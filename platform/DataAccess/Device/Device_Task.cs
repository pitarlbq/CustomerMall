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
    /// This object represents the properties and methods of a Device_Task.
    /// </summary>
    public partial class Device_Task : EntityBase
    {
        public static Device_Task[] GetDevice_TaskListByDeviceIDList(List<int> DeviceIDList)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[DeviceID] in (" + string.Join(",", DeviceIDList.ToArray()) + ")");
            return GetList<Device_Task>("select * from [Device_Task] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
        public static int GetDevice_TaskCountByStatus(int UserID, int Status)
        {
            int count = 0;
            using (SqlHelper helper = new SqlHelper())
            {
                List<SqlParameter> parameters = new List<SqlParameter>();
                string cmdtext = string.Empty;
                if (Status == 10)
                {
                    cmdtext = "select count(1) from [Device_Task] where [TaskStatus]=@Status";
                }
                else
                {
                    cmdtext = "select count(1) from [Device_Task] where [TaskStatus]=@Status and [TaskChargeManID]=@UserID";
                    parameters.Add(new SqlParameter("@UserID", UserID));
                }
                parameters.Add(new SqlParameter("@Status", Status));
                var result = helper.ExecuteScalar(cmdtext, CommandType.Text, parameters);
                if (result != null)
                {
                    count = Convert.ToInt32(result);
                }
            }
            return count;
        }
        public string TaskStatusDesc
        {
            get
            {
                if (this.TaskStatus == 1)
                {
                    return "待处理";
                }
                else if (this.TaskStatus == 2)
                {
                    return "处理中";
                }
                else if (this.TaskStatus == 3)
                {
                    return "已完成";
                }
                return string.Empty;
            }
        }
        public string TaskFromDesc
        {
            get
            {
                if (string.IsNullOrEmpty(this.TaskFrom))
                {
                    return string.Empty;
                }
                return Utility.EnumHelper.GetDescription(typeof(Utility.EnumModel.DeviceTaskFromDefine), this.TaskFrom);
            }
        }
        public string TaskTypeDesc
        {
            get
            {
                if (string.IsNullOrEmpty(this.TaskType))
                {
                    return string.Empty;
                }
                return Utility.EnumHelper.GetDescription(typeof(Utility.EnumModel.DeviceTaskTypeDefine), this.TaskType);
            }
        }
    }
}
