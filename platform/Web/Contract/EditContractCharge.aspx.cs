using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Contract
{
    public partial class EditContractCharge : BasePage
    {
        public int ContractID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int ID = 0;
                int.TryParse(Request.QueryString["ID"], out ID);
                var data = Foresight.DataAccess.ViewContractChargeSummary.GetViewContractChargeSummaryByID(ID);
                if (data == null)
                {
                    Response.End();
                    return;
                }
                ContractID = data.ContractID;
                SetInfo(data);
            }
        }
        private void SetInfo(Foresight.DataAccess.ViewContractChargeSummary data)
        {
            this.tdFullName.Value = string.IsNullOrEmpty(data.FullName) ? "所有房间" : data.FullName;
            this.tdRoomName.Value = data.Name;
            this.tdChargeID.Value = data.ChargeID.ToString();
            this.tdUnitPrice.Value = data.CalculateUnitPrice.ToString();
            this.tdStartTime.Value = data.CalculateStartTime > DateTime.MinValue ? data.CalculateStartTime.ToString("yyyy-MM-dd") : "";
            this.tdEndTime.Value = data.CalculateEndTime > DateTime.MinValue ? data.CalculateEndTime.ToString("yyyy-MM-dd") : "";
            this.tdNewEndTime.Value = data.CalculateNewEndTime > DateTime.MinValue ? data.CalculateNewEndTime.ToString("yyyy-MM-dd") : "";
            this.tdTotalCost.Value = data.CalcualteTotalCost.ToString();
            this.tdRemark.Value = data.Remark;
            this.tdRoomUseCount.Value = data.CalculateUseCount.ToString();
            this.tdReadyChargeTime.Value = data.ReadyChargeTime > DateTime.MinValue ? data.ReadyChargeTime.ToString("yyyy-MM-dd") : "";
        }
    }
}