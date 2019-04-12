using Foresight.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utility;

namespace Web.CangKu
{
    public partial class MaterialLingYongAnalysis : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var categoryList = Foresight.DataAccess.CKCategory.GetCKCategories();
            Foresight.DataAccess.CKCategory defaultCategory = new Foresight.DataAccess.CKCategory()
            {
                ID = 0,
                CategoryName = "全部",
            };
            categoryList.Insert(0, defaultCategory);
        }
    }
}