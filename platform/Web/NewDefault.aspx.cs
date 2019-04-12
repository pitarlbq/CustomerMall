using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class NewDefault : BasePage
    {
        public string ServerEndTime = "已过期";
        public string SocketURL = string.Empty;
        public int show_appgl = 0;
        public int show_jygl = 0;
        public int show_jspt = 0;
        public int show_sjzx = 0;
        public int show_xtsz = 0;
        public string[] xtsz_list = new string[] { "1101261", "1101262", "1101263", "1101264", "1101265", "1101266", "1101296" };
        public string RealName = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RealName = WebUtil.GetUser(this.Context).RealName;
                var config = new Utility.SiteConfig();
                SocketURL = config.SocketURL;
                var company = WebUtil.GetCompany(this.Context);
                if (company != null)
                {
                    if (company.IsAdmin)
                    {
                        ServerEndTime = "永久";
                    }
                    else
                    {
                        ServerEndTime = company.ServerEndTime > DateTime.MinValue ? company.ServerEndTime.ToString("yyyy年MM月dd日") : "已过期";
                    }
                }
                var list = Foresight.DataAccess.SysMenu.GetSysMenuPageCodeList();
                string GroupName = Utility.EnumModel.SysMenuGroupNameDefine.appgl.ToString();
                string[] appgl_list = list.Where(p => p.GroupName.Equals(GroupName)).Select(p => p.ModuleCode).ToArray();

                 GroupName = Utility.EnumModel.SysMenuGroupNameDefine.jygl.ToString();
                 string[] jygl_list = list.Where(p => p.GroupName.Equals(GroupName)).Select(p => p.ModuleCode).ToArray();

                 GroupName = Utility.EnumModel.SysMenuGroupNameDefine.jspt.ToString();
                 string[] jspt_list = list.Where(p => p.GroupName.Equals(GroupName)).Select(p => p.ModuleCode).ToArray();

                 GroupName = Utility.EnumModel.SysMenuGroupNameDefine.sjzx.ToString();
                 string[] sjzx_list = list.Where(p => p.GroupName.Equals(GroupName)).Select(p => p.ModuleCode).ToArray();

                 GroupName = Utility.EnumModel.SysMenuGroupNameDefine.xtsz.ToString();
                 string[] xtsz_list = list.Where(p => p.GroupName.Equals(GroupName)).Select(p => p.ModuleCode).ToArray();
                this.show_appgl = base.CheckAuthByModuleCodeList(appgl_list) ? 1 : 0;
                this.show_jygl = base.CheckAuthByModuleCodeList(jygl_list) ? 1 : 0;
                this.show_jspt = base.CheckAuthByModuleCodeList(jspt_list) ? 1 : 0;
                this.show_sjzx = base.CheckAuthByModuleCodeList(sjzx_list) ? 1 : 0;
                this.show_xtsz = base.CheckAuthByModuleCodeList(xtsz_list) ? 1 : 0;
            }
        }
        protected override void ProcessAjaxRequest(HttpContext context, string action)
        {
            switch (action)
            {
                default:
                    base.ProcessAjaxRequest(context, action);
                    break;
            }
        }
    }
}