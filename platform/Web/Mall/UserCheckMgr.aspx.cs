using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Mall
{
    public partial class UserCheckMgr : BasePage
    {
        public int approvestatus = -1;
        public int confirmstatus = -1;
        public int processstatus = -1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["approvestatus"] != null)
                {
                    int.TryParse(Request.QueryString["approvestatus"], out approvestatus);
                }
                if (Request.QueryString["confirmstatus"] != null)
                {
                    int.TryParse(Request.QueryString["confirmstatus"], out confirmstatus);
                }
                if (Request.QueryString["processstatus"] != null)
                {
                    int.TryParse(Request.QueryString["processstatus"], out processstatus);
                }
            }
        }
    }
}