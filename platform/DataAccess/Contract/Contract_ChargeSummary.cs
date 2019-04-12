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
	/// This object represents the properties and methods of a Contract_ChargeSummary.
	/// </summary>
	public partial class Contract_ChargeSummary : EntityBase
	{
        public static Contract_ChargeSummary[] GetContract_ChargeSummaryList(int ContractID, string guid, int ChargeID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (ContractID > 0)
            {
                conditions.Add("[ContractID]=@ContractID");
                parameters.Add(new SqlParameter("@ContractID", ContractID));
            }
            else if (!string.IsNullOrEmpty(guid))
            {
                conditions.Add("[GUID]=@GUID");
                parameters.Add(new SqlParameter("@GUID", guid));
            }
            if (ChargeID > 0)
            {
                conditions.Add("[ChargeID]=@ChargeID");
                parameters.Add(new SqlParameter("@ChargeID", ChargeID));
            }
            return GetList<Contract_ChargeSummary>("select * from [Contract_ChargeSummary] where  " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
	}
}
