using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.APPCode;

namespace Web.Contract
{
    public partial class ContractDetailPrint : BasePage
    {
        public string HTMLContent = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            int ID = 0;
            int.TryParse(Request.QueryString["ID"], out ID);
            if (ID > 0)
            {
                var contract_print = Foresight.DataAccess.Contract_Print.GetContract_Print(ID);
                if (contract_print == null)
                {
                    Response.End();
                    return;
                }
                this.HTMLContent = contract_print.PrintContent;
                return;
            }
            if (string.IsNullOrEmpty(Request.QueryString["contractid"]))
            {
                Response.End();
                return;
            }
            if (string.IsNullOrEmpty(Request.QueryString["templateid"]))
            {
                Response.End();
                return;
            }
            int ContractID = 0;
            int.TryParse(Request.QueryString["contractid"], out ContractID);
            var contract = Foresight.DataAccess.Contract.GetContract(ContractID);
            if (contract == null)
            {
                Response.End();
                return;
            }
            int TemplateID = 0;
            int.TryParse(Request.QueryString["templateid"], out TemplateID);
            var template = Foresight.DataAccess.Contract_Template.GetContract_Template(TemplateID);
            if (template == null)
            {
                Response.End();
                return;
            }
            this.HTMLContent = CommHelper.GetContractTemplateHtml(template.TemplateContent, contract);
        }
    }
}