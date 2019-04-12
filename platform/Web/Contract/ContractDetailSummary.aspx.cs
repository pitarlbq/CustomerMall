using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.APPCode;

namespace Web.Contract
{
    public partial class ContractDetailSummary : BasePage
    {
        public int ContractID = 0;
        public int TemplateID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["ID"]))
            {
                Response.End();
                return;
            }
            if (string.IsNullOrEmpty(Request.QueryString["TemplateID"]))
            {
                Response.End();
                return;
            }
            int.TryParse(Request.QueryString["ID"], out ContractID);
            var contract = Foresight.DataAccess.Contract.GetContract(ContractID);
            if (contract == null)
            {
                Response.End();
                return;
            }
            int.TryParse(Request.QueryString["templateid"], out TemplateID);
            var template = Foresight.DataAccess.Contract_Template.GetContract_Template(TemplateID);
            if (template == null)
            {
                Response.End();
                return;
            }
            var contract_print = Foresight.DataAccess.Contract_Print.GetContract_PrintByContractID(contract.ID, template.ID);
            if (contract_print != null && !string.IsNullOrEmpty(contract_print.PrintContent))
            {
                this.hdContent.Value = contract_print.PrintContent;
            }
            else
            {
                this.hdContent.Value = CommHelper.GetContractTemplateHtml(template.TemplateContent, contract);
            }
        }
    }
}