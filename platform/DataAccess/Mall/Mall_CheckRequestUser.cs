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
	/// This object represents the properties and methods of a Mall_CheckRequestUser.
	/// </summary>
	public partial class Mall_CheckRequestUser : EntityBase
	{
        public static Mall_CheckRequestUser[] GetMall_CheckRequestUserListByRequestIDList(List<int> RequestIDList)
        {
            if (RequestIDList.Count == 0)
            {
                return new Mall_CheckRequestUser[] { };
            }
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[RequestID] in (" + string.Join(",", RequestIDList.ToArray()) + ")");
            string cmdtext = "select * from [Mall_CheckRequestUser] where  " + string.Join(" and ", conditions.ToArray());
            Mall_CheckRequestUser[] list = GetList<Mall_CheckRequestUser>(cmdtext, parameters).ToArray();
            return list;
        }
	}
}
