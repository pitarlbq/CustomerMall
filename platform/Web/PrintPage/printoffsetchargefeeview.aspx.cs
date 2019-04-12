using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Foresight.DataAccess;
using Utility;
using Foresight.DataAccess.Framework;

namespace Web.PrintPage
{
    public partial class printoffsetchargefeeview : BasePage
    {
        public int PrintID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["PrintID"] != null)
            {
                int.TryParse(Request.QueryString["PrintID"], out PrintID);
            }
        }
    }
}