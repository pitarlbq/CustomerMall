using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Cheque
{
    public partial class ChequeCheck_Approve : BasePage
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
        }
        private void SetInfo(Foresight.DataAccess.Cheque_Confirm data)
        {
            this.tdApproveTime.Value = data.ApproveTime > DateTime.MinValue ? data.ApproveTime.ToString("yyyy-MM-dd") : "";
            this.tdApproveMan.Value = data.ApproveMan;
            this.tdApproveMethod.Value = data.ApproveMethod;
            this.tdApproveMonth.Value = data.ApproveMonth;
            this.tdApproveRemark.Value = data.ApproveRemark;
        }
    }
}