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
    /// This object represents the properties and methods of a ChargeFee.
    /// </summary>
    public partial class ChargeFee : EntityBase
    {
        public static ChargeFee[] GetChargeFeeListByChargeID(int ChargeID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("IsActive=1");
            if (ChargeID > 0)
            {
                conditions.Add("[ChargeID]=@ChargeID");
                parameters.Add(new SqlParameter("@ChargeID", ChargeID));
            }
            return GetList<ChargeFee>("select * from [ChargeFee] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
    }
    public class ChargeFeeDetails : ChargeFee
    {
        [DatabaseColumn("FeeID")]
        public int FeeID { get; set; }
        public static ChargeFeeDetails[] GetChargeFeeByChargeID(int ChargeID, int RoomID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("IsActive=1");
            if (ChargeID > 0)
            {
                conditions.Add("[ChargeID]=@ChargeID");
                parameters.Add(new SqlParameter("@ChargeID", ChargeID));
            }
            parameters.Add(new SqlParameter("@RoomID", RoomID));
            return GetList<ChargeFeeDetails>("select *,isnull((select top 1 ID from [RoomFee] where RoomID=@RoomID and [ChargeFeeID]=[ChargeFee].ID),0) as FeeID from [ChargeFee] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
    }
}
