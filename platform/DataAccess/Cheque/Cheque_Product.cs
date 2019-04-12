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
	/// This object represents the properties and methods of a Cheque_Product.
	/// </summary>
	public partial class Cheque_Product : EntityBase
	{
        public static Cheque_Product[] GetCheque_ProductList(string Keywords)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (!string.IsNullOrEmpty(Keywords))
            {
                parameters.Add(new SqlParameter("@Keywords", "%" + Keywords + "%"));
                conditions.Add("[ProductName] like @Keywords");
            }
            return GetList<Cheque_Product>("select * from [Cheque_Product] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
	}
}
