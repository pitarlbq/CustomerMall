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
    /// This object represents the properties and methods of a RoomFee_BreakContract.
    /// </summary>
    public partial class RoomFee_BreakContract : EntityBase
    {
        public static RoomFee_BreakContract[] GetRoomFee_BreakContractList(int[] RoomFeeIDList)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (RoomFeeIDList.Length == 0)
            {
                return new RoomFee_BreakContract[] { };
            }
            conditions.Add("[RoomFeeID] in (" + string.Join(",", RoomFeeIDList) + ")");
            return GetList<RoomFee_BreakContract>("select * from [RoomFee_BreakContract] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
        public static RoomFee_BreakContract GetRoomFee_BreakContract(int RoomFeeID, int SummaryID, SqlHelper helper)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[RoomFeeID]=@RoomFeeID");
            conditions.Add("[SummaryID]=@SummaryID");
            parameters.Add(new SqlParameter("@RoomFeeID", RoomFeeID));
            parameters.Add(new SqlParameter("@SummaryID", SummaryID));
            return GetOne<RoomFee_BreakContract>("select top 1 * from [RoomFee_BreakContract] where " + string.Join(" and ", conditions.ToArray()), parameters);
        }
    }
}
