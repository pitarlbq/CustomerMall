using Foresight.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Web.Mall
{
    public partial class BusinessUserEdit : BasePage
    {
        public int UserID = 0;
        public int BusinessID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["ID"] != null)
                {
                    int.TryParse(Request.QueryString["ID"], out BusinessID);
                }
                if (Request.QueryString["UserID"] != null)
                {
                    int.TryParse(Request.QueryString["UserID"], out UserID);
                }
                Mall_Business data = null;
                if (BusinessID > 0)
                {
                    data = Foresight.DataAccess.Mall_Business.GetMall_Business(BusinessID);
                }

                if (UserID > 0)
                {
                    var user = Foresight.DataAccess.User.GetUser(UserID);
                    SetInfo(user);
                }
            }
        }
        private void SetInfo(Foresight.DataAccess.User data)
        {
            if (data == null)
            {
                return;
            }
            this.UserID = data.UserID;
            this.tdCustomerName.Value = string.IsNullOrEmpty(data.RealName) ? data.NickName : data.RealName;
            this.hdCustomerName.Value = this.tdCustomerName.Value;
            this.tdPhoneNumber.Value = data.PhoneNumber;
            this.tdGender.Value = data.Gender;
            this.tdIsLocked.Value = data.IsLocked ? "1" : "0";
            this.tdLoginName.Value = data.LoginName;
            this.hdPwd.Value = data.Password;
        }
    }
}