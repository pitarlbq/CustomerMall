using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Utility;

using System.IO;
using Foresight.DataAccess;
using Foresight.DataAccess.Framework;
using System.Web.SessionState;
using System.Data.SqlClient;
using System.Data;

namespace Web.Handler
{
    /// <summary>
    /// EncryptHandler 的摘要说明
    /// </summary>
    public class EncryptHandler : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string visit = context.Request.Params["visit"];
            if (string.IsNullOrEmpty(visit))
            {
                LogHelper.WriteDebug("AuthMgrHandler", "visit为空");
                context.Response.Write(null);
                return;
            }
            visit = visit.ToLower();
            try
            {
                switch (visit)
                {
                    case "checkcompany":
                        checkcompany(context);
                        break;
                    case "getusercount":
                        getusercount(context);
                        break;
                    case "registercompany":
                        registercompany(context);
                        break;
                    case "getcompanyinfo":
                        getcompanyinfo(context);
                        break;
                    case "savecompanyinfo":
                        savecompanyinfo(context);
                        break;
                    case "getsysmenulist":
                        getsysmenulist(context);
                        break;
                    case "saveappuser":
                        saveappuser(context);
                        break;
                    case "removeappuser":
                        removeappuser(context);
                        break;
                    default:
                        WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "Unkown Visit: " + visit);
                        break;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("EncryptHandler", "visit: " + visit, ex);
                context.Response.Write("{\"status\":false}");
            }
        }
        private void removeappuser(HttpContext context)
        {
            Foresight.DataAccess.Company company = null;
            if (!checkvalidcompany(context, out company))
            {
                var items = new { status = false, errormsg = "公司未登记" };
                WebUtil.WriteJson(context, items);
                return;
            }
            string UserIDs = context.Request["UserIDList"];
            List<int> UserIDList = new List<int>();
            if (!string.IsNullOrEmpty(UserIDs))
            {
                UserIDList = JsonConvert.DeserializeObject<List<int>>(UserIDs);
            }
            if (UserIDList.Count == 0)
            {
                WebUtil.WriteJson(context, new { status = true, errormsg = "OK" });
                return;
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    string cmdtext = "delete from [User] where [FromCompanyID]=@FromCompanyID and [FromUserID] in (" + string.Join(",", UserIDList.ToArray()) + ");";
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    parameters.Add(new SqlParameter("@FromCompanyID", company.CompanyID));
                    helper.Execute(cmdtext, CommandType.Text, parameters);
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    WebUtil.WriteJson(context, new { status = false, errormsg = "系统异常:" + ex.Message });
                    helper.Rollback();
                    return;
                }
            }
            WebUtil.WriteJson(context, new { status = true, errormsg = "OK" });
        }
        private void saveappuser(HttpContext context)
        {
            Foresight.DataAccess.Company company = null;
            if (!checkvalidcompany(context, out company))
            {
                var items = new { status = false, errormsg = "公司未登记" };
                WebUtil.WriteJson(context, items);
                return;
            }
            string LoginName = context.Request["LoginName"];
            string Password = context.Request["Password"];
            string UserType = context.Request["UserType"];
            UserType = string.IsNullOrEmpty(UserType) ? UserTypeDefine.APPUser.ToString() : UserType;
            int FromUserID = WebUtil.GetIntValue(context, "FromUserID");
            var user = Foresight.DataAccess.User.GetAPPUser(FromUserID, company.CompanyID);
            var exist_user = Foresight.DataAccess.User.GetUserByLoginName(LoginName, Foresight.DataAccess.UserTypeDefine.APPUser.ToString());
            if (exist_user != null)
            {
                if (user == null)
                {
                    WebUtil.WriteJson(context, new { status = false, errormsg = "用户名已存在" });
                    return;
                }
                if (user != null && exist_user.UserID != user.UserID)
                {
                    WebUtil.WriteJson(context, new { status = false, errormsg = "用户名已存在" });
                    return;
                }
            }
            if (user == null)
            {
                user = new Foresight.DataAccess.User();
                user.FromCompanyID = company.CompanyID;
                user.FromUserID = FromUserID;
                user.CreateTime = DateTime.Now;
                user.Type = UserType;
            }
            user.LoginName = LoginName;
            user.Password = Password;
            user.Save();
            var item = new { status = true, errormsg = "OK" };
            WebUtil.WriteJson(context, item);
        }
        private void getsysmenulist(HttpContext context)
        {
            Foresight.DataAccess.Company company = null;
            if (!checkvalidcompany(context, out company))
            {
                var items = new { status = false, errormsg = "公司未登记" };
                WebUtil.WriteJson(context, items);
                return;
            }
            var list = SysMenu.GetSysModulesByCompany(company.CompanyID);
            var item = new { status = true, errormsg = "OK", list = list };
            WebUtil.WriteJson(context, item);
        }
        private void savecompanyinfo(HttpContext context)
        {
            Foresight.DataAccess.Company company = null;
            if (!checkvalidcompany(context, out company))
            {
                var items = new { status = false, errormsg = "公司未登记" };
                WebUtil.WriteJson(context, items);
                return;
            }
            company.CompanyName = context.Request.Params["CompanyName"];
            company.PhoneNumber = context.Request.Params["PhoneNumber"];
            company.Address = context.Request.Params["Address"];
            company.CompanyDesc = context.Request.Params["CompanyDesc"];
            company.ChargePerson = context.Request.Params["ChargePerson"];
            company.Save();
            var item = new { status = true, errormsg = "OK" };
            WebUtil.WriteJson(context, item);
        }
        private void getcompanyinfo(HttpContext context)
        {
            Foresight.DataAccess.Company company = null;
            if (!checkvalidcompany(context, out company))
            {
                var items = new { status = false, errormsg = "公司未登记" };
                WebUtil.WriteJson(context, items);
                return;
            }
            if (!string.IsNullOrEmpty(company.Login_LogImg))
            {
                company.Login_LogImg = WebUtil.GetContextPath() + company.Login_LogImg;
            }
            if (!string.IsNullOrEmpty(company.Login_BodyImg))
            {
                company.Login_BodyImg = WebUtil.GetContextPath() + company.Login_BodyImg;
            }
            if (!string.IsNullOrEmpty(company.Home_LogoImg))
            {
                company.Home_LogoImg = WebUtil.GetContextPath() + company.Home_LogoImg;
            }
            bool ExpiringShow = company.ExpiringShow;
            DateTime ServerEndTime = company.ServerEndTime;
            int ExpiringDay = company.ExpiringDay > 0 ? company.ExpiringDay : 0;
            if (ExpiringShow && ServerEndTime > DateTime.MinValue)
            {
                if (ServerEndTime > DateTime.Now.AddDays(ExpiringDay))
                {
                    ExpiringShow = false;
                }
            }
            string ExpiringMsg = company.ExpiringMsg;
            if (string.IsNullOrEmpty(ExpiringMsg))
            {
                ExpiringMsg = "产品售后服务将于{到期日期}到期，到期后不影响产品正常使用。继续享受售后服务与技术支持，请您联系相关人员购买服务有效期";
            }
            ExpiringMsg = ExpiringMsg.Replace("{到期日期}", company.ServerEndTime.ToString("yyyy年MM月dd日"));
            var data_company = new { CompanyID = company.CompanyID, CompanyName = company.CompanyName, PhoneNumber = company.PhoneNumber, IsActive = company.IsActive, BaseURL = company.BaseURL, UserCount = company.UserCount, ServerStartTime = company.ServerStartTime, ServerEndTime = ServerEndTime, IsPay = company.IsPay, IsAdmin = company.IsAdmin, IsCustomer = company.IsCustomer, LocalURL = company.LocalURL, Login_LogImg = company.Login_LogImg, Login_BodyImg = company.Login_BodyImg, Home_LogoImg = company.Home_LogoImg, VersionCode = company.VersionCode, ProjectCount = company.ProjectCount >= 0 ? company.ProjectCount : int.MaxValue, IsHideLogin_LogImg = company.IsHideLogin_LogImg, IsHideLogin_BodyImg = company.IsHideLogin_BodyImg, IsHideHome_LogoImg = company.IsHideHome_LogoImg, CopyRightText = company.CopyRightText, IsHideCopyRightText = company.IsHideCopyRightText, ExpiringMsg = ExpiringMsg, ExpiringDay = ExpiringDay, ExpiringShow = ExpiringShow, SystemNo = company.SystemNumber };
            if (company.IsAdmin)
            {
                var items = new { status = true, errormsg = "OK", company = data_company };
                WebUtil.WriteJson(context, items);
                return;
            }
            if (!company.IsPay)
            {
                var items = new { status = false, errormsg = "公司已欠费", company = data_company };
                WebUtil.WriteJson(context, items);
                return;
            }
            var item = new { status = true, errormsg = "OK", company = data_company };
            WebUtil.WriteJson(context, item);
            return;
        }
        private void registercompany(HttpContext context)
        {
            Foresight.DataAccess.Company fromcompany = null;
            if (!checkvalidcompany(context, out fromcompany))
            {
                var items = new { status = false, errormsg = "公司未登记" };
                WebUtil.WriteJson(context, items);
                return;
            }
            if (fromcompany.CompanyID == 93)
            {
                var items = new { status = false, errormsg = "你已被禁止使用该功能" };
                WebUtil.WriteJson(context, items);
                return;
            }
            string CompanyName = context.Request.Params["CompanyName"];
            var company = Foresight.DataAccess.Company.GetCompanyByCompanyName(CompanyName);
            if (company != null)
            {
                var item = new { status = false, errormsg = "该公司已注册，请联系公司管理员分配帐号" };
                WebUtil.WriteJson(context, item);
                return;
            }
            string LoginName = context.Request.Params["LoginName"];
            var user = Foresight.DataAccess.User.GetUserByLoginName(LoginName);
            if (user != null)
            {
                var item = new { status = false, errormsg = "登录名已存在，请更换" };
                WebUtil.WriteJson(context, item);
                return;
            }

            string PhoneNumber = context.Request.Params["PhoneNumber"];
            company = new Company();
            company.CompanyName = CompanyName;
            company.AddTime = DateTime.Now;
            company.IsActive = false;
            company.Distributor = fromcompany.CompanyName;
            company.PhoneNumber = PhoneNumber;
            company.IsCustomer = true;
            company.IsPay = false;

            user = new Foresight.DataAccess.User();
            user.LoginName = LoginName;
            user.Password = Foresight.DataAccess.User.EncryptPassword(context.Request.Params["Password"]);
            user.Type = Foresight.DataAccess.UserTypeDefine.SystemUser.ToString();
            user.CreateTime = DateTime.Now;
            user.IsLocked = false;

            var usercompany = new Foresight.DataAccess.UserCompany();

            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    company.Save(helper);
                    user.Save(helper);
                    usercompany.UserID = user.UserID;
                    usercompany.CompanyID = company.CompanyID;
                    usercompany.Save(helper);
                    helper.Commit();
                    var items = new { status = true, errormsg = "注册成功，管理员审核中，请耐心等待" };
                    WebUtil.WriteJson(context, items);
                }
                catch (Exception ex)
                {
                    LogHelper.WriteError("EncryptHandler", "visit: registercompany", ex);
                    helper.Rollback();
                    var items = new { status = false, errormsg = "服务器内部异常，请稍候重试" };
                    WebUtil.WriteJson(context, items);
                    return;
                }
            }
        }
        private void getusercount(HttpContext context)
        {
            Foresight.DataAccess.Company company = null;
            if (!checkvalidcompany(context, out company))
            {
                var items = new { status = false, errormsg = "公司未登记" };
                WebUtil.WriteJson(context, items);
                return;
            }
            string total = company.UserCount <= 0 ? "0" : company.UserCount.ToString();
            if (company.IsAdmin)
            {
                total = int.MaxValue.ToString();
            }
            var item = new { status = true, errormsg = total };
            WebUtil.WriteJson(context, item);
            return;
        }
        private void checkcompany(HttpContext context)
        {
            Foresight.DataAccess.Company company = null;
            if (!checkvalidcompany(context, out company))
            {
                var items = new { status = false, errormsg = "公司未登记" };
                WebUtil.WriteJson(context, items);
                return;
            }
            if (company.IsAdmin)
            {
                var items = new { status = true, errormsg = "OK" };
                WebUtil.WriteJson(context, items);
                return;
            }
            if (!company.IsPay)
            {
                var items = new { status = false, errormsg = "当前公司未付费，禁止登陆" };
                WebUtil.WriteJson(context, items);
                return;
            }
            if (!company.IsActive)
            {
                var items = new { status = false, errormsg = "当前公司已禁用，禁止登陆" };
                WebUtil.WriteJson(context, items);
                return;
            }
            if (DateTime.Now < company.ServerStartTime || DateTime.Now > company.ServerEndTime)
            {
                var items = new { status = true, errormsg = "当前公司已超过使用期限，禁止登陆" };
                WebUtil.WriteJson(context, items);
                return;
            }
            var item = new { status = true, errormsg = "OK" };
            WebUtil.WriteJson(context, item);
            return;
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
        #region CommMethods
        private bool checkvalidcompany(HttpContext context, out Foresight.DataAccess.Company company)
        {
            string baseurl = EncryptHelper.GetURL(context);
            string signature = context.Request["signature"];
            string token = context.Request["token"];
            company = null;
            if (string.IsNullOrEmpty(baseurl) && string.IsNullOrEmpty(signature) && string.IsNullOrEmpty(token))
            {
                return false;
            }
            company = Foresight.DataAccess.Company.GetCompanyByURL(baseurl, signature: signature, token: token);
            if (company == null)
            {
                return false;
            }
            return true;
        }
        #endregion
    }
}