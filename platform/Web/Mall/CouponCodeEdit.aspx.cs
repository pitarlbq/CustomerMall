using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utility;

namespace Web.Mall
{
    public partial class CouponCodeEdit : BasePage
    {
        public int CouponID = 0;
        public int type = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["ID"] != null)
            {
                int.TryParse(Request.QueryString["ID"], out CouponID);
            }
            if (CouponID > 0)
            {
                var data = Foresight.DataAccess.Mall_Coupon.GetMall_Coupon(CouponID);
                SetInfo(data);
            }
        }
        private void SetInfo(Foresight.DataAccess.Mall_Coupon data)
        {
            this.tdIsAutoShowOnProduct.Value = data.IsAutoShowOnProduct ? "1" : "0";
            this.tdCouponName.Value = data.CouponName;
            this.tdIsActive.Value = data.IsActive ? "1" : "0";
            this.tdSummary.Value = data.Summary;
            this.tdStartTime.Value = data.StartTime > DateTime.MinValue ? data.StartTime.ToString("yyyy-MM-dd HH:mm:ss") : "";
            this.tdEndTime.Value = data.EndTime > DateTime.MinValue ? data.EndTime.ToString("yyyy-MM-dd HH:mm:ss") : "";
            this.hdIsUseForALLProduct.Value = data.IsUseForALLProduct ? "1" : "0";
            if (!data.IsUseForALLProduct)
            {
                var list = Foresight.DataAccess.Mall_Product.GetMall_CouponProductListByCouponID(data.ID);
                if (list.Length > 0)
                {
                    this.tdProducts.Value = string.Join(",", list.Select(p => p.ProductName).ToArray());
                    this.hdProducts.Value = JsonConvert.SerializeObject(list.Select(p => p.ID).ToArray());
                }
            }
            this.tdUseType.Value = data.UseType > 0 ? data.UseType.ToString() : "";
            this.tdAmountType.Value = data.AmountType > 0 ? data.AmountType.ToString() : "";
            if (data.UseType == 1)
            {
                this.tdUseNeedAmount.Value = data.UseNeedAmount.ToString("0.00");
                this.tdReduceAmount1.Value = data.ReduceAmount.ToString("0.00");
            }
            else if (data.UseType == 2)
            {
                this.tdReduceAmount2.Value = data.ReduceAmount.ToString("0.00");
            }
            this.tdIsUseForWY.Checked = data.IsUseForWY;
            this.tdIsUseForProduct.Checked = data.IsUseForProduct;
            this.tdIsUseForService.Checked = data.IsUseForService;
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
            this.tdCouponType.Value = data.CouponType > 0 ? data.CouponType.ToString() : "";

            this.hdIsUseForALLStore.Value = data.IsUseForALLStore ? "1" : "0";
            if (!data.IsUseForALLStore)
            {
                var list = Foresight.DataAccess.Mall_Business.GetMall_BusinessListByCouponID(data.ID);
                if (list.Length > 0)
                {
                    this.tdStores.Value = string.Join(",", list.Select(p => p.BusinessName).ToArray());
                    this.hdStores.Value = JsonConvert.SerializeObject(list.Select(p => p.ID).ToArray());
                }
            }

            this.hdIsUseForALLCategory.Value = data.IsUseForALLCategory ? "1" : "0";
            if (!data.IsUseForALLCategory)
            {
                var list = Foresight.DataAccess.Mall_Category.GetMall_ProductCategoryListByCouponID(data.ID);
                if (list.Length > 0)
                {
                    this.tdCategorys.Value = string.Join(",", list.Select(p => p.CategoryName).ToArray());
                    this.hdProductCategorys.Value = JsonConvert.SerializeObject(list.Select(p => p.ID).ToArray());
                }
            }
        }
    }
}