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
    /// This object represents the properties and methods of a Mall_CheckCategory.
    /// </summary>
    public partial class Mall_CheckCategory : EntityBase
    {
        public static Mall_CheckCategory[] GetMall_CheckCategoryListByKeywords(string Keywords, int CategoryType)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (CategoryType > 0)
            {
                conditions.Add("[CategoryType]=@CategoryType");
                parameters.Add(new SqlParameter("@CategoryType", CategoryType));
            }
            if (!string.IsNullOrEmpty(Keywords))
            {
                conditions.Add("[CategoryName] like @Keywords");
                parameters.Add(new SqlParameter("@Keywords", "%" + Keywords + "%"));
            }
            return GetList<Mall_CheckCategory>("select * from [Mall_CheckCategory] where " + string.Join(" and ", conditions.ToArray()) + " order by [AddTime] desc", parameters).ToArray();
        }
        public string CategoryTypeDesc
        {
            get
            {
                if (this.CategoryType == 1)
                {
                    return "奖励";
                }
                if (this.CategoryType == 2)
                {
                    return "惩罚";
                }
                return string.Empty;
            }
        }
    }
}
