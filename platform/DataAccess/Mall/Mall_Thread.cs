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
    /// This object represents the properties and methods of a Mall_Thread.
    /// </summary>
    public partial class Mall_Thread : EntityBase
    {
        public static Mall_Thread[] GetMall_ThreadListByKeyword(int CategoryID, long startRowIndex, int pageSize, out long totalRows, int ThreadType = 1)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("isnull([ThreadType],1)=@ThreadType");
            parameters.Add(new SqlParameter("@ThreadType", ThreadType));
            if (CategoryID > 0)
            {
                conditions.Add("[CategoryID]=@CategoryID");
                parameters.Add(new SqlParameter("@CategoryID", CategoryID));
            }
            string OrderBy = " order by [AddTime] desc";
            string fieldList = "[Mall_Thread].*";
            string Statement = " from [Mall_Thread] where  " + string.Join(" and ", conditions.ToArray());
            var list = GetList<Mall_Thread>(fieldList, Statement, parameters, OrderBy, startRowIndex, pageSize, out totalRows).ToArray();
            return list;
        }
    }
    public partial class Mall_ThreadDetail : Mall_Thread
    {
        [DatabaseColumn("CategoryName")]
        public string CategoryName { get; set; }
        [DatabaseColumn("CommentCount")]
        public int CommentCount { get; set; }
        public static Ui.DataGrid GetMall_ThreadDetailListByKeyword(string keywords, long startRowIndex, int pageSize, int ThreadType = 1)
        {
            long totalRows = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("isnull([ThreadType],1)=@ThreadType");
            parameters.Add(new SqlParameter("@ThreadType", ThreadType));
            if (!string.IsNullOrEmpty(keywords))
            {
                conditions.Add("([Description] like @keywords or [UserName] like @keywords)");
                parameters.Add(new SqlParameter("@keywords", "%" + keywords + "%"));
            }
            string OrderBy = " order by [AddTime] desc";
            string fieldList = "A.*";
            string Statement = " from (select *,(select [CategoryName] from [Mall_Category] where [ID]=[Mall_Thread].[CategoryID]) as CategoryName,(select count(1) from [Mall_ThreadComment] where [ThreadID]=[Mall_Thread].[ID]) as CommentCount from [Mall_Thread])A where  " + string.Join(" and ", conditions.ToArray());
            var list = GetList<Mall_ThreadDetail>(fieldList, Statement, parameters, OrderBy, startRowIndex, pageSize, out totalRows).ToArray();
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
    }
}
