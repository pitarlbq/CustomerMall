using Foresight.DataAccess;
using Foresight.DataAccess.Framework;

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Utility;

namespace Web.Mobile
{
    /// <summary>
    /// MallBusinessAPI 的摘要说明
    /// </summary>
    public class MallBusinessAPI : IHttpHandler
    {

        const string LogModuel = "MallBusinessAPI";
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string action = context.Request.Params["action"];
            if (string.IsNullOrEmpty(action))
            {
                LogHelper.WriteDebug(LogModuel, "action为空");
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "action为空");
                return;
            }
            action = action.ToLower();
            try
            {
                switch (action)
                {
                    case "dologin":
                        dologin(context);
                        break;
                    case "checkloginstatus":
                        checkloginstatus(context);
                        break;
                    case "getrotatingimages":
                        getrotatingimages(context);
                        break;
                    case "getbusinesscategorylist":
                        getbusinesscategorylist(context);
                        break;
                    case "savebusinessapplication":
                        savebusinessapplication(context);
                        break;
                    case "getbusinessapplication":
                        getbusinessapplication(context);
                        break;
                    case "registercheckphone":
                        registercheckphone(context);
                        break;
                    case "removebusinesscoverimg":
                        removebusinesscoverimg(context);
                        break;
                    case "removebusinesspicture":
                        removebusinesspicture(context);
                        break;
                    case "getproductcount":
                        getproductcount(context);
                        break;
                    case "getbusinessproductlist":
                        getbusinessproductlist(context);
                        break;
                    case "getmallbusinesshomesource":
                        getmallbusinesshomesource(context);
                        break;
                    case "getmallproductdetail":
                        getmallproductdetail(context);
                        break;
                    case "savebusinessproduct":
                        savebusinessproduct(context);
                        break;
                    case "removeproductimage":
                        removeproductimage(context);
                        break;
                    case "getproductdescription":
                        getproductdescription(context);
                        break;
                    case "saveproductdescription":
                        saveproductdescription(context);
                        break;
                    case "removeproductdesc":
                        removeproductdesc(context);
                        break;
                    case "removebusinessproduct":
                        removebusinessproduct(context);
                        break;
                    case "offlinebusinessproduct":
                        offlinebusinessproduct(context);
                        break;
                    case "savebusinessproductcategory":
                        savebusinessproductcategory(context);
                        break;
                    case "getproductcategorylist":
                        getproductcategorylist(context);
                        break;
                    case "getmyorderlist":
                        getmyorderlist(context);
                        break;
                    case "closemyorder":
                        closemyorder(context);
                        break;
                    case "getmallorderdetail":
                        getmallorderdetail(context);
                        break;
                    case "saveorderdelivery":
                        saveorderdelivery(context);
                        break;
                    case "completemyorder":
                        completemyorder(context);
                        break;
                    case "getmallcustomerstatics":
                        getmallcustomerstatics(context);
                        break;
                    case "getmallchattitlelist":
                        getmallchattitlelist(context);
                        break;
                    case "getmallchatdetaillist":
                        getmallchatdetaillist(context);
                        break;
                    case "postmallchatcontent":
                        postmallchatcontent(context);
                        break;
                    case "savedeviceid":
                        savedeviceid(context);
                        break;
                    case "getmsglist":
                        getmsglist(context);
                        break;
                    case "getmsgdetail"://获取通知消息详情
                        getmsgdetail(context);
                        break;
                    case "savemydiscountrequest":
                        savemydiscountrequest(context);
                        break;
                    case "getdiscountrequestlist":
                        getdiscountrequestlist(context);
                        break;
                    case "getdiscountrequestdetail":
                        getdiscountrequestdetail(context);
                        break;
                    case "getbusinessbalancecountlist":
                        getbusinessbalancecountlist(context);
                        break;
                    case "grabmallbusinesschat":
                        grabmallbusinesschat(context);
                        break;
                    case "getbusinessindexcount":
                        getbusinessindexcount(context);
                        break;
                    case "savenewpassword":
                        savenewpassword(context);
                        break;
                    case "getordertabcountlist":
                        getordertabcountlist(context);
                        break;
                    case "savemallorderrefund":
                        savemallorderrefund(context);
                        break;
                    case "getshipcompanylist":
                        getshipcompanylist(context);
                        break;
                    case "getmallproductvariantdetail":
                        getmallproductvariantdetail(context);
                        break;
                    case "saveproductvariant":
                        saveproductvariant(context);
                        break;
                    case "getproductvariantlist":
                        getproductvariantlist(context);
                        break;
                    case "removeproductvariant":
                        removeproductvariant(context);
                        break;
                    case "getiscountproductlist":
                        getiscountproductlist(context);
                        break;
                    case "savediscountproduct":
                        savediscountproduct(context);
                        break;
                    case "completechoosediscountproduct":
                        completechoosediscountproduct(context);
                        break;
                    default:
                        WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "action不合法");
                        break;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(LogModuel, action, ex);
                if (ex.Message.Equals("get_uid_failed"))
                {
                    WebUtil.WriteJsonError(context, ErrorCode.AuthenticationFail, ex.Message);
                    return;
                }
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, ex.Message);
            }
        }
        private void completechoosediscountproduct(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            var business = Mall_Business.GetMall_BusinessByUserID(user.UserID);
            int ID = WebUtil.GetIntValue(context, "ID");
            string guid = context.Request["guid"];
            var IDList = new List<int>();
            var IDListStr = context.Request["IDList"];
            if (!string.IsNullOrEmpty(IDListStr))
            {
                IDList = JsonConvert.DeserializeObject<List<int>>(IDListStr);
            }
            if (IDList.Count == 0)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "请选择商品");
                return;
            }
            var data_list = Mall_BusinessDiscountRequest_Product.GetMall_BusinessDiscountRequest_ProductListByBusinessDiscountRequestID(ID, guid);
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    foreach (var ProductID in IDList)
                    {
                        var my_data = data_list.FirstOrDefault(p => p.ProductID == ProductID);
                        if (my_data == null)
                        {
                            my_data = new Mall_BusinessDiscountRequest_Product();
                            my_data.AddTime = DateTime.Now;
                            my_data.AddUserName = user.LoginName;
                            my_data.BusinessDiscountRequestID = ID;
                            my_data.BusinessID = business.ID;
                            my_data.ProductID = ProductID;
                            my_data.Guid = Guid.Parse(guid);
                            my_data.Quantity = 0;
                            my_data.Price = 0;
                            my_data.Quantity = 0;
                            my_data.Save(helper);
                        }
                        foreach (var item in data_list)
                        {
                            if (!IDList.Contains(item.ProductID))
                            {
                                item.Delete(helper);
                            }
                        }
                    }
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError(LogModuel, "completechoosediscountproduct", ex);
                    WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, ex.Message);
                }
            }
            WebUtil.WriteJsonResult(context, "success");
        }
        private void savediscountproduct(HttpContext context)
        {
            var list = new List<DiscountProductModel>();
            var liststr = context.Request["list"];
            if (!string.IsNullOrEmpty(liststr))
            {
                list = JsonConvert.DeserializeObject<List<Utility.DiscountProductModel>>(liststr);
            }
            if (list.Count == 0)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "请选择商品");
                return;
            }
            var data_list = Mall_BusinessDiscountRequest_Product.GetMall_BusinessDiscountRequest_ProductListByIDList(list.Select(p => p.ID).ToList());
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    foreach (var item in list)
                    {
                        var my_data = data_list.FirstOrDefault(p => p.ID == item.ID);
                        if (my_data == null)
                        {
                            continue;
                        }
                        my_data.Price = item.SalePrice;
                        my_data.Quantity = item.SaleQuantity;
                        my_data.Save(helper);
                    }
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError(LogModuel, "savediscountproduct", ex);
                    WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, ex.Message);
                }
            }
            WebUtil.WriteJsonResult(context, "success");
        }
        private void getiscountproductlist(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            string guid = context.Request["guid"];
            var list = Mall_BusinessDiscountRequest_ProductDetail.GetMall_BusinessDiscountRequest_ProductDetailListByBusinessDiscountRequestID(ID, guid);
            var items = list.Select(p =>
            {
                var item = new DiscountProductModel { ID = p.ID, ProductName = p.ProductName, SalePrice = p.Price, SaleQuantity = p.Quantity, FinalPrice = p.FinalPrice, FinalInventory = p.FinalInventory };
                return item;
            }).ToArray();
            WebUtil.WriteJsonResult(context, new { list = items });
        }
        private void removeproductvariant(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            Mall_Product_Variant.DeleteMall_Product_Variant(ID);
            WebUtil.WriteJsonResult(context, "Success");
        }
        private void getproductvariantlist(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            string guid = context.Request["guid"];
            var list = Mall_Product_Variant.GetMall_Product_VariantListByProductID(ID, GUID: guid);
            var items = list.Select(p =>
            {
                var item = new { ID = p.ID, Name = p.VariantName };
                return item;
            }).ToArray();
            WebUtil.WriteJsonResult(context, new { list = items });
        }
        private void getmallproductvariantdetail(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            int ProductID = WebUtil.GetIntValue(context, "ProductID");
            string guid = context.Request["guid"];
            Mall_Product_Variant data = null;
            if (ID > 0)
            {
                data = Mall_Product_Variant.GetMall_Product_Variant(ID);
            }
            if (data == null)
            {
                WebUtil.WriteJsonResult(context, new
                {
                    ID = 0,
                    ProductID = ProductID,
                    VariantName = "",
                    VariantPrice = "",
                    VariantInventory = "",
                    IsNew = true,
                    guid = guid
                });
                return;
            }
            WebUtil.WriteJsonResult(context, new
            {
                ID = data.ID,
                ProductID = ProductID,
                VariantName = data.VariantName,
                VariantPrice = data.VariantPrice,
                VariantInventory = data.Inventory,
                IsNew = false,
                guid = guid
            });
        }
        private void saveproductvariant(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            int ID = WebUtil.GetIntValue(context, "ID");
            int ProductID = WebUtil.GetIntValue(context, "ProductID");
            string guid = context.Request["guid"];
            Mall_Product_Variant variant = null;
            if (ID > 0)
            {
                variant = Mall_Product_Variant.GetMall_Product_Variant(ID);
            }
            if (variant == null)
            {
                variant = new Mall_Product_Variant();
                variant.AddTime = DateTime.Now;
                variant.AddMan = user.RealName;
                variant.ProductID = ProductID;
                variant.GUID = guid;
            }
            variant.VariantTitle = context.Request["VariantTitle"];
            variant.VariantName = context.Request["VariantName"];
            variant.Inventory = WebUtil.GetIntValue(context, "VariantInventory");
            variant.VariantPrice = WebUtil.GetDecimalValue(context, "VariantPrice");
            variant.VariantPoint = 0;
            variant.VariantPointPrice = 0;
            variant.VariantVIPPrice = 0;
            variant.VariantVIPPoint = 0;
            variant.VariantStaffPoint = 0;
            variant.VariantStaffPrice = 0;
            variant.Save();
            WebUtil.WriteJsonResult(context, "Success");
        }
        private void getshipcompanylist(HttpContext context)
        {
            var list = Mall_ShipRate.GetMall_ShipRates().OrderByDescending(p => p.IsDefault).ThenByDescending(p => p.AddTime).ToArray();
            var items = list.Select(p =>
            {
                var item = new { ID = p.ID, Name = p.RateTile, RateType = p.RateType };
                return item;
            }).ToArray();
            WebUtil.WriteJsonResult(context, new { list = items });
        }
        private void savemallorderrefund(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            var uid = GetUID(context, out user);
            int ID = WebUtil.GetIntValue(context, "id");
            var data = Foresight.DataAccess.Mall_Order.GetMall_Order(ID);
            if (data == null)
            {
                WebUtil.WriteJson(context, new { status = false, error = "订单不存在" });
                return;
            }
            if (data.OrderStatus != 6 || data.TotalOrderCost <= 0)
            {
                WebUtil.WriteJson(context, new { status = false, error = "操作不允许" });
                return;
            }
            var list = Foresight.DataAccess.Mall_OrderRefundRequest.GetMall_OrderRefundRequestListByOrderID(data.ID).OrderByDescending(p => p.AddTime).ToArray();
            if (list.Length == 0)
            {
                WebUtil.WriteJson(context, new { status = false, error = "申请退款记录已删除" });
                return;
            }
            var refund_request = list[0];
            string RefundNo = WxPayAPI.WxPayApi.GenerateOutTradeNo();
            int RefundAmount = Convert.ToInt32(data.TotalOrderCost * 100);
            string result = string.Empty;
            bool IsSuccess = false;
            if (data.PaymentMethod.Equals(Utility.EnumModel.Mall_OrderPaymentMethodDefine.wxpay.ToString()))
            {
                IsSuccess = APPCode.PaymentHelper.WxPayRefundRequest(data.TradeNo, RefundAmount, RefundNo, out result);
                //返还账户余额退款后清除
                Mall_UserBalance.Insert_Mall_UserBalance(data.UserID, 2, data.TotalOrderCost, "退款赠予金额清除", "OrderID:" + data.ID, 7, user.LoginName, 1, data.TradeNo, RelatedID: data.ID, PaymentMethod: data.PaymentMethod);
                //返还积分退款后清除
                Mall_UserPoint.Insert_Mall_UserPoint(data.UserID, 2, data.TotalOrderCost, "退款赠与积分清除", "OrderID:" + data.ID, 7, user.LoginName, 1, data.TradeNo, data.ID, RelatedID: data.ID);
            }
            else if (data.PaymentMethod.Equals(Utility.EnumModel.Mall_OrderPaymentMethodDefine.alipay.ToString()))
            {
                IsSuccess = APPCode.PaymentHelper.AliPayRefundRequest(data.TradeNo, data.TotalOrderCost.ToString("0.00"), RefundNo, out result);
                //返还账户余额退款后清除
                Mall_UserBalance.Insert_Mall_UserBalance(data.UserID, 2, data.TotalOrderCost, "退款赠予金额清除", "OrderID:" + data.ID, 7, user.LoginName, 1, data.TradeNo, RelatedID: data.ID, PaymentMethod: data.PaymentMethod);
                //返还积分退款后清除
                Mall_UserPoint.Insert_Mall_UserPoint(data.UserID, 2, data.TotalOrderCost, "退款赠与积分清除", "OrderID:" + data.ID, 7, user.LoginName, 1, data.TradeNo, data.ID, RelatedID: data.ID);
            }
            else if (data.PaymentMethod.Equals(Utility.EnumModel.Mall_OrderPaymentMethodDefine.balance.ToString()))
            {
                //消费账户金额返回到账户
                Mall_UserBalance.Insert_Mall_UserBalance(data.UserID, 1, data.TotalOrderCost, "订单退款", "OrderID:" + data.ID, 4, user.LoginName, 1, RefundNo, RelatedID: data.ID, PaymentMethod: data.PaymentMethod);
                //返还账户余额退款后清除
                Mall_UserBalance.Insert_Mall_UserBalance(data.UserID, 2, data.TotalOrderCost, "退款赠予金额清除", "OrderID:" + data.ID, 7, user.LoginName, 1, data.TradeNo, RelatedID: data.ID, PaymentMethod: data.PaymentMethod);
                //返还积分退款后清除
                Mall_UserPoint.Insert_Mall_UserPoint(data.UserID, 2, data.TotalOrderCost, "退款赠与积分清除", "OrderID:" + data.ID, 7, user.LoginName, 1, data.TradeNo, data.ID, RelatedID: data.ID);
                IsSuccess = true;
                result = "账户余额消费退款成功";
            }
            else if (data.PaymentMethod.Equals(Utility.EnumModel.Mall_OrderPaymentMethodDefine.point.ToString()))
            {
                Mall_UserPoint.Insert_Mall_UserPoint(data.UserID, 1, data.TotalOrderCost, "积分购买退货返回", "OrderID:" + data.ID, 3, "System", 1, RefundNo, data.ID, RelatedID: data.ID);
                IsSuccess = true;
                result = "积分消费退款成功";
            }
            if (IsSuccess)
            {
                data.RefundTrackNo = RefundNo;
                data.RefundTime = DateTime.Now;
                data.OrderStatus = 7;
                data.Save();
                refund_request.RefundAmount = Convert.ToDecimal(RefundAmount);
                refund_request.RefundTrackNo = RefundNo;
                refund_request.IsSuccess = IsSuccess;
                refund_request.Result = result;
                refund_request.Save();
                //推送通知用户
                var app_user = Foresight.DataAccess.User.GetUser(data.UserID);
                if (app_user != null && !string.IsNullOrEmpty(app_user.DeviceId))
                {
                    var company = Foresight.DataAccess.Company.GetCompanies().FirstOrDefault();
                    string companyname = company != null ? company.CompanyName : "永友网络";
                    string[] android_cids = app_user.DeviceType.Equals("android") ? new string[] { app_user.DeviceId } : new string[] { };
                    string[] ios_cids = app_user.DeviceType.Equals("ios") ? new string[] { app_user.DeviceId } : new string[] { };
                    Dictionary<string, object> extras = new Dictionary<string, object>();
                    int ContentCode = 601;
                    string ContentMsg = "您的订单" + data.OrderNumber + "已退款成功";
                    var extra_model = new Utility.JpushContent(ContentCode, Msg: ContentMsg, Type: "mallorder_refund");
                    extras["code"] = extra_model.code;
                    extras["msg"] = extra_model.msg;
                    extras["type"] = extra_model.type;
                    extras["id"] = data.ID;
                    string push_result = JPush.JpushAPI.PushMessage(companyname, extras, android_cids: android_cids, ios_cids: ios_cids, msg_content: extra_model.msg, PushAPP: 2, IsToAll: false);
                    Foresight.DataAccess.JPushLog.Insert_JPushLog(android_cids, ios_cids, extras, push_result, 9, data.ID, true, companyname);
                }
            }
            WebUtil.WriteJsonResult(context, "Success");
        }
        private void getordertabcountlist(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            var uid = GetUID(context, out user);
            var business = Mall_Business.GetMall_BusinessByUserID(user.UserID);
            var list = Mall_OrderAnalysis.GetMall_OrderGroupCountByBusinessID(business.ID);
            //待发货
            int wait_ship_count = list.Where(p => p.OrderStatus == 5).Sum(p => p.TotalCount);
            //待退款
            int wait_refund_count = list.Where(p => p.OrderStatus == 6).Sum(p => p.TotalCount);
            //待付款
            int wait_pay_count = list.Where(p => p.OrderStatus == 1).Sum(p => p.TotalCount);
            //待收货
            int wait_complete_ship_count = list.Where(p => p.OrderStatus == 2).Sum(p => p.TotalCount);
            //已收货
            int complete_ship_count = Mall_Order.GetMall_OrderCompleteCountByBusinessID(business.ID, false);
            //已完成
            int complete_done_count = Mall_Order.GetMall_OrderCompleteCountByBusinessID(business.ID, true);
            //已退款
            int complete_refund_count = list.Where(p => p.OrderStatus == 7).Sum(p => p.TotalCount);
            //已关闭
            int complete_close_count = Mall_Order.GetMall_OrderCountByBusinessID(business.ID, new int[] { 4 });
            //全部
            int all_count = wait_ship_count + wait_refund_count + wait_pay_count + complete_ship_count + complete_done_count + complete_refund_count + complete_close_count;
            WebUtil.WriteJsonResult(context, new { wait_ship_count = wait_ship_count, wait_refund_count = wait_refund_count, wait_pay_count = wait_pay_count, complete_ship_count = complete_ship_count, complete_done_count = complete_done_count, complete_refund_count = complete_refund_count, complete_close_count = complete_close_count, all_count = all_count, wait_complete_ship_count = wait_complete_ship_count });
        }
        private void savenewpassword(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            string password = context.Request["password"];
            if (!User.EncryptPassword(password).Equals(user.Password))
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "原密码不正确");
                return;
            }
            string newpassword = context.Request["newpassword"];
            user.Password = User.EncryptPassword(newpassword);
            user.Save();
            WebUtil.WriteJsonResult(context, "Success");
        }
        private void getbusinessindexcount(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            var uid = GetUID(context, out user);
            int msgcount = Mall_ChatTitleDetail.GetBusinessMsgCountByUserID(uid);
            var business = Mall_Business.GetMall_BusinessByUserID(user.UserID);
            int ordercount = Mall_Order.GetMall_OrderCountByBusinessID(business.ID, new int[] { 5, 6 });
            WebUtil.WriteJsonResult(context, new { msgcount = msgcount, ordercount = ordercount });
        }
        private void grabmallbusinesschat(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            var uid = GetUID(context, out user);
            int ID = WebUtil.GetIntValue(context, "ID");

            bool grab_result = Mall_ChatTitle.GrabMall_ChatTitleByAPPUserID(ID, user.UserID);
            if (grab_result)
            {
                WebUtil.WriteJsonResult(context, "Success");
                return;
            }
            WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "您的同事正在与该客户沟通");
        }
        private void getbusinessbalancecountlist(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            var uid = GetUID(context, out user);
            var business = Mall_Business.GetMall_BusinessByUserID(user.UserID);
            int minday = WebUtil.GetIntValue(context, "minday");
            int maxday = WebUtil.GetIntValue(context, "maxday");
            //可提现
            decimal can_balance_value = Mall_OrderAnalysis.GetMall_OrderBalanceCountByBusinessID(business.ID, minday, maxday, 1);
            //交易中
            decimal saleing_value = Mall_OrderAnalysis.GetMall_OrderBalanceCountByBusinessID(business.ID, minday, maxday, 4);
            //结算中
            decimal sale_done_value = Mall_OrderAnalysis.GetMall_OrderBalanceCountByBusinessID(business.ID, minday, maxday, 2);
            //已提现
            decimal complete_value = Mall_OrderAnalysis.GetMall_OrderBalanceCountByBusinessID(business.ID, minday, maxday, 3);
            WebUtil.WriteJsonResult(context, new { can_balance_value = can_balance_value.ToString("0.00"), saleing_value = saleing_value.ToString("0.00"), sale_done_value = sale_done_value.ToString("0.00"), complete_value = complete_value.ToString("0.00") });
        }
        private void getdiscountrequestdetail(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            Mall_BusinessDiscountRequest data = null;
            if (ID > 0)
            {
                data = Mall_BusinessDiscountRequest.GetMall_BusinessDiscountRequest(ID);
            }
            string guid = Guid.NewGuid().ToString();
            string StartTime = string.Empty;
            string EndTime = string.Empty;
            string AddTime = string.Empty;
            string AddUserMan = string.Empty;
            string RequestContent = string.Empty;
            string ApproveTime = string.Empty;
            string ApproveUserMan = string.Empty;
            int status = 0;
            string ApproveStatusDesc = string.Empty;
            if (data != null)
            {
                StartTime = data.StartTime > DateTime.MinValue ? data.StartTime.ToString("yyyy-MM-dd HH:mm:ss") : "";
                EndTime = data.EndTime > DateTime.MinValue ? data.EndTime.ToString("yyyy-MM-dd HH:mm:ss") : "";
                AddTime = data.AddTimeDesc;
                AddUserMan = data.AddUserMan;
                RequestContent = data.RequestContent;
                ApproveTime = data.ApproveTimeDesc;
                ApproveUserMan = data.ApproveUserMan;
                status = data.Status;
                ApproveStatusDesc = data.StatusDesc;
            }
            var form = new { ID = ID, guid = guid, StartTime = StartTime, EndTime = EndTime, AddTime = AddTime, AddUserMan = AddUserMan, RequestContent = RequestContent, ApproveTime = ApproveTime, ApproveUserMan = ApproveUserMan, currentsize = 0, maxsize = 500, status = status, ApproveStatusDesc = ApproveStatusDesc };
            WebUtil.WriteJsonResult(context, new { form = form });
        }
        private void getdiscountrequestlist(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            var uid = GetUID(context, out user);
            var list = Mall_BusinessDiscountRequest.GetMall_BusinessDiscountRequestByUserID(user.UserID);
            var items = list.Select(p =>
            {
                var item = new { StatusDesc = p.StatusDesc, Title = p.AddTimeDesc, Content = p.RequestContent, AddUserMan = p.AddUserMan, ID = p.ID, AddTime = p.AddTimeDesc, status = p.Status };
                return item;
            }).ToArray();
            WebUtil.WriteJsonResult(context, new { list = items });
        }
        private void savemydiscountrequest(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            var uid = GetUID(context, out user);
            int ID = WebUtil.GetIntValue(context, "ID");
            string guid = context.Request["guid"];
            var discount_product_list = Mall_BusinessDiscountRequest_ProductDetail.GetMall_BusinessDiscountRequest_ProductDetailListByBusinessDiscountRequestID(ID, guid);
            if (discount_product_list.Length == 0)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "请选择商品");
                return;
            }
            string StartTimeStr = context.Request["StartTime"].Replace("T", " ");
            string EndTimeStr = context.Request["EndTime"].Replace("T", " ");

            string content = context.Request["content"];
            Mall_BusinessDiscountRequest data = null;
            if (ID > 0)
            {
                data = Mall_BusinessDiscountRequest.GetMall_BusinessDiscountRequest(ID);
            }
            if (data == null)
            {
                data = new Mall_BusinessDiscountRequest();
                data.AddTime = DateTime.Now;
                data.AddUserMan = user.LoginName;
            }
            data.UserID = user.UserID;
            var business = Mall_Business.GetMall_BusinessByUserID(user.UserID);
            data.BusinessID = business.ID;
            data.RequestContent = content;
            data.Status = 1;
            data.StartTime = WebUtil.GetDateTimeByStr(StartTimeStr);
            data.EndTime = WebUtil.GetDateTimeByStr(EndTimeStr);
            data.IsActive = true;
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    data.Save(helper);
                    foreach (var item in discount_product_list)
                    {
                        item.BusinessDiscountRequestID = data.ID;
                        item.Save(helper);
                    }
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError(LogModuel, "savemydiscountrequest", ex);
                    WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "服务器内部异常");
                    return;
                }
            }
            WebUtil.WriteJsonResult(context, "Success");
        }
        private void getmsgdetail(HttpContext context)
        {
            var uid = GetUID(context);
            int ID = WebUtil.GetIntValue(context, "ID");
            var data = Foresight.DataAccess.Wechat_Msg.GetWechat_Msg(ID);
            if (data == null)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "该消息不存在");
                return;
            }
            var item = new
            {
                ID = data.ID,
                Title = data.MsgTitle,
                Content = data.HTMLContent,
            };
            WebUtil.WriteJsonResult(context, item);
        }
        private void getmsglist(HttpContext context)
        {
            var uid = GetUID(context);
            string pageindex = context.Request.Form["pageindex"];
            string pagesize = context.Request.Form["pagesize"];
            long startRowIndex = long.Parse(pageindex);
            int pageSize = int.Parse(pagesize);
            long totals = 0;
            var list = Foresight.DataAccess.Wechat_Msg.GetWechat_MsgListByMsgType(string.Empty, startRowIndex, pageSize, out totals, IsBusinessAPPSend: true, UserID: uid);
            var items = list.Select(p =>
            {
                string Summary = string.IsNullOrEmpty(p.MsgSummary) ? "暂无详细说明" : p.MsgSummary;
                string AddTime = p.PublishTime == DateTime.MinValue ? p.AddTime.ToString("yyyy-MM-dd") : p.PublishTime.ToString("yyyy-MM-dd");
                string ImgUrl = string.IsNullOrEmpty(p.PicPath) ? "../image/message.png" : WebUtil.GetContextPath() + p.PicPath;
                var item = new { ID = p.ID, ImgUrl = ImgUrl, Title = p.MsgTitle, Summary = Summary, AddTime = AddTime, MsgType = p.MsgTypeDesc };
                return item;
            });
            WebUtil.WriteJsonResult(context, new { tongzhilist = items });
        }
        private void savedeviceid(HttpContext context)
        {
            var uid = GetUID(context);
            var user = Foresight.DataAccess.User.GetUser(uid);
            string DeviceId = context.Request["device_id"];
            string DeviceType = context.Request["device_type"];
            if (!string.IsNullOrEmpty(DeviceId))
            {
                user.APPBusinessDeviceID = DeviceId;
                user.APPBusinessDeviceType = DeviceType;
                user.Save();
            }
            WebUtil.WriteJsonResult(context, "保存成功");
        }
        private void postmallchatcontent(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            int ID = WebUtil.GetIntValue(context, "id");
            string Content = context.Request["content"];
            if (string.IsNullOrEmpty(Content))
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "消息不能为空");
                return;
            }
            var list = Mall_ChatSensitive.GetMall_ChatSensitiveListByKeywords(Content);
            if (list.Length > 0)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "您输入的消息含有敏感关键字");
                return;
            }
            var data = new Mall_ChatMessage();
            data.AddTime = DateTime.Now;
            data.ChatID = ID;
            data.ChatType = 2;
            data.ChatContent = Content;
            data.UserID = uid;
            data.AddUserName = user.LoginName;
            data.Save();
            WebUtil.WriteJsonResult(context, "Success");
        }
        private void getmallchatdetaillist(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            int ID = WebUtil.GetIntValue(context, "id");
            var chat_title = Mall_ChatTitle.GetMall_ChatTitle(ID);
            var buyer = Foresight.DataAccess.User.GetUser(chat_title.FromUserID);
            if (buyer == null)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "用户已删除");
                return;
            }
            var list = Mall_ChatMessage.GetMall_ChatMessageListByBusinesChatID(ID, onlyTotay: true);
            string seller_headimage = string.IsNullOrEmpty(user.HeadImg) ? "../image/error-img.png" : WebUtil.GetContextPath() + user.HeadImg;
            string buyer_headimage = string.IsNullOrEmpty(buyer.HeadImg) ? "../image/error-img.png" : WebUtil.GetContextPath() + buyer.HeadImg;
            List<Dictionary<string, object>> items = new List<Dictionary<string, object>>();
            var orderby_list = list.GroupBy(p => p.AddTime.ToString("yyyy-MM-dd HH:mm")).Select(p => (new { name = p.Key, count = p.Count() })).ToArray();
            foreach (var item in orderby_list)
            {
                var my_list = list.Where(p => p.AddTime.ToString("yyyy-MM-dd HH:mm").Equals(item.name)).ToArray();
                var dic = new Dictionary<string, object>();
                dic["addtime"] = item.name;
                dic["list"] = my_list.Select(p =>
                {
                    string css = p.ChatType == 1 ? "aui-chat-left" : "aui-chat-right";
                    string headimage = p.ChatType == 1 ? buyer_headimage : seller_headimage;
                    string nickname = p.ChatType == 1 ? buyer.NickName : "我";
                    nickname = string.IsNullOrEmpty(nickname) ? "匿名" : nickname;
                    var my_item = new { id = p.ID, headimage = headimage, css = css, nickname = nickname, msgcontent = p.ChatContent };
                    return my_item;
                });
                items.Add(dic);
            }
            var unread_list = list.Where(p => p.UserReadTime == DateTime.MinValue).ToArray();
            if (unread_list.Length > 0)
            {
                using (SqlHelper helper = new SqlHelper())
                {
                    try
                    {
                        helper.BeginTransaction();
                        foreach (var item in unread_list)
                        {
                            item.UserReadTime = DateTime.Now;
                            item.Save(helper);
                        }
                        helper.Commit();
                    }
                    catch (Exception ex)
                    {
                        helper.Rollback();
                        LogHelper.WriteError(LogModuel, "getmallchatdetaillist", ex);
                    }
                }
            }
            WebUtil.WriteJsonResult(context, new { list = items });
        }
        private void getmallchattitlelist(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            var list = Mall_ChatTitleDetail.GetMall_ChatTitleDetailListByBusinesUserID(uid);
            var items = list.Select(p =>
            {
                string HeadImage = string.IsNullOrEmpty(p.HeadImage) ? "../image/error-img.png" : WebUtil.GetContextPath() + p.HeadImage;
                string addtime = p.AddTime.Day == DateTime.Now.Day ? p.AddTime.ToString("HH:mm") : p.AddTime.ToString("yyyy-MM-dd HH:mm");
                string nickname = string.IsNullOrEmpty(p.NickName) ? "匿名" : p.NickName;
                string LastMessage = p.LastMessage.Length > 10 ? p.LastMessage.Substring(0, 10) + "..." : p.LastMessage;
                var item = new { id = p.ID, HeadImage = HeadImage, lastmsg = LastMessage, addtime = addtime, nickname = nickname, UnreadCount = p.UnreadCount > 0 ? p.UnreadCount : 0 };
                return item;
            });
            WebUtil.WriteJsonResult(context, new { list = items });
        }
        private void getmallcustomerstatics(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            int minday = WebUtil.GetIntValue(context, "minday");
            int maxday = WebUtil.GetIntValue(context, "maxday");
            var order_list = Mall_Order.GetMall_OrderListByBusinesUserID(uid, minday, maxday);
            var shoppingcart_list = Mall_ShoppingCart.GetMall_ShoppingCartListByBusinessUserID(uid, minday, maxday);
            int TotalUserCount = 0;
            decimal BuyUnitPrice = 0;
            int NewBuyCount = 0;
            int BackBuyCount = 0;
            string BackBuyPercent = "0%";
            int PotentialCount = 0;
            if (order_list.Length > 0)
            {
                var my_order_list = order_list.GroupBy(p => p.UserID).Select(p => (new { name = p.Key, count = p.Count() })).ToArray();
                TotalUserCount = my_order_list.Length;
                NewBuyCount = my_order_list.Where(p => p.count == 1).ToArray().Length;
                BackBuyCount = my_order_list.Where(p => p.count > 1).ToArray().Length;
                BackBuyPercent = TotalUserCount > 0 ? Math.Round(((decimal)100 * BackBuyCount / TotalUserCount), 2, MidpointRounding.AwayFromZero).ToString("0.00") + "%" : "0.00";
                var order_items = Mall_OrderItem.GetAnalysisMall_OrderItemListByOrderIDList(order_list.Select(p => p.ID).ToList());
                int TotalQuantity = order_items.Sum(p => p.Quantity);
                decimal TotalCost = order_list.Sum(p => p.TotalCost);
                BuyUnitPrice = TotalQuantity > 0 ? Math.Round((TotalCost / TotalQuantity), 2, MidpointRounding.AwayFromZero) : 0;
            }
            if (shoppingcart_list.Length > 0)
            {
                var my_shoppingcart_list = shoppingcart_list.GroupBy(p => p.UserID).ToArray();
                PotentialCount = my_shoppingcart_list.Length;
            }
            List<Dictionary<string, object>> customerlist = new List<Dictionary<string, object>>();
            for (int i = 1; i < 4; i++)
            {
                var dic = new Dictionary<string, object>();
                string title = string.Empty;
                string value = string.Empty;
                if (i == 1)
                {
                    title = "客户总数";
                    value = TotalUserCount.ToString("0");
                }
                else if (i == 2)
                {
                    title = "回头率";
                    value = BackBuyPercent;
                }
                else if (i == 3)
                {
                    title = "客单价";
                    value = BuyUnitPrice.ToString("0.00");
                }
                dic["title"] = title;
                dic["index"] = i;
                dic["value"] = value;
                customerlist.Add(dic);
            }
            List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
            for (int i = 1; i < 4; i++)
            {
                var dic = new Dictionary<string, object>();
                string title = string.Empty;
                string value = string.Empty;
                string src = string.Empty;
                if (i == 1)
                {
                    title = "潜在客户";
                    value = PotentialCount.ToString("0");
                    src = "../image/customer_maybe_icon.png";
                }
                else if (i == 2)
                {
                    title = "新增客户";
                    value = NewBuyCount.ToString("0");
                    src = "../image/customer_new_icon.png";
                }
                else if (i == 3)
                {
                    title = "回头客";
                    value = BackBuyCount.ToString("0");
                    src = "../image/customer_return_icon.png";
                }
                dic["title"] = title;
                dic["index"] = i;
                dic["value"] = value;
                dic["src"] = src;
                list.Add(dic);
            }
            WebUtil.WriteJsonResult(context, new { customerlist = customerlist, list = list });
        }
        private void completemyorder(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            int ID = WebUtil.GetIntValue(context, "id");
            var order = Foresight.DataAccess.Mall_Order.GetMall_Order(ID);
            if (order == null)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "非法请求");
                return;
            }
            if (order.OrderStatus != 3)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "订单状态不允许此操作");
                return;
            }
            order.BusinessCompleteTime = DateTime.Now;
            order.Save();
            WebUtil.WriteJsonResult(context, "Success");
        }
        private void saveorderdelivery(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            int orderid = WebUtil.GetIntValue(context, "ID");
            var order = Foresight.DataAccess.Mall_Order.GetMall_Order(orderid);
            if (order == null)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "非法请求");
                return;
            }
            if (order.OrderStatus != 5)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "订单状态不允许此操作");
                return;
            }
            string ShipTimeStr = context.Request["ShipTime"].Replace("T", " ");
            order.OrderStatus = 2;
            order.ShipCompanyName = context.Request["ShipCompanyName"];
            order.ShipTime = WebUtil.GetDateTimeByStr(ShipTimeStr);
            order.ShipUserName = user.LoginName;
            order.ShipTrackNo = context.Request["ShipTrackNo"];
            order.ShipRemark = context.Request["Remark"];
            order.Save();
            WebUtil.WriteJsonResult(context, new { id = order.ID, status = order.OrderStatus });
        }
        private void getmallorderdetail(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            int orderid = WebUtil.GetIntValue(context, "ID");
            var order = Foresight.DataAccess.Mall_Order.GetMall_Order(orderid);
            if (order == null)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "非法请求");
                return;
            }
            if (order.OrderStatus != 5)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "订单状态不允许此操作");
                return;
            }
            WebUtil.WriteJsonResult(context, new { id = order.ID, status = order.OrderStatus });
        }
        private void closemyorder(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            int ID = WebUtil.GetIntValue(context, "id");
            var order = Foresight.DataAccess.Mall_Order.GetMall_Order(ID);
            if (order == null)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "非法请求");
                return;
            }
            if (order.OrderStatus != 1)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "订单状态不允许此操作");
                return;
            }
            order.IsClosed = true;
            order.CloseTime = DateTime.Now;
            order.CloseUserName = user.LoginName;
            order.Save();
            WebUtil.WriteJsonResult(context, "Success");
        }
        private void getmyorderlist(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            int status = WebUtil.GetIntValue(context, "status");
            string pageindex = context.Request.Form["pageindex"];
            string pagesize = context.Request.Form["pagesize"];
            long startRowIndex = long.Parse(pageindex);
            int pageSize = int.Parse(pagesize);
            string keywords = context.Request["keywords"];
            long totals = 0;
            var order_list = Foresight.DataAccess.Mall_Order.GetBusinessMall_OrderListByStatus(status, startRowIndex, pageSize, out totals, UserID: uid, keywords: keywords);
            var order_items_list = Foresight.DataAccess.Mall_OrderItem.GetMall_OrderItemListByOrderIDList(order_list.Select(p => p.ID).ToList());
            var product_list = Foresight.DataAccess.Mall_Product.GetMall_ProductListByIDList(order_items_list.Select(p => p.ProductID).ToList());
            var items = order_list.Select(p =>
            {
                bool canship = false;
                if (p.OrderStatus == 5 && !p.IsClosed)
                {
                    canship = true;
                }
                bool canrefund = false;
                if (p.OrderStatus == 6 && !p.IsClosed)
                {
                    canrefund = true;
                }
                bool cancomplete = false;
                if (p.OrderStatus == 3 && !p.IsClosed && p.BusinessCompleteTime == DateTime.MinValue)
                {
                    cancomplete = true;
                }
                bool canclose = false;
                if ((p.OrderStatus == 1 || p.OrderStatus == 7) && !p.IsClosed)
                {
                    canclose = true;
                }
                bool candelete = false;
                if (p.IsClosed)
                {
                    candelete = true;
                }
                var my_order_items = order_items_list.Where(q => q.OrderID == p.ID).ToArray();
                var productlist = my_order_items.Select(q =>
                {
                    var my_product = product_list.FirstOrDefault(o => o.ID == q.ProductID);
                    string imageurl = "../image/error-img.png";
                    if (my_product != null)
                    {
                        imageurl = !string.IsNullOrEmpty(my_product.CoverImage) ? WebUtil.GetContextPath() + my_product.CoverImage : imageurl;
                    }
                    if (p.ProductTypeID == 10)
                    {
                        imageurl = "../image/icons/wuyejiaofei_order.png";
                    }
                    var product_item = new { id = q.ID, productid = q.ProductID, variantid = q.VariantID, imageurl = imageurl, title = q.ProductTitle, desc = q.ProductSubTitle, price = "￥" + q.Price.ToString("0.00"), quantity = "x" + q.Quantity.ToString(), producttypeid = q.ProductTypeID, orderid = q.OrderID };
                    return product_item;
                }).ToList();
                var productsummary = new { totaldesc = "共" + productlist.Count + "件商品", totalprice = p.TotalCost };
                var ordersummary = new { id = p.ID, status = p.OrderStatus, ordernumber = p.OrderNumber, ordertime = p.AddTime.ToString("yyyy-MM-dd HH:mm:ss"), producttypeid = p.ProductTypeID, statusdesc = p.OrderStatusDesc, canship = canship, canrefund = canrefund, cancomplete = cancomplete, canclose = canclose, candelete = candelete };
                var item = new { productlist = productlist, productsummary = productsummary, ordersummary = ordersummary };
                return item;
            });
            WebUtil.WriteJsonResult(context, new { list = items });
        }
        private void getproductcategorylist(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            var categorylist = Foresight.DataAccess.Mall_Category.GetMall_Categories().Where(p => p.CategoryType.Equals(Utility.EnumModel.Mall_CategoryTypeDefine.productcategory.ToString())).OrderBy(p => p.SortOrder).ThenByDescending(p => p.AddTime).ToArray();
            var categoryitems = categorylist.Select(p =>
            {
                var item = new { id = p.ID, text = p.CategoryName, selected = "" };
                return item;
            });
            WebUtil.WriteJsonResult(context, new { categorylist = categoryitems });
        }
        private void savebusinessproductcategory(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            List<int> ProductIDList = JsonConvert.DeserializeObject<List<int>>(context.Request["IDList"]);
            List<int> CategoryIDList = JsonConvert.DeserializeObject<List<int>>(context.Request["CategoryIDList"]);
            if (CategoryIDList.Count > 0 && ProductIDList.Count > 0)
            {
                string cmdtext = "delete from [Mall_Product_Category] where [ProductID] in (" + string.Join(",", ProductIDList.ToArray()) + ");";
                foreach (var ProductID in ProductIDList)
                {
                    foreach (var CategoryID in CategoryIDList)
                    {
                        cmdtext += "insert into [Mall_Product_Category] ([ProductID],[CategoryID]) values (" + ProductID + "," + CategoryID + ");";
                    }
                }
                using (SqlHelper helper = new SqlHelper())
                {
                    try
                    {
                        helper.BeginTransaction();
                        var parameters = new List<SqlParameter>();
                        helper.Execute(cmdtext, CommandType.Text, parameters);
                        helper.Commit();
                    }
                    catch (Exception ex)
                    {
                        helper.Rollback();
                        LogHelper.WriteError(LogModuel, "savebusinessproductcategory", ex);
                        WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, ex.Message);
                        return;
                    }
                }
            }
            WebUtil.WriteJsonResult(context, "Success");
        }
        private void offlinebusinessproduct(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            List<int> ProductIDList = JsonConvert.DeserializeObject<List<int>>(context.Request["IDList"]);
            if (ProductIDList.Count > 0)
            {
                using (SqlHelper helper = new SqlHelper())
                {
                    try
                    {
                        helper.BeginTransaction();
                        string cmdtext = "update [Mall_Product] set [Status]=2 where ID in (" + string.Join(",", ProductIDList.ToArray()) + ");";
                        var parameters = new List<SqlParameter>();
                        helper.Execute(cmdtext, CommandType.Text, parameters);
                        helper.Commit();
                    }
                    catch (Exception ex)
                    {
                        helper.Rollback();
                        LogHelper.WriteError(LogModuel, "offlinebusinessproduct", ex);
                        WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, ex.Message);
                        return;
                    }
                }
            }
            WebUtil.WriteJsonResult(context, "Success");
        }
        private void removebusinessproduct(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            int ID = WebUtil.GetIntValue(context, "ID");
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    string cmdtext = "delete from [Mall_Product] where [Status]=2 ID=@ID;";
                    cmdtext += "delete from [Mall_Product_Category] where ProductID=@ID;";
                    cmdtext += "delete from [Mall_Product_Picture] where ProductID=@ID;";
                    cmdtext += "delete from [Mall_ProductDesc] where ProductID=@ID;";
                    var parameters = new List<SqlParameter>();
                    parameters.Add(new SqlParameter("@ID", ID));
                    helper.Execute(cmdtext, CommandType.Text, parameters);
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError(LogModuel, "removebusinessproduct", ex);
                    WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, ex.Message);
                    return;
                }
            }
            WebUtil.WriteJsonResult(context, "Success");
        }
        private void removeproductdesc(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            int ID = WebUtil.GetIntValue(context, "ID");
            Mall_ProductDesc.DeleteMall_ProductDesc(ID);
            WebUtil.WriteJsonResult(context, "Success");
        }
        private void saveproductdescription(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            int ID = WebUtil.GetIntValue(context, "ID");
            string guid = context.Request["guid"];
            var list = Foresight.DataAccess.Mall_ProductDesc.GetMall_ProductDescListByProductID(ID, guid);
            List<Dictionary<string, object>> list_dic = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(context.Request["list"]);
            List<Mall_ProductDesc> desclist = new List<Mall_ProductDesc>();
            List<int> imageindexlist = JsonConvert.DeserializeObject<List<int>>(context.Request["imageindexs"]);
            List<string> imageurllist = new List<string>();
            HttpFileCollection uploadFiles = context.Request.Files;
            if (uploadFiles.Count > 0)
            {
                for (int i = 0; i < uploadFiles.Count; i++)
                {
                    HttpPostedFile postedFile = uploadFiles[i];
                    string fileOriName = postedFile.FileName;
                    if (fileOriName != "" && fileOriName != null)
                    {
                        string extension = System.IO.Path.GetExtension(fileOriName).ToLower();
                        string fileNameWithOutExtenSion = DateTime.Now.ToFileTime().ToString();
                        string fileName = fileNameWithOutExtenSion + extension;
                        string filepath = "/upload/Product/";
                        string rootPath = HttpContext.Current.Server.MapPath("~" + filepath);
                        if (!System.IO.Directory.Exists(rootPath))
                        {
                            System.IO.Directory.CreateDirectory(rootPath);
                        }
                        string Path = rootPath + fileName;
                        postedFile.SaveAs(Path);
                        imageurllist.Add(filepath + fileName);
                    }
                }
            }
            int index = 0;
            foreach (var dic in list_dic)
            {
                int descid = 0;
                int.TryParse(dic["id"].ToString(), out descid);
                var data = list.FirstOrDefault(p => p.ID == descid);
                if (data == null)
                {
                    data = new Mall_ProductDesc();
                    data.ProductID = ID;
                    data.GUID = guid;
                    data.AddTime = DateTime.Now;
                    data.AddMan = user.LoginName;
                    data.Type = dic["type"].ToString();
                    if (data.Type.Equals("image"))
                    {
                        var imageindex = imageindexlist.IndexOf(index);
                        if (imageindex > -1)
                        {
                            data.ImageUrl = imageurllist[imageindex];
                        }
                    }
                }
                data.SortOrder = index;
                if (data.Type.Equals("text"))
                {
                    data.TextContent = dic["content"].ToString();
                }
                desclist.Add(data);
                index++;
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    foreach (var item in desclist)
                    {
                        item.Save(helper);
                    }
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError(LogModuel, "saveproductdescription", ex);
                    WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, ex.Message);
                    return;
                }
            }
            WebUtil.WriteJsonResult(context, "Success");
        }
        private void getproductdescription(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            int ID = WebUtil.GetIntValue(context, "ID");
            string guid = context.Request["guid"];
            var list = Foresight.DataAccess.Mall_ProductDesc.GetMall_ProductDescListByProductID(ID, guid);
            var items = list.Select(p =>
            {
                string content = p.TextContent;
                if (p.Type.Equals("image"))
                {
                    content = WebUtil.GetContextPath() + p.ImageUrl;
                }
                var item = new { id = p.ID, content = content, type = p.Type };
                return item;
            });
            WebUtil.WriteJsonResult(context, new { list = items });
        }
        private void removeproductimage(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            int ID = WebUtil.GetIntValue(context, "ID");
            Mall_Product_Picture.DeleteMall_Product_Picture(ID);
            WebUtil.WriteJsonResult(context, "Success");
        }
        private void savebusinessproduct(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            var business = Foresight.DataAccess.Mall_Business.GetMall_BusinessByUserID(uid);
            int ID = WebUtil.GetIntValue(context, "ID");
            string guid = context.Request["guid"];
            Foresight.DataAccess.Mall_Product data = null;
            if (ID > 0)
            {
                data = Mall_Product.GetMall_Product(ID);
            }
            if (data == null)
            {
                data = new Mall_Product();
                data.AddTime = DateTime.Now;
                data.AddMan = user.LoginName;
            }
            data.IsZiYing = false;
            data.ProductName = context.Request["ProductName"];
            data.BusinessID = business.ID;
            data.TotalCount = WebUtil.GetIntValue(context, "Inventory");
            data.SalePrice = WebUtil.GetDecimalValue(context, "Price");
            data.ModelNumber = context.Request["ModelNumber"];
            data.Status = 3;
            data.ProductTypeID = 1;
            data.Unit = context.Request["Unit"];
            data.IsShowOnHome = false;
            data.QuantityLimit = 0;
            data.SortOrder = 1;
            data.IsSuggestion = false;
            data.IsYouXuan = false;
            data.ShipRateID = 0;
            data.ShipRateType = 0;
            data.IsAllowProductBuy = true;
            data.IsAllowPointBuy = false;
            data.IsAllowVIPBuy = false;
            data.IsAllowStaffBuy = false;

            List<int> CategoryIDList = JsonConvert.DeserializeObject<List<int>>(context.Request["CategoryIDList"]);
            List<Mall_Product_Category> categorylist = new List<Mall_Product_Category>();
            foreach (var CategoryID in CategoryIDList)
            {
                var category = new Mall_Product_Category();
                category.CategoryID = CategoryID;
                categorylist.Add(category);
            }
            List<Mall_Product_Picture> attachlist = new List<Mall_Product_Picture>();
            HttpFileCollection uploadFiles = context.Request.Files;
            if (uploadFiles.Count > 0)
            {
                for (int i = 0; i < uploadFiles.Count; i++)
                {
                    HttpPostedFile postedFile = uploadFiles[i];
                    string fileOriName = postedFile.FileName;
                    if (fileOriName != "" && fileOriName != null)
                    {
                        string extension = System.IO.Path.GetExtension(fileOriName).ToLower();
                        string fileNameWithOutExtenSion = DateTime.Now.ToFileTime().ToString();
                        string fileName = fileNameWithOutExtenSion + extension;
                        string filepath = "/upload/Product/";
                        string rootPath = HttpContext.Current.Server.MapPath("~" + filepath);
                        if (!System.IO.Directory.Exists(rootPath))
                        {
                            System.IO.Directory.CreateDirectory(rootPath);
                        }
                        string Path = rootPath + fileName;
                        postedFile.SaveAs(Path);
                        Foresight.DataAccess.Mall_Product_Picture attach = new Foresight.DataAccess.Mall_Product_Picture();
                        System.Drawing.Image img = System.Drawing.Image.FromFile(Path);
                        attach.AddTime = DateTime.Now;
                        attach.AddMan = user.LoginName;
                        string IconPicPath = WebUtil.CreatThumbnail(img, System.IO.Path.Combine(rootPath, string.Format("{0}\\{1}.jpg", "icon", fileNameWithOutExtenSion)), 180, 320);
                        string MediumPicPath = WebUtil.CreatThumbnail(img, System.IO.Path.Combine(rootPath, string.Format("{0}\\{1}.jpg", "medium", fileNameWithOutExtenSion)), 540, 960);
                        string LargePicPath = WebUtil.CreatThumbnail(img, System.IO.Path.Combine(rootPath, string.Format("{0}\\{1}.jpg", "large", fileNameWithOutExtenSion)), 0, 0);
                        attach.IconPicPath = IconPicPath.Replace(rootPath, "\\" + filepath).Replace("\\", "/");
                        attach.MediumPicPath = MediumPicPath.Replace(rootPath, "\\" + filepath).Replace("\\", "/");
                        attach.LargePicPath = LargePicPath.Replace(rootPath, "\\" + filepath).Replace("\\", "/");
                        attachlist.Add(attach);
                        if (i == 0)
                        {
                            data.CoverImage = filepath + fileName;
                        }
                    }
                }
            }
            var desclist = Foresight.DataAccess.Mall_ProductDesc.GetMall_ProductDescListByProductID(ID, guid);
            string desc = string.Empty;
            foreach (var item in desclist)
            {
                if (item.Type.Equals("text"))
                {
                    desc += "<p>" + item.TextContent.Replace("\r\n", "<br/>") + "</p>";
                    continue;
                }
                if (item.Type.Equals("image"))
                {
                    desc += "<p><img src=\"" + WebUtil.GetContextPath() + item.ImageUrl + "\" /></p>";
                    continue;
                }
            }
            data.Description = desc;

            var variant_list = Mall_Product_Variant.GetMall_Product_VariantListByProductID(data.ID, GUID: guid);
            var default_variant = Mall_Product_Variant.GetDefaultMall_Product_VarianByProductID(data.ID);
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    data.Save(helper);
                    var parameters = new List<SqlParameter>();
                    parameters.Add(new SqlParameter("@ProductID", data.ID));
                    helper.Execute("delete from [Mall_Product_Category] where ProductID=@ProductID", CommandType.Text, parameters);
                    foreach (var item in categorylist)
                    {
                        item.ProductID = data.ID;
                        item.Save(helper);
                    }
                    foreach (var item in attachlist)
                    {
                        item.ProductID = data.ID;
                        item.Save(helper);
                    }
                    foreach (var item in desclist)
                    {
                        item.ProductID = data.ID;
                        item.Save(helper);
                    }
                    foreach (var item in variant_list)
                    {
                        item.ProductID = data.ID;
                        item.Save(helper);
                    }
                    if (variant_list.Length > 0)
                    {
                        if (default_variant != null)
                        {
                            default_variant.Delete(helper);
                        }
                    }
                    else
                    {
                        if (default_variant == null)
                        {
                            default_variant = new Mall_Product_Variant();
                            default_variant.AddMan = user.LoginName;
                            default_variant.AddTime = DateTime.Now;
                            default_variant.VariantTitle = "规格";
                            default_variant.ProductID = data.ID;
                        }
                        default_variant.IsDefault = true;
                        default_variant.VariantName = "默认";
                        default_variant.Inventory = data.TotalCount;
                        default_variant.VariantPrice = data.SalePrice;
                        default_variant.VariantPoint = 0;
                        default_variant.VariantPointPrice = 0;
                        default_variant.VariantVIPPrice = 0;
                        default_variant.VariantVIPPoint = 0;
                        default_variant.VariantStaffPrice = 0;
                        default_variant.VariantStaffPoint = 0;
                        default_variant.Save(helper);
                    }
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError(LogModuel, "savebusinessproduct", ex);
                    WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, ex.Message);
                    return;
                }
            }
            WebUtil.WriteJsonResult(context, new { ID = data.ID });
        }
        private void getmallproductdetail(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            int ID = WebUtil.GetIntValue(context, "ID");
            Foresight.DataAccess.Mall_Product data = null;
            if (ID > 0)
            {
                data = Mall_Product.GetMall_Product(ID);
            }
            var categorylist = Foresight.DataAccess.Mall_Category.GetMall_Categories().Where(p => p.CategoryType.Equals(Utility.EnumModel.Mall_CategoryTypeDefine.productcategory.ToString())).OrderBy(p => p.SortOrder).ThenByDescending(p => p.AddTime).ToArray();
            var categoryitems = categorylist.Select(p =>
            {
                var item = new { id = p.ID, text = p.CategoryName, selected = "" };
                return item;
            });
            if (data == null)
            {
                string guid = System.Guid.NewGuid().ToString();
                WebUtil.WriteJsonResult(context, new { guid = guid, categorylist = categoryitems });
                return;
            }
            var productcategory = Foresight.DataAccess.Mall_Category.GetMall_CategoryListByProductID(data.ID);
            var CategoryIDList = productcategory.Select(p => p.ID).ToArray();
            string CategoryNames = string.Join(",", productcategory.Select(p => p.CategoryName).ToArray());
            bool canpost = true;
            string errormsg = "提交";
            if (data.Status == 3)
            {
                canpost = false;
                errormsg = "审核中";
            }
            if (data.Status == 4)
            {
                canpost = false;
                errormsg = "重新提交";
            }
            var variant_list = Mall_Product_Variant.GetMall_Product_VariantListByProductID(data.ID);
            bool mutipleprice = variant_list.Length > 0;
            string VariantTitle = string.Empty;
            if (variant_list.Length > 0)
            {
                VariantTitle = !string.IsNullOrEmpty(variant_list[0].VariantTitle) ? variant_list[0].VariantTitle : "规格";
            }
            var form = new { ID = data.ID, ProductName = data.ProductName, ModelNumber = data.ModelNumber, Unit = data.Unit, CategoryNames = CategoryNames, Price = data.SalePrice, Inventory = data.TotalCount, canpost = canpost, errormsg = errormsg, status = data.Status, approveremark = data.ApproveRemark, guid = "", CategoryIDList = CategoryIDList, statusdesc = data.StatusDesc, mutipleprice = mutipleprice, VariantTitle = VariantTitle };

            var imagelist = Foresight.DataAccess.Mall_Product_Picture.GetMall_Product_PictureListByID(data.ID);
            int count = 0;
            var imageitems = imagelist.Select(p =>
            {
                var item = new { id = p.ID, url = WebUtil.GetContextPath() + p.IconPicPath, index = count };
                count++;
                return item;
            });
            WebUtil.WriteJsonResult(context, new { form = form, categorylist = categoryitems, productimglist = imageitems, productimgindex = count, });
        }
        private void getmallbusinesshomesource(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            var data = Foresight.DataAccess.Mall_Business.GetMall_BusinessByUserID(uid);
            string categoryname = data == null ? "福顺居" : data.BusinessName;
            string address = data == null ? data.ShortAddress : data.BusinessAddress;
            string logourl = data == null ? string.Empty : WebUtil.GetContextPath() + data.CoverImage;
            //滑动图片
            var imagelist = Foresight.DataAccess.Mall_RotatingImage.GetMall_RotatingImageListByType(4);
            var imageitems = imagelist.Select(p =>
            {
                int productid = 0;
                if (p.URLLinkType == 1 && p.URLLinkID > 0)
                {
                    productid = p.URLLinkID;
                }
                var item = new { ID = p.ID, imageurl = WebUtil.GetContextPath() + p.ImagePath, productid = productid };
                return item;
            });
            WebUtil.WriteJsonResult(context, new { categoryname = categoryname, imagelist = imageitems, address = address, logourl = logourl });
        }
        private void getbusinessproductlist(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            int sortby = WebUtil.GetIntValue(context, "sortby");
            int status = WebUtil.GetIntValue(context, "status");
            string pageindex = context.Request.Form["pageindex"];
            string pagesize = context.Request.Form["pagesize"];
            long startRowIndex = long.Parse(pageindex);
            int pageSize = int.Parse(pagesize);
            long totals = 0;
            var list = Foresight.DataAccess.Mall_ProductDetail.GetBusinessMall_ProductDetailListByUID(uid, sortby, startRowIndex, pageSize, out totals, status, ProductTypeID: 1);
            int ID = WebUtil.GetIntValue(context, "ID");
            string guid = context.Request["guid"];
            var discount_product_list = new Mall_BusinessDiscountRequest_Product[] { };
            if (!string.IsNullOrEmpty(guid))
            {
                discount_product_list = Mall_BusinessDiscountRequest_Product.GetMall_BusinessDiscountRequest_ProductListByBusinessDiscountRequestID(ID, guid);
            }
            var ProductIDList = list.Select(p => p.ID).ToList();
            var items = list.Select(p =>
            {
                string imageurl = string.IsNullOrEmpty(p.CoverImage) ? "../image/error-img.png" : WebUtil.GetContextPath() + p.CoverImage;
                int salecount = (p.SaleCount > 0 ? p.SaleCount : 0);
                decimal saleamount = (p.SaleAmount > 0 ? p.SaleAmount : 0);
                int inventory = (p.Inventory > 0 ? p.Inventory : 0);
                var my_discount_product = discount_product_list.FirstOrDefault(q => q.ProductID == p.ID);
                bool selected = my_discount_product != null;
                var item = new { id = p.ID, title = p.ProductName, price = p.PriceDesc, saledesc = p.SaleCountDesc, imageurl = imageurl, time = p.TimeDesc, salecount = salecount, saleamount = saleamount, inventory = inventory, addtime = p.AddTime.ToString("yyyy-MM-dd"), selected = selected };
                return item;
            }).ToArray();
            if (discount_product_list.Length > 0)
            {
                items = items.OrderBy(p => p.selected).ToArray();
            }
            WebUtil.WriteJsonResult(context, new { list = items });
        }
        private void getproductcount(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            var list = Foresight.DataAccess.Mall_Product.GetMall_ProductListByUserID(uid).Where(p => p.ProductTypeID == 1).ToArray();
            int salecount = list.Where(p => p.Status == 10).ToArray().Length;
            int offlinecount = list.Where(p => p.Status == 2).ToArray().Length;
            int approvecount = list.Where(p => p.Status == 3 || p.Status == 4).ToArray().Length;
            WebUtil.WriteJsonResult(context, new { salecount = salecount, offlinecount = offlinecount, approvecount = approvecount });
        }
        private void removebusinesscoverimg(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            var data = Foresight.DataAccess.Mall_Business.GetMall_Business(ID);
            if (data != null)
            {
                data.CoverImage = string.Empty;
                data.Save();
            }
            WebUtil.WriteJsonResult(context, "Success");
        }
        private void removebusinesspicture(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            var data = Foresight.DataAccess.Mall_Business_Picture.GetMall_Business_Picture(ID);
            if (data != null)
            {
                data.IconPicPath = string.Empty;
                data.MediumPicPath = string.Empty;
                data.LargePicPath = string.Empty;
                data.Save();
            }
            WebUtil.WriteJsonResult(context, "Success");
        }
        private void registercheckphone(HttpContext context)
        {
            int uid = 0;
            try
            {
                uid = GetUID(context);
            }
            catch (Exception)
            {
            }
            if (uid == 0)
            {
                try
                {
                    uid = GetUID(context, "tempuid");
                }
                catch (Exception)
                {
                }
            }
            string LoginName = context.Request["LoginName"];
            var user = Foresight.DataAccess.User.GetAPPUserByLoginName(LoginName, UserTypeDefine.APPBusiness.ToString());
            if (user != null && user.UserID != uid)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "当前手机号码已被使用");
                return;
            }

            Random rnd = new Random();
            string content = "验证码{0}，请在15分钟内按页面提示输入验证码，切勿将验证码泄露于他人。";
            string VerifyCode = Utility.Tools.SendVerifyCode(LoginName, content);
            Foresight.DataAccess.Wechat_VerifyCode.SaveWechatVerifyCode(LoginName, VerifyCode);
            WebUtil.WriteJsonResult(context, "Success");
        }
        private void getbusinessapplication(HttpContext context)
        {
            string DeviceID = context.Request["DeviceID"];
            int uid = 0;
            try
            {
                uid = GetUID(context);
            }
            catch (Exception)
            {
            }
            if (uid == 0)
            {
                try
                {
                    uid = GetUID(context, "tempuid");
                }
                catch (Exception)
                {
                }
            }
            var data = Foresight.DataAccess.Mall_Business.GetMall_BusinessByUserID(uid);
            if (data == null)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "您尚未提交申请");
                return;
            }
            string CategoryNames = string.Empty;
            List<int> CategoryIDList = new List<int>();
            var categorylist = Foresight.DataAccess.Mall_Category.GetMall_CategoryListByBusinessID(data.ID);
            if (categorylist.Length > 0)
            {
                CategoryNames = string.Join(",", categorylist.Select(p => p.CategoryName).ToArray());
                CategoryIDList = categorylist.Select(p => p.ID).ToList();
            }
            string Lon = string.Empty;
            string Lat = string.Empty;
            if (!string.IsNullOrEmpty(data.MapLocation))
            {
                var map_array = data.MapLocation.Split(',');
                if (map_array.Length == 2)
                {
                    Lon = map_array[0];
                    Lat = map_array[1];
                }
            }
            List<Dictionary<string, object>> coverimglist = new List<Dictionary<string, object>>();
            if (!string.IsNullOrEmpty(data.CoverImage))
            {
                var dic = new Dictionary<string, object>();
                dic["id"] = data.ID;
                dic["url"] = WebUtil.GetContextPath() + data.CoverImage;
                dic["index"] = 0;
                coverimglist.Add(dic);
            }
            int coverimgindex = coverimglist.Count;
            var filelist = Foresight.DataAccess.Mall_Business_Picture.GetMall_Business_PictureListByID(data.ID);
            int count = 0;
            var fileimglist = filelist.Select(p =>
            {
                count++;
                var item = new { id = p.ID, url = WebUtil.GetContextPath() + p.LargePicPath, index = count - 1 };
                return item;
            }).ToList();
            string LoginName = string.Empty;
            var user = Foresight.DataAccess.User.GetUser(uid);
            if (user != null)
            {
                LoginName = user.LoginName;
            }
            int fileimgindex = fileimglist.Count;
            bool canpost = true;
            string errormsg = "提交";
            if (data.Status == 10)
            {
                canpost = false;
                errormsg = "审核中";
            }
            if (data.Status == 2)
            {
                canpost = false;
                errormsg = "重新提交";
            }
            if (data.Status == 1)
            {
                canpost = false;
                errormsg = "审核通过";
            }
            var form = new { LoginName = LoginName, verifycode = "", codeissent = false, countdown = "", password = "", repassword = "", id = data.ID, BusinessName = data.BusinessName, BusinessAddress = data.BusinessAddress, ContactName = data.ContactName, CategoryNames = CategoryNames, CategoryIDList = CategoryIDList, Lon = Lon, Lat = Lat, canpost = canpost, errormsg = errormsg, status = data.Status, approveremark = data.ApproveRemark, Remark = data.Remark };
            WebUtil.WriteJsonResult(context, new { form = form, coverimglist = coverimglist, coverimgindex = coverimgindex, fileimglist = fileimglist, fileimgindex = fileimgindex });
        }
        private void savebusinessapplication(HttpContext context)
        {
            string DeviceID = context.Request["DeviceID"];
            int uid = 0;
            try
            {
                uid = GetUID(context);
            }
            catch (Exception)
            {
            }
            if (uid == 0)
            {
                try
                {
                    uid = GetUID(context, "tempuid");
                }
                catch (Exception)
                {
                }
            }
            var data = Foresight.DataAccess.Mall_Business.GetMall_BusinessByUserID(uid);
            if (data != null)
            {
                if (data.Status == 1)
                {
                    WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "您的信息已审核通过");
                    return;
                }
            }
            string LoginName = context.Request["LoginName"];
            var my_user = Foresight.DataAccess.User.GetAPPUserByLoginName(LoginName, UserTypeDefine.APPBusiness.ToString());
            if (my_user != null && my_user.UserID != uid)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "登录手机号已被使用");
                return;
            }
            string verifycode = context.Request["verifycode"];
            var wechatVerifyCode = Wechat_VerifyCode.GetWechat_VerifyCodeByUserOpenId(string.Empty, LoginName, DateTime.Now);
            if (wechatVerifyCode == null || !wechatVerifyCode.VerifyCode.Equals(verifycode))
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "验证码不正确");
                return;
            }
            string password = context.Request["password"];
            var user = Foresight.DataAccess.User.GetUser(uid);
            if (user == null)
            {
                user = new Foresight.DataAccess.User();
                user.CreateTime = DateTime.Now;
            }
            user.LoginName = LoginName;
            user.Password = User.EncryptPassword(password);
            user.PhoneNumber = LoginName;
            user.Type = UserTypeDefine.APPBusiness.ToString();
            user.IsLocked = false;
            if (data == null)
            {
                data = new Mall_Business();
                data.AddTime = DateTime.Now;
                data.DeviceID = DeviceID;
                data.UserID = uid;
            }
            data.BusinessName = context.Request["BusinessName"];
            data.BusinessAddress = context.Request["BusinessAddress"];
            data.ContactName = context.Request["ContactName"];
            data.ContactPhone = user.LoginName;
            data.Status = 10;
            data.Remark = context.Request["Remark"];
            string Lon = context.Request["Lon"];
            string Lat = context.Request["Lat"];
            if (!string.IsNullOrEmpty(Lon) && !string.IsNullOrEmpty(Lat))
            {
                data.MapLocation = Lon + "," + Lat;
            }
            List<Foresight.DataAccess.Mall_Business_Picture> attachlist = new List<Foresight.DataAccess.Mall_Business_Picture>();
            HttpFileCollection uploadFiles = context.Request.Files;
            if (uploadFiles.Count > 0)
            {
                for (int i = 0; i < uploadFiles.Count; i++)
                {
                    HttpPostedFile postedFile = uploadFiles[i];
                    string fileOriName = postedFile.FileName;
                    if (fileOriName != "" && fileOriName != null)
                    {
                        string extension = System.IO.Path.GetExtension(fileOriName).ToLower();
                        string fileNameWithOutExtenSion = DateTime.Now.ToFileTime().ToString();
                        string fileName = fileNameWithOutExtenSion + extension;
                        string filepath = "/upload/Business/";
                        string rootPath = HttpContext.Current.Server.MapPath("~" + filepath);
                        if (!System.IO.Directory.Exists(rootPath))
                        {
                            System.IO.Directory.CreateDirectory(rootPath);
                        }
                        string Path = rootPath + fileName;
                        postedFile.SaveAs(Path);
                        if (i == 0)
                        {
                            data.CoverImage = filepath + fileName;
                        }
                        else
                        {
                            Foresight.DataAccess.Mall_Business_Picture attach = new Foresight.DataAccess.Mall_Business_Picture();
                            System.Drawing.Image img = System.Drawing.Image.FromFile(Path);
                            attach.AddTime = DateTime.Now;
                            attach.AddMan = DeviceID;
                            string IconPicPath = WebUtil.CreatThumbnail(img, System.IO.Path.Combine(rootPath, string.Format("{0}\\{1}.jpg", "icon", fileNameWithOutExtenSion)), 180, 320);
                            string MediumPicPath = WebUtil.CreatThumbnail(img, System.IO.Path.Combine(rootPath, string.Format("{0}\\{1}.jpg", "medium", fileNameWithOutExtenSion)), 540, 960);
                            string LargePicPath = WebUtil.CreatThumbnail(img, System.IO.Path.Combine(rootPath, string.Format("{0}\\{1}.jpg", "large", fileNameWithOutExtenSion)), 0, 0);
                            attach.IconPicPath = IconPicPath.Replace(rootPath, "\\" + filepath).Replace("\\", "/");
                            attach.MediumPicPath = MediumPicPath.Replace(rootPath, "\\" + filepath).Replace("\\", "/");
                            attach.LargePicPath = LargePicPath.Replace(rootPath, "\\" + filepath).Replace("\\", "/");
                            attachlist.Add(attach);
                        }
                    }
                }
            }
            List<int> CategoryIDList = JsonConvert.DeserializeObject<List<int>>(context.Request["CategoryIDList"]);
            List<Mall_Business_Category> category_list = new List<Mall_Business_Category>();
            foreach (var CategoryID in CategoryIDList)
            {
                var category = new Mall_Business_Category();
                category.CategoryID = CategoryID;
                category_list.Add(category);
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    wechatVerifyCode.IsUsed = true;
                    wechatVerifyCode.Save(helper);
                    user.Save(helper);
                    data.UserID = user.UserID;
                    data.Save(helper);
                    foreach (var item in attachlist)
                    {
                        item.BusinessID = data.ID;
                        item.Save(helper);
                    }
                    string cmdtext = "delete from [Mall_Business_Category] where [BusinessID]=@BusinessID";
                    var parameters = new List<SqlParameter>();
                    parameters.Add(new SqlParameter("@BusinessID", data.ID));
                    helper.Execute(cmdtext, CommandType.Text, parameters);
                    foreach (var item in category_list)
                    {
                        item.BusinessID = data.ID;
                        item.Save(helper);
                    }
                    Mall_BusinessUser.Save_Mall_BusinessUser(data.ID, user.UserID, helper);
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError(LogModuel, "savebusinessapplication", ex);
                    WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, ex.Message);
                    return;
                }
            }
            WebUtil.WriteJsonResult(context, "Success");
        }
        private void getbusinesscategorylist(HttpContext context)
        {
            var list = Foresight.DataAccess.Mall_Category.GetMall_Categories().Where(p => p.CategoryType.Equals(Utility.EnumModel.Mall_CategoryTypeDefine.businesscategory.ToString()) && !p.IsDisabled).OrderBy(p => p.SortOrder).ThenByDescending(p => p.AddTime).ToArray();
            var items = list.Select(p =>
            {
                var item = new { id = p.ID, text = p.CategoryName, selected = "" };
                return item;
            });
            WebUtil.WriteJsonResult(context, new { servicelist = items });
        }
        private void getrotatingimages(HttpContext context)
        {
            int type = WebUtil.GetIntValue(context, "type");
            //滑动图片
            var imagelist = Foresight.DataAccess.Mall_RotatingImage.GetMall_RotatingImageListByType(type);
            var imageitems = imagelist.Select(p =>
            {
                int productid = 0;
                if (p.URLLinkType == 1 && p.URLLinkID > 0)
                {
                    productid = p.URLLinkID;
                }
                var item = new { ID = p.ID, imageurl = WebUtil.GetContextPath() + p.ImagePath, productid = productid };
                return item;
            });
            WebUtil.WriteJsonResult(context, new { imagelist = imageitems });
        }
        private void dologin(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            string LoginName = context.Request["Username"];
            string Password = context.Request["Password"];
            if (string.IsNullOrEmpty(LoginName))
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "用户名不能为空");
                return;
            }
            if (string.IsNullOrEmpty(Password))
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "密码不能为空");
                return;
            }
            user = Foresight.DataAccess.User.GetAPPUserByLoginNamePassWord(LoginName, Password, UserTypeDefine.APPBusiness.ToString());

            if (user == null)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "用户名或密码错误");
                return;
            }
            if (user.Type != UserTypeDefine.APPBusiness.ToString())
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "账号异常，登录失败");
                return;
            }
            if (user.IsLocked)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "帐号已被锁定,禁止登陆");
                return;
            }
            var business = Foresight.DataAccess.Mall_Business.GetMall_BusinessByUserID(user.UserID);
            if (business == null)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "非商户账号");
                return;
            }
            string DeviceId = context.Request["device_id"];
            string DeviceType = context.Request["device_type"];
            if (!string.IsNullOrEmpty(DeviceId))
            {
                user.APPBusinessDeviceID = DeviceId;
                user.APPBusinessDeviceType = DeviceType;
            }
            user.Save();
            var ticket = new System.Web.Security.FormsAuthenticationTicket(1, user.UserID.ToString(), DateTime.Now,
                       DateTime.Now.AddYears(1), true, string.Empty);
            var uid = System.Web.Security.FormsAuthentication.Encrypt(ticket);
            string headimg = string.IsNullOrEmpty(user.HeadImg) ? "" : WebUtil.GetContextPath() + user.HeadImg;
            string RealName = string.IsNullOrEmpty(user.NickName) ? "匿名用户" : user.NickName;
            WebUtil.WriteJsonResult(context, new { uid = uid, username = RealName, headimg = headimg, phonenumber = user.PhoneNumber, sex = user.Gender, status = business.Status });
        }
        private void checkloginstatus(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            WebUtil.WriteJsonResult(context, "Success");
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
        static int GetUID(HttpContext context, string key = "uid")
        {
            var uidStr = context.Request[key];
            if (!string.IsNullOrEmpty(uidStr))
            {
                var uid = 0;
                try
                {
                    var ticket = System.Web.Security.FormsAuthentication.Decrypt(uidStr);
                    uid = Convert.ToInt32(ticket.Name);
                }
                catch (Exception ex)
                {
                    throw new Exception("get_uid_failed", ex);
                }
                return uid;
            }
            else
            {
                throw new Exception("get_uid_failed");
            }
        }
        static int GetUID(HttpContext context, out Foresight.DataAccess.User user)
        {
            user = null;
            var uidStr = context.Request["uid"];
            if (!string.IsNullOrEmpty(uidStr))
            {
                int uid = 0;
                try
                {
                    var ticket = System.Web.Security.FormsAuthentication.Decrypt(uidStr);
                    uid = Convert.ToInt32(ticket.Name);
                }
                catch (Exception ex)
                {
                    throw new Exception("get_uid_failed", ex);
                }
                user = Foresight.DataAccess.User.GetUser(uid);
                if (user == null)
                {
                    throw new Exception("get_uid_failed");
                }
                var familyuidStr = context.Request["familyuid"];
                int familyuid = 0;
                if (!string.IsNullOrEmpty(familyuidStr))
                {
                    try
                    {
                        var ticket = System.Web.Security.FormsAuthentication.Decrypt(familyuidStr);
                        familyuid = Convert.ToInt32(ticket.Name);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("get_uid_failed", ex);
                    }
                    user = Foresight.DataAccess.User.GetUser(familyuid);
                    if (user == null)
                    {
                        throw new Exception("get_uid_failed");
                    }
                }
                return uid;
            }
            else
            {
                throw new Exception("get_uid_failed");
            }
        }
    }
}