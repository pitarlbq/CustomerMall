﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;

using Foresight.DataAccess.Framework;

namespace Foresight.DataAccess
{
    /// <summary>
    /// This object represents the properties and methods of a RoleModule.
    /// </summary>
    public partial class RoleModule : EntityBase
    {
        public static RoleModule[] GetRoleModuleListByRoleId(int RoleId, int UserID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            if (RoleId <= 0 && UserID <= 0)
            {
                return new RoleModule[] { };
            }
            if (RoleId > 0)
            {
                conditions.Add("[RoleId] = @RoleId");
                parameters.Add(new SqlParameter("@RoleId", RoleId));
            }
            if (UserID > 0)
            {
                conditions.Add("[UserID] = @UserID");
                parameters.Add(new SqlParameter("@UserID", UserID));
            }
            string sqlText = "select * from [RoleModule] where " + string.Join(" or ", conditions.ToArray());
            return GetList<RoleModule>(sqlText, parameters).ToArray();
        }
        public static void DeleteRoleModuleByRoleId(int RoleID, int UserID, SqlHelper helper)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            if (RoleID > 0)
            {
                conditions.Add("[RoleId] = @RoleID");
                parameters.Add(new SqlParameter("@RoleID", RoleID));
            }
            if (UserID > 0)
            {
                conditions.Add("[UserID] = @UserID");
                parameters.Add(new SqlParameter("@UserID", UserID));
            }
            string commandText = @"delete from [RoleModule] where " + string.Join(" or ", conditions.ToArray());
            helper.Execute(commandText, CommandType.Text, parameters);
        }
    }
}
