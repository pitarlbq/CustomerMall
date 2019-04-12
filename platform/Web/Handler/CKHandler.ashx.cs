using Foresight.DataAccess;
using Foresight.DataAccess.Framework;
using Foresight.DataAccess.Ui;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using Utility;
using Web.Model;

namespace Web.Handler
{
    /// <summary>
    /// CKHandler 的摘要说明
    /// </summary>
    public class CKHandler : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string visit = context.Request.Params["visit"];
            if (string.IsNullOrEmpty(visit))
            {
                LogHelper.WriteDebug("CKHandler", "visit为空");
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
                    case "saveproduct":
                        saveproduct(context);
                        break;
                    case "loadproductgrid":
                        loadproductgrid(context);
                        break;
                    case "removeproduct":
                        removeproduct(context);
                        break;
                    case "savecontract":
                        savecontract(context);
                        break;
                    case "removecontract":
                        removecontract(context);
                        break;
                    case "loadcontractgrid":
                        loadcontractgrid(context);
                        break;
                    case "loadingrid":
                        loadingrid(context);
                        break;
                    case "saveckinsummary":
                        saveckinsummary(context);
                        break;
                    case "getindetailparams":
                        getindetailparams(context);
                        break;
                    case "loadinproductdetailgrid":
                        loadinproductdetailgrid(context);
                        break;
                    case "removeckin":
                        removeckin(context);
                        break;
                    case "loadcategorygrid":
                        loadcategorygrid(context);
                        break;
                    case "removecategory":
                        removecategory(context);
                        break;
                    case "savecategory":
                        savecategory(context);
                        break;
                    case "loadoutgrid":
                        loadoutgrid(context);
                        break;
                    case "removeckout":
                        removeckout(context);
                        break;
                    case "getoutdetailparams":
                        getoutdetailparams(context);
                        break;
                    case "saveckoutsummary":
                        saveckoutsummary(context);
                        break;
                    case "loadoutproductdetailgrid":
                        loadoutproductdetailgrid(context);
                        break;
                    case "loadinventorygrid":
                        loadinventorygrid(context);
                        break;
                    case "loadincategorygrid":
                        loadincategorygrid(context);
                        break;
                    case "removeincategory":
                        removeincategory(context);
                        break;
                    case "saveincategory":
                        saveincategory(context);
                        break;
                    case "loadmateriallingyonganalysis":
                        loadmateriallingyonganalysis(context);
                        break;
                    case "saveckdepartment":
                        saveckdepartment(context);
                        break;
                    case "loadckdepartmentgrid":
                        loadckdepartmentgrid(context);
                        break;
                    case "removeckdepartment":
                        removeckdepartment(context);
                        break;
                    case "loadckacceptusergrid":
                        loadckacceptusergrid(context);
                        break;
                    case "removeckacceptuser":
                        removeckacceptuser(context);
                        break;
                    case "saveckacceptuser":
                        saveckacceptuser(context);
                        break;
                    case "loadproductcategorytree":
                        loadproductcategorytree(context);
                        break;
                    case "saveproductcategory":
                        saveproductcategory(context);
                        break;
                    case "removeproductcategory":
                        removeproductcategory(context);
                        break;
                    case "removeckoutdetail":
                        removeckoutdetail(context);
                        break;
                    case "removeckindetail":
                        removeckindetail(context);
                        break;
                    case "approveckin":
                        approveckin(context);
                        break;
                    case "approveckout":
                        approveckout(context);
                        break;
                    case "getoutmgrparams":
                        getoutmgrparams(context);
                        break;
                    case "calculateoutprice":
                        calculateoutprice(context);
                        break;
                    case "loaddepartmenttree":
                        loaddepartmenttree(context);
                        break;
                    case "loadckpropertygrid":
                        loadckpropertygrid(context);
                        break;
                    case "removeckproperty":
                        removeckproperty(context);
                        break;
                    case "saveckproperty":
                        saveckproperty(context);
                        break;
                    case "loadpropertycategorygrid":
                        loadpropertycategorygrid(context);
                        break;
                    case "removepropertycategory":
                        removepropertycategory(context);
                        break;
                    case "savepropertycategory":
                        savepropertycategory(context);
                        break;
                    case "loadckpropertytempgrid":
                        loadckpropertytempgrid(context);
                        break;
                    case "getckinmgrcombobox":
                        getckinmgrcombobox(context);
                        break;
                    case "exportckintemplate":
                        exportckintemplate(context);
                        break;
                    case "exportckimportproducttemplate":
                        exportckimportproducttemplate(context);
                        break;
                    case "exportckimportpropertytemplate":
                        exportckimportpropertytemplate(context);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("CKHandler", "visit: " + visit, ex);
                context.Response.Write("{\"status\":false}");
            }
        }
        private void exportckimportpropertytemplate(HttpContext context)
        {
            string downloadurl = string.Empty;
            string error = string.Empty;
            bool status = APPCode.ExportHelper.DownLoadImportPropertyTemplateData(out downloadurl, out error);
            WebUtil.WriteJson(context, new { status = status, downloadurl = downloadurl, error = error });
        }
        private void exportckimportproducttemplate(HttpContext context)
        {
            string downloadurl = string.Empty;
            string error = string.Empty;
            bool status = APPCode.ExportHelper.DownLoadImportProductTemplateData(out downloadurl, out error);
            WebUtil.WriteJson(context, new { status = status, downloadurl = downloadurl, error = error });
        }
        private void exportckintemplate(HttpContext context)
        {
            string downloadurl = string.Empty;
            string error = string.Empty;
            bool status = APPCode.ExportHelper.DownLoadImportCKInTemplateData(out downloadurl, out error);
            WebUtil.WriteJson(context, new { status = status, downloadurl = downloadurl, error = error });
        }
        private void getckinmgrcombobox(HttpContext context)
        {
            var list = CKProductCategory.GetCKProductCategories();
            var dic = new Dictionary<string, object>();
            var items = list.Select(p =>
            {
                dic = new Dictionary<string, object>();
                dic["ID"] = p.ID;
                dic["Name"] = p.ProductCategoryName;
                return dic;
            }).ToList();
            dic = new Dictionary<string, object>();
            dic["ID"] = "";
            dic["Name"] = "全部";
            items.Insert(0, dic);
            WebUtil.WriteJson(context, new { status = true, ProductCategoryList = items });
        }
        private void loadckpropertytempgrid(HttpContext context)
        {
            try
            {
                int PropertID = WebUtil.GetIntValue(context, "PropertyID");
                string Keywords = context.Request.Params["Keywords"];
                DateTime StartTime = WebUtil.GetDateValue(context, "StartTime");
                DateTime EndTime = WebUtil.GetDateValue(context, "EndTime");
                string TreeIDs = context.Request["TreeIDList"];
                List<int> DepartmentIDList = new List<int>();
                if (!string.IsNullOrEmpty(TreeIDs))
                {
                    DepartmentIDList = JsonConvert.DeserializeObject<List<int>>(TreeIDs);
                }
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                DataGrid dg = CKPropertyTemp.GetCKPropertyTempGridByKeywords(PropertID, Keywords, StartTime, EndTime, DepartmentIDList, "order by [ModifyTime] desc", startRowIndex, pageSize);
                WebUtil.WriteJson(context, dg);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.WriteError("CKHandler", "命令:loadckpropertytempgrid", ex);
                WebUtil.WriteJson(context, new Foresight.DataAccess.Ui.DataGrid());
            }
        }
        private void savepropertycategory(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            CKPropertyCategory data = null;
            if (ID > 0)
            {
                data = CKPropertyCategory.GetCKPropertyCategory(ID);
            }
            if (data == null)
            {
                data = new CKPropertyCategory();
                data.AddTime = DateTime.Now;
                data.AddUser = WebUtil.GetUser(context).RealName;
            }
            data.PropertyCategoryName = context.Request["PropertyCategoryName"];
            data.Save();
            WebUtil.WriteJson(context, new { status = true });
        }
        private void removepropertycategory(HttpContext context)
        {
            string IDs = context.Request.Params["IDList"];
            List<int> IDList = new List<int>();
            if (!string.IsNullOrEmpty(IDs))
            {
                IDList = JsonConvert.DeserializeObject<List<int>>(IDs);
            }
            if (IDList.Count > 0)
            {
                using (SqlHelper helper = new SqlHelper())
                {
                    try
                    {
                        helper.BeginTransaction();
                        string cmdtext = "delete from [CKPropertyCategory] where [ID] in (" + string.Join(",", IDList.ToArray()) + ")";
                        helper.Execute(cmdtext, CommandType.Text, new List<System.Data.SqlClient.SqlParameter>());
                        helper.Commit();
                    }
                    catch (Exception ex)
                    {
                        helper.Rollback();
                        LogHelper.WriteError("CKHandler", "visit:removepropertycategory", ex);
                        WebUtil.WriteJson(context, new { status = false });
                        return;
                    }
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void loadpropertycategorygrid(HttpContext context)
        {
            try
            {
                string Keywords = context.Request.Params["Keywords"];
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                DataGrid dg = CKPropertyCategory.GetCKPropertyCategoryGridByKeywords(Keywords, "order by AddTime desc", startRowIndex, pageSize);
                WebUtil.WriteJson(context, dg);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.WriteError("CKHandler", "命令:loadpropertycategorygrid", ex);
                WebUtil.WriteJson(context, new Foresight.DataAccess.Ui.DataGrid());
            }
        }
        private void saveckproperty(HttpContext context)
        {
            int PropertyID = WebUtil.GetIntValue(context, "ID");
            Foresight.DataAccess.CKProperty data = null;
            if (PropertyID > 0)
            {
                data = CKProperty.GetCKProperty(PropertyID);
            }
            if (data == null)
            {
                data = new CKProperty();
                data.AddTime = DateTime.Now;
                data.AddMan = WebUtil.GetUser(context).RealName;
            }
            string PropertyNo = context.Request["PropertyNo"];
            if (!string.IsNullOrEmpty(PropertyNo))
            {
                var exist_property = CKPropertyDetails.GetCKPropertyDetailsByPropertyNo(PropertyNo);
                if (exist_property != null && exist_property.ID != data.ID)
                {
                    WebUtil.WriteJson(context, new { status = false, error = "资产编号已存在" });
                    return;
                }
            }
            data.PropertyCategoryID = WebUtil.GetIntValue(context, "PropertyCategoryID");
            data.PropertyNo = context.Request["PropertyNo"];
            data.PropertyName = context.Request["PropertyName"];
            data.PropertyModelNo = context.Request["PropertyModelNo"];
            data.PropertyUnit = context.Request["PropertyUnit"];
            data.PropertyCount = WebUtil.GetIntValue(context, "PropertyCount");
            data.PropertyUnitPrice = WebUtil.GetDecimalValue(context, "PropertyUnitPrice");
            data.PropertyCost = data.PropertyCount * data.PropertyUnitPrice;
            data.PropertyPurchaseDate = WebUtil.GetDateValue(context, "PropertyPurchaseDate");
            data.PropertyUseYear = WebUtil.GetDecimalValue(context, "PropertyUseYear");
            data.PropertyRealCost = WebUtil.GetDecimalValue(context, "PropertyRealCost");
            data.PropertyDiscountCost = WebUtil.GetDecimalValue(context, "PropertyDiscountCost");
            data.PropertyChangeType = context.Request["PropertyChangeType"];
            data.PropertyState = WebUtil.GetIntValue(context, "PropertyState");
            data.PropertyDepartmentID = WebUtil.GetIntValue(context, "PropertyDepartmentID");
            data.PropertyLocation = context.Request["PropertyLocation"];
            data.PropertyUseMan = context.Request["PropertyUseMan"];
            data.PropertyContractName = context.Request["PropertyContractName"];
            data.PropertyContactPhone = context.Request["PropertyContactPhone"];
            data.PropertyRemark = context.Request["PropertyRemark"];
            data.UpdateMan = WebUtil.GetUser(context).RealName;
            data.UpdateTime = DateTime.Now;
            data.Save();
            if (context.Request["op"].Equals("change"))
            {
                Foresight.DataAccess.CKPropertyTemp.InsertCKPropertyTempByPropertyID(PropertyID, WebUtil.GetUser(context).RealName);
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void removeckproperty(HttpContext context)
        {
            string IDs = context.Request.Params["IDList"];
            List<int> IDList = new List<int>();
            if (!string.IsNullOrEmpty(IDs))
            {
                IDList = JsonConvert.DeserializeObject<List<int>>(IDs);
            }
            if (IDList.Count > 0)
            {
                using (SqlHelper helper = new SqlHelper())
                {
                    try
                    {
                        helper.BeginTransaction();
                        string cmdtext = "delete from [CKProperty] where [ID] in (" + string.Join(",", IDList.ToArray()) + ")";
                        helper.Execute(cmdtext, CommandType.Text, new List<System.Data.SqlClient.SqlParameter>());
                        helper.Commit();
                    }
                    catch (Exception ex)
                    {
                        helper.Rollback();
                        LogHelper.WriteError("CKHandler", "visit:removeckproperty", ex);
                        WebUtil.WriteJson(context, new { status = false });
                        return;
                    }
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void loadckpropertygrid(HttpContext context)
        {
            try
            {
                string Keywords = context.Request.Params["Keywords"];
                DateTime StartTime = WebUtil.GetDateValue(context, "StartTime");
                DateTime EndTime = WebUtil.GetDateValue(context, "EndTime");
                string TreeIDs = context.Request["TreeIDList"];
                List<int> DepartmentIDList = new List<int>();
                if (!string.IsNullOrEmpty(TreeIDs))
                {
                    DepartmentIDList = JsonConvert.DeserializeObject<List<int>>(TreeIDs);
                }
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                bool canexport = WebUtil.GetBoolValue(context, "canexport");
                DataGrid dg = CKPropertyDetails.GetCKPropertyDetailsGridByKeywords(Keywords, StartTime, EndTime, DepartmentIDList, "order by AddTime desc", startRowIndex, pageSize, canexport: canexport);
                if (canexport)
                {
                    string downloadurl = string.Empty;
                    string error = string.Empty;
                    bool status = APPCode.ExportHelper.DownLoadCKPropertyData(dg, out downloadurl, out error);
                    WebUtil.WriteJson(context, new { status = status, downloadurl = downloadurl, error = error });
                    return;
                }
                WebUtil.WriteJson(context, dg);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.WriteError("CKHandler", "命令:loadckpropertygrid", ex);
                WebUtil.WriteJson(context, new Foresight.DataAccess.Ui.DataGrid());
            }
        }
        private void loaddepartmenttree(HttpContext context)
        {
            try
            {
                string Keywords = context.Request.Params["Keywords"];
                int UserID = WebUtil.GetUser(context).UserID;
                var list = Foresight.DataAccess.CKDepartment.GetCKDepartmentListByKeywords(Keywords);
                TreeModule treeModule = null;
                var items = list.Select(p =>
                {
                    treeModule = new TreeModule();
                    treeModule.id = "department_" + p.ID.ToString();
                    treeModule.ID = p.ID;
                    treeModule.pId = "department_0";
                    treeModule.name = p.DepartmentName;
                    treeModule.isParent = false;
                    treeModule.open = true;
                    return treeModule;
                }).ToList();
                treeModule = new TreeModule();
                treeModule.id = "department_0";
                treeModule.ID = 0;
                treeModule.pId = "0";
                treeModule.name = WebUtil.GetCompany(context).CompanyName;
                bool hasckChild = list.Length > 0;
                treeModule.isParent = hasckChild;
                treeModule.open = hasckChild;
                treeModule.type = EnumModel.CKCategoryType.company.ToString();
                items.Add(treeModule);
                WebUtil.WriteJson(context, items);
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("CKHandler.ashx", "visit: loaddepartmenttree", ex);
                context.Response.Write("[]");
            }
        }
        private void calculateoutprice(HttpContext context)
        {
            decimal arv_price = 0;
            decimal In_TotalCost = 0;
            decimal In_TotalCount = 0;
            int ProductID = WebUtil.GetIntValue(context, "ProductID");
            int OutCount = WebUtil.GetIntValue(context, "OutCount");
            int CKCategoryID = WebUtil.GetIntValue(context, "CKCategoryID");
            var indetails = Foresight.DataAccess.CKProudctInDetail2.GetCKProudctInDetailListByProductIDList((new int[] { ProductID }).ToList(), CKCategoryID);
            foreach (var indetail in indetails)
            {
                if (OutCount <= 0)
                {
                    break;
                }
                int rest_count = indetail.InTotalCount - indetail.OutTotalCount;
                if (rest_count <= 0)
                {
                    continue;
                }
                if (rest_count > OutCount)
                {
                    In_TotalCost += OutCount * indetail.UnitPrice;
                    In_TotalCount += OutCount;
                    OutCount = 0;
                    break;
                }
                OutCount = OutCount - rest_count;
                In_TotalCost += rest_count * indetail.UnitPrice;
                In_TotalCount += rest_count;
            }
            if (In_TotalCount <= 0)
            {
                WebUtil.WriteJson(context, new { status = true, UnitPrice = arv_price });
                return;
            }
            arv_price = Math.Round(In_TotalCost / In_TotalCount, 2, MidpointRounding.AwayFromZero);
            WebUtil.WriteJson(context, new { status = true, UnitPrice = arv_price });
        }
        private void getoutmgrparams(HttpContext context)
        {
            var DepartmentList = CKDepartment.GetCKDepartments();
            var dic = new Dictionary<string, object>();
            var items = DepartmentList.Select(p =>
             {
                 dic = new Dictionary<string, object>();
                 dic["ID"] = p.ID;
                 dic["DepartmentName"] = p.DepartmentName;
                 return dic;
             }).ToList();
            dic = new Dictionary<string, object>();
            dic["ID"] = "";
            dic["DepartmentName"] = "全部";
            items.Insert(0, dic);
            var list = CKProductCategory.GetCKProductCategories();
            var categoryitems = list.Select(p =>
            {
                dic = new Dictionary<string, object>();
                dic["ID"] = p.ID;
                dic["Name"] = p.ProductCategoryName;
                return dic;
            }).ToList();
            dic = new Dictionary<string, object>();
            dic["ID"] = "";
            dic["Name"] = "全部";
            categoryitems.Insert(0, dic);
            var accpetman_list = Foresight.DataAccess.CKAccpetUser.GetCKAccpetUsers();
            var accpetmanitems = accpetman_list.Select(p =>
            {
                dic = new Dictionary<string, object>();
                dic["ID"] = p.AccpetUserID;
                dic["Name"] = p.AccpetUserName;
                return dic;
            }).ToList();
            dic = new Dictionary<string, object>();
            dic["ID"] = "";
            dic["Name"] = "全部";
            accpetmanitems.Insert(0, dic);
            WebUtil.WriteJson(context, new { DepartmentList = items, ProductCategoryList = categoryitems, AccpetManList = accpetmanitems });
        }
        private void approveckout(HttpContext context)
        {
            string IDs = context.Request.Params["IDList"];
            List<int> IDList = new List<int>();
            if (!string.IsNullOrEmpty(IDs))
            {
                IDList = JsonConvert.DeserializeObject<List<int>>(IDs);
            }
            if (IDList.Count > 0)
            {
                int ApproveStatus = WebUtil.GetIntValue(context, "approvestatus");
                string ApproveMan = "'" + WebUtil.GetUser(context).RealName + "'";
                using (SqlHelper helper = new SqlHelper())
                {
                    try
                    {
                        helper.BeginTransaction();
                        string cmdtext = string.Empty;
                        if (ApproveStatus == 1)
                        {
                            string ApproveYesTime = ApproveStatus == 1 ? "'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'" : "NULL";
                            cmdtext += "update [CKProductOutSumary] set [ApproveStatus]=" + ApproveStatus + ",[ApproveYesTime]=" + ApproveYesTime + ",[ApproveMan]=" + ApproveMan + " where [ID] in (" + string.Join(",", IDList.ToArray()) + ");";
                        }
                        else
                        {
                            string ApproveNoTime = ApproveStatus == 0 ? "'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'" : "NULL";
                            cmdtext += "update [CKProductOutSumary] set [ApproveStatus]=" + ApproveStatus + ",[ApproveNoTime]=" + ApproveNoTime + ",[ApproveMan]=" + ApproveMan + " where [ID] in (" + string.Join(",", IDList.ToArray()) + ");";
                        }
                        helper.Execute(cmdtext, CommandType.Text, new List<System.Data.SqlClient.SqlParameter>());
                        helper.Commit();
                    }
                    catch (Exception ex)
                    {
                        helper.Rollback();
                        LogHelper.WriteError("CKHandler", "visit:approveckin", ex);
                        WebUtil.WriteJson(context, new { status = false });
                        return;
                    }
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void approveckin(HttpContext context)
        {
            string IDs = context.Request.Params["IDList"];
            List<int> IDList = new List<int>();
            if (!string.IsNullOrEmpty(IDs))
            {
                IDList = JsonConvert.DeserializeObject<List<int>>(IDs);
            }
            if (IDList.Count > 0)
            {
                int ApproveStatus = WebUtil.GetIntValue(context, "approvestatus");
                string ApproveMan = "'" + WebUtil.GetUser(context).RealName + "'";
                using (SqlHelper helper = new SqlHelper())
                {
                    try
                    {
                        helper.BeginTransaction();
                        string cmdtext = string.Empty;
                        if (ApproveStatus == 1)
                        {
                            string ApproveYesTime = ApproveStatus == 1 ? "'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'" : "NULL";
                            cmdtext += "update [CKProductInSumary] set [ApproveStatus]=" + ApproveStatus + ",[ApproveYesTime]=" + ApproveYesTime + ",[ApproveMan]=" + ApproveMan + " where [ID] in (" + string.Join(",", IDList.ToArray()) + ");";
                        }
                        else
                        {
                            string ApproveNoTime = ApproveStatus == 0 ? "'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'" : "NULL";
                            cmdtext += "update [CKProductInSumary] set [ApproveStatus]=" + ApproveStatus + ",[ApproveNoTime]=" + ApproveNoTime + ",[ApproveMan]=" + ApproveMan + " where [ID] in (" + string.Join(",", IDList.ToArray()) + ");";
                        }
                        helper.Execute(cmdtext, CommandType.Text, new List<System.Data.SqlClient.SqlParameter>());
                        helper.Commit();
                    }
                    catch (Exception ex)
                    {
                        helper.Rollback();
                        LogHelper.WriteError("CKHandler", "visit:approveckin", ex);
                        WebUtil.WriteJson(context, new { status = false });
                        return;
                    }
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void removeckindetail(HttpContext context)
        {
            string IDs = context.Request.Params["IDList"];
            List<int> IDList = new List<int>();
            if (!string.IsNullOrEmpty(IDs))
            {
                IDList = JsonConvert.DeserializeObject<List<int>>(IDs);

            }
            if (IDList.Count > 0)
            {
                var inout_summarys = Foresight.DataAccess.CKInOutSummary.GetCKInOutSummaryListByInDetailIDList(IDList);
                if (inout_summarys.Length > 0)
                {
                    foreach (var ID in IDList)
                    {
                        var sub_inout_summarys = inout_summarys.Where(p => p.CKProudctInDetailID == ID).ToArray();
                        if (sub_inout_summarys.Length > 0)
                        {
                            var ckproduct = Foresight.DataAccess.CKProduct.GetCKProductByInDetailID(ID);
                            string ProductName = ckproduct == null ? string.Empty : ckproduct.ProductName;
                            WebUtil.WriteJson(context, new { status = false, error = "商品" + ProductName + "已出库，禁止删除" });
                            return;
                        }
                    }
                }
                using (SqlHelper helper = new SqlHelper())
                {
                    try
                    {
                        helper.BeginTransaction();
                        string cmdtext = string.Empty;
                        cmdtext += "delete from [CKProudctInDetail] where [ID] in (" + string.Join(",", IDList.ToArray()) + ");";
                        helper.Execute(cmdtext, CommandType.Text, new List<System.Data.SqlClient.SqlParameter>());
                        helper.Commit();
                    }
                    catch (Exception ex)
                    {
                        helper.Rollback();
                        LogHelper.WriteError("CKHandler", "visit:removeckoutdetail", ex);
                        WebUtil.WriteJson(context, new { status = false });
                        return;
                    }
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void removeckoutdetail(HttpContext context)
        {
            string IDs = context.Request.Params["IDList"];
            if (!string.IsNullOrEmpty(IDs))
            {
                List<int> IDList = JsonConvert.DeserializeObject<List<int>>(IDs);
                using (SqlHelper helper = new SqlHelper())
                {
                    try
                    {
                        helper.BeginTransaction();
                        string cmdtext = "delete from [CKInOutSummary] where [CKProudctOutDetailID] in (" + string.Join(",", IDList.ToArray()) + ");";
                        cmdtext += "delete from [CKProudctOutDetail] where [ID] in (" + string.Join(",", IDList.ToArray()) + ");";
                        helper.Execute(cmdtext, CommandType.Text, new List<System.Data.SqlClient.SqlParameter>());
                        helper.Commit();
                    }
                    catch (Exception ex)
                    {
                        helper.Rollback();
                        LogHelper.WriteError("CKHandler", "visit:removeckoutdetail", ex);
                        WebUtil.WriteJson(context, new { status = false });
                        return;
                    }
                }
                WebUtil.WriteJson(context, new { status = true });
            }
        }
        private void removeproductcategory(HttpContext context)
        {
            string IDs = context.Request.Params["IDList"];
            List<int> IDList = new List<int>();
            if (!string.IsNullOrEmpty(IDs))
            {
                IDList = JsonConvert.DeserializeObject<List<int>>(IDs);
            }
            if (IDList.Count > 0)
            {
                using (SqlHelper helper = new SqlHelper())
                {
                    try
                    {
                        helper.BeginTransaction();
                        string cmdtext = "delete from [CKProductCategory] where [ID] in (" + string.Join(",", IDList.ToArray()) + ")";
                        helper.Execute(cmdtext, CommandType.Text, new List<System.Data.SqlClient.SqlParameter>());
                        helper.Commit();
                    }
                    catch (Exception ex)
                    {
                        helper.Rollback();
                        LogHelper.WriteError("CKHandler", "visit:removeproductcategory", ex);
                        WebUtil.WriteJson(context, new { status = false });
                        return;
                    }
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void saveproductcategory(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            Foresight.DataAccess.CKProductCategory category = null;
            if (ID > 0)
            {
                category = Foresight.DataAccess.CKProductCategory.GetCKProductCategory(ID);
            }
            if (category == null)
            {
                category = new CKProductCategory();
                category.AddMan = WebUtil.GetUser(context).LoginName;
                category.AddTime = DateTime.Now;
            }
            category.ProductCategoryName = context.Request.Params["CategoryName"];
            category.ProductCategoryDesc = context.Request.Params["Remark"];
            category.Save();
            WebUtil.WriteJson(context, new { status = true });
        }
        private void loadproductcategorytree(HttpContext context)
        {
            try
            {
                string Keywords = context.Request.Params["Keywords"];
                int UserID = WebUtil.GetUser(context).UserID;
                var categorylist = Foresight.DataAccess.CKProductCategory.GetCKProductCategoryListByKeywords(Keywords);
                TreeModule treeModule = null;
                var items = categorylist.Select(p =>
                {
                    treeModule = new TreeModule();
                    treeModule.id = "category_" + p.ID.ToString();
                    treeModule.ID = p.ID;
                    treeModule.pId = "category_1";
                    treeModule.name = p.ProductCategoryName;
                    treeModule.isParent = false;
                    treeModule.open = true;
                    return treeModule;
                }).ToList();
                treeModule = new TreeModule();
                treeModule.id = "category_1";
                treeModule.ID = 0;
                treeModule.pId = "0";
                treeModule.name = WebUtil.GetCompany(context).CompanyName;
                bool hasckChild = categorylist.Length > 0;
                treeModule.isParent = hasckChild;
                treeModule.open = hasckChild;
                treeModule.type = EnumModel.CKCategoryType.company.ToString();
                items.Add(treeModule);
                WebUtil.WriteJson(context, items);
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("CKHandler.ashx", "visit: loadproductcategorytree", ex);
                context.Response.Write("[]");
            }
        }
        private void saveckacceptuser(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            Foresight.DataAccess.CKAccpetUser user = null;
            if (ID > 0)
            {
                user = CKAccpetUser.GetCKAccpetUser(ID);
            }
            if (user == null)
            {
                user = new CKAccpetUser();
            }
            user.AccpetUserName = context.Request["AcceptUserName"];
            user.Save();
            WebUtil.WriteJson(context, new { status = true, ID = user.AccpetUserID });
        }
        private void removeckacceptuser(HttpContext context)
        {
            string IDs = context.Request.Params["IDList"];
            if (!string.IsNullOrEmpty(IDs))
            {
                List<int> IDList = JsonConvert.DeserializeObject<List<int>>(IDs);
                using (SqlHelper helper = new SqlHelper())
                {
                    try
                    {
                        helper.BeginTransaction();
                        string cmdtext = "delete from [CKAccpetUser] where [AccpetUserID] in (" + string.Join(",", IDList.ToArray()) + ")";
                        helper.Execute(cmdtext, CommandType.Text, new List<System.Data.SqlClient.SqlParameter>());
                        helper.Commit();
                    }
                    catch (Exception ex)
                    {
                        helper.Rollback();
                        LogHelper.WriteError("CKHandler", "visit:removeckacceptuser", ex);
                        WebUtil.WriteJson(context, new { status = false });
                        return;
                    }
                }
                WebUtil.WriteJson(context, new { status = true });
            }
        }
        private void loadckacceptusergrid(HttpContext context)
        {
            string Keywords = context.Request.Params["Keywords"];
            string page = context.Request.Form["page"];
            string rows = context.Request.Form["rows"];
            long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
            int pageSize = int.Parse(rows);
            DataGrid dg = CKAccpetUser.GetCKAccpetUserGridByKeywords(Keywords, "order by AccpetUserID desc", startRowIndex, pageSize);
            string result = JsonConvert.SerializeObject(dg);
            context.Response.Write(result);
        }
        private void removeckdepartment(HttpContext context)
        {
            string IDs = context.Request.Params["IDList"];
            if (!string.IsNullOrEmpty(IDs))
            {
                List<int> IDList = JsonConvert.DeserializeObject<List<int>>(IDs);
                using (SqlHelper helper = new SqlHelper())
                {
                    try
                    {
                        helper.BeginTransaction();
                        string cmdtext = "delete from [CKDepartment] where [ID] in (" + string.Join(",", IDList.ToArray()) + ")";
                        helper.Execute(cmdtext, CommandType.Text, new List<System.Data.SqlClient.SqlParameter>());
                        helper.Commit();
                    }
                    catch (Exception ex)
                    {
                        helper.Rollback();
                        LogHelper.WriteError("CKHandler", "visit:removeckdepartment", ex);
                        WebUtil.WriteJson(context, new { status = false });
                        return;
                    }
                }
                WebUtil.WriteJson(context, new { status = true });
            }
        }
        private void loadckdepartmentgrid(HttpContext context)
        {
            string Keywords = context.Request.Params["Keywords"];
            string page = context.Request.Form["page"];
            string rows = context.Request.Form["rows"];
            long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
            int pageSize = int.Parse(rows);
            DataGrid dg = CKDepartment.GetCKDepartmentGridByKeywords(Keywords, "order by AddTime desc", startRowIndex, pageSize);
            string result = JsonConvert.SerializeObject(dg);
            context.Response.Write(result);
        }
        private void saveckdepartment(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            Foresight.DataAccess.CKDepartment ckdepartment = null;
            if (ID > 0)
            {
                ckdepartment = CKDepartment.GetCKDepartment(ID);
            }
            if (ckdepartment == null)
            {
                ckdepartment = new CKDepartment();
                ckdepartment.AddTime = DateTime.Now;
            }
            ckdepartment.DepartmentName = context.Request.Params["DepartmentName"];
            ckdepartment.Description = context.Request.Params["Description"];
            ckdepartment.SortOrder = WebUtil.GetIntValue(context, "SortOrder");
            ckdepartment.Save();
            WebUtil.WriteJson(context, new { status = true, ID = ckdepartment.ID });
        }
        private void loadmateriallingyonganalysis(HttpContext context)
        {
            string Keywords = context.Request.Params["Keywords"];
            int TreeID = WebUtil.GetIntValue(context, "TreeID");
            string page = context.Request.Form["page"];
            string rows = context.Request.Form["rows"];
            long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
            int pageSize = int.Parse(rows);
            List<int> CategoryIDList = new List<int>();
            if (TreeID > 1)
            {
                CategoryIDList = CKCategory.SelectChildCategorytByID(TreeID).Select(p => p.ID).ToList();
            }
            DateTime StartTime = WebUtil.GetDateValue(context, "StartTime");
            DateTime EndTime = WebUtil.GetDateValue(context, "EndTime");
            bool canexport = WebUtil.GetBoolValue(context, "canexport");
            DataGrid dg = ViewCKMaterialAnalysis.GetViewCKMaterialAnalysisGridBy(Keywords, CategoryIDList, StartTime, EndTime, "order by ID desc", startRowIndex, pageSize, canexport: canexport);
            if (canexport)
            {
                string downloadurl = string.Empty;
                string error = string.Empty;
                bool status = APPCode.ExportHelper.DownLoadCKMaterialLingYongData(dg, out downloadurl, out error);
                WebUtil.WriteJson(context, new { status = status, downloadurl = downloadurl, error = error });
                return;
            }
            string result = JsonConvert.SerializeObject(dg);
            context.Response.Write(result);
        }
        private void saveincategory(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            Foresight.DataAccess.CKInCategory ckinCategory = null;
            if (ID > 0)
            {
                ckinCategory = CKInCategory.GetCKInCategory(ID);
            }
            if (ckinCategory == null)
            {
                ckinCategory = new CKInCategory();
                ckinCategory.AddTime = DateTime.Now;
            }
            ckinCategory.InCategoryName = context.Request.Params["InCategoryName"];
            ckinCategory.InCategoryDesc = context.Request.Params["InCategoryDesc"];
            ckinCategory.CategoryType = context.Request.Params["CategoryType"];
            ckinCategory.PrintLineCount = WebUtil.GetIntValue(context, "PrintLineCount");
            ckinCategory.Save();
            WebUtil.WriteJson(context, new { status = true, ID = ckinCategory.ID });
        }
        private void removeincategory(HttpContext context)
        {
            string IDs = context.Request.Params["IDList"];
            if (!string.IsNullOrEmpty(IDs))
            {
                List<int> IDList = JsonConvert.DeserializeObject<List<int>>(IDs);
                using (SqlHelper helper = new SqlHelper())
                {
                    try
                    {
                        helper.BeginTransaction();
                        string cmdtext = "delete from [CKInCategory] where [ID] in (" + string.Join(",", IDList.ToArray()) + ")";
                        helper.Execute(cmdtext, CommandType.Text, new List<System.Data.SqlClient.SqlParameter>());
                        helper.Commit();
                    }
                    catch (Exception ex)
                    {
                        helper.Rollback();
                        LogHelper.WriteError("CKHandler", "visit:removeincategory", ex);
                        WebUtil.WriteJson(context, new { status = false });
                        return;
                    }
                }
                WebUtil.WriteJson(context, new { status = true });
            }
        }
        private void loadincategorygrid(HttpContext context)
        {
            string Keywords = context.Request.Params["Keywords"];
            string page = context.Request.Form["page"];
            string rows = context.Request.Form["rows"];
            long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
            int pageSize = int.Parse(rows);
            string CategoryType = context.Request["CategoryType"];
            DataGrid dg = CKInCategory.GetCKInCategoryGridByKeywords(Keywords, CategoryType, "order by AddTime desc", startRowIndex, pageSize);
            string result = JsonConvert.SerializeObject(dg);
            context.Response.Write(result);
        }
        private void loadinventorygrid(HttpContext context)
        {
            try
            {
                string Keywords = context.Request.Params["Keywords"];
                string CategoryIDs = context.Request["CategoryIDs"];
                string DepartmentIDs = context.Request["DepartmentIDs"];
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                List<int> TopCategoryIDList = new List<int>();
                List<int> CategoryIDList = new List<int>();
                if (!string.IsNullOrEmpty(CategoryIDs))
                {
                    TopCategoryIDList = JsonConvert.DeserializeObject<List<int>>(CategoryIDs);
                    if (TopCategoryIDList.Count > 0)
                    {
                        CategoryIDList = CKCategory.SelectChildCategorytByID(TopCategoryIDList).Select(p => p.ID).ToList();
                    }
                }
                bool IncludDepartment = false;
                if (!string.IsNullOrEmpty(context.Request["IncludDepartment"]))
                {
                    bool.TryParse(context.Request["IncludDepartment"], out IncludDepartment);
                }
                List<int> DepartmentIDList = new List<int>();
                if (!string.IsNullOrEmpty(DepartmentIDs))
                {
                    DepartmentIDList = JsonConvert.DeserializeObject<List<int>>(DepartmentIDs);
                }
                DateTime StartTime = WebUtil.GetDateValue(context, "StartTime");
                DateTime EndTime = WebUtil.GetDateValue(context, "EndTime");
                int ProductCategoryID = WebUtil.GetIntValue(context, "ProductCategoryID");
                bool HideInventory = false;
                if (!string.IsNullOrEmpty(context.Request["HideInventory"]))
                {
                    bool.TryParse(context.Request["HideInventory"], out HideInventory);
                }
                bool canexport = WebUtil.GetBoolValue(context, "canexport");
                DataGrid dg = ViewCKProudctInventory.GetViewCKProudctInventoryGridByCategoryID(Keywords, CategoryIDList, StartTime, EndTime, DepartmentIDList, IncludDepartment, "order by ID desc", startRowIndex, pageSize, ProductCategoryID: ProductCategoryID, HideInventory: HideInventory, canexport: canexport);
                if (canexport)
                {
                    string downloadurl = string.Empty;
                    string error = string.Empty;
                    bool status = APPCode.ExportHelper.DownLoadCKInventoryData(dg, out downloadurl, out error);
                    WebUtil.WriteJson(context, new { status = status, downloadurl = downloadurl, error = error });
                    return;
                }
                string result = JsonConvert.SerializeObject(dg);
                context.Response.Write(result);
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("CKHandler", "loadinventorygrid", ex);
                WebUtil.WriteJson(context, new Foresight.DataAccess.Ui.DataGrid());
            }
        }
        private void loadoutproductdetailgrid(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            int ServiceID = WebUtil.GetIntValue(context, "ServiceID");
            string page = context.Request.Form["page"];
            string rows = context.Request.Form["rows"];
            long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
            int pageSize = int.Parse(rows);
            List<int> InIDList = new List<int>();
            if (!string.IsNullOrEmpty(context.Request["InIDList"]))
            {
                InIDList = JsonConvert.DeserializeObject<List<int>>(context.Request["InIDList"]).Distinct().ToList();
            }
            DataGrid dg = new DataGrid();
            if (InIDList.Count > 0 || ServiceID > 0)
            {
                dg = ViewCKProudctInDetail.GetViewCKProudctInDetailGridBySummaryID(0, ServiceID, "order by AddTime desc", startRowIndex, pageSize, InIDList: InIDList);
                ViewCKProudctInDetail[] inlist = dg.rows as ViewCKProudctInDetail[];
                List<ProductOutRow> ProductRowList = new List<ProductOutRow>();
                foreach (var item in inlist)
                {
                    ProductOutRow outitem = new ProductOutRow();
                    outitem.ProductName = item.ProductName;
                    outitem.ModelNumber = item.ModelNumber;
                    outitem.OutTotalCount = item.InTotalCount;
                    outitem.OutTotalPrice = item.InTotalPrice;
                    outitem.Unit = item.Unit;
                    outitem.UnitPrice = item.UnitPrice;
                    outitem.ProductID = item.ProductID;
                    outitem.TotalInventory = CKProudctInDetail.GetTotalInventory(item.ProductID);
                    outitem.InBasicUnitPrice = 0;
                    ProductRowList.Add(outitem);
                }
                dg.total = ProductRowList.Count;
                dg.rows = ProductRowList;
                dg.page = 1;
            }
            else
            {
                dg = ViewCKProudctOutDetail.GetViewCKProudctOutDetailGridBySummaryID(ID, "order by AddTime desc", startRowIndex, pageSize);
            }
            WebUtil.WriteJson(context, dg);
        }
        private void saveckoutsummary(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            Foresight.DataAccess.CKProductOutSumary summary = null;
            if (ID > 0)
            {
                summary = CKProductOutSumary.GetCKProductOutSumary(ID);
            }
            if (summary == null)
            {
                summary = new CKProductOutSumary();
                summary.AddMan = context.Request.Params["AddMan"];
                summary.AddTime = DateTime.Now;
                int OrderNumberID = 0;
                summary.OrderNumber = Foresight.DataAccess.CKProductOutSumary.GetLastestOrderNumber(out OrderNumberID);
                summary.OrderNumberID = OrderNumberID;
                summary.CKCategoryID = WebUtil.GetIntValue(context, "CKCategoryID");
            }
            summary.AddUserName = context.Request.Params["AddUserName"];
            summary.OutTime = WebUtil.GetDateValue(context, "OutTime");
            summary.AcceptUserID = WebUtil.GetIntValue(context, "AccpetUserID");
            summary.AcceptUserName = context.Request.Params["AcceptUserName"];
            summary.AccpetDepartmentName = context.Request.Params["AccpetDepartmentName"];
            summary.UseFor = context.Request.Params["UseFor"];
            summary.InCategoryID = WebUtil.GetIntValue(context, "InCategoryID");
            summary.BelongTeamName = context.Request.Params["BelongTeamName"];
            summary.BelongDepartmentID = WebUtil.GetIntValue(context, "BelongTeamID");
            string ProductRows = context.Request.Params["ProductRows"];
            List<ProductOutRow> ProductRowList = new List<ProductOutRow>();
            if (!string.IsNullOrEmpty(ProductRows))
            {
                ProductRowList = JsonConvert.DeserializeObject<List<ProductOutRow>>(ProductRows);
            }
            List<Model.CKOutDetailSummary> CKProudctInDetailList = new List<Model.CKOutDetailSummary>();
            var ProductIDList = ProductRowList.Select(p => p.ProductID).ToList();
            var indetail_list = Foresight.DataAccess.CKProudctInDetail2.GetCKProudctInDetailListByProductIDList(ProductIDList, summary.CKCategoryID);
            foreach (var item in ProductRowList)
            {
                CKProudctOutDetail ckProudctInDetail = null;
                if (item.ID > 0)
                {
                    ckProudctInDetail = CKProudctOutDetail.GetCKProudctOutDetail(item.ID);
                }
                if (ckProudctInDetail != null)
                {
                    var outdetailsummary = new Model.CKOutDetailSummary();
                    ckProudctInDetail.Remark = item.Remark;
                    outdetailsummary.outdetail = ckProudctInDetail;
                    outdetailsummary.inoutlist = new List<Foresight.DataAccess.CKInOutSummary>();
                    CKProudctInDetailList.Add(outdetailsummary);
                }
                else
                {
                    var outdetailsummary = new Model.CKOutDetailSummary();
                    var inoutlist = new List<Foresight.DataAccess.CKInOutSummary>();
                    ckProudctInDetail = new CKProudctOutDetail();
                    ckProudctInDetail.ProductID = item.ProductID;
                    ckProudctInDetail.UnitPrice = item.UnitPrice;
                    ckProudctInDetail.OutTotalCount = item.OutTotalCount;
                    ckProudctInDetail.OutTotalPrice = item.OutTotalPrice;
                    ckProudctInDetail.AddTime = DateTime.Now;
                    ckProudctInDetail.AddMan = context.Request.Params["AddMan"];
                    ckProudctInDetail.InBasicUnitPrice = item.InBasicUnitPrice;
                    ckProudctInDetail.Remark = item.Remark;
                    outdetailsummary.outdetail = ckProudctInDetail;
                    var one_indetail_list = indetail_list.Where(p => p.ProductID == item.ProductID).OrderBy(p => p.InTime);
                    //.OrderBy(p => p.SysProductOrderNumber).ThenBy(p => p.AddTime).ToArray();
                    var totalinvetory = one_indetail_list.Sum(p =>
                    {
                        int inventory = (p.InTotalCount > 0 ? p.InTotalCount : 0) - (p.OutTotalCount > 0 ? p.OutTotalCount : 0);
                        return inventory;
                    });
                    if (totalinvetory < item.OutTotalCount)
                    {
                        WebUtil.WriteJson(context, new { status = false, error = "出库数量不能大于库存总数" });
                        return;
                    }
                    int resut_total = item.OutTotalCount;
                    foreach (var indetail in one_indetail_list)
                    {
                        int inventory = (indetail.InTotalCount > 0 ? indetail.InTotalCount : 0) - (indetail.OutTotalCount > 0 ? indetail.OutTotalCount : 0);
                        if (inventory <= 0)
                        {
                            continue;
                        }
                        var inout_summary = new Foresight.DataAccess.CKInOutSummary();
                        inout_summary.AddTime = DateTime.Now;
                        inout_summary.CKProudctInDetailID = indetail.ID;

                        resut_total = resut_total - inventory;
                        if (resut_total <= 0)
                        {
                            inout_summary.Inventory = inventory + resut_total;
                            inoutlist.Add(inout_summary);
                            break;
                        }
                        inout_summary.Inventory = inventory;
                        inoutlist.Add(inout_summary);
                    }
                    outdetailsummary.inoutlist = inoutlist;
                    CKProudctInDetailList.Add(outdetailsummary);
                }
            }
            int ServiceID = WebUtil.GetIntValue(context, "ServiceID");
            Foresight.DataAccess.CustomerService service = null;
            if (ServiceID > 0)
            {
                service = Foresight.DataAccess.CustomerService.GetCustomerService(ServiceID);
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    summary.Save(helper);
                    foreach (var item in CKProudctInDetailList)
                    {
                        item.outdetail.OutSummaryID = summary.ID;
                        item.outdetail.Save(helper);
                        foreach (var item2 in item.inoutlist)
                        {
                            item2.CKProudctOutDetailID = item.outdetail.ID;
                            item2.Save(helper);
                        }
                    }
                    if (service != null)
                    {
                        service.CKProductOutSumaryID = summary.ID;
                        service.Save(helper);
                    }
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError("CKHandler", "visit: saveckoutsummary", ex);
                    WebUtil.WriteJson(context, new { status = false });
                    return;
                }
            }
            WebUtil.WriteJson(context, new { status = true, ID = summary.ID });
        }
        private void getoutdetailparams(HttpContext context)
        {
            var userlist = Foresight.DataAccess.CKAccpetUser.GetCKAccpetUsers();
            var inCategoryList = CKInCategory.GetCKInCategories().Where(p => p.CategoryType.Equals(EnumModel.InCategoryTypeDefine.chuku.ToString())); ;
            var DepartmentList = CKDepartment.GetCKDepartments();
            WebUtil.WriteJson(context, new { UserList = userlist, InCategoryList = inCategoryList, DepartmentList = DepartmentList });
        }
        private void removeckout(HttpContext context)
        {
            string IDs = context.Request.Params["IDList"];
            if (!string.IsNullOrEmpty(IDs))
            {
                List<int> IDList = JsonConvert.DeserializeObject<List<int>>(IDs);
                using (SqlHelper helper = new SqlHelper())
                {
                    try
                    {
                        helper.BeginTransaction();
                        string cmdtext = "delete from [CKInOutSummary] where [CKProudctOutDetailID] in (select [ID] from [CKProudctOutDetail] where [OutSummaryID] in (" + string.Join(",", IDList.ToArray()) + "));";
                        cmdtext += "delete from [CKProudctOutDetail] where [OutSummaryID] in (" + string.Join(",", IDList.ToArray()) + ");";
                        cmdtext += "delete from [CKProductOutSumary] where [ID] in (" + string.Join(",", IDList.ToArray()) + ");";
                        helper.Execute(cmdtext, CommandType.Text, new List<System.Data.SqlClient.SqlParameter>());
                        helper.Commit();
                    }
                    catch (Exception ex)
                    {
                        helper.Rollback();
                        LogHelper.WriteError("CKHandler", "visit:removeckout", ex);
                        WebUtil.WriteJson(context, new { status = false });
                        return;
                    }
                }
                WebUtil.WriteJson(context, new { status = true });
            }
        }
        private void loadoutgrid(HttpContext context)
        {
            string Keywords = context.Request.Params["Keywords"];
            string page = context.Request.Form["page"];
            string rows = context.Request.Form["rows"];
            long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
            int pageSize = int.Parse(rows);
            DateTime StartTime = WebUtil.GetDateValue(context, "StartTime");
            DateTime EndTime = WebUtil.GetDateValue(context, "EndTime");
            int DepartmentID = WebUtil.GetIntValue(context, "DepartmentID");
            int CKCategoryID = WebUtil.GetIntValue(context, "CKCategoryID");
            int ProductCategoryID = WebUtil.GetIntValue(context, "ProductCategoryID");
            int AcceptUserID = WebUtil.GetIntValue(context, "AcceptUserID");
            string DepartmentName = context.Request["DepartmentName"];
            bool canexport = WebUtil.GetBoolValue(context, "canexport");
            DataGrid dg = ViewCKProudctOutDetail.GetViewCKProudctOutDetailGridByKeywords(Keywords, StartTime, EndTime, DepartmentID, CKCategoryID, "order by OutSummaryID desc, ID asc", startRowIndex, pageSize, ProductCategoryID: ProductCategoryID, AcceptUserID: AcceptUserID, DepartmentName: DepartmentName, canexport: canexport);
            if (canexport)
            {
                string downloadurl = string.Empty;
                string error = string.Empty;
                bool status = APPCode.ExportHelper.DownLoadCkOutData(dg, out downloadurl, out error);
                WebUtil.WriteJson(context, new { status = status, downloadurl = downloadurl, error = error });
                return;
            }
            string result = JsonConvert.SerializeObject(dg);
            context.Response.Write(result);
        }
        private void savecategory(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            int ParentID = WebUtil.GetIntValue(context, "ParentID");
            Foresight.DataAccess.CKCategory category = null;
            if (ID > 0)
            {
                category = Foresight.DataAccess.CKCategory.GetCKCategory(ID);
            }
            if (category == null)
            {
                category = new CKCategory();
                category.AddMan = context.Request.Params["AddMan"];
                category.AddTime = DateTime.Now;
            }
            if (ParentID > 0)
            {
                category.ParentID = ParentID;
            }
            if (!string.IsNullOrEmpty(context.Request.Params["CategoryType"]))
            {
                category.CategoryType = context.Request.Params["CategoryType"];
            }
            category.CategoryName = context.Request.Params["CategoryName"];
            category.CategoryDesc = context.Request.Params["Remark"];
            category.Save();
            #region 保存权限
            if (ID <= 0)
            {
                RoleCKCategory.InsertCKCategory(category.ID);
            }
            #endregion
            WebUtil.WriteJson(context, new { status = true });
        }
        private void removecategory(HttpContext context)
        {
            string IDs = context.Request.Params["IDList"];
            var list = CKCategory.GetCKCategories();
            if (!string.IsNullOrEmpty(IDs))
            {
                List<int> IDList = JsonConvert.DeserializeObject<List<int>>(IDs);
                foreach (var ID in IDList)
                {
                    if (list.Any(p => p.ParentID == ID))
                    {
                        WebUtil.WriteJson(context, new { status = true, haschild = true });
                        return;
                    }
                }
                using (SqlHelper helper = new SqlHelper())
                {
                    try
                    {
                        helper.BeginTransaction();
                        string cmdtext = "delete from [CKCategory] where [ID] in (" + string.Join(",", IDList.ToArray()) + ")";
                        helper.Execute(cmdtext, CommandType.Text, new List<System.Data.SqlClient.SqlParameter>());
                        helper.Commit();
                    }
                    catch (Exception ex)
                    {
                        helper.Rollback();
                        LogHelper.WriteError("CKHandler", "visit:removecategory", ex);
                        WebUtil.WriteJson(context, new { status = false });
                        return;
                    }
                }
                WebUtil.WriteJson(context, new { status = true, haschild = false });
            }
        }
        private void loadcategorygrid(HttpContext context)
        {
            try
            {
                string Keywords = context.Request.Params["keywords"];
                CKCategory[] list = Foresight.DataAccess.CKCategory.GetCKCategoryGridByKeywords(Keywords);
                var items = list.Select(p =>
                {
                    var dic = new Dictionary<string, object>();
                    dic["id"] = p.ID;
                    dic["name"] = p.CategoryName;
                    dic["_parentId"] = p.ParentID < 0 ? 1 : p.ParentID;
                    dic["CategoryType"] = p.CategoryType;
                    if (p.CategoryType.Equals(Utility.EnumModel.CKCategoryType.warehouse.ToString()))
                    {
                        if (list.Any(o => o.ParentID == p.ID))
                        {
                            dic["state"] = "closed";
                        }
                    }
                    return dic;
                }).ToList();
                var dic2 = new Dictionary<string, object>();
                dic2["id"] = 1;
                dic2["name"] = WebUtil.GetCompany(context).CompanyName;
                dic2["_parentId"] = 0;
                dic2["CategoryType"] = Utility.EnumModel.CKCategoryType.company.ToString();
                items.Add(dic2);
                DataGrid dg = new DataGrid();
                dg.rows = items;
                dg.total = items.Count;
                string result = JsonConvert.SerializeObject(dg);
                context.Response.Write(result);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.WriteError("CKHandler", "命令:loadservicelist", ex);
                context.Response.Write("{\"rows\":[],\"total\":0,\"page\":0}");
            }
        }
        private void removeckin(HttpContext context)
        {
            string IDs = context.Request.Params["IDList"];
            if (!string.IsNullOrEmpty(IDs))
            {
                List<int> IDList = JsonConvert.DeserializeObject<List<int>>(IDs);
                var inout_list = Foresight.DataAccess.CKInOutSummary.GetCKInOutSummaryListByInSummaryIDList(IDList);
                if (inout_list.Length > 0)
                {
                    WebUtil.WriteJson(context, new { status = false, error = "当前入库商品已出库，不允许删除" });
                    return;
                }
                using (SqlHelper helper = new SqlHelper())
                {
                    try
                    {
                        helper.BeginTransaction();
                        string cmdtext = "delete from [CKInOutSummary] where [CKProudctInDetailID] in (select [ID] from [CKProudctInDetail] where [InSummaryID] in (" + string.Join(",", IDList.ToArray()) + "));";
                        cmdtext += "delete from [CKProudctInDetail] where [InSummaryID] in (" + string.Join(",", IDList.ToArray()) + ")";
                        cmdtext += "delete from [CKProductInSumary] where [ID] in (" + string.Join(",", IDList.ToArray()) + ")";
                        helper.Execute(cmdtext, CommandType.Text, new List<System.Data.SqlClient.SqlParameter>());
                        helper.Commit();
                    }
                    catch (Exception ex)
                    {
                        helper.Rollback();
                        LogHelper.WriteError("CKHandler", "visit:removeckin", ex);
                        WebUtil.WriteJson(context, new { status = false });
                        return;
                    }
                }
                WebUtil.WriteJson(context, new { status = true });
            }
        }
        private void loadinproductdetailgrid(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            int ServiceID = WebUtil.GetIntValue(context, "ServiceID");
            string page = context.Request.Form["page"];
            string rows = context.Request.Form["rows"];
            long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
            int pageSize = int.Parse(rows);
            DataGrid dg = ViewCKProudctInDetail.GetViewCKProudctInDetailGridBySummaryID(ID, ServiceID, "order by AddTime desc", startRowIndex, pageSize);
            string result = JsonConvert.SerializeObject(dg);
            context.Response.Write(result);
        }
        private void getindetailparams(HttpContext context)
        {
            var contractlist = CKContarct.GetCKContarcts();
            var inCategoryList = CKInCategory.GetCKInCategories().Where(p => p.CategoryType.Equals(EnumModel.InCategoryTypeDefine.ruku.ToString()));
            var departmentList = CKDepartment.GetCKDepartments();
            WebUtil.WriteJson(context, new { ContractList = contractlist, InCategoryList = inCategoryList, DepartmentList = departmentList });
        }
        private void saveckinsummary(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            Foresight.DataAccess.CKProductInSumary insummary = null;
            if (ID > 0)
            {
                insummary = CKProductInSumary.GetCKProductInSumary(ID);
            }
            if (insummary == null)
            {
                insummary = new CKProductInSumary();
                insummary.AddMan = context.Request.Params["AddMan"];
                insummary.AddTime = DateTime.Now;
                int OrderNumberID = 0;
                insummary.OrderNumber = Foresight.DataAccess.CKProductInSumary.GetLastestOrderNumber(out OrderNumberID);
                insummary.OrderNumberID = OrderNumberID;
                insummary.CKCategoryID = WebUtil.GetIntValue(context, "CKCategoryID");
            }
            DateTime InTime = WebUtil.GetDateValue(context, "InTime");
            insummary.AddUserName = context.Request.Params["AddUserName"];
            //insummary.InTime = WebUtil.GetDateValue(context, "InTime");
            insummary.ContractID = WebUtil.GetIntValue(context, "ContractID");
            insummary.ContractName = context.Request.Params["ContractName"];
            insummary.ContractUserName = context.Request.Params["ContractUserName"];
            insummary.ContractPhoneNumber = context.Request.Params["ContractPhoneNumber"];
            insummary.InCategoryID = WebUtil.GetIntValue(context, "InCategoryID");
            insummary.BelongTeamName = context.Request["BelongTeamName"];
            insummary.BelongDepartmentID = WebUtil.GetIntValue(context, "BelongDepartmentID");
            string ProductRows = context.Request.Params["ProductRows"];
            List<ProductRow> ProductRowList = new List<ProductRow>();
            if (!string.IsNullOrEmpty(ProductRows))
            {
                ProductRowList = JsonConvert.DeserializeObject<List<ProductRow>>(ProductRows);
            }
            List<CKProudctInDetail> CKProudctInDetailList = new List<CKProudctInDetail>();
            var InDetailIDList = ProductRowList.Where(p => p.ID > 0).Select(p => p.ID).ToList();
            var inout_summarys = Foresight.DataAccess.CKInOutSummary.GetCKInOutSummaryListByInDetailIDList(InDetailIDList);
            foreach (var item in ProductRowList)
            {
                CKProudctInDetail ckProudctInDetail = null;
                if (item.ID > 0)
                {
                    ckProudctInDetail = CKProudctInDetail.GetCKProudctInDetail(item.ID);
                }
                if (ckProudctInDetail == null)
                {
                    ckProudctInDetail = new CKProudctInDetail();
                    ckProudctInDetail.AddTime = DateTime.Now;
                    ckProudctInDetail.AddMan = WebUtil.GetUser(context).RealName;
                }
                else
                {
                    var sub_inout_summarys = inout_summarys.Where(p => p.CKProudctInDetailID == item.ID).ToArray();
                    if (sub_inout_summarys.Length > 0)
                    {
                        if (InTime != insummary.InTime && insummary.InTime > DateTime.MinValue)
                        {
                            WebUtil.WriteJson(context, new { status = false, error = "该入库单已出库，入库时间禁止修改" });
                            return;
                        }
                        decimal totaloutcount = sub_inout_summarys.Sum(p => p.Inventory);
                        if (totaloutcount > item.InTotalCount)
                        {
                            var ckproduct = Foresight.DataAccess.CKProduct.GetCKProduct(item.ProductID);
                            string ProductName = ckproduct == null ? string.Empty : ckproduct.ProductName;
                            WebUtil.WriteJson(context, new { status = false, error = "商品" + ProductName + "库存数量不能小于出库数量" });
                            return;
                        }
                    }
                }
                ckProudctInDetail.ProductID = item.ProductID;
                ckProudctInDetail.UnitPrice = item.UnitPrice;
                ckProudctInDetail.InTotalCount = item.InTotalCount;
                ckProudctInDetail.InTotalPrice = item.InTotalPrice;
                ckProudctInDetail.Remark = item.Remark;
                CKProudctInDetailList.Add(ckProudctInDetail);
            }
            insummary.InTime = InTime;
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    insummary.Save(helper);
                    foreach (var item in CKProudctInDetailList)
                    {
                        if (item.ID <= 0 && item.ProductID > 0)
                        {
                            item.SysProductOrderNumber = Foresight.DataAccess.CKProudctInDetail.GetLatestProductOrderNumber(helper);
                        }
                        item.InSummaryID = insummary.ID;
                        item.Save(helper);
                    }
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError("CKHandler", "visit:saveckinsummary", ex);
                    WebUtil.WriteJson(context, new { status = false });
                    return;
                }
            }
            WebUtil.WriteJson(context, new { status = true, ID = insummary.ID });
        }
        private void loadingrid(HttpContext context)
        {
            string Keywords = context.Request.Params["Keywords"];
            string page = context.Request.Form["page"];
            string rows = context.Request.Form["rows"];
            long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
            int pageSize = int.Parse(rows);
            DateTime StartTime = WebUtil.GetDateValue(context, "StartTime");
            DateTime EndTime = WebUtil.GetDateValue(context, "EndTime");
            int CKCategoryID = WebUtil.GetIntValue(context, "CKCategoryID");
            int ProductCategoryID = WebUtil.GetIntValue(context, "ProductCategoryID");
            bool canexport = WebUtil.GetBoolValue(context, "canexport");
            DataGrid dg = ViewCKProudctInDetail.GetViewCKProudctInDetailGridByKeywords(Keywords, StartTime, EndTime, "order by InSummaryID desc, ID asc", startRowIndex, pageSize, CKCategoryID, ProductCategoryID: ProductCategoryID, canexport: canexport);
            if (canexport)
            {
                string downloadurl = string.Empty;
                string error = string.Empty;
                bool status = APPCode.ExportHelper.DownLoadCKInData(dg, out downloadurl, out error);
                WebUtil.WriteJson(context, new { status = status, downloadurl = downloadurl, error = error });
                return;
            }
            string result = JsonConvert.SerializeObject(dg);
            context.Response.Write(result);
        }
        private void loadcontractgrid(HttpContext context)
        {
            string Keywords = context.Request.Params["Keywords"];
            string page = context.Request.Form["page"];
            string rows = context.Request.Form["rows"];
            long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
            int pageSize = int.Parse(rows);
            DataGrid dg = CKContarct.GetCKContarctGridByKeywords(Keywords, "order by AddTime desc", startRowIndex, pageSize);
            string result = JsonConvert.SerializeObject(dg);
            context.Response.Write(result);
        }
        private void removecontract(HttpContext context)
        {
            string IDs = context.Request.Params["IDList"];
            if (!string.IsNullOrEmpty(IDs))
            {
                List<int> IDList = JsonConvert.DeserializeObject<List<int>>(IDs);
                using (SqlHelper helper = new SqlHelper())
                {
                    try
                    {
                        helper.BeginTransaction();
                        string cmdtext = "delete from [CKContarct] where [ID] in (" + string.Join(",", IDList.ToArray()) + ")";
                        helper.Execute(cmdtext, CommandType.Text, new List<System.Data.SqlClient.SqlParameter>());
                        helper.Commit();
                    }
                    catch (Exception ex)
                    {
                        helper.Rollback();
                        LogHelper.WriteError("CKHandler", "visit:removecontract", ex);
                        WebUtil.WriteJson(context, new { status = false });
                        return;
                    }
                }
                WebUtil.WriteJson(context, new { status = true });
            }
        }
        private void savecontract(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            Foresight.DataAccess.CKContarct contract = null;
            if (ID > 0)
            {
                contract = CKContarct.GetCKContarct(ID);
            }
            if (contract == null)
            {
                contract = new CKContarct();
                contract.AddMan = context.Request.Params["AddMan"];
                contract.AddTime = DateTime.Now;
                contract.ContractNumber = context.Request.Params["ContractNumber"];
            }
            contract.ContractName = context.Request.Params["ContractName"];
            contract.ContractFullName = context.Request.Params["ContractFullName"];
            contract.Address = context.Request.Params["Address"];
            contract.ContactMan = context.Request.Params["ContactMan"];
            contract.PhoneNumber = context.Request.Params["PhoneNumber"];
            contract.FaxNumber = context.Request.Params["FaxNumber"];
            contract.EMailAddress = context.Request.Params["EMailAddress"];
            contract.Remark = context.Request.Params["Remark"];
            contract.Save();
            WebUtil.WriteJson(context, new { status = true, ID = contract.ID });
        }
        private void removeproduct(HttpContext context)
        {
            string IDs = context.Request.Params["IDList"];
            if (!string.IsNullOrEmpty(IDs))
            {
                List<int> IDList = JsonConvert.DeserializeObject<List<int>>(IDs);
                using (SqlHelper helper = new SqlHelper())
                {
                    try
                    {
                        helper.BeginTransaction();
                        string cmdtext = "delete from [CKProduct] where [ID] in (" + string.Join(",", IDList.ToArray()) + ")";
                        helper.Execute(cmdtext, CommandType.Text, new List<System.Data.SqlClient.SqlParameter>());
                        helper.Commit();
                    }
                    catch (Exception ex)
                    {
                        helper.Rollback();
                        LogHelper.WriteError("CKHandler", "visit:removeproduct", ex);
                        WebUtil.WriteJson(context, new { status = false });
                        return;
                    }
                }
                WebUtil.WriteJson(context, new { status = true });
            }
        }
        private void loadproductgrid(HttpContext context)
        {
            string Keywords = context.Request.Params["Keywords"];
            string TreeID = context.Request["TreeID"];
            List<int> CategoryIDList = new List<int>();
            if (!string.IsNullOrEmpty(TreeID))
            {
                CategoryIDList = JsonConvert.DeserializeObject<List<int>>(TreeID).Where(p => p != 0).ToList();
            }
            int ProductID = WebUtil.GetIntValue(context, "ProductID");
            int CKCategoryID = WebUtil.GetIntValue(context, "CKCategoryID");
            string page = context.Request.Form["page"];
            string rows = context.Request.Form["rows"];
            long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
            int pageSize = int.Parse(rows);
            bool ShowTotalInventory = false;
            if (!string.IsNullOrEmpty(context.Request["ShowTotalInventory"]))
            {
                bool.TryParse(context.Request["ShowTotalInventory"], out ShowTotalInventory);
            }
            bool canexport = WebUtil.GetBoolValue(context, "canexport");
            DataGrid dg = ViewCKProductCategory.GetViewCKProductCategoryGridByKeywords(Keywords, CategoryIDList, ProductID, ShowTotalInventory, "order by AddTime desc", startRowIndex, pageSize, CKCategoryID, canexport: canexport);
            if (canexport)
            {
                string downloadurl = string.Empty;
                string error = string.Empty;
                bool status = APPCode.ExportHelper.DownLoadCKProductData(dg, out downloadurl, out error);
                WebUtil.WriteJson(context, new { status = status, downloadurl = downloadurl, error = error });
                return;
            }
            string result = JsonConvert.SerializeObject(dg);
            context.Response.Write(result);
        }
        private void saveproduct(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            Foresight.DataAccess.CKProduct product = null;
            if (ID > 0)
            {
                product = CKProduct.GetCKProduct(ID);
            }
            if (product == null)
            {
                product = new CKProduct();
                product.AddMan = context.Request.Params["AddMan"];
                product.AddTime = DateTime.Now;
            }
            string ProductNumber = context.Request["ProductNumber"];
            if (string.IsNullOrEmpty(ProductNumber))
            {
                WebUtil.WriteJson(context, new { status = false, error = "物品编号不能为空" });
                return;
            }
            var exist_product = CKProduct.GetCKProductByProductNumber(ProductNumber);
            if (exist_product != null && exist_product.ID != product.ID)
            {
                WebUtil.WriteJson(context, new { status = false, error = "物品编号已存在" });
                return;
            }
            product.ProductNumber = ProductNumber;
            product.ProductName = context.Request.Params["ProductName"];
            product.Unit = context.Request.Params["Unit"];
            product.CategoryID = WebUtil.GetIntValue(context, "CategoryID");
            product.ModelNumber = context.Request.Params["ModelNumber"];
            product.InventoryMin = WebUtil.GetIntValue(context, "InventoryMin");
            product.InventoryMax = WebUtil.GetIntValue(context, "InventoryMax");
            product.ProductUnitPrice = WebUtil.GetDecimalValue(context, "ProductUnitPrice");
            product.Save();
            WebUtil.WriteJson(context, new { status = true });
        }
        private void LoadTree(HttpContext context)
        {
            try
            {
                string Keywords = context.Request.Params["Keywords"];
                int UserID = WebUtil.GetUser(context).UserID;
                var categorylist = Foresight.DataAccess.CKCategory.GetCKCategoryListByKeywords(Keywords, UserID);
                bool ShowProduct = false;
                if (!string.IsNullOrEmpty(context.Request.Params["ShowProduct"]))
                {
                    bool.TryParse(context.Request.Params["ShowProduct"], out ShowProduct);
                }
                CKProductDetail[] productlist = null;
                if (ShowProduct)
                {
                    productlist = CKProductDetail.GetCKProductDetailList(Keywords);
                }
                TreeModule treeModule = null;
                var items = categorylist.Select(p =>
                {
                    treeModule = new TreeModule();
                    treeModule.id = "category_" + p.ID.ToString();
                    treeModule.ID = p.ID;
                    treeModule.pId = p.ParentID > 0 ? "category_" + p.ParentID.ToString() : "category_1";
                    treeModule.name = p.CategoryName;
                    bool hasChild = false;
                    if (p.CategoryType.Equals(EnumModel.CKCategoryType.category.ToString()) && ShowProduct)
                    {
                        hasChild = productlist.Any(o => o.CategoryID == p.ID);
                    }
                    else
                    {
                        hasChild = categorylist.Any(o => o.ParentID == p.ID);
                    }
                    treeModule.isParent = hasChild;
                    treeModule.open = hasChild;
                    treeModule.type = Utility.EnumModel.CKCategoryType.category.ToString();
                    return treeModule;
                }).ToList();
                treeModule = new TreeModule();
                treeModule.id = "category_1";
                treeModule.ID = 1;
                treeModule.pId = "0";
                treeModule.name = WebUtil.GetCompany(context).CompanyName;
                bool hasckChild = categorylist.Any(o => o.ParentID == 1);
                treeModule.isParent = hasckChild;
                treeModule.open = hasckChild;
                treeModule.type = EnumModel.CKCategoryType.company.ToString();
                items.Add(treeModule);
                if (ShowProduct)
                {
                    foreach (var product in productlist)
                    {
                        treeModule = new TreeModule();
                        treeModule.id = "product_" + product.ID.ToString();
                        treeModule.ID = product.ID;
                        treeModule.pId = product.CategoryID > 0 ? "category_" + product.CategoryID.ToString() : "category_1";
                        treeModule.name = product.ProductName;
                        treeModule.Unit = product.Unit;
                        treeModule.ModelNumber = product.ModelNumber;
                        treeModule.TotalInventory = product.TotalInventory;
                        treeModule.isParent = false;
                        treeModule.open = false;
                        treeModule.type = EnumModel.CKCategoryType.product.ToString();
                        items.Add(treeModule);
                    }
                }
                bool showdepartment = false;
                if (!string.IsNullOrEmpty(context.Request["showdepartment"]))
                {
                    bool.TryParse(context.Request["showdepartment"], out showdepartment);
                }
                if (showdepartment)
                {
                    var departmentlist = Foresight.DataAccess.CKDepartment.GetCKDepartmentListByKeywords(Keywords);
                    treeModule = new TreeModule();
                    treeModule.id = "department_0";
                    treeModule.ID = 0;
                    treeModule.pId = "category_1";
                    treeModule.name = "部门列表";
                    bool hasdepartmentChild = departmentlist.Length > 0;
                    treeModule.isParent = hasdepartmentChild;
                    treeModule.open = hasdepartmentChild;
                    treeModule.type = EnumModel.CKCategoryType.department.ToString();
                    items.Add(treeModule);
                    foreach (var item in departmentlist)
                    {
                        treeModule = new TreeModule();
                        treeModule.id = "department_" + item.ID;
                        treeModule.ID = item.ID;
                        treeModule.pId = "department_0";
                        treeModule.name = item.DepartmentName;
                        treeModule.isParent = false;
                        treeModule.open = false;
                        treeModule.type = EnumModel.CKCategoryType.department.ToString();
                        items.Add(treeModule);
                    }
                }
                WebUtil.WriteJson(context, items);
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("CKHandler.ashx", "visit: LoadTree", ex);
                context.Response.Write("[]");
            }
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
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
            public string Unit { get; set; }
            public string ModelNumber { get; set; }
            public decimal TotalInventory { get; set; }
        }
    }
}