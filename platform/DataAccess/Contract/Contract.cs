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
    /// This object represents the properties and methods of a Contract.
    /// </summary>
    public partial class Contract : EntityBase
    {
        public int ContractWarningDayCount { get; set; }
        public bool IsRentExpire
        {
            get
            {

                string ContractStatusDesc = Utility.EnumModel.ContractStatus.tongguo.ToString();
                return this.ContractStatus.Equals(ContractStatusDesc) && this.RentEndTime > DateTime.MinValue && this.RentEndTime <= DateTime.Now.AddDays(this.ContractWarningDayCount);
            }
        }
        public static Contract[] GetContractListByIDList(List<int> IDList)
        {
            if (IDList.Count == 0)
            {
                return new Contract[] { };
            }
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[ID] in (" + string.Join(",", IDList.ToArray()) + ")");
            return GetList<Contract>("select * from [Contract] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
        public static Contract[] GetContractListByDivideIDList(List<int> DivideIDList)
        {
            if (DivideIDList.Count == 0)
            {
                return new Contract[] { };
            }
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[ID] in (select ContractID from Contract_Divide where ID in (" + string.Join(",", DivideIDList.ToArray()) + "))");
            return GetList<Contract>("select * from [Contract] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
        public static Contract GetContractByContractNo(string ContractNo)
        {
            using (SqlHelper helper = new SqlHelper())
            {
                return GetContractByContractNo(ContractNo, 0, helper);
            }
        }
        public static Contract GetContractByContractNo(string ContractNo, int ContractID, SqlHelper helper)
        {
            if (string.IsNullOrEmpty(ContractNo))
            {
                return null;
            }
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            parameters.Add(new SqlParameter("@ContractNo", ContractNo));
            conditions.Add("[ContractNo]=@ContractNo");
            if (ContractID > 0)
            {
                conditions.Add("[ID]!=@ContractID");
                parameters.Add(new SqlParameter("@ContractID", ContractID));
            }
            return GetOne<Contract>("select top 1 * from [Contract] where " + string.Join(" and ", conditions.ToArray()), parameters, helper);
        }
        public static int GetALLWaringingContractsCount(List<int> RoomIDList, List<int> ProjectIDList, int UserID = 0)
        {
            List<string> conditions = new List<string>();
            if (ProjectIDList.Count > 0)
            {
                List<string> cmdlist = ViewRoomFeeHistory.GetProjectIDListConditions(ProjectIDList, IncludeRelation: false, RoomIDName: "[RoomID]", IsContractFee: false, UserID: UserID);
                conditions.Add("ID in (select ContractID from Contract_Room where (" + string.Join(" or ", cmdlist.ToArray()) + "))");
            }
            if (RoomIDList.Count > 0)
            {
                List<string> cmdlist = ViewRoomFeeHistory.GetRoomIDListConditions(RoomIDList, IncludeRelation: false, RoomIDName: "[RoomID]");
                conditions.Add("ID in (select ContractID from Contract_Room where (" + string.Join(" or ", cmdlist.ToArray()) + "))");
            }
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@ContractStatus", Utility.EnumModel.ContractStatus.tongguo.ToString()));
            conditions.Add("[ContractStatus]=@ContractStatus");
            var list = GetList<ContractDetail>("select [ID],[ContractStatus],[RentEndTime] from [Contract] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
            ContractDetail.SetContractWarningCount(list);
            list = list.Where(p => p.IsRentExpire).ToArray();
            return list.Length;
        }
        public string ContractStatusDesc
        {
            get
            {
                if (string.IsNullOrEmpty(this.ContractStatus))
                {
                    return string.Empty;
                }
                return Utility.EnumHelper.GetDescription(typeof(Utility.EnumModel.ContractStatus), this.ContractStatus);
            }
        }
        public int RestDays
        {
            get
            {
                if (DateTime.Now > this.RentEndTime)
                {
                    return 0;
                }
                TimeSpan span = this.RentEndTime - DateTime.Now;
                int count = Convert.ToInt32(span.TotalDays);
                return count;
            }
        }
        public static Ui.DataGrid GetContractGridByKeywords(string Keywords, string ContractStatus, List<int> RoomIDList, List<int> ProjectIDList, bool ShowALL, DateTime StartTime, DateTime EndTime, DateTime RentStartTime, DateTime RentEndTime, string orderBy, long startRowIndex, int pageSize, bool IsDivideOn = false)
        {
            long totalRows = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
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
                            cmd += "  and  ([RentName] like '%" + keywords[i] + "%' or [RoomLocation] like '%" + keywords[i] + "%' or [ContractNo] like '%" + keywords[i] + "%' or [ContractName] like '%" + keywords[i] + "%' or [ContractSummary] like '%" + keywords[i] + "%')";
                        }
                        else
                        {
                            cmd += "  ([RentName] like '%" + keywords[i] + "%' or [RoomLocation] like '%" + keywords[i] + "%' or [ContractNo] like '%" + keywords[i] + "%' or [ContractName] like '%" + keywords[i] + "%' or [ContractSummary] like '%" + keywords[i] + "%'))";
                        }
                    }
                    else if (i == 0)
                    {
                        cmd += " and (([RentName] like '%" + keywords[i] + "%' or [RoomLocation] like '%" + keywords[i] + "%' or [ContractNo] like '%" + keywords[i] + "%' or [ContractName] like '%" + keywords[i] + "%' or [ContractSummary] like '%" + keywords[i] + "%') or";
                    }
                    else
                    {
                        cmd += "  ([RentName] like '%" + keywords[i] + "%' or [RoomLocation] like '%" + keywords[i] + "%' or [ContractNo] like '%" + keywords[i] + "%' or [ContractName] like '%" + keywords[i] + "%' or [ContractSummary] like '%" + keywords[i] + "%') or ";
                    }
                }
            }
            #endregion
            if (RentStartTime > DateTime.MinValue)
            {
                conditions.Add("[RentEndTime]>=@RentStartTime");
                parameters.Add(new SqlParameter("@RentStartTime", RentStartTime));
            }
            if (RentEndTime > DateTime.MinValue)
            {
                conditions.Add("[RentEndTime]<=@RentEndTime");
                parameters.Add(new SqlParameter("@RentEndTime", RentEndTime));
            }
            if (!string.IsNullOrEmpty(ContractStatus))
            {
                conditions.Add("[ContractStatus]=@ContractStatus");
                parameters.Add(new SqlParameter("@ContractStatus", ContractStatus));
            }
            //else
            //{
            //    conditions.Add("[ContractStatus]<>@ContractStatus");
            //    parameters.Add(new SqlParameter("@ContractStatus", Utility.EnumModel.ContractStatus.deleted.ToString()));
            //}
            if (ProjectIDList.Count > 0)
            {
                List<string> cmdlist = new List<string>();
                foreach (var ProjectID in ProjectIDList)
                {
                    cmdlist.Add("([AllParentID] like '%," + ProjectID + ",%' or [ID] =" + ProjectID + ")");
                }
                if (ShowALL)
                {
                    conditions.Add("([ID] in (select [ContractID] from [Contract_Room] where [RoomID] in (select [ID] from [Project] where (" + string.Join(" or ", cmdlist.ToArray()) + "))) or not exists (select * from [Contract_Room] where ContractID=[Contract].ID))");
                }
                else
                {
                    conditions.Add("[ID] in (select [ContractID] from [Contract_Room] where [RoomID] in (select [ID] from [Project] where (" + string.Join(" or ", cmdlist.ToArray()) + ")))");
                }
            }
            if (RoomIDList.Count > 0)
            {
                conditions.Add("[ID] in (select [ContractID] from [Contract_Room] where [RoomID] in (" + string.Join(",", RoomIDList.ToArray()) + "))");
            }
            if (StartTime > DateTime.MinValue)
            {
                conditions.Add("[SignTime]>=@StartTime");
                parameters.Add(new SqlParameter("@StartTime", StartTime));
            }
            if (EndTime > DateTime.MinValue)
            {
                conditions.Add("[SignTime]<=@EndTime");
                parameters.Add(new SqlParameter("@EndTime", EndTime));
            }
            if (IsDivideOn)
            {
                conditions.Add("[IsDivideOn]=1");
            }
            string fieldList = "[Contract].*";
            string Statement = " from [Contract] where  " + string.Join(" and ", conditions.ToArray()) + cmd;
            var list = GetList<ContractDetail>(fieldList, Statement, parameters, orderBy, startRowIndex, pageSize, out totalRows).ToArray();
            ContractDetail.SetContractWarningCount(list);
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
        public static int GetRelatedContractCountByID(int ContractID,int ContractRelateType)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            int count = 0;
            using (SqlHelper helper = new SqlHelper())
            {
                parameters.Add(new SqlParameter("@TopContractID", ContractID));
                parameters.Add(new SqlParameter("@ContractRelateType", ContractRelateType));
                var result = helper.ExecuteScalar("select count(1) from [Contract] where TopContractID=@TopContractID and ContractRelateType=@ContractRelateType", CommandType.Text, parameters);
                if (result != null)
                {
                    int.TryParse(result.ToString(), out count);
                }
            }
            return count;
        }
        public static string GetLastestContractNumber(string OrderTypeName, int RoomID, out int OrderNumberID)
        {
            if (string.IsNullOrEmpty(OrderTypeName))
            {
                OrderTypeName = OrderTypeNameDefine.contractnumber.ToString();
            }
            Sys_OrderNumber sysOrderNumber = Sys_OrderNumber.GetSys_OrderNumberByRoomID(OrderTypeName, RoomID);
            if (sysOrderNumber == null)
            {
                OrderNumberID = 0;
                return string.Empty;
            }
            OrderNumberID = sysOrderNumber.ID;
            Contract contract = Contract.GetLastContract(OrderNumberID);
            string Part1 = string.Empty;
            Part1 += sysOrderNumber.OrderPrefix;
            string time_yyyy = DateTime.Now.ToString("yyyy");
            string time_mm = DateTime.Now.ToString("MM");
            string time_dd = DateTime.Now.ToString("dd");
            if (sysOrderNumber.UseYear)
            {
                Part1 += time_yyyy;
            }
            if (sysOrderNumber.UseMonth)
            {
                Part1 += time_mm;
            }
            if (sysOrderNumber.UseDay)
            {
                Part1 += time_dd;
            }
            int OrderNumberCount = sysOrderNumber.OrderNumberCount <= 0 ? 3 : sysOrderNumber.OrderNumberCount;
            int number = 1;
            if (contract != null && !string.IsNullOrEmpty(contract.ContractNo))
            {
                number = PrintRoomFeeHistory.GetOrderNumberBySysOrder(contract.ContractNo, sysOrderNumber, out OrderNumberCount);
            }
            return Part1 + number.ToString("D" + OrderNumberCount);
        }
        public static Contract GetLastContract(int OrderNumberID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            //conditions.Add("ChargeTime is not null");
            conditions.Add("[AddTime]>=@AddTime");
            conditions.Add("isnull([OrderNumberID],0)=@OrderNumberID");
            parameters.Add(new SqlParameter("@OrderNumberID", OrderNumberID));
            DateTime start = DateTime.Today.AddDays(1 - DateTime.Now.Day);
            parameters.Add(new SqlParameter("@AddTime", start));
            return GetOne<Contract>("select top 1 * from [Contract] where " + string.Join(" and ", conditions.ToArray()) + " order by AddTime desc", parameters);
        }
        public static Contract[] GetContractListByMinMaxID(int MinID, int MaxID)
        {
            if (MaxID <= 0)
            {
                return new Contract[] { };
            }
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("ID between " + MinID + " and " + MaxID);
            return GetList<Contract>("select * from [Contract] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
        public decimal CalculateEarnCost
        {
            get
            {
                this.ContractDevicePercent = this.ContractDevicePercent > 0 ? this.ContractDevicePercent : 0;
                this.ContractDivideSellCost = this.ContractDivideSellCost > 0 ? this.ContractDivideSellCost : 0;
                return Math.Round((this.ContractDevicePercent * this.ContractDivideSellCost) / 100, 2, MidpointRounding.AwayFromZero);
            }
        }
        public decimal FinalEarnCost
        {
            get
            {
                this.ContractBasicRentCost = this.ContractBasicRentCost > 0 ? this.ContractBasicRentCost : 0;
                if (this.CalculateEarnCost < this.ContractBasicRentCost)
                {
                    return this.ContractBasicRentCost;
                }
                return this.CalculateEarnCost;
            }
        }
        /// <summary>
        /// 1-联营分成 2-保底租金
        /// </summary>
        public int ChargeEarnType
        {
            get
            {
                this.ContractBasicRentCost = this.ContractBasicRentCost > 0 ? this.ContractBasicRentCost : 0;
                if (this.CalculateEarnCost < this.ContractBasicRentCost)
                {
                    return 2;
                }
                return 1;
            }
        }
        public string ChargeEarnTypeDesc
        {
            get
            {
                return this.ChargeEarnType == 1 ? "联营分成" : "保底租金";
            }
        }
    }
    public partial class ContractDetail : Contract
    {
        [DatabaseColumn("TotalCost")]
        public decimal TotalCost { get; set; }
        [DatabaseColumn("ChargedCost")]
        public decimal ChargedCost { get; set; }
        [DatabaseColumn("RestCost")]
        public decimal RestCost { get; set; }
        [DatabaseColumn("PreCost")]
        public decimal PreCost { get; set; }
        [DatabaseColumn("DepositCost")]
        public decimal DepositCost { get; set; }
        [DatabaseColumn("BreakCost")]
        public decimal BreakCost { get; set; }
        [DatabaseColumn("TotalContractArea")]
        public decimal TotalContractArea { get; set; }
        public decimal FinalTotalContractArea
        {
            get
            {
                return this.TotalContractArea > 0 ? this.TotalContractArea : 0;
            }
        }

        public static Ui.DataGrid GetContractDetailGridByKeywords(string Keywords, string ContractStatus, List<int> RoomIDList, List<int> ProjectIDList, DateTime StartTime, DateTime EndTime, DateTime RentStartTime, DateTime RentEndTime, string orderBy, long startRowIndex, int pageSize, int onlyexpired = 0, bool canexport = false)
        {
            long totalRows = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
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
                            cmd += "  and  ([RentName] like '%" + keywords[i] + "%' or [RoomLocation] like '%" + keywords[i] + "%' or [ContractNo] like '%" + keywords[i] + "%' or [ContractName] like '%" + keywords[i] + "%' or [ContractSummary] like '%" + keywords[i] + "%')";
                        }
                        else
                        {
                            cmd += "  ([RentName] like '%" + keywords[i] + "%' or [RoomLocation] like '%" + keywords[i] + "%' or [ContractNo] like '%" + keywords[i] + "%' or [ContractName] like '%" + keywords[i] + "%' or [ContractSummary] like '%" + keywords[i] + "%'))";
                        }
                    }
                    else if (i == 0)
                    {
                        cmd += " and (([RentName] like '%" + keywords[i] + "%' or [RoomLocation] like '%" + keywords[i] + "%' or [ContractNo] like '%" + keywords[i] + "%' or [ContractName] like '%" + keywords[i] + "%' or [ContractSummary] like '%" + keywords[i] + "%') or";
                    }
                    else
                    {
                        cmd += "  ([RentName] like '%" + keywords[i] + "%' or [RoomLocation] like '%" + keywords[i] + "%' or [ContractNo] like '%" + keywords[i] + "%' or [ContractName] like '%" + keywords[i] + "%' or [ContractSummary] like '%" + keywords[i] + "%') or ";
                    }
                }
            }
            #endregion
            if (RentStartTime > DateTime.MinValue)
            {
                conditions.Add("[RentEndTime]>=@RentStartTime");
                parameters.Add(new SqlParameter("@RentStartTime", RentStartTime));
            }
            if (RentEndTime > DateTime.MinValue)
            {
                conditions.Add("[RentEndTime]<=@RentEndTime");
                parameters.Add(new SqlParameter("@RentEndTime", RentEndTime));
            }
            if (!string.IsNullOrEmpty(ContractStatus))
            {
                conditions.Add("[ContractStatus]=@ContractStatus");
                parameters.Add(new SqlParameter("@ContractStatus", ContractStatus));
            }
            if (ProjectIDList.Count > 0)
            {
                List<string> cmdlist = new List<string>();
                foreach (var ProjectID in ProjectIDList)
                {
                    cmdlist.Add("([AllParentID] like '%," + ProjectID + ",%' or [ID] =" + ProjectID + ")");
                }
                conditions.Add("ID in (select ContractID from Contract_Room where [RoomID] in (select [ID] from [Project] where (" + string.Join(" or ", cmdlist.ToArray()) + ")))");
            }
            if (RoomIDList.Count > 0)
            {
                conditions.Add("ID in (select ContractID from Contract_Room where [RoomID] in (" + string.Join(",", RoomIDList.ToArray()) + "))");
            }
            if (StartTime > DateTime.MinValue)
            {
                conditions.Add("[SignTime]>=@StartTime");
                parameters.Add(new SqlParameter("@StartTime", StartTime));
            }
            if (EndTime > DateTime.MinValue)
            {
                conditions.Add("[SignTime]<=@EndTime");
                parameters.Add(new SqlParameter("@EndTime", EndTime));
            }
            string fieldList = "A.*";
            string Statement = @" from (select *,(select sum(isnull(ContractArea,0)) from [RoomBasic] where ([RoomID] 
in (select [RoomID] from [Contract_RoomCharge] where [ContractID]=[Contract].ID)
or ([RoomID] in (select [RoomID] from [Contract_Room] where [ContractID]=[Contract].ID
and exists(select 1 from [Contract_RoomCharge] where [ContractID]=[Contract].ID and [RoomID]=0)
))
)) as TotalContractArea from [Contract]) A where  " + string.Join(" and ", conditions.ToArray()) + cmd;
            var list = GetList<ContractDetail>("select " + fieldList + Statement + " " + orderBy, parameters).ToArray();
            SetContractWarningCount(list);
            if (onlyexpired == 1)
            {
                string ContractStatusDesc = Utility.EnumModel.ContractStatus.tongguo.ToString();
                list = list.Where(p => p.IsRentExpire).ToArray();
            }
            if (!canexport)
            {
                list = list.Skip((int)startRowIndex).Take(pageSize).ToArray();
            }
            totalRows = list.Length;
            var footeritem = new ContractDetail();
            GetContractFeeSummary(list, out footeritem, outfooter: true);
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.footer = new ContractDetail[] { footeritem };
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
        public static void GetContractFeeSummary(ContractDetail[] list)
        {
            ContractDetail footeritem = null;
            GetContractFeeSummary(list, out footeritem, outfooter: true);
        }
        public static void GetContractFeeSummary(ContractDetail[] list, out ContractDetail footeritem, bool outfooter = false)
        {
            List<int> ContractIDList = list.Select(p => p.ID).ToList();
            var fee_list = RoomFeeAnalysis.GetRoomFeeAnalysisListByContractIDList(ContractIDList);
            var feehistory_list = ViewRoomFeeHistory.GetViewRoomFeeHistoryListByContractIDList(ContractIDList);
            var fee_weiyue_list = RoomFeeAnalysis.GetContractFeeWeiYueListByContractIDList(ContractIDList);
            decimal totalRestCost = 0;
            decimal totalChargedCost = 0;
            decimal totalPreCost = 0;
            decimal totalDepositCost = 0;
            decimal totalBreakCost = 0;
            decimal totalTotalCost = 0;
            foreach (var item in list)
            {
                item.RestCost = fee_list.Where(p => p.ContractID == item.ID && p.TotalCost > 0).Sum(p => p.TotalCost);
                item.ChargedCost = feehistory_list.Where(p => p.ContractID == item.ID && p.RealCost > 0).Sum(p => p.RealCost);
                item.PreCost = feehistory_list.Where(p => p.ContractID == item.ID && p.RealCost > 0 && p.CategoryID == 4).Sum(p => p.RealCost);
                item.DepositCost = feehistory_list.Where(p => p.ContractID == item.ID && p.RealCost > 0 && p.CategoryID == 3).Sum(p => p.RealCost);
                item.TotalCost = item.RestCost + item.ChargedCost;
                item.BreakCost = 0;
                totalRestCost += item.RestCost;
                totalChargedCost += item.ChargedCost;
                totalPreCost += item.PreCost;
                totalDepositCost += item.DepositCost;
                totalBreakCost += fee_weiyue_list.Where(p => p.RelatedFeeID == item.ID && p.TotalCost > 0).Sum(p => p.TotalCost);
                totalTotalCost += item.TotalCost;
            }
            footeritem = new ContractDetail();
            footeritem.ContractNo = "合计";
            footeritem.RestCost = totalRestCost;
            footeritem.ChargedCost = totalChargedCost;
            footeritem.PreCost = totalPreCost;
            footeritem.DepositCost = totalDepositCost;
            footeritem.TotalCost = totalTotalCost;
            footeritem.BreakCost = totalBreakCost;
        }
        public static void SetContractWarningCount(ContractDetail[] list)
        {
            if (list.Length == 0)
            {
                return;
            }
            var sysConfig = SysConfig.GetSysConfigByName(SysConfigNameDefine.ContractWarning.ToString());
            if (sysConfig != null)
            {
                var contractRoomList = Contract_RoomDetail.GetContract_RoomDetailListByMinMaxContractID(list.Min(p => p.ID), list.Max(p => p.ID));
                int MinProjectID = 0;
                int MaxProjectID = 0;
                if (contractRoomList.Length > 0)
                {
                    MinProjectID = contractRoomList.Min(p => p.RoomID);
                    MaxProjectID = contractRoomList.Max(p => p.RoomID);
                }
                var configProjectList = SysConfig_ProjectDetail.Get_SysConfig_ProjectListByProjectIDList(MinProjectID, MaxProjectID).Where(p => p.ConfigID == sysConfig.ID).ToArray();
                foreach (var item in list)
                {
                    var myContractRoomList = contractRoomList.Where(p => p.ContractID == item.ID).ToArray();
                    foreach (var item2 in myContractRoomList)
                    {
                        var myConfig = SysConfig_ProjectDetail.GetSysConfig_ProjectDetailByAllParentID(configProjectList, item2.AllParentID, item2.RoomID);
                        int myConfigValue = 0;
                        if (myConfig != null)
                        {
                            int.TryParse(myConfig.ConfigValue, out myConfigValue);
                        }
                        else
                        {
                            int.TryParse(sysConfig.Value, out myConfigValue);
                        }
                        if (item.ContractWarningDayCount <= myConfigValue)
                        {
                            item.ContractWarningDayCount = myConfigValue;
                        }
                    }
                }
            }
        }
    }
}
