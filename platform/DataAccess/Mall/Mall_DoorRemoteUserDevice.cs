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
	/// This object represents the properties and methods of a Mall_DoorRemoteUserDevice.
	/// </summary>
	public partial class Mall_DoorRemoteUserDevice : EntityBase
	{
        public static Mall_DoorRemoteUserDevice[] GetMall_DoorRemoteUserDeviceListByDoorRemoteID(int DoorRemoteID)
        {
            if (DoorRemoteID <= 0)
            {
                return new Mall_DoorRemoteUserDevice[] { };
            }
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[DoorRemoteID]=@DoorRemoteID");
            parameters.Add(new SqlParameter("@DoorRemoteID", DoorRemoteID));
            Mall_DoorRemoteUserDevice[] list = GetList<Mall_DoorRemoteUserDevice>("select * from [Mall_DoorRemoteUserDevice] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
            return list;
        }
	}
}
