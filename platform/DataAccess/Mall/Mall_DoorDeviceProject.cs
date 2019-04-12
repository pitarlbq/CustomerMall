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
    /// This object represents the properties and methods of a Mall_DoorDeviceProject.
    /// </summary>
    public partial class Mall_DoorDeviceProject : EntityBase
    {
        public static Mall_DoorDeviceProject[] GetMall_DoorDeviceProjectListByDeviceID(int DoorDeviceID)
        {
            if (DoorDeviceID <= 0)
            {
                return new Mall_DoorDeviceProject[] { };
            }
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[DoorDeviceID]=@DoorDeviceID");
            parameters.Add(new SqlParameter("@DoorDeviceID", DoorDeviceID));
            Mall_DoorDeviceProject[] list = GetList<Mall_DoorDeviceProject>("select * from [Mall_DoorDeviceProject] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
            return list;
        }
        public static Mall_DoorDeviceProject[] GetMall_DoorDeviceProjectListByDeviceIDList(List<int> DoorDeviceIDList)
        {
            if (DoorDeviceIDList.Count <= 0)
            {
                return new Mall_DoorDeviceProject[] { };
            }
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[DoorDeviceID] in (" + string.Join(",", DoorDeviceIDList.ToArray()) + ")");
            Mall_DoorDeviceProject[] list = GetList<Mall_DoorDeviceProject>("select * from [Mall_DoorDeviceProject] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
            return list;
        }
    }
}
