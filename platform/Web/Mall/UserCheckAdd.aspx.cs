using Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Mall
{
    public partial class UserCheckAdd : BasePage
    {
        public int CheckID = 0;
        public string op = "edit";
        public int RequestType = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["ID"] != null)
            {
                int.TryParse(Request.QueryString["ID"], out CheckID);
            }
            if (Request.QueryString["op"] != null)
            {
                op = Request.QueryString["op"];
            }
            if (CheckID > 0)
            {
                var data = Foresight.DataAccess.Mall_CheckRequest.GetMall_CheckRequest(CheckID);
                if (data != null)
                {
                    SetInfo(data);
                }
            }
        }
        private void SetInfo(Foresight.DataAccess.Mall_CheckRequest data)
        {
            this.tdRemark.Value = data.Remark;
            var user_list = Foresight.DataAccess.User.GetAPPUserListByCheckRequestID(data.ID);
            if (user_list.Length > 0)
            {
                this.tdUserName.Value = string.Join(",", user_list.Select(p => p.LoginName).ToArray());
                this.hdUserIDs.Value = JsonConvert.SerializeObject(user_list.Select(p => p.UserID).ToArray());
            }
            this.RequestType = data.RequestType;
        }
    }
}