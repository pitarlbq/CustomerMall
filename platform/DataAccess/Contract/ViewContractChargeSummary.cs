using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Linq;
using Foresight.DataAccess.Framework;

namespace Foresight.DataAccess
{
    /// <summary>
    /// This object represents the properties and methods of a ViewContractChargeSummary.
    /// </summary>
    public partial class ViewContractChargeSummary : EntityBaseReadOnly
    {
        #region 公用静态属性
        public static DateTime InPutStartTime = DateTime.MinValue;
        public static DateTime InPutEndTime = DateTime.MinValue;
        public static List<decimal> ratecostlist = new List<decimal>();
        public static ChargePriceRange[] PriceRangeList = null;
        public static Dictionary<int, decimal> UseCountList = new Dictionary<int, decimal>();
        public static Contract_FreeTime[] ContractFreeTimeList = null;
        public static ViewRoomFeeHistoryDetail[] ViewRoomFeeHistoryDetailList = null;
        #endregion
        #region 公用属性
        [DatabaseColumn("PrintRemark")]
        public string PrintRemark { get; set; }
        public string FormatCalcualteTotalCost
        {
            get
            {
                return Utility.Tools.FormatMoney(this.CalcualteTotalCost);
            }
        }
        public string FormatCalcualtePayCost
        {
            get
            {
                return Utility.Tools.FormatMoney(this.CalcualtePayCost);
            }
        }
        public string FormatCalcualteDiscount
        {
            get
            {
                return Utility.Tools.FormatMoney(this.CalcualteDiscount);
            }
        }
        public string FormatCalcualteRestCost
        {
            get
            {
                return Utility.Tools.FormatMoney(this.CalcualteRestCost);
            }
        }
        public DateTime CalculateStartTime
        {
            get
            {
                if (this.CategoryID == 3 || this.CategoryID == 4)
                {
                    return DateTime.MinValue;
                }
                if (this.RoomStartTime > DateTime.MinValue)
                {
                    return this.RoomStartTime;
                }
                if (this.RentStartTime > DateTime.MinValue)
                {
                    return this.RentStartTime;
                }
                if (InPutStartTime > DateTime.MinValue)
                {
                    return InPutStartTime;
                }
                return this.SummaryStartTime;
            }
        }
        public DateTime CalculateEndTime
        {
            get
            {
                if (this.CategoryID == 3 || this.CategoryID == 4)
                {
                    return DateTime.MinValue;
                }
                if (this.RoomEndTime > DateTime.MinValue)
                {
                    return this.RoomEndTime;
                }
                if (this.FeeType != 1)
                {
                    return this.CalculateNewEndTime;
                }
                DateTime startTime = this.CalculateStartTime > DateTime.MinValue ? this.CalculateStartTime : DateTime.Now;
                DateTime endTime = DateTime.MinValue;
                int summaryChargeTypeCount = this.SummaryChargeTypeCount < 0 ? 1 : this.SummaryChargeTypeCount;
                int endNumberType = this.EndNumberType == int.MinValue ? 1 : this.EndNumberType;
                int endTypeID = this.EndTypeID == int.MinValue ? 1 : this.EndTypeID;
                if (endTypeID == 1)
                {
                    startTime = startTime < DateTime.Now ? DateTime.Now : startTime;
                }
                if (this.AutoToMonthEnd)
                {
                    if (endNumberType == 1)
                    {
                        endTime = startTime.AddDays(1 - startTime.Day).AddMonths(summaryChargeTypeCount + 1).AddDays(-1);
                    }
                    else
                    {
                        endTime = startTime.AddDays(1 - startTime.Day).AddMonths(1).AddDays(-1);
                    }
                }
                else
                {
                    if (endNumberType == 1)
                    {
                        endTime = startTime.AddMonths(summaryChargeTypeCount).AddDays(-1);
                    }
                    else
                    {
                        endTime = startTime.AddDays(summaryChargeTypeCount);
                    }
                }
                return endTime;
            }
        }
        public DateTime CalculateNewEndTime
        {
            get
            {
                if (this.RoomNewEndTime > DateTime.MinValue)
                {
                    return this.RoomNewEndTime;
                }
                if (this.RentEndTime > DateTime.MinValue)
                {
                    return this.RentEndTime;
                }
                if (InPutEndTime > DateTime.MinValue)
                {
                    return InPutEndTime;
                }
                return this.SummaryEndStartTime;
            }
        }
        public decimal CalculateUseCount
        {
            get
            {
                decimal CalculateUseCount = 0;
                if (UseCountList.ContainsKey(this.ID))
                {
                    CalculateUseCount = UseCountList[this.ID];
                    return CalculateUseCount;
                }
                if (this.RoomUseCount > 0)
                {
                    UseCountList[this.ID] = this.RoomUseCount;
                    return UseCountList[this.ID];
                }
                if (this.RoomID <= 0)
                {
                    decimal count1 = 0;
                    decimal count2 = 0;
                    var charge_list = Foresight.DataAccess.Contract_RoomCharge.GetContract_RoomChargeListByContractID(this.ContractID).Where(p => p.RoomID > 0);
                    var charge_roomid_list = charge_list.Select(q => q.RoomID).ToList();
                    var charge_basic_list = Foresight.DataAccess.RoomBasic.GetRoomBasicListByRoomIDList(charge_roomid_list);
                    var charge_summary_list = Foresight.DataAccess.ChargeSummary.GetChargeSummaries();
                    foreach (var item in charge_list)
                    {
                        var basic = charge_basic_list.FirstOrDefault(p => item.RoomID == p.RoomID);
                        if (basic != null)
                        {
                            var summary = charge_summary_list.FirstOrDefault(p => p.ID == item.ChargeID);
                            if (summary == null)
                            {
                                count1 += (basic.ContractArea > 0 ? basic.ContractArea : 0);
                            }
                            else
                            {
                                count1 += DoCalculateUseCount(basic, summary);
                            }
                        }
                    }
                    var basic_list = Foresight.DataAccess.RoomBasic.GetRoomBasicListByContractID(this.ContractID);
                    count2 = basic_list.Where(p => !charge_roomid_list.Contains(p.RoomID)).Sum(p => (p.ContractArea > 0 ? p.ContractArea : 0));

                    UseCountList[this.ID] = count1 + count2;
                    return UseCountList[this.ID];
                }
                if (this.CalculateAreaType.Equals(Utility.EnumModel.ChargeSummaryCalculateAreaType.jifei.ToString()))
                {
                    CalculateUseCount = this.BuildingArea;
                }
                else if (this.CalculateAreaType.Equals(Utility.EnumModel.ChargeSummaryCalculateAreaType.jianzhu.ToString()))
                {
                    CalculateUseCount = this.BuildOutArea;
                }
                else if (this.CalculateAreaType.Equals(Utility.EnumModel.ChargeSummaryCalculateAreaType.taonei.ToString()))
                {
                    CalculateUseCount = this.BuildInArea;
                }
                else if (this.CalculateAreaType.Equals(Utility.EnumModel.ChargeSummaryCalculateAreaType.gongtan.ToString()))
                {
                    CalculateUseCount = this.GonTanArea;
                }
                else if (this.CalculateAreaType.Equals(Utility.EnumModel.ChargeSummaryCalculateAreaType.chanquan.ToString()))
                {
                    CalculateUseCount = this.ChanQuanArea;
                }
                else if (this.CalculateAreaType.Equals(Utility.EnumModel.ChargeSummaryCalculateAreaType.shiyong.ToString()))
                {
                    CalculateUseCount = this.UseArea;
                }
                else if (this.CalculateAreaType.Equals(Utility.EnumModel.ChargeSummaryCalculateAreaType.peitao.ToString()))
                {
                    CalculateUseCount = this.PeiTaoArea;
                }
                if (CalculateUseCount > 0)
                {
                    UseCountList[this.ID] = CalculateUseCount;
                    return UseCountList[this.ID];
                }
                UseCountList[this.ID] = this.ContractArea > 0 ? this.ContractArea : 0;
                return UseCountList[this.ID];
            }
        }
        public decimal CalculateUnitPrice
        {
            get
            {
                if (this.RoomUnitPrice > 0)
                {
                    return this.RoomUnitPrice;
                }
                if (this.SummaryUnitPrice > 0)
                {
                    return this.SummaryUnitPrice;
                }
                return 0;
            }
        }
        public List<Dictionary<string, object>> ActiveTimeRange
        {
            get
            {
                var list = new List<Dictionary<string, object>>();
                if (this.ContractID == 0)
                {
                    return list;
                }
                var FreeTimeList = GetContractFreeTimeList();
                var my_list = FreeTimeList.Where(p => p.ContractID == this.ContractID).ToArray();
                if (my_list.Length == 0)
                {
                    return list;
                }
                foreach (var item in my_list)
                {
                    List<int> ChargeIDList = item.FreeChargeIDs.Split(',').Select(p => { return Convert.ToInt32(p); }).ToList();
                    if (!ChargeIDList.Contains(this.ChargeID))
                    {
                        continue;
                    }
                    if (item.FreeStartTime == DateTime.MinValue || item.FreeEndTime == DateTime.MinValue)
                    {
                        continue;
                    }
                    if (item.FreeStartTime > item.FreeEndTime)
                    {
                        continue;
                    }
                    if (item.FreeStartTime >= this.CalculateEndTime || item.FreeEndTime <= this.CalculateStartTime)
                    {
                        continue;
                    }
                    var dic = new Dictionary<string, object>();
                    if (item.FreeStartTime >= this.CalculateStartTime && item.FreeEndTime <= this.CalculateEndTime)
                    {
                        dic = new Dictionary<string, object>();
                        dic["StartTime"] = item.FreeStartTime;
                        dic["EndTime"] = item.FreeEndTime;
                        dic["FreeType"] = item.FreeType;
                        list.Add(dic);
                    }
                    else if (item.FreeStartTime <= this.CalculateStartTime && item.FreeEndTime >= this.CalculateEndTime)
                    {
                        dic = new Dictionary<string, object>();
                        dic["StartTime"] = this.CalculateStartTime;
                        dic["EndTime"] = this.CalculateEndTime;
                        dic["FreeType"] = item.FreeType;
                        list.Add(dic);
                    }
                    else if (item.FreeStartTime >= this.CalculateStartTime && item.FreeEndTime >= this.CalculateEndTime)
                    {
                        dic = new Dictionary<string, object>();
                        dic["StartTime"] = item.FreeStartTime;
                        dic["EndTime"] = this.CalculateEndTime;
                        dic["FreeType"] = item.FreeType;
                        list.Add(dic);
                    }
                    else if (item.FreeStartTime <= this.CalculateStartTime && item.FreeEndTime <= this.CalculateEndTime)
                    {
                        dic = new Dictionary<string, object>();
                        dic["StartTime"] = this.CalculateStartTime;
                        dic["EndTime"] = item.FreeEndTime;
                        dic["FreeType"] = item.FreeType;
                        list.Add(dic);
                    }
                }
                return list;
            }
        }
        public decimal CalculateReduceCost
        {
            get
            {
                if (this.ActiveTimeRange.Count == 0)
                {
                    return 0;
                }
                decimal reduce_cost = 0;
                foreach (var item in ActiveTimeRange)
                {
                    int _FreeType = 0;
                    int.TryParse(item["FreeType"].ToString(), out _FreeType);
                    if (_FreeType == 1)
                    {
                        DateTime _StartTime = DateTime.MinValue;
                        DateTime.TryParse(item["StartTime"].ToString(), out _StartTime);
                        DateTime _EndTime = DateTime.MinValue;
                        DateTime.TryParse(item["EndTime"].ToString(), out _EndTime);
                        reduce_cost += RoomFeeAnalysisBase.CalculateTotalCostByTime(_StartTime, _EndTime, contractSummary: this);
                    }
                }
                return reduce_cost;
            }
        }
        public decimal CalcualteTotalCost
        {
            get
            {
                try
                {
                    decimal totalcost = RoomFeeAnalysisBase.CalculateTotalCostByTime(this.CalculateStartTime, this.CalculateEndTime, contractSummary: this);
                    decimal cost = totalcost - this.CalculateReduceCost;
                    return cost > 0 ? cost : 0;
                }
                catch (Exception ex)
                {
                    Utility.LogHelper.WriteError("ViewContractChargeSummary", this.ContractID + "-" + this.ID, ex);
                    return 0;
                }
            }
        }
        public decimal CalcualteDiscount
        {
            get
            {
                decimal result = (CalcualteJianMianDiscount > 0 ? CalcualteJianMianDiscount : 0) + (CalcualteHistoryDiscount > 0 ? CalcualteHistoryDiscount : 0);
                return (result > 0 ? result : 0);
            }
        }
        public decimal CalcualteJianMianDiscount
        {
            get
            {
                if (this.ActiveTimeRange.Count == 0)
                {
                    return 0;
                }
                decimal reduce_cost = 0;
                foreach (var item in ActiveTimeRange)
                {
                    int _FreeType = 0;
                    int.TryParse(item["FreeType"].ToString(), out _FreeType);
                    if (_FreeType == 2)
                    {
                        DateTime _StartTime = DateTime.MinValue;
                        DateTime.TryParse(item["StartTime"].ToString(), out _StartTime);
                        DateTime _EndTime = DateTime.MinValue;
                        DateTime.TryParse(item["EndTime"].ToString(), out _EndTime);
                        reduce_cost += RoomFeeAnalysisBase.CalculateTotalCostByTime(_StartTime, _EndTime, contractSummary: this);
                    }
                }
                return reduce_cost;
            }
        }
        public decimal CalcualteRestCost
        {
            get
            {
                decimal restcost = this.CalcualteTotalCost - this.CalcualtePayCost - this.CalcualteDiscount;
                return restcost > 0 ? restcost : 0;
            }
        }
        public decimal CalcualtePayCost
        {
            get
            {
                decimal cost = 0;
                if (ViewRoomFeeHistoryDetailList != null && ViewRoomFeeHistoryDetailList.Length > 0)
                {
                    cost = ViewRoomFeeHistoryDetailList.Where(p => p.Contract_RoomChargeID == this.ID).Sum(p => p.MonthTotalCost);
                }
                return cost;
            }
        }
        public decimal CalcualteHistoryDiscount
        {
            get
            {
                decimal cost = 0;
                if (ViewRoomFeeHistoryDetailList != null && ViewRoomFeeHistoryDetailList.Length > 0)
                {
                    cost = ViewRoomFeeHistoryDetailList.Where(p => p.Contract_RoomChargeID == this.ID && p.Discount > 0).Sum(p => p.Discount);
                }
                return cost;
            }
        }
        public string ChargeTypeDesc
        {
            get
            {
                string desc = string.Empty;
                switch (this.TypeID)
                {
                    case 1:
                        desc = "单价*计费面积(月度)";
                        break;
                    case 2:
                        desc = "定额(月度)";
                        break;
                    case 3:
                        desc = "单价*计费面积*公摊系数(月度)";
                        break;
                    case 4:
                        desc = "定额(年度)";
                        break;
                    case 5:
                        desc = "单价*计费面积(按天)";
                        break;
                    case 6:
                        desc = "单价*计费面积/用量(一次性)";
                        break;
                    default:
                        break;
                }
                return desc;
            }
        }
        public string CategoryDesc
        {
            get
            {
                string desc = string.Empty;
                switch (this.CategoryID)
                {
                    case 1:
                        desc = "收入";
                        break;
                    case 2:
                        desc = "代收";
                        break;
                    case 3:
                        desc = "押金";
                        break;
                    case 4:
                        desc = "预收";
                        break;
                    default:
                        break;
                }
                return desc;
            }
        }
        public decimal RestCost { get; set; }
        #endregion
        #region 公用静态方法
        public static void ReSetParams()
        {
            InPutStartTime = DateTime.MinValue;
            InPutEndTime = DateTime.MinValue;
            ratecostlist = new List<decimal>();
            PriceRangeList = null;
            UseCountList = new Dictionary<int, decimal>();
            ContractFreeTimeList = null;
            ViewRoomFeeHistoryDetailList = null;
        }
        public static Ui.DataGrid GetViewContractChargeSummaryGrid(int ContractID, string guid, DateTime StartTime, DateTime EndTime, string orderBy, long startRowIndex, int pageSize, bool IsLinShi = false, int UserID = 0, List<int> RoomIDList = null, List<int> ProjectIDList = null, string keywords = "", string ContractStatus = "", bool IsWarning = false, bool includefooter = false, DateTime? ReadyStartTime = null, DateTime? ReadyEndTime = null, int FeeStatus = 0, List<int> ChargeIDList = null, bool canexport = false)
        {
            ReSetParams();
            long totalRows = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("isnull([ChargeID],0)!=0");
            if (ChargeIDList != null && ChargeIDList.Count > 0)
            {
                conditions.Add("[ChargeID] in (" + string.Join(",", ChargeIDList.ToArray()) + ")");
            }
            if (ReadyStartTime.HasValue)
            {
                DateTime _ReadyStartTime = Convert.ToDateTime(ReadyStartTime);
                if (_ReadyStartTime > DateTime.MinValue)
                {
                    conditions.Add("([ReadyChargeTime]>=@ReadyStartTime or [ReadyChargeTime] is null)");
                    parameters.Add(new SqlParameter("@ReadyStartTime", ReadyStartTime));
                }
            }
            if (ReadyEndTime.HasValue)
            {
                DateTime _ReadyEndTime = Convert.ToDateTime(ReadyEndTime);
                if (_ReadyEndTime > DateTime.MinValue)
                {
                    conditions.Add("([ReadyChargeTime]<=@ReadyEndTime or [ReadyChargeTime] is null)");
                    parameters.Add(new SqlParameter("@ReadyEndTime", ReadyEndTime));
                }
            }
            if (ProjectIDList != null && ProjectIDList.Count > 0)
            {
                List<string> cmdlist = ViewRoomFeeHistory.GetProjectIDListConditions(ProjectIDList, IncludeRelation: false, RoomIDName: "[RoomID]", IsContractFee: true, UserID: UserID);
                conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
            }
            if (RoomIDList != null && RoomIDList.Count > 0)
            {
                List<string> cmdlist = ViewRoomFeeHistory.GetRoomIDListConditions(RoomIDList, IncludeRelation: false, RoomIDName: "[RoomID]", IsContractFee: true);
                conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
            }
            if (!string.IsNullOrEmpty(keywords))
            {
                conditions.Add("(ContractID in (select ID from Contract where [RentName] like @keywords or [ContractNo] like  @keywords or [ContractName] like @keywords) or [Name] like @keywords)");
                parameters.Add(new SqlParameter("@keywords", "%" + keywords + "%"));
            }
            if (!string.IsNullOrEmpty(ContractStatus))
            {
                conditions.Add("ContractID in (select ID from Contract where [ContractStatus]=@ContractStatus)");
                parameters.Add(new SqlParameter("@ContractStatus", ContractStatus));
            }
            if (IsWarning)
            {
                conditions.Add("([ReadyChargeTime]<=@ReadyChargeTime or [ReadyChargeTime] is null)");
                parameters.Add(new SqlParameter("@ReadyChargeTime", DateTime.Now));
            }
            if (IsLinShi)
            {
                conditions.Add("[ChargeID] in (select ID from ChargeSummary where [FeeType]=4)");
            }
            if (ContractID > 0)
            {
                conditions.Add("[ContractID]=@ContractID");
                parameters.Add(new SqlParameter("@ContractID", ContractID));
            }
            else if (!string.IsNullOrEmpty(guid))
            {
                conditions.Add("[GUID]=@GUID");
                parameters.Add(new SqlParameter("@GUID", guid));
            }
            string fieldList = "[ViewContractChargeSummary].*";
            string Statement = " from [ViewContractChargeSummary] where  " + string.Join(" and ", conditions.ToArray());
            ViewContractChargeSummary[] list = new ViewContractChargeSummary[] { };
            if (FeeStatus == 0)
            {
                if (canexport)
                {
                    list = GetList<ViewContractChargeSummary>("select " + fieldList + Statement + " " + orderBy, parameters).ToArray();
                }
                else
                {
                    list = GetList<ViewContractChargeSummary>(fieldList, Statement, parameters, orderBy, startRowIndex, pageSize, out totalRows).ToArray();
                }

                if (list.Length > 0)
                {
                    var RoomFeeIDList = list.Where(p => p.RoomFeeID > 0).Select(p => p.RoomFeeID).ToList();
                    var ContractChargeIDList = list.Select(p => p.ID).ToList();
                    ViewRoomFeeHistoryDetailList = ViewRoomFeeHistoryDetail.GetViewRoomFeeHistoryDetailList(new List<int>(), StartTime, EndTime, StartTime, EndTime, new List<int>(), RoomFeeIDList, ContractChargeIDList, UserID: UserID, RequireOrderBy: false).Where(p => p.MonthTotalCost > 0).ToArray();
                }
                DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
                dg.rows = list;
                dg.total = totalRows;
                dg.page = pageSize;
                return dg;
            }
            else
            {
                list = GetList<ViewContractChargeSummary>("select * from [ViewContractChargeSummary] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
                if (list.Length > 0)
                {
                    var RoomFeeIDList = list.Where(p => p.RoomFeeID > 0).Select(p => p.RoomFeeID).ToList();
                    var ContractChargeIDList = list.Select(p => p.ID).ToList();
                    ViewRoomFeeHistoryDetailList = ViewRoomFeeHistoryDetail.GetViewRoomFeeHistoryDetailList(new List<int>(), StartTime, EndTime, StartTime, EndTime, new List<int>(), RoomFeeIDList, ContractChargeIDList, UserID: UserID, RequireOrderBy: false).Where(p => p.MonthTotalCost > 0).ToArray();
                }
                if (FeeStatus == 1)
                {
                    list = list.Where(p => p.CalcualtePayCost == 0 || p.CalcualteRestCost > 0).ToArray();
                }
                else if (FeeStatus == 2)
                {
                    list = list.Where(p => p.CalcualtePayCost > 0 && p.CalcualteRestCost == 0).ToArray();
                }
                totalRows = list.Length;
                int StartRowIndex = Convert.ToInt32(startRowIndex);
                var finallist = list.Skip(StartRowIndex).Take(pageSize).ToArray();
                DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
                dg.rows = finallist;
                dg.total = totalRows;
                dg.page = pageSize;
                return dg;
            }
        }
        public static ViewContractChargeSummary GetViewContractChargeSummaryByID(int ID)
        {
            ReSetParams();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@ID", ID));
            return GetOne<ViewContractChargeSummary>("select * from [ViewContractChargeSummary] where [ID]= @ID", parameters);
        }
        public static ViewContractChargeSummary[] GetViewContractChargeSummaryByContractID(int ContractID)
        {
            ReSetParams();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@ContractID", ContractID));
            return GetList<ViewContractChargeSummary>("select * from [ViewContractChargeSummary] where [ContractID]= @ContractID", parameters).ToArray();
        }
        public static ViewContractChargeSummary[] GetViewContractChargeSummaryByProjectIDList(List<int> RoomIDList, List<int> ProjectIDList, int UserID = 0)
        {
            ReSetParams();
            List<string> conditions = new List<string>();
            if (ProjectIDList.Count > 0)
            {
                List<string> cmdlist = ViewRoomFeeHistory.GetProjectIDListConditions(ProjectIDList, IncludeRelation: false, RoomIDName: "[RoomID]", IsContractFee: true, UserID: UserID);
                conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
            }
            if (RoomIDList.Count > 0)
            {
                List<string> cmdlist = ViewRoomFeeHistory.GetRoomIDListConditions(RoomIDList, IncludeRelation: false, RoomIDName: "[RoomID]", IsContractFee: true);
                conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
            }
            List<SqlParameter> parameters = new List<SqlParameter>();
            return GetList<ViewContractChargeSummary>("select * from [ViewContractChargeSummary] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
        public static ViewContractChargeSummary[] GetViewContractChargeSummaryListByIDList(List<int> IDList)
        {
            ReSetParams();
            List<SqlParameter> parameters = new List<SqlParameter>();
            if (IDList.Count == 0)
            {
                return new ViewContractChargeSummary[] { };
            }
            return GetList<ViewContractChargeSummary>("select * from [ViewContractChargeSummary] where [ID] in (" + string.Join(",", IDList.ToArray()) + ")", parameters).ToArray();
        }
        #endregion
        #region 私有静态方法
        private static decimal GetJieTiUnitPrice(int ChargeID, decimal CalculateUseCount)
        {
            decimal JieTieUnitPrice = 0;
            var ChargePriceRangeList = GetPriceRangeList();
            foreach (var item in ChargePriceRangeList)
            {
                if (item.SummaryID == ChargeID)
                {
                    if (CalculateUseCount >= Convert.ToDecimal(item.MinValue) && CalculateUseCount < Convert.ToDecimal(item.MaxValue))
                    {
                        JieTieUnitPrice = item.BasePrice;
                        break;
                    }
                }
            }
            return JieTieUnitPrice;
        }
        private static void calculateRateCost(decimal CalculateUnitPrice, int startnumber, int weiyuedays, decimal WeiYuePercent)
        {
            if (startnumber == 0)
            {
                ratecostlist = new List<decimal>();
            }
            startnumber++;
            if (startnumber > weiyuedays)
            {
                return;
            }
            decimal totalcost = CalculateUnitPrice * (1 + WeiYuePercent / 100);
            ratecostlist.Add(totalcost);
            calculateRateCost(totalcost, startnumber, weiyuedays, WeiYuePercent);
            return;
        }
        private static decimal DoCalculateUseCount(RoomBasic basic, ChargeSummary summary)
        {
            decimal CalculateUseCount = 0;
            if (summary.CalculateAreaType.Equals(Utility.EnumModel.ChargeSummaryCalculateAreaType.jifei.ToString()))
            {
                CalculateUseCount = basic.BuildingArea;
            }
            else if (summary.CalculateAreaType.Equals(Utility.EnumModel.ChargeSummaryCalculateAreaType.jianzhu.ToString()))
            {
                CalculateUseCount = basic.BuildOutArea;
            }
            else if (summary.CalculateAreaType.Equals(Utility.EnumModel.ChargeSummaryCalculateAreaType.taonei.ToString()))
            {
                CalculateUseCount = basic.BuildInArea;
            }
            else if (summary.CalculateAreaType.Equals(Utility.EnumModel.ChargeSummaryCalculateAreaType.gongtan.ToString()))
            {
                CalculateUseCount = basic.GonTanArea;
            }
            else if (summary.CalculateAreaType.Equals(Utility.EnumModel.ChargeSummaryCalculateAreaType.chanquan.ToString()))
            {
                CalculateUseCount = basic.ChanQuanArea;
            }
            else if (summary.CalculateAreaType.Equals(Utility.EnumModel.ChargeSummaryCalculateAreaType.shiyong.ToString()))
            {
                CalculateUseCount = basic.UseArea;
            }
            else if (summary.CalculateAreaType.Equals(Utility.EnumModel.ChargeSummaryCalculateAreaType.peitao.ToString()))
            {
                CalculateUseCount = basic.PeiTaoArea;
            }
            if (CalculateUseCount > 0)
            {
                return CalculateUseCount;
            }
            return basic.ContractArea > 0 ? basic.ContractArea : 0;
        }
        private static ChargePriceRange[] GetPriceRangeList()
        {
            if (PriceRangeList == null)
            {
                PriceRangeList = ChargePriceRange.GetChargePriceRangeList();
            }
            return PriceRangeList;
        }
        private static Contract_FreeTime[] GetContractFreeTimeList()
        {
            if (ContractFreeTimeList == null)
            {
                ContractFreeTimeList = Contract_FreeTime.GetContract_FreeTimes().Where(p => !string.IsNullOrEmpty(p.FreeChargeIDs)).ToArray();
            }
            return ContractFreeTimeList;
        }
        #endregion
    }
}
