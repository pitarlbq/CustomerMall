using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HuiShouYin.Domain;
using HuiShouYin.Util;

namespace HuiShouYin
{

    [Serializable]
    public abstract class MpResponse
    {

        /// <summary>
        /// 错误信息
        /// </summary>
        public ErrInfo ErrInfo { get; set; }

        /// <summary>
        /// 响应原始内容
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// 请求Url
        /// </summary>
        public string ReqUrl { get; set; }

        /// <summary>
        /// 响应结果是否错误
        /// </summary>
        public bool IsError
        {
            get
            {
                if (ErrInfo == null)
                {
                    return false;
                }
                return true;
            }
        }

        /// <summary>
        /// 判断是否返回了错误信息
        /// </summary>
        /// <returns></returns>
        internal bool HasError()
        {
            if (WebUtils.IsNullOrWhiteSpace(Body))
            {
                return false;
            }
            string html = Body.Trim().ToLower();

            if (html.StartsWith("{\"errcode\"", StringComparison.InvariantCultureIgnoreCase))
            {
                if (Convert.ToInt64(Tools.GetJosnValue(Body, "errcode")) == 0)
                {
                    return false;
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// 获取错误代码和错误信息
        /// </summary>
        /// <returns></returns>
        internal ErrInfo GetErrInfo()
        {
            HuiShouYin.Domain.ErrInfo err = new ErrInfo()
            {
                error_code = Tools.GetJosnValue(Body, "error_code"),
                error_msg = Tools.GetJosnValue(Body, "error_msg")
            };
            return err;
        }
    }
}

