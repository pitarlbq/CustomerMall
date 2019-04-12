using Foresight.DataAccess.Framework;
using Foresight.DataAccess.Ui;

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using Utility;
using Web.Model;

namespace Web.Handler
{
    /// <summary>
    /// ZhuangXiuHandler 的摘要说明
    /// </summary>
    public class ZhuangXiuHandler : IHttpHandler, IRequiresSessionState
    {
        const string LogModule = "ZhuangXiuHandler";
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string visit = context.Request.Params["visit"];
            if (string.IsNullOrEmpty(visit))
            {
                LogHelper.WriteDebug(LogModule, "visit为空");
                context.Response.Write(null);
                return;
            }
            visit = visit.ToLower();
            try
            {
                switch (visit)
                {
                    case "loadzhuangxiugrid":
                        loadzhuangxiugrid(context);
                        break;
                    case "savezhuangxiu":
                        savezhuangxiu(context);
                        break;
                    case "loadzhuangxiuattachs":
                        loadzhuangxiuattachs(context);
                        break;
                    case "deletefile":
                        deletefile(context);
                        break;
                    case "approvezhuangxiu":
                        approvezhuangxiu(context);
                        break;
                    case "confirmzhuangxiu":
                        confirmzhuangxiu(context);
                        break;
                    case "savexunjian":
                        savexunjian(context);
                        break;
                    case "saveyanshou":
                        saveyanshou(context);
                        break;
                    case "loadzhuangxiurulegrid":
                        loadzhuangxiurulegrid(context);
                        break;
                    case "removezhuangxiufule":
                        removezhuangxiufule(context);
                        break;
                    case "savezhuangxiurule":
                        savezhuangxiurule(context);
                        break;
                    case "getzhuangxiucategoryparams":
                        getzhuangxiucategoryparams(context);
                        break;
                    case "deletecomboboxzhuangxiucategory":
                        deletecomboboxzhuangxiucategory(context);
                        break;
                    case "savecomboboxzhuangxiucategory":
                        savecomboboxzhuangxiucategory(context);
                        break;
                    case "deletezhuangxiu":
                        deletezhuangxiu(context);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                Utility.LogHelper.WriteError(LogModule, "命令:" + visit, ex);
                context.Response.Write("{\"status\":false}");
            }
        }
        private void deletezhuangxiu(HttpContext context)
        {
            string IDs = context.Request["IDList"];
            List<int> IDList = new List<int>();
            if (!string.IsNullOrEmpty(IDs))
            {
                IDList = JsonConvert.DeserializeObject<List<int>>(IDs);
            }
            if (IDList.Count == 0)
            {
                WebUtil.WriteJson(context, new { status = false, error = "请选择装修记录" });
                return;
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    string cmdtext = "delete from [RoomFee] where ID in (select [RoomFeeID] from [ZhuangXiu] where ID in (" + string.Join(",", IDList.ToArray()) + "));";
                    cmdtext += "delete from [ZhuangXiu] where ID in (" + string.Join(",", IDList.ToArray()) + ")";
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    helper.Execute(cmdtext, CommandType.Text, parameters);
                    helper.Commit();
                    context.Response.Write("{\"status\":true}");
                }
                catch (Exception ex)
                {
                    Utility.LogHelper.WriteError(LogModule, "命令: deletezhuangxiu", ex);
                    helper.Rollback();
                    context.Response.Write("{\"status\":false}");
                }
            }
        }
        private void savecomboboxzhuangxiucategory(HttpContext context)
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
                Foresight.DataAccess.ZhuangXiu_Category category = null;
                if (item.id > 0)
                {
                    category = Foresight.DataAccess.ZhuangXiu_Category.GetZhuangXiu_Category(item.id);
                }
                if (category == null)
                {
                    category = new Foresight.DataAccess.ZhuangXiu_Category();
                    category.AddTime = DateTime.Now;
                }
                category.CategoryName = item.value;
                category.Save();
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void deletecomboboxzhuangxiucategory(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            var list = Foresight.DataAccess.ZhuangXiu_Rule.GetZhuangXiu_RuleListByParams(new int[] { ID });
            if (list.Length > 0)
            {
                WebUtil.WriteJson(context, new { status = false, msg = "任务类别使用中，禁止删除" });
                return;
            }
            Foresight.DataAccess.ZhuangXiu_Category.DeleteZhuangXiu_Category(ID);
            WebUtil.WriteJson(context, new { status = true });
        }
        private void getzhuangxiucategoryparams(HttpContext context)
        {
            var categorylist = Foresight.DataAccess.ZhuangXiu_Category.GetZhuangXiu_Categories().Select(p =>
            {
                var item = new { ID = p.ID, Name = p.CategoryName };
                return item;
            });
            WebUtil.WriteJson(context, new { status = true, category_list = categorylist });
        }
        private void savezhuangxiurule(HttpContext context)
        {
            Foresight.DataAccess.ZhuangXiu_Rule zhuangxiu_rule = null;
            int ID = 0;
            int.TryParse(context.Request.Params["ID"], out ID);
            if (ID > 0)
            {
                zhuangxiu_rule = Foresight.DataAccess.ZhuangXiu_Rule.GetZhuangXiu_Rule(ID);
            }
            if (zhuangxiu_rule == null)
            {
                zhuangxiu_rule = new Foresight.DataAccess.ZhuangXiu_Rule();
                zhuangxiu_rule.AddTime = DateTime.Now;
            }
            zhuangxiu_rule.RuleCategoryID = getIntValue(context, "tdRuleCategory");
            zhuangxiu_rule.RuleName = getValue(context, "tdRuleName");
            zhuangxiu_rule.RuleRequire = getValue(context, "tdRuleRequire");
            zhuangxiu_rule.Save();
            context.Response.Write("{\"status\":true}");
        }
        private void removezhuangxiufule(HttpContext context)
        {
            int ID = 0;
            int.TryParse(context.Request.Params["ID"], out ID);
            string IDs = context.Request["IDList"];
            List<int> IDList = new List<int>();
            if (!string.IsNullOrEmpty(IDs))
            {
                IDList = JsonConvert.DeserializeObject<List<int>>(IDs);
            }
            if (IDList.Count == 0)
            {
                WebUtil.WriteJson(context, new { status = true });
                return;
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    string cmdtext = "delete from [ZhuangXiu_Rule] where ID in (" + string.Join(",", IDList.ToArray()) + ")";
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    helper.Execute(cmdtext, CommandType.Text, parameters);
                    helper.Commit();
                    context.Response.Write("{\"status\":true}");
                }
                catch (Exception ex)
                {
                    Utility.LogHelper.WriteError(LogModule, "命令: removezhuangxiufule", ex);
                    helper.Rollback();
                    context.Response.Write("{\"status\":false}");
                }
            }
        }
        private void loadzhuangxiurulegrid(HttpContext context)
        {
            try
            {
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                string Keywords = context.Request.Params["Keywords"];
                DataGrid dg = Foresight.DataAccess.ZhuangXiu_Rule.GetZhuangXiu_RuleGridByKeywords(Keywords, "order by [AddTime] desc", startRowIndex, pageSize);
                var category_list = Foresight.DataAccess.ZhuangXiu_Category.GetZhuangXiu_Categories();
                var list = dg.rows as Foresight.DataAccess.ZhuangXiu_Rule[];
                var items = list.Select(p =>
                {
                    var dic = p.ToJsonObject();
                    var category = category_list.FirstOrDefault(q => q.ID == p.RuleCategoryID);
                    dic["CategoryName"] = category == null ? "" : category.CategoryName;
                    return dic;
                });
                dg.rows = items;
                string result = JsonConvert.SerializeObject(dg);
                context.Response.Write(result);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.WriteError(LogModule, "命令:loadzhuangxiurulegrid", ex);
                context.Response.Write("{\"rows\":[],\"total\":0,\"page\":0}");
            }
        }
        private void saveyanshou(HttpContext context)
        {
            Foresight.DataAccess.ZhuangXiu zhuangxiu = null;
            int ID = 0;
            int.TryParse(context.Request.Params["ID"], out ID);
            if (ID > 0)
            {
                zhuangxiu = Foresight.DataAccess.ZhuangXiu.GetZhuangXiu(ID);
            }
            zhuangxiu.YanShouTime = getTimeValue(context, "tdYanShouTime");
            zhuangxiu.YanShouMan = getValue(context, "tdYanShouMan");
            zhuangxiu.YanShouRemark = getValue(context, "tdYanShouRemark");
            zhuangxiu.Status = EnumModel.ZhuangXiuStatus.yanshou.ToString();
            List<Foresight.DataAccess.ZhuangXiu_File> attachlist = new List<Foresight.DataAccess.ZhuangXiu_File>();
            HttpFileCollection uploadFiles = context.Request.Files;
            for (int i = 0; i < uploadFiles.Count; i++)
            {
                HttpPostedFile postedFile = uploadFiles[i];
                string fileOriName = postedFile.FileName;
                if (fileOriName != "" && fileOriName != null)
                {
                    string extension = System.IO.Path.GetExtension(fileOriName).ToLower();
                    string fileName = DateTime.Now.ToFileTime().ToString() + extension;
                    string filepath = "/upload/ZhuangXiu/";
                    string rootPath = HttpContext.Current.Server.MapPath("~" + filepath);
                    if (!System.IO.Directory.Exists(rootPath))
                    {
                        System.IO.Directory.CreateDirectory(rootPath);
                    }
                    string Path = rootPath + fileName;
                    postedFile.SaveAs(Path);
                    Foresight.DataAccess.ZhuangXiu_File attach = new Foresight.DataAccess.ZhuangXiu_File();
                    attach.FileOriName = fileOriName;
                    attach.AttachedFilePath = filepath + fileName;
                    attach.AddTime = DateTime.Now;
                    attach.FileType = Utility.EnumModel.ZhuangXiuFileType.addyanshou.ToString();
                    attachlist.Add(attach);
                }
            }
            Foresight.DataAccess.RoomBasic room_basic = null;
            if (zhuangxiu.RoomID > 0)
            {
                room_basic = Foresight.DataAccess.RoomBasic.GetRoomBasicByRoomID(zhuangxiu.RoomID);
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    zhuangxiu.Save(helper);
                    foreach (var item in attachlist)
                    {
                        item.RelateID = zhuangxiu.ID;
                        item.Save(helper);
                    }
                    if (room_basic != null)
                    {
                        room_basic.ZxEndTime = zhuangxiu.YanShouTime;
                        room_basic.Save(helper);
                    }
                    helper.Commit();
                    context.Response.Write("{\"status\":true,\"ID\":" + zhuangxiu.ID + "}");
                }
                catch (Exception ex)
                {
                    Utility.LogHelper.WriteError(LogModule, "命令: saveyanshou", ex);
                    helper.Rollback();
                    context.Response.Write("{\"status\":false}");
                    return;
                }
            }
        }
        private void savexunjian(HttpContext context)
        {
            Foresight.DataAccess.ZhuangXiu zhuangxiu = null;
            int ID = 0;
            int.TryParse(context.Request.Params["ID"], out ID);
            if (ID > 0)
            {
                zhuangxiu = Foresight.DataAccess.ZhuangXiu.GetZhuangXiu(ID);
            }
            var xunjian = new Foresight.DataAccess.ZhuangXiu_XunJian();
            xunjian.AddMan = context.Request.Params["AddMan"];
            xunjian.AddTime = DateTime.Now;
            xunjian.ZhuangXiuID = zhuangxiu.ID;
            xunjian.XunJianTime = getTimeValue(context, "tdXunJianTime");
            xunjian.XunJianMan = getValue(context, "tdXunJianMan");
            xunjian.XunJianStatus = getValue(context, "XunJianStatus");
            if (xunjian.XunJianStatus.Equals("WeiGui"))
            {
                string WeiGuiRuleIDs = context.Request["WeiGuiRuleIDs"];
                List<int> WeiGuiRuleIDList = new List<int>();
                if (!string.IsNullOrEmpty(WeiGuiRuleIDs))
                {
                    WeiGuiRuleIDList = JsonConvert.DeserializeObject<List<int>>(WeiGuiRuleIDs);
                }
                if (WeiGuiRuleIDList.Count > 0)
                {
                    var weigui_list = Foresight.DataAccess.ZhuangXiu_Rule.GetZhuangXiu_RuleList(WeiGuiRuleIDList);
                    xunjian.WeiGuiProject = string.Join(",", weigui_list.Select(p => p.RuleName).ToArray());
                    xunjian.WeiGuiRuleID = WeiGuiRuleIDs;
                }

                xunjian.WeiGuiCost = getDecimalValue(context, "tdWeiGuiCost");
            }
            else
            {
                xunjian.WeiGuiCost = 0;
            }
            xunjian.Remark = getValue(context, "tdRemark");
            List<Foresight.DataAccess.ZhuangXiu_File> attachlist = new List<Foresight.DataAccess.ZhuangXiu_File>();
            HttpFileCollection uploadFiles = context.Request.Files;
            for (int i = 0; i < uploadFiles.Count; i++)
            {
                HttpPostedFile postedFile = uploadFiles[i];
                string fileOriName = postedFile.FileName;
                if (fileOriName != "" && fileOriName != null)
                {
                    string extension = System.IO.Path.GetExtension(fileOriName).ToLower();
                    string fileName = DateTime.Now.ToFileTime().ToString() + extension;
                    string filepath = "/upload/ZhuangXiu/";
                    string rootPath = HttpContext.Current.Server.MapPath("~" + filepath);
                    if (!System.IO.Directory.Exists(rootPath))
                    {
                        System.IO.Directory.CreateDirectory(rootPath);
                    }
                    string Path = rootPath + fileName;
                    postedFile.SaveAs(Path);
                    Foresight.DataAccess.ZhuangXiu_File attach = new Foresight.DataAccess.ZhuangXiu_File();
                    attach.FileOriName = fileOriName;
                    attach.AttachedFilePath = filepath + fileName;
                    attach.AddTime = DateTime.Now;
                    attach.FileType = Utility.EnumModel.ZhuangXiuFileType.addxunjian.ToString();
                    attachlist.Add(attach);
                }
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    xunjian.Save(helper);
                    foreach (var item in attachlist)
                    {
                        item.RelateID = xunjian.ID;
                        item.Save(helper);
                    }
                    helper.Commit();
                    context.Response.Write("{\"status\":true,\"ID\":" + xunjian.ID + "}");
                }
                catch (Exception ex)
                {
                    Utility.LogHelper.WriteError(LogModule, "命令: savexunjian", ex);
                    helper.Rollback();
                    context.Response.Write("{\"status\":false}");
                    return;
                }
            }
        }
        private void confirmzhuangxiu(HttpContext context)
        {
            string IDs = context.Request.Params["IDList"];
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(IDs);
            if (IDList.Count == 0)
            {
                WebUtil.WriteJson(context, new { status = false });
                return;
            }
            DateTime ConfirmZXTime = WebUtil.GetDateValue(context, "ZhuangXiuTime");
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    string cmdtext = "update [ZhuangXiu] set Status=@Status,ConfirmZXTime=@ConfirmZXTime where ID in (" + string.Join(",", IDList.ToArray()) + ");";
                    cmdtext += "update [RoomBasic] set ZxStartTime=@ConfirmZXTime where RoomID in (select RoomID from ZhuangXiu where ID in (" + string.Join(",", IDList.ToArray()) + "));";
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    parameters.Add(new SqlParameter("@Status", EnumModel.ZhuangXiuStatus.zhuangxiu.ToString()));
                    parameters.Add(new SqlParameter("@ConfirmZXTime", ConfirmZXTime));
                    helper.Execute(cmdtext, CommandType.Text, parameters);
                    helper.Commit();
                    context.Response.Write("{\"status\":true}");
                }
                catch (Exception ex)
                {
                    Utility.LogHelper.WriteError(LogModule, "命令: confirmzhuangxiu", ex);
                    helper.Rollback();
                    context.Response.Write("{\"status\":false}");
                }
            }
        }
        private void approvezhuangxiu(HttpContext context)
        {
            Foresight.DataAccess.ZhuangXiu zhuangxiu = null;
            string precontractstr = string.Empty;
            int ID = 0;
            int.TryParse(context.Request.Params["ID"], out ID);
            if (ID > 0)
            {
                zhuangxiu = Foresight.DataAccess.ZhuangXiu.GetZhuangXiu(ID);
            }
            var Approve = new Foresight.DataAccess.ZhuangXiu_Approve();
            Approve.AddMan = context.Request.Params["AddMan"];
            Approve.AddTime = DateTime.Now;
            Approve.ZhuangXiuID = zhuangxiu.ID;
            Approve.ApproveDesc = getValue(context, "tdApproveDesc");
            Approve.ApproveStatus = WebUtil.GetIntValue(context, "ApproveStatus") == 1 ? "通过" : "不通过";
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    Approve.Save(helper);
                    zhuangxiu.ApproveID = Approve.ID;
                    zhuangxiu.Status = WebUtil.GetIntValue(context, "ApproveStatus") == 1 ? EnumModel.ZhuangXiuStatus.shenpiyes.ToString() : EnumModel.ZhuangXiuStatus.shenpino.ToString();
                    zhuangxiu.Save(helper);
                    helper.Commit();
                    context.Response.Write("{\"status\":true,\"ID\":" + Approve.ID + "}");
                }
                catch (Exception ex)
                {
                    Utility.LogHelper.WriteError(LogModule, "命令: approvezhuangxiu", ex);
                    helper.Rollback();
                    context.Response.Write("{\"status\":false}");
                    return;
                }
            }
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
                    string cmdtext = "delete from [ZhuangXiu_File] where ID=@ID";
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    parameters.Add(new SqlParameter("@ID", ID));
                    helper.Execute(cmdtext, CommandType.Text, parameters);
                    helper.Commit();
                    context.Response.Write("{\"status\":true}");
                }
                catch (Exception ex)
                {
                    Utility.LogHelper.WriteError(LogModule, "命令: deletefile", ex);
                    helper.Rollback();
                    context.Response.Write("{\"status\":false}");
                }
            }
        }
        private void loadzhuangxiuattachs(HttpContext context)
        {
            int ID = int.Parse(context.Request.Params["ID"]);
            string FileType = context.Request.Params["FileType"];
            var list = Foresight.DataAccess.ZhuangXiu_File.GetZhuangXiu_FileAttachList(ID, FileType);
            var items = list.Select(p =>
            {
                var dic = p.ToJsonObject();
                dic["AttachedFilePath"] = string.IsNullOrEmpty(p.AttachedFilePath) ? string.Empty : WebUtil.GetContextPath() + p.AttachedFilePath;
                return dic;
            });
            context.Response.Write(JsonConvert.SerializeObject(items));
        }
        private void savezhuangxiu(HttpContext context)
        {
            Foresight.DataAccess.ZhuangXiu zhuangxiu = null;
            string precontractstr = string.Empty;
            int ID = 0;
            int.TryParse(context.Request.Params["ID"], out ID);
            int ProjectID = 0;
            int.TryParse(context.Request.Params["ProjectID"], out ProjectID);
            if (ID > 0)
            {
                zhuangxiu = Foresight.DataAccess.ZhuangXiu.GetZhuangXiu(ID);
            }
            if (zhuangxiu == null)
            {
                zhuangxiu = new Foresight.DataAccess.ZhuangXiu();
                zhuangxiu.AddTime = DateTime.Now;
                zhuangxiu.AddMan = context.Request.Params["AddMan"];
                zhuangxiu.Status = EnumModel.ZhuangXiuStatus.shenqing.ToString();
            }
            zhuangxiu.RoomID = ProjectID;
            zhuangxiu.ApplicationMan = getValue(context, "tdApplicationMan");
            zhuangxiu.PhoneNumber = getValue(context, "tdPhoneNumber");
            zhuangxiu.DepositPrice = getDecimalValue(context, "tdDepositPrice");
            zhuangxiu.ZhuangXiuType = getValue(context, "tdZhuangXiuType");
            zhuangxiu.TypeDesc = getValue(context, "tdTypeDesc");
            zhuangxiu.ChargeID = getIntValue(context, "tdChargeName");
            List<Foresight.DataAccess.ZhuangXiu_File> attachlist = new List<Foresight.DataAccess.ZhuangXiu_File>();
            HttpFileCollection uploadFiles = context.Request.Files;
            for (int i = 0; i < uploadFiles.Count; i++)
            {
                HttpPostedFile postedFile = uploadFiles[i];
                string fileOriName = postedFile.FileName;
                if (fileOriName != "" && fileOriName != null)
                {
                    string extension = System.IO.Path.GetExtension(fileOriName).ToLower();
                    string fileName = DateTime.Now.ToFileTime().ToString() + extension;
                    string filepath = "/upload/ZhuangXiu/";
                    string rootPath = HttpContext.Current.Server.MapPath("~" + filepath);
                    if (!System.IO.Directory.Exists(rootPath))
                    {
                        System.IO.Directory.CreateDirectory(rootPath);
                    }
                    string Path = rootPath + fileName;
                    postedFile.SaveAs(Path);
                    Foresight.DataAccess.ZhuangXiu_File attach = new Foresight.DataAccess.ZhuangXiu_File();
                    attach.FileOriName = fileOriName;
                    attach.AttachedFilePath = filepath + fileName;
                    attach.AddTime = DateTime.Now;
                    attach.FileType = Utility.EnumModel.ZhuangXiuFileType.addzhuangxiu.ToString();
                    attachlist.Add(attach);
                }
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    Foresight.DataAccess.RoomFee roomFee = null;
                    if (zhuangxiu.RoomID > 0 && zhuangxiu.ChargeID > 0)
                    {
                        if (zhuangxiu.RoomFeeID > 0)
                        {
                            roomFee = Foresight.DataAccess.RoomFee.GetRoomFee(zhuangxiu.RoomFeeID, helper);
                        }
                        if (roomFee == null)
                        {
                            roomFee = Foresight.DataAccess.RoomFee.SetInfo_RoomFee(zhuangxiu.RoomID, DateTime.MinValue, DateTime.MinValue, zhuangxiu.DepositPrice, zhuangxiu.DepositPrice, zhuangxiu.DepositPrice, zhuangxiu.ChargeID, Remark: "装修押金", OnlyOnceCharge: true, DefaultChargeManName: zhuangxiu.ApplicationMan, IsTempFee: true, cansave: true, helper: helper);
                        }
                        zhuangxiu.RoomFeeID = roomFee.ID;
                        zhuangxiu.Save(helper);
                    }
                    foreach (var item in attachlist)
                    {
                        item.RelateID = zhuangxiu.ID;
                        item.Save(helper);
                    }
                    helper.Commit();
                    context.Response.Write("{\"status\":true,\"ID\":" + zhuangxiu.ID + "}");
                }
                catch (Exception ex)
                {
                    Utility.LogHelper.WriteError(LogModule, "命令: savezhuangxiu", ex);
                    helper.Rollback();
                    context.Response.Write("{\"status\":false}");
                    return;
                }
            }
        }
        private void loadzhuangxiugrid(HttpContext context)
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
                DateTime StartTime = WebUtil.GetDateValue(context, "StartTime");
                DateTime EndTime = WebUtil.GetDateValue(context, "EndTime");
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                string Keywords = context.Request.Params["Keywords"];
                string Status = context.Request.Params["Status"];
                DataGrid dg = Foresight.DataAccess.ViewZhuangXiu.GetViewZhuangXiuGridByKeywords(Keywords, Status, RoomIDList, ProjectIDList, StartTime, EndTime, "order by [AddTime] desc", startRowIndex, pageSize, UserID: WebUtil.GetUser(context).UserID);
                string result = JsonConvert.SerializeObject(dg);
                context.Response.Write(result);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.WriteError(LogModule, "命令:loadzhuangxiugrid", ex);
                context.Response.Write("{\"rows\":[],\"total\":0,\"page\":0}");
            }
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
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
    }
}