
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HuiShouYin.Domain
{
    /// <summary>
    /// 统一下单
    /// </summary>
    public class ApplyPayResponse
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
        public string hy_pay_id { get; set; }
        public string subject { get; set; }
        public int total_fee { get; set; }
        public string code_url { get; set; }
        public string hy_pay_url { get; set; }
        public string hy_js_auth_pay_url { get; set; }
    }
}

