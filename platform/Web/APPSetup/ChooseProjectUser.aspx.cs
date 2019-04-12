using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.APPSetup
{
    public partial class ChooseProjectUser : BasePage
    {
        public int singleselect = 0;
        public int ProjectID = 0;
        public int IsHuHuoRen = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["singleselect"] != null)
            {
                int.TryParse(Request.QueryString["singleselect"], out singleselect);
            }
            if (Request.QueryString["ProjectID"] != null)
            {
                int.TryParse(Request.QueryString["ProjectID"], out ProjectID);
            }
            if (Request.QueryString["IsHuHuoRen"] != null)
            {
                int.TryParse(Request.QueryString["IsHuHuoRen"], out IsHuHuoRen);
            }
        }
    }
}