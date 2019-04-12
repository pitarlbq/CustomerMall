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
	/// This object represents the properties and methods of a CKProductCategory.
	/// </summary>
	public partial class CKProductCategory : EntityBase
	{
        public static CKProductCategory[] GetCKProductCategoryListByKeywords(string Keywords)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (!string.IsNullOrEmpty(Keywords))
            {
                conditions.Add("[ProductCategoryName] like @Keywords");
                parameters.Add(new SqlParameter("@Keywords", "%" + Keywords + "%"));
            }
            return GetList<CKProductCategory>("select * from [CKProductCategory] where " + string.Join(" and ", conditions.ToArray()) + " order by [ProductCategoryName] collate Chinese_PRC_CS_AS_KS_WS", parameters).ToArray();
        }
	}
}
