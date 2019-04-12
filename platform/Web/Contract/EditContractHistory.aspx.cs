using Foresight.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Contract
{
    public partial class EditContractHistory : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int ContractID = 0;
            int.TryParse(Request.QueryString["ID"], out ContractID);
            var contract = Foresight.DataAccess.Contract.GetContract(ContractID);
            if (contract == null)
            {
                Response.Write("ID不合法");
                Response.End();
            }
        }
    }
}