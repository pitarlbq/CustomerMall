
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Mall
{
    public partial class UserCheckApprove : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.tdApproveTime.Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            this.tdApproveMan.Value = WebUtil.GetUser(this.Context).LoginName;
        }
    }
}