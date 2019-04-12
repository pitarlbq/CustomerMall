using Foresight.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.CangKu
{
    public partial class EditInCategory : BasePage
    {
        public int ID = 0;
        public int IsSystemAdd = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            ID = 0;
            int.TryParse(Request.QueryString["ID"], out ID);
            if (ID > 0)
            {
                var data = Foresight.DataAccess.CKInCategory.GetCKInCategory(ID);
                if (data != null)
                {
                    SetInfo(data);
                    return;
                }
            }
        }
        private void SetInfo(Foresight.DataAccess.CKInCategory data)
        {
            this.tdInCategoryName.Value = data.InCategoryName;
            this.tdInCategoryDesc.Value = data.InCategoryDesc;
            this.tdCategoryType.Value = data.CategoryType;
            IsSystemAdd = data.IsSystemAdd ? 1 : 0;
            this.tdPrintLineCount.Value = data.PrintLineCount > 0 ? data.PrintLineCount.ToString() : "";
        }
    }
}