using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using Utility;

namespace Web.Wechat
{
    public partial class WechatSetup : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.CheckAuthByModuleCode("1101233"))
            {
                Response.End();
                return;
            }
        }
    }
}