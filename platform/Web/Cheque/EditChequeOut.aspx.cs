using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Cheque
{
    public partial class EditChequeOut : BasePage
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
                var data = Foresight.DataAccess.Cheque_OutSummary.GetCheque_OutSummary(ID);
                if (data != null)
                {
                    SetInfo(data);
                    return;
                }
            }
            this.tdWriteDate.Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            this.tdWriteMan.Value = WebUtil.GetUser(this.Context).RealName;
        }
        private void SetInfo(Foresight.DataAccess.Cheque_OutSummary data)
        {
            this.tdWriteMan.Value = data.WriteMan;
            this.tdWriteDate.Value = data.WriteDate > DateTime.MinValue ? data.WriteDate.ToString("yyyy-MM-dd HH:mm:ss") : "";
            this.tdDepartmentID.Value = data.DepartmentID > 0 ? data.DepartmentID.ToString() : "";
            this.tdProjectID.Value = data.ProjectID > 0 ? data.ProjectID.ToString() : "";
            this.tdSellerID.Value = data.SellerID > 0 ? data.SellerID.ToString() : "";
            if (data.SellerID > 0)
            {
                var seller = Foresight.DataAccess.Cheque_Seller.GetCheque_Seller(data.SellerID);
                if (seller != null)
                {
                    this.tdSellerTaxNumber.Value = seller.SellerTaxNumber;
                    this.tdSellerAddressPhone.Value = seller.SellerAddressPhone;
                    this.tdSellerBankAccount.Value = seller.SellerBankAccount;
                }
            }
            this.tdChequeNumber.Value = data.ChequeNumber;
            this.tdChequeTime.Value = data.ChequeTime > DateTime.MinValue ? data.ChequeTime.ToString("yyyy-MM-dd") : "";
            this.tdBuyerID.Value = data.BuyerID > 0 ? data.BuyerID.ToString() : "";
            if (data.BuyerID > 0)
            {
                var buyer = Foresight.DataAccess.Cheque_Buyer.GetCheque_Buyer(data.BuyerID);
                if (buyer != null)
                {
                    this.tdBuyerTaxNumber.Value = buyer.BuyerTaxNumber;
                    this.tdBuyerAddressPhone.Value = buyer.BuyerAddressPhone;
                    this.tdBuyerBankAccount.Value = buyer.BuyerBankAccount;
                }
            }
            this.tdChequeCode.Value = data.ChequeCode;
            this.tdChequeCategory.Value = data.ChequeCategory;
        }
    }
}