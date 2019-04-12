using Foresight.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.SetupFee
{
    public partial class EditGongTanFee : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.hdChargeType.Value = "1";
                this.hdCategory.Value = "1";
                int ID = 0;
                if (int.TryParse(Request.QueryString["ID"], out ID))
                {
                    ChargeSummary summary = ChargeSummary.GetChargeSummary(ID);
                    this.tdName.Value = summary.Name;
                    this.hdChargeType.Value = summary.TypeID.ToString();
                    this.hdCategory.Value = summary.CategoryID.ToString();
                    this.tdSummaryUnitPrice.Value = summary.SummaryUnitPrice == decimal.MinValue ? "0.00" : summary.SummaryUnitPrice.ToString();
                    this.hdEndNumber.Value = summary.EndNumber == int.MinValue ? "2" : summary.EndNumber.ToString();
                    this.tdOrderBy.Value = summary.OrderBy == int.MinValue ? "" : summary.OrderBy.ToString();
                    this.tdIsReading.Value = summary.IsReading ? "1" : "0";
                }
            }
        }
    }
}