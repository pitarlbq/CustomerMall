using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.SetupFee
{
    public partial class SetupFeeSummary : BasePage
    {
        public string token = DateTime.Now.ToString("yyyyMMddHHmmss");
        public string DefaultSelectedTitle;
        protected void Page_Load(object sender, EventArgs e)
        {
            var list = Foresight.DataAccess.Category.GetCategories();
            var dic = new Dictionary<string, object>();
            var items = list.Select(p =>
            {
                var item = new { ID = p.ID, Name = p.Name };
                return item;
            }).ToList();
            var category_idlist = Foresight.DataAccess.Category.GetCategories().Select(p => p.ID).ToList();
            var summarys = Foresight.DataAccess.ChargeSummary.GetChargeSummaries().Where(p => !category_idlist.Contains(p.CategoryID)).ToArray();
            if (summarys.Length > 0)
            {
                items.Add(new { ID = 0, Name = "未分类" });
            }
            this.rptFee.DataSource = items;
            this.rptFee.DataBind();
            if (items.Count > 0)
            {
                DefaultSelectedTitle = items[0].Name.ToString();
            }
        }
    }
}