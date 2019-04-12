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
    /// This object represents the properties and methods of a SysManual.
    /// </summary>
    public partial class SysManual : EntityBase
    {
        public string StatusDesc
        {
            get
            {
                return this.Status == 1 ? "发布" : "未发布";
            }
        }
    }
    public partial class SysManualDetail : SysManual
    {
        [DatabaseColumn("CategoryName")]
        public string CategoryName { get; set; }
        public static Ui.DataGrid GetSysManualGridByKeywords(string Keywords, List<int> CategoryIDList, string orderBy, long startRowIndex, int pageSize)
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
            if (CategoryIDList.Count > 0)
            {
                conditions.Add("[CategoryID] in (" + string.Join(",", CategoryIDList.ToArray()) + ")");
            }
            string fieldList = "[SysManual].*,(select CategoryName from [SysManualCategory] where ID=[SysManual].CategoryID) as CategoryName";
            string Statement = " from [SysManual] where  " + string.Join(" and ", conditions.ToArray());
            SysManualDetail[] list = GetList<SysManualDetail>(fieldList, Statement, parameters, orderBy, startRowIndex, pageSize, out totalRows).ToArray();
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
    }
}
