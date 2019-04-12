using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Foresight.DataAccess;

namespace Web.Charge
{
    public partial class EditChargeFee : BasePage
    {
        public Foresight.DataAccess.ChargeFee chargeFee = new Foresight.DataAccess.ChargeFee();
        public Foresight.DataAccess.ChargeSummary chargeSummary = new Foresight.DataAccess.ChargeSummary();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["FeeID"]))
            {
                Response.End();
                return;
            }
            int FeeID = 0;
            if (!int.TryParse(Request.QueryString["FeeID"], out FeeID))
            {
                Response.End();
                return;
            }
            chargeFee = Foresight.DataAccess.ChargeFee.GetChargeFee(FeeID);
            if (chargeFee == null)
            {
                Response.End();
                return;
            }
            this.tbUnitPrice.Value = chargeFee.UnitPrice.ToString();
            this.tbStartTime.Value = chargeFee.StartTime.ToString("yyyy-MM-dd");
            this.tbEndType.Value = chargeFee.EndTypeID.ToString();
            chargeSummary = ChargeSummary.GetChargeSummary(chargeFee.ChargeID);
            this.tbName.Value = chargeSummary.Name;
        }
    }
}