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
	/// This object represents the properties and methods of a Cheque_OutingFile.
	/// </summary>
	public partial class Cheque_OutingFile : EntityBase
	{
        public static Cheque_OutingFile[] GetCheque_OutingFileList(int OutingID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (OutingID > 0)
            {
                conditions.Add("[OutingID]=@OutingID");
                parameters.Add(new SqlParameter("@OutingID", OutingID));
            }
            Cheque_OutingFile[] list = GetList<Cheque_OutingFile>("select * from [Cheque_OutingFile] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
            return list;
        }
	}
}
