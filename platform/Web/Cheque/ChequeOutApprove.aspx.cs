using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Cheque
{
    public partial class ChequeOutApprove : BasePage
    {
        public Foresight.DataAccess.Cheque_OutSummary summary;
        protected void Page_Load(object sender, EventArgs e)
        {
            int ID = 0;
            int.TryParse(Request.QueryString["ID"], out ID);
            summary = Foresight.DataAccess.Cheque_OutSummary.GetCheque_OutSummary(ID);
            if (summary == null)
            {
                Response.End();
                return;
            }
            if (summary.ApproveState == 1)
            {
                SetInfo(summary);
                return;
            }
            this.tdApproveOperator.Value = WebUtil.GetUser(this.Context).RealName;
            this.tdApporveTime.Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
        private void SetInfo(Foresight.DataAccess.Cheque_OutSummary data)
        {
            this.tdApproveOperator.Value = data.ApproveOperator;
            this.tdApporveTime.Value = data.ApporveTime > DateTime.MinValue ? data.ApporveTime.ToString("yyyy-MM-dd HH:mm:ss") : "";
            this.tdApproveRemark.Value = data.ApproveRemark;
        }
    }
}