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
    /// This object represents the properties and methods of a ViewDeviceGroup.
    /// </summary>
    public partial class ViewDeviceGroup : EntityBaseReadOnly
    {
        public static Ui.DataGrid GetViewDeviceGroupGridByKeywords(string Keywords, string orderBy, long startRowIndex, int pageSize)
        {
            long totalRows = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (!string.IsNullOrEmpty(Keywords))
            {
                conditions.Add("([DeviceGroupName] like @Keywords or [Code] like @Keywords or [RepairUserMan] like @Keywords or [CheckUserMan] like @Keywords)");
                parameters.Add(new SqlParameter("@Keywords", "%" + Keywords + "%"));
            }
            string fieldList = "[ViewDeviceGroup].*";
            string Statement = " from [ViewDeviceGroup] where  " + string.Join(" and ", conditions.ToArray());
            ViewDeviceGroup[] list = GetList<ViewDeviceGroup>(fieldList, Statement, parameters, orderBy, startRowIndex, pageSize, out totalRows).ToArray();
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
    }
}
