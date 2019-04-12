using Foresight.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utility;
using Web.APPCode;

namespace Web.Analysis
{
    public partial class ShouFeiLvAnalysis : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DateTime StartTime = DateTime.Now.AddDays(1 - DateTime.Now.Day).AddMonths(-1);
                this.tdStartTime.Value = StartTime.ToString("yyyy-MM-dd");
                this.tdEndTime.Value = StartTime.AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd");
            }
        }
    }
}