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
    /// This object represents the properties and methods of a Contract_Print.
    /// </summary>
    public partial class Contract_Print : EntityBase
    {
        public static Contract_Print GetContract_PrintByContractID(int ContractID, int ContractTemplateID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[ContractID]=@ContractID");
            parameters.Add(new SqlParameter("@ContractID", ContractID));
            conditions.Add("[ContractTemplateID]=@ContractTemplateID");
            parameters.Add(new SqlParameter("@ContractTemplateID", ContractTemplateID));
            return GetOne<Contract_Print>("select * from [Contract_Print] where " + string.Join(" and ", conditions.ToArray()), parameters);
        }
    }
}
