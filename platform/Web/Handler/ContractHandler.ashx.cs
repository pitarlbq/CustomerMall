using DataAccess;
using Foresight.DataAccess;
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
using Web.APPCode;
using Web.Model;

namespace Web.Handler
{
    /// <summary>
    /// ContractHandler 的摘要说明
    /// </summary>
    public class ContractHandler : IHttpHandler, IRequiresSessionState
    {
        const string LogModule = "ContractHandler";
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
                    case "loadcontractgrid":
                        loadcontractgrid(context);
                        break;
                    case "savecontract":
                        savecontract(context);
                        break;
                    case "saveapprove":
                        saveapprove(context);
                        break;
                    case "cancelcontract":
                        cancelcontract(context);
                        break;
                    case "loadcontractattachs":
                        loadcontractattachs(context);
                        break;
                    case "deletefile":
                        deletefile(context);
                        break;
                    case "loadcontractsummarygrid":
                        loadcontractsummarygrid(context);
                        break;
                    case "loadcontractroomlist":
                        loadcontractroomlist(context);
                        break;
                    case "savecontractroom":
                        savecontractroom(context);
                        break;
                    case "removecontractroom":
                        removecontractroom(context);
                        break;
                    case "getaddcontractchargeparam":
                        getaddcontractchargeparam(context);
                        break;
                    case "savecontractcharge":
                        savecontractcharge(context);
                        break;
                    case "removecontractcharge":
                        removecontractcharge(context);
                        break;
                    case "loadcontractchargelist":
                        loadcontractchargelist(context);
                        break;
                    case "removecontract":
                        removecontract(context);
                        break;
                    case "createcontractfee":
                        createcontractfee(context);
                        break;
                    case "cancelcontractprintfee":
                        cancelcontractprintfee(context);
                        break;
                    case "editcontractcharge":
                        editcontractcharge(context);
                        break;
                    case "loadcontractfeehistorylist":
                        loadcontractfeehistorylist(context);
                        break;
                    case "getcontractfeetitle":
                        getcontractfeetitle(context);
                        break;
                    case "savecontracttempprice":
                        savecontracttempprice(context);
                        break;
                    case "loadcontractemppricegrid":
                        loadcontractemppricegrid(context);
                        break;
                    case "addcontracttemppricelist":
                        addcontracttemppricelist(context);
                        break;
                    case "addcontracttemppricelistnew":
                        addcontracttemppricelistnew(context);
                        break;
                    case "removecontracttempprice":
                        removecontracttempprice(context);
                        break;
                    case "removecontracttemppricebyguid":
                        removecontracttemppricebyguid(context);
                        break;
                    case "checkweiyuestatus":
                        checkweiyuestatus(context);
                        break;
                    case "createzuzhong":
                        createzuzhong(context);
                        break;
                    case "getzuzhonglist":
                        getzuzhonglist(context);
                        break;
                    case "savezukong":
                        savezukong(context);
                        break;
                    case "removezukong":
                        removezukong(context);
                        break;
                    case "savecontracttemplate":
                        savecontracttemplate(context);
                        break;
                    case "loadcontracttemplategrid":
                        loadcontracttemplategrid(context);
                        break;
                    case "removecontracttemplate":
                        removecontracttemplate(context);
                        break;
                    case "getcontractfreetime":
                        getcontractfreetime(context);
                        break;
                    case "removecontractfreetime":
                        removecontractfreetime(context);
                        break;
                    case "zuofeicontract":
                        zuofeicontract(context);
                        break;
                    case "savecontractprintcontent":
                        savecontractprintcontent(context);
                        break;
                    case "loadcontractdividegrid":
                        loadcontractdividegrid(context);
                        break;
                    case "savecontractdiviecreate":
                        savecontractdiviecreate(context);
                        break;
                    case "activecontractdivide":
                        activecontractdivide(context);
                        break;
                    case "getcontractdividestypebyid":
                        getcontractdividestypebyid(context);
                        break;
                    case "removecontractdividetype":
                        removecontractdividetype(context);
                        break;
                    case "savecontractdivieedit":
                        savecontractdivieedit(context);
                        break;
                    case "removecontractdivide":
                        removecontractdivide(context);
                        break;
                    case "savecontractdivieprocess":
                        savecontractdivieprocess(context);
                        break;
                    case "savecontractbasicinfo":
                        savecontractbasicinfo(context);
                        break;
                    case "savecontractmoreinfo":
                        savecontractmoreinfo(context);
                        break;
                    case "getcontractfeesummarygrid":
                        getcontractfeesummarygrid(context);
                        break;
                    case "getcontractcustomergrid":
                        getcontractcustomergrid(context);
                        break;
                    case "removecontractcustomer":
                        removecontractcustomer(context);
                        break;
                    case "loadcontractmodifyloggrid":
                        loadcontractmodifyloggrid(context);
                        break;
                    case "savecontractearn":
                        savecontractearn(context);
                        break;
                    case "savecontractchargebyrows":
                        savecontractchargebyrows(context);
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
        private void savecontractchargebyrows(HttpContext context)
        {
            var rows = context.Request["rows"];
            if (string.IsNullOrEmpty(rows))
            {
                WebUtil.WriteJson(context, new { status = false, error = "请选择需要保存的数据" });
                return;
            }
            var list = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(rows);
            int canedit = WebUtil.GetIntValue(context, "canedit");

            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    foreach (var item in list)
                    {
                        string IDStr = WebUtil.GetStrByObj(item, "ID");
                        int ID = 0;
                        if (!string.IsNullOrEmpty(IDStr))
                        {
                            int.TryParse(IDStr, out ID);
                        }
                        if (ID <= 0)
                        {
                            WebUtil.WriteJson(context, new { status = false, error = "ID无效" });
                            return;
                        }
                        var data = Foresight.DataAccess.Contract_RoomCharge.GetContract_RoomCharge(ID, helper);
                        if (data == null)
                        {
                            WebUtil.WriteJson(context, new { status = false, error = "收费标准不存在" });
                            return;
                        }
                        data.RoomUnitPrice = WebUtil.GetDecimalByObj(item, "CalculateUnitPrice");
                        data.RoomStartTime = WebUtil.GetDateTimeByObj(item, "CalculateStartTime");
                        data.RoomEndTime = WebUtil.GetDateTimeByObj(item, "CalculateEndTime");
                        data.RoomNewEndTime = WebUtil.GetDateTimeByObj(item, "CalculateNewEndTime");
                        data.RoomUseCount = WebUtil.GetDecimalByObj(item, "CalculateUseCount");
                        data.ReadyChargeTime = WebUtil.GetDateTimeByObj(item, "ReadyChargeTime");
                        data.Save(helper);
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
            WebUtil.WriteJson(context, new { status = true });
        }
        private void savecontractearn(HttpContext context)
        {
            string IDs = context.Request.Params["IDList"];
            List<int> IDList = new List<int>();
            if (!string.IsNullOrEmpty(IDs))
            {
                IDList = JsonConvert.DeserializeObject<List<int>>(IDs);
            }
            Foresight.DataAccess.Contract_Customer[] datalist = new Contract_Customer[] { };
            if (IDList.Count == 0)
            {
                WebUtil.WriteJson(context, new { status = false, error = "请选择一个扣点合同" });
                return;
            }
            List<string> conditions = new List<string>();
            var parameters = new List<SqlParameter>();
            if (!string.IsNullOrEmpty(WebUtil.getServerValue(context, "tdContractDivideSellCost")))
            {
                decimal ContractDivideSellCost = WebUtil.getServerDecimalValue(context, "tdContractDivideSellCost");
                conditions.Add("ContractDivideSellCost=@ContractDivideSellCost");
                parameters.Add(new SqlParameter("@ContractDivideSellCost", ContractDivideSellCost));
            }
            if (!string.IsNullOrEmpty(WebUtil.getServerValue(context, "tdContractDevicePercent")))
            {
                decimal ContractDevicePercent = WebUtil.getServerDecimalValue(context, "tdContractDevicePercent");
                conditions.Add("ContractDevicePercent=@ContractDevicePercent");
                parameters.Add(new SqlParameter("@ContractDevicePercent", ContractDevicePercent));
            }
            if (conditions.Count == 0)
            {
                WebUtil.WriteJson(context, new { status = false, error = "请填写数据" });
                return;
            }
            string cmdtext = "update [Contract] set " + string.Join(",", conditions.ToArray()) + " where [ID] in (" + string.Join(",", IDList.ToArray()) + ");";
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    helper.Execute(cmdtext, CommandType.Text, parameters);
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    Utility.LogHelper.WriteError("ContractHandler", "命令:savecontractearn", ex);
                    WebUtil.WriteJson(context, new { status = false });
                    return;
                }
            }

            WebUtil.WriteJson(context, new { status = true });
        }
        private void removecontractcustomer(HttpContext context)
        {
            int canedit = WebUtil.GetIntValue(context, "canedit");
            string IDs = context.Request.Params["IDList"];
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(IDs);
            Foresight.DataAccess.Contract_Customer[] datalist = new Contract_Customer[] { };
            if (IDList.Count > 0)
            {
                datalist = Foresight.DataAccess.Contract_Customer.GetContract_CustomerListByIDList(IDList);
                string cmdtext = string.Empty;
                cmdtext += "delete from [Contract_Customer] where [ID] in (" + string.Join(",", IDList.ToArray()) + ");";
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
                        helper.Rollback();
                        Utility.LogHelper.WriteError("ContractHandler", "命令:removecontractcustomer", ex);
                        WebUtil.WriteJson(context, new { status = false });
                        return;
                    }
                }
                #region 删除日志
                var user = WebUtil.GetUser(context);
                APPCode.CommHelper.SaveOperationLog(string.Join(",", IDList.ToArray()), Utility.EnumModel.OperationModule.ContractChargeDelete.ToString(), "合同收款/承租方删除", user.UserID.ToString(), "Contract_Customer", user.LoginName, IsHide: true);
                APPCode.CommHelper.SaveOperationLog("用户" + user.LoginName + "删除了合同收款/承租方", Utility.EnumModel.OperationModule.ContractChargeDelete.ToString(), "合同合同收款/承租方删除", user.UserID.ToString(), "Contract_Customer", user.LoginName);
                #endregion
            }
            else
            {
                WebUtil.WriteJson(context, new { status = true });
                return;
            }
            if (datalist.Length > 0 && canedit == 1)
            {
                CommHelper.SaveContractCustomerRemoveorAddLog(datalist, WebUtil.GetUser(context).RealName, ModifyType: "remove");
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void loadcontractmodifyloggrid(HttpContext context)
        {
            try
            {
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                int ContractID = WebUtil.GetIntValue(context, "ContractID");
                DataGrid dg = Foresight.DataAccess.Contract_ModifyLog.GetContract_ModifyLogGrid(ContractID, "order by [ID] desc", startRowIndex, pageSize);
                WebUtil.WriteJson(context, dg);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.WriteError(LogModule, "命令:loadcontractmodifyloggrid", ex);
                WebUtil.WriteJson(context, new DataGrid());
            }
        }
        private void getcontractcustomergrid(HttpContext context)
        {
            try
            {
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                int ContractID = WebUtil.GetIntValue(context, "ContractID");
                DataGrid dg = Foresight.DataAccess.Contract_Customer.GetContract_CustomerGrid(ContractID, "order by [ID] asc", startRowIndex, pageSize);
                WebUtil.WriteJson(context, dg);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.WriteError(LogModule, "命令:getcontractcustomergrid", ex);
                WebUtil.WriteJson(context, new DataGrid());
            }
        }
        private void getcontractfeesummarygrid(HttpContext context)
        {
            var summarys = Foresight.DataAccess.ChargeSummary.GetChargeSummaries();
            var item = new { summarys = summarys };
            WebUtil.WriteJson(context, item);
        }
        private void savecontractmoreinfo(HttpContext context)
        {
            int canedit = WebUtil.GetIntValue(context, "canedit");
            Foresight.DataAccess.Contract contract = null;
            string precontractstr = string.Empty;
            int ContractID = WebUtil.GetIntValue(context, "ContractID");
            string guid = context.Request.Params["guid"];
            string AddMan = WebUtil.GetUser(context).RealName;
            if (ContractID > 0)
            {
                contract = Foresight.DataAccess.Contract.GetContract(ContractID);
                precontractstr = JsonConvert.SerializeObject(contract);
            }
            if (contract == null)
            {
                contract = new Foresight.DataAccess.Contract();
                contract.AddTime = DateTime.Now;
                contract.AddMan = AddMan;
                contract.ContractStatus = EnumModel.ContractStatus.yuding.ToString();
            }
            contract.RoomID = 0;
            contract.WarningTime = getTimeValue(context, "tdWarningTime");
            contract.RoomUseFor = getValue(context, "tdRoomUseFor");
            contract.RoomStatus = getValue(context, "tdRoomStatus");
            contract.SignTime = getTimeValue(context, "tdSignTime");
            contract.FreeStartTime = getTimeValue(context, "tdFreeStartTime");
            contract.FreeEndTime = getTimeValue(context, "tdFreeEndTime");
            contract.OpenTime = getTimeValue(context, "tdOpenTime");
            contract.InTime = getTimeValue(context, "tdInTime");
            contract.OutTime = getTimeValue(context, "tdOutTime");
            contract.RentRange = getValue(context, "tdRentRange");
            contract.ChargeRange = getValue(context, "tdChargeRange");
            contract.EveryYearUp = getDecimalValue(context, "tdEveryYearUp");
            contract.BrandModel = getValue(context, "tdBrandModel");
            contract.Address = getValue(context, "tdAddress");
            contract.DeliverTime = getTimeValue(context, "tdDeliverTime");
            contract.RentUseFor = getValue(context, "tdRentUseFor");
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    if (!string.IsNullOrEmpty(contract.ContractNo))
                    {
                        var exist_contract = Foresight.DataAccess.Contract.GetContractByContractNo(contract.ContractNo, contract.ID > 0 ? contract.ID : 0, helper);
                        if (exist_contract != null && exist_contract.ID != contract.ID)
                        {
                            helper.Rollback();
                            WebUtil.WriteJson(context, new { status = false, msg = "该合同编号已存在" });
                            return;
                        }
                    }
                    contract.Save(helper);
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    Utility.LogHelper.WriteError(LogModule, "命令: savecontractmore", ex);
                    helper.Rollback();
                    context.Response.Write("{\"status\":false}");
                    return;
                }
            }
            if (!string.IsNullOrEmpty(precontractstr) && canedit == 1)
            {
                Foresight.DataAccess.Contract precontract = JsonConvert.DeserializeObject<Foresight.DataAccess.Contract>(precontractstr);
                CommHelper.SaveContractLog(precontract, contract, WebUtil.GetUser(context).RealName);
            }
            context.Response.Write("{\"status\":true,\"ID\":" + contract.ID + "}");
        }
        private void savecontractbasicinfo(HttpContext context)
        {
            var user = WebUtil.GetUser(context);
            int canedit = WebUtil.GetIntValue(context, "canedit");
            int canNewRent = WebUtil.GetIntValue(context, "canNewRent");
            int canChangeRent = WebUtil.GetIntValue(context, "canChangeRent");
            Foresight.DataAccess.Contract contract = null;
            string precontractstr = string.Empty;
            int ContractID = WebUtil.GetIntValue(context, "ContractID");
            int TopContractID = WebUtil.GetIntValue(context, "TopContractID");
            string guid = context.Request.Params["guid"];
            string AddMan = user.RealName;
            var roomList = Contract_Room.GetContract_RoomListByContractID(ContractID, guid);
            if (roomList.Length == 0)
            {
                WebUtil.WriteJson(context, new { status = false, msg = "请选择租赁资源" });
                return;
            }
            if (ContractID > 0)
            {
                contract = Foresight.DataAccess.Contract.GetContract(ContractID);
                precontractstr = JsonConvert.SerializeObject(contract);
            }
            if (contract == null)
            {
                contract = new Foresight.DataAccess.Contract();
                contract.AddTime = DateTime.Now;
                contract.AddMan = AddMan;
                contract.ContractStatus = EnumModel.ContractStatus.yuding.ToString();
                if (TopContractID > 0)
                {
                    var topContract = Foresight.DataAccess.Contract.GetContract(TopContractID);
                    if (topContract != null)
                    {
                        contract.TopContractID = topContract.TopContractID > 0 ? topContract.TopContractID : TopContractID;
                        contract.ParentContractID = topContract.ID;
                    }
                }
            }
            contract.RoomID = 0;
            contract.OrderNumberID = WebUtil.getServerIntValue(context, "hdOrderNumberID");
            contract.ContractNo = getValue(context, "tdContractNo");
            contract.ContractName = getValue(context, "tdContractName");
            contract.ContractDeposit = getDecimalValue(context, "tdContractDeposit");
            contract.TimeLimit = getIntValue(context, "tdTimeLimit");
            contract.RentStartTime = getTimeValue(context, "tdRentStartTime");
            contract.RentEndTime = getTimeValue(context, "tdRentEndTime");
            contract.FreeDays = getIntValue(context, "tdFreeDays");
            contract.RentPrice = getDecimalValue(context, "tdRentPrice");
            contract.ContractSummary = getValue(context, "tdContractSummary");
            contract.IsDivideOn = WebUtil.GetIntValue(context, "IsContractDivideOn") == 1;
            contract.ContractDevicePercent = WebUtil.getServerDecimalValue(context, "tdContractDevicePercent");
            contract.ContractBasicRentCost = WebUtil.getServerDecimalValue(context, "tdContractBasicRentCost");
            contract.ContractType = WebUtil.getServerIntValue(context, "tdContractType");
            //contract.WarningTime = getTimeValue(context, "tdWarningTime");
            string RelationProperty = WebUtil.getServerValue(context, "tdRelationProperty");

            contract.RentName = WebUtil.getServerValue(context, "tdRentName");
            contract.ContractPhone = WebUtil.getServerValue(context, "tdContractPhone");
            contract.CustomerName = WebUtil.getServerValue(context, "tdCustomerName");
            contract.InChargeMan = WebUtil.getServerValue(context, "tdInChargeMan");
            contract.BusinessLicense = WebUtil.getServerValue(context, "tdBusinessLicense");
            contract.SellerProduct = WebUtil.getServerValue(context, "tdSellerProduct");
            contract.IDCardNo = WebUtil.getServerValue(context, "tdIDCardNo");
            contract.IDCardAddress = WebUtil.getServerValue(context, "tdIDCardAddress");
            if (canNewRent == 1)
            {
                contract.ContractRelateType = 1;
            }
            if (canChangeRent == 2)
            {
                contract.ContractRelateType = 2;
            }
            List<Foresight.DataAccess.Contract_File> attachlist = new List<Foresight.DataAccess.Contract_File>();
            HttpFileCollection uploadFiles = context.Request.Files;
            for (int i = 0; i < uploadFiles.Count; i++)
            {
                HttpPostedFile postedFile = uploadFiles[i];
                string fileOriName = postedFile.FileName;
                if (fileOriName != "" && fileOriName != null)
                {
                    string extension = System.IO.Path.GetExtension(fileOriName).ToLower();
                    string fileName = DateTime.Now.ToFileTime().ToString() + extension;
                    string filepath = "/upload/Contract/";
                    string rootPath = HttpContext.Current.Server.MapPath("~" + filepath);
                    if (!System.IO.Directory.Exists(rootPath))
                    {
                        System.IO.Directory.CreateDirectory(rootPath);
                    }
                    string Path = rootPath + fileName;
                    postedFile.SaveAs(Path);
                    Foresight.DataAccess.Contract_File attach = new Foresight.DataAccess.Contract_File();
                    attach.FileOriName = fileOriName;
                    attach.AttachedFilePath = filepath + fileName;
                    attach.AddTime = DateTime.Now;
                    attach.FileType = "addcontract";
                    attachlist.Add(attach);
                }
            }
            Contract_ChargeSummary[] summaryList = new Contract_ChargeSummary[] { };
            Contract_RoomCharge[] chargeList = new Contract_RoomCharge[] { };
            if (ContractID <= 0)
            {
                summaryList = Contract_ChargeSummary.GetContract_ChargeSummaryList(ContractID, guid, 0);
                chargeList = Contract_RoomCharge.GetContract_RoomChargeList(ContractID, guid);
            }
            string freeliststr = context.Request["freelist"];
            List<ContractFreeTimeModel> freemodellist = new List<ContractFreeTimeModel>();
            List<Contract_FreeTime> freelist = new List<Contract_FreeTime>();
            if (!string.IsNullOrEmpty(freeliststr))
            {
                freemodellist = JsonConvert.DeserializeObject<List<ContractFreeTimeModel>>(freeliststr);
            }
            foreach (var item in freemodellist)
            {
                Foresight.DataAccess.Contract_FreeTime freetime = null;
                if (item.ID > 0)
                {
                    freetime = Foresight.DataAccess.Contract_FreeTime.GetContract_FreeTime(item.ID);
                }
                if (freetime == null)
                {
                    freetime = new Contract_FreeTime();
                    freetime.AddTime = DateTime.Now;
                }
                freetime.FreeStartTime = item.StartTime;
                freetime.FreeEndTime = item.EndTime;
                freetime.FreeType = item.FreeType;
                if (item.FreeChargeIDs.Length > 0)
                {
                    item.FreeChargeIDs = item.FreeChargeIDs.Substring(1, item.FreeChargeIDs.Length - 2);
                    freetime.FreeChargeIDs = item.FreeChargeIDs;
                }
                freelist.Add(freetime);
            }
            string customers = context.Request["customerList"];
            List<ContractCustomerModel> customerModelList = new List<ContractCustomerModel>();
            List<Contract_Customer> customerList = new List<Contract_Customer>();
            List<Contract_Customer> addCustomerList = new List<Contract_Customer>();
            if (!string.IsNullOrEmpty(customers))
            {
                customerModelList = JsonConvert.DeserializeObject<List<ContractCustomerModel>>(customers);
            }
            foreach (var item in customerModelList)
            {
                Contract_Customer contractCustomer = null;
                if (item.ID > 0)
                {
                    contractCustomer = Contract_Customer.GetContract_Customer(item.ID);
                }
                if (contractCustomer == null)
                {
                    contractCustomer = new Contract_Customer();
                    contractCustomer.AddTime = DateTime.Now;
                    contractCustomer.AddUserName = AddMan;
                    addCustomerList.Add(contractCustomer);
                }
                contractCustomer.CustomerName = item.CustomerName;
                contractCustomer.Address = item.Address;
                contractCustomer.OfficerName = item.OfficerName;
                contractCustomer.ContactName = item.ContactName;
                contractCustomer.PhoneNumber = item.PhoneNumber;
                contractCustomer.ChargeIDs = item.ChargeIDs;
                contractCustomer.CustomerType = item.FinalCustomerType;
                contractCustomer.ChargePercent = item.ChargePercent;
                customerList.Add(contractCustomer);
            }
            RoomPhoneRelation relationPhone = null;
            var relationConnectList = new RoomPhoneRelation_Connect[] { };
            if (!string.IsNullOrEmpty(contract.ContractPhone) || !string.IsNullOrEmpty(contract.RentName))
            {
                if (contract.RelationPhoneID > 0)
                {
                    relationPhone = RoomPhoneRelation.GetRoomPhoneRelation(contract.RelationPhoneID);
                }
                if (relationPhone == null)
                {
                    relationPhone = new RoomPhoneRelation();
                    relationPhone.AddTime = DateTime.Now;
                    relationPhone.IsChargeFee = true;
                    relationPhone.IsChargeMan = true;
                    relationPhone.RoomID = 0;
                }
                relationPhone.RelationProperty = WebUtil.getServerValue(context, "tdRelationProperty");
                relationPhone.RelatePhoneNumber = WebUtil.getServerValue(context, "tdContractPhone");
                if (relationPhone.RelationProperty.Equals("geren"))
                {
                    relationPhone.RelationName = WebUtil.getServerValue(context, "tdRentName");
                }
                else
                {
                    relationPhone.CompanyName = WebUtil.getServerValue(context, "tdRentName");
                    relationPhone.RelationName = WebUtil.getServerValue(context, "tdCustomerName");
                    relationPhone.CompanyInChargeMan = WebUtil.getServerValue(context, "tdInChargeMan");
                    relationPhone.BusinessLicense = WebUtil.getServerValue(context, "tdBusinessLicense");
                    relationPhone.SellerProduct = WebUtil.getServerValue(context, "tdSellerProduct");
                }
                relationPhone.IDCardType = WebUtil.getServerIntValue(context, "tdIDCardType");
                relationPhone.RelationIDCard = WebUtil.getServerValue(context, "tdIDCardNo");
                relationPhone.IDCardAddress = WebUtil.getServerValue(context, "tdIDCardAddress");
                if (contract.ID > 0)
                {
                    relationConnectList = RoomPhoneRelation_Connect.GetRoomPhoneRelation_ConnectListByContractID(contract.ID);
                }
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    if (!string.IsNullOrEmpty(contract.ContractNo))
                    {
                        var exist_contract = Foresight.DataAccess.Contract.GetContractByContractNo(contract.ContractNo, contract.ID > 0 ? contract.ID : 0, helper);
                        if (exist_contract != null && exist_contract.ID != contract.ID)
                        {
                            helper.Rollback();
                            WebUtil.WriteJson(context, new { status = false, msg = "该合同编号已存在" });
                            return;
                        }
                    }
                    contract.Save(helper);
                    foreach (var item in customerList)
                    {
                        item.ContractID = contract.ID;
                        item.Save(helper);
                    }
                    int DefaultChargeManID = 0;
                    if (relationPhone != null)
                    {
                        relationPhone.ContractID = contract.ID;
                        relationPhone.Save(helper);
                        contract.RelationPhoneID = relationPhone.ID;
                        contract.Save(helper);
                        DefaultChargeManID = relationPhone.ID;
                    }
                    foreach (var item in freelist)
                    {
                        item.ContractID = contract.ID;
                        item.Save(helper);
                    }
                    foreach (var item in attachlist)
                    {
                        item.RelateID = contract.ID;
                        item.Save(helper);
                    }
                    foreach (var item in roomList)
                    {
                        item.ContractID = contract.ID;
                        item.Save(helper);
                        if (relationPhone != null)
                        {
                            var connectItem = relationConnectList.FirstOrDefault(p => p.RoomPhoneRelationID == relationPhone.ID && p.RoomID == item.RoomID);
                            if (connectItem == null)
                            {
                                connectItem = new RoomPhoneRelation_Connect();
                                connectItem.RoomPhoneRelationID = relationPhone.ID;
                                connectItem.ContractID = contract.ID;
                                connectItem.RoomID = item.RoomID;
                                connectItem.Save(helper);
                            }
                        }
                    }
                    foreach (var item in summaryList)
                    {
                        item.ContractID = contract.ID;
                        item.Save(helper);
                    }
                    foreach (var item in chargeList)
                    {
                        if (item.RoomStartTime == DateTime.MinValue)
                        {
                            item.RoomStartTime = contract.RentStartTime;
                        }
                        if (item.RoomEndTime == DateTime.MinValue)
                        {
                            item.RoomEndTime = contract.RentEndTime;
                        }
                        if (item.RoomNewEndTime == DateTime.MinValue)
                        {
                            item.RoomNewEndTime = contract.RentEndTime;
                        }
                        item.ContractID = contract.ID;
                        item.Save(helper);
                    }
                    string DefaultChargeManName = contract.RentName;
                    if (!string.IsNullOrEmpty(DefaultChargeManName))
                    {
                        string cmdtext = "update RoomFee set [DefaultChargeManName]=@DefaultChargeManName,[DefaultChargeManID]=@DefaultChargeManID where [ContractID]=@ContractID;";
                        List<SqlParameter> parameters = new List<SqlParameter>();
                        parameters.Add(new SqlParameter("@DefaultChargeManName", DefaultChargeManName));
                        parameters.Add(new SqlParameter("@DefaultChargeManID", DefaultChargeManID));
                        parameters.Add(new SqlParameter("@ContractID", contract.ID));
                        helper.Execute(cmdtext, CommandType.Text, parameters);
                    }
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    Utility.LogHelper.WriteError(LogModule, "命令: savecontractbasicinfo", ex);
                    helper.Rollback();
                    WebUtil.WriteJson(context, new { status = false });
                    return;
                }
            }
            if (!string.IsNullOrEmpty(precontractstr) && canedit == 1)
            {
                Foresight.DataAccess.Contract precontract = JsonConvert.DeserializeObject<Foresight.DataAccess.Contract>(precontractstr);
                CommHelper.SaveContractLog(precontract, contract, WebUtil.GetUser(context).RealName);
            }
            WebUtil.WriteJson(context, new { status = true, ID = contract.ID });
        }
        private void savecontractdivieprocess(HttpContext context)
        {
            List<int> DivideIDList = JsonConvert.DeserializeObject<List<int>>(context.Request["IDList"]);
            if (DivideIDList.Count == 0)
            {
                WebUtil.WriteJson(context, new { status = false, error = "请选择账单" });
                return;
            }
            var historylist = Foresight.DataAccess.RoomFeeHistory.GetRoomFeeHistoryListByContractDivideIDList(DivideIDList);
            if (historylist.Length > 0)
            {
                WebUtil.WriteJson(context, new { status = false, error = "选中的账单已收费，禁止此操作" });
                return;
            }
            DateTime WriteDate = getTimeValue(context, "tdWirteDate");
            DateTime StartTime = getTimeValue(context, "tdStartTime");
            DateTime EndTime = getTimeValue(context, "tdEndTime");
            decimal SellCost = getDecimalValue(context, "tdSellCost");
            string DivideType = getValue(context, "tdDivideType");
            decimal DividePercent = getDecimalValue(context, "tdFixedPercent");
            string Remark = getValue(context, "tdRemark");
            foreach (var DivideID in DivideIDList)
            {
                Contract_Divide data = Foresight.DataAccess.Contract_Divide.GetContract_Divide(DivideID);
                if (data == null)
                {
                    continue;
                }
                data.WriteDate = WriteDate > DateTime.MinValue ? WriteDate : data.WriteDate;
                data.StartTime = StartTime > DateTime.MinValue ? StartTime : data.StartTime;
                data.EndTime = EndTime > DateTime.MinValue ? EndTime : data.EndTime;
                data.SellCost = SellCost > 0 ? SellCost : data.SellCost;
                data.DivideType = !string.IsNullOrEmpty(DivideType) ? DivideType : data.DivideType;
                List<Contract_DivideType> datatype_list = new List<Contract_DivideType>();
                if (data.DivideType.Equals(Utility.EnumModel.ContractDivideTypeDefine.jietipercent.ToString()))
                {
                    List<Utility.ContractDivideTypeModel> typelist = JsonConvert.DeserializeObject<List<Utility.ContractDivideTypeModel>>(context.Request["type_list"]);
                    foreach (var item in typelist)
                    {
                        Contract_DivideType data_type = new Contract_DivideType();
                        data_type.AddTime = DateTime.Now;
                        data_type.DivideType = data.DivideType;
                        data_type.Divide_Percent = item.Divide_Percent;
                        data_type.DivideStartCost = item.DivideStartCost;
                        data_type.DivideEndCost = item.DivideEndCost;
                        datatype_list.Add(data_type);
                    }
                }
                else
                {
                    if (DividePercent > 0)
                    {
                        Contract_DivideType data_type = new Contract_DivideType();
                        data_type.AddTime = DateTime.Now;
                        data_type.DivideType = data.DivideType;
                        data_type.Divide_Percent = DividePercent;
                        datatype_list.Add(data_type);
                    }
                }
                data.Remark = !string.IsNullOrEmpty(Remark) ? Remark : data.Remark;
                using (SqlHelper helper = new SqlHelper())
                {
                    try
                    {
                        helper.BeginTransaction();
                        data.Save(helper);
                        if (datatype_list.Count > 0)
                        {
                            string cmdtext = "delete from [Contract_DivideType] where [Contract_DivideID]=@Contract_DivideID;";
                            List<SqlParameter> parameters = new List<SqlParameter>();
                            parameters.Add(new SqlParameter("@Contract_DivideID", data.ID));
                            helper.Execute(cmdtext, CommandType.Text, parameters);
                            foreach (var item in datatype_list)
                            {
                                item.Contract_DivideID = data.ID;
                                item.Save(helper);
                            }
                        }
                        helper.Commit();
                    }
                    catch (Exception ex)
                    {
                        helper.Rollback();
                        LogHelper.WriteError("ContractHandler", "savecontractdivieprocess", ex);
                        WebUtil.WriteJson(context, new { status = false });
                        return;
                    }
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void removecontractdivide(HttpContext context)
        {
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(context.Request["IDList"]);
            if (IDList.Count > 0)
            {
                var historylist = Foresight.DataAccess.RoomFeeHistory.GetRoomFeeHistoryListByContractDivideIDList(IDList);
                if (historylist.Length > 0)
                {
                    WebUtil.WriteJson(context, new { status = false, error = "账单已收，禁止删除" });
                    return;
                }
                using (SqlHelper helper = new SqlHelper())
                {
                    try
                    {
                        helper.BeginTransaction();
                        string cmdtext = string.Empty;
                        cmdtext += "delete from [RoomFee] where isnull([ContractDivideID],0) in (" + string.Join(",", IDList.ToArray()) + ")";
                        cmdtext += "delete from [Contract_DivideType] where Contract_DivideID in (" + string.Join(",", IDList.ToArray()) + ")";
                        cmdtext += "delete from [Contract_Divide] where ID in (" + string.Join(",", IDList.ToArray()) + ")";
                        helper.Execute(cmdtext, CommandType.Text, new List<SqlParameter>());
                        helper.Commit();
                    }
                    catch (Exception ex)
                    {
                        LogHelper.WriteError(LogModule, "removecontractdivide", ex);
                        helper.Rollback();
                        WebUtil.WriteJson(context, new { status = false });
                        return;
                    }
                }
                #region 删除日志
                var user = WebUtil.GetUser(context);
                APPCode.CommHelper.SaveOperationLog(string.Join(",", IDList.ToArray()), Utility.EnumModel.OperationModule.Contract_DivideDelete.ToString(), "联营分成删除", user.UserID.ToString(), "Contract_Divide", IsHide: true);
                APPCode.CommHelper.SaveOperationLog("用户" + user.LoginName + "删除了联营分成", Utility.EnumModel.OperationModule.Contract_DivideDelete.ToString(), "联营分成删除", user.UserID.ToString(), "Contract_Divide");
                #endregion
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void savecontractdivieedit(HttpContext context)
        {
            int DivideID = WebUtil.GetIntValue(context, "DivideID");
            Contract_Divide data = Foresight.DataAccess.Contract_Divide.GetContract_Divide(DivideID);
            if (data == null)
            {
                WebUtil.WriteJson(context, new { status = false, error = "账单不存在" });
                return;
            }
            List<int> IDList = new List<int>();
            IDList.Add(data.ID);
            var historylist = Foresight.DataAccess.RoomFeeHistory.GetRoomFeeHistoryListByContractDivideIDList(IDList);
            if (historylist.Length > 0)
            {
                WebUtil.WriteJson(context, new { status = false, error = "账单已收费，禁止修改" });
                return;
            }
            data.RentName = getValue(context, "tdRentName");
            data.WriteDate = getTimeValue(context, "tdWirteDate");
            data.StartTime = getTimeValue(context, "tdStartTime");
            data.EndTime = getTimeValue(context, "tdEndTime");
            data.SellCost = getDecimalValue(context, "tdSellCost");
            data.DivideType = getValue(context, "tdDivideType");
            List<Contract_DivideType> datatype_list = new List<Contract_DivideType>();
            if (data.DivideType.Equals(Utility.EnumModel.ContractDivideTypeDefine.jietipercent.ToString()))
            {
                List<Utility.ContractDivideTypeModel> typelist = JsonConvert.DeserializeObject<List<Utility.ContractDivideTypeModel>>(context.Request["type_list"]);
                foreach (var item in typelist)
                {
                    Contract_DivideType data_type = null;
                    if (item.ID > 0)
                    {
                        data_type = Contract_DivideType.GetContract_DivideType(item.ID);
                    }
                    if (data_type == null)
                    {
                        data_type = new Contract_DivideType();
                        data_type.AddTime = DateTime.Now;
                    }
                    data_type.DivideType = data.DivideType;
                    data_type.Divide_Percent = item.Divide_Percent;
                    data_type.DivideStartCost = item.DivideStartCost;
                    data_type.DivideEndCost = item.DivideEndCost;
                    datatype_list.Add(data_type);
                }
            }
            else
            {
                decimal DividePercent = getDecimalValue(context, "tdFixedPercent");
                Contract_DivideType data_type = Foresight.DataAccess.Contract_DivideType.GetContract_DivideTypeList(data.ID).FirstOrDefault(p => p.DivideType.Equals(data.DivideType));
                if (data_type == null)
                {
                    data_type = new Contract_DivideType();
                    data_type.AddTime = DateTime.Now;
                }
                data_type.DivideType = data.DivideType;
                data_type.Divide_Percent = DividePercent;
                datatype_list.Add(data_type);
            }
            data.Remark = getValue(context, "tdRemark");
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    data.Save(helper);
                    foreach (var item in datatype_list)
                    {
                        item.Contract_DivideID = data.ID;
                        item.Save(helper);
                    }
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError("ContractHandler", "savecontractdivieedit", ex);
                    WebUtil.WriteJson(context, new { status = false });
                    return;
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void removecontractdividetype(HttpContext context)
        {
            int DivideID = WebUtil.GetIntValue(context, "DivideID");
            List<int> IDList = new List<int>();
            IDList.Add(DivideID);
            var historylist = Foresight.DataAccess.RoomFeeHistory.GetRoomFeeHistoryListByContractDivideIDList(IDList);
            if (historylist.Length > 0)
            {
                WebUtil.WriteJson(context, new { status = false, error = "账单已收费，禁止删除" });
                return;
            }
            int ID = WebUtil.GetIntValue(context, "ID");
            Foresight.DataAccess.Contract_DivideType.DeleteContract_DivideType(ID);
            WebUtil.WriteJson(context, new { status = true });
        }
        private void getcontractdividestypebyid(HttpContext context)
        {
            int DivideID = WebUtil.GetIntValue(context, "DivideID");
            var list = Foresight.DataAccess.Contract_DivideType.GetContract_DivideTypeList(DivideID).Where(p => p.DivideType.Equals(Utility.EnumModel.ContractDivideTypeDefine.jietipercent.ToString())).OrderBy(p => p.DivideStartCost).ToArray();
            int count = 0;
            var items = list.Select(p =>
            {
                count++;
                var item = new { ID = p.ID, count = count, DivideStartCost = p.DivideStartCost, DivideEndCost = p.DivideEndCost, Divide_Percent = p.Divide_Percent };
                return item;
            });
            WebUtil.WriteJson(context, new { status = true, list = items });

        }
        private void activecontractdivide(HttpContext context)
        {
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(context.Request["IDList"]);
            var historylist = Foresight.DataAccess.RoomFeeHistory.GetRoomFeeHistoryListByContractDivideIDList(IDList);
            if (historylist.Length > 0)
            {
                WebUtil.WriteJson(context, new { status = false, error = "选中的账单包含已收费的账单，操作取消" });
                return;
            }
            var fee_list = RoomFeeAnalysis.GetRoomFeeAnalysisListByContractDivideIDList(IDList);
            if (fee_list.Length > 0)
            {
                WebUtil.WriteJson(context, new { status = false, error = "选中的账单包含已生效的账单，操作取消" });
                return;
            }
            var contract_list = Foresight.DataAccess.Contract.GetContractListByDivideIDList(IDList).Where(p => !p.ContractStatus.Equals(Utility.EnumModel.ContractStatus.tongguo.ToString())).ToArray();
            if (contract_list.Length > 0)
            {
                WebUtil.WriteJson(context, new { status = false, error = "选中的账单包含未生效的合同，操作取消" });
                return;
            }
            var list = Foresight.DataAccess.Contract_Divide.GetContract_DivideList(IDList);
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    foreach (var item in list)
                    {
                        item.ChargeStatus = 0;
                        item.Save(helper);
                    }
                    foreach (var item in list)
                    {
                        var roomfee = Foresight.DataAccess.RoomFee.SetInfo_RoomFee(0, item.StartTime, item.EndTime, 0, 0, 0, item.ChargeID, Remark: item.Remark, OnlyOnceCharge: true, ContractID: item.ContractID, ContractDivideID: item.ID, cansave: true, helper: helper);
                    }
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError("ContractHandler", "activecontractdivide", ex);
                    WebUtil.WriteJson(context, new { status = false });
                    return;
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void savecontractdiviecreate(HttpContext context)
        {
            string IDs = context.Request["IDList"];
            List<int> IDList = new List<int>();
            if (!string.IsNullOrEmpty(IDs))
            {
                IDList = Utility.JsonConvert.DeserializeObject<List<int>>(IDs);
            }
            if (IDList.Count == 0)
            {
                WebUtil.WriteJson(context, new { status = false, error = "请选择扣点合同" });
                return;
            }
            var contractList = Foresight.DataAccess.Contract.GetContractListByIDList(IDList);
            List<Utility.ContractDivideTypeModel> typelist = new List<ContractDivideTypeModel>();
            if (!string.IsNullOrEmpty(context.Request["type_list"]))
            {
                typelist = JsonConvert.DeserializeObject<List<Utility.ContractDivideTypeModel>>(context.Request["type_list"]);
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    foreach (var ContractID in IDList)
                    {
                        var contract = contractList.FirstOrDefault(p => p.ID == ContractID);
                        if (contract == null)
                        {
                            continue;
                        }
                        if (!contract.ContractStatus.Equals(Utility.EnumModel.ContractStatus.tongguo.ToString()))
                        {
                            continue;
                        }
                        decimal DividePercent = getDecimalValue(context, "tdFixedPercent");
                        var data = new Foresight.DataAccess.Contract_Divide();
                        data.AddTime = DateTime.Now;
                        data.ChargeStatus = 2;
                        data.ContractID = contract.ID;
                        data.RentName = contract.RentName;
                        data.WriteDate = getTimeValue(context, "tdWirteDate");
                        data.StartTime = getTimeValue(context, "tdStartTime");
                        data.EndTime = getTimeValue(context, "tdEndTime");
                        data.SellCost = getDecimalValue(context, "tdSellCost");
                        data.DivideType = getValue(context, "tdDivideType");
                        data.ChargeID = getIntValue(context, "tdChargeSummary");
                        data.Remark = getValue(context, "tdRemark");
                        if (string.IsNullOrEmpty(data.DivideType))
                        {
                            data.DivideType = "fixedpercent";
                            data.SellCost = contract.ContractDivideSellCost;
                            DividePercent = contract.ContractDevicePercent;
                        }
                        data.Save(helper);
                        if (data.DivideType.Equals(Utility.EnumModel.ContractDivideTypeDefine.jietipercent.ToString()))
                        {
                            foreach (var item in typelist)
                            {
                                var data_type = new Foresight.DataAccess.Contract_DivideType();
                                data_type.DivideType = data.DivideType;
                                data_type.Divide_Percent = item.Divide_Percent;
                                data_type.DivideStartCost = item.DivideStartCost;
                                data_type.DivideEndCost = item.DivideEndCost;
                                data_type.AddTime = DateTime.Now;
                                data_type.Contract_DivideID = data.ID;
                                data_type.Save(helper);
                            }
                        }
                        else
                        {
                            var data_type = new Foresight.DataAccess.Contract_DivideType();
                            data_type.DivideType = data.DivideType;
                            data_type.Divide_Percent = DividePercent;
                            data_type.AddTime = DateTime.Now;
                            data_type.Contract_DivideID = data.ID;
                            data_type.Save(helper);
                        }
                    }
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError("ContractHandler", "savecontractdiviecreate", ex);
                    WebUtil.WriteJson(context, new { status = false });
                    return;
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void loadcontractdividegrid(HttpContext context)
        {
            try
            {
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                string Keywords = context.Request.Params["Keywords"];
                DateTime StartTime = WebUtil.GetDateValue(context, "StartTime");
                DateTime EndTime = WebUtil.GetDateValue(context, "EndTime");
                bool canexport = WebUtil.GetBoolValue(context, "canexport");
                int ContractID = WebUtil.GetIntValue(context, "ContractID");
                string RoomIDs = context.Request.Params["RoomIDs"];
                List<int> RoomIDList = new List<int>();
                if (!string.IsNullOrEmpty(RoomIDs))
                {
                    RoomIDList = JsonConvert.DeserializeObject<List<int>>(RoomIDs);
                }
                string ProjectIDs = context.Request.Params["ProjectIDs"];
                List<int> ProjectIDList = new List<int>();
                if (RoomIDList.Count == 0)
                {
                    if (!string.IsNullOrEmpty(ProjectIDs))
                    {
                        ProjectIDList = JsonConvert.DeserializeObject<List<int>>(ProjectIDs).Where(p => p != 1).ToList();
                    }
                    ProjectIDList = WebUtil.GetMyProjects(WebUtil.GetUser(context).UserID, ProjectIDList).Where(p => p.ID != 1).Select(p => p.ID).ToList();
                }
                DataGrid dg = Foresight.DataAccess.ViewContractDivide.GetViewContractDivideGridByKeywords(Keywords, StartTime, EndTime, "order by [AddTime] desc", startRowIndex, pageSize, ProjectIDList, RoomIDList, ContractID, canexport: canexport);
                if (canexport)
                {
                    string downloadurl = string.Empty;
                    string error = string.Empty;
                    bool status = APPCode.ExportHelper.DownLoadContractEarnData(dg, out downloadurl, out error);
                    WebUtil.WriteJson(context, new { status = status, downloadurl = downloadurl, error = error });
                    return;
                }
                WebUtil.WriteJson(context, dg);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.WriteError(LogModule, "命令:loadcontractdividegrid", ex);
                context.Response.Write("{\"rows\":[],\"total\":0,\"page\":0}");
            }
        }
        private void savecontractprintcontent(HttpContext context)
        {
            int ContractID = WebUtil.GetIntValue(context, "ContractID");
            int TemplateID = WebUtil.GetIntValue(context, "TemplateID");
            var contract = Foresight.DataAccess.Contract.GetContract(ContractID);
            var template = Foresight.DataAccess.Contract_Template.GetContract_Template(TemplateID);
            if (contract == null || template == null)
            {
                WebUtil.WriteJson(context, new { status = false });
                return;
            }
            var contract_print = Foresight.DataAccess.Contract_Print.GetContract_PrintByContractID(contract.ID, template.ID);
            if (contract_print == null)
            {
                contract_print = new Contract_Print();
                contract_print.AddTime = DateTime.Now;
                contract_print.ContractID = contract.ID;
                contract_print.ContractTemplateID = template.ID;
            }
            contract_print.PrintContent = context.Request["HTMLContent"];
            contract_print.Save();
            WebUtil.WriteJson(context, new { status = true, ID = contract_print.ID });
        }
        private void zuofeicontract(HttpContext context)
        {
            string IDs = context.Request.Params["IDList"];
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(IDs);
            if (IDList.Count > 0)
            {
                string cmdtext = string.Empty;
                cmdtext += "delete from [RoomFee] where isnull([ContractID],0) in (select ID from [Contract] where [ID] in (" + string.Join(",", IDList.ToArray()) + ") and [ContractStatus]='" + Utility.EnumModel.ContractStatus.zhongzhi.ToString() + "');";
                cmdtext += "update [Contract] set [ContractStatus]='" + Utility.EnumModel.ContractStatus.deleted.ToString() + "' where [ID] in (" + string.Join(",", IDList.ToArray()) + ") and [ContractStatus]='" + Utility.EnumModel.ContractStatus.zhongzhi.ToString() + "';";
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
                        helper.Rollback();
                        Utility.LogHelper.WriteError("ContractHandler", "命令:zuofeicontract", ex);
                        WebUtil.WriteJson(context, new { status = false });
                        return;
                    }
                }
                #region 删除日志
                var user = WebUtil.GetUser(context);
                APPCode.CommHelper.SaveOperationLog(string.Join(",", IDList.ToArray()), Utility.EnumModel.OperationModule.ContractCancel.ToString(), "合同作废", user.UserID.ToString(), "Contract", user.LoginName, IsHide: true);
                APPCode.CommHelper.SaveOperationLog("用户" + user.LoginName + "作废了合同", Utility.EnumModel.OperationModule.ContractCancel.ToString(), "合同作废", user.UserID.ToString(), "Contract", user.LoginName);
                #endregion
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void removecontractfreetime(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            Foresight.DataAccess.Contract_FreeTime.DeleteContract_FreeTime(ID);
            WebUtil.WriteJson(context, new { status = true });
        }
        private void getcontractfreetime(HttpContext context)
        {
            int ContractID = WebUtil.GetIntValue(context, "ContractID");
            var list = Foresight.DataAccess.Contract_FreeTime.GetContract_FreeTimeList(ContractID);
            var ChargeList = Foresight.DataAccess.ChargeSummary.GetChargeSummaries();
            int count = 0;
            var items = list.Select(p =>
            {
                count++;
                string ChargeNames = string.Empty;
                if (!string.IsNullOrEmpty(p.FreeChargeIDs))
                {
                    List<int> FreeChargeIDList = p.FreeChargeIDs.Split(',').Select(q => { return Convert.ToInt32(q); }).ToList();
                    var sub_chargename_list = ChargeList.Where(q => FreeChargeIDList.Contains(q.ID)).Select(q => q.Name).ToArray();
                    if (sub_chargename_list.Length > 0)
                    {
                        ChargeNames = string.Join(",", sub_chargename_list);
                    }
                }
                string FreeChargeIDs = string.Empty;
                if (!string.IsNullOrEmpty(p.FreeChargeIDs))
                {
                    FreeChargeIDs = "[" + p.FreeChargeIDs + "]";
                }
                var item = new { ID = p.ID, StartTime = p.FreeStartTime.ToString("yyyy-MM-dd"), EndTime = p.FreeEndTime.ToString("yyyy-MM-dd"), FreeType = p.FreeType, FreeChargeNames = ChargeNames, FreeChargeIDs = FreeChargeIDs, count = count };
                return item;
            });
            WebUtil.WriteJson(context, new { status = true, list = items });
        }
        private void removecontracttemplate(HttpContext context)
        {
            string IDs = context.Request["IDList"];
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
                        string cmdtext = "delete from [Contract_Template] where ID in (" + string.Join(",", IDList.ToArray()) + ")";
                        helper.Execute(cmdtext, CommandType.Text, new List<SqlParameter>());
                        helper.Commit();
                    }
                    catch (Exception ex)
                    {
                        helper.Rollback();
                        LogHelper.WriteError("ContractHandler", "removecontracttemplate", ex);
                        WebUtil.WriteJson(context, new { status = false });
                        return;
                    }
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void loadcontracttemplategrid(HttpContext context)
        {
            try
            {
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                string Keywords = context.Request.Params["Keywords"];
                int Status = 0;
                if (!string.IsNullOrEmpty(context.Request["TemplateStatus"]))
                {
                    Status = WebUtil.GetIntValue(context, "TemplateStatus");
                }
                DataGrid dg = Foresight.DataAccess.Contract_Template.GetContract_TemplateGridByKeywords(Keywords, Status, "order by [AddTime] desc", startRowIndex, pageSize);
                string result = JsonConvert.SerializeObject(dg);
                context.Response.Write(result);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.WriteError(LogModule, "命令:loadcontracttemplategrid", ex);
                context.Response.Write("{\"rows\":[],\"total\":0,\"page\":0}");
            }
        }
        private void savecontracttemplate(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            var template = Foresight.DataAccess.Contract_Template.GetContract_Template(ID);
            if (template == null)
            {
                template = new Contract_Template();
                template.AddTime = DateTime.Now;
                template.TemplateStatus = 1;
            }
            template.TemplateNo = context.Request["TemplateNo"];
            template.TemplateName = context.Request["TemplateName"];
            template.TemplateSummary = context.Request["TemplateSummary"];
            template.TemplateContent = context.Request["HTMLContent"];
            template.Save();
            WebUtil.WriteJson(context, new { status = true });
        }
        private void removezukong(HttpContext context)
        {
            string ids = context.Request["ids"];
            if (string.IsNullOrEmpty(ids))
            {
                WebUtil.WriteJson(context, new { status = false, msg = "参数不能为空" });
                return;
            }
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(ids);
            if (IDList.Count == 0)
            {
                WebUtil.WriteJson(context, new { status = false, msg = "参数不能为空" });
                return;
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    string cmdtext = "delete from [Contract_ZuKong] where ID in (" + string.Join(",", IDList.ToArray()) + ")";
                    helper.Execute(cmdtext, CommandType.Text, new List<SqlParameter>());
                    helper.Commit();
                }
                catch (Exception)
                {
                    helper.Rollback();
                    WebUtil.WriteJson(context, new { status = false });
                    return;
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void savezukong(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            var data = Foresight.DataAccess.Contract_ZuKong.GetContract_ZuKong(ID);
            if (data != null)
            {
                data.RoomName = context.Request["RoomName"];
                data.RoomState = context.Request["RoomState"];
                data.RoomOwner = context.Request["RoomOwner"];
                data.Save();
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void getzuzhonglist(HttpContext context)
        {
            string RoomIDs = context.Request.Params["RoomIDs"];
            List<int> RoomIDList = new List<int>();
            if (!string.IsNullOrEmpty(RoomIDs))
            {
                RoomIDList = JsonConvert.DeserializeObject<List<int>>(RoomIDs);
            }
            string ProjectIDs = context.Request.Params["ProjectIDs"];
            List<int> ProjectIDList = new List<int>();
            if (RoomIDList.Count == 0)
            {
                if (!string.IsNullOrEmpty(ProjectIDs))
                {
                    ProjectIDList = JsonConvert.DeserializeObject<List<int>>(ProjectIDs).Where(p => p != 1).ToList();
                }
                ProjectIDList = WebUtil.GetMyProjects(WebUtil.GetUser(context).UserID, ProjectIDList).Where(p => p.ID != 1).Select(p => p.ID).ToList();
            }
            string Keywords = context.Request["keywords"];
            int RoomStateID = WebUtil.GetIntValue(context, "RoomStateID");
            int RoomFeeState = WebUtil.GetIntValue(context, "RoomFeeState");
            DateTime StartTime = WebUtil.GetDateValue(context, "StartTime");
            DateTime EndTime = WebUtil.GetDateValue(context, "EndTime");
            var zukong_list = Foresight.DataAccess.Contract_ZuKong.GetContract_ZuKongListByKeywords(RoomIDList, ProjectIDList, Keywords, RoomStateID, RoomFeeState, StartTime, EndTime, UserID: WebUtil.GetUser(context).UserID);
            var roomstate_list = Foresight.DataAccess.RoomState.GetRoomStates();
            var roombasic_list = Foresight.DataAccess.ViewRoomBasic.GetViewRoomBasicByRoomIDList(zukong_list.Select(p => p.RoomID).ToList());
            var items = zukong_list.Select(p =>
            {
                var roombasic = roombasic_list.FirstOrDefault(q => q.RoomID == p.RoomID);
                if (roombasic != null)
                {
                    var roomstate = roomstate_list.FirstOrDefault(q => q.ID.Equals(roombasic.RoomStateID));
                    var item = new { ID = p.ID, RoomName = roombasic.Name, RoomID = roombasic.RoomID, RoomState = roomstate != null ? roomstate.Name : "", RoomOwner = roombasic.RelationName, RoomFee = p.RoomFee, canedit = false, BackColor = roomstate != null ? roomstate.BackColor : "", ischecked = false };
                    return item;
                }
                else
                {
                    var item = new { ID = p.ID, RoomName = "", RoomID = p.RoomID, RoomState = "", RoomOwner = "", RoomFee = p.RoomFee, canedit = false, BackColor = "", ischecked = false };
                    return item;
                }
            });
            WebUtil.WriteJson(context, new { status = true, list = items });
        }
        private void createzuzhong(HttpContext context)
        {
            string RoomIDs = context.Request.Params["RoomIDs"];
            List<int> RoomIDList = new List<int>();
            if (!string.IsNullOrEmpty(RoomIDs))
            {
                RoomIDList = JsonConvert.DeserializeObject<List<int>>(RoomIDs);
            }
            string ProjectIDs = context.Request.Params["ProjectIDs"];
            List<int> ProjectIDList = new List<int>();
            if (RoomIDList.Count == 0)
            {
                if (!string.IsNullOrEmpty(ProjectIDs))
                {
                    ProjectIDList = JsonConvert.DeserializeObject<List<int>>(ProjectIDs).Where(p => p != 1).ToList();
                }
                ProjectIDList = WebUtil.GetMyProjects(WebUtil.GetUser(context).UserID, ProjectIDList).Where(p => p.ID != 1).Select(p => p.ID).ToList();
            }
            var zukong_list = Foresight.DataAccess.Contract_ZuKong.GetContract_ZuKongListByKeywords(RoomIDList, ProjectIDList, UserID: WebUtil.GetUser(context).UserID);
            var viewroom_list = Foresight.DataAccess.ViewRoomBasic.GetRoomBasicListByKeywords(RoomIDList, ProjectIDList);
            var zukong_roomidlist = zukong_list.Select(p => p.RoomID).ToList();
            string cmdtext = string.Empty;
            foreach (var item in viewroom_list)
            {
                if (zukong_roomidlist.Contains(item.RoomID))
                {
                    continue;
                }
                string Name = !string.IsNullOrEmpty(item.Name) ? "'" + item.Name + "'" : "NULL";
                string RoomState = !string.IsNullOrEmpty(item.RoomState) ? "'" + item.RoomState + "'" : "NULL";
                string RelationName = !string.IsNullOrEmpty(item.RelationName) ? "'" + item.RelationName + "'" : "NULL";
                int RoomStateID = item.RoomStateID > 0 ? item.RoomStateID : 0;
                cmdtext += @"
                insert into [dbo].[Contract_ZuKong]
               ([RoomID]
               ,[RoomName]
               ,[RoomState]
               ,[RoomOwner]
               ,[RoomFee]
               ,[AddTime]
               ,[RoomStateID])
               VALUES
               (" + item.RoomID + "," + Name + "," + RoomState + "," + RelationName + ",0,GETDATE()," + RoomStateID + ");";
            }
            if (!string.IsNullOrEmpty(cmdtext))
            {
                using (SqlHelper helper = new SqlHelper())
                {
                    try
                    {
                        helper.BeginTransaction();
                        helper.Execute(cmdtext, CommandType.Text, new List<SqlParameter>());
                        helper.Commit();
                    }
                    catch (Exception)
                    {
                        helper.Rollback();
                        WebUtil.WriteJson(context, new { status = false });
                    }
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void removecontracttemppricebyguid(HttpContext context)
        {
            string GUID = context.Request.Params["guid"];
            if (!string.IsNullOrEmpty(GUID))
            {
                string cmdtext = string.Empty;
                cmdtext += "delete from [Contract_TempPrice] where [GUID]=@GUID;";
                var parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@GUID", GUID));
                using (SqlHelper helper = new SqlHelper())
                {
                    try
                    {
                        helper.BeginTransaction();
                        helper.Execute(cmdtext, CommandType.Text, parameters);
                        helper.Commit();
                        WebUtil.WriteJson(context, new { status = true });
                    }
                    catch (Exception ex)
                    {
                        helper.Rollback();
                        Utility.LogHelper.WriteError("ContractHandler", "命令:removecontracttemppricebyguid", ex);
                        WebUtil.WriteJson(context, new { status = false });
                    }
                }
            }
            else
            {
                WebUtil.WriteJson(context, new { status = true });
            }
        }
        private void checkweiyuestatus(HttpContext context)
        {
            string RoomIDs = context.Request["RoomIDs"];
            int[] RoomIDList = JsonConvert.DeserializeObject<int[]>(RoomIDs);
            CommHelper.CheckRoomFeeWeiYue(RoomIDList);
            context.Response.Write("{\"status\":true}");
        }
        private void removecontracttempprice(HttpContext context)
        {
            string IDs = context.Request.Params["IDList"];
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(IDs);
            if (IDList.Count > 0)
            {
                string cmdtext = string.Empty;
                cmdtext += "delete from [Contract_TempPrice] where [ID] in (" + string.Join(",", IDList.ToArray()) + ");";
                cmdtext += "delete from [Contract_RoomCharge] where [Contract_TempPriceID] in (" + string.Join(",", IDList.ToArray()) + ");";
                cmdtext += "delete from [RoomFee] where [Contract_RoomChargeID] in (select [ID] from [Contract_RoomCharge] where [Contract_TempPriceID] in (" + string.Join(",", IDList.ToArray()) + "));";
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
                        helper.Rollback();
                        Utility.LogHelper.WriteError("ContractHandler", "命令:removecontracttempprice", ex);
                        WebUtil.WriteJson(context, new { status = false });
                        return;
                    }
                }
                #region 删除日志
                var user = WebUtil.GetUser(context);
                APPCode.CommHelper.SaveOperationLog(string.Join(",", IDList.ToArray()), Utility.EnumModel.OperationModule.Contract_TempPriceDelete.ToString(), "合同临时价格删除", user.UserID.ToString(), "Contract_TempPrice", user.LoginName, IsHide: true);
                APPCode.CommHelper.SaveOperationLog("用户" + user.LoginName + "删除了合同临时价格", Utility.EnumModel.OperationModule.Contract_TempPriceDelete.ToString(), "合同临时价格删除", user.UserID.ToString(), "Contract_TempPrice", user.LoginName);
                #endregion
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void addcontracttemppricelistnew(HttpContext context)
        {
            int CalculateMonth = WebUtil.GetIntValue(context, "CalculateMonth");
            DateTime StartTime = WebUtil.GetDateValue(context, "StartTime");
            DateTime EndTime = WebUtil.GetDateValue(context, "EndTime");
            decimal RoomUnitPrice = WebUtil.GetDecimalValue(context, "RoomUnitPrice");
            string guid = context.Request["guid"];
            string TempList = context.Request["TempList"];
            int CategoryID = WebUtil.GetIntValue(context, "CategoryID");
            int FeeType = WebUtil.GetIntValue(context, "FeeType");
            DateTime FirstReadyChargeTime = WebUtil.GetDateValue(context, "FirstReadyChargeTime");
            DateTime FirstStartTime = WebUtil.GetDateValue(context, "FirstStartTime");
            int FirstReadyChargeDay = WebUtil.GetIntValue(context, "FirstReadyChargeDay");
            List<Utility.ContractTempPrice> list = new List<Utility.ContractTempPrice>();
            string CalculateTypeList = context.Request["CalculateTypeList"];
            List<Utility.ContractCalculateTypeModel> calculateTypeList = new List<Utility.ContractCalculateTypeModel>();
            if (FeeType == 1)
            {
                if (!string.IsNullOrEmpty(TempList))
                {
                    list = JsonConvert.DeserializeObject<List<Utility.ContractTempPrice>>(TempList);
                }
                if (!string.IsNullOrEmpty(CalculateTypeList))
                {
                    calculateTypeList = JsonConvert.DeserializeObject<List<Utility.ContractCalculateTypeModel>>(CalculateTypeList);
                    calculateTypeList = calculateTypeList.Where(p => p.LastReadyChargePriceTime >= StartTime).ToList();
                }
            }
            List<Contract_TempPrice> templist = new List<Contract_TempPrice>();
            int ChargeID = WebUtil.GetIntValue(context, "ChargeID");
            string RoomIDs = context.Request["RoomIDList"];
            List<int> RoomIDList = new List<int>();
            if (!string.IsNullOrEmpty(RoomIDs))
            {
                RoomIDList = JsonConvert.DeserializeObject<List<int>>(RoomIDs);
            }
            RoomIDList = RoomIDList.Where(p => p != 0).ToList();
            int canrent = WebUtil.GetIntValue(context, "canrent");
            DateTime RentToTime = DateTime.MinValue;
            if (canrent == 1)
            {
                RentToTime = WebUtil.GetDateValue(context, "RentToTime");
                if (RentToTime < EndTime.AddDays(1))
                {
                    WebUtil.WriteJson(context, new { statu = false, error = "合同结束日期不能大于续租日期" });
                    return;
                }
                StartTime = EndTime.AddDays(1);
                EndTime = RentToTime;
            }
            if (list.Count == 0)
            {
                if (FeeType != 1)
                {
                    var data = Foresight.DataAccess.Contract_TempPrice.Add_Contract_TempPrice(RoomUnitPrice, StartTime, EndTime, string.Empty, 0, 0, guid, FirstReadyChargeTime, StartTime, EndTime, RoomUnitPrice);
                    templist.Add(data);
                }
                else
                {
                    if (CalculateMonth <= 0)
                    {
                        WebUtil.WriteJson(context, new { status = true, error = "请重新收费周期" });
                        return;
                    }
                    if (StartTime == DateTime.MinValue)
                    {
                        WebUtil.WriteJson(context, new { status = true, error = "请重新合同开始日期" });
                        return;
                    }
                    if (EndTime == DateTime.MinValue)
                    {
                        WebUtil.WriteJson(context, new { status = true, error = "请重新合同截止日期" });
                        return;
                    }
                    var tempList = CommHelper.GetContractTempPriceList(calculateTypeList, StartTime, EndTime, FirstReadyChargeTime, RoomUnitPrice, CalculateMonth, FirstStartTime, FirstReadyChargeDay);
                    foreach (var item in tempList)
                    {
                        var data = Foresight.DataAccess.Contract_TempPrice.Add_Contract_TempPrice(RoomUnitPrice, StartTime, EndTime, item.CalculateType, item.CalculatePercent, item.CalculateAmount, guid, item.ReadyChargeTime, item.StartTime, item.EndTime, item.CalculateValue);
                        templist.Add(data);
                    }
                }
            }
            else
            {
                int i = 0;
                foreach (var item in list)
                {
                    Contract_TempPrice data = null;
                    if (item.ID > 0)
                    {
                        data = Contract_TempPrice.GetContract_TempPrice(item.ID);
                    }
                    if (data == null)
                    {
                        data = new Contract_TempPrice();
                        data.AddTime = DateTime.Now;
                        if (FirstReadyChargeTime > DateTime.MinValue)
                        {
                            data.ReadyChargeTime = FirstReadyChargeTime.AddMonths(i * CalculateMonth);
                        }
                    }
                    data.CalculatePrice = item.CalculatePrice;
                    data.CalculateStartTime = item.CalculateStartTime;
                    data.CalculateEndTime = item.CalculateEndTime;
                    data.CalculateCost = item.CalculateCost;
                    data.ReadyChargeTime = item.ReadyChargeTime;
                    templist.Add(data);
                    i++;
                }
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    foreach (var item in templist)
                    {
                        item.BasicPrice = RoomUnitPrice;
                        item.BasicStartTime = StartTime;
                        item.BasicEndTime = EndTime;
                        item.GUID = guid;
                        item.ChargeID = ChargeID;
                        item.RoomUseCount = 0;
                        if (RoomIDList.Count == 1)
                        {
                            item.RoomID = RoomIDList[0];
                        }
                        item.Save(helper);
                    }
                    helper.Commit();
                    WebUtil.WriteJson(context, new { status = true });
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    Utility.LogHelper.WriteError("ContractHandler", "命令:addcontracttemppricelistnew", ex);
                    WebUtil.WriteJson(context, new { status = false });
                }
            }
        }
        private void addcontracttemppricelist(HttpContext context)
        {
            int CalculateMonth = WebUtil.GetIntValue(context, "CalculateMonth");
            string CalculateType = context.Request["CalculateType"];
            decimal CalculatePercent = WebUtil.GetDecimalValue(context, "CalculatePercent");
            decimal CalculateAmount = WebUtil.GetDecimalValue(context, "CalculateAmount");
            DateTime StartTime = WebUtil.GetDateValue(context, "StartTime");
            DateTime EndTime = WebUtil.GetDateValue(context, "EndTime");
            decimal RoomUnitPrice = WebUtil.GetDecimalValue(context, "RoomUnitPrice");
            string guid = context.Request["guid"];
            string TempList = context.Request["TempList"];
            int IsAutoChagePrice = WebUtil.GetIntValue(context, "IsAutoChagePrice");
            int CategoryID = WebUtil.GetIntValue(context, "CategoryID");
            int FeeType = WebUtil.GetIntValue(context, "FeeType");
            DateTime FirstReadyChargeTime = WebUtil.GetDateValue(context, "FirstReadyChargeTime");
            int CalcualtePriceMonth = WebUtil.GetIntValue(context, "CalcualtePriceMonth");
            DateTime FirstReadyChargePriceTime = WebUtil.GetDateValue(context, "FirstReadyChargePriceTime");
            List<Utility.ContractTempPrice> list = new List<Utility.ContractTempPrice>();
            string CalculateTypeList = context.Request["CalculateTypeList"];
            List<Utility.ContractCalculateTypeModel> calculateTypeList = new List<Utility.ContractCalculateTypeModel>();
            if (FeeType == 1)
            {
                if (!string.IsNullOrEmpty(TempList))
                {
                    list = JsonConvert.DeserializeObject<List<Utility.ContractTempPrice>>(TempList);
                }
                if (!string.IsNullOrEmpty(CalculateTypeList))
                {
                    calculateTypeList = JsonConvert.DeserializeObject<List<Utility.ContractCalculateTypeModel>>(CalculateTypeList);
                }
            }
            List<Contract_TempPrice> templist = new List<Contract_TempPrice>();
            int ChargeID = WebUtil.GetIntValue(context, "ChargeID");
            string RoomIDs = context.Request["RoomIDList"];
            List<int> RoomIDList = new List<int>();
            if (!string.IsNullOrEmpty(RoomIDs))
            {
                RoomIDList = JsonConvert.DeserializeObject<List<int>>(RoomIDs);
            }
            RoomIDList = RoomIDList.Where(p => p != 0).ToList();
            int canrent = WebUtil.GetIntValue(context, "canrent");
            DateTime RentToTime = DateTime.MinValue;
            if (canrent == 1)
            {
                RentToTime = WebUtil.GetDateValue(context, "RentToTime");
                if (RentToTime < EndTime.AddDays(1))
                {
                    WebUtil.WriteJson(context, new { statu = false, error = "合同结束日期不能大于续租日期" });
                    return;
                }
                StartTime = EndTime.AddDays(1);
                EndTime = RentToTime;
            }
            if (list.Count == 0)
            {
                if (IsAutoChagePrice == 0 || (CategoryID == 4 && CalculateAmount <= 0) || (FeeType == 4 && CalculateAmount <= 0))
                {
                    var _contract_TempPrice = new Foresight.DataAccess.Contract_TempPrice();
                    _contract_TempPrice.BasicPrice = RoomUnitPrice;
                    _contract_TempPrice.BasicStartTime = StartTime;
                    _contract_TempPrice.BasicEndTime = EndTime;
                    _contract_TempPrice.CalculateType = CalculateType;
                    _contract_TempPrice.CalculatePercent = CalculatePercent;
                    _contract_TempPrice.CalculateAmount = CalculateAmount;
                    _contract_TempPrice.GUID = guid;
                    _contract_TempPrice.CalculatePrice = RoomUnitPrice;
                    _contract_TempPrice.CalculateStartTime = StartTime;
                    _contract_TempPrice.CalculateEndTime = EndTime;
                    _contract_TempPrice.AddTime = DateTime.Now;
                    _contract_TempPrice.ReadyChargeTime = FirstReadyChargeTime;
                    templist.Add(_contract_TempPrice);
                }
                else
                {
                    if (CalculateMonth <= 0)
                    {
                        WebUtil.WriteJson(context, new { status = true, MonthInvalid = true });
                        return;
                    }
                    if (!string.IsNullOrEmpty(CalculateType))
                    {
                        if (CalcualtePriceMonth <= 0)
                        {
                            WebUtil.WriteJson(context, new { status = true, PriceMonthInvalid = true });
                            return;
                        }
                        if (CalculateType.Equals("percent") && CalculatePercent <= 0)
                        {
                            WebUtil.WriteJson(context, new { status = true, CalculatePercentInvalid = true });
                            return;
                        }
                        else if (CalculateType.Equals("amount") && CalculateAmount <= 0)
                        {
                            WebUtil.WriteJson(context, new { status = true, CalculateAmountInvalid = true });
                            return;
                        }
                    }
                    if (StartTime == DateTime.MinValue)
                    {
                        WebUtil.WriteJson(context, new { status = true, StartTimeInvalid = true });
                        return;
                    }
                    if (EndTime == DateTime.MinValue)
                    {
                        WebUtil.WriteJson(context, new { status = true, EndTimeInvalid = true });
                        return;
                    }
                    CalculatePercent = CalculatePercent < 0 ? 0 : CalculatePercent;
                    CalculateAmount = CalculateAmount < 0 ? 0 : CalculateAmount;
                    RoomUnitPrice = RoomUnitPrice < 0 ? 0 : RoomUnitPrice;
                    decimal TotalMonth = (EndTime.Year - StartTime.Year) * 12 + (EndTime.Month - StartTime.Month);
                    int TotalNumber = Convert.ToInt32(Math.Ceiling(TotalMonth / CalculateMonth));
                    TotalNumber = TotalNumber <= 0 ? 1 : TotalNumber;
                    decimal CalculatePrice = RoomUnitPrice;
                    for (int i = 0; i <= TotalNumber; i++)
                    {
                        DateTime CalculateStartTime = CommHelper.CalculateContractTempStartTime(StartTime, EndTime, i, CalculateMonth);
                        if (CalculateStartTime == EndTime)
                        {
                            break;
                        }
                        DateTime CalculateEndTime = CommHelper.CalculateContractTempEndTime(StartTime, EndTime, i, CalculateMonth);
                        var _contract_TempPrice = new Foresight.DataAccess.Contract_TempPrice();
                        if (string.IsNullOrEmpty(CalculateType))
                        {
                            _contract_TempPrice = new Foresight.DataAccess.Contract_TempPrice();
                            _contract_TempPrice.BasicPrice = RoomUnitPrice;
                            _contract_TempPrice.BasicStartTime = StartTime;
                            _contract_TempPrice.BasicEndTime = EndTime;
                            _contract_TempPrice.CalculateType = CalculateType;
                            _contract_TempPrice.CalculatePercent = CalculatePercent;
                            _contract_TempPrice.CalculateAmount = CalculateAmount;
                            _contract_TempPrice.GUID = guid;
                            _contract_TempPrice.AddTime = DateTime.Now;
                            if (FirstReadyChargeTime > DateTime.MinValue)
                            {
                                _contract_TempPrice.ReadyChargeTime = FirstReadyChargeTime.AddMonths(i * CalculateMonth);
                            }
                            _contract_TempPrice.CalculateStartTime = CalculateStartTime;
                            _contract_TempPrice.CalculateEndTime = CalculateEndTime;
                            _contract_TempPrice.CalculatePrice = RoomUnitPrice;
                            templist.Add(_contract_TempPrice);
                        }
                        if (!string.IsNullOrEmpty(CalculateType))
                        {
                            DateTime Last_CalculateStartTime = DateTime.MinValue;
                            DateTime Last_CalculateEndTime = DateTime.MinValue;
                            decimal Last_CalculatePrice = CalculatePrice;
                            for (int j = 0; j < int.MaxValue; j++)
                            {
                                _contract_TempPrice = new Foresight.DataAccess.Contract_TempPrice();
                                _contract_TempPrice.BasicPrice = RoomUnitPrice;
                                _contract_TempPrice.BasicStartTime = StartTime;
                                _contract_TempPrice.BasicEndTime = EndTime;
                                _contract_TempPrice.CalculateType = CalculateType;
                                _contract_TempPrice.CalculatePercent = CalculatePercent;
                                _contract_TempPrice.CalculateAmount = CalculateAmount;
                                _contract_TempPrice.GUID = guid;
                                _contract_TempPrice.AddTime = DateTime.Now;
                                if (FirstReadyChargeTime > DateTime.MinValue)
                                {
                                    _contract_TempPrice.ReadyChargeTime = FirstReadyChargeTime.AddMonths(i * CalculateMonth);
                                }
                                DateTime CalculatePriceStartTime = CommHelper.CalculateContractTempStartTime(FirstReadyChargePriceTime, DateTime.MaxValue, j, CalcualtePriceMonth);
                                DateTime CalculatePriceEndTime = CommHelper.CalculateContractTempEndTime(FirstReadyChargePriceTime, DateTime.MaxValue, j, CalcualtePriceMonth);
                                if (CalculatePriceStartTime < StartTime)
                                {
                                    continue;
                                }
                                if (CalculateEndTime >= CalculatePriceStartTime)
                                {

                                }
                                if (CalculatePriceStartTime >= CalculateStartTime && CalculatePriceStartTime < CalculateEndTime)
                                {
                                    CalculatePrice = CommHelper.CalculateContractTempPrice(Last_CalculatePrice, 1, CalculateType, CalculatePercent, CalculateAmount);
                                    if (Last_CalculateStartTime == DateTime.MinValue || Last_CalculateEndTime == DateTime.MinValue)
                                    {
                                        _contract_TempPrice.CalculateStartTime = CalculateStartTime;
                                        if (CalculatePriceStartTime == CalculateStartTime)
                                        {
                                            _contract_TempPrice.CalculatePrice = CalculatePrice;
                                            if (CalculatePriceEndTime < CalculateEndTime)
                                            {
                                                _contract_TempPrice.CalculateEndTime = CalculatePriceEndTime;
                                            }
                                            else
                                            {
                                                _contract_TempPrice.CalculateEndTime = CalculateEndTime;
                                            }
                                        }
                                        else
                                        {
                                            _contract_TempPrice.CalculatePrice = Last_CalculatePrice;
                                            _contract_TempPrice.CalculateEndTime = CalculatePriceStartTime.AddDays(-1);
                                        }
                                    }
                                    else
                                    {
                                        _contract_TempPrice.CalculatePrice = CalculatePrice;
                                        _contract_TempPrice.CalculateStartTime = Last_CalculateEndTime.AddDays(1);
                                        CalculatePriceEndTime = CommHelper.CalculateContractTempEndTime(Last_CalculateEndTime.AddDays(1), DateTime.MaxValue, 0, CalcualtePriceMonth);
                                        if (CalculatePriceEndTime < CalculateEndTime)
                                        {
                                            _contract_TempPrice.CalculateEndTime = CalculatePriceEndTime;
                                        }
                                        else
                                        {
                                            _contract_TempPrice.CalculateEndTime = CalculateEndTime;
                                        }
                                    }
                                    if (_contract_TempPrice.CalculateStartTime <= _contract_TempPrice.CalculateEndTime)
                                    {
                                        templist.Add(_contract_TempPrice);
                                    }
                                    Last_CalculateStartTime = _contract_TempPrice.CalculateStartTime;
                                    Last_CalculateEndTime = _contract_TempPrice.CalculateEndTime;
                                    Last_CalculatePrice = _contract_TempPrice.CalculatePrice;
                                }
                                else if (CalculatePriceStartTime >= CalculateEndTime)
                                {
                                    if (Last_CalculateStartTime != DateTime.MinValue && Last_CalculateEndTime != DateTime.MinValue)
                                    {
                                        _contract_TempPrice.CalculatePrice = CalculatePrice;
                                        _contract_TempPrice.CalculateStartTime = Last_CalculateEndTime.AddDays(1);
                                        CalculatePriceEndTime = CommHelper.CalculateContractTempEndTime(Last_CalculateEndTime.AddDays(1), DateTime.MaxValue, 0, CalcualtePriceMonth);
                                        if (CalculatePriceEndTime < CalculateEndTime)
                                        {
                                            _contract_TempPrice.CalculateEndTime = CalculatePriceEndTime;
                                        }
                                        else
                                        {
                                            _contract_TempPrice.CalculateEndTime = CalculateEndTime;
                                        }
                                        if (_contract_TempPrice.CalculateStartTime <= _contract_TempPrice.CalculateEndTime)
                                        {
                                            templist.Add(_contract_TempPrice);
                                        }
                                    }
                                    else
                                    {
                                        _contract_TempPrice.CalculatePrice = CalculatePrice;
                                        _contract_TempPrice.CalculateStartTime = CalculateStartTime;
                                        _contract_TempPrice.CalculateEndTime = CalculateEndTime;
                                        if (_contract_TempPrice.CalculateStartTime <= _contract_TempPrice.CalculateEndTime)
                                        {
                                            templist.Add(_contract_TempPrice);
                                        }
                                    }
                                    Last_CalculateStartTime = _contract_TempPrice.CalculateStartTime;
                                    Last_CalculateEndTime = _contract_TempPrice.CalculateEndTime;
                                    Last_CalculatePrice = _contract_TempPrice.CalculatePrice;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                int i = 0;
                foreach (var item in list)
                {
                    Contract_TempPrice _contract_TempPrice = null;
                    if (item.ID > 0)
                    {
                        _contract_TempPrice = Contract_TempPrice.GetContract_TempPrice(item.ID);
                    }
                    if (_contract_TempPrice == null)
                    {
                        _contract_TempPrice = new Contract_TempPrice();
                        _contract_TempPrice.AddTime = DateTime.Now;
                        if (FirstReadyChargeTime > DateTime.MinValue)
                        {
                            _contract_TempPrice.ReadyChargeTime = FirstReadyChargeTime.AddMonths(i * CalculateMonth);
                        }
                    }
                    _contract_TempPrice.CalculatePrice = item.CalculatePrice;
                    _contract_TempPrice.CalculateStartTime = item.CalculateStartTime;
                    _contract_TempPrice.CalculateEndTime = item.CalculateEndTime;
                    _contract_TempPrice.CalculateCost = item.CalculateCost;
                    _contract_TempPrice.ReadyChargeTime = item.ReadyChargeTime;
                    templist.Add(_contract_TempPrice);
                    i++;
                }
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    foreach (var item in templist)
                    {
                        item.BasicPrice = RoomUnitPrice;
                        item.BasicStartTime = StartTime;
                        item.BasicEndTime = EndTime;
                        item.CalculateType = CalculateType;
                        item.CalculatePercent = CalculatePercent;
                        item.CalculateAmount = CalculateAmount;
                        item.GUID = guid;
                        item.ChargeID = ChargeID;
                        item.RoomUseCount = 0;
                        if (RoomIDList.Count == 1)
                        {
                            item.RoomID = RoomIDList[0];
                        }
                        item.Save(helper);
                    }
                    helper.Commit();
                    WebUtil.WriteJson(context, new { status = true });
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    Utility.LogHelper.WriteError("ContractHandler", "命令:addcontracttemppricelist", ex);
                    WebUtil.WriteJson(context, new { status = false });
                }
            }
        }
        private void savecontracttempprice(HttpContext context)
        {
            List<Foresight.DataAccess.Contract_TempPrice> list = new List<Contract_TempPrice>();
            int IsAutoChagePrice = WebUtil.GetIntValue(context, "IsAutoChagePrice");
            decimal RoomUnitPrice = WebUtil.GetDecimalValue(context, "RoomUnitPrice");
            DateTime StartTime = WebUtil.GetDateValue(context, "StartTime");
            DateTime EndTime = WebUtil.GetDateValue(context, "EndTime");
            int CalculateMonth = WebUtil.GetIntValue(context, "CalculateMonth");
            int CategoryID = WebUtil.GetIntValue(context, "CategoryID");
            int FeeType = WebUtil.GetIntValue(context, "FeeType");
            string CalculateType = context.Request["CalculateType"];
            decimal CalculatePercent = WebUtil.GetDecimalValue(context, "CalculatePercent");
            decimal CalculateAmount = WebUtil.GetDecimalValue(context, "CalculateAmount");
            string guid = context.Request["guid"];
            DateTime FirstReadyChargeTime = WebUtil.GetDateValue(context, "FirstReadyChargeTime");

            int CalcualtePriceMonth = WebUtil.GetIntValue(context, "CalcualtePriceMonth");
            DateTime FirstReadyChargePriceTime = WebUtil.GetDateValue(context, "FirstReadyChargePriceTime");

            int canrent = WebUtil.GetIntValue(context, "canrent");
            DateTime RentToTime = DateTime.MinValue;
            if (canrent == 1)
            {
                RentToTime = WebUtil.GetDateValue(context, "RentToTime");
                if (RentToTime < EndTime.AddDays(1))
                {
                    WebUtil.WriteJson(context, new { statu = false, error = "调价日期不能小于合同结束日期" });
                    return;
                }
                StartTime = EndTime.AddDays(1);
                EndTime = RentToTime;
            }
            if (IsAutoChagePrice == 0 || (CategoryID == 4 && CalculateMonth <= 0) || (FeeType == 4 && CalculateMonth <= 0))
            {
                var _contract_TempPrice = new Foresight.DataAccess.Contract_TempPrice();
                _contract_TempPrice.BasicPrice = RoomUnitPrice;
                _contract_TempPrice.BasicStartTime = StartTime;
                _contract_TempPrice.BasicEndTime = EndTime;
                _contract_TempPrice.CalculateType = CalculateType;
                _contract_TempPrice.CalculatePercent = CalculatePercent;
                _contract_TempPrice.CalculateAmount = CalculateAmount;
                _contract_TempPrice.GUID = guid;
                _contract_TempPrice.CalculatePrice = RoomUnitPrice;
                _contract_TempPrice.CalculateStartTime = StartTime;
                _contract_TempPrice.CalculateEndTime = EndTime;
                if (CategoryID == 3 || CategoryID == 4)
                {
                    _contract_TempPrice.CalculateStartTime = DateTime.MinValue;
                    _contract_TempPrice.CalculateEndTime = DateTime.MinValue;
                }
                _contract_TempPrice.AddTime = DateTime.Now;
                _contract_TempPrice.ReadyChargeTime = FirstReadyChargeTime;
                list.Add(_contract_TempPrice);
            }
            else
            {
                if (CalculateMonth <= 0)
                {
                    WebUtil.WriteJson(context, new { status = true, MonthInvalid = true });
                    return;
                }
                if (!string.IsNullOrEmpty(CalculateType))
                {
                    if (CalcualtePriceMonth <= 0)
                    {
                        WebUtil.WriteJson(context, new { status = true, PriceMonthInvalid = true });
                        return;
                    }
                    if (CalculateType.Equals("percent") && CalculatePercent <= 0)
                    {
                        WebUtil.WriteJson(context, new { status = true, CalculatePercentInvalid = true });
                        return;
                    }
                    else if (CalculateType.Equals("amount") && CalculateAmount <= 0)
                    {
                        WebUtil.WriteJson(context, new { status = true, CalculateAmountInvalid = true });
                        return;
                    }
                }
                if (StartTime == DateTime.MinValue)
                {
                    WebUtil.WriteJson(context, new { status = true, StartTimeInvalid = true });
                    return;
                }
                if (EndTime == DateTime.MinValue)
                {
                    WebUtil.WriteJson(context, new { status = true, EndTimeInvalid = true });
                    return;
                }
                CalculatePercent = CalculatePercent < 0 ? 0 : CalculatePercent;
                CalculateAmount = CalculateAmount < 0 ? 0 : CalculateAmount;
                RoomUnitPrice = RoomUnitPrice < 0 ? 0 : RoomUnitPrice;
                decimal TotalMonth = (EndTime.Year - StartTime.Year) * 12 + (EndTime.Month - StartTime.Month);
                int TotalNumber = Convert.ToInt32(Math.Ceiling(TotalMonth / CalculateMonth));
                TotalNumber = TotalNumber <= 0 ? 1 : TotalNumber;
                decimal CalculatePrice = RoomUnitPrice;
                for (int i = 0; i <= TotalNumber; i++)
                {
                    DateTime CalculateStartTime = CommHelper.CalculateContractTempStartTime(StartTime, EndTime, i, CalculateMonth);
                    if (CalculateStartTime == EndTime)
                    {
                        break;
                    }
                    DateTime CalculateEndTime = CommHelper.CalculateContractTempEndTime(StartTime, EndTime, i, CalculateMonth);
                    var _contract_TempPrice = new Foresight.DataAccess.Contract_TempPrice();
                    if (string.IsNullOrEmpty(CalculateType))
                    {
                        _contract_TempPrice = new Foresight.DataAccess.Contract_TempPrice();
                        _contract_TempPrice.BasicPrice = RoomUnitPrice;
                        _contract_TempPrice.BasicStartTime = StartTime;
                        _contract_TempPrice.BasicEndTime = EndTime;
                        _contract_TempPrice.CalculateType = CalculateType;
                        _contract_TempPrice.CalculatePercent = CalculatePercent;
                        _contract_TempPrice.CalculateAmount = CalculateAmount;
                        _contract_TempPrice.GUID = guid;
                        _contract_TempPrice.AddTime = DateTime.Now;
                        if (FirstReadyChargeTime > DateTime.MinValue)
                        {
                            _contract_TempPrice.ReadyChargeTime = FirstReadyChargeTime.AddMonths(i * CalculateMonth);
                        }
                        _contract_TempPrice.CalculateStartTime = CalculateStartTime;
                        _contract_TempPrice.CalculateEndTime = CalculateEndTime;
                        _contract_TempPrice.CalculatePrice = RoomUnitPrice;
                        list.Add(_contract_TempPrice);
                    }
                    if (!string.IsNullOrEmpty(CalculateType))
                    {
                        DateTime Last_CalculateStartTime = DateTime.MinValue;
                        DateTime Last_CalculateEndTime = DateTime.MinValue;
                        decimal Last_CalculatePrice = CalculatePrice;
                        for (int j = 0; j < int.MaxValue; j++)
                        {
                            _contract_TempPrice = new Foresight.DataAccess.Contract_TempPrice();
                            _contract_TempPrice.BasicPrice = RoomUnitPrice;
                            _contract_TempPrice.BasicStartTime = StartTime;
                            _contract_TempPrice.BasicEndTime = EndTime;
                            _contract_TempPrice.CalculateType = CalculateType;
                            _contract_TempPrice.CalculatePercent = CalculatePercent;
                            _contract_TempPrice.CalculateAmount = CalculateAmount;
                            _contract_TempPrice.GUID = guid;
                            _contract_TempPrice.AddTime = DateTime.Now;
                            if (FirstReadyChargeTime > DateTime.MinValue)
                            {
                                _contract_TempPrice.ReadyChargeTime = FirstReadyChargeTime.AddMonths(i * CalculateMonth);
                            }
                            DateTime CalculatePriceStartTime = CommHelper.CalculateContractTempStartTime(FirstReadyChargePriceTime, DateTime.MaxValue, j, CalcualtePriceMonth);
                            DateTime CalculatePriceEndTime = CommHelper.CalculateContractTempEndTime(FirstReadyChargePriceTime, DateTime.MaxValue, j, CalcualtePriceMonth);
                            if (CalculatePriceStartTime < StartTime)
                            {
                                continue;
                            }
                            if (CalculateEndTime >= CalculatePriceStartTime)
                            {

                            }
                            if (CalculatePriceStartTime >= CalculateStartTime && CalculatePriceStartTime < CalculateEndTime)
                            {
                                CalculatePrice = CommHelper.CalculateContractTempPrice(Last_CalculatePrice, 1, CalculateType, CalculatePercent, CalculateAmount);
                                if (Last_CalculateStartTime == DateTime.MinValue || Last_CalculateEndTime == DateTime.MinValue)
                                {
                                    _contract_TempPrice.CalculateStartTime = CalculateStartTime;
                                    if (CalculatePriceStartTime == CalculateStartTime)
                                    {
                                        _contract_TempPrice.CalculatePrice = CalculatePrice;
                                        if (CalculatePriceEndTime < CalculateEndTime)
                                        {
                                            _contract_TempPrice.CalculateEndTime = CalculatePriceEndTime;
                                        }
                                        else
                                        {
                                            _contract_TempPrice.CalculateEndTime = CalculateEndTime;
                                        }
                                    }
                                    else
                                    {
                                        _contract_TempPrice.CalculatePrice = Last_CalculatePrice;
                                        _contract_TempPrice.CalculateEndTime = CalculatePriceStartTime.AddDays(-1);
                                    }
                                }
                                else
                                {
                                    _contract_TempPrice.CalculatePrice = CalculatePrice;
                                    _contract_TempPrice.CalculateStartTime = Last_CalculateEndTime.AddDays(1);
                                    CalculatePriceEndTime = CommHelper.CalculateContractTempEndTime(Last_CalculateEndTime.AddDays(1), DateTime.MaxValue, 0, CalcualtePriceMonth);
                                    if (CalculatePriceEndTime < CalculateEndTime)
                                    {
                                        _contract_TempPrice.CalculateEndTime = CalculatePriceEndTime;
                                    }
                                    else
                                    {
                                        _contract_TempPrice.CalculateEndTime = CalculateEndTime;
                                    }
                                }
                                if (_contract_TempPrice.CalculateStartTime <= _contract_TempPrice.CalculateEndTime)
                                {
                                    list.Add(_contract_TempPrice);
                                }
                                Last_CalculateStartTime = _contract_TempPrice.CalculateStartTime;
                                Last_CalculateEndTime = _contract_TempPrice.CalculateEndTime;
                                Last_CalculatePrice = _contract_TempPrice.CalculatePrice;
                            }
                            else if (CalculatePriceStartTime >= CalculateEndTime)
                            {
                                if (Last_CalculateStartTime != DateTime.MinValue && Last_CalculateEndTime != DateTime.MinValue)
                                {
                                    _contract_TempPrice.CalculatePrice = CalculatePrice;
                                    _contract_TempPrice.CalculateStartTime = Last_CalculateEndTime.AddDays(1);
                                    CalculatePriceEndTime = CommHelper.CalculateContractTempEndTime(Last_CalculateEndTime.AddDays(1), DateTime.MaxValue, 0, CalcualtePriceMonth);
                                    if (CalculatePriceEndTime < CalculateEndTime)
                                    {
                                        _contract_TempPrice.CalculateEndTime = CalculatePriceEndTime;
                                    }
                                    else
                                    {
                                        _contract_TempPrice.CalculateEndTime = CalculateEndTime;
                                    }
                                    if (_contract_TempPrice.CalculateStartTime <= _contract_TempPrice.CalculateEndTime)
                                    {
                                        list.Add(_contract_TempPrice);
                                    }
                                }
                                else
                                {
                                    _contract_TempPrice.CalculatePrice = CalculatePrice;
                                    _contract_TempPrice.CalculateStartTime = CalculateStartTime;
                                    _contract_TempPrice.CalculateEndTime = CalculateEndTime;
                                    if (_contract_TempPrice.CalculateStartTime <= _contract_TempPrice.CalculateEndTime)
                                    {
                                        list.Add(_contract_TempPrice);
                                    }
                                }
                                Last_CalculateStartTime = _contract_TempPrice.CalculateStartTime;
                                Last_CalculateEndTime = _contract_TempPrice.CalculateEndTime;
                                Last_CalculatePrice = _contract_TempPrice.CalculatePrice;
                                break;
                            }
                        }
                    }
                }
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    foreach (var item in list)
                    {
                        item.Save(helper);
                    }
                    helper.Commit();
                    WebUtil.WriteJson(context, new { status = true });
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    Utility.LogHelper.WriteError("ContractHandler", "命令:savecontracttempprice", ex);
                    WebUtil.WriteJson(context, new { status = false });
                }
            }
        }
        private void loadcontractemppricegrid(HttpContext context)
        {
            try
            {
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                string guid = context.Request["guid"];
                int ChargeID = WebUtil.GetIntValue(context, "ChargeID");
                int ContractID = WebUtil.GetIntValue(context, "ContractID");
                DataGrid dg = ViewContract_TempPrice.GetContract_TempPriceGridByGuid(guid, "order by [ID] desc", startRowIndex, pageSize, ChargeID, ContractID: ContractID);
                string result = JsonConvert.SerializeObject(dg);
                context.Response.Write(result);
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("ContractHandler", "visit: loadcontractemppricegrid", ex);
                context.Response.Write("{\"rows\":[],\"total\":0,\"page\":0}");
            }
        }
        private void getcontractfeetitle(HttpContext context)
        {
            int[] RoomIDList = new int[] { };
            if (!string.IsNullOrEmpty(context.Request["RoomIDs"]))
            {
                RoomIDList = JsonConvert.DeserializeObject<int[]>(context.Request["RoomIDs"]);
            }
            if (RoomIDList.Length == 0)
            {
                WebUtil.WriteJson(context, new { status = false });
                return;
            }
            var list = Foresight.DataAccess.Contract_RoomCharge.GetGroupbyContract_RoomCharge(RoomIDList);
            List<Dictionary<string, object>> temp = new List<Dictionary<string, object>>();
            if (list.Length == 0)
            {
                WebUtil.WriteJson(context, new { status = true, list = temp });
                return;
            }
            int MinContractID = list.Min(p => p.ContractID);
            int MaxContractID = list.Max(p => p.ContractID);
            var feeList = RoomFee.GetRoomFeeIDListByContractIDList(MinContractID, MaxContractID);
            var contractList = Foresight.DataAccess.Contract.GetContractListByIDList(list.Select(p => p.ContractID).ToList());
            foreach (var item in list)
            {
                var myContract = contractList.FirstOrDefault(p => p.ID == item.ContractID);
                if (myContract == null)
                {
                    continue;
                }
                var myFeeList = feeList.Where(p => p.ContractID == item.ContractID).ToArray();
                if (myFeeList.Length == 0)
                {
                    continue;
                }
                Dictionary<string, object> dic = new Dictionary<string, object>();
                dic["ContractID"] = myContract.ID;
                dic["ContractName"] = myContract.ContractName;
                temp.Add(dic);
            }
            WebUtil.WriteJson(context, new { status = true, list = temp });
        }
        private void loadcontractfeehistorylist(HttpContext context)
        {
            try
            {
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                List<int> ContractIDList = JsonConvert.DeserializeObject<List<int>>(context.Request["ContractIDList"]);
                bool IncludIsCharged = false;
                bool.TryParse(context.Request["IncludIsCharged"], out IncludIsCharged);
                DataGrid dg = ViewContractFeeHistory.GetViewContractFeeHistoryGridByContractID(ContractIDList, IncludIsCharged, "order by [PrintNumber] desc", startRowIndex, pageSize);
                string result = JsonConvert.SerializeObject(dg);
                context.Response.Write(result);
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("ContractHandler", "visit: loadcontractfeehistorylist", ex);
                context.Response.Write("{\"rows\":[],\"total\":0,\"page\":0}");
            }
        }
        private void editcontractcharge(HttpContext context)
        {
            int canedit = WebUtil.GetIntValue(context, "canedit");
            int ID = WebUtil.GetIntValue(context, "ID");
            string precontractroomchargestr = string.Empty;
            var data = Foresight.DataAccess.Contract_RoomCharge.GetContract_RoomCharge(ID);
            if (data == null)
            {
                WebUtil.WriteJson(context, new { status = false, msg = "费项不存在" });
                return;
            }
            var roomfeehistory = Foresight.DataAccess.RoomFeeHistory.GetRoomFeeHistoryByContract_RoomChargeID(data.ContractID, data.ID);
            if (roomfeehistory != null)
            {
                WebUtil.WriteJson(context, new { status = false, msg = "该费项已收款" });
                return;
            }
            precontractroomchargestr = JsonConvert.SerializeObject(data);
            data.RoomUnitPrice = WebUtil.GetDecimalValue(context, "UnitPrice");
            data.RoomStartTime = WebUtil.GetDateValue(context, "StartTime");
            data.RoomEndTime = WebUtil.GetDateValue(context, "EndTime");
            data.RoomNewEndTime = WebUtil.GetDateValue(context, "NewEndTime");
            data.Remark = context.Request["Remark"];
            data.RoomCost = WebUtil.GetDecimalValue(context, "RoomCost");
            data.RoomUseCount = WebUtil.GetDecimalValue(context, "RoomUseCount");
            data.ReadyChargeTime = WebUtil.GetDateValue(context, "ReadyChargeTime");
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    data.Save(helper);
                    string RoomStartTime = data.RoomStartTime > DateTime.MinValue ? "'" + data.RoomStartTime.ToString("yyyy-MM-dd") + "'" : "NULL";
                    string RoomEndTime = data.RoomEndTime > DateTime.MinValue ? "'" + data.RoomEndTime.ToString("yyyy-MM-dd") + "'" : "NULL";
                    string RoomNewEndTime = data.RoomNewEndTime > DateTime.MinValue ? "'" + data.RoomNewEndTime.ToString("yyyy-MM-dd") + "'" : "NULL";
                    string cmdtext = "update [RoomFee] set [UnitPrice]=@UnitPrice,[StartTime]=" + RoomStartTime + ",[EndTime]=" + RoomEndTime + ",[NewEndTime]=" + RoomNewEndTime + ",[Remark]=@Remark,[Cost]=@Cost,[UseCount]=@UseCount where [ContractID]=@ContractID and [ChargeID]=@ChargeID and [RoomID]=@RoomID and [Contract_RoomChargeID]=@Contract_RoomChargeID;";
                    cmdtext += "update [RooFeeRemark] set [RemarkNote]=@Remark where RooFeeID in (select ID from RoomFee where [ContractID]=@ContractID and [ChargeID]=@ChargeID and [RoomID]=@RoomID and [Contract_RoomChargeID]=@Contract_RoomChargeID);";
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    parameters.Add(new SqlParameter("@ContractID", data.ContractID));
                    parameters.Add(new SqlParameter("@ChargeID", data.ChargeID));
                    parameters.Add(new SqlParameter("@RoomID", data.RoomID));
                    parameters.Add(new SqlParameter("@Contract_RoomChargeID", data.ID));
                    parameters.Add(new SqlParameter("@UnitPrice", data.RoomUnitPrice > 0 ? data.RoomUnitPrice : 0));
                    parameters.Add(new SqlParameter("@Remark", data.Remark));
                    parameters.Add(new SqlParameter("@Cost", data.RoomCost > 0 ? data.RoomCost : 0));
                    parameters.Add(new SqlParameter("@UseCount", data.RoomUseCount > 0 ? data.RoomUseCount : 0));
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
            if (!string.IsNullOrEmpty(precontractroomchargestr) && canedit == 1)
            {
                Foresight.DataAccess.Contract_RoomCharge precontractroomcharge = JsonConvert.DeserializeObject<Foresight.DataAccess.Contract_RoomCharge>(precontractroomchargestr);
                CommHelper.SaveContractRoomChargeLog(precontractroomcharge, data, WebUtil.GetUser(context).RealName);
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void cancelcontractprintfee(HttpContext context)
        {
            string TempHistoryIDs = context.Request.Params["TempHistoryIDs"];
            List<int> TempHistoryIDList = JsonConvert.DeserializeObject<List<int>>(TempHistoryIDs);
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    string cmdtext = "delete from [TempRoomFee] where [TempID] in (select [TempID] from [TempRoomFeeHistory] where [TempHistoryID] in (" + string.Join(",", TempHistoryIDList.ToArray()) + "))";
                    cmdtext += "delete from [TempRoomFeeHistory] where [TempHistoryID] in (" + string.Join(",", TempHistoryIDList.ToArray()) + ")";
                    helper.Execute(cmdtext, CommandType.Text, new List<SqlParameter>());
                    helper.Commit();
                    context.Response.Write("{\"status\":true}");
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError("ContractHandler", "visit:cancelcontractprintfee", ex);
                    context.Response.Write("{\"status\":false}");
                }
            }
        }
        private void createcontractfee(HttpContext context)
        {
            string IDs = context.Request.Params["IDList"];
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(IDs);
            var contract_list = Foresight.DataAccess.Contract.GetContractListByIDList(IDList);
            foreach (var contract in contract_list)
            {
                if (!contract.ContractStatus.Equals(Utility.EnumModel.ContractStatus.tongguo.ToString()))
                {
                    continue;
                }
                var roomList = ViewContractChargeSummary.GetViewContractChargeSummaryByContractID(contract.ID);
                var roomfee_list = Foresight.DataAccess.RoomFee.GetRoomFeeListByContractID(contract.ID);
                var roomfeehistory_list = Foresight.DataAccess.RoomFeeHistory.GetRoomFeeHistoryListByContractID(contract.ID);
                var summaryList = ViewChargeSummary.GetViewChargeSummaries().ToArray();
                foreach (var room in roomList)
                {
                    var roomfee = roomfee_list.FirstOrDefault(p => p.Contract_RoomChargeID == room.ID);
                    var roomfeehistory = roomfeehistory_list.FirstOrDefault(p => p.Contract_RoomChargeID == room.ID);
                    if (roomfeehistory != null)
                    {
                        continue;
                    }
                    if (roomfee != null)
                    {
                        continue;
                    }
                    int ChargeID = room.ChargeID;
                    ViewChargeSummary summary = summaryList.FirstOrDefault(p => p.ID == room.ChargeID);
                    if (summary == null)
                    {
                        continue;
                    }
                    List<int> RoomIdList = new List<int>();
                    RoomIdList.Add(room.RoomID);
                    string StartTimeStr = room.CalculateStartTime == DateTime.MinValue ? null : room.CalculateStartTime.ToString("yyyy-MM-dd");
                    string EndTimeStr = room.CalculateEndTime == DateTime.MinValue ? null : room.CalculateEndTime.ToString("yyyy-MM-dd");
                    string NewEndTimeStr = room.CalculateNewEndTime == DateTime.MinValue ? null : room.CalculateNewEndTime.ToString("yyyy-MM-dd");
                    RoomFee.InsertRoomFee(new List<int>(), RoomIdList, StartTimeStr, EndTimeStr, contract.ID, room.CalculateUnitPrice, room.Remark, summary, NewEndTime: NewEndTimeStr, TotalCost: room.CalcualteTotalCost, UseCount: room.CalculateUseCount, Contract_RoomChargeID: room.ID);
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void removecontract(HttpContext context)
        {
            string IDs = context.Request.Params["IDList"];
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(IDs);
            if (IDList.Count > 0)
            {
                string cmdtext = string.Empty;
                cmdtext += "delete from [Contract_RoomCharge] where [ContractID]=0 or [ContractID] in (" + string.Join(",", IDList.ToArray()) + ");";
                cmdtext += "delete from [Contract_Room] where [ContractID]=0 or [ContractID] in (" + string.Join(",", IDList.ToArray()) + ");";
                cmdtext += "delete from [Contract_ChargeSummary] where [ContractID]=0 or [ContractID] in (" + string.Join(",", IDList.ToArray()) + ");";
                cmdtext += "delete from [RoomFee] where isnull([ContractID],0) in (" + string.Join(",", IDList.ToArray()) + ");";
                cmdtext += "delete from [Contract] where [ID] in (" + string.Join(",", IDList.ToArray()) + ");";
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
                        helper.Rollback();
                        Utility.LogHelper.WriteError("ContractHandler", "命令:removecontract", ex);
                        WebUtil.WriteJson(context, new { status = false });
                        return;
                    }
                }
                #region 删除日志
                var user = WebUtil.GetUser(context);
                APPCode.CommHelper.SaveOperationLog(string.Join(",", IDList.ToArray()), Utility.EnumModel.OperationModule.ContractDelete.ToString(), "合同删除", user.UserID.ToString(), "Contract", user.LoginName, IsHide: true);
                APPCode.CommHelper.SaveOperationLog("用户" + user.LoginName + "删除了合同", Utility.EnumModel.OperationModule.ContractDelete.ToString(), "合同删除", user.UserID.ToString(), "Contract", user.LoginName);
                #endregion
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void loadcontractchargelist(HttpContext context)
        {
            try
            {
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                string guid = context.Request.Params["guid"];
                int ContractID = WebUtil.GetIntValue(context, "ContractID");
                DateTime StartTime = WebUtil.GetDateValue(context, "StartTime");
                DateTime EndTime = WebUtil.GetDateValue(context, "EndTime");
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                string SearchAreas = context.Request.Params["SearchAreas"];
                List<string> SearchAreaList = new List<string>();
                if (!string.IsNullOrEmpty(SearchAreas))
                {
                    SearchAreaList = JsonConvert.DeserializeObject<List<string>>(SearchAreas);
                }
                bool IsLinShi = false;
                if (!string.IsNullOrEmpty(context.Request["IsLinShi"]))
                {
                    bool.TryParse(context.Request["IsLinShi"], out IsLinShi);
                }
                string RoomIDs = context.Request.Params["RoomIDs"];
                List<int> RoomIDList = new List<int>();
                if (!string.IsNullOrEmpty(RoomIDs))
                {
                    RoomIDList = JsonConvert.DeserializeObject<List<int>>(RoomIDs);
                }
                string ProjectIDs = context.Request.Params["ProjectIDs"];
                List<int> ProjectIDList = new List<int>();
                if (RoomIDList.Count == 0)
                {
                    if (!string.IsNullOrEmpty(ProjectIDs))
                    {
                        ProjectIDList = JsonConvert.DeserializeObject<List<int>>(ProjectIDs).Where(p => p != 1).ToList();
                    }
                    ProjectIDList = WebUtil.GetMyProjects(WebUtil.GetUser(context).UserID, ProjectIDList).Where(p => p.ID != 1).Select(p => p.ID).ToList();
                }
                string Keywords = context.Request["Keywords"];
                string ContractStatus = context.Request["ContractStatus"];
                bool IsWarning = false;
                if (!string.IsNullOrEmpty(context.Request["IsWarning"]))
                {
                    bool.TryParse(context.Request["IsWarning"], out IsWarning);
                }
                DateTime ReadyStartTime = WebUtil.GetDateValue(context, "ReadyStartTime");
                DateTime ReadyEndTime = WebUtil.GetDateValue(context, "ReadyEndTime");
                int FeeStatus = WebUtil.GetIntValue(context, "FeeStatus");
                string ChargeSummarys = context.Request["ChargeSummarys"];
                List<int> ChargeIDList = new List<int>();
                if (!string.IsNullOrEmpty(ChargeSummarys))
                {
                    ChargeIDList = JsonConvert.DeserializeObject<List<int>>(ChargeSummarys);
                }
                int canrent = WebUtil.GetIntValue(context, "canrent");
                if (canrent == 1)
                {
                    ContractID = 0;
                }
                string OrderType = context.Request["OrderType"];
                string SortOrder = "order by ID asc";
                if (!string.IsNullOrEmpty(OrderType) && OrderType.Equals("Project"))
                {
                    SortOrder = "order by DefaultOrder asc,ContractID desc,ID asc";
                }
                bool canexport = WebUtil.GetBoolValue(context, "canexport");
                DataGrid dg = ViewContractChargeSummary.GetViewContractChargeSummaryGrid(ContractID, guid, StartTime, EndTime, SortOrder, startRowIndex, pageSize, IsLinShi, UserID: WebUtil.GetUser(context).UserID, ProjectIDList: ProjectIDList, RoomIDList: RoomIDList, keywords: Keywords, ContractStatus: ContractStatus, IsWarning: IsWarning, ReadyStartTime: ReadyStartTime, ReadyEndTime: ReadyEndTime, FeeStatus: FeeStatus, ChargeIDList: ChargeIDList, canexport: canexport);
                if (canexport)
                {
                    string downloadurl = string.Empty;
                    string error = string.Empty;
                    bool status = APPCode.ExportHelper.DownLoadContractFeeSummaryData(dg, OrderType, out downloadurl, out error);
                    WebUtil.WriteJson(context, new { status = status, downloadurl = downloadurl, error = error });
                    return;
                }
                bool IncludeFooter = false;
                if (!string.IsNullOrEmpty(context.Request["IncludeFooter"]))
                {
                    bool.TryParse(context.Request["IncludeFooter"], out IncludeFooter);
                }
                if (IncludeFooter && dg != null)
                {
                    var datalist = dg.rows as ViewContractChargeSummary[];
                    decimal totalcost = datalist.Sum(p => p.CalcualteTotalCost);
                    decimal paycost = datalist.Sum(p => p.CalcualtePayCost);
                    decimal restcost = datalist.Sum(p => p.CalcualteRestCost);
                    decimal discountcost = datalist.Sum(p => p.CalcualteDiscount);
                    var footerlist = new List<Dictionary<string, object>>();
                    var footerdata = new Dictionary<string, object>();
                    footerdata["ContractNo"] = "合计";
                    footerdata["FormatCalcualteTotalCost"] = Utility.Tools.FormatMoney(totalcost);
                    footerdata["FormatCalcualtePayCost"] = Utility.Tools.FormatMoney(paycost);
                    footerdata["FormatCalcualteRestCost"] = Utility.Tools.FormatMoney(restcost);
                    footerdata["FormatCalcualteDiscount"] = Utility.Tools.FormatMoney(discountcost);
                    footerlist.Add(footerdata);
                    dg.footer = footerlist;
                }
                WebUtil.WriteJson(context, dg);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.WriteError("ContractHandler", "命令:loadcontractchargelist", ex);
                context.Response.Write("{\"rows\":[],\"total\":0,\"page\":0}");
            }
        }
        private void removecontractcharge(HttpContext context)
        {
            int canedit = WebUtil.GetIntValue(context, "canedit");
            string IDs = context.Request.Params["IDList"];
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(IDs);
            Foresight.DataAccess.Contract_RoomCharge[] datalist = new Contract_RoomCharge[] { };
            if (IDList.Count > 0)
            {
                datalist = Foresight.DataAccess.Contract_RoomCharge.GetContract_RoomChargeListByIDList(IDList);
                foreach (var data in datalist)
                {
                    var roomfeehistory = Foresight.DataAccess.RoomFeeHistory.GetRoomFeeHistoryByContract_RoomChargeID(data.ContractID, data.ID);
                    if (roomfeehistory != null)
                    {
                        WebUtil.WriteJson(context, new { status = false, msg = "删除项中包含已收款的费项" });
                        return;
                    }
                }
                string cmdtext = string.Empty;
                cmdtext += "delete from [Contract_RoomCharge] where [ID] in (" + string.Join(",", IDList.ToArray()) + ");";
                foreach (var ID in IDList)
                {
                    cmdtext += "delete from [RoomFee] where [Contract_RoomChargeID]=" + ID + ";";
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
                        helper.Rollback();
                        Utility.LogHelper.WriteError("ContractHandler", "命令:removecontractcharge", ex);
                        WebUtil.WriteJson(context, new { status = false });
                        return;
                    }
                }
                #region 删除日志
                var user = WebUtil.GetUser(context);
                APPCode.CommHelper.SaveOperationLog(string.Join(",", IDList.ToArray()), Utility.EnumModel.OperationModule.ContractChargeDelete.ToString(), "合同费项删除", user.UserID.ToString(), "Contract_RoomCharge", user.LoginName, IsHide: true);
                APPCode.CommHelper.SaveOperationLog("用户" + user.LoginName + "删除了合同费项", Utility.EnumModel.OperationModule.ContractChargeDelete.ToString(), "合同费项删除", user.UserID.ToString(), "Contract_RoomCharge", user.LoginName);
                #endregion
            }
            else
            {
                WebUtil.WriteJson(context, new { status = true });
                return;
            }
            if (datalist.Length > 0 && canedit == 1)
            {
                CommHelper.SaveContractRoomChargeRemoveorAddLog(datalist, WebUtil.GetUser(context).RealName);
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void savecontractcharge(HttpContext context)
        {
            int canedit = WebUtil.GetIntValue(context, "canedit");
            string guid = context.Request.Params["guid"];
            int ContractID = WebUtil.GetIntValue(context, "ContractID");
            string RoomIDs = context.Request["RoomIDs"];
            List<int> RoomIDList = JsonConvert.DeserializeObject<List<int>>(RoomIDs);
            string RoomName = context.Request.Params["RoomName"];
            decimal RoomUnitPrice = WebUtil.GetDecimalValue(context, "RoomUnitPrice");
            DateTime FirstReadyChargeTime = WebUtil.GetDateValue(context, "FirstReadyChargeTime");
            DateTime FirstStartTime = WebUtil.GetDateValue(context, "FirstStartTime");
            List<int> ChargeIDList = JsonConvert.DeserializeObject<List<int>>(context.Request["ChargeIDList"]);
            int canrent = WebUtil.GetIntValue(context, "canrent");
            #region ChargeIDList循环
            var temlist = Contract_TempPrice.GetContract_TempPriceListByGuid(guid, ChargeIDList: ChargeIDList);
            List<Contract_Room> roomList = new List<Contract_Room>();
            if (RoomIDList.Contains(0))
            {
                roomList = Contract_Room.GetContract_RoomList(ContractID, guid).ToList();
            }
            else
            {
                roomList = Contract_Room.GetContract_RoomList(ContractID, guid, 0, RoomIDList).ToList();
            }
            var room_basic_list = Foresight.DataAccess.RoomBasic.GetRoomBasicListByRoomIDList(roomList.Select(p => p.RoomID).ToList());
            List<Contract_ChargeSummary> contract_Charge_List = new List<Contract_ChargeSummary>();
            List<Contract_RoomCharge> chargeList = new List<Contract_RoomCharge>();
            var contract_charge_list = Contract_RoomCharge.GetContract_RoomChargeListByTempGuid(guid);
            foreach (var ChargeID in ChargeIDList)
            {
                var charge = ChargeSummary.GetChargeSummary(ChargeID);
                if (charge == null)
                {
                    continue;
                }
                Contract_ChargeSummary _contract_Charge = null;
                var _contract_ChargeList = Contract_ChargeSummary.GetContract_ChargeSummaryList(ContractID, guid, ChargeID);
                if (_contract_ChargeList.Length == 0)
                {
                    _contract_Charge = new Contract_ChargeSummary();
                    _contract_Charge.ChargeID = ChargeID;
                    _contract_Charge.ContractID = ContractID;
                    _contract_Charge.GUID = guid;
                    _contract_Charge.RoomType = RoomName;
                    contract_Charge_List.Add(_contract_Charge);
                }
                int count_index = 0;
                foreach (var contractroom in roomList)
                {
                    count_index++;
                    if (RoomIDList.Contains(contractroom.RoomID))
                    {
                        if (temlist.Length > 0)
                        {
                            foreach (var item in temlist)
                            {
                                Contract_RoomCharge _contract_RoomCharge = contract_charge_list.FirstOrDefault(p => p.Contract_TempPriceID == item.ID);
                                if (_contract_RoomCharge == null)
                                {
                                    _contract_RoomCharge = new Contract_RoomCharge();
                                    _contract_RoomCharge.AddTime = DateTime.Now;
                                    _contract_RoomCharge.Contract_TempPriceID = item.ID;
                                    _contract_RoomCharge.RoomUseCount = 0;
                                    _contract_RoomCharge.ChargeID = ChargeID;
                                    _contract_RoomCharge.RoomID = contractroom.RoomID;
                                }
                                _contract_RoomCharge.ContractID = ContractID;
                                _contract_RoomCharge.RoomUnitPrice = item.CalculatePrice;
                                _contract_RoomCharge.RoomStartTime = item.CalculateStartTime;
                                _contract_RoomCharge.RoomEndTime = item.CalculateEndTime;
                                _contract_RoomCharge.RoomNewEndTime = item.CalculateEndTime;
                                if (charge.CategoryID == 3 || charge.CategoryID == 4)
                                {
                                    _contract_RoomCharge.RoomStartTime = DateTime.MinValue;
                                    _contract_RoomCharge.RoomEndTime = DateTime.MinValue;
                                }
                                _contract_RoomCharge.RoomCost = item.CalculateCost > 0 ? item.CalculateCost : 0;
                                _contract_RoomCharge.GUID = guid;
                                _contract_RoomCharge.ReadyChargeTime = item.ReadyChargeTime;
                                chargeList.Add(_contract_RoomCharge);
                            }
                        }
                        else
                        {
                            Contract_RoomCharge _contract_RoomCharge = new Contract_RoomCharge();
                            _contract_RoomCharge.AddTime = DateTime.Now;
                            _contract_RoomCharge.ContractID = ContractID;
                            _contract_RoomCharge.RoomID = contractroom.RoomID;
                            _contract_RoomCharge.ChargeID = ChargeID;
                            _contract_RoomCharge.RoomUnitPrice = RoomUnitPrice;
                            _contract_RoomCharge.GUID = guid;
                            _contract_RoomCharge.RoomCost = 0;
                            _contract_RoomCharge.RoomUseCount = 0;
                            _contract_RoomCharge.ReadyChargeTime = FirstReadyChargeTime;
                            _contract_RoomCharge.Contract_TempPriceID = 0;
                            chargeList.Add(_contract_RoomCharge);
                        }
                    }
                    if (RoomIDList.Contains(0))
                    {
                        if (count_index == roomList.Count)
                        {
                            if (temlist.Length > 0)
                            {
                                foreach (var item in temlist)
                                {
                                    Contract_RoomCharge _contract_RoomCharge = contract_charge_list.FirstOrDefault(p => p.Contract_TempPriceID == item.ID);
                                    if (_contract_RoomCharge == null)
                                    {
                                        _contract_RoomCharge = new Contract_RoomCharge();
                                        _contract_RoomCharge.AddTime = DateTime.Now;
                                        _contract_RoomCharge.Contract_TempPriceID = item.ID;
                                        _contract_RoomCharge.RoomUseCount = 0;
                                    }
                                    _contract_RoomCharge.ContractID = ContractID;
                                    _contract_RoomCharge.RoomID = 0;
                                    _contract_RoomCharge.ChargeID = ChargeID;
                                    _contract_RoomCharge.RoomUnitPrice = item.CalculatePrice;
                                    _contract_RoomCharge.RoomStartTime = item.CalculateStartTime;
                                    _contract_RoomCharge.RoomEndTime = item.CalculateEndTime;
                                    _contract_RoomCharge.RoomNewEndTime = item.CalculateEndTime;
                                    if (charge.CategoryID == 3 || charge.CategoryID == 4)
                                    {
                                        _contract_RoomCharge.RoomStartTime = DateTime.MinValue;
                                        _contract_RoomCharge.RoomEndTime = DateTime.MinValue;
                                    }
                                    _contract_RoomCharge.RoomCost = item.CalculateCost > 0 ? item.CalculateCost : 0;
                                    _contract_RoomCharge.GUID = guid;
                                    _contract_RoomCharge.ReadyChargeTime = item.ReadyChargeTime;
                                    chargeList.Add(_contract_RoomCharge);
                                }
                            }
                            else
                            {
                                Contract_RoomCharge _contract_RoomCharge = new Contract_RoomCharge();
                                _contract_RoomCharge.AddTime = DateTime.Now;
                                _contract_RoomCharge.ContractID = ContractID;
                                _contract_RoomCharge.RoomID = 0;
                                _contract_RoomCharge.ChargeID = ChargeID;
                                _contract_RoomCharge.RoomUnitPrice = RoomUnitPrice;
                                _contract_RoomCharge.GUID = guid;
                                _contract_RoomCharge.RoomCost = 0;
                                _contract_RoomCharge.RoomUseCount = 0;
                                _contract_RoomCharge.ReadyChargeTime = FirstReadyChargeTime;
                                _contract_RoomCharge.Contract_TempPriceID = 0;
                                chargeList.Add(_contract_RoomCharge);
                            }
                        }
                    }
                }
            }
            #endregion
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    foreach (var item in contract_Charge_List)
                    {
                        item.Save(helper);
                    }
                    foreach (var item in chargeList)
                    {
                        item.IsReRent = canrent == 1;
                        item.Save(helper);
                    }
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    Utility.LogHelper.WriteError("ContractHandler", "命令:savecontractcharge", ex);
                    WebUtil.WriteJson(context, new { status = false });
                    return;
                }
            }
            if (chargeList.Count > 0 && canedit == 1)
            {
                string EditType = "";
                if (canrent == 1)
                {
                    EditType = "htsfbzxuzu";
                }
                else if (canedit == 1)
                {
                    EditType = "htsfbzxz";
                }
                CommHelper.SaveContractRoomChargeRemoveorAddLog(chargeList.ToArray(), WebUtil.GetUser(context).RealName, EditType);
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void getaddcontractchargeparam(HttpContext context)
        {
            string guid = context.Request.Params["guid"];
            int ContractID = WebUtil.GetIntValue(context, "ContractID");
            var roomlist = ViewContractRoom.GetViewContractRoomListByContractID(ContractID, guid);
            var roomitems = roomlist.Select(p =>
            {
                var item = new { RoomID = p.RoomID, Name = p.Name };
                return item;
            }).ToList();
            //roomitems.Insert(0, new { RoomID = 0, Name = "合同所有房间" });
            var chargelist = ChargeSummary.GetChargeSummaries();
            WebUtil.WriteJson(context, new { status = true, roomlist = roomitems, chargelist = chargelist });
        }
        private void removecontractroom(HttpContext context)
        {
            int canedit = WebUtil.GetIntValue(context, "canedit");
            string IDs = context.Request.Params["IDList"];
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(IDs);
            var roomList = new Foresight.DataAccess.Contract_Room[] { };
            if (IDList.Count > 0)
            {
                roomList = Foresight.DataAccess.Contract_Room.GetContract_RoomListByIDList(IDList);
                string cmdtext = "delete from [Contract_Room] where ID in (" + string.Join(",", IDList.ToArray()) + ");";
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
                        helper.Rollback();
                        Utility.LogHelper.WriteError("ContractHandler", "命令:removecontractroom", ex);
                        WebUtil.WriteJson(context, new { status = false });
                        return;
                    }
                }
            }
            else
            {
                WebUtil.WriteJson(context, new { status = true });
                return;
            }
            if (roomList.Length > 0 && canedit == 1)
            {
                CommHelper.SaveContractRoomRemoveorAddLog(roomList, WebUtil.GetUser(context).RealName);
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void savecontractroom(HttpContext context)
        {
            string guid = context.Request.Params["guid"];
            int canedit = WebUtil.GetIntValue(context, "canedit");
            int ContractID = WebUtil.GetIntValue(context, "ContractID");
            string ProjectIDs = context.Request.Params["ProjectIDList"];
            string RoomIDs = context.Request.Params["RoomIDList"];
            List<int> ProjectIDList = JsonConvert.DeserializeObject<List<int>>(ProjectIDs);
            List<int> RoomIDList = JsonConvert.DeserializeObject<List<int>>(RoomIDs);
            var list = Project.GetProjectList(ProjectIDList, RoomIDList);
            List<Contract_Room> roomList = new List<Contract_Room>();
            var contractRoomList = Contract_Room.GetContract_RoomList(ContractID, guid, 0);
            foreach (var project in list)
            {
                var myContractRoom = contractRoomList.FirstOrDefault(p => p.RoomID == project.ID);
                if (myContractRoom == null)
                {
                    myContractRoom = new Contract_Room();
                    myContractRoom.RoomID = project.ID;
                    myContractRoom.ContractID = ContractID;
                    myContractRoom.GUID = guid;
                    roomList.Add(myContractRoom);
                }
            }
            if (roomList.Count == 0)
            {
                WebUtil.WriteJson(context, new { status = true });
                return;
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    foreach (var item in roomList)
                    {
                        item.Save(helper);
                    }
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    Utility.LogHelper.WriteError("ContractHandler", "命令:savecontractroom", ex);
                    WebUtil.WriteJson(context, new { status = false });
                    return;
                }
            }
            if (roomList.Count > 0 && canedit == 1)
            {
                CommHelper.SaveContractRoomRemoveorAddLog(roomList.ToArray(), WebUtil.GetUser(context).RealName, "htzlzyxz");
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void loadcontractroomlist(HttpContext context)
        {
            try
            {
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                string guid = context.Request.Params["guid"];
                int ContractID = WebUtil.GetIntValue(context, "ContractID");
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                string SearchAreas = context.Request.Params["SearchAreas"];
                List<string> SearchAreaList = new List<string>();
                if (!string.IsNullOrEmpty(SearchAreas))
                {
                    SearchAreaList = JsonConvert.DeserializeObject<List<string>>(SearchAreas);
                }
                DataGrid dg = ViewContractRoom.GetViewContractRoomListByKeywords(ContractID, guid, "order by ID desc", startRowIndex, pageSize);
                string result = JsonConvert.SerializeObject(dg);
                context.Response.Write(result);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.WriteError("ContractHandler", "命令:loadcontractroomlist", ex);
                context.Response.Write("{\"rows\":[],\"total\":0,\"page\":0}");
            }
        }
        private void loadcontractsummarygrid(HttpContext context)
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
                if (RoomIDList.Count == 0)
                {
                    if (!string.IsNullOrEmpty(ProjectIDs))
                    {
                        ProjectIDList = JsonConvert.DeserializeObject<List<int>>(ProjectIDs).Where(p => p != 1).ToList();
                    }
                    ProjectIDList = WebUtil.GetMyProjects(WebUtil.GetUser(context).UserID, ProjectIDList).Where(p => p.ID != 1).Select(p => p.ID).ToList();
                }
                DateTime StartTime = WebUtil.GetDateValue(context, "StartTime");
                DateTime EndTime = WebUtil.GetDateValue(context, "EndTime");
                DateTime RentStartTime = WebUtil.GetDateValue(context, "RentStartTime");
                DateTime RentEndTime = WebUtil.GetDateValue(context, "RentEndTime");
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                string Keywords = context.Request.Params["Keywords"];
                string ContractStatus = context.Request.Params["ContractStatus"];
                int onlyexpired = WebUtil.GetIntValue(context, "onlyexpired");
                bool canexport = WebUtil.GetBoolValue(context, "canexport");
                DataGrid dg = Foresight.DataAccess.ContractDetail.GetContractDetailGridByKeywords(Keywords, ContractStatus, RoomIDList, ProjectIDList, StartTime, EndTime, RentStartTime, RentEndTime, "order by [AddTime] desc", startRowIndex, pageSize, onlyexpired: onlyexpired, canexport: canexport);
                if (canexport)
                {
                    string downloadurl = string.Empty;
                    string error = string.Empty;
                    bool status = APPCode.ExportHelper.DownLoadContractSummaryData(dg, out downloadurl, out error);
                    WebUtil.WriteJson(context, new { status = status, downloadurl = downloadurl, error = error });
                    return;
                }
                string result = JsonConvert.SerializeObject(dg);
                context.Response.Write(result);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.WriteError(LogModule, "命令:loadcontractsummarygrid", ex);
                context.Response.Write("{\"rows\":[],\"total\":0,\"page\":0}");
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
                    string cmdtext = "delete from [Contract_File] where ID=@ID";
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
        private void loadcontractattachs(HttpContext context)
        {
            int ID = int.Parse(context.Request.Params["ID"]);
            string FileType = context.Request.Params["FileType"];
            var list = Foresight.DataAccess.Contract_File.GetContract_FileAttachList(ID, FileType);
            var items = list.Select(p =>
            {
                var dic = p.ToJsonObject();
                dic["AttachedFilePath"] = string.IsNullOrEmpty(p.AttachedFilePath) ? string.Empty : WebUtil.GetContextPath() + p.AttachedFilePath;
                return dic;
            });
            context.Response.Write(JsonConvert.SerializeObject(items));
        }
        private void cancelcontract(HttpContext context)
        {
            Foresight.DataAccess.Contract_Stop stop = null;
            int ID = 0;
            int.TryParse(context.Request.Params["ID"], out ID);
            if (ID > 0)
            {
                stop = Foresight.DataAccess.Contract_Stop.GetContract_Stop(ID);
            }
            if (stop == null)
            {
                stop = new Foresight.DataAccess.Contract_Stop();
                stop.AddTime = DateTime.Now;
                stop.AddMan = context.Request.Params["AddMan"];
            }
            stop.ContractID = WebUtil.GetIntValue(context, "ContractID");
            stop.StopTime = getTimeValue(context, "tdStopTime");
            stop.ProcessMan = getValue(context, "tdProcessMan");
            stop.StopReason = getValue(context, "tdStopReason");
            var contract = Foresight.DataAccess.Contract.GetContract(stop.ContractID);
            contract.ContractStatus = Utility.EnumModel.ContractStatus.zhongzhi.ToString();
            List<Foresight.DataAccess.Contract_File> attachlist = new List<Foresight.DataAccess.Contract_File>();
            HttpFileCollection uploadFiles = context.Request.Files;
            for (int i = 0; i < uploadFiles.Count; i++)
            {
                HttpPostedFile postedFile = uploadFiles[i];
                string fileOriName = postedFile.FileName;
                if (fileOriName != "" && fileOriName != null)
                {
                    string extension = System.IO.Path.GetExtension(fileOriName).ToLower();
                    string fileName = DateTime.Now.ToFileTime().ToString() + extension;
                    string filepath = "/upload/Contract/";
                    string rootPath = HttpContext.Current.Server.MapPath("~" + filepath);
                    if (!System.IO.Directory.Exists(rootPath))
                    {
                        System.IO.Directory.CreateDirectory(rootPath);
                    }
                    string Path = rootPath + fileName;
                    postedFile.SaveAs(Path);
                    Foresight.DataAccess.Contract_File attach = new Foresight.DataAccess.Contract_File();
                    attach.FileOriName = fileOriName;
                    attach.AttachedFilePath = filepath + fileName;
                    attach.AddTime = DateTime.Now;
                    attach.FileType = "stop";
                    attachlist.Add(attach);
                }
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    contract.Save(helper);
                    stop.Save(helper);
                    foreach (var item in attachlist)
                    {
                        item.RelateID = stop.ID;
                        item.Save(helper);
                    }
                    string cmdtext = "delete from [RoomFee] where [ContractID]=" + contract.ID;
                    helper.Execute(cmdtext, CommandType.Text, new List<SqlParameter>());
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    Utility.LogHelper.WriteError(LogModule, "命令: cancelcontract", ex);
                    helper.Rollback();
                    WebUtil.WriteJson(context, new { status = false });
                    return;
                }
            }
            #region 删除日志
            var user = WebUtil.GetUser(context);
            APPCode.CommHelper.SaveOperationLog(ID.ToString(), Utility.EnumModel.OperationModule.ContractZhongZhi.ToString(), "合同终止", user.UserID.ToString(), "Contract", user.LoginName, IsHide: true);
            APPCode.CommHelper.SaveOperationLog("用户" + user.LoginName + "终止了合同", Utility.EnumModel.OperationModule.ContractZhongZhi.ToString(), "合同终止", user.UserID.ToString(), "Contract", user.LoginName);
            #endregion
            WebUtil.WriteJson(context, new { status = true, ID = stop.ID });
        }
        private void saveapprove(HttpContext context)
        {
            Foresight.DataAccess.Contract_Approve approve = null;
            int ID = 0;
            int.TryParse(context.Request.Params["ID"], out ID);
            if (ID > 0)
            {
                approve = Foresight.DataAccess.Contract_Approve.GetContract_Approve(ID);
            }
            if (approve == null)
            {
                approve = new Foresight.DataAccess.Contract_Approve();
                approve.AddTime = DateTime.Now;
                approve.AddMan = context.Request.Params["AddMan"];
            }
            approve.ApproveStatus = "审核通过";
            approve.ContractID = WebUtil.GetIntValue(context, "ContractID");
            approve.JingShouTeam = getValue(context, "tdJingShouTeam");
            approve.JingShouPerson = getValue(context, "tdJingShouPerson");
            approve.ShareRole = getValue(context, "tdShareRole");
            approve.ApproveTime = getTimeValue(context, "tdApproveTime");
            approve.ApproveMan = getValue(context, "tdApproveMan");
            approve.YunYingModel = getValue(context, "tdYunYingModel");
            approve.BusinessYeTai = getValue(context, "tdBusinessYeTai");
            approve.BusinessRange = getValue(context, "tdBusinessRange");
            approve.ApproveDesc = getValue(context, "tdApproveDesc");
            var contract = Foresight.DataAccess.Contract.GetContract(approve.ContractID);
            contract.ContractStatus = Utility.EnumModel.ContractStatus.tongguo.ToString();
            List<Foresight.DataAccess.Contract_File> attachlist = new List<Foresight.DataAccess.Contract_File>();
            HttpFileCollection uploadFiles = context.Request.Files;
            for (int i = 0; i < uploadFiles.Count; i++)
            {
                HttpPostedFile postedFile = uploadFiles[i];
                string fileOriName = postedFile.FileName;
                if (fileOriName != "" && fileOriName != null)
                {
                    string extension = System.IO.Path.GetExtension(fileOriName).ToLower();
                    string fileName = DateTime.Now.ToFileTime().ToString() + extension;
                    string filepath = "/upload/Contract/";
                    string rootPath = HttpContext.Current.Server.MapPath("~" + filepath);
                    if (!System.IO.Directory.Exists(rootPath))
                    {
                        System.IO.Directory.CreateDirectory(rootPath);
                    }
                    string Path = rootPath + fileName;
                    postedFile.SaveAs(Path);
                    Foresight.DataAccess.Contract_File attach = new Foresight.DataAccess.Contract_File();
                    attach.FileOriName = fileOriName;
                    attach.AttachedFilePath = filepath + fileName;
                    attach.AddTime = DateTime.Now;
                    attach.FileType = "approve";
                    attachlist.Add(attach);
                }
            }
            var roomstate_list = Foresight.DataAccess.RoomState.GetRoomStates();
            var roomstate = roomstate_list.FirstOrDefault(p => p.Name.Equals("已租"));
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    contract.Save(helper);
                    approve.Save(helper);
                    foreach (var item in attachlist)
                    {
                        item.RelateID = approve.ID;
                        item.Save(helper);
                    }
                    if (roomstate != null)
                    {
                        string cmdtext = "update [RoomBasic] set [RoomStateID]=" + roomstate.ID + " where [RoomID] in (select [RoomID] from [Contract_Room] where [ContractID]=" + contract.ID + ")";
                        helper.Execute(cmdtext, CommandType.Text, new List<SqlParameter>());
                    }
                    helper.Commit();
                    context.Response.Write("{\"status\":true,\"ID\":" + approve.ID + "}");
                }
                catch (Exception ex)
                {
                    Utility.LogHelper.WriteError(LogModule, "命令: saveapprove", ex);
                    helper.Rollback();
                    context.Response.Write("{\"status\":false}");
                }
            }
        }
        private void savecontract(HttpContext context)
        {
            int canedit = WebUtil.GetIntValue(context, "canedit");
            Foresight.DataAccess.Contract contract = null;
            string precontractstr = string.Empty;
            int ContractID = WebUtil.GetIntValue(context, "ContractID");
            string guid = context.Request.Params["guid"];
            string AddMan = WebUtil.GetUser(context).RealName;
            if (ContractID > 0)
            {
                contract = Foresight.DataAccess.Contract.GetContract(ContractID);
                precontractstr = JsonConvert.SerializeObject(contract);
            }
            if (contract == null)
            {
                contract = new Foresight.DataAccess.Contract();
                contract.AddTime = DateTime.Now;
                contract.AddMan = AddMan;
                contract.ContractStatus = EnumModel.ContractStatus.yuding.ToString();
            }
            contract.RoomID = 0;
            contract.RentName = getValue(context, "tdRentName");
            contract.RoomUseFor = getValue(context, "tdRoomUseFor");
            contract.RoomStatus = getValue(context, "tdRoomStatus");
            contract.ContractNo = getValue(context, "tdContractNo");
            contract.ContractName = getValue(context, "tdContractName");
            contract.ContractDeposit = getDecimalValue(context, "tdContractDeposit");
            contract.TimeLimit = getIntValue(context, "tdTimeLimit");
            contract.SignTime = getTimeValue(context, "tdSignTime");
            contract.RentStartTime = getTimeValue(context, "tdRentStartTime");
            contract.RentEndTime = getTimeValue(context, "tdRentEndTime");
            contract.FreeDays = getIntValue(context, "tdFreeDays");
            contract.FreeStartTime = getTimeValue(context, "tdFreeStartTime");
            contract.FreeEndTime = getTimeValue(context, "tdFreeEndTime");
            contract.OpenTime = getTimeValue(context, "tdOpenTime");
            contract.InTime = getTimeValue(context, "tdInTime");
            contract.OutTime = getTimeValue(context, "tdOutTime");
            contract.RentPrice = getDecimalValue(context, "tdRentPrice");
            contract.RentRange = getValue(context, "tdRentRange");
            contract.ChargeRange = getValue(context, "tdChargeRange");
            contract.SellerProduct = getValue(context, "tdSellerProduct");
            contract.EveryYearUp = getDecimalValue(context, "tdEveryYearUp");
            contract.BrandModel = getValue(context, "tdBrandModel");
            contract.ContractSummary = getValue(context, "tdContractSummary");
            contract.PhoneNumber = getValue(context, "tdPhoneNumber");
            contract.Address = getValue(context, "tdAddress");
            contract.CustomerName = getValue(context, "tdCustomerName");
            contract.IDCardNo = getValue(context, "tdIDCardNo");
            contract.DeliverTime = getTimeValue(context, "tdDeliverTime");
            contract.IDCardAddress = getValue(context, "tdIDCardAddress");
            contract.RentUseFor = getValue(context, "tdRentUseFor");
            contract.BusinessLicense = getValue(context, "tdBusinessLicense");
            contract.ContractPhone = getValue(context, "tdContractPhone");
            contract.WarningTime = getTimeValue(context, "tdWarningTime");
            contract.InChargeMan = getValue(context, "tdInChargeMan");
            List<Foresight.DataAccess.Contract_File> attachlist = new List<Foresight.DataAccess.Contract_File>();
            HttpFileCollection uploadFiles = context.Request.Files;
            for (int i = 0; i < uploadFiles.Count; i++)
            {
                HttpPostedFile postedFile = uploadFiles[i];
                string fileOriName = postedFile.FileName;
                if (fileOriName != "" && fileOriName != null)
                {
                    string extension = System.IO.Path.GetExtension(fileOriName).ToLower();
                    string fileName = DateTime.Now.ToFileTime().ToString() + extension;
                    string filepath = "/upload/Contract/";
                    string rootPath = HttpContext.Current.Server.MapPath("~" + filepath);
                    if (!System.IO.Directory.Exists(rootPath))
                    {
                        System.IO.Directory.CreateDirectory(rootPath);
                    }
                    string Path = rootPath + fileName;
                    postedFile.SaveAs(Path);
                    Foresight.DataAccess.Contract_File attach = new Foresight.DataAccess.Contract_File();
                    attach.FileOriName = fileOriName;
                    attach.AttachedFilePath = filepath + fileName;
                    attach.AddTime = DateTime.Now;
                    attach.FileType = "addcontract";
                    attachlist.Add(attach);
                }
            }
            Contract_Room[] roomList = new Contract_Room[] { };
            Contract_ChargeSummary[] summaryList = new Contract_ChargeSummary[] { };
            Contract_RoomCharge[] chargeList = new Contract_RoomCharge[] { };
            if (ContractID <= 0)
            {
                summaryList = Contract_ChargeSummary.GetContract_ChargeSummaryList(ContractID, guid, 0);
                chargeList = Contract_RoomCharge.GetContract_RoomChargeList(ContractID, guid);
            }
            roomList = Contract_Room.GetContract_RoomListByContractID(ContractID, guid);
            List<RoomPhoneRelation> phoneList = new List<RoomPhoneRelation>();
            if (!string.IsNullOrEmpty(contract.ContractPhone) || !string.IsNullOrEmpty(contract.RentName))
            {
                var exist_phone_list = Foresight.DataAccess.RoomPhoneRelation.GetRoomPhoneRelationsByRoomIDList(roomList.Select(p => p.RoomID).ToList());
                foreach (var item in roomList)
                {
                    RoomPhoneRelation phone_relation = null;
                    if (contract.ID > 0)
                    {
                        phone_relation = exist_phone_list.FirstOrDefault(p => p.ContractID == item.ContractID);
                    }
                    if (phone_relation == null && !string.IsNullOrEmpty(contract.ContractPhone))
                    {
                        phone_relation = exist_phone_list.FirstOrDefault(p => p.RoomID == item.RoomID && p.RelatePhoneNumber.Equals(contract.ContractPhone));
                    }
                    if (phone_relation == null && !string.IsNullOrEmpty(contract.RentName))
                    {
                        phone_relation = exist_phone_list.FirstOrDefault(p => p.RoomID == item.RoomID && p.RelationName.Equals(contract.RentName));
                    }
                    if (phone_relation == null)
                    {
                        phone_relation = new RoomPhoneRelation();
                        phone_relation.RoomID = item.RoomID;
                        phone_relation.AddTime = DateTime.Now;
                        phone_relation.IsDefault = true;
                        phone_relation.IsChargeFee = true;
                        phone_relation.IsChargeMan = true;
                    }
                    phone_relation.RelatePhoneNumber = contract.ContractPhone;
                    phone_relation.RelationName = contract.RentName;
                    phone_relation.RelationType = Foresight.DataAccess.RelationTypeDefine.rentfamily.ToString();
                    phoneList.Add(phone_relation);
                }
            }
            string freeliststr = context.Request["freelist"];
            List<ContractFreeTimeModel> freemodellist = new List<ContractFreeTimeModel>();
            List<Contract_FreeTime> freelist = new List<Contract_FreeTime>();
            if (!string.IsNullOrEmpty(freeliststr))
            {
                freemodellist = JsonConvert.DeserializeObject<List<ContractFreeTimeModel>>(freeliststr);
            }
            foreach (var item in freemodellist)
            {
                Foresight.DataAccess.Contract_FreeTime freetime = null;
                if (item.ID > 0)
                {
                    freetime = Foresight.DataAccess.Contract_FreeTime.GetContract_FreeTime(item.ID);
                }
                if (freetime == null)
                {
                    freetime = new Contract_FreeTime();
                    freetime.AddTime = DateTime.Now;
                }
                freetime.FreeStartTime = item.StartTime;
                freetime.FreeEndTime = item.EndTime;
                freetime.FreeType = item.FreeType;
                if (item.FreeChargeIDs.Length > 0)
                {
                    item.FreeChargeIDs = item.FreeChargeIDs.Substring(1, item.FreeChargeIDs.Length - 2);
                    freetime.FreeChargeIDs = item.FreeChargeIDs;
                }
                freelist.Add(freetime);
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    if (!string.IsNullOrEmpty(contract.ContractNo))
                    {
                        var exist_contract = Foresight.DataAccess.Contract.GetContractByContractNo(contract.ContractNo, contract.ID > 0 ? contract.ID : 0, helper);
                        if (exist_contract != null && exist_contract.ID != contract.ID)
                        {
                            helper.Rollback();
                            WebUtil.WriteJson(context, new { status = false, msg = "该合同编号已存在" });
                            return;
                        }
                    }
                    contract.Save(helper);
                    foreach (var item in freelist)
                    {
                        item.ContractID = contract.ID;
                        item.Save(helper);
                    }
                    foreach (var item in phoneList)
                    {
                        item.ContractID = contract.ID;
                        item.Save(helper);
                    }
                    foreach (var item in attachlist)
                    {
                        item.RelateID = contract.ID;
                        item.Save(helper);
                    }
                    foreach (var item in roomList)
                    {
                        item.ContractID = contract.ID;
                        item.Save(helper);
                    }
                    foreach (var item in summaryList)
                    {
                        item.ContractID = contract.ID;
                        item.Save(helper);
                    }
                    foreach (var item in chargeList)
                    {
                        if (item.RoomStartTime == DateTime.MinValue)
                        {
                            item.RoomStartTime = contract.RentStartTime;
                        }
                        if (item.RoomEndTime == DateTime.MinValue)
                        {
                            item.RoomEndTime = contract.RentEndTime;
                        }
                        if (item.RoomNewEndTime == DateTime.MinValue)
                        {
                            item.RoomNewEndTime = contract.RentEndTime;
                        }
                        item.ContractID = contract.ID;
                        item.Save(helper);
                    }
                    string cmdtext = "update RoomFee set [DefaultChargeManName]=@DefaultChargeManName where [ContractID]=@ContractID;";
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    parameters.Add(new SqlParameter("@DefaultChargeManName", contract.RentName));
                    parameters.Add(new SqlParameter("@ContractID", contract.ID));
                    helper.Execute(cmdtext, CommandType.Text, parameters);
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    Utility.LogHelper.WriteError(LogModule, "命令: savecontract", ex);
                    helper.Rollback();
                    context.Response.Write("{\"status\":false}");
                    return;
                }
            }
            if (!string.IsNullOrEmpty(precontractstr) && canedit == 1)
            {
                Foresight.DataAccess.Contract precontract = JsonConvert.DeserializeObject<Foresight.DataAccess.Contract>(precontractstr);
                CommHelper.SaveContractLog(precontract, contract, WebUtil.GetUser(context).RealName);
            }
            context.Response.Write("{\"status\":true,\"ID\":" + contract.ID + "}");
        }
        private void loadcontractgrid(HttpContext context)
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
                bool ShowALL = false;
                if (RoomIDList.Count == 0)
                {
                    if (!string.IsNullOrEmpty(ProjectIDs))
                    {
                        ProjectIDList = JsonConvert.DeserializeObject<List<int>>(ProjectIDs).Where(p => p != 1).ToList();
                    }
                    ProjectIDList = WebUtil.GetMyProjects(WebUtil.GetUser(context).UserID, ProjectIDList).Where(p => p.ID != 1).Select(p => p.ID).ToList();
                }
                DateTime StartTime = WebUtil.GetDateValue(context, "StartTime");
                DateTime EndTime = WebUtil.GetDateValue(context, "EndTime");
                DateTime RentStartTime = WebUtil.GetDateValue(context, "RentStartTime");
                DateTime RentEndTime = WebUtil.GetDateValue(context, "RentEndTime");
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                string Keywords = context.Request.Params["Keywords"];
                string ContractStatus = context.Request.Params["ContractStatus"];
                bool IsDivideOn = WebUtil.GetBoolValue(context, "IsDivideOn");
                DataGrid dg = Foresight.DataAccess.Contract.GetContractGridByKeywords(Keywords, ContractStatus, RoomIDList, ProjectIDList, ShowALL, StartTime, EndTime, RentStartTime, RentEndTime, "order by [AddTime] desc", startRowIndex, pageSize, IsDivideOn: IsDivideOn);
                string result = JsonConvert.SerializeObject(dg);
                context.Response.Write(result);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.WriteError(LogModule, "命令:loadcontractgrid", ex);
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