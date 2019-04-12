using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;

using Foresight.DataAccess.Framework;

namespace Foresight.DataAccess
{
    /// <summary>
    /// This object represents the properties and methods of a PaySummary.
    /// </summary>
    public partial class PaySummary : EntityBase
    {
        public static Ui.DataGrid GetPaySummaryGridByKeywords(string Keywords, string orderBy, long startRowIndex, int pageSize)
        {
            long totalRows = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            #region 关键字查询
            string cmd = string.Empty;
            if (!string.IsNullOrEmpty(Keywords))
            {
                conditions.Add("[PayName] like @Keywords");
                parameters.Add(new SqlParameter("@Keywords", "%" + Keywords + "%"));
            }
            #endregion
            string fieldList = "[PaySummary].*";
            string Statement = " from [PaySummary] where  " + string.Join(" and ", conditions.ToArray()) + cmd;
            PaySummary[] list = new PaySummary[] { };
            list = GetList<PaySummary>(fieldList, Statement, parameters, orderBy, startRowIndex, pageSize, out totalRows).ToArray();
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
        public string RelateFeeTypeDesc
        {
            get
            {
                List<string> desclist = new List<string>();
                if (this.RelateFeeType_Pay)
                {
                    desclist.Add("付款单据");
                }
                if (desclist.Count > 0)
                {
                    return string.Join(",", desclist);
                }
                return string.Empty;
            }
        }
    }
    public partial class PaySummaryDetail : PaySummary
    {
        [DatabaseColumn("TotalMoney")]
        public decimal TotalMoney { get; set; }
        public static PaySummaryDetail[] GetPaySummaryDetailListByRoomID(List<int> RoomIDList, List<int> ProjectIDList, DateTime StartTime, DateTime EndTime, int UserID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (StartTime > DateTime.MinValue)
            {
                conditions.Add("[PayTime]>=@StartTime");
                parameters.Add(new SqlParameter("@StartTime", StartTime));
            }
            if (EndTime > DateTime.MinValue)
            {
                conditions.Add("[PayTime]<=@EndTime");
                parameters.Add(new SqlParameter("@EndTime", EndTime));
            }
            if (RoomIDList.Count > 0)
            {
                List<string> cmdlist = ViewRoomFeeHistory.GetRoomIDListConditions(RoomIDList, IncludeRelation: false, RoomIDName: "[ProjectID]");
                conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
            }
            if (ProjectIDList.Count > 0)
            {
                List<string> cmdlist = ViewRoomFeeHistory.GetProjectIDListConditions(ProjectIDList, IncludeRelation: false, RoomIDName: "[ProjectID]", UserID: UserID);
                conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
            }
            string Statement = @" select*,A.TotalMoney from PaySummary left join
(
select PaySummaryID, sum(isnull(PayMoney,0)) as TotalMoney from PayService where " + string.Join(" and ", conditions) + @" group by PaySummaryID
)A on A.PaySummaryID=PaySummary.ID";
            PaySummaryDetail[] list = GetList<PaySummaryDetail>(Statement, parameters).ToArray();
            return list;
        }
    }
    public partial class PaySummaryAnalysis : EntityBaseReadOnly
    {
        [DatabaseColumn("ProjectID")]
        public int ProjectID { get; set; }
        [DatabaseColumn("PaySummaryID")]
        public int PaySummaryID { get; set; }
        [DatabaseColumn("TotalCost")]
        public decimal TotalCost { get; set; }
        [DatabaseColumn("FullName")]
        public string FullName { get; set; }
        [DatabaseColumn("Name")]
        public string Name { get; set; }
        [DatabaseColumn("DefaultOrder")]
        public string DefaultOrder { get; set; }
        [DatabaseColumn("ProjectName")]
        public string ProjectName { get; set; }
        [DatabaseColumn("RoomName")]
        public string RoomName { get; set; }
        protected override void EnsureParentProperties()
        {
        }
        public static Ui.DataGrid GetPaySummaryAnalysisGrid(List<int> ProjectIDList, List<int> RoomIDList, DateTime StartTime, DateTime EndTime, string orderBy, long startRowIndex, int pageSize, int UserID = 0, bool canexport = false)
        {
            List<string> conditions = new List<string>();
            List<SqlParameter> parameters = new List<SqlParameter>();
            conditions.Add("1=1");
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
            if (StartTime > DateTime.MinValue)
            {
                conditions.Add("[PayTime]>=@StartTime");
                parameters.Add(new SqlParameter("@StartTime", StartTime));
            }
            if (EndTime > DateTime.MinValue)
            {
                conditions.Add("[PayTime]<=@EndTime");
                parameters.Add(new SqlParameter("@EndTime", EndTime));
            }
            long totalRows = 0;
            string fieldList = "B.*";
            string Statement = " from (select A.*,Project.FullName,Project.Name,Project.DefaultOrder from (select ProjectID,ProjectName,RoomName,sum(PayMoney) as TotalCost from PayService where [ProjectID]>0 and " + string.Join(" and ", conditions.ToArray()) + " group by ProjectID,ProjectName,RoomName)A left join Project on Project.ID=A.ProjectID )B where B.TotalCost>0";
            PaySummaryAnalysis[] list = new PaySummaryAnalysis[] { };
            if (canexport)
            {
                list = GetList<PaySummaryAnalysis>("select " + fieldList + Statement + " " + orderBy, parameters).ToArray();
            }
            else
            {
                list = GetList<PaySummaryAnalysis>(fieldList, Statement, parameters, orderBy, startRowIndex, pageSize, out totalRows).ToArray();
            }
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
        public static PaySummaryAnalysis[] GetPaySummaryAnalysisList(List<int> ProjectIDList, List<int> RoomIDList, DateTime StartTime, DateTime EndTime, int UserID = 0)
        {
            List<string> conditions = new List<string>();
            List<SqlParameter> parameters = new List<SqlParameter>();
            conditions.Add("1=1");
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
            if (StartTime > DateTime.MinValue)
            {
                conditions.Add("[PayTime]>=@StartTime");
                parameters.Add(new SqlParameter("@StartTime", StartTime));
            }
            if (EndTime > DateTime.MinValue)
            {
                conditions.Add("[PayTime]<=@EndTime");
                parameters.Add(new SqlParameter("@EndTime", EndTime));
            }
            string cmdtext = "select A.* from (select ProjectID,PaySummaryID,sum(PayMoney) as TotalCost from PayService where " + string.Join(" and ", conditions.ToArray()) + " group by ProjectID, PaySummaryID)A where A.TotalCost>0";
            PaySummaryAnalysis[] list = GetList<PaySummaryAnalysis>(cmdtext, parameters).ToArray();
            return list;
        }
    }
}
