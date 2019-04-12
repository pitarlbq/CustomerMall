using Aop.Api;
using Aop.Api.Domain;
using Aop.Api.Request;
using Aop.Api.Response;
using Foresight.DataAccess;
using Foresight.DataAccess.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Xml;
using Utility;
using WxPayAPI;

namespace Web.APPCode
{
    public class PaymentHelper
    {
        public static Dictionary<string, string> H5WxPayUnifiedorder(string trade_no, string body, string total_fee)
        {
            string url = "https://api.mch.weixin.qq.com/pay/unifiedorder";
            string wx_appid = PaymentConfig.WeiXinConfig.MobileAppID;
            string wx_mch_id = PaymentConfig.WeiXinConfig.MobileMCHID;
            string notify_url = WeixinConfig.app_notify_url;
            string Server_ID = Utility.Tools.GetClientIP();
            //统一下单
            WxPayData data = new WxPayData();
            data.SetValue("body", body);
            data.SetValue("attach", "test");
            data.SetValue("out_trade_no", trade_no);
            data.SetValue("total_fee", total_fee);
            data.SetValue("time_start", DateTime.Now.ToString("yyyyMMddHHmmss"));
            data.SetValue("time_expire", DateTime.Now.AddMinutes(10).ToString("yyyyMMddHHmmss"));
            data.SetValue("goods_tag", "yongyouapp");
            data.SetValue("trade_type", "MWEB");
            data.SetValue("notify_url", notify_url);//异步通知url
            data.SetValue("appid", wx_appid);//公众账号ID
            data.SetValue("mch_id", wx_mch_id);//商户号
            data.SetValue("spbill_create_ip", Server_ID);//终端ip	  	    
            data.SetValue("nonce_str", WxPayApi.GenerateNonceStr());//随机字符串
            data.SetValue("sign", data.MakeAPPSign());

            string xml = data.ToXml();
            string response = HttpService.Post(xml, url, false, 6);
            WxPayData result = new WxPayData();
            result.FromXml(response);
            if (!result.IsSet("mweb_url"))
            {
                throw new Exception("UnifiedOrder response error!");
            }
            WxPayData appApiParam = new WxPayData();
            appApiParam.SetValue("appid", wx_appid);
            appApiParam.SetValue("partnerid", wx_mch_id);
            appApiParam.SetValue("prepayid", result.GetValue("prepay_id"));
            appApiParam.SetValue("package", "Sign=WXPay");
            appApiParam.SetValue("noncestr", WxPayApi.GenerateNonceStr());
            appApiParam.SetValue("timestamp", WxPayApi.GenerateTimeStamp());
            //appApiParam.SetValue("signType", "MD5");
            appApiParam.SetValue("sign", appApiParam.MakeAPPSign());
            //通信成功
            var res = new Dictionary<string, string>
            {
                {"mweb_url", result.GetValue("mweb_url").ToString()},
            };
            //在服务器上签名
            return res;
        }
        public static Dictionary<string, string> APPWxPayUnifiedorder(string trade_no, string body, string total_fee, bool IsOrder = true, bool IsChongZhi = false)
        {
            string url = "https://api.mch.weixin.qq.com/pay/unifiedorder";
            string wx_appid = PaymentConfig.WeiXinConfig.MobileAppID;
            string wx_mch_id = PaymentConfig.WeiXinConfig.MobileMCHID;
            string notify_url = string.Empty;
            if (IsChongZhi)
            {
                notify_url = WeixinConfig.app_chongzhi_notify_url;
            }
            else if (IsOrder)
            {
                notify_url = WeixinConfig.app_notify_url;
            }
            //统一下单
            WxPayData data = new WxPayData();
            data.SetValue("body", body);
            data.SetValue("attach", "test");
            data.SetValue("out_trade_no", trade_no);
            data.SetValue("total_fee", total_fee);
            data.SetValue("time_start", DateTime.Now.ToString("yyyyMMddHHmmss"));
            data.SetValue("time_expire", DateTime.Now.AddMinutes(10).ToString("yyyyMMddHHmmss"));
            data.SetValue("goods_tag", "yongyouapp");
            data.SetValue("trade_type", "APP");
            data.SetValue("notify_url", notify_url);//异步通知url
            data.SetValue("appid", wx_appid);//公众账号ID
            data.SetValue("mch_id", wx_mch_id);//商户号
            data.SetValue("spbill_create_ip", WxPayConfig.IP);//终端ip	  	    
            data.SetValue("nonce_str", WxPayApi.GenerateNonceStr());//随机字符串
            data.SetValue("sign", data.MakeAPPSign());

            string xml = data.ToXml();
            string response = HttpService.Post(xml, url, false, 6);
            WxPayData result = new WxPayData();
            result.FromXml(response);

            if (!result.IsSet("appid") || !result.IsSet("prepay_id") || result.GetValue("prepay_id").ToString() == "")
            {
                throw new Exception("UnifiedOrder response error!");
            }
            WxPayData appApiParam = new WxPayData();
            appApiParam.SetValue("appid", wx_appid);
            appApiParam.SetValue("partnerid", wx_mch_id);
            appApiParam.SetValue("prepayid", result.GetValue("prepay_id"));
            appApiParam.SetValue("package", "Sign=WXPay");
            appApiParam.SetValue("noncestr", WxPayApi.GenerateNonceStr());
            appApiParam.SetValue("timestamp", WxPayApi.GenerateTimeStamp());
            //appApiParam.SetValue("signType", "MD5");
            appApiParam.SetValue("sign", appApiParam.MakeAPPSign());
            //通信成功
            var res = new Dictionary<string, string>
            {
                {"appid", appApiParam.GetValue("appid").ToString()},
                {"partnerid", appApiParam.GetValue("partnerid").ToString()},
                {"prepayid", appApiParam.GetValue("prepayid").ToString()},
                {"package", appApiParam.GetValue("package").ToString()},
                {"noncestr", appApiParam.GetValue("noncestr").ToString()},
                {"timestamp", appApiParam.GetValue("timestamp").ToString()},
                {"sign", appApiParam.GetValue("sign").ToString()}
            };
            //在服务器上签名
            return res;
        }
        /// <summary>
        /// 2-付款成功 1-未付款 3-异常
        /// </summary>
        /// <param name="out_trade_no"></param>
        /// <returns></returns>
        public static int OrderQuery(string out_trade_no)
        {
            var exist_payment = Foresight.DataAccess.Payment.GetPaymentByTradeNo(out_trade_no);
            if (exist_payment == null)
            {
                return 1;
            }
            if (string.IsNullOrEmpty(exist_payment.PaymentType))
            {
                return 1;
            }
            if (exist_payment.PaymentType.Equals(Utility.EnumModel.PaymentTypeDefine.wx.ToString()))
            {
                if (exist_payment.Status == 2)
                {
                    Web.APPCode.PaymentHelper.SaveRoomFee(out_trade_no, "微信公众号微信支付", "微信支付");
                    return 2;
                }
                WxPayData data = new WxPayData();
                data.SetValue("out_trade_no", out_trade_no);
                WxPayData result = WxPayApi.OrderQuery(data);//提交订单查询请求给API，接收返回数据
                var sort_list = data.FromXml(result.ToXml());
                var trade_state = result.GetValue("trade_state");
                if (trade_state != null && trade_state.ToString() == "SUCCESS")
                {
                    Web.APPCode.PaymentHelper.SaveRoomFee(out_trade_no, "微信公众号微信支付", "微信支付");
                    return 2;
                }
                return 1;
            }
            if (exist_payment.PaymentType.Equals(Utility.EnumModel.PaymentTypeDefine.alipay.ToString()))
            {
                if (exist_payment.Status == 2)
                {
                    Web.APPCode.PaymentHelper.SaveRoomFee(out_trade_no, "微信公众号支付宝支付", "支付宝");
                    return 2;
                }
                return AlipayOrderQuery(out_trade_no);
            }
            if (exist_payment.PaymentType.Equals(Utility.EnumModel.PaymentTypeDefine.app_wx.ToString()))
            {
                if (exist_payment.Status == 2)
                {
                    Web.APPCode.PaymentHelper.SaveRoomFee(out_trade_no, "APP微信支付", "微信支付");
                    return 2;
                }
                WxPayData data = new WxPayData();
                data.SetValue("out_trade_no", out_trade_no);
                WxPayData result = WxPayApi.OrderQueryAPP(data);//提交订单查询请求给API，接收返回数据
                var sort_list = data.FromXml(result.ToXml());
                var trade_state = result.GetValue("trade_state");
                if (trade_state != null && trade_state.ToString() == "SUCCESS")
                {
                    Web.APPCode.PaymentHelper.SaveRoomFee(out_trade_no, "APP微信支付", "微信支付");
                    return 2;
                }
                return 1;
            }
            if (exist_payment.PaymentType.Equals(Utility.EnumModel.PaymentTypeDefine.app_alipay.ToString()))
            {
                if (exist_payment.Status == 2)
                {
                    Web.APPCode.PaymentHelper.SaveRoomFee(out_trade_no, "APP支付宝支付", "支付宝");
                    return 2;
                }
                return AlipayAPPOrderQuery(out_trade_no);
            }
            return 1;
        }
        public static int AlipayOrderQuery(string out_trade_no)
        {
            DefaultAopClient client = new DefaultAopClient(AlipayConfig.mobile_gatewayUrl, AlipayConfig.mobile_app_id, AlipayConfig.mobile_private_key_value, "json", "1.0", AlipayConfig.sign_type, AlipayConfig.mobile_public_key_value, AlipayConfig.charset, false);
            AlipayTradeQueryModel model = new AlipayTradeQueryModel();
            model.OutTradeNo = out_trade_no;

            AlipayTradeQueryRequest request = new AlipayTradeQueryRequest();
            request.SetBizModel(model);
            AlipayTradeQueryResponse response = null;
            try
            {
                response = client.Execute(request);
                if (response.TradeStatus.Equals(AliPayTradeStatus.WAIT_BUYER_PAY.ToString()))
                {
                    return 1;
                }
                if (response.TradeStatus.Equals(AliPayTradeStatus.TRADE_SUCCESS.ToString()))
                {
                    Web.APPCode.PaymentHelper.SaveRoomFee(out_trade_no, "微信公众号支付宝支付", "支付宝");
                    return 2;
                }
                return 3;
            }
            catch (Exception exp)
            {
                LogHelper.WriteError("PaymentHelper", "AlipayOrderQuery", exp);
                return 3;
            }
        }
        public static int AlipayAPPOrderQuery(string out_trade_no)
        {
            DefaultAopClient client = new DefaultAopClient(AlipayConfig.mobile_gatewayUrl, AlipayConfig.mobile_app_id, AlipayConfig.mobile_private_key_value, "json", "1.0", AlipayConfig.sign_type, AlipayConfig.mobile_public_key_value, AlipayConfig.charset, false);
            AlipayTradeQueryModel model = new AlipayTradeQueryModel();
            model.OutTradeNo = out_trade_no;

            AlipayTradeQueryRequest request = new AlipayTradeQueryRequest();
            request.BizContent = "{\"out_trade_no\":\"" + out_trade_no + "\"}";
            request.SetBizModel(model);
            AlipayTradeQueryResponse response = new AlipayTradeQueryResponse();
            try
            {
                response = client.Execute(request);
                if (response.TradeStatus.Equals(AliPayTradeStatus.WAIT_BUYER_PAY.ToString()))
                {
                    return 1;
                }
                if (response.TradeStatus.Equals(AliPayTradeStatus.TRADE_SUCCESS.ToString()))
                {
                    Web.APPCode.PaymentHelper.SaveRoomFee(out_trade_no, "APP支付宝支付", "支付宝");
                    return 2;
                }
                return 3;
            }
            catch (Exception exp)
            {
                LogHelper.WriteError("PaymentHelper", "AlipayAPPOrderQuery", exp);
                return 3;
            }
        }
        public static string SaveRoomFee(string tradeno, string Remark, string ChargeType, int OrderID = 0)
        {
            //var history_count = Foresight.DataAccess.RoomFeeHistory.GetRoomFeeHistoryCountByTradeNo(tradeno, OrderID: OrderID);
            //if (history_count > 0)
            //{
            //    return "历史账单已存在";
            //}
            List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
            var request_list = Foresight.DataAccess.Payment_Request.GetPayment_RequestByTradeNo(tradeno, OrderID: OrderID);
            if (request_list.Length == 0)
            {
                return "Payment_Request不存在";
            }
            RoomFeeAnalysis viewroomfee = null;
            decimal TotalCost = 0;
            int RoomID = 0;
            string RoomFullName = string.Empty;
            string RoomOwnerName = string.Empty;
            string AllParentID = string.Empty;
            foreach (var item in request_list)
            {
                viewroomfee = RoomFeeAnalysis.GetRoomFeeAnalysisByEndTime(item.RoomFeeID, item.EndTime, relatedRequire: true);
                if (viewroomfee == null)
                {
                    continue;
                }
                Dictionary<string, object> dic = new Dictionary<string, object>();
                dic["ID"] = viewroomfee.ID;
                dic["CalculateStartTime"] = viewroomfee.CalculateStartTime;
                dic["CalculateEndTime"] = viewroomfee.CalculateEndTime;
                dic["TotalCost"] = viewroomfee.TotalCost;
                dic["CalculateUnitPrice"] = viewroomfee.CalculateUnitPrice;
                dic["CalculateUseCount"] = viewroomfee.CalculateUseCount;
                list.Add(dic);
                TotalCost += viewroomfee.TotalCost;
                RoomID = viewroomfee.RoomID;
                RoomFullName = viewroomfee.FullName + "-" + viewroomfee.RoomName;
                RoomOwnerName = viewroomfee.FinalCustomerName;
                AllParentID = viewroomfee.AllParentID;
            }
            if (list.Count == 0)
            {
                return "ViewRoomFee不存在";
            }
            var payment = Foresight.DataAccess.Payment.GetPaymentByTradeNo(tradeno);
            string OpenID = payment.AddUser;
            var wuser = Foresight.DataAccess.Wechat_User.GetWechat_UserByUserOpenID(OpenID);
            string AddMan = (wuser != null && !string.IsNullOrEmpty(wuser.NickName)) ? wuser.NickName : OpenID;
            PrintRoomFeeHistory printRoomFeeHistory = new PrintRoomFeeHistory();
            string ChargeMan = AddMan;
            var ConfigName = SysConfigNameDefine.WeixinChargeMan;
            var sysConfigList = SysConfig.Get_SysConfigListByProjectIDList(MinProjectID: RoomID, MaxProjectID: RoomID, ConfigName: ConfigName);
            string defaultChargeManName = SysConfig.GetConfigValueByList(sysConfigList, ConfigName, AllParentID: AllParentID);
            if (!string.IsNullOrEmpty(defaultChargeManName))
            {
                ChargeMan = defaultChargeManName;
            }
            var ViewChargeSummaryList = ViewChargeSummary.GetViewChargeSummaries().ToArray();
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    SavePrintRoomFeeHistory(printRoomFeeHistory, RoomID, TotalCost, ChargeMan, helper, RoomFullName, RoomOwnerName, Remark, ChargeType, payment.AddTime);
                    foreach (var field in list)
                    {
                        int FeeID = WebUtil.GetIntByStr(field["ID"].ToString());
                        var roomFee = Foresight.DataAccess.RoomFee.GetRoomFee(FeeID, helper);
                        if (roomFee == null)
                        {
                            continue;
                        }
                        DateTime CalculateStartTime = WebUtil.GetDateTimeByStr(field["CalculateStartTime"].ToString());
                        roomFee.StartTime = CalculateStartTime > DateTime.MinValue ? CalculateStartTime : DateTime.MinValue;
                        DateTime CalculateEndTime = WebUtil.GetDateTimeByStr(field["CalculateEndTime"].ToString());
                        roomFee.EndTime = CalculateEndTime > DateTime.MinValue ? CalculateEndTime : DateTime.MinValue;
                        decimal CalculateUseCount = WebUtil.GetDecimalByStr(field["CalculateUseCount"].ToString());
                        roomFee.UseCount = CalculateUseCount;
                        decimal CalculateTotalCost = WebUtil.GetDecimalByStr(field["TotalCost"].ToString());
                        roomFee.Cost = CalculateTotalCost > 0 ? CalculateTotalCost : 0;
                        roomFee.IsCharged = true;
                        decimal CalculateUnitPrice = WebUtil.GetDecimalByStr(field["CalculateUnitPrice"].ToString());
                        roomFee.UnitPrice = CalculateUnitPrice > 0 ? CalculateUnitPrice : 0;
                        roomFee.ChargeFee = roomFee.ChargeFee > 0 ? roomFee.ChargeFee : 0;
                        roomFee.RealCost = roomFee.ChargeFee > 0 ? roomFee.ChargeFee : (roomFee.Cost > decimal.MinValue ? roomFee.Cost : 0);
                        roomFee.Discount = roomFee.Discount > 0 ? roomFee.Discount : 0;
                        roomFee.TotalRealCost = (roomFee.TotalRealCost < 0 ? 0 : roomFee.TotalRealCost) + roomFee.RealCost;
                        roomFee.TotalDiscountCost = (roomFee.TotalDiscountCost < 0 ? 0 : roomFee.TotalDiscountCost) + roomFee.Discount;
                        decimal restcost = roomFee.Cost - roomFee.TotalDiscountCost - roomFee.TotalRealCost;
                        if (restcost < 0)
                        {
                            restcost = 0;
                        }
                        roomFee.RestCost = restcost;
                        roomFee.Remark = Remark;
                        roomFee.Save(helper);
                        #region 收费后续操作
                        LogHelper.WriteInfo("Web.APPCode.HandlerHelper.SaveRoomFee", "收费后续操作开始");
                        Web.APPCode.HandlerHelper.SaveRoomFee(roomFee, ChargeMan, helper, printRoomFeeHistory, ViewChargeSummaryList, OpenID: OpenID);
                        LogHelper.WriteInfo("Web.APPCode.HandlerHelper.SaveRoomFee", "收费后续操作完成");
                        #endregion
                    }
                    Payment.CompletePayment(helper, TradeNo: tradeno, payment: payment);
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError("PaymentHelper.SaveRoomFee", ChargeType, ex);
                    return ex.Message;
                }
            }
            return "Success";
        }
        private static void SavePrintRoomFeeHistory(PrintRoomFeeHistory printRoomFeeHistory, int RoomID, decimal RealCost, string ChargeMan, SqlHelper helper, string RoomFullName, string RoomOwnerName, string Remark, string ChargeType, DateTime ChargeTime)
        {
            var chargemoneytype = Foresight.DataAccess.ChargeMoneyType.GetChargeMoneyTypeByChargeName(ChargeType);
            int ChargeType1 = chargemoneytype.ChargeTypeID;
            int ChargeType2 = 0;
            int OrderNumberID = 0;
            string PrintNumber = PrintRoomFeeHistory.GetLastestPrintNumber(OrderTypeNameDefine.chargefee.ToString(), RoomID, helper, out OrderNumberID);
            var sys_ordernumber = Sys_OrderNumber.GetSys_OrderNumber(OrderNumberID, helper);
            printRoomFeeHistory.PrintNumber = PrintNumber;
            printRoomFeeHistory.OrderNumberID = sys_ordernumber != null ? sys_ordernumber.ID : 0;
            printRoomFeeHistory.OrderNumberType = sys_ordernumber != null ? sys_ordernumber.ChargeType : 1;
            decimal PreChargeMoney = 0;
            decimal ChargeBackMoney = 0;
            decimal RealMoneyCost1 = RealCost;
            decimal RealMoneyCost2 = 0;
            decimal DiscountMoney = 0;
            decimal money = RealCost;
            string MoneyDaXie = Utility.Tools.CmycurD(RealCost);
            printRoomFeeHistory.Cost = money;
            printRoomFeeHistory.CostCapital = MoneyDaXie;
            printRoomFeeHistory.RealCost = RealCost;
            printRoomFeeHistory.PreChargeMoney = PreChargeMoney;
            printRoomFeeHistory.ChargeBackMoney = ChargeBackMoney;
            printRoomFeeHistory.RealMoneyCost1 = RealMoneyCost1;
            printRoomFeeHistory.RealMoneyCost2 = RealMoneyCost2;
            printRoomFeeHistory.DiscountMoney = DiscountMoney;
            printRoomFeeHistory.ChargeMan = ChargeMan;
            printRoomFeeHistory.ChargeTime = ChargeTime;
            printRoomFeeHistory.Remark = Remark;
            printRoomFeeHistory.ChageType1 = ChargeType1;
            printRoomFeeHistory.ChageType2 = ChargeType2;
            if (printRoomFeeHistory.AddTime == DateTime.MinValue)
            {
                printRoomFeeHistory.AddTime = DateTime.Now;
            }
            printRoomFeeHistory.WeiShuMore = 0;
            printRoomFeeHistory.WeiShuConsume = 0;
            printRoomFeeHistory.RoomFullName = RoomFullName;
            printRoomFeeHistory.RoomOwnerName = RoomOwnerName;
            printRoomFeeHistory.Save(helper);
        }
        public static void SaveMallOrder(Mall_Order order)
        {
            try
            {
                bool can_socket_notify = false;
                if (order.OrderStatus != 1 || string.IsNullOrEmpty(order.TradeNo))
                {
                    return;
                }
                int PayStatus = APPCode.PaymentHelper.OrderQuery(order.TradeNo);
                if (PayStatus != 2)
                {
                    return;
                }
                var payment = Foresight.DataAccess.Payment.GetPaymentByTradeNo(order.TradeNo);
                if (payment != null)
                {
                    if (payment.Status != 1)
                    {
                        return;
                    }
                }
                Payment.CompletePayment(TradeNo: order.TradeNo, payment: payment, order: order);
                Mall_UserBalance.GetEarnThroughBuy(order, payment);
                if (can_socket_notify)
                {
                    APPCode.SocketNotify.PushSocketNotifyAlert(type: Utility.EnumModel.SocketNotifyDefine.notifyorderpaied);
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("PaymentHelper.css", "SaveMallOrder", ex);
            }
        }
        public static bool WxPayRefundRequest(string trade_no, int total_fee, string out_refund_no, out string response)
        {
            response = string.Empty;
            if (string.IsNullOrEmpty(out_refund_no))
            {
                out_refund_no = WxPayApi.GenerateOutTradeNo();
            }
            string url = "https://api.mch.weixin.qq.com/secapi/pay/refund";
            string wx_appid = PaymentConfig.WeiXinConfig.MobileAppID;
            string wx_mch_id = PaymentConfig.WeiXinConfig.MobileMCHID;
            WxPayData data = new WxPayData();
            data.SetValue("out_trade_no", trade_no);
            data.SetValue("total_fee", total_fee);//订单总金额
            data.SetValue("refund_fee", total_fee);//退款金额
            data.SetValue("out_refund_no", out_refund_no);//随机生成商户退款单号
            data.SetValue("op_user_id", wx_mch_id);//操作员，默认为商户号
            data.SetValue("appid", wx_appid);//公众账号ID
            data.SetValue("mch_id", wx_mch_id);//商户号
            data.SetValue("nonce_str", Guid.NewGuid().ToString().Replace("-", ""));//随机字符串
            data.SetValue("sign", data.MakeAPPSign());//签名

            string xml = data.ToXml();
            response = HttpService.Post(xml, url, true, 6, SSLCERT_PATH: PaymentConfig.WeiXinConfig.MobileSSLCERT_PATH, SSLCERT_PASSWORD: PaymentConfig.WeiXinConfig.MobileSSLCERT_PASSWORD);//调用HTTP通信接口提交数据到API
            WxPayData result = new WxPayData();
            result.FromXml(response);
            if (result.IsSet("return_code"))
            {
                if (result.GetValue("return_code").ToString().Equals("SUCCESS"))
                {
                    return true;
                }
                return false;
            }
            else
            {
                response = result.GetValue("return_msg").ToString();
            }
            return false;
        }
        public static bool WxPayRefundResult(string trade_no, string out_refund_no)
        {
            string url = "https://api.mch.weixin.qq.com/pay/refundquery";
            string wx_appid = PaymentConfig.WeiXinConfig.MobileAppID;
            string wx_mch_id = PaymentConfig.WeiXinConfig.MobileMCHID;
            WxPayData data = new WxPayData();
            data.SetValue("out_refund_no", out_refund_no);
            data.SetValue("appid", wx_appid);//公众账号ID
            data.SetValue("mch_id", wx_mch_id);//商户号
            data.SetValue("nonce_str", Guid.NewGuid().ToString().Replace("-", ""));//随机字符串
            data.SetValue("sign", data.MakeAPPSign());//签名

            string xml = data.ToXml();
            string response = HttpService.Post(xml, url, true, 6, SSLCERT_PATH: PaymentConfig.WeiXinConfig.MobileSSLCERT_PATH, SSLCERT_PASSWORD: PaymentConfig.WeiXinConfig.MobileSSLCERT_PASSWORD);//调用HTTP通信接口提交数据到API
            WxPayData result = new WxPayData();
            result.FromXml(response);
            if (result.IsSet("return_code"))
            {
                if (result.GetValue("return_code").Equals("SUCCESS"))
                {
                    return true;
                }
                return false;
            }
            return false;
        }
        public static bool AliPayRefundRequest(string trade_no, string total_fee, string out_refund_no, out string response)
        {
            IAopClient client = new DefaultAopClient(AlipayConfig.mobile_gatewayUrl, AlipayConfig.mobile_app_id, AlipayConfig.mobile_private_key_value, "json", "1.0", AlipayConfig.sign_type, AlipayConfig.mobile_public_key_value, AlipayConfig.charset, false);
            AlipayTradeRefundRequest request = new AlipayTradeRefundRequest();
            request.BizContent = "{" +
            "\"out_trade_no\":\"" + trade_no + "\"," +
            "\"refund_amount\":" + total_fee + "," +
            "\"out_request_no\":\"" + out_refund_no + "\"" +
            "  }";
            AlipayTradeRefundResponse responsed = client.Execute(request);
            response = responsed.Body;
            if (responsed.Code == "10000")
            {
                return true;
            }
            return false;
        }
        public static bool AliPayRefundResult(string trade_no, string out_refund_no)
        {
            IAopClient client = new DefaultAopClient(AlipayConfig.mobile_gatewayUrl, AlipayConfig.mobile_app_id, AlipayConfig.mobile_private_key_value, "json", "1.0", AlipayConfig.sign_type, AlipayConfig.mobile_public_key_value, AlipayConfig.charset, false);
            AlipayTradeFastpayRefundQueryRequest request = new AlipayTradeFastpayRefundQueryRequest();
            request.BizContent = "{" +
            "\"out_trade_no\":\"" + trade_no + "\"," +
            "\"out_request_no\":\"" + out_refund_no + "\"" +
            "}";
            AlipayTradeFastpayRefundQueryResponse response = client.Execute(request);
            if (response.Code == "10000")
            {
                return true;
            }
            return false;
        }
    }
    /// 交易状态：WAIT_BUYER_PAY（交易创建，等待买家付款）、TRADE_CLOSED（未付款交易超时关闭，或支付完成后全额退款）、TRADE_SUCCESS（交易支付成功）、TRADE_FINISHED（交易结束，不可退款）
    public enum AliPayTradeStatus
    {
        WAIT_BUYER_PAY,
        TRADE_CLOSED,
        TRADE_SUCCESS,
        TRADE_FINISHED,
    }
}