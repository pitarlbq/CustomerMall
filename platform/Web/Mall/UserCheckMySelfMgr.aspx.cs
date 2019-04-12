using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Mall
{
    public partial class UserCheckMySelfMgr : BasePage
    {
        public int UserID = 0;
        public int confirmstatus = -1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["UserID"] != null)
                {
                    int.TryParse(Request.QueryString["UserID"], out UserID);
                }
            }
            if (UserID <= 0)
            {
                Response.End();
                return;
            }
        }
    }
}