using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Mall
{
    public partial class RoomOwnerBalanceApplicationMgr : BasePage
    {
        public int BalanceStatus = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["status"] != null)
                {
                    int.TryParse(Request.QueryString["status"], out BalanceStatus);
                }
            }
        }
    }
}