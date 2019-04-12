using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Foresight.DataAccess;
using System.Configuration;
using System.Text.RegularExpressions;
using System.IO;
using System.Collections;
using System.Text;
using System.Data;
using ExcelProcess;
using WeiXin;
using WeiXin.Request;
using WeiXin.Domain;

namespace Web
{
    public class WechatBasePage : System.Web.UI.Page
    {
        public static string mState = Utility.Tools.GetRandomString(8);
        public static string mCode = string.Empty;
        public static string mOpenID = string.Empty;
        override protected void OnInit(EventArgs e)
        {
            string code = Request.QueryString["code"];
            string OpenID = string.Empty;
            string CookieKey = WebUtil.GetOpenIDPrefix();
            string CookieHasRoomKey = WebUtil.GetHasRoomPrefix();
            if (HttpContext.Current.Request.Cookies[CookieKey] != null)
            {
                OpenID = HttpContext.Current.Request.Cookies[CookieKey].Value;
            }
            string state = Request.QueryString["state"];
            if (string.IsNullOrEmpty(OpenID))
            {
                if (string.IsNullOrEmpty(code))
                {
                    string BaseRequestURL = this.Request.Url.ToString();
                    this.Response.Redirect(APPCode.WeixinHelper.ResovleOauth2Url(BaseRequestURL, true, State: mState), true);
                    return;
                }
                if (mCode.Equals(code))
                {
                    OpenID = mOpenID;
                }
                else
                {
                    mCode = code;
                    OpenID = APPCode.WeixinHelper.GetOpenIDByCode(code);
                }
            }
            if (string.IsNullOrEmpty(OpenID))
            {
                Utility.LogHelper.WriteError(this.Request.Url.ToString(), "获取OpenID失败:" + Request.QueryString["code"], null);
                Response.Write("获取OpenID失败，请刷新后重试");
                Response.End();
                return;
            }
            mOpenID = OpenID;
            bool HasRoom = WechatUser_Project.CheckWechatUser_ProjectByOpenid(OpenID);
            if (HttpContext.Current.Request.Cookies[CookieKey] == null)
            {
                HttpContext.Current.Response.Cookies.Add(new HttpCookie(CookieKey, OpenID));
            }
            else
            {
                HttpContext.Current.Request.Cookies[CookieKey].Value = OpenID;
            }
            if (HttpContext.Current.Request.Cookies[CookieHasRoomKey] == null)
            {
                HttpContext.Current.Response.Cookies.Add(new HttpCookie(CookieHasRoomKey, (HasRoom ? "1" : "0")));
            }
            else
            {
                HttpContext.Current.Request.Cookies[CookieHasRoomKey].Value = (HasRoom ? "1" : "0");
            }
        }
    }
}