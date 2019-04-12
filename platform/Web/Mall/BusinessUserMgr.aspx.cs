using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Mall
{
    public partial class BusinessUserMgr : BasePage
    {
        public int BusinessID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["BusinessID"] != null)
                {
                    int.TryParse(Request.QueryString["BusinessID"], out BusinessID);
                }
            }
        }
    }
}