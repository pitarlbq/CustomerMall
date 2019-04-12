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
    /// This object represents the properties and methods of a Device.
    /// </summary>
    public partial class Device : EntityBase
    {
        public static Device[] GetAllWorkingDevices()
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            return GetList<Device>("select * from [Device] where isnull([IsInvalid],0)=0 and isnull([IsScrap],0)=0", parameters).ToArray();
        }
        public static Device[] GetDeviceListByParams(int[] TaskTypeIDList = null)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (TaskTypeIDList != null && TaskTypeIDList.Length > 0)
            {
                conditions.Add("[TaskTypeID] in (" + string.Join(",", TaskTypeIDList) + ")");
            }
            return GetList<Device>("select * from [Device] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
    }
}
