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
    /// This object represents the properties and methods of a ChargeMeter_ProjectFee.
    /// </summary>
    public partial class ChargeMeter_ProjectFee : EntityBase
    {
        public static ChargeMeter_ProjectFee[] GetChargeMeter_ProjectFeeListbyIDList(int[] IDList)
        {
            var parameters = new List<SqlParameter>();
            string cmdtext = "select * from [ChargeMeter_ProjectFee] where [ID] in (" + string.Join(",", IDList) + ")";
            return GetList<ChargeMeter_ProjectFee>(cmdtext, parameters).ToArray();
        }
        public static int GetIsChargedMeter_ProjectFeeCountbyIDList(int[] IDList)
        {
            var parameters = new List<SqlParameter>();
            string cmdtext = "select count(1) from [ChargeMeter_ProjectFee] where [ID] in (" + string.Join(",", IDList) + ") and ([IsDeleted]=0 or [IsDeleted] is null) and exists (select 1 from [RoomFeeHistory] where ChargeState in (1,4) and [RoomFeeHistory].[ChargeMeterProjectFeeID]=[ChargeMeter_ProjectFee].[ID])";
            int total = 0;
            using (SqlHelper helper = new SqlHelper())
            {
                var result = helper.ExecuteScalar(cmdtext, CommandType.Text, parameters);
                if (result != null)
                {
                    int.TryParse(result.ToString(), out total);
                }
            }
            return total;
        }
        public static int GetChargeMeter_ProjectFeeCountbyMeterProjectIDList(int[] MeterProjectIDList)
        {
            var parameters = new List<SqlParameter>();
            string cmdtext = "select count(1) from [ChargeMeter_ProjectFee] where [MeterProjectID] in (" + string.Join(",", MeterProjectIDList) + ") and ([IsDeleted]=0 or [IsDeleted] is null)";
            int total = 0;
            using (SqlHelper helper = new SqlHelper())
            {
                var result = helper.ExecuteScalar(cmdtext, CommandType.Text, parameters);
                if (result != null)
                {
                    int.TryParse(result.ToString(), out total);
                }
            }
            return total;
        }
        public static bool Save_ChargeMeter_ProjectFee(int[] MeterProjectIDList, DateTime WriteDate, decimal Coefficient, decimal SummaryUnitPrice, DateTime StartTime, DateTime EndTime, string AddUserName, out string errormsg, List<int> ChargeIDList)
        {
            errormsg = string.Empty;
            var meter_project_list = ChargeMeter_ProjectDetail.GetChargeMeter_ProjectDetailListByIDList(MeterProjectIDList);
            if (meter_project_list.FirstOrDefault(p => p.RoomOwnerCount <= 0) != null && new Utility.SiteConfig().CheckOwnerInStatus)
            {
                errormsg = "选中的房间尚未有业主入住";
                return false;
            }
            if (meter_project_list.Length == 0)
            {
                errormsg = "请选择一条数据，操作取消";
                return false;
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    List<int> RoomFeeIDList = new List<int>();
                    foreach (var ChargeID in ChargeIDList)
                    {
                        foreach (var item in meter_project_list)
                        {
                            string cmdtext = "update [ChargeMeter_Project] set [WriteStatus]=1,[FeeStatus]=1 where ID=" + item.ID + ";";
                            helper.Execute(cmdtext, CommandType.Text, new List<SqlParameter>());
                            var data = new ChargeMeter_ProjectFee();
                            data.MeterProjectID = item.ID;
                            data.MeterID = item.MeterID;
                            data.ProjectID = item.ProjectID;
                            data.MeterName = item.MeterName;
                            data.MeterNumber = item.MeterNumber;
                            data.MeterCategoryID = item.MeterCategoryID;
                            data.MeterType = item.MeterType;
                            data.MeterSpec = item.MeterSpec;
                            data.MeterCoefficient = Coefficient;
                            data.MeterRemark = item.MeterRemark;
                            data.MeterChargeID = ChargeID;
                            data.MeterHouseNo = item.MeterHouseNo;
                            data.MeterLocation = item.MeterLocation;
                            data.SortOrder = item.SortOrder;
                            data.MeterStartPoint = item.FinalFeeStartPoint;
                            data.MeterEndPoint = item.FinalFeeEndPoint;
                            data.MeterTotalPoint = item.FinalFeeTotalPoint;
                            data.AddTime = DateTime.Now;
                            data.AddUserName = AddUserName;
                            data.MeterStartTime = StartTime;
                            data.MeterEndTime = EndTime;
                            data.MeterWriteDate = WriteDate;
                            data.WriteDate = item.WriteDate;
                            data.WriteUserName = item.WriteUserName;
                            var room_fee = RoomFee.SetInfo_RoomFee(data.ProjectID, data.MeterStartTime, data.MeterEndTime, 0, 0, SummaryUnitPrice, ChargeID, IsMeterFee: true, RoomFeeCoefficient: data.MeterCoefficient, RoomFeeWriteDate: WriteDate, UseCount: data.MeterTotalPoint, RoomFeeStartPoint: data.MeterStartPoint, RoomFeeEndPoint: data.MeterEndPoint, cansave: true, helper: helper);
                            data.RoomFeeID = room_fee.ID;
                            data.Save(helper);
                            room_fee.ChargeMeterProjectFeeID = data.ID;
                            room_fee.Save(helper);
                            RoomFeeIDList.Add(room_fee.ID);
                        }
                    }
                    ChargeFeePriceRange.CreateChargeFeePriceRangeByImportFeeIDList(helper, RoomFeeIDList: RoomFeeIDList);
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    Utility.LogHelper.WriteError("ChargeMeter_ProjectFee.cs", "Save_ChargeMeter_ProjectFee", ex);
                    helper.Rollback();
                    errormsg = ex.Message;
                    return false;
                }
            }
            return true;
        }
        public string MeterCategoryName
        {
            get
            {
                if (this.MeterCategoryID == 1)
                {
                    return "水表";
                }
                if (this.MeterCategoryID == 2)
                {
                    return "电表";
                }
                if (this.MeterCategoryID == 3)
                {
                    return "气表";
                }
                return "";
            }
        }
        public string MeterTypeName
        {
            get
            {
                if (this.MeterType == 1)
                {
                    return "住户";
                }
                if (this.MeterType == 2)
                {
                    return "公共";
                }
                return "";
            }
        }
        public string MeterSpecDesc
        {
            get
            {
                if (this.MeterSpec == 1)
                {
                    return "分表";
                }
                if (this.MeterSpec == 2)
                {
                    return "总表";
                }
                return "";
            }
        }
    }
    public partial class ChargeMeter_ProjectFeeDetail : ChargeMeter_ProjectFee
    {
        [DatabaseColumn("ProjectName")]
        public string ProjectName { get; set; }

        [DatabaseColumn("FullName")]
        public string FullName { get; set; }
        [DatabaseColumn("DefaultOrder")]
        public string DefaultOrder { get; set; }
        [DatabaseColumn("isParent")]
        public bool isParent { get; set; }
        [DatabaseColumn("ChargeName")]
        public string ChargeName { get; set; }
        [DatabaseColumn("RealRoomFeeID")]
        public int RealRoomFeeID { get; set; }
        [DatabaseColumn("RealRoomFeeHistoryID")]
        public int RealRoomFeeHistoryID { get; set; }
        [DatabaseColumn("ChargeState")]
        public int ChargeState { get; set; }
        [DatabaseColumn("PrintNumber")]
        public string PrintNumber { get; set; }
        [DatabaseColumn("ChargeTime")]
        public DateTime ChargeTime { get; set; }
        [DatabaseColumn("ChargeMan")]
        public string ChargeMan { get; set; }
        [DatabaseColumn("RoomFeeUnitPrice")]
        public decimal RoomFeeUnitPrice { get; set; }
        [DatabaseColumn("RoomFeeCoefficient")]
        public decimal RoomFeeCoefficient { get; set; }
        [DatabaseColumn("HistoryFeeUnitPrice")]
        public decimal HistoryFeeUnitPrice { get; set; }
        [DatabaseColumn("HistoryFeeCoefficient")]
        public decimal HistoryFeeCoefficient { get; set; }
        [DatabaseColumn("EndNumberCount")]
        public int EndNumberCount { get; set; }
        [DatabaseColumn("RoomFeeStartTime")]
        public DateTime RoomFeeStartTime { get; set; }
        [DatabaseColumn("RoomFeeEndTime")]
        public DateTime RoomFeeEndTime { get; set; }
        [DatabaseColumn("HistoryFeeStartTime")]
        public DateTime HistoryFeeStartTime { get; set; }
        [DatabaseColumn("HistoryFeeEndTime")]
        public DateTime HistoryFeeEndTime { get; set; }
        public decimal FinalUnitPrice
        {
            get
            {
                if (this.RoomFeeUnitPrice > 0)
                {
                    return this.RoomFeeUnitPrice;
                }
                if (this.HistoryFeeUnitPrice > 0)
                {
                    return this.HistoryFeeUnitPrice;
                }
                return 0;
            }
        }
        public DateTime FinalStartTime
        {
            get
            {
                if (this.RoomFeeStartTime > DateTime.MinValue)
                {
                    return this.RoomFeeStartTime;
                }
                if (this.HistoryFeeStartTime > DateTime.MinValue)
                {
                    return this.HistoryFeeStartTime;
                }
                return this.MeterStartTime;
            }
        }
        public DateTime FinalEndTime
        {
            get
            {
                if (this.RoomFeeEndTime > DateTime.MinValue)
                {
                    return this.RoomFeeEndTime;
                }
                if (this.HistoryFeeEndTime > DateTime.MinValue)
                {
                    return this.HistoryFeeEndTime;
                }
                return this.MeterEndTime;
            }
        }
        public decimal FinalCoefficient
        {
            get
            {
                if (this.RoomFeeCoefficient > 0)
                {
                    return this.RoomFeeCoefficient;
                }
                if (this.HistoryFeeCoefficient > 0)
                {
                    return this.HistoryFeeCoefficient;
                }
                return 1;
            }
        }
        public decimal FinalTotalCost
        {
            get
            {
                this.EndNumberCount = this.EndNumberCount > 0 ? this.EndNumberCount : 0;
                return Math.Round((this.FinalUnitPrice * this.FinalCoefficient * this.MeterTotalPoint), EndNumberCount, MidpointRounding.AwayFromZero);
            }
        }
        public string FinalName
        {
            get
            {
                return this.isParent ? this.FullName : this.FullName + "-" + this.ProjectName;
            }
        }
        /// <summary>
        /// 1-未收 2-已收 3-部分收款 4-已作废 5-催收中 0-已删除
        /// </summary>
        public int FinalChargeState
        {
            get
            {
                if (this.RealRoomFeeID > 0)
                {
                    if (this.RealRoomFeeHistoryID > 0)
                    {
                        if (this.ChargeState == 1 || this.ChargeState == 4)
                        {
                            return 3;
                        }
                    }
                    return 1;
                }
                if (this.RealRoomFeeHistoryID > 0)
                {
                    if (this.ChargeState == 1 || this.ChargeState == 4)
                    {
                        return 2;
                    }
                    if (this.ChargeState == 5)
                    {
                        return 5;
                    }
                    return 4;
                }
                return 0;
            }
        }
        public bool IsCharged
        {
            get
            {
                return this.FinalChargeState == 2 || FinalChargeState == 3 ? true : false;
            }
        }
        public string ChargeStateDesc
        {
            get
            {
                if (this.FinalChargeState == 1)
                {
                    return "未收";
                }
                if (this.FinalChargeState == 2)
                {
                    return "已收";
                }
                if (this.FinalChargeState == 3)
                {
                    return "部分收款";
                }
                if (this.FinalChargeState == 4)
                {
                    return "已作废";
                }
                if (this.FinalChargeState == 5)
                {
                    return "催收中";
                }
                return "已删除";
            }
        }
        public static string CommSqlText = "(select [ChargeMeter_ProjectFee].*,[ChargeSummary].Name as ChargeName,[ChargeSummary].EndNumberCount,[Project].Name as ProjectName,[Project].FullName,[Project].isParent,[Project].DefaultOrder,[RoomFee].ID as RealRoomFeeID,[RoomFee].UnitPrice as RoomFeeUnitPrice,[RoomFee].RoomFeeCoefficient,[RoomFee].StartTime as RoomFeeStartTime,[RoomFee].EndTime as RoomFeeEndTime,[RoomFeeHistory].UnitPrice as HistoryFeeUnitPrice,[RoomFeeHistory].[RoomFeeCoefficient] as HistoryFeeCoefficient,[RoomFeeHistory].HistoryID as RealRoomFeeHistoryID,[RoomFeeHistory].[ChargeState],[RoomFeeHistory].[StartTime] as HistoryFeeStartTime,[RoomFeeHistory].[EndTime] as HistoryFeeEndTime,[PrintRoomFeeHistory].PrintNumber,[PrintRoomFeeHistory].ChargeTime,[PrintRoomFeeHistory].ChargeMan from [ChargeMeter_ProjectFee] left join [ChargeSummary] on [ChargeSummary].ID=[ChargeMeter_ProjectFee].[MeterChargeID] left join [Project] on [Project].ID=[ChargeMeter_ProjectFee].[ProjectID] left join [RoomFee] on [RoomFee].ID=ChargeMeter_ProjectFee.RoomFeeID left join [RoomFeeHistory] on RoomFeeHistory.ID=ChargeMeter_ProjectFee.RoomFeeID left join [PrintRoomFeeHistory] on [PrintRoomFeeHistory].ID=[RoomFeeHistory].PrintID)A";
        public static Ui.DataGrid GetChargeMeter_ProjectFeeDetailGridByKeywords(string Keywords, List<int> RoomIDList, List<int> ProjectIDList, int MeterCategoryID, int MeterType, int MeterChargeID, string orderBy, long startRowIndex, int pageSize, int UserID = 0, int ChargeState = 0)
        {
            long totalRows = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("([IsDeleted]=0 or [IsDeleted] is null)");
            if (ChargeState == 1)//已收
            {
                conditions.Add("[ChargeState] in (1,4)");
            }
            if (ChargeState == 2)//未收
            {
                conditions.Add("[RealRoomFeeID]>0");
            }
            if (ChargeState == 3)//作废
            {
                conditions.Add("[ChargeState]=2");
            }
            if (ChargeState == 4)//催收中
            {
                conditions.Add("[ChargeState]=5");
            }
            if (ProjectIDList.Count > 0)
            {
                List<string> cmdlist = ViewRoomFeeHistory.GetProjectIDListConditions(ProjectIDList, IncludeRelation: false, RoomIDName: "[ProjectID]", UserID: UserID);
                conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
            }
            if (RoomIDList.Count > 0)
            {
                List<string> cmdlist = ViewRoomFeeHistory.GetRoomIDListConditions(RoomIDList, IncludeRelation: false, RoomIDName: "[ProjectID]");
                conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
            }
            if (!string.IsNullOrEmpty(Keywords))
            {
                conditions.Add("([MeterName] like @Keywords or [MeterNumber] like @Keywords)");
                parameters.Add(new SqlParameter("@Keywords", "%" + Keywords + "%"));
            }
            if (MeterCategoryID > 0)
            {
                conditions.Add("[MeterCategoryID]=@MeterCategoryID");
                parameters.Add(new SqlParameter("@MeterCategoryID", MeterCategoryID));
            }
            if (MeterType > 0)
            {
                conditions.Add("[MeterType]=@MeterType");
                parameters.Add(new SqlParameter("@MeterType", MeterType));
            }
            if (MeterChargeID > 0)
            {
                conditions.Add("[MeterChargeID]=@MeterChargeID");
                parameters.Add(new SqlParameter("@MeterChargeID", MeterChargeID));
            }
            string cmdcolumns = string.Empty;
            ChargeMeter_ProjectFeeDetail[] list = new ChargeMeter_ProjectFeeDetail[] { };
            string fieldList = @"A.*";
            string Statement = " from " + CommSqlText + " where  " + string.Join(" and ", conditions.ToArray());
            list = GetList<ChargeMeter_ProjectFeeDetail>(fieldList, Statement, parameters, orderBy, startRowIndex, pageSize, out totalRows).ToArray();
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.page = pageSize;
            dg.total = totalRows;
            if (list.Length == 0)
            {
                dg.rows = list;
                return dg;
            }
            var feeList = RoomFeeAnalysis.GetRoomFeeAnalysisListByIDList(list.Select(p => p.RoomFeeID).ToList());
            foreach (var item in list)
            {
                var myFee = feeList.FirstOrDefault(p => p.ID == item.RoomFeeID);
                if (myFee != null)
                {
                    item.RoomFeeUnitPrice = myFee.CalculateUnitPrice;
                }
            }
            dg.rows = list;
            return dg;
        }
    }
}
