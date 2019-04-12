using Foresight.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Wechat
{
    public partial class EditMsgCategory : BasePage
    {
        public int ID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request.QueryString["ID"], out ID);
            if (ID > 0)
            {
                var data = Foresight.DataAccess.Wechat_MsgCategory.GetWechat_MsgCategory(ID);
                if (data != null)
                {
                    SetInfo(data);
                    return;
                }
            }
        }
        private void SetInfo(Foresight.DataAccess.Wechat_MsgCategory data)
        {
            this.tdCategoryName.Value = data.CategoryName;
            this.tdSortOrder.Value = data.SortOrder > 0 ? data.SortOrder.ToString() : "";
        }
    }
}