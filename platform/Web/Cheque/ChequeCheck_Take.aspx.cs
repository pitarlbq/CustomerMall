using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Cheque
{
    public partial class ChequeCheck_Take : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int ID = 0;
            int.TryParse(Request.QueryString["ID"], out ID);
            int InSummaryID = 0;
            int.TryParse(Request.QueryString["InSummaryID"], out InSummaryID);
            var data = Foresight.DataAccess.Cheque_Confirm.GetCheque_Confirm(ID);
            if (data != null && data.TakeStatus == 1)
            {
                SetInfo(data);
            }
        }
        private void SetInfo(Foresight.DataAccess.Cheque_Confirm data)
        {
            this.tdTakeTime.Value = data.TakeTime > DateTime.MinValue ? data.TakeTime.ToString("yyyy-MM-dd") : "";
            this.tdTakeUser.Value = data.TakeUser;
            this.tdTakeRemark.Value = data.TakeRemark;
        }
    }
}