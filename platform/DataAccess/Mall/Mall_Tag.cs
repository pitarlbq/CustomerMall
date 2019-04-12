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
    /// This object represents the properties and methods of a Mall_Tag.
    /// </summary>
    public partial class Mall_Tag : EntityBase
    {
        public static Ui.DataGrid GetMall_TagGridByKeywords(string keywords, long startRowIndex, int pageSize)
        {
            long totalRows = 0;
            string OrderBy = " order by SortOrder asc, AddTime desc";
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (!string.IsNullOrEmpty(keywords))
            {
                conditions.Add("([TagName] like @keywords)");
                parameters.Add(new SqlParameter("@keywords", "%" + keywords + "%"));
            }
            string fieldList = "[Mall_Tag].*";
            string Statement = " from [Mall_Tag] where  " + string.Join(" and ", conditions.ToArray());
            Mall_Tag[] list = GetList<Mall_Tag>(fieldList, Statement, parameters, OrderBy, startRowIndex, pageSize, out totalRows).ToArray();
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
        public static Mall_Tag[] GetMall_TagListByCategoryID(int CategoryID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (CategoryID > 0)
            {
                conditions.Add("ID in (select [TagID] from [Mall_CategoryTag] where [CategoryID]=@CategoryID)");
                parameters.Add(new SqlParameter("@CategoryID", CategoryID));
            }
            string cmdtext = "select * from [Mall_Tag] where  " + string.Join(" and ", conditions.ToArray()) + " order by [SortOrder] asc,[AddTime] desc";
            return GetList<Mall_Tag>(cmdtext, parameters).ToArray();
        }
        public static Mall_Tag[] GetMall_TagListByProductID(int ProductID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (ProductID == 0)
            {
                return new Mall_Tag[] { };
            }
            conditions.Add("ID in (select [TagID] from [Mall_ProductTag] where [ProductID]=@ProductID)");
            parameters.Add(new SqlParameter("@ProductID", ProductID));
            string cmdtext = "select * from [Mall_Tag] where  " + string.Join(" and ", conditions.ToArray()) + " order by [SortOrder] asc,[AddTime] desc";
            return GetList<Mall_Tag>(cmdtext, parameters).ToArray();
        }
    }
}
