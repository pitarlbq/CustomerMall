using ExcelProcess;
using Foresight.DataAccess;
using Foresight.DataAccess.Framework;

using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.InsideCustomer
{
    public partial class UploadCustomer : BasePage
    {
        public int ID;
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request.QueryString["ID"], out ID);
            var customer = Foresight.DataAccess.InsideCustomer.GetInsideCustomer(ID);
            if (customer == null)
            {
                Response.End();
                return;
            }
        }
    }
}