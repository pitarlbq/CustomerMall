
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeiXin.Util;

namespace WeiXin.Response
{
    /// <summary>
    /// 发送客户信息回应信息
    /// </summary>
    public class CustomerServiceCreateResponse : MpResponse
    {
        public long ErrorCode
        {
            get
            {
                return Convert.ToInt64(Tools.GetJosnValue(Body, "errcode"));
            }
        }
        public string ErrorMsg
        {
            get
            {
                return Tools.GetCustomerServiceErrorMsg(this.ErrorCode);
            }
        }
    }
}
