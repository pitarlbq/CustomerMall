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
    /// This object represents the properties and methods of a DeviceSetting.
    /// </summary>
    public partial class DeviceSetting : EntityBase
    {
        public static DeviceSetting GetDeviceSettingByCode(string ModuleCode)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[ModuleCode]=@ModuleCode");
            parameters.Add(new SqlParameter("@ModuleCode", ModuleCode));
            return GetOne<DeviceSetting>("select * from [DeviceSetting] where " + string.Join(" and ", conditions.ToArray()), parameters);
        }
    }
}
