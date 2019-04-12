using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Contract
{
    public partial class AddContractRoom : BasePage
    {
        public int ContractID = 0;
        public string guid = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["ContractID"] != null)
                {
                    int.TryParse(Request.QueryString["ContractID"], out ContractID);
                }
                if (Request.QueryString["guid"] != null)
                {
                    guid = Request.QueryString["guid"];
                }
            }
        }
    }
}