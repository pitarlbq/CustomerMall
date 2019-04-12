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
	/// This object represents the properties and methods of a Device_TaskOperation.
	/// </summary>
	public partial class Device_TaskOperation : EntityBase
	{
        public static Device_TaskOperation GetTopDevice_TaskOperation(string OperationType,int DeviceID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@OperationType", OperationType));
            parameters.Add(new SqlParameter("@DeviceID", DeviceID));
            return GetOne<Device_TaskOperation>("select top 1 * from [Device_TaskOperation] where [OperationType]=@OperationType and [DeviceID]=@DeviceID order by [ThisOperationTime] desc", parameters);
        }
	}
}
