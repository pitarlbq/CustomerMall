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
    public partial class DoorDeviceEdit : BasePage
    {
        public int DeviceID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["ID"] != null)
                {
                    int.TryParse(Request.QueryString["ID"], out DeviceID);
                }
                if (DeviceID > 0)
                {
                    var data = Foresight.DataAccess.Mall_DoorDevice.GetMall_DoorDevice(DeviceID);
                    if (data != null)
                    {
                        SetInfo(data);
                    }
                }
            }
        }
        private void SetInfo(Foresight.DataAccess.Mall_DoorDevice data)
        {
            this.tdProjectID.Value = data.ProjectID > 0 ? data.ProjectID.ToString() : "";
            this.tdDeviceName.Value = data.DeviceName;
            this.tdDeviceCode.Value = data.DeviceCode;
            this.tdUseForAll.Value = data.IsUseAll ? "1" : "2";
            var list = Mall_DoorDeviceProject.GetMall_DoorDeviceProjectListByDeviceID(data.ID);
            if (list.Length > 0)
            {
                List<int> ProjectIDList = list.Select(p => p.ProjectID).ToList();
                var projects = Foresight.DataAccess.Project.GetProjectListByIDs(ProjectIDList);
                if (projects.Length > 0)
                {
                    this.hdRoomID.Value = JsonConvert.SerializeObject(projects.Select(p => p.ID).ToArray());
                    this.tdRoomID.Value = string.Join(",", projects.Select(p => p.Name).ToArray());
                }
            }
            this.tdSortOrder.Value = data.SortOrder > 0 ? data.SortOrder.ToString("0") : "";
            this.tdDisableQrCodeOpen.Value = data.DisableQrCodeOpen ? "0" : "1";
        }
    }
}