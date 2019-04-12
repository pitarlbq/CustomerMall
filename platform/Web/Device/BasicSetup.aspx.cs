using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Device
{
    public partial class BasicSetup : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var submenus = Foresight.DataAccess.SysMenu.GetSysModulesForUserByUserId(WebUtil.GetUser(this.Context).UserID).Where(p => p.ParentID == 117);
            var items = submenus.Select(p =>
            {
                //p.Url = p.Url.Replace("../", "/");
                string NewUrl = GetContextPath() + "/main/subpage.aspx?ID=" + p.ID;
                return new { Title = p.Title, Url = NewUrl, CssClass = p.CssClass, Description = p.Description };
            });
            this.rptSummary.DataSource = items;
            this.rptSummary.DataBind();
        }
    }
}