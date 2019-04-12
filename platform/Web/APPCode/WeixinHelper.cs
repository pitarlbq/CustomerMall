using Foresight.DataAccess.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Xml;
using Utility;
using WeiXin;
using WeiXin.Domain;
using WeiXin.Request;
using WeiXin.Response;

namespace Web.APPCode
{
    public class WeixinHelper
    {
        public static bool GrabWechat_Chat(int UserID, Foresight.DataAccess.Wechat_ChatRequest chat_request, out string errormsg, out Foresight.DataAccess.Wechat_ServiceUser user)
        {
            errormsg = string.Empty;
            user = null;
            List<SqlParameter> parameters = new List<SqlParameter>();
            using (SqlHelper helper = new SqlHelper())
            {
                if (chat_request == null)
                {
                    errormsg = "其他客服已接单";
                    return false;
                }
                user = Foresight.DataAccess.Wechat_ChatRequest.GetWechat_ServiceUserByUserID(UserID, helper);
                if (user == null)
                {
                    errormsg = "您不是客服人员";
                    return false;
                }
                var result = MessageHandler.CreateCustomerService(WeixinHelper.GetAccessToken(null), user.AccountName, chat_request.OpenID);
                if (result.IsError)
                {
                    errormsg = result.ErrorMsg;
                    return false;
                }
                try
                {
                    helper.BeginTransaction();
                    bool update_result = Foresight.DataAccess.Wechat_ChatRequest.SaveWechat_ChatRequestByUserID(UserID, chat_request.ID, helper);
                    helper.Commit();
                    if (update_result)
                    {
                        return true;
                    }
                    errormsg = "其他客服已接单";
                    return false;
                }
                catch (Exception ex)
                {
                    errormsg = ex.Message;
                    helper.Rollback();
                    return false;
                }
            }
        }
        public static void SaveImgbyMediaid(int serviceid, string mediaid, string OpenID, SqlHelper helper)
        {

            string ImgPath = GetIMGURLByMediaID(mediaid);
            Image img = Image.FromFile(HttpContext.Current.Server.MapPath(ImgPath));
            string relativepath = "pics/service";
            string rootpath = HttpContext.Current.Server.MapPath("~/" + relativepath);
            string datefolder = DateTime.Now.Date.ToString("yyyyMM");
            string filenameWithouExtesion = Guid.NewGuid().ToString("N");
            string RawPicture = WebUtil.CreatThumbnail(img, System.IO.Path.Combine(rootpath, string.Format("raw\\{0}\\{1}.jpg", datefolder, filenameWithouExtesion)), 0, 0);
            string ThumbnailHD = WebUtil.CreatThumbnail(img, System.IO.Path.Combine(rootpath, string.Format("hd\\{0}\\{1}.jpg", datefolder, filenameWithouExtesion)), 540, 960);
            string ThumbnailSD = WebUtil.CreatThumbnail(img, System.IO.Path.Combine(rootpath, string.Format("sd\\{0}\\{1}.jpg", datefolder, filenameWithouExtesion)), 180, 320);
            var storepic = new Foresight.DataAccess.Wechat_ServiceImg()
            {
                ServiceID = serviceid,
                AddTime = DateTime.Now,
                IsVertical = img.Height > img.Width,
                FileName = ImgPath,
                Large = RawPicture.Replace(rootpath, "\\" + relativepath).Replace("\\", "/"),
                Medium = ThumbnailHD.Replace(rootpath, "\\" + relativepath).Replace("\\", "/"),
                Icon = ThumbnailSD.Replace(rootpath, "\\" + relativepath).Replace("\\", "/"),
                OpenID = OpenID,
            };
            storepic.Save(helper);
        }
        public static string GetIMGURLByMediaID(string mediaid)
        {
            string filepath = "/upload/service/";
            string phypath = HttpContext.Current.Server.MapPath(filepath);
            if (!Directory.Exists(phypath))
            {
                Directory.CreateDirectory(phypath);
            }
            DownloadMediaResponse response = null;
            int retry = 0;
            string mAppId = PaymentConfig.WeiXinConfig.AppID;
            string mAppSecret = PaymentConfig.WeiXinConfig.AppSecret;
            do
            {
                IMpClient mpClient = new MpClient();
                DownloadMediaRequest request = new DownloadMediaRequest()
                {
                    AppIdInfo = new AppIdInfo() { AppID = mAppId, AppSecret = mAppSecret },
                    AccessToken = GetAccessToken(null),
                    MediaId = mediaid,
                    SaveDir = phypath,
                };
                response = mpClient.Execute(request);
                retry++;
            } while (retry < 2 && response.IsError);
            if (response.IsError)
            {
                LogHelper.WriteInfo("GetIMGURLByMediaID失败", "获取图片素材(" + mediaid + ")基本信息失败，错误信息为：" + response.ErrInfo.ErrCode + "-" + response.ErrInfo.ErrMsg);
                return string.Empty;
            }
            else
            {
                return filepath + response.SaveFileName;
            }
        }
        public static string CreateQrCode(int ProjectID)
        {
            var qrscene = Foresight.DataAccess.Wechat_QrScene.GetWechat_QrSceneByProjectID(ProjectID);
            if (qrscene == null)
            {
                qrscene = new Foresight.DataAccess.Wechat_QrScene();
                qrscene.CreationTime = DateTime.Now;
                qrscene.Save();
            }
            if (DateTime.Now < qrscene.ExpiredTime && !string.IsNullOrEmpty(qrscene.PicUrl))
            {
                var PicPath = HttpContext.Current.Server.MapPath(qrscene.PicUrl);
                if (File.Exists(PicPath))
                {
                    return qrscene.PicUrl;
                }
            }
            int ExpireSecond = 2592000;
            var response = SendQrCodeCreateRequest(qrscene.ID, Utility.EnumModel.QR_SCENE.QR_SCENE.ToString(), ExpireSecond);
            qrscene.Ticket = response.Ticket;
            qrscene.ScanUrl = response.Url.Replace("\\", "");
            qrscene.ExpiredTime = DateTime.Now.AddSeconds(response.ExpireSeconds);
            string squarePicUrl = null;
            qrscene.PicUrl = CreateQrCode(qrscene.ScanUrl, out squarePicUrl);
            qrscene.SquarePicUrl = squarePicUrl;
            qrscene.ProjectID = ProjectID;
            qrscene.Save();
            return qrscene.PicUrl;
        }
        public static QrCodeCreateResponse SendQrCodeCreateRequest(int sceneID, string QrType, int ExpireSeconds)
        {
            int retry = 0;
            QrCodeCreateResponse res = null;
            do
            {
                QrCodeCreateRequest reqeust = new QrCodeCreateRequest()
                {
                    AccessToken = GetAccessToken(null),
                    AppIdInfo = new AppIdInfo()
                    {
                        AppID = PaymentConfig.WeiXinConfig.AppID,
                        AppSecret = PaymentConfig.WeiXinConfig.AppSecret,
                    },
                    QrCodeCreateMessage = new QrCodeCreateMessage()
                    {
                        SceneId = sceneID,
                        ExpireSeconds = ExpireSeconds,
                        ActionName = QrType,
                    }
                };
                IMpClient mp = new MpClient();

                res = mp.Execute(reqeust);
                if (!RefreshAccessToken(res, reqeust.AccessToken))
                {
                    break;
                }
                retry++;
            } while (retry < 2 && res.IsError);
            return res;
        }
        private static bool RefreshAccessToken(MpResponse res, string accesstoken)
        {
            if (res.IsError && res.ErrInfo.ErrCode == 40001)//invalid credential
            {
                LogHelper.WriteDebug("CreateQrCode", "accesstoken expired:" + accesstoken);
                GetAccessToken(null);
                return true;
            }
            return false;
        }
        public static string CreateQrCode(string scanUrl, out string squarePicUrl)
        {
            squarePicUrl = null;
            try
            {
                string logo_png = HttpContext.Current.Server.MapPath("~/qrcode_logo.png");
                Bitmap bmp = QrCodeHelper.CreateQrCode(scanUrl, logo_png);
                //int borderOffset = 30;

                //int h = bmp.Height + borderOffset * 2;
                //int w = h * 9 / 5;
                //Bitmap tmpBmp = new Bitmap(w, h);

                //int offsetX = (tmpBmp.Width - tmpBmp.Height) / 2 + borderOffset;
                //int offsetY = borderOffset;
                //Graphics g = Graphics.FromImage(tmpBmp);
                //g.FillRectangle(Brushes.White, 0, 0, tmpBmp.Width, tmpBmp.Height);
                //g.DrawImage(bmp, offsetX, offsetY, bmp.Width, bmp.Height);
                int w = bmp.Width;
                int h = bmp.Height;
                Bitmap tmpBmp = new Bitmap(w + 10, h + 10);
                Graphics g = Graphics.FromImage(tmpBmp);
                g.FillRectangle(Brushes.White, 0, 0, tmpBmp.Width, tmpBmp.Height);
                g.DrawImage(bmp, 5, 5, w, h);

                string filename = "/pics/qrcode/" + DateTime.Today.ToString("yyyyMM") + "/" + DateTime.Today.ToString("dd") + "/" + Guid.NewGuid().ToString("N") + ".png";
                string fullpath = HttpContext.Current.Server.MapPath("~" + filename);
                string dir = System.IO.Path.GetDirectoryName(fullpath);
                if (!System.IO.Directory.Exists(dir))
                {
                    System.IO.Directory.CreateDirectory(dir);
                }
                tmpBmp.Save(fullpath);

                string squareFullpath = fullpath.Replace(".png", "_square.png");
                bmp.Save(squareFullpath);

                squarePicUrl = filename.Replace(".png", "_square.png").Replace("\\", "/");

                return filename.Replace("\\", "/");
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("二维码管理", "生成QRCode图片失败", ex);
            }
            finally
            {
                GC.Collect();
            }
            return null;
        }
        public static User GetUserInfo(string openid, string accessToken, out ErrInfo err)
        {
            err = null;
            IMpClient mpClient = new MpClient();

            GetUserInfoRequest request2 = new GetUserInfoRequest()
            {
                AccessToken = accessToken,
                OpenId = openid,
            };
            var response2 = mpClient.Execute(request2);
            if (response2.IsError)
            {
                err = response2.ErrInfo;
                LogHelper.WriteError("Foresight.Winxin", "获取用户基本信息失败，错误信息为：" + response2.ErrInfo.ErrCode + "-" + response2.ErrInfo.ErrMsg, null);
                return null;
            }
            else
            {
                return response2.UserInfo;
            }
        }
        public static List<string> GetAttentionsList()
        {
            List<string> openIds = new List<string>();
            while (true)
            {
                IMpClient mpClient = new MpClient();
                GetAttentionsRequest request = new GetAttentionsRequest()
                {
                    AccessToken = GetAccessToken(null),
                };
                if (openIds.Count > 0)
                {
                    request.NextOpenId = openIds.Last();
                }
                var response = mpClient.Execute(request);
                if (response.IsError)
                {
                    LogHelper.WriteError("WeixinHelper", "获取关注者列表失败，错误信息为：" + response.ErrInfo.ErrCode + "-" + response.ErrInfo.ErrMsg, null);
                    break;
                }
                else
                {
                    if (response.Attentions.data.openid.Count > 0)
                    {
                        openIds.AddRange(response.Attentions.data.openid);
                    }
                    if (response.Attentions.total <= openIds.Count)
                    {
                        break;
                    }
                }
            }

            return openIds;
        }
        public static string GetAccessToken(string oldaccesstoken)
        {
            return GetFromWxServer(new Dictionary<string, string>() {
                {"action","getaccesstoken"},
                {"oldaccesstoken",oldaccesstoken},
            });
        }
        public static string GetOpenIDByCode(string code)
        {
            return GetFromWxServer(new Dictionary<string, string>() {
                {"action","getopenid"},
                {"code",code},
            });
        }
        public static string GetJsApiSignature(string noncestr, long timestamp, string url)
        {
            return GetFromWxServer(new Dictionary<string, string>() {
                {"action","getjssignature"},
                {"noncestr",noncestr},
                {"timestamp",timestamp.ToString()},
                {"url",url},
            });
        }
        public static string GetFromWxServer(Dictionary<string, string> queryparameter)
        {
            string apiurl = PaymentConfig.WeiXinConfig.WxApiUrl + "/api/api.ashx";
            if (queryparameter != null && queryparameter.Keys.Count > 0)
            {
                string querystr = string.Join("&", queryparameter.Select(p => p.Key + "=" + HttpUtility.UrlEncode(p.Value)).ToArray());
                if (apiurl.EndsWith("?") || apiurl.EndsWith("&"))
                {
                    apiurl += querystr;
                }
                else if (apiurl.Contains("?"))
                {
                    apiurl += ("&" + querystr);
                }
                else
                {
                    apiurl += ("?" + querystr);
                }
            }

            var request = System.Net.HttpWebRequest.Create(apiurl);
            request.Method = "GET";

            var res = request.GetResponse();
            string result = null;

            using (StreamReader sr = new StreamReader(res.GetResponseStream()))
            {
                result = sr.ReadToEnd();
            }
            res.Close();
            return result;
        }
        public static string ResolveClientUrl(string url)
        {
            string clientUrl = string.Empty;
            if (!string.IsNullOrEmpty(url))
            {
                if (url.StartsWith("http://", StringComparison.OrdinalIgnoreCase) || url.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
                {
                    clientUrl = url;
                }
                else
                {
                    while (url.StartsWith("/"))
                    {
                        url = url.Substring(1);
                    }
                    string siteurl = PaymentConfig.WeiXinConfig.Oauth2Url;
                    if (!siteurl.EndsWith("/"))
                    {
                        siteurl += "/";
                    }
                    clientUrl = siteurl + url;
                }
            }

            return clientUrl;
        }
        public static string ResovleOauth2Url(string url)
        {
            var wx_EnableOauth2 = string.Compare(ConfigurationManager.AppSettings["wx_EnableOauth2"], "true", true) == 0;

            return ResovleOauth2Url(url, wx_EnableOauth2);
        }

        public static string ResovleOauth2Url(string url, bool userOauth2, string State = "")
        {
            string appID = PaymentConfig.WeiXinConfig.AppID;
            return userOauth2 ? ("https://open.weixin.qq.com/connect/oauth2/authorize?appid=" + appID + "&redirect_uri=" + HttpUtility.UrlEncode(ResolveClientUrl(url)) + "&response_type=code&scope=snsapi_base&state=" + State + "&connect_redirect=1#wechat_redirect") : ResolveClientUrl(url);
        }
        /// <summary>
        /// 发送模板消息
        /// </summary>
        /// <param name="type"></param>
        /// <param name="touser"></param>
        /// <param name="contentList"></param>
        /// <returns></returns>
        public static TemPlateMessageResponse SendTemPlateMessage(string template_file_path, string touser, List<string> contentList, string url)
        {
            var ret = new TemPlateMessageResponse();
            var template_id = string.Empty;
            var msgitemlist = new List<TemPlateMessageItem>();
            var doc = new XmlDocument();
            try
            {
                string application_path = WebUtil.getApplicationPath().ToLower();
                if (!string.IsNullOrEmpty(application_path))
                {
                    if (!template_file_path.ToLower().StartsWith(application_path))
                    {
                        template_file_path = application_path + template_file_path;
                    }
                }
                string filename = HttpContext.Current.Server.MapPath(template_file_path);
                doc.Load(filename);
                //加载Xml文件  
                var rootElem = doc.DocumentElement; //获取根节点  
                if (rootElem != null)
                {
                    template_id = rootElem.GetElementsByTagName("template_id")[0].InnerText;
                    var parmNodes = rootElem.GetElementsByTagName("parm"); //获取parm子节点集合  
                    foreach (XmlNode node in parmNodes)
                    {
                        var parmname = ((XmlElement)node).GetAttribute("name"); //获取parmname属性值  
                        var colorval = ((XmlElement)node).GetAttribute("color"); //获取colorval属性值  
                        msgitemlist.Add(new TemPlateMessageItem { color = colorval, key = parmname });
                    }
                    for (var i = 0; i < msgitemlist.Count; i++)
                    {
                        msgitemlist[i].value = contentList[i];
                    }
                    ret = MessageHandler.SendTemPlateMessage(GetAccessToken(null), touser, template_id, msgitemlist, url);
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("TemPlateMessageResponse", template_file_path, ex);
            }
            return ret;
        }
        public static string GetSignString(Dictionary<string, string> dic)
        {
            string key = PaymentConfig.WeiXinConfig.MCHKey;//商户平台 API安全里面设置的KEY  32位长度
            //排序
            dic = dic.OrderBy(d => d.Key).ToDictionary(d => d.Key, d => d.Value);
            //连接字段
            var sign = dic.Aggregate("", (current, d) => current + (d.Key + "=" + d.Value + "&"));
            sign += "key=" + key;
            //MD5
            return Md5Hash(sign).ToUpper();
        }
        public static string GetAPPSignString(Dictionary<string, string> dic)
        {
            string key = PaymentConfig.WeiXinConfig.MobileMCHKey;//商户平台 API安全里面设置的KEY  32位长度
            //排序
            dic = dic.OrderBy(d => d.Key).ToDictionary(d => d.Key, d => d.Value);
            //连接字段
            var sign = dic.Aggregate("", (current, d) => current + (d.Key + "=" + d.Value + "&"));
            sign += "key=" + key;
            //MD5
            return Md5Hash(sign).ToUpper();
        }
        private static string Md5Hash(string input)
        {
            return Utility.Tools.Md5Hash(input);
        }
        public static string GetPayBodyContent(string ProductNames)
        {
            string body = new SiteConfig().SystemName + ProductNames;
            return body;
        }
        public static Foresight.DataAccess.Project[] GetMyWechatXiaoquList(string wx_openid, bool requireCheckRoom = true, bool HasRoom = false)
        {
            if (requireCheckRoom)
            {
                HasRoom = Foresight.DataAccess.WechatUser_Project.CheckWechatUser_ProjectByOpenid(wx_openid);
            }
            Foresight.DataAccess.Project[] xiaoqu_list = new Foresight.DataAccess.Project[] { };
            //我的小区
            if (HasRoom)
            {
                xiaoqu_list = Foresight.DataAccess.Project.GetTopProjectListByOpenID(wx_openid);
            }
            else
            {
                xiaoqu_list = Foresight.DataAccess.Project.GetAllChildProjectListByIDs(null, 1);
            }
            return xiaoqu_list;
        }
        public static List<int> GetMyWechatProjectIDList(string wx_openid, out bool HasRoom)
        {
            var IDList = new List<int>();
            HasRoom = Foresight.DataAccess.WechatUser_Project.CheckWechatUser_ProjectByOpenid(wx_openid);
            var project = CacheHelper.GetMyWechatCurrentProject(wx_openid);
            if (project != null)
            {
                IDList.Add(project.ID);
            }
            return IDList;
        }
    }
    /// <summary>
    /// 微信模板信息类型
    /// </summary>
    public enum TemPlateMessageType
    {
        物业管理通知,
        新服务通知创建通知,
        物业账单催缴通知
    }
}