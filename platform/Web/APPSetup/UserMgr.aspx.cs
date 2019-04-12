using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.APPSetup
{
    public partial class UserMgr : BasePage
    {
        public int CanEdit = 0;
        public int IsFuShunJu = 0;
        public int BusinessID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            CanEdit = base.CheckAuthByModuleCode("1101376") ? 1 : 0;
            var config = new Utility.SiteConfig();
            IsFuShunJu = config.IsFuShunJu ? 1 : 0;
        }
    }
}