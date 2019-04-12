
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeiXin.Domain
{
    /// <summary>
    /// access_token实体类
    /// </summary>
    public class JsApiTicketInfo
    {
        /// <summary>
        /// ticket
        /// </summary>
        public string Ticket { get; set; }

        /// <summary>
        /// 凭证有效时间，单位：秒 
        /// </summary>
        public long ExpiresIn { get; set; }
    }
}

