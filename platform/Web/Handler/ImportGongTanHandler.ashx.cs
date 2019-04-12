using ExcelProcess;
using Foresight.DataAccess;
using Foresight.DataAccess.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using Utility;

namespace Web.Handler
{
    /// <summary>
    /// ImportHandler 的摘要说明
    /// </summary>
    public class ImportGongTanHandler : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string visit = context.Request.Params["visit"];
            if (string.IsNullOrEmpty(visit))
            {
                LogHelper.WriteDebug("ImportChaoBiaoHandler", "visit为空");
                context.Response.Write(null);
                return;
            }
            visit = visit.ToLower();
            try
            {
                switch (visit)
                {
                    case "importgongtan":
                        importgongtan(context);
                        break;
                    case "importtaizhang":
                        importtaizhang(context);
                        break;
                    case "importmeterdata":
                        importmeterdata(context);
                        break;
                    case "importmeterpointdata":
                        importmeterpointdata(context);
                        break;
                    default:
                        WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "Unkown Visit: " + visit);
                        break;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("ImportGongTanHandler", "visit: " + visit, ex);
                context.Response.Write("{\"status\":false}");
            }
        }
        private void importmeterpointdata(HttpContext context)
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
            string msg = string.Empty;
            bool ImportFailed = false;
            int TotalNumber = 0;
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    #region 导入处理
                    for (int j = 0; j < uploadFiles.Count; j++)
                    {
                        HttpPostedFile postedFile = uploadFiles[j];
                        string filepath = HttpContext.Current.Server.MapPath("~/upload/ImportChaoBiao/" + DateTime.Now.ToString("yyyyMMdd"));
                        if (!System.IO.Directory.Exists(filepath))
                        {
                            System.IO.Directory.CreateDirectory(filepath);
                        }
                        string filename = DateTime.Now.ToLocalTime().ToString("yyyyMMddHHmmss") + "_" + postedFile.FileName;
                        string fullpath = Path.Combine(filepath, filename);
                        postedFile.SaveAs(fullpath);
                        DataTable table = ExcelExportHelper.NPOIReadExcel(fullpath);
                        for (int i = 0; i < table.Rows.Count; i++)
                        {
                            int ID = 0;
                            int.TryParse(table.Rows[i]["仪表ID"].ToString(), out ID);
                            Foresight.DataAccess.ChargeMeter_Project projectbiao = null;
                            if (ID > 0)
                            {
                                projectbiao = Foresight.DataAccess.ChargeMeter_Project.GetChargeMeter_Project(ID, helper);
                            }
                            if (projectbiao == null)
                            {
                                msg += "<p>第" + (i + 2) + "行上传失败。原因：仪表不存在</p>";
                                ImportFailed = true;
                                break;
                            }
                            projectbiao.MeterName = table.Rows[i]["仪表名称"].ToString();
                            projectbiao.MeterNumber = table.Rows[i]["仪表编号"].ToString();
                            projectbiao.MeterCategoryID = ChargeMeter_Project.GetMeterCategoryID(table.Rows[i]["仪表种类"].ToString());
                            if (projectbiao.MeterCategoryID == 0)
                            {
                                msg += "<p>第" + (i + 2) + "行上传失败。原因：仪表种类不存在</p>";
                                ImportFailed = true;
                                break;
                            }
                            projectbiao.MeterType = ChargeMeter_Project.GetMeterTypeID(table.Rows[i]["仪表类型"].ToString());
                            if (projectbiao.MeterType == 0)
                            {
                                msg += "<p>第" + (i + 2) + "行上传失败。原因：仪表类型不存在</p>";
                                ImportFailed = true;
                                break;
                            }
                            projectbiao.MeterSpec = ChargeMeter_Project.GetMeterSpec(table.Rows[i]["仪表规格"].ToString());
                            if (projectbiao.MeterSpec == 0)
                            {
                                msg += "<p>第" + (i + 2) + "行上传失败。原因：仪表规格不存在</p>";
                                ImportFailed = true;
                                break;
                            }
                            projectbiao.MeterCoefficient = WebUtil.GetDecimalByStr(table.Rows[i]["倍率"].ToString());
                            projectbiao.MeterHouseNo = table.Rows[i]["缴费户号"].ToString();
                            projectbiao.MeterLocation = table.Rows[i]["仪表位置"].ToString();
                            projectbiao.MeterRemark = table.Rows[i]["备注"].ToString();
                            projectbiao.SortOrder = WebUtil.GetIntByStr(table.Rows[i]["排序序号"].ToString());
                            projectbiao.MeterStartPoint = WebUtil.GetDecimalByStr(table.Rows[i]["上次读数"].ToString());
                            projectbiao.MeterEndPoint = WebUtil.GetDecimalByStr(table.Rows[i]["本次读数"].ToString());
                            projectbiao.Save(helper);
                            TotalNumber = i;
                        }
                    }
                    #endregion
                    if (!ImportFailed)
                    {
                        helper.Commit();
                        msg += "<p>导入完成</p>";
                    }
                    else
                    {
                        helper.Rollback();
                        msg += "<p>导入失败</p>";
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.WriteError("ImportGongTanHandler", "visit: importmeterdata", ex);
                    helper.Rollback();
                    msg += "<p>第" + (TotalNumber + 2) + "行上传失败。原因：" + ex.Message + "</p>";
                }
                context.Response.Write(msg);
            }
        }
        private void importmeterdata(HttpContext context)
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
            string msg = string.Empty;
            bool ImportFailed = false;
            int TotalNumber = 0;
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    #region 导入处理
                    for (int j = 0; j < uploadFiles.Count; j++)
                    {
                        HttpPostedFile postedFile = uploadFiles[j];
                        string filepath = HttpContext.Current.Server.MapPath("~/upload/ImportChaoBiao/" + DateTime.Now.ToString("yyyyMMdd"));
                        if (!System.IO.Directory.Exists(filepath))
                        {
                            System.IO.Directory.CreateDirectory(filepath);
                        }
                        string filename = DateTime.Now.ToLocalTime().ToString("yyyyMMddHHmmss") + "_" + postedFile.FileName;
                        string fullpath = Path.Combine(filepath, filename);
                        postedFile.SaveAs(fullpath);
                        DataTable table = ExcelExportHelper.NPOIReadExcel(fullpath);
                        for (int i = 0; i < table.Rows.Count; i++)
                        {
                            int ID = 0;
                            int.TryParse(table.Rows[i]["仪表ID"].ToString(), out ID);
                            Foresight.DataAccess.ChargeMeter_Project projectbiao = null;
                            if (ID > 0)
                            {
                                projectbiao = Foresight.DataAccess.ChargeMeter_Project.GetChargeMeter_Project(ID, helper);
                            }
                            if (projectbiao == null)
                            {
                                msg += "<p>第" + (i + 2) + "行上传失败。原因：仪表不存在</p>";
                                ImportFailed = true;
                                break;
                            }
                            projectbiao.MeterName = table.Rows[i]["仪表名称"].ToString();
                            projectbiao.MeterNumber = table.Rows[i]["仪表编号"].ToString();
                            projectbiao.MeterCategoryID = ChargeMeter_Project.GetMeterCategoryID(table.Rows[i]["仪表种类"].ToString());
                            if (projectbiao.MeterCategoryID == 0)
                            {
                                msg += "<p>第" + (i + 2) + "行上传失败。原因：仪表种类不存在</p>";
                                ImportFailed = true;
                                break;
                            }
                            projectbiao.MeterType = ChargeMeter_Project.GetMeterTypeID(table.Rows[i]["仪表类型"].ToString());
                            if (projectbiao.MeterType == 0)
                            {
                                msg += "<p>第" + (i + 2) + "行上传失败。原因：仪表类型不存在</p>";
                                ImportFailed = true;
                                break;
                            }
                            projectbiao.MeterSpec = ChargeMeter_Project.GetMeterSpec(table.Rows[i]["仪表规格"].ToString());
                            if (projectbiao.MeterSpec == 0)
                            {
                                msg += "<p>第" + (i + 2) + "行上传失败。原因：仪表规格不存在</p>";
                                ImportFailed = true;
                                break;
                            }
                            projectbiao.MeterCoefficient = WebUtil.GetDecimalByStr(table.Rows[i]["倍率"].ToString());
                            projectbiao.MeterHouseNo = table.Rows[i]["缴费户号"].ToString();
                            projectbiao.MeterLocation = table.Rows[i]["仪表位置"].ToString();
                            projectbiao.MeterRemark = table.Rows[i]["备注"].ToString();
                            projectbiao.SortOrder = WebUtil.GetIntByStr(table.Rows[i]["排序序号"].ToString());
                            projectbiao.Save(helper);
                            TotalNumber = i;
                        }
                    }
                    #endregion
                    if (!ImportFailed)
                    {
                        helper.Commit();
                        msg += "<p>导入完成</p>";
                    }
                    else
                    {
                        helper.Rollback();
                        msg += "<p>导入失败</p>";
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.WriteError("ImportGongTanHandler", "visit: importmeterdata", ex);
                    helper.Rollback();
                    msg += "<p>第" + (TotalNumber + 2) + "行上传失败。原因：" + ex.Message + "</p>";
                }
                context.Response.Write(msg);
            }
        }
        private void importtaizhang(HttpContext context)
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
            string msg = string.Empty;
            bool ImportFailed = false;
            int TotalNumber = 0;
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    #region 导入处理
                    for (int j = 0; j < uploadFiles.Count; j++)
                    {
                        HttpPostedFile postedFile = uploadFiles[j];
                        string filepath = HttpContext.Current.Server.MapPath("~/upload/ImportChaoBiao/" + DateTime.Now.ToString("yyyyMMdd"));
                        if (!System.IO.Directory.Exists(filepath))
                        {
                            System.IO.Directory.CreateDirectory(filepath);
                        }
                        string filename = DateTime.Now.ToLocalTime().ToString("yyyyMMddHHmmss") + "_" + postedFile.FileName;
                        string fullpath = Path.Combine(filepath, filename);
                        postedFile.SaveAs(fullpath);
                        DataTable table = ExcelExportHelper.NPOIReadExcel(fullpath);
                        for (int i = 0; i < table.Rows.Count; i++)
                        {
                            int ID = 0;
                            int.TryParse(table.Rows[i]["表台帐ID"].ToString(), out ID);
                            Foresight.DataAccess.Project_Biao projectbiao = null;
                            if (ID > 0)
                            {
                                projectbiao = Foresight.DataAccess.Project_Biao.GetProject_Biao(ID, helper);
                            }
                            if (projectbiao == null)
                            {
                                msg += "<p>第" + (i + 2) + "行上传失败。原因：表台帐不存在</p>";
                                ImportFailed = true;
                                break;
                            }
                            projectbiao.BiaoName = table.Rows[i]["表名称"].ToString();
                            projectbiao.BiaoCategory = table.Rows[i]["表种类"].ToString();
                            projectbiao.BiaoGuiGe = table.Rows[i]["表规格"].ToString();
                            projectbiao.ChargeRoomNo = table.Rows[i]["缴费户号"].ToString();

                            decimal Rate = 0;
                            decimal.TryParse(table.Rows[i]["倍率"].ToString(), out Rate);
                            Rate = Rate > 0 ? Rate : 0;
                            projectbiao.Rate = Rate;

                            decimal StartPoint = 0;
                            decimal.TryParse(table.Rows[i]["上次读数"].ToString(), out StartPoint);
                            StartPoint = StartPoint > 0 ? StartPoint : 0;
                            projectbiao.StartPoint = StartPoint;

                            decimal EndPoint = 0;
                            decimal.TryParse(table.Rows[i]["本次读数"].ToString(), out EndPoint);
                            EndPoint = EndPoint > 0 ? EndPoint : 0;
                            projectbiao.EndPoint = EndPoint;

                            decimal ReducePoint = 0;
                            decimal.TryParse(table.Rows[i]["扣减用量"].ToString(), out ReducePoint);
                            ReducePoint = ReducePoint > 0 ? ReducePoint : 0;
                            projectbiao.ReducePoint = ReducePoint;

                            decimal TotalPoint = 0;
                            decimal.TryParse(table.Rows[i]["本次用量"].ToString(), out TotalPoint);
                            if (TotalPoint <= 0)
                            {
                                TotalPoint = (EndPoint - StartPoint) * (Rate > 0 ? Rate : 0) - (ReducePoint > 0 ? ReducePoint : 0);
                            }
                            TotalPoint = TotalPoint > 0 ? TotalPoint : 0;
                            projectbiao.TotalPoint = TotalPoint;

                            projectbiao.Remark = table.Rows[i]["备注"].ToString();
                            projectbiao.IsActive = table.Rows[i]["作废状态"].ToString().Equals("生效") ? true : false;

                            decimal ImportCoefficient = 0;
                            decimal.TryParse(table.Rows[i]["系数"].ToString(), out ImportCoefficient);
                            if (ImportCoefficient > 0)
                            {
                                projectbiao.Coefficient = ImportCoefficient;
                            }
                            decimal UnitPrice = 0;
                            decimal.TryParse(table.Rows[i]["单价"].ToString(), out UnitPrice);
                            if (UnitPrice > 0)
                            {
                                projectbiao.UnitPrice = UnitPrice;
                            }
                            projectbiao.Save(helper);
                            string cmdtex_2 = string.Empty;
                            if (projectbiao.Coefficient > 0)
                            {
                                cmdtex_2 += ",[ImportCoefficient]='" + projectbiao.Coefficient + "'";
                            }
                            if (projectbiao.UnitPrice > 0)
                            {
                                cmdtex_2 += ",[UnitPrice]='" + projectbiao.UnitPrice + "'";
                            }
                            string cmdtext = "update [ImportFee] set [ImportBiaoCategory]='" + projectbiao.BiaoCategory + "',[ImportBiaoName]='" + projectbiao.BiaoName + "',[StartPoint]='" + StartPoint + "',[EndPoint]='" + EndPoint + "',[TotalPoint]='" + TotalPoint + "' " + cmdtex_2 + " where ID in (select top 1 ID from [ImportFee] where  [ProjectBiaoID]=" + projectbiao.ID + " and RoomID ='" + projectbiao.ProjectID + "' order by [WriteDate] desc);";
                            helper.Execute(cmdtext, CommandType.Text, new List<SqlParameter>());
                            TotalNumber = i;
                        }
                    }
                    #endregion
                    if (!ImportFailed)
                    {
                        helper.Commit();
                        msg += "<p>导入完成</p>";
                    }
                    else
                    {
                        helper.Rollback();
                        msg += "<p>导入失败</p>";
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.WriteError("ImportGongTanHandler", "visit: importtaizhang", ex);
                    helper.Rollback();
                    msg += "<p>第" + (TotalNumber + 2) + "行上传失败。原因：" + ex.Message + "</p>";
                }
                context.Response.Write(msg);
            }
        }

        private void importgongtan(HttpContext context)
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
            string msg = string.Empty;
            int CompanyID = WebUtil.GetCompanyID(context);
            int CreatorID = WebUtil.GetUser(context).UserID;
            string AddMan = WebUtil.GetUser(context).RealName;
            bool ImportFailed = false;
            var summarylist = ChargeSummary.GetChargeSummaries().ToArray();
            titleList = Foresight.DataAccess.TableColumn.GetTableColumnByPageCode("roomfeesource", true).Where(p => !p.ColumnName.Equals("选择按钮")).ToArray();
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    #region 导入处理
                    for (int j = 0; j < uploadFiles.Count; j++)
                    {
                        HttpPostedFile postedFile = uploadFiles[j];
                        string filepath = HttpContext.Current.Server.MapPath("~/upload/ImportChaoBiao/" + DateTime.Now.ToString("yyyyMMdd"));
                        if (!System.IO.Directory.Exists(filepath))
                        {
                            System.IO.Directory.CreateDirectory(filepath);
                        }
                        string filename = DateTime.Now.ToLocalTime().ToString("yyyyMMddHHmmss") + "_" + postedFile.FileName;
                        string fullpath = Path.Combine(filepath, filename);
                        postedFile.SaveAs(fullpath);
                        DataTable table = ExcelExportHelper.NPOIReadExcel(fullpath);
                        for (int i = 0; i < table.Rows.Count; i++)
                        {
                            Project project = null;
                            object Value, FullName, RoomName;
                            if (GetColumnValue("房源信息", table, i, out FullName) && GetColumnValue("房间号", table, i, out RoomName))
                            {
                                project = Project.GetProjectByFullName(RoomName.ToString(), FullName.ToString(), CompanyID, helper);
                            }
                            if (project == null)
                            {
                                msg += "<p>第" + (i + 2) + "行上传失败。原因：房间资源不存在</p>";
                                ImportFailed = true;
                                break;
                            }
                            ChargeSummary summary = null;
                            if (GetColumnValue("收费项目", table, i, out Value))
                            {
                                summary = summarylist.FirstOrDefault(p => p.CompanyID == CompanyID && p.Name.Equals(Value.ToString()));
                            }
                            if (summary == null)
                            {
                                msg += "<p>第" + (i + 2) + "行上传失败。原因：收费项目项目不存在</p>";
                                ImportFailed = true;
                                break;
                            }
                            int ID = 0;
                            int.TryParse(table.Rows[i]["账单ID"].ToString(), out ID);
                            Foresight.DataAccess.ImportFee importFee = null;
                            if (ID > 0)
                            {
                                importFee = Foresight.DataAccess.ImportFee.GetOrCreateImportFeeByID(ID, helper, CanCreate: false);
                            }
                            if (importFee == null)
                            {
                                importFee = new Foresight.DataAccess.ImportFee();
                                importFee.ChargeStatus = 0;
                                importFee.AddTime = DateTime.Now;
                                importFee.ChargeID = summary.ID;
                                importFee.RoomID = project.ID;
                                importFee.ChargeStatus = 2;
                            }
                            if (importFee.ChargeStatus == 1)
                            {
                                msg += "<p>第" + (i + 2) + "行上传失败。原因：该费用已收取</p>";
                                ImportFailed = true;
                                break;
                            }
                            if (GetColumnValue("上次读数", table, i, out Value))
                            {
                                importFee.StartPoint = GetDecimalValue(Value);
                            }
                            if (GetColumnValue("本次读数", table, i, out Value))
                            {
                                importFee.EndPoint = GetDecimalValue(Value);
                            }
                            decimal totalpoint = decimal.MinValue;
                            if (GetColumnValue("用量", table, i, out Value))
                            {
                                totalpoint = GetDecimalValue(Value);
                            }
                            if (totalpoint == decimal.MinValue)
                            {
                                totalpoint = (importFee.EndPoint == decimal.MinValue ? 0 : importFee.EndPoint) - (importFee.StartPoint == decimal.MinValue ? 0 : importFee.StartPoint);
                            }
                            totalpoint = totalpoint < 0 ? 0 : totalpoint;
                            importFee.TotalPoint = totalpoint;
                            if (GetColumnValue("单价", table, i, out Value))
                            {
                                importFee.UnitPrice = GetDecimalValue(Value);
                            }
                            if (GetColumnValue("系数", table, i, out Value))
                            {
                                importFee.ImportCoefficient = GetDecimalValue(Value);
                            }
                            decimal totalprice = decimal.MinValue;
                            if (GetColumnValue("金额", table, i, out Value))
                            {
                                totalprice = GetDecimalValue(Value);
                            }
                            if (totalprice == decimal.MinValue)
                            {
                                totalprice = (importFee.TotalPoint == decimal.MinValue ? 0 : importFee.TotalPoint) * (importFee.ImportCoefficient == decimal.MinValue ? 0 : importFee.ImportCoefficient) * (importFee.UnitPrice == decimal.MinValue ? 0 : importFee.UnitPrice);
                            }
                            importFee.TotalPrice = totalprice;
                            if (GetColumnValue("收费状态", table, i, out Value))
                            {
                                importFee.ChargeStatus = Value.ToString().Equals("已收") ? 1 : (Value.ToString().Equals("未收") ? 0 : 2);
                            }
                            if (GetColumnValue("账单日期", table, i, out Value))
                            {
                                importFee.WriteDate = GetDateTimeValue(Value);
                            }
                            if (GetColumnValue("计费开始日期", table, i, out Value))
                            {
                                importFee.StartTime = GetDateTimeValue(Value);
                            }
                            if (GetColumnValue("计费结束日期", table, i, out Value))
                            {
                                importFee.EndTime = GetDateTimeValue(Value);
                            }

                            string ImportBiaoCategory = string.Empty;
                            string ImportBiaoName = project.Name;
                            string ImportChargeRoomNo = string.Empty;
                            if (GetColumnValue("表种类", table, i, out Value))
                            {
                                ImportBiaoCategory = Value.ToString();
                            }
                            if (GetColumnValue("表名称", table, i, out Value))
                            {
                                ImportBiaoName = Value.ToString();
                            }
                            if (GetColumnValue("缴费户号", table, i, out Value))
                            {
                                ImportChargeRoomNo = Value.ToString();
                            }
                            Foresight.DataAccess.ImportFee lastimportFee = Foresight.DataAccess.ImportFee.GetImportFeeByRoomID(project.ID, null, importFee.ChargeID, helper);
                            if (string.IsNullOrEmpty(ImportBiaoCategory))
                            {
                                ImportBiaoCategory = summary.BiaoCategory;
                                if (lastimportFee != null && !string.IsNullOrEmpty(lastimportFee.ImportBiaoCategory))
                                {
                                    ImportBiaoCategory = lastimportFee.ImportBiaoCategory;
                                }
                            }
                            if (string.IsNullOrEmpty(ImportBiaoName))
                            {
                                ImportBiaoName = project.Name;
                                if (lastimportFee != null && !string.IsNullOrEmpty(lastimportFee.ImportBiaoName))
                                {
                                    ImportBiaoName = lastimportFee.ImportBiaoName;
                                }
                            }
                            if (string.IsNullOrEmpty(ImportChargeRoomNo))
                            {
                                if (lastimportFee != null && !string.IsNullOrEmpty(lastimportFee.ImportChargeRoomNo))
                                {
                                    ImportChargeRoomNo = lastimportFee.ImportChargeRoomNo;
                                }
                            }
                            importFee.ImportBiaoCategory = ImportBiaoCategory;
                            importFee.ImportBiaoName = ImportBiaoName;
                            importFee.ImportChargeRoomNo = ImportChargeRoomNo;
                            importFee.Save(helper);
                            if (importFee.ChargeStatus == 0)
                            {
                                SaveRoomFee(importFee, summary.ID, helper);
                            }
                            else if (importFee.ChargeStatus == 1)
                            {
                                SaveRoomHistoryFee(importFee, summary.ID, helper, AddMan);
                            }
                        }
                    }
                    #endregion
                    if (!ImportFailed)
                    {
                        helper.Commit();
                        msg += "<p>导入完成</p>";
                    }
                    else
                    {
                        helper.Rollback();
                        msg += "<p>导入失败</p>";
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.WriteError("ImportGongTanHandler", "visit: importgongtan", ex);
                    helper.Rollback();
                }
                context.Response.Write(msg);
            }
        }
        #region Comm Methods
        private decimal GetDecimalValue(object value)
        {
            decimal result = decimal.MinValue;
            decimal.TryParse(value.ToString(), out result);
            return result;
        }
        private DateTime GetDateTimeValue(object value)
        {
            DateTime result = DateTime.MinValue;
            DateTime.TryParse(value.ToString(), out result);
            return result;
        }
        private void SaveRoomFee(ImportFee importFee, int SummaryID, SqlHelper helper)
        {
            RoomFee roomFee = RoomFee.GetRoomFeeByImportFeeID(importFee.ID, helper);
            if (roomFee == null)
            {
                roomFee = new RoomFee();
                roomFee.AddTime = DateTime.Now;
                roomFee.AddUserName = User.GetCurrentUserName();
            }
            roomFee.RoomID = importFee.RoomID;
            roomFee.UseCount = importFee.TotalPoint;
            roomFee.StartTime = importFee.StartTime;
            roomFee.EndTime = importFee.EndTime;
            roomFee.Cost = importFee.TotalPrice;
            roomFee.IsCharged = false;
            roomFee.ChargeID = SummaryID;
            roomFee.IsStart = true;
            roomFee.UnitPrice = importFee.UnitPrice;
            roomFee.ImportFeeID = importFee.ID;
            roomFee.ChargeFeeID = 0;
            roomFee.ChargeFee = 0;
            roomFee.IsImportFee = true;
            roomFee.Save(helper);
        }
        private void SaveRoomHistoryFee(ImportFee importFee, int SummaryID, SqlHelper helper, string AddMan)
        {
            PrintRoomFeeHistory printRoomFeeHistory = new PrintRoomFeeHistory();
            printRoomFeeHistory.Cost = importFee.TotalPrice;
            printRoomFeeHistory.CostCapital = Tools.CmycurD(printRoomFeeHistory.Cost);
            printRoomFeeHistory.RealCost = printRoomFeeHistory.Cost;
            printRoomFeeHistory.PreChargeMoney = 0;
            printRoomFeeHistory.DiscountMoney = 0;
            printRoomFeeHistory.RealMoneyCost1 = printRoomFeeHistory.Cost;
            printRoomFeeHistory.RealMoneyCost2 = 0;
            printRoomFeeHistory.AddMan = AddMan;
            printRoomFeeHistory.AddTime = DateTime.Now;
            int OrderNumberID = 0;
            string PrintNumber = Foresight.DataAccess.PrintRoomFeeHistory.GetLastestPrintNumber(importFee.RoomID, helper, out OrderNumberID);
            printRoomFeeHistory.PrintNumber = PrintNumber;
            printRoomFeeHistory.OrderNumberID = OrderNumberID;
            printRoomFeeHistory.ChargeBackMoney = 0;
            printRoomFeeHistory.ChargeTime = DateTime.Now;
            printRoomFeeHistory.ChageType1 = 0;
            printRoomFeeHistory.IsCancel = false;
            printRoomFeeHistory.Save(helper);
            RoomFeeHistory roomFee = new RoomFeeHistory();
            roomFee.ID = importFee.ID;
            roomFee.RoomID = importFee.RoomID;
            roomFee.UseCount = importFee.TotalPoint;
            roomFee.StartTime = importFee.StartTime;
            roomFee.EndTime = importFee.EndTime;
            roomFee.Cost = importFee.TotalPrice;
            roomFee.AddTime = DateTime.Now;
            roomFee.AddUserName = User.GetCurrentUserName();
            roomFee.IsCharged = true;
            roomFee.ChargeID = SummaryID;
            roomFee.IsStart = true;
            roomFee.UnitPrice = importFee.UnitPrice;
            roomFee.ImportFeeID = importFee.ID;
            roomFee.ChargeFeeID = 0;
            roomFee.ChargeFee = 0;
            roomFee.RealCost = roomFee.Cost;
            roomFee.Discount = 0;
            roomFee.TotalRealCost = roomFee.RealCost;
            roomFee.TotalDiscountCost = 0;
            roomFee.RestCost = 0;
            roomFee.PrintID = printRoomFeeHistory.ID;
            roomFee.ChargeTime = DateTime.Now;
            roomFee.ChargeState = 1;
            roomFee.IsImportFee = true;
            roomFee.Save(helper);
        }
        private bool GetColumnValue(string Title, DataTable table, int index, out object Value)
        {
            Value = null;
            if (!table.Columns.Contains(Title))
            {
                return false;
            }
            bool result = false;
            for (int i = 0; i < titleList.Length; i++)
            {
                if (titleList[i].ColumnName.Equals(Title))
                {
                    DataRow dr = table.Rows[index];
                    if (dr == null)
                    {
                        return false;
                    }
                    Value = dr[Title];
                    result = true;
                    break;
                }
            }
            return result;
        }
        Foresight.DataAccess.TableColumn[] titleList = new Foresight.DataAccess.TableColumn[] { };
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