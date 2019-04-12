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
	/// This object represents the properties and methods of a CustomerServiceHuifang.
	/// </summary>
	public partial class CustomerServiceHuifang : EntityBase
	{
        public static CustomerServiceHuifang[] GetCustomerServiceHuifangList(int ServiceID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[ServiceID]=@ServiceID");
            parameters.Add(new SqlParameter("@ServiceID", ServiceID));
            return GetList<CustomerServiceHuifang>("select * from [CustomerServiceHuifang] where " + string.Join(" and ", conditions.ToArray()) + " order by AddTime desc", parameters).ToArray();
        }
	}
}
