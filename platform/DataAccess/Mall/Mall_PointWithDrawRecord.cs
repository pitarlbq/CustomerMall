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
    /// This object represents the properties and methods of a Mall_PointWithDrawRecord.
    /// </summary>
    public partial class Mall_PointWithDrawRecord : EntityBase
    {
        public string StatusDesc
        {
            get
            {
                if (this.Status == 1)
                {
                    return "已提现";
                }
                if (this.Status == 2)
                {
                    return "审核中";
                }
                if (this.Status == 3)
                {
                    return "审核未通过";
                }
                return string.Empty;
            }
        }
        public string AddTimeDesc
        {
            get
            {
                return this.AddTime.ToString("yyyy-MM-dd");
            }
        }
        public string ApproveTimeDesc
        {
            get
            {
                if (this.ApproveTime == DateTime.MinValue)
                {
                    return string.Empty;
                }
                return this.ApproveTime.ToString("yyyy-MM-dd");
            }
        }
        public static Ui.DataGrid GetMall_PointWithDrawRecordGridList(string keywords, long startRowIndex, int pageSize)
        {
            long totalRows = 0;
            string OrderBy = " order by AddTime desc";
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (!string.IsNullOrEmpty(keywords))
            {
                conditions.Add("([AddUserName] like @keywords)");
                parameters.Add(new SqlParameter("@keywords", "%" + keywords + "%"));
            }
            string fieldList = "Mall_PointWithDrawRecord.*";
            string Statement = " from [Mall_PointWithDrawRecord] where  " + string.Join(" and ", conditions.ToArray());
            Mall_PointWithDrawRecord[] list = GetList<Mall_PointWithDrawRecord>(fieldList, Statement, parameters, OrderBy, startRowIndex, pageSize, out totalRows).ToArray();
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
        public static Mall_PointWithDrawRecord[] Get_Mall_PointWithDrawRecordListByUserID(int UserID)
        {
            var parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@UserID", UserID));
            return GetList<Mall_PointWithDrawRecord>("select * from [Mall_PointWithDrawRecord] where UserID=@UserID order by [AddTime] desc", parameters).ToArray();
        }
    }
}
