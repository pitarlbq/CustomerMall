using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.APPSetup
{
    public partial class UserFamilyMgr : BasePage
    {
        public int UserID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["UserID"] != null)
            {
                int.TryParse(Request.QueryString["UserID"], out UserID);
            }
        }
    }
}