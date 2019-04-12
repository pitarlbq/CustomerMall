using ExcelProcess;
using Foresight.DataAccess;
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
    public partial class NewAddContract_More : BasePage
    {
        public string guid = string.Empty;
        public Foresight.DataAccess.Contract contract = null;
        public Foresight.DataAccess.Contract_Approve approve = null;
        public Foresight.DataAccess.Contract_Stop stop = null;
        public string op = string.Empty;
        public bool canEdit = false;
        public bool cansavelog = false;
        public bool canprint = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                op = !string.IsNullOrEmpty(Request.QueryString["op"]) ? Request.QueryString["op"] : string.Empty;
                guid = System.Guid.NewGuid().ToString();
                int ContractID = 0;
                int.TryParse(Request.QueryString["ID"], out ContractID);
                contract = Foresight.DataAccess.Contract.GetContract(ContractID);
                if (contract != null)
                {
                    var list = Contract_Room.GetContract_RoomListByContractID(contract.ID);
                    SetInfo(contract);
                    approve = Foresight.DataAccess.Contract_Approve.GetContract_ApproveByContractID(contract.ID);
                    stop = Foresight.DataAccess.Contract_Stop.GetContract_StopByContractID(contract.ID);
                }
                if (contract == null || contract.ContractStatus.Equals("yuding") || this.op.Equals("edit"))
                {
                    canEdit = true;
                }
                if (this.op.Equals("edit"))
                {
                    cansavelog = true;
                }
                if (contract != null)
                {
                    canprint = true;
                }
            }
        }
        private void SetInfo(Foresight.DataAccess.Contract data)
        {
            this.tdRoomUseFor.Value = data.RoomUseFor;
            this.tdRoomStatus.Value = data.RoomStatus;
            this.tdSignTime.Value = data.SignTime > DateTime.MinValue ? data.SignTime.ToString("yyyy-MM-dd") : "";
            this.tdFreeStartTime.Value = data.FreeStartTime > DateTime.MinValue ? data.FreeStartTime.ToString("yyyy-MM-dd") : "";
            this.tdFreeEndTime.Value = data.FreeEndTime > DateTime.MinValue ? data.FreeEndTime.ToString("yyyy-MM-dd") : "";
            this.tdOpenTime.Value = data.OpenTime > DateTime.MinValue ? data.OpenTime.ToString("yyyy-MM-dd") : "";
            this.tdInTime.Value = data.InTime > DateTime.MinValue ? data.InTime.ToString("yyyy-MM-dd") : "";
            this.tdOutTime.Value = data.OutTime > DateTime.MinValue ? data.OutTime.ToString("yyyy-MM-dd") : "";
            this.tdRentRange.Value = data.RentRange;
            this.tdChargeRange.Value = data.ChargeRange;
            this.tdSellerProduct.Value = data.SellerProduct;
            this.tdEveryYearUp.Value = data.EveryYearUp > decimal.MinValue ? data.EveryYearUp.ToString() : "";
            this.tdBrandModel.Value = data.BrandModel;
            this.tdPhoneNumber.Value = data.PhoneNumber;
            this.tdAddress.Value = data.Address;
            this.tdCustomerName.Value = data.CustomerName;
            this.tdIDCardNo.Value = data.IDCardNo;
            this.tdDeliverTime.Value = data.DeliverTime > DateTime.MinValue ? data.DeliverTime.ToString("yyyy-MM-dd HH:mm:ss") : "";
            this.tdIDCardAddress.Value = data.IDCardAddress;
            this.tdRentUseFor.Value = data.RentUseFor;
            this.tdBusinessLicense.Value = data.BusinessLicense;
            this.tdInChargeMan.Value = data.InChargeMan;
        }
    }
}