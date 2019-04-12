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
    /// This object represents the properties and methods of a CarrierGroup.
    /// </summary>
    public partial class CarrierGroup : EntityBase
    {
        public static CarrierGroup[] GetCarrierGroupListByKeywords(string Keywords)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (!string.IsNullOrEmpty(Keywords))
            {
                conditions.Add("([CarrierGroupName] like @Keywords or [ID] in (select [GroupID] from [Carrier_Group] where [CarrierID] in (select [ID] from [Carrier] where CarrierName like @Keywords)))");
                parameters.Add(new SqlParameter("@Keywords", "%" + Keywords + "%"));
            }
            return GetList<CarrierGroup>("select * from [CarrierGroup] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
    }
}
