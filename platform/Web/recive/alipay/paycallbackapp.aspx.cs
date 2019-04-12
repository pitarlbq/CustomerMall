using Aop.Api.Util;
using Foresight.DataAccess;
using Foresight.DataAccess.Framework;

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using Utility;

namespace Web.Recive.alipay
{
    public partial class paycallbackapp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                LogHelper.WriteDebug("支付宝APP订单支付异步", "支付宝APP异步---------++++++++++++++++++");
                IDictionary<string, string> paramsMap = new Dictionary<string, string>();
                NameValueCollection coll;
                coll = Request.Form;
                String[] requestItem = coll.AllKeys;
                for (int i = 0; i < requestItem.Length; i++)
                {
                    paramsMap.Add(requestItem[i], coll[requestItem[i]]);
                }
                LogHelper.WriteInfo("paramsMap", JsonConvert.SerializeObject(paramsMap));
                string publicKey = AlipayConfig.mobile_public_key_value;
                bool checkSign = AlipaySignature.RSACheckV1(paramsMap, publicKey, AlipayConfig.charset, AlipayConfig.sign_type, false);
                if (!checkSign)
                {
                    LogHelper.WriteDebug("验签失败", "验签失败---------");
                    Response.Write("failure");
                    Response.End();
                    return;
                }
                string trade_status = paramsMap["trade_status"].ToString();
                if (!trade_status.ToLower().Equals("trade_success"))
                {
                    Response.Write("failure");
                    Response.End();
                    return;
                }
                string tradeno = paramsMap["out_trade_no"].ToString();
                var payment = Foresight.DataAccess.Payment.GetPaymentByTradeNo(tradeno);
                if (payment == null)
                {
                    LogHelper.WriteDebug("Payment不存在", "Payment不存在---------");
                    Response.Write("failure");
                    Response.End();
                    return;
                }
                Foresight.DataAccess.Payment.Insert_Payment(payment.Amount, payment.PaymentType, payment.TradeNo, payment.Status, payment.AddUser, payment.Remark, ResponseContent: payment.ResponseContent, payment: payment, CanSave: true);
                var order = Foresight.DataAccess.Mall_Order.GetMall_OrderByTradeNo(tradeno, OrderID: payment.OrderID);
                if (order == null)
                {
                    LogHelper.WriteDebug("订单不存在", "订单不存在---------");
                    Response.Write("failure");
                    Response.End();
                    return;
                }
                if (order.OrderStatus != 1)
                {
                    LogHelper.WriteDebug("订单状态不是未支付", "订单状态不是未支付---------");
                    Response.Write("failure");
                    Response.End();
                    return;
                }
                if (payment.Status != 1)
                {
                    Response.Write("failure");
                    Response.End();
                    return;
                }
                Payment.CompletePayment(TradeNo: tradeno, payment: payment, order: order);
                bool can_socket_notify = false;
                if (order.ProductTypeID != 10)
                {
                    can_socket_notify = true;
                }
                Mall_UserBalance.GetEarnThroughBuy(order, payment);
                if (can_socket_notify)
                {
                    APPCode.SocketNotify.PushSocketNotifyAlert(Utility.EnumModel.SocketNotifyDefine.notifyorderpaied);
                }
                //var history_count = Foresight.DataAccess.RoomFeeHistory.GetRoomFeeHistoryCountByTradeNo(tradeno, OrderID: order.ID);
                //if (history_count > 0)
                //{
                //    Response.Write("failure");
                //    Response.End();
                //    return;
                //}
                var fee_count = Foresight.DataAccess.RoomFee.GetRoomFeeCountByTradeNo(tradeno, OrderID: order.ID);
                if (fee_count > 0)
                {
                    Web.APPCode.PaymentHelper.SaveRoomFee(tradeno, "APP支付宝支付", "支付宝");
                }
                else
                {
                    Payment.CompletePayment(TradeNo: tradeno, payment: payment, order: order);
                }
                Response.Write("success");
                Response.End();
                return;
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("Web.Recive.alipay", "paycallbackapp", ex);
                Response.Write("success");
                Response.End();
                return;
            }
        }
    }
}