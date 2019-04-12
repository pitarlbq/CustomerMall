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
    /// This object represents the properties and methods of a Mall_UserFamily.
    /// </summary>
    public partial class Mall_UserFamily : EntityBase
    {
        public static Mall_UserFamily[] GetMall_UserFamilyListByUserID(int UserID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (UserID <= 0)
            {
                return new Mall_UserFamily[] { };
            }
            conditions.Add("[UserID]=@UserID");
            parameters.Add(new SqlParameter("@UserID", UserID));
            return GetList<Mall_UserFamily>("select * from [Mall_UserFamily] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
    }
}
