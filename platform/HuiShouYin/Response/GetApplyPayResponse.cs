
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HuiShouYin.Domain;

namespace HuiShouYin.Response
{
    /// <summary>
    /// 获取关注者列表请求回应信息
    /// </summary>
    public class GetApplyPayResponse : MpResponse 
    {
        public ApplyPayResponse ApplyPay { get; set; }
    }
}
