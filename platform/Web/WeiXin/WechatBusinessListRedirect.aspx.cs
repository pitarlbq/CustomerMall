using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utility;
using Web.APPCode;

namespace Web.WeiXin
{
    public partial class WechatBusinessListRedirect : WechatBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string OpenID = string.Empty;
                string CookieKey = WebUtil.GetOpenIDPrefix();
                string activityHome = "/html/newweixin/service/businesslist.html";
                string file = Server.MapPath("~" + activityHome);
                if (System.IO.File.Exists(file))
                {
                    this.Response.Cookies.Add(new HttpCookie(CookieKey, OpenID));
                    this.Response.Redirect(WeixinHelper.ResolveClientUrl(activityHome + "?t=" + DateTime.Now.Ticks), true);
                    return;
                }
                else
                {
                    Response.Write("找不到相关页面");
                    this.Response.End();
                    return;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("WeiXin", this.Request.Url.ToString(), ex);
                Response.Write("请求已过期，请刷新后重试");
                return;
            }
        }
    }
}