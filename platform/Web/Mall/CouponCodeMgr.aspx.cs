﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Mall
{
    public partial class CouponCodeMgr : BasePage
    {
        public int CanEdit = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            CanEdit = base.CheckAuthByModuleCode("1101455") ? 1 : 0;
        }
    }
}