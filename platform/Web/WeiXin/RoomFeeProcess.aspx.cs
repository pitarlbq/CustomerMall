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
    public partial class RoomFeeProcess : WechatBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string OpenID = this.Request.Cookies[WebUtil.GetOpenIDPrefix()].Value;
                var list = Project.GetProjectListByOpenid(OpenID);
                if (list.Length > 0)
                {
                    string activitypath = "/html/newweixin/service/fycj.html";
                    string file = Server.MapPath("~" + activitypath);
                    if (System.IO.File.Exists(file))
                    {
                        this.Response.Redirect(WeixinHelper.ResolveClientUrl(activitypath + "?t=" + DateTime.Now.Ticks), true);
                        return;
                    }
                    else
                    {
                        Response.Write("找不到相关页面");
                        this.Response.End();
                        return;
                    }
                }
                else
                {
                    this.Response.Redirect(WeixinHelper.ResovleOauth2Url("Weixin/RoomConnectRedirect.aspx", false), true);
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