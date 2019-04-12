using Foresight.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utility;

namespace Web.Analysis
{
    public partial class ProjectCountAnalysis : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DateTime Start = DateTime.Now.AddDays(1 - DateTime.Now.Day);
                this.tdStartTime.Value = Start.ToString("yyyy-MM-dd");
                this.tdEndTime.Value = Start.AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd");
            }
        }
    }
}