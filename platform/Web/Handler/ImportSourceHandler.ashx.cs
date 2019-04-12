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
    public class ImportSourceHandler : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string visit = context.Request.Params["visit"];
            if (string.IsNullOrEmpty(visit))
            {
                LogHelper.WriteDebug("ImportSourceHandler", "visit为空");
                context.Response.Write(null);
                return;
            }
            visit = visit.ToLower();
            try
            {
                switch (visit)
                {
                    case "importroomsource":
                        importroomsource(context);
                        break;
                    case "importckproduct":
                        importckproduct(context);
                        break;
                    case "importdevicesource":
                        importdevicesource(context);
                        break;
                    case "importckin":
                        importckin(context);
                        break;
                    case "importckproperty":
                        importckproperty(context);
                        break;
                    case "importwechatlotteryuser":
                        importwechatlotteryuser(context);
                        break;
                    case "importstarttime":
                        importstarttime(context);
                        break;
                    case "importcontractdivide":
                        importcontractdivide(context);
                        break;
                    case "exportlotteryusertemplate":
                        exportlotteryusertemplate(context);
                        break;
                    default:
                        WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "Unkown Visit: " + visit);
                        break;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("ImportSourceHandler", "visit: " + visit, ex);
                context.Response.Write("{\"status\":false}");
            }
        }
        private void exportlotteryusertemplate(HttpContext context)
        {
            string downloadurl = string.Empty;
            string error = string.Empty;
            bool status = APPCode.ExportHelper.DownLoadLotteryUserTemplateData(out downloadurl, out error);
            WebUtil.WriteJson(context, new { status = status, downloadurl = downloadurl, error = error });
        }
        private void importcontractdivide(HttpContext context)
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
            var contract_list = Foresight.DataAccess.Contract.GetContracts().ToArray();
            titleList = GetTableColumns("contractdividemgr");
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    #region 导入处理
                    for (int j = 0; j < uploadFiles.Count; j++)
                    {
                        HttpPostedFile postedFile = uploadFiles[j];
                        string filepath = HttpContext.Current.Server.MapPath("~/upload/ImportContract/" + DateTime.Now.ToString("yyyyMMdd"));
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
                            Foresight.DataAccess.Contract contract = null;
                            object Value, ContractNo;
                            if (GetColumnValue("合同号", table, i, out ContractNo))
                            {
                                contract = contract_list.FirstOrDefault(p => p.ContractNo.Equals(ContractNo));
                            }
                            if (contract == null)
                            {
                                msg += "<p>第" + (i + 2) + "行上传失败。原因：合同号不存在</p>";
                                ImportFailed = true;
                                break;
                            }
                            int ID = 0;
                            int.TryParse(table.Rows[i]["账单ID"].ToString(), out ID);
                            Foresight.DataAccess.Contract_Divide data = null;
                            if (ID > 0)
                            {
                                data = Foresight.DataAccess.Contract_Divide.GetContract_Divide(ID, helper);
                            }
                            if (data == null)
                            {
                                data = new Foresight.DataAccess.Contract_Divide();
                                data.ChargeStatus = 2;
                                data.AddTime = DateTime.Now;
                                data.ContractID = contract.ID;
                            }
                            if (data.ChargeStatus == 1)
                            {
                                msg += "<p>第" + (i + 2) + "行上传失败。原因：该费用已收取</p>";
                                ImportFailed = true;
                                break;
                            }
                            if (GetColumnValue("租户名称", table, i, out Value))
                            {
                                data.RentName = Value.ToString();
                            }
                            if (GetColumnValue("账单状态", table, i, out Value))
                            {
                                data.ChargeStatus = 2;
                                if (Value.ToString().Equals("未收"))
                                {
                                    data.ChargeStatus = 0;
                                }
                                if (Value.ToString().Equals("已收"))
                                {
                                    data.ChargeStatus = 1;
                                }
                            }
                            if (GetColumnValue("分成方式", table, i, out Value))
                            {
                                if (Value.ToString().Equals("阶梯比例"))
                                {
                                    data.DivideType = Utility.EnumModel.ContractDivideTypeDefine.jietipercent.ToString();
                                }
                                else
                                {
                                    data.DivideType = Utility.EnumModel.ContractDivideTypeDefine.fixedpercent.ToString();
                                }
                            }
                            if (GetColumnValue("账单日期", table, i, out Value))
                            {
                                data.WriteDate = WebUtil.GetDateTimeByStr(Value.ToString());
                            }
                            if (GetColumnValue("账单开始日期", table, i, out Value))
                            {
                                data.StartTime = WebUtil.GetDateTimeByStr(Value.ToString());
                            }
                            if (GetColumnValue("账单结束日期", table, i, out Value))
                            {
                                data.EndTime = WebUtil.GetDateTimeByStr(Value.ToString());
                            }
                            if (GetColumnValue("销售额", table, i, out Value))
                            {
                                data.SellCost = WebUtil.GetDecimalByStr(Value.ToString());
                            }
                            if (data.ChargeStatus == 0)
                            {
                                //SaveRoomFee(data, helper);
                            }
                            else if (data.ChargeStatus == 1)
                            {
                                //SaveRoomHistoryFee(data, helper, AddMan);
                            }
                            data.Save(helper);
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
                    LogHelper.WriteError("ImportSourceHandler", "visit: importcontractdivide", ex);
                    helper.Rollback();
                }
                context.Response.Write(msg);
            }
        }
        private void importstarttime(HttpContext context)
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
                        string filepath = HttpContext.Current.Server.MapPath("~/upload/ImportStartTime/" + DateTime.Now.ToString("yyyyMMdd"));
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
                            DataRow dr = table.Rows[i];
                            int ID = WebUtil.GetIntByStr(dr["费项ID"].ToString());
                            if (ID <= 0)
                            {
                                msg += "<p>第" + (i + 2) + "行上传失败。原因：费项不存在</p>";
                                ImportFailed = true;
                                break;
                            }
                            Foresight.DataAccess.RoomFee roomFee = Foresight.DataAccess.RoomFee.GetRoomFee(ID, helper);
                            if (roomFee == null)
                            {
                                msg += "<p>第" + (i + 2) + "行上传失败。原因：费项不存在</p>";
                                ImportFailed = true;
                                break;
                            }
                            int CuiShouCount = RoomFeeAnalysis.GetCuiShouCount(roomFee.ID);
                            if (CuiShouCount > 0)
                            {
                                msg += "<p>第" + (i + 2) + "行上传失败。原因：此费项催收中</p>";
                                ImportFailed = true;
                                break;
                            }
                            DateTime StartTime = WebUtil.GetDateTimeByStr(dr["计费开始日期"].ToString());
                            DateTime EndTime = WebUtil.GetDateTimeByStr(dr["计费结束日期"].ToString());
                            DateTime NewEndTime = WebUtil.GetDateTimeByStr(dr["计费停用日期"].ToString());
                            decimal UnitPrice = WebUtil.GetDecimalByStr(dr["单价(月度)"].ToString());
                            roomFee.UnitPrice = UnitPrice;
                            roomFee.StartTime = StartTime;
                            roomFee.EndTime = EndTime;
                            roomFee.NewEndTime = NewEndTime;
                            roomFee.Remark = dr["备注"].ToString();
                            roomFee.Save(helper);
                            if (roomFee.ImportFeeID > 0)
                            {
                                var importfee = Foresight.DataAccess.ImportFee.GetOrCreateImportFeeByID(roomFee.ImportFeeID, helper);
                                if (importfee != null)
                                {
                                    importfee.StartTime = roomFee.StartTime;
                                    importfee.EndTime = roomFee.EndTime;
                                    importfee.UnitPrice = roomFee.UnitPrice;
                                    importfee.Save(helper);
                                }
                            }
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
                    LogHelper.WriteError("ImportSourceHandler", "visit: importstarttime", ex);
                    helper.Rollback();
                    msg += "<p>第" + (TotalNumber + 2) + "行上传失败。原因：" + ex.Message + "</p>";
                }
                context.Response.Write(msg);
            }
        }
        private void importwechatlotteryuser(HttpContext context)
        {
            int ActivityID = WebUtil.GetIntValue(context, "ActivityID");
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
            int count = 0;
            try
            {
                #region 导入处理
                for (int j = 0; j < uploadFiles.Count; j++)
                {
                    HttpPostedFile postedFile = uploadFiles[j];
                    string filepath = HttpContext.Current.Server.MapPath("~/upload/" + DateTime.Now.ToString("yyyyMMdd"));
                    if (!System.IO.Directory.Exists(filepath))
                    {
                        System.IO.Directory.CreateDirectory(filepath);
                    }
                    string filename = DateTime.Now.ToLocalTime().ToString("yyyyMMddHHmmss") + "_" + postedFile.FileName;
                    string fullpath = Path.Combine(filepath, filename);
                    postedFile.SaveAs(fullpath);
                    DataTable table = ExcelExportHelper.NPOIReadExcel(fullpath);
                    var user = WebUtil.GetUser(context);
                    var rolelist = Foresight.DataAccess.Role.GetAdminInRoleList(user.UserID);
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        count = i;
                        DataRow dr = table.Rows[i];
                        string CustomerName = dr["客户名称"].ToString();
                        if (string.IsNullOrEmpty(CustomerName))
                        {
                            msg += "<p>第" + (i + 2) + "行上传失败。原因：客户名称不能为空</p>";
                            context.Response.Write(msg);
                            return;
                        }
                        string PhoneNumber = dr["手机号码"].ToString();
                        if (string.IsNullOrEmpty(PhoneNumber))
                        {
                            msg += "<p>第" + (i + 2) + "行上传失败。原因：手机号码不能为空</p>";
                            context.Response.Write(msg);
                            return;
                        }
                        Foresight.DataAccess.Wechat_LotteryActivityUser data = Wechat_LotteryActivityUser.GetWechat_LotteryActivityUserByPhone(PhoneNumber, ActivityID);
                        if (data == null)
                        {
                            data = new Wechat_LotteryActivityUser();
                            data.AddTime = DateTime.Now;
                            data.ActivityID = ActivityID;
                        }
                        data.CustomerName = CustomerName;
                        data.PhoneNumber = PhoneNumber;
                        data.Save();
                    }
                }
                #endregion
                msg += "<p>导入完成</p>";
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("ImportSourceHandler", "visit: importckproperty", ex);
                msg = "第" + (count + 2) + "行开始数据有问题，导入失败";
            }
            context.Response.Write(msg);
        }
        private void importckproperty(HttpContext context)
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
            var propertylist = Foresight.DataAccess.CKProperty.GetCKProperties().ToList();
            var categorylist = Foresight.DataAccess.CKPropertyCategory.GetCKPropertyCategories().ToList();
            var departmentlist = Foresight.DataAccess.CKDepartment.GetCKDepartments().ToList();
            int count = 0;
            try
            {
                #region 导入处理
                for (int j = 0; j < uploadFiles.Count; j++)
                {
                    HttpPostedFile postedFile = uploadFiles[j];
                    string filepath = HttpContext.Current.Server.MapPath("~/upload/" + DateTime.Now.ToString("yyyyMMdd"));
                    if (!System.IO.Directory.Exists(filepath))
                    {
                        System.IO.Directory.CreateDirectory(filepath);
                    }
                    string filename = DateTime.Now.ToLocalTime().ToString("yyyyMMddHHmmss") + "_" + postedFile.FileName;
                    string fullpath = Path.Combine(filepath, filename);
                    postedFile.SaveAs(fullpath);
                    DataTable table = ExcelExportHelper.NPOIReadExcel(fullpath);
                    var user = WebUtil.GetUser(context);
                    var rolelist = Foresight.DataAccess.Role.GetAdminInRoleList(user.UserID);
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        count = i;
                        DataRow dr = table.Rows[i];
                        string Value = dr["资产编号"].ToString();
                        if (string.IsNullOrEmpty(Value))
                        {
                            msg += "<p>第" + (i + 2) + "行上传失败。原因：资产编号不能为空</p>";
                            context.Response.Write(msg);
                            return;
                        }
                        Foresight.DataAccess.CKProperty data = propertylist.FirstOrDefault(p => p.PropertyNo.Equals(Value));
                        if (data == null)
                        {
                            data = new CKProperty();
                            data.AddMan = WebUtil.GetUser(context).RealName;
                            data.AddTime = DateTime.Now;
                        }
                        data.PropertyNo = Value;
                        data.PropertyName = dr["资产名称"].ToString();
                        Value = dr["资产类别"].ToString();
                        if (!string.IsNullOrEmpty(Value))
                        {
                            var category = categorylist.FirstOrDefault(p => p.PropertyCategoryName.Equals(Value));
                            if (category == null)
                            {
                                category = new CKPropertyCategory();
                                category.PropertyCategoryName = Value;
                                category.AddTime = DateTime.Now;
                                category.AddUser = WebUtil.GetUser(context).RealName;
                                category.Save();
                                categorylist.Add(category);
                            }
                            data.PropertyCategoryID = category.ID;
                        }
                        data.PropertyModelNo = dr["规格型号"].ToString();
                        data.PropertyUnit = dr["单位"].ToString();
                        data.PropertyCount = WebUtil.GetIntByStr(dr["数量"].ToString());
                        data.PropertyUnitPrice = WebUtil.GetDecimalByStr(dr["单价"].ToString());
                        data.PropertyCost = WebUtil.GetDecimalByStr(dr["购入金额"].ToString());
                        data.PropertyPurchaseDate = WebUtil.GetDateTimeByStr(dr["购入时间"].ToString());
                        data.PropertyUseYear = WebUtil.GetDecimalByStr(dr["预计使用年限"].ToString());
                        data.PropertyRealCost = WebUtil.GetDecimalByStr(dr["净值"].ToString());
                        data.PropertyDiscountCost = WebUtil.GetDecimalByStr(dr["折旧金额"].ToString());
                        data.PropertyChangeType = dr["变动方式"].ToString();
                        data.PropertyState = GetPropertyState(dr["状态"].ToString());
                        Value = dr["使用部门"].ToString();
                        if (!string.IsNullOrEmpty(Value))
                        {
                            var department = departmentlist.FirstOrDefault(p => p.DepartmentName.Equals(Value));
                            if (department == null)
                            {
                                department = new CKDepartment();
                                department.DepartmentName = Value;
                                department.AddTime = DateTime.Now;
                                department.Save();
                                departmentlist.Add(department);
                            }
                            data.PropertyDepartmentID = department.ID;
                        }
                        data.PropertyLocation = dr["存放地点"].ToString();
                        data.PropertyUseMan = dr["使用人员"].ToString();
                        data.PropertyContractName = dr["供应商"].ToString();
                        data.PropertyContactPhone = dr["联系方式"].ToString();
                        data.PropertyRemark = dr["备注"].ToString();
                        data.Save();
                    }
                }
                #endregion
                msg += "<p>导入完成</p>";
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("ImportSourceHandler", "visit: importckproperty", ex);
                msg = "第" + (count + 2) + "行开始数据有问题，导入失败";
            }
            context.Response.Write(msg);
        }
        public int GetPropertyState(string value)
        {
            int state = 0;
            switch (value)
            {
                case "在用":
                    state = 1;
                    break;
                case "封存":
                    state = 2;
                    break;
                case "待报废":
                    state = 3;
                    break;
                case "报废":
                    state = 4;
                    break;
                case "租赁":
                    state = 5;
                    break;
                case "出租":
                    state = 6;
                    break;
                default:
                    break;
            }
            return state;
        }
        private void importckin(HttpContext context)
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
            var ckcategory_list = Foresight.DataAccess.CKCategory.GetCKCategories().ToList();
            var ckincategory_list = Foresight.DataAccess.CKInCategory.GetCKInCategories().ToList();
            var ckdepartment_list = Foresight.DataAccess.CKDepartment.GetCKDepartments().ToList();
            var ckcontract_list = Foresight.DataAccess.CKContarct.GetCKContarcts().ToList();
            var ckproduct_list = Foresight.DataAccess.CKProduct.GetCKProducts().ToList();
            var ckproductcategory_list = Foresight.DataAccess.CKProductCategory.GetCKProductCategories().ToList();
            Foresight.DataAccess.CKProductInSumary ckinsummary = null;
            int count = 0;
            try
            {
                #region 导入处理
                for (int j = 0; j < uploadFiles.Count; j++)
                {
                    HttpPostedFile postedFile = uploadFiles[j];
                    string filepath = HttpContext.Current.Server.MapPath("~/upload/CangKu/" + DateTime.Now.ToString("yyyyMMdd"));
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
                        count = i;
                        #region 导入入库基本信息
                        DataRow dr = table.Rows[i];
                        string Value = string.Empty;
                        if (!string.IsNullOrEmpty(dr["入库单号"].ToString().Trim()) || !string.IsNullOrEmpty(dr["所属一级仓库类别"].ToString().Trim()) || !string.IsNullOrEmpty(dr["所属二级仓库类别"].ToString().Trim()) || !string.IsNullOrEmpty(dr["仓管员"].ToString().Trim()) || !string.IsNullOrEmpty(dr["入库时间"].ToString().Trim()) || !string.IsNullOrEmpty(dr["入库类别"].ToString().Trim()) || !string.IsNullOrEmpty(dr["所在部门"].ToString().Trim()) || !string.IsNullOrEmpty(dr["供应商"].ToString().Trim()) || !string.IsNullOrEmpty(dr["供应商联系人"].ToString().Trim()) || !string.IsNullOrEmpty(dr["供应商联系电话"].ToString().Trim()) || i == 0)
                        {
                            Value = dr["所属一级仓库类别"].ToString().Trim();
                            if (string.IsNullOrEmpty(Value))
                            {
                                msg += "<p>第" + (i + 2) + "行上传失败。原因：所属一级仓库类别不能为空</p>";
                                context.Response.Write(msg);
                                return;
                            }
                            var cktopcategory = ckcategory_list.FirstOrDefault(p => p.CategoryName.Equals(Value));
                            if (cktopcategory == null)
                            {
                                msg += "<p>第" + (i + 2) + "行上传失败。原因：所属一级仓库类别不存在</p>";
                                context.Response.Write(msg);
                                return;
                            }
                            ckinsummary = new Foresight.DataAccess.CKProductInSumary();
                            Value = dr["入库单号"].ToString().Trim();
                            if (!string.IsNullOrEmpty(Value) && !Value.Equals("系统自动生成"))
                            {
                                ckinsummary = CKProductInSumary.GetCKProductInSumaryByOrderNumber(Value);
                                if (ckinsummary == null)
                                {
                                    ckinsummary = new Foresight.DataAccess.CKProductInSumary();
                                    ckinsummary.OrderNumber = Value;
                                }
                                else
                                {
                                    int OrderNumberID = 0;
                                    ckinsummary.OrderNumber = Foresight.DataAccess.CKProductInSumary.GetLastestOrderNumber(out OrderNumberID);
                                    ckinsummary.OrderNumberID = OrderNumberID;
                                }
                            }
                            else
                            {
                                int OrderNumberID = 0;
                                ckinsummary.OrderNumber = Foresight.DataAccess.CKProductInSumary.GetLastestOrderNumber(out OrderNumberID);
                                ckinsummary.OrderNumberID = OrderNumberID;
                            }
                            ckinsummary.AddMan = WebUtil.GetUser(context).RealName;
                            ckinsummary.AddTime = DateTime.Now;
                            Value = dr["所属二级仓库类别"].ToString().Trim();
                            if (string.IsNullOrEmpty(Value))
                            {
                                ckinsummary.CKCategoryID = cktopcategory.ID;
                            }
                            else
                            {
                                var cksecondcategory = ckcategory_list.FirstOrDefault(p => p.CategoryName.Equals(Value) && p.ParentID == cktopcategory.ID);
                                if (cksecondcategory != null)
                                {
                                    ckinsummary.CKCategoryID = cksecondcategory.ID;
                                }
                                else
                                {
                                    ckinsummary.CKCategoryID = cktopcategory.ID;
                                }
                            }
                            ckinsummary.AddUserName = dr["仓管员"].ToString().Trim();
                            ckinsummary.InTime = WebUtil.GetDateTimeByStr(dr["入库时间"].ToString().Trim());
                            Value = dr["入库类别"].ToString().Trim();
                            if (!string.IsNullOrEmpty(Value))
                            {
                                var ckincategory = ckincategory_list.FirstOrDefault(p => p.InCategoryName.Equals(Value));
                                if (ckincategory == null)
                                {
                                    ckincategory = new CKInCategory();
                                    ckincategory.InCategoryName = Value;
                                    ckincategory.AddTime = DateTime.Now;
                                    ckincategory.CategoryType = Utility.EnumModel.InCategoryTypeDefine.ruku.ToString();
                                    ckincategory.Save();
                                    ckincategory_list.Add(ckincategory);
                                }
                                ckinsummary.InCategoryID = ckincategory.ID;
                            }
                            Value = dr["所在部门"].ToString().Trim();
                            if (!string.IsNullOrEmpty(Value))
                            {
                                var ckdepartment = ckdepartment_list.FirstOrDefault(p => p.DepartmentName.Equals(Value));
                                if (ckdepartment == null)
                                {
                                    ckdepartment = new CKDepartment();
                                    ckdepartment.DepartmentName = Value;
                                    ckdepartment.AddTime = DateTime.Now;
                                    ckdepartment.Save();
                                    ckdepartment_list.Add(ckdepartment);
                                }
                                ckinsummary.BelongDepartmentID = ckdepartment.ID;
                                ckinsummary.BelongTeamName = Value;
                            }
                            Value = dr["供应商"].ToString().Trim();
                            if (!string.IsNullOrEmpty(Value))
                            {
                                var ckcontract = ckcontract_list.FirstOrDefault(p => p.ContractName.Equals(Value));
                                if (ckcontract == null)
                                {
                                    ckcontract = new Foresight.DataAccess.CKContarct();
                                    ckcontract.ContractName = Value;
                                    ckcontract.ContractFullName = Value;
                                    ckcontract.AddTime = DateTime.Now;
                                    ckcontract.AddMan = WebUtil.GetUser(context).RealName;
                                    Value = dr["供应商联系人"].ToString().Trim();
                                    if (!string.IsNullOrEmpty(Value))
                                    {
                                        ckcontract.ContactMan = Value;
                                    }
                                    Value = dr["供应商联系电话"].ToString().Trim();
                                    if (!string.IsNullOrEmpty(Value))
                                    {
                                        ckcontract.PhoneNumber = Value;
                                    }
                                    ckcontract.Save();
                                    ckcontract_list.Add(ckcontract);
                                }
                                else
                                {
                                    Value = dr["供应商联系人"].ToString().Trim();
                                    if (!string.IsNullOrEmpty(Value))
                                    {
                                        ckcontract.ContactMan = Value;
                                    }
                                    Value = dr["供应商联系电话"].ToString().Trim();
                                    if (!string.IsNullOrEmpty(Value))
                                    {
                                        ckcontract.PhoneNumber = Value;
                                    }
                                    ckcontract.Save();
                                }
                                ckinsummary.ContractID = ckcontract.ID;
                                ckinsummary.ContractName = ckcontract.ContractName;
                                ckinsummary.ContractUserName = ckcontract.ContactMan;
                                ckinsummary.ContractPhoneNumber = ckcontract.PhoneNumber;
                                ckinsummary.BelongTeamName = Value;
                            }
                            ckinsummary.Save();
                        }
                        #endregion
                        #region 导入入库产品信息
                        Value = dr["物品名称"].ToString().Trim();
                        string Model = dr["规格型号"].ToString().Trim();
                        if (!string.IsNullOrEmpty(Value))
                        {
                            var ckinproduct = new Foresight.DataAccess.CKProudctInDetail();
                            string productcategoryname = dr["物品类别"].ToString();
                            var ckproductcategory = ckproductcategory_list.FirstOrDefault(p => p.ProductCategoryName.Equals(productcategoryname));
                            if (ckproductcategory == null)
                            {
                                ckproductcategory = new CKProductCategory();
                                ckproductcategory.ProductCategoryName = productcategoryname;
                                ckproductcategory.AddTime = DateTime.Now;
                                ckproductcategory.AddMan = WebUtil.GetUser(context).RealName;
                                ckproductcategory.Save();
                            }
                            Foresight.DataAccess.CKProduct ckproduct = null;
                            if (!string.IsNullOrEmpty(Model))
                            {
                                ckproduct = ckproduct_list.FirstOrDefault(p => p.ProductName.Equals(Value) && p.ModelNumber.Equals(Model));
                            }
                            else
                            {
                                ckproduct = ckproduct_list.FirstOrDefault(p => p.ProductName.Equals(Value));
                            }
                            if (ckproduct == null)
                            {
                                ckproduct = new Foresight.DataAccess.CKProduct();
                                ckproduct.CategoryID = ckproductcategory.ID;
                                ckproduct.ProductName = Value;
                                ckproduct.AddTime = DateTime.Now;
                                ckproduct.AddMan = WebUtil.GetUser(context).RealName;
                                ckproduct.ModelNumber = Model;
                                ckproduct.Unit = dr["单位"].ToString().Trim();
                                ckproduct_list.Add(ckproduct);
                                ckproduct.Save();
                            }
                            else
                            {
                                if (ckproductcategory.ID != ckproduct.CategoryID)
                                {
                                    ckproduct.CategoryID = ckproductcategory.ID;
                                    ckproduct.Save();
                                }
                            }
                            ckinproduct.InSummaryID = ckinsummary.ID;
                            ckinproduct.ProductID = ckproduct.ID;
                            ckinproduct.UnitPrice = WebUtil.GetDecimalByStr(dr["入库单价"].ToString().Trim());
                            ckinproduct.InTotalCount = WebUtil.GetIntByStr(dr["入库数量"].ToString().Trim());
                            ckinproduct.InTotalPrice = ckinproduct.UnitPrice * ckinproduct.InTotalCount;
                            ckinproduct.AddMan = WebUtil.GetUser(context).RealName;
                            ckinproduct.AddTime = DateTime.Now;
                            ckinproduct.Remark = dr["备注"].ToString();
                            ckinproduct.Save();
                        }
                        #endregion
                    }
                }
                #endregion
                msg += "<p>导入完成</p>";
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("ImportSourceHandler", "visit: importckin", ex);
                msg = "第" + (count + 2) + "行开始数据有问题，导入失败";
            }
            context.Response.Write(msg);
        }
        private void importdevicesource(HttpContext context)
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
            var devicelist = Foresight.DataAccess.Device.GetDevices().ToList();
            var devicetypelist = Foresight.DataAccess.Device_Type.GetDevice_Types().ToList();
            var devicegrouplist = Foresight.DataAccess.Device_Group.GetDevice_Groups().ToList();
            var tasktypelist = Foresight.DataAccess.Device_TaskType.GetDevice_TaskTypes().ToList();
            var appusers = Foresight.DataAccess.User.GetAPPUserList();
            var projectlist = WebUtil.GetMyProjectsByLevel(1, WebUtil.GetUser(context).UserID);
            titleList = GetTableColumns("devicemgr");
            int count = 0;
            try
            {
                #region 导入处理
                for (int j = 0; j < uploadFiles.Count; j++)
                {
                    HttpPostedFile postedFile = uploadFiles[j];
                    string filepath = HttpContext.Current.Server.MapPath("~/upload/" + DateTime.Now.ToString("yyyyMMdd"));
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
                        count = i;
                        DataRow dr = table.Rows[i];
                        object Value;
                        string devicename = string.Empty;
                        if (GetColumnValue("设备名称", table, i, out Value))
                        {
                            devicename = Value.ToString();
                        }
                        if (string.IsNullOrEmpty(devicename))
                        {
                            msg += "<p>第" + (i + 2) + "行上传失败。原因：设备名称不能为空</p>";
                            context.Response.Write(msg);
                            return;
                        }
                        string deviceno = string.Empty;
                        if (GetColumnValue("设备编码", table, i, out Value))
                        {
                            deviceno = Value.ToString();
                        }
                        if (string.IsNullOrEmpty(deviceno))
                        {
                            msg += "<p>第" + (i + 2) + "行上传失败。原因：设备编码不能为空</p>";
                            context.Response.Write(msg);
                            return;
                        }
                        string projectname = string.Empty;
                        if (GetColumnValue("所属项目", table, i, out Value))
                        {
                            projectname = Value.ToString();
                        }
                        if (string.IsNullOrEmpty(projectname))
                        {
                            msg += "<p>第" + (i + 2) + "行上传失败。原因：所属项目不能为空</p>";
                            context.Response.Write(msg);
                            return;
                        }
                        var project = projectlist.FirstOrDefault(p => p.Name.Equals(projectname));
                        if (project == null)
                        {
                            msg += "<p>第" + (i + 2) + "行上传失败。原因：所属项目不存在</p>";
                            context.Response.Write(msg);
                            return;
                        }
                        var device = devicelist.FirstOrDefault(p => p.DeviceNo.Equals(deviceno));
                        if (device == null)
                        {
                            device = new Foresight.DataAccess.Device();
                            device.DeviceNo = deviceno;
                            device.AddTime = DateTime.Now;
                        }
                        device.ProjectID = project.ID;
                        device.DeviceName = devicename;
                        string devicetypename = string.Empty;
                        if (GetColumnValue("设备类型", table, i, out Value))
                        {
                            devicetypename = Value.ToString();
                        }
                        if (!string.IsNullOrEmpty(devicetypename))
                        {
                            var devicetype = devicetypelist.FirstOrDefault(p => p.DeviceTypeName.Equals(devicetypename));
                            if (devicetype == null)
                            {
                                devicetype = new Device_Type();
                                devicetype.AddTime = DateTime.Now;
                                devicetype.DeviceTypeName = devicetypename;
                                devicetype.ParentID = 0;
                                devicetype.Save();
                                devicetypelist.Add(devicetype);
                            }
                            device.DeviceTypeID = devicetype.ID;
                        }
                        string devicegroupname = string.Empty;
                        if (GetColumnValue("设备分组", table, i, out Value))
                        {
                            devicegroupname = Value.ToString();
                        }
                        if (!string.IsNullOrEmpty(devicegroupname))
                        {
                            var devicegroup = devicegrouplist.FirstOrDefault(p => p.DeviceGroupName.Equals(devicegroupname));
                            if (devicegroup == null)
                            {
                                devicegroup = new Device_Group();
                                devicegroup.AddTime = DateTime.Now;
                                devicegroup.DeviceGroupName = devicegroupname;
                                devicegroup.Save();
                                devicegrouplist.Add(devicegroup);
                            }
                            device.DeviceGroupID = devicegroup.ID;
                        }
                        if (GetColumnValue("规格型号", table, i, out Value))
                        {
                            device.ModelNo = Value.ToString();
                        }
                        if (GetColumnValue("设备状态", table, i, out Value))
                        {
                            device.DeviceStatus = GetDeviceStatus(Value.ToString());
                        }
                        if (GetColumnValue("设备等级", table, i, out Value))
                        {
                            device.DeviceLevel = Value.ToString();
                        }
                        string tasktypename = string.Empty;
                        if (GetColumnValue("维保类型", table, i, out Value))
                        {
                            tasktypename = Value.ToString();
                        }
                        if (!string.IsNullOrEmpty(tasktypename))
                        {
                            var tasktype = tasktypelist.FirstOrDefault(p => p.TaskTypeName.Equals(tasktypename));
                            if (tasktype == null)
                            {
                                tasktype = new Device_TaskType();
                                tasktype.AddTime = DateTime.Now;
                                tasktype.TaskTypeName = tasktypename;
                                tasktype.Save();
                                tasktypelist.Add(tasktype);
                            }
                            device.TaskTypeID = tasktype.ID;
                        }
                        if (GetColumnValue("供应商单位", table, i, out Value))
                        {
                            device.Supplier = Value.ToString();
                        }
                        if (GetColumnValue("供应商联系人", table, i, out Value))
                        {
                            device.SupplierMan = Value.ToString();
                        }
                        if (GetColumnValue("供应商联系方式", table, i, out Value))
                        {
                            device.SupplierPhone = Value.ToString();
                        }
                        if (GetColumnValue("购入日期", table, i, out Value))
                        {
                            device.PurchaseDate = WebUtil.GetDateTimeByStr(Value.ToString());
                        }
                        if (GetColumnValue("质保期", table, i, out Value))
                        {
                            device.GuaranteeDate = Value.ToString();
                        }
                        if (GetColumnValue("质保到期日期", table, i, out Value))
                        {
                            device.GuaranteeEndDate = WebUtil.GetDateTimeByStr(Value.ToString());
                        }
                        if (GetColumnValue("维保单位", table, i, out Value))
                        {
                            device.RepairCompany = Value.ToString();
                        }
                        string repairechargeman = string.Empty;
                        if (GetColumnValue("维保责任人", table, i, out Value))
                        {
                            repairechargeman = Value.ToString();
                        }
                        if (!string.IsNullOrEmpty(repairechargeman))
                        {
                            var user = appusers.FirstOrDefault(p => p.RealName.Equals(repairechargeman));
                            if (user != null)
                            {
                                device.RepairUserID = user.UserID;
                            }
                        }
                        if (GetColumnValue("维保联系方式", table, i, out Value))
                        {
                            device.RepairUserPhone = Value.ToString();
                        }
                        if (GetColumnValue("首次维保日期", table, i, out Value))
                        {
                            device.FirstRepairDate = WebUtil.GetDateTimeByStr(Value.ToString());
                        }
                        string repaircirclestr = string.Empty;
                        if (GetColumnValue("维保周期", table, i, out Value))
                        {
                            repaircirclestr = Value.ToString();
                        }
                        if (!string.IsNullOrEmpty(repaircirclestr) && repaircirclestr.Length >= 2)
                        {
                            string repaircirclestr_part1 = repaircirclestr.Substring(0, repaircirclestr.Length - 1);
                            int RepairCount = 0;
                            int.TryParse(repaircirclestr_part1, out RepairCount);
                            device.RepairCount = RepairCount;
                            string repaircirclestr_part2 = repaircirclestr.Substring(repaircirclestr.Length - 1, 1);
                            device.RepairCycle = GetCircleKey(repaircirclestr_part2);
                        }
                        if (GetColumnValue("上次维保日期", table, i, out Value))
                        {
                            device.LastRepairDate = WebUtil.GetDateTimeByStr(Value.ToString());
                        }
                        if (GetColumnValue("本次维保日期", table, i, out Value))
                        {
                            device.ThisRepairDate = WebUtil.GetDateTimeByStr(Value.ToString());
                        }
                        string checkchargeman = string.Empty;
                        if (GetColumnValue("巡检责任人", table, i, out Value))
                        {
                            checkchargeman = Value.ToString();
                        }
                        if (!string.IsNullOrEmpty(checkchargeman))
                        {
                            var user = appusers.FirstOrDefault(p => p.RealName.Equals(checkchargeman));
                            if (user != null)
                            {
                                device.CheckUserID = user.UserID;
                            }
                        }
                        if (GetColumnValue("首次巡检日期", table, i, out Value))
                        {
                            device.FirstCheckDate = WebUtil.GetDateTimeByStr(Value.ToString());
                        }
                        string checkcirclestr = string.Empty;
                        if (GetColumnValue("巡检周期", table, i, out Value))
                        {
                            checkchargeman = Value.ToString();
                        }
                        if (!string.IsNullOrEmpty(checkcirclestr) && checkcirclestr.Length >= 2)
                        {
                            string checkcirclestr_part1 = checkcirclestr.Substring(0, checkcirclestr.Length - 1);
                            int CheckCount = 0;
                            int.TryParse(checkcirclestr_part1, out CheckCount);
                            device.CheckCount = CheckCount;
                            string checkcirclestr_part2 = checkcirclestr.Substring(checkcirclestr.Length - 1, 1);
                            device.CheckCycle = GetCircleKey(checkcirclestr_part2);
                        }
                        if (GetColumnValue("上次巡检日期", table, i, out Value))
                        {
                            device.LastCheckDate = WebUtil.GetDateTimeByStr(Value.ToString());
                        }
                        if (GetColumnValue("本次巡检日期", table, i, out Value))
                        {
                            device.ThisCheckDate = WebUtil.GetDateTimeByStr(Value.ToString());
                        }
                        if (GetColumnValue("存放位置", table, i, out Value))
                        {
                            device.LocationPlace = Value.ToString();
                        }
                        device.Save();
                        devicelist.Add(device);
                    }
                }
                #endregion
                msg += "<p>导入完成</p>";
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("ImportSourceHandler", "visit: importdevicesource", ex);
                msg = "第" + (count + 2) + "行开始数据有问题，导入失败";
            }
            context.Response.Write(msg);
        }
        private string GetCircleKey(string desc)
        {
            if (desc.Equals("月"))
            {
                return "month";
            }
            return "day";
        }
        private int GetDeviceStatus(string desc)
        {
            if (desc.Equals("停用"))
            {
                return 2;
            }
            if (desc.Equals("报废"))
            {
                return 3;
            }
            return 1;
        }
        private void importckproduct(HttpContext context)
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
            var categorylist = Foresight.DataAccess.CKProductCategory.GetCKProductCategories().ToList();
            var ckproductlist = Foresight.DataAccess.CKProduct.GetCKProducts().ToList();
            int count = 0;
            try
            {
                #region 导入处理
                for (int j = 0; j < uploadFiles.Count; j++)
                {
                    HttpPostedFile postedFile = uploadFiles[j];
                    string filepath = HttpContext.Current.Server.MapPath("~/upload/" + DateTime.Now.ToString("yyyyMMdd"));
                    if (!System.IO.Directory.Exists(filepath))
                    {
                        System.IO.Directory.CreateDirectory(filepath);
                    }
                    string filename = DateTime.Now.ToLocalTime().ToString("yyyyMMddHHmmss") + "_" + postedFile.FileName;
                    string fullpath = Path.Combine(filepath, filename);
                    postedFile.SaveAs(fullpath);
                    DataTable table = ExcelExportHelper.NPOIReadExcel(fullpath);
                    var user = WebUtil.GetUser(context);
                    var rolelist = Foresight.DataAccess.Role.GetAdminInRoleList(user.UserID);
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        count = i;
                        DataRow dr = table.Rows[i];
                        string categoryname = dr["物品类别"].ToString();
                        if (string.IsNullOrEmpty(categoryname))
                        {
                            msg += "<p>第" + (i + 2) + "行上传失败。原因：物品类别不能为空</p>";
                            context.Response.Write(msg);
                            return;
                        }
                        string productname = dr["物品名称"].ToString();
                        if (string.IsNullOrEmpty(productname))
                        {
                            msg += "<p>第" + (i + 2) + "行上传失败。原因：物品名称不能为空</p>";
                            context.Response.Write(msg);
                            return;
                        }
                        string productnumber = dr["物品编号"].ToString();
                        if (string.IsNullOrEmpty(productnumber))
                        {
                            msg += "<p>第" + (i + 2) + "行上传失败。原因：物品编号不能为空</p>";
                            context.Response.Write(msg);
                            return;
                        }
                        Foresight.DataAccess.CKProduct ckproduct = null;
                        #region 版本2
                        //Foresight.DataAccess.CKProduct[] sub_ckproductlist = ckproductlist.Where(p => p.ProductNumber.Equals(productnumber)).OrderByDescending(p => p.AddTime).ToArray();
                        //if (sub_ckproductlist.Length > 0)
                        //{
                        //    var sub_list = sub_ckproductlist.Where(p => p.AddTime <= Convert.ToDateTime("2017-11-08 14:31:00") && p.ProductName.Equals(productname)).ToArray();
                        //    if (sub_list.Length > 0)
                        //    {
                        //        ckproductlist.Remove(sub_list[0]);
                        //        ckproduct = sub_list[0];
                        //        break;
                        //    }
                        //    if (ckproduct == null)
                        //    {
                        //        foreach (var item in sub_ckproductlist)
                        //        {
                        //            if (item.ProductName.Equals(productname))
                        //            {
                        //                ckproductlist.Remove(item);
                        //                ckproduct = item;
                        //                break;
                        //            }
                        //        }
                        //    }
                        //    if (ckproduct == null)
                        //    {
                        //        ckproductlist.Remove(sub_ckproductlist[0]);
                        //        ckproduct = sub_ckproductlist[0];
                        //    }
                        //}
                        #endregion
                        #region 正式版1
                        Foresight.DataAccess.CKProduct[] sub_ckproductlist = ckproductlist.Where(p => p.ProductName.Equals(productname)).OrderBy(p => p.ID).ToArray();
                        if (sub_ckproductlist.Length > 0)
                        {
                            foreach (var item in sub_ckproductlist)
                            {
                                if (item.ProductNumber.Equals(productnumber))
                                {
                                    ckproductlist.Remove(item);
                                    ckproduct = item;
                                    break;
                                }
                            }
                            if (ckproduct == null)
                            {
                                foreach (var item in sub_ckproductlist)
                                {
                                    if (string.IsNullOrEmpty(item.ProductNumber))
                                    {
                                        ckproductlist.Remove(item);
                                        ckproduct = item;
                                        break;
                                    }
                                }
                            }
                        }
                        #endregion
                        //Foresight.DataAccess.CKProduct ckproduct = ckproductlist.FirstOrDefault(p => p.ProductNumber.Equals(productnumber));
                        if (ckproduct == null)
                        {
                            ckproduct = new Foresight.DataAccess.CKProduct();
                        }
                        var category = categorylist.FirstOrDefault(p => p.ProductCategoryName.Equals(categoryname));
                        if (category == null)
                        {
                            category = new CKProductCategory();
                            category.ProductCategoryName = categoryname;
                            category.AddTime = DateTime.Now;
                            category.AddMan = WebUtil.GetUser(context).RealName;
                            category.Save();
                            categorylist.Add(category);
                        }
                        ckproduct.CategoryID = category.ID;
                        ckproduct.ProductNumber = productnumber;
                        ckproduct.ProductName = productname;
                        ckproduct.Unit = dr["计量单位"].ToString();
                        ckproduct.ModelNumber = dr["规格型号"].ToString();
                        int InventoryMin = 0;
                        int.TryParse(dr["库存下限"].ToString(), out InventoryMin);
                        int InventoryMax = 0;
                        int.TryParse(dr["库存上限"].ToString(), out InventoryMax);
                        ckproduct.InventoryMin = InventoryMin;
                        ckproduct.InventoryMax = InventoryMax;
                        ckproduct.ProductUnitPrice = WebUtil.GetDecimalByStr(dr["默认单价"].ToString());
                        ckproduct.AddMan = WebUtil.GetUser(context).RealName;
                        ckproduct.Save();
                        ckproductlist.Add(ckproduct);
                    }
                }
                #endregion
                msg += "<p>导入完成</p>";
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("ImportSourceHandler", "visit: importckproduct", ex);
                msg = "第" + (count + 2) + "行开始数据有问题，导入失败";
            }
            context.Response.Write(msg);
        }
        private decimal GetDecimalValue(object value)
        {
            decimal result = 0;
            decimal.TryParse(value.ToString(), out result);
            return result;
        }
        private decimal GetIntValue(object value)
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
        private bool GetColumnValue(string Title, DataTable table, int index, out object Value)
        {
            Value = null;
            bool result = false;
            if (!table.Columns.Contains(Title))
            {
                return false;
            }
            for (int i = 0; i < titleList.Count; i++)
            {
                if (titleList[i]["ColumnName"].Equals(Title))
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
        List<Dictionary<string, object>> titleList = new List<Dictionary<string, object>>();
        private void importroomsource(HttpContext context)
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
            HttpPostedFile postedFile = uploadFiles[0];
            string filepath = HttpContext.Current.Server.MapPath("~/upload/ImportRoomSource/" + DateTime.Now.ToString("yyyyMMdd"));
            if (!System.IO.Directory.Exists(filepath))
            {
                System.IO.Directory.CreateDirectory(filepath);
            }
            string filename = DateTime.Now.ToLocalTime().ToString("yyyyMMddHHmmss") + "_" + postedFile.FileName;
            string fullpath = Path.Combine(filepath, filename);
            postedFile.SaveAs(fullpath);
            string msg = string.Empty;
            DataTable table = ExcelExportHelper.NPOIReadExcel(fullpath);
            if (!table.Columns.Contains("资源ID"))
            {
                msg += "<p>导入失败，原因：资源ID列不存在</p>";
                WebUtil.WriteJson(context, msg);
                return;
            }
            int MinID = table.Select().Min(r =>
            {
                int ID = 0;
                if (r.Field<object>("资源ID") != null)
                {
                    int.TryParse(r.Field<object>("资源ID").ToString(), out ID);
                }
                return ID;
            });
            int MaxID = table.Select().Max(r =>
            {
                int ID = 0;
                if (r.Field<object>("资源ID") != null)
                {
                    int.TryParse(r.Field<object>("资源ID").ToString(), out ID);
                }
                return ID;
            });
            string TableName = Utility.EnumModel.DefineFieldTableName.RoomBasic.ToString();
            string TableName_Relation = Utility.EnumModel.DefineFieldTableName.RoomPhoneRelation.ToString();
            string isconver = context.Request["isconver"];
            bool ImportFailed = false;
            int count = 0;
            var fieldlist = Foresight.DataAccess.DefineField.GetDefineFieldsByTable_Name(TableName).Where(p => p.IsShown).ToArray();
            var contentlist = new Foresight.DataAccess.RoomBasicField[] { };
            if (fieldlist.Length > 0)
            {
                contentlist = Foresight.DataAccess.RoomBasicField.GetRoomBasicFieldsByFieldIDList(fieldlist.Select(p => p.ID).ToList()).ToArray();
            }
            var roomproperty_list = Foresight.DataAccess.RoomProperty.GetRoomProperties();
            var roomtype_list = Foresight.DataAccess.RoomType.GetRoomTypes();
            var roomstate_list = Foresight.DataAccess.RoomState.GetRoomStates();
            var comm_helper = new APPCode.CommHelper();
            titleList = GetTableColumns();
            var basicList = RoomBasic.GetRoomBasicListByMinMaxRoomID(MinID, MaxID);
            var phoneList = RoomPhoneRelation.GetRoomPhoneRelationListByMinMaxRoomID(MinID, MaxID);
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    #region 导入处理
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        count = i;
                        Project project = null;
                        object Value = table.Rows[i]["资源ID"];
                        int RoomID = 0;
                        if (Value != null)
                        {
                            int.TryParse(Value.ToString(), out RoomID);
                        }
                        if (RoomID > 0)
                        {
                            project = Foresight.DataAccess.Project.GetProject(RoomID, helper);
                        }
                        if (project == null)
                        {
                            msg += "<p>第" + (i + 2) + "行上传失败。原因：所属项目不存在</p>";
                            ImportFailed = true;
                            break;
                        }
                        if (GetColumnValue("房间编号", table, i, out Value))
                        {
                            project.Name = Value.ToString().Trim();
                        }
                        if (GetColumnValue("默认排序", table, i, out Value))
                        {
                            project.DefaultOrder = Value.ToString().Trim();
                        }
                        project.Save(helper);
                        RoomBasic basic = basicList.FirstOrDefault(p => p.RoomID == project.ID);
                        if (isconver.Equals("0") && basic != null)
                        {
                            continue;
                        }
                        if (basic == null)
                        {
                            basic = new RoomBasic();
                            basic.RoomID = project.ID;
                            basic.AddTime = DateTime.Now;
                        }
                        if (GetColumnValue("房间状态", table, i, out Value))
                        {
                            var roomstate = roomstate_list.FirstOrDefault(p => p.Name.Equals(Value.ToString().Trim()));
                            basic.RoomStateID = roomstate != null ? roomstate.ID : int.MinValue;
                            basic.RoomState = Value.ToString().Trim();
                        }
                        if (GetColumnValue(comm_helper.GetExistColumns(TableName, "BuildingArea"), table, i, out Value))
                        {
                            basic.BuildingArea = GetDecimalValue(Value);
                        }
                        if (GetColumnValue(comm_helper.GetExistColumns(TableName, "ContractArea"), table, i, out Value))
                        {
                            basic.ContractArea = GetDecimalValue(Value);
                        }
                        if (GetColumnValue("交房日期", table, i, out Value))
                        {
                            basic.PaymentTime = GetDateTimeValue(Value);
                        }
                        if (GetColumnValue("入住日期", table, i, out Value))
                        {
                            basic.MoveInTime = GetDateTimeValue(Value);
                        }
                        if (GetColumnValue("装修开始时间", table, i, out Value))
                        {
                            basic.ZxStartTime = GetDateTimeValue(Value);
                        }
                        if (GetColumnValue("装修验收时间", table, i, out Value))
                        {
                            basic.ZxEndTime = GetDateTimeValue(Value);
                        }
                        if (GetColumnValue("户型", table, i, out Value))
                        {
                            basic.RoomLayout = Value.ToString().Trim();
                        }
                        if (GetColumnValue("期数", table, i, out Value))
                        {
                            basic.BuildingNumber = Value.ToString().Trim();
                        }
                        if (GetColumnValue(comm_helper.GetExistColumns(TableName, "BuildOutArea"), table, i, out Value))
                        {
                            basic.BuildOutArea = GetDecimalValue(Value);
                        }
                        if (GetColumnValue(comm_helper.GetExistColumns(TableName, "BuildInArea"), table, i, out Value))
                        {
                            basic.BuildInArea = GetDecimalValue(Value);
                        }
                        if (GetColumnValue(comm_helper.GetExistColumns(TableName, "GonTanArea"), table, i, out Value))
                        {
                            basic.GonTanArea = GetDecimalValue(Value);
                        }
                        if (GetColumnValue(comm_helper.GetExistColumns(TableName, "ChanQuanArea"), table, i, out Value))
                        {
                            basic.ChanQuanArea = GetDecimalValue(Value);
                        }
                        if (GetColumnValue(comm_helper.GetExistColumns(TableName, "UseArea"), table, i, out Value))
                        {
                            basic.UseArea = GetDecimalValue(Value);
                        }
                        if (GetColumnValue(comm_helper.GetExistColumns(TableName, "PeiTaoArea"), table, i, out Value))
                        {
                            basic.PeiTaoArea = GetDecimalValue(Value);
                        }
                        if (GetColumnValue("功能系数", table, i, out Value))
                        {
                            basic.FunctionCoefficient = GetDecimalValue(Value);
                        }
                        if (GetColumnValue("分摊系数", table, i, out Value))
                        {
                            basic.FenTanCoefficient = GetDecimalValue(Value);
                        }
                        if (GetColumnValue("产权证号", table, i, out Value))
                        {
                            basic.ChanQuanNo = Value.ToString().Trim();
                        }
                        if (GetColumnValue("发证日期", table, i, out Value))
                        {
                            basic.CertificateTime = GetDateTimeValue(Value);
                        }
                        if (GetColumnValue("房间类型", table, i, out Value))
                        {
                            var roomtype = roomtype_list.FirstOrDefault(p => p.RoomTypeName.Equals(Value.ToString().Trim()));
                            basic.RoomTypeID = roomtype != null ? roomtype.ID : int.MinValue;
                            basic.RoomType = Value.ToString().Trim();
                        }
                        if (GetColumnValue("房源属性", table, i, out Value))
                        {
                            var roomproperty = roomproperty_list.FirstOrDefault(p => p.Name.Equals(Value.ToString().Trim()));
                            basic.RoomPropertyID = roomproperty != null ? roomproperty.ID : int.MinValue;
                            basic.RoomProperty = Value.ToString().Trim();
                        }
                        if (GetColumnValue("自定义一", table, i, out Value))
                        {
                            basic.CustomOne = Value.ToString().Trim();
                        }
                        if (GetColumnValue("自定义二", table, i, out Value))
                        {
                            basic.CustomTwo = Value.ToString().Trim();
                        }
                        if (GetColumnValue("自定义三", table, i, out Value))
                        {
                            basic.CustomThree = Value.ToString().Trim();
                        }
                        if (GetColumnValue("自定义四", table, i, out Value))
                        {
                            basic.CustomFour = Value.ToString().Trim();
                        }
                        foreach (var item in fieldlist)
                        {
                            if (GetColumnValue(item.FieldName, table, i, out Value))
                            {
                                var content_model = contentlist.FirstOrDefault(p => p.RoomID == basic.RoomID && p.FieldID == item.ID);
                                if (content_model == null)
                                {
                                    content_model = new RoomBasicField();
                                    content_model.AddTime = DateTime.Now;
                                    content_model.RoomID = basic.RoomID;
                                    content_model.FieldID = item.ID;
                                }
                                content_model.FieldContent = Value.ToString();
                                content_model.Save(helper);
                            }
                        }
                        if (GetColumnValue("是否激活", table, i, out Value))
                        {
                            basic.IsLocked = Value.ToString().Trim().Equals("是") ? false : true;
                        }
                        if (GetColumnValue("资源备注", table, i, out Value))
                        {
                            basic.Remark = Value.ToString();
                        }
                        List<RoomPhoneRelation> roomPhoneRelationList = new List<RoomPhoneRelation>();
                        if (GetColumnValue("住户姓名", table, i, out Value))
                        {
                            string[] CustomerNameArray = GetStringArray("住户姓名", table, i);
                            string[] RelationTypeDescArray = GetStringArray("住户标签", table, i);
                            string[] RelatePhoneNumberArray = GetStringArray("联系方式", table, i);
                            string[] IDCardTypeDescArray = GetStringArray("证件类型", table, i);
                            string[] RelationIDCardArray = GetStringArray("证件号码", table, i);
                            string[] BirthdayArray = GetStringArray("出生日期", table, i);
                            string[] EmailAddressArray = GetStringArray("电子信箱", table, i);
                            string[] HomeAddressArray = GetStringArray("联系地址", table, i);
                            string[] OfficeAddressArray = GetStringArray("工作单位", table, i);
                            string[] BankAccountNameArray = GetStringArray("开户名称", table, i);
                            string[] BankAccountNoArray = GetStringArray("银行账号", table, i);
                            string[] BelongTeamArray = GetStringArray("所属部门", table, i);
                            string[] OneCardNumberArray = GetStringArray("银行卡号", table, i);
                            string[] ChargeForManArray = GetStringArray("代扣对象", table, i);
                            string[] RelationPropertyDescArray = GetStringArray("住户类别", table, i);
                            string[] CompanyNameArray = GetStringArray("公司名称", table, i);
                            string[] RoomPhoneRelationRemarkArray = GetStringArray("客户备注", table, i);
                            string[] RelateCustomOneArray = new string[] { };
                            string[] RelateCustomTwoArray = new string[] { };
                            string[] RelateCustomThreeArray = new string[] { };
                            string[] RelateCustomFourArray = new string[] { };
                            string[] RelateInterestingArray = new string[] { };
                            string[] RelateConsumeMoreArray = new string[] { };
                            if (GetColumnValue(comm_helper.GetExistColumns(TableName_Relation, "CustomOne"), table, i, out Value))
                            {
                                RelateCustomOneArray = GetStringArrayByValue(Value);
                            }
                            if (GetColumnValue(comm_helper.GetExistColumns(TableName_Relation, "CustomTwo"), table, i, out Value))
                            {
                                RelateCustomTwoArray = GetStringArrayByValue(Value);
                            }
                            if (GetColumnValue(comm_helper.GetExistColumns(TableName_Relation, "CustomThree"), table, i, out Value))
                            {
                                RelateCustomThreeArray = GetStringArrayByValue(Value);
                            }
                            if (GetColumnValue(comm_helper.GetExistColumns(TableName_Relation, "CustomFour"), table, i, out Value))
                            {
                                RelateCustomFourArray = GetStringArrayByValue(Value);
                            }
                            if (GetColumnValue(comm_helper.GetExistColumns(TableName_Relation, "Interesting"), table, i, out Value))
                            {
                                RelateInterestingArray = GetStringArrayByValue(Value);
                            }
                            if (GetColumnValue(comm_helper.GetExistColumns(TableName_Relation, "ConsumeMore"), table, i, out Value))
                            {
                                RelateConsumeMoreArray = GetStringArrayByValue(Value);
                            }
                            var myPhoneList = phoneList.Where(p => p.RoomID == project.ID).OrderByDescending(p => p.IsDefault).ThenBy(p => p.ID).ToArray();
                            for (int j = 0; j < CustomerNameArray.Length; j++)
                            {
                                string CustomerName = CustomerNameArray[j];
                                RoomPhoneRelation myPhoneRelation = null;
                                if (myPhoneList.Length > 0 && j < myPhoneList.Length)
                                {
                                    myPhoneRelation = myPhoneList[j];
                                }
                                if (myPhoneRelation == null)
                                {
                                    myPhoneRelation = new RoomPhoneRelation();
                                    myPhoneRelation.AddTime = DateTime.Now.AddMilliseconds(10);
                                    myPhoneRelation.RoomID = project.ID;
                                }
                                myPhoneRelation.RelationName = CustomerName;
                                myPhoneRelation.IsDefault = false;
                                myPhoneRelation.IsChargeFee = true;
                                myPhoneRelation.IsChargeMan = true;
                                if (j == 0)
                                {
                                    myPhoneRelation.IsDefault = true;
                                }
                                if (RelationTypeDescArray.Length > 0)
                                {
                                    string RelationTypeDesc = GetStrFromArray(RelationTypeDescArray, j);
                                    if (RelationTypeDesc.Equals("业主"))
                                    {
                                        myPhoneRelation.RelationType = RelationTypeDefine.homefamily.ToString();
                                    }
                                    else if (RelationTypeDesc.Equals("租户"))
                                    {
                                        myPhoneRelation.RelationType = RelationTypeDefine.rentfamily.ToString();
                                    }
                                }
                                if (RelatePhoneNumberArray.Length > 0)
                                {
                                    string RelatePhoneNumber = GetStrFromArray(RelatePhoneNumberArray, j);
                                    myPhoneRelation.RelatePhoneNumber = RelatePhoneNumber;
                                }
                                if (IDCardTypeDescArray.Length > 0)
                                {
                                    string IDCardTypeDesc = GetStrFromArray(IDCardTypeDescArray, j);
                                    myPhoneRelation.IDCardType = ViewRoomBasic.GetIDCardType(IDCardTypeDesc);
                                }
                                if (RelationIDCardArray.Length > 0)
                                {
                                    string RelationIDCard = GetStrFromArray(RelationIDCardArray, j);
                                    myPhoneRelation.RelationIDCard = RelationIDCard;
                                }
                                if (BirthdayArray.Length > 0)
                                {
                                    string BirthdayStr = GetStrFromArray(BirthdayArray, j);
                                    if (!string.IsNullOrEmpty(BirthdayStr))
                                    {
                                        DateTime Birthday = DateTime.MinValue;
                                        DateTime.TryParse(BirthdayStr, out Birthday);
                                        myPhoneRelation.Birthday = Birthday;
                                    }
                                }
                                if (EmailAddressArray.Length > 0)
                                {
                                    string EmailAddress = GetStrFromArray(EmailAddressArray, j);
                                    myPhoneRelation.EmailAddress = EmailAddress;
                                }
                                if (HomeAddressArray.Length > 0)
                                {
                                    string HomeAddress = GetStrFromArray(HomeAddressArray, j);
                                    myPhoneRelation.HomeAddress = HomeAddress;
                                }
                                if (OfficeAddressArray.Length > 0)
                                {
                                    string OfficeAddress = GetStrFromArray(OfficeAddressArray, j);
                                    myPhoneRelation.OfficeAddress = OfficeAddress;
                                }
                                if (BankAccountNameArray.Length > 0)
                                {
                                    string BankAccountName = GetStrFromArray(BankAccountNameArray, j);
                                    myPhoneRelation.BankAccountName = BankAccountName;
                                }
                                if (BankAccountNoArray.Length > 0)
                                {
                                    string BankAccountNo = GetStrFromArray(BankAccountNoArray, j);
                                    myPhoneRelation.BankAccountNo = BankAccountNo;
                                }
                                if (BelongTeamArray.Length > 0)
                                {
                                    string BelongTeam = GetStrFromArray(BelongTeamArray, j);
                                    myPhoneRelation.BelongTeam = BelongTeam;
                                }
                                if (OneCardNumberArray.Length > 0)
                                {
                                    string OneCardNumber = GetStrFromArray(OneCardNumberArray, j);
                                    myPhoneRelation.OneCardNumber = OneCardNumber;
                                }
                                if (ChargeForManArray.Length > 0)
                                {
                                    string ChargeForMan = GetStrFromArray(ChargeForManArray, j);
                                    myPhoneRelation.ChargeForMan = ChargeForMan;
                                }
                                if (RelationPropertyDescArray.Length > 0)
                                {
                                    string RelationPropertyDesc = GetStrFromArray(RelationPropertyDescArray, j);
                                    if (RelationPropertyDesc.Equals("个人"))
                                    {
                                        myPhoneRelation.RelationProperty = Foresight.DataAccess.RelationPropertyDefine.geren.ToString();
                                    }
                                    if (RelationPropertyDesc.Equals("公司"))
                                    {
                                        myPhoneRelation.RelationProperty = Foresight.DataAccess.RelationPropertyDefine.gongsi.ToString();
                                    }
                                }
                                if (CompanyNameArray.Length > 0)
                                {
                                    string CompanyName = GetStrFromArray(CompanyNameArray, j);
                                    myPhoneRelation.CompanyName = CompanyName;
                                }
                                if (RoomPhoneRelationRemarkArray.Length > 0)
                                {
                                    string RoomPhoneRelationRemark = GetStrFromArray(RoomPhoneRelationRemarkArray, j);
                                    myPhoneRelation.Remark = RoomPhoneRelationRemark;
                                }
                                if (RelateCustomOneArray.Length > 0)
                                {
                                    string RelateCustomOne = GetStrFromArray(RelateCustomOneArray, j);
                                    myPhoneRelation.CustomOne = RelateCustomOne;
                                }
                                if (RelateCustomTwoArray.Length > 0)
                                {
                                    string RelateCustomTwo = GetStrFromArray(RelateCustomTwoArray, j);
                                    myPhoneRelation.CustomTwo = RelateCustomTwo;
                                }
                                if (RelateCustomThreeArray.Length > 0)
                                {
                                    string RelateCustomThree = GetStrFromArray(RelateCustomThreeArray, j);
                                    myPhoneRelation.CustomThree = RelateCustomThree;
                                }
                                if (RelateCustomFourArray.Length > 0)
                                {
                                    string RelateCustomFour = GetStrFromArray(RelateCustomFourArray, j);
                                    myPhoneRelation.CustomFour = RelateCustomFour;
                                }
                                if (RelateInterestingArray.Length > 0)
                                {
                                    string RelateInteresting = GetStrFromArray(RelateInterestingArray, j);
                                    myPhoneRelation.Interesting = RelateInteresting;
                                }
                                if (RelateConsumeMoreArray.Length > 0)
                                {
                                    string RelateConsumeMore = GetStrFromArray(RelateConsumeMoreArray, j);
                                    myPhoneRelation.ConsumeMore = RelateConsumeMore;
                                }
                                myPhoneRelation.Save(helper);
                            }
                            //if (GetColumnValue("合同开始日期", table, i, out Value))
                            //{
                            //    roomrelation.ContractStartTime = GetDateTimeValue(Value);
                            //}
                            //if (GetColumnValue("合同结束日期", table, i, out Value))
                            //{
                            //    roomrelation.ContractEndTime = GetDateTimeValue(Value);
                            //}
                        }
                        basic.Save(helper);
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
                    LogHelper.WriteError("ImportSourceHandler", "visit: importroomsource", ex);
                    msg = "第" + (count + 2) + "行数据有问题，导入取消";
                    helper.Rollback();
                }
                context.Response.Write(msg);
            }
        }
        private string[] GetStringArray(string ColumName, DataTable table, int i)
        {
            object Value = null;
            if (GetColumnValue(ColumName, table, i, out Value))
            {
                return GetStringArrayByValue(Value);
            }
            return new string[] { };
        }
        private string[] GetStringArrayByValue(object Value)
        {
            if (Value == null)
            {
                return new string[] { };
            }
            if (string.IsNullOrEmpty(Value.ToString().Trim()))
            {
                return new string[] { };
            }
            return Value.ToString().Trim().Replace("，", ",").Split(',').ToArray();
        }
        private string GetStrFromArray(string[] arrayList, int j)
        {
            if (arrayList.Length > 0)
            {
                string Value = arrayList[arrayList.Length - 1];
                if (j < arrayList.Length)
                {
                    Value = arrayList[j];
                }
                return Value;
            }
            return string.Empty;
        }
        private void AddRoomRelation(int RoomID, string guid, SqlHelper helper)
        {
            RoomRelation roomRelation = new RoomRelation();
            roomRelation.RoomID = RoomID;
            roomRelation.GUID = guid;
            roomRelation.Save(helper);
        }
        private int CheckRoomProperty(string desc)
        {
            int state = 0;
            switch (desc)
            {
                case "回迁户":
                    state = 1;
                    break;
                case "五保户":
                    state = 2;
                    break;
                case "军烈属":
                    state = 3;
                    break;
                case "员工":
                    state = 4;
                    break;
                default:
                    break;
            }
            return state;
        }
        private int CheckRoomState(string desc)
        {
            int state = 0;
            switch (desc)
            {
                case "自住":
                    state = 1;
                    break;
                case "已租":
                    state = 2;
                    break;
                case "招租":
                    state = 3;
                    break;
                case "未售":
                    state = 4;
                    break;
                default:
                    break;
            }
            return state;
        }
        private bool CheckExistRoomResource(string TotalName, int CompanyID, SqlHelper helper, out Project project)
        {
            project = null;
            try
            {
                if (string.IsNullOrEmpty(TotalName))
                {
                    return true;
                }
                string[] NameArry = TotalName.Split('|');
                if (NameArry.Length < 2)
                {
                    return false;
                }
                string RoomName = NameArry[1];
                string FullName = NameArry[0];
                project = Project.GetProjectByFullName(RoomName, FullName, CompanyID, helper);
                if (project != null)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        private List<Dictionary<string, object>> GetTableColumns()
        {
            string TableName = Utility.EnumModel.DefineFieldTableName.RoomBasic.ToString();
            var list = Foresight.DataAccess.TableColumn.GetTableColumnByPageCode("roomsource", true).Where(p => !p.ColumnName.Equals("选择按钮")).ToArray();
            var all_fieldlist = Foresight.DataAccess.DefineField.GetDefineFieldsByTable_Name(TableName, 0);
            var results = list.Select(p =>
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
                return dic;
            }).ToList();
            var fieldlist = all_fieldlist.Where(p => p.IsShown && string.IsNullOrEmpty(p.ColumnName));
            foreach (var item in fieldlist)
            {
                var dic = new Dictionary<string, object>();
                dic["ID"] = 0;
                dic["FieldID"] = item.ID;
                dic["PageCode"] = "roomsource";
                dic["ColumnField"] = "field: '" + item.FieldName + "', title: '" + item.FieldName + "', width: 150";
                dic["SortOrder"] = item.SortOrder < 0 ? 0 : item.SortOrder;
                dic["IsShown"] = item.IsShown;
                dic["ColumnName"] = item.FieldName;
                results.Add(dic);
            }
            results = results.OrderBy(p => p["SortOrder"]).ToList();
            return results;
        }
        private List<Dictionary<string, object>> GetTableColumns(string PageCode)
        {
            var list = Foresight.DataAccess.TableColumn.GetTableColumnByPageCode(PageCode, true).Where(p => !p.ColumnName.Equals("选择按钮")).ToArray();
            var results = new List<Dictionary<string, object>>();
            foreach (var item in list)
            {
                var dic = new Dictionary<string, object>();
                dic["ID"] = 0;
                dic["FieldID"] = item.ID;
                dic["PageCode"] = PageCode;
                dic["ColumnField"] = item.ColumnField;
                dic["SortOrder"] = item.SortOrder < 0 ? 0 : item.SortOrder;
                dic["IsShown"] = item.IsShown;
                dic["ColumnName"] = item.ColumnName;
                results.Add(dic);
            }
            results = results.OrderBy(p => p["SortOrder"]).ToList();
            return results;
        }
        private int GetIDCardType(string idcardtype)
        {
            int typeid = 0;
            switch (idcardtype)
            {
                case "身份证":
                    typeid = 1;
                    break;
                case "护照":
                    typeid = 2;
                    break;
                case "军人证":
                    typeid = 3;
                    break;
                case "驾驶证":
                    typeid = 4;
                    break;
                case "其他":
                    typeid = 5;
                    break;
                default:
                    break;
            }
            return typeid;
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