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
    /// This object represents the properties and methods of a RoleCKCategory.
    /// </summary>
    public partial class RoleCKCategory : EntityBase
    {
        public static void DeleteRoleCKCategory(int RoleId, int UserID, SqlHelper helper)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            if (RoleId > 0)
            {
                conditions.Add("[RoleId] = @RoleID");
                parameters.Add(new SqlParameter("@RoleID", RoleId));
            }
            if (UserID > 0)
            {
                conditions.Add("[UserID] = @UserID");
                parameters.Add(new SqlParameter("@UserID", UserID));
            }
            string commandText = @"delete from [RoleCKCategory] where " + string.Join(" or ", conditions.ToArray());
            helper.Execute(commandText, CommandType.Text, parameters);
        }
        public static void InsertCKCategory(int CKCategoryID)
        {
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    string cmdtext = "insert into [RoleCKCategory] ([RoleID],[CKCategoryID]) select [RoleID]," + CKCategoryID + " from [Roles]";
                    helper.Execute(cmdtext, CommandType.Text, new List<SqlParameter>());
                    helper.Commit();
                }
                catch (Exception)
                {
                    helper.Rollback();
                }
            }
        }
    }
}
