using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Linq;

using Foresight.DataAccess.Framework;
using System.Configuration;
using System.Reflection;

namespace Foresight.DataAccess
{
    /// <summary>
    /// This object represents the properties and methods of a ViewRoomFeeHistory.
    /// </summary>
    public partial class ViewRoomFeeHistory : EntityBaseReadOnly
    {
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
                    this.StartPoint = this.RoomFeeStartPoint;
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
                    this.EndPoint = this.RoomFeeEndPoint;
                    return this.RoomFeeEndPoint;
                }
                return 0;
            }
        }
        public string FinalRelationName
        {
            get
            {
                return this.RoomOwnerName;
                //if (this.ChargeState == 5)
                //{
                //    return !string.IsNullOrEmpty(this.RoomOwnerName) ? this.RoomOwnerName : this.RelationName;
                //}
                //return this.RelationName;
            }
        }
        public string FormatUnitPrice
        {
            get
            {
                return Utility.Tools.FormatMoney(this.UnitPrice, 4);
            }
        }
        public string FormatRealCost
        {
            get
            {

                return Utility.Tools.FormatMoney(this.RealCost);
            }
        }
        public string FormatSumRealCost
        {
            get
            {
                return Utility.Tools.FormatMoney(this.SumRealCost);
            }
        }
        private string _FinalFullName;
        public string FinalFullName
        {
            get
            {
                return string.IsNullOrEmpty(_FinalFullName) ? this.FullName : _FinalFullName;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _FinalFullName = value;
                }
                else
                {
                    _FinalFullName = this.FullName;
                }
            }
        }
        private string _FinalRoomName;
        public string FinalRoomName
        {
            get
            {
                return string.IsNullOrEmpty(_FinalRoomName) ? this.RoomName : _FinalRoomName;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _FinalRoomName = value;
                }
                else
                {
                    _FinalRoomName = this.RoomName;
                }
            }
        }
        private string _FinalChargeName;
        public string FinalChargeName
        {
            get
            {
                return string.IsNullOrEmpty(_FinalChargeName) ? (string.IsNullOrEmpty(this.ChargeName) ? "所有费项之和" : this.ChargeName) : _FinalChargeName;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _FinalChargeName = value;
                }
                else
                {
                    _FinalChargeName = string.IsNullOrEmpty(this.ChargeName) ? "所有费项之和" : this.ChargeName;
                }
            }
        }
        private int _FinalChargeID;
        public int FinalChargeID
        {
            get
            {
                return _FinalChargeID > 0 ? _FinalChargeID : (this.ChargeID > 0 ? this.ChargeID : 0);
            }
            set
            {
                if (value > 0)
                {
                    _FinalChargeID = value;
                }
                else
                {
                    _FinalChargeID = this.ChargeID > 0 ? this.ChargeID : 0;
                }
            }
        }
        public decimal CalculateMonthCount
        {
            get
            {
                try
                {
                    int monthnumber = Utility.Tools.calculatemonth(this.StartTime, this.EndTime);
                    decimal totaldays = Utility.Tools.calculateTotaldays(this.StartTime, this.EndTime, monthnumber, true);
                    int restdays = Utility.Tools.calculateTotaldays(this.StartTime, this.EndTime, monthnumber, false);
                    decimal month_count = (monthnumber + (restdays / totaldays));
                    return Math.Round(month_count, 0, MidpointRounding.AwayFromZero);
                }
                catch (Exception ex)
                {
                    return 0;
                }
            }
        }
        public decimal FinalTotaCost { get; set; }
        private decimal _FinalRealCost;
        public decimal FinalRealCost
        {
            get
            {
                return _FinalRealCost > 0 ? _FinalRealCost : (this.RealCost > 0 ? this.RealCost : 0);
            }
            set
            {
                if (value > 0)
                {
                    _FinalRealCost = value;
                }
                else
                {
                    _FinalRealCost = this.RealCost > 0 ? this.RealCost : 0;
                }
            }
        }
        public decimal FinalRestCost { get; set; }
        public string FinalCostPercent { get; set; }
        public string FinalPrintNumber
        {
            get
            {
                if (!string.IsNullOrEmpty(this.ChequeNumber))
                {
                    return this.ChequeNumber;
                }
                return this.PrintNumber;
            }
        }
        private string _id;
        public string id
        {
            get
            {
                return !string.IsNullOrEmpty(_id) ? _id : this.RoomID.ToString();
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _id = value;
                }
                else
                {
                    _id = this.RoomID.ToString();
                }
            }
        }
        private string _state;
        public string state
        {
            get
            {
                return !string.IsNullOrEmpty(_state) ? _state : "closed";
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _state = value;
                }
                else
                {
                    _state = "closed";
                }
            }
        }
        [DatabaseColumn("RoomType")]
        public string RoomType { get; set; }
        [DatabaseColumn("GradeLevel")]
        public int GradeLevel { get; set; }

        [DatabaseColumn("SumRealCost")]
        public decimal SumRealCost { get; set; }
        [DatabaseColumn("WeiShuBalance")]
        public decimal WeiShuBalance { get; set; }
        public string ChargeStateDesc
        {
            get
            {
                string typedesc = string.Empty;
                switch (this.ChargeState)
                {
                    case 1:
                        typedesc = "已收费";
                        break;
                    case 2:
                        if (this.ChargeFeeSummaryName.Equals("退预收款") || this.ChargeFeeSummaryName.Equals("退预收费用"))
                        {
                            typedesc = "已作废(退预收款)";
                        }
                        else if (this.ReturnGuaranteeFee)
                        {
                            typedesc = "已作废(退押金)";
                        }
                        else
                        {
                            typedesc = "已作废";
                        }
                        break;
                    case 3:
                        typedesc = "退保证金";
                        break;
                    case 4:
                        typedesc = "冲抵收费";
                        break;
                    case 5:
                        typedesc = "催收中";
                        break;
                    case 6:
                        typedesc = "退预收款";
                        break;
                    case 7:
                        typedesc = "已付款";
                        break;
                    default:
                        break;
                }
                if (this.ApproveStatus == 1 && this.ChargeState != 2 && this.ChargeState != 5)
                {
                    typedesc = "已交款";
                }
                return typedesc;
            }
        }
        public string FinalRemark
        {
            get
            {
                if (string.IsNullOrEmpty(this.Remark))
                {
                    return string.Empty;
                }
                this.Remark = this.Remark.Replace("微信公众号微信支付", "").Replace("APP微信支付", "").Replace("微信公众号支付宝支付", "").Replace("APP支付宝支付", "");
                return this.Remark;
            }
        }
        public static Ui.DataGrid GetViewRoomFeeHistoryGridByRoomID(List<int> RoomIDList, List<int> ProjectIDList, DateTime StartChargeTime, DateTime EndChargeTime, int RoomID, List<int> ChargeIDList, string orderBy, long startRowIndex, int pageSize, int UserID = 0, bool IsAnalysisQuery = false)
        {
            long totalRows = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[ChargeState] in (1,4)");
            string cmdwhere = string.Empty;
            if (StartChargeTime > DateTime.MinValue)
            {
                conditions.Add("Convert(nvarchar(10),[ChargeTime],120)>=@StartChargeTime");
                parameters.Add(new SqlParameter("@StartChargeTime", StartChargeTime));
            }
            if (EndChargeTime > DateTime.MinValue)
            {
                conditions.Add("Convert(nvarchar(10),[ChargeTime],120)<=@EndChargeTime");
                parameters.Add(new SqlParameter("@EndChargeTime", EndChargeTime));
            }
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
            if (ChargeIDList.Count > 0)
            {
                conditions.Add("[ChargeID] in (" + string.Join(",", ChargeIDList.ToArray()) + ")");
            }
            string fieldList = "";
            string Statement = "";
            if (RoomID == 1)
            {
                parameters.Add(new SqlParameter("@RoomID", RoomID));
                cmdwhere += " and [ParentID]=@RoomID";
                fieldList = "B.*";
                Statement = @" from (select A.ID as RoomID,A.Name as RoomName,A.FullName,A.IconID as GradeLevel,(select sum(isnull(RealCost,0)) from [ViewRoomFeeHistory] 
where RoomID in (select [ID]
from [Project] where [AllParentID] like '%,'+ CONVERT(nvarchar(200), A.ID)+',%'
) and " + string.Join(" and ", conditions.ToArray()) + @") as RealCost,
(case when A.isParent=1 then 'Project' else 'Room' end) as RoomType,A.DefaultOrder
from (select * from Project where 1=1 " + cmdwhere + ")A)B where isnull([RealCost],0)>0";
            }
            else
            {
                fieldList = "B.*";
                Statement = @" from (select Project.ID as RoomID,Project.Name as RoomName,Project.FullName,Project.IconID as GradeLevel,Project.DefaultOrder,A.RealCost from (select [RoomID],sum(isnull(RealCost,0)) as [RealCost] from [RoomFeeHistory] where " + string.Join(" and ", conditions.ToArray()) + " group by [RoomID])A left join Project on Project.ID=A.RoomID)B where [RealCost]>0";
            }
            ViewRoomFeeHistory[] list = new ViewRoomFeeHistory[] { };
            list = GetList<ViewRoomFeeHistory>(fieldList, Statement, parameters, orderBy, startRowIndex, pageSize, out totalRows).ToArray();
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
        public static ViewRoomFeeHistory[] GetViewRoomFeeHistoryListByRoomID(List<int> RoomIDList, List<int> ProjectIDList, DateTime StartChargeTime, DateTime EndChargeTime, int RoomID, int UserID = 0)
        {
            return GetViewRoomFeeHistoryListByRoomID(RoomIDList, ProjectIDList, StartChargeTime, EndChargeTime, RoomID, new List<int>(), UserID: UserID);
        }
        public static ViewRoomFeeHistory[] GetViewRoomFeeHistoryListByRoomID(List<int> RoomIDList, List<int> ProjectIDList, DateTime StartChargeTime, DateTime EndChargeTime, int RoomID, List<int> ChargeIDList, int UserID = 0)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[ChargeState] in (1,4)");
            string cmdwhere = string.Empty;
            if (StartChargeTime > DateTime.MinValue)
            {
                conditions.Add("Convert(nvarchar(10),[ChargeTime],120)>=@StartChargeTime");
                parameters.Add(new SqlParameter("@StartChargeTime", StartChargeTime));
            }
            if (EndChargeTime > DateTime.MinValue)
            {
                conditions.Add("Convert(nvarchar(10),[ChargeTime],120)<=@EndChargeTime");
                parameters.Add(new SqlParameter("@EndChargeTime", EndChargeTime));
            }
            if (RoomIDList.Count > 0)
            {
                List<string> cmdlist = ViewRoomFeeHistory.GetRoomIDListConditions(RoomIDList, IncludeRelation: true);
                conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
            }
            if (ProjectIDList.Count > 0)
            {
                List<string> cmdlist = ViewRoomFeeHistory.GetProjectIDListConditions(ProjectIDList, IncludeRelation: true, UserID: UserID);
                conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
            }
            if (ChargeIDList.Count > 0)
            {
                conditions.Add("[ChargeID] in (" + string.Join(",", ChargeIDList.ToArray()) + ")");
            }
            string Statement = "";
            if (RoomID == 1)
            {
                parameters.Add(new SqlParameter("@RoomID", RoomID));
                cmdwhere += " and [ParentID]=@RoomID";
                Statement = @"select B.* from (select A.ID as RoomID,A.Name as RoomName,A.FullName,A.IconID as GradeLevel,(select sum(isnull(RealCost,0)) from [ViewRoomFeeHistory] 
where RoomID in (select [ID]
from [Project] where [AllParentID] like '%,'+ CONVERT(nvarchar(200), A.ID)+',%'
) and " + string.Join(" and ", conditions.ToArray()) + @") as RealCost,
(case when A.isParent=1 then 'Project' else 'Room' end) as RoomType,A.DefaultOrder
from (select * from Project where 1=1 " + cmdwhere + ")A)B where isnull([RealCost],0)>0";
            }
            else
            {
                Statement = @"select B.* from (select Project.ID as RoomID,Project.Name as RoomName,Project.FullName,Project.IconID as GradeLevel,Project.DefaultOrder,A.RealCost from (select [RoomID],sum(isnull(RealCost,0)) as [RealCost] from [RoomFeeHistory] where " + string.Join(" and ", conditions.ToArray()) + " group by [RoomID])A left join Project on Project.ID=A.RoomID)B where isnull([RealCost],0)>0";
            }
            ViewRoomFeeHistory[] list = GetList<ViewRoomFeeHistory>(Statement, parameters).ToArray();
            return list;
        }
        public static Ui.DataGrid GetViewRoomFeeHistoryGridGroupByChargeSummary(List<int> RoomIDList, List<int> ProjectIDList, DateTime StartChargeTime, DateTime EndChargeTime, int RoomID, List<int> ChargeIDList, string orderBy, long startRowIndex, int pageSize, int UserID = 0)
        {
            long totalRows = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            conditions.Add("[ChargeState] in (1,4)");
            if (ChargeIDList.Count > 0)
            {
                conditions.Add("[ChargeID] in (" + string.Join(",", ChargeIDList.ToArray()) + ")");
            }
            if (RoomIDList.Count > 0)
            {
                List<string> cmdlist = ViewRoomFeeHistory.GetRoomIDListConditions(RoomIDList, IncludeRelation: true);
                conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
            }
            if (ProjectIDList.Count > 0)
            {
                List<string> cmdlist = ViewRoomFeeHistory.GetProjectIDListConditions(ProjectIDList, IncludeRelation: true, UserID: UserID);
                conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
            }
            if (StartChargeTime > DateTime.MinValue)
            {
                conditions.Add("Convert(nvarchar(10),[ChargeTime],120)>=@StartChargeTime");
                parameters.Add(new SqlParameter("@StartChargeTime", StartChargeTime));
            }
            if (EndChargeTime > DateTime.MinValue)
            {
                conditions.Add("Convert(nvarchar(10),[ChargeTime],120)<=@EndChargeTime");
                parameters.Add(new SqlParameter("@EndChargeTime", EndChargeTime));
            }
            string fieldList = "A.*, 'ChargeSummary' as [RoomType]";
            string Statement = " from (select ChargeID, ChargeName,sum(RealCost) as RealCost from ViewRoomFeeHistory where " + string.Join(" and ", conditions.ToArray()) + " group by ChargeID,ChargeName)A";
            if (RoomID > 0)
            {
                conditions.Add("RoomID in (select ID from [Project] where (ID=@RoomID or AllParentID like '%," + RoomID + ",%'))");
                parameters.Add(new SqlParameter("@RoomID", RoomID));
                Statement = " from (select ChargeID, ChargeName,sum(RealCost) as RealCost, " + RoomID + " as RoomID,(select Name from Project where ID=@RoomID) as RoomName, (select FullName from Project where ID=@RoomID) as FullName from ViewRoomFeeHistory where " + string.Join(" and ", conditions.ToArray()) + " group by ChargeID,ChargeName)A";
            }

            ViewRoomFeeHistory[] list = new ViewRoomFeeHistory[] { };
            list = GetList<ViewRoomFeeHistory>(fieldList, Statement, parameters, orderBy, startRowIndex, pageSize, out totalRows).ToArray();
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
        public static Ui.DataGrid GetViewRoomFeeHistoryGridByRoomID(List<int> RoomIDList, List<int> ProjectIDList, int FeeID, DateTime StartChargeTime, DateTime EndChargeTime, bool IncludIsCharged, bool IncludePreCharge, bool IncludeDepoistCharge, int DepoistStatus, int PreChargeStatus, int CompanyID, int[] ChargeManID, int[] ChargeSummaryID, int[] ChargeTypeID, int[] CategoryID, List<int> ChargeStatusIDList, int RoomFeeOrderID, bool IsRoomFeeSearch, bool IsCuiShou, int ContractID, string orderBy, long startRowIndex, int pageSize, List<int> IDList, bool ExcludeCuiShou = false, bool IncludeFooter = false, int DivideID = 0, int UserID = 0, bool canexport = false, bool IncludeTime = false, string RelationBelongTeam = "", int PayOnLineStatus = 0)
        {
            long totalRows = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            #region 搜索条件
            conditions.Add("1=1");
            if (PayOnLineStatus == 1)//1-线下付款
            {
                conditions.Add("([TradeNo]='' or TradeNo is null or not exists(select 1 from Payment where [TradeNo]=ViewRoomFeeHistory.TradeNo and [Status]=2))");
            }
            if (PayOnLineStatus == 2)//2-在线付款
            {
                conditions.Add("([TradeNo]!='' and TradeNo is not null and exists(select 1 from Payment where [TradeNo]=ViewRoomFeeHistory.TradeNo and [Status]=2))");
            }
            if (DivideID > 0)
            {
                conditions.Add("isnull([ContractDivideID],0)=@DivideID");
                parameters.Add(new SqlParameter("@DivideID", DivideID));
            }
            if (IDList.Count > 2)
            {
                ViewRoomFeeHistory.CreateTempTable(IDList, UserID: UserID);
                conditions.Add("EXISTS (SELECT 1 FROM [TempIDs] WHERE id=[ViewRoomFeeHistory].HistoryID and [UserID]=" + UserID + ")");
            }
            else if (IDList.Count > 0)
            {
                conditions.Add("[HistoryID] in (" + string.Join(",", IDList.ToArray()) + ")");
            }
            if (ExcludeCuiShou)
            {
                conditions.Add("[ChargeState] in (1,2,3,4,6,7)");
            }
            if (ChargeStatusIDList.Contains(3))
            {
                ChargeStatusIDList.Add(6);
                ChargeStatusIDList.Add(7);
            }
            if (ContractID > 0)
            {
                conditions.Add("[ContractID]=@ContractID");
                parameters.Add(new SqlParameter("@ContractID", ContractID));
            }
            if (IsCuiShou)
            {
                conditions.Add("isnull([IsCuiShou],0)=1");
            }
            if (RoomFeeOrderID > 0)
            {
                conditions.Add("[PrintID] in (select [ID] from [PrintRoomFeeHistory] where [RoomFeeOrderID]=@RoomFeeOrderID)");
                parameters.Add(new SqlParameter("@RoomFeeOrderID", RoomFeeOrderID));
            }
            else if (IsRoomFeeSearch)
            {
                conditions.Add("[PrintID] in (select [ID] from [PrintRoomFeeHistory] where isnull([RoomFeeOrderID],0)=0)");
                conditions.Add("([ChargeID] in (select [ID] from [ChargeSummary] where isnull([IsOrderFeeOn],0)=1) or isnull(ChargeID,0)=0)");
            }
            if (StartChargeTime > DateTime.MinValue)
            {
                if (IncludeTime)
                {
                    conditions.Add("[ChargeTime]>=@StartChargeTime");
                }
                else
                {
                    conditions.Add("Convert(nvarchar(10),[ChargeTime],120)>=@StartChargeTime");
                }
                parameters.Add(new SqlParameter("@StartChargeTime", StartChargeTime));
            }
            if (EndChargeTime > DateTime.MinValue)
            {
                if (IncludeTime)
                {
                    conditions.Add("[ChargeTime]<=@EndChargeTime");
                }
                else
                {
                    conditions.Add("Convert(nvarchar(10),[ChargeTime],120)<=@EndChargeTime");
                }
                parameters.Add(new SqlParameter("@EndChargeTime", EndChargeTime));
            }
            if (ChargeManID.Length > 0)
            {
                conditions.Add("[ChargeMan] in (select [RealName] from [User] where [UserID] in (" + string.Join(",", ChargeManID) + "))");
            }
            if (ChargeSummaryID.Length > 0)
            {
                conditions.Add("[ChargeID] in (" + string.Join(",", ChargeSummaryID) + ")");
            }
            string cmdconditions = string.Empty;

            if (ChargeTypeID.Length > 0)
            {
                var cmdlist = new List<string>();
                cmdlist.Add("(isnull([ChageType1],-1) in (" + string.Join(",", ChargeTypeID) + ") and isnull([RealMoneyCost1],0)>0 and [RealCost]>0)");
                cmdlist.Add("(isnull([ChageType1],-1) in (" + string.Join(",", ChargeTypeID) + ") and isnull([RealMoneyCost1],0)>=0 and [RealCost]=0)");
                cmdlist.Add("(isnull([ChageType2],-1) in (" + string.Join(",", ChargeTypeID) + ") and isnull([RealMoneyCost2],0)>0 and [RealCost]>0)");
                cmdlist.Add("(isnull([ChageType2],-1) in (" + string.Join(",", ChargeTypeID) + ") and isnull([RealMoneyCost2],0)>=0 and [RealCost]=0)");

                conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
                cmdconditions = "(case when (isnull([ChageType1],-1) in (" + string.Join(",", ChargeTypeID) + ") and isnull([RealMoneyCost1],0)>0) then RealMoneyCost1 else 0 end) + (case when (isnull([ChageType2],-1) in (" + string.Join(",", ChargeTypeID) + ") and isnull([RealMoneyCost2],0)>0) then RealMoneyCost2 else 0 end) as SumRealCost,";
            }
            else
            {
                cmdconditions = "[PrintRealCost] as SumRealCost,";
            }
            if (CategoryID.Length > 0)
            {
                conditions.Add("[CategoryID] in (" + string.Join(",", CategoryID) + ")");
            }
            if (ChargeStatusIDList.Count > 0)
            {
                conditions.Add("[ChargeState] in (" + string.Join(",", ChargeStatusIDList) + ")");
            }
            if (IncludeDepoistCharge)
            {
                conditions.Add("[CategoryID]=3");
                if (DepoistStatus == 1)
                {
                    conditions.Add("[ChargeState] in (1,4)");
                }
                else if (DepoistStatus == 2)
                {
                    conditions.Add("[ChargeState] in (3)");
                }
                else
                {
                    conditions.Add("[ChargeState] in (1,4,3)");
                }
            }

            if (IncludePreCharge)
            {
                if (PreChargeStatus != 4)
                {
                    conditions.Add("([CategoryID]=4 or [ChargeState]=4)");
                }
                if (PreChargeStatus == 1)
                {
                    conditions.Add("[ChargeState]=1");
                }
                else if (PreChargeStatus == 2)
                {
                    conditions.Add("[ChargeState]=4");
                }
                else if (PreChargeStatus == 3)
                {
                    conditions.Add("[ChargeState]=6");
                }
                else if (PreChargeStatus == 4)
                {
                    conditions.Add("[ChargeState]=2 and [ChargeFee]>0");
                }
                else
                {
                    conditions.Add("[ChargeState] in (1,4,6)");
                }
            }
            if (CompanyID > 1)
            {
                conditions.Add(" [ChargeID] in (select [ID] from [ChargeSummary] where [CompanyID]=@CompanyID)");
                parameters.Add(new SqlParameter("@CompanyID", CompanyID));
            }
            if (IncludIsCharged)
            {
                conditions.Add("[ChargeState] in (1,4)");
            }
            if (RoomIDList.Count > 0)
            {
                List<string> cmdlist = ViewRoomFeeHistory.GetRoomIDListConditions(RoomIDList, IsContractFee: true);
                conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
            }
            if (ProjectIDList.Count > 0)
            {
                List<string> cmdlist = ViewRoomFeeHistory.GetProjectIDListConditions(ProjectIDList, IsContractFee: true, UserID: UserID);
                conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
            }
            if (FeeID > 0)
            {
                conditions.Add("[ChargeFeeID]=@FeeID");
                parameters.Add(new SqlParameter("@FeeID", FeeID));
            }
            if (!string.IsNullOrEmpty(RelationBelongTeam))
            {
                conditions.Add("[BelongTeam] like @RelationBelongTeam");
                parameters.Add(new SqlParameter("@RelationBelongTeam", "%" + RelationBelongTeam + "%"));
            }
            #endregion
            string fieldList = "A.* ";
            string Statement = " from (select " + cmdconditions + " * from [ViewRoomFeeHistory] where  " + string.Join(" and ", conditions.ToArray()) + ")A";
            ViewRoomFeeHistory[] list = new ViewRoomFeeHistory[] { };
            if (canexport)
            {
                list = GetList<ViewRoomFeeHistory>("select " + fieldList + Statement + " " + orderBy, parameters).ToArray();
            }
            else
            {
                list = GetList<ViewRoomFeeHistory>(fieldList, Statement, parameters, orderBy, startRowIndex, pageSize, out totalRows).ToArray();
            }
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            if (IncludeFooter && list.Length > 0)
            {
                if (ChargeTypeID.Length == 0)
                {
                    cmdconditions = "[RealCost] as SumRealCost,";
                }
                string footertext = " select '总合计' as PrintNumber, 0 as UnitPrice, Sum(case when ChargeState in (3,6,7) then 0-(isnull(RealCost,0)) else isnull(RealCost,0) end) as RealCost,sum(UseCount) as UseCount,sum(isnull(TotalPoint,0)) as TotalPoint, (isnull((select Sum(isnull(SumRealCost,0)) from (select " + cmdconditions + " * from [PrintRoomFeeHistory])A where [ID] in (select [PrintID] from  [ViewRoomFeeHistory] where ChargeState not in (3,6,7) and " + string.Join(" and ", conditions.ToArray()) + ")),0)-(isnull((select Sum(isnull(SumRealCost,0)) from (select " + cmdconditions + " * from [PrintRoomFeeHistory])A where [ID] in (select [PrintID] from  [ViewRoomFeeHistory] where ChargeState in (3,6) and " + string.Join(" and ", conditions.ToArray()) + ")),0))) as SumRealCost,sum(isnull(Discount,0)) as Discount from [ViewRoomFeeHistory] where  " + string.Join(" and ", conditions.ToArray());
                dg.footer = GetList<ViewRoomFeeHistory>(footertext, parameters).ToArray();
            }
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
        public static ViewRoomFeeHistory[] GetViewRoomFeeHistoryListByIDs(List<int> IDs)
        {
            return GetViewRoomFeeHistoryListByIDs(0, IDs, 0);
        }
        public static ViewRoomFeeHistory[] GetViewRoomFeeHistoryListByIDs(int PrintID)
        {
            return GetViewRoomFeeHistoryListByIDs(0, new List<int>(), PrintID);
        }
        public static ViewRoomFeeHistory[] GetViewRoomFeeHistoryListByPrintID(int PrintID)
        {
            return GetViewRoomFeeHistoryListByIDs(int.MinValue, new List<int>(), PrintID);
        }
        public static ViewRoomFeeHistory[] GetViewRoomFeeHistoryListByIDs(int RoomID, List<int> IDs, int PrintID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            if (RoomID <= 0 && IDs.Count == 0 && PrintID <= 0)
            {
                return new ViewRoomFeeHistory[] { };
            }
            if (RoomID > 0)
            {
                conditions.Add("[RoomID]=@RoomID");
                parameters.Add(new SqlParameter("@RoomID", RoomID));
            }
            if (IDs.Count > 0)
            {
                conditions.Add("[HistoryID] in (" + string.Join(",", IDs.ToArray()) + ")");
            }
            if (PrintID > 0)
            {
                conditions.Add("[PrintID]=@PrintID");
                parameters.Add(new SqlParameter("@PrintID", PrintID));
            }
            ViewRoomFeeHistory[] list = new ViewRoomFeeHistory[] { };
            list = GetList<ViewRoomFeeHistory>("select *,(select WeiShuBalance from [PrintRoomFeeHistory] where ID=[ViewRoomFeeHistory].PrintID) as WeiShuBalance from [ViewRoomFeeHistory] where  " + string.Join(" and ", conditions.ToArray()) + " order by [PrintNumber] desc", parameters).ToArray();
            return list;
        }
        public static ViewRoomFeeHistory[] GetPreChargeViewRoomFeeHistoryList(int PrintID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            if (PrintID > 0)
            {
                conditions.Add("[PrintID]=@PrintID");
                parameters.Add(new SqlParameter("@PrintID", PrintID));
            }
            else
            {
                conditions.Add("[CategoryID]=4");
                conditions.Add("[ChargeState]=1");
            }
            ViewRoomFeeHistory[] list = GetList<ViewRoomFeeHistory>("select * from [ViewRoomFeeHistory] where  " + string.Join(" and ", conditions.ToArray()) + " order by [ChargeTime] desc", parameters).ToArray();
            return list;
        }

        public static ViewRoomFeeHistory[] GetViewRoomFeeHistoryListForOrder(DateTime StartTime, DateTime EndTime, string ChargeMan, List<int> ChargeStateList, List<int> ProjectIDList, int RoomFeeOrderID, bool IsRoomFeeSearch, List<int> HistoryIDList = null, bool DeleteTempHistoryIDList = true, int UserID = 0)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (HistoryIDList != null && HistoryIDList.Count > 0)
            {
                if (HistoryIDList.Count > 2)
                {
                    ViewRoomFeeHistory.CreateTempTable(HistoryIDList, DeleteTempHistoryIDList, UserID: UserID);
                    conditions.Add("EXISTS (SELECT 1 FROM [TempIDs] WHERE id=[ViewRoomFeeHistory].HistoryID and [UserID]=" + UserID + ")");
                }
                else if (HistoryIDList.Count > 0)
                {
                    conditions.Add("[HistoryID] in (" + string.Join(",", HistoryIDList.ToArray()) + ")");
                }
            }
            if (RoomFeeOrderID > 0)
            {
                conditions.Add("[PrintID] in (select [ID] from [PrintRoomFeeHistory] where [RoomFeeOrderID]=@RoomFeeOrderID)");
                parameters.Add(new SqlParameter("@RoomFeeOrderID", RoomFeeOrderID));
            }
            else if (IsRoomFeeSearch)
            {
                conditions.Add("[PrintID] in (select [ID] from [PrintRoomFeeHistory] where isnull([RoomFeeOrderID],0)=0)");
                conditions.Add("([ChargeID] in (select [ID] from [ChargeSummary] where isnull([IsOrderFeeOn],0)=1) or isnull(ChargeID,0)=0)");
            }
            if (StartTime > DateTime.MinValue)
            {
                conditions.Add("[ChargeTime]>=@StartTime");
                parameters.Add(new SqlParameter("@StartTime", StartTime));
            }
            if (EndTime > DateTime.MinValue)
            {
                conditions.Add("[ChargeTime]<@EndTime");
                parameters.Add(new SqlParameter("@EndTime", EndTime));
            }
            #region 收款人查询
            string cmd = string.Empty;
            if (!string.IsNullOrEmpty(ChargeMan))
            {
                string[] keywords = ChargeMan.Trim().Split(',');
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
                            cmd += "  and  ([ChargeMan] like '%" + keywords[i] + "%')";
                        }
                        else
                        {
                            cmd += "  ([ChargeMan] like '%" + keywords[i] + "%'))";
                        }
                    }
                    else if (i == 0)
                    {
                        cmd += " and (([ChargeMan] like '%" + keywords[i] + "%') or";
                    }
                    else
                    {
                        cmd += "  ([ChargeMan] like '%" + keywords[i] + "%') or ";
                    }
                }
            }
            #endregion
            //if (!string.IsNullOrEmpty(ChargeMan))
            //{
            //    conditions.Add("[ChargeMan]=@ChargeMan");
            //    parameters.Add(new SqlParameter("@ChargeMan", ChargeMan));
            //}
            if (ChargeStateList.Count > 0)
            {
                conditions.Add("[ChargeState] in (" + string.Join(",", ChargeStateList.ToArray()) + ")");
            }
            if (ProjectIDList.Count > 0)
            {
                List<string> cmdlist = ViewRoomFeeHistory.GetProjectIDListConditions(ProjectIDList, IncludeRelation: false, UserID: UserID);
                conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
            }
            var list = GetList<ViewRoomFeeHistory>("select * from [ViewRoomFeeHistory] where " + string.Join(" and ", conditions.ToArray()) + cmd + " order by [PrintNumber]", parameters).ToArray();
            return list;
        }
        public static int GetViewRoomFeeHistoryCount(List<int> RoomIDList, List<int> ProjectIDList, DateTime StartChargeTime, DateTime EndChargeTime, int RoomID, int UserID = 0)
        {
            int totalcount = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[ChargeState] in (1,4)");
            string cmdwhere = string.Empty;
            if (StartChargeTime > DateTime.MinValue)
            {
                conditions.Add("Convert(nvarchar(10),[ChargeTime],120)>=@StartChargeTime");
                parameters.Add(new SqlParameter("@StartChargeTime", StartChargeTime));
            }
            if (EndChargeTime > DateTime.MinValue)
            {
                conditions.Add("Convert(nvarchar(10),[ChargeTime],120)<=@EndChargeTime");
                parameters.Add(new SqlParameter("@EndChargeTime", EndChargeTime));
            }
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
            if (RoomID == 1)
            {
                parameters.Add(new SqlParameter("@RoomID", RoomID));
                cmdwhere += " and [ParentID]=@RoomID";
            }
            else
            {
                cmdwhere += " and isnull([isParent],0)=0";
            }
            string cmdtext = @"select count(1) from (select A.ID as RoomID,A.Name as RoomName,A.FullName,A.IconID as GradeLevel,(select sum(isnull(RealCost,0)) from [ViewRoomFeeHistory] 
where RoomID=A.ID or RoomID in (select [ID]
from [Project] where [AllParentID] like '%,'+ CONVERT(nvarchar(200), A.ID)+',%'
) and " + string.Join(" and ", conditions.ToArray()) + @") as RealCost,
(case when A.isParent=1 then 'Project' else 'Room' end) as RoomType,A.DefaultOrder
from (select * from Project where 1=1 " + cmdwhere + ")A)B";
            using (SqlHelper helper = new SqlHelper())
            {
                var Total = helper.ExecuteScalar(cmdtext, CommandType.Text, new List<SqlParameter>());
                if (Total != null)
                {
                    int.TryParse(Total.ToString(), out totalcount);
                }
            }
            return totalcount;
        }
        public static List<string> GetViewRoomFeeHistoryGridForOrderConditions(DateTime StartTime, DateTime EndTime, string ChargeMan, List<int> ChargeStateList, List<int> ProjectIDList, int RoomFeeOrderID, List<int> ChargeTypeList, int UserID, out List<SqlParameter> parameters, out string cmd, List<int> RoomIDList = null)
        {
            parameters = new List<SqlParameter>();
            cmd = "";
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (ChargeTypeList != null && ChargeTypeList.Count > 0)
            {
                conditions.Add("[PrintID] in (select [ID] from [PrintRoomFeeHistory] where ((ChageType1 in (" + string.Join(",", ChargeTypeList.ToArray()) + ") and isnull([RealMoneyCost1],0)>0) or (ChageType2 in (" + string.Join(",", ChargeTypeList.ToArray()) + ") and isnull([RealMoneyCost2],0)>0)))");
            }
            if (RoomFeeOrderID > 0)
            {
                conditions.Add("[PrintID] in (select [ID] from [PrintRoomFeeHistory] where [RoomFeeOrderID]=@RoomFeeOrderID)");
                parameters.Add(new SqlParameter("@RoomFeeOrderID", RoomFeeOrderID));
            }
            else
            {
                conditions.Add("[PrintID] in (select [ID] from [PrintRoomFeeHistory] where isnull([RoomFeeOrderID],0)=0)");
                conditions.Add("([ChargeID] in (select [ID] from [ChargeSummary] where isnull([IsOrderFeeOn],0)=1) or isnull(ChargeID,0)=0)");
            }
            if (StartTime > DateTime.MinValue)
            {
                conditions.Add("[ChargeTime]>=@StartTime");
                parameters.Add(new SqlParameter("@StartTime", StartTime));
            }
            if (EndTime > DateTime.MinValue)
            {
                conditions.Add("[ChargeTime]<@EndTime");
                parameters.Add(new SqlParameter("@EndTime", EndTime));
            }
            #region 收款人查询
            if (!string.IsNullOrEmpty(ChargeMan))
            {
                string[] keywords = ChargeMan.Trim().Split(',');
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
                            cmd += "  and  ([ChargeMan] like '%" + keywords[i] + "%')";
                        }
                        else
                        {
                            cmd += "  ([ChargeMan] like '%" + keywords[i] + "%'))";
                        }
                    }
                    else if (i == 0)
                    {
                        cmd += " and (([ChargeMan] like '%" + keywords[i] + "%') or";
                    }
                    else
                    {
                        cmd += "  ([ChargeMan] like '%" + keywords[i] + "%') or ";
                    }
                }
            }
            #endregion
            if (ChargeStateList.Count > 0)
            {
                List<string> newconditions = new List<string>();
                if (ChargeStateList.Contains(1))
                {
                    newconditions.Add("[ChargeState] in (1)");
                }
                else if (ChargeStateList.Contains(2))
                {
                    newconditions.Add("[ChargeState] in (3,6,7)");
                }
                else if (ChargeStateList.Contains(3))
                {
                    newconditions.Add("[ChargeState]=2");
                }
                conditions.Add("(" + string.Join(" or ", newconditions.ToArray()) + ")");
            }
            else
            {
                conditions.Add("[ChargeState] in (1,2,3,6,7)");
            }
            if (ProjectIDList != null && ProjectIDList.Count > 0)
            {
                List<string> cmdlist = ViewRoomFeeHistory.GetProjectIDListConditions(ProjectIDList, UserID: UserID);
                conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
            }
            if (RoomIDList != null && RoomIDList.Count > 0)
            {
                List<string> cmdlist = ViewRoomFeeHistory.GetRoomIDListConditions(RoomIDList);
                conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
            }
            return conditions;
        }
        public static Ui.DataGrid GetViewRoomFeeHistoryGridForOrder(DateTime StartTime, DateTime EndTime, string ChargeMan, List<int> ChargeStateList, List<int> ProjectIDList, int RoomFeeOrderID, string orderBy, long startRowIndex, int pageSize, List<int> ChargeTypeList = null, int UserID = 0, List<int> RoomIDList = null)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            string cmd = string.Empty;
            List<string> conditions = GetViewRoomFeeHistoryGridForOrderConditions(StartTime, EndTime, ChargeMan, ChargeStateList, ProjectIDList, RoomFeeOrderID, ChargeTypeList, UserID, out parameters, out cmd, RoomIDList: RoomIDList);
            long totalRows = 0;
            string fieldList = "A.*";
            string Statement = " from (select * from [ViewRoomFeeHistory] where " + string.Join(" and ", conditions.ToArray()) + cmd + ")A";
            var list = GetList<ViewRoomFeeHistory>(fieldList, Statement, parameters, orderBy, startRowIndex, pageSize, out totalRows).ToArray();
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
        public static List<int> GetViewRoomFeeHistoryIDListForOrder(DateTime StartTime, DateTime EndTime, string ChargeMan, List<int> ChargeStateList, List<int> ProjectIDList, int RoomFeeOrderID, List<int> ChargeTypeList = null, int UserID = 0, List<int> RoomIDList = null)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            string cmd = string.Empty;
            List<string> conditions = GetViewRoomFeeHistoryGridForOrderConditions(StartTime, EndTime, ChargeMan, ChargeStateList, ProjectIDList, RoomFeeOrderID, ChargeTypeList, UserID, out parameters, out cmd, RoomIDList: RoomIDList);
            string Statement = "select HistoryID from [ViewRoomFeeHistory] where " + string.Join(" and ", conditions.ToArray()) + cmd;
            var list = GetList<ViewRoomFeeHistory>(Statement, parameters).ToArray();
            return list.Select(p => p.HistoryID).ToList();
        }
        public static ViewRoomFeeHistory[] GetViewRoomFeeHistoryListByContractIDList(List<int> ContractIDList)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[ChargeState] in (1,4)");
            if (ContractIDList.Count == 0)
            {
                return new ViewRoomFeeHistory[] { };
            }
            conditions.Add("[ContractID] in (" + string.Join(",", ContractIDList.ToArray()) + ")");
            string Statement = " select * from [ViewRoomFeeHistory] where  " + string.Join(" and ", conditions.ToArray());
            ViewRoomFeeHistory[] list = new ViewRoomFeeHistory[] { };
            list = GetList<ViewRoomFeeHistory>(Statement, parameters).ToArray();
            return list;
        }
        public static ViewRoomFeeHistory[] GetViewRoomFeeHistoryListByPrintIDList(List<int> PrintIDList)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (PrintIDList.Count > 0)
            {
                conditions.Add("[PrintID] in (" + string.Join(",", PrintIDList.ToArray()) + ")");
            }
            string Statement = " select * from [ViewRoomFeeHistory] where  " + string.Join(" and ", conditions.ToArray());
            ViewRoomFeeHistory[] list = new ViewRoomFeeHistory[] { };
            list = GetList<ViewRoomFeeHistory>(Statement, parameters).ToArray();
            return list;
        }
        public static void Inert2DBBySqlBulkCopy(List<int> IDList, int UserID = 0, bool InsertProjectID = false)//插入sql方法
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("UserID", System.Type.GetType("System.Int32"));
            if (InsertProjectID)
            {
                dt.Columns.Add("ProjectID", System.Type.GetType("System.String"));
            }
            else
            {
                dt.Columns.Add("id", System.Type.GetType("System.Int32"));
            }
            foreach (var ID in IDList)
            {
                DataRow dr = dt.NewRow();
                dr["UserID"] = UserID;
                if (InsertProjectID)
                {
                    dr["ProjectID"] = ID.ToString();
                }
                else
                {
                    dr["id"] = ID;
                }
                dt.Rows.Add(dr);
            }
            string connectionString = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlBulkCopy sqlbulkcopy = new SqlBulkCopy(connectionString, SqlBulkCopyOptions.UseInternalTransaction))
                {
                    try
                    {
                        sqlbulkcopy.DestinationTableName = "TempIDs";
                        for (int i = 0; i < dt.Columns.Count; i++)
                        {
                            sqlbulkcopy.ColumnMappings.Add(dt.Columns[i].ColumnName, dt.Columns[i].ColumnName);
                        }
                        sqlbulkcopy.WriteToServer(dt);
                    }
                    catch (System.Exception ex)
                    {
                        Utility.LogHelper.WriteError("ViewRoomFeeHistory.cs", "Inert2DBBySqlBulkCopy", ex);
                        throw ex;
                    }
                }
            }
        }
        private static Object thisLock = new Object();
        public static void CreateTempTable(List<int> IDList, bool DeleteTempHistoryIDList = true, int UserID = 0, bool InsertProjectID = false)
        {
            lock (thisLock)
            {
                string cmdtext = string.Empty;
                if (DeleteTempHistoryIDList)
                {
                    cmdtext += "delete from [TempIDs] where isnull(UserID,0)=" + UserID + " and isnull([id],0)!=0;";
                    using (SqlHelper helper = new SqlHelper())
                    {
                        try
                        {
                            helper.BeginTransaction();
                            helper.Execute(cmdtext, CommandType.Text, new List<SqlParameter>());
                            helper.Commit();
                        }
                        catch (Exception)
                        {
                            helper.Rollback();
                        }
                    }
                    Inert2DBBySqlBulkCopy(IDList, UserID, InsertProjectID);
                    return;
                }
                if (InsertProjectID)
                {
                    cmdtext += "delete from [TempIDs] where isnull(UserID,0)=" + UserID + " and isnull([ProjectID],'0')!='0';";
                    using (SqlHelper helper = new SqlHelper())
                    {
                        try
                        {
                            helper.BeginTransaction();
                            helper.Execute(cmdtext, CommandType.Text, new List<SqlParameter>());
                            helper.Commit();
                        }
                        catch (Exception)
                        {
                            helper.Rollback();
                        }
                    }
                    Inert2DBBySqlBulkCopy(IDList, UserID, InsertProjectID);
                }
            }
        }
        public static List<string> GetRoomIDListConditions(List<int> RoomIDList, bool IncludeRelation = true, bool IsContractFee = false, string RoomIDName = "[RoomID]", string ContractIDName = "[ContractID]")
        {
            List<string> cmdlist = new List<string>();
            cmdlist.Add("(" + RoomIDName + " in (" + string.Join(",", RoomIDList.ToArray()) + "))");
            if (IncludeRelation)
            {
                cmdlist.Add("(" + RoomIDName + " in (select [RoomID] from [RoomRelation] where [GUID] in (select [GUID] from [RoomRelation] where [RoomID] in (" + string.Join(",", RoomIDList.ToArray()) + "))))");
            }
            if (IsContractFee)
            {
                cmdlist.Add("(" + RoomIDName + "=0 and isnull(" + ContractIDName + ",0)>0 and " + ContractIDName + " in (select ContractID from [Contract_Room] where [RoomID] in (" + string.Join(",", RoomIDList.ToArray()) + ")))");
            }
            return cmdlist;
        }
        public static List<string> GetProjectIDListConditions(List<int> ProjectIDList, bool IncludeRelation = true, bool IsContractFee = false, string RoomIDName = "[RoomID]", int UserID = 0, string ContractIDName = "[ContractID]")
        {
            List<string> cmdlist = new List<string>();
            ProjectIDList = ProjectIDList.Where(p => p != 0).ToList();
            if (ProjectIDList.Count == 0)
            {
                cmdlist.Add("1=1");
                return cmdlist;
            }
            List<string> cmdwhere = new List<string>();
            if (ProjectIDList.Count > 100)
            {
                ViewRoomFeeHistory.CreateTempTable(ProjectIDList, UserID: UserID, InsertProjectID: true, DeleteTempHistoryIDList: false);
                cmdwhere.Add("exists (select 1 from [TempIDs] where [UserID]=" + UserID + " and ([Project].[AllParentID] like '%,'+[TempIDs].[ProjectID]+',%' or [Project].ID=[TempIDs].[ProjectID]))");
            }
            else
            {
                foreach (var ProjectID in ProjectIDList)
                {
                    cmdwhere.Add("([AllParentID] like '%," + ProjectID + ",%' or [ID] =" + ProjectID + ")");
                }
            }
            cmdlist.Add("(" + RoomIDName + " in (select ID from [Project] where " + string.Join(" or ", cmdwhere) + "))");
            if (IncludeRelation)
            {
                cmdlist.Add("(" + RoomIDName + " in (select [RoomID] from [RoomRelation] where [GUID] in (select [GUID] from [RoomRelation] where [RoomID] in (select ID from [Project] where " + string.Join(" or ", cmdwhere) + "))))");
            }
            if (IsContractFee)
            {
                cmdlist.Add("(" + RoomIDName + "=0 and isnull(" + ContractIDName + ",0)>0 and " + ContractIDName + " in (select ContractID from [Contract_Room] where [RoomID] in (select ID from [Project] where " + string.Join(" or ", cmdwhere) + ")))");
            }
            return cmdlist;
        }
        public static List<string> GetPublicProjectIDListConditions(List<int> ProjectIDList, string RoomIDName = "[PublicProjectID]", int UserID = 0)
        {
            List<string> cmdlist = new List<string>();
            ProjectIDList = ProjectIDList.Where(p => p != 0).ToList();
            if (ProjectIDList.Count == 0)
            {
                return cmdlist;
            }
            List<string> cmdwhere = new List<string>();
            if (ProjectIDList.Count > 100)
            {
                ViewRoomFeeHistory.CreateTempTable(ProjectIDList, UserID: UserID, InsertProjectID: true, DeleteTempHistoryIDList: false);
                cmdwhere.Add("exists (select 1 from [TempIDs] where [UserID]=" + UserID + " and ([Project].[AllParentID] like '%,'+[TempIDs].[ProjectID]+',%' or [Project].[ID]=[TempIDs].[ProjectID]))");
            }
            else
            {
                foreach (var ProjectID in ProjectIDList)
                {
                    cmdwhere.Add("([AllParentID] like '%," + ProjectID + ",%' or [ID]=" + ProjectID + ")");
                }
            }
            if (RoomIDName.Equals("[ParentProjectID]"))
            {
                cmdlist.Add("([ParentProjectID] in (select [ID] from [Project] where " + string.Join(" or ", cmdwhere) + "))");
            }
            else
            {
                cmdlist.Add("(" + RoomIDName + " in (select ID from [Project_Public] where [ParentProjectID] in (select [ID] from [Project] where " + string.Join(" or ", cmdwhere) + ")))");
            }
            return cmdlist;
        }
        public static List<string> GetPublicParentIDListConditions(List<int> ParentIDList, string RoomIDName = "[PublicProjectID]", int UserID = 0)
        {
            List<string> cmdlist = new List<string>();
            ParentIDList = ParentIDList.Where(p => p != 0).ToList();
            if (ParentIDList.Count == 0)
            {
                return cmdlist;
            }
            List<string> cmdwhere = new List<string>();
            if (ParentIDList.Count > 100)
            {
                ViewRoomFeeHistory.CreateTempTable(ParentIDList, UserID: UserID, InsertProjectID: true, DeleteTempHistoryIDList: false);
                cmdwhere.Add("exists (select 1 from [TempIDs] where [UserID]=" + UserID + " and ([Project_Public].[AllParentID] like '%,'+[TempIDs].[ProjectID]+',%' or [Project_Public].ID=[TempIDs].[ProjectID]))");
            }
            else
            {
                foreach (var ProjectID in ParentIDList)
                {
                    cmdwhere.Add("([AllParentID] like '%," + ProjectID + ",%' or [ID]=" + ProjectID + ")");
                }
            }
            if (RoomIDName.Equals("[ID]"))
            {
                cmdlist.Add("(" + string.Join(" or ", cmdwhere) + ")");
            }
            else
            {
                cmdlist.Add("(" + RoomIDName + " in (select ID from [Project_Public] where " + string.Join(" or ", cmdwhere) + "))");
            }
            return cmdlist;
        }
        public static string GetInPutTimeCmdString(DateTime StartTime, DateTime EndTime, bool IsAnalysisQuery)
        {
            string cmd_select = "";
            if (StartTime > DateTime.MinValue)
            {
                cmd_select += ",'" + StartTime.ToString("yyyy-MM-dd 00:00:00") + "' as InPutStartTime";
            }
            else
            {
                cmd_select += ",NULL as InPutStartTime";
            }
            if (EndTime > DateTime.MinValue)
            {
                cmd_select += ",'" + EndTime.ToString("yyyy-MM-dd 23:59:59") + "' as InPutEndTime";
            }
            else
            {
                cmd_select += ",NULL as InPutEndTime";
            }
            cmd_select += "," + (IsAnalysisQuery ? "1" : "0") + " as IsAnalysisQuery";
            return cmd_select;
        }
    }
    public partial class ViewRoomFeeHistoryDetail : ViewRoomFeeHistory
    {
        public static Dictionary<int, ViewRoomFee> ViewRoomFee_Dic = new Dictionary<int, ViewRoomFee>();
        [DatabaseColumn("Contract_RoomChargeID")]
        public int Contract_RoomChargeID { get; set; }
        [DatabaseColumn("AllParentID")]
        public string AllParentID { get; set; }
        [DatabaseColumn("InPutStartTime")]
        public DateTime InPutStartTime { get; set; }
        [DatabaseColumn("InPutEndTime")]
        public DateTime InPutEndTime { get; set; }
        [DatabaseColumn("IsAnalysisQuery")]
        public bool IsAnalysisQuery { get; set; }
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
        public DateTime ActiveStartTime
        {
            get
            {
                var result = ViewRoomFeeHistoryBase.Get_ActiveStartTime(this);
                return result;
            }
        }
        public DateTime ActiveEndTime
        {
            get
            {
                var result = ViewRoomFeeHistoryBase.Get_ActiveEndTime(this);
                return result;
            }
        }
        public decimal MonthTotalCost
        {
            get
            {
                var result = ViewRoomFeeHistoryBase.Get_MonthTotalCost(this);
                return result;
            }
        }
        public decimal MonthDiscountCost
        {
            get
            {
                var result = ViewRoomFeeHistoryBase.Get_MonthDiscountCost(this);
                return result;
            }
        }
        public decimal CalculateDayPercent
        {
            get
            {
                var result = ViewRoomFeeHistoryBase.Get_CalculateDayPercent(this);
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
                return Convert.ToInt32(Math.Floor(tspan.TotalDays)) + 1;
            }
        }
        public int CalculateStartEndDay
        {
            get
            {
                DateTime _StartTime = this.StartTime > this.InPutStartTime ? this.StartTime : this.InPutStartTime;
                DateTime _EndTime = this.EndTime < this.InPutEndTime ? this.EndTime : this.InPutEndTime;
                if (_StartTime == DateTime.MinValue || _EndTime == DateTime.MinValue)
                {
                    return 1;
                }
                if (_StartTime > _EndTime)
                {
                    return 0;
                }
                var tspan = _EndTime - _StartTime;
                return Convert.ToInt32(Math.Floor(tspan.TotalDays)) + 1;
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
                return ViewRoomFeeHistoryBase.GetAnalysisQueryValue(true, result);
            }
        }
        public decimal TotalCost
        {
            get
            {
                if (this.IsTempFee)
                {
                    if (this.InPutStartTime == DateTime.MinValue && this.InPutEndTime == DateTime.MinValue)
                    {
                        return this.RealCost;
                    }
                    if (this.ChargeTime >= this.InPutStartTime && this.ChargeTime <= this.InPutEndTime)
                    {
                        return this.RealCost;
                    }
                    return 0;
                }
                if (this.RoomFeeCount > 0)
                {
                    return 0;
                }
                if (this.EndTime < this.InPutEndTime && this.ContractID <= 0)
                {
                    this.InPutEndTime = this.EndTime;
                }
                DateTime CalculateStartTime = RoomFeeAnalysisBase.Get_CalculateStartTime(this.ContractID, this.InPutStartTime, this.StartTime, this.ImportFeeID, this.FeeType, this.RelatedFeeID, this.WeiYueStartDate, this.WeiYueDays, this.WeiYueBefore, this.ChargeMeterProjectFeeID);
                DateTime CalculateEndTime = RoomFeeAnalysisBase.Get_CalculateEndTime(this.ContractID, this.InPutEndTime, this.EndTime, this.ImportFeeID, CalculateStartTime, this.NewEndTime, this.RelatedFeeID, this.FeeType, this.CuiShouStartTime, this.ChargeMeterProjectFeeID);
                //ViewRoomFee data = null;
                //if (ViewRoomFee_Dic.ContainsKey(this.HistoryID))
                //{
                //    data = ViewRoomFee_Dic[this.HistoryID];
                //}
                //if (data == null)
                //{
                //    data = ViewRoomFeeHistoryBase.StructureViewRoomFee(this);
                //    ViewRoomFee_Dic[this.HistoryID] = data;
                //}
                //data.InPutStartTime = this.InPutStartTime;
                //data.InPutEndTime = this.InPutEndTime;
                //if (data.EndTime < data.InPutEndTime && data.ContractID <= 0)
                //{
                //    data.InPutEndTime = data.EndTime;
                //}
                decimal cost = RoomFeeAnalysisBase.Get_ALLFinalTotalCost(this.InPutStartTime, this.InPutEndTime, CalculateStartTime, CalculateEndTime, this.ContractID, this.StartTime, this.EndTime, this.ReadyChargeTime, historyfee: this);
                return cost;
            }
        }
        public static void CalculateActiveTime(ViewRoomFeeHistoryDetail self, DateTime StartTime, DateTime EndTime, out DateTime start, out DateTime end)
        {
            start = DateTime.MinValue;
            end = DateTime.MinValue;
            if (self.CategoryID == 3 || self.CategoryID == 4)
            {
                start = StartTime;
                end = EndTime;
            }
            else if (self.InPutStartTime == DateTime.MinValue && self.InPutEndTime == DateTime.MinValue)
            {
                start = DateTime.MinValue;
                end = DateTime.MinValue;
            }
            else if (self.InPutStartTime > self.InPutEndTime)
            {
                start = DateTime.MinValue;
                end = DateTime.MinValue;
            }
            else if (self.InPutEndTime < StartTime)
            {
                start = DateTime.MinValue;
                end = DateTime.MinValue;
            }
            else if (self.InPutStartTime > EndTime)
            {
                start = DateTime.MinValue;
                end = DateTime.MinValue;
            }
            else if (self.InPutEndTime >= StartTime && self.InPutStartTime <= StartTime && self.InPutEndTime >= EndTime)
            {
                start = StartTime;
                end = EndTime;
            }
            else if (self.InPutEndTime >= StartTime && self.InPutStartTime <= StartTime && self.InPutEndTime < EndTime)
            {
                start = StartTime;
                end = self.InPutEndTime;
            }
            else if (self.InPutStartTime > StartTime && self.InPutStartTime <= EndTime && self.InPutEndTime >= EndTime)
            {
                start = self.InPutStartTime;
                end = EndTime;
            }
            else if (self.InPutStartTime > StartTime && self.InPutEndTime < EndTime)
            {
                start = self.InPutStartTime;
                end = self.InPutEndTime;
            }
        }
        public static ViewRoomFeeHistoryDetail[] GetViewRoomFeeHistoryDetailList(List<int> RoomIDList, DateTime StartChargeTime, DateTime EndChargeTime, DateTime StartTime, DateTime EndTime, List<int> ProjectIDList = null, List<int> FeeIDList = null, List<int> ContractChargeIDList = null, List<int> ChargeIDList = null, int UserID = 0, bool RequireOrderBy = false, string ChargeMan = "", bool IncludePrintTotalCost = false, bool IsAnalysisQuery = false, bool OnlyWuye = false, bool RequireMerge = true, int[] ChargeStateList = null, int ChargeTypeID = -1, bool requireRelationRoom = false)
        {
            decimal TotalPrintCost = 0;
            int[] ChargeTypeIDList = new int[] { };
            if (ChargeTypeID >= 0)
            {
                ChargeTypeIDList = new int[] { ChargeTypeID };
            }
            return GetViewRoomFeeHistoryDetailList(out TotalPrintCost, RoomIDList, StartChargeTime, EndChargeTime, StartTime, EndTime, ProjectIDList: ProjectIDList, FeeIDList: FeeIDList, ContractChargeIDList: ContractChargeIDList, ChargeIDList: ChargeIDList, UserID: UserID, RequireOrderBy: RequireOrderBy, ChargeMan: ChargeMan, IncludePrintTotalCost: IncludePrintTotalCost, IsAnalysisQuery: IsAnalysisQuery, OnlyWuye: OnlyWuye, RequireMerge: RequireMerge, ChargeStateList: ChargeStateList, ChargeTypeIDList: ChargeTypeIDList, requireRelationRoom: requireRelationRoom);
        }
        public static ViewRoomFeeHistoryDetail[] GetViewRoomFeeHistoryDetailList(out decimal TotalPrintCost, List<int> RoomIDList, DateTime StartChargeTime, DateTime EndChargeTime, DateTime StartTime, DateTime EndTime, List<int> ProjectIDList = null, List<int> FeeIDList = null, List<int> ContractChargeIDList = null, List<int> ChargeIDList = null, int UserID = 0, bool RequireOrderBy = false, string ChargeMan = "", bool IncludePrintTotalCost = false, bool IsAnalysisQuery = false, bool OnlyWuye = false, bool RequireMerge = true, int[] ChargeStateList = null, int[] ChargeTypeIDList = null, bool requireRelationRoom = false)
        {
            TotalPrintCost = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            if (ChargeTypeIDList != null && ChargeTypeIDList.Length > 0)
            {
                var cmdlist = new List<string>();
                cmdlist.Add("(isnull([ChageType1],-1) in (" + string.Join(",", ChargeTypeIDList) + ") and isnull([RealMoneyCost1],0)>0 and [RealCost]>0)");
                cmdlist.Add("(isnull([ChageType1],-1) in (" + string.Join(",", ChargeTypeIDList) + ") and isnull([RealMoneyCost1],0)>=0 and [RealCost]=0)");
                cmdlist.Add("(isnull([ChageType2],-1) in (" + string.Join(",", ChargeTypeIDList) + ") and isnull([RealMoneyCost2],0)>0 and [RealCost]>0)");
                cmdlist.Add("(isnull([ChageType2],-1) in (" + string.Join(",", ChargeTypeIDList) + ") and isnull([RealMoneyCost2],0)>=0 and [RealCost]=0)");
                conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
            }
            if (ChargeStateList != null && ChargeStateList.Length > 0)
            {
                conditions.Add("[ChargeState] in (" + string.Join(",", ChargeStateList) + ")");
            }
            else
            {
                conditions.Add("[ChargeState] in (1,4)");
            }
            if (OnlyWuye)
            {
                conditions.Add("ChargeFeeType=1");
            }
            if (!string.IsNullOrEmpty(ChargeMan))
            {
                conditions.Add("[ChargeMan]=@ChargeMan");
                parameters.Add(new SqlParameter("@ChargeMan", ChargeMan));
            }
            string cmdwhere = string.Empty;
            if (ChargeIDList != null && ChargeIDList.Count > 0)
            {
                conditions.Add("[ChargeID] in (" + string.Join(",", ChargeIDList.ToArray()) + ")");
            }
            if (StartTime > DateTime.MinValue)
            {
                conditions.Add("(isnull([ImportFeeID],0)=0 or [WriteDate]>=@WriteStartTime)");
                parameters.Add(new SqlParameter("@WriteStartTime", StartTime));
            }
            if (EndTime > DateTime.MinValue)
            {
                conditions.Add("(isnull([ImportFeeID],0)=0 or [WriteDate]<=@WriteEndTime)");
                parameters.Add(new SqlParameter("@WriteEndTime", EndTime));
            }
            if (StartChargeTime > DateTime.MinValue)
            {
                conditions.Add("Convert(nvarchar(10),[ChargeTime],120)>=@StartChargeTime");
                parameters.Add(new SqlParameter("@StartChargeTime", StartChargeTime));
            }
            if (EndChargeTime > DateTime.MinValue)
            {
                conditions.Add("Convert(nvarchar(10),[ChargeTime],120)<=@EndChargeTime");
                parameters.Add(new SqlParameter("@EndChargeTime", EndChargeTime));
            }
            if (RoomIDList.Count > 0)
            {
                List<string> cmdlist = ViewRoomFeeHistory.GetRoomIDListConditions(RoomIDList, IncludeRelation: true);
                conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
            }
            if (ProjectIDList != null && ProjectIDList.Count > 0)
            {
                List<string> cmdlist = ViewRoomFeeHistory.GetProjectIDListConditions(ProjectIDList, IncludeRelation: true, UserID: UserID);
                conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
            }
            if (ContractChargeIDList != null && ContractChargeIDList.Count > 0)
            {
                List<string> sub_conditions = new List<string>();
                sub_conditions.Add("(isnull([Contract_RoomChargeID],0) in (" + string.Join(",", ContractChargeIDList.ToArray()) + "))");
                if (FeeIDList != null && FeeIDList.Count > 0)
                {
                    if (FeeIDList.Count > 200)
                    {
                        ViewRoomFeeHistory.CreateTempTable(FeeIDList, UserID: UserID);
                        sub_conditions.Add("(EXISTS (SELECT 1 FROM [TempIDs] WHERE id=A.ID and [UserID]=" + UserID + "))");
                    }
                    else
                    {
                        sub_conditions.Add("(A.[ID] in (" + string.Join(",", FeeIDList.ToArray()) + "))");
                    }
                }
                conditions.Add("(" + string.Join(" or ", sub_conditions.ToArray()) + ")");
            }
            else if (FeeIDList != null && FeeIDList.Count > 0)
            {
                if (FeeIDList.Count > 20)
                {
                    ViewRoomFeeHistory.CreateTempTable(FeeIDList, UserID: UserID);
                    conditions.Add("EXISTS (SELECT 1 FROM [TempIDs] WHERE id=A.ID and UserID=" + UserID + ")");
                }
                else
                {
                    conditions.Add("A.ID in (" + string.Join(",", FeeIDList.ToArray()) + ")");
                }
            }
            string orderby = string.Empty;
            if (RequireOrderBy)
            {
                orderby = " order by (case when A.FeeType=8 and A.RelatedFeeID>1 then isnull((select top 1 DefaultOrder from Project where ID=(select top 1 RoomID from RoomFeeHistory where ID=A.RelatedFeeID)),DefaultOrder) else DefaultOrder end) asc,(case when A.FeeType=8 and A.RelatedFeeID>1 then isnull((select top 1 AddTime from RoomFeeHistory where ID=A.RelatedFeeID),AddTime) else AddTime end) asc,AddTime asc";
            }
            ViewRoomFeeHistoryDetail[] list = new ViewRoomFeeHistoryDetail[] { };
            string cmd_select = GetInPutTimeCmdString(StartTime, EndTime, IsAnalysisQuery: IsAnalysisQuery);
            string Statement = @"select * from (select *" + cmd_select + ",(select [Contract_RoomChargeID] from RoomFeeHistory where HistoryID=ViewRoomFeeHistory.HistoryID) as Contract_RoomChargeID,(select [AllParentID] from [Project] where ID=ViewRoomFeeHistory.RoomID) as AllParentID from [ViewRoomFeeHistory])A where " + string.Join(" and ", conditions.ToArray());
            list = GetList<ViewRoomFeeHistoryDetail>(Statement + orderby, parameters).ToArray();
            if (IncludePrintTotalCost)
            {
                using (SqlHelper helper = new SqlHelper())
                {
                    string cmdtext = "select sum(isnull(RealCost,0)) from [PrintRoomFeeHistory] where [ID] in (select [PrintID] from (" + Statement + ")A where " + string.Join(" and ", conditions.ToArray()) + ")";
                    var objresult = helper.ExecuteScalar(cmdtext, CommandType.Text, parameters);
                    if (objresult != null)
                    {
                        decimal.TryParse(objresult.ToString(), out TotalPrintCost);
                    }
                }
            }
            if (RequireMerge)
            {
                list = GetFinalViewRoomFeeHistoryDetailList(list);
            }
            if (requireRelationRoom)
            {
                GetViewRoomFeeHistoryDetailFinalRelationDataList(list);
            }
            return list;
        }
        public static ViewRoomFeeHistoryDetail[] GetViewRoomFeeHistoryDetail2List(List<int> RoomIDList, List<int> ProjectIDList, DateTime StartTime, DateTime EndTime, List<int> ChargeIDList, int UserID = 0, List<int> ChargeStateList = null, bool IsAnalysisQuery = false, int[] ChargeTypeIDList = null, bool requireRelationRoom = true)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            if (ChargeTypeIDList != null && ChargeTypeIDList.Length > 0)
            {
                var cmdlist = new List<string>();
                cmdlist.Add("(isnull([ChageType1],-1) in (" + string.Join(",", ChargeTypeIDList) + ") and isnull([RealMoneyCost1],0)>0 and [RealCost]>0)");
                cmdlist.Add("(isnull([ChageType1],-1) in (" + string.Join(",", ChargeTypeIDList) + ") and isnull([RealMoneyCost1],0)>=0 and [RealCost]=0)");
                cmdlist.Add("(isnull([ChageType2],-1) in (" + string.Join(",", ChargeTypeIDList) + ") and isnull([RealMoneyCost2],0)>0 and [RealCost]>0)");
                cmdlist.Add("(isnull([ChageType2],-1) in (" + string.Join(",", ChargeTypeIDList) + ") and isnull([RealMoneyCost2],0)>=0 and [RealCost]=0)");
                conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
            }
            if (ChargeStateList == null)
            {
                conditions.Add("[ChargeState] in (1,4)");
            }
            else if (ChargeStateList.Count > 0)
            {
                conditions.Add("[ChargeState] in (" + string.Join(",", ChargeStateList.ToArray()) + ")");
            }
            string cmdwhere = string.Empty;
            //if (StartTime > DateTime.MinValue)
            //{
            //    conditions.Add("(isnull([ImportFeeID],0)=0 or [WriteDate]>=@WriteStartTime)");
            //    parameters.Add(new SqlParameter("@WriteStartTime", StartTime));
            //}
            //if (EndTime > DateTime.MinValue)
            //{
            //    conditions.Add("(isnull([ImportFeeID],0)=0 or [WriteDate]<=@WriteEndTime)");
            //    parameters.Add(new SqlParameter("@WriteEndTime", EndTime));
            //}
            if (ProjectIDList.Count > 0)
            {
                List<string> cmdlist = ViewRoomFeeHistory.GetProjectIDListConditions(ProjectIDList, IncludeRelation: true, UserID: UserID);
                conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
            }
            if (RoomIDList.Count > 0)
            {
                List<string> cmdlist = ViewRoomFeeHistory.GetRoomIDListConditions(RoomIDList, IncludeRelation: true);
                conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
            }
            if (ChargeIDList.Count > 0)
            {
                conditions.Add("[ChargeID] in (" + string.Join(",", ChargeIDList.ToArray()) + ")");
            }
            string cmd_select = GetInPutTimeCmdString(StartTime, EndTime, IsAnalysisQuery: IsAnalysisQuery);
            string Statement = "select * from (select *" + cmd_select + ",(select [AllParentID] from [Project] where ID=ViewRoomFeeHistory.RoomID) as AllParentID from [ViewRoomFeeHistory])A where " + string.Join(" and ", conditions.ToArray());
            ViewRoomFeeHistoryDetail[] list = GetList<ViewRoomFeeHistoryDetail>(Statement, parameters).ToArray();
            list = GetFinalViewRoomFeeHistoryDetailList(list);
            if (requireRelationRoom)
            {
                GetViewRoomFeeHistoryDetailFinalRelationDataList(list);
            }
            return list;
        }
        public static ViewRoomFeeHistoryDetail[] GetViewRoomFeeHistoryDetailListByMinMaxID(int MinRoomID, int MaxRoomID, DateTime StartTime, DateTime EndTime, bool IsAnalysisQuery = false)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("RoomID between " + MinRoomID + " and " + MaxRoomID);
            string cmd_select = GetInPutTimeCmdString(StartTime, EndTime, IsAnalysisQuery: IsAnalysisQuery);
            string Statement = "select * from (select *" + cmd_select + ",(select [AllParentID] from [Project] where ID=ViewRoomFeeHistory.RoomID) as AllParentID from [ViewRoomFeeHistory])A where " + string.Join(" and ", conditions.ToArray());
            ViewRoomFeeHistoryDetail[] list = GetList<ViewRoomFeeHistoryDetail>(Statement, parameters).ToArray();
            list = GetFinalViewRoomFeeHistoryDetailList(list);
            return list;
        }
        public static ViewRoomFeeHistoryDetail[] GetViewRoomFeeHistoryDetailListByMinMaxID(int MinRoomID, int MaxRoomID, DateTime StartChargeTime, DateTime EndChargeTime, DateTime StartTime, DateTime EndTime, List<int> ChargeIDList = null, string ChargeMan = "", bool IsAnalysisQuery = false, bool OnlyWuye = false, int[] ChargeStateList = null)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            if (ChargeStateList != null && ChargeStateList.Length > 0)
            {
                conditions.Add("[ChargeState] in (" + string.Join(",", ChargeStateList) + ")");
            }
            else
            {
                conditions.Add("[ChargeState] in (1,4)");
            }
            if (OnlyWuye)
            {
                conditions.Add("ChargeFeeType=1");
            }
            if (!string.IsNullOrEmpty(ChargeMan))
            {
                conditions.Add("[ChargeMan]=@ChargeMan");
                parameters.Add(new SqlParameter("@ChargeMan", ChargeMan));
            }
            string cmdwhere = string.Empty;
            if (ChargeIDList != null && ChargeIDList.Count > 0)
            {
                conditions.Add("[ChargeID] in (" + string.Join(",", ChargeIDList.ToArray()) + ")");
            }
            if (StartTime > DateTime.MinValue)
            {
                conditions.Add("(isnull([ImportFeeID],0)=0 or [WriteDate]>=@WriteStartTime)");
                parameters.Add(new SqlParameter("@WriteStartTime", StartTime));
            }
            if (EndTime > DateTime.MinValue)
            {
                conditions.Add("(isnull([ImportFeeID],0)=0 or [WriteDate]<=@WriteEndTime)");
                parameters.Add(new SqlParameter("@WriteEndTime", EndTime));
            }
            if (StartChargeTime > DateTime.MinValue)
            {
                conditions.Add("Convert(nvarchar(10),[ChargeTime],120)>=@StartChargeTime");
                parameters.Add(new SqlParameter("@StartChargeTime", StartChargeTime));
            }
            if (EndChargeTime > DateTime.MinValue)
            {
                conditions.Add("Convert(nvarchar(10),[ChargeTime],120)<=@EndChargeTime");
                parameters.Add(new SqlParameter("@EndChargeTime", EndChargeTime));
            }
            conditions.Add("(RoomID between " + MinRoomID + " and " + MaxRoomID + " or [RoomID]=0)");
            string orderby = string.Empty;
            ViewRoomFeeHistoryDetail[] list = new ViewRoomFeeHistoryDetail[] { };
            string cmd_select = GetInPutTimeCmdString(StartTime, EndTime, IsAnalysisQuery: IsAnalysisQuery);
            string Statement = @"select * from (select *" + cmd_select + ",(select [Contract_RoomChargeID] from RoomFeeHistory where HistoryID=ViewRoomFeeHistory.HistoryID) as Contract_RoomChargeID,(select [AllParentID] from [Project] where ID=ViewRoomFeeHistory.RoomID) as AllParentID from [ViewRoomFeeHistory])A where " + string.Join(" and ", conditions.ToArray());
            list = GetList<ViewRoomFeeHistoryDetail>(Statement + orderby, parameters).ToArray();
            return list;
        }
        public decimal LishiShouBenqi
        {
            get
            {
                return ViewRoomFeeHistoryBase.Get_LishiShouBenqi(this);
            }
        }
        public decimal LishiShouBenqi_ShiShou_ChargeType1
        {
            get
            {
                this.RealCost = this.RealCost > 0 ? this.RealCost : 0;
                this.RealMoneyCost1 = this.RealMoneyCost1 > 0 ? this.RealMoneyCost1 : 0;
                this.PrintRealCost = this.PrintRealCost > 0 ? this.PrintRealCost : 1;
                return ViewRoomFeeHistoryBase.Get_LishiShouBenqiCost(this, (this.RealMoneyCost1 / this.PrintRealCost) * RealCost, 1);
            }
        }
        public decimal LishiShouBenqi_ShiShou_ChargeType2
        {
            get
            {
                this.RealCost = this.RealCost > 0 ? this.RealCost : 0;
                this.RealMoneyCost2 = this.RealMoneyCost2 > 0 ? this.RealMoneyCost2 : 0;
                this.PrintRealCost = this.PrintRealCost > 0 ? this.PrintRealCost : 1;
                return ViewRoomFeeHistoryBase.Get_LishiShouBenqiCost(this, (this.RealMoneyCost2 / this.PrintRealCost) * RealCost, 1);
            }
        }
        public decimal LishiShouBenqi_ShiShou
        {
            get
            {
                return ViewRoomFeeHistoryBase.Get_LishiShouBenqiCost(this, this.RealCost, 1);
            }
        }
        public decimal LishiShouBenqi_ChongDi
        {
            get
            {
                return ViewRoomFeeHistoryBase.Get_LishiShouBenqiCost(this, this.RealCost, 4);
            }
        }
        public decimal LishiShouBenqi_JianMian
        {
            get
            {
                return ViewRoomFeeHistoryBase.Get_LishiShouBenqiCost(this, this.Discount, 0);
            }
        }
        public decimal BenqiShouLishi
        {
            get
            {
                return ViewRoomFeeHistoryBase.Get_BenqiShouLishi(this);
            }
        }
        public decimal BenqiShouLishi_ShiShou_ChargeType1
        {
            get
            {
                this.RealCost = this.RealCost > 0 ? this.RealCost : 0;
                this.RealMoneyCost1 = this.RealMoneyCost1 > 0 ? this.RealMoneyCost1 : 0;
                this.PrintRealCost = this.PrintRealCost > 0 ? this.PrintRealCost : 1;
                return ViewRoomFeeHistoryBase.Get_BenqiShouLishiCost(this, (this.RealMoneyCost1 / this.PrintRealCost) * RealCost, 1);
            }
        }
        public decimal BenqiShouLishi_ShiShou_ChargeType2
        {
            get
            {
                this.RealCost = this.RealCost > 0 ? this.RealCost : 0;
                this.RealMoneyCost2 = this.RealMoneyCost2 > 0 ? this.RealMoneyCost2 : 0;
                this.PrintRealCost = this.PrintRealCost > 0 ? this.PrintRealCost : 1;
                return ViewRoomFeeHistoryBase.Get_BenqiShouLishiCost(this, (this.RealMoneyCost2 / this.PrintRealCost) * RealCost, 1);
            }
        }
        public decimal BenqiShouLishi_ShiShou
        {
            get
            {
                return ViewRoomFeeHistoryBase.Get_BenqiShouLishiCost(this, this.RealCost, 1);
            }
        }
        public decimal BenqiShouLishi_ChongDi
        {
            get
            {
                return ViewRoomFeeHistoryBase.Get_BenqiShouLishiCost(this, this.RealCost, 4);
            }
        }
        public decimal BenqiShouLishi_JianMian
        {
            get
            {
                return ViewRoomFeeHistoryBase.Get_BenqiShouLishiCost(this, this.Discount, 0);
            }
        }
        public decimal BenqiShouBenqi
        {
            get
            {
                return ViewRoomFeeHistoryBase.Get_BenqiShouBenqi(this);
            }
        }
        public decimal BenqiShouBenqi_ShiShou_ChargeType1
        {
            get
            {
                this.RealCost = this.RealCost > 0 ? this.RealCost : 0;
                this.RealMoneyCost1 = this.RealMoneyCost1 > 0 ? this.RealMoneyCost1 : 0;
                this.PrintRealCost = this.PrintRealCost > 0 ? this.PrintRealCost : 1;
                return ViewRoomFeeHistoryBase.Get_BenqiShouBenqiCost(this, (this.RealMoneyCost1 / this.PrintRealCost) * RealCost, 1);
            }
        }
        public decimal BenqiShouBenqi_ShiShou_ChargeType2
        {
            get
            {
                this.RealCost = this.RealCost > 0 ? this.RealCost : 0;
                this.RealMoneyCost2 = this.RealMoneyCost2 > 0 ? this.RealMoneyCost2 : 0;
                this.PrintRealCost = this.PrintRealCost > 0 ? this.PrintRealCost : 1;
                return ViewRoomFeeHistoryBase.Get_BenqiShouBenqiCost(this, (this.RealMoneyCost2 / this.PrintRealCost) * RealCost, 1);
            }
        }
        public decimal BenqiShouBenqi_ShiShou
        {
            get
            {
                return ViewRoomFeeHistoryBase.Get_BenqiShouBenqiCost(this, this.RealCost, 1);
            }
        }
        public decimal BenqiShouBenqi_ChongDi
        {
            get
            {
                return ViewRoomFeeHistoryBase.Get_BenqiShouBenqiCost(this, this.RealCost, 4);
            }
        }
        public decimal BenqiShouBenqi_JianMian
        {
            get
            {
                return ViewRoomFeeHistoryBase.Get_BenqiShouBenqiCost(this, this.Discount, 0);
            }
        }
        public decimal BenqiYuShou
        {
            get
            {
                return ViewRoomFeeHistoryBase.Get_BenqiYuShou(this);
            }
        }
        public decimal BenqiYuShou_ShiShou_ChargeType1
        {
            get
            {
                this.RealCost = this.RealCost > 0 ? this.RealCost : 0;
                this.RealMoneyCost1 = this.RealMoneyCost1 > 0 ? this.RealMoneyCost1 : 0;
                this.PrintRealCost = this.PrintRealCost > 0 ? this.PrintRealCost : 1;
                return ViewRoomFeeHistoryBase.Get_BenqiYuShouCost(this, (this.RealMoneyCost1 / this.PrintRealCost) * RealCost, 1);
            }
        }
        public decimal BenqiYuShou_ShiShou_ChargeType2
        {
            get
            {
                this.RealCost = this.RealCost > 0 ? this.RealCost : 0;
                this.RealMoneyCost2 = this.RealMoneyCost2 > 0 ? this.RealMoneyCost2 : 0;
                this.PrintRealCost = this.PrintRealCost > 0 ? this.PrintRealCost : 1;
                return ViewRoomFeeHistoryBase.Get_BenqiYuShouCost(this, (this.RealMoneyCost2 / this.PrintRealCost) * RealCost, 1);
            }
        }
        public decimal BenqiYuShou_ShiShou
        {
            get
            {
                return ViewRoomFeeHistoryBase.Get_BenqiYuShouCost(this, this.RealCost, 1);
            }
        }
        public bool IsTempFee
        {
            get
            {
                if ((this.FeeType == 1 && this.StartTime > DateTime.MinValue && this.EndTime > DateTime.MinValue) || (this.ImportFeeID > 0 && this.WriteDate > DateTime.MinValue))
                {
                    return false;
                }
                return true;
            }
        }
        public decimal BenqiYuShou_ChongDi
        {
            get
            {
                return ViewRoomFeeHistoryBase.Get_BenqiYuShouCost(this, this.RealCost, 4);
            }
        }
        public decimal BenqiYuShou_JianMian
        {
            get
            {
                return ViewRoomFeeHistoryBase.Get_BenqiYuShouCost(this, this.Discount, 0);
            }
        }
        public decimal ZhiHouShouBenqi
        {
            get
            {
                return ViewRoomFeeHistoryBase.Get_ZhiHouShouBenqi(this);
            }
        }
        public decimal ZhiHouShouBenqi_ShiShou_ChargeType1
        {
            get
            {
                this.RealCost = this.RealCost > 0 ? this.RealCost : 0;
                this.RealMoneyCost1 = this.RealMoneyCost1 > 0 ? this.RealMoneyCost1 : 0;
                this.PrintRealCost = this.PrintRealCost > 0 ? this.PrintRealCost : 1;
                return ViewRoomFeeHistoryBase.Get_ZhiHouShouBenqiCost(this, (this.RealMoneyCost1 / this.PrintRealCost) * RealCost, 1);
            }
        }
        public decimal ZhiHouShouBenqi_ShiShou_ChargeType2
        {
            get
            {
                this.RealCost = this.RealCost > 0 ? this.RealCost : 0;
                this.RealMoneyCost2 = this.RealMoneyCost2 > 0 ? this.RealMoneyCost2 : 0;
                this.PrintRealCost = this.PrintRealCost > 0 ? this.PrintRealCost : 1;
                return ViewRoomFeeHistoryBase.Get_ZhiHouShouBenqiCost(this, (this.RealMoneyCost2 / this.PrintRealCost) * RealCost, 1);
            }
        }
        public decimal ZhiHouShouBenqi_ShiShou
        {
            get
            {
                return ViewRoomFeeHistoryBase.Get_ZhiHouShouBenqiCost(this, this.RealCost, 1);
            }
        }
        public decimal ZhiHouShouBenqi_ChongDi
        {
            get
            {
                return ViewRoomFeeHistoryBase.Get_ZhiHouShouBenqiCost(this, this.RealCost, 4);
            }
        }
        public decimal ZhiHouShouBenqi_JianMian
        {
            get
            {
                return ViewRoomFeeHistoryBase.Get_ZhiHouShouBenqiCost(this, this.Discount, 0);
            }
        }
        public decimal BenqiChongXiao
        {
            get
            {
                return ViewRoomFeeHistoryBase.Get_BenqiChongXiao(this);
            }
        }
        public decimal BenqiChongXiao_ShiShou
        {
            get
            {
                return 0;
            }
        }
        public decimal BenqiChongXiao_ChongDi
        {
            get
            {
                return ViewRoomFeeHistoryBase.Get_BenqiChongXiaoCost(this, this.RealCost, 4);
            }
        }
        public decimal BenqiChongXiao_JianMian
        {
            get
            {
                return ViewRoomFeeHistoryBase.Get_BenqiChongXiaoCost(this, this.Discount, 4);
            }
        }
        public static bool IsAllowBenQi(ViewRoomFeeHistoryDetail self)
        {
            if (self.FeeType == 1 || self.ImportFeeID > 0 || self.CategoryID == 3 || self.CategoryID == 4)
            {
                return true;
            }
            return false;
        }
        public static DateTime GetFinalInputEndTime(DateTime InputEndTime)
        {
            if (InputEndTime > DateTime.MinValue)
            {
                return Convert.ToDateTime(InputEndTime.ToString("yyyy-MM-dd 23:59:59"));
            }
            return DateTime.MinValue;
        }
        public static decimal calculateTotalCost(DateTime starttime, DateTime endtime, DateTime StartTime, DateTime EndTime, decimal RealCost, int EndNumberCount, bool IsAnalysisQuery)
        {
            if (starttime == DateTime.MinValue || endtime == DateTime.MinValue)
            {
                return 0;
            }
            if (RealCost <= 0)
            {
                return 0;
            }
            int ActiveMonthNumber = Utility.Tools.calculatemonth(starttime, endtime);
            decimal ActiveTotalDays = Utility.Tools.calculateTotaldays(starttime, endtime, ActiveMonthNumber, true);
            ActiveTotalDays = ActiveTotalDays == 0 ? 1 : ActiveTotalDays;
            int ActiveRestDays = Utility.Tools.calculateTotaldays(starttime, endtime, ActiveMonthNumber, false);
            int MonthNumber = Utility.Tools.calculatemonth(StartTime, EndTime);
            MonthNumber = MonthNumber < 0 ? 0 : MonthNumber;
            decimal TotalDays = Utility.Tools.calculateTotaldays(StartTime, EndTime, MonthNumber, true);
            TotalDays = TotalDays == 0 ? 1 : TotalDays;
            int RestDays = Utility.Tools.calculateTotaldays(StartTime, EndTime, MonthNumber, false);
            if (MonthNumber + (RestDays / TotalDays) == 0)
            {
                return 0;
            }
            decimal calculateCost = RealCost * (ActiveMonthNumber + (ActiveRestDays / ActiveTotalDays)) / (MonthNumber + (RestDays / TotalDays));
            if (calculateCost <= 0)
            {
                return 0;
            }
            return ViewRoomFeeHistoryBase.GetAnalysisQueryValue(true, calculateCost);
        }
        public static ViewRoomFeeHistoryDetail[] GetFinalViewRoomFeeHistoryDetailList(ViewRoomFeeHistoryDetail[] history_list)
        {
            var base_list = history_list.GroupBy(p => p.ID).Select(p => (new { ID = p.Key, count = p.Count() })).ToArray();
            var IDList = base_list.Where(p => p.count < 2).Select(p => p.ID).ToArray();
            var my_history_list = history_list.Where(p => IDList.Contains(p.ID)).ToList();
            var MultipleIDList = base_list.Where(p => p.count >= 2).Select(p => p.ID).ToArray();
            foreach (var ID in MultipleIDList)
            {
                var my_history_list_2 = history_list.Where(p => p.ID == ID).ToList();
                if (my_history_list_2.Count == 0)
                {
                    continue;
                }
                if (ID <= 0)
                {
                    my_history_list.AddRange(my_history_list_2);
                    continue;
                }
                DateTime My_StartTime = my_history_list_2.Min(p => p.StartTime);
                DateTime My_EndTime = my_history_list_2.Max(p => p.EndTime);
                var data = my_history_list_2.FirstOrDefault(p => p.ID == ID);
                data.StartTime = My_StartTime;
                data.EndTime = My_EndTime;
                data.RealCost = my_history_list_2.Sum(p => p.RealCost);
                my_history_list.Add(data);
            }
            return my_history_list.ToArray();
        }
        public static ViewRoomFeeHistoryDetail[] GetFinalViewRoomFeeHistoryDetailList(ViewRoomFeeHistoryDetail[] history_list, DateTime StartTime, DateTime EndTime)
        {
            var history_list1 = history_list.Where(p =>
            {
                p.InPutStartTime = StartTime;
                p.InPutEndTime = EndTime;
                if (p.InPutStartTime > DateTime.MinValue && p.ImportFeeID > 0 && Convert.ToDateTime(p.WriteDate.ToString("yyyy-MM-dd")) < Convert.ToDateTime(p.InPutStartTime.ToString("yyyy-MM-dd")))
                {
                    return false;
                }
                if (p.InPutEndTime > DateTime.MinValue && p.ImportFeeID > 0 && Convert.ToDateTime(p.WriteDate.ToString("yyyy-MM-dd")) > Convert.ToDateTime(p.InPutEndTime.ToString("yyyy-MM-dd")))
                {
                    return false;
                }
                //if (p.InPutStartTime > DateTime.MinValue && p.FeeType == 4 && Convert.ToDateTime(p.ChargeTime.ToString("yyyy-MM-dd")) < Convert.ToDateTime(p.InPutStartTime.ToString("yyyy-MM-dd")))
                //{
                //    return false;
                //}
                //if (p.InPutEndTime > DateTime.MinValue && p.FeeType == 4 && Convert.ToDateTime(p.ChargeTime.ToString("yyyy-MM-dd")) > Convert.ToDateTime(p.InPutEndTime.ToString("yyyy-MM-dd")))
                //{
                //    return false;
                //}
                return (p.MonthTotalCost > 0 || p.MonthDiscountCost > 0 || p.BenqiYuShou > 0 || p.BenqiShouLishi > 0);
            }).ToArray();
            return history_list1;
        }
        public static List<Dictionary<string, object>> GetFinalViewRoomFeeHistoryDetailDictionary(ViewRoomFeeHistoryDetail[] history_list, DateTime StartTime, DateTime EndTime)
        {
            var history_list1 = history_list.Select(p =>
            {
                p.InPutStartTime = StartTime;
                p.InPutEndTime = EndTime;
                var dic = p.ToJsonObject();
                dic["ID"] = p.ID;
                dic["RoomID"] = p.RoomID;
                dic["AllParentID"] = p.AllParentID;
                dic["FinalAllParentID"] = p.FinalAllParentID;
                dic["ChargeID"] = p.ChargeID;
                dic["MonthTotalCost"] = p.MonthTotalCost;
                dic["MonthDiscountCost"] = p.MonthDiscountCost;
                dic["BenqiYuShou"] = p.BenqiYuShou;
                dic["BenqiShouLishi"] = p.BenqiShouLishi;
                dic["TotalCost"] = p.TotalCost;
                return dic;
            }).ToList();
            return history_list1;
        }
        public static List<Dictionary<string, object>> GetViewRoomFeeHistoryDetailDictionary(ViewRoomFeeHistoryDetail[] history_list, DateTime StartTime, DateTime EndTime)
        {
            var history_list1 = GetFinalViewRoomFeeHistoryDetailList(history_list, StartTime, EndTime);
            return GetFinalViewRoomFeeHistoryDetailDictionary(history_list1, StartTime, EndTime);
        }
        public static void GetViewRoomFeeHistoryDetailFinalRelationDataList(ViewRoomFeeHistoryDetail[] list)
        {
            if (list.Length == 0)
            {
                return;
            }
            var MinID = list.Min(p => p.RoomID);
            var MaxID = list.Max(p => p.RoomID);
            var relationList = RoomRelation.GetRoomRelationListByMinMaxRoomID(MinID, MaxID);
            var projectList = Project.GetProjectListByMinMaxID(MinID, MaxID);
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
                var myAllParentIDList = projectList.Where(p => relationRoomIDList.Contains(p.ID)).Select(p => p.AllParentID).ToArray();
                if (myAllParentIDList.Length > 0)
                {
                    item.RelationAllParentID = string.Join("", myAllParentIDList);
                }
                item.RelationRoomIDList = relationRoomIDList;
            }
        }
    }
    public partial class ViewRoomFeeHistoryBase : EntityBaseReadOnly
    {
        protected override void EnsureParentProperties()
        {
        }
        public static DateTime Get_ActiveStartTime(ViewRoomFeeHistoryDetail self)
        {
            DateTime start = DateTime.MinValue;
            DateTime end = DateTime.MinValue;
            ViewRoomFeeHistoryDetail.CalculateActiveTime(self, self.StartTime, self.EndTime, out start, out end);
            return start;
        }
        public static DateTime Get_ActiveEndTime(ViewRoomFeeHistoryDetail self)
        {
            DateTime start = DateTime.MinValue;
            DateTime end = DateTime.MinValue;
            ViewRoomFeeHistoryDetail.CalculateActiveTime(self, self.StartTime, self.EndTime, out start, out end);
            return end;
        }
        public static decimal Get_CalculateDayPercent(ViewRoomFeeHistoryDetail self)
        {
            if (self.IsTempFee)
            {
                if (self.ChargeTime >= self.InPutStartTime && self.ChargeTime <= self.InPutEndTime)
                {
                    return 1;
                }
                return 0;
            }
            if (self.ContractID > 0 && self.InPutStartTime > DateTime.MinValue && self.InPutEndTime > DateTime.MinValue)
            {
                if (self.StartTime > self.InPutEndTime || self.EndTime < self.InPutStartTime)
                {
                    return 0;
                }
            }
            if (self.FeeType != 1)
            {
                return 1;
            }
            if (self.ActiveStartTime == DateTime.MinValue && self.ActiveEndTime == DateTime.MinValue)
            {
                if (self.InPutStartTime > DateTime.MinValue || self.InPutEndTime > DateTime.MinValue)
                {
                    return 0;
                }
                return 1;
            }
            int MonthNumber = Utility.Tools.calculatemonth(self.StartTime, self.EndTime);
            int ActiveMonthNumber = Utility.Tools.calculatemonth(self.ActiveStartTime, self.ActiveEndTime);
            decimal ActiveTotalDays = Utility.Tools.calculateTotaldays(self.ActiveStartTime, self.ActiveEndTime, ActiveMonthNumber, true);
            if (ActiveTotalDays <= 0)
            {
                return 1;
            }
            decimal TotalDays = Utility.Tools.calculateTotaldays(self.StartTime, self.EndTime, MonthNumber, true);
            if (TotalDays <= 0)
            {
                return 1;
            }
            int ActiveRestDays = Utility.Tools.calculateTotaldays(self.ActiveStartTime, self.ActiveEndTime, ActiveMonthNumber, false);
            int RestDays = Utility.Tools.calculateTotaldays(self.StartTime, self.EndTime, MonthNumber, false);
            decimal fenzi_count = ActiveMonthNumber + (ActiveRestDays / ActiveTotalDays);
            decimal fenmu_count = (MonthNumber + (RestDays / TotalDays));
            if (fenmu_count <= 0)
            {
                return 1;
            }
            return fenzi_count / fenmu_count;
        }
        public static decimal Get_MonthTotalCost(ViewRoomFeeHistoryDetail self)
        {
            decimal result = 0;
            if (self.RealCost < 0)
            {
                return 0;
            }
            if (self.IsTempFee)
            {
                if (self.InPutStartTime == DateTime.MinValue && self.InPutEndTime == DateTime.MinValue)
                {
                    result = self.RealCost;
                }
                else if (self.ChargeTime >= self.InPutStartTime && self.ChargeTime <= self.InPutEndTime)
                {
                    result = self.RealCost;
                }
            }
            else
            {
                result = self.RealCost * self.CalculateDayPercent;
            }
            return ViewRoomFeeHistoryBase.GetAnalysisQueryValue(true, result);
        }
        public static decimal Get_MonthDiscountCost(ViewRoomFeeHistoryDetail self)
        {
            if (self.Discount <= 0)
            {
                return 0;
            }
            decimal result = self.Discount * self.CalculateDayPercent;
            return ViewRoomFeeHistoryBase.GetAnalysisQueryValue(true, result);
        }
        public static ViewRoomFee StructureViewRoomFee(ViewRoomFeeHistoryDetail self)
        {
            var data = new ViewRoomFee();
            data.ViewRoomFeeHistoryDetailList = new ViewRoomFeeHistoryDetail[] { };
            //data.InPutStartTime = self.InPutEndTime;
            //data.InPutEndTime = self.InPutEndTime;
            var history_type = self.GetType();
            var history_pi = history_type.GetProperties();
            Type fee_type = data.GetType();
            var fee_pi = fee_type.GetProperties();
            foreach (PropertyInfo history in history_pi)
            {
                if (history.PropertyType == typeof(String) || history.PropertyType == typeof(Int32) || history.PropertyType == typeof(Decimal) || history.PropertyType == typeof(Boolean) || history.PropertyType == typeof(DateTime))//属性的类型判断
                {
                    string history_name = history.Name;
                    if (history_name.Equals("TotalCost"))
                    {
                        continue;
                    }
                    object history_obj = history.GetValue(self, null);
                    if (history_obj == null || history_obj == DBNull.Value)
                    {
                        continue;
                    }
                    var fee = fee_pi.FirstOrDefault(p => p.CanWrite && p.Name.Equals(history_name));
                    if (fee != null)
                    {
                        try
                        {
                            fee.SetValue(data, history_obj, null);
                        }
                        catch (Exception)
                        {
                        }
                    }
                }
            }
            return data;
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
        public static decimal GetViewRoomFeeHistoryTotalCost(ViewRoomFeeHistoryDetail[] my_history_list = null, List<Dictionary<string, object>> my_history_dic_list = null)
        {
            decimal totalcost = 0;
            var IDList = new List<int>();
            if (my_history_list != null)
            {
                my_history_list = my_history_list.OrderBy(p => p.StartTime).ToArray();
                foreach (var item in my_history_list)
                {
                    if (IDList.Contains(item.ID))
                    {
                        continue;
                    }
                    if (item.TotalCost > 0)
                    {
                        IDList.Add(item.ID);
                        totalcost += item.TotalCost;
                    }
                }
            }
            else if (my_history_dic_list != null)
            {
                my_history_dic_list = my_history_dic_list.OrderBy(p => Convert.ToDateTime(p["StartTime"])).ToList();
                foreach (var item in my_history_dic_list)
                {
                    int ID = Convert.ToInt32(item["ID"]);
                    if (IDList.Contains(ID))
                    {
                        continue;
                    }
                    decimal TotalCost = Convert.ToDecimal(item["TotalCost"]);
                    if (TotalCost > 0)
                    {
                        IDList.Add(ID);
                        totalcost += Convert.ToDecimal(item["TotalCost"]);
                    }
                }
            }
            return totalcost;
        }
        public static decimal GetViewRoomFeeHistoryRealCost(ViewRoomFeeHistoryDetail[] my_history_list, bool IncludeRealCost = true, bool IncludeDiscount = true)
        {
            decimal totalcost = 0;
            var list = my_history_list.GroupBy(p => p.ID).Select(p => (new { ID = p.Key, count = p.Count() })).ToArray();
            var MultipleIDList = list.Where(p => p.count > 1).Select(p => p.ID).ToArray();
            foreach (var ID in MultipleIDList)
            {
                var my_history_list_2 = my_history_list.Where(p => p.ID == ID).ToArray();
                if (my_history_list_2.Length == 0)
                {
                    continue;
                }
                DateTime StartTime = my_history_list_2.Min(p => p.StartTime);
                DateTime EndTime = my_history_list_2.Max(p => p.EndTime);
                var data = my_history_list.FirstOrDefault(p => p.ID == ID);
                //data.StartTime = StartTime;
                //data.EndTime = EndTime;
                //data.RealCost = my_history_list_2.Sum(p => p.RealCost);
                if (IncludeRealCost)
                {
                    totalcost += data.MonthTotalCost;
                }
                if (IncludeDiscount)
                {
                    totalcost += data.MonthDiscountCost;
                }
            }
            var IDList = list.Where(p => p.count == 1).Select(p => p.ID).ToArray();
            var my_history_list_1 = my_history_list.Where(p => IDList.Contains(p.ID)).ToArray();
            totalcost += my_history_list_1.Sum(p => p.MonthTotalCost);
            if (IncludeRealCost)
            {
                totalcost += my_history_list_1.Sum(p => p.MonthTotalCost);
            }
            if (IncludeDiscount)
            {
                totalcost += my_history_list_1.Sum(p => p.MonthDiscountCost);
            }
            return totalcost;
        }
        public static decimal Get_LishiShouBenqi(ViewRoomFeeHistoryDetail self)
        {
            decimal cost = self.LishiShouBenqi_ShiShou + self.LishiShouBenqi_ChongDi + self.LishiShouBenqi_JianMian;
            return cost;
        }
        public static decimal Get_LishiShouBenqiCost(ViewRoomFeeHistoryDetail self, decimal RealCost, int ChargeState)
        {
            if (self.ChargeState != ChargeState && ChargeState > 0)
            {
                return 0;
            }
            if (self.IsTempFee)
            {
                if (self.InPutStartTime == DateTime.MinValue && self.InPutEndTime == DateTime.MinValue)
                {
                    return 0;
                }
                if (self.ChargeTime < self.InPutStartTime)
                {
                    return RealCost;
                }
                return 0;
            }
            if (self.InPutStartTime == DateTime.MinValue && self.InPutEndTime == DateTime.MinValue)
            {
                return 0;
            }
            DateTime starttime = DateTime.MinValue;
            DateTime endtime = DateTime.MinValue;
            ViewRoomFeeHistoryDetail.CalculateActiveTime(self, self.StartTime, self.EndTime, out starttime, out endtime);
            if (self.ChargeTime < self.InPutStartTime && ViewRoomFeeHistoryDetail.IsAllowBenQi(self))
            {
                if (self.ImportFeeID > 0)
                {
                    if (self.WriteDate >= self.InPutStartTime && self.WriteDate <= self.InPutEndTime)
                    {
                        return RealCost;
                    }
                    return 0;
                }
                if (starttime == DateTime.MinValue && endtime == DateTime.MinValue)
                {
                    return 0;
                }
                return ViewRoomFeeHistoryDetail.calculateTotalCost(starttime, endtime, self.StartTime, self.EndTime, RealCost, self.EndNumberCount, self.IsAnalysisQuery);
            }
            return 0;
        }
        public static decimal Get_BenqiShouLishi(ViewRoomFeeHistoryDetail self)
        {
            decimal cost = self.BenqiShouLishi_ShiShou + self.BenqiShouLishi_ChongDi + self.BenqiShouLishi_JianMian;
            return cost;
        }
        public static decimal Get_BenqiShouLishiCost(ViewRoomFeeHistoryDetail self, decimal RealCost, int ChargeState)
        {
            if (RealCost <= 0 || (self.ChargeState != ChargeState && ChargeState > 0))
            {
                return 0;
            }
            if (self.IsTempFee)
            {
                return 0;
            }
            if (self.InPutStartTime == DateTime.MinValue && self.InPutEndTime == DateTime.MinValue)
            {
                return 0;
            }
            DateTime starttime = DateTime.MinValue;
            DateTime endtime = DateTime.MinValue;
            if (self.InPutEndTime > DateTime.MinValue)
            {
                self.InPutEndTime = ViewRoomFeeHistoryDetail.GetFinalInputEndTime(self.InPutEndTime);
            }
            if (self.ChargeTime >= self.InPutStartTime && self.ChargeTime <= self.InPutEndTime && ViewRoomFeeHistoryDetail.IsAllowBenQi(self))
            {
                if (self.ImportFeeID > 0)
                {
                    if (self.WriteDate < self.InPutStartTime)
                    {
                        return RealCost;
                    }
                    return 0;
                }
                if (self.StartTime >= self.InPutStartTime)
                {
                    return 0;
                }
                if (self.StartTime < self.InPutStartTime && self.EndTime < self.InPutStartTime)
                {
                    starttime = self.StartTime;
                    endtime = self.EndTime;
                }
                else if (self.StartTime < self.InPutStartTime && self.EndTime >= self.InPutStartTime)
                {
                    starttime = self.StartTime;
                    endtime = self.InPutStartTime.AddDays(-1);
                }
                if (starttime == DateTime.MinValue && endtime == DateTime.MinValue)
                {
                    return 0;
                }
                return ViewRoomFeeHistoryDetail.calculateTotalCost(starttime, endtime, self.StartTime, self.EndTime, RealCost, self.EndNumberCount, self.IsAnalysisQuery);
            }
            return 0;
        }
        public static decimal Get_BenqiShouBenqi(ViewRoomFeeHistoryDetail self)
        {
            decimal cost = self.BenqiShouBenqi_ShiShou + self.BenqiShouBenqi_ChongDi + self.BenqiShouBenqi_JianMian;
            return cost;
        }
        public static decimal Get_BenqiShouBenqiCost(ViewRoomFeeHistoryDetail self, decimal RealCost, int ChargeState)
        {
            if (RealCost <= 0 || (self.ChargeState != ChargeState && ChargeState > 0))
            {
                return 0;
            }
            if (self.IsTempFee)
            {
                if (self.InPutStartTime == DateTime.MinValue && self.InPutEndTime == DateTime.MinValue)
                {
                    return RealCost;
                }
                if (self.ChargeTime >= self.InPutStartTime && self.ChargeTime <= self.InPutEndTime)
                {
                    return RealCost;
                }
                return 0;
            }
            if (self.InPutStartTime == DateTime.MinValue && self.InPutEndTime == DateTime.MinValue)
            {
                return 0;
            }
            DateTime starttime = DateTime.MinValue;
            DateTime endtime = DateTime.MinValue;
            ViewRoomFeeHistoryDetail.CalculateActiveTime(self, self.StartTime, self.EndTime, out starttime, out endtime);
            if (self.InPutEndTime > DateTime.MinValue)
            {
                self.InPutEndTime = ViewRoomFeeHistoryDetail.GetFinalInputEndTime(self.InPutEndTime);
            }
            if (self.ChargeTime >= self.InPutStartTime && self.ChargeTime <= self.InPutEndTime && ViewRoomFeeHistoryDetail.IsAllowBenQi(self))
            {
                if (self.ImportFeeID > 0)
                {
                    if (self.WriteDate >= self.InPutStartTime && self.WriteDate <= self.InPutEndTime)
                    {
                        return RealCost;
                    }
                    return 0;
                }
                if (starttime == DateTime.MinValue && endtime == DateTime.MinValue)
                {
                    return 0;
                }
                return ViewRoomFeeHistoryDetail.calculateTotalCost(starttime, endtime, self.StartTime, self.EndTime, RealCost, self.EndNumberCount, self.IsAnalysisQuery);
            }
            return 0;
        }
        public static decimal Get_BenqiYuShou(ViewRoomFeeHistoryDetail self)
        {
            decimal cost = self.BenqiYuShou_ShiShou + self.BenqiYuShou_ChongDi + self.BenqiYuShou_JianMian;
            return cost;
        }
        public static decimal Get_BenqiYuShouCost(ViewRoomFeeHistoryDetail self, decimal RealCost, int ChargeState)
        {
            if (RealCost <= 0 || (self.ChargeState != ChargeState && ChargeState > 0))
            {
                return 0;
            }
            if (self.IsTempFee)
            {
                return 0;
            }
            if (self.InPutStartTime == DateTime.MinValue && self.InPutEndTime == DateTime.MinValue)
            {
                return 0;
            }
            DateTime starttime = DateTime.MinValue;
            DateTime endtime = DateTime.MinValue;
            if (self.InPutEndTime > DateTime.MinValue)
            {
                self.InPutEndTime = ViewRoomFeeHistoryDetail.GetFinalInputEndTime(self.InPutEndTime);
            }
            if (self.ChargeTime >= self.InPutStartTime && self.ChargeTime <= self.InPutEndTime && ViewRoomFeeHistoryDetail.IsAllowBenQi(self))
            {
                if (self.EndTime <= self.InPutEndTime)
                {
                    return 0;
                }
                if (self.StartTime > self.InPutEndTime)
                {
                    starttime = self.StartTime;
                    endtime = self.EndTime;
                }
                else if (self.StartTime <= self.InPutEndTime)
                {
                    starttime = Convert.ToDateTime(self.InPutEndTime.ToString("yyyy-MM-dd 00:00:00")).AddDays(1);
                    endtime = self.EndTime;
                }
                if (self.ImportFeeID > 0 && self.WriteDate > self.InPutEndTime)
                {
                    return RealCost;
                }
                if (starttime == DateTime.MinValue && endtime == DateTime.MinValue)
                {
                    return 0;
                }
                return ViewRoomFeeHistoryDetail.calculateTotalCost(starttime, endtime, self.StartTime, self.EndTime, RealCost, self.EndNumberCount, self.IsAnalysisQuery);
            }
            return 0;
        }
        public static decimal Get_ZhiHouShouBenqi(ViewRoomFeeHistoryDetail self)
        {
            decimal cost = self.ZhiHouShouBenqi_ShiShou + self.ZhiHouShouBenqi_ChongDi + self.ZhiHouShouBenqi_JianMian;
            return cost;
        }
        public static decimal Get_ZhiHouShouBenqiCost(ViewRoomFeeHistoryDetail self, decimal RealCost, int ChargeState)
        {
            if (RealCost <= 0 || (self.ChargeState != ChargeState && ChargeState > 0))
            {
                return 0;
            }
            if (self.IsTempFee)
            {
                if (self.InPutStartTime == DateTime.MinValue && self.InPutEndTime == DateTime.MinValue)
                {
                    return 0;
                }
                //if (this.ChargeTime > this.InPutEndTime)
                //{
                //    return RealCost;
                //}
                return 0;
            }
            if (self.InPutStartTime == DateTime.MinValue && self.InPutEndTime == DateTime.MinValue)
            {
                return 0;
            }
            DateTime starttime = DateTime.MinValue;
            DateTime endtime = DateTime.MinValue;
            ViewRoomFeeHistoryDetail.CalculateActiveTime(self, self.StartTime, self.EndTime, out starttime, out endtime);
            if (self.InPutEndTime > DateTime.MinValue)
            {
                self.InPutEndTime = ViewRoomFeeHistoryDetail.GetFinalInputEndTime(self.InPutEndTime);
            }
            if (self.ChargeTime >= self.InPutEndTime && ViewRoomFeeHistoryDetail.IsAllowBenQi(self))
            {
                if (self.ImportFeeID > 0 && self.WriteDate >= self.InPutStartTime && self.WriteDate <= self.InPutEndTime)
                {
                    return RealCost;
                }
                if (starttime == DateTime.MinValue && endtime == DateTime.MinValue)
                {
                    return 0;
                }
                return ViewRoomFeeHistoryDetail.calculateTotalCost(starttime, endtime, self.StartTime, self.EndTime, RealCost, self.EndNumberCount, self.IsAnalysisQuery);
            }
            return 0;
        }
        public static decimal Get_BenqiChongXiao(ViewRoomFeeHistoryDetail self)
        {
            decimal cost = self.BenqiChongXiao_ShiShou + self.BenqiChongXiao_ChongDi + self.BenqiChongXiao_JianMian;
            return cost;
        }
        public static decimal Get_BenqiChongXiaoCost(ViewRoomFeeHistoryDetail self, decimal RealCost, int ChargeState)
        {
            if (RealCost <= 0 || (self.ChargeState != ChargeState && ChargeState > 0))
            {
                return 0;
            }
            if (self.InPutStartTime == DateTime.MinValue && self.InPutEndTime == DateTime.MinValue)
            {
                return 0;
            }
            DateTime starttime = DateTime.MinValue;
            DateTime endtime = DateTime.MinValue;
            ViewRoomFeeHistoryDetail.CalculateActiveTime(self, self.StartTime, self.EndTime, out starttime, out endtime);
            if (starttime == DateTime.MinValue && endtime == DateTime.MinValue)
            {
                return 0;
            }
            if (self.InPutEndTime > DateTime.MinValue)
            {
                self.InPutEndTime = ViewRoomFeeHistoryDetail.GetFinalInputEndTime(self.InPutEndTime);
            }
            if (self.ChargeTime >= self.InPutStartTime && self.ChargeTime <= self.InPutEndTime)
            {
                return ViewRoomFeeHistoryDetail.calculateTotalCost(starttime, endtime, self.StartTime, self.EndTime, RealCost, self.EndNumberCount, self.IsAnalysisQuery);
            }
            return 0;
        }
    }
}
