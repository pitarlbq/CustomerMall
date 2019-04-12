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
	/// This object represents the properties and methods of a Cheque_OutSummaryFile.
	/// </summary>
	public partial class Cheque_OutSummaryFile : EntityBase
	{
        public static Cheque_OutSummaryFile[] GetCheque_OutSummaryFileList(int OutSummaryID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (OutSummaryID > 0)
            {
                conditions.Add("[OutSummaryID]=@OutSummaryID");
                parameters.Add(new SqlParameter("@OutSummaryID", OutSummaryID));
            }
            Cheque_OutSummaryFile[] list = GetList<Cheque_OutSummaryFile>("select * from [Cheque_OutSummaryFile] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
            return list;
        }
	}
}
