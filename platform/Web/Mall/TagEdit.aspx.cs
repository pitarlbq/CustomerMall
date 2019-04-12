using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Mall
{
    public partial class TagEdit : BasePage
    {
        public int TagID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["ID"] != null)
            {
                int.TryParse(Request.QueryString["ID"], out TagID);
            }
            if (TagID > 0)
            {
                var data = Foresight.DataAccess.Mall_Tag.GetMall_Tag(TagID);
                SetInfo(data);
            }
        }
        private void SetInfo(Foresight.DataAccess.Mall_Tag data)
        {
            this.tdTagName.Value = data.TagName;
            this.tdSortOrder.Value = data.SortOrder > 0 ? data.SortOrder.ToString() : "";
        }
    }
}