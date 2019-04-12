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
    /// This object represents the properties and methods of a Mall_DoorRemoteUser.
    /// </summary>
    public partial class Mall_DoorRemoteUser : EntityBase
    {
        public string IsForeverDesc
        {
            get
            {
                return this.IsForever ? "是" : "否";
            }
        }
        public string IsActiveDesc
        {
            get
            {
                return this.IsActive ? "是" : "否";
            }
        }
    }
    public partial class Mall_DoorRemoteUserDetail : Mall_DoorRemoteUser
    {
        public string NickName { get; set; }
        public string PhoneNumber { get; set; }
        public string DeviceInfo { get; set; }
        public string FullName { get; set; }
        public string RoomName { get; set; }
        public static Ui.DataGrid GetMall_DoorRemoteUserDetailGridByKeywords(string keywords, long startRowIndex, int pageSize)
        {
            long totalRows = 0;
            string OrderBy = " order by [AddTime] desc";
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (!string.IsNullOrEmpty(keywords))
            {
                conditions.Add("([Title] like @keywords or [UserID] in (select [UserID] from [User] where [NickName] like @keywords or [PhoneNumber] like @keywords) or [ProjectName] like @keywords)");
                parameters.Add(new SqlParameter("@keywords", "%" + keywords + "%"));
            }
            string fieldList = "[Mall_DoorRemoteUser].*";
            string Statement = " from [Mall_DoorRemoteUser] where  " + string.Join(" and ", conditions.ToArray());
            Mall_DoorRemoteUserDetail[] list = GetList<Mall_DoorRemoteUserDetail>(fieldList, Statement, parameters, OrderBy, startRowIndex, pageSize, out totalRows).ToArray();
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            if (list.Length > 0)
            {
                List<int> remote_idlist = list.Select(p => p.ID).ToList();
                var remote_device_list = Mall_DoorRemoteUserDevice.GetMall_DoorRemoteUserDevices().Where(p => remote_idlist.Contains(p.DoorRemoteID)).ToArray();
                int MinRelationID = list.Min(p => p.RoomPhoneRelationID);
                int MaxRelationID = list.Max(p => p.RoomPhoneRelationID);
                var device_list = Mall_DoorDevice.GetALLActiveMall_DoorDeviceList().ToArray();
                var user_list = Foresight.DataAccess.RoomPhoneRelation.GetRoomPhoneRelationListByMinMaxID(MinRelationID, MaxRelationID);
                int MinRoomID = 0;
                int MaxRoomID = 0;
                if (user_list.Length > 0)
                {
                    MinRoomID = user_list.Min(p => p.RoomID);
                    MaxRoomID = user_list.Max(p => p.RoomID);
                }
                var projectList = Project.GetProjectListByMinMaxID(MinRoomID, MaxRoomID);
                foreach (var item in list)
                {
                    var my_remote_device_list = remote_device_list.Where(p => p.DoorRemoteID == item.ID).ToArray();
                    List<int> my_deviceidlist = my_remote_device_list.Select(p => p.DoorDeviceID).ToList();
                    var my_device_list = device_list.Where(p => my_deviceidlist.Contains(p.DeviceID)).ToArray();
                    if (my_device_list.Length > 0)
                    {
                        item.DeviceInfo = string.Join(",", my_device_list.Select(p =>
                        {
                            return "【" + p.DeviceID + "," + p.DeviceName + "】";
                        }).ToArray());
                    }
                    var my_user = user_list.FirstOrDefault(p => p.ID == item.RoomPhoneRelationID);
                    if (my_user != null)
                    {
                        item.NickName = my_user.RelationName;
                        item.PhoneNumber = my_user.RelatePhoneNumber;
                        var myProject = projectList.FirstOrDefault(p => p.ID == my_user.RoomID);
                        if (myProject != null)
                        {
                            item.FullName = myProject.FullName + "-" + myProject.Name;
                            item.RoomName = myProject.Name;
                        }
                    }
                }
                dg.rows = list;
            }
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
    }
}
