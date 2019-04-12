using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.APPSetup
{
    public partial class DoorDeviceMgr : BasePage
    {
        public int CanRemoteOpen = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            CanRemoteOpen = base.CheckAuthByModuleCode("1101395") ? 1 : 0;
        }
    }
}