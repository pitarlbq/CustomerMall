using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.CangKu
{
    public partial class EditPropertyHistory : BasePage
    {
        public int PropertyID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["ID"] != null)
            {
                int.TryParse(Request.QueryString["ID"], out PropertyID);
            }
            Foresight.DataAccess.CKProperty data = null;
            if (PropertyID > 0)
            {
                data = Foresight.DataAccess.CKProperty.GetCKProperty(PropertyID);
            }
            if (data == null)
            {
                Response.End();
                return;
            }
        }
    }
}