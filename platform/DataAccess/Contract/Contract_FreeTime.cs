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
	/// This object represents the properties and methods of a Contract_FreeTime.
	/// </summary>
	public partial class Contract_FreeTime : EntityBase
	{
        public static Contract_FreeTime[] GetContract_FreeTimeList(int ContractID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (ContractID > 0)
            {
                conditions.Add("[ContractID]=@ContractID");
                parameters.Add(new SqlParameter("@ContractID", ContractID));
            }
            return GetList<Contract_FreeTime>("select * from [Contract_FreeTime] where  " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
	}
}
