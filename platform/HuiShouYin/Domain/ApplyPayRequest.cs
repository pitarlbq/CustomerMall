
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
    public class ApplyPayRequest
    {
        public ApplyPayRequest(ApplyPay_BizContent _biz_content)
        {
            var config = new Utility.SiteConfig();
            this.api_from_type = "Out_Api";
            this.method = "heemoney.pay.applypay";
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
        private string GetSign(ApplyPay_BizContent _biz_content, string key)
        {
            string sign = "api_from_type={0}&app_id={1}&biz_content={{\"out_trade_no\":\"{2}\",\"subject\":\"{3}\",\"total_fee\":\"{4}\",\"client_ip\":\"{5}\",\"notify_url\":\"{6}\",\"return_url\":\"{7}\",\"channel_type\":\"{8}\",\"pay_option\":\"{16}\"}}&charset={9}&mch_uid={10}&method={11}&sign_type={12}&timestamp={13}&version={14}&key={15}";
            string signstr = string.Format(sign, this.api_from_type, this.app_id, _biz_content.out_trade_no, _biz_content.subject, _biz_content.total_fee, _biz_content.client_ip, _biz_content.notify_url, _biz_content.return_url, _biz_content.channel_type, this.charset, this.mch_uid, this.method, this.sign_type, this.timestamp, this.version, key, _biz_content.pay_option);
            string MD5Str = Util.Tools.MD5Encrypt(signstr);
            return MD5Str;
        }

        private string GetBIZ(ApplyPay_BizContent _biz_content)
        {
            string biz = "{{\"out_trade_no\":\"{0}\",\"subject\":\"{1}\",\"total_fee\":\"{2}\",\"client_ip\":\"{3}\",\"notify_url\":\"{4}\",\"return_url\":\"{5}\",\"channel_type\":\"{6}\",\"pay_option\":\"{7}\"}}";
            string bizstr = string.Format(biz, _biz_content.out_trade_no, _biz_content.subject, _biz_content.total_fee, _biz_content.client_ip, _biz_content.notify_url, _biz_content.return_url, _biz_content.channel_type, _biz_content.pay_option);
            return bizstr;
        }
    }
    public class ApplyPay_BizContent
    {
        public string out_trade_no { get; set; }
        public string subject { get; set; }
        public string total_fee { get; set; }
        public string client_ip { get; set; }
        public string channel_type { get; set; }
        public string notify_url { get; set; }
        public string return_url { get; set; }
        public string pay_option { get; set; }
    }

}

