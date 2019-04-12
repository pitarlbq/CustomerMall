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
	/// This object represents the properties and methods of a Cheque_Seller.
	/// </summary>
	public partial class Cheque_Seller : EntityBase
	{
        public static Cheque_Seller[] GetCheque_SellerList(string Keywords)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (!string.IsNullOrEmpty(Keywords))
            {
                parameters.Add(new SqlParameter("@Keywords", "%" + Keywords + "%"));
                conditions.Add("[SellerName] like @Keywords");
            }
            return GetList<Cheque_Seller>("select * from [Cheque_Seller] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
        public static Cheque_Seller[] GetCheque_SellerByGUID(string guid)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (!string.IsNullOrEmpty(guid))
            {
                parameters.Add(new SqlParameter("@guid", guid));
                conditions.Add("[GUID]=@guid");
            }
            return GetList<Cheque_Seller>("select * from [Cheque_Seller] where " + string.Join(" and ", conditions.ToArray()) + " order by ID desc", parameters).ToArray();
        }
	}
}
