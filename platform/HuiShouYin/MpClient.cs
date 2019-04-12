
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HuiShouYin.Util;
using HuiShouYin.Request;

namespace HuiShouYin
{
    /// <summary>
    /// 微信公众平台客户端
    /// </summary>
    public class MpClient : IMpClient
    {
        private WebUtils webUtils;

        /// <summary>
        /// 执行微信公众平台API请求
        /// </summary>
        /// <typeparam name="T">领域对象</typeparam>
        /// <param name="request">具体的微信公众平台请求</param>
        /// <returns>领域对象</returns>
        public T Execute<T>(IMpRequest<T> request) where T : MpResponse
        {
            request.Validate();
            string body;
            webUtils = new WebUtils();
            string url = request.GetReqUrl();
            Utility.LogHelper.WriteInfo("HuiShouYin.Request", request.SendData);
            body = webUtils.DoPost(url, request.SendData);
            Utility.LogHelper.WriteInfo("HuiShouYin.Resonse", body);
            if (WebUtils.IsNullOrWhiteSpace(body))
            {
                return null;
            }
            T response = request.ParseHtmlToResponse(body);

            return response;
        }
        public T Execute<T>(IMpRequest<T> request, out string requestdata, out string responsedata) where T : MpResponse
        {
            requestdata = string.Empty;
            responsedata = string.Empty;
            request.Validate();
            string body;
            webUtils = new WebUtils();
            string url = request.GetReqUrl();
            Utility.LogHelper.WriteInfo("HuiShouYin.Request", request.SendData);
            requestdata = request.SendData;
            body = webUtils.DoPost(url, request.SendData);
            Utility.LogHelper.WriteInfo("HuiShouYin.Resonse", body);
            responsedata = body;
            if (WebUtils.IsNullOrWhiteSpace(body))
            {
                return null;
            }
            T response = request.ParseHtmlToResponse(body);

            return response;
        }
    }
}
