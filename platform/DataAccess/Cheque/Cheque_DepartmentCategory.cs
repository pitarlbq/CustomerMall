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
	/// This object represents the properties and methods of a Cheque_DepartmentCategory.
	/// </summary>
	public partial class Cheque_DepartmentCategory : EntityBase
	{
        public static Cheque_DepartmentCategory[] GetCheque_DepartmentCategoryListByKeywords(string Keywords)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (!string.IsNullOrEmpty(Keywords))
            {
                conditions.Add("([DepartmentCategoryName] like @Keywords or [ID] in (select [DepartmentCategoryID] from [Cheque_Department] where [DepartmentName] like  @Keywords))");
                parameters.Add(new SqlParameter("@Keywords", "%" + Keywords + "%"));
            }
            string Statement = " select * from [Cheque_DepartmentCategory] where  " + string.Join(" and ", conditions.ToArray());
            Cheque_DepartmentCategory[] list = GetList<Cheque_DepartmentCategory>(Statement, parameters).ToArray();
            return list;
        }
        public static Ui.DataGrid GetCheque_DepartmentCategoryGridByKeywords(string Keywords, string orderBy, long startRowIndex, int pageSize)
        {
            long totalRows = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (!string.IsNullOrEmpty(Keywords))
            {
                conditions.Add("([DepartmentCategoryName] like @Keywords or [DepartmentCategoryNumber] like @Keywords)");
                parameters.Add(new SqlParameter("@Keywords", "%" + Keywords + "%"));
            }
            string fieldList = "[Cheque_DepartmentCategory].*";
            string Statement = " from [Cheque_DepartmentCategory] where  " + string.Join(" and ", conditions.ToArray());
            Cheque_DepartmentCategory[] list = GetList<Cheque_DepartmentCategory>(fieldList, Statement, parameters, orderBy, startRowIndex, pageSize, out totalRows).ToArray();
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
	}
}
