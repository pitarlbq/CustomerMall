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
    public partial class ContractFeeSummaryAnalysis : BasePage
    {
        public string op = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["op"] != null)
                {
                    op = Request.QueryString["op"];
                }
            }
        }
    }
}