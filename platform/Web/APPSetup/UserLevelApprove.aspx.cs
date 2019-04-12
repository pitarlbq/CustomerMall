using Foresight.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.APPSetup
{
    public partial class UserLevelApprove : BasePage
    {
        public int ApproveID = 0;
        public string FilePath = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request.QueryString["ID"], out ApproveID);
            if (ApproveID > 0)
            {
                var data = Foresight.DataAccess.Mall_UserLevelApproveDetail.GetMall_UserLevelApproveDetailByID(ApproveID);
                if (data != null)
                {
                    SetInfo(data);
                }
            }
        }
        private void SetInfo(Foresight.DataAccess.Mall_UserLevelApproveDetail data)
        {
            this.label_RequestTime.InnerHtml = data.RequestTime.ToString("yyyy-MM-dd HH:mm:ss");
            this.label_NickName.InnerHtml = data.FinalUserName;
            this.label_PhoneNumber.InnerHtml = data.FinalPhoneNumber;

            this.label_IncomingAmount.InnerHtml = data.FinalIncomingAmount;
            this.label_IncomingWay.InnerHtml = data.IncomingWay;
            this.label_IncomingTime.InnerHtml = data.FinalyIncomingTime;
            this.label_DealManName.InnerHtml = data.DealManName;

            var user_level = Foresight.DataAccess.Mall_UserLevel.GetMall_UserLevel(data.ApproveUserLevelID);
            if (user_level != null)
            {
                this.label_LevelName.InnerHtml = user_level.Name;
            }
            FilePath = string.IsNullOrEmpty(data.FilePath) ? "" : WebUtil.GetContextPath() + data.FilePath;
        }
    }
}