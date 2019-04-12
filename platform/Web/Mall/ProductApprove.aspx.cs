using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utility;

namespace Web.Mall
{
    public partial class ProductApprove : BasePage
    {
        public int ProductID = 0;
        public int Status = 0;
        public string op = string.Empty;
        public bool can_approve = false;
        public int type = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["type"] != null)
            {
                int.TryParse(Request.QueryString["type"], out type);
            }
            if (this.type == 1)
            {
                this.tdUnit.InnerHtml = "(元)";
                this.tdProductType.InnerHtml = "(购买商品)";
            }
            else if (this.type == 2)
            {
                this.tdUnit.InnerHtml = "(个)";
                this.tdProductType.InnerHtml = "(积分兑换商品)";
            }
            else if (this.type == 3)
            {
                this.tdUnit.InnerHtml = "(元)";
                this.tdProductType.InnerHtml = "(拼团商品)";
            }
            if (Request.QueryString["op"] != null)
            {
                op = Request.QueryString["op"];
            }
            if (Request.QueryString["ID"] != null)
            {
                int.TryParse(Request.QueryString["ID"], out ProductID);
            }
            Foresight.DataAccess.Mall_Product data = null;
            if (ProductID > 0)
            {
                data = Foresight.DataAccess.Mall_Product.GetMall_Product(ProductID);
            }
            if (data == null)
            {
                Response.End();
                return;
            }
            SetInfo(data);
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
            this.tdSalePrice.Value = data.SalePrice.ToString();
            this.tdModelNumber.Value = data.ModelNumber;
            this.tdStatus.Value = data.Status.ToString();
            this.hdDescription.Value = data.Description;
            this.Status = data.Status;
            this.tdIsZiYing.Value = data.IsZiYing ? "1" : "0";
            if (data.Status != 3)
            {
                this.tdApproveMan.Value = data.ApproveMan;
                this.tdApproveTime.Value = data.ApproveTime > DateTime.MinValue ? data.ApproveTime.ToString("yyyy-MM-dd HH:mm:ss") : string.Empty;
            }
            else
            {
                this.tdApproveMan.Value = WebUtil.GetUser(this.Context).RealName;
                this.tdApproveTime.Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            }
            if (data.Status == 3 || data.Status == 4)
            {
                this.can_approve = true;
            }
            if (op.Equals("view"))
            {
                this.can_approve = false;
            }
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
            var tag_list = Foresight.DataAccess.Mall_Tag.GetMall_TagListByProductID(data.ID);
            if (tag_list.Length > 0)
            {
                List<int> IDList = tag_list.Select(p => p.ID).ToList();
                this.tdTagName.Value = string.Join(",", IDList.ToArray());
                this.hdTagName.Value = JsonConvert.SerializeObject(IDList);
            }
            this.tdIsYouXuan.Value = data.IsYouXuan ? "1" : "0";
            this.tdShipRateID.Value = data.ShipRateID > 0 ? data.ShipRateID.ToString() : "";
        }
    }
}