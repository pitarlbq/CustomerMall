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
	/// This object represents the properties and methods of a Cheque_OutingProduct.
	/// </summary>
	public partial class Cheque_OutingProduct : EntityBase
	{
        public static Ui.DataGrid GetCheque_OutingProductGridByKeywords(int OutingID, string GUID, string orderBy, long startRowIndex, int pageSize)
        {
            long totalRows = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[GUID]=@GUID");
            parameters.Add(new SqlParameter("@GUID", GUID));
            if (OutingID > 0)
            {
                conditions.Add("[OutingID]=@OutingID");
                parameters.Add(new SqlParameter("@OutingID", OutingID));
            }
            string fieldList = "[Cheque_OutingProduct].*";
            string Statement = " from [Cheque_OutingProduct] where  " + string.Join(" or ", conditions.ToArray());
            Cheque_OutingProduct[] list = GetList<Cheque_OutingProduct>(fieldList, Statement, parameters, orderBy, startRowIndex, pageSize, out totalRows).ToArray();
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
	}
}
