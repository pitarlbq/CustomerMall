using Foresight.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Web.PayService
{
    public partial class EditPaySummary : BasePage
    {
        public int ID;
        protected void Page_Load(object sender, EventArgs e)
        {
            ID = 0;
            int.TryParse(Request.QueryString["ID"], out ID);
            if (ID > 0)
            {
                var data = Foresight.DataAccess.PaySummary.GetPaySummary(ID);
                if (data != null)
                {
                    SetInfo(data);
                    return;
                }
            }
        }
        private void SetInfo(Foresight.DataAccess.PaySummary data)
        {
            this.tdPayName.Value = data.PayName;
            this.tdRemark.Value = data.Remark;
            this.tdRelateFeeType_Pay.Checked = data.RelateFeeType_Pay;
        }
    }
}