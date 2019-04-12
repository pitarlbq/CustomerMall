using Foresight.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.SysSeting
{
    public partial class SummaryColumnSetup : BasePage
    {
        public int OnlyShowALL = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (string.IsNullOrEmpty(Request.QueryString["PageCode"]))
                {
                    Response.End();
                }
                if (Request.QueryString["OnlyShowALL"] != null)
                {
                    int.TryParse(Request.QueryString["OnlyShowALL"], out OnlyShowALL);
                }
            }
        }
    }
}