using PaymentConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// config 的摘要说明
/// </summary>
public class AlipayConfig
{
    public AlipayConfig()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }
    // 应用ID,您的APPID
    public static string mobile_app_id = AlipayParamConfig.AlipayAPPID;//"2018022402264625";
    public static string mobile_seller_id = AlipayParamConfig.AlipaySellerID;//"2088921709195685";
    public static string mobile_product_code = AlipayParamConfig.MobileProductCode;
    public static string mobile_notify_url = AlipayParamConfig.MobileNotifyUrl;
    public static string mobile_notify_url_chongzhi = AlipayParamConfig.MobileNotifyUrl_ChongZhi;
    //public static string mobile_private_key = AlipayParamConfig.MobilePrivateKey;
    //public static string mobile_public_key = AlipayParamConfig.MobilePublicKey;
    public static string mobile_public_key_value = AlipayParamConfig.MobilePublicKeyValue;
    public static string mobile_private_key_value = AlipayParamConfig.MobilePrivateKeyValue;
    public static string mobile_gatewayUrl = AlipayParamConfig.mobile_gatewayUrl;
    // 签名方式
    public static string sign_type = AlipayParamConfig.sign_type;

    // 编码格式
    public static string charset = AlipayParamConfig.charset;

    //该笔订单允许的最晚付款时间，逾期将关闭交易
    public static string timeout_express = AlipayParamConfig.timeout_express;

    //销售产品码，商家和支付宝签约的产品码。该产品请填写固定值：QUICK_WAP_WAY
    public static string wap_product_code = AlipayParamConfig.wap_product_code;

    //支付宝服务器主动通知商户服务器里指定的页面http/https路径。
    public static string notify_url = AlipayParamConfig.NotifyUrl;

    //调用的接口版本，固定为：1.0
    public static string version = AlipayParamConfig.version;

    //支付宝服务器主动通知商户服务器里指定的页面http/https路径。
    public static string wx_return_url = AlipayParamConfig.wx_return_url;
    public static string wap_return_url = AlipayParamConfig.wap_return_url;
}