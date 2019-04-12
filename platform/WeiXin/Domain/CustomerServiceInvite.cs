
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeiXin.Domain
{
    /// <summary>
    /// 发送客服信息基类
    /// </summary>
    public class CustomerServiceInvite
    {
        /// <summary>
        /// 完整客服帐号，格式为：帐号前缀@公众号微信号 
        /// </summary>
        public string kf_account { get; set; }

        /// <summary>
        /// 接收绑定邀请的客服微信号
        /// </summary>
        public string invite_wx { get; set; }

        /// <summary>
        /// 调用接口凭证
        /// </summary>
        public string AccessToken { get; set; }
        public string ToJsonString()
        {
            return "{\"kf_account\":\"" + kf_account + "\",\"invite_wx\":\"" + invite_wx + "\"}";
        }
    }
}
