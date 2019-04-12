using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Cheque
{
    public partial class ChequeOutWriteCheque : BasePage
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
        }
        private void SetInfo(Foresight.DataAccess.Cheque_OutSummary data)
        {
            this.tdWriteMan.Value = data.WriteMan;
            this.tdChequeCode.Value = data.ChequeCode;
            this.tdChequeNumber.Value = data.ChequeNumber;
            this.tdChequeTime.Value = data.ChequeTime > DateTime.MinValue ? data.ChequeTime.ToString("yyyy-MM-dd HH:mm:ss") : "";
        }
    }
}