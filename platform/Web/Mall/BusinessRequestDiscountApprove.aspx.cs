using Foresight.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Mall
{
    public partial class BusinessRequestDiscountApprove : BasePage
    {
        public int Status = 0;
        public int ID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["ID"] != null)
            {
                int.TryParse(Request.QueryString["ID"], out ID);
            }
            if (ID > 0)
            {
                var data = Foresight.DataAccess.Mall_BusinessDiscountRequest.GetMall_BusinessDiscountRequest(ID);
                SetInfo(data);
            }
        }
        private void SetInfo(Foresight.DataAccess.Mall_BusinessDiscountRequest data)
        {
            this.labelAddUserMan.InnerHtml = data.AddUserMan;
            this.labelAddTime.InnerHtml = data.AddTime.ToString("yyyy-MM-dd HH:mm:ss");
            this.labelRequestContent.InnerHtml = data.RequestContent;
            if (data.BusinessID > 0)
            {
                var business = Mall_Business.GetMall_Business(data.BusinessID);
                if (business != null)
                {
                    this.labelBusinessName.InnerHtml = business.BusinessName;
                }
            }
            this.Status = data.Status;
            this.tdApproveRemark.Value = data.ApproveRemark;
            if (data.Status != 1)
            {
                this.tdApproveMan.Value = data.ApproveUserMan;
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