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
    /// This object represents the properties and methods of a CKDepartment.
    /// </summary>
    public partial class CKDepartment : EntityBase
    {
        public static Ui.DataGrid GetCKDepartmentGridByKeywords(string Keywords, string orderBy, long startRowIndex, int pageSize)
        {
            long totalRows = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (!string.IsNullOrEmpty(Keywords))
            {
                conditions.Add("([DepartmentName] like @Keywords)");
                parameters.Add(new SqlParameter("@Keywords", "%" + Keywords + "%"));
            }
            string fieldList = "[CKDepartment].*";
            string Statement = " from [CKDepartment] where  " + string.Join(" and ", conditions.ToArray());
            CKDepartment[] list = new CKDepartment[] { };
            list = GetList<CKDepartment>(fieldList, Statement, parameters, orderBy, startRowIndex, pageSize, out totalRows).ToArray();
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
        public static CKDepartment[] GetCKDepartmentListByKeywords(string Keywords)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (!string.IsNullOrEmpty(Keywords))
            {
                conditions.Add("[DepartmentName] like @Keywords");
                parameters.Add(new SqlParameter("@Keywords", "%" + Keywords + "%"));
            }
            return GetList<CKDepartment>("select * from [CKDepartment] where " + string.Join(" and ", conditions.ToArray()) + " order by [DepartmentName] collate Chinese_PRC_CS_AS_KS_WS", parameters).ToArray();
        }
        public static CKDepartment[] GetAdminNotInDepartmentList(int UserId, string keywords)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            string cmd = string.Empty;
            if (!string.IsNullOrEmpty(keywords))
            {
                parameters.Add(new SqlParameter("@keywords", "%" + keywords + "%"));
                cmd += " and [DepartmentName] like @keywords";
            }
            if (UserId > 0)
            {
                parameters.Add(new SqlParameter("@UserId", UserId));
                cmd += " and [ID] not in (select [DepartmentID] from [UserDepartment] where [UserID]=@UserId)";
            }
            string sqlText = "select * from [CKDepartment] where 1=1 " + cmd;
            return GetList<CKDepartment>(sqlText, parameters).ToArray();
        }
        public static CKDepartment[] GetAdminInDepartmentList(int UserId)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            string cmd = string.Empty;
            if (UserId > 0)
            {
                parameters.Add(new SqlParameter("@UserId", UserId));
                cmd += " and [ID] in (select [DepartmentID] from [UserDepartment] where [UserID]=@UserId)";
            }
            string sqlText = "select * from [CKDepartment] where 1=1 " + cmd;
            return GetList<CKDepartment>(sqlText, parameters).ToArray();
        }
    }
}
