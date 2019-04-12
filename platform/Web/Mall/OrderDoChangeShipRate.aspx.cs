using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Mall
{
    public partial class OrderDoChangeShipRate : BasePage
    {
        public int OrderID = 0;
        public int Status = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["OrderID"] != null)
            {
                int.TryParse(Request.QueryString["OrderID"], out OrderID);
            }
            Foresight.DataAccess.Mall_Order data = null;
            if (OrderID > 0)
            {
                data = Foresight.DataAccess.Mall_Order.GetMall_Order(OrderID);
            }
            if (data != null)
            {
                SetInfo(data);
            }
        }
        private void SetInfo(Foresight.DataAccess.Mall_Order data)
        {
            this.tdShipRateAmount.Value = data.ShipRateAmount > 0 ? data.ShipRateAmount.ToString("0.00") : "";
            this.Status = data.OrderStatus;
        }
    }
}