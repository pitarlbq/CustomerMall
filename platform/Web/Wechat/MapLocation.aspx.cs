using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Wechat
{
    public partial class MapLocation : BasePage
    {
        public string BaiduAK = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            var config = new Utility.SiteConfig();
            BaiduAK = config.BaiduAK;
        }
    }
}