using Foresight.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.APPSetup
{
    public partial class UserCouponEdit : BasePage
    {
        public int ID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int.TryParse(Request.QueryString["ID"], out ID);
                if (ID > 0)
                {
                    var data = Foresight.DataAccess.Mall_CouponUser.GetMall_CouponUser(ID);
                    if (data != null)
                    {
                        SetInfo(data);
                        return;
                    }
                }
            }
        }
        private void SetInfo(Foresight.DataAccess.Mall_CouponUser data)
        {
            var user = Foresight.DataAccess.User.GetUser(data.UserID);
            if (user != null)
            {
                this.label_NickName.InnerHtml = user.NickName;
                this.label_PhoneNumber.InnerHtml = user.PhoneNumber;
            }
            var coupon = Mall_Coupon.GetMall_Coupon(data.CouponID);
            if (coupon != null)
            {
                this.label_CouponName.InnerHtml = coupon.CouponName;
                this.label_CouponType.InnerHtml = coupon.CouponTypeDesc;
                this.label_UseFor.InnerHtml = coupon.UseForALLDesc;
                this.label_UseRule.InnerHtml = coupon.UseTypeMoreDesc;
               
            }
            this.tdStartTime.Value = data.StartTime > DateTime.MinValue ? data.StartTime.ToString("yyyy-MM-dd") : "";
            this.tdEndTime.Value = data.EndTime > DateTime.MinValue ? data.EndTime.ToString("yyyy-MM-dd") : "";
            this.tdIsActive.Value = data.IsActive ? "1" : "0";
        }
    }
}