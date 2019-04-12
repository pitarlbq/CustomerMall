using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Mall
{
    public partial class Order_ViewShipInfo : BasePage
    {
        public int OrderID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["ID"] != null)
            {
                int.TryParse(Request.QueryString["ID"], out OrderID);
            }
            if (OrderID <= 0)
            {
                Response.End();
                return;
            }
            var data = Foresight.DataAccess.Mall_Order.GetMall_Order(OrderID);
            if (data == null)
            {
                Response.End();
                return;
            }
            SetInfo(data);
        }
        private void SetInfo(Foresight.DataAccess.Mall_Order data)
        {
            this.tdAddressUserName.InnerHtml = data.AddressUserName;
            this.tdAddressPhoneNumber.InnerHtml = data.AddressPhoneNumber;
            this.tdAddressProvince.InnerHtml = data.AddressProvince;
            this.tdAddressCity.InnerHtml = data.AddressCity;
            this.tdAddressDistrict.InnerHtml = data.AddressDistrict;
            this.tdAddressDetailInfo.InnerHtml = data.AddressDetailInfo;
        }
    }
}