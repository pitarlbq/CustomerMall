using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using Utility;
using Foresight.DataAccess.Framework;
using ExcelProcess;

namespace Web.Handler
{
    /// <summary>
    /// ImportHandler 的摘要说明
    /// </summary>
    public class ImportChequeHandler : IHttpHandler, IRequiresSessionState
    {

        const string LogModule = "ImportChequeHandler";
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
                    case "importinsummary":
                        importinsummary(context);
                        break;
                    case "importoutjz":
                        importoutjz(context);
                        break;
                    case "importchequestamp":
                        importchequestamp(context);
                        break;
                    case "importoutsummary":
                        importoutsummary(context);
                        break;
                    case "importchequecheck":
                        importchequecheck(context);
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
        private void importchequecheck(HttpContext context)
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
            #region 导入处理
            var titleList = Foresight.DataAccess.TableColumn.GetTableColumnByPageCode("chequecheckmgr", true).Where(p => !p.ColumnName.Equals("选择按钮")).ToArray();
            for (int j = 0; j < uploadFiles.Count; j++)
            {
                HttpPostedFile postedFile = uploadFiles[j];
                string filepath = HttpContext.Current.Server.MapPath("~/upload/cheque/" + DateTime.Now.ToString("yyyyMMdd"));
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
                    Foresight.DataAccess.Cheque_Confirm confirm = null;
                    Foresight.DataAccess.Cheque_InSummary insummary = null;
                    object Value;
                    if (GetColumnValue(titleList, "ID", table, i, out Value))
                    {
                        int ID = GetIntValue(Value);
                        if (ID > 0)
                        {
                            confirm = Foresight.DataAccess.Cheque_Confirm.GetCheque_Confirm(ID);
                        }
                    }
                    if (confirm == null)
                    {
                        if (GetColumnValue(titleList, "发票代码", table, i, out Value))
                        {
                            insummary = Foresight.DataAccess.Cheque_InSummary.GetCheque_InSummaryByChequeCode(Value.ToString());
                        }
                        if (insummary == null)
                        {
                            msg += "<p>第" + (i + 1) + "行进项发票不存在,导入失败</p>";
                            context.Response.Write(msg);
                            return;
                        }
                        confirm = new Foresight.DataAccess.Cheque_Confirm();
                        confirm.AddTime = DateTime.Now;
                        confirm.SummaryID = insummary.ID;
                    }
                    if (GetColumnValue(titleList, "财务接管日期", table, i, out Value))
                    {
                        if (!string.IsNullOrEmpty(Value.ToString()))
                        {
                            confirm.TakeTime = GetDateTimeValue(Value);
                            confirm.TakeStatus = 1;
                        }
                    }
                    if (GetColumnValue(titleList, "交接人", table, i, out Value))
                    {
                        if (!string.IsNullOrEmpty(Value.ToString()))
                        {
                            confirm.TakeUser = Value.ToString();
                            confirm.TakeStatus = 1;
                        }
                    }
                    if (GetColumnValue(titleList, "交接状态", table, i, out Value))
                    {
                        if (!string.IsNullOrEmpty(Value.ToString()))
                        {
                            confirm.TakeStatus = Value.ToString().Equals("已交接") ? 1 : 0;
                        }
                    }
                    if (GetColumnValue(titleList, "认证日期", table, i, out Value))
                    {
                        if (!string.IsNullOrEmpty(Value.ToString()))
                        {
                            confirm.ApproveTime = GetDateTimeValue(Value);
                            confirm.ApproveStatus = 1;
                        }
                    }
                    if (GetColumnValue(titleList, "认证结果", table, i, out Value))
                    {
                        if (!string.IsNullOrEmpty(Value.ToString()))
                        {
                            confirm.ApproveRemark = Value.ToString();
                            confirm.ApproveStatus = 1;
                        }
                    }
                    if (GetColumnValue(titleList, "认证月度", table, i, out Value))
                    {
                        if (!string.IsNullOrEmpty(Value.ToString()))
                        {
                            confirm.ApproveMonth = Value.ToString();
                            confirm.ApproveStatus = 1;
                        }
                    }
                    if (GetColumnValue(titleList, "认证方式", table, i, out Value))
                    {
                        if (!string.IsNullOrEmpty(Value.ToString()))
                        {
                            confirm.ApproveMethod = Value.ToString();
                            confirm.ApproveStatus = 1;
                        }
                    }
                    if (GetColumnValue(titleList, "认证状态", table, i, out Value))
                    {
                        if (!string.IsNullOrEmpty(Value.ToString()))
                        {
                            confirm.ApproveStatus = Value.ToString().Equals("已认证") ? 1 : 0;
                        }
                    }
                    if (GetColumnValue(titleList, "转出时间", table, i, out Value))
                    {
                        if (!string.IsNullOrEmpty(Value.ToString()))
                        {
                            confirm.TransferTime = GetDateTimeValue(Value);
                            confirm.TransferStatus = 1;
                        }
                    }
                    if (GetColumnValue(titleList, "转出人", table, i, out Value))
                    {
                        if (!string.IsNullOrEmpty(Value.ToString()))
                        {
                            confirm.TransferMan = Value.ToString();
                            confirm.TransferStatus = 1;
                        }
                    }
                    if (GetColumnValue(titleList, "转出状态", table, i, out Value))
                    {
                        if (!string.IsNullOrEmpty(Value.ToString()))
                        {
                            confirm.TransferStatus = Value.ToString().Equals("已转出") ? 1 : 0;
                        }
                    }
                    confirm.Save();
                }
            }
            #endregion
            msg += "<p>导入成功</p>";
            context.Response.Write(msg);
        }
        private void importoutsummary(HttpContext context)
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
            var departmentList = Foresight.DataAccess.Cheque_Department.GetCheque_Departments();
            var projectList = Foresight.DataAccess.Cheque_Project.GetCheque_Projects();
            var sellerList = Foresight.DataAccess.Cheque_Seller.GetCheque_Sellers();
            var productList = Foresight.DataAccess.Cheque_Product.GetCheque_Products();
            var buyerList = Foresight.DataAccess.Cheque_Buyer.GetCheque_Buyers();
            var departmentCategoryList = Foresight.DataAccess.Cheque_DepartmentCategory.GetCheque_DepartmentCategories();
            var projectCategoryList = Foresight.DataAccess.Cheque_ProjectCategory.GetCheque_ProjectCategories();
            var sellerCategoryList = Foresight.DataAccess.Cheque_SellerCategory.GetCheque_SellerCategories();
            var productCategoryList = Foresight.DataAccess.Cheque_ProductCategory.GetCheque_ProductCategories();
            var buyerCategoryList = Foresight.DataAccess.Cheque_BuyerCategory.GetCheque_BuyerCategories();
            #region 导入处理
            var titleList = Foresight.DataAccess.TableColumn.GetTableColumnByPageCode("chequeoutmgr", true).Where(p => !p.ColumnName.Equals("选择按钮")).ToArray();
            for (int j = 0; j < uploadFiles.Count; j++)
            {
                HttpPostedFile postedFile = uploadFiles[j];
                string filepath = HttpContext.Current.Server.MapPath("~/upload/cheque/" + DateTime.Now.ToString("yyyyMMdd"));
                if (!System.IO.Directory.Exists(filepath))
                {
                    System.IO.Directory.CreateDirectory(filepath);
                }
                string filename = DateTime.Now.ToLocalTime().ToString("yyyyMMddHHmmss") + "_" + postedFile.FileName;
                string fullpath = Path.Combine(filepath, filename);
                postedFile.SaveAs(fullpath);
                DataTable table = ExcelExportHelper.NPOIReadExcel(fullpath);
                Foresight.DataAccess.Cheque_OutSummary presummary = null;
                bool isSame = false;
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    Foresight.DataAccess.Cheque_OutSummary summary = null;
                    Foresight.DataAccess.Cheque_Department department = null;
                    Foresight.DataAccess.Cheque_Project project = null;
                    Foresight.DataAccess.Cheque_Seller seller = null;
                    Foresight.DataAccess.Cheque_Product product = null;
                    Foresight.DataAccess.Cheque_Buyer buyer = null;
                    Foresight.DataAccess.Cheque_DepartmentCategory departmentCategory = null;
                    Foresight.DataAccess.Cheque_ProjectCategory projectCategory = null;
                    Foresight.DataAccess.Cheque_SellerCategory sellerCategory = null;
                    Foresight.DataAccess.Cheque_ProductCategory productCategory = null;
                    Foresight.DataAccess.Cheque_BuyerCategory buyerCategory = null;
                    Foresight.DataAccess.Cheque_OutDetail detail = null;

                    object Value;
                    if (GetColumnValue(titleList, "ID", table, i, out Value))
                    {
                        int ID = GetIntValue(Value);
                        if (ID > 0)
                        {
                            summary = Foresight.DataAccess.Cheque_OutSummary.GetCheque_OutSummary(GetIntValue(Value));
                        }
                    }
                    if (string.IsNullOrEmpty(Value.ToString()) && presummary != null)
                    {
                        summary = presummary;
                        isSame = true;
                    }
                    else
                    {
                        isSame = false;
                        if (summary == null)
                        {
                            summary = new Foresight.DataAccess.Cheque_OutSummary();
                            summary.AddTime = DateTime.Now;
                        }
                        if (GetColumnValue(titleList, "登记日期", table, i, out Value))
                        {
                            DateTime WriteDate = GetDateTimeValue(Value);
                            summary.WriteDate = WriteDate > DateTime.MinValue ? WriteDate : DateTime.Now;
                        }
                        if (GetColumnValue(titleList, "部门档案", table, i, out Value))
                        {
                            summary.DepartmentFile = Value.ToString();
                        }
                        if (GetColumnValue(titleList, "签收人员", table, i, out Value))
                        {
                            if (!string.IsNullOrEmpty(Value.ToString()))
                            {
                                summary.SignOperator = Value.ToString();
                                summary.SignState = 1;
                            }
                        }
                        if (GetColumnValue(titleList, "签收日期", table, i, out Value))
                        {
                            DateTime SignTime = GetDateTimeValue(Value);
                            if (SignTime > DateTime.MinValue)
                            {
                                summary.SignTime = SignTime;
                                summary.SignState = 1;
                            }
                        }
                        if (GetColumnValue(titleList, "审核人员", table, i, out Value))
                        {
                            if (!string.IsNullOrEmpty(Value.ToString()))
                            {
                                summary.ApproveOperator = Value.ToString();
                                summary.ApproveState = 1;
                            }
                        }
                        if (GetColumnValue(titleList, "审核日期", table, i, out Value))
                        {
                            DateTime ApporveTime = GetDateTimeValue(Value);
                            if (ApporveTime > DateTime.MinValue)
                            {
                                summary.ApporveTime = ApporveTime;
                                summary.ApproveState = 1;
                            }
                        }
                        if (GetColumnValue(titleList, "登记人员", table, i, out Value))
                        {
                            string WriteMan = string.IsNullOrEmpty(Value.ToString()) ? WebUtil.GetUser(context).RealName : Value.ToString();
                            summary.WriteMan = WriteMan;
                        }
                        if (GetColumnValue(titleList, "发票编号", table, i, out Value))
                        {
                            summary.ChequeNumber = Value.ToString();
                        }
                        if (GetColumnValue(titleList, "发票代码", table, i, out Value))
                        {
                            summary.ChequeCode = Value.ToString();
                        }
                        if (GetColumnValue(titleList, "开票日期", table, i, out Value))
                        {
                            DateTime ChequeTime = GetDateTimeValue(Value);
                            if (ChequeTime > DateTime.MinValue)
                            {
                                summary.ChequeTime = ChequeTime;
                            }
                        }
                        #region 销售单位分类 项目分类 部门分类 购货单位分类
                        if (GetColumnValue(titleList, "销售单位分类", table, i, out Value))
                        {
                            if (!string.IsNullOrEmpty(Value.ToString()))
                            {
                                sellerCategory = sellerCategoryList.FirstOrDefault(p => p.SellerCategoryName.Equals(Value.ToString()));
                                if (sellerCategory == null)
                                {
                                    sellerCategory = new Foresight.DataAccess.Cheque_SellerCategory();
                                    sellerCategory.SellerCategoryName = Value.ToString();
                                }
                            }
                        }
                        if (GetColumnValue(titleList, "项目分类", table, i, out Value))
                        {
                            if (!string.IsNullOrEmpty(Value.ToString()))
                            {
                                projectCategory = projectCategoryList.FirstOrDefault(p => p.ProjectCategoryName.Equals(Value.ToString()));
                                if (projectCategory == null)
                                {
                                    projectCategory = new Foresight.DataAccess.Cheque_ProjectCategory();
                                    projectCategory.ProjectCategoryName = Value.ToString();
                                }
                            }
                        }
                        if (GetColumnValue(titleList, "部门分类", table, i, out Value))
                        {
                            if (!string.IsNullOrEmpty(Value.ToString()))
                            {
                                departmentCategory = departmentCategoryList.FirstOrDefault(p => p.DepartmentCategoryName.Equals(Value.ToString()));
                                if (departmentCategory == null)
                                {
                                    departmentCategory = new Foresight.DataAccess.Cheque_DepartmentCategory();
                                    departmentCategory.DepartmentCategoryName = Value.ToString();
                                }
                            }
                        }
                        if (GetColumnValue(titleList, "购货单位分类", table, i, out Value))
                        {
                            if (!string.IsNullOrEmpty(Value.ToString()))
                            {
                                buyerCategory = buyerCategoryList.FirstOrDefault(p => p.BuyerCategoryName.Equals(Value.ToString()));
                                if (buyerCategory == null)
                                {
                                    buyerCategory = new Foresight.DataAccess.Cheque_BuyerCategory();
                                    buyerCategory.BuyerCategoryName = Value.ToString();
                                }
                            }
                        }
                        #endregion
                        #region 直管部门 项目 销售单位 购货单位
                        if (GetColumnValue(titleList, "所属直管部门", table, i, out Value))
                        {
                            if (summary.DepartmentID > 0)
                            {
                                department = departmentList.FirstOrDefault(p => p.ID == summary.DepartmentID);
                                if (department == null)
                                {
                                    department = new Foresight.DataAccess.Cheque_Department();
                                    department.AddTime = DateTime.Now;
                                }
                                department.DepartmentName = Value.ToString();
                            }
                            else if (!string.IsNullOrEmpty(Value.ToString()))
                            {
                                department = departmentList.FirstOrDefault(p => p.DepartmentName.Equals(Value.ToString()));
                                if (department == null)
                                {
                                    department = new Foresight.DataAccess.Cheque_Department();
                                    department.AddTime = DateTime.Now;
                                    department.DepartmentName = Value.ToString();
                                }
                            }
                        }
                        if (GetColumnValue(titleList, "项目名称", table, i, out Value))
                        {
                            if (summary.ProjectID > 0)
                            {
                                project = projectList.FirstOrDefault(p => p.ID == summary.ProjectID);
                                if (project == null)
                                {
                                    project = new Foresight.DataAccess.Cheque_Project();
                                    project.AddTime = DateTime.Now;
                                }
                                project.ProjectName = Value.ToString();
                            }
                            else if (!string.IsNullOrEmpty(Value.ToString()))
                            {
                                project = projectList.FirstOrDefault(p => p.ProjectName.Equals(Value.ToString()));
                                if (project == null)
                                {
                                    project = new Foresight.DataAccess.Cheque_Project();
                                    project.AddTime = DateTime.Now;
                                    project.ProjectName = Value.ToString();
                                }
                            }
                        }
                        if (GetColumnValue(titleList, "销售单位名称", table, i, out Value))
                        {
                            if (summary.SellerID > 0)
                            {
                                seller = sellerList.FirstOrDefault(p => p.ID == summary.SellerID);
                                if (seller == null)
                                {
                                    seller = new Foresight.DataAccess.Cheque_Seller();
                                    seller.AddTime = DateTime.Now;
                                }
                                seller.SellerName = Value.ToString();
                            }
                            else if (!string.IsNullOrEmpty(Value.ToString()))
                            {
                                seller = sellerList.FirstOrDefault(p => p.SellerName.Equals(Value.ToString()));
                                if (seller == null)
                                {
                                    seller = new Foresight.DataAccess.Cheque_Seller();
                                    seller.AddTime = DateTime.Now;
                                    seller.SellerName = Value.ToString();
                                }
                            }
                        }
                        if (GetColumnValue(titleList, "销售纳税人识别号", table, i, out Value))
                        {
                            if (seller != null)
                            {
                                seller.SellerTaxNumber = Value.ToString();
                            }
                        }
                        if (GetColumnValue(titleList, "销售地址电话", table, i, out Value))
                        {
                            if (seller != null)
                            {
                                seller.SellerAddressPhone = Value.ToString();
                            }
                        }
                        if (GetColumnValue(titleList, "销售开户行及帐号", table, i, out Value))
                        {
                            if (seller != null)
                            {
                                seller.SellerBankAccount = Value.ToString();
                            }
                        }
                        if (GetColumnValue(titleList, "购货单位名称", table, i, out Value))
                        {
                            if (summary.BuyerID > 0)
                            {
                                buyer = buyerList.FirstOrDefault(p => p.ID == summary.BuyerID);
                                if (buyer == null)
                                {
                                    buyer = new Foresight.DataAccess.Cheque_Buyer();
                                    buyer.AddTime = DateTime.Now;
                                }
                                buyer.BuyerName = Value.ToString();
                            }
                            else if (!string.IsNullOrEmpty(Value.ToString()))
                            {
                                buyer = buyerList.FirstOrDefault(p => p.BuyerName.Equals(Value.ToString()));
                                if (buyer == null)
                                {
                                    buyer = new Foresight.DataAccess.Cheque_Buyer();
                                    buyer.AddTime = DateTime.Now;
                                    buyer.BuyerName = Value.ToString();
                                }
                            }
                        }
                        if (GetColumnValue(titleList, "购货纳税人识别号", table, i, out Value))
                        {
                            if (buyer != null)
                            {
                                buyer.BuyerTaxNumber = Value.ToString();
                            }
                        }
                        if (GetColumnValue(titleList, "购货地址电话", table, i, out Value))
                        {
                            if (buyer != null)
                            {
                                buyer.BuyerAddressPhone = Value.ToString();
                            }
                        }
                        if (GetColumnValue(titleList, "购货开户行及帐号", table, i, out Value))
                        {
                            if (buyer != null)
                            {
                                buyer.BuyerBankAccount = Value.ToString();
                            }
                        }
                        #endregion
                    }
                    #region 货物 货物分类
                    if (GetColumnValue(titleList, "货物或应税劳务名称", table, i, out Value))
                    {
                        if (!string.IsNullOrEmpty(Value.ToString()))
                        {
                            product = productList.FirstOrDefault(p => p.ProductName.Equals(Value.ToString()));
                            if (product == null)
                            {
                                product = new Foresight.DataAccess.Cheque_Product();
                                product.AddTime = DateTime.Now;
                                product.ProductName = Value.ToString();
                            }
                            if (summary.ID > 0 && product.ID > 0)
                            {
                                detail = Foresight.DataAccess.Cheque_OutDetail.GetCheque_OutDetail(summary.ID, product.ID);
                            }
                            if (detail == null)
                            {
                                detail = new Foresight.DataAccess.Cheque_OutDetail();
                            }
                            detail.ProductName = Value.ToString();
                        }
                    }
                    if (GetColumnValue(titleList, "规格型号", table, i, out Value))
                    {
                        if (product != null)
                        {
                            product.ModelNumber = Value.ToString();
                        }
                        if (detail != null)
                        {
                            detail.ModelNumber = Value.ToString();
                        }
                    }
                    if (GetColumnValue(titleList, "单位", table, i, out Value))
                    {
                        if (product != null)
                        {
                            product.Unit = Value.ToString();
                        }
                        if (detail != null)
                        {
                            detail.Unit = Value.ToString();
                        }
                    }
                    if (GetColumnValue(titleList, "单价", table, i, out Value))
                    {
                        if (product != null)
                        {
                            product.UnitPrice = GetDecimalValue(Value);
                        }
                        if (detail != null)
                        {
                            detail.UnitPrice = GetDecimalValue(Value);
                        }
                    }
                    if (GetColumnValue(titleList, "数量", table, i, out Value))
                    {
                        if (detail != null)
                        {
                            detail.TotalCount = GetIntValue(Value);
                        }
                    }
                    if (GetColumnValue(titleList, "税率", table, i, out Value))
                    {
                        if (detail != null)
                        {
                            detail.TaxRate = GetDecimalValue(Value).ToString();
                        }
                    }
                    if (detail != null)
                    {
                        detail.TotalCost = detail.UnitPrice * detail.TotalCount;
                        detail.TotalTaxCost = Math.Round((detail.TotalCost * Convert.ToInt32(detail.TaxRate) / 100), 2);
                        detail.TotalSummaryCost = detail.TotalCost + detail.TotalTaxCost;
                    }
                    if (GetColumnValue(titleList, "货物分类", table, i, out Value))
                    {
                        if (!string.IsNullOrEmpty(Value.ToString()))
                        {
                            productCategory = productCategoryList.FirstOrDefault(p => p.ProductCategoryName.Equals(Value.ToString()));
                            if (productCategory == null)
                            {
                                productCategory = new Foresight.DataAccess.Cheque_ProductCategory();
                                productCategory.ProductCategoryName = Value.ToString();
                            }
                        }
                    }
                    #endregion
                    if (!isSame)
                    {
                        if (departmentCategory != null)
                        {
                            departmentCategory.Save();
                        }
                        if (department != null)
                        {
                            if (departmentCategory != null)
                            {
                                department.DepartmentCategoryID = departmentCategory.ID;
                            }
                            department.Save();
                            summary.DepartmentID = department.ID;
                        }
                        if (projectCategory != null)
                        {
                            projectCategory.Save();
                        }
                        if (project != null)
                        {
                            if (projectCategory != null)
                            {
                                project.ProjectCategoryID = projectCategory.ID;
                            }
                            project.Save();
                            summary.ProjectID = project.ID;
                        }
                        if (sellerCategory != null)
                        {
                            sellerCategory.Save();
                        }
                        if (seller != null)
                        {
                            if (sellerCategory != null)
                            {
                                seller.SellerCategoryID = sellerCategory.ID;
                            }
                            seller.Save();
                            summary.SellerID = seller.ID;
                        }
                        if (buyerCategory != null)
                        {
                            buyerCategory.Save();
                        }
                        if (buyer != null)
                        {
                            if (buyerCategory != null)
                            {
                                buyer.BuyerCategoryID = buyerCategory.ID;
                            }
                            buyer.Save();
                            summary.BuyerID = buyer.ID;
                        }
                    }
                    summary.Save();
                    if (productCategory != null)
                    {
                        productCategory.Save();
                    }
                    if (product != null)
                    {
                        if (productCategory != null)
                        {
                            product.ProductCategoryID = productCategory.ID;
                        }
                        product.Save();
                        if (detail != null)
                        {
                            detail.ProductID = product.ID;
                            detail.OutSummaryID = summary.ID;
                            detail.Save();
                        }
                    }
                    presummary = summary;
                }
            }
            #endregion
            msg += "<p>导入成功</p>";
            context.Response.Write(msg);
        }
        private void importchequestamp(HttpContext context)
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
            var departmentList = Foresight.DataAccess.Cheque_Department.GetCheque_Departments();
            var contractCategoryList = Foresight.DataAccess.Cheque_ContractCategory.GetCheque_ContractCategories();
            var taxrateList = Foresight.DataAccess.Cheque_TaxRate.GetCheque_TaxRates();
            #region 导入处理
            var titleList = Foresight.DataAccess.TableColumn.GetTableColumnByPageCode("chequestampmgr", true).Where(p => !p.ColumnName.Equals("选择按钮")).ToArray();
            for (int j = 0; j < uploadFiles.Count; j++)
            {
                HttpPostedFile postedFile = uploadFiles[j];
                string filepath = HttpContext.Current.Server.MapPath("~/upload/cheque/" + DateTime.Now.ToString("yyyyMMdd"));
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
                    Foresight.DataAccess.Cheque_Tax tax = null;
                    Foresight.DataAccess.Cheque_Department department = null;
                    Foresight.DataAccess.Cheque_ContractCategory contractCategory = null;
                    Foresight.DataAccess.Cheque_TaxRate chequetaxrate = null;
                    object Value;
                    if (GetColumnValue(titleList, "ID", table, i, out Value))
                    {
                        int ID = GetIntValue(Value);
                        if (ID > 0)
                        {
                            tax = Foresight.DataAccess.Cheque_Tax.GetCheque_Tax(ID);
                        }
                    }
                    if (tax == null)
                    {
                        tax = new Foresight.DataAccess.Cheque_Tax();
                        tax.AddTime = DateTime.Now;
                        tax.AddMan = WebUtil.GetUser(context).RealName;
                    }
                    if (GetColumnValue(titleList, "合同编号", table, i, out Value))
                    {
                        tax.ContractNumber = Value.ToString();
                    }
                    if (GetColumnValue(titleList, "合同名称", table, i, out Value))
                    {
                        tax.ContractName = Value.ToString();
                    }
                    if (GetColumnValue(titleList, "单价", table, i, out Value))
                    {
                        tax.UnitPrice = GetDecimalValue(Value);
                    }
                    if (GetColumnValue(titleList, "数量", table, i, out Value))
                    {
                        tax.TotalCount = GetIntValue(Value);
                    }
                    if (GetColumnValue(titleList, "金额", table, i, out Value))
                    {
                        decimal TotalCost = GetDecimalValue(Value);
                        if (TotalCost > 0)
                        {
                            tax.TotalCost = TotalCost;
                        }
                        else
                        {
                            tax.TotalCost = (tax.UnitPrice > 0 ? tax.UnitPrice : 0) * (tax.TotalCount > 0 ? tax.TotalCount : 0);
                        }
                    }
                    #region  印花税税率
                    if (GetColumnValue(titleList, "印花税税目税率表", table, i, out Value))
                    {
                        if (tax.TaxRateID > 0)
                        {
                            chequetaxrate = taxrateList.FirstOrDefault(p => p.ID == tax.TaxRateID);
                            if (chequetaxrate == null)
                            {
                                chequetaxrate = new Foresight.DataAccess.Cheque_TaxRate();
                                chequetaxrate.AddTime = DateTime.Now;
                            }
                            chequetaxrate.TaxRateName = Value.ToString();
                        }
                        else if (!string.IsNullOrEmpty(Value.ToString()))
                        {
                            chequetaxrate = taxrateList.FirstOrDefault(p => p.TaxRateName.Equals(Value.ToString()));
                            if (chequetaxrate == null)
                            {
                                chequetaxrate = new Foresight.DataAccess.Cheque_TaxRate();
                                chequetaxrate.AddTime = DateTime.Now;
                                chequetaxrate.TaxRateName = Value.ToString();
                            }
                        }
                    }
                    if (GetColumnValue(titleList, "税额", table, i, out Value))
                    {
                        decimal TotalTaxCost = GetDecimalValue(Value);
                        if (TotalTaxCost > 0)
                        {
                            tax.TotalTaxCost = TotalTaxCost;
                        }
                        else
                        {
                            if (chequetaxrate != null)
                            {
                                decimal taxratevalue = 0;
                                decimal.TryParse(chequetaxrate.TaxRateValue, out taxratevalue);
                                decimal TotalCost = tax.TotalCost > 0 ? tax.TotalCost : 0;
                                tax.TotalTaxCost = Math.Round((TotalCost * taxratevalue / 100), 2);
                            }
                        }
                    }
                    #endregion
                    #region  部门
                    if (GetColumnValue(titleList, "部门名称", table, i, out Value))
                    {
                        if (tax.DepartmentID > 0)
                        {
                            department = departmentList.FirstOrDefault(p => p.ID == tax.DepartmentID);
                            if (department == null)
                            {
                                department = new Foresight.DataAccess.Cheque_Department();
                                department.AddTime = DateTime.Now;
                            }
                            department.DepartmentName = Value.ToString();
                        }
                        else if (!string.IsNullOrEmpty(Value.ToString()))
                        {
                            department = departmentList.FirstOrDefault(p => p.DepartmentName.Equals(Value.ToString()));
                            if (department == null)
                            {
                                department = new Foresight.DataAccess.Cheque_Department();
                                department.AddTime = DateTime.Now;
                                department.DepartmentName = Value.ToString();
                            }
                        }
                    }
                    #endregion
                    #region  合同分类
                    if (GetColumnValue(titleList, "合同分类", table, i, out Value))
                    {
                        if (tax.ContractCategoryID > 0)
                        {
                            contractCategory = contractCategoryList.FirstOrDefault(p => p.ID == tax.ContractCategoryID);
                            if (contractCategory == null)
                            {
                                contractCategory = new Foresight.DataAccess.Cheque_ContractCategory();
                            }
                            contractCategory.ContractCategoryName = Value.ToString();
                        }
                        else if (!string.IsNullOrEmpty(Value.ToString()))
                        {
                            contractCategory = contractCategoryList.FirstOrDefault(p => p.ContractCategoryName.Equals(Value.ToString()));
                            if (contractCategory == null)
                            {
                                contractCategory = new Foresight.DataAccess.Cheque_ContractCategory();
                                contractCategory.ContractCategoryName = Value.ToString();
                            }
                        }
                    }
                    #endregion
                    if (chequetaxrate != null)
                    {
                        chequetaxrate.Save();
                        tax.TaxRateID = chequetaxrate.ID;
                    }
                    if (department != null)
                    {
                        department.Save();
                        tax.DepartmentID = department.ID;
                    }
                    if (contractCategory != null)
                    {
                        contractCategory.Save();
                        tax.ContractCategoryID = contractCategory.ID;
                    }
                    tax.Save();
                }
            }
            #endregion
            msg += "<p>导入成功</p>";
            context.Response.Write(msg);
        }
        private void importoutjz(HttpContext context)
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
            var projectList = Foresight.DataAccess.Cheque_Project.GetCheque_Projects();
            var departmentList = Foresight.DataAccess.Cheque_Department.GetCheque_Departments();
            #region 导入处理
            var titleList = Foresight.DataAccess.TableColumn.GetTableColumnByPageCode("chequeoutjz", true).Where(p => !p.ColumnName.Equals("选择按钮")).ToArray();
            for (int j = 0; j < uploadFiles.Count; j++)
            {
                HttpPostedFile postedFile = uploadFiles[j];
                string filepath = HttpContext.Current.Server.MapPath("~/upload/cheque/" + DateTime.Now.ToString("yyyyMMdd"));
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
                    Foresight.DataAccess.Cheque_Outing outing = null;
                    Foresight.DataAccess.Cheque_Project project = null;
                    Foresight.DataAccess.Cheque_Department department = null;
                    object Value;
                    if (GetColumnValue(titleList, "ID", table, i, out Value))
                    {
                        int ID = GetIntValue(Value);
                        if (ID > 0)
                        {
                            outing = Foresight.DataAccess.Cheque_Outing.GetCheque_Outing(GetIntValue(Value));
                        }
                    }
                    if (outing == null)
                    {
                        outing = new Foresight.DataAccess.Cheque_Outing();
                        outing.AddTime = DateTime.Now;
                    }
                    if (GetColumnValue(titleList, "生效日期", table, i, out Value))
                    {
                        outing.StartTime = GetDateTimeValue(Value);
                    }
                    if (GetColumnValue(titleList, "失效日期", table, i, out Value))
                    {
                        outing.EndTime = GetDateTimeValue(Value);
                    }
                    if (GetColumnValue(titleList, "提醒日期", table, i, out Value))
                    {
                        outing.NotifyTime = GetDateTimeValue(Value);
                    }
                    if (GetColumnValue(titleList, "经办人", table, i, out Value))
                    {
                        outing.Operator = Value.ToString();
                    }
                    if (GetColumnValue(titleList, "办理日期", table, i, out Value))
                    {
                        outing.OperationTime = GetDateTimeValue(Value);
                    }
                    if (GetColumnValue(titleList, "证件状态", table, i, out Value))
                    {
                        outing.IDCardStatus = Value.ToString();
                    }
                    if (GetColumnValue(titleList, "所属分公司", table, i, out Value))
                    {
                        outing.BelongCompanyName = Value.ToString();
                    }
                    if (GetColumnValue(titleList, "文书号", table, i, out Value))
                    {
                        outing.PaperNumber = Value.ToString();
                    }
                    if (GetColumnValue(titleList, "外出经营地", table, i, out Value))
                    {
                        outing.OutingAddress = Value.ToString();
                    }
                    if (GetColumnValue(titleList, "审核人", table, i, out Value))
                    {
                        outing.ApproveMan = Value.ToString();
                    }
                    if (GetColumnValue(titleList, "备注", table, i, out Value))
                    {
                        outing.Remark = Value.ToString();
                    }
                    #region  项目 部门
                    if (GetColumnValue(titleList, "项目名称", table, i, out Value))
                    {
                        if (outing.ProjectID > 0)
                        {
                            project = projectList.FirstOrDefault(p => p.ID == outing.ProjectID);
                            if (project == null)
                            {
                                project = new Foresight.DataAccess.Cheque_Project();
                                project.AddTime = DateTime.Now;
                            }
                            project.ProjectName = Value.ToString();
                        }
                        else if (!string.IsNullOrEmpty(Value.ToString()))
                        {
                            project = projectList.FirstOrDefault(p => p.ProjectName.Equals(Value.ToString()));
                            if (project == null)
                            {
                                project = new Foresight.DataAccess.Cheque_Project();
                                project.AddTime = DateTime.Now;
                                project.ProjectName = Value.ToString();
                            }
                        }
                    }
                    if (GetColumnValue(titleList, "直管部门", table, i, out Value))
                    {
                        if (outing.DepartmentID > 0)
                        {
                            department = departmentList.FirstOrDefault(p => p.ID == outing.DepartmentID);
                            if (department == null)
                            {
                                department = new Foresight.DataAccess.Cheque_Department();
                                department.AddTime = DateTime.Now;
                            }
                            department.DepartmentName = Value.ToString();
                        }
                        else if (!string.IsNullOrEmpty(Value.ToString()))
                        {
                            department = departmentList.FirstOrDefault(p => p.DepartmentName.Equals(Value.ToString()));
                            if (department == null)
                            {
                                department = new Foresight.DataAccess.Cheque_Department();
                                project.AddTime = DateTime.Now;
                                department.DepartmentName = Value.ToString();
                            }
                        }
                    }
                    #endregion

                    if (project != null)
                    {
                        project.Save();
                        outing.ProjectID = project.ID;
                    }
                    if (department != null)
                    {
                        department.Save();
                        outing.DepartmentID = department.ID;
                    }
                    outing.Save();
                }
            }
            #endregion
            msg += "<p>导入成功</p>";
            context.Response.Write(msg);
        }
        private void importinsummary(HttpContext context)
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
            var departmentList = Foresight.DataAccess.Cheque_Department.GetCheque_Departments();
            var projectList = Foresight.DataAccess.Cheque_Project.GetCheque_Projects();
            var sellerList = Foresight.DataAccess.Cheque_Seller.GetCheque_Sellers();
            var productList = Foresight.DataAccess.Cheque_Product.GetCheque_Products();
            var buyerList = Foresight.DataAccess.Cheque_Buyer.GetCheque_Buyers();
            var departmentCategoryList = Foresight.DataAccess.Cheque_DepartmentCategory.GetCheque_DepartmentCategories();
            var projectCategoryList = Foresight.DataAccess.Cheque_ProjectCategory.GetCheque_ProjectCategories();
            var sellerCategoryList = Foresight.DataAccess.Cheque_SellerCategory.GetCheque_SellerCategories();
            var productCategoryList = Foresight.DataAccess.Cheque_ProductCategory.GetCheque_ProductCategories();
            var buyerCategoryList = Foresight.DataAccess.Cheque_BuyerCategory.GetCheque_BuyerCategories();
            #region 导入处理
            var titleList = Foresight.DataAccess.TableColumn.GetTableColumnByPageCode("chequeinmgr", true).Where(p => !p.ColumnName.Equals("选择按钮")).ToArray();
            for (int j = 0; j < uploadFiles.Count; j++)
            {
                HttpPostedFile postedFile = uploadFiles[j];
                string filepath = HttpContext.Current.Server.MapPath("~/upload/cheque/" + DateTime.Now.ToString("yyyyMMdd"));
                if (!System.IO.Directory.Exists(filepath))
                {
                    System.IO.Directory.CreateDirectory(filepath);
                }
                string filename = DateTime.Now.ToLocalTime().ToString("yyyyMMddHHmmss") + "_" + postedFile.FileName;
                string fullpath = Path.Combine(filepath, filename);
                postedFile.SaveAs(fullpath);
                DataTable table = ExcelExportHelper.NPOIReadExcel(fullpath);
                Foresight.DataAccess.Cheque_InSummary presummary = null;
                bool isSame = false;
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    Foresight.DataAccess.Cheque_InSummary summary = null;
                    Foresight.DataAccess.Cheque_Department department = null;
                    Foresight.DataAccess.Cheque_Project project = null;
                    Foresight.DataAccess.Cheque_Seller seller = null;
                    Foresight.DataAccess.Cheque_Product product = null;
                    Foresight.DataAccess.Cheque_Buyer buyer = null;
                    Foresight.DataAccess.Cheque_DepartmentCategory departmentCategory = null;
                    Foresight.DataAccess.Cheque_ProjectCategory projectCategory = null;
                    Foresight.DataAccess.Cheque_SellerCategory sellerCategory = null;
                    Foresight.DataAccess.Cheque_ProductCategory productCategory = null;
                    Foresight.DataAccess.Cheque_BuyerCategory buyerCategory = null;
                    Foresight.DataAccess.Cheque_InDetail detail = null;

                    object Value;
                    if (GetColumnValue(titleList, "ID", table, i, out Value))
                    {
                        int ID = GetIntValue(Value);
                        if (ID > 0)
                        {
                            summary = Foresight.DataAccess.Cheque_InSummary.GetCheque_InSummary(GetIntValue(Value));
                        }
                    }
                    if (string.IsNullOrEmpty(Value.ToString()) && presummary != null)
                    {
                        summary = presummary;
                        isSame = true;
                    }
                    else
                    {
                        isSame = false;
                        if (summary == null)
                        {
                            summary = new Foresight.DataAccess.Cheque_InSummary();
                            summary.AddTime = DateTime.Now;
                        }
                        if (GetColumnValue(titleList, "登记日期", table, i, out Value))
                        {
                            DateTime WriteDate = GetDateTimeValue(Value);
                            summary.WriteDate = WriteDate > DateTime.MinValue ? WriteDate : DateTime.Now;
                        }
                        if (GetColumnValue(titleList, "部门档案", table, i, out Value))
                        {
                            summary.DepartmentFile = Value.ToString();
                        }
                        if (GetColumnValue(titleList, "签收人员", table, i, out Value))
                        {
                            if (!string.IsNullOrEmpty(Value.ToString()))
                            {
                                summary.SignOperator = Value.ToString();
                                summary.SignState = 1;
                            }
                        }
                        if (GetColumnValue(titleList, "签收日期", table, i, out Value))
                        {
                            DateTime SignTime = GetDateTimeValue(Value);
                            if (SignTime > DateTime.MinValue)
                            {
                                summary.SignTime = SignTime;
                                summary.SignState = 1;
                            }
                        }
                        if (GetColumnValue(titleList, "审核人员", table, i, out Value))
                        {
                            if (!string.IsNullOrEmpty(Value.ToString()))
                            {
                                summary.ApproveOperator = Value.ToString();
                                summary.ApproveState = 1;
                            }
                        }
                        if (GetColumnValue(titleList, "审核日期", table, i, out Value))
                        {
                            DateTime ApporveTime = GetDateTimeValue(Value);
                            if (ApporveTime > DateTime.MinValue)
                            {
                                summary.ApporveTime = ApporveTime;
                                summary.ApproveState = 1;
                            }
                        }
                        if (GetColumnValue(titleList, "登记人员", table, i, out Value))
                        {
                            string WriteMan = string.IsNullOrEmpty(Value.ToString()) ? WebUtil.GetUser(context).RealName : Value.ToString();
                            summary.WriteMan = WriteMan;
                        }
                        if (GetColumnValue(titleList, "发票编号", table, i, out Value))
                        {
                            summary.ChequeNumber = Value.ToString();
                        }
                        if (GetColumnValue(titleList, "发票代码", table, i, out Value))
                        {
                            summary.ChequeCode = Value.ToString();
                        }
                        if (GetColumnValue(titleList, "开票日期", table, i, out Value))
                        {
                            DateTime ChequeTime = GetDateTimeValue(Value);
                            if (ChequeTime > DateTime.MinValue)
                            {
                                summary.ChequeTime = ChequeTime;
                            }
                        }
                        #region 销售单位分类 项目分类 部门分类 购货单位分类
                        if (GetColumnValue(titleList, "销售单位分类", table, i, out Value))
                        {
                            if (!string.IsNullOrEmpty(Value.ToString()))
                            {
                                sellerCategory = sellerCategoryList.FirstOrDefault(p => p.SellerCategoryName.Equals(Value.ToString()));
                                if (sellerCategory == null)
                                {
                                    sellerCategory = new Foresight.DataAccess.Cheque_SellerCategory();
                                    sellerCategory.SellerCategoryName = Value.ToString();
                                }
                            }
                        }
                        if (GetColumnValue(titleList, "项目分类", table, i, out Value))
                        {
                            if (!string.IsNullOrEmpty(Value.ToString()))
                            {
                                projectCategory = projectCategoryList.FirstOrDefault(p => p.ProjectCategoryName.Equals(Value.ToString()));
                                if (projectCategory == null)
                                {
                                    projectCategory = new Foresight.DataAccess.Cheque_ProjectCategory();
                                    projectCategory.ProjectCategoryName = Value.ToString();
                                }
                            }
                        }
                        if (GetColumnValue(titleList, "部门分类", table, i, out Value))
                        {
                            if (!string.IsNullOrEmpty(Value.ToString()))
                            {
                                departmentCategory = departmentCategoryList.FirstOrDefault(p => p.DepartmentCategoryName.Equals(Value.ToString()));
                                if (departmentCategory == null)
                                {
                                    departmentCategory = new Foresight.DataAccess.Cheque_DepartmentCategory();
                                    departmentCategory.DepartmentCategoryName = Value.ToString();
                                }
                            }
                        }
                        if (GetColumnValue(titleList, "购货单位分类", table, i, out Value))
                        {
                            if (!string.IsNullOrEmpty(Value.ToString()))
                            {
                                buyerCategory = buyerCategoryList.FirstOrDefault(p => p.BuyerCategoryName.Equals(Value.ToString()));
                                if (buyerCategory == null)
                                {
                                    buyerCategory = new Foresight.DataAccess.Cheque_BuyerCategory();
                                    buyerCategory.BuyerCategoryName = Value.ToString();
                                }
                            }
                        }
                        #endregion
                        #region 直管部门 项目 销售单位 购货单位
                        if (GetColumnValue(titleList, "所属直管部门", table, i, out Value))
                        {
                            if (summary.DepartmentID > 0)
                            {
                                department = departmentList.FirstOrDefault(p => p.ID == summary.DepartmentID);
                                if (department == null)
                                {
                                    department = new Foresight.DataAccess.Cheque_Department();
                                    department.AddTime = DateTime.Now;
                                }
                                department.DepartmentName = Value.ToString();
                            }
                            else if (!string.IsNullOrEmpty(Value.ToString()))
                            {
                                department = departmentList.FirstOrDefault(p => p.DepartmentName.Equals(Value.ToString()));
                                if (department == null)
                                {
                                    department = new Foresight.DataAccess.Cheque_Department();
                                    department.AddTime = DateTime.Now;
                                    department.DepartmentName = Value.ToString();
                                }
                            }
                        }
                        if (GetColumnValue(titleList, "项目名称", table, i, out Value))
                        {
                            if (summary.ProjectID > 0)
                            {
                                project = projectList.FirstOrDefault(p => p.ID == summary.ProjectID);
                                if (project == null)
                                {
                                    project = new Foresight.DataAccess.Cheque_Project();
                                    project.AddTime = DateTime.Now;
                                }
                                project.ProjectName = Value.ToString();
                            }
                            else if (!string.IsNullOrEmpty(Value.ToString()))
                            {
                                project = projectList.FirstOrDefault(p => p.ProjectName.Equals(Value.ToString()));
                                if (project == null)
                                {
                                    project = new Foresight.DataAccess.Cheque_Project();
                                    project.AddTime = DateTime.Now;
                                    project.ProjectName = Value.ToString();
                                }
                            }
                        }
                        if (GetColumnValue(titleList, "销售单位名称", table, i, out Value))
                        {
                            if (summary.SellerID > 0)
                            {
                                seller = sellerList.FirstOrDefault(p => p.ID == summary.SellerID);
                                if (seller == null)
                                {
                                    seller = new Foresight.DataAccess.Cheque_Seller();
                                    seller.AddTime = DateTime.Now;
                                }
                                seller.SellerName = Value.ToString();
                            }
                            else if (!string.IsNullOrEmpty(Value.ToString()))
                            {
                                seller = sellerList.FirstOrDefault(p => p.SellerName.Equals(Value.ToString()));
                                if (seller == null)
                                {
                                    seller = new Foresight.DataAccess.Cheque_Seller();
                                    seller.AddTime = DateTime.Now;
                                    seller.SellerName = Value.ToString();
                                }
                            }
                        }
                        if (GetColumnValue(titleList, "销售纳税人识别号", table, i, out Value))
                        {
                            if (seller != null)
                            {
                                seller.SellerTaxNumber = Value.ToString();
                            }
                        }
                        if (GetColumnValue(titleList, "销售地址电话", table, i, out Value))
                        {
                            if (seller != null)
                            {
                                seller.SellerAddressPhone = Value.ToString();
                            }
                        }
                        if (GetColumnValue(titleList, "销售开户行及帐号", table, i, out Value))
                        {
                            if (seller != null)
                            {
                                seller.SellerBankAccount = Value.ToString();
                            }
                        }
                        if (GetColumnValue(titleList, "购货单位名称", table, i, out Value))
                        {
                            if (summary.BuyerID > 0)
                            {
                                buyer = buyerList.FirstOrDefault(p => p.ID == summary.BuyerID);
                                if (buyer == null)
                                {
                                    buyer = new Foresight.DataAccess.Cheque_Buyer();
                                    buyer.AddTime = DateTime.Now;
                                }
                                buyer.BuyerName = Value.ToString();
                            }
                            else if (!string.IsNullOrEmpty(Value.ToString()))
                            {
                                buyer = buyerList.FirstOrDefault(p => p.BuyerName.Equals(Value.ToString()));
                                if (buyer == null)
                                {
                                    buyer = new Foresight.DataAccess.Cheque_Buyer();
                                    buyer.AddTime = DateTime.Now;
                                    buyer.BuyerName = Value.ToString();
                                }
                            }
                        }
                        if (GetColumnValue(titleList, "购货纳税人识别号", table, i, out Value))
                        {
                            if (buyer != null)
                            {
                                buyer.BuyerTaxNumber = Value.ToString();
                            }
                        }
                        if (GetColumnValue(titleList, "购货地址电话", table, i, out Value))
                        {
                            if (buyer != null)
                            {
                                buyer.BuyerAddressPhone = Value.ToString();
                            }
                        }
                        if (GetColumnValue(titleList, "购货开户行及帐号", table, i, out Value))
                        {
                            if (buyer != null)
                            {
                                buyer.BuyerBankAccount = Value.ToString();
                            }
                        }
                        #endregion
                    }
                    #region 货物 货物分类
                    if (GetColumnValue(titleList, "货物或应税劳务名称", table, i, out Value))
                    {
                        if (!string.IsNullOrEmpty(Value.ToString()))
                        {
                            product = productList.FirstOrDefault(p => p.ProductName.Equals(Value.ToString()));
                            if (product == null)
                            {
                                product = new Foresight.DataAccess.Cheque_Product();
                                product.AddTime = DateTime.Now;
                                product.ProductName = Value.ToString();
                            }
                            if (summary.ID > 0 && product.ID > 0)
                            {
                                detail = Foresight.DataAccess.Cheque_InDetail.GetCheque_InDetail(summary.ID, product.ID);
                            }
                            if (detail == null)
                            {
                                detail = new Foresight.DataAccess.Cheque_InDetail();
                            }
                            detail.ProductName = Value.ToString();
                        }
                    }
                    if (GetColumnValue(titleList, "规格型号", table, i, out Value))
                    {
                        if (product != null)
                        {
                            product.ModelNumber = Value.ToString();
                        }
                        if (detail != null)
                        {
                            detail.ModelNumber = Value.ToString();
                        }
                    }
                    if (GetColumnValue(titleList, "单位", table, i, out Value))
                    {
                        if (product != null)
                        {
                            product.Unit = Value.ToString();
                        }
                        if (detail != null)
                        {
                            detail.Unit = Value.ToString();
                        }
                    }
                    if (GetColumnValue(titleList, "单价", table, i, out Value))
                    {
                        if (product != null)
                        {
                            product.UnitPrice = GetDecimalValue(Value);
                        }
                        if (detail != null)
                        {
                            detail.UnitPrice = GetDecimalValue(Value);
                        }
                    }
                    if (GetColumnValue(titleList, "数量", table, i, out Value))
                    {
                        if (detail != null)
                        {
                            detail.TotalCount = GetIntValue(Value);
                        }
                    }
                    if (GetColumnValue(titleList, "税率", table, i, out Value))
                    {
                        if (detail != null)
                        {
                            detail.TaxRate = GetDecimalValue(Value).ToString();
                        }
                    }
                    if (detail != null)
                    {
                        detail.TotalCost = detail.UnitPrice * detail.TotalCount;
                        detail.TotalTaxCost = Math.Round((detail.TotalCost * Convert.ToInt32(detail.TaxRate) / 100), 2);
                        detail.TotalSummaryCost = detail.TotalCost + detail.TotalTaxCost;
                    }
                    if (GetColumnValue(titleList, "货物分类", table, i, out Value))
                    {
                        if (!string.IsNullOrEmpty(Value.ToString()))
                        {
                            productCategory = productCategoryList.FirstOrDefault(p => p.ProductCategoryName.Equals(Value.ToString()));
                            if (productCategory == null)
                            {
                                productCategory = new Foresight.DataAccess.Cheque_ProductCategory();
                                productCategory.ProductCategoryName = Value.ToString();
                            }
                        }
                    }
                    #endregion
                    if (!isSame)
                    {
                        if (departmentCategory != null)
                        {
                            departmentCategory.Save();
                        }
                        if (department != null)
                        {
                            if (departmentCategory != null)
                            {
                                department.DepartmentCategoryID = departmentCategory.ID;
                            }
                            department.Save();
                            summary.DepartmentID = department.ID;
                        }
                        if (projectCategory != null)
                        {
                            projectCategory.Save();
                        }
                        if (project != null)
                        {
                            if (projectCategory != null)
                            {
                                project.ProjectCategoryID = projectCategory.ID;
                            }
                            project.Save();
                            summary.ProjectID = project.ID;
                        }
                        if (sellerCategory != null)
                        {
                            sellerCategory.Save();
                        }
                        if (seller != null)
                        {
                            if (sellerCategory != null)
                            {
                                seller.SellerCategoryID = sellerCategory.ID;
                            }
                            seller.Save();
                            summary.SellerID = seller.ID;
                        }
                        if (buyerCategory != null)
                        {
                            buyerCategory.Save();
                        }
                        if (buyer != null)
                        {
                            if (buyerCategory != null)
                            {
                                buyer.BuyerCategoryID = buyerCategory.ID;
                            }
                            buyer.Save();
                            summary.BuyerID = buyer.ID;
                        }
                    }
                    summary.Save();
                    if (productCategory != null)
                    {
                        productCategory.Save();
                    }
                    if (product != null)
                    {
                        if (productCategory != null)
                        {
                            product.ProductCategoryID = productCategory.ID;
                        }
                        product.Save();
                        if (detail != null)
                        {
                            detail.ProductID = product.ID;
                            detail.InSummaryID = summary.ID;
                            detail.Save();
                        }
                    }
                    presummary = summary;
                }
            }
            #endregion
            msg += "<p>导入成功</p>";
            context.Response.Write(msg);
        }
        #region Comm Methods
        private decimal GetDecimalValue(object value)
        {
            decimal result = 0;
            decimal.TryParse(value.ToString(), out result);
            return result;
        }
        private int GetIntValue(object value)
        {
            int result = 0;
            int.TryParse(value.ToString(), out result);
            return result;
        }
        private DateTime GetDateTimeValue(object value)
        {
            DateTime result = DateTime.MinValue;
            DateTime.TryParse(value.ToString(), out result);
            return result;
        }
        private bool GetColumnValue(Foresight.DataAccess.TableColumn[] titleList, string Title, DataTable table, int index, out object Value)
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