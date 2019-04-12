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
    /// This object represents the properties and methods of a CKInCategory.
    /// </summary>
    public partial class CKInCategory : EntityBase
    {
        public static Ui.DataGrid GetCKInCategoryGridByKeywords(string Keywords, string CategoryType, string orderBy, long startRowIndex, int pageSize)
        {
            long totalRows = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (!string.IsNullOrEmpty(Keywords))
            {
                conditions.Add("([InCategoryName] like @Keywords)");
                parameters.Add(new SqlParameter("@Keywords", "%" + Keywords + "%"));
            }
            if (!string.IsNullOrEmpty(CategoryType))
            {
                conditions.Add("([CategoryType]=@CategoryType)");
                parameters.Add(new SqlParameter("@CategoryType", CategoryType));
            }
            string fieldList = "[CKInCategory].*";
            string Statement = " from [CKInCategory] where  " + string.Join(" and ", conditions.ToArray());
            CKInCategory[] list = new CKInCategory[] { };
            list = GetList<CKInCategory>(fieldList, Statement, parameters, orderBy, startRowIndex, pageSize, out totalRows).ToArray();
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
        public string CategoryTypeDesc
        {
            get
            {
                if (string.IsNullOrEmpty(this.CategoryType))
                {
                    return string.Empty;
                }
                return Utility.EnumHelper.GetDescription(typeof(Utility.EnumModel.InCategoryTypeDefine), this.CategoryType);
            }
        }
    }
}
