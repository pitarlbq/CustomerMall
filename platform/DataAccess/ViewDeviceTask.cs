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
    /// This object represents the properties and methods of a ViewDeviceTask.
    /// </summary>
    public partial class ViewDeviceTask : EntityBaseReadOnly
    {
        public static ViewDeviceTask GetViewDeviceTaskByID(int ID)
        {
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            List<SqlParameter> parameters = new List<SqlParameter>();
            if (ID > 0)
            {
                conditions.Add("[ID]=@ID");
                parameters.Add(new SqlParameter("@ID", ID));
            }
            return GetOne<ViewDeviceTask>("select * from [ViewDeviceTask] where " + string.Join(" and ", conditions.ToArray()), parameters);
        }
        public static Ui.DataGrid GetViewDeviceTaskGridByKeywords(string Keywords, string TaskFrom, string TaskType, string NewTaskType, int DeviceID, int Status, string orderBy, long startRowIndex, int pageSize)
        {
            long totalRows = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (DeviceID > 0)
            {
                conditions.Add("[DeviceID]=@DeviceID");
                parameters.Add(new SqlParameter("@DeviceID", DeviceID));
            }
            if (!string.IsNullOrEmpty(Keywords))
            {
                conditions.Add("([ModelNo] like @Keywords or [DeviceName] like @Keywords or [DeviceNo] like @Keywords)");
                parameters.Add(new SqlParameter("@Keywords", "%" + Keywords + "%"));
            }
            if (!string.IsNullOrEmpty(TaskFrom))
            {
                conditions.Add("[TaskFrom]=@TaskFrom");
                parameters.Add(new SqlParameter("@TaskFrom", TaskFrom));
            }
            if (!string.IsNullOrEmpty(TaskType))
            {
                conditions.Add("[TaskType]=@TaskType");
                parameters.Add(new SqlParameter("@TaskType", TaskType));
            }
            if (Status > 0)
            {
                conditions.Add("[TaskStatus]=@TaskStatus");
                parameters.Add(new SqlParameter("@TaskStatus", Status));
            }
            if (!string.IsNullOrEmpty(NewTaskType))
            {
                if (NewTaskType.Equals("repair"))
                {
                    conditions.Add("[TaskType] in ('system_repair','manual_repair')");
                }
                if (NewTaskType.Equals("check"))
                {
                    conditions.Add("[TaskType] in ('system_check','manual_check')");
                }
            }
            string fieldList = "[ViewDeviceTask].*";
            string Statement = " from [ViewDeviceTask] where  " + string.Join(" and ", conditions.ToArray());
            ViewDeviceTask[] list = new ViewDeviceTask[] { };
            list = GetList<ViewDeviceTask>(fieldList, Statement, parameters, orderBy, startRowIndex, pageSize, out totalRows).ToArray();
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
        public static ViewDeviceTask[] GetViewDeviceTaskListByStatus(int status, int UserID, long startRowIndex, int pageSize, out long totalRows)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            string orderby = " order by [TaskAddTime] desc";
            conditions.Add("1=1");
            if (status > 0)
            {
                conditions.Add("[TaskStatus]=@TaskStatus");
                parameters.Add(new SqlParameter("@TaskStatus", status));
                if (status == 3)
                {
                    orderby = " order by [TaskCompleteTime] desc";
                }
            }
            if (UserID > 0 && status != 10)
            {
                conditions.Add("[TaskChargeManID]=@TaskChargeManID");
                parameters.Add(new SqlParameter("@TaskChargeManID", UserID));
            }
            string fieldList = "[ViewDeviceTask].*";
            string Statement = " from [ViewDeviceTask] where " + string.Join(" and ", conditions.ToArray());
            var list = GetList<ViewDeviceTask>(fieldList, Statement, parameters, orderby, startRowIndex, pageSize, out totalRows).ToArray();
            return list;
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
