using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utility;

namespace Web.Charge
{
    public partial class ChargeFeePreChargeAllDetail : BasePage
    {
        public string token = DateTime.Now.ToString("yyyyMMddHHmmss");
        public int ChargeID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var rangelist = Foresight.DataAccess.ChargeFeePriceRange.GetAllActiveChargeFeePriceRangeObjectList();
                this.hdPriceRangeList.Value = JsonConvert.SerializeObject(rangelist);
                int.TryParse(Request.QueryString["ChargeID"], out ChargeID);
            }
        }
    }
}