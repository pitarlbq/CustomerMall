﻿using Foresight.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utility;

namespace Web.GongTan
{
    public partial class TaiZhangMgr : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var list = Foresight.DataAccess.ChargeBiao.GetChargeBiaos();
            if (list.Count > 0)
            {
                hdBiaoCategory.Value = JsonConvert.SerializeObject(list);
            }
        }
    }
}