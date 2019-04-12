using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Mall
{
    public partial class BusinessMgr : BasePage
    {
        public int Status = 0;
        public bool CanApprove = false;
        public bool IsMallBusinessOn = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["status"] != null)
                {
                    int.TryParse(Request.QueryString["status"], out Status);
                }
                IsMallBusinessOn = new Utility.SiteConfig().IsMallBusinessOn;
                if (base.CheckAuthByModuleCode("1101413") && Status != 1 && IsMallBusinessOn)
                {
                    CanApprove = true;
                }
            }
        }
    }
}