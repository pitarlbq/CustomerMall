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
	/// This object represents the properties and methods of a Contract_Approve.
	/// </summary>
	public partial class Contract_Approve : EntityBase
	{
        public static Contract_Approve GetContract_ApproveByContractID(int ContractID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@ContractID", ContractID));
            return GetOne<Contract_Approve>("select top 1 * from [Contract_Approve] where ContractID=@ContractID order by [AddTime] desc", parameters);
        }
	}
}
