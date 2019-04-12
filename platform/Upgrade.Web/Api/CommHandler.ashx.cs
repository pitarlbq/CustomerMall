using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using Utility;
using Web;

namespace Upgrade.Web.Api
{
    /// <summary>
    /// CommHandler 的摘要说明
    /// </summary>
    public class CommHandler : IHttpHandler
    {

        const string LogModuel = "CommHandler";
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
                    case "doupgradesite":
                        doupgradesite(context);
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
        private void doupgradesite(HttpContext context)
        {
            var files = context.Request.Files;
            bool sql_result = true;
            bool system_result = true;
            bool wechat_backend_result = true;
            bool wechat_front_result = true;
            for (int i = 0; i < context.Request.Files.Count; i++)
            {
                HttpPostedFile postedFile = context.Request.Files[i];
                string fileName = postedFile.FileName;
                if (fileName == "" || fileName == null)
                {
                    continue;
                }
                string extension = System.IO.Path.GetExtension(fileName).ToLower();
                fileName = DateTime.Now.ToFileTime().ToString() + extension;
                string filepath = "/upload/";
                string rootPath = HttpContext.Current.Server.MapPath("~" + filepath);
                if (!System.IO.Directory.Exists(rootPath))
                {
                    System.IO.Directory.CreateDirectory(rootPath);
                }
                string ZipPath = rootPath + fileName;
                postedFile.SaveAs(ZipPath);
                if (i == 0)
                {
                    sql_result = doupgradesql(context, ZipPath, rootPath);
                }
                if (i == 1)
                {
                    string SiteLocatoin = ConfigurationManager.AppSettings["SiteLocation"];
                    system_result = doupgradesystem(context, ZipPath, SiteLocatoin);
                }
                if (i == 2)
                {
                    string SiteLocatoin = ConfigurationManager.AppSettings["WechatPlatfromLocation"];
                    wechat_backend_result = doupgradesystem(context, ZipPath, SiteLocatoin);
                }
                if (i == 3)
                {
                    string SiteLocatoin = ConfigurationManager.AppSettings["WechatFrontLocation"];
                    wechat_front_result = doupgradesystem(context, ZipPath, SiteLocatoin);
                }
            }
            string error = string.Empty;
            if (sql_result && system_result && wechat_backend_result && wechat_front_result)
            {
                error = "更新成功";
            }
            if (!sql_result)
            {
                error += "更新数据库失败";
            }
            if (!system_result)
            {
                error += "更新后台系统代码失败";
            }
            if (!wechat_backend_result)
            {
                error += "更新微信后端代码失败";
            }
            if (!wechat_front_result)
            {
                error += "更新微信前端代码失败";
            }
            WebUtil.WriteJson(context, error);
        }
        private bool doupgradesystem(HttpContext context, string ZipPath, string SiteLocation)
        {
            Utility.Tools.UnZipFile(ZipPath, SiteLocation, "");
            return true;
        }
        private bool doupgradesql(HttpContext context, string ZipPath, string rootPath)
        {
            var config = new Utility.SiteConfig();
            string SiteName = config.SiteName;
            string NewFileName = DateTime.Now.ToString("yyyyMMddHHmmss");
            Utility.Tools.UnZipFile(ZipPath, rootPath, NewFileName);
            string DatabaseName = ConfigurationManager.AppSettings["DatabaseName"];
            string FullFilePath = rootPath + NewFileName;
            DirectoryInfo root = new DirectoryInfo(FullFilePath);
            foreach (FileInfo f in root.GetFiles().OrderBy(p => p.Name))
            {
                if (!f.Extension.ToLower().Contains("sql"))
                {
                    continue;
                }
                string SQLFullPath = FullFilePath + "\\" + f.Name;
                try
                {
                    Utility.SQLHelper.ExecuteSQLFile(SQLFullPath, DatabaseName);
                }
                catch (Exception ex)
                {
                    LogHelper.WriteError("更新数据库失败", "", ex);
                }
            }
            return true;
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}