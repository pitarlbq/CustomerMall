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
	/// This object represents the properties and methods of a Cheque_ProjectCategory.
	/// </summary>
	public partial class Cheque_ProjectCategory : EntityBase
	{
        public static Cheque_ProjectCategory[] GetCheque_ProjectCategoryListByKeywords(string Keywords)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (!string.IsNullOrEmpty(Keywords))
            {
                conditions.Add("([ProjectCategoryName] like @Keywords or [ID] in (select [ProjectCategoryID] from [Cheque_Project] where [ProjectName] like  @Keywords))");
                parameters.Add(new SqlParameter("@Keywords", "%" + Keywords + "%"));
            }
            string Statement = " select * from [Cheque_ProjectCategory] where  " + string.Join(" and ", conditions.ToArray());
            Cheque_ProjectCategory[] list = GetList<Cheque_ProjectCategory>(Statement, parameters).ToArray();
            return list;
        }
        public static Ui.DataGrid GetCheque_ProjectCategoryGridByKeywords(string Keywords, string orderBy, long startRowIndex, int pageSize)
        {
            long totalRows = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (!string.IsNullOrEmpty(Keywords))
            {
                conditions.Add("([ProjectCategoryName] like @Keywords or [ProjectCategoryNumber] like @Keywords)");
                parameters.Add(new SqlParameter("@Keywords", "%" + Keywords + "%"));
            }
            string fieldList = "[Cheque_ProjectCategory].*";
            string Statement = " from [Cheque_ProjectCategory] where  " + string.Join(" and ", conditions.ToArray());
            Cheque_ProjectCategory[] list = GetList<Cheque_ProjectCategory>(fieldList, Statement, parameters, orderBy, startRowIndex, pageSize, out totalRows).ToArray();
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
	}
}
