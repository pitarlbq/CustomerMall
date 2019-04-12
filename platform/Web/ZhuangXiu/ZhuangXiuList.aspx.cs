using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.ZhuangXiu
{
    public partial class ZhuangXiuList : BasePage
    {
        public string status = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["status"] != null)
            {
                status = Request.QueryString["status"];
            }
        }
    }
}