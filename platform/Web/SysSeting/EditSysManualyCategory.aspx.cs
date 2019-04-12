using Foresight.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Web.SysSeting
{
    public partial class EditSysManualyCategory : BasePage
    {
        public int CategoryID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request.QueryString["CategoryID"], out CategoryID);
            if (CategoryID > 0)
            {
                var data = Foresight.DataAccess.SysManualCategory.GetSysManualCategory(CategoryID);
                if (data != null)
                {
                    SetInfo(data);
                    return;
                }
            }
        }
        private void SetInfo(Foresight.DataAccess.SysManualCategory data)
        {
            this.tdCategoryName.Value = data.CategoryName;
            this.tdSortBy.Value = data.SortBy > int.MinValue ? data.SortBy.ToString() : "";
            this.tdStatus.Value = data.Status > int.MinValue ? data.Status.ToString() : "1";
        }
    }
}