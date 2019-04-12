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
	/// This object represents the properties and methods of a CKPropertyCategory.
	/// </summary>
	public partial class CKPropertyCategory : EntityBase
	{
        public static Ui.DataGrid GetCKPropertyCategoryGridByKeywords(string Keywords, string orderBy, long startRowIndex, int pageSize)
        {
            long totalRows = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (!string.IsNullOrEmpty(Keywords))
            {
                conditions.Add("([PropertyCategoryName] like @Keywords)");
                parameters.Add(new SqlParameter("@Keywords", "%" + Keywords + "%"));
            }
            string fieldList = "[CKPropertyCategory].*";
            string Statement = " from [CKPropertyCategory] where  " + string.Join(" and ", conditions.ToArray());
            CKPropertyCategory[] list = GetList<CKPropertyCategory>(fieldList, Statement, parameters, orderBy, startRowIndex, pageSize, out totalRows).ToArray();
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
	}
}
