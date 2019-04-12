using ExcelProcess;
using Foresight.DataAccess;
using Foresight.DataAccess.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utility;

namespace Web.Contract
{
    public partial class NewAddContract : BasePage
    {
        public string guid = string.Empty;
        public int ContractID = 0;
        public int FinalContractID = 0;
        public int TopContractID = 0;
        public Foresight.DataAccess.Contract contract = null;
        public string op = string.Empty;
        public bool canAdd = false;
        public bool canEdit = false;
        public bool canSaveLog = false;
        public bool canPrint = false;
        public bool canRent = false;
        public bool canView = false;
        public bool canNewRent = false;
        public bool canChangeRent = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                op = !string.IsNullOrEmpty(Request.QueryString["op"]) ? Request.QueryString["op"] : string.Empty;
                guid = Request.QueryString["guid"];
                if (string.IsNullOrEmpty(guid))
                {
                    guid = System.Guid.NewGuid().ToString();
                }
                int.TryParse(Request.QueryString["ID"], out ContractID);
                if (this.op.Equals("add"))
                {
                    canAdd = true;
                }
                if (this.op.Equals("edit") || this.op.Equals("newrent") || this.op.Equals("changerent"))
                {
                    canEdit = true;
                }
                contract = Foresight.DataAccess.Contract.GetContract(ContractID);
                if (contract == null)
                {
                    canEdit = true;
                    ContractID = 0;
                }
                else
                {
                    canPrint = true;
                    if (contract.ContractStatus.Equals("yuding"))
                    {
                        canEdit = true;
                    }
                    if (this.op.Equals("rent"))
                    {
                        canRent = true;
                        canSaveLog = true;
                    }
                    if (this.op.Equals("changerent"))
                    {
                        canChangeRent = true;
                        canSaveLog = true;
                    }
                    if (this.op.Equals("edit"))
                    {
                        canSaveLog = true;
                    }
                    if (this.op.Equals("view"))
                    {
                        canView = true;
                    }
                    if (this.op.Equals("newrent"))
                    {
                        canNewRent = true;
                        canSaveLog = true;
                        canPrint = false;
                        canAdd = true;
                    }
                    SetInfo(contract);
                }
            }
        }
        private void SetInfo(Foresight.DataAccess.Contract data)
        {
            this.FinalContractID = ContractID;
            if (this.canNewRent || this.canChangeRent)
            {
                this.ContractID = 0;
                this.TopContractID = data.ID;
                if (data.TopContractID > 0)
                {
                    var topContract = Foresight.DataAccess.Contract.GetContract(data.TopContractID);
                    if (topContract != null)
                    {
                        TopContractID = topContract.ID;
                    }
                }
                //资源列表
                var contractRoomList = Contract_Room.GetContract_RoomListByContractID(TopContractID);
                //收费标准
                var chargeList = Contract_ChargeSummary.GetContract_ChargeSummaryList(TopContractID, string.Empty, 0);
                using (SqlHelper helper = new SqlHelper())
                {
                    try
                    {
                        helper.BeginTransaction();
                        foreach (var item in contractRoomList)
                        {
                            var dataItem = new Contract_Room
                            {
                                ContractID = 0,
                                GUID = guid,
                                ChargeID = item.ChargeID,
                                RoomID = item.RoomID,
                                RentName = item.RentName,
                                RoomLocation = item.RoomLocation,
                                RoomArea = item.RoomArea
                            };
                            dataItem.Save(helper);
                        }
                        foreach (var item in chargeList)
                        {
                            var dataItem = new Contract_ChargeSummary
                            {
                                ContractID = 0,
                                GUID = guid,
                                ChargeID = item.ChargeID,
                                RoomType = item.RoomType,
                            };
                            dataItem.Save(helper);
                        }
                        helper.Commit();
                    }
                    catch (Exception)
                    {
                        helper.Rollback();
                    }
                }
                if (this.canChangeRent)
                {
                    //免租期
                    var freeList = Contract_FreeTime.GetContract_FreeTimeList(TopContractID);
                    //收费标准
                    var contractChargeList = ViewContractChargeSummary.GetViewContractChargeSummaryByContractID(TopContractID).Where(p => p.CalcualteRestCost > 0); //Contract_RoomCharge.GetContract_RoomChargeListByContractID(TopContractID);
                    using (SqlHelper helper = new SqlHelper())
                    {
                        try
                        {
                            helper.BeginTransaction();
                            foreach (var item in contractChargeList)
                            {
                                var dataItem = new Contract_RoomCharge
                                {
                                    ContractID = 0,
                                    GUID = guid,
                                    ChargeID = item.ChargeID,
                                    RoomID = item.RoomID,
                                    RoomUnitPrice = item.RoomUnitPrice,
                                    RoomStartTime = item.RoomStartTime,
                                    RoomEndTime = item.RoomEndTime,
                                    RoomNewEndTime = item.RoomNewEndTime,
                                    RoomCost = item.RoomCost,
                                    Remark = item.Remark,
                                    AddTime = DateTime.Now,
                                    RoomUseCount = item.RoomUseCount,
                                    ReadyChargeTime = item.ReadyChargeTime,
                                    Contract_TempPriceID = item.Contract_TempPriceID,
                                    IsReRent = item.IsReRent,
                                    IsContractDivideFee = item.IsContractDivideFee
                                };
                                dataItem.Save(helper);
                            }
                            helper.Commit();
                        }
                        catch (Exception)
                        {
                            helper.Rollback();
                        }
                    }
                }
            }
        }
    }
}