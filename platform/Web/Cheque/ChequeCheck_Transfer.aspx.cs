using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Cheque
{
    public partial class ChequeCheck_Transfer : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int ID = 0;
            int.TryParse(Request.QueryString["ID"], out ID);
            int InSummaryID = 0;
            int.TryParse(Request.QueryString["InSummaryID"], out InSummaryID);
            var data = Foresight.DataAccess.Cheque_Confirm.GetCheque_Confirm(ID);
            if (data != null && data.ApproveStatus == 1)
            {
                SetInfo(data);
                return;
            }
            var list = Foresight.DataAccess.Cheque_InDetail.GetCheque_InDetailList(InSummaryID);
            decimal totalCost = list.Sum(p => p.TotalSummaryCost);
            this.tdTransferMoney.Value = totalCost > 0 ? totalCost.ToString() : "";
        }
        private void SetInfo(Foresight.DataAccess.Cheque_Confirm data)
        {
            this.tdTransferTime.Value = data.TransferTime > DateTime.MinValue ? data.TransferTime.ToString("yyyy-MM-dd") : "";
            this.tdTransferMan.Value = data.TransferMan;
            this.tdTransferMoney.Value = data.TransferMoney > 0 ? data.TransferMoney.ToString() : "";
            this.tdTransferRemark.Value = data.TransferRemark;
        }
    }
}