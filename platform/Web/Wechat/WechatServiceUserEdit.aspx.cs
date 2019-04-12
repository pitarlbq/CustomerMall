using Foresight.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utility;

namespace Web.Wechat
{
    public partial class WechatServiceUserEdit : BasePage
    {
        public int ID = 0;
        public int can_edit_wx = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int UserID = 0;
                int.TryParse(Request.QueryString["ID"], out ID);
                if (ID > 0)
                {
                    var data = Foresight.DataAccess.Wechat_ServiceUser.GetWechat_ServiceUser(ID);
                    if (data != null)
                    {
                        can_edit_wx = 0;
                        SetInfo(data);
                        UserID = data.UserID;
                    }
                }
                var user_list = Foresight.DataAccess.User.GetWechatServiceUserListByUserID(UserID);
                var items = user_list.Select(p =>
                {
                    var item = new { ID = p.UserID, Name = p.FinalRealName };
                    return item;
                }).ToArray();
                this.hdUserList.Value = Utility.JsonConvert.SerializeObject(items);
            }
        }
        private void SetInfo(Foresight.DataAccess.Wechat_ServiceUser data)
        {
            this.tdNickName.Value = data.NickName;
            this.tdAccountName.Value = data.AccountName;
            this.tdWx_Account.Value = data.Wx_Account;
            this.tdUserList.Value = data.UserID > 0 ? data.UserID.ToString() : "";
        }
    }
}