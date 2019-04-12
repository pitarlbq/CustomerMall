using Foresight.DataAccess;
using Foresight.DataAccess.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using Utility;
using Web.APPCode;

namespace Web.Api
{
    /// <summary>
    /// DeviceApi 的摘要说明
    /// </summary>
    public class DeviceApi : IHttpHandler, IRequiresSessionState
    {
        const string LogModuel = "DeviceApi";
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string visit = context.Request.Params["visit"];
            if (string.IsNullOrEmpty(visit))
            {
                LogHelper.WriteDebug(LogModuel, "visit为空");
                WebUtil.WriteJson(context, new { status = false });
                return;
            }
            visit = visit.ToLower();
            try
            {
                switch (visit)
                {
                    case "getallurls"://获取所有url
                        getallurls(context);
                        break;
                    case "dotaskstart"://执行任务
                        dotaskstart(context);
                        break;
                    case "sendsystemmsg"://后台消息通知
                        sendsystemmsg(context);
                        break;
                    case "backupdatabase"://备份数据库
                        backupdatabase(context);
                        break;
                    case "shrinkdatabaselog"://收缩数据库
                        shrinkdatabaselog(context);
                        break;
                    case "removeerrorlog"://清除日志
                        removeerrorlog(context);
                        break;
                    default:
                        WebUtil.WriteJson(context, new { status = false });
                        break;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(LogModuel, "visit: " + visit, ex);
                WebUtil.WriteJson(context, new { status = false });
            }
        }
        private void removeerrorlog(HttpContext context)
        {
            string VirName = context.Request["VirName"];
            var config = new Utility.SiteConfig();
            if (string.IsNullOrEmpty(VirName))
            {
                WebUtil.WriteJson(context, new { status = false });
                return;
            }
            try
            {
                string sitelocation = context.Server.MapPath("~/Log");
                if (config.IsAdminSite)
                {
                    sitelocation = config.SitePath + VirName + @"\Log\";
                }
                Utility.Tools.DeleteFile(sitelocation, "log", keepday: 10);
                WebUtil.WriteJson(context, new { status = true });
            }
            catch (Exception)
            {
                WebUtil.WriteJson(context, new { status = false });
            }
        }
        private void dotaskstart(HttpContext context)
        {
            var company = Foresight.DataAccess.Company.GetCompanies().FirstOrDefault();
            string companyname = company != null ? company.CompanyName : "未知";
            //维保任务
            int repaircount = 0;
            try
            {
                repaircount = DeviceHelper.DoRepairTask();
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("DeviceApi", "DoRepairTask", ex);
            }
            //巡检任务
            int checkcount = 0;
            try
            {
                checkcount = DeviceHelper.DoCheckTask();
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("DeviceApi", "DoCheckTask", ex);
            }
            //发送模板消息
            int sendtempltemsgcount = 0;
            try
            {
                sendtempltemsgcount = sendnotifytemplatemsg();
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("DeviceApi", "sendtempltemsgcount", ex);
            }
            //设备维保任务通知
            int senddevicetaskcount = 0;
            try
            {
                senddevicetaskcount = sendjpushdevicetaskmsg(companyname);
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("DeviceApi", "sendjpushdevicetaskmsg", ex);
            }
            //物业账单催缴通知
            int sendnotifyfeecount = 0;
            try
            {
                sendnotifyfeecount = sendnotifyroomfeemsg();
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("DeviceApi", "sendnotifyroomfeemsg", ex);
            }
            var siteconfig = new SiteConfig();
            int sendtuantaskcount = 0;
            int sendxianshitaskcount = 0;
            int sendbirthdaycount = 0;
            int closemallordercount = 0;
            int completemallordercount = 0;
            int ratemallordercount = 0;
            int fixedpointcount = 0;
            int jixiaopointactivecount = 0;
            int sendactiveuserbalancecount = 0;
            int sendactiveuserpointcount = 0;
            int sendactiveusercouponcount = 0;
            int sendappuserordercount = 0;
            int grapappuserordecount = 0;
            int readygrapappuserordecount = 0;
            int failgrapappuserordecount = 0;
            if (siteconfig.IsMallOn)
            {
                //团购提前通知
                try
                {
                    sendtuantaskcount = sendmallproducttuanjpush(companyname);
                }
                catch (Exception ex)
                {
                    LogHelper.WriteError("DeviceApi", "sendmallproducttuanjpush", ex);
                }
                //限时购提前通知
                try
                {
                    sendxianshitaskcount = sendmallproductxianshijpush(companyname);
                }
                catch (Exception ex)
                {
                    LogHelper.WriteError("DeviceApi", "sendmallproductxianshijpush", ex);
                }
                //生日通知
                try
                {
                    sendbirthdaycount = sendmalluserbirthdaypush(companyname);
                }
                catch (Exception ex)
                {
                    LogHelper.WriteError("DeviceApi", "sendmalluserbirthdaypush", ex);
                }
                //关闭订单
                try
                {
                    closemallordercount = closemallorder();
                }
                catch (Exception ex)
                {
                    LogHelper.WriteError("DeviceApi", "closemallorder", ex);
                }
                //完成订单
                try
                {
                    completemallordercount = completemallordership();
                }
                catch (Exception ex)
                {
                    LogHelper.WriteError("DeviceApi", "completemallordership", ex);
                }
                //评论订单
                try
                {
                    ratemallordercount = ratemallorder();
                }
                catch (Exception ex)
                {
                    LogHelper.WriteError("DeviceApi", "ratemallorder", ex);
                }
                //固定积分生效
                try
                {
                    fixedpointcount = createuserfixedpoint();
                }
                catch (Exception ex)
                {
                    LogHelper.WriteError("DeviceApi", "createuserfixedpoint", ex);
                }
                //岗位积分发放
                //try
                //{
                //    jixiaopointactivecount = senduserjixiaopoint();
                //}
                //catch (Exception ex)
                //{
                //    LogHelper.WriteError("DeviceApi", "senduserjixiaopoint", ex);
                //}
                //账户余额生效
                try
                {
                    sendactiveuserbalancecount = sendactiveuserbalance();
                }
                catch (Exception ex)
                {
                    LogHelper.WriteError("DeviceApi", "sendactiveuserbalance", ex);
                }
                //积分余额生效
                try
                {
                    sendactiveuserpointcount = sendactiveuserpoint();
                }
                catch (Exception ex)
                {
                    LogHelper.WriteError("DeviceApi", "sendactiveuserpoint", ex);
                }
                //优惠券生效
                try
                {
                    sendactiveusercouponcount = sendactiveusercoupon();
                }
                catch (Exception ex)
                {
                    LogHelper.WriteError("DeviceApi", "sendactiveusercoupon", ex);
                }
                //派单通知
                try
                {
                    sendappuserordercount = dosendappuserorder(companyname);
                }
                catch (Exception ex)
                {
                    LogHelper.WriteError("DeviceApi", "dosendappuserorder", ex);
                }
                //付款单转待抢订单
                try
                {
                    readygrapappuserordecount = doreadygrapappuserorder(companyname);
                }
                catch (Exception ex)
                {
                    LogHelper.WriteError("DeviceApi", "doreadygrapappuserorder", ex);
                }
                //待抢订单转付款单
                try
                {
                    failgrapappuserordecount = dofailgrapappuserorder(companyname);
                }
                catch (Exception ex)
                {
                    LogHelper.WriteError("DeviceApi", "dofailgrapappuserorder", ex);
                }
                //抢单通知
                try
                {
                    grapappuserordecount = dograpappuserorder(companyname);
                }
                catch (Exception ex)
                {
                    LogHelper.WriteError("DeviceApi", "dograpappuserorder", ex);
                }
            }
            WebUtil.WriteJson(context, new { status = true, companyname = companyname, repaircount = repaircount, checkcount = checkcount, sendtempltemsgcount = sendtempltemsgcount, senddevicetaskcount = senddevicetaskcount, sendnotifyfeecount = sendnotifyfeecount, sendtuantaskcount = sendtuantaskcount, sendxianshitaskcount = sendxianshitaskcount, sendbirthdaycount = sendbirthdaycount, closemallordercount = closemallordercount, completemallordercount = completemallordercount, ratemallordercount = ratemallordercount, fixedpointcount = fixedpointcount, jixiaopointactivecount = jixiaopointactivecount, sendactiveuserbalancecount = sendactiveuserbalancecount, sendactiveuserpointcount = sendactiveuserpointcount, sendactiveusercouponcount = sendactiveusercouponcount, sendappuserordercount = sendappuserordercount, grapappuserordecount = grapappuserordecount });
        }
        private void sendsystemmsg(HttpContext context)
        {
            if (!checkAuth(context))
            {
                WebUtil.WriteJson(context, new { status = false });
                return;
            }
            int CompanyID = WebUtil.GetIntValue(context, "CompanyID");
            var msg_company_list = Foresight.DataAccess.SystemMsg_Company.GetSystemMsg_CompanyListByCompanyID(CompanyID);
            var company = Foresight.DataAccess.Company.GetCompany(CompanyID);
            #region 保存修改过的消息
            var read_list = msg_company_list.Where(p => p.IsReading).ToArray();
            var companyid_list = read_list.Select(p => p.CompanyID).ToList();
            var msgid_list = read_list.Select(p => p.SystemMsgID).ToList();
            var msg_list = Foresight.DataAccess.SystemMsg.GetSystemMsgs().ToArray();
            var sys_company_list = new List<SystemMsg_Company>();
            List<SystemMsgModel> request_list = new List<SystemMsgModel>();
            foreach (var msg in msg_list)
            {
                if (msg.DisableNotify)
                {
                    continue;
                }
                if (!msg.IsNotifyALL)
                {
                    var my_msg_company_list = msg_company_list.Where(p => p.SystemMsgID == msg.ID).ToArray();
                    if (!my_msg_company_list.Select(p => p.CompanyID).Contains(company.CompanyID))
                    {
                        continue;
                    }
                }
                var my_read_list = read_list.Where(p => p.SystemMsgID == msg.ID).ToArray();
                var my_read_company_idlist = my_read_list.Select(p => p.CompanyID).ToArray();
                if (my_read_company_idlist.Contains(company.CompanyID))
                {
                    continue;
                }
                var data = new SystemMsgModel
                {
                    ID = msg.ID,
                    Title = msg.Title,
                    ContentSummary = msg.ContentSummary,
                    SortOrder = msg.SortOrder,
                    IsTopShow = msg.IsTopShow,
                    AddTime = msg.AddTime
                };
                request_list.Add(data);
                var my_sys_company = msg_company_list.FirstOrDefault(p => p.SystemMsgID == msg.ID);
                if (my_sys_company == null)
                {
                    my_sys_company = new SystemMsg_Company();
                    my_sys_company.SystemMsgID = msg.ID;
                    my_sys_company.CompanyID = company.CompanyID;
                    my_sys_company.IsReading = false;
                    my_sys_company.AddTime = DateTime.Now;
                }
                sys_company_list.Add(my_sys_company);
            }
            if (request_list.Count > 0)
            {
                if (CommHelper.SaveSystemMsg(company.BaseURL, request_list.ToArray()))
                {
                    using (SqlHelper helper = new SqlHelper())
                    {
                        try
                        {
                            helper.BeginTransaction();
                            foreach (var my_msg in sys_company_list)
                            {
                                my_msg.IsReading = true;
                                my_msg.ReadingTime = DateTime.Now;
                                my_msg.Save(helper);
                            }
                            helper.Commit();
                        }
                        catch (Exception ex)
                        {
                            helper.Rollback();
                            LogHelper.WriteError("DeviceApi.ashx", "getallsystemmsgurls_save", ex);
                        }
                    }
                }
            }
            #endregion
            #region 删除消息
            var delete_msg_company_list = msg_company_list.Where(p => p.IsDeleting && p.DeleteTime == DateTime.MinValue).ToArray();
            if (delete_msg_company_list.Length > 0)
            {
                var company_idlist = delete_msg_company_list.Select(p => p.CompanyID).ToArray();
                if (company_idlist.Contains(company.CompanyID))
                {
                    var my_delete_msg_company_list = delete_msg_company_list.Where(p => p.CompanyID == company.CompanyID).ToArray();
                    if (CommHelper.DeleteSystemMsg(company.BaseURL, my_delete_msg_company_list.Select(p => p.SystemMsgID).ToArray()))
                    {
                        using (SqlHelper helper = new SqlHelper())
                        {
                            try
                            {
                                helper.BeginTransaction();
                                foreach (var my_msg in my_delete_msg_company_list)
                                {
                                    my_msg.DeleteTime = DateTime.Now;
                                    my_msg.Save(helper);
                                }
                                helper.Commit();
                            }
                            catch (Exception ex)
                            {
                                helper.Rollback();
                                LogHelper.WriteError("DeviceApi.ashx", "getallsystemmsgurls_delete", ex);
                            }
                        }
                    }
                }
            }
            #endregion
            WebUtil.WriteJson(context, new { status = true });
        }
        private void shrinkdatabaselog(HttpContext context)
        {
            string VirName = context.Request["VirName"];
            string dBName = context.Request["dBName"];
            string dBLogName = context.Request["dBLogName"];
            List<string> companyname_list = new List<string>() { VirName };
            var config = new Utility.SiteConfig();
            if (string.IsNullOrEmpty(dBName))
            {
                WebUtil.WriteJson(context, new { status = false });
                return;
            }
            dBLogName = string.IsNullOrEmpty(dBLogName) ? dBName + "_data_log" : dBLogName;
            string cmdText = "USE [master] GO";
            cmdText += "ALTER DATABASE {0} SET RECOVERY SIMPLE WITH NO_WAIT GO";
            cmdText += "ALTER DATABASE {0} SET RECOVERY SIMPLE GO";
            cmdText += "USE {0} GO";
            cmdText += "DBCC SHRINKFILE('{1}' , 11, TRUNCATEONLY) GO";
            cmdText += "ALTER DATABASE {0} SET RECOVERY FULL WITH NO_WAIT GO";
            cmdText += "USE [master] GO";
            cmdText += "ALTER DATABASE {0} SET RECOVERY FULL WITH NO_WAIT GO";
            cmdText += "ALTER DATABASE {0} SET RECOVERY FULL GO";
            cmdText = string.Format(cmdText, dBName, dBLogName);
            Utility.SQLHelper.ExecuteSql("master", cmdText);
            WebUtil.WriteJson(context, new { status = true, companynamelist = companyname_list });
        }
        private void backupdatabase(HttpContext context)
        {
            string VirName = context.Request["VirName"];
            string dBName = context.Request["dBName"];
            var config = new Utility.SiteConfig();
            List<string> companyname_list = new List<string>() { VirName };
            if (string.IsNullOrEmpty(dBName))
            {
                WebUtil.WriteJson(context, new { status = false });
                return;
            }
            string dblocation = config.BackupFileLocation + VirName + @"\backup\";
            try
            {
                if (!System.IO.Directory.Exists(dblocation))
                {
                    System.IO.Directory.CreateDirectory(dblocation);
                }
                else
                {
                    Utility.Tools.DeleteFile(dblocation, "bak", keepday: 0, keepcount: 3);
                }
            }
            catch (Exception)
            {
                WebUtil.WriteJson(context, new { status = false });
                return;
            }
            string saveAway = dblocation + DateTime.Now.ToString("yyyyMMddHHmmss") + ".bak";
            string cmdText = @"backup database " + dBName + " to disk='" + saveAway + "'";
            Utility.SQLHelper.ExecuteSql("master", cmdText);
            WebUtil.WriteJson(context, new { status = true, companynamelist = companyname_list });
        }
        private void getallurls(HttpContext context)
        {
            if (!checkAuth(context))
            {
                WebUtil.WriteJson(context, new { status = false });
                return;
            }
            string base_url = new Utility.SiteConfig().SITE_URL;
            var urls = Foresight.DataAccess.Company.GetAllActiveCompanyList().Select(o =>
            {
                string VirName = string.Empty;
                string DBName = string.Empty;
                if (o.BaseURL.Contains(base_url))
                {
                    VirName = o.BaseURL.Replace(base_url, "");
                    if (!string.IsNullOrEmpty(VirName))
                    {
                        DBName = "yy_" + VirName;
                    }
                }
                var item = new Utility.ServerCompanyModel() { CompanyID = o.CompanyID, ApiURL = o.FinalAPIURL, VirName = VirName, DBName = DBName };
                return item;
            }).ToList();
            WebUtil.WriteJson(context, new { status = true, urls = urls });
        }
        #region 任务方法集合
        private int dofailgrapappuserorder(string companyname)
        {
            var list = Mall_Order.GetFailGrapAPPMall_OrderList();
            return list.Length;
        }
        private int doreadygrapappuserorder(string companyname)
        {
            var list = Mall_Order.GetReadyGrapAPPMall_OrderList();
            return list.Length;
        }
        private int dograpappuserorder(string companyname)
        {
            var list = Mall_Order.GetUnGrapAPPMall_OrderList();
            if (list.Length == 0)
            {
                return 0;
            }
            foreach (var item in list)
            {
                Dictionary<string, object> extras = new Dictionary<string, object>();
                int ContentCode = 902;
                string ContentMsg = "有新订单来了，开始抢单";
                var extra_model = new Utility.JpushContent(ContentCode, Msg: ContentMsg, Type: "mallorder_sendapp");
                extras["code"] = extra_model.code;
                extras["msg"] = extra_model.msg;
                extras["type"] = extra_model.type;
                extras["id"] = item.ID;
                string result = JPush.JpushAPI.PushMessage(companyname, extras, msg_content: extra_model.msg, IsToAll: true);
                Foresight.DataAccess.JPushLog.Insert_JPushLog(null, null, extras, result, 13, item.ID, true, companyname);
            }
            return list.Length;
        }
        private int dosendappuserorder(string companyname)
        {
            var list = Mall_Order.GetUnSendAPPMall_OrderList();
            if (list.Length == 0)
            {
                return 0;
            }
            var app_orderuser_list = Mall_OrderAPPUser.GetMall_OrderAPPUsers().Where(p => list.Select(q => q.ID).ToList().Contains(p.OrderID));
            var user_list = Foresight.DataAccess.User.GetAPPUserList().Where(p => !string.IsNullOrEmpty(p.APPUserDeviceID)).ToArray();
            if (user_list.Length == 0)
            {
                return 0;
            }
            foreach (var item in list)
            {
                var my_orderuser_list = app_orderuser_list.Where(p => p.OrderID == item.ID).ToArray();
                List<int> UserIDList = my_orderuser_list.Select(p => p.UserID).ToList();
                var my_user_list = user_list.Where(p => !UserIDList.Contains(p.UserID)).ToArray();
                if (my_user_list.Length == 0)
                {
                    continue;
                }
                var android_users = my_user_list.Where(p => p.APPUserDeviceType.Equals("android")).ToArray();
                var ios_users = my_user_list.Where(p => p.APPUserDeviceType.Equals("ios")).ToArray();
                string[] android_cids = android_users.Select(p => p.APPUserDeviceID).ToArray();
                string[] ios_cids = ios_users.Select(p => p.APPUserDeviceID).ToArray();
                int[] MyUserIDList = my_user_list.Select(p => p.UserID).ToArray();
                Dictionary<string, object> extras = new Dictionary<string, object>();
                int ContentCode = 901;
                string ContentMsg = "您有新订单来了";
                var extra_model = new Utility.JpushContent(ContentCode, Msg: ContentMsg, Type: "mallorder_sendapp");
                extras["code"] = extra_model.code;
                extras["msg"] = extra_model.msg;
                extras["type"] = extra_model.type;
                extras["id"] = item.ID;
                string result = JPush.JpushAPI.PushMessage(companyname, extras, android_cids: android_cids, ios_cids: ios_cids, msg_content: extra_model.msg, IsToAll: false);
                Foresight.DataAccess.JPushLog.Insert_JPushLog(android_cids, ios_cids, extras, result, 12, item.ID, true, companyname, UserIDList: MyUserIDList);
                foreach (var my_orderuser in my_orderuser_list)
                {
                    Mall_OrderAPPUser.Save_Mall_OrderAPPUser(4, IsAPPSend: true, APPSendResult: result, data: my_orderuser, IsAPPShow: true);
                }
            }
            return list.Length;
        }
        private int sendactiveusercoupon()
        {
            var list = Mall_CouponUser.GetUnSentMall_CouponUserList();
            if (list.Length == 0)
            {
                return 0;
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    foreach (var item in list)
                    {
                        item.IsSent = true;
                        item.SentTime = DateTime.Now;
                        item.Save(helper);
                    }
                }
                catch (Exception)
                {
                    return 0;
                }
            }

            return list.Length;
        }
        private int sendactiveuserpoint()
        {
            var list = Mall_UserPoint.GetUnSentMall_UserPointList();
            if (list.Length == 0)
            {
                return 0;
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    foreach (var item in list)
                    {
                        item.PointStatus = 1;
                        item.IsSent = true;
                        item.SentTime = DateTime.Now;
                        item.Save(helper);
                    }
                }
                catch (Exception)
                {
                    return 0;
                }
            }

            return list.Length;
        }
        private int sendactiveuserbalance()
        {
            var list = Mall_UserBalance.GetUnSentMall_UserBalanceList();
            if (list.Length == 0)
            {
                return 0;
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    foreach (var item in list)
                    {
                        item.BalanceStatus = 1;
                        item.IsSent = true;
                        item.SentTime = DateTime.Now;
                        item.Save(helper);
                    }
                }
                catch (Exception)
                {
                    return 0;
                }
            }

            return list.Length;
        }
        private int createuserfixedpoint()
        {
            DateTime now = DateTime.Now;
            var config = SysConfig.GetSysConfigByName(SysConfigNameDefine.FixedPointActiveDay.ToString());
            int Activity_Day = 0;
            if (config != null)
            {
                int.TryParse(config.Value, out Activity_Day);
            }
            if (Activity_Day <= 0)
            {
                return 0;
            }
            int Current_Day = now.Day;
            if (Current_Day != Activity_Day)
            {
                return 0;
            }
            var user_list = Foresight.DataAccess.User.GetAPPCustomerUserListHavingFixedPoint(UserTypeDefine.APPUser.ToString());
            if (user_list.Length == 0)
            {
                return 0;
            }
            int Current_Month = now.Month;
            List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
            foreach (var item in user_list)
            {
                int user_month = item.FixedPointUpdateDate > DateTime.MinValue ? item.FixedPointUpdateDate.Month : (Current_Month - 1);
                for (int i = user_month; i < Current_Month; i++)
                {
                    var dic = new Dictionary<string, object>();
                    var data = new Mall_CheckRequest();
                    data.AddTime = DateTime.Now;
                    data.AddUserName = "System";
                    data.ApproveStatus = 3;
                    data.ConfirmStatus = 0;
                    data.ProcessStatus = 0;
                    data.RequestType = 2;
                    dic["Mall_CheckRequest"] = data;

                    var check_user = new Mall_CheckRequestUser();
                    check_user.UserID = item.UserID;
                    dic["Mall_CheckRequestUser"] = check_user;

                    DateTime FixedPointDateTime = new DateTime(DateTime.Now.Year, i + 1, Current_Day);
                    var request_rule = new Mall_CheckRequestRule();
                    request_rule.RuleID = 0;
                    request_rule.EarnType = 1;
                    request_rule.PointValue = item.FixedPoint;
                    request_rule.AddTime = DateTime.Now;
                    request_rule.Title = FixedPointDateTime.ToString("yyyy年MM月") + "固定积分";
                    request_rule.FixedPointMonth = i + 1;
                    request_rule.FixedPointDateTime = FixedPointDateTime;
                    dic["Mall_CheckRequestRule"] = request_rule;
                    list.Add(dic);
                }
            }
            if (list.Count == 0)
            {
                return 0;
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    foreach (var item in user_list)
                    {
                        item.FixedPointUpdateDate = now;
                        item.Save(helper);
                    }
                    foreach (var item in list)
                    {
                        var data = item["Mall_CheckRequest"] as Mall_CheckRequest;
                        data.Save(helper);

                        var check_user = item["Mall_CheckRequestUser"] as Mall_CheckRequestUser;
                        check_user.RequestID = data.ID;
                        check_user.Save(helper);

                        var request_rule = item["Mall_CheckRequestRule"] as Mall_CheckRequestRule;
                        request_rule.RequestID = data.ID;
                        request_rule.Save(helper);
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.WriteError(LogModuel, "createuserfixedpoint", ex);
                    return 0;
                }
            }
            return list.Count;
        }
        private int sendmalluserbirthdaypush(string companyname)
        {
            var config = SysConfig.GetSysConfigByName(SysConfigNameDefine.UserBirthdayBefore.ToString());
            if (config == null)
            {
                return 0;
            }
            var coupon_config = SysConfig.GetSysConfigByName(SysConfigNameDefine.UserBirthdayCoupon.ToString());
            if (config == null)
            {
                return 0;
            }
            double Days = 0;
            double.TryParse(config.Value, out Days);
            int CouponID = 0;
            int.TryParse(coupon_config.Value, out CouponID);
            if (CouponID <= 0)
            {
                return 0;
            }
            var list = Foresight.DataAccess.User.GetAPPCustomerUserList().Where(p => p.Birthday > DateTime.MinValue && p.Birthday < DateTime.Now.AddDays(Days) && p.Birthday > DateTime.Now && !string.IsNullOrEmpty(p.DeviceId)).ToArray();
            if (list.Length == 0)
            {
                return 0;
            }
            var my_coupon_list = Mall_CouponUser.GetMall_CouponUserListByUserID(Type: 2);
            List<int> UserIDList = my_coupon_list.Select(p => p.UserID).ToList();
            var my_list = list.Where(p => !UserIDList.Contains(p.UserID)).ToArray();
            if (my_list.Length == 0)
            {
                return 0;
            }
            var android_users = my_list.Where(p => p.DeviceType.Equals("android")).ToArray();
            var ios_users = my_list.Where(p => p.DeviceType.Equals("ios")).ToArray();
            string[] android_cids = android_users.Select(p => p.DeviceId).ToArray();
            string[] ios_cids = ios_users.Select(p => p.DeviceId).ToArray();
            int[] MyUserIDList = my_list.Select(p => p.UserID).ToArray();
            Dictionary<string, object> extras = new Dictionary<string, object>();
            int ContentCode = 501;
            string ContentMsg = "您的生日就要到了，请领取优惠券";
            var extra_model = new Utility.JpushContent(ContentCode, Msg: ContentMsg, Type: "mallbirthday_coupon");
            extras["code"] = extra_model.code;
            extras["msg"] = extra_model.msg;
            extras["type"] = extra_model.type;
            extras["id"] = CouponID;
            string result = JPush.JpushAPI.PushMessage(companyname, extras, android_cids: android_cids, ios_cids: ios_cids, msg_content: extra_model.msg, PushAPP: 2, IsToAll: false);
            Foresight.DataAccess.JPushLog.Insert_JPushLog(android_cids, ios_cids, extras, result, 8, CouponID, true, companyname, UserIDList: MyUserIDList);
            return 1;
        }
        private int sendmallproductxianshijpush(string companyname)
        {
            var config = SysConfig.GetSysConfigByName(SysConfigNameDefine.JPushXianShiNotify.ToString());
            if (config == null)
            {
                return 0;
            }
            double Hours = 0;
            double.TryParse(config.Value, out Hours);
            var list = Mall_Product.GetMall_Products().Where(p => p.ProductTypeID == 4 && p.Status == 10 && p.XianShiStartTime < DateTime.Now.AddHours(Hours) && p.XianShiStartTime > DateTime.Now).ToArray();
            if (list.Length == 0)
            {
                return 0;
            }
            var push_list = JPushLog.GetJPushLogListByRelatedID(0, 6, true);
            List<int> ProductIDList = push_list.Select(p => p.RelatedID).ToList();
            var my_list = list.Where(p => !ProductIDList.Contains(p.ID)).ToArray();
            if (my_list.Length == 0)
            {
                return 0;
            }
            var product = my_list[0];
            Dictionary<string, object> extras = new Dictionary<string, object>();
            int ContentCode = 401;
            string ContentMsg = "限时购商品" + product.ProductName + "即将开始";
            var extra_model = new Utility.JpushContent(ContentCode, Msg: ContentMsg, Type: "mallproduct_xianshi");
            extras["code"] = extra_model.code;
            extras["msg"] = extra_model.msg;
            extras["type"] = extra_model.type;
            extras["id"] = product.ID;
            string result = JPush.JpushAPI.PushMessage(companyname, extras, msg_content: extra_model.msg, PushAPP: 2, IsToAll: true);
            Foresight.DataAccess.JPushLog.Insert_JPushLog(null, null, extras, result, 6, product.ID, true, companyname);
            return 1;
        }
        private int sendmallproducttuanjpush(string companyname)
        {
            var config = SysConfig.GetSysConfigByName(SysConfigNameDefine.JPushTuanGouNotify.ToString());
            if (config == null)
            {
                return 0;
            }
            double Hours = 0;
            double.TryParse(config.Value, out Hours);
            var list = Mall_Product.GetMall_Products().Where(p => p.ProductTypeID == 3 && p.Status == 10 && p.PinStartTime < DateTime.Now.AddHours(Hours) && p.PinStartTime > DateTime.Now).ToArray();
            if (list.Length == 0)
            {
                return 0;
            }
            var push_list = JPushLog.GetJPushLogListByRelatedID(0, 7, true);
            List<int> ProductIDList = push_list.Select(p => p.RelatedID).ToList();
            var my_list = list.Where(p => !ProductIDList.Contains(p.ID)).ToArray();
            if (my_list.Length == 0)
            {
                return 0;
            }
            var product = my_list[0];
            Dictionary<string, object> extras = new Dictionary<string, object>();
            int ContentCode = 301;
            string ContentMsg = "团购商品" + product.ProductName + "即将开始";
            var extra_model = new Utility.JpushContent(ContentCode, Msg: ContentMsg, Type: "mallproduct_tuan");
            extras["code"] = extra_model.code;
            extras["msg"] = extra_model.msg;
            extras["type"] = extra_model.type;
            extras["id"] = product.ID;
            string result = JPush.JpushAPI.PushMessage(companyname, extras, msg_content: extra_model.msg, PushAPP: 2, IsToAll: true);
            Foresight.DataAccess.JPushLog.Insert_JPushLog(null, null, extras, result, 7, product.ID, true, companyname);
            return 1;
        }
        private int sendjpushdevicetaskmsg(string companyname)
        {
            var device_tasks = Foresight.DataAccess.Device_Task.GetDevice_Tasks().Where(p => p.TaskStatus == 1 && p.IsAPPShow && !p.IsAPPSend && p.TaskChargeManID > 0).ToArray();
            int sentcount = 0;

            var config = new Utility.SiteConfig();
            foreach (var device_task in device_tasks)
            {
                var user = Foresight.DataAccess.User.GetUser(device_task.TaskChargeManID);
                if (user != null && !string.IsNullOrEmpty(user.APPUserDeviceID) && !string.IsNullOrEmpty(config.JPushKey_User))
                {
                    Dictionary<string, object> extras = new Dictionary<string, object>();
                    var extra_model = new Utility.JpushContent(device_task.TaskStatus, Type: "devicetask");
                    extras["code"] = extra_model.code;
                    extras["msg"] = extra_model.msg;
                    extras["type"] = extra_model.type;
                    extras["id"] = device_task.ID;
                    extras["status"] = device_task.TaskStatus;
                    string[] android_cids = new string[] { user.APPUserDeviceID };
                    string device_type = string.IsNullOrEmpty(user.APPUserDeviceType) ? "all" : user.APPUserDeviceType;
                    string[] ios_cids = new string[] { user.APPUserDeviceID };
                    if (device_type.Equals("android"))
                    {
                        android_cids = new string[] { user.APPUserDeviceID };
                        ios_cids = new string[] { };
                    }
                    else if (device_type.Equals("ios"))
                    {
                        ios_cids = new string[] { user.APPUserDeviceID };
                        android_cids = new string[] { };
                    }
                    string result = JPush.JpushAPI.PushMessage(companyname, extras, android_cids, ios_cids, extra_model.msg);
                    device_task.IsAPPSend = true;
                    device_task.APPSendTime = DateTime.Now;
                    device_task.APPSendResult = result;
                    device_task.Save();
                    Foresight.DataAccess.JPushLog.Insert_JPushLog(android_cids, ios_cids, extras, result, 5, device_task.ID, true, companyname);
                    sentcount++;
                }
            }
            return sentcount;
        }
        private int ratemallorder()
        {
            var siteconfig = new SiteConfig();
            if (!siteconfig.IsMallOn)
            {
                return 0;
            }
            int waithour = 24;
            var config = Foresight.DataAccess.SysConfig.GetSysConfigByName(Foresight.DataAccess.SysConfigNameDefine.OrderAutoRate.ToString());
            if (config != null && !string.IsNullOrEmpty(config.Value))
            {
                int.TryParse(config.Value, out waithour);
            }
            waithour = waithour <= 0 ? 24 : waithour;
            var list = Foresight.DataAccess.Mall_Order.GetWaitingMall_OrderListByStatus(3, waithour);
            if (list.Length == 0)
            {
                return 0;
            }
            List<int> OrderIDList = list.Select(p => p.ID).ToList();
            var orderitem_list = Foresight.DataAccess.Mall_OrderItem.GetMall_OrderItemListByOrderIDList(OrderIDList);
            var commentlist = Foresight.DataAccess.Mall_OrderComment.GetMall_OrderCommentListByOrderIDList(OrderIDList);
            List<Foresight.DataAccess.Mall_OrderComment> ratelist = new List<Foresight.DataAccess.Mall_OrderComment>();
            foreach (var item in orderitem_list)
            {
                var order = list.FirstOrDefault(p => p.ID == item.OrderID);
                if (order == null)
                {
                    continue;
                }
                var data = commentlist.FirstOrDefault(p => p.OrderID == item.OrderID && p.ProductID == item.ProductID);
                if (data != null)
                {
                    continue;
                }
                data = new Foresight.DataAccess.Mall_OrderComment();
                data.OrderID = item.OrderID;
                data.UserID = order.UserID;
                data.RateStar = 5;
                data.AddTime = DateTime.Now;
                data.BusinessID = item.BusinessID;
                data.ProductID = item.ProductID;
                ratelist.Add(data);
            }
            if (ratelist.Count > 0)
            {
                using (SqlHelper helper = new SqlHelper())
                {
                    try
                    {
                        helper.BeginTransaction();
                        foreach (var item in ratelist)
                        {
                            item.Save(helper);
                        }
                        helper.Commit();
                    }
                    catch (Exception ex)
                    {
                        helper.Rollback();
                        LogHelper.WriteError(LogModuel, "ratemallorder", ex);
                        return 0;
                    }
                }
            }
            return ratelist.Count;
        }
        private int completemallordership()
        {
            var siteconfig = new SiteConfig();
            if (!siteconfig.IsMallOn)
            {
                return 0;
            }
            int waithour = 72;
            var config = Foresight.DataAccess.SysConfig.GetSysConfigByName(Foresight.DataAccess.SysConfigNameDefine.OrderAuoShipped.ToString());
            if (config != null && !string.IsNullOrEmpty(config.Value))
            {
                int.TryParse(config.Value, out waithour);
            }
            waithour = waithour <= 0 ? 72 : waithour;
            var list = Foresight.DataAccess.Mall_Order.GetWaitingMall_OrderListByStatus(2, waithour);
            foreach (var item in list)
            {
                item.OrderStatus = 3;
                item.CompleteTime = DateTime.Now;
                item.CompleteUserName = "System";
                item.Save();
            }
            return list.Length;
        }
        private int closemallorder()
        {
            var siteconfig = new SiteConfig();
            if (!siteconfig.IsMallOn)
            {
                return 0;
            }
            int waithour = 24;
            var config = Foresight.DataAccess.SysConfig.GetSysConfigByName(Foresight.DataAccess.SysConfigNameDefine.OrderCloseTime.ToString());
            if (config != null && !string.IsNullOrEmpty(config.Value))
            {
                int.TryParse(config.Value, out waithour);
            }
            waithour = waithour <= 0 ? 24 : waithour;
            var list = Foresight.DataAccess.Mall_Order.GetWaitingMall_OrderListByStatus(1, waithour);
            foreach (var item in list)
            {
                item.IsClosed = true;
                item.CloseTime = DateTime.Now;
                item.CloseUserName = "System";
                item.Save();
            }
            return list.Length;
        }
        private int sendnotifyroomfeemsg()
        {
            int sentcount = 0;
            string template_file_path = WebUtil.GetWechatTemplatePath(new Utility.SiteConfig().wyzdcjtz);
            if (string.IsNullOrEmpty(template_file_path))
            {
                return 0;
            }
            #region 发送物业账单催缴通知
            var feelist = Foresight.DataAccess.ViewRoomFee.GetViewRoomFeeListHavingOpenIDs().Where(p => p.TotalCost > 0).ToArray();
            if (feelist.Length == 0)
            {
                return 0;
            }
            var company = Foresight.DataAccess.Company.GetCompanies().FirstOrDefault();
            string companyname = company != null ? company.CompanyName : "未知";
            var notifyList = Wechat_RoomFeeNotify.GetWechat_RoomFeeNotifyByFeeIDList(feelist.Select(p => p.ID).ToArray());
            var RoomIDList = feelist.Select(p => p.RoomID).ToList();
            var wechatusers = Foresight.DataAccess.Wechat_User.GetWechat_UserList(null, RoomIDList).ToArray().Where(p => !string.IsNullOrEmpty(p.OpenId));
            var wechatuser_projects = Foresight.DataAccess.WechatUser_Project.GetWechatUser_ProjectListByRoomIDList(RoomIDList).ToArray();
            var dbNotifyList = new List<Wechat_RoomFeeNotify>();
            string DomainURL = PaymentConfig.WeiXinConfig.Oauth2Url;
            foreach (var user in wechatusers)
            {
                RoomIDList = wechatuser_projects.Where(p => p.OpenID.Equals(user.OpenId)).Select(p => p.ProjectID).ToList();
                if (RoomIDList.Count == 0)
                {
                    continue;
                }
                var myfeelist = feelist.Where(p => RoomIDList.Contains(p.RoomID)).ToArray();
                decimal total_cost = 0;
                string RoomOwnerName = string.Empty;
                string RoomName = string.Empty;
                foreach (var myfee in myfeelist)
                {
                    var myNotify = notifyList.FirstOrDefault(p =>
                    {
                        DateTime SendDate = DateTime.MinValue;
                        DateTime.TryParse(p.SendDate, out SendDate);
                        return p.FeeID == myfee.ID && SendDate >= myfee.WechatNotifyTime;
                    });
                    if (myNotify != null)
                    {
                        continue;
                    }
                    if (string.IsNullOrEmpty(RoomOwnerName))
                    {
                        RoomOwnerName = myfee.FinalCustomerName;
                    }
                    if (string.IsNullOrEmpty(RoomName))
                    {
                        RoomName = myfee.FullName + myfee.RoomName;
                    }
                    total_cost += myfee.TotalCost > 0 ? myfee.TotalCost : 0;
                }
                if (total_cost <= 0)
                {
                    continue;
                }
                var sendbackmessage = WeixinHelper.SendTemPlateMessage(template_file_path,
                     user.OpenId,
                     new List<string> 
                              { 
                                  "尊敬的【"+RoomOwnerName+"】，截止本月底您应缴账单明细如下：", 
                                  RoomName, 
                                  "￥"+total_cost.ToString(), 
                                  "点击详情查看明细和缴纳费用！"
                              }, DomainURL + "/Weixin/RoomFeeProcess.aspx");
                if (sendbackmessage.IsError)
                {
                    LogHelper.WriteError("物业账单催缴通知:sendnotifyroomfeemsg", sendbackmessage.Body, null);
                    continue;
                }
                foreach (var myfee in myfeelist)
                {
                    var wechat_RoomFeeNotify = new Foresight.DataAccess.Wechat_RoomFeeNotify();
                    wechat_RoomFeeNotify.FeeID = myfee.ID;
                    wechat_RoomFeeNotify.SendDate = myfee.WechatNotifyTime.ToString("yyyy-MM-dd");
                    wechat_RoomFeeNotify.AddTime = DateTime.Now;
                    dbNotifyList.Add(wechat_RoomFeeNotify);
                }
                sentcount++;
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    foreach (var item in dbNotifyList)
                    {
                        item.Save(helper);
                    }
                    helper.Commit();
                }
                catch (Exception)
                {
                    helper.Rollback();
                }
            }
            #endregion
            return sentcount;
        }
        private int sendnotifytemplatemsg()
        {
            string template_file_path = WebUtil.GetWechatTemplatePath(new Utility.SiteConfig().wygltz);
            if (string.IsNullOrEmpty(template_file_path))
            {
                return 0;
            }
            int sentcount = 0;
            var notifys = Foresight.DataAccess.Wechat_Msg.GetWechat_Msgs().Where(p =>
            {
                bool result = p.IsSending && p.IsWechatSend && p.IsShow && p.IsInvalidDesc.Equals("有效");
                return result;
            }).ToArray();
            if (notifys.Length == 0)
            {
                return 0;
            }
            foreach (var notify in notifys)
            {
                bool sentsuccess = false;
                string sendresult = string.Empty;
                var list = Foresight.DataAccess.Wechat_MsgProject.GetWechat_MsgProjectList(notify.ID);
                if (list.Length == 0)
                {
                    continue;
                }
                List<int> ProjectIDList = new List<int>();
                if (list.Length > 0)
                {
                    ProjectIDList = list.Select(p => p.ProjectID).ToList();
                }
                var wechatusers = Foresight.DataAccess.Wechat_User.GetWechat_UserList(ProjectIDList).ToArray();
                string DomainURL = PaymentConfig.WeiXinConfig.Oauth2Url;
                DomainURL = string.IsNullOrEmpty(DomainURL) ? WebUtil.GetContextPath() : DomainURL;
                foreach (var user in wechatusers)
                {
                    if (string.IsNullOrEmpty(user.OpenId))
                    {
                        continue;
                    }
                    var sendbackmessage = WeixinHelper.SendTemPlateMessage(template_file_path, user.OpenId, new List<string>
                        { 
                            string.IsNullOrEmpty(notify.MsgSummary)?notify.MsgTitle:notify.MsgSummary, 
                            notify.MsgTitle, 
                            DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                            notify.MsgContent,
                            "感谢您的使用！"
                        }, DomainURL + "/html/newweixin/service/tzgg.html?id=" + notify.ID + "&msgtype=tongzhi");
                    if (sendbackmessage.IsError)
                    {
                        LogHelper.WriteError("物业管理通知:sendnotifytemplatemsg", sendbackmessage.Body, null);
                    }
                    else
                    {
                        sentcount++;
                        sentsuccess = true;
                    }
                }
                if (sentsuccess)
                {
                    notify.IsSending = false;
                    notify.SendingMan = "System";
                    notify.MobileSendTime = DateTime.Now;
                    notify.MobileSendResult = string.Empty;
                    notify.Save();
                }
            }
            return sentcount;
        }
        #endregion
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
        public bool checkAuth(HttpContext context)
        {
            if (context.Request["key"].Equals("yy2016"))
            {
                return true;
            }
            return false;
        }
    }
}