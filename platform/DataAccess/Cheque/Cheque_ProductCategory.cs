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
	/// This object represents the properties and methods of a Cheque_ProductCategory.
	/// </summary>
	public partial class Cheque_ProductCategory : EntityBase
	{
        public static Cheque_ProductCategory[] GetCheque_ProductCategoryListByKeywords(string Keywords)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (!string.IsNullOrEmpty(Keywords))
            {
                conditions.Add("([ProductCategoryName] like @Keywords or [ID] in (select [ProductCategoryID] from [Cheque_Product] where [ProductName] like  @Keywords))");
                parameters.Add(new SqlParameter("@Keywords", "%" + Keywords + "%"));
            }
            string Statement = " select * from [Cheque_ProductCategory] where  " + string.Join(" and ", conditions.ToArray());
            Cheque_ProductCategory[] list = GetList<Cheque_ProductCategory>(Statement, parameters).ToArray();
            return list;
        }
        public static Ui.DataGrid GetCheque_ProductCategoryGridByKeywords(string Keywords, string orderBy, long startRowIndex, int pageSize)
        {
            long totalRows = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (!string.IsNullOrEmpty(Keywords))
            {
                conditions.Add("([ProductCategoryName] like @Keywords or [ProductCategoryNumber] like @Keywords)");
                parameters.Add(new SqlParameter("@Keywords", "%" + Keywords + "%"));
            }
            string fieldList = "[Cheque_ProductCategory].*";
            string Statement = " from [Cheque_ProductCategory] where  " + string.Join(" and ", conditions.ToArray());
            Cheque_ProductCategory[] list = GetList<Cheque_ProductCategory>(fieldList, Statement, parameters, orderBy, startRowIndex, pageSize, out totalRows).ToArray();
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
	}
}
