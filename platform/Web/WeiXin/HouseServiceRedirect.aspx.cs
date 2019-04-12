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
    public partial class HouseServiceRedirect : WechatBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string activitypath = "/html/newweixin/service/houseservicelist.html";
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
            catch (Exception ex)
            {
                LogHelper.WriteError("WeiXin", this.Request.Url.ToString(), ex);
                Response.Write("请求已过期，请刷新后重试");
                return;
            }
        }
    }
}