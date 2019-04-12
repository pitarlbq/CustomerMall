using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using Utility;
using Web;

namespace Upgrade.Web.Api
{
    /// <summary>
    /// Api 的摘要说明
    /// </summary>
    public class Api : IHttpHandler
    {

        const string LogModuel = "UpgradeAPI";
        public void ProcessRequest(HttpContext context)
        {
            string action = context.Request.Params["action"];
            if (string.IsNullOrEmpty(action))
            {
                LogHelper.WriteDebug(LogModuel, "action为空");
                WebUtil.WriteJson(context, new { status = false });
                return;
            }
            action = action.ToLower();
            try
            {
                switch (action)
                {
                    case "doupgrade":
                        doupgrade(context);
                        break;
                    default:
                        WebUtil.WriteJson(context, new { status = false });
                        break;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(LogModuel, action, ex);
                WebUtil.WriteJson(context, new { status = false });
            }
        }
        private void doupgrade(HttpContext context)
        {
            int VersionCode = WebUtil.GetIntValue(context, "VersionCode");
            string versions = context.Request["versions"];
            List<SiteVersionModel> version_list = JsonConvert.DeserializeObject<List<SiteVersionModel>>(versions);
            var company = Foresight.DataAccess.Company.GetCompanies().FirstOrDefault();
            company.VersionCode = company.VersionCode > 0 ? company.VersionCode : 1;
            if (company.VersionCode >= VersionCode)
            {
                WebUtil.WriteJson(context, new { status = true });
                return;
            }
            string error_sql_sites = string.Empty;
            string error_file_sites = string.Empty;
            upgradecompany_file(company, version_list, VersionCode, out error_sql_sites, out error_file_sites);
            string error = string.Empty;
            if (!string.IsNullOrEmpty(error_sql_sites))
            {
                error += error_sql_sites + "更新数据库失败.";
            }
            if (!string.IsNullOrEmpty(error_file_sites))
            {
                error += error_file_sites + "更新系统代码失败";
            }
            if (!string.IsNullOrEmpty(error))
            {
                WebUtil.WriteJson(context, new { status = false, errormsg = error });
                return;
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private string DownloadFile(string url, string filetype)
        {
            string localPath = ConfigurationManager.AppSettings["UploadLocation"];
            localPath = localPath + DateTime.Now.ToString("yyyyMMdd");
            if (!Directory.Exists(localPath))
            {
                Directory.CreateDirectory(localPath);
            }
            localPath = localPath + "/" + DateTime.Now.ToString("yyyyMMddHHmmss") + filetype;
            WebClient myWebClient = new WebClient();
            myWebClient.DownloadFile(url, localPath);
            return localPath;
        }
        private void upgradecompany_file(Foresight.DataAccess.Company company, List<SiteVersionModel> version_list, int VersionCode, out string error_sql_sites, out string error_file_sites)
        {
            error_sql_sites = string.Empty;
            error_file_sites = string.Empty;
            string DatabaseName = ConfigurationManager.AppSettings["DatabaseName"];
            string SiteFullPath = ConfigurationManager.AppSettings["SiteLocation"];
            company.VersionCode = company.VersionCode > 0 ? company.VersionCode : 1;
            string FilePath = string.Empty;
            for (int i = company.VersionCode + 1; i <= VersionCode; i++)
            {
                var current_version = version_list.FirstOrDefault(p => p.VersionCode == i);
                if (current_version == null)
                {
                    continue;
                }
                string SqlPath = current_version.SqlPath;
                if (!string.IsNullOrEmpty(SqlPath))
                {
                    string SQLFullPath = DownloadFile(SqlPath, ".sql");
                    try
                    {
                        Utility.SQLHelper.ExecuteSQLFile(SQLFullPath, DatabaseName);
                    }
                    catch (Exception ex)
                    {
                        error_sql_sites += company.CompanyName + ",";
                        LogHelper.WriteError("更新数据库失败", company.CompanyName, ex);
                    }
                }
                if (!string.IsNullOrEmpty(current_version.FilePath))
                {
                    FilePath = current_version.FilePath;
                }
                if (string.IsNullOrEmpty(error_sql_sites) && string.IsNullOrEmpty(error_file_sites))
                {
                    company.VersionCode = current_version.VersionCode;
                    company.Save();
                }
            }
            if (!string.IsNullOrEmpty(FilePath))
            {
                string FileFullPath = DownloadFile(FilePath, ".zip");
                try
                {
                    Utility.Tools.UnZipFile(FileFullPath, SiteFullPath, "");
                }
                catch (Exception ex)
                {
                    error_file_sites += company.CompanyName + ",";
                    LogHelper.WriteError("更新系统文件失败", company.CompanyName, ex);
                }
            }
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

    }
    public class SiteVersionModel
    {
        public int VersionCode { get; set; }
        public string FilePath { get; set; }
        public string SqlPath { get; set; }
    }
}