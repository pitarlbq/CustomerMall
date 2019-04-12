using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class Default : BasePage
    {
        public string ServerEndTime = "已过期";
        public string SocketURL = string.Empty;
        public string RealName = string.Empty;
        public int HasWechatServiceAuth = 0;
        public string LogoPath = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var config = new Utility.SiteConfig();
                SocketURL = config.SocketURL;
                RealName = WebUtil.GetUser(this.Context).RealName;
                HasWechatServiceAuth = base.CheckAuthByModuleCode("1191501") ? 1 : 0;
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
                LogoPath = "html/images/NewLogo.png";
                string LogoFullPath = HttpContext.Current.Server.MapPath("~/" + LogoPath);
                if (!System.IO.File.Exists(LogoFullPath))
                {
                    LogoPath = "/" + LogoPath;
                }
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