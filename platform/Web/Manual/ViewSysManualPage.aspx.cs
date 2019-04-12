using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Manual
{
    public partial class ViewSysManualPage : System.Web.UI.Page
    {
        public string HMTLContent = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["ManualID"] == null)
            {
                Response.End();
                return;
            }
            int ManualID = WebUtil.GetIntByStr(Request.QueryString["ManualID"]);
            var data = Foresight.DataAccess.SysManual.GetSysManual(ManualID);
            if (data == null)
            {
                Response.End();
                return;
            }
            HMTLContent = data.Description;
        }
    }
}