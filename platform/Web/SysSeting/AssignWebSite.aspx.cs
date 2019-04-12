using Foresight.DataAccess.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using Utility;

namespace Web.SysSeting
{
    public partial class AssignWebSite : BasePage
    {
        public int SiteURLExist = 0;
        public int canEdit = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.CheckAuthByModuleCode("1101108"))
            {
                Response.Write("您没有权限查看此页面");
                Response.End();
                return;
            }
            if (!IsPostBack)
            {
                int CompanyID = WebUtil.GetIntByStr(Request.QueryString["CompanyID"]);
                var company = Foresight.DataAccess.Company.GetCompany(CompanyID);
                if (company == null)
                {
                    Response.End();
                    return;
                }
                canEdit = company.IsAdmin ? 0 : 1;
                this.tdServerLocation.Value = company.ServerLocation > 0 ? company.ServerLocation.ToString() : "0";
                if (!string.IsNullOrEmpty(company.BaseURL))
                {
                    SiteURLExist = 1;
                    this.tdSiteURL.Value = company.BaseURL;
                }
                if (this.tdServerLocation.Value.Equals("0") && canEdit == 1)
                {
                    this.tdSiteURL.Value = this.tdSiteURL.Value.Replace("http://te-cool.com:99/", "");
                }
            }
        }
        protected override void ProcessAjaxRequest(HttpContext context, string action)
        {
            switch (action)
            {
                case "savesite":
                    savesite(context);
                    break;
                default:
                    base.ProcessAjaxRequest(context, action);
                    break;
            }
        }
        private void savesite(HttpContext context)
        {
            try
            {
                var config = new Utility.SiteConfig();
                string VirName = context.Request.Params["sitename"];
                int CompanyID = int.Parse(context.Request.Params["CompanyID"]);
                int SiteNumber = int.Parse(config.SiteNumber);
                string SiteName = config.SiteName;
                string ZipPath = config.ZipPath;
                string SitePath = config.SitePath;
                int ServerLocation = WebUtil.GetIntValue(context, "ServerLocation");
                int VersionCode = 1;
                int.TryParse(config.SysVersionCode, out VersionCode);
                var company = Foresight.DataAccess.Company.GetCompany(CompanyID);
                if (company == null)
                {
                    WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "公司已删除");
                    return;
                }
                if (string.IsNullOrEmpty(VirName))
                {
                    WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "网址不能为空");
                    return;
                }
                company.ServerLocation = ServerLocation;
                if (company.ServerLocation == 1)
                {
                    if (!VirName.ToLower().StartsWith("http://") && !VirName.ToLower().StartsWith("https://"))
                    {
                        WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "网址输入不正确");
                        return;
                    }
                    company.BaseURL = VirName;
                    company.IsActive = true;
                    company.IsAdmin = false;
                    company.IsCustomer = true;
                    company.VersionCode = company.VersionCode > 0 ? company.VersionCode : VersionCode;
                    company.Save();
                    WebUtil.WriteJsonResult(context, "生成成功");
                    return;
                }
                if (!string.IsNullOrEmpty(company.BaseURL))
                {
                    WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "网址已分配");
                    return;
                }
                var URLList = Foresight.DataAccess.Company.GetCompanies().Select(p => p.BaseURL);
                if (URLList.Any(p => p.Contains(VirName)))
                {
                    WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "网站已存在");
                    return;
                }
                string SiteURL = config.SITE_URL + VirName;
                string DBName = "yy_" + VirName;
                try
                {
                    Utility.Tools.UnZipFile(ZipPath, SitePath, VirName);
                    bool sitestatus = IISManager.CreateWebSite(SiteName, VirName, SitePath + VirName, false, 1, SiteNumber, "localhost");
                    //if (!sitestatus)
                    //{
                    //    WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "网站已存在");
                    //    return;
                    //}
                    string ConfigPath = SitePath + VirName + @"\Web.config";
                    if (!System.IO.File.Exists(ConfigPath))
                    {
                        ConfigPath = SitePath + @"Web.config";
                    }
                    if (System.IO.File.Exists(ConfigPath))
                    {
                        Dictionary<string, object> dic = new Dictionary<string, object>();
                        dic["SITE_URL"] = SiteURL;
                        dic["CompanyName"] = company.CompanyName;
                        dic["CopyRight"] = DateTime.Now.Year.ToString() + " " + company.CompanyName;
                        dic["ConnString"] = config.ConnString + ";database=" + DBName;
                        Utility.IISManager.UpdateConfigValue(ConfigPath, dic);
                    }
                }
                catch (Exception)
                {
                }
                #region 生成数据库
                try
                {
                    Utility.SQLHelper.CreateDataBase(DBName, CompanyID);
                    company.BaseURL = SiteURL;
                    company.IsActive = true;
                    company.IsAdmin = false;
                    company.IsCustomer = true;
                    company.VersionCode = VersionCode;
                    company.Save();
                    string sqltext = @"insert into [" + DBName + "].[dbo].[Company]([CompanyName],[CompanyDesc],[PhoneNumber],[Address],[ChargePerson],[AddTime],[IsActive],[BaseURL],[VersionCode]) select [CompanyName],[CompanyDesc],[PhoneNumber],[Address],[ChargePerson],[AddTime],[IsActive],[BaseURL],[VersionCode] from [prosystem].[dbo].[Company] where CompanyID=" + company.CompanyID + ";";
                    Utility.SQLHelper.ExecuteSql("master", sqltext);
                    sqltext = @"insert into [" + DBName + "].[dbo].[User]([LoginName],[Password],[PhoneNumber],[Email],[HeadImg],[NickName],[RealName],[Gender],[Type],[CreateTime],[IsLocked],[LockTime]) select [LoginName],[Password],[PhoneNumber],[Email],[HeadImg],[NickName],[RealName],[Gender],[Type],[CreateTime],[IsLocked],[LockTime] from [prosystem].[dbo].[User] where UserID in (select UserID from [prosystem].[dbo].[UserCompany] where [CompanyID]=" + CompanyID + ");";
                    Utility.SQLHelper.ExecuteSql("master", sqltext);
                }
                catch (Exception)
                {
                }
                #endregion
                WebUtil.WriteJsonResult(context, "生成成功");
            }
            catch (Exception ex)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, ex);
            }
        }
    }
}