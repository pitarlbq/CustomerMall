using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Mall
{
    public partial class OrderDoRefund : BasePage
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
            this.tdOrderPaymentMethod.InnerHtml = data.PaymentMethodDesc;
            this.tdOrderTotalCost.InnerHtml = data.TotalOrderCost > 0 ? data.TotalOrderCost.ToString("0.00") : "";
            var list = Foresight.DataAccess.Mall_OrderRefundRequest.GetMall_OrderRefundRequestListByOrderID(data.ID).OrderByDescending(p => p.AddTime).ToArray();
            if (list.Length == 0)
            {
                Response.End();
                return;
            }
            this.tdRefundReason.InnerHtml = list[0].Remark;
            this.tdRefundTime.InnerHtml = data.RefundRequestTime > DateTime.MinValue ? data.RefundRequestTime.ToString("yyyy-MM-dd HH:mm") : "";
            this.Status = data.OrderStatus;
        }
    }
}