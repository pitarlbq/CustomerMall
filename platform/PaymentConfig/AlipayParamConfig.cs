using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;
using System.Xml;
using Utility;

namespace PaymentConfig
{
    public class AlipayParamConfig
    {
        public static string AlipayAPPID = ConfigurationManager.AppSettings["AlipayAPPID"];

        public static string AlipaySellerID = ConfigurationManager.AppSettings["AlipaySellerID"];

        public static string MobileProductCode = "QUICK_MSECURITY_PAY";

        public static string MobileNotifyUrl = Utility.Tools.GetContextPath() + "/recive/alipay/paycallbackapp.aspx";

        public static string MobileNotifyUrl_ChongZhi = Utility.Tools.GetContextPath() + "/recive/alipay/paycallbackappchongzhi.aspx";

        public static string NotifyUrl = Utility.Tools.GetContextPath() + "/recive/alipay/paycallback.aspx";

        public static string wx_return_url = Utility.Tools.GetContextPath() + "/html/newweixin/service/alipay_return.html";

        public static string wap_return_url = Utility.Tools.GetContextPath() + "/html/webapp/html/ordercomplete_frm.html";

        public static string MobilePrivateKey = System.Web.Hosting.HostingEnvironment.MapPath("~/html/alipay/aop-RSA-private_mobile_app.pem.txt");

        public static string MobilePublicKey = System.Web.Hosting.HostingEnvironment.MapPath("~/html/alipay/aop-RSA-public_mobile_app.pem.txt");

        public static string MobilePublicKeyValue = ConfigurationManager.AppSettings["Alipay_MobilePublicKeyValue"];

        public static string MobilePrivateKeyValue = ConfigurationManager.AppSettings["Alipay_MobilePrivateKeyValue"];

        public static string mobile_gatewayUrl = "https://openapi.alipay.com/gateway.do";

        public static string sign_type = "RSA2";

        public static string charset = "utf-8";

        public static string timeout_express = "30m";

        public static string wap_product_code = "QUICK_WAP_PAY";

        public static string version = "1.0";
    }
}
