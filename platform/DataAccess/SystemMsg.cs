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
    /// This object represents the properties and methods of a SystemMsg.
    /// </summary>
    public partial class SystemMsg : EntityBase
    {
        public static Ui.DataGrid GetSystemMsgGridByKeywords(string Keywords, string orderBy, long startRowIndex, int pageSize)
        {
            long totalRows = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (!string.IsNullOrEmpty(Keywords))
            {
                conditions.Add("([Title] like @Keywords)");
                parameters.Add(new SqlParameter("@Keywords", "%" + Keywords + "%"));
            }
            string fieldList = "[SystemMsg].*";
            string Statement = " from [SystemMsg] where  " + string.Join(" and ", conditions.ToArray());
            SystemMsg[] list = GetList<SystemMsg>(fieldList, Statement, parameters, orderBy, startRowIndex, pageSize, out totalRows).ToArray();
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
        public static SystemMsg[] GetSystemMsgGridListByIDList(List<int> IDList)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (IDList.Count > 0)
            {
                conditions.Add("[ID] in (" + string.Join(",", IDList.ToArray()) + ")");
            }
            return GetList<SystemMsg>("select * from [SystemMsg] where  " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
        public static int GetUnReadSystemMsgCount()
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("isnull([IsReading],0)=0");
            int count = 0;
            using (SqlHelper helper = new SqlHelper())
            {
                var result = helper.ExecuteScalar("select count(1) from [SystemMsg] where  " + string.Join(" and ", conditions.ToArray()), CommandType.Text, new List<SqlParameter>());
                if (result != null)
                {
                    int.TryParse(result.ToString(), out count);
                }
            }
            return count;
        }
    }
}
