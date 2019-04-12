using ExcelProcess;
using Foresight.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utility;

namespace Web.Contract
{
    public partial class AddContract : BasePage
    {
        public string op = string.Empty;
        public int ContractID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                op = !string.IsNullOrEmpty(Request.QueryString["op"]) ? Request.QueryString["op"] : string.Empty;
                int.TryParse(Request.QueryString["ID"], out ContractID);
            }
        }
    }
}