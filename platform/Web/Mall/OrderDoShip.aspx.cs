using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Mall
{
    public partial class OrderDoShip : BasePage
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
            else
            {
                this.tdShipTime.Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            }
        }
        private void SetInfo(Foresight.DataAccess.Mall_Order data)
        {
            this.tdShipTrackNo.Value = data.ShipTrackNo;
            this.tdShipCompany.Value = data.ShipCompanyName;
            this.tdShipTime.Value = data.ShipTime > DateTime.MinValue ? data.ShipTime.ToString("yyyy-MM-dd HH:mm:ss") : "";
            this.Status = data.OrderStatus;
            this.tdShipUserName.Value = string.IsNullOrEmpty(data.ShipUserName) ? WebUtil.GetUser(this.Context).FinalRealName : data.ShipUserName;
            this.tdShipDelivererName.Value = data.ShipDelivererName;
        }
    }
}