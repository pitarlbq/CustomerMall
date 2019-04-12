using Mobile.Web.AppCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Utility;
using WeiXin;

namespace Mobile.Web.API
{
    /// <summary>
    /// API 的摘要说明
    /// </summary>
    public class API : IHttpHandler
    {
        const string LogModule = "MobileAPI";
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string action = context.Request["action"];
            if (string.IsNullOrEmpty(action))
            {
                WebUtil.WriteJsonResult(context, null);
                LogHelper.WriteInfo(LogModule, "action 为空: action=" + action);
                return;
            }
            try
            {
                switch (action.ToLower())
                {
                    case "getaccesstoken":
                        GetAccessToken(context);
                        break;
                    case "getjsticket":
                        getjsticket(context);
                        break;
                    case "getopenid":
                        GetOpenID(context);
                        break;
                    case "getjssignature":
                        GetJsSignature(context);
                        break;
                    case "clearwechatconfigcache":
                        clearwechatconfigcache(context);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                WebUtil.WriteJsonError(context, ErrorCode.ServerError, ex.Message);
                LogHelper.WriteError(LogModule, "Process Error: action=" + action, ex);
            }
        }
        private void clearwechatconfigcache(HttpContext context)
        {
            var config = new WechatConfig();
            config.ClearCache();
            WebUtil.WriteJson(context, new { status = true });
        }
        private void getjsticket(HttpContext context)
        {
            string jsticket = jsticket = MessageProcessor.Instance.GetJsApiTicket();
            WebUtil.WriteJson(context, jsticket);
        }
        private void GetJsSignature(HttpContext context)
        {
            string noncestr = context.Request.QueryString["noncestr"];
            long timestamp = Convert.ToInt64(context.Request.QueryString["timestamp"]);
            string url = context.Request.QueryString["url"];

            WebUtil.WriteJson(context, MessageProcessor.Instance.GetJsSignature(noncestr, timestamp, url));
        }
        private void GetOpenID(HttpContext context)
        {
            string code = context.Request.QueryString["code"];

            IMpClient client = new MpClient();
            var request = new WeiXin.Request.Oauth2AccessTokenGetRequest()
            {
                AppIdInfo = new WeiXin.Domain.AppIdInfo()
                {
                    AppID = MessageProcessor.Instance.mAppId,
                    AppSecret = MessageProcessor.Instance.mAppSecret
                },
                Code = code,
            };
            var response = client.Execute(request);
            if (!response.IsError)
            {
                string openId = response.AccessToken.OpenID;
                LogHelper.WriteDebug(LogModule, "获取OpenID(" + code + ")成功：" + openId);
                WebUtil.WriteJson(context, openId);
                return;
            }
            else
            {
                LogHelper.WriteError(LogModule, "获取OpenID(" + code + ")失败：" + response.ErrInfo.ToString(), null);
            }
            WebUtil.WriteJson(context, null);
        }
        private void GetAccessToken(HttpContext context)
        {
            string accesstoken = string.Empty;
            if (!string.IsNullOrEmpty(context.Request["oldaccesstoken"]))
            {
                accesstoken = MessageProcessor.Instance.GetAccessToken(context.Request["oldaccesstoken"]);
            }
            else
            {
                accesstoken = MessageProcessor.Instance.GetAccessToken();
            }
            WebUtil.WriteJson(context, accesstoken);
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}