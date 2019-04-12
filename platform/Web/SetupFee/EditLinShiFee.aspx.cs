using Foresight.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.SetupFee
{
    public partial class EditLinShiFee : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int ID = 0;
                this.tdSummaryUnitPrice.Value = "0";
                if (int.TryParse(Request.QueryString["ID"], out ID))
                {
                    ChargeSummary summary = ChargeSummary.GetChargeSummary(ID);
                    this.tdName.Value = summary.Name;
                    this.tdSummaryUnitPrice.Value = summary.SummaryUnitPrice == decimal.MinValue ? "0" : summary.SummaryUnitPrice.ToString();
                    this.tbAllowImport.Value = summary.IsAllowImport ? "1" : "0";
                    this.tbEndNumberCount.Value = summary.EndNumberCount == int.MinValue ? "2" : summary.EndNumberCount.ToString();
                }
            }
        }
    }
}