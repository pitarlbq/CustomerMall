using Foresight.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.APPSetup
{
    public partial class UserEdit : BasePage
    {
        public int UserID = 0;
        public int type = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["type"] != null)
                {
                    int.TryParse(Request.QueryString["type"], out type);
                }
                UserID = 0;
                int.TryParse(Request.QueryString["UserID"], out UserID);
                if (UserID > 0)
                {
                    var data = Foresight.DataAccess.User.GetUser(UserID);
                    if (data != null)
                    {
                        SetInfo(data);
                        return;
                    }
                }
            }
        }
        private void SetInfo(Foresight.DataAccess.User data)
        {
            this.tdNickName.Value = string.IsNullOrEmpty(data.RealName) ? data.NickName : data.RealName;
            this.hdCustomerName.Value = this.tdNickName.Value;
            this.tdPhoneNumber.Value = data.PhoneNumber;
            this.tdGender.Value = data.Gender;
            this.tdIsLocked.Value = data.IsLocked ? "1" : "0";
            this.tdLoginName.Value = data.LoginName;
            this.hdPwd.Value = data.Password;
            this.tdUserType.Value = data.Type;
            this.hdIsAllowSysLogin.Value = data.IsAllowSysLogin ? "1" : "0";
            this.hdIsAllowAPPUserLogin.Value = data.IsAllowAPPUserLogin ? "1" : "0";
            this.tdPositionName.Value = data.PositionName;
            this.tdDepartment.Value = data.DepartmentID > 0 ? data.DepartmentID.ToString() : "";
            this.tdEducation.Value = data.Education;
            this.tdFixedPoint.Value = data.FixedPoint > 0 ? data.FixedPoint.ToString() : "0";
            this.tdFixedPointUpdateDate.Value = data.FixedPointUpdateDate > DateTime.MinValue ? data.FixedPointUpdateDate.ToString("yyyy-MM-dd") : "";
            this.tdIsAllowPhrase.Value = data.IsAllowPhrase ? "1" : "0";
        }
    }
}