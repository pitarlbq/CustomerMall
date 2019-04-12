using Aop.Api.Util;
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

namespace Web.Recive.alipay
{
    public partial class paycallback : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                LogHelper.WriteDebug("支付宝异步", "支付宝异步---------++++++++++++++++++");
                IDictionary<string, string> paramsMap = new Dictionary<string, string>();
                var coll = Request.Params;
                String[] requestItem = coll.AllKeys;
                for (int i = 0; i < requestItem.Length; i++)
                {
                    paramsMap.Add(requestItem[i], coll[requestItem[i]]);
                }
                LogHelper.WriteInfo("paramsMap", JsonConvert.SerializeObject(paramsMap));
                bool checkSign = AlipaySignature.RSACheckV1(paramsMap, AlipayConfig.mobile_public_key_value, "UTF-8", "RSA2", false);
                LogHelper.WriteInfo("checkSign.status", checkSign ? "true" : "false");
                if (!checkSign)
                {
                    //LogHelper.WriteDebug("验签失败", "验签失败---------");
                    //Response.Write("failure");
                    //Response.End();
                    //return;
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
                //    Response.Write("failure");
                //    Response.End();
                //    return;
                //}
                var fee_count = Foresight.DataAccess.RoomFee.GetRoomFeeCountByTradeNo(tradeno);
                if (fee_count > 0)
                {
                    Web.APPCode.PaymentHelper.SaveRoomFee(tradeno, "微信公众号支付宝支付", "支付宝");
                }
                Response.Write("success");
                Response.End();
                return;
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("Web.Recive.alipay", "paycallback", ex);
                Response.Write("success");
                Response.End();
                return;
            }
        }
    }
}