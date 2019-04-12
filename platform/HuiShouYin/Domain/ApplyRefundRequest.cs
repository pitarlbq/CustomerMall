
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using HuiShouYin.Util;
namespace HuiShouYin.Domain
{
    /// <summary>
    /// 统一下单
    /// </summary>
    public class ApplyRefundRequest
    {
        public ApplyRefundRequest(ApplyRefund_BizContent _biz_content)
        {
            var config = new Utility.SiteConfig();
            this.api_from_type = "Out_Api";
            this.method = "heemoney.pay.refund";
            this.version = "1.0";
            this.app_id = config.HuiShouYin_APPID;
            this.mch_uid = config.HuiShouYin_MCHUID;
            this.charset = "utf-8";
            this.sign_type = "MD5";
            this.timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
            this.biz_content = GetBIZ(_biz_content);
            this.sign = GetSign(_biz_content, config.HuiShouYin_KEY);
        }
        public string api_from_type { get; set; }
        public string method { get; set; }
        public string version { get; set; }
        public string app_id { get; set; }
        public string mch_uid { get; set; }
        public string charset { get; set; }
        public string sign_type { get; set; }
        public string sign { get; set; }
        public string timestamp { get; set; }
        public string biz_content { get; set; }
        private string GetSign(ApplyRefund_BizContent _biz_content, string key)
        {
            string sign = "api_from_type={0}&app_id={1}&biz_content={{\"out_trade_no\":\"{2}\",\"out_refund_no\":\"{3}\",\"total_fee\":\"{4}\",\"refund_fee\":\"{5}\"}}&charset={6}&mch_uid={7}&method={8}&sign_type={9}&timestamp={10}&version={11}&key={12}";
            string signstr = string.Format(sign, this.api_from_type, this.app_id, _biz_content.out_trade_no, _biz_content.out_refund_no, _biz_content.total_fee, _biz_content.refund_fee, this.charset, this.mch_uid, this.method, this.sign_type, this.timestamp, this.version, key);
            string MD5Str = Util.Tools.MD5Encrypt(signstr);
            return MD5Str;
        }

        private string GetBIZ(ApplyRefund_BizContent _biz_content)
        {
            string biz = "{{\"out_trade_no\":\"{0}\",\"out_refund_no\":\"{1}\",\"total_fee\":\"{2}\",\"refund_fee\":\"{3}\"}}";
            string bizstr = string.Format(biz, _biz_content.out_trade_no, _biz_content.out_refund_no, _biz_content.total_fee, _biz_content.refund_fee);
            return bizstr;
        }
    }
    public class ApplyRefund_BizContent
    {
        public string out_trade_no { get; set; }
        public string out_refund_no { get; set; }
        public int total_fee { get; set; }
        public int refund_fee { get; set; }
    }
}

