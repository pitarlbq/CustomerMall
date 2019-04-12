using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;

using Foresight.DataAccess.Framework;
using Utility;
using System.Linq;

namespace Foresight.DataAccess
{
    /// <summary>
    /// This object represents the properties and methods of a ViewImportFee.
    /// </summary>
    public partial class ViewImportFee : EntityBaseReadOnly
    {
        [DatabaseColumn("RoomName")]
        public string RoomName { get; set; }
        [DatabaseColumn("RoomFullName")]
        public string RoomFullName { get; set; }
        [DatabaseColumn("LastEndPoint")]
        public decimal LastEndPoint { get; set; }
        [DatabaseColumn("LastEndTime")]
        public DateTime LastEndTime { get; set; }
        [DatabaseColumn("RelationName")]
        public string RelationName { get; set; }
        [DatabaseColumn("CuiShouCount")]
        public int CuiShouCount { get; set; }

    }
    public partial class ViewImportFeeDetail : ViewImportFeeDetail2
    {
        [DatabaseColumn("HistoryStartTime")]
        public DateTime HistoryStartTime { get; set; }
        [DatabaseColumn("HistoryEndTime")]
        public DateTime HistoryEndTime { get; set; }
        [DatabaseColumn("HistoryUseCount")]
        public decimal HistoryUseCount { get; set; }
        [DatabaseColumn("HistoryUnitPrice")]
        public decimal HistoryUnitPrice { get; set; }
        [DatabaseColumn("HistoryRealCost")]
        public decimal HistoryRealCost { get; set; }
        [DatabaseColumn("WeiShou")]
        public int WeiShou { get; set; }
        [DatabaseColumn("YiShou")]
        public int YiShou { get; set; }
        public string ChargeStatusDesc
        {
            get
            {
                if (this.FullName.Equals("总合计"))
                {
                    return string.Empty;
                }
                if (this.YiShou == 1)
                {
                    return "已收";
                }
                return "未收";
            }
        }
        public DateTime FinalStartTime
        {
            get
            {
                return this.YiShou == 1 ? this.HistoryStartTime : this.StartTime;
            }
        }
        public DateTime FinalEndTime
        {
            get
            {
                return this.YiShou == 1 ? this.HistoryEndTime : this.EndTime;
            }
        }
        public decimal FinalUseCount
        {
            get
            {
                if (this.FullName.Equals("总合计"))
                {
                    return this.HistoryUseCount;
                }
                return this.YiShou == 1 ? this.HistoryUseCount : this.TotalPoint;
            }
        }
        public decimal FinalUnitPrice
        {
            get
            {
                if (this.FullName.Equals("总合计"))
                {
                    return 0;
                }
                return this.YiShou == 1 ? this.HistoryUnitPrice : this.UnitPrice;
            }
        }
        public decimal FinalRealCost
        {
            get
            {
                if (this.FullName.Equals("总合计"))
                {
                    return this.HistoryRealCost;
                }
                return this.YiShou == 1 ? this.HistoryRealCost : this.FinalTotalPrice;
            }
        }
        public static Ui.DataGrid GetChaoBiaoAnalysisDetailGrid(string Keywords, List<int> ChargeIDList, List<int> RoomIDList, List<int> ProjectIDList, int ChargeStatus, DateTime StartWriteDate, DateTime EndWriteDate, string BiaoCategory, string orderBy, long startRowIndex, int pageSize, List<int> ImportFeeIDList = null, bool canexport = false)
        {
            long totalRows = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            #region search conditions
            List<string> conditions = new List<string>();
            if (ImportFeeIDList != null && ImportFeeIDList.Count > 0)
            {
                conditions.Add("[ID] in (" + string.Join(",", ImportFeeIDList.ToArray()) + ")");
            }
            conditions.Add("[ChargeID] in (select [ID] from [ChargeSummary] where [IsReading]=1)");
            #region 关键字查询
            string cmd = string.Empty;
            if (!string.IsNullOrEmpty(Keywords))
            {
                string[] keywords = Keywords.Trim().Split(' ');
                for (int i = 0; i < keywords.Length; i++)
                {
                    if (string.IsNullOrEmpty(keywords[i].ToString()))
                    {
                        continue;
                    }
                    if (i + 1 == keywords.Length)
                    {
                        if (keywords.Length == 1)
                        {
                            cmd += "  and  ([FullName] like '%" + keywords[i] + "%' or [Name] like '%" + keywords[i] + "%')";
                        }
                        else
                        {
                            cmd += "  ([FullName] like '%" + keywords[i] + "%' or [Name] like '%" + keywords[i] + "%'))";
                        }
                    }
                    else if (i == 0)
                    {
                        cmd += " and (([FullName] like '%" + keywords[i] + "%' or [Name] like '%" + keywords[i] + "%') or";
                    }
                    else
                    {
                        cmd += "  ([FullName] like '%" + keywords[i] + "%' or [Name] like '%" + keywords[i] + "%') or ";
                    }
                }
            }
            #endregion
            if (!string.IsNullOrEmpty(BiaoCategory))
            {
                conditions.Add("([ImportBiaoCategory] like '%" + BiaoCategory + "%' or [BiaoCategory] like '%" + BiaoCategory + "%')");
            }
            if (StartWriteDate > DateTime.MinValue)
            {
                conditions.Add("[WriteDate]>=@StartWriteDate");
                parameters.Add(new SqlParameter("@StartWriteDate", StartWriteDate));
            }
            if (EndWriteDate > DateTime.MinValue)
            {
                conditions.Add("[WriteDate]<=@EndWriteDate");
                parameters.Add(new SqlParameter("@EndWriteDate", EndWriteDate));
            }
            if (ProjectIDList.Count > 0)
            {
                List<string> cmdlist = new List<string>();
                foreach (var ProjectID in ProjectIDList)
                {
                    cmdlist.Add("[AllParentID] like '%," + ProjectID + ",%'");
                }
                conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
            }
            if (RoomIDList.Count > 0)
            {
                List<string> cmdlist = ViewRoomFeeHistory.GetRoomIDListConditions(RoomIDList, IncludeRelation: false);
                conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
            }
            if (ChargeIDList.Count > 0)
            {
                conditions.Add("[ChargeID] in (" + string.Join(",", ChargeIDList.ToArray()) + ")");
            }
            if (ChargeStatus != int.MinValue)
            {
                if (ChargeStatus == 99)
                {
                    conditions.Add("(A.WeiShou=1 or A.YiShou=1)");
                }
                else if (ChargeStatus == 0)
                {
                    conditions.Add("A.YiShou != 1");
                }
                else if (ChargeStatus == 1)
                {
                    conditions.Add("A.YiShou = 1");
                }
            }
            #endregion
            string fieldList = @"A.*, (case when A.YiShou=1 then (select top 1 StartTime from [RoomFeeHistory] 
where [RoomFeeHistory].ImportFeeID=A.ID and ChargeState in (1,4)) end) as HistoryStartTime, 
(case when A.YiShou=1 then (select top 1 EndTime from [RoomFeeHistory] 
where [RoomFeeHistory].ImportFeeID=A.ID and ChargeState in (1,4)) end) as HistoryEndTime,
(case when A.YiShou=1 then (select top 1 UseCount from [RoomFeeHistory] 
where [RoomFeeHistory].ImportFeeID=A.ID and ChargeState in (1,4)) end) as HistoryUseCount,
(case when A.YiShou=1 then (select top 1 UnitPrice from [RoomFeeHistory] 
where [RoomFeeHistory].ImportFeeID=A.ID and ChargeState in (1,4)) end) as HistoryUnitPrice,
(case when A.YiShou=1 then (select top 1 RealCost from [RoomFeeHistory] 
where [RoomFeeHistory].ImportFeeID=A.ID and ChargeState in (1,4)) end) as HistoryRealCost";
            string Statement = " from (select *,(case when exists (select top 1 [ImportFeeID] from [RoomFee] where isnull(IsStart,1)=1 and isnull(IsCharged,0)=0 and RoomFee.ImportFeeID=ViewImportFee.ID) then 1 else 0 end) as WeiShou,(case when exists (select top 1 [ImportFeeID] from [RoomFeeHistory] where ChargeState in (1,4) and RoomFeeHistory.ImportFeeID=ViewImportFee.ID) then 1 else 0 end) as YiShou from [ViewImportFee] where ([ID] in (select [ImportFeeID] from [RoomFee] where isnull(IsStart,1)=1 and isnull(IsCharged,0)=0) or [ID] in (select [ImportFeeID] from [RoomFeeHistory] where ChargeState in (1,4))))A where" + string.Join(" and ", conditions.ToArray()) + cmd;
            ViewImportFeeDetail[] list = new ViewImportFeeDetail[] { };
            if (canexport)
            {
                list = GetList<ViewImportFeeDetail>("select " + fieldList + Statement + " " + orderBy, parameters).ToArray();
            }
            else
            {
                list = GetList<ViewImportFeeDetail>(fieldList, Statement, parameters, orderBy, startRowIndex, pageSize, out totalRows).ToArray();
            }
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            string footertext = @"select '总合计' as [FullName], sum(isnull(case when B.YiShou=1 then B.HistoryUseCount else B.TotalPoint end,0)) as HistoryUseCount, sum(isnull(case when B.YiShou=1 then B.HistoryRealCost else B.TotalPrice end,0)) as HistoryRealCost from
(select A.*, (case when A.YiShou=1 then (select top 1 StartTime from [RoomFeeHistory] 
where [RoomFeeHistory].ImportFeeID=A.ID and ChargeState in (1,4)) end) as HistoryStartTime, 
(case when A.YiShou=1 then (select top 1 EndTime from [RoomFeeHistory] 
where [RoomFeeHistory].ImportFeeID=A.ID and ChargeState in (1,4)) end) as HistoryEndTime,
(case when A.YiShou=1 then (select top 1 UseCount from [RoomFeeHistory] 
where [RoomFeeHistory].ImportFeeID=A.ID and ChargeState in (1,4)) end) as HistoryUseCount,
(case when A.YiShou=1 then (select top 1 UnitPrice from [RoomFeeHistory] 
where [RoomFeeHistory].ImportFeeID=A.ID and ChargeState in (1,4)) end) as HistoryUnitPrice,
(case when A.YiShou=1 then (select top 1 RealCost from [RoomFeeHistory] 
where [RoomFeeHistory].ImportFeeID=A.ID and ChargeState in (1,4)) end) as HistoryRealCost from (select *,(case when exists (select top 1 [ImportFeeID] from [RoomFee] where isnull(IsStart,1)=1 and isnull(IsCharged,0)=0 and RoomFee.ImportFeeID=ViewImportFee.ID) then 1 else 0 end) as WeiShou,(case when exists (select top 1 [ImportFeeID] from [RoomFeeHistory] where ChargeState in (1,4) and RoomFeeHistory.ImportFeeID=ViewImportFee.ID) then 1 else 0 end) as YiShou from [ViewImportFee] where ([ID] in (select [ImportFeeID] from [RoomFee] where isnull(IsStart,1)=1 and isnull(IsCharged,0)=0) or [ID] in (select [ImportFeeID] from [RoomFeeHistory] where ChargeState in (1,4))))A where" + string.Join(" and ", conditions.ToArray()) + cmd + ")B";
            dg.footer = GetList<ViewImportFeeDetail>(footertext, parameters).ToArray();
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
    }
    public partial class ViewImportFeeDetail2 : ViewImportFee
    {
        [DatabaseColumn("ReationID")]
        public int ReationID { get; set; }
        [DatabaseColumn("RelationProjectBiaoID")]
        public int RelationProjectBiaoID { get; set; }
        [DatabaseColumn("BiaoStartPoint")]
        public decimal BiaoStartPoint { get; set; }
        [DatabaseColumn("BiaoEndPoint")]
        public decimal BiaoEndPoint { get; set; }
        [DatabaseColumn("BiaoRate")]
        public decimal BiaoRate { get; set; }
        [DatabaseColumn("BiaoReducePoint")]
        public decimal BiaoReducePoint { get; set; }
        [DatabaseColumn("BiaoWriteDate")]
        public DateTime BiaoWriteDate { get; set; }
        [DatabaseColumn("RoomFeeID")]
        public int RoomFeeID { get; set; }
        public static ChargePriceRange[] PriceRangeList = null;
        public static ChargeFeePriceRange[] PriceFeeRangeList = null;
        public static Dictionary<int, decimal> totalpointdic = new Dictionary<int, decimal>();
        public static Dictionary<int, decimal> reducepointdic = new Dictionary<int, decimal>();
        public static Dictionary<int, decimal> unitpricedic = new Dictionary<int, decimal>();
        public static Dictionary<int, decimal> importcoefficientdic = new Dictionary<int, decimal>();
        public static Dictionary<int, decimal> totalpricedic = new Dictionary<int, decimal>();
        public bool IsPriceRange
        {
            get
            {
                if (this.StartPriceRange && this.PriceRangeStartTime <= DateTime.Now)
                {
                    return true;
                }
                return false;
            }
        }
        public decimal CalcualteTotalPoint
        {
            get
            {
                if (totalpointdic.ContainsKey(this.ID))
                {
                    return totalpointdic[this.ID];
                }
                decimal startpoint = this.StartPoint > 0 ? this.StartPoint : 0;
                decimal endpoint = this.EndPoint > 0 ? this.EndPoint : 0;
                if (this.ProjectBiaoID > 0)
                {
                    if (this.ImportRate <= 0)
                    {
                        this.ImportRate = 1;
                    }
                    decimal rate = this.ImportRate > 0 ? this.ImportRate : 0;
                    decimal reducepoint = this.FinalReducePoint > 0 ? this.FinalReducePoint : 0;
                    decimal totalpoint = ((endpoint - startpoint) * rate) - reducepoint;
                    totalpoint = (totalpoint > 0 ? totalpoint : 0);
                    totalpointdic.Add(this.ID, totalpoint);
                    return totalpoint;
                }
                var count = endpoint - startpoint;
                count = (count > 0 ? count : 0);
                totalpointdic.Add(this.ID, count);
                return count;
            }
        }
        public decimal FinalTotalPoint
        {
            get
            {
                decimal totalpoint = 0;
                decimal FinalEndPoint = 0;
                decimal FinalStartPoint = 0;
                decimal FinalRate = 0;
                decimal FinalReducePoint = 0;
                if (this.ID > 0)
                {
                    FinalEndPoint = this.EndPoint > 0 ? this.EndPoint : 0;
                    FinalStartPoint = this.StartPoint > 0 ? this.StartPoint : 0;
                    FinalRate = this.ImportRate > 0 ? this.ImportRate : 0;
                    FinalReducePoint = this.ImportReducePoint > 0 ? this.ImportReducePoint : 0;
                }
                else
                {
                    FinalEndPoint = this.BiaoEndPoint > 0 ? this.BiaoEndPoint : 0;
                    FinalStartPoint = this.BiaoStartPoint > 0 ? this.BiaoStartPoint : 0;
                    FinalRate = this.BiaoRate > 0 ? this.BiaoRate : 0;
                    FinalReducePoint = this.BiaoReducePoint > 0 ? this.BiaoReducePoint : 0;
                }
                totalpoint = (FinalEndPoint - FinalStartPoint) * FinalRate - FinalReducePoint;
                totalpoint = (totalpoint > 0 ? totalpoint : 0);
                return totalpoint;
            }
        }
        public decimal FinalReducePoint
        {
            get
            {
                decimal value = 0;
                if (reducepointdic.ContainsKey(this.ID))
                {
                    return reducepointdic[this.ID];
                }
                if (!this.ImportBiaoGuiGe.Equals("总表"))
                {
                    value = (this.ImportReducePoint > 0 ? this.ImportReducePoint : 0);
                    reducepointdic.Add(this.ID, value);
                    return value;
                }
                if (this.WriteDate == DateTime.MinValue)
                {
                    reducepointdic.Add(this.ID, 0);
                    return 0;
                }
                if (this.ProjectBiaoID <= 0 && this.RelationProjectBiaoID <= 0)
                {
                    reducepointdic.Add(this.ID, 0);
                    return 0;
                }
                var list = GetViewImportFeeDetail2ListByWriteDate(this.WriteDate, this.ProjectBiaoID);
                decimal final_reduce_point = list.Sum(p => p.FinalTotalPoint);
                value = (final_reduce_point > 0 ? final_reduce_point : 0);
                reducepointdic.Add(this.ID, value);
                return value;
            }
        }
        public decimal FinalUnitPrice
        {
            get
            {
                if (this.FinalChargeStatus == 1)
                {
                    return this.HistoryUnitPrice > 0 ? this.HistoryUnitPrice : 0;
                }
                if (unitpricedic.ContainsKey(this.ID))
                {
                    return unitpricedic[this.ID];
                }
                if (this.IsPriceRange)
                {
                    decimal unitprice = GetJieTiUnitPrice(this);
                    if (unitprice > 0)
                    {
                        unitpricedic.Add(this.ID, unitprice);
                        return unitprice;
                    }
                    unitpricedic.Add(this.ID, 0);
                    return 0;
                }
                if (this.UnitPrice >= 0)
                {
                    unitpricedic.Add(this.ID, this.UnitPrice);
                    return this.UnitPrice;
                }
                if (this.SummaryUnitPrice >= 0)
                {
                    unitpricedic.Add(this.ID, this.SummaryUnitPrice);
                    return this.SummaryUnitPrice;
                }
                unitpricedic.Add(this.ID, 0);
                return 0;
            }
        }
        public decimal FinalImportCoefficient
        {
            get
            {
                if (importcoefficientdic.ContainsKey(this.ID))
                {
                    return importcoefficientdic[this.ID];
                }
                if (importcoefficientdic.ContainsKey(this.ID))
                {
                    return importcoefficientdic[this.ID];
                }
                if (this.ImportCoefficient > 0)
                {
                    importcoefficientdic.Add(this.ID, this.ImportCoefficient);
                    return this.ImportCoefficient;
                }
                if (this.Coefficient > 0)
                {
                    importcoefficientdic.Add(this.ID, this.Coefficient);
                    return this.Coefficient;
                }
                importcoefficientdic.Add(this.ID, 0);
                return 0;
            }
        }
        public bool IsCharged
        {
            get
            {
                return this.ChargedHistoryID > 1;
            }
        }
        public decimal RealTotalPoint
        {
            get
            {
                if (this.FinalChargeStatus == 1)
                {
                    return this.HistoryUseCount > 0 ? this.HistoryUseCount : 0;
                }
                if (this.CalcualteTotalPoint > 0)
                {
                    return this.CalcualteTotalPoint;
                }
                if (this.TotalPoint > 0)
                {
                    return this.TotalPoint;
                }
                return 0;
            }
        }
        public decimal CalculateTotalPrice
        {
            get
            {
                if (totalpricedic.ContainsKey(this.ID))
                {
                    return totalpricedic[this.ID];
                }
                decimal cost = 0;
                #region 阶梯单价
                if (this.IsPriceRange)
                {
                    var ChargePriceRangeList = GetPriceRangeList(this);
                    if (ChargePriceRangeList.Length > 0)
                    {
                        var my_pricerangelist = ChargePriceRangeList.Where(p => p.SummaryID == this.ChargeID).ToArray();
                        for (var i = 0; i < my_pricerangelist.Length; i++)
                        {
                            var pricerange = my_pricerangelist[i];
                            decimal MinValue = 0;
                            decimal.TryParse(pricerange.MinValue, out MinValue);
                            decimal MaxValue = 0;
                            decimal.TryParse(pricerange.MaxValue, out MaxValue);
                            decimal NianTotal = 0;
                            if (pricerange.BaseType.Equals(Utility.EnumModel.PriceRangeType.qnyl.ToString()))
                            {
                                NianTotal = (this.TotalUseCount > 0 ? this.TotalUseCount : 0);
                            }
                            if ((NianTotal + this.RealTotalPoint) >= MinValue && (NianTotal + this.RealTotalPoint) < MaxValue)
                            {
                                if (NianTotal > MinValue)
                                {
                                    cost += this.RealTotalPoint * pricerange.BasePrice * (this.FinalImportCoefficient > 0 ? this.FinalImportCoefficient : 1);
                                }
                                else
                                {
                                    cost += (NianTotal + this.RealTotalPoint - MinValue) * pricerange.BasePrice * (this.FinalImportCoefficient > 0 ? this.FinalImportCoefficient : 1);
                                }
                                break;
                            }
                            if ((NianTotal + this.RealTotalPoint) >= MaxValue)
                            {
                                if (i == my_pricerangelist.Length - 1)
                                {
                                    cost += (NianTotal + this.RealTotalPoint - MinValue) * pricerange.BasePrice * (this.FinalImportCoefficient > 0 ? this.FinalImportCoefficient : 1);
                                    break;
                                }
                                if (pricerange.BaseType.Equals(Utility.EnumModel.PriceRangeType.qnyl.ToString()))
                                {
                                    if (MaxValue > NianTotal)
                                    {
                                        MinValue = (NianTotal > MinValue ? NianTotal : MinValue);
                                        cost += (MaxValue - MinValue) * pricerange.BasePrice * (this.FinalImportCoefficient > 0 ? this.FinalImportCoefficient : 1);
                                    }
                                }
                                else
                                {
                                    cost += (MaxValue - MinValue) * pricerange.BasePrice * (this.FinalImportCoefficient > 0 ? this.FinalImportCoefficient : 1);
                                }
                            }
                        }
                        cost = Math.Round(cost, this.EndNumberCount, MidpointRounding.AwayFromZero);
                        if (cost > 0)
                        {
                            totalpricedic.Add(this.ID, cost);
                            return cost;
                        }
                    }
                }
                #endregion
                #region 导入账单费用
                cost = this.RealTotalPoint * this.FinalUnitPrice * (this.FinalImportCoefficient > 0 ? this.FinalImportCoefficient : 1);
                if (cost > 0)
                {
                    cost = Math.Round(cost, this.EndNumberCount, MidpointRounding.AwayFromZero);
                    totalpricedic.Add(this.ID, cost);
                    return cost;
                }
                totalpricedic.Add(this.ID, 0);
                return 0;
                #endregion
            }
        }
        public decimal FinalTotalPrice
        {
            get
            {
                //if (this.FinalChargeStatus == 1)
                //{
                //    return this.HistoryRealCost > 0 ? this.HistoryRealCost : 0;
                //}
                if (this.CalculateTotalPrice > 0)
                {
                    return this.CalculateTotalPrice;
                }
                if (this.TotalPrice > 0)
                {
                    return this.TotalPrice;
                }
                return 0;
            }
        }
        /// <summary>
        /// 0-未收 1-已收 2-草稿
        /// </summary>
        public int FinalChargeStatus
        {
            get
            {
                if (this.RoomFeeID > 0)
                {
                    return 0;
                }
                if (this.HistoryID > 0)
                {
                    return 1;
                }
                return 2;
            }
        }
        public string StatusDesc
        {
            get
            {
                string typedesc = string.Empty;
                switch (this.FinalChargeStatus)
                {
                    case 0:
                        typedesc = "未收";
                        break;
                    case 1:
                        typedesc = "已收";
                        break;
                    case 2:
                        typedesc = "草稿";
                        break;
                    default:
                        typedesc = "";
                        break;
                }
                return typedesc;
            }
        }
        public static string CommSQLTable = "(select [ViewImportFee].*,(select top 1 [RelationName] from [RoomPhoneRelation] where isnull([IsDefault],0)=1 and [RoomID]=[ViewImportFee].[RoomID]) as [RelationName],(select Count(1) from RoomFeeHistory where [ImportFeeID]=ViewImportFee.ID and ChargeState=5) as CuiShouCount,(select top 1 ID from [RoomFee] where [RoomFee].ImportFeeID=ViewImportFee.ID) as RoomFeeID from [ViewImportFee])A";
        public static void ReSetParams()
        {
            PriceRangeList = null;
            PriceFeeRangeList = null;
            totalpointdic = new Dictionary<int, decimal>();
            reducepointdic = new Dictionary<int, decimal>();
            unitpricedic = new Dictionary<int, decimal>();
            importcoefficientdic = new Dictionary<int, decimal>();
            totalpricedic = new Dictionary<int, decimal>();
        }
        private static decimal GetJieTiUnitPrice(ViewImportFeeDetail2 self)
        {
            decimal JieTieUnitPrice = 0;
            var ChargePriceRangeList = GetPriceRangeList(self);
            foreach (var item in ChargePriceRangeList)
            {
                if (item.SummaryID == self.ChargeID)
                {
                    decimal NianTotal = 0;
                    if (item.BaseType.Equals(Utility.EnumModel.PriceRangeType.qnyl.ToString()))
                    {
                        NianTotal = (self.TotalUseCount > 0 ? self.TotalUseCount : 0);
                    }
                    if ((NianTotal + self.RealTotalPoint) >= Convert.ToDecimal(item.MinValue) && (NianTotal + self.RealTotalPoint) < Convert.ToDecimal(item.MaxValue))
                    {
                        JieTieUnitPrice = item.BasePrice;
                        break;
                    }
                }
            }
            return JieTieUnitPrice;
        }
        private static ChargePriceRange[] GetPriceRangeList(ViewImportFeeDetail2 self)
        {
            var list = new List<ChargePriceRange>();
            if (PriceRangeList == null || PriceRangeList.Length == 0)
            {
                PriceRangeList = ChargePriceRange.GetChargePriceRangeList();
            }
            if (PriceFeeRangeList == null)
            {
                PriceFeeRangeList = ChargeFeePriceRange.GetAllActiveChargeFeePriceRangeList();
            }
            if (self.RoomFeeID > 0)
            {
                if (PriceFeeRangeList != null && PriceFeeRangeList.Length > 0)
                {
                    var my_pricefee_list = PriceFeeRangeList.Where(p => p.RoomFeeID == self.RoomFeeID && p.SummaryID == self.ChargeID).ToArray();
                    foreach (var item in my_pricefee_list)
                    {
                        var data = new ChargePriceRange();
                        data.SummaryID = item.SummaryID;
                        data.MinValue = item.MinValue;
                        data.MaxValue = item.MaxValue;
                        data.BasePrice = item.BasePrice;
                        data.BaseType = item.BaseType;
                        data.IsActive = item.IsActive;
                        list.Add(data);
                    }
                }
                return list.OrderBy(p =>
                {
                    decimal minvalue = 0;
                    decimal.TryParse(p.MinValue, out minvalue);
                    return minvalue;
                }).ToArray();
            }
            else
            {
                if (PriceRangeList != null && PriceRangeList.Length > 0)
                {
                    list = PriceRangeList.Where(p => p.SummaryID == self.ChargeID).OrderBy(p =>
                    {
                        decimal minvalue = 0;
                        decimal.TryParse(p.MinValue, out minvalue);
                        return minvalue;
                    }).ToList();
                }
                return list.ToArray();
            }
        }
        public static Ui.DataGrid GetViewImportFeeGridByRoomID(string Keywords, List<int> FeeTypeList, List<int> RoomIDList, List<int> ProjectIDList, int ChargeID, int ChargeStatus, DateTime StartWriteDate, DateTime EndWriteDate, bool IsReading, bool AllowImport, string BiaoCategory, string orderBy, long startRowIndex, int pageSize, bool ShowFooter = false, bool canexport = false)
        {
            ReSetParams();
            long totalRows = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("([RoomID] in (select [RoomID] from [RoomBasic] where isnull([IsLocked],0)=0) or not exists (select * from [RoomBasic] where isnull([IsLocked],0)=0 and [RoomID]=A.[RoomID]))");
            #region 关键字查询
            string cmd = string.Empty;

            if (!string.IsNullOrEmpty(Keywords))
            {
                string[] keywords = Keywords.Trim().Split(' ');
                for (int i = 0; i < keywords.Length; i++)
                {
                    if (string.IsNullOrEmpty(keywords[i].ToString()))
                    {
                        continue;
                    }
                    if (i + 1 == keywords.Length)
                    {
                        if (keywords.Length == 1)
                        {
                            cmd += "  and  ([FullName] like '%" + keywords[i] + "%' or [Name] like '%" + keywords[i] + "%')";
                        }
                        else
                        {
                            cmd += "  ([FullName] like '%" + keywords[i] + "%' or [Name] like '%" + keywords[i] + "%'))";
                        }
                    }
                    else if (i == 0)
                    {
                        cmd += " and (([FullName] like '%" + keywords[i] + "%' or [Name] like '%" + keywords[i] + "%') or";
                    }
                    else
                    {
                        cmd += "  ([FullName] like '%" + keywords[i] + "%' or [Name] like '%" + keywords[i] + "%') or ";
                    }
                }
            }
            #endregion
            if (!string.IsNullOrEmpty(BiaoCategory))
            {
                conditions.Add("([ImportBiaoCategory] like '%" + BiaoCategory + "%' or [BiaoCategory] like '%" + BiaoCategory + "%')");
            }
            if (StartWriteDate > DateTime.MinValue)
            {
                conditions.Add("[WriteDate]>=@StartWriteDate");
                parameters.Add(new SqlParameter("@StartWriteDate", StartWriteDate));
            }
            if (EndWriteDate > DateTime.MinValue)
            {
                conditions.Add("[WriteDate]<=@EndWriteDate");
                parameters.Add(new SqlParameter("@EndWriteDate", EndWriteDate));
            }
            if (IsReading)
            {
                conditions.Add("[ChargeID] in (select [ID] from [ChargeSummary] where [IsReading]=1)");
            }
            if (AllowImport)
            {
                conditions.Add("[ChargeID] in (select [ID] from [ChargeSummary] where [IsAllowImport]=1 and ([IsReading]=0 or [IsReading] is null))");
            }
            if (ProjectIDList.Count > 0)
            {
                List<string> cmdlist = new List<string>();
                foreach (var ProjectID in ProjectIDList)
                {
                    cmdlist.Add("[AllParentID] like '%," + ProjectID + ",%'");
                }
                conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
            }
            if (RoomIDList.Count > 0)
            {
                List<string> cmdlist = ViewRoomFeeHistory.GetRoomIDListConditions(RoomIDList, IncludeRelation: false);
                conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
            }
            if (FeeTypeList.Count > 0)
            {
                conditions.Add("[ChargeID] in (select [ID] from [ChargeSummary] where [FeeType] in (" + string.Join(",", FeeTypeList.ToArray()) + "))");
            }
            if (ChargeID > 0)
            {
                conditions.Add("[ChargeID]=@ChargeID");
                parameters.Add(new SqlParameter("@ChargeID", ChargeID));
            }
            if (ChargeStatus == 0)
            {
                conditions.Add("[RoomFeeID]>0");
            }
            else if (ChargeStatus == 1)
            {
                conditions.Add("[HistoryID]>0");
            }
            else if (ChargeStatus == 2)
            {
                conditions.Add("(isnull([RoomFeeID],0)<=0 and isnull([HistoryID],0)<=0)");
            }
            string fieldList = "A.*";
            string Statement = " from " + CommSQLTable + " where " + string.Join(" and ", conditions.ToArray()) + cmd;
            ViewImportFeeDetail2[] list = new ViewImportFeeDetail2[] { };
            if (canexport)
            {
                list = GetList<ViewImportFeeDetail2>("select " + fieldList + Statement + " " + orderBy, parameters).ToArray();
                totalRows = list.Length;
            }
            else
            {
                list = GetList<ViewImportFeeDetail2>(fieldList, Statement, parameters, orderBy, startRowIndex, pageSize, out totalRows).ToArray();
            }
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            if (ShowFooter)
            {
                Dictionary<string, object> dic = new Dictionary<string, object>();
                dic["FullName"] = "合计";
                dic["RealTotalPoint"] = list.Sum(p => p.RealTotalPoint);
                dic["FinalTotalPrice"] = list.Sum(p => p.FinalTotalPrice);
                dg.footer = new Dictionary<string, object>[] { dic };
            }
            return dg;
        }
        public static ViewImportFeeDetail2[] GetViewImportFeeDetail2ListByWriteDate(DateTime WriteDate, int ID)
        {
            ReSetParams();
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("(isnull(A.[WriteDate],'')=@WriteDate or isnull(A.[BiaoWriteDate],'')=@WriteDate)");
            conditions.Add("A.[RelationProjectBiaoID]=@ID");
            conditions.Add("isnull(A.[ImportBiaoGuiGe],'')!='总表'");
            parameters.Add(new SqlParameter("@WriteDate", WriteDate));
            parameters.Add(new SqlParameter("@ID", ID));
            string cmdtext = @"select * from (select [ImportFee].*,Project_Biao.StartPoint as BiaoStartPoint, Project_Biao.EndPoint as BiaoEndPoint,Project_Biao.Rate as BiaoRate,Project_Biao.ReducePoint as BiaoReducePoint,Project_Biao.WriteDate as BiaoWriteDate,[ProjectBiao_Relation].ReationID,[ProjectBiao_Relation].ProjectBiaoID as RelationProjectBiaoID from [ProjectBiao_Relation] left join [ImportFee] on [ImportFee].ProjectBiaoID=[ProjectBiao_Relation].ReationID left join [Project_Biao] on [Project_Biao].ID=[ProjectBiao_Relation].ReationID)A where " + string.Join(" and ", conditions.ToArray());
            return GetList<ViewImportFeeDetail2>(cmdtext, parameters).ToArray();
        }
        public static ViewImportFeeDetail2[] GetViewImportFeeDetail2ListByID(List<int> IDList, string orderby = "")
        {
            ReSetParams();
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            string cmdwhere = string.Empty;
            if (IDList.Count > 0)
            {
                conditions.Add("[ID] in (" + string.Join(",", IDList.ToArray()) + ")");
            }
            ViewImportFeeDetail2[] list = new ViewImportFeeDetail2[] { };
            string cmdorderby = string.Empty;
            if (!string.IsNullOrEmpty(orderby))
            {
                if (orderby.ToLower().StartsWith("order by"))
                {
                    cmdorderby = orderby;
                }
                else
                {
                    cmdorderby = "order by " + orderby;
                }
            }
            string cmdText = "select A.* from " + CommSQLTable + " where " + string.Join(" and ", conditions.ToArray()) + cmdorderby;
            list = GetList<ViewImportFeeDetail2>(cmdText, parameters).ToArray();
            return list;
        }
        public static ViewImportFeeDetail2[] GetViewImportFeeDetail2ListByBiaoID(List<int> RoomIDList, List<int> ProjectIDList, int ChargeID = 0, DateTime? WriteDate = null, int BiaoID = 0, string BiaoCategory = "", string BiaoName = "", string BiaoGuiGe = "", int UserID = 0)
        {
            ReSetParams();
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (RoomIDList.Count > 0)
            {
                List<string> cmdlist = ViewRoomFeeHistory.GetRoomIDListConditions(RoomIDList, IncludeRelation: false);
                conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
            }
            if (ProjectIDList.Count > 0)
            {
                List<string> cmdlist = ViewRoomFeeHistory.GetProjectIDListConditions(ProjectIDList, IncludeRelation: false, UserID: UserID);
                conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
            }
            ViewImportFeeDetail2[] list = new ViewImportFeeDetail2[] { };
            if (ChargeID > 0)
            {
                parameters.Add(new SqlParameter("@ChargeID", ChargeID));
                conditions.Add("[ChargeID]=@ChargeID");
            }
            if (BiaoID > 0)
            {
                parameters.Add(new SqlParameter("@BiaoID", BiaoID));
                conditions.Add("[ChargeBiaoID]=@BiaoID");
            }
            if (!string.IsNullOrEmpty(BiaoCategory))
            {
                parameters.Add(new SqlParameter("@BiaoCategory", BiaoCategory));
                conditions.Add("[ImportBiaoCategory]=@BiaoCategory");
            }
            if (!string.IsNullOrEmpty(BiaoName))
            {
                parameters.Add(new SqlParameter("@BiaoName", BiaoName));
                conditions.Add("[ImportBiaoName]=@BiaoName");
            }
            if (!string.IsNullOrEmpty(BiaoGuiGe))
            {
                parameters.Add(new SqlParameter("@BiaoGuiGe", BiaoGuiGe));
                conditions.Add("[ImportBiaoGuiGe]=@BiaoGuiGe");
            }
            //if (WriteDate.HasValue)
            //{
            //    parameters.Add(new SqlParameter("@WriteDate", WriteDate));
            //    conditions.Add("[WriteDate]=(select top 1 WriteDate from [ViewImportFee] where WriteDate<@WriteDate and " + string.Join(" and ", conditions.ToArray()) + " order by WriteDate desc)");
            //}
            list = GetList<ViewImportFeeDetail2>("select * from [ViewImportFee] where  " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
            if (list.Length > 0 && WriteDate.HasValue)
            {
                var first_fee = list.Where(p => p.WriteDate < WriteDate).OrderByDescending(p => p.WriteDate).FirstOrDefault();
                if (first_fee != null)
                {
                    list = list.Where(p => p.WriteDate == first_fee.WriteDate).ToArray();
                }
            }
            return list;
        }
        public static ViewImportFeeDetail2[] GetViewImportFeeDetail2ListByID(List<int> IDList)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            string cmdwhere = string.Empty;
            if (IDList.Count > 0)
            {
                conditions.Add("[ID] in (" + string.Join(",", IDList.ToArray()) + ")");
            }
            string cmdText = "select * from [ViewImportFee] where " + string.Join(" and ", conditions.ToArray());
            var list = GetList<ViewImportFeeDetail2>(cmdText, parameters).ToArray();
            return list;
        }
    }
}
