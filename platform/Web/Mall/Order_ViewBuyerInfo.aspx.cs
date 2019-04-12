﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Mall
{
    public partial class Order_ViewBuyerInfo : BasePage
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
            var user = Foresight.DataAccess.User.GetUser(data.UserID);
            if (user != null)
            {
                SetInfo(user);
            }
        }
        private void SetInfo(Foresight.DataAccess.User data)
        {
            this.tdNickName.InnerHtml = data.NickName;
            this.tdPhoneNumber.InnerHtml = data.PhoneNumber;
        }
    }
}