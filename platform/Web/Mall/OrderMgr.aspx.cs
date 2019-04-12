using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Mall
{
    public partial class OrderMgr : BasePage
    {
        public int status = 0;
        public int ShareUserID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["status"] != null)
            {
                int.TryParse(Request.QueryString["status"], out status);
            }
            if (Request.QueryString["ShareUserID"] != null)
            {
                int.TryParse(Request.QueryString["ShareUserID"], out ShareUserID);
            }
        }
    }
}