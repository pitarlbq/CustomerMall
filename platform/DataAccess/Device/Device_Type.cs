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
    /// This object represents the properties and methods of a Device_Type.
    /// </summary>
    public partial class Device_Type : EntityBase
    {
        public static Device_Type[] GetChildDevice_Types(List<int> IDList)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            return GetList<Device_Type>("select * from [Device_Type] where [ParentID] in (" + string.Join(",", IDList.ToArray()) + ")", parameters).ToArray();
        }
    }
}
