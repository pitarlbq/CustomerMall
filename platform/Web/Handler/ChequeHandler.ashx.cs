using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using Utility;
using Foresight.DataAccess.Framework;
using Foresight.DataAccess.Ui;
using Utility;

namespace Web.Handler
{
    /// <summary>
    /// UserHandler 的摘要说明
    /// </summary>
    public class ChequeHandler : IHttpHandler, IRequiresSessionState
    {
        const string LogModule = "ChequeHandler";
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
                    case "gettree":
                        gettree(context);
                        break;
                    case "savechequeseller":
                        savechequeseller(context);
                        break;
                    case "savechequeproduct":
                        savechequeproduct(context);
                        break;
                    case "savechequedepartment":
                        savechequedepartment(context);
                        break;
                    case "savechequeproject":
                        savechequeproject(context);
                        break;
                    case "savechequebuyer":
                        savechequebuyer(context);
                        break;
                    case "removenode":
                        removenode(context);
                        break;
                    case "savechequeinproduct":
                        savechequeinproduct(context);
                        break;
                    case "getproductlist":
                        getproductlist(context);
                        break;
                    case "loadinproductdetailgrid":
                        loadinproductdetailgrid(context);
                        break;
                    case "removechequeindetail":
                        removechequeindetail(context);
                        break;
                    case "getindetailparams":
                        getindetailparams(context);
                        break;
                    case "savechequein":
                        savechequein(context);
                        break;
                    case "getcomboboxbyguid":
                        getcomboboxbyguid(context);
                        break;
                    case "loadchequeingrid":
                        loadchequeingrid(context);
                        break;
                    case "savechequesign":
                        savechequesign(context);
                        break;
                    case "savechequeapprove":
                        savechequeapprove(context);
                        break;
                    case "removechequein":
                        removechequein(context);
                        break;
                    case "addtempproductlist":
                        addtempproductlist(context);
                        break;
                    case "loadchequeoutjzgrid":
                        loadchequeoutjzgrid(context);
                        break;
                    case "removechequeoutjz":
                        removechequeoutjz(context);
                        break;
                    case "getoutjzeditparams":
                        getoutjzeditparams(context);
                        break;
                    case "savechequeoutjz":
                        savechequeoutjz(context);
                        break;
                    case "removeoutjzfile":
                        removeoutjzfile(context);
                        break;
                    case "loadoutjzfiles":
                        loadoutjzfiles(context);
                        break;
                    case "loadchequestampgrid":
                        loadchequestampgrid(context);
                        break;
                    case "removechequestamp":
                        removechequestamp(context);
                        break;
                    case "getchequestampeditparams":
                        getchequestampeditparams(context);
                        break;
                    case "savechequestamp":
                        savechequestamp(context);
                        break;
                    case "savechequecontractcategory":
                        savechequecontractcategory(context);
                        break;
                    case "savechequetaxrate":
                        savechequetaxrate(context);
                        break;
                    case "loadchequetaxrategrid":
                        loadchequetaxrategrid(context);
                        break;
                    case "removechequetaxrate":
                        removechequetaxrate(context);
                        break;
                    case "loadchequecontractcategorygrid":
                        loadchequecontractcategorygrid(context);
                        break;
                    case "removechequecontractcategory":
                        removechequecontractcategory(context);
                        break;
                    case "loadchequeoutgrid":
                        loadchequeoutgrid(context);
                        break;
                    case "removechequeout":
                        removechequeout(context);
                        break;
                    case "addtempoutproductlist":
                        addtempoutproductlist(context);
                        break;
                    case "getoutdetailparams":
                        getoutdetailparams(context);
                        break;
                    case "loadoutproductdetailgrid":
                        loadoutproductdetailgrid(context);
                        break;
                    case "removechequeoutdetail":
                        removechequeoutdetail(context);
                        break;
                    case "savechequeout":
                        savechequeout(context);
                        break;
                    case "savechequeoutsign":
                        savechequeoutsign(context);
                        break;
                    case "savechequeoutapprove":
                        savechequeoutapprove(context);
                        break;
                    case "savechequeoutproduct":
                        savechequeoutproduct(context);
                        break;
                    case "loadoutingservicegrid":
                        loadoutingservicegrid(context);
                        break;
                    case "removechequeoutingservice":
                        removechequeoutingservice(context);
                        break;
                    case "savechequeoutingservice":
                        savechequeoutingservice(context);
                        break;
                    case "loadoutingproductgrid":
                        loadoutingproductgrid(context);
                        break;
                    case "removechequeoutingproduct":
                        removechequeoutingproduct(context);
                        break;
                    case "savechequeoutingproduct":
                        savechequeoutingproduct(context);
                        break;
                    case "savechequeoutwritecheque":
                        savechequeoutwritecheque(context);
                        break;
                    case "loadchequecheckgrid":
                        loadchequecheckgrid(context);
                        break;
                    case "savechequechecktake":
                        savechequechecktake(context);
                        break;
                    case "savechequechecktransfer":
                        savechequechecktransfer(context);
                        break;
                    case "savechequecheckapprove":
                        savechequecheckapprove(context);
                        break;
                    case "getlatestcheckinsummary":
                        getlatestcheckinsummary(context);
                        break;
                    case "getlatestcheckoutsummary":
                        getlatestcheckoutsummary(context);
                        break;
                    case "loadinsummaryfiles":
                        loadinsummaryfiles(context);
                        break;
                    case "removeinsummaryfile":
                        removeinsummaryfile(context);
                        break;
                    case "loadoutsummaryfiles":
                        loadoutsummaryfiles(context);
                        break;
                    case "removeoutsummaryfile":
                        removeoutsummaryfile(context);
                        break;
                    case "loadchequeinoutanalysis":
                        loadchequeinoutanalysis(context);
                        break;
                    case "getinsummarycost":
                        getinsummarycost(context);
                        break;
                    default:
                        WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "Unkown Visit: " + visit);
                        break;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(LogModule, "命令:" + visit, ex);
                context.Response.Write("{\"status\":false}");
            }
        }
        private void getinsummarycost(HttpContext context)
        {
            decimal TotalInCost = 0;
            decimal ConfirmCost = 0;
            decimal NoConfirmCost = 0;
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    DateTime StartTime = DateTime.Now.AddMonths(-3);
                    DateTime EndTime = DateTime.Now;
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    parameters.Add(new SqlParameter("@StartTime", StartTime));
                    parameters.Add(new SqlParameter("@EndTime", EndTime));
                    string cmdwhere = " and InSummaryID in (select ID from [Cheque_InSummary] where [ChequeTime]>=@StartTime and  [ChequeTime]<=@EndTime)";
                    string cmdtext = "select sum(TotalSummaryCost) from Cheque_InDetail where 1=1 " + cmdwhere;
                    var obj = helper.ExecuteScalar(cmdtext, CommandType.Text, parameters);
                    if (obj != null)
                    {
                        decimal.TryParse(obj.ToString(), out TotalInCost);
                    }
                    cmdtext = "select sum(TotalSummaryCost) from Cheque_InDetail where InSummaryID in (select SummaryID from Cheque_Confirm)" + cmdwhere;
                    obj = helper.ExecuteScalar(cmdtext, CommandType.Text, parameters);
                    if (obj != null)
                    {
                        decimal.TryParse(obj.ToString(), out ConfirmCost);
                    }
                    NoConfirmCost = TotalInCost - ConfirmCost;
                }
                catch (Exception ex)
                {
                    LogHelper.WriteError(LogModule, "getinsummarycost", ex);
                }
            }
            WebUtil.WriteJson(context, new { status = true, TotalInCost = TotalInCost, ConfirmCost = ConfirmCost, NoConfirmCost = NoConfirmCost });
        }
        private void loadchequeinoutanalysis(HttpContext context)
        {
            try
            {
                int SearchType = WebUtil.GetIntValue(context, "SearchType");
                DateTime StartTime = WebUtil.GetDateValue(context, "StartTime");
                DateTime EndTime = WebUtil.GetDateValue(context, "EndTime");
                var list = Foresight.DataAccess.Cheque_InOutAnalysis.GetCheque_InOutAnalysisList(StartTime, EndTime, SearchType);
                var dg = new DataGrid();
                dg.rows = list;
                dg.total = list.Length;
                dg.page = 1;
                var footerlist = new List<Foresight.DataAccess.Cheque_InOutAnalysis>();
                var footer = new Foresight.DataAccess.Cheque_InOutAnalysis();
                footer.Name = "合计";
                footer.TaxRate = list.Sum(p => p.TaxRate > 0 ? p.TaxRate : 0);
                footer.TotalCount = list.Sum(p => p.TotalCount > 0 ? p.TotalCount : 0);
                footer.TotalCost = list.Sum(p => p.TotalCost > 0 ? p.TotalCost : 0);
                footer.TotalTaxCost = list.Sum(p => p.TotalTaxCost > 0 ? p.TotalTaxCost : 0);
                footer.TotalSumCost = list.Sum(p => p.TotalSumCost > 0 ? p.TotalSumCost : 0);
                footerlist.Add(footer);
                dg.footer = footerlist;
                WebUtil.WriteJson(context, dg);
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(LogModule, "命令: loadchequecheckgrid", ex);
                context.Response.Write("{\"rows\":[],\"total\":0,\"page\":0}");
            }
        }
        private void removeoutsummaryfile(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            if (ID > 0)
            {
                using (SqlHelper helper = new SqlHelper())
                {
                    try
                    {
                        helper.BeginTransaction();
                        string cmdtext = "delete from [Cheque_OutSummaryFile] where [ID]=@ID;";
                        List<SqlParameter> parameters = new List<SqlParameter>();
                        parameters.Add(new SqlParameter("@ID", ID));
                        helper.Execute(cmdtext, CommandType.Text, parameters);
                        helper.Commit();
                    }
                    catch (Exception ex)
                    {
                        helper.Rollback();
                        LogHelper.WriteError(LogModule, "命令: removeinsummaryfile", ex);
                        WebUtil.WriteJson(context, new { status = false });
                        return;
                    }
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void loadoutsummaryfiles(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            Foresight.DataAccess.Cheque_OutSummaryFile[] files = Foresight.DataAccess.Cheque_OutSummaryFile.GetCheque_OutSummaryFileList(ID);
            WebUtil.WriteJson(context, files);
        }
        private void removeinsummaryfile(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            if (ID > 0)
            {
                using (SqlHelper helper = new SqlHelper())
                {
                    try
                    {
                        helper.BeginTransaction();
                        string cmdtext = "delete from [Cheque_InSummaryFile] where [ID]=@ID;";
                        List<SqlParameter> parameters = new List<SqlParameter>();
                        parameters.Add(new SqlParameter("@ID", ID));
                        helper.Execute(cmdtext, CommandType.Text, parameters);
                        helper.Commit();
                    }
                    catch (Exception ex)
                    {
                        helper.Rollback();
                        LogHelper.WriteError(LogModule, "命令: removeinsummaryfile", ex);
                        WebUtil.WriteJson(context, new { status = false });
                        return;
                    }
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void loadinsummaryfiles(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            Foresight.DataAccess.Cheque_InSummaryFile[] files = Foresight.DataAccess.Cheque_InSummaryFile.GetCheque_InSummaryFileList(ID);
            WebUtil.WriteJson(context, files);
        }
        private void getlatestcheckoutsummary(HttpContext context)
        {
            var summary = Foresight.DataAccess.Cheque_OutSummary.GetLastCheque_OutSummary();
            if (summary != null)
            {
                WebUtil.WriteJson(context, new { status = true, summary = summary });
            }
            else
            {
                WebUtil.WriteJson(context, new { status = false });
            }
        }
        private void getlatestcheckinsummary(HttpContext context)
        {
            var summary = Foresight.DataAccess.Cheque_InSummary.GetLastCheque_InSummary();
            if (summary != null)
            {
                WebUtil.WriteJson(context, new { status = true, summary = summary });
            }
            else
            {
                WebUtil.WriteJson(context, new { status = false });
            }
        }
        private void savechequecheckapprove(HttpContext context)
        {
            Foresight.DataAccess.Cheque_Confirm data = null;
            int ID = WebUtil.GetIntValue(context, "ID");
            int InSummaryID = WebUtil.GetIntValue(context, "InSummaryID");
            if (ID > 0)
            {
                data = Foresight.DataAccess.Cheque_Confirm.GetCheque_Confirm(ID);
            }
            if (data == null)
            {
                data = Foresight.DataAccess.Cheque_Confirm.GetCheque_ConfirmByInSummaryID(InSummaryID);
            }
            if (data == null)
            {
                data = new Foresight.DataAccess.Cheque_Confirm();
                data.SummaryID = InSummaryID;
                data.AddTime = DateTime.Now;
            }
            data.ApproveTime = WebUtil.GetDateValue(context, "ApproveTime");
            data.ApproveMan = context.Request["ApproveMan"];
            data.ApproveMethod = context.Request["ApproveMethod"];
            data.ApproveMonth = context.Request["ApproveMonth"];
            data.ApproveRemark = context.Request["ApproveRemark"];
            data.ApproveStatus = 1;
            data.Save();
            WebUtil.WriteJson(context, new { status = true });
        }
        private void savechequechecktransfer(HttpContext context)
        {
            Foresight.DataAccess.Cheque_Confirm data = null;
            int ID = WebUtil.GetIntValue(context, "ID");
            int InSummaryID = WebUtil.GetIntValue(context, "InSummaryID");
            if (ID > 0)
            {
                data = Foresight.DataAccess.Cheque_Confirm.GetCheque_Confirm(ID);
            }
            if (data == null)
            {
                data = Foresight.DataAccess.Cheque_Confirm.GetCheque_ConfirmByInSummaryID(InSummaryID);
            }
            if (data == null)
            {
                data = new Foresight.DataAccess.Cheque_Confirm();
                data.SummaryID = InSummaryID;
                data.AddTime = DateTime.Now;
            }
            data.TransferTime = WebUtil.GetDateValue(context, "TransferTime");
            data.TransferMan = context.Request["TransferMan"];
            data.TransferRemark = context.Request["TransferRemark"];
            data.TransferMoney = WebUtil.GetDecimalValue(context, "TransferMoney");
            data.TransferStatus = 1;
            data.Save();
            WebUtil.WriteJson(context, new { status = true });
        }
        private void savechequechecktake(HttpContext context)
        {
            Foresight.DataAccess.Cheque_Confirm data = null;
            int ID = WebUtil.GetIntValue(context, "ID");
            int InSummaryID = WebUtil.GetIntValue(context, "InSummaryID");
            if (ID > 0)
            {
                data = Foresight.DataAccess.Cheque_Confirm.GetCheque_Confirm(ID);
            }
            if (data == null)
            {
                data = Foresight.DataAccess.Cheque_Confirm.GetCheque_ConfirmByInSummaryID(InSummaryID);
            }
            if (data == null)
            {
                data = new Foresight.DataAccess.Cheque_Confirm();
                data.SummaryID = InSummaryID;
                data.AddTime = DateTime.Now;
            }
            data.TakeTime = WebUtil.GetDateValue(context, "TakeTime");
            data.TakeUser = context.Request["TakeUser"];
            data.TakeRemark = context.Request["TakeRemark"];
            data.TakeStatus = 1;
            data.Save();
            WebUtil.WriteJson(context, new { status = true });
        }
        private void loadchequecheckgrid(HttpContext context)
        {
            try
            {
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                string keywords = context.Request["keywords"];
                string sellerlist = context.Request["sellerlist"];
                List<int> SellerList = JsonConvert.DeserializeObject<List<int>>(sellerlist);
                string productlist = context.Request["productlist"];
                List<int> ProductList = JsonConvert.DeserializeObject<List<int>>(productlist);
                string departmentlist = context.Request["departmentlist"];
                List<int> DepartmentList = JsonConvert.DeserializeObject<List<int>>(departmentlist);
                string projectlist = context.Request["projectlist"];
                List<int> ProjectList = JsonConvert.DeserializeObject<List<int>>(projectlist);
                int TakeStatus = WebUtil.GetIntValue(context, "TakeStatus");
                int ApproveStatus = WebUtil.GetIntValue(context, "ApproveStatus");
                int TransferStatus = WebUtil.GetIntValue(context, "TransferStatus");
                DataGrid dg = Foresight.DataAccess.ViewChequeConfirm.GetViewChequeConfirmGridByKeywords(keywords, TakeStatus, ApproveStatus, TransferStatus, SellerList, ProductList, DepartmentList, ProjectList, "order by ID desc,[InSummaryID] desc", startRowIndex, pageSize);
                WebUtil.WriteJson(context, dg);
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(LogModule, "命令: loadchequecheckgrid", ex);
                context.Response.Write("{\"rows\":[],\"total\":0,\"page\":0}");
            }
        }
        private void savechequeoutwritecheque(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            var summary = Foresight.DataAccess.Cheque_OutSummary.GetCheque_OutSummary(ID);
            if (summary != null)
            {
                summary.ChequeCode = context.Request["ChequeCode"];
                summary.ChequeNumber = context.Request["ChequeNumber"];
                summary.WriteMan = context.Request["WriteMan"];
                summary.ChequeTime = WebUtil.GetDateValue(context, "ChequeTime");
                summary.Save();
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void savechequeoutingproduct(HttpContext context)
        {
            Foresight.DataAccess.Cheque_OutingProduct data = null;
            int ID = WebUtil.GetIntValue(context, "ID");
            if (ID > 0)
            {
                data = Foresight.DataAccess.Cheque_OutingProduct.GetCheque_OutingProduct(ID);
            }
            if (data == null)
            {
                data = new Foresight.DataAccess.Cheque_OutingProduct();
                data.OutingID = WebUtil.GetIntValue(context, "OutingID");
                data.GUID = context.Request["guid"];
            }
            data.ProductName = context.Request["ProductName"];
            data.SellerAddress = context.Request["SellerAddress"];
            data.ProductStartTime = WebUtil.GetDateValue(context, "ProductStartTime");
            data.ProductEndTime = WebUtil.GetDateValue(context, "ProductEndTime");
            data.ProductTotalCost = WebUtil.GetDecimalValue(context, "ProductTotalCost");
            data.TotalCount = WebUtil.GetIntValue(context, "TotalCount");
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    data.Save(helper);
                    helper.Commit();
                    WebUtil.WriteJson(context, new { status = true });
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError(LogModule, "命令: savechequeoutingproduct", ex);
                    WebUtil.WriteJson(context, new { status = false });
                }
            }
        }
        private void removechequeoutingproduct(HttpContext context)
        {
            string ids = context.Request["IDList"];
            List<int> IDlist = JsonConvert.DeserializeObject<List<int>>(ids);
            if (IDlist.Count > 0)
            {
                using (SqlHelper helper = new SqlHelper())
                {
                    try
                    {
                        helper.BeginTransaction();
                        string cmdtext = "delete from [Cheque_OutingProduct] where [ID] in (" + string.Join(",", IDlist) + ")";
                        helper.Execute(cmdtext, CommandType.Text, new List<SqlParameter>());
                        helper.Commit();
                    }
                    catch (Exception ex)
                    {
                        helper.Rollback();
                        LogHelper.WriteError(LogModule, "命令: removechequeoutingproduct", ex);
                        WebUtil.WriteJson(context, new { status = false });
                        return;
                    }
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void loadoutingproductgrid(HttpContext context)
        {
            try
            {
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                int OutingID = WebUtil.GetIntValue(context, "OutingID");
                string guid = context.Request["guid"];
                DataGrid dg = Foresight.DataAccess.Cheque_OutingProduct.GetCheque_OutingProductGridByKeywords(OutingID, guid, "order by ID desc", startRowIndex, pageSize);
                WebUtil.WriteJson(context, dg);
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(LogModule, "命令: loadoutingproductgrid", ex);
                context.Response.Write("{\"rows\":[],\"total\":0,\"page\":0}");
            }
        }
        private void savechequeoutingservice(HttpContext context)
        {
            Foresight.DataAccess.Cheque_OutingService _cheque_OutingService = null;
            int ID = WebUtil.GetIntValue(context, "ID");
            if (ID > 0)
            {
                _cheque_OutingService = Foresight.DataAccess.Cheque_OutingService.GetCheque_OutingService(ID);
            }
            if (_cheque_OutingService == null)
            {
                _cheque_OutingService = new Foresight.DataAccess.Cheque_OutingService();
                _cheque_OutingService.OutingID = WebUtil.GetIntValue(context, "OutingID");
                _cheque_OutingService.GUID = context.Request["guid"];
            }
            _cheque_OutingService.ServiceName = context.Request["ServiceName"];
            _cheque_OutingService.ServiceAddress = context.Request["ServiceAddress"];
            _cheque_OutingService.ServiceStartTime = WebUtil.GetDateValue(context, "ServiceStartTime");
            _cheque_OutingService.ServiceEndTime = WebUtil.GetDateValue(context, "ServiceEndTime");
            _cheque_OutingService.ContractMoney = WebUtil.GetDecimalValue(context, "ContractMoney");
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    _cheque_OutingService.Save(helper);
                    helper.Commit();
                    WebUtil.WriteJson(context, new { status = true });
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError(LogModule, "命令: savechequeoutingservice", ex);
                    WebUtil.WriteJson(context, new { status = false });
                }
            }
        }
        private void removechequeoutingservice(HttpContext context)
        {
            string ids = context.Request["IDList"];
            List<int> IDlist = JsonConvert.DeserializeObject<List<int>>(ids);
            if (IDlist.Count > 0)
            {
                using (SqlHelper helper = new SqlHelper())
                {
                    try
                    {
                        helper.BeginTransaction();
                        string cmdtext = "delete from [Cheque_OutingService] where [ID] in (" + string.Join(",", IDlist) + ")";
                        helper.Execute(cmdtext, CommandType.Text, new List<SqlParameter>());
                        helper.Commit();
                    }
                    catch (Exception ex)
                    {
                        helper.Rollback();
                        LogHelper.WriteError(LogModule, "命令: removechequeoutingservice", ex);
                        WebUtil.WriteJson(context, new { status = false });
                        return;
                    }
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void loadoutingservicegrid(HttpContext context)
        {
            try
            {
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                int OutingID = WebUtil.GetIntValue(context, "OutingID");
                string guid = context.Request["guid"];
                DataGrid dg = Foresight.DataAccess.Cheque_OutingService.GetCheque_OutingServiceGridByKeywords(OutingID, guid, "order by ID desc", startRowIndex, pageSize);
                WebUtil.WriteJson(context, dg);
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(LogModule, "命令: loadoutingservicegrid", ex);
                context.Response.Write("{\"rows\":[],\"total\":0,\"page\":0}");
            }
        }
        private void savechequeoutproduct(HttpContext context)
        {
            int ProductID = WebUtil.GetIntValue(context, "ProductID");
            Foresight.DataAccess.Cheque_OutDetail _cheque_OutDetail = null;
            int ID = WebUtil.GetIntValue(context, "ID");
            if (ID > 0)
            {
                _cheque_OutDetail = Foresight.DataAccess.Cheque_OutDetail.GetCheque_OutDetail(ID);
            }
            if (_cheque_OutDetail == null)
            {
                _cheque_OutDetail = new Foresight.DataAccess.Cheque_OutDetail();
                _cheque_OutDetail.OutSummaryID = WebUtil.GetIntValue(context, "OutSummaryID");
                _cheque_OutDetail.GUID = context.Request["guid"];
            }
            var product = Foresight.DataAccess.Cheque_Product.GetCheque_Product(ProductID);
            if (product == null)
            {
                product = new Foresight.DataAccess.Cheque_Product();
                product.AddTime = DateTime.Now;
            }
            product.ProductName = context.Request["ProductName"];
            product.ModelNumber = context.Request["ModelNumber"];
            product.Unit = context.Request["Unit"];
            product.UnitPrice = WebUtil.GetDecimalValue(context, "UnitPrice");
            _cheque_OutDetail.ProductName = context.Request["ProductName"];
            _cheque_OutDetail.ModelNumber = context.Request["ModelNumber"];
            _cheque_OutDetail.Unit = context.Request["Unit"];
            _cheque_OutDetail.UnitPrice = WebUtil.GetDecimalValue(context, "UnitPrice");
            _cheque_OutDetail.TotalCount = WebUtil.GetIntValue(context, "TotalCount");
            _cheque_OutDetail.TotalCost = _cheque_OutDetail.TotalCount * _cheque_OutDetail.UnitPrice;
            _cheque_OutDetail.TaxRate = context.Request["TaxRate"];
            decimal TaxRate = WebUtil.GetDecimalValue(context, "TaxRate");
            _cheque_OutDetail.TotalTaxCost = Math.Round((_cheque_OutDetail.TotalCost * TaxRate / 100), 2);
            _cheque_OutDetail.TotalSummaryCost = _cheque_OutDetail.TotalTaxCost + _cheque_OutDetail.TotalCost;
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    product.Save(helper);
                    _cheque_OutDetail.ProductID = product.ID;
                    _cheque_OutDetail.Save(helper);
                    helper.Commit();
                    WebUtil.WriteJson(context, new { status = true });
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError(LogModule, "命令: savechequeoutproduct", ex);
                    WebUtil.WriteJson(context, new { status = false });
                }
            }
        }
        private void savechequeoutapprove(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            var summary = Foresight.DataAccess.Cheque_OutSummary.GetCheque_OutSummary(ID);
            if (summary != null)
            {
                summary.ApproveOperator = context.Request["ApproveOperator"];
                summary.ApporveTime = WebUtil.GetDateValue(context, "ApporveTime");
                summary.ApproveRemark = context.Request["ApproveRemark"];
                summary.ApproveState = 1;
                summary.Save();
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void savechequeoutsign(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            var summary = Foresight.DataAccess.Cheque_OutSummary.GetCheque_OutSummary(ID);
            if (summary != null)
            {
                summary.SignOperator = context.Request["SignOperator"];
                summary.SignTime = WebUtil.GetDateValue(context, "SignTime");
                summary.SignRemark = context.Request["SignRemark"];
                summary.SignState = 1;
                summary.Save();
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void savechequeout(HttpContext context)
        {
            int OutSummaryID = WebUtil.GetIntValue(context, "OutSummaryID");
            Foresight.DataAccess.Cheque_OutSummary insummary = null;
            if (OutSummaryID > 0)
            {
                insummary = Foresight.DataAccess.Cheque_OutSummary.GetCheque_OutSummary(OutSummaryID);
            }
            if (insummary == null)
            {
                insummary = new Foresight.DataAccess.Cheque_OutSummary();
                insummary.AddTime = DateTime.Now;
            }
            string guid = context.Request["guid"];
            insummary.WriteDate = WebUtil.GetDateValue(context, "WriteDate");
            insummary.WriteMan = context.Request["WriteMan"];
            insummary.DepartmentID = WebUtil.GetIntValue(context, "DepartmentID");
            insummary.ProjectID = WebUtil.GetIntValue(context, "ProjectID");
            insummary.SellerID = WebUtil.GetIntValue(context, "SellerID");
            insummary.BuyerID = WebUtil.GetIntValue(context, "BuyerID");
            insummary.ChequeNumber = context.Request["ChequeNumber"];
            insummary.ChequeTime = WebUtil.GetDateValue(context, "ChequeTime");
            insummary.ChequeCode = context.Request["ChequeCode"];
            insummary.ChequeCategory = context.Request["ChequeCategory"];

            var depeartment = Foresight.DataAccess.Cheque_Department.GetCheque_Department(insummary.DepartmentID);
            insummary.CurrentDepartmentName = depeartment != null ? depeartment.DepartmentName : "";

            var project = Foresight.DataAccess.Cheque_Project.GetCheque_Project(insummary.ProjectID);
            insummary.CurrentProjectName = project != null ? project.ProjectName : "";

            var seller = Foresight.DataAccess.Cheque_Seller.GetCheque_Seller(insummary.SellerID);
            insummary.CurrentSellerName = seller != null ? seller.SellerName : "";
            insummary.CurrentSellerTaxNumber = seller != null ? seller.SellerTaxNumber : "";
            insummary.CurrentSellerAddressPhone = seller != null ? seller.SellerAddressPhone : "";
            insummary.CurrentSellerBankAccount = seller != null ? seller.SellerBankAccount : "";

            var buyer = Foresight.DataAccess.Cheque_Buyer.GetCheque_Buyer(insummary.BuyerID);
            insummary.CurrentBuyerName = seller != null ? buyer.BuyerName : "";
            insummary.CurrentBuyerTaxNumber = seller != null ? buyer.BuyerTaxNumber : "";
            insummary.CurrentBuyerAddressPhone = seller != null ? buyer.BuyerAddressPhone : "";
            insummary.CurrentBuyerBankAccount = seller != null ? buyer.BuyerBankAccount : "";

            var detaillist = Foresight.DataAccess.Cheque_OutDetail.GetCheque_OutDetailList(OutSummaryID, guid);

            List<Foresight.DataAccess.Cheque_OutSummaryFile> attachlist = new List<Foresight.DataAccess.Cheque_OutSummaryFile>();
            HttpFileCollection uploadFiles = context.Request.Files;
            for (int i = 0; i < uploadFiles.Count; i++)
            {
                HttpPostedFile postedFile = uploadFiles[i];
                string fileOriName = postedFile.FileName;
                if (fileOriName != "" && fileOriName != null)
                {
                    string extension = System.IO.Path.GetExtension(fileOriName).ToLower();
                    string fileName = DateTime.Now.ToFileTime().ToString() + extension;
                    string filepath = "/upload/cheque/";
                    string rootPath = HttpContext.Current.Server.MapPath("~" + filepath);
                    if (!System.IO.Directory.Exists(rootPath))
                    {
                        System.IO.Directory.CreateDirectory(rootPath);
                    }
                    string Path = rootPath + fileName;
                    postedFile.SaveAs(Path);
                    Foresight.DataAccess.Cheque_OutSummaryFile attach = new Foresight.DataAccess.Cheque_OutSummaryFile();
                    attach.FileOriName = fileOriName;
                    attach.FilePath = filepath + fileName;
                    attach.AddTime = DateTime.Now;
                    attachlist.Add(attach);
                }
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    insummary.Save(helper);
                    foreach (var item in detaillist)
                    {
                        item.OutSummaryID = insummary.ID;
                        item.Save(helper);
                    }
                    foreach (var item in attachlist)
                    {
                        item.OutSummaryID = insummary.ID;
                        item.Save(helper);
                    }
                    helper.Commit();
                    WebUtil.WriteJson(context, new { status = true });
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError(LogModule, "命令: savechequeout", ex);
                    WebUtil.WriteJson(context, new { status = false });
                }
            }
        }
        private void removechequeoutdetail(HttpContext context)
        {
            string ids = context.Request["IDList"];
            List<int> IDlist = JsonConvert.DeserializeObject<List<int>>(ids);
            if (IDlist.Count > 0)
            {
                using (SqlHelper helper = new SqlHelper())
                {
                    try
                    {
                        helper.BeginTransaction();
                        string cmdtext = "delete from [Cheque_OutDetail] where [ID] in (" + string.Join(",", IDlist) + ")";
                        helper.Execute(cmdtext, CommandType.Text, new List<SqlParameter>());
                        helper.Commit();
                    }
                    catch (Exception ex)
                    {
                        helper.Rollback();
                        LogHelper.WriteError(LogModule, "命令: removechequeoutdetail", ex);
                        WebUtil.WriteJson(context, new { status = false });
                        return;
                    }
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void loadoutproductdetailgrid(HttpContext context)
        {
            try
            {
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                int OutSummaryID = WebUtil.GetIntValue(context, "OutSummaryID");
                string guid = context.Request["guid"];
                DataGrid dg = Foresight.DataAccess.Cheque_OutDetail.GetCheque_OutDetailGridByKeywords(OutSummaryID, guid, "order by ID desc", startRowIndex, pageSize);
                WebUtil.WriteJson(context, dg);
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(LogModule, "命令: loadoutproductdetailgrid", ex);
                context.Response.Write("{\"rows\":[],\"total\":0,\"page\":0}");
            }
        }
        private void getoutdetailparams(HttpContext context)
        {
            var DepartmentList = Foresight.DataAccess.Cheque_Department.GetCheque_Departments();
            var ProjectList = Foresight.DataAccess.Cheque_Project.GetCheque_Projects();
            var SellerList = Foresight.DataAccess.Cheque_Seller.GetCheque_Sellers();
            var BuyerList = Foresight.DataAccess.Cheque_Buyer.GetCheque_Buyers();
            WebUtil.WriteJson(context, new { DepartmentList = DepartmentList, ProjectList = ProjectList, SellerList, BuyerList = BuyerList });
        }
        private void addtempoutproductlist(HttpContext context)
        {
            string guid = context.Request["guid"];
            string list = context.Request["list"];
            int[] IDList = JsonConvert.DeserializeObject<int[]>(list);
            List<Foresight.DataAccess.Cheque_OutDetail> detaillist = new List<Foresight.DataAccess.Cheque_OutDetail>();
            if (IDList.Length > 0)
            {
                foreach (var ID in IDList)
                {
                    var product = Foresight.DataAccess.Cheque_Product.GetCheque_Product(ID);
                    if (product == null)
                    {
                        continue;
                    }
                    var detail = new Foresight.DataAccess.Cheque_OutDetail();
                    detail.OutSummaryID = 0;
                    detail.ProductID = product.ID;
                    detail.ProductName = product.ProductName;
                    detail.ModelNumber = product.ModelNumber;
                    detail.UnitPrice = product.UnitPrice;
                    detail.TotalCount = 0;
                    detail.TotalCost = 0;
                    detail.TaxRate = "";
                    detail.TotalTaxCost = 0;
                    detail.TotalSummaryCost = 0;
                    detail.GUID = guid;
                    detaillist.Add(detail);
                }
            }
            if (detaillist.Count > 0)
            {
                using (SqlHelper helper = new SqlHelper())
                {
                    try
                    {
                        helper.BeginTransaction();
                        foreach (var item in detaillist)
                        {
                            item.Save(helper);
                        }
                        helper.Commit();
                    }
                    catch (Exception ex)
                    {
                        helper.Rollback();
                        LogHelper.WriteError(LogModule, "命令: addtempoutproductlist", ex);
                    }
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void removechequeout(HttpContext context)
        {
            string ids = context.Request["IDList"];
            List<int> IDlist = JsonConvert.DeserializeObject<List<int>>(ids);
            if (IDlist.Count > 0)
            {
                using (SqlHelper helper = new SqlHelper())
                {
                    try
                    {
                        helper.BeginTransaction();
                        string cmdtext = "delete from [Cheque_OutSummary] where [ID] in (" + string.Join(",", IDlist) + ")";
                        helper.Execute(cmdtext, CommandType.Text, new List<SqlParameter>());
                        helper.Commit();
                    }
                    catch (Exception ex)
                    {
                        helper.Rollback();
                        LogHelper.WriteError(LogModule, "命令: removechequeout", ex);
                        WebUtil.WriteJson(context, new { status = false });
                        return;
                    }
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void loadchequeoutgrid(HttpContext context)
        {
            try
            {
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                string keywords = context.Request["keywords"];
                string sellerlist = context.Request["sellerlist"];
                List<int> SellerList = JsonConvert.DeserializeObject<List<int>>(sellerlist);
                string productlist = context.Request["productlist"];
                List<int> ProductList = JsonConvert.DeserializeObject<List<int>>(productlist);
                string departmentlist = context.Request["departmentlist"];
                List<int> DepartmentList = JsonConvert.DeserializeObject<List<int>>(departmentlist);
                string projectlist = context.Request["projectlist"];
                List<int> ProjectList = JsonConvert.DeserializeObject<List<int>>(projectlist);
                DateTime StartTime = WebUtil.GetDateValue(context, "StartTime");
                DateTime EndTime = WebUtil.GetDateValue(context, "EndTime");
                string ChequeCode = context.Request["ChequeNo"];
                DataGrid dg = Foresight.DataAccess.ViewChequeOutSummary.GetViewChequeOutSummaryGridByKeywords(keywords, SellerList, ProductList, DepartmentList, ProjectList, StartTime, EndTime, ChequeCode, "order by ID desc", startRowIndex, pageSize);
                WebUtil.WriteJson(context, dg);
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(LogModule, "命令: loadchequeoutgrid", ex);
                context.Response.Write("{\"rows\":[],\"total\":0,\"page\":0}");
            }
        }
        private void removechequecontractcategory(HttpContext context)
        {
            string ids = context.Request["IDList"];
            List<int> IDlist = JsonConvert.DeserializeObject<List<int>>(ids);
            if (IDlist.Count > 0)
            {
                using (SqlHelper helper = new SqlHelper())
                {
                    try
                    {
                        helper.BeginTransaction();
                        string cmdtext = "delete from [Cheque_ContractCategory] where [ID] in (" + string.Join(",", IDlist) + ");";
                        helper.Execute(cmdtext, CommandType.Text, new List<SqlParameter>());
                        helper.Commit();
                    }
                    catch (Exception ex)
                    {
                        helper.Rollback();
                        LogHelper.WriteError(LogModule, "命令: removechequecontractcategory", ex);
                        WebUtil.WriteJson(context, new { status = false });
                        return;
                    }
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void loadchequecontractcategorygrid(HttpContext context)
        {
            try
            {
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                string keywords = context.Request["keywords"];
                DataGrid dg = Foresight.DataAccess.Cheque_ContractCategory.GetCheque_ContractCategoryGridByKeywords(keywords, "order by ID desc", startRowIndex, pageSize);
                WebUtil.WriteJson(context, dg);
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(LogModule, "命令: loadchequecontractcategorygrid", ex);
                context.Response.Write("{\"rows\":[],\"total\":0,\"page\":0}");
            }
        }
        private void removechequetaxrate(HttpContext context)
        {
            string ids = context.Request["IDList"];
            List<int> IDlist = JsonConvert.DeserializeObject<List<int>>(ids);
            if (IDlist.Count > 0)
            {
                using (SqlHelper helper = new SqlHelper())
                {
                    try
                    {
                        helper.BeginTransaction();
                        string cmdtext = "delete from [Cheque_TaxRate] where [ID] in (" + string.Join(",", IDlist) + ");";
                        helper.Execute(cmdtext, CommandType.Text, new List<SqlParameter>());
                        helper.Commit();
                    }
                    catch (Exception ex)
                    {
                        helper.Rollback();
                        LogHelper.WriteError(LogModule, "命令: removechequetaxrate", ex);
                        WebUtil.WriteJson(context, new { status = false });
                        return;
                    }
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void loadchequetaxrategrid(HttpContext context)
        {
            try
            {
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                string keywords = context.Request["keywords"];
                DataGrid dg = Foresight.DataAccess.Cheque_TaxRate.GetCheque_TaxRateGridByKeywords(keywords, "order by ID desc", startRowIndex, pageSize);
                WebUtil.WriteJson(context, dg);
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(LogModule, "命令: loadchequetaxrategrid", ex);
                context.Response.Write("{\"rows\":[],\"total\":0,\"page\":0}");
            }
        }
        private void savechequetaxrate(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            string guid = context.Request["guid"];
            var taxrate = Foresight.DataAccess.Cheque_TaxRate.GetCheque_TaxRate(ID);
            if (taxrate == null)
            {
                taxrate = new Foresight.DataAccess.Cheque_TaxRate();
                taxrate.AddTime = DateTime.Now;
            }
            taxrate.TaxRateName = context.Request["TaxRateName"];
            taxrate.TaxRateValue = context.Request["TaxRateValue"];
            taxrate.GUID = guid;
            taxrate.Save();
            WebUtil.WriteJson(context, new { status = true });
        }
        private void savechequecontractcategory(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            string guid = context.Request["guid"];
            var contractcategory = Foresight.DataAccess.Cheque_ContractCategory.GetCheque_ContractCategory(ID);
            if (contractcategory == null)
            {
                contractcategory = new Foresight.DataAccess.Cheque_ContractCategory();
            }
            contractcategory.ContractCategoryName = context.Request["ContractCategoryName"];
            contractcategory.ContractCategoryNumber = context.Request["ContractCategoryNumber"];
            contractcategory.GUID = guid;
            contractcategory.Save();
            WebUtil.WriteJson(context, new { status = true });
        }
        private void savechequestamp(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            var chequetax = Foresight.DataAccess.Cheque_Tax.GetCheque_Tax(ID);
            if (chequetax == null)
            {
                chequetax = new Foresight.DataAccess.Cheque_Tax();
                chequetax.AddTime = DateTime.Now;
            }
            chequetax.ContractNumber = context.Request["ContractNumber"];
            chequetax.DepartmentID = WebUtil.GetIntValue(context, "DepartmentID");
            chequetax.ContractCategoryID = WebUtil.GetIntValue(context, "ContractCategoryID");
            chequetax.TaxRateID = WebUtil.GetIntValue(context, "TaxRateID");
            chequetax.ContractName = context.Request["ContractName"];
            chequetax.UnitPrice = WebUtil.GetDecimalValue(context, "UnitPrice");
            chequetax.TotalCount = WebUtil.GetIntValue(context, "TotalCount");

            var department = Foresight.DataAccess.Cheque_Department.GetCheque_Department(chequetax.DepartmentID);
            chequetax.CurrentDepartmentName = department != null ? department.DepartmentName : "";
            var contractcategory = Foresight.DataAccess.Cheque_ContractCategory.GetCheque_ContractCategory(chequetax.ContractCategoryID);
            chequetax.CurrentContractCategoryName = contractcategory != null ? contractcategory.ContractCategoryName : "";

            var taxrate = Foresight.DataAccess.Cheque_TaxRate.GetCheque_TaxRate(chequetax.TaxRateID);
            chequetax.CurrentTaxRateName = taxrate != null ? taxrate.TaxRateName : "";
            chequetax.CurrentTaxRateValue = taxrate != null ? taxrate.TaxRateValue : "";

            decimal TotalCost = chequetax.UnitPrice * chequetax.TotalCount;
            chequetax.TotalCost = TotalCost;
            var chequetaxrate = Foresight.DataAccess.Cheque_TaxRate.GetCheque_TaxRate(chequetax.TaxRateID);
            if (chequetaxrate != null)
            {
                decimal taxratevalue = 0;
                decimal.TryParse(chequetaxrate.TaxRateValue, out taxratevalue);
                chequetax.TotalTaxCost = Math.Round((chequetax.TotalCost * taxratevalue / 100), 2);
            }
            else
            {
                chequetax.TotalTaxCost = 0;
            }
            string AddMan = context.Request["AddMan"];
            chequetax.AddMan = string.IsNullOrEmpty(AddMan) ? WebUtil.GetUser(context).RealName : AddMan;
            DateTime AddTime = WebUtil.GetDateValue(context, "AddTime");
            chequetax.AddTime = AddTime > DateTime.MinValue ? AddTime : DateTime.Now;
            chequetax.Save();
            WebUtil.WriteJson(context, new { status = true });
        }
        private void getchequestampeditparams(HttpContext context)
        {
            var DepartmentList = Foresight.DataAccess.Cheque_Department.GetCheque_Departments();
            var ContractCategoryList = Foresight.DataAccess.Cheque_ContractCategory.GetCheque_ContractCategories();
            var TaxRateList = Foresight.DataAccess.Cheque_TaxRate.GetCheque_TaxRates();
            WebUtil.WriteJson(context, new { DepartmentList = DepartmentList, ContractCategoryList = ContractCategoryList, TaxRateList = TaxRateList });
        }
        private void removechequestamp(HttpContext context)
        {
            string ids = context.Request["IDList"];
            List<int> IDlist = JsonConvert.DeserializeObject<List<int>>(ids);
            if (IDlist.Count > 0)
            {
                using (SqlHelper helper = new SqlHelper())
                {
                    try
                    {
                        helper.BeginTransaction();
                        string cmdtext = "delete from [Cheque_Tax] where [ID] in (" + string.Join(",", IDlist) + ");";
                        helper.Execute(cmdtext, CommandType.Text, new List<SqlParameter>());
                        helper.Commit();
                    }
                    catch (Exception ex)
                    {
                        helper.Rollback();
                        LogHelper.WriteError(LogModule, "命令: removechequestamp", ex);
                        WebUtil.WriteJson(context, new { status = false });
                        return;
                    }
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void loadchequestampgrid(HttpContext context)
        {
            try
            {
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                string keywords = context.Request["keywords"];
                DataGrid dg = Foresight.DataAccess.ViewChequeTax.GetViewChequeTaxGridByKeywords(keywords, "order by ID desc", startRowIndex, pageSize);
                WebUtil.WriteJson(context, dg);
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(LogModule, "命令: loadchequestampgrid", ex);
                context.Response.Write("{\"rows\":[],\"total\":0,\"page\":0}");
            }
        }
        private void loadoutjzfiles(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            Foresight.DataAccess.Cheque_OutingFile[] files = Foresight.DataAccess.Cheque_OutingFile.GetCheque_OutingFileList(ID);
            WebUtil.WriteJson(context, files);
        }
        private void removeoutjzfile(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            if (ID > 0)
            {
                using (SqlHelper helper = new SqlHelper())
                {
                    try
                    {
                        helper.BeginTransaction();
                        string cmdtext = "delete from [Cheque_OutingFile] where [ID]=@ID;";
                        List<SqlParameter> parameters = new List<SqlParameter>();
                        parameters.Add(new SqlParameter("@ID", ID));
                        helper.Execute(cmdtext, CommandType.Text, parameters);
                        helper.Commit();
                    }
                    catch (Exception ex)
                    {
                        helper.Rollback();
                        LogHelper.WriteError(LogModule, "命令: removechequeoutjz", ex);
                        WebUtil.WriteJson(context, new { status = false });
                        return;
                    }
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void savechequeoutjz(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            var outing = Foresight.DataAccess.Cheque_Outing.GetCheque_Outing(ID);
            if (outing == null)
            {
                outing = new Foresight.DataAccess.Cheque_Outing();
                outing.AddTime = DateTime.Now;
            }
            outing.ProjectID = WebUtil.GetIntValue(context, "ProjectID");
            outing.StartTime = WebUtil.GetDateValue(context, "StartTime");
            outing.EndTime = WebUtil.GetDateValue(context, "EndTime");
            outing.NotifyTime = WebUtil.GetDateValue(context, "NotifyTime");
            outing.Operator = context.Request["Operator"];
            outing.OperationTime = WebUtil.GetDateValue(context, "OperationTime");
            outing.IDCardStatus = context.Request["IDCardStatus"];
            outing.Remark = context.Request["Remark"];
            outing.DepartmentID = WebUtil.GetIntValue(context, "DepartmentID");
            outing.BelongCompanyName = context.Request["BelongCompanyName"];
            outing.PaperNumber = context.Request["PaperNumber"];
            outing.OutingAddress = context.Request["OutingAddress"];
            outing.ApproveMan = context.Request["ApproveMan"];
            outing.TaxManName = context.Request["TaxManName"];
            outing.TaxNumber = context.Request["TaxNumber"];
            outing.CompanyInChargeMan = context.Request["CompanyInChargeMan"];
            outing.IDCardType = context.Request["IDCardType"];
            outing.IDCardNumber = context.Request["IDCardNumber"];
            outing.ProduceAddress = context.Request["ProduceAddress"];
            outing.CompanyRegiserType = context.Request["CompanyRegiserType"];
            outing.BusinessType = context.Request["BusinessType"];
            outing.InChargeMan = context.Request["InChargeMan"];
            if (!string.IsNullOrEmpty(outing.ApproveMan))
            {
                outing.ApproveStatus = 1;
                outing.ApproveTime = DateTime.Now;
            }
            var project = Foresight.DataAccess.Cheque_Project.GetCheque_Project(outing.ProjectID);
            outing.CurrentProjectName = project != null ? project.ProjectName : "";
            var department = Foresight.DataAccess.Cheque_Department.GetCheque_Department(outing.DepartmentID);
            outing.CurrentDepartmentName = department != null ? department.DepartmentName : "";
            List<Foresight.DataAccess.Cheque_OutingFile> attachlist = new List<Foresight.DataAccess.Cheque_OutingFile>();
            HttpFileCollection uploadFiles = context.Request.Files;
            for (int i = 0; i < uploadFiles.Count; i++)
            {
                HttpPostedFile postedFile = uploadFiles[i];
                string fileOriName = postedFile.FileName;
                if (fileOriName != "" && fileOriName != null)
                {
                    string extension = System.IO.Path.GetExtension(fileOriName).ToLower();
                    string fileName = DateTime.Now.ToFileTime().ToString() + extension;
                    string filepath = "/upload/cheque/";
                    string rootPath = HttpContext.Current.Server.MapPath("~" + filepath);
                    if (!System.IO.Directory.Exists(rootPath))
                    {
                        System.IO.Directory.CreateDirectory(rootPath);
                    }
                    string Path = rootPath + fileName;
                    postedFile.SaveAs(Path);
                    Foresight.DataAccess.Cheque_OutingFile attach = new Foresight.DataAccess.Cheque_OutingFile();
                    attach.FileOriName = fileOriName;
                    attach.FilePath = filepath + fileName;
                    attach.AddTime = DateTime.Now;
                    attachlist.Add(attach);
                }
            }
            using (SqlHelper helper = new SqlHelper())
            {
                helper.BeginTransaction();
                try
                {
                    outing.Save(helper);
                    foreach (var item in attachlist)
                    {
                        item.OutingID = outing.ID;
                        item.Save(helper);
                    }
                    helper.Commit();
                    WebUtil.WriteJson(context, new { status = true });
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError(LogModule, "命令: savechequeoutjz", ex);
                    WebUtil.WriteJson(context, new { status = false });
                }
            }
        }
        private void getoutjzeditparams(HttpContext context)
        {
            var ProjectList = Foresight.DataAccess.Cheque_Project.GetCheque_Projects();
            var DepartmentList = Foresight.DataAccess.Cheque_Department.GetCheque_Departments();
            WebUtil.WriteJson(context, new { ProjectList = ProjectList, DepartmentList = DepartmentList });
        }
        private void removechequeoutjz(HttpContext context)
        {
            string ids = context.Request["IDList"];
            List<int> IDlist = JsonConvert.DeserializeObject<List<int>>(ids);
            if (IDlist.Count > 0)
            {
                using (SqlHelper helper = new SqlHelper())
                {
                    try
                    {
                        helper.BeginTransaction();
                        string cmdtext = "delete from [Cheque_OutingFile] where [OutingID] in (" + string.Join(",", IDlist) + ");";
                        cmdtext += "delete from [Cheque_Outing] where [ID] in (" + string.Join(",", IDlist) + ")";
                        helper.Execute(cmdtext, CommandType.Text, new List<SqlParameter>());
                        helper.Commit();
                    }
                    catch (Exception ex)
                    {
                        helper.Rollback();
                        LogHelper.WriteError(LogModule, "命令: removechequeoutjz", ex);
                        WebUtil.WriteJson(context, new { status = false });
                        return;
                    }
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void loadchequeoutjzgrid(HttpContext context)
        {
            try
            {
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                string keywords = context.Request["keywords"];
                DataGrid dg = Foresight.DataAccess.Cheque_OutingDetail.GetCheque_OutingDetailGridByKeywords(keywords, "order by ID desc", startRowIndex, pageSize);
                WebUtil.WriteJson(context, dg);
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(LogModule, "命令: loadchequeoutjzgrid", ex);
                context.Response.Write("{\"rows\":[],\"total\":0,\"page\":0}");
            }
        }
        private void addtempproductlist(HttpContext context)
        {
            string guid = context.Request["guid"];
            string list = context.Request["list"];
            int[] IDList = JsonConvert.DeserializeObject<int[]>(list);
            List<Foresight.DataAccess.Cheque_InDetail> detaillist = new List<Foresight.DataAccess.Cheque_InDetail>();
            if (IDList.Length > 0)
            {
                foreach (var ID in IDList)
                {
                    var product = Foresight.DataAccess.Cheque_Product.GetCheque_Product(ID);
                    if (product == null)
                    {
                        continue;
                    }
                    var detail = new Foresight.DataAccess.Cheque_InDetail();
                    detail.InSummaryID = 0;
                    detail.ProductID = product.ID;
                    detail.ProductName = product.ProductName;
                    detail.ModelNumber = product.ModelNumber;
                    detail.UnitPrice = product.UnitPrice;
                    detail.TotalCount = 0;
                    detail.TotalCost = 0;
                    detail.TaxRate = "";
                    detail.TotalTaxCost = 0;
                    detail.TotalSummaryCost = 0;
                    detail.GUID = guid;
                    detaillist.Add(detail);
                }
            }
            if (detaillist.Count > 0)
            {
                using (SqlHelper helper = new SqlHelper())
                {
                    try
                    {
                        helper.BeginTransaction();
                        foreach (var item in detaillist)
                        {
                            item.Save(helper);
                        }
                        helper.Commit();
                    }
                    catch (Exception ex)
                    {
                        helper.Rollback();
                        LogHelper.WriteError(LogModule, "命令: addtempproductlist", ex);
                    }
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void removechequein(HttpContext context)
        {
            string ids = context.Request["IDList"];
            List<int> IDlist = JsonConvert.DeserializeObject<List<int>>(ids);
            if (IDlist.Count > 0)
            {
                using (SqlHelper helper = new SqlHelper())
                {
                    try
                    {
                        helper.BeginTransaction();
                        string cmdtext = "delete from [Cheque_InSummary] where [ID] in (" + string.Join(",", IDlist) + ")";
                        helper.Execute(cmdtext, CommandType.Text, new List<SqlParameter>());
                        helper.Commit();
                    }
                    catch (Exception ex)
                    {
                        helper.Rollback();
                        LogHelper.WriteError(LogModule, "命令: removechequein", ex);
                        WebUtil.WriteJson(context, new { status = false });
                        return;
                    }
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void savechequeapprove(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            var summary = Foresight.DataAccess.Cheque_InSummary.GetCheque_InSummary(ID);
            if (summary != null)
            {
                summary.ApproveOperator = context.Request["ApproveOperator"];
                summary.ApporveTime = WebUtil.GetDateValue(context, "ApporveTime");
                summary.ApproveRemark = context.Request["ApproveRemark"];
                summary.ApproveState = 1;
                summary.Save();
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void savechequesign(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            var summary = Foresight.DataAccess.Cheque_InSummary.GetCheque_InSummary(ID);
            if (summary != null)
            {
                summary.SignOperator = context.Request["SignOperator"];
                summary.SignTime = WebUtil.GetDateValue(context, "SignTime");
                summary.SignRemark = context.Request["SignRemark"];
                summary.SignState = 1;
                summary.Save();
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void loadchequeingrid(HttpContext context)
        {
            try
            {
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                string keywords = context.Request["keywords"];
                string sellerlist = context.Request["sellerlist"];
                List<int> SellerList = JsonConvert.DeserializeObject<List<int>>(sellerlist);
                string productlist = context.Request["productlist"];
                List<int> ProductList = JsonConvert.DeserializeObject<List<int>>(productlist);
                string departmentlist = context.Request["departmentlist"];
                List<int> DepartmentList = JsonConvert.DeserializeObject<List<int>>(departmentlist);
                string projectlist = context.Request["projectlist"];
                List<int> ProjectList = JsonConvert.DeserializeObject<List<int>>(projectlist);
                DateTime StartTime = WebUtil.GetDateValue(context, "StartTime");
                DateTime EndTime = WebUtil.GetDateValue(context, "EndTime");
                string ChequeCode = context.Request["ChequeNo"];
                DataGrid dg = Foresight.DataAccess.ViewChequeInSummary.GetViewChequeInSummaryGridByKeywords(keywords, SellerList, ProductList, DepartmentList, ProjectList, StartTime, EndTime, ChequeCode, "order by ID desc", startRowIndex, pageSize);
                var footerList = Foresight.DataAccess.ViewChequeInSummary.GetViewChequeInSummaryFooterByKeywords(keywords, SellerList, ProductList, DepartmentList, ProjectList, StartTime, EndTime, ChequeCode);
                dg.footer = footerList;

                WebUtil.WriteJson(context, dg);
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(LogModule, "命令: loadchequeingrid", ex);
                context.Response.Write("{\"rows\":[],\"total\":0,\"page\":0}");
            }
        }
        private void getcomboboxbyguid(HttpContext context)
        {
            string type = context.Request["type"];
            string guid = context.Request["guid"];
            switch (type)
            {
                case "department":
                    {
                        var DepartmentList = Foresight.DataAccess.Cheque_Department.GetCheque_Departments();
                        var list = Foresight.DataAccess.Cheque_Department.GetCheque_DepartmentByGUID(guid);
                        var ID = list.Length > 0 ? list[0].ID : 0;
                        WebUtil.WriteJson(context, new { status = true, DepartmentList = DepartmentList, ID = ID });
                    }
                    break;
                case "project":
                    {
                        var ProjectList = Foresight.DataAccess.Cheque_Project.GetCheque_Projects();
                        var list = Foresight.DataAccess.Cheque_Project.GetCheque_ProjectByGUID(guid);
                        var ID = list.Length > 0 ? list[0].ID : 0;
                        WebUtil.WriteJson(context, new { status = true, ProjectList = ProjectList, ID = ID });
                    }
                    break;
                case "seller":
                    {
                        var SellerList = Foresight.DataAccess.Cheque_Seller.GetCheque_Sellers();
                        var list = Foresight.DataAccess.Cheque_Seller.GetCheque_SellerByGUID(guid);
                        var ID = list.Length > 0 ? list[0].ID : 0;
                        WebUtil.WriteJson(context, new { status = true, SellerList = SellerList, ID = ID });
                    }
                    break;
                case "buyer":
                    {
                        var BuyerList = Foresight.DataAccess.Cheque_Buyer.GetCheque_Buyers();
                        var list = Foresight.DataAccess.Cheque_Buyer.GetCheque_BuyerByGUID(guid);
                        var ID = list.Length > 0 ? list[0].ID : 0;
                        WebUtil.WriteJson(context, new { status = true, BuyerList = BuyerList, ID = ID });
                    }
                    break;
                case "contract":
                    {
                        var ContractCategoryList = Foresight.DataAccess.Cheque_ContractCategory.GetCheque_ContractCategories();
                        var list = Foresight.DataAccess.Cheque_ContractCategory.GetCheque_ContractCategoryByGUID(guid);
                        var ID = list.Length > 0 ? list[0].ID : 0;
                        WebUtil.WriteJson(context, new { status = true, ContractCategoryList = ContractCategoryList, ID = ID });
                    }
                    break;
                case "taxrate":
                    {
                        var TaxRateList = Foresight.DataAccess.Cheque_TaxRate.GetCheque_TaxRates();
                        var list = Foresight.DataAccess.Cheque_TaxRate.GetCheque_TaxRateCategoryByGUID(guid);
                        var ID = list.Length > 0 ? list[0].ID : 0;
                        WebUtil.WriteJson(context, new { status = true, TaxRateList = TaxRateList, ID = ID });
                    }
                    break;
                default:
                    WebUtil.WriteJson(context, new { status = false });
                    break;
            }
        }
        private void savechequein(HttpContext context)
        {
            int InSummaryID = WebUtil.GetIntValue(context, "InSummaryID");
            Foresight.DataAccess.Cheque_InSummary insummary = null;
            if (InSummaryID > 0)
            {
                insummary = Foresight.DataAccess.Cheque_InSummary.GetCheque_InSummary(InSummaryID);
            }
            if (insummary == null)
            {
                insummary = new Foresight.DataAccess.Cheque_InSummary();
                insummary.AddTime = DateTime.Now;
            }
            string guid = context.Request["guid"];
            insummary.WriteDate = WebUtil.GetDateValue(context, "WriteDate");
            insummary.WriteMan = context.Request["WriteMan"];
            insummary.DepartmentID = WebUtil.GetIntValue(context, "DepartmentID");
            insummary.ProjectID = WebUtil.GetIntValue(context, "ProjectID");
            insummary.SellerID = WebUtil.GetIntValue(context, "SellerID");
            insummary.BuyerID = WebUtil.GetIntValue(context, "BuyerID");
            insummary.ChequeNumber = context.Request["ChequeNumber"];
            insummary.ChequeTime = WebUtil.GetDateValue(context, "ChequeTime");
            insummary.ChequeCode = context.Request["ChequeCode"];
            insummary.ChequeCategory = context.Request["ChequeCategory"];

            var depeartment = Foresight.DataAccess.Cheque_Department.GetCheque_Department(insummary.DepartmentID);
            insummary.CurrentDepartmentName = depeartment != null ? depeartment.DepartmentName : "";

            var project = Foresight.DataAccess.Cheque_Project.GetCheque_Project(insummary.ProjectID);
            insummary.CurrentProjectName = project != null ? project.ProjectName : "";

            var seller = Foresight.DataAccess.Cheque_Seller.GetCheque_Seller(insummary.SellerID);
            insummary.CurrentSellerName = seller != null ? seller.SellerName : "";
            insummary.CurrentSellerTaxNumber = seller != null ? seller.SellerTaxNumber : "";
            insummary.CurrentSellerAddressPhone = seller != null ? seller.SellerAddressPhone : "";
            insummary.CurrentSellerBankAccount = seller != null ? seller.SellerBankAccount : "";

            var buyer = Foresight.DataAccess.Cheque_Buyer.GetCheque_Buyer(insummary.BuyerID);
            insummary.CurrentBuyerName = seller != null ? buyer.BuyerName : "";
            insummary.CurrentBuyerTaxNumber = seller != null ? buyer.BuyerTaxNumber : "";
            insummary.CurrentBuyerAddressPhone = seller != null ? buyer.BuyerAddressPhone : "";
            insummary.CurrentBuyerBankAccount = seller != null ? buyer.BuyerBankAccount : "";

            var detaillist = Foresight.DataAccess.Cheque_InDetail.GetCheque_InDetailList(InSummaryID, guid);

            List<Foresight.DataAccess.Cheque_InSummaryFile> attachlist = new List<Foresight.DataAccess.Cheque_InSummaryFile>();
            HttpFileCollection uploadFiles = context.Request.Files;
            for (int i = 0; i < uploadFiles.Count; i++)
            {
                HttpPostedFile postedFile = uploadFiles[i];
                string fileOriName = postedFile.FileName;
                if (fileOriName != "" && fileOriName != null)
                {
                    string extension = System.IO.Path.GetExtension(fileOriName).ToLower();
                    string fileName = DateTime.Now.ToFileTime().ToString() + extension;
                    string filepath = "/upload/cheque/";
                    string rootPath = HttpContext.Current.Server.MapPath("~" + filepath);
                    if (!System.IO.Directory.Exists(rootPath))
                    {
                        System.IO.Directory.CreateDirectory(rootPath);
                    }
                    string Path = rootPath + fileName;
                    postedFile.SaveAs(Path);
                    Foresight.DataAccess.Cheque_InSummaryFile attach = new Foresight.DataAccess.Cheque_InSummaryFile();
                    attach.FileOriName = fileOriName;
                    attach.FilePath = filepath + fileName;
                    attach.AddTime = DateTime.Now;
                    attachlist.Add(attach);
                }
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    insummary.Save(helper);
                    foreach (var item in detaillist)
                    {
                        item.InSummaryID = insummary.ID;
                        item.Save(helper);
                    }
                    foreach (var item in attachlist)
                    {
                        item.InSummaryID = insummary.ID;
                        item.Save(helper);
                    }
                    helper.Commit();
                    WebUtil.WriteJson(context, new { status = true });
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError(LogModule, "命令: savechequein", ex);
                    WebUtil.WriteJson(context, new { status = false });
                }
            }
        }
        private void getindetailparams(HttpContext context)
        {
            var DepartmentList = Foresight.DataAccess.Cheque_Department.GetCheque_Departments();
            var ProjectList = Foresight.DataAccess.Cheque_Project.GetCheque_Projects();
            var SellerList = Foresight.DataAccess.Cheque_Seller.GetCheque_Sellers();
            var BuyerList = Foresight.DataAccess.Cheque_Buyer.GetCheque_Buyers();
            WebUtil.WriteJson(context, new { DepartmentList = DepartmentList, ProjectList = ProjectList, SellerList, BuyerList = BuyerList });
        }
        private void removechequeindetail(HttpContext context)
        {
            string ids = context.Request["IDList"];
            List<int> IDlist = JsonConvert.DeserializeObject<List<int>>(ids);
            if (IDlist.Count > 0)
            {
                using (SqlHelper helper = new SqlHelper())
                {
                    try
                    {
                        helper.BeginTransaction();
                        string cmdtext = "delete from [Cheque_InDetail] where [ID] in (" + string.Join(",", IDlist) + ")";
                        helper.Execute(cmdtext, CommandType.Text, new List<SqlParameter>());
                        helper.Commit();
                    }
                    catch (Exception ex)
                    {
                        helper.Rollback();
                        LogHelper.WriteError(LogModule, "命令: removechequeindetail", ex);
                        WebUtil.WriteJson(context, new { status = false });
                        return;
                    }
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void loadinproductdetailgrid(HttpContext context)
        {
            try
            {
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                int InSummaryID = WebUtil.GetIntValue(context, "InSummaryID");
                string guid = context.Request["guid"];
                DataGrid dg = Foresight.DataAccess.Cheque_InDetail.GetCheque_InDetailGridByKeywords(InSummaryID, guid, "order by ID desc", startRowIndex, pageSize);
                WebUtil.WriteJson(context, dg);
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(LogModule, "命令: loadinproductdetailgrid", ex);
                context.Response.Write("{\"rows\":[],\"total\":0,\"page\":0}");
            }
        }
        private void getproductlist(HttpContext context)
        {
            var list = Foresight.DataAccess.Cheque_Product.GetCheque_Products();
            WebUtil.WriteJson(context, new { status = true, ProductList = list });
        }
        private void savechequeinproduct(HttpContext context)
        {
            int ProductID = WebUtil.GetIntValue(context, "ProductID");
            Foresight.DataAccess.Cheque_InDetail _cheque_InDetail = null;
            int ID = WebUtil.GetIntValue(context, "ID");
            if (ID > 0)
            {
                _cheque_InDetail = Foresight.DataAccess.Cheque_InDetail.GetCheque_InDetail(ID);
            }
            if (_cheque_InDetail == null)
            {
                _cheque_InDetail = new Foresight.DataAccess.Cheque_InDetail();
                _cheque_InDetail.InSummaryID = WebUtil.GetIntValue(context, "InSummaryID");
                _cheque_InDetail.GUID = context.Request["guid"];
            }
            var product = Foresight.DataAccess.Cheque_Product.GetCheque_Product(ProductID);
            if (product == null)
            {
                product = new Foresight.DataAccess.Cheque_Product();
                product.AddTime = DateTime.Now;
            }
            product.ProductName = context.Request["ProductName"];
            product.ModelNumber = context.Request["ModelNumber"];
            product.Unit = context.Request["Unit"];
            product.UnitPrice = WebUtil.GetDecimalValue(context, "UnitPrice");
            _cheque_InDetail.ProductName = context.Request["ProductName"];
            _cheque_InDetail.ModelNumber = context.Request["ModelNumber"];
            _cheque_InDetail.Unit = context.Request["Unit"];
            _cheque_InDetail.UnitPrice = WebUtil.GetDecimalValue(context, "UnitPrice");
            _cheque_InDetail.TotalCount = WebUtil.GetIntValue(context, "TotalCount");
            _cheque_InDetail.TotalCost = _cheque_InDetail.TotalCount * _cheque_InDetail.UnitPrice;
            _cheque_InDetail.TaxRate = context.Request["TaxRate"];
            decimal TaxRate = WebUtil.GetDecimalValue(context, "TaxRate");
            _cheque_InDetail.TotalTaxCost = Math.Round((_cheque_InDetail.TotalCost * TaxRate / 100), 2);
            _cheque_InDetail.TotalSummaryCost = _cheque_InDetail.TotalTaxCost + _cheque_InDetail.TotalCost;
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    product.Save(helper);
                    _cheque_InDetail.ProductID = product.ID;
                    _cheque_InDetail.Save(helper);
                    helper.Commit();
                    WebUtil.WriteJson(context, new { status = true });
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError(LogModule, "命令: savechequeinproduct", ex);
                    WebUtil.WriteJson(context, new { status = false });
                }
            }
        }
        private void removenode(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            string NodeType = context.Request["NodeType"];
            string Type = context.Request["Type"];
            string cmdtext = string.Empty;
            switch (NodeType)
            {
                case "sellercategory":
                    {
                        cmdtext = "delete from [Cheque_SellerCategory] where ID=" + ID + ";";
                    }
                    break;
                case "seller":
                    {
                        cmdtext += "delete from [Cheque_Seller] where ID=" + ID + ";";
                    }
                    break;
                case "productcategory":
                    {
                        cmdtext = "delete from [Cheque_ProductCategory] where ID=" + ID + ";";
                    }
                    break;
                case "product":
                    {
                        cmdtext = "delete from [Cheque_Product] where ID=" + ID + ";";
                    }
                    break;
                case "departmentcategory":
                    {
                        cmdtext = "delete from [Cheque_DepartmentCategory] where ID=" + ID + ";";
                    }
                    break;
                case "department":
                    {
                        cmdtext = "delete from [Cheque_Department] where ID=" + ID + ";";
                    }
                    break;
                case "projectcategory":
                    {
                        cmdtext = "delete from [Cheque_ProjectCategory] where ID=" + ID + ";";
                    }
                    break;
                case "project":
                    {
                        cmdtext = "delete from [Cheque_Project] where ID=" + ID + ";";
                    }
                    break;
                case "buyercategory":
                    {
                        cmdtext = "delete from [Cheque_ProjectCategory] where ID=" + ID + ";";
                    }
                    break;
                case "buyer":
                    {
                        cmdtext = "delete from [Cheque_Buyer] where ID=" + ID + ";";
                    }
                    break;
                default:
                    break;
            }
            if (!string.IsNullOrEmpty(cmdtext))
            {
                using (SqlHelper helper = new SqlHelper())
                {
                    helper.BeginTransaction();
                    try
                    {
                        helper.Execute(cmdtext, CommandType.Text, new List<SqlParameter>());
                        helper.Commit();
                    }
                    catch (Exception ex)
                    {
                        helper.Rollback();
                        LogHelper.WriteError(LogModule, "命令: removenode", ex);
                        WebUtil.WriteJson(context, new { status = false });
                        return;
                    }
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void savechequebuyer(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            var buyer = Foresight.DataAccess.Cheque_Buyer.GetCheque_Buyer(ID);
            if (buyer == null)
            {
                buyer = new Foresight.DataAccess.Cheque_Buyer();
                buyer.AddTime = DateTime.Now;
            }
            buyer.BuyerName = context.Request["BuyerName"];
            buyer.BuyerTaxNumber = context.Request["TaxNumber"];
            buyer.BuyerAddressPhone = context.Request["AddressPhone"];
            buyer.BuyerBankAccount = context.Request["BankAccount"];
            buyer.BuyerSocialCreditCode = context.Request["BuyerSocialCreditCode"];
            buyer.BuyerCategoryID = WebUtil.GetIntValue(context, "BuyerCategoryID");
            buyer.BuyerType = context.Request["BuyerType"];
            buyer.GUID = context.Request["guid"];
            buyer.Save();
            WebUtil.WriteJson(context, new { status = true });
        }
        private void savechequeproject(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            var project = Foresight.DataAccess.Cheque_Project.GetCheque_Project(ID);
            if (project == null)
            {
                project = new Foresight.DataAccess.Cheque_Project();
                project.AddTime = DateTime.Now;
            }
            project.ProjectName = context.Request["ProjectName"];
            project.GUID = context.Request["guid"];
            project.Save();
            WebUtil.WriteJson(context, new { status = true });
        }
        private void savechequedepartment(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            var department = Foresight.DataAccess.Cheque_Department.GetCheque_Department(ID);
            if (department == null)
            {
                department = new Foresight.DataAccess.Cheque_Department();
                department.AddTime = DateTime.Now;
            }
            department.DepartmentName = context.Request["DepartmentName"];
            department.Description = context.Request["Description"];
            department.DepartmentNumber = context.Request["DepartmentNumber"];
            department.DepartmentInChargeMan = context.Request["DepartmentInChargeMan"];
            department.GUID = context.Request["guid"];
            department.DepartmentCategoryID = WebUtil.GetIntValue(context, "DepartmentCategoryID");
            department.Save();
            WebUtil.WriteJson(context, new { status = true });
        }
        private void savechequeproduct(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            var product = Foresight.DataAccess.Cheque_Product.GetCheque_Product(ID);
            if (product == null)
            {
                product = new Foresight.DataAccess.Cheque_Product();
                product.AddTime = DateTime.Now;
            }
            product.ProductName = context.Request["ProductName"];
            product.ModelNumber = context.Request["ModelNumber"];
            product.Unit = context.Request["Unit"];
            product.UnitPrice = WebUtil.GetDecimalValue(context, "UnitPrice");
            product.ProductNumber = context.Request["ProductNumber"];
            product.ProductCategoryID = WebUtil.GetIntValue(context, "ProductCategoryID");
            product.Save();
            WebUtil.WriteJson(context, new { status = true });
        }
        private void savechequeseller(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            var seller = Foresight.DataAccess.Cheque_Seller.GetCheque_Seller(ID);
            if (seller == null)
            {
                seller = new Foresight.DataAccess.Cheque_Seller();
                seller.AddTime = DateTime.Now;
            }
            seller.SellerName = context.Request["SellerName"];
            seller.SellerTaxNumber = context.Request["TaxNumber"];
            seller.SellerAddressPhone = context.Request["AddressPhone"];
            seller.SellerBankAccount = context.Request["BankAccount"];
            seller.SellerSocialCreditCode = context.Request["SellerSocialCreditCode"];
            seller.SellerCategoryID = WebUtil.GetIntValue(context, "SellerCategoryID");
            seller.SellerType = context.Request["SellerType"];
            seller.GUID = context.Request["guid"];
            seller.Save();
            WebUtil.WriteJson(context, new { status = true });
        }
        private void gettree(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            string Keywords = context.Request.Params["Keywords"];
            List<Dictionary<string, object>> items = new List<Dictionary<string, object>>();
            Dictionary<string, object> dic = new Dictionary<string, object>();
            items.Add(GetTreeLevel("基础资料", "basicinfo_1", "0", "root", true));
            items.Add(GetTreeLevel("销售单位", "sellerinfo_1", "basicinfo_1", "sellerinfo", false));
            items.Add(GetTreeLevel("货品信息", "productinfo_1", "basicinfo_1", "productinfo", false));
            items.Add(GetTreeLevel("直管部门", "departmentinfo_1", "basicinfo_1", "departmentinfo", false));
            items.Add(GetTreeLevel("项目名称", "projectinfo_1", "basicinfo_1", "projectinfo", false));
            items.Add(GetTreeLevel("购货单位", "buyerinfo_1", "basicinfo_1", "buyerinfo", false));
            #region 销售单位子级
            var sellerCategoryList = Foresight.DataAccess.Cheque_SellerCategory.GetCheque_SellerCategoryListByKeywords(Keywords);
            var sellerlist = Foresight.DataAccess.Cheque_Seller.GetCheque_SellerList(Keywords);
            foreach (var item in sellerCategoryList)
            {
                items.Add(GetTreeLevel(item.SellerCategoryName, "sellercategory_" + item.ID, "sellerinfo_1", "sellercategory", false));
                var childlist = sellerlist.Where(p => p.SellerCategoryID == item.ID);
                foreach (var childitem in childlist)
                {
                    items.Add(GetTreeLevel(childitem.SellerName, "seller_" + childitem.ID, "sellercategory_" + item.ID, "seller", false));
                }
            }
            var sellerCategoryIDList = sellerCategoryList.Select(q => q.ID).ToList();
            var notbelongsellerlist = sellerlist.Where(p => (sellerCategoryIDList.Contains(p.SellerCategoryID) == false));
            foreach (var item in notbelongsellerlist)
            {
                items.Add(GetTreeLevel(item.SellerName, "seller_" + item.ID, "sellerinfo_1", "seller", false));
            }
            #endregion

            #region 货品子级
            var productCategoryList = Foresight.DataAccess.Cheque_ProductCategory.GetCheque_ProductCategoryListByKeywords(Keywords);
            var productlist = Foresight.DataAccess.Cheque_Product.GetCheque_ProductList(Keywords);
            foreach (var item in productCategoryList)
            {
                items.Add(GetTreeLevel(item.ProductCategoryName, "productcategory_" + item.ID, "productinfo_1", "productcategory", false));
                var childlist = productlist.Where(p => p.ProductCategoryID == item.ID);
                foreach (var childitem in childlist)
                {
                    items.Add(GetTreeLevel(childitem.ProductName, "product_" + childitem.ID, "productcategory_" + item.ID, "product", false));
                }
            }
            var productCategoryIDList = productCategoryList.Select(q => q.ID).ToList();
            var notbelongproductlist = productlist.Where(p => (productCategoryIDList.Contains(p.ProductCategoryID) == false));
            foreach (var item in notbelongproductlist)
            {
                items.Add(GetTreeLevel(item.ProductName, "product_" + item.ID.ToString(), "productinfo_1", "product", false));
            }
            #endregion

            #region 直管部门子级
            var departmentCategoryList = Foresight.DataAccess.Cheque_DepartmentCategory.GetCheque_DepartmentCategoryListByKeywords(Keywords);
            var departmentlist = Foresight.DataAccess.Cheque_Department.GetCheque_DepartmentList(Keywords);
            foreach (var item in departmentCategoryList)
            {
                items.Add(GetTreeLevel(item.DepartmentCategoryName, "departmentcategory_" + item.ID, "departmentinfo_1", "departmentcategory", false));
                var childlist = departmentlist.Where(p => p.DepartmentCategoryID == item.ID);
                foreach (var childitem in childlist)
                {
                    items.Add(GetTreeLevel(childitem.DepartmentName, "department_" + childitem.ID.ToString(), "departmentcategory_" + item.ID, "department", false));
                }
            }
            var departmentCategoryIDList = departmentCategoryList.Select(q => q.ID).ToList();
            var notbelongdepartmentlist = departmentlist.Where(p => (departmentCategoryIDList.Contains(p.DepartmentCategoryID) == false));

            foreach (var item in notbelongdepartmentlist)
            {
                items.Add(GetTreeLevel(item.DepartmentName, "department_" + item.ID.ToString(), "departmentinfo_1", "department", false));
            }
            #endregion

            #region 项目子级
            var projectCategoryList = Foresight.DataAccess.Cheque_ProjectCategory.GetCheque_ProjectCategoryListByKeywords(Keywords);
            var projectlist = Foresight.DataAccess.Cheque_Project.GetCheque_ProjectList(Keywords);
            foreach (var item in projectCategoryList)
            {
                items.Add(GetTreeLevel(item.ProjectCategoryName, "projectcategory_" + item.ID, "projectinfo_1", "projectcategory", false));
                var childlist = projectlist.Where(p => p.ProjectCategoryID == item.ID);
                foreach (var childitem in childlist)
                {
                    items.Add(GetTreeLevel(childitem.ProjectName, "project_" + childitem.ID.ToString(), "projectcategory_" + item.ID, "project", false));
                }
            }
            var projectCategoryIDList = projectCategoryList.Select(q => q.ID).ToList();
            var notbelongprojectlist = projectlist.Where(p => (projectCategoryIDList.Contains(p.ProjectCategoryID) == false));
            foreach (var item in notbelongprojectlist)
            {
                items.Add(GetTreeLevel(item.ProjectName, "project_" + item.ID.ToString(), "projectinfo_1", "project", false));
            }
            #endregion

            #region 购货单位子级
            var buyerCategoryList = Foresight.DataAccess.Cheque_BuyerCategory.GetCheque_BuyerCategoryListByKeywords(Keywords);
            var buyerlist = Foresight.DataAccess.Cheque_Buyer.GetCheque_BuyerList(Keywords);
            foreach (var item in buyerCategoryList)
            {
                items.Add(GetTreeLevel(item.BuyerCategoryName, "buyercategory_" + item.ID, "buyerinfo_1", "buyercategory", false));
                var childlist = buyerlist.Where(p => p.BuyerCategoryID == item.ID);
                foreach (var childitem in childlist)
                {
                    items.Add(GetTreeLevel(childitem.BuyerName, "buyer_" + childitem.ID.ToString(), "buyercategory_" + item.ID, "buyer", false));
                }
            }
            var buyerCategoryIDList = buyerCategoryList.Select(q => q.ID).ToList();
            var notbelongbuyerlist = buyerlist.Where(p => (buyerCategoryIDList.Contains(p.BuyerCategoryID) == false));
            foreach (var item in notbelongbuyerlist)
            {
                items.Add(GetTreeLevel(item.BuyerName, "buyer_" + item.ID.ToString(), "buyerinfo_1", "buyer", false));
            }
            #endregion
            string result = JsonConvert.SerializeObject(items);
            context.Response.Write(result);
        }
        #region Comm Methods
        private Dictionary<string, object> GetTreeLevel(string name, string id, string pId, string type, bool open)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic["name"] = name;
            dic["id"] = id;
            dic["pId"] = pId;
            dic["ptype"] = type;
            dic["open"] = open;
            return dic;
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