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
    /// This object represents the properties and methods of a CompanyModule.
    /// </summary>
    public partial class CompanyModule : EntityBase
    {
        public static CompanyModule[] GetCompanyModuleListByCompanyID(int CompanyID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@CompanyID", CompanyID));
            string sqlText = "select * from [CompanyModule] where [CompanyID] = @CompanyID";
            return GetList<CompanyModule>(sqlText, parameters).ToArray();
        }
        public static void DeleteCompanyModuleByRoleId(int CompanyID)
        {
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    string commandText = @"
DELETE FROM [dbo].[CompanyModule]
WHERE [CompanyModule].[CompanyID] = @CompanyID";

                    System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
                    parameters.Add(new SqlParameter("@CompanyID", CompanyID));

                    helper.Execute(commandText, CommandType.Text, parameters);
                    helper.Commit();
                }
                catch
                {
                    helper.Rollback();
                    throw;
                }
            }
        }
    }
}
