using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Linq;
using Foresight.DataAccess.Framework;

namespace Foresight.DataAccess
{
    /// <summary>
    /// This object represents the properties and methods of a Mall_CheckInfo.
    /// </summary>
    public partial class Mall_CheckInfo : EntityBase
    {
        public string PointRange
        {
            get
            {
                return this.StartPoint.ToString() + " - " + this.EndPoint.ToString();
            }
        }
    }
    public partial class Mall_CheckInfoDetail : Mall_CheckInfo
    {
        public int CategoryType { get; set; }
        public string CategoryTypeDesc { get; set; }
        public string CategoryName { get; set; }
        public static Ui.DataGrid GetMall_CheckInfoDetailGridByKeywords(string Keywords, List<int> CategoryIDList, string orderBy, long startRowIndex, int pageSize, int CategoryType)
        {
            long totalRows = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (CategoryType > 0)
            {
                conditions.Add("[CheckCategoryID] in (select [ID] from [Mall_CheckCategory] where [CategoryType]=@CategoryType)");
                parameters.Add(new SqlParameter("@CategoryType", CategoryType));
            }
            if (!string.IsNullOrEmpty(Keywords))
            {
                conditions.Add("([CheckName] like @Keywords)");
                parameters.Add(new SqlParameter("@Keywords", "%" + Keywords + "%"));
            }
            if (CategoryIDList.Count > 0)
            {
                conditions.Add("[CheckCategoryID] in (" + string.Join(",", CategoryIDList.ToArray()) + ")");
            }
            string fieldList = "[Mall_CheckInfo].* ";
            string Statement = " from [Mall_CheckInfo] where  " + string.Join(" and ", conditions.ToArray());
            Mall_CheckInfoDetail[] list = GetList<Mall_CheckInfoDetail>(fieldList, Statement, parameters, orderBy, startRowIndex, pageSize, out totalRows).ToArray();
            if (list.Length > 0)
            {
                var category_list = Mall_CheckCategory.GetMall_CheckCategories();
                foreach (var item in list)
                {
                    var my_category = category_list.FirstOrDefault(p => p.ID == item.CheckCategoryID);
                    if (my_category != null)
                    {
                        item.CategoryName = my_category.CategoryName;
                        item.CategoryTypeDesc = my_category.CategoryTypeDesc;
                        item.CategoryType = my_category.CategoryType;
                    }
                }
            }
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
    }
}
