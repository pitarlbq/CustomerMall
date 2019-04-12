using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Cheque
{
    public partial class AddOutingProduct : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int ID = 0;
            int.TryParse(Request.QueryString["ID"], out ID);
            var data = Foresight.DataAccess.Cheque_OutingProduct.GetCheque_OutingProduct(ID);
            if (data != null)
            {
                SetInfo(data);
            }
        }
        private void SetInfo(Foresight.DataAccess.Cheque_OutingProduct data)
        {
            this.tdProductName.Value = data.ProductName;
            this.tdSellerAddress.Value = data.SellerAddress;
            this.tdProductStartTime.Value = data.ProductStartTime > DateTime.MinValue ? data.ProductStartTime.ToString("yyyy-MM-dd") : "";
            this.tdProductEndTime.Value = data.ProductEndTime > DateTime.MinValue ? data.ProductEndTime.ToString("yyyy-MM-dd") : "";
            this.tdProductTotalCost.Value = data.ProductTotalCost > 0 ? data.ProductTotalCost.ToString() : "";
            this.tdTotalCount.Value = data.TotalCount > 0 ? data.TotalCount.ToString() : "";
        }
    }
}