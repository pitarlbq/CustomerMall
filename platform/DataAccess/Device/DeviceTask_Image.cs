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
    /// This object represents the properties and methods of a DeviceTask_Image.
    /// </summary>
    public partial class DeviceTask_Image : EntityBase
    {
        public static DeviceTask_Image[] GetDeviceTask_ImageListByDeviceTaskID(int DeviceTaskID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[DeviceTaskID]=@DeviceTaskID");
            parameters.Add(new SqlParameter("@DeviceTaskID", DeviceTaskID));
            return GetList<DeviceTask_Image>("select * from [DeviceTask_Image] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
    }
}
