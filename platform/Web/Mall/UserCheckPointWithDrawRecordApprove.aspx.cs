using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Mall
{
    public partial class UserCheckPointWithDrawRecordApprove : BasePage
    {
        public int ID = 0;
        public bool CanApprove = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["ID"] != null)
            {
                int.TryParse(Request.QueryString["ID"], out ID);
            }
            if (ID > 0)
            {
                var data = Foresight.DataAccess.Mall_PointWithDrawRecord.GetMall_PointWithDrawRecord(ID);
                SetInfo(data);
                return;
            }
        }
        private void SetInfo(Foresight.DataAccess.Mall_PointWithDrawRecord data)
        {
            this.tdAddUserName.InnerHtml = data.AddUserName;
            this.tdAddTime.InnerHtml = data.AddTime.ToString("yyyy-MM-dd");
            this.tdPointValue.InnerHtml = data.PointValue.ToString();
            this.tdStatus.InnerHtml = data.StatusDesc.ToString();
            if (data.Status == 2)
            {
                CanApprove = true;
                this.tdApproveUserName.InnerHtml = WebUtil.GetUser(this.Context).LoginName;
                this.tdApproveTime.InnerHtml = DateTime.Now.ToString("yyyy-MM-dd");
            }
            else
            {
                CanApprove = false;
                this.tdApproveUserName.InnerHtml = data.ApproveUserName;
                this.tdApproveTime.InnerHtml = data.ApproveTime.ToString("yyyy-MM-dd");
                this.tdApproveRemark.Value = data.ApproveRemark;
            }
        }
    }
}