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
	/// This object represents the properties and methods of a Cheque_ContractCategory.
	/// </summary>
	public partial class Cheque_ContractCategory : EntityBase
	{
        public static Ui.DataGrid GetCheque_ContractCategoryGridByKeywords(string keywords, string orderBy, long startRowIndex, int pageSize)
        {
            long totalRows = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (!string.IsNullOrEmpty(keywords))
            {
                conditions.Add("([ContractCategoryNumber] like @keywords or [ContractCategoryName] like @keywords)");
                parameters.Add(new SqlParameter("@keywords", "%" + keywords + "%"));
            }
            string fieldList = "[Cheque_ContractCategory].*";
            string Statement = " from [Cheque_ContractCategory] where  " + string.Join(" and ", conditions.ToArray());
            Cheque_ContractCategory[] list = GetList<Cheque_ContractCategory>(fieldList, Statement, parameters, orderBy, startRowIndex, pageSize, out totalRows).ToArray();
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
        public static Cheque_ContractCategory[] GetCheque_ContractCategoryByGUID(string guid)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (!string.IsNullOrEmpty(guid))
            {
                parameters.Add(new SqlParameter("@guid", guid));
                conditions.Add("[GUID]=@guid");
            }
            return GetList<Cheque_ContractCategory>("select * from [Cheque_ContractCategory] where " + string.Join(" and ", conditions.ToArray()) + " order by ID desc", parameters).ToArray();
        }
	}
}
