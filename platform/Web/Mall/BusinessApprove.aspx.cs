using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Mall
{
    public partial class BusinessApprove : BasePage
    {
        public int Status = 0;
        public int BusinessID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["ID"] != null)
            {
                int.TryParse(Request.QueryString["ID"], out BusinessID);
            }
            if (BusinessID > 0)
            {
                var data = Foresight.DataAccess.Mall_Business.GetMall_Business(BusinessID);
                SetInfo(data);
            }
        }
        private void SetInfo(Foresight.DataAccess.Mall_Business data)
        {
            this.tdBusinessName.Value = data.BusinessName;
            this.tdBusinessAddress.Value = data.BusinessAddress;
            this.tdContactName.Value = data.ContactName;
            this.tdContactPhone.Value = data.ContactPhone;
            this.tdLicenseNumber.Value = data.LicenseNumber;
            this.Status = data.Status;
            this.tdApproveRemark.Value = data.ApproveRemark;
            if (data.Status != 10)
            {
                this.tdApproveMan.Value = data.ApproveMan;
                this.tdApproveTime.Value = data.ApproveTime > DateTime.MinValue ? data.ApproveTime.ToString("yyyy-MM-dd HH:mm:ss") : string.Empty;
            }
            else
            {
                this.tdApproveMan.Value = WebUtil.GetUser(this.Context).RealName;
                this.tdApproveTime.Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            }
        }
    }
}