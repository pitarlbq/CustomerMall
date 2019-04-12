
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HuiShouYin.Domain;

namespace HuiShouYin.Request
{
    /// <summary>
    /// 请求基类
    /// </summary>
    public abstract class RequestBase<T> where T : MpResponse
    {

        /// <summary>
        /// 获取默认AppInfo信息
        /// </summary>
        /// <returns></returns>
        protected AppIdInfo GetDefaultAppIdInfo()
        {
            AppIdInfo info = new AppIdInfo()
            {
                AppID = "1",
                MchUID = "2",
            };
            return info;
        }
    }
}
