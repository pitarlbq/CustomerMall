﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utility;

namespace Web.Charge
{
    public partial class AddTempFee : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var rangelist = Foresight.DataAccess.ChargePriceRange.GetChargePriceRangeList();
                this.hdPriceRangeList.Value = JsonConvert.SerializeObject(rangelist);
                var discountlist = Foresight.DataAccess.ChargeDiscount.GetChargeDiscounts().Where(p => (DateTime.Now >= p.StartTime && (DateTime.Now <= p.EndTime || p.EndTime == DateTime.MinValue))).OrderBy(p => p.SortOrder);
                this.hdChargeDiscount.Value = JsonConvert.SerializeObject(discountlist);
            }
        }
    }
}