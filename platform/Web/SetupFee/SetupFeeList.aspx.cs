using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.SetupFee
{
    public partial class SetupFeeList : BasePage
    {
        public int CategoryID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["CategoryID"]))
            {
                Response.End();
                return;
            }
            if (!int.TryParse(Request.QueryString["CategoryID"], out CategoryID))
            {
                Response.End();
                return;
            }
        }
    }
}