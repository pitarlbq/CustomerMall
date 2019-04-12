using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.ContractEarn
{
    public partial class ContractDivideCreate : BasePage
    {
        public int ContractID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["ID"]))
                {
                    int.TryParse(Request.QueryString["ID"], out ContractID);
                }
                if (ContractID > 0)
                {
                    var data = Foresight.DataAccess.Contract.GetContract(ContractID);
                    if (data != null)
                    {
                        this.tdContractNo.Value = data.ContractNo;
                        this.tdSellCost.Value = data.ContractDivideSellCost > 0 ? data.ContractDivideSellCost.ToString() : "";
                        this.tdFixedPercent.Value = data.ContractDevicePercent > 0 ? data.ContractDevicePercent.ToString() : "";
                    }
                    else
                    {
                        ContractID = 0;
                    }
                }
                var chargeList = Foresight.DataAccess.ChargeSummary.GetChargeSummaries().ToArray();
                var chargeItems = chargeList.Select(p =>
                {
                    var item = new { ID = p.ID, Name = p.Name };
                    return item;
                }).ToArray();
                this.hdChargeSummary.Value = Utility.JsonConvert.SerializeObject(chargeItems);
            }
        }
    }
}