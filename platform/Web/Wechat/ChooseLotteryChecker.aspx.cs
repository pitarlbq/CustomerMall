using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Wechat
{
    public partial class ChooseLotteryChecker : BasePage
    {
        public int ActivityID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request.QueryString["ActivityID"], out ActivityID);
            if (ActivityID <= 0)
            {
                Response.End();
                return;
            }
        }
    }
}