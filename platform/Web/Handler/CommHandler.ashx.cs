using Foresight.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Foresight.DataAccess.Ui;
using Foresight.DataAccess.Framework;
using System.Data.SqlClient;
using System.Data;
using Utility;
using System.Web.SessionState;
using System.Web.Security;
using System.Configuration;

namespace Web.Handler
{
    /// <summary>
    /// CommHandler 的摘要说明
    /// </summary>
    public class CommHandler : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string visit = context.Request.Params["visit"];
            if (string.IsNullOrEmpty(visit))
            {
                LogHelper.WriteDebug("CommHandler", "visit为空");
                context.Response.Write(null);
                return;
            }
            visit = visit.ToLower();
            try
            {
                switch (visit)
                {
                    case "loadtree":
                        LoadTree(context);
                        break;
                    case "loadinoutsource":
                        LoadInoutSource(context);
                        break;
                    case "saveresource":
                        SaveResource(context);
                        break;
                    case "saveresourceout":
                        SaveResourceOut(context);
                        break;
                    case "editresourceout":
                        EditResourceOut(context);
                        break;
                    case "loadallcommbox":
                        LoadAllCommbox(context);
                        break;
                    case "checkinstatus":
                        CheckInStatus(context);
                        break;
                    case "cancelsource":
                        CancelSource(context);
                        break;
                    case "chargebusinessbalance":
                        ChargeBusinessBalance(context);
                        break;
                    case "chargecarrierbalance":
                        ChargeCarrierBalance(context);
                        break;
                    case "savebusiness":
                        SaveBusiness(context);
                        break;
                    case "saveproduct":
                        SaveProduct(context);
                        break;
                    case "savespec":
                        SaveSpec(context);
                        break;
                    case "saveinventoryinfo":
                        SaveInventoryInfo(context);
                        break;
                    case "savecarriergroup":
                        SaveCarrierGroup(context);
                        break;
                    case "savecarrier":
                        SaveCarrier(context);
                        break;
                    case "deletetree":
                        DeleteTree(context);
                        break;
                    case "tonextmonth":
                        ToNextMonth(context);
                        break;
                    case "printinmgr":
                        PrintInMgr(context);
                        break;
                    case "loadinoutsummary":
                        LoadInOutSummary(context);
                        break;
                    case "viewprintinmgrtable":
                        ViewPrintInMgrTable(context);
                        break;
                    case "getfeecategorylist":
                        getfeecategorylist(context);
                        break;
                    case "loadfeecategory":
                        loadfeecategory(context);
                        break;
                    case "savefeecategory":
                        savefeecategory(context);
                        break;
                    case "deletefeecategory":
                        deletefeecategory(context);
                        break;
                    case "checkwarningcontract":
                        checkwarningcontract(context);
                        break;
                    case "loadownfeecategory":
                        loadownfeecategory(context);
                        break;
                    case "saveownfeecategory":
                        saveownfeecategory(context);
                        break;
                    case "deleteownfeecategory":
                        deleteownfeecategory(context);
                        break;
                    case "forcelogout":
                        forcelogout(context);
                        break;
                    case "socketinit":
                        socketinit(context);
                        break;
                    case "loadinsidecustomergrid":
                        loadinsidecustomergrid(context);
                        break;
                    case "saveinsidecustomer":
                        saveinsidecustomer(context);
                        break;
                    case "deleteinsidecustomer":
                        deleteinsidecustomer(context);
                        break;
                    case "loadincustomerattachs":
                        loadincustomerattachs(context);
                        break;
                    case "deleteinsidecustomerfile":
                        deleteinsidecustomerfile(context);
                        break;
                    case "saveinsidecustomerattached":
                        saveinsidecustomerattached(context);
                        break;
                    case "getnextinsidecustomer":
                        getnextinsidecustomer(context);
                        break;
                    case "genjininsidecustomer":
                        genjininsidecustomer(context);
                        break;
                    case "savemoreinsidecustomer":
                        savemoreinsidecustomer(context);
                        break;
                    case "saveoperationlog":
                        saveoperationlog(context);
                        break;
                    case "getsysmessage":
                        getsysmessage(context);
                        break;
                    case "gethomedatasource":
                        gethomedatasource(context);
                        break;
                    case "grabwechatchat":
                        grabwechatchat(context);
                        break;
                    case "clearcache":
                        clearcache(context);
                        break;
                    default:
                        WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "Unkown Visit: " + visit);
                        break;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("CommHandler", "visit: " + visit, ex);
                context.Response.Write("{\"status\":false}");
            }
        }
        private void clearcache(HttpContext context)
        {
            Web.APPCode.CacheHelper.ClearCache();
            WebUtil.WriteJson(context, new { status = true });
        }
        private void grabwechatchat(HttpContext context)
        {
            string template_file_path = WebUtil.GetWechatTemplatePath(new Utility.SiteConfig().kftztx);
            if (string.IsNullOrEmpty(template_file_path))
            {
                WebUtil.WriteJson(context, new { status = false, error = "您为开通客服功能" });
                return;
            }
            int UserID = WebUtil.GetUser(context).UserID;
            int ID = WebUtil.GetIntValue(context, "ID");
            var data = Wechat_ChatRequest.GetWechat_ChatRequest(ID);
            if (data == null)
            {
                WebUtil.WriteJson(context, new { status = false, error = "聊天已被删除" });
                return;
            }
            string errormsg = string.Empty;
            var service_user = new Wechat_ServiceUser();
            bool status = APPCode.WeixinHelper.GrabWechat_Chat(UserID, data, out errormsg, out service_user);
            if (status)
            {
                var sendbackmessage = APPCode.WeixinHelper.SendTemPlateMessage(template_file_path,
                            data.OpenID,
                            new List<string> 
                              { 
                                  "客服人员"+service_user.NickName+"正在为您服务", 
                                  "未知", 
                                  "在线客服", 
                                  "服务中",
                                  DateTime.Now.ToString("yyy-MM-dd HH:mm:ss"),
                                  ""
                              }, "");
            }
            WebUtil.WriteJson(context, new { status = status, error = errormsg });
        }
        private void gethomedatasource(HttpContext context)
        {
            if (WebUtil.GetContextPath().Contains("localhost"))
            {
                WebUtil.WriteJson(context, new { status = false });
                return;
            }
            Foresight.DataAccess.User user = null;
            try
            {
                user = WebUtil.GetUser(context);
            }
            catch (Exception)
            {
                WebUtil.WriteJson(context, new { status = false });
                return;
            }
            if (user == null)
            {
                WebUtil.WriteJson(context, new { status = false });
                return;
            }
            int UserID = user.UserID;
            int msgcount = Foresight.DataAccess.SystemMsg.GetUnReadSystemMsgCount();
            List<int> RoomIDList = new List<int>();
            List<int> ProjectIDList = WebUtil.GetMyProjects(user.UserID).Where(p => p.ID != 1).Select(p => p.ID).ToList();
            var daoqi_contractcount = Foresight.DataAccess.Contract.GetALLWaringingContractsCount(RoomIDList, ProjectIDList, UserID: UserID);

            var shoufei_contract_list = RoomFeeAnalysis.GetRoomFeeAnalysisListByRoomID(RoomIDList, ProjectIDList, DateTime.MinValue, DateTime.MinValue, new int[] { }, -1, new List<int>(), false, true, 0, false, string.Empty, false, DivideID: 0, RoomStateList: new List<int>(), UserID: UserID, IsContractWarning: true, RequireOrderBy: false);
            shoufei_contract_list = shoufei_contract_list.Where(p => p.TotalCost > 0).ToArray();
            int shoufei_contractcount = shoufei_contract_list.Length;

            List<int> EqualProjectIDList = new List<int>();
            List<int> InProjectIDList = new List<int>();
            Web.APPCode.CacheHelper.GetMyProjectListByUserID(user.UserID, out EqualProjectIDList, out InProjectIDList);
            if (EqualProjectIDList.Count > 0)
            {
                EqualProjectIDList.Add(0);
            }
            int service_count = 0;
            Foresight.DataAccess.CustomerService.GetCustomerServiceListByEqualProjectID(RoomIDList, 100, out service_count, UserID, EqualProjectIDList, InProjectIDList, GetCount: true);

            int total_count = daoqi_contractcount + shoufei_contractcount + service_count;

            WebUtil.WriteJson(context, new { status = true, msgcount = msgcount, daoqi_contractcount = daoqi_contractcount, shoufei_contractcount = shoufei_contractcount, service_count = service_count, total_count = total_count });
        }
        private void getsysmessage(HttpContext context)
        {
            if (WebUtil.GetContextPath().Contains("localhost"))
            {
                WebUtil.WriteJson(context, new { status = false });
                return;
            }
            Foresight.DataAccess.User user = null;
            try
            {
                user = WebUtil.GetUser(context);
            }
            catch (Exception)
            {
                WebUtil.WriteJson(context, new { status = false });
                return;
            }
            if (user == null)
            {
                WebUtil.WriteJson(context, new { status = false });
                return;
            }
            int UserID = user.UserID;

            int unread_customercount = Foresight.DataAccess.CustomerService.GetUnReadCustomerServiceCount();
            int unread_ordercount = 0;
            int unread_orderrefundcount = 0;
            var config = new SiteConfig();
            if (config.IsMallOn)
            {
                unread_ordercount = Mall_Order.GetUnReadMall_OrderNewCount();
                unread_orderrefundcount = Mall_Order.GetUnReadMall_OrderRefundCount();
            }
            var chat_user = Wechat_ChatRequest.GetWechat_ServiceUserByUserID(user.UserID);
            int wechat_chat_ready_count = 0;
            if (chat_user != null)
            {
                wechat_chat_ready_count = Wechat_ChatRequest.GetWechat_ChatRequestReadyCount();
            }
            WebUtil.WriteJson(context, new { status = true, unread_customercount = unread_customercount, unread_ordercount = unread_ordercount, unread_orderrefundcount = unread_orderrefundcount, wechat_chat_ready_count = wechat_chat_ready_count });
        }
        private void saveoperationlog(HttpContext context)
        {
            string op = context.Request["op"];
            int PrintID = WebUtil.GetIntValue(context, "PrintID");
            var printRoomFeeHistory = Foresight.DataAccess.PrintRoomFeeHistory.GetPrintRoomFeeHistory(PrintID);
            if (op != null && printRoomFeeHistory != null)
            {
                if (op.Equals(Utility.EnumModel.OperationModule.HistoryPrint.ToString()))
                {
                    #region 补打历史单据
                    APPCode.CommHelper.SaveOperationLog("订单号" + printRoomFeeHistory.PrintNumber + "补打单据", Utility.EnumModel.OperationModule.HistoryPrint.ToString(), "补打单据", printRoomFeeHistory.ID.ToString(), "PrintRoomFeeHistory");
                    #endregion
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void savemoreinsidecustomer(HttpContext context)
        {
            string ListStr = context.Request.Params["List"];
            Foresight.DataAccess.InsideCustomer customer = JsonConvert.DeserializeObject<Foresight.DataAccess.InsideCustomer>(ListStr);
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(context.Request["IDList"]);
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    foreach (var ID in IDList)
                    {
                        var customerNew = Foresight.DataAccess.InsideCustomer.GetInsideCustomer(ID, helper);
                        if (customerNew != null)
                        {
                            if (!string.IsNullOrEmpty(customer.IndustryName))
                            {
                                customerNew.IndustryName = customer.IndustryName;
                            }
                            if (!string.IsNullOrEmpty(customer.CategoryName))
                            {
                                customerNew.CategoryName = customer.CategoryName;
                            }
                            if (!string.IsNullOrEmpty(customer.Interesting))
                            {
                                customerNew.Interesting = customer.Interesting;
                            }
                            if (!string.IsNullOrEmpty(customer.CustomerBelonger))
                            {
                                customerNew.CustomerBelonger = customer.CustomerBelonger;
                            }
                            if (!string.IsNullOrEmpty(customer.Region))
                            {
                                customerNew.Region = customer.Region;
                            }
                            if (!string.IsNullOrEmpty(customer.Province))
                            {
                                customerNew.Province = customer.Province;
                            }
                            if (!string.IsNullOrEmpty(customer.City))
                            {
                                customerNew.City = customer.City;
                            }
                            if (!string.IsNullOrEmpty(customer.QQGroupInvitation))
                            {
                                customerNew.QQGroupInvitation = customer.QQGroupInvitation;
                            }
                            if (!string.IsNullOrEmpty(customer.WechaGroupInvitation))
                            {
                                customerNew.WechaGroupInvitation = customer.WechaGroupInvitation;
                            }
                            customerNew.Save(helper);
                        }
                    }
                    helper.Commit();
                    context.Response.Write("{\"status\":true}");
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError("CommHandler", "visit: savemoreinsidecustomer", ex);
                    context.Response.Write("{\"status\":false}");
                }
            }
        }
        private void genjininsidecustomer(HttpContext context)
        {
            string ListStr = context.Request.Params["List"];
            Foresight.DataAccess.InsideCustomer customer = JsonConvert.DeserializeObject<Foresight.DataAccess.InsideCustomer>(ListStr);
            List<Foresight.DataAccess.InsideCustomerAttach> attachlist = new List<Foresight.DataAccess.InsideCustomerAttach>();
            HttpFileCollection uploadFiles = context.Request.Files;
            for (int i = 0; i < uploadFiles.Count; i++)
            {
                HttpPostedFile postedFile = uploadFiles[i];
                string fileOriName = postedFile.FileName;
                if (fileOriName != "" && fileOriName != null)
                {
                    string extension = System.IO.Path.GetExtension(fileOriName).ToLower();
                    string fileName = DateTime.Now.ToFileTime().ToString() + extension;
                    string filepath = "/upload/Customer/";
                    string rootPath = HttpContext.Current.Server.MapPath("~" + filepath);
                    if (!System.IO.Directory.Exists(rootPath))
                    {
                        System.IO.Directory.CreateDirectory(rootPath);
                    }
                    string Path = rootPath + fileName;
                    postedFile.SaveAs(Path);
                    Foresight.DataAccess.InsideCustomerAttach attach = new Foresight.DataAccess.InsideCustomerAttach();
                    attach.FileOriName = fileOriName;
                    attach.AttachedFilePath = filepath + fileName;
                    attach.AddTime = DateTime.Now;
                    attachlist.Add(attach);
                }
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    var customerNew = Foresight.DataAccess.InsideCustomer.GetInsideCustomer(customer.ID, helper);
                    if (customerNew != null)
                    {

                        customerNew.CustomerName = customer.CustomerName;
                        customerNew.CategoryName = customer.CategoryName;
                        customerNew.Interesting = customer.Interesting;
                        customerNew.ContactMan = customer.ContactMan;
                        customerNew.ContactPhone = customer.ContactPhone;
                        customerNew.QQNo = customer.QQNo;
                        customerNew.QQGroupInvitation = customer.QQGroupInvitation;
                        customerNew.WechatNo = customer.WechatNo;
                        customerNew.WechaGroupInvitation = customer.WechaGroupInvitation;
                        customerNew.OtherContactMan = customer.OtherContactMan;
                        if (!string.IsNullOrEmpty(customer.NewFollowup))
                        {
                            var historyFollowup = new Foresight.DataAccess.InsideCustomer_Followup();
                            historyFollowup.FollowupDate = customerNew.NewFollowupDate;
                            historyFollowup.FollowupContent = customerNew.NewFollowup;
                            historyFollowup.InsideCustomerID = customerNew.ID;
                            historyFollowup.Save(helper);
                            customerNew.NewFollowup = customer.NewFollowup;
                            customerNew.NewFollowupDate = DateTime.Now;
                        }
                        customerNew.BusinessStage = customer.BusinessStage;
                        customerNew.Cost = customer.Cost;
                        customerNew.DealProbably = customer.DealProbably;
                        customerNew.Remark = customer.Remark;
                        customerNew.Save(helper);
                        foreach (var item in attachlist)
                        {
                            item.InsideCustomerID = customerNew.ID;
                            item.Save(helper);
                        }
                    }
                    helper.Commit();
                    context.Response.Write("{\"status\":true}");
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError("CommHandler", "visit: genjininsidecustomer", ex);
                    context.Response.Write("{\"status\":false}");
                }
            }
        }
        private void getnextinsidecustomer(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            var customer = Foresight.DataAccess.InsideCustomer.GetNextInsideCustomer(ID);
            int NextID = 0;
            if (customer != null)
            {
                NextID = customer.ID;
            }
            WebUtil.WriteJson(context, new { status = true, ID = NextID });
        }
        private void saveinsidecustomerattached(HttpContext context)
        {
            Foresight.DataAccess.InsideCustomer customer = null;
            int InsideCustomerID = 0;
            int.TryParse(context.Request.Params["InsideCustomerID"], out InsideCustomerID);
            int ProjectID = 0;
            int.TryParse(context.Request.Params["ProjectID"], out ProjectID);
            int ServiceStatus = 0;
            int.TryParse(context.Request.Params["ServiceStatus"], out ServiceStatus);
            if (InsideCustomerID > 0)
            {
                customer = Foresight.DataAccess.InsideCustomer.GetInsideCustomer(InsideCustomerID);
            }
            if (customer == null)
            {
                WebUtil.WriteJson(context, new { status = true });
                return;
            }
            List<Foresight.DataAccess.InsideCustomerAttach> attachlist = new List<Foresight.DataAccess.InsideCustomerAttach>();
            HttpFileCollection uploadFiles = context.Request.Files;
            for (int i = 0; i < uploadFiles.Count; i++)
            {
                HttpPostedFile postedFile = uploadFiles[i];
                string fileOriName = postedFile.FileName;
                if (fileOriName != "" && fileOriName != null)
                {
                    string extension = System.IO.Path.GetExtension(fileOriName).ToLower();
                    string fileName = DateTime.Now.ToFileTime().ToString() + extension;
                    string filepath = "/upload/Customer/";
                    string rootPath = HttpContext.Current.Server.MapPath("~" + filepath);
                    if (!System.IO.Directory.Exists(rootPath))
                    {
                        System.IO.Directory.CreateDirectory(rootPath);
                    }
                    string Path = rootPath + fileName;
                    postedFile.SaveAs(Path);
                    Foresight.DataAccess.InsideCustomerAttach attach = new Foresight.DataAccess.InsideCustomerAttach();
                    attach.FileOriName = fileOriName;
                    attach.AttachedFilePath = filepath + fileName;
                    attach.AddTime = DateTime.Now;
                    attachlist.Add(attach);
                }
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    foreach (var item in attachlist)
                    {
                        item.InsideCustomerID = customer.ID;
                        item.Save(helper);
                    }
                    helper.Commit();
                    context.Response.Write("{\"status\":true,\"ID\":" + customer.ID + "}");
                }
                catch (Exception ex)
                {
                    Utility.LogHelper.WriteError("CommHandler", "命令: saveinsidecustomerattached", ex);
                    helper.Rollback();
                    context.Response.Write("{\"status\":false}");
                }
            }
        }
        private void deleteinsidecustomerfile(HttpContext context)
        {
            int ID = 0;
            int.TryParse(context.Request.Params["ID"], out ID);
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    string cmdtext = "delete from [InsideCustomerAttach] where ID=@ID";
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    parameters.Add(new SqlParameter("@ID", ID));
                    helper.Execute(cmdtext, CommandType.Text, parameters);
                    helper.Commit();
                    context.Response.Write("{\"status\":true}");
                }
                catch (Exception ex)
                {
                    Utility.LogHelper.WriteError("CommHandler", "命令: deleteinsidecustomerfile", ex);
                    helper.Rollback();
                    context.Response.Write("{\"status\":false}");
                }
            }
        }
        private void loadincustomerattachs(HttpContext context)
        {
            int ID = int.Parse(context.Request.Params["ID"]);
            var list = Foresight.DataAccess.InsideCustomerAttach.GetInsideCustomerAttachList(ID);
            var items = list.Select(p =>
            {
                var dic = p.ToJsonObject();
                dic["AttachedFilePath"] = string.IsNullOrEmpty(p.AttachedFilePath) ? string.Empty : WebUtil.GetContextPath() + p.AttachedFilePath;
                return dic;
            });
            context.Response.Write(JsonConvert.SerializeObject(items));
        }
        private void deleteinsidecustomer(HttpContext context)
        {
            string ids = context.Request.Params["IDList"];
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(ids);
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    string cmdtext = "delete from [InsideCustomer] where ID in (" + string.Join(",", IDList.ToArray()) + ") and [CategoryName]='无效客户';";
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    helper.Execute(cmdtext, CommandType.Text, parameters);
                    helper.Commit();
                    context.Response.Write("{\"status\":true}");
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    Utility.LogHelper.WriteError("CommHandler", "命令: deleteinsidecustomer", ex);
                    context.Response.Write("{\"status\":false}");
                }
            }
        }
        private void saveinsidecustomer(HttpContext context)
        {
            string ListStr = context.Request.Params["List"];
            List<Foresight.DataAccess.InsideCustomer> list = JsonConvert.DeserializeObject<List<Foresight.DataAccess.InsideCustomer>>(ListStr);
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    foreach (var customer in list)
                    {
                        var customerNew = Foresight.DataAccess.InsideCustomer.GetInsideCustomer(customer.ID, helper);
                        if (customerNew == null)
                        {
                            continue;
                        }
                        var historyFollowup = new Foresight.DataAccess.InsideCustomer_Followup();
                        historyFollowup.FollowupDate = customerNew.NewFollowupDate;
                        historyFollowup.FollowupContent = customerNew.NewFollowup;
                        historyFollowup.InsideCustomerID = customerNew.ID;
                        historyFollowup.Save(helper);
                        customerNew.CustomerName = customer.CustomerName;
                        customerNew.IndustryName = customer.IndustryName;
                        customerNew.CategoryName = customer.CategoryName;
                        customerNew.Interesting = customer.Interesting;
                        customerNew.ContactMan = customer.ContactMan;
                        customerNew.ContactPhone = customer.ContactPhone;
                        customerNew.QQNo = customer.QQNo;
                        customerNew.QQGroupInvitation = customer.QQGroupInvitation;
                        customerNew.WechatNo = customer.WechatNo;
                        customerNew.WechaGroupInvitation = customer.WechaGroupInvitation;
                        customerNew.OtherContactMan = customer.OtherContactMan;
                        customerNew.CustomerBelonger = customer.CustomerBelonger;
                        customerNew.NewFollowup = customer.NewFollowup;
                        customerNew.NewFollowupDate = DateTime.Now;
                        customerNew.Region = customer.Region;
                        customerNew.Province = customer.Province;
                        customerNew.City = customer.City;
                        customerNew.BusinessStage = customer.BusinessStage;
                        customerNew.Cost = customer.Cost;
                        customerNew.DealProbably = customer.DealProbably;
                        customerNew.Remark = customer.Remark;
                        customerNew.Save(helper);
                    }
                    helper.Commit();
                    context.Response.Write("{\"status\":true}");
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError("CommHandler", "visit: saveinsidecustomer", ex);
                    context.Response.Write("{\"status\":false}");
                }
            }
        }
        private void loadinsidecustomergrid(HttpContext context)
        {
            try
            {
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                string CustomerBelonger = context.Request["CustomerBelonger"];
                DateTime StartTime = WebUtil.GetDateValue(context, "StartTime");
                DateTime EndTime = WebUtil.GetDateValue(context, "EndTime");
                string Region = context.Request["Region"];
                string Province = context.Request["Province"];
                string City = context.Request["City"];
                string CustomerName = context.Request["CustomerName"];
                string IndustryName = context.Request["IndustryName"];
                string CategoryName = context.Request["CategoryName"];
                string Interesting = context.Request["Interesting"];
                bool canexport = WebUtil.GetBoolValue(context, "canexport");
                DataGrid dg = Foresight.DataAccess.InsideCustomer.GeInsideCustomerGrid(CustomerBelonger, StartTime, EndTime, Region, Province, City, CustomerName, IndustryName, CategoryName, Interesting, "order by AddTime desc", startRowIndex, pageSize, canexport: canexport);
                if (canexport)
                {
                    string downloadurl = string.Empty;
                    string error = string.Empty;
                    bool status = APPCode.ExportHelper.DownLoadInsideCustomerData(dg, out downloadurl, out error);
                    WebUtil.WriteJson(context, new { status = status, downloadurl = downloadurl, error = error });
                    return;
                }
                string result = JsonConvert.SerializeObject(dg);
                context.Response.Write(result);
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("CommHandler", "visit: loadinsidecustomergrid", ex);
                context.Response.Write("{\"rows\":[],\"total\":0,\"page\":0}");
            }
        }
        private void socketinit(HttpContext context)
        {
            WebUtil.WriteJson(context, new { loginname = Web.WebUtil.GetUserLoginFullName(context) + Web.WebUtil.GetUser(context).LoginName, guid = HttpContext.Current.User.Identity.Name });
        }
        private void forcelogout(HttpContext context)
        {
            Web.APPCode.CacheHelper.ClearCache();
            FormsAuthentication.SignOut();
            WebUtil.WriteJson(context, new { status = true });
        }
        private void deleteownfeecategory(HttpContext context)
        {
            string ids = context.Request.Params["ids"];
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(ids);
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    string cmdtext = "delete from [OwnFeeCategory] where ID in (" + string.Join(",", IDList.ToArray()) + ")";
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    helper.Execute(cmdtext, CommandType.Text, parameters);
                    helper.Commit();
                    context.Response.Write("{\"status\":true}");
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    Utility.LogHelper.WriteError("CommHandler", "命令: deleteownfeecategory", ex);
                    context.Response.Write("{\"status\":false}");
                }
            }
        }
        private void saveownfeecategory(HttpContext context)
        {
            string id = context.Request.Params["id"];
            string name = context.Request.Params["name"];
            string sortorder = context.Request.Params["sortorder"];
            Foresight.DataAccess.OwnFeeCategory category = null;
            if (!string.IsNullOrEmpty(id))
            {
                category = Foresight.DataAccess.OwnFeeCategory.GetOwnFeeCategory(int.Parse(id));
            }
            if (category == null)
            {
                category = new Foresight.DataAccess.OwnFeeCategory();
            }
            category.CategoryName = name;
            int _sortorder = int.MinValue;
            int.TryParse(sortorder, out _sortorder);
            category.SortOrder = _sortorder;
            category.Save();
            context.Response.Write("{\"status\":true}");
        }
        private void loadownfeecategory(HttpContext context)
        {
            try
            {
                var list = Foresight.DataAccess.OwnFeeCategory.GetOwnFeeCategories().OrderBy(p => p.SortOrder).ToList();
                var dg = new DataGrid();
                dg.rows = list;
                dg.total = list.Count;
                dg.page = 1;
                string result = JsonConvert.SerializeObject(dg);
                context.Response.Write(result);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.WriteError("CommHandler", "命令: loadownfeecategory", ex);
                context.Response.Write("{\"rows\":[],\"total\":0,\"page\":0}");
            }
        }
        private void checkwarningcontract(HttpContext context)
        {
            int totalcount = Foresight.DataAccess.Contract.GetALLWaringingContractsCount(new List<int>(), new List<int>(), UserID: WebUtil.GetUser(context).UserID);
            WebUtil.WriteJson(context, new { status = true, totalcount = totalcount });
        }
        private void getfeecategorylist(HttpContext context)
        {
            try
            {
                var list = Foresight.DataAccess.Category.GetCategories().OrderBy(p => p.SortOrder).ToList();
                string result = JsonConvert.SerializeObject(list);
                context.Response.Write(result);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.WriteError("ServiceHandler", "命令: getfeecategorylist", ex);
                context.Response.Write("{\"rows\":[],\"total\":0,\"page\":0}");
            }
        }
        private void deletefeecategory(HttpContext context)
        {
            string ids = context.Request.Params["ids"];
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(ids);
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    foreach (var ID in IDList)
                    {
                        var summary = Foresight.DataAccess.ChargeSummary.GetChargeSummaryByCategoryID(ID, helper);
                        if (summary != null)
                        {
                            helper.Rollback();
                            WebUtil.WriteJson(context, new { status = false, error = "费项标准已使用该费项类别，禁止删除" });
                            return;
                        }
                    }
                    string cmdtext = "delete from [Category] where ID in (" + string.Join(",", IDList.ToArray()) + ")";
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    helper.Execute(cmdtext, CommandType.Text, parameters);
                    helper.Commit();
                    context.Response.Write("{\"status\":true}");
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    Utility.LogHelper.WriteError("CommHandler", "命令: deletefeecategory", ex);
                    context.Response.Write("{\"status\":false}");
                }
            }
        }
        private void savefeecategory(HttpContext context)
        {
            string id = context.Request.Params["id"];
            string name = context.Request.Params["name"];
            string sortorder = context.Request.Params["sortorder"];
            Foresight.DataAccess.Category category = null;
            if (!string.IsNullOrEmpty(id))
            {
                category = Foresight.DataAccess.Category.GetCategory(int.Parse(id));
            }
            if (category == null)
            {
                category = new Foresight.DataAccess.Category();
            }
            category.Name = name;
            int _sortorder = int.MinValue;
            int.TryParse(sortorder, out _sortorder);
            category.SortOrder = _sortorder;
            category.Save();
            context.Response.Write("{\"status\":true}");
        }
        private void loadfeecategory(HttpContext context)
        {
            try
            {
                var list = Foresight.DataAccess.Category.GetCategories().OrderBy(p => p.SortOrder).ToList();
                var dg = new DataGrid();
                dg.rows = list;
                dg.total = list.Count;
                dg.page = 1;
                string result = JsonConvert.SerializeObject(dg);
                context.Response.Write(result);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.WriteError("ServiceHandler", "命令: loadfeecategory", ex);
                context.Response.Write("{\"rows\":[],\"total\":0,\"page\":0}");
            }
        }
        private void ViewPrintInMgrTable(HttpContext context)
        {
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(context.Request.Params["IDs"]);
            var list = Foresight.DataAccess.ViewWarehouseInOut.GetViewWarehouseInOutListByIDList(IDList);
            var footer = Foresight.DataAccess.ViewWarehouseInOut.GetViewWarehouseInOutSummaryByIDList(IDList);
            list.Add(footer[0]);
            var printhistory = Foresight.DataAccess.PrintHistory.GetPrintHistory(list[0].PrintID);
            string ChargeTime = string.Empty;
            if (printhistory != null)
            {
                ChargeTime = printhistory.ChargeTime == DateTime.MinValue ? "" : printhistory.ChargeTime.ToString("yyyy-MM-dd HH:mm:ss");
            }
            var items = new
            {
                list = list,
                ColdCost = footer[0].ColdCost == decimal.MinValue ? 0 : footer[0].ColdCost,
                MoveCost = footer[0].MoveCost == decimal.MinValue ? 0 : footer[0].MoveCost,
                CarrierMoveCost = footer[0].CarrierMoveCost == decimal.MinValue ? 0 : footer[0].CarrierMoveCost,
                ChargeTime = ChargeTime
            };
            string results = JsonConvert.SerializeObject(items);
            context.Response.Write(results);
        }
        private void LoadInOutSummary(HttpContext context)
        {
            try
            {
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                int BusinessID = GetIntValue(context, "BusinessID");
                int CarrierID = GetIntValue(context, "CarrierID");
                int ProductID = GetIntValue(context, "ProductID");
                int SpecInfoID = GetIntValue(context, "SpecInfoID");
                int InventoryInfoID = GetIntValue(context, "InventoryInfoID");
                int CarrierGroupID = GetIntValue(context, "CarrierGroupID");
                DateTime StartTime = GetDateValue(context, "StartTime");
                DateTime EndTime = GetDateValue(context, "EndTime");
                DateTime OutStartTime = GetDateValue(context, "OutStartTime");
                DateTime OutEndTime = GetDateValue(context, "OutEndTime");
                DataGrid dg = ViewWarehouseInOutSummary.GetViewWarehouseInOutSummaryByKeywords(BusinessID, CarrierGroupID, ProductID, SpecInfoID, InventoryInfoID, CarrierID, StartTime, EndTime, OutStartTime, OutEndTime, "order by [ID] asc,[InOutType] asc", startRowIndex, pageSize);
                var footer = ViewWarehouseInOutSummary.GetViewWarehouseInOutSummaryFooterByKeywords(BusinessID, CarrierGroupID, ProductID, SpecInfoID, InventoryInfoID, CarrierID, StartTime, EndTime, OutStartTime, OutEndTime, "order by [ID] asc,[InOutType] asc", startRowIndex, pageSize);
                dg.footer = footer;
                string result = JsonConvert.SerializeObject(dg);
                context.Response.Write(result);
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("CommHandler", "visit:LoadInOutSummary ", ex);
                context.Response.Write("{\"rows\":[],\"total\":0,\"page\":0}");
            }
        }
        private void ToNextMonth(HttpContext context)
        {
            WarehouseInOut[] list = WarehouseInOut.GetNextMonthToDO();
            if (list.Length == 0)
            {
                return;
            }
            string cmdtext = string.Empty;
            foreach (var item in list)
            {
                GetInfo(item);
            }
        }
        private void GetInfo(WarehouseInOut data)
        {
            TimeSpan span = DateTime.Today - data.EndTime;
            int months = (Convert.ToInt32(span.TotalDays) / 30) + 1;
            List<WarehouseInOut> list = new List<WarehouseInOut>();
            for (int i = 0; i < months; i++)
            {
                var warehouseInOut = new WarehouseInOut();
                warehouseInOut.AddMan = data.AddMan;
                warehouseInOut.AddTime = DateTime.Now;
                warehouseInOut.BusinessChargeStatus = false;
                warehouseInOut.BusinessID = data.BusinessID;
                warehouseInOut.CarrierChargeStatus = true;
                //warehouseInOut.CarrierID = data.CarrierID;
                //warehouseInOut.CarrierMoveCost = data.CarrierMoveCost;
                warehouseInOut.ColdCost = data.ColdCost;
                warehouseInOut.Count = data.Count;
                warehouseInOut.StartTime = data.EndTime.AddDays((1 + i) + i * 30);
                warehouseInOut.EndTime = warehouseInOut.StartTime.AddDays(30);
                warehouseInOut.TotalCount = data.TotalCount;
                warehouseInOut.InOutType = 1;
                warehouseInOut.InventoryInfoID = data.InventoryInfoID;
                //warehouseInOut.MoveCost = data.MoveCost;
                warehouseInOut.ProductID = data.ProductID;
                warehouseInOut.Remark = "到期转月";
                warehouseInOut.SpecInfoID = data.SpecInfoID;
                warehouseInOut.OrderNumber = "到期转月";
                warehouseInOut.IsNextOrder = true;
                if (i == (months - 1))
                {
                    warehouseInOut.IsToNext = false;
                }
                else
                {
                    warehouseInOut.IsToNext = true;
                }
                warehouseInOut.Save();
            }

            data.IsToNext = true;
            data.Save();
        }
        private void DeleteTree(HttpContext context)
        {
            try
            {
                int BusinessID = GetIntValue(context, "BusinessID");
                int ProductID = GetIntValue(context, "ProductID");
                int SpecInfoID = GetIntValue(context, "SpecInfoID");
                int InventoryInfoID = GetIntValue(context, "InventoryInfoID");
                int CarrierGroupID = GetIntValue(context, "CarrierGroupID");
                int CarrierID = GetIntValue(context, "CarrierID");
                var WarehouseInOutList = WarehouseInOut.GetWarehouseInOutListByIDs(BusinessID, ProductID, SpecInfoID, InventoryInfoID, CarrierGroupID, CarrierID);
                if (WarehouseInOutList.Length > 0)
                {
                    context.Response.Write("{\"status\":0}");
                    return;
                }
                if (BusinessID > 0)
                {
                    var data = Business.GetBusiness(BusinessID);
                    data.Delete();
                }
                if (ProductID > 0)
                {
                    var data = Product.GetProduct(ProductID);
                    data.Delete();
                }
                if (SpecInfoID > 0)
                {
                    var data = SpecInfo.GetSpecInfo(SpecInfoID);
                    data.Delete();
                }
                if (InventoryInfoID > 0)
                {
                    var data = InventoryInfo.GetInventoryInfo(InventoryInfoID);
                    data.Delete();
                }
                if (CarrierGroupID > 0)
                {
                    using (SqlHelper helper = new SqlHelper())
                    {
                        try
                        {
                            helper.BeginTransaction();
                            string cmdtext = "delete from [Carrier] where [ID] in (select [CarrierID] from [Carrier_Group] where [GroupID]=@CarrierGroupID);";
                            cmdtext += "delete from [Carrier_Group] where [GroupID]=@CarrierGroupID";
                            List<SqlParameter> parameters = new List<SqlParameter>();
                            parameters.Add(new SqlParameter("@CarrierGroupID", CarrierGroupID));
                            helper.Execute(cmdtext, CommandType.Text, parameters);
                            helper.Commit();
                        }
                        catch (Exception ex)
                        {
                            helper.Rollback();
                            Utility.LogHelper.WriteError("CommHandler", "命令: DeleteTree", ex);
                        }
                    }
                    var data = CarrierGroup.GetCarrierGroup(CarrierGroupID);
                    data.Delete();
                }
                if (CarrierID > 0)
                {
                    using (SqlHelper helper = new SqlHelper())
                    {
                        helper.BeginTransaction();
                        try
                        {
                            string cmdtext = "delete from [Carrier_Group] where [CarrierID]=@CarrierID";
                            List<SqlParameter> parameters = new List<SqlParameter>();
                            parameters.Add(new SqlParameter("@CarrierID", CarrierID));
                            helper.Execute(cmdtext, CommandType.Text, parameters);
                            helper.Commit();
                        }
                        catch (Exception ex)
                        {
                            helper.Rollback();
                            Utility.LogHelper.WriteError("CommHandler", "命令: DeleteTree", ex);
                        }
                    }
                    var data = Carrier.GetCarrier(CarrierID);
                    data.Delete();
                }
                context.Response.Write("{\"status\":1}");
                return;
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("CommHandler", "visit:DeleteTree ", ex);
                context.Response.Write("{\"status\":2}");
                return;
            }
        }
        private void SaveCarrier(HttpContext context)
        {
            int ID = GetIntValue(context, "ID");
            int GroupID = GetIntValue(context, "GroupID");
            string CarrierName = context.Request.Params["CarrierName"];
            Carrier carrier = null;
            if (ID > 0)
            {
                carrier = Carrier.GetCarrier(ID);
            }
            if (carrier == null)
            {
                carrier = new Carrier();
            }
            carrier.CarrierName = CarrierName;
            carrier.Save();
            if (GroupID > 0)
            {
                var carriergroup = new Carrier_Group();
                carriergroup.GroupID = GroupID;
                carriergroup.CarrierID = carrier.ID;
                carriergroup.Save();
            }
            context.Response.Write("{\"status\":true}");
        }
        private void SaveCarrierGroup(HttpContext context)
        {
            int ID = GetIntValue(context, "ID");
            string CarrierGroupName = context.Request.Params["CarrierGroupName"];

            CarrierGroup carrierGroup = null;
            if (ID > 0)
            {
                carrierGroup = CarrierGroup.GetCarrierGroup(ID);
            }
            if (carrierGroup == null)
            {
                carrierGroup = new CarrierGroup();
            }
            carrierGroup.CarrierGroupName = CarrierGroupName;
            carrierGroup.Save();
            context.Response.Write("{\"status\":true}");
        }
        private void SaveInventoryInfo(HttpContext context)
        {
            int ID = GetIntValue(context, "ID");
            string InventoryName = context.Request.Params["InventoryName"];
            InventoryInfo inventory = null;
            if (ID > 0)
            {
                inventory = InventoryInfo.GetInventoryInfo(ID);
            }
            if (inventory == null)
            {
                inventory = new InventoryInfo();
            }
            inventory.InventoryName = InventoryName;
            inventory.Save();
            context.Response.Write("{\"status\":true}");
        }
        private void SaveSpec(HttpContext context)
        {
            int ID = GetIntValue(context, "ID");
            decimal ColdPrice = GetDecimalValue(context, "ColdPrice");
            decimal MovePrice = GetDecimalValue(context, "MovePrice");
            decimal BalancePrice = GetDecimalValue(context, "BalancePrice");
            string SpecName = context.Request.Params["SpecName"];
            SpecInfo spec = null;
            if (ID > 0)
            {
                spec = SpecInfo.GetSpecInfo(ID);
            }
            if (spec == null)
            {
                spec = new SpecInfo();
            }
            spec.SpecName = SpecName;
            spec.ColdPrice = ColdPrice;
            spec.MovePrice = MovePrice;
            spec.BalancePrice = BalancePrice;
            spec.Save();
            context.Response.Write("{\"status\":true}");
        }
        private void SaveProduct(HttpContext context)
        {
            int ID = GetIntValue(context, "ID");
            string ProductName = context.Request.Params["ProductName"];

            Product product = null;
            if (ID > 0)
            {
                product = Product.GetProduct(ID);
            }
            if (product == null)
            {
                product = new Product();
            }
            product.ProductName = ProductName;
            product.Save();
            context.Response.Write("{\"status\":true}");
        }
        private void SaveBusiness(HttpContext context)
        {
            int ID = GetIntValue(context, "ID");
            string Category = context.Request.Params["Category"];
            string ContactName = context.Request.Params["ContactName"];
            string ContactPhone = context.Request.Params["ContactPhone"];
            string Remark = context.Request.Params["Remark"];
            Business business = null;
            if (ID > 0)
            {
                business = Business.GetBusiness(ID);
            }
            if (business == null)
            {
                business = new Business();
                business.AddTime = DateTime.Now;
            }
            business.Category = Category;
            business.ContactName = ContactName;
            business.ContactPhone = ContactPhone;
            business.Remark = Remark;
            business.Save();
            context.Response.Write("{\"status\":true}");
        }
        public class CarrierBalanceModule
        {
            public int ID { get; set; }
            public decimal CarrierBalanceCost { get; set; }
            public decimal RemoveCost { get; set; }
            public DateTime CarrierBalanceTime { get; set; }

        }
        private void PrintInMgr(HttpContext context)
        {
            string IDstr = context.Request.Params["IDs"];
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(IDstr);
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    string cmdtext = "update [WarehouseInOut] set [LastPrintTime]=getdate(),[PrintCount]=isnull([PrintCount],0)+1 where ID in (" + string.Join(",", IDList.ToArray()) + ")";
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    helper.Execute(cmdtext, CommandType.Text, parameters);
                    helper.Commit();
                    context.Response.Write("{\"status\":true}");
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError("CommHandler", "visit: PrintInMgr", ex);
                    context.Response.Write("{\"status\":false}");
                }
            }
        }
        private void ChargeCarrierBalance(HttpContext context)
        {
            string listarry = context.Request.Params["list"];
            List<CarrierBalanceModule> oldlist = JsonConvert.DeserializeObject<List<CarrierBalanceModule>>(listarry);
            string AddMan = context.Request.Params["AddMan"];
            string ChargeMan = context.Request.Params["ChargeMan"];
            DateTime ChargeTime = DateTime.Now;
            DateTime.TryParse(context.Request.Params["ChargeTime"], out ChargeTime);
            int ChageType1 = GetIntValue(context, "ChargeType1");

            List<WarehouseInOut> newlist = new List<WarehouseInOut>();
            decimal total = 0;
            foreach (var item in oldlist)
            {
                var warehouseInOut = WarehouseInOut.GetWarehouseInOut(item.ID);
                warehouseInOut.CarrierBalanceCost = item.CarrierBalanceCost;
                warehouseInOut.RemoveCost = item.RemoveCost;
                warehouseInOut.CarrierBalanceTime = item.CarrierBalanceTime;
                warehouseInOut.CarrierChargeStatus = true;
                newlist.Add(warehouseInOut);
                total += warehouseInOut.CarrierBalanceCost;
            }
            var printHistory = new PrintHistory();
            printHistory.Cost = total;
            printHistory.CostCapital = Tools.CmycurD(total);
            printHistory.AddMan = AddMan;
            printHistory.AddTime = DateTime.Now;
            printHistory.ChargeMan = ChargeMan;
            printHistory.ChargeTime = ChargeTime;
            printHistory.ChageType1 = ChageType1;
            printHistory.Save();
            foreach (var item in newlist)
            {
                item.PrintID = printHistory.ID;
                item.Save();
            }
            context.Response.Write("{\"status\":true}");
        }
        public class BusinessBalanceModule
        {
            public int ID { get; set; }
            public decimal TotalCost { get; set; }
            public decimal ColdCost { get; set; }
            public decimal DiscountCost { get; set; }
            public decimal RealCost { get; set; }
            public DateTime BalanceTime { get; set; }

        }
        private void ChargeBusinessBalance(HttpContext context)
        {
            string listarry = context.Request.Params["list"];
            List<BusinessBalanceModule> oldlist = JsonConvert.DeserializeObject<List<BusinessBalanceModule>>(listarry);
            string AddMan = context.Request.Params["AddMan"];
            string ChargeMan = context.Request.Params["ChargeMan"];
            DateTime ChargeTime = DateTime.Now;
            DateTime.TryParse(context.Request.Params["ChargeTime"], out ChargeTime);
            int ChageType1 = GetIntValue(context, "ChargeType1");

            List<WarehouseInOut> newlist = new List<WarehouseInOut>();
            decimal total = 0;
            foreach (var item in oldlist)
            {
                var warehouseInOut = WarehouseInOut.GetWarehouseInOut(item.ID);
                warehouseInOut.TotalCost = item.TotalCost;
                warehouseInOut.ColdCost = item.ColdCost;
                warehouseInOut.DiscountCost = item.DiscountCost;
                warehouseInOut.RealCost = item.RealCost;
                warehouseInOut.BalanceTime = item.BalanceTime;
                warehouseInOut.BusinessChargeStatus = true;
                newlist.Add(warehouseInOut);
                total += warehouseInOut.RealCost;
            }
            var printHistory = new PrintHistory();
            printHistory.Cost = total;
            printHistory.CostCapital = Tools.CmycurD(total);
            printHistory.AddMan = AddMan;
            printHistory.AddTime = DateTime.Now;
            printHistory.ChargeMan = ChargeMan;
            printHistory.ChargeTime = ChargeTime;
            printHistory.ChageType1 = ChageType1;
            printHistory.Save();
            foreach (var item in newlist)
            {
                item.PrintID = printHistory.ID;
                item.Save();
            }
            context.Response.Write("{\"status\":true}");
        }
        private void EditResourceOut(HttpContext context)
        {
            int ID = GetIntValue(context, "ID");
            int CarrierID = GetIntValue(context, "CarrierID");
            decimal MoveCost = GetDecimalValue(context, "MoveCost");
            int Count = GetIntValue(context, "Count");
            DateTime OutTime = GetDateValue(context, "OutTime");
            string Remark = context.Request.Params["Remark"];
            string AddMan = context.Request.Params["AddMan"];
            int SpecID = GetIntValue(context, "SpecID");
            if (ID == 0)
            {
                context.Response.Write("{\"status\":0}");
                return;
            }
            var warehouseInOut = WarehouseInOut.GetWarehouseInOut(ID);
            if (warehouseInOut == null)
            {
                context.Response.Write("{\"status\":0}");
                return;
            }
            var warehouseIn = WarehouseInOut.GetWarehouseInOut(warehouseInOut.RelateID);
            if (warehouseIn.Count + warehouseInOut.Count < Count)
            {
                context.Response.Write("{\"status\":2}");
                return;
            }
            warehouseIn.Count = warehouseIn.Count + warehouseInOut.Count - Count;
            warehouseIn.Save();
            warehouseInOut.Count = Count;
            warehouseInOut.CarrierID = CarrierID;
            warehouseInOut.SpecInfoID = SpecID;
            warehouseInOut.OutTime = OutTime;
            warehouseInOut.MoveCost = MoveCost;
            warehouseInOut.Remark = Remark;
            warehouseInOut.AddMan = AddMan;
            warehouseInOut.AddTime = DateTime.Now;
            warehouseInOut.TotalCount = Count;
            var specInfo = SpecInfo.GetSpecInfo(SpecID);
            decimal CarrierMoveCost = Count * specInfo.BalancePrice;
            warehouseInOut.CarrierMoveCost = CarrierMoveCost;
            warehouseInOut.Save();
            context.Response.Write("{\"status\":1}");
        }
        private void CancelSource(HttpContext context)
        {
            string IDListArry = context.Request.Params["IDList"];
            int InOutType = GetIntValue(context, "InOutType");
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(IDListArry);
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    string cmdtext = string.Empty;
                    if (InOutType == 2)
                    {
                        foreach (var ID in IDList)
                        {
                            var warehouseInOut = WarehouseInOut.GetWarehouseInOut(ID, helper);
                            cmdtext += "update [WarehouseInOut] set [Count]=[Count]+" + warehouseInOut.Count + " where ID=" + warehouseInOut.RelateID;
                        }
                    }
                    cmdtext += "delete from [WarehouseInOut] where ID in (" + string.Join(",", IDList.ToArray()) + ");";
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    helper.Execute(cmdtext, CommandType.Text, parameters);
                    helper.Commit();
                    context.Response.Write("{\"status\":true}");
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError("CommHandler.ashx", "visit: CancelSource", ex);
                    context.Response.Write("{\"status\":false}");
                }
            }
        }
        private void CheckInStatus(HttpContext context)
        {
            try
            {
                string InIDListArry = context.Request.Params["InIDList"];
                if (!string.IsNullOrEmpty(InIDListArry))
                {
                    List<int> InIDList = JsonConvert.DeserializeObject<List<int>>(InIDListArry);
                    if (InIDList.Count > 0)
                    {
                        var list = WarehouseInOut.GetWarehouseInOutListByParentID(InIDList);
                        if (list.Length > 0)
                        {
                            context.Response.Write("{\"status\":2}");
                            return;
                        }
                    }
                }
                context.Response.Write("{\"status\":1}");
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("CommHandler.ashx", "visit: CheckInStatus", ex);
                context.Response.Write("{\"status\":0}");
            }
        }
        private void SaveResourceOut(HttpContext context)
        {
            try
            {
                int ID = GetIntValue(context, "ID");
                int CarrierID = GetIntValue(context, "CarrierID");
                decimal MoveCost = GetDecimalValue(context, "MoveCost");
                int Count = GetIntValue(context, "Count");
                DateTime OutTime = GetDateValue(context, "OutTime");
                string Remark = context.Request.Params["Remark"];
                string AddMan = context.Request.Params["AddMan"];
                string OrderNumber = context.Request.Params["OrderNumber"];
                int SpecID = GetIntValue(context, "SpecID");
                if (ID == 0)
                {
                    context.Response.Write("{\"status\":0}");
                    return;
                }
                var warehouseIn = WarehouseInOut.GetWarehouseInOut(ID);
                if (warehouseIn == null)
                {
                    context.Response.Write("{\"status\":0}");
                    return;
                }
                if (warehouseIn.Count < Count)
                {
                    context.Response.Write("{\"status\":2}");
                    return;
                }
                var warehouseInOut = new WarehouseInOut();
                warehouseInOut.OrderNumber = OrderNumber;
                warehouseInOut.InventoryInfoID = warehouseIn.InventoryInfoID;
                warehouseInOut.BusinessID = warehouseIn.BusinessID;
                warehouseInOut.ProductID = warehouseIn.ProductID;
                warehouseInOut.StartTime = warehouseIn.StartTime;
                warehouseInOut.Count = Count;
                warehouseInOut.CarrierID = CarrierID;
                warehouseInOut.SpecInfoID = SpecID;
                warehouseInOut.OutTime = OutTime;
                warehouseInOut.MoveCost = MoveCost;
                warehouseInOut.Remark = Remark;
                warehouseInOut.AddMan = AddMan;
                warehouseInOut.AddTime = DateTime.Now;
                warehouseInOut.InOutType = 2;
                warehouseInOut.RelateID = warehouseIn.ID;
                warehouseInOut.TotalCount = Count;
                var specInfo = SpecInfo.GetSpecInfo(SpecID);
                decimal CarrierMoveCost = Count * specInfo.BalancePrice;
                warehouseInOut.CarrierMoveCost = CarrierMoveCost;
                warehouseInOut.Save();
                warehouseIn.Count = warehouseIn.Count - Count;
                warehouseIn.Save();
                context.Response.Write("{\"status\":1}");
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("CommHandler.ashx", "visit: SaveResourceOut", ex);
                context.Response.Write("{\"status\":0}");
            }
        }
        private void LoadAllCommbox(HttpContext context)
        {
            var businesslist = Business.GetBusinesses();
            var productlist = Product.GetProducts();
            var speclist = SpecInfo.GetSpecInfos();
            var inventorylist = InventoryInfo.GetInventoryInfos();
            var carrierlist = Carrier.GetCarriers();
            string str1 = JsonConvert.SerializeObject(businesslist);
            string str2 = JsonConvert.SerializeObject(productlist);
            string str3 = JsonConvert.SerializeObject(speclist);
            string str4 = JsonConvert.SerializeObject(inventorylist);
            string str5 = JsonConvert.SerializeObject(carrierlist);
            context.Response.Write("{\"status\":true,\"businesslist\":" + str1 + ",\"productlist\":" + str2 + ",\"speclist\":" + str3 + ",\"inventorylist\":" + str4 + ",\"carrierlist\":" + str5 + "}");
        }
        private void SaveResource(HttpContext context)
        {
            int ID = GetIntValue(context, "ID");
            string OrderNumber = context.Request.Params["OrderNumber"];
            int InventoryInfoID = GetIntValue(context, "InventoryInfoID");
            int BusinessID = GetIntValue(context, "BusinessID");
            int ProductID = GetIntValue(context, "ProductID");
            int Count = GetIntValue(context, "Count");
            int CarrierID = GetIntValue(context, "CarrierID");
            int SpecID = GetIntValue(context, "SpecID");
            DateTime StartTime = GetDateValue(context, "StartTime");
            DateTime EndTime = GetDateValue(context, "EndTime");
            string Remark = context.Request.Params["Remark"];
            string AddMan = context.Request.Params["AddMan"];
            decimal MoveCost = GetDecimalValue(context, "MoveCost");
            decimal ColdCost = GetDecimalValue(context, "ColdCost");
            var warehouseInOut = new WarehouseInOut();
            if (ID > 0)
            {
                warehouseInOut = WarehouseInOut.GetWarehouseInOut(ID);
                if (warehouseInOut == null)
                {
                    warehouseInOut = new WarehouseInOut();
                }
            }
            warehouseInOut.OrderNumber = OrderNumber;
            warehouseInOut.InventoryInfoID = InventoryInfoID;
            warehouseInOut.BusinessID = BusinessID;
            warehouseInOut.ProductID = ProductID;
            warehouseInOut.Count = Count;
            warehouseInOut.CarrierID = CarrierID;
            warehouseInOut.SpecInfoID = SpecID;
            warehouseInOut.StartTime = StartTime;
            warehouseInOut.EndTime = EndTime;
            warehouseInOut.Remark = Remark;
            warehouseInOut.AddMan = AddMan;
            warehouseInOut.AddTime = DateTime.Now;
            warehouseInOut.InOutType = 1;
            warehouseInOut.MoveCost = MoveCost;
            warehouseInOut.ColdCost = ColdCost;
            warehouseInOut.TotalCount = Count;
            var specInfo = SpecInfo.GetSpecInfo(SpecID);
            decimal CarrierMoveCost = Count * specInfo.BalancePrice;
            warehouseInOut.CarrierMoveCost = CarrierMoveCost;
            warehouseInOut.Save();
            context.Response.Write("{\"status\":true}");
        }
        private void LoadInoutSource(HttpContext context)
        {
            try
            {
                string Keywords = context.Request.Params["Keywords"];
                int InOutType = GetIntValue(context, "InOutType");
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                int BusinessChargeStatus = GetIntValue(context, "BusinessChargeStatus");
                int CarrierChargeStatus = GetIntValue(context, "CarrierChargeStatus");
                int BusinessID = GetIntValue(context, "BusinessID");
                int CarrierID = GetIntValue(context, "CarrierID");
                int ProductID = GetIntValue(context, "ProductID");
                int SpecInfoID = GetIntValue(context, "SpecInfoID");
                int InventoryInfoID = GetIntValue(context, "InventoryInfoID");
                int CarrierGroupID = GetIntValue(context, "CarrierGroupID");
                DateTime StartTime = GetDateValue(context, "StartTime");
                DateTime EndTime = GetDateValue(context, "EndTime");
                DateTime OutStartTime = GetDateValue(context, "OutStartTime");
                DateTime OutEndTime = GetDateValue(context, "OutEndTime");
                DateTime BusinessBalanceStartTime = GetDateValue(context, "BusinessBalanceStartTime");
                DateTime BusinessBalanceEndTime = GetDateValue(context, "BusinessBalanceEndTime");
                DateTime CarrierBalanceStartTime = GetDateValue(context, "CarrierBalanceStartTime");
                DateTime CarrierBalanceEndTime = GetDateValue(context, "CarrierBalanceEndTime");
                bool IncludeIsNextOrder = false;
                bool.TryParse(context.Request.Params["IncludeIsNextOrder"], out IncludeIsNextOrder);
                bool HaveInventory = false;
                bool.TryParse(context.Request.Params["HaveInventory"], out HaveInventory);
                string SortOrder = context.Request.Params["SortOrder"];
                if (string.IsNullOrEmpty(SortOrder))
                {
                    SortOrder = "order by [StartTime] desc";
                }
                int IsPrint = int.MinValue;
                if (!string.IsNullOrEmpty(context.Request.Params["IsPrint"]))
                {
                    int.TryParse(context.Request.Params["IsPrint"], out IsPrint);
                }
                bool ShowCarrierFee = false;
                bool.TryParse(context.Request.Params["ShowCarrierFee"], out ShowCarrierFee);
                DataGrid dg = ViewWarehouseInOut.GetViewWarehouseInOutByKeywords(InOutType, BusinessChargeStatus, CarrierChargeStatus, BusinessID, CarrierGroupID, ProductID, SpecInfoID, InventoryInfoID, CarrierID, StartTime, EndTime, OutStartTime, OutEndTime, BusinessBalanceStartTime, BusinessBalanceEndTime, CarrierBalanceStartTime, CarrierBalanceEndTime, IncludeIsNextOrder, HaveInventory, IsPrint, ShowCarrierFee, SortOrder, startRowIndex, pageSize);
                var footer = ViewWarehouseInOut.GetViewWarehouseInOutSummaryByKeywords(InOutType, BusinessChargeStatus, CarrierChargeStatus, BusinessID, CarrierGroupID, ProductID, SpecInfoID, InventoryInfoID, CarrierID, StartTime, EndTime, OutStartTime, OutEndTime, BusinessBalanceStartTime, BusinessBalanceEndTime, CarrierBalanceStartTime, CarrierBalanceEndTime, IncludeIsNextOrder, HaveInventory);
                dg.footer = footer;
                string result = JsonConvert.SerializeObject(dg);
                context.Response.Write(result);
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("CommHandler.ashx", "visit: LoadInoutSource", ex);
                context.Response.Write("{\"rows\":[],\"total\":0,\"page\":0}");
            }
        }
        public List<TreeModule> list = new List<TreeModule>();
        private void LoadTree(HttpContext context)
        {
            try
            {
                string Keywords = context.Request.Params["Keywords"];
                var businesslist = Business.GetBusinessListByKeywords(Keywords);
                var productlist = Product.GetProductListByKeywords(Keywords);
                var speclist = SpecInfo.GetSpecInfoListByKeywords(Keywords);
                var inventorylist = InventoryInfo.GetInventoryInfoListByKeywords(Keywords);
                var carriergrouplist = CarrierGroup.GetCarrierGroupListByKeywords(Keywords);
                if (businesslist.Length > 0)
                {
                    GetParentList(1, "商户", TreeTypeDefine.Business.ToString(), true);
                }
                else
                {
                    GetParentList(1, "商户", TreeTypeDefine.Business.ToString(), false);
                }
                if (productlist.Length > 0)
                {
                    GetParentList(2, "货品", TreeTypeDefine.Product.ToString(), true);
                }
                else
                {
                    GetParentList(2, "货品", TreeTypeDefine.Product.ToString(), false);
                }
                if (speclist.Length > 0)
                {
                    GetParentList(3, "规格", TreeTypeDefine.SpecInfo.ToString(), true);
                }
                else
                {
                    GetParentList(3, "规格", TreeTypeDefine.SpecInfo.ToString(), false);
                }
                if (inventorylist.Length > 0)
                {
                    GetParentList(4, "库存", TreeTypeDefine.InventoryInfo.ToString(), true);
                }
                else
                {
                    GetParentList(4, "库存", TreeTypeDefine.InventoryInfo.ToString(), false);
                }
                if (carriergrouplist.Length > 0)
                {
                    GetParentList(5, "搬运工", TreeTypeDefine.CarrierGroup.ToString(), true);
                }
                else
                {
                    GetParentList(5, "搬运工", TreeTypeDefine.CarrierGroup.ToString(), false);
                }
                foreach (var item in businesslist)
                {
                    var treeModule = new TreeModule();
                    treeModule.id = TreeTypeDefine.Business.ToString() + "_" + item.ID.ToString();
                    treeModule.ID = item.ID;
                    treeModule.pId = "1";
                    treeModule.name = item.ContactName;
                    treeModule.isParent = false;
                    treeModule.open = false;
                    treeModule.type = TreeTypeDefine.Business.ToString();
                    list.Add(treeModule);
                }
                foreach (var item in productlist)
                {
                    var treeModule = new TreeModule();
                    treeModule.id = TreeTypeDefine.Product.ToString() + "_" + item.ID.ToString();
                    treeModule.ID = item.ID;
                    treeModule.pId = "2";
                    treeModule.name = item.ProductName;
                    treeModule.isParent = false;
                    treeModule.open = false;
                    treeModule.type = TreeTypeDefine.Product.ToString();
                    list.Add(treeModule);
                }
                foreach (var item in speclist)
                {
                    var treeModule = new TreeModule();
                    treeModule.id = TreeTypeDefine.SpecInfo.ToString() + "_" + item.ID.ToString();
                    treeModule.ID = item.ID;
                    treeModule.pId = "3";
                    treeModule.name = item.SpecName;
                    treeModule.isParent = false;
                    treeModule.open = false;
                    treeModule.type = TreeTypeDefine.SpecInfo.ToString();
                    list.Add(treeModule);
                }
                foreach (var item in inventorylist)
                {
                    var treeModule = new TreeModule();
                    treeModule.id = TreeTypeDefine.InventoryInfo.ToString() + "_" + item.ID.ToString();
                    treeModule.ID = item.ID;
                    treeModule.pId = "4";
                    treeModule.name = item.InventoryName;
                    treeModule.isParent = false;
                    treeModule.open = false;
                    treeModule.type = TreeTypeDefine.InventoryInfo.ToString();
                    list.Add(treeModule);
                }
                foreach (var item in carriergrouplist)
                {
                    var treeModule = new TreeModule();
                    treeModule.id = TreeTypeDefine.CarrierGroup.ToString() + "_" + item.ID.ToString();
                    treeModule.ID = item.ID;
                    treeModule.pId = "5";
                    treeModule.name = item.CarrierGroupName;
                    treeModule.isParent = false;
                    treeModule.open = false;
                    treeModule.type = TreeTypeDefine.CarrierGroup.ToString();
                    var newcarrierlist = Carrier.GetCarrierListByGroupID(item.ID, Keywords);
                    if (newcarrierlist.Length > 0)
                    {
                        treeModule.isParent = true;
                        treeModule.open = true;
                    }
                    list.Add(treeModule);
                    foreach (var carrier in newcarrierlist)
                    {
                        var newtreeModule = new TreeModule();
                        newtreeModule.id = TreeTypeDefine.Carrier.ToString() + "_" + carrier.ID.ToString();
                        newtreeModule.ID = carrier.ID;
                        newtreeModule.pId = treeModule.id;
                        newtreeModule.name = carrier.CarrierName;
                        newtreeModule.isParent = false;
                        newtreeModule.open = false;
                        newtreeModule.type = TreeTypeDefine.Carrier.ToString();
                        list.Add(newtreeModule);
                    }
                }
                string result = JsonConvert.SerializeObject(list);
                context.Response.Write(result);
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("CommHandler.ashx", "visit: LoadTree", ex);
                context.Response.Write("[]");
            }
        }
        private decimal GetDecimalValue(HttpContext context, string name)
        {
            decimal value = decimal.MinValue;
            decimal.TryParse(context.Request.Params[name], out value);
            return value;
        }
        private int GetIntValue(HttpContext context, string name)
        {
            int value = int.MinValue;
            int.TryParse(context.Request.Params[name], out value);
            return value;
        }
        private DateTime GetDateValue(HttpContext context, string name)
        {
            DateTime value = DateTime.MinValue;
            DateTime.TryParse(context.Request.Params[name], out value);
            return value;
        }
        private void GetParentList(int ID, string Name, string type, bool open)
        {
            TreeModule treeModule = new TreeModule();
            treeModule.id = ID.ToString();
            treeModule.ID = ID;
            treeModule.pId = "0";
            treeModule.name = Name;
            treeModule.isParent = open;
            treeModule.open = open;
            treeModule.type = type;
            list.Add(treeModule);
        }
        public class TreeModule
        {
            public string id { get; set; }
            public int ID { get; set; }
            public string pId { get; set; }
            public string name { get; set; }
            public bool isParent { get; set; }
            public bool open { get; set; }
            public string type { get; set; }
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