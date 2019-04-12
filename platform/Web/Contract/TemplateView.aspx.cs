using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Contract
{
    public partial class TemplateView : BasePage
    {
        public int ID = 0;
        public Foresight.DataAccess.Contract_Template data = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int.TryParse(Request.QueryString["ID"], out ID);
                if (ID <= 0)
                {
                    Response.End();
                    return;
                }
                data = Foresight.DataAccess.Contract_Template.GetContract_Template(ID);
                if (data == null)
                {
                    Response.End();
                    return;
                }
            }
        }
    }
}