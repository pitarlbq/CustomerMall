using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utility;

namespace Web.Mall
{
    public partial class MemberAmountRuleEdit : BasePage
    {
        public int RuleID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["ID"] != null)
            {
                int.TryParse(Request.QueryString["ID"], out RuleID);
            }
            if (RuleID > 0)
            {
                var data = Foresight.DataAccess.Mall_AmountRule.GetMall_AmountRule(RuleID);
                SetInfo(data);
            }
        }
        private void SetInfo(Foresight.DataAccess.Mall_AmountRule data)
        {
            this.tdIsUseForALLProduct.Value = data.IsUseForALLProduct ? "1" : "0";
            this.hdIsUseForALLProduct.Value = data.IsUseForALLProduct ? "1" : "0";
            if (!data.IsUseForALLProduct)
            {
                var list = Foresight.DataAccess.Mall_Product.GetMall_CouponProductListByAmountRuleID(data.ID);
                if (list.Length > 0)
                {
                    this.tdProducts.Value = string.Join(",", list.Select(p => p.ProductName).ToArray());
                    this.hdProducts.Value = JsonConvert.SerializeObject(list.Select(p => p.ID).ToArray());
                }
            }
            this.tdIsUseForALLService.Value = data.IsUseForALLService ? "1" : "0";
            this.hdIsUseForALLService.Value = data.IsUseForALLService ? "1" : "0";
            if (!data.IsUseForALLService)
            {
                var list = Foresight.DataAccess.Wechat_HouseService.GetWechat_HouseServiceListByCouponID(data.ID);
                if (list.Length > 0)
                {
                    this.tdServices.Value = string.Join(",", list.Select(p => p.Title).ToArray());
                    this.hdServices.Value = JsonConvert.SerializeObject(list.Select(p => p.ID).ToArray());
                }
            }
            this.tdTitle.Value = data.Title;
            this.tdStartAmount.Value = data.StartAmount > 0 ? data.StartAmount.ToString("0.00") : "0";
            this.tdEndAmount.Value = data.EndAmount > 0 ? data.EndAmount.ToString("0.00") : "0";
            this.tdBackAmount.Value = data.BackAmount > 0 ? data.BackAmount.ToString("0.00") : "0";
            this.tdBackPoint.Value = data.BackPoint > 0 ? data.BackPoint.ToString("0") : "0";
            this.tdRemark.Value = data.Remark;
            this.tdIsActive.Value = data.IsActive ? "1" : "0";
            this.tdBackAmountType.Value = data.BackAmountType > 0 ? data.BackAmountType.ToString() : "";
            this.tdBackPointType.Value = data.BackPointType > 0 ? data.BackPointType.ToString() : "";
            this.tdAmountType.Value = data.AmountType > 0 ? data.AmountType.ToString() : "";
            if (data.AdditionalEarnService)
            {
                var list = Foresight.DataAccess.Mall_Coupon.GetMall_CouponListByAmountRuleID(data.ID);
                if (list.Length > 0)
                {
                    this.tdCoupons.Value = string.Join(",", list.Select(p => p.CouponName).ToArray());
                    this.hdCoupons.Value = JsonConvert.SerializeObject(list.Select(p => p.ID).ToArray());
                }
            }
            this.tdRuleType.Value = data.RuleType > 0 ? data.RuleType.ToString() : "";
            this.tdIsSendNow.Checked = data.IsSendNow;
            this.tdIsReadySendTime.Value = data.IsReadySendTime > DateTime.MinValue ? data.IsReadySendTime.ToString("yyyy-MM-dd") : "";
            this.tdSendCouponCount.Value = data.SendCouponCount >= 0 ? data.SendCouponCount.ToString() : "1";
            var project_list = Foresight.DataAccess.Project.GetMall_AmountRuleProjectListByAmountRuleID(data.ID);
            if (project_list.Length > 0)
            {
                this.tdRoomID.Value = string.Join(",", project_list.Select(p => p.Name).ToArray());
                this.hdRoomID.Value = JsonConvert.SerializeObject(project_list.Select(p => p.ID).ToArray());
            }
            this.tdIsUseForALLProject.Checked = data.IsUseForALLProject;
            this.tdPopupUnTakeDay.Value = data.PopupUnTakeDay > 0 ? data.PopupUnTakeDay.ToString() : "0";
            this.tdPopupBeforeExpireDay.Value = data.PopupBeforeExpireDay > 0 ? data.PopupBeforeExpireDay.ToString() : "0";
        }
    }
}