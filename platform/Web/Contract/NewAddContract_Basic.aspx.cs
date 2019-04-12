using ExcelProcess;
using Foresight.DataAccess;
using Foresight.DataAccess.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utility;

namespace Web.Contract
{
    public partial class NewAddContract_Basic : BasePage
    {
        public int ContractID = 0;
        public bool canEdit = false;
        public bool canNewRent = false;
        public string op = string.Empty;
        public string guid = string.Empty;
        public bool canChangeRent = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                op = !string.IsNullOrEmpty(Request.QueryString["op"]) ? Request.QueryString["op"] : string.Empty;
                int.TryParse(Request.QueryString["ID"], out ContractID);
                if (this.op.Equals("edit") || this.op.Equals("newrent"))
                {
                    canEdit = true;
                }
                if (this.op.Equals("newrent"))
                {
                    canNewRent = true;
                }
                if (this.op.Equals("changerent"))
                {
                    canChangeRent = true;
                }
                Foresight.DataAccess.Contract contract = null;
                if (ContractID > 0)
                {
                    contract = Foresight.DataAccess.Contract.GetContract(ContractID);
                }
                if (contract == null)
                {
                    canEdit = true;
                    int OrderNumberID = 0;
                    this.tdContractNo.Value = Foresight.DataAccess.Contract.GetLastestContractNumber("", 0, out OrderNumberID);
                    this.hdOrderNumberID.Value = OrderNumberID.ToString();
                }
                else
                {
                    SetInfo(contract);
                    if (contract.ContractStatus.Equals("yuding"))
                    {
                        canEdit = true;
                    }
                }
            }
        }
        private void SetInfo(Foresight.DataAccess.Contract data)
        {
            this.tdContractType.Value = data.ContractType > 0 ? data.ContractType.ToString() : "1";
            this.tdContractName.Value = data.ContractName;
            this.tdContractNo.Value = data.ContractNo;
            this.tdTimeLimit.Value = data.TimeLimit > int.MinValue ? data.TimeLimit.ToString() : "";
            this.tdRentStartTime.Value = data.RentStartTime > DateTime.MinValue ? data.RentStartTime.ToString("yyyy-MM-dd") : "";
            this.tdRentEndTime.Value = data.RentEndTime > DateTime.MinValue ? data.RentEndTime.ToString("yyyy-MM-dd") : "";
            this.tdTimeLimit.Value = data.TimeLimit > int.MinValue ? data.TimeLimit.ToString() : "";
            //this.tdContractStatus.Value = data.ContractStatusDesc;
            //this.tdWarningTime.Value = data.WarningTime > DateTime.MinValue ? data.WarningTime.ToString("yyyy-MM-dd") : "";
            this.tdIsContractDivideOn.Checked = data.IsDivideOn;
            this.tdContractDevicePercent.Value = data.ContractDevicePercent > 0 ? data.ContractDevicePercent.ToString() : "";
            this.tdContractBasicRentCost.Value = data.ContractBasicRentCost > 0 ? data.ContractBasicRentCost.ToString() : "";
            if (this.canNewRent || canChangeRent)
            {
                this.ContractID = 0;
                int TopContractID = data.ID;
                string ContractNo = data.ContractNo;
                if (data.TopContractID > 0)
                {
                    var topContract = Foresight.DataAccess.Contract.GetContract(data.TopContractID);
                    if (topContract != null)
                    {
                        TopContractID = topContract.ID;
                        ContractNo = topContract.ContractNo;
                    }
                }
                if (canNewRent)
                {
                    this.tdRentStartTime.Value = data.RentEndTime > DateTime.MinValue ? data.RentEndTime.AddDays(1).ToString("yyyy-MM-dd") : "";
                    this.tdRentEndTime.Value = "";
                    int total = Foresight.DataAccess.Contract.GetRelatedContractCountByID(TopContractID, 1);
                    this.tdContractNo.Value = ContractNo + "(续" + (total + 1).ToString() + ")";
                }
                else if (canChangeRent)
                {
                    int total = Foresight.DataAccess.Contract.GetRelatedContractCountByID(TopContractID, 2);
                    this.tdContractNo.Value = ContractNo + "(转" + (total + 1).ToString() + ")";
                }
            }
            var relationPhone = RoomPhoneRelation.GetRoomPhoneRelation(data.RelationPhoneID);
            if (canChangeRent)
            {
                if (relationPhone != null)
                {
                    this.oldRelationProperty.InnerHtml = relationPhone.RelationPropertyDesc;
                    this.hdOldRelationProperty.Value = relationPhone.RelationProperty;
                    if (relationPhone.RelationProperty.Equals("geren"))
                    {
                        this.oldRentName.InnerHtml = relationPhone.RelationName;
                    }
                    else
                    {
                        this.oldRentName.InnerHtml = relationPhone.CompanyName;
                        this.oldCustomerName.InnerHtml = relationPhone.RelationName;
                    }
                    this.oldContractPhone.InnerHtml = relationPhone.RelatePhoneNumber;
                    this.oldIDCardType.InnerHtml = relationPhone.IDCardTypeDesc;
                    this.oldIDCardNo.InnerHtml = relationPhone.RelationIDCard;
                    this.oldIDCardAddress.InnerHtml = relationPhone.IDCardAddress;
                    this.oldInChargeMan.InnerHtml = relationPhone.CompanyInChargeMan;
                    this.oldBusinessLicense.InnerHtml = relationPhone.BusinessLicense;
                    this.oldSellerProduct.InnerHtml = relationPhone.SellerProduct;
                }
                else
                {
                    this.oldRelationProperty.InnerHtml = "个人";
                    this.hdOldRelationProperty.Value = "geren";
                    this.oldRentName.InnerHtml = data.RentName;
                    this.oldContractPhone.InnerHtml = data.ContractPhone;
                    this.oldCustomerName.InnerHtml = data.RentName;
                    this.oldIDCardType.InnerHtml = "";
                    this.oldIDCardNo.InnerHtml = data.IDCardNo;
                    this.oldIDCardAddress.InnerHtml = data.IDCardAddress;
                    this.oldInChargeMan.InnerHtml = data.InChargeMan;
                    this.oldBusinessLicense.InnerHtml = data.BusinessLicense;
                    this.oldSellerProduct.InnerHtml = data.SellerProduct;
                }
            }
            else
            {
                if (relationPhone != null)
                {
                    this.tdRelationProperty.Value = relationPhone.RelationProperty;
                    if (relationPhone.RelationProperty.Equals("geren"))
                    {
                        this.tdRentName.Value = relationPhone.RelationName;
                    }
                    else
                    {
                        this.tdRentName.Value = relationPhone.CompanyName;
                        this.tdCustomerName.Value = relationPhone.RelationName;
                    }
                    this.tdContractPhone.Value = relationPhone.RelatePhoneNumber;
                    this.tdIDCardType.Value = relationPhone.IDCardType == int.MinValue ? "1" : relationPhone.IDCardType.ToString();
                    this.tdIDCardNo.Value = relationPhone.RelationIDCard;
                    this.tdIDCardAddress.Value = relationPhone.IDCardAddress;
                    this.tdInChargeMan.Value = relationPhone.CompanyInChargeMan;
                    this.tdBusinessLicense.Value = relationPhone.BusinessLicense;
                    this.tdSellerProduct.Value = relationPhone.SellerProduct;
                }
                else
                {
                    this.tdRelationProperty.Value = "geren";
                    this.tdRentName.Value = data.RentName;
                    this.tdContractPhone.Value = data.ContractPhone;
                    this.tdCustomerName.Value = data.RentName;
                    this.tdIDCardType.Value = "1";
                    this.tdIDCardNo.Value = data.IDCardNo;
                    this.tdIDCardAddress.Value = data.IDCardAddress;
                    this.tdInChargeMan.Value = data.InChargeMan;
                    this.tdBusinessLicense.Value = data.BusinessLicense;
                    this.tdSellerProduct.Value = data.SellerProduct;
                }
            }
        }
    }
}