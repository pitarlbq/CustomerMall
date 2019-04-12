using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Cheque
{
    public partial class AddInProduct : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int ID = 0;
            int.TryParse(Request.QueryString["ID"], out ID);
            var _cheque_InDetail = Foresight.DataAccess.Cheque_InDetail.GetCheque_InDetail(ID);
            if (_cheque_InDetail != null)
            {
                SetInfo(_cheque_InDetail);
            }
        }
        private void SetInfo(Foresight.DataAccess.Cheque_InDetail data)
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