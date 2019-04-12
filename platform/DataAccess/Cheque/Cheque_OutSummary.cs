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
	/// This object represents the properties and methods of a Cheque_OutSummary.
	/// </summary>
	public partial class Cheque_OutSummary : EntityBase
	{
        public static Cheque_OutSummary GetLastCheque_OutSummary()
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            string Statement = "select top 1 * from [Cheque_OutSummary] where isnull([SellerID],0)>0 order by ID desc";
            return GetOne<Cheque_OutSummary>(Statement, parameters);
        }
	}
}
