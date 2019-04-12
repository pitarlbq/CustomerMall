
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Mall
{
    public partial class ShipRateEdit : BasePage
    {
        public int RateID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["ID"] != null)
            {
                int.TryParse(Request.QueryString["ID"], out RateID);
            }
            if (RateID > 0)
            {
                var data = Foresight.DataAccess.Mall_ShipRate.GetMall_ShipRate(RateID);
                SetInfo(data);
            }
        }
        private void SetInfo(Foresight.DataAccess.Mall_ShipRate data)
        {
            this.tdRateTitle.Value = data.RateTile;
            this.tdRateType.Value = data.RateType > 0 ? data.RateType.ToString() : "";
            this.tdRateSummary.Value = data.RateSummary;
            var default_ratedetail = Foresight.DataAccess.Mall_ShipRateDetail.GetDefaultMall_ShipRateDetailByRateID(data.ID);
            if (default_ratedetail != null)
            {
                this.tdDefaultQuantity.Value = default_ratedetail.DefaultQuantity.ToString("0");
                this.tdDefaultAmount.Value = default_ratedetail.DefaultMoney.ToString("0.00");
                this.tdAdditionalQuantity.Value = default_ratedetail.AdditionalQuantity.ToString("0");
                this.tdAdditionalAmount.Value = default_ratedetail.AdditionalMoney.ToString("0.00");
            }
            this.tdIsDefault.Value = data.IsDefault ? "1" : "0";
        }
    }
}