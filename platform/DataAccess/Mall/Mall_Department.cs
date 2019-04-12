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
	/// This object represents the properties and methods of a Mall_Department.
	/// </summary>
	public partial class Mall_Department : EntityBase
	{
        public static Ui.DataGrid GetMall_DepartmentGridByKeywords(string keywords, long startRowIndex, int pageSize)
        {
            long totalRows = 0;
            string OrderBy = " order by [SortOrder] asc,[AddTime] desc";
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (!string.IsNullOrEmpty(keywords))
            {
                conditions.Add("[Name] like @keywords");
                parameters.Add(new SqlParameter("@keywords", "%" + keywords + "%"));
            }
            string fieldList = "[Mall_Department].*";
            string Statement = " from [Mall_Department] where  " + string.Join(" and ", conditions.ToArray());
            Mall_Department[] list = GetList<Mall_Department>(fieldList, Statement, parameters, OrderBy, startRowIndex, pageSize, out totalRows).ToArray();
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
	}
}
