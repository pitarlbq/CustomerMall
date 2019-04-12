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
	/// This object represents the properties and methods of a Cheque_SellerCategory.
	/// </summary>
	public partial class Cheque_SellerCategory : EntityBase
	{
        public static Cheque_SellerCategory[] GetCheque_SellerCategoryListByKeywords(string Keywords)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (!string.IsNullOrEmpty(Keywords))
            {
                conditions.Add("([SellerCategoryName] like @Keywords or [ID] in (select [SellerCategoryID] from [Cheque_Seller] where [SellerName] like  @Keywords))");
                parameters.Add(new SqlParameter("@Keywords", "%" + Keywords + "%"));
            }
            string Statement = " select * from [Cheque_SellerCategory] where  " + string.Join(" and ", conditions.ToArray());
            Cheque_SellerCategory[] list = GetList<Cheque_SellerCategory>(Statement, parameters).ToArray();
            return list;
        }
        public static Ui.DataGrid GetCheque_SellerCategoryGridByKeywords(string Keywords, string orderBy, long startRowIndex, int pageSize)
        {
            long totalRows = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (!string.IsNullOrEmpty(Keywords))
            {
                conditions.Add("([SellerCategoryName] like @Keywords or [SellerCategoryNumber] like @Keywords)");
                parameters.Add(new SqlParameter("@Keywords", "%" + Keywords + "%"));
            }
            string fieldList = "[Cheque_SellerCategory].*";
            string Statement = " from [Cheque_SellerCategory] where  " + string.Join(" and ", conditions.ToArray());
            Cheque_SellerCategory[] list = GetList<Cheque_SellerCategory>(fieldList, Statement, parameters, orderBy, startRowIndex, pageSize, out totalRows).ToArray();
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
	}
}
