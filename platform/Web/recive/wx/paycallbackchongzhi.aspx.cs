using Foresight.DataAccess;
using Foresight.DataAccess.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using Utility;

namespace Web.Recive.wx
{
    public partial class paycallbackchongzhi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string return_code = string.Empty;
                string return_msg = string.Empty;
                string sign = string.Empty;
                LogHelper.WriteDebug("APP微信异步充值", "APP微信异步---------++++++++++++++++++");
                var form = HttpContext.Current.Request;
                var xml = new XmlDocument();
                Stream stream = form.InputStream;   //获取响应的字符串流
                StreamReader sr = new StreamReader(stream); //创建一个stream读取流
                string html = sr.ReadToEnd();   //从头读到尾，放到字符串html
                xml.LoadXml(html);
                //对请求返回值 进行处理
                var root = xml.DocumentElement;
                Dictionary<string, string> paramsMap = new Dictionary<string, string>();
                foreach (XmlNode node in root.ChildNodes)
                {
                    LogHelper.WriteDebug(node.Name + ":", node.InnerText);
                    if (node.Name != "sign")
                    {
                        paramsMap.Add(node.Name, node.InnerText);
                    }
                    else
                    {
                        sign = node.InnerText;
                    }
                }
                var _sign = Web.APPCode.WeixinHelper.GetAPPSignString(paramsMap);
                if (_sign != sign)///签名验证成功
                {
                    LogHelper.WriteDebug("签名验证失败", sign + "---------" + _sign);
                    return_code = "FAIL";
                    return_msg = "签名验证失败";
                    Response.Write("<xml><return_code><![CDATA[" + return_code + "]]></return_code><return_msg><![CDATA[" + return_msg + "]]></return_msg></xml>");
                    Response.End();
                    return;
                }
                string tradeno = paramsMap["out_trade_no"].ToString();
                var payment = Foresight.DataAccess.Payment.GetPaymentByTradeNo(tradeno);
                if (payment == null)
                {
                    return_code = "SUCCESS";
                    return_msg = "payment不存在";
                    Response.Write("<xml><return_code><![CDATA[" + return_code + "]]></return_code><return_msg><![CDATA[" + return_msg + "]]></return_msg></xml>");
                    Response.End();
                    return;
                }
                if (payment != null && payment.Status != 1)
                {
                    return_code = "SUCCESS";
                    return_msg = "payment状态不为1";
                    Response.Write("<xml><return_code><![CDATA[" + return_code + "]]></return_code><return_msg><![CDATA[" + return_msg + "]]></return_msg></xml>");
                    Response.End();
                    return;
                }
                Payment.CompletePayment(TradeNo: tradeno, payment: payment);
                Foresight.DataAccess.Mall_UserBalance.UpdateMall_UserBalanceStatus(1, payment.TradeNo, payment: payment, PaymentMethod: Utility.EnumModel.Mall_OrderPaymentMethodDefine.wxpay.ToString());
                return_code = "SUCCESS";
                return_msg = "订单已支付";
                Response.Write("<xml><return_code><![CDATA[" + return_code + "]]></return_code><return_msg><![CDATA[" + return_msg + "]]></return_msg></xml>");
                Response.End();
                return;
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("Web.Recive.wx", "paycallbackchongzhi", ex);
                Response.Write("<xml><return_code><![CDATA[FAIL]]></return_code><return_msg><![CDATA[FAIL]]></return_msg></xml>");
                Response.End();
                return;
            }
        }
    }
}