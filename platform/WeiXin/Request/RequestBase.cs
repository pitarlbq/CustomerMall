
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeiXin.Domain;

namespace WeiXin.Request
{
    /// <summary>
    /// 请求基类
    /// </summary>
    public abstract class RequestBase<T> where T : MpResponse
    {
        /* 测试账号申请地址
         *  http://mp.weixin.qq.com/debug/cgi-bin/sandbox?t=sandbox/login
        */

        /// <summary>
        /// 获取默认AppInfo信息
        /// </summary>
        /// <returns></returns>
        protected AppIdInfo GetDefaultAppIdInfo()
        {
            AppIdInfo info = new AppIdInfo()
            {
                AppID = "1",
                AppSecret = "2",
                CallBack = "3"
            };
            return info;
        }
    }
}
