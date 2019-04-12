using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Mall
{
    public partial class BusinessEdit : BasePage
    {
        public int BusinessID = 0;
        public bool IsMallBusinessOn = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                IsMallBusinessOn = new Utility.SiteConfig().IsMallBusinessOn;
                if (Request.QueryString["ID"] != null)
                {
                    int.TryParse(Request.QueryString["ID"], out BusinessID);
                }
                if (BusinessID > 0)
                {
                    var data = Foresight.DataAccess.Mall_Business.GetMall_Business(BusinessID);
                    SetInfo(data);
                }
            }
        }
        private void SetInfo(Foresight.DataAccess.Mall_Business data)
        {
            this.tdBusinessName.Value = data.BusinessName;
            this.tdBusinessAddress.Value = data.BusinessAddress;
            this.tdContactName.Value = data.ContactName;
            this.tdContactPhone.Value = data.ContactPhone;
            this.tdLicenseNumber.Value = data.LicenseNumber;
            var category_list = Foresight.DataAccess.Mall_Category.GetMall_CategoryListByBusinessID(data.ID);
            if (category_list.Length > 0)
            {
                int[] category_idlist = category_list.Select(p => p.ID).ToArray();
                this.tdCategoryName.Value = string.Join(",", category_idlist);
            }
            this.tdIsShowOnHome.Value = data.IsShowOnHome ? "1" : "0";
            this.tdIsSuggestion.Value = data.IsSuggestion ? "1" : "0";
            this.tdMapLocation.Value = data.MapLocation;
            this.tdSortOrder.Value = data.SortOrder > int.MinValue ? data.SortOrder.ToString() : "";
            this.tdShortAddress.Value = data.ShortAddress;
            this.tdIsTopShow.Value = data.IsTopShow ? "1" : "0";
            this.tdRemark.Value = data.Remark;
        }
    }
}