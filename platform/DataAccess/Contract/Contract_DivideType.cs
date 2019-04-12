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
	/// This object represents the properties and methods of a Contract_DivideType.
	/// </summary>
	public partial class Contract_DivideType : EntityBase
	{
        public static Contract_DivideType[] GetContract_DivideTypeList(int DivideID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[Contract_DivideID]=@DivideID");
            parameters.Add(new SqlParameter("@DivideID", DivideID));
            return GetList<Contract_DivideType>("select * from [Contract_DivideType] where " + string.Join(" and ", conditions.ToArray()) + " order by AddTime desc", parameters).ToArray();
        }
	}
}
