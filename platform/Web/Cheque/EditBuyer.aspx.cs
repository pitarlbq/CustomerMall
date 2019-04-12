using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Cheque
{
    public partial class EditBuyer : BasePage
    {
        public int ID;
        protected void Page_Load(object sender, EventArgs e)
        {
            ID = 0;
            int.TryParse(Request.QueryString["ID"], out ID);
            if (ID > 0)
            {
                var data = Foresight.DataAccess.Cheque_Buyer.GetCheque_Buyer(ID);
                if (data != null)
                {
                    SetInfo(data);
                    return;
                }
            }
        }
        private void SetInfo(Foresight.DataAccess.Cheque_Buyer data)
        {
            this.tdBuyerName.Value = data.BuyerName;
            this.tdTaxNumber.Value = data.BuyerTaxNumber;
            this.tdAddressPhone.Value = data.BuyerAddressPhone;
            this.tdBankAccount.Value = data.BuyerBankAccount;
            this.tdBuyerCategoryID.Value = data.BuyerCategoryID > 0 ? data.BuyerCategoryID.ToString() : "";
            this.tdBuyerSocialCreditCode.Value = data.BuyerSocialCreditCode;
            this.tdBuyerType.Value = data.BuyerType;
        }
    }
}