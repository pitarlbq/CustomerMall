using Foresight.DataAccess;
using Foresight.DataAccess.Framework;
using Foresight.DataAccess.Ui;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.SessionState;
using Utility;
using Web.APPCode;
using Web.Model;

namespace Web.Handler
{
    /// <summary>
    /// AnalysisHandler 的摘要说明
    /// </summary>
    public class AnalysisHandler : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string visit = context.Request.Params["visit"];
            if (string.IsNullOrEmpty(visit))
            {
                LogHelper.WriteDebug("AnalysisHandler", "visit为空");
                context.Response.Write(null);
                return;
            }
            visit = visit.ToLower();
            try
            {
                switch (visit)
                {
                    case "getrealcostsearch":
                        getrealcostsearch(context);
                        break;
                    case "gettochargesearch":
                        gettochargesearch(context);
                        break;
                    case "saveroomfeenote":
                        saveroomfeenote(context);
                        break;
                    case "loadtochargesummarybychargename":
                        LoadToChargeSummaryByChargename(context);
                        break;
                    case "loadrealcostsummarybychargename":
                        LoadRealCostSummaryByChargeName(context);
                        break;
                    case "loadrealcostsummarybychargetype":
                        LoadRealCostSummaryByChargetype(context);
                        break;
                    case "loadtotalcostsummarybychargename":
                        LoadTotalCostSummaryByChargename(context);
                        break;
                    case "loadcreateorderparams":
                        loadcreateorderparams(context);
                        break;
                    case "searchorder":
                        searchorder(context);
                        break;
                    case "saveorder":
                        saveorder(context);
                        break;
                    case "loadchargefeeorderlist":
                        loadchargefeeorderlist(context);
                        break;
                    case "saveorderapprove":
                        saveorderapprove(context);
                        break;
                    case "deleteorder":
                        deleteorder(context);
                        break;
                    case "cancelfeeorder":
                        cancelfeeorder(context);
                        break;
                    case "loadanalysissummary":
                        loadanalysissummary(context);
                        break;
                    case "loadskkbsummary":
                        loadskkbsummary(context);
                        break;
                    case "loadsummarysearchparams":
                        loadsummarysearchparams(context);
                        break;
                    case "loadqfkbsummary":
                        loadqfkbsummary(context);
                        break;
                    case "getshoufeilv":
                        getshoufeilv(context);
                        break;
                    case "loadzckbsummary":
                        loadzckbsummary(context);
                        break;
                    case "loadruzhustaticcolumn":
                        loadruzhustaticcolumn(context);
                        break;
                    case "loadroomruzhustaticlist":
                        loadroomruzhustaticlist(context);
                        break;
                    case "loadprechargesummarybyproject":
                        loadprechargesummarybyproject(context);
                        break;
                    case "loadprechargesummarybychargename":
                        loadprechargesummarybychargename(context);
                        break;
                    case "loadprechargesummarybyroom":
                        loadprechargesummarybyroom(context);
                        break;
                    case "loadchaobiaoanalysisbyproject":
                        loadchaobiaoanalysisbyproject(context);
                        break;
                    case "loadchaobiaoanalysisbyroom":
                        loadchaobiaoanalysisbyroom(context);
                        break;
                    case "loadchaobiaoanalysisbycharge":
                        loadchaobiaoanalysisbycharge(context);
                        break;
                    case "loadshoufeilvquanzebyproject":
                        loadshoufeilvquanzebyproject(context);
                        break;
                    case "loadshoufeilvquanzebycharge":
                        loadshoufeilvquanzebycharge(context);
                        break;
                    case "loadshoufeilvquanzebychargemoneytype":
                        loadshoufeilvquanzebychargemoneytype(context);
                        break;
                    case "loadshoufeilvquanzebyroom":
                        loadshoufeilvquanzebyroom(context);
                        break;
                    case "loadchaobiaoanalysislist":
                        loadchaobiaoanalysislist(context);
                        break;
                    case "loaddepositsummarybychargename":
                        loaddepositsummarybychargename(context);
                        break;
                    case "loaddepositsummarybyproject":
                        loaddepositsummarybyproject(context);
                        break;
                    case "loaddepositsummarybyroom":
                        loaddepositsummarybyroom(context);
                        break;
                    case "getshoufeilvsummarycolumns":
                        getshoufeilvsummarycolumns(context);
                        break;
                    case "loadshoufeilvsummaryanalysic":
                        loadshoufeilvsummaryanalysic(context);
                        break;
                    case "searchordernew":
                        searchordernew(context);
                        break;
                    case "searchorderbyids":
                        searchorderbyids(context);
                        break;
                    case "loadtochargesummarybychargenamev2":
                        LoadToChargeSummaryByChargenameV2(context);
                        break;
                    case "getdepositsearchparams":
                        getdepositsearchparams(context);
                        break;
                    case "getprochargesearchparams":
                        getprochargesearchparams(context);
                        break;
                    case "loadwarninginfo":
                        loadwarninginfo(context);
                        break;
                    case "loadmonthanalysisgrid":
                        loadmonthanalysisgrid(context);
                        break;
                    case "getmonthfeeanalysisparams":
                        getmonthfeeanalysisparams(context);
                        break;
                    case "getmonthfeeanalysiscolumns":
                        getmonthfeeanalysiscolumns(context);
                        break;
                    case "loadshourusummaryanalysis":
                        loadshourusummaryanalysis(context);
                        break;
                    case "getrealcostmingxicolumns":
                        getrealcostmingxicolumns(context);
                        break;
                    case "loadrealcostmingxianalysic":
                        loadrealcostmingxianalysic(context);
                        break;
                    case "loadzhichusummaryanalysis":
                        loadzhichusummaryanalysis(context);
                        break;
                    case "loadrealcostanalysissummary":
                        loadrealcostanalysissummary(context);
                        break;
                    case "loadprojectcountanalysis":
                        loadprojectcountanalysis(context);
                        break;
                    case "getmallcustomeranalysis":
                        getmallcustomeranalysis(context);
                        break;
                    case "getmallsaleanalysis":
                        getmallsaleanalysis(context);
                        break;
                    case "getmallorderanalysis":
                        getmallorderanalysis(context);
                        break;
                    case "loadshareorderanlaysis":
                        loadshareorderanlaysis(context);
                        break;
                    default:
                        WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "Unkown Visit: " + visit);
                        break;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("AnalysisHandler", "visit: " + visit, ex);
                context.Response.Write("{\"status\":false}");
            }
        }
        private void loadshareorderanlaysis(HttpContext context)
        {
            try
            {
                int Status = WebUtil.GetIntValue(context, "Status");
                string Keywords = context.Request.Params["Keywords"];
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                DateTime StartTime = WebUtil.GetDateValue(context, "StartTime");
                DateTime EndTime = WebUtil.GetDateValue(context, "EndTime");
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                int OrderStatus = WebUtil.GetIntValue(context, "OrderStatus");
                DataGrid dg = Mall_OrderAnalysis.GetShareMall_OrderAnalysisGrid(Keywords, StartTime, EndTime, startRowIndex, pageSize, OrderStatus);
                WebUtil.WriteJson(context, dg);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.WriteError("AnalysisHandler", "loadshareorderanlaysis", ex);
                WebUtil.WriteJson(context, new Foresight.DataAccess.Ui.DataGrid());
            }
        }
        private void getmallorderanalysis(HttpContext context)
        {
            DateTime StartTime = WebUtil.GetDateValue(context, "StartTime");
            DateTime EndTime = WebUtil.GetDateValue(context, "EndTime");
            var order_list = Mall_Order.GetMall_OrderListByTime(StartTime, EndTime, OrderStatus: 0);
            order_list = order_list.Where(p => p.OrderStatus == 1 || p.OrderStatus == 3 || p.OrderStatus == 5).ToArray();
            int order_readypay_count = 0;
            int order_readyship_count = 0;
            int order_complete_count = 0;
            int order_total_count = 0;
            int order_product_count = 0;
            decimal order_total_cost = 0;
            var x_array = new string[] { };
            var y_array = new int[] { };
            if (order_list.Length > 0)
            {
                order_readypay_count = order_list.Where(p => p.OrderStatus == 1).ToArray().Length;
                order_readyship_count = order_list.Where(p => p.OrderStatus == 5).ToArray().Length;
                order_complete_count = order_list.Where(p => p.OrderStatus == 3).ToArray().Length;
                order_total_count = order_readypay_count + order_readyship_count + order_complete_count;
                var complete_order_list = order_list.Where(p => p.OrderStatus == 3).ToArray();
                var order_items = Mall_OrderItem.GetAnalysisMall_OrderItemListByOrderIDList(complete_order_list.Select(p => p.ID).ToList());
                var my_order_items = order_items.GroupBy(p => p.ProductID).Select(p => (new { name = p.Key, count = p.Count() })).ToArray();
                order_product_count = my_order_items.Length;
                order_total_cost = complete_order_list.Sum(p => p.TotalCost);
                double totaldays = 0;
                if (EndTime > DateTime.MinValue && StartTime > DateTime.MinValue)
                {
                    totaldays = (EndTime - StartTime).TotalDays;
                }
                string time_format = string.Empty;
                if (totaldays <= 31)
                {
                    time_format = "yyyy-MM-dd";
                }
                else
                {
                    time_format = "yyyy-MM";
                }
                var my_query_order_list = order_list.GroupBy(p => p.AddTime.ToString(time_format)).Select(p => (new { name = p.Key, count = p.Count(), cost = p.Sum(q => q.TotalCost) })).ToArray();
                x_array = my_query_order_list.Select(p => p.name).ToArray();
                y_array = my_query_order_list.Select(p => p.count).ToArray();
            }
            var form = new { order_readypay_count = order_readypay_count.ToString("0") + "笔", order_readyship_count = order_readyship_count.ToString("0") + "笔", order_complete_count = order_complete_count.ToString("0") + "笔", order_total_count = order_total_count.ToString("0") + "笔", order_product_count = order_product_count.ToString("0") + "个", order_total_cost = "￥" + order_total_cost.ToString("0.00") };
            WebUtil.WriteJson(context, new { status = true, form = form, x_array = x_array, y_array = y_array });
        }
        private void getmallsaleanalysis(HttpContext context)
        {
            DateTime StartTime = WebUtil.GetDateValue(context, "StartTime");
            DateTime EndTime = WebUtil.GetDateValue(context, "EndTime");
            var order_list = Mall_Order.GetMall_OrderListByTime(StartTime, EndTime);
            decimal totalcost = 0;
            int totalcount = 0;
            int totalusercount = 0;
            decimal customer_per_cost = 0;
            var x_array = new string[] { };
            var y_array = new decimal[] { };
            if (order_list.Length > 0)
            {
                totalcost = order_list.Sum(p => p.TotalCost);
                totalcount = order_list.Length;
                var my_order_list = order_list.GroupBy(p => p.UserID).Select(p => (new { name = p.Key, count = p.Count() })).ToArray();
                totalusercount = my_order_list.Length;
                customer_per_cost = Math.Round((totalcost / totalusercount), 2, MidpointRounding.AwayFromZero);
                double totaldays = 0;
                if (EndTime > DateTime.MinValue && StartTime > DateTime.MinValue)
                {
                    totaldays = (EndTime - StartTime).TotalDays;
                }
                string time_format = string.Empty;
                if (totaldays <= 31)
                {
                    time_format = "yyyy-MM-dd";
                }
                else
                {
                    time_format = "yyyy-MM";
                }
                var my_query_order_list = order_list.GroupBy(p => p.AddTime.ToString(time_format)).Select(p => (new { name = p.Key, count = p.Count(), cost = p.Sum(q => q.TotalCost) })).ToArray();
                x_array = my_query_order_list.Select(p => p.name).ToArray();
                y_array = my_query_order_list.Select(p => p.cost).ToArray();
            }
            var form = new { totalcost = "￥" + totalcost.ToString("0.00"), totalcount = totalcount.ToString("0") + "笔", customer_per_cost = "￥" + customer_per_cost.ToString("0.00") };
            WebUtil.WriteJson(context, new { status = true, form = form, x_array = x_array, y_array = y_array });
        }
        private void getmallcustomeranalysis(HttpContext context)
        {
            DateTime StartTime = WebUtil.GetDateValue(context, "StartTime");
            DateTime EndTime = WebUtil.GetDateValue(context, "EndTime");
            var order_list = Mall_Order.GetMall_OrderListByTime(StartTime, EndTime);
            var shoppingcart_list = Mall_ShoppingCart.GetMall_ShoppingCartListByTime(StartTime, EndTime);
            var user_list = User.GetAPPCustomerUserListByTime(StartTime, EndTime);
            int TotalUserCount = 0;
            decimal BuyUnitPrice = 0;
            int NewBuyCount = 0;
            int BackBuyCount = 0;
            string BackBuyPercent = "0%";
            int PotentialCount = 0;
            var x_array = new string[] { };
            var y_array = new int[] { };
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
            if (user_list.Length > 0)
            {
                double totaldays = 0;
                if (EndTime > DateTime.MinValue && StartTime > DateTime.MinValue)
                {
                    totaldays = (EndTime - StartTime).TotalDays;
                }
                string time_format = string.Empty;
                if (totaldays <= 31)
                {
                    time_format = "yyyy-MM-dd";
                }
                else
                {
                    time_format = "yyyy-MM";
                }
                var my_user_list = user_list.GroupBy(p => p.CreateTime.ToString(time_format)).Select(p => (new { name = p.Key, count = p.Count() })).ToArray();
                x_array = my_user_list.Select(p => p.name).ToArray();
                y_array = my_user_list.Select(p => p.count).ToArray();
            }
            var form = new { customer_total_count = TotalUserCount.ToString("0") + "人", customer_return_percent = BackBuyPercent, customer_unitprice = "￥" + BuyUnitPrice.ToString("0.00"), customer_maybe_count = PotentialCount.ToString("0") + "人", customer_new_count = NewBuyCount.ToString("0") + "人", customer_return_count = BackBuyCount.ToString("0") + "人" };
            WebUtil.WriteJson(context, new { status = true, form = form, x_array = x_array, y_array = y_array });
        }
        private void loadprojectcountanalysis(HttpContext context)
        {
            string RoomIDs = context.Request["RoomIDs"];
            List<int> RoomIDList = new List<int>();
            if (!string.IsNullOrEmpty(RoomIDs))
            {
                RoomIDList = JsonConvert.DeserializeObject<List<int>>(RoomIDs);
            }
            string ProjectIDs = context.Request["ProjectIDs"];
            List<int> ProjectIDList = new List<int>();
            if (RoomIDList.Count == 0)
            {
                if (!string.IsNullOrEmpty(ProjectIDs))
                {
                    ProjectIDList = JsonConvert.DeserializeObject<List<int>>(ProjectIDs).Where(p => p != 1).ToList();
                }
                ProjectIDList = WebUtil.GetMyProjects(WebUtil.GetUser(context).UserID, ProjectIDList).Where(p => p.ID != 1).Select(p => p.ID).ToList();
            }
            DateTime StartTime = WebUtil.GetDateValue(context, "StartChargeTime");
            DateTime EndTime = WebUtil.GetDateValue(context, "EndChargeTime");
            bool IsAnalysisQuery = WebUtil.GetIntValue(context, "IsAnalysisQuery") == 1;
            var fee_list = RoomFeeAnalysis.GetRoomFeeAnalysisListByRoomID(RoomIDList, ProjectIDList, StartTime, EndTime, new int[] { }, -1, new List<int>(), true, true, 0, UserID: WebUtil.GetUser(context).UserID, RequireOrderBy: false, IncludeRelation: false, IsAnalysisQuery: IsAnalysisQuery, OnlyWuye: true);
            ViewRoomFeeHistoryDetail[] history_list = ViewRoomFeeHistoryDetail.GetViewRoomFeeHistoryDetailList(RoomIDList, DateTime.MinValue, DateTime.MinValue, StartTime, EndTime, ProjectIDList, ChargeIDList: new List<int>(), UserID: WebUtil.GetUser(context).UserID, RequireOrderBy: false, IsAnalysisQuery: IsAnalysisQuery, OnlyWuye: true, requireRelationRoom: true);
            var list = new List<Dictionary<string, object>>();
            var project_list = WebUtil.GetMyXiaoQuProjects(WebUtil.GetUser(context).UserID);
            List<int> EqualIDList = new List<int>();
            List<int> InIDList = new List<int>();
            ProjectIDList.AddRange(RoomIDList);
            Project.GetMyProjectListByProjectIDList(ProjectIDList, out EqualIDList, out InIDList);
            bool IsTimeNotNull = true;
            if (StartTime == DateTime.MinValue || EndTime == DateTime.MinValue)
            {
                IsTimeNotNull = false;
            }
            foreach (var project in project_list)
            {
                if (!EqualIDList.Contains(project.ID) && !InIDList.Contains(project.ID))
                {
                    continue;
                }
                var dic = new Dictionary<string, object>();
                dic["ProjectName"] = project.Name;
                int YingShou_Count = 0;
                decimal ShiShou_Count = 0;
                var my_fee_list = fee_list.Where(p => p.FinalAllParentID.Contains("," + project.ID + ",") && p.TotalCost > 0).ToArray();
                var my_history_list = history_list.Where(p => p.FinalAllParentID.Contains("," + project.ID + ",") && p.TotalCost > 0).ToList();
                List<int> My_ChargeIDList = new List<int>();
                List<int> My_RoomIDList = new List<int>();
                foreach (var item in my_fee_list)
                {
                    if (My_RoomIDList.Contains(item.RoomID) && My_ChargeIDList.Contains(item.ChargeID))
                    {
                        continue;
                    }
                    My_RoomIDList.Add(item.RoomID);
                    My_ChargeIDList.Add(item.ChargeID);
                    YingShou_Count++;
                }
                foreach (var item in my_history_list)
                {
                    if (My_RoomIDList.Contains(item.RoomID) && My_ChargeIDList.Contains(item.ChargeID))
                    {
                        continue;
                    }
                    My_RoomIDList.Add(item.RoomID);
                    My_ChargeIDList.Add(item.ChargeID);
                    YingShou_Count++;
                }
                if (IsTimeNotNull)
                {
                    ShiShou_Count = my_history_list.Sum(p => p.CalculateStartEndPercent);
                }
                else
                {
                    ShiShou_Count = YingShou_Count;
                }
                decimal ShiShou_Amount = my_history_list.Sum(p => p.MonthTotalCost);
                decimal WeiShou_Amount = my_fee_list.Sum(p => p.TotalFinalCost);
                decimal YingShou_Amount_1 = my_fee_list.Sum(p => p.TotalCost);
                decimal YingShou_Amount_2 = ViewRoomFeeHistoryBase.GetViewRoomFeeHistoryTotalCost(my_history_list: my_history_list.ToArray());
                dic["ShiShou_Count"] = ShiShou_Count;
                dic["ShiShou_Amount"] = ShiShou_Amount;
                dic["YingShou_Count"] = YingShou_Count;
                dic["YingShou_Amount"] = YingShou_Amount_1 + YingShou_Amount_2;
                YingShou_Count = YingShou_Count > 0 ? YingShou_Count : 1;
                dic["ShouFeiLv_Count"] = Math.Round(ShiShou_Count / YingShou_Count, 2, MidpointRounding.AwayFromZero) * 100 + "%";
                decimal YingShou_Amount = (YingShou_Amount_1 + YingShou_Amount_2);
                YingShou_Amount = YingShou_Amount > 0 ? YingShou_Amount : 1;
                dic["ShouFeiLv_Amount"] = Math.Round(ShiShou_Amount / YingShou_Amount, 2, MidpointRounding.AwayFromZero) * 100 + "%";
                list.Add(dic);
            }
            var dg = new Foresight.DataAccess.Ui.DataGrid();
            dg.rows = list;
            dg.page = 1;
            dg.total = list.Count;
            bool canexport = WebUtil.GetBoolValue(context, "canexport");
            if (canexport)
            {
                string downloadurl = string.Empty;
                string error = string.Empty;
                bool status = APPCode.ExportHelper.DownloadProjectCountAnalysis(dg, out downloadurl, out error);
                WebUtil.WriteJson(context, new { status = status, downloadurl = downloadurl, error = error });
                return;
            }
            WebUtil.WriteJson(context, dg);
        }
        private void loadrealcostanalysissummary(HttpContext context)
        {
            string RoomIDs = context.Request["RoomIDs"];
            List<int> RoomIDList = new List<int>();
            if (!string.IsNullOrEmpty(RoomIDs))
            {
                RoomIDList = JsonConvert.DeserializeObject<List<int>>(RoomIDs);
            }
            string ProjectIDs = context.Request["ProjectIDs"];
            List<int> ProjectIDList = new List<int>();
            if (RoomIDList.Count == 0)
            {
                if (!string.IsNullOrEmpty(ProjectIDs))
                {
                    ProjectIDList = JsonConvert.DeserializeObject<List<int>>(ProjectIDs).Where(p => p != 1).ToList();
                }
                ProjectIDList = WebUtil.GetMyProjects(WebUtil.GetUser(context).UserID, ProjectIDList).Where(p => p.ID != 1).Select(p => p.ID).ToList();
            }
            DateTime StartTime = WebUtil.GetDateValue(context, "StartChargeTime");
            DateTime EndTime = WebUtil.GetDateValue(context, "EndChargeTime");
            string ChargeIDs = context.Request.Params["ChargeIDs"];
            int[] ChargeIDList = new int[] { };
            if (!string.IsNullOrEmpty(ChargeIDs))
            {
                ChargeIDList = JsonConvert.DeserializeObject<int[]>(ChargeIDs).Where(p => p != 0).ToArray();
            }
            string ChargeMan = context.Request["ChargeMan"];
            decimal TotalPrintCost = 0;
            bool IsAnalysisQuery = WebUtil.GetIntValue(context, "IsAnalysisQuery") == 1;
            ViewRoomFeeHistoryDetail[] history_list = ViewRoomFeeHistoryDetail.GetViewRoomFeeHistoryDetailList(out TotalPrintCost, RoomIDList, StartTime, EndTime, DateTime.MinValue, DateTime.MinValue, ProjectIDList, ChargeIDList: ChargeIDList.ToList(), UserID: WebUtil.GetUser(context).UserID, RequireOrderBy: false, ChargeMan: ChargeMan, IncludePrintTotalCost: true, IsAnalysisQuery: IsAnalysisQuery);
            var ChargeList = Foresight.DataAccess.ChargeSummary.GetChargeSummaries();
            List<Dictionary<string, object>> item_list = new List<Dictionary<string, object>>();
            decimal ShiShou_HeJi = 0;
            decimal DiscountCost_HeJi = 0;
            var item = new Dictionary<string, object>();
            foreach (var ChargeSummary in ChargeList)
            {
                item = new Dictionary<string, object>();
                item["ChargeName"] = ChargeSummary.Name;
                var my_history_list = history_list.Where(p => p.ChargeID == ChargeSummary.ID).ToArray();
                decimal ShiShou = my_history_list.Where(p => p.RealCost > 0).Sum(p => p.RealCost);
                decimal DiscountCost = my_history_list.Where(p => p.Discount > 0).Sum(p => p.Discount);
                if (ShiShou == 0 && DiscountCost == 0)
                {
                    continue;
                }
                ShiShou_HeJi += ShiShou;
                DiscountCost_HeJi += DiscountCost;
                item["ShiShou"] = ShiShou;
                item["FormatShiShou"] = Utility.Tools.FormatMoney(ShiShou);
                item["TotalDiscount"] = DiscountCost;
                item["FormatTotalDiscount"] = Utility.Tools.FormatMoney(DiscountCost);
                item["ALLPrintCost"] = "";
                item_list.Add(item);
            }
            List<Dictionary<string, object>> footer_list = new List<Dictionary<string, object>>();
            item = new Dictionary<string, object>();
            item["ChargeName"] = "合计";
            item["ShiShou"] = ShiShou_HeJi;
            item["FormatShiShou"] = Utility.Tools.FormatMoney(ShiShou_HeJi);
            item["TotalDiscount"] = DiscountCost_HeJi;
            item["FormatTotalDiscount"] = Utility.Tools.FormatMoney(DiscountCost_HeJi);
            item["ALLPrintCost"] = TotalPrintCost;
            item["FormatALLPrintCost"] = Utility.Tools.FormatMoney(TotalPrintCost);
            footer_list.Add(item);
            var dg = new Foresight.DataAccess.Ui.DataGrid();
            dg.rows = item_list;
            dg.page = 1;
            dg.total = item_list.Count;
            dg.footer = footer_list;
            bool canexport = WebUtil.GetBoolValue(context, "canexport");
            if (canexport)
            {
                string downloadurl = string.Empty;
                string error = string.Empty;
                bool status = APPCode.ExportHelper.DownLoadRealCostAnalysisSummaryData(dg, out downloadurl, out error);
                WebUtil.WriteJson(context, new { status = status, downloadurl = downloadurl, error = error });
                return;
            }
            WebUtil.WriteJson(context, dg);
        }
        private void loadzhichusummaryanalysis(HttpContext context)
        {
            DateTime StartTime = DateTime.MinValue;
            DateTime EndTime = DateTime.MinValue;
            if (!string.IsNullOrEmpty(context.Request["StartTime"]))
            {
                StartTime = Convert.ToDateTime(context.Request["StartTime"]);
            }
            if (!string.IsNullOrEmpty(context.Request["EndTime"]))
            {
                EndTime = Convert.ToDateTime(context.Request["EndTime"]);
            }
            string RoomIDs = context.Request["RoomIDs"];
            List<int> RoomIDList = new List<int>();
            if (!string.IsNullOrEmpty(RoomIDs))
            {
                RoomIDList = JsonConvert.DeserializeObject<List<int>>(RoomIDs);
            }
            string ProjectIDs = context.Request["ProjectIDs"];
            List<int> ProjectIDList = new List<int>();
            if (RoomIDList.Count == 0)
            {
                if (!string.IsNullOrEmpty(ProjectIDs))
                {
                    ProjectIDList = JsonConvert.DeserializeObject<List<int>>(ProjectIDs).Where(p => p != 1).ToList();
                }
                ProjectIDList = WebUtil.GetMyProjects(WebUtil.GetUser(context).UserID, ProjectIDList).Where(p => p.ID != 1).Select(p => p.ID).ToList();
            }
            List<int> EqualProjectIDList = new List<int>();
            List<int> InProjectIDList = new List<int>();
            if (RoomIDList.Count == 0)
            {
                List<int> MyProjectIDList = new List<int>();
                if (!string.IsNullOrEmpty(ProjectIDs))
                {
                    MyProjectIDList = JsonConvert.DeserializeObject<List<int>>(ProjectIDs).Where(p => p != 1).ToList();
                }
                Web.APPCode.CacheHelper.GetMyProjectListByUserID(WebUtil.GetUser(context).UserID, out EqualProjectIDList, out InProjectIDList, ProjectIDList: MyProjectIDList);
                if (MyProjectIDList.Count == 0)
                {
                    if (EqualProjectIDList.Count > 0)
                    {
                        EqualProjectIDList.Add(0);
                    }
                }
                else
                {
                    string ALLProjectIDs = context.Request.Params["ALLProjectIDs"];
                    List<int> ALLProjectIDList = new List<int>();
                    if (!string.IsNullOrEmpty(ALLProjectIDs))
                    {
                        ALLProjectIDList = JsonConvert.DeserializeObject<List<int>>(ALLProjectIDs).Where(p => p != 1).ToList();
                    }
                    if (ALLProjectIDList.Count > 0)
                    {
                        EqualProjectIDList = ALLProjectIDList;
                    }
                }
            }
            var payserviceList = Foresight.DataAccess.PayService.GetPayServiceList(RoomIDList, StartTime, EndTime, UserID: WebUtil.GetUser(context).UserID, EqualProjectIDList: EqualProjectIDList, InProjectIDList: InProjectIDList);
            var categorys = Foresight.DataAccess.PaySummary.GetPaySummaries().ToArray();
            var dic_list = new List<Dictionary<string, object>>();
            foreach (var item in categorys)
            {
                var my_list = payserviceList.Where(p => p.PaySummaryID == item.ID).ToArray();
                if (my_list.Length == 0)
                {
                    continue;
                }
                var dic = new Dictionary<string, object>();
                dic["Name"] = item.PayName;
                dic["TotalCost"] = my_list.Sum(p => p.PayMoney);
                dic_list.Add(dic);
            }
            List<int> ChargeStateList = new List<int>();
            ChargeStateList.Add(3);
            ChargeStateList.Add(6);
            var historylist = ViewRoomFeeHistoryDetail.GetViewRoomFeeHistoryDetail2List(RoomIDList, ProjectIDList, StartTime, EndTime, new List<int>(), UserID: WebUtil.GetUser(context).UserID, ChargeStateList: ChargeStateList);
            var chargesummarys = ChargeSummary.GetChargeSummaries().ToArray();
            foreach (var item in chargesummarys)
            {
                var my_historylist = historylist.Where(p => p.ChargeID == item.ID).ToArray();
                if (my_historylist.Length == 0)
                {
                    continue;
                }
                var dic = new Dictionary<string, object>();
                dic["Name"] = item.Name;
                dic["TotalCost"] = my_historylist.Sum(p => p.MonthTotalCost);
                dic_list.Add(dic);
            }
            var dg = new Foresight.DataAccess.Ui.DataGrid();
            dg.rows = dic_list;
            dg.total = dic_list.Count;
            dg.page = 1;
            bool canexport = WebUtil.GetBoolValue(context, "canexport");
            if (canexport)
            {
                string downloadurl = string.Empty;
                string error = string.Empty;
                bool status = APPCode.ExportHelper.DownLoadShouRuZhiChuPayServiceData(dg, out downloadurl, out error);
                WebUtil.WriteJson(context, new { status = status, downloadurl = downloadurl, error = error });
                return;
            }
            WebUtil.WriteJson(context, dg);
        }
        private void loadrealcostmingxianalysic(HttpContext context)
        {
            string RoomType = context.Request["RoomType"];
            if (RoomType.Equals("Project"))
            {
                loadrealcostmingxianalysicbyproject(context);
                return;
            }
            else
            {
                loadrealcostmingxianalysicbyroom(context);
            }
        }
        private void loadrealcostmingxianalysicbyproject(HttpContext context)
        {
        }
        private void loadrealcostmingxianalysicbyroom(HttpContext context)
        {
            string PageCode = Utility.EnumModel.AnalysisChargeFieldPageCode.RealCostMingXinAnalysis.ToString();
            var chargesummary_list = Foresight.DataAccess.ChargeSummaryField.GetChargeSummaryFields(PageCode).Where(p => (!p.IsHide) || p.ChargeFieldID < 0).OrderBy(p => { return p.SortOrder < 0 ? int.MaxValue : p.SortOrder; }).ToArray();
            if (chargesummary_list.Length == 0)
            {
                WebUtil.WriteJson(context, new Foresight.DataAccess.Ui.DataGrid());
                return;
            }
            var SummaryIDList = chargesummary_list.Select(p => p.ID).ToArray();
            string RoomIDs = context.Request["RoomIDs"];
            List<int> RoomIDList = new List<int>();
            if (!string.IsNullOrEmpty(RoomIDs))
            {
                RoomIDList = JsonConvert.DeserializeObject<List<int>>(RoomIDs);
            }
            string ProjectIDs = context.Request["ProjectIDs"];
            List<int> ProjectIDList = new List<int>();
            if (RoomIDList.Count == 0)
            {
                if (!string.IsNullOrEmpty(ProjectIDs))
                {
                    ProjectIDList = JsonConvert.DeserializeObject<List<int>>(ProjectIDs).Where(p => p != 1).ToList();
                }
                ProjectIDList = WebUtil.GetMyProjects(WebUtil.GetUser(context).UserID, ProjectIDList).Where(p => p.ID != 1).Select(p => p.ID).ToList();
            }
            DateTime StartTime = WebUtil.GetDateValue(context, "StartTime");
            DateTime EndTime = WebUtil.GetDateValue(context, "EndTime");
            DateTime StartChargeTime = WebUtil.GetDateValue(context, "StartChargeTime");
            DateTime EndChargeTime = WebUtil.GetDateValue(context, "EndChargeTime");
            string page = context.Request.Form["page"];
            string rows = context.Request.Form["rows"];
            page = string.IsNullOrEmpty(page) ? "1" : page;
            rows = string.IsNullOrEmpty(rows) ? "50" : rows;
            long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
            int pageSize = int.Parse(rows);
            string Keywords = context.Request["keywords"];
            var dg = Foresight.DataAccess.ViewRoomBasic.GetViewRoomBasicGrid(ProjectIDList, RoomIDList, Keywords, string.Empty, startRowIndex, pageSize);
            var room_list = dg.rows as Foresight.DataAccess.ViewRoomBasic[];
            RoomIDList = room_list.Select(p => p.RoomID).ToList();
            ProjectIDList = new List<int>();
            var feehistory_list = Foresight.DataAccess.ViewRoomFeeHistoryDetail.GetViewRoomFeeHistoryDetailList(RoomIDList, StartChargeTime, EndChargeTime, StartTime, EndTime, UserID: WebUtil.GetUser(context).UserID, RequireMerge: true);
            Dictionary<string, object> footer = new Dictionary<string, object>();
            footer["FullName"] = "合计";
            feehistory_list = feehistory_list.Where(p => p.ChargeState == 1).ToArray();
            var items = room_list.Select(room =>
            {
                var dic = new Dictionary<string, object>();
                dic["FullName"] = room.FullName;
                dic["RoomName"] = room.Name;
                dic["RelationName"] = room.RelationName;
                decimal heji_RealCost = 0;
                foreach (var summary in chargesummary_list)
                {
                    decimal realcost = feehistory_list.Where(p => p.RoomID == room.RoomID && p.ChargeID == summary.ID).Sum(p => p.MonthTotalCost);
                    dic[summary.ID + "_RealCost"] = realcost > 0 ? realcost : 0;
                    heji_RealCost += realcost > 0 ? realcost : 0;
                    decimal footer_realcost = 0;
                    if (footer.ContainsKey(summary.ID + "_RealCost"))
                    {
                        footer_realcost = Convert.ToDecimal(footer[summary.ID + "_RealCost"]);
                    }
                    footer[summary.ID + "_RealCost"] = footer_realcost + (realcost > 0 ? realcost : 0);
                }
                dic["heji_RealCost"] = heji_RealCost;
                decimal footer_heji_realcost = 0;
                if (footer.ContainsKey("heji_RealCost"))
                {
                    footer_heji_realcost = Convert.ToDecimal(footer["heji_RealCost"]);
                }
                footer["heji_RealCost"] = footer_heji_realcost + heji_RealCost;
                return dic;
            });
            dg.rows = items;
            List<Dictionary<string, object>> footerlist = new List<Dictionary<string, object>>();
            footerlist.Add(footer);
            dg.footer = footerlist;
            WebUtil.WriteJson(context, dg);
        }
        private void getrealcostmingxicolumns(HttpContext context)
        {
            string PageCode = context.Request["PageCode"];
            PageCode = string.IsNullOrEmpty(PageCode) ? Utility.EnumModel.AnalysisChargeFieldPageCode.RealCostMingXinAnalysis.ToString() : PageCode;
            var chargesummary_list = Foresight.DataAccess.ChargeSummaryField.GetChargeSummaryFields(PageCode).Where(p => (!p.IsHide) || p.ChargeFieldID < 0).OrderBy(p => { return p.SortOrder < 0 ? int.MaxValue : p.SortOrder; }).ToArray();
            if (chargesummary_list.Length == 0)
            {
                WebUtil.WriteJson(context, new { status = false, msg = "请先配置" });
            }
            StringBuilder columns = new StringBuilder("[[");
            columns.Append("{ field: 'FullName', title: '资源位置', width: 200, },");
            columns.Append("{ field: 'RoomName', title: '房间信息', width: 100 },");
            columns.Append("{ field: 'RelationName', title: '客户名称', width: 100 },");
            StringBuilder sub_columns = new StringBuilder("],[");
            for (int i = 0; i < chargesummary_list.Length; i++)
            {
                var item = chargesummary_list[i];
                int colspancount = 0;
                columns.Append("{field: '" + item.ID + "_RealCost', formatter: formatCostFormat, title: '" + item.Name + "', width: 100},");
                colspancount++;
                if (i == chargesummary_list.Length - 1)
                {
                    columns.Append("{field: 'heji_RealCost', formatter: formatCostFormat, title: '实收合计', width: 100},");
                }
            }
            columns.Append("]]");
            var items = new
            {
                status = true,
                columns = columns.ToString(),
            };
            WebUtil.WriteJson(context, items);
        }
        private void loadshourusummaryanalysis(HttpContext context)
        {
            string RoomIDs = context.Request["RoomIDs"];
            List<int> RoomIDList = new List<int>();
            if (!string.IsNullOrEmpty(RoomIDs))
            {
                RoomIDList = JsonConvert.DeserializeObject<List<int>>(RoomIDs);
            }
            string ProjectIDs = context.Request["ProjectIDs"];
            List<int> ProjectIDList = new List<int>();
            if (RoomIDList.Count == 0)
            {
                if (!string.IsNullOrEmpty(ProjectIDs))
                {
                    ProjectIDList = JsonConvert.DeserializeObject<List<int>>(ProjectIDs).Where(p => p != 1).ToList();
                }
                ProjectIDList = WebUtil.GetMyProjects(WebUtil.GetUser(context).UserID, ProjectIDList).Where(p => p.ID != 1).Select(p => p.ID).ToList();
            }
            DateTime StartTime = WebUtil.GetDateValue(context, "StartChargeTime");
            DateTime EndTime = WebUtil.GetDateValue(context, "EndChargeTime");
            string ChargeIDs = context.Request.Params["ChargeIDs"];
            int[] ChargeIDList = new int[] { };
            if (!string.IsNullOrEmpty(ChargeIDs))
            {
                ChargeIDList = JsonConvert.DeserializeObject<int[]>(ChargeIDs).Where(p => p != 0).ToArray();
            }
            string ChargeMan = context.Request["ChargeMan"];
            bool IncludeHeJiRow = false;
            if (context.Request["IncludeHeJiRow"] != null)
            {
                bool.TryParse(context.Request["IncludeHeJiRow"].ToString(), out IncludeHeJiRow);
            }
            bool IsAnalysisQuery = WebUtil.GetIntValue(context, "IsAnalysisQuery") == 1;
            var fee_list = RoomFeeAnalysis.GetRoomFeeAnalysisListByRoomID(RoomIDList, ProjectIDList, DateTime.MinValue, DateTime.MinValue, ChargeIDList, -1, new List<int>(), true, true, 0, UserID: WebUtil.GetUser(context).UserID, RequireOrderBy: false, IncludeRelation: false, IsAnalysisQuery: IsAnalysisQuery);
            ViewRoomFeeHistoryDetail[] history_list = new ViewRoomFeeHistoryDetail[] { };
            decimal TotalPrintCost = 0;
            if (IncludeHeJiRow)
            {
                history_list = ViewRoomFeeHistoryDetail.GetViewRoomFeeHistoryDetailList(out TotalPrintCost, RoomIDList, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, ProjectIDList, ChargeIDList: ChargeIDList.ToList(), UserID: WebUtil.GetUser(context).UserID, RequireOrderBy: false, ChargeMan: ChargeMan, IncludePrintTotalCost: IncludeHeJiRow, IsAnalysisQuery: IsAnalysisQuery);
            }
            else
            {
                history_list = ViewRoomFeeHistoryDetail.GetViewRoomFeeHistoryDetailList(RoomIDList, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, ProjectIDList, ChargeIDList: ChargeIDList.ToList(), UserID: WebUtil.GetUser(context).UserID, RequireOrderBy: false, ChargeMan: ChargeMan, IsAnalysisQuery: IsAnalysisQuery);
            }
            var ChargeList = Foresight.DataAccess.ChargeSummary.GetChargeSummaries();

            List<Dictionary<string, object>> item_list = new List<Dictionary<string, object>>();
            decimal ShiShou_HeJi = 0;
            decimal ChongDi_HeJi = 0;
            decimal DiscountCost_HeJi = 0;
            decimal YiShou_HeJi = 0;
            decimal BenQiShouYiHou_HeJi = 0;
            decimal BenQiShouLiShi_HeJi = 0;
            decimal QianFei_HeJi = 0;
            decimal YingShou_HeJi = 0;
            decimal LiShiQianFei_HeJi = 0;
            var item = new Dictionary<string, object>();
            foreach (var ChargeSummary in ChargeList)
            {
                var my_fee_list = fee_list.Where(p => p.ChargeID == ChargeSummary.ID).ToArray();
                var my_fee_history_list = history_list.Where(p => p.ChargeID == ChargeSummary.ID).ToArray();
                if (my_fee_list.Length == 0 && my_fee_history_list.Length == 0)
                {
                    continue;
                }
                item = new Dictionary<string, object>();
                item["ChargeName"] = ChargeSummary.Name;
                var my_fee_list1 = my_fee_list;
                if (StartTime > DateTime.MinValue || EndTime > DateTime.MinValue)
                {
                    my_fee_list1 = RoomFeeAnalysis.GetFinalRoomFeeAnalysisList(my_fee_list, DateTime.MinValue, StartTime);
                }
                var my_fee_history_list2 = ViewRoomFeeHistoryDetail.GetViewRoomFeeHistoryDetailDictionary(my_fee_history_list, StartTime, EndTime);

                var my_fee_list2 = RoomFeeAnalysis.GetFinalRoomFeeAnalysisDictionary(my_fee_list1, StartTime, EndTime);

                decimal ShiShou = my_fee_history_list2.Where(p => Convert.ToInt32(p["ChargeState"]) == 1).Sum(p => Convert.ToDecimal(p["MonthTotalCost"]));
                decimal ChongDi = my_fee_history_list2.Where(p => Convert.ToInt32(p["ChargeState"]) == 4).Sum(p => Convert.ToDecimal(p["MonthTotalCost"]));
                decimal DiscountCost = my_fee_history_list2.Sum(p => Convert.ToDecimal(p["MonthDiscountCost"]));
                decimal YiShou = ShiShou + ChongDi + DiscountCost;
                decimal BenQiShouYiHou = my_fee_history_list2.Sum(q => Convert.ToDecimal(q["BenqiYuShou"]));
                decimal BenQiShouLiShi = my_fee_history_list2.Sum(q => Convert.ToDecimal(q["BenqiShouLishi"]));
                item["FormatShiShou"] = Utility.Tools.FormatMoney(ShiShou);
                item["FormatYiShou"] = Utility.Tools.FormatMoney(YiShou);
                item["FormatTotalDiscount"] = Utility.Tools.FormatMoney(DiscountCost);
                item["FormatBenQiShouYiHou"] = Utility.Tools.FormatMoney(BenQiShouYiHou);
                item["FormatBenQiShouLiShi"] = Utility.Tools.FormatMoney(BenQiShouLiShi);
                decimal QianFei = my_fee_list2.Sum(p => Convert.ToDecimal(p["TotalFinalCost"]));
                decimal YingShou = QianFei + YiShou;
                item["FormatYingShou"] = Utility.Tools.FormatMoney(YingShou);
                DateTime NewEndTime = DateTime.MinValue;
                decimal LiShiQianFei = 0;
                if (StartTime > DateTime.MinValue)
                {
                    NewEndTime = StartTime;
                }
                else if (EndTime > DateTime.MinValue)
                {
                    NewEndTime = EndTime;
                }
                if (NewEndTime > DateTime.MinValue)
                {
                    my_fee_list2 = RoomFeeAnalysis.GetRoomFeeAnalysisDictionary(my_fee_list, DateTime.MinValue, NewEndTime);
                }
                LiShiQianFei = my_fee_list2.Sum(p => Convert.ToDecimal(p["TotalFinalCost"]));
                item["FormatLiShiQianFei"] = Utility.Tools.FormatMoney(LiShiQianFei);

                item["ShiShou"] = ShiShou;
                item["YiShou"] = YiShou;
                item["TotalDiscount"] = DiscountCost;
                item["BenQiShouYiHou"] = BenQiShouYiHou;
                item["BenQiShouLiShi"] = BenQiShouLiShi;
                item["YingShou"] = YingShou;
                item["LiShiQianFei"] = LiShiQianFei;
                item["ALLPrintCost"] = TotalPrintCost;

                item_list.Add(item);
                ShiShou_HeJi += ShiShou;
                ChongDi_HeJi += ChongDi;
                DiscountCost_HeJi += DiscountCost;
                YiShou_HeJi += YiShou;
                BenQiShouYiHou_HeJi += BenQiShouYiHou;
                BenQiShouLiShi_HeJi += BenQiShouLiShi;
                QianFei_HeJi += QianFei;
                YingShou_HeJi += YingShou;
                LiShiQianFei_HeJi += LiShiQianFei;
            }
            List<Dictionary<string, object>> footer_list = new List<Dictionary<string, object>>();
            if (IncludeHeJiRow)
            {
                item = new Dictionary<string, object>();
                item["ChargeName"] = "合计";

                item["FormatShiShou"] = Utility.Tools.FormatMoney(ShiShou_HeJi);
                item["FormatYiShou"] = Utility.Tools.FormatMoney(YiShou_HeJi);
                item["FormatTotalDiscount"] = Utility.Tools.FormatMoney(DiscountCost_HeJi);
                item["FormatBenQiShouYiHou"] = Utility.Tools.FormatMoney(BenQiShouYiHou_HeJi);
                item["FormatBenQiShouLiShi"] = Utility.Tools.FormatMoney(BenQiShouLiShi_HeJi);
                item["FormatYingShou"] = Utility.Tools.FormatMoney(YingShou_HeJi);
                item["FormatLiShiQianFei"] = Utility.Tools.FormatMoney(LiShiQianFei_HeJi);
                item["FormatALLPrintCost"] = Utility.Tools.FormatMoney(TotalPrintCost);

                item["ShiShou"] = ShiShou_HeJi;
                item["YiShou"] = YiShou_HeJi;
                item["TotalDiscount"] = DiscountCost_HeJi;
                item["BenQiShouYiHou"] = BenQiShouYiHou_HeJi;
                item["BenQiShouLiShi"] = BenQiShouLiShi_HeJi;
                item["YingShou"] = YingShou_HeJi;
                item["LiShiQianFei"] = LiShiQianFei_HeJi;
                item["ALLPrintCost"] = TotalPrintCost;

                footer_list.Add(item);
            }
            var dg = new Foresight.DataAccess.Ui.DataGrid();
            dg.rows = item_list;
            dg.page = 1;
            dg.total = item_list.Count;
            dg.footer = footer_list;
            var canexport = WebUtil.GetBoolValue(context, "canexport");
            if (canexport)
            {
                string downloadurl = string.Empty;
                string error = string.Empty;
                bool status = APPCode.ExportHelper.DownLoadShouruSummaryAnalysisData(dg, out downloadurl, out error);
                WebUtil.WriteJson(context, new { status = status, downloadurl = downloadurl, error = error });
                return;
            }
            WebUtil.WriteJson(context, dg);
        }
        private void getmonthfeeanalysiscolumns(HttpContext context)
        {
            string PageCode = Utility.EnumModel.AnalysisChargeFieldPageCode.MonthFeeAnalysis.ToString();
            var chargesummary_list = Foresight.DataAccess.AnalysisChargeField.GetMonthFeeAnalysisColumns().Where(p => !p.IsHide && (!p.IsHideReal || !p.IsHideRest || !p.IsHideTotal || !p.IsHideDiscount)).OrderBy(p => { return p.SortOrder < 0 ? int.MaxValue : p.SortOrder; }).ToArray();
            StringBuilder columns = new StringBuilder("[[");
            StringBuilder sub_columns = new StringBuilder("],[");
            StringBuilder sub_columns2 = new StringBuilder("],[");
            bool sub_columns2_added = false;
            int rowspan = 2;
            columns.Append("{ field: 'FullName', title: '资源位置', width: 200, rowspan: " + (rowspan + 1) + " },");
            columns.Append("{ field: 'RoomName', title: '资源编号', width: 100, rowspan: " + (rowspan + 1) + "},");
            columns.Append("{ field: 'DefaultChargeManName', title: '客户信息', width: 100, rowspan: " + (rowspan + 1) + " },");
            columns.Append("{ field: 'Name', title: '收费项目', width: 100, rowspan: " + (rowspan + 1) + " },");
            for (int i = 0; i < chargesummary_list.Length; i++)
            {
                var item = chargesummary_list[i];
                int colspancount = 0;
                if (!item.IsHideTotal)
                {
                    sub_columns.Append("{field: '" + item.ChargeID + "_YingShou', title: '应收', width: 100, rowspan: " + rowspan + "},");
                    colspancount++;
                }
                int yishou_count = 0;
                if (!item.IsHideReal || !item.IsHideChargeFee || !item.IsHideDiscount)
                {
                    if (!item.IsHideReal)
                    {
                        colspancount++;
                        yishou_count++;
                        sub_columns2.Append("{field: '" + item.ChargeID + "_YiShou', title: '实收', width: 100},");
                    }
                    if (!item.IsHideChargeFee)
                    {
                        colspancount++;
                        yishou_count++;
                        sub_columns2.Append("{field: '" + item.ChargeID + "_ChongDi', title: '冲抵', width: 100},");
                    }
                    if (!item.IsHideDiscount)
                    {
                        colspancount++;
                        yishou_count++;
                        sub_columns2.Append("{field: '" + item.ChargeID + "_JianMian', title: '减免', width: 100},");
                    }
                    sub_columns2_added = true;
                    sub_columns.Append("{title: '已收', width: 100, colspan: " + yishou_count + "},");
                }
                if (!item.IsHideRest)
                {
                    sub_columns.Append("{field: '" + item.ChargeID + "_WeiShou', title: '未收', width: 100, rowspan: " + rowspan + "},");
                    colspancount++;
                }
                if (colspancount == 0)
                {
                    continue;
                }
                columns.Append("{title: '" + item.ChargeID + "月份', colspan: " + colspancount + " },");
            }
            columns.Append("{ title: '合计', width: 100, colspan: 6 },");
            sub_columns.Append("{field: 'Heji_YingShou', title: '累计应收', width: 100, rowspan: " + rowspan + "},");
            sub_columns.Append("{title: '累计已收', width: 100, colspan: 3},");
            sub_columns.Append("{field: 'Heji_WeiShou', title: '累计未收', width: 100, rowspan: " + rowspan + "},");
            sub_columns.Append("{field: 'Heji_LiShiQianFei', title: '历史欠费', width: 100, rowspan: " + rowspan + "},");
            //sub_columns.Append("{field: 'Heji_ShouFeiLv', title: '累计收费率', width: 100, rowspan: " + rowspan + "},");
            sub_columns2.Append("{field: 'Heji_YiShou', title: '累计实收', width: 100},");
            sub_columns2.Append("{field: 'Heji_ChongDi', title: '累计冲抵', width: 100},");
            sub_columns2.Append("{field: 'Heji_JianMian', title: '累计减免', width: 100},");
            columns.Append(sub_columns.ToString());
            if (sub_columns2_added)
            {
                columns.Append(sub_columns2.ToString());
            }
            columns.Append("]]");
            var items = new
            {
                status = true,
                columns = columns.ToString(),
            };
            WebUtil.WriteJson(context, items);
        }
        private void getmonthfeeanalysisparams(HttpContext context)
        {
            var summarys = Foresight.DataAccess.ChargeSummary.GetChargeSummaries();
            var summary_items = summarys.Select(p =>
            {
                var item = new { ID = p.ID, Name = p.Name };
                return item;
            });
            int defalt_year = 2016;
            var year_items = new List<Dictionary<string, object>>();
            for (int i = 0; i < 30; i++)
            {
                var year = defalt_year + i;
                var dic = new Dictionary<string, object>();
                dic["ID"] = year;
                dic["Name"] = year + "年";
                year_items.Add(dic);
            }
            WebUtil.WriteJson(context, new { summarys = summary_items, years = year_items });
        }
        private void loadmonthanalysisgrid(HttpContext context)
        {
            int UserID = WebUtil.GetUser(context).UserID;
            string page = context.Request.Form["page"];
            string rows = context.Request.Form["rows"];
            page = string.IsNullOrEmpty(page) ? "1" : page;
            rows = string.IsNullOrEmpty(rows) ? "50" : rows;
            long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
            int pageSize = int.Parse(rows);
            int currentcount = WebUtil.GetIntValue(context, "currentcount");
            if (startRowIndex == 0)
            {
                currentcount = 0;
            }
            string RoomIDs = context.Request.Params["RoomIDs"];
            List<int> RoomIDList = new List<int>();
            if (!string.IsNullOrEmpty(RoomIDs))
            {
                RoomIDList = JsonConvert.DeserializeObject<List<int>>(RoomIDs);
            }
            string ProjectIDs = context.Request.Params["ProjectIDs"];
            List<int> ProjectIDList = new List<int>();
            if (RoomIDList.Count == 0)
            {
                if (!string.IsNullOrEmpty(ProjectIDs))
                {
                    ProjectIDList = JsonConvert.DeserializeObject<List<int>>(ProjectIDs).Where(p => p != 1).ToList();
                }
                ProjectIDList = WebUtil.GetMyProjects(WebUtil.GetUser(context).UserID, ProjectIDList).Where(p => p.ID != 1).Select(p => p.ID).ToList();
            }
            string ChargeIDs = context.Request.Params["ChargeIDs"];
            int[] ChargeIDList = new int[] { };
            if (!string.IsNullOrEmpty(ChargeIDs))
            {
                ChargeIDList = JsonConvert.DeserializeObject<int[]>(ChargeIDs).Where(p => p != 0).ToArray();
            }
            int Year = WebUtil.GetIntValue(context, "Year");
            bool ShowALLFooter = WebUtil.GetIntValue(context, "ShowALLFooter") == 1;
            bool IsAnalysisQuery = WebUtil.GetIntValue(context, "IsAnalysisQuery") == 1;
            var fee_list = RoomFeeAnalysis.GetRoomFeeAnalysisListByRoomID(RoomIDList, ProjectIDList, DateTime.MinValue, DateTime.MinValue, ChargeIDList, -1, new List<int>(), true, true, 0, UserID: WebUtil.GetUser(context).UserID, RequireOrderBy: false, IncludeRelation: false, IsAnalysisQuery: IsAnalysisQuery);
            var history_list = ViewRoomFeeHistoryDetail.GetViewRoomFeeHistoryDetailList(RoomIDList, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, ProjectIDList, ChargeIDList: ChargeIDList.ToList(), UserID: WebUtil.GetUser(context).UserID, RequireOrderBy: false, IsAnalysisQuery: IsAnalysisQuery, RequireMerge: true);
            var history_list_chongdi = ViewRoomFeeHistoryDetail.GetViewRoomFeeHistoryDetailList(RoomIDList, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, ProjectIDList, ChargeIDList: ChargeIDList.ToList(), UserID: WebUtil.GetUser(context).UserID, RequireOrderBy: false, IsAnalysisQuery: IsAnalysisQuery, RequireMerge: false, ChargeStateList: new int[] { 4 });
            List<int> ALLRoomIDList = fee_list.Select(p => p.RoomID).Distinct().ToList();
            List<int> HistoryRoomIDList = history_list.Select(p => p.RoomID).Distinct().ToList();
            ALLRoomIDList.AddRange(HistoryRoomIDList);
            ALLRoomIDList = ALLRoomIDList.Distinct().ToList();
            List<Dictionary<string, object>> data_list = new List<Dictionary<string, object>>();
            int totalcount = 0;
            int currentindex = 0;
            long next_startRowIndex = 0;
            bool cancontinue = true;
            bool canexport = WebUtil.GetBoolValue(context, "canexport");
            DateTime StartTime = new DateTime(Year, 1, 1).AddSeconds(-1);
            List<Dictionary<string, object>> footer_list = new List<Dictionary<string, object>>();
            Dictionary<string, object> footer_item = new Dictionary<string, object>();
            var chargesummary_list = Foresight.DataAccess.AnalysisChargeField.GetMonthFeeAnalysisColumns().Where(p => !p.IsHide && (!p.IsHideReal || !p.IsHideRest || !p.IsHideTotal || !p.IsHideDiscount)).OrderBy(p => { return p.SortOrder < 0 ? int.MaxValue : p.SortOrder; }).ToArray();
            foreach (var RoomID in ALLRoomIDList)
            {
                var my_fee_room_list = fee_list.Where(p => p.RoomID == RoomID).ToArray();
                List<int> MYChargeIDList = my_fee_room_list.Select(p => p.ChargeID).Distinct().ToList();
                var my_fee_history_room_list = history_list.Where(p => p.RoomID == RoomID).ToArray();
                List<int> MYHistoryChargeIDList = my_fee_history_room_list.Select(p => p.ChargeID).Distinct().ToList();
                MYChargeIDList.AddRange(MYHistoryChargeIDList);
                MYChargeIDList = MYChargeIDList.Distinct().ToList();
                totalcount += MYChargeIDList.Count;
                if (!cancontinue && !canexport)
                {
                    continue;
                }
                foreach (var ChargeID in MYChargeIDList)
                {
                    currentindex++;
                    if (currentindex < currentcount && !canexport)
                    {
                        continue;
                    }
                    if (next_startRowIndex >= pageSize && !canexport)
                    {
                        currentcount = currentindex;
                        cancontinue = false;
                        break;
                    }
                    var my_fee_list = fee_list.Where(p => p.RoomID == RoomID && p.ChargeID == ChargeID).ToArray();
                    var my_fee_history_list = history_list.Where(p => p.RoomID == RoomID && p.ChargeID == ChargeID).ToArray();
                    var my_history_list_chongdi = history_list_chongdi.Where(p => p.RoomID == RoomID && p.ChargeID == ChargeID).ToArray();
                    if (my_fee_list.Length == 0 && my_fee_history_list.Length == 0)
                    {
                        continue;
                    }
                    var dic = new Dictionary<string, object>();
                    dic["RoomID"] = RoomID;
                    dic["ID"] = RoomID + "_" + ChargeID;
                    if (my_fee_list.Length > 0)
                    {
                        dic["FullName"] = my_fee_list[0].FullName;
                        dic["RoomName"] = my_fee_list[0].RoomName;
                        dic["DefaultChargeManName"] = my_fee_list[0].DefaultChargeManName;
                        dic["Name"] = my_fee_list[0].Name;
                    }
                    else
                    {
                        dic["FullName"] = my_fee_history_list[0].FullName;
                        dic["RoomName"] = my_fee_history_list[0].RoomName;
                        dic["DefaultChargeManName"] = my_fee_history_list[0].DefaultChargeManName;
                        dic["Name"] = my_fee_history_list[0].ChargeName;
                    }
                    decimal YingShouFee = 0;
                    decimal YiShouFee = 0;
                    decimal ChongDiFee = 0;
                    decimal JianMianFee = 0;
                    decimal WeiShouFee = 0;
                    decimal Cycle_WeiShouFee = 0;
                    decimal Heji_YingShou = 0;
                    decimal Heji_YiShou = 0;
                    decimal Heji_ChongDi = 0;
                    decimal Heji_JianMian = 0;
                    decimal Heji_WeiShou = 0;
                    decimal Heji_CycleWeiShou = 0;

                    for (int index = 0; index < chargesummary_list.Length; index++)
                    {
                        int i = chargesummary_list[index].ChargeID;
                        WebUtil.GetFeeListByMonth(i, my_fee_list, my_fee_history_list, my_history_list_chongdi, Year, out YingShouFee, out YiShouFee, out JianMianFee, out WeiShouFee, out ChongDiFee, out Cycle_WeiShouFee);
                        dic[i.ToString() + "_YingShou"] = YingShouFee;
                        dic[i.ToString() + "_YiShou"] = YiShouFee;
                        dic[i.ToString() + "_ChongDi"] = ChongDiFee;
                        dic[i.ToString() + "_JianMian"] = JianMianFee;
                        dic[i.ToString() + "_WeiShou"] = WeiShouFee;
                        Heji_YingShou += YingShouFee;
                        Heji_YiShou += YiShouFee;
                        Heji_ChongDi += ChongDiFee;
                        Heji_JianMian += JianMianFee;
                        Heji_WeiShou += WeiShouFee;
                        Heji_CycleWeiShou += Cycle_WeiShouFee;
                        decimal footer_yingshou = 0;
                        if (footer_item.ContainsKey(i.ToString() + "_YingShou"))
                        {
                            footer_yingshou = Convert.ToDecimal(footer_item[i.ToString() + "_YingShou"]);
                        }
                        footer_item[i.ToString() + "_YingShou"] = footer_yingshou + YingShouFee;
                        decimal footer_yishou = 0;
                        if (footer_item.ContainsKey(i.ToString() + "_YiShou"))
                        {
                            footer_yishou = Convert.ToDecimal(footer_item[i.ToString() + "_YiShou"]);
                        }
                        footer_item[i.ToString() + "_YiShou"] = footer_yishou + YiShouFee;
                        decimal footer_chongdi = 0;
                        if (footer_item.ContainsKey(i.ToString() + "_ChongDi"))
                        {
                            footer_chongdi = Convert.ToDecimal(footer_item[i.ToString() + "_ChongDi"]);
                        }
                        footer_item[i.ToString() + "_ChongDi"] = footer_chongdi + ChongDiFee;
                        decimal footer_jianmian = 0;
                        if (footer_item.ContainsKey(i.ToString() + "_JianMian"))
                        {
                            footer_jianmian = Convert.ToDecimal(footer_item[i.ToString() + "_JianMian"]);
                        }
                        footer_item[i.ToString() + "_JianMian"] = footer_jianmian + JianMianFee;
                        decimal footer_weishou = 0;
                        if (footer_item.ContainsKey(i.ToString() + "_WeiShou"))
                        {
                            footer_weishou = Convert.ToDecimal(footer_item[i.ToString() + "_WeiShou"]);
                        }
                        footer_item[i.ToString() + "_WeiShou"] = footer_weishou + WeiShouFee;
                    }

                    var my_fee_list1 = RoomFeeAnalysis.GetRoomFeeAnalysisDictionary(my_fee_list, DateTime.MinValue, StartTime);
                    decimal Heji_LiShiQianFei = my_fee_list1.Sum(p => Convert.ToDecimal(p["TotalFinalCost"]));
                    if (Heji_YingShou <= 0 && Heji_LiShiQianFei <= 0 && Heji_YiShou <= 0 && Heji_ChongDi <= 0 && Heji_JianMian <= 0 && Heji_WeiShou <= 0)
                    {
                        continue;
                    }
                    next_startRowIndex++;
                    string Heji_ShouFeiLv = "0.00%";
                    if (Heji_YingShou > 0)
                    {
                        Heji_ShouFeiLv = (Math.Round(((Heji_YingShou - Heji_CycleWeiShou) / Heji_YingShou), 4, MidpointRounding.AwayFromZero) * 100).ToString("0.00") + "%";
                    }
                    dic["Heji_YingShou"] = Heji_YingShou;
                    dic["Heji_YiShou"] = Heji_YiShou;
                    dic["Heji_ChongDi"] = Heji_ChongDi;
                    dic["Heji_JianMian"] = Heji_JianMian;
                    dic["Heji_WeiShou"] = Heji_WeiShou;
                    dic["Heji_LiShiQianFei"] = Heji_LiShiQianFei;
                    dic["Heji_ShouFeiLv"] = Heji_ShouFeiLv;
                    data_list.Add(dic);
                    decimal footer_Heji_WeiShou = 0;
                    if (footer_item.ContainsKey("Heji_WeiShou"))
                    {
                        footer_Heji_WeiShou = Convert.ToDecimal(footer_item["Heji_WeiShou"]);
                    }
                    footer_item["Heji_WeiShou"] = footer_Heji_WeiShou + Heji_WeiShou;
                    decimal footer_Heji_YiShou = 0;
                    if (footer_item.ContainsKey("Heji_YiShou"))
                    {
                        footer_Heji_YiShou = Convert.ToDecimal(footer_item["Heji_YiShou"]);
                    }
                    footer_item["Heji_YiShou"] = footer_Heji_YiShou + Heji_YiShou;
                    decimal footer_Heji_ChongDi = 0;
                    if (footer_item.ContainsKey("Heji_ChongDi"))
                    {
                        footer_Heji_ChongDi = Convert.ToDecimal(footer_item["Heji_ChongDi"]);
                    }
                    footer_item["Heji_ChongDi"] = footer_Heji_ChongDi + Heji_ChongDi;
                    decimal footer_Heji_JianMian = 0;
                    if (footer_item.ContainsKey("Heji_JianMian"))
                    {
                        footer_Heji_JianMian = Convert.ToDecimal(footer_item["Heji_JianMian"]);
                    }
                    footer_item["Heji_JianMian"] = footer_Heji_JianMian + Heji_JianMian;
                    decimal footer_Heji_YingShou = 0;
                    if (footer_item.ContainsKey("Heji_YingShou"))
                    {
                        footer_Heji_YingShou = Convert.ToDecimal(footer_item["Heji_YingShou"]);
                    }
                    footer_item["Heji_YingShou"] = footer_Heji_YingShou + Heji_YingShou;
                    decimal footer_Heji_LiShiQianFei = 0;
                    if (footer_item.ContainsKey("Heji_LiShiQianFei"))
                    {
                        footer_Heji_LiShiQianFei = Convert.ToDecimal(footer_item["Heji_LiShiQianFei"]);
                    }
                    footer_item["Heji_LiShiQianFei"] = footer_Heji_LiShiQianFei + Heji_LiShiQianFei;
                }
            }
            if (!ShowALLFooter)
            {
                footer_list.Add(footer_item);
            }
            else
            {
                decimal YingShouFee = 0;
                decimal YiShouFee = 0;
                decimal ChongDiFee = 0;
                decimal JianMianFee = 0;
                decimal WeiShouFee = 0;
                decimal Cycle_WeiShouFee = 0;
                decimal Footer_Heji_YingShou = 0;
                decimal Footer_Heji_YiShou = 0;
                decimal Footer_Heji_ChongDi = 0;
                decimal Footer_Heji_JianMian = 0;
                decimal Footer_Heji_WeiShou = 0;
                decimal Footer_Heji_CycleWeiShou = 0;
                for (int i = 1; i < 13; i++)
                {
                    WebUtil.GetFeeListByMonth(i, fee_list, history_list, history_list_chongdi, Year, out YingShouFee, out YiShouFee, out JianMianFee, out WeiShouFee, out ChongDiFee, out Cycle_WeiShouFee);
                    footer_item[i.ToString() + "_YingShou"] = YingShouFee;
                    footer_item[i.ToString() + "_YiShou"] = YiShouFee;
                    footer_item[i.ToString() + "_ChongDi"] = ChongDiFee;
                    footer_item[i.ToString() + "_JianMian"] = JianMianFee;
                    footer_item[i.ToString() + "_WeiShou"] = WeiShouFee;
                    Footer_Heji_YingShou += YingShouFee;
                    Footer_Heji_YiShou += YiShouFee;
                    Footer_Heji_ChongDi += ChongDiFee;
                    Footer_Heji_JianMian += JianMianFee;
                    Footer_Heji_WeiShou += WeiShouFee;
                    Footer_Heji_CycleWeiShou += Cycle_WeiShouFee;
                }
                var my_fee_list2 = RoomFeeAnalysis.GetRoomFeeAnalysisDictionary(fee_list, DateTime.MinValue, StartTime);
                decimal Footer_Heji_LiShiQianFei = my_fee_list2.Sum(p => Convert.ToDecimal(p["TotalFinalCost"]));
                footer_item["Heji_YingShou"] = Footer_Heji_YingShou;
                footer_item["Heji_YiShou"] = Footer_Heji_YiShou;
                footer_item["Heji_ChongDi"] = Footer_Heji_ChongDi;
                footer_item["Heji_JianMian"] = Footer_Heji_JianMian;
                footer_item["Heji_WeiShou"] = Footer_Heji_WeiShou;
                footer_item["Heji_LiShiQianFei"] = Footer_Heji_LiShiQianFei;
                footer_list.Add(footer_item);
            }
            var dg = new Foresight.DataAccess.Ui.DataGrid();
            dg.rows = data_list;
            dg.page = pageSize;
            dg.total = totalcount;
            dg.footer = footer_list;
            if (canexport)
            {
                string downloadurl = string.Empty;
                string error = string.Empty;
                bool status = APPCode.ExportHelper.DownLoadMonthFeeAnalysisData(dg, out downloadurl, out error);
                WebUtil.WriteJson(context, new { status = status, downloadurl = downloadurl, error = error });
            }
            else
            {
                var dic_dg = new Dictionary<string, object>();
                dic_dg["rows"] = dg.rows;
                dic_dg["page"] = dg.page;
                dic_dg["total"] = dg.total;
                dic_dg["footer"] = dg.footer;
                dic_dg["currentcount"] = currentcount;
                WebUtil.WriteJson(context, dic_dg);
            }
        }
        private void loadwarninginfo(HttpContext context)
        {
            int UserID = WebUtil.GetUser(context).UserID;
            string RoomIDs = context.Request.Params["RoomIDs"];
            List<int> RoomIDList = new List<int>();
            if (!string.IsNullOrEmpty(RoomIDs))
            {
                RoomIDList = JsonConvert.DeserializeObject<List<int>>(RoomIDs);
            }
            string ProjectIDs = context.Request.Params["ProjectIDs"];
            List<int> MyProjectIDList = new List<int>();
            List<int> ProjectIDList = new List<int>();
            if (RoomIDList.Count == 0)
            {
                if (!string.IsNullOrEmpty(ProjectIDs))
                {
                    MyProjectIDList = JsonConvert.DeserializeObject<List<int>>(ProjectIDs).Where(p => p != 1).ToList();
                }
                ProjectIDList = WebUtil.GetMyProjects(WebUtil.GetUser(context).UserID, MyProjectIDList).Where(p => p.ID != 1).Select(p => p.ID).ToList();
            }
            //if (RoomIDList.Count == 0 && ProjectIDList.Count == 0)
            //{
            //    WebUtil.WriteJson(context, new { status = false, error = "请选择资源" });
            //    return;
            //}
            int contractcount = Foresight.DataAccess.Contract.GetALLWaringingContractsCount(RoomIDList, ProjectIDList, UserID: UserID);
            decimal contractamount = 0;
            RoomFeeAnalysis[] list = RoomFeeAnalysis.GetRoomFeeAnalysisListByRoomID(RoomIDList, ProjectIDList, DateTime.MinValue, DateTime.MinValue, new int[] { }, -1, new List<int>(), false, true, 0, false, string.Empty, false, DivideID: 0, RoomStateList: new List<int>(), UserID: WebUtil.GetUser(HttpContext.Current).UserID, IsContractWarning: true, RequireOrderBy: false);
            if (list.Length > 0)
            {
                contractamount = list.Sum(p => p.TotalFinalCost);
            }
            List<int> EqualProjectIDList = new List<int>();
            List<int> InProjectIDList = new List<int>();
            if (RoomIDList.Count == 0)
            {
                Web.APPCode.CacheHelper.GetMyProjectListByUserID(WebUtil.GetUser(context).UserID, out EqualProjectIDList, out InProjectIDList, ProjectIDList: MyProjectIDList);
                if (MyProjectIDList.Count == 0)
                {
                    if (EqualProjectIDList.Count > 0)
                    {
                        EqualProjectIDList.Add(0);
                    }
                }
                else
                {
                    string ALLProjectIDs = context.Request["ALLProjectIDs"];
                    List<int> ALLProjectIDList = new List<int>();
                    if (!string.IsNullOrEmpty(ALLProjectIDs))
                    {
                        ALLProjectIDList = JsonConvert.DeserializeObject<List<int>>(ALLProjectIDs).Where(p => p != 1).ToList();
                    }
                    if (ALLProjectIDList.Count > 0)
                    {
                        EqualProjectIDList = ALLProjectIDList;
                    }
                }
            }
            int servicecount = Foresight.DataAccess.CustomerService.GetCustomerServiceListCountByEqualProjectID(RoomIDList, 100, UserID, EqualProjectIDList, InProjectIDList);

            int delaycount = 0;
            WebUtil.WriteJson(context, new { status = true, contractcount = contractcount, contractamount = contractamount, servicecount = servicecount, delaycount = delaycount });
        }
        private void getprochargesearchparams(HttpContext context)
        {
            var list = Foresight.DataAccess.ChargeSummary.GetChargeSummaries().Where(p => p.CategoryID == 4);
            var summarys = list.Select(p =>
            {
                var item = new { ID = p.ID, Name = p.Name };
                return item;
            });
            WebUtil.WriteJson(context, new { status = true, summarys = summarys });
        }
        private void getdepositsearchparams(HttpContext context)
        {
            var list = Foresight.DataAccess.ChargeSummary.GetChargeSummaries().Where(p => p.CategoryID == 3);
            var summarys = list.Select(p =>
            {
                var item = new { ID = p.ID, Name = p.Name };
                return item;
            });
            WebUtil.WriteJson(context, new { status = true, summarys = summarys });
        }
        private void LoadToChargeSummaryByChargenameV2(HttpContext context)
        {
            try
            {
                int CompanyID = 0;
                int.TryParse(context.Request.Params["CompanyID"], out CompanyID);
                string RoomID = context.Request.Params["RoomID"];
                List<int> RoomIDList = new List<int>();
                if (!string.IsNullOrEmpty(RoomID))
                {
                    RoomIDList = JsonConvert.DeserializeObject<List<int>>(RoomID);
                }
                string ProjectIDs = context.Request.Params["ProjectID"];
                List<int> ProjectIDList = new List<int>();
                if (RoomIDList.Count == 0)
                {
                    if (!string.IsNullOrEmpty(ProjectIDs))
                    {
                        ProjectIDList = JsonConvert.DeserializeObject<List<int>>(ProjectIDs).Where(p => p != 1).ToList();
                    }
                    ProjectIDList = WebUtil.GetMyProjects(WebUtil.GetUser(context).UserID, ProjectIDList).Where(p => p.ID != 1).Select(p => p.ID).ToList();
                }
                DateTime StartTime = DateTime.MinValue;
                DateTime.TryParse(context.Request.Params["StartTime"], out StartTime);
                DateTime EndTime = DateTime.MinValue;
                DateTime.TryParse(context.Request.Params["EndTime"], out EndTime);
                string ChargeSummarys = context.Request.Params["ChargeSummarys"];
                int[] ChargeSummaryIDList = new int[] { };
                if (!string.IsNullOrEmpty(ChargeSummarys))
                {
                    ChargeSummaryIDList = JsonConvert.DeserializeObject<int[]>(ChargeSummarys);
                }
                ChargeSummaryToChargeSummary[] summarylist = ChargeSummaryToChargeSummary.GetChargeSummaryToChargeSummaryListByIDList(ChargeSummaryIDList);
                RoomFeeAnalysis[] list = RoomFeeAnalysis.GetRoomFeeAnalysisListByRoomID(RoomIDList, ProjectIDList, StartTime, EndTime, ChargeSummaryIDList, -1, new List<int>(), true, true, 0, false, string.Empty, true, UserID: WebUtil.GetUser(context).UserID, RequireOrderBy: false, IncludeRelation: false).Where(p => p.TotalCost > 0).ToArray();
                decimal footer_RestCost = 0;
                decimal footer_PayCost = 0;
                decimal footer_TotalCost = 0;
                foreach (var summary in summarylist)
                {
                    var sublist = list.Where(p => p.ChargeID == summary.ID).ToArray();
                    summary.RestCost = sublist.Sum(p => p.TotalFinalCost);
                    summary.PayCost = sublist.Sum(p => p.TotalFinalPayCost);
                    summary.TotalCost = sublist.Sum(p => p.TotalCost);
                    footer_RestCost += summary.RestCost;
                    footer_PayCost += summary.PayCost;
                    footer_TotalCost += summary.TotalCost;
                }
                var footerlist = new List<ChargeSummaryToChargeSummary>();
                var footer = new ChargeSummaryToChargeSummary();
                footer.Name = "合计";
                footer.RestCost = footer_RestCost;
                footer.PayCost = footer_PayCost;
                footer.TotalCost = footer_TotalCost;
                footerlist.Add(footer);
                DataGrid dg = new DataGrid();
                dg.rows = summarylist;
                dg.total = summarylist.Length;
                dg.page = 1;
                dg.footer = footerlist;
                bool canexport = WebUtil.GetBoolValue(context, "canexport");
                if (canexport)
                {
                    string downloadurl = string.Empty;
                    string error = string.Empty;
                    bool status = APPCode.ExportHelper.DownLoadToChargeAnalysisSummaryData(dg, out downloadurl, out error);
                    WebUtil.WriteJson(context, new { status = status, downloadurl = downloadurl, error = error });
                    return;
                }
                string result = JsonConvert.SerializeObject(dg);
                context.Response.Write(result);
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("AnalysisHandler", "visit: LoadToChargeSummaryByChargenameV2", ex);
                context.Response.Write("{\"rows\":[],\"total\":0,\"page\":0}");
            }
        }
        private void searchorderbyids(HttpContext context)
        {
            Foresight.DataAccess.RoomFeeOrder roomFeeOrder = null;
            int RoomFeeOrderID = GetIntValue(context, "RoomFeeOrderID");
            if (RoomFeeOrderID > 0)
            {
                roomFeeOrder = RoomFeeOrder.GetRoomFeeOrder(RoomFeeOrderID);
            }
            string HistoryIDs = context.Request["HistoryIDs"];
            List<int> HistoryIDList = new List<int>();
            if (!string.IsNullOrEmpty(HistoryIDs))
            {
                HistoryIDList = JsonConvert.DeserializeObject<List<int>>(HistoryIDs);
            }
            List<int> ChargeState = new List<int>();
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
            if (roomFeeOrder != null)
            {
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
            }
            else
            {
                ChargeState = new List<int>();
                ChargeState = new int[] { 1, 2, 3, 6, 7 }.ToList();
                TotalALLCount = Foresight.DataAccess.PrintRoomFeeHistory.GetCountByChargeState(DateTime.MinValue, DateTime.MinValue, string.Empty, ChargeState, new List<int>(), RoomFeeOrderID, true, HistoryIDList, DeleteTempHistoryIDList: true, UserID: WebUtil.GetUser(context).UserID);
                ChargeState = new List<int>();
                ChargeState = new int[] { 1 }.ToList();
                TotalChargeCount = Foresight.DataAccess.PrintRoomFeeHistory.GetCountByChargeState(DateTime.MinValue, DateTime.MinValue, string.Empty, ChargeState, new List<int>(), RoomFeeOrderID, true, HistoryIDList, DeleteTempHistoryIDList: true, UserID: WebUtil.GetUser(context).UserID);
                ChargeState = new List<int>();
                ChargeState = new int[] { 2 }.ToList();
                TotalChargeCancelCount = Foresight.DataAccess.PrintRoomFeeHistory.GetCountByChargeState(DateTime.MinValue, DateTime.MinValue, string.Empty, ChargeState, new List<int>(), RoomFeeOrderID, true, HistoryIDList, DeleteTempHistoryIDList: true, UserID: WebUtil.GetUser(context).UserID);
                ChargeState = new List<int>();
                ChargeState = new int[] { 3, 6, 7 }.ToList();
                TotalChargeBackCount = Foresight.DataAccess.PrintRoomFeeHistory.GetCountByChargeState(DateTime.MinValue, DateTime.MinValue, string.Empty, ChargeState, new List<int>(), RoomFeeOrderID, true, HistoryIDList, DeleteTempHistoryIDList: true, UserID: WebUtil.GetUser(context).UserID);
                var historylist = Foresight.DataAccess.ViewRoomFeeHistory.GetViewRoomFeeHistoryListForOrder(DateTime.MinValue, DateTime.MinValue, string.Empty, new List<int>(), new List<int>(), RoomFeeOrderID, true, HistoryIDList, DeleteTempHistoryIDList: true, UserID: WebUtil.GetUser(context).UserID);
                ChargeState = new List<int>();
                ChargeState = new int[] { 1 }.ToList();
                ShouTotalRealCost = Foresight.DataAccess.PrintRoomFeeHistory.GetSumCostByChargeState(DateTime.MinValue, DateTime.MinValue, string.Empty, ChargeState, new List<int>(), RoomFeeOrderID, true, HistoryIDList, DeleteTempHistoryIDList: true, UserID: WebUtil.GetUser(context).UserID);
                var ShouPrintNumberList = historylist.Where(p => !string.IsNullOrEmpty(p.PrintNumber) && (p.ChargeState == 1 || p.ChargeState == 4)).OrderBy(q => q.PrintNumber).ToList();
                if (ShouPrintNumberList.Count > 0)
                {
                    ShouKuanStartNumber = ShouPrintNumberList[0].PrintNumber;
                    ShouKuanEndNumber = ShouPrintNumberList[ShouPrintNumberList.Count - 1].PrintNumber;
                }
                ChargeState = new List<int>();
                ChargeState = new int[] { 3, 6, 7 }.ToList();
                FuTotalRealCost = Foresight.DataAccess.PrintRoomFeeHistory.GetSumCostByChargeState(DateTime.MinValue, DateTime.MinValue, string.Empty, ChargeState, new List<int>(), RoomFeeOrderID, true, HistoryIDList, DeleteTempHistoryIDList: true, UserID: WebUtil.GetUser(context).UserID);
                var FuPrintNumberList = historylist.Where(p => !string.IsNullOrEmpty(p.PrintNumber) && p.ChargeState == 3).OrderBy(q => q.PrintNumber).ToList();
                if (FuPrintNumberList.Count > 0)
                {
                    FuKuanStartNumber = FuPrintNumberList[0].PrintNumber;
                    FuKuanEndNumber = FuPrintNumberList[FuPrintNumberList.Count - 1].PrintNumber;
                }
                ChargeState = new List<int>();
                ChargeState = new int[] { 1 }.ToList();
                WeiShuTotalCost = Foresight.DataAccess.PrintRoomFeeHistory.GetSumWeiShuByChargeState(DateTime.MinValue, DateTime.MinValue, string.Empty, ChargeState, new List<int>(), new List<int>(), 0, false, HistoryIDList, UserID: WebUtil.GetUser(context).UserID);
            }
            var ShouTypeSummaryList = new List<ChargeMoneyTypeDetails>();
            var ShouChargeSummaryList = new List<ChargeSummaryDetails>();
            var FuChargeSummaryList = new List<ChargeSummaryDetails>();
            var FuTypeSummaryList = new List<ChargeMoneyTypeDetails>();
            DataGrid dg = ChargeMoneyTypeDetails.GetHistorySummaryGroupByTypeName(new List<int>(), new List<int>(), DateTime.MinValue, DateTime.MinValue, string.Empty, int.MinValue, int.MinValue, RoomFeeOrderID, true, HistoryIDList, DeleteTempHistoryIDList: true, UserID: WebUtil.GetUser(context).UserID);
            ChargeMoneyTypeDetails[] list = dg.rows as ChargeMoneyTypeDetails[];
            ShouTypeSummaryList = list.Where(p => p.RealCost > 0).ToList();

            ChargeState = new List<int>();
            ChargeState = new int[] { 1 }.ToList();
            dg = ChargeSummaryDetails.GetHistorySummaryGroupByChargeName(new List<int>(), new List<int>(), DateTime.MinValue, DateTime.MinValue, 1, string.Empty, int.MinValue, int.MinValue, RoomFeeOrderID, ChargeState, false, HistoryIDList, DeleteTempHistoryIDList: true, UserID: WebUtil.GetUser(context).UserID);
            ChargeSummaryDetails[] list2 = dg.rows as ChargeSummaryDetails[];
            ShouChargeSummaryList = list2.Where(p => p.RealCost > 0).ToList();

            ChargeState = new List<int>();
            ChargeState = new int[] { 3, 6, 7 }.ToList();
            dg = ChargeSummaryDetails.GetHistorySummaryGroupByChargeName(new List<int>(), new List<int>(), DateTime.MinValue, DateTime.MinValue, 1, string.Empty, int.MinValue, int.MinValue, RoomFeeOrderID, ChargeState, false, HistoryIDList, DeleteTempHistoryIDList: true, UserID: WebUtil.GetUser(context).UserID);
            ChargeSummaryDetails[] list3 = dg.rows as ChargeSummaryDetails[];
            FuChargeSummaryList = list3.Where(p => p.RealCost > 0).ToList();

            dg = ChargeMoneyTypeDetails.GetDepositSummaryGroupByTypeName(new List<int>(), new List<int>(), DateTime.MinValue, DateTime.MinValue, 1, string.Empty, RoomFeeOrderID, false, HistoryIDList, DeleteTempHistoryIDList: true, UserID: WebUtil.GetUser(context).UserID);
            ChargeMoneyTypeDetails[] list4 = dg.rows as ChargeMoneyTypeDetails[];
            FuTypeSummaryList = list4.Where(p => p.RealCost > 0).ToList();

            int totalCount1 = Math.Max(ShouTypeSummaryList.Count, ShouChargeSummaryList.Count);
            int totalCount2 = Math.Max(FuTypeSummaryList.Count, FuChargeSummaryList.Count);
            int totalCount = Math.Max(totalCount1, totalCount2);
            var items = new
            {
                status = true,
                summary = new
                {
                    TotalALLCount = TotalALLCount,
                    TotalChargeCount = TotalChargeCount,
                    TotalChargeCancelCount = TotalChargeCancelCount,
                    TotalChargeBackCount = TotalChargeBackCount,
                    ShouKuanStartNumber = ShouKuanStartNumber,
                    ShouKuanEndNumber = ShouKuanEndNumber,
                    FuKuanStartNumber = FuKuanStartNumber,
                    FuKuanEndNumber = FuKuanEndNumber,
                    ShouTotalRealCost = ShouTotalRealCost,
                    FuTotalRealCost = FuTotalRealCost,
                    WeiShuTotalCost = WeiShuTotalCost
                },
                ShouTypeSummaryList = ShouTypeSummaryList,
                ShouChargeSummaryList = ShouChargeSummaryList,
                FuChargeSummaryList = FuChargeSummaryList,
                FuTypeSummaryList = FuTypeSummaryList,
                totalCount = totalCount
            };
            var result = JsonConvert.SerializeObject(items);
            context.Response.Write(result);
        }
        private void searchordernew(HttpContext context)
        {
            try
            {
                DateTime StartTime = GetDateValue(context, "StartTime");
                DateTime EndTime = GetDateValue(context, "EndTime");
                string ChargeMan = context.Request.Params["Operator"];
                string ProjectIDs = context.Request.Params["ProjectIDList"];
                List<int> ProjectIDList = new List<int>();
                if (!string.IsNullOrEmpty(ProjectIDs))
                {
                    ProjectIDList = JsonConvert.DeserializeObject<List<int>>(ProjectIDs).Where(p => p != 1).ToList();
                }
                ProjectIDList = WebUtil.GetMyProjects(WebUtil.GetUser(context).UserID, ProjectIDList).Where(p => p.ID != 1).Select(p => p.ID).ToList();
                string RoomIDs = context.Request.Params["RoomIDList"];
                List<int> RoomIDList = new List<int>();
                if (!string.IsNullOrEmpty(RoomIDs))
                {
                    RoomIDList = JsonConvert.DeserializeObject<List<int>>(RoomIDs);
                }
                List<int> ChargeStateList = new List<int>();
                string ChargeStates = context.Request["ChargeStates"];
                if (!string.IsNullOrEmpty(ChargeStates))
                {
                    ChargeStateList = JsonConvert.DeserializeObject<List<int>>(ChargeStates);
                }
                List<int> ChargeTypeList = new List<int>();
                string ChargeTypes = context.Request["ChargeTypes"];
                if (!string.IsNullOrEmpty(ChargeTypes))
                {
                    ChargeTypeList = JsonConvert.DeserializeObject<List<int>>(ChargeTypes);
                }
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                page = string.IsNullOrEmpty(page) ? "1" : page;
                rows = string.IsNullOrEmpty(rows) ? "50" : rows;
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                int RoomFeeOrderID = GetIntValue(context, "RoomFeeOrderID");
                var dg = Foresight.DataAccess.ViewRoomFeeHistory.GetViewRoomFeeHistoryGridForOrder(StartTime, EndTime, ChargeMan, ChargeStateList, ProjectIDList, RoomFeeOrderID, "order by [PrintNumber] desc", startRowIndex, pageSize, ChargeTypeList: ChargeTypeList, UserID: WebUtil.GetUser(context).UserID, RoomIDList: RoomIDList);
                var HistoryIDList = Foresight.DataAccess.ViewRoomFeeHistory.GetViewRoomFeeHistoryIDListForOrder(StartTime, EndTime, ChargeMan, ChargeStateList, ProjectIDList, RoomFeeOrderID, ChargeTypeList: ChargeTypeList, UserID: WebUtil.GetUser(context).UserID, RoomIDList: RoomIDList);
                var dic = new Dictionary<string, object>();
                dic["rows"] = dg.rows;
                dic["page"] = dg.page;
                dic["total"] = dg.total;
                dic["historyidlist"] = HistoryIDList;
                WebUtil.WriteJson(context, dic);
            }
            catch (Exception)
            {
                WebUtil.WriteJson(context, new { rows = new List<object>(), total = 0, page = 0 });
            }

        }
        private void loadshoufeilvsummaryanalysic(HttpContext context)
        {
            string RoomType = context.Request["RoomType"];
            if (RoomType.Equals("Project"))
            {
                loadshoufeilvsummaryanalysicbyproject(context);
                return;
            }
            else
            {
                loadshoufeilvsummaryanalysicbyroom(context);
            }
        }
        private void loadshoufeilvsummaryanalysicbyproject(HttpContext context)
        {
        }
        private void loadshoufeilvsummaryanalysicbyroom(HttpContext context)
        {
            string PageCode = Utility.EnumModel.AnalysisChargeFieldPageCode.ShouFeiLvSummaryAnalysis.ToString();
            var chargesummary_list = Foresight.DataAccess.ChargeSummaryField.GetChargeSummaryFields(PageCode).Where(p => (!p.IsHide && (!p.IsHideReal || !p.IsHideRest || !p.IsHideTotal || !p.IsHideHistoryRoomFee)) || p.ChargeFieldID < 0).OrderBy(p => { return p.SortOrder < 0 ? int.MaxValue : p.SortOrder; }).ToArray();
            if (chargesummary_list.Length == 0)
            {
                WebUtil.WriteJson(context, new Foresight.DataAccess.Ui.DataGrid());
                return;
            }
            var SummaryIDList = chargesummary_list.Select(p => p.ID).ToArray();
            string RoomIDs = context.Request["RoomIDs"];
            List<int> RoomIDList = new List<int>();
            if (!string.IsNullOrEmpty(RoomIDs))
            {
                RoomIDList = JsonConvert.DeserializeObject<List<int>>(RoomIDs);
            }
            string ProjectIDs = context.Request["ProjectIDs"];
            List<int> ProjectIDList = new List<int>();
            if (RoomIDList.Count == 0)
            {
                if (!string.IsNullOrEmpty(ProjectIDs))
                {
                    ProjectIDList = JsonConvert.DeserializeObject<List<int>>(ProjectIDs).Where(p => p != 1).ToList();
                }
                ProjectIDList = WebUtil.GetMyProjects(WebUtil.GetUser(context).UserID, ProjectIDList).Where(p => p.ID != 1).Select(p => p.ID).ToList();
            }
            DateTime StartTime = WebUtil.GetDateValue(context, "StartTime");
            DateTime EndTime = WebUtil.GetDateValue(context, "EndTime");
            DateTime StartChargeTime = WebUtil.GetDateValue(context, "StartChargeTime");
            DateTime EndChargeTime = WebUtil.GetDateValue(context, "EndChargeTime");
            string page = context.Request.Form["page"];
            string rows = context.Request.Form["rows"];
            page = string.IsNullOrEmpty(page) ? "1" : page;
            rows = string.IsNullOrEmpty(rows) ? "50" : rows;
            long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
            int pageSize = int.Parse(rows);
            string Keywords = context.Request["keywords"];
            bool canexport = WebUtil.GetBoolValue(context, "canexport");
            var dg = Foresight.DataAccess.ViewRoomBasic.GetViewRoomBasicGrid(ProjectIDList, RoomIDList, Keywords, string.Empty, startRowIndex, pageSize, canexport: canexport);
            var room_list = dg.rows as Foresight.DataAccess.ViewRoomBasic[];
            //RoomIDList = room_list.Select(p => p.RoomID).ToList();
            //ProjectIDList = new List<int>();
            bool IsAnalysisQuery = WebUtil.GetIntValue(context, "IsAnalysisQuery") == 1;
            var feehistory_list = Foresight.DataAccess.ViewRoomFeeHistoryDetail.GetViewRoomFeeHistoryDetailList(RoomIDList, StartChargeTime, EndChargeTime, StartTime, EndTime, ProjectIDList: ProjectIDList, UserID: WebUtil.GetUser(context).UserID, IsAnalysisQuery: IsAnalysisQuery);
            var fee_list = Foresight.DataAccess.RoomFeeAnalysis.GetRoomFeeAnalysisListByTime(DateTime.MinValue, DateTime.MinValue, ProjectIDList, RoomIDList, StartChargeTime, EndChargeTime, UserID: WebUtil.GetUser(context).UserID, IsAnalysisQuery: IsAnalysisQuery);
            Dictionary<string, object> footer = new Dictionary<string, object>();
            var my_fee_list1 = RoomFeeAnalysis.GetRoomFeeAnalysisDictionary(fee_list, StartTime, EndTime);
            var my_fee_list2 = RoomFeeAnalysis.GetRoomFeeAnalysisDictionary(fee_list, DateTime.MinValue, EndTime);
            footer["FullName"] = "合计";
            var items = room_list.Select(room =>
            {
                var dic = new Dictionary<string, object>();
                dic["FullName"] = room.FullName;
                dic["RoomName"] = room.Name;
                dic["RelationName"] = room.RelationName;
                decimal heji_RealCost = 0;
                decimal heji_RestCost = 0;
                decimal heji_AllCost = 0;
                decimal heji_HistoryRestCost = 0;
                foreach (var summary in chargesummary_list)
                {
                    var sub_feehistory_list = feehistory_list.Where(p => p.RoomID == room.RoomID && p.ChargeID == summary.ID).ToArray();
                    decimal realcost = sub_feehistory_list.Sum(p => p.MonthTotalCost + p.MonthDiscountCost);
                    dic[summary.ID + "_RealCost"] = realcost > 0 ? realcost : 0;
                    heji_RealCost += realcost > 0 ? realcost : 0;
                    decimal footer_realcost = 0;
                    if (footer.ContainsKey(summary.ID + "_RealCost"))
                    {
                        footer_realcost = Convert.ToDecimal(footer[summary.ID + "_RealCost"]);
                    }
                    footer[summary.ID + "_RealCost"] = footer_realcost + (realcost > 0 ? realcost : 0);
                    var sub_my_fee_list1 = my_fee_list1.Where(p => Convert.ToInt32(p["RoomID"]) == room.RoomID && Convert.ToInt32(p["ChargeID"]) == summary.ID).ToArray();
                    decimal totalcost_1 = sub_my_fee_list1.Sum(p => Convert.ToDecimal(p["TotalCost"]));
                    decimal totalcost_2 = ViewRoomFeeHistoryBase.GetViewRoomFeeHistoryTotalCost(my_history_list: sub_feehistory_list);
                    decimal totalcost = totalcost_1 + totalcost_2;
                    decimal restcost = sub_my_fee_list1.Sum(p => Convert.ToDecimal(p["TotalFinalCost"]));
                    dic[summary.ID + "_RestCost"] = restcost > 0 ? restcost : 0;
                    heji_RestCost += restcost > 0 ? restcost : 0;
                    decimal footer_restcost = 0;
                    if (footer.ContainsKey(summary.ID + "_RestCost"))
                    {
                        footer_restcost = Convert.ToDecimal(footer[summary.ID + "_RestCost"]);
                    }
                    footer[summary.ID + "_RestCost"] = footer_restcost + (restcost > 0 ? restcost : 0);
                    //totalcost = (realcost > 0 ? realcost : 0) + (restcost > 0 ? restcost : 0);
                    dic[summary.ID + "_AllCost"] = totalcost;
                    decimal footer_allcost = 0;
                    if (footer.ContainsKey(summary.ID + "_AllCost"))
                    {
                        footer_allcost = Convert.ToDecimal(footer[summary.ID + "_AllCost"]);
                    }
                    footer[summary.ID + "_AllCost"] = footer_allcost + totalcost;
                    var sub_my_fee_list2 = my_fee_list2.Where(p => Convert.ToInt32(p["RoomID"]) == room.RoomID && Convert.ToInt32(p["ChargeID"]) == summary.ID).ToArray();
                    decimal history_restcost = sub_my_fee_list2.Sum(p => Convert.ToDecimal(p["TotalFinalCost"]));
                    dic[summary.ID + "_HistoryRestCost"] = history_restcost > 0 ? history_restcost : 0;
                    heji_HistoryRestCost += history_restcost > 0 ? history_restcost : 0;
                    decimal footer_history_restcost = 0;
                    if (footer.ContainsKey(summary.ID + "_HistoryRestCost"))
                    {
                        footer_history_restcost = Convert.ToDecimal(footer[summary.ID + "_HistoryRestCost"]);
                    }
                    footer[summary.ID + "_HistoryRestCost"] = footer_history_restcost + (history_restcost > 0 ? history_restcost : 0);
                }
                heji_AllCost = heji_RealCost + heji_RestCost;
                dic["heji_AllCost"] = heji_AllCost;
                dic["heji_RealCost"] = heji_RealCost;
                dic["heji_RestCost"] = heji_RestCost;
                dic["heji_HistoryRestCost"] = heji_HistoryRestCost;
                decimal footer_heji_allcost = 0;
                if (footer.ContainsKey("heji_AllCost"))
                {
                    footer_heji_allcost = Convert.ToDecimal(footer["heji_AllCost"]);
                }
                footer["heji_AllCost"] = footer_heji_allcost + heji_AllCost;

                decimal footer_heji_realcost = 0;
                if (footer.ContainsKey("heji_RealCost"))
                {
                    footer_heji_realcost = Convert.ToDecimal(footer["heji_RealCost"]);
                }
                footer["heji_RealCost"] = footer_heji_realcost + heji_RealCost;

                decimal footer_heji_restcost = 0;
                if (footer.ContainsKey("heji_RestCost"))
                {
                    footer_heji_restcost = Convert.ToDecimal(footer["heji_RestCost"]);
                }
                footer["heji_RestCost"] = footer_heji_restcost + heji_RestCost;

                decimal footer_heji_history_restcost = 0;
                if (footer.ContainsKey("heji_HistoryRestCost"))
                {
                    footer_heji_history_restcost = Convert.ToDecimal(footer["heji_HistoryRestCost"]);
                }
                footer["heji_HistoryRestCost"] = footer_heji_history_restcost + heji_HistoryRestCost;
                return dic;
            }).ToList();
            dg.rows = items;
            List<Dictionary<string, object>> footerlist = new List<Dictionary<string, object>>();
            footerlist.Add(footer);
            dg.footer = footerlist;
            if (canexport)
            {
                string downloadurl = string.Empty;
                string error = string.Empty;
                bool status = APPCode.ExportHelper.DownLoadShouFeiLvSummaryAnalysisData(dg, out downloadurl, out error);
                WebUtil.WriteJson(context, new { status = status, downloadurl = downloadurl, error = error });
            }
            else
            {
                WebUtil.WriteJson(context, dg);
            }
        }
        private void getshoufeilvsummarycolumns(HttpContext context)
        {
            int takecount = WebUtil.GetIntValue(context, "takecount");
            takecount = takecount <= 0 ? int.MaxValue : takecount;
            string PageCode = context.Request["PageCode"];
            PageCode = string.IsNullOrEmpty(PageCode) ? Utility.EnumModel.AnalysisChargeFieldPageCode.ShouFeiLvSummaryAnalysis.ToString() : PageCode;
            var chargesummary_list = Foresight.DataAccess.ChargeSummaryField.GetChargeSummaryFields(PageCode).Where(p => (!p.IsHide && (!p.IsHideReal || !p.IsHideRest || !p.IsHideTotal || !p.IsHideHistoryRoomFee)) || p.ChargeFieldID < 0).OrderBy(p => { return p.SortOrder < 0 ? int.MaxValue : p.SortOrder; }).ToArray();
            if (chargesummary_list.Length == 0)
            {
                WebUtil.WriteJson(context, new { status = false, msg = "请先配置" });
            }
            StringBuilder columns = new StringBuilder("[[");
            columns.Append("{ field: 'FullName', title: '资源位置', width: 200, rowspan: 2 },");
            columns.Append("{ field: 'RoomName', title: '房间信息', width: 100, rowspan: 2 },");
            columns.Append("{ field: 'RelationName', title: '客户名称', width: 100, rowspan: 2 },");
            StringBuilder sub_columns = new StringBuilder("],[");
            for (int i = 0; i < chargesummary_list.Length; i++)
            {
                var item = chargesummary_list[i];
                int colspancount = 0;
                if (!item.IsHideTotal)
                {
                    sub_columns.Append("{field: '" + item.ID + "_AllCost', formatter: formatCostFormat, title: '应收', width: 100},");
                    colspancount++;
                }
                if (!item.IsHideReal)
                {
                    sub_columns.Append("{field: '" + item.ID + "_RealCost', formatter: formatCostFormat, title: '已收', width: 100},");
                    colspancount++;
                }
                if (!item.IsHideRest)
                {
                    sub_columns.Append("{field: '" + item.ID + "_RestCost', formatter: formatCostFormat, title: '未收', width: 100},");
                    colspancount++;
                }
                if (!item.IsHideHistoryRoomFee)
                {
                    sub_columns.Append("{field: '" + item.ID + "_HistoryRestCost', formatter: formatCostFormat, title: '累计欠费', width: 100},");
                    colspancount++;
                }
                if (colspancount == 0)
                {
                    continue;
                }
                columns.Append("{title: '" + item.Name + "', colspan: " + colspancount + " },");
                if (i == chargesummary_list.Length - 1)
                {
                    columns.Append("{title: '合计', colspan: 4 },");
                    sub_columns.Append("{field: 'heji_AllCost', formatter: formatCostFormat, title: '应收', width: 100},");
                    sub_columns.Append("{field: 'heji_RealCost', formatter: formatCostFormat, title: '已收', width: 100},");
                    sub_columns.Append("{field: 'heji_RestCost', formatter: formatCostFormat, title: '未收', width: 100},");
                    sub_columns.Append("{field: 'heji_HistoryRestCost', formatter: formatCostFormat, title: '累计欠费', width: 100},");
                }
            }
            columns.Append(sub_columns.ToString());
            columns.Append("]]");
            var items = new
            {
                status = true,
                columns = columns.ToString(),
            };
            WebUtil.WriteJson(context, items);
        }
        private void loaddepositsummarybyroom(HttpContext context)
        {
            try
            {
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                page = string.IsNullOrEmpty(page) ? "1" : page;
                rows = string.IsNullOrEmpty(rows) ? "50" : rows;
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                int CompanyID = 0;
                int.TryParse(context.Request.Params["CompanyID"], out CompanyID);
                string RoomIDs = context.Request.Params["RoomIDs"];
                List<int> RoomIDList = new List<int>();
                if (!string.IsNullOrEmpty(RoomIDs))
                {
                    RoomIDList = JsonConvert.DeserializeObject<List<int>>(RoomIDs);
                }
                string ProjectIDs = context.Request.Params["ProjectIDs"];
                List<int> ProjectIDList = new List<int>();
                if (RoomIDList.Count == 0)
                {
                    if (!string.IsNullOrEmpty(ProjectIDs))
                    {
                        ProjectIDList = JsonConvert.DeserializeObject<List<int>>(ProjectIDs).Where(p => p != 1).ToList();
                    }
                    ProjectIDList = WebUtil.GetMyProjects(WebUtil.GetUser(context).UserID, ProjectIDList).Where(p => p.ID != 1).Select(p => p.ID).ToList();
                }
                DateTime StartTime = DateTime.MinValue;
                DateTime.TryParse(context.Request.Params["StartChargeTime"], out StartTime);
                DateTime EndTime = DateTime.MinValue;
                DateTime.TryParse(context.Request.Params["EndChargeTime"], out EndTime);
                string ChargeIDs = context.Request.Params["ChargeIDs"];
                List<int> ChargeIDList = new List<int>();
                if (!string.IsNullOrEmpty(ChargeIDs))
                {
                    ChargeIDList = JsonConvert.DeserializeObject<List<int>>(ChargeIDs).Where(p => p != 0).ToList();
                }
                bool canexport = WebUtil.GetBoolValue(context, "canexport");
                DataGrid dg = ChargeSummaryDepositChargeAnalysis.GetDepositChargeSummaryGroupByRoom(ProjectIDList, RoomIDList, StartTime, EndTime, CompanyID, ChargeIDList, "order by DefaultOrder asc", startRowIndex, pageSize, UserID: WebUtil.GetUser(context).UserID, canexport: canexport);
                if (canexport)
                {
                    string downloadurl = string.Empty;
                    string error = string.Empty;
                    bool status = APPCode.ExportHelper.DownloadDepositSummaryByChargename(dg, out downloadurl, out error);
                    WebUtil.WriteJson(context, new { status = status, downloadurl = downloadurl, error = error });
                    return;
                }
                string result = JsonConvert.SerializeObject(dg);
                context.Response.Write(result);
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("AnalysisHandler", "visit: loaddepositsummarybyroom", ex);
                context.Response.Write("{\"rows\":[],\"total\":0,\"page\":0}");
            }
        }
        private void loaddepositsummarybyproject(HttpContext context)
        {
            try
            {
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                page = string.IsNullOrEmpty(page) ? "1" : page;
                rows = string.IsNullOrEmpty(rows) ? "50" : rows;
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                int CompanyID = 0;
                int.TryParse(context.Request.Params["CompanyID"], out CompanyID);
                string RoomIDs = context.Request.Params["RoomIDs"];
                List<int> RoomIDList = new List<int>();
                if (!string.IsNullOrEmpty(RoomIDs))
                {
                    RoomIDList = JsonConvert.DeserializeObject<List<int>>(RoomIDs);
                }
                string ProjectIDs = context.Request.Params["ProjectIDs"];
                List<int> ProjectIDList = new List<int>();
                if (RoomIDList.Count == 0)
                {
                    if (!string.IsNullOrEmpty(ProjectIDs))
                    {
                        ProjectIDList = JsonConvert.DeserializeObject<List<int>>(ProjectIDs).Where(p => p != 1).ToList();
                    }
                    ProjectIDList = WebUtil.GetMyProjects(WebUtil.GetUser(context).UserID, ProjectIDList).Where(p => p.ID != 1).Select(p => p.ID).ToList();
                }
                DateTime StartTime = DateTime.MinValue;
                DateTime.TryParse(context.Request.Params["StartChargeTime"], out StartTime);
                DateTime EndTime = DateTime.MinValue;
                DateTime.TryParse(context.Request.Params["EndChargeTime"], out EndTime);
                string ChargeIDs = context.Request.Params["ChargeIDs"];
                List<int> ChargeIDList = new List<int>();
                if (!string.IsNullOrEmpty(ChargeIDs))
                {
                    ChargeIDList = JsonConvert.DeserializeObject<List<int>>(ChargeIDs).Where(p => p != 0).ToList();
                }
                bool canexport = WebUtil.GetBoolValue(context, "canexport");
                DataGrid dg = ChargeSummaryDepositChargeAnalysis.GetDepositChargeSummaryGroupByProject(ProjectIDList, RoomIDList, StartTime, EndTime, CompanyID, ChargeIDList, "order by DefaultOrder asc", startRowIndex, pageSize, UserID: WebUtil.GetUser(context).UserID, canexport: canexport);
                if (canexport)
                {
                    string downloadurl = string.Empty;
                    string error = string.Empty;
                    bool status = APPCode.ExportHelper.DownloadDepositSummaryByChargename(dg, out downloadurl, out error);
                    WebUtil.WriteJson(context, new { status = status, downloadurl = downloadurl, error = error });
                    return;
                }
                string result = JsonConvert.SerializeObject(dg);
                context.Response.Write(result);
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("AnalysisHandler", "visit: loaddepositsummarybyproject", ex);
                context.Response.Write("{\"rows\":[],\"total\":0,\"page\":0}");
            }
        }
        private void loaddepositsummarybychargename(HttpContext context)
        {
            try
            {
                int CompanyID = 0;
                int.TryParse(context.Request.Params["CompanyID"], out CompanyID);
                string RoomIDs = context.Request.Params["RoomIDs"];
                List<int> RoomIDList = new List<int>();
                if (!string.IsNullOrEmpty(RoomIDs))
                {
                    RoomIDList = JsonConvert.DeserializeObject<List<int>>(RoomIDs);
                }
                string ProjectIDs = context.Request.Params["ProjectIDs"];
                List<int> ProjectIDList = new List<int>();
                if (RoomIDList.Count == 0)
                {
                    if (!string.IsNullOrEmpty(ProjectIDs))
                    {
                        ProjectIDList = JsonConvert.DeserializeObject<List<int>>(ProjectIDs).Where(p => p != 1).ToList();
                    }
                    ProjectIDList = WebUtil.GetMyProjects(WebUtil.GetUser(context).UserID, ProjectIDList).Where(p => p.ID != 1).Select(p => p.ID).ToList();
                }
                DateTime StartTime = DateTime.MinValue;
                DateTime.TryParse(context.Request.Params["StartChargeTime"], out StartTime);
                DateTime EndTime = DateTime.MinValue;
                DateTime.TryParse(context.Request.Params["EndChargeTime"], out EndTime);
                int RoomID = WebUtil.GetIntValue(context, "RoomID");
                string ChargeIDs = context.Request.Params["ChargeIDs"];
                List<int> ChargeIDList = new List<int>();
                if (!string.IsNullOrEmpty(ChargeIDs))
                {
                    ChargeIDList = JsonConvert.DeserializeObject<List<int>>(ChargeIDs).Where(p => p != 0).ToList();
                }
                bool canexport = WebUtil.GetBoolValue(context, "canexport");
                DataGrid dg = ChargeSummaryDepositChargeAnalysis.GetDepositChargeSummaryGroupByChargeName(ProjectIDList, RoomIDList, StartTime, EndTime, CompanyID, ChargeIDList, RoomID, UserID: WebUtil.GetUser(context).UserID, canexport: canexport);
                bool showFooter = false;
                if (!string.IsNullOrEmpty(context.Request["showFooter"]))
                {
                    bool.TryParse(context.Request["showFooter"], out showFooter);
                }
                if (showFooter)
                {
                    var rows = (dg.rows as ChargeSummaryDepositChargeAnalysis[]).ToList();
                    var footeritem = new ChargeSummaryDepositChargeAnalysis();
                    footeritem.Name = "合计";
                    footeritem.PreTotalCost = rows.Sum(p => p.PreTotalCost);
                    footeritem.Cost = rows.Sum(p => p.Cost);
                    footeritem.ChargeReturnCost = rows.Sum(p => p.ChargeReturnCost);
                    footeritem.AfterTotalCost = rows.Sum(p => p.AfterTotalCost);
                    rows.Add(footeritem);
                    dg.rows = rows;
                }
                if (canexport)
                {
                    string downloadurl = string.Empty;
                    string error = string.Empty;
                    bool status = APPCode.ExportHelper.DownloadDepositSummaryByChargename(dg, out downloadurl, out error);
                    WebUtil.WriteJson(context, new { status = status, downloadurl = downloadurl, error = error });
                    return;
                }
                string result = JsonConvert.SerializeObject(dg);
                context.Response.Write(result);
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("AnalysisHandler", "visit: loaddepositsummarybychargename", ex);
                context.Response.Write("{\"rows\":[],\"total\":0,\"page\":0}");
            }
        }
        private void loadchaobiaoanalysislist(HttpContext context)
        {
            try
            {
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                string RoomIDs = context.Request.Params["RoomIDs"];
                List<int> RoomIDList = new List<int>();
                if (!string.IsNullOrEmpty(RoomIDs))
                {
                    RoomIDList = JsonConvert.DeserializeObject<List<int>>(RoomIDs);
                }
                string ProjectIDs = context.Request.Params["ProjectIDs"];
                List<int> ProjectIDList = new List<int>();
                if (RoomIDList.Count == 0)
                {
                    if (!string.IsNullOrEmpty(ProjectIDs))
                    {
                        ProjectIDList = JsonConvert.DeserializeObject<List<int>>(ProjectIDs).Where(p => p != 1).ToList();
                    }
                    ProjectIDList = WebUtil.GetMyProjects(WebUtil.GetUser(context).UserID, ProjectIDList).Where(p => p.ID != 1).Select(p => p.ID).ToList();
                }
                string ChargeIds = context.Request["ChargeIDs"];
                List<int> ChargeIDist = new List<int>();
                if (!string.IsNullOrEmpty(ChargeIds))
                {
                    ChargeIDist = JsonConvert.DeserializeObject<List<int>>(ChargeIds);
                }
                int ChargeStatus = WebUtil.GetIntValue(context, "ChargeStatus");
                DateTime StartWriteDate = WebUtil.GetDateValue(context, "StartWriteDate");
                DateTime EndWriteDate = WebUtil.GetDateValue(context, "EndWriteDate");
                string BiaoCategory = context.Request.Params["BiaoCategory"];
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                bool ShowFooter = false;
                bool.TryParse(context.Request.Params["ShowFooter"], out ShowFooter);
                bool canexport = WebUtil.GetBoolValue(context, "canexport");
                DataGrid dg = ViewImportFeeDetail.GetChaoBiaoAnalysisDetailGrid(context.Request.Params["Keywords"], ChargeIDist, RoomIDList, ProjectIDList, ChargeStatus, StartWriteDate, EndWriteDate, BiaoCategory, "order by WriteDate desc,[DefaultOrder] asc", startRowIndex, pageSize, canexport: canexport);
                if (canexport)
                {
                    string downloadurl = string.Empty;
                    string error = string.Empty;
                    bool status = APPCode.ExportHelper.DownLoadChaoBiaCostAnalysisData(dg, out downloadurl, out error);
                    WebUtil.WriteJson(context, new { status = status, downloadurl = downloadurl, error = error });
                    return;
                }
                else
                {
                    WebUtil.WriteJson(context, dg);
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("AnalysisHandler", "visit: loadchaobiaoanalysislist", ex);
                context.Response.Write("{\"rows\":[],\"total\":0,\"page\":0}");
            }
        }
        private void loadshoufeilvquanzebychargemoneytype(HttpContext context)
        {
            try
            {
                string RoomIDs = context.Request.Params["RoomIDs"];
                List<int> RoomIDList = new List<int>();
                if (!string.IsNullOrEmpty(RoomIDs))
                {
                    RoomIDList = JsonConvert.DeserializeObject<List<int>>(RoomIDs);
                }
                string ProjectIDs = context.Request.Params["ProjectIDs"];
                List<int> ProjectIDList = new List<int>();
                if (RoomIDList.Count == 0)
                {
                    if (!string.IsNullOrEmpty(ProjectIDs))
                    {
                        ProjectIDList = JsonConvert.DeserializeObject<List<int>>(ProjectIDs).Where(p => p != 1).ToList();
                    }
                    ProjectIDList = WebUtil.GetMyProjects(WebUtil.GetUser(context).UserID, ProjectIDList).Where(p => p.ID != 1).Select(p => p.ID).ToList();
                }
                DateTime StartTime = DateTime.MinValue;
                DateTime.TryParse(context.Request.Params["StartChargeTime"], out StartTime);
                DateTime EndTime = DateTime.MinValue;
                DateTime.TryParse(context.Request.Params["EndChargeTime"], out EndTime);
                int RoomID = WebUtil.GetIntValue(context, "RoomID");
                string RoomType = context.Request["RoomType"];
                string ChargeIDs = context.Request.Params["ChargeIDs"];
                List<int> ChargeIDList = new List<int>();
                if (!string.IsNullOrEmpty(ChargeIDs))
                {
                    ChargeIDList = JsonConvert.DeserializeObject<List<int>>(ChargeIDs).Where(p => p != 0).ToList();
                }
                var dg = HandlerHelper.loadshoufeilvquanzebychargemoneytype(RoomID, StartTime, EndTime, ChargeIDList, ProjectIDList, RoomIDList);
                WebUtil.WriteJson(context, dg);
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("AnalysisHandler", "visit: loadshoufeilvquanzebychargemoneytype", ex);
                WebUtil.WriteJson(context, new Foresight.DataAccess.Ui.DataGrid());
            }
        }
        private void loadshoufeilvquanzebycharge(HttpContext context)
        {
            try
            {
                int CompanyID = WebUtil.GetCompanyID(context);
                string RoomIDs = context.Request.Params["RoomIDs"];
                List<int> RoomIDList = new List<int>();
                if (!string.IsNullOrEmpty(RoomIDs))
                {
                    RoomIDList = JsonConvert.DeserializeObject<List<int>>(RoomIDs);
                }
                string ProjectIDs = context.Request.Params["ProjectIDs"];
                List<int> ProjectIDList = new List<int>();
                if (RoomIDList.Count == 0)
                {
                    if (!string.IsNullOrEmpty(ProjectIDs))
                    {
                        ProjectIDList = JsonConvert.DeserializeObject<List<int>>(ProjectIDs).Where(p => p != 1).ToList();
                    }
                    ProjectIDList = WebUtil.GetMyProjects(WebUtil.GetUser(context).UserID, ProjectIDList).Where(p => p.ID != 1).Select(p => p.ID).ToList();
                }
                DateTime StartTime = DateTime.MinValue;
                DateTime.TryParse(context.Request.Params["StartChargeTime"], out StartTime);
                DateTime EndTime = DateTime.MinValue;
                DateTime.TryParse(context.Request.Params["EndChargeTime"], out EndTime);
                int RoomID = WebUtil.GetIntValue(context, "RoomID");
                string RoomType = context.Request["RoomType"];
                string ChargeIDs = context.Request.Params["ChargeIDs"];
                List<int> ChargeIDList = new List<int>();
                if (!string.IsNullOrEmpty(ChargeIDs))
                {
                    ChargeIDList = JsonConvert.DeserializeObject<List<int>>(ChargeIDs).Where(p => p != 0).ToList();
                }
                if (RoomID > 0)
                {
                    if (RoomType.Equals("Room"))
                    {
                        ProjectIDList = new List<int>();
                        RoomIDList = new List<int>();
                        RoomIDList.Add(RoomID);
                    }
                }
                int ShowType = WebUtil.GetIntValue(context, "ShowType");
                bool IsQuanZe = true;
                if (!string.IsNullOrEmpty(context.Request["IsQuanZe"]))
                {
                    bool.TryParse(context.Request["IsQuanZe"], out IsQuanZe);
                }
                bool IsAnalysisQuery = WebUtil.GetIntValue(context, "IsAnalysisQuery") == 1;
                bool IsShouRuZhiChuAnalysis = WebUtil.GetIntValue(context, "IsShouRuZhiChuAnalysis") == 1;
                bool canexport = WebUtil.GetBoolValue(context, "canexport");
                var dg = HandlerHelper.loadshoufeilvquanzebycharge(0, int.MaxValue, CompanyID, RoomIDList, ProjectIDList, StartTime, EndTime, ChargeIDList, ShowType, IsQuanZe, RoomType, RoomID, IsAnalysisQuery: IsAnalysisQuery, IsShouRuZhiChuAnalysis: IsShouRuZhiChuAnalysis, canexport: canexport);
                if (canexport)
                {
                    string downloadurl = string.Empty;
                    string error = string.Empty;
                    bool status = false;
                    string source = context.Request["source"];
                    source = string.IsNullOrEmpty(source) ? "" : source;
                    if (source.Equals("ShouRuZhiChuSumaryAnalysis"))
                    {
                        status = APPCode.ExportHelper.DownLoadShouRuZhiChuSummaryAnalysisData(dg, "Charge", out downloadurl, out error);
                    }
                    else
                    {
                        status = APPCode.ExportHelper.DownLoadShouFeiLvAnalysisData(dg, "Charge", out downloadurl, out error);
                    }
                    WebUtil.WriteJson(context, new { status = status, downloadurl = downloadurl, error = error });
                    return;
                }
                WebUtil.WriteJson(context, dg);
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("AnalysisHandler", "visit: loadshoufeilvquanzebycharge", ex);
                WebUtil.WriteJson(context, new Foresight.DataAccess.Ui.DataGrid());
            }
        }
        private void loadshoufeilvquanzebyproject(HttpContext context)
        {
            try
            {
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                page = string.IsNullOrEmpty(page) ? "1" : page;
                rows = string.IsNullOrEmpty(rows) ? "50" : rows;
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                int CompanyID = 0;
                int.TryParse(context.Request.Params["CompanyID"], out CompanyID);
                string RoomIDs = context.Request.Params["RoomIDs"];
                List<int> RoomIDList = new List<int>();
                if (!string.IsNullOrEmpty(RoomIDs))
                {
                    RoomIDList = JsonConvert.DeserializeObject<List<int>>(RoomIDs);
                }
                string ProjectIDs = context.Request.Params["ProjectIDs"];
                List<int> ProjectIDList = new List<int>();
                if (RoomIDList.Count == 0)
                {
                    if (!string.IsNullOrEmpty(ProjectIDs))
                    {
                        ProjectIDList = JsonConvert.DeserializeObject<List<int>>(ProjectIDs).Where(p => p != 1).ToList();
                    }
                    ProjectIDList = WebUtil.GetMyProjects(WebUtil.GetUser(context).UserID, ProjectIDList).Where(p => p.ID != 1).Select(p => p.ID).ToList();
                }
                DateTime StartTime = DateTime.MinValue;
                DateTime.TryParse(context.Request.Params["StartChargeTime"], out StartTime);
                DateTime EndTime = DateTime.MinValue;
                DateTime.TryParse(context.Request.Params["EndChargeTime"], out EndTime);
                string ChargeIDs = context.Request.Params["ChargeIDs"];
                List<int> ChargeIDList = new List<int>();
                if (!string.IsNullOrEmpty(ChargeIDs))
                {
                    ChargeIDList = JsonConvert.DeserializeObject<List<int>>(ChargeIDs).Where(p => p != 0).ToList();
                }
                int ShowType = WebUtil.GetIntValue(context, "ShowType");
                bool IsQuanZe = true;
                if (!string.IsNullOrEmpty(context.Request["IsQuanZe"]))
                {
                    bool.TryParse(context.Request["IsQuanZe"], out IsQuanZe);
                }
                bool canexport = WebUtil.GetBoolValue(context, "canexport");
                int ChargeTypeID = -1;
                if (!string.IsNullOrEmpty(context.Request["ChargeTypeID"]))
                {
                    ChargeTypeID = WebUtil.GetIntValue(context, "ChargeTypeID");
                }
                var dg = HandlerHelper.loadshoufeilvquanzebyproject(startRowIndex, pageSize, CompanyID, RoomIDList, ProjectIDList, StartTime, EndTime, ChargeIDList, ShowType, IsQuanZe, canexport: canexport, ChargeTypeID: ChargeTypeID);
                if (canexport)
                {
                    string source = context.Request["source"];
                    source = string.IsNullOrEmpty(source) ? "" : source;
                    string downloadurl = string.Empty;
                    string error = string.Empty;
                    bool status = false;
                    if (source.Equals("ShouFeiLvQuanZeByMonth"))
                    {
                        status = APPCode.ExportHelper.DownLoadShouFeiLvQuanZeByMonthData(dg, "Project", out downloadurl, out error);
                    }
                    else
                    {
                        status = APPCode.ExportHelper.DownLoadShouFeiLvAnalysisData(dg, "Project", out downloadurl, out error);
                    }
                    WebUtil.WriteJson(context, new { status = status, downloadurl = downloadurl, error = error });
                    return;
                }
                WebUtil.WriteJson(context, dg);
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("AnalysisHandler", "visit: loadshoufeilvquanzebyproject", ex);
                WebUtil.WriteJson(context, new Foresight.DataAccess.Ui.DataGrid());
            }
        }
        private void loadshoufeilvquanzebyroom(HttpContext context)
        {
            try
            {
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                page = string.IsNullOrEmpty(page) ? "1" : page;
                rows = string.IsNullOrEmpty(rows) ? "50" : rows;
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                int CompanyID = 0;
                int.TryParse(context.Request.Params["CompanyID"], out CompanyID);
                string RoomIDs = context.Request.Params["RoomIDs"];
                List<int> RoomIDList = new List<int>();
                if (!string.IsNullOrEmpty(RoomIDs))
                {
                    RoomIDList = JsonConvert.DeserializeObject<List<int>>(RoomIDs);
                }
                string ProjectIDs = context.Request.Params["ProjectIDs"];
                List<int> ProjectIDList = new List<int>();
                if (RoomIDList.Count == 0)
                {
                    if (!string.IsNullOrEmpty(ProjectIDs))
                    {
                        ProjectIDList = JsonConvert.DeserializeObject<List<int>>(ProjectIDs).Where(p => p != 1).ToList();
                    }
                    ProjectIDList = WebUtil.GetMyProjects(WebUtil.GetUser(context).UserID, ProjectIDList).Where(p => p.ID != 1).Select(p => p.ID).ToList();
                }
                DateTime StartTime = DateTime.MinValue;
                DateTime.TryParse(context.Request.Params["StartChargeTime"], out StartTime);
                DateTime EndTime = DateTime.MinValue;
                DateTime.TryParse(context.Request.Params["EndChargeTime"], out EndTime);
                string ChargeIDs = context.Request.Params["ChargeIDs"];
                List<int> ChargeIDList = new List<int>();
                if (!string.IsNullOrEmpty(ChargeIDs))
                {
                    ChargeIDList = JsonConvert.DeserializeObject<List<int>>(ChargeIDs).Where(p => p != 0).ToList();
                }
                int ShowType = WebUtil.GetIntValue(context, "ShowType");
                bool IsQuanZe = true;
                if (!string.IsNullOrEmpty(context.Request["IsQuanZe"]))
                {
                    bool.TryParse(context.Request["IsQuanZe"], out IsQuanZe);
                }
                bool canexport = WebUtil.GetBoolValue(context, "canexport");
                var dg = HandlerHelper.loadshoufeilvquanzebyroom(startRowIndex, pageSize, CompanyID, RoomIDList, ProjectIDList, StartTime, EndTime, ChargeIDList, ShowType, IsQuanZe, canexport: canexport);
                if (canexport)
                {
                    string source = context.Request["source"];
                    source = string.IsNullOrEmpty(source) ? "" : source;
                    string downloadurl = string.Empty;
                    string error = string.Empty;
                    bool status = false;
                    if (source.Equals("ShouFeiLvQuanZeByMonth"))
                    {
                        status = APPCode.ExportHelper.DownLoadShouFeiLvQuanZeByMonthData(dg, "Room", out downloadurl, out error);
                    }
                    else
                    {
                        status = APPCode.ExportHelper.DownLoadShouFeiLvAnalysisData(dg, "Room", out downloadurl, out error);
                    }
                    WebUtil.WriteJson(context, new { status = status, downloadurl = downloadurl, error = error });
                    return;
                }
                WebUtil.WriteJson(context, dg);
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("AnalysisHandler", "visit: loadshoufeilvquanzebyroom", ex);
                WebUtil.WriteJson(context, new Foresight.DataAccess.Ui.DataGrid());
            }
        }
        private void loadchaobiaoanalysisbycharge(HttpContext context)
        {
            try
            {
                int CompanyID = 0;
                int.TryParse(context.Request.Params["CompanyID"], out CompanyID);
                string RoomIDs = context.Request.Params["RoomIDs"];
                List<int> RoomIDList = new List<int>();
                if (!string.IsNullOrEmpty(RoomIDs))
                {
                    RoomIDList = JsonConvert.DeserializeObject<List<int>>(RoomIDs);
                }
                string ProjectIDs = context.Request.Params["ProjectIDs"];
                List<int> ProjectIDList = new List<int>();
                if (RoomIDList.Count == 0)
                {
                    if (!string.IsNullOrEmpty(ProjectIDs))
                    {
                        ProjectIDList = JsonConvert.DeserializeObject<List<int>>(ProjectIDs).Where(p => p != 1).ToList();
                    }
                    ProjectIDList = WebUtil.GetMyProjects(WebUtil.GetUser(context).UserID, ProjectIDList).Where(p => p.ID != 1).Select(p => p.ID).ToList();
                }
                DateTime StartTime = DateTime.MinValue;
                DateTime.TryParse(context.Request.Params["StartChargeTime"], out StartTime);
                DateTime EndTime = DateTime.MinValue;
                DateTime.TryParse(context.Request.Params["EndChargeTime"], out EndTime);
                int RoomID = WebUtil.GetIntValue(context, "RoomID");
                string ChargeIDs = context.Request.Params["ChargeIDs"];
                List<int> ChargeIDList = new List<int>();
                if (!string.IsNullOrEmpty(ChargeIDs))
                {
                    ChargeIDList = JsonConvert.DeserializeObject<List<int>>(ChargeIDs).Where(p => p != 0).ToList();
                }
                DataGrid dg = ChargeSummaryChaoBiaoAnalysis.GetChargeSummaryChaoBiaoAnalysisByChargeName(ProjectIDList, RoomIDList, StartTime, EndTime, CompanyID, ChargeIDList, RoomID, UserID: WebUtil.GetUser(context).UserID);
                string result = JsonConvert.SerializeObject(dg);
                context.Response.Write(result);
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("AnalysisHandler", "visit: loadprechargesummarybychargename", ex);
                context.Response.Write("{\"rows\":[],\"total\":0,\"page\":0}");
            }
        }
        private void loadchaobiaoanalysisbyroom(HttpContext context)
        {
            try
            {
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                page = string.IsNullOrEmpty(page) ? "1" : page;
                rows = string.IsNullOrEmpty(rows) ? "50" : rows;
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                int CompanyID = 0;
                int.TryParse(context.Request.Params["CompanyID"], out CompanyID);
                string RoomIDs = context.Request.Params["RoomIDs"];
                List<int> RoomIDList = new List<int>();
                if (!string.IsNullOrEmpty(RoomIDs))
                {
                    RoomIDList = JsonConvert.DeserializeObject<List<int>>(RoomIDs);
                }
                string ProjectIDs = context.Request.Params["ProjectIDs"];
                List<int> ProjectIDList = new List<int>();
                if (RoomIDList.Count == 0)
                {
                    if (!string.IsNullOrEmpty(ProjectIDs))
                    {
                        ProjectIDList = JsonConvert.DeserializeObject<List<int>>(ProjectIDs).Where(p => p != 1).ToList();
                    }
                    ProjectIDList = WebUtil.GetMyProjects(WebUtil.GetUser(context).UserID, ProjectIDList).Where(p => p.ID != 1).Select(p => p.ID).ToList();
                }
                DateTime StartTime = DateTime.MinValue;
                DateTime.TryParse(context.Request.Params["StartChargeTime"], out StartTime);
                DateTime EndTime = DateTime.MinValue;
                DateTime.TryParse(context.Request.Params["EndChargeTime"], out EndTime);
                string ChargeIDs = context.Request.Params["ChargeIDs"];
                List<int> ChargeIDList = new List<int>();
                if (!string.IsNullOrEmpty(ChargeIDs))
                {
                    ChargeIDList = JsonConvert.DeserializeObject<List<int>>(ChargeIDs).Where(p => p != 0).ToList();
                }
                DataGrid dg = ChargeSummaryChaoBiaoAnalysis.GetChargeSummaryChaoBiaoAnalysisByRoom(ProjectIDList, RoomIDList, StartTime, EndTime, CompanyID, ChargeIDList, "order by DefaultOrder asc", startRowIndex, pageSize, UserID: WebUtil.GetUser(context).UserID);
                string result = JsonConvert.SerializeObject(dg);
                context.Response.Write(result);
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("AnalysisHandler", "visit: loadchaobiaoanalysisbyroom", ex);
                context.Response.Write("{\"rows\":[],\"total\":0,\"page\":0}");
            }
        }
        private void loadchaobiaoanalysisbyproject(HttpContext context)
        {
            try
            {
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                page = string.IsNullOrEmpty(page) ? "1" : page;
                rows = string.IsNullOrEmpty(rows) ? "50" : rows;
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                int CompanyID = 0;
                int.TryParse(context.Request.Params["CompanyID"], out CompanyID);
                string RoomIDs = context.Request.Params["RoomIDs"];
                List<int> RoomIDList = new List<int>();
                if (!string.IsNullOrEmpty(RoomIDs))
                {
                    RoomIDList = JsonConvert.DeserializeObject<List<int>>(RoomIDs);
                }
                string ProjectIDs = context.Request.Params["ProjectIDs"];
                List<int> ProjectIDList = new List<int>();
                if (RoomIDList.Count == 0)
                {
                    if (!string.IsNullOrEmpty(ProjectIDs))
                    {
                        ProjectIDList = JsonConvert.DeserializeObject<List<int>>(ProjectIDs).Where(p => p != 1).ToList();
                    }
                    ProjectIDList = WebUtil.GetMyProjects(WebUtil.GetUser(context).UserID, ProjectIDList).Where(p => p.ID != 1).Select(p => p.ID).ToList();
                }
                DateTime StartTime = DateTime.MinValue;
                DateTime.TryParse(context.Request.Params["StartChargeTime"], out StartTime);
                DateTime EndTime = DateTime.MinValue;
                DateTime.TryParse(context.Request.Params["EndChargeTime"], out EndTime);
                string ChargeIDs = context.Request.Params["ChargeIDs"];
                List<int> ChargeIDList = new List<int>();
                if (!string.IsNullOrEmpty(ChargeIDs))
                {
                    ChargeIDList = JsonConvert.DeserializeObject<List<int>>(ChargeIDs).Where(p => p != 0).ToList();
                }
                var dg = ChargeSummaryChaoBiaoAnalysis.GetChargeSummaryChaoBiaoAnalysisByProject(ProjectIDList, RoomIDList, StartTime, EndTime, ChargeIDList, UserID: WebUtil.GetUser(context).UserID);
                WebUtil.WriteJson(context, dg);
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("AnalysisHandler", "visit: loadchaobiaoanalysisbyproject", ex);
                context.Response.Write("{\"rows\":[],\"total\":0,\"page\":0}");
            }
        }
        private void loadprechargesummarybyroom(HttpContext context)
        {
            try
            {
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                page = string.IsNullOrEmpty(page) ? "1" : page;
                rows = string.IsNullOrEmpty(rows) ? "50" : rows;
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                int CompanyID = 0;
                int.TryParse(context.Request.Params["CompanyID"], out CompanyID);
                string RoomIDs = context.Request.Params["RoomIDs"];
                List<int> RoomIDList = new List<int>();
                if (!string.IsNullOrEmpty(RoomIDs))
                {
                    RoomIDList = JsonConvert.DeserializeObject<List<int>>(RoomIDs);
                }
                string ProjectIDs = context.Request.Params["ProjectIDs"];
                List<int> ProjectIDList = new List<int>();
                if (RoomIDList.Count == 0)
                {
                    if (!string.IsNullOrEmpty(ProjectIDs))
                    {
                        ProjectIDList = JsonConvert.DeserializeObject<List<int>>(ProjectIDs).Where(p => p != 1).ToList();
                    }
                    ProjectIDList = WebUtil.GetMyProjects(WebUtil.GetUser(context).UserID, ProjectIDList).Where(p => p.ID != 1).Select(p => p.ID).ToList();
                }
                DateTime StartTime = DateTime.MinValue;
                DateTime.TryParse(context.Request.Params["StartChargeTime"], out StartTime);
                DateTime EndTime = DateTime.MinValue;
                DateTime.TryParse(context.Request.Params["EndChargeTime"], out EndTime);
                string ChargeIDs = context.Request.Params["ChargeIDs"];
                List<int> ChargeIDList = new List<int>();
                if (!string.IsNullOrEmpty(ChargeIDs))
                {
                    ChargeIDList = JsonConvert.DeserializeObject<List<int>>(ChargeIDs).Where(p => p != 0).ToList();
                }
                bool canexport = WebUtil.GetBoolValue(context, "canexport");
                DataGrid dg = ChargeSummaryPreChargeAnalysis.GetPreChargeSummaryGroupByRoom(ProjectIDList, RoomIDList, StartTime, EndTime, CompanyID, ChargeIDList, "order by DefaultOrder asc", startRowIndex, pageSize, UserID: WebUtil.GetUser(context).UserID, canexport: canexport);
                if (canexport)
                {
                    string downloadurl = string.Empty;
                    string error = string.Empty;
                    bool status = APPCode.ExportHelper.DownloadPreChargeSummary(dg, out downloadurl, out error);
                    WebUtil.WriteJson(context, new { status = status, downloadurl = downloadurl, error = error });
                    return;
                }
                string result = JsonConvert.SerializeObject(dg);
                context.Response.Write(result);
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("AnalysisHandler", "visit: loadprechargesummarybyroom", ex);
                context.Response.Write("{\"rows\":[],\"total\":0,\"page\":0}");
            }
        }
        private void loadprechargesummarybychargename(HttpContext context)
        {
            try
            {
                int CompanyID = 0;
                int.TryParse(context.Request.Params["CompanyID"], out CompanyID);
                string RoomIDs = context.Request.Params["RoomIDs"];
                List<int> RoomIDList = new List<int>();
                if (!string.IsNullOrEmpty(RoomIDs))
                {
                    RoomIDList = JsonConvert.DeserializeObject<List<int>>(RoomIDs);
                }
                string ProjectIDs = context.Request.Params["ProjectIDs"];
                List<int> ProjectIDList = new List<int>();
                if (RoomIDList.Count == 0)
                {
                    if (!string.IsNullOrEmpty(ProjectIDs))
                    {
                        ProjectIDList = JsonConvert.DeserializeObject<List<int>>(ProjectIDs).Where(p => p != 1).ToList();
                    }
                    ProjectIDList = WebUtil.GetMyProjects(WebUtil.GetUser(context).UserID, ProjectIDList).Where(p => p.ID != 1).Select(p => p.ID).ToList();
                }
                DateTime StartTime = DateTime.MinValue;
                DateTime.TryParse(context.Request.Params["StartChargeTime"], out StartTime);
                DateTime EndTime = DateTime.MinValue;
                DateTime.TryParse(context.Request.Params["EndChargeTime"], out EndTime);
                int RoomID = WebUtil.GetIntValue(context, "RoomID");
                string ChargeIDs = context.Request.Params["ChargeIDs"];
                List<int> ChargeIDList = new List<int>();
                if (!string.IsNullOrEmpty(ChargeIDs))
                {
                    ChargeIDList = JsonConvert.DeserializeObject<List<int>>(ChargeIDs).Where(p => p != 0).ToList();
                }
                bool canexport = WebUtil.GetBoolValue(context, "canexport");
                DataGrid dg = ChargeSummaryPreChargeAnalysis.GetPreChargeSummaryGroupByChargeName(ProjectIDList, RoomIDList, StartTime, EndTime, CompanyID, ChargeIDList, RoomID);
                if (canexport)
                {
                    string downloadurl = string.Empty;
                    string error = string.Empty;
                    bool status = false;
                    string source = context.Request["source"];
                    source = string.IsNullOrEmpty(source) ? "" : source;
                    if (source.Equals("ShouRuZhiChuSumaryAnalysis"))
                    {
                        status = APPCode.ExportHelper.DownloadPreChargeShouRuZhiChuSummary(dg, out downloadurl, out error);
                    }
                    else
                    {
                        status = APPCode.ExportHelper.DownloadPreChargeSummary(dg, out downloadurl, out error);
                    }
                    WebUtil.WriteJson(context, new { status = status, downloadurl = downloadurl, error = error });
                    return;
                }
                string result = JsonConvert.SerializeObject(dg);
                context.Response.Write(result);
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("AnalysisHandler", "visit: loadprechargesummarybychargename", ex);
                context.Response.Write("{\"rows\":[],\"total\":0,\"page\":0}");
            }
        }
        private void loadprechargesummarybyproject(HttpContext context)
        {
            try
            {
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                page = string.IsNullOrEmpty(page) ? "1" : page;
                rows = string.IsNullOrEmpty(rows) ? "50" : rows;
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                int CompanyID = 0;
                int.TryParse(context.Request.Params["CompanyID"], out CompanyID);
                string RoomIDs = context.Request.Params["RoomIDs"];
                List<int> RoomIDList = new List<int>();
                if (!string.IsNullOrEmpty(RoomIDs))
                {
                    RoomIDList = JsonConvert.DeserializeObject<List<int>>(RoomIDs);
                }
                string ProjectIDs = context.Request.Params["ProjectIDs"];
                List<int> ProjectIDList = new List<int>();
                if (RoomIDList.Count == 0)
                {
                    if (!string.IsNullOrEmpty(ProjectIDs))
                    {
                        ProjectIDList = JsonConvert.DeserializeObject<List<int>>(ProjectIDs).Where(p => p != 1).ToList();
                    }
                    ProjectIDList = WebUtil.GetMyProjects(WebUtil.GetUser(context).UserID, ProjectIDList).Where(p => p.ID != 1).Select(p => p.ID).ToList();
                }
                DateTime StartTime = DateTime.MinValue;
                DateTime.TryParse(context.Request.Params["StartChargeTime"], out StartTime);
                DateTime EndTime = DateTime.MinValue;
                DateTime.TryParse(context.Request.Params["EndChargeTime"], out EndTime);
                string ChargeIDs = context.Request.Params["ChargeIDs"];
                List<int> ChargeIDList = new List<int>();
                if (!string.IsNullOrEmpty(ChargeIDs))
                {
                    ChargeIDList = JsonConvert.DeserializeObject<List<int>>(ChargeIDs).Where(p => p != 0).ToList();
                }
                bool canexport = WebUtil.GetBoolValue(context, "canexport");
                DataGrid dg = ChargeSummaryPreChargeAnalysis.GetPreChargeSummaryGroupByProject(ProjectIDList, RoomIDList, StartTime, EndTime, CompanyID, ChargeIDList, "order by DefaultOrder asc", startRowIndex, pageSize, UserID: WebUtil.GetUser(context).UserID, canexport: canexport);
                if (canexport)
                {
                    string downloadurl = string.Empty;
                    string error = string.Empty;
                    bool status = APPCode.ExportHelper.DownloadPreChargeSummary(dg, out downloadurl, out error);
                    WebUtil.WriteJson(context, new { status = status, downloadurl = downloadurl, error = error });
                    return;
                }
                string result = JsonConvert.SerializeObject(dg);
                context.Response.Write(result);
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("AnalysisHandler", "visit: loadprechargesummarybyproject", ex);
                context.Response.Write("{\"rows\":[],\"total\":0,\"page\":0}");
            }
        }
        private void loadroomruzhustaticlist(HttpContext context)
        {
            int ParentID = WebUtil.GetIntValue(context, "ProjectID");
            List<int> EqualProjectIDList = new List<int>();
            List<int> InProjectIDList = new List<int>();
            List<int> ProjectIDList = new List<int>();
            Web.APPCode.CacheHelper.GetMyProjectListByUserID(WebUtil.GetUser(context).UserID, out EqualProjectIDList, out InProjectIDList, ProjectIDList: ProjectIDList);
            var projectList = Foresight.DataAccess.Project.GetAllChildProjectListByEqualInIDList(EqualProjectIDList, InProjectIDList, ParentID);
            StringBuilder builder = new StringBuilder();
            builder.Append("{");
            builder.Append("\"total\":" + projectList.Length + ",");
            builder.Append("\"rows\":[");
            int i = 0;
            foreach (var project in projectList)
            {
                builder.Append("{");
                builder.Append("\"id\":" + project.ID + ",");
                builder.Append("\"_parentId\":" + (ParentID == 1 ? 0 : ParentID) + ",");
                if (project.isParent)
                {
                    builder.Append("\"state\":\"closed\",");
                }
                builder.Append("\"管理区\":\"" + project.Name + "\",");
                builder.Append("\"资源类别\":\"" + project.TypeDesc + "\",");
                builder.Append("\"计费面积\":" + RoomBasic.GetTotalBuildingArea(project.ID) + ",");
                builder.Append("\"合同面积\":" + RoomBasic.GetTotalContractAreaArea(project.ID) + ",");
                var countList = Foresight.DataAccess.RoomBasicStatic.GetRoomBasicStaticCountByParams(project.ID);
                int total = 0;
                if (countList.Length > 0)
                {
                    foreach (var item in countList)
                    {
                        if (!string.IsNullOrEmpty(item.RoomState) && !item.RoomState.Equals("空置"))
                        {
                            builder.Append("\"" + item.RoomState + "\":" + item.TotalCount + "");
                            builder.Append(",");
                            total += item.TotalCount;
                        }
                    }
                }
                int RoomTotalCount = RoomBasic.GetTotalRoomCount(project.ID);
                int KongZhiCount = (RoomTotalCount - total) > 0 ? (RoomTotalCount - total) : 0;
                builder.Append("\"空置\":" + KongZhiCount + ",");
                builder.Append("\"总计\":" + RoomTotalCount + "");
                if (i == (projectList.Length - 1))
                {
                    builder.Append("}");
                }
                else
                {
                    builder.Append("},");
                }
                i++;
            }
            builder.Append("]}");
            string tables = builder.ToString();
            context.Response.Write(tables);
        }
        private void loadruzhustaticcolumn(HttpContext context)
        {
            var list = Foresight.DataAccess.RoomState.GetRoomStates().OrderBy(p => p.SortOrder).ToList();
            StringBuilder columns = new StringBuilder("[[");
            string ColumnField = "field: '管理区', title: '管理区', width: 100";
            columns.Append("{" + ColumnField + "},");
            ColumnField = "field: '资源类别', title: '资源类别', width: 200";
            columns.Append("{" + ColumnField + "},");
            ColumnField = "field: '计费面积', formatter: formatCount, title: '计费面积', width: 80";
            columns.Append("{" + ColumnField + "},");
            ColumnField = "field: '合同面积', formatter: formatCount, title: '合同面积', width: 80";
            columns.Append("{" + ColumnField + "},");
            foreach (var item in list)
            {
                ColumnField = "field: '" + item.Name + "', formatter: formatCount, title: '" + item.Name + "', width: 100";
                columns.Append("{" + ColumnField + "},");
            }
            ColumnField = "field: '总计', formatter: formatCount, title: '总计', width: 100";
            columns.Append("{" + ColumnField + "},");
            columns.Remove(columns.Length - 1, 1);
            columns.Append("]]");
            var items = new
            {
                status = list.Count > 0 ? true : false,
                columns = columns.ToString(),
            };
            context.Response.Write(JsonConvert.SerializeObject(items));
        }
        private void loadzckbsummary(HttpContext context)
        {
            DateTime StartTime = DateTime.MinValue;
            DateTime EndTime = DateTime.MinValue;
            string Title = string.Empty;
            int UserID = WebUtil.GetIntValue(context, "UserID");
            AnalysisTimeHelper.GetZCKB(UserID, out StartTime, out EndTime, out Title);
            string RoomIDs = context.Request.Params["RoomIDs"];
            List<int> RoomIDList = new List<int>();
            if (!string.IsNullOrEmpty(RoomIDs))
            {
                RoomIDList = JsonConvert.DeserializeObject<List<int>>(RoomIDs);
            }
            string ProjectIDs = context.Request.Params["ProjectIDs"];
            List<int> ProjectIDList = new List<int>();
            if (RoomIDList.Count == 0)
            {
                if (!string.IsNullOrEmpty(ProjectIDs))
                {
                    ProjectIDList = JsonConvert.DeserializeObject<List<int>>(ProjectIDs).Where(p => p != 1).ToList();
                }
                ProjectIDList = WebUtil.GetMyProjects(WebUtil.GetUser(context).UserID, ProjectIDList).Where(p => p.ID != 1).Select(p => p.ID).ToList();
            }
            PaySummaryDetail[] feelist = PaySummaryDetail.GetPaySummaryDetailListByRoomID(RoomIDList, ProjectIDList, StartTime, EndTime, UserID: WebUtil.GetUser(context).UserID).Where(p => p.TotalMoney > 0).ToArray();
            var items = new { ZCKBSummaryList = feelist, Title = Title };
            string results = JsonConvert.SerializeObject(items);
            context.Response.Write(results);
        }
        private void getshoufeilv(HttpContext context)
        {
            try
            {
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                page = string.IsNullOrEmpty(page) ? "1" : page;
                rows = string.IsNullOrEmpty(rows) ? "50" : rows;
                int CompanyID = 0;
                int.TryParse(context.Request.Params["CompanyID"], out CompanyID);
                string RoomIDs = context.Request.Params["RoomIDs"];
                List<int> RoomIDList = new List<int>();
                if (!string.IsNullOrEmpty(RoomIDs))
                {
                    RoomIDList = JsonConvert.DeserializeObject<List<int>>(RoomIDs);
                }
                string ProjectIDs = context.Request.Params["ProjectIDs"];
                List<int> ProjectIDList = new List<int>();
                if (RoomIDList.Count == 0)
                {
                    if (!string.IsNullOrEmpty(ProjectIDs))
                    {
                        ProjectIDList = JsonConvert.DeserializeObject<List<int>>(ProjectIDs).Where(p => p != 1).ToList();
                    }
                    ProjectIDList = WebUtil.GetMyProjects(WebUtil.GetUser(context).UserID, ProjectIDList).Where(p => p.ID != 1).Select(p => p.ID).ToList();
                }
                string ChargeIDs = context.Request.Params["ChargeIDs"];
                List<int> ChargeIDList = new List<int>();
                if (!string.IsNullOrEmpty(ChargeIDs))
                {
                    ChargeIDList = JsonConvert.DeserializeObject<List<int>>(ChargeIDs).Where(p => p != 0).ToList();
                }
                DateTime StartTime = GetDateValue(context, "StartTime");
                DateTime EndTime = GetDateValue(context, "EndTime");
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                string ChargeMans = context.Request.Params["ChargeMans"];
                string RoomType = context.Request.Params["RoomType"];
                string NewRoomType = context.Request.Params["NewRoomType"];
                bool IsAnalysisQuery = WebUtil.GetIntValue(context, "IsAnalysisQuery") == 1;
                DataGrid dg = new DataGrid();
                ViewRoomFeeHistory[] ViewRoomFeeHistoryList = null;
                if (RoomType.Equals("Project") && !NewRoomType.Equals("ChargeSummary"))
                {
                    dg = ViewRoomFeeHistory.GetViewRoomFeeHistoryGridByRoomID(RoomIDList, ProjectIDList, StartTime, EndTime, 1, ChargeIDList, "order by DefaultOrder asc", startRowIndex, int.MaxValue, UserID: WebUtil.GetUser(context).UserID);
                    ViewRoomFeeHistoryList = dg.rows as ViewRoomFeeHistory[];
                    List<ViewRoomFeeHistory> FinalViewRoomFeeHistoryList = new List<ViewRoomFeeHistory>();
                    var feelist = RoomFeeAnalysis.GetRoomFeeAnalysisListByRoomID(new List<int>(), ProjectIDList, StartTime, EndTime, ChargeIDList.ToArray(), UserID: WebUtil.GetUser(context).UserID).Where(p => p.TotalCost > 0).ToArray();
                    foreach (var item1 in ViewRoomFeeHistoryList)
                    {
                        item1.id = item1.RoomID.ToString();
                        item1.state = "closed";
                        item1.FinalTotaCost = 0;
                        item1.FinalRestCost = 0;
                        var nowfeelist = feelist.Where(p => !string.IsNullOrEmpty(p.FinalAllParentID) && p.FinalAllParentID.Contains("," + item1.RoomID + ","));
                        item1.FinalRestCost = nowfeelist.Sum(p => p.TotalCost);
                        if (item1.FinalRealCost > 0 || item1.FinalRestCost > 0)
                        {
                            FinalViewRoomFeeHistoryList.Add(item1);
                        }
                    }
                    var finallist = FinalViewRoomFeeHistoryList.Skip((int)startRowIndex).Take(pageSize).ToList();
                    dg.rows = finallist;
                    dg.page = pageSize;
                    dg.total = FinalViewRoomFeeHistoryList.Count;
                }
                else if (RoomType.Equals("Room") && !NewRoomType.Equals("ChargeSummary"))
                {
                    dg = ViewRoomFeeHistory.GetViewRoomFeeHistoryGridByRoomID(RoomIDList, ProjectIDList, StartTime, EndTime, 0, ChargeIDList, "order by DefaultOrder asc", startRowIndex, pageSize, UserID: WebUtil.GetUser(context).UserID);
                    ViewRoomFeeHistoryList = dg.rows as ViewRoomFeeHistory[];
                    List<int> ViewRoomFeeHistoryRoomIDList = new List<int>();
                    List<int> ViewRoomFeeRoomIDList = new List<int>();
                    RoomFeeAnalysis[] feelist = null;
                    int totalcount = 0;
                    List<ViewRoomFeeHistory> FinalViewRoomFeeHistoryList = new List<ViewRoomFeeHistory>();
                    if (ViewRoomFeeHistoryList.Length == pageSize)
                    {
                        FinalViewRoomFeeHistoryList = ViewRoomFeeHistoryList.ToList();
                        var AllViewRoomFeeHistoryList = Foresight.DataAccess.ViewRoomFeeHistory.GetViewRoomFeeHistoryListByRoomID(RoomIDList, ProjectIDList, StartTime, EndTime, 0, UserID: WebUtil.GetUser(context).UserID);
                        ViewRoomFeeHistoryRoomIDList = AllViewRoomFeeHistoryList.Select(p => p.RoomID).ToList();
                        feelist = RoomFeeAnalysis.GetRoomFeeAnalysisListByRoomID(RoomIDList, ProjectIDList, StartTime, EndTime, new int[] { }, UserID: WebUtil.GetUser(context).UserID).Where(p => p.TotalCost > 0).ToArray();
                        foreach (var item in FinalViewRoomFeeHistoryList)
                        {
                            item.FinalRestCost = feelist.Where(p => p.RoomID == item.RoomID).Sum(p => p.TotalCost);
                        }
                        ViewRoomFeeRoomIDList = feelist.Select(p => p.RoomID).Distinct().ToList();
                        ViewRoomFeeRoomIDList = ViewRoomFeeRoomIDList.Where(p => (!ViewRoomFeeHistoryRoomIDList.Contains(p))).ToList();
                        totalcount = AllViewRoomFeeHistoryList.Length + ViewRoomFeeRoomIDList.Count;
                    }
                    else if (ViewRoomFeeHistoryList.Length > 0)
                    {
                        FinalViewRoomFeeHistoryList = ViewRoomFeeHistoryList.ToList();
                        var AllViewRoomFeeHistoryList = Foresight.DataAccess.ViewRoomFeeHistory.GetViewRoomFeeHistoryListByRoomID(RoomIDList, ProjectIDList, StartTime, EndTime, 0, ChargeIDList, UserID: WebUtil.GetUser(context).UserID);
                        ViewRoomFeeHistoryRoomIDList = AllViewRoomFeeHistoryList.Select(p => p.RoomID).Distinct().ToList();
                        feelist = RoomFeeAnalysis.GetRoomFeeAnalysisListByRoomID(RoomIDList, ProjectIDList, StartTime, EndTime, ChargeIDList.ToArray(), UserID: WebUtil.GetUser(context).UserID).Where(p => p.TotalCost > 0).ToArray();
                        foreach (var item in FinalViewRoomFeeHistoryList)
                        {
                            item.FinalRestCost = feelist.Where(p => p.RoomID == item.RoomID).Sum(p => p.TotalCost);
                        }
                        ViewRoomFeeRoomIDList = feelist.Select(p => p.RoomID).Distinct().ToList();
                        ViewRoomFeeRoomIDList = ViewRoomFeeRoomIDList.Where(p => (!ViewRoomFeeHistoryRoomIDList.Contains(p))).ToList();
                        totalcount = AllViewRoomFeeHistoryList.Length + ViewRoomFeeRoomIDList.Count;
                        IEnumerable<IGrouping<int, RoomFeeAnalysis>> queryViewRoomFeeList = feelist.GroupBy(p => p.RoomID);
                        queryViewRoomFeeList = queryViewRoomFeeList.Where(p =>
                        {
                            List<RoomFeeAnalysis> vr = p.ToList<RoomFeeAnalysis>();
                            int RoomID = vr[0].RoomID;
                            return ViewRoomFeeRoomIDList.Contains(RoomID);
                        }).ToArray();
                        if (queryViewRoomFeeList.Count() > 0)
                        {
                            queryViewRoomFeeList = queryViewRoomFeeList.Skip(0).Take((pageSize - ViewRoomFeeHistoryList.Length)).ToArray();
                        }
                        foreach (var item in queryViewRoomFeeList)
                        {
                            List<RoomFeeAnalysis> vr = item.ToList<RoomFeeAnalysis>();
                            ViewRoomFeeHistory viewRoomFeeHistory = new ViewRoomFeeHistory();
                            viewRoomFeeHistory.id = vr[0].RoomID.ToString();
                            viewRoomFeeHistory.state = "closed";
                            viewRoomFeeHistory.FinalFullName = vr[0].FullName;
                            viewRoomFeeHistory.FinalRoomName = vr[0].RoomName;
                            viewRoomFeeHistory.FinalRealCost = 0;
                            viewRoomFeeHistory.FinalRestCost = feelist.Where(p => (p.RoomID == vr[0].RoomID)).Sum(p => p.TotalCost);
                            FinalViewRoomFeeHistoryList.Add(viewRoomFeeHistory);
                        }
                    }
                    else
                    {
                        var AllViewRoomFeeHistoryList = Foresight.DataAccess.ViewRoomFeeHistory.GetViewRoomFeeHistoryListByRoomID(RoomIDList, ProjectIDList, StartTime, EndTime, 0, ChargeIDList, UserID: WebUtil.GetUser(context).UserID);
                        ViewRoomFeeHistoryRoomIDList = AllViewRoomFeeHistoryList.Select(p => p.RoomID).Distinct().ToList();
                        feelist = RoomFeeAnalysis.GetRoomFeeAnalysisListByRoomID(RoomIDList, ProjectIDList, StartTime, EndTime, ChargeIDList.ToArray(), UserID: WebUtil.GetUser(context).UserID).Where(p => p.TotalCost > 0).ToArray();
                        feelist = feelist.Where(p => (!ViewRoomFeeHistoryRoomIDList.Contains(p.RoomID))).ToArray();
                        ViewRoomFeeRoomIDList = feelist.Select(p => p.RoomID).Distinct().ToList();
                        ViewRoomFeeRoomIDList = ViewRoomFeeRoomIDList.Where(p => (!ViewRoomFeeHistoryRoomIDList.Contains(p))).ToList();
                        totalcount = AllViewRoomFeeHistoryList.Length + ViewRoomFeeRoomIDList.Count;

                        IEnumerable<IGrouping<int, RoomFeeAnalysis>> queryViewRoomFeeList = feelist.GroupBy(p => p.RoomID);
                        queryViewRoomFeeList = queryViewRoomFeeList.Where(p =>
                        {
                            List<RoomFeeAnalysis> vr = p.ToList<RoomFeeAnalysis>();
                            int RoomID = vr[0].RoomID;
                            return ViewRoomFeeRoomIDList.Contains(RoomID);
                        }).ToArray();
                        if (queryViewRoomFeeList.Count() > 0)
                        {
                            int start = (int)(startRowIndex - AllViewRoomFeeHistoryList.Length);
                            start = start > 0 ? start : 0;
                            queryViewRoomFeeList = queryViewRoomFeeList.Skip(start).Take(pageSize).ToArray();
                        }
                        foreach (var item in queryViewRoomFeeList)
                        {
                            List<RoomFeeAnalysis> vr = item.ToList<RoomFeeAnalysis>();
                            ViewRoomFeeHistory viewRoomFeeHistory = new ViewRoomFeeHistory();
                            viewRoomFeeHistory.id = vr[0].RoomID.ToString();
                            viewRoomFeeHistory.state = "closed";
                            viewRoomFeeHistory.FinalFullName = vr[0].FullName;
                            viewRoomFeeHistory.FinalRoomName = vr[0].RoomName;
                            viewRoomFeeHistory.FinalRealCost = 0;
                            viewRoomFeeHistory.FinalRestCost = feelist.Where(p => (p.RoomID == vr[0].RoomID)).Sum(p => p.TotalCost);
                            FinalViewRoomFeeHistoryList.Add(viewRoomFeeHistory);
                        }
                    }
                    var finallist = FinalViewRoomFeeHistoryList.Skip((int)startRowIndex).Take(pageSize).ToList();
                    dg.rows = FinalViewRoomFeeHistoryList;
                    dg.page = pageSize;
                    dg.total = totalcount;
                }
                else if (RoomType.Equals("ChargeSummary") || NewRoomType.Equals("ChargeSummary"))
                {
                    int RoomID = WebUtil.GetIntValue(context, "RoomID");
                    if (RoomID > 0)
                    {
                        if (RoomType.Equals("Project"))
                        {
                            ProjectIDList = new List<int> { RoomID };
                        }
                        else if (RoomType.Equals("Room"))
                        {
                            RoomIDList = new List<int> { RoomID };
                        }
                    }
                    dg = ViewRoomFeeHistory.GetViewRoomFeeHistoryGridGroupByChargeSummary(RoomIDList, ProjectIDList, StartTime, EndTime, RoomID, ChargeIDList, "order by [ChargeID] desc", 0, int.MaxValue, UserID: WebUtil.GetUser(context).UserID);
                    ViewRoomFeeHistoryList = dg.rows as ViewRoomFeeHistory[];
                    List<ViewRoomFeeHistory> FinalViewRoomFeeHistoryList = ViewRoomFeeHistoryList.Where(p => p.FinalRealCost > 0).ToList();

                    var ViewRoomFeeHistoryChargeIDList = FinalViewRoomFeeHistoryList.Select(p => p.ChargeID).Distinct().ToList();

                    RoomFeeAnalysis[] feelist = RoomFeeAnalysis.GetRoomFeeAnalysisListByRoomID(RoomIDList, ProjectIDList, StartTime, EndTime, ChargeIDList.ToArray(), UserID: WebUtil.GetUser(context).UserID).Where(p => p.TotalCost > 0).ToArray();
                    var feelistChargeIDList = feelist.Select(p => p.ChargeID).Distinct().ToList();

                    var chargeList = Foresight.DataAccess.ChargeSummary.GetChargeSummaries();
                    foreach (var ID in feelistChargeIDList)
                    {
                        var summary = chargeList.FirstOrDefault(p => p.ID == ID);
                        if (summary == null)
                        {
                            continue;
                        }
                        var feechargelist = feelist.Where(p => p.ChargeID == ID);
                        if (!ViewRoomFeeHistoryChargeIDList.Contains(ID))
                        {
                            ViewRoomFeeHistory viewRoomFeeHistory = new ViewRoomFeeHistory();
                            viewRoomFeeHistory.id = "Charge_" + RoomID + "_" + ID;
                            viewRoomFeeHistory.FinalChargeName = summary.Name;
                            viewRoomFeeHistory.FinalChargeID = ID;
                            viewRoomFeeHistory.FinalTotaCost = feechargelist.Sum(p => p.TotalCost);
                            viewRoomFeeHistory.FinalRealCost = 0;
                            viewRoomFeeHistory.FinalRestCost = feechargelist.Sum(p => p.TotalCost);
                            FinalViewRoomFeeHistoryList.Add(viewRoomFeeHistory);
                        }
                        else
                        {
                            ViewRoomFeeHistory viewRoomFeeHistory = FinalViewRoomFeeHistoryList.FirstOrDefault(p => p.ChargeID == ID);
                            viewRoomFeeHistory.id = "summary_" + RoomID + "_" + ID;
                            viewRoomFeeHistory.FinalChargeName = summary.Name;
                            viewRoomFeeHistory.FinalChargeID = ID;
                            viewRoomFeeHistory.FinalRestCost = feechargelist.Sum(p => p.TotalCost);
                            viewRoomFeeHistory.FinalTotaCost = viewRoomFeeHistory.FinalRestCost + viewRoomFeeHistory.FinalRealCost;
                        }
                    }
                    List<Dictionary<string, object>> diclist = new List<Dictionary<string, object>>();
                    foreach (var item in FinalViewRoomFeeHistoryList)
                    {
                        Dictionary<string, object> dic = new Dictionary<string, object>();
                        dic["id"] = "summary_" + ((RoomID > 0) ? RoomID + "_" : "") + item.FinalChargeID;
                        dic["FinalRoomName"] = "";
                        dic["FinalChargeName"] = item.FinalChargeName;
                        dic["FinalChargeID"] = item.FinalChargeID;
                        dic["FinalRealCost"] = item.FinalRealCost;
                        dic["FinalTotaCost"] = item.FinalTotaCost;
                        dic["FinalRestCost"] = item.FinalRestCost;
                        if (RoomID > 0)
                        {
                            dic["_parentId"] = RoomID.ToString();
                        }
                        diclist.Add(dic);
                    }
                    var finallist = diclist;
                    if (RoomID <= 0)
                    {
                        finallist = diclist.Skip((int)startRowIndex).Take(pageSize).ToList();
                    }
                    dg.rows = finallist;
                    dg.page = pageSize;
                    dg.total = diclist.Count;
                }
                string result = JsonConvert.SerializeObject(dg);
                context.Response.Write(result);
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("FeeCenterHandler", "visit: getshoufeilv", ex);
                context.Response.Write("{\"rows\":[],\"total\":0,\"page\":0}");
            }
        }
        private void CalculateQianFeiTime(string TimeRange, out DateTime StartTime, out DateTime EndTime)
        {
            StartTime = DateTime.MinValue;
            EndTime = DateTime.MinValue;
            switch (TimeRange)
            {
                case "1":
                    {
                        StartTime = DateTime.MinValue;
                        EndTime = DateTime.Now;
                    }
                    break;
                case "2":
                    {
                        StartTime = DateTime.Today.AddDays(1 - DateTime.Today.Day);
                        EndTime = StartTime.AddMonths(1);
                    }
                    break;
                case "3":
                    {
                        StartTime = DateTime.Parse(DateTime.Now.ToString("yyyy-01-01"));
                        EndTime = StartTime.AddMonths(12);
                    }
                    break;
                case "4":
                    {
                        StartTime = DateTime.MinValue;
                        EndTime = DateTime.MinValue;
                    }
                    break;
                default:
                    break;
            }
        }
        private void loadqfkbsummary(HttpContext context)
        {
            string TimeRange = context.Request.Params["TimeRange"];
            DateTime StartTime = GetDateValue(context, "StartTime");
            DateTime EndTime = GetDateValue(context, "EndTime");
            string ChargeSummarys = context.Request.Params["ChargeSummaryIDList"];
            List<int> ChargeSummaryIDList = new List<int>();
            if (!string.IsNullOrEmpty(ChargeSummarys) && !ChargeSummarys.Equals("[\"\"]"))
            {
                ChargeSummaryIDList = JsonConvert.DeserializeObject<List<int>>(ChargeSummarys);
                if (ChargeSummaryIDList.Contains(0))
                {
                    ChargeSummaryIDList = new List<int>();
                }
            }
            string RoomIDs = context.Request.Params["RoomIDs"];
            List<int> RoomIDList = new List<int>();
            if (!string.IsNullOrEmpty(RoomIDs))
            {
                RoomIDList = JsonConvert.DeserializeObject<List<int>>(RoomIDs);
            }
            string ProjectIDs = context.Request.Params["ProjectIDs"];
            List<int> ProjectIDList = new List<int>();
            if (RoomIDList.Count == 0)
            {
                if (!string.IsNullOrEmpty(ProjectIDs))
                {
                    ProjectIDList = JsonConvert.DeserializeObject<List<int>>(ProjectIDs).Where(p => p != 1).ToList();
                }
                ProjectIDList = WebUtil.GetMyProjects(WebUtil.GetUser(context).UserID, ProjectIDList).Where(p => p.ID != 1).Select(p => p.ID).ToList();
            }
            if (StartTime == DateTime.MinValue && EndTime == DateTime.MinValue)
            {
                CalculateQianFeiTime(TimeRange, out StartTime, out EndTime);
            }
            string Title = string.Empty;
            AnalysisTimeHelper.GetQK(WebUtil.GetUser(context).UserID, out StartTime, out EndTime, out Title);
            int CompanyID = GetIntValue(context, "CompanyID");
            ChargeSummaryDetails[] summarylist = ChargeSummaryDetails.GetChargeSummaryByCompanyID(CompanyID, ChargeSummaryIDList.ToArray());

            var feelist = RoomFeeAnalysis.GetRoomFeeAnalysisListByRoomID(RoomIDList, ProjectIDList, StartTime, EndTime, ChargeSummaryIDList.ToArray(), IsContractFee: true, UserID: WebUtil.GetUser(context).UserID);
            foreach (var summary in summarylist)
            {
                summary.RealCost = 0;
                foreach (var fee in feelist)
                {
                    if (summary.ID == fee.ChargeID)
                    {
                        summary.RealCost += fee.TotalCost > 0 ? fee.TotalCost : 0;
                    }
                }
            }
            summarylist = summarylist.Where(p => p.RealCost > 0).ToArray();
            var items = new { QianFeiSummaryList = summarylist, Title = Title };
            string results = JsonConvert.SerializeObject(items);
            context.Response.Write(results);
        }
        private void loadsummarysearchparams(HttpContext context)
        {
            var summarylist = ChargeSummary.GetChargeSummaries();
            var typelist = ChargeMoneyType.GetChargeMoneyTypes();
            var items = new { SummaryList = summarylist, TypeList = typelist };
            string results = JsonConvert.SerializeObject(items);
            context.Response.Write(results);
        }
        private void CalculateShouFeiTime(string TimeRange, out DateTime StartTime, out DateTime EndTime)
        {
            StartTime = DateTime.MinValue;
            EndTime = DateTime.MinValue;
            switch (TimeRange)
            {
                case "1":
                    {
                        StartTime = DateTime.Today;
                        EndTime = DateTime.Today;
                    }
                    break;
                case "2":
                    {
                        StartTime = DateTime.Today.AddDays(-1);
                        EndTime = DateTime.Today.AddDays(-1);
                    }
                    break;
                case "3":
                    {
                        StartTime = DateTime.Today.AddDays(1 - Convert.ToInt32(DateTime.Today.DayOfWeek.ToString("d")));
                        EndTime = StartTime.AddDays(7);
                    }
                    break;
                case "4":
                    {
                        StartTime = DateTime.Today.AddDays(1 - DateTime.Today.Day);
                        EndTime = StartTime.AddMonths(1).AddDays(-1);
                    }
                    break;
                case "5":
                    {
                        StartTime = DateTime.Today.AddMonths(0 - ((DateTime.Today.Month - 1) % 3)).AddDays(1 - DateTime.Today.Day);
                        EndTime = StartTime.AddMonths(3).AddDays(-1);
                    }
                    break;
                case "6":
                    {
                        StartTime = DateTime.Parse(DateTime.Now.ToString("yyyy-01-01"));
                        EndTime = DateTime.Parse(DateTime.Now.ToString("yyyy-12-31"));
                    }
                    break;
                default:
                    break;
            }
        }
        private void loadskkbsummary(HttpContext context)
        {
            string TimeRange = context.Request.Params["TimeRange"];
            DateTime StartTime = GetDateValue(context, "StartTime");
            DateTime EndTime = GetDateValue(context, "EndTime");
            string ChargeTypeIDs = context.Request.Params["ChargeTypeIDList"];
            List<int> ChargeTypeIDList = new List<int>();
            if (!string.IsNullOrEmpty(ChargeTypeIDs) && !ChargeTypeIDs.Equals("[\"\"]"))
            {
                ChargeTypeIDList = JsonConvert.DeserializeObject<List<int>>(ChargeTypeIDs);
                if (ChargeTypeIDList.Contains(-1))
                {
                    ChargeTypeIDList = new List<int>();
                }
            }
            string ChargeSummarys = context.Request.Params["ChargeSummaryIDList"];
            List<int> ChargeSummaryIDList = new List<int>();
            if (!string.IsNullOrEmpty(ChargeSummarys) && !ChargeSummarys.Equals("[\"\"]"))
            {
                ChargeSummaryIDList = JsonConvert.DeserializeObject<List<int>>(ChargeSummarys);
                if (ChargeSummaryIDList.Contains(0))
                {
                    ChargeSummaryIDList = new List<int>();
                }
            }
            string RoomIDs = context.Request.Params["RoomIDs"];
            List<int> RoomIDList = new List<int>();
            if (!string.IsNullOrEmpty(RoomIDs))
            {
                RoomIDList = JsonConvert.DeserializeObject<List<int>>(RoomIDs);
            }
            string ProjectIDs = context.Request.Params["ProjectIDs"];
            List<int> ProjectIDList = new List<int>();
            if (RoomIDList.Count == 0)
            {
                if (!string.IsNullOrEmpty(ProjectIDs))
                {
                    ProjectIDList = JsonConvert.DeserializeObject<List<int>>(ProjectIDs).Where(p => p != 1).ToList();
                }
                ProjectIDList = WebUtil.GetMyProjects(WebUtil.GetUser(context).UserID, ProjectIDList).Where(p => p.ID != 1).Select(p => p.ID).ToList();
            }
            if (StartTime == DateTime.MinValue && EndTime == DateTime.MinValue)
            {
                CalculateShouFeiTime(TimeRange, out StartTime, out EndTime);
            }
            string Title1 = string.Empty;
            AnalysisTimeHelper.GetSK(WebUtil.GetUser(context).UserID, out StartTime, out EndTime, out Title1);
            List<int> ChargeStateList = new List<int>();
            ChargeStateList.Add(1);
            //ChargeStateList.Add(4);
            var ShouKuanSummaryList = Foresight.DataAccess.ChargeSummaryDetails.GetHistorySummaryGroupByChargeName(RoomIDList, ProjectIDList, StartTime, EndTime, ChargeSummaryIDList, ChargeTypeIDList, ChargeStateList, UserID: WebUtil.GetUser(context).UserID).Where(p => p.RealCost > 0).OrderByDescending(p => p.RealCost);
            var ShouKuanTypeList = ChargeMoneyTypeDetails.GetHistorySummaryGroupByTypeName(RoomIDList, ProjectIDList, StartTime, EndTime, ChargeSummaryIDList, ChargeTypeIDList, ChargeStateList, UserID: WebUtil.GetUser(context).UserID).Where(p => p.RealCost > 0).OrderByDescending(p => p.RealCost);
            var items = new { ShouKuanSummaryList = ShouKuanSummaryList, ShouKuanTypeList = ShouKuanTypeList, Title = Title1 };
            string results = JsonConvert.SerializeObject(items);
            context.Response.Write(results);
        }
        private void loadanalysissummary(HttpContext context)
        {
            int UserID = WebUtil.GetUser(context).UserID;
            string RoomIDs = context.Request.Params["RoomIDs"];
            List<int> RoomIDList = new List<int>();
            if (!string.IsNullOrEmpty(RoomIDs))
            {
                RoomIDList = JsonConvert.DeserializeObject<List<int>>(RoomIDs);
            }
            string ProjectIDs = context.Request.Params["ProjectIDs"];
            List<int> ProjectIDList = new List<int>();
            if (RoomIDList.Count == 0)
            {
                if (!string.IsNullOrEmpty(ProjectIDs))
                {
                    ProjectIDList = JsonConvert.DeserializeObject<List<int>>(ProjectIDs).Where(p => p != 1).ToList();
                }
                ProjectIDList = WebUtil.GetMyProjects(WebUtil.GetUser(context).UserID, ProjectIDList).Where(p => p.ID != 1).Select(p => p.ID).ToList();
            }
            //if (RoomIDList.Count == 0 && ProjectIDList.Count == 0)
            //{
            //    WebUtil.WriteJson(context, new { status = false, error = "请选择资源" });
            //    return;
            //}
            DateTime start = DateTime.Today;
            DateTime end = DateTime.Today.AddDays(1);
            string Title1 = string.Empty;
            AnalysisTimeHelper.GetSK(UserID, out start, out end, out Title1);
            decimal todayFee = Foresight.DataAccess.PrintRoomFeeHistory.GetSumCostByTime(start, end, ProjectIDList, RoomIDList, UserID: WebUtil.GetUser(context).UserID);

            var fee_list = Foresight.DataAccess.RoomFeeAnalysis.GetRoomFeeAnalysisListByTime(DateTime.MinValue, DateTime.MinValue, ProjectIDList, RoomIDList, UserID: WebUtil.GetUser(context).UserID);

            string Title2 = string.Empty;
            AnalysisTimeHelper.GetQK(UserID, out start, out end, out Title2);
            var fee_list1 = RoomFeeAnalysis.GetFinalRoomFeeAnalysisList(fee_list, start, end);
            decimal totalOwnFee = fee_list1.Sum(p => p.TotalCost);

            string Title3 = string.Empty;
            AnalysisTimeHelper.GetSFL(UserID, out start, out end, out Title3);
            decimal thisMonthFee = Foresight.DataAccess.PrintRoomFeeHistory.GetSumCostByTime(start, end, ProjectIDList, RoomIDList, UserID: WebUtil.GetUser(context).UserID);
            var fee_list2 = RoomFeeAnalysis.GetFinalRoomFeeAnalysisList(fee_list, start, end);
            decimal thisMonthOwnFee = fee_list2.Sum(p => p.TotalCost);
            decimal shouFeiPercent = Math.Round((decimal)(thisMonthFee / ((thisMonthFee + thisMonthOwnFee) > 0 ? (thisMonthFee + thisMonthOwnFee) : 1)) * 100, 2, MidpointRounding.AwayFromZero);

            string Title4 = "支出金额";
            AnalysisTimeHelper.GetZCKB(UserID, out start, out end, out Title4);
            //bool isgugou = AnalysisTimeHelper.GetQFHS(UserID, out start, out end, out Title4);
            //int OwnCount = 0;
            //if (!isgugou)
            //{
            //    qianFeiList = Foresight.DataAccess.ViewRoomFeeDetail.GetViewRoomFeeDetailListByTime(start, end, ProjectIDList, RoomIDList);
            //}
            //OwnCount = qianFeiList.Where(p => p.Cost > 0).GroupBy(p => p.RoomID).ToList().Count;
            List<int> EqualProjectIDList = new List<int>();
            List<int> InProjectIDList = new List<int>();
            if (RoomIDList.Count == 0)
            {
                List<int> MyProjectIDList = new List<int>();
                if (!string.IsNullOrEmpty(ProjectIDs))
                {
                    MyProjectIDList = JsonConvert.DeserializeObject<List<int>>(ProjectIDs).Where(p => p != 1).ToList();
                }
                Web.APPCode.CacheHelper.GetMyProjectListByUserID(WebUtil.GetUser(context).UserID, out EqualProjectIDList, out InProjectIDList, ProjectIDList: MyProjectIDList);
                if (MyProjectIDList.Count == 0)
                {
                    if (EqualProjectIDList.Count > 0)
                    {
                        EqualProjectIDList.Add(0);
                    }
                }
                else
                {
                    string ALLProjectIDs = context.Request.Params["ALLProjectIDs"];
                    List<int> ALLProjectIDList = new List<int>();
                    if (!string.IsNullOrEmpty(ALLProjectIDs))
                    {
                        ALLProjectIDList = JsonConvert.DeserializeObject<List<int>>(ALLProjectIDs).Where(p => p != 1).ToList();
                    }
                    if (ALLProjectIDList.Count > 0)
                    {
                        EqualProjectIDList = ALLProjectIDList;
                    }
                }
            }
            var payserviceList = Foresight.DataAccess.PayService.GetPayServiceList(RoomIDList, start, end, UserID: WebUtil.GetUser(context).UserID, EqualProjectIDList: EqualProjectIDList, InProjectIDList: InProjectIDList);
            decimal OwnCount = payserviceList.Sum(p => p.PayMoney);
            var items = new { status = true, todayFee = Math.Round(todayFee, 2), totalOwnFee = Math.Round((decimal)totalOwnFee, 2, MidpointRounding.AwayFromZero), shouFeiPercent = shouFeiPercent, OwnCount = OwnCount, Title1 = Title1, Title2 = Title2, Title3 = Title3, Title4 = Title4 };
            WebUtil.WriteJson(context, items);
        }
        private void cancelfeeorder(HttpContext context)
        {
            string IDs = context.Request.Params["IDList"];
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(IDs);
            var orderList = Foresight.DataAccess.RoomFeeOrder.GetRoomFeeOrderList(IDList);
            var approveList = orderList.Where(p => p.ApproveStatus == 1).ToList();
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    string cmdtext = "update [RoomFeeOrder] set [ApproveStatus]=3 where ID in (" + string.Join(",", IDList.ToArray()) + ");";
                    cmdtext += "update [PrintRoomFeeHistory] set [RoomFeeOrderID]=NULL where [RoomFeeOrderID] in (" + string.Join(",", IDList.ToArray()) + ")";
                    helper.Execute(cmdtext, CommandType.Text, new List<System.Data.SqlClient.SqlParameter>());
                    helper.Commit();
                    context.Response.Write("{\"status\":true}");
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError("AnalysisHandler", "visit: cancelfeeorder", ex);
                    context.Response.Write("{\"status\":false}");
                }
            }
        }
        private void deleteorder(HttpContext context)
        {
            string IDs = context.Request.Params["IDList"];
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(IDs);
            var orderList = Foresight.DataAccess.RoomFeeOrder.GetRoomFeeOrderList(IDList);
            var approveList = orderList.Where(p => p.ApproveStatus == 1).ToList();
            if (approveList.Count > 0)
            {
                context.Response.Write("{\"status\":true,\"approved\":true}");
                return;
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    string cmdtext = "delete from [RoomFeeOrder] where ID in (" + string.Join(",", IDList.ToArray()) + ");";
                    cmdtext += "update [PrintRoomFeeHistory] set [RoomFeeOrderID]=NULL where [RoomFeeOrderID] in (" + string.Join(",", IDList.ToArray()) + ")";
                    helper.Execute(cmdtext, CommandType.Text, new List<System.Data.SqlClient.SqlParameter>());
                    helper.Commit();
                    context.Response.Write("{\"status\":true}");
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError("AnalysisHandler", "visit: deleteorder", ex);
                    context.Response.Write("{\"status\":false}");
                }
            }
        }
        private void saveorderapprove(HttpContext context)
        {
            DateTime ApproveTime = GetDateValue(context, "ApproveTime");
            string ApproveMan = context.Request.Params["ApproveMan"];
            int ApproveUserID = GetIntValue(context, "ApproveUserID");
            int ApproveStatus = GetIntValue(context, "ApproveStatus");
            string ApproveRemark = context.Request.Params["ApproveRemark"];
            int RoomFeeOrderID = GetIntValue(context, "RoomFeeOrderID");
            var rooFeeOrder = Foresight.DataAccess.RoomFeeOrder.GetRoomFeeOrder(RoomFeeOrderID);
            rooFeeOrder.ApproveTime = ApproveTime;
            rooFeeOrder.ApproveMan = ApproveMan;
            rooFeeOrder.ApproveManUserID = ApproveUserID;
            rooFeeOrder.ApproveStatus = ApproveStatus;
            rooFeeOrder.ApproveRemark = ApproveRemark;
            rooFeeOrder.Save();
            context.Response.Write("{\"status\":true}");
        }
        private void loadchargefeeorderlist(HttpContext context)
        {
            DateTime StartTime = GetDateValue(context, "StartTime");
            DateTime EndTime = GetDateValue(context, "EndTime");
            string AddMans = context.Request.Params["AddMans"];
            int ApproveStatus = GetIntValue(context, "ApproveStatus");
            string ApproveMans = context.Request.Params["ApproveMans"];
            List<int> AddManList = new List<int>();
            if (!string.IsNullOrEmpty(AddMans) && !AddMans.Equals("[\"\"]"))
            {
                AddManList = JsonConvert.DeserializeObject<List<int>>(AddMans);
            }
            List<int> ApproveStatusList = new List<int>();
            if (ApproveStatus > 0)
            {
                ApproveStatusList.Add(ApproveStatus);
            }
            List<int> ApproveManList = new List<int>();
            if (!string.IsNullOrEmpty(ApproveMans) && !ApproveMans.Equals("[\"\"]"))
            {
                ApproveManList = JsonConvert.DeserializeObject<List<int>>(ApproveMans);
            }
            string page = context.Request.Form["page"];
            string rows = context.Request.Form["rows"];
            long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
            int pageSize = int.Parse(rows);
            try
            {
                var dg = Foresight.DataAccess.RoomFeeOrder.GeRoomFeeOrderGridByKeywords(StartTime, EndTime, AddManList, ApproveManList, ApproveStatusList, "order by [OrderTime] desc", startRowIndex, pageSize);
                string result = JsonConvert.SerializeObject(dg);
                context.Response.Write(result);
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("AnalysisHandler", "visit: loadchargefeeorderlist", ex);
                context.Response.Write("{\"rows\":[],\"total\":0,\"page\":0}");
            }
        }
        private void saveorder(HttpContext context)
        {
            DateTime StartTime = GetDateValue(context, "StartTime");
            DateTime EndTime = GetDateValue(context, "EndTime");
            string ChargeMan = context.Request.Params["ChargeMan"];
            string AddMan = context.Request.Params["AddMan"];
            int AddManID = GetIntValue(context, "AddManID");
            DateTime OrderTime = GetDateValue(context, "OrderTime");
            string ProjectIDs = context.Request["ProjectIDList"];
            List<int> ProjectIDList = new List<int>();
            if (!string.IsNullOrEmpty(ProjectIDs))
            {
                ProjectIDList = JsonConvert.DeserializeObject<List<int>>(ProjectIDs);
            }
            string RoomIDs = context.Request["RoomIDList"];
            List<int> RoomIDList = new List<int>();
            if (!string.IsNullOrEmpty(RoomIDs))
            {
                RoomIDList = JsonConvert.DeserializeObject<List<int>>(RoomIDs);
            }
            if (ProjectIDList.Count == 0 && RoomIDList.Count == 0)
            {
                WebUtil.WriteJson(context, new { status = false, msg = "RoomIDs" });
                return;
            }
            List<int> HistoryIDList = JsonConvert.DeserializeObject<List<int>>(context.Request["HistoryIDs"]);

            //List<int> ChargeState = new List<int>();
            //ChargeState.Add(1);
            //ChargeState.Add(4);
            //decimal ShouTotalRealCost = Foresight.DataAccess.PrintRoomFeeHistory.GetSumCostByChargeState(StartTime, EndTime, ChargeMan, ChargeState, ProjectIDList, int.MinValue);
            //ChargeState = new List<int>();
            //ChargeState.Add(3);
            //decimal FuTotalRealCost = Foresight.DataAccess.PrintRoomFeeHistory.GetSumCostByChargeState(StartTime, EndTime, ChargeMan, ChargeState, ProjectIDList, int.MinValue);
            var roomFeeOrder = new Foresight.DataAccess.RoomFeeOrder();
            int OrderNumberID = 0;
            foreach (var RoomID in RoomIDList)
            {
                if (OrderNumberID > 0)
                {
                    break;
                }
                roomFeeOrder.OrderNumber = Foresight.DataAccess.RoomFeeOrder.GetLastestRoomFeeOrderNumber(Foresight.DataAccess.OrderTypeNameDefine.roomfeeorder.ToString(), RoomID, out OrderNumberID);
            }
            foreach (var ProjectID in ProjectIDList)
            {
                if (OrderNumberID > 0)
                {
                    break;
                }
                roomFeeOrder.OrderNumber = Foresight.DataAccess.RoomFeeOrder.GetLastestRoomFeeOrderNumber(Foresight.DataAccess.OrderTypeNameDefine.roomfeeorder.ToString(), ProjectID, out OrderNumberID);
            }

            roomFeeOrder.OrderNumberID = OrderNumberID;
            roomFeeOrder.ProjectID = string.Join(",", ProjectIDList.ToArray());
            roomFeeOrder.OrderUserMan = AddMan;
            roomFeeOrder.OrderUserID = AddManID;
            roomFeeOrder.OrderTime = OrderTime;
            roomFeeOrder.Operator = ChargeMan;
            roomFeeOrder.ApproveStatus = 0;
            roomFeeOrder.ChargeStartTime = StartTime;
            roomFeeOrder.ChargeEndTime = EndTime;
            roomFeeOrder.AddTime = DateTime.Now;
            roomFeeOrder.TotalCount = GetIntValue(context, "TotalCount");
            roomFeeOrder.TotalPayBackCount = GetIntValue(context, "TotalPayBackCount");
            roomFeeOrder.TotalPayCount = GetIntValue(context, "TotalPayCount");
            roomFeeOrder.TotalCancelCount = GetIntValue(context, "TotalCancelCount");
            roomFeeOrder.StartShouOrderNumber = context.Request.Params["StartShouOrderNumber"];
            roomFeeOrder.EndShouOrderNumber = context.Request.Params["EndShouOrderNumber"];
            roomFeeOrder.StartFuOrderNumber = context.Request.Params["StartFuOrderNumber"];
            roomFeeOrder.EndFuOrderNumber = context.Request.Params["EndFuOrderNumber"];
            roomFeeOrder.ShouTotalCost = GetDecimalValue(context, "ShouTotalCost");
            roomFeeOrder.FuTotalCost = GetDecimalValue(context, "FuTotalCost");
            roomFeeOrder.WeiShuTotalCost = GetDecimalValue(context, "WeiShuTotalCost");
            roomFeeOrder.OrderCost = (roomFeeOrder.ShouTotalCost - roomFeeOrder.FuTotalCost);

            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    roomFeeOrder.Save(helper);
                    Foresight.DataAccess.PrintRoomFeeHistory.UpdateRoomFeeOrderNumber(roomFeeOrder.ID, helper, HistoryIDList, UserID: WebUtil.GetUser(context).UserID);
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError("AnalysisHandler", "visit: saveorder", ex);
                    WebUtil.WriteJson(context, new { status = false, error = ex.Message });
                    return;
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void searchorder(HttpContext context)
        {
            DateTime StartTime = GetDateValue(context, "StartTime");
            DateTime EndTime = GetDateValue(context, "EndTime");
            string ChargeMan = context.Request.Params["Operator"];
            string ProjectIDs = context.Request.Params["ProjectIDList"];
            List<int> ProjectIDList = new List<int>();
            if (!string.IsNullOrEmpty(ProjectIDs))
            {
                ProjectIDList = JsonConvert.DeserializeObject<List<int>>(ProjectIDs);
            }
            Foresight.DataAccess.RoomFeeOrder roomFeeOrder = null;
            int RoomFeeOrderID = GetIntValue(context, "RoomFeeOrderID");
            if (RoomFeeOrderID > 0)
            {
                roomFeeOrder = RoomFeeOrder.GetRoomFeeOrder(RoomFeeOrderID);
            }
            List<int> ChargeState = new List<int>();
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
            if (roomFeeOrder != null)
            {
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
            }
            else
            {
                ChargeState = new List<int>();
                ChargeState = new int[] { 1, 2, 3, 4, 6, 7 }.ToList();
                TotalALLCount = Foresight.DataAccess.PrintRoomFeeHistory.GetCountByChargeState(StartTime, EndTime, ChargeMan, ChargeState, ProjectIDList, RoomFeeOrderID, true, UserID: WebUtil.GetUser(context).UserID);
                ChargeState = new List<int>();
                ChargeState = new int[] { 1, 4 }.ToList();
                TotalChargeCount = Foresight.DataAccess.PrintRoomFeeHistory.GetCountByChargeState(StartTime, EndTime, ChargeMan, ChargeState, ProjectIDList, RoomFeeOrderID, true, UserID: WebUtil.GetUser(context).UserID);
                ChargeState = new List<int>();
                ChargeState = new int[] { 2 }.ToList();
                TotalChargeCancelCount = Foresight.DataAccess.PrintRoomFeeHistory.GetCountByChargeState(StartTime, EndTime, ChargeMan, ChargeState, ProjectIDList, RoomFeeOrderID, true, UserID: WebUtil.GetUser(context).UserID);
                ChargeState = new List<int>();
                ChargeState = new int[] { 3, 6, 7 }.ToList();
                TotalChargeBackCount = Foresight.DataAccess.PrintRoomFeeHistory.GetCountByChargeState(StartTime, EndTime, ChargeMan, ChargeState, ProjectIDList, RoomFeeOrderID, true, UserID: WebUtil.GetUser(context).UserID);
                var historylist = Foresight.DataAccess.ViewRoomFeeHistory.GetViewRoomFeeHistoryListForOrder(StartTime, EndTime, ChargeMan, new List<int>(), ProjectIDList, RoomFeeOrderID, true, UserID: WebUtil.GetUser(context).UserID);
                ChargeState = new List<int>();
                ChargeState = new int[] { 1, 4 }.ToList();
                ShouTotalRealCost = Foresight.DataAccess.PrintRoomFeeHistory.GetSumCostByChargeState(StartTime, EndTime, ChargeMan, ChargeState, ProjectIDList, RoomFeeOrderID, true, UserID: WebUtil.GetUser(context).UserID);
                var ShouPrintNumberList = historylist.Where(p => !string.IsNullOrEmpty(p.PrintNumber) && (p.ChargeState == 1 || p.ChargeState == 4)).OrderBy(q => q.PrintNumber).ToList();
                if (ShouPrintNumberList.Count > 0)
                {
                    ShouKuanStartNumber = ShouPrintNumberList[0].PrintNumber;
                    ShouKuanEndNumber = ShouPrintNumberList[ShouPrintNumberList.Count - 1].PrintNumber;
                }
                ChargeState = new List<int>();
                ChargeState = new int[] { 3, 6, 7 }.ToList();
                FuTotalRealCost = Foresight.DataAccess.PrintRoomFeeHistory.GetSumCostByChargeState(StartTime, EndTime, ChargeMan, ChargeState, ProjectIDList, RoomFeeOrderID, true, UserID: WebUtil.GetUser(context).UserID);
                var FuPrintNumberList = historylist.Where(p => !string.IsNullOrEmpty(p.PrintNumber) && p.ChargeState == 3).OrderBy(q => q.PrintNumber).ToList();
                if (FuPrintNumberList.Count > 0)
                {
                    FuKuanStartNumber = FuPrintNumberList[0].PrintNumber;
                    FuKuanEndNumber = FuPrintNumberList[FuPrintNumberList.Count - 1].PrintNumber;
                }
                ChargeState = new List<int>();
                ChargeState = new int[] { 1, 4 }.ToList();
                WeiShuTotalCost = Foresight.DataAccess.PrintRoomFeeHistory.GetSumWeiShuByChargeState(DateTime.MinValue, DateTime.MinValue, string.Empty, ChargeState, new List<int>(), new List<int>(), RoomFeeOrderID, true, new List<int>(), UserID: WebUtil.GetUser(context).UserID);
            }
            var ShouTypeSummaryList = new List<ChargeMoneyTypeDetails>();
            var ShouChargeSummaryList = new List<ChargeSummaryDetails>();
            var FuChargeSummaryList = new List<ChargeSummaryDetails>();
            var FuTypeSummaryList = new List<ChargeMoneyTypeDetails>();
            DataGrid dg = ChargeMoneyTypeDetails.GetHistorySummaryGroupByTypeName(new List<int>(), ProjectIDList, StartTime, EndTime, ChargeMan, int.MinValue, int.MinValue, RoomFeeOrderID, true, UserID: WebUtil.GetUser(context).UserID);
            ChargeMoneyTypeDetails[] list = dg.rows as ChargeMoneyTypeDetails[];
            ShouTypeSummaryList = list.Where(p => p.RealCost > 0).ToList();

            ChargeState = new List<int>();
            ChargeState = new int[] { 1, 4 }.ToList();
            dg = ChargeSummaryDetails.GetHistorySummaryGroupByChargeName(new List<int>(), ProjectIDList, StartTime, EndTime, 1, ChargeMan, int.MinValue, int.MinValue, RoomFeeOrderID, ChargeState, true, UserID: WebUtil.GetUser(context).UserID);
            ChargeSummaryDetails[] list2 = dg.rows as ChargeSummaryDetails[];
            ShouChargeSummaryList = list2.Where(p => p.RealCost > 0).ToList();

            ChargeState = new List<int>();
            ChargeState = new int[] { 3, 6, 7 }.ToList();
            dg = ChargeSummaryDetails.GetHistorySummaryGroupByChargeName(new List<int>(), ProjectIDList, StartTime, EndTime, 1, ChargeMan, int.MinValue, int.MinValue, RoomFeeOrderID, ChargeState, true, UserID: WebUtil.GetUser(context).UserID);
            ChargeSummaryDetails[] list3 = dg.rows as ChargeSummaryDetails[];
            FuChargeSummaryList = list3.Where(p => p.RealCost > 0).ToList();

            dg = ChargeMoneyTypeDetails.GetDepositSummaryGroupByTypeName(new List<int>(), ProjectIDList, StartTime, EndTime, 1, ChargeMan, RoomFeeOrderID, true, UserID: WebUtil.GetUser(context).UserID);
            ChargeMoneyTypeDetails[] list4 = dg.rows as ChargeMoneyTypeDetails[];
            FuTypeSummaryList = list4.Where(p => p.RealCost > 0).ToList();

            int totalCount1 = Math.Max(ShouTypeSummaryList.Count, ShouChargeSummaryList.Count);
            int totalCount2 = Math.Max(FuTypeSummaryList.Count, FuChargeSummaryList.Count);
            int totalCount = Math.Max(totalCount1, totalCount2);
            var items = new
            {
                status = true,
                summary = new
                {
                    TotalALLCount = TotalALLCount,
                    TotalChargeCount = TotalChargeCount,
                    TotalChargeCancelCount = TotalChargeCancelCount,
                    TotalChargeBackCount = TotalChargeBackCount,
                    ShouKuanStartNumber = ShouKuanStartNumber,
                    ShouKuanEndNumber = ShouKuanEndNumber,
                    FuKuanStartNumber = FuKuanStartNumber,
                    FuKuanEndNumber = FuKuanEndNumber,
                    ShouTotalRealCost = ShouTotalRealCost,
                    FuTotalRealCost = FuTotalRealCost,
                    WeiShuTotalCost = WeiShuTotalCost
                },
                ShouTypeSummaryList = ShouTypeSummaryList,
                ShouChargeSummaryList = ShouChargeSummaryList,
                FuChargeSummaryList = FuChargeSummaryList,
                FuTypeSummaryList = FuTypeSummaryList,
                totalCount = totalCount
            };
            var result = JsonConvert.SerializeObject(items);
            context.Response.Write(result);
        }
        private void loadcreateorderparams(HttpContext context)
        {
            var userlist = Foresight.DataAccess.User.GetSysUserList();
            var dic = new Dictionary<string, object>();
            var userList = userlist.Select(p =>
            {
                dic = new Dictionary<string, object>();
                dic["UserID"] = p.UserID;
                dic["RealName"] = p.FinalRealName;
                return dic;
            }).ToList();
            var list = Foresight.DataAccess.ChargeMoneyType.GetChargeMoneyTypes();
            var items = list.Select(p =>
            {
                dic = new Dictionary<string, object>();
                dic["ID"] = p.ChargeTypeID;
                dic["Name"] = p.ChargeTypeName;
                return dic;
            }).ToList();
            WebUtil.WriteJson(context, new { status = true, ChargeTypeList = items, UList = userList });
        }

        private void LoadTotalCostSummaryByChargename(HttpContext context)
        {
            try
            {
                int CompanyID = 0;
                int.TryParse(context.Request.Params["CompanyID"], out CompanyID);
                string RoomID = context.Request.Params["RoomID"];
                List<int> RoomIDList = new List<int>();
                if (!string.IsNullOrEmpty(RoomID))
                {
                    RoomIDList = JsonConvert.DeserializeObject<List<int>>(RoomID);
                }
                if (RoomIDList.Count == 0)
                {
                    string ProjectID = context.Request.Params["ProjectID"];
                    List<int> ProjectIDList = JsonConvert.DeserializeObject<List<int>>(ProjectID);
                    if (ProjectIDList.Count > 0)
                    {
                        var projectlist = Project.GetAllRoomChild(ProjectIDList);
                        RoomIDList = projectlist.Select(p => p.ID).ToList();
                    }
                }
                DateTime StartTime = DateTime.MinValue;
                DateTime.TryParse(context.Request.Params["StartChargeTime"], out StartTime);
                DateTime EndTime = DateTime.MinValue;
                DateTime.TryParse(context.Request.Params["EndChargeTime"], out EndTime);
                DataGrid dg = ChargeSummaryDetails.GetTotalCostSummaryGroupByChargeName(RoomIDList, StartTime, EndTime, CompanyID);
                ChargeSummaryDetails[] list = dg.rows as ChargeSummaryDetails[];
                list = list.Where(p => p.Cost > 0 || p.RealCost > 0 || p.Discount > 0 || p.OwnCost > 0).ToArray();
                List<ChargeSummaryDetails> newlist = list.ToList();
                if (newlist.Count > 0)
                {
                    decimal totalRealCost = 0;
                    decimal totalCost = 0;
                    decimal totalDisCount = 0;
                    decimal totalOwnCost = 0;
                    foreach (var item in list)
                    {
                        totalRealCost += item.RealCost > 0 ? item.RealCost : 0;
                        totalCost += item.Cost > 0 ? item.Cost : 0;
                        totalDisCount += item.Discount > 0 ? item.Discount : 0;
                        totalOwnCost += item.OwnCost > 0 ? item.OwnCost : 0;
                    }
                    var chargeSummaryDetails = new ChargeSummaryDetails();
                    chargeSummaryDetails.Name = "合计";
                    chargeSummaryDetails.RealCost = totalRealCost;
                    chargeSummaryDetails.Cost = totalCost;
                    chargeSummaryDetails.Discount = totalDisCount;
                    chargeSummaryDetails.OwnCost = totalOwnCost;
                    newlist.Add(chargeSummaryDetails);
                }
                dg.rows = newlist;
                dg.total = newlist.Count;
                string result = JsonConvert.SerializeObject(dg);
                context.Response.Write(result);
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("AnalysisHandler", "visit: LoadTotalCostSummaryByChargename", ex);
                context.Response.Write("{\"rows\":[],\"total\":0,\"page\":0}");
            }
        }
        private void LoadRealCostSummaryByChargetype(HttpContext context)
        {
            try
            {
                string RoomIDs = context.Request.Params["RoomIDs"];
                List<int> RoomIDList = new List<int>();
                if (!string.IsNullOrEmpty(RoomIDs))
                {
                    RoomIDList = JsonConvert.DeserializeObject<List<int>>(RoomIDs);
                }
                string ProjectIDs = context.Request.Params["ProjectIDs"];
                List<int> ProjectIDList = new List<int>();
                if (RoomIDList.Count == 0)
                {
                    if (!string.IsNullOrEmpty(ProjectIDs))
                    {
                        ProjectIDList = JsonConvert.DeserializeObject<List<int>>(ProjectIDs).Where(p => p != 1).ToList();
                    }
                    ProjectIDList = WebUtil.GetMyProjects(WebUtil.GetUser(context).UserID, ProjectIDList).Where(p => p.ID != 1).Select(p => p.ID).ToList();
                }
                DateTime StartTime = DateTime.MinValue;
                DateTime.TryParse(context.Request.Params["StartTime"], out StartTime);
                DateTime EndTime = DateTime.MinValue;
                DateTime.TryParse(context.Request.Params["EndTime"], out EndTime);
                List<int> EqualProjectIDList = new List<int>();
                List<int> InProjectIDList = new List<int>();
                if (RoomIDList.Count == 0)
                {
                    List<int> MyProjectIDList = new List<int>();
                    if (!string.IsNullOrEmpty(ProjectIDs))
                    {
                        MyProjectIDList = JsonConvert.DeserializeObject<List<int>>(ProjectIDs).Where(p => p != 1).ToList();
                    }
                    Web.APPCode.CacheHelper.GetMyProjectListByUserID(WebUtil.GetUser(context).UserID, out EqualProjectIDList, out InProjectIDList, ProjectIDList: MyProjectIDList);
                    if (MyProjectIDList.Count == 0)
                    {
                        if (EqualProjectIDList.Count > 0)
                        {
                            EqualProjectIDList.Add(0);
                        }
                    }
                    else
                    {
                        string ALLProjectIDs = context.Request.Params["ALLProjectIDs"];
                        List<int> ALLProjectIDList = new List<int>();
                        if (!string.IsNullOrEmpty(ALLProjectIDs))
                        {
                            ALLProjectIDList = JsonConvert.DeserializeObject<List<int>>(ALLProjectIDs).Where(p => p != 1).ToList();
                        }
                        if (ALLProjectIDList.Count > 0)
                        {
                            EqualProjectIDList = ALLProjectIDList;
                        }
                    }
                }
                var payserviceList = Foresight.DataAccess.PayService.GetPayServiceList(RoomIDList, StartTime, EndTime, UserID: WebUtil.GetUser(context).UserID, EqualProjectIDList: EqualProjectIDList, InProjectIDList: InProjectIDList);
                List<int> ChargeStateList = new List<int>();
                ChargeStateList.Add(1);
                var shourulist = PrintRoomFeeHistory.GetPrintRoomFeeHistoryListByRoomProjectIDList(StartTime, EndTime, ProjectIDList, RoomIDList, UserID: WebUtil.GetUser(context).UserID, ChargeStateList: ChargeStateList);
                ChargeStateList = new List<int>();
                ChargeStateList.Add(3);
                ChargeStateList.Add(6);
                var zhichulist = PrintRoomFeeHistory.GetPrintRoomFeeHistoryListByRoomProjectIDList(StartTime, EndTime, ProjectIDList, RoomIDList, UserID: WebUtil.GetUser(context).UserID, ChargeStateList: ChargeStateList);
                var chargetypes = Foresight.DataAccess.ChargeMoneyType.GetChargeMoneyTypes().ToArray();
                var dic_list = new List<Dictionary<string, object>>();
                foreach (var item in chargetypes)
                {
                    if (item.ChargeTypeName.Contains("冲抵") || item.ChargeTypeName.Contains("冲销"))
                    {
                        continue;
                    }
                    decimal ShouRuCost = 0;
                    decimal ZhiChuCost = 0;
                    var shourulist1 = shourulist.Where(p => p.ChageType1 == item.ChargeTypeID).ToArray();
                    var shourulist2 = shourulist.Where(p => p.ChageType2 == item.ChargeTypeID).ToArray();
                    if (shourulist1.Length > 0)
                    {
                        ShouRuCost += shourulist1.Sum(p => { return p.RealMoneyCost1 > 0 ? p.RealMoneyCost1 : p.RealCost; });
                    }
                    if (shourulist2.Length > 0)
                    {
                        ShouRuCost += shourulist2.Sum(p => { return p.RealMoneyCost2 > 0 ? p.RealMoneyCost2 : 0; });
                    }
                    var zhichulist1 = zhichulist.Where(p => p.ChageType1 == item.ChargeTypeID).ToArray();
                    var zhichulist2 = zhichulist.Where(p => p.ChageType2 == item.ChargeTypeID).ToArray();
                    if (zhichulist1.Length > 0)
                    {
                        ZhiChuCost += zhichulist1.Sum(p => { return p.RealMoneyCost1 > 0 ? p.RealMoneyCost1 : p.RealCost; });
                    }
                    if (zhichulist2.Length > 0)
                    {
                        ZhiChuCost += zhichulist2.Sum(p => { return p.RealMoneyCost2 > 0 ? p.RealMoneyCost2 : 0; });
                    }
                    var my_list = payserviceList.Where(p => p.PayTypeID == item.ChargeTypeID).ToArray();
                    if (my_list.Length > 0)
                    {
                        ZhiChuCost += my_list.Sum(p => p.PayMoney);
                    }
                    if (ShouRuCost > 0 || ZhiChuCost > 0)
                    {
                        var dic = new Dictionary<string, object>();
                        dic["Name"] = item.ChargeTypeName;
                        dic["ShouRuCost"] = ShouRuCost;
                        dic["ZhiChuCost"] = ZhiChuCost;
                        dic_list.Add(dic);
                    }
                }
                var dg = new Foresight.DataAccess.Ui.DataGrid();
                dg.rows = dic_list;
                dg.page = 1;
                dg.total = dic_list.Count;
                bool canexport = WebUtil.GetBoolValue(context, "canexport");
                if (canexport)
                {
                    string downloadurl = string.Empty;
                    string error = string.Empty;
                    bool status = APPCode.ExportHelper.DownLoadShouRuZhiChuChargeTypeData(dg, out downloadurl, out error);
                    WebUtil.WriteJson(context, new { status = status, downloadurl = downloadurl, error = error });
                    return;
                }
                WebUtil.WriteJson(context, dg);
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("AnalysisHandler", "visit: LoadRealCostSummaryByChargetype", ex);
                context.Response.Write("{\"rows\":[],\"total\":0,\"page\":0}");
            }
        }
        private void LoadRealCostSummaryByChargeName(HttpContext context)
        {
            try
            {
                int CompanyID = 0;
                int.TryParse(context.Request.Params["CompanyID"], out CompanyID);
                string RoomID = context.Request.Params["RoomID"];
                List<int> RoomIDList = new List<int>();
                if (!string.IsNullOrEmpty(RoomID))
                {
                    RoomIDList = JsonConvert.DeserializeObject<List<int>>(RoomID);
                }
                string ProjectIDs = context.Request.Params["ProjectID"];
                List<int> ProjectIDList = new List<int>();
                if (RoomIDList.Count == 0)
                {
                    if (!string.IsNullOrEmpty(ProjectIDs))
                    {
                        ProjectIDList = JsonConvert.DeserializeObject<List<int>>(ProjectIDs).Where(p => p != 1).ToList();
                    }
                    ProjectIDList = WebUtil.GetMyProjects(WebUtil.GetUser(context).UserID, ProjectIDList).Where(p => p.ID != 1).Select(p => p.ID).ToList();
                }
                DateTime StartChargeTime = DateTime.MinValue;
                DateTime.TryParse(context.Request.Params["StartChargeTime"], out StartChargeTime);
                DateTime EndChargeTime = DateTime.MinValue;
                DateTime.TryParse(context.Request.Params["EndChargeTime"], out EndChargeTime);
                string ChargeMan = context.Request.Params["ChargeMan"];
                int ChargeSummaryID = GetIntValue(context, "ChargeSummary");
                int ChargeTypeID = GetIntValue(context, "ChargeType");
                List<int> ChargeState = new List<int>();
                ChargeState.Add(1);
                ChargeState.Add(4);
                DataGrid dg = ChargeSummaryDetails.GetHistorySummaryGroupByChargeName(RoomIDList, ProjectIDList, StartChargeTime, EndChargeTime, CompanyID, ChargeMan, ChargeSummaryID, ChargeTypeID, int.MinValue, ChargeState, UserID: WebUtil.GetUser(context).UserID);
                ChargeSummaryDetails[] list = dg.rows as ChargeSummaryDetails[];
                list = list.Where(p => p.RealCost > 0 || p.Cost > 0 || p.Discount > 0).ToArray();
                List<ChargeSummaryDetails> newlist = list.ToList();
                if (newlist.Count > 0)
                {
                    decimal totalCost = 0;
                    decimal totalRealCost = 0;
                    decimal totalDiscount = 0;
                    int TotalNumber = 0;
                    decimal TotalCount = 0;
                    foreach (var item in newlist)
                    {
                        totalCost += item.Cost > 0 ? item.Cost : 0;
                        totalRealCost += item.RealCost > 0 ? item.RealCost : 0;
                        totalDiscount += item.Discount > 0 ? item.Discount : 0;
                        TotalNumber += item.TotalNumber > 0 ? item.TotalNumber : 0;
                        TotalCount += item.TotalCount > 0 ? item.TotalCount : 0;
                    }
                    var chargeSummaryDetails = new ChargeSummaryDetails();
                    chargeSummaryDetails.Name = "合计";
                    chargeSummaryDetails.Cost = totalCost;
                    chargeSummaryDetails.RealCost = totalRealCost;
                    chargeSummaryDetails.Discount = totalDiscount;
                    chargeSummaryDetails.TotalNumber = TotalNumber;
                    chargeSummaryDetails.TotalCount = TotalCount;
                    newlist.Add(chargeSummaryDetails);
                }
                dg.rows = newlist;
                dg.total = newlist.Count;
                string result = JsonConvert.SerializeObject(dg);
                context.Response.Write(result);
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("AnalysisHandler", "visit: LoadRealCostSummaryByChargeName", ex);
                context.Response.Write("{\"rows\":[],\"total\":0,\"page\":0}");
            }
        }
        private void LoadToChargeSummaryByChargename(HttpContext context)
        {
            try
            {
                int CompanyID = 0;
                int.TryParse(context.Request.Params["CompanyID"], out CompanyID);
                string RoomID = context.Request.Params["RoomID"];
                List<int> RoomIDList = new List<int>();
                if (!string.IsNullOrEmpty(RoomID))
                {
                    RoomIDList = JsonConvert.DeserializeObject<List<int>>(RoomID);
                }
                string ProjectIDs = context.Request.Params["ProjectID"];
                List<int> ProjectIDList = new List<int>();
                if (RoomIDList.Count == 0)
                {
                    if (!string.IsNullOrEmpty(ProjectIDs))
                    {
                        ProjectIDList = JsonConvert.DeserializeObject<List<int>>(ProjectIDs).Where(p => p != 1).ToList();
                    }
                    ProjectIDList = WebUtil.GetMyProjects(WebUtil.GetUser(context).UserID, ProjectIDList).Where(p => p.ID != 1).Select(p => p.ID).ToList();
                }
                DateTime StartTime = DateTime.MinValue;
                DateTime.TryParse(context.Request.Params["StartTime"], out StartTime);
                DateTime EndTime = DateTime.MinValue;
                DateTime.TryParse(context.Request.Params["EndTime"], out EndTime);
                string ChargeSummarys = context.Request.Params["ChargeSummarys"];
                int[] ChargeSummaryID = new int[] { };
                if (!string.IsNullOrEmpty(ChargeSummarys))
                {
                    ChargeSummaryID = JsonConvert.DeserializeObject<int[]>(ChargeSummarys);
                }
                ChargeSummaryDetails[] summarylist = ChargeSummaryDetails.GetChargeSummaryByCompanyID(CompanyID, ChargeSummaryID);

                //计算期初欠费
                RoomFeeAnalysis[] feelist = RoomFeeAnalysis.GetRoomFeeAnalysisListByRoomID(RoomIDList, ProjectIDList, DateTime.MinValue, DateTime.MinValue, ChargeSummaryID, IsRoomFee: true, IsContractFee: true, UserID: WebUtil.GetUser(context).UserID);
                var feelist1dic = new List<Dictionary<string, object>>();
                if (StartTime > DateTime.MinValue)
                {
                    feelist1dic = RoomFeeAnalysis.GetRoomFeeAnalysisDictionary(feelist, DateTime.MinValue, StartTime.AddDays(-1));
                }
                //计算本期欠费
                var feelist2dic = RoomFeeAnalysis.GetRoomFeeAnalysisDictionary(feelist, StartTime, EndTime);

                //计算期末欠费
                //ViewRoomFeeDetail[] feelist3 = ViewRoomFeeDetail.GetViewRoomFeeDetailListByRoomID(RoomIDList, new List<int>(), DateTime.Now, EndTime, ChargeSummaryID);
                foreach (var summary in summarylist)
                {
                    summary.PreTotalCost = feelist1dic.Where(p => Convert.ToInt32(p["ChargeID"]) == summary.ID && Convert.ToDecimal(p["TotalCost"]) > 0).Sum(p => Convert.ToDecimal(p["TotalCost"]));

                    summary.Cost = feelist2dic.Where(p => Convert.ToInt32(p["ChargeID"]) == summary.ID && Convert.ToDecimal(p["TotalCost"]) > 0).Sum(p => Convert.ToDecimal(p["TotalCost"]));

                    summary.AfterTotalCost = summary.Cost + summary.PreTotalCost;
                }
                var preTotalCost = feelist1dic.Sum(p => Convert.ToDecimal(p["TotalCost"]));
                var othersummary = new ChargeSummaryDetails();
                othersummary.PreTotalCost = feelist1dic.Where(p => !(summarylist.Select(q => q.ID).Contains(Convert.ToInt32(p["ChargeID"]))) && Convert.ToDecimal(p["TotalCost"]) > 0).Sum(p => Convert.ToDecimal(p["TotalCost"]));
                othersummary.Cost = feelist2dic.Where(p => !(summarylist.Select(q => q.ID).Contains(Convert.ToInt32(p["ChargeID"]))) && Convert.ToDecimal(p["TotalCost"]) > 0).Sum(p => Convert.ToDecimal(p["TotalCost"]));
                othersummary.AfterTotalCost = othersummary.Cost + othersummary.PreTotalCost;
                othersummary.Name = "其他";
                if (othersummary.Cost > 0 || othersummary.PreTotalCost > 0 || othersummary.AfterTotalCost > 0)
                {
                    summarylist.ToList().Add(othersummary);
                }
                summarylist = summarylist.Where(p => p.Cost > 0 || p.PreTotalCost > 0 || p.AfterTotalCost > 0).ToArray();
                List<ChargeSummaryDetails> newlist = summarylist.ToList();
                if (newlist.Count > 0)
                {
                    decimal totalCost = 0;
                    decimal totalPreCost = 0;
                    decimal totalAfterCost = 0;
                    foreach (var item in summarylist)
                    {
                        var itemCost = item.Cost > 0 ? item.Cost : 0;
                        totalCost += itemCost;
                        var itemPreTotalCost = item.PreTotalCost > 0 ? item.PreTotalCost : 0;
                        totalPreCost += itemPreTotalCost;
                        var itemAfterTotalCost = item.AfterTotalCost > 0 ? item.AfterTotalCost : 0;
                        totalAfterCost += itemAfterTotalCost;
                    }
                    var chargeSummaryDetails = new ChargeSummaryDetails();
                    chargeSummaryDetails.Name = "合计";
                    chargeSummaryDetails.Cost = totalCost;
                    chargeSummaryDetails.PreTotalCost = totalPreCost;
                    chargeSummaryDetails.AfterTotalCost = totalAfterCost;
                    newlist.Add(chargeSummaryDetails);
                }
                DataGrid dg = new DataGrid();
                dg.rows = newlist;
                dg.total = newlist.Count;
                dg.page = 1;
                string result = JsonConvert.SerializeObject(dg);
                bool canexport = WebUtil.GetBoolValue(context, "canexport");
                if (canexport)
                {
                    string downloadurl = string.Empty;
                    string error = string.Empty;
                    bool status = APPCode.ExportHelper.DownLoadToChargeAnalysisSummaryV2Data(dg, out downloadurl, out error);
                    WebUtil.WriteJson(context, new { status = status, downloadurl = downloadurl, error = error });
                    return;
                }
                context.Response.Write(result);
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("AnalysisHandler", "visit: LoadToChargeSummaryByChargename", ex);
                context.Response.Write("{\"rows\":[],\"total\":0,\"page\":0}");
            }
        }
        private void saveroomfeenote(HttpContext context)
        {
            string ListStr = context.Request.Params["List"];
            List<RoomNote> list = JsonConvert.DeserializeObject<List<RoomNote>>(ListStr);
            if (list.Count == 0)
            {
                context.Response.Write("{\"status\":true}");
                return;
            }
            List<Foresight.DataAccess.RooFeeRemark> newlist = new List<Foresight.DataAccess.RooFeeRemark>();
            foreach (var item in list)
            {
                var roomFeeNote = Foresight.DataAccess.RooFeeRemark.GetRooFeeRemarkByRoomFeeID(item.ID);
                if (roomFeeNote == null)
                {
                    roomFeeNote = new Foresight.DataAccess.RooFeeRemark();
                    roomFeeNote.RooFeeID = item.ID;
                }
                roomFeeNote.CategoryNote = item.CategoryNote;
                roomFeeNote.CategoryID = item.CategoryID;
                roomFeeNote.RemarkNote = item.RemarkNote;
                newlist.Add(roomFeeNote);
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    foreach (var item in newlist)
                    {
                        item.Save(helper);
                    }
                    helper.Commit();
                    context.Response.Write("{\"status\":true}");
                }
                catch (Exception ex)
                {
                    LogHelper.WriteError("AnalysisHandler", "visit: saveroomfeenote", ex);
                    helper.Rollback();
                    context.Response.Write("{\"status\":false}");
                }
            }
        }
        private void gettochargesearch(HttpContext context)
        {
            var summarys = Foresight.DataAccess.ChargeSummary.GetChargeSummaries();
            var categories = Foresight.DataAccess.OwnFeeCategory.GetOwnFeeCategories().OrderBy(p => p.SortOrder);
            var properties = Foresight.DataAccess.RoomProperty.GetRoomProperties();
            var property_items = properties.Select(p =>
            {
                var results = new { ID = p.ID, Name = p.Name };
                return results;
            }).ToList();
            property_items.Insert(0, new { ID = 0, Name = "全部" });

            var roomstates = Foresight.DataAccess.RoomState.GetRoomStates();
            var roomstates_items = roomstates.Select(p =>
            {
                var results = new { ID = p.ID, Name = p.Name };
                return results;
            }).ToList();
            //roomstates_items.Insert(0, new { ID = 0, Name = "全部" });
            var item = new { summarys = summarys, categories = categories, properties = property_items, roomstates = roomstates_items };
            string result = JsonConvert.SerializeObject(item);
            context.Response.Write(result);
        }
        private void getrealcostsearch(HttpContext context)
        {
            var users = Foresight.DataAccess.User.GetSysUserList();
            var dic = new Dictionary<string, object>();
            var userList = users.Select(p =>
            {
                dic = new Dictionary<string, object>();
                dic["UserID"] = p.UserID;
                dic["RealName"] = p.FinalRealName;
                return dic;
            }).ToList();
            var summarys = Foresight.DataAccess.ChargeSummary.GetChargeSummaries();
            var chargetypes = Foresight.DataAccess.ChargeMoneyType.GetChargeMoneyTypes();
            var categories = Foresight.DataAccess.Category.GetCategories();
            var item = new { users = userList, summarys = summarys, chargetypes = chargetypes, categories = categories };
            string result = JsonConvert.SerializeObject(item);
            context.Response.Write(result);
        }
        private decimal GetDecimalValue(HttpContext context, string param)
        {
            decimal value = 0;
            decimal.TryParse(context.Request.Params[param], out value);
            return value;
        }
        private int GetIntValue(HttpContext context, string param)
        {
            int value = 0;
            int.TryParse(context.Request.Params[param], out value);
            return value;
        }
        private DateTime GetDateValue(HttpContext context, string param)
        {
            DateTime value = DateTime.MinValue;
            DateTime.TryParse(context.Request.Params[param], out value);
            return value;
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