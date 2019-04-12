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
    /// This object represents the properties and methods of a ChargeBiao.
    /// </summary>
    public partial class ChargeBiao : EntityBase
    {
        public static Ui.DataGrid GetChargeBiaoGrid(string Keywords, string orderBy, long startRowIndex, int pageSize)
        {
            long totalRows = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            string fieldList = "[ChargeBiao].* ";
            string Statement = " from [ChargeBiao] where  " + string.Join(" and ", conditions.ToArray());
            ChargeBiao[] list = new ChargeBiao[] { };
            list = GetList<ChargeBiao>(fieldList, Statement, parameters, orderBy, startRowIndex, pageSize, out totalRows).ToArray();
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
    }
}
