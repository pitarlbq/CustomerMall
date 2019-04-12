using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Foresight.DataAccess.Ui;
using Foresight.DataAccess;
using Foresight.DataAccess.Framework;
using DataAccess;
using System.Data.SqlClient;
using System.Data;
using Utility;
using System.Web.SessionState;

namespace Web.Handler
{
    /// <summary>
    /// FeeCenterHandler 的摘要说明
    /// </summary>
    public class FeeCenterHandler : BaseHandler, IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string visit = context.Request.Params["visit"];
            if (string.IsNullOrEmpty(visit))
            {
                LogHelper.WriteDebug("FeeCenterHandler", "visit为空");
                context.Response.Write(null);
                return;
            }
            visit = visit.ToLower();
            try
            {
                switch (visit)
                {
                    case "loadroomfeelist":
                        WrapParams(context, null);
                        LoadRoomFeeList(context);
                        break;
                    case "loadsetfeelist":
                        LoadSetFeeList(context);
                        break;
                    case "saveroomfee"://启用周期收费
                        SaveRoomFee(context);
                        break;
                    case "savecontractroomfee":
                        SaveContractRoomFee(context);
                        break;
                    case "chargeroomfee":
                        ChargeRoomFee(context);
                        break;
                    case "saveprintfee":
                        WrapParams(context, null);
                        SavePrintFee(context);
                        break;
                    case "saveprintfeenew":
                        saveprintfeenew(context);
                        break;
                    case "addchargeprice":
                        AddChargePrice(context);
                        break;
                    case "loadcheckfeeids":
                        LoadCheckFeeIds(context);
                        break;
                    case "cancelroomfee":
                        CancelRoomFee(context);
                        break;
                    case "removeroomfee":
                        RemoveRoomFee(context);
                        break;
                    case "loadlfeesummarylist":
                        LoadlFeeSummaryList(context);
                        break;
                    case "loadlchargesummarylist":
                        LoadlChargeSummaryList(context);
                        break;
                    case "loadltempsummarylist":
                        LoadlTempSummaryList(context);
                        break;
                    case "deletesummaryfee":
                        DeleteSummaryFee(context);
                        break;
                    case "savesummaryfee":
                        SaveSummaryFee(context);
                        break;
                    case "getchargesummarylist":
                        GetChargeSummaryList(context);
                        break;
                    case "savetemproomfee":
                        SaveTempRoomFee(context);
                        break;
                    case "chargetemproomfee":
                        ChargeTempRoomFee(context);
                        break;
                    case "viewroombalance":
                        ViewRoomBalance(context);
                        break;
                    case "loadroomfeehistorylist":
                        LoadRoomFeeHistoryList(context);
                        break;
                    case "cancelhistoryfee":
                        CancelHistoryFee(context);
                        break;
                    case "loadguaranteefeelist":
                        LoadGuaranteeFeeList(context);
                        break;
                    case "addchargesummary":
                        AddChargeSummary(context);
                        break;
                    case "savechargesummary":
                        SaveChargeSummary(context);
                        break;
                    case "deletechargesummary":
                        DeleteChargeSummary(context);
                        break;
                    case "loadchargesummarytype":
                        LoadChargeSummaryType(context);
                        break;
                    case "deletetemproomfee":
                        DeleteTempRoomFee(context);
                        break;
                    case "checkexistsummary":
                        CheckExistSummary(context);
                        break;
                    case "loadroomresourcefeelist":
                        LoadRoomResourceFeeList(context);
                        break;
                    case "checkexistroomsourcefee":
                        CheckExistRoomSourceFee(context);
                        break;
                    case "checkresourcehistoryfee":
                        CheckResourceHistoryFee(context);
                        break;
                    case "checktempsummaryhistoryfee":
                        CheckTempSummaryHistoryFee(context);
                        break;
                    case "checkprechargeroomfeehistory":
                        CheckPreChargeRoomFeeHistory(context);
                        break;
                    case "getallowimportchargesummarylist":
                        GetAllowImportChargeSummaryList(context);
                        break;
                    case "printchargefee":
                        PrintChargeFee(context);
                        break;
                    case "checkroomfeesummary":
                        CheckRoomFeeSummary(context);
                        break;
                    case "viewroomweishubalance":
                        ViewRoomWeiShuBalance(context);
                        break;
                    case "cancelprintfee":
                        CancelPrintFee(context);
                        break;
                    case "cancelguaranteeprintfee":
                        CancelGuaranteePrintFee(context);
                        break;
                    case "batchsavefee":
                        batchsavefee(context);
                        break;
                    case "getendtime":
                        getendtime(context);
                        break;
                    case "confirmechargeroomfee":
                        confirmechargeroomfee(context);
                        break;
                    case "saveroomfeenote":
                        saveroomfeenote(context);
                        break;
                    case "getallnotes":
                        getallnotes(context);
                        break;
                    case "deletenotes":
                        deletenotes(context);
                        break;
                    case "removeroomfeehistory":
                        removeroomfeehistory(context);
                        break;
                    case "cancelprefee":
                        cancelprefee(context);
                        break;
                    case "getroomprechargebalancetitle":
                        getroomprechargebalancetitle(context);
                        break;
                    case "loadcreatecuishouparas":
                        loadcreatecuishouparas(context);
                        break;
                    case "re_confirmechargeroomfee":
                        re_confirmechargeroomfee(context);
                        break;
                    case "changechargeman":
                        changechargeman(context);
                        break;
                    case "getchargeprechargeallparams":
                        getchargeprechargeallparams(context);
                        break;
                    case "saveprintfeelist":
                        saveprintfeelist(context);
                        break;
                    default:
                        WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "Unkown Visit: " + visit);
                        break;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("FeeCenterHandler", "visit: " + visit, ex);
                context.Response.Write("{\"status\":false}");
            }
        }
        private void saveprintfeelist(HttpContext context)
        {
            List<Dictionary<string, object>> List = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(context.Request["list"]);
            List<int> TempHistoryIDList = new List<int>();
            foreach (var item in List)
            {
                string TempHistoryIDs = WebUtil.GetStrByObj(item, "TempHistoryIDs");
                if (!string.IsNullOrEmpty(TempHistoryIDs))
                {
                    TempHistoryIDList.AddRange(JsonConvert.DeserializeObject<List<int>>(TempHistoryIDs));
                }
            }
            var list = TempRoomFeeHistory.GetTempRoomFeeHistoryListByIDs(TempHistoryIDList);
            var ViewChargeSummaryList = ViewChargeSummary.GetViewChargeSummaries().ToArray();
            List<Dictionary<string, object>> results = new List<Dictionary<string, object>>();
            var user = WebUtil.GetUser(context);
            foreach (var item in List)
            {
                int RoomID = WebUtil.GetIntByObj(item, "RoomID");
                var my_list = list.Where(p => p.RoomID == RoomID).ToArray();
                int out_printid = 0;
                string errormsg = string.Empty;
                bool print_cheque_status = true;
                bool result = APPCode.HandlerHelper.SavePrintFee(item, out out_printid, out print_cheque_status, out errormsg, my_list, ViewChargeSummaryList);
                if (result)
                {
                    var obj = new Dictionary<string, object>();
                    obj["RoomID"] = RoomID;
                    obj["PrintID"] = out_printid;
                    results.Add(obj);
                }
            }
            if (results.Count > 0)
            {
                WebUtil.WriteJson(context, new { status = true, list = results });
            }
        }
        private void getchargeprechargeallparams(HttpContext context)
        {
            var list = Foresight.DataAccess.ChargeSummary.GetChargeSummaries();
            var chargelist = list.Where(p => p.CategoryID != 4).Select(p =>
            {
                var item = new { ID = p.ID, Name = p.Name };
                return item;
            });
            var prechargelist = list.Where(p => p.CategoryID == 4).Select(p =>
            {
                var item = new { ID = p.ID, Name = p.Name };
                return item;
            });
            WebUtil.WriteJson(context, new { status = true, chargelist = chargelist, prechargelist });
        }
        private void changechargeman(HttpContext context)
        {
            List<int> IDList = new List<int>();
            if (!string.IsNullOrEmpty(context.Request["IDs"]))
            {
                IDList = JsonConvert.DeserializeObject<List<int>>(context.Request["IDs"]);
            }
            DateTime NewEndTime = DateTime.MinValue;
            if (!string.IsNullOrEmpty(context.Request["NewEndTime"]))
            {
                NewEndTime = WebUtil.GetDateValue(context, "NewEndTime");
            }
            var list = Foresight.DataAccess.RoomFee.GetRoomFeeListByIDs(IDList);
            foreach (var item in list)
            {
                item.DefaultChargeManID = WebUtil.GetIntValue(context, "DefaultChargeManID");
                item.DefaultChargeManName = context.Request["DefaultChargeManName"];
                if (NewEndTime > DateTime.MinValue)
                {
                    item.NewEndTime = NewEndTime;
                }
                item.Save();
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void re_confirmechargeroomfee(HttpContext context)
        {
            DateTime ChargeStartTime = WebUtil.GetDateValue(context, "StartTime");
            DateTime ChargeEndTime = WebUtil.GetDateValue(context, "EndTime");
            List<int> IDList = new List<int>();
            if (!string.IsNullOrEmpty(context.Request.Params["IDs"]))
            {
                IDList = JsonConvert.DeserializeObject<List<int>>(context.Request.Params["IDs"]);
            }
            RoomFeeHistory[] list = new RoomFeeHistory[] { };
            if (IDList.Count > 0)
            {
                list = RoomFeeHistory.GetRoomFeeHistorysByHistoryIDs(IDList);
            }
            //else
            //{
            //    list = RoomFeeHistory.GetCuiShouRoomFeeHistorys(ChargeStartTime, ChargeEndTime);
            //}
            var ChargeSummaryList = ChargeSummary.GetChargeSummaries();
            var ViewChargeSummaryList = ViewChargeSummary.GetViewChargeSummaries();
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    foreach (var history in list)
                    {
                        var roomFee = RoomFee.GetRoomFee(history.ID, helper);
                        if (roomFee == null)
                        {
                            roomFee = RoomFee.GetRoomFeeByIDs(history.RoomID, history.ChargeID, helper);
                        }
                        if (roomFee == null)
                        {
                            continue;
                        }
                        if (roomFee.StartTime >= history.EndTime)
                        {
                            continue;
                        }
                        roomFee.IsCharged = true;
                        roomFee.Save(helper);
                        ChargeSummary summary = ChargeSummaryList.FirstOrDefault(p => p.ID == roomFee.ChargeID); //
                        if (roomFee.ImportFeeID > 0)
                        {
                            ImportFee importFee = ImportFee.GetOrCreateImportFeeByID(roomFee.ImportFeeID, helper);
                            if (importFee != null)
                            {
                                importFee.ChargeStatus = 1;
                                importFee.Save(helper);
                            }
                        }
                        roomFee.Delete(helper);
                        if (roomFee.OnlyOnceCharge)
                        {
                            if (roomFee.NewEndTime == DateTime.MinValue)
                            {
                                continue;
                            }
                            if (roomFee.EndTime >= roomFee.NewEndTime)
                            {
                                continue;
                            }
                        }
                        if (summary.FeeType != 1)
                        {
                            continue;
                        }
                        if (history.EndTime >= roomFee.NewEndTime && roomFee.NewEndTime != DateTime.MinValue)
                        {
                            continue;
                        }
                        DateTime StartTime = history.EndTime > DateTime.MinValue ? history.EndTime.AddDays(1) : DateTime.MinValue;
                        var viewChargeSummary = ViewChargeSummaryList.FirstOrDefault(p => p.ID == roomFee.ChargeID);
                        DateTime EndTime = Web.APPCode.CommHelper.GetEndTime(viewChargeSummary, StartTime);
                        DateTime CuiShouStartTime = DateTime.MinValue;
                        DateTime CuiShouEndTime = DateTime.MinValue;
                        //查询此催收单之前是否有费用
                        if (viewChargeSummary != null && viewChargeSummary.FeeType == 1)
                        {
                            RoomFeeHistory nexthistory = null;
                            var prehistory = RoomFeeHistory.GetPreRoomFeeHistory(history.ID, history.StartTime, helper, out nexthistory);
                            if (nexthistory != null)
                            {
                                CuiShouStartTime = nexthistory.StartTime;
                                CuiShouEndTime = nexthistory.EndTime;
                            }
                        }
                        var newRoomFee = Foresight.DataAccess.RoomFee.SetInfo_RoomFee(roomFee.RoomID, StartTime, EndTime, roomFee.Cost, 0, roomFee.UnitPrice, roomFee.ChargeID, ChargeFeeID: roomFee.ChargeFeeID, NewEndTime: roomFee.NewEndTime, CuiShouStartTime: CuiShouStartTime, CuiShouEndTime: CuiShouEndTime, IsCycleFee: true, cansave: true, helper: helper);
                    }
                    helper.Commit();
                    var item = new { status = true };
                    WebUtil.WriteJson(context, item);
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError("FeeCenterHandler", "visit: re_confirmechargeroomfee", ex);
                    context.Response.Write("{\"status\":false}");
                }
            }
        }
        private void loadcreatecuishouparas(HttpContext context)
        {
            try
            {
                ChargeMoneyType[] list = ChargeMoneyType.GetChargeMoneyTypes().ToArray();
                var userlist = Foresight.DataAccess.User.GetSysUserList();
                var dic = new Dictionary<string, object>();
                var userList = userlist.Select(p =>
                {
                    dic = new Dictionary<string, object>();
                    dic["UserID"] = p.UserID;
                    dic["RealName"] = p.FinalRealName;
                    return dic;
                }).ToList();
                WebUtil.WriteJson(context, new { typelist = list, userlist = userList });
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("FeeCenterHandler", "visit: loadcreatecuishouparas", ex);
                context.Response.Write("{\"list\":[]}");
            }
        }
        private void cancelprefee(HttpContext context)
        {
            bool doprint = true;
            if (!string.IsNullOrEmpty(context.Request["doprint"]))
            {
                bool.TryParse(context.Request["doprint"], out doprint);
            }
            int PrintID = WebUtil.GetIntValue(context, "PrintID");
            string RoomIDs = context.Request["RoomIDs"];
            List<int> RoomIDList = new List<int>();
            if (!string.IsNullOrEmpty(RoomIDs))
            {
                RoomIDList = JsonConvert.DeserializeObject<List<int>>(RoomIDs);
            }
            int RoomID = RoomIDList.Count > 0 ? RoomIDList[0] : 0;
            PrintRoomFeeHistory printRoomFeeHistory = null;
            if (PrintID > 0)
            {
                printRoomFeeHistory = PrintRoomFeeHistory.GetPrintRoomFeeHistory(PrintID);
            }
            if (printRoomFeeHistory != null)
            {
                if (!doprint)
                {
                    printRoomFeeHistory = SavePreChargeBackPrintRoomFeeHistory(context, printRoomFeeHistory, RoomID);
                    printRoomFeeHistory.Save();
                    #region 预收款退款保存日志
                    APPCode.CommHelper.SaveOperationLog("订单号" + printRoomFeeHistory.PrintNumber + "预收款退款保存", Utility.EnumModel.OperationModule.PreChargeFeeBackSave.ToString(), "预收款退款保存", printRoomFeeHistory.ID.ToString(), "PrintRoomFeeHistory");
                    #endregion
                }
                else
                {
                    #region 预收款退款打印日志
                    APPCode.CommHelper.SaveOperationLog("订单号" + printRoomFeeHistory.PrintNumber + "预收款退款打印", Utility.EnumModel.OperationModule.PreChargeFeeBackPrint.ToString(), "预收款退款打印", printRoomFeeHistory.ID.ToString(), "PrintRoomFeeHistory");
                    #endregion
                }
                WebUtil.WriteJson(context, new { status = true, PrintID = printRoomFeeHistory.ID });
                return;
            }
            string AddMan = context.Request.Params["AddMan"];
            int ChargeID = WebUtil.GetIntValue(context, "ChargeID");
            string ChargeMan = context.Request.Params["ChargeMan"];
            DateTime ChargeTime = WebUtil.GetDateValue(context, "ChargeTime");
            printRoomFeeHistory = SavePreChargeBackPrintRoomFeeHistory(context, printRoomFeeHistory, RoomID);
            var ItemList = JsonConvert.DeserializeObject<List<Utility.RoomFeeModule>>(context.Request["itemlist"]);

            List<RoomFeeHistory> list = new List<RoomFeeHistory>();
            foreach (var item in ItemList)
            {
                var newRoomFeeHistory = new RoomFeeHistory();
                newRoomFeeHistory.ChargeState = 6;
                newRoomFeeHistory.ID = 0;
                newRoomFeeHistory.RoomID = RoomIDList[0];
                newRoomFeeHistory.Cost = item.RealCost;
                newRoomFeeHistory.Remark = item.Remark;
                newRoomFeeHistory.AddTime = DateTime.Now;
                newRoomFeeHistory.AddUserName = User.GetCurrentUserName();
                newRoomFeeHistory.IsCharged = true;
                newRoomFeeHistory.ChargeID = ChargeID;
                newRoomFeeHistory.IsStart = true;
                newRoomFeeHistory.RealCost = item.RealCost;
                newRoomFeeHistory.RestCost = 0;
                newRoomFeeHistory.TotalDiscountCost = 0;
                newRoomFeeHistory.ChargeTime = ChargeTime == DateTime.MinValue ? DateTime.Now : ChargeTime;
                newRoomFeeHistory.ChargeMan = AddMan;
                newRoomFeeHistory.ChargeState = 6;
                newRoomFeeHistory.ChargeFeeSummaryID = ChargeID;
                newRoomFeeHistory.ChargeFeeSummaryName = item.ChargeFeeSummaryName;
                newRoomFeeHistory.ChargeFeeCurrentBalance = item.ChargeFeeCurrentBalance;
                newRoomFeeHistory.UseCount = 0;
                newRoomFeeHistory.UnitPrice = 0;
                newRoomFeeHistory.Discount = 0;
                newRoomFeeHistory.IsTempFee = true;
                list.Add(newRoomFeeHistory);
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    if (list.Count > 0)
                    {
                        printRoomFeeHistory.Save(helper);
                        foreach (var item in list)
                        {
                            item.PrintID = printRoomFeeHistory.ID;
                            item.Save(helper);
                        }
                        helper.Commit();
                    }
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError("FeeCenterHandler", "visit: cancelprefee", ex);
                    WebUtil.WriteJson(context, new { status = false });
                    return;
                }
            }
            if (!doprint)
            {
                #region 预收款退款保存日志
                APPCode.CommHelper.SaveOperationLog("订单号" + printRoomFeeHistory.PrintNumber + "预收款退款保存", Utility.EnumModel.OperationModule.PreChargeFeeBackSave.ToString(), "预收款退款保存", printRoomFeeHistory.ID.ToString(), "PrintRoomFeeHistory");
                #endregion
            }
            else
            {
                #region 预收款退款打印日志
                APPCode.CommHelper.SaveOperationLog("订单号" + printRoomFeeHistory.PrintNumber + "预收款退款打印", Utility.EnumModel.OperationModule.PreChargeFeeBackPrint.ToString(), "预收款退款打印", printRoomFeeHistory.ID.ToString(), "PrintRoomFeeHistory");
                #endregion
            }
            WebUtil.WriteJson(context, new { status = true, PrintID = printRoomFeeHistory.ID });
        }
        private void removeroomfeehistory(HttpContext context)
        {
            string ids = context.Request.Params["IDList"];
            List<int> IDList = new List<int>();
            if (!string.IsNullOrEmpty(ids))
            {
                IDList = JsonConvert.DeserializeObject<List<int>>(ids);
            }
            if (IDList.Count > 0)
            {
                using (SqlHelper helper = new SqlHelper())
                {
                    try
                    {
                        helper.BeginTransaction();
                        string cmdtext = string.Empty;
                        cmdtext += "delete from [PrintRoomFeeHistory] where [ID] in (select [PrintID] from [RoomFeeHistory] where HistoryID in (" + string.Join(",", IDList.ToArray()) + "))";
                        cmdtext += "delete from [RoomFeeHistory] where HistoryID in (" + string.Join(",", IDList.ToArray()) + ");";
                        helper.Execute(cmdtext, CommandType.Text, new List<SqlParameter>());
                        helper.Commit();
                    }
                    catch (Exception ex)
                    {
                        LogHelper.WriteError("FeeCenterHandler", "removeroomfeehistory", ex);
                        helper.Rollback();
                        WebUtil.WriteJson(context, new { status = false });
                        return;
                    }
                }
                #region 删除日志
                var user = WebUtil.GetUser(context);
                APPCode.CommHelper.SaveOperationLog(string.Join(",", IDList.ToArray()), Utility.EnumModel.OperationModule.RoomFeeHistoryDelete.ToString(), "历史账单删除", user.UserID.ToString(), "RoomFeeHistory", user.LoginName, IsHide: true);
                APPCode.CommHelper.SaveOperationLog("用户" + user.LoginName + "删除了历史账单", Utility.EnumModel.OperationModule.RoomFeeHistoryDelete.ToString(), "历史账单删除", user.UserID.ToString(), "RoomFeeHistory", user.LoginName);
                #endregion
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void deletenotes(HttpContext context)
        {
            string ids = context.Request.Params["ids"];
            List<int> IDList = new List<int>();
            if (!string.IsNullOrEmpty(ids))
            {
                IDList = JsonConvert.DeserializeObject<List<int>>(ids);
            }
            if (IDList.Count > 0)
            {
                using (SqlHelper helper = new SqlHelper())
                {
                    try
                    {
                        helper.BeginTransaction();
                        string cmdtext = "delete from [RoomFee_Note] where ID in (" + string.Join(",", IDList.ToArray()) + ")";
                        helper.Execute(cmdtext, CommandType.Text, new List<SqlParameter>());
                        helper.Commit();
                        WebUtil.WriteJson(context, new { status = true });
                    }
                    catch (Exception ex)
                    {
                        LogHelper.WriteError("FeeCenterHandler", "removeroomfeehistory", ex);
                        helper.Rollback();
                        WebUtil.WriteJson(context, new { status = false });
                    }
                }
                return;
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void getallnotes(HttpContext context)
        {
            int RoomID = WebUtil.GetIntValue(context, "RoomID");
            var list = RoomFee_Note.GetRoomFee_NoteListByRoomID(RoomID).OrderByDescending(p => p.AddTime);
            var items = list.Select(p =>
            {
                var dic = p.ToJsonObject();
                dic["FullFilePath"] = WebUtil.GetContextPath() + p.FilePath;
                return dic;
            });
            WebUtil.WriteJson(context, new { status = true, list = items });
        }
        private void saveroomfeenote(HttpContext context)
        {
            int RoomID = WebUtil.GetIntValue(context, "RoomID");
            string Title = context.Request.Params["Title"];
            string AddMan = WebUtil.GetUser(context).RealName;
            int AddManID = WebUtil.GetUser(context).UserID;
            string Remark = context.Request.Params["Remark"];
            Foresight.DataAccess.RoomFee_Note note = new RoomFee_Note();
            note.RoomID = RoomID;
            note.Title = Title;
            note.AddMan = AddMan;
            note.AddManID = AddManID;
            note.Remark = Remark;
            note.AddTime = DateTime.Now;
            HttpFileCollection uploadFiles = context.Request.Files;
            if (uploadFiles.Count > 0)
            {
                HttpPostedFile postedFile = uploadFiles[0];
                string fileOriName = postedFile.FileName;
                if (fileOriName != "" && fileOriName != null)
                {
                    string extension = System.IO.Path.GetExtension(fileOriName).ToLower();
                    string fileName = DateTime.Now.ToFileTime().ToString() + extension;
                    string filepath = "/upload/ChargeFeeNote/";
                    string rootPath = HttpContext.Current.Server.MapPath("~" + filepath);
                    if (!System.IO.Directory.Exists(rootPath))
                    {
                        System.IO.Directory.CreateDirectory(rootPath);
                    }
                    string Path = rootPath + fileName;
                    postedFile.SaveAs(Path);
                    note.FilePath = filepath + fileName;
                    note.OriFileName = System.IO.Path.GetFileNameWithoutExtension(fileOriName);
                }
            }
            note.Save();
            WebUtil.WriteJson(context, new { status = true });
        }
        private void confirmechargeroomfee(HttpContext context)
        {
            List<int> IDList = new List<int>();
            if (!string.IsNullOrEmpty(context.Request.Params["IDs"]))
            {
                IDList = JsonConvert.DeserializeObject<List<int>>(context.Request.Params["IDs"]);
            }
            var history_list = RoomFeeHistory.GetRoomFeeHistorysByHistoryIDs(IDList);
            string ChargeMan = context.Request["ChargeMan"];
            int ChargeType = WebUtil.GetIntValue(context, "ChargeType");
            DateTime ChargeTime = WebUtil.GetDateValue(context, "ChargeTime");
            string Remark = context.Request["Remark"];
            var ViewChargeSummaryList = ViewChargeSummary.GetViewChargeSummaries();
            var print_list = Foresight.DataAccess.PrintRoomFeeHistory.GetPrintRoomFeeList(RoomFeeHistoryIDList: IDList);
            foreach (var printRoomFeeHistory in print_list)
            {
                var list = history_list.Where(p => p.PrintID == printRoomFeeHistory.ID).ToArray();
                using (SqlHelper helper = new SqlHelper())
                {
                    try
                    {
                        helper.BeginTransaction();
                        printRoomFeeHistory.ChargeTime = ChargeTime;
                        printRoomFeeHistory.ChargeMan = ChargeMan;
                        printRoomFeeHistory.ChageType1 = ChargeType;
                        printRoomFeeHistory.Save(helper);
                        foreach (var history in list)
                        {
                            var roomFee = RoomFee.GetRoomFee(history.ID, helper);
                            if (roomFee == null)
                            {
                                roomFee = RoomFee.GetRoomFeeByIDs(history.RoomID, history.ChargeID, helper);
                            }
                            if (roomFee == null)
                            {
                                helper.Rollback();
                                var result = new { status = false, msg = "账单不存在或者已被删除" };
                                WebUtil.WriteJson(context, result);
                                return;
                            }
                            var viewChargeSummary = ViewChargeSummaryList.FirstOrDefault(p => p.ID == roomFee.ChargeID);
                            //查询此催收单之前是否有费用
                            RoomFeeHistory nexthistory = null;
                            DateTime CuiShouStartTime = DateTime.MinValue;
                            DateTime CuiShouEndTime = DateTime.MinValue;
                            if (viewChargeSummary != null && viewChargeSummary.FeeType == 1)
                            {
                                var prehistory = RoomFeeHistory.GetPreRoomFeeHistory(history.ID, history.StartTime, helper, out nexthistory);
                                if (prehistory != null)
                                {
                                    helper.Rollback();
                                    var result = new { status = false, msg = "请按先收取此催收单之前的费用" };
                                    WebUtil.WriteJson(context, result);
                                    return;
                                }
                                if (nexthistory != null)
                                {
                                    CuiShouStartTime = nexthistory.StartTime;
                                    CuiShouEndTime = nexthistory.EndTime;
                                }
                            }
                            history.ChargeMan = ChargeMan;
                            history.ChargeTime = ChargeTime;
                            history.Remark = Remark;
                            history.ChargeState = 1;
                            history.Save(helper);
                            if (nexthistory != null)
                            {
                                roomFee.CuiShouStartTime = CuiShouStartTime;
                                roomFee.CuiShouEndTime = CuiShouEndTime;
                                roomFee.Save(helper);
                                continue;
                            }
                            roomFee.IsCharged = true;
                            roomFee.Save(helper);
                            if (roomFee.ImportFeeID > 0)
                            {
                                ImportFee importFee = ImportFee.GetOrCreateImportFeeByID(roomFee.ImportFeeID, helper);
                                if (importFee != null)
                                {
                                    importFee.ChargeStatus = 1;
                                    importFee.Save(helper);
                                }
                            }
                            roomFee.Delete(helper);
                            if (roomFee.OnlyOnceCharge)
                            {
                                if (roomFee.NewEndTime == DateTime.MinValue)
                                {
                                    continue;
                                }
                                if (roomFee.EndTime >= roomFee.NewEndTime)
                                {
                                    continue;
                                }
                            }
                            if (viewChargeSummary.FeeType != 1)
                            {
                                continue;
                            }
                            if (roomFee.EndTime >= roomFee.NewEndTime && roomFee.NewEndTime != DateTime.MinValue)
                            {
                                continue;
                            }
                            DateTime StartTime = history.EndTime > DateTime.MinValue ? history.EndTime.AddDays(1) : DateTime.MinValue;
                            DateTime EndTime = Web.APPCode.CommHelper.GetEndTime(viewChargeSummary, StartTime);
                            var newRoomFee = Foresight.DataAccess.RoomFee.SetInfo_RoomFee(roomFee.RoomID, StartTime, EndTime, roomFee.Cost, 0, roomFee.UnitPrice, viewChargeSummary.ID, ChargeFeeID: roomFee.ChargeFeeID, NewEndTime: roomFee.NewEndTime, CuiShouStartTime: CuiShouStartTime, CuiShouEndTime: CuiShouEndTime, IsCycleFee: true, cansave: true, helper: helper);
                        }
                        helper.Commit();
                    }
                    catch (Exception ex)
                    {
                        helper.Rollback();
                        LogHelper.WriteError("FeeCenterHandler", "visit: confirmechargeroomfee", ex);
                        context.Response.Write("{\"status\":false}");
                    }
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void getendtime(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            string IDs = context.Request.Params["IDList"];
            List<int> IDList = new List<int>();
            if (!string.IsNullOrEmpty(IDs))
            {
                IDList = JsonConvert.DeserializeObject<List<int>>(IDs);
            }
            DateTime StartTime = WebUtil.GetDateValue(context, "StartTime");
            DateTime EndTime = DateTime.MinValue;
            if (StartTime > DateTime.MinValue)
            {
                RoomFee roomFee = new RoomFee();
                if (ID > 0)
                {
                    roomFee = RoomFee.GetRoomFee(ID);
                }
                else
                {
                    var roomFeeList = RoomFee.GetRoomFeeListByIDs(IDList);
                    roomFee = roomFeeList.FirstOrDefault();
                }
                var viewChargeSummary = ViewChargeSummary.GetViewChargeSummaryByChargeID(roomFee.ChargeID);
                EndTime = Web.APPCode.CommHelper.GetEndTime(viewChargeSummary, StartTime);
            }
            WebUtil.WriteJson(context, new { status = true, EndTime = (EndTime > DateTime.MinValue ? EndTime.ToString("yyyy-MM-dd") : "") });
        }
        private void batchsavefee(HttpContext context)
        {
            string ids = context.Request.Params["ids"];
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(ids);
            var RoomFeeList = Foresight.DataAccess.RoomFee.GetRoomFeeListByIDs(IDList);
            if (RoomFeeList.Length == 0)
            {
                WebUtil.WriteJson(context, new { status = false, msg = "参数错误" });
                return;
            }
            bool clearstarttime = false;
            if (!string.IsNullOrEmpty(context.Request["clearstarttime"]))
            {
                bool.TryParse(context.Request["clearstarttime"], out clearstarttime);
            }
            bool clearendtime = false;
            if (!string.IsNullOrEmpty(context.Request["clearendtime"]))
            {
                bool.TryParse(context.Request["clearendtime"], out clearendtime);
            }
            if (clearstarttime)
            {
                foreach (var item in RoomFeeList)
                {
                    item.StartTime = DateTime.MinValue;
                }
            }
            else if (clearendtime)
            {
                foreach (var item in RoomFeeList)
                {
                    item.EndTime = DateTime.MinValue;
                }
            }
            else
            {
                DateTime StartTime = GetDateValue(context, "StartTime");
                DateTime EndTime = GetDateValue(context, "EndTime");
                if (StartTime > EndTime)
                {
                    WebUtil.WriteJson(context, new { status = false, msg = "计费开始日期不能大于计费结束日期" });
                    return;
                }
                decimal UnitPrice = decimal.MinValue;
                if (!string.IsNullOrEmpty(context.Request["UnitPrice"]))
                {
                    UnitPrice = GetDecimalValue(context, "UnitPrice");
                }
                foreach (var item in RoomFeeList)
                {
                    if (item.NewEndTime > DateTime.MinValue)
                    {
                        if (item.NewEndTime < StartTime)
                        {
                            continue;
                        }
                        if (item.NewEndTime < EndTime)
                        {
                            item.EndTime = item.NewEndTime;
                        }
                        if (StartTime > DateTime.MinValue)
                        {
                            item.StartTime = StartTime;
                        }
                    }
                    else
                    {
                        if (StartTime > DateTime.MinValue)
                        {
                            item.StartTime = StartTime;
                        }
                        if (EndTime > DateTime.MinValue)
                        {
                            item.EndTime = EndTime;
                        }
                    }
                    if (UnitPrice > decimal.MinValue)
                    {
                        item.UnitPrice = UnitPrice;
                    }
                }
            }

            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    if (RoomFeeList.Length > 0)
                    {
                        foreach (var item in RoomFeeList)
                        {
                            item.Save(helper);
                        }
                        helper.Commit();
                    }
                    context.Response.Write("{\"status\":true}");
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError("FeeCenterHandler", "visit:batchsavefee", ex);
                    context.Response.Write("{\"status\":false}");
                }
            }
        }
        private void CancelGuaranteePrintFee(HttpContext context)
        {
            string GUID = context.Request.Params["GUID"];
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    string cmdtext = "delete from [ChargeBackGuaranteeTemp] where [GUID]=@GUID";
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    parameters.Add(new SqlParameter("@GUID", GUID));
                    helper.Execute(cmdtext, CommandType.Text, parameters);
                    helper.Commit();
                    context.Response.Write("{\"status\":true}");
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError("FeeCenterHandler", "visit:CancelGuaranteePrintFee", ex);
                    context.Response.Write("{\"status\":false}");
                }
            }
        }
        private void CancelPrintFee(HttpContext context)
        {
            string TempHistoryIDs = context.Request.Params["TempHistoryIDs"];
            List<int> TempHistoryIDList = JsonConvert.DeserializeObject<List<int>>(TempHistoryIDs);
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    string cmdtext = "delete from [TempRoomFee] where [TempID] in (select [TempID] from [TempRoomFeeHistory] where [TempHistoryID] in (" + string.Join(",", TempHistoryIDList.ToArray()) + "))";
                    cmdtext += "delete from [TempRoomFeeHistory] where [TempHistoryID] in (" + string.Join(",", TempHistoryIDList.ToArray()) + ")";
                    helper.Execute(cmdtext, CommandType.Text, new List<SqlParameter>());
                    helper.Commit();
                    context.Response.Write("{\"status\":true}");
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError("FeeCenterHandler", "visit:CancelPrintFee", ex);
                    context.Response.Write("{\"status\":false}");
                }
            }

        }
        private void ViewRoomWeiShuBalance(HttpContext context)
        {
            int PrintID = int.Parse(context.Request.Params["PrintID"]);
            decimal total = PrintRoomFeeHistory.GetRoomWeiShuBalance(PrintID, 0);
            context.Response.Write("{\"balance\":" + total + "}");
        }
        private void CheckRoomFeeSummary(HttpContext context)
        {
            string ChargeIDs = context.Request.Params["summaryids"];
            List<int> ChargeIDList = new List<int>();
            if (!string.IsNullOrEmpty(ChargeIDs))
            {
                ChargeIDList = JsonConvert.DeserializeObject<List<int>>(ChargeIDs);
            }
            string ProjectIDs = context.Request.Params["projectids"];
            List<int> ProjectIDList = new List<int>();
            if (!string.IsNullOrEmpty(ProjectIDs))
            {
                ProjectIDList = JsonConvert.DeserializeObject<List<int>>(ProjectIDs);
            }
            string RoomIDs = context.Request.Params["roomids"];
            List<int> RoomIDList = new List<int>();
            if (!string.IsNullOrEmpty(RoomIDs))
            {
                RoomIDList = JsonConvert.DeserializeObject<List<int>>(RoomIDs);
            }
            var list = RoomFee.GetRoomFeeListByParams(ProjectIDList, RoomIDList, ChargeIDList, UserID: WebUtil.GetUser(context).UserID);
            if (list.Length > 0)
            {
                var items = new { status = true, hasfee = true };
                context.Response.Write(JsonConvert.SerializeObject(items));
                return;
            }
            var newitems = new { status = true, hasfee = false };
            context.Response.Write(JsonConvert.SerializeObject(newitems));
        }
        private void PrintChargeFee(HttpContext context)
        {
            int PrintID = int.Parse(context.Request.Params["PrintID"]);
            string Remark = context.Request.Params["Remark"];
            var printRoomFeeHistory = PrintRoomFeeHistory.GetPrintRoomFeeHistory(PrintID);
            printRoomFeeHistory.PrintCount = printRoomFeeHistory.PrintCount == int.MinValue ? 1 : printRoomFeeHistory.PrintCount + 1;
            printRoomFeeHistory.LastPrintTime = DateTime.Now;
            printRoomFeeHistory.PrintRemark = Remark;
            printRoomFeeHistory.IsRePrint = printRoomFeeHistory.PrintCount > 1 ? true : false;
            printRoomFeeHistory.Save();
            context.Response.Write("{\"status\":true}");
        }
        private void GetAllowImportChargeSummaryList(HttpContext context)
        {
            try
            {
                int CompanyID = int.Parse(context.Request.Params["CompanyID"]);
                ChargeSummary[] summarylist = ChargeSummary.GetAllowImportChargeSummarys(CompanyID).ToArray();
                context.Response.Write(JsonConvert.SerializeObject(summarylist));
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("FeeCenterHandler", "visit:GetAllowImportChargeSummaryList", ex);
                context.Response.Write("{\"data\":[]}");
            }
        }
        private void CheckPreChargeRoomFeeHistory(HttpContext context)
        {
            string RoomIDs = context.Request.Params["RoomIDs"];
            List<int> RoomIDList = new List<int>();
            if (!string.IsNullOrEmpty(RoomIDs))
            {
                RoomIDList = JsonConvert.DeserializeObject<List<int>>(RoomIDs);
            }
            List<int> ChargeState = new List<int>();
            ChargeState.Add(4);
            int State = 1;
            var roomFeeHistory = RoomFeeHistory.GetRoomFeeHistoryListByRoomIDListAndChargeState(RoomIDList, ChargeState);
            if (roomFeeHistory.Length > 0)
            {
                State = 2;//预收款已经冲销
            }
            context.Response.Write("{\"status\":" + State + "}");
        }
        private void CheckTempSummaryHistoryFee(HttpContext context)
        {
            string ChargeIDStr = context.Request.Params["ChargeIDs"];
            List<int> ChargeIDList = new List<int>();
            if (!string.IsNullOrEmpty(ChargeIDStr))
            {
                ChargeIDList = JsonConvert.DeserializeObject<List<int>>(ChargeIDStr);
            }
            List<int> RoomIDList = new List<int>();
            List<int> FeeID = new List<int>();
            int State = 1;
            for (int i = 0; i < ChargeIDList.Count; i++)
            {
                //是否有导入账单信息
                var ImportFeeList = ImportFee.GetImportFeeByChargeID(ChargeIDList[i]);
                if (ImportFeeList.Length > 0)
                {
                    State = 4;//有导入账单信息
                    break;
                }
                var roomFeeHistory = RoomFeeHistory.GetRoomFeeHistoryListByRoomIDList(RoomIDList, ChargeIDList[i], FeeID, UserID: WebUtil.GetUser(context).UserID);
                if (roomFeeHistory.Length == 0)
                {
                    //没有历史收费                        
                    continue;
                }
                var roomFeeHistoryitem = roomFeeHistory.FirstOrDefault(p => p.ChargeState != 2);
                if (roomFeeHistoryitem == null)
                {
                    State = 2;//有历史收费且都已作废
                    continue;
                }
                State = 3;//有历史收费且未作废
                break;
            }
            context.Response.Write("{\"status\":" + State + "}");
        }
        private void CheckExistRoomSourceFee(HttpContext context)
        {
            string RoomIDs = context.Request.Params["RoomIDs"];
            List<int> RoomIDList = new List<int>();
            if (!string.IsNullOrEmpty(RoomIDs))
            {
                RoomIDList = JsonConvert.DeserializeObject<List<int>>(RoomIDs);
            }
            if (RoomIDList.Count == 0)
            {
                context.Response.Write("{\"status\":false}");
                return;
            }
            List<int> ChargeState = new List<int>();
            ChargeState.Add(1);
            ChargeState.Add(4);
            var roomFeeHistory = RoomFeeHistory.GetRoomFeeHistoryListByRoomIDListAndChargeState(RoomIDList, ChargeState);
            if (roomFeeHistory.Length > 0)
            {
                context.Response.Write("{\"status\":false}");
                return;
            }
            context.Response.Write("{\"status\":true}");
        }
        private void LoadRoomResourceFeeList(HttpContext context)
        {
            try
            {
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                string RoomIDs = context.Request.Params["RoomIDs"];
                List<int> RoomIDList = new List<int>();
                if (!string.IsNullOrEmpty(RoomIDs))
                {
                    RoomIDList = JsonConvert.DeserializeObject<List<int>>(RoomIDs);
                }
                string ProjectIDs = context.Request.Params["ProjectID"];
                List<int> ProjectIDList = new List<int>();
                if (RoomIDList.Count == 0)
                {
                    if (!string.IsNullOrEmpty(ProjectIDs))
                    {
                        ProjectIDList = JsonConvert.DeserializeObject<List<int>>(ProjectIDs).Where(p => p != 1).ToList();
                    }
                    ProjectIDList = WebUtil.GetMyProjects(WebUtil.GetUser(context).UserID, ProjectIDList).Where(p => p.ID != 1).Select(p => p.ID).ToList();
                }
                int ChargeID = 0;
                int.TryParse(context.Request.Params["ChargeID"], out ChargeID);
                string keywords = context.Request.Params["keywords"];
                bool IsContractFee = false;
                if (!string.IsNullOrEmpty(context.Request["IsContractFee"]))
                {
                    bool.TryParse(context.Request["IsContractFee"], out IsContractFee);
                }
                bool IsRoomFee = true;
                if (!string.IsNullOrEmpty(context.Request["IsRoomFee"]))
                {
                    bool.TryParse(context.Request["IsRoomFee"], out IsRoomFee);
                }
                string RoomProperty = context.Request["RoomProperty"];
                DataGrid dg = ViewRoomSourceFee.GetViewRoomSourceFeeGridByKeywords(keywords, RoomIDList, ProjectIDList, ChargeID, IsRoomFee, IsContractFee, RoomProperty, "order by DefaultOrder asc,ChargeID asc", startRowIndex, pageSize, UserID: WebUtil.GetUser(context).UserID);
                string result = JsonConvert.SerializeObject(dg);
                context.Response.Write(result);
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("FeeCenterHandler", "visit: LoadRoomResourceFeeList", ex);
                context.Response.Write("{\"rows\":[],\"total\":0,\"page\":0}");
            }
        }
        /// <summary>
        /// 检测当前收费项目是否已收费
        /// </summary>
        /// <param name="context"></param>
        private void CheckExistSummary(HttpContext context)
        {
            int ID = int.Parse(context.Request.Params["ID"]);
            string RoomIDs = context.Request.Params["RoomIDs"];
            List<int> RoomIDList = new List<int>();
            if (!string.IsNullOrEmpty(RoomIDs))
            {
                RoomIDList = JsonConvert.DeserializeObject<List<int>>(RoomIDs);
            }
            if (RoomIDList.Count == 0 && !string.IsNullOrEmpty(context.Request.Params["ProjectID"]))
            {
                int ProjectID = int.Parse(context.Request.Params["ProjectID"]);
                Project[] list = Project.GetAllRoomChild(ProjectID);
                RoomIDList = list.Select(p => p.ID).ToList();
            }
            var roomFee = RoomFee.GetRoomFeeListByRoomIDList(-1, RoomIDList, ID);
            if (roomFee.Length > 0)
            {
                context.Response.Write("{\"status\":false}");
                return;
            }

            var roomFeeHistory = RoomFeeHistory.GetRoomFeeHistoryListByRoomIDList(RoomIDList, ID, UserID: WebUtil.GetUser(context).UserID);
            if (roomFeeHistory.Length > 0)
            {
                context.Response.Write("{\"status\":false}");
                return;
            }
            context.Response.Write("{\"status\":true}");
        }
        private void CheckResourceHistoryFee(HttpContext context)
        {
            string IDs = context.Request.Params["IDList"];
            List<int> IDList = new List<int>();
            if (!string.IsNullOrEmpty(IDs))
            {
                IDList = JsonConvert.DeserializeObject<List<int>>(IDs);
            }
            if (IDList.Count == 0)
            {
                WebUtil.WriteJson(context, new { status = false, error = "请选择需要删除的费项" });
                return;
            }
            var roomFeeHistory = RoomFeeHistory.GetRoomFeeHistoryByFeeIDList(IDList);
            if (roomFeeHistory.Length == 0)
            {
                WebUtil.WriteJson(context, new { status = true });
                return;
            }
            var roomFeeHistoryitem = roomFeeHistory.FirstOrDefault(p => p.ChargeState == 1 || p.ChargeState == 4);
            if (roomFeeHistoryitem != null)
            {
                WebUtil.WriteJson(context, new { status = false, error = "选择的费项已部分收款，禁止删除" });
                return;
            }
            roomFeeHistoryitem = roomFeeHistory.FirstOrDefault(p => p.ChargeState == 5);
            if (roomFeeHistoryitem != null)
            {
                WebUtil.WriteJson(context, new { status = false, error = "选择的费项催收中，禁止删除" });
                return;
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void DeleteTempRoomFee(HttpContext context)
        {
            string IDStr = context.Request.Params["RoomFeeIDList"];
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(IDStr);
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    foreach (var ID in IDList)
                    {
                        RoomFee roomFee = RoomFee.GetRoomFee(ID, helper);
                        if (roomFee != null)
                        {
                            ChargeSummary summary = ChargeSummary.GetChargeSummary(roomFee.ChargeID, helper);
                            if (summary.FeeType != 4)
                            {
                                continue;
                            }
                            roomFee.Delete(helper);
                        }
                    }
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError("FeeCenterHandler", "visit:DeleteTempRoomFee", ex);
                    WebUtil.WriteJson(context, new { status = false });
                    return;
                }
            }
            #region 删除日志
            var user = WebUtil.GetUser(context);
            APPCode.CommHelper.SaveOperationLog(string.Join(",", IDList.ToArray()), Utility.EnumModel.OperationModule.TempRoomFeeDelete.ToString(), "临时费项删除", user.UserID.ToString(), "RoomFee", user.LoginName, IsHide: true);
            APPCode.CommHelper.SaveOperationLog("用户" + user.LoginName + "删除了临时费项", Utility.EnumModel.OperationModule.TempRoomFeeDelete.ToString(), "临时费项删除", user.UserID.ToString(), "RoomFee", user.LoginName);
            #endregion
            WebUtil.WriteJson(context, new { status = true });
        }
        private void LoadChargeSummaryType(HttpContext context)
        {
            try
            {
                ChargeMoneyType[] list = ChargeMoneyType.GetChargeMoneyTypes().ToArray();
                string result = JsonConvert.SerializeObject(list);
                context.Response.Write("{\"list\":" + result + "}");
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("FeeCenterHandler", "visit: LoadChargeSummaryType", ex);
                context.Response.Write("{\"list\":[]}");
            }
        }
        private void DeleteChargeSummary(HttpContext context)
        {
            int ID = int.Parse(context.Request.Params["ID"]);
            ChargeSummary summary = ChargeSummary.GetChargeSummary(ID);
            if (summary == null)
            {
                context.Response.Write("{\"status\":0}");
                return;
            }
            RoomFee roomFee = RoomFee.GetRoomFeeByChargeID(0, ID);
            if (roomFee != null)
            {
                context.Response.Write("{\"status\":2}");
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    summary.Delete(helper);
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    parameters.Add(new SqlParameter("@ChargeID", ID));
                    string cmdtext = "delete from [ChargeFee] where ChargeID=@ChargeID;";
                    helper.Execute(cmdtext, CommandType.Text, parameters);
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError("FeeCenterHandler", "visit: DeleteChargeSummary", ex);
                    context.Response.Write("{\"status\":0}");
                    return;
                }
            }
            #region 删除日志
            var user = WebUtil.GetUser(context);
            APPCode.CommHelper.SaveOperationLog(summary.ID.ToString(), Utility.EnumModel.OperationModule.ChargeSummaryDelete.ToString(), "收费项目删除", user.UserID.ToString(), "ChargeSummary", user.LoginName, IsHide: true);
            APPCode.CommHelper.SaveOperationLog("用户" + user.LoginName + "删除了收费项目", Utility.EnumModel.OperationModule.ChargeSummaryDelete.ToString(), "收费项目删除", user.UserID.ToString(), "ChargeSummary", user.LoginName);
            #endregion
            context.Response.Write("{\"status\":1}");
        }
        private void SaveChargeSummary(HttpContext context)
        {
            int ID = int.Parse(context.Request.Params["ID"]);
            string Name = context.Request.Params["Name"];
            int TypeID = int.Parse(context.Request.Params["TypeID"]);
            int CategoryID = int.Parse(context.Request.Params["CategoryID"]);
            int EndNumber = int.Parse(context.Request.Params["EndNumber"]);
            int OrderBy = 0;
            int.TryParse(context.Request.Params["OrderBy"], out OrderBy);
            int EndNumberCount = 0;
            int.TryParse(context.Request.Params["EndNumberCount"], out EndNumberCount);
            bool IsAllowImport = int.Parse(context.Request.Params["IsAllowImport"]) == 1 ? true : false;
            if (OrderBy == int.MinValue)
            {
                OrderBy = 0;
            }
            ChargeSummary summary = ChargeSummary.GetChargeSummary(ID);
            if (summary == null)
            {
                context.Response.Write("{\"status\":false}");
                return;
            }
            summary.Name = Name;
            summary.TypeID = TypeID;
            summary.CategoryID = CategoryID;
            summary.EndNumber = EndNumber;
            summary.OrderBy = OrderBy;
            summary.IsAllowImport = IsAllowImport;
            summary.EndNumberCount = EndNumberCount;
            summary.Save();
            context.Response.Write("{\"status\":true}");
        }
        private void AddChargeSummary(HttpContext context)
        {
            string Name = context.Request.Params["Name"];
            int CompanyID = int.Parse(context.Request.Params["CompanyID"]);
            int FeeType = int.Parse(context.Request.Params["FeeType"]);
            int TypeID = int.Parse(context.Request.Params["TypeID"]);
            int OrderBy = 0;
            int.TryParse(context.Request.Params["OrderBy"], out OrderBy);
            if (OrderBy == int.MinValue)
            {
                OrderBy = 0;
            }
            int CategoryID = int.Parse(context.Request.Params["CategoryID"]);
            int RuleID = int.Parse(context.Request.Params["RuleID"]);
            int EndNumber = int.Parse(context.Request.Params["EndNumber"]);
            decimal SummaryUnitPrice = decimal.MinValue;
            decimal Coefficient = decimal.MinValue;
            int IntAllowImport = 0;
            int.TryParse(context.Request.Params["AllowImport"], out IntAllowImport);
            int EndNumberCount = 2;
            if (!string.IsNullOrEmpty(context.Request.Params["EndNumberCount"]))
            {
                int.TryParse(context.Request.Params["EndNumberCount"], out EndNumberCount);
            }
            int isread = 0;
            int.TryParse(context.Request.Params["IsReading"], out isread);
            bool IsReading = isread == 1 ? true : false;
            ChargeSummary summary = new ChargeSummary();
            summary.Name = Name;
            summary.AddTime = DateTime.Now;
            summary.CompanyID = CompanyID;
            summary.FeeType = FeeType;
            summary.TypeID = TypeID;
            summary.OrderBy = OrderBy;
            summary.CategoryID = CategoryID;
            summary.RuleID = RuleID;
            summary.EndNumber = EndNumber;
            summary.SummaryUnitPrice = SummaryUnitPrice;
            summary.Coefficient = Coefficient;
            summary.IsAllowImport = IntAllowImport == 1 ? true : false;
            summary.EndNumberCount = EndNumberCount;
            summary.IsReading = IsReading;
            summary.Save();
            context.Response.Write("{\"status\":true}");
        }
        private void LoadGuaranteeFeeList(HttpContext context)
        {
            try
            {
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                string RoomID = context.Request.Params["RoomID"];
                List<int> RoomIDList = new List<int>();
                if (!string.IsNullOrEmpty(RoomID))
                {
                    RoomIDList = JsonConvert.DeserializeObject<List<int>>(RoomID);
                }
                int CategoryID = 0;
                int.TryParse(context.Request.Params["CategoryID"], out CategoryID);
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                DataGrid dg = ViewGuaranteeHistoryFee.GetGuaranteeRoomFeeGridByRoomID(RoomIDList, CategoryID, "order by RoomName", startRowIndex, pageSize);
                string result = JsonConvert.SerializeObject(dg);
                context.Response.Write(result);
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("FeeCenterHandler", "visit: LoadGuaranteeFeeList", ex);
                context.Response.Write("{\"rows\":[],\"total\":0,\"page\":0}");
            }
        }
        /// <summary>
        /// 作废单据
        /// </summary>
        /// <param name="context"></param>
        private void CancelHistoryFee(HttpContext context)
        {
            string AddMan = WebUtil.GetUser(context).RealName;
            string PrintIDs = context.Request.Params["PrintIDList"];
            string IDs = context.Request.Params["IDList"];
            List<int> PrintIDList = new List<int>();
            if (!string.IsNullOrEmpty(PrintIDs))
            {
                PrintIDList = JsonConvert.DeserializeObject<List<int>>(PrintIDs);
            }
            List<int> IDList = new List<int>();
            if (!string.IsNullOrEmpty(IDs))
            {
                IDList = JsonConvert.DeserializeObject<List<int>>(IDs);
            }
            var print_list = PrintRoomFeeHistory.GetPrintRoomFeeList(IDList: PrintIDList, RoomFeeHistoryIDList: IDList);
            var history_list = new RoomFeeHistory[] { };
            bool status = false;
            string error = string.Empty;
            if (PrintIDList.Count > 0)
            {
                history_list = RoomFeeHistory.GetRoomFeeHistoryListByPrintIDList(PrintIDList);
            }
            else if (IDList.Count > 0)
            {
                history_list = RoomFeeHistory.GetRoomFeeHistorysByHistoryIDs(IDList);
            }
            status = APPCode.HandlerHelper.CancelHistoryFeeProcess(context, AddMan, history_list, print_list, out error);
            WebUtil.WriteJson(context, new { status = status, error = error });
        }
        /// <summary>
        /// 查看缴费记录
        /// </summary>
        /// <param name="context"></param>
        private void LoadRoomFeeHistoryList(HttpContext context)
        {
            try
            {
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                int CompanyID = 0;
                int.TryParse(context.Request.Params["CompanyID"], out CompanyID);
                string RoomID = context.Request.Params["RoomID"];
                List<int> RoomIDList = new List<int>();
                if (!string.IsNullOrEmpty(RoomID))
                {
                    RoomIDList = JsonConvert.DeserializeObject<List<int>>(RoomID);
                }
                string ProjectIDs = context.Request.Params["ProjectID"];
                List<int> ProjectIDList = new List<int>();
                if (RoomIDList.Count == 0)
                {
                    if (!string.IsNullOrEmpty(ProjectIDs))
                    {
                        ProjectIDList = JsonConvert.DeserializeObject<List<int>>(ProjectIDs).Where(p => p != 1).ToList();
                    }
                    ProjectIDList = WebUtil.GetMyProjects(WebUtil.GetUser(context).UserID, ProjectIDList).Where(p => p.ID != 1).Select(p => p.ID).ToList();
                }
                int FeeID = 0;
                int.TryParse(context.Request.Params["FeeID"], out FeeID);
                DateTime StartChargeTime = DateTime.MinValue;
                DateTime.TryParse(context.Request.Params["StartChargeTime"], out StartChargeTime);
                DateTime EndChargeTime = DateTime.MinValue;
                DateTime.TryParse(context.Request.Params["EndChargeTime"], out EndChargeTime);
                bool IncludIsCharged = false;
                bool.TryParse(context.Request.Params["IncludIsCharged"], out IncludIsCharged);
                bool IncludePreCharge = false;
                bool.TryParse(context.Request.Params["IncludePreCharge"], out IncludePreCharge);
                bool IncludeDepoistCharge = false;
                bool.TryParse(context.Request.Params["IncludeDepoistCharge"], out IncludeDepoistCharge);
                int DepoistStatus = int.MinValue;
                int.TryParse(context.Request.Params["DepoistStatus"], out DepoistStatus);
                int PreChargeStatus = int.MinValue;
                int.TryParse(context.Request.Params["PreChargeStatus"], out PreChargeStatus);
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                string ChargeMans = context.Request.Params["ChargeMans"];
                int[] ChargeManID = new int[] { };
                if (!string.IsNullOrEmpty(ChargeMans) && !ChargeMans.Equals("[\"\"]"))
                {
                    ChargeManID = JsonConvert.DeserializeObject<int[]>(ChargeMans);
                }
                string ChargeSummarys = context.Request.Params["ChargeSummarys"];
                int[] ChargeSummaryID = new int[] { };
                if (!string.IsNullOrEmpty(ChargeSummarys))
                {
                    ChargeSummaryID = JsonConvert.DeserializeObject<int[]>(ChargeSummarys);
                }
                string ChargeTypes = context.Request.Params["ChargeTypes"];
                int[] ChargeTypeID = new int[] { };
                if (!string.IsNullOrEmpty(ChargeTypes))
                {
                    ChargeTypeID = JsonConvert.DeserializeObject<int[]>(ChargeTypes);
                }
                string Categories = context.Request.Params["Categories"];
                int[] CategoryID = new int[] { };
                if (!string.IsNullOrEmpty(Categories))
                {
                    CategoryID = JsonConvert.DeserializeObject<int[]>(Categories);
                }
                bool IncludeFooter = false;
                if (!string.IsNullOrEmpty(context.Request.Params["IncludeFooter"]))
                {
                    bool.TryParse(context.Request.Params["IncludeFooter"], out IncludeFooter);
                }
                string ChargeStatus = context.Request.Params["ChargeStatus"];
                List<int> ChargeStatusIDList = new List<int>();
                if (!string.IsNullOrEmpty(ChargeStatus))
                {
                    ChargeStatusIDList = JsonConvert.DeserializeObject<List<int>>(ChargeStatus);
                }
                int RoomFeeOrderID = GetIntValue(context, "RoomFeeOrderID");
                bool IsRoomFeeSearch = false;
                bool.TryParse(context.Request.Params["IsRoomFeeSearch"], out IsRoomFeeSearch);
                bool IsCuiShou = false;
                if (!string.IsNullOrEmpty(context.Request.Params["IsCuiShou"]))
                {
                    bool.TryParse(context.Request.Params["IsCuiShou"], out IsCuiShou);
                }
                int ContractID = WebUtil.GetIntValue(context, "ContractID");
                bool ExcludeCuiShou = false;
                if (!string.IsNullOrEmpty(context.Request["ExcludeCuiShou"]))
                {
                    bool.TryParse(context.Request["ExcludeCuiShou"], out ExcludeCuiShou);
                }
                List<int> HistoryIDList = new List<int>();
                if (!string.IsNullOrEmpty(context.Request["HistoryIDs"]))
                {
                    HistoryIDList = JsonConvert.DeserializeObject<List<int>>(context.Request["HistoryIDs"]);
                }
                int DivideID = WebUtil.GetIntValue(context, "DivideID");
                bool canexport = WebUtil.GetBoolValue(context, "canexport");
                bool IncludeTime = WebUtil.GetBoolValue(context, "IncludeTime");
                string RelationBelongTeam = context.Request["RelationBelongTeam"];
                int PayOnLineStatus = WebUtil.GetIntValue(context, "PayOnLineStatus");
                DataGrid dg = ViewRoomFeeHistory.GetViewRoomFeeHistoryGridByRoomID(RoomIDList, ProjectIDList, FeeID, StartChargeTime, EndChargeTime, IncludIsCharged, IncludePreCharge, IncludeDepoistCharge, DepoistStatus, PreChargeStatus, CompanyID, ChargeManID, ChargeSummaryID, ChargeTypeID, CategoryID, ChargeStatusIDList, RoomFeeOrderID, IsRoomFeeSearch, IsCuiShou, ContractID, "order by [ChargeTime] desc", startRowIndex, pageSize, HistoryIDList, ExcludeCuiShou, IncludeFooter: IncludeFooter, DivideID: DivideID, UserID: WebUtil.GetUser(context).UserID, canexport: canexport, IncludeTime: IncludeTime, RelationBelongTeam: RelationBelongTeam, PayOnLineStatus: PayOnLineStatus);
                if (canexport)
                {
                    string downloadurl = string.Empty;
                    string error = string.Empty;
                    bool status = false;
                    string source = context.Request["source"];
                    source = string.IsNullOrEmpty(source) ? "" : source;
                    if (source.Equals("ToCuiKuanDetails"))
                    {
                        status = APPCode.ExportHelper.DownLoadToCuiKuanDetailsListData(dg, out downloadurl, out error);
                    }
                    else if (source.Equals("ToCuiKuanDetailsDaiKou"))
                    {
                        status = APPCode.ExportHelper.DownLoadToCuiKuanDetailsDaiKouListData(dg, out downloadurl, out error);
                    }
                    else if (source.Equals("PreChargeAnalysisDetails"))
                    {
                        status = APPCode.ExportHelper.DownLoadPreChargeAnalysisData(dg, out downloadurl, out error);
                    }
                    else
                    {
                        status = APPCode.ExportHelper.DownLoadRoomFeeHistoryListData(dg, out downloadurl, out error);
                    }
                    WebUtil.WriteJson(context, new { status = status, downloadurl = downloadurl, error = error });
                }
                else
                {
                    WebUtil.WriteJson(context, dg);
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("FeeCenterHandler", "visit: LoadRoomFeeHistoryList", ex);
                WebUtil.WriteJson(context, new Foresight.DataAccess.Ui.DataGrid());
            }
        }
        private void getroomprechargebalancetitle(HttpContext context)
        {
            List<Dictionary<string, object>> temp = new List<Dictionary<string, object>>();
            List<int> RoomIDList = JsonConvert.DeserializeObject<List<int>>(context.Request.Params["RoomIDs"]);
            int ChargeID = WebUtil.GetIntValue(context, "ChargeID");
            var summarylist = Foresight.DataAccess.ChargeSummary.GetChargeSummarysByCategoryID(4);
            decimal total = 0;
            Dictionary<string, object> dic = new Dictionary<string, object>();
            foreach (var item in summarylist)
            {
                total = Foresight.DataAccess.ViewRoomBalance.GetPreChargeBalance(RoomIDList, item.ID);
                if (total > 0)
                {
                    dic = new Dictionary<string, object>();
                    dic["ChargeID"] = item.ID;
                    dic["ChargeName"] = item.Name;
                    dic["balance"] = total;
                    temp.Add(dic);
                }
            }
            WebUtil.WriteJson(context, new { status = true, list = temp });
        }
        private void ViewRoomBalance(HttpContext context)
        {
            List<int> RoomIDList = JsonConvert.DeserializeObject<List<int>>(context.Request.Params["RoomIDs"]);
            int ChargeID = WebUtil.GetIntValue(context, "ChargeID");
            decimal total = Foresight.DataAccess.ViewRoomBalance.GetPreChargeBalance(RoomIDList, ChargeID);
            decimal guaranteefee = Foresight.DataAccess.ViewRoomBalance.GetGuaranteeBalance(RoomIDList);
            WebUtil.WriteJson(context, new { status = true, balance = total, guaranteefee = guaranteefee });
        }
        /// <summary>
        /// 直接打印临时收费
        /// </summary>
        /// <param name="context"></param>
        private void ChargeTempRoomFee(HttpContext context)
        {
            int CompanyID = WebUtil.GetIntValue(context, "CompanyID");
            string AddMan = context.Request.Params["AddMan"];
            string Fields = context.Request.Params["Fields"];
            string RoomIDs = context.Request.Params["RoomIDs"];
            int ContractID = WebUtil.GetIntValue(context, "ContractID");
            List<int> RoomIDList = JsonConvert.DeserializeObject<List<int>>(RoomIDs);
            List<RoomFeeChangeField> fields = JsonConvert.DeserializeObject<List<RoomFeeChangeField>>(Fields);
            List<int> HistoryListID = new List<int>();
            if (RoomIDList.Count == 0)
            {
                WebUtil.WriteJson(context, new { status = false });
                return;
            }
            var relation_list = Foresight.DataAccess.RoomPhoneRelation.GetRoomPhoneRelationsByRoomIDList(RoomIDList);
            #region 临时费项
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    foreach (var roomID in RoomIDList)
                    {
                        Project project = Project.GetProject(roomID, helper);
                        foreach (var field in fields)
                        {
                            var roomFee = new TempRoomFee();
                            roomFee.ID = 0;
                            roomFee.RoomID = project.ID;
                            roomFee.UseCount = field.UseCount < 0 ? 0 : field.UseCount;
                            roomFee.Cost = field.Cost;
                            roomFee.AddTime = DateTime.Now;
                            roomFee.IsCharged = true;
                            roomFee.ChargeFeeID = 0;
                            roomFee.ChargeID = field.ID;
                            roomFee.IsStart = true;
                            roomFee.UnitPrice = field.UnitPrice;
                            roomFee.RealCost = field.RealCost;
                            roomFee.Discount = field.Discount;
                            roomFee.Remark = field.Remark;
                            roomFee.ChargeFee = 0;
                            roomFee.TotalRealCost = field.RealCost;
                            roomFee.TotalDiscountCost = field.Discount;
                            roomFee.RestCost = 0;
                            roomFee.StartTime = string.IsNullOrEmpty(field.StartTime) ? DateTime.MinValue : DateTime.Parse(field.StartTime);
                            roomFee.EndTime = string.IsNullOrEmpty(field.EndTime) ? DateTime.MinValue : DateTime.Parse(field.EndTime);
                            roomFee.DiscountID = field.DiscountID;
                            roomFee.ContractID = ContractID;
                            roomFee.OnlyOnceCharge = true;
                            if (roomFee.ContractID <= 0)
                            {
                                var default_relation = relation_list.FirstOrDefault(p => p.RoomID == roomFee.RoomID);
                                if (default_relation != null)
                                {
                                    roomFee.DefaultChargeManID = default_relation.ID;
                                    roomFee.DefaultChargeManName = default_relation.RelationName;
                                }
                            }
                            else
                            {
                                var contract = Foresight.DataAccess.Contract.GetContract(roomFee.ContractID, helper);
                                roomFee.DefaultChargeManID = 0;
                                roomFee.DefaultChargeManName = contract != null ? contract.RentName : string.Empty;
                            }
                            roomFee.IsTempFee = true;
                            roomFee.Save(helper);
                            int HistoryID = TempRoomFeeHistory.InsertTempRoomFeeHistoryByTempFeeID(roomFee.TempID, AddMan, helper);
                            HistoryListID.Add(HistoryID);
                            roomFee.Delete(helper);
                        }
                    }
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError("FeeCenterHandler", "visit: ChargeTempRoomFee", ex);
                    context.Response.Write("{\"status\":false}");
                    return;
                }
            }
            #endregion
            string RoomFeeFields = context.Request.Params["RoomFeeFields"];
            List<RoomFeeChangeField> RoomFeeFieldList = JsonConvert.DeserializeObject<List<RoomFeeChangeField>>(RoomFeeFields);
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    foreach (var field in RoomFeeFieldList)
                    {
                        int tempID = TempRoomFee.InsertTempRoomFeeByRoomFeeID(field.ID, helper);
                        var roomFee = TempRoomFee.GetTempRoomFee(tempID, helper);
                        DateTime Start = DateTime.MinValue;
                        DateTime.TryParse(field.StartTime, out Start);
                        roomFee.StartTime = Start;
                        DateTime End = DateTime.MinValue;
                        DateTime.TryParse(field.EndTime, out End);
                        roomFee.EndTime = End;
                        roomFee.OutDays = field.OutDays;
                        roomFee.UseCount = field.UseCount;
                        roomFee.Cost = field.Cost;
                        roomFee.Remark = field.Remark;
                        roomFee.IsCharged = true;
                        roomFee.UnitPrice = field.UnitPrice;
                        roomFee.ChargeFee = field.ChargeFee;
                        roomFee.RealCost = field.ChargeFee > 0 ? field.ChargeFee : field.RealCost;
                        roomFee.Discount = field.Discount;
                        roomFee.TotalRealCost = (roomFee.TotalRealCost < 0 ? 0 : roomFee.TotalRealCost);
                        roomFee.TotalDiscountCost = (roomFee.TotalDiscountCost < 0 ? 0 : roomFee.TotalDiscountCost);
                        decimal restcost = roomFee.Cost - roomFee.TotalDiscountCost - roomFee.TotalRealCost;
                        if (restcost < 0)
                        {
                            restcost = 0;
                        }
                        roomFee.RestCost = restcost;
                        DateTime NewEndTime = DateTime.MinValue;
                        DateTime.TryParse(field.NewEndTime, out NewEndTime);
                        roomFee.NewEndTime = NewEndTime;
                        roomFee.ContractID = ContractID;
                        if (roomFee.DefaultChargeManID <= 0 && string.IsNullOrEmpty(roomFee.DefaultChargeManName))
                        {
                            if (roomFee.ContractID <= 0)
                            {
                                var default_relation = relation_list.FirstOrDefault(p => p.RoomID == roomFee.RoomID);
                                if (default_relation != null)
                                {
                                    roomFee.DefaultChargeManID = default_relation.ID;
                                    roomFee.DefaultChargeManName = default_relation.RelationName;
                                }
                            }
                            else
                            {
                                var contract = Foresight.DataAccess.Contract.GetContract(roomFee.ContractID, helper);
                                roomFee.DefaultChargeManID = 0;
                                roomFee.DefaultChargeManName = contract != null ? contract.RentName : string.Empty;
                            }
                        }
                        roomFee.Save(helper);
                        int HistoryID = TempRoomFeeHistory.InsertTempRoomFeeHistoryByTempFeeID(roomFee.TempID, AddMan, helper);
                        HistoryListID.Add(HistoryID);
                    }
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError("FeeCenterHandler", "visit: ChargeTempRoomFee", ex);
                    context.Response.Write("{\"status\":false}");
                    return;
                }
            }
            context.Response.Write("{\"status\":true,\"HistoryListID\":" + JsonConvert.SerializeObject(HistoryListID) + "}");
        }

        /// <summary>
        /// 保存临时收费
        /// </summary>
        /// <param name="context"></param>
        private void SaveTempRoomFee(HttpContext context)
        {
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    string summarys = context.Request.Params["SummaryList"];
                    string AddMan = context.Request.Params["AddMan"];
                    List<ChargeSummaryDetails> list = JsonConvert.DeserializeObject<List<ChargeSummaryDetails>>(summarys);
                    string RoomIDs = context.Request.Params["RoomIDs"];
                    List<int> RoomIDList = JsonConvert.DeserializeObject<List<int>>(RoomIDs);
                    foreach (var roomID in RoomIDList)
                    {
                        Project project = Project.GetProject(roomID, helper);
                        foreach (var summary in list)
                        {
                            var newRoomFee = Foresight.DataAccess.RoomFee.SetInfo_RoomFee(project.ID, DateTime.MinValue, DateTime.MinValue, summary.Cost, summary.RealCost, summary.SummaryUnitPrice, summary.ID, UseCount: summary.CalculateUseCount, Discount: summary.Discount, Remark: summary.Remark, IsTempFee: true, cansave: true, helper: helper);
                        }
                    }
                    helper.Commit();
                    context.Response.Write("{\"status\":true}");
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError("FeeCenterHandler", "visit: SaveTempRoomFee", ex);
                    context.Response.Write("{\"status\":false}");
                }
            }
        }
        private void GetChargeSummaryList(HttpContext context)
        {
            try
            {
                int FeeType = WebUtil.GetIntValue(context, "FeeType");
                int CompanyID = WebUtil.GetIntValue(context, "CompanyID");
                string FeeTypeListStr = context.Request.Params["FeeTypeList"];
                List<int> FeeTypeList = new List<int>();
                if (!string.IsNullOrEmpty(FeeTypeListStr))
                {
                    FeeTypeList = JsonConvert.DeserializeObject<List<int>>(FeeTypeListStr);
                }
                bool IsReading = false;
                if (!string.IsNullOrEmpty(context.Request.Params["IsReading"]))
                {
                    bool.TryParse(context.Request.Params["IsReading"], out IsReading);
                }
                bool IsAllowImport = false;
                if (!string.IsNullOrEmpty(context.Request.Params["IsAllowImport"]))
                {
                    bool.TryParse(context.Request.Params["IsAllowImport"], out IsAllowImport);
                }
                int CategoryID = WebUtil.GetIntValue(context, "CategoryID");
                ChargeSummary[] summarylist = ChargeSummary.GetChargeSummaryByID(FeeTypeList, 0, CompanyID, FeeType, IsReading, IsAllowImport, CategoryID).ToArray();
                context.Response.Write(JsonConvert.SerializeObject(summarylist));
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("FeeCenterHandler", "visit: GetChargeSummaryList", ex);
                context.Response.Write("{\"data\":[]}");
            }
        }
        private void SaveSummaryFee(HttpContext context)
        {
            int ID = 0;
            int.TryParse(context.Request.Params["id"], out ID);
            string Name = context.Request.Params["name"];
            int chargetype = int.Parse(context.Request.Params["chargetype"]);
            int category = int.Parse(context.Request.Params["category"]);
            int endnumber = int.Parse(context.Request.Params["endnumber"]);
            decimal coefficient = decimal.Parse(context.Request.Params["coefficient"]);
            string unit = context.Request.Params["unit"];
            int sortorder = 1;
            int.TryParse(context.Request.Params["sortorder"], out sortorder);
            decimal summaryunitprice = 0;
            decimal.TryParse(context.Request.Params["summaryunitprice"], out summaryunitprice);
            int CompanyID = int.Parse(context.Request.Params["CompanyID"]);
            int FeeType = int.Parse(context.Request.Params["FeeType"]);
            int isread = 0;
            int.TryParse(context.Request.Params["IsReading"], out isread);
            bool IsReading = isread == 1 ? true : false;
            int IntAllowImport = 0;
            int.TryParse(context.Request.Params["AllowImport"], out IntAllowImport);
            int EndNumberCount = 2;
            if (!string.IsNullOrEmpty(context.Request.Params["EndNumberCount"]))
            {
                int.TryParse(context.Request.Params["EndNumberCount"], out EndNumberCount);
            }
            ChargeSummary chargeSummary = new ChargeSummary();
            if (ID > 0)
            {
                chargeSummary = ChargeSummary.GetChargeSummary(ID);
            }
            else
            {
                chargeSummary.AddTime = DateTime.Now;
            }
            chargeSummary.Unit = unit;
            chargeSummary.Coefficient = coefficient;
            chargeSummary.RuleID = 1;
            chargeSummary.CompanyID = CompanyID;
            chargeSummary.FeeType = FeeType;
            chargeSummary.OrderBy = sortorder;
            chargeSummary.EndNumber = endnumber;
            chargeSummary.Name = Name;
            chargeSummary.TypeID = chargetype;
            chargeSummary.CategoryID = category;
            chargeSummary.SummaryUnitPrice = summaryunitprice;
            chargeSummary.IsReading = IsReading;
            chargeSummary.IsAllowImport = IntAllowImport == 1 ? true : false;
            chargeSummary.EndNumberCount = EndNumberCount;
            chargeSummary.Save();
            context.Response.Write("{\"status\":true}");
        }
        private void DeleteSummaryFee(HttpContext context)
        {
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(context.Request.Params["list"]);
            if (IDList.Count == 0)
            {
                WebUtil.WriteJson(context, new { status = false, error = "请选择数据，操作取消" });
                return;
            }
            int roomfee_total = RoomFee.GetRoomFeeListCountByChargeIDList(IDList);
            if (roomfee_total > 0)
            {
                WebUtil.WriteJson(context, new { status = false, error = "有未收费的单据，操作取消" });
                return;
            }
            var history_count = RoomFeeHistory.GetRoomFeeHistoryListCountByChargeIDList(ChargeIDList: IDList);
            if (history_count > 0)
            {
                WebUtil.WriteJson(context, new { status = false, error = "有已收费的单据，操作取消" });
                return;
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    string cmdstr = "delete from [ChargeSummary] where ID in (" + string.Join(" , ", IDList.ToArray()) + ");";
                    cmdstr += "delete from [ChargeFee] where ChargeID in (" + string.Join(" , ", IDList.ToArray()) + ");";
                    //cmdstr += "delete from [RoomFee] where ChargeID in (" + string.Join(" , ", list.ToArray()) + ");";
                    //cmdstr += "delete from [ImportFee] where ChargeID in (" + string.Join(" , ", list.ToArray()) + ");";
                    helper.Execute(cmdstr, CommandType.Text, parameters);
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError("FeeCenterHandler", "visit: DeleteSummaryFee", ex);
                    WebUtil.WriteJson(context, new { status = false });
                    return;
                }
            }
            #region 删除日志
            var user = WebUtil.GetUser(context);
            APPCode.CommHelper.SaveOperationLog(string.Join(",", IDList.ToArray()), Utility.EnumModel.OperationModule.ChargeSummaryDelete.ToString(), "收费项目删除", user.UserID.ToString(), "ChargeSummary", user.LoginName, IsHide: true);
            APPCode.CommHelper.SaveOperationLog("用户" + user.LoginName + "删除了收费项目", Utility.EnumModel.OperationModule.ChargeSummaryDelete.ToString(), "收费项目删除", user.UserID.ToString(), "ChargeSummary", user.LoginName);
            #endregion
            WebUtil.WriteJson(context, new { status = true });
        }
        private void LoadlTempSummaryList(HttpContext context)
        {
            try
            {
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                List<int> RoomIDList = JsonConvert.DeserializeObject<List<int>>(context.Request.Params["RoomIDs"]);
                int RoomID = RoomIDList.Count > 0 ? RoomIDList[0] : 0;
                DataGrid dg = ChargeSummaryDetails.GetTempChargeSummaryGrid(RoomID, "order by [OrderBy]", startRowIndex, pageSize);
                string result = JsonConvert.SerializeObject(dg);
                context.Response.Write(result);
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("FeeCenterHandler", "visit: LoadlTempSummaryList", ex);
                context.Response.Write("{\"rows\":[],\"total\":0,\"page\":0}");
            }
        }
        private void LoadlChargeSummaryList(HttpContext context)
        {
            try
            {
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                int FeeType = 0;
                int.TryParse(context.Request.Params["FeeType"], out FeeType);
                int CategoryID = 0;
                int.TryParse(context.Request.Params["CategoryID"], out CategoryID);
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                string SummaryType = context.Request.Params["SummaryType"];
                int ContractID = WebUtil.GetIntValue(context, "ContractID");
                string guid = context.Request.Params["guid"];
                string keywords = context.Request["keywords"];
                DataGrid dg = ViewChargeSummary.GetViewChargeSummaryGrid(FeeType, CategoryID, SummaryType, ContractID, guid, "order by [OrderBy]", startRowIndex, pageSize, keywords);
                string result = JsonConvert.SerializeObject(dg);
                context.Response.Write(result);
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("FeeCenterHandler", "visit: LoadlChargeSummaryList", ex);
                context.Response.Write("{\"rows\":[],\"total\":0,\"page\":0}");
            }
        }
        private void LoadlFeeSummaryList(HttpContext context)
        {
            try
            {
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                int FeeType = 0;
                int.TryParse(context.Request.Params["FeeType"], out FeeType);
                int CategoryID = 0;
                int.TryParse(context.Request.Params["CategoryID"], out CategoryID);
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                bool exclude = false;
                List<int> RoomIDs = new List<int>();
                if (!string.IsNullOrEmpty(context.Request.Params["exclude"]))
                {
                    exclude = true;
                    RoomIDs = JsonConvert.DeserializeObject<List<int>>(context.Request.Params["RoomIDs"]);
                }
                DataGrid dg = ChargeSummaryDetails.GetChargeSummaryGrid(FeeType, CategoryID, "order by [OrderBy]", startRowIndex, pageSize, exclude, RoomIDs);
                string result = JsonConvert.SerializeObject(dg);
                context.Response.Write(result);
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("FeeCenterHandler", "visit: LoadlFeeSummaryList", ex);
                context.Response.Write("{\"rows\":[],\"total\":0,\"page\":0}");
            }
        }
        /// <summary>
        /// 删除收费标准
        /// </summary>
        /// <param name="context"></param>
        private void RemoveRoomFee(HttpContext context)
        {
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    int FeeID = int.Parse(context.Request.Params["FeeID"]);
                    List<int> IDarry = new List<int>();
                    helper.BeginTransaction();
                    ChargeFee chargeFee = ChargeFee.GetChargeFee(FeeID, helper);
                    chargeFee.IsActive = false;
                    chargeFee.Save(helper);
                    IDarry.Add(FeeID);
                    if (chargeFee.CID > 0)
                    {
                        ChargeFee newchargeFee = ChargeFee.GetChargeFee(chargeFee.CID, helper);
                        if (!newchargeFee.IsActive)
                        {
                            IDarry.Add(newchargeFee.ID);
                        }
                    }
                    string commandText = @"update [RoomFee] set [IsStart]=0 where ChargeFeeID in (" + string.Join(",", IDarry.ToArray()) + ");";
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    helper.Execute(commandText, CommandType.Text, parameters);
                    helper.Commit();
                    context.Response.Write("{\"status\":true}");
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError("FeeCenterHandler", "visit: RemoveRoomFee", ex);
                    context.Response.Write("{\"status\":false}");
                }
            }
        }
        /// <summary>
        /// 停用收费标准
        /// </summary>
        /// <param name="context"></param>
        private void CancelRoomFee(HttpContext context)
        {
            string RoomFeeIDs = context.Request.Params["RoomFeeIDs"];
            DateTime EndTime = WebUtil.GetDateValue(context, "stoptime");
            var RoomFeeIDList = JsonConvert.DeserializeObject<List<int>>(RoomFeeIDs);
            var roomFeeList = RoomFeeAnalysis.GetRoomFeeAnalysisListByIDList(RoomFeeIDList);
            bool isFail = false;
            List<string> errorlist = new List<string>();
            string commandText = string.Empty;
            foreach (var roomFee in roomFeeList)
            {
                DateTime FeeStartTime = roomFee.CalculateStartTime;
                if (EndTime == DateTime.MinValue)
                {
                    commandText += "update [RoomFee] set [NewEndTime]=NULL where [ID]=" + roomFee.ID + ";";
                }
                else if (FeeStartTime > EndTime)
                {
                    errorlist.Add(roomFee.RoomName);
                    isFail = true;
                    continue;
                }
                else
                {
                    DateTime FeeEndTime = roomFee.CalculateEndTime;
                    if (FeeEndTime >= EndTime)
                    {
                        commandText += "update [RoomFee] set [EndTime]=@EndTime,[NewEndTime]=@EndTime where [ID]=" + roomFee.ID + ";";
                        continue;
                    }
                    else
                    {
                        commandText += "update [RoomFee] set [NewEndTime]=@EndTime where [ID]=" + roomFee.ID + ";";
                        continue;
                    }
                }
            }
            if (isFail || string.IsNullOrEmpty(commandText))
            {
                var item = new { status = 4, errorcount = errorlist.Count };
                context.Response.Write(JsonConvert.SerializeObject(item));
                return;
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    if (EndTime > DateTime.MinValue)
                    {
                        parameters.Add(new SqlParameter("@EndTime", EndTime));
                    }
                    helper.Execute(commandText, CommandType.Text, parameters);
                    helper.Commit();
                    context.Response.Write("{\"status\":1}");
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError("FeeCenterHandler", "visit: CancelRoomFee", ex);
                    context.Response.Write("{\"status\":0}");
                }
            }
        }
        private void LoadCheckFeeIds(HttpContext context)
        {
            int RoomID = 0;
            int.TryParse(context.Request.Params["RoomID"], out RoomID);
            int ChargeID = 0;
            int.TryParse(context.Request.Params["ChargeID"], out ChargeID);
            var roomfeelist = RoomFee.GetRoomFeeListByRoomID(RoomID, ChargeID);
            List<RoomFee> newlist = new List<RoomFee>();
            foreach (var item in roomfeelist)
            {
                var chargefee = ChargeFee.GetChargeFee(item.ChargeFeeID);
                if (item.UnitPrice <= 0)
                {
                    item.UnitPrice = chargefee.UnitPrice;
                }
                if (item.StartTime == DateTime.MinValue)
                {
                    item.StartTime = chargefee.StartTime;
                }
                if (item.EndTime == DateTime.MinValue)
                {
                    item.EndTime = chargefee.EndTime;
                }
                newlist.Add(item);
            }
            string liststr = JsonConvert.SerializeObject(newlist);
            var result = "{\"status\":true,\"list\":" + liststr + "}";
            context.Response.Write(result);
        }
        /// <summary>
        /// 添加收费标准
        /// </summary>
        /// <param name="context"></param>
        private void AddChargePrice(HttpContext context)
        {
            int ChargeID = GetIntValue(context, "ChargeID");
            ViewChargeSummary viewsummary = null;
            ChargeSummary summary = null;
            if (ChargeID > 0)
            {
                summary = ChargeSummary.GetChargeSummary(ChargeID);
            }
            if (summary != null)
            {
                viewsummary = ViewChargeSummary.GetViewChargeSummaryByChargeID(ChargeID);
            }
            else
            {
                summary = new ChargeSummary();
                summary.AddTime = DateTime.Now;
                summary.OrderBy = 0;
                summary.RuleID = 1;
                summary.EndNumber = 3;
            }
            summary.Name = context.Request.Params["Name"];
            var exist_summary = Foresight.DataAccess.ChargeSummary.GetChargeSummaryByChargeName(summary.ID, summary.Name);
            if (exist_summary != null)
            {
                WebUtil.WriteJson(context, new { status = false, error = "收费项目名称已存在，请重新填写" });
                return;
            }
            summary.CompanyID = GetIntValue(context, "CompanyID");
            summary.FeeType = GetIntValue(context, "FeeType");
            summary.TypeID = GetIntValue(context, "ChargeType");
            summary.CategoryID = GetIntValue(context, "Category");
            summary.EndTypeID = GetIntValue(context, "EndType");
            summary.SummaryUnitPrice = GetDecimalValue(context, "UnitPrice");
            summary.Unit = context.Request.Params["Unit"];
            summary.Remark = context.Request.Params["Remark"];
            summary.IsReading = GetIntValue(context, "IsReading") == 1 ? true : false;
            summary.EndNumberCount = GetIntValue(context, "EndNumberCount");
            summary.IsAllowImport = GetIntValue(context, "AllowImport") == 1 ? true : false;
            summary.SummaryStartTime = GetDateValue(context, "StartTime");
            summary.SummaryEndStartTime = GetDateValue(context, "EndTime");
            summary.SummaryChargeTypeCount = GetIntValue(context, "ChargeTypeCount");
            summary.EndNumberType = GetIntValue(context, "EndNumberType");
            summary.AutoToMonthEnd = GetIntValue(context, "AutoNextMonth") == 1 ? true : false;
            summary.BiaoCategory = context.Request.Params["BiaoCategory"];
            summary.BiaoName = context.Request.Params["BiaoName"];
            summary.TimeAuto = GetIntValue(context, "TimeAuto") == 1 ? true : false;
            summary.OrderBy = GetIntValue(context, "SortOrder");
            summary.IsOrderFeeOn = GetIntValue(context, "IsOrderFeeOn") == 1 ? true : false;
            summary.CalculateAreaType = context.Request.Params["CalculateAreaType"];
            summary.StartPriceRange = WebUtil.GetIntValue(context, "StartPriceRange") == 1 ? true : false;
            summary.PriceRangeStartTime = WebUtil.GetDateValue(context, "PriceRangeStartTime");
            summary.ChargeFeeType = WebUtil.GetIntValue(context, "ChargeFeeType");
            string[] ChargeBiaoIDArray = new string[] { };
            string ChargeBiaoIDs = context.Request.Params["ChargeBiaoIDs"];
            if (!string.IsNullOrEmpty(ChargeBiaoIDs))
            {
                ChargeBiaoIDArray = ChargeBiaoIDs.Split(',');
            }
            List<ChargeSummary_Biao> biaoList = new List<ChargeSummary_Biao>();
            foreach (var item in ChargeBiaoIDArray)
            {
                int ChargeBiaoID = 0;
                int.TryParse(item, out ChargeBiaoID);
                if (ChargeBiaoID <= 0)
                {
                    continue;
                }
                ChargeSummary_Biao chargeSummary_Biao = new ChargeSummary_Biao();
                chargeSummary_Biao.ChargeBiaoID = ChargeBiaoID;
                biaoList.Add(chargeSummary_Biao);
            }
            summary.WeiYuePercent = WebUtil.GetDecimalValue(context, "WeiYuePercent");
            string RelateCharges = context.Request.Params["RelateCharges"];
            if (!string.IsNullOrEmpty(RelateCharges))
            {
                string[] RelateChargesArray = JsonConvert.DeserializeObject<string[]>(RelateCharges);
                RelateCharges = string.Empty;
                foreach (var item in RelateChargesArray)
                {
                    if (string.IsNullOrEmpty(item))
                    {
                        continue;
                    }
                    RelateCharges += item + ",";
                }
            }
            RelateCharges = string.IsNullOrEmpty(RelateCharges) ? "" : "," + RelateCharges;
            summary.RelateCharges = RelateCharges;
            summary.ChargeWeiYueType = WebUtil.GetIntValue(context, "ChargeWeiYueType");
            summary.DayGunLi = WebUtil.GetIntValue(context, "DayGunLi") == 1 ? true : false;
            summary.WeiYueStartDate = context.Request.Params["WeiYueStartDate"];
            summary.WeiYueBefore = context.Request.Params["WeiYueBefore"];
            summary.WeiYueDays = WebUtil.GetIntValue(context, "WeiYueDays");
            summary.WeiYueActiveStartDate = context.Request["WeiYueActiveStartDate"];
            summary.WeiYueActiveBeforeAfter = context.Request["WeiYueActiveBeforeAfter"];
            summary.WeiYueActiveCount = WebUtil.GetIntValue(context, "WeiYueActiveCount");
            summary.WeiYueActiveDayMonth = context.Request["WeiYueActiveDayMonth"];
            summary.WeiYueEndDate = context.Request["WeiYueEndDate"];
            summary.DisableDefaultImportFee = WebUtil.GetIntValue(context, "DisableDefaultImportFee") == 1;

            #region 周期费用
            ChargeFee chargeFee = null;
            if (summary.FeeType == 1 || summary.FeeType == 5)
            {
                if (viewsummary != null && viewsummary.FeeID > 0)
                {
                    chargeFee = ChargeFee.GetChargeFee(viewsummary.FeeID);
                }
                if (chargeFee == null)
                {
                    chargeFee = new ChargeFee();
                    chargeFee.AddTime = DateTime.Now;
                }
                chargeFee.UnitPrice = summary.SummaryUnitPrice;
                chargeFee.EndTypeID = summary.EndTypeID;
                chargeFee.StartTime = summary.SummaryStartTime;
                chargeFee.EndTime = summary.SummaryEndStartTime;
                chargeFee.IsActive = true;
                chargeFee.Remark = summary.Remark;
                chargeFee.ChargeTypeCount = summary.SummaryChargeTypeCount;
            }
            #endregion
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    summary.Save(helper);
                    if (biaoList.Count > 0)
                    {
                        string cmdtext = "delete from [ChargeSummary_Biao] where [ChargeID]=" + summary.ID;
                        helper.Execute(cmdtext, CommandType.Text, new List<SqlParameter>());
                        foreach (var biao in biaoList)
                        {
                            biao.ChargeID = summary.ID;
                            biao.Save(helper);
                        }
                    }
                    if (chargeFee != null)
                    {
                        chargeFee.ChargeID = summary.ID;
                        chargeFee.Save(helper);
                    }
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError("FeeCenterHandler", "visit: AddChargePrice", ex);
                    WebUtil.WriteJson(context, new { status = false });
                    return;
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void SavePrintRoomFeeHistory(HttpContext context, PrintRoomFeeHistory printRoomFeeHistory, SqlHelper helper, int RoomID = 0)
        {
            int ChargeType1 = GetIntValue(context, "ChargeMoneyType1");
            int ChargeType2 = GetIntValue(context, "ChargeMoneyType2");
            string PrintNumber = context.Request.Params["PrintNumber"];
            //decimal Cost = decimal.Parse(context.Request.Params["Cost"]);
            decimal RealCost = GetDecimalValue(context, "RealCost");
            decimal TotalCost = GetDecimalValue(context, "TotalCost");
            decimal PreChargeMoney = GetDecimalValue(context, "PreChargeMoney");
            decimal ChargeBackMoney = GetDecimalValue(context, "ChargeBackMoney");
            decimal RealMoneyCost1 = GetDecimalValue(context, "RealMoneyCost1");
            decimal RealMoneyCost2 = GetDecimalValue(context, "RealMoneyCost2");
            decimal DiscountMoney = GetDecimalValue(context, "DiscountMoney");
            decimal WeiShu = GetDecimalValue(context, "WeiShu");
            decimal money = GetDecimalValue(context, "money");
            string MoneyDaXie = context.Request.Params["MoneyDaXie"];
            string ChargeMan = context.Request.Params["ChargeMan"];
            DateTime ChargeTime = GetDateValue(context, "ChargeTime");
            string Remark = context.Request.Params["Remark"];
            int OrderNumberID = GetIntValue(context, "OrderNumberID");
            var nextPrintRoomFeeHistory = PrintRoomFeeHistory.GetPrintRoomFeeHistoryByPrintNumber(PrintNumber, printRoomFeeHistory.ID, helper);
            if (nextPrintRoomFeeHistory != null)
            {
                PrintNumber = PrintRoomFeeHistory.GetLastestPrintNumber(OrderTypeNameDefine.chargefee.ToString(), RoomID, helper, out OrderNumberID);
            }
            var sys_ordernumber = Foresight.DataAccess.Sys_OrderNumber.GetSys_OrderNumber(OrderNumberID, helper);
            printRoomFeeHistory.PrintNumber = PrintNumber;
            printRoomFeeHistory.OrderNumberID = sys_ordernumber != null ? sys_ordernumber.ID : 0;
            printRoomFeeHistory.OrderNumberType = sys_ordernumber != null ? sys_ordernumber.ChargeType : 1;
            printRoomFeeHistory.Cost = TotalCost;
            printRoomFeeHistory.CostCapital = MoneyDaXie;
            printRoomFeeHistory.RealCost = RealCost;
            printRoomFeeHistory.PreChargeMoney = PreChargeMoney;
            printRoomFeeHistory.ChargeBackMoney = ChargeBackMoney;
            printRoomFeeHistory.RealMoneyCost1 = RealMoneyCost1;
            printRoomFeeHistory.RealMoneyCost2 = RealMoneyCost2;
            printRoomFeeHistory.DiscountMoney = DiscountMoney;
            printRoomFeeHistory.ChargeMan = ChargeMan;
            printRoomFeeHistory.ChargeTime = ChargeTime;
            printRoomFeeHistory.Remark = Remark;
            printRoomFeeHistory.ChageType1 = ChargeType1;
            printRoomFeeHistory.ChageType2 = ChargeType2;
            if (printRoomFeeHistory.AddTime == DateTime.MinValue)
            {
                printRoomFeeHistory.AddTime = DateTime.Now;
            }
            decimal weishumore = printRoomFeeHistory.RealCost - printRoomFeeHistory.Cost;
            printRoomFeeHistory.WeiShuMore = weishumore > 0 ? weishumore : 0;
            decimal weishuconsume = printRoomFeeHistory.Cost - printRoomFeeHistory.RealCost;
            printRoomFeeHistory.WeiShuConsume = weishuconsume > 0 ? weishuconsume : 0;
            printRoomFeeHistory.RoomFullName = context.Request.Params["RoomFullName"];
            printRoomFeeHistory.RoomOwnerName = context.Request.Params["RoomOwnerName"];
            printRoomFeeHistory.ChargeForSummary = context.Request["ChargeForSummary"];
            printRoomFeeHistory.ChargeMethods = context.Request["ChargeMethods"];
            printRoomFeeHistory.WeiShuBalance = WebUtil.GetDecimalValue(context, "WeiShuBalance");
            printRoomFeeHistory.Save(helper);
        }
        private void saveprintfeenew(HttpContext context)
        {
            var PrintIDList = new List<int>();
            if (!string.IsNullOrEmpty(context.Request["PrintIDList"]))
            {
                PrintIDList = Utility.JsonConvert.DeserializeObject<List<int>>(context.Request["PrintIDList"]);
            }
            if (PrintIDList.Count > 0)
            {
                WebUtil.WriteJson(context, new { status = true, print_cheque_status = true, PrintIDList = PrintIDList, error = "" });
                return;
            }
            List<int> TempHistoryIDList = new List<int>();
            if (!string.IsNullOrEmpty(context.Request.Params["TempHistoryIDs"]))
            {
                TempHistoryIDList = JsonConvert.DeserializeObject<List<int>>(context.Request.Params["TempHistoryIDs"]);
            }
            if (TempHistoryIDList.Count == 0)
            {
                WebUtil.WriteJson(context, new { status = false, error = "请选择需要打印的单据" });
                return;
            }
            var dataList = new List<Dictionary<string, object>>();
            if (!string.IsNullOrEmpty(context.Request["dataList"]))
            {
                dataList = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(context.Request.Params["dataList"]);
            }
            if (TempHistoryIDList.Count == 0 || dataList.Count == 0)
            {
                WebUtil.WriteJson(context, new { status = false, error = "请选择需要打印的单据" });
                return;
            }
            var list = TempRoomFeeHistory.GetTempRoomFeeHistoryListByIDs(TempHistoryIDList);
            if (list.Length == 0)
            {
                WebUtil.WriteJson(context, new { status = false, error = "请选择需要打印的单据" });
                return;
            }
            var ViewChargeSummaryList = ViewChargeSummary.GetViewChargeSummaries().ToArray();
            var user = WebUtil.GetUser(context);
            bool print_cheque_status = false;
            bool result = false;
            string errormsg = string.Empty;
            foreach (var item in dataList)
            {
                var myTempHistoryIDList = new List<int>();
                if (!string.IsNullOrEmpty(item["TempHistoryIDs"].ToString()))
                {
                    myTempHistoryIDList = Utility.JsonConvert.DeserializeObject<List<int>>(item["TempHistoryIDs"].ToString());
                }

                var myList = list.Where(p => myTempHistoryIDList.Contains(p.TempHistoryID)).ToArray();
                if (myList.Length == 0)
                {
                    continue;
                }
                int out_printid = 0;
                result = APPCode.HandlerHelper.SavePrintFee(item, out out_printid, out print_cheque_status, out errormsg, myList, ViewChargeSummaryList);
                PrintIDList.Add(out_printid);
            }
            WebUtil.WriteJson(context, new { status = result, print_cheque_status = print_cheque_status, PrintIDList = PrintIDList, error = errormsg });
        }
        /// <summary>
        /// 保存收费打单
        /// </summary>
        /// <param name="context"></param>
        private void SavePrintFee(HttpContext context)
        {
            List<int> TempHistoryIDList = new List<int>();
            if (!string.IsNullOrEmpty(context.Request.Params["TempHistoryIDs"]))
            {
                TempHistoryIDList = JsonConvert.DeserializeObject<List<int>>(context.Request.Params["TempHistoryIDs"]);
            }
            var list = TempRoomFeeHistory.GetTempRoomFeeHistoryListByIDs(TempHistoryIDList);

            var ViewChargeSummaryList = ViewChargeSummary.GetViewChargeSummaries().ToArray();
            int out_printid = 0;
            string errormsg = string.Empty;
            bool print_cheque_status = true;
            var user = WebUtil.GetUser(context);
            bool result = APPCode.HandlerHelper.SavePrintFee(AccpetParam, out out_printid, out print_cheque_status, out errormsg, list, ViewChargeSummaryList);
            WebUtil.WriteJson(context, new { status = result, print_cheque_status = print_cheque_status, PrintID = out_printid, error = errormsg });
        }
        /// <summary>
        /// 收费打单
        /// </summary>
        /// <param name="context"></param>
        private void ChargeRoomFee(HttpContext context)
        {
            int CompanyID = 0;
            int.TryParse(context.Request.Params["CompanyID"], out CompanyID);
            string AddMan = context.Request.Params["AddMan"];
            string Fields = context.Request.Params["Fields"];
            List<RoomFeeChangeField> fields = JsonConvert.DeserializeObject<List<RoomFeeChangeField>>(Fields);
            List<int> HistoryListID = new List<int>();
            var relation_list = Foresight.DataAccess.RoomPhoneRelation.GetDefaultInChargeFeeRoomPhoneRelationList(fields.Select(p => p.ID).ToList());
            bool isWechatCharge = RoomFee.IsWechatChargeingFee(fields.Select(p => p.ID).ToArray());
            if (isWechatCharge)
            {
                WebUtil.WriteJson(context, new { status = false, error = "客户正在使用微信缴费，请过一分钟后在尝试" });
                return;
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    foreach (var field in fields)
                    {
                        var is_cuishou = RoomFeeHistory.CheckCuiShouRoomFeeHistoryByID(field.ID, helper);
                        if (is_cuishou)
                        {
                            helper.Rollback();
                            WebUtil.WriteJson(context, new { status = false, error = "账单催收中，禁止收费" });
                            return;
                        }
                        int tempID = TempRoomFee.InsertTempRoomFeeByRoomFeeID(field.ID, helper);
                        var roomFee = TempRoomFee.GetTempRoomFee(tempID, helper);
                        DateTime Start = DateTime.MinValue;
                        DateTime.TryParse(field.StartTime, out Start);
                        roomFee.StartTime = Start;
                        DateTime End = DateTime.MinValue;
                        DateTime.TryParse(field.EndTime, out End);
                        roomFee.EndTime = End;
                        roomFee.OutDays = field.OutDays;
                        roomFee.UseCount = field.UseCount;
                        roomFee.Cost = field.Cost;
                        roomFee.Remark = field.Remark;
                        roomFee.IsCharged = true;
                        roomFee.UnitPrice = field.UnitPrice;
                        roomFee.ChargeFee = field.ChargeFee;
                        roomFee.RealCost = field.ChargeFee > 0 ? field.ChargeFee : field.RealCost;
                        roomFee.Discount = field.Discount;
                        roomFee.TotalRealCost = (roomFee.TotalRealCost < 0 ? 0 : roomFee.TotalRealCost);
                        roomFee.TotalDiscountCost = (roomFee.TotalDiscountCost < 0 ? 0 : roomFee.TotalDiscountCost);
                        decimal restcost = roomFee.Cost - roomFee.TotalDiscountCost - roomFee.TotalRealCost;
                        if (restcost < 0)
                        {
                            restcost = 0;
                        }
                        roomFee.RestCost = restcost;
                        DateTime NewEndTime = DateTime.MinValue;
                        DateTime.TryParse(field.NewEndTime, out NewEndTime);
                        roomFee.NewEndTime = NewEndTime;
                        roomFee.DiscountID = field.DiscountID;
                        roomFee.ChongDiChargeID = WebUtil.GetIntValue(context, "ChongDiChargeID");
                        if (string.IsNullOrEmpty(roomFee.DefaultChargeManName))
                        {
                            if (roomFee.ContractID <= 0)
                            {
                                var default_relation = relation_list.FirstOrDefault(p => p.RoomID == roomFee.RoomID && p.IsChargeFee);
                                if (default_relation != null)
                                {
                                    roomFee.DefaultChargeManID = default_relation.ID;
                                    roomFee.DefaultChargeManName = default_relation.RelationName;
                                }
                            }
                            else
                            {
                                var contract = Foresight.DataAccess.Contract.GetContract(roomFee.ContractID, helper);
                                roomFee.DefaultChargeManID = 0;
                                roomFee.DefaultChargeManName = contract != null ? contract.RentName : string.Empty;
                            }
                        }
                        roomFee.Save(helper);
                        int HistoryID = TempRoomFeeHistory.InsertTempRoomFeeHistoryByTempFeeID(roomFee.TempID, AddMan, helper);
                        HistoryListID.Add(HistoryID);
                    }
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError("FeeCenterHandler", "visit: ChargeRoomFee", ex);
                    WebUtil.WriteJson(context, new { status = false });
                    return;
                }
            }
            WebUtil.WriteJson(context, new { status = true, HistoryListID = HistoryListID });
        }
        List<int> AllChildIDs = new List<int>();
        public void GetALLProjectChildIDs(int ID)
        {
            var project = Project.GetProject(ID);
            if (project == null)
            {
                return;
            }
            if (!project.isParent)
            {
                AllChildIDs.Add(project.ID);
                return;
            }
            var projectlist = Project.GetChildProjects(project.ID);
            foreach (var item in projectlist)
            {
                if (!item.isParent)
                {
                    AllChildIDs.Add(item.ID);
                    continue;
                }
                GetALLProjectChildIDs(item.ID);
            }
        }
        /// <summary>
        /// 启用收费标准
        /// </summary>
        /// <param name="context"></param>
        private void SaveRoomFee(HttpContext context)
        {
            string summaryids = context.Request.Params["summaryids"];
            List<int> SummaryIdList = JsonConvert.DeserializeObject<List<int>>(summaryids);
            string projectids = context.Request.Params["projectids"];
            List<int> ProjectIdList = JsonConvert.DeserializeObject<List<int>>(projectids);
            string roomids = context.Request.Params["roomids"];
            List<int> RoomIdList = JsonConvert.DeserializeObject<List<int>>(roomids);
            bool OwnerStatus = RoomFee.CheckRoomOwnerStatus(ProjectIdList, RoomIdList);
            if (!OwnerStatus)
            {
                WebUtil.WriteJson(context, new { status = false, error = "选择的资源没有业主信息" });
                return;
            }
            foreach (var ChargeID in SummaryIdList)
            {
                ViewChargeSummary summary = ViewChargeSummary.GetViewChargeSummaryByChargeID(ChargeID);
                if (summary == null)
                {
                    continue;
                }
                if (summary.FeeType == 5)
                {
                    List<DateTime> EndTimeList = Web.APPCode.CommHelper.GetContractEndTime(summary);
                    List<string> projectNames = new List<string>();
                    string cmdCommand = string.Empty;
                    for (int i = 0; i < EndTimeList.Count; i++)
                    {
                        string StartTimeStr = string.Empty;
                        string EndTimeStr = string.Empty;
                        if (i == 0)
                        {
                            StartTimeStr = summary.SummaryStartTime == DateTime.MinValue ? null : summary.SummaryStartTime.ToString("yyyy-MM-dd");
                        }
                        else
                        {
                            StartTimeStr = EndTimeList[(i - 1)].AddDays(1).ToString("yyyy-MM-dd");
                        }
                        EndTimeStr = EndTimeList[i].ToString("yyyy-MM-dd");
                        bool status = RoomFee.InsertRoomFee(ProjectIdList, RoomIdList, summary, StartTimeStr, EndTimeStr, IsCycleFee: 1);
                        if (!status)
                        {
                            WebUtil.WriteJson(context, new { status = false });
                            return;
                        }
                    }
                }
                else
                {
                    DateTime EndTime = Web.APPCode.CommHelper.GetEndTime(summary, summary.SummaryStartTime);
                    EndTime = EndTime > DateTime.Today ? EndTime : DateTime.Today;
                    if (summary.SummaryEndStartTime != DateTime.MinValue && EndTime > summary.SummaryEndStartTime)
                    {
                        EndTime = summary.SummaryEndStartTime;
                    }
                    string EndTimeStr = EndTime.ToString("yyyy-MM-dd");
                    bool status = RoomFee.InsertRoomFee(ProjectIdList, RoomIdList, summary, null, EndTimeStr, IsCycleFee: 1);
                    if (!status)
                    {
                        WebUtil.WriteJson(context, new { status = false });
                        return;
                    }
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        /// <summary>
        /// 启用合同费项
        /// </summary>
        /// <param name="context"></param>
        private void SaveContractRoomFee(HttpContext context)
        {
            int CompanyID = 0;
            int.TryParse(context.Request.Params["CompanyID"], out CompanyID);
            string feeids = context.Request.Params["feeids"];
            List<int> feeidList = JsonConvert.DeserializeObject<List<int>>(feeids);
            string RoomIDs = context.Request.Params["RoomIDs"];
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(RoomIDs);
            ProjectDetails[] projectList = new ProjectDetails[] { };
            ChargeFee chargeFee = ChargeFee.GetChargeFee(feeidList[0]);
            if (IDList.Count > 0)
            {
                projectList = ProjectDetails.GetRoomFeeByRoomIDList(IDList, chargeFee.ID);
            }
            else
            {
                int ProjectID = int.Parse(context.Request.Params["ProjectID"]);
                projectList = ProjectDetails.GetRoomFeeByChildRoomID(ProjectID, chargeFee.ID);
            }
            ViewChargeSummary summary = ViewChargeSummary.GetViewChargeSummaryByChargeID(chargeFee.ChargeID);
            List<DateTime> EndTimeList = Web.APPCode.CommHelper.GetContractEndTime(summary);
            List<string> projectNames = new List<string>();
            string cmdCommand = string.Empty;
            for (int i = 0; i < EndTimeList.Count; i++)
            {
                string StartTimeStr = string.Empty;
                string EndTimeStr = string.Empty;
                if (i == 0)
                {
                    StartTimeStr = chargeFee.StartTime.ToString("yyyy-MM-dd");
                }
                else
                {
                    StartTimeStr = EndTimeList[(i - 1)].AddDays(1).ToString("yyyy-MM-dd");
                }
                EndTimeStr = EndTimeList[i].ToString("yyyy-MM-dd");
                foreach (var projectdetails in projectList)
                {
                    //if (projectdetails.FeeID > 0)
                    //{
                    //    projectNames.Add(projectdetails.Name);
                    //    continue;
                    //}
                    cmdCommand += GetSaveContractRoomChargeFeeTxt(StartTimeStr, EndTimeStr, chargeFee, projectdetails, summary.Remark);
                }

            }
            if (!string.IsNullOrEmpty(cmdCommand))
            {
                using (SqlHelper helper = new SqlHelper())
                {
                    try
                    {
                        helper.BeginTransaction();
                        List<SqlParameter> parameters = new List<SqlParameter>();
                        helper.Execute(cmdCommand, CommandType.Text, parameters);
                        helper.Commit();
                    }
                    catch (Exception ex)
                    {
                        helper.Rollback();
                        LogHelper.WriteError("FeeCenterHandler", "visit: SaveContractRoomFee", ex);
                        context.Response.Write("{\"status\":false}");
                        return;
                    }
                }
            }
            if (projectNames.Count > 0)
            {
                context.Response.Write("{\"status\":true,\"errornames\":" + JsonConvert.SerializeObject(projectNames) + "}");
            }
            else
            {
                context.Response.Write("{\"status\":true,\"errornames\":[]}");
            }
        }
        private string GetSaveContractRoomChargeFeeTxt(string StartTime, string EndTime, ChargeFee chargeFee, ProjectDetails project, string Remark)
        {
            string sqltext = string.Empty;
            sqltext = @"INSERT INTO [dbo].[RoomFee]
           ([RoomID]
           ,[UseCount]
           ,[StartTime]
           ,[EndTime]
           ,[Cost]
           ,[Remark]
           ,[AddTime]
           ,[IsCharged]
           ,[ChargeFeeID]
           ,[ChargeID]
           ,[IsStart]
           ,ChargeFee)
     VALUES
           (" + project.ID + ",0,'" + StartTime + "','" + EndTime + "',0,'" + Remark + "',getdate(),0," + chargeFee.ID + "," + chargeFee.ChargeID + ",1,0);";
            return sqltext;
        }
        /// <summary>
        /// 加载收费项目和对应收费标准列表
        /// </summary>
        /// <param name="context"></param>
        private void LoadSetFeeList(HttpContext context)
        {
            int CompanyID = 0;
            int.TryParse(context.Request.Params["CompanyID"], out CompanyID);
            int ID = int.Parse(context.Request.Params["ID"]);
            int RoomID = 0;
            int.TryParse(context.Request.Params["RoomID"], out RoomID);
            int FeeType = 0;
            int.TryParse(context.Request.Params["FeeType"], out FeeType);
            List<int> FeeTypeList = new List<int>();
            ChargeSummary[] chargeSummaryList = ChargeSummary.GetChargeSummaryByID(FeeTypeList, ID, CompanyID, FeeType, false).ToArray();
            List<ChargeObj> chargeList = new List<ChargeObj>();
            foreach (var item in chargeSummaryList)
            {
                ChargeObj obj = new ChargeObj();
                obj.summary = item;
                ChargeFeeDetails[] chargeFeeList = ChargeFeeDetails.GetChargeFeeByChargeID(item.ID, RoomID);
                obj.list = chargeFeeList;
                chargeList.Add(obj);
            }
            string chargeSummaryStr = JsonConvert.SerializeObject(chargeList);
            string jsonstr = "{\"status\":true,\"ChargeList\":" + chargeSummaryStr + "}";
            context.Response.Write(jsonstr);
        }
        /// <summary>
        /// 加载账单明细
        /// </summary>
        /// <param name="context"></param>
        private void LoadRoomFeeList(HttpContext context)
        {
            try
            {
                int currentcount = 0;
                var dg = Web.APPCode.HandlerHelper.GetRoomFeeList(context, AccpetParam, out currentcount);
                bool canexport = WebUtil.GetBoolValue(context, "canexport");
                if (canexport)
                {
                    string downloadurl = string.Empty;
                    string error = string.Empty;
                    bool status = false;
                    string source = context.Request["source"];
                    source = string.IsNullOrEmpty(source) ? "" : source;
                    if (source.Equals("ToChargeAnalysisDetails"))
                    {
                        status = APPCode.ExportHelper.DownLoadToChargeAnalysisDetailData(dg, out downloadurl, out error);
                    }
                    else if (source.Equals("ToChargeAnalysisDetailsStatisc"))
                    {
                        status = APPCode.ExportHelper.DownLoadToChargeAnalysisDetailStaticsData(dg, out downloadurl, out error);
                    }
                    else if (source.Equals("ToCuiKuanList"))
                    {
                        status = APPCode.ExportHelper.DownLoadToCuiKuanListData(dg, out downloadurl, out error);
                    }
                    else if (source.Equals("ContractFeeSummaryAnalysis"))
                    {
                        status = APPCode.ExportHelper.DownLoadChargeFeeSummaryAnalysisData(dg, out downloadurl, out error);
                    }
                    WebUtil.WriteJson(context, new { status = status, downloadurl = downloadurl, error = error });
                    return;
                }
                var dic_dg = new Dictionary<string, object>();
                dic_dg["rows"] = dg.rows;
                dic_dg["page"] = dg.page;
                dic_dg["total"] = dg.total;
                if (dg.footer != null)
                {
                    dic_dg["footer"] = dg.footer;
                }
                dic_dg["currentcount"] = currentcount;
                WebUtil.WriteJson(context, dic_dg);
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("FeeCenterHandler", "visit: LoadRoomFeeList", ex);
                context.Response.Write("{\"rows\":[],\"total\":0,\"page\":0}");
            }
        }
        private decimal GetDecimalValue(HttpContext context, string param)
        {
            decimal value = 0;
            decimal.TryParse(context.Request.Params[param], out value);
            return value;
        }
        private int GetIntValue(HttpContext context, string param)
        {
            int value = 0;
            int.TryParse(context.Request.Params[param], out value);
            return value;
        }
        private DateTime GetDateValue(HttpContext context, string param)
        {
            DateTime value = DateTime.MinValue;
            DateTime.TryParse(context.Request.Params[param], out value);
            return value;
        }
        private PrintRoomFeeHistory SavePreChargeBackPrintRoomFeeHistory(HttpContext context, PrintRoomFeeHistory printRoomFeeHistory, int RoomID)
        {
            if (printRoomFeeHistory == null)
            {
                printRoomFeeHistory = new PrintRoomFeeHistory();
            }
            string AddMan = context.Request.Params["AddMan"];
            string PrintNumber = context.Request.Params["PrintNumber"];
            int ChargeID = WebUtil.GetIntValue(context, "ChargeID");
            string ChargeMan = context.Request.Params["ChargeMan"];
            DateTime ChargeTime = WebUtil.GetDateValue(context, "ChargeTime");
            string Remark = context.Request.Params["Remark"];
            decimal Cost = WebUtil.GetDecimalValue(context, "Cost");
            int ChargeMoneyType = WebUtil.GetIntValue(context, "ChargeMoneyType");
            string FullName = context.Request.Params["FullName"];
            string MoneyDaXie = context.Request.Params["MoneyDaXie"];
            int OrderNumberID = GetIntValue(context, "OrderNumberID");
            using (SqlHelper helper = new SqlHelper())
            {
                var nextPrintRoomFeeHistory = PrintRoomFeeHistory.GetPrintRoomFeeHistoryByPrintNumber(PrintNumber, printRoomFeeHistory.ID, helper);
                if (nextPrintRoomFeeHistory != null)
                {
                    PrintNumber = PrintRoomFeeHistory.GetLastestPrintNumber(OrderTypeNameDefine.chargefee.ToString(), RoomID, helper, out OrderNumberID);
                }
                var sys_ordernumber = Sys_OrderNumber.GetSys_OrderNumber(OrderNumberID, helper);
                printRoomFeeHistory.PrintNumber = PrintNumber;
                printRoomFeeHistory.OrderNumberID = sys_ordernumber != null ? sys_ordernumber.ID : 0;
                printRoomFeeHistory.OrderNumberType = sys_ordernumber != null ? sys_ordernumber.ChargeType : 1;
            }
            printRoomFeeHistory.Cost = Cost;
            printRoomFeeHistory.RealCost = Cost;
            printRoomFeeHistory.Remark = Remark;
            printRoomFeeHistory.AddMan = AddMan;
            printRoomFeeHistory.AddTime = DateTime.Now;
            printRoomFeeHistory.ChargeMan = ChargeMan;
            printRoomFeeHistory.ChargeTime = ChargeTime;
            printRoomFeeHistory.ChageType1 = ChargeMoneyType;
            printRoomFeeHistory.IsCancel = false;
            printRoomFeeHistory.FullName = FullName;
            printRoomFeeHistory.CostCapital = MoneyDaXie;
            printRoomFeeHistory.RoomFullName = context.Request.Params["RoomFullName"];
            printRoomFeeHistory.RoomOwnerName = context.Request.Params["RoomOwnerName"];
            return printRoomFeeHistory;
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
        public class ChargeObj
        {
            public ChargeSummary summary { get; set; }

            public ChargeFeeDetails[] list { get; set; }
        }
    }
}