using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Cheque
{
    public partial class EditSeller : BasePage
    {
        public int ID;
        protected void Page_Load(object sender, EventArgs e)
        {
            ID = 0;
            int.TryParse(Request.QueryString["ID"], out ID);
            if (ID > 0)
            {
                var data = Foresight.DataAccess.Cheque_Seller.GetCheque_Seller(ID);
                if (data != null)
                {
                    SetInfo(data);
                    return;
                }
            }
        }
        private void SetInfo(Foresight.DataAccess.Cheque_Seller data)
        {
            this.tdSellerName.Value = data.SellerName;
            this.tdTaxNumber.Value = data.SellerTaxNumber;
            this.tdAddressPhone.Value = data.SellerAddressPhone;
            this.tdBankAccount.Value = data.SellerBankAccount;
            this.tdSellerSocialCreditCode.Value = data.SellerSocialCreditCode;
            this.tdSellerCategoryID.Value = data.SellerCategoryID > 0 ? data.SellerCategoryID.ToString() : "";
            this.tdSellerType.Value = data.SellerType;
        }
    }
}