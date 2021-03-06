﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeiXin.Domain
{
    /// <summary>
    /// 发送客服信息基类
    /// </summary>
    public class CustomerServiceAccount
    {
        /// <summary>
        /// 完整客服帐号，格式为：帐号前缀@公众号微信号 
        /// </summary>
        public string kf_account { get; set; }

        /// <summary>
        /// 客服昵称，最长16个字
        /// </summary>
        public string nickname { get; set; }

        /// <summary>
        /// 调用接口凭证
        /// </summary>
        public string AccessToken { get; set; }
        public string ToJsonString()
        {
            return "{\"kf_account\":\"" + kf_account + "\",\"nickname\":\"" + nickname + "\"}";
        }
    }
}
