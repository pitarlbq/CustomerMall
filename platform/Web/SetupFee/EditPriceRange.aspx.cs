using Foresight.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Web.SetupFee
{
    public partial class EditPriceRange : BasePage
    {
        public int ChargeID = 0;
        public string ContractNumber = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            ChargeID = 0;
            int.TryParse(Request.QueryString["ChargeID"], out ChargeID);
            if (ChargeID <= 0)
            {
                Response.End();
                return;
            }
            var summary = ChargeSummary.GetChargeSummary(ChargeID);
            if (summary == null)
            {
                Response.End();
                return;
            }
        }
    }
}