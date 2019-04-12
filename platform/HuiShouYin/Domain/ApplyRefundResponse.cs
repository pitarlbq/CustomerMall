
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HuiShouYin.Domain
{
    /// <summary>
    /// 退款
    /// </summary>
    public class ApplyRefundResponse
    {
        public string return_code { get; set; }
        public string return_msg { get; set; }
        public string result_code { get; set; }
        public string sign { get; set; }
        public string app_id { get; set; }
        public string mch_uid { get; set; }
        public string channel_type { get; set; }
        public string provider_type { get; set; }
        public string out_trade_no { get; set; }
        public string hy_bill_no { get; set; }
        public string out_refund_no { get; set; }
        public string hy_refund_no { get; set; }
        public int total_fee { get; set; }
        public int real_fee { get; set; }
        public int refund_fee { get; set; }
        public int real_refund_fee { get; set; }
        public int refund_status { get; set; }
    }
}

