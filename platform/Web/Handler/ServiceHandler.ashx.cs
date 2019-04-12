using Foresight.DataAccess;
using Foresight.DataAccess.Framework;
using Foresight.DataAccess.Ui;

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.SessionState;
using Utility;
using Web.Model;

namespace Web.Handler
{
    /// <summary>
    /// ServiceHandler 的摘要说明
    /// </summary>
    public class ServiceHandler : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string visit = context.Request.Params["visit"];
            if (string.IsNullOrEmpty(visit))
            {
                LogHelper.WriteDebug("ServiceHandler", "visit为空");
                context.Response.Write(null);
                return;
            }
            visit = visit.ToLower();
            try
            {
                switch (visit)
                {
                    case "savecustomerservice":
                        savecustomerservice(context);
                        break;
                    case "getservicetype":
                        getservicetype(context);
                        break;
                    case "getroominfo":
                        getroominfo(context);
                        break;
                    case "loadservicelist":
                        loadservicelist(context);
                        break;
                    case "savechuli":
                        savechuli(context);
                        break;
                    case "savehuifang":
                        savehuifang(context);
                        break;
                    case "savebanjie":
                        savebanjie(context);
                        break;
                    case "removeservice":
                        removeservice(context);
                        break;
                    case "deletefile":
                        deletefile(context);
                        break;
                    case "loaduserlist":
                        loaduserlist(context);
                        break;
                    case "loadstaticcolumn":
                        loadstaticcolumn(context);
                        break;
                    case "loadstaticlist":
                        loadstaticlist(context);
                        break;
                    case "loadserviceattachs":
                        loadserviceattachs(context);
                        break;
                    case "loadservicetype":
                        loadservicetype(context);
                        break;
                    case "saveservicetype":
                        saveservicetype(context);
                        break;
                    case "deleteservicetype":
                        deleteservicetype(context);
                        break;
                    case "loadpaysummary":
                        loadpaysummary(context);
                        break;
                    case "getpaytype":
                        getpaytype(context);
                        break;
                    case "savepayservice":
                        savepayservice(context);
                        break;
                    case "loadpaysummarygrid":
                        loadpaysummarygrid(context);
                        break;
                    case "removepaysummary":
                        removepaysummary(context);
                        break;
                    case "savepaysummary":
                        savepaysummary(context);
                        break;
                    case "loadpayservicegrid":
                        loadpayservicegrid(context);
                        break;
                    case "removepayservice":
                        removepayservice(context);
                        break;
                    case "removeservicematerial":
                        removeservicematerial(context);
                        break;
                    case "saveservicematerial":
                        saveservicematerial(context);
                        break;
                    case "cancelservice":
                        cancelservice(context);
                        break;
                    case "loadservicemateriallist":
                        loadservicemateriallist(context);
                        break;
                    case "completeservice":
                        completeservice(context);
                        break;
                    case "resendjpush":
                        resendjpush(context);
                        break;
                    case "getservicetaskparams":
                        getservicetaskparams(context);
                        break;
                    case "deletecomboboxservicetask":
                        deletecomboboxservicetask(context);
                        break;
                    case "savecomboboxservicetask":
                        savecomboboxservicetask(context);
                        break;
                    case "savewechatservice":
                        savewechatservice(context);
                        break;
                    case "getservicemgrparams":
                        getservicemgrparams(context);
                        break;
                    case "getpayserviceanalysicolumns":
                        getpayserviceanalysicolumns(context);
                        break;
                    case "loadpayserviceanalysis":
                        loadpayserviceanalysis(context);
                        break;
                    case "approvepayservice":
                        approvepayservice(context);
                        break;
                    case "getacceptuserlistbydepartmentid":
                        getacceptuserlistbydepartmentid(context);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                Utility.LogHelper.WriteError("ServiceHandler", "命令:" + visit, ex);
                WebUtil.WriteJson(context, new { status = false });
            }
        }
        private void getacceptuserlistbydepartmentid(HttpContext context)
        {
            int DepartmentID = WebUtil.GetIntValue(context, "DepartmentID");
            var userlist = Foresight.DataAccess.User.GetAPPUserList(DepartmentID: DepartmentID);
            var items = userlist.Select(p =>
            {
                var item = new { UserID = p.UserID, RealName = p.FinalRealName };
                return item;
            }).ToList();
            WebUtil.WriteJson(context, new { status = true, users = items });
        }
        private void approvepayservice(HttpContext context)
        {
            string ids = context.Request.Params["IDList"];
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(ids);
            int status = WebUtil.GetIntValue(context, "status");
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    string cmdtext = "update [PayService] set Status=@status where ID in (" + string.Join(",", IDList.ToArray()) + ")";
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    parameters.Add(new SqlParameter("@status", status));
                    helper.Execute(cmdtext, CommandType.Text, parameters);
                    helper.Commit();
                    context.Response.Write("{\"status\":true}");
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    Utility.LogHelper.WriteError("ServiceHandler", "命令: approvepayservice", ex);
                    context.Response.Write("{\"status\":false}");
                }
            }
        }
        private void loadpayserviceanalysis(HttpContext context)
        {

            string RoomIDs = context.Request.Params["RoomIDs"];
            List<int> RoomIDList = new List<int>();
            if (!string.IsNullOrEmpty(RoomIDs))
            {
                RoomIDList = JsonConvert.DeserializeObject<List<int>>(RoomIDs);
            }
            string ProjectIDs = context.Request.Params["ProjectIDs"];
            List<int> ProjectIDList = new List<int>();
            if (RoomIDList.Count == 0)
            {
                if (!string.IsNullOrEmpty(ProjectIDs))
                {
                    ProjectIDList = JsonConvert.DeserializeObject<List<int>>(ProjectIDs).Where(p => p != 1).ToList();
                }
                ProjectIDList = WebUtil.GetMyProjects(WebUtil.GetUser(context).UserID, ProjectIDList).Where(p => p.ID != 1).Select(p => p.ID).ToList();
            }
            DateTime StartTime = WebUtil.GetDateValue(context, "StartTime");
            DateTime EndTime = WebUtil.GetDateValue(context, "EndTime");
            string page = context.Request.Form["page"];
            string rows = context.Request.Form["rows"];
            long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
            int pageSize = int.Parse(rows);
            bool canexport = WebUtil.GetBoolValue(context, "canexport");
            DataGrid dg = Foresight.DataAccess.PaySummaryAnalysis.GetPaySummaryAnalysisGrid(ProjectIDList, RoomIDList, StartTime, EndTime, "order by [DefaultOrder] desc", startRowIndex, pageSize, UserID: WebUtil.GetUser(context).UserID, canexport: canexport);
            PaySummaryAnalysis[] list = null;
            if (dg != null && dg.rows != null)
            {
                var paysummary_list = Foresight.DataAccess.PaySummary.GetPaySummaries().ToArray();
                list = dg.rows as PaySummaryAnalysis[];
                var cost_list = Foresight.DataAccess.PaySummaryAnalysis.GetPaySummaryAnalysisList(ProjectIDList, RoomIDList, StartTime, EndTime, UserID: WebUtil.GetUser(context).UserID);
                Dictionary<string, object> footer = new Dictionary<string, object>();
                footer["FullName"] = "合计";
                var items = list.Select(room =>
                {
                    var dic = new Dictionary<string, object>();
                    string FullName = string.IsNullOrEmpty(room.FullName) ? room.ProjectName : room.FullName;
                    dic["FullName"] = FullName;
                    string RoomName = string.IsNullOrEmpty(room.Name) ? room.RoomName : room.Name;
                    dic["RoomName"] = RoomName;
                    decimal heji_RealCost = 0;
                    foreach (var summary in paysummary_list)
                    {
                        decimal realcost = cost_list.Where(p => p.ProjectID == room.ProjectID && p.PaySummaryID == summary.ID).Sum(p => p.TotalCost);
                        dic[summary.ID + "_RealCost"] = realcost > 0 ? realcost : 0;
                        heji_RealCost += realcost > 0 ? realcost : 0;
                        decimal footer_realcost = 0;
                        if (footer.ContainsKey(summary.ID + "_RealCost"))
                        {
                            footer_realcost = Convert.ToDecimal(footer[summary.ID + "_RealCost"]);
                        }
                        footer[summary.ID + "_RealCost"] = footer_realcost + (realcost > 0 ? realcost : 0);
                    }
                    decimal footer_heji_realcost = 0;
                    dic["heji_RealCost"] = heji_RealCost;
                    if (footer.ContainsKey("heji_RealCost"))
                    {
                        footer_heji_realcost = Convert.ToDecimal(footer["heji_RealCost"]);
                    }
                    footer["heji_RealCost"] = footer_heji_realcost + heji_RealCost;
                    return dic;
                }).ToList();
                dg.rows = items;
                List<Dictionary<string, object>> footerlist = new List<Dictionary<string, object>>();
                footerlist.Add(footer);
                dg.footer = footerlist;
            }
            if (canexport)
            {
                string downloadurl = string.Empty;
                string error = string.Empty;
                bool status = APPCode.ExportHelper.DownLoadPayServiceAnalysisData(dg, out downloadurl, out error);
                WebUtil.WriteJson(context, new { status = status, downloadurl = downloadurl, error = error });
                return;
            }
            WebUtil.WriteJson(context, dg);
        }
        private void getpayserviceanalysicolumns(HttpContext context)
        {
            var list = Foresight.DataAccess.PaySummary.GetPaySummaries().ToList();
            StringBuilder columns = new StringBuilder("[[");
            columns.Append("{ field: 'FullName', title: '资源位置', width: 200 },");
            columns.Append("{ field: 'RoomName', title: '房间信息', width: 100 },");
            foreach (var item in list)
            {
                columns.Append("{ field: '" + item.ID + "_RealCost', formatter: formatCostFormat, title: '" + item.PayName + "', width: 100 },");
            }
            columns.Append("{ field: 'heji_RealCost', formatter: formatCostFormat, title: '总计', width: 100 },");
            columns.Remove(columns.Length - 1, 1);
            columns.Append("]]");
            var items = new
            {
                status = list.Count > 0 ? true : false,
                columns = columns.ToString(),
            };
            WebUtil.WriteJson(context, items);
        }
        private void getservicemgrparams(HttpContext context)
        {
            var userlist = Foresight.DataAccess.User.GetAPPUserList();
            var items = userlist.Select(p =>
            {
                var item = new { UserID = p.UserID, RealName = p.RealName };
                return item;
            }).ToList();
            items.Insert(0, new { UserID = 0, RealName = "全部" });
            WebUtil.WriteJson(context, new { status = true, users = items });
        }
        private void savewechatservice(HttpContext context)
        {
            Foresight.DataAccess.Wechat_Service service = null;
            int ID = WebUtil.GetIntValue(context, "ID");
            if (ID > 0)
            {
                service = Foresight.DataAccess.Wechat_Service.GetWechat_Service(ID);
            }
            if (service == null)
            {
                service = new Foresight.DataAccess.Wechat_Service();
                service.AddTime = DateTime.Now;
                service.ServiceFrom = Utility.EnumModel.WechatServiceFromDefine.system.ToString();
            }
            service.FullName = getValue(context, "tdFullName");
            service.ServiceContent = getValue(context, "tdServiceContent");
            service.PhoneNumber = getValue(context, "tdPhoneNumber");
            service.ServiceAddTime = getTimeValue(context, "tdServiceAddTime");
            service.ServiceMan = getValue(context, "tdServiceMan");
            service.ServiceContent = getValue(context, "tdServiceContent");
            service.ServiceType = Utility.EnumModel.WechatServiceType.bsbx.ToString();
            List<Foresight.DataAccess.Wechat_ServiceImg> attachlist = new List<Foresight.DataAccess.Wechat_ServiceImg>();
            HttpFileCollection uploadFiles = context.Request.Files;
            for (int i = 0; i < uploadFiles.Count; i++)
            {
                HttpPostedFile postedFile = uploadFiles[i];
                string fileOriName = postedFile.FileName;
                if (fileOriName != "" && fileOriName != null)
                {
                    string extension = System.IO.Path.GetExtension(fileOriName).ToLower();
                    string fileName = DateTime.Now.ToFileTime().ToString() + extension;
                    string filepath = "/upload/CustomerService/";
                    string rootPath = HttpContext.Current.Server.MapPath("~" + filepath);
                    if (!System.IO.Directory.Exists(rootPath))
                    {
                        System.IO.Directory.CreateDirectory(rootPath);
                    }
                    string Path = rootPath + fileName;
                    postedFile.SaveAs(Path);
                    Foresight.DataAccess.Wechat_ServiceImg attach = new Foresight.DataAccess.Wechat_ServiceImg();
                    attach.FileName = fileOriName;
                    attach.Icon = filepath + fileName;
                    attach.Medium = filepath + fileName;
                    attach.Large = filepath + fileName;
                    attach.AddTime = DateTime.Now;
                    attachlist.Add(attach);
                }
            }

            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    service.Save(helper);
                    foreach (var item in attachlist)
                    {
                        item.ServiceID = service.ID;
                        item.Save(helper);
                    }
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    Utility.LogHelper.WriteError("ServiceHandler", "命令: savewechatservice", ex);
                    helper.Rollback();
                    WebUtil.WriteJson(context, new { status = false });
                    return;
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void savecomboboxservicetask(HttpContext context)
        {
            string liststr = context.Request["list"];
            if (string.IsNullOrEmpty(liststr))
            {
                WebUtil.WriteJson(context, new { status = false, msg = "参数错误" });
                return;
            }
            List<Utility.BasicModel> list = JsonConvert.DeserializeObject<List<Utility.BasicModel>>(liststr);
            foreach (var item in list)
            {
                Foresight.DataAccess.CustomerService_Task task = null;
                if (item.id > 0)
                {
                    task = Foresight.DataAccess.CustomerService_Task.GetCustomerService_Task(item.id);
                }
                if (task == null)
                {
                    task = new CustomerService_Task();
                    task.AddTime = DateTime.Now;
                }
                task.TaskName = item.value;
                task.Save();
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void deletecomboboxservicetask(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            var list = Foresight.DataAccess.CustomerService.GetCustomerServiceListByParams(new int[] { ID });
            if (list.Length > 0)
            {
                WebUtil.WriteJson(context, new { status = false, msg = "任务标签使用中，禁止删除" });
                return;
            }
            Foresight.DataAccess.CustomerService_Task.DeleteCustomerService_Task(ID);
            WebUtil.WriteJson(context, new { status = true });
        }
        private void getservicetaskparams(HttpContext context)
        {
            var task_list = Foresight.DataAccess.CustomerService_Task.GetCustomerService_Tasks().OrderBy(p => p.ID).Select(p =>
            {
                var item = new { ID = p.ID, Name = p.TaskName };
                return item;
            });
            WebUtil.WriteJson(context, new { status = true, task_list = task_list });

        }
        private void resendjpush(HttpContext context)
        {
            var config = new Utility.SiteConfig();
            if (string.IsNullOrEmpty(config.JPushKey_User))
            {
                WebUtil.WriteJson(context, new { status = false, error = "推送服务器未配置" });
                return;
            }
            string type = context.Request["type"];
            if (string.IsNullOrEmpty(type))
            {
                type = "customer_service";
            }
            if (!type.Equals("customer_service"))
            {
                WebUtil.WriteJson(context, "type不合法");
                return;
            }
            int ID = WebUtil.GetIntValue(context, "ID");
            string ErrorMsg = string.Empty;
            var company = WebUtil.GetCompany(HttpContext.Current);
            string title = company == null ? "永友网络" : company.CompanyName;
            var user = WebUtil.GetUser(context);
            bool result = APPCode.JPushHelper.SendJpushMsgByServiceID(ID, out ErrorMsg, title: title, SendUserID: user.UserID, SendUserName: user.RealName);
            if (!result)
            {
                WebUtil.WriteJson(context, ErrorMsg);
                return;
            }
            WebUtil.WriteJson(context, "推送成功");
        }
        private void completeservice(HttpContext context)
        {
            string IDs = context.Request.Params["IDList"];
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(IDs);
            string BalanceStatus = context.Request["BalanceStatus"];
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    string cmdtext = "update [CustomerService] set BalanceStatus='" + BalanceStatus + "' where ID in (" + string.Join(",", IDList.ToArray()) + ")";
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    helper.Execute(cmdtext, CommandType.Text, parameters);
                    helper.Commit();
                    context.Response.Write("{\"status\":true}");
                }
                catch (Exception ex)
                {
                    Utility.LogHelper.WriteError("ServiceHandler", "命令: removeservice", ex);
                    helper.Rollback();
                    context.Response.Write("{\"status\":false}");
                }
            }
        }
        private void loadservicemateriallist(HttpContext context)
        {
            try
            {
                string RoomIDs = context.Request.Params["RoomIDs"];
                List<int> RoomIDList = new List<int>();
                if (!string.IsNullOrEmpty(RoomIDs))
                {
                    RoomIDList = JsonConvert.DeserializeObject<List<int>>(RoomIDs);
                }
                string ProjectIDs = context.Request.Params["ProjectIDs"];
                List<int> ProjectIDList = new List<int>();
                if (!string.IsNullOrEmpty(ProjectIDs))
                {
                    ProjectIDList = JsonConvert.DeserializeObject<List<int>>(ProjectIDs);
                }
                string BalanceStatus = context.Request.Params["BalanceStatus"];
                string PayStatusStr = context.Request.Params["PayStatus"];
                int PayStatus = int.MinValue;
                if (!string.IsNullOrEmpty(PayStatusStr))
                {
                    int.TryParse(PayStatusStr, out PayStatus);
                }
                DateTime StartTime = DateTime.MinValue;
                DateTime.TryParse(context.Request.Params["StartTime"], out StartTime);
                DateTime EndTime = DateTime.MinValue;
                DateTime.TryParse(context.Request.Params["EndTime"], out EndTime);
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                bool canexport = WebUtil.GetBoolValue(context, "canexport");
                DataGrid dg = Foresight.DataAccess.ViewCustomerServiceInDetail.GetViewCustomerServiceInDetailGridByKeywords(StartTime, EndTime, PayStatus, BalanceStatus, RoomIDList, ProjectIDList, "order by [ServiceID] desc,[ID] asc", startRowIndex, pageSize, UserID: WebUtil.GetUser(context).UserID, canexport: canexport);
                if (canexport)
                {
                    string downloadurl = string.Empty;
                    string error = string.Empty;
                    bool status = APPCode.ExportHelper.DownLoadMaterialListData(dg, out downloadurl, out error);
                    WebUtil.WriteJson(context, new { status = status, downloadurl = downloadurl, error = error });
                    return;
                }
                string result = JsonConvert.SerializeObject(dg);
                context.Response.Write(result);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.WriteError("ServiceHandler", "命令:loadservicemateriallist", ex);
                context.Response.Write("{\"rows\":[],\"total\":0,\"page\":0}");
            }
        }
        private void cancelservice(HttpContext context)
        {
            string IDs = context.Request.Params["IDList"];
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(IDs);
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    string cmdtext = "update [CustomerService] set ServiceStatus=2 where ID in (" + string.Join(",", IDList.ToArray()) + ")";
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    helper.Execute(cmdtext, CommandType.Text, parameters);
                    helper.Commit();
                    context.Response.Write("{\"status\":true}");
                }
                catch (Exception ex)
                {
                    Utility.LogHelper.WriteError("ServiceHandler", "命令: cancelservice", ex);
                    helper.Rollback();
                    context.Response.Write("{\"status\":false}");
                }
            }
        }
        private void saveservicematerial(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            Foresight.DataAccess.CustomerService_Material material = null;
            if (ID > 0)
            {
                material = Foresight.DataAccess.CustomerService_Material.GetCustomerService_Material(ID);
            }
            if (material == null)
            {
                material = new Foresight.DataAccess.CustomerService_Material();
                material.CustomerServiceID = WebUtil.GetIntValue(context, "CustomerServiceID");
                material.AddTime = DateTime.Now;
            }
            material.MateralName = context.Request["MateralName"];
            material.UnitPrice = WebUtil.GetDecimalValue(context, "UnitPrice");
            material.TotalCount = WebUtil.GetIntValue(context, "TotalCount");
            material.TotalCost = WebUtil.GetDecimalValue(context, "TotalCost");
            material.GUID = context.Request["guid"];
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    material.Save(helper);
                    helper.Commit();
                    WebUtil.WriteJson(context, new { status = true, ID = material.ID });
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError("ServiceHandler", "命令: saveservicematerial", ex);
                    WebUtil.WriteJson(context, new { status = false });
                }
            }
        }
        private void removeservicematerial(HttpContext context)
        {
            string ids = context.Request["IDList"];
            List<int> IDlist = JsonConvert.DeserializeObject<List<int>>(ids);
            if (IDlist.Count > 0)
            {
                using (SqlHelper helper = new SqlHelper())
                {
                    try
                    {
                        helper.BeginTransaction();
                        string cmdtext = "delete from [CustomerService_Material] where [ID] in (" + string.Join(",", IDlist) + ")";
                        helper.Execute(cmdtext, CommandType.Text, new List<SqlParameter>());
                        helper.Commit();
                    }
                    catch (Exception ex)
                    {
                        helper.Rollback();
                        LogHelper.WriteError("ServiceHandler", "命令: removeservicematerial", ex);
                        WebUtil.WriteJson(context, new { status = false });
                        return;
                    }
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void removepayservice(HttpContext context)
        {
            string ids = context.Request.Params["IDList"];
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(ids);
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    string cmdtext = string.Empty;
                    cmdtext += "delete from [PrintRoomFeeHistory] where exists (select 1 from [PayService] where [PrintID]=[PrintRoomFeeHistory].ID and [PayService].ID in (" + string.Join(",", IDList.ToArray()) + "));";
                    cmdtext += "delete from [RoomFeeHistory] where exists (select 1 from [PayService] where [PrintID]=[RoomFeeHistory].PrintID and [PayService].ID in (" + string.Join(",", IDList.ToArray()) + "));";
                    cmdtext += "delete from [PayService] where ID in (" + string.Join(",", IDList.ToArray()) + ");";
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    helper.Execute(cmdtext, CommandType.Text, parameters);
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    Utility.LogHelper.WriteError("ServiceHandler", "命令: removepayservice", ex);
                    context.Response.Write("{\"status\":false}");
                    WebUtil.WriteJson(context, new { status = false });
                    return;
                }
            }
            #region 操作日志
            var user = WebUtil.GetUser(context);
            APPCode.CommHelper.SaveOperationLog(string.Join(",", IDList.ToArray()), Utility.EnumModel.OperationModule.PayServiceDelete.ToString(), "支出登记删除", user.UserID.ToString(), "PayService", user.LoginName, IsHide: true);
            APPCode.CommHelper.SaveOperationLog("用户" + user.LoginName + "删除了支出登记", Utility.EnumModel.OperationModule.PayServiceDelete.ToString(), "支出登记删除", user.UserID.ToString(), "PayService", user.LoginName);
            #endregion
            WebUtil.WriteJson(context, new { status = true });
        }
        private void loadpayservicegrid(HttpContext context)
        {
            try
            {
                string RoomIDs = context.Request.Params["RoomIDs"];
                List<int> RoomIDList = new List<int>();
                if (!string.IsNullOrEmpty(RoomIDs))
                {
                    RoomIDList = JsonConvert.DeserializeObject<List<int>>(RoomIDs);
                }
                string ProjectIDs = context.Request.Params["ProjectIDs"];
                List<int> EqualProjectIDList = new List<int>();
                List<int> InProjectIDList = new List<int>();
                if (RoomIDList.Count == 0)
                {
                    List<int> MyProjectIDList = new List<int>();
                    if (!string.IsNullOrEmpty(ProjectIDs))
                    {
                        MyProjectIDList = JsonConvert.DeserializeObject<List<int>>(ProjectIDs).Where(p => p != 1).ToList();
                    }
                    Web.APPCode.CacheHelper.GetMyProjectListByUserID(WebUtil.GetUser(context).UserID, out EqualProjectIDList, out InProjectIDList, ProjectIDList: MyProjectIDList);
                }
                int PaySummaryID = WebUtil.GetIntValue(context, "PaySummary");
                DateTime StartTime = DateTime.MinValue;
                DateTime.TryParse(context.Request.Params["StartTime"], out StartTime);
                DateTime EndTime = DateTime.MinValue;
                DateTime.TryParse(context.Request.Params["EndTime"], out EndTime);
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                string Keywords = context.Request.Params["Keywords"];
                bool canexport = WebUtil.GetBoolValue(context, "canexport");
                DataGrid dg = Foresight.DataAccess.ViewPayService.GetViewPayServiceGridByKeywords(PaySummaryID, Keywords, RoomIDList, StartTime, EndTime, "order by [PayTime] desc", startRowIndex, pageSize, UserID: WebUtil.GetUser(context).UserID, EqualProjectIDList: EqualProjectIDList, InProjectIDList: InProjectIDList, canexport: canexport);
                if (canexport)
                {
                    string downloadurl = string.Empty;
                    string error = string.Empty;
                    bool status = APPCode.ExportHelper.DownLoadPayServiceData(dg, out downloadurl, out error);
                    WebUtil.WriteJson(context, new { status = status, downloadurl = downloadurl, error = error });
                    return;
                }
                string result = JsonConvert.SerializeObject(dg);
                context.Response.Write(result);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.WriteError("ServiceHandler", "命令:loadpayservicegrid", ex);
                context.Response.Write("{\"rows\":[],\"total\":0,\"page\":0}");
            }
        }
        private void savepaysummary(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            Foresight.DataAccess.PaySummary summary = null;
            if (ID > 0)
            {
                summary = Foresight.DataAccess.PaySummary.GetPaySummary(ID);
            }
            int RelateFeeType_Pay = WebUtil.GetIntValue(context, "RelateFeeType_Pay");

            if (summary == null)
            {
                summary = new PaySummary();
                summary.AddMan = WebUtil.GetUser(context).RealName;
                summary.AddTime = DateTime.Now;
                summary.PID = 0;
            }
            summary.PayName = context.Request.Params["PayName"];
            summary.Remark = context.Request.Params["Remark"];
            summary.RelateFeeType_Pay = RelateFeeType_Pay == 1;
            summary.Save();
            WebUtil.WriteJson(context, new { status = true });
        }
        private void removepaysummary(HttpContext context)
        {
            string ids = context.Request.Params["IDList"];
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(ids);
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    string cmdtext = "delete from [PaySummary] where ID in (" + string.Join(",", IDList.ToArray()) + ")";
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    helper.Execute(cmdtext, CommandType.Text, parameters);
                    helper.Commit();
                    context.Response.Write("{\"status\":true}");
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    Utility.LogHelper.WriteError("ServiceHandler", "命令: removepaysummary", ex);
                    context.Response.Write("{\"status\":false}");
                }
            }
        }
        private void loadpaysummarygrid(HttpContext context)
        {
            try
            {
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                string Keywords = context.Request.Params["keywords"];
                DataGrid dg = Foresight.DataAccess.PaySummary.GetPaySummaryGridByKeywords(Keywords, "order by [AddTime] desc", startRowIndex, pageSize);
                string result = JsonConvert.SerializeObject(dg);
                context.Response.Write(result);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.WriteError("ServiceHandler", "命令:loadpaysummarygrid", ex);
                context.Response.Write("{\"rows\":[],\"total\":0,\"page\":0}");
            }
        }
        private void savepayservice(HttpContext context)
        {
            Foresight.DataAccess.PayService service = null;
            int ID = WebUtil.GetIntValue(context, "ID");
            int ProjectID = WebUtil.GetIntValue(context, "ProjectID");
            int type = WebUtil.GetIntValue(context, "type");
            if (ID > 0)
            {
                service = Foresight.DataAccess.PayService.GetPayService(ID);
            }
            if (service == null)
            {
                service = new Foresight.DataAccess.PayService();
                service.AddTime = DateTime.Now;
                service.AddMan = getValue(context, "tdAddMan");
                service.AddManID = WebUtil.GetIntValue(context, "AddManID");
                service.ProjectID = WebUtil.GetIntValue(context, "ProjectID");
                service.Status = 1;
            }
            else
            {
                if (service.PrintID > 0)
                {
                    WebUtil.WriteJson(context, new { status = true, ID = service.ID, PrintID = service.PrintID });
                    return;
                }
                service.ModifyTime = DateTime.Now;
                service.ModifyMan = context.Request.Params["AddMan"];
                service.ModifyManID = WebUtil.GetIntValue(context, "AddManID");
            }
            service.ProjectName = getValue(context, "tdProjectName");
            service.PayMoney = getDecimalValue(context, "tdPayMoney");
            service.PaySummaryID = getIntValue(context, "tdPaySummary");
            service.PayTypeID = getIntValue(context, "tdPayType");
            service.PayType = getValue(context, "hdPayType");
            service.AccountType = getValue(context, "tdAccountType");
            service.PayTime = getTimeValue(context, "tdPayTime");
            service.RoomName = getValue(context, "tdRoomName");
            service.Remark = getValue(context, "tdRemark");
            service.Save();
            if (type == 0)
            {
                WebUtil.WriteJson(context, new { status = true, ID = service.ID });
                return;
            }
            var paysummary = Foresight.DataAccess.PaySummary.GetPaySummary(service.PaySummaryID);
            var temphistory = new Foresight.DataAccess.TempRoomFeeHistory();
            temphistory.TempID = 0;
            temphistory.ID = 0;
            temphistory.RoomID = service.ProjectID;
            temphistory.UseCount = 0;
            temphistory.Cost = service.PayMoney;
            temphistory.AddTime = DateTime.Now;
            temphistory.IsCharged = true;
            temphistory.ChargeID = 0;
            temphistory.ChargeID = 0;
            temphistory.IsStart = true;
            temphistory.IsStart = true;
            temphistory.RealCost = service.PayMoney;
            temphistory.RealCost = service.PayMoney;
            temphistory.Discount = 0;
            temphistory.OutDays = 0;
            temphistory.ChargeFee = 0;
            temphistory.TotalRealCost = 0;
            temphistory.RestCost = 0;
            temphistory.TotalDiscountCost = 0;
            temphistory.OnlyOnceCharge = true;
            temphistory.ChargeTime = DateTime.Now;
            temphistory.ChargeMan = WebUtil.GetUser(context).RealName;
            temphistory.ChargeState = 7;
            temphistory.UnitPrice = 0;
            temphistory.ChargeFeeSummaryName = paysummary != null ? paysummary.PayName : "未定义";
            temphistory.BackGuaranteeRemark = temphistory.ChargeTime.ToString("yyyy-MM-dd") + "支出 " + temphistory.ChargeFeeSummaryName + " " + WebUtil.FormatMoney(temphistory.RealCost) + "元 " + "付款人 " + temphistory.ChargeMan;
            temphistory.Save();
            WebUtil.WriteJson(context, new { status = true, ID = service.ID, TempID = temphistory.TempHistoryID });
        }
        private void getpaytype(HttpContext context)
        {
            var list = ChargeMoneyType.GetChargeMoneyTypes().Where(p => (!p.ChargeTypeName.Contains("冲抵")));
            WebUtil.WriteJson(context, list);
        }
        private void loadpaysummary(HttpContext context)
        {
            var list = PaySummary.GetPaySummaries();
            WebUtil.WriteJson(context, list);
        }
        private void deleteservicetype(HttpContext context)
        {
            string ids = context.Request.Params["ids"];
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(ids);
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    string cmdtext = "delete from [ServiceType] where ID in (" + string.Join(",", IDList.ToArray()) + ")";
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    helper.Execute(cmdtext, CommandType.Text, parameters);
                    helper.Commit();
                    context.Response.Write("{\"status\":true}");
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    Utility.LogHelper.WriteError("ServiceHandler", "命令: deleteservicetype", ex);
                    context.Response.Write("{\"status\":false}");
                }
            }
        }
        private void saveservicetype(HttpContext context)
        {
            string id = context.Request.Params["id"];
            string name = context.Request.Params["name"];
            string sortorder = context.Request.Params["sortorder"];
            Foresight.DataAccess.ServiceType servicetype = null;
            if (!string.IsNullOrEmpty(id))
            {
                servicetype = Foresight.DataAccess.ServiceType.GetServiceType(int.Parse(id));
            }
            if (servicetype == null)
            {
                servicetype = new Foresight.DataAccess.ServiceType();
            }
            servicetype.ServiceTypeName = name;
            int _sortorder = int.MinValue;
            int.TryParse(sortorder, out _sortorder);
            servicetype.SortOrder = _sortorder;
            servicetype.Save();
            context.Response.Write("{\"status\":true}");
        }
        private void loadservicetype(HttpContext context)
        {
            try
            {
                var list = Foresight.DataAccess.ServiceType.GetServiceTypes().OrderBy(p => p.SortOrder).ToList();
                var dg = new DataGrid();
                dg.rows = list;
                dg.total = list.Count;
                dg.page = 1;
                string result = JsonConvert.SerializeObject(dg);
                context.Response.Write(result);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.WriteError("ServiceHandler", "命令: loadservicetype", ex);
                context.Response.Write("{\"rows\":[],\"total\":0,\"page\":0}");
            }
        }
        private void loadserviceattachs(HttpContext context)
        {
            int ID = int.Parse(context.Request.Params["ID"]);
            var list = Foresight.DataAccess.CustomerServiceAttach.GetCustomerServiceAttachList(ID);
            var items = list.Select(p =>
            {
                var dic = p.ToJsonObject();
                dic["AttachedFilePath"] = string.IsNullOrEmpty(p.AttachedFilePath) ? string.Empty : WebUtil.GetContextPath() + p.AttachedFilePath;
                return dic;
            });
            WebUtil.WriteJson(context, items);
        }
        private void loadstaticlist(HttpContext context)
        {
            string ServiceType = context.Request["ServiceType"];
            if (ServiceType.Equals("servicecategory"))
            {
                loadstaticlistbyservicecategory(context);
                return;
            }
            if (ServiceType.Equals("tasktype"))
            {
                loadstaticlistbytasktype(context);
                return;
            }
            if (ServiceType.Equals("accpetman"))
            {
                loadstaticlistbyaccpetman(context);
                return;
            }
        }
        private void loadstaticlistbyaccpetman(HttpContext context)
        {
            DateTime StartTime = DateTime.MinValue;
            DateTime.TryParse(context.Request.Params["StartTime"], out StartTime);
            DateTime EndTime = DateTime.MinValue;
            DateTime.TryParse(context.Request.Params["EndTime"], out EndTime);
            var userList = Foresight.DataAccess.User.GetAPPUserList();
            StringBuilder builder = new StringBuilder();
            builder.Append("{");
            builder.Append("\"total\":" + userList.Length + ",");
            builder.Append("\"rows\":[");
            int i = 0;
            var list = Foresight.DataAccess.ServiceType.GetServiceTypes().ToArray();
            foreach (var user in userList)
            {
                builder.Append("{");
                builder.Append("\"接单人\":\"" + user.RealName + "\"");
                var countList = Foresight.DataAccess.CustomerServiceStatic.GetCustomerServiceStaticCountByServiceType(StartTime, EndTime, 0, user.UserID);
                if (list.Length > 0)
                {
                    builder.Append(",");
                    int total = 0;
                    int completeCount = 0;
                    foreach (var model in list)
                    {
                        var item = countList.FirstOrDefault(p => p.ID == model.ID);
                        if (item == null)
                        {
                            builder.Append("\"" + model.ID + "_jiedandengji\":0,");
                            builder.Append("\"" + model.ID + "_chulizhong\":0,");
                            builder.Append("\"" + model.ID + "_yiwancheng\":0,");
                            builder.Append("\"" + model.ID + "_yihuifang\":0,");
                            builder.Append("\"" + model.ID + "_wanchenglv\":\"--\",");
                        }
                        else
                        {
                            item.TotalCount = item.TotalCount > 0 ? item.TotalCount : 0;
                            item.jiedandengji_count = item.jiedandengji_count > 0 ? item.jiedandengji_count : 0;
                            item.chulizhong_count = item.chulizhong_count > 0 ? item.chulizhong_count : 0;
                            item.yiwancheng_count = item.yiwancheng_count > 0 ? item.yiwancheng_count : 0;
                            item.yihuifang_count = item.yihuifang_count > 0 ? item.yihuifang_count : 0;
                            builder.Append("\"" + item.ID + "_jiedandengji\":" + item.jiedandengji_count + ",");
                            builder.Append("\"" + item.ID + "_chulizhong\":" + item.chulizhong_count + ",");
                            builder.Append("\"" + item.ID + "_yiwancheng\":" + item.yiwancheng_count + ",");
                            builder.Append("\"" + item.ID + "_yihuifang\":" + item.yihuifang_count + ",");
                            string completePer = "--";
                            if ((decimal)item.TotalCount > 0)
                            {
                                completePer = Math.Round((decimal)(item.yiwancheng_count / (decimal)item.TotalCount) * 100, 2, MidpointRounding.AwayFromZero) + "%";
                            }
                            builder.Append("\"" + item.ID + "_wanchenglv\":\"" + completePer + "\",");
                            total += item.TotalCount;
                            completeCount += item.yiwancheng_count;
                        }
                    }
                    string closePer = "--";
                    if ((decimal)total > 0)
                    {
                        closePer = Math.Round((decimal)(completeCount / (decimal)total) * 100, 2, MidpointRounding.AwayFromZero) + "%";
                    }
                    builder.Append("\"总量\":\"" + total + "\",");
                    builder.Append("\"完成率\":\"" + closePer + "\"");
                }
                if (i == (userList.Length - 1))
                {
                    builder.Append("}");
                }
                else
                {
                    builder.Append("},");
                }
                i++;
            }
            builder.Append("]}");
            string tables = builder.ToString();
            context.Response.Write(tables);
        }
        private void loadstaticlistbytasktype(HttpContext context)
        {
            DateTime StartTime = DateTime.MinValue;
            DateTime.TryParse(context.Request.Params["StartTime"], out StartTime);
            DateTime EndTime = DateTime.MinValue;
            DateTime.TryParse(context.Request.Params["EndTime"], out EndTime);
            var projectList = Foresight.DataAccess.Project.GetProjectByParentID(1);
            StringBuilder builder = new StringBuilder();
            builder.Append("{");
            builder.Append("\"total\":" + projectList.Length + ",");
            builder.Append("\"rows\":[");
            int i = 0;
            var list = Foresight.DataAccess.CustomerService_Task.GetCustomerService_Tasks().ToArray();
            foreach (var project in projectList)
            {
                builder.Append("{");
                builder.Append("\"项目\":\"" + project.Name + "\"");
                var countList = Foresight.DataAccess.CustomerServiceStatic.GetCustomerServiceStaticCountByTaskType(project.ID, StartTime, EndTime);
                if (list.Length > 0)
                {
                    builder.Append(",");
                    int total = 0;
                    int completeCount = 0;
                    foreach (var model in list)
                    {
                        var item = countList.FirstOrDefault(p => p.ID == model.ID);
                        if (item == null)
                        {
                            builder.Append("\"" + model.ID + "_jiedandengji\":0,");
                            builder.Append("\"" + model.ID + "_chulizhong\":0,");
                            builder.Append("\"" + model.ID + "_yiwancheng\":0,");
                            builder.Append("\"" + model.ID + "_yihuifang\":0,");
                            builder.Append("\"" + model.ID + "_wanchenglv\":\"--\",");
                        }
                        else
                        {
                            item.TotalCount = item.TotalCount > 0 ? item.TotalCount : 0;
                            item.jiedandengji_count = item.jiedandengji_count > 0 ? item.jiedandengji_count : 0;
                            item.chulizhong_count = item.chulizhong_count > 0 ? item.chulizhong_count : 0;
                            item.yiwancheng_count = item.yiwancheng_count > 0 ? item.yiwancheng_count : 0;
                            item.yihuifang_count = item.yihuifang_count > 0 ? item.yihuifang_count : 0;
                            builder.Append("\"" + item.ID + "_jiedandengji\":" + item.jiedandengji_count + ",");
                            builder.Append("\"" + item.ID + "_chulizhong\":" + item.chulizhong_count + ",");
                            builder.Append("\"" + item.ID + "_yiwancheng\":" + item.yiwancheng_count + ",");
                            builder.Append("\"" + item.ID + "_yihuifang\":" + item.yihuifang_count + ",");
                            string completePer = "--";
                            if ((decimal)item.TotalCount > 0)
                            {
                                completePer = Math.Round((decimal)(item.yiwancheng_count / (decimal)item.TotalCount) * 100, 2, MidpointRounding.AwayFromZero) + "%";
                            }
                            builder.Append("\"" + item.ID + "_wanchenglv\":\"" + completePer + "\",");
                            total += item.TotalCount;
                            completeCount += item.yiwancheng_count;
                        }
                    }
                    string closePer = "--";
                    if ((decimal)total > 0)
                    {
                        closePer = Math.Round((decimal)(completeCount / (decimal)total) * 100, 2, MidpointRounding.AwayFromZero) + "%";
                    }
                    builder.Append("\"总量\":\"" + total + "\",");
                    builder.Append("\"完成率\":\"" + closePer + "\"");
                }
                if (i == (projectList.Length - 1))
                {
                    builder.Append("}");
                }
                else
                {
                    builder.Append("},");
                }
                i++;
            }
            builder.Append("]}");
            string tables = builder.ToString();
            context.Response.Write(tables);
        }
        private void loadstaticlistbyservicecategory(HttpContext context)
        {
            DateTime StartTime = DateTime.MinValue;
            DateTime.TryParse(context.Request.Params["StartTime"], out StartTime);
            DateTime EndTime = DateTime.MinValue;
            DateTime.TryParse(context.Request.Params["EndTime"], out EndTime);
            var projectList = Foresight.DataAccess.Project.GetProjectByParentID(1);
            StringBuilder builder = new StringBuilder();
            builder.Append("{");
            builder.Append("\"total\":" + projectList.Length + ",");
            builder.Append("\"rows\":[");
            int i = 0;
            var list = Foresight.DataAccess.ServiceType.GetServiceTypes().ToArray();
            foreach (var project in projectList)
            {
                builder.Append("{");
                builder.Append("\"项目\":\"" + project.Name + "\"");
                var countList = Foresight.DataAccess.CustomerServiceStatic.GetCustomerServiceStaticCountByServiceType(StartTime, EndTime, project.ID, 0);
                if (list.Length > 0)
                {
                    builder.Append(",");
                    int total = 0;
                    int completeCount = 0;
                    foreach (var model in list)
                    {
                        var item = countList.FirstOrDefault(p => p.ID == model.ID);
                        if (item == null)
                        {
                            builder.Append("\"" + model.ID + "_jiedandengji\":0,");
                            builder.Append("\"" + model.ID + "_chulizhong\":0,");
                            builder.Append("\"" + model.ID + "_yiwancheng\":0,");
                            builder.Append("\"" + model.ID + "_yihuifang\":0,");
                            builder.Append("\"" + model.ID + "_wanchenglv\":\"--\",");
                        }
                        else
                        {
                            item.TotalCount = item.TotalCount > 0 ? item.TotalCount : 0;
                            item.jiedandengji_count = item.jiedandengji_count > 0 ? item.jiedandengji_count : 0;
                            item.chulizhong_count = item.chulizhong_count > 0 ? item.chulizhong_count : 0;
                            item.yiwancheng_count = item.yiwancheng_count > 0 ? item.yiwancheng_count : 0;
                            item.yihuifang_count = item.yihuifang_count > 0 ? item.yihuifang_count : 0;
                            builder.Append("\"" + item.ID + "_jiedandengji\":" + item.jiedandengji_count + ",");
                            builder.Append("\"" + item.ID + "_chulizhong\":" + item.chulizhong_count + ",");
                            builder.Append("\"" + item.ID + "_yiwancheng\":" + item.yiwancheng_count + ",");
                            builder.Append("\"" + item.ID + "_yihuifang\":" + item.yihuifang_count + ",");
                            string completePer = "--";
                            if ((decimal)item.TotalCount > 0)
                            {
                                completePer = Math.Round((decimal)(item.yiwancheng_count / (decimal)item.TotalCount) * 100, 2, MidpointRounding.AwayFromZero) + "%";
                            }
                            builder.Append("\"" + item.ID + "_wanchenglv\":\"" + completePer + "\",");
                            total += item.TotalCount;
                            completeCount += item.yiwancheng_count;
                        }
                    }
                    string closePer = "--";
                    if ((decimal)total > 0)
                    {
                        closePer = Math.Round((decimal)(completeCount / (decimal)total) * 100, 2, MidpointRounding.AwayFromZero) + "%";
                    }
                    builder.Append("\"总量\":\"" + total + "\",");
                    builder.Append("\"完成率\":\"" + closePer + "\"");
                }
                if (i == (projectList.Length - 1))
                {
                    builder.Append("}");
                }
                else
                {
                    builder.Append("},");
                }
                i++;
            }
            builder.Append("]}");
            string tables = builder.ToString();
            context.Response.Write(tables);
        }
        private void loadstaticcolumn(HttpContext context)
        {
            string ServiceType = context.Request["ServiceType"];
            if (ServiceType.Equals("servicecategory"))
            {
                loadstaticcolumnbyservicecategory(context);
                return;
            }
            if (ServiceType.Equals("tasktype"))
            {
                loadstaticcolumnbytasktype(context);
                return;
            }
            if (ServiceType.Equals("accpetman"))
            {
                loadstaticcolumnbyaccpetman(context);
                return;
            }
        }
        private void loadstaticcolumnbyaccpetman(HttpContext context)
        {
            var list = Foresight.DataAccess.ServiceType.GetServiceTypes().ToArray();
            StringBuilder columns = new StringBuilder("[[");
            string ColumnField = "field: '接单人', title: '接单人', width: 100, rowspan: 2";
            columns.Append("{" + ColumnField + "},");
            StringBuilder sub_columns = new StringBuilder("],[");
            for (int i = 0; i < list.Length; i++)
            {
                var item = list[i];
                sub_columns.Append("{field: '" + item.ID + "_jiedandengji', title: '接单登记', width: 60},");
                sub_columns.Append("{field: '" + item.ID + "_chulizhong', title: '处理中', width: 60},");
                sub_columns.Append("{field: '" + item.ID + "_yiwancheng', title: '已完成', width: 60},");
                sub_columns.Append("{field: '" + item.ID + "_yihuifang', title: '已回访', width: 60},");
                sub_columns.Append("{field: '" + item.ID + "_wanchenglv', title: '完成率', width: 60},");
                columns.Append("{title: '" + item.ServiceTypeName + "', colspan: 5 },");
            }
            ColumnField = "field: '总量', formatter: formatCount, title: '总量', width: 100, rowspan: 2";
            columns.Append("{" + ColumnField + "},");
            ColumnField = "field: '完成率', title: '完成率', width: 100, rowspan: 2";
            columns.Append("{" + ColumnField + "},");
            columns.Append(sub_columns.ToString());
            columns.Append("]]");
            var items = new
            {
                status = list.Length > 0 ? true : false,
                columns = columns.ToString(),
            };
            context.Response.Write(JsonConvert.SerializeObject(items));
        }
        private void loadstaticcolumnbytasktype(HttpContext context)
        {
            var list = Foresight.DataAccess.CustomerService_Task.GetCustomerService_Tasks().ToArray();
            StringBuilder columns = new StringBuilder("[[");
            string ColumnField = "field: '项目', title: '项目', width: 100, rowspan: 2";
            columns.Append("{" + ColumnField + "},");
            StringBuilder sub_columns = new StringBuilder("],[");
            for (int i = 0; i < list.Length; i++)
            {
                var item = list[i];
                sub_columns.Append("{field: '" + item.ID + "_jiedandengji', title: '接单登记', width: 60},");
                sub_columns.Append("{field: '" + item.ID + "_chulizhong', title: '处理中', width: 60},");
                sub_columns.Append("{field: '" + item.ID + "_yiwancheng', title: '已完成', width: 60},");
                sub_columns.Append("{field: '" + item.ID + "_yihuifang', title: '已回访', width: 60},");
                sub_columns.Append("{field: '" + item.ID + "_wanchenglv', title: '完成率', width: 60},");
                columns.Append("{title: '" + item.TaskName + "', colspan: 5 },");
            }
            ColumnField = "field: '总量', formatter: formatCount, title: '总量', width: 100, rowspan: 2";
            columns.Append("{" + ColumnField + "},");
            ColumnField = "field: '完成率', title: '完成率', width: 100, rowspan: 2";
            columns.Append("{" + ColumnField + "},");
            columns.Append(sub_columns.ToString());

            columns.Append("]]");
            var items = new
            {
                status = list.Length > 0 ? true : false,
                columns = columns.ToString(),
            };
            context.Response.Write(JsonConvert.SerializeObject(items));
        }
        private void loadstaticcolumnbyservicecategory(HttpContext context)
        {
            var list = Foresight.DataAccess.ServiceType.GetServiceTypes().ToArray();
            StringBuilder columns = new StringBuilder("[[");
            string ColumnField = "field: '项目', title: '项目', width: 100, rowspan: 2";
            columns.Append("{" + ColumnField + "},");
            StringBuilder sub_columns = new StringBuilder("],[");
            for (int i = 0; i < list.Length; i++)
            {
                var item = list[i];
                sub_columns.Append("{field: '" + item.ID + "_jiedandengji', title: '接单登记', width: 60},");
                sub_columns.Append("{field: '" + item.ID + "_chulizhong', title: '处理中', width: 60},");
                sub_columns.Append("{field: '" + item.ID + "_yiwancheng', title: '已完成', width: 60},");
                sub_columns.Append("{field: '" + item.ID + "_yihuifang', title: '已回访', width: 60},");
                sub_columns.Append("{field: '" + item.ID + "_wanchenglv', title: '完成率', width: 60},");
                columns.Append("{title: '" + item.ServiceTypeName + "', colspan: 5 },");
            }
            ColumnField = "field: '总量', formatter: formatCount, title: '总量', width: 100, rowspan: 2";
            columns.Append("{" + ColumnField + "},");
            ColumnField = "field: '完成率', title: '完成率', width: 100, rowspan: 2";
            columns.Append("{" + ColumnField + "},");
            columns.Append(sub_columns.ToString());

            columns.Append("]]");
            var items = new
            {
                status = list.Length > 0 ? true : false,
                columns = columns.ToString(),
            };
            context.Response.Write(JsonConvert.SerializeObject(items));
        }
        private void loaduserlist(HttpContext context)
        {
            var list = Foresight.DataAccess.User.GetSysUserList();
            var dic = new Dictionary<string, object>();
            var userList = list.Select(p =>
            {
                dic = new Dictionary<string, object>();
                dic["UserID"] = p.UserID;
                dic["RealName"] = p.FinalRealName;
                return dic;
            }).ToList();
            var item = new { status = true, list = userList };
            context.Response.Write(JsonConvert.SerializeObject(item));
        }
        private void deletefile(HttpContext context)
        {
            int ID = 0;
            int.TryParse(context.Request.Params["ID"], out ID);
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    string cmdtext = "delete from [CustomerServiceAttach] where ID=@ID";
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    parameters.Add(new SqlParameter("@ID", ID));
                    helper.Execute(cmdtext, CommandType.Text, parameters);
                    helper.Commit();
                    context.Response.Write("{\"status\":true}");
                }
                catch (Exception ex)
                {
                    Utility.LogHelper.WriteError("ServiceHandler", "命令: deletefile", ex);
                    helper.Rollback();
                    context.Response.Write("{\"status\":false}");
                }
            }
        }
        private void removeservice(HttpContext context)
        {
            string IDs = context.Request.Params["IDList"];
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(IDs);
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    string cmdtext = "delete from [CustomerService] where ID in (" + string.Join(",", IDList.ToArray()) + ")";
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    helper.Execute(cmdtext, CommandType.Text, parameters);
                    helper.Commit();
                    context.Response.Write("{\"status\":true}");
                }
                catch (Exception ex)
                {
                    Utility.LogHelper.WriteError("ServiceHandler", "命令: removeservice", ex);
                    helper.Rollback();
                    context.Response.Write("{\"status\":false}");
                }
            }
        }
        private void savebanjie(HttpContext context)
        {
            Foresight.DataAccess.CustomerService service = null;
            int ID = 0;
            int.TryParse(context.Request.Params["ID"], out ID);
            if (ID > 0)
            {
                service = Foresight.DataAccess.CustomerService.GetCustomerService(ID);
            }
            if (service == null)
            {
                context.Response.Write("{\"status\":true,\"ID\":0}");
                return;
            }
            service.BanJieTime = getTimeValue(context, "tdBanJieTime");
            service.BanJieNote = getValue(context, "tdBanJieNote");
            service.BanJieManUserID = WebUtil.GetUser(context).UserID;
            service.BanJieManName = WebUtil.GetUser(context).RealName;
            service.ServiceStatus = 1;
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    service.Save(helper);
                    helper.Commit();
                    context.Response.Write("{\"status\":true,\"ID\":" + service.ID + "}");
                }
                catch (Exception ex)
                {
                    Utility.LogHelper.WriteError("ServiceHandler", "命令: savebanjie", ex);
                    helper.Rollback();
                    context.Response.Write("{\"status\":false}");
                }
            }
        }
        private void savehuifang(HttpContext context)
        {
            Foresight.DataAccess.CustomerService service = null;
            int ID = 0;
            int.TryParse(context.Request.Params["ID"], out ID);
            if (ID > 0)
            {
                service = Foresight.DataAccess.CustomerService.GetCustomerService(ID);
            }
            if (service == null)
            {
                context.Response.Write("{\"status\":true,\"ID\":0}");
                return;
            }
            var huifang = new Foresight.DataAccess.CustomerServiceHuifang();
            huifang.ServiceID = service.ID;
            huifang.HuiFangTime = getTimeValue(context, "tdHuiFangTime");
            huifang.HuiFangNote = getValue(context, "tdHuiFangNote");
            huifang.AddTime = DateTime.Now;
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    huifang.Save(helper);
                    helper.Commit();
                    context.Response.Write("{\"status\":true,\"ID\":" + service.ID + "}");
                }
                catch (Exception ex)
                {
                    Utility.LogHelper.WriteError("ServiceHandler", "命令: savehuifang", ex);
                    helper.Rollback();
                    context.Response.Write("{\"status\":false}");
                }
            }
        }
        private void savechuli(HttpContext context)
        {
            Foresight.DataAccess.CustomerService service = null;
            int ID = 0;
            int.TryParse(context.Request.Params["ID"], out ID);
            if (ID > 0)
            {
                service = Foresight.DataAccess.CustomerService.GetCustomerService(ID);
            }
            if (service == null)
            {
                context.Response.Write("{\"status\":true,\"ID\":0}");
                return;
            }
            var chuli = new Foresight.DataAccess.CustomerServiceChuli();
            chuli.ServiceID = service.ID;
            chuli.ChuliDate = getTimeValue(context, "tdChuLiTime");
            chuli.ChuliNote = getValue(context, "tdChuLiNote");
            chuli.AddTime = DateTime.Now;
            service.HandelFee = getValue(context, "tdHandelFee");
            service.TotalFee = getDecimalValue(context, "tdTotalFee");
            string guid = context.Request["guid"];

            string ProductRows = context.Request.Params["ProductRows"];
            List<ProductRow> ProductRowList = new List<ProductRow>();
            if (!string.IsNullOrEmpty(ProductRows))
            {
                ProductRowList = JsonConvert.DeserializeObject<List<ProductRow>>(ProductRows);
            }
            List<CKProudctInDetail> CKProudctInDetailList = new List<CKProudctInDetail>();
            foreach (var item in ProductRowList)
            {
                CKProudctInDetail ckProudctInDetail = new CKProudctInDetail();
                ckProudctInDetail.ProductID = item.ProductID;
                ckProudctInDetail.UnitPrice = item.UnitPrice;
                ckProudctInDetail.InTotalCount = item.InTotalCount;
                ckProudctInDetail.InTotalPrice = item.InTotalPrice;
                ckProudctInDetail.AddTime = DateTime.Now;
                ckProudctInDetail.AddMan = context.Request.Params["AddMan"];
                CKProudctInDetailList.Add(ckProudctInDetail);
            }

            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    chuli.Save(helper);
                    service.Save(helper);
                    string cmdtext = "delete from [CKProudctInDetail] where [ServiceID]=@ServiceID";
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    parameters.Add(new SqlParameter("@ServiceID", service.ID));
                    helper.Execute(cmdtext, CommandType.Text, parameters);
                    foreach (var item in CKProudctInDetailList)
                    {
                        item.InSummaryID = 0;
                        item.ServiceID = service.ID;
                        item.Save(helper);
                    }
                    helper.Commit();
                    context.Response.Write("{\"status\":true,\"ID\":" + service.ID + "}");
                }
                catch (Exception ex)
                {
                    Utility.LogHelper.WriteError("ServiceHandler", "命令: savechuli", ex);
                    helper.Rollback();
                    context.Response.Write("{\"status\":false}");
                }
            }
        }
        private void loadservicelist(HttpContext context)
        {
            try
            {
                int ServiceType = WebUtil.GetIntValue(context, "ServiceType");
                string RoomIDs = context.Request.Params["RoomIDs"];
                List<int> RoomIDList = new List<int>();
                if (!string.IsNullOrEmpty(RoomIDs))
                {
                    RoomIDList = JsonConvert.DeserializeObject<List<int>>(RoomIDs);
                }
                string PublicProjectIDs = context.Request.Params["PublicProjectIDs"];
                List<int> PublicProjectIDList = new List<int>();
                if (!string.IsNullOrEmpty(PublicProjectIDs))
                {
                    PublicProjectIDList = JsonConvert.DeserializeObject<List<int>>(PublicProjectIDs);
                }
                string ProjectIDs = context.Request.Params["ProjectIDs"];
                List<int> EqualProjectIDList = new List<int>();
                List<int> InProjectIDList = new List<int>();
                if (RoomIDList.Count == 0)
                {
                    List<int> MyProjectIDList = new List<int>();
                    if (!string.IsNullOrEmpty(ProjectIDs))
                    {
                        MyProjectIDList = JsonConvert.DeserializeObject<List<int>>(ProjectIDs).Where(p => p != 1).ToList();
                    }
                    Web.APPCode.CacheHelper.GetMyProjectListByUserID(WebUtil.GetUser(context).UserID, out EqualProjectIDList, out InProjectIDList, ProjectIDList: MyProjectIDList);
                    if (MyProjectIDList.Count == 0)
                    {
                        if (EqualProjectIDList.Count > 0)
                        {
                            EqualProjectIDList.Add(0);
                        }
                    }
                    else
                    {
                        string ALLProjectIDs = context.Request.Params["ALLProjectIDs"];
                        List<int> ALLProjectIDList = new List<int>();
                        if (!string.IsNullOrEmpty(ALLProjectIDs))
                        {
                            ALLProjectIDList = JsonConvert.DeserializeObject<List<int>>(ALLProjectIDs).Where(p => p != 1).ToList();
                        }
                        if (ALLProjectIDList.Count > 0)
                        {
                            EqualProjectIDList = ALLProjectIDList;
                        }
                    }
                }
                string ServiceStatusStr = context.Request.Params["ServiceStatus"];
                int ServiceStatus = int.MinValue;
                if (!string.IsNullOrEmpty(ServiceStatusStr))
                {
                    int.TryParse(ServiceStatusStr, out ServiceStatus);
                }
                string PayStatusStr = context.Request.Params["PayStatus"];
                int PayStatus = int.MinValue;
                if (!string.IsNullOrEmpty(PayStatusStr))
                {
                    int.TryParse(PayStatusStr, out PayStatus);
                }
                DateTime StartTime = DateTime.MinValue;
                DateTime.TryParse(context.Request.Params["StartTime"], out StartTime);
                DateTime EndTime = DateTime.MinValue;
                DateTime.TryParse(context.Request.Params["EndTime"], out EndTime);
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                string Keywords = context.Request.Params["Keywords"];
                string OrderBy = context.Request["OrderBy"];
                string SortOrder = " order by [AddTime] desc";
                if (!string.IsNullOrEmpty(OrderBy) && OrderBy.Equals("2"))
                {
                    SortOrder = " order by [ServiceNumber] desc";
                }
                int ServiceAccpetManID = WebUtil.GetIntValue(context, "ServiceAccpetManID");
                if (!string.IsNullOrEmpty(context.Request["ChooseStatus"]))
                {
                    ServiceStatus = WebUtil.GetIntValue(context, "ChooseStatus");
                }
                int ServiceRange = WebUtil.GetIntValue(context, "ServiceRange");
                bool canexport = WebUtil.GetBoolValue(context, "canexport");
                DataGrid dg = Foresight.DataAccess.ViewCustomerService.GetCustomerServiceGridByKeywords(Keywords, RoomIDList, StartTime, EndTime, ServiceStatus, PayStatus, ServiceAccpetManID, SortOrder, startRowIndex, pageSize, UserID: WebUtil.GetUser(context).UserID, EqualProjectIDList: EqualProjectIDList, InProjectIDList: InProjectIDList, ServiceType: ServiceType, ServiceRange: ServiceRange, PublicProjectIDList: PublicProjectIDList, canexport: canexport);
                if (canexport)
                {
                    string downloadurl = string.Empty;
                    string error = string.Empty;
                    bool status = APPCode.ExportHelper.DownLoadCustomerServiceData(dg, out downloadurl, out error);
                    WebUtil.WriteJson(context, new { status = status, downloadurl = downloadurl, error = error });
                    return;
                }
                string result = JsonConvert.SerializeObject(dg);
                context.Response.Write(result);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.WriteError("ServiceHandler", "命令:loadservicelist", ex);
                context.Response.Write("{\"rows\":[],\"total\":0,\"page\":0}");
            }
        }
        private void getroominfo(HttpContext context)
        {
            string results = string.Empty;
            int ProjectID = 0;
            int.TryParse(context.Request.Params["ProjectID"], out ProjectID);
            bool IsNotRoom = true;
            bool.TryParse(context.Request.Params["IsNotRoom"], out IsNotRoom);
            int OrderNumberID = 0;
            string CustomerNumber = Foresight.DataAccess.CustomerService.GetLastestCustomerServiceNumber(Foresight.DataAccess.OrderTypeNameDefine.customerservice.ToString(), ProjectID, out OrderNumberID);
            if (IsNotRoom)
            {
                var project = Foresight.DataAccess.Project.GetProject(ProjectID);
                string[] ids = project.AllParentID.Split(',');
                List<int> IDList = new List<int>();
                foreach (var id in ids)
                {
                    if (string.IsNullOrEmpty(id))
                    {
                        continue;
                    }
                    int ID = int.Parse(id);
                    IDList.Add(ID);
                }
                string ProjectName = string.Empty;
                var projectlist = Foresight.DataAccess.Project.GetProjectListByIDs(IDList).Where(p => p.ParentID == 1).ToList();
                if (projectlist.Count > 0)
                {
                    ProjectName = projectlist[0].Name;
                }
                else
                {
                    ProjectName = project.FullName.Split('-')[0];
                }
                var items = new { room = project, CustomerNumber = CustomerNumber, OrderNumberID = OrderNumberID, ProjectName = ProjectName };
                results = JsonConvert.SerializeObject(items);
            }
            else
            {
                var room = Foresight.DataAccess.ViewRoomBasic.GetViewRoomBasicByRoomID(ProjectID);
                string[] ids = room.AllParentID.Split(',');
                List<int> IDList = new List<int>();
                foreach (var id in ids)
                {
                    if (string.IsNullOrEmpty(id))
                    {
                        continue;
                    }
                    int ID = int.Parse(id);
                    IDList.Add(ID);
                }
                string ProjectName = string.Empty;
                var projectlist = Foresight.DataAccess.Project.GetProjectListByIDs(IDList).Where(p => p.ParentID == 1).ToList();
                if (projectlist.Count > 0)
                {
                    ProjectName = projectlist[0].Name;
                }
                else
                {
                    ProjectName = room.FullName.Split('-')[0];
                }
                var roomrelation = RoomPhoneRelation.GetRoomPhoneRelationsByRoomID(room.RoomID);
                var items = new { room = room, CustomerNumber = CustomerNumber, OrderNumberID = OrderNumberID, ProjectName = ProjectName, roomrelation = roomrelation };
                results = JsonConvert.SerializeObject(items);
            }
            context.Response.Write(results);
        }
        private void getservicetype(HttpContext context)
        {
            var types = Foresight.DataAccess.ServiceType.GetServiceTypes().Select(p =>
            {
                var item = new { ID = p.ID, ServiceTypeName = p.ServiceTypeName };
                return item;
            });
            var users = Foresight.DataAccess.User.GetAPPUserList().Select(p =>
            {
                var item = new { UserID = p.UserID, RealName = string.IsNullOrEmpty(p.RealName) ? p.LoginName : p.RealName };
                return item;
            });
            var tasks = Foresight.DataAccess.CustomerService_Task.GetCustomerService_Tasks().Select(p =>
            {
                var item = new { ID = p.ID, Name = p.TaskName };
                return item;
            });
            var departments = Foresight.DataAccess.CKDepartment.GetCKDepartments().Select(p =>
            {
                var item = new { ID = p.ID, Name = p.DepartmentName };
                return item;
            }).ToList();
            departments.Insert(0, new { ID = 0, Name = "不限" });
            WebUtil.WriteJson(context, new { types = types, users = users, tasks = tasks, departments = departments });
        }
        private void savecustomerservice(HttpContext context)
        {
            Foresight.DataAccess.CustomerService service = null;
            int ID = 0;
            int.TryParse(context.Request.Params["ID"], out ID);
            int ProjectID = 0;
            int.TryParse(context.Request.Params["ProjectID"], out ProjectID);
            int ServiceStatus = 0;
            int.TryParse(context.Request.Params["ServiceStatus"], out ServiceStatus);
            if (ID > 0)
            {
                service = Foresight.DataAccess.CustomerService.GetCustomerService(ID);
            }
            if (ServiceStatus < 0)
            {
                if (service == null)
                {
                    context.Response.Write("{\"status\":true,\"ID\":0}");
                    return;
                }
            }
            else
            {
                if (service == null)
                {
                    service = new Foresight.DataAccess.CustomerService();
                    service.AddTime = DateTime.Now;
                    service.AddMan = context.Request.Params["AddMan"];
                    service.AddUserID = WebUtil.GetUser(context).UserID;
                    service.ServiceStatus = ServiceStatus == 100 ? 10 : ServiceStatus;
                }
                service.ProjectID = ProjectID;
            }
            string ServiceNumber = getValue(context, "tdServiceNumber");
            var exist_service = Foresight.DataAccess.CustomerService.GetExistCustomerServiceByServiceNumber(service.ID, ServiceNumber);
            if (exist_service != null)
            {
                WebUtil.WriteJson(context, new { status = false, error = "单号重复" });
                return;
            }
            string ServiceAccpetManIDs = getValue(context, "tdAcceptMan");
            List<int> ServiceAccpetManIDList = new List<int>();
            if (!string.IsNullOrEmpty(ServiceAccpetManIDs))
            {
                if (!ServiceAccpetManIDs.StartsWith("["))
                {
                    ServiceAccpetManIDs = "[" + ServiceAccpetManIDs + "]";
                }
                ServiceAccpetManIDList = JsonConvert.DeserializeObject<List<int>>(ServiceAccpetManIDs);
            }
            service.ServiceFullName = getValue(context, "tdFullName");
            service.ProjectName = getValue(context, "tdProjectName");
            service.ServiceTypeID = getIntValue(context, "tdServiceType");
            service.ServiceTypeName = getValue(context, "hdServiceTypeName");
            service.AddUserName = getValue(context, "tdAddUserName");
            service.StartTime = getTimeValue(context, "tdStartTime");
            service.ServiceArea = getValue(context, "tdServiceArea");
            service.ServiceNumber = ServiceNumber;
            service.AddCustomerName = getValue(context, "tdAddCustomerName");
            service.AddCallPhone = getValue(context, "tdAddCallPhone");
            service.ServiceContent = getValue(context, "tdServiceContent");
            service.ServiceAppointTime = getTimeValue(context, "tdAppointTime");
            service.OrderNumberID = getIntValue(context, "hdOrderNumberID");
            service.IsRequireCost = WebUtil.GetIntValue(context, "IsRequireCost") == 1;
            service.IsRequireProduct = WebUtil.GetIntValue(context, "IsRequireProduct") == 1;
            service.IsAPPShow = WebUtil.GetIntValue(context, "IsSendAPP") == 1;
            service.TaskType = getIntValue(context, "tdTaskType");
            service.ServiceAccpetMan = getValue(context, "tdAcceptManInput");
            service.DepartmentID = getIntValue(context, "tdBelongTeamName");
            if (ServiceStatus == 1)
            {
                service.ServiceStatus = ServiceStatus;
                service.BanJieTime = WebUtil.GetDateValue(context, "CompelteTime");
            }
            else if (ServiceStatus == 100)
            {
                if (service.ServiceStatus != 3 && service.ServiceStatus != 10)
                {
                    WebUtil.WriteJson(context, new { status = false, error = "当前状态不允许派单" });
                    return;
                }
                service.IsAPPShow = true;
                service.IsAPPSend = false;
            }
            if (service.ServiceStatus == 0 && service.IsAPPShow)
            {
                if (ServiceAccpetManIDList.Count == 0)
                {
                    service.ServiceStatus = 3;
                    service.IsAPPSend = false;
                }
                else if (!service.ServiceAccpetManID.Equals(ServiceAccpetManIDs))
                {
                    service.ServiceStatus = 10;
                    service.IsAPPSend = false;
                }
            }
            else if (service.ServiceStatus == 3 || service.ServiceStatus == 10)
            {
                if (!service.IsAPPShow)
                {
                    service.ServiceStatus = 0;
                }
                else
                {
                    if (ServiceAccpetManIDList.Count > 0)
                    {
                        if (!service.ServiceAccpetManID.Equals(ServiceAccpetManIDs))
                        {
                            service.IsAPPSend = false;
                        }
                        service.ServiceStatus = 10;
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(service.ServiceAccpetManID.Replace("[", "").Replace("]", "")))
                        {
                            service.IsAPPSend = false;
                        }
                        service.ServiceStatus = 3;
                    }
                }
            }
            service.ServiceAccpetManID = ServiceAccpetManIDs;
            if (service.IsRequireCost)
            {
                service.HandelFee = getValue(context, "tdHandelFee");
                service.TotalFee = getDecimalValue(context, "tdTotalFee");
            }
            else
            {
                service.HandelFee = "0";
                service.TotalFee = 0;
            }
            List<CustomerService_Accpet> serviceaccpet_list = new List<CustomerService_Accpet>();
            if (ServiceAccpetManIDList.Count > 0 && !service.IsAPPSend)
            {
                foreach (var ServiceAccpetManID in ServiceAccpetManIDList)
                {
                    if (ServiceAccpetManID <= 0)
                    {
                        continue;
                    }
                    var serviceaccpet = new Foresight.DataAccess.CustomerService_Accpet();
                    serviceaccpet.AccpetManID = ServiceAccpetManID;
                    serviceaccpet.AppointTime = service.ServiceAppointTime;
                    serviceaccpet.AddTime = DateTime.Now;
                    serviceaccpet_list.Add(serviceaccpet);
                }
            }
            List<Foresight.DataAccess.CustomerServiceAttach> attachlist = new List<Foresight.DataAccess.CustomerServiceAttach>();
            int WechatServiceID = WebUtil.GetIntValue(context, "WechatServiceID");
            if (WechatServiceID > 0)
            {
                var wechat_service = Foresight.DataAccess.Wechat_Service.GetWechat_Service(WechatServiceID);
                if (wechat_service != null)
                {
                    service.WechatServiceID = wechat_service.ID;
                    service.ServiceFrom = wechat_service.ServiceFrom;
                    var wechat_service_attachlist = Foresight.DataAccess.Wechat_ServiceImg.GetWechat_ServiceImgList(wechat_service.ID);
                    foreach (var item in wechat_service_attachlist)
                    {
                        Foresight.DataAccess.CustomerServiceAttach attach = new Foresight.DataAccess.CustomerServiceAttach();
                        attach.FileOriName = item.FileName;
                        attach.AttachedFilePath = item.Large;
                        attach.AddTime = DateTime.Now;
                        attachlist.Add(attach);
                    }
                }
            }
            if (string.IsNullOrEmpty(service.ServiceFrom))
            {
                service.ServiceFrom = Utility.EnumModel.WechatServiceFromDefine.system.ToString();
            }
            HttpFileCollection uploadFiles = context.Request.Files;
            for (int i = 0; i < uploadFiles.Count; i++)
            {
                HttpPostedFile postedFile = uploadFiles[i];
                string fileOriName = postedFile.FileName;
                if (fileOriName != "" && fileOriName != null)
                {
                    string extension = System.IO.Path.GetExtension(fileOriName).ToLower();
                    string fileName = DateTime.Now.ToFileTime().ToString() + extension;
                    string filepath = "/upload/CustomerService/";
                    string rootPath = HttpContext.Current.Server.MapPath("~" + filepath);
                    if (!System.IO.Directory.Exists(rootPath))
                    {
                        System.IO.Directory.CreateDirectory(rootPath);
                    }
                    string Path = rootPath + fileName;
                    postedFile.SaveAs(Path);
                    Foresight.DataAccess.CustomerServiceAttach attach = new Foresight.DataAccess.CustomerServiceAttach();
                    attach.FileOriName = fileOriName;
                    attach.AttachedFilePath = filepath + fileName;
                    attach.AddTime = DateTime.Now;
                    attachlist.Add(attach);
                }
            }
            List<CKProudctInDetail> CKProudctInDetailList = new List<CKProudctInDetail>();
            if (service.IsRequireProduct)
            {
                string ProductRows = context.Request.Params["ProductRows"];
                List<ProductRow> ProductRowList = new List<ProductRow>();
                if (!string.IsNullOrEmpty(ProductRows))
                {
                    ProductRowList = JsonConvert.DeserializeObject<List<ProductRow>>(ProductRows);
                }
                foreach (var item in ProductRowList)
                {
                    CKProudctInDetail ckProudctInDetail = new CKProudctInDetail();
                    ckProudctInDetail.ProductID = item.ProductID;
                    ckProudctInDetail.UnitPrice = item.UnitPrice;
                    ckProudctInDetail.InTotalCount = item.InTotalCount;
                    ckProudctInDetail.InTotalPrice = item.InTotalPrice;
                    ckProudctInDetail.AddTime = DateTime.Now;
                    ckProudctInDetail.AddMan = context.Request.Params["AddMan"];
                    CKProudctInDetailList.Add(ckProudctInDetail);
                }
            }

            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    service.Save(helper);
                    foreach (var serviceaccpet in serviceaccpet_list)
                    {
                        serviceaccpet.ServiceID = service.ID;
                        serviceaccpet.Save(helper);
                    }
                    foreach (var item in attachlist)
                    {
                        item.ServiceID = service.ID;
                        item.Save(helper);
                    }
                    string cmdtext = "delete from [CKProudctInDetail] where [ServiceID]=@ServiceID";
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    parameters.Add(new SqlParameter("@ServiceID", service.ID));
                    helper.Execute(cmdtext, CommandType.Text, parameters);
                    foreach (var item in CKProudctInDetailList)
                    {
                        item.InSummaryID = 0;
                        item.ServiceID = service.ID;
                        item.Save(helper);
                    }
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    Utility.LogHelper.WriteError("ServiceHandler", "命令: savecustomerservice", ex);
                    helper.Rollback();
                    context.Response.Write("{\"status\":false}");
                    return;
                }
            }
            var config = new Utility.SiteConfig();
            if (service.IsAPPShow && !service.IsAPPSend && !string.IsNullOrEmpty(config.JPushKey_User))
            {
                var company = WebUtil.GetCompany(HttpContext.Current);
                string title = company == null ? "永友网络" : company.CompanyName;
                var user = WebUtil.GetUser(context);
                string ErrorMsg = "";
                APPCode.JPushHelper.SendJpushMsgByServiceID(service.ID, out ErrorMsg, title: title, SendUserID: user.UserID, SendUserName: user.RealName);
            }
            WebUtil.WriteJson(context, new { status = true, ID = service.ID });
        }
        private string getValue(HttpContext context, string name)
        {
            string PostName = "ctl00$content$";
            return context.Request.Params[PostName + name];
        }
        private int getIntValue(HttpContext context, string name)
        {
            int result = 0;
            int.TryParse(getValue(context, name), out result);
            return result;
        }
        private DateTime getTimeValue(HttpContext context, string name)
        {
            DateTime result = DateTime.MinValue;
            DateTime.TryParse(getValue(context, name), out result);
            return result;
        }
        private decimal getDecimalValue(HttpContext context, string name)
        {
            decimal result = 0;
            decimal.TryParse(getValue(context, name), out result);
            return result;
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