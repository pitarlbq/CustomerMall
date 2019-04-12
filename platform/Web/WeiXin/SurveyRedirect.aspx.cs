using Foresight.DataAccess;
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
    public partial class SurveyRedirect : WechatBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                int SurveyID = 0;
                int.TryParse(Request.QueryString["ID"], out SurveyID);
                int type = 0;
                int.TryParse(Request.QueryString["type"], out type);
                string CookieKey = WebUtil.GetOpenIDPrefix();
                string OpenID = this.Request.Cookies[CookieKey].Value;
                string activityHome = "/html/newweixin/service/dcwj.html";
                if (type == 2)
                {
                    activityHome = "/html/newweixin/service/shequvotedetail.html";
                }
                string file = Server.MapPath("~" + activityHome);
                if (System.IO.File.Exists(file))
                {
                    this.Response.Cookies.Add(new HttpCookie(CookieKey, OpenID));
                    this.Response.Redirect(WeixinHelper.ResolveClientUrl(activityHome + "?id=" + SurveyID + "&wxopenid=" + OpenID + "&t=" + DateTime.Now.Ticks), true);
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