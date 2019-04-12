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
	/// This object represents the properties and methods of a Device_Image.
	/// </summary>
	public partial class Device_Image : EntityBase
	{
        public static Device_Image[] GetDevice_ImageListByDeviceID(int DeviceID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[DeviceID]=@DeviceID");
            parameters.Add(new SqlParameter("@DeviceID", DeviceID));
            return GetList<Device_Image>("select * from [Device_Image] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
	}
}
