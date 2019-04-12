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
    /// This object represents the properties and methods of a ViewRoomFee.
    /// </summary>
    public partial class ViewRoomFee : EntityBaseReadOnly
    {
        #region 数据库属性
        [DatabaseColumn("PayCost")]
        public decimal PayCost { get; set; }
        [DatabaseColumn("CuiShouCount")]
        public int CuiShouCount { get; set; }
        [DatabaseColumn("PreChargeBalance")]
        public decimal PreChargeBalance { get; set; }
        [DatabaseColumn("TotalFinalRealCost")]
        public decimal TotalFinalRealCost { get; set; }
        [DatabaseColumn("PrintRemark")]
        public string PrintRemark { get; set; }
        [DatabaseColumn("InPutStartTime")]
        public DateTime InPutStartTime { get; set; }
        [DatabaseColumn("InPutEndTime")]
        public DateTime InPutEndTime { get; set; }
        [DatabaseColumn("IsAnalysisQuery")]
        public bool IsAnalysisQuery { get; set; }
        public string RelationName { get; set; }
        public string ChargeForMan { get; set; }
        public string RelatePhoneNumber { get; set; }
        public string BankAccountNo { get; set; }
        public string HomeAddress { get; set; }
        public string BelongTeam { get; set; }
        public string FormatFunctionCoefficient
        {
            get
            {
                if (this.FunctionCoefficient > 0)
                {
                    return this.FunctionCoefficient.ToString();
                }
                return string.Empty;
            }
        }
        public DateTime WechatNotifyTime { get; set; }
        #endregion
        #region 公用静态属性
        public static bool AutoEndTime = false;
        #endregion
        #region 公用属性
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
                var result = RoomFeeAnalysisBase.Get_CalcualteDiscount(this.InPutStartTime, this.InPutEndTime, roomfee: this);
                return RoomFeeAnalysisBase.GetAnalysisQueryValue(this.IsAnalysisQuery, result);
            }
        }
        public decimal ALLFinalTotalCost
        {
            get
            {
                var result = RoomFeeAnalysisBase.Get_ALLFinalTotalCost(this.InPutStartTime, this.InPutEndTime, roomfee: this);
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

                var result = RoomFeeAnalysisBase.Get_ALLTotalCost(this.InPutStartTime, this.InPutEndTime, roomfee: this);
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
                var result = RoomFeeAnalysisBase.Get_AllCuiShouTotalCost(this.InPutStartTime, this.InPutEndTime, roomfee: this);
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
                var result = RoomFeeAnalysisBase.Get_TotalFinalPayCost(roomfee: this);
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
        public List<int> RelationRoomIDList { get; set; }
        public string FinalCustomerName
        {
            get
            {
                return this.DefaultChargeManName;
            }
        }
        public string FinalCustomerPhone
        {
            get
            {
                return this.RelatePhoneNumber;
            }
        }
        #endregion
        #region 公用静态方法
        public static void ReSetParams()
        {
            Contract_Divide.ReSetParams();
            AutoEndTime = false;
        }
        public static Ui.DataGrid GetViewRoomFeeListGridByRoomID(List<int> RoomIDList, int FeeID, int CategoryID, int TypeID, List<int> FeeTypeList, DateTime StartTime, DateTime EndTime, int CompanyID, bool IsRoomFee, bool IsContractFee, int ContractID, string orderBy, long startRowIndex, int pageSize, bool IsAutoEndTime = false, List<int> ProjectIDList = null, int[] ChargeSummaryIDList = null, List<int> RoomPropertyList = null, string keywords = "", int StartTimeState = 0, int DivideID = 0, List<int> RoomStateList = null, int UserID = 0, int PreChargeID = 0, bool IsAnalysisQuery = false)
        {
            ReSetParams();
            AutoEndTime = IsAutoEndTime;
            long totalRows = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[IsStart]=1");
            conditions.Add("(Contract_RoomChargeID is null or Contract_RoomChargeID=0 or Contract_RoomChargeID in (select ID from [Contract_RoomCharge]))");
            if (RoomStateList != null && RoomStateList.Count > 0)
            {
                conditions.Add("[RoomID] in (select [RoomID] from [RoomBasic] where [RoomStateID] in (" + string.Join(",", RoomStateList.ToArray()) + "))");
            }
            if (DivideID > 0)
            {
                conditions.Add("isnull([ContractDivideID],0)=@DivideID");
                parameters.Add(new SqlParameter("@DivideID", DivideID));
            }
            if (StartTimeState == 1)
            {
                conditions.Add("isnull([StartTime],'')=''");
            }
            else if (StartTimeState == 2)
            {
                conditions.Add("isnull([StartTime],'')!=''");
            }
            if (IsRoomFee && !IsContractFee)
            {
                conditions.Add("isnull([ContractID],0)=0");
            }
            if (IsContractFee && !IsRoomFee)
            {
                conditions.Add("isnull([ContractID],0)>0");
            }
            if (ContractID > 0)
            {
                conditions.Add("[ContractID]=@ContractID");
                parameters.Add(new SqlParameter("@ContractID", ContractID));
                orderBy = " order by [StartTime] asc,[ContractID] asc,[ChargeID] asc,[DefaultOrder] asc";
            }
            else if (RoomIDList.Count > 0)
            {
                List<string> cmdlist = ViewRoomFeeHistory.GetRoomIDListConditions(RoomIDList, IsContractFee: IsContractFee);
                conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
            }
            if (ProjectIDList != null && ProjectIDList.Count > 0)
            {
                List<string> cmdlist = ViewRoomFeeHistory.GetProjectIDListConditions(ProjectIDList, IsContractFee: IsContractFee, UserID: UserID);
                conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
            }
            if (CompanyID > 1)
            {
                conditions.Add(" [ChargeID] in (select [ID] from [ChargeSummary] where [CompanyID]=@CompanyID)");
                parameters.Add(new SqlParameter("@CompanyID", CompanyID));
            }
            if (StartTime > DateTime.MinValue)
            {
                conditions.Add("((Convert(nvarchar(10),[WriteDate],120)>=@StartTime and [ImportFeeID]>0) or (Convert(nvarchar(10),[RoomFeeWriteDate],120)>=@StartTime and [ChargeMeterProjectFeeID]>0) or (isnull([ImportFeeID],0)=0 and isnull([ChargeMeterProjectFeeID],0)=0))");
                parameters.Add(new SqlParameter("@StartTime", StartTime));
            }
            if (EndTime > DateTime.MinValue)
            {
                conditions.Add("((Convert(nvarchar(10),[WriteDate],120)<=@EndTime and [ImportFeeID]>0) or (Convert(nvarchar(10),[RoomFeeWriteDate],120)<=@EndTime and [ChargeMeterProjectFeeID]>0) or (isnull([ImportFeeID],0)=0 and isnull([ChargeMeterProjectFeeID],0)=0))");
                parameters.Add(new SqlParameter("@EndTime", EndTime));
            }
            if (FeeTypeList.Count > 0)
            {
                conditions.Add("[FeeType] in (" + string.Join(",", FeeTypeList.ToArray()) + ")");
            }
            if (CategoryID > 0)
            {
                conditions.Add("[CategoryID]=@CategoryID");
                parameters.Add(new SqlParameter("@CategoryID", CategoryID));
            }
            if (TypeID > 0)
            {
                conditions.Add("[TypeID]=@TypeID");
                parameters.Add(new SqlParameter("@TypeID", TypeID));
            }
            if (ChargeSummaryIDList != null && ChargeSummaryIDList.Length > 0)
            {
                conditions.Add("[ChargeID] in (" + string.Join(",", ChargeSummaryIDList) + ")");
            }
            if (RoomPropertyList != null && RoomPropertyList.Count > 0)
            {
                //List<string> cmdcondition = new List<string>();
                //foreach (var item in RoomPropertyList)
                //{
                //    cmdcondition.Add("'" + item + "'");
                //}
                conditions.Add("[RoomID] in (select [RoomID] from [RoomBasic] where [RoomPropertyID] in (" + string.Join(",", RoomPropertyList.ToArray()) + "))");
            }
            if (!string.IsNullOrEmpty(keywords))
            {
                conditions.Add("([Name] like @Keywords or [FullName] like @Keywords or [RoomName] like @Keywords)");
                parameters.Add(new SqlParameter("@Keywords", "%" + keywords + "%"));
            }
            string cmd_select = GetInPutTimeCmdString(StartTime, EndTime, IsAnalysisQuery);
            string fieldList = "A.*";
            string Statement = " from (select * from (select [ViewRoomFee].*" + cmd_select + ",(select Count(1) from RoomFeeHistory where [ID]=ViewRoomFee.ID and ChargeState=5) as CuiShouCount from [ViewRoomFee] where  " + string.Join(" and ", conditions.ToArray()) + " ) as B where 1=1) as A";
            ViewRoomFee[] list = new ViewRoomFee[] { };
            if (PreChargeID > 0)
            {
                parameters.Add(new SqlParameter("@PreChargeID", PreChargeID));
                conditions.Add("exists (select 1 from [RoomFeeHistory] where exists (select 1 from ChargeSummary where CategoryID = 4 and ID=RoomFeeHistory.ChargeID) and ChargeState=1 and [ChargeID]=@PreChargeID and  ([RoomFeeHistory].[RoomID]=[ViewRoomFee].RoomID or exists (select 1 from [RoomRelation] where [RoomID]=[ViewRoomFee].RoomID and [GUID] in (select [GUID] from [RoomRelation] where [RoomID]=[RoomFeeHistory].[RoomID]))))");
                list = GetList<ViewRoomFee>("select " + fieldList + Statement + " " + orderBy, parameters).ToArray();
                totalRows = list.Length;
            }
            else
            {
                list = GetList<ViewRoomFee>(fieldList, Statement, parameters, orderBy, startRowIndex, pageSize, out totalRows).ToArray();
            }
            if (list.Length > 0)
            {
                RoomFeeHistory[] historyList1 = new RoomFeeHistory[] { };
                RoomFeeHistory[] historyList2 = new RoomFeeHistory[] { };
                RoomRelation[] relationList = new RoomRelation[] { };
                int MinID = list.Min(p => p.RoomID);
                int MaxID = list.Max(p => p.RoomID);
                if (PreChargeID > 0)
                {
                    parameters = new List<SqlParameter>();
                    parameters.Add(new SqlParameter("@PreChargeID", PreChargeID));
                    historyList1 = GetList<RoomFeeHistory>("select [RoomID],[RealCost] from [RoomFeeHistory] where exists (select 1 from ChargeSummary where CategoryID = 4 and ID=RoomFeeHistory.ChargeID) and ChargeState=1 and [ChargeID]=@PreChargeID", parameters).ToArray();
                    if (historyList1.Length > 0)
                    {
                        relationList = RoomRelation.GetRoomRelationListByMinMaxRoomID(MinID, MaxID);
                        historyList2 = GetList<RoomFeeHistory>("select [RoomID],[RealCost] from [RoomFeeHistory] where ChargeState in (4,6) and ([ChargeID]=@PreChargeID or ChongDiChargeID=@PreChargeID)", parameters).ToArray();
                        foreach (var item in list)
                        {
                            var myRelationList = relationList.Where(q => q.RoomID == item.RoomID).ToArray();
                            if (myRelationList.Length > 0)
                            {
                                var guidList = myRelationList.Select(p => p.GUID).ToArray();
                                myRelationList = relationList.Where(p => guidList.Contains(p.GUID)).ToArray();
                            }
                            var relationRoomIDList = myRelationList.Select(p => p.RoomID).ToList();
                            relationRoomIDList.Add(item.RoomID);
                            decimal TotalPreCost = historyList1.Where(p => relationRoomIDList.Contains(p.RoomID)).Sum(p => p.RealCost);
                            decimal ChargePreCost = historyList2.Where(p => relationRoomIDList.Contains(p.RoomID)).Sum(p => p.RealCost);
                            decimal PreChargeBalance = TotalPreCost - ChargePreCost;
                            item.PreChargeBalance = PreChargeBalance;
                            item.RelationRoomIDList = relationRoomIDList;
                        }
                    }
                    list = list.Where(p => p.PreChargeBalance > 0).ToArray();
                    totalRows = list.Length;
                    list = list.Skip((int)startRowIndex).Take(pageSize).ToArray();
                }
                GetViewRoomFeeFinalDataList(list, StartTime, EndTime, StartTime, EndTime);
            }
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
        public static ViewRoomFee[] GetViewRoomFeeListHavingOpenIDs()
        {
            ReSetParams();
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("RoomID in (select ProjectID from WechatUser_Project)");
            conditions.Add("(Contract_RoomChargeID is null or Contract_RoomChargeID=0 or Contract_RoomChargeID in (select ID from [Contract_RoomCharge]))");
            string Statement = " select * from [ViewRoomFee] where  " + string.Join(" and ", conditions.ToArray());
            ViewRoomFee[] list = new ViewRoomFee[] { };
            list = GetList<ViewRoomFee>(Statement, parameters).ToArray();
            if (list.Length > 0)
            {
                list = SysConfig_Project.GetNotifyViewRoomFee(list);
            }
            GetViewRoomFeeOwnerName(list);
            return list;
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
        public static ViewRoomFee[] GetViewRoomFeeListByRoomID(List<int> RoomIDList, List<int> ProjectIDList, DateTime StartTime, DateTime EndTime, int[] ChargeSummaryID, int IsCharged, List<int> RoomPropertyList, bool IsRoomFee, bool IsContractFee, int ContractID, bool IsAutoEndTime = false, string keywords = "", bool ExcludeHistoryChargeTime = false, DateTime? StartChargeTime = null, DateTime? EndChargeTime = null, int DivideID = 0, List<int> RoomStateList = null, int UserID = 0, bool RequireOrderBy = true, DateTime? ReadyStartTime = null, DateTime? ReadyEndTime = null, bool IsContractWarning = false, bool IncludeRelation = true, bool IsAnalysisQuery = false, bool OnlyWuye = false, string RelationBelongTeam = "")
        {
            ReSetParams();
            AutoEndTime = IsAutoEndTime;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[IsStart]=1");
            conditions.Add("(Contract_RoomChargeID is null or Contract_RoomChargeID=0 or Contract_RoomChargeID in (select ID from [Contract_RoomCharge]))");
            if (OnlyWuye)
            {
                conditions.Add("ChargeFeeType=1");
            }
            if (IsContractWarning || (IsContractFee && !IsRoomFee) || ContractID > 0)
            {
                conditions.Add("isnull([ContractID],0) in (select [ID] from [Contract])");
            }
            if (IsContractWarning)
            {
                conditions.Add("([ReadyChargeTime]<=@ReadyChargeTime or [ReadyChargeTime] is null)");
                parameters.Add(new SqlParameter("@ReadyChargeTime", DateTime.Now));
            }
            if (RoomStateList != null && RoomStateList.Count > 0)
            {
                conditions.Add("[RoomID] in (select [RoomID] from [RoomBasic] where [RoomStateID] in (" + string.Join(",", RoomStateList.ToArray()) + "))");
            }
            if (DivideID > 0)
            {
                conditions.Add("isnull([ContractDivideID],0)=@DivideID");
                parameters.Add(new SqlParameter("@DivideID", DivideID));
            }
            if (!string.IsNullOrEmpty(keywords))
            {
                conditions.Add("([Name] like @Keywords or [FullName] like @Keywords or [RoomName] like @Keywords)");
                parameters.Add(new SqlParameter("@Keywords", "%" + keywords + "%"));
            }
            if (IsRoomFee && !IsContractFee)
            {
                conditions.Add("isnull([ContractID],0)=0");
            }
            if (IsContractFee && !IsRoomFee)
            {
                conditions.Add("isnull([ContractID],0)>0");
            }
            if (ContractID > 0)
            {
                conditions.Add("isnull([ContractID],0)=@ContractID");
                parameters.Add(new SqlParameter("@ContractID", ContractID));
            }
            if (RoomPropertyList.Count > 0)
            {
                conditions.Add("[RoomID] in (select [RoomID] from [RoomBasic] where [RoomPropertyID] in (" + string.Join(",", RoomPropertyList.ToArray()) + "))");
            }
            if (IsCharged >= 0)
            {
                conditions.Add("isnull([IsCharged],0)=@IsCharged");
                parameters.Add(new SqlParameter("@IsCharged", IsCharged));
            }
            if (StartTime > DateTime.MinValue)
            {
                conditions.Add("((Convert(nvarchar(10),[WriteDate],120)>=@StartTime and [ImportFeeID]>0) or (Convert(nvarchar(10),[RoomFeeWriteDate],120)>=@StartTime and [ChargeMeterProjectFeeID]>0) or (isnull([ImportFeeID],0)=0 and isnull([ChargeMeterProjectFeeID],0)=0))");
                parameters.Add(new SqlParameter("@StartTime", StartTime));
            }
            if (EndTime > DateTime.MinValue)
            {
                conditions.Add("((Convert(nvarchar(10),[WriteDate],120)<=@EndTime and [ImportFeeID]>0) or (Convert(nvarchar(10),[RoomFeeWriteDate],120)<=@EndTime and [ChargeMeterProjectFeeID]>0) or (isnull([ImportFeeID],0)=0 and isnull([ChargeMeterProjectFeeID],0)=0))");
                parameters.Add(new SqlParameter("@EndTime", EndTime));
            }
            if (ReadyStartTime.HasValue)
            {
                DateTime _ReadyStartTime = Convert.ToDateTime(ReadyStartTime);
                if (_ReadyStartTime > DateTime.MinValue)
                {
                    conditions.Add("(Convert(nvarchar(10),[ReadyChargeTime],120)>=@ReadyStartTime or [ReadyChargeTime] is null)");
                    parameters.Add(new SqlParameter("@ReadyStartTime", _ReadyStartTime));
                }
            }
            if (ReadyEndTime.HasValue)
            {
                DateTime _ReadyEndTime = Convert.ToDateTime(ReadyEndTime);
                if (_ReadyEndTime > DateTime.MinValue)
                {
                    conditions.Add("(Convert(nvarchar(10),[ReadyChargeTime],120)<=@ReadyEndTime or [ReadyChargeTime] is null)");
                    parameters.Add(new SqlParameter("@ReadyEndTime", _ReadyEndTime));
                }
            }
            if (RoomIDList.Count > 0)
            {
                List<string> cmdlist = ViewRoomFeeHistory.GetRoomIDListConditions(RoomIDList, IncludeRelation: IncludeRelation, IsContractFee: IsContractFee);
                if (ContractID > 0)
                {
                    cmdlist.Add("[RoomID]=0");
                }
                conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
            }
            if (ProjectIDList.Count > 0)
            {
                List<string> cmdlist = ViewRoomFeeHistory.GetProjectIDListConditions(ProjectIDList, IncludeRelation: IncludeRelation, IsContractFee: IsContractFee, UserID: UserID);
                if (ContractID > 0)
                {
                    cmdlist.Add("[RoomID]=0");
                }
                conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
            }
            if (ChargeSummaryID.Length > 0)
            {
                conditions.Add("[ChargeID] in (" + string.Join(",", ChargeSummaryID) + ")");
            }
            string orderby = string.Empty;
            if (RequireOrderBy)
            {
                orderby = " order by (case when FeeType=8 and RelatedFeeID>1 then isnull((select top 1 DefaultOrder from Project where ID=(select top 1 RoomID from RoomFee where ID=ViewRoomFee.RelatedFeeID)),DefaultOrder) else DefaultOrder end) asc,(case when FeeType=8 and RelatedFeeID>1 then isnull((select top 1 AddTime from RoomFee where ID=ViewRoomFee.RelatedFeeID),AddTime) else AddTime end) asc,AddTime asc";
            }
            string cmd_select = GetInPutTimeCmdString(StartTime, EndTime, IsAnalysisQuery);
            string Statement = " select * " + cmd_select + " from [ViewRoomFee] where  " + string.Join(" and ", conditions.ToArray()) + orderby;
            ViewRoomFee[] list = GetList<ViewRoomFee>(Statement, parameters).ToArray();
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
            if (!string.IsNullOrEmpty(RelationBelongTeam))
            {
                list = list.Where(p => !string.IsNullOrEmpty(p.BelongTeam) && p.BelongTeam.Contains(RelationBelongTeam)).ToArray();
            }
            return list;
        }
        public static Ui.DataGrid GetViewRoomFeeGridByRoomID(List<int> RoomIDList, List<int> ProjectIDList, DateTime StartTime, DateTime EndTime, int[] ChargeSummaryID, int IsCharged, List<int> RoomPropertyList, bool IsRoomFee, bool IsContractFee, int ContractID, bool IsAutoEndTime = false, string keywords = "", bool ExcludeHistoryChargeTime = false, DateTime? StartChargeTime = null, DateTime? EndChargeTime = null, int DivideID = 0, List<int> RoomStateList = null, int UserID = 0, bool RequireOrderBy = true, DateTime? ReadyStartTime = null, DateTime? ReadyEndTime = null, bool IsContractWarning = false, bool IncludeRelation = true, bool IsAnalysisQuery = false, bool OnlyWuye = false, int currentcount = 0, bool IsCuiShou = false, int pageSize = 0, bool ShowFooter = false, string RelationBelongTeam = "", bool canexport = false)
        {
            ViewRoomFee[] list = ViewRoomFee.GetViewRoomFeeListByRoomID(RoomIDList, ProjectIDList, StartTime, EndTime, ChargeSummaryID, IsCharged, RoomPropertyList, IsRoomFee, IsContractFee, ContractID, IsAutoEndTime, keywords, ExcludeHistoryChargeTime, DivideID: DivideID, RoomStateList: RoomStateList, UserID: UserID, ReadyStartTime: ReadyStartTime, ReadyEndTime: ReadyEndTime, IsContractWarning: IsContractWarning, RelationBelongTeam: RelationBelongTeam);
            List<Dictionary<string, object>> finallist = new List<Dictionary<string, object>>();
            int currentindex = 0;
            long next_startRowIndex = 0;
            if (IsCuiShou)
            {
                list = list.Where(p => p.CuiShouTotalCost > 0).ToArray();
                if (EndTime > DateTime.MinValue)
                {
                    list = list.Where(p => p.CalculateCuiShouStartTime <= EndTime).ToArray();
                }
                foreach (var item in list)
                {
                    currentindex++;
                    if (currentindex < currentcount && !canexport)
                    {
                        continue;
                    }
                    if (next_startRowIndex >= pageSize && !canexport)
                    {
                        currentcount = currentindex;
                        break;
                    }
                    next_startRowIndex++;
                    var dic = item.ToJsonObject(ignoreDBColumn: false);
                    finallist.Add(dic);
                }
            }
            else
            {
                list = list.Where(p => p.TotalCost > 0).ToArray();
                if (EndTime > DateTime.MinValue)
                {
                    list = list.Where(p => p.CalculateStartTime <= EndTime).ToArray();
                }
                foreach (var item in list)
                {
                    currentindex++;
                    if (currentindex < currentcount && !canexport)
                    {
                        continue;
                    }
                    if (next_startRowIndex >= pageSize && !canexport)
                    {
                        currentcount = currentindex;
                        break;
                    }
                    next_startRowIndex++;
                    var dic = item.ToJsonObject(ignoreDBColumn: false);
                    finallist.Add(dic);
                }
            }
            Foresight.DataAccess.Ui.DataGrid dg = new Foresight.DataAccess.Ui.DataGrid();
            dg.rows = finallist;
            dg.page = pageSize;
            dg.total = list.Length;
            if (ShowFooter)
            {
                var footerlist = new List<Dictionary<string, object>>();
                object item = null;
                decimal CalculateUseCount = list.Sum(p => p.CalculateUseCount);
                decimal CuiShouTotalCost = list.Sum(p => p.CuiShouTotalCost);
                decimal TotalCost = list.Sum(p => p.TotalCost);
                decimal TotalFinalCost = list.Sum(p => p.TotalFinalCost);
                decimal TotalFinalPayCost = list.Sum(p => { return (p.TotalFinalPayCost > 0 ? p.TotalFinalPayCost : 0); });
                decimal ALLFinalTotalCost = list.Sum(p => p.ALLFinalTotalCost);
                var dic = new Dictionary<string, object>();
                dic["RoomName"] = "总合计";
                dic["CalculateUseCount"] = CalculateUseCount;
                dic["CuiShouTotalCost"] = CuiShouTotalCost;
                dic["FormatCuiShouTotalCost"] = Utility.Tools.FormatMoney(CuiShouTotalCost);
                dic["TotalCost"] = TotalCost;
                dic["FormatTotalCost"] = Utility.Tools.FormatMoney(TotalCost);
                dic["TotalFinalCost"] = TotalFinalCost;
                dic["FormatTotalFinalCost"] = Utility.Tools.FormatMoney(TotalFinalCost);
                dic["TotalFinalPayCost"] = TotalFinalPayCost;
                dic["FormatTotalFinalPayCost"] = Utility.Tools.FormatMoney(TotalFinalPayCost);
                dic["ALLFinalTotalCost"] = ALLFinalTotalCost;
                dic["FormatALLFinalTotalCost"] = Utility.Tools.FormatMoney(ALLFinalTotalCost);
                footerlist.Add(dic);
                dg.footer = footerlist;
            }
            return dg;
        }
        public static ViewRoomFee[] GetViewRoomFeeListByRelationIDs(List<int> IDlist, DateTime? StartTime = null, DateTime? EndTime = null, int UserID = 0, bool IsAnalysisQuery = false)
        {
            ReSetParams();
            DateTime _StartTime = DateTime.MinValue;
            DateTime _EndTime = DateTime.MinValue;
            if (StartTime.HasValue && StartTime > DateTime.MinValue)
            {
                _StartTime = Convert.ToDateTime(StartTime);
            }
            if (EndTime.HasValue && EndTime > DateTime.MinValue)
            {
                _EndTime = Convert.ToDateTime(EndTime);
            }
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[IsStart]=1");
            conditions.Add("(Contract_RoomChargeID is null or Contract_RoomChargeID=0 or Contract_RoomChargeID in (select ID from [Contract_RoomCharge]))");
            if (_StartTime > DateTime.MinValue)
            {
                conditions.Add("((Convert(nvarchar(10),[WriteDate],120)>=@StartTime and [ImportFeeID]>0) or (Convert(nvarchar(10),[RoomFeeWriteDate],120)>=@StartTime and [ChargeMeterProjectFeeID]>0) or (isnull([ImportFeeID],0)=0 and isnull([ChargeMeterProjectFeeID],0)=0))");
                parameters.Add(new SqlParameter("@StartTime", _StartTime));
            }
            if (_EndTime > DateTime.MinValue)
            {
                conditions.Add("((Convert(nvarchar(10),[WriteDate],120)<=@EndTime and [ImportFeeID]>0) or (Convert(nvarchar(10),[RoomFeeWriteDate],120)<=@EndTime and [ChargeMeterProjectFeeID]>0) or (isnull([ImportFeeID],0)=0 and isnull([ChargeMeterProjectFeeID],0)=0))");
                parameters.Add(new SqlParameter("@EndTime", _EndTime));
            }
            if (IDlist.Count > 200)
            {
                ViewRoomFeeHistory.CreateTempTable(IDlist, UserID: UserID);
                conditions.Add("EXISTS (SELECT 1 FROM [TempIDs] WHERE id=[ViewRoomFee].ID and [UserID]=" + UserID + ")");
            }
            else if (IDlist.Count > 0)
            {
                conditions.Add("[ID] in (" + string.Join(",", IDlist.ToArray()) + ")");
            }
            string cmd_select = GetInPutTimeCmdString(_StartTime, _EndTime, IsAnalysisQuery);
            string Statement = " select * " + cmd_select + " from [ViewRoomFee] where  " + string.Join(" and ", conditions.ToArray()) + " order by [DefaultOrder] asc";
            ViewRoomFee[] list = GetList<ViewRoomFee>(Statement, parameters).ToArray();
            GetViewRoomFeeFinalDataList(list, _StartTime, _EndTime, _StartTime, _EndTime);
            return list;
        }
        public static ViewRoomFee[] GetViewRoomFeeListByIDs(List<int> IDlist, DateTime? StartTime = null, DateTime? EndTime = null, int UserID = 0, bool IsAnalysisQuery = false)
        {
            ReSetParams();
            DateTime _StartTime = DateTime.MinValue;
            DateTime _EndTime = DateTime.MinValue;
            if (StartTime.HasValue && StartTime > DateTime.MinValue)
            {
                _StartTime = Convert.ToDateTime(StartTime);
            }
            if (EndTime.HasValue && EndTime > DateTime.MinValue)
            {
                _EndTime = Convert.ToDateTime(EndTime);
            }
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[IsStart]=1");
            conditions.Add("(Contract_RoomChargeID is null or Contract_RoomChargeID=0 or Contract_RoomChargeID in (select ID from [Contract_RoomCharge]))");
            if (_StartTime > DateTime.MinValue)
            {
                conditions.Add("((Convert(nvarchar(10),[WriteDate],120)>=@StartTime and [ImportFeeID]>0) or (Convert(nvarchar(10),[RoomFeeWriteDate],120)>=@StartTime and [ChargeMeterProjectFeeID]>0) or (isnull([ImportFeeID],0)=0 and isnull([ChargeMeterProjectFeeID],0)=0))");
                parameters.Add(new SqlParameter("@StartTime", _StartTime));
            }
            if (_EndTime > DateTime.MinValue)
            {
                conditions.Add("((Convert(nvarchar(10),[WriteDate],120)<=@EndTime and [ImportFeeID]>0) or (Convert(nvarchar(10),[RoomFeeWriteDate],120)<=@EndTime and [ChargeMeterProjectFeeID]>0) or (isnull([ImportFeeID],0)=0 and isnull([ChargeMeterProjectFeeID],0)=0))");
                parameters.Add(new SqlParameter("@EndTime", _EndTime));
            }
            if (IDlist.Count > 200)
            {
                ViewRoomFeeHistory.CreateTempTable(IDlist, UserID: UserID);
                conditions.Add("EXISTS (SELECT 1 FROM [TempIDs] WHERE id=[ViewRoomFee].ID and [UserID]=" + UserID + ")");
            }
            else if (IDlist.Count > 0)
            {
                conditions.Add("[ID] in (" + string.Join(",", IDlist.ToArray()) + ")");
            }
            string cmd_select = GetInPutTimeCmdString(_StartTime, _EndTime, IsAnalysisQuery);
            string Statement = " select * " + cmd_select + " from [ViewRoomFee] where  " + string.Join(" and ", conditions.ToArray()) + " order by  isnull(RelatedFeeID,0) asc,[DefaultOrder] asc";
            ViewRoomFee[] list = GetList<ViewRoomFee>(Statement, parameters).ToArray();
            GetViewRoomFeeFinalDataList(list, _StartTime, _EndTime, _StartTime, _EndTime);
            return list;
        }
        public static ViewRoomFee[] GetViewRoomFeeListByOpenID(string OpenID, int RoomID, bool CheckNotifyTime = true)
        {
            bool hasRoom = false;
            var ProjectIDList = Foresight.DataAccess.Wechat_User.GetMyWechatProjectIDList(OpenID, out hasRoom);
            if (!hasRoom)
            {
                return new ViewRoomFee[] { };
            }
            ReSetParams();
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[IsStart]=1");
            conditions.Add("(Contract_RoomChargeID is null or Contract_RoomChargeID=0 or Contract_RoomChargeID in (select ID from [Contract_RoomCharge]))");
            //conditions.Add("(Contract_RoomChargeID is null or Contract_RoomChargeID=0 or Contract_RoomChargeID in (select ID from [Contract_RoomCharge]))");
            var RoomIDList = new List<int>();
            if (RoomID > 0)
            {
                RoomIDList.Add(RoomID);
            }
            if (RoomIDList.Count > 0)
            {
                List<string> cmdlist = ViewRoomFeeHistory.GetRoomIDListConditions(RoomIDList, IsContractFee: true);
                conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
            }
            else if (ProjectIDList.Count > 0)
            {
                List<string> cmdlist = ViewRoomFeeHistory.GetProjectIDListConditions(ProjectIDList, IsContractFee: true, UserID: 9999);
                conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
            }
            string Statement = " select * from [ViewRoomFee] where  " + string.Join(" and ", conditions.ToArray());
            ViewRoomFee[] list = new ViewRoomFee[] { };
            list = GetList<ViewRoomFee>(Statement, parameters).ToArray();
            if (CheckNotifyTime)
            {
                list = SysConfig_Project.GetNotifyViewRoomFee(list);
            }
            GetViewRoomFeeOwnerName(list);
            return list;
        }
        public static void GetViewRoomFeeOwnerName(ViewRoomFee[] list)
        {
            GetViewRoomFeeFinalDataList(list, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, historyListRequire: false, relatedRequire: true);
        }
        public static void GetViewRoomFeeFinalDataList(ViewRoomFee[] list, DateTime StartChargeTime, DateTime EndChargeTime, DateTime StartTime, DateTime EndTime, bool historyListRequire = true, bool relatedRequire = true)
        {
            if (list.Length == 0)
            {
                return;
            }
            var MinID = list.Min(p => p.RoomID);
            var MaxID = list.Max(p => p.RoomID);
            ViewRoomFeeHistoryDetail[] roomFeeHistoryDetailList = new ViewRoomFeeHistoryDetail[] { };
            RoomPhoneRelation[] phoneRelationList = new RoomPhoneRelation[] { };
            if (historyListRequire)
            {
                roomFeeHistoryDetailList = ViewRoomFeeHistoryDetail.GetViewRoomFeeHistoryDetailListByMinMaxID(MinID, MaxID, StartChargeTime, EndChargeTime, StartTime, EndTime);
            }
            if (relatedRequire)
            {
                phoneRelationList = RoomPhoneRelation.GetRoomPhoneRelationListByMinMaxRoomID(MinID, MaxID);
            }
            if (phoneRelationList.Length == 0 && roomFeeHistoryDetailList.Length == 0)
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
                    var myRelationList = phoneRelationList.Where(p => p.RoomID == item.RoomID);
                    RoomPhoneRelation phoneRelation = null;
                    if (item.DefaultChargeManID > 0)
                    {
                        phoneRelation = myRelationList.FirstOrDefault(p => p.ID == item.DefaultChargeManID);
                    }
                    if (phoneRelation == null)
                    {
                        phoneRelation = myRelationList.FirstOrDefault(p => p.IsChargeFee);
                    }
                    if (phoneRelation == null)
                    {
                        phoneRelation = myRelationList.FirstOrDefault(p => p.IsDefault);
                    }
                    if (phoneRelation != null)
                    {
                        item.DefaultChargeManID = phoneRelation.ID;
                        item.DefaultChargeManName = phoneRelation.RelationName;
                        item.RelatePhoneNumber = phoneRelation.RelatePhoneNumber;
                        item.ChargeForMan = phoneRelation.ChargeForMan;
                        item.RelationName = phoneRelation.RelationName;
                        item.BankAccountNo = phoneRelation.OneCardNumber;
                        item.HomeAddress = phoneRelation.HomeAddress;
                        item.BelongTeam = phoneRelation.BelongTeam;
                    }
                }
            }
        }
        #endregion
    }
}
