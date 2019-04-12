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
	/// This object represents the properties and methods of a Mall_CouponProduct.
	/// </summary>
	public partial class Mall_CouponProduct : EntityBase
	{
        public static Mall_CouponProduct[] GetMall_CouponProductListByIDList(List<int> IDList)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (IDList.Count == 0)
            {
                return new Mall_CouponProduct[] { };
            }
            conditions.Add("[CouponID] in (" + string.Join(",", IDList.ToArray()) + ")");
            string cmdtext = "select * from [Mall_CouponProduct] where  " + string.Join(" and ", conditions.ToArray());
            return GetList<Mall_CouponProduct>(cmdtext, parameters).ToArray();
        }
	}
}
