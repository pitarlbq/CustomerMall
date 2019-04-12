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
	/// This object represents the properties and methods of a TableColumnsUser.
	/// </summary>
	public partial class TableColumnsUser : EntityBase
	{
        public static TableColumnsUser[] GetTableColumnsUserListByUserID(int UserID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@UserID", UserID));
            return GetList<TableColumnsUser>("select * from [TableColumnsUser] where [UserID]=@UserID", parameters).ToArray();
        }
	}
}
