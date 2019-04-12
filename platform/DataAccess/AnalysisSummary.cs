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
    /// This object represents the properties and methods of a AnalysisSummary.
    /// </summary>
    public partial class AnalysisSummary : EntityBase
    {
        public static AnalysisSummary GetAnalysisSummaryByCode(int UserID, string AnalysisCode)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@AnalysisCode", AnalysisCode));
            parameters.Add(new SqlParameter("@UserID", UserID));
            return GetOne<AnalysisSummary>("select top 1 * from [AnalysisSummary] where [ID] in (select [SummaryID] from [AnalysisSummaryUser] where [UserID]=@UserID) and [PID] in (select [ID] from [AnalysisSummary] where [AnalysisCode]=@AnalysisCode)", parameters);
        }
    }
    public partial class AnalysisSummaryDetail : AnalysisSummary
    {
        [DatabaseColumn("UserID")]
        public int UserID { get; set; }
        public static AnalysisSummaryDetail[] GetAnalysisSummaryTreeListByID(int UserID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@UserID", UserID));
            AnalysisSummaryDetail[] list = GetList<AnalysisSummaryDetail>("select *,(select [UserID] from [AnalysisSummaryUser] where [AnalysisSummaryUser].[SummaryID]=[AnalysisSummary].[ID] and [UserID]=@UserID) as UserID from [AnalysisSummary]", parameters).ToArray();
            return list;
        }
    }
}
