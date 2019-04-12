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
    /// This object represents the properties and methods of a CKContarct.
    /// </summary>
    public partial class CKContarct : EntityBase
    {
        public static Ui.DataGrid GetCKContarctGridByKeywords(string Keywords, string orderBy, long startRowIndex, int pageSize)
        {
            long totalRows = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (!string.IsNullOrEmpty(Keywords))
            {
                conditions.Add("([ContractName] like @Keywords or [ContractFullName] like @Keywords or [ContactMan] like @Keywords or [PhoneNumber] like @Keywords or [FaxNumber] like @Keywords)");
                parameters.Add(new SqlParameter("@Keywords", "%" + Keywords + "%"));
            }
            string fieldList = "[CKContarct].*";
            string Statement = " from [CKContarct] where  " + string.Join(" and ", conditions.ToArray());
            CKContarct[] list = new CKContarct[] { };
            list = GetList<CKContarct>(fieldList, Statement, parameters, orderBy, startRowIndex, pageSize, out totalRows).ToArray();
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
        public static CKContarct GetLastCKContarct(SqlHelper helper)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            return GetOne<CKContarct>("select top 1 * from [CKContarct] order by [AddTime] desc", parameters, helper);
        }
        public static string GetLastestContractNumber()
        {
            using (SqlHelper helper = new SqlHelper())
            {
                return GetLastestContractNumber(helper);
            }
        }
        public static string GetLastestContractNumber(SqlHelper helper)
        {
            CKContarct history = CKContarct.GetLastCKContarct(helper);
            string Part1 = "CS_";
            int number = 1;
            if (history != null && !string.IsNullOrEmpty(history.ContractNumber))
            {
                string Number = history.ContractNumber.Replace("CS_", "");
                int _number = 0;
                int.TryParse(Number, out _number);
                number = _number + 1;
            }
            return Part1 + number.ToString("D8");
        }
    }
}
