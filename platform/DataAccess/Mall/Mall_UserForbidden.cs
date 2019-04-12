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
    /// This object represents the properties and methods of a Mall_UserForbidden.
    /// </summary>
    public partial class Mall_UserForbidden : EntityBase
    {
        public bool IsActive
        {
            get
            {
                if (this.ForbiddenStartTime > DateTime.Now && this.ForbiddenStartTime > DateTime.MinValue)
                {
                    return false;
                }
                if (this.ForbiddenEndTime < DateTime.Now && this.ForbiddenEndTime > DateTime.MinValue)
                {
                    return false;
                }
                return true;
            }
        }
        public static Mall_UserForbidden[] GetMall_UserForbiddenListByUserID(int UserID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (UserID <= 0)
            {
                return new Mall_UserForbidden[] { };
            }
            conditions.Add("[UserID]=@UserID");
            parameters.Add(new SqlParameter("@UserID", UserID));
            string cmdtext = " select * from [Mall_UserForbidden] where  " + string.Join(" and ", conditions.ToArray());
            var list = GetList<Mall_UserForbiddenDetail>(cmdtext, parameters).ToArray();
            return list;
        }
    }
    public partial class Mall_UserForbiddenDetail : Mall_UserForbidden
    {
        [DatabaseColumn("NickName")]
        public string NickName { get; set; }
        [DatabaseColumn("PhoneNumber")]
        public string PhoneNumber { get; set; }
        public string ForbiddenTimeDesc
        {
            get
            {
                if (this.ForbiddenStartTime == DateTime.MinValue && this.ForbiddenEndTime == DateTime.MinValue)
                {
                    return "永久";
                }
                string desc = "";
                if (this.ForbiddenStartTime > DateTime.MinValue)
                {
                    desc += this.ForbiddenStartTime.ToString("yyyy-MM-dd");
                }
                else
                {
                    desc = "--";
                }
                desc += " 至 ";
                if (this.ForbiddenEndTime > DateTime.MinValue)
                {
                    desc += this.ForbiddenEndTime.ToString("yyyy-MM-dd");
                }
                else
                {
                    desc += "--";
                }
                return desc;
            }
        }
        public static Ui.DataGrid GetMall_UserForbiddenDetailGridByKeyword(string keywords, long startRowIndex, int pageSize)
        {
            long totalRows = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (!string.IsNullOrEmpty(keywords))
            {
                conditions.Add("([NickName] like @keywords)");
                parameters.Add(new SqlParameter("@keywords", "%" + keywords + "%"));
            }
            string OrderBy = " order by [AddTime] desc";
            string fieldList = "A.*";
            string Statement = " from (select *,(select NickName from [User] where UserID=Mall_UserForbidden.UserID) as NickName,(select PhoneNumber from [User] where UserID=Mall_UserForbidden.UserID) as PhoneNumber from [Mall_UserForbidden])A where  " + string.Join(" and ", conditions.ToArray());
            var list = GetList<Mall_UserForbiddenDetail>(fieldList, Statement, parameters, OrderBy, startRowIndex, pageSize, out totalRows).ToArray();
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
    }
}
