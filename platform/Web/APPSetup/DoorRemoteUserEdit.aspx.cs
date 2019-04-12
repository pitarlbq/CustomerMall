using Foresight.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utility;

namespace Web.APPSetup
{
    public partial class DoorRemoteUserEdit : BasePage
    {
        public int RemoteID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["ID"] != null)
                {
                    int.TryParse(Request.QueryString["ID"], out RemoteID);
                }
                if (RemoteID > 0)
                {
                    var data = Foresight.DataAccess.Mall_DoorRemoteUser.GetMall_DoorRemoteUser(RemoteID);
                    if (data != null)
                    {
                        SetInfo(data);
                    }
                }
            }
        }
        private void SetInfo(Foresight.DataAccess.Mall_DoorRemoteUser data)
        {
            this.tdProjectID.Value = data.ProjectID > 0 ? data.ProjectID.ToString() : "";
            var card_device_list = Mall_DoorRemoteUserDevice.GetMall_DoorRemoteUserDeviceListByDoorRemoteID(data.ID);
            var device_list = Mall_DoorDevice.GetALLActiveMall_DoorDeviceList().Where(p => card_device_list.Select(q => q.DoorDeviceID).ToList().Contains(p.DeviceID)).ToArray();
            if (device_list.Length > 0)
            {
                this.tdDeviceList.Value = string.Join(",", device_list.Select(p => p.ID).ToArray());
                this.hdDeviceList.Value = JsonConvert.SerializeObject(device_list.Select(p => p.ID).ToArray());
            }
            var user = Foresight.DataAccess.RoomPhoneRelation.GetRoomPhoneRelation(data.RoomPhoneRelationID);
            if (user != null)
            {
                this.hdUserName.Value = user.RelationName + "\r\n" + user.RelatePhoneNumber;
                this.hdUserID.Value = user.UserID > 0 ? user.UserID.ToString("0") : "";
                this.hdRelationID.Value = user.ID.ToString();
                var project = Foresight.DataAccess.Project.GetProject(user.RoomID);
                if (project != null)
                {
                    this.hdUserName.Value += "\r\n" + project.FullName + "-" + project.Name;
                }
            }
            this.tdTile.Value = data.Title;
            this.tdDescription.Value = data.Description;
            this.tdIsForever.Value = data.IsForever ? "1" : "0";
            this.tdEndTime.Value = data.EndTime > DateTime.MinValue ? data.EndTime.ToString("yyyy-MM-dd") : "";
            this.tdIsActive.Value = data.IsActive ? "1" : "0";
        }
    }
}