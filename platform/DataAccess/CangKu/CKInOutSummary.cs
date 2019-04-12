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
    /// This object represents the properties and methods of a CKInOutSummary.
    /// </summary>
    public partial class CKInOutSummary : EntityBase
    {
        public static CKInOutSummary[] GetCKInOutSummaryListByInSummaryIDList(List<int> InSummaryIDList)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            if (InSummaryIDList.Count == 0)
            {
                return new CKInOutSummary[] { };
            }
            conditions.Add("[CKProudctInDetailID] in (select [ID] from [CKProudctInDetail] where [InSummaryID] in (" + string.Join(",", InSummaryIDList.ToArray()) + "))");
            return GetList<CKInOutSummary>("select * from CKInOutSummary where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
        public static CKInOutSummary[] GetCKInOutSummaryListByInDetailIDList(List<int> InDetailIDList)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            if (InDetailIDList.Count == 0)
            {
                return new CKInOutSummary[] { };
            }
            conditions.Add("[CKProudctInDetailID] in (" + string.Join(",", InDetailIDList.ToArray()) + ")");
            return GetList<CKInOutSummary>("select * from CKInOutSummary where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
    }
}
