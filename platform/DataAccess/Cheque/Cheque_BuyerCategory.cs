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
	/// This object represents the properties and methods of a Cheque_BuyerCategory.
	/// </summary>
    public partial class Cheque_BuyerCategory : EntityBase
    {
        public static Cheque_BuyerCategory[] GetCheque_BuyerCategoryListByKeywords(string Keywords)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (!string.IsNullOrEmpty(Keywords))
            {
                conditions.Add("([BuyerCategoryName] like @Keywords or [ID] in (select [BuyerCategoryID] from [Cheque_Buyer] where [BuyerName] like  @Keywords))");
                parameters.Add(new SqlParameter("@Keywords", "%" + Keywords + "%"));
            }
            string Statement = " select * from [Cheque_BuyerCategory] where  " + string.Join(" and ", conditions.ToArray());
            Cheque_BuyerCategory[] list = GetList<Cheque_BuyerCategory>(Statement, parameters).ToArray();
            return list;
        }
        public static Ui.DataGrid GetCheque_BuyerCategoryGridByKeywords(string Keywords, string orderBy, long startRowIndex, int pageSize)
        {
            long totalRows = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (!string.IsNullOrEmpty(Keywords))
            {
                conditions.Add("([BuyerCategoryName] like @Keywords or [BuyerCategoryNumber] like @Keywords)");
                parameters.Add(new SqlParameter("@Keywords", "%" + Keywords + "%"));
            }
            string fieldList = "[Cheque_BuyerCategory].*";
            string Statement = " from [Cheque_BuyerCategory] where  " + string.Join(" and ", conditions.ToArray());
            Cheque_BuyerCategory[] list = GetList<Cheque_BuyerCategory>(fieldList, Statement, parameters, orderBy, startRowIndex, pageSize, out totalRows).ToArray();
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
    }
}
