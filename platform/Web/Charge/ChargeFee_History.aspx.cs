﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utility;

namespace Web.Charge
{
    public partial class ChargeFee_History : BasePage
    {
        public string token = DateTime.Now.ToString("yyyyMMddHHmmss");
        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
}