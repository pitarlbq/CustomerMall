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
    /// This object represents the properties and methods of a Mall_DoorDevice.
    /// </summary>
    public partial class Mall_DoorDevice : EntityBase
    {
        public string BindDeviceName { get; set; }
        public static Mall_DoorDevice[] GetALLActiveMall_DoorDeviceList()
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("isnull([IsDelete],0)=0");
            Mall_DoorDevice[] list = GetList<Mall_DoorDevice>("select * from [Mall_DoorDevice] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
            return list;
        }
        private static void UpdateMall_DoorDeviceOnLineStatus()
        {
            var db_list = Mall_DoorDevice.GetMall_DoorDevices().ToArray();
            List<Mall_DoorDevice> all_device_list = new List<Mall_DoorDevice>();
            var device_list = Utility.LLingHelper.doQueryDeviceList();
            if (device_list.Count > 0)
            {
                foreach (var item in device_list)
                {
                    var my_device = db_list.FirstOrDefault(p => p.DeviceID == item.deviceId);
                    if (my_device == null)
                    {
                        my_device = new Mall_DoorDevice();
                        my_device.AddTime = DateTime.Now;
                        my_device.DeviceID = item.deviceId;
                        my_device.ProjectID = 0;
                        my_device.AddUserName = "System";
                        my_device.DeviceName = item.deviceName;
                    }
                    my_device.IsDelete = false;
                    my_device.Status = item.isOnline;
                    my_device.DeviceCode = item.deviceCode;
                    all_device_list.Add(my_device);
                }
            }
            List<int> DeviceIDList = device_list.Select(p => p.deviceId).ToList();
            var useless_list = db_list.Where(p => !DeviceIDList.Contains(p.DeviceID)).ToArray();
            foreach (var item in useless_list)
            {
                item.IsDelete = true;
                all_device_list.Add(item);
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    foreach (var item in all_device_list)
                    {
                        item.Save(helper);
                    }
                    helper.Commit();
                }
                catch (Exception)
                {
                    helper.Rollback();
                }
            }
        }
        public static Ui.DataGrid GetMall_DoorDeviceGridByKeywords(string keywords, long startRowIndex, int pageSize, List<int> ProjectIDList, List<int> RoomIDList)
        {
            UpdateMall_DoorDeviceOnLineStatus();
            long totalRows = 0;
            string OrderBy = " order by [SortOrder] asc, AddTime desc";
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("isnull([IsDelete],0)=0");
            if (!string.IsNullOrEmpty(keywords))
            {
                conditions.Add("([DeviceName] like @keywords or [DeviceCode] like @keywords)");
                parameters.Add(new SqlParameter("@keywords", "%" + keywords + "%"));
            }
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
            List<string> cmdlist = new List<string>();
            if (EqualIDList.Count > 0)
            {
                EqualIDList.Add(0);
                cmdlist.Add("([ProjectID] in (" + string.Join(",", EqualIDList.ToArray()) + ") and [IsUseAll]=1)");
                cmdlist.Add("[ID] in (select [DoorDeviceID] from [Mall_DoorDeviceProject] where [ProjectID] in (" + string.Join(",", EqualIDList.ToArray()) + "))");
            }
            if (InIDList.Count > 0)
            {
                List<string> subcmdlist = new List<string>();
                foreach (var InID in InIDList)
                {
                    subcmdlist.Add("(ID=" + InID + " or AllParentID like '%," + InID.ToString() + ",%')");
                }
                cmdlist.Add("([ProjectID] in (select ID from [Project] where " + string.Join(" or ", subcmdlist.ToArray()) + ") and [IsUseAll]=1)");
                cmdlist.Add("[ID] in (select [DoorDeviceID] from [Mall_DoorDeviceProject] where [ProjectID] in (select ID from [Project] where " + string.Join(" or ", subcmdlist.ToArray()) + "))");
            }
            if (cmdlist.Count > 0)
            {
                conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
            }
            string fieldList = "[Mall_DoorDevice].*";
            string Statement = " from [Mall_DoorDevice] where  " + string.Join(" and ", conditions.ToArray());
            Mall_DoorDevice[] list = GetList<Mall_DoorDevice>(fieldList, Statement, parameters, OrderBy, startRowIndex, pageSize, out totalRows).ToArray();
            if (list.Length > 0)
            {
                var device_project_list = Mall_DoorDeviceProject.GetMall_DoorDeviceProjectListByDeviceIDList(list.Select(p => p.ID).ToList());
                var project_list = Project.GetMall_DoorDeviceProjectListByDoorDeviceIDList(list.Select(p => p.ID).ToList());
                foreach (var item in list)
                {
                    if (item.IsUseAll)
                    {
                        item.BindDeviceName = "所有楼栋";
                    }
                    else
                    {
                        var my_device_project_list = device_project_list.Where(p => p.DoorDeviceID == item.ID).ToArray();
                        List<int> device_project_idlist = my_device_project_list.Select(p => p.ProjectID).ToList();
                        var my_project_list = project_list.Where(p => device_project_idlist.Contains(p.ID));
                        List<string> my_project_names = my_project_list.Select(p =>
                        {
                            string result = string.Empty;
                            if (p.isParent)
                            {
                                result = p.FullName;
                            }
                            else
                            {
                                result = p.FullName + p.Name;
                            }
                            return result;
                        }).ToList();
                        if (my_project_names.Count > 0)
                        {
                            item.BindDeviceName = string.Join(",", my_project_names.ToArray());
                        }
                    }
                }
            }
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
        public static Mall_DoorDevice[] GetMall_DoorDeviceList(List<int> DeviceIDList)
        {
            if (DeviceIDList.Count == 0)
            {
                return new Mall_DoorDevice[] { };
            }
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("isnull([IsDelete],0)=0");
            conditions.Add("[DeviceID] in (" + string.Join(",", DeviceIDList.ToArray()) + ")");
            Mall_DoorDevice[] list = GetList<Mall_DoorDevice>("select * from [Mall_DoorDevice] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
            return list;
        }
        public static Mall_DoorDevice GetMall_DoorDeviceSDKKeyByID(int ID)
        {
            var data = Mall_DoorDevice.GetMall_DoorDevice(ID);
            if (data == null)
            {
                return null;
            }
            if (data.IsDelete)
            {
                return null;
            }
            DateTime now = DateTime.Now;
            if (string.IsNullOrEmpty(data.SDKKey) || data.SDKKeyExpireDate <= now)
            {
                data.SDKKey = string.Empty;
                data.SDKKeyExpireDate = DateTime.MinValue;
                string error = string.Empty;
                var response = Utility.LLingHelper.doQueryDeviceSDKKeyList(new int[] { data.DeviceID }, out error);
                if (response.ContainsKey(data.DeviceID))
                {
                    data.SDKKey = response[data.DeviceID];
                    data.SDKKeyExpireDate = now.AddDays(99);
                }
                data.Save();
            }
            if (string.IsNullOrEmpty(data.SDKKey))
            {
                return null;
            }
            return data;
        }
        public static Mall_DoorDevice[] GetRemoteMall_DoorDeviceSDKKeyByUserID(int UserID, int SelfUserID = 0)
        {
            UpdateMall_DoorDeviceOnLineStatus();
            List<SqlParameter> parameters = new List<SqlParameter>();
            string cmdwhere = "and [RoomPhoneRelationID] in (select [ID] from [RoomPhoneRelation] where [UserID]=@UserID)";
            if (SelfUserID > 0)
            {
                cmdwhere = " and [RoomPhoneRelationID] in (select [ID] from [RoomPhoneRelation] where[UserID]=@UserID or [UserID]=@SelfUserID)";
                parameters.Add(new SqlParameter("@SelfUserID", SelfUserID));
            }
            string cmdtext = "select * from [Mall_DoorDevice] where isnull([IsDelete],0)=0 and [DeviceID] in (select [DoorDeviceID] from [Mall_DoorRemoteUserDevice] where [DoorRemoteID] in (select [ID] from [Mall_DoorRemoteUser] where 1=1 " + cmdwhere + " and [IsActive]=1 and ([IsForever]=1 or ([IsForever]=0 and EndTime<=@EndTime))))";
            parameters.Add(new SqlParameter("@UserID", UserID));
            parameters.Add(new SqlParameter("@EndTime", DateTime.Now));
            var list1 = GetList<Mall_DoorDevice>(cmdtext, parameters).ToList();
            var list2 = GetMall_DoorDeviceSDKKeyByUserID(UserID, SelfUserID: SelfUserID).ToList();
            if (list1.Count == 0 && list2.Count == 0)
            {
                return new Mall_DoorDevice[] { };
            }
            var list = list2.Where(p => !(list1.Select(q => q.ID).ToList()).Contains(p.ID)).ToList();
            list.AddRange(list1);
            DateTime now = DateTime.Now;
            var valid_list = list.Where(p => !string.IsNullOrEmpty(p.SDKKey) && p.SDKKeyExpireDate > now).ToList();
            var invalid_list = list.Where(p => string.IsNullOrEmpty(p.SDKKey) || p.SDKKeyExpireDate <= now).ToList();
            if (invalid_list.Count > 0)
            {
                string error = string.Empty;
                var response = Utility.LLingHelper.doQueryDeviceSDKKeyList(invalid_list.Select(p => p.DeviceID).ToArray(), out error);
                foreach (var item in invalid_list)
                {
                    item.SDKKey = string.Empty;
                    item.SDKKeyExpireDate = DateTime.MinValue;
                    if (response.ContainsKey(item.DeviceID))
                    {
                        item.SDKKey = response[item.DeviceID];
                        item.SDKKeyExpireDate = now.AddDays(99);
                    }
                    item.Save();
                }
            }
            valid_list.AddRange(invalid_list);
            return valid_list.Where(p => !string.IsNullOrEmpty(p.SDKKey) && p.SDKKeyExpireDate > now).ToArray();
        }
        public static Mall_DoorDevice[] GetMall_DoorDeviceSDKKeyByUserID(int UserID, int SelfUserID = 0)
        {
            var project_list = Project.GetProjectListByAPPUserID(UserID, SelfUserID: SelfUserID);
            if (project_list.Length == 0)
            {
                return new Mall_DoorDevice[] { };
            }
            List<int> AllParentIDList = new List<int>();
            foreach (var project in project_list)
            {
                string[] all_parent_project_ids = project.AllParentID.Split(',').ToArray();
                foreach (var all_parent_id in all_parent_project_ids)
                {
                    if (string.IsNullOrEmpty(all_parent_id))
                    {
                        continue;
                    }
                    int AllParentID = 0;
                    int.TryParse(all_parent_id, out AllParentID);
                    if (AllParentID <= 0)
                    {
                        continue;
                    }
                    AllParentIDList.Add(AllParentID);
                }
                AllParentIDList.Add(project.ID);
            }
            if (AllParentIDList.Count == 0)
            {
                return new Mall_DoorDevice[] { };
            }
            var device_project_list = Mall_DoorDeviceProject.GetMall_DoorDeviceProjects().Where(p => AllParentIDList.Contains(p.ProjectID)).ToArray();
            List<int> device_idlist = device_project_list.Select(p => p.DoorDeviceID).Distinct().ToList();
            var list = Mall_DoorDevice.GetALLActiveMall_DoorDeviceList().Where(p => device_idlist.Contains(p.ID) || (p.IsUseAll && AllParentIDList.Contains(p.ProjectID))).ToArray();
            if (list.Length == 0)
            {
                return list;
            }

            DateTime now = DateTime.Now;
            var valid_list = list.Where(p => !string.IsNullOrEmpty(p.SDKKey) && p.SDKKeyExpireDate > now).ToList();
            var invalid_list = list.Where(p => string.IsNullOrEmpty(p.SDKKey) || p.SDKKeyExpireDate <= now).ToList();
            if (invalid_list.Count > 0)
            {
                string error = string.Empty;
                var response = Utility.LLingHelper.doQueryDeviceSDKKeyList(invalid_list.Select(p => p.DeviceID).ToArray(), out error);
                foreach (var item in invalid_list)
                {
                    item.SDKKey = string.Empty;
                    item.SDKKeyExpireDate = DateTime.MinValue;
                    if (response.ContainsKey(item.DeviceID))
                    {
                        item.SDKKey = response[item.DeviceID];
                        item.SDKKeyExpireDate = now.AddDays(99);
                    }
                    item.Save();
                }
            }
            valid_list.AddRange(invalid_list);

            var results = valid_list.Where(p => !string.IsNullOrEmpty(p.SDKKey) && p.SDKKeyExpireDate > now).ToArray();

            //Utility.LogHelper.WriteInfo("DeviceIDList." + UserID.ToString(), Utility.JsonConvert.SerializeObject(results.Select(p => p.DeviceName)));

            return results;
        }
        public string StatusDesc
        {
            get
            {
                return this.Status == 1 ? "在线" : "离线";
            }
        }
    }
}
