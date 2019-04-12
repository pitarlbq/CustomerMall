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
	/// This object represents the properties and methods of a Cheque_InSummaryFile.
	/// </summary>
	public partial class Cheque_InSummaryFile : EntityBase
	{
        public static Cheque_InSummaryFile[] GetCheque_InSummaryFileList(int InSummaryID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (InSummaryID > 0)
            {
                conditions.Add("[InSummaryID]=@InSummaryID");
                parameters.Add(new SqlParameter("@InSummaryID", InSummaryID));
            }
            Cheque_InSummaryFile[] list = GetList<Cheque_InSummaryFile>("select * from [Cheque_InSummaryFile] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
            return list;
        }
	}
}
