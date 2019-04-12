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
    /// This object represents the properties and methods of a Mall_RoomOwnerBalance.
    /// </summary>
    public partial class Mall_RoomOwnerBalance : EntityBase
    {
        public static Mall_RoomOwnerBalance[] GetMall_RoomOwnerBalanceListByIDList(List<int> IDList)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (IDList.Count == 0)
            {
                return new Mall_RoomOwnerBalance[] { };
            }
            conditions.Add("[ID] in (" + string.Join(",", IDList.ToArray()) + ")");
            string cmdtext = "select * from [Mall_RoomOwnerBalance] where  " + string.Join(" and ", conditions.ToArray());
            return GetList<Mall_RoomOwnerBalance>(cmdtext, parameters).ToArray();
        }
        public string BalanceStatusDesc
        {
            get
            {
                string desc = "待申请";
                switch (this.BalanceStatus)
                {
                    case 1:
                        desc = "待结算";
                        break;
                    case 2:
                        desc = "已结算";
                        break;
                    case 3:
                        desc = "审核未通过";
                        break;
                    case 4:
                        desc = "待申请";
                        break;
                    default:
                        break;
                }
                return desc;
            }
        }
        public string ApproveStatusDesc
        {
            get
            {
                string desc = "待申请";
                switch (this.BalanceStatus)
                {
                    case 1:
                        desc = "待审核";
                        break;
                    case 2:
                        desc = "审核通过";
                        break;
                    case 3:
                        desc = "审核未通过";
                        break;
                    case 4:
                        desc = "待申请";
                        break;
                    default:
                        break;
                }
                return desc;
            }
        }
    }
    public partial class Mall_RoomOwnerBalanceDetail : Mall_RoomOwnerBalance
    {
        [DatabaseColumn("RoomOwnerName")]
        public string RoomOwnerName { get; set; }
        [DatabaseColumn("FullName")]
        public string FullName { get; set; }
        [DatabaseColumn("RoomName")]
        public string RoomName { get; set; }

        [DatabaseColumn("BalanceRuleName")]
        public string BalanceRuleName { get; set; }
        public string FinalFullName
        {
            get
            {
                return this.FullName + "-" + this.RoomName;
            }
        }
        public static Ui.DataGrid GetMall_RoomOwnerBalanceDetailGridByKeywords(string Keywords, DateTime StartTime, DateTime EndTime, int BalanceStatus, long startRowIndex, int pageSize, List<int> RoomIDList, List<int> ProjectIDList, int UserID = 0)
        {
            long totalRows = 0;
            string OrderBy = " order by AddTime desc";
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (RoomIDList.Count > 0)
            {
                conditions.Add("[ProjectID] in (" + string.Join(",", RoomIDList.ToArray()) + ")");
            }
            if (ProjectIDList.Count > 0)
            {
                List<string> cmdlist = ViewRoomFeeHistory.GetProjectIDListConditions(ProjectIDList, RoomIDName: "[ProjectID]", UserID: UserID);
                conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
            }
            if (BalanceStatus == 23)
            {
                conditions.Add("[BalanceStatus] in (2,3)");
            }
            else if (BalanceStatus > 0)
            {
                conditions.Add("[BalanceStatus]=@BalanceStatus");
                parameters.Add(new SqlParameter("@BalanceStatus", BalanceStatus));
            }
            if (StartTime > DateTime.MinValue)
            {
                conditions.Add("[AddTime]>=@StartTime");
                parameters.Add(new SqlParameter("@StartTime", StartTime));
            }
            if (EndTime > DateTime.MinValue)
            {
                conditions.Add("[AddTime]<=@EndTime");
                parameters.Add(new SqlParameter("@EndTime", EndTime));
            }
            if (!string.IsNullOrEmpty(Keywords))
            {
                conditions.Add("([RoomOwnerName] like @keywords)");
                parameters.Add(new SqlParameter("@keywords", "%" + Keywords + "%"));
            }
            string fieldList = "A.*";
            string Statement = " from (select [Mall_RoomOwnerBalance].*,[RoomPhoneRelation].RelationName as RoomOwnerName,[Project].FullName,[Project].Name as RoomName from [Mall_RoomOwnerBalance] left join [RoomPhoneRelation] on [RoomPhoneRelation].ID=[Mall_RoomOwnerBalance].RoomPhoneRelationID left join [Project] on [Project].ID=[RoomPhoneRelation].RoomID)A where  " + string.Join(" and ", conditions.ToArray());
            Mall_RoomOwnerBalanceDetail[] list = GetList<Mall_RoomOwnerBalanceDetail>(fieldList, Statement, parameters, OrderBy, startRowIndex, pageSize, out totalRows).ToArray();
            var rule_list = Mall_BalanceRule.GetMall_BalanceRules().ToArray();
            foreach (var item in list)
            {
                var my_rule = rule_list.FirstOrDefault(p => p.ID == item.BalanceRuleID);
                if (my_rule != null)
                {
                    item.BalanceRuleName = my_rule.Title;
                }
            }
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
    }
    public partial class Mall_RoomOwnerBalanceApplicationDetail : EntityBaseReadOnly
    {
        [DatabaseColumn("RoomID")]
        public int RoomID { get; set; }
        [DatabaseColumn("FullName")]
        public string FullName { get; set; }
        [DatabaseColumn("RoomName")]
        public string RoomName { get; set; }
        [DatabaseColumn("TotalCost")]
        public decimal TotalCost { get; set; }
        [DatabaseColumn("TotalBalanceAmount")]
        public decimal TotalBalanceAmount { get; set; }
        public decimal TotalRestCost
        {
            get
            {
                decimal cost = TotalCost - TotalBalanceAmount;
                return cost > 0 ? cost : 0;
            }
        }
        public string FinalFullName
        {
            get
            {
                return this.FullName + "-" + this.RoomName;
            }
        }
        public static Ui.DataGrid GetMall_RoomOwnerBalanceDetailApplicationGridByKeywords(string Keywords, long startRowIndex, int pageSize, List<int> RoomIDList, List<int> ProjectIDList, DateTime StartTime, DateTime EndTime, int UserID = 0)
        {
            var room_list = ViewRoomBasic.GetRoomBasicListByKeywords(RoomIDList, ProjectIDList, Keywords, HavingOrder: true);
            if (room_list.Length == 0)
            {
                return new Ui.DataGrid();
            }
            var order_analysis_list = Mall_OrderAnalysis.GetMall_OrderAnalysisList(StartTime, EndTime);
            var user_project_list = Mall_UserProject.GetMall_UserProjectListHavingOrders();
            var balance_list = Mall_RoomOwnerBalanceAnalysis.GetMall_RoomOwnerBalanceAnalysisList();
            List<Mall_RoomOwnerBalanceApplicationDetail> list = new List<Mall_RoomOwnerBalanceApplicationDetail>();
            foreach (var item in room_list)
            {
                var my_user_project_list = user_project_list.Where(p => p.ProjectID == item.RoomID).ToArray();
                if (my_user_project_list.Length == 0)
                {
                    continue;
                }
                var my_useridlist = my_user_project_list.Select(p => p.UserID).ToArray();
                var my_order_analysis_list = order_analysis_list.Where(p => my_useridlist.Contains(p.UserID)).ToArray();
                if (my_order_analysis_list.Length == 0)
                {
                    continue;
                }
                var data = new Mall_RoomOwnerBalanceApplicationDetail();
                data.RoomID = item.RoomID;
                data.FullName = item.FullName;
                data.RoomName = item.Name;
                data.TotalCost = my_order_analysis_list.Sum(p => p.TotalCost);
                var my_balance_list = balance_list.Where(p => p.ProjectID == item.RoomID).ToArray();
                data.TotalBalanceAmount = my_balance_list.Sum(p => p.TotalCost);
                if (data.TotalCost > 0)
                {
                    list.Add(data);
                }
            }
            var finallist = list.Skip(Convert.ToInt32(startRowIndex)).Take(pageSize).ToArray();
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = finallist;
            dg.total = list.Count;
            dg.page = pageSize;
            return dg;
        }

        protected override void EnsureParentProperties()
        {
            throw new NotImplementedException();
        }
    }
    public partial class Mall_RoomOwnerBalanceAnalysis : EntityBaseReadOnly
    {
        [DatabaseColumn("ProjectID")]
        public int ProjectID { get; set; }
        [DatabaseColumn("TotalCost")]
        public decimal TotalCost { get; set; }
        public static Mall_RoomOwnerBalanceAnalysis[] GetMall_RoomOwnerBalanceAnalysisList()
        {
            string cmdtext = "select sum(TotalCost) as TotalCost,[ProjectID] from Mall_RoomOwnerBalance where BalanceStatus!=3 group by [ProjectID]";
            Mall_RoomOwnerBalanceAnalysis[] list = GetList<Mall_RoomOwnerBalanceAnalysis>(cmdtext, new List<SqlParameter>()).ToArray();
            return list;
        }
        protected override void EnsureParentProperties()
        {
            throw new NotImplementedException();
        }
    }
}
