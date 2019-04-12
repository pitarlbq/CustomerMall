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
	/// This object represents the properties and methods of a Cheque_Confirm.
	/// </summary>
	public partial class Cheque_Confirm : EntityBase
	{
        public static Cheque_Confirm GetCheque_ConfirmByInSummaryID(int InSummaryID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[SummaryID]=@InSummaryID");
            parameters.Add(new SqlParameter("@InSummaryID", InSummaryID));
            string Statement = "select * from [Cheque_Confirm] where  " + string.Join(" and ", conditions.ToArray());
            return GetOne<Cheque_Confirm>(Statement, parameters);
        }
	}
}
