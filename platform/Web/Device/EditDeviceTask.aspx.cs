using Foresight.DataAccess.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Device
{
    public partial class EditDeviceTask : BasePage
    {
        public int TaskID = 0;
        public Foresight.DataAccess.ViewDeviceTask device;
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request.QueryString["ID"], out TaskID);
            if (TaskID > 0)
            {
                device = Foresight.DataAccess.ViewDeviceTask.GetViewDeviceTaskByID(TaskID);
                if (device != null)
                {
                    SetInfo(device);
                }
            }
        }
        private void SetInfo(Foresight.DataAccess.ViewDeviceTask data)
        {
            hdDeviceID.Value = data.DeviceID > 0 ? data.DeviceID.ToString() : "0";
            this.tdDeviceName.Value = data.DeviceName;
            this.tdDeviceType.Value = data.DeviceTypeName;
            this.tdDeviceGroup.Value = data.DeviceGroupName;
            this.tdModelNo.Value = data.ModelNo;
            this.tdTaskFrom.Value = data.TaskFrom;
            this.tdTaskType.Value = data.TaskType;
            this.tdTaskLevel.Value = data.TaskLevel;
            this.tdTaskStatus.Value = data.TaskStatus > 0 ? data.TaskStatus.ToString() : "1";
            this.tdTaskChargeMan.Value = data.TaskChargeManID > 0 ? data.TaskChargeManID.ToString() : "";
            this.tdTaskChargeManPhone.Value = data.TaskChargeManPhone;
            this.tdTaskContent.Value = data.TaskContent;
            this.tdTaskTime.Value = data.TaskTime > DateTime.MinValue ? data.TaskTime.ToString("yyyy-MM-dd HH:mm:ss") : "";
            this.tdTaskCompleteTime.Value = data.TaskCompleteTime > DateTime.MinValue ? data.TaskCompleteTime.ToString("yyyy-MM-dd HH:mm:ss") : "";
            this.tdTaskCompleteContent.Value = data.TaskCompleteContent;
        }
    }
}