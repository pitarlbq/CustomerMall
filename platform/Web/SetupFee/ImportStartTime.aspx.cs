using ExcelProcess;
using Foresight.DataAccess;
using Foresight.DataAccess.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utility;

namespace Web.SetupFee
{
    public partial class ImportStartTime : BasePage
    {
        public int ChargeID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request.QueryString["ChargeID"], out ChargeID);
        }
    }
}