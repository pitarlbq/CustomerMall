using Foresight.DataAccess;
using Foresight.DataAccess.Framework;
using Foresight.DataAccess.Ui;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.SessionState;
using Utility;

namespace Web.Handler
{
    /// <summary>
    /// PrintHandler 的摘要说明
    /// </summary>
    public class PrintHandler : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string visit = context.Request.Params["visit"];
            if (string.IsNullOrEmpty(visit))
            {
                LogHelper.WriteDebug("PrintHandler", "visit为空");
                context.Response.Write(null);
                return;
            }
            visit = visit.ToLower();
            try
            {
                switch (visit)
                {
                    case "loadprintfeeorder":
                        loadprintfeeorder(context);
                        break;
                    case "createcuishou":
                        createcuishou(context);
                        break;
                    case "loadprintckin":
                        loadprintckin(context);
                        break;
                    case "loadprintckout":
                        loadprintckout(context);
                        break;
                    case "loadprintcuifei":
                        loadprintcuifei(context);
                        break;
                    case "loadprintchargefee":
                        loadprintchargefee(context);
                        break;
                    case "loadtempprintchargefee":
                        loadtempprintchargefee(context);
                        break;
                    case "getprinthistorypagesize":
                        getprinthistorypagesize(context);
                        break;
                    case "getoffsetchargefeelist":
                        getoffsetchargefeelist(context);
                        break;
                    case "loadprintcontractcuifei":
                        loadprintcontractcuifei(context);
                        break;
                    case "loadmallorderprint":
                        loadmallorderprint(context);
                        break;
                    case "saveprintchequedata":
                        saveprintchequedata(context);
                        break;
                    case "checkprintchequestatus":
                        checkprintchequestatus(context);
                        break;
                    case "cancelguaranteefee":
                        cancelguaranteefee(context);
                        break;
                    case "chargepayservice":
                        chargepayservice(context);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("PrintHandler", "visit: " + visit, ex);
                context.Response.Write("{\"status\":false}");
            }
        }
        /// <summary>
        /// 付款单据
        /// </summary>
        /// <param name="context"></param>
        private void chargepayservice(HttpContext context)
        {
            int PrintID = WebUtil.GetIntValue(context, "PrintID");
            Foresight.DataAccess.PrintRoomFeeHistory printRoomFeeHistory = null;
            int PayServiceID = WebUtil.GetIntValue(context, "PayServiceID");
            var payservice = Foresight.DataAccess.PayService.GetPayService(PayServiceID);
            Foresight.DataAccess.PaySummary paysummary = null;
            if (payservice != null && payservice.PaySummaryID > 0)
            {
                if (payservice.PrintID > 0)
                {
                    PrintID = payservice.PrintID;
                }
                paysummary = Foresight.DataAccess.PaySummary.GetPaySummary(payservice.PaySummaryID);
            }
            if (PrintID > 0)
            {
                printRoomFeeHistory = Foresight.DataAccess.PrintRoomFeeHistory.GetPrintRoomFeeHistory(PrintID);
            }
            if (printRoomFeeHistory != null)
            {
                #region 支出登记付款单据打印日志
                APPCode.CommHelper.SaveOperationLog("订单号" + printRoomFeeHistory.PrintNumber + "支出登记付款单据打印", Utility.EnumModel.OperationModule.PayServicePayBack.ToString(), "支出登记付款单据打印", printRoomFeeHistory.ID.ToString(), "PrintRoomFeeHistory");
                #endregion
                WebUtil.WriteJson(context, new { status = true, PrintID = printRoomFeeHistory.ID });
                return;
            }
            var ItemList = JsonConvert.DeserializeObject<List<Utility.GuaranteeFeeModule>>(context.Request["itemlist"]);
            if (ItemList.Count == 0)
            {
                WebUtil.WriteJson(context, new { status = false, error = "付款费项为空" });
                return;
            }
            string AddMan = User.GetCurrentUserName();
            printRoomFeeHistory = SaveChargeGuaranteeBackPrintRoomFeeHistory(context, printRoomFeeHistory);
            List<RoomFeeHistory> list = new List<RoomFeeHistory>();
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    foreach (var item in ItemList)
                    {
                        RoomFeeHistory newRoomFeeHistory = null;
                        if (paysummary != null && paysummary.RelateFeeType_Pay)
                        {
                            int newRoomFeeHistoryID = RoomFeeHistory.InsertRoomFeeHistoryByTempHistoryID(item.HistoryID, AddMan, 7, helper);
                            newRoomFeeHistory = RoomFeeHistory.GetRoomFeeHistory(newRoomFeeHistoryID, helper);
                        }
                        printRoomFeeHistory.Save(helper);
                        payservice.PrintID = printRoomFeeHistory.ID;
                        payservice.Save(helper);
                        if (newRoomFeeHistory != null)
                        {
                            newRoomFeeHistory.IsTempFee = true;
                            newRoomFeeHistory.ParentRoomFeeID = 0;
                            newRoomFeeHistory.BackGuaranteeChargeTime = item.ChargeTime;
                            newRoomFeeHistory.ChargeFeeSummaryName = item.ChargeName;
                            newRoomFeeHistory.BackGuaranteeRemark = item.BackGuaranteeRemark;
                            newRoomFeeHistory.PrintID = printRoomFeeHistory.ID;
                            newRoomFeeHistory.Save(helper);
                        }
                    }
                    helper.Commit();
                    WebUtil.WriteJson(context, new { status = true, PrintID = printRoomFeeHistory.ID });
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError("FeeCenterHandler", "visit: chargepayservice", ex);
                    context.Response.Write("{\"status\":false}");
                }
            }
        }
        /// <summary>
        /// 退保证金
        /// </summary>
        /// <param name="context"></param>
        private void cancelguaranteefee(HttpContext context)
        {
            bool doprint = true;
            if (!string.IsNullOrEmpty(context.Request["doprint"]))
            {
                bool.TryParse(context.Request["doprint"], out doprint);
            }
            int PrintID = WebUtil.GetIntValue(context, "PrintID");
            Foresight.DataAccess.PrintRoomFeeHistory printRoomFeeHistory = null;
            if (PrintID > 0)
            {
                printRoomFeeHistory = Foresight.DataAccess.PrintRoomFeeHistory.GetPrintRoomFeeHistory(PrintID);
            }
            if (printRoomFeeHistory != null)
            {
                if (!doprint)
                {
                    printRoomFeeHistory = SaveChargeGuaranteeBackPrintRoomFeeHistory(context, printRoomFeeHistory);
                    printRoomFeeHistory.Save();
                    #region 押金退款保存日志
                    APPCode.CommHelper.SaveOperationLog("订单号" + printRoomFeeHistory.PrintNumber + "押金退款保存", Utility.EnumModel.OperationModule.GuaranteeFeeBackSave.ToString(), "押金退款保存", printRoomFeeHistory.ID.ToString(), "PrintRoomFeeHistory");
                    #endregion
                }
                else
                {
                    #region 押金退款打印日志
                    APPCode.CommHelper.SaveOperationLog("订单号" + printRoomFeeHistory.PrintNumber + "押金退款打印", Utility.EnumModel.OperationModule.GuaranteeFeeBackPrint.ToString(), "押金退款打印", printRoomFeeHistory.ID.ToString(), "PrintRoomFeeHistory");
                    #endregion
                }
                WebUtil.WriteJson(context, new { status = true, PrintID = printRoomFeeHistory.ID });
                return;
            }
            printRoomFeeHistory = SaveChargeGuaranteeBackPrintRoomFeeHistory(context, printRoomFeeHistory);
            int i = 0;
            List<RoomFeeHistory> list = new List<RoomFeeHistory>();
            var ItemList = JsonConvert.DeserializeObject<List<Utility.GuaranteeFeeModule>>(context.Request["itemlist"]);
            DateTime ChargeTime = WebUtil.GetDateValue(context, "ChargeTime");
            foreach (var item in ItemList)
            {
                var HistoryID = item.HistoryID;
                var roomFeeHistory = RoomFeeHistory.GetRoomFeeHistory(HistoryID);
                var newRoomFeeHistory = new RoomFeeHistory();
                newRoomFeeHistory.ParentRoomFeeID = roomFeeHistory.HistoryID;
                newRoomFeeHistory.ID = roomFeeHistory.ID;
                newRoomFeeHistory.RoomID = roomFeeHistory.RoomID;
                newRoomFeeHistory.UseCount = roomFeeHistory.UseCount;
                newRoomFeeHistory.StartTime = roomFeeHistory.StartTime;
                newRoomFeeHistory.EndTime = roomFeeHistory.EndTime;
                newRoomFeeHistory.Cost = item.RealCost;
                newRoomFeeHistory.Remark = item.Remark;
                newRoomFeeHistory.AddTime = DateTime.Now;
                newRoomFeeHistory.AddUserName = User.GetCurrentUserName();
                newRoomFeeHistory.IsCharged = true;
                newRoomFeeHistory.ChargeFeeID = roomFeeHistory.ChargeFeeID;
                newRoomFeeHistory.ChargeID = roomFeeHistory.ChargeID;
                newRoomFeeHistory.IsStart = true;
                newRoomFeeHistory.UnitPrice = roomFeeHistory.UnitPrice;
                newRoomFeeHistory.RealCost = item.RealCost;
                newRoomFeeHistory.TotalRealCost = 0;
                newRoomFeeHistory.RestCost = 0;
                newRoomFeeHistory.TotalDiscountCost = 0;
                newRoomFeeHistory.ChargeTime = ChargeTime == DateTime.MinValue ? DateTime.Now : ChargeTime;
                newRoomFeeHistory.ChargeMan = context.Request["AddMan"];
                newRoomFeeHistory.ChargeState = 3;
                newRoomFeeHistory.ReturnGuaranteeFee = true;
                newRoomFeeHistory.BackGuaranteeChargeTime = item.ChargeTime;
                newRoomFeeHistory.BackGuaranteeRemark = item.BackGuaranteeRemark;
                newRoomFeeHistory.Remark = item.Remark;
                newRoomFeeHistory.ParentHistoryID = roomFeeHistory.HistoryID;
                newRoomFeeHistory.ChargeFeeSummaryName = item.ChargeName;
                newRoomFeeHistory.IsTempFee = true;
                list.Add(newRoomFeeHistory);
                i++;
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    if (list.Count > 0)
                    {
                        printRoomFeeHistory.Save(helper);
                        foreach (var item in list)
                        {
                            item.PrintID = printRoomFeeHistory.ID;
                            item.Save(helper);
                        }
                    }
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError("FeeCenterHandler", "visit: CancelGuaranteeFee", ex);
                    WebUtil.WriteJson(context, new { status = false });
                }
            }
            if (!doprint)
            {
                #region 押金退款保存日志
                APPCode.CommHelper.SaveOperationLog("订单号" + printRoomFeeHistory.PrintNumber + "押金退款保存", Utility.EnumModel.OperationModule.GuaranteeFeeBackSave.ToString(), "押金退款保存", printRoomFeeHistory.ID.ToString(), "PrintRoomFeeHistory");
                #endregion
            }
            else
            {
                #region 押金退款打印日志
                APPCode.CommHelper.SaveOperationLog("订单号" + printRoomFeeHistory.PrintNumber + "押金退款打印", Utility.EnumModel.OperationModule.GuaranteeFeeBackPrint.ToString(), "押金退款打印", printRoomFeeHistory.ID.ToString(), "PrintRoomFeeHistory");
                #endregion
            }
            WebUtil.WriteJson(context, new { status = true, PrintID = printRoomFeeHistory.ID });
        }
        private void checkprintchequestatus(HttpContext context)
        {
            int PrintID = WebUtil.GetIntValue(context, "PrintID");
            var data = PrintRoomFeeHistory.GetPrintRoomFeeHistory(PrintID);
            if (!string.IsNullOrEmpty(data.ChequePDFPath))
            {
                WebUtil.WriteJson(context, new { status = true, pdfurl = WebUtil.GetContextPath() + data.ChequePDFPath });
            }
            if (data.ChequeInvoiceStatus == 0)
            {
                WebUtil.WriteJson(context, new { status = false, reprint = true });
                return;
            }
            string msg = string.Empty;
            bool result = Utility.ChequeHelper.doGetInvoiceResult(data.ChequeInvoiceNo, out msg);
            if (result)
            {
                WebUtil.WriteJson(context, new { status = true, pdfurl = WebUtil.GetContextPath() + msg });
                return;
            }
            WebUtil.WriteJson(context, new { status = false, error = msg });
        }
        private void saveprintchequedata(HttpContext context)
        {
            int RoomID = WebUtil.GetIntValue(context, "RoomID");
            int RelationID = WebUtil.GetIntValue(context, "RelationID");
            int PrintID = WebUtil.GetIntValue(context, "PrintID");
            string CompanyName = WebUtil.getServerValue(context, "tdCompanyName");
            string Address = WebUtil.getServerValue(context, "tdAddress");
            string BuyerTaxpayerNumber = WebUtil.getServerValue(context, "tdBuyerTaxpayerNumber");
            string BuyerBankAccountNo = WebUtil.getServerValue(context, "tdBuyerBankAccountNo");
            string BuyerBankName = WebUtil.getServerValue(context, "tdBuyerBankName");
            string BuyerEmailAddress = WebUtil.getServerValue(context, "tdBuyerEmailAddress");

            string SellerTaxpayerNumber = WebUtil.getServerValue(context, "tdSellerTaxpayerNumber");
            string SellerBankNo = WebUtil.getServerValue(context, "tdSellerBankNo");
            string SellerBankName = WebUtil.getServerValue(context, "tdSellerBankName");
            string ReCheckUserName = WebUtil.getServerValue(context, "tdReCheckUserName");
            string SellerCompanyName = WebUtil.getServerValue(context, "tdSellerCompanyName");
            string SellerAddress = WebUtil.getServerValue(context, "tdSellerAddress");
            RoomPhoneRelation relation = null;
            RoomBasic basic = null;
            if (RelationID > 0)
            {
                relation = RoomPhoneRelation.GetRoomPhoneRelation(RelationID);
            }
            if (relation != null)
            {
                relation.CompanyName = CompanyName;
                relation.HomeAddress = Address;
                relation.TaxpayerNumber = BuyerTaxpayerNumber;
                relation.BankAccountNo = BuyerBankAccountNo;
                relation.BankName = BuyerBankName;
                relation.EmailAddress = BuyerEmailAddress;
            }
            if (relation == null)
            {
                basic = RoomBasic.GetRoomBasicByRoomID(RoomID);
            }
            if (basic != null)
            {
                basic.ChequeCompanyName = CompanyName;
                basic.ChequeAddress = Address;
                basic.ChequeTaxpayerNumber = BuyerTaxpayerNumber;
                basic.ChequeBankNo = BuyerBankAccountNo;
                basic.ChequeBankName = BuyerBankName;
            }
            var company = Company.GetCompanies().FirstOrDefault();
            if (company != null)
            {
                company.TaxpayerNumber = SellerTaxpayerNumber;
                company.BankAccountNo = SellerBankNo;
                company.BankName = SellerBankName;
                company.ReCheckUserName = ReCheckUserName;
                company.ChequeTitle = SellerCompanyName;
                company.Address = SellerAddress;
                company.Cheque_SL = WebUtil.getServerDecimalValue(context, "tdCheque_SL");
                company.Cheque_FLBM = WebUtil.getServerValue(context, "tdCheque_FLBM");
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    if (relation != null)
                    {
                        relation.Save(helper);
                    }
                    if (basic != null)
                    {
                        basic.Save(helper);
                    }
                    if (company != null)
                    {
                        company.Save(helper);
                    }
                    helper.Commit();
                }
                catch (Exception)
                {
                    helper.Rollback();
                    WebUtil.WriteJson(context, new { status = false });
                    return;
                }
            }
            if (PrintID > 0)
            {
                string errormsg = string.Empty;
                bool result = APPCode.HandlerHelper.PrintCheque(PrintID, RelationID, out errormsg);
                WebUtil.WriteJson(context, new { status = result, error = errormsg });
                return;
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void loadmallorderprint(HttpContext context)
        {
            int OrderID = WebUtil.GetIntValue(context, "OrderID");
            List<int> OrderIDList = new List<int>();
            string OrderIDs = context.Request["OrderIDList"];
            if (!string.IsNullOrEmpty(OrderIDs))
            {
                OrderIDList = JsonConvert.DeserializeObject<List<int>>(OrderIDs);
            }
            if (OrderID > 0)
            {
                OrderIDList.Add(OrderID);
            }
            if (OrderIDList.Count == 0)
            {
                WebUtil.WriteJson(context, new { status = false });
                return;
            }
            var order_item_list = Mall_OrderItem.GetMall_OrderItemListByOrderIDList(OrderIDList);
            var order_list = Mall_Order.GetMall_OrderListByIDList(OrderIDList);
            List<Dictionary<string, object>> diclist = new List<Dictionary<string, object>>();
            var company = WebUtil.GetCompany(context);
            var user_list = Foresight.DataAccess.User.GetUserListByIDList(order_list.Select(p => p.UserID).Distinct().ToList());
            foreach (var order in order_list)
            {
                var my_order_item_list = order_item_list.Where(p => p.OrderID == order.ID).ToArray();
                var my_order_items = my_order_item_list.Select(p =>
                {
                    var my_order_item = new { ID = p.ID, ProductName = p.ProductTitle, ProductModel = p.ProductSubTitle, Quantity = p.Quantity, UnitPrice = p.PriceDesc, Cost = p.TotalPriceDesc };
                    return my_order_item;
                });
                var dic = new Dictionary<string, object>();
                dic["list"] = my_order_items;
                var my_user = user_list.FirstOrDefault(q => q.UserID == order.UserID);
                if (!string.IsNullOrEmpty(order.AddressUserName))
                {
                    dic["BuyerName"] = order.AddressUserName;
                }
                else
                {
                    dic["BuyerName"] = my_user != null ? my_user.NickName : "";
                }
                if (!string.IsNullOrEmpty(order.AddressPhoneNumber))
                {
                    dic["BuyerPhone"] = order.AddressPhoneNumber;
                }
                else
                {
                    dic["BuyerPhone"] = my_user != null ? my_user.PhoneNumber : "";
                }
                dic["FullAddressInfo"] = order.FinalAddressName;
                dic["OrderNumber"] = order.OrderNumber;
                dic["OrderTime"] = order.AddTime.ToString("yyyy年MM月dd日HH:mm:ss");
                dic["StatusDesc"] = order.OrderStatusDesc;
                dic["OrderType"] = order.ProductTypeDesc;
                dic["TotalCost"] = order.TotalOrderCostDesc;
                dic["CouponCost"] = order.CouponAmount > 0 ? "￥" + order.CouponAmount.ToString("0.00") : "￥0.00";
                diclist.Add(dic);
            }
            WebUtil.WriteJson(context, new { status = true, list = diclist });
        }
        private void loadprintcontractcuifei(HttpContext context)
        {
            string IDs = context.Request.Params["IDs"];
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(IDs).Distinct().ToList();
            var list = ViewContractChargeSummary.GetViewContractChargeSummaryListByIDList(IDList).Where(p => p.CalcualteTotalCost > 0);
            var main_list = list.Where(p => IDList.Contains(p.ID)).ToList();
            List<CuiFeiModel> templist = new List<CuiFeiModel>();
            Project main_project = null;
            foreach (var item in main_list)
            {
                CuiFeiModel cuiFeiModel = new CuiFeiModel();
                if (cuiFeiModel.RoomID <= 0)
                {
                    cuiFeiModel.RoomID = item.RoomID;
                }
                if (main_project == null)
                {
                    main_project = Foresight.DataAccess.Project.GetProject(cuiFeiModel.RoomID);
                }
                cuiFeiModel.FullName = item.ContractNo;
                cuiFeiModel.OwnerName = item.ContractName;
                cuiFeiModel.ContractID = item.ContractID;
                var sub_list = list.Where(p => (p.ContractID == item.ContractID)).OrderByDescending(p => p.ContractID).ThenByDescending(p => p.ID).ToList();
                foreach (var item2 in sub_list)
                {
                    item2.PrintRemark = item2.Remark;
                }
                cuiFeiModel.contractfeelist = sub_list.ToList();
                templist.Add(cuiFeiModel);
            }

            var newList = templist.Where((x, i) => templist.FindIndex(z => (z.ContractID == x.ContractID)) == i);
            foreach (var item in newList)
            {
                item.PrintTotalLines = 6;
                var project = Foresight.DataAccess.Project.GetProject(item.RoomID);
                if (project == null)
                {
                    project = main_project;
                }
                if (project != null)
                {
                    item.Remark = project.CuiFeiNote.Replace("\r\n", "<br/>").Replace("\n", "<br/>").Replace(" ", "&nbsp;");
                    item.PrintTitle = project.CuiShouPrintTitle;
                    item.PrintSubTitle = project.CuiShouPrintSubTitle;
                    item.PrintFont = string.IsNullOrEmpty(project.PrintFont) ? "100%" : project.PrintFont;
                    if (project.IsDefinePrintSize)
                    {
                        item.pageHeight = project.PrintHeight;
                    }
                    else
                    {
                        item.pageHeight = WebUtil.GetPrintHeight(project.PrintType);
                    }
                    item.PrintTopMargin = project.PrintTopMargin > 0 ? project.PrintTopMargin : 0;
                    item.PrintBottomMargin = project.PrintBottomMargin > 0 ? project.PrintBottomMargin : 0;
                    item.PrintTotalLines = project.PrintTotalLines > 0 ? project.PrintTotalLines : 6;
                    foreach (var data in item.contractfeelist)
                    {
                        item.TotalCost += data.CalcualteTotalCost;
                    }
                }
                item.PrintTitle = string.IsNullOrEmpty(item.PrintTitle) ? WebUtil.GetCompany(context).CompanyName : item.PrintTitle;
                item.PrintSubTitle = string.IsNullOrEmpty(item.PrintSubTitle) ? "催费通知单" : item.PrintSubTitle;
            }
            var items = new
            {
                list = newList,
            };
            string result = JsonConvert.SerializeObject(items);
            context.Response.Write(result);
        }
        private void getoffsetchargefeelist(HttpContext context)
        {
            var historyidlist = JsonConvert.DeserializeObject<List<int>>(context.Request["historyidlist"]);
            var list = ViewTempRoomFeeHistory.GetViewTempRoomFeeHistoryListByIDs(historyidlist);
            List<int> RoomIDList = list.Select(p => p.RoomID).Distinct().ToList();
            var project_list = Foresight.DataAccess.Project.GetProjectListByIDs(RoomIDList);
            List<Dictionary<string, object>> items = new List<Dictionary<string, object>>();
            List<Dictionary<string, object>> PrintNumberList = new List<Dictionary<string, object>>();
            foreach (var RoomID in RoomIDList)
            {
                var my_list = list.Where(p => p.RoomID == RoomID).ToArray();
                var my_project = project_list.FirstOrDefault(p => p.ID == RoomID);
                var dic = new Dictionary<string, object>();
                int OrderNumberID = 0;
                string PrintNumber = PrintRoomFeeHistory.GetLastestPrintNumber(Foresight.DataAccess.OrderTypeNameDefine.offseefee.ToString(), RoomID, out OrderNumberID);
                if (OrderNumberID > 0 && !string.IsNullOrEmpty(PrintNumber))
                {
                    bool is_in = false;
                    string PrintNumber_NumberPart = string.Empty;
                    string PrintNumber_TextPart = string.Empty;
                    foreach (var item in PrintNumberList)
                    {
                        if (Convert.ToInt32(item["OrderNumberID"]) == OrderNumberID)
                        {
                            PrintNumber_NumberPart = item["PrintNumber_NumberPart"].ToString();
                            PrintNumber_TextPart = item["PrintNumber_TextPart"].ToString();
                            long PrintNumber_Number = 0;
                            PrintNumber_Number = Convert.ToInt64(PrintNumber_NumberPart);
                            PrintNumber_NumberPart = (PrintNumber_Number + 1).ToString("D" + PrintNumber_NumberPart.Length); ;
                            PrintNumber = PrintNumber_TextPart + PrintNumber_NumberPart;
                            item["PrintNumber"] = PrintNumber;
                            item["PrintNumber_NumberPart"] = PrintNumber_NumberPart;
                            is_in = true;
                            break;
                        }
                    }
                    if (!is_in)
                    {
                        PrintNumber_NumberPart = System.Text.RegularExpressions.Regex.Replace(PrintNumber, @"[^0-9]+", "");
                        PrintNumber_TextPart = PrintNumber.Replace(PrintNumber_NumberPart, "");
                        var PrintNumber_Dic = new Dictionary<string, object>();
                        PrintNumber_Dic["OrderNumberID"] = OrderNumberID;
                        PrintNumber_Dic["PrintNumber"] = PrintNumber;
                        PrintNumber_Dic["PrintNumber_NumberPart"] = PrintNumber_NumberPart;
                        PrintNumber_Dic["PrintNumber_TextPart"] = PrintNumber_TextPart;
                        PrintNumberList.Add(PrintNumber_Dic);
                    }
                }
                decimal TotalCost = my_list.Sum(p => p.Cost);
                decimal RealCost = my_list.Sum(p => p.RealCost);
                decimal Money = my_list.Sum(p => p.ChargeFee);
                decimal Cost = my_list.Sum(p => p.Cost);
                dic["PrintID"] = 0;
                dic["RoomID"] = RoomID;
                dic["PrintNumber"] = PrintNumber;
                dic["OrderNumberID"] = OrderNumberID;
                dic["TotalCost"] = TotalCost;
                dic["RealCost"] = RealCost;
                dic["PreChargeMoney"] = 0;
                dic["ChargeBackMoney"] = 0;
                dic["ChargeMan"] = WebUtil.GetUser(context).RealName;
                dic["ChargeTime"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                dic["RealMoneyCost1"] = RealCost;
                dic["ChargeMoneyType1"] = 3;
                dic["RealMoneyCost2"] = 0;
                dic["ChargeMoneyType2"] = 0;
                dic["DiscountMoney"] = 0;
                dic["Remark"] = my_project.PrintNote;
                dic["AddMan"] = WebUtil.GetUser(context).RealName;
                dic["TempHistoryIDs"] = JsonConvert.SerializeObject(my_list.Select(p => p.TempHistoryID));
                dic["money"] = Money;
                dic["MoneyDaXie"] = Tools.CmycurD(Money);
                dic["TotalCost"] = Cost;
                dic["RoomFullName"] = my_project.FullName + "-" + my_project.Name;
                List<string> OwnerNameList = my_list.Where(p => !string.IsNullOrEmpty(p.DefaultChargeManName)).Select(p => p.DefaultChargeManName).Distinct().ToList();
                string RoomOwnerName = string.Empty;
                if (OwnerNameList.Count <= 3)
                {
                    RoomOwnerName = string.Join(",", OwnerNameList.ToArray());
                }
                else
                {
                    RoomOwnerName = OwnerNameList[0];
                }
                dic["RoomOwnerName"] = RoomOwnerName;
                dic["ChargeForSummary"] = "预收款";
                dic["ChargeMethods"] = "手工指定";
                dic["doprint"] = true;
                dic["ischongxiao"] = true;
                var history_items = my_list.Select(p =>
                {
                    var history_item = new { TempHistoryID = p.TempHistoryID, ID = p.ID, ChargeName = p.ChargeName, StartTime = p.StartTime > DateTime.MinValue ? p.StartTime.ToString("yyyy-MM-dd") : "", EndTime = p.EndTime > DateTime.MinValue ? p.EndTime.ToString("yyyy-MM-dd") : "", UnitPrice = p.UnitPrice > 0 ? p.UnitPrice : 0, ChargeFee = p.ChargeFee > 0 ? p.ChargeFee : 0, StartPoint = p.StartPoint > 0 ? p.StartPoint : 0, EndPoint = p.EndPoint > 0 ? p.EndPoint : 0, Remark = p.Remark };
                    return history_item;
                });
                dic["list"] = history_items;
                dic["FirstTitle"] = my_project.PrintTitle;
                dic["FirstTitle"] = my_project.PrintTitle;
                items.Add(dic);
            }
            decimal page_width = 210;
            decimal page_height = 99;
            foreach (var project in project_list)
            {
                decimal my_page_width = 0;
                decimal my_page_height = 0;
                if (project.IsDefinePrintSize)
                {
                    my_page_width = project.PrintWidth > 0 ? project.PrintWidth : page_width;
                    my_page_height = project.PrintHeight > 0 ? project.PrintHeight : WebUtil.GetPrintHeight();
                }
                else
                {
                    my_page_height = WebUtil.GetPrintHeight(project.PrintType);
                }
                if (my_page_width <= page_width)
                {
                    page_width = my_page_width;
                }
                if (my_page_height <= page_height)
                {
                    page_height = my_page_height;
                }
            }
            WebUtil.WriteJson(context, new { status = true, list = items, pageWidth = page_width, pageHeight = page_height });
        }
        private void getprinthistorypagesize(HttpContext context)
        {
            int PrintID = WebUtil.GetIntValue(context, "PrintID");
            var list = Foresight.DataAccess.Project.GetProjectListByPrintID(PrintID);
            decimal page_width = 210;
            decimal page_height = 99;
            foreach (var project in list)
            {
                decimal my_page_width = 0;
                decimal my_page_height = 0;
                if (project.IsDefinePrintSize)
                {
                    my_page_width = project.PrintWidth > 0 ? project.PrintWidth : page_width;
                    my_page_height = project.PrintHeight > 0 ? project.PrintHeight : WebUtil.GetPrintHeight();
                }
                else
                {
                    my_page_height = WebUtil.GetPrintHeight(project.PrintType);
                }
                if (my_page_width <= page_width)
                {
                    page_width = my_page_width;
                }
                if (my_page_height <= page_height)
                {
                    page_height = my_page_height;
                }
            }
            WebUtil.WriteJson(context, new { status = true, page_width = page_width, page_height = page_height });
        }
        private void loadprintchargefee(HttpContext context)
        {
            int PrintID = WebUtil.GetIntValue(context, "PrintID");
            string type = context.Request["type"];
            type = string.IsNullOrEmpty(type) ? "" : type;
            List<int> PrintIDList = new List<int>();
            string PrintIDs = context.Request["PrintIDList"];
            if (!string.IsNullOrEmpty(PrintIDs))
            {
                PrintIDList = JsonConvert.DeserializeObject<List<int>>(PrintIDs);
            }
            if (PrintID > 0)
            {
                PrintIDList.Add(PrintID);
            }
            if (PrintIDList.Count == 0)
            {
                WebUtil.WriteJson(context, new { status = false });
                return;
            }
            var ProjectList = Foresight.DataAccess.ProjectDetails2.GetProjectListByPrintIDList(PrintIDList);
            var list = ViewRoomFeeHistory.GetViewRoomFeeHistoryListByPrintIDList(PrintIDList);
            TempRoomFeeHistory[] templist = new TempRoomFeeHistory[] { };
            if (list.Length == 0 && type.Equals("payservice"))
            {
                templist = TempRoomFeeHistory.GetTempRoomFeeHistorysByPrintID(PrintID);
            }
            var ChargeMoneyTypeList = ChargeMoneyType.GetChargeMoneyTypes();
            var printRoomFeeHistoryList = PrintRoomFeeHistory.GetPrintRoomFeeHistoryListByIDList(PrintIDList);
            List<Dictionary<string, object>> diclist = new List<Dictionary<string, object>>();
            var company = WebUtil.GetCompany(context);
            foreach (var printRoomFeeHistory in printRoomFeeHistoryList)
            {
                var sub_list = list.Where(p => p.PrintID == printRoomFeeHistory.ID).ToArray();
                decimal Total_Cost = sub_list.Where(p => p.Cost > 0).Sum(p => p.Cost);
                printRoomFeeHistory.Cost = Total_Cost;
                ChargeMoneyType moneyType = ChargeMoneyTypeList.FirstOrDefault(p => p.ChargeTypeID == printRoomFeeHistory.ChageType1);
                string ChargeTypeName1 = string.Empty;
                if (moneyType != null)
                {
                    ChargeTypeName1 = moneyType.ChargeTypeName;
                }
                moneyType = ChargeMoneyTypeList.FirstOrDefault(p => p.ChargeTypeID == printRoomFeeHistory.ChageType2);
                string ChargeTypeName2 = string.Empty;
                if (moneyType != null)
                {
                    ChargeTypeName2 = moneyType.ChargeTypeName;
                }
                var project = ProjectList.FirstOrDefault(p => p.PrintID == printRoomFeeHistory.ID);
                string RoomOwner = printRoomFeeHistory.RoomOwnerName;
                string FullName = printRoomFeeHistory.RoomFullName;
                string FirstTitle = string.Empty;
                FirstTitle = company != null ? company.CompanyName : string.Empty;
                string SubTitle = "收款单据";
                string PrintFont = "100%";
                bool IsShowPrintNote = true;
                bool IsShowPrintCount = true;
                bool IsShowPrintCost = true;
                bool IsShowPrintDiscount = true;
                bool IsShowPrintRoomNo = true;
                bool IsPrintTotalRealCost = true;
                bool IsPrintRealCost = true;
                bool IsPrintMonthCount = true;
                bool IsPrintUnitPrice = true;
                string LogoPath = string.Empty;
                decimal PrintTopMargin = 0;
                decimal PrintBottomMargin = 0;
                int PrintTotalLines = 0;
                decimal PageHeight = WebUtil.GetPrintHeight();
                int LogoWidth = 0;
                int LogoHeight = 0;
                int PrintChargeTypeCount = 2;
                if (project != null)
                {
                    if (type.Equals("payback") || type.Equals("payservice"))
                    {
                        FirstTitle = string.IsNullOrEmpty(project.PayPrintTitle) ? FirstTitle : project.PayPrintTitle;
                        SubTitle = string.IsNullOrEmpty(project.PayPrintSubTitle) ? "付款单据" : project.PayPrintSubTitle;
                    }
                    else
                    {
                        FirstTitle = string.IsNullOrEmpty(project.PrintTitle) ? FirstTitle : project.PrintTitle;
                        SubTitle = string.IsNullOrEmpty(project.PrintSubTitle) ? SubTitle : project.PrintSubTitle;
                    }
                    PrintFont = string.IsNullOrEmpty(project.PrintFont) ? PrintFont : project.PrintFont;
                    IsShowPrintNote = project.IsPrintNote;
                    IsShowPrintCount = project.IsPrintCount;
                    IsShowPrintCost = project.IsPrintCost;
                    IsShowPrintDiscount = project.IsPrintDiscount;
                    IsShowPrintRoomNo = project.IsPrintRoomNo;
                    IsPrintTotalRealCost = project.IsPrintTotalRealCost;
                    IsPrintRealCost = project.IsPrintRealCost;
                    IsPrintMonthCount = project.IsPrintMonthCount;
                    IsPrintUnitPrice = project.IsPrintUnitPrice;
                    LogoPath = project.LogoPath;
                    LogoWidth = project.LogoWidth;
                    LogoHeight = project.LogoHeight;
                    PrintTopMargin = project.PrintTopMargin;
                    PrintBottomMargin = project.PrintBottomMargin;
                    PrintTotalLines = project.PrintTotalLines;
                    PrintChargeTypeCount = project.PrintChargeTypeCount > 0 ? PrintChargeTypeCount : 2;
                    if (project.IsDefinePrintSize)
                    {
                        PageHeight = project.PrintHeight;
                    }
                    else
                    {
                        PageHeight = WebUtil.GetPrintHeight(project.PrintType);
                    }
                }
                FirstTitle = string.IsNullOrEmpty(printRoomFeeHistory.PrintTitle) ? FirstTitle : printRoomFeeHistory.PrintTitle;
                SubTitle = string.IsNullOrEmpty(printRoomFeeHistory.PrintSubTitle) ? SubTitle : printRoomFeeHistory.PrintSubTitle;
                printRoomFeeHistory.Remark = printRoomFeeHistory.Remark.Replace("\r\n", "<br/>").Replace("\n", "<br/>").Replace(" ", "&nbsp;");
                decimal totalbalance = (printRoomFeeHistory.WeiShuBalance < 0 ? 0 : printRoomFeeHistory.WeiShuBalance);
                var dic = new Dictionary<string, object>();
                dic["list"] = sub_list;
                dic["templist"] = templist;
                dic["printhistory"] = printRoomFeeHistory;
                dic["ChargeTypeName1"] = ChargeTypeName1;
                dic["ChargeTypeName2"] = ChargeTypeName2;
                dic["OwnerName"] = RoomOwner;
                dic["FullName"] = FullName;
                dic["totalbalance"] = totalbalance;
                dic["CompanyName"] = FirstTitle;
                dic["PrintFont"] = PrintFont;
                dic["IsShowPrintNote"] = IsShowPrintNote;
                dic["IsShowPrintCount"] = IsShowPrintCount;
                dic["IsShowPrintCost"] = IsShowPrintCost;
                dic["IsShowPrintDiscount"] = IsShowPrintDiscount;
                dic["IsShowPrintRoomNo"] = IsShowPrintRoomNo;
                dic["IsPrintTotalRealCost"] = IsPrintTotalRealCost;
                dic["IsPrintRealCost"] = IsPrintRealCost;
                dic["IsPrintMonthCount"] = IsPrintMonthCount;
                dic["IsPrintUnitPrice"] = IsPrintUnitPrice;
                dic["SubTitle"] = SubTitle;
                dic["LogoPath"] = LogoPath;
                dic["LogoWidth"] = LogoWidth;
                dic["LogoHeight"] = LogoHeight;
                dic["PageHeight"] = PageHeight;
                dic["PrintTopMargin"] = PrintTopMargin;
                dic["PrintBottomMargin"] = PrintBottomMargin;
                dic["PrintTotalLines"] = PrintTotalLines;
                dic["show_sign"] = WebUtil.Authorization(context, "1101315");
                dic["PrintChargeTypeCount"] = PrintChargeTypeCount;
                diclist.Add(dic);
            }
            WebUtil.WriteJson(context, new { status = true, list = diclist });
        }
        private void loadtempprintchargefee(HttpContext context)
        {
            var user = WebUtil.GetUser(context);
            string IDs = context.Request["IDs"];
            int RoomID = WebUtil.GetIntValue(context, "RoomID");
            List<int> IDList = new List<int>();
            List<int> RoomIDList = new List<int>();
            List<int> ContractIDList = new List<int>();
            if (string.IsNullOrEmpty(IDs))
            {
                WebUtil.WriteJson(context, new { status = false });
                return;
            }
            IDList = JsonConvert.DeserializeObject<List<int>>(IDs);
            var list = ViewTempRoomFeeHistory.GetViewTempRoomFeeHistoryListByIDs(IDList);
            var finalList = Foresight.DataAccess.Contract_Customer.GetTempRoomFeeHistoryByDivide(list);
            var ProjectIDList = list.Select(p => p.RoomID).Distinct().ToList();
            var ProjectList = Foresight.DataAccess.ProjectDetails2.GetProjectListByIDs(ProjectIDList);
            TempRoomFeeHistory[] templist = new TempRoomFeeHistory[] { };
            var ChargeMoneyTypeList = ChargeMoneyType.GetChargeMoneyTypes();
            List<Dictionary<string, object>> diclist = new List<Dictionary<string, object>>();
            var company = WebUtil.GetCompany(context);
            decimal Total_Cost = list.Where(p => p.Cost > 0).Sum(p => p.Cost);
            var project = ProjectList.FirstOrDefault(p => ProjectIDList.Contains(p.ID));
            var OwnerNameList = list.Where(p => !string.IsNullOrEmpty(p.DefaultChargeManName)).Select(p => p.DefaultChargeManName).Distinct().ToList();
            string RoomOwner = OwnerNameList.Count > 0 ? OwnerNameList[0] : string.Empty;
            string FullName = project != null ? project.FullName + "-" + project.Name : "";
            string FirstTitle = company != null ? company.CompanyName : string.Empty;
            string SubTitle = "收款单据";
            string PrintFont = "100%";
            bool IsShowPrintNote = true;
            bool IsShowPrintCount = true;
            bool IsShowPrintCost = true;
            bool IsShowPrintDiscount = true;
            bool IsShowPrintRoomNo = true;
            bool IsPrintTotalRealCost = true;
            bool IsPrintRealCost = true;
            bool IsPrintMonthCount = true;
            bool IsPrintUnitPrice = true;
            string LogoPath = string.Empty;
            decimal PrintTopMargin = 0;
            decimal PrintBottomMargin = 0;
            int PrintTotalLines = 0;
            int LogoWidth = 0;
            int LogoHeight = 0;
            int PrintChargeTypeCount = 2;
            string PrintRemark = string.Empty;
            string PrintNumberPart1 = string.Empty;
            int PrintNumberPart2 = 0;
            int OrderNumberCount = 0;
            string AllParentID = string.Empty;
            decimal pageWidth = 210;
            decimal pageHeight = 99;
            var ChargeTypes = Foresight.DataAccess.ChargeMoneyType.GetChargeMoneyTypes().ToArray();
            var ChargeItems = ChargeTypes.Select(p =>
            {
                var item = new { ID = p.ChargeTypeID, Name = p.ChargeTypeName };
                return item;
            }).ToArray();
            if (project != null)
            {
                AllParentID = project.AllParentID;
                SubTitle = string.IsNullOrEmpty(project.PrintSubTitle) ? SubTitle : project.PrintSubTitle;
                PrintFont = string.IsNullOrEmpty(project.PrintFont) ? PrintFont : project.PrintFont;
                IsShowPrintNote = project.IsPrintNote;
                IsShowPrintCount = project.IsPrintCount;
                IsShowPrintCost = project.IsPrintCost;
                IsShowPrintDiscount = project.IsPrintDiscount;
                IsShowPrintRoomNo = project.IsPrintRoomNo;
                IsPrintTotalRealCost = project.IsPrintTotalRealCost;
                IsPrintRealCost = project.IsPrintRealCost;
                IsPrintMonthCount = project.IsPrintMonthCount;
                IsPrintUnitPrice = project.IsPrintUnitPrice;
                LogoPath = project.LogoPath;
                LogoWidth = project.LogoWidth;
                LogoHeight = project.LogoHeight;
                PrintTopMargin = project.PrintTopMargin;
                PrintBottomMargin = project.PrintBottomMargin;
                PrintTotalLines = project.PrintTotalLines;
                PrintChargeTypeCount = project.PrintChargeTypeCount > 0 ? PrintChargeTypeCount : 2;
                if (project.IsDefinePrintSize)
                {
                    pageWidth = project.PrintWidth > 0 ? project.PrintWidth : pageWidth;
                    pageHeight = project.PrintHeight > 0 ? project.PrintHeight : WebUtil.GetPrintHeight();
                }
                else
                {
                    pageHeight = WebUtil.GetPrintHeight(project.PrintType);
                }
                if (project.IsDefinePrintSize)
                {
                    pageHeight = project.PrintHeight;
                }
                else
                {
                    pageHeight = WebUtil.GetPrintHeight(project.PrintType);
                }
                PrintRemark = project.PrintNote;
                if (RoomID <= 0)
                {
                    RoomID = project.ID;
                }

                PrintChargeTypeCount = project.PrintChargeTypeCount > 0 ? project.PrintChargeTypeCount : 2;
            }
            int OrderNumberID = 0;
            using (SqlHelper helper = new SqlHelper())
            {
                PrintNumberPart1 = Foresight.DataAccess.PrintRoomFeeHistory.GetLastestPrintNumberPart1(Foresight.DataAccess.OrderTypeNameDefine.chargefee.ToString(), RoomID, helper, out OrderNumberID);
                PrintNumberPart2 = Foresight.DataAccess.PrintRoomFeeHistory.GetLastestPrintNumberPart2(Foresight.DataAccess.OrderTypeNameDefine.chargefee.ToString(), RoomID, helper, out OrderNumberID, out OrderNumberCount);
            }
            var configList = SysConfig.Get_SysConfigListByProjectIDList(MinProjectID: RoomID, MaxProjectID: RoomID, ConfigName: SysConfigNameDefine.RealCostCouZhengOn);
            bool isCouZhengOn = SysConfig.IsCouZhengOn(configList, AllParentID);
            decimal finalweishu = PrintRoomFeeHistory.GetRoomWeiShuBalance(0, RoomID);
            int count = 0;
            foreach (var finalData in finalList)
            {
                if (finalData.viewTempList.Length == 0)
                {
                    continue;
                }
                if (project != null)
                {
                    if (!string.IsNullOrEmpty(finalData.CustomerName))
                    {
                        FirstTitle = finalData.CustomerName;
                    }
                    else
                    {
                        FirstTitle = string.IsNullOrEmpty(project.PrintTitle) ? FirstTitle : project.PrintTitle;
                    }
                }
                decimal money = finalData.viewTempList.Where(p => p.RealCost > 0).Sum(p => p.RealCost);
                decimal TotalCost = finalData.viewTempList.Where(p => p.Cost > 0).Sum(p => p.Cost);
                decimal RealCost = 0;
                if (isCouZhengOn)
                {
                    RealCost = Math.Ceiling(money);
                }
                else
                {
                    RealCost = money;
                }
                decimal WeiShuMore = 0;
                decimal WeiShuConsume = 0;
                decimal weishumore = RealCost - money;
                if (finalweishu >= (1 - weishumore))
                {
                    WeiShuMore = 0;
                    WeiShuConsume = (1 - weishumore);
                    if (isCouZhengOn)
                    {
                        RealCost = (Math.Ceiling(money) - 1);
                        finalweishu = finalweishu + (WeiShuMore - WeiShuConsume);
                    }
                }
                else
                {
                    WeiShuMore = weishumore;
                    WeiShuConsume = 0;
                    if (isCouZhengOn)
                    {
                        RealCost = Math.Ceiling(money);
                        finalweishu = finalweishu + (WeiShuMore - WeiShuConsume);
                    }
                }
                var dic = new Dictionary<string, object>();
                dic["PrintChargeTypeCount"] = PrintChargeTypeCount;
                dic["EnableChargeMan"] = WebUtil.Authorization(context, "1191144");
                dic["EnableChargeTime"] = WebUtil.Authorization(context, "1191145");
                dic["ShowWeiShu"] = isCouZhengOn;
                dic["WeiShuMore"] = WeiShuMore;
                dic["WeiShuConsume"] = WeiShuConsume;
                dic["totalbalance"] = finalweishu;
                dic["RealCost"] = RealCost;
                dic["money"] = money;
                dic["TotalCost"] = money;
                dic["list"] = finalData.viewTempList;
                dic["templist"] = templist;
                string PrintNumber = string.Empty;
                if (!string.IsNullOrEmpty(PrintNumberPart1))
                {
                    PrintNumber = PrintNumberPart1 + PrintNumberPart2.ToString("D" + OrderNumberCount);
                }
                dic["OrderNumberID"] = OrderNumberID;
                dic["PrintNumber"] = PrintNumber;
                dic["OwnerName"] = RoomOwner;
                dic["FullName"] = FullName;
                dic["CompanyName"] = FirstTitle;
                dic["PrintFont"] = PrintFont;
                dic["IsShowPrintNote"] = IsShowPrintNote;
                dic["IsShowPrintCount"] = IsShowPrintCount;
                dic["IsShowPrintCost"] = IsShowPrintCost;
                dic["IsShowPrintDiscount"] = IsShowPrintDiscount;
                dic["IsShowPrintRoomNo"] = IsShowPrintRoomNo;
                dic["IsPrintTotalRealCost"] = IsPrintTotalRealCost;
                dic["IsPrintRealCost"] = IsPrintRealCost;
                dic["IsPrintMonthCount"] = IsPrintMonthCount;
                dic["IsPrintUnitPrice"] = IsPrintUnitPrice;
                dic["SubTitle"] = SubTitle;
                dic["LogoPath"] = LogoPath;
                dic["LogoWidth"] = LogoWidth;
                dic["LogoHeight"] = LogoHeight;
                dic["pageWidth"] = pageWidth;
                dic["pageHeight"] = pageHeight;
                dic["PrintTopMargin"] = PrintTopMargin;
                dic["PrintBottomMargin"] = PrintBottomMargin;
                dic["PrintTotalLines"] = PrintTotalLines;
                dic["show_sign"] = WebUtil.Authorization(context, "1101315");
                dic["PrintChargeTypeCount"] = PrintChargeTypeCount;
                dic["PrintRemark"] = PrintRemark;
                dic["ChargeMan"] = user.FinalRealName;
                dic["ChargeTime"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                dic["TempHistoryIDs"] = JsonConvert.SerializeObject(finalData.viewTempList.Select(p => p.TempHistoryID));
                dic["MoneyDaXie"] = Tools.CmycurD(money);
                diclist.Add(dic);
                count++;
            }
            WebUtil.WriteJson(context, new { status = true, list = diclist, ChargeItems = ChargeItems });
        }
        private void loadprintcuifei(HttpContext context)
        {
            string IDs = context.Request.Params["IDs"];
            DateTime StartTime = WebUtil.GetDateValue(context, "StartTime");
            DateTime EndTime = WebUtil.GetDateValue(context, "EndTime");
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(IDs).Distinct().ToList();
            var list = ViewRoomFee.GetViewRoomFeeListByRelationIDs(IDList, StartTime, EndTime, UserID: WebUtil.GetUser(context).UserID).Where(p => p.TotalCost > 0).ToArray();
            var main_list = list.Where(p => IDList.Contains(p.ID)).ToList();
            List<CuiFeiModel> templist = new List<CuiFeiModel>();
            List<int> RoomIDList = list.Select(p => p.RoomID).Distinct().ToList();
            var basic_list = Foresight.DataAccess.RoomBasicDetail.GetRoomBasicDetailListByRoomIDList(RoomIDList);
            foreach (var item in main_list)
            {
                bool can_continue = true;
                foreach (var temp in templist)
                {
                    if (temp.RelationIDList.Contains(item.RoomID))
                    {
                        can_continue = false;
                        break;
                    }
                }
                if (!can_continue)
                {
                    continue;
                }
                CuiFeiModel cuiFeiModel = new CuiFeiModel();
                cuiFeiModel.RoomID = item.RoomID;
                cuiFeiModel.AllParentID = item.AllParentID;
                var relationids = string.Join(",", basic_list.Where(p => p.RoomID == item.RoomID).Select(p => p.RelationIDs).ToArray()).Split(',');
                List<int> RelationIDList = new List<int>();
                foreach (var relationid in relationids)
                {
                    if (!string.IsNullOrEmpty(relationid))
                    {
                        int Relation_ID = 0;
                        int.TryParse(relationid, out Relation_ID);
                        if (Relation_ID > 0)
                        {
                            RelationIDList.Add(Relation_ID);
                        }
                    }
                }
                cuiFeiModel.RelationIDList = RelationIDList;
                var sub_list = list.Where(p => (p.RoomID == item.RoomID || RelationIDList.Contains(p.RoomID))).OrderBy(p =>
                {
                    if (p.RoomID == item.RoomID)
                    {
                        return "0";
                    }
                    return p.DefaultOrder;
                }).ThenBy(p => p.CalculateStartTime).ToList();
                foreach (var item2 in sub_list)
                {
                    if (item2.RoomID != item.RoomID)
                    {
                        item2.PrintRemark = "(关联资源" + item2.RoomName + ")";
                    }
                    else
                    {
                        item2.PrintRemark = item2.RemarkNote;
                    }
                }
                cuiFeiModel.list = sub_list.ToList();
                templist.Add(cuiFeiModel);
            }

            var newList = templist.Where((x, i) => templist.FindIndex(z => (z.RoomID == x.RoomID || z.RelationIDList.Contains(x.RoomID))) == i).ToArray();
            int MinProjectID = 0;
            int MaxProjectID = 0;
            if (list.Length > 0)
            {
                MinProjectID = list.Min(p => p.RoomID);
                MaxProjectID = list.Max(p => p.RoomID);
            }
            var sysConfig = SysConfig.GetSysConfigByName(SysConfigNameDefine.HideCuiShouCustomerName.ToString());
            SysConfig_ProjectDetail[] configProjectList = new SysConfig_ProjectDetail[] { };
            if (sysConfig != null)
            {
                configProjectList = SysConfig_ProjectDetail.Get_SysConfig_ProjectListByProjectIDList(MinProjectID, MaxProjectID).Where(p => p.ConfigID == sysConfig.ID).ToArray();
            }
            foreach (var item in newList)
            {
                var project = Foresight.DataAccess.Project.GetProject(item.RoomID);
                if (project != null)
                {
                    item.Remark = project.CuiFeiNote.Replace("\r\n", "<br/>").Replace("\n", "<br/>").Replace(" ", "&nbsp;");
                    item.PrintTitle = project.CuiShouPrintTitle;
                    item.PrintSubTitle = project.CuiShouPrintSubTitle;
                    item.PrintFont = string.IsNullOrEmpty(project.PrintFont) ? "100%" : project.PrintFont;
                    if (project.IsDefinePrintSize)
                    {
                        item.pageHeight = project.PrintHeight;
                    }
                    else
                    {
                        item.pageHeight = WebUtil.GetPrintHeight(project.PrintType);
                    }
                    item.PrintTopMargin = project.PrintTopMargin > 0 ? project.PrintTopMargin : 0;
                    item.PrintBottomMargin = project.PrintBottomMargin > 0 ? project.PrintBottomMargin : 0;
                    item.PrintTotalLines = project.PrintTotalLines > 0 ? project.PrintTotalLines : 6;
                    bool showCustomerName = SysConfig.IsShowCustomerCuiShouByAllParentID(configProjectList, item.AllParentID, item.RoomID, sysConfig);
                    if (showCustomerName)
                    {
                        item.OwnerName = string.Empty;
                        foreach (var item2 in item.list)
                        {
                            if (!string.IsNullOrEmpty(item.OwnerName))
                            {
                                break;
                            }
                            item.OwnerName = item2.FinalCustomerName;
                        }
                    }
                    else
                    {
                        item.OwnerName = "***";
                    }
                    item.FullName = project.FullName + "-" + project.Name;
                    foreach (var data in item.list)
                    {
                        item.TotalCost += data.TotalFinalCost;
                    }
                    item.IsPrintUnitPrice = project.IsPrintUnitPrice;
                }
                item.PrintTitle = string.IsNullOrEmpty(item.PrintTitle) ? WebUtil.GetCompany(context).CompanyName : item.PrintTitle;
                item.PrintSubTitle = string.IsNullOrEmpty(item.PrintSubTitle) ? "催费通知单" : item.PrintSubTitle;
            }
            var items = new
            {
                list = newList,
            };
            string result = JsonConvert.SerializeObject(items);
            context.Response.Write(result);
        }
        private void loadprintckout(HttpContext context)
        {
            string IDs = context.Request.Params["IDs"];
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(IDs);
            var ckincategories = Foresight.DataAccess.CKInCategory.GetCKInCategories();
            List<PrintCKOutModel> diclist = new List<PrintCKOutModel>();
            foreach (var ID in IDList)
            {
                var summary = CKProductOutSumary.GetCKProductOutSumary(ID);
                if (summary == null)
                {
                    continue;
                }
                var list = ViewCKProudctOutDetail.GetViewCKProudctOutDetailListBySummaryID(ID);
                if (list.Length > 0)
                {
                    summary.BelongTeamName = list[0].BelongTeamName;
                }
                int PrintLineCount = 6;
                if (summary.InCategoryID > 0)
                {
                    var incategory = ckincategories.FirstOrDefault(p => p.ID == summary.InCategoryID);
                    if (incategory != null)
                    {
                        PrintLineCount = incategory.PrintLineCount > 0 ? incategory.PrintLineCount : 6;
                    }
                }
                var printCKModel = new PrintCKOutModel();
                printCKModel.summary = summary;
                printCKModel.list = list;
                printCKModel.PrintLineCount = PrintLineCount;
                diclist.Add(printCKModel);
            }
            WebUtil.WriteJson(context, diclist);
        }
        private void loadprintckin(HttpContext context)
        {
            string IDs = context.Request.Params["IDs"];
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(IDs);
            List<PrintCKInModel> diclist = new List<PrintCKInModel>();
            var ckincategories = Foresight.DataAccess.CKInCategory.GetCKInCategories();
            foreach (var ID in IDList)
            {
                var summary = CKProductInSumary.GetCKProductInSumary(ID);
                if (summary == null)
                {
                    continue;
                }
                var list = ViewCKProudctInDetail.GetViewCKProudctInDetailListBySummaryID(ID);
                if (list.Length > 0)
                {
                    summary.ContractUserName = list[0].ContractName;
                }
                int PrintLineCount = 6;
                if (summary.InCategoryID > 0)
                {
                    var incategory = ckincategories.FirstOrDefault(p => p.ID == summary.InCategoryID);
                    if (incategory != null)
                    {
                        PrintLineCount = incategory.PrintLineCount > 0 ? incategory.PrintLineCount : 6;
                    }
                }
                var printCKModel = new PrintCKInModel();
                printCKModel.summary = summary;
                printCKModel.list = list;
                printCKModel.PrintLineCount = PrintLineCount;
                diclist.Add(printCKModel);
            }
            WebUtil.WriteJson(context, diclist);
        }
        private void createcuishou(HttpContext context)
        {
            string CompanyName = context.Request.Params["CompanyName"];
            string AddMan = context.Request.Params["AddMan"];
            string ChargeMan = context.Request.Params["ChargeMan"];
            int ChargeType = WebUtil.GetIntValue(context, "ChargeType");
            DateTime ChargeTime = WebUtil.GetDateValue(context, "ChargeTime");
            ChargeTime = ChargeTime > DateTime.MinValue ? ChargeTime : DateTime.Now;
            string Remark = context.Request.Params["Remark"];
            string IDs = context.Request.Params["IDs"];
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(IDs);
            DateTime StartTime = WebUtil.GetDateValue(context, "StartTime");
            DateTime EndTime = WebUtil.GetDateValue(context, "EndTime");
            var list = ViewRoomFee.GetViewRoomFeeListByIDs(IDList, StartTime, EndTime, UserID: WebUtil.GetUser(context).UserID);
            var main_list = list.Where(p => IDList.Contains(p.ID)).ToList();
            List<CuiFeiModel> templist = new List<CuiFeiModel>();
            List<int> RoomIDList = list.Select(p => p.RoomID).Distinct().ToList();
            var basic_list = Foresight.DataAccess.RoomBasicDetail.GetRoomBasicDetailListByRoomIDList(RoomIDList);
            foreach (var item in main_list)
            {
                bool can_continue = true;
                foreach (var temp in templist)
                {
                    if (temp.RelationIDList.Contains(item.RoomID))
                    {
                        can_continue = false;
                        break;
                    }
                }
                if (!can_continue)
                {
                    continue;
                }
                CuiFeiModel cuiFeiModel = new CuiFeiModel();
                cuiFeiModel.RoomID = item.RoomID;
                cuiFeiModel.AllParentID = item.AllParentID;
                var relationids = string.Join(",", basic_list.Where(p => p.RoomID == item.RoomID).Select(p => p.RelationIDs).ToArray()).Split(',');
                List<int> RelationIDList = new List<int>();
                foreach (var relationid in relationids)
                {
                    if (!string.IsNullOrEmpty(relationid))
                    {
                        int Relation_ID = 0;
                        int.TryParse(relationid, out Relation_ID);
                        if (Relation_ID > 0)
                        {
                            RelationIDList.Add(Relation_ID);
                        }
                    }
                }
                cuiFeiModel.RelationIDList = RelationIDList;
                var sub_list = list.Where(p => (p.RoomID == item.RoomID || RelationIDList.Contains(p.RoomID))).OrderBy(p =>
                {
                    if (p.RoomID == item.RoomID)
                    {
                        return "0";
                    }
                    return p.DefaultOrder;
                }).ThenBy(p => p.CalculateStartTime).ToList();
                foreach (var item2 in sub_list)
                {
                    if (item2.RoomID != item.RoomID)
                    {
                        item2.PrintRemark = "(关联资源" + item2.RoomName + ")";
                    }
                    else
                    {
                        item2.PrintRemark = item2.RemarkNote;
                    }
                }
                cuiFeiModel.list = sub_list.ToList();
                templist.Add(cuiFeiModel);
            }

            var newList = templist.Where((x, i) => templist.FindIndex(z => (z.RoomID == x.RoomID || z.RelationIDList.Contains(x.RoomID))) == i).ToArray();
            foreach (var item in newList)
            {
                var project = Foresight.DataAccess.Project.GetProject(item.RoomID);
                if (project == null)
                {
                    continue;
                }
                item.Remark = string.IsNullOrEmpty(Remark) ? project.CuiFeiNote : Remark;
                item.OwnerName = string.Empty;
                foreach (var item2 in item.list)
                {
                    if (!string.IsNullOrEmpty(item.OwnerName))
                    {
                        break;
                    }
                    item.OwnerName = item2.FinalCustomerName;
                }
                item.FullName = project.FullName + "-" + project.Name;
                item.FirstTitle = project.PrintTitle;
                item.SubTitle = project.PrintSubTitle;
                item.IsShowPrintNote = project.IsPrintNote;
                item.IsShowPrintCount = project.IsPrintCount;
                item.IsShowPrintCost = project.IsPrintCost;
                item.IsShowPrintDiscount = project.IsPrintDiscount;
                foreach (var data in item.list)
                {
                    item.TotalCost += data.CuiShouTotalCost;
                }
            }
            var relation_list = Foresight.DataAccess.RoomPhoneRelation.GetDefaultInChargeFeeRoomPhoneRelationList(list.Select(p => p.ID).ToList());
            int MinProjectID = 0;
            int MaxProjectID = 0;
            if (list.Length > 0)
            {
                MinProjectID = list.Min(p => p.RoomID);
                MaxProjectID = list.Max(p => p.RoomID);
            }
            var sysConfig = SysConfig.GetSysConfigByName(SysConfigNameDefine.RealCostCouZhengOn.ToString());
            SysConfig_ProjectDetail[] configProjectList = new SysConfig_ProjectDetail[] { };
            if (sysConfig != null)
            {
                configProjectList = SysConfig_ProjectDetail.Get_SysConfig_ProjectListByProjectIDList(MinProjectID, MaxProjectID).Where(p => p.ConfigID == sysConfig.ID).ToArray();
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    foreach (var item in newList)
                    {
                        PrintRoomFeeHistory printRoomFeeHistory = new PrintRoomFeeHistory();
                        bool isCouZheng = SysConfig.IsCouZhengOnByAllParentID(configProjectList, item.AllParentID, item.RoomID, sysConfig);
                        SavePrintRoomFeeHistory(item.RoomID, item.TotalCost, ChargeMan, item.FullName, item.OwnerName, ChargeType, ChargeTime, item.Remark, printRoomFeeHistory, helper, isCouZheng);
                        if (isCouZheng)
                        {
                            decimal weishumore = printRoomFeeHistory.RealCost - printRoomFeeHistory.Cost;
                            decimal finalweishu = PrintRoomFeeHistory.GetRoomWeiShuBalance(0, item.RoomID, helper);
                            if (finalweishu >= (1 - weishumore))
                            {
                                printRoomFeeHistory.WeiShuMore = 0;
                                printRoomFeeHistory.WeiShuConsume = (1 - weishumore);
                                printRoomFeeHistory.RealCost = (Math.Ceiling(printRoomFeeHistory.Cost) - 1);
                                printRoomFeeHistory.RealMoneyCost1 = printRoomFeeHistory.RealCost;
                            }
                            else
                            {
                                printRoomFeeHistory.WeiShuMore = weishumore;
                                printRoomFeeHistory.WeiShuConsume = 0;
                                printRoomFeeHistory.RealCost = Math.Ceiling(printRoomFeeHistory.Cost);
                                printRoomFeeHistory.RealMoneyCost1 = printRoomFeeHistory.RealCost;
                            }
                            var final = finalweishu + (printRoomFeeHistory.WeiShuMore - printRoomFeeHistory.WeiShuConsume);
                            printRoomFeeHistory.WeiShuBalance = (final > 0 ? final : 0);
                            printRoomFeeHistory.Save(helper);
                            //var final = finalweishu + (printRoomFeeHistory.WeiShuMore - printRoomFeeHistory.WeiShuConsume);
                            //string finalbalance = (final > 0 ? final : 0).ToString("F2");
                        }

                        item.PrintNumber = printRoomFeeHistory.PrintNumber;
                        foreach (var data in item.list)
                        {
                            item.TotalCost += data.TotalCost;
                            var roomFee = RoomFee.GetRoomFee(data.ID, helper);
                            if (roomFee == null)
                            {
                                helper.Rollback();
                                var result = new { status = false, msg = "收费项目不存在" };
                                WebUtil.WriteJson(context, result);
                                return;
                            }
                            if (roomFee.IsCharged)
                            {
                                helper.Rollback();
                                var result = new { status = false, msg = "收费项目已生成缴费通知单" };
                                WebUtil.WriteJson(context, result);
                                return;
                            }
                            int HistoryID = RoomFeeHistory.InsertRoomFeeHistoryByRoomID(roomFee.ID, AddMan, 5, helper);
                            var roomFeeHistory = RoomFeeHistory.GetRoomFeeHistory(HistoryID, helper);
                            roomFeeHistory.StartTime = data.CalculateCuiShouStartTime;
                            roomFeeHistory.EndTime = data.CalculateCuiShouEndTime;
                            roomFeeHistory.UseCount = data.CalculateUseCount;
                            roomFeeHistory.Cost = data.CuiShouTotalCost;
                            roomFeeHistory.RealCost = data.CuiShouTotalCost;
                            roomFeeHistory.TotalRealCost = data.CuiShouTotalCost;
                            roomFeeHistory.UnitPrice = data.CalculateUnitPrice;
                            roomFeeHistory.Discount = 0;
                            roomFeeHistory.RestCost = 0;
                            roomFeeHistory.TotalDiscountCost = 0;
                            roomFeeHistory.ChargeMan = ChargeMan;
                            roomFeeHistory.ChargeTime = ChargeTime;
                            roomFeeHistory.PrintID = printRoomFeeHistory.ID;
                            roomFeeHistory.IsCuiShou = true;
                            if (roomFee.DefaultChargeManID <= 0 && string.IsNullOrEmpty(roomFee.DefaultChargeManName))
                            {
                                if (roomFee.ContractID <= 0)
                                {
                                    var default_relation = relation_list.FirstOrDefault(p => p.RoomID == roomFee.RoomID && p.IsChargeFee);//默认缴费人员
                                    if (default_relation != null)
                                    {
                                        roomFeeHistory.DefaultChargeManID = default_relation.ID;
                                        roomFeeHistory.DefaultChargeManName = default_relation.RelationName;
                                    }
                                    else
                                    {
                                        default_relation = relation_list.FirstOrDefault(p => p.RoomID == roomFee.RoomID && p.IsChargeMan);//第一个缴费对象
                                        if (default_relation != null)
                                        {
                                            roomFeeHistory.DefaultChargeManID = default_relation.ID;
                                            roomFeeHistory.DefaultChargeManName = default_relation.RelationName;
                                        }
                                    }
                                }
                                else
                                {
                                    var contract = Foresight.DataAccess.Contract.GetContract(roomFee.ContractID, helper);
                                    roomFeeHistory.DefaultChargeManID = 0;
                                    roomFeeHistory.DefaultChargeManName = contract != null ? contract.RentName : string.Empty;
                                }
                            }
                            roomFeeHistory.Save(helper);
                            if (data.FeeType == 1)
                            {
                                if (data.CalculateCuiShouEndTime > DateTime.MinValue)
                                {
                                    roomFee.CuiShouStartTime = data.CalculateCuiShouEndTime.AddDays(1);
                                }
                                var viewChargeSummary = Foresight.DataAccess.ViewChargeSummary.GetViewChargeSummaryByChargeID(roomFee.ChargeID, helper);
                                DateTime CalculateEndTime = Web.APPCode.CommHelper.GetEndTime(viewChargeSummary, roomFee.CuiShouStartTime);
                                roomFee.CuiShouEndTime = CalculateEndTime;
                                roomFee.IsCharged = false;
                            }
                            else
                            {
                                roomFee.IsCharged = true;
                            }
                            roomFee.Save(helper);
                        }
                    }
                    helper.Commit();
                    var items = new { status = true };
                    context.Response.Write(JsonConvert.SerializeObject(items));
                    return;
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError("PrintHandler", "visit: createcuishou", ex);
                    var items = new { status = false, msg = "系统异常" };
                    context.Response.Write(JsonConvert.SerializeObject(items));
                }
            }
        }
        private void loadprintfeeorder(HttpContext context)
        {
            int ID = 0;
            int.TryParse(context.Request.Params["ID"], out ID);
            var roomFeeOrder = RoomFeeOrder.GetRoomFeeOrder(ID);
            if (roomFeeOrder == null)
            {
                context.Response.Write("{\"status\":true,\"iderror\":true}");
                return;
            }
            int TotalALLCount = 0;
            int TotalChargeCount = 0;
            int TotalChargeCancelCount = 0;
            int TotalChargeBackCount = 0;
            string ShouKuanStartNumber = string.Empty;
            string ShouKuanEndNumber = string.Empty;
            string FuKuanStartNumber = string.Empty;
            string FuKuanEndNumber = string.Empty;
            decimal ShouTotalRealCost = 0;
            decimal FuTotalRealCost = 0;
            decimal WeiShuTotalCost = 0;
            string ProjectName = string.Empty;
            TotalALLCount = roomFeeOrder.TotalCount < 0 ? 0 : roomFeeOrder.TotalCount;
            TotalChargeCount = roomFeeOrder.TotalPayCount < 0 ? 0 : roomFeeOrder.TotalPayCount;
            TotalChargeCancelCount = roomFeeOrder.TotalCancelCount < 0 ? 0 : roomFeeOrder.TotalCancelCount;
            TotalChargeBackCount = roomFeeOrder.TotalPayBackCount < 0 ? 0 : roomFeeOrder.TotalPayBackCount;
            ShouKuanStartNumber = roomFeeOrder.StartShouOrderNumber;
            ShouKuanEndNumber = roomFeeOrder.EndShouOrderNumber;
            FuKuanStartNumber = roomFeeOrder.StartFuOrderNumber;
            FuKuanEndNumber = roomFeeOrder.EndFuOrderNumber;
            ShouTotalRealCost = roomFeeOrder.ShouTotalCost < 0 ? 0 : roomFeeOrder.ShouTotalCost;
            FuTotalRealCost = roomFeeOrder.FuTotalCost < 0 ? 0 : roomFeeOrder.FuTotalCost;
            WeiShuTotalCost = roomFeeOrder.WeiShuTotalCost == decimal.MinValue ? 0 : roomFeeOrder.WeiShuTotalCost;
            if (!string.IsNullOrEmpty(roomFeeOrder.ProjectID))
            {
                int[] ProjectIDList = roomFeeOrder.ProjectID.Split(',').Select(p =>
                {
                    int _ID = 0;
                    int.TryParse(p, out _ID);
                    return _ID;

                }).ToArray();
                var projects = Foresight.DataAccess.Project.GetProjectListByIDs(ProjectIDList.ToList());
                var NameList = projects.Select(p => !string.IsNullOrEmpty(p.FullName) ? p.FullName : p.Name).ToArray();
                ProjectName = string.Join("|", NameList);
            }
            var ShouTypeSummaryList = new List<ChargeMoneyTypeDetails>();
            var ShouChargeSummaryList = new List<ChargeSummaryDetails>();
            var FuChargeSummaryList = new List<ChargeSummaryDetails>();
            var FuTypeSummaryList = new List<ChargeMoneyTypeDetails>();
            DataGrid dg = ChargeMoneyTypeDetails.GetHistorySummaryGroupByRoomFeeOrderID(roomFeeOrder.ID, WebUtil.GetUser(context).UserID);
            ChargeMoneyTypeDetails[] list = dg.rows as ChargeMoneyTypeDetails[];
            ShouTypeSummaryList = list.Where(p => p.RealCost > 0).ToList();
            List<int> ChargeStateList = new List<int>();
            ChargeStateList.Add(1);
            ChargeStateList.Add(4);
            dg = ChargeSummaryDetails.GetHistorySummaryGroupByRoomFeeOrderID(roomFeeOrder.ID, ChargeStateList);
            ChargeSummaryDetails[] list2 = dg.rows as ChargeSummaryDetails[];
            ShouChargeSummaryList = list2.Where(p => p.RealCost > 0).ToList();
            ChargeStateList = new List<int>();
            ChargeStateList.Add(3);
            ChargeStateList.Add(6);
            ChargeStateList.Add(7);
            dg = ChargeSummaryDetails.GetHistorySummaryGroupByRoomFeeOrderID(roomFeeOrder.ID, ChargeStateList);
            ChargeSummaryDetails[] list3 = dg.rows as ChargeSummaryDetails[];
            FuChargeSummaryList = list3.Where(p => p.RealCost > 0).ToList();

            dg = ChargeMoneyTypeDetails.GetDepositSummaryGroupByRoomFeeOrderID(roomFeeOrder.ID);
            ChargeMoneyTypeDetails[] list4 = dg.rows as ChargeMoneyTypeDetails[];
            FuTypeSummaryList = list4.Where(p => p.RealCost > 0).ToList();

            int totalCount1 = Math.Max(ShouTypeSummaryList.Count, ShouChargeSummaryList.Count);
            int totalCount2 = Math.Max(FuTypeSummaryList.Count, FuChargeSummaryList.Count);
            int totalCount = Math.Max(totalCount1, totalCount2);

            StringBuilder builder = new StringBuilder();
            int totalcolumns = 6;
            #region 打印内容
            builder.Append("<div style='height:287mm;max-height:287mm;'>");
            builder.Append("<table class='info'");
            builder.Append("<tr>");
            builder.Append("<td colspan='" + totalcolumns + "' style=\"text-align: center; padding: 5px 10px; font-size: 18px; \"'>");
            builder.Append("交款单");
            builder.Append("</td>");
            builder.Append("</tr>");
            builder.Append("<tr>");
            builder.Append("<td style='width:15%;'>项目名称</td>");
            builder.Append("<td style='width:20%;'>" + ProjectName + "</td>");
            builder.Append("<td style='width:10%;'>交款人</td>");
            builder.Append("<td style='width:20%;'>" + roomFeeOrder.OrderUserMan + "</td>");
            builder.Append("<td style='width:15%;'>交款日期</td>");
            builder.Append("<td style='width:20%;'>" + roomFeeOrder.OrderTime.ToString("yyyy-MM-dd HH:mm:ss") + "</td>");
            builder.Append("</tr>");
            builder.Append("<tr>");
            builder.Append("<td style='width:15%;'>交款区间 起始</td>");
            builder.Append("<td style='width:20%;'>" + roomFeeOrder.ChargeStartTime.ToString("yyyy-MM-dd HH:mm:ss") + "</td>");
            builder.Append("<td style='width:10%;'>终止</td>");
            builder.Append("<td style='width:20%;'>" + roomFeeOrder.ChargeEndTime.ToString("yyyy-MM-dd HH:mm:ss") + "</td>");
            builder.Append("<td style='width:15%;'>操作员</td>");
            builder.Append("<td style='width:20%;'>" + roomFeeOrder.Operator + "</td>");
            builder.Append("</tr>");
            builder.Append("</table>");
            builder.Append("<table class=\"result1\">");
            builder.Append("<tr>");
            builder.Append("<td colspan=\"4\" style=\"width: 50%; text-align: center;\">收款情况</td>");
            builder.Append("<td colspan=\"4\" style=\"width: 50%; text-align: center;\">付款情况</td>");
            builder.Append("</tr>");
            builder.Append("<tr>");
            builder.Append("<td style='width:10%;'>收款单号</td>");
            builder.Append("<td colspan=\"3\" style=\"width: 40%\">");
            builder.Append("<div style=\"display: inline-table; width: 100%;\">");
            builder.Append("起始 " + ShouKuanStartNumber);
            builder.Append("</div>");
            builder.Append("<div style=\"display: inline-table;\">");
            builder.Append("终止 " + ShouKuanEndNumber);
            builder.Append("</div>");
            builder.Append("</td>");
            builder.Append("<td style='width:10%;'>付款单号</td>");
            builder.Append("<td colspan=\"3\" style=\"width: 40%\">");
            builder.Append("<div style=\"display: inline-table; width: 100%;\">");
            builder.Append("起始 " + FuKuanStartNumber);
            builder.Append("</div>");
            builder.Append("<div style=\"display: inline-table;\">");
            builder.Append("终止 " + FuKuanEndNumber);
            builder.Append("</div>");
            builder.Append("</td>");
            builder.Append("</tr>");
            builder.Append("<tr>");
            builder.Append("<td style='width:10%;'>收款总金额</td>");
            builder.Append("<td colspan=\"3\" style=\"width: 40%\">");
            builder.Append("￥" + ShouTotalRealCost);
            builder.Append("</td>");
            builder.Append("<td style='width:10%;'>付款总金额</td>");
            builder.Append("<td style=\"width: 15%\">");
            builder.Append("￥" + FuTotalRealCost);
            builder.Append("</td>");
            builder.Append("<td style='width:10%;'>尾数差额</td>");
            builder.Append("<td style=\"width: 15%\">");
            builder.Append("￥" + WeiShuTotalCost);
            builder.Append("</td>");
            builder.Append("</tr>");
            for (int i = 0; i < totalCount; i++)
            {
                builder.Append("<tr>");
                if (i < ShouTypeSummaryList.Count)
                {
                    builder.Append("<td style='width:10%;'>" + ShouTypeSummaryList[i].ChargeTypeName + "</td>");
                    builder.Append("<td style='width:10%;'>￥" + ShouTypeSummaryList[i].RealCost + "</td>");
                }
                else
                {
                    builder.Append("<td style='width:10%;'></td>");
                    builder.Append("<td style='width:10%;'></td>");
                }
                if (i < ShouChargeSummaryList.Count)
                {
                    builder.Append("<td style='width:10%;'>" + ShouChargeSummaryList[i].Name + "</td>");
                    builder.Append("<td style='width:20%;'>￥" + ShouChargeSummaryList[i].RealCost + "</td>");
                }
                else
                {
                    builder.Append("<td style='width:10%;'></td>");
                    builder.Append("<td style='width:20%;'></td>");
                }
                if (i < FuTypeSummaryList.Count)
                {
                    builder.Append("<td style='width:10%;'>" + FuTypeSummaryList[i].ChargeTypeName + "</td>");
                    builder.Append("<td style='width:15%;'>￥" + FuTypeSummaryList[i].RealCost + "</td>");
                }
                else
                {
                    builder.Append("<td style='width:10%;'></td>");
                    builder.Append("<td style='width:15%;'></td>");
                }
                if (i < FuChargeSummaryList.Count)
                {
                    builder.Append("<td style='width:10%;'>" + FuChargeSummaryList[i].Name + "</td>");
                    builder.Append("<td style='width:15%;'>￥" + FuChargeSummaryList[i].RealCost + "</td>");
                }
                else
                {
                    builder.Append("<td style='width:10%;'></td>");
                    builder.Append("<td style='width:15%;'></td>");
                }
                builder.Append("</tr>");
            }
            builder.Append("<tr>");
            builder.Append("<td style='width:10%;'>审核人</td>");
            builder.Append("<td style='width:10%;'>");
            builder.Append(roomFeeOrder.ApproveMan);
            builder.Append("</td>");
            builder.Append("<td style='width:10%;'>审核日期</td>");
            builder.Append("<td style='width:20%;'>");
            builder.Append((roomFeeOrder.ApproveTime == DateTime.MinValue ? "" : roomFeeOrder.ApproveTime.ToString("yyyy-MM-dd HH:mm:ss")));
            builder.Append("</td>");
            builder.Append("<td style='width:10%;'>审核说明</td>");
            builder.Append("<td style='width:40%;' colspan=\"3\">");
            builder.Append(roomFeeOrder.ApproveRemark);
            builder.Append("</td>");
            builder.Append("</tr>");
            builder.Append("</table>");
            builder.Append("</div>");
            #endregion
            string resulthtml = builder.ToString();
            var items = new { html = resulthtml };
            context.Response.Write(JsonConvert.SerializeObject(items));
        }
        private void SavePrintRoomFeeHistory(int RoomID, decimal RealCost, string ChargeMan, string RoomFullName, string RoomOwnerName, int ChargeType, DateTime ChargeTime, string Remark, PrintRoomFeeHistory printRoomFeeHistory, SqlHelper helper, bool isCouZheng)
        {
            int OrderNumberID = 0;
            string PrintNumber = Foresight.DataAccess.PrintRoomFeeHistory.GetLastestPrintNumber(Foresight.DataAccess.OrderTypeNameDefine.chargefee.ToString(), RoomID, helper, out OrderNumberID);
            //decimal Cost = decimal.Parse(context.Request.Params["Cost"]);
            printRoomFeeHistory.PrintNumber = PrintNumber;
            printRoomFeeHistory.OrderNumberID = OrderNumberID;
            printRoomFeeHistory.Cost = RealCost;
            printRoomFeeHistory.CostCapital = Tools.CmycurD(RealCost);
            if (isCouZheng)
            {
                printRoomFeeHistory.RealCost = Math.Ceiling(RealCost);
                printRoomFeeHistory.RealMoneyCost1 = Math.Ceiling(RealCost);
            }
            else
            {
                printRoomFeeHistory.RealCost = RealCost;
                printRoomFeeHistory.RealMoneyCost1 = RealCost;
            }
            printRoomFeeHistory.PreChargeMoney = 0;
            printRoomFeeHistory.ChargeBackMoney = 0;
            printRoomFeeHistory.RealMoneyCost2 = 0;
            printRoomFeeHistory.DiscountMoney = 0;
            printRoomFeeHistory.ChargeMan = ChargeMan;
            printRoomFeeHistory.ChargeTime = ChargeTime > DateTime.MinValue ? ChargeTime : DateTime.Now;
            printRoomFeeHistory.ChageType1 = ChargeType;
            printRoomFeeHistory.ChageType2 = 0;
            if (printRoomFeeHistory.AddTime == DateTime.MinValue)
            {
                printRoomFeeHistory.AddTime = DateTime.Now;
            }
            printRoomFeeHistory.WeiShuMore = 0;
            printRoomFeeHistory.WeiShuConsume = 0;
            printRoomFeeHistory.RoomFullName = RoomFullName;
            printRoomFeeHistory.RoomOwnerName = RoomOwnerName;
            printRoomFeeHistory.Remark = Remark;
            printRoomFeeHistory.PrintRemark = Remark;
            printRoomFeeHistory.Save(helper);

        }
        #region Comm
        private PrintRoomFeeHistory SaveChargeGuaranteeBackPrintRoomFeeHistory(HttpContext context, PrintRoomFeeHistory printRoomFeeHistory)
        {
            if (printRoomFeeHistory == null)
            {
                printRoomFeeHistory = new PrintRoomFeeHistory();
            }
            string AddMan = context.Request["AddMan"];
            string PrintNumber = context.Request["PrintNumber"];
            string ChargeMan = context.Request["ChargeMan"];
            DateTime ChargeTime = WebUtil.GetDateValue(context, "ChargeTime");
            string Remark = context.Request["Remark"];
            decimal Cost = decimal.Parse(context.Request.Params["Cost"]);
            int ChargeMoneyType = WebUtil.GetIntValue(context, "ChargeMoneyType");
            string FullName = context.Request["FullName"];
            string MoneyDaXie = context.Request["MoneyDaXie"];
            int OrderNumberID = WebUtil.GetIntValue(context, "OrderNumberID");
            printRoomFeeHistory.PrintNumber = PrintNumber;
            printRoomFeeHistory.OrderNumberID = OrderNumberID;
            printRoomFeeHistory.Cost = Cost;
            printRoomFeeHistory.RealCost = Cost;
            printRoomFeeHistory.Remark = Remark;
            printRoomFeeHistory.AddMan = AddMan;
            printRoomFeeHistory.AddTime = DateTime.Now;
            printRoomFeeHistory.ChargeMan = ChargeMan;
            printRoomFeeHistory.ChargeTime = ChargeTime == DateTime.MinValue ? DateTime.Now : ChargeTime;
            printRoomFeeHistory.ChageType1 = ChargeMoneyType;
            printRoomFeeHistory.IsCancel = false;
            printRoomFeeHistory.FullName = FullName;
            printRoomFeeHistory.CostCapital = MoneyDaXie;
            printRoomFeeHistory.RoomFullName = context.Request["RoomFullName"];
            printRoomFeeHistory.RoomOwnerName = context.Request["RoomOwnerName"];
            return printRoomFeeHistory;
        }
        #endregion
        public class CuiFeiModel
        {
            public int RoomID { get; set; }
            public string AllParentID { get; set; }
            public int PrintID { get; set; }
            public int ContractID { get; set; }
            public List<ViewContractChargeSummary> contractfeelist { get; set; }
            public List<ViewRoomFee> list { get; set; }
            public List<ViewRoomFeeHistory> historylist { get; set; }
            public string OwnerName { get; set; }
            public string FullName { get; set; }
            public decimal TotalCost { get; set; }
            public decimal RealCost { get; set; }
            public string Remark { get; set; }
            public string PrintNumber { get; set; }
            public bool IsShowPrintCount { get; set; }
            public bool IsShowPrintNote { get; set; }
            public bool IsShowPrintCost { get; set; }
            public bool IsShowPrintDiscount { get; set; }
            public string FirstTitle { get; set; }
            public string SubTitle { get; set; }
            public string ChargeMan { get; set; }
            public string ChargeTime { get; set; }
            public string ChargeTypeName { get; set; }
            public bool WeiShuCouZheng { get; set; }
            public decimal weishubalance { get; set; }
            public int OrderNumberType { get; set; }
            public string CostCapital { get; set; }
            public List<int> RelationIDList { get; set; }
            public string PrintTitle { get; set; }
            public string PrintSubTitle { get; set; }
            public string PrintFont { get; set; }
            public decimal pageHeight { get; set; }
            public decimal PrintTopMargin { get; set; }
            public decimal PrintBottomMargin { get; set; }
            public int PrintTotalLines { get; set; }
            public bool IsPrintUnitPrice { get; set; }
        }
        public class PrintCKInModel
        {
            public int PrintLineCount { get; set; }
            public CKProductInSumary summary { get; set; }
            public ViewCKProudctInDetail[] list { get; set; }
        }
        public class PrintCKOutModel
        {
            public int PrintLineCount { get; set; }
            public CKProductOutSumary summary { get; set; }
            public ViewCKProudctOutDetail[] list { get; set; }
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}