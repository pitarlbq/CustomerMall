using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class SiteManager : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string key = Request.QueryString["key"];
            if (string.IsNullOrEmpty(key))
            {
                Response.End();
                return;
            }
            if (!key.Equals("yy2016"))
            {
                Response.End();
                return;
            }
        }
    }
}