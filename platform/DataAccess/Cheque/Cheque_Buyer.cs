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
    /// This object represents the properties and methods of a Cheque_Buyer.
    /// </summary>
    public partial class Cheque_Buyer : EntityBase
    {
        public static Cheque_Buyer[] GetCheque_BuyerList(string Keywords)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (!string.IsNullOrEmpty(Keywords))
            {
                parameters.Add(new SqlParameter("@Keywords", "%" + Keywords + "%"));
                conditions.Add("[BuyerName] like @Keywords");
            }
            return GetList<Cheque_Buyer>("select * from [Cheque_Buyer] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
        public static Cheque_Buyer[] GetCheque_BuyerByGUID(string guid)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (!string.IsNullOrEmpty(guid))
            {
                parameters.Add(new SqlParameter("@guid", guid));
                conditions.Add("[GUID]=@guid");
            }
            return GetList<Cheque_Buyer>("select * from [Cheque_Buyer] where " + string.Join(" and ", conditions.ToArray()) + " order by ID desc", parameters).ToArray();
        }
    }
}
