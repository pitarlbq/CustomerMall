using ExcelProcess;
using Foresight.DataAccess;
using Foresight.DataAccess.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utility;

namespace Web.Contract
{
    public partial class NewAddContract_Part : BasePage
    {
        public int ContractID = 0;
        public Foresight.DataAccess.Contract contract = null;
        public string op = string.Empty;
        public bool canEdit = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                op = !string.IsNullOrEmpty(Request.QueryString["op"]) ? Request.QueryString["op"] : string.Empty;
                int.TryParse(Request.QueryString["ID"], out ContractID);
                if (this.op.Equals("edit") || this.op.Equals("newrent"))
                {
                    canEdit = true;
                }
                contract = Foresight.DataAccess.Contract.GetContract(ContractID);
                if (contract == null)
                {
                    canEdit = true;
                }
                else
                {
                    if (contract.ContractStatus.Equals("yuding"))
                    {
                        canEdit = true;
                    }
                }
            }
        }
    }
}