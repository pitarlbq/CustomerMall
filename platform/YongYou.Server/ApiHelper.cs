using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using Utility;

namespace YongYou.Server
{
    public class ApiHelper
    {
        public static string getKey()
        {
            return "yy2016";
        }
        public static void DoSendSystemMsg(int CompanyID)
        {
            try
            {
                HttpRequest.Post(null, new Dictionary<string, string>() { { "visit", "sendsystemmsg" }, { "key", getKey() }, { "CompanyID", CompanyID.ToString() } });
            }
            catch (Exception ex)
            {
                Utility.LogHelper.WriteError("ApiHelper", "DoSendTemplateMsg", ex);
            }
        }
        public static List<Utility.ServerCompanyModel> GetAllAPIUrl()
        {
            URLList response = null;
            List<Utility.ServerCompanyModel> results = new List<Utility.ServerCompanyModel>();
            bool OnlySelf = false;
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["OnlySelf"]))
            {
                bool.TryParse(ConfigurationManager.AppSettings["OnlySelf"], out OnlySelf);
            }
            if (OnlySelf)
            {
                var data = new Utility.ServerCompanyModel();
                data.ApiURL = ConfigurationManager.AppSettings["API_URL"];
                data.CompanyID = 1;
                data.DBName = ConfigurationManager.AppSettings["DBName"];
                data.VirName = ConfigurationManager.AppSettings["VirName"];
                data.DBLogName = ConfigurationManager.AppSettings["DBLogName"];
                results.Add(data);
                return results;
            }
            int i = 0;
            do
            {
                try
                {
                    i++;
                    string result = HttpRequest.Post(null, new Dictionary<string, string>() { { "visit", "getallurls" }, { "key", getKey() } });
                    response = JsonConvert.DeserializeObject<URLList>(result);
                }
                catch (Exception ex)
                {
                    Utility.LogHelper.WriteError("ApiHelper", "GetAllAPIUrl", ex);
                }
            } while ((response == null) && i <= 3);
            if (response != null && response.status)
            {
                results = response.urls;
            }
            return results;
        }
        public static bool DoDatabaseBackup(Utility.ServerCompanyModel company)
        {
            BackupResponse response = null;
            int i = 0;
            do
            {
                try
                {
                    i++;
                    string result = HttpRequest.Post(null, new Dictionary<string, string>() { { "visit", "backupdatabase" }, { "VirName", company.VirName }, { "dBName", company.DBName } });
                    response = JsonConvert.DeserializeObject<BackupResponse>(result);
                }
                catch (Exception ex)
                {
                    Utility.LogHelper.WriteError("ApiHelper", "DatabaseBackup", ex);
                }
            } while ((response == null) && i <= 3);
            if (response != null && response.status && response.companynamelist.Count > 0)
            {
                foreach (var companyname in response.companynamelist)
                {
                    string results = "公司: (" + companyname + ")成功备份了数据库";
                    LogHelper.WriteInfo("DoDatabaseBackup", "{0}", results);
                }
                return true;
            }
            return false;
        }
        public static bool DoShrinkDatabaseLog(Utility.ServerCompanyModel company)
        {
            BackupResponse response = null;
            int i = 0;
            do
            {
                try
                {
                    i++;
                    string result = HttpRequest.Post(null, new Dictionary<string, string>() { { "visit", "shrinkdatabaselog" }, { "VirName", company.VirName }, { "dBName", company.DBName }, { "dBLogName", company.DBLogName } });
                    response = JsonConvert.DeserializeObject<BackupResponse>(result);
                }
                catch (Exception ex)
                {
                    Utility.LogHelper.WriteError("ApiHelper", "DoShrinkDatabaseLog", ex);
                }
            } while ((response == null) && i <= 3);
            if (response != null && response.status && response.companynamelist.Count > 0)
            {
                foreach (var companyname in response.companynamelist)
                {
                    string results = "公司: (" + companyname + ")成功收缩了数据库日志";
                    LogHelper.WriteInfo("DoShrinkDatabaseLog", "{0}", results);
                }
                return true;
            }
            return false;
        }
        public static string DoALLTask(Utility.ServerCompanyModel company)
        {
            string apiurl = company.ApiURL + HttpRequest.getAPIParams();
            ALLTaskResponse response = null;
            int i = 0;
            do
            {
                try
                {
                    i++;
                    //string result = HttpRequest.Post(apiurl, null, new Dictionary<string, string>() { { "visit", "dotaskstart" } });
                    //response = JsonConvert.DeserializeObject<ALLTaskResponse>(result);
                    //response = Utility.HttpRequestHelper.DoPostData<ALLTaskResponse>(new Dictionary<string, object>() { { "visit", "dotaskstart" } }, HttpRequest.getAPIParams(), apiurl: company.ApiURL);
                    string result = HttpRequest.Post(apiurl, null, new Dictionary<string, string>() { { "visit", "dotaskstart" } });
                    response = JsonConvert.DeserializeObject<ALLTaskResponse>(result);
                }
                catch (Exception ex)
                {
                    Utility.LogHelper.WriteError("ApiHelper", "DoALLTask", ex);
                }
            } while ((response == null) && i <= 3);
            string results = string.Empty;
            if (response == null)
            {
                return results;
            }
            if (!response.status)
            {
                return results;
            }
            if (response.repaircount > 0)
            {
                results += "公司: (" + response.companyname + ")成功生成了(" + response.repaircount + ")条维保任务" + Environment.NewLine;
            }
            if (response.checkcount > 0)
            {
                results += "公司: (" + response.companyname + ")成功生成了(" + response.checkcount + ")条巡检任务" + Environment.NewLine;
            }
            if (response.sendtempltemsgcount > 0)
            {
                results += "公司: (" + response.companyname + ")成功发送了(" + response.sendtempltemsgcount + ")条微信系统通知" + Environment.NewLine;
            }
            if (response.senddevicetaskcount > 0)
            {
                results += "公司: (" + response.companyname + ")成功推送了(" + response.senddevicetaskcount + ")条设备维保任务通知" + Environment.NewLine;
            }
            if (response.sendnotifyfeecount > 0)
            {
                results += "公司: (" + response.companyname + ")成功发送了(" + response.sendnotifyfeecount + ")条微信物业账单催缴通知" + Environment.NewLine;
            }
            if (response.sendtuantaskcount > 0)
            {
                results += "公司: (" + response.companyname + ")成功发送了(" + response.sendtuantaskcount + ")条团购提前通知" + Environment.NewLine;
            }
            if (response.sendxianshitaskcount > 0)
            {
                results += "公司: (" + response.companyname + ")成功发送了(" + response.sendxianshitaskcount + ")条限时购提前通知" + Environment.NewLine;
            }
            if (response.sendbirthdaycount > 0)
            {
                results += "公司: (" + response.companyname + ")成功发送了(" + response.sendbirthdaycount + ")条生日通知" + Environment.NewLine;
            }
            if (response.closemallordercount > 0)
            {
                results += "公司: (" + response.companyname + ")成功自动关闭了(" + response.closemallordercount + ")条订单" + Environment.NewLine;
            }
            if (response.completemallordercount > 0)
            {
                results += "公司: (" + response.companyname + ")成功自动完成了(" + response.completemallordercount + ")条订单" + Environment.NewLine;
            }
            if (response.ratemallordercount > 0)
            {
                results += "公司: (" + response.companyname + ")成功自动评论了(" + response.ratemallordercount + ")条订单" + Environment.NewLine;
            }
            if (response.fixedpointcount > 0)
            {
                results += "公司: (" + response.companyname + ")成功生成了(" + response.fixedpointcount + ")条固定积分" + Environment.NewLine;
            }
            if (response.jixiaopointactivecount > 0)
            {
                results += "公司: (" + response.companyname + ")成功生效了(" + response.jixiaopointactivecount + ")条员工积分" + Environment.NewLine;
            }
            if (response.sendactiveuserbalancecount > 0)
            {
                results += "公司: (" + response.companyname + ")成功生效了(" + response.sendactiveuserbalancecount + ")条账户余额" + Environment.NewLine;
            }
            if (response.sendactiveuserpointcount > 0)
            {
                results += "公司: (" + response.companyname + ")成功生效了(" + response.sendactiveuserpointcount + ")条积分余额" + Environment.NewLine;
            }
            if (response.sendactiveusercouponcount > 0)
            {
                results += "公司: (" + response.companyname + ")成功生效了(" + response.sendactiveusercouponcount + ")个优惠券" + Environment.NewLine;
            }
            return results;
        }
        public static bool DoRemoveErrorLog(Utility.ServerCompanyModel company)
        {
            BaseResponse response = null;
            int i = 0;
            do
            {
                try
                {
                    i++;
                    string result = HttpRequest.Post(null, new Dictionary<string, string>() { { "visit", "removeerrorlog" }, { "VirName", company.VirName }, { "dBName", company.DBName } });
                    response = JsonConvert.DeserializeObject<BaseResponse>(result);
                }
                catch (Exception ex)
                {
                    Utility.LogHelper.WriteError("ApiHelper", "DoRemoveErrorLog", ex);
                }
            } while ((response == null) && i <= 3);
            if (response != null && response.status)
            {
                return true;
            }
            return false;
        }
    }
}
