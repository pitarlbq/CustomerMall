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
    /// This object represents the properties and methods of a InventoryInfo.
    /// </summary>
    public partial class InventoryInfo : EntityBase
    {
        public static InventoryInfo[] GetInventoryInfoListByKeywords(string Keywords)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (!string.IsNullOrEmpty(Keywords))
            {
                conditions.Add("[InventoryName] like @Keywords");
                parameters.Add(new SqlParameter("@Keywords", "%" + Keywords + "%"));
            }
            return GetList<InventoryInfo>("select * from [InventoryInfo] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
    }
}
