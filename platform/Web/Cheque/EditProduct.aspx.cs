using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Cheque
{
    public partial class EditProduct : BasePage
    {
        public int ID;
        protected void Page_Load(object sender, EventArgs e)
        {
            ID = 0;
            int.TryParse(Request.QueryString["ID"], out ID);
            if (ID > 0)
            {
                var data = Foresight.DataAccess.Cheque_Product.GetCheque_Product(ID);
                if (data != null)
                {
                    SetInfo(data);
                    return;
                }
            }
        }
        private void SetInfo(Foresight.DataAccess.Cheque_Product data)
        {
            this.tdProductName.Value = data.ProductName;
            this.tdModelNumber.Value = data.ModelNumber;
            this.tdUnit.Value = data.Unit;
            this.tdUnitPrice.Value = data.UnitPrice > 0 ? data.UnitPrice.ToString() : "";
            this.tdProductNumber.Value = data.ProductNumber;
            this.tdProductCategoryID.Value = data.ProductCategoryID > 0 ? data.ProductCategoryID.ToString() : "";
        }
    }
}