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
	/// This object represents the properties and methods of a Mall_Content.
	/// </summary>
	public partial class Mall_Content : EntityBase
	{
        public static Mall_Content GetMall_ContentByName(string Name)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Name", Name));
            return GetOne<Mall_Content>("select * from [Mall_Content] where [Name]=@Name", parameters);
        }
	}
}
