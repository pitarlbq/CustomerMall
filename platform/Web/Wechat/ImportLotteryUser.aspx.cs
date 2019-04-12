using ExcelProcess;
using Foresight.DataAccess;
using Foresight.DataAccess.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Wechat
{
    public partial class ImportLotteryUser : BasePage
    {
        public int ActivityID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request.QueryString["ActivityID"], out ActivityID);
            if (ActivityID <= 0)
            {
                Response.End();
                return;
            }
        }
    }
}