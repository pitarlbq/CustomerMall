using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.SysSeting
{
    public partial class WechatChatRequestMgr : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.tdStartTime.Value = DateTime.Today.ToString("yyyy-MM-dd HH:mm:ss");
                this.tdEndTime.Value = DateTime.Today.AddDays(1).AddSeconds(-1).ToString("yyyy-MM-dd HH:mm:ss");
            }
        }
    }
}