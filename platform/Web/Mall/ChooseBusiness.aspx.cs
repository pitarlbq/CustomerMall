using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Mall
{
    public partial class ChooseBusiness : BasePage
    {
        public int singleselect = 0;
        public int usetype = 0;
        public string from = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["singleselect"] != null)
            {
                int.TryParse(Request.QueryString["singleselect"], out singleselect);
            }
            if (Request.QueryString["usetype"] != null)
            {
                int.TryParse(Request.QueryString["usetype"], out usetype);
            }
            if (Request.QueryString["from"] != null)
            {
                from = Request.QueryString["from"];
            }
        }
    }
}