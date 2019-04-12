using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Cheque
{
    public partial class AddOutProduct : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int ID = 0;
            int.TryParse(Request.QueryString["ID"], out ID);
            var _cheque_OutDetail = Foresight.DataAccess.Cheque_OutDetail.GetCheque_OutDetail(ID);
            if (_cheque_OutDetail != null)
            {
                SetInfo(_cheque_OutDetail);
            }
        }
        private void SetInfo(Foresight.DataAccess.Cheque_OutDetail data)
        {
            this.tdProductName.Value = data.ProductID.ToString();
            this.tdModelNumber.Value = data.ModelNumber;
            this.tdUnit.Value = data.Unit;
            this.tdUnitPrice.Value = data.UnitPrice > 0 ? data.UnitPrice.ToString() : "";
            this.tdTotalCount.Value = data.TotalCount > 0 ? data.TotalCount.ToString() : "";
            this.tdTotalCost.Value = data.TotalCost > 0 ? data.TotalCost.ToString() : "";
            this.tdTotalTaxCost.Value = data.TotalTaxCost > 0 ? data.TotalTaxCost.ToString() : "";
            this.tdTaxRate.Value = data.TaxRate;
        }
    }
}