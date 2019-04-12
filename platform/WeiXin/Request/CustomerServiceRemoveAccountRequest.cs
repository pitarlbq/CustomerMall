
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
    public class CustomerServiceRemoveAccountRequest : RequestBase<CustomerServiceRemoveAccountResponse>, IMpRequest<CustomerServiceRemoveAccountResponse>
    {
        public string Method
        {
            get
            {
                return "GET";
            }
        }
        /// <summary>
        /// 调用接口凭证 
        /// </summary>
        public string AccessToken { get; set; }
        public string kf_account { get; set; }

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
            string urlFormat = "https://api.weixin.qq.com/customservice/kfaccount/del?access_token={0}&kf_account={1}";
            string url = string.Format(urlFormat, AccessToken, kf_account);
            return url;
        }

        public IDictionary<string, string> GetParameters()
        {
            return new Dictionary<string, string>();
        }

        public void Validate()
        {

        }

        public CustomerServiceRemoveAccountResponse ParseHtmlToResponse(string body)
        {
            CustomerServiceRemoveAccountResponse response = new CustomerServiceRemoveAccountResponse();
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

