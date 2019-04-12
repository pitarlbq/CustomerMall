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
    public partial class AddContract_Basic : BasePage
    {
        public string guid = string.Empty;
        public int ContractID = 0;
        public int TopContractID = 0;
        public Foresight.DataAccess.Contract contract = null;
        public Foresight.DataAccess.Contract_Approve approve = null;
        public Foresight.DataAccess.Contract_Stop stop = null;
        public string op = string.Empty;
        public bool canEdit = false;
        public bool cansavelog = false;
        public bool canprint = false;
        public bool canRent = false;
        public bool canAdd = false;
        public bool canView = false;
        public bool canNewRent = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                op = !string.IsNullOrEmpty(Request.QueryString["op"]) ? Request.QueryString["op"] : string.Empty;
                guid = System.Guid.NewGuid().ToString();
                int.TryParse(Request.QueryString["ID"], out ContractID);
                if (this.op.Equals("add"))
                {
                    canAdd = true;
                }
                if (this.op.Equals("edit") || this.op.Equals("newrent"))
                {
                    canEdit = true;
                }
                contract = Foresight.DataAccess.Contract.GetContract(ContractID);
                if (contract == null)
                {
                    canEdit = true;
                }
                else
                {
                    canprint = true;
                    if (contract.ContractStatus.Equals("yuding"))
                    {
                        canEdit = true;
                    }
                    if (this.op.Equals("rent"))
                    {
                        canRent = true;
                        cansavelog = true;
                    }
                    if (this.op.Equals("edit"))
                    {
                        cansavelog = true;
                    }
                    if (this.op.Equals("view"))
                    {
                        canView = true;
                    }
                    if (this.op.Equals("newrent"))
                    {
                        canNewRent = true;
                        cansavelog = true;
                        canprint = false;
                        canAdd = true;
                    }
                    SetInfo(contract);
                    if (!canNewRent)
                    {
                        approve = Foresight.DataAccess.Contract_Approve.GetContract_ApproveByContractID(contract.ID);
                        stop = Foresight.DataAccess.Contract_Stop.GetContract_StopByContractID(contract.ID);
                    }
                    else
                    {
                        int.TryParse(Request.QueryString["ID"], out TopContractID);
                        ContractID = 0;
                        var contractRoomList = Contract_Room.GetContract_RoomListByContractID(contract.ID);
                        using (SqlHelper helper = new SqlHelper())
                        {
                            try
                            {
                                helper.BeginTransaction();
                                foreach (var item in contractRoomList)
                                {
                                    var data = new Contract_Room
                                    {
                                        ContractID = 0,
                                        GUID = guid,
                                        ChargeID = item.ChargeID,
                                        RoomID = item.RoomID,
                                        RentName = item.RentName,
                                        RoomLocation = item.RoomLocation,
                                        RoomArea = item.RoomArea
                                    };
                                    data.Save(helper);
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
        private void SetInfo(Foresight.DataAccess.Contract data)
        {
            this.tdRentName.Value = data.RentName;
            this.tdContractPhone.Value = data.ContractPhone;
            this.tdContractNo.Value = data.ContractNo;
            this.tdContractName.Value = data.ContractName;
            this.tdContractDeposit.Value = data.ContractDeposit > decimal.MinValue ? data.ContractDeposit.ToString() : "";
            this.tdTimeLimit.Value = data.TimeLimit > int.MinValue ? data.TimeLimit.ToString() : "";
            this.tdRentStartTime.Value = data.RentStartTime > DateTime.MinValue ? data.RentStartTime.ToString("yyyy-MM-dd") : "";
            this.tdRentEndTime.Value = data.RentEndTime > DateTime.MinValue ? data.RentEndTime.ToString("yyyy-MM-dd") : "";
            this.tdFreeDays.Value = data.FreeDays > int.MinValue ? data.FreeDays.ToString() : "";
            this.tdRentPrice.Value = data.RentPrice > decimal.MinValue ? data.RentPrice.ToString() : "";
            this.tdContractSummary.Value = data.ContractSummary;
            //this.tdWarningTime.Value = data.WarningTime > DateTime.MinValue ? data.WarningTime.ToString("yyyy-MM-dd") : "";
            //this.tdContractStatus.Value = data.ContractStatusDesc;
            if (this.canNewRent)
            {
                this.tdRentStartTime.Value = data.RentEndTime > DateTime.MinValue ? data.RentEndTime.AddDays(1).ToString("yyyy-MM-dd") : "";
                this.tdRentEndTime.Value = "";
                int TopContractID = data.ID;
                string ContractNo = data.ContractNo;
                if (data.TopContractID > 0)
                {
                    var topContract = Foresight.DataAccess.Contract.GetContract(data.TopContractID);
                    if (topContract != null)
                    {
                        TopContractID = topContract.ID;
                        ContractNo = topContract.ContractNo;
                    }
                }
                int total = Foresight.DataAccess.Contract.GetRelatedContractCountByID(TopContractID, 1);
                this.tdContractNo.Value = ContractNo + "(续" + (total + 1).ToString() + ")";
            }
        }
        protected void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                int contract_id = 0;
                int.TryParse(Request.QueryString["ID"], out contract_id);
                var contract = Foresight.DataAccess.Contract.GetContract(contract_id);
                if (contract == null)
                {
                    return;
                }
                string FullName = "合同信息";
                List<WorkBookModel> dtlist = new List<WorkBookModel>();
                #region 合同基本信息
                DataTable dt = new DataTable();
                DataRow dr = dt.NewRow();
                dt.Columns.Add("合同编号");
                dt.Columns.Add("合同名称");
                dt.Columns.Add("客户名称");
                dt.Columns.Add("联系方式");
                dt.Columns.Add("合同状态");
                dt.Columns.Add("开始日期");
                dt.Columns.Add("结束日期");
                dt.Columns.Add("预警日期");
                dt.Columns.Add("铺位功能");
                dt.Columns.Add("铺位状态");
                dt.Columns.Add("租赁用途");
                dt.Columns.Add("合同押金");
                dt.Columns.Add("合同期限");
                dt.Columns.Add("签约日期");
                dt.Columns.Add("免租天数");
                dt.Columns.Add("免租开始日期");
                dt.Columns.Add("免租结束日期");
                dt.Columns.Add("开业日期");
                dt.Columns.Add("进场日期");
                dt.Columns.Add("退场日期");
                dt.Columns.Add("租金价格");
                dt.Columns.Add("计费周期");
                dt.Columns.Add("收费周期");
                dt.Columns.Add("经营商品");
                dt.Columns.Add("每年递增");
                dt.Columns.Add("业态品类/品牌");
                dt.Columns.Add("合同描述");
                dt.Columns.Add("联系电话");
                dt.Columns.Add("通讯地址");
                dt.Columns.Add("客户联系人");
                dt.Columns.Add("身份证号");
                dt.Columns.Add("交付时间");
                dt.Columns.Add("身份证地址");
                dt.Columns.Add("营业执照");

                dr["合同编号"] = contract.ContractNo;
                dr["合同名称"] = contract.ContractName;
                dr["客户名称"] = contract.RentName;
                dr["联系方式"] = contract.ContractPhone;
                dr["合同状态"] = contract.ContractStatusDesc;
                dr["开始日期"] = WebUtil.GetStrDate(contract.RentStartTime);
                dr["结束日期"] = WebUtil.GetStrDate(contract.RentEndTime);
                dr["预警日期"] = WebUtil.GetStrDate(contract.WarningTime);
                dr["铺位功能"] = contract.RoomUseFor;
                dr["铺位状态"] = contract.RoomStatus;
                dr["租赁用途"] = contract.RentUseFor;
                dr["合同押金"] = contract.ContractDeposit > 0 ? contract.ContractDeposit : 0;
                dr["合同期限"] = contract.TimeLimit > 0 ? contract.TimeLimit.ToString() + "个月" : "";
                dr["签约日期"] = WebUtil.GetStrDate(contract.SignTime);
                dr["免租天数"] = contract.FreeDays.ToString() + "天";
                dr["免租开始日期"] = WebUtil.GetStrDate(contract.FreeStartTime);
                dr["免租结束日期"] = WebUtil.GetStrDate(contract.FreeEndTime);
                dr["开业日期"] = WebUtil.GetStrDate(contract.OpenTime);
                dr["进场日期"] = WebUtil.GetStrDate(contract.InTime);
                dr["退场日期"] = WebUtil.GetStrDate(contract.OutTime);
                dr["租金价格"] = contract.RentPrice > 0 ? contract.RentPrice : 0;
                dr["计费周期"] = contract.RentRange;
                dr["收费周期"] = contract.ChargeRange;
                dr["经营商品"] = contract.SellerProduct;
                dr["每年递增"] = contract.EveryYearUp;
                dr["业态品类/品牌"] = contract.BrandModel;
                dr["合同描述"] = contract.ContractSummary;
                dr["联系电话"] = contract.PhoneNumber;
                dr["通讯地址"] = contract.Address;
                dr["客户联系人"] = contract.CustomerName;
                dr["身份证号"] = contract.IDCardNo;
                dr["交付时间"] = WebUtil.GetStrDate(contract.DeliverTime, "yyyy-MM-dd HH:mm:ss");
                dr["身份证地址"] = contract.IDCardAddress;
                dr["营业执照"] = contract.BusinessLicense;
                dt.Rows.Add(dr);
                WorkBookModel workBookModel = new WorkBookModel();
                workBookModel.dt = dt;
                workBookModel.SheetName = "基本信息";
                dtlist.Add(workBookModel);
                #endregion
                #region 租赁资源
                var contractroomlist = loadcontractroomlist(contract_id);
                dt = new DataTable();
                dt.Columns.Add("资源位置");
                dt.Columns.Add("资源编号");
                dt.Columns.Add("房间类型");
                dt.Columns.Add("合同面积");
                for (int i = 0; i < contractroomlist.Length; i++)
                {
                    var item = contractroomlist[i];
                    dr = dt.NewRow();
                    dr["资源位置"] = item.FullName;
                    dr["资源编号"] = item.Name;
                    dr["房间类型"] = item.RoomType;
                    dr["合同面积"] = item.ContractArea > 0 ? item.ContractArea : 0;
                    dt.Rows.Add(dr);
                }
                workBookModel = new WorkBookModel();
                workBookModel.dt = dt;
                workBookModel.SheetName = "租赁资源";
                dtlist.Add(workBookModel);
                #endregion
                #region 免租期
                var contractfreetimelist = getcontractfreetime(contract_id);
                dt = new DataTable();
                dt.Columns.Add("免租开始日期");
                dt.Columns.Add("免租结束日期");
                dt.Columns.Add("免租方式");
                dt.Columns.Add("免租收费项目");
                for (int i = 0; i < contractfreetimelist.Count; i++)
                {
                    var item = contractfreetimelist[i];
                    dr = dt.NewRow();
                    dr["免租开始日期"] = WebUtil.GetStrDate(WebUtil.GetDateTimeByStr(item["StartTime"].ToString()));
                    dr["免租结束日期"] = WebUtil.GetStrDate(WebUtil.GetDateTimeByStr(item["EndTime"].ToString()));
                    dr["免租方式"] = WebUtil.GetIntByStr(item["FreeType"].ToString()) == 1 ? "扣减应收" : "减免金额";
                    dr["免租收费项目"] = item["FreeChargeNames"];
                    dt.Rows.Add(dr);
                }
                workBookModel = new WorkBookModel();
                workBookModel.dt = dt;
                workBookModel.SheetName = "免租期";
                dtlist.Add(workBookModel);
                #endregion
                #region 收费标准
                var contractchargelist = loadcontractchargelist(contract_id, contract.RentStartTime, contract.RentEndTime);
                dt = new DataTable();
                dt.Columns.Add("房源位置");
                dt.Columns.Add("房号");
                dt.Columns.Add("收费项目");
                dt.Columns.Add("单价");
                dt.Columns.Add("面积");
                dt.Columns.Add("计费开始日期");
                dt.Columns.Add("计费结束日期");
                dt.Columns.Add("计费停用日期");
                dt.Columns.Add("应收金额");
                dt.Columns.Add("已收金额");
                dt.Columns.Add("未收金额");
                dt.Columns.Add("减免金额");
                dt.Columns.Add("计费规则");
                dt.Columns.Add("备注");
                for (int i = 0; i < contractchargelist.Length; i++)
                {
                    var item = contractchargelist[i];
                    dr = dt.NewRow();
                    dr["房源位置"] = string.IsNullOrEmpty(item.FullName) ? "所有房间" : item.FullName;
                    dr["房号"] = item.Name;
                    dr["收费项目"] = item.ChargeName;
                    dr["单价"] = item.CalculateUnitPrice;
                    dr["面积"] = item.CalculateUseCount;
                    dr["计费开始日期"] = WebUtil.GetStrDate(item.CalculateStartTime);
                    dr["计费结束日期"] = WebUtil.GetStrDate(item.CalculateEndTime);
                    dr["计费停用日期"] = WebUtil.GetStrDate(item.CalculateNewEndTime);
                    dr["应收金额"] = item.CalcualteTotalCost;
                    dr["已收金额"] = item.CalcualtePayCost;
                    dr["未收金额"] = item.CalcualteRestCost;
                    dr["减免金额"] = item.CalcualteDiscount;
                    dr["计费规则"] = item.ChargeTypeDesc;
                    dr["备注"] = item.Remark;
                    dt.Rows.Add(dr);
                }
                workBookModel = new WorkBookModel();
                workBookModel.dt = dt;
                workBookModel.SheetName = "收费标准";
                dtlist.Add(workBookModel);
                #endregion
                #region 合同应收
                var discountlist = Foresight.DataAccess.ChargeDiscount.GetChargeDiscounts().Where(p => (DateTime.Now >= p.StartTime && (DateTime.Now <= p.EndTime || p.EndTime == DateTime.MinValue))).OrderBy(p => p.SortOrder);
                var roomfeelist = LoadRoomFeeList(contract_id);
                dt = new DataTable();
                dt.Columns.Add("资源编号");
                dt.Columns.Add("合同编号");
                dt.Columns.Add("客户名称");
                dt.Columns.Add("收费项目");
                dt.Columns.Add("单价");
                dt.Columns.Add("合同面积");
                dt.Columns.Add("计费开始日期");
                dt.Columns.Add("计费结束日期");
                dt.Columns.Add("计费停用日期");
                dt.Columns.Add("应收金额");
                dt.Columns.Add("已收金额");
                dt.Columns.Add("未收金额");
                dt.Columns.Add("减免金额");
                dt.Columns.Add("减免方案");
                dt.Columns.Add("逾期");
                dt.Columns.Add("备注信息");
                for (int i = 0; i < roomfeelist.Length; i++)
                {
                    var item = roomfeelist[i];
                    dr = dt.NewRow();
                    dr["资源编号"] = item.RoomName;
                    dr["合同编号"] = item.ContractNo;
                    dr["客户名称"] = item.RentName;
                    dr["收费项目"] = item.Name;
                    dr["单价"] = item.CalculateUnitPrice > 0 ? item.CalculateUnitPrice : 0;
                    dr["合同面积"] = item.CalculateUseCount > 0 ? item.CalculateUseCount : 0;
                    dr["计费开始日期"] = WebUtil.GetStrDate(item.CalculateStartTime);
                    dr["计费结束日期"] = WebUtil.GetStrDate(item.CalculateEndTime);
                    dr["计费停用日期"] = WebUtil.GetStrDate(item.NewEndTime);
                    dr["应收金额"] = item.TotalCost > 0 ? item.TotalCost : 0;
                    dr["已收金额"] = item.TotalRealCost > 0 ? item.TotalRealCost : 0;
                    dr["未收金额"] = calculate_restcost(item.TotalCost, item.TotalRealCost, item.Discount);
                    dr["减免金额"] = item.Discount > 0 ? item.Discount : 0;
                    if (item.DiscountID > 0)
                    {
                        var discount = discountlist.FirstOrDefault(p => p.ID == item.DiscountID);
                        dr["减免方案"] = discount != null ? discount.DiscountName : "";
                    }
                    dr["逾期"] = calculateOutDays(item.CalculateStartTime);
                    dr["备注信息"] = item.RemarkNote;
                    dt.Rows.Add(dr);
                }
                workBookModel = new WorkBookModel();
                workBookModel.dt = dt;
                workBookModel.SheetName = "合同应收";
                dtlist.Add(workBookModel);
                #endregion
                #region 合同已收
                var roomfeehistorylist = LoadRoomFeeHistoryList(contract_id);
                dt = new DataTable();
                dt.Columns.Add("收款单号");
                dt.Columns.Add("单据状态");
                dt.Columns.Add("收款人");
                dt.Columns.Add("收款日期");
                dt.Columns.Add("房号");
                dt.Columns.Add("收费项目");
                dt.Columns.Add("费项分类");
                dt.Columns.Add("计费开始日期");
                dt.Columns.Add("计费结束日期");
                dt.Columns.Add("单价");
                dt.Columns.Add("面积/用量");
                dt.Columns.Add("实收金额");
                dt.Columns.Add("减免金额");
                dt.Columns.Add("上次读数");
                dt.Columns.Add("本次读数");
                dt.Columns.Add("本次用量");
                dt.Columns.Add("备注");
                List<CellRangeAddressModel> rangeList = new List<CellRangeAddressModel>();
                CellRangeAddressModel model = new CellRangeAddressModel();
                CellRangeAddressModel model1 = new CellRangeAddressModel();
                CellRangeAddressModel model2 = new CellRangeAddressModel();
                CellRangeAddressModel model3 = new CellRangeAddressModel();
                for (int i = 0; i < roomfeehistorylist.Length; i++)
                {
                    var item = roomfeehistorylist[i];
                    if (i == 0)
                    {
                        model = new CellRangeAddressModel();
                        model.FirstRow = (i + 1);
                        model1 = new CellRangeAddressModel();
                        model1.FirstRow = (i + 1);
                        model2 = new CellRangeAddressModel();
                        model2.FirstRow = (i + 1);
                        model3 = new CellRangeAddressModel();
                        model3.FirstRow = (i + 1);
                    }
                    dr = dt.NewRow();
                    dr["收款单号"] = item.PrintNumber;
                    dr["单据状态"] = item.ChargeStateDesc;
                    dr["收款人"] = item.ChargeMan;
                    dr["收款日期"] = WebUtil.GetStrDate(item.ChargeTime);
                    dr["房号"] = item.RoomName;
                    dr["收费项目"] = item.ChargeName;
                    dr["费项分类"] = item.ChargeTypeName;
                    dr["计费开始日期"] = WebUtil.GetStrDate(item.StartTime);
                    dr["计费结束日期"] = WebUtil.GetStrDate(item.EndTime);
                    dr["单价"] = item.UnitPrice > 0 ? item.UnitPrice : 0;
                    dr["面积/用量"] = item.UseCount > 0 ? item.UseCount : 0;
                    dr["实收金额"] = item.RealCost > 0 ? item.RealCost : 0;
                    dr["减免金额"] = item.Discount > 0 ? item.Discount : 0;
                    dr["上次读数"] = item.FinalStartPoint;
                    dr["本次读数"] = item.FinalEndPoint;
                    dr["本次用量"] = item.UseCount > 0 ? item.UseCount : 0;
                    dr["备注"] = item.Remark;
                    dt.Rows.Add(dr);
                    if (i == roomfeehistorylist.Length - 1)
                    {
                        if (model.IsUse)
                        {
                            rangeList.Add(model);
                        }
                        if (model1.IsUse)
                        {
                            rangeList.Add(model1);
                        }
                        if (model2.IsUse)
                        {
                            rangeList.Add(model2);
                        }
                        if (model3.IsUse)
                        {
                            rangeList.Add(model3);
                        }
                    }
                    if (i < roomfeehistorylist.Length - 1)
                    {
                        if (roomfeehistorylist[i].PrintNumber.Equals(roomfeehistorylist[i + 1].PrintNumber) && !string.IsNullOrEmpty(roomfeehistorylist[i].PrintNumber))
                        {
                            if (dt.Columns["收款单号"] != null)
                            {
                                model.IsUse = true;
                                model.LastRow = (i + 2);
                                model.FirstCol = dt.Columns["收款单号"].Ordinal;
                                model.LastCol = dt.Columns["收款单号"].Ordinal;
                            }
                            if (dt.Columns["单据状态"] != null)
                            {
                                model1.IsUse = true;
                                model1.LastRow = (i + 2);
                                model1.FirstCol = dt.Columns["单据状态"].Ordinal;
                                model1.LastCol = dt.Columns["单据状态"].Ordinal;
                            }
                            if (dt.Columns["收款日期"] != null)
                            {
                                model2.IsUse = true;
                                model2.LastRow = (i + 2);
                                model2.FirstCol = dt.Columns["收款日期"].Ordinal;
                                model2.LastCol = dt.Columns["收款日期"].Ordinal;
                            }
                            if (dt.Columns["收款人"] != null)
                            {
                                model3.IsUse = true;
                                model3.LastRow = (i + 2);
                                model3.FirstCol = dt.Columns["收款人"].Ordinal;
                                model3.LastCol = dt.Columns["收款人"].Ordinal;
                            }
                        }
                        else
                        {
                            if (model.IsUse)
                            {
                                rangeList.Add(model);
                            }
                            if (model1.IsUse)
                            {
                                rangeList.Add(model1);
                            }
                            if (model2.IsUse)
                            {
                                rangeList.Add(model2);
                            }
                            if (model3.IsUse)
                            {
                                rangeList.Add(model3);
                            }
                            model = new CellRangeAddressModel();
                            model.FirstRow = (i + 2);
                            model1 = new CellRangeAddressModel();
                            model1.FirstRow = (i + 2);
                            model2 = new CellRangeAddressModel();
                            model2.FirstRow = (i + 2);
                            model3 = new CellRangeAddressModel();
                            model3.FirstRow = (i + 2);
                        }
                    }
                }
                workBookModel = new WorkBookModel();
                workBookModel.dt = dt;
                workBookModel.SheetName = "合同已收";
                workBookModel.rangeList = rangeList;
                dtlist.Add(workBookModel);
                #endregion
                string FileName = FullName + DateTime.Now.ToString("yyyyMMddHHmmss") + "_导出.xls";
                string filepath = Server.MapPath("~/upload/ExcelExport/ExportStartTime/");
                base.ExportMultiFile(FileName, filepath, dtlist);
            }
            catch (Exception)
            {

            }
        }
        private ViewRoomFeeHistory[] LoadRoomFeeHistoryList(int ContractID)
        {
            ViewRoomFeeHistory[] list = new ViewRoomFeeHistory[] { };
            try
            {
                int CompanyID = 0;
                List<int> RoomIDList = new List<int>();
                List<int> ProjectIDList = WebUtil.GetMyProjects(WebUtil.GetUser(this.Context).UserID).Where(p => p.ID != 1).Select(p => p.ID).ToList();
                int FeeID = 0;
                DateTime StartChargeTime = DateTime.MinValue;
                DateTime EndChargeTime = DateTime.MinValue;
                bool IncludIsCharged = false;
                bool IncludePreCharge = false;
                bool IncludeDepoistCharge = false;
                int DepoistStatus = int.MinValue;
                int PreChargeStatus = int.MinValue;
                long startRowIndex = 0;
                int pageSize = int.MaxValue;
                string ChargeMans = string.Empty;
                int[] ChargeManID = new int[] { };
                int[] ChargeSummaryID = new int[] { };
                int[] ChargeTypeID = new int[] { };
                int[] CategoryID = new int[] { };
                List<int> ChargeStatusIDList = new List<int>();
                int RoomFeeOrderID = 0;
                bool IsRoomFeeSearch = false;
                bool IsCuiShou = false;
                bool ExcludeCuiShou = false;
                List<int> HistoryIDList = new List<int>();
                var dg = ViewRoomFeeHistory.GetViewRoomFeeHistoryGridByRoomID(RoomIDList, ProjectIDList, FeeID, StartChargeTime, EndChargeTime, IncludIsCharged, IncludePreCharge, IncludeDepoistCharge, DepoistStatus, PreChargeStatus, CompanyID, ChargeManID, ChargeSummaryID, ChargeTypeID, CategoryID, ChargeStatusIDList, RoomFeeOrderID, IsRoomFeeSearch, IsCuiShou, ContractID, "order by [PrintNumber] desc", startRowIndex, pageSize, HistoryIDList, ExcludeCuiShou, UserID: WebUtil.GetUser(this.Context).UserID);
                list = dg.rows as ViewRoomFeeHistory[];
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("AddContract.aspx", "visit: LoadRoomFeeHistoryList", ex);
            }
            return list;
        }
        private string calculateOutDays(DateTime StartTime)
        {
            if (StartTime == DateTime.MinValue)
            {
                return "0天";
            }
            if (StartTime > DateTime.Now)
            {
                return "0天";
            }
            TimeSpan span = DateTime.Now - StartTime;  //时间差的毫秒数
            int days = Convert.ToInt32(Math.Floor(span.TotalSeconds / (24 * 3600)));
            return days + "天";
        }
        private decimal calculate_restcost(decimal totalcost, decimal totalrealcost, decimal discount)
        {
            totalcost = totalcost > 0 ? totalcost : 0;
            totalrealcost = totalrealcost > 0 ? totalrealcost : 0;
            discount = discount > 0 ? discount : 0;
            decimal restcost = totalcost - totalrealcost - discount;
            return restcost > 0 ? restcost : 0;
        }
        private ViewContractRoom[] loadcontractroomlist(int ContractID)
        {
            ViewContractRoom[] list = new ViewContractRoom[] { };
            try
            {
                long startRowIndex = 0;
                int pageSize = int.MaxValue;
                var dg = ViewContractRoom.GetViewContractRoomListByKeywords(ContractID, string.Empty, "order by ID desc", startRowIndex, pageSize);
                list = dg.rows as ViewContractRoom[];
            }
            catch (Exception ex)
            {
                Utility.LogHelper.WriteError("AddContract.aspx", "命令:loadcontractroomlist", ex);
            }
            return list;
        }
        private List<Dictionary<string, object>> getcontractfreetime(int ContractID)
        {
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
                var dic = new Dictionary<string, object>();
                dic["ID"] = p.ID;
                dic["StartTime"] = p.FreeStartTime.ToString("yyyy-MM-dd");
                dic["EndTime"] = p.FreeEndTime.ToString("yyyy-MM-dd");
                dic["FreeType"] = p.FreeType;
                dic["FreeChargeNames"] = ChargeNames;
                dic["FreeChargeIDs"] = FreeChargeIDs;
                dic["count"] = count;
                return dic;
            }).ToList();
            return items;
        }
        private ViewContractChargeSummary[] loadcontractchargelist(int ContractID, DateTime StartTime, DateTime EndTime)
        {
            ViewContractChargeSummary[] list = new ViewContractChargeSummary[] { };
            try
            {
                long startRowIndex = 0;
                int pageSize = int.MaxValue;
                bool IsLinShi = false;
                var dg = ViewContractChargeSummary.GetViewContractChargeSummaryGrid(ContractID, string.Empty, StartTime, EndTime, "order by ID desc", startRowIndex, pageSize, IsLinShi, UserID: WebUtil.GetUser(this.Context).UserID);
                list = dg.rows as ViewContractChargeSummary[];
            }
            catch (Exception ex)
            {
                Utility.LogHelper.WriteError("AddContract.aspx", "命令:loadcontractchargelist", ex);
            }
            return list;
        }
        private ViewRoomFee[] LoadRoomFeeList(int ContractID)
        {
            ViewRoomFee[] list = new ViewRoomFee[] { };
            try
            {
                DateTime StartTime = DateTime.MinValue;
                DateTime EndTime = DateTime.MinValue;
                int CompanyID = WebUtil.GetCompanyID(this.Context);
                List<int> RoomIDList = new List<int>();
                List<int> ProjectIDList = WebUtil.GetMyProjects(WebUtil.GetUser(this.Context).UserID).Where(p => p.ID != 1).Select(p => p.ID).ToList();
                List<int> FeeTypeList = new List<int>();
                int[] ChargeSummaryID = new int[] { };
                int IsCharged = -1;
                List<int> RoomPropertyList = new List<int>();
                bool IsContractFee = true;
                bool IsRoomFee = true;
                bool IsCuiShou = false;
                bool IsAutoEndTime = false;
                string keywords = string.Empty;
                bool ExcludeHistoryChargeTime = false;
                list = ViewRoomFee.GetViewRoomFeeListByRoomID(RoomIDList, ProjectIDList, StartTime, EndTime, ChargeSummaryID, IsCharged, RoomPropertyList, IsRoomFee, IsContractFee, ContractID, IsAutoEndTime, keywords, ExcludeHistoryChargeTime, UserID: WebUtil.GetUser(this.Context).UserID);
                if (IsCuiShou)
                {
                    list = list.Where(p => p.CuiShouTotalCost > 0).ToArray();
                    if (EndTime > DateTime.MinValue)
                    {
                        list = list.Where(p => p.CalculateCuiShouStartTime <= EndTime).ToArray();
                    }
                }
                else
                {
                    list = list.Where(p => p.TotalCost > 0).ToArray();
                    if (EndTime > DateTime.MinValue)
                    {
                        list = list.Where(p => p.CalculateStartTime <= EndTime).ToArray();
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("AddContract.aspx", "visit: LoadRoomFeeList", ex);
            }
            return list;
        }
    }
}