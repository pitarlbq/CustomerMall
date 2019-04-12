
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Foresight.DataAccess;
using Foresight.DataAccess.Ui;
using Foresight.DataAccess.Framework;
using Utility;
using System.Data;
using System.Data.SqlClient;
using Web.Model;
using Web.APPCode;
using System.Web.SessionState;

namespace Web.Handler
{
    /// <summary>
    /// ImportFeeHandler 的摘要说明
    /// </summary>
    public class ImportFeeHandler : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string visit = context.Request.Params["visit"];
            if (string.IsNullOrEmpty(visit))
            {
                LogHelper.WriteDebug("ImportFeeHandler", "visit为空");
                context.Response.Write(null);
                return;
            }
            visit = visit.ToLower();
            try
            {
                switch (visit)
                {
                    case "loaddaishouimport":
                        loaddaishouimport(context);
                        break;
                    case "saveimportfee":
                        SaveImportFee(context);
                        break;
                    case "saveimportsetfee":
                        SaveImportSetFee(context);
                        break;
                    case "deleteimportfee":
                        DeleteImportSetFee(context);
                        break;
                    case "createimportfee":
                        createimportfee(context);
                        break;
                    case "activefee":
                        activefee(context);
                        break;
                    case "batchsavetime":
                        batchsavetime(context);
                        break;
                    case "batchsavecount":
                        batchsavecount(context);
                        break;
                    case "batchgongtantool":
                        batchgongtantool(context);
                        break;
                    case "batchsaveqichu":
                        batchsaveqichu(context);
                        break;
                    case "loadtaizhanggrid":
                        loadtaizhanggrid(context);
                        break;
                    case "saveprojectbiao":
                        saveprojectbiao(context);
                        break;
                    case "changeprojectbiaostatus":
                        changeprojectbiaostatus(context);
                        break;
                    case "deleteprojectbiao":
                        deleteprojectbiao(context);
                        break;
                    case "createimporttaizhangfee":
                        createimporttaizhangfee(context);
                        break;
                    case "connectprojectbiao":
                        connectprojectbiao(context);
                        break;
                    case "disconnectprojectbiao":
                        disconnectprojectbiao(context);
                        break;
                    case "savetaizhang":
                        savetaizhang(context);
                        break;
                    case "createnewimporttaizhangfee":
                        createnewimporttaizhangfee(context);
                        break;
                    case "batchsavetaizhangtime":
                        batchsavetaizhangtime(context);
                        break;
                    case "loadmetergrid":
                        loadmetergrid(context);
                        break;
                    case "deletemeterdata":
                        deletemeterdata(context);
                        break;
                    case "savemeterdata":
                        savemeterdata(context);
                        break;
                    case "doaddmeterdata":
                        doaddmeterdata(context);
                        break;
                    case "checkwritemeterstatus":
                        checkwritemeterstatus(context);
                        break;
                    case "dostartwritemeter":
                        dostartwritemeter(context);
                        break;
                    case "savemeterprojectpoint":
                        savemeterprojectpoint(context);
                        break;
                    case "dostopappwritemeter":
                        dostopappwritemeter(context);
                        break;
                    case "createmeterprojectfee":
                        createmeterprojectfee(context);
                        break;
                    case "loadmeterprojectfeegrid":
                        loadmeterprojectfeegrid(context);
                        break;
                    case "doremovemeterprojectfee":
                        doremovemeterprojectfee(context);
                        break;
                    case "loadmeterpointgrid":
                        loadmeterpointgrid(context);
                        break;
                    case "batchsavemeterfeetime":
                        batchsavemeterfeetime(context);
                        break;
                    default:
                        WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "Unkown Visit: " + visit);
                        break;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("ImportFeeHandler", "visit: " + visit, ex);
                context.Response.Write("{\"status\":false}");
            }
        }
        private void batchsavemeterfeetime(HttpContext context)
        {
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(context.Request.Params["ids"]);
            if (IDList.Count == 0)
            {
                WebUtil.WriteJson(context, new { status = false, error = "非法请求" });
                return;
            }
            var importfeelist = ChargeMeter_ProjectFee.GetChargeMeter_ProjectFeeListbyIDList(IDList.ToArray());
            string settext = string.Empty;
            string setfeetext = string.Empty;
            if (!string.IsNullOrEmpty(context.Request["UnitPrice"]))
            {
                decimal UnitPrice = WebUtil.GetDecimalValue(context, "UnitPrice");
                string UnitPriceStr = UnitPrice == decimal.MinValue ? "0" : "'" + UnitPrice.ToString() + "'";
                setfeetext += "[UnitPrice]=" + UnitPriceStr + ",";
            }
            if (!string.IsNullOrEmpty(context.Request["Coefficient"]))
            {
                decimal Coefficient = WebUtil.GetDecimalValue(context, "Coefficient");
                string CoefficientStr = Coefficient == decimal.MinValue ? "0" : "'" + Coefficient.ToString() + "'";
                setfeetext += "[RoomFeeCoefficient]=" + CoefficientStr + ",";
            }
            if (!string.IsNullOrEmpty(context.Request["WriteDate"]))
            {
                DateTime WriteDate = WebUtil.GetDateValue(context, "WriteDate");
                string WriteDateStr = WriteDate == DateTime.MinValue ? "NULL" : "'" + WriteDate.ToString("yyyy-MM-dd") + "'";
                settext += "[MeterWriteDate]=" + WriteDateStr + ",";
                setfeetext += "[RoomFeeWriteDate]=" + WriteDateStr + ",";
            }
            if (!string.IsNullOrEmpty(context.Request["StartTime"]))
            {
                DateTime StartTime = WebUtil.GetDateValue(context, "StartTime");
                string StartTimeStr = StartTime == DateTime.MinValue ? "NULL" : "'" + StartTime.ToString("yyyy-MM-dd") + "'";
                settext += "[MeterStartTime]=" + StartTimeStr + ",";
                setfeetext += "[StartTime]=" + StartTimeStr + ",";
            }
            if (!string.IsNullOrEmpty(context.Request["EndTime"]))
            {
                DateTime EndTime = WebUtil.GetDateValue(context, "EndTime");
                string EndTimeStr = EndTime == DateTime.MinValue ? "NULL" : "'" + EndTime.ToString("yyyy-MM-dd") + "'";
                settext += "[MeterEndTime]=" + EndTimeStr + ",";
                setfeetext += "[EndTime]=" + EndTimeStr + ",";
            }
            string cmdtext = string.Empty;
            if (!string.IsNullOrEmpty(settext))
            {
                settext = settext.Substring(0, settext.Length - 1);
                int[] idlist = importfeelist.Select(p => p.ID).ToArray();
                cmdtext += "update [ChargeMeter_ProjectFee] set " + settext + " where [ID] in (" + string.Join(",", idlist) + ");";
            }
            if (!string.IsNullOrEmpty(setfeetext))
            {
                setfeetext = setfeetext.Substring(0, setfeetext.Length - 1);
                cmdtext += "update [RoomFee] set " + setfeetext + " where [ChargeMeterProjectFeeID] in (" + string.Join(",", IDList) + ");";
            }
            if (string.IsNullOrEmpty(cmdtext))
            {
                WebUtil.WriteJson(context, new { status = false, error = "没有可修改的数据，请重新填写" });
                return;
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    helper.Execute(cmdtext, CommandType.Text, new List<SqlParameter>());
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError("ImportFeeHandler", "visit: batchsavetime ", ex);
                    WebUtil.WriteJson(context, new { status = false });
                    return;
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void loadmeterpointgrid(HttpContext context)
        {
            try
            {
                string keywords = context.Request.Params["keywords"];
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                int MeterCategoryID = WebUtil.GetIntValue(context, "MeterCategoryID");
                int MeterType = WebUtil.GetIntValue(context, "MeterType");
                int MeterChargeID = WebUtil.GetIntValue(context, "MeterChargeID");
                bool canexport = false;
                if (!string.IsNullOrEmpty(context.Request["canexport"]))
                {
                    bool.TryParse(context.Request["canexport"], out canexport);
                }
                List<int> MeterProjectIDList = new List<int>();
                if (!string.IsNullOrEmpty(context.Request["IDList"]))
                {
                    MeterProjectIDList = JsonConvert.DeserializeObject<List<int>>(context.Request["IDList"]);
                }
                DataGrid dg = ChargeMeter_Project_PointDetail.GetChargeMeter_Project_PointDetailGridByKeywords(keywords, MeterCategoryID, MeterType, MeterChargeID, "[SortOrder] asc,[DefaultOrder] asc,[AddTime] desc", startRowIndex, pageSize, MeterProjectIDList, UserID: WebUtil.GetUser(context).UserID, canexport: canexport);
                if (!canexport)
                {
                    WebUtil.WriteJson(context, dg);
                    return;
                }
                string downloadurl = string.Empty;
                string error = string.Empty;
                bool status = APPCode.ExportHelper.DownLoadMeterProjectPointData(dg, out downloadurl, out error);
                var list = dg.rows as ChargeMeter_ProjectDetail[];
                WebUtil.WriteJson(context, new { status = status, downloadurl = downloadurl, error = error });
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("ImportFeeHandler.ashx", "loadmeterpointgrid", ex);
                WebUtil.WriteJson(context, new DataGrid());
            }
        }
        private void doremovemeterprojectfee(HttpContext context)
        {
            string IDStr = context.Request["IDList"];
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(IDStr);
            if (IDList.Count == 0)
            {
                WebUtil.WriteJson(context, new { status = false, error = "请至少选择一条数据，操作取消" });
                return;
            }
            var count = ChargeMeter_ProjectFee.GetIsChargedMeter_ProjectFeeCountbyIDList(IDList.ToArray());
            if (count > 0)
            {
                WebUtil.WriteJson(context, new { status = false, error = "选中的账单已收费，操作取消" });
                return;
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    string cmdtext = "delete from [RoomFee] where ID in (select RoomFeeID from [ChargeMeter_ProjectFee] where ID in (" + string.Join(",", IDList.ToArray()) + "))";
                    helper.Execute(cmdtext, CommandType.Text, new List<SqlParameter>());
                    cmdtext = "update [ChargeMeter_ProjectFee] set [IsDeleted]=1 where ID in (" + string.Join(",", IDList.ToArray()) + ")";
                    helper.Execute(cmdtext, CommandType.Text, new List<SqlParameter>());
                    cmdtext = "update [ChargeMeter_Project] set [FeeStatus]=0 where ID in (select [MeterProjectID] from [ChargeMeter_ProjectFee] where ID in (" + string.Join(",", IDList.ToArray()) + "))";
                    helper.Execute(cmdtext, CommandType.Text, new List<SqlParameter>());
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError("ImportFeeHandler.ashx", "doremovemeterprojectfee", ex);
                    WebUtil.WriteJson(context, new { status = false });
                    return;
                }
            }
            #region 删除日志
            var user = WebUtil.GetUser(context);
            APPCode.CommHelper.SaveOperationLog(string.Join(",", IDList.ToArray()), Utility.EnumModel.OperationModule.ChargeMeter_ProjectFeeDelete.ToString(), "三表账单删除", user.UserID.ToString(), "ChargeMeter_ProjectFee", user.LoginName, IsHide: true);
            APPCode.CommHelper.SaveOperationLog("用户" + user.LoginName + "删除了三表账单", Utility.EnumModel.OperationModule.ChargeMeter_ProjectFeeDelete.ToString(), "三表账单删除", user.UserID.ToString(), "ChargeMeter_ProjectFee", user.LoginName);
            #endregion
            WebUtil.WriteJson(context, new { status = true });
        }
        private void loadmeterprojectfeegrid(HttpContext context)
        {
            try
            {
                string keywords = context.Request.Params["keywords"];
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                int MeterCategoryID = WebUtil.GetIntValue(context, "MeterCategoryID");
                int MeterType = WebUtil.GetIntValue(context, "MeterType");
                int MeterChargeID = WebUtil.GetIntValue(context, "MeterChargeID");
                string ProjectIDs = context.Request.Params["ProjectIDList"];
                string RoomIDs = context.Request.Params["RoomIDList"];
                List<int> RoomIDList = new List<int>();
                if (!string.IsNullOrEmpty(RoomIDs) && !RoomIDs.Equals("[]"))
                {
                    RoomIDList = JsonConvert.DeserializeObject<List<int>>(RoomIDs);
                }
                List<int> ProjectIDList = new List<int>();
                if (RoomIDList.Count == 0)
                {
                    if (!string.IsNullOrEmpty(ProjectIDs))
                    {
                        ProjectIDList = JsonConvert.DeserializeObject<List<int>>(ProjectIDs).Where(p => p != 1).ToList();
                    }
                    ProjectIDList = WebUtil.GetMyProjects(WebUtil.GetUser(context).UserID, ProjectIDList).Where(p => p.ID != 1).Select(p => p.ID).ToList();
                }
                int ChargeState = WebUtil.GetIntValue(context, "ChargeState");
                DataGrid dg = ChargeMeter_ProjectFeeDetail.GetChargeMeter_ProjectFeeDetailGridByKeywords(keywords, RoomIDList, ProjectIDList, MeterCategoryID, MeterType, MeterChargeID, "[SortOrder] asc,[DefaultOrder] asc,[AddTime] desc", startRowIndex, pageSize, UserID: WebUtil.GetUser(context).UserID, ChargeState: ChargeState);
                WebUtil.WriteJson(context, dg);
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("ImportFeeHandler.ashx", "loadmeterprojectfeegrid", ex);
                WebUtil.WriteJson(context, new DataGrid());
            }
        }
        private void createmeterprojectfee(HttpContext context)
        {
            string IDStr = context.Request.Params["IDList"];
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(IDStr);
            if (IDList.Count == 0)
            {
                WebUtil.WriteJson(context, new { status = false, error = "请至少选择一条数据，操作取消" });
                return;
            }
            DateTime WriteDate = WebUtil.GetDateValue(context, "WriteDate");
            decimal SummaryUnitPrice = WebUtil.GetDecimalValue(context, "SummaryUnitPrice");
            decimal Coefficient = WebUtil.GetDecimalValue(context, "Coefficient");
            DateTime StartTime = WebUtil.GetDateValue(context, "StartTime");
            DateTime EndTime = WebUtil.GetDateValue(context, "EndTime");
            string errormsg = string.Empty;
            string ChargeIDs = context.Request["ChargeIDs"];
            List<int> ChargeIDList = new List<int>();
            if (!string.IsNullOrEmpty(ChargeIDs))
            {
                ChargeIDList = JsonConvert.DeserializeObject<List<int>>(ChargeIDs);
            }
            if (ChargeIDList.Count == 0)
            {
                WebUtil.WriteJson(context, new { status = false, error = "请选择收费项目" });
                return;
            }
            var status = Foresight.DataAccess.ChargeMeter_ProjectFee.Save_ChargeMeter_ProjectFee(IDList.ToArray(), WriteDate, Coefficient, SummaryUnitPrice, StartTime, EndTime, WebUtil.GetUser(context).LoginName, out errormsg, ChargeIDList);
            WebUtil.WriteJson(context, new { status = status, error = errormsg });
        }
        private void dostopappwritemeter(HttpContext context)
        {
            string IDStr = context.Request["IDList"];
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(IDStr);
            if (IDList.Count == 0)
            {
                WebUtil.WriteJson(context, new { status = false, error = "请至少选择一条数据，操作取消" });
                return;
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    string cmdtext = "update [ChargeMeter_Project] set IsAPPWriteEnable=0 where ID in (" + string.Join(",", IDList.ToArray()) + ");";
                    helper.Execute(cmdtext, CommandType.Text, new List<SqlParameter>());
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError("ImportFeeHandler.ashx", "dostopappwritemeter", ex);
                    WebUtil.WriteJson(context, new { status = false });
                    return;
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void savemeterprojectpoint(HttpContext context)
        {
            var liststr = context.Request["list"];
            List<Dictionary<string, object>> List = new List<Dictionary<string, object>>();
            if (!string.IsNullOrEmpty(liststr))
            {
                List = Utility.JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(liststr);
            }
            if (List.Count == 0)
            {
                WebUtil.WriteJson(context, new { status = false, error = "请选择一条数据，操作取消" });
                return;
            }
            var user = WebUtil.GetUser(context);
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    foreach (var item in List)
                    {
                        int ID = WebUtil.GetIntByStr(item["ID"].ToString());
                        decimal StartPoint = WebUtil.GetDecimalByStr(item["StartPoint"].ToString());
                        decimal EndPoint = WebUtil.GetDecimalByStr(item["EndPoint"].ToString());
                        if (EndPoint < StartPoint)
                        {
                            WebUtil.WriteJson(context, new { status = false, error = "本次读数不能小于上次读数，操作取消" });
                            helper.Rollback();
                            return;
                        }
                        decimal TotalPoint = EndPoint - StartPoint;
                        var data = ChargeMeter_Project.GetChargeMeter_Project(ID, helper);
                        if (data != null)
                        {
                            data.MeterStartPoint = StartPoint;
                            data.MeterEndPoint = EndPoint;
                            data.MeterTotalPoint = TotalPoint;
                            data.WriteDate = DateTime.Now;
                            data.WriteUserName = user.FinalRealName;
                            data.WriteStatus = 1;
                            data.Save(helper);
                            ChargeMeter_Project_Point.Save_ChargeMeter_Project_Point(data, helper);
                        }
                    }
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError("ImportFeeHalder", "savemeterprojectpoint", ex);
                    WebUtil.WriteJson(context, new { status = false });
                    return;
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void dostartwritemeter(HttpContext context)
        {
            int type = WebUtil.GetIntValue(context, "type");
            string IDStr = context.Request.Params["IDList"];
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(IDStr);
            if (IDList.Count == 0)
            {
                WebUtil.WriteJson(context, new { status = false, error = "请至少选择一条数据，操作取消" });
                return;
            }

            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    string cmdtext = string.Empty;
                    if (type == 1)//启用APP抄表
                    {
                        cmdtext = "update [ChargeMeter_Project] set IsAPPWriteEnable=1 where ID in (" + string.Join(",", IDList.ToArray()) + ")";
                    }
                    else//开始抄表
                    {
                        cmdtext = "update [ChargeMeter_Project] set [WriteStatus]=0,[FeeStatus]=0 where ID in (" + string.Join(",", IDList.ToArray()) + ")";
                    }
                    helper.Execute(cmdtext, CommandType.Text, new List<SqlParameter>());
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError("ImportFeeHandler.ashx", "dostartwritemeter", ex);
                    WebUtil.WriteJson(context, new { status = false });
                    return;
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void checkwritemeterstatus(HttpContext context)
        {
            string IDStr = context.Request.Params["IDList"];
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(IDStr);
            if (IDList.Count == 0)
            {
                WebUtil.WriteJson(context, new { status = false, error = "请至少选择一条数据，操作取消" });
                return;
            }
            int total = ChargeMeter_Project.GetChargeMeter_ProjectCountbyIDList(IDList.ToArray());
            if (total > 0)
            {
                WebUtil.WriteJson(context, new { status = false, error = "当前抄表记录有未生成账单的用量，是否继续抄表" });
                return;
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void doaddmeterdata(HttpContext context)
        {
            int MeterType = WebUtil.GetIntValue(context, "MeterType");
            int[] RoomIDList = new int[] { };
            int[] ProjectIDList = new int[] { };
            string RoomIDs = context.Request["RoomIDList"];
            if (!string.IsNullOrEmpty(RoomIDs))
            {
                RoomIDList = JsonConvert.DeserializeObject<int[]>(RoomIDs);
            }
            string ProjectIDs = context.Request["ProjectIDList"];
            if (!string.IsNullOrEmpty(ProjectIDs))
            {
                ProjectIDList = JsonConvert.DeserializeObject<int[]>(ProjectIDs);
            }
            if (ProjectIDList.Length == 0 && RoomIDList.Length == 0 && MeterType == 1)
            {
                WebUtil.WriteJson(context, new { status = false, error = "请选择资源" });
                return;
            }
            if (ProjectIDList.Length == 0 && MeterType == 2)
            {
                WebUtil.WriteJson(context, new { status = false, error = "请选择资源" });
                return;
            }
            decimal MeterCoefficient = getDecimalValue(context, "tdMeterCoefficient");
            MeterCoefficient = MeterCoefficient > 0 ? MeterCoefficient : 1;
            var user = WebUtil.GetUser(context);
            ChargeMeter data = new ChargeMeter();
            data.AddTime = DateTime.Now;
            data.AddUserName = user.LoginName;
            data.MeterName = getValue(context, "tdMeterName");
            data.MeterNumber = getValue(context, "tdMeterNumber");
            data.MeterCategoryID = getIntValue(context, "tdMeterCategory");
            data.MeterType = getIntValue(context, "tdMeterType");
            data.MeterSpec = getIntValue(context, "tdMeterSpec");
            data.MeterCoefficient = MeterCoefficient;
            data.MeterRemark = getValue(context, "tdMeterRemark");
            data.MeterChargeID = getIntValue(context, "tdChargeSummary");
            data.MeterHouseNo = getValue(context, "tdMeterHouseNo");
            data.MeterLocation = getValue(context, "tdMeterLocation");
            data.SortOrder = getIntValue(context, "tdSortOrder");
            var project_list = new Project[] { };
            if (ProjectIDList.Length > 0 && RoomIDList.Length == 0 && MeterType == 1)
            {
                project_list = Project.GetProjectList(ProjectIDList.ToList(), RoomIDList.ToList());
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    data.Save(helper);
                    if (MeterType == 1)
                    {
                        foreach (var RoomID in RoomIDList)
                        {
                            var my_item = new ChargeMeter_Project();
                            my_item.AddTime = DateTime.Now;
                            my_item.AddUserName = user.LoginName;
                            my_item.ProjectID = RoomID;
                            my_item.MeterID = data.ID;
                            ChargeMeter_Project.Save_ChargeMeter_Project(my_item, data, helper);
                        }
                        foreach (var item in project_list)
                        {
                            var my_item = new ChargeMeter_Project();
                            my_item.AddTime = DateTime.Now;
                            my_item.AddUserName = user.LoginName;
                            my_item.ProjectID = item.ID;
                            my_item.MeterID = data.ID;
                            ChargeMeter_Project.Save_ChargeMeter_Project(my_item, data, helper);
                        }
                    }
                    else
                    {
                        foreach (var ProjectID in ProjectIDList)
                        {
                            var my_item = new ChargeMeter_Project();
                            my_item.AddTime = DateTime.Now;
                            my_item.AddUserName = user.LoginName;
                            my_item.ProjectID = ProjectID;
                            my_item.MeterID = data.ID;
                            ChargeMeter_Project.Save_ChargeMeter_Project(my_item, data, helper);
                        }
                    }
                    helper.Commit();
                }
                catch (Exception)
                {
                    helper.Rollback();
                    WebUtil.WriteJson(context, new { status = false });
                    return;
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void savemeterdata(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            var user = WebUtil.GetUser(context);
            ChargeMeter_Project data = null;
            if (ID > 0)
            {
                data = ChargeMeter_Project.GetChargeMeter_Project(ID);
            }
            if (data == null)
            {
                WebUtil.WriteJson(context, new { status = false, error = "数据不存在或已删除" });
                return;
            }
            data.MeterName = getValue(context, "tdMeterName");
            data.MeterNumber = getValue(context, "tdMeterNumber");
            data.MeterCategoryID = getIntValue(context, "tdMeterCategory");
            data.MeterType = getIntValue(context, "tdMeterType");
            data.MeterSpec = getIntValue(context, "tdMeterSpec");
            data.MeterCoefficient = getDecimalValue(context, "tdMeterCoefficient");
            data.MeterRemark = getValue(context, "tdMeterRemark");
            data.MeterHouseNo = getValue(context, "tdMeterHouseNo");
            data.MeterLocation = getValue(context, "tdMeterLocation");
            data.SortOrder = getIntValue(context, "tdSortOrder");
            data.Save();
            WebUtil.WriteJson(context, new { status = true });
        }
        private void deletemeterdata(HttpContext context)
        {
            string IDStr = context.Request.Params["IDList"];
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(IDStr);
            if (IDList.Count == 0)
            {
                WebUtil.WriteJson(context, new { status = false, error = "请至少选择一条数据，操作取消" });
                return;
            }
            int total = ChargeMeter_ProjectFee.GetChargeMeter_ProjectFeeCountbyMeterProjectIDList(IDList.ToArray());
            if (total > 0)
            {
                WebUtil.WriteJson(context, new { status = false, error = "选中的数据包含已生成的账单，禁止删除" });
                return;
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    string cmdtext = string.Empty;
                    foreach (var ID in IDList)
                    {
                        cmdtext += "delete from [ChargeMeter_Project] where [ID] in (" + string.Join(",", IDList.ToArray()) + ")";
                    }
                    helper.Execute(cmdtext, CommandType.Text, new List<SqlParameter>());
                    helper.Commit();
                    WebUtil.WriteJson(context, new { status = true });
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError("ImportFeeHandler", "visit: deletemeterdata", ex);
                    WebUtil.WriteJson(context, new { status = false });
                    return;
                }
            }
        }
        private void loadmetergrid(HttpContext context)
        {
            try
            {
                string keywords = context.Request.Params["keywords"];
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                int MeterCategoryID = WebUtil.GetIntValue(context, "MeterCategoryID");
                int MeterType = WebUtil.GetIntValue(context, "MeterType");
                int MeterChargeID = WebUtil.GetIntValue(context, "MeterChargeID");
                string ProjectIDs = context.Request.Params["ProjectIDList"];
                string RoomIDs = context.Request.Params["RoomIDList"];
                List<int> RoomIDList = new List<int>();
                if (!string.IsNullOrEmpty(RoomIDs) && !RoomIDs.Equals("[]"))
                {
                    RoomIDList = JsonConvert.DeserializeObject<List<int>>(RoomIDs);
                }
                List<int> ProjectIDList = new List<int>();
                if (RoomIDList.Count == 0)
                {
                    if (!string.IsNullOrEmpty(ProjectIDs))
                    {
                        ProjectIDList = JsonConvert.DeserializeObject<List<int>>(ProjectIDs).Where(p => p != 1).ToList();
                    }
                    ProjectIDList = WebUtil.GetMyProjects(WebUtil.GetUser(context).UserID, ProjectIDList).Where(p => p.ID != 1).Select(p => p.ID).ToList();
                }
                bool canexport = false;
                if (!string.IsNullOrEmpty(context.Request["canexport"]))
                {
                    bool.TryParse(context.Request["canexport"], out canexport);
                }
                bool IsWritePoint = WebUtil.GetBoolValue(context, "IsWritePoint");
                DataGrid dg = ChargeMeter_ProjectDetail.GetChargeMeter_ProjectDetailGridByKeywords(keywords, RoomIDList, ProjectIDList, MeterCategoryID, MeterType, MeterChargeID, "[SortOrder] asc,[DefaultOrder] asc,[AddTime] desc", startRowIndex, pageSize, UserID: WebUtil.GetUser(context).UserID, canexport: canexport, IsWritePoint: IsWritePoint);
                if (!canexport)
                {
                    WebUtil.WriteJson(context, dg);
                    return;
                }
                string downloadurl = string.Empty;
                string error = string.Empty;
                bool status = APPCode.ExportHelper.DownLoadMeterProjectData(dg, IsWritePoint, out downloadurl, out error);
                var list = dg.rows as ChargeMeter_ProjectDetail[];
                WebUtil.WriteJson(context, new { status = status, downloadurl = downloadurl, error = error });
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("ImportFeeHandler.ashx", "loadmetergrid", ex);
                WebUtil.WriteJson(context, new DataGrid());
            }
        }
        private void batchsavetaizhangtime(HttpContext context)
        {
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(context.Request.Params["ids"]);
            var list = Foresight.DataAccess.Project_Biao.GetProject_BiaoListByID(IDList);
            string settext = string.Empty;
            string setfeetext = string.Empty;
            if (!string.IsNullOrEmpty(context.Request.Params["WriteDate"]))
            {
                DateTime WriteDate = WebUtil.GetDateValue(context, "WriteDate");
                string WriteDateStr = WriteDate == DateTime.MinValue ? "NULL" : "'" + WriteDate.ToString("yyyy-MM-dd") + "'";
                settext += "[WriteDate]=" + WriteDateStr + ",";
            }
            decimal Rate = 1;
            if (!string.IsNullOrEmpty(context.Request.Params["Rate"]))
            {
                Rate = WebUtil.GetDecimalValue(context, "Rate");
            }
            settext += "[Rate]=" + Rate + ",";
            if (!string.IsNullOrEmpty(context.Request.Params["Coefficient"]))
            {
                decimal ImportCoefficient = WebUtil.GetDecimalValue(context, "Coefficient");
                settext += "[Coefficient]=" + ImportCoefficient + ",";
            }
            if (!string.IsNullOrEmpty(context.Request.Params["UnitPrice"]))
            {
                decimal UnitPrice = WebUtil.GetDecimalValue(context, "UnitPrice");
                settext += "[UnitPrice]=" + UnitPrice + ",";
            }
            if (string.IsNullOrEmpty(settext))
            {
                context.Response.Write("{\"status\":true,\"error\":true}");
                return;
            }
            settext = settext.Substring(0, settext.Length - 1);
            string cmdtext = string.Empty;
            int[] idlist = list.Select(p => p.ID).ToArray();
            cmdtext += "update [Project_Biao] set " + settext + " where [ID] in (" + string.Join(",", idlist) + ");";
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    helper.Execute(cmdtext, CommandType.Text, new List<SqlParameter>());
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError("ImportFeeHandler", "visit: batchsavetaizhangtime ", ex);
                    context.Response.Write("{\"status\":false}");
                    return;
                }
            }
            context.Response.Write("{\"status\":true}");
        }
        private void createnewimporttaizhangfee(HttpContext context)
        {
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(context.Request["IDList"]);
            DateTime StartTime = WebUtil.GetDateValue(context, "StartTime");
            DateTime EndTime = WebUtil.GetDateValue(context, "EndTime");
            var roomlist = ViewTaiZhang.GetViewTaiZhangListByIDs(IDList).Where(p => p.IsActive);
            var importList = ImportFee.GetImportFeeByProjectBiaoIDs(IDList);
            List<string> cmdlist = new List<string>();
            foreach (var project in roomlist)
            {
                DateTime WriteDate = project.WriteDate;
                decimal FinalUnitPrice = project.FinalUnitPrice;
                decimal FinalCoefficient = project.FinalCoefficient;
                decimal FinalStartPoint = project.FinalStartPoint;
                decimal FinalEndPoint = project.FinalEndPoint;
                decimal FinalTotalPoint = project.FinalTotalPoint;
                decimal FinalReducePoint = project.FinalReducePoint;
                DateTime FinalStartTime = StartTime > DateTime.MinValue ? StartTime : DateTime.MinValue;
                DateTime FinalEndTime = EndTime > DateTime.MinValue ? EndTime : DateTime.MinValue;
                decimal FinalTotalCost = FinalTotalPoint * FinalUnitPrice * FinalCoefficient;

                FinalTotalCost = FinalTotalCost > 0 ? FinalTotalCost : 0;

                string StartTimeStr = FinalStartTime > DateTime.MinValue ? "'" + FinalStartTime.ToString("yyyy-MM-dd") + "'" : "NULL";
                string EndTimeStr = FinalEndTime > DateTime.MinValue ? "'" + FinalEndTime.ToString("yyyy-MM-dd") + "'" : "NULL";
                string BiaoCategory = !string.IsNullOrEmpty(project.FinalBiaoCategory) ? "'" + project.FinalBiaoCategory + "'" : "NULL";
                string BiaoName = !string.IsNullOrEmpty(project.FinalBiaoName) ? "'" + project.FinalBiaoName + "'" : "NULL";
                int BiaoID = project.BiaoID > 0 ? project.BiaoID : 0;
                string BiaoGuiGe = !string.IsNullOrEmpty(project.BiaoGuiGe) ? "'" + project.BiaoGuiGe + "'" : "NULL";
                decimal ImportRate = project.Rate > 0 ? project.Rate : 0;
                string cmdtext = @"INSERT INTO [dbo].[ImportFee]
                   ([RoomID]           
                   ,[ChargeID]
                   ,[StartPoint]
                   ,[EndPoint]
                   ,[TotalPoint]
                   ,[UnitPrice]
                   ,[TotalPrice]
                   ,[WriteDate]
                   ,[StartTime]
                   ,[EndTime]
                   ,[AddTime]
                   ,[ChargeStatus]
                   ,[ImportCoefficient]
                   ,[ImportBiaoCategory]
                   ,[ImportBiaoName]
                   ,[ChargeBiaoID]
                   ,[ProjectBiaoID]
                   ,[ImportBiaoGuiGe]
                   ,[ImportRate]
                   ,[ImportReducePoint]
                   )
                    values
                   (" + project.ProjectID + "," + project.ChargeID + "," + FinalStartPoint + "," + FinalEndPoint + "," + FinalTotalPoint + "," + FinalUnitPrice + "," + FinalTotalCost + ",'" + WriteDate.ToString("yyyy-MM-dd") + "'," + StartTimeStr + "," + EndTimeStr + ",getdate(),2," + FinalCoefficient + "," + BiaoCategory + "," + BiaoName + "," + BiaoID + "," + project.ID + "," + BiaoGuiGe + "," + ImportRate + "," + FinalReducePoint + ");";
                cmdlist.Add(cmdtext);
            }
            if (cmdlist.Count > 0)
            {
                using (SqlHelper helper = new SqlHelper())
                {
                    try
                    {
                        helper.BeginTransaction();
                        foreach (var cmd in cmdlist)
                        {
                            helper.Execute(cmd, CommandType.Text, new List<SqlParameter>());
                        }
                        helper.Commit();
                        context.Response.Write("{\"status\":1}");
                        return;
                    }
                    catch (Exception ex)
                    {
                        LogHelper.WriteError("ImportFeeHandler", "visit: createnewimporttaizhangfee", ex);
                        helper.Rollback();
                        context.Response.Write("{\"status\":2}");
                        return;
                    }
                }
            }
            context.Response.Write("{\"status\":1}");
        }
        private void savetaizhang(HttpContext context)
        {
            string rows = context.Request["rows"];
            var list = JsonConvert.DeserializeObject<List<Utility.TaiZhangModel>>(rows);
            foreach (var item in list)
            {
                var projectBiao = Foresight.DataAccess.Project_Biao.GetProject_Biao(item.ID);
                if (projectBiao != null)
                {
                    projectBiao.BiaoName = item.FinalBiaoName;
                    projectBiao.Rate = item.Rate;
                    projectBiao.WriteDate = item.WriteDate;
                    projectBiao.StartPoint = item.FinalStartPoint;
                    projectBiao.EndPoint = item.FinalEndPoint;
                    projectBiao.EndPoint = projectBiao.EndPoint < projectBiao.StartPoint ? projectBiao.StartPoint : projectBiao.EndPoint;
                    projectBiao.Coefficient = item.FinalCoefficient;
                    projectBiao.ReducePoint = item.FinalReducePoint;
                    if (item.BiaoGuiGe != "总表")
                    {
                        projectBiao.TotalPoint = (projectBiao.EndPoint - projectBiao.StartPoint) * projectBiao.Rate - projectBiao.ReducePoint;
                        projectBiao.TotalPoint = projectBiao.TotalPoint > 0 ? projectBiao.TotalPoint : 0;
                    }
                    projectBiao.UnitPrice = item.FinalUnitPrice;
                    projectBiao.Save();
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void disconnectprojectbiao(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            string IDListStr = context.Request["IDList"];
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(IDListStr);
            List<string> cmdlist = new List<string>();
            foreach (var RelationID in IDList)
            {
                string cmdtext = "delete from [ProjectBiao_Relation] where [ProjectBiaoID]=" + ID + " and [ReationID]=" + RelationID + ";";
                cmdlist.Add(cmdtext);
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    foreach (var item in cmdlist)
                    {
                        helper.Execute(item, CommandType.Text, new List<SqlParameter>());
                    }
                    helper.Commit();
                    context.Response.Write("{\"status\":true}");
                }
                catch (Exception ex)
                {
                    LogHelper.WriteError("ImportFeeHandler", "dicconnectprojectbiao", ex);
                    helper.Rollback();
                    context.Response.Write("{\"status\":false}");
                }
            }
        }
        private void connectprojectbiao(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            string IDListStr = context.Request["IDList"];
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(IDListStr);
            foreach (var RelationID in IDList)
            {
                var relation = new Foresight.DataAccess.ProjectBiao_Relation();
                relation.ProjectBiaoID = ID;
                relation.ReationID = RelationID;
                relation.AddTime = DateTime.Now;
                relation.Save();
            }
            context.Response.Write("{\"status\":true}");
        }
        private void createimporttaizhangfee(HttpContext context)
        {
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(context.Request["IDList"]);
            var roomlist = ViewTaiZhang.GetViewTaiZhangListByIDs(IDList).Where(p => p.IsActive);
            DateTime WriteDate = WebUtil.GetDateValue(context, "WriteDate");
            decimal SummaryUnitPrice = WebUtil.GetDecimalValue(context, "SummaryUnitPrice");
            decimal Coefficient = WebUtil.GetDecimalValue(context, "Coefficient");
            decimal UseCount = WebUtil.GetDecimalValue(context, "UseCount");
            DateTime StartTime = WebUtil.GetDateValue(context, "StartTime");
            DateTime EndTime = WebUtil.GetDateValue(context, "EndTime");
            decimal TotalCost = WebUtil.GetDecimalValue(context, "TotalCost");
            var importList = ImportFee.GetImportFeeByProjectBiaoIDs(IDList);
            List<string> cmdlist = new List<string>();
            foreach (var project in roomlist)
            {
                var importfee = importList.FirstOrDefault(p => p.ProjectBiaoID == project.ID && p.WriteDate == WriteDate);
                if (importfee != null)
                {
                    continue;
                }
                decimal FinalUnitPrice = 0;
                decimal FinalCoefficient = 0;
                decimal FinalEndPoint = 0;
                decimal FinalTotalPoint = 0;
                DateTime FinalStartTime = DateTime.MinValue;
                DateTime FinalEndTime = DateTime.MinValue;
                decimal FinalTotalCost = 0;
                FinalUnitPrice = project.UnitPrice > 0 ? project.UnitPrice : (SummaryUnitPrice > 0 ? SummaryUnitPrice : (project.SummaryUnitPrice == decimal.MinValue ? 1 : project.SummaryUnitPrice));

                FinalCoefficient = Coefficient > 0 ? Coefficient : (project.Coefficient == decimal.MinValue ? 1 : project.Coefficient);

                if (UseCount > 0)
                {
                    FinalTotalPoint = UseCount;
                    FinalEndPoint = FinalTotalPoint + (project.StartPoint > 0 ? project.StartPoint : 0);
                }
                else
                {
                    FinalEndPoint = (project.EndPoint > 0 ? project.EndPoint : 0);
                    FinalTotalPoint = (project.EndPoint - project.StartPoint) * (project.Rate > 0 ? project.Rate : 0) - (project.ReducePoint > 0 ? project.ReducePoint : 0);
                }

                FinalEndPoint = (FinalEndPoint > 0 ? FinalEndPoint : 0);

                FinalTotalPoint = FinalTotalPoint > 0 ? FinalTotalPoint : 0;

                FinalStartTime = StartTime > DateTime.MinValue ? StartTime : DateTime.MinValue;

                FinalEndTime = EndTime > DateTime.MinValue ? EndTime : DateTime.MinValue;

                if (TotalCost > 0)
                {
                    FinalTotalCost = TotalCost;
                }
                else
                {
                    FinalTotalCost = FinalTotalPoint * FinalUnitPrice * FinalCoefficient;
                }
                FinalTotalCost = FinalTotalCost > 0 ? FinalTotalCost : 0;

                string StartTimeStr = FinalStartTime > DateTime.MinValue ? "'" + FinalStartTime.ToString("yyyy-MM-dd") + "'" : "NULL";
                string EndTimeStr = FinalEndTime > DateTime.MinValue ? "'" + FinalEndTime.ToString("yyyy-MM-dd") + "'" : "NULL";
                decimal FinalStartPoint = project.StartPoint > 0 ? project.StartPoint : 0;
                string BiaoCategory = !string.IsNullOrEmpty(project.BiaoCategory) ? "'" + project.BiaoCategory + "'" : "NULL";
                string BiaoName = !string.IsNullOrEmpty(project.BiaoName) ? "'" + project.BiaoName + "'" : "NULL";
                int BiaoID = project.BiaoID > 0 ? project.BiaoID : 0;
                string BiaoGuiGe = !string.IsNullOrEmpty(project.BiaoGuiGe) ? "'" + project.BiaoGuiGe + "'" : "NULL";
                decimal ImportRate = project.Rate > 0 ? project.Rate : 0;
                decimal ImportReducePoint = project.ReducePoint > 0 ? project.ReducePoint : 0;
                string cmdtext = @"INSERT INTO [dbo].[ImportFee]
                   ([RoomID]           
                   ,[ChargeID]
                   ,[StartPoint]
                   ,[EndPoint]
                   ,[TotalPoint]
                   ,[UnitPrice]
                   ,[TotalPrice]
                   ,[WriteDate]
                   ,[StartTime]
                   ,[EndTime]
                   ,[AddTime]
                   ,[ChargeStatus]
                   ,[ImportCoefficient]
                   ,[ImportBiaoCategory]
                   ,[ImportBiaoName]
                   ,[ChargeBiaoID]
                   ,[ProjectBiaoID]
                   ,[ImportBiaoGuiGe]
                   ,[ImportRate]
                   ,[ImportReducePoint]
                   )
                    values
                   (" + project.ProjectID + "," + project.ChargeID + "," + FinalStartPoint + "," + FinalEndPoint + "," + FinalTotalPoint + "," + FinalUnitPrice + "," + FinalTotalCost + ",'" + WriteDate.ToString("yyyy-MM-dd") + "'," + StartTimeStr + "," + EndTimeStr + ",getdate(),2," + FinalCoefficient + "," + BiaoCategory + "," + BiaoName + "," + BiaoID + "," + project.ID + "," + BiaoGuiGe + "," + ImportRate + "," + ImportReducePoint + ");";
                cmdlist.Add(cmdtext);
            }
            if (cmdlist.Count > 0)
            {
                using (SqlHelper helper = new SqlHelper())
                {
                    try
                    {
                        helper.BeginTransaction();
                        foreach (var cmd in cmdlist)
                        {
                            helper.Execute(cmd, CommandType.Text, new List<SqlParameter>());
                        }
                        helper.Commit();
                        context.Response.Write("{\"status\":1}");
                        return;
                    }
                    catch (Exception ex)
                    {
                        LogHelper.WriteError("ImportFeeHandler", "visit: createimporttaizhangfee", ex);
                        helper.Rollback();
                        context.Response.Write("{\"status\":2}");
                        return;
                    }
                }
            }
            context.Response.Write("{\"status\":1}");
        }
        private void deleteprojectbiao(HttpContext context)
        {
            string IDListStr = context.Request.Params["IDList"];
            var IDList = JsonConvert.DeserializeObject<List<int>>(IDListStr);
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    string cmdtext = string.Empty;
                    foreach (var ID in IDList)
                    {
                        cmdtext += "delete [Project_Biao] where [ID]=" + ID + ";";
                    }
                    helper.Execute(cmdtext, CommandType.Text, new List<SqlParameter>());
                    helper.Commit();
                    WebUtil.WriteJson(context, new { status = true });
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError("ImportFeeHandler", "visit: deleteprojectbiao", ex);
                    WebUtil.WriteJson(context, new { status = false });
                }
            }
        }
        private void changeprojectbiaostatus(HttpContext context)
        {
            string IDList = context.Request.Params["IDList"];
            var list = JsonConvert.DeserializeObject<List<Project_Biao>>(IDList);
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    string cmdtext = string.Empty;
                    foreach (var item in list)
                    {
                        cmdtext += "update [Project_Biao] set [IsActive]=" + (item.IsActive ? 1 : 0) + " where [ProjectID]=" + item.ProjectID + " and [BiaoID]=" + item.BiaoID + ";";
                    }
                    helper.Execute(cmdtext, CommandType.Text, new List<SqlParameter>());
                    helper.Commit();
                    WebUtil.WriteJson(context, new { status = true });
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError("ImportDaiShouHandler", "visit: changeprojectbiaostatus", ex);
                    WebUtil.WriteJson(context, new { status = false });
                }
            }
        }
        private void saveprojectbiao(HttpContext context)
        {
            int BiaoID = WebUtil.GetIntValue(context, "BiaoID");
            string ProjectIDs = context.Request.Params["ProjectIDs"];
            string RoomIDs = context.Request.Params["RoomIDs"];
            List<int> RoomIDList = new List<int>();
            if (!string.IsNullOrEmpty(RoomIDs) && !RoomIDs.Equals("[]"))
            {
                RoomIDList = JsonConvert.DeserializeObject<List<int>>(RoomIDs);
            }
            List<int> ProjectIDList = new List<int>();
            if (!string.IsNullOrEmpty(ProjectIDs) && !ProjectIDs.Equals("[]"))
            {
                ProjectIDList = JsonConvert.DeserializeObject<List<int>>(ProjectIDs);
            }
            if (ProjectIDList.Count == 0 && RoomIDList.Count == 0)
            {
                WebUtil.WriteJson(context, new { status = false, error = "请选择房间" });
                return;
            }
            string BiaoName = context.Request.Params["BiaoName"];
            string BiaoCategory = context.Request.Params["BiaoCategory"];
            string BiaoGuiGe = context.Request.Params["BiaoGuiGe"];
            decimal Rate = WebUtil.GetDecimalValue(context, "Rate");
            if (string.IsNullOrEmpty(context.Request["Rate"]))
            {
                Rate = 1;
            }
            string Remark = context.Request.Params["Remark"];
            var projectBiaoList = Project_Biao.GetProject_BiaoListByBiaoID(RoomIDList, ProjectIDList, 0, BiaoID, BiaoCategory, BiaoName, BiaoGuiGe, UserID: WebUtil.GetUser(context).UserID);
            var importfeeList = ViewImportFeeDetail2.GetViewImportFeeDetail2ListByBiaoID(RoomIDList, ProjectIDList, 0, null, BiaoID, BiaoCategory, BiaoName, BiaoGuiGe, UserID: WebUtil.GetUser(context).UserID);
            var list = Foresight.DataAccess.ViewRoomBasicDetails.GetRoomBasicDetailsListByBiaoID(RoomIDList, ProjectIDList, BiaoID, BiaoCategory, BiaoName, BiaoGuiGe);
            foreach (var item in list)
            {
                Project_Biao projectBiao = null;
                if (item.ProjectBiao_BiaoID > 0)
                {
                    projectBiao = Foresight.DataAccess.Project_Biao.GetProject_Biao(item.ProjectBiao_BiaoID);
                }
                if (projectBiao == null)
                {
                    projectBiao = projectBiaoList.FirstOrDefault(p => p.ProjectID == item.RoomID && p.BiaoID == BiaoID && p.BiaoCategory == BiaoCategory && p.BiaoName == BiaoName && p.BiaoGuiGe == BiaoGuiGe);
                }
                if (projectBiao == null)
                {
                    projectBiao = new Project_Biao();
                    projectBiao.ProjectID = item.RoomID;
                    projectBiao.BiaoID = BiaoID;
                    projectBiao.BiaoCategory = BiaoCategory;
                    projectBiao.BiaoName = BiaoName;
                    projectBiao.BiaoGuiGe = BiaoGuiGe;
                    projectBiao.IsActive = true;
                }
                projectBiao.ChargeRoomNo = context.Request["ChargeRoomNo"];
                var importfee = importfeeList.Where(p => p.RoomID == item.RoomID).OrderByDescending(p => p.WriteDate).FirstOrDefault();
                if (importfee != null)
                {
                    projectBiao.StartPoint = importfee.StartPoint > 0 ? importfee.StartPoint : 0;
                    projectBiao.EndPoint = importfee.EndPoint > 0 ? importfee.EndPoint : 0;
                    projectBiao.TotalPoint = importfee.FinalTotalPoint > 0 ? importfee.FinalTotalPoint : 0;
                    projectBiao.ReducePoint = importfee.FinalReducePoint > 0 ? importfee.FinalReducePoint : 0;
                    projectBiao.WriteDate = importfee.WriteDate > DateTime.MinValue ? importfee.WriteDate : DateTime.MinValue;
                }
                else
                {
                    projectBiao.StartPoint = 0;
                    projectBiao.EndPoint = 0;
                    projectBiao.TotalPoint = 0;
                    projectBiao.ReducePoint = 0;
                    projectBiao.WriteDate = DateTime.MinValue;
                }
                projectBiao.Rate = Rate;
                projectBiao.Remark = Remark;
                projectBiao.Save();
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void loadtaizhanggrid(HttpContext context)
        {
            try
            {
                string Keywords = context.Request.Params["Keywords"];
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                int BiaoID = WebUtil.GetIntValue(context, "BiaoCategory");
                int ActiveStatus = int.MinValue;
                if (!string.IsNullOrEmpty(context.Request.Params["ActiveStatus"]))
                {
                    ActiveStatus = WebUtil.GetIntValue(context, "ActiveStatus");
                }
                string ProjectIDs = context.Request.Params["ProjectIDList"];
                string RoomIDs = context.Request.Params["RoomIDList"];
                List<int> RoomIDList = new List<int>();
                if (!string.IsNullOrEmpty(RoomIDs) && !RoomIDs.Equals("[]"))
                {
                    RoomIDList = JsonConvert.DeserializeObject<List<int>>(RoomIDs);
                }
                List<int> ProjectIDList = new List<int>();
                if (!string.IsNullOrEmpty(ProjectIDs) && !ProjectIDs.Equals("[]"))
                {
                    ProjectIDList = JsonConvert.DeserializeObject<List<int>>(ProjectIDs);
                }
                int ID = WebUtil.GetIntValue(context, "ID");
                int RelationStatus = int.MinValue;
                if (!string.IsNullOrEmpty(context.Request.Params["RelationStatus"]))
                {
                    RelationStatus = WebUtil.GetIntValue(context, "RelationStatus");
                }
                bool canexport = WebUtil.GetBoolValue(context, "canexport");
                DataGrid dg = ViewTaiZhang.GetViewTaiZhangGridByKeywords(Keywords, RoomIDList, ProjectIDList, BiaoID, ActiveStatus, ID, RelationStatus, "order by [DefaultOrder] asc", startRowIndex, pageSize, UserID: WebUtil.GetUser(context).UserID, canexport: canexport);
                if (canexport)
                {
                    string downloadurl = string.Empty;
                    string error = string.Empty;
                    bool status = APPCode.ExportHelper.DownLoadTaiZhangData(dg, out downloadurl, out error);
                    WebUtil.WriteJson(context, new { status = status, downloadurl = downloadurl, error = error });
                    return;
                }
                string result = JsonConvert.SerializeObject(dg);
                context.Response.Write(result);
            }
            catch (Exception)
            {
                context.Response.Write("{\"rows\":[],\"total\":0,\"page\":0}");
            }
        }
        /// <summary>
        /// 期初收款
        /// </summary>
        /// <param name="context"></param>
        private void batchsaveqichu(HttpContext context)
        {
            string ChargeMan = context.Request.Params["ChargeMan"];
            DateTime ChargeTime = WebUtil.GetDateValue(context, "ChargeTime");
            string Remark = context.Request.Params["Remark"];
            string AddMan = context.Request.Params["AddMan"];
            string ChargeStatus = context.Request.Params["ChargeStatus"];
            int ChargeMoneyType = WebUtil.GetIntValue(context, "ChargeMoneyType");
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(context.Request.Params["ids"]);
            var importfeelist = Foresight.DataAccess.ViewImportFeeDetail2.GetViewImportFeeDetail2ListByID(IDList);
            if (ChargeStatus.Equals("canceled"))
            {
                foreach (var item in importfeelist)
                {
                    if (item.FinalChargeStatus != 1)
                    {
                        WebUtil.WriteJson(context, new { status = false, error = "选中的账单状态必须为已收" });
                        return;
                    }
                }
                string error = string.Empty;
                List<int> PrintIDList = importfeelist.Select(p => p.PrintID).ToList();
                var print_list = PrintRoomFeeHistory.GetPrintRoomFeeList(IDList: PrintIDList);
                var history_list = RoomFeeHistory.GetRoomFeeHistoryListByPrintIDList(PrintIDList);
                bool status = APPCode.HandlerHelper.CancelHistoryFeeProcess(HttpContext.Current, AddMan, history_list, print_list, out error);
                WebUtil.WriteJson(context, new { status = status, error = error });
                return;
            }
            else if (ChargeStatus.Equals("charged"))
            {
                foreach (var item in importfeelist)
                {
                    if (item.FinalChargeStatus != 0 && item.FinalChargeStatus != 2)
                    {
                        WebUtil.WriteJson(context, new { status = false, error = "选中的账单状态必须为草稿或者未收" });
                        return;
                    }
                }
                int[] idlist = importfeelist.Select(p => p.ID).ToArray();
                var cuishou_list = RoomFeeHistory.GetCuiShouRoomFeeHistoryListByImportFeeID(idlist);
                if (cuishou_list.Length > 0)
                {
                    WebUtil.WriteJson(context, new { status = false, error = "选中的账单催收中" });
                    return;
                }
                string cmdtext = "update [ImportFee] set [ChargeStatus]=1 where [ID] in (" + string.Join(",", idlist) + ");";
                using (SqlHelper helper = new SqlHelper())
                {
                    try
                    {
                        helper.BeginTransaction();
                        helper.Execute(cmdtext, CommandType.Text, new List<SqlParameter>());
                        SaveRoomHistoryFee(importfeelist, helper, ChargeMan, AddMan, ChargeTime, Remark, ChargeMoneyType);
                        helper.Commit();
                    }
                    catch (Exception ex)
                    {
                        helper.Rollback();
                        LogHelper.WriteError("ImportFeeHandler", "visit: batchsaveqichu ", ex);
                        WebUtil.WriteJson(context, new { status = false });
                        return;
                    }
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void batchgongtantool(HttpContext context)
        {
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(context.Request.Params["ids"]);
            var importfeelist = Foresight.DataAccess.ImportFeeDetails.GetImportFeeDetailsListByIDList(IDList);
            string Category = context.Request.Params["Category"];
            decimal Money = 0;
            decimal.TryParse(context.Request.Params["Money"], out Money);
            decimal Count = 0;
            decimal.TryParse(context.Request.Params["Count"], out Count);
            string GongTanType = context.Request.Params["GongTanType"];
            var sumlist = importfeelist.Select(p => p.ImportCoefficient);
            decimal SumConefficient = 0;
            foreach (var value in sumlist)
            {
                SumConefficient += (value <= 0 ? 1 : value);
            }
            string cmdtext = string.Empty;
            foreach (var importfee in importfeelist)
            {
                decimal ImportCoefficient = (importfee.ImportCoefficient <= 0 ? (importfee.ChargeSummaryCoefficient < 0 ? 0 : importfee.ChargeSummaryCoefficient) : importfee.ImportCoefficient);
                if (Category.Equals("1"))
                {
                    decimal TotalCost = (ImportCoefficient / SumConefficient) * Money;
                    cmdtext += "update [ImportFee] set [TotalPrice]=" + TotalCost + " where [ID]=" + importfee.ID + ";";
                    cmdtext += "update [RoomFee] set [Cost]=" + TotalCost + " where [ImportFeeID]=" + importfee.ID + ";";
                }
                else if (Category.Equals("2"))
                {
                    decimal TotalPoint = (ImportCoefficient / SumConefficient) * Count;
                    decimal UnitPrice = (importfee.UnitPrice <= 0 ? (importfee.SummaryUnitPrice < 0 ? 0 : importfee.SummaryUnitPrice) : importfee.UnitPrice);
                    decimal TotalCost = importfee.IsReading ? (UnitPrice * ImportCoefficient * TotalPoint) : (UnitPrice * ImportCoefficient);
                    cmdtext += "update [ImportFee] set [StartPoint]=0,[EndPoint]=0, [TotalPoint]=" + TotalPoint + ",[TotalPrice]=" + TotalCost + " where [ID]=" + importfee.ID + ";";
                    cmdtext += "update [RoomFee] set [UseCount]=" + TotalPoint + ",[Cost]=" + TotalCost + " where [ImportFeeID]=" + importfee.ID + ";";
                }
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    helper.Execute(cmdtext, CommandType.Text, new List<SqlParameter>());
                    helper.Commit();
                    context.Response.Write("{\"status\":true}");
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError("ImportFeeHandler", "visit: batchgongtantool ", ex);
                    context.Response.Write("{\"status\":false}");
                }
            }
        }
        private void batchsavecount(HttpContext context)
        {
            List<ImportPoint> list = JsonConvert.DeserializeObject<List<ImportPoint>>(context.Request.Params["list"]);
            if (list.Count == 0)
            {
                WebUtil.WriteJson(context, new { status = false, error = "非法请求" });
                return;
            }
            var importfeelist = Foresight.DataAccess.ImportFee.GetImportFeeListByIDList(list.Select(p => p.ID).ToList());
            string cmdtext = string.Empty;
            foreach (var importfee in importfeelist)
            {
                foreach (var item in list)
                {
                    if (importfee.ID == item.ID)
                    {
                        importfee.StartPoint = item.StartPoint == decimal.MinValue ? 0 : item.StartPoint;
                        importfee.EndPoint = item.EndPoint == decimal.MinValue ? 0 : item.EndPoint;
                        importfee.TotalPoint = importfee.EndPoint - importfee.StartPoint;
                        cmdtext += "update [RoomFee] set [UseCount]=" + importfee.TotalPoint + " where [ImportFeeID]=" + importfee.ID + ";";
                        cmdtext += "update [ImportFee] set [StartPoint]=" + importfee.StartPoint + ",[EndPoint]=" + importfee.EndPoint + ",TotalPoint=" + importfee.TotalPoint + " where [ID]=" + importfee.ID + ";";
                    }
                }
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    helper.Execute(cmdtext, CommandType.Text, new List<SqlParameter>());
                    helper.Commit();
                    context.Response.Write("{\"status\":true}");
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError("ImportFeeHandler", "visit: batchsavecount ", ex);
                    context.Response.Write("{\"status\":false}");
                }
            }
        }
        private void batchsavetime(HttpContext context)
        {
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(context.Request.Params["ids"]);
            if (IDList.Count == 0)
            {
                WebUtil.WriteJson(context, new { status = false, error = "非法请求" });
                return;
            }
            var importfeelist = Foresight.DataAccess.ViewImportFeeDetail2.GetViewImportFeeDetail2ListByID(IDList);
            string settext = string.Empty;
            string setfeetext = string.Empty;
            decimal TotalPoint = decimal.MinValue;
            if (!string.IsNullOrEmpty(context.Request.Params["UseCount"]))
            {
                TotalPoint = WebUtil.GetDecimalValue(context, "UseCount");
                settext += "[TotalPoint]=" + TotalPoint + ",";
                settext += "[EndPoint]=0,";
                setfeetext += "[UseCount]=" + TotalPoint + ",";
            }
            decimal UnitPrice = decimal.MinValue;
            if (!string.IsNullOrEmpty(context.Request.Params["UnitPrice"]))
            {
                UnitPrice = WebUtil.GetDecimalValue(context, "UnitPrice");
                settext += "[UnitPrice]=" + UnitPrice + ",";
                setfeetext += "[UnitPrice]=" + UnitPrice + ",";
            }
            decimal ImportCoefficient = decimal.MinValue;
            if (!string.IsNullOrEmpty(context.Request.Params["Coefficient"]))
            {
                ImportCoefficient = WebUtil.GetDecimalValue(context, "Coefficient");
                settext += "[ImportCoefficient]=" + ImportCoefficient + ",";
            }
            decimal TotalPrice = decimal.MinValue;
            if (!string.IsNullOrEmpty(context.Request.Params["TotalPrice"]))
            {
                TotalPrice = WebUtil.GetDecimalValue(context, "TotalPrice");
                settext += "[TotalPrice]=" + TotalPrice + ",";
            }
            decimal Rate = decimal.MinValue;
            if (!string.IsNullOrEmpty(context.Request.Params["Rate"]))
            {
                Rate = WebUtil.GetDecimalValue(context, "Rate");
                settext += "[ImportRate]=" + Rate + ",";
            }
            decimal ReducePoint = decimal.MinValue;
            if (!string.IsNullOrEmpty(context.Request.Params["ReducePoint"]))
            {
                ReducePoint = WebUtil.GetDecimalValue(context, "ReducePoint");
                settext += "[ImportReducePoint]=" + ReducePoint + ",";
            }
            int ChargeStatus = int.MinValue;
            if (!string.IsNullOrEmpty(context.Request.Params["FeeStatus"]))
            {
                ChargeStatus = WebUtil.GetIntValue(context, "FeeStatus");
                if (ChargeStatus == 1)
                {
                    settext += "[ChargeStatus]=" + ChargeStatus + ",";
                }
            }
            if (!string.IsNullOrEmpty(context.Request.Params["WriteDate"]))
            {
                DateTime WriteDate = WebUtil.GetDateValue(context, "WriteDate");
                string WriteDateStr = WriteDate == DateTime.MinValue ? "NULL" : "'" + WriteDate.ToString("yyyy-MM-dd") + "'";
                settext += "[WriteDate]=" + WriteDateStr + ",";
            }
            if (!string.IsNullOrEmpty(context.Request.Params["StartTime"]))
            {
                DateTime StartTime = WebUtil.GetDateValue(context, "StartTime");
                string StartTimeStr = StartTime == DateTime.MinValue ? "NULL" : "'" + StartTime.ToString("yyyy-MM-dd") + "'";
                settext += "[StartTime]=" + StartTimeStr + ",";
                setfeetext += "[StartTime]=" + StartTimeStr + ",";
            }
            if (!string.IsNullOrEmpty(context.Request.Params["EndTime"]))
            {
                DateTime EndTime = WebUtil.GetDateValue(context, "EndTime");
                string EndTimeStr = EndTime == DateTime.MinValue ? "NULL" : "'" + EndTime.ToString("yyyy-MM-dd") + "'";
                settext += "[EndTime]=" + EndTimeStr + ",";
                setfeetext += "[EndTime]=" + EndTimeStr + ",";
            }
            if (string.IsNullOrEmpty(settext))
            {
                context.Response.Write("{\"status\":true,\"error\":true}");
                return;
            }
            settext = settext.Substring(0, settext.Length - 1);
            string cmdtext = string.Empty;
            int[] idlist = importfeelist.Select(p => p.ID).ToArray();
            cmdtext += "update [ImportFee] set " + settext + " where [ID] in (" + string.Join(",", idlist) + ");";
            if (!string.IsNullOrEmpty(setfeetext))
            {
                setfeetext = setfeetext.Substring(0, setfeetext.Length - 1);
                cmdtext += "update [RoomFee] set " + setfeetext + " where [ImportFeeID] in (" + string.Join(",", idlist) + ");";
            }
            var ALLPriceRangeList = ChargePriceRange.GetChargePriceRangeList();
            foreach (var importfee in importfeelist)
            {
                var PriceRangeList = ALLPriceRangeList.Where(p => p.SummaryID == importfee.ChargeID).ToArray();

                decimal FinalImportCoefficient = ImportCoefficient > decimal.MinValue ? ImportCoefficient : (importfee.ImportCoefficient > decimal.MinValue ? importfee.ImportCoefficient : importfee.Coefficient);
                decimal calculateTotalPoint = importfee.EndPoint - importfee.StartPoint;
                decimal FinalTotalPoint = TotalPoint > decimal.MinValue ? TotalPoint : (calculateTotalPoint > 0 ? calculateTotalPoint : importfee.TotalPoint);
                decimal FinalUnitPrice = decimal.MinValue;
                if (PriceRangeList.Length > 0)
                {
                    CommHelper.GetPriceRangeInfo(PriceRangeList, importfee.TotalUseCount, FinalTotalPoint, FinalImportCoefficient, out FinalUnitPrice, out TotalPrice);
                }
                else
                {
                    FinalUnitPrice = UnitPrice > decimal.MinValue ? UnitPrice : (importfee.UnitPrice > decimal.MinValue ? importfee.UnitPrice : importfee.SummaryUnitPrice);
                    if (importfee.IsReading)
                    {
                        if (FinalTotalPoint > 0 && FinalUnitPrice > 0 && FinalImportCoefficient > 0)
                        {
                            TotalPrice = FinalTotalPoint * FinalUnitPrice * FinalImportCoefficient;
                        }
                        else
                        {
                            TotalPrice = 0;
                        }
                    }
                    else
                    {
                        if (FinalTotalPoint > 0 && FinalUnitPrice > 0 && FinalImportCoefficient > 0)
                        {
                            TotalPrice = FinalTotalPoint * FinalUnitPrice * FinalImportCoefficient;
                        }
                        else
                        {
                            TotalPrice = 0;
                        }
                    }
                }
                cmdtext += "update [ImportFee] set [UnitPrice]=" + FinalUnitPrice + ",[ImportCoefficient]=" + FinalImportCoefficient + ",[TotalPoint]=" + FinalTotalPoint + " where [ID]=" + importfee.ID + ";";
                if (importfee.IsReading && FinalTotalPoint > 0)
                {
                    cmdtext += "update [ImportFee] set [EndPoint]=" + FinalTotalPoint + "+isnull([StartPoint],0) where [ID]=" + importfee.ID + ";";
                }
                if (TotalPrice > decimal.MinValue)
                {
                    cmdtext += "update [ImportFee] set [TotalPrice]=" + TotalPrice + " where [ID]=" + importfee.ID + ";";
                    cmdtext += "update [RoomFee] set [Cost]=" + TotalPrice + " where [ImportFeeID]=" + importfee.ID + ";";
                }
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    helper.Execute(cmdtext, CommandType.Text, new List<SqlParameter>());
                    helper.Commit();
                    //context.Response.Write("{\"status\":true}");
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError("ImportFeeHandler", "visit: batchsavetime ", ex);
                    context.Response.Write("{\"status\":false}");
                    return;
                }
            }
            if (ChargeStatus == 1)
            {
                importfeelist = Foresight.DataAccess.ViewImportFeeDetail2.GetViewImportFeeDetail2ListByID(IDList);
                using (SqlHelper helper = new SqlHelper())
                {
                    try
                    {
                        helper.BeginTransaction();
                        SaveRoomHistoryFee(importfeelist, helper, context.Request.Params["AddMan"]);
                        helper.Commit();
                        context.Response.Write("{\"status\":true}");
                    }
                    catch (Exception ex)
                    {
                        helper.Rollback();
                        LogHelper.WriteError("ImportFeeHandler", "visit: batchsavetime ", ex);
                        context.Response.Write("{\"status\":false}");
                    }
                }
                return;
            }
            context.Response.Write("{\"status\":true}");
        }
        private void activefee(HttpContext context)
        {
            string IDStr = context.Request.Params["IDList"];
            List<int> IDList = new List<int>();
            if (!string.IsNullOrEmpty(IDStr))
            {
                IDList = JsonConvert.DeserializeObject<List<int>>(IDStr);
            }
            if (IDList.Count == 0)
            {
                WebUtil.WriteJson(context, new { status = false, error = "请选择账单，操作取消" });
                return;
            }
            var list = ViewImportFeeDetail2.GetViewImportFeeDetail2ListByID(IDList);
            List<int> NewIDList = new List<int>();
            string cmdtext = RoomFee.GetActiveImportFeeCmdText(list);
            if (string.IsNullOrEmpty(cmdtext))
            {
                var item = new { status = true, msg = "所选账单金额全部为0" };
                context.Response.Write(JsonConvert.SerializeObject(item));
                return;
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    helper.Execute(cmdtext, CommandType.Text, new List<SqlParameter>());
                    var my_list = list.Where(p => p.IsPriceRange).ToArray();
                    if (my_list.Length > 0)
                    {
                        var ImportFeeIDList = my_list.Select(p => p.ID).Distinct().ToList();
                        ChargeFeePriceRange.CreateChargeFeePriceRangeByImportFeeIDList(helper, ImportFeeIDList: ImportFeeIDList);
                    }
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError("ImportFeeHandler", "visit: activefee", ex);
                    WebUtil.WriteJson(context, new { status = false });
                    return;
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void createimportfee(HttpContext context)
        {
            int ChargeID = WebUtil.GetIntValue(context, "ChargeID");
            DateTime WriteDate = WebUtil.GetDateValue(context, "WriteDate");
            string projectIds = context.Request.Params["projectids"];
            string roomids = context.Request.Params["roomids"];
            List<int> RoomIDList = JsonConvert.DeserializeObject<List<int>>(roomids);
            List<int> ProjectIDList = JsonConvert.DeserializeObject<List<int>>(projectIds);
            var roomlist = ViewRoomBasicDetails.GetRoomBasicDetailsListByKeywords(RoomIDList, ProjectIDList, WriteDate.ToString("yyyy-MM-dd"), ChargeID);
            var projectBiaoList = Project_Biao.GetProject_BiaoListByBiaoID(RoomIDList, ProjectIDList, ChargeID, UserID: WebUtil.GetUser(context).UserID);
            var importfeeList = ViewImportFeeDetail2.GetViewImportFeeDetail2ListByBiaoID(RoomIDList, ProjectIDList, ChargeID, WriteDate, UserID: WebUtil.GetUser(context).UserID);
            var viewChargeSummary = Foresight.DataAccess.ViewChargeSummary.GetViewChargeSummaryByChargeID(ChargeID);
            if (viewChargeSummary == null)
            {
                WebUtil.WriteJson(context, new { status = 3 });
                return;
            }
            string cmdtext = string.Empty;
            decimal SummaryUnitPrice = 0;
            if (!viewChargeSummary.StartPriceRange)
            {
                SummaryUnitPrice = WebUtil.GetDecimalValue(context, "SummaryUnitPrice");
            }
            decimal Coefficient = WebUtil.GetDecimalValue(context, "Coefficient");
            decimal UseCount = WebUtil.GetDecimalValue(context, "UseCount");
            decimal TotalCost = WebUtil.GetDecimalValue(context, "TotalCost");
            DateTime StartTime = WebUtil.GetDateValue(context, "StartTime");
            DateTime EndTime = WebUtil.GetDateValue(context, "EndTime");
            var PriceRangeList = ChargePriceRange.GetChargePriceRangeListBySummaryID(ChargeID);
            List<string> cmdlist = new List<string>();
            foreach (var project in roomlist)
            {
                decimal ImportCoefficient = decimal.MinValue;
                if (Coefficient > 0)
                {
                    ImportCoefficient = Coefficient;
                }
                else
                {
                    ImportCoefficient = project.LastCoefficient == decimal.MinValue ? 1 : project.LastCoefficient;
                }
                decimal StartPoint = 0;
                decimal TotalPoint = UseCount == decimal.MinValue ? 0 : UseCount;
                decimal EndPoint = 0;
                decimal UnitPrice = decimal.MinValue;
                decimal FinalTotalCost = 0;
                if (PriceRangeList.Length > 0 && viewChargeSummary.StartPriceRange)
                {
                    CommHelper.GetPriceRangeInfo(PriceRangeList, project.TotalUseCount, TotalPoint, ImportCoefficient, out UnitPrice, out FinalTotalCost);
                }
                else
                {
                    if (SummaryUnitPrice > 0)
                    {
                        UnitPrice = SummaryUnitPrice;
                    }
                    else
                    {
                        UnitPrice = project.LastUnitPrice == decimal.MinValue ? 1 : project.LastUnitPrice;
                    }
                    if (viewChargeSummary.IsReading)
                    {
                        FinalTotalCost = TotalPoint * UnitPrice * (ImportCoefficient > 0 ? ImportCoefficient : 1);
                    }
                    else
                    {
                        FinalTotalCost = TotalPoint * UnitPrice * ImportCoefficient;
                    }
                }

                FinalTotalCost = FinalTotalCost == 0 ? TotalCost : FinalTotalCost;
                if (viewChargeSummary.IsReading)
                {
                    StartPoint = project.LastEndPoint == decimal.MinValue ? 0 : project.LastEndPoint;
                    EndPoint = StartPoint + TotalPoint;
                }
                string StartTimeStr = StartTime == DateTime.MinValue ? (project.LastEndTime == DateTime.MinValue ? "NULL" : "'" + project.LastEndTime.ToString("yyyy-MM-dd") + "'") : "'" + StartTime.ToString("yyyy-MM-dd") + "'";
                DateTime NewEndTime = GetEndTime(viewChargeSummary, project.LastEndTime);
                string EndTimeStr = EndTime == DateTime.MinValue ? (NewEndTime == DateTime.MinValue ? "NULL" : "'" + NewEndTime.ToString("yyyy-MM-dd") + "'") : "'" + EndTime.ToString("yyyy-MM-dd") + "'";
                string ImportBiaoName = string.IsNullOrEmpty(project.Name) ? "NULL" : "'" + project.Name + "'";
                var biaoList = projectBiaoList.Where(p => p.ProjectID == project.RoomID && p.ID == project.ProjectBiao_ID).ToArray();
                if (biaoList.Length == 0 && !viewChargeSummary.DisableDefaultImportFee)
                {
                    cmdtext = @"INSERT INTO [dbo].[ImportFee]
                   ([RoomID]           
                   ,[ChargeID]
                   ,[StartPoint]
                   ,[EndPoint]
                   ,[TotalPoint]
                   ,[UnitPrice]
                   ,[TotalPrice]
                   ,[WriteDate]
                   ,[StartTime]
                   ,[EndTime]
                   ,[AddTime]
                   ,[ChargeStatus]
                   ,[ImportCoefficient]
                   ,[ImportBiaoCategory]
                   ,[ImportBiaoName]
                   ,[ChargeBiaoID],[ProjectBiaoID])
                    values
                   (" + project.RoomID + "," + ChargeID + "," + StartPoint + "," + EndPoint + "," + TotalPoint + "," + UnitPrice + "," + FinalTotalCost + ",'" + WriteDate.ToString("yyyy-MM-dd") + "'," + StartTimeStr + "," + EndTimeStr + ",getdate(),2," + ImportCoefficient + ",NULL," + ImportBiaoName + ",0,0);";
                    cmdlist.Add(cmdtext);
                }
                else if (biaoList.Length > 0)
                {
                    foreach (var projectbiao in biaoList)
                    {
                        var last_import_fee = importfeeList.Where(p => p.ChargeBiaoID == projectbiao.BiaoID && p.ImportBiaoCategory == projectbiao.BiaoCategory && p.ImportBiaoName == projectbiao.BiaoName && p.ImportBiaoGuiGe == projectbiao.BiaoGuiGe && p.RoomID == projectbiao.ProjectID).FirstOrDefault();

                        StartPoint = last_import_fee != null ? (last_import_fee.EndPoint > 0 ? last_import_fee.EndPoint : 0) : StartPoint;
                        decimal reduce_point = projectbiao.ReducePoint > 0 ? projectbiao.ReducePoint : 0;
                        EndPoint = StartPoint + TotalPoint;
                        decimal biao_rate = projectbiao.Rate > 0 ? projectbiao.Rate : 0;
                        if (Coefficient > 0)
                        {
                            ImportCoefficient = Coefficient;
                        }
                        else
                        {
                            ImportCoefficient = projectbiao.Coefficient <= 0 ? 1 : projectbiao.Coefficient;
                        }
                        FinalTotalCost = TotalPoint * UnitPrice * (ImportCoefficient > 0 ? ImportCoefficient : 1);
                        string ImportBiaoCategory = string.IsNullOrEmpty(projectbiao.BiaoCategory) ? "NULL" : "'" + projectbiao.BiaoCategory + "'";
                        string ImportBiaoGuiGe = string.IsNullOrEmpty(projectbiao.BiaoGuiGe) ? "NULL" : "'" + projectbiao.BiaoGuiGe + "'";
                        ImportBiaoName = string.IsNullOrEmpty(projectbiao.BiaoName) ? (string.IsNullOrEmpty(project.Name) ? "NULL" : "'" + project.Name + "'") : "'" + projectbiao.BiaoName + "'";
                        int ChargeBiaoID = projectbiao.BiaoID > 0 ? projectbiao.BiaoID : 0;
                        string ImportChargeRoomNo = string.IsNullOrEmpty(projectbiao.ChargeRoomNo) ? "NULL" : "'" + projectbiao.ChargeRoomNo + "'";
                        cmdtext = @"INSERT INTO [dbo].[ImportFee]
                       ([RoomID]           
                       ,[ChargeID]
                       ,[StartPoint]
                       ,[EndPoint]
                       ,[TotalPoint]
                       ,[UnitPrice]
                       ,[TotalPrice]
                       ,[WriteDate]
                       ,[StartTime]
                       ,[EndTime]
                       ,[AddTime]
                       ,[ChargeStatus]
                       ,[ImportCoefficient]
                       ,[ImportBiaoCategory]
                       ,[ImportBiaoName]
                       ,[ChargeBiaoID],[ProjectBiaoID],[ImportBiaoGuiGe],[ImportRate],[ImportReducePoint],[ImportChargeRoomNo])
                        values
                       (" + project.RoomID + "," + ChargeID + "," + StartPoint + "," + EndPoint + "," + TotalPoint + "," + UnitPrice + "," + FinalTotalCost + ",'" + WriteDate.ToString("yyyy-MM-dd") + "'," + StartTimeStr + "," + EndTimeStr + ",getdate(),2," + ImportCoefficient + "," + ImportBiaoCategory + "," + ImportBiaoName + "," + ChargeBiaoID + "," + projectbiao.ID + "," + ImportBiaoGuiGe + "," + biao_rate + "," + reduce_point + "," + ImportChargeRoomNo + ");";
                        cmdlist.Add(cmdtext);
                    }
                }
            }
            if (!string.IsNullOrEmpty(cmdtext))
            {
                using (SqlHelper helper = new SqlHelper())
                {
                    try
                    {
                        helper.BeginTransaction();
                        foreach (var cmd in cmdlist)
                        {
                            helper.Execute(cmd, CommandType.Text, new List<SqlParameter>());
                        }
                        helper.Commit();
                    }
                    catch (Exception ex)
                    {
                        LogHelper.WriteError("ImportFeeHandler", "visit: createimportfee", ex);
                        helper.Rollback();
                        WebUtil.WriteJson(context, new { status = 2 });
                        return;
                    }
                }
            }
            WebUtil.WriteJson(context, new { status = 1 });
        }
        private void DeleteImportSetFee(HttpContext context)
        {
            string IDStr = context.Request.Params["IDList"];
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(IDStr);
            if (IDList.Count <= 0)
            {
                WebUtil.WriteJson(context, new { status = false, error = "请选择数据，操作取消" });
                return;
            }
            var historyList = RoomFeeHistory.GetRoomFeeHistorysByHistoryImportFeeIDList(IDList);
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    foreach (var ID in IDList)
                    {
                        var historyData = historyList.FirstOrDefault(p => p.ImportFeeID == ID && (p.ChargeState == 1 || p.ChargeState == 4));
                        if (historyData != null)
                        {
                            helper.Rollback();
                            WebUtil.WriteJson(context, new { status = false, error = "账单已收费，禁止删除" });
                            return;
                        }
                        ImportFee importFee = ImportFee.GetOrCreateImportFeeByID(ID, helper);
                        RoomFee roomFee = RoomFee.GetRoomFeeByImportFeeID(importFee.ID, helper);
                        if (roomFee != null)
                        {
                            var is_cuishou = RoomFeeHistory.CheckCuiShouRoomFeeHistoryByID(roomFee.ID, helper);
                            if (is_cuishou)
                            {
                                helper.Rollback();
                                WebUtil.WriteJson(context, new { status = false, error = "账单催收中，禁止删除" });
                                return;
                            }
                            if (roomFee.IsCharged)
                            {
                                WebUtil.WriteJson(context, new { status = false, error = "账单已部分收费，禁止删除" });
                                return;
                            }
                            roomFee.Delete(helper);
                        }
                        importFee.Delete(helper);
                    }
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError("ImportFeeHandler", "visit: DeleteImportSetFee", ex);
                    WebUtil.WriteJson(context, new { status = false });
                    return;
                }
            }
            #region 删除日志
            var user = WebUtil.GetUser(context);
            APPCode.CommHelper.SaveOperationLog(string.Join(",", IDList.ToArray()), Utility.EnumModel.OperationModule.ImportFeeDelete.ToString(), "账单处理账单删除", user.UserID.ToString(), "ImportFee", user.LoginName, IsHide: true);
            APPCode.CommHelper.SaveOperationLog("用户" + user.LoginName + "删除了账单处理账单", Utility.EnumModel.OperationModule.ImportFeeDelete.ToString(), "账单处理账单删除", user.UserID.ToString(), "ImportFee", user.LoginName);
            #endregion
            WebUtil.WriteJson(context, new { status = true });
        }
        private void SaveImportSetFee(HttpContext context)
        {
            int Number = int.Parse(context.Request.Params["Number"]);
            int ID = int.Parse(context.Request.Params["ID"]);
            string SetName = context.Request.Params["SetName"];
            int ChargeTypeID = int.Parse(context.Request.Params["ChargeTypeID"]);
            int CategoryID = int.Parse(context.Request.Params["CategoryID"]);
            int EndNumber = int.Parse(context.Request.Params["EndNumber"]);
            decimal SummaryUnitPrice = decimal.Parse(context.Request.Params["SummaryUnitPrice"]);
            decimal Coefficient = decimal.Parse(context.Request.Params["Coefficient"]);
            string Unit = context.Request.Params["Unit"];
            ChargeSummary chargeSummary = ChargeSummary.GetChargeSummary(ID);
            chargeSummary.OrderBy = Number;
            chargeSummary.Name = SetName;
            chargeSummary.TypeID = ChargeTypeID;
            chargeSummary.CategoryID = CategoryID;
            chargeSummary.EndNumber = EndNumber;
            chargeSummary.SummaryUnitPrice = SummaryUnitPrice;
            chargeSummary.Coefficient = Coefficient;
            chargeSummary.Unit = Unit;
            chargeSummary.Save();
            context.Response.Write("{\"status\":true}");
        }
        private void SaveImportFee(HttpContext context)
        {
            int state = 1;
            bool importsuccess = true;
            string importfeelist = context.Request.Params["ImportFeeList"];
            List<ImportFee> list = JsonConvert.DeserializeObject<List<ImportFee>>(importfeelist);
            var ViewImportFeeList = Foresight.DataAccess.ViewImportFeeDetail2.GetViewImportFeeDetail2ListByID(list.Select(p => p.ID).ToList());
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    foreach (var importFee in list)
                    {
                        var chargesummary = ChargeSummary.GetChargeSummary(importFee.ChargeID);
                        var importFeeNew = ImportFee.GetOrCreateImportFeeByID(importFee.ID, helper);
                        if (importFeeNew.ChargeStatus == 1)
                        {
                            importFeeNew.StartTime = importFee.StartTime;
                            importFeeNew.EndTime = importFee.EndTime;
                            importFeeNew.Save(helper);
                            string HistoryStartTime = importFee.StartTime == DateTime.MinValue ? "NULL" : "'" + importFee.StartTime.ToString("yyyy-MM-dd") + "'";
                            string HistoryEndTime = importFee.EndTime == DateTime.MinValue ? "NULL" : "'" + importFee.EndTime.ToString("yyyy-MM-dd") + "'";
                            string newcmdtext = "update [RoomFeeHistory] set [StartTime]=" + HistoryStartTime + ",[EndTime]=" + HistoryEndTime + " where [ImportFeeID]='" + importFeeNew.ID + "' and ChargeState in (1)";
                            helper.Execute(newcmdtext, CommandType.Text, new List<SqlParameter>());
                            continue;
                        }
                        importFeeNew.ChargeID = importFee.ChargeID;
                        importFeeNew.ImportRate = importFee.ImportRate;
                        importFeeNew.ImportReducePoint = importFee.ImportReducePoint;
                        importFeeNew.ChargeID = importFee.ChargeID;
                        importFeeNew.StartPoint = importFee.StartPoint;
                        importFeeNew.EndPoint = importFee.EndPoint;
                        importFeeNew.UnitPrice = importFee.UnitPrice;
                        importFeeNew.ImportCoefficient = importFee.ImportCoefficient;
                        decimal TotalPoint = 0;
                        if (importFeeNew.ProjectBiaoID > 0)
                        {
                            var viewimportfee = ViewImportFeeList.FirstOrDefault(p => p.ID == importFeeNew.ID);
                            TotalPoint = importFee.EndPoint - importFee.StartPoint;
                            TotalPoint = TotalPoint > 0 ? TotalPoint : 0;
                            TotalPoint = TotalPoint * (importFeeNew.ImportRate > 0 ? importFeeNew.ImportRate : 0);
                            TotalPoint = TotalPoint - (viewimportfee.FinalReducePoint > 0 ? viewimportfee.FinalReducePoint : 0);
                            TotalPoint = TotalPoint > 0 ? TotalPoint : 0;
                        }
                        else
                        {
                            TotalPoint = importFee.EndPoint - importFee.StartPoint;
                        }
                        if (TotalPoint <= 0)
                        {
                            TotalPoint = importFee.TotalPoint > 0 ? importFee.TotalPoint : 0;
                        }
                        importFeeNew.TotalPoint = TotalPoint;
                        decimal TotalPrice = TotalPrice = importFeeNew.TotalPoint * importFeeNew.UnitPrice * importFeeNew.ImportCoefficient;
                        if (TotalPrice <= 0)
                        {
                            TotalPrice = importFee.TotalPrice > 0 ? importFee.TotalPrice : 0;
                        }
                        importFeeNew.TotalPrice = TotalPrice;
                        importFeeNew.WriteDate = importFee.WriteDate;
                        importFeeNew.StartTime = importFee.StartTime;
                        importFeeNew.EndTime = importFee.EndTime;
                        importFeeNew.ImportBiaoCategory = importFee.ImportBiaoCategory;
                        importFeeNew.ImportBiaoName = importFee.ImportBiaoName;
                        importFeeNew.Save(helper);
                        var roomFee = RoomFee.GetRoomFeeByImportFeeID(importFeeNew.ID, helper);
                        if (roomFee != null)
                        {
                            roomFee.ChargeID = importFeeNew.ChargeID;
                            roomFee.UnitPrice = importFeeNew.UnitPrice;
                            roomFee.StartTime = importFeeNew.StartTime;
                            roomFee.EndTime = importFeeNew.EndTime;
                            roomFee.Cost = importFeeNew.TotalPrice;
                            roomFee.UseCount = importFeeNew.TotalPoint;
                            roomFee.RoomFeeCoefficient = importFeeNew.ImportCoefficient;
                            roomFee.RoomFeeStartPoint = importFeeNew.StartPoint;
                            roomFee.RoomFeeEndPoint = importFeeNew.EndPoint;
                            roomFee.RoomFeeWriteDate = importFeeNew.WriteDate;
                            roomFee.Save(helper);
                        }
                    }
                    if (importsuccess)
                    {
                        helper.Commit();
                    }
                    else
                    {
                        helper.Rollback();
                    }
                    context.Response.Write("{\"status\":" + state + "}");
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    state = 3;
                    LogHelper.WriteError("ImportFeeHandler", "visit: SaveImportFee", ex);
                    context.Response.Write("{\"status\":" + state + "}");
                }
            }
        }
        private void loaddaishouimport(HttpContext context)
        {
            try
            {
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
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
                int ChargeID = 0;
                int.TryParse(context.Request.Params["ChargeID"], out ChargeID);
                string FeeTypeListStr = context.Request.Params["FeeTypeList"];
                List<int> FeeTypeList = new List<int>();
                if (!string.IsNullOrEmpty(FeeTypeListStr))
                {
                    FeeTypeList = JsonConvert.DeserializeObject<List<int>>(FeeTypeListStr);
                }
                int FeeStatus = int.MinValue;
                if (!string.IsNullOrEmpty(context.Request.Params["FeeStatus"]))
                {
                    int.TryParse(context.Request.Params["FeeStatus"], out FeeStatus);
                }
                bool AllowImport = false;
                bool.TryParse(context.Request.Params["AllowImport"], out AllowImport);
                DateTime StartWriteDate = DateTime.MinValue;
                DateTime.TryParse(context.Request.Params["StartWriteDate"], out StartWriteDate);
                DateTime EndWriteDate = DateTime.MinValue;
                DateTime.TryParse(context.Request.Params["EndWriteDate"], out EndWriteDate);
                bool IsReading = false;
                bool.TryParse(context.Request.Params["IsReading"], out IsReading);
                string BiaoCategory = context.Request.Params["BiaoCategory"];
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                bool ShowFooter = false;
                bool.TryParse(context.Request.Params["ShowFooter"], out ShowFooter);
                bool canexport = WebUtil.GetBoolValue(context, "canexport");
                DataGrid dg = ViewImportFeeDetail2.GetViewImportFeeGridByRoomID(context.Request.Params["Keywords"], FeeTypeList, RoomIDList, ProjectIDList, ChargeID, FeeStatus, StartWriteDate, EndWriteDate, IsReading, AllowImport, BiaoCategory, "order by WriteDate desc,[DefaultOrder] asc", startRowIndex, pageSize, ShowFooter: ShowFooter, canexport: canexport);
                if (canexport)
                {
                    string downloadurl = string.Empty;
                    string error = string.Empty;
                    bool status = APPCode.ExportHelper.DownLoadGongTanData(dg, out downloadurl, out error);
                    WebUtil.WriteJson(context, new { status = status, downloadurl = downloadurl, error = error });
                    return;
                }
                string result = JsonConvert.SerializeObject(dg);
                context.Response.Write(result);
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("ImportFeeHandler", "visit: LoadDaishouImport", ex);
                context.Response.Write("{\"rows\":[],\"total\":0,\"page\":0}");
            }
        }
        #region Comm Methods
        /// <summary>
        /// 1-成功 2-预收款已经冲销 3-选中的订单部分已交班
        /// </summary>
        /// <param name="importFeeList"></param>
        /// <returns></returns>
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
        private DateTime GetEndTime(ViewChargeSummary summary, DateTime StartTime)
        {
            if (StartTime == DateTime.MinValue)
            {
                return DateTime.MinValue;
            }
            if (StartTime > DateTime.Now)
            {
                return DateTime.MinValue;
            }
            int SummaryChargeTypeCount = summary.SummaryChargeTypeCount;
            SummaryChargeTypeCount = SummaryChargeTypeCount < 0 ? 1 : SummaryChargeTypeCount;
            int EndNumberType = summary.EndNumberType == int.MinValue ? 1 : summary.EndNumberType;
            int EndTypeID = summary.EndTypeID == int.MinValue ? 1 : summary.EndTypeID;
            DateTime EndTime = DateTime.MinValue;
            if (EndTypeID == 1)
            {
                StartTime = DateTime.Now;
            }
            if (summary.AutoToMonthEnd)
            {
                if (EndNumberType == 1)
                {
                    EndTime = StartTime.AddDays(1 - StartTime.Day).AddMonths(SummaryChargeTypeCount + 1).AddDays(-1);
                }
                else
                {
                    EndTime = StartTime.AddDays(1 - StartTime.Day).AddMonths(1).AddDays(-1);
                }
            }
            else
            {
                if (EndNumberType == 1)
                {
                    EndTime = StartTime.AddMonths(SummaryChargeTypeCount).AddDays(-1);
                }
                else
                {
                    EndTime = StartTime.AddDays(SummaryChargeTypeCount);
                }
            }
            return EndTime;
        }
        private void SaveRoomHistoryFee(ViewImportFeeDetail2[] importFeeList, SqlHelper helper, string AddMan)
        {
            SaveRoomHistoryFee(importFeeList, helper, AddMan, AddMan, DateTime.MinValue, string.Empty, 0);
        }
        private void SaveRoomHistoryFee(ViewImportFeeDetail2[] importFeeList, SqlHelper helper, string ChargeMan, string AddMan, DateTime ChargeTime, string Remark, int ChargeMoneyType)
        {
            foreach (var importFee in importFeeList)
            {
                ChargeTime = (ChargeTime == DateTime.MinValue ? importFee.WriteDate : ChargeTime);
                PrintRoomFeeHistory printRoomFeeHistory = new PrintRoomFeeHistory();
                printRoomFeeHistory.Cost = importFee.FinalTotalPrice;
                printRoomFeeHistory.CostCapital = Tools.CmycurD(printRoomFeeHistory.Cost);
                printRoomFeeHistory.RealCost = printRoomFeeHistory.Cost;
                printRoomFeeHistory.PreChargeMoney = 0;
                printRoomFeeHistory.DiscountMoney = 0;
                printRoomFeeHistory.RealMoneyCost1 = printRoomFeeHistory.Cost;
                printRoomFeeHistory.RealMoneyCost2 = 0;
                printRoomFeeHistory.AddTime = DateTime.Now;
                int OrderNumberID = 0;
                string PrintNumber = PrintRoomFeeHistory.GetLastestPrintNumber(importFee.RoomID, helper, out OrderNumberID);
                printRoomFeeHistory.PrintNumber = PrintNumber;
                printRoomFeeHistory.OrderNumberID = OrderNumberID;
                printRoomFeeHistory.ChargeBackMoney = 0;
                printRoomFeeHistory.ChageType1 = ChargeMoneyType;
                printRoomFeeHistory.IsCancel = false;
                printRoomFeeHistory.ChargeTime = ChargeTime;
                printRoomFeeHistory.AddMan = AddMan;
                printRoomFeeHistory.Remark = Remark;
                printRoomFeeHistory.ChargeMan = ChargeMan;
                printRoomFeeHistory.Save(helper);
                RoomFeeHistory roomFeeHistory = new RoomFeeHistory();
                var roomFee = Foresight.DataAccess.RoomFee.GetRoomFeeByImportFeeID(importFee.ID, helper);
                if (roomFee != null)
                {
                    roomFee.StartTime = importFee.StartTime;
                    roomFee.EndTime = importFee.EndTime;
                    roomFee.UseCount = importFee.RealTotalPoint;
                    roomFee.Cost = importFee.FinalTotalPrice;
                    roomFee.IsCharged = true;
                    roomFee.UnitPrice = importFee.FinalUnitPrice;
                    roomFee.RealCost = roomFee.Cost;
                    roomFee.Discount = 0;
                    roomFee.TotalRealCost = (roomFee.TotalRealCost < 0 ? 0 : roomFee.TotalRealCost) + roomFee.RealCost;
                    roomFee.TotalDiscountCost = (roomFee.TotalDiscountCost < 0 ? 0 : roomFee.TotalDiscountCost) + roomFee.Discount;
                    decimal restcost = roomFee.Cost - roomFee.TotalDiscountCost - roomFee.TotalRealCost;
                    if (restcost < 0)
                    {
                        restcost = 0;
                    }
                    roomFee.RestCost = restcost;
                    roomFee.Save(helper);
                    int HistoryID = RoomFeeHistory.InsertRoomFeeHistoryByRoomID(roomFee.ID, ChargeMan, helper);
                    roomFeeHistory = RoomFeeHistory.GetRoomFeeHistory(HistoryID, helper);
                    roomFeeHistory.PrintID = printRoomFeeHistory.ID;
                    roomFeeHistory.ChargeTime = printRoomFeeHistory.ChargeTime;
                    roomFeeHistory.Save(helper);
                    roomFee.Delete(helper);
                }
                else
                {
                    roomFeeHistory.ID = importFee.ID;
                    roomFeeHistory.RoomID = importFee.RoomID;
                    roomFeeHistory.UseCount = importFee.TotalPoint;
                    roomFeeHistory.StartTime = importFee.StartTime;
                    roomFeeHistory.EndTime = importFee.EndTime;
                    roomFeeHistory.Cost = importFee.TotalPrice;
                    roomFeeHistory.AddTime = DateTime.Now;
                    roomFeeHistory.AddUserName = User.GetCurrentUserName();
                    roomFeeHistory.IsCharged = true;
                    roomFeeHistory.ChargeID = importFee.ChargeID;
                    roomFeeHistory.IsStart = true;
                    roomFeeHistory.UnitPrice = importFee.UnitPrice;
                    roomFeeHistory.ImportFeeID = importFee.ID;
                    roomFeeHistory.ChargeFeeID = 0;
                    roomFeeHistory.ChargeFee = 0;
                    roomFeeHistory.RealCost = importFee.TotalPrice;
                    roomFeeHistory.Discount = 0;
                    roomFeeHistory.TotalRealCost = importFee.TotalPrice;
                    roomFeeHistory.TotalDiscountCost = 0;
                    roomFeeHistory.RestCost = 0;
                    roomFeeHistory.PrintID = printRoomFeeHistory.ID;
                    roomFeeHistory.ChargeState = 1;
                    roomFeeHistory.ChargeTime = ChargeTime;
                    roomFeeHistory.Remark = Remark;
                    roomFeeHistory.ChargeMan = ChargeMan;
                    roomFeeHistory.IsImportFee = true;
                    roomFeeHistory.Save(helper);
                }
            }
        }
        #endregion

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}