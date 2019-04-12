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
    public partial class RoomFeeAnalysis : EntityBaseReadOnly
    {
        #region 数据库属性
        public static string columntext = @"select RoomFee.RoomFeeStartPoint
,ImportFee.StartPoint
,ImportFee.[EndPoint]
,RoomFee.RoomFeeEndPoint
,RoomFee.TotalRealCost
,ImportFee.ImportCoefficient
,RoomFee.RoomFeeCoefficient
,ChargeSummary.StartPriceRange
,ChargeSummary.PriceRangeStartTime
,RoomFee.ImportFeeID
,RoomFee.UseCount
,ImportFee.TotalPoint
,RoomFee.ContractID
,RoomBasic.ContractArea
,ChargeSummary.CalculateAreaType
,RoomBasic.BuildingArea
,RoomBasic.BuildOutArea
,RoomBasic.BuildInArea
,RoomBasic.GonTanArea
,RoomBasic.ChanQuanArea
,RoomBasic.UseArea
,RoomBasic.PeiTaoArea
,RoomFee.UnitPrice
,ChargeSummary.SummaryUnitPrice as SummaryUnitPrice
,RoomFee.CuiShouStartTime
,ChargeSummary.FeeType
,RoomFee.NewEndTime
,RoomFee.CuiShouEndTime
,RoomFee.EndTime
,RoomFee.StartTime
,RoomFee.RelatedFeeID
,ChargeSummary.WeiYueStartDate
,ChargeSummary.WeiYueDays
,ChargeSummary.WeiYueBefore
,RoomFee.ChargeID
,Contract_RoomCharge.ReadyChargeTime
,ChargeSummary.TypeID
,RoomFee.RoomID
,RoomFee.Contract_RoomChargeID
,ChargeSummary.EndNumberCount
,RoomFee.ContractDivideID
,RoomFee.ID
,ChargeSummary.ChargeWeiYueType
,ChargeSummary.WeiYuePercent
,ChargeSummary.DayGunLi
,RoomBasic.FenTanCoefficient
,RoomFee.IsMeterFee
,RoomFee.Cost
,(case when [ChargeSummary].StartPriceRange=0 then 0 else
(select sum(isnull(ImportFee_2.[TotalPoint],0)) from (select *,
(DATEADD(yy,DATEDIFF(yy,0,ImportFee.WriteDate),0)) as FinalWriteDate,[ChargeSummary].PriceRangeStartTime from [ImportFee] as ImportFee_1) as ImportFee_2 where
ImportFee_2.ChargeID=[ImportFee].ChargeID
and isnull([ImportFee_2].ChargeBiaoID,0)=isnull([ImportFee].ChargeBiaoID,0) and
[ImportFee_2].[WriteDate]<[ImportFee].WriteDate
and [ImportFee_2].WriteDate>=(case when [ImportFee_2].PriceRangeStartTime=''
then [ImportFee_2].FinalWriteDate
when [ImportFee_2].FinalWriteDate>[ImportFee_2].PriceRangeStartTime then [ImportFee_2].FinalWriteDate
else [ImportFee_2].PriceRangeStartTime
end)
and [ImportFee_2].[RoomID]=[ImportFee].[RoomID]) end)
as TotalUseCount,
(case when [ChargeSummary].StartPriceRange=0 then 0 else
(select sum(isnull(ChargeMeter_ProjectFee_2.MeterTotalPoint,0)) from (select *,
(DATEADD(yy,DATEDIFF(yy,0,[ChargeMeter_ProjectFee_1].WriteDate),0)) as FinalWriteDate,
[ChargeSummary].PriceRangeStartTime from 
[ChargeMeter_ProjectFee] as ChargeMeter_ProjectFee_1) 
as ChargeMeter_ProjectFee_2 where
ChargeMeter_ProjectFee_2.MeterChargeID=ChargeMeter_ProjectFee.MeterChargeID and
[ChargeMeter_ProjectFee_2].[WriteDate]<[ChargeMeter_ProjectFee].WriteDate
and [ChargeMeter_ProjectFee_2].WriteDate>=(case when [ChargeMeter_ProjectFee_2].PriceRangeStartTime=''
then [ChargeMeter_ProjectFee_2].FinalWriteDate
when [ChargeMeter_ProjectFee_2].FinalWriteDate>[ChargeMeter_ProjectFee_2].PriceRangeStartTime 
then [ChargeMeter_ProjectFee_2].FinalWriteDate
else [ChargeMeter_ProjectFee_2].PriceRangeStartTime
	end)
and [ChargeMeter_ProjectFee_2].[ProjectID]=[ChargeMeter_ProjectFee].[ProjectID]) end)
as TotalUseChaoBiaoCount
,[ImportFee].WriteDate
,[Project].AllParentID
,[Project].FullName
,[Project].Name as RoomName
,[ChargeSummary].Name
,[ChargeSummary].IsReading
,[RoomFee].DefaultChargeManName
,[RoomFee].RoomFeeWriteDate
,[RoomFee].Discount
,[RoomFee].DefaultChargeManID
,[RoomFee].ChargeMeterProjectFeeID
 from RoomFee left join 
ChargeSummary on ChargeSummary.ID=RoomFee.ChargeID
left join ImportFee on ImportFee.ID=RoomFee.ImportFeeID
left join (select * from ChargeMeter_ProjectFee where isnull(IsDeleted,0)=0)as ChargeMeter_ProjectFee
on ChargeMeter_ProjectFee.ID=RoomFee.ChargeMeterProjectFeeID
left join RoomBasic on RoomBasic.RoomID=RoomFee.RoomID
left join Contract_RoomCharge on Contract_RoomCharge.ID=RoomFee.Contract_RoomChargeID
left join [Project] on [Project].ID=RoomFee.RoomID";
        [DatabaseColumn("TotalUseChaoBiaoCount")]
        public decimal TotalUseChaoBiaoCount { get; set; }
        [DatabaseColumn("ChargeMeterProjectFeeID")]
        public int ChargeMeterProjectFeeID { get; set; }
        [DatabaseColumn("InPutStartTime")]
        public DateTime InPutStartTime { get; set; }
        [DatabaseColumn("InPutEndTime")]
        public DateTime InPutEndTime { get; set; }
        [DatabaseColumn("StartPoint")]
        public decimal StartPoint { get; set; }
        [DatabaseColumn("RoomFeeStartPoint")]
        public decimal RoomFeeStartPoint { get; set; }
        [DatabaseColumn("EndPoint")]
        public decimal EndPoint { get; set; }
        [DatabaseColumn("RoomFeeEndPoint")]
        public decimal RoomFeeEndPoint { get; set; }
        [DatabaseColumn("TotalRealCost")]
        public decimal TotalRealCost { get; set; }
        [DatabaseColumn("ImportCoefficient")]
        public decimal ImportCoefficient { get; set; }
        [DatabaseColumn("RoomFeeCoefficient")]
        public decimal RoomFeeCoefficient { get; set; }
        [DatabaseColumn("IsAnalysisQuery")]
        public bool IsAnalysisQuery { get; set; }
        [DatabaseColumn("StartPriceRange")]
        public bool StartPriceRange { get; set; }
        [DatabaseColumn("PriceRangeStartTime")]
        public DateTime PriceRangeStartTime { get; set; }
        [DatabaseColumn("ImportFeeID")]
        public int ImportFeeID { get; set; }
        [DatabaseColumn("UseCount")]
        public decimal UseCount { get; set; }
        [DatabaseColumn("TotalPoint")]
        public decimal TotalPoint { get; set; }
        [DatabaseColumn("ContractID")]
        public int ContractID { get; set; }
        [DatabaseColumn("ContractArea")]
        public decimal ContractArea { get; set; }
        [DatabaseColumn("CalculateAreaType")]
        public string CalculateAreaType { get; set; }
        [DatabaseColumn("BuildingArea")]
        public decimal BuildingArea { get; set; }
        [DatabaseColumn("BuildOutArea")]
        public decimal BuildOutArea { get; set; }
        [DatabaseColumn("BuildInArea")]
        public decimal BuildInArea { get; set; }
        [DatabaseColumn("GonTanArea")]
        public decimal GonTanArea { get; set; }
        [DatabaseColumn("ChanQuanArea")]
        public decimal ChanQuanArea { get; set; }
        [DatabaseColumn("UseArea")]
        public decimal UseArea { get; set; }
        [DatabaseColumn("PeiTaoArea")]
        public decimal PeiTaoArea { get; set; }
        [DatabaseColumn("UnitPrice")]
        public decimal UnitPrice { get; set; }
        [DatabaseColumn("ChargeFeeUnitPrice")]
        public decimal ChargeFeeUnitPrice { get; set; }
        [DatabaseColumn("SummaryUnitPrice")]
        public decimal SummaryUnitPrice { get; set; }
        [DatabaseColumn("CuiShouStartTime")]
        public DateTime CuiShouStartTime { get; set; }
        [DatabaseColumn("FeeType")]
        public int FeeType { get; set; }
        [DatabaseColumn("NewEndTime")]
        public DateTime NewEndTime { get; set; }
        [DatabaseColumn("CuiShouEndTime")]
        public DateTime CuiShouEndTime { get; set; }
        [DatabaseColumn("EndTime")]
        public DateTime EndTime { get; set; }
        [DatabaseColumn("StartTime")]
        public DateTime StartTime { get; set; }

        [DatabaseColumn("RelatedFeeID")]
        public int RelatedFeeID { get; set; }
        [DatabaseColumn("WeiYueStartDate")]
        public string WeiYueStartDate { get; set; }
        [DatabaseColumn("WeiYueDays")]
        public int WeiYueDays { get; set; }
        [DatabaseColumn("WeiYueBefore")]
        public string WeiYueBefore { get; set; }
        [DatabaseColumn("ChargeID")]
        public int ChargeID { get; set; }
        [DatabaseColumn("ReadyChargeTime")]
        public DateTime ReadyChargeTime { get; set; }
        [DatabaseColumn("TypeID")]
        public int TypeID { get; set; }
        [DatabaseColumn("RoomID")]
        public int RoomID { get; set; }
        [DatabaseColumn("Contract_RoomChargeID")]
        public int Contract_RoomChargeID { get; set; }
        [DatabaseColumn("EndNumberCount")]
        public int EndNumberCount { get; set; }
        [DatabaseColumn("ContractDivideID")]
        public int ContractDivideID { get; set; }
        [DatabaseColumn("ID")]
        public int ID { get; set; }
        [DatabaseColumn("ChargeWeiYueType")]
        public int ChargeWeiYueType { get; set; }
        [DatabaseColumn("WeiYuePercent")]
        public decimal WeiYuePercent { get; set; }
        [DatabaseColumn("DayGunLi")]
        public bool DayGunLi { get; set; }
        [DatabaseColumn("FenTanCoefficient")]
        public decimal FenTanCoefficient { get; set; }
        [DatabaseColumn("IsMeterFee")]
        public bool IsMeterFee { get; set; }
        [DatabaseColumn("Cost")]
        public decimal Cost { get; set; }
        [DatabaseColumn("TotalUseCount")]
        public decimal TotalUseCount { get; set; }
        [DatabaseColumn("WriteDate")]
        public DateTime WriteDate { get; set; }
        [DatabaseColumn("AllParentID")]
        public string AllParentID { get; set; }
        [DatabaseColumn("FullName")]
        public string FullName { get; set; }
        [DatabaseColumn("RoomName")]
        public string RoomName { get; set; }
        [DatabaseColumn("Name")]
        public string Name { get; set; }
        [DatabaseColumn("IsReading")]
        public bool IsReading { get; set; }
        [DatabaseColumn("DefaultChargeManName")]
        public string DefaultChargeManName { get; set; }
        [DatabaseColumn("RoomFeeWriteDate")]
        public DateTime RoomFeeWriteDate { get; set; }
        [DatabaseColumn("Discount")]
        public decimal Discount { get; set; }
        [DatabaseColumn("DefaultChargeManID")]
        public int DefaultChargeManID { get; set; }
        #endregion
        #region 公用属性
        public List<int> RelationRoomIDList { get; set; }

        public string RelationAllParentID { get; set; }
        public string FinalAllParentID
        {
            get
            {
                if (!string.IsNullOrEmpty(this.RelationAllParentID))
                {
                    return this.RelationAllParentID;
                }
                if (!string.IsNullOrEmpty(this.AllParentID))
                {
                    return this.AllParentID;
                }
                return string.Empty;
            }
        }
        public decimal FinalStartPoint
        {
            get
            {
                if (this.StartPoint > 0)
                {
                    return this.StartPoint;
                }
                if (this.RoomFeeStartPoint > 0)
                {
                    return this.RoomFeeStartPoint;
                }
                return 0;
            }
        }
        public decimal FinalEndPoint
        {
            get
            {
                if (this.EndPoint > 0)
                {
                    return this.EndPoint;
                }
                if (this.RoomFeeEndPoint > 0)
                {
                    return this.RoomFeeEndPoint;
                }
                return 0;
            }
        }
        public string FormatCalculateUnitPrice
        {
            get
            {
                return Utility.Tools.FormatMoney(this.CalculateUnitPrice, 4);
            }
        }
        public string FormatTotalCost
        {
            get
            {
                return Utility.Tools.FormatMoney(this.TotalCost);
            }
        }
        public string FormatTotalRealCost
        {
            get
            {
                return Utility.Tools.FormatMoney(this.TotalRealCost);
            }
        }
        public string FormatCuiShouTotalCost
        {
            get
            {
                return Utility.Tools.FormatMoney(this.CuiShouTotalCost);
            }
        }
        public string FormatALLTotalCost
        {
            get
            {
                return Utility.Tools.FormatMoney(this.ALLTotalCost);
            }
        }
        public string FormatTotalFinalCost
        {
            get
            {
                return Utility.Tools.FormatMoney(this.TotalFinalCost);
            }
        }
        public string FormatTotalFinalPayCost
        {
            get
            {
                return Utility.Tools.FormatMoney(this.TotalFinalPayCost);
            }
        }
        public string FormatALLFinalTotalCost
        {
            get
            {
                return Utility.Tools.FormatMoney(this.ALLFinalTotalCost);
            }
        }
        public ViewRoomFeeHistoryDetail[] ViewRoomFeeHistoryDetailList { get; set; }
        public bool IsPriceRange
        {
            get
            {
                return RoomFeeAnalysisBase.Get_IsPriceRange(this.StartPriceRange, this.PriceRangeStartTime, this.ImportFeeID, this.ChargeMeterProjectFeeID);
            }
        }
        public decimal FinalTotalUseCount
        {
            get
            {
                if (this.TotalUseCount > 0)
                {
                    return this.TotalUseCount;
                }
                if (this.TotalUseChaoBiaoCount > 0)
                {
                    return this.TotalUseChaoBiaoCount;
                }
                return 0;
            }
        }
        public decimal CalculateCoefficient
        {
            get
            {
                if (this.ImportCoefficient > 0)
                {
                    return this.ImportCoefficient;
                }
                if (this.RoomFeeCoefficient > 0)
                {
                    return this.RoomFeeCoefficient;
                }
                return 1;
            }
        }
        public decimal CalculateUseCount
        {
            get
            {
                decimal result = RoomFeeAnalysisBase.Get_CalculateUseCount(this.ImportFeeID, this.UseCount, this.TotalPoint, this.ContractID, this.ContractArea, this.CalculateAreaType, this.BuildingArea, this.BuildOutArea, this.BuildInArea, this.GonTanArea, this.ChanQuanArea, this.UseArea, this.PeiTaoArea);
                return result;
            }
        }
        public decimal CalculateJieTiUnitPrice
        {
            get
            {
                decimal result = RoomFeeAnalysisBase.Get_CalculateJieTiUnitPrice(this.IsPriceRange, this.ID, this.ChargeID, this.FinalTotalUseCount, this.CalculateUseCount);
                return result;
            }
        }
        public decimal CalculateUnitPrice
        {
            get
            {
                decimal result = RoomFeeAnalysisBase.Get_CalculateUnitPrice(this.IsPriceRange, this.CalculateJieTiUnitPrice, this.UnitPrice, this.ChargeFeeUnitPrice, this.SummaryUnitPrice);
                return result;
            }
        }
        public DateTime CalculateCuiShouStartTime
        {
            get
            {
                DateTime result = RoomFeeAnalysisBase.Get_CalculateCuiShouStartTime(this.CuiShouStartTime, this.ImportFeeID, this.FeeType, this.InPutStartTime, this.CalculateStartTime);
                return result;
            }
        }
        public DateTime CalculateCuiShouEndTime
        {
            get
            {
                DateTime result = RoomFeeAnalysisBase.Get_CalculateCuiShouEndTime(this.ImportFeeID, this.FeeType, this.InPutEndTime, this.NewEndTime, this.CuiShouEndTime, this.CalculateStartTime, this.EndTime);
                return result;
            }
        }
        public DateTime CalculateStartTime
        {
            get
            {
                DateTime result = RoomFeeAnalysisBase.Get_CalculateStartTime(this.ContractID, this.InPutStartTime, this.StartTime, this.ImportFeeID, this.FeeType, this.RelatedFeeID, this.WeiYueStartDate, this.WeiYueDays, this.WeiYueBefore, this.ChargeMeterProjectFeeID);
                return result;
            }
        }
        public DateTime CalculateEndTime
        {
            get
            {
                DateTime result = RoomFeeAnalysisBase.Get_CalculateEndTime(this.ContractID, this.InPutEndTime, this.EndTime, this.ImportFeeID, this.CalculateStartTime, this.NewEndTime, this.RelatedFeeID, this.FeeType, this.CuiShouStartTime, this.ChargeMeterProjectFeeID);
                return result;
            }
        }
        public int CalculateInputStartEndDay
        {
            get
            {
                if (this.InPutStartTime == DateTime.MinValue || this.InPutEndTime == DateTime.MinValue)
                {
                    return 1;
                }
                if (this.InPutStartTime > this.InPutEndTime)
                {
                    return 1;
                }
                var tspan = this.InPutEndTime - this.InPutStartTime;
                return Convert.ToInt32(tspan.TotalDays + 1);
            }
        }
        public int CalculateStartEndDay
        {
            get
            {
                if (this.CalculateStartTime == DateTime.MinValue || this.CalculateEndTime == DateTime.MinValue)
                {
                    return 1;
                }
                if (this.CalculateStartTime > this.CalculateEndTime)
                {
                    return 0;
                }
                var tspan = this.CalculateEndTime - this.CalculateStartTime;
                return Convert.ToInt32(tspan.TotalDays + 1);
            }
        }
        public decimal CalculateStartEndPercent
        {
            get
            {
                if (this.CalculateInputStartEndDay <= 0)
                {
                    return 0;
                }
                var result = (decimal)this.CalculateStartEndDay / this.CalculateInputStartEndDay;
                return RoomFeeAnalysisBase.GetAnalysisQueryValue(true, result);
            }
        }
        public List<Dictionary<string, object>> ActiveTimeRange
        {
            get
            {
                var result = RoomFeeAnalysisBase.Get_ActiveTimeRange(this.ContractID, this.CalculateStartTime, this.CalculateEndTime, this.ChargeID, this.ContractDivideID);
                return result;
            }
        }
        public List<Dictionary<string, object>> ActiveCuiShouTimeRange
        {
            get
            {
                var result = RoomFeeAnalysisBase.Get_ActiveCuiShouTimeRange(this.ContractID, this.CalculateCuiShouStartTime, this.CalculateCuiShouEndTime, this.ChargeID, this.ContractDivideID);
                return result;
            }
        }
        /// <summary>
        /// 合同减免金额
        /// </summary>
        public decimal CalcualteDiscount
        {
            get
            {
                var result = RoomFeeAnalysisBase.Get_CalcualteDiscount(this.InPutStartTime, this.InPutEndTime, analysis: this);
                return RoomFeeAnalysisBase.GetAnalysisQueryValue(this.IsAnalysisQuery, result);
            }
        }
        public decimal ALLFinalTotalCost
        {
            get
            {
                var result = RoomFeeAnalysisBase.Get_ALLFinalTotalCost(this.InPutStartTime, this.InPutEndTime, analysis: this);
                return RoomFeeAnalysisBase.GetAnalysisQueryValue(this.IsAnalysisQuery, result);
            }
        }
        /// <summary>
        /// 应收金额(包含合同减免)
        /// </summary>
        public decimal ALLTotalCost
        {
            get
            {

                var result = RoomFeeAnalysisBase.Get_ALLTotalCost(this.InPutStartTime, this.InPutEndTime, analysis: this);
                return RoomFeeAnalysisBase.GetAnalysisQueryValue(this.IsAnalysisQuery, result);
            }
        }

        /// <summary>
        /// 应收金额(不包含合同减免)
        /// </summary>
        public decimal TotalCost
        {
            get
            {
                var result = RoomFeeAnalysisBase.Get_TotalCost(this.ALLTotalCost, this.CalcualteDiscount);
                return RoomFeeAnalysisBase.GetAnalysisQueryValue(this.IsAnalysisQuery, result);
            }
        }
        /// <summary>
        /// 未收金额
        /// </summary>
        public decimal TotalFinalCost
        {
            get
            {
                var result = RoomFeeAnalysisBase.Get_TotalFinalCost(this.ALLTotalCost, this.CalcualteDiscount, this.TotalFinalPayCost, this.TotalFinalDiscountCost);
                return RoomFeeAnalysisBase.GetAnalysisQueryValue(this.IsAnalysisQuery, result);
            }
        }

        /// <summary>
        ///  催收金额(不包含合同减免)
        /// </summary>
        public decimal CuiShouTotalCost
        {
            get
            {
                var result = RoomFeeAnalysisBase.Get_CuiShouTotalCost(this.AllCuiShouTotalCost, this.CalcualteDiscount);
                return RoomFeeAnalysisBase.GetAnalysisQueryValue(this.IsAnalysisQuery, result);
            }
        }
        /// <summary>
        ///  催收金额(包含合同减免)
        /// </summary>
        public decimal AllCuiShouTotalCost
        {
            get
            {
                var result = RoomFeeAnalysisBase.Get_AllCuiShouTotalCost(this.InPutStartTime, this.InPutEndTime, analysis: this);
                return RoomFeeAnalysisBase.GetAnalysisQueryValue(this.IsAnalysisQuery, result);
            }
        }
        public string ChargeTypeDesc
        {
            get
            {
                var result = RoomFeeAnalysisBase.Get_ChargeTypeDesc(this.TypeID);
                return result;
            }
        }
        /// <summary>
        ///  已收金额
        /// </summary>
        public decimal TotalFinalPayCost
        {
            get
            {
                var result = RoomFeeAnalysisBase.Get_TotalFinalPayCost(analysis: this);
                return RoomFeeAnalysisBase.GetAnalysisQueryValue(this.IsAnalysisQuery, result);
            }
        }
        public string ChargeDiscountName
        {
            get
            {
                var result = RoomFeeAnalysisBase.Get_ChargeDiscountName(this.ViewRoomFeeHistoryDetailList, this.InPutStartTime, this.InPutEndTime, this.ID, this.RoomID, this.ChargeID, this.Contract_RoomChargeID);
                return result;
            }
        }
        /// <summary>
        ///  已收折扣
        /// </summary>
        public decimal TotalFinalDiscountCost
        {
            get
            {
                var result = RoomFeeAnalysisBase.Get_TotalFinalDiscountCost(this.ViewRoomFeeHistoryDetailList, this.InPutStartTime, this.InPutEndTime, this.ID, this.RoomID, this.ChargeID, this.Contract_RoomChargeID);
                return RoomFeeAnalysisBase.GetAnalysisQueryValue(this.IsAnalysisQuery, result);
            }
        }
        public string FinalCustomerName
        {
            get
            {
                if (!string.IsNullOrEmpty(this.DefaultChargeManName))
                {
                    return this.DefaultChargeManName;
                }
                return string.Empty;
            }
        }
        #endregion
        protected override void EnsureParentProperties()
        {
        }
        #region 公用静态方法
        public static RoomFeeAnalysis[] GetRoomFeeAnalysisListByTime(DateTime StartTime, DateTime EndTime, List<int> ProjectIDList, List<int> RoomIDList, DateTime? StartChargeTime = null, DateTime? EndChargeTime = null, bool IsContractFee = true, int UserID = 0, bool IsContractWarning = false, bool IsAnalysisQuery = false)
        {
            return GetRoomFeeAnalysisListByRoomID(RoomIDList, ProjectIDList, StartTime, EndTime, new int[] { }, -1, new List<int>(), true, IsContractFee, 0, StartChargeTime: StartChargeTime, EndChargeTime: EndChargeTime, UserID: UserID, RequireOrderBy: false, IsContractWarning: IsContractWarning, IsAnalysisQuery: IsAnalysisQuery);
        }
        public static RoomFeeAnalysis[] GetRoomFeeAnalysisListByRoomID(List<int> RoomIDList, List<int> ProjectIDList, DateTime StartTime, DateTime EndTime, int[] ChargeSummaryID, bool IsRoomFee = true, bool IsContractFee = false, int UserID = 0, bool IsAnalysisQuery = false)
        {
            return GetRoomFeeAnalysisListByRoomID(RoomIDList, ProjectIDList, StartTime, EndTime, ChargeSummaryID, -1, new List<int>(), IsRoomFee, IsContractFee, 0, UserID: UserID, RequireOrderBy: false, IncludeRelation: false, IsAnalysisQuery: IsAnalysisQuery);
        }
        public static RoomFeeAnalysis[] GetRoomFeeAnalysisListByRoomID(List<int> RoomIDList, List<int> ProjectIDList, DateTime StartTime, DateTime EndTime, int[] ChargeSummaryID, int IsCharged, List<int> RoomPropertyList, bool IsRoomFee, bool IsContractFee, int ContractID, bool IsAutoEndTime = false, string keywords = "", bool ExcludeHistoryChargeTime = false, DateTime? StartChargeTime = null, DateTime? EndChargeTime = null, int DivideID = 0, List<int> RoomStateList = null, int UserID = 0, bool RequireOrderBy = true, DateTime? ReadyStartTime = null, DateTime? ReadyEndTime = null, bool IsContractWarning = false, bool IncludeRelation = true, bool IsAnalysisQuery = false, bool OnlyWuye = false)
        {
            RoomFeeAnalysisBase.ReSetParams();
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[RoomFee].[IsStart]=1");
            conditions.Add("([RoomFee].Contract_RoomChargeID is null or [RoomFee].Contract_RoomChargeID=0 or [RoomFee].Contract_RoomChargeID in (select ID from [Contract_RoomCharge]))");
            if (OnlyWuye)
            {
                conditions.Add("[ChargeSummary].ChargeFeeType=1");
            }
            if (IsContractWarning || (IsContractFee && !IsRoomFee) || ContractID > 0)
            {
                conditions.Add("isnull([RoomFee].[ContractID],0) in (select [ID] from [Contract])");
            }
            if (IsContractWarning)
            {
                conditions.Add("([Contract_RoomCharge].[ReadyChargeTime]<=@ReadyChargeTime or [Contract_RoomCharge].[ReadyChargeTime] is null)");
                parameters.Add(new SqlParameter("@ReadyChargeTime", DateTime.Now));
            }
            if (RoomStateList != null && RoomStateList.Count > 0)
            {
                conditions.Add("[RoomBasic].[RoomStateID] in (" + string.Join(",", RoomStateList.ToArray()) + ")");
            }
            if (DivideID > 0)
            {
                conditions.Add("isnull([RoomFee].[ContractDivideID],0)=@DivideID");
                parameters.Add(new SqlParameter("@DivideID", DivideID));
            }
            if (!string.IsNullOrEmpty(keywords))
            {
                conditions.Add("([Project].[Name] like @Keywords or [Project].[FullName] like @Keywords)");
                parameters.Add(new SqlParameter("@Keywords", "%" + keywords + "%"));
            }
            if (IsRoomFee && !IsContractFee)
            {
                conditions.Add("isnull([RoomFee].[ContractID],0)=0");
            }
            if (IsContractFee && !IsRoomFee)
            {
                conditions.Add("isnull([RoomFee].[ContractID],0)>0");
            }
            if (ContractID > 0)
            {
                conditions.Add("isnull([RoomFee].[ContractID],0)=@ContractID");
                parameters.Add(new SqlParameter("@ContractID", ContractID));
            }
            if (RoomPropertyList.Count > 0)
            {
                conditions.Add("[RoomBasic].[RoomPropertyID] in (" + string.Join(",", RoomPropertyList.ToArray()) + ")");
            }
            if (IsCharged >= 0)
            {
                conditions.Add("isnull([RoomFee].[IsCharged],0)=@IsCharged");
                parameters.Add(new SqlParameter("@IsCharged", IsCharged));
            }
            if (StartTime > DateTime.MinValue)
            {
                conditions.Add("((Convert(nvarchar(10),[ImportFee].[WriteDate],120)>=@StartTime and [ImportFeeID]>0) or isnull([ImportFeeID],0)=0)");
                parameters.Add(new SqlParameter("@StartTime", StartTime));
            }
            if (EndTime > DateTime.MinValue)
            {
                conditions.Add("((Convert(nvarchar(10),[ImportFee].[WriteDate],120)<=@EndTime and [RoomFee].[ImportFeeID]>0) or isnull([RoomFee].[ImportFeeID],0)=0)");
                parameters.Add(new SqlParameter("@EndTime", EndTime));
            }
            if (ReadyStartTime.HasValue)
            {
                DateTime _ReadyStartTime = Convert.ToDateTime(ReadyStartTime);
                if (_ReadyStartTime > DateTime.MinValue)
                {
                    conditions.Add("(Convert(nvarchar(10),[Contract_RoomCharge].[ReadyChargeTime],120)>=@ReadyStartTime or [Contract_RoomCharge].[ReadyChargeTime] is null)");
                    parameters.Add(new SqlParameter("@ReadyStartTime", _ReadyStartTime));
                }
            }
            if (ReadyEndTime.HasValue)
            {
                DateTime _ReadyEndTime = Convert.ToDateTime(ReadyEndTime);
                if (_ReadyEndTime > DateTime.MinValue)
                {
                    conditions.Add("(Convert(nvarchar(10),[Contract_RoomCharge].[ReadyChargeTime],120)<=@ReadyEndTime or [Contract_RoomCharge].[ReadyChargeTime] is null)");
                    parameters.Add(new SqlParameter("@ReadyEndTime", _ReadyEndTime));
                }
            }
            if (RoomIDList.Count > 0)
            {
                List<string> cmdlist = ViewRoomFeeHistory.GetRoomIDListConditions(RoomIDList, IncludeRelation: IncludeRelation, IsContractFee: IsContractFee, RoomIDName: "[RoomFee].[RoomID]", ContractIDName: "[RoomFee].[ContractID]");
                if (ContractID > 0)
                {
                    cmdlist.Add("[RoomFee].[RoomID]=0");
                }
                conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
            }
            if (ProjectIDList.Count > 0)
            {
                List<string> cmdlist = ViewRoomFeeHistory.GetProjectIDListConditions(ProjectIDList, IncludeRelation: IncludeRelation, IsContractFee: IsContractFee, UserID: UserID, RoomIDName: "[RoomFee].[RoomID]", ContractIDName: "[RoomFee].[ContractID]");
                if (ContractID > 0)
                {
                    cmdlist.Add("[RoomFee].[RoomID]=0");
                }
                conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
            }
            if (ChargeSummaryID.Length > 0)
            {
                conditions.Add("[RoomFee].[ChargeID] in (" + string.Join(",", ChargeSummaryID) + ")");
            }
            string cmd_select = RoomFeeAnalysisBase.GetInPutTimeCmdString(StartTime, EndTime, IsAnalysisQuery);
            string Statement = " select * " + cmd_select + " from (" + columntext + " where  " + string.Join(" and ", conditions.ToArray()) + ")A";
            var list = GetList<RoomFeeAnalysis>(Statement, parameters).ToArray();
            if (list.Length > 0)
            {
                DateTime _StartChargeTime = StartTime;
                DateTime _EndChargeTime = EndTime;
                if (ExcludeHistoryChargeTime)
                {
                    _StartChargeTime = DateTime.MinValue;
                    _EndChargeTime = DateTime.MinValue;
                }
                else
                {
                    if (StartChargeTime.HasValue)
                    {
                        _StartChargeTime = Convert.ToDateTime(StartChargeTime);
                    }
                    if (EndChargeTime.HasValue)
                    {
                        _EndChargeTime = Convert.ToDateTime(EndChargeTime);
                    }
                }
                GetViewRoomFeeFinalDataList(list, _StartChargeTime, _EndChargeTime, StartTime, EndTime);
            }
            return list;
        }
        public static RoomFeeAnalysis[] GetFinalRoomFeeAnalysisList(RoomFeeAnalysis[] fee_list, DateTime StartTime, DateTime EndTime)
        {
            RoomFeeAnalysisBase.ReSetParams();
            var my_fee_list = fee_list.Where(p =>
            {
                p.InPutStartTime = StartTime;
                p.InPutEndTime = EndTime;
                if (p.InPutStartTime > DateTime.MinValue && p.ImportFeeID > 0 && Convert.ToDateTime(p.WriteDate.ToString("yyyy-MM-dd")) > DateTime.MinValue && Convert.ToDateTime(p.WriteDate.ToString("yyyy-MM-dd")) < Convert.ToDateTime(p.InPutStartTime.ToString("yyyy-MM-dd")))
                {
                    return false;
                }
                if (p.InPutEndTime > DateTime.MinValue && p.ImportFeeID > 0 && Convert.ToDateTime(p.WriteDate.ToString("yyyy-MM-dd")) > Convert.ToDateTime(p.InPutEndTime.ToString("yyyy-MM-dd")))
                {
                    return false;
                }
                if (p.InPutStartTime > DateTime.MinValue && p.IsMeterFee && Convert.ToDateTime(p.RoomFeeWriteDate.ToString("yyyy-MM-dd")) < Convert.ToDateTime(p.InPutStartTime.ToString("yyyy-MM-dd")))
                {
                    return false;
                }
                if (p.InPutEndTime > DateTime.MinValue && p.IsMeterFee && Convert.ToDateTime(p.RoomFeeWriteDate.ToString("yyyy-MM-dd")) > Convert.ToDateTime(p.InPutEndTime.ToString("yyyy-MM-dd")))
                {
                    return false;
                }
                //if (EndTime > DateTime.MinValue && p.ContractID <= 0)                
                if (EndTime > DateTime.MinValue)
                {
                    return p.CalculateStartTime <= EndTime;
                }
                return p.TotalFinalCost > 0 || p.TotalCost > 0;
            }).ToArray();
            return my_fee_list;
        }
        public static List<Dictionary<string, object>> GetFinalRoomFeeAnalysisDictionary(RoomFeeAnalysis[] fee_list, DateTime StartTime, DateTime EndTime, bool CanRest = true)
        {
            if (CanRest)
            {
                RoomFeeAnalysisBase.ReSetParams();
            }
            var my_fee_list = fee_list.Select(p =>
            {
                p.InPutStartTime = StartTime;
                p.InPutEndTime = EndTime;
                var dic = p.ToJsonObject();
                dic["FinalAllParentID"] = p.FinalAllParentID;
                dic["InPutStartTime"] = p.InPutStartTime;
                dic["InPutEndTime"] = p.InPutEndTime;
                dic["TotalFinalCost"] = p.TotalFinalCost;
                dic["TotalCost"] = p.TotalCost;
                dic["TotalFinalPayCost"] = p.TotalFinalPayCost;
                dic["TotalFinalDiscountCost"] = p.TotalFinalDiscountCost;
                return dic;
            }).ToList();
            return my_fee_list;
        }
        public static List<Dictionary<string, object>> GetRoomFeeAnalysisDictionary(RoomFeeAnalysis[] fee_list, DateTime StartTime, DateTime EndTime)
        {
            var my_fee_list = GetFinalRoomFeeAnalysisList(fee_list, StartTime, EndTime);
            var my_fee_list1 = GetFinalRoomFeeAnalysisDictionary(my_fee_list, StartTime, EndTime, CanRest: false);
            return my_fee_list1;
        }
        public static RoomFeeAnalysis GetParentRoomFeeAnalysis(int ID, bool CanReSet = true)
        {
            if (CanReSet)
            {
                RoomFeeAnalysisBase.ReSetParams();
            }
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[FeeType]!=8");
            conditions.Add("[ID]=@ID");
            parameters.Add(new SqlParameter("@ID", ID));
            var data = GetOne<RoomFeeAnalysis>("select * from (" + columntext + ")A where " + string.Join(" and ", conditions.ToArray()), parameters);
            return data;
        }
        public static int GetCuiShouCount(int RoomFeeID)
        {
            var parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@ID", RoomFeeID));
            string cmdtext = "select Count(1) from RoomFeeHistory where [ID]=@ID and ChargeState=5";
            int count = 0;
            using (SqlHelper helper = new SqlHelper())
            {
                var result = helper.ExecuteScalar(cmdtext, CommandType.Text, parameters);
                if (result != null)
                {
                    int.TryParse(result.ToString(), out count);
                }
            }
            return count;
        }
        public static RoomFeeAnalysis GetRoomFeeAnalysisByID(int ID, bool CanReSet = true)
        {
            if (CanReSet)
            {
                RoomFeeAnalysisBase.ReSetParams();
            }
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[ID]=@ID");
            parameters.Add(new SqlParameter("@ID", ID));
            var data = GetOne<RoomFeeAnalysis>("select * from (" + columntext + ")A where " + string.Join(" and ", conditions.ToArray()), parameters);
            return data;
        }
        public static RoomFeeAnalysis[] GetRoomFeeAnalysisListByIDList(List<int> IDList)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[ID] in (" + string.Join(",", IDList.ToArray()) + ")");
            return GetList<RoomFeeAnalysis>("select * from (" + columntext + ")A where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
        public static RoomFeeAnalysis[] GetRoomFeeAnalysisListByRoomIDList(int[] RoomIDList)
        {
            RoomFeeAnalysisBase.ReSetParams();
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            if (RoomIDList.Length == 0)
            {
                return new RoomFeeAnalysis[] { };
            }
            conditions.Add("[RoomID] in (" + string.Join(",", RoomIDList) + ")");
            conditions.Add("(Contract_RoomChargeID is null or Contract_RoomChargeID=0 or Contract_RoomChargeID in (select ID from [Contract_RoomCharge]))");
            string Statement = " select * from (" + columntext + ")A where  " + string.Join(" and ", conditions.ToArray());
            var list = GetList<RoomFeeAnalysis>(Statement, parameters).ToArray();
            GetViewRoomFeeFinalDataList(list, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue);
            return list;
        }
        public static RoomFeeAnalysis[] GetRoomFeeAnalysisListByContractIDList(List<int> ContractIDList)
        {
            RoomFeeAnalysisBase.ReSetParams();
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            if (ContractIDList.Count == 0)
            {
                return new RoomFeeAnalysis[] { };
            }
            conditions.Add("Contract_RoomChargeID in (select ID from [Contract_RoomCharge])");
            conditions.Add("[ContractID] in (" + string.Join(",", ContractIDList.ToArray()) + ")");
            string Statement = " select * from (" + columntext + ")A where  " + string.Join(" and ", conditions.ToArray());
            var list = GetList<RoomFeeAnalysis>(Statement, parameters).ToArray();
            GetViewRoomFeeFinalDataList(list, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue);
            return list;
        }
        public static RoomFeeAnalysis[] GetContractFeeWeiYueListByContractIDList(List<int> ContractIDList)
        {
            RoomFeeAnalysisBase.ReSetParams();
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[FeeType]=8");
            if (ContractIDList.Count == 0)
            {
                return new RoomFeeAnalysis[] { };
            }
            conditions.Add("Contract_RoomChargeID in (select ID from [Contract_RoomCharge])");
            conditions.Add("[RelatedFeeID] in (" + string.Join(",", ContractIDList.ToArray()) + ")");
            string Statement = " select * from (" + columntext + ")A where  " + string.Join(" and ", conditions.ToArray());
            var list = GetList<RoomFeeAnalysis>(Statement, parameters).ToArray();
            GetViewRoomFeeFinalDataList(list, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue);
            return list;
        }
        public static RoomFeeAnalysis[] GetRoomFeeAnalysisListByContractDivideIDList(List<int> DivideIDList)
        {
            RoomFeeAnalysisBase.ReSetParams();
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            if (DivideIDList.Count == 0)
            {
                return new RoomFeeAnalysis[] { };
            }
            conditions.Add("[ContractDivideID] in (" + string.Join(",", DivideIDList.ToArray()) + ")");
            conditions.Add("(Contract_RoomChargeID is null or Contract_RoomChargeID=0 or Contract_RoomChargeID in (select ID from [Contract_RoomCharge]))");
            string Statement = " select * from (" + columntext + ")A where  " + string.Join(" and ", conditions.ToArray());
            var list = GetList<RoomFeeAnalysis>(Statement, parameters).ToArray();
            GetViewRoomFeeFinalDataList(list, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue);
            return list;
        }
        public static RoomFeeAnalysis GetRoomFeeAnalysisByEndTime(int ID, DateTime EndTime, int UserID = 0, bool IsAnalysisQuery = false, bool relatedRequire = false)
        {
            RoomFeeAnalysisBase.ReSetParams();
            string cmd_select = RoomFeeAnalysisBase.GetInPutTimeCmdString(DateTime.MinValue, EndTime, IsAnalysisQuery);
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[ID]=@ID");
            parameters.Add(new SqlParameter("@ID", ID));
            string Statement = " select * " + cmd_select + " from (" + columntext + ")A where  " + string.Join(" and ", conditions.ToArray());
            var data = GetOne<RoomFeeAnalysis>(Statement, parameters);
            if (data != null)
            {
                var list = new RoomFeeAnalysis[] { data };
                GetViewRoomFeeFinalDataList(list, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, relatedRequire: relatedRequire);
                return list[0];
            }
            return null;
        }
        public static RoomFeeAnalysis[] GetRoomFeeAnalysisListByUserID(int UserID, int RoomID = 0)
        {
            RoomFeeAnalysisBase.ReSetParams();
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            List<string> cmdlist = new List<string>();
            if (RoomID > 0)
            {
                cmdlist.Add("[RoomID] in (select [ID] from [Project] where ID=" + RoomID + " or [AllParentID] like '%," + RoomID + ",%')");
                cmdlist.Add("[RoomID] in (select [RoomID] from [RoomRelation] where [GUID] in (select [GUID] from [RoomRelation] where [RoomID] in (select [ID] from [Project] where ID=" + RoomID + " or [AllParentID] like '%," + RoomID + ",%')))");
            }
            else
            {
                cmdlist.Add("[RoomID] in (select [ProjectID] from [Mall_UserProject] where isnull([IsDisable],0)=0 and [UserID]=@UserID)");
                cmdlist.Add("[RoomID] in (select [RoomID] from [RoomRelation] where [GUID] in (select [GUID] from [RoomRelation] where [RoomID] in (select [ProjectID] from [Mall_UserProject] where isnull([IsDisable],0)=0 and [UserID]=@UserID)))");
                parameters.Add(new SqlParameter("@UserID", UserID));
            }
            if (cmdlist.Count > 0)
            {
                conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
            }
            string Statement = " select * from (" + columntext + ")A where  " + string.Join(" and ", conditions.ToArray());
            var list = GetList<RoomFeeAnalysis>(Statement, parameters).ToArray();
            GetViewRoomFeeFinalDataList(list, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue);
            return list;
        }
        public static void GetViewRoomFeeOwnerName(RoomFeeAnalysis[] list)
        {
            GetViewRoomFeeFinalDataList(list, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, historyListRequire: false, relatedRequire: true);
        }
        public static void GetViewRoomFeeFinalDataList(RoomFeeAnalysis[] list, DateTime StartChargeTime, DateTime EndChargeTime, DateTime StartTime, DateTime EndTime, bool historyListRequire = true, bool relatedRequire = true)
        {
            if (list.Length == 0)
            {
                return;
            }
            var MinID = list.Min(p => p.RoomID);
            var MaxID = list.Max(p => p.RoomID);
            ViewRoomFeeHistoryDetail[] roomFeeHistoryDetailList = new ViewRoomFeeHistoryDetail[] { };
            RoomPhoneRelation[] phoneRelationList = new RoomPhoneRelation[] { };
            RoomRelation[] relationList = new RoomRelation[] { };
            Project[] projectList = new Project[] { };
            if (historyListRequire)
            {
                roomFeeHistoryDetailList = ViewRoomFeeHistoryDetail.GetViewRoomFeeHistoryDetailListByMinMaxID(MinID, MaxID, StartChargeTime, EndChargeTime, StartTime, EndTime);
            }
            if (relatedRequire)
            {
                phoneRelationList = RoomPhoneRelation.GetRoomPhoneRelationListByMinMaxRoomID(MinID, MaxID);
                relationList = RoomRelation.GetRoomRelationListByMinMaxRoomID(MinID, MaxID);
                projectList = Project.GetProjectListByMinMaxID(MinID, MaxID);
            }
            if (phoneRelationList.Length == 0 && roomFeeHistoryDetailList.Length == 0 && relationList.Length == 0)
            {
                return;
            }
            foreach (var item in list)
            {
                if (roomFeeHistoryDetailList.Length > 0)
                {
                    item.ViewRoomFeeHistoryDetailList = roomFeeHistoryDetailList.Where(p =>
                    {
                        bool result1 = p.RoomID == item.RoomID && p.ChargeID == item.ChargeID && p.ID == item.ID;
                        bool result2 = p.RoomID == item.RoomID && p.ChargeID == item.ChargeID && p.Contract_RoomChargeID == item.Contract_RoomChargeID && item.Contract_RoomChargeID > 0;
                        return result1 || result2;
                    }).ToArray();
                }
                if (phoneRelationList.Length > 0)
                {
                    var myPhoneRelationList = phoneRelationList.Where(p => p.RoomID == item.RoomID);
                    RoomPhoneRelation phoneRelation = null;
                    if (item.DefaultChargeManID > 0)
                    {
                        phoneRelation = myPhoneRelationList.FirstOrDefault(p => p.ID == item.DefaultChargeManID);
                    }
                    if (phoneRelation == null)
                    {
                        phoneRelation = myPhoneRelationList.FirstOrDefault(p => p.IsChargeFee);
                    }
                    if (phoneRelation == null)
                    {
                        phoneRelation = myPhoneRelationList.FirstOrDefault(p => p.IsDefault);
                    }
                    if (phoneRelation != null)
                    {
                        item.DefaultChargeManID = phoneRelation.ID;
                        item.DefaultChargeManName = phoneRelation.RelationName;
                    }
                    var myRelationList = relationList.Where(q => q.RoomID == item.RoomID).ToArray();
                    if (myRelationList.Length > 0)
                    {
                        var guidList = myRelationList.Select(p => p.GUID).ToArray();
                        myRelationList = relationList.Where(p => guidList.Contains(p.GUID)).ToArray();
                    }
                    var relationRoomIDList = myRelationList.Select(p => p.RoomID).ToList();
                    relationRoomIDList.Add(item.RoomID);
                    var myAllParentIDList = projectList.Where(p => relationRoomIDList.Contains(p.ID)).Select(p => p.AllParentID).ToArray();
                    if (myAllParentIDList.Length > 0)
                    {
                        item.RelationAllParentID = string.Join("", myAllParentIDList);
                    }
                    item.RelationRoomIDList = relationRoomIDList;
                }
            }
        }
        #endregion
    }
    public partial class RoomFeeAnalysisBase : EntityBaseReadOnly
    {
        public static void ReSetParams()
        {
            Contract_Divide.ReSetParams();
            ratecostlist = new List<decimal>();
            PriceFeeRangeList = null;
            contractdividefee = new Dictionary<int, decimal>();
            RoomBasicDetailList = null;
            ChargeDiscountList = null;
            ContractFreeTimeList = null;
            parent_list = new Dictionary<int, RoomFeeAnalysis>();
            ContractDivideList = null;
        }
        #region 公用静态属性
        public static ChargeFeePriceRange[] PriceFeeRangeList = null;
        public static List<decimal> ratecostlist = new List<decimal>();
        public static Dictionary<int, decimal> contractdividefee = new Dictionary<int, decimal>();
        public static RoomBasicDetail[] RoomBasicDetailList = null;
        public static ChargeDiscount[] ChargeDiscountList = null;
        public static Contract_FreeTime[] ContractFreeTimeList = null;
        public static Dictionary<int, RoomFeeAnalysis> parent_list = new Dictionary<int, RoomFeeAnalysis>();
        public static Contract_Divide[] ContractDivideList = null;
        #endregion
        protected override void EnsureParentProperties()
        {
        }
        public static string GetInPutTimeCmdString(DateTime StartTime, DateTime EndTime, bool IsAnalysisQuery)
        {
            string cmd_select = "";
            if (StartTime > DateTime.MinValue)
            {
                cmd_select += ",'" + StartTime.ToString("yyyy-MM-dd HH:mm:ss") + "' as InPutStartTime";
            }
            else
            {
                cmd_select += ",NULL as InPutStartTime";
            }
            if (EndTime > DateTime.MinValue)
            {
                cmd_select += ",'" + EndTime.ToString("yyyy-MM-dd HH:mm:ss") + "' as InPutEndTime";
            }
            else
            {
                cmd_select += ",NULL as InPutEndTime";
            }
            cmd_select += "," + (IsAnalysisQuery ? "1" : "0") + " as IsAnalysisQuery";
            return cmd_select;
        }
        public static bool Get_IsPriceRange(bool StartPriceRange, DateTime PriceRangeStartTime, int ImportFeeID, int ChargeMeterProjectFeeID)
        {
            if (StartPriceRange && PriceRangeStartTime <= DateTime.Now && (ImportFeeID > 0 || ChargeMeterProjectFeeID > 0))
            {
                return true;
            }
            return false;
        }
        public static decimal Get_CalculateUseCount(int ImportFeeID, decimal UseCount, decimal TotalPoint, int ContractID, decimal ContractArea, string CalculateAreaType, decimal BuildingArea, decimal BuildOutArea, decimal BuildInArea, decimal GonTanArea, decimal ChanQuanArea, decimal UseArea, decimal PeiTaoArea)
        {
            decimal _CalculateUseCount = 0;
            if (ImportFeeID > 0)
            {
                if (UseCount > 0)
                {
                    _CalculateUseCount = UseCount;
                }
                else if (TotalPoint > 0)
                {
                    _CalculateUseCount = TotalPoint;
                }
                return _CalculateUseCount;
            }
            if (ContractID > 0 && UseCount > 0)
            {
                return UseCount;
            }
            if (ContractID > 0 && ContractArea > 0)
            {
                return ContractArea;
            }
            if (!string.IsNullOrEmpty(CalculateAreaType))
            {
                if (CalculateAreaType.Equals(Utility.EnumModel.ChargeSummaryCalculateAreaType.jifei.ToString()))
                {
                    _CalculateUseCount = BuildingArea;
                }
                else if (CalculateAreaType.Equals(Utility.EnumModel.ChargeSummaryCalculateAreaType.jianzhu.ToString()))
                {
                    _CalculateUseCount = BuildOutArea;
                }
                else if (CalculateAreaType.Equals(Utility.EnumModel.ChargeSummaryCalculateAreaType.taonei.ToString()))
                {
                    _CalculateUseCount = BuildInArea;
                }
                else if (CalculateAreaType.Equals(Utility.EnumModel.ChargeSummaryCalculateAreaType.gongtan.ToString()))
                {
                    _CalculateUseCount = GonTanArea;
                }
                else if (CalculateAreaType.Equals(Utility.EnumModel.ChargeSummaryCalculateAreaType.chanquan.ToString()))
                {
                    _CalculateUseCount = ChanQuanArea;
                }
                else if (CalculateAreaType.Equals(Utility.EnumModel.ChargeSummaryCalculateAreaType.shiyong.ToString()))
                {
                    _CalculateUseCount = UseArea;
                }
                else if (CalculateAreaType.Equals(Utility.EnumModel.ChargeSummaryCalculateAreaType.peitao.ToString()))
                {
                    _CalculateUseCount = PeiTaoArea;
                }
            }
            if (_CalculateUseCount > 0)
            {
                return _CalculateUseCount;
            }
            if (UseCount > 0)
            {
                return UseCount;
            }
            if (BuildingArea > 0)
            {
                return BuildingArea;
            }
            return 0;
        }
        public static decimal Get_CalculateJieTiUnitPrice(bool IsPriceRange, int ID, int ChargeID, decimal TotalUseCount, decimal CalculateUseCount)
        {
            decimal unitprice = RoomFeeAnalysisBase.GetJieTiUnitPrice(IsPriceRange, ID, ChargeID, TotalUseCount, CalculateUseCount);
            return unitprice;
        }
        public static decimal Get_CalculateUnitPrice(bool IsPriceRange, decimal CalculateJieTiUnitPrice, decimal UnitPrice, decimal ChargeFeeUnitPrice, decimal SummaryUnitPrice)
        {
            decimal unitprice = 0;
            if (IsPriceRange)
            {
                if (CalculateJieTiUnitPrice > 0)
                {
                    unitprice = CalculateJieTiUnitPrice;
                }
                else
                {
                    unitprice = 0;
                }
            }
            else if (UnitPrice > 0)
            {
                unitprice = UnitPrice;
            }
            else if (ChargeFeeUnitPrice > 0)
            {
                unitprice = ChargeFeeUnitPrice;
            }
            else if (SummaryUnitPrice > 0)
            {
                unitprice = SummaryUnitPrice;
            }
            return unitprice;
        }
        public static DateTime Get_CalculateCuiShouStartTime(DateTime CuiShouStartTime, int ImportFeeID, int FeeType, DateTime InPutStartTime, DateTime CalculateStartTime)
        {
            DateTime start_time = CuiShouStartTime > DateTime.MinValue ? CuiShouStartTime : CalculateStartTime;
            if (ImportFeeID == int.MinValue || FeeType == 1)
            {
                if (InPutStartTime > start_time)
                {
                    return InPutStartTime;
                }
            }
            return start_time;
        }
        public static DateTime Get_CalculateCuiShouEndTime(int ImportFeeID, int FeeType, DateTime InPutEndTime, DateTime NewEndTime, DateTime CuiShouEndTime, DateTime CalculateStartTime, DateTime EndTime)
        {
            if (ImportFeeID == int.MinValue || FeeType == 1)
            {
                if (InPutEndTime > DateTime.MinValue && InPutEndTime > CalculateStartTime)
                {
                    if (InPutEndTime >= NewEndTime && NewEndTime > DateTime.MinValue)
                    {
                        return NewEndTime;
                    }
                    return InPutEndTime;
                }
            }
            DateTime endtime = (CuiShouEndTime > DateTime.MinValue ? CuiShouEndTime : EndTime);
            return endtime;
        }
        public static DateTime Get_CalculateStartTime(int ContractID, DateTime InPutStartTime, DateTime StartTime, int ImportFeeID, int FeeType, int RelatedFeeID, string WeiYueStartDate, int WeiYueDays, string WeiYueBefore, int ChargeMeterProjectFeeID)
        {
            if (ContractID > 0 && InPutStartTime > DateTime.MinValue && InPutStartTime < StartTime)
            {
                return StartTime;
            }
            if ((ImportFeeID <= 0 && ChargeMeterProjectFeeID <= 0) || FeeType == 1)
            {
                if (InPutStartTime > StartTime)
                {
                    return InPutStartTime;
                }
            }
            if (RelatedFeeID > 0 && FeeType == 8)
            {
                RoomFeeAnalysis parent_roomfee = null;
                if (RoomFeeAnalysisBase.parent_list.ContainsKey(RelatedFeeID))
                {
                    parent_roomfee = RoomFeeAnalysisBase.parent_list[RelatedFeeID];
                }
                else
                {
                    parent_roomfee = RoomFeeAnalysis.GetParentRoomFeeAnalysis(RelatedFeeID, false);
                    RoomFeeAnalysisBase.parent_list[RelatedFeeID] = parent_roomfee;
                }
                if (parent_roomfee != null)
                {
                    DateTime FinalStartTime = DateTime.MinValue;
                    if (WeiYueStartDate.Equals(Utility.EnumModel.ChargeSummaryWeiYueStartDate.starttime.ToString()))
                    {
                        FinalStartTime = parent_roomfee.CalculateStartTime;
                    }
                    else if (WeiYueStartDate.Equals(Utility.EnumModel.ChargeSummaryWeiYueStartDate.endtime.ToString()))
                    {
                        FinalStartTime = parent_roomfee.CalculateEndTime;
                    }
                    int days = WeiYueDays > 0 ? WeiYueDays : 0;
                    if (WeiYueBefore.Equals(Utility.EnumModel.ChargeSummaryWeiYueBeforeAfter.before.ToString()))
                    {
                        days = -days;
                    }
                    if (FinalStartTime > DateTime.MinValue)
                    {
                        FinalStartTime = FinalStartTime.AddDays(days);
                    }
                    return FinalStartTime;
                }
            }
            return StartTime;
        }
        public static DateTime Get_CalculateEndTime(int ContractID, DateTime InPutEndTime, DateTime EndTime, int ImportFeeID, DateTime CalculateStartTime, DateTime NewEndTime, int RelatedFeeID, int FeeType, DateTime CuiShouStartTime, int ChargeMeterProjectFeeID)
        {
            if (ContractID > 0 && InPutEndTime > DateTime.MinValue && InPutEndTime > EndTime)
            {
                return EndTime;
            }
            if (ImportFeeID <= 0 && ChargeMeterProjectFeeID <= 0)
            {
                if (InPutEndTime > DateTime.MinValue && InPutEndTime >= CalculateStartTime)
                {
                    if (InPutEndTime >= NewEndTime && NewEndTime > DateTime.MinValue)
                    {
                        return NewEndTime;
                    }
                    return InPutEndTime;
                }
            }
            if (RelatedFeeID > 0 && FeeType == 8)
            {
                return DateTime.Now;
            }
            DateTime DefaultEndTime = CuiShouStartTime > DateTime.MinValue ? CuiShouStartTime.AddDays(-1) : EndTime;
            if (NewEndTime > DateTime.MinValue && DefaultEndTime > NewEndTime)
            {
                return NewEndTime;
            }
            return DefaultEndTime;
        }
        public static List<Dictionary<string, object>> Get_ActiveTimeRange(int ContractID, DateTime CalculateStartTime, DateTime CalculateEndTime, int ChargeID, int ContractDivideID)
        {
            var list = new List<Dictionary<string, object>>();
            if (ContractID == 0 || ContractDivideID > 0)
            {
                return list;
            }
            var FreeTimeList = RoomFeeAnalysisBase.GetContractFreeTimeList();
            var my_list = FreeTimeList.Where(p => p.ContractID == ContractID).ToArray();
            if (my_list.Length == 0)
            {
                return list;
            }
            var _CalculateStartTime = CalculateStartTime;
            var _CalculateEndTime = CalculateEndTime;
            foreach (var item in my_list)
            {
                List<int> ChargeIDList = item.FreeChargeIDs.Split(',').Select(p => { return Convert.ToInt32(p); }).ToList();
                if (!ChargeIDList.Contains(ChargeID))
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
                if (item.FreeStartTime >= _CalculateEndTime || item.FreeEndTime <= _CalculateStartTime)
                {
                    continue;
                }
                var dic = new Dictionary<string, object>();
                if (item.FreeStartTime >= _CalculateStartTime && item.FreeEndTime <= _CalculateEndTime)
                {
                    dic = new Dictionary<string, object>();
                    dic["StartTime"] = item.FreeStartTime;
                    dic["EndTime"] = item.FreeEndTime;
                    dic["FreeType"] = item.FreeType;
                    list.Add(dic);
                }
                else if (item.FreeStartTime <= _CalculateStartTime && item.FreeEndTime >= _CalculateEndTime)
                {
                    dic = new Dictionary<string, object>();
                    dic["StartTime"] = _CalculateStartTime;
                    dic["EndTime"] = _CalculateEndTime;
                    dic["FreeType"] = item.FreeType;
                    list.Add(dic);
                }
                else if (item.FreeStartTime >= _CalculateStartTime && item.FreeEndTime >= _CalculateEndTime)
                {
                    dic = new Dictionary<string, object>();
                    dic["StartTime"] = item.FreeStartTime;
                    dic["EndTime"] = _CalculateEndTime;
                    dic["FreeType"] = item.FreeType;
                    list.Add(dic);
                }
                else if (item.FreeStartTime <= _CalculateStartTime && item.FreeEndTime <= _CalculateEndTime)
                {
                    dic = new Dictionary<string, object>();
                    dic["StartTime"] = _CalculateStartTime;
                    dic["EndTime"] = item.FreeEndTime;
                    dic["FreeType"] = item.FreeType;
                    list.Add(dic);
                }
            }
            return list;
        }
        public static List<Dictionary<string, object>> Get_ActiveCuiShouTimeRange(int ContractID, DateTime CalculateCuiShouStartTime, DateTime CalculateCuiShouEndTime, int ChargeID, int ContractDivideID)
        {
            var list = new List<Dictionary<string, object>>();
            if (ContractID == 0 || ContractDivideID > 0)
            {
                return list;
            }
            var FreeTimeList = RoomFeeAnalysisBase.GetContractFreeTimeList();
            var my_list = FreeTimeList.Where(p => p.ContractID == ContractID).ToArray();
            if (my_list.Length == 0)
            {
                return list;
            }
            var _CalculateCuiShouStartTime = CalculateCuiShouStartTime;
            var _CalculateCuiShouEndTime = CalculateCuiShouEndTime;
            foreach (var item in my_list)
            {
                List<int> ChargeIDList = item.FreeChargeIDs.Split(',').Select(p => { return Convert.ToInt32(p); }).ToList();
                if (!ChargeIDList.Contains(ChargeID))
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
                if (item.FreeStartTime >= _CalculateCuiShouEndTime || item.FreeEndTime <= _CalculateCuiShouStartTime)
                {
                    continue;
                }
                var dic = new Dictionary<string, object>();
                if (item.FreeStartTime >= _CalculateCuiShouStartTime && item.FreeEndTime <= _CalculateCuiShouEndTime)
                {
                    dic = new Dictionary<string, object>();
                    dic["StartTime"] = item.FreeStartTime;
                    dic["EndTime"] = item.FreeEndTime;
                    dic["FreeType"] = item.FreeType;
                    list.Add(dic);
                }
                else if (item.FreeStartTime <= _CalculateCuiShouStartTime && item.FreeEndTime >= _CalculateCuiShouEndTime)
                {
                    dic = new Dictionary<string, object>();
                    dic["StartTime"] = CalculateCuiShouStartTime;
                    dic["EndTime"] = CalculateCuiShouEndTime;
                    dic["FreeType"] = item.FreeType;
                    list.Add(dic);
                }
                else if (item.FreeStartTime >= _CalculateCuiShouStartTime && item.FreeEndTime >= CalculateCuiShouEndTime)
                {
                    dic = new Dictionary<string, object>();
                    dic["StartTime"] = item.FreeStartTime;
                    dic["EndTime"] = _CalculateCuiShouEndTime;
                    dic["FreeType"] = item.FreeType;
                    list.Add(dic);
                }
                else if (item.FreeStartTime <= _CalculateCuiShouStartTime && item.FreeEndTime <= _CalculateCuiShouEndTime)
                {
                    dic = new Dictionary<string, object>();
                    dic["StartTime"] = _CalculateCuiShouStartTime;
                    dic["EndTime"] = item.FreeEndTime;
                    dic["FreeType"] = item.FreeType;
                    list.Add(dic);
                }
            }
            return list;
        }
        public static decimal Get_CalcualteDiscount(DateTime InPutStartTime, DateTime InPutEndTime, RoomFeeAnalysis analysis = null, ViewRoomFee roomfee = null)
        {
            if (analysis != null)
            {
                analysis.InPutStartTime = InPutStartTime;
                analysis.InPutEndTime = InPutEndTime;
                return Get_CalcualteDiscount(analysis.InPutStartTime, analysis.InPutEndTime, analysis.ContractID, analysis.StartTime, analysis.EndTime, analysis.ActiveTimeRange, analysis: analysis);
            }
            if (roomfee != null)
            {
                roomfee.InPutStartTime = InPutStartTime;
                roomfee.InPutEndTime = InPutEndTime;
                return Get_CalcualteDiscount(roomfee.InPutStartTime, roomfee.InPutEndTime, roomfee.ContractID, roomfee.StartTime, roomfee.EndTime, roomfee.ActiveTimeRange, roomfee: roomfee);
            }
            return 0;
        }
        /// <summary>
        /// 合同减免金额
        /// </summary>
        public static decimal Get_CalcualteDiscount(DateTime InPutStartTime, DateTime InPutEndTime, int ContractID, DateTime StartTime, DateTime EndTime, List<Dictionary<string, object>> ActiveTimeRange, RoomFeeAnalysis analysis = null, ViewRoomFee roomfee = null)
        {
            if (ContractID > 0)
            {
                if (StartTime > InPutEndTime && InPutEndTime > DateTime.MinValue)
                {
                    return 0;
                }
                if (EndTime < InPutStartTime && InPutStartTime > DateTime.MinValue)
                {
                    return 0;
                }
            }
            if (ActiveTimeRange.Count == 0)
            {
                return 0;
            }
            if (analysis != null && analysis.ContractDivideID > 0)
            {
                return 0;
            }
            if (roomfee != null && roomfee.ContractDivideID > 0)
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
                    reduce_cost += RoomFeeAnalysisBase.CalculateTotalCostByTime(_StartTime, _EndTime, analysis: analysis, roomfee: roomfee);
                }
            }
            return reduce_cost;
        }
        public static decimal Get_ALLFinalTotalCost(DateTime InPutStartTime, DateTime InPutEndTime, RoomFeeAnalysis analysis = null, ViewRoomFee roomfee = null)
        {
            if (analysis != null)
            {
                analysis.InPutStartTime = InPutStartTime;
                analysis.InPutEndTime = InPutEndTime;
                return Get_ALLFinalTotalCost(analysis.InPutStartTime, analysis.InPutEndTime, analysis.CalculateStartTime, analysis.CalculateEndTime, analysis.ContractID, analysis.StartTime, analysis.EndTime, analysis.ReadyChargeTime, analysis: analysis);
            }
            if (roomfee != null)
            {
                roomfee.InPutStartTime = InPutStartTime;
                roomfee.InPutEndTime = InPutEndTime;
                return Get_ALLFinalTotalCost(roomfee.InPutStartTime, roomfee.InPutEndTime, roomfee.CalculateStartTime, roomfee.CalculateEndTime, roomfee.ContractID, roomfee.StartTime, roomfee.EndTime, roomfee.ReadyChargeTime, roomfee: roomfee);
            }
            return 0;
        }
        public static decimal Get_ALLFinalTotalCost(DateTime InPutStartTime, DateTime InPutEndTime, DateTime CalculateStartTime, DateTime CalculateEndTime, int ContractID, DateTime StartTime, DateTime EndTime, DateTime ReadyChargeTime, RoomFeeAnalysis analysis = null, ViewRoomFee roomfee = null, ViewRoomFeeHistoryDetail historyfee = null)
        {
            if (InPutEndTime > DateTime.MinValue && CalculateStartTime > InPutEndTime && ContractID <= 0)
            {
                return 0;
            }
            if (ContractID > 0)
            {
                if (StartTime > InPutEndTime && InPutEndTime > DateTime.MinValue)
                {
                    return 0;
                }
                if (EndTime < InPutStartTime && InPutStartTime > DateTime.MinValue)
                {
                    return 0;
                }
            }
            DateTime _CalculateStartTime = CalculateStartTime;
            DateTime _CalculateEndTime = CalculateEndTime;
            //if (self.ContractID > 0)
            //{
            //    if (self.ReadyChargeTime > DateTime.MinValue)
            //    {
            //        if (self.InPutStartTime > DateTime.MinValue)
            //        {
            //            if (self.ReadyChargeTime >= self.InPutStartTime)
            //            {
            //                _CalculateStartTime = self.StartTime;
            //            }
            //            else
            //            {
            //                _CalculateStartTime = DateTime.MinValue;
            //            }
            //        }
            //        if (self.InPutEndTime > DateTime.MinValue)
            //        {
            //            if (self.ReadyChargeTime <= self.InPutEndTime)
            //            {
            //                _CalculateEndTime = self.EndTime;
            //            }
            //            else
            //            {
            //                _CalculateEndTime = DateTime.MinValue;
            //            }
            //        }
            //    }
            //}
            decimal totalcost = RoomFeeAnalysisBase.CalculateTotalCostByTime(_CalculateStartTime, _CalculateEndTime, analysis: analysis, roomfee: roomfee, historyfee: historyfee);
            return (totalcost > 0 ? totalcost : 0);
        }
        public static decimal Get_ALLTotalCost(DateTime InPutStartTime, DateTime InPutEndTime, RoomFeeAnalysis analysis = null, ViewRoomFee roomfee = null)
        {
            if (analysis != null)
            {
                analysis.InPutStartTime = InPutStartTime;
                analysis.InPutEndTime = InPutEndTime;
                return Get_ALLTotalCost(analysis.InPutStartTime, analysis.InPutEndTime, analysis.CalculateStartTime, analysis.ContractID, analysis.ALLFinalTotalCost, analysis.ActiveTimeRange, analysis: analysis);
            }
            if (roomfee != null)
            {
                roomfee.InPutStartTime = InPutStartTime;
                roomfee.InPutEndTime = InPutEndTime;
                return Get_ALLTotalCost(roomfee.InPutStartTime, roomfee.InPutEndTime, roomfee.CalculateStartTime, roomfee.ContractID, roomfee.ALLFinalTotalCost, roomfee.ActiveTimeRange, roomfee: roomfee);
            }
            return 0;
        }
        /// <summary>
        /// 应收金额(包含合同减免)
        /// </summary>
        public static decimal Get_ALLTotalCost(DateTime InPutStartTime, DateTime InPutEndTime, DateTime CalculateStartTime, int ContractID, decimal ALLFinalTotalCost, List<Dictionary<string, object>> ActiveTimeRange, RoomFeeAnalysis analysis = null, ViewRoomFee roomfee = null)
        {
            decimal totalcost = ALLFinalTotalCost;
            if (ActiveTimeRange.Count == 0)
            {
                return totalcost;
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
                    reduce_cost += RoomFeeAnalysisBase.CalculateTotalCostByTime(InPutStartTime, InPutEndTime, analysis: analysis, roomfee: roomfee);
                }
            }
            decimal total = totalcost - reduce_cost;
            total = (total > 0 ? total : 0);
            return total;
        }
        /// <summary>
        /// 应收金额(包含合同减免)
        /// </summary>
        public static decimal Get_TotalCost(decimal ALLTotalCost, decimal CalcualteDiscount)
        {
            decimal cost = ALLTotalCost;
            //cost final_total_cost = ALLTotalCost - CalcualteDiscount;            
            return (cost > 0 ? cost : 0);
        }
        /// <summary>
        /// 未收金额
        /// </summary>
        public static decimal Get_TotalFinalCost(decimal ALLTotalCost, decimal CalcualteDiscount, decimal TotalFinalPayCost, decimal TotalFinalDiscountCost)
        {
            decimal cost = ALLTotalCost - CalcualteDiscount - TotalFinalPayCost - TotalFinalDiscountCost;
            return (cost > 0 ? cost : 0);
        }
        /// <summary>
        ///  催收金额(不包含合同减免)
        /// </summary>
        public static decimal Get_CuiShouTotalCost(decimal AllCuiShouTotalCost, decimal CalcualteDiscount)
        {
            decimal cost = AllCuiShouTotalCost - CalcualteDiscount;
            return cost > 0 ? cost : 0;
        }
        public static decimal Get_AllCuiShouTotalCost(DateTime InPutStartTime, DateTime InPutEndTime, RoomFeeAnalysis analysis = null, ViewRoomFee roomfee = null)
        {
            if (analysis != null)
            {
                analysis.InPutStartTime = InPutStartTime;
                analysis.InPutEndTime = InPutEndTime;
                return Get_AllCuiShouTotalCost(analysis.InPutStartTime, analysis.InPutEndTime, analysis.CalculateCuiShouStartTime, analysis.CalculateCuiShouEndTime, analysis.ActiveTimeRange, analysis.ActiveCuiShouTimeRange, analysis: analysis);
            }
            if (roomfee != null)
            {
                roomfee.InPutStartTime = InPutStartTime;
                roomfee.InPutEndTime = InPutEndTime;
                return Get_AllCuiShouTotalCost(roomfee.InPutStartTime, roomfee.InPutEndTime, roomfee.CalculateCuiShouStartTime, roomfee.CalculateCuiShouEndTime, roomfee.ActiveTimeRange, roomfee.ActiveCuiShouTimeRange, roomfee: roomfee);
            }
            return 0;
        }
        /// <summary>
        ///  催收金额(包含合同减免)
        /// </summary>
        public static decimal Get_AllCuiShouTotalCost(DateTime InPutStartTime, DateTime InPutEndTime, DateTime CalculateCuiShouStartTime, DateTime CalculateCuiShouEndTime, List<Dictionary<string, object>> ActiveTimeRange, List<Dictionary<string, object>> ActiveCuiShouTimeRange, RoomFeeAnalysis analysis = null, ViewRoomFee roomfee = null)
        {
            if (InPutEndTime > DateTime.MinValue && CalculateCuiShouStartTime > InPutEndTime)
            {
                return 0;
            }
            decimal totalcost = RoomFeeAnalysisBase.CalculateTotalCostByTime(CalculateCuiShouStartTime, CalculateCuiShouEndTime, analysis: analysis, roomfee: roomfee);
            if (ActiveTimeRange.Count == 0)
            {
                return totalcost;
            }
            decimal reduce_cost = 0;
            foreach (var item in ActiveCuiShouTimeRange)
            {
                int _FreeType = 0;
                int.TryParse(item["FreeType"].ToString(), out _FreeType);
                if (_FreeType == 1)
                {
                    DateTime _StartTime = DateTime.MinValue;
                    DateTime.TryParse(item["StartTime"].ToString(), out _StartTime);
                    DateTime _EndTime = DateTime.MinValue;
                    DateTime.TryParse(item["EndTime"].ToString(), out _EndTime);
                    reduce_cost += RoomFeeAnalysisBase.CalculateTotalCostByTime(_StartTime, _EndTime, analysis: analysis, roomfee: roomfee);
                }
            }
            decimal total = totalcost - reduce_cost;
            total = (total > 0 ? total : 0);
            return total;
        }
        public static string Get_ChargeTypeDesc(int TypeID)
        {
            string typedesc = string.Empty;
            switch (TypeID)
            {
                case 1:
                    typedesc = "单价*计费面积(月度)";
                    break;
                case 2:
                    typedesc = "定额(月度)";
                    break;
                case 3:
                    typedesc = "单价*计费面积*公摊系数(月度)";
                    break;
                case 4:
                    typedesc = "定额(年度)";
                    break;
                case 5:
                    typedesc = "单价*计费面积(按天)";
                    break;
                case 6:
                    typedesc = "单价*计费面积/用量(一次性)";
                    break;
                default:
                    break;
            }
            return typedesc;
        }
        public static decimal Get_TotalFinalPayCost(RoomFeeAnalysis analysis = null, ViewRoomFee roomfee = null)
        {
            if (analysis != null)
            {
                return Get_TotalFinalPayCost(analysis.ViewRoomFeeHistoryDetailList, analysis.InPutStartTime, analysis.InPutEndTime, analysis.ID);
            }
            if (roomfee != null)
            {
                return Get_TotalFinalPayCost(roomfee.ViewRoomFeeHistoryDetailList, roomfee.InPutStartTime, roomfee.InPutEndTime, roomfee.ID);
            }
            return 0;
        }
        /// <summary>
        ///  已收金额
        /// </summary>
        public static decimal Get_TotalFinalPayCost(ViewRoomFeeHistoryDetail[] ViewRoomFeeHistoryDetailList, DateTime InPutStartTime, DateTime InPutEndTime, int ID)
        {
            decimal cost = 0;
            if (ViewRoomFeeHistoryDetailList != null && ViewRoomFeeHistoryDetailList.Length > 0)
            {
                var history_list = ViewRoomFeeHistoryDetail.GetFinalViewRoomFeeHistoryDetailList(ViewRoomFeeHistoryDetailList, InPutStartTime, InPutEndTime);
                cost = history_list.Where(p =>
                {
                    return p.ID == ID && p.MonthTotalCost > 0;
                }).Sum(p =>
                {
                    p.InPutStartTime = InPutStartTime;
                    p.InPutEndTime = InPutEndTime;
                    return p.MonthTotalCost;
                });
            }
            return cost;
        }
        public static string Get_ChargeDiscountName(ViewRoomFeeHistoryDetail[] ViewRoomFeeHistoryDetailList, DateTime InPutStartTime, DateTime InPutEndTime, int ID, int RoomID, int ChargeID, int Contract_RoomChargeID)
        {
            string Name = string.Empty;
            if (ViewRoomFeeHistoryDetailList != null && ViewRoomFeeHistoryDetailList.Length > 0)
            {
                var history_list = ViewRoomFeeHistoryDetailList.Where(p =>
                {
                    p.InPutStartTime = InPutStartTime;
                    p.InPutEndTime = InPutEndTime;
                    if (p.ImportFeeID > 0 && p.WriteDate < InPutStartTime && InPutStartTime > DateTime.MinValue)
                    {
                        return false;
                    }
                    if (p.ImportFeeID > 0 && p.WriteDate > InPutEndTime && InPutEndTime > DateTime.MinValue)
                    {
                        return false;
                    }
                    bool result1 = p.RoomID == RoomID && p.ChargeID == ChargeID && p.ID == ID;
                    bool result2 = p.RoomID == RoomID && p.ChargeID == ChargeID && p.Contract_RoomChargeID == Contract_RoomChargeID && Contract_RoomChargeID > 0;
                    return (result1 || result2) && p.MonthTotalCost > 0;
                }).ToArray();
                if (history_list.Length > 0)
                {
                    if (RoomFeeAnalysisBase.ChargeDiscountList == null)
                    {
                        RoomFeeAnalysisBase.ChargeDiscountList = ChargeDiscount.GetChargeDiscounts().ToArray();
                    }
                    var my_charge_discount_list = RoomFeeAnalysisBase.ChargeDiscountList.Where(p => history_list.Select(q => q.DiscountID).ToList().Contains(p.ID)).ToArray();
                    if (my_charge_discount_list.Length > 0)
                    {
                        Name = string.Join(",", my_charge_discount_list.Select(p => p.DiscountName).ToArray());
                    }
                }
            }
            return Name;
        }
        /// <summary>
        ///  已收折扣
        /// </summary>
        public static decimal Get_TotalFinalDiscountCost(ViewRoomFeeHistoryDetail[] ViewRoomFeeHistoryDetailList, DateTime InPutStartTime, DateTime InPutEndTime, int ID, int RoomID, int ChargeID, int Contract_RoomChargeID)
        {
            decimal cost = 0;
            if (ViewRoomFeeHistoryDetailList != null && ViewRoomFeeHistoryDetailList.Length > 0)
            {
                var history_list = ViewRoomFeeHistoryDetail.GetFinalViewRoomFeeHistoryDetailList(ViewRoomFeeHistoryDetailList, InPutStartTime, InPutEndTime);
                cost = history_list.Where(p =>
                {
                    bool result1 = p.RoomID == RoomID && p.ChargeID == ChargeID && p.ID == ID;
                    bool result2 = p.RoomID == RoomID && p.ChargeID == ChargeID && p.Contract_RoomChargeID == Contract_RoomChargeID && Contract_RoomChargeID > 0;
                    return (result1 || result2) && p.MonthDiscountCost > 0;
                }).Sum(p =>
                {
                    p.InPutStartTime = InPutStartTime;
                    p.InPutEndTime = InPutEndTime;
                    return p.MonthDiscountCost;
                });
            }
            return cost;
        }
        public static decimal GetAnalysisQueryValue(bool IsAnalysisQuery, decimal result, int EndNumberCount = 2)
        {
            EndNumberCount = EndNumberCount < 0 ? 0 : EndNumberCount;
            if (IsAnalysisQuery)
            {
                result = Math.Round(result, EndNumberCount, MidpointRounding.AwayFromZero);
            }
            return result;
        }
        public static decimal GetJieTiUnitPrice(bool IsPriceRange, int ID, int ChargeID, decimal TotalUseCount, decimal CalculateUseCount)
        {
            decimal JieTieUnitPrice = 0;
            if (IsPriceRange)
            {
                var ChargePriceRangeList = GetPriceRangeList(ID, ChargeID);
                if (ChargePriceRangeList != null && ChargePriceRangeList.Length > 0)
                {
                    var my_pricerangelist = ChargePriceRangeList.Where(p => p.SummaryID == ChargeID).ToArray();
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
                            NianTotal = (TotalUseCount > 0 ? TotalUseCount : 0);
                        }
                        if ((NianTotal + CalculateUseCount) >= MinValue && (NianTotal + CalculateUseCount) < MaxValue)
                        {
                            JieTieUnitPrice = pricerange.BasePrice;
                            break;
                        }
                        if ((NianTotal + CalculateUseCount) >= MaxValue)
                        {
                            if (i == my_pricerangelist.Length - 1)
                            {
                                JieTieUnitPrice = pricerange.BasePrice;
                                break;
                            }
                            if (pricerange.BaseType.Equals(Utility.EnumModel.PriceRangeType.qnyl.ToString()))
                            {
                                if (MaxValue > NianTotal)
                                {
                                    JieTieUnitPrice = pricerange.BasePrice;
                                    break;
                                }
                            }
                            else
                            {
                                JieTieUnitPrice = pricerange.BasePrice;
                                break;
                            }
                        }
                    }
                }
            }
            return JieTieUnitPrice;
        }
        public static decimal CalculateTotalCostByTime(DateTime _StartTime, DateTime _EndTime, RoomFeeAnalysis analysis = null, ViewRoomFee roomfee = null, ViewRoomFeeHistoryDetail historyfee = null, ViewContractChargeSummary contractSummary = null, ViewContract_TempPrice contractTempPrice = null)
        {
            if (analysis != null)
            {
                return CalculateTotalCostByTime(_StartTime, _EndTime, analysis.EndNumberCount, analysis.IsAnalysisQuery, analysis.ContractID, analysis.ID, analysis.ContractDivideID, analysis.IsPriceRange, analysis.ChargeID, analysis.TotalUseCount, analysis.CalculateUseCount, analysis.ImportCoefficient, analysis.ImportFeeID, analysis.IsMeterFee, analysis.CalculateUnitPrice, analysis.CalculateCoefficient, analysis.Cost, analysis.CalculateStartTime, analysis.CalculateEndTime, analysis.FeeType, analysis.ChargeWeiYueType, analysis.WeiYuePercent, analysis.RelatedFeeID, analysis.DayGunLi, analysis.TypeID, analysis.FenTanCoefficient);
            }
            if (roomfee != null)
            {
                return CalculateTotalCostByTime(_StartTime, _EndTime, roomfee.EndNumberCount, roomfee.IsAnalysisQuery, roomfee.ContractID, roomfee.ID, roomfee.ContractDivideID, roomfee.IsPriceRange, roomfee.ChargeID, roomfee.TotalUseCount, roomfee.CalculateUseCount, roomfee.ImportCoefficient, roomfee.ImportFeeID, roomfee.IsMeterFee, roomfee.CalculateUnitPrice, roomfee.CalculateCoefficient, roomfee.Cost, roomfee.CalculateStartTime, roomfee.CalculateEndTime, roomfee.FeeType, roomfee.ChargeWeiYueType, roomfee.WeiYuePercent, roomfee.RelatedFeeID, roomfee.DayGunLi, roomfee.TypeID, roomfee.FenTanCoefficient);
            }
            if (historyfee != null)
            {
                return CalculateTotalCostByTime(_StartTime, _EndTime, historyfee.EndNumberCount, true, historyfee.ContractID, historyfee.ID, historyfee.ContractDivideID, false, historyfee.ChargeID, 0, historyfee.UseCount, 0, historyfee.ImportFeeID, historyfee.IsMeterFee, historyfee.UnitPrice, 0, historyfee.Cost, historyfee.StartTime, historyfee.EndTime, historyfee.FeeType, historyfee.ChargeWeiYueType, historyfee.WeiYuePercent, historyfee.RelatedFeeID, historyfee.DayGunLi, historyfee.TypeID, historyfee.FenTanCoefficient, isHistoryFee: true);
            }
            if (contractSummary != null)
            {
                return CalculateTotalCostByTime(_StartTime, _EndTime, contractSummary.EndNumberCount, false, contractSummary.ContractID, contractSummary.RoomFeeID, 0, false, contractSummary.ChargeID, 0, contractSummary.CalculateUseCount, 0, 0, false, contractSummary.CalculateUnitPrice, 0, contractSummary.RoomCost, contractSummary.CalculateStartTime, contractSummary.CalculateEndTime, contractSummary.FeeType, contractSummary.ChargeWeiYueType, contractSummary.WeiYuePercent, 0, contractSummary.DayGunLi, contractSummary.TypeID, contractSummary.FenTanCoefficient);
            }
            if (contractTempPrice != null)
            {
                return CalculateTotalCostByTime(_StartTime, _EndTime, contractTempPrice.EndNumberCount, false, contractTempPrice.ContractID, 0, 0, false, contractTempPrice.ChargeID, 0, contractTempPrice.CalculateUseCount, 0, 0, false, contractTempPrice.CalculatePrice, 0, 0, contractTempPrice.CalculateStartTime, contractTempPrice.CalculateEndTime, contractTempPrice.FeeType, contractTempPrice.ChargeWeiYueType, contractTempPrice.WeiYuePercent, 0, contractTempPrice.DayGunLi, contractTempPrice.TypeID, contractTempPrice.FenTanCoefficient);
            }
            return 0;
        }
        public static decimal CalculateTotalCostByTime(DateTime _StartTime, DateTime _EndTime, int EndNumberCount, bool IsAnalysisQuery, int ContractID, int ID, int ContractDivideID, bool IsPriceRange, int ChargeID, decimal TotalUseCount, decimal CalculateUseCount, decimal ImportCoefficient, int ImportFeeID, bool IsMeterFee, decimal CalculateUnitPrice, decimal CalculateCoefficient, decimal Cost, DateTime CalculateStartTime, DateTime CalculateEndTime, int FeeType, int ChargeWeiYueType, decimal WeiYuePercent, int RelatedFeeID, bool DayGunLi, int TypeID, decimal FenTanCoefficient, bool isHistoryFee = false)
        {
            decimal cost = 0;
            EndNumberCount = EndNumberCount >= 0 ? EndNumberCount : 2;
            ImportCoefficient = (ImportCoefficient > 0 ? ImportCoefficient : 1);
            //if (IsAnalysisQuery)
            //{
            //    EndNumberCount = 4;
            //}
            try
            {
                if ((_StartTime == DateTime.MinValue || _EndTime == DateTime.MinValue) && ContractID > 0)
                {
                    return CalculateUnitPrice > 0 ? CalculateUnitPrice : 0;
                }
                #region 合同商业分成
                if (ContractDivideID > 0)
                {
                    if (isHistoryFee)
                    {
                        return Cost;
                    }
                    if (!contractdividefee.ContainsKey(ID))
                    {
                        if (ContractDivideList == null)
                        {
                            ContractDivideList = Contract_Divide.Get_Contract_DivideList();
                        }
                        Contract_Divide contractdivide = null;
                        if (ContractDivideList.Length > 0)
                        {
                            contractdivide = ContractDivideList.FirstOrDefault(p => p.ID == ContractDivideID);
                        }
                        if (contractdivide == null)
                        {
                            contractdividefee.Add(ID, 0);
                        }
                        else
                        {
                            contractdividefee.Add(ID, contractdivide.TotalCost);
                        }
                    }
                    cost = contractdividefee[ID];
                    return RoomFeeAnalysisBase.GetAnalysisQueryValue(true, cost, EndNumberCount: EndNumberCount);
                }
                #endregion
                #region 阶梯单价
                if (IsPriceRange)
                {
                    if (isHistoryFee)
                    {
                        return Cost;
                    }
                    var ChargePriceRangeList = GetPriceRangeList(ID, ChargeID);
                    if (ChargePriceRangeList != null && ChargePriceRangeList.Length > 0)
                    {
                        var my_pricerangelist = ChargePriceRangeList.Where(p => p.SummaryID == ChargeID).ToArray();
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
                                NianTotal = (TotalUseCount > 0 ? TotalUseCount : 0);
                            }
                            if ((NianTotal + CalculateUseCount) >= MinValue && (NianTotal + CalculateUseCount) < MaxValue)
                            {
                                if (NianTotal > MinValue)
                                {
                                    cost += CalculateUseCount * pricerange.BasePrice * ImportCoefficient;
                                }
                                else
                                {
                                    cost += (NianTotal + CalculateUseCount - MinValue) * pricerange.BasePrice * ImportCoefficient;
                                }
                                break;
                            }
                            if ((NianTotal + CalculateUseCount) >= MaxValue)
                            {
                                if (i == my_pricerangelist.Length - 1)
                                {
                                    cost += (NianTotal + CalculateUseCount - MinValue) * pricerange.BasePrice * ImportCoefficient;
                                    break;
                                }
                                if (pricerange.BaseType.Equals(Utility.EnumModel.PriceRangeType.qnyl.ToString()))
                                {
                                    if (MaxValue > NianTotal)
                                    {
                                        MinValue = (NianTotal > MinValue ? NianTotal : MinValue);
                                        cost += (MaxValue - MinValue) * pricerange.BasePrice * ImportCoefficient;
                                    }
                                }
                                else
                                {
                                    cost += (MaxValue - MinValue) * pricerange.BasePrice * ImportCoefficient;
                                }
                            }
                        }
                        return RoomFeeAnalysisBase.GetAnalysisQueryValue(true, cost, EndNumberCount: EndNumberCount);
                    }
                    return 0;
                }
                #endregion
                #region 导入账单费用或者抄表登记
                if (ImportFeeID > 0 || IsMeterFee)
                {
                    cost = CalculateUseCount * CalculateUnitPrice * CalculateCoefficient;
                    cost = cost > 0 ? cost : Cost;
                    if (cost > 0)
                    {
                        return RoomFeeAnalysisBase.GetAnalysisQueryValue(true, cost, EndNumberCount: EndNumberCount);
                    }
                    return 0;
                }
                #endregion
                #region 违约金
                var _CalculateStartTime = CalculateStartTime;
                var _CalculateEndTime = CalculateEndTime;
                if (FeeType == 8)
                {
                    if (isHistoryFee)
                    {
                        return Cost;
                    }
                    decimal weiyuetotal = 0;
                    if (ChargeWeiYueType == 1 && WeiYuePercent > 0 && _CalculateStartTime > DateTime.MinValue && _CalculateEndTime > DateTime.MinValue && RelatedFeeID > 0)
                    {
                        RoomFeeAnalysis parent_roomfee = null;
                        if (RoomFeeAnalysisBase.parent_list.ContainsKey(RelatedFeeID))
                        {
                            parent_roomfee = RoomFeeAnalysisBase.parent_list[RelatedFeeID];
                        }
                        else
                        {
                            parent_roomfee = RoomFeeAnalysis.GetParentRoomFeeAnalysis(RelatedFeeID, false);
                            RoomFeeAnalysisBase.parent_list[RelatedFeeID] = parent_roomfee;
                        }
                        if (parent_roomfee != null && parent_roomfee.TotalCost > 0 && parent_roomfee.FeeType != 8)
                        {
                            int weiyuedays = Convert.ToInt32((_CalculateEndTime - _CalculateStartTime).TotalSeconds / (60 * 60 * 24));
                            if (DayGunLi)
                            {
                                calculateRateCost(parent_roomfee.TotalCost, 0, weiyuedays, WeiYuePercent);
                                foreach (var item in ratecostlist)
                                {
                                    weiyuetotal += item;
                                }
                            }
                            else
                            {
                                weiyuetotal = parent_roomfee.TotalCost * weiyuedays * WeiYuePercent;
                            }
                            return RoomFeeAnalysisBase.GetAnalysisQueryValue(true, weiyuetotal, EndNumberCount: EndNumberCount);
                        }
                    }
                }
                #endregion
                if (TypeID <= 0)
                {
                    return RoomFeeAnalysisBase.GetAnalysisQueryValue(true, CalculateUnitPrice, EndNumberCount: EndNumberCount);
                }
                //单价*计费面积(一次性)
                if (TypeID == 6)
                {
                    return RoomFeeAnalysisBase.GetAnalysisQueryValue(true, (decimal)(CalculateUseCount * CalculateUnitPrice), EndNumberCount: EndNumberCount);
                }
                if (_StartTime == DateTime.MinValue || _EndTime == DateTime.MinValue)
                {
                    return 0;
                }
                if (_StartTime > _EndTime)
                {
                    return 0;
                }
                int monthnumber = Utility.Tools.calculatemonth(_StartTime, _EndTime);
                decimal totaldays = Utility.Tools.calculateTotaldays(_StartTime, _EndTime, monthnumber, true);
                int restdays = Utility.Tools.calculateTotaldays(_StartTime, _EndTime, monthnumber, false);
                switch (TypeID)
                {
                    //单价*计费面积(月度)
                    case 1:
                        cost = (decimal)(CalculateUseCount * CalculateUnitPrice * (monthnumber + (restdays / totaldays)));
                        break;
                    //定额(月度)
                    case 2:
                        cost = (decimal)(CalculateUnitPrice * (monthnumber + (restdays / totaldays)));
                        break;
                    //单价*计费面积*公摊系数(月度)
                    case 3:
                        decimal Coefficient = FenTanCoefficient > 0 ? FenTanCoefficient : 0;
                        cost = (decimal)(Coefficient * CalculateUseCount * CalculateUnitPrice * (monthnumber + (restdays / totaldays)));
                        break;
                    //定额(年度)
                    case 4:
                        cost = (decimal)(CalculateUnitPrice * (monthnumber + (restdays / totaldays)) / 12);
                        break;
                    //单价*计费面积(按天)
                    case 5:
                        totaldays = 0;
                        if (_EndTime > DateTime.MinValue && _StartTime > DateTime.MinValue)
                        {
                            totaldays = Convert.ToDecimal((_EndTime - _StartTime).TotalSeconds / (60 * 60 * 24)) + 1;
                        }
                        cost = (decimal)(CalculateUseCount * CalculateUnitPrice * totaldays);
                        break;
                    //单价*计费面积(月度进位)
                    case 7:
                        cost = Math.Round((decimal)(CalculateUseCount * CalculateUnitPrice), 0, MidpointRounding.AwayFromZero) * (monthnumber + (restdays / totaldays));
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                Utility.LogHelper.WriteError("CalculateTotalCostByTime", "ID:" + ID, ex);
            }
            return RoomFeeAnalysisBase.GetAnalysisQueryValue(true, cost, EndNumberCount: EndNumberCount);
        }
        public static void calculateRateCost(decimal CalculateUnitPrice, int startnumber, int weiyuedays, decimal WeiYuePercent)
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
        private static ChargePriceRange[] GetPriceRangeList(int RoomFeeID, int ChargeID)
        {
            var list = new List<ChargePriceRange>();
            if (PriceFeeRangeList == null)
            {
                PriceFeeRangeList = ChargeFeePriceRange.GetAllActiveChargeFeePriceRangeList();
            }
            if (PriceFeeRangeList != null && PriceFeeRangeList.Length > 0)
            {
                var my_pricefee_list = PriceFeeRangeList.Where(p => p.RoomFeeID == RoomFeeID && p.SummaryID == ChargeID).ToArray();
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
                return list.OrderBy(p =>
                {
                    decimal minvalue = 0;
                    decimal.TryParse(p.MinValue, out minvalue);
                    return minvalue;
                }).ToArray();
            }
            return new ChargePriceRange[] { };
        }
        public static Contract_FreeTime[] GetContractFreeTimeList()
        {
            if (ContractFreeTimeList == null || ContractFreeTimeList.Length == 0)
            {
                ContractFreeTimeList = Contract_FreeTime.GetContract_FreeTimes().Where(p => !string.IsNullOrEmpty(p.FreeChargeIDs)).ToArray();
            }
            return ContractFreeTimeList;
        }
    }
}
