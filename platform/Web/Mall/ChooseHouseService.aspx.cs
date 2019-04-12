using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Mall
{
    public partial class ChooseHouseService : BasePage
    {
        public int singleselect = 0;
        public int type = 1;
        public string from = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["singleselect"] != null)
            {
                int.TryParse(Request.QueryString["singleselect"], out singleselect);
            }
            if (Request.QueryString["type"] != null)
            {
                int.TryParse(Request.QueryString["type"], out type);
            }
            if (Request.QueryString["from"] != null)
            {
                from = Request.QueryString["from"];
            }
        }
    }
}