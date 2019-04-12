using Foresight.DataAccess;
using Foresight.DataAccess.Framework;
using Foresight.DataAccess.Ui;

using System;
using System.Collections.Generic;
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
    /// RoomResourceHandler 的摘要说明
    /// </summary>
    public class RoomResourceHandler : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {

            context.Response.ContentType = "text/plain";
            string visit = context.Request.Params["visit"];
            if (string.IsNullOrEmpty(visit))
            {
                LogHelper.WriteDebug("RoomResourceHandler", "visit为空");
                context.Response.Write(null);
                return;
            }
            visit = visit.ToLower();
            try
            {
                switch (visit)
                {
                    case "loadroomresourcelist":
                        LoadRoomResourceList(context);
                        break;
                    case "saveroomresource":
                        SaveRoomResource(context);
                        break;
                    case "loadroomproperty":
                        LoadRoomProperty(context);
                        break;
                    case "loadroomresourceobj":
                        LoadRoomResourceObj(context);
                        break;
                    case "loadlrelatefamily":
                        LoadlRelateFamily(context);
                        break;
                    case "savefamily":
                        SaveFamily(context);
                        break;
                    case "deletefamily":
                        DeleteFamily(context);
                        break;
                    case "loadlrelateroomresource":
                        LoadlRelateRoomResource(context);
                        break;
                    case "addrelatesource":
                        AddRelateSource(context);
                        break;
                    case "loadchargesummarylist":
                        LoadChargeSummarylist(context);
                        break;
                    case "saveroomsourcefee":
                        SaveRoomSourceFee(context);
                        break;
                    case "deleteroomsourcefee":
                        DeleteRoomSourceFee(context);
                        break;
                    case "saveshowlevel":
                        SaveShowLevel(context);
                        break;
                    case "loadtablecolumn":
                        loadtablecolumn(context);
                        break;
                    case "savefamilyphoto":
                        savefamilyphoto(context);
                        break;
                    case "getroomstate":
                        getroomstate(context);
                        break;
                    case "saveroomstate":
                        saveroomstate(context);
                        break;
                    case "getroombasicparams":
                        getroombasicparams(context);
                        break;
                    case "savecomboboxroomstate":
                        savecomboboxroomstate(context);
                        break;
                    case "savecomboboxroomtype":
                        savecomboboxroomtype(context);
                        break;
                    case "savecomboboxroomproperty":
                        savecomboboxroomproperty(context);
                        break;
                    case "deletecomboboxroomstate":
                        deletecomboboxroomstate(context);
                        break;
                    case "deletecomboboxroomtype":
                        deletecomboboxroomtype(context);
                        break;
                    case "deletecomboboxroomproperty":
                        deletecomboboxroomproperty(context);
                        break;
                    case "checkrelation_contractstatus":
                        checkrelation_contractstatus(context);
                        break;
                    case "loadviewroomfeelistparams":
                        loadviewroomfeelistparams(context);
                        break;
                    default:
                        WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "Unkown Visit: " + visit);
                        break;
                }
            }
            catch (Exception ex)
            {
                Utility.LogHelper.WriteError("RoomResourceHandler", "命令:" + visit, ex);
                context.Response.Write("{\"status\":false}");
            }
        }
        private void loadviewroomfeelistparams(HttpContext context)
        {
            int CompanyID = WebUtil.GetCompanyID(context);
            List<int> FeeTypeList = new List<int>();
            ChargeSummary[] list = ChargeSummary.GetChargeSummaries().OrderBy(p => p.OrderBy).ToArray();
            var summary_items = list.Select(p =>
            {
                var results = new { ID = p.ID, Name = p.Name };
                return results;
            }).ToList();
            summary_items.Insert(0, new { ID = 0, Name = "全部" });
            var properties = Foresight.DataAccess.RoomProperty.GetRoomProperties();
            var property_items = properties.Select(p =>
            {
                var results = new { ID = p.ID, Name = p.Name };
                return results;
            }).ToList();
            property_items.Insert(0, new { ID = 0, Name = "全部" });
            var roomstates = Foresight.DataAccess.RoomState.GetRoomStates();
            var roomstate_items = roomstates.Select(p =>
            {
                var results = new { ID = p.ID, Name = p.Name };
                return results;
            }).ToList();
            roomstate_items.Insert(0, new { ID = 0, Name = "全部" });
            WebUtil.WriteJson(context, new { status = true, summaries = summary_items, properties = property_items, roomstates = roomstate_items });
        }
        private void checkrelation_contractstatus(HttpContext context)
        {
            string IDs = context.Request["IDList"];
            List<int> IDList = new List<int>();
            bool hascontract = false;
            if (!string.IsNullOrEmpty(IDs))
            {
                IDList = JsonConvert.DeserializeObject<List<int>>(IDs);
            }
            if (IDList.Count > 0)
            {
                var relation_list = Foresight.DataAccess.RoomPhoneRelation.GetRoomPhoneRelationsByIDList(IDList).Where(p => p.ContractID > 0).ToArray();
                foreach (var relation in relation_list)
                {
                    var contract_room = Foresight.DataAccess.Contract_Room.GetContract_RoomListByContractID(relation.ContractID).FirstOrDefault(p => p.RoomID == relation.RoomID);
                    if (contract_room != null)
                    {
                        hascontract = true;
                        break;
                    }
                }
            }
            WebUtil.WriteJson(context, new { status = true, hascontract = hascontract });
        }
        private void deletecomboboxroomproperty(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            var list = Foresight.DataAccess.RoomBasic.GetRoomBasicListByParams(null, null, new int[] { ID });
            if (list.Length > 0)
            {
                WebUtil.WriteJson(context, new { status = false, msg = "房源属性使用中，禁止删除" });
                return;
            }
            Foresight.DataAccess.RoomProperty.DeleteRoomProperty(ID);
            WebUtil.WriteJson(context, new { status = true });
        }
        private void deletecomboboxroomtype(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            var list = Foresight.DataAccess.RoomBasic.GetRoomBasicListByParams(null, new int[] { ID }, null);
            if (list.Length > 0)
            {
                WebUtil.WriteJson(context, new { status = false, msg = "房间类型使用中，禁止删除" });
                return;
            }
            Foresight.DataAccess.RoomType.DeleteRoomType(ID);
            WebUtil.WriteJson(context, new { status = true });
        }
        private void deletecomboboxroomstate(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            var list = Foresight.DataAccess.RoomBasic.GetRoomBasicListByParams(new int[] { ID }, null, null);
            if (list.Length > 0)
            {
                WebUtil.WriteJson(context, new { status = false, msg = "房间状态使用中，禁止删除" });
                return;
            }
            Foresight.DataAccess.RoomState.DeleteRoomState(ID);
            WebUtil.WriteJson(context, new { status = true });
        }
        private void savecomboboxroomproperty(HttpContext context)
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
                Foresight.DataAccess.RoomProperty roomproperty = null;
                if (item.id > 0)
                {
                    roomproperty = Foresight.DataAccess.RoomProperty.GetRoomProperty(item.id);
                }
                if (roomproperty == null)
                {
                    roomproperty = new RoomProperty();
                }
                roomproperty.Name = item.value;
                roomproperty.Save();
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void savecomboboxroomtype(HttpContext context)
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
                Foresight.DataAccess.RoomType roomtype = null;
                if (item.id > 0)
                {
                    roomtype = Foresight.DataAccess.RoomType.GetRoomType(item.id);
                }
                if (roomtype == null)
                {
                    roomtype = new RoomType();
                }
                roomtype.RoomTypeName = item.value;
                roomtype.Save();
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void savecomboboxroomstate(HttpContext context)
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
                Foresight.DataAccess.RoomState state = null;
                if (item.id > 0)
                {
                    state = Foresight.DataAccess.RoomState.GetRoomState(item.id);
                }
                if (state == null)
                {
                    state = new RoomState();
                }
                state.Name = item.value;
                state.Save();
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void getroombasicparams(HttpContext context)
        {
            var roomstate_list = Foresight.DataAccess.RoomState.GetRoomStates().OrderBy(p => p.SortOrder).OrderBy(p => p.ID).Select(p =>
            {
                var item = new { ID = p.ID, Name = p.Name };
                return item;
            });
            var roomtype_list = Foresight.DataAccess.RoomType.GetRoomTypes().OrderBy(p => p.SortOrder).OrderBy(p => p.ID).Select(p =>
            {
                var item = new { ID = p.ID, Name = p.RoomTypeName };
                return item;
            });
            var roomproperty_list = Foresight.DataAccess.RoomProperty.GetRoomProperties().OrderBy(p => p.SortOrder).OrderBy(p => p.ID).Select(p =>
            {
                var item = new { ID = p.ID, Name = p.Name };
                return item;
            });
            WebUtil.WriteJson(context, new { status = true, roomstate_list = roomstate_list, roomtype_list = roomtype_list, roomproperty_list = roomproperty_list });

        }
        private void saveroomstate(HttpContext context)
        {
            string roomstates = context.Request["roomstates"];
            List<Utility.RoomStateModel> list = new List<Utility.RoomStateModel>();
            if (!string.IsNullOrEmpty(roomstates))
            {
                list = JsonConvert.DeserializeObject<List<Utility.RoomStateModel>>(roomstates);
            }
            var roomstatelist = Foresight.DataAccess.RoomState.GetRoomStates();
            foreach (var item in list)
            {
                var data = roomstatelist.FirstOrDefault(p => p.Name.Equals(item.Name));
                if (data == null)
                {
                    continue;
                }
                data.BackColor = item.BackColor;
                data.Save();
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void getroomstate(HttpContext context)
        {
            var list = Foresight.DataAccess.RoomState.GetRoomStates().OrderBy(p => p.SortOrder).OrderBy(p => p.ID);
            var results = list.Select(p =>
            {
                var item = new { ID = p.ID, Name = p.Name, BackColor = p.BackColor };
                return item;
            });
            WebUtil.WriteJson(context, new { status = true, list = results });
        }
        private void savefamilyphoto(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            var relation = RoomPhoneRelation.GetRoomPhoneRelation(ID);
            HttpFileCollection uploadFiles = context.Request.Files;
            for (int i = 0; i < uploadFiles.Count; i++)
            {
                HttpPostedFile postedFile = uploadFiles[i];
                string fileOriName = postedFile.FileName;
                if (fileOriName != "" && fileOriName != null)
                {
                    string extension = System.IO.Path.GetExtension(fileOriName).ToLower();
                    string fileName = DateTime.Now.ToFileTime().ToString() + extension;
                    string filepath = "/upload/Family/";
                    string rootPath = HttpContext.Current.Server.MapPath("~" + filepath);
                    if (!System.IO.Directory.Exists(rootPath))
                    {
                        System.IO.Directory.CreateDirectory(rootPath);
                    }
                    string Path = rootPath + fileName;
                    postedFile.SaveAs(Path);
                    relation.HeadImg = filepath + fileName;
                    relation.Save();
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void loadtablecolumn(HttpContext context)
        {
            string pagecode = context.Request.Params["pagecode"];
            string TableName = context.Request.Params["TableName"];
            var list = Foresight.DataAccess.TableColumn.GetTableColumnByPageCode(pagecode, true);
            var results = new List<Dictionary<string, object>>();
            if (string.IsNullOrEmpty(TableName))
            {
                results = list.Select(p =>
                {
                    var dic = p.ToJsonObject();
                    dic["FieldID"] = 0;
                    return dic;
                }).ToList();
            }
            else
            {
                var all_fieldlist = Foresight.DataAccess.DefineField.GetDefineFieldsByTable_Name(TableName, 0);
                results = list.Select(p =>
               {
                   if (p.ColumnName.StartsWith("业主自定义"))
                   {
                       p.ColumnName = p.ColumnName.Replace("业主", "");
                   }
                   var exist_fieldlist = all_fieldlist.Where(q => !string.IsNullOrEmpty(q.ColumnName));
                   var exist_field = exist_fieldlist.FirstOrDefault(q => q.OriFieldName.Equals(p.ColumnName));
                   if (exist_field != null)
                   {
                       p.ColumnField = p.ColumnField.Replace(p.ColumnName, exist_field.FieldName);
                       p.ColumnName = exist_field.FieldName;
                   }
                   var dic = p.ToJsonObject();
                   dic["FieldID"] = 0;
                   return dic;
               }).ToList();

                var fieldlist = all_fieldlist.Where(p => string.IsNullOrEmpty(p.ColumnName) && p.IsShown);
                foreach (var item in fieldlist)
                {
                    var dic = new Dictionary<string, object>();
                    dic["ID"] = 0;
                    dic["FieldID"] = item.ID;
                    dic["PageCode"] = pagecode;
                    dic["ColumnField"] = "field: '" + item.FieldName + "', title: '" + item.FieldName + "', width: 150";
                    dic["SortOrder"] = item.SortOrder < 0 ? 0 : item.SortOrder;
                    dic["IsShown"] = item.IsShown;
                    dic["ColumnName"] = item.FieldName;
                    results.Add(dic);
                }
            }
            results = results.OrderBy(p => p["SortOrder"]).ToList();
            int ChargeID = 0;
            int.TryParse(context.Request.Params["ChargeID"], out ChargeID);
            Foresight.DataAccess.ChargeSummary chargesummary = null;
            if (ChargeID > 0)
            {
                chargesummary = ChargeSummary.GetChargeSummary(ChargeID);
            }
            StringBuilder columns = new StringBuilder("[[");
            foreach (var item in results)
            {
                if (chargesummary != null && !chargesummary.IsReading)
                {
                    if (!item["ColumnName"].Equals("表种类") && !item["ColumnName"].Equals("表名称") && !item["ColumnName"].Equals("上次读数") && !item["ColumnName"].Equals("本次读数"))
                    {
                        columns.Append("{" + item["ColumnField"] + "},");
                    }
                }
                else
                {
                    columns.Append("{" + item["ColumnField"] + "},");
                }
            }
            if (results.Count > 0)
            {
                columns.Remove(columns.Length - 1, 1);
            }
            columns.Append("]]");
            var items = new
            {
                status = results.Count > 0 ? true : false,
                columns = columns.ToString(),
            };
            context.Response.Write(JsonConvert.SerializeObject(items));
        }
        private void SaveShowLevel(HttpContext context)
        {
            int LevelID = int.Parse(context.Request.Params["LevelID"]);
            int CompanyID = int.Parse(context.Request.Params["CompanyID"]);
            var treeExpandLevel = Foresight.DataAccess.TreeExpandLevel.GetTreeExpandLevelByCompanyID(CompanyID);
            if (treeExpandLevel == null)
            {
                treeExpandLevel = new TreeExpandLevel();
                treeExpandLevel.CompanyID = CompanyID;
            }
            treeExpandLevel.LevelID = LevelID;
            treeExpandLevel.Save();
            context.Response.Write("{\"status\":true}");
        }
        private void DeleteRoomSourceFee(HttpContext context)
        {
            string IDs = context.Request.Params["IDList"];
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(IDs);
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    string cmdtext = "delete from [ImportFee] where ID in (select [ImportFeeID] from [RoomFee] where ID in(" + string.Join(" , ", IDList.ToArray()) + ")) and ChargeStatus!=1;";
                    cmdtext += "delete from [RoomFee] where ID in (" + string.Join(" , ", IDList.ToArray()) + ");";
                    cmdtext += "delete from [RoomFeeHistory] where ID in (" + string.Join(" , ", IDList.ToArray()) + ") and [ChargeState]=5";
                    helper.Execute(cmdtext, CommandType.Text, parameters);
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    Utility.LogHelper.WriteError("RoomResourceHandler", "命令:DeleteRoomSourceFee", ex);
                    context.Response.Write("{\"status\":false}");
                    WebUtil.WriteJson(context, new { status = false });
                    return;
                }
            }
            #region 删除日志
            var user = WebUtil.GetUser(context);
            APPCode.CommHelper.SaveOperationLog(string.Join(",", IDList.ToArray()), Utility.EnumModel.OperationModule.RoomFeeDelete.ToString(), "费项删除", user.UserID.ToString(), "RoomFee", user.LoginName, IsHide: true);
            APPCode.CommHelper.SaveOperationLog("用户" + user.LoginName + "删除了费项", Utility.EnumModel.OperationModule.RoomFeeDelete.ToString(), "费项删除", user.UserID.ToString(), "RoomFee", user.LoginName);
            #endregion
            WebUtil.WriteJson(context, new { status = true });
        }
        private void SaveRoomSourceFee(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            string op = context.Request.Params["op"];
            int ChargeSummaryID = WebUtil.GetIntValue(context, "ChargeSummaryID");
            int TypeID = WebUtil.GetIntValue(context, "TypeID");
            decimal UnitPrice = WebUtil.GetDecimalValue(context, "UnitPrice");
            DateTime StartTime = WebUtil.GetDateValue(context, "StartTime");
            DateTime EndTime = WebUtil.GetDateValue(context, "EndTime");
            DateTime NewEndTime = WebUtil.GetDateValue(context, "NewEndTime");
            string Remark = context.Request.Params["Remark"];
            RoomFee roomFee = RoomFee.GetRoomFee(ID);
            if (roomFee == null)
            {
                WebUtil.WriteJson(context, new { status = false, msg = "费项不存在" });
                return;
            }
            if (NewEndTime > DateTime.MinValue && EndTime > NewEndTime)
            {
                WebUtil.WriteJson(context, new { status = false, msg = "计费结束日期不能大于计费停用日期" });
                return;
            }
            Foresight.DataAccess.ChargeSummary chargesummary = null;
            if (roomFee.ContractDivideID > 0)
            {
                if ((StartTime > EndTime && EndTime > DateTime.MinValue) || (StartTime > EndTime && EndTime == DateTime.MinValue))
                {
                    WebUtil.WriteJson(context, new { status = false, msg = "计费开始日期不能大于计费结束日期" });
                    return;
                }
            }
            else
            {
                if ((StartTime > EndTime && EndTime > DateTime.MinValue) || (StartTime > EndTime && EndTime == DateTime.MinValue && chargesummary.EndTypeID != 3))
                {
                    WebUtil.WriteJson(context, new { status = false, msg = "计费开始日期不能大于计费结束日期" });
                    return;

                }
                chargesummary = Foresight.DataAccess.ChargeSummary.GetChargeSummary(ChargeSummaryID);
                if (chargesummary == null)
                {
                    WebUtil.WriteJson(context, new { status = false, msg = "收费项目不存在" });
                    return;
                }
            }
            if (op.Equals("edit"))
            {
                roomFee.ChargeID = ChargeSummaryID;
                roomFee.UnitPrice = UnitPrice;
                roomFee.StartTime = StartTime;
                roomFee.EndTime = EndTime;
                roomFee.NewEndTime = NewEndTime;
                roomFee.Remark = Remark;
                roomFee.Save();
                if (roomFee.ImportFeeID > 0)
                {
                    var importfee = Foresight.DataAccess.ImportFee.GetImportFee(roomFee.ImportFeeID);
                    if (importfee != null)
                    {
                        importfee.StartTime = roomFee.StartTime;
                        importfee.EndTime = roomFee.EndTime;
                        importfee.UnitPrice = roomFee.UnitPrice;
                        importfee.Save();
                    }
                }
                if (roomFee.ContractDivideID > 0)
                {
                    var divide = Foresight.DataAccess.Contract_Divide.GetContract_Divide(roomFee.ContractDivideID);
                    if (divide != null)
                    {
                        divide.StartTime = roomFee.StartTime;
                        divide.EndTime = roomFee.EndTime;
                        divide.Save();
                    }
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void LoadChargeSummarylist(HttpContext context)
        {
            ChargeSummary[] list = ChargeSummary.GetChargeSummaries().OrderBy(p => p.OrderBy).ToArray();
            var summary_items = list.Select(p =>
            {
                var results = new { ID = p.ID, Name = p.Name };
                return results;
            }).ToList();
            WebUtil.WriteJson(context, new { status = true, list = summary_items });
        }
        private void AddRelateSource(HttpContext context)
        {
            int RoomID = 0;
            int.TryParse(context.Request.Params["RoomID"], out RoomID);
            string IDs = context.Request.Params["IDList"];
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(IDs);
            context.Response.Write("{\"status\":true}");
        }
        private void LoadlRelateRoomResource(HttpContext context)
        {
            try
            {
                int RoomID = int.Parse(context.Request.Params["RoomID"]);
                string Keywords = context.Request.Params["Keywords"];
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                bool loadIn = bool.Parse(context.Request.Params["loadIn"]);
                DataGrid dg = ViewRoomBasic.GetProjectDetailsGridByRoomID(RoomID, loadIn, Keywords, "order by RoomID asc", startRowIndex, pageSize);
                string result = JsonConvert.SerializeObject(dg);
                context.Response.Write(result);

            }
            catch (Exception ex)
            {
                Utility.LogHelper.WriteError("RoomResourceHandler", "命令:LoadlRelateRoomResource", ex);
                context.Response.Write("{\"rows\":[],\"total\":0,\"page\":0}");
            }
        }
        private void DeleteFamily(HttpContext context)
        {
            string IDs = context.Request.Params["IDList"];
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(IDs);
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    string cmdtext = "delete from [RoomPhoneRelation] where ID in (" + string.Join(",", IDList.ToArray()) + ")";
                    helper.Execute(cmdtext, CommandType.Text, parameters);
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    Utility.LogHelper.WriteError("RoomResourceHandler", "命令:DeleteFamily", ex);
                    WebUtil.WriteJson(context, new { status = false });
                    return;
                }
            }
            #region 删除日志
            var user = WebUtil.GetUser(context);
            APPCode.CommHelper.SaveOperationLog(string.Join(",", IDList.ToArray()), Utility.EnumModel.OperationModule.RoomPhoneRelationDelete.ToString(), "住户删除", user.UserID.ToString(), "RoomPhoneRelation", user.LoginName, IsHide: true);
            APPCode.CommHelper.SaveOperationLog("用户" + user.LoginName + "删除了住户", Utility.EnumModel.OperationModule.RoomPhoneRelationDelete.ToString(), "住户删除", user.UserID.ToString(), "RoomPhoneRelation", user.LoginName);
            #endregion
            WebUtil.WriteJson(context, new { status = true });
        }
        private void SaveFamily(HttpContext context)
        {
            int ID = GetIntValue(context, "ID");
            int RoomID = GetIntValue(context, "RoomID");
            string name = context.Request.Params["name"];
            string phone = context.Request.Params["phone"];
            string RelateIDCard = context.Request.Params["RelateIDCard"];
            bool IsDefault = GetIntValue(context, "IsDefault") == 1 ? true : false;
            string RelationType = context.Request.Params["RelationType"];
            int IDCardType = GetIntValue(context, "IDCardType");
            DateTime Birthday = GetDateValue(context, "Birthday");
            string EmailAddress = context.Request.Params["EmailAddress"];
            string HomeAddress = context.Request.Params["HomeAddress"];
            string OfficeAddress = context.Request.Params["OfficeAddress"];
            string BankName = context.Request.Params["BankName"];
            string BankAccountName = context.Request.Params["BankAccountName"];
            string BankNo = context.Request.Params["BankNo"];
            string CustomOne = context.Request.Params["CustomOne"];
            string CustomTwo = context.Request.Params["CustomTwo"];
            string CustomThree = context.Request.Params["CustomThree"];
            string CustomFour = context.Request.Params["CustomFour"];
            string Remark = context.Request.Params["Remark"];
            bool IsChargeFee = GetIntValue(context, "IsChargeFee") == 1 ? true : false;
            string RelationProperty = context.Request.Params["RelationProperty"];
            bool IsChargeMan = GetIntValue(context, "IsChargeMan") == 1 ? true : false;
            IsChargeFee = IsChargeMan ? IsChargeFee : false;
            RoomPhoneRelation relation = new RoomPhoneRelation();
            if (ID > 0)
            {
                relation = RoomPhoneRelation.GetRoomPhoneRelation(ID);
            }
            else
            {
                relation.RoomID = RoomID;
            }
            relation.RelatePhoneNumber = phone;
            relation.RelationName = name;
            relation.RelationIDCard = RelateIDCard;
            relation.RelationType = RelationType;
            string cmdtext = string.Empty;
            if (!IsDefault)
            {
                if (relation.RelationType.Equals(RelationTypeDefine.homefamily.ToString()))
                {
                    cmdtext += "update [RoomBasic] set [RoomOwner]='',[OwnerPhone]='',[OwnerIDCard]='' where [RoomID]=@RoomID;";
                }
                else if (relation.RelationType.Equals(RelationTypeDefine.rentfamily.ToString()))
                {
                    cmdtext += "update [RoomBasic] set [RentName]='',[RentPhoneNumber]='',[RentIDCard]='' where [RoomID]=@RoomID;";
                }
            }
            if (IsDefault)
            {
                cmdtext += "update [RoomPhoneRelation] set [IsDefault]=0 where RoomID=@RoomID and ID!=@RelationID;";
                if (relation.RelationType.Equals(RelationTypeDefine.homefamily.ToString()))
                {
                    cmdtext += "update [RoomBasic] set [RoomOwner]=@RoomOwner,[OwnerPhone]=@OwnerPhone,[OwnerIDCard]=@OwnerIDCard,[RentName]='',[RentPhoneNumber]='',[RentIDCard]='' where [RoomID]=@RoomID;";
                }
                else if (relation.RelationType.Equals(RelationTypeDefine.rentfamily.ToString()))
                {
                    cmdtext += "update [RoomBasic] set [RoomOwner]='',[OwnerPhone]='',[OwnerIDCard]='', [RentName]=@RoomOwner,[RentPhoneNumber]=@OwnerPhone,[RentIDCard]=@OwnerIDCard where [RoomID]=@RoomID;";
                }
            }
            relation.IsDefault = IsDefault;
            if (IsChargeFee)
            {
                cmdtext += "update [RoomPhoneRelation] set [IsChargeFee]=0 where RoomID=@RoomID and ID!=@RelationID;";
            }
            relation.IsChargeFee = IsChargeFee;
            relation.IsChargeMan = IsChargeMan;
            relation.RelationProperty = RelationProperty;
            relation.IDCardType = IDCardType;
            relation.Birthday = Birthday;
            relation.EmailAddress = EmailAddress;
            relation.HomeAddress = HomeAddress;
            relation.OfficeAddress = OfficeAddress;
            relation.BankName = BankName;
            relation.BankAccountName = BankAccountName;
            relation.BankAccountNo = BankNo;
            relation.CustomOne = CustomOne;
            relation.CustomTwo = CustomTwo;
            relation.CustomThree = CustomThree;
            relation.CustomFour = CustomFour;
            relation.Remark = Remark;
            relation.ContractStartTime = GetDateValue(context, "ContractStartTime");
            relation.ContractEndTime = GetDateValue(context, "ContractEndTime");
            relation.BrandInfo = context.Request.Params["BrandInfo"];
            relation.ContractNote = context.Request.Params["ContractNote"];
            relation.Interesting = context.Request.Params["Interesting"];
            relation.ConsumeMore = context.Request.Params["ConsumeMore"];
            relation.BelongTeam = context.Request.Params["BelongTeam"];
            relation.OneCardNumber = context.Request.Params["OneCardNumber"];
            relation.ChargeForMan = context.Request.Params["ChargeForMan"];
            relation.CompanyName = context.Request["CompanyName"];
            relation.TaxpayerNumber = context.Request["TaxpayerNumber"];
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    if (!string.IsNullOrEmpty(cmdtext))
                    {
                        List<SqlParameter> parameters = new List<SqlParameter>();
                        parameters.Add(new SqlParameter("@RoomID", relation.RoomID));
                        parameters.Add(new SqlParameter("@RoomOwner", relation.RelationName));
                        parameters.Add(new SqlParameter("@OwnerPhone", relation.RelatePhoneNumber));
                        parameters.Add(new SqlParameter("@OwnerIDCard", relation.RelationIDCard));
                        parameters.Add(new SqlParameter("@RelationID", relation.ID > 0 ? relation.ID : 0));
                        helper.Execute(cmdtext, CommandType.Text, parameters);
                    }
                    relation.Save(helper);
                    helper.Commit();
                    context.Response.Write("{\"status\":true,\"ID\":" + relation.ID + "}");
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    Utility.LogHelper.WriteError("RoomResourceHandler", "命令:SaveFamily", ex);
                    context.Response.Write("{\"status\":false}");
                }
            }
        }
        private void LoadlRelateFamily(HttpContext context)
        {
            try
            {
                int RoomID = WebUtil.GetIntValue(context, "RoomID");
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                string RelationType = context.Request.Params["RelationType"];
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                string ProjectIDs = context.Request.Params["ProjectIDs"];
                string RoomIDs = context.Request.Params["RoomIDs"];
                List<int> RoomIDList = new List<int>();
                if (!string.IsNullOrEmpty(RoomIDs))
                {
                    RoomIDList = JsonConvert.DeserializeObject<List<int>>(RoomIDs);
                }
                if (RoomID > 0)
                {
                    RoomIDList.Add(RoomID);
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
                bool IsContractUser = WebUtil.GetBoolValue(context, "IsContractUser");
                bool IsProjectUser = WebUtil.GetBoolValue(context, "IsProjectUser");
                DataGrid dg = RoomPhoneRelation.GetRoomPhoneRelationGridByRoomID(ProjectIDList, RoomIDList, RelationType, "order by ID asc", startRowIndex, pageSize, IsContractUser, IsProjectUser);
                string result = JsonConvert.SerializeObject(dg);
                context.Response.Write(result);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.WriteError("RoomResourceHandler", "命令:LoadlRelateFamily", ex);
                context.Response.Write("{\"rows\":[],\"total\":0,\"page\":0}");
            }
        }
        private void LoadRoomResourceObj(HttpContext context)
        {
            int RoomID = WebUtil.GetIntValue(context, "RoomID");
            int ContractID = WebUtil.GetIntValue(context, "ContractID");
            var roomBasic = RoomBasic.GetRoomBasicByRoomID(RoomID);
            var relation_list = RoomPhoneRelation.GetRoomPhoneRelationsByRoomID(RoomID).Where(p => (p.IsChargeMan || p.IsChargeFee));
            var roomPhoneRelation = relation_list.FirstOrDefault(p => p.IsChargeFee);
            var project = Project.GetProject(RoomID);
            string RelationName = string.Empty;
            string results = string.Empty;
            var note_list = Foresight.DataAccess.RoomFee_Note.GetRoomFee_NoteListByRoomID(RoomID);
            if (ContractID > 0)
            {
                var contract = Foresight.DataAccess.Contract.GetContract(ContractID);
                var RelationNameList = new List<object>();
                if (contract != null && !string.IsNullOrEmpty(contract.ContractName))
                {
                    RelationNameList.Add(new { ID = 0, RelationName = contract.RentName, RelationTypeDesc = "客户" });
                }
                var item = new
                {
                    Name = project.Name,
                    RelatePhoneNumber = contract == null ? "" : contract.ContractPhone,
                    RelationNameID = 0,
                    RelationName = contract == null ? "" : contract.RentName,
                    BuildingArea = roomBasic == null ? 0 : roomBasic.BuildingArea,
                    RoomStateID = roomBasic == null ? 0 : (roomBasic.RoomStateID > 0 ? roomBasic.RoomStateID : 0),
                    RelationTypeDesc = "客户",
                    RelationNameList = RelationNameList
                };
                WebUtil.WriteJson(context, new { status = true, data = item, notecount = note_list.Length });
                return;
            }
            else
            {
                var item = new
                {
                    Name = project.Name,
                    RelatePhoneNumber = roomPhoneRelation == null ? "" : roomPhoneRelation.RelatePhoneNumber,
                    RelationNameID = roomPhoneRelation == null ? 0 : roomPhoneRelation.ID,
                    RelationName = roomPhoneRelation == null ? "" : roomPhoneRelation.RelationName,
                    BuildingArea = roomBasic == null ? 0 : roomBasic.BuildingArea,
                    RoomStateID = roomBasic == null ? 0 : (roomBasic.RoomStateID > 0 ? roomBasic.RoomStateID : 0),
                    RelationTypeDesc = roomPhoneRelation == null ? "" : roomPhoneRelation.RelationTypeDesc,
                    RelationNameList = relation_list.Select(p =>
                    {
                        return new { ID = p.ID, RelationName = p.RelationName, RelatePhoneNumber = p.RelatePhoneNumber, RelationTypeDesc = p.RelationTypeDesc };
                    })
                };
                WebUtil.WriteJson(context, new { status = true, data = item, notecount = note_list.Length });
                return;
            }
        }
        private void LoadRoomProperty(HttpContext context)
        {
            try
            {
                RoomProperty[] property = RoomProperty.GetRoomProperties().ToArray();
                string result = JsonConvert.SerializeObject(property);
                context.Response.Write("{\"status\":true,\"list\":" + result + "}");
            }
            catch (Exception ex)
            {
                Utility.LogHelper.WriteError("RoomResourceHandler", "命令:LoadRoomProperty", ex);
                context.Response.Write("{\"status\":false,\"list\":[]}");
            }
        }
        private void SaveRoomResource(HttpContext context)
        {
            int RoomID = WebUtil.GetIntValue(context, "RoomID");
            Project project = Project.GetProject(RoomID);
            if (project == null)
            {
                WebUtil.WriteJson(context, new { status = false, msg = "房间不存在" });
                return;
            }
            RoomBasic basic = RoomBasic.GetRoomBasicByRoomID(RoomID);
            string list = context.Request["FieldList"];
            List<Utility.BasicModel> ModelList = JsonConvert.DeserializeObject<List<Utility.BasicModel>>(list);
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    project.Name = context.Request.Params["RoomName"];
                    int SortOrder = WebUtil.GetIntValue(context, "SortOrder");
                    if (!string.IsNullOrEmpty(project.DefaultOrder))
                    {
                        string NewDefaultOrder = string.Empty;
                        string[] SortOrderArray = project.DefaultOrder.Split('-');
                        for (int i = 0; i < SortOrderArray.Length; i++)
                        {
                            if (i != SortOrderArray.Length - 1)
                            {
                                NewDefaultOrder += SortOrderArray[i] + "-";
                            }
                            else
                            {
                                NewDefaultOrder += SortOrder.ToString("D3");
                            }
                        }
                        project.DefaultOrder = NewDefaultOrder;
                    }
                    project.Save(helper);
                    if (basic == null)
                    {
                        basic = new RoomBasic();
                        basic.RoomID = project.ID;
                        basic.AddTime = DateTime.Now;
                    }
                    basic.RoomState = context.Request.Params["RoomState"];
                    basic.RoomStateID = WebUtil.GetIntValue(context, "RoomStateID");
                    basic.BuildingArea = GetDecimalValue(context, "BuildingArea");
                    basic.ContractArea = GetDecimalValue(context, "ContractArea");
                    basic.PaymentTime = GetDateValue(context, "PaymentTime");
                    basic.MoveInTime = GetDateValue(context, "MoveInTime");
                    basic.ZxStartTime = GetDateValue(context, "ZxStartTime");
                    basic.ZxEndTime = GetDateValue(context, "ZxEndTime");
                    basic.RoomType = context.Request.Params["RoomType"];
                    basic.RoomTypeID = WebUtil.GetIntValue(context, "RoomTypeID");
                    basic.BuildingNumber = context.Request.Params["BuildingNumber"];
                    basic.BuildOutArea = GetDecimalValue(context, "BuildOutArea");
                    basic.BuildInArea = GetDecimalValue(context, "BuildInArea");
                    basic.GonTanArea = GetDecimalValue(context, "GonTanArea");
                    basic.ChanQuanArea = GetDecimalValue(context, "ChanQuanArea");
                    basic.UseArea = GetDecimalValue(context, "UseArea");
                    basic.PeiTaoArea = GetDecimalValue(context, "PeiTaoArea");
                    basic.FunctionCoefficient = GetDecimalValue(context, "FunctionCoefficient");
                    basic.FenTanCoefficient = GetDecimalValue(context, "FenTanCoefficient");
                    basic.ChanQuanNo = context.Request.Params["ChanQuanNo"];
                    basic.CertificateTime = GetDateValue(context, "CertificateTime");
                    basic.RoomLayout = context.Request.Params["RoomLayout"];
                    basic.RoomProperty = context.Request.Params["RoomProperty"];
                    basic.RoomPropertyID = WebUtil.GetIntValue(context, "RoomPropertyID");
                    basic.CustomOne = context.Request.Params["CustomOne"];
                    basic.CustomTwo = context.Request.Params["CustomTwo"];
                    basic.CustomThree = context.Request.Params["CustomThree"];
                    basic.CustomFour = context.Request.Params["CustomFour"];
                    basic.Remark = context.Request.Params["Remark"];
                    basic.IsLocked = GetIntValue(context, "IsLocked") == 1 ? true : false;
                    basic.Save(helper);
                    if (ModelList.Count > 0)
                    {
                        foreach (var item in ModelList)
                        {
                            if (item.id <= 0)
                            {
                                continue;
                            }
                            var roombasic_field = RoomBasicField.GetRoomBasicFieldByRoomIDandFieldID(RoomID, item.id, helper);
                            if (roombasic_field == null)
                            {
                                roombasic_field = new RoomBasicField();
                                roombasic_field.AddTime = DateTime.Now;
                            }
                            roombasic_field.RoomID = RoomID;
                            roombasic_field.FieldID = item.id;
                            roombasic_field.FieldContent = item.value;
                            roombasic_field.Save(helper);
                        }
                    }
                    helper.Commit();
                    context.Response.Write("{\"status\":true}");
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    Utility.LogHelper.WriteError("RoomResourceHandler", "命令:SaveRoomResource", ex);
                    context.Response.Write("{\"status\":false}");
                }
            }

        }
        private void LoadRoomResourceList(HttpContext context)
        {
            try
            {
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                string ProjectID = context.Request.Params["ProjectID"];
                string RoomID = context.Request.Params["RoomID"];
                List<int> RoomIDList = new List<int>();
                if (!string.IsNullOrEmpty(RoomID))
                {
                    RoomIDList = JsonConvert.DeserializeObject<List<int>>(RoomID);
                }
                List<int> ProjectIDList = new List<int>();
                if (RoomIDList.Count == 0)
                {
                    if (!string.IsNullOrEmpty(ProjectID))
                    {
                        ProjectIDList = JsonConvert.DeserializeObject<List<int>>(ProjectID).Where(p => p != 1).ToList();
                    }
                    ProjectIDList = WebUtil.GetMyProjects(WebUtil.GetUser(context).UserID, ProjectIDList).Where(p => p.ID != 1).Select(p => p.ID).ToList();
                }
                string OwnerName = context.Request.Params["OwnerName"];
                string OwnerPhoneNumber = context.Request.Params["OwnerPhoneNumber"];
                string Keywords = context.Request.Params["Keywords"];
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                string SearchAreas = context.Request.Params["SearchAreas"];
                List<string> SearchAreaList = new List<string>();
                if (!string.IsNullOrEmpty(SearchAreas))
                {
                    SearchAreaList = JsonConvert.DeserializeObject<List<string>>(SearchAreas);
                }
                bool canexport = WebUtil.GetBoolValue(context, "canexport");
                DataGrid dg = ViewRoomBasic.GetRoomBasicListByKeywords(RoomIDList, ProjectIDList, OwnerName, OwnerPhoneNumber, Keywords, SearchAreaList, "order by DefaultOrder asc", startRowIndex, pageSize, canexport: canexport);
                if (canexport)
                {
                    string downloadurl = string.Empty;
                    string error = string.Empty;
                    bool status = APPCode.ExportHelper.DownLoadRoomSourceData(dg, out downloadurl, out error);
                    WebUtil.WriteJson(context, new { status = status, downloadurl = downloadurl, error = error });
                }
                else
                {
                    WebUtil.WriteJson(context, dg);
                }
            }
            catch (Exception ex)
            {
                Utility.LogHelper.WriteError("RoomResourceHandler", "命令:LoadRoomResourceList", ex);
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
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}