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
	/// This object represents the properties and methods of a Mall_ProductTag.
	/// </summary>
	public partial class Mall_ProductTag : EntityBase
	{
        public static Mall_ProductTag[] GetMall_ProductTagListByProductIDList(List<int> ProductIDList)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (ProductIDList.Count == 0)
            {
                return new Mall_ProductTag[] { };
            }
            conditions.Add("[ProductID] in (" + string.Join(",", ProductIDList.ToArray()) + ")");
            string cmdtext = "select * from [Mall_ProductTag] where  " + string.Join(" and ", conditions.ToArray());
            return GetList<Mall_ProductTag>(cmdtext, parameters).ToArray();
        }
	}
}
