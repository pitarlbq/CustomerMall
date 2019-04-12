using Foresight.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.APPSetup
{
    public partial class CheckCategoryEdit : BasePage
    {
        public int CategoryID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request.QueryString["ID"], out CategoryID);
            if (CategoryID > 0)
            {
                var data = Foresight.DataAccess.Mall_CheckCategory.GetMall_CheckCategory(CategoryID);
                if (data != null)
                {
                    SetInfo(data);
                    return;
                }
            }
        }
        private void SetInfo(Foresight.DataAccess.Mall_CheckCategory data)
        {
            this.tdCategoryName.Value = data.CategoryName;
            this.tdCategoryType.Value = data.CategoryType > 0 ? data.CategoryType.ToString() : "";
        }
    }
}