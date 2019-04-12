using Foresight.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.CangKu
{
    public partial class EditProductCategory : BasePage
    {
        public int ID;
        protected void Page_Load(object sender, EventArgs e)
        {
            ID = 0;
            int.TryParse(Request.QueryString["CategoryID"], out ID);
            if (ID > 0)
            {
                var data = Foresight.DataAccess.CKProductCategory.GetCKProductCategory(ID);
                if (data != null)
                {
                    SetInfo(data);
                    return;
                }
            }
        }
        private void SetInfo(Foresight.DataAccess.CKProductCategory data)
        {
            this.tdCategoryName.Value = data.ProductCategoryName;
            this.tdRemark.Value = data.ProductCategoryDesc;
        }
    }
}