using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Analysis
{
    public partial class TotalAnalysis : BasePage
    {
        public string ShowSFXM = "skkb_sfxm";
        protected void Page_Load(object sender, EventArgs e)
        {
            var skkb = Foresight.DataAccess.AnalysisSummary.GetAnalysisSummaryByCode(WebUtil.GetUser(this.Context).UserID, "skkb");
            if (skkb != null)
            {
                ShowSFXM = skkb.AnalysisCode;
            }
        }
    }
}