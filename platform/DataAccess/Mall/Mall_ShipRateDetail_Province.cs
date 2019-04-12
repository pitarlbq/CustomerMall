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
    /// This object represents the properties and methods of a Mall_ShipRateDetail_Province.
    /// </summary>
    public partial class Mall_ShipRateDetail_Province : EntityBase
    {
        public static Mall_ShipRateDetail_Province[] GetMall_ShipRateDetail_ProvinceListByRateID(int RateID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (RateID <= 0)
            {
                return new Mall_ShipRateDetail_Province[] { };
            }
            conditions.Add("[RateID]=@RateID");
            parameters.Add(new SqlParameter("@RateID", RateID));
            return GetList<Mall_ShipRateDetail_Province>("select * from [Mall_ShipRateDetail_Province] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
    }
}
