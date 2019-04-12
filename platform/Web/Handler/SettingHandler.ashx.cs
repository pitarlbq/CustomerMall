
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Utility;
using Foresight.DataAccess.Framework;
using Foresight.DataAccess.Ui;
using Foresight.DataAccess;

namespace Web.Handler
{
    /// <summary>
    /// SettingHandler 的摘要说明
    /// </summary>
    public class SettingHandler : IHttpHandler
    {
        const string LogModule = "SettingHandler";
        public void ProcessRequest(HttpContext context)
        {
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
                    case "loadsellercategorygrid":
                        loadsellercategorygrid(context);
                        break;
                    case "removesellercategory":
                        removesellercategory(context);
                        break;
                    case "savesellercategory":
                        savesellercategory(context);
                        break;
                    case "geteditsellercombobox":
                        geteditsellercombobox(context);
                        break;
                    case "loadprojectcategorygrid":
                        loadprojectcategorygrid(context);
                        break;
                    case "removeprojectcategory":
                        removeprojectcategory(context);
                        break;
                    case "saveprojectcategory":
                        saveprojectcategory(context);
                        break;
                    case "geteditprojectcombobox":
                        geteditprojectcombobox(context);
                        break;
                    case "loaddepartmentcategorygrid":
                        loaddepartmentcategorygrid(context);
                        break;
                    case "removedepartmentcategory":
                        removedepartmentcategory(context);
                        break;
                    case "savedepartmentcategory":
                        savedepartmentcategory(context);
                        break;
                    case "geteditproductcombobox":
                        geteditproductcombobox(context);
                        break;
                    case "loadbuyercategorygrid":
                        loadbuyercategorygrid(context);
                        break;
                    case "removebuyercategory":
                        removebuyercategory(context);
                        break;
                    case "savebuyercategory":
                        savebuyercategory(context);
                        break;
                    case "loadproductcategorygrid":
                        loadproductcategorygrid(context);
                        break;
                    case "removeproductcategory":
                        removeproductcategory(context);
                        break;
                    case "saveproductcategory":
                        saveproductcategory(context);
                        break;
                    case "geteditdepartmentcombobox":
                        geteditdepartmentcombobox(context);
                        break;
                    case "geteditbuyercombobox":
                        geteditbuyercombobox(context);
                        break;
                    case "getsystemmsglist":
                        getsystemmsglist(context);
                        break;
                    case "deletesystemmsg":
                        deletesystemmsg(context);
                        break;
                    case "savesystemmsg":
                        savesystemmsg(context);
                        break;
                    case "getmysysmsglist":
                        getmysysmsglist(context);
                        break;
                    case "savemsgreadstatus":
                        savemsgreadstatus(context);
                        break;
                    default:
                        WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "Unkown Visit: " + visit);
                        break;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(LogModule, "visit: " + visit, ex);
                context.Response.Write("{\"status\":false}");
            }
        }
        private void savemsgreadstatus(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            var sysmsg = Foresight.DataAccess.SystemMsg.GetSystemMsg(ID);
            sysmsg.IsReading = true;
            sysmsg.ReadingTime = DateTime.Now;
            sysmsg.Save();
            WebUtil.WriteJson(context, new { status = true });
        }
        private void getmysysmsglist(HttpContext context)
        {
            var list = Foresight.DataAccess.SystemMsg.GetSystemMsgs().OrderByDescending(p => p.IsTopShow).ThenBy(p => p.SortOrder).ThenByDescending(p => p.AddTime).ToArray();
            var items = list.Select(p =>
            {
                var item = new { ID = p.ID, Title = p.Title, AddTime = p.AddTime.ToString("yyyy年MM月dd日"), ContentSummary = p.ContentSummary, showtext = "查看", showsummary = false, IsReading = p.IsReading };
                return item;
            });
            WebUtil.WriteJson(context, new { status = true, list = items });
        }
        private void savesystemmsg(HttpContext context)
        {
            Foresight.DataAccess.SystemMsg msg = null;
            int ID = 0;
            int.TryParse(context.Request.Params["ID"], out ID);
            if (ID > 0)
            {
                msg = Foresight.DataAccess.SystemMsg.GetSystemMsg(ID);
            }
            if (msg == null)
            {
                msg = new Foresight.DataAccess.SystemMsg();
                msg.AddTime = DateTime.Now;
            }
            msg.Title = getValue(context, "tdTitle");
            msg.IsTopShow = getIntValue(context, "tdIsTopShow") == 1;
            msg.SortOrder = getIntValue(context, "tdSortOrder");
            msg.ContentSummary = context.Request["HTMLContent"];
            msg.DisableNotify = getIntValue(context, "tdDisableNotify") == 1;
            msg.IsNotifyALL = getIntValue(context, "tdIsNotifyALL") == 1;
            string CompanyIDs = context.Request["CompanyIDs"];
            List<Foresight.DataAccess.SystemMsg_Company> msgcompany_list = new List<Foresight.DataAccess.SystemMsg_Company>();
            List<int> CompanyIDList = new List<int>();
            if (!string.IsNullOrEmpty(CompanyIDs))
            {
                CompanyIDList = JsonConvert.DeserializeObject<List<int>>(CompanyIDs);
            }
            if (msg.IsNotifyALL)
            {
                CompanyIDList = Company.GetAllActiveCompanyList().Select(p => p.CompanyID).ToList();
            }
            if (CompanyIDList.Count > 0)
            {
                if (msg.ID > 0)
                {
                    var exist_list = Foresight.DataAccess.SystemMsg_Company.GetSystemMsg_CompanyList(msg.ID);
                    foreach (var CompanyID in CompanyIDList)
                    {
                        var msgcompany = exist_list.FirstOrDefault(p => p.CompanyID == CompanyID);
                        if (msgcompany == null)
                        {
                            msgcompany = new Foresight.DataAccess.SystemMsg_Company();
                            msgcompany.CompanyID = CompanyID;
                            msgcompany.AddTime = DateTime.Now;
                        }
                        msgcompany_list.Add(msgcompany);
                    }
                }
                else
                {
                    foreach (var CompanyID in CompanyIDList)
                    {
                        var msgcompany = new Foresight.DataAccess.SystemMsg_Company();
                        msgcompany.CompanyID = CompanyID;
                        msgcompany.AddTime = DateTime.Now;
                        msgcompany_list.Add(msgcompany);
                    }
                }
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    msg.Save(helper);
                    foreach (var item in msgcompany_list)
                    {
                        item.IsReading = false;
                        item.SystemMsgID = msg.ID;
                        item.Save(helper);
                    }
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    LogHelper.WriteError(LogModule, "savesystemmsg", ex);
                    helper.Rollback();
                    WebUtil.WriteJson(context, new { status = false });
                    return;
                }
            }
            WebUtil.WriteJson(context, new { status = true, ID = msg.ID });
        }
        private void deletesystemmsg(HttpContext context)
        {
            string IDs = context.Request.Params["IDList"];
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(IDs);
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    string cmdtext = "delete from [SystemMsg] where ID in (" + string.Join(",", IDList.ToArray()) + ");";
                    cmdtext += "update [SystemMsg_Company] set [IsDeleting]=1 where [SystemMsgID] in (" + string.Join(",", IDList.ToArray()) + ")";
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    helper.Execute(cmdtext, CommandType.Text, parameters);
                    helper.Commit();
                    context.Response.Write("{\"status\":true}");
                }
                catch (Exception ex)
                {
                    Utility.LogHelper.WriteError(LogModule, "命令: deletesystemmsg", ex);
                    helper.Rollback();
                    context.Response.Write("{\"status\":false}");
                }
            }
        }
        private void getsystemmsglist(HttpContext context)
        {
            try
            {
                string Keywords = context.Request.Params["keywords"];
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                DataGrid dg = Foresight.DataAccess.SystemMsg.GetSystemMsgGridByKeywords(Keywords, "order by [AddTime] desc", startRowIndex, pageSize);
                WebUtil.WriteJson(context, dg);
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(LogModule, "getsystemmsglist", ex);
                WebUtil.WriteJson(context, new Foresight.DataAccess.Ui.DataGrid());
            }
        }
        private void geteditbuyercombobox(HttpContext context)
        {
            var list = Foresight.DataAccess.Cheque_BuyerCategory.GetCheque_BuyerCategories();
            WebUtil.WriteJson(context, new { status = true, buyercategorylist = list });
        }
        private void geteditdepartmentcombobox(HttpContext context)
        {
            var departmentcategorylist = Foresight.DataAccess.Cheque_DepartmentCategory.GetCheque_DepartmentCategories();
            WebUtil.WriteJson(context, new { departmentcategorylist = departmentcategorylist });
        }
        private void saveproductcategory(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            Foresight.DataAccess.Cheque_ProductCategory data = null;
            if (ID > 0)
            {
                data = Foresight.DataAccess.Cheque_ProductCategory.GetCheque_ProductCategory(ID);
            }
            if (data == null)
            {
                data = new Foresight.DataAccess.Cheque_ProductCategory();
            }
            data.ProductCategoryName = context.Request["ProductCategoryName"];
            data.ProductCategoryNumber = context.Request["ProductCategoryNumber"];
            data.Save();
            WebUtil.WriteJson(context, new { status = true });
        }
        private void removeproductcategory(HttpContext context)
        {
            string IDListArry = context.Request.Params["IDList"];
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(IDListArry);
            if (IDList.Count == 0)
            {
                WebUtil.WriteJson(context, new { status = false });
                return;
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    string cmdtext = "delete from [Cheque_ProductCategory] where [ID] in (" + string.Join(",", IDList.ToArray()) + ")";
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    helper.Execute(cmdtext, CommandType.Text, parameters);
                    helper.Commit();
                    WebUtil.WriteJson(context, new { status = true });
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError(LogModule, "命令: removebuyercategory", ex);
                    WebUtil.WriteJson(context, new { status = false });
                }
            }
        }
        private void loadproductcategorygrid(HttpContext context)
        {
            try
            {
                string Keywords = context.Request.Params["keywords"];
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                DataGrid dg = Foresight.DataAccess.Cheque_ProductCategory.GetCheque_ProductCategoryGridByKeywords(Keywords, "order by ID desc", startRowIndex, pageSize);
                string result = JsonConvert.SerializeObject(dg);
                context.Response.Write(result);
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(LogModule, "命令: loadbuyercategorygrid", ex);
                context.Response.Write("{\"rows\":[],\"total\":0,\"page\":0}");
            }
        }
        private void savebuyercategory(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            Foresight.DataAccess.Cheque_BuyerCategory data = null;
            if (ID > 0)
            {
                data = Foresight.DataAccess.Cheque_BuyerCategory.GetCheque_BuyerCategory(ID);
            }
            if (data == null)
            {
                data = new Foresight.DataAccess.Cheque_BuyerCategory();
            }
            data.BuyerCategoryName = context.Request["BuyerCategoryName"];
            data.BuyerCategoryNumber = context.Request["BuyerCategoryNumber"];
            data.Save();
            WebUtil.WriteJson(context, new { status = true });
        }
        private void removebuyercategory(HttpContext context)
        {
            string IDListArry = context.Request.Params["IDList"];
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(IDListArry);
            if (IDList.Count == 0)
            {
                WebUtil.WriteJson(context, new { status = false });
                return;
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    string cmdtext = "delete from [Cheque_BuyerCategory] where [ID] in (" + string.Join(",", IDList.ToArray()) + ")";
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    helper.Execute(cmdtext, CommandType.Text, parameters);
                    helper.Commit();
                    WebUtil.WriteJson(context, new { status = true });
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError(LogModule, "命令: removebuyercategory", ex);
                    WebUtil.WriteJson(context, new { status = false });
                }
            }
        }
        private void loadbuyercategorygrid(HttpContext context)
        {
            try
            {
                string Keywords = context.Request.Params["keywords"];
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                DataGrid dg = Foresight.DataAccess.Cheque_BuyerCategory.GetCheque_BuyerCategoryGridByKeywords(Keywords, "order by ID desc", startRowIndex, pageSize);
                string result = JsonConvert.SerializeObject(dg);
                context.Response.Write(result);
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(LogModule, "命令: loadbuyercategorygrid", ex);
                context.Response.Write("{\"rows\":[],\"total\":0,\"page\":0}");
            }
        }
        private void geteditproductcombobox(HttpContext context)
        {
            var productcategorylist = Foresight.DataAccess.Cheque_ProductCategory.GetCheque_ProductCategories();
            WebUtil.WriteJson(context, new { productcategorylist = productcategorylist });
        }
        private void savedepartmentcategory(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            Foresight.DataAccess.Cheque_DepartmentCategory data = null;
            if (ID > 0)
            {
                data = Foresight.DataAccess.Cheque_DepartmentCategory.GetCheque_DepartmentCategory(ID);
            }
            if (data == null)
            {
                data = new Foresight.DataAccess.Cheque_DepartmentCategory();
            }
            data.DepartmentCategoryName = context.Request["DepartmentCategoryName"];
            data.DepartmentCategoryNumber = context.Request["DepartmentCategoryNumber"];
            data.Save();
            WebUtil.WriteJson(context, new { status = true });
        }
        private void removedepartmentcategory(HttpContext context)
        {
            string IDListArry = context.Request.Params["IDList"];
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(IDListArry);
            if (IDList.Count == 0)
            {
                WebUtil.WriteJson(context, new { status = false });
                return;
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    string cmdtext = "delete from [Cheque_DepartmentCategory] where [ID] in (" + string.Join(",", IDList.ToArray()) + ")";
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    helper.Execute(cmdtext, CommandType.Text, parameters);
                    helper.Commit();
                    WebUtil.WriteJson(context, new { status = true });
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError(LogModule, "命令: removedepartmentcategory", ex);
                    WebUtil.WriteJson(context, new { status = false });
                }
            }
        }
        private void loaddepartmentcategorygrid(HttpContext context)
        {
            try
            {
                string Keywords = context.Request.Params["keywords"];
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                DataGrid dg = Foresight.DataAccess.Cheque_DepartmentCategory.GetCheque_DepartmentCategoryGridByKeywords(Keywords, "order by ID desc", startRowIndex, pageSize);
                string result = JsonConvert.SerializeObject(dg);
                context.Response.Write(result);
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(LogModule, "命令: loaddepartmentcategorygrid", ex);
                context.Response.Write("{\"rows\":[],\"total\":0,\"page\":0}");
            }
        }
        private void geteditprojectcombobox(HttpContext context)
        {
            var projectcategorylist = Foresight.DataAccess.Cheque_ProjectCategory.GetCheque_ProjectCategories();
            var departmentlist = Foresight.DataAccess.Cheque_Department.GetCheque_Departments();
            WebUtil.WriteJson(context, new { projectcategorylist = projectcategorylist, departmentlist = departmentlist });
        }
        private void saveprojectcategory(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            Foresight.DataAccess.Cheque_ProjectCategory data = null;
            if (ID > 0)
            {
                data = Foresight.DataAccess.Cheque_ProjectCategory.GetCheque_ProjectCategory(ID);
            }
            if (data == null)
            {
                data = new Foresight.DataAccess.Cheque_ProjectCategory();
            }
            data.ProjectCategoryName = context.Request["ProjectCategoryName"];
            data.ProjectCategoryNumber = context.Request["ProjectCategoryNumber"];
            data.Save();
            WebUtil.WriteJson(context, new { status = true });
        }
        private void removeprojectcategory(HttpContext context)
        {
            string IDListArry = context.Request.Params["IDList"];
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(IDListArry);
            if (IDList.Count == 0)
            {
                WebUtil.WriteJson(context, new { status = false });
                return;
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    string cmdtext = "delete from [Cheque_ProjectCategory] where [ID] in (" + string.Join(",", IDList.ToArray()) + ")";
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    helper.Execute(cmdtext, CommandType.Text, parameters);
                    helper.Commit();
                    WebUtil.WriteJson(context, new { status = true });
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError(LogModule, "命令: removeprojectcategory", ex);
                    WebUtil.WriteJson(context, new { status = false });
                }
            }
        }
        private void loadprojectcategorygrid(HttpContext context)
        {
            try
            {
                string Keywords = context.Request.Params["keywords"];
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                DataGrid dg = Foresight.DataAccess.Cheque_ProjectCategory.GetCheque_ProjectCategoryGridByKeywords(Keywords, "order by ID desc", startRowIndex, pageSize);
                string result = JsonConvert.SerializeObject(dg);
                context.Response.Write(result);
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(LogModule, "命令: loadprojectcategorygrid", ex);
                context.Response.Write("{\"rows\":[],\"total\":0,\"page\":0}");
            }
        }
        private void geteditsellercombobox(HttpContext context)
        {
            var list = Foresight.DataAccess.Cheque_SellerCategory.GetCheque_SellerCategories();
            WebUtil.WriteJson(context, new { status = true, sellercategorylist = list });
        }
        private void savesellercategory(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            Foresight.DataAccess.Cheque_SellerCategory category = null;
            if (ID > 0)
            {
                category = Foresight.DataAccess.Cheque_SellerCategory.GetCheque_SellerCategory(ID);
            }
            if (category == null)
            {
                category = new Foresight.DataAccess.Cheque_SellerCategory();
            }
            category.SellerCategoryName = context.Request["SellerCategoryName"];
            category.SellerCategoryNumber = context.Request["SellerCategoryNumber"];
            category.Save();
            WebUtil.WriteJson(context, new { status = true });
        }
        private void removesellercategory(HttpContext context)
        {
            string IDListArry = context.Request.Params["IDList"];
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(IDListArry);
            if (IDList.Count == 0)
            {
                WebUtil.WriteJson(context, new { status = false });
                return;
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    string cmdtext = "delete from [Cheque_SellerCategory] where [ID] in (" + string.Join(",", IDList.ToArray()) + ")";
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    helper.Execute(cmdtext, CommandType.Text, parameters);
                    helper.Commit();
                    WebUtil.WriteJson(context, new { status = true });
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError(LogModule, "命令: removesellercategory", ex);
                    WebUtil.WriteJson(context, new { status = false });
                }
            }
        }
        private void loadsellercategorygrid(HttpContext context)
        {
            try
            {
                string Keywords = context.Request.Params["keywords"];
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                DataGrid dg = Foresight.DataAccess.Cheque_SellerCategory.GetCheque_SellerCategoryGridByKeywords(Keywords, "order by ID desc", startRowIndex, pageSize);
                string result = JsonConvert.SerializeObject(dg);
                context.Response.Write(result);
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(LogModule, "命令: loadsellercategorygrid", ex);
                context.Response.Write("{\"rows\":[],\"total\":0,\"page\":0}");
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
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}