using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.PayService
{
    public partial class EditPayService : BasePage
    {
        public Foresight.DataAccess.PayService service = null;
        public int ID = 0;
        public bool can_edit = true;
        protected void Page_Load(object sender, EventArgs e)
        {
            ID = 0;
            if (!string.IsNullOrEmpty(Request.QueryString["ID"]))
            {
                int.TryParse(Request.QueryString["ID"], out ID);
                if (ID > 0)
                {
                    service = Foresight.DataAccess.PayService.GetPayService(ID);
                    if (service != null)
                    {
                        SetInfo(service);
                        return;
                    }
                }
            }
            this.tdPayTime.Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            this.tdAddMan.Value = WebUtil.GetUser(this.Context).RealName;
        }
        private void SetInfo(Foresight.DataAccess.PayService data)
        {
            this.tdProjectName.Value = data.ProjectName;
            this.tdRoomName.Value = data.RoomName;
            this.tdPaySummary.Value = data.PaySummaryID == int.MinValue ? "1" : data.PaySummaryID.ToString();
            this.tdPayMoney.Value = data.PayMoney == decimal.MinValue ? "0" : data.PayMoney.ToString();
            this.tdPayType.Value = data.PayTypeID == int.MinValue ? "1" : data.PayTypeID.ToString();
            this.hdPayType.Value = data.PayType;
            this.tdAddMan.Value = data.AddMan;
            this.tdPayTime.Value = data.PayTime == DateTime.MinValue ? "0" : data.PayTime.ToString("yyyy-MM-dd HH:mm:ss");
            this.tdAccountType.Value = data.AccountType;
            this.tdRemark.Value = data.Remark;
            this.hdProjectID.Value = data.ProjectID > 0 ? data.ProjectID.ToString() : "";
            if (data.Status <= 0 || data.Status == 3)
            {
                this.can_edit = false;
            }
        }
    }
}