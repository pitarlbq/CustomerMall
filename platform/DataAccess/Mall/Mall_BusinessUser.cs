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
    /// This object represents the properties and methods of a Mall_BusinessUser.
    /// </summary>
    public partial class Mall_BusinessUser : EntityBase
    {
        public static void Save_Mall_BusinessUser(int BusinessID, int UserID, SqlHelper helper)
        {
            string cmdtext = "select * from [Mall_BusinessUser] where [BusinessID]=@BusinessID and UserID=@UserID";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@BusinessID", BusinessID));
            parameters.Add(new SqlParameter("@UserID", UserID));
            var data = GetOne<Mall_BusinessUser>(cmdtext, parameters, helper);
            if (data == null)
            {
                data = new Mall_BusinessUser();
                data.BusinessID = BusinessID;
                data.UserID = UserID;
                data.Save(helper);
            }
        }
    }
}
