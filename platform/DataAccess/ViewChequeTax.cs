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
	/// This object represents the properties and methods of a ViewChequeTax.
	/// </summary>
	public partial class ViewChequeTax : EntityBaseReadOnly
	{
        public static Ui.DataGrid GetViewChequeTaxGridByKeywords(string keywords, string orderBy, long startRowIndex, int pageSize)
        {
            long totalRows = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (!string.IsNullOrEmpty(keywords))
            {
                conditions.Add("([DepartmentName] like @keywords or [ContractCategoryName] like @keywords or [ContractNumber] like @keywords or [ContractName] like @keywords)");
                parameters.Add(new SqlParameter("@keywords", "%" + keywords + "%"));
            }
            string fieldList = "[ViewChequeTax].*";
            string Statement = " from [ViewChequeTax] where  " + string.Join(" and ", conditions.ToArray());
            ViewChequeTax[] list = GetList<ViewChequeTax>(fieldList, Statement, parameters, orderBy, startRowIndex, pageSize, out totalRows).ToArray();
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
        public static ViewChequeTax[] GetViewChequeTaxListByKeywords(string keywords)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (!string.IsNullOrEmpty(keywords))
            {
                conditions.Add("([DepartmentName] like @keywords or [ContractCategoryName] like @keywords or [ContractNumber] like @keywords or [ContractName] like @keywords)");
                parameters.Add(new SqlParameter("@keywords", "%" + keywords + "%"));
            }
            string fieldList = "select [ViewChequeTax].*  from [ViewChequeTax] where  " + string.Join(" and ", conditions.ToArray());
            ViewChequeTax[] list = GetList<ViewChequeTax>(fieldList, parameters).ToArray();
            return list;
        }
	}
}
