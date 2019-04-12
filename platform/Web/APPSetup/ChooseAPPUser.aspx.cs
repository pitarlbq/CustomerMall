using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.APPSetup
{
    public partial class ChooseAPPUser : BasePage
    {
        public int singleselect = 0;
        public int ProjectID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["singleselect"] != null)
            {
                int.TryParse(Request.QueryString["singleselect"], out singleselect);
            }
        }
    }
}