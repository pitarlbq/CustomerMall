using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utility;

namespace Web.Mall
{
    public partial class ProductEdit : BasePage
    {
        public int ProductID = 0;
        public int type = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["type"] != null)
            {
                int.TryParse(Request.QueryString["type"], out type);
            }
            if (this.type == 1)
            {
                this.tdProductType.InnerHtml = "(购买商品)";
            }
            else if (this.type == 2)
            {
                this.tdProductType.InnerHtml = "(积分兑换商品)";
            }
            else if (this.type == 3)
            {
                this.tdProductType.InnerHtml = "(拼团商品)";
            }
            if (Request.QueryString["ID"] != null)
            {
                int.TryParse(Request.QueryString["ID"], out ProductID);
            }
            if (ProductID > 0)
            {
                var data = Foresight.DataAccess.Mall_Product.GetMall_Product(ProductID);
                SetInfo(data);
            }
        }
        private void SetInfo(Foresight.DataAccess.Mall_Product data)
        {
            this.tdProductName.Value = data.ProductName;
            var category_list = Foresight.DataAccess.Mall_Category.GetMall_CategoryListByProductID(data.ID);
            if (category_list.Length > 0)
            {
                int[] category_idlist = category_list.Select(p => p.ID).ToArray();
                this.tdCategoryName.Value = string.Join(",", category_idlist);
            }
            this.tdBusinessName.Value = data.BusinessID > 0 ? data.BusinessID.ToString() : string.Empty;
            this.tdTotalCount.Value = data.TotalCount.ToString();
            this.tdBasicPrice.Value = data.BasicPrice > 0 ? data.BasicPrice.ToString() : "";
            this.tdSalePrice.Value = data.SalePrice.ToString();
            this.tdModelNumber.Value = data.ModelNumber;
            this.tdStatus.Value = data.Status.ToString();
            this.hdDescription.Value = data.Description;
            this.tdIsZiYing.Value = data.IsZiYing ? "1" : "0";
            this.tdPinSalePrice.Value = data.PinSalePrice > 0 ? data.PinSalePrice.ToString() : "";
            this.tdPinPeopleCount.Value = data.PinPeopleCount > 0 ? data.PinPeopleCount.ToString() : "";
            this.tdActiveTimeRange.Value = data.ActiveTimeRange > 0 ? data.ActiveTimeRange.ToString() : "";
            this.tdPinStartTime.Value = data.PinStartTime > DateTime.MinValue ? data.PinStartTime.ToString("yyyy-MM-dd HH:mm:ss") : "";
            this.tdPinEndTime.Value = data.PinEndTime > DateTime.MinValue ? data.PinEndTime.ToString("yyyy-MM-dd HH:mm:ss") : "";
            this.tdCountUnit.Value = data.Unit;
            this.tdIsShowOnHome.Value = data.IsShowOnHome ? "1" : "0";
            this.tdProductSummary.Value = data.ProductSummary;
            this.tdXianShiSalePrice.Value = data.XianShiSalePrice > 0 ? data.XianShiSalePrice.ToString() : "";
            this.tdXianShiStartTime.Value = data.XianShiStartTime > DateTime.MinValue ? data.XianShiStartTime.ToString("yyyy-MM-dd HH:mm:ss") : "";
            this.tdXianShiEndTime.Value = data.XianShiEndTime > DateTime.MinValue ? data.XianShiEndTime.ToString("yyyy-MM-dd HH:mm:ss") : "";
            this.type = data.ProductTypeID;
            this.tdQuantityLimit.Value = data.QuantityLimit > 0 ? data.QuantityLimit.ToString() : "";
            this.tdSortOrder.Value = data.SortOrder > int.MinValue ? data.SortOrder.ToString() : "";
            this.tdIsSuggestion.Value = data.IsSuggestion ? "1" : "0";
            var tag_list = Foresight.DataAccess.Mall_Tag.GetMall_TagListByProductID(data.ID);
            if (tag_list.Length > 0)
            {
                List<int> IDList = tag_list.Select(p => p.ID).ToList();
                this.tdTagName.Value = string.Join(",", IDList.ToArray());
                this.hdTagName.Value = JsonConvert.SerializeObject(IDList);
            }
            this.tdIsYouXuan.Value = data.IsYouXuan ? "1" : "0";
            this.tdShipRateID.Value = data.ShipRateID > 0 ? data.ShipRateID.ToString() : "";
            this.tdIsAllowPointBuy.Value = data.IsAllowPointBuy ? "1" : "0";
            var productvariant = Foresight.DataAccess.Mall_Product_Variant.GetDefaultMall_Product_VarianByProductID(data.ID);
            if (productvariant != null)
            {
                this.tdTotalCount.Value = productvariant.Inventory > 0 ? productvariant.Inventory.ToString() : "0";

                this.tdBasicPrice.Value = productvariant.VariantBasicPrice > 0 ? productvariant.VariantBasicPrice.ToString("0.00") : "0.00";

                this.tdSalePrice.Value = productvariant.VariantPrice > 0 ? productvariant.VariantPrice.ToString("0.00") : "0.00";

                this.tdVariantPointPrice.Value = productvariant.VariantPointPrice > 0 ? productvariant.VariantPointPrice.ToString("0.00") : "0.00";
                this.tdVariantPoint.Value = productvariant.VariantPoint > 0 ? productvariant.VariantPoint.ToString() : "0";

                this.tdVariantVIPPrice.Value = productvariant.VariantVIPPrice > 0 ? productvariant.VariantVIPPrice.ToString("0.00") : "0.00";
                this.tdVariantVIPPoint.Value = productvariant.VariantVIPPoint > 0 ? productvariant.VariantVIPPoint.ToString() : "0";
                this.tdVariantStaffPrice.Value = productvariant.VariantStaffPrice > 0 ? productvariant.VariantStaffPrice.ToString("0.00") : "0.00";
                this.tdVariantStaffPoint.Value = productvariant.VariantStaffPoint > 0 ? productvariant.VariantStaffPoint.ToString() : "0";
            }
            this.tdIsAllowProductBuy.Value = data.IsAllowProductBuy ? "1" : "0";
            this.tdIsAllowPointBuy.Value = data.IsAllowPointBuy ? "1" : "0";
            this.tdIsAllowVIPBuy.Value = data.IsAllowVIPBuy ? "1" : "0";
            this.tdIsAllowStaffBuy.Value = data.IsAllowStaffBuy ? "1" : "0";

        }
    }
}