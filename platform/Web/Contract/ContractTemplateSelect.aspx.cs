using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Contract
{
    public partial class ContractTemplateSelect : BasePage
    {
        public int ID = 0;
        public string op = string.Empty;
        public int print_can_edit = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int.TryParse(Request.QueryString["ID"], out ID);
                if (ID == 0)
                {
                    Response.End();
                    return;
                }
                var contract = Foresight.DataAccess.Contract.GetContract(ID);
                if (contract == null)
                {
                    Response.End();
                    return;
                }
                print_can_edit = base.CheckAuthByModuleCode("11011231") ? 1 : 0;
                var list = Foresight.DataAccess.Contract_Template.GetContract_Templates();
                this.rptSummary.DataSource = list;
                this.rptSummary.DataBind();
            }
        }
    }
}