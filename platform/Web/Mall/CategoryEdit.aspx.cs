using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utility;

namespace Web.Mall
{
    public partial class CategoryEdit : BasePage
    {
        public int CategoryID = 0;
        public int ParentID = 0;
        public int type = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["type"] != null)
            {
                int.TryParse(Request.QueryString["type"], out type);
            }
            if (Request.QueryString["ID"] != null)
            {
                int.TryParse(Request.QueryString["ID"], out CategoryID);
            }
            if (Request.QueryString["ParentID"] != null)
            {
                int.TryParse(Request.QueryString["ParentID"], out ParentID);
            }
            if (CategoryID > 0)
            {
                var data = Foresight.DataAccess.Mall_Category.GetMall_Category(CategoryID);
                SetInfo(data);
            }
            if (ParentID > 0)
            {
                var parent_category = Foresight.DataAccess.Mall_Category.GetMall_Category(ParentID);
                this.tdParentCategoryName.InnerHtml = parent_category != null ? parent_category.CategoryName : string.Empty;
            }
        }
        private void SetInfo(Foresight.DataAccess.Mall_Category data)
        {
            this.tdCategoryName.Value = data.CategoryName;
            this.tdSortOrder.Value = data.SortOrder > 0 ? data.SortOrder.ToString() : "";
            this.ParentID = data.ParentID;
            var tag_list = Foresight.DataAccess.Mall_Tag.GetMall_TagListByCategoryID(data.ID);
            if (tag_list.Length > 0)
            {
                List<int> IDList = tag_list.Select(p => p.ID).ToList();
                this.tdTagName.Value = string.Join(",", IDList.ToArray());
                this.hdTagName.Value = JsonConvert.SerializeObject(IDList);
            }
            this.tdIsDisabled.Value = data.IsDisabled ? "1" : "0";
            this.tdIsShowOnMallYouXuan.Value = data.IsShowOnMallYouXuan ? "1" : "0";
        }
    }
}