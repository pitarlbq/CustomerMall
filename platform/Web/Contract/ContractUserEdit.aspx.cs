using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Foresight.DataAccess;

namespace Web.RoomResource
{
    public partial class ContractUserEdit : BasePage
    {
        public int ID = 0;
        public bool canEdit = true;
        protected void Page_Load(object sender, EventArgs e)
        {
            RoomPhoneRelation relationPhone = null;
            if (!string.IsNullOrEmpty(Request.QueryString["ID"]))
            {
                var op = Request.QueryString["op"];
                if (!string.IsNullOrEmpty(op) && op.Equals("view"))
                {
                    this.canEdit = false;
                }
                ID = 0;
                if (int.TryParse(Request.QueryString["ID"], out ID))
                {
                    relationPhone = RoomPhoneRelation.GetRoomPhoneRelation(ID);
                }
            }
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
        }
    }
}