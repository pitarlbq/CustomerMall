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
    /// This object represents the properties and methods of a ViewContract_TempPrice.
    /// </summary>
    public partial class ViewContract_TempPrice : EntityBaseReadOnly
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
        [DatabaseColumn("ContractID")]
        public int ContractID { get; set; }
        [DatabaseColumn("Contract_RoomChargeID")]
        public int Contract_RoomChargeID { get; set; }
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
                if (this.RoomID <= 0)
                {
                    return 0;
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
                        reduce_cost += RoomFeeAnalysisBase.CalculateTotalCostByTime(_StartTime, _EndTime, contractTempPrice: this);
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
                    decimal totalcost = RoomFeeAnalysisBase.CalculateTotalCostByTime(this.CalculateStartTime, this.CalculateEndTime, contractTempPrice: this);
                    decimal cost = totalcost - this.CalculateReduceCost;
                    return cost > 0 ? cost : 0;
                }
                catch (Exception ex)
                {
                    Utility.LogHelper.WriteError("ViewContract_TempPrice", this.ContractID + "-" + this.ID, ex);
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
                        reduce_cost += RoomFeeAnalysisBase.CalculateTotalCostByTime(_StartTime, _EndTime, contractTempPrice: this);
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
        public static Ui.DataGrid GetContract_TempPriceGridByGuid(string guid, string orderBy, long startRowIndex, int pageSize, int ChargeID, int ContractID = 0)
        {
            ReSetParams();
            long totalRows = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (ChargeID > 0)
            {
                conditions.Add("[ChargeID]=@ChargeID");
                parameters.Add(new SqlParameter("@ChargeID", ChargeID));
            }
            if (!string.IsNullOrEmpty(guid))
            {
                conditions.Add("[GUID]=@guid");
                parameters.Add(new SqlParameter("@guid", guid));
            }
            string fieldList = "A.* ";
            string Statement = " from (select [ViewContract_TempPrice].*,(select top 1 ID from [Contract_RoomCharge] where [Contract_TempPriceID]=[ViewContract_TempPrice].ID) as Contract_RoomChargeID, " + ContractID + " as ContractID from [ViewContract_TempPrice])A where  " + string.Join(" and ", conditions.ToArray());
            ViewContract_TempPrice[] list = GetList<ViewContract_TempPrice>(fieldList, Statement, parameters, orderBy, startRowIndex, pageSize, out totalRows).ToArray();
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
        #endregion
        #region 私有静态方法
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
