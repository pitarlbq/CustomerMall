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
    /// This object represents the properties and methods of a Mall_BusinessBalance.
    /// </summary>
    public partial class Mall_BusinessBalance : EntityBase
    {
        public static Mall_BusinessBalance[] GetMall_BusinessBalanceListByRuleIDList(List<int> RuleIDList)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (RuleIDList.Count == 0)
            {
                return new Mall_BusinessBalance[] { };
            }
            conditions.Add("[BalanceRuleID] in (" + string.Join(",", RuleIDList.ToArray()) + ")");
            string sqlText = "select * from [Mall_BusinessBalance] where " + string.Join(" and ", conditions.ToArray());
            return GetList<Mall_BusinessBalance>(sqlText, parameters).ToArray();
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
                    default:
                        break;
                }
                return desc;
            }
        }
    }
    public partial class Mall_BusinessBalanceDetail : Mall_BusinessBalance
    {
        [DatabaseColumn("BusinessName")]
        public string BusinessName { get; set; }
        [DatabaseColumn("BusinessContactMan")]
        public string BusinessContactMan { get; set; }

        [DatabaseColumn("BalanceRuleName")]
        public string BalanceRuleName { get; set; }
        public string FinalBusinessName
        {
            get
            {
                if (string.IsNullOrEmpty(this.BusinessName))
                {
                    if (this.BusinessID <= 0)
                    {
                        this.BusinessName = "福顺居自营";
                    }
                    else
                    {
                        this.BusinessName = "商户已删除";
                    }
                }
                return this.BusinessName;
            }
        }

        public static Ui.DataGrid GetMall_BusinessBalanceDetailGridByKeywords(string Keywords, DateTime StartTime, DateTime EndTime, int BalanceStatus, long startRowIndex, int pageSize)
        {
            long totalRows = 0;
            string OrderBy = " order by AddTime desc";
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
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
                conditions.Add("([BusinessID] in (select [ID] from [Mall_Business] where [BusinessName] like @keywords))");
                parameters.Add(new SqlParameter("@keywords", "%" + Keywords + "%"));
            }
            string fieldList = "A.*";
            string Statement = " from (select [Mall_BusinessBalance].*,[Mall_Business].BusinessName,[Mall_Business].ContactName as BusinessContactMan from [Mall_BusinessBalance] left join [Mall_Business] on [Mall_Business].ID=[Mall_BusinessBalance].BusinessID)A where  " + string.Join(" and ", conditions.ToArray());
            Mall_BusinessBalanceDetail[] list = GetList<Mall_BusinessBalanceDetail>(fieldList, Statement, parameters, OrderBy, startRowIndex, pageSize, out totalRows).ToArray();
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
}
