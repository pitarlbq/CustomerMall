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
    public partial class LotteryRedirect : WechatBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(Request.QueryString["ID"]))
                {
                    Response.Write("非法的请求");
                    this.Response.End();
                    return;
                }
                int activityID = Convert.ToInt32(Request.QueryString["ID"]);
                var activity = LotteryHelper.GetActivity(activityID);
                if (activity == null)
                {
                    Response.Write("活动已关闭");
                    this.Response.End();
                    return;
                }
                string CookieKey = WebUtil.GetOpenIDPrefix();
                string OpenID = this.Request.Cookies[CookieKey].Value;
                string activityid_key = string.IsNullOrEmpty(WebUtil.getApplicationPath()) ? "activity" : WebUtil.getApplicationPath() + "_activity";
                string activityHome = string.Empty;
                string file = string.Empty;
                if (activity.UserLimit)
                {
                    var joinuser = Foresight.DataAccess.Wechat_LotteryActivityUser.GetWechatLotteryActivityUserByOpenID(activity.ID, OpenID);
                    if (joinuser == null)
                    {
                        activityHome = "/html/newweixin/lottery/lotteryinfocollect.html";
                        file = Server.MapPath("~" + activityHome);
                        if (System.IO.File.Exists(file))
                        {
                            this.Response.Cookies.Add(new HttpCookie(CookieKey, OpenID));
                            this.Response.Cookies.Add(new HttpCookie(activityid_key, activity.ID.ToString()));
                            this.Response.Redirect(WeixinHelper.ResolveClientUrl(activityHome + "?t=" + DateTime.Now.Ticks), true);
                            return;
                        }
                        else
                        {
                            Response.Write("活动页面未创建");
                            this.Response.End();
                            return;
                        }
                    }
                }
                if (string.IsNullOrEmpty(activityHome))
                {
                    activityHome = string.Format("/html/newweixin/lottery/{0}/index.html", activity.ID.ToString());
                    file = Server.MapPath("~" + activityHome);
                    if (!System.IO.File.Exists(file))
                    {
                        activityHome = string.Format("/html/newweixin/lottery/{0}/index.html", activity.Type);
                        file = Server.MapPath("~" + activityHome);
                    }
                    if (!System.IO.File.Exists(file))
                    {
                        activityHome = string.Format("/html/newweixin/lottery/{0}/index.html", activity.Type);
                        if (activity.Type.Equals(Utility.EnumModel.LotteryTypeDefine.Goldenegg.ToString()))
                        {
                            activityHome = "/html/newweixin/lottery/lottery_zjd/index.html";
                        }
                        else if (activity.Type.Equals(Utility.EnumModel.LotteryTypeDefine.Shake.ToString()))
                        {
                            activityHome = "/html/newweixin/lottery/lottery_yly/index.html";
                        }
                        else if (activity.Type.Equals(Utility.EnumModel.LotteryTypeDefine.Shave.ToString()))
                        {
                            activityHome = "/html/newweixin/lottery/lottery_ggl/index.html";
                        }
                        else if (activity.Type.Equals(Utility.EnumModel.LotteryTypeDefine.Turntable.ToString()))
                        {
                            activityHome = "/html/newweixin/lottery/lottery_zp/index.html";
                        }
                        file = Server.MapPath("~" + activityHome);
                    }
                }
                this.Response.Clear();
                this.Response.Cookies.Add(new HttpCookie(CookieKey, OpenID));
                this.Response.Cookies.Add(new HttpCookie(activityid_key, activity.ID.ToString()));
                this.Response.Redirect(WeixinHelper.ResolveClientUrl(activityHome + "?t=" + DateTime.Now.Ticks), true);
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