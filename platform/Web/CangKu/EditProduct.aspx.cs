using Foresight.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utility;

namespace Web.CangKu
{
    public partial class EditProduct : BasePage
    {
        public int ID = 0;
        public int CategoryID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var list = Foresight.DataAccess.CKProductCategory.GetCKProductCategories().ToList();
                if (list.Count > 0)
                {
                    this.hdCategories.Value = JsonConvert.SerializeObject(list);
                }
            }
            ID = 0;
            int.TryParse(Request.QueryString["ID"], out ID);
            if (ID > 0)
            {
                var data = Foresight.DataAccess.CKProduct.GetCKProduct(ID);
                if (data != null)
                {
                    SetInfo(data);
                    return;
                }
            }
            CategoryID = 0;
            int.TryParse(Request.QueryString["CategoryID"], out CategoryID);
            if (CategoryID > 0)
            {
                this.tdProductCategory.Value = CategoryID.ToString();
            }
            this.tdProductNumber.Value = Foresight.DataAccess.CKProduct.GetLastestProductNumber();
        }
        private void SetInfo(Foresight.DataAccess.CKProduct data)
        {
            this.tdProductName.Value = data.ProductName;
            this.tdUnit.Value = data.Unit;
            this.tdProductCategory.Value = data.CategoryID > 0 ? data.CategoryID.ToString() : "";
            this.tdModelNumber.Value = data.ModelNumber;
            this.tdInventoryMin.Value = data.InventoryMin > int.MinValue ? data.InventoryMin.ToString() : "";
            this.tdInventoryMax.Value = data.InventoryMax > int.MinValue ? data.InventoryMax.ToString() : "";
            this.tdProductUnitPrice.Value = data.ProductUnitPrice > int.MinValue ? data.ProductUnitPrice.ToString() : "";
            this.tdProductNumber.Value = data.ProductNumber;
        }
    }
}