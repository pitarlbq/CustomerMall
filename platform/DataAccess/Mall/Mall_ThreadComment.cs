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
    /// This object represents the properties and methods of a Mall_ThreadComment.
    /// </summary>
    public partial class Mall_ThreadComment : EntityBase
    {
        public static Mall_ThreadComment[] GetMall_ThreadCommentListByThreadID(int ThreadID)
        {
            if (ThreadID == 0)
            {
                return new Mall_ThreadComment[] { };
            }
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            if (ThreadID > 0)
            {
                conditions.Add("[ThreadID]=@ThreadID");
                parameters.Add(new SqlParameter("@ThreadID", ThreadID));
            }
            string cmdtext = "select * from [Mall_ThreadComment] where  " + string.Join(" and ", conditions.ToArray()) + " order by [AddTime] desc";
            return GetList<Mall_ThreadComment>(cmdtext, parameters).ToArray();
        }
        
    }
    public partial class Mall_ThreadCommentDetail : Mall_ThreadComment
    {
        [DatabaseColumn("NickName")]
        public string NickName { get; set; }
        public static Ui.DataGrid GetMall_ThreadCommentDetailGridByKeyword(int ThreadID, string keywords, long startRowIndex, int pageSize)
        {
            long totalRows = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (ThreadID <= 0)
            {
                return new Ui.DataGrid();
            }
            conditions.Add("([ThreadID]=@ThreadID)");
            parameters.Add(new SqlParameter("@ThreadID", ThreadID));
            if (!string.IsNullOrEmpty(keywords))
            {
                conditions.Add("([Comment] like @keywords or [UserName] like @keywords)");
                parameters.Add(new SqlParameter("@keywords", "%" + keywords + "%"));
            }
            string OrderBy = " order by [AddTime] desc";
            string fieldList = "A.*";
            string Statement = " from (select *,(select NickName from [User] where UserID=Mall_ThreadComment.UserID) as NickName from [Mall_ThreadComment])A where  " + string.Join(" and ", conditions.ToArray());
            var list = GetList<Mall_ThreadCommentDetail>(fieldList, Statement, parameters, OrderBy, startRowIndex, pageSize, out totalRows).ToArray();
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
    }
}
