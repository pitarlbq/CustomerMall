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
	/// This object represents the properties and methods of a Mall_OrderRefundRequest.
	/// </summary>
	public partial class Mall_OrderRefundRequest : EntityBase
	{
        public static Mall_OrderRefundRequest[] GetMall_OrderRefundRequestListByOrderID(int OrderID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[OrderID]=@OrderID");
            parameters.Add(new SqlParameter("@OrderID", OrderID));
            string Statement = @"select * from Mall_OrderRefundRequest where " + string.Join(" and ", conditions);
            return GetList<Mall_OrderRefundRequest>(Statement, parameters).ToArray();
        }
	}
}
