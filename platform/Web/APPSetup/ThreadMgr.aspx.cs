using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.APPSetup
{
    public partial class ThreadMgr : BasePage
    {
        public int Type = 1;
        public int CanViewThread = 0;
        public int CanViewComment = 0;
        public int CanStopComment = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["type"] != null)
                {
                    int.TryParse(Request.QueryString["type"], out Type);
                }
                if ((base.CheckAuthByModuleCode("1101354") && Type == 1) || (base.CheckAuthByModuleCode("1101362") && Type == 2))
                {
                    this.CanViewThread = 1;
                }

                if ((base.CheckAuthByModuleCode("1101356") && Type == 1) || (base.CheckAuthByModuleCode("1101364") && Type == 2))
                {
                    this.CanViewComment = 1;
                }
                if ((base.CheckAuthByModuleCode("1101357") && Type == 1) || (base.CheckAuthByModuleCode("1101365") && Type == 2))
                {
                    this.CanStopComment = 1;
                }
            }
        }
    }
}