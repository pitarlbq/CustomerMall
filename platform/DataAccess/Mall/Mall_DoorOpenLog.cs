using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Linq;
using Foresight.DataAccess.Framework;

namespace Foresight.DataAccess
{
    /// <summary>
    /// This object represents the properties and methods of a Mall_DoorOpenLog.
    /// </summary>
    public partial class Mall_DoorOpenLog : EntityBase
    {
        public static Mall_DoorOpenLog GetMaxMall_DoorOpenLogData()
        {
            string cmdtext = "select top 1 OpenTime from [Mall_DoorOpenLog] order by OpenTime desc";
            return GetOne<Mall_DoorOpenLog>(cmdtext, new List<SqlParameter>());
        }
        public static DateTime LastRemoteTime = DateTime.MinValue;
        public static void GetRemoteMallDoorLog(int pageSize)
        {
            if (LastRemoteTime > DateTime.MinValue && LastRemoteTime.AddSeconds(60 * 10) > DateTime.Now)
            {
                return;
            }
            LastRemoteTime = DateTime.Now;
            Utility.LLing_OpenDoorLogModel result = null;
            string error = "";
            //long total = Foresight.DataAccess.Mall_DoorOpenLog.GetMall_DoorOpenLogCount();
            //var count_result = Utility.LLingHelper.doQueryOpenDoorLog(1, 1, out error);
            //if (count_result.total > total)
            //{
            //    total = count_result.total - total + 100;
            //    result = Utility.LLingHelper.doQueryOpenDoorLog(1, total, out error);
            //}
            //if (result == null)
            //{
            //    return;
            //}
            var maxData = GetMaxMall_DoorOpenLogData();
            long totalDay = 50;
            if (maxData != null)
            {
                totalDay = (long)(DateTime.Now - maxData.OpenTime).TotalDays + 1;
                totalDay = totalDay > 50 ? 50 : totalDay;
            }
            result = Utility.LLingHelper.doQueryOpenDoorLog(1, 10000 * totalDay, out error);
            if (result == null || result.rows.Count == 0)
            {
                return;
            }
            Utility.LLing_OpenDoorLogRowsModel[] rows = null;
            if (maxData != null)
            {
                rows = result.rows.Where(p => p.OpenTime >= maxData.OpenTime).ToArray();
            }
            else
            {
                rows = result.rows.ToArray();
            }
            DateTime MinTime = rows.Min(p => p.OpenTime);
            var parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@OpenTime", MinTime));
            var list = GetList<Mall_DoorOpenLog>("select [DeviceID],[OpenTimeSpan] from [Mall_DoorOpenLog] where OpenTime>=@OpenTime", parameters).ToArray();
            List<string> cmdList = new List<string>();
            string cmdtext = "";
            int count = 0;
            foreach (var item in rows)
            {
                count++;
                var myItem = list.FirstOrDefault(p => p.DeviceID == item.deviceId && p.OpenTimeSpan == item.openTime);
                if (myItem == null)
                {
                    cmdtext += "insert into [Mall_DoorOpenLog] ([DeviceID],[OpenTime],[OpenType],[LingLingId],[OpenTimeSpan]) values ('" + item.deviceId.ToString() + "','" + item.OpenTimeDesc + "','" + item.openType.ToString() + "','" + item.lingLingId + "','" + item.openTime.ToString() + "');";
                }
                if ((count % pageSize == 0 || count == rows.Length) && !string.IsNullOrEmpty(cmdtext))
                {
                    cmdList.Add(cmdtext);
                    cmdtext = "";
                }
            }
            if (cmdList.Count > 0)
            {
                using (SqlHelper helper = new SqlHelper())
                {
                    try
                    {
                        parameters = new List<SqlParameter>();
                        helper.BeginTransaction();
                        foreach (var item in cmdList)
                        {
                            helper.Execute(item, CommandType.Text, parameters);
                        }
                        helper.Commit();
                    }
                    catch (Exception)
                    {
                        helper.Rollback();
                    }
                }
            }
        }
        public static Ui.DataGrid GetMall_DoorOpenLogDataGrid(string keywords, long startRowIndex, int pageSize, List<int> ProjectIDList, List<int> RoomIDList, DateTime StartTime, DateTime EndTime, bool canexport = false)
        {
            if (startRowIndex <= 1 && !canexport)
            {
                GetRemoteMallDoorLog(pageSize);
            }
            long totalRows = 0;
            string OrderBy = " order by [OpenTime] desc";
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (!string.IsNullOrEmpty(keywords))
            {
                conditions.Add("[DeviceName] like @keywords");
                parameters.Add(new SqlParameter("@keywords", "%" + keywords + "%"));
            }
            List<string> cmdlist = new List<string>();
            List<int> EqualIDList = new List<int>();
            List<int> InIDList = new List<int>();
            if (RoomIDList.Count > 0)
            {
                Project.GetMyProjectListByProjectIDList(RoomIDList, out EqualIDList, out InIDList);
            }
            else if (ProjectIDList.Count > 0)
            {
                Project.GetMyProjectListByProjectIDList(ProjectIDList, out EqualIDList, out InIDList);
            }
            if (EqualIDList.Count > 0)
            {
                EqualIDList.Add(0);
                cmdlist.Add("([ProjectID] in (" + string.Join(",", EqualIDList.ToArray()) + ") and [IsUseAll]=1)");
                cmdlist.Add("[Device_ID] in (select [DoorDeviceID] from [Mall_DoorDeviceProject] where [ProjectID] in (" + string.Join(",", EqualIDList.ToArray()) + "))");
            }
            if (InIDList.Count > 0)
            {
                List<string> subcmdlist = new List<string>();
                foreach (var InID in InIDList)
                {
                    subcmdlist.Add("AllParentID like '%," + InID.ToString() + ",%'");
                }
                cmdlist.Add("([ProjectID] in (select ID from [Project] where " + string.Join(" or ", subcmdlist.ToArray()) + ") and [IsUseAll]=1)");
                cmdlist.Add("[Device_ID] in (select [DoorDeviceID] from [Mall_DoorDeviceProject] where [ProjectID] in (select ID from [Project] where " + string.Join(" or ", subcmdlist.ToArray()) + "))");
            }
            if (cmdlist.Count > 0)
            {
                conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
            }
            if (StartTime > DateTime.MinValue)
            {
                conditions.Add("OpenTime>=@StartTime");
                parameters.Add(new SqlParameter("@StartTime", StartTime));
            }
            if (EndTime > DateTime.MinValue)
            {
                conditions.Add("OpenTime<=@EndTime");
                parameters.Add(new SqlParameter("@EndTime", EndTime));
            }
            string fieldList = "A.*";
            string Statement = " from (select Mall_DoorOpenLog.*,Mall_DoorDevice.[DeviceName],Mall_DoorDevice.ID as Device_ID,[Mall_DoorDevice].ProjectID,[Mall_DoorDevice].IsUseAll from [Mall_DoorOpenLog] left join [Mall_DoorDevice] on Mall_DoorDevice.DeviceID=Mall_DoorOpenLog.DeviceID)A where  " + string.Join(" and ", conditions.ToArray());
            Mall_DoorOpenLogDetail[] list = new Mall_DoorOpenLogDetail[] { }; ;
            if (canexport)
            {
                list = GetList<Mall_DoorOpenLogDetail>("select " + fieldList + Statement + " " + OrderBy, parameters).ToArray();
                totalRows = list.Length;
            }
            else
            {
                list = GetList<Mall_DoorOpenLogDetail>(fieldList, Statement, parameters, OrderBy, startRowIndex, pageSize, out totalRows).ToArray();
            }
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
        public string OpenTimeDesc
        {
            get
            {
                string desc = this.OpenTime.ToString("yyyy-MM-dd HH:mm:ss");
                return desc;
            }
        }
        public string OpenTypeDesc
        {
            get
            {
                string desc = "";
                switch (this.OpenType)
                {
                    case 2:
                        desc = "业主二维码开门";
                        break;
                    case 3:
                        desc = "门禁访客二维码开门";
                        break;
                    case 4:
                        desc = "梯控访客二维码";
                        break;
                    case 5:
                        desc = "远程开门";
                        break;
                    case 6:
                        desc = "NFC开门";
                        break;
                    default:
                        break;
                }
                return desc;
            }
        }
    }
    public partial class Mall_DoorOpenLogDetail : Mall_DoorOpenLog
    {
        [DatabaseColumn("DeviceName")]
        public string DeviceName { get; set; }
        [DatabaseColumn("Device_ID")]
        public int Device_ID { get; set; }
        [DatabaseColumn("ProjectID")]
        public int ProjectID { get; set; }
        [DatabaseColumn("IsUseAll")]
        public bool IsUseAll { get; set; }
    }
}
