using Foresight.DataAccess;
using Foresight.DataAccess.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.PrintPage
{
    public partial class PrintChequeView : BasePage
    {
        public int RoomID = 0;
        public int DefaultRelationID = 0;
        public int ContractID = 0;
        public int RelationID = 0;
        public int PrintID = 0;
        public bool CanPrintCheque = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["RoomID"] != null)
                {
                    int.TryParse(Request.QueryString["RoomID"], out RoomID);
                }
                if (Request.QueryString["DefaultRelationID"] != null)
                {
                    int.TryParse(Request.QueryString["DefaultRelationID"], out DefaultRelationID);
                }
                if (Request.QueryString["ContractID"] != null)
                {
                    int.TryParse(Request.QueryString["ContractID"], out ContractID);
                }
                if (Request.QueryString["PrintID"] != null)
                {
                    int.TryParse(Request.QueryString["PrintID"], out PrintID);
                }
                if (PrintID > 0)
                {
                    var history_list = ViewRoomFeeHistory.GetViewRoomFeeHistoryListByPrintID(PrintID);
                    if (history_list.Length > 0)
                    {
                        DefaultRelationID = history_list[0].DefaultChargeManID;
                        RoomID = history_list[0].RoomID;
                        ContractID = history_list[0].ContractID;
                        CanPrintCheque = true;
                    }
                }
                Foresight.DataAccess.RoomPhoneRelation data = null;
                RoomBasic basic = null;
                using (SqlHelper helper = new SqlHelper())
                {
                    if (DefaultRelationID > 0)
                    {
                        data = RoomPhoneRelation.GetRoomPhoneRelation(DefaultRelationID, helper);
                    }
                    if (data == null)
                    {
                        data = RoomPhoneRelation.GetDefaultInChargeFeeRoomPhoneRelation(RoomID, ContractID, helper);
                    }
                    if (data == null)
                    {
                        basic = RoomBasic.GetRoomBasicByRoomID(RoomID, helper);
                    }
                }
                if (data != null)
                {
                    this.RelationID = data.ID;
                    this.tdCompanyName.Value = data.CompanyName;
                    this.tdAddress.Value = data.HomeAddress;
                    this.tdBuyerTaxpayerNumber.Value = data.TaxpayerNumber;
                    this.tdBuyerBankAccountNo.Value = data.BankAccountNo;
                    this.tdBuyerBankName.Value = data.BankName;
                    this.tdBuyerEmailAddress.Value = data.EmailAddress;
                }
                if (basic != null)
                {
                    this.tdCompanyName.Value = basic.ChequeCompanyName;
                    this.tdAddress.Value = basic.ChequeAddress;
                    this.tdBuyerTaxpayerNumber.Value = basic.ChequeTaxpayerNumber;
                    this.tdBuyerBankAccountNo.Value = basic.ChequeBankNo;
                    this.tdBuyerBankName.Value = basic.ChequeBankName;
                    this.tdBuyerEmailAddress.Value = basic.ChequeEmailAddress;
                }
                var company = Company.GetCompanies().FirstOrDefault();
                if (company != null)
                {
                    this.tdSellerCompanyName.Value = string.IsNullOrEmpty(company.ChequeTitle) ? company.CompanyName : company.ChequeTitle;
                    this.tdSellerAddress.Value = company.Address;
                    this.tdSellerTaxpayerNumber.Value = company.TaxpayerNumber;
                    this.tdSellerBankNo.Value = company.BankAccountNo;
                    this.tdSellerBankName.Value = company.BankName;
                    this.tdReCheckUserName.Value = company.ReCheckUserName;
                    this.tdCheque_SL.Value = company.Cheque_SL > decimal.MinValue ? company.Cheque_SL.ToString("0.00") : string.Empty;
                    this.tdCheque_FLBM.Value = company.Cheque_FLBM;
                }
            }
        }
    }
}