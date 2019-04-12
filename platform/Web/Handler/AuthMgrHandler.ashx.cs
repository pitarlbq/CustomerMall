using Foresight.DataAccess;
using Foresight.DataAccess.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.SessionState;
using Utility;

namespace Web.Handler
{
    /// <summary>
    /// AuthMgrHandler 的摘要说明
    /// </summary>
    public class AuthMgrHandler : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string visit = context.Request.Params["visit"];
            if (string.IsNullOrEmpty(visit))
            {
                LogHelper.WriteDebug("AuthMgrHandler", "visit为空");
                context.Response.Write(null);
                return;
            }
            visit = visit.ToLower();
            try
            {
                switch (visit)
                {
                    case "operationtree":
                        operationTree(context);
                        break;
                    case "saveoperation":
                        saveoperation(context);
                        break;
                    case "loadoperation":
                        LoadOperation(context);
                        break;
                    case "loaduserroletree":
                        loaduserroletree(context);
                        break;
                    case "loadusertree":
                        loadusertree(context);
                        break;
                    case "getprojecttree":
                        GetProjectTree(context);
                        break;
                    case "saveuserprojecttree":
                        saveuserprojecttree(context);
                        break;
                    case "getprojectordernumbertree":
                        GetProjectOrderNumberTree(context);
                        break;
                    case "saveprojectordernumber":
                        saveProjectOrderNumber(context);
                        break;
                    case "getanalysistree":
                        getanalysistree(context);
                        break;
                    case "saveanalysisuser":
                        saveanalysisuser(context);
                        break;
                    case "gettopprojecttree":
                        gettopprojecttree(context);
                        break;
                    case "savemsgproject":
                        savemsgproject(context);
                        break;
                    case "companytree":
                        companytree(context);
                        break;
                    case "loadcompanyoperation":
                        LoadCompanyOperation(context);
                        break;
                    case "savecompanymodule":
                        savecompanymodule(context);
                        break;
                    case "operationcompanytree":
                        operationCompanyTree(context);
                        break;
                    case "getckcategorytree":
                        getckcategorytree(context);
                        break;
                    case "saveuserckcategory":
                        saveuserckcategory(context);
                        break;
                    case "getprojectbylevel":
                        getprojectbylevel(context);
                        break;
                    case "getcompanytree":
                        getcompanytree(context);
                        break;
                    case "savesysmsgcompany":
                        savesysmsgcompany(context);
                        break;
                    case "gettopprojecttreebywechatcontractid":
                        gettopprojecttreebywechatcontractid(context);
                        break;
                    case "savewechatcontactproject":
                        savewechatcontactproject(context);
                        break;
                    default:
                        WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "Unkown Visit: " + visit);
                        break;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("AuthMgrHandler", "visit: " + visit, ex);
                context.Response.Write("{\"status\":false}");
            }
        }
        private void savesysmsgcompany(HttpContext context)
        {
            int MsgID = WebUtil.GetIntValue(context, "MsgID");
            string IDList = context.Request.Params["IdList"];
            if (string.IsNullOrEmpty(IDList))
            {
                WebUtil.WriteJson(context, new { status = false, error = "请选择公司" });
                return;
            }
            var msg = Foresight.DataAccess.SystemMsg.GetSystemMsg(MsgID);
            if (msg == null)
            {
                WebUtil.WriteJson(context, new { status = false, error = "MsgID不合法" });
                return;
            }
            string[] CompanyIDList = JsonConvert.DeserializeObject<string[]>(IDList);
            var sys_company_list = Foresight.DataAccess.SystemMsg_Company.GetSystemMsg_CompanyList(MsgID);
            var exist_companyid_list = sys_company_list.Select(p => p.CompanyID).ToList();
            var delete_sys_company_list = sys_company_list.Where(p => !CompanyIDList.Contains(p.CompanyID.ToString()));
            var msgcompany_list = new List<Foresight.DataAccess.SystemMsg_Company>();
            foreach (var CompanyIDStr in CompanyIDList)
            {
                int CompanyID = 0;
                int.TryParse(CompanyIDStr, out CompanyID);
                if (CompanyID > 0)
                {
                    if (!exist_companyid_list.Contains(CompanyID))
                    {
                        var msgcompany = new Foresight.DataAccess.SystemMsg_Company();
                        msgcompany.AddTime = DateTime.Now;
                        msgcompany.CompanyID = CompanyID;
                        msgcompany.SystemMsgID = MsgID;
                        msgcompany_list.Add(msgcompany);
                    }
                }
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    foreach (var item in msgcompany_list)
                    {
                        item.Save(helper);
                    }
                    foreach (var item in delete_sys_company_list)
                    {
                        item.Delete(helper);
                    }
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    LogHelper.WriteError("AuthMgrHandler", "savesysmsgcompany", ex);
                    helper.Rollback();
                    WebUtil.WriteJson(context, new { status = false });
                    return;
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void getcompanytree(HttpContext context)
        {
            int MsgID = 0;
            int.TryParse(context.Request.Params["MsgID"], out MsgID);
            var list = CompanyDetail.GetCompanyDetailTreeListByMsgID(MsgID).ToArray();
            List<Dictionary<string, object>> items = null;
            items = list.Select(p =>
            {
                bool ischecked = MsgID != 0 && p.MsgID == MsgID;
                var dic = p.ToJsonObject();
                if (p.CompanyID == 1)
                {
                    dic["id"] = p.CompanyID;
                    dic["pId"] = 0;
                    dic["open"] = true;
                    dic["checked"] = ischecked;
                }
                else
                {
                    dic["id"] = p.CompanyID;
                    dic["pId"] = 1;
                    dic["open"] = false;
                    dic["checked"] = ischecked;
                }
                dic["name"] = p.CompanyName;
                return dic;
            }).ToList();
            string result = JsonConvert.SerializeObject(items);
            context.Response.Write(result);
        }
        private void getprojectbylevel(HttpContext context)
        {
            int level = WebUtil.GetIntValue(context, "level");
            var projects = WebUtil.GetMyProjectsByLevel(level, WebUtil.GetUser(context).UserID);
            var items = projects.Select(p =>
            {
                var dic = new Dictionary<string, object>();
                dic["id"] = p.ID;
                dic["name"] = p.Name;
                dic["pId"] = p.ParentID;
                dic["open"] = true;
                dic["isParent"] = true;
                if (p.IconID == level)
                {
                    dic["isParent"] = false;
                }
                return dic;
            }).ToList();
            var top_dic = new Dictionary<string, object>();
            top_dic["id"] = 1;
            top_dic["name"] = WebUtil.GetCompany(context).CompanyName;
            top_dic["pId"] = 0;
            top_dic["open"] = true;
            top_dic["isParent"] = true;
            items.Add(top_dic);
            WebUtil.WriteJson(context, items);
        }
        private void saveuserckcategory(HttpContext context)
        {
            int RoleID = WebUtil.GetIntValue(context, "RoleID");
            int UserID = WebUtil.GetIntValue(context, "UserID");
            if (RoleID <= 0 && UserID <= 0)
            {
                WebUtil.WriteJson(context, new { status = false, error = "请选择用户或者角色" });
                return;
            }
            string[] IDArry = new string[] { };
            string IDList = context.Request.Params["IdList"];
            if (!string.IsNullOrEmpty(IDList))
            {
                IDArry = JsonConvert.DeserializeObject<string[]>(IDList);
            }
            string cmdtext = string.Empty;
            foreach (var item in IDArry)
            {
                int ModuleID = 0;
                int.TryParse(item, out ModuleID);
                if (ModuleID <= 0)
                {
                    continue;
                }
                cmdtext += "insert into [RoleCKCategory] (RoleID,CKCategoryID,UserID) values (" + RoleID + "," + ModuleID + "," + UserID + ");";
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    Foresight.DataAccess.RoleCKCategory.DeleteRoleCKCategory(RoleID, UserID, helper);
                    if (!string.IsNullOrEmpty(cmdtext))
                    {
                        helper.Execute(cmdtext, CommandType.Text, new List<SqlParameter>());
                    }
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    WebUtil.WriteJson(context, new { status = false, error = ex.Message });
                    return;
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void getckcategorytree(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            string Keywords = context.Request.Params["Keywords"];
            int RoleID = WebUtil.GetIntValue(context, "RoleID");
            int UserID = WebUtil.GetIntValue(context, "UserID");
            CKCategoryDetail[] list = CKCategoryDetail.GetProjectTreeListByID(ID, Keywords, RoleID, UserID).ToArray();
            List<Dictionary<string, object>> items = null;
            items = list.Select(p =>
            {
                var dic = p.ToJsonObject();
                dic["id"] = p.ID;
                dic["name"] = p.CategoryName;
                dic["pId"] = p.ParentID;
                bool hasChild = false;
                if (p.CategoryType.Equals(EnumModel.CKCategoryType.category.ToString()))
                {
                    //hasChild = productlist.Any(o => o.CategoryID == p.ID);
                }
                else
                {
                    hasChild = list.Any(o => o.ParentID == p.ID);
                }
                dic["open"] = hasChild;
                dic["checked"] = false;
                if (RoleID > 0)
                {
                    dic["checked"] = p.RoleID == RoleID;
                }
                if (UserID > 0)
                {
                    dic["checked"] = p.UserID == UserID;
                }
                return dic;
            }).ToList();
            Dictionary<string, object> companyModule = new Dictionary<string, object>();
            companyModule["id"] = 1;
            companyModule["pId"] = 0;
            companyModule["name"] = WebUtil.GetCompany(context).CompanyName;
            bool hasckChild = list.Any(o => o.ParentID == 1);
            companyModule["open"] = hasckChild;
            items.Add(companyModule);
            string result = JsonConvert.SerializeObject(items);
            context.Response.Write(result);
        }
        private void savecompanymodule(HttpContext context)
        {
            int CompanyID = WebUtil.GetIntValue(context, "CompanyID");
            if (CompanyID <= 0)
            {
                context.Response.Write("{\"status\":0}");
                return;
            }
            string IDList = context.Request.Params["IdList"];
            if (string.IsNullOrEmpty(IDList))
            {
                context.Response.Write("{\"status\":1}");
                return;
            }
            var company = Foresight.DataAccess.Company.GetCompany(CompanyID);
            string[] IDArry = IDList.Split(',');
            Foresight.DataAccess.CompanyModule.DeleteCompanyModuleByRoleId(CompanyID);
            foreach (var item in IDArry)
            {
                if (string.IsNullOrEmpty(item))
                {
                    continue;
                }
                Foresight.DataAccess.CompanyModule.InsertCompanyModule(CompanyID, int.Parse(item));
            }
            try
            {
                var opertaion_log = new Foresight.DataAccess.OperationLog();
                opertaion_log.OperationTime = DateTime.Now;
                opertaion_log.OperationMan = WebUtil.GetUser(context).LoginName;
                opertaion_log.OperationContent = string.Join(",", IDArry.ToArray());
                opertaion_log.OperationKey = Utility.EnumModel.OperationModule.CompanyModule.ToString();
                opertaion_log.IsHide = true;
                opertaion_log.Save();
            }
            catch (Exception)
            {
            }
            //通知后台
            APPCode.SocketNotify.PushSocketNotifyAlert(Utility.EnumModel.SocketNotifyDefine.notifyclearcache, url: company.BaseURL);
            context.Response.Write("{\"status\":2}");
        }
        private void LoadCompanyOperation(HttpContext context)
        {
            string CompanyID = context.Request.Params["CompanyID"];
            Foresight.DataAccess.CompanyModule[] roleModule = Foresight.DataAccess.CompanyModule.GetCompanyModuleListByCompanyID(int.Parse(CompanyID));
            string JsonValue = JsonConvert.SerializeObject(roleModule);
            context.Response.Write(JsonValue);
        }
        private void companytree(HttpContext context)
        {
            string keywords = context.Request["keywords"];
            Foresight.DataAccess.Company[] companys = Foresight.DataAccess.Company.GetCompanyListByKeywords(keywords).Where(p => (p.IsActive)).ToArray();
            var company = WebUtil.GetCompany(context);
            if (company != null)
            {
                foreach (var item in companys)
                {
                    if (item.BaseURL.ToLower().Equals(company.BaseURL.ToLower()))
                    {
                        item.CompanyName = company.CompanyName;
                    }
                }
            }
            StringBuilder sb = new StringBuilder("[{");
            sb.Append(string.Format("\"id\":\"{0}\",\"text\":\"{1}\"", "0", "所有公司"));
            if (companys.Length > 0)
            {
                sb.Append(",");
                sb.Append("\"children\":");
                sb.Append("[{");
                for (int i = 0; i < companys.Length; i++)
                {
                    sb.Append(string.Format("\"id\":\"{0}\",\"text\":\"{1}\"", companys[i].CompanyID, companys[i].CompanyName));
                    if (i != companys.Length - 1)
                    {
                        sb.Append("},{");
                    }
                }
                sb.Append("}]");
            }
            sb.Append("}]");
            string result = sb.ToString();
            context.Response.Write(result);
        }
        private void savemsgproject(HttpContext context)
        {

            int MsgID = WebUtil.GetIntValue(context, "MsgID");
            string IDList = context.Request.Params["IdList"];
            if (string.IsNullOrEmpty(IDList))
            {
                context.Response.Write("{\"status\":2}");
                return;
            }
            string[] IDArry = JsonConvert.DeserializeObject<string[]>(IDList);
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    parameters.Add(new SqlParameter("@MsgID", MsgID));
                    string cmdtext = "delete from [Wechat_MsgProject] where [MsgID]=@MsgID;";
                    foreach (var item in IDArry)
                    {
                        cmdtext += "insert into [Wechat_MsgProject] ([MsgID],[ProjectID]) values (" + MsgID + "," + int.Parse(item) + ");";
                    }
                    helper.Execute(cmdtext, CommandType.Text, parameters);
                    helper.Commit();
                    context.Response.Write("{\"status\":1}");
                }
                catch (Exception ex)
                {
                    LogHelper.WriteError("AuthMgrHandler", "savemsgproject", ex);
                    helper.Rollback();
                    context.Response.Write("{\"status\":0}");
                }
            }
        }
        private void savewechatcontactproject(HttpContext context)
        {

            int ContactID = WebUtil.GetIntValue(context, "ContactID");
            string IDList = context.Request.Params["IdList"];
            if (string.IsNullOrEmpty(IDList))
            {
                context.Response.Write("{\"status\":2}");
                return;
            }
            string[] IDArry = JsonConvert.DeserializeObject<string[]>(IDList);
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    parameters.Add(new SqlParameter("@ContactID", ContactID));
                    string cmdtext = "delete from [Wechat_ContactProject] where [WechatContactID]=@ContactID;";
                    foreach (var item in IDArry)
                    {
                        cmdtext += "insert into [Wechat_ContactProject] ([WechatContactID],[ProjectID]) values (" + ContactID + "," + int.Parse(item) + ");";
                    }
                    helper.Execute(cmdtext, CommandType.Text, parameters);
                    helper.Commit();
                    context.Response.Write("{\"status\":1}");
                }
                catch (Exception ex)
                {
                    LogHelper.WriteError("AuthMgrHandler", "savewechatcontactproject", ex);
                    helper.Rollback();
                    context.Response.Write("{\"status\":0}");
                }
            }
        }
        private void gettopprojecttree(HttpContext context)
        {
            int CompanyID = 0;
            int.TryParse(context.Request.Params["CompanyID"], out CompanyID);
            int MsgID = 0;
            int.TryParse(context.Request.Params["MsgID"], out MsgID);
            string ProjectIDs = context.Request["ProjectIDs"];
            int UserID = WebUtil.GetUser(context).UserID;
            int ContactID = WebUtil.GetIntValue(context, "ContactID");
            List<int> ProjectIDList = new List<int>();
            if (!string.IsNullOrEmpty(ProjectIDs))
            {
                ProjectIDList = JsonConvert.DeserializeObject<List<int>>(ProjectIDs);
            }
            var list = ProjectTree.GetProjectTreeListByMsgID(CompanyID, MsgID, UserID).ToArray();
            List<Dictionary<string, object>> items = null;
            items = list.Select(p =>
            {
                bool ischecked = MsgID != 0 && p.MsgID == MsgID;
                if (ProjectIDList.Count > 0 && ProjectIDList.Contains(p.ID))
                {
                    ischecked = true;
                }
                var dic = p.ToJsonObject();
                if (p.ID == 1)
                {
                    var company = Company.GetCompany(CompanyID);
                    dic["name"] = company.CompanyName;
                }
                else
                {
                    dic["name"] = p.Name;
                }
                dic["id"] = p.ID;
                dic["pId"] = p.ParentID;
                dic["iconSkin"] = "Icon_" + p.IconID;
                dic["open"] = true;
                dic["checked"] = ischecked;
                return dic;
            }).ToList();
            string result = JsonConvert.SerializeObject(items);
            context.Response.Write(result);
        }
        private void gettopprojecttreebywechatcontractid(HttpContext context)
        {
            int CompanyID = 0;
            int.TryParse(context.Request.Params["CompanyID"], out CompanyID);
            string ProjectIDs = context.Request["ProjectIDs"];
            int UserID = WebUtil.GetUser(context).UserID;
            int ContactID = WebUtil.GetIntValue(context, "ContactID");
            List<int> ProjectIDList = new List<int>();
            if (!string.IsNullOrEmpty(ProjectIDs))
            {
                ProjectIDList = JsonConvert.DeserializeObject<List<int>>(ProjectIDs);
            }
            var list = ProjectTree.GetProjectTreeListByContactID(CompanyID, ContactID, UserID).ToArray();
            List<Dictionary<string, object>> items = null;
            items = list.Select(p =>
            {
                bool ischecked = ContactID != 0 && p.MsgID == ContactID;
                if (ProjectIDList.Count > 0 && ProjectIDList.Contains(p.ID))
                {
                    ischecked = true;
                }
                var dic = p.ToJsonObject();
                if (p.ID == 1)
                {
                    var company = Company.GetCompany(CompanyID);
                    dic["name"] = company.CompanyName;
                }
                else
                {
                    dic["name"] = p.Name;
                }
                dic["id"] = p.ID;
                dic["pId"] = p.ParentID;
                dic["iconSkin"] = "Icon_" + p.IconID;
                dic["open"] = true;
                dic["checked"] = ischecked;
                return dic;
            }).ToList();
            string result = JsonConvert.SerializeObject(items);
            context.Response.Write(result);
        }
        private void saveanalysisuser(HttpContext context)
        {
            string IDList = context.Request.Params["IdList"];
            string[] IDArry = new string[] { };
            if (!string.IsNullOrEmpty(IDList))
            {
                IDArry = JsonConvert.DeserializeObject<string[]>(IDList);
            }
            if (IDArry.Length == 0)
            {
                WebUtil.WriteJson(context, new { status = false, error = "请选择看板配置项" });
                return;
            }
            int UserID = WebUtil.GetUser(context).UserID;
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    string cmdtext = "delete from [AnalysisSummaryUser] where [UserID]=@UserID;";
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    foreach (var ID in IDArry)
                    {
                        if (string.IsNullOrEmpty(ID))
                        {
                            continue;
                        }
                        cmdtext += "insert into [AnalysisSummaryUser] ([SummaryID],[UserID]) values(" + ID + "," + UserID + ");";
                    }
                    parameters.Add(new SqlParameter("@UserID", UserID));
                    helper.Execute(cmdtext, CommandType.Text, parameters);
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError("AuthMgrHandler", "visit: saveanalysisuser", ex);
                    WebUtil.WriteJson(context, new { status = false });
                    return;
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void getanalysistree(HttpContext context)
        {
            int CompanyID = WebUtil.GetIntValue(context, "CompanyID");
            int UserID = WebUtil.GetUser(context).UserID;
            AnalysisSummaryDetail[] list = AnalysisSummaryDetail.GetAnalysisSummaryTreeListByID(UserID).ToArray();
            List<Dictionary<string, object>> items = list.Select(p =>
            {
                var dic = p.ToJsonObject();
                dic["name"] = p.AnalysisName;
                dic["id"] = p.ID;
                dic["pId"] = p.PID;
                dic["nocheck"] = p.PID == 0;
                dic["open"] = true;
                dic["checked"] = p.UserID == UserID;
                return dic;
            }).ToList();
            Dictionary<string, object> newdic = new Dictionary<string, object>();
            var company = Company.GetCompany(CompanyID);
            newdic["name"] = company.CompanyName;
            newdic["id"] = 0;
            newdic["pId"] = -1;
            newdic["open"] = true;
            newdic["nocheck"] = true;
            items.Add(newdic);
            WebUtil.WriteJson(context, items);
        }
        private void saveProjectOrderNumber(HttpContext context)
        {
            int OrderNumberID = 0;
            int.TryParse(context.Request.Params["OrderNumberID"], out OrderNumberID);
            if (OrderNumberID == 0)
            {
                context.Response.Write("{\"status\":false}");
                return;
            }
            string IDs = context.Request.Params["IdList"];
            int[] IDArry = JsonConvert.DeserializeObject<int[]>(IDs);
            Foresight.DataAccess.ProjectOrderNumber.DeleteProjectOrderNumberOrderNumberID(OrderNumberID);
            foreach (var ProjectID in IDArry)
            {
                Foresight.DataAccess.ProjectOrderNumber.InsertProjectOrderNumber(ProjectID, OrderNumberID);
            }
            context.Response.Write("{\"status\":true}");
        }
        private void saveuserprojecttree(HttpContext context)
        {
            int UserID = WebUtil.GetIntValue(context, "UserID");
            int RoleID = WebUtil.GetIntValue(context, "RoleID");
            Foresight.DataAccess.User user = null;
            Foresight.DataAccess.Role role = null;
            if (UserID > 0)
            {
                user = User.GetUser(UserID);
            }
            if (RoleID > 0)
            {
                role = Role.GetRole(RoleID);
            }
            string[] IDArry = new string[] { };
            string IDList = context.Request.Params["IdList"];
            if (!string.IsNullOrEmpty(IDList))
            {
                IDArry = JsonConvert.DeserializeObject<string[]>(IDList);
            }
            string cmdtext = string.Empty;
            foreach (var item in IDArry)
            {
                int ProjectID = 0;
                int.TryParse(item, out ProjectID);
                if (ProjectID <= 0)
                {
                    continue;
                }
                cmdtext += "insert into [RoleProject] (RoleID,ProjectID,UserID) values (" + RoleID + "," + ProjectID + "," + UserID + ");";
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    Foresight.DataAccess.RoleProject.DeleteRoleProjectRoleId(RoleID, UserID, helper);
                    if (!string.IsNullOrEmpty(cmdtext))
                    {
                        helper.Execute(cmdtext, CommandType.Text, new List<SqlParameter>());
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
            try
            {
                #region 权限修改日志
                string name = role != null ? "角色" + role.RoleName : string.Empty;
                name = user != null ? "用户" + user.LoginName : name;
                string LogID = role != null ? role.RoleID.ToString() : string.Empty;
                LogID = user != null ? "用户" + user.UserID.ToString() : name;
                APPCode.CommHelper.SaveOperationLog(string.Join(",", IDArry.ToArray()), Utility.EnumModel.OperationModule.RoleProject.ToString(), "资源权限", LogID, "RoleProject", IsHide: true);
                APPCode.CommHelper.SaveOperationLog(name + "权限修改", Utility.EnumModel.OperationModule.RoleProject.ToString(), "权限修改", LogID, "RoleProject");
                Web.APPCode.CacheHelper.RemoveMyViewProjectTree();
                #endregion
            }
            catch (Exception)
            {
            }
            WebUtil.WriteJson(context, new { status = true });

        }
        private void GetIDList(Project[] projectlist, out int[] ChildProjectID, out int[] ParentProjectID)
        {
            List<int> resultChild = new List<int>();
            List<int> resultParent = new List<int>();
            List<int> resultRoom = new List<int>();
            List<int> idarry = new List<int>();
            List<int> pidarray = new List<int>();
            foreach (var item in projectlist)
            {
                idarry.Add(item.ID);
                if (!pidarray.Contains(item.ParentID))
                {
                    pidarray.Add(item.ParentID);
                }
            }
            int max = pidarray.Max() + 1;
            bool[] temp = new bool[max];
            for (var i = 0; i < pidarray.Count; i++)
            {
                temp[pidarray[i]] = true;
            };
            for (var i = 0; i < idarry.Count; i++)
            {
                if (idarry[i] >= max)
                {
                    resultChild.Add(idarry[i]);
                }
                else if (!temp[idarry[i]])
                {
                    resultChild.Add(idarry[i]);
                }
                else
                {
                    resultParent.Add(idarry[i]);
                }
            }
            ChildProjectID = resultChild.ToArray();
            ParentProjectID = resultParent.ToArray();
        }
        private void GetProjectOrderNumberTree(HttpContext context)
        {
            int CompanyID = 0;
            int.TryParse(context.Request.Params["CompanyID"], out CompanyID);
            int ID = 0;
            int.TryParse(context.Request.Params["ID"], out ID);
            string Keywords = context.Request.Params["Keywords"];
            int OrderNumberID = 0;
            int.TryParse(context.Request.Params["OrderNumberID"], out OrderNumberID);
            int Level = 0;
            int.TryParse(context.Request.Params["Level"], out Level);
            if (Level <= 0)
            {
                Level = 2;
            }
            int UserID = WebUtil.GetUser(context).UserID;
            ProjectTree[] list = ProjectTree.GetProjectTreeListByOrderNumberID(ID, Keywords, OrderNumberID, Level, UserID).ToArray();
            List<Dictionary<string, object>> items = null;
            if (string.IsNullOrEmpty(Keywords))
            {
                items = list.Select(p =>
                {
                    var dic = p.ToJsonObject();
                    if (p.ID == 1)
                    {
                        var company = Company.GetCompany(CompanyID);
                        dic["name"] = company.CompanyName;
                    }
                    else
                    {
                        dic["name"] = p.Name;
                    }
                    dic["id"] = p.ID;
                    dic["pId"] = p.ParentID;
                    dic["iconSkin"] = "Icon_" + p.IconID;
                    dic["open"] = true;
                    dic["checked"] = OrderNumberID != 0 && p.OrderNumberID == OrderNumberID;
                    if (p.IconID == Level)
                    {
                        dic["isParent"] = false;
                    }
                    return dic;
                }).ToList();
            }
            else
            {
                items = list.Select(p =>
                {
                    var dic = p.ToJsonObject();
                    if (p.ID == 1)
                    {
                        var company = Company.GetCompany(CompanyID);
                        dic["name"] = company.CompanyName;
                    }
                    else
                    {
                        dic["name"] = p.FullName + p.Name;
                    }
                    dic["id"] = p.ID;
                    dic["pId"] = p.ParentID;
                    dic["iconSkin"] = "Icon_" + p.IconID;
                    dic["open"] = true;
                    dic["checked"] = OrderNumberID != 0 && p.OrderNumberID == OrderNumberID;
                    if (p.IconID == Level)
                    {
                        dic["isParent"] = false;
                    }
                    return dic;
                }).ToList();
            }
            string result = JsonConvert.SerializeObject(items);
            context.Response.Write(result);
        }
        private void loadusertree(HttpContext context)
        {
            var list = Foresight.DataAccess.User.GetALLModuleUserList();
            StringBuilder sb = new StringBuilder("[{");
            sb.Append(string.Format("\"id\":\"{0}\",\"text\":\"{1}\"", "0", "所有用户"));
            if (list.Length > 0)
            {
                sb.Append(",");
                sb.Append("\"children\":");
                sb.Append("[{");
                for (int i = 0; i < list.Length; i++)
                {
                    sb.Append(string.Format("\"id\":\"{0}\",\"text\":\"{1}\"", list[i].UserID, list[i].FinalRealName));
                    if (i != list.Length - 1)
                    {
                        sb.Append("},{");
                    }
                }
                sb.Append("}]");
            }
            sb.Append("}]");
            string result = sb.ToString();
            WebUtil.WriteJson(context, result);
        }
        private void loaduserroletree(HttpContext context)
        {
            Foresight.DataAccess.Role[] role = Foresight.DataAccess.Role.GetAdminNotInRoleList(0);
            StringBuilder sb = new StringBuilder("[{");
            sb.Append(string.Format("\"id\":\"{0}\",\"text\":\"{1}\"", "0", "所有角色"));
            if (role.Length > 0)
            {
                sb.Append(",");
                sb.Append("\"children\":");
                sb.Append("[{");
                for (int i = 0; i < role.Length; i++)
                {
                    sb.Append(string.Format("\"id\":\"{0}\",\"text\":\"{1}\"", role[i].RoleID, role[i].RoleName));
                    if (i != role.Length - 1)
                    {
                        sb.Append("},{");
                    }
                }
                sb.Append("}]");
            }
            sb.Append("}]");
            string result = sb.ToString();
            context.Response.Write(result);
        }
        private void operationCompanyTree(HttpContext context)
        {
            StringBuilder sb = new StringBuilder("[");
            string GroupName = Utility.EnumModel.SysMenuGroupNameDefine.wynk.ToString();
            string sub_result = get_operation_tree_str(context, GroupName, -1, usecompany: true);
            sb.Append(sub_result);

            GroupName = Utility.EnumModel.SysMenuGroupNameDefine.appgl.ToString();
            sub_result = get_operation_tree_str(context, GroupName, -4, usecompany: true);
            if (!string.IsNullOrEmpty(sub_result))
            {
                sb.Append(",");
                sb.Append(sub_result);
            }

            GroupName = Utility.EnumModel.SysMenuGroupNameDefine.jygl.ToString();
            sub_result = get_operation_tree_str(context, GroupName, -2, usecompany: true);
            if (!string.IsNullOrEmpty(sub_result))
            {
                sb.Append(",");
                sb.Append(sub_result);
            }

            GroupName = Utility.EnumModel.SysMenuGroupNameDefine.jspt.ToString();
            sub_result = get_operation_tree_str(context, GroupName, -3, usecompany: true);
            if (!string.IsNullOrEmpty(sub_result))
            {
                sb.Append(",");
                sb.Append(sub_result);
            }

            GroupName = Utility.EnumModel.SysMenuGroupNameDefine.sjzx.ToString();
            sub_result = get_operation_tree_str(context, GroupName, -5, usecompany: true);
            if (!string.IsNullOrEmpty(sub_result))
            {
                sb.Append(",");
                sb.Append(sub_result);
            }

            GroupName = Utility.EnumModel.SysMenuGroupNameDefine.xtsz.ToString();
            sub_result = get_operation_tree_str(context, GroupName, -6, usecompany: true);
            if (!string.IsNullOrEmpty(sub_result))
            {
                sb.Append(",");
                sb.Append(sub_result);
            }

            GroupName = Utility.EnumModel.SysMenuGroupNameDefine.wynkapp.ToString();
            sub_result = get_operation_tree_str(context, GroupName, -7, usecompany: true);
            if (!string.IsNullOrEmpty(sub_result))
            {
                sb.Append(",");
                sb.Append(sub_result);
            }

            sb.Append("]");
            string result = sb.ToString();
            context.Response.Write(result);
        }
        public Foresight.DataAccess.SysMenu[] allcompanymenus = null;
        public string OperationCompanyJson(HttpContext context, int ParentID)
        {
            StringBuilder sb = new StringBuilder("");
            if (allcompanymenus == null)
            {
                allcompanymenus = Foresight.DataAccess.SysMenu.GetSysMenus().Where(p => !p.Disabled).OrderBy(p => p.SortOrder).ToArray();
            }
            Foresight.DataAccess.SysMenu[] sysMenu = allcompanymenus.Where(p => p.ParentID == ParentID).ToArray();
            if (sysMenu.Length > 0)
            {
                sb.Append(",");
                sb.Append("\"children\":");
                sb.Append("[");
                for (int i = 0; i < sysMenu.Length; i++)
                {
                    if (i == 0)
                    {
                        sb.Append("{");
                    }
                    else
                    {
                        sb.Append(",{");
                    }
                    var subMenus = allcompanymenus.Where(p => p.ParentID == sysMenu[i].ID).ToArray();
                    if (subMenus.Length > 0)
                    {
                        sb.Append(string.Format("\"id\":\"{0}\",\"name\":\"{1}\",\"description\":\"{2}\",\"state\":\"{3}\"", sysMenu[i].ID, sysMenu[i].Title, sysMenu[i].Description, "closed"));
                    }
                    else
                    {
                        sb.Append(string.Format("\"id\":\"{0}\",\"name\":\"{1}\",\"description\":\"{2}\"", sysMenu[i].ID, sysMenu[i].Title, sysMenu[i].Description));
                    }
                    sb.Append(OperationCompanyJson(context, sysMenu[i].ID));
                    sb.Append("}");
                }
                sb.Append("]");
            }
            string result = sb.ToString();
            return result;
        }
        private void operationTree(HttpContext context)
        {
            StringBuilder sb = new StringBuilder("[");
            string GroupName = Utility.EnumModel.SysMenuGroupNameDefine.wynk.ToString();
            string sub_result = get_operation_tree_str(context, GroupName, -1);
            sb.Append(sub_result);

            GroupName = Utility.EnumModel.SysMenuGroupNameDefine.appgl.ToString();
            sub_result = get_operation_tree_str(context, GroupName, -4);
            if (!string.IsNullOrEmpty(sub_result))
            {
                sb.Append(",");
                sb.Append(sub_result);
            }

            GroupName = Utility.EnumModel.SysMenuGroupNameDefine.jygl.ToString();
            sub_result = get_operation_tree_str(context, GroupName, -2);
            if (!string.IsNullOrEmpty(sub_result))
            {
                sb.Append(",");
                sb.Append(sub_result);
            }

            GroupName = Utility.EnumModel.SysMenuGroupNameDefine.jspt.ToString();
            sub_result = get_operation_tree_str(context, GroupName, -3);
            if (!string.IsNullOrEmpty(sub_result))
            {
                sb.Append(",");
                sb.Append(sub_result);
            }

            GroupName = Utility.EnumModel.SysMenuGroupNameDefine.sjzx.ToString();
            sub_result = get_operation_tree_str(context, GroupName, -5);
            if (!string.IsNullOrEmpty(sub_result))
            {
                sb.Append(",");
                sb.Append(sub_result);
            }

            GroupName = Utility.EnumModel.SysMenuGroupNameDefine.xtsz.ToString();
            sub_result = get_operation_tree_str(context, GroupName, -6);
            if (!string.IsNullOrEmpty(sub_result))
            {
                sb.Append(",");
                sb.Append(sub_result);
            }

            GroupName = Utility.EnumModel.SysMenuGroupNameDefine.wynkapp.ToString();
            sub_result = get_operation_tree_str(context, GroupName, -7);
            if (!string.IsNullOrEmpty(sub_result))
            {
                sb.Append(",");
                sb.Append(sub_result);
            }

            sb.Append("]");
            string result = sb.ToString();
            context.Response.Write(result);
        }
        public string get_operation_tree_str(HttpContext context, string GroupName, int id, bool usecompany = false)
        {
            var allmenus = getallmenus(context, GroupName, usecompany: usecompany);
            var sysMenu = get_all_child_menus(allmenus, 0, GroupName);
            if (sysMenu.Length == 0)
            {
                return string.Empty;
            }
            StringBuilder sb = new StringBuilder("{");
            sb.Append(string.Format("\"id\":\"{0}\",\"name\":\"{1}\",\"description\":\"{2}\",\"state\":\"{3}\"", id, Utility.EnumHelper.GetDescription(typeof(Utility.EnumModel.SysMenuGroupNameDefine), GroupName), "查看全部权限", "closed"));
            sb.Append(OperationJson(allmenus, 0, GroupName));
            sb.Append("}");
            return sb.ToString();
        }
        public Foresight.DataAccess.SysMenu[] getallmenus(HttpContext context, string GroupName, bool usecompany = false)
        {
            var allmenus = Foresight.DataAccess.SysMenu.GetSysMenus().Where(p => !p.Disabled).OrderBy(p => p.SortOrder).ToArray();
            if (usecompany)
            {
                return allmenus;
            }
            string[] allmodulecodes = WebUtil.GetALLModuleCodes(context);
            if (allmodulecodes != null)
            {
                allmenus = allmenus.Where(p => allmodulecodes.Contains(p.ModuleCode)).ToArray();
            }
            return allmenus;
        }
        public Foresight.DataAccess.SysMenu[] get_all_child_menus(SysMenu[] allmenus, int ParentID, string GroupName)
        {
            Foresight.DataAccess.SysMenu[] sysMenu = new SysMenu[] { };
            if (ParentID > 0)
            {
                sysMenu = allmenus.Where(p => p.ParentID == ParentID).ToArray();
            }
            else
            {
                sysMenu = allmenus.Where(p => p.ParentID == ParentID && (p.GroupName.Equals(GroupName) || (string.IsNullOrEmpty(p.GroupName) && GroupName.Equals(Utility.EnumModel.SysMenuGroupNameDefine.wynk.ToString())))).ToArray();
            }
            return sysMenu;
        }
        public string OperationJson(SysMenu[] allmenus, int ParentID, string GroupName)
        {
            StringBuilder sb = new StringBuilder("");
            var sysMenu = get_all_child_menus(allmenus, ParentID, GroupName);
            if (sysMenu.Length > 0)
            {
                sb.Append(",");
                sb.Append("\"children\":");
                sb.Append("[");
                for (int i = 0; i < sysMenu.Length; i++)
                {
                    if (i == 0)
                    {
                        sb.Append("{");
                    }
                    else
                    {
                        sb.Append(",{");
                    }
                    var subMenus = allmenus.Where(p => p.ParentID == sysMenu[i].ID).ToArray();
                    if (subMenus.Length > 0)
                    {
                        sb.Append(string.Format("\"id\":\"{0}\",\"name\":\"{1}\",\"description\":\"{2}\",\"state\":\"{3}\"", sysMenu[i].ID, sysMenu[i].Title, sysMenu[i].Description, "closed"));
                    }
                    else
                    {
                        sb.Append(string.Format("\"id\":\"{0}\",\"name\":\"{1}\",\"description\":\"{2}\"", sysMenu[i].ID, sysMenu[i].Title, sysMenu[i].Description));
                    }
                    sb.Append(OperationJson(allmenus, sysMenu[i].ID, GroupName));
                    sb.Append("}");
                }
                sb.Append("]");
            }
            string result = sb.ToString();
            return result;
        }
        private void saveoperation(HttpContext context)
        {
            int UserID = WebUtil.GetIntValue(context, "UserID");
            int RoleID = WebUtil.GetIntValue(context, "RoleID");
            Foresight.DataAccess.User user = null;
            Foresight.DataAccess.Role role = null;
            if (UserID > 0)
            {
                user = User.GetUser(UserID);
            }
            if (RoleID > 0)
            {
                role = Role.GetRole(RoleID);
            }
            string IDList = context.Request.Params["IdList"];
            string[] IDArry = new string[] { };
            if (!string.IsNullOrEmpty(IDList))
            {
                IDArry = IDList.Split(',');
            }
            string cmdtext = string.Empty;
            foreach (var item in IDArry)
            {
                int ModuleID = 0;
                int.TryParse(item, out ModuleID);
                if (ModuleID <= 0)
                {
                    continue;
                }
                cmdtext += "insert into [RoleModule] (RoleID,ModuleId,UserID) values (" + RoleID + "," + ModuleID + "," + UserID + ");";
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    Foresight.DataAccess.RoleModule.DeleteRoleModuleByRoleId(RoleID, UserID, helper);
                    if (!string.IsNullOrEmpty(cmdtext))
                    {
                        helper.Execute(cmdtext, CommandType.Text, new List<SqlParameter>());
                    }
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    WebUtil.WriteJson(context, new { status = false, error = ex.Message });
                    return;
                }
            }
            try
            {
                #region 权限修改日志
                string name = role != null ? "角色" + role.RoleName : string.Empty;
                name = user != null ? "用户" + user.LoginName : name;
                string LogID = role != null ? role.RoleID.ToString() : string.Empty;
                LogID = user != null ? "用户" + user.UserID.ToString() : name;
                APPCode.CommHelper.SaveOperationLog(string.Join(",", IDArry.ToArray()), Utility.EnumModel.OperationModule.RoleModule.ToString(), "操作权限", LogID, "RoleModule", user.RealName, IsHide: true);
                APPCode.CommHelper.SaveOperationLog(name + "权限修改", Utility.EnumModel.OperationModule.RoleModuleSave.ToString(), "权限修改", LogID, "Role");
                #endregion
            }
            catch (Exception)
            {
            }
            //通知后台
            APPCode.SocketNotify.PushSocketNotifyAlert(Utility.EnumModel.SocketNotifyDefine.notifyclearcache);
            WebUtil.WriteJson(context, new { status = true });
        }
        private void LoadOperation(HttpContext context)
        {
            int RoleId = WebUtil.GetIntValue(context, "RoleId");
            int UserID = WebUtil.GetIntValue(context, "UserID");
            var list = Foresight.DataAccess.RoleModule.GetRoleModuleListByRoleId(RoleId, UserID);
            var items = list.Select(p =>
            {
                var item = new { ModuleId = p.ModuleId };
                return item;
            });
            WebUtil.WriteJson(context, items);
        }
        private void GetProjectTree(HttpContext context)
        {
            int CompanyID = WebUtil.GetIntValue(context, "CompanyID");
            int ID = WebUtil.GetIntValue(context, "ID");
            string Keywords = context.Request.Params["Keywords"];
            int RoleID = WebUtil.GetIntValue(context, "RoleID");
            int UserID = WebUtil.GetIntValue(context, "UserID");
            ProjectTree[] list = ProjectTree.GetProjectTreeListByRoleIDAndUserID(ID, Keywords, RoleID, UserID).ToArray();
            List<Dictionary<string, object>> items = null;
            if (string.IsNullOrEmpty(Keywords))
            {
                items = list.Select(p =>
                {
                    var dic = p.ToJsonObject();
                    if (p.ID == 1)
                    {
                        var company = WebUtil.GetCompany(context);
                        dic["name"] = company.CompanyName;
                    }
                    else
                    {
                        dic["name"] = p.Name;
                    }
                    dic["id"] = p.ID;
                    dic["pId"] = p.ParentID;
                    dic["iconSkin"] = "Icon_" + p.IconID;
                    dic["open"] = true;
                    dic["checked"] = false;
                    if (RoleID > 0)
                    {
                        dic["checked"] = RoleID == p.RoleID;
                    }
                    if (UserID > 0)
                    {
                        dic["checked"] = UserID == p.UserID;
                    }
                    return dic;
                }).ToList();
            }
            else
            {
                items = list.Select(p =>
                {
                    var dic = p.ToJsonObject();
                    if (p.ID == 1)
                    {
                        var company = Company.GetCompany(CompanyID);
                        dic["name"] = company.CompanyName;
                    }
                    else
                    {
                        dic["name"] = p.FullName + p.Name;
                    }
                    dic["id"] = p.ID;
                    dic["pId"] = p.ParentID;
                    dic["iconSkin"] = "Icon_" + p.IconID;
                    dic["open"] = true;
                    dic["checked"] = false;
                    if (RoleID > 0)
                    {
                        dic["checked"] = RoleID == p.RoleID;
                    }
                    if (UserID > 0)
                    {
                        dic["checked"] = UserID == p.UserID;
                    }
                    return dic;
                }).ToList();
            }
            WebUtil.WriteJson(context, items);
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