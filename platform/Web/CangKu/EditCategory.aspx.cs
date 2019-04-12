using Foresight.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.CangKu
{
    public partial class EditCategory : BasePage
    {
        public int ID;
        public int ParentID;
        protected void Page_Load(object sender, EventArgs e)
        {
            ID = 0;
            int.TryParse(Request.QueryString["ID"], out ID);
            if (ID > 0)
            {
                var data = Foresight.DataAccess.CKCategory.GetCKCategory(ID);
                if (data != null)
                {
                    SetInfo(data);
                    return;
                }
            }
            ParentID = 0;
            int.TryParse(Request.QueryString["ParentID"], out ParentID);
            if (ParentID > 0)
            {
                if (ParentID == 1)
                {
                    this.tdCategoryType.InnerHtml = "仓库";
                    this.hdCategoryType.Value = Utility.EnumModel.CKCategoryType.warehouse.ToString();
                    return;
                }
                var data = Foresight.DataAccess.CKCategory.GetCKCategory(ParentID);
                if (data != null)
                {
                    if (data.CategoryType.Equals(Utility.EnumModel.CKCategoryType.warehouse.ToString()))
                    {
                        this.tdCategoryType.InnerHtml = "仓库";
                        this.hdCategoryType.Value = Utility.EnumModel.CKCategoryType.category.ToString();
                    }
                    else
                    {
                        Response.Write("当前级别为物品类别,不能新增子级树");
                        Response.End();
                        return;
                    }
                    return;
                }
            }
        }
        private void SetInfo(Foresight.DataAccess.CKCategory data)
        {
            this.tdCategoryName.Value = data.CategoryName;
            this.tdRemark.Value = data.CategoryDesc;
            if (data.CategoryType.Equals(Utility.EnumModel.CKCategoryType.warehouse.ToString()))
            {
                this.tdCategoryType.InnerHtml = "仓库";
            }
            else if (data.CategoryType.Equals(Utility.EnumModel.CKCategoryType.category.ToString()))
            {
                this.tdCategoryType.InnerHtml = "仓库";
            }
        }
    }
}