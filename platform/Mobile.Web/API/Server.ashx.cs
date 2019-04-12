using Mobile.Web.AppCode;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using Utility;
using WeiXin;

namespace Mobile.Web.API
{
    /// <summary>
    /// Server 的摘要说明
    /// </summary>
    public class Server : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            try
            {
                var config = new WechatConfig();
                string token = config.Token;
                if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["echostr"]))
                {
                    LogHelper.WriteDebug("validate", context.Request.RawUrl);
                    MessageHandler.Valid(token);
                }
                else
                {
                    var recMsg = MessageHandler.ConvertMsgToObject(token);  //将消息转换成对象
                    if (recMsg != null)
                    {
                        MessageProcessor msgProcessor = MessageProcessor.Instance;  //处理消息，继承接口IMessageProcessor来处理接受到的消息

                        msgProcessor.ProcessMessage(recMsg); //处理消息
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("API.Server", "Process Request Error", ex);
                context.Response.Write("非法操作");
            }
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