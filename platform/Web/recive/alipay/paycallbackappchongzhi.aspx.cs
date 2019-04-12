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
    public partial class paycallbackappchongzhi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                LogHelper.WriteDebug("支付宝APP充值异步", "支付宝APP异步---------++++++++++++++++++");
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
                    Response.Write("failure");
                    Response.End();
                    return;
                }
                if (payment != null && payment.Status != 1)
                {
                    Response.Write("failure");
                    Response.End();
                    return;
                }
                Payment.CompletePayment(TradeNo: tradeno, payment: payment);
                Foresight.DataAccess.Mall_UserBalance.UpdateMall_UserBalanceStatus(1, payment.TradeNo, payment: payment, PaymentMethod: Utility.EnumModel.Mall_OrderPaymentMethodDefine.alipay.ToString());
                Response.Write("success");
                Response.End();
                return;
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("Web.Recive.alipay", "paycallbackappchongzhi", ex);
                Response.Write("success");
                Response.End();
                return;
            }
        }
    }
}