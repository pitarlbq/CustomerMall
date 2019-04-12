using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.APPSetup
{
    public partial class UserForbiddenEdit : BasePage
    {
        public int ID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["ID"] != null)
            {
                int.TryParse(Request.QueryString["ID"], out ID);
            }
            if (ID > 0)
            {
                var data = Foresight.DataAccess.Mall_UserForbidden.GetMall_UserForbidden(ID);
                SetInfo(data);
            }
        }
        private void SetInfo(Foresight.DataAccess.Mall_UserForbidden data)
        {
            if (data.UserID > 0)
            {
                this.hdUserID.Value = data.UserID > 0 ? data.UserID.ToString() : "0";
                var user = Foresight.DataAccess.User.GetUser(data.UserID);
                if (user != null)
                {
                    this.tdNickName.Value = string.IsNullOrEmpty(user.NickName) ? user.PhoneNumber : user.NickName;
                }
                this.tdStartTime.Value = data.ForbiddenStartTime > DateTime.MinValue ? data.ForbiddenStartTime.ToString("yyyy-MM-dd") : "";
                this.tdEndTime.Value = data.ForbiddenEndTime > DateTime.MinValue ? data.ForbiddenEndTime.ToString("yyyy-MM-dd") : "";
            }
        }
    }
}