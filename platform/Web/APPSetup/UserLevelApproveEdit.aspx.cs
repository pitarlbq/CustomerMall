using Foresight.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.APPSetup
{
    public partial class UserLevelApproveEdit : BasePage
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
            this.tdUserLevelID.Value = data.ApproveUserLevelID > 0 ? data.ApproveUserLevelID.ToString() : "";
            this.tdIncomingAmount.Value = data.FinalIncomingAmount;
            this.tdIncomingType.Value = data.IncomingType;
            this.tdIncomingTime.Value = data.FinalyIncomingTime;
            this.tdDealManName.Value = data.DealManName;
            FilePath = string.IsNullOrEmpty(data.FilePath) ? "" : WebUtil.GetContextPath() + data.FilePath;
            if (data.RoomPhoneRelationID > 0)
            {
                var user = Foresight.DataAccess.RoomPhoneRelation.GetRoomPhoneRelation(data.RoomPhoneRelationID);
                if (user != null)
                {
                    this.hdUserName.Value = user.RelationName + "\r\n" + user.RelatePhoneNumber;
                    this.hdUserID.Value = user.UserID > 0 ? user.UserID.ToString("0") : "";
                    this.hdRelationID.Value = user.ID.ToString();
                    var project = Foresight.DataAccess.Project.GetProject(user.RoomID);
                    if (project != null)
                    {
                        this.hdUserName.Value += "\r\n" + project.FullName + "-" + project.Name;
                    }
                }
            }
        }
    }
}