using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Cheque
{
    public partial class ChequeSign : BasePage
    {
        public Foresight.DataAccess.Cheque_InSummary summary;
        protected void Page_Load(object sender, EventArgs e)
        {
            int ID = 0;
            int.TryParse(Request.QueryString["ID"], out ID);
            summary = Foresight.DataAccess.Cheque_InSummary.GetCheque_InSummary(ID);
            if (summary == null)
            {
                Response.End();
                return;
            }
            if (summary.SignState == 1)
            {
                SetInfo(summary);
                return;
            }
            this.tdSignOperator.Value = WebUtil.GetUser(this.Context).RealName;
            this.tdSignTime.Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
        private void SetInfo(Foresight.DataAccess.Cheque_InSummary data)
        {
            this.tdSignOperator.Value = data.SignOperator;
            this.tdSignTime.Value = data.SignTime > DateTime.MinValue ? data.SignTime.ToString("yyyy-MM-dd HH:mm:ss") : "";
            this.tdSignRemark.Value = data.SignRemark;
        }
    }
}