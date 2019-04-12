
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeiXin.Response;
using WeiXin.Domain;
using WeiXin.Util;

namespace WeiXin.Request
{
    /// <summary>
    /// 获取access_token请求
    /// </summary>
    public class JsApiTicketGetRequest : RequestBase<JsApiTicketGetResponse>, IMpRequest<JsApiTicketGetResponse>
    {

        public string Method
        {
            get
            {
                return "GET";
            }
        }


        /// <summary>
        /// AppId信息
        /// </summary>
        public AppIdInfo AppIdInfo
        {
            get;
            set;
        }

        /// <summary>
        /// 调用接口凭证 
        /// </summary>
        public string AccessToken { get; set; }

        /// 需要POST发送的数据
        /// </summary>
        public string SendData { get; set; }

        /// <summary>
        /// 获取Api请求地址
        /// </summary>
        /// <returns></returns>
        public string GetReqUrl()
        {
            string urlFormat = "https://api.weixin.qq.com/cgi-bin/ticket/getticket?access_token={0}&type=jsapi";
            string url = string.Format(urlFormat, this.AccessToken);
            return url;
        }

        public IDictionary<string, string> GetParameters()
        {
            return null;
        }

        public void Validate()
        {

        }

        /// <summary>
        /// 将平台返回的HTML转化成MpResponse对象
        /// </summary>
        /// <param name="body">返回的HTML</param>
        /// <returns></returns>
        public JsApiTicketGetResponse ParseHtmlToResponse(string body)
        {
            JsApiTicketGetResponse response = new JsApiTicketGetResponse();
            response.Body = body;

            if (response.HasError())
            {
                response.ErrInfo = response.GetErrInfo();
            }
            else
            {
                JsApiTicketInfo ticket = new JsApiTicketInfo()
                {
                    Ticket = Tools.GetJosnValue(body, "ticket"),
                    ExpiresIn = Convert.ToInt64(Tools.GetJosnValue(body, "expires_in"))
                };
                response.Ticket = ticket;
            }
            return response;
        }

    } // class end
}
