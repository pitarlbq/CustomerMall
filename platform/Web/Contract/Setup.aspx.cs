using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Contract
{
    public partial class Setup : BasePage
    {
        public string addContractPath = string.Empty;
        public string editContractPath = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (new Utility.SiteConfig().IsNewContract)
                {
                    addContractPath = "NewAddContract.aspx";
                    editContractPath = "NewAddContract.aspx";
                }
                else
                {
                    addContractPath = "AddContract.aspx";
                    editContractPath = "EditContract.aspx";
                }
            }
        }
    }
}