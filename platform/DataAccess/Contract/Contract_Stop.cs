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
	/// This object represents the properties and methods of a Contract_Stop.
	/// </summary>
	public partial class Contract_Stop : EntityBase
	{
        public static Contract_Stop GetContract_StopByContractID(int ContractID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@ContractID", ContractID));
            return GetOne<Contract_Stop>("select top 1 * from [Contract_Stop] where ContractID=@ContractID order by [AddTime] desc", parameters);
        }
	}
}
