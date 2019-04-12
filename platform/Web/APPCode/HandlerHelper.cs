using Foresight.DataAccess;
using Foresight.DataAccess.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Utility;

namespace Web.APPCode
{
    public class HandlerHelper
    {
        public static Foresight.DataAccess.Ui.DataGrid GetRoomFeeList(HttpContext context, Dictionary<string, object> AccpetParam, out int currentcount)
        {
            currentcount = 0;
            DateTime StartTime = WebUtil.GetDateTimeByObj(AccpetParam, "StartTime");
            DateTime EndTime = WebUtil.GetDateTimeByObj(AccpetParam, "EndTime");
            if (StartTime > DateTime.MinValue && EndTime > DateTime.MinValue && StartTime > EndTime)
            {
                return new Foresight.DataAccess.Ui.DataGrid();
            }
            DateTime ReadyStartTime = WebUtil.GetDateTimeByObj(AccpetParam, "ReadyStartTime");
            DateTime ReadyEndTime = WebUtil.GetDateTimeByObj(AccpetParam, "ReadyEndTime");
            if (ReadyStartTime > DateTime.MinValue && ReadyEndTime > DateTime.MinValue && ReadyStartTime > ReadyEndTime)
            {
                return new Foresight.DataAccess.Ui.DataGrid();
            }
            string page = !AccpetParam.ContainsKey("page") ? "1" : AccpetParam["page"].ToString();
            string rows = !AccpetParam.ContainsKey("rows") ? "100" : AccpetParam["rows"].ToString();
            long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
            int pageSize = int.Parse(rows);
            int CompanyID = WebUtil.GetIntByObj(AccpetParam, "CompanyID");
            string RoomID = !AccpetParam.ContainsKey("RoomID") ? string.Empty : AccpetParam["RoomID"].ToString();
            List<int> RoomIDList = new List<int>();
            if (!string.IsNullOrEmpty(RoomID))
            {
                RoomIDList = JsonConvert.DeserializeObject<List<int>>(RoomID);
            }
            string ProjectID = !AccpetParam.ContainsKey("ProjectID") ? string.Empty : AccpetParam["ProjectID"].ToString();
            List<int> ProjectIDList = new List<int>();
            if (RoomIDList.Count == 0)
            {
                if (!string.IsNullOrEmpty(ProjectID))
                {
                    ProjectIDList = JsonConvert.DeserializeObject<List<int>>(ProjectID).Where(p => p != 1).ToList();
                }
                ProjectIDList = WebUtil.GetMyProjects(WebUtil.GetUser(context).UserID, ProjectIDList).Where(p => p.ID != 1).Select(p => p.ID).ToList();
            }
            int FeeID = WebUtil.GetIntByObj(AccpetParam, "FeeID");
            int CategoryID = WebUtil.GetIntByObj(AccpetParam, "CategoryID");
            int TypeID = WebUtil.GetIntByObj(AccpetParam, "TypeID");
            List<int> FeeTypeList = new List<int>();
            string FeeType = !AccpetParam.ContainsKey("FeeType") ? string.Empty : AccpetParam["FeeType"].ToString();
            if (!string.IsNullOrEmpty(FeeType))
            {
                FeeTypeList = JsonConvert.DeserializeObject<List<int>>(FeeType);
            }
            string ChargeSummarys = !AccpetParam.ContainsKey("ChargeSummarys") ? string.Empty : AccpetParam["ChargeSummarys"].ToString();
            int[] ChargeSummaryID = new int[] { };
            if (!string.IsNullOrEmpty(ChargeSummarys))
            {
                ChargeSummaryID = JsonConvert.DeserializeObject<int[]>(ChargeSummarys);
            }
            bool IsToCharge = false;
            string IsToChargeStr = !AccpetParam.ContainsKey("IsToCharge") ? string.Empty : AccpetParam["IsToCharge"].ToString();
            if (!string.IsNullOrEmpty(IsToChargeStr))
            {
                bool.TryParse(IsToChargeStr, out IsToCharge);
            }
            bool ShowFooter = false;
            string ShowFooterStr = !AccpetParam.ContainsKey("ShowFooter") ? string.Empty : AccpetParam["ShowFooter"].ToString();
            if (!string.IsNullOrEmpty(ShowFooterStr))
            {
                bool.TryParse(ShowFooterStr, out ShowFooter);
            }
            int IsCharged = -1;
            string IsChargedStr = !AccpetParam.ContainsKey("IsCharged") ? string.Empty : AccpetParam["IsCharged"].ToString();
            if (!string.IsNullOrEmpty(IsChargedStr))
            {
                IsCharged = WebUtil.GetIntByObj(AccpetParam, "IsCharged");
            }
            string RoomPropertyStr = !AccpetParam.ContainsKey("RoomPropertyList") ? string.Empty : AccpetParam["RoomPropertyList"].ToString();
            List<int> RoomPropertyList = new List<int>();
            if (!string.IsNullOrEmpty(RoomPropertyStr))
            {
                RoomPropertyList = JsonConvert.DeserializeObject<List<int>>(RoomPropertyStr);
            }
            RoomPropertyList = RoomPropertyList.Where(p => p != 0).ToList();
            bool IsContractFee = false;
            string IsContractFeeStr = !AccpetParam.ContainsKey("IsContractFee") ? string.Empty : AccpetParam["IsContractFee"].ToString();
            if (!string.IsNullOrEmpty(IsContractFeeStr))
            {
                bool.TryParse(IsContractFeeStr, out IsContractFee);
            }
            bool IsRoomFee = true;
            string IsRoomFeeStr = !AccpetParam.ContainsKey("IsRoomFee") ? string.Empty : AccpetParam["IsRoomFee"].ToString();
            if (!string.IsNullOrEmpty(IsRoomFeeStr))
            {
                bool.TryParse(IsRoomFeeStr, out IsRoomFee);
            }
            int ContractID = WebUtil.GetIntByObj(AccpetParam, "ContractID");
            bool IsCuiShou = false;
            string IsCuiShouStr = !AccpetParam.ContainsKey("IsCuiShou") ? string.Empty : AccpetParam["IsCuiShou"].ToString();
            if (!string.IsNullOrEmpty(IsCuiShouStr))
            {
                bool.TryParse(IsCuiShouStr, out IsCuiShou);
            }
            bool IsAutoEndTime = false;
            string IsAutoEndTimeStr = !AccpetParam.ContainsKey("IsAutoEndTime") ? string.Empty : AccpetParam["IsAutoEndTime"].ToString();
            if (!string.IsNullOrEmpty(IsAutoEndTimeStr))
            {
                bool.TryParse(IsAutoEndTimeStr, out IsAutoEndTime);
            }
            string keywords = !AccpetParam.ContainsKey("keywords") ? string.Empty : AccpetParam["keywords"].ToString();
            bool ExcludeHistoryChargeTime = false;
            string ExcludeHistoryChargeTimeStr = !AccpetParam.ContainsKey("ExcludeHistoryChargeTime") ? string.Empty : AccpetParam["ExcludeHistoryChargeTime"].ToString();
            if (!string.IsNullOrEmpty(ExcludeHistoryChargeTimeStr))
            {
                bool.TryParse(ExcludeHistoryChargeTimeStr, out ExcludeHistoryChargeTime);
            }
            int DivideID = WebUtil.GetIntByObj(AccpetParam, "DivideID");
            string RoomStateStr = !AccpetParam.ContainsKey("RoomStateList") ? string.Empty : AccpetParam["RoomStateList"].ToString();
            List<int> RoomStateList = new List<int>();
            if (!string.IsNullOrEmpty(RoomStateStr))
            {
                RoomStateList = JsonConvert.DeserializeObject<List<int>>(RoomStateStr);
            }
            RoomStateList = RoomStateList.Where(p => p != 0).ToList();
            int PreChargeID = WebUtil.GetIntByObj(AccpetParam, "PreChargeID");
            bool IsContractWarning = false;
            string IsContractWarningStr = !AccpetParam.ContainsKey("IsContractWarning") ? string.Empty : AccpetParam["IsContractWarning"].ToString();
            if (!string.IsNullOrEmpty(IsContractWarningStr))
            {
                bool.TryParse(IsContractWarningStr, out IsContractWarning);
            }
            currentcount = WebUtil.GetIntByObj(AccpetParam, "currentcount");
            string RelationBelongTeam = WebUtil.GetStrByObj(AccpetParam, "RelationBelongTeam");
            Foresight.DataAccess.Ui.DataGrid dg = new Foresight.DataAccess.Ui.DataGrid();

            string canexportsrt = !AccpetParam.ContainsKey("canexport") ? string.Empty : AccpetParam["canexport"].ToString();
            bool canexport = false;
            if (!string.IsNullOrEmpty(canexportsrt))
            {
                bool.TryParse(canexportsrt, out canexport);
            }

            if (IsToCharge)
            {
                dg = ViewRoomFee.GetViewRoomFeeGridByRoomID(RoomIDList, ProjectIDList, StartTime, EndTime, ChargeSummaryID, IsCharged, RoomPropertyList, IsRoomFee, IsContractFee, ContractID, IsAutoEndTime, keywords, ExcludeHistoryChargeTime, DivideID: DivideID, RoomStateList: RoomStateList, UserID: WebUtil.GetUser(HttpContext.Current).UserID, ReadyStartTime: ReadyStartTime, ReadyEndTime: ReadyEndTime, IsContractWarning: IsContractWarning, currentcount: currentcount, IsCuiShou: IsCuiShou, pageSize: pageSize, ShowFooter: ShowFooter, RelationBelongTeam: RelationBelongTeam, canexport: canexport);
            }
            else
            {
                int StartTimeState = 0;
                string StartTimeStateStr = !AccpetParam.ContainsKey("StartTimeState") ? string.Empty : AccpetParam["StartTimeState"].ToString();
                if (!string.IsNullOrEmpty(StartTimeStateStr))
                {
                    StartTimeState = WebUtil.GetIntByObj(AccpetParam, "StartTimeState");
                }
                dg = ViewRoomFee.GetViewRoomFeeListGridByRoomID(RoomIDList, FeeID, CategoryID, TypeID, FeeTypeList, StartTime, EndTime, CompanyID, IsRoomFee, IsContractFee, ContractID, " order by isnull(RelatedFeeID,0) asc,[DefaultOrder] asc,[AddTime] asc", startRowIndex, pageSize, IsAutoEndTime, ProjectIDList, ChargeSummaryID, RoomPropertyList, keywords, StartTimeState, DivideID: DivideID, RoomStateList: RoomStateList, UserID: WebUtil.GetUser(context).UserID, PreChargeID: PreChargeID);
            }
            return dg;
        }
        public static void SaveRoomFee(RoomFee roomFee, string ChargeMan, SqlHelper helper, PrintRoomFeeHistory printRoomFeeHistory, ViewChargeSummary[] ViewChargeSummaryList, string OpenID = "")
        {
            try
            {
                int HistoryID = RoomFeeHistory.InsertRoomFeeHistoryByRoomID(roomFee.ID, ChargeMan, helper);
                LogHelper.WriteInfo("Web.APPCode.HandlerHelper.SaveRoomFee.HistoryID", HistoryID.ToString());
                var roomFeeHistory = RoomFeeHistory.GetRoomFeeHistory(HistoryID, helper);
                roomFeeHistory.OpenID = OpenID;
                roomFeeHistory.PrintID = printRoomFeeHistory.ID;
                roomFeeHistory.ChargeTime = printRoomFeeHistory.ChargeTime > DateTime.MinValue ? printRoomFeeHistory.ChargeTime : DateTime.Now;
                if (!string.IsNullOrEmpty(roomFee.TradeNo))
                {
                    roomFeeHistory.OrderID = roomFee.OrderID;
                    roomFeeHistory.TradeNo = roomFee.TradeNo;
                    var payment = Foresight.DataAccess.Payment.GetPaymentByTradeNo(roomFee.TradeNo, helper);
                    Payment.CompletePayment(helper, TradeNo: roomFee.TradeNo);
                }
                if (roomFeeHistory.DefaultChargeManID <= 0)
                {
                    var default_relation = RoomPhoneRelation.GetDefaultInChargeFeeRoomPhoneRelation(roomFeeHistory.RoomID, roomFeeHistory.ContractID, helper);
                    if (default_relation != null)
                    {
                        roomFeeHistory.DefaultChargeManID = default_relation.ID;
                        roomFeeHistory.DefaultChargeManName = default_relation.RelationName;
                    }
                }
                roomFeeHistory.Save(helper);
                List<SqlParameter> parameters = new List<SqlParameter>();
                string cmdwhere = string.Empty;
                if (roomFeeHistory.StartTime > DateTime.MinValue)
                {
                    cmdwhere += " and [StartTime]>=@StartTime";
                    parameters.Add(new SqlParameter("@StartTime", roomFeeHistory.StartTime));
                }
                if (roomFeeHistory.EndTime > DateTime.MinValue)
                {
                    cmdwhere += " and [EndTime]<=@EndTime";
                    parameters.Add(new SqlParameter("@EndTime", roomFeeHistory.EndTime));
                }
                string cmdtext = "update [PrintRoomFeeHistory] set [ChargeTime]=@ChargeTime,[ChargeMan]=@ChargeMan,[ChageType1]=@ChageType1,[Remark]=@Remark where [ID] in (select [PrintID] from [RoomFeeHistory] where [ChargeState]=5 and [RoomID]=@RoomID and [ChargeID]=@ChargeID " + cmdwhere + ");";
                cmdtext += "update [RoomFeeHistory] set [ChargeTime]=@ChargeTime,[ChargeMan]=@ChargeMan,[ChargeState]=1,[Remark]=@Remark where [ChargeState]=5 and [RoomID]=@RoomID and [ChargeID]=@ChargeID " + cmdwhere + ";";
                parameters.Add(new SqlParameter("@ChargeTime", roomFeeHistory.ChargeTime));
                parameters.Add(new SqlParameter("@ChargeMan", roomFeeHistory.ChargeMan));
                parameters.Add(new SqlParameter("@Remark", roomFeeHistory.Remark));
                parameters.Add(new SqlParameter("@RoomID", roomFeeHistory.RoomID));
                parameters.Add(new SqlParameter("@ChargeID", roomFeeHistory.ChargeID));
                parameters.Add(new SqlParameter("@ChageType1", printRoomFeeHistory.ChageType1));
                helper.Execute(cmdtext, CommandType.Text, parameters);

                ViewChargeSummary summary = ViewChargeSummaryList.FirstOrDefault(p => p.ID == roomFee.ChargeID);
                //冲抵收费
                #region 冲抵收费
                if (roomFee.ChargeFee > 0)
                {
                    roomFeeHistory.ChargeState = 4;
                    roomFeeHistory.Save(helper);
                }
                #endregion
                //抄表账单
                if (roomFee.ImportFeeID > 0)
                {
                    ImportFee importFee = ImportFee.GetOrCreateImportFeeByID(roomFee.ImportFeeID, helper);
                    if (importFee != null)
                    {
                        importFee.StartTime = roomFeeHistory.StartTime;
                        importFee.EndTime = roomFeeHistory.EndTime;
                        importFee.TotalPoint = roomFeeHistory.UseCount;
                        importFee.UnitPrice = roomFeeHistory.UnitPrice;
                        importFee.TotalPrice = roomFeeHistory.RealCost;
                        importFee.ChargeStatus = 1;
                        importFee.Save(helper);
                    }
                }
                //商业分成
                if (roomFee.ContractDivideID > 0)
                {
                    var divide = Contract_Divide.GetContract_Divide(roomFee.ContractDivideID, helper);
                    if (divide != null)
                    {
                        divide.ChargeStatus = 1;
                        divide.Save(helper);
                    }
                }
                List<int> FeeIDList = new List<int>();
                FeeIDList.Add(roomFee.ID);
                var historylist = RoomFeeHistory.GetRoomFeeHistoryByFeeIDList(FeeIDList, helper).Where(p => p.ChargeState == 1 || p.ChargeState == 4);
                decimal totalpaycost = historylist.Where(p => p.RealCost > 0).Sum(p => p.RealCost);
                decimal totaldiscountcost = historylist.Where(p => p.Discount > 0).Sum(p => p.Discount);
                decimal restcost = roomFee.Cost - totalpaycost - totaldiscountcost;
                if (restcost > 0)
                {
                    roomFee.IsCharged = false;
                    roomFee.Discount = 0;
                    roomFee.RealCost = 0;
                    roomFee.ChargeFee = 0;
                    roomFee.Save(helper);
                    return;
                }
                roomFee.Delete(helper);
                if (roomFee.OnlyOnceCharge)
                {
                    if (roomFee.NewEndTime == DateTime.MinValue)
                    {
                        return;
                    }
                    if (roomFee.EndTime >= roomFee.NewEndTime)
                    {
                        return;
                    }
                }
                if (roomFee.ContractID <= 0)
                {
                    if (summary.FeeType != 1)
                    {
                        return;
                    }
                    if (roomFee.EndTime >= roomFee.NewEndTime && roomFee.NewEndTime != DateTime.MinValue)
                    {
                        return;
                    }
                }
                else
                {
                    if (roomFee.ContractDivideID > 0)
                    {
                        return;
                    }
                    if ((roomFee.EndTime >= roomFee.NewEndTime && roomFee.NewEndTime != DateTime.MinValue) || roomFee.EndTime == DateTime.MinValue)
                    {
                        return;
                    }
                }
                DateTime RoomFee_EndTime = DateTime.MinValue;
                DateTime RoomFee_StartTime = roomFee.EndTime > DateTime.MinValue ? roomFee.EndTime.AddDays(1) : DateTime.MinValue;
                if (roomFee.ContractID > 0)
                {
                    RoomFee_EndTime = roomFee.NewEndTime;
                }
                else
                {
                    var viewChargeSummary = ViewChargeSummaryList.FirstOrDefault(p => p.ID == roomFee.ChargeID);
                    RoomFee_EndTime = Web.APPCode.CommHelper.GetEndTime(viewChargeSummary, RoomFee_StartTime);
                }
                var newRoomFee = Foresight.DataAccess.RoomFee.SetInfo_RoomFee(roomFee.RoomID, RoomFee_StartTime, RoomFee_EndTime, roomFee.Cost, 0, roomFee.UnitPrice, roomFee.ChargeID, ContractID: roomFee.ContractID, RelatedFeeID: roomFee.RelatedFeeID, DefaultChargeManID: roomFee.DefaultChargeManID, DefaultChargeManName: roomFee.DefaultChargeManName, Contract_RoomChargeID: roomFee.Contract_RoomChargeID, ContractDivideID: roomFee.ContractDivideID, IsCycleFee: true, NewEndTime: roomFee.NewEndTime, cansave: true, helper: helper);
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("APPCode.HandlerHelper", "SaveRoomFee", ex);
                throw ex;
            }
        }
        public static Foresight.DataAccess.Ui.DataGrid loadshoufeilvquanzebyroom(long startRowIndex, int pageSize, int CompanyID, List<int> RoomIDList, List<int> ProjectIDList, DateTime StartTime, DateTime EndTime, List<int> ChargeIDList, int ShowType, bool IsQuanZe, bool IsAnalysisQuery = false, bool canexport = false)
        {
            try
            {
                if (!IsQuanZe)
                {
                    return loadshoufeilvshoufubyroom(startRowIndex, pageSize, CompanyID, RoomIDList, ProjectIDList, StartTime, EndTime, ChargeIDList, ShowType, canexport: canexport);
                }
                Foresight.DataAccess.Ui.DataGrid dg = ChargeSummaryShouFeiLvAnalysis.GetChargeSummaryShouFeiLvAnalysisByRoom(ProjectIDList, RoomIDList, StartTime, EndTime, CompanyID, ChargeIDList, "order by DefaultOrder asc", startRowIndex, pageSize, ShowType, canexport: canexport);
                var list = dg.rows as ChargeSummaryShouFeiLvAnalysis[];
                if (list.Length == 0)
                {
                    return new Foresight.DataAccess.Ui.DataGrid();
                }
                var viewRoomFeeList = RoomFeeAnalysis.GetRoomFeeAnalysisListByRoomID(RoomIDList, ProjectIDList, StartTime, EndTime, ChargeIDList.ToArray(), true, UserID: WebUtil.GetUser(HttpContext.Current).UserID, IsAnalysisQuery: IsAnalysisQuery);
                var viewRoomFeeHistoryList = ViewRoomFeeHistoryDetail.GetViewRoomFeeHistoryDetail2List(RoomIDList, ProjectIDList, StartTime, EndTime, ChargeIDList, UserID: WebUtil.GetUser(HttpContext.Current).UserID, IsAnalysisQuery: IsAnalysisQuery);
                foreach (var item in list)
                {
                    var child_historyfee_list = viewRoomFeeHistoryList.Where(p => p.RoomID == item.RoomID);
                    var child_fee_list = viewRoomFeeList.Where(p => p.RoomID == item.RoomID).ToArray();
                    item.MonthLishiShouBenqi_ShiShou = child_historyfee_list.Sum(q => q.LishiShouBenqi_ShiShou);
                    item.MonthLishiShouBenqi_ChongDi = child_historyfee_list.Sum(q => q.LishiShouBenqi_ChongDi);
                    item.MonthLishiShouBenqi_JianMian = child_historyfee_list.Sum(q => q.LishiShouBenqi_JianMian);
                    item.MonthLishiShouBenqi = child_historyfee_list.Sum(q => q.LishiShouBenqi);

                    item.MonthBenqiShouLishi_ShiShou = child_historyfee_list.Sum(q => q.BenqiShouLishi_ShiShou);
                    item.MonthBenqiShouLishi_ChongDi = child_historyfee_list.Sum(q => q.BenqiShouLishi_ChongDi);
                    item.MonthBenqiShouLishi_JianMian = child_historyfee_list.Sum(q => q.BenqiShouLishi_JianMian);
                    item.MonthBenqiShouLishi = child_historyfee_list.Sum(q => q.BenqiShouLishi);

                    item.MonthBenqiShouBenqi_ShiShou = child_historyfee_list.Sum(q => q.BenqiShouBenqi_ShiShou);
                    item.MonthBenqiShouBenqi_ChongDi = child_historyfee_list.Sum(q => q.BenqiShouBenqi_ChongDi);
                    item.MonthBenqiShouBenqi_JianMian = child_historyfee_list.Sum(q => q.BenqiShouBenqi_JianMian);
                    item.MonthBenqiShouBenqi = child_historyfee_list.Sum(q => q.BenqiShouBenqi);

                    item.MonthBenqiYuShou_ShiShou = child_historyfee_list.Sum(q => q.BenqiYuShou_ShiShou);
                    item.MonthBenqiYuShou_ChongDi = child_historyfee_list.Sum(q => q.BenqiYuShou_ChongDi);
                    item.MonthBenqiYuShou_JianMian = child_historyfee_list.Sum(q => q.BenqiYuShou_JianMian);
                    item.MonthBenqiYuShou = child_historyfee_list.Sum(q => q.BenqiYuShou);

                    item.MonthZhiHouShouBenqi_ShiShou = child_historyfee_list.Sum(q => q.ZhiHouShouBenqi_ShiShou);
                    item.MonthZhiHouShouBenqi_ChongDi = child_historyfee_list.Sum(q => q.ZhiHouShouBenqi_ChongDi);
                    item.MonthZhiHouShouBenqi_JianMian = child_historyfee_list.Sum(q => q.ZhiHouShouBenqi_JianMian);
                    item.MonthZhiHouShouBenqi = child_historyfee_list.Sum(q => q.ZhiHouShouBenqi);

                    item.MonthBenqiChongXiao_ShiShou = child_historyfee_list.Sum(q => q.BenqiChongXiao_ShiShou);
                    item.MonthBenqiChongXiao_ChongDi = child_historyfee_list.Sum(q => q.BenqiChongXiao_ChongDi);
                    item.MonthBenqiChongXiao_JianMian = child_historyfee_list.Sum(q => q.BenqiChongXiao_JianMian);
                    item.MonthBenqiChongXiao = child_historyfee_list.Sum(q => q.BenqiChongXiao);

                    item.BenQiDiscount = child_historyfee_list.Sum(q => q.MonthDiscountCost);
                    item.BenQiQianFei = child_fee_list.Sum(q => q.TotalFinalCost);
                    //本期应收
                    decimal MonthBenQiYingShou_1 = child_fee_list.Sum(q => q.TotalCost);
                    decimal MonthBenQiYingShou_2 = ViewRoomFeeHistoryBase.GetViewRoomFeeHistoryTotalCost(my_history_list: child_historyfee_list.ToArray());
                    item.MonthBenQiYingShou = MonthBenQiYingShou_1 + MonthBenQiYingShou_2;
                    decimal BenQiQianFeiFenMu = item.MonthBenQiYingShou;
                    if (BenQiQianFeiFenMu > 0)
                    {
                        decimal BenQiQianFeiFenZi = item.MonthLishiShouBenqi + item.MonthBenqiShouBenqi;
                        item.BenQiShouFeiLv = Math.Round((decimal)((BenQiQianFeiFenZi / BenQiQianFeiFenMu) * 100), 2, MidpointRounding.AwayFromZero) + "%";
                        decimal ShiShiShouFeiLvFenZi = item.MonthLishiShouBenqi + item.MonthBenqiShouBenqi + item.MonthZhiHouShouBenqi;
                        item.ShiShiShouFeiLv = Math.Round((decimal)((ShiShiShouFeiLvFenZi / BenQiQianFeiFenMu) * 100), 2, MidpointRounding.AwayFromZero) + "%";
                    }
                    else
                    {
                        item.BenQiShouFeiLv = "0.00%";
                        item.ShiShiShouFeiLv = "0.00%";
                    }
                }
                if (ShowType == 0)
                {
                    list = list.Where(p => p.MonthLishiShouBenqi > 0 || p.MonthBenqiShouLishi > 0 || p.MonthBenqiShouBenqi > 0 || p.MonthBenqiYuShou > 0 || p.MonthBenqiChongXiao > 0 || p.MonthZhiHouShouBenqi > 0 || p.BenQiQianFei > 0).ToArray();
                }
                dg.rows = list;
                var footer = new List<ChargeSummaryShouFeiLvAnalysis>();
                var footer_item = new ChargeSummaryShouFeiLvAnalysis();
                footer_item.FullName = "合计";
                footer_item.RoomName = "";
                footer_item.Name = "";
                footer_item.MonthLishiShouBenqi = list.Sum(p =>
                {
                    return p.MonthLishiShouBenqi > 0 ? p.MonthLishiShouBenqi : 0;
                });
                footer_item.MonthBenqiShouLishi = list.Sum(p =>
                {
                    return p.MonthBenqiShouLishi > 0 ? p.MonthBenqiShouLishi : 0;
                });
                footer_item.MonthBenqiShouBenqi = list.Sum(p =>
                {
                    return p.MonthBenqiShouBenqi > 0 ? p.MonthBenqiShouBenqi : 0;
                });
                footer_item.MonthBenqiYuShou = list.Sum(p =>
                {
                    return p.MonthBenqiYuShou > 0 ? p.MonthBenqiYuShou : 0;
                });
                footer_item.MonthBenqiChongXiao = list.Sum(p =>
                {
                    return p.MonthBenqiChongXiao > 0 ? p.MonthBenqiChongXiao : 0;
                });
                footer_item.MonthZhiHouShouBenqi = list.Sum(p =>
                {
                    return p.MonthZhiHouShouBenqi > 0 ? p.MonthZhiHouShouBenqi : 0;
                });
                footer_item.BenQiQianFei = list.Sum(p =>
                {
                    return p.BenQiQianFei > 0 ? p.BenQiQianFei : 0;
                });
                footer_item.BenQiShouFeiLv = "--";
                footer_item.ShiShiShouFeiLv = "--";
                footer.Add(footer_item);
                dg.footer = footer;
                return dg;
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("HandlerHelper.cs", "loadshoufeilvquanzebyroom", ex);
                return new Foresight.DataAccess.Ui.DataGrid();
            }
        }
        public static Foresight.DataAccess.Ui.DataGrid loadshoufeilvshoufubyroom(long startRowIndex, int pageSize, int CompanyID, List<int> RoomIDList, List<int> ProjectIDList, DateTime StartTime, DateTime EndTime, List<int> ChargeIDList, int ShowType, bool canexport = false)
        {
            try
            {
                Foresight.DataAccess.Ui.DataGrid dg = ChargeSummaryShouFeiLvAnalysis.GetChargeSummaryShouFeiLvAnalysisByRoom(ProjectIDList, RoomIDList, StartTime, EndTime, CompanyID, ChargeIDList, "order by DefaultOrder asc", startRowIndex, pageSize, ShowType, canexport: canexport);
                var list = dg.rows as ChargeSummaryShouFeiLvAnalysis[];
                if (list.Length == 0)
                {
                    return new Foresight.DataAccess.Ui.DataGrid();
                }
                var fee_list = RoomFeeAnalysis.GetRoomFeeAnalysisListByRoomID(RoomIDList, ProjectIDList, DateTime.MinValue, DateTime.MinValue, ChargeIDList.ToArray(), true, UserID: WebUtil.GetUser(HttpContext.Current).UserID);
                var history_list = ViewRoomFeeHistoryDetail.GetViewRoomFeeHistoryDetailList(RoomIDList, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, ProjectIDList: ProjectIDList, ChargeIDList: ChargeIDList, UserID: WebUtil.GetUser(HttpContext.Current).UserID, requireRelationRoom: true);
                //本期欠费
                var ViewRoomFeeDetailList_BeiQiQianFei_Dic = RoomFeeAnalysis.GetRoomFeeAnalysisDictionary(fee_list, StartTime, EndTime);
                //本期实收
                var ViewRoomFeeHistoryDetailList_BenQiShiShou_Dic = ViewRoomFeeHistoryDetail.GetViewRoomFeeHistoryDetailDictionary(history_list, StartTime, EndTime);
                DateTime HistoryEndTime = DateTime.MinValue;
                if (StartTime > DateTime.MinValue)
                {
                    HistoryEndTime = StartTime.AddDays(-1);
                }
                var ViewRoomFeeDetailList_LiShiQianFei_Dic = new List<Dictionary<string, object>>();
                var ViewRoomFeeHistoryDetailList_LeiJiShiShou_Dic = new List<Dictionary<string, object>>();
                if (HistoryEndTime > DateTime.MinValue)
                {
                    //历史欠费
                    ViewRoomFeeDetailList_LiShiQianFei_Dic = RoomFeeAnalysis.GetRoomFeeAnalysisDictionary(fee_list, DateTime.MinValue, HistoryEndTime);
                    //累计实收
                    ViewRoomFeeHistoryDetailList_LeiJiShiShou_Dic = ViewRoomFeeHistoryDetail.GetViewRoomFeeHistoryDetailDictionary(history_list, DateTime.MinValue, HistoryEndTime);
                }
                foreach (var item in list)
                {
                    var child_ViewRoomFeeDetailList_BeiQiQianFei_Dic = ViewRoomFeeDetailList_BeiQiQianFei_Dic.Where(p => Convert.ToInt32(p["RoomID"]) == item.RoomID).ToArray();
                    var child_ViewRoomFeeHistoryDetailList_BenQiShiShou_Dic = ViewRoomFeeHistoryDetailList_BenQiShiShou_Dic.Where(p => Convert.ToInt32(p["RoomID"]) == item.RoomID).ToList();

                    var child_ViewRoomFeeDetailList_LiShiQianFei_Dic = ViewRoomFeeDetailList_LiShiQianFei_Dic.Where(p => Convert.ToInt32(p["RoomID"]) == item.RoomID);

                    var child_ViewRoomFeeHistoryDetailList_LeiJinShiShou = ViewRoomFeeHistoryDetailList_LeiJiShiShou_Dic.Where(p => Convert.ToInt32(p["RoomID"]) == item.RoomID).ToList();
                    //本期实收
                    item.ShouFuZhiBenQiShiShou = child_ViewRoomFeeHistoryDetailList_BenQiShiShou_Dic.Sum(q => Convert.ToDecimal(q["MonthTotalCost"]));
                    //本期减免
                    item.ShouFuZhiBenQiJianMian = child_ViewRoomFeeHistoryDetailList_BenQiShiShou_Dic.Where(p => Convert.ToDecimal(p["MonthDiscountCost"]) > 0).Sum(q => Convert.ToDecimal(q["MonthDiscountCost"]));
                    //本期欠费
                    item.ShouFuZhiBenQiQianFei = child_ViewRoomFeeDetailList_BeiQiQianFei_Dic.Sum(q => Convert.ToDecimal(q["TotalFinalCost"]));
                    //本期应收
                    decimal ShouFuZhiBenQiYingShou_1 = child_ViewRoomFeeDetailList_BeiQiQianFei_Dic.Sum(q => Convert.ToDecimal(q["TotalCost"]));
                    decimal ShouFuZhiBenQiYingShou_2 = ViewRoomFeeHistoryBase.GetViewRoomFeeHistoryTotalCost(my_history_dic_list: child_ViewRoomFeeHistoryDetailList_BenQiShiShou_Dic);
                    item.ShouFuZhiBenQiYingShou = ShouFuZhiBenQiYingShou_1 + ShouFuZhiBenQiYingShou_2;
                    //累计实收
                    item.ShouFuZhiLeiJiShiShou = child_ViewRoomFeeHistoryDetailList_LeiJinShiShou.Sum(q => Convert.ToDecimal(q["MonthTotalCost"]));
                    item.ShouFuZhiLeiJiShiShou += item.ShouFuZhiBenQiShiShou;
                    //累计减免
                    item.ShouFuZhiLiShiJianMian = child_ViewRoomFeeHistoryDetailList_LeiJinShiShou.Where(p => Convert.ToDecimal(p["MonthDiscountCost"]) > 0).Sum(q => Convert.ToDecimal(q["MonthDiscountCost"]));
                    item.ShouFuZhiLiShiJianMian += item.ShouFuZhiBenQiJianMian;
                    //累计欠费
                    item.ShouFuZhiLiShiQianFei = child_ViewRoomFeeDetailList_LiShiQianFei_Dic.Sum(q => Convert.ToDecimal(q["TotalFinalCost"]));
                    item.ShouFuZhiLiShiQianFei = item.ShouFuZhiLiShiQianFei + item.ShouFuZhiBenQiQianFei;
                    //累计应收
                    decimal ShouFuZhiLeiJiYingShou_1 = child_ViewRoomFeeDetailList_LiShiQianFei_Dic.Sum(q => Convert.ToDecimal(q["TotalCost"]));
                    decimal ShouFuZhiLeiJiYingShou_2 = ViewRoomFeeHistoryBase.GetViewRoomFeeHistoryTotalCost(my_history_dic_list: child_ViewRoomFeeHistoryDetailList_LeiJinShiShou);
                    item.ShouFuZhiLeiJiYingShou = ShouFuZhiLeiJiYingShou_1 + ShouFuZhiLeiJiYingShou_2 + item.ShouFuZhiBenQiYingShou;
                    if (item.ShouFuZhiBenQiYingShou > 0)
                    {
                        item.ShouFuZhiBenQiShouFeiLv = Math.Round((decimal)(((item.ShouFuZhiBenQiShiShou + item.ShouFuZhiBenQiJianMian) / item.ShouFuZhiBenQiYingShou) * 100), 2, MidpointRounding.AwayFromZero) + "%";
                    }
                    else
                    {
                        item.ShouFuZhiBenQiShouFeiLv = "0.00%";
                    }
                    if (item.ShouFuZhiLeiJiYingShou > 0)
                    {
                        item.ShouFuZhiLeiJiShouFeiLv = Math.Round((decimal)(((item.ShouFuZhiLeiJiShiShou + item.ShouFuZhiLiShiJianMian) / item.ShouFuZhiLeiJiYingShou) * 100), 2, MidpointRounding.AwayFromZero) + "%";
                    }
                    else
                    {
                        item.ShouFuZhiLeiJiShouFeiLv = "0.00%";
                    }
                }
                if (ShowType == 0)
                {
                    list = list.Where(p => p.ShouFuZhiBenQiYingShou > 0 || p.ShouFuZhiLeiJiYingShou > 0 || p.ShouFuZhiBenQiShiShou > 0 || p.ShouFuZhiBenQiQianFei > 0 || p.ShouFuZhiLiShiQianFei > 0).ToArray();
                }
                dg.rows = list;
                var footer = new List<ChargeSummaryShouFeiLvAnalysis>();
                var footer_item = new ChargeSummaryShouFeiLvAnalysis();
                footer_item.FullName = "合计";
                footer_item.RoomName = "";
                footer_item.Name = "";
                footer_item.ShouFuZhiBenQiYingShou = list.Sum(p =>
                {
                    return p.ShouFuZhiBenQiYingShou > 0 ? p.ShouFuZhiBenQiYingShou : 0;
                });
                footer_item.ShouFuZhiBenQiShiShou = list.Sum(p =>
                {
                    return p.ShouFuZhiBenQiShiShou > 0 ? p.ShouFuZhiBenQiShiShou : 0;
                });
                footer_item.ShouFuZhiBenQiQianFei = list.Sum(p =>
                {
                    return p.ShouFuZhiBenQiQianFei > 0 ? p.ShouFuZhiBenQiQianFei : 0;
                });
                footer_item.ShouFuZhiLeiJiYingShou = list.Sum(p =>
                {
                    return p.ShouFuZhiLeiJiYingShou > 0 ? p.ShouFuZhiLeiJiYingShou : 0;
                });
                footer_item.ShouFuZhiLeiJiShiShou = list.Sum(p =>
                {
                    return p.ShouFuZhiLeiJiShiShou > 0 ? p.ShouFuZhiLeiJiShiShou : 0;
                });
                footer_item.ShouFuZhiLiShiQianFei = list.Sum(p =>
                {
                    return p.ShouFuZhiLiShiQianFei > 0 ? p.ShouFuZhiLiShiQianFei : 0;
                });
                footer_item.ShouFuZhiBenQiJianMian = list.Sum(p =>
                {
                    return p.ShouFuZhiBenQiJianMian > 0 ? p.ShouFuZhiBenQiJianMian : 0;
                });
                footer_item.ShouFuZhiLiShiJianMian = list.Sum(p =>
                {
                    return p.ShouFuZhiLiShiJianMian > 0 ? p.ShouFuZhiLiShiJianMian : 0;
                });
                footer_item.ShouFuZhiBenQiShouFeiLv = "--";
                footer_item.ShouFuZhiLeiJiShouFeiLv = "--";
                footer.Add(footer_item);
                dg.footer = footer;
                return dg;
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("HandlerHelper.cs", "loadshoufeilvshoufubyroom", ex);
                return new Foresight.DataAccess.Ui.DataGrid();
            }
        }
        public static Foresight.DataAccess.Ui.DataGrid loadshoufeilvquanzebyproject(long startRowIndex, int pageSize, int CompanyID, List<int> RoomIDList, List<int> ProjectIDList, DateTime StartTime, DateTime EndTime, List<int> ChargeIDList, int ShowType, bool IsQuanZe, bool IsAnalysisQuery = false, bool canexport = false, int ChargeTypeID = -1)
        {
            try
            {
                if (!IsQuanZe)
                {
                    return loadshoufeilvshoufubyproject(startRowIndex, pageSize, CompanyID, RoomIDList, ProjectIDList, StartTime, EndTime, ChargeIDList, ShowType, canexport: canexport, ChargeTypeID: ChargeTypeID);
                }
                var dg = ChargeSummaryShouFeiLvAnalysis.GetChargeSummaryShouFeiLvAnalysisByProject(ProjectIDList, RoomIDList, StartTime, EndTime, CompanyID, ChargeIDList, "order by DefaultOrder asc", startRowIndex, pageSize, ShowType, canexport: canexport);
                var list = dg.rows as ChargeSummaryShouFeiLvAnalysis[];
                if (list.Length == 0)
                {
                    return new Foresight.DataAccess.Ui.DataGrid();
                }
                var viewRoomFeeList = RoomFeeAnalysis.GetRoomFeeAnalysisListByRoomID(RoomIDList, ProjectIDList, StartTime, EndTime, ChargeIDList.ToArray(), true, UserID: WebUtil.GetUser(HttpContext.Current).UserID, IsAnalysisQuery: IsAnalysisQuery);
                int[] ChargeTypeIDList = new int[] { };
                if (ChargeTypeID > -1)
                {
                    ChargeTypeIDList = new int[] { ChargeTypeID };
                }
                var viewRoomFeeHistoryList = ViewRoomFeeHistoryDetail.GetViewRoomFeeHistoryDetail2List(RoomIDList, ProjectIDList, StartTime, EndTime, ChargeIDList, UserID: WebUtil.GetUser(HttpContext.Current).UserID, IsAnalysisQuery: IsAnalysisQuery, ChargeTypeIDList: ChargeTypeIDList);
                foreach (var item in list)
                {
                    var child_historyfee_list = viewRoomFeeHistoryList.Where(p => (p.FinalAllParentID == null ? "" : p.FinalAllParentID).Contains("," + item.RoomID + ","));
                    var child_fee_list = viewRoomFeeList.Where(p => p.FinalAllParentID.Contains("," + item.RoomID + ",")).ToArray();
                    item.MonthLishiShouBenqi_ShiShou = child_historyfee_list.Sum(q => q.LishiShouBenqi_ShiShou);
                    item.MonthLishiShouBenqi_ChongDi = child_historyfee_list.Sum(q => q.LishiShouBenqi_ChongDi);
                    item.MonthLishiShouBenqi_JianMian = child_historyfee_list.Sum(q => q.LishiShouBenqi_JianMian);
                    item.MonthLishiShouBenqi = child_historyfee_list.Sum(q => q.LishiShouBenqi);

                    item.MonthBenqiShouLishi_ShiShou = child_historyfee_list.Sum(q => q.BenqiShouLishi_ShiShou);
                    item.MonthBenqiShouLishi_ChongDi = child_historyfee_list.Sum(q => q.BenqiShouLishi_ChongDi);
                    item.MonthBenqiShouLishi_JianMian = child_historyfee_list.Sum(q => q.BenqiShouLishi_JianMian);
                    item.MonthBenqiShouLishi = child_historyfee_list.Sum(q => q.BenqiShouLishi);

                    item.MonthBenqiShouBenqi_ShiShou = child_historyfee_list.Sum(q => q.BenqiShouBenqi_ShiShou);
                    item.MonthBenqiShouBenqi_ChongDi = child_historyfee_list.Sum(q => q.BenqiShouBenqi_ChongDi);
                    item.MonthBenqiShouBenqi_JianMian = child_historyfee_list.Sum(q => q.BenqiShouBenqi_JianMian);
                    item.MonthBenqiShouBenqi = child_historyfee_list.Sum(q => q.BenqiShouBenqi);

                    item.MonthBenqiYuShou_ShiShou = child_historyfee_list.Sum(q => q.BenqiYuShou_ShiShou);
                    item.MonthBenqiYuShou_ChongDi = child_historyfee_list.Sum(q => q.BenqiYuShou_ChongDi);
                    item.MonthBenqiYuShou_JianMian = child_historyfee_list.Sum(q => q.BenqiYuShou_JianMian);
                    item.MonthBenqiYuShou = child_historyfee_list.Sum(q => q.BenqiYuShou);

                    item.MonthZhiHouShouBenqi_ShiShou = child_historyfee_list.Sum(q => q.ZhiHouShouBenqi_ShiShou);
                    item.MonthZhiHouShouBenqi_ChongDi = child_historyfee_list.Sum(q => q.ZhiHouShouBenqi_ChongDi);
                    item.MonthZhiHouShouBenqi_JianMian = child_historyfee_list.Sum(q => q.ZhiHouShouBenqi_JianMian);
                    item.MonthZhiHouShouBenqi = child_historyfee_list.Sum(q => q.ZhiHouShouBenqi);

                    item.MonthBenqiChongXiao_ShiShou = child_historyfee_list.Sum(q => q.BenqiChongXiao_ShiShou);
                    item.MonthBenqiChongXiao_ChongDi = child_historyfee_list.Sum(q => q.BenqiChongXiao_ChongDi);
                    item.MonthBenqiChongXiao_JianMian = child_historyfee_list.Sum(q => q.BenqiChongXiao_JianMian);
                    item.MonthBenqiChongXiao = child_historyfee_list.Sum(q => q.BenqiChongXiao);

                    item.BenQiDiscount = child_historyfee_list.Sum(q => q.MonthDiscountCost);
                    item.BenQiQianFei = child_fee_list.Sum(q => q.TotalFinalCost);
                    //本期应收
                    decimal MonthBenQiYingShou_1 = child_fee_list.Sum(q => q.TotalCost);
                    decimal MonthBenQiYingShou_2 = ViewRoomFeeHistoryBase.GetViewRoomFeeHistoryTotalCost(my_history_list: child_historyfee_list.ToArray());
                    item.MonthBenQiYingShou = MonthBenQiYingShou_1 + MonthBenQiYingShou_2;
                    decimal BenQiQianFeiFenMu = item.MonthBenQiYingShou;
                    if (BenQiQianFeiFenMu > 0)
                    {
                        decimal BenQiQianFeiFenZi = item.MonthLishiShouBenqi + item.MonthBenqiShouBenqi;
                        item.BenQiShouFeiLv = Math.Round((decimal)((BenQiQianFeiFenZi / BenQiQianFeiFenMu) * 100), 2, MidpointRounding.AwayFromZero) + "%";
                        decimal ShiShiShouFeiLvFenZi = item.MonthLishiShouBenqi + item.MonthBenqiShouBenqi + item.MonthZhiHouShouBenqi;
                        item.ShiShiShouFeiLv = Math.Round((decimal)((ShiShiShouFeiLvFenZi / BenQiQianFeiFenMu) * 100), 2, MidpointRounding.AwayFromZero) + "%";
                    }
                    else
                    {
                        item.BenQiShouFeiLv = "0.00%";
                        item.ShiShiShouFeiLv = "0.00%";
                    }
                }
                if (ShowType == 0)
                {
                    list = list.Where(p => p.MonthLishiShouBenqi > 0 || p.MonthBenqiShouLishi > 0 || p.MonthBenqiShouBenqi > 0 || p.MonthBenqiYuShou > 0 || p.MonthBenqiChongXiao > 0 || p.MonthZhiHouShouBenqi > 0 || p.BenQiQianFei > 0).ToArray();
                }
                dg.rows = list;
                var footer = new List<ChargeSummaryShouFeiLvAnalysis>();
                var footer_item = new ChargeSummaryShouFeiLvAnalysis();
                footer_item.FullName = "合计";
                footer_item.RoomName = "";
                footer_item.Name = "";
                footer_item.MonthLishiShouBenqi = list.Sum(p =>
                {
                    return p.MonthLishiShouBenqi > 0 ? p.MonthLishiShouBenqi : 0;
                });
                footer_item.MonthBenqiShouLishi = list.Sum(p =>
                {
                    return p.MonthBenqiShouLishi > 0 ? p.MonthBenqiShouLishi : 0;
                });
                footer_item.MonthBenqiShouBenqi = list.Sum(p =>
                {
                    return p.MonthBenqiShouBenqi > 0 ? p.MonthBenqiShouBenqi : 0;
                });
                footer_item.MonthBenqiYuShou = list.Sum(p =>
                {
                    return p.MonthBenqiYuShou > 0 ? p.MonthBenqiYuShou : 0;
                });
                footer_item.MonthBenqiChongXiao = list.Sum(p =>
                {
                    return p.MonthBenqiChongXiao > 0 ? p.MonthBenqiChongXiao : 0;
                });
                footer_item.MonthZhiHouShouBenqi = list.Sum(p =>
                {
                    return p.MonthZhiHouShouBenqi > 0 ? p.MonthZhiHouShouBenqi : 0;
                });
                footer_item.BenQiQianFei = list.Sum(p =>
                {
                    return p.BenQiQianFei > 0 ? p.BenQiQianFei : 0;
                });
                footer_item.BenQiShouFeiLv = "--";
                footer_item.ShiShiShouFeiLv = "--";
                footer.Add(footer_item);
                dg.footer = footer;
                return dg;
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("HandlerHelper.cs", "loadshoufeilvquanzebyproject", ex);
                return new Foresight.DataAccess.Ui.DataGrid();
            }
        }
        public static Foresight.DataAccess.Ui.DataGrid loadshoufeilvshoufubyproject(long startRowIndex, int pageSize, int CompanyID, List<int> RoomIDList, List<int> ProjectIDList, DateTime StartTime, DateTime EndTime, List<int> ChargeIDList, int ShowType, bool canexport = false, int ChargeTypeID = -1)
        {
            try
            {
                var dg = ChargeSummaryShouFeiLvAnalysis.GetChargeSummaryShouFeiLvAnalysisByProject(ProjectIDList, RoomIDList, StartTime, EndTime, CompanyID, ChargeIDList, "order by DefaultOrder asc", startRowIndex, pageSize, ShowType, canexport: canexport);
                var list = dg.rows as ChargeSummaryShouFeiLvAnalysis[];
                if (list.Length == 0)
                {
                    return new Foresight.DataAccess.Ui.DataGrid();
                }
                var fee_list = RoomFeeAnalysis.GetRoomFeeAnalysisListByRoomID(RoomIDList, ProjectIDList, DateTime.MinValue, DateTime.MinValue, ChargeIDList.ToArray(), true, UserID: WebUtil.GetUser(HttpContext.Current).UserID);
                var history_list = ViewRoomFeeHistoryDetail.GetViewRoomFeeHistoryDetailList(RoomIDList, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, ProjectIDList: ProjectIDList, ChargeIDList: ChargeIDList, UserID: WebUtil.GetUser(HttpContext.Current).UserID, ChargeTypeID: ChargeTypeID, requireRelationRoom: true);
                //本期欠费
                var ViewRoomFeeDetailList_BenQiQianFei_Dic = RoomFeeAnalysis.GetRoomFeeAnalysisDictionary(fee_list, StartTime, EndTime);
                //本期实收
                var ViewRoomFeeHistoryDetailList_BenQiShiShou_Dic = ViewRoomFeeHistoryDetail.GetViewRoomFeeHistoryDetailDictionary(history_list, StartTime, EndTime);
                DateTime HistoryEndTime = DateTime.MinValue;
                if (StartTime > DateTime.MinValue)
                {
                    HistoryEndTime = StartTime.AddDays(-1);
                }
                var ViewRoomFeeDetailList_LiShiQianFei_Dic = new List<Dictionary<string, object>>();
                var ViewRoomFeeHistoryDetailList_LeiJiShiShou_Dic = new List<Dictionary<string, object>>();
                if (HistoryEndTime > DateTime.MinValue)
                {
                    //历史欠费
                    ViewRoomFeeDetailList_LiShiQianFei_Dic = RoomFeeAnalysis.GetRoomFeeAnalysisDictionary(fee_list, DateTime.MinValue, HistoryEndTime);
                    //累计实收
                    ViewRoomFeeHistoryDetailList_LeiJiShiShou_Dic = ViewRoomFeeHistoryDetail.GetViewRoomFeeHistoryDetailDictionary(history_list, DateTime.MinValue, HistoryEndTime);
                }
                foreach (var item in list)
                {
                    var child_ViewRoomFeeDetailList_BenQiQianFei_Dic = ViewRoomFeeDetailList_BenQiQianFei_Dic.Where(p => (p["FinalAllParentID"] == null ? "" : p["FinalAllParentID"].ToString()).Contains("," + item.RoomID + ",")).ToArray();

                    var child_ViewRoomFeeHistoryDetailList_BenQiShiShou_Dic = ViewRoomFeeHistoryDetailList_BenQiShiShou_Dic.Where(p => (p["FinalAllParentID"] == null ? "" : p["FinalAllParentID"].ToString()).Contains("," + item.RoomID + ",")).ToList();

                    var child_ViewRoomFeeDetailList_LiShiQianFei_Dic = ViewRoomFeeDetailList_LiShiQianFei_Dic.Where(p => (p["FinalAllParentID"] == null ? "" : p["FinalAllParentID"].ToString()).Contains("," + item.RoomID + ",")).ToArray();

                    var child_ViewRoomFeeHistoryDetailList_LeiJiShiShou = ViewRoomFeeHistoryDetailList_LeiJiShiShou_Dic.Where(p => (p["FinalAllParentID"] == null ? "" : p["FinalAllParentID"].ToString()).Contains("," + item.RoomID + ","));
                    //本期实收
                    item.ShouFuZhiBenQiShiShou = child_ViewRoomFeeHistoryDetailList_BenQiShiShou_Dic.Where(p => Convert.ToDecimal(p["MonthTotalCost"]) > 0).Sum(q => Convert.ToDecimal(q["MonthTotalCost"]));
                    //本期减免
                    item.ShouFuZhiBenQiJianMian = child_ViewRoomFeeHistoryDetailList_BenQiShiShou_Dic.Where(p => Convert.ToDecimal(p["MonthDiscountCost"]) > 0).Sum(q => Convert.ToDecimal(q["MonthDiscountCost"]));
                    //本期欠费
                    item.ShouFuZhiBenQiQianFei = child_ViewRoomFeeDetailList_BenQiQianFei_Dic.Where(p => Convert.ToDecimal(p["TotalFinalCost"]) > 0).Sum(q => Convert.ToDecimal(q["TotalFinalCost"]));
                    //本期应收
                    decimal ShouFuZhiBenQiYingShou_1 = child_ViewRoomFeeDetailList_BenQiQianFei_Dic.Where(p => Convert.ToDecimal(p["TotalCost"]) > 0).Sum(q => Convert.ToDecimal(q["TotalCost"]));
                    decimal ShouFuZhiBenQiYingShou_2 = ViewRoomFeeHistoryBase.GetViewRoomFeeHistoryTotalCost(my_history_dic_list: child_ViewRoomFeeHistoryDetailList_BenQiShiShou_Dic);
                    item.ShouFuZhiBenQiYingShou = ShouFuZhiBenQiYingShou_1 + ShouFuZhiBenQiYingShou_2;
                    //累计实收
                    item.ShouFuZhiLeiJiShiShou = child_ViewRoomFeeHistoryDetailList_LeiJiShiShou.Where(p => Convert.ToDecimal(p["MonthTotalCost"]) > 0).Sum(q => Convert.ToDecimal(q["MonthTotalCost"]));
                    item.ShouFuZhiLeiJiShiShou += item.ShouFuZhiBenQiShiShou;
                    //累计减免
                    item.ShouFuZhiLiShiJianMian = child_ViewRoomFeeHistoryDetailList_LeiJiShiShou.Where(p => Convert.ToDecimal(p["MonthDiscountCost"]) > 0).Sum(q => Convert.ToDecimal(q["MonthDiscountCost"]));
                    item.ShouFuZhiLiShiJianMian += item.ShouFuZhiBenQiJianMian;
                    //累计欠费
                    item.ShouFuZhiLiShiQianFei = child_ViewRoomFeeDetailList_LiShiQianFei_Dic.Where(p => Convert.ToDecimal(p["TotalFinalCost"]) > 0).Sum(q => Convert.ToDecimal(q["TotalFinalCost"]));
                    item.ShouFuZhiLiShiQianFei = item.ShouFuZhiLiShiQianFei + item.ShouFuZhiBenQiQianFei;
                    //累计应收
                    decimal ShouFuZhiLeiJiYingShou_1 = child_ViewRoomFeeDetailList_LiShiQianFei_Dic.Where(p => Convert.ToDecimal(p["TotalCost"]) > 0).Sum(q => Convert.ToDecimal(q["TotalCost"]));
                    decimal ShouFuZhiLeiJiYingShou_2 = child_ViewRoomFeeHistoryDetailList_LeiJiShiShou.Where(p => Convert.ToDecimal(p["TotalCost"]) > 0).Sum(q => Convert.ToDecimal(q["TotalCost"]));
                    item.ShouFuZhiLeiJiYingShou = ShouFuZhiLeiJiYingShou_1 + ShouFuZhiLeiJiYingShou_2 + item.ShouFuZhiBenQiYingShou;
                    if (item.ShouFuZhiBenQiYingShou > 0)
                    {
                        item.ShouFuZhiBenQiShouFeiLv = Math.Round((decimal)(((item.ShouFuZhiBenQiShiShou + item.ShouFuZhiBenQiJianMian) / item.ShouFuZhiBenQiYingShou) * 100), 2, MidpointRounding.AwayFromZero) + "%";
                    }
                    else
                    {
                        item.ShouFuZhiBenQiShouFeiLv = "0.00%";
                    }
                    if (item.ShouFuZhiLeiJiYingShou > 0)
                    {
                        item.ShouFuZhiLeiJiShouFeiLv = Math.Round((decimal)(((item.ShouFuZhiLeiJiShiShou + item.ShouFuZhiLiShiJianMian) / item.ShouFuZhiLeiJiYingShou) * 100), 2, MidpointRounding.AwayFromZero) + "%";
                    }
                    else
                    {
                        item.ShouFuZhiLeiJiShouFeiLv = "0.00%";
                    }
                }
                if (ShowType == 0)
                {
                    list = list.Where(p => p.ShouFuZhiBenQiYingShou > 0 || p.ShouFuZhiLeiJiYingShou > 0 || p.ShouFuZhiBenQiShiShou > 0 || p.ShouFuZhiBenQiQianFei > 0 || p.ShouFuZhiLiShiQianFei > 0).ToArray();
                }
                dg.rows = list;
                var footer = new List<ChargeSummaryShouFeiLvAnalysis>();
                var footer_item = new ChargeSummaryShouFeiLvAnalysis();
                footer_item.FullName = "合计";
                footer_item.RoomName = "";
                footer_item.Name = "";
                footer_item.ShouFuZhiBenQiYingShou = list.Sum(p =>
                {
                    return p.ShouFuZhiBenQiYingShou > 0 ? p.ShouFuZhiBenQiYingShou : 0;
                });
                footer_item.ShouFuZhiBenQiShiShou = list.Sum(p =>
                {
                    return p.ShouFuZhiBenQiShiShou > 0 ? p.ShouFuZhiBenQiShiShou : 0;
                });
                footer_item.ShouFuZhiBenQiQianFei = list.Sum(p =>
                {
                    return p.ShouFuZhiBenQiQianFei > 0 ? p.ShouFuZhiBenQiQianFei : 0;
                });
                footer_item.ShouFuZhiLeiJiYingShou = list.Sum(p =>
                {
                    return p.ShouFuZhiLeiJiYingShou > 0 ? p.ShouFuZhiLeiJiYingShou : 0;
                });
                footer_item.ShouFuZhiLeiJiShiShou = list.Sum(p =>
                {
                    return p.ShouFuZhiLeiJiShiShou > 0 ? p.ShouFuZhiLeiJiShiShou : 0;
                });
                footer_item.ShouFuZhiLiShiQianFei = list.Sum(p =>
                {
                    return p.ShouFuZhiLiShiQianFei > 0 ? p.ShouFuZhiLiShiQianFei : 0;
                });
                footer_item.ShouFuZhiBenQiJianMian = list.Sum(p =>
                {
                    return p.ShouFuZhiBenQiJianMian > 0 ? p.ShouFuZhiBenQiJianMian : 0;
                });
                footer_item.ShouFuZhiLiShiJianMian = list.Sum(p =>
                {
                    return p.ShouFuZhiLiShiJianMian > 0 ? p.ShouFuZhiLiShiJianMian : 0;
                });
                footer_item.MonthBenQiYingShou = list.Sum(p =>
                {
                    return p.MonthBenQiYingShou > 0 ? p.MonthBenQiYingShou : 0;
                });
                footer_item.MonthZhiHouShouBenqi = list.Sum(p =>
                {
                    return p.MonthZhiHouShouBenqi > 0 ? p.MonthZhiHouShouBenqi : 0;
                });
                footer_item.MonthLishiShouBenqi = list.Sum(p =>
                {
                    return p.MonthLishiShouBenqi > 0 ? p.MonthLishiShouBenqi : 0;
                });
                footer_item.MonthBenqiShouBenqi = list.Sum(p =>
                {
                    return p.MonthBenqiShouBenqi > 0 ? p.MonthBenqiShouBenqi : 0;
                });
                footer_item.MonthBenqiShouLishi = list.Sum(p =>
                {
                    return p.MonthBenqiShouLishi > 0 ? p.MonthBenqiShouLishi : 0;
                });
                footer_item.MonthBenqiYuShou = list.Sum(p =>
                {
                    return p.MonthBenqiYuShou > 0 ? p.MonthBenqiYuShou : 0;
                });
                footer_item.ShouFuZhiBenQiShouFeiLv = "--";
                footer_item.ShouFuZhiLeiJiShouFeiLv = "--";
                footer.Add(footer_item);
                dg.footer = footer;
                return dg;
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("HandlerHelper.cs", "loadshoufeilvshoufubyproject", ex);
                return new Foresight.DataAccess.Ui.DataGrid();
            }
        }
        public static Foresight.DataAccess.Ui.DataGrid loadshoufeilvquanzebycharge(long startRowIndex, int pageSize, int CompanyID, List<int> RoomIDList, List<int> ProjectIDList, DateTime StartTime, DateTime EndTime, List<int> ChargeIDList, int ShowType, bool IsQuanZe, string RoomType, int RoomID, bool IsAnalysisQuery = false, bool IsShouRuZhiChuAnalysis = false, bool canexport = false)
        {
            try
            {
                if (!IsQuanZe)
                {
                    return loadshoufeilvshoufubycharge(startRowIndex, pageSize, CompanyID, RoomIDList, ProjectIDList, StartTime, EndTime, ChargeIDList, ShowType, RoomType, RoomID);
                }
                var dg = ChargeSummaryShouFeiLvAnalysis.GetChargeSummaryShouFeiLvAnalysisByChargeName(ProjectIDList, RoomIDList, StartTime, EndTime, CompanyID, ChargeIDList, RoomID, RoomType, ShowType);
                var list = dg.rows as ChargeSummaryShouFeiLvAnalysis[];
                if (list.Length == 0)
                {
                    return new Foresight.DataAccess.Ui.DataGrid();
                }
                var viewRoomFeeList = RoomFeeAnalysis.GetRoomFeeAnalysisListByRoomID(RoomIDList, ProjectIDList, StartTime, EndTime, ChargeIDList.ToArray(), true, UserID: WebUtil.GetUser(HttpContext.Current).UserID, IsAnalysisQuery: IsAnalysisQuery);
                var viewRoomFeeHistoryList = ViewRoomFeeHistoryDetail.GetViewRoomFeeHistoryDetail2List(RoomIDList, ProjectIDList, StartTime, EndTime, ChargeIDList, UserID: WebUtil.GetUser(HttpContext.Current).UserID, IsAnalysisQuery: IsAnalysisQuery);
                foreach (var item in list)
                {
                    var child_historyfee_list = viewRoomFeeHistoryList.Where(p => p.ChargeID == item.ChargeID);
                    var child_fee_list = viewRoomFeeList.Where(p => p.ChargeID == item.ChargeID);
                    if (RoomID > 0)
                    {
                        child_historyfee_list = child_historyfee_list.Where(p => ((p.FinalAllParentID == null ? "" : p.FinalAllParentID).Contains("," + RoomID + ",") || p.RoomID == RoomID));
                        child_fee_list = child_fee_list.Where(p => p.FinalAllParentID.Contains("," + RoomID + ",") || p.RoomID == RoomID);
                    }
                    item.MonthLishiShouBenqi_ShiShou = child_historyfee_list.Sum(q => q.LishiShouBenqi_ShiShou);
                    item.MonthLishiShouBenqi_ChongDi = child_historyfee_list.Sum(q => q.LishiShouBenqi_ChongDi);
                    item.MonthLishiShouBenqi_JianMian = child_historyfee_list.Sum(q => q.LishiShouBenqi_JianMian);
                    item.MonthLishiShouBenqi = child_historyfee_list.Sum(q => q.LishiShouBenqi);

                    item.MonthBenqiShouLishi_ShiShou = child_historyfee_list.Sum(q => q.BenqiShouLishi_ShiShou);
                    item.MonthBenqiShouLishi_ChongDi = child_historyfee_list.Sum(q => q.BenqiShouLishi_ChongDi);
                    item.MonthBenqiShouLishi_JianMian = child_historyfee_list.Sum(q => q.BenqiShouLishi_JianMian);
                    item.MonthBenqiShouLishi = child_historyfee_list.Sum(q => q.BenqiShouLishi);

                    item.MonthBenqiShouBenqi_ShiShou = child_historyfee_list.Sum(q => q.BenqiShouBenqi_ShiShou);
                    item.MonthBenqiShouBenqi_ChongDi = child_historyfee_list.Sum(q => q.BenqiShouBenqi_ChongDi);
                    item.MonthBenqiShouBenqi_JianMian = child_historyfee_list.Sum(q => q.BenqiShouBenqi_JianMian);
                    item.MonthBenqiShouBenqi = child_historyfee_list.Sum(q => q.BenqiShouBenqi);

                    item.MonthBenqiYuShou_ShiShou = child_historyfee_list.Sum(q => q.BenqiYuShou_ShiShou);
                    item.MonthBenqiYuShou_ChongDi = child_historyfee_list.Sum(q => q.BenqiYuShou_ChongDi);
                    item.MonthBenqiYuShou_JianMian = child_historyfee_list.Sum(q => q.BenqiYuShou_JianMian);
                    item.MonthBenqiYuShou = child_historyfee_list.Sum(q => q.BenqiYuShou);

                    item.MonthZhiHouShouBenqi_ShiShou = child_historyfee_list.Sum(q => q.ZhiHouShouBenqi_ShiShou);
                    item.MonthZhiHouShouBenqi_ChongDi = child_historyfee_list.Sum(q => q.ZhiHouShouBenqi_ChongDi);
                    item.MonthZhiHouShouBenqi_JianMian = child_historyfee_list.Sum(q => q.ZhiHouShouBenqi_JianMian);
                    item.MonthZhiHouShouBenqi = child_historyfee_list.Sum(q => q.ZhiHouShouBenqi);

                    item.MonthBenqiChongXiao_ShiShou = child_historyfee_list.Sum(q => q.BenqiChongXiao_ShiShou);
                    item.MonthBenqiChongXiao_ChongDi = child_historyfee_list.Sum(q => q.BenqiChongXiao_ChongDi);
                    item.MonthBenqiChongXiao_JianMian = child_historyfee_list.Sum(q => q.BenqiChongXiao_JianMian);
                    item.MonthBenqiChongXiao = child_historyfee_list.Sum(q => q.BenqiChongXiao);

                    item.BenQiDiscount = child_historyfee_list.Sum(q => q.MonthDiscountCost);
                    item.BenQiQianFei = child_fee_list.Sum(q => q.TotalFinalCost);
                    //本期应收
                    decimal MonthBenQiYingShou_1 = child_fee_list.Sum(q => q.TotalCost);
                    decimal MonthBenQiYingShou_2 = ViewRoomFeeHistoryBase.GetViewRoomFeeHistoryTotalCost(my_history_list: child_historyfee_list.ToArray());
                    item.MonthBenQiYingShou = MonthBenQiYingShou_1 + MonthBenQiYingShou_2;
                    decimal BenQiQianFeiFenMu = item.MonthBenQiYingShou;
                    if (BenQiQianFeiFenMu > 0)
                    {
                        decimal BenQiQianFeiFenZi = item.MonthLishiShouBenqi + item.MonthBenqiShouBenqi;
                        item.BenQiShouFeiLv = Math.Round((decimal)((BenQiQianFeiFenZi / BenQiQianFeiFenMu) * 100), 2, MidpointRounding.AwayFromZero) + "%";
                        decimal ShiShiShouFeiLvFenZi = item.MonthLishiShouBenqi + item.MonthBenqiShouBenqi + item.MonthZhiHouShouBenqi;
                        item.ShiShiShouFeiLv = Math.Round((decimal)((ShiShiShouFeiLvFenZi / BenQiQianFeiFenMu) * 100), 2, MidpointRounding.AwayFromZero) + "%";
                    }
                    else
                    {
                        item.BenQiShouFeiLv = "0.00%";
                        item.ShiShiShouFeiLv = "0.00%";
                    }
                }
                if (ShowType == 0)
                {
                    list = list.Where(p => p.MonthLishiShouBenqi > 0 || p.MonthBenqiShouLishi > 0 || p.MonthBenqiShouBenqi > 0 || p.MonthBenqiYuShou > 0 || p.MonthBenqiChongXiao > 0 || p.MonthZhiHouShouBenqi > 0 || p.BenQiQianFei > 0).ToArray();
                }
                if (IsShouRuZhiChuAnalysis)
                {
                    list = list.Where(p => p.MonthBenqiShouBenqi_ShiShou > 0 || p.MonthBenqiShouLishi_ShiShou > 0 || p.MonthBenqiYuShou_ShiShou > 0).ToArray();
                }
                dg.rows = list;
                if (RoomID <= 0)
                {
                    var footer = new List<ChargeSummaryShouFeiLvAnalysis>();
                    var footer_item = new ChargeSummaryShouFeiLvAnalysis();
                    footer_item.FullName = "合计";
                    footer_item.RoomName = "";
                    footer_item.Name = "";
                    footer_item.MonthLishiShouBenqi = list.Sum(p =>
                    {
                        return p.MonthLishiShouBenqi > 0 ? p.MonthLishiShouBenqi : 0;
                    });
                    footer_item.MonthBenqiShouLishi = list.Sum(p =>
                    {
                        return p.MonthBenqiShouLishi > 0 ? p.MonthBenqiShouLishi : 0;
                    });
                    footer_item.MonthBenqiShouBenqi = list.Sum(p =>
                    {
                        return p.MonthBenqiShouBenqi > 0 ? p.MonthBenqiShouBenqi : 0;
                    });
                    footer_item.MonthBenqiYuShou = list.Sum(p =>
                    {
                        return p.MonthBenqiYuShou > 0 ? p.MonthBenqiYuShou : 0;
                    });
                    footer_item.MonthZhiHouShouBenqi = list.Sum(p =>
                    {
                        return p.MonthZhiHouShouBenqi > 0 ? p.MonthZhiHouShouBenqi : 0;
                    });
                    footer_item.MonthBenqiChongXiao = list.Sum(p =>
                    {
                        return p.MonthBenqiChongXiao > 0 ? p.MonthBenqiChongXiao : 0;
                    });
                    footer_item.BenQiQianFei = list.Sum(p =>
                    {
                        return p.BenQiQianFei > 0 ? p.BenQiQianFei : 0;
                    });
                    footer_item.MonthBenqiShouBenqi_ShiShou = list.Sum(p =>
                    {
                        return p.MonthBenqiShouBenqi_ShiShou > 0 ? p.MonthBenqiShouBenqi_ShiShou : 0;
                    });
                    footer_item.MonthBenqiShouLishi_ShiShou = list.Sum(p =>
                    {
                        return p.MonthBenqiShouLishi_ShiShou > 0 ? p.MonthBenqiShouLishi_ShiShou : 0;
                    });
                    footer_item.MonthBenqiYuShou_ShiShou = list.Sum(p =>
                    {
                        return p.MonthBenqiYuShou_ShiShou > 0 ? p.MonthBenqiYuShou_ShiShou : 0;
                    });
                    footer_item.BenQiShouFeiLv = "--";
                    footer_item.ShiShiShouFeiLv = "--";
                    footer.Add(footer_item);
                    dg.footer = footer;
                }
                return dg;
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("HandlerHelper.cs", "loadshoufeilvquanzebycharge", ex);
                return new Foresight.DataAccess.Ui.DataGrid();
            }
        }
        public static Foresight.DataAccess.Ui.DataGrid loadshoufeilvquanzebychargemoneytype(int ProjectID, DateTime StartTime, DateTime EndTime, List<int> ChargeIDList, List<int> ProjectIDList, List<int> RoomIDList)
        {
            try
            {
                var user = WebUtil.GetUser(HttpContext.Current);
                var chargeMoneyList = ChargeMoneyType.GetChargeMoneyTypes().ToArray();
                var viewRoomFeeHistoryList = ViewRoomFeeHistoryDetail.GetViewRoomFeeHistoryDetail2List(RoomIDList, ProjectIDList, StartTime, EndTime, ChargeIDList, UserID: user.UserID, IsAnalysisQuery: true).Where(p => p.FinalAllParentID.Contains("," + ProjectID + ","));
                var dataList = new List<Dictionary<string, object>>();
                var data = new Dictionary<string, object>();
                var childHistoryList1 = new ViewRoomFeeHistoryDetail[] { };
                var childHistoryList2 = new ViewRoomFeeHistoryDetail[] { };
                var viewRoomFeeHistoryRealCostList = viewRoomFeeHistoryList.Where(p => p.ChargeState == 1);
                foreach (var item in chargeMoneyList)
                {
                    childHistoryList1 = viewRoomFeeHistoryRealCostList.Where(p => p.ChageType1 == item.ChargeTypeID).ToArray();
                    childHistoryList2 = viewRoomFeeHistoryRealCostList.Where(p => p.ChageType2 == item.ChargeTypeID).ToArray();
                    data = getShouFeiLvDataByChargeMoneyType(item.ChargeTypeName, item.ChargeTypeID, ProjectID, childHistoryList1, childHistoryList2);
                    if (data != null)
                    {
                        dataList.Add(data);
                    }
                }
                int[] ChargeTypeIDList = chargeMoneyList.Select(p => p.ChargeTypeID).ToArray();
                childHistoryList1 = viewRoomFeeHistoryRealCostList.Where(p => !ChargeTypeIDList.Contains(p.ChageType1) && p.RealMoneyCost1 > 0).ToArray();
                childHistoryList2 = viewRoomFeeHistoryRealCostList.Where(p => !ChargeTypeIDList.Contains(p.ChageType2) && p.RealMoneyCost2 > 0).ToArray();
                data = getShouFeiLvDataByChargeMoneyType("其他", -1, ProjectID, childHistoryList1, childHistoryList2);
                if (data != null)
                {
                    dataList.Add(data);
                }

                childHistoryList1 = viewRoomFeeHistoryList.Where(p => p.Discount > 0).ToArray();
                childHistoryList2 = new ViewRoomFeeHistoryDetail[] { };
                data = getShouFeiLvDataByChargeMoneyType("减免", -2, ProjectID, childHistoryList1, childHistoryList2, isDiscountCost: true);
                if (data != null)
                {
                    dataList.Add(data);
                }

                childHistoryList1 = viewRoomFeeHistoryList.Where(p => p.ChargeState == 4).ToArray();
                childHistoryList2 = new ViewRoomFeeHistoryDetail[] { };
                data = getShouFeiLvDataByChargeMoneyType("冲抵", -3, ProjectID, childHistoryList1, childHistoryList2, IsChongDiCost: true);
                if (data != null)
                {
                    dataList.Add(data);
                }

                var dg = new Foresight.DataAccess.Ui.DataGrid();
                dg.rows = dataList;
                dg.total = dataList.Count;
                dg.page = 1;
                return dg;
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("HandlerHelper.cs", "loadshoufeilvquanzebychargemoneytype", ex);
                return new Foresight.DataAccess.Ui.DataGrid();
            }
        }
        public static Dictionary<string, object> getShouFeiLvDataByChargeMoneyType(string ChargeTypeName, int ChargeTypeID, int ProjectID, ViewRoomFeeHistoryDetail[] childHistoryList1, ViewRoomFeeHistoryDetail[] childHistoryList2, bool isDiscountCost = false, bool IsChongDiCost = false)
        {
            var data = new Dictionary<string, object>();
            data["state"] = string.Empty;
            data["id"] = "ChargeMoneyType_" + ChargeTypeID;
            data["_parentId"] = "Room_" + ProjectID;
            data["Name"] = ChargeTypeName;
            decimal MonthZhiHouShouBenqi = 0;
            decimal MonthLishiShouBenqi = 0;
            decimal MonthBenqiShouBenqi = 0;
            decimal MonthBenqiShouLishi = 0;
            decimal MonthBenqiYuShou = 0;
            if (isDiscountCost)
            {
                MonthZhiHouShouBenqi = childHistoryList1.Sum(q => q.ZhiHouShouBenqi_JianMian);
                MonthLishiShouBenqi = childHistoryList1.Sum(q => q.LishiShouBenqi_JianMian);
                MonthBenqiShouBenqi = childHistoryList1.Sum(q => q.BenqiShouBenqi_JianMian);
                MonthBenqiShouLishi = childHistoryList1.Sum(q => q.BenqiShouLishi_JianMian);
                MonthBenqiYuShou = childHistoryList1.Sum(q => q.BenqiYuShou_JianMian);
            }
            else if (IsChongDiCost)
            {
                MonthZhiHouShouBenqi = childHistoryList1.Sum(q => q.ZhiHouShouBenqi_ChongDi);
                MonthLishiShouBenqi = childHistoryList1.Sum(q => q.LishiShouBenqi_ChongDi);
                MonthBenqiShouBenqi = childHistoryList1.Sum(q => q.BenqiShouBenqi_ChongDi);
                MonthBenqiShouLishi = childHistoryList1.Sum(q => q.BenqiShouLishi_ChongDi);
                MonthBenqiYuShou = childHistoryList1.Sum(q => q.BenqiYuShou_ChongDi);
            }
            else
            {
                decimal MonthZhiHouShouBenqi1 = childHistoryList1.Sum(q => q.ZhiHouShouBenqi_ShiShou_ChargeType1);
                decimal MonthZhiHouShouBenqi2 = childHistoryList2.Sum(q => q.ZhiHouShouBenqi_ShiShou_ChargeType2);
                MonthZhiHouShouBenqi = MonthZhiHouShouBenqi1 + MonthZhiHouShouBenqi2;

                decimal MonthLishiShouBenqi1 = childHistoryList1.Sum(q => q.LishiShouBenqi_ShiShou_ChargeType1);
                decimal MonthLishiShouBenqi2 = childHistoryList2.Sum(q => q.LishiShouBenqi_ShiShou_ChargeType2);
                MonthLishiShouBenqi = MonthLishiShouBenqi1 + MonthLishiShouBenqi2;

                decimal MonthBenqiShouBenqi1 = childHistoryList1.Sum(q => q.BenqiShouBenqi_ShiShou_ChargeType1);
                decimal MonthBenqiShouBenqi2 = childHistoryList2.Sum(q => q.BenqiShouBenqi_ShiShou_ChargeType2);
                MonthBenqiShouBenqi = MonthBenqiShouBenqi1 + MonthBenqiShouBenqi2;

                decimal MonthBenqiShouLishi1 = childHistoryList1.Sum(q => q.BenqiShouLishi_ShiShou_ChargeType1);
                decimal MonthBenqiShouLishi2 = childHistoryList2.Sum(q => q.BenqiShouLishi_ShiShou_ChargeType2);
                MonthBenqiShouLishi = MonthBenqiShouLishi1 + MonthBenqiShouLishi2;

                decimal MonthBenqiYuShou1 = childHistoryList1.Sum(q => q.BenqiYuShou_ShiShou_ChargeType1);
                decimal MonthBenqiYuShou2 = childHistoryList2.Sum(q => q.BenqiYuShou_ShiShou_ChargeType2);
                MonthBenqiYuShou = MonthBenqiYuShou1 + MonthBenqiYuShou2;
            }
            if (MonthZhiHouShouBenqi > 0 || MonthLishiShouBenqi > 0 || MonthBenqiShouBenqi > 0 || MonthBenqiShouLishi > 0 || MonthBenqiYuShou > 0)
            {
                data["FormatMonthZhiHouShouBenqi"] = Utility.Tools.FormatMoney(MonthZhiHouShouBenqi, 2);
                data["FormatMonthLishiShouBenqi"] = Utility.Tools.FormatMoney(MonthLishiShouBenqi, 2);
                data["FormatMonthBenqiShouBenqi"] = Utility.Tools.FormatMoney(MonthBenqiShouBenqi, 2);
                data["FormatMonthBenqiShouLishi"] = Utility.Tools.FormatMoney(MonthBenqiShouLishi, 2);
                data["FormatMonthBenqiYuShou"] = Utility.Tools.FormatMoney(MonthBenqiYuShou, 2);
                return data;
            }
            return null;
        }
        public static Foresight.DataAccess.Ui.DataGrid loadshoufeilvshoufubycharge(long startRowIndex, int pageSize, int CompanyID, List<int> RoomIDList, List<int> ProjectIDList, DateTime StartTime, DateTime EndTime, List<int> ChargeIDList, int ShowType, string RoomType, int RoomID, bool canexport = false)
        {
            try
            {
                var dg = ChargeSummaryShouFeiLvAnalysis.GetChargeSummaryShouFeiLvAnalysisByChargeName(ProjectIDList, RoomIDList, StartTime, EndTime, CompanyID, ChargeIDList, RoomID, RoomType, ShowType);
                var list = dg.rows as ChargeSummaryShouFeiLvAnalysis[];
                if (list.Length == 0)
                {
                    return new Foresight.DataAccess.Ui.DataGrid();
                }
                var fee_list = RoomFeeAnalysis.GetRoomFeeAnalysisListByRoomID(RoomIDList, ProjectIDList, DateTime.MinValue, DateTime.MinValue, ChargeIDList.ToArray(), true, UserID: WebUtil.GetUser(HttpContext.Current).UserID);
                var history_list = ViewRoomFeeHistoryDetail.GetViewRoomFeeHistoryDetailList(RoomIDList, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, ProjectIDList: ProjectIDList, ChargeIDList: ChargeIDList, UserID: WebUtil.GetUser(HttpContext.Current).UserID, requireRelationRoom: true);
                //本期欠费
                var ViewRoomFeeDetailList_BenQiQianFei_Dic = RoomFeeAnalysis.GetRoomFeeAnalysisDictionary(fee_list, StartTime, EndTime);
                //本期实收
                var ViewRoomFeeHistoryDetailList_BenQiShiShou_Dic = ViewRoomFeeHistoryDetail.GetViewRoomFeeHistoryDetailDictionary(history_list, StartTime, EndTime);
                DateTime HistoryEndTime = DateTime.MinValue;
                if (StartTime > DateTime.MinValue)
                {
                    HistoryEndTime = StartTime.AddDays(-1);
                }
                var ViewRoomFeeDetailList_LiShiQianFei_Dic = new List<Dictionary<string, object>>();
                var ViewRoomFeeHistoryDetailList_LeiJiShiShou_Dic = new List<Dictionary<string, object>>();
                if (HistoryEndTime > DateTime.MinValue)
                {
                    //历史欠费
                    ViewRoomFeeDetailList_LiShiQianFei_Dic = RoomFeeAnalysis.GetRoomFeeAnalysisDictionary(fee_list, DateTime.MinValue, HistoryEndTime);
                    //累计实收
                    ViewRoomFeeHistoryDetailList_LeiJiShiShou_Dic = ViewRoomFeeHistoryDetail.GetViewRoomFeeHistoryDetailDictionary(history_list, DateTime.MinValue, HistoryEndTime);
                }
                foreach (var item in list)
                {
                    var child_ViewRoomFeeDetailList_BenQiQianFei_Dic = ViewRoomFeeDetailList_BenQiQianFei_Dic.Where(p => Convert.ToInt32(p["ChargeID"]) == item.ChargeID);

                    var child_ViewRoomFeeHistoryDetailList_BenQiShiShou_Dic = ViewRoomFeeHistoryDetailList_BenQiShiShou_Dic.Where(p => Convert.ToInt32(p["ChargeID"]) == item.ChargeID).ToList();

                    var child_ViewRoomFeeDetailList_LiShiQianFei_Dic = ViewRoomFeeDetailList_LiShiQianFei_Dic.Where(p => Convert.ToInt32(p["ChargeID"]) == item.ChargeID);

                    var child_ViewRoomFeeHistoryDetailList_LeiJiShiShouList = ViewRoomFeeHistoryDetailList_LeiJiShiShou_Dic.Where(p => Convert.ToInt32(p["ChargeID"]) == item.ChargeID).ToList();

                    if (RoomID > 0)
                    {
                        child_ViewRoomFeeDetailList_BenQiQianFei_Dic = child_ViewRoomFeeDetailList_BenQiQianFei_Dic.Where(p => ((p["FinalAllParentID"] == null ? "" : p["FinalAllParentID"].ToString()).Contains("," + RoomID + ",") || Convert.ToInt32(p["RoomID"].ToString()) == RoomID));

                        child_ViewRoomFeeHistoryDetailList_BenQiShiShou_Dic = child_ViewRoomFeeHistoryDetailList_BenQiShiShou_Dic.Where(p => ((p["FinalAllParentID"] == null ? "" : p["FinalAllParentID"].ToString()).Contains("," + RoomID + ",") || Convert.ToInt32(p["RoomID"].ToString()) == RoomID)).ToList();

                        child_ViewRoomFeeDetailList_LiShiQianFei_Dic = child_ViewRoomFeeDetailList_LiShiQianFei_Dic.Where(p => ((p["FinalAllParentID"] == null ? "" : p["FinalAllParentID"].ToString()).Contains("," + RoomID + ",") || Convert.ToInt32(p["RoomID"].ToString()) == RoomID));

                        child_ViewRoomFeeHistoryDetailList_LeiJiShiShouList = child_ViewRoomFeeHistoryDetailList_LeiJiShiShouList.Where(p => ((p["FinalAllParentID"] == null ? "" : p["FinalAllParentID"].ToString()).Contains("," + RoomID + ",") || Convert.ToInt32(p["RoomID"].ToString()) == RoomID)).ToList();
                    }
                    //本期实收
                    item.ShouFuZhiBenQiShiShou = child_ViewRoomFeeHistoryDetailList_BenQiShiShou_Dic.Where(p => Convert.ToDecimal(p["MonthTotalCost"]) > 0).Sum(q => Convert.ToDecimal(q["MonthTotalCost"]));
                    //本期减免
                    item.ShouFuZhiBenQiJianMian = child_ViewRoomFeeHistoryDetailList_BenQiShiShou_Dic.Where(p => Convert.ToDecimal(p["MonthDiscountCost"]) > 0).Sum(q => Convert.ToDecimal(q["MonthDiscountCost"]));
                    //本期欠费
                    item.ShouFuZhiBenQiQianFei = child_ViewRoomFeeDetailList_BenQiQianFei_Dic.Where(p => Convert.ToDecimal(p["TotalFinalCost"]) > 0).Sum(q => Convert.ToDecimal(q["TotalFinalCost"]));
                    //本期应收
                    decimal ShouFuZhiBenQiYingShou_1 = child_ViewRoomFeeDetailList_BenQiQianFei_Dic.Sum(q => Convert.ToDecimal(q["TotalCost"]));
                    decimal ShouFuZhiBenQiYingShou_2 = ViewRoomFeeHistoryBase.GetViewRoomFeeHistoryTotalCost(my_history_dic_list: child_ViewRoomFeeHistoryDetailList_BenQiShiShou_Dic);
                    item.ShouFuZhiBenQiYingShou = ShouFuZhiBenQiYingShou_1 + ShouFuZhiBenQiYingShou_2;
                    //累计实收
                    item.ShouFuZhiLeiJiShiShou = child_ViewRoomFeeHistoryDetailList_LeiJiShiShouList.Where(p => Convert.ToDecimal(p["MonthTotalCost"]) > 0).Sum(q => Convert.ToDecimal(q["MonthTotalCost"]));
                    item.ShouFuZhiLeiJiShiShou += item.ShouFuZhiBenQiShiShou;
                    //累计减免
                    item.ShouFuZhiLiShiJianMian = child_ViewRoomFeeHistoryDetailList_LeiJiShiShouList.Where(p => Convert.ToDecimal(p["MonthDiscountCost"]) > 0).Sum(q => Convert.ToDecimal(q["MonthDiscountCost"]));
                    item.ShouFuZhiLiShiJianMian += item.ShouFuZhiBenQiJianMian;
                    item.ShouFuZhiLiShiQianFei = child_ViewRoomFeeDetailList_LiShiQianFei_Dic.Where(p => Convert.ToDecimal(p["TotalFinalCost"]) > 0).Sum(q => Convert.ToDecimal(q["TotalFinalCost"]));
                    item.ShouFuZhiLiShiQianFei = item.ShouFuZhiLiShiQianFei + item.ShouFuZhiBenQiQianFei;

                    decimal ShouFuZhiLeiJiYingShou_1 = child_ViewRoomFeeDetailList_LiShiQianFei_Dic.Sum(q => Convert.ToDecimal(q["TotalCost"]));
                    decimal ShouFuZhiLeiJiYingShou_2 = ViewRoomFeeHistoryBase.GetViewRoomFeeHistoryTotalCost(my_history_dic_list: child_ViewRoomFeeHistoryDetailList_LeiJiShiShouList);
                    item.ShouFuZhiLeiJiYingShou = ShouFuZhiLeiJiYingShou_1 + ShouFuZhiLeiJiYingShou_2 + item.ShouFuZhiBenQiYingShou;
                    if (item.ShouFuZhiBenQiYingShou > 0)
                    {
                        item.ShouFuZhiBenQiShouFeiLv = Math.Round((decimal)(((item.ShouFuZhiBenQiShiShou + item.ShouFuZhiBenQiJianMian) / item.ShouFuZhiBenQiYingShou) * 100), 2, MidpointRounding.AwayFromZero) + "%";
                    }
                    else
                    {
                        item.ShouFuZhiBenQiShouFeiLv = "0.00%";
                    }
                    if (item.ShouFuZhiLeiJiYingShou > 0)
                    {
                        item.ShouFuZhiLeiJiShouFeiLv = Math.Round((decimal)(((item.ShouFuZhiLeiJiShiShou + item.ShouFuZhiLiShiJianMian) / item.ShouFuZhiLeiJiYingShou) * 100), 2, MidpointRounding.AwayFromZero) + "%";
                    }
                    else
                    {
                        item.ShouFuZhiLeiJiShouFeiLv = "0.00%";
                    }
                }
                if (ShowType == 0)
                {
                    list = list.Where(p => p.ShouFuZhiBenQiYingShou > 0 || p.ShouFuZhiLeiJiYingShou > 0 || p.ShouFuZhiBenQiShiShou > 0 || p.ShouFuZhiBenQiQianFei > 0 || p.ShouFuZhiLiShiQianFei > 0).ToArray();
                }
                dg.rows = list;
                if (RoomID <= 0)
                {
                    var footer = new List<ChargeSummaryShouFeiLvAnalysis>();
                    var footer_item = new ChargeSummaryShouFeiLvAnalysis();
                    footer_item.FullName = "合计";
                    footer_item.RoomName = "";
                    footer_item.Name = "";
                    footer_item.ShouFuZhiBenQiYingShou = list.Sum(p =>
                    {
                        return p.ShouFuZhiBenQiYingShou > 0 ? p.ShouFuZhiBenQiYingShou : 0;
                    });
                    footer_item.ShouFuZhiBenQiShiShou = list.Sum(p =>
                    {
                        return p.ShouFuZhiBenQiShiShou > 0 ? p.ShouFuZhiBenQiShiShou : 0;
                    });
                    footer_item.ShouFuZhiBenQiQianFei = list.Sum(p =>
                    {
                        return p.ShouFuZhiBenQiQianFei > 0 ? p.ShouFuZhiBenQiQianFei : 0;
                    });
                    footer_item.ShouFuZhiLeiJiYingShou = list.Sum(p =>
                    {
                        return p.ShouFuZhiLeiJiYingShou > 0 ? p.ShouFuZhiLeiJiYingShou : 0;
                    });
                    footer_item.ShouFuZhiLeiJiShiShou = list.Sum(p =>
                    {
                        return p.ShouFuZhiLeiJiShiShou > 0 ? p.ShouFuZhiLeiJiShiShou : 0;
                    });
                    footer_item.ShouFuZhiLiShiQianFei = list.Sum(p =>
                    {
                        return p.ShouFuZhiLiShiQianFei > 0 ? p.ShouFuZhiLiShiQianFei : 0;
                    });
                    footer_item.ShouFuZhiBenQiJianMian = list.Sum(p =>
                    {
                        return p.ShouFuZhiBenQiJianMian > 0 ? p.ShouFuZhiBenQiJianMian : 0;
                    });
                    footer_item.ShouFuZhiLiShiJianMian = list.Sum(p =>
                    {
                        return p.ShouFuZhiLiShiJianMian > 0 ? p.ShouFuZhiLiShiJianMian : 0;
                    });
                    footer_item.ShouFuZhiBenQiShouFeiLv = "--";
                    footer_item.ShouFuZhiLeiJiShouFeiLv = "--";
                    footer.Add(footer_item);
                    dg.footer = footer;
                }
                return dg;
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("HandlerHelper.cs", "loadshoufeilvshoufubycharge", ex);
                return new Foresight.DataAccess.Ui.DataGrid();
            }
        }
        public static bool SavePrintFee(Dictionary<string, object> paramlist, out int out_printid, out bool print_cheque_status, out string errormsg, TempRoomFeeHistory[] list, ViewChargeSummary[] ViewChargeSummaryList)
        {
            print_cheque_status = true;
            errormsg = string.Empty;
            int PrintID = WebUtil.GetIntByObj(paramlist, "PrintID");
            out_printid = PrintID;
            PrintRoomFeeHistory printRoomFeeHistory = null;
            if (PrintID > 0)
            {
                printRoomFeeHistory = PrintRoomFeeHistory.GetPrintRoomFeeHistory(PrintID);
            }
            bool doprint = false;
            bool.TryParse(WebUtil.GetStrByObj(paramlist, "doprint"), out doprint);
            bool ischongxiao = false;
            bool.TryParse(WebUtil.GetStrByObj(paramlist, "ischongxiao"), out ischongxiao);
            if (printRoomFeeHistory != null)
            {
                if (!doprint)
                {
                    using (SqlHelper helper = new SqlHelper())
                    {
                        try
                        {
                            helper.BeginTransaction();
                            SavePrintRoomFeeHistory(paramlist, printRoomFeeHistory, helper);
                            helper.Commit();
                        }
                        catch (Exception ex)
                        {
                            helper.Rollback();
                            errormsg = ex.Message;
                            return false;
                        }
                    }
                    if (!ischongxiao)
                    {
                        #region 收款保存日志
                        APPCode.CommHelper.SaveOperationLog("订单号" + printRoomFeeHistory.PrintNumber + "收款保存", Utility.EnumModel.OperationModule.ChargeFeeSave.ToString(), "收款保存", printRoomFeeHistory.ID.ToString(), "PrintRoomFeeHistory");
                        #endregion
                    }
                    else
                    {
                        #region 预收款冲销保存日志
                        APPCode.CommHelper.SaveOperationLog("订单号" + printRoomFeeHistory.PrintNumber + "预收款冲销保存", Utility.EnumModel.OperationModule.PreChargeFeeSave.ToString(), "预收款冲销保存", printRoomFeeHistory.ID.ToString(), "PrintRoomFeeHistory");
                        #endregion
                    }
                }
                else
                {
                    if (!ischongxiao)
                    {
                        #region 收款打印日志
                        APPCode.CommHelper.SaveOperationLog("订单号" + printRoomFeeHistory.PrintNumber + "收款打印", Utility.EnumModel.OperationModule.ChargeFeePrint.ToString(), "收款打印", printRoomFeeHistory.ID.ToString(), "PrintRoomFeeHistory");
                        #endregion
                    }
                    else
                    {
                        #region 预收款冲销打印日志
                        APPCode.CommHelper.SaveOperationLog("订单号" + printRoomFeeHistory.PrintNumber + "预收款冲销打印", Utility.EnumModel.OperationModule.PreChargeFeePrint.ToString(), "预收款冲销打印", printRoomFeeHistory.ID.ToString(), "PrintRoomFeeHistory");
                        #endregion
                    }
                }
                out_printid = printRoomFeeHistory.ID;
                return true;
            }
            printRoomFeeHistory = new PrintRoomFeeHistory();
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    int RoomID = list.Length > 0 ? list[0].RoomID : 0;
                    SavePrintRoomFeeHistory(paramlist, printRoomFeeHistory, helper, RoomID);
                    foreach (var field in list)
                    {
                        decimal UnitPrice = field.UnitPrice > decimal.MinValue ? field.UnitPrice : 0;
                        decimal ChargeFee = field.ChargeFee > decimal.MinValue ? field.ChargeFee : 0;
                        decimal RealCost = field.ChargeFee > 0 ? field.ChargeFee : (field.RealCost > decimal.MinValue ? field.RealCost : 0);
                        decimal Discount = field.Discount > decimal.MinValue ? field.Discount : 0;
                        DateTime CuiShouStartTime = field.CuiShouStartTime > DateTime.MinValue ? field.CuiShouStartTime : DateTime.MinValue;
                        var roomFee = RoomFee.GetRoomFee(field.ID, helper);
                        if (roomFee == null)
                        {
                            roomFee = Foresight.DataAccess.RoomFee.SetInfo_RoomFee(field.RoomID, field.StartTime, field.EndTime, field.Cost, RealCost, UnitPrice, field.ChargeID, TotalRealCost: field.TotalRealCost, OnlyOnceCharge: field.OnlyOnceCharge, cansave: true, helper: helper);
                        }
                        roomFee.StartTime = field.StartTime;
                        roomFee.EndTime = field.EndTime;
                        roomFee.NewEndTime = field.NewEndTime;
                        roomFee.OutDays = field.OutDays;
                        roomFee.UseCount = field.UseCount;
                        roomFee.Cost = field.Cost;
                        roomFee.Remark = field.Remark;
                        roomFee.IsCharged = true;
                        roomFee.UnitPrice = UnitPrice;
                        roomFee.ChargeFee = ChargeFee;
                        roomFee.RealCost = RealCost;
                        roomFee.Discount = Discount;
                        roomFee.TotalRealCost = (roomFee.TotalRealCost < 0 ? 0 : roomFee.TotalRealCost) + roomFee.RealCost;
                        roomFee.TotalDiscountCost = (roomFee.TotalDiscountCost < 0 ? 0 : roomFee.TotalDiscountCost) + roomFee.Discount;
                        decimal restcost = roomFee.Cost - roomFee.TotalDiscountCost - roomFee.TotalRealCost;
                        if (restcost < 0)
                        {
                            restcost = 0;
                        }
                        roomFee.RestCost = restcost;
                        roomFee.ContractID = field.ContractID;
                        roomFee.DiscountID = field.DiscountID;
                        roomFee.CuiShouStartTime = CuiShouStartTime;
                        roomFee.CuiShouEndTime = field.CuiShouEndTime > DateTime.MinValue ? field.CuiShouEndTime : DateTime.MinValue;
                        roomFee.RelatedFeeID = field.RelatedFeeID;
                        roomFee.ChongDiChargeID = field.ChongDiChargeID;
                        roomFee.DefaultChargeManID = field.DefaultChargeManID;
                        roomFee.DefaultChargeManName = field.DefaultChargeManName;
                        roomFee.Contract_RoomChargeID = field.Contract_RoomChargeID;
                        roomFee.TradeNo = field.TradeNo;
                        roomFee.ContractDivideID = field.ContractDivideID;
                        roomFee.OrderID = field.OrderID;
                        roomFee.IsTempFee = field.IsTempFee;
                        roomFee.IsMeterFee = field.IsMeterFee;
                        roomFee.IsImportFee = field.IsImportFee;
                        roomFee.IsCycleFee = field.IsCycleFee;
                        roomFee.Save(helper);
                        #region 收费后续操作
                        Web.APPCode.HandlerHelper.SaveRoomFee(roomFee, WebUtil.GetStrByObj(paramlist, "ChargeMan"), helper, printRoomFeeHistory, ViewChargeSummaryList);
                        #endregion
                    }
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError("FeeCenterHandler", "visit: SavePrintFee", ex);
                    errormsg = ex.Message;
                    return false;
                }
            }

            if (!doprint)
            {
                if (ischongxiao)
                {
                    #region 预收款冲销保存日志
                    APPCode.CommHelper.SaveOperationLog("订单号" + printRoomFeeHistory.PrintNumber + "预收款冲销保存", Utility.EnumModel.OperationModule.PreChargeFeeSave.ToString(), "预收款冲销保存", printRoomFeeHistory.ID.ToString(), "PrintRoomFeeHistory");
                    #endregion
                }
                else
                {
                    #region 收款保存日志
                    APPCode.CommHelper.SaveOperationLog("订单号" + printRoomFeeHistory.PrintNumber + "收款保存", Utility.EnumModel.OperationModule.ChargeFeeSave.ToString(), "收款保存", printRoomFeeHistory.ID.ToString(), "PrintRoomFeeHistory");
                    #endregion
                }
            }
            else
            {
                if (!ischongxiao)
                {
                    #region 收款打印日志
                    APPCode.CommHelper.SaveOperationLog("订单号" + printRoomFeeHistory.PrintNumber + "收款打印", Utility.EnumModel.OperationModule.ChargeFeePrint.ToString(), "收款打印", printRoomFeeHistory.ID.ToString(), "PrintRoomFeeHistory");
                    #endregion
                }
                else
                {
                    #region 预收款冲销打印日志
                    APPCode.CommHelper.SaveOperationLog("订单号" + printRoomFeeHistory.PrintNumber + "预收款冲销打印", Utility.EnumModel.OperationModule.PreChargeFeePrint.ToString(), "预收款冲销打印", printRoomFeeHistory.ID.ToString(), "PrintRoomFeeHistory");
                    #endregion
                }
            }
            out_printid = printRoomFeeHistory.ID;
            bool printcheque = false;
            bool.TryParse(WebUtil.GetStrByObj(paramlist, "printcheque"), out printcheque);
            int RelationID = WebUtil.GetIntByObj(paramlist, "RelationID");
            if (printcheque)
            {
                print_cheque_status = PrintCheque(out_printid, RelationID, out errormsg);
            }
            return true;
        }
        private static void SavePrintRoomFeeHistory(Dictionary<string, object> paramlist, PrintRoomFeeHistory printRoomFeeHistory, SqlHelper helper, int RoomID = 0)
        {
            int ChargeType1 = WebUtil.GetIntByObj(paramlist, "ChargeMoneyType1");
            int ChargeType2 = WebUtil.GetIntByObj(paramlist, "ChargeMoneyType2");
            string PrintNumber = WebUtil.GetStrByObj(paramlist, "PrintNumber");
            decimal RealCost = WebUtil.GetDecimalByObj(paramlist, "RealCost");
            decimal TotalCost = WebUtil.GetDecimalByObj(paramlist, "TotalCost");
            decimal PreChargeMoney = WebUtil.GetDecimalByObj(paramlist, "PreChargeMoney");
            decimal ChargeBackMoney = WebUtil.GetDecimalByObj(paramlist, "ChargeBackMoney");
            decimal RealMoneyCost1 = WebUtil.GetDecimalByObj(paramlist, "RealMoneyCost1");
            decimal RealMoneyCost2 = WebUtil.GetDecimalByObj(paramlist, "RealMoneyCost2");
            decimal DiscountMoney = WebUtil.GetDecimalByObj(paramlist, "DiscountMoney");
            decimal WeiShu = WebUtil.GetDecimalByObj(paramlist, "WeiShu");
            decimal money = WebUtil.GetDecimalByObj(paramlist, "money");
            string MoneyDaXie = WebUtil.GetStrByObj(paramlist, "MoneyDaXie");
            string ChargeMan = WebUtil.GetStrByObj(paramlist, "ChargeMan");
            DateTime ChargeTime = WebUtil.GetDateTimeByObj(paramlist, "ChargeTime");
            string Remark = WebUtil.GetStrByObj(paramlist, "Remark");
            int OrderNumberID = WebUtil.GetIntByObj(paramlist, "OrderNumberID");
            string PrintTitle = WebUtil.GetStrByObj(paramlist, "PrintTitle");
            string PrintSubTitle = WebUtil.GetStrByObj(paramlist, "PrintSubTitle");
            var nextPrintRoomFeeHistory = PrintRoomFeeHistory.GetPrintRoomFeeHistoryByPrintNumber(PrintNumber, printRoomFeeHistory.ID, helper);
            if (nextPrintRoomFeeHistory != null)
            {
                PrintNumber = PrintRoomFeeHistory.GetLastestPrintNumber(OrderTypeNameDefine.chargefee.ToString(), RoomID, helper, out OrderNumberID);
            }
            printRoomFeeHistory.PrintNumber = PrintNumber;
            if (OrderNumberID > 0)
            {
                var sys_ordernumber = Sys_OrderNumber.GetSys_OrderNumber(OrderNumberID, helper);
                if (sys_ordernumber != null)
                {
                    printRoomFeeHistory.OrderNumberID = sys_ordernumber.ID;
                    printRoomFeeHistory.OrderNumberType = sys_ordernumber.ChargeType;
                }
            }
            printRoomFeeHistory.PrintTitle = PrintTitle;
            printRoomFeeHistory.PrintSubTitle = PrintSubTitle;
            printRoomFeeHistory.Cost = TotalCost;
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
            decimal weishumore = printRoomFeeHistory.RealCost - money;
            printRoomFeeHistory.WeiShuMore = weishumore > 0 ? weishumore : 0;

            decimal weishuconsume = money - printRoomFeeHistory.RealCost;
            printRoomFeeHistory.WeiShuConsume = weishuconsume > 0 ? weishuconsume : 0;
            printRoomFeeHistory.RoomFullName = WebUtil.GetStrByObj(paramlist, "RoomFullName");
            printRoomFeeHistory.RoomOwnerName = WebUtil.GetStrByObj(paramlist, "RoomOwnerName");
            printRoomFeeHistory.ChargeForSummary = WebUtil.GetStrByObj(paramlist, "ChargeForSummary");
            printRoomFeeHistory.ChargeMethods = WebUtil.GetStrByObj(paramlist, "ChargeMethods");
            printRoomFeeHistory.WeiShuBalance = WebUtil.GetDecimalByObj(paramlist, "WeiShuBalance");
            printRoomFeeHistory.Save(helper);
        }
        public static bool CancelHistoryFeeProcess(HttpContext context, string AddMan, RoomFeeHistory[] history_list, PrintRoomFeeHistory[] print_list, out string error)
        {
            error = string.Empty;
            if (history_list.Length == 0 && print_list.Length == 0)
            {
                return false;
            }
            var print_order_list = print_list.Where(p => p.RoomFeeOrderID > 0).ToList();
            if (print_order_list.Count > 0)
            {
                error = "选中的账单包含已交班账单，禁止此操作";
                return false;
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    foreach (var item in print_list)
                    {
                        item.IsCancel = true;
                        item.CancelMan = AddMan;
                        item.CancelTime = DateTime.Now;
                        item.Save(helper);
                        var RoomFeeHistoryList = history_list.Where(p => p.PrintID == item.ID).ToArray().OrderByDescending(p => p.StartTime).ToArray();
                        foreach (var roomFeeHistory in RoomFeeHistoryList)
                        {
                            var preChargeState = roomFeeHistory.ChargeState;
                            //订单已作废
                            if (preChargeState == 2)
                            {
                                helper.Rollback();
                                error = "不能重复作废订单";
                                return false;
                            }
                            var chargeSummary = ChargeSummary.GetChargeSummary(roomFeeHistory.ChargeID, helper);
                            //预收款作废
                            if (chargeSummary != null && chargeSummary.CategoryID == 4 && preChargeState == 1)
                            {
                                List<int> RoomIDList = new int[] { roomFeeHistory.RoomID }.ToList();
                                var preBalance = Foresight.DataAccess.ViewRoomBalance.GetPreChargeBalance(RoomIDList, roomFeeHistory.ChargeID, helper);
                                if (roomFeeHistory.RealCost > preBalance)
                                {
                                    helper.Rollback();
                                    error = "预收款金额大于账户余额，不能作废";
                                    return false;
                                }
                            }
                            roomFeeHistory.ChargeState = 2;
                            roomFeeHistory.Save(helper);
                            if (chargeSummary == null && roomFeeHistory.ContractDivideID <= 0)
                            {
                                continue;
                            }
                            //付款单据作废
                            if (preChargeState == 3 || preChargeState == 6)
                            {
                                continue;
                            }
                            //判断是否账单是否存在
                            var roomFee = RoomFee.GetRoomFee(roomFeeHistory.ID, helper);
                            decimal TotalRealCost = 0;
                            if (roomFee != null)
                            {
                                TotalRealCost = Foresight.DataAccess.RoomFeeHistory.GetTotalRealCost(roomFee.ID, roomFee.RoomID, roomFee.ChargeID, helper);
                            }
                            #region 催款单作废处理
                            DateTime CuiShouStartTime = DateTime.MinValue;
                            DateTime CuiShouEndTime = DateTime.MinValue;
                            if (preChargeState == 5)
                            {
                                //查询此催收单之后是否还有收费项目
                                if (roomFee != null)
                                {
                                    if (chargeSummary != null && chargeSummary.FeeType == 1)
                                    {
                                        RoomFeeHistory nexthistory = null;
                                        var prehistory = RoomFeeHistory.GetPreRoomFeeHistory(roomFeeHistory.ID, roomFeeHistory.StartTime, helper, out nexthistory);
                                        if (nexthistory != null)
                                        {
                                            helper.Rollback();
                                            error = "请按先取消此催收单之后的费用";
                                            return false;
                                        }
                                        if (prehistory != null)
                                        {
                                            CuiShouStartTime = prehistory.StartTime;
                                            CuiShouEndTime = prehistory.EndTime;
                                        }
                                    }
                                    roomFee.IsCharged = false;
                                    roomFee.Cost = roomFeeHistory.Cost;
                                    roomFee.ChargeFee = 0;
                                    roomFee.Discount = 0;
                                    roomFee.TotalDiscountCost = 0;
                                    roomFee.TotalRealCost = TotalRealCost > 0 ? TotalRealCost : 0;
                                    roomFee.EndTime = roomFeeHistory.EndTime;
                                    roomFee.CuiShouStartTime = CuiShouStartTime;
                                    roomFee.CuiShouEndTime = CuiShouEndTime;
                                    roomFee.Save(helper);
                                }
                                continue;
                            }
                            #endregion
                            //更改导入账单状态
                            ImportFee importFee = null;
                            int ImportFeeID = 0;
                            if (roomFeeHistory.ImportFeeID > 0)
                            {
                                ImportFeeID = roomFeeHistory.ImportFeeID;
                                importFee = ImportFee.GetOrCreateImportFeeByID(ImportFeeID, helper);
                                if (importFee != null)
                                {
                                    importFee.ChargeStatus = TotalRealCost > 0 ? 1 : 0;
                                    importFee.Save(helper);
                                }
                            }
                            //三表费用
                            ChargeMeter_ProjectFee meter_fee = null;
                            int MeterFeeID = 0;
                            if (roomFeeHistory.IsMeterFee && roomFeeHistory.ChargeMeterProjectFeeID > 0)
                            {
                                MeterFeeID = roomFeeHistory.ChargeMeterProjectFeeID;
                                meter_fee = ChargeMeter_ProjectFee.GetChargeMeter_ProjectFee(MeterFeeID, helper);
                            }
                            //更改联营分成账单状态
                            Contract_Divide divide = null;
                            int DivideID = 0;
                            if (roomFeeHistory.ContractDivideID > 0)
                            {
                                DivideID = roomFeeHistory.ContractDivideID;
                                divide = Contract_Divide.GetContract_Divide(DivideID, helper);
                                if (divide != null)
                                {
                                    divide.ChargeStatus = TotalRealCost > 0 ? 1 : 0;
                                    divide.Save(helper);
                                }
                            }
                            if (roomFeeHistory.IsCuiShou)
                            {
                                RoomFeeHistory nexthistory = null;
                                var prehistory = RoomFeeHistory.GetPreRoomFeeHistory(roomFeeHistory.ID, roomFeeHistory.StartTime, helper, out nexthistory);
                                if (prehistory != null)
                                {
                                    CuiShouStartTime = prehistory.StartTime;
                                    CuiShouEndTime = prehistory.EndTime;
                                }
                            }
                            if (roomFee != null)
                            {
                                roomFee.UnitPrice = roomFeeHistory.UnitPrice;
                                roomFee.UseCount = roomFeeHistory.UseCount;
                                roomFee.IsCharged = false;
                                roomFee.ChargeFee = 0;
                                roomFee.TotalRealCost = TotalRealCost > 0 ? TotalRealCost : 0;
                                roomFee.TotalDiscountCost = 0;
                                roomFee.Discount = 0;
                                roomFee.CuiShouStartTime = CuiShouStartTime;
                                roomFee.CuiShouEndTime = CuiShouEndTime;
                                roomFee.Save(helper);
                                continue;
                            }
                            DateTime RoomFee_NewEndTime = DateTime.MinValue;
                            //周期费用，非合同费项
                            if (roomFee == null && roomFeeHistory.Contract_RoomChargeID <= 0 && chargeSummary != null && chargeSummary.FeeType == 1)
                            {
                                roomFee = RoomFee.GetRoomFeeByIDs(roomFeeHistory.RoomID, roomFeeHistory.ChargeID, helper, StartTime: roomFeeHistory.StartTime, EndTime: roomFeeHistory.EndTime);
                                if (roomFee != null)
                                {
                                    RoomFeeHistory.UpdateRoomFeeHistoryID(helper, RoomFeeID: roomFee.ID, HistoryRoomFeeID: roomFeeHistory.ID);
                                    //连续收费
                                    if (roomFeeHistory.EndTime > DateTime.MinValue && roomFee.StartTime > DateTime.MinValue && roomFeeHistory.EndTime.AddDays(1) == roomFee.StartTime)
                                    {
                                        roomFee.IsCharged = false;
                                        roomFee.Cost = roomFeeHistory.Cost;
                                        roomFee.ChargeFee = 0;
                                        roomFee.Discount = 0;
                                        roomFee.TotalDiscountCost = 0;
                                        roomFee.TotalRealCost = TotalRealCost > 0 ? TotalRealCost : 0;
                                        roomFee.StartTime = roomFeeHistory.StartTime;
                                        roomFee.EndTime = roomFeeHistory.EndTime;
                                        roomFee.CuiShouStartTime = CuiShouStartTime;
                                        roomFee.CuiShouEndTime = CuiShouEndTime;
                                        roomFee.Save(helper);
                                        continue;
                                    }
                                    RoomFee_NewEndTime = roomFeeHistory.EndTime;
                                }
                            }
                            //临时费项
                            if ((ImportFeeID == 0 && chargeSummary != null && chargeSummary.FeeType != 1 && MeterFeeID == 0) || roomFeeHistory.IsTempFee)
                            {
                                continue;
                            }
                            var newroomFee = Foresight.DataAccess.RoomFee.SetInfo_RoomFee(roomFeeHistory.RoomID, roomFeeHistory.StartTime, roomFeeHistory.EndTime, roomFeeHistory.Cost, 0, roomFeeHistory.UnitPrice, roomFeeHistory.ChargeID, UseCount: roomFeeHistory.UseCount, NewEndTime: RoomFee_NewEndTime, Remark: roomFeeHistory.Remark, ImportFeeID: roomFeeHistory.ImportFeeID, OutDays: roomFeeHistory.OutDays, OnlyOnceCharge: true, ContractID: roomFeeHistory.ContractID, Contract_RoomChargeID: roomFeeHistory.Contract_RoomChargeID, DefaultChargeManID: roomFeeHistory.DefaultChargeManID, DefaultChargeManName: roomFeeHistory.DefaultChargeManName, CuiShouStartTime: CuiShouStartTime, CuiShouEndTime: CuiShouEndTime, RelatedFeeID: roomFeeHistory.RelatedFeeID, ContractDivideID: roomFeeHistory.ContractDivideID, OrderID: roomFeeHistory.OrderID, IsTempFee: roomFeeHistory.IsTempFee, IsMeterFee: roomFeeHistory.IsMeterFee, IsImportFee: roomFeeHistory.IsImportFee, IsCycleFee: roomFeeHistory.IsCycleFee, RoomFeeCoefficient: roomFeeHistory.RoomFeeCoefficient, RoomFeeWriteDate: roomFeeHistory.RoomFeeWriteDate, ChargeFeeID: roomFeeHistory.ChargeFeeID, RoomFeeStartPoint: roomFeeHistory.RoomFeeStartPoint, RoomFeeEndPoint: roomFeeHistory.RoomFeeEndPoint, ChargeMeterProjectFeeID: roomFeeHistory.ChargeMeterProjectFeeID, cansave: true, helper: helper, HistoryRoomFeeID: roomFeeHistory.ID);
                            if (meter_fee != null)
                            {
                                meter_fee.RoomFeeID = newroomFee.ID;
                                meter_fee.Save(helper);
                            }
                        }
                    }
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError("APPCode.HandlerHelper.cs", "CancelHistoryFeeProcess", ex);
                    error = ex.Message;
                    return false;
                }
            }
            return true;
        }
        public static bool PrintCheque(int PrintID, int RelationID, out string msg)
        {
            msg = string.Empty;
            var history_list = ViewRoomFeeHistory.GetViewRoomFeeHistoryListByPrintID(PrintID);
            if (history_list.Length == 0)
            {
                msg = "单据费项为空";
                return false;
            }
            string KHMC = string.Empty;
            string KHDZ = string.Empty;
            string KHSH = string.Empty;
            string KHKHYHZH = string.Empty;
            string KHYJ = string.Empty;
            var company = Company.GetCompanies().FirstOrDefault();
            PrintRoomFeeHistory print_data = null;
            RoomPhoneRelation relation = null;
            RoomBasic basic = null;
            using (SqlHelper helper = new SqlHelper())
            {
                print_data = PrintRoomFeeHistory.GetPrintRoomFeeHistory(PrintID, helper);
                relation = RoomPhoneRelation.GetRoomPhoneRelation(RelationID, helper);
                if (relation != null)
                {
                    KHMC = relation.CompanyName;
                    KHDZ = relation.HomeAddress;
                    KHSH = relation.TaxpayerNumber;
                    KHKHYHZH = relation.BankAccountNo;
                    KHYJ = relation.EmailAddress;
                }
                if (relation == null)
                {
                    basic = RoomBasic.GetRoomBasicByRoomID(history_list[0].RoomID, helper);
                }
                if (basic != null)
                {
                    KHMC = basic.ChequeCompanyName;
                    KHDZ = basic.ChequeAddress;
                    KHSH = basic.ChequeTaxpayerNumber;
                    KHKHYHZH = basic.ChequeBankNo;
                    KHYJ = basic.ChequeEmailAddress;
                }
            }
            var itemlist = new List<Dictionary<string, string>>();
            foreach (var history in history_list)
            {
                var item = new Dictionary<string, string>();
                item["CPMC"] = history.ChargeName;
                if (history.StartTime > DateTime.MinValue && history.EndTime > DateTime.MinValue)
                {
                    item["CPXH"] = history.StartTime.ToString("yyyy-MM-dd") + "至" + history.EndTime.ToString("yyyy-MM-dd");
                }
                else
                {
                    item["CPXH"] = "无";
                }
                item["CPDW"] = "个";
                item["SL"] = company.Cheque_SL.ToString("0.00");
                item["CPSL"] = "1";
                item["BHSJE"] = print_data.RealCost.ToString("0.00");
                string SE = Math.Round((print_data.RealCost * company.Cheque_SL / 100), 2, MidpointRounding.AwayFromZero).ToString("0.00");
                item["SE"] = SE;
                item["FLBM"] = company.Cheque_FLBM;
                item["XSYH"] = "0";
                item["LSLBZ"] = "";
                item["YHSM"] = "";
                itemlist.Add(item);
            }
            var headRequireItem = new Dictionary<string, string>();
            string XTLSH = Guid.NewGuid().ToString("N");
            string KPR = WebUtil.GetUser(HttpContext.Current).FinalRealName;
            string SKR = string.IsNullOrEmpty(print_data.ChargeMan) ? KPR : print_data.ChargeMan;
            headRequireItem["XTLSH"] = XTLSH;
            headRequireItem["KHMC"] = KHMC;
            headRequireItem["KHDZ"] = KHDZ;
            headRequireItem["KHSH"] = KHSH;
            headRequireItem["KHKHYHZH"] = KHKHYHZH;
            headRequireItem["QYKHYHZH"] = company.BankAccountNo;
            headRequireItem["KPJH"] = "0";
            headRequireItem["KPR"] = KPR;
            headRequireItem["SKR"] = SKR;
            headRequireItem["FHR"] = company.ReCheckUserName;
            string data = Utility.ChequeHelper.GetInvoiceContent(headRequireItem, itemlist);
            bool response = Utility.ChequeHelper.doChequeWriteReceipt(data, out msg);
            print_data.IsChequePrint = true;
            print_data.ChequeInvoiceStatus = response ? 1 : 0;
            print_data.ChequeInvoiceNo = XTLSH;
            print_data.Save();
            return response;
        }
        public static List<Dictionary<string, object>> GetMyMenuTree(SysMenu[] menus, int ParentID, string contextPath)
        {
            var modules = menus.Where(p => p.ParentID == ParentID).ToArray();
            if (modules.Length == 0)
            {
                return new List<Dictionary<string, object>>();
            }
            var items = modules.Select(p =>
            {
                string GroupName = p.GroupName;
                if (p.ParentID <= 0)
                {
                    GroupName = string.IsNullOrEmpty(GroupName) ? Utility.EnumModel.SysMenuGroupNameDefine.wynk.ToString() : GroupName;
                }
                var ChildCount = modules.Where(q => q.ParentID == p.ID).ToArray().Length;
                var item = new Dictionary<string, object>();
                item["ID"] = p.ID;
                item["Title"] = p.Title;
                item["URL"] = string.IsNullOrEmpty(p.Url) ? "" : p.Url;
                item["CssClass"] = p.CssClass;
                item["IconPath"] = !string.IsNullOrEmpty(p.IconPath) ? contextPath + p.IconPath : string.Empty;
                item["Children"] = GetMyMenuTree(menus, p.ID, contextPath);
                item["GroupName"] = string.IsNullOrEmpty(GroupName) ? "" : GroupName;
                return item;
            }).ToList();
            return items;
        }
    }
}