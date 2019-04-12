using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Contract
{
    public partial class EditContract : BasePage
    {
        public int ID = 0;
        public string op = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int.TryParse(Request.QueryString["ID"], out ID);
                op = !string.IsNullOrEmpty(Request.QueryString["op"]) ? Request.QueryString["op"] : string.Empty;
            }
        }
    }
}