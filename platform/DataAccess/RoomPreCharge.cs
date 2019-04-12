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
    /// This object represents the properties and methods of a RoomPreCharge.
    /// </summary>
    public partial class RoomPreCharge : EntityBase
    {
        public static RoomPreCharge[] GetRoomPreChargeListByRoomID(List<int> RoomIDs)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[RoomID] in (" + string.Join(",", RoomIDs.ToArray()) + ")");
            return GetList<RoomPreCharge>("select * from [RoomPreCharge] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
    }
}
