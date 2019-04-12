using Foresight.DataAccess;
using Foresight.DataAccess.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Utility;

namespace Web.APPCode
{
    public class DeviceHelper
    {
        //执行巡检任务生成
        public static int DoCheckTask()
        {
            int count = 0;
            DateTime NowDate = DateTime.Now;
            var devices = Foresight.DataAccess.Device.GetDevices().Where(p => p.DeviceStatus == 1 && p.FirstCheckDate > DateTime.MinValue && p.CheckCount > 0 && !string.IsNullOrEmpty(p.CheckCycle)).ToArray();
            if (devices.Length == 0)
            {
                return count;
            }
            var setting = DeviceSetting.GetDeviceSettingByCode(Utility.EnumModel.DeviceSettingCode.checktimesetup.ToString());
            List<Foresight.DataAccess.Device_Task> tasklist = new List<Device_Task>();
            List<Foresight.DataAccess.Device_TaskOperation> operationlist = new List<Device_TaskOperation>();
            List<Foresight.DataAccess.Device> devicelist = new List<Foresight.DataAccess.Device>();
            var appusers = Foresight.DataAccess.User.GetAPPUserList();
            foreach (var device in devices)
            {
                DateTime ThisCheckTime = device.FirstCheckDate;
                var check_log = Foresight.DataAccess.Device_TaskOperation.GetTopDevice_TaskOperation("check", device.ID);
                if (check_log != null)
                {
                    ThisCheckTime = check_log.ThisOperationTime;
                }
                DateTime NextCheckTime = DateTime.MinValue;
                DateTime NextAllowTime = GetNextCheckTime(setting, ThisCheckTime, device, out NextCheckTime);
                if (NextAllowTime > NowDate)
                {
                    continue;
                }
                var task = new Foresight.DataAccess.Device_Task();
                task.DeviceID = device.ID;
                task.TaskFrom = Utility.EnumModel.DeviceTaskFromDefine.system.ToString();
                task.TaskType = Utility.EnumModel.DeviceTaskTypeDefine.system_check.ToString();
                task.TaskLevel = "紧急";
                task.TaskStatus = 1;
                var user = appusers.FirstOrDefault(p => p.UserID == device.CheckUserID);
                task.TaskChargeManID = user == null ? int.MinValue : user.UserID;
                task.TaskChargeManName = user == null ? string.Empty : user.RealName;
                task.TaskChargeManPhone = user == null ? string.Empty : user.PhoneNumber;
                task.TaskContent = string.Empty;
                task.TaskTime = NextCheckTime;
                task.IsAPPSend = false;
                task.IsAPPShow = true;
                tasklist.Add(task);
                var operation = new Foresight.DataAccess.Device_TaskOperation();
                operation.DeviceID = device.ID;
                operation.OperationType = "check";
                operation.AddTime = NowDate;
                operation.ThisOperationTime = NextCheckTime;
                operationlist.Add(operation);
                device.LastCheckDate = device.ThisCheckDate;
                device.ThisCheckDate = NextCheckTime;
                devicelist.Add(device);
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    foreach (var item in tasklist)
                    {
                        item.Save(helper);
                        count++;
                    }
                    foreach (var item in operationlist)
                    {
                        item.Save(helper);
                    }
                    foreach (var item in devicelist)
                    {
                        item.Save(helper);
                    }
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    LogHelper.WriteError("巡检任务生成", "DoXunJianTask", ex);
                    helper.Rollback();
                }
            }
            return count;
        }

        public static DateTime GetNextCheckTime(DeviceSetting setting, DateTime StartTime, Foresight.DataAccess.Device device, out DateTime EndTime)
        {
            DateTime ResultTime = DateTime.MinValue;
            EndTime = DateTime.MinValue;
            if (device.CheckCycle.Equals(Utility.EnumModel.DeviceCycleType.day.ToString()))
            {
                EndTime = StartTime.AddDays(device.CheckCount);
            }
            else if (device.CheckCycle.Equals(Utility.EnumModel.DeviceCycleType.month.ToString()))
            {
                EndTime = StartTime.AddMonths(device.CheckCount);
            }
            if (setting == null || string.IsNullOrEmpty(setting.Parameters1) || string.IsNullOrEmpty(setting.Parameters2))
            {
                ResultTime = EndTime;
            }
            else if (setting.Parameters2.Equals(Utility.EnumModel.DeviceCycleType.day.ToString()))
            {
                int beforecount = 0;
                int.TryParse(setting.Parameters1, out beforecount);
                ResultTime = EndTime.AddDays(-beforecount);
            }
            else if (setting.Parameters2.Equals(Utility.EnumModel.DeviceCycleType.month.ToString()))
            {
                int beforecount = 0;
                int.TryParse(setting.Parameters1, out beforecount);
                ResultTime = EndTime.AddMonths(-beforecount);
            }
            return ResultTime;
        }
        //执行巡检任务生成
        public static int DoRepairTask()
        {
            int count = 0;
            DateTime NowDate = DateTime.Now;
            var devices = Foresight.DataAccess.Device.GetDevices().Where(p => p.DeviceStatus == 1 && p.FirstRepairDate > DateTime.MinValue && p.RepairCount > 0 && !string.IsNullOrEmpty(p.RepairCycle)).ToArray();
            if (devices.Length == 0)
            {
                return count;
            }
            var setting = DeviceSetting.GetDeviceSettingByCode(Utility.EnumModel.DeviceSettingCode.repairtimesetup.ToString());
            List<Foresight.DataAccess.Device_Task> tasklist = new List<Device_Task>();
            List<Foresight.DataAccess.Device_TaskOperation> operationlist = new List<Device_TaskOperation>();
            List<Foresight.DataAccess.Device> devicelist = new List<Foresight.DataAccess.Device>();
            var appusers = Foresight.DataAccess.User.GetAPPUserList();
            foreach (var device in devices)
            {
                DateTime ThisRepairTime = device.FirstRepairDate;
                var check_log = Foresight.DataAccess.Device_TaskOperation.GetTopDevice_TaskOperation("repair", device.ID);
                if (check_log != null)
                {
                    ThisRepairTime = check_log.ThisOperationTime;
                }
                DateTime NextRepairTime = DateTime.MinValue;
                DateTime NextAllowTime = GetNextRepairTime(setting, ThisRepairTime, device, out NextRepairTime);
                if (NextAllowTime > NowDate)
                {
                    continue;
                }
                var task = new Foresight.DataAccess.Device_Task();
                task.DeviceID = device.ID;
                task.TaskFrom = Utility.EnumModel.DeviceTaskFromDefine.system.ToString();
                task.TaskType = Utility.EnumModel.DeviceTaskTypeDefine.system_repair.ToString();
                task.TaskLevel = "紧急";
                task.TaskStatus = 1;
                var user = appusers.FirstOrDefault(p => p.UserID == device.RepairUserID);
                task.TaskChargeManID = user == null ? int.MinValue : user.UserID;
                task.TaskChargeManName = user == null ? string.Empty : user.RealName;
                task.TaskChargeManPhone = device.RepairUserPhone;
                task.TaskTime = NextRepairTime;
                task.IsAPPSend = false;
                task.IsAPPShow = true;
                tasklist.Add(task);
                var operation = new Foresight.DataAccess.Device_TaskOperation();
                operation.DeviceID = device.ID;
                operation.OperationType = "repair";
                operation.AddTime = NowDate;
                operation.ThisOperationTime = NextRepairTime;
                operationlist.Add(operation);
                device.LastRepairDate = device.ThisRepairDate;
                device.ThisRepairDate = NextRepairTime;
                devicelist.Add(device);
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    foreach (var item in tasklist)
                    {
                        item.Save(helper);
                        count++;
                    }
                    foreach (var item in operationlist)
                    {
                        item.Save(helper);
                    }
                    foreach (var item in devicelist)
                    {
                        item.Save(helper);
                    }
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    LogHelper.WriteError("维保任务生成", "DoRepairTask", ex);
                    helper.Rollback();
                }
            }
            return count;
        }
        public static DateTime GetNextRepairTime(DeviceSetting setting, DateTime StartTime, Foresight.DataAccess.Device device, out DateTime EndTime)
        {
            DateTime ResultTime = DateTime.MinValue;
            EndTime = DateTime.MinValue;
            if (device.RepairCycle.Equals(Utility.EnumModel.DeviceCycleType.day.ToString()))
            {
                EndTime = StartTime.AddDays(device.RepairCount);
            }
            else if (device.RepairCycle.Equals(Utility.EnumModel.DeviceCycleType.month.ToString()))
            {
                EndTime = StartTime.AddMonths(device.RepairCount);
            }
            if (setting == null || string.IsNullOrEmpty(setting.Parameters1) || string.IsNullOrEmpty(setting.Parameters2))
            {
                ResultTime = EndTime;
            }
            else if (setting.Parameters2.Equals(Utility.EnumModel.DeviceCycleType.day.ToString()))
            {
                int beforecount = 0;
                int.TryParse(setting.Parameters1, out beforecount);
                ResultTime = EndTime.AddDays(-beforecount);
            }
            else if (setting.Parameters2.Equals(Utility.EnumModel.DeviceCycleType.month.ToString()))
            {
                int beforecount = 0;
                int.TryParse(setting.Parameters1, out beforecount);
                ResultTime = EndTime.AddMonths(-beforecount);
            }
            return ResultTime;
        }
    }
}