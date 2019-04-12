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
    /// This object represents the properties and methods of a Carrier.
    /// </summary>
    public partial class Carrier : EntityBase
    {
        public static Carrier[] GetCarrierListByGroupID(int GroupID, string Keywords)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (GroupID > 0)
            {
                conditions.Add(" [ID] in (select [CarrierID] from [Carrier_Group] where [GroupID] = @GroupID)");
                parameters.Add(new SqlParameter("@GroupID", GroupID));
            }
            if (!string.IsNullOrEmpty(Keywords))
            {
                conditions.Add(" [CarrierName] like @Keywords");
                parameters.Add(new SqlParameter("@Keywords", "%" + Keywords + "%"));
            }
            return GetList<Carrier>("select * from [Carrier] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
    }
}
