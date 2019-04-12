using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.APPSetup
{
    public partial class UserStaffMgr : BasePage
    {
        public int CanViewCoupon = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            CanViewCoupon = base.CheckAuthByModuleCode("1101383") ? 1 : 0;
        }
    }
}