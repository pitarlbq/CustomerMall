using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Mall
{
    public partial class OrderDetail : BasePage
    {
        public int OrderID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["ID"] != null)
            {
                int.TryParse(Request.QueryString["ID"], out OrderID);
            }
            Foresight.DataAccess.Mall_Order data = null;
            if (OrderID > 0)
            {
                data = Foresight.DataAccess.Mall_Order.GetMall_Order(OrderID);

            }
            if (data == null)
            {
                Response.End();
                return;
            }
            SetInfo(data);
        }
        private void SetInfo(Foresight.DataAccess.Mall_Order data)
        {
            this.tdOrderNumber.InnerHtml = data.OrderNumber;
            this.tdOrderTime.InnerHtml = data.AddTime.ToString("yyyy-MM-dd HH:mm");
            this.tdOrderType.InnerHtml = data.ProductTypeDesc;
            this.tdTotalCost.InnerHtml = data.TotalCost.ToString("0.00");
            this.tdOrderStatus.InnerHtml = data.OrderStatusDesc;
            if (data.UserID > 0)
            {
                var user = Foresight.DataAccess.User.GetUser(data.UserID);
                if (user != null)
                {
                    this.tdNickName.InnerHtml = user.NickName;
                    this.tdBuserPhone.InnerHtml = user.PhoneNumber;
                }
            }
            this.tdUserNote.InnerHtml = data.UserNote;
            this.tdAddressUserName.InnerHtml = data.AddressUserName;
            this.tdAddressPhoneNumber.InnerHtml = data.AddressPhoneNumber;
            this.tdAddressProvince.InnerHtml = data.AddressProvince;
            this.tdAddressCity.InnerHtml = data.AddressCity;
            this.tdAddressDistrict.InnerHtml = data.AddressDistrict;
            this.tdAddressDetailInfo.InnerHtml = data.AddressDetailInfo;
            this.tdShipTrackNo.InnerHtml = data.ShipTrackNo;
            this.tdShipTime.InnerHtml = data.ShipTime > DateTime.MinValue ? data.ShipTime.ToString("yyyy-MM-dd HH:mm:ss") : "";
            this.tdShipCompany.InnerHtml = data.ShipCompanyName;
            this.tdShipUserName.InnerHtml = data.ShipUserName;
            this.tdCompleteTime.InnerHtml = data.CompleteTime > DateTime.MinValue ? data.CompleteTime.ToString("yyyy-MM-dd HH:mm:ss") : "";
            this.tdShipDelivererName.InnerHtml = data.ShipDelivererName;
            var grapOrderList = Foresight.DataAccess.Mall_OrderAPPUser.GetMall_OrderAPPUserListByOrderID(data.ID);
            var grapOrder = grapOrderList.FirstOrDefault(p => p.AccpetStatus == 1);
            if (grapOrder != null)
            {
                var user = Foresight.DataAccess.User.GetUser(grapOrder.UserID);
                this.tdGrapUserName.InnerHtml = user != null ? user.FinalRealName : string.Empty;
                this.tdGrapTime.InnerHtml = grapOrder.AppSendTime.ToString("yyyy-MM-dd HH:mm:ss");
            }
        }
    }
}