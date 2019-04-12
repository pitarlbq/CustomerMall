﻿
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
    /// 获取用户基本信心请求
    /// </summary>
    public class GetUserInfoRequest : RequestBase<GetUserInfoResponse>, IMpRequest<GetUserInfoResponse>
    {
        public string Method
        {
            get
            {
                return "GET";
            }
        }

        /// <summary>
        /// 普通用户的标识，对当前公众号唯一
        /// </summary>
        public string OpenId { get; set; }

        /// <summary>
        /// 需要POST发送的数据
        /// </summary>
        public string SendData { get; set; }

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
        /// 获取Api请求地址
        /// </summary>
        /// <returns></returns>
        public string GetReqUrl()
        {
            string urlFormat = "https://api.weixin.qq.com/cgi-bin/user/info?access_token={0}&openid={1}&lang=zh_CN";
            string url = string.Format(urlFormat, AccessToken, OpenId);
            return url;
        }

        public IDictionary<string, string> GetParameters()
        {
            return new Dictionary<string, string>();
        }

        public void Validate()
        {

        }

        public GetUserInfoResponse ParseHtmlToResponse(string body)
        {
            GetUserInfoResponse response = new GetUserInfoResponse();
            response.Body = body;

            if (response.HasError())
            {
                response.ErrInfo = response.GetErrInfo();
            }
            else
            {
                User userInfo = new User()
                {
                    SubScribe = Tools.GetJosnValue(body, "subscribe"),
                    OpenId = Tools.GetJosnValue(body, "openid"),
                    NickName = Tools.GetJosnValue(body, "nickname"),
                    Sex = Tools.GetJosnValue(body, "sex"),
                    Language = Tools.GetJosnValue(body, "language"),
                    City = Tools.GetJosnValue(body, "city"),
                    Province = Tools.GetJosnValue(body, "province"),
                    Country = Tools.GetJosnValue(body, "country"),
                    HeadImgUrl = Tools.GetJosnValue(body, "headimgurl"),
                    SubscribeTime = Tools.GetJosnValue(body, "subscribe_time")
                };
                if (!string.IsNullOrEmpty(userInfo.SubscribeTime))
                {
                    userInfo.SubscribeTime = (long.Parse(userInfo.SubscribeTime) + 8 * 3600).ToString();//+08:00:00
                }

                response.UserInfo = userInfo;
            }
            return response;
        }


    } // class end
}

