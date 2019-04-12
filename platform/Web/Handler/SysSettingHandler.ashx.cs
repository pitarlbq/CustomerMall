using Foresight.DataAccess;
using Foresight.DataAccess.Ui;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Foresight.DataAccess.Framework;
using System.Data.SqlClient;
using System.Data;
using Utility;
using System.Web.SessionState;
using Web.Model;

namespace Web.Handler
{
    /// <summary>
    /// SysSettingHandler 的摘要说明
    /// </summary>
    public class SysSettingHandler : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string visit = context.Request.Params["visit"];
            if (string.IsNullOrEmpty(visit))
            {
                LogHelper.WriteDebug("SysSettingHandler", "visit为空");
                context.Response.Write(null);
                return;
            }
            visit = visit.ToLower();
            try
            {
                switch (visit)
                {
                    case "loadchargemoneytype":
                        loadchargemoneytype(context);
                        break;
                    case "savechargemoneytype":
                        savechargemoneytype(context);
                        break;
                    case "deletechargemoneytype":
                        deletechargemoneytype(context);
                        break;
                    case "loadordernumberlist":
                        loadordernumberlist(context);
                        break;
                    case "saveordernumber":
                        saveordernumber(context);
                        break;
                    case "deleteordernumber":
                        deleteordernumber(context);
                        break;
                    case "gettablefield":
                        gettablefield(context);
                        break;
                    case "savetablefield":
                        savetablefield(context);
                        break;
                    case "savesysconfig":
                        savesysconfig(context);
                        break;
                    case "loadpricerangegrid":
                        loadpricerangegrid(context);
                        break;
                    case "savepricerange":
                        savepricerange(context);
                        break;
                    case "deletepricerange":
                        deletepricerange(context);
                        break;
                    case "loadchargebiaogrid":
                        loadchargebiaogrid(context);
                        break;
                    case "savechargebiao":
                        savechargebiao(context);
                        break;
                    case "deletechargebiao":
                        deletechargebiao(context);
                        break;
                    case "getmaxpricevalue":
                        getmaxpricevalue(context);
                        break;
                    case "loadtopyt":
                        loadtopyt(context);
                        break;
                    case "savetopyt":
                        savetopyt(context);
                        break;
                    case "loadchargediscount":
                        loadchargediscount(context);
                        break;
                    case "savechargediscount":
                        savechargediscount(context);
                        break;
                    case "deletechargediscount":
                        deletechargediscount(context);
                        break;
                    case "getdefinefield":
                        getdefinefield(context);
                        break;
                    case "savedefinefield":
                        savedefinefield(context);
                        break;
                    case "removedefinefield":
                        removedefinefield(context);
                        break;
                    case "getdefinecontent":
                        getdefinecontent(context);
                        break;
                    case "getchargetablefield":
                        getchargetablefield(context);
                        break;
                    case "savechargetablefield":
                        savechargetablefield(context);
                        break;
                    case "loadversiongrid":
                        loadversiongrid(context);
                        break;
                    case "removeversions":
                        removeversions(context);
                        break;
                    case "savesiteversion":
                        savesiteversion(context);
                        break;
                    case "removeversionfile":
                        removeversionfile(context);
                        break;
                    case "getupgradesiteparams":
                        getupgradesiteparams(context);
                        break;
                    case "getsysmanualtree":
                        getsysmanualtree(context);
                        break;
                    case "savesysmanualcategory":
                        savesysmanualcategory(context);
                        break;
                    case "removesysmanualcategory":
                        removesysmanualcategory(context);
                        break;
                    case "getsysmanualgrid":
                        getsysmanualgrid(context);
                        break;
                    case "savesysmanual":
                        savesysmanual(context);
                        break;
                    case "removesysmanual":
                        removesysmanual(context);
                        break;
                    case "getsysmenucategorylist":
                        getsysmenucategorylist(context);
                        break;
                    case "cleardata":
                        cleardata(context);
                        break;
                    case "getsysmenus":
                        getsysmenus(context);
                        break;
                    case "getmenubyid":
                        getmenubyid(context);
                        break;
                    case "savesysmenu":
                        savesysmenu(context);
                        break;
                    case "deletesysmenuimg":
                        deletesysmenuimg(context);
                        break;
                    case "deletesysmenus":
                        deletesysmenus(context);
                        break;
                    case "getmymenus":
                        getmymenus(context);
                        break;
                    case "getappversionbyapptype":
                        getappversionbyapptype(context);
                        break;
                    case "getmonthfeeanalysisfield":
                        getmonthfeeanalysisfield(context);
                        break;
                    case "savemonthfeeanalysistablefield":
                        savemonthfeeanalysistablefield(context);
                        break;
                    case "savewechatchatconfig":
                        savewechatchatconfig(context);
                        break;
                    case "loadwechatrequestgrid":
                        loadwechatrequestgrid(context);
                        break;
                    case "getsysconfiglist":
                        getsysconfiglist(context);
                        break;
                    case "getallmymenus":
                        getallmymenus(context);
                        break;
                    default:
                        WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "Unkown Visit: " + visit);
                        break;
                }
            }
            catch (Exception ex)
            {
                Utility.LogHelper.WriteError("SysSettingHandler", "命令:" + visit, ex);
                context.Response.Write("{\"status\":false}");
            }
        }
        private void getallmymenus(HttpContext context)
        {
            string[] modulecodes = WebUtil.GetModuleCodes(context);
            var modules = SysMenu.GetSysMenus().Where(p => modulecodes.Contains(p.ModuleCode) && (!p.IsAuthority || !string.IsNullOrEmpty(p.Url))).OrderBy(p => p.SortOrder).ThenBy(p => p.ID).ToArray();
            string context_path = WebUtil.getApplicationPath();
            WebUtil.WriteJson(context, new
            {
                status = true,
                list = APPCode.HandlerHelper.GetMyMenuTree(modules, 0, context_path)
            });
        }
        private void getsysconfiglist(HttpContext context)
        {
            int ProjectID = WebUtil.GetIntValue(context, "ProjectID");
            var list = SysConfig.Get_SysConfigList(ProjectID: ProjectID);
            string CouZheng = SysConfig.GetSysConfigValueByName(list, SysConfigNameDefine.RealCostCouZhengOn);
            string ContractWarning = SysConfig.GetSysConfigValueByName(list, SysConfigNameDefine.ContractWarning);
            string WeixinChargeMan = SysConfig.GetSysConfigValueByName(list, SysConfigNameDefine.WeixinChargeMan);
            string HideCuiShouCustomerName = SysConfig.GetSysConfigValueByName(list, SysConfigNameDefine.HideCuiShouCustomerName);
            string WechatFeeNotify = SysConfig.GetSysConfigValueByName(list, SysConfigNameDefine.WechatFeeNotify);
            string WechatFeeNotifyTime = SysConfig.GetSysConfigValueByName(list, SysConfigNameDefine.WechatFeeNotifyTime);
            WebUtil.WriteJson(context, new { status = true, CouZheng = CouZheng, ContractWarning = ContractWarning, WeixinChargeMan = WeixinChargeMan, HideCuiShouCustomerName = HideCuiShouCustomerName, WechatFeeNotify = WechatFeeNotify, WechatFeeNotifyTime = WechatFeeNotifyTime });
        }
        private void loadwechatrequestgrid(HttpContext context)
        {
            try
            {
                string Keywords = context.Request.Params["keywords"];
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                DateTime StartTime = WebUtil.GetDateValue(context, "StartTime");
                DateTime EndTime = WebUtil.GetDateValue(context, "EndTime");
                DataGrid dg = Wechat_ChatRequestDetail.GetWechat_ChatRequestDetailGridByKeywords(Keywords, StartTime, EndTime, "order by AddTime desc", startRowIndex, pageSize);
                WebUtil.WriteJson(context, dg);
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("SysSettingHandler.ashx", "loadwechatrequestgrid", ex);
                WebUtil.WriteJson(context, new Foresight.DataAccess.Ui.DataGrid());
                return;
            }
        }
        private void savewechatchatconfig(HttpContext context)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            var syslist = Foresight.DataAccess.SysConfig.GetSysConfigs().ToArray();
            string ConfigName = Foresight.DataAccess.SysConfigNameDefine.WechatChatStartTime.ToString();
            string Value = WebUtil.getServerValue(context, "tdWechatChatStartTime");
            SysConfig.SaveSysConfigByType(syslist, ConfigName, Value);
            dic["chatServiceStartTime"] = Value;

            ConfigName = Foresight.DataAccess.SysConfigNameDefine.WechatChatEndTime.ToString();
            Value = WebUtil.getServerValue(context, "tdWechatChatEndTime");
            SysConfig.SaveSysConfigByType(syslist, ConfigName, Value);
            dic["chatServiceEndTime"] = Value;

            ConfigName = Foresight.DataAccess.SysConfigNameDefine.WechatChatNotWorkMsg.ToString();
            Value = WebUtil.getServerValue(context, "tdWechatChatNotWorkMsg");
            SysConfig.SaveSysConfigByType(syslist, ConfigName, Value);
            dic["chatServiceNotWorkMsg"] = Value;

            ConfigName = Foresight.DataAccess.SysConfigNameDefine.WechatChatLeaveMsg.ToString();
            Value = WebUtil.getServerValue(context, "tdWechatChatLeaveMsg");
            SysConfig.SaveSysConfigByType(syslist, ConfigName, Value);
            dic["chatServiceWorkMsg"] = Value;
            string VirName = WebUtil.GetVirName();
            Wechat_ChatRequest.SaveWechat_Config_Path(VirName, dic);
            WebUtil.WriteJson(context, new { status = true });
        }
        private void savemonthfeeanalysistablefield(HttpContext context)
        {
            string Liststr = context.Request.Params["List"];
            string PageCode = Utility.EnumModel.AnalysisChargeFieldPageCode.MonthFeeAnalysis.ToString();
            List<Dictionary<string, object>> List = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(Liststr);
            var summary_list = Foresight.DataAccess.AnalysisChargeField.GetMonthFeeAnalysisColumns().ToArray();
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    for (int i = 0; i < summary_list.Length; i++)
                    {
                        int ChargeID = summary_list[i].ID;
                        var chargefield = summary_list[i];
                        chargefield.IsHide = true;
                        chargefield.IsHideTotal = true;
                        chargefield.IsHideReal = true;
                        chargefield.IsHideRest = true;
                        chargefield.IsHideDiscount = true;
                        chargefield.IsHideChargeFee = true;
                        foreach (var dic in List)
                        {
                            int dic_id = Convert.ToInt32(dic["ID"]);
                            if (dic_id == ChargeID)
                            {
                                if (dic["FieldType"].ToString().Equals("summary"))
                                {
                                    chargefield.IsHide = false;
                                    chargefield.SortOrder = Convert.ToInt32(dic["SortOrder"]);
                                }
                                if (dic["FieldType"].ToString().Equals("total"))
                                {
                                    chargefield.IsHideTotal = false;
                                    chargefield.SortOrder = Convert.ToInt32(dic["SortOrder"]);
                                }
                                if (dic["FieldType"].ToString().Equals("real"))
                                {
                                    chargefield.IsHideReal = false;
                                    chargefield.SortOrder = Convert.ToInt32(dic["SortOrder"]);
                                }
                                if (dic["FieldType"].ToString().Equals("chargefee"))
                                {
                                    chargefield.IsHideChargeFee = false;
                                    chargefield.SortOrder = Convert.ToInt32(dic["SortOrder"]);
                                }
                                if (dic["FieldType"].ToString().Equals("rest"))
                                {
                                    chargefield.IsHideRest = false;
                                    chargefield.SortOrder = Convert.ToInt32(dic["SortOrder"]);
                                }
                                if (dic["FieldType"].ToString().Equals("discount"))
                                {
                                    chargefield.IsHideDiscount = false;
                                    chargefield.SortOrder = Convert.ToInt32(dic["SortOrder"]);
                                }
                            }
                        }
                        chargefield.Save(helper);
                    }
                    helper.Commit();
                    context.Response.Write(JsonConvert.SerializeObject(new { status = true }));
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    Utility.LogHelper.WriteError("SysSettingHandler", "命令: savemonthfeeanalysistablefield", ex);
                    context.Response.Write(JsonConvert.SerializeObject(new { status = false }));
                }
            }
        }
        private void getmonthfeeanalysisfield(HttpContext context)
        {
            try
            {
                string PageCode = context.Request.Params["PageCode"];
                PageCode = string.IsNullOrEmpty(PageCode) ? Utility.EnumModel.AnalysisChargeFieldPageCode.MonthFeeAnalysis.ToString() : PageCode;
                var list = Foresight.DataAccess.AnalysisChargeField.GetMonthFeeAnalysisColumns();
                var results = list.Select(p =>
                {
                    var dic = new Dictionary<string, object>();
                    dic["FieldID"] = p.ID;
                    dic["ID"] = p.ID;
                    dic["ColumnName"] = p.ChargeID + "月份";
                    dic["SortOrder"] = p.SortOrder < 0 ? 0 : p.SortOrder;
                    dic["DefaultSortOrder"] = p.SortOrder < 0 ? int.MaxValue : p.SortOrder;
                    dic["IsShown"] = !p.IsHide;
                    dic["IsShowTotal"] = !p.IsHideTotal;
                    dic["IsShowReal"] = !p.IsHideReal;
                    dic["IsShowRest"] = !p.IsHideRest;
                    dic["IsShowDiscount"] = !p.IsHideDiscount;
                    dic["IsShowChargeFee"] = !p.IsHideChargeFee;
                    return dic;
                }).ToList();
                results = results.OrderBy(p => p["DefaultSortOrder"]).ToList();
                var items = new
                {
                    status = true,
                    list = results,
                };
                context.Response.Write(JsonConvert.SerializeObject(items));
            }
            catch (Exception)
            {
                var items = new
                {
                    status = false,
                };
                context.Response.Write(JsonConvert.SerializeObject(items));
            }
        }
        private void getappversionbyapptype(HttpContext context)
        {
            int APPType = WebUtil.GetIntValue(context, "APPType");
            string VersionType = context.Request["VersionType"];
            var data = Foresight.DataAccess.SiteVersion.GetLatestAPPVersion(APPType: APPType, VersionType: VersionType);
            if (data == null)
            {
                WebUtil.WriteJson(context, new { status = false });
                return;
            }
            string filepath_android = string.Empty;
            string filepath_ios = string.Empty;
            if (data.VersionType.Equals("android"))
            {
                filepath_android = WebUtil.GetContextPath() + data.FilePath;
            }
            else if (data.VersionType.Equals("ios"))
            {
                filepath_ios = data.FilePath;
            }
            WebUtil.WriteJson(context, new { status = true, version = data.APPVersionDesc, time = data.PublishDate.ToString("yyyy-MM-dd"), desc = data.VersionDesc, filepath_android = filepath_android, filepath_ios = filepath_ios });
        }
        private void getmymenus(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            if (ID < 0)
            {
                WebUtil.WriteJson(context, new { status = false });
                return;
            }
            string GroupName = context.Request["GroupName"];
            string[] modulecodes = WebUtil.GetModuleCodes(context);
            GroupName = string.IsNullOrEmpty(GroupName) ? Utility.EnumModel.SysMenuGroupNameDefine.wynk.ToString() : GroupName;
            var modules = SysMenu.GetSysMenuForUser(WebUtil.GetUser(context).UserID, ID, GroupName: GroupName).Where(p => modulecodes.Contains(p.ModuleCode)).OrderBy(p => p.SortOrder);
            string context_path = WebUtil.getApplicationPath();
            var items = modules.Select(p =>
            {
                var item = p.ToJsonObject();
                item["IconPath"] = !string.IsNullOrEmpty(p.IconPath) ? context_path + p.IconPath : string.Empty;
                return item;
            });
            WebUtil.WriteJson(context, new { status = true, list = items });
        }
        private void deletesysmenus(HttpContext context)
        {
            string ids = context.Request.Params["ids"];
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(ids);
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    string cmdtext = "delete from [SysMenu] where [ID] in (" + string.Join(",", IDList.ToArray()) + ")";
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    helper.Execute(cmdtext, CommandType.Text, parameters);
                    helper.Commit();
                    context.Response.Write("{\"status\":true}");
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    Utility.LogHelper.WriteError("SysSettingHandler", "命令: deletesysmenus", ex);
                    context.Response.Write("{\"status\":false}");
                }
            }
        }
        private void deletesysmenuimg(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            int type = WebUtil.GetIntValue(context, "type");
            var menu = Foresight.DataAccess.SysMenu.GetSysMenu(ID);
            if (type == 1)
            {
                menu.IconPath = string.Empty;
            }
            else
            {
                menu.ImgUrl = string.Empty;
            }
            menu.Save();
            WebUtil.WriteJson(context, new { status = true });
        }
        private void savesysmenu(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            int ParentID = WebUtil.GetIntValue(context, "ParentID");
            var MaxID = Foresight.DataAccess.SysMenu.GetSysMenus().Max(p => p.ID);
            var menu = Foresight.DataAccess.SysMenu.GetSysMenu(ID);
            if (menu == null)
            {
                menu = new SysMenu();
                menu.ID = (MaxID + 1);
                menu.ModuleCode = "1101" + menu.ID.ToString("D3");
            }
            if (ParentID > 0)
            {
                var parent_module = Foresight.DataAccess.SysMenu.GetSysMenu(ParentID);
                menu.GroupName = parent_module.GroupName;
            }
            else
            {
                string GroupName = context.Request["GroupName"];
                if (!string.IsNullOrEmpty(GroupName))
                {
                    menu.GroupName = GroupName;
                    menu.ParentID = 0;
                }
            }
            menu.Name = context.Request["Name"];
            menu.Title = menu.Name;
            menu.ParentID = ParentID;
            menu.IsAuthority = WebUtil.GetIntValue(context, "MenuType") != 1;
            menu.Url = context.Request["URL"];
            menu.UsingImgURL = WebUtil.GetIntValue(context, "UsingImgURL") == 1;
            menu.SortOrder = WebUtil.GetIntValue(context, "SortOrder");
            menu.Description = context.Request["Description"];
            HttpFileCollection uploadFiles = context.Request.Files;
            if (uploadFiles.Count > 0)
            {
                for (int i = 0; i < uploadFiles.Count; i++)
                {
                    HttpPostedFile postedFile = uploadFiles[i];
                    string fileOriName = postedFile.FileName;
                    if (fileOriName != "" && fileOriName != null)
                    {
                        string extension = System.IO.Path.GetExtension(fileOriName).ToLower();
                        string fileName = DateTime.Now.ToFileTime().ToString() + extension;
                        string filepath = "/upload/VersionMgr/";
                        string rootPath = HttpContext.Current.Server.MapPath("~" + filepath);
                        if (!System.IO.Directory.Exists(rootPath))
                        {
                            System.IO.Directory.CreateDirectory(rootPath);
                        }
                        string Path = rootPath + fileName;
                        postedFile.SaveAs(Path);
                        if (i == 0)
                        {
                            menu.IconPath = filepath + fileName;
                        }
                        else
                        {
                            menu.ImgUrl = filepath + fileName;
                        }
                    }
                }
            }
            menu.Save();
            WebUtil.WriteJson(context, new { status = true, ID = menu.ID });
        }
        private void getmenubyid(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            var menu = Foresight.DataAccess.SysMenu.GetSysMenu(ID);
            string ParentName = string.Empty;
            if (menu.ParentID > 0)
            {
                var parent = Foresight.DataAccess.SysMenu.GetSysMenu(menu.ParentID);
                ParentName = parent.Name;
            }
            else if (!string.IsNullOrEmpty(menu.GroupName))
            {
                ParentName = Utility.EnumHelper.GetDescription(typeof(Utility.EnumModel.SysMenuGroupNameDefine), menu.GroupName);
            }
            int MenuType = 2;
            if (!menu.IsAuthority)
            {
                MenuType = 1;
            }
            if (menu.IsAuthority && !string.IsNullOrEmpty(menu.Url))
            {
                MenuType = 3;
            }
            string IconPath = menu.IconPath;
            int SortOrder = menu.SortOrder > 0 ? menu.SortOrder : 0;
            int UsingImgURL = menu.UsingImgURL ? 1 : 0;
            IconPath = string.IsNullOrEmpty(IconPath) ? string.Empty : WebUtil.GetContextPath() + IconPath;
            string ImgUrl = menu.ImgUrl;
            ImgUrl = string.IsNullOrEmpty(ImgUrl) ? string.Empty : WebUtil.GetContextPath() + ImgUrl;
            var item = new { ID = menu.ID, Name = menu.Name, ParentName = ParentName, MenuType = MenuType, URL = menu.Url, IconPath = IconPath, SortOrder = SortOrder, UsingImgURL = UsingImgURL, ImgUrl = ImgUrl, Description = menu.Description, GroupName = menu.GroupName, ParentID = menu.ParentID, ModuleCode = menu.ModuleCode };
            WebUtil.WriteJson(context, new { status = true, menu = item });
        }
        private void getsysmenus(HttpContext context)
        {
            var menus = Foresight.DataAccess.SysMenu.GetSysMenus().Where(p => !p.Disabled).OrderBy(p => p.SortOrder);
            var items = menus.Select(p =>
            {
                var item = p.ToJsonObject();
                item["id"] = p.ID.ToString();
                if (p.ParentID == 0)
                {
                    if (!string.IsNullOrEmpty(p.GroupName))
                    {
                        item["pId"] = p.GroupName;
                    }
                    else
                    {
                        item["pId"] = Utility.EnumModel.SysMenuGroupNameDefine.wynk.ToString();
                    }
                }
                else
                {
                    item["pId"] = p.ParentID.ToString();
                }
                item["name"] = p.Title;
                return item;
            }).ToList();

            items.Add(AddSysMenuTree(Utility.EnumModel.SysMenuGroupNameDefine.wynk.ToString()));
            items.Add(AddSysMenuTree(Utility.EnumModel.SysMenuGroupNameDefine.appgl.ToString()));
            WebUtil.WriteJson(context, items);
        }
        private Dictionary<string, object> AddSysMenuTree(string id)
        {
            var dic = new Dictionary<string, object>();
            dic["id"] = id;
            dic["ID"] = 0;
            dic["pId"] = "0";
            dic["name"] = Utility.EnumHelper.GetDescription(typeof(Utility.EnumModel.SysMenuGroupNameDefine), id);
            return dic;
        }
        private void cleardata(HttpContext context)
        {
            if (!WebUtil.Authorization(context, "1101235"))
            {
                WebUtil.WriteJson(context, new { status = false, error = "您没有此操作权限" });
                return;
            }
            string cmdtext = string.Empty;
            int clear_project = WebUtil.GetIntValue(context, "clear_project");
            if (clear_project == 1)
            {
                cmdtext += "delete from [Project] where [ID]!=1;";
                cmdtext += "delete from [RoomBasic];";
                cmdtext += "delete from [RoomPhoneRelation];";
                cmdtext += "delete from [RoomRelation];";
            }
            int clear_chargesummary = WebUtil.GetIntValue(context, "clear_chargesummary");
            if (clear_chargesummary == 1)
            {
                cmdtext += "delete from [ChargeSummary];";
                cmdtext += "delete from [ChargeDiscount_ChargeSummary];";
                cmdtext += "delete from [ChargeFee];";
                cmdtext += "delete from [ChargePriceRange];";
                cmdtext += "delete from [ChargeSummary_Biao];";
            }
            int clear_fee = WebUtil.GetIntValue(context, "clear_fee");
            if (clear_fee == 1)
            {
                cmdtext += "delete from [RoomFee];";
                cmdtext += "delete from [RoomFee_BreakContract];";
                cmdtext += "delete from [TempRoomFee];";
            }
            int clear_importfee = WebUtil.GetIntValue(context, "clear_importfee");
            if (clear_importfee == 1)
            {
                cmdtext += "delete from [ImportFee];";
                cmdtext += "delete from [Project_Biao];";
                cmdtext += "delete from [ProjectBiao_Relation];";
            }
            int clear_historyfee = WebUtil.GetIntValue(context, "clear_historyfee");
            if (clear_historyfee == 1)
            {
                cmdtext += "delete from [RoomFeeHistory];";
                cmdtext += "delete from [PrintRoomFeeHistory];";
                cmdtext += "delete from [TempRoomFeeHistory];";
            }
            int clear_feeorder = WebUtil.GetIntValue(context, "clear_feeorder");
            if (clear_feeorder == 1)
            {
                cmdtext += "delete from [RoomFeeOrder];";
                cmdtext += "update [PrintRoomFeeHistory] set [RoomFeeOrderID]=null;";
            }
            int clear_contract = WebUtil.GetIntValue(context, "clear_contract");
            if (clear_contract == 1)
            {
                cmdtext += "delete from [Contract];";
                cmdtext += "delete from [Contract_Approve];";
                cmdtext += "delete from [Contract_ChargeSummary];";
                cmdtext += "delete from [Contract_Divide];";
                cmdtext += "delete from [Contract_DivideType];";
                cmdtext += "delete from [Contract_File];";
                cmdtext += "delete from [Contract_FreeTime];";
                cmdtext += "delete from [Contract_ModifyLog];";
                cmdtext += "delete from [Contract_Print];";
                cmdtext += "delete from [Contract_Room];";
                cmdtext += "delete from [Contract_RoomCharge];";
                cmdtext += "delete from [Contract_Stop];";
                cmdtext += "delete from [Contract_Template];";
                cmdtext += "delete from [Contract_TempPrice];";
                cmdtext += "delete from [Contract_ZuKong];";
                cmdtext += "delete from [Contract_ZuKong];";
            }
            int clear_cangku = WebUtil.GetIntValue(context, "clear_cangku");
            if (clear_cangku == 1)
            {
                cmdtext += "delete from [CKAccpetUser];";
                cmdtext += "delete from [CKCategory];";
                cmdtext += "delete from [CKContarct];";
                cmdtext += "delete from [CKDepartment];";
                cmdtext += "delete from [CKInCategory] where isnull([IsSystemAdd],0)!=1;";
                cmdtext += "delete from [CKInOutSummary];";
                cmdtext += "delete from [CKProductCategory];";
                cmdtext += "delete from [CKProductInSumary];";
                cmdtext += "delete from [CKProductOutSumary];";
                cmdtext += "delete from [CKProperty];";
                cmdtext += "delete from [CKPropertyCategory];";
                cmdtext += "delete from [CKPropertyTemp];";
                cmdtext += "delete from [CKProudctInDetail];";
                cmdtext += "delete from [CKProudctOutDetail];";
            }
            int clear_customerservice = WebUtil.GetIntValue(context, "clear_customerservice");
            if (clear_customerservice == 1)
            {
                cmdtext += "delete from [CustomerService];";
                cmdtext += "delete from [CustomerService_Accpet];";
                cmdtext += "delete from [CustomerService_Material];";
                cmdtext += "delete from [CustomerService_Task];";
                cmdtext += "delete from [CustomerServiceAttach];";
                cmdtext += "delete from [CustomerServiceChuli];";
                cmdtext += "delete from [CustomerServiceChuli_Attach];";
                cmdtext += "delete from [CustomerServiceHuifang];";
                cmdtext += "delete from [ZhuangXiu];";
                cmdtext += "delete from [ZhuangXiu_Approve];";
                cmdtext += "delete from [ZhuangXiu_Category];";
                cmdtext += "delete from [ZhuangXiu_File];";
                cmdtext += "delete from [ZhuangXiu_Rule];";
                cmdtext += "delete from [ZhuangXiu_XunJian];";
            }
            int clear_payservice = WebUtil.GetIntValue(context, "clear_payservice");
            if (clear_payservice == 1)
            {
                cmdtext += "delete from [PayService];";
                cmdtext += "delete from [PaySummary];";
            }
            int clear_divice = WebUtil.GetIntValue(context, "clear_divice");
            if (clear_divice == 1)
            {
                cmdtext += "delete from [Device];";
                cmdtext += "delete from [Device_Group];";
                cmdtext += "delete from [Device_Image];";
                cmdtext += "delete from [Device_Task];";
                cmdtext += "delete from [Device_TaskOperation];";
                cmdtext += "delete from [Device_TaskType];";
                cmdtext += "delete from [Device_Type];";
                cmdtext += "delete from [DeviceSetting];";
                cmdtext += "delete from [DeviceTask_Image];";
            }
            if (string.IsNullOrEmpty(cmdtext))
            {
                WebUtil.WriteJson(context, new { status = false, error = "没有选择任何项" });
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
                    LogHelper.WriteError("SysSetingHandeler", "cleardata", ex);
                    helper.Rollback();
                    WebUtil.WriteJson(context, new { status = false });
                    return;
                }
            }
            Web.APPCode.CacheHelper.ClearCache();
            System.Web.Security.FormsAuthentication.SignOut();
            WebUtil.WriteJson(context, new { status = true });
        }
        private void getsysmenucategorylist(HttpContext context)
        {
            var categorylist = Foresight.DataAccess.SysManualCategory.GetSysManualCategories().Where(p => p.Status == 1).OrderBy(p => p.SortBy).ToArray();
            var manuallist = Foresight.DataAccess.SysManual.GetSysManuals().Where(p => p.Status == 1).OrderBy(p => p.SortBy).ToArray();
            var items = categorylist.Select(p =>
            {
                var mymanuals = manuallist.Where(q => q.CategoryID == p.ID).Select(q =>
                {
                    var manual = new { ManualID = q.ID, Title = q.Title, HtmlContent = "" };
                    return manual;
                });
                var item = new { CategoryID = p.ID, CategoryName = p.CategoryName, mymanuals = mymanuals };
                return item;
            });
            WebUtil.WriteJson(context, new { status = true, list = items });
        }
        private void removesysmanual(HttpContext context)
        {
            string IDListArry = context.Request.Params["IDList"];
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(IDListArry);
            if (IDList.Count > 0)
            {
                using (SqlHelper helper = new SqlHelper())
                {
                    try
                    {
                        helper.BeginTransaction();
                        string cmdtext = "delete from [SysManual] where [ID] in (" + string.Join(",", IDList.ToArray()) + ")";
                        List<SqlParameter> parameters = new List<SqlParameter>();
                        helper.Execute(cmdtext, CommandType.Text, parameters);
                        helper.Commit();
                    }
                    catch (Exception ex)
                    {
                        helper.Rollback();
                        LogHelper.WriteError("SysSettingHandler.ashx", "命令: removesysmanual", ex);
                        WebUtil.WriteJson(context, new { status = false });
                        return;
                    }
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void savesysmanual(HttpContext context)
        {
            int CategoryID = WebUtil.GetIntValue(context, "CategoryID");
            int ManualID = WebUtil.GetIntValue(context, "ManualID");
            Foresight.DataAccess.SysManual data = null;
            if (ManualID > 0)
            {
                data = Foresight.DataAccess.SysManual.GetSysManual(ManualID);
            }
            if (data == null)
            {
                data = new SysManual();
                data.AddMan = WebUtil.GetUser(context).RealName;
                data.AddTime = DateTime.Now;
                data.CategoryID = CategoryID;
            }
            data.Title = getValue(context, "tdTitle");
            data.Description = context.Request["HTMLContent"];
            data.SortBy = getIntValue(context, "tdSortBy");
            data.Status = getIntValue(context, "tdStatus");
            data.Save();
            WebUtil.WriteJson(context, new { status = true });
        }
        private void getsysmanualgrid(HttpContext context)
        {
            try
            {
                string Keywords = context.Request.Params["keywords"];
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                string TreeIDs = context.Request["TreeIDList"];
                List<int> TreeIDList = JsonConvert.DeserializeObject<List<int>>(TreeIDs);
                DataGrid dg = SysManualDetail.GetSysManualGridByKeywords(Keywords, TreeIDList, "order by SortBy asc,AddTime asc", startRowIndex, pageSize);
                WebUtil.WriteJson(context, dg);
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("SysSettingHandler.ashx", "getsysmanualgrid", ex);
                WebUtil.WriteJson(context, new Foresight.DataAccess.Ui.DataGrid());
                return;
            }
        }
        private void removesysmanualcategory(HttpContext context)
        {
            string IDListArry = context.Request.Params["IDList"];
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(IDListArry);
            if (IDList.Count > 0)
            {
                using (SqlHelper helper = new SqlHelper())
                {
                    try
                    {
                        helper.BeginTransaction();
                        string cmdtext = "delete from [SysManualCategory] where [ID] in (" + string.Join(",", IDList.ToArray()) + ")";
                        List<SqlParameter> parameters = new List<SqlParameter>();
                        helper.Execute(cmdtext, CommandType.Text, parameters);
                        helper.Commit();
                    }
                    catch (Exception ex)
                    {
                        helper.Rollback();
                        LogHelper.WriteError("SysSettingHandler.ashx", "命令: removesysmanualcategory", ex);
                        WebUtil.WriteJson(context, new { status = false });
                        return;
                    }
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void savesysmanualcategory(HttpContext context)
        {
            int CategoryID = WebUtil.GetIntValue(context, "CategoryID");
            Foresight.DataAccess.SysManualCategory data = null;
            if (CategoryID > 0)
            {
                data = Foresight.DataAccess.SysManualCategory.GetSysManualCategory(CategoryID);
            }
            if (data == null)
            {
                data = new SysManualCategory();
                data.AddTime = DateTime.Now;
            }
            data.CategoryName = getValue(context, "tdCategoryName");
            data.SortBy = getIntValue(context, "tdSortBy");
            data.Status = getIntValue(context, "tdStatus");
            data.Save();
            WebUtil.WriteJson(context, new { status = true });
        }
        private void getsysmanualtree(HttpContext context)
        {
            try
            {
                string Keywords = context.Request.Params["Keywords"];
                var list = Foresight.DataAccess.SysManualCategory.GetSysManualCategoryListByKeywords(Keywords);
                TreeModule treeModule = null;
                var items = list.Select(p =>
                {
                    treeModule = new TreeModule();
                    treeModule.id = "category_" + p.ID.ToString();
                    treeModule.ID = p.ID;
                    treeModule.pId = "category_0";
                    treeModule.name = p.CategoryName;
                    treeModule.isParent = false;
                    treeModule.open = true;
                    return treeModule;
                }).ToList();
                treeModule = new TreeModule();
                treeModule.id = "category_0";
                treeModule.ID = 0;
                treeModule.pId = "0";
                treeModule.name = WebUtil.GetCompany(context).CompanyName;
                bool hasckChild = list.Length > 0;
                treeModule.isParent = hasckChild;
                treeModule.open = hasckChild;
                items.Add(treeModule);
                WebUtil.WriteJson(context, items);
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("WechatHandler.ashx", "visit: getsurveytree", ex);
                context.Response.Write("[]");
            }
        }
        private void getupgradesiteparams(HttpContext context)
        {
            var list = Foresight.DataAccess.SiteVersion.GetSiteVersions().Where(p => string.IsNullOrEmpty(p.VersionType) || p.VersionType.Equals("platform")).OrderByDescending(p => p.VersionCode);
            var items = list.Select(p =>
            {
                var item = new { ID = p.ID, Name = p.VersionCode.ToString() };
                return item;
            });
            WebUtil.WriteJson(context, new { status = true, versions = items });
        }
        private void removeversionfile(HttpContext context)
        {
            int VersionID = WebUtil.GetIntValue(context, "VersionID");
            int index = WebUtil.GetIntValue(context, "index");
            Foresight.DataAccess.SiteVersion data = null;
            if (VersionID > 0)
            {
                data = SiteVersion.GetSiteVersion(VersionID);
            }
            if (data == null)
            {
                WebUtil.WriteJson(context, new { status = false });
                return;
            }
            if (index == 1)
            {
                data.FilePath = string.Empty;
            }
            else
            {
                data.SqlPath = string.Empty;
            }
            data.Save();
            WebUtil.WriteJson(context, new { status = true });
        }
        private void savesiteversion(HttpContext context)
        {
            int VersionID = WebUtil.GetIntValue(context, "VersionID");
            Foresight.DataAccess.SiteVersion data = null;
            if (VersionID > 0)
            {
                data = SiteVersion.GetSiteVersion(VersionID);
            }
            if (data == null)
            {
                data = new SiteVersion();
                data.PublishDate = DateTime.Now;
            }
            data.VersionCode = WebUtil.GetIntValue(context, "VersionCode");
            data.VersionDesc = context.Request["VersionDesc"];
            data.VersionType = context.Request["VersionType"];
            data.APPVersionCode = WebUtil.GetIntValue(context, "APPVersionCode");
            data.APPVersionDesc = context.Request["APPVersionDesc"];
            data.APPType = WebUtil.GetIntValue(context, "APPType");
            data.DisableUpdate = WebUtil.GetIntValue(context, "DisableUpdate") == 1;
            data.IsForceUpdate = WebUtil.GetIntValue(context, "IsForceUpdate") == 1;
            HttpFileCollection uploadFiles = context.Request.Files;
            if (uploadFiles.Count > 0)
            {
                for (int i = 0; i < uploadFiles.Count; i++)
                {
                    HttpPostedFile postedFile = uploadFiles[i];
                    string fileOriName = postedFile.FileName;
                    if (fileOriName != "" && fileOriName != null)
                    {
                        string extension = System.IO.Path.GetExtension(fileOriName).ToLower();
                        string fileName = DateTime.Now.ToFileTime().ToString() + extension;
                        string filepath = "/upload/VersionMgr/";
                        string rootPath = HttpContext.Current.Server.MapPath("~" + filepath);
                        if (!System.IO.Directory.Exists(rootPath))
                        {
                            System.IO.Directory.CreateDirectory(rootPath);
                        }
                        string Path = rootPath + fileName;
                        postedFile.SaveAs(Path);
                        if (i == 0)
                        {
                            data.FilePath = filepath + fileName;
                        }
                        else
                        {
                            data.SqlPath = filepath + fileName;
                        }
                    }
                }
            }
            if (data.VersionType.Equals("ios"))
            {
                data.FilePath = context.Request["IOS_FilePath"];
            }
            data.Save();
            WebUtil.WriteJson(context, new { status = true });
        }
        private void removeversions(HttpContext context)
        {
            string ids = context.Request.Params["IDList"];
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(ids);
            if (IDList.Count > 0)
            {
                using (SqlHelper helper = new SqlHelper())
                {
                    try
                    {
                        helper.BeginTransaction();
                        string cmdtext = "delete from [SiteVersion] where [ID] in (" + string.Join(",", IDList.ToArray()) + ")";
                        List<SqlParameter> parameters = new List<SqlParameter>();
                        helper.Execute(cmdtext, CommandType.Text, parameters);
                        helper.Commit();
                    }
                    catch (Exception ex)
                    {
                        helper.Rollback();
                        Utility.LogHelper.WriteError("SysSettingHandler", "命令: removeversions", ex);
                        WebUtil.WriteJson(context, new { status = false });
                        return;
                    }
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void loadversiongrid(HttpContext context)
        {
            try
            {
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                string keywords = context.Request["keywords"];
                string VersionType = context.Request["VersionType"];
                bool OnlyAPP = false;
                if (context.Request["OnlyAPP"] != null)
                {
                    bool.TryParse(context.Request["OnlyAPP"], out OnlyAPP);
                }
                string OrderBy = "order by [VersionCode] desc";
                if (OnlyAPP)
                {
                    OrderBy = "order by [APPVersionCode] desc";
                }
                var dg = SiteVersion.GetSiteVersionGrid(keywords, OrderBy, startRowIndex, pageSize, VersionType, OnlyAPP: OnlyAPP);
                var list = dg.rows as SiteVersion[];
                string context_path = WebUtil.GetContextPath();
                foreach (var item in list)
                {
                    item.FilePath = context_path + item.FilePath;
                }
                dg.rows = list;
                WebUtil.WriteJson(context, dg);
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("SysSettingHandler", "loadversiongrid", ex);
                WebUtil.WriteJson(context, new Foresight.DataAccess.Ui.DataGrid());
                return;
            }
        }
        private void savechargetablefield(HttpContext context)
        {
            string Liststr = context.Request.Params["List"];
            string PageCode = context.Request.Params["PageCode"];
            List<Dictionary<string, object>> List = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(Liststr);
            var summary_list = Foresight.DataAccess.ChargeSummary.GetChargeSummaries().ToArray();
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    string cmdtext = "update AnalysisChargeField set [IsHide]=1,IsHideTotal=1,IsHideReal=1,IsHideRest=1,SortOrder=-1 where [PageCode]=@PageCode";
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    parameters.Add(new SqlParameter("@PageCode", PageCode));
                    helper.Execute(cmdtext, CommandType.Text, parameters);
                    for (int i = 0; i < summary_list.Length; i++)
                    {
                        int ChargeID = summary_list[i].ID;
                        var chargefield = Foresight.DataAccess.AnalysisChargeField.GetAnalysisChargeFieldByCode(PageCode, ChargeID, helper);
                        if (chargefield == null)
                        {
                            chargefield = new AnalysisChargeField();
                            chargefield.ChargeID = ChargeID;
                            chargefield.PageCode = PageCode;
                            chargefield.IsHide = true;
                            chargefield.IsHideReal = true;
                            chargefield.IsHideRest = true;
                            chargefield.IsHideTotal = true;
                        }
                        foreach (var dic in List)
                        {
                            int dic_id = Convert.ToInt32(dic["ID"]);
                            if (dic_id == ChargeID)
                            {
                                if (dic["FieldType"].ToString().Equals("summary"))
                                {
                                    chargefield.IsHide = false;
                                    chargefield.SortOrder = Convert.ToInt32(dic["SortOrder"]);
                                }
                                if (dic["FieldType"].ToString().Equals("total"))
                                {
                                    chargefield.IsHideTotal = false;
                                    chargefield.SortOrder = Convert.ToInt32(dic["SortOrder"]);
                                }
                                if (dic["FieldType"].ToString().Equals("real"))
                                {
                                    chargefield.IsHideReal = false;
                                    chargefield.SortOrder = Convert.ToInt32(dic["SortOrder"]);
                                }
                                if (dic["FieldType"].ToString().Equals("rest"))
                                {
                                    chargefield.IsHideRest = false;
                                    chargefield.SortOrder = Convert.ToInt32(dic["SortOrder"]);
                                }
                            }
                        }
                        chargefield.Save(helper);
                    }
                    helper.Commit();
                    context.Response.Write(JsonConvert.SerializeObject(new { status = true }));
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    Utility.LogHelper.WriteError("SysSettingHandler", "命令: savechargetablefield", ex);
                    context.Response.Write(JsonConvert.SerializeObject(new { status = false }));
                }
            }
        }
        private void getchargetablefield(HttpContext context)
        {
            try
            {
                string PageCode = context.Request.Params["PageCode"];
                PageCode = string.IsNullOrEmpty(PageCode) ? Utility.EnumModel.AnalysisChargeFieldPageCode.ShouFeiLvSummaryAnalysis.ToString() : PageCode;
                var list = Foresight.DataAccess.ChargeSummaryField.GetChargeSummaryFields(PageCode);
                if (list.Length == 0)
                {
                    list = Foresight.DataAccess.ChargeSummaryField.GetChargeSummaryFields(string.Empty);
                }
                var results = list.Select(p =>
                {
                    var dic = new Dictionary<string, object>();
                    dic["FieldID"] = p.ID;
                    dic["ID"] = p.ID;
                    dic["ColumnName"] = p.Name;
                    dic["SortOrder"] = p.SortOrder < 0 ? 0 : p.SortOrder;
                    dic["DefaultSortOrder"] = p.SortOrder < 0 ? int.MaxValue : p.SortOrder;
                    dic["IsShown"] = !p.IsHide;
                    dic["IsShowTotal"] = !p.IsHideTotal;
                    dic["IsShowReal"] = !p.IsHideReal;
                    dic["IsShowRest"] = !p.IsHideRest;
                    return dic;
                }).ToList();
                results = results.OrderBy(p => p["DefaultSortOrder"]).ToList();
                var items = new
                {
                    status = true,
                    list = results,
                };
                context.Response.Write(JsonConvert.SerializeObject(items));
            }
            catch (Exception)
            {
                var items = new
                {
                    status = false,
                };
                context.Response.Write(JsonConvert.SerializeObject(items));
            }
        }
        private void getdefinecontent(HttpContext context)
        {
            string TableName = context.Request["TableName"];
            if (string.IsNullOrEmpty(TableName))
            {
                WebUtil.WriteJson(context, new { status = false, msg = "TableName为空" });
                return;
            }
            var all_list = Foresight.DataAccess.DefineField.GetDefineFieldsByTable_Name(TableName, 0);
            var list = all_list.Where(p => string.IsNullOrEmpty(p.ColumnName)).ToArray();
            List<Dictionary<string, object>> list_dic = new List<Dictionary<string, object>>();
            if (TableName.Equals(Utility.EnumModel.DefineFieldTableName.RoomBasic.ToString()))
            {
                int RoomID = WebUtil.GetIntValue(context, "RoomID");
                var basic_field_list = Foresight.DataAccess.RoomBasicField.GetRoomBasicFieldsByRoomID(RoomID);
                foreach (var item in list)
                {
                    var basic_field = basic_field_list.FirstOrDefault(p => p.FieldID == item.ID);
                    var dic = item.ToJsonObject();
                    dic["FieldContent"] = basic_field == null ? "" : basic_field.FieldContent;
                    list_dic.Add(dic);
                }
            }
            WebUtil.WriteJson(context, new { status = true, list = list_dic });
        }
        private void removedefinefield(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            string TableName = context.Request["TableName"];
            if (TableName.Equals(Utility.EnumModel.DefineFieldTableName.RoomBasic.ToString()))
            {
                var list = RoomBasicField.GetRoomBasicFieldsByFieldID(ID);
                if (list.Length > 0)
                {
                    WebUtil.WriteJson(context, new { status = false, msg = "该字段包含数据，禁止删除" });
                    return;
                }
                string cmdtext = "delete from RoomBasicField where FieldID=@FieldID and isnull(FieldContent,'')='';";
                cmdtext += "delete from DefineField where ID=@FieldID;";
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@FieldID", ID));
                using (SqlHelper helper = new SqlHelper())
                {
                    try
                    {
                        helper.BeginTransaction();
                        helper.Execute(cmdtext, CommandType.Text, parameters);
                        helper.Commit();
                    }
                    catch (Exception)
                    {
                        helper.Rollback();
                        WebUtil.WriteJson(context, new { status = false });
                        return;
                    }
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void savedefinefield(HttpContext context)
        {
            string list = context.Request["list"];
            string TableName = context.Request["TableName"];
            List<Utility.BasicModel> ModelList = JsonConvert.DeserializeObject<List<Utility.BasicModel>>(list);
            foreach (var item in ModelList)
            {
                Foresight.DataAccess.DefineField define_field = null;
                if (item.id > 0)
                {
                    define_field = Foresight.DataAccess.DefineField.GetDefineField(item.id);
                }
                if (define_field == null)
                {
                    define_field = new DefineField();
                    define_field.AddTime = DateTime.Now;
                    define_field.IsShown = false;
                }
                define_field.FieldName = item.value;
                define_field.Table_Name = TableName;
                define_field.Save();
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void getdefinefield(HttpContext context)
        {
            string TableName = context.Request["TableName"];
            if (string.IsNullOrEmpty(TableName))
            {
                WebUtil.WriteJson(context, new { status = false });
                return;
            }
            var all_list = Foresight.DataAccess.DefineField.GetDefineFieldsByTable_Name(TableName, 0, true);
            var list = all_list.Where(p => string.IsNullOrEmpty(p.ColumnName)).ToArray();
            var exist_list = all_list.Where(p => !string.IsNullOrEmpty(p.ColumnName)).ToArray();
            WebUtil.WriteJson(context, new { status = true, list = list, exist_list = exist_list });
        }
        private void deletechargediscount(HttpContext context)
        {
            string ids = context.Request.Params["ids"];
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(ids);
            int total = RoomFeeHistory.GetRoomFeeHistoryListCountByChargeIDList(DiscountIDList: IDList);
            if (total > 0)
            {
                WebUtil.WriteJson(context, new { status = false, error = "选中的折扣方式已使用，操作取消" });
                return;
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    string cmdtext = "delete from [ChargeDiscount] where ID in (" + string.Join(",", IDList.ToArray()) + ")";
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    helper.Execute(cmdtext, CommandType.Text, parameters);
                    helper.Commit();
                    context.Response.Write("{\"status\":true}");
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    Utility.LogHelper.WriteError("SysSettingHandler", "命令: deletechargediscount", ex);
                    context.Response.Write("{\"status\":false}");
                }
            }
        }
        private void savechargediscount(HttpContext context)
        {
            int id = WebUtil.GetIntValue(context, "id");
            string DiscountName = context.Request.Params["DiscountName"];
            int SortOrder = WebUtil.GetIntValue(context, "SortOrder");
            string DiscountType = context.Request.Params["DiscountType"];
            decimal DiscountValue = WebUtil.GetDecimalValue(context, "DiscountValue");
            DateTime StartTime = WebUtil.GetDateValue(context, "StartTime");
            DateTime EndTime = WebUtil.GetDateValue(context, "EndTime");
            string Remark = context.Request.Params["Remark"];
            ChargeDiscount chargeDiscount = null;
            if (id > 0)
            {
                chargeDiscount = ChargeDiscount.GetChargeDiscount(id);
            }
            if (chargeDiscount == null)
            {
                chargeDiscount = new ChargeDiscount();
            }
            chargeDiscount.DiscountName = DiscountName;
            chargeDiscount.DiscountType = DiscountType;
            chargeDiscount.DiscountValue = DiscountValue;
            chargeDiscount.StartTime = StartTime;
            chargeDiscount.EndTime = EndTime;
            chargeDiscount.SortOrder = SortOrder;
            chargeDiscount.Remark = Remark;
            string ChargeSummaryIDs = context.Request["ChargeSummaryIDs"];
            List<ChargeDiscount_ChargeSummary> list = new List<ChargeDiscount_ChargeSummary>();
            if (!string.IsNullOrEmpty(ChargeSummaryIDs))
            {
                List<int> ChargeSummaryIDList = JsonConvert.DeserializeObject<List<int>>(ChargeSummaryIDs);
                if (ChargeSummaryIDList.Count > 0)
                {
                    chargeDiscount.ChargeSummaryIDs = string.Join(",", ChargeSummaryIDList);
                    foreach (var ChargeSummaryID in ChargeSummaryIDList)
                    {
                        var chargeDiscount_ChargeSummary = new ChargeDiscount_ChargeSummary();
                        chargeDiscount_ChargeSummary.ChargeID = ChargeSummaryID;
                        list.Add(chargeDiscount_ChargeSummary);
                    }
                }
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    chargeDiscount.Save(helper);
                    string cmdtext = "delete from [ChargeDiscount_ChargeSummary] where [ChargeDiscountID]=" + chargeDiscount.ID + ";";
                    helper.Execute(cmdtext, CommandType.Text, new List<SqlParameter>());
                    foreach (var item in list)
                    {
                        item.ChargeDiscountID = chargeDiscount.ID;
                        item.Save(helper);
                    }
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    LogHelper.WriteDebug("SysSettingHandler", "savechargediscount", ex);
                    helper.Rollback();
                    context.Response.Write("{\"status\":false}");
                    return;
                }
            }
            context.Response.Write("{\"status\":true}");
        }
        private void loadchargediscount(HttpContext context)
        {
            try
            {
                var list = ChargeDiscount.GetChargeDiscounts().OrderBy(p => p.SortOrder).ToList();
                var dg = new DataGrid();
                dg.rows = list;
                dg.total = list.Count;
                dg.page = 1;
                string result = JsonConvert.SerializeObject(dg);
                context.Response.Write(result);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.WriteError("SysSettingHandler", "命令: loadordernumberlist", ex);
                context.Response.Write("{\"rows\":[],\"total\":0,\"page\":0}");
            }
        }
        private void savetopyt(HttpContext context)
        {
            string IDs = context.Request.Params["IDs"];
            int ProjectID = WebUtil.GetIntValue(context, "ProjectID");
            int CompanyID = WebUtil.GetIntValue(context, "CompanyID");
            string SortOrders = context.Request.Params["SortOrders"];
            string YTNameLists = context.Request.Params["YTNameLists"];
            string CheckLists = context.Request.Params["CheckLists"];
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(IDs);
            List<int> SortOrderList = JsonConvert.DeserializeObject<List<int>>(SortOrders);
            List<string> YTNameList = JsonConvert.DeserializeObject<List<string>>(YTNameLists);
            List<int> CheckList = JsonConvert.DeserializeObject<List<int>>(CheckLists);
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    string cmdtext = string.Empty;
                    for (int i = 0; i < IDList.Count; i++)
                    {
                        if (IDList[0] > 0)
                        {
                            cmdtext += " update [ProjectYTOrder] set IsShow=" + CheckList[i] + ",OrderBy=" + SortOrderList[i] + " where ID=" + IDList[i] + ";";
                        }
                        else
                        {
                            cmdtext += " insert into [ProjectYTOrder] ([CompanyID],[OrderBy],[Name],[IsShow],[ProjectID]) values(" + CompanyID + "," + SortOrderList[i] + ",'" + YTNameList[i].Trim() + "','" + CheckList[i] + "'," + ProjectID + ");";
                        }
                    }
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    helper.Execute(cmdtext, CommandType.Text, parameters);
                    helper.Commit();
                    var items = new { status = true };
                    context.Response.Write(JsonConvert.SerializeObject(items));
                }
                catch (Exception)
                {
                    helper.Rollback();
                    var items = new { status = false };
                    context.Response.Write(JsonConvert.SerializeObject(items));
                }
            }
        }
        private void loadtopyt(HttpContext context)
        {
            int ProjectID = 0;
            int.TryParse(context.Request.Params["ProjectID"], out ProjectID);
            int CompanyID = 0;
            int.TryParse(context.Request.Params["CompanyID"], out CompanyID);
            var project = Project.GetProject(ProjectID);
            string strjson = string.Empty;
            var list = ProjectYTDetails.GetProjectYTList(project.ID, CompanyID).OrderBy(p => p.YTOrderBy).ThenBy(p => p.OrderBy).ToArray();
            if (list.Length > 0)
            {
                strjson = JsonConvert.SerializeObject(list);
                context.Response.Write("{\"status\":true,\"list\":" + strjson + "}");
                return;
            }
            context.Response.Write("{\"status\":true,\"list\":[]}");
        }
        private void getmaxpricevalue(HttpContext context)
        {
            int ChargeID = WebUtil.GetIntValue(context, "ChargeID");
            decimal MaxValue = 0;
            var list = Foresight.DataAccess.ChargePriceRange.GetChargePriceRangeListBySummaryID(ChargeID);
            if (list.Length > 0)
            {
                MaxValue = list.Select(p => Convert.ToDecimal(p.MaxValue)).Max();
            }
            string maxstr = MaxValue == decimal.MaxValue ? "无上限" : MaxValue.ToString();
            WebUtil.WriteJson(context, new { status = true, MaxValue = maxstr });
        }
        private void deletechargebiao(HttpContext context)
        {
            string ids = context.Request.Params["ids"];
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(ids);
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    string cmdtext = "delete from [ChargeBiao] where [ID] in (" + string.Join(",", IDList.ToArray()) + ")";
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    helper.Execute(cmdtext, CommandType.Text, parameters);
                    helper.Commit();
                    context.Response.Write("{\"status\":true}");
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    Utility.LogHelper.WriteError("SysSettingHandler", "命令: deletechargebiao", ex);
                    context.Response.Write("{\"status\":false}");
                }
            }
        }
        private void savechargebiao(HttpContext context)
        {
            List<ChargeBiaoModel> list = JsonConvert.DeserializeObject<List<ChargeBiaoModel>>(context.Request.Params["BiaoRows"]);
            List<Foresight.DataAccess.ChargeBiao> biaoList = new List<ChargeBiao>();
            foreach (var item in list)
            {
                Foresight.DataAccess.ChargeBiao biao = null;
                if (item.ID != 0)
                {
                    biao = ChargeBiao.GetChargeBiao(item.ID);
                    if (biao != null)
                    {
                        biao.BiaoCategory = item.BiaoCategory;
                        biaoList.Add(biao);
                        continue;
                    }
                }

                biao = new ChargeBiao();
                biao.BiaoCategory = item.BiaoCategory;
                biao.AddTime = DateTime.Now;
                biaoList.Add(biao);
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    foreach (var item in biaoList)
                    {
                        item.Save(helper);
                    }
                    helper.Commit();
                    context.Response.Write("{\"status\":true}");
                }
                catch (Exception ex)
                {
                    LogHelper.WriteError("SysSettingHandler", "visit:savechargebiao", ex);
                    helper.Rollback();
                    context.Response.Write("{\"status\":false}");
                }
            }
        }
        private void loadchargebiaogrid(HttpContext context)
        {
            try
            {
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                var dg = ChargeBiao.GetChargeBiaoGrid(null, "order by [AddTime] desc", startRowIndex, pageSize);
                string result = JsonConvert.SerializeObject(dg);
                context.Response.Write(result);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.WriteError("SysSettingHandler", "命令: loadchargebiaogrid", ex);
                context.Response.Write("{\"rows\":[],\"total\":0,\"page\":0}");
            }
        }
        private void deletepricerange(HttpContext context)
        {
            string ids = context.Request.Params["ids"];
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(ids);
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    string cmdtext = "delete from [ChargePriceRange] where [ID] in (" + string.Join(",", IDList.ToArray()) + ")";
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    helper.Execute(cmdtext, CommandType.Text, parameters);
                    helper.Commit();
                    context.Response.Write("{\"status\":true}");
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    Utility.LogHelper.WriteError("SysSettingHandler", "命令: deletepricerange", ex);
                    context.Response.Write("{\"status\":false}");
                }
            }
        }
        private void savepricerange(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            int SummaryID = WebUtil.GetIntValue(context, "SummaryID");
            string BaseType = context.Request.Params["BaseType"];
            var list = Foresight.DataAccess.ChargePriceRange.GetChargePriceRangeListBySummaryID(SummaryID);
            var defaultrange = list.FirstOrDefault();
            if (defaultrange != null)
            {
                if (list.Length == 1)
                {
                    if (defaultrange.ID != ID)
                    {
                        if (!BaseType.Equals(defaultrange.BaseType))
                        {
                            context.Response.Write("{\"status\":true,\"success\":false}");
                            return;
                        }
                    }
                }
                else if (!BaseType.Equals(defaultrange.BaseType))
                {
                    context.Response.Write("{\"status\":true,\"success\":false}");
                    return;
                }
            }

            Foresight.DataAccess.ChargePriceRange priceRange = null;
            if (ID > 0)
            {
                priceRange = ChargePriceRange.GetChargePriceRange(ID);
            }
            if (priceRange == null)
            {
                priceRange = new ChargePriceRange();
                priceRange.SummaryID = SummaryID;
                priceRange.AddTime = DateTime.Now;
            }
            string MaxValueStr = context.Request["MaxValue"];
            decimal MaxValue = 0;
            if (MaxValueStr.Equals("无上限"))
            {
                MaxValue = decimal.MaxValue;
            }
            else
            {
                MaxValue = WebUtil.GetDecimalValue(context, "MaxValue");

            }
            priceRange.MinValue = WebUtil.GetDecimalValue(context, "MinValue").ToString();
            priceRange.MaxValue = MaxValue.ToString();
            priceRange.BasePrice = WebUtil.GetDecimalValue(context, "BasePrice");
            priceRange.BaseType = BaseType;
            priceRange.IsActive = WebUtil.GetIntValue(context, "IsActive") == 1 ? true : false;
            priceRange.Save();
            context.Response.Write("{\"status\":true,\"success\":true}");
        }
        private void loadpricerangegrid(HttpContext context)
        {
            try
            {
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                int SummaryID = WebUtil.GetIntValue(context, "SummaryID");
                var dg = ChargePriceRange.GetChargePriceRangeGridBySummaryID(SummaryID, "order by Convert(decimal(18,2), [MinValue]) asc", startRowIndex, pageSize);
                string result = JsonConvert.SerializeObject(dg);
                context.Response.Write(result);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.WriteError("SysSettingHandler", "命令: loadpricerangegrid", ex);
                context.Response.Write("{\"rows\":[],\"total\":0,\"page\":0}");
            }
        }
        private void savesysconfig(HttpContext context)
        {
            int ProjectID = WebUtil.GetIntValue(context, "ProjectID");
            var list = SysConfig.GetSysConfigs().ToArray();
            var configProjectList = SysConfig_Project.Get_SysConfig_ProjectList(ProjectID);

            SysConfig.SaveSysConfigValueByName(list, SysConfigNameDefine.RealCostCouZhengOn, context.Request["CouZheng"], configProjectList: configProjectList, ProjectID: ProjectID);

            SysConfig.SaveSysConfigValueByName(list, SysConfigNameDefine.ContractWarning, context.Request["ContractWarning"], configProjectList: configProjectList, ProjectID: ProjectID);

            SysConfig.SaveSysConfigValueByName(list, SysConfigNameDefine.WeixinChargeMan, context.Request["WeixinChargeMan"], configProjectList: configProjectList, ProjectID: ProjectID);

            SysConfig.SaveSysConfigValueByName(list, SysConfigNameDefine.HideCuiShouCustomerName, context.Request["HideCuiShouCustomerName"], configProjectList: configProjectList, ProjectID: ProjectID);

            SysConfig.SaveSysConfigValueByName(list, SysConfigNameDefine.WechatFeeNotify, context.Request["WechatFeeNotify"], configProjectList: configProjectList, ProjectID: ProjectID);

            SysConfig.SaveSysConfigValueByName(list, SysConfigNameDefine.WechatFeeNotifyTime, context.Request["WechatFeeNotifyTime"], configProjectList: configProjectList, ProjectID: ProjectID);

            context.Response.Write("{\"status\":true}");
        }
        private void savetablefield(HttpContext context)
        {
            string IDs = context.Request.Params["IDs"];
            string PageCode = context.Request.Params["PageCode"];
            string TableName = context.Request.Params["TableName"];
            string SortOrders = context.Request.Params["SortOrders"];
            string FieldIDs = context.Request.Params["FieldIDs"];
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(IDs);
            List<int> SortOrderList = JsonConvert.DeserializeObject<List<int>>(SortOrders);
            List<int> FieldIDList = JsonConvert.DeserializeObject<List<int>>(FieldIDs);
            int UserID = WebUtil.GetUser(context).UserID;
            var column_user_list = TableColumnsUser.GetTableColumnsUserListByUserID(UserID).ToList();
            var column_list = TableColumn.GetTableColumnByPageCode(PageCode, false);
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    string cmdtext = "update [TableColumnsUser] set IsShown=0 where [UserID]=@UserID and [TableColumnID] in (select [ID] from [TableColumns] where PageCode=@PageCode) and [TableColumnID] not in (" + string.Join(",", IDList.ToArray()) + ");";
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    parameters.Add(new SqlParameter("@PageCode", PageCode));
                    parameters.Add(new SqlParameter("@UserID", UserID));
                    helper.Execute(cmdtext, CommandType.Text, parameters);
                    foreach (var item in column_list)
                    {
                        var my_column_user = column_user_list.FirstOrDefault(p => p.TableColumnID == item.ID);
                        if (my_column_user == null)
                        {
                            my_column_user = new TableColumnsUser();
                            my_column_user.UserID = UserID;
                            my_column_user.TableColumnID = item.ID;
                            my_column_user.SortOrder = item.SortOrder;
                            my_column_user.IsShown = false;
                            my_column_user.Save(helper);
                            column_user_list.Add(my_column_user);
                        }
                    }
                    for (int i = 0; i < IDList.Count; i++)
                    {
                        int ID = IDList[i];
                        if (ID <= 0)
                        {
                            continue;
                        }
                        int SortOrder = SortOrderList[i];
                        var my_column_user = column_user_list.FirstOrDefault(p => p.TableColumnID == ID);
                        if (my_column_user == null)
                        {
                            my_column_user = new TableColumnsUser();
                            my_column_user.UserID = UserID;
                            my_column_user.TableColumnID = ID;
                        }
                        my_column_user.SortOrder = SortOrder;
                        my_column_user.IsShown = true;
                        my_column_user.Save(helper);
                    }
                    if (!string.IsNullOrEmpty(TableName))
                    {
                        if (TableName.Equals(Utility.EnumModel.DefineFieldTableName.RoomBasic.ToString()))
                        {
                            cmdtext = " update [DefineField] set IsShown=0 where (Table_Name=@TableName or Table_Name='RoomPhoneRelation');";
                        }
                        else
                        {
                            cmdtext = " update [DefineField] set IsShown=0 where Table_Name=@TableName;";
                        }
                        for (int i = 0; i < FieldIDList.Count; i++)
                        {
                            if (FieldIDList[i] <= 0)
                            {
                                continue;
                            }
                            cmdtext += " update [DefineField] set IsShown=1,SortOrder=" + SortOrderList[i] + " where ID=" + FieldIDList[i] + ";";
                        }
                        parameters = new List<SqlParameter>();
                        parameters.Add(new SqlParameter("@TableName", TableName));
                        helper.Execute(cmdtext, CommandType.Text, parameters);
                    }
                    helper.Commit();
                    context.Response.Write(JsonConvert.SerializeObject(new { status = true }));
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    Utility.LogHelper.WriteError("SysSettingHandler", "命令: savetablefield", ex);
                    context.Response.Write(JsonConvert.SerializeObject(new { status = false }));
                }
            }
        }
        private void gettablefield(HttpContext context)
        {
            try
            {
                string PageCode = context.Request.Params["PageCode"];
                string TableName = context.Request.Params["TableName"];
                var list = Foresight.DataAccess.TableColumn.GetTableColumnByPageCode(PageCode, false);
                var results = new List<Dictionary<string, object>>();
                var dic_list = new List<Dictionary<string, object>>();
                var dic = new Dictionary<string, object>();
                bool has_define_filed = false;
                if (string.IsNullOrEmpty(TableName))
                {
                    dic_list = list.Select(p =>
                    {
                        dic = p.ToJsonObject();
                        dic["FieldID"] = 0;
                        dic["GroupName"] = p.FinalGroupName;
                        return dic;
                    }).ToList();
                }
                else
                {
                    var all_fieldlist = Foresight.DataAccess.DefineField.GetDefineFieldsByTable_Name(TableName, 0);
                    dic_list = list.Select(p =>
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
                       dic = p.ToJsonObject();
                       if (exist_field != null)
                       {
                           dic["FieldID"] = exist_field.ID;
                       }
                       else
                       {
                           dic["FieldID"] = 0;
                       }
                       dic["GroupName"] = p.FinalGroupName;
                       return dic;
                   }).ToList();
                    var fieldlist = all_fieldlist.Where(p => string.IsNullOrEmpty(p.ColumnName));
                    foreach (var item in fieldlist)
                    {
                        dic = new Dictionary<string, object>();
                        dic["ID"] = 0;
                        dic["FieldID"] = item.ID;
                        dic["PageCode"] = PageCode;
                        dic["ColumnField"] = "field: '" + item.FieldName + "', title: '" + item.FieldName + "', width: 150";
                        dic["SortOrder"] = item.SortOrder < 0 ? 0 : item.SortOrder;
                        dic["IsShown"] = item.IsShown;
                        dic["ColumnName"] = item.FieldName;
                        dic["GroupName"] = "自定义信息";
                        dic["IsNecessary"] = false;
                        dic_list.Add(dic);
                        has_define_filed = true;
                    }
                }
                dic_list = dic_list.OrderBy(p => p["SortOrder"]).ToList();
                var GroupNameArray = new List<string>();
                foreach (var item in dic_list)
                {
                    if (!item.ContainsKey("GroupName"))
                    {
                        continue;
                    }
                    string GroupName = item["GroupName"].ToString();
                    if (GroupName.Equals("自定义信息"))
                    {
                        continue;
                    }
                    if (!string.IsNullOrEmpty(GroupName) && !GroupNameArray.Contains(GroupName))
                    {
                        GroupNameArray.Add(GroupName);
                    }
                }
                foreach (var GroupName in GroupNameArray)
                {
                    dic = new Dictionary<string, object>();
                    dic["Title"] = GroupName;
                    var my_list = dic_list.Where(p => p["GroupName"].ToString().Equals(GroupName)).OrderBy(p => p["SortOrder"]).ToList();
                    dic["list"] = my_list;
                    results.Add(dic);
                }
                string DefaultGrounName = string.Empty;
                if (GroupNameArray.Count > 0)
                {
                    DefaultGrounName = "其他信息";
                }
                else if (has_define_filed)
                {
                    DefaultGrounName = "基本信息";
                }
                var other_list = dic_list.Where(p => string.IsNullOrEmpty(p["GroupName"].ToString())).OrderBy(p => p["SortOrder"]).ToList();
                dic = new Dictionary<string, object>();
                dic["Title"] = DefaultGrounName;
                dic["list"] = other_list;
                results.Add(dic);
                var define_list = dic_list.Where(p => p["GroupName"].ToString().Equals("自定义信息")).OrderBy(p => p["SortOrder"]).ToList();
                dic = new Dictionary<string, object>();
                dic["Title"] = "自定义信息";
                dic["list"] = define_list;
                results.Add(dic);
                var items = new
                {
                    status = true,
                    list = results,
                };
                WebUtil.WriteJson(context, items);
            }
            catch (Exception)
            {
                var items = new
                {
                    status = false,
                };
                context.Response.Write(JsonConvert.SerializeObject(items));
            }
        }
        private void deleteordernumber(HttpContext context)
        {
            string ids = context.Request.Params["ids"];
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(ids);
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    string cmdtext = "delete from [Sys_OrderNumber] where ID in (" + string.Join(",", IDList.ToArray()) + ")";
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    helper.Execute(cmdtext, CommandType.Text, parameters);
                    helper.Commit();
                    context.Response.Write("{\"status\":true}");
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    Utility.LogHelper.WriteError("SysSettingHandler", "命令: deleteordernumber", ex);
                    context.Response.Write("{\"status\":false}");
                }
            }
        }
        private void saveordernumber(HttpContext context)
        {
            string id = context.Request.Params["id"];
            string OrderTypeName = context.Request.Params["OrderTypeName"];
            int OrderNumberCount = int.Parse(context.Request.Params["OrderNumberCount"]);
            int UseYear = int.Parse(context.Request.Params["UseYear"]);
            int UseMonth = int.Parse(context.Request.Params["UseMonth"]);
            int UseDay = int.Parse(context.Request.Params["UseDay"]);
            int IsYearReset = WebUtil.GetIntValue(context, "IsYearReset");
            int IsMonthReset = WebUtil.GetIntValue(context, "IsMonthReset");
            int IsDayReset = WebUtil.GetIntValue(context, "IsDayReset");
            string Prefix = context.Request.Params["Prefix"];
            string OrderPreview = context.Request.Params["OrderPreview"];
            string Remark = context.Request.Params["Remark"];
            string AddMan = context.Request.Params["AddMan"];
            Sys_OrderNumber orderNumber = null;
            if (!string.IsNullOrEmpty(id))
            {
                orderNumber = Sys_OrderNumber.GetSys_OrderNumber(int.Parse(id));
            }
            if (orderNumber == null)
            {
                orderNumber = new Sys_OrderNumber();
            }
            orderNumber.OrderTypeName = OrderTypeName;
            orderNumber.OrderNumberCount = OrderNumberCount;
            orderNumber.UseYear = UseYear == 1 ? true : false;
            orderNumber.UseMonth = UseMonth == 1 ? true : false;
            orderNumber.UseDay = UseDay == 1 ? true : false;
            orderNumber.OrderPrefix = Prefix;
            orderNumber.OrderPreview = GenerateOrderPreview(orderNumber);
            orderNumber.Remark = Remark;
            orderNumber.AddMan = AddMan;
            orderNumber.ChargeType = WebUtil.GetIntValue(context, "ChargeType");
            orderNumber.IsYearReset = IsYearReset == 1 ? true : false;
            orderNumber.IsMonthReset = IsMonthReset == 1 ? true : false;
            orderNumber.IsDayReset = IsDayReset == 1 ? true : false;
            orderNumber.Save();
            context.Response.Write("{\"status\":true}");
        }
        private string GenerateOrderPreview(Sys_OrderNumber orderNumber)
        {
            string orderPreview = orderNumber.OrderPrefix;
            if (orderNumber.UseYear)
            {
                orderPreview += DateTime.Now.ToString("yyyy");
            }
            if (orderNumber.UseMonth)
            {
                orderPreview += DateTime.Now.ToString("MM");
            }
            if (orderNumber.UseDay)
            {
                orderPreview += DateTime.Now.ToString("dd");
            }
            Random ran = new Random();
            int start = Convert.ToInt32(Math.Pow(10, (orderNumber.OrderNumberCount - 1)));
            int end = Convert.ToInt32(Math.Pow(10, (orderNumber.OrderNumberCount))) - 1;
            orderPreview += ran.Next(start, end).ToString();
            return orderPreview;
        }
        private void loadordernumberlist(HttpContext context)
        {
            try
            {
                var list = Sys_OrderNumber.GetSys_OrderNumbers();
                var dg = new DataGrid();
                dg.rows = list;
                dg.total = list.Count;
                dg.page = 1;
                string result = JsonConvert.SerializeObject(dg);
                context.Response.Write(result);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.WriteError("SysSettingHandler", "命令: loadordernumberlist", ex);
                context.Response.Write("{\"rows\":[],\"total\":0,\"page\":0}");
            }
        }
        private void deletechargemoneytype(HttpContext context)
        {
            string ids = context.Request.Params["ids"];
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(ids);
            int count = Foresight.DataAccess.RoomFeeHistory.GetPrintRoomFeeHistoryListCountByChargeTypeIDList(IDList);
            if (count > 0)
            {
                WebUtil.WriteJson(context, new { status = false, error = "选中的收款方式已使用，操作取消" });
                return;
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    string cmdtext = "delete from [ChargeMoneyType] where ChargeTypeID in (" + string.Join(",", IDList.ToArray()) + ")";
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    helper.Execute(cmdtext, CommandType.Text, parameters);
                    helper.Commit();
                    context.Response.Write("{\"status\":true}");
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    Utility.LogHelper.WriteError("SysSettingHandler", "命令: deletechargemoneytype", ex);
                    context.Response.Write("{\"status\":false}");
                }
            }
        }
        private void savechargemoneytype(HttpContext context)
        {
            string id = context.Request.Params["id"];
            string name = context.Request.Params["name"];
            string sortorder = context.Request.Params["sortorder"];
            ChargeMoneyType chargeMoneyType = null;
            if (!string.IsNullOrEmpty(id))
            {
                chargeMoneyType = ChargeMoneyType.GetChargeMoneyType(int.Parse(id));
            }
            if (chargeMoneyType == null)
            {
                chargeMoneyType = new ChargeMoneyType();
            }
            chargeMoneyType.ChargeTypeName = name;
            int _sortorder = int.MinValue;
            int.TryParse(sortorder, out _sortorder);
            chargeMoneyType.SortOrder = _sortorder;
            chargeMoneyType.Save();
            context.Response.Write("{\"status\":true}");
        }
        private void loadchargemoneytype(HttpContext context)
        {
            try
            {
                var list = ChargeMoneyType.GetChargeMoneyTypes();
                var dg = new DataGrid();
                dg.rows = list;
                dg.total = list.Count;
                dg.page = 1;
                string result = JsonConvert.SerializeObject(dg);
                context.Response.Write(result);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.WriteError("SysSettingHandler", "命令: loadchargemoneytype", ex);
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
    public class ChargeBiaoModel
    {
        public int ID { get; set; }
        public string BiaoCategory { get; set; }
    }
}