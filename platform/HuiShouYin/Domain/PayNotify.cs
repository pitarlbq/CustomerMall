
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HuiShouYin.Domain
{
    /// <summary>
    /// 统一下单
    /// </summary>
    public class PayNotify
    {
        public string version { get; set; }
        public string app_id { get; set; }
        public string mch_uid { get; set; }
        public string subject { get; set; }
        public string out_trade_no { get; set; }
        public string hy_bill_no { get; set; }
        public string channel_trade_no { get; set; }
        public string channel_type { get; set; }
        public string total_fee { get; set; }
        public string real_fee { get; set; }
        public string trade_status { get; set; }
        public string bank_type { get; set; }
        public string time_end { get; set; }
        public string pay_option { get; set; }
        public string sign { get; set; }
    }
    public class Pay_Option
    {
        public List<OptionList> idlist { get; set; }
        public string openid { get; set; }
    }
    public class OptionList
    {
        public int ID { get; set; }
        public string EndTime { get; set; }
    }
}

