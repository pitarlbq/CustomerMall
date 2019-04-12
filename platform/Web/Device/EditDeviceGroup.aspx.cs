using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Device
{
    public partial class EditDeviceGroup : BasePage
    {
        public Foresight.DataAccess.Device_Group group = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int GroupID = 0;
                int.TryParse(Request.QueryString["ID"], out GroupID);
                if (GroupID > 0)
                {
                    group = Foresight.DataAccess.Device_Group.GetDevice_Group(GroupID);
                    if (group == null)
                    {
                        Response.Write("ID不合法");
                        Response.End();
                    }
                    this.tdCode.Value = group.Code;
                    this.tdDeviceGroupName.Value = group.DeviceGroupName;
                    this.tdRepairUserID.Value = group.RepairUserID > 0 ? group.RepairUserID.ToString() : "";
                    this.tdCheckUserID.Value = group.CheckUserID > 0 ? group.CheckUserID.ToString() : "";
                    this.tdDescription.Value = group.Description;
                }
            }
        }
    }
}