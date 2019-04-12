using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.SysSeting
{
    public partial class MainSetup : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int ParentID = 0;
            if (Request.QueryString["ParentID"] != null)
            {
                int.TryParse(Request.QueryString["ParentID"], out ParentID);
            }
            ParentID = ParentID <= 0 ? 203 : ParentID;
            var module = Foresight.DataAccess.SysMenu.GetSysMenu(ParentID);
            if (module == null)
            {
                Response.End();
                return;
            }
            var submenus = new Foresight.DataAccess.SysMenu[] { };
            if (!module.GroupName.Equals(Utility.EnumModel.SysMenuGroupNameDefine.wynk.ToString()) && !string.IsNullOrEmpty(module.GroupName))
            {
                submenus = Foresight.DataAccess.SysMenu.GetAllSysMenuList(module.ID);
            }
            else
            {
                submenus = Foresight.DataAccess.SysMenu.GetSysModulesForUserByUserId(WebUtil.GetUser(this.Context).UserID).Where(p => p.ParentID == ParentID).ToArray();
            }
            var items = submenus.Select(p =>
            {
                string CssClass = string.IsNullOrEmpty(p.CssClass) ? "sfsz" : p.CssClass;
                string NewUrl = GetContextPath() + "/main/subpage.aspx?ID=" + p.ID;
                return new { Title = p.Title, Url = NewUrl, CssClass = CssClass };
            });
            this.rptSummary.DataSource = items;
            this.rptSummary.DataBind();
        }
    }
}