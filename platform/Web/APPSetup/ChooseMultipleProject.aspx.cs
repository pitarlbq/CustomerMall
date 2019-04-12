using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.APPSetup
{
    public partial class ChooseMultipleProject : BasePage
    {
        public int ParentID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["ParentID"] != null)
            {
                int.TryParse(Request.QueryString["ParentID"], out ParentID);
            }
        }
    }
}