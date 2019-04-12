using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Foresight.DataAccess;

namespace Web.RoomResource
{
    public partial class EditRelateFamily : BasePage
    {
        public string TableName = Utility.EnumModel.DefineFieldTableName.RoomPhoneRelation.ToString();
        public RoomPhoneRelation relation = null;
        public bool canEditName = true;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["ID"]))
            {
                int ID = 0;
                if (int.TryParse(Request.QueryString["ID"], out ID))
                {
                    relation = RoomPhoneRelation.GetRoomPhoneRelation(ID);
                }
            }
            if (relation != null)
            {
                this.tdRelationProperty.Value = relation.RelationProperty;
                this.tdRelateName.Value = relation.RelationName;
                this.tdRelatePhone.Value = relation.RelatePhoneNumber;
                this.tdRelateIDCard.Value = relation.RelationIDCard;
                this.tdIsDefault.Checked = relation.IsDefault;
                this.tdIsChargeMan.Checked = relation.IsChargeMan;
                this.tdIsChargeFee.Checked = relation.IsChargeFee;
                this.tdIDCardType.Value = relation.IDCardType == int.MinValue ? "1" : relation.IDCardType.ToString();
                this.tdBirthday.Value = relation.Birthday == DateTime.MinValue ? "" : relation.Birthday.ToString("yyyy-MM-dd");
                this.tdEmailAddress.Value = relation.EmailAddress;
                this.tdHomeAddress.Value = relation.HomeAddress;
                this.tdOfficeAddress.Value = relation.OfficeAddress;
                this.tdBankName.Value = relation.BankName;
                this.tdBankAccountName.Value = relation.BankAccountName;
                this.tdBankNo.Value = relation.BankAccountNo;
                this.tdCustomOne.Value = relation.CustomOne;
                this.tdCustomTwo.Value = relation.CustomTwo;
                this.tdCustomThree.Value = relation.CustomThree;
                this.tdCustomFour.Value = relation.CustomFour;
                this.tdRemark.Value = relation.Remark;
                this.tdContractStartTime.Value = relation.ContractStartTime == DateTime.MinValue ? "" : relation.ContractStartTime.ToString("yyyy-MM-dd");
                this.tdContractEndTime.Value = relation.ContractEndTime == DateTime.MinValue ? "" : relation.ContractEndTime.ToString("yyyy-MM-dd");
                this.tdBrandNote.Value = relation.BrandInfo;
                this.tdContractNote.Value = relation.ContractNote;
                this.tdInteresting.Value = relation.Interesting;
                this.tdConsumeMore.Value = relation.ConsumeMore;
                this.tdBelongTeam.Value = relation.BelongTeam;
                this.tdOneCardNumber.Value = relation.OneCardNumber;
                this.tdChargeForMan.Value = relation.ChargeForMan;
                this.tdCompanyName.Value = relation.CompanyName;
                this.canEditName = true;
                if (relation.ContractID > 0)
                {
                    var contract_room = Foresight.DataAccess.Contract_Room.GetContract_RoomListByContractID(relation.ContractID).FirstOrDefault(p => p.RoomID == relation.RoomID);
                    this.canEditName = contract_room == null;
                }
                this.tdRelationType.Value = relation.RelationType;
            }
        }
    }
}