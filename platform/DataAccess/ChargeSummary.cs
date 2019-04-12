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
    /// This object represents the properties and methods of a ChargeSummary.
    /// </summary>
    public partial class ChargeSummary : EntityBase
    {
        public static ChargeSummary GetChargeSummaryByChargeName(int ID, string Name)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (ID > 0)
            {
                conditions.Add("[ID]!=@ID");
                parameters.Add(new SqlParameter("@ID", ID));
            }
            if (!string.IsNullOrEmpty(Name))
            {
                conditions.Add("[Name]=@Name");
                parameters.Add(new SqlParameter("@Name", Name));
            }
            return GetOne<ChargeSummary>("select * from [ChargeSummary] where " + string.Join(" and ", conditions.ToArray()), parameters);
        }
        public static ChargeSummary[] GetChargeSummarysBiaoID(int BiaoID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (BiaoID > 0)
            {
                conditions.Add("[ID] in (select ChargeID from [ChargeSummary_Biao] where [ChargeBiaoID]=@BiaoID)");
                parameters.Add(new SqlParameter("@BiaoID", BiaoID));
            }
            return GetList<ChargeSummary>("select * from [ChargeSummary] where " + string.Join(" and ", conditions.ToArray()) + " order by [OrderBy]", parameters).ToArray();
        }
        public static ChargeSummary[] GetChargeSummarysByImportRoomID(int RoomID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            conditions.Add("[ID] in (select [ChargeID] from [ImportFee] where [ChargeStatus]=2 and [RoomID]=@RoomID)");
            parameters.Add(new SqlParameter("@RoomID", RoomID));
            string cmdtext = "select * from [ChargeSummary] where " + string.Join(" and ", conditions.ToArray()) + " order by [OrderBy]";
            return GetList<ChargeSummary>(cmdtext, parameters).ToArray();
        }
        public static ChargeSummary[] GetChargeSummarysByCategoryID(int CategoryID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (CategoryID > 0)
            {
                conditions.Add("[CategoryID]=@CategoryID");
                parameters.Add(new SqlParameter("@CategoryID", CategoryID));
            }
            return GetList<ChargeSummary>("select * from [ChargeSummary] where " + string.Join(" and ", conditions.ToArray()) + " order by [OrderBy]", parameters).ToArray();
        }
        public static ChargeSummary GetChargeSummaryByCategoryID(int CategoryID, SqlHelper helper)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (CategoryID > 0)
            {
                conditions.Add("[CategoryID]=@CategoryID");
                parameters.Add(new SqlParameter("@CategoryID", CategoryID));
            }
            return GetOne<ChargeSummary>("select top 1 * from [ChargeSummary] where " + string.Join(" and ", conditions.ToArray()) + " order by [OrderBy]", parameters, helper);
        }
        public static ChargeSummary[] GetAllowImportChargeSummarys(int CompanyID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[IsAllowImport]=1");
            conditions.Add("([IsReading]=0 or [IsReading] is null)");
            if (CompanyID != 1)
            {
                conditions.Add("[CompanyID]=@CompanyID");
                parameters.Add(new SqlParameter("@CompanyID", CompanyID));
            }
            return GetList<ChargeSummary>("select * from [ChargeSummary] where " + string.Join(" and ", conditions.ToArray()) + " order by [OrderBy]", parameters).ToArray();
        }
        public static ChargeSummary[] GetChargeSummaryByID(List<int> FeeTypeList, int ID, int CompanyID, int FeeType, bool IsReading, bool IsAllowImport, int CategoryID = 0)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (CategoryID > 0)
            {
                conditions.Add("[CategoryID]=@CategoryID");
                parameters.Add(new SqlParameter("@CategoryID", CategoryID));
            }
            if (IsReading)
            {
                conditions.Add("[IsReading]=1");
                conditions.Add("[FeeType]=4");
            }
            if (IsAllowImport)
            {
                conditions.Add("[IsAllowImport]=1");
                conditions.Add("[FeeType]=4");
            }
            if (FeeTypeList.Count > 0)
            {
                conditions.Add("[FeeType] in (" + string.Join(",", FeeTypeList.ToArray()) + ")");
            }
            if (ID > 0)
            {
                conditions.Add("[ID]=@ID");
                parameters.Add(new SqlParameter("@ID", ID));
            }
            if (FeeType > 0)
            {
                conditions.Add("[FeeType]=@FeeType");
                parameters.Add(new SqlParameter("@FeeType", FeeType));
            }
            if (CompanyID > 1)
            {
                conditions.Add("[CompanyID]=@CompanyID");
                parameters.Add(new SqlParameter("@CompanyID", CompanyID));
            }
            return GetList<ChargeSummary>("select * from [ChargeSummary] where " + string.Join(" and ", conditions.ToArray()) + " order by [OrderBy]", parameters).ToArray();
        }
        public static ChargeSummary[] GetChargeSummaryByID(List<int> FeeTypeList, int ID, int CompanyID, int FeeType, bool IsReading)
        {
            return GetChargeSummaryByID(FeeTypeList, ID, CompanyID, FeeType, IsReading, false);
        }
        public static ChargeSummary GetChargeSummaryByName(string Name, int CompanyID, SqlHelper helper)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (!string.IsNullOrEmpty(Name))
            {
                conditions.Add("[Name]=@Name");
                parameters.Add(new SqlParameter("@Name", Name));
            }
            if (CompanyID > 0)
            {
                conditions.Add("[CompanyID]=@CompanyID");
                parameters.Add(new SqlParameter("@CompanyID", CompanyID));
            }
            return GetOne<ChargeSummary>("select top 1 * from [ChargeSummary] where " + string.Join(" and ", conditions.ToArray()), parameters, helper);
        }
        public static ChargeSummary[] GetNoContractList(int ContractID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            string cmd = string.Empty;
            if (ContractID > 0)
            {
                parameters.Add(new SqlParameter("@ContractID", ContractID));
                cmd += " and [ID] not in (select ChargeID from [Contract_ChargeSummary] where ContractID=@ContractID)";
            }
            string sqlText = "select * from [ChargeSummary] where 1=1 " + cmd;
            return GetList<ChargeSummary>(sqlText, parameters).ToArray();
        }
        public static ChargeSummary[] GetInContractList(int ContractID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            string cmd = string.Empty;
            if (ContractID > 0)
            {
                parameters.Add(new SqlParameter("@ContractID", ContractID));
                cmd += " and [ID] in (select ChargeID from [Contract_ChargeSummary] where ContractID=@ContractID)";
            }
            string sqlText = "select * from [ChargeSummary] where 1=1 " + cmd;
            return GetList<ChargeSummary>(sqlText, parameters).ToArray();
        }
        public static ChargeSummary[] GetWeiYueSummaryList(int[] ChargeIDList)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            if (ChargeIDList.Length == 0)
            {
                return new ChargeSummary[] { };
            }
            var conditions = new List<string>();
            var sub_conditions = new List<string>();
            conditions.Add("[FeeType]=8");
            foreach (var ChargeID in ChargeIDList)
            {
                sub_conditions.Add("isnull([RelateCharges],'') like '%," + ChargeID + ",%'");
            }
            conditions.Add("(" + string.Join(" or ", sub_conditions.ToArray()) + ")");
            string sqlText = "select * from [ChargeSummary] where " + string.Join(" and ", conditions.ToArray());
            return GetList<ChargeSummary>(sqlText, parameters).ToArray();
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
                    case 7:
                        desc = "单价*计费面积(月度进位)";
                        break;
                    default:
                        break;
                }
                return desc;
            }
        }
        public string EndTypeDesc
        {
            get
            {
                string desc = string.Empty;
                switch (this.EndTypeID)
                {
                    case 1:
                        desc = "按当前自然日期";
                        break;
                    case 2:
                        desc = "按计费开始日期";
                        break;
                    default:
                        break;
                }
                return desc;
            }
        }
        public string EndNumberDesc
        {
            get
            {
                string typedesc = string.Empty;
                switch (this.EndNumber)
                {
                    case 1:
                        typedesc = "整数";
                        break;
                    case 2:
                        typedesc = "凑整";
                        break;
                    case 3:
                        typedesc = "四舍五入";
                        break;
                    default:
                        break;
                }
                return typedesc;
            }
        }
        public string FeeTypeDesc
        {
            get
            {
                if (this.FeeType == 1)
                {
                    return "周期费用";
                }
                else if (this.FeeType == 4)
                {
                    return "临时费用";
                }
                else if (this.FeeType == 8)
                {
                    return "违约金";
                }
                return string.Empty;
            }
        }
    }
    public partial class ChargeSummaryDetails : ChargeSummary
    {
        [DatabaseColumn("Cost")]
        public decimal Cost { get; set; }
        public string FormatCost
        {
            get
            {
                return Utility.Tools.FormatMoney(this.Cost);
            }
        }
        [DatabaseColumn("Discount")]
        public decimal Discount { get; set; }
        public string FormatDiscount
        {
            get
            {
                return Utility.Tools.FormatMoney(this.Discount);
            }
        }
        [DatabaseColumn("RealCost")]
        public decimal RealCost { get; set; }
        public string FormatRealCost
        {
            get
            {
                return Utility.Tools.FormatMoney(this.RealCost);
            }
        }
        [DatabaseColumn("PreTotalCost")]
        public decimal PreTotalCost { get; set; }
        public string FormatPreTotalCost
        {
            get
            {
                return Utility.Tools.FormatMoney(this.PreTotalCost);
            }
        }
        [DatabaseColumn("ChargeBackCost")]
        public decimal ChargeBackCost { get; set; }
        public string FormatChargeBackCost
        {
            get
            {
                return Utility.Tools.FormatMoney(this.ChargeBackCost);
            }
        }
        [DatabaseColumn("ChargeReturnCost")]
        public decimal ChargeReturnCost { get; set; }
        public string FormatChargeReturnCost
        {
            get
            {
                return Utility.Tools.FormatMoney(this.ChargeReturnCost);
            }
        }
        [DatabaseColumn("OwnCost")]
        public decimal OwnCost { get; set; }
        public string FormatOwnCost
        {
            get
            {
                return Utility.Tools.FormatMoney(this.OwnCost);
            }
        }
        [DatabaseColumn("AfterTotalCost")]
        public decimal AfterTotalCost { get; set; }
        public string FormatAfterTotalCost
        {
            get
            {
                return Utility.Tools.FormatMoney(this.AfterTotalCost);
            }
        }
        [DatabaseColumn("TotalNumber")]
        public int TotalNumber { get; set; }
        [DatabaseColumn("TotalCount")]
        public decimal TotalCount { get; set; }
        [DatabaseColumn("CategoryDesc")]
        public string CategoryDesc { get; set; }
        [DatabaseColumn("BuildingArea")]
        public decimal BuildingArea { get; set; }
        [DatabaseColumn("BuildOutArea")]
        public decimal BuildOutArea { get; set; }
        [DatabaseColumn("GonTanArea")]
        public decimal GonTanArea { get; set; }
        public decimal CalculateUseCount
        {
            get
            {
                decimal CalculateUseCount = 0;
                if (this.CalculateAreaType.Equals(Utility.EnumModel.ChargeSummaryCalculateAreaType.jifei.ToString()))
                {
                    CalculateUseCount = this.BuildingArea;
                }
                else if (this.CalculateAreaType.Equals(Utility.EnumModel.ChargeSummaryCalculateAreaType.jianzhu.ToString()))
                {
                    CalculateUseCount = this.BuildOutArea;
                }
                else if (this.CalculateAreaType.Equals(Utility.EnumModel.ChargeSummaryCalculateAreaType.gongtan.ToString()))
                {
                    CalculateUseCount = this.GonTanArea;
                }
                if (CalculateUseCount > 0)
                {
                    return CalculateUseCount;
                }
                return 0;
            }
        }
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
        public static Ui.DataGrid GetTotalCostSummaryGroupByChargeName(List<int> RoomIDList, DateTime StartChargeTime, DateTime EndChargeTime, int CompanyID)
        {

            List<SqlParameter> parameters = new List<SqlParameter>();
            string cmdNow = string.Empty;
            string cmdWhere = string.Empty;
            if (CompanyID != 1)
            {
                cmdWhere += " and [CompanyID]=@CompanyID";
                parameters.Add(new SqlParameter("@CompanyID", CompanyID));
            }
            if (RoomIDList.Count > 0)
            {
                cmdNow += " and [RoomID] in (" + string.Join(",", RoomIDList.ToArray()) + ")";
            }
            if (StartChargeTime > DateTime.MinValue)
            {
                cmdNow += " and Convert(nvarchar(10),[ChargeTime],120)>=@StartChargeTime";
                parameters.Add(new SqlParameter("@StartChargeTime", StartChargeTime));
            }
            if (EndChargeTime > DateTime.MinValue)
            {
                cmdNow += " and Convert(nvarchar(10),[ChargeTime],120)<=@EndChargeTime";
                parameters.Add(new SqlParameter("@EndChargeTime", EndChargeTime));
            }
            string cmdtext = @"select isnull(A.Cost,0) as Cost,isnull(B.RealCost,0) as RealCost,
isnull(C.Discount,0) as Discount, (isnull(A.Cost,0)-isnull(B.RealCost,0)-isnull(C.Discount,0)) as OwnCost,
ChargeSummary.* from ChargeSummary 
left join
(
select sum(Cost) as Cost,ChargeID from RoomFeeHistory 
where ChargeID not in (select ID from ChargeSummary where CategoryID in (3,4)) AND ChargeState in(1,4) " + cmdNow + @"
group by ChargeID
)A on A.ChargeID=ChargeSummary.ID
left join
(
select sum(RealCost) as RealCost,ChargeID from RoomFeeHistory 
where ChargeID not in (select ID from ChargeSummary where CategoryID in (3,4)) AND ChargeState in(1,4) " + cmdNow + @"
group by ChargeID
)B on B.ChargeID=ChargeSummary.ID
left join
(
select sum(Discount) as Discount,ChargeID from RoomFeeHistory 
where ChargeID not in (select ID from ChargeSummary where CategoryID in (3,4)) AND ChargeState in(1,4) " + cmdNow + @"
group by ChargeID
)C on C.ChargeID=ChargeSummary.ID where 1=1 " + cmdWhere;
            ChargeSummaryDetails[] list = GetList<ChargeSummaryDetails>(cmdtext, parameters).ToArray();
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = list.Length;
            dg.page = 1;
            return dg;
        }
        public static Ui.DataGrid GetDepositSummaryGroupByChargeName(List<int> RoomIDList, List<int> ProjectIDList, DateTime StartChargeTime, DateTime EndChargeTime, int CompanyID, string ChargeMan, int RoomFeeOrderID, int UserID = 0)
        {

            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            string cmdPre = string.Empty;
            string cmdNow = string.Empty;
            string cmdWhere = string.Empty;
            if (RoomFeeOrderID > 0)
            {
                cmdPre += " and [PrintID] in (select [ID] from [PrintRoomFeeHistory] where [RoomFeeOrderID]=@RoomFeeOrderID)";
                cmdNow += " and [PrintID] in (select [ID] from [PrintRoomFeeHistory] where [RoomFeeOrderID]=@RoomFeeOrderID)";
                parameters.Add(new SqlParameter("@RoomFeeOrderID", RoomFeeOrderID));
            }
            if (!string.IsNullOrEmpty(ChargeMan))
            {
                cmdPre += " and [ChargeMan]=@ChargeMan";
                cmdNow += " and [ChargeMan]=@ChargeMan";
                parameters.Add(new SqlParameter("@ChargeMan", ChargeMan));
            }
            if (CompanyID != 1)
            {
                cmdWhere += " and [CompanyID]=@CompanyID";
                parameters.Add(new SqlParameter("@CompanyID", CompanyID));
            }
            if (RoomIDList.Count > 0)
            {
                List<string> cmdlist = ViewRoomFeeHistory.GetRoomIDListConditions(RoomIDList, IsContractFee: true);
                cmdPre += " and (" + string.Join(" or ", cmdlist.ToArray()) + ")";
                cmdNow += " and (" + string.Join(" or ", cmdlist.ToArray()) + ")";
            }
            if (ProjectIDList.Count > 0)
            {
                List<string> cmdlist = ViewRoomFeeHistory.GetProjectIDListConditions(ProjectIDList, IsContractFee: true, UserID: UserID);
                cmdPre += " and (" + string.Join(" or ", cmdlist.ToArray()) + ")";
                cmdNow += " and (" + string.Join(" or ", cmdlist.ToArray()) + ")";
            }
            string preValue = "0";
            if (StartChargeTime > DateTime.MinValue)
            {
                cmdPre += " and Convert(nvarchar(10),[ChargeTime],120)<@StartChargeTime";
                cmdNow += " and Convert(nvarchar(10),[ChargeTime],120)>=@StartChargeTime";
                parameters.Add(new SqlParameter("@StartChargeTime", StartChargeTime));
                preValue = "(isnull(A.TotalCost,0)-isnull(B.TotalCost,0))";
            }
            if (EndChargeTime > DateTime.MinValue)
            {
                cmdNow += " and Convert(nvarchar(10),[ChargeTime],120)<=@EndChargeTime";
                parameters.Add(new SqlParameter("@EndChargeTime", EndChargeTime));
            }
            string cmdtext = @"select " + preValue + @" as PreTotalCost,
            isnull(C.TotalCost,0) as Cost,isnull(D.TotalCost,0) as ChargeBackCost,
            ChargeSummary.* from ChargeSummary 
            left join
            (
            select sum(isnull(RealCost,0)) as TotalCost,ChargeID from RoomFeeHistory 
            where ChargeID in (select ID from ChargeSummary where CategoryID=3) AND ChargeState in(1,4) " + cmdPre + @"
            group by ChargeID
            )A on A.ChargeID=ChargeSummary.ID
            left join
            (
            select sum(isnull(RealCost,0)) as TotalCost,ChargeID from RoomFeeHistory 
            where ChargeID in (select ID from ChargeSummary where CategoryID=3) AND ChargeState =3 and [ParentHistoryID] in (select [HistoryID] from [RoomFeeHistory] where [ChargeState] in(1,4))" + cmdPre + @"
            group by ChargeID
            )B on B.ChargeID=ChargeSummary.ID
            left join
            (
            select sum(isnull(RealCost,0)) as TotalCost,ChargeID from RoomFeeHistory 
            where ChargeID in (select ID from ChargeSummary where CategoryID=3) AND ChargeState in(1,4) " + cmdNow + @"
            group by ChargeID
            )C on C.ChargeID=ChargeSummary.ID
            left join
            (
            select sum(isnull(RealCost,0)) as TotalCost,ChargeID from RoomFeeHistory 
            where ChargeID in (select ID from ChargeSummary where CategoryID=3) AND ChargeState =3 and [ParentHistoryID] in (select [HistoryID] from [RoomFeeHistory] where [ChargeState] in(1,4))" + cmdNow + @"
            group by ChargeID
            )D on D.ChargeID=ChargeSummary.ID
             where 1=1 " + cmdWhere;
            ChargeSummaryDetails[] list = GetList<ChargeSummaryDetails>(cmdtext, parameters).ToArray();
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = list.Length;
            dg.page = 1;
            return dg;
        }
        public static Ui.DataGrid GetChargeSummaryGrid(int FeeType, int CategoryID, string orderBy, long startRowIndex, int pageSize, bool exclude, List<int> RoomIDs)
        {
            long totalRows = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (FeeType > 0)
            {
                conditions.Add("[FeeType]=@FeeType");
                parameters.Add(new SqlParameter("@FeeType", FeeType));
            }
            if (CategoryID > 0)
            {
                conditions.Add("[CategoryID]=@CategoryID");
                parameters.Add(new SqlParameter("@CategoryID", CategoryID));
            }
            if (exclude)
            {
                conditions.Add("[ID] not in (select [ChargeID] from [RoomFee] where RoomID in (" + string.Join(",", RoomIDs.ToArray()) + ") and [IsStart]=1)");
            }
            string fieldList = "[ChargeSummary].*,(select [Name] from [Category] where [ID]=[ChargeSummary].[CategoryID]) as CategoryDesc";
            string Statement = " from [ChargeSummary] where  " + string.Join(" and ", conditions.ToArray());
            ChargeSummaryDetails[] list = new ChargeSummaryDetails[] { };
            list = GetList<ChargeSummaryDetails>(fieldList, Statement, parameters, orderBy, startRowIndex, pageSize, out totalRows).ToArray();
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }

        public static Ui.DataGrid GetTempChargeSummaryGrid(int RoomID, string orderBy, long startRowIndex, int pageSize)
        {
            long totalRows = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[FeeType]=4");
            string fieldList = "[ChargeSummary].*,(select [Name] from [Category] where [ID]=[ChargeSummary].[CategoryID]) as CategoryDesc,(select [BuildingArea] from [RoomBasic] where [RoomID]=@RoomID) as BuildingArea,(select [BuildOutArea] from [RoomBasic] where [RoomID]=@RoomID) as BuildOutArea,(select [GonTanArea] from [RoomBasic] where [RoomID]=@RoomID) as GonTanArea";
            string Statement = " from [ChargeSummary] where  " + string.Join(" and ", conditions.ToArray());
            parameters.Add(new SqlParameter("@RoomID", RoomID));
            ChargeSummaryDetails[] list = new ChargeSummaryDetails[] { };
            list = GetList<ChargeSummaryDetails>(fieldList, Statement, parameters, orderBy, startRowIndex, pageSize, out totalRows).ToArray();
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
        public static Ui.DataGrid GetHistorySummaryGroupByChargeName(List<int> RoomIDList, List<int> ProjectIDList, DateTime StartChargeTime, DateTime EndChargeTime, int CompanyID, string ChargeMan, int ChargeSummaryID, int ChargeTypeID, int RoomFeeOrderID, List<int> ChargeStateList, int UserID = 0)
        {
            return GetHistorySummaryGroupByChargeName(RoomIDList, ProjectIDList, StartChargeTime, EndChargeTime, CompanyID, ChargeMan, ChargeSummaryID, ChargeTypeID, RoomFeeOrderID, ChargeStateList, false, UserID: UserID);
        }
        public static Ui.DataGrid GetHistorySummaryGroupByRoomFeeOrderID(int RoomFeeOrderID, List<int> ChargeStateList)
        {
            return GetHistorySummaryGroupByChargeName(new List<int>(), new List<int>(), DateTime.MinValue, DateTime.MinValue, int.MinValue, string.Empty, int.MinValue, int.MinValue, RoomFeeOrderID, ChargeStateList, true);
        }
        public static ChargeSummaryDetails[] GetHistorySummaryGroupByChargeName(List<int> RoomIDList, List<int> ProjectIDList, DateTime StartChargeTime, DateTime EndChargeTime, List<int> ChargeSummaryIDList, List<int> ChargeTypeIDList, List<int> ChargeStateList, int UserID = 0)
        {
            Ui.DataGrid dg = GetHistorySummaryGroupByChargeName(RoomIDList, ProjectIDList, StartChargeTime, EndChargeTime, 1, string.Empty, ChargeSummaryIDList, ChargeTypeIDList, 0, ChargeStateList, false, string.Empty, UserID: UserID);
            ChargeSummaryDetails[] list = dg.rows as ChargeSummaryDetails[];
            return list;
        }
        public static Ui.DataGrid GetHistorySummaryGroupByChargeName(List<int> RoomIDList, List<int> ProjectIDList, DateTime StartChargeTime, DateTime EndChargeTime, int CompanyID, string ChargeMan, int ChargeSummaryID, int ChargeTypeID, int RoomFeeOrderID, List<int> ChargeStateList, bool IsRoomFeeSearch, List<int> HistoryIDList = null, bool DeleteTempHistoryIDList = true, int UserID = 0)
        {
            List<int> ChargeSummaryIDList = new List<int>();
            if (ChargeSummaryID > 0)
            {
                ChargeSummaryIDList.Add(ChargeSummaryID);
            }
            List<int> ChargeTypeIDList = new List<int>();
            if (ChargeTypeID > -1)
            {
                ChargeTypeIDList.Add(ChargeTypeID);
            }
            return GetHistorySummaryGroupByChargeName(RoomIDList, ProjectIDList, StartChargeTime, EndChargeTime, CompanyID, ChargeMan, ChargeSummaryIDList, ChargeTypeIDList, RoomFeeOrderID, ChargeStateList, IsRoomFeeSearch, string.Empty, HistoryIDList, DeleteTempHistoryIDList: DeleteTempHistoryIDList, UserID: UserID);
        }
        public static Ui.DataGrid GetHistorySummaryGroupByChargeName(List<int> RoomIDList, List<int> ProjectIDList, DateTime StartChargeTime, DateTime EndChargeTime, int CompanyID, string ChargeMan, List<int> ChargeSummaryIDList, List<int> ChargeTypeIDList, int RoomFeeOrderID, List<int> ChargeStateList, bool IsRoomFeeSearch, string OpenID, List<int> HistoryIDList = null, bool DeleteTempHistoryIDList = true, int UserID = 0)
        {

            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (HistoryIDList != null && HistoryIDList.Count > 0)
            {
                if (HistoryIDList.Count > 2)
                {
                    ViewRoomFeeHistory.CreateTempTable(HistoryIDList, DeleteTempHistoryIDList, UserID: UserID);
                    conditions.Add("EXISTS (SELECT 1 FROM [TempIDs] WHERE id=RoomFeeHistory.HistoryID and UserID=" + UserID + ")");
                }
                else if (HistoryIDList.Count > 0)
                {
                    conditions.Add("RoomFeeHistory.HistoryID in (" + string.Join(",", HistoryIDList.ToArray()) + ")");
                }
            }
            if (!string.IsNullOrEmpty(OpenID))
            {
                conditions.Add("[RoomID] in (select [ProjectID] from [WechatUser_Project] where [OpenID]=@OpenID)");
                parameters.Add(new SqlParameter("@OpenID", OpenID));
            }
            if (ChargeStateList.Count > 0)
            {
                conditions.Add("[ChargeState] in (" + string.Join(",", ChargeStateList.ToArray()) + ")");
            }
            string cmdwhere = string.Empty;
            if (RoomFeeOrderID > 0)
            {
                conditions.Add("[PrintID] in (select [ID] from [PrintRoomFeeHistory] where isnull([RoomFeeOrderID],0)=@RoomFeeOrderID)");
                parameters.Add(new SqlParameter("@RoomFeeOrderID", RoomFeeOrderID));
            }
            else if (IsRoomFeeSearch)
            {
                conditions.Add("[PrintID] in (select [ID] from [PrintRoomFeeHistory] where isnull([RoomFeeOrderID],0)=0)");
                conditions.Add("([ChargeID] in (select [ID] from [ChargeSummary] where isnull([IsOrderFeeOn],0)=1) or isnull(ChargeID,0)=0)");
                if (StartChargeTime > DateTime.MinValue)
                {
                    conditions.Add("[ChargeTime]>=@StartChargeTime");
                    parameters.Add(new SqlParameter("@StartChargeTime", StartChargeTime));
                }
                if (EndChargeTime > DateTime.MinValue)
                {
                    conditions.Add("[ChargeTime]<=@EndChargeTime");
                    parameters.Add(new SqlParameter("@EndChargeTime", EndChargeTime));
                }
            }
            else
            {
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
            //    conditions.Add("[ChargeMan] like '%" + ChargeMan + "%'");
            //}
            if (ChargeSummaryIDList.Count > 0)
            {
                conditions.Add("[ChargeID] in (" + string.Join(",", ChargeSummaryIDList.ToArray()) + ")");
                cmdwhere += " and [ID] in (" + string.Join(",", ChargeSummaryIDList.ToArray()) + ")";
            }
            if (ChargeTypeIDList.Count > 0)
            {
                conditions.Add("[PrintID] in (select [ID] from [PrintRoomFeeHistory] where [ChageType1] in (" + string.Join(",", ChargeTypeIDList.ToArray()) + ") or [ChageType2] in (" + string.Join(",", ChargeTypeIDList.ToArray()) + "))");
            }
            if (CompanyID > 1)
            {
                cmdwhere += " and [CompanyID]=@CompanyID";
                parameters.Add(new SqlParameter("@CompanyID", CompanyID));
            }
            if (ProjectIDList.Count > 0)
            {
                List<string> cmdlist = ViewRoomFeeHistory.GetProjectIDListConditions(ProjectIDList, IsContractFee: true, UserID: UserID);
                conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
            }
            if (RoomIDList.Count > 0)
            {
                List<string> cmdlist = ViewRoomFeeHistory.GetRoomIDListConditions(RoomIDList, IsContractFee: true);
                conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
            }
            string cmdtext = @" select cs.*,(c.RealCost+B.Discount) as Cost,B.Discount,c.RealCost,D.TotalNumber,E.TotalCount from ChargeSummary cs
left join
(
select sum(isnull(Discount,0)) as Discount,ChargeID from RoomFeeHistory 
where " + string.Join(" and ", conditions.ToArray()) + cmd + @"
Group by ChargeID
) B on B.ChargeID=cs.ID
left join
(
select sum(isnull(RealCost,0)) as RealCost,ChargeID from RoomFeeHistory 
where " + string.Join(" and ", conditions.ToArray()) + cmd + @"
Group by ChargeID
) C on C.ChargeID=cs.ID 
left join
(
select count(1) as TotalNumber,ChargeID from RoomFeeHistory 
where " + string.Join(" and ", conditions.ToArray()) + cmd + @"
Group by ChargeID
) D on D.ChargeID=cs.ID 
left join
(
select sum(isnull(UseCount,0)) as TotalCount,ChargeID from RoomFeeHistory 
where " + string.Join(" and ", conditions.ToArray()) + cmd + @"
Group by ChargeID
) E on E.ChargeID=cs.ID where 1=1 " + cmdwhere;

            ChargeSummaryDetails[] list = GetList<ChargeSummaryDetails>(cmdtext, parameters).ToArray();
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = list.Length;
            dg.page = 1;
            return dg;
        }
        public static ChargeSummaryDetails[] GetChargeSummaryByCompanyID(int CompanyID, int[] IDList)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (CompanyID != 1)
            {
                conditions.Add("[CompanyID]=@CompanyID");
                parameters.Add(new SqlParameter("@CompanyID", CompanyID));
            }
            if (IDList.Length > 0)
            {
                conditions.Add("[ID] in (" + string.Join(",", IDList) + ")");
            }
            return GetList<ChargeSummaryDetails>("select * from [ChargeSummary] where " + string.Join(" and ", conditions.ToArray()) + " order by [OrderBy]", parameters).ToArray();
        }
    }
    public partial class ChargeSummaryDepositChargeAnalysis : EntityBaseReadOnly
    {
        [DatabaseColumn("state")]
        public string state { get; set; }
        [DatabaseColumn("id")]
        public string id { get; set; }
        [DatabaseColumn("_parentId")]
        public string _parentId { get; set; }
        [DatabaseColumn("RoomID")]
        public int RoomID { get; set; }
        [DatabaseColumn("RoomName")]
        public string RoomName { get; set; }
        [DatabaseColumn("FullName")]
        public string FullName { get; set; }
        [DatabaseColumn("DefaultOrder")]
        public string DefaultOrder { get; set; }
        [DatabaseColumn("Cost")]
        public decimal Cost { get; set; }
        public string FormatCost
        {
            get
            {
                return Utility.Tools.FormatMoney(this.Cost);
            }
        }
        [DatabaseColumn("ChargeReturnCost")]
        public decimal ChargeReturnCost { get; set; }
        public string FormatChargeReturnCost
        {
            get
            {
                return Utility.Tools.FormatMoney(this.ChargeReturnCost);
            }
        }
        [DatabaseColumn("PreTotalCost")]
        public decimal PreTotalCost { get; set; }
        public string FormatPreTotalCost
        {
            get
            {
                return Utility.Tools.FormatMoney(this.PreTotalCost);
            }
        }
        [DatabaseColumn("ChargeBackCost")]
        public decimal ChargeBackCost { get; set; }
        public string FormatChargeBackCost
        {
            get
            {
                return Utility.Tools.FormatMoney(this.ChargeBackCost);
            }
        }
        [DatabaseColumn("AfterTotalCost")]
        public decimal AfterTotalCost { get; set; }
        public string FormatAfterTotalCost
        {
            get
            {
                return Utility.Tools.FormatMoney(this.AfterTotalCost);
            }
        }
        [DatabaseColumn("Name")]
        public string Name { get; set; }
        protected override void EnsureParentProperties()
        {
        }
        public static Ui.DataGrid GetDepositChargeSummaryGroupByRoom(List<int> ProjectIDList, List<int> RoomIDList, DateTime StartChargeTime, DateTime EndChargeTime, int CompanyID, List<int> ChargeIDList, string orderBy, long startRowIndex, int pageSize, int UserID = 0, bool canexport = false)
        {

            List<SqlParameter> parameters = new List<SqlParameter>();
            string cmdNow = string.Empty;
            string cmdWhere = string.Empty;
            #region conditions
            if (ChargeIDList.Count > 0)
            {
                cmdNow += " and [ChargeID] in (" + string.Join(",", ChargeIDList.ToArray()) + ")";
            }
            if (ProjectIDList.Count > 0)
            {
                List<string> cmdlist1 = ViewRoomFeeHistory.GetProjectIDListConditions(ProjectIDList, IsContractFee: true, UserID: UserID);
                List<string> cmdlist2 = ViewRoomFeeHistory.GetProjectIDListConditions(ProjectIDList, RoomIDName: "[ID]", UserID: UserID);
                cmdNow += " and (" + string.Join(" or ", cmdlist1.ToArray()) + ")";
                cmdWhere += " and (" + string.Join(" or ", cmdlist2.ToArray()) + ")";
            }
            if (RoomIDList.Count > 0)
            {
                List<string> cmdlist = ViewRoomFeeHistory.GetRoomIDListConditions(RoomIDList, IsContractFee: true);
                cmdNow += " and (" + string.Join(" or ", cmdlist.ToArray()) + ")";
            }
            string cmdPreTotalCost = "0 as QiChiCost, 0 as QiChiChargeReturnCost";
            if (StartChargeTime > DateTime.MinValue)
            {
                parameters.Add(new SqlParameter("@StartChargeTime", StartChargeTime));
                cmdPreTotalCost = @"(select sum(isnull(RealCost,0)) as [Cost] from [RoomFeeHistory] 
where ChargeID in (SELECT ID FROM  dbo.ChargeSummary where  CategoryID = 3) and ChargeState = 1 and RoomID=A.ID " + cmdNow + @" and Convert(nvarchar(10),[ChargeTime],120)<@StartChargeTime) as QiChiCost,
(select sum(isnull(RealCost,0)) as [Cost] from [RoomFeeHistory] 
where ChargeID in (SELECT ID FROM  dbo.ChargeSummary where  CategoryID = 3) and ChargeState =3 and RoomID=A.ID " + cmdNow + @" and Convert(nvarchar(10),[ChargeTime],120)<@StartChargeTime) as QiChiChargeReturnCost";
                cmdNow += " and Convert(nvarchar(10),[ChargeTime],120)>=@StartChargeTime";
            }
            if (EndChargeTime > DateTime.MinValue)
            {
                parameters.Add(new SqlParameter("@EndChargeTime", EndChargeTime));
                cmdNow += " and Convert(nvarchar(10),[ChargeTime],120)<=@EndChargeTime";
            }
            #endregion
            string Statement = @"from (select B.*,(isnull(B.QiChiCost,0)-isnull(B.QiChiChargeReturnCost,0)) as PreTotalCost from (select 'closed' as state,'Room_'+CONVERT(nvarchar(100), A.ID) as id,'' as _parentId, A.ID as RoomID,A.Name as RoomName,'所有费项之和' as Name,A.FullName,A.DefaultOrder,
(select sum(isnull(RealCost,0)) as [Cost] from [RoomFeeHistory] 
where ChargeID in (SELECT ID FROM  dbo.ChargeSummary where  CategoryID = 3) and ChargeState = 1 and RoomID =A.ID " + cmdNow + @") as Cost,
(select sum(isnull(RealCost,0)) as [Cost] from [RoomFeeHistory] 
where ChargeID in (SELECT ID FROM  dbo.ChargeSummary where  CategoryID = 3) and ChargeState = 3 and RoomID =A.ID " + cmdNow + @") as ChargeReturnCost," + cmdPreTotalCost + @"
from (select * from Project where isnull(isParent,1)=0 " + cmdWhere + ")A)B)C where isnull([PreTotalCost],0)>0 or isnull([Cost],0)>0 or isnull([ChargeReturnCost],0)>0";
            long totalRows = 0;
            ChargeSummaryDepositChargeAnalysis[] list = GetList<ChargeSummaryDepositChargeAnalysis>("C.*,(isnull(C.PreTotalCost,0)+isnull(C.Cost,0)-isnull(C.ChargeReturnCost,0)) as AfterTotalCost", Statement, parameters, orderBy, startRowIndex, pageSize, out totalRows).ToArray();
            if (canexport)
            {
                list = GetList<ChargeSummaryDepositChargeAnalysis>("select C.*,(isnull(C.PreTotalCost,0)+isnull(C.Cost,0)-isnull(C.ChargeReturnCost,0)) as AfterTotalCost " + Statement + " " + orderBy, parameters).ToArray();
                totalRows = list.Length;
            }
            else
            {
                list = GetList<ChargeSummaryDepositChargeAnalysis>("C.*,(isnull(C.PreTotalCost,0)+isnull(C.Cost,0)-isnull(C.ChargeReturnCost,0)) as AfterTotalCost", Statement, parameters, orderBy, startRowIndex, pageSize, out totalRows).ToArray();
            }
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
        public static Ui.DataGrid GetDepositChargeSummaryGroupByProject(List<int> ProjectIDList, List<int> RoomIDList, DateTime StartChargeTime, DateTime EndChargeTime, int CompanyID, List<int> ChargeIDList, string orderBy, long startRowIndex, int pageSize, int UserID = 0, bool canexport = false)
        {

            List<SqlParameter> parameters = new List<SqlParameter>();
            string cmdNow = string.Empty;
            string cmdWhere = string.Empty;
            #region conditions
            if (ChargeIDList.Count > 0)
            {
                cmdNow += " and [ChargeID] in (" + string.Join(",", ChargeIDList.ToArray()) + ")";
            }
            if (ProjectIDList.Count > 0)
            {
                List<string> cmdlist = ViewRoomFeeHistory.GetProjectIDListConditions(ProjectIDList, IsContractFee: true, UserID: UserID);
                cmdNow += " and (" + string.Join(" or ", cmdlist.ToArray()) + ")";
                cmdWhere += " and [ID] in (" + string.Join(",", ProjectIDList.ToArray()) + ")";
            }
            if (RoomIDList.Count > 0)
            {
                List<string> cmdlist = ViewRoomFeeHistory.GetRoomIDListConditions(RoomIDList, IsContractFee: true);
                cmdNow += " and (" + string.Join(" or ", cmdlist.ToArray()) + ")";
            }
            string cmdPreTotalCost = "0 as QiChiCost, 0 as QiChiChargeReturnCost";
            if (StartChargeTime > DateTime.MinValue)
            {
                parameters.Add(new SqlParameter("@StartChargeTime", StartChargeTime));
                cmdPreTotalCost = @"(select sum(isnull(RealCost,0)) as [Cost] from [RoomFeeHistory] 
                where ChargeID in (SELECT ID FROM  dbo.ChargeSummary where  CategoryID = 3) and ChargeState = 1 and RoomID in (select [ID]
                from [Project] where [AllParentID] like '%,'+ CONVERT(nvarchar(200), A.ID)+',%'
                ) " + cmdNow + @" and Convert(nvarchar(10),[ChargeTime],120)<@StartChargeTime) as QiChiCost,
                (select sum(isnull(RealCost,0)) as [Cost] from [RoomFeeHistory] 
                where ChargeID in (SELECT ID FROM  dbo.ChargeSummary where  CategoryID = 3) and ChargeState = 3 and RoomID in (select [ID]
                from [Project] where [AllParentID] like '%,'+ CONVERT(nvarchar(200), A.ID)+',%'
                ) " + cmdNow + @" and Convert(nvarchar(10),[ChargeTime],120)<@StartChargeTime) as QiChiChargeReturnCost";
                cmdNow += " and Convert(nvarchar(10),[ChargeTime],120)>=@StartChargeTime";
            }
            if (EndChargeTime > DateTime.MinValue)
            {
                cmdNow += " and Convert(nvarchar(10),[ChargeTime],120)<=@EndChargeTime";
                parameters.Add(new SqlParameter("@EndChargeTime", EndChargeTime));
            }
            #endregion
            string Statement = @"from (select B.*,(isnull(B.QiChiCost,0)-isnull(B.QiChiChargeReturnCost,0)) as PreTotalCost from (select 'closed' as state,'Room_'+CONVERT(nvarchar(100), A.ID) as id,'' as _parentId, A.ID as RoomID,'' as RoomName,'所有费项之和' as Name,A.FullName,A.DefaultOrder,
                (select sum(isnull(RealCost,0)) as [Cost] from [RoomFeeHistory] 
                where ChargeID in (SELECT ID FROM  dbo.ChargeSummary where  CategoryID = 3) and ChargeState = 1 and RoomID in (select [ID]
                from [Project] where [AllParentID] like '%,'+ CONVERT(nvarchar(200), A.ID)+',%'
                ) " + cmdNow + @") as Cost,
                (select sum(isnull(RealCost,0)) as [Cost] from [RoomFeeHistory] 
                where ChargeID in (SELECT ID FROM  dbo.ChargeSummary where  CategoryID = 3) and ChargeState = 3 and RoomID in (select [ID]
                from [Project] where [AllParentID] like '%,'+ CONVERT(nvarchar(200), A.ID)+',%'
                ) " + cmdNow + @") as ChargeReturnCost," + cmdPreTotalCost + @"
                from (select * from Project where isnull(ParentID,0)=1 " + cmdWhere + ")A)B)C where isnull([PreTotalCost],0)>0 or isnull([Cost],0)>0 or isnull([ChargeReturnCost],0)>0";
            long totalRows = 0;
            ChargeSummaryDepositChargeAnalysis[] list = new ChargeSummaryDepositChargeAnalysis[] { };
            if (canexport)
            {
                list = GetList<ChargeSummaryDepositChargeAnalysis>("select C.*,(isnull(C.PreTotalCost,0)+isnull(C.Cost,0)-isnull(C.ChargeReturnCost,0)) as AfterTotalCost " + Statement + " " + orderBy, parameters).ToArray();
                totalRows = list.Length;
            }
            else
            {
                list = GetList<ChargeSummaryDepositChargeAnalysis>("C.*,(isnull(C.PreTotalCost,0)+isnull(C.Cost,0)-isnull(C.ChargeReturnCost,0)) as AfterTotalCost", Statement, parameters, orderBy, startRowIndex, pageSize, out totalRows).ToArray();
            }
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
        public static Ui.DataGrid GetDepositChargeSummaryGroupByChargeName(List<int> ProjectIDList, List<int> RoomIDList, DateTime StartChargeTime, DateTime EndChargeTime, int CompanyID, List<int> ChargeIDList, int RoomID, int UserID = 0, bool canexport = false)
        {

            List<SqlParameter> parameters = new List<SqlParameter>();
            string cmdNow = string.Empty;
            string cmdWhere = string.Empty;
            if (ChargeIDList.Count > 0)
            {
                cmdNow += " and [ChargeID] in (" + string.Join(",", ChargeIDList.ToArray()) + ")";
                cmdWhere += " and [ID] in (" + string.Join(",", ChargeIDList.ToArray()) + ")";
            }
            if (CompanyID != 1)
            {
                cmdWhere += " and [CompanyID]=@CompanyID";
                parameters.Add(new SqlParameter("@CompanyID", CompanyID));
            }
            if (RoomIDList.Count > 0)
            {
                List<string> cmdlist = ViewRoomFeeHistory.GetRoomIDListConditions(RoomIDList, IsContractFee: true);
                cmdNow += " and (" + string.Join(" or ", cmdlist.ToArray()) + ")";
            }
            if (ProjectIDList.Count > 0)
            {
                List<string> cmdlist = ViewRoomFeeHistory.GetProjectIDListConditions(ProjectIDList, IsContractFee: true, UserID: UserID);
                cmdNow += " and (" + string.Join(" or ", cmdlist.ToArray()) + ")";
            }
            string parentid = string.Empty;
            if (RoomID > 0)
            {
                parentid = "Room_" + RoomID;
                cmdNow += " and ([RoomID] in (select ID from [Project] where [AllParentID] like '%," + RoomID + ",%' or [ID] =" + RoomID + "))";
            }
            else
            {
                RoomID = 0;
            }
            string cmdPreTotalCost = "0 as QiChiCost, 0 as QiChiChargeReturnCost";
            if (StartChargeTime > DateTime.MinValue)
            {
                parameters.Add(new SqlParameter("@StartChargeTime", StartChargeTime));
                cmdPreTotalCost = @"(select sum(isnull(RealCost,0)) as [Cost] from [RoomFeeHistory] 
where ChargeID in (SELECT ID FROM  dbo.ChargeSummary where  CategoryID = 3) and ChargeID=ChargeSummary.ID and ChargeState = 1 " + cmdNow + @" and Convert(nvarchar(10),[ChargeTime],120)<@StartChargeTime) as QiChiCost,
(select sum(isnull(RealCost,0)) as [Cost] from [RoomFeeHistory] 
where ChargeID in (SELECT ID FROM  dbo.ChargeSummary where CategoryID = 3) and ChargeID=ChargeSummary.ID and ChargeState = 3 " + cmdNow + @" and Convert(nvarchar(10),[ChargeTime],120)<@StartChargeTime) as QiChiChargeReturnCost";
                cmdNow += " and Convert(nvarchar(10),[ChargeTime],120)>=@StartChargeTime";
            }
            if (EndChargeTime > DateTime.MinValue)
            {
                cmdNow += " and Convert(nvarchar(10),[ChargeTime],120)<=@EndChargeTime";
                parameters.Add(new SqlParameter("@EndChargeTime", EndChargeTime));
            }

            string cmdtext = @"select B.*,(isnull(B.PreTotalCost,0)+isnull(B.Cost,0)-isnull(B.ChargeReturnCost,0)) as AfterTotalCost from (select A.*,(isnull(A.QiChiCost,0)-isnull(A.QiChiChargeReturnCost,0)) as PreTotalCost from (select '' as state,'Charge_" + RoomID + "_'+CONVERT(nvarchar(100), ChargeSummary.ID) as id,'" + parentid + @"' as _parentId, " + RoomID + @" as RoomID,'' as RoomName,ChargeSummary.Name,'' as FullName,'' as DefaultOrder, 
(select sum(RealCost) as Cost from RoomFeeHistory where  ChargeState = 1 and ChargeID =ChargeSummary.ID " + cmdNow + @") 
as Cost,
(SELECT SUM(RealCost) as Cost from RoomFeeHistory where ChargeState = 3 and ChargeID in (SELECT ID FROM  dbo.ChargeSummary where CategoryID = 3) and ChargeID=ChargeSummary.ID " + cmdNow + @")
as ChargeReturnCost," + cmdPreTotalCost + @"
from ChargeSummary where  CategoryID = 3 " + cmdWhere + ")A)B";
            ChargeSummaryDepositChargeAnalysis[] list = GetList<ChargeSummaryDepositChargeAnalysis>(cmdtext, parameters).ToArray();
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = list.Length;
            dg.page = 1;
            return dg;
        }
    }
    public partial class ChargeSummaryPreChargeAnalysis : EntityBaseReadOnly
    {
        [DatabaseColumn("state")]
        public string state { get; set; }
        [DatabaseColumn("id")]
        public string id { get; set; }
        [DatabaseColumn("_parentId")]
        public string _parentId { get; set; }
        [DatabaseColumn("RoomID")]
        public int RoomID { get; set; }
        [DatabaseColumn("RoomName")]
        public string RoomName { get; set; }
        [DatabaseColumn("FullName")]
        public string FullName { get; set; }
        [DatabaseColumn("DefaultOrder")]
        public string DefaultOrder { get; set; }
        [DatabaseColumn("Cost")]
        public decimal Cost { get; set; }
        public string FormatCost
        {
            get
            {
                return Utility.Tools.FormatMoney(this.Cost);
            }
        }
        [DatabaseColumn("ChargeBackCost")]
        public decimal ChargeBackCost { get; set; }
        public string FormatChargeBackCost
        {
            get
            {
                return Utility.Tools.FormatMoney(this.ChargeBackCost);
            }
        }
        [DatabaseColumn("ChargeReturnCost")]
        public decimal ChargeReturnCost { get; set; }
        public string FormatChargeReturnCost
        {
            get
            {
                return Utility.Tools.FormatMoney(this.ChargeReturnCost);
            }
        }
        [DatabaseColumn("PreTotalCost")]
        public decimal PreTotalCost { get; set; }
        public string FormatPreTotalCost
        {
            get
            {
                return Utility.Tools.FormatMoney(this.PreTotalCost);
            }
        }
        [DatabaseColumn("AfterTotalCost")]
        public decimal AfterTotalCost { get; set; }
        public string FormatAfterTotalCost
        {
            get
            {
                return Utility.Tools.FormatMoney(this.AfterTotalCost);
            }
        }
        [DatabaseColumn("Name")]
        public string Name { get; set; }
        protected override void EnsureParentProperties()
        {
        }
        public static Ui.DataGrid GetPreChargeSummaryGroupByRoom(List<int> ProjectIDList, List<int> RoomIDList, DateTime StartChargeTime, DateTime EndChargeTime, int CompanyID, List<int> ChargeIDList, string orderBy, long startRowIndex, int pageSize, int UserID = 0, bool canexport = false)
        {

            List<SqlParameter> parameters = new List<SqlParameter>();
            string cmd_chongdi = string.Empty;
            string cmdNow = string.Empty;
            string cmdWhere = string.Empty;
            #region conditions
            if (ChargeIDList.Count > 0)
            {
                cmdNow += " and [ChargeID] in (" + string.Join(",", ChargeIDList.ToArray()) + ")";
                cmd_chongdi += " and [ChongDiChargeID] in (" + string.Join(",", ChargeIDList.ToArray()) + ")";
            }
            if (ProjectIDList.Count > 0)
            {
                List<string> cmdlist1 = ViewRoomFeeHistory.GetProjectIDListConditions(ProjectIDList, IsContractFee: true, UserID: UserID);
                List<string> cmdlist2 = ViewRoomFeeHistory.GetProjectIDListConditions(ProjectIDList, RoomIDName: "[ID]", UserID: UserID);
                cmdNow += " and (" + string.Join(" or ", cmdlist1.ToArray()) + ")";
                cmdWhere += " and (" + string.Join(" or ", cmdlist2.ToArray()) + ")";
                cmd_chongdi += " and (" + string.Join(" or ", cmdlist1.ToArray()) + ")";
            }
            if (RoomIDList.Count > 0)
            {
                List<string> cmdlist = ViewRoomFeeHistory.GetRoomIDListConditions(RoomIDList, IsContractFee: true);
                cmdNow += " and (" + string.Join(" or ", cmdlist.ToArray()) + ")";
                cmd_chongdi += " and (" + string.Join(" or ", cmdlist.ToArray()) + ")";
            }
            string cmdPreTotalCost = "0 as QiChiCost,0 as QiChiChargeBackCost, 0 as QiChiChargeReturnCost";
            if (StartChargeTime > DateTime.MinValue)
            {
                parameters.Add(new SqlParameter("@StartChargeTime", StartChargeTime));
                cmdPreTotalCost = @"(select sum(isnull(RealCost,0)) as [Cost] from [RoomFeeHistory] 
where ChargeID in (SELECT ID FROM  dbo.ChargeSummary where  CategoryID = 4) and ChargeState = 1 and RoomID=A.ID " + cmdNow + @" and Convert(nvarchar(10),[ChargeTime],120)<@StartChargeTime) as QiChiCost,
(select sum(isnull(RealCost,0)) as [Cost] from [RoomFeeHistory] 
where ChargeState = 4 and RoomID=A.ID " + cmd_chongdi + @" and Convert(nvarchar(10),[ChargeTime],120)<@StartChargeTime) as QiChiChargeBackCost,
(select sum(isnull(RealCost,0)) as [Cost] from [RoomFeeHistory] 
where ChargeID in (SELECT ID FROM  dbo.ChargeSummary where  CategoryID = 4) and ChargeState = 6 and RoomID=A.ID " + cmdNow + @" and Convert(nvarchar(10),[ChargeTime],120)<@StartChargeTime) as QiChiChargeReturnCost";
                cmdNow += " and Convert(nvarchar(10),[ChargeTime],120)>=@StartChargeTime";
            }
            if (EndChargeTime > DateTime.MinValue)
            {
                parameters.Add(new SqlParameter("@EndChargeTime", EndChargeTime));
                cmdNow += " and Convert(nvarchar(10),[ChargeTime],120)<=@EndChargeTime";
            }
            #endregion
            string Statement = @"from (select B.*,(isnull(B.QiChiCost,0)-isnull(B.QiChiChargeBackCost,0)-isnull(B.QiChiChargeReturnCost,0)) as PreTotalCost from (select 'closed' as state,'Room_'+CONVERT(nvarchar(100), A.ID) as id,'' as _parentId, A.ID as RoomID,A.Name as RoomName,'所有费项之和' as Name,A.FullName,A.DefaultOrder,
(select sum(isnull(RealCost,0)) as [Cost] from [RoomFeeHistory] 
where ChargeID in (SELECT ID FROM  dbo.ChargeSummary where  CategoryID = 4) and ChargeState = 1 and RoomID =A.ID " + cmdNow + @") as Cost,
(select sum(isnull(RealCost,0)) as [Cost] from [RoomFeeHistory] 
where ChargeState = 4 and RoomID =A.ID " + cmd_chongdi + @") as ChargeBackCost,
(select sum(isnull(RealCost,0)) as [Cost] from [RoomFeeHistory] 
where ChargeID in (SELECT ID FROM  dbo.ChargeSummary where  CategoryID = 4) and ChargeState = 6 and RoomID =A.ID " + cmdNow + @") as ChargeReturnCost," + cmdPreTotalCost + @"
from (select * from Project where isnull(isParent,1)=0 " + cmdWhere + ")A)B)C where isnull([PreTotalCost],0)>0 or isnull([Cost],0)>0 or isnull([ChargeBackCost],0)>0 or isnull([ChargeReturnCost],0)>0";
            long totalRows = 0;
            ChargeSummaryPreChargeAnalysis[] list = new ChargeSummaryPreChargeAnalysis[] { };
            if (canexport)
            {
                list = GetList<ChargeSummaryPreChargeAnalysis>("select C.*,(isnull(C.PreTotalCost,0)+isnull(C.Cost,0)-isnull(C.ChargeBackCost,0)-isnull(C.ChargeReturnCost,0)) as AfterTotalCost " + Statement + " " + orderBy, parameters).ToArray();
                totalRows = list.Length;
            }
            else
            {
                list = GetList<ChargeSummaryPreChargeAnalysis>("C.*,(isnull(C.PreTotalCost,0)+isnull(C.Cost,0)-isnull(C.ChargeBackCost,0)-isnull(C.ChargeReturnCost,0)) as AfterTotalCost", Statement, parameters, orderBy, startRowIndex, pageSize, out totalRows).ToArray();
            }
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
        public static Ui.DataGrid GetPreChargeSummaryGroupByProject(List<int> ProjectIDList, List<int> RoomIDList, DateTime StartChargeTime, DateTime EndChargeTime, int CompanyID, List<int> ChargeIDList, string orderBy, long startRowIndex, int pageSize, int UserID = 0, bool canexport = false)
        {

            List<SqlParameter> parameters = new List<SqlParameter>();
            string cmd_chongdi = string.Empty;
            string cmdNow = string.Empty;
            string cmdWhere = string.Empty;
            #region conditions
            if (ChargeIDList.Count > 0)
            {
                cmdNow += " and [ChargeID] in (" + string.Join(",", ChargeIDList.ToArray()) + ")";
                cmd_chongdi += " and [ChongDiChargeID] in (" + string.Join(",", ChargeIDList.ToArray()) + ")";
            }
            if (ProjectIDList.Count > 0)
            {
                List<string> cmdlist1 = ViewRoomFeeHistory.GetProjectIDListConditions(ProjectIDList, IsContractFee: true, UserID: UserID);
                List<string> cmdlist2 = ViewRoomFeeHistory.GetProjectIDListConditions(ProjectIDList, RoomIDName: "[ID]", UserID: UserID);
                cmdNow += " and (" + string.Join(" or ", cmdlist1.ToArray()) + ")";
                cmdWhere += " and (" + string.Join(" or ", cmdlist2.ToArray()) + ")";
                cmd_chongdi += " and (" + string.Join(" or ", cmdlist1.ToArray()) + ")";
            }
            if (RoomIDList.Count > 0)
            {
                List<string> cmdlist = ViewRoomFeeHistory.GetRoomIDListConditions(RoomIDList, IsContractFee: true);
                cmdNow += " and (" + string.Join(" or ", cmdlist.ToArray()) + ")";
                cmd_chongdi += " and (" + string.Join(" or ", cmdlist.ToArray()) + ")";
            }
            string cmdPreTotalCost = "0 as QiChiCost,0 as QiChiChargeBackCost, 0 as QiChiChargeReturnCost";
            if (StartChargeTime > DateTime.MinValue)
            {
                parameters.Add(new SqlParameter("@StartChargeTime", StartChargeTime));
                cmdPreTotalCost = @"(select sum(isnull(RealCost,0)) as [Cost] from [RoomFeeHistory] 
where ChargeID in (SELECT ID FROM  dbo.ChargeSummary where  CategoryID = 4) and ChargeState = 1 and RoomID in (select [ID]
from [Project] where [AllParentID] like '%,'+ CONVERT(nvarchar(200), A.ID)+',%'
) " + cmdNow + @" and Convert(nvarchar(10),[ChargeTime],120)<@StartChargeTime) as QiChiCost,
(select sum(isnull(RealCost,0)) as [Cost] from [RoomFeeHistory] 
where ChargeState = 4 and RoomID in (select [ID]
from [Project] where [AllParentID] like '%,'+ CONVERT(nvarchar(200), A.ID)+',%'
) " + cmd_chongdi + @" and Convert(nvarchar(10),[ChargeTime],120)<@StartChargeTime) as QiChiChargeBackCost,
(select sum(isnull(RealCost,0)) as [Cost] from [RoomFeeHistory] 
where ChargeID in (SELECT ID FROM  dbo.ChargeSummary where  CategoryID = 4) and ChargeState = 6 and RoomID in (select [ID]
from [Project] where [AllParentID] like '%,'+ CONVERT(nvarchar(200), A.ID)+',%'
) " + cmdNow + @" and Convert(nvarchar(10),[ChargeTime],120)<@StartChargeTime) as QiChiChargeReturnCost";
                cmdNow += " and Convert(nvarchar(10),[ChargeTime],120)>=@StartChargeTime";
            }
            if (EndChargeTime > DateTime.MinValue)
            {
                cmdNow += " and Convert(nvarchar(10),[ChargeTime],120)<=@EndChargeTime";
                parameters.Add(new SqlParameter("@EndChargeTime", EndChargeTime));
            }
            #endregion
            string Statement = @"from (select B.*,(isnull(B.QiChiCost,0)-isnull(B.QiChiChargeBackCost,0)-isnull(B.QiChiChargeReturnCost,0)) as PreTotalCost from (select 'closed' as state,'Room_'+CONVERT(nvarchar(100), A.ID) as id,'' as _parentId, A.ID as RoomID,'' as RoomName,'所有费项之和' as Name,A.FullName,A.DefaultOrder,
(select sum(isnull(RealCost,0)) as [Cost] from [RoomFeeHistory] 
where ChargeID in (SELECT ID FROM  dbo.ChargeSummary where  CategoryID = 4) and ChargeState = 1 and RoomID in (select [ID]
from [Project] where [AllParentID] like '%,'+ CONVERT(nvarchar(200), A.ID)+',%'
) " + cmdNow + @") as Cost,
(select sum(isnull(RealCost,0)) as [Cost] from [RoomFeeHistory] 
where ChargeState = 4 and RoomID in (select [ID]
from [Project] where [AllParentID] like '%,'+ CONVERT(nvarchar(200), A.ID)+',%'
) " + cmd_chongdi + @") as ChargeBackCost,
(select sum(isnull(RealCost,0)) as [Cost] from [RoomFeeHistory] 
where ChargeID in (SELECT ID FROM  dbo.ChargeSummary where  CategoryID = 4) and ChargeState = 6 and RoomID in (select [ID]
from [Project] where [AllParentID] like '%,'+ CONVERT(nvarchar(200), A.ID)+',%'
) " + cmdNow + @") as ChargeReturnCost," + cmdPreTotalCost + @"
from (select * from Project where isnull(ParentID,0)=1)A)B)C where isnull([PreTotalCost],0)>0 or isnull([Cost],0)>0 or isnull([ChargeBackCost],0)>0 or isnull([ChargeReturnCost],0)>0";
            long totalRows = 0;
            ChargeSummaryPreChargeAnalysis[] list = new ChargeSummaryPreChargeAnalysis[] { };
            if (canexport)
            {
                list = GetList<ChargeSummaryPreChargeAnalysis>("select C.*,(isnull(C.PreTotalCost,0)+isnull(C.Cost,0)-isnull(C.ChargeBackCost,0)-isnull(C.ChargeReturnCost,0)) as AfterTotalCost " + Statement + " " + orderBy, parameters).ToArray();
                totalRows = list.Length;
            }
            else
            {
                list = GetList<ChargeSummaryPreChargeAnalysis>("C.*,(isnull(C.PreTotalCost,0)+isnull(C.Cost,0)-isnull(C.ChargeBackCost,0)-isnull(C.ChargeReturnCost,0)) as AfterTotalCost", Statement, parameters, orderBy, startRowIndex, pageSize, out totalRows).ToArray();
            }
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
        public static Ui.DataGrid GetPreChargeSummaryGroupByChargeName(List<int> ProjectIDList, List<int> RoomIDList, DateTime StartChargeTime, DateTime EndChargeTime, int CompanyID, List<int> ChargeIDList, int RoomID)
        {

            List<SqlParameter> parameters = new List<SqlParameter>();
            string cmd_chongdi = string.Empty;
            string cmdNow = string.Empty;
            string cmdWhere = string.Empty;
            if (ChargeIDList.Count > 0)
            {
                cmdNow += " and [ChargeID] in (" + string.Join(",", ChargeIDList.ToArray()) + ")";
                cmdWhere += " and [ID] in (" + string.Join(",", ChargeIDList.ToArray()) + ")";
                cmd_chongdi += " and [ChongDiChargeID] in (" + string.Join(",", ChargeIDList.ToArray()) + ")";
            }
            if (CompanyID != 1)
            {
                cmdWhere += " and [CompanyID]=@CompanyID";
                parameters.Add(new SqlParameter("@CompanyID", CompanyID));
            }
            if (RoomIDList.Count > 0)
            {
                List<string> cmdlist = ViewRoomFeeHistory.GetRoomIDListConditions(RoomIDList, IsContractFee: true);
                cmdNow += " and (" + string.Join(" or ", cmdlist.ToArray()) + ")";
                cmd_chongdi += " and (" + string.Join(" or ", cmdlist.ToArray()) + ")";
            }
            if (ProjectIDList.Count > 0)
            {
                List<string> cmdlist = ViewRoomFeeHistory.GetProjectIDListConditions(ProjectIDList, IsContractFee: true);
                cmdNow += " and (" + string.Join(" or ", cmdlist.ToArray()) + ")";
                cmd_chongdi += " and (" + string.Join(" or ", cmdlist.ToArray()) + ")";
            }
            string parentid = string.Empty;
            if (RoomID > 0)
            {
                parentid = "Room_" + RoomID;
                cmdNow += " and ([RoomID] in (select ID from [Project] where [AllParentID] like '%," + RoomID + ",%' or [ID] =" + RoomID + "))";
                cmd_chongdi += " and ([RoomID] in (select ID from [Project] where [AllParentID] like '%," + RoomID + ",%' or [ID] =" + RoomID + "))";
            }
            else
            {
                RoomID = 0;
            }
            string cmdPreTotalCost = "0 as QiChiCost,0 as QiChiChargeBackCost, 0 as QiChiChargeReturnCost";
            if (StartChargeTime > DateTime.MinValue)
            {
                parameters.Add(new SqlParameter("@StartChargeTime", StartChargeTime));
                cmdPreTotalCost = @"(select sum(isnull(RealCost,0)) as [Cost] from [RoomFeeHistory] 
                where ChargeID in (SELECT ID FROM  dbo.ChargeSummary where  CategoryID = 4) and ChargeID=ChargeSummary.ID and ChargeState = 1 " + cmdNow + @" and Convert(nvarchar(10),[ChargeTime],120)<@StartChargeTime) as QiChiCost,
                (select sum(isnull(RealCost,0)) as [Cost] from [RoomFeeHistory] 
                where ChargeState = 4 and ChongDiChargeID=ChargeSummary.ID" + cmd_chongdi + @" and Convert(nvarchar(10),[ChargeTime],120)<@StartChargeTime) as QiChiChargeBackCost,
                (select sum(isnull(RealCost,0)) as [Cost] from [RoomFeeHistory] 
                where ChargeID in (SELECT ID FROM  dbo.ChargeSummary where CategoryID = 4) and ChargeID=ChargeSummary.ID and ChargeState = 6 " + cmdNow + @" and Convert(nvarchar(10),[ChargeTime],120)<@StartChargeTime) as QiChiChargeReturnCost";
                cmdNow += " and Convert(nvarchar(10),[ChargeTime],120)>=@StartChargeTime";
            }
            if (EndChargeTime > DateTime.MinValue)
            {
                cmdNow += " and Convert(nvarchar(10),[ChargeTime],120)<=@EndChargeTime";
                parameters.Add(new SqlParameter("@EndChargeTime", EndChargeTime));
            }

            string cmdtext = @"select B.*,(isnull(B.PreTotalCost,0)+isnull(B.Cost,0)-isnull(B.ChargeBackCost,0)-isnull(B.ChargeReturnCost,0)) as AfterTotalCost from (select A.*,(isnull(A.QiChiCost,0)-isnull(A.QiChiChargeBackCost,0)-isnull(A.QiChiChargeReturnCost,0)) as PreTotalCost from (select '' as state,'Charge_" + RoomID + "_'+CONVERT(nvarchar(100), ChargeSummary.ID) as id,'" + parentid + @"' as _parentId, " + RoomID + @" as RoomID,'' as RoomName,ChargeSummary.Name,'' as FullName,'' as DefaultOrder, 
            (select sum(RealCost) as Cost from RoomFeeHistory where  ChargeState = 1 and ChargeID =ChargeSummary.ID " + cmdNow + @") 
            as Cost,
            (select sum(RealCost) as Cost from RoomFeeHistory where  ChargeState = 4 and ChongDiChargeID=ChargeSummary.ID " + cmd_chongdi + @")
            as ChargeBackCost,
            (SELECT SUM(RealCost) as Cost from RoomFeeHistory where ChargeState = 6 and ChargeID in (SELECT ID FROM  dbo.ChargeSummary where CategoryID = 4) and ChargeID=ChargeSummary.ID " + cmdNow + @")
            as ChargeReturnCost," + cmdPreTotalCost + @"
            from ChargeSummary where  CategoryID = 4 " + cmdWhere + ")A)B";
            ChargeSummaryPreChargeAnalysis[] list = GetList<ChargeSummaryPreChargeAnalysis>(cmdtext, parameters).ToArray();
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = list.Length;
            dg.page = 1;
            return dg;
        }
    }
    public partial class ChargeSummaryChaoBiaoAnalysis : EntityBaseReadOnly
    {
        [DatabaseColumn("state")]
        public string state { get; set; }
        [DatabaseColumn("id")]
        public string id { get; set; }
        [DatabaseColumn("_parentId")]
        public string _parentId { get; set; }
        [DatabaseColumn("RoomID")]
        public int RoomID { get; set; }
        [DatabaseColumn("RoomName")]
        public string RoomName { get; set; }
        [DatabaseColumn("FullName")]
        public string FullName { get; set; }
        [DatabaseColumn("Name")]
        public string Name { get; set; }
        [DatabaseColumn("RentName")]
        public string RentName { get; set; }
        [DatabaseColumn("DefaultOrder")]
        public string DefaultOrder { get; set; }
        [DatabaseColumn("TotalPoint")]
        public decimal TotalPoint { get; set; }
        [DatabaseColumn("Cost")]
        public decimal Cost { get; set; }
        public string FormatCost
        {
            get
            {
                return Utility.Tools.FormatMoney(this.Cost);
            }
        }
        /// <summary>
        /// 已收
        /// </summary>
        [DatabaseColumn("ChargeCost")]
        public decimal ChargeCost { get; set; }
        public string FormatChargeCost
        {
            get
            {
                return Utility.Tools.FormatMoney(this.ChargeCost);
            }
        }
        [DatabaseColumn("ChargeUseCount")]
        public decimal ChargeUseCount { get; set; }
        [DatabaseColumn("RestCost")]
        public decimal RestCost { get; set; }
        public string FormatRestCost
        {
            get
            {
                return Utility.Tools.FormatMoney(this.RestCost);
            }
        }
        [DatabaseColumn("RestUseCount")]
        public decimal RestUseCount { get; set; }
        protected override void EnsureParentProperties()
        {
        }
        public static Ui.DataGrid GetChargeSummaryChaoBiaoAnalysisByChargeName(List<int> ProjectIDList, List<int> RoomIDList, DateTime StartChargeTime, DateTime EndChargeTime, int CompanyID, List<int> ChargeIDList, int RoomID, int UserID = 0)
        {

            List<SqlParameter> parameters = new List<SqlParameter>();
            string cmdNow = string.Empty;
            string cmdWhere = string.Empty;
            if (ChargeIDList.Count > 0)
            {
                cmdNow += " and [ChargeID] in (" + string.Join(",", ChargeIDList.ToArray()) + ")";
                cmdWhere += " and [ID] in (" + string.Join(",", ChargeIDList.ToArray()) + ")";
            }
            if (RoomIDList.Count > 0)
            {
                List<string> cmdlist = ViewRoomFeeHistory.GetRoomIDListConditions(RoomIDList, IsContractFee: true);
                cmdNow += " and (" + string.Join(" or ", cmdlist.ToArray()) + ")";
            }
            if (ProjectIDList.Count > 0)
            {
                List<string> cmdlist = ViewRoomFeeHistory.GetProjectIDListConditions(ProjectIDList, IsContractFee: true, UserID: UserID);
                cmdNow += " and (" + string.Join(" or ", cmdlist.ToArray()) + ")";
            }
            if (StartChargeTime > DateTime.MinValue)
            {
                cmdNow += " and Convert(nvarchar(10),[ChargeTime],120)>=@StartChargeTime";
                parameters.Add(new SqlParameter("@StartChargeTime", StartChargeTime));
            }
            if (EndChargeTime > DateTime.MinValue)
            {
                cmdNow += " and Convert(nvarchar(10),[ChargeTime],120)<=@EndChargeTime";
                parameters.Add(new SqlParameter("@EndChargeTime", EndChargeTime));
            }
            string parentid = string.Empty;
            if (RoomID > 0)
            {
                parentid = "Room_" + RoomID;
                cmdNow += " and ([RoomID] in (select ID from [Project] where [AllParentID] like '%," + RoomID + ",%' or [ID] =" + RoomID + "))";
            }
            else
            {
                RoomID = 0;
            }
            string cmdtext = @"select * from (select '' as state,'Charge_" + RoomID + @"_'+CONVERT(nvarchar(100), ChargeSummary.ID) as id,'" + parentid + @"' as _parentId, " + RoomID + @" as RoomID,'' as RoomName,ChargeSummary.Name,'' as FullName,'' as DefaultOrder,(isnull(A.ChargeCost,0)+ isnull(C.RestCost,0)) as Cost,(isnull(B.ChargeUseCount,0)+ isnull(D.RestUseCount,0)) as TotalPoint,A.ChargeCost,C.RestCost from ChargeSummary 
            left join
            (
            select sum(RealCost) as ChargeCost,ChargeID from RoomFeeHistory where ChargeID in
            (SELECT ID FROM  dbo.ChargeSummary where isnull(IsReading,0)=1) and  ChargeState = 1 " + cmdNow + @"
            group by ChargeID
            )A on A.ChargeID=ChargeSummary.ID
            left join
            (
            select sum(isnull(UseCount,0)) as [ChargeUseCount],ChargeID from RoomFeeHistory where ChargeID in
            (SELECT ID FROM  dbo.ChargeSummary where isnull(IsReading,0)=1) and  ChargeState = 1 " + cmdNow + @"
            group by ChargeID
            )B on B.ChargeID=ChargeSummary.ID
            left join
            (
            SELECT SUM(Cost) as RestCost,ChargeID
            FROM dbo.RoomFee where ChargeID in (SELECT ID FROM  dbo.ChargeSummary where isnull(IsReading,0)=1) " + cmdNow + @"
            group by ChargeID
            )C on C.ChargeID=ChargeSummary.ID 
            left join
            (
            SELECT SUM(UseCount) as RestUseCount,ChargeID
            FROM dbo.RoomFee where ChargeID in (SELECT ID FROM  dbo.ChargeSummary where isnull(IsReading,0)=1) " + cmdNow + @"
            group by ChargeID
            )D on D.ChargeID=ChargeSummary.ID 
            where 1=1 " + cmdWhere + ")TT where isnull(Cost,0)>0 or isnull(TotalPoint,0)>0 or isnull(ChargeCost,0)>0 or isnull(RestCost,0)>0";
            ChargeSummaryChaoBiaoAnalysis[] list = GetList<ChargeSummaryChaoBiaoAnalysis>(cmdtext, parameters).ToArray();
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = list.Length;
            dg.page = 1;
            return dg;
        }
        public static Ui.DataGrid GetChargeSummaryChaoBiaoAnalysisByProject(List<int> ProjectIDList, List<int> RoomIDList, DateTime StartTime, DateTime EndTime, List<int> ChargeIDList, int UserID = 0)
        {
            var fee_list = RoomFeeAnalysis.GetRoomFeeAnalysisListByRoomID(RoomIDList, ProjectIDList, StartTime, EndTime, ChargeIDList.ToArray(), -1, new List<int>(), true, true, 0, UserID: UserID, RequireOrderBy: false, IncludeRelation: false).Where(p => p.IsReading).ToArray();
            var history_list = ViewRoomFeeHistoryDetail.GetViewRoomFeeHistoryDetailList(RoomIDList, StartTime, EndTime, DateTime.MinValue, DateTime.MinValue, ProjectIDList, ChargeIDList: new List<int>(), UserID: UserID, RequireOrderBy: false).Where(p => p.IsReading).ToArray();
            List<ChargeSummaryChaoBiaoAnalysis> list = new List<ChargeSummaryChaoBiaoAnalysis>();
            var project_list = Project.GetXiaoQuProjectListBySystemUserID(UserID);
            foreach (var project in project_list)
            {
                var my_history_list = history_list.Where(p => p.AllParentID.Contains("," + project.ID + ",")).ToArray();
                var my_fee_list = fee_list.Where(p => p.AllParentID.Contains("," + project.ID + ",")).ToArray();
                var item = new ChargeSummaryChaoBiaoAnalysis();
                item.RentName = string.Empty;
                item.state = "closed";
                item.id = "Room_" + project.ID;
                item._parentId = string.Empty;
                item.RoomID = project.ID;
                item.RoomName = string.Empty;
                item.Name = "所有费项之和";
                item.FullName = project.FullName;
                item.DefaultOrder = project.DefaultOrder;
                item.ChargeCost = my_history_list.Sum(p => p.MonthTotalCost);
                item.ChargeUseCount = my_history_list.Where(p => p.IsReading).Sum(p => p.UseCount);
                item.RestCost = my_fee_list.Sum(p => p.TotalFinalCost);
                item.RestUseCount = my_fee_list.Where(p => p.IsReading).Sum(p => p.CalculateUseCount);
                decimal TotalPoint = item.ChargeUseCount - item.RestUseCount;
                item.TotalPoint = (TotalPoint > 0 ? TotalPoint : 0);
                decimal Cost_1 = ViewRoomFeeHistoryBase.GetViewRoomFeeHistoryTotalCost(my_history_list: my_history_list);
                decimal Cost_2 = my_fee_list.Sum(p => p.TotalCost);
                item.Cost = Cost_1 + Cost_2;
                list.Add(item);
            }
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = list.Count;
            dg.page = 1;
            return dg;
        }
        public static Ui.DataGrid GetChargeSummaryChaoBiaoAnalysisByRoom(List<int> ProjectIDList, List<int> RoomIDList, DateTime StartTime, DateTime EndTime, int CompanyID, List<int> ChargeIDList, string orderBy, long startRowIndex, int pageSize, int UserID)
        {

            var fee_list = RoomFeeAnalysis.GetRoomFeeAnalysisListByRoomID(RoomIDList, ProjectIDList, StartTime, EndTime, ChargeIDList.ToArray(), -1, new List<int>(), true, true, 0, UserID: UserID, RequireOrderBy: false, IncludeRelation: false).Where(p => p.IsReading).ToArray();
            var history_list = ViewRoomFeeHistoryDetail.GetViewRoomFeeHistoryDetailList(RoomIDList, StartTime, EndTime, DateTime.MinValue, DateTime.MinValue, ProjectIDList, ChargeIDList: new List<int>(), UserID: UserID, RequireOrderBy: false).Where(p => p.IsReading).ToArray();
            List<ChargeSummaryChaoBiaoAnalysis> list = new List<ChargeSummaryChaoBiaoAnalysis>();
            var project_list = Project.GetXiaoQuProjectListBySystemUserID(UserID);
            foreach (var project in project_list)
            {
                var my_history_list = history_list.Where(p => p.AllParentID.Contains("," + project.ID + ",")).ToArray();
                var my_fee_list = fee_list.Where(p => p.AllParentID.Contains("," + project.ID + ",")).ToArray();
                var item = new ChargeSummaryChaoBiaoAnalysis();
                item.RentName = string.Empty;
                item.state = "closed";
                item.id = "Room_" + project.ID;
                item._parentId = string.Empty;
                item.RoomID = project.ID;
                item.RoomName = string.Empty;
                item.Name = "所有费项之和";
                item.FullName = project.FullName;
                item.DefaultOrder = project.DefaultOrder;
                item.ChargeCost = my_history_list.Sum(p => p.MonthTotalCost);
                item.ChargeUseCount = my_history_list.Where(p => p.IsReading).Sum(p => p.UseCount);
                item.RestCost = my_fee_list.Sum(p => p.TotalFinalCost);
                item.RestUseCount = my_fee_list.Where(p => p.IsReading).Sum(p => p.CalculateUseCount);
                decimal TotalPoint = item.ChargeUseCount - item.RestUseCount;
                item.TotalPoint = (TotalPoint > 0 ? TotalPoint : 0);
                decimal Cost_1 = ViewRoomFeeHistoryBase.GetViewRoomFeeHistoryTotalCost(my_history_list: my_history_list);
                decimal Cost_2 = my_fee_list.Sum(p => p.TotalCost);
                item.Cost = Cost_1 + Cost_2;
                list.Add(item);
            }
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = list.Count;
            dg.page = 1;
            return dg;
        }
    }
    public partial class ChargeSummaryShouFeiLvAnalysis : EntityBaseReadOnly
    {
        [DatabaseColumn("state")]
        public string state { get; set; }
        [DatabaseColumn("id")]
        public string id { get; set; }
        [DatabaseColumn("_parentId")]
        public string _parentId { get; set; }
        [DatabaseColumn("RoomID")]
        public int RoomID { get; set; }
        [DatabaseColumn("ChargeID")]
        public int ChargeID { get; set; }
        [DatabaseColumn("RoomName")]
        public string RoomName { get; set; }
        [DatabaseColumn("FullName")]
        public string FullName { get; set; }
        [DatabaseColumn("Name")]
        public string Name { get; set; }
        [DatabaseColumn("DefaultOrder")]
        public string DefaultOrder { get; set; }
        [DatabaseColumn("LishiShouBenqi")]
        public decimal LishiShouBenqi { get; set; }
        public string FormatLishiShouBenqi
        {
            get
            {
                return Utility.Tools.FormatMoney(this.LishiShouBenqi);
            }
        }
        [DatabaseColumn("BenqiShouLishi")]
        public decimal BenqiShouLishi { get; set; }
        public string FormatBenqiShouLishi
        {
            get
            {
                return Utility.Tools.FormatMoney(this.BenqiShouLishi);
            }
        }
        [DatabaseColumn("BenqiShouBenqi")]
        public decimal BenqiShouBenqi { get; set; }
        public string FormatBenqiShouBenqi
        {
            get
            {
                return Utility.Tools.FormatMoney(this.BenqiShouBenqi);
            }
        }
        [DatabaseColumn("BenqiYuShou")]
        public decimal BenqiYuShou { get; set; }
        public string FormatBenqiYuShou
        {
            get
            {
                return Utility.Tools.FormatMoney(this.BenqiYuShou);
            }
        }
        [DatabaseColumn("BenqiChongXiao")]
        public decimal BenqiChongXiao { get; set; }
        public string FormatBenqiChongXiao
        {
            get
            {
                return Utility.Tools.FormatMoney(this.BenqiChongXiao);
            }
        }
        [DatabaseColumn("ZhiHouShouBenqi")]
        public decimal ZhiHouShouBenqi { get; set; }
        public string FormatZhiHouShouBenqi
        {
            get
            {
                return Utility.Tools.FormatMoney(this.ZhiHouShouBenqi);
            }
        }
        [DatabaseColumn("ActiveStartTime")]
        public DateTime ActiveStartTime { get; set; }
        [DatabaseColumn("ActiveEndTime")]
        public DateTime ActiveEndTime { get; set; }
        [DatabaseColumn("StartTime")]
        public DateTime StartTime { get; set; }
        [DatabaseColumn("EndTime")]
        public DateTime EndTime { get; set; }
        [DatabaseColumn("RealCost")]
        public decimal RealCost { get; set; }
        public string FormatRealCost
        {
            get
            {
                return Utility.Tools.FormatMoney(this.RealCost);
            }
        }
        public decimal MonthBenQiYingShou { get; set; }
        public string FormatMonthBenQiYingShou
        {
            get
            {
                return Utility.Tools.FormatMoney(this.MonthBenQiYingShou);
            }
        }
        public string MonthLishiShouBenqi_Title
        {
            get
            {
                string result = string.Empty;
                result += "实收: " + Utility.Tools.FormatMoney(this.MonthLishiShouBenqi_ShiShou);
                result += "冲抵: " + Utility.Tools.FormatMoney(this.MonthLishiShouBenqi_ChongDi);
                result += "减免: " + Utility.Tools.FormatMoney(this.MonthLishiShouBenqi_JianMian);
                return result;
            }
        }
        public decimal MonthLishiShouBenqi_ShiShou { get; set; }
        public decimal MonthLishiShouBenqi_ChongDi { get; set; }
        public decimal MonthLishiShouBenqi_JianMian { get; set; }
        public decimal MonthLishiShouBenqi { get; set; }
        public string FormatMonthLishiShouBenqi
        {
            get
            {
                return Utility.Tools.FormatMoney(this.MonthLishiShouBenqi);
            }
        }
        public string MonthBenqiShouLishi_Title
        {
            get
            {
                string result = string.Empty;
                result += "实收: " + Utility.Tools.FormatMoney(this.MonthBenqiShouLishi_ShiShou);
                result += "冲抵: " + Utility.Tools.FormatMoney(this.MonthBenqiShouLishi_ChongDi);
                result += "减免: " + Utility.Tools.FormatMoney(this.MonthBenqiShouLishi_JianMian);
                return result;
            }
        }
        public decimal MonthBenqiShouLishi_ShiShou { get; set; }
        public string FormatMonthBenqiShouBenqi_ShiShou
        {
            get
            {
                return Utility.Tools.FormatMoney(this.MonthBenqiShouBenqi_ShiShou);
            }
        }
        public string FormatMonthBenqiShouLishi_ShiShou
        {
            get
            {
                return Utility.Tools.FormatMoney(this.MonthBenqiShouLishi_ShiShou);
            }
        }
        public string FormatMonthBenqiYuShou_ShiShou
        {
            get
            {
                return Utility.Tools.FormatMoney(this.MonthBenqiYuShou_ShiShou);
            }
        }
        public decimal MonthBenqiShouLishi_ChongDi { get; set; }
        public decimal MonthBenqiShouLishi_JianMian { get; set; }
        public decimal MonthBenqiShouLishi { get; set; }
        public string FormatMonthBenqiShouLishi
        {
            get
            {
                return Utility.Tools.FormatMoney(this.MonthBenqiShouLishi);
            }
        }
        public string MonthBenqiShouBenqi_Title
        {
            get
            {
                string result = string.Empty;
                result += "实收: " + Utility.Tools.FormatMoney(this.MonthBenqiShouBenqi_ShiShou);
                result += "冲抵: " + Utility.Tools.FormatMoney(this.MonthBenqiShouBenqi_ChongDi);
                result += "减免: " + Utility.Tools.FormatMoney(this.MonthBenqiShouBenqi_JianMian);
                return result;
            }
        }
        public decimal MonthBenqiShouBenqi_ShiShou { get; set; }
        public decimal MonthBenqiShouBenqi_ChongDi { get; set; }
        public decimal MonthBenqiShouBenqi_JianMian { get; set; }
        public decimal MonthBenqiShouBenqi { get; set; }
        public string FormatMonthBenqiShouBenqi
        {
            get
            {
                return Utility.Tools.FormatMoney(this.MonthBenqiShouBenqi);
            }
        }
        public string MonthBenqiYuShou_Title
        {
            get
            {
                string result = string.Empty;
                result += "实收: " + Utility.Tools.FormatMoney(this.MonthBenqiYuShou_ShiShou);
                result += "冲抵: " + Utility.Tools.FormatMoney(this.MonthBenqiYuShou_ChongDi);
                result += "减免: " + Utility.Tools.FormatMoney(this.MonthBenqiYuShou_JianMian);
                return result;
            }
        }
        public decimal MonthBenqiYuShou_ShiShou { get; set; }
        public decimal MonthBenqiYuShou_ChongDi { get; set; }
        public decimal MonthBenqiYuShou_JianMian { get; set; }
        public decimal MonthBenqiYuShou { get; set; }
        public string FormatMonthBenqiYuShou
        {
            get
            {
                return Utility.Tools.FormatMoney(this.MonthBenqiYuShou);
            }
        }
        public string MonthBenqiChongXiao_Title
        {
            get
            {
                string result = string.Empty;
                result += "实收: " + Utility.Tools.FormatMoney(this.MonthBenqiChongXiao_ShiShou);
                result += "冲抵: " + Utility.Tools.FormatMoney(this.MonthBenqiYuShou_ChongDi);
                result += "减免: " + Utility.Tools.FormatMoney(this.MonthBenqiChongXiao_JianMian);
                return result;
            }
        }
        public decimal MonthBenqiChongXiao_ShiShou { get; set; }
        public decimal MonthBenqiChongXiao_ChongDi { get; set; }
        public decimal MonthBenqiChongXiao_JianMian { get; set; }
        public decimal MonthBenqiChongXiao { get; set; }
        public string FormatMonthBenqiChongXiao
        {
            get
            {
                return Utility.Tools.FormatMoney(this.MonthBenqiChongXiao);
            }
        }
        public string MonthZhiHouShouBenqi_Title
        {
            get
            {
                string result = string.Empty;
                result += "实收: " + Utility.Tools.FormatMoney(this.MonthZhiHouShouBenqi_ShiShou);
                result += "冲抵: " + Utility.Tools.FormatMoney(this.MonthZhiHouShouBenqi_ChongDi);
                result += "减免: " + Utility.Tools.FormatMoney(this.MonthZhiHouShouBenqi_JianMian);
                return result;
            }
        }
        public decimal MonthZhiHouShouBenqi_ShiShou { get; set; }
        public decimal MonthZhiHouShouBenqi_ChongDi { get; set; }
        public decimal MonthZhiHouShouBenqi_JianMian { get; set; }
        public decimal MonthZhiHouShouBenqi { get; set; }
        public string FormatMonthZhiHouShouBenqi
        {
            get
            {
                return Utility.Tools.FormatMoney(this.MonthZhiHouShouBenqi);
            }
        }
        [DatabaseColumn("BenQiQianFei")]
        public decimal BenQiQianFei { get; set; }
        public string FormatBenQiQianFei
        {
            get
            {
                return Utility.Tools.FormatMoney(this.BenQiQianFei);
            }
        }
        public decimal BenQiDiscount { get; set; }
        public string FormatBenQiDiscount
        {
            get
            {
                return Utility.Tools.FormatMoney(this.BenQiDiscount);
            }
        }
        public string BenQiShouFeiLv { get; set; }
        public string ShiShiShouFeiLv { get; set; }
        public decimal ShouFuZhiBenQiYingShou { get; set; }
        public string FormatShouFuZhiBenQiYingShou
        {
            get
            {
                return Utility.Tools.FormatMoney(this.ShouFuZhiBenQiYingShou);
            }
        }
        public decimal ShouFuZhiLeiJiYingShou { get; set; }
        public string FormatShouFuZhiLeiJiYingShou
        {
            get
            {
                return Utility.Tools.FormatMoney(this.ShouFuZhiLeiJiYingShou);
            }
        }
        public decimal ShouFuZhiLeiJiShiShou { get; set; }
        public string FormatShouFuZhiLeiJiShiShou
        {
            get
            {
                return Utility.Tools.FormatMoney(this.ShouFuZhiLeiJiShiShou);
            }
        }
        public decimal ShouFuZhiBenQiShiShou { get; set; }
        public string FormatShouFuZhiBenQiShiShou
        {
            get
            {
                return Utility.Tools.FormatMoney(this.ShouFuZhiBenQiShiShou);
            }
        }
        public decimal ShouFuZhiBenQiJianMian { get; set; }
        public string FormatShouFuZhiBenQiJianMian
        {
            get
            {
                return Utility.Tools.FormatMoney(this.ShouFuZhiBenQiJianMian);
            }
        }
        public decimal ShouFuZhiBenQiQianFei { get; set; }
        public string FormatShouFuZhiBenQiQianFei
        {
            get
            {
                return Utility.Tools.FormatMoney(this.ShouFuZhiBenQiQianFei);
            }
        }
        public decimal ShouFuZhiLiShiQianFei { get; set; }
        public string FormatShouFuZhiLiShiQianFei
        {
            get
            {
                return Utility.Tools.FormatMoney(this.ShouFuZhiLiShiQianFei);
            }
        }
        public decimal ShouFuZhiLiShiJianMian { get; set; }
        public string FormatShouFuZhiLiShiJianMian
        {
            get
            {
                return Utility.Tools.FormatMoney(this.ShouFuZhiLiShiJianMian);
            }
        }
        public string ShouFuZhiBenQiShouFeiLv { get; set; }
        public string ShouFuZhiLeiJiShouFeiLv { get; set; }
        protected override void EnsureParentProperties()
        {
        }
        public static Ui.DataGrid GetChargeSummaryShouFeiLvAnalysisByProject(List<int> ProjectIDList, List<int> RoomIDList, DateTime StartChargeTime, DateTime EndChargeTime, int CompanyID, List<int> ChargeIDList, string orderBy, long startRowIndex, int pageSize, int ShowType = 0, bool canexport = false)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            string cmd_project = string.Empty;
            #region conditions
            if (ProjectIDList.Count > 0)
            {
                List<string> cmdlist = new List<string>();
                foreach (var ProjectID in ProjectIDList)
                {
                    cmdlist.Add("(exists (select 1 from Project as Project_1 where [Project_1].[AllParentID] like '%,'+Convert(nvarchar(100),[Project].ID)+',%' and [Project_1].[ID] =" + ProjectID + "))");
                    cmdlist.Add("[Project].ID=" + ProjectID);
                }
                cmd_project = " and (" + string.Join(" or ", cmdlist) + ")";
            }
            if (RoomIDList.Count > 0)
            {
                List<string> cmdlist = new List<string>();
                foreach (var RoomID in RoomIDList)
                {
                    cmdlist.Add("(exists (select 1 from Project as Project_1 where [Project_1].[AllParentID] like '%,'+Convert(nvarchar(100),[Project].ID)+',%' and [Project_1].[ID] =" + RoomID + "))");
                }
                cmd_project = " and (" + string.Join(" or ", cmdlist) + ")";
            }
            if (StartChargeTime == DateTime.MinValue)
            {
                return new Ui.DataGrid() { rows = new ChargeSummaryShouFeiLvAnalysis[] { }, total = 0, page = 0 };
            }
            if (EndChargeTime == DateTime.MinValue)
            {
                return new Ui.DataGrid() { rows = new ChargeSummaryShouFeiLvAnalysis[] { }, total = 0, page = 0 };
            }
            #endregion
            parameters.Add(new SqlParameter("@StartTime", StartChargeTime));
            parameters.Add(new SqlParameter("@StartTimeBeoreDay", StartChargeTime.AddDays(-1)));
            parameters.Add(new SqlParameter("@EndTime", EndChargeTime));
            parameters.Add(new SqlParameter("@EndTimeAfterDay", EndChargeTime.AddDays(1)));
            string Statement = @" from (select 0 as ChargeID, 'closed' as state,'Room_'+CONVERT(nvarchar(100), NewProject.ID) as id,'' as _parentId, NewProject.ID as RoomID,NewProject.Name as RoomName,'所有费项之和' as Name,NewProject.FullName,NewProject.DefaultOrder from (select * from Project where isnull(ParentID,0)=1 " + cmd_project + ")NewProject)Summary";
            long totalRows = 0;
            var list = new ChargeSummaryShouFeiLvAnalysis[] { };
            if (canexport)
            {
                list = GetList<ChargeSummaryShouFeiLvAnalysis>("select * " + Statement + " " + orderBy, parameters).ToArray();
                totalRows = list.Length;
            }
            else
            {
                list = GetList<ChargeSummaryShouFeiLvAnalysis>("Summary.*", Statement, parameters, orderBy, startRowIndex, pageSize, out totalRows).ToArray();
            }
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
        public static Ui.DataGrid GetChargeSummaryShouFeiLvAnalysisByChargeName(List<int> ProjectIDList, List<int> RoomIDList, DateTime StartChargeTime, DateTime EndChargeTime, int CompanyID, List<int> ChargeIDList, int RoomID, string RoomType = "Project", int ShowType = 0)
        {

            List<SqlParameter> parameters = new List<SqlParameter>();
            string cmd_chargesummary = string.Empty;
            if (ChargeIDList.Count > 0)
            {
                cmd_chargesummary += " and [ID] in (" + string.Join(",", ChargeIDList.ToArray()) + ")";
            }
            if (StartChargeTime == DateTime.MinValue)
            {
                return new Ui.DataGrid() { rows = new ChargeSummaryShouFeiLvAnalysis[] { }, total = 0, page = 0 };
            }
            if (EndChargeTime == DateTime.MinValue)
            {
                return new Ui.DataGrid() { rows = new ChargeSummaryShouFeiLvAnalysis[] { }, total = 0, page = 0 };
            }
            string parentid = string.Empty;
            if (RoomID > 0)
            {
                parentid = "Room_" + RoomID;
            }
            else
            {
                RoomID = 0;
            }
            parameters.Add(new SqlParameter("@StartTime", StartChargeTime));
            parameters.Add(new SqlParameter("@StartTimeBeforeDay", StartChargeTime.AddDays(-1)));
            parameters.Add(new SqlParameter("@EndTime", EndChargeTime));
            parameters.Add(new SqlParameter("@EndTimeAfterDay", EndChargeTime.AddDays(1)));
            string cmd_where = " 1=1";
            string Statement = @"select * from (select NewProject.ID as ChargeID, '' as state,'Charge_" + RoomID + "_'+CONVERT(nvarchar(100), NewProject.ID) as id,'" + parentid + @"' as _parentId, " + RoomID + @" as RoomID,'' as RoomName,NewProject.Name,'' as FullName,'' as DefaultOrder from (select * from ChargeSummary where 1=1 " + cmd_chargesummary + ")NewProject)Summary where " + cmd_where;
            ChargeSummaryShouFeiLvAnalysis[] list = GetList<ChargeSummaryShouFeiLvAnalysis>(Statement, parameters).ToArray();
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = list.Length;
            dg.page = 1;
            return dg;
        }
        public static Ui.DataGrid GetChargeSummaryShouFeiLvAnalysisByRoom(List<int> ProjectIDList, List<int> RoomIDList, DateTime StartChargeTime, DateTime EndChargeTime, int CompanyID, List<int> ChargeIDList, string orderBy, long startRowIndex, int pageSize, int ShowType = 0, bool canexport = false)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            string cmd_project = string.Empty;
            #region conditions
            if (ProjectIDList.Count > 0)
            {
                List<string> cmdlist = new List<string>();
                foreach (var ProjectID in ProjectIDList)
                {
                    cmdlist.Add("([AllParentID] like '%," + ProjectID + ",%' or [ID] =" + ProjectID + ")");
                }
                cmd_project += " and (" + string.Join(" or ", cmdlist.ToArray()) + ")";
            }
            if (RoomIDList.Count > 0)
            {
                cmd_project += " and [ID] in (" + string.Join(",", RoomIDList.ToArray()) + ")";
            }
            if (StartChargeTime == DateTime.MinValue)
            {
                return new Ui.DataGrid() { rows = new ChargeSummaryShouFeiLvAnalysis[] { }, total = 0, page = 0 };
            }
            if (EndChargeTime == DateTime.MinValue)
            {
                return new Ui.DataGrid() { rows = new ChargeSummaryShouFeiLvAnalysis[] { }, total = 0, page = 0 };
            }
            #endregion
            parameters.Add(new SqlParameter("@StartTime", StartChargeTime));
            parameters.Add(new SqlParameter("@StartTimeBeoreDay", StartChargeTime.AddDays(-1)));
            parameters.Add(new SqlParameter("@EndTime", EndChargeTime));
            parameters.Add(new SqlParameter("@EndTimeAfterDay", EndChargeTime.AddDays(1)));
            string Statement = @" from (select 0 as ChargeID, 'closed' as state,'Room_'+CONVERT(nvarchar(100), NewProject.ID) as id,'' as _parentId, NewProject.ID as RoomID,NewProject.Name as RoomName,'所有费项之和' as Name,NewProject.FullName,NewProject.DefaultOrder from (select * from Project where isnull(isParent,1)=0 " + cmd_project + ")NewProject)Summary";
            long totalRows = 0;
            var list = new ChargeSummaryShouFeiLvAnalysis[] { };
            if (canexport)
            {
                list = GetList<ChargeSummaryShouFeiLvAnalysis>("select * " + Statement + " " + orderBy, parameters).ToArray();
                totalRows = list.Length;
            }
            else
            {
                list = GetList<ChargeSummaryShouFeiLvAnalysis>("Summary.*", Statement, parameters, orderBy, startRowIndex, pageSize, out totalRows).ToArray();
            }
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
    }
    public partial class ChargeSummaryShouFeiLvMonth : EntityBaseReadOnly
    {
        [DatabaseColumn("RoomID")]
        public int RoomID { get; set; }
        [DatabaseColumn("ChargeID")]
        public int ChargeID { get; set; }
        public decimal ZhiHouShouBenqi { get; set; }
        [DatabaseColumn("ActiveStartTime")]
        public DateTime ActiveStartTime { get; set; }
        [DatabaseColumn("ActiveEndTime")]
        public DateTime ActiveEndTime { get; set; }
        [DatabaseColumn("StartTime")]
        public DateTime StartTime { get; set; }
        [DatabaseColumn("EndTime")]
        public DateTime EndTime { get; set; }
        [DatabaseColumn("RealCost")]
        public decimal RealCost { get; set; }
        [DatabaseColumn("AllParentID")]
        public string AllParentID { get; set; }
        protected override void EnsureParentProperties()
        {
        }
        public decimal MonthTotalCost
        {
            get
            {
                int ActiveMonthNumber = calculatemonth(this.ActiveStartTime, this.ActiveEndTime);
                decimal ActiveTotalDays = calculateTotaldays(this.ActiveStartTime, this.ActiveEndTime, ActiveMonthNumber, true);
                int ActiveRestDays = calculateTotaldays(this.ActiveStartTime, this.ActiveEndTime, ActiveMonthNumber, false);
                int MonthNumber = calculatemonth(this.StartTime, this.EndTime);
                decimal TotalDays = calculateTotaldays(this.StartTime, this.EndTime, MonthNumber, true);
                int RestDays = calculateTotaldays(this.StartTime, this.EndTime, MonthNumber, false);
                decimal calculateCost = this.RealCost * (ActiveMonthNumber + (ActiveRestDays / ActiveTotalDays)) / (MonthNumber + (RestDays / TotalDays));
                if (calculateCost <= 0)
                {
                    return 0;
                }
                return Math.Round(calculateCost, 2, MidpointRounding.AwayFromZero);
            }
        }
        public static int calculatemonth(DateTime starttime, DateTime endtime)
        {
            int count = 0;
            int year1 = starttime.Year;
            int month1 = starttime.Month;
            int day1 = starttime.Day;
            int year2 = endtime.Year;
            int month2 = endtime.Month;
            int day2 = endtime.Day;
            int newday2 = endtime.AddDays(1 - day2).AddMonths(1).AddDays(-1).Day;
            if (day1 == 1)
            {
                if (day2 == newday2)
                {
                    count = (year2 - year1) * 12 + (month2 - month1) + 1;
                }
                else
                {
                    count = (year2 - year1) * 12 + (month2 - month1);
                }
            }
            else if (day2 < (day1 - 1))
            {
                count = (year2 - year1) * 12 + (month2 - month1) - 1;
            }
            else
            {
                count = (year2 - year1) * 12 + (month2 - month1);
            }
            return count;
        }
        public static int calculateTotaldays(DateTime starttime, DateTime endtime, int monthnumber, bool isTotal)
        {
            string newendtime = string.Empty;
            int count = 0;
            string newstarttime = getNextMonth(starttime, monthnumber);
            if (isTotal)
            {
                newendtime = getNextMonth(DateTime.Parse(newstarttime), 1);
                count = 0;
            }
            else
            {
                newendtime = endtime.ToString("yyyy-MM-dd");
                count = 1;
            }
            DateTime startdate = DateTime.Parse(newstarttime);
            DateTime enddate = DateTime.Parse(newendtime);
            if (startdate > enddate)
            {
                if (isTotal)
                {
                    return 1;
                }
                return 0;
            }
            TimeSpan date = enddate - startdate;
            int time = Convert.ToInt32(date.TotalMilliseconds / (1000 * 60 * 60 * 24)) + count;
            return time;
        }
        public static string getNextMonth(DateTime date, int monthnumber)
        {
            int year1 = date.Year; //获取当前日期的年份
            int month1 = date.Month; //获取当前日期的月份
            int day1 = date.Day; //获取当前日期的日
            int newmonth2 = month1 + monthnumber;
            int addyearcount = (newmonth2 - 1) / 12;
            int year2 = year1 + addyearcount;
            int month2 = newmonth2 - (12 * addyearcount);
            int day2 = day1;
            DateTime newdate = DateTime.Parse(year2 + "-" + month2 + "-01").AddMonths(1).AddDays(-1);
            int lastday = newdate.Day;
            string month2str = month2.ToString("D2");
            if (day2 > lastday)
            {
                day2 = lastday;
            }
            string day2str = day2.ToString("D2");
            string t2 = year2 + "-" + month2str + "-" + day2str;
            return t2;
        }
    }
    public partial class ChargeSummaryField : ChargeSummary
    {
        [DatabaseColumn("SortOrder")]
        public int SortOrder { get; set; }
        [DatabaseColumn("IsHide")]
        public bool IsHide { get; set; }
        [DatabaseColumn("ChargeFieldID")]
        public int ChargeFieldID { get; set; }
        [DatabaseColumn("IsHideTotal")]
        public bool IsHideTotal { get; set; }
        [DatabaseColumn("IsHideReal")]
        public bool IsHideReal { get; set; }
        [DatabaseColumn("IsHideRest")]
        public bool IsHideRest { get; set; }
        [DatabaseColumn("IsHideHistoryRoomFee")]
        public bool IsHideHistoryRoomFee { get; set; }
        public static ChargeSummaryField[] GetChargeSummaryFields(string PageCode)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (!string.IsNullOrEmpty(PageCode))
            {
                parameters.Add(new SqlParameter("@PageCode", PageCode));
                return GetList<ChargeSummaryField>("select [ChargeSummary].*,A.SortOrder,A.IsHide,A.ID as ChargeFieldID,A.IsHideTotal,A.IsHideReal,A.IsHideRest,A.IsHideHistoryRoomFee from [ChargeSummary] left join (select * from AnalysisChargeField where [PageCode]=@PageCode) A on A.ChargeID=[ChargeSummary].ID where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
            }
            var list = GetList<ChargeSummaryField>("select * from [ChargeSummary] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
            return list;
        }
    }
    public partial class ChargeSummaryToChargeSummary : EntityBaseReadOnly
    {
        [DatabaseColumn("ID")]
        public int ID { get; set; }
        [DatabaseColumn("Name")]
        public string Name { get; set; }
        [DatabaseColumn("TotalCost")]
        public decimal TotalCost { get; set; }
        [DatabaseColumn("PayCost")]
        public decimal PayCost { get; set; }
        [DatabaseColumn("RestCost")]
        public decimal RestCost { get; set; }
        public string FormatTotalCost
        {
            get
            {
                return Utility.Tools.FormatMoney(this.TotalCost);
            }
        }
        public string FormatPayCost
        {
            get
            {
                return Utility.Tools.FormatMoney(this.PayCost);
            }
        }
        public string FormatRestCost
        {
            get
            {
                return Utility.Tools.FormatMoney(this.RestCost);
            }
        }
        protected override void EnsureParentProperties()
        {
        }
        public static ChargeSummaryToChargeSummary[] GetChargeSummaryToChargeSummaryListByIDList(int[] IDList)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (IDList.Length > 0)
            {
                conditions.Add("[ID] in (" + string.Join(",", IDList) + ")");
            }
            return GetList<ChargeSummaryToChargeSummary>("select ID,Name from [ChargeSummary] where " + string.Join(" and ", conditions.ToArray()) + " order by [OrderBy]", parameters).ToArray();
        }
    }
}
