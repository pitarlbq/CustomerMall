using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Cheque
{
    public partial class ChequeStampEdit : BasePage
    {
        public int ID = 0;
        public string guid = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            guid = System.Guid.NewGuid().ToString();
            ID = 0;
            int.TryParse(Request.QueryString["ID"], out ID);
            if (ID > 0)
            {
                var data = Foresight.DataAccess.Cheque_Tax.GetCheque_Tax(ID);
                if (data != null)
                {
                    SetInfo(data);
                    return;
                }
            }
            this.tdAddTime.Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            this.tdAddMan.Value = WebUtil.GetUser(this.Context).RealName;
        }
        private void SetInfo(Foresight.DataAccess.Cheque_Tax data)
        {
            this.tdContractNumber.Value = data.ContractNumber;
            this.tdDepartmentID.Value = data.DepartmentID > 0 ? data.DepartmentID.ToString() : "";
            this.tdContractCategoryID.Value = data.ContractCategoryID > 0 ? data.ContractCategoryID.ToString() : "";
            this.tdTaxRateID.Value = data.TaxRateID > 0 ? data.TaxRateID.ToString() : "";
            this.tdContractName.Value = data.ContractName;
            this.tdUnitPrice.Value = data.UnitPrice > 0 ? data.UnitPrice.ToString() : "";
            this.tdTotalCount.Value = data.TotalCount > 0 ? data.TotalCount.ToString() : "";
            this.tdTotalCost.Value = data.TotalCost > 0 ? data.TotalCost.ToString() : "";
            this.tdTotalTaxCost.Value = data.TotalTaxCost > 0 ? data.TotalTaxCost.ToString() : "";
            this.tdAddMan.Value = data.AddMan;
            this.tdAddTime.Value = data.AddTime > DateTime.MinValue ? data.AddTime.ToString("yyyy-MM-dd HH:mm:ss") : "";
            if (data.TaxRateID > 0)
            {
                var taxrate = Foresight.DataAccess.Cheque_TaxRate.GetCheque_TaxRate(data.TaxRateID);
                this.tdTaxRateValue.Value = taxrate != null ? taxrate.TaxRateValue : "";
            }
        }
    }
}