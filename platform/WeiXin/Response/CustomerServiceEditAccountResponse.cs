
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeiXin.Response
{
    /// <summary>
    /// 发送客户信息回应信息
    /// </summary>
    public class CustomerServiceEditAccountResponse : MpResponse
    {
        public long ErrorCode
        {
            get
            {
                return Convert.ToInt64(WeiXin.Util.Tools.GetJosnValue(Body, "errcode"));
            }
        }
        public string ErrorMsg
        {
            get
            {
                return WeiXin.Util.Tools.GetCustomerServiceErrorMsg(this.ErrorCode);
            }
        }
    }
}
