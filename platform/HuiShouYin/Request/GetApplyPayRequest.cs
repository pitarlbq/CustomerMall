
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HuiShouYin.Response;
using HuiShouYin.Domain;
using HuiShouYin.Util;
using Utility;

namespace HuiShouYin.Request
{
    /// <summary>
    /// 获取access_token请求
    /// </summary>
    public class GetApplyPayRequest : RequestBase<GetApplyPayResponse>, IMpRequest<GetApplyPayResponse>
    {

        public string Method
        {
            get
            {
                return "POST";
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

        /// 需要POST发送的数据
        /// </summary>
        public string SendData { get; set; }

        /// <summary>
        /// 获取Api请求地址
        /// </summary>
        /// <returns></returns>
        public string GetReqUrl()
        {
            string url = "https://pay.heemoney.com/v1/ApplyPay";
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
        public GetApplyPayResponse ParseHtmlToResponse(string body)
        {
            GetApplyPayResponse response = new GetApplyPayResponse();
            response.Body = body;

            if (response.HasError())
            {
                response.ErrInfo = response.GetErrInfo();
            }
            else
            {
                ApplyPayResponse mg = JsonConvert.DeserializeObject<ApplyPayResponse>(response.Body);
                response.ApplyPay = mg;
            }
            return response;
        }
    } // class end
}
