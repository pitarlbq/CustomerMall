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
    /// This object represents the properties and methods of a Mall_DoorCardDevice.
    /// </summary>
    public partial class Mall_DoorCardDevice : EntityBase
    {
        public static Mall_DoorCardDevice[] GetMall_DoorCardDeviceListByCardID(int CardID)
        {
            if (CardID <= 0)
            {
                return new Mall_DoorCardDevice[] { };
            }
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[DoorCardID]=@DoorCardID");
            parameters.Add(new SqlParameter("@DoorCardID", CardID));
            Mall_DoorCardDevice[] list = GetList<Mall_DoorCardDevice>("select * from [Mall_DoorCardDevice] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
            return list;
        }
    }
}
