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
    /// This object represents the properties and methods of a ViewDevice.
    /// </summary>
    public partial class ViewDevice : EntityBaseReadOnly
    {
        public string StatusDesc
        {
            get
            {
                if (this.DeviceStatus == 1)
                {
                    return "正常";
                }
                else if (this.DeviceStatus == 2)
                {
                    return "停用";
                }
                else if (this.DeviceStatus == 3)
                {
                    return "报废";
                }
                return string.Empty;
            }
        }
        public string RepairCycleDesc
        {
            get
            {
                if (this.RepairCount <= 0)
                {
                    return string.Empty;
                }
                if (this.RepairCycle.Equals(Utility.EnumModel.DeviceCycleType.day.ToString()))
                {
                    return this.RepairCount + "天";
                }
                else if (this.RepairCycle.Equals(Utility.EnumModel.DeviceCycleType.month.ToString()))
                {
                    return this.RepairCount + "月";
                }
                return string.Empty;
            }
        }
        public string CheckCycleDesc
        {
            get
            {
                if (this.CheckCount <= 0)
                {
                    return string.Empty;
                }
                if (this.CheckCycle.Equals(Utility.EnumModel.DeviceCycleType.day.ToString()))
                {
                    return this.CheckCount + "天";
                }
                else if (this.CheckCycle.Equals(Utility.EnumModel.DeviceCycleType.month.ToString()))
                {
                    return this.CheckCount + "月";
                }
                return string.Empty;
            }
        }
        public static Ui.DataGrid GetViewDeviceGridByKeywords(string Keywords, int DeviceGroupID, List<int> ProjectIDList, string orderBy, long startRowIndex, int pageSize, bool canexport = false)
        {
            long totalRows = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (ProjectIDList.Count > 0)
            {
                conditions.Add("([ProjectID] in (" + string.Join(",", ProjectIDList.ToArray()) + "))");
            }
            if (!string.IsNullOrEmpty(Keywords))
            {
                conditions.Add("([DeviceNo] like @Keywords or [DeviceName] like @Keywords)");
                parameters.Add(new SqlParameter("@Keywords", "%" + Keywords + "%"));
            }
            if (DeviceGroupID > 0)
            {
                conditions.Add("[DeviceGroupID]=@DeviceGroupID");
                parameters.Add(new SqlParameter("@DeviceGroupID", DeviceGroupID));
            }
            string fieldList = "[ViewDevice].*";
            string Statement = " from [ViewDevice] where  " + string.Join(" and ", conditions.ToArray());
            ViewDevice[] list = new ViewDevice[] { };

            if (canexport)
            {
                list = GetList<ViewDevice>("select " + fieldList + Statement + " " + orderBy, parameters).ToArray();
                totalRows = list.Length;
            }
            else
            {
                list = GetList<ViewDevice>(fieldList, Statement, parameters, orderBy, startRowIndex, pageSize, out totalRows).ToArray();
            }
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
    }
}
