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
    /// This object represents the properties and methods of a ProjectYT.
    /// </summary>
    public partial class ProjectYT : EntityBase
    {
        public static ProjectYT GetProjectYTByName(string Name, SqlHelper helper)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[Name]=@Name");
            parameters.Add(new SqlParameter("@Name", Name));
            return GetOne<ProjectYT>("select top 1 * from [ProjectYT] where " + string.Join(" and ", conditions.ToArray()), parameters, helper);
        }
    }
    public partial class ProjectYTDetails : ProjectYT
    {
        [DatabaseColumn("YTOrderID")]
        public int YTOrderID { get; set; }
        [DatabaseColumn("YTOrderBy")]
        public int YTOrderBy { get; set; }
        [DatabaseColumn("IsShow")]
        public bool IsShow { get; set; }
        public static ProjectYTDetails[] GetProjectYTList(int ProjectID, int CompanyID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            parameters.Add(new SqlParameter("@CompanyID", CompanyID));
            conditions.Add("[CompanyID]=@CompanyID");
            if (ProjectID > 1)
            {
                parameters.Add(new SqlParameter("@ProjectID", ProjectID));
                conditions.Add("[ProjectID] in (select [ID] from [Project] where [AllParentID] like '%," + ProjectID + ",%' or [ID]=@ProjectID)");
                return GetList<ProjectYTDetails>("select *,isnull((select top 1 [ID] from [ProjectYTOrder] where [Name]=[ProjectYT].[Name] and " + string.Join(" and ", conditions.ToArray()) + "),0) as YTOrderID,isnull((select top 1 [OrderBy] from [ProjectYTOrder] where [Name]=[ProjectYT].[Name] and " + string.Join(" and ", conditions.ToArray()) + "),0) as YTOrderBy,isnull((select top 1 [IsShow] from [ProjectYTOrder] where [Name]=[ProjectYT].[Name] and " + string.Join(" and ", conditions.ToArray()) + "),1) as IsShow from [ProjectYT]", parameters).ToArray();
            }
            return GetList<ProjectYTDetails>("select *,1 as [IsShow],0 as [YTOrderID], 0 as [YTOrderBy] from [ProjectYT]", parameters).ToArray();
        }
    }
}
