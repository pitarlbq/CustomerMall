using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Device
{
    public partial class DeviceRepairCheckView : BasePage
    {
        public int DeviceID = 0;
        public string TaskType = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request.QueryString["DeviceID"], out DeviceID);
            TaskType = Request.QueryString["TaskType"];
        }
    }
}