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
	/// This object represents the properties and methods of a Cheque_Project.
	/// </summary>
	public partial class Cheque_Project : EntityBase
	{
        public static Cheque_Project[] GetCheque_ProjectList(string Keywords)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (!string.IsNullOrEmpty(Keywords))
            {
                parameters.Add(new SqlParameter("@Keywords", "%" + Keywords + "%"));
                conditions.Add("[ProjectName] like @Keywords");
            }
            return GetList<Cheque_Project>("select * from [Cheque_Project] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
        public static Cheque_Project[] GetCheque_ProjectByGUID(string guid)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (!string.IsNullOrEmpty(guid))
            {
                parameters.Add(new SqlParameter("@guid", guid));
                conditions.Add("[GUID]=@guid");
            }
            return GetList<Cheque_Project>("select * from [Cheque_Project] where " + string.Join(" and ", conditions.ToArray()) + " order by ID desc", parameters).ToArray();
        }
	}
}
