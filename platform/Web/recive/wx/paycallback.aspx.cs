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
    public partial class paycallback : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string return_code = string.Empty;
                string return_msg = string.Empty;
                string sign = string.Empty;
                LogHelper.WriteDebug("微信异步", "微信异步---------++++++++++++++++++");
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
                var _sign = Web.APPCode.WeixinHelper.GetSignString(paramsMap);
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
                Foresight.DataAccess.Payment.Insert_Payment(payment.Amount, payment.PaymentType, payment.TradeNo, payment.Status, payment.AddUser, payment.Remark, ResponseContent: payment.ResponseContent, payment: payment, CanSave: true, IsRoomFee: true);
                //var history_count = Foresight.DataAccess.RoomFeeHistory.GetRoomFeeHistoryCountByTradeNo(tradeno);
                //if (history_count > 0)
                //{
                //    if (payment.Status != 2)
                //    {
                //        payment.Status = 2;
                //        payment.Save();
                //    }
                //    LogHelper.WriteDebug("订单已支付", "订单已支付---------");
                //    return_code = "SUCCESS";
                //    return_msg = "订单已支付";
                //    Response.Write("<xml><return_code><![CDATA[" + return_code + "]]></return_code><return_msg><![CDATA[" + return_msg + "]]></return_msg></xml>");
                //    Response.End();
                //    return;
                //}
                var fee_count = Foresight.DataAccess.RoomFee.GetRoomFeeCountByTradeNo(tradeno);
                if (fee_count > 0)
                {
                    Web.APPCode.PaymentHelper.SaveRoomFee(tradeno, "微信公众号微信支付", "微信支付");
                }
                else
                {
                    Payment.CompletePayment(TradeNo: tradeno, payment: payment);
                }
                return_code = "SUCCESS";
                return_msg = "订单已支付";
                Response.Write("<xml><return_code><![CDATA[" + return_code + "]]></return_code><return_msg><![CDATA[" + return_msg + "]]></return_msg></xml>");
                Response.End();
                return;
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("Web.Recive.wx", "paycallback", ex);
                Response.Write("<xml><return_code><![CDATA[FAIL]]></return_code><return_msg><![CDATA[FAIL]]></return_msg></xml>");
                Response.End();
                return;
            }
        }
    }
}