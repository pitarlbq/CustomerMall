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
    /// This object represents the properties and methods of a ZhuangXiu_Rule.
    /// </summary>
    public partial class ZhuangXiu_Rule : EntityBase
    {
        public static Ui.DataGrid GetZhuangXiu_RuleGridByKeywords(string Keywords, string orderBy, long startRowIndex, int pageSize)
        {
            long totalRows = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            string cmd = string.Empty;
            if (!string.IsNullOrEmpty(Keywords))
            {
                conditions.Add("[RuleName] like @Keywords");
                parameters.Add(new SqlParameter("@Keywords", "%" + Keywords + "%"));
            }
            string fieldList = "[ZhuangXiu_Rule].*";
            string Statement = " from [ZhuangXiu_Rule] where  " + string.Join(" and ", conditions.ToArray()) + cmd;
            ZhuangXiu_Rule[] list = GetList<ZhuangXiu_Rule>(fieldList, Statement, parameters, orderBy, startRowIndex, pageSize, out totalRows).ToArray();
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
        public static ZhuangXiu_Rule[] GetZhuangXiu_RuleList(List<int> IDList)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (IDList.Count > 0)
            {
                conditions.Add("[ID] in (" + string.Join(",", IDList.ToArray()) + ")");
            }
            string Statement = "select * from [ZhuangXiu_Rule] where  " + string.Join(" and ", conditions.ToArray());
            return GetList<ZhuangXiu_Rule>(Statement, parameters).ToArray();
        }
        public static ZhuangXiu_Rule[] GetZhuangXiu_RuleListByParams(int[] CategoryIDList = null)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (CategoryIDList != null && CategoryIDList.Length > 0)
            {
                conditions.Add("[RuleCategoryID] in (" + string.Join(",", CategoryIDList) + ")");
            }
            return GetList<ZhuangXiu_Rule>("select * from [ZhuangXiu_Rule] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
    }
}
