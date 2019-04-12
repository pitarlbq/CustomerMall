using WeiXin.Domain;
using WeiXin.Response;
using WeiXin.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeiXin.Request
{
    public class Oauth2AccessTokenGetRequest : RequestBase<Oauth2AccessTokenGetResponse>, IMpRequest<Oauth2AccessTokenGetResponse>
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
        /// Code
        /// </summary>
        public string Code { get; set; }

        /// 需要POST发送的数据
        /// </summary>
        public string SendData { get; set; }

        /// <summary>
        /// 获取Api请求地址
        /// </summary>
        /// <returns></returns>
        public string GetReqUrl()
        {
            string urlFormat = "https://api.weixin.qq.com/sns/oauth2/access_token?appid={0}&secret={1}&code={2}&grant_type=authorization_code";
            AppIdInfo info = AppIdInfo == null ? GetDefaultAppIdInfo() : AppIdInfo;
            string url = string.Format(urlFormat, info.AppID, info.AppSecret, this.Code);
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
        public Oauth2AccessTokenGetResponse ParseHtmlToResponse(string body)
        {
            Oauth2AccessTokenGetResponse response = new Oauth2AccessTokenGetResponse();
            response.Body = body;

            if (response.HasError())
            {
                response.ErrInfo = response.GetErrInfo();
            }
            else
            {
                Oauth2AccessTokenInfo token = new Oauth2AccessTokenInfo()
                {
                    AccessToken = Tools.GetJosnValue(body, "access_token"),
                    ExpiresIn = Convert.ToInt64(Tools.GetJosnValue(body, "expires_in")),
                    RefreshToken = Tools.GetJosnValue(body, "refresh_token"),
                    OpenID = Tools.GetJosnValue(body, "openid"),
                    Scope = Tools.GetJosnValue(body, "scope"),
                    UnionID = Tools.GetJosnValue(body, "unionid"),
                };
                response.AccessToken = token;
            }
            return response;
        }
    }
}
