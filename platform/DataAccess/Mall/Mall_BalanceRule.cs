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
    /// This object represents the properties and methods of a Mall_BalanceRule.
    /// </summary>
    public partial class Mall_BalanceRule : EntityBase
    {
        public static Ui.DataGrid GetMall_BalanceRuleGridByKeywords(string keywords, long startRowIndex, int pageSize, int RuleType)
        {
            long totalRows = 0;
            string OrderBy = " order by [AddTime] desc";
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (!string.IsNullOrEmpty(keywords))
            {
                conditions.Add("([Title] like @keywords)");
                parameters.Add(new SqlParameter("@keywords", "%" + keywords + "%"));
            }
            if (RuleType > 0)
            {
                conditions.Add("[RuleType]=@RuleType");
                parameters.Add(new SqlParameter("@RuleType", RuleType));
            }
            string fieldList = "Mall_BalanceRule.*";
            string Statement = " from Mall_BalanceRule where  " + string.Join(" and ", conditions.ToArray());
            Mall_BalanceRule[] list = GetList<Mall_BalanceRule>(fieldList, Statement, parameters, OrderBy, startRowIndex, pageSize, out totalRows).ToArray();
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
        public string IsActiveDesc
        {
            get
            {
                return this.IsActive ? "有效" : "失效";
            }
        }
        public string RuleTypeDesc
        {
            get
            {
                if (this.RuleType == 1)
                {
                    return "商家结算";
                }
                if (this.RuleType == 2)
                {
                    return "业主结算";
                }
                return "";
            }
        }
        public string BackBalanceTypeDesc
        {
            get
            {
                if (this.BackBalanceType == 1)
                {
                    return "按比例结算";
                }
                if (this.BackBalanceType == 2)
                {
                    return "固定金额结算";
                }
                return "";
            }
        }
        public string FinalBackAmountDesc
        {
            get
            {
                if (this.BackBalanceType == 1)
                {
                    return this.BackPercent > 0 ? this.BackPercent.ToString() + "%" : "0.00%";
                }
                if (this.BackBalanceType == 2)
                {
                    return this.BackAmount > 0 ? this.BackAmount.ToString() : "0.00";
                }
                return "";
            }
        }
    }
}
