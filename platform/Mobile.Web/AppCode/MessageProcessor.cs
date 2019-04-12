using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeiXin.Domain;
using WeiXin.Util;
using WeiXin.Request;
using WeiXin.Response;
using Utility;
using System.Configuration;
using System.Text.RegularExpressions;
using System.IO;
using System.Web.Script.Serialization;
using System.Web.Security;
using System.Web;
using WeiXin;
using Utility;

namespace Mobile.Web.AppCode
{
    public class MessageProcessor : IMessageProcessor
    {
        const string LogModule = "Mobile.Web.AppCode.MessageProcessor";

        ///
        /// 处理消息
        ///
        ///消息对象
        ///参数（用于具体业务传递参数用）
        ///是否处理成功
        public string mAppId = "";
        public string mAppSecret = "";
        private string mAccessToken = string.Empty;
        private object mAccessTokenLocker = new object();
        private DateTime mAccessTokenExpiredTime = DateTime.Now;
        private string mJsApiTicket = string.Empty;
        private DateTime mJsApiTicketExpiredTime = DateTime.Now;
        private float mAccessTokenCachePeriod = 0.5F;
        private string mWxCardApiTicket = string.Empty;
        private DateTime mWxCardApiTicketExpiredTime = DateTime.Now;

        private static MessageProcessor sInstance = null;

        static MessageProcessor()
        {
            var wx_config = new WechatConfig();
            sInstance = new MessageProcessor(wx_config.AppID, wx_config.AppSecret);
        }

        public static MessageProcessor Instance
        {
            get
            {
                return sInstance;
            }
        }

        public MessageProcessor(string appId, string appSecret)
        {
            mAppId = appId;
            mAppSecret = appSecret;

            try
            {
                this.mAccessTokenCachePeriod = float.Parse(ConfigurationManager.AppSettings["AccessTokenCachePeriod"]);
            }
            catch
            {
            }
        }

        public string GetAccessToken()
        {
            return GetAccessToken(null);
        }

        public string GetAccessToken(string oldAccessToken)
        {
            if (string.IsNullOrEmpty(mAccessToken) || mAccessTokenExpiredTime <= DateTime.Now || mAccessToken == oldAccessToken)
            {
                lock (mAccessTokenLocker)
                {
                    if (string.IsNullOrEmpty(mAccessToken) || mAccessTokenExpiredTime <= DateTime.Now || mAccessToken == oldAccessToken)
                    {
                        DateTime timenow = DateTime.Now;

                        IMpClient mpClient = new MpClient();
                        AccessTokenGetRequest request = new AccessTokenGetRequest()
                        {
                            AppIdInfo = new AppIdInfo() { AppID = mAppId, AppSecret = mAppSecret }
                        };
                        AccessTokenGetResponse response = mpClient.Execute(request);
                        if (response.IsError)
                        {
                            string msg = string.Format("获取AccessToken失败。 Code:{0}，Msg:{1},APPID:{2},Token:{3}", response.ErrInfo.ErrCode, response.ErrInfo.ErrMsg, mAppId, mAppSecret);
                            LogHelper.WriteError(LogModule, msg, null);
                            if (response.ErrInfo.ErrCode == 45009)//reach max api daily quota limit
                            {
                                mAccessToken = "00000000000";
                                mAccessTokenExpiredTime = DateTime.Today.AddDays(1);
                                return mAccessToken;
                            }
                            throw new ApplicationException(msg);
                        }
                        else
                        {
                            mAccessToken = response.AccessToken.AccessToken;
                            mAccessTokenExpiredTime = timenow.AddSeconds((long)(response.AccessToken.ExpiresIn * mAccessTokenCachePeriod));
                            LogHelper.WriteDebug(LogModule, "AccessToken:{0}, ExpiredTime:{1:yyyy-MM-dd HH:mm:ss}", mAccessToken, mAccessTokenExpiredTime);
                        }
                    }
                }
            }
            return mAccessToken;
        }
        public string GetJsApiTicket()
        {
            if (string.IsNullOrEmpty(mJsApiTicket) || mJsApiTicketExpiredTime <= DateTime.Now)
            {
                JsApiTicketGetResponse response = null;

                DateTime timenow = DateTime.MinValue;
                int retry = 0;
                do
                {
                    timenow = DateTime.Now;
                    IMpClient mpClient = new MpClient();
                    JsApiTicketGetRequest request = new JsApiTicketGetRequest()
                    {
                        AppIdInfo = new AppIdInfo() { AppID = mAppId, AppSecret = mAppSecret },
                        AccessToken = this.GetAccessToken(),
                    };
                    response = mpClient.Execute(request);

                    if (!RefreshAccessToken(response, request.AccessToken))
                    {
                        break;
                    }
                    retry++;
                } while (retry < 2 && response.IsError);

                if (response.IsError)
                {
                    string msg = string.Format("获取JsApiTicket失败。 Code:{0}，Msg:{1}", response.ErrInfo.ErrCode, response.ErrInfo.ErrMsg);
                    LogHelper.WriteError(LogModule, msg, null);
                    throw new ApplicationException(msg);
                }
                else
                {
                    mJsApiTicket = response.Ticket.Ticket;
                    mJsApiTicketExpiredTime = timenow.AddSeconds(response.Ticket.ExpiresIn).AddMinutes(-10);
                }
            }
            return mJsApiTicket;
        }

        public string GetJsSignature(string noncestr, long timestamp, string url)
        {
            string ticket = this.GetJsApiTicket();
            string tmpStr = string.Format("jsapi_ticket={0}&noncestr={1}&timestamp={2}&url={3}", ticket, noncestr, timestamp, url);
            LogHelper.WriteDebug("JsSignatureRawString", tmpStr);
            var signature = FormsAuthentication.HashPasswordForStoringInConfigFile(tmpStr, "SHA1");
            LogHelper.WriteDebug("JsSignature", signature);
            return signature.ToLower();
        }

        public bool ProcessMessage(ReceiveMessageBase msg, params object[] args)
        {
            switch (msg.MsgType)
            {
                case MsgType.Text:
                    return ProcessTextMessage(msg as TextReceiveMessage, args);
                case MsgType.Image:
                    return ProcessImageMessage(msg as ImageReceiveMessage, args);
                case MsgType.Link:
                    return ProcessLinkMessage(msg as LinkReceiveMessage, args);
                case MsgType.Location:
                    return ProcessLocationMessage(msg as LocationReceiveMessage, args);
                case MsgType.Video:
                    return ProcessVideoMessage(msg as VideoReceiveMessage, args);
                case MsgType.Voice:
                    return ProcessVoiceMessage(msg as VoiceReceiveMessage, args);
                case MsgType.VoiceResult:
                    return ProcessVoiceMessage(msg as VoiceReceiveMessage, args);
                case MsgType.Event:
                    EventMessage evtMsg = msg as EventMessage;
                    switch (evtMsg.EventType)
                    {
                        case EventType.Click:
                            return ProcessMenuEvent(msg as MenuEventMessage, args);
                        case EventType.Location:
                            return ProcessUploadLocationEvent(msg as LocationReceiveMessage, args);
                        case EventType.Scan:
                            return ProcessScanEvent(msg as ScanEventMessage, args);
                        case EventType.Subscribe:
                            return ProcessSubscribeEvent(msg as SubscribeEventMessage, args);
                        case EventType.UnSubscribe:
                            return ProcessUnSubscribeEvent(msg as UnSubscribeEventMessage, args);
                        case EventType.WifiConnected:
                            return ProcessWifiConnectedEvent(msg as WifiConnectedEventMessage, args);
                        default:
                            return ProcessNotHandlerMsg(msg, args);
                    }
                default:
                    return ProcessNotHandlerMsg(msg, args);
            }
        }

        ///
        /// 处理文本消息
        ///
        ///消息对象
        ///参数（用于具体业务传递参数用）
        ///是否处理成功
        public bool ProcessTextMessage(TextReceiveMessage msg, params object[] args)
        {
            string response_msg = new Utility.SiteConfig().WechatAutoResponseMsg;
            MessageHandler.SendTextReplyMessage(msg.ToUserName, msg.FromUserName, response_msg);
            return true;
        }
        ///
        /// 处理图片消息
        ///
        /// 消息对象
        /// 参数（用于具体业务传递参数用）
        /// 是否处理成功
        public bool ProcessImageMessage(ImageReceiveMessage msg, params object[] args)
        {
            MessageHandler.SendTextReplyMessage(msg.ToUserName, msg.FromUserName, "图片上传成功");
            return true;
        }

        ///

        /// 处理语音消息
        ///

        /// 消息对象
        /// 参数（用于具体业务传递参数用）
        /// 是否处理成功
        public bool ProcessVoiceMessage(VoiceReceiveMessage msg, params object[] args)
        {
            return true;
        }

        ///

        /// 处理视频消息
        ///

        /// 消息对象
        /// 参数（用于具体业务传递参数用）
        /// 是否处理成功
        public bool ProcessVideoMessage(VideoReceiveMessage msg, params object[] args)
        {
            return true;
        }

        ///

        /// 处理地理位置消息
        ///

        /// 消息对象
        /// 参数（用于具体业务传递参数用）
        /// 是否处理成功
        public bool ProcessLocationMessage(LocationReceiveMessage msg, params object[] args)
        {
            return true;
        }

        ///

        /// 处理链接消息
        ///

        /// 消息对象
        /// 参数（用于具体业务传递参数用）
        /// 是否处理成功
        public bool ProcessLinkMessage(LinkReceiveMessage msg, params object[] args)
        {
            return true;
        }

        ///

        /// 处理关注事件
        ///

        /// 事件消息
        /// 参数（用于具体业务传递参数用）
        /// 是否处理成功
        public bool ProcessSubscribeEvent(SubscribeEventMessage msg, params object[] args)
        {
            var wechatuser = GetUserInfo(msg.FromUserName);
            LogHelper.WriteInfo("关注", JsonConvert.SerializeObject(msg));
            string QrScene = string.IsNullOrEmpty(msg.EventKey) ? "" : msg.EventKey.Replace("qrscene_", "");
            if (wechatuser != null)
            {
                string result = Post(null, new Dictionary<string, string>() { 
                        {"visit","addweixinuser"},
                        {"OpenID", wechatuser.OpenId},
                        {"City", wechatuser.City},
                        {"Country", wechatuser.Country},
                        {"NickName", wechatuser.NickName},
                        {"HeadImgUrl", wechatuser.HeadImgUrl == null ? "" : wechatuser.HeadImgUrl.Replace("\\","")},
                        {"Province", wechatuser.Province},
                        {"Language", wechatuser.Language},
                        {"Sex", wechatuser.Sex},
                        {"SubScribe", wechatuser.SubScribe},
                        {"SubscribeTime",wechatuser.SubscribeTime},
                        {"QrScene",QrScene},
                        {"Ticket",string.IsNullOrEmpty(msg.Ticket)?"":msg.Ticket},
                        {"accesstoken",GetAccessToken()},
                    });
                int sceneID = 0;
                int.TryParse(QrScene, out sceneID);
                if (sceneID > 0)
                {
                    if (!string.IsNullOrEmpty(result))
                    {
                        MessageHandler.SendTextReplyMessage(msg.ToUserName, msg.FromUserName, result);
                    }
                    else
                    {
                        MessageHandler.SendTextReplyMessage(msg.ToUserName, msg.FromUserName, "感谢您的关注,请联系工作人员查看房间关联是否成功");
                    }
                    return true;
                }
            }
            MessageHandler.SendTextReplyMessage(msg.ToUserName, msg.FromUserName, "感谢您的关注");
            return true;
        }

        ///

        /// 处理取消关注事件
        ///

        /// 事件消息
        /// 参数（用于具体业务传递参数用）
        /// 是否处理成功
        public bool ProcessUnSubscribeEvent(UnSubscribeEventMessage msg, params object[] args)
        {
            try
            {
                Post(null, new Dictionary<string, string>() { 
                        {"visit","unsubscribwexinuser"},
                        {"OpenID", msg.FromUserName},
                    });
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(LogModule, "记录访问日志失败", ex);
            }
            return true;
        }

        ///
        /// 处理连网后下发消息
        ///
        public bool ProcessWifiConnectedEvent(WifiConnectedEventMessage msg, params object[] args)
        {
            return true;
        }

        ///

        /// 处理扫描二维码事件
        ///

        /// 事件消息
        /// 参数（用于具体业务传递参数用）
        /// 是否处理成功
        public bool ProcessScanEvent(ScanEventMessage msg, params object[] args)
        {
            LogHelper.WriteInfo("扫描", JsonConvert.SerializeObject(msg));
            if (!string.IsNullOrEmpty(msg.EventKey))
            {
                int sceneID = 0;
                int.TryParse(msg.EventKey.Replace("qrscene_", ""), out sceneID);
                if (sceneID > 0)
                {
                    string result = Post(new Dictionary<string, string>() { 
                        { "visit", "qrscenescan" },
                    },
                        new Dictionary<string, string>()
                    {
                        {"OpenID",msg.FromUserName},
                        {"QrSceneID",sceneID.ToString()},
                        {"accesstoken",GetAccessToken()},
                    });
                    if (!string.IsNullOrEmpty(result))
                    {
                        MessageHandler.SendTextReplyMessage(msg.ToUserName, msg.FromUserName, result);
                    }
                    else
                    {
                        MessageHandler.SendTextReplyMessage(msg.ToUserName, msg.FromUserName, "感谢您的关注,请联系工作人员查看房间关联是否成功");
                    }
                }
            }
            return true;
        }

        ///

        /// 处理上报地理位置事件
        ///

        /// 事件消息
        /// 参数（用于具体业务传递参数用）
        /// 是否处理成功
        public bool ProcessUploadLocationEvent(LocationReceiveMessage msg, params object[] args)
        {
            //这里回应1条文本消息，当然您也可以回应其他消息
            MessageHandler.SendTextReplyMessage(msg.ToUserName, msg.FromUserName, "您的地里位置为：" + msg.Location_X + "-" + msg.Location_Y);
            return true;
        }

        ///

        /// 处理自定义菜单事件
        ///

        /// 事件消息
        /// 参数（用于具体业务传递参数用）
        /// 是否处理成功
        public bool ProcessMenuEvent(MenuEventMessage msg, params object[] args)
        {
            return true;
        }

        ///

        /// 处理未定义处理方法消息
        ///

        /// 消息对象
        /// 参数（用于具体业务传递参数用）
        /// 是否处理成功
        public bool ProcessNotHandlerMsg(ReceiveMessageBase msg, params object[] args)
        {
            LogHelper.WriteInfo("NotHandlerMsg", msg.MessageBody);
            //这里回应1条文本消息，也可以回应其他消息
            MessageHandler.SendTextReplyMessage(msg.ToUserName, msg.FromUserName, "客户正在忙-----");
            return true;
        }

        /// <summary>
        /// 获取用户基本信息
        /// </summary>


        private bool RefreshAccessToken(MpResponse res, string accesstoken)
        {
            if (res.IsError && res.ErrInfo.ErrCode == 40001)//invalid credential
            {
                LogHelper.WriteDebug(LogModule, "accesstoken expired:" + accesstoken);
                GetAccessToken(accesstoken);
                return true;
            }
            return false;
        }
        public static string Post(Dictionary<string, string> queryparameter, Dictionary<string, string> postform)
        {
            string apiurl = ConfigurationManager.AppSettings["apiurl"];
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
            request.Method = "POST";
            string postContent = string.Empty;
            if (postform != null)
            {
                postContent = string.Join("&", postform.Select(p => p.Key + "=" + p.Value).ToArray());
            }
            byte[] buffer = Encoding.UTF8.GetBytes(postContent);
            request.ContentLength = buffer.Length;
            request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";

            var reqStream = request.GetRequestStream();
            reqStream.Write(buffer, 0, buffer.Length);
            reqStream.Flush();

            var res = request.GetResponse();
            string result = null;

            using (StreamReader sr = new StreamReader(res.GetResponseStream()))
            {
                result = sr.ReadToEnd();
            }
            res.Close();
            return result;
        }
        public static string PostAsync(Dictionary<string, string> queryparameter, Dictionary<string, string> postform, Action<bool, string> onResponse)
        {
            string result = string.Empty;
            string apiurl = ConfigurationManager.AppSettings["apiurl"];
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
            request.Method = "POST";
            string postContent = string.Empty;
            if (postform != null)
            {
                postContent = string.Join("&", postform.Select(p => p.Key + "=" + p.Value).ToArray());
            }
            byte[] buffer = Encoding.UTF8.GetBytes(postContent);
            request.ContentLength = buffer.Length;
            request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
            request.BeginGetRequestStream(new AsyncCallback(ar =>
            {
                try
                {
                    var reqStream = request.EndGetRequestStream(ar);
                    reqStream.Write(buffer, 0, buffer.Length);
                    reqStream.Flush();

                    var res = request.GetResponse();
                    using (StreamReader sr = new StreamReader(res.GetResponseStream()))
                    {
                        result = sr.ReadToEnd();
                    }
                    res.Close();

                    if (onResponse != null)
                    {
                        onResponse(true, result);
                    }
                }
                catch
                {
                    if (onResponse != null)
                    {
                        onResponse(false, null);
                    }
                }
            }), null);
            return result;
        }
        public WeiXin.Domain.User GetUserInfo(string OpenID)
        {
            GetUserInfoResponse response = null;

            int retry = 0;
            do
            {
                IMpClient mpClient = new MpClient();

                GetUserInfoRequest request = new GetUserInfoRequest()
                {
                    AccessToken = this.GetAccessToken(),
                    OpenId = OpenID,
                };

                response = mpClient.Execute(request);
                if (!RefreshAccessToken(response, request.AccessToken))
                {
                    break;
                }
                retry++;
            } while (retry < 2 && response.IsError);
            if (response.IsError)
            {
                LogHelper.WriteInfo("faild", "获取OpenID:" + OpenID + "基本信息失败。获取用户基本信息失败，错误信息为：" + response.ErrInfo.ErrCode + "-" + response.ErrInfo.ErrMsg);
                return null;
            }
            else
            {
                LogHelper.WriteInfo("sucess", "获取OpenID:" + OpenID + "基本信息成功");
                return response.UserInfo;
            }
        }
    }
}
