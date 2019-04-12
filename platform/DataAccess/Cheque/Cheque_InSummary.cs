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
	/// This object represents the properties and methods of a Cheque_InSummary.
	/// </summary>
	public partial class Cheque_InSummary : EntityBase
	{
        public static Cheque_InSummary GetLastCheque_InSummary()
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            string Statement = "select top 1 * from [Cheque_InSummary] where isnull([SellerID],0)>0 order by ID desc";
            return GetOne<Cheque_InSummary>(Statement, parameters);
        }
        public static Cheque_InSummary GetCheque_InSummaryByChequeCode(string ChequeCode)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[ChequeCode]=@ChequeCode");
            parameters.Add(new SqlParameter("@Cheque_InSummary", ChequeCode));
            string Statement = "select * from [Cheque_InSummary] where  " + string.Join(" and ", conditions.ToArray());
            return GetOne<Cheque_InSummary>(Statement, parameters);
        }
	}
}
