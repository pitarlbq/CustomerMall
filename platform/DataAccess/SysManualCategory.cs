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
    /// This object represents the properties and methods of a SysManualCategory.
    /// </summary>
    public partial class SysManualCategory : EntityBase
    {
        public static SysManualCategory[] GetSysManualCategoryListByKeywords(string Keywords)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (!string.IsNullOrEmpty(Keywords))
            {
                conditions.Add("[CategoryName] like @Keywords");
                parameters.Add(new SqlParameter("@Keywords", "%" + Keywords + "%"));
            }
            return GetList<SysManualCategory>("select * from [SysManualCategory] where " + string.Join(" and ", conditions.ToArray()) + " order by [SortBy] asc", parameters).ToArray();
        }
        public string StatusDesc
        {
            get
            {
                return this.Status == 1 ? "发布" : "未发布";
            }
        }
    }
}
