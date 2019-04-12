using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Contract
{
    public partial class ChooseChargeSummary : BasePage
    {
        public string source = string.Empty;
        public int rowIndex = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["source"] != null)
                {
                    source = Request.QueryString["source"];
                }
                if (Request.QueryString["rowIndex"] != null)
                {
                    int.TryParse(Request.QueryString["rowIndex"], out rowIndex);
                }
            }
        }
    }
}