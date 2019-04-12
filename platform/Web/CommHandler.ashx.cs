using ExcelProcess;
using Foresight.DataAccess.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.SessionState;
using Utility;

namespace Web
{
    /// <summary>
    /// CommHandler 的摘要说明
    /// </summary>
    public class CommHandler : IHttpHandler, IRequiresSessionState
    {
        public string FilePath = "site.txt";
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string visit = context.Request.Params["visit"];
            try
            {
                switch (visit.ToLower())
                {
                    case "getsites":
                        getsites(context);
                        break;
                    case "savesites":
                        savesites(context);
                        break;
                    case "deletesites":
                        deletesites(context);
                        break;
                    case "upgradecompany":
                        upgradecompany(context);
                        break;
                    case "updateweishu":
                        updateweishu(context);
                        break;
                    case "updateorder":
                        updateprojectorder(context);
                        break;
                    case "rechargeroomfee":
                        rechargeroomfee(context);
                        break;
                    case "updateallsiteweishu":
                        updateallsiteweishu(context);
                        break;
                    case "insertimportfeebyhistory":
                        insertimportfeebyhistory(context);
                        break;
                    case "updatehistoryfeechageid":
                        updatehistoryfeechageid(context);
                        break;
                    default:
                        WebUtil.WriteJson(context, new { status = false });
                        break;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("Web.CommHandler", "visit: " + visit, ex);
                WebUtil.WriteJson(context, new { status = false });
            }
        }
        private void updatehistoryfeechageid(HttpContext context)
        {
            HttpFileCollection uploadFiles = context.Request.Files;
            if (uploadFiles.Count == 0)
            {
                context.Response.Write("请选择一个文件");
                return;
            }
            if (string.IsNullOrEmpty(uploadFiles[0].FileName))
            {
                context.Response.Write("请选择一个文件");
                return;
            }
            HttpPostedFile postedFile = uploadFiles[0];
            string filepath = HttpContext.Current.Server.MapPath("~/upload/Temp/" + DateTime.Now.ToString("yyyyMMdd"));
            if (!System.IO.Directory.Exists(filepath))
            {
                System.IO.Directory.CreateDirectory(filepath);
            }
            string filename = DateTime.Now.ToLocalTime().ToString("yyyyMMddHHmmss") + "_" + postedFile.FileName;
            string fullpath = Path.Combine(filepath, filename);
            postedFile.SaveAs(fullpath);
            DataTable table = ExcelExportHelper.NPOIReadExcel(fullpath);

            var ChargeSummarys = Foresight.DataAccess.ChargeSummary.GetChargeSummaries().ToArray();
            int total = 0;
            for (int i = 0; i < table.Rows.Count; i++)
            {
                DataRow dr = table.Rows[i];
                string PrintNumber = dr["收款单号"].ToString();
                string ChargeName = dr["收费项目"].ToString();
                if (string.IsNullOrEmpty(PrintNumber) || string.IsNullOrEmpty(ChargeName))
                {
                    continue;
                }
                var my_chargesummary = ChargeSummarys.FirstOrDefault(p => p.Name.Equals(ChargeName));
                if (my_chargesummary == null)
                {
                    continue;
                }
                var history_data = Foresight.DataAccess.RoomFeeHistory.GetRoomFeeHistoryByPrintNumber(PrintNumber);
                if (history_data != null)
                {
                    history_data.ChargeID = my_chargesummary.ID;
                    history_data.Save();
                    total++;
                }
            }
            WebUtil.WriteJson(context, new { status = true, count = total });
        }
        private void insertimportfeebyhistory(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            if (ID <= 0)
            {
                WebUtil.WriteJson(context, "ID不合法");
                return;
            }
            int ChargeID = WebUtil.GetIntValue(context, "ChargeID");
            if (ChargeID <= 0)
            {
                WebUtil.WriteJson(context, "ChargeID不合法");
                return;
            }
            List<int> ProjectIDList = new List<int>();
            ProjectIDList.Add(ID);
            var list = Foresight.DataAccess.RoomFeeHistory.GetRoomFeeHistoryListByRoomIDList(new List<int>(), ChargeID: ChargeID, ProjectIDList: ProjectIDList, OnlyChargeFee: true);
            foreach (var item in list)
            {
                if (item.ImportFeeID > 0)
                {
                    Foresight.DataAccess.ImportFee.GetOrCreateImportFeeByID(item.ImportFeeID);
                }
            }
            WebUtil.WriteJson(context, "success");
        }
        private void updateallsiteweishu(HttpContext context)
        {
            var companys = Foresight.DataAccess.Company.GetAllActiveCompanyList();
            foreach (var item in companys)
            {
                var dic = new Dictionary<string, object>();
                dic["visit"] = "updateweishu";
                Utility.HttpRequestHelper.DoPostData<Dictionary<string, object>>(dic, "/CommHandler.ashx", apiurl: item.BaseURL);
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void rechargeroomfee(HttpContext context)
        {
            string tradeno = context.Request["tradeno"];
            if (string.IsNullOrEmpty(tradeno))
            {
                WebUtil.WriteJson(context, "参数为空");
                return;
            }
            var payment = Foresight.DataAccess.Payment.GetPaymentByTradeNo(tradeno);
            if (payment == null)
            {
                WebUtil.WriteJson(context, "payment不存在");
                return;
            }
            string remark = context.Request["remark"];
            string paytype = context.Request["paytype"];
            remark = string.IsNullOrEmpty(remark) ? "APP微信支付" : remark;
            paytype = string.IsNullOrEmpty(paytype) ? "微信支付" : paytype;
            Foresight.DataAccess.Payment.Insert_Payment(payment.Amount, payment.PaymentType, payment.TradeNo, payment.Status, payment.AddUser, payment.Remark, ResponseContent: payment.ResponseContent, payment: payment, CanSave: true, IsRoomFee: true);
            var history_count = Foresight.DataAccess.RoomFeeHistory.GetRoomFeeHistoryCountByTradeNo(tradeno, OrderID: payment.OrderID);
            if (history_count > 0)
            {
                WebUtil.WriteJson(context, "历史单据已存在");
                return;
            }
            var list = Foresight.DataAccess.RoomFee.GetRoomFeeListByTradeNo(tradeno, OrderID: payment.OrderID);
            if (list.Length == 0)
            {
                WebUtil.WriteJson(context, "待支付单据不存在");
                return;
            }
            string result = Web.APPCode.PaymentHelper.SaveRoomFee(tradeno, remark, paytype);
            WebUtil.WriteJson(context, result);
        }
        private void updateprojectorder(HttpContext context)
        {
            var url_list = Foresight.DataAccess.Company.GetAllActiveCompanyList().Where(p => !p.BaseURL.Contains("saasyy.com")).Select(o => o.BaseURL).ToList();
            string error_urls = string.Empty;
            foreach (var url in url_list)
            {
                string apiurl = url + "/Handler/ProjectHandler.ashx";
                try
                {
                    Foresight.Web.HttpRequest.Post(null, new Dictionary<string, string>() { { "visit", "saveprojectneworder" }, { "ProjectID", "1" }, { "SortOrder", "1" } }, apiurl: apiurl);
                }
                catch (Exception ex)
                {
                    error_urls += apiurl + ",";
                    Utility.LogHelper.WriteError("UpdateProjectOrder", url, ex);
                }
            }
            if (string.IsNullOrEmpty(error_urls))
            {
                WebUtil.WriteJson(context, "成功");
            }
            else
            {
                WebUtil.WriteJson(context, error_urls + "失败");
            }
        }
        private void updateweishu(HttpContext context)
        {
            var print_list = Foresight.DataAccess.PrintRoomFeeHistoryDetail.GetPrintRoomFeeHistoryDetailList().OrderBy(p => p.ID).ToArray();
            foreach (var print in print_list)
            {
                var printRoomFeeHistory = Foresight.DataAccess.PrintRoomFeeHistory.GetPrintRoomFeeHistory(print.ID);
                printRoomFeeHistory.Cost = print.HistoryCost;
                decimal finalweishu = Foresight.DataAccess.PrintRoomFeeHistory.GetRoomWeiShuBalance(print.ID, 0, print.ChargeTime);
                decimal ceil_historycost = Math.Ceiling(print.HistoryCost);
                if (ceil_historycost != print.RealCost && ceil_historycost != (print.RealCost - 1))
                {
                    printRoomFeeHistory.WeiShuMore = 0;
                    printRoomFeeHistory.WeiShuConsume = 0;
                    printRoomFeeHistory.WeiShuBalance = finalweishu;
                }
                else
                {

                    decimal weishumore = Math.Ceiling(print.HistoryCost) - print.HistoryCost;
                    if (finalweishu >= (1 - weishumore))
                    {
                        printRoomFeeHistory.WeiShuMore = 0;
                        printRoomFeeHistory.WeiShuConsume = (1 - weishumore);
                        printRoomFeeHistory.WeiShuBalance = finalweishu - (1 - weishumore);
                        printRoomFeeHistory.RealCost = (ceil_historycost - 1);
                    }
                    else
                    {
                        printRoomFeeHistory.WeiShuMore = weishumore;
                        printRoomFeeHistory.WeiShuConsume = 0;
                        printRoomFeeHistory.WeiShuBalance = finalweishu + weishumore;
                        printRoomFeeHistory.RealCost = ceil_historycost;
                    }
                }
                if (printRoomFeeHistory.RealMoneyCost2 >= printRoomFeeHistory.RealCost)
                {
                    printRoomFeeHistory.RealMoneyCost1 = 0;
                    printRoomFeeHistory.RealMoneyCost2 = printRoomFeeHistory.RealCost;
                }
                else if (printRoomFeeHistory.RealMoneyCost2 > 0)
                {
                    printRoomFeeHistory.RealMoneyCost1 = printRoomFeeHistory.RealCost - printRoomFeeHistory.RealMoneyCost2;
                }
                else
                {
                    printRoomFeeHistory.RealMoneyCost1 = printRoomFeeHistory.RealCost;
                }
                printRoomFeeHistory.Save();
            }
            WebUtil.WriteJson(context, new { status = true, IDList = print_list.Select(p => p.ID) });
        }
        private void upgrade_out_company_file(List<Foresight.DataAccess.Company> company_list, Foresight.DataAccess.SiteVersion site_version, out string error_sites, out List<Foresight.DataAccess.Company> company_list_out)
        {
            error_sites = string.Empty;
            company_list_out = new List<Foresight.DataAccess.Company>();
            var config = new Utility.SiteConfig();
            string base_url = config.SITE_URL;
            string SitePath = config.SitePath;
            var version_list = Foresight.DataAccess.SiteVersion.GetSiteVersions();
            int VersionCode = site_version.VersionCode;
            foreach (var company in company_list)
            {
                company.VersionCode = company.VersionCode > 0 ? company.VersionCode : 1;
                List<Utility.SiteVersionModel> site_version_model_list = new List<Utility.SiteVersionModel>();
                for (int i = company.VersionCode + 1; i <= VersionCode; i++)
                {
                    var current_version = version_list.FirstOrDefault(p => p.VersionCode == i);
                    if (current_version == null)
                    {
                        continue;
                    }
                    Utility.SiteVersionModel site_version_model = null;
                    string SqlPath = current_version.SqlPath;
                    if (!string.IsNullOrEmpty(SqlPath))
                    {
                        string extension = System.IO.Path.GetExtension(current_version.SqlPath).ToLower();
                        if (extension.ToLower().Contains("sql"))
                        {
                            if (site_version_model == null)
                            {
                                site_version_model = new Utility.SiteVersionModel();
                                site_version_model.VersionCode = current_version.VersionCode;
                            }
                            site_version_model.SqlPath = WebUtil.GetContextPath() + SqlPath;
                        }
                    }
                    string FilePath = current_version.FilePath;
                    if (!string.IsNullOrEmpty(FilePath))
                    {
                        string extension = System.IO.Path.GetExtension(FilePath).ToLower();
                        if (extension.ToLower().Contains("zip"))
                        {
                            if (site_version_model == null)
                            {
                                site_version_model = new Utility.SiteVersionModel();
                                site_version_model.VersionCode = current_version.VersionCode;
                            }
                            site_version_model.FilePath = WebUtil.GetContextPath() + FilePath;
                        }
                    }
                    if (site_version_model != null)
                    {
                        site_version_model_list.Add(site_version_model);
                    }
                }
                if (EncryptHelper.DoUpgradeSite(company, site_version_model_list, VersionCode, out error_sites))
                {
                    company_list_out.Add(company);
                }
            }
        }
        private void upgradecompany_file(List<Foresight.DataAccess.Company> company_list, Foresight.DataAccess.SiteVersion site_version, out string error_sql_sites, out string error_file_sites, out List<Foresight.DataAccess.Company> company_list_out)
        {
            error_sql_sites = string.Empty;
            error_file_sites = string.Empty;
            company_list_out = new List<Foresight.DataAccess.Company>();
            var config = new Utility.SiteConfig();
            string base_url = config.SITE_URL;
            string SitePath = config.SitePath;
            var version_list = Foresight.DataAccess.SiteVersion.GetSiteVersions().Where(p => p.VersionType.Equals("platform") || string.IsNullOrEmpty(p.VersionType)).OrderByDescending(p => p.VersionCode);
            foreach (var company in company_list)
            {
                if (!company.BaseURL.ToLower().StartsWith(base_url))
                {
                    continue;
                }
                string SiteName = company.BaseURL.Replace(base_url, "");
                company.VersionCode = company.VersionCode > 0 ? company.VersionCode : 1;
                string FilePath = string.Empty;
                for (int i = company.VersionCode + 1; i <= site_version.VersionCode; i++)
                {
                    var current_version = version_list.FirstOrDefault(p => p.VersionCode == i);
                    if (current_version == null)
                    {
                        continue;
                    }
                    string SqlPath = current_version.SqlPath;
                    if (!string.IsNullOrEmpty(SqlPath))
                    {
                        string extension = System.IO.Path.GetExtension(current_version.SqlPath).ToLower();
                        if (extension.ToLower().Contains("sql"))
                        {
                            try
                            {
                                string SQLFullPath = HttpContext.Current.Server.MapPath("~" + SqlPath);
                                string DatabaseName = "yy_" + SiteName;
                                Utility.SQLHelper.ExecuteSQLFile(SQLFullPath, DatabaseName);
                                if (!company_list_out.Select(p => p.CompanyID).ToList().Contains(company.CompanyID))
                                {
                                    company_list_out.Add(company);
                                }
                            }
                            catch (Exception ex)
                            {
                                error_sql_sites += company.CompanyName + ",";
                                LogHelper.WriteError("更新数据库失败", company.CompanyName, ex);
                            }
                        }
                    }
                    if (!string.IsNullOrEmpty(current_version.FilePath))
                    {
                        FilePath = current_version.FilePath;
                    }
                }
                if (!string.IsNullOrEmpty(FilePath))
                {
                    string extension = System.IO.Path.GetExtension(FilePath).ToLower();
                    if (extension.ToLower().Contains("zip"))
                    {
                        try
                        {
                            string FileFullPath = HttpContext.Current.Server.MapPath("~" + FilePath);
                            string SiteFullPath = SitePath + SiteName;
                            Utility.Tools.UnZipFile(FileFullPath, SiteFullPath, "");
                            if (!company_list_out.Select(p => p.CompanyID).ToList().Contains(company.CompanyID))
                            {
                                company_list_out.Add(company);
                            }
                        }
                        catch (Exception ex)
                        {
                            error_file_sites += company.CompanyName + ",";
                            LogHelper.WriteError("更新系统文件失败", company.CompanyName, ex);
                        }
                    }
                }
            }
        }
        private void upgradecompany(HttpContext context)
        {
            string VersionType = context.Request["VersionType"];
            if (VersionType.Equals("weixin"))
            {
                upgradeweixinsite(context);
                return;
            }
            int VersionID = WebUtil.GetIntValue(context, "VersionID");
            var site_version = Foresight.DataAccess.SiteVersion.GetSiteVersion(VersionID);
            if (site_version == null)
            {
                WebUtil.WriteJson(context, new { status = false, error = "升级版本号不合法" });
                return;
            }
            int VersionCode = site_version.VersionCode;
            string FilePath = site_version.FilePath;
            string SqlPath = site_version.SqlPath;
            string IDs = context.Request["IDList"];
            List<int> IDList = new List<int>();
            if (!string.IsNullOrEmpty(IDs))
            {
                IDList = JsonConvert.DeserializeObject<List<int>>(IDs);
            }
            if (IDList.Count == 0)
            {
                WebUtil.WriteJson(context, new { status = false, error = "公司为空" });
                return;
            }
            var companys = Foresight.DataAccess.Company.GetAllActiveCompanyList().Where(p => IDList.Contains(p.CompanyID)).ToArray();
            List<Foresight.DataAccess.Company> company_list = new List<Foresight.DataAccess.Company>();
            List<Foresight.DataAccess.Company> out_company_list = new List<Foresight.DataAccess.Company>();
            foreach (var company in companys)
            {
                company.VersionCode = company.VersionCode > 0 ? company.VersionCode : 1;
                if (company.VersionCode >= VersionCode)
                {
                    continue;
                }
                if (company.ServerLocation == 1)
                {
                    out_company_list.Add(company);
                }
                else
                {
                    company_list.Add(company);
                }
            }
            if (company_list.Count == 0 && out_company_list.Count == 0)
            {
                WebUtil.WriteJson(context, new { status = false, error = "所选公司当前版本号全部大于升级版本号" });
                return;
            }
            string error_sql_sites = string.Empty;
            string error_file_sites = string.Empty;
            string error_sites = string.Empty;
            if (company_list.Count > 0)
            {
                string in_error_sql_sites = string.Empty;
                string in_error_file_sites = string.Empty;
                List<Foresight.DataAccess.Company> company_list_out = new List<Foresight.DataAccess.Company>();
                upgradecompany_file(company_list, site_version, out in_error_sql_sites, out in_error_file_sites, out company_list_out);
                if (string.IsNullOrEmpty(error_sql_sites) && string.IsNullOrEmpty(error_file_sites))
                {
                    foreach (var company in company_list_out)
                    {
                        company.VersionCode = VersionCode;
                        company.Save();
                    }
                }
                error_sql_sites += in_error_sql_sites;
                error_file_sites += in_error_file_sites;
            }
            if (out_company_list.Count > 0)
            {
                string out_error_sql_sites = string.Empty;
                string out_error_file_sites = string.Empty;
                List<Foresight.DataAccess.Company> company_list_out = new List<Foresight.DataAccess.Company>();
                upgrade_out_company_file(out_company_list, site_version, out error_sites, out company_list_out);
                if (string.IsNullOrEmpty(out_error_sql_sites) && string.IsNullOrEmpty(out_error_file_sites))
                {
                    foreach (var company in company_list_out)
                    {
                        company.VersionCode = VersionCode;
                        company.Save();
                    }
                }
                foreach (var company in company_list_out)
                {
                    company.VersionCode = VersionCode;
                    company.Save();
                }
                error_sql_sites += out_error_sql_sites;
                error_file_sites += out_error_file_sites;
            }
            string error = string.Empty;
            if (!string.IsNullOrEmpty(error_sql_sites))
            {
                error += error_sql_sites + "更新数据库失败.";
            }
            if (!string.IsNullOrEmpty(error_file_sites))
            {
                error += error_file_sites + "更新系统代码失败";
            }
            if (!string.IsNullOrEmpty(error_sites))
            {
                error += error_sites;
            }
            if (!string.IsNullOrEmpty(error))
            {
                WebUtil.WriteJson(context, new { status = false, error = error });
                return;
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void upgradeweixinsite(HttpContext context)
        {
            string IDs = context.Request["IDList"];
            List<int> IDList = new List<int>();
            if (!string.IsNullOrEmpty(IDs))
            {
                IDList = JsonConvert.DeserializeObject<List<int>>(IDs);
            }
            if (IDList.Count == 0)
            {
                WebUtil.WriteJson(context, new { status = false, error = "公司为空" });
                return;
            }
            HttpPostedFile postedFile = context.Request.Files[0];
            string fileName = postedFile.FileName;
            if (fileName == "" || fileName == null)
            {
                WebUtil.WriteJson(context, new { status = false, error = "请上传文件" });
                return;
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
            var companys = Foresight.DataAccess.Company.GetAllActiveCompanyList().Where(p => IDList.Contains(p.CompanyID)).ToArray();
            var config = new Utility.SiteConfig();
            string SitePath = config.Wechat_SitePath;
            string SiteName = config.SiteName;
            foreach (var company in companys)
            {
                if (!company.BaseURL.Contains(config.SITE_URL))
                {
                    WebUtil.WriteJson(context, new { status = false, error = "功能不支持，请手动配置微信" });
                    return;
                }
                string NewFileName = company.BaseURL.Replace(config.SITE_URL, "");
                string VirName = NewFileName;
                string Sub_VirName = "html";
                if (NewFileName.StartsWith("http://"))
                {
                    NewFileName = "saas";
                    VirName = "html";
                    Sub_VirName = "";
                }
                int SiteNumber = int.Parse(config.SiteNumber);
                Utility.Tools.UnZipFile(ZipPath, SitePath, NewFileName);
                string my_sitepath = SitePath + NewFileName + @"\html";
                bool sitestatus = IISManager.CreateWebSite(SiteName, VirName, my_sitepath, false, 1, SiteNumber, "localhost", Sub_VirName);
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void deletesites(HttpContext context)
        {
            string content = context.Request.Params["content"];
            Write(content);
            context.Response.Write("成功");
        }
        private void savesites(HttpContext context)
        {
            string allcontent = context.Request.Params["allcontent"];
            Write(allcontent);
            List<FileModel> alllist = JsonConvert.DeserializeObject<List<FileModel>>(allcontent);
            string content = context.Request.Params["content"];
            List<FileModel> list = JsonConvert.DeserializeObject<List<FileModel>>(content);
            HttpPostedFile postedFile = context.Request.Files[0];
            string fileName = postedFile.FileName;
            if (fileName == "" || fileName == null)
            {
                context.Response.Write("成功");
                return;
            }
            if (list.Count == 0)
            {
                context.Response.Write("请选择需要更新的系统");
                return;
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
            if (extension.Contains("zip"))
            {
                try
                {
                    string error_sites = string.Empty;
                    foreach (var item in list)
                    {
                        try
                        {
                            Utility.Tools.UnZipFile(ZipPath, item.SitePath, "");
                            foreach (var allitem in alllist)
                            {
                                if (allitem.SiteName.Equals(item.SiteName))
                                {
                                    allitem.LastUpdateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            error_sites += item.SiteName + ",";
                            LogHelper.WriteError("更新代码失败", item.SiteName, ex);
                        }
                    }
                    string result = JsonConvert.SerializeObject(alllist);
                    Write(result);
                    if (string.IsNullOrEmpty(error_sites))
                    {
                        context.Response.Write("成功");
                    }
                    else
                    {
                        context.Response.Write(error_sites + "更新代码失败:");
                    }
                }
                catch (Exception)
                {
                    context.Response.Write("失败");
                }
            }
            else if (extension.Contains("sql"))
            {
                try
                {
                    string error_sites = string.Empty;
                    foreach (var item in list)
                    {
                        try
                        {
                            string[] DatabaseNameArray = item.SitePath.Split('\\');
                            string DatabaseName = "yy_" + DatabaseNameArray[DatabaseNameArray.Length - 1];
                            Utility.SQLHelper.ExecuteSQLFile(ZipPath, DatabaseName);
                        }
                        catch (Exception ex)
                        {
                            error_sites += item.SiteName + ",";
                            LogHelper.WriteError("更新数据库失败", item.SiteName, ex);
                        }
                    }
                    if (string.IsNullOrEmpty(error_sites))
                    {
                        context.Response.Write("成功");
                    }
                    else
                    {
                        context.Response.Write(error_sites + "更新数据库失败:");
                    }
                }
                catch (Exception ex)
                {
                    context.Response.Write("失败:" + ex.Message);
                }
            }
        }
        private void getsites(HttpContext context)
        {
            string content = Read();
            List<FileModel> list = new List<FileModel>();
            if (string.IsNullOrEmpty(content))
            {
                context.Response.Write("[]");
                return;
            }
            //list = JsonConvert.DeserializeObject<List<FileModel>>(content);
            context.Response.Write(content);
        }
        public string Read()
        {
            string fullpath = System.Web.HttpContext.Current.Server.MapPath(FilePath);
            if (!File.Exists(fullpath))
            {
                File.Create(fullpath).Close();
            }
            string text = System.IO.File.ReadAllText(fullpath);

            return text;
        }
        public void Write(string content)
        {
            string fullpath = System.Web.HttpContext.Current.Server.MapPath(FilePath);
            FileStream fs = new FileStream(fullpath, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            try
            {
                //开始写入
                sw.Write(content);
            }
            catch (Exception)
            {
            }
            finally
            {
                //清空缓冲区
                sw.Flush();
                //关闭流
                sw.Close();
                fs.Close();
            }
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
        public class FileModel
        {
            public string SiteName { get; set; }
            public string SitePath { get; set; }
            public string LastUpdateTime { get; set; }
        }
    }
}