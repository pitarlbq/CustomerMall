using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mobile.Web.AppCode
{
    public enum ErrorCode
    {
        /// <summary>
        /// 成功
        /// </summary>
        Succeed = 0,
        /// <summary>
        /// 服务器错误
        /// </summary>
        ServerError = -1,
        /// <summary>
        /// 错误的请求
        /// </summary>
        InvalideRequest = -2,
        /// <summary>
        /// 错误的OpenID
        /// </summary>
        InvalideOpenID = -3
    }
}