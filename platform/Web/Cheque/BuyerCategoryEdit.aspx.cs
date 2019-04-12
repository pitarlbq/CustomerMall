using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Cheque
{
    public partial class BuyerCategoryEdit : BasePage
    {
        public int ID;
        protected void Page_Load(object sender, EventArgs e)
        {
            ID = 0;
            int.TryParse(Request.QueryString["ID"], out ID);
            if (ID > 0)
            {
                var data = Foresight.DataAccess.Cheque_BuyerCategory.GetCheque_BuyerCategory(ID);
                if (data != null)
                {
                    SetInfo(data);
                    return;
                }
            }
        }
        private void SetInfo(Foresight.DataAccess.Cheque_BuyerCategory data)
        {
            this.tdBuyerCategoryName.Value = data.BuyerCategoryName;
            this.tdBuyerCategoryNumber.Value = data.BuyerCategoryNumber;
        }
    }
}