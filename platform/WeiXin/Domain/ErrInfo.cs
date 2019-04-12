
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeiXin.Domain
{
    /// <summary>
    /// 微信公众平台接口调用返回码以及返回信息实体类
    /// </summary>
    public class ErrInfo
    {
        /// <summary>
        /// 返回码
        /// </summary>
        public long ErrCode { get; set; }

        /// <summary>
        /// 返回信息
        /// </summary>
        public string ErrMsg { get; set; }

        public override string ToString()
        {
            return string.Format("code:{0},msg:{1}", this.ErrCode, this.ErrMsg);
        }
    }
}

