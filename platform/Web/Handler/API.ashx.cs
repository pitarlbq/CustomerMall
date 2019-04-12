using Foresight.DataAccess;
using Foresight.DataAccess.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using Utility;
using Web.APPCode;
using WeiXin.Domain;

namespace Web.Handler
{
    /// <summary>
    /// API 的摘要说明
    /// </summary>
    public class API : IHttpHandler, IRequiresSessionState
    {
        const string LogModule = "APIHandler";
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string visit = context.Request.Params["visit"];
            if (string.IsNullOrEmpty(visit))
            {
                LogHelper.WriteDebug("API", "visit为空");
                context.Response.Write(null);
                return;
            }
            visit = visit.ToLower();
            try
            {
                switch (visit)
                {
                    case "getjssignature":
                        getjssignature(context);
                        break;
                    case "qrscenescan":
                        qrscenescan(context);
                        break;
                    case "addweixinuser":
                        addweixinuser(context);
                        break;
                    case "unsubscribwexinuser":
                        unsubscribwexinuser(context);
                        break;
                    case "getuserinfo":
                        getuserinfo(context);
                        break;
                    case "loadtongzhi":
                        loadtongzhi(context);
                        break;
                    case "loadtongzhilist":
                        loadtongzhilist(context);
                        break;
                    case "getroomsourcebyopenid":
                        getroomsourcebyopenid(context);
                        break;
                    case "getbianmin":
                        getbianmin(context);
                        break;
                    case "savesystemmsg":
                        savesystemmsg(context);
                        break;
                    case "deletesystemmsg":
                        deletesystemmsg(context);
                        break;
                    case "getwechatconfig":
                        getwechatconfig(context);
                        break;
                    default:
                        WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "Unkown Visit: " + visit);
                        break;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(LogModule, "visit: " + visit, ex);
                context.Response.Write("{\"status\":false}");
            }
        }
        private void getwechatconfig(HttpContext context)
        {
            List<Utility.MobileWechatModel> list = new List<Utility.MobileWechatModel>();
            Utility.MobileWechatModel item = new Utility.MobileWechatModel();
            item.Name = "AppID";
            item.Value = PaymentConfig.WeiXinConfig.AppID;
            list.Add(item);
            item = new Utility.MobileWechatModel();
            item.Name = "AppSecret";
            item.Value = PaymentConfig.WeiXinConfig.AppSecret;
            list.Add(item);
            item = new Utility.MobileWechatModel();
            item.Name = "Token";
            item.Value = PaymentConfig.WeiXinConfig.Token;
            list.Add(item);
            WebUtil.WriteJson(context, new { status = true, list = list });
        }
        private void deletesystemmsg(HttpContext context)
        {
            string liststr = context.Request["list"];
            if (string.IsNullOrEmpty(liststr))
            {
                WebUtil.WriteJson(context, new { status = false });
                return;
            }
            int[] list = new int[] { };
            try
            {
                list = JsonConvert.DeserializeObject<int[]>(liststr);
            }
            catch (Exception)
            {
            }
            var msg_list = Foresight.DataAccess.SystemMsg.GetSystemMsgs();
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    foreach (var ID in list)
                    {
                        var msg = msg_list.FirstOrDefault(p => p.FromID == ID);
                        if (msg != null)
                        {
                            msg.Delete(helper);
                        }
                    }
                    helper.Commit();
                }
                catch (Exception)
                {
                    helper.Rollback();
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void savesystemmsg(HttpContext context)
        {
            string liststr = context.Request["list"];
            if (string.IsNullOrEmpty(liststr))
            {
                WebUtil.WriteJson(context, new { status = false });
                return;
            }
            Utility.SystemMsgModel[] list = new SystemMsgModel[] { };
            try
            {
                string new_data = HttpUtility.UrlDecode(liststr, Encoding.UTF8);
                list = JsonConvert.DeserializeObject<Utility.SystemMsgModel[]>(new_data);

            }
            catch (Exception)
            {
            }
            var msg_list = Foresight.DataAccess.SystemMsg.GetSystemMsgs();
            foreach (var item in list)
            {
                var msg = msg_list.FirstOrDefault(p => p.FromID == item.ID);
                if (msg == null)
                {
                    msg = new SystemMsg();
                    msg.AddTime = item.AddTime;
                    msg.FromID = item.ID;
                    msg.Title = item.Title;
                    msg.ContentSummary = item.ContentSummary;
                    msg.SortOrder = item.SortOrder;
                    msg.IsTopShow = item.IsTopShow;
                }
                else
                {
                    msg.Title = item.Title;
                    msg.ContentSummary = item.ContentSummary;
                    msg.SortOrder = item.SortOrder;
                    msg.IsTopShow = item.IsTopShow;
                }
                msg.Save();
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void getbianmin(HttpContext context)
        {
            var list = Foresight.DataAccess.Wechat_Contact.GetWechat_Contacts();
            List<string> titles = list.Select(p => p.PhoneType).Distinct().ToList();
            List<Dictionary<string, object>> diclist = new List<Dictionary<string, object>>();
            foreach (var title in titles)
            {
                Dictionary<string, object> dic = new Dictionary<string, object>();
                dic["title"] = string.IsNullOrEmpty(title) ? "" : Utility.EnumHelper.GetDescription(typeof(Utility.EnumModel.WechatContactType), title);
                dic["phonelist"] = list.Where(p => p.PhoneType.Equals(title));
                diclist.Add(dic);
            }
            WebUtil.WriteJsonResult(context, new { list = diclist });
        }
        private void getroomsourcebyopenid(HttpContext context)
        {
            string openid = GetOpenID(context);
            var list = ViewRoomBasic.GetRoomBasicListByOpenID(openid);
            WebUtil.WriteJsonResult(context, list);
        }
        private void loadtongzhilist(HttpContext context)
        {
            string MsgType = context.Request.Params["MsgType"];
            string OpenID = GetOpenID(context);
            List<int> ProjectIDList = WechatUser_Project.GetWechatUser_ProjectByOpenid(OpenID).Select(p => p.ProjectID).ToList();
            if (ProjectIDList.Count == 0)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "list为空");
                return;
            }
            long totals = 0;
            var list = Foresight.DataAccess.Wechat_Msg.GetWechat_MsgListByMsgType(MsgType, 0, int.MaxValue, out totals, IsWechatSend: true, ProjectIDList: ProjectIDList).ToArray();
            int ID = WebUtil.GetIntValue(context, "ID");
            if (ID > 0)
            {
                list = list.Where(p => p.ID == ID).ToArray();
            }
            var items = list.Select(p =>
            {
                var dic = p.ToJsonObject();
                dic["HTMLContent"] = string.Empty;
                dic["publishdate"] = p.PublishTime.ToString("yyyy年MM月dd日");
                return dic;
            });
            WebUtil.WriteJsonResult(context, new { list = items });
        }
        private void loadtongzhi(HttpContext context)
        {
            string MsgType = Utility.EnumModel.WechatMsgType.tongzhi.ToString();
            string OpenID = GetOpenID(context);
            List<int> ProjectIDList = WechatUser_Project.GetWechatUser_ProjectByOpenid(OpenID).Select(p => p.ProjectID).ToList();
            long totals = 0;
            var list = Foresight.DataAccess.Wechat_Msg.GetWechat_MsgListByMsgType(MsgType, 0, 5, out totals, IsWechatSend: true, ProjectIDList: ProjectIDList).ToArray();
            var tongzhilist = list.Select(p =>
            {
                var item = new { ID = p.ID, MsgTitle = p.MsgTitle, PicPath = p.PicPath, PublishTime = p.PublishTime > DateTime.MinValue ? p.PublishTime.ToString("yyyy-MM-dd HH:mm") : "", MsgContent = p.PublishTime };
                return item;
            }).ToList();
            MsgType = Utility.EnumModel.WechatMsgType.huodong.ToString();
            list = Foresight.DataAccess.Wechat_Msg.GetWechat_MsgListByMsgType(MsgType, 0, 5, out totals, IsWechatSend: true, ProjectIDList: ProjectIDList).ToArray();
            var huodonglist = list.Select(p =>
            {
                var item = new { ID = p.ID, MsgTitle = p.MsgTitle, PicPath = p.PicPath, PublishTime = p.PublishTime > DateTime.MinValue ? p.PublishTime.ToString("yyyy-MM-dd HH:mm") : "", MsgContent = p.PublishTime };
                return item;
            }).ToList();
            WebUtil.WriteJsonResult(context, new { tongzhilist = tongzhilist, huodonglist = huodonglist });
        }
        private void getuserinfo(HttpContext context)
        {
            string OpenID = GetOpenID(context);
            if (string.IsNullOrEmpty(OpenID))
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "获取用户OpenID失败");
                return;
            }
            ErrInfo err = new ErrInfo();
            string accesstoken = WeixinHelper.GetAccessToken(null);
            var wechatuser = WeixinHelper.GetUserInfo(OpenID, accesstoken, out err);
            if (wechatuser == null)
            {
                if (err.ErrCode == 40001)//invalid credential
                {
                    accesstoken = WeixinHelper.GetAccessToken(accesstoken);
                    wechatuser = WeixinHelper.GetUserInfo(OpenID, accesstoken, out err);
                }
            }
            if (wechatuser == null)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, err.ErrMsg);
                return;
            }
            Foresight.DataAccess.Wechat_User user = Foresight.DataAccess.Wechat_User.GetWechat_UserByUserOpenID(OpenID);
            if (user == null)
            {
                user = new Foresight.DataAccess.Wechat_User()
                {
                    OpenId = OpenID,
                };
            }
            if (!string.IsNullOrEmpty(wechatuser.NickName))
                user.NickName = wechatuser.NickName;

            if (!string.IsNullOrEmpty(wechatuser.HeadImgUrl))
                user.HeadImgUrl = wechatuser.HeadImgUrl.Replace("\\", "");

            if (!string.IsNullOrEmpty(wechatuser.Sex))
                user.Sex = int.Parse(wechatuser.Sex);

            if (!string.IsNullOrEmpty(wechatuser.City))
                user.City = wechatuser.City;

            if (!string.IsNullOrEmpty(wechatuser.Country))
                user.Country = wechatuser.Country;

            if (!string.IsNullOrEmpty(wechatuser.Province))
                user.Province = wechatuser.Province;

            if (!string.IsNullOrEmpty(wechatuser.Language))
                user.Language = wechatuser.Language;

            if (!string.IsNullOrEmpty(wechatuser.SubScribe))
                user.SubScribe = int.Parse(wechatuser.SubScribe);

            if (!string.IsNullOrEmpty(wechatuser.SubscribeTime))
                user.SubscribeTime = ConvertDate(wechatuser.SubscribeTime);
            if (user.SubScribe != 0)
            {
                user.UnSubscribeTime = DateTime.MinValue;
            }
            else
            {
                if (user.UnSubscribeTime == DateTime.MinValue)
                {
                    user.UnSubscribeTime = DateTime.Now;
                }
            }
            if (user.FirstSubScribeTime == DateTime.MinValue)
            {
                user.FirstSubScribeTime = user.SubscribeTime;
            }
            user.Save();
            WebUtil.WriteJsonResult(context, new { status = true, HeadImgUrl = user.HeadImgUrl, NickName = user.NickName });
        }
        private void unsubscribwexinuser(HttpContext context)
        {
            DateTime timenow = DateTime.Now;
            string openID = context.Request.Form["OpenID"];
            if (string.IsNullOrEmpty(openID))
            {
                LogHelper.WriteError(LogModule, "添加微信用户失败。缺少参数：OpenID", null);
                WebUtil.WriteJson(context, null);
                return;
            }
            var user = Wechat_User.GetWechat_UserByUserOpenID(openID);
            if (user != null)
            {
                user.UnSubscribeTime = timenow;
                user.SubScribe = 0;

                Wechat_Log log = new Wechat_Log()
                {
                    OpenID = openID,
                    OperationTime = timenow,
                    Operation = "取消关注",
                };
                using (SqlHelper helper = new SqlHelper())
                {
                    try
                    {
                        helper.BeginTransaction();
                        user.Save(helper);
                        log.Save(helper);
                        helper.Commit();
                    }
                    catch (Exception ex)
                    {
                        helper.Rollback();
                        LogHelper.WriteError(LogModule, "visit: unsubscribwexinuser", ex);
                    }
                }
            }
            WebUtil.WriteJson(context, "OK");
        }
        private void addweixinuser(HttpContext context)
        {
            string result = string.Empty;
            var user = CreateWechatUser(context, out result);
            WebUtil.WriteJson(context, result);
        }
        private void qrscenescan(HttpContext context)
        {
            string result = string.Empty;
            string openID = context.Request.Params["OpenID"];
            string qrSceneIDStr = context.Request.Params["QrSceneID"];
            int sceneID = 0;
            int.TryParse(qrSceneIDStr, out sceneID);
            if (sceneID > 0 && !string.IsNullOrEmpty(openID))
            {
                var record = Wechat_QrScene.GetWechat_QrScene(sceneID);
                if (record == null)
                {
                    WebUtil.WriteJson(context, null);
                    return;
                }
                bool isChanged = false;
                var wUser = Wechat_User.GetWechat_UserByUserOpenID(openID);
                if (wUser == null)
                {
                    isChanged = true;
                    wUser = new Wechat_User();
                    wUser.OpenId = openID;
                }
                if (wUser.FromQrID <= 0)
                {
                    wUser.FromQrID = record.ID;
                    isChanged = true;
                }
                if (isChanged)
                {
                    wUser.Save();
                }
                string Token = context.Request.Params["accesstoken"];
                result = SaveWechatProject(openID, record.ProjectID);
            }
            WebUtil.WriteJson(context, result);
        }
        private void getjssignature(HttpContext context)
        {
            string appId = PaymentConfig.WeiXinConfig.AppID;
            long timestamp = (long)((DateTime.Now - new DateTime(1970, 1, 1)).TotalSeconds);
            string nonceStr = "yongyou2016";
            string url = context.Request.Params["pageurl"];
            if (!url.StartsWith("http"))
            {
                url = WebUtil.GetContextPath() + url;
            }
            string signature = WeixinHelper.GetJsApiSignature(nonceStr, timestamp, url);
            WebUtil.WriteJsonResult(context, new { url = url, appId = appId, timestamp = timestamp, nonceStr = nonceStr, signature = signature });
        }
        #region 通用方法
        private DateTime ConvertDate(string datestr)
        {
            DateTime conTime = new DateTime();
            DateTime firstTime = new DateTime(1970, 1, 1);
            int stime = -1;
            if (int.TryParse(datestr, out stime) == false)
            {
                conTime = Convert.ToDateTime(datestr);
            }
            else
            {
                conTime = Convert.ToDateTime(firstTime.AddSeconds(stime));
            }
            return conTime;
        }
        private string GetOpenID(HttpContext context)
        {
            string CookieKey = WebUtil.GetOpenIDPrefix();
            string openid = context.Request[CookieKey];
            if (string.IsNullOrEmpty(openid))
            {
                throw new Exception(CookieKey + ": openid获取失败");
            }
            return openid;
        }
        private Wechat_User CreateWechatUser(HttpContext context, out string result)
        {
            result = string.Empty;
            string openID = context.Request.Form["OpenID"];
            string city = context.Request.Form["City"];
            string country = context.Request.Form["Country"];
            string nickName = context.Request.Form["NickName"];
            string headImgUrl = context.Request.Form["HeadImgUrl"];
            string province = context.Request.Form["Province"];
            string language = context.Request.Form["Language"];
            string sex = context.Request.Form["Sex"];
            string subScribe = context.Request.Form["SubScribe"];
            string subscribeTimeStamp = context.Request.Form["SubscribeTime"];
            //todo：绑定微信粉丝来源
            string qrScene = context.Request.Form["QrScene"];
            string ticket = context.Request.Form["Ticket"];


            DateTime subscribeTime = DateTime.Now;
            if (!string.IsNullOrEmpty(subscribeTimeStamp))
            {
                subscribeTime = new DateTime(1970, 1, 1).AddSeconds(Convert.ToInt32(subscribeTimeStamp));
            }

            if (string.IsNullOrEmpty(openID))
            {
                LogHelper.WriteError(LogModule, "添加微信用户失败。缺少参数：OpenID", null);
                return null;
            }
            if (string.IsNullOrEmpty(nickName))
            {
                LogHelper.WriteError(LogModule, "添加微信用户失败。缺少参数：NickName", null);
                return null;
            }


            var user = Wechat_User.GetWechat_UserByUserOpenID(openID);
            if (user == null)
            {
                user = new Foresight.DataAccess.Wechat_User()
                {
                    OpenId = openID,
                };
            }
            if (!string.IsNullOrEmpty(qrScene))
            {
                int qrSceneID = 0;
                int.TryParse(qrScene, out qrSceneID);
                if (qrSceneID > 0)
                {
                    var scene = Wechat_QrScene.GetWechat_QrScene(qrSceneID);
                    if (scene != null)
                    {
                        if (user.FromQrID <= 0)
                        {
                            user.FromQrID = scene.ID;
                        }
                        result = SaveWechatProject(openID, scene.ProjectID);
                    }
                }
            }
            user.SubScribe = int.Parse(subScribe);
            if (user.SubScribe != 0)
            {
                user.City = city;
                user.Country = country;
                user.NickName = nickName;
                user.HeadImgUrl = headImgUrl;
                user.Province = province;
                user.Sex = int.Parse(sex);
                user.SubscribeTime = subscribeTime;
                user.UnSubscribeTime = DateTime.MinValue;
                user.Language = language;
            }
            else
            {
                if (user.UnSubscribeTime == DateTime.MinValue)
                {
                    user.UnSubscribeTime = DateTime.Now;
                }
            }
            if (user.FirstSubScribeTime == DateTime.MinValue)
            {
                user.FirstSubScribeTime = user.SubscribeTime;
            }
            user.Save();

            return user;
        }
        private string SaveWechatProject(string OpenID, int ProjectID)
        {
            var project = Project.GetProject(ProjectID);
            if (project == null)
            {
                return "房间已删除，请重新生成二维码";
            }
            var wProject = WechatUser_Project.GetWechatUser_Project(ProjectID, OpenID);
            if (wProject == null)
            {
                //绑定房间
                wProject = new WechatUser_Project();
                wProject.ProjectID = ProjectID;
                wProject.OpenID = OpenID;
                wProject.Save();
                return "房间" + project.Name + "与您关联成功";
            }
            //解绑房间
            wProject.Delete();
            return "房间" + project.Name + "已与您解除关联";
        }
        #endregion
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}