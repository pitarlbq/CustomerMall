
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
    /// 发送客服信息请求
    /// </summary>
    public class CustomerServiceCreateAccountRequest : RequestBase<CustomerServiceCreateAccountResponse>, IMpRequest<CustomerServiceCreateAccountResponse>
    {
        public string Method
        {
            get
            {
                return "POST";
            }
        }
        /// <summary>
        /// 调用接口凭证 
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// AppId信息
        /// </summary>
        public AppIdInfo AppIdInfo
        {
            get;
            set;
        }

        /// <summary>
        /// 需要POST发送的数据
        /// </summary>
        public string SendData { get; set; }


        /// <summary>
        /// 获取Api请求地址
        /// </summary>
        /// <returns></returns>
        public string GetReqUrl()
        {
            string urlFormat = "https://api.weixin.qq.com/customservice/kfaccount/add?access_token={0}";
            string url = string.Format(urlFormat, AccessToken);
            return url;
        }

        public IDictionary<string, string> GetParameters()
        {
            return new Dictionary<string, string>();
        }

        public void Validate()
        {

        }

        public CustomerServiceCreateAccountResponse ParseHtmlToResponse(string body)
        {
            CustomerServiceCreateAccountResponse response = new CustomerServiceCreateAccountResponse();
            response.Body = body;

            if (response.HasError())
            {
                response.ErrInfo = response.GetErrInfo();
            }
            else
            {
             
            }
            return response;
        }
    }
}

