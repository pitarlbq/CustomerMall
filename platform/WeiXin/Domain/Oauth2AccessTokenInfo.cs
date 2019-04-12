using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeiXin.Domain
{
    public class Oauth2AccessTokenInfo
    {
        /// <summary>
        /// access_token
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// 凭证有效时间，单位：秒 
        /// </summary>
        public long ExpiresIn { get; set; }

        /// <summary>
        /// 用户刷新access_token
        /// </summary>
        public string RefreshToken { get; set; }

        /// <summary>
        /// openid
        /// </summary>
        public string OpenID { get; set; }

        /// <summary>
        /// 用户授权的作用域，使用逗号（,）分隔。
        /// </summary>
        public string Scope { get; set; }

        /// <summary>
        /// 只有在用户将公众号绑定到微信开放平台帐号后，才会出现该字段。
        /// </summary>
        public string UnionID { get; set; }
        public string UserId { get; set; }
        public string DeviceId { get; set; }
    }
}
