using ExcelProcess;
using Foresight.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utility;

namespace Web.Charge
{
    public partial class ApproveFeeOrder : BasePage
    {
        public Foresight.DataAccess.RoomFeeOrder roomfeeOrder;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["ID"]))
            {
                Response.End();
                return;
            }
            int ID = 0;
            if (!int.TryParse(Request.QueryString["ID"], out ID))
            {
                Response.End();
                return;
            }
            roomfeeOrder = Foresight.DataAccess.RoomFeeOrder.GetRoomFeeOrder(ID);
            if (roomfeeOrder == null)
            {
                Response.End();
                return;
            }
            if (roomfeeOrder.ApproveStatus != 0)
            {
                SetInfo(roomfeeOrder);
            }
            else
            {
                this.tdApproveTime.Value = DateTime.Now.ToString("yyyy-MM-dd");
                this.tdApproveMan.Value = WebUtil.GetUser(this.Context).RealName;
                this.hdApproveUserID.Value = WebUtil.GetUser(this.Context).UserID.ToString();
            }
            SetSearchInfo(roomfeeOrder);
        }
        private void SetInfo(Foresight.DataAccess.RoomFeeOrder data)
        {
            this.tdApproveTime.Value = data.ApproveTime == DateTime.MinValue ? "" : data.ApproveTime.ToString("yyyy-MM-dd HH:mm:ss");
            this.tdApproveMan.Value = data.ApproveMan;
            this.hdApproveUserID.Value = data.ApproveManUserID == int.MinValue ? "" : data.ApproveManUserID.ToString();
            this.tdApproveStatus.Value = data.ApproveStatus.ToString();
            this.tdApproveRemark.Value = data.ApproveRemark;
        }
        private void SetSearchInfo(Foresight.DataAccess.RoomFeeOrder data)
        {
            if (!string.IsNullOrEmpty(data.ProjectID))
            {
                int[] ProjectIDList = data.ProjectID.Split(',').Select(p =>
                {
                    int _ID = 0;
                    int.TryParse(p, out _ID);
                    return _ID;

                }).ToArray();
                var projects = Foresight.DataAccess.Project.GetProjectListByIDs(ProjectIDList.ToList());
                var NameList = projects.Select(p => !string.IsNullOrEmpty(p.FullName) ? p.FullName : p.Name).ToArray();
                this.tdProjectName.InnerHtml = string.Join("|", NameList);
            }
            this.tdAddMan.Value = data.OrderUserMan;
            this.tdOrderTime.Value = data.OrderTime != DateTime.MinValue ? data.OrderTime.ToString("yyyy-MM-dd HH:mm:ss") : "";
            this.tdStartTime.Value = data.ChargeStartTime != DateTime.MinValue ? data.ChargeStartTime.ToString("yyyy-MM-dd HH:mm:ss") : "";
            this.tdEndTime.Value = data.ChargeEndTime != DateTime.MinValue ? data.ChargeEndTime.ToString("yyyy-MM-dd HH:mm:ss") : "";
            this.tdOperator.Value = data.Operator;
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                string FullName = "交班报表";
                List<ChargeMoneyTypeDetails> ShouTypeSummaryList = new List<ChargeMoneyTypeDetails>();
                List<ChargeMoneyTypeDetails> FuTypeSummaryList = new List<ChargeMoneyTypeDetails>();
                searchorderbyids(out ShouTypeSummaryList, out FuTypeSummaryList);
                int totalCount = Math.Max(ShouTypeSummaryList.Count, FuTypeSummaryList.Count);
                List<WorkBookModel> dtlist = new List<WorkBookModel>();
                #region 收款方式汇总
                DataTable dt = new DataTable();
                DataRow dr = dt.NewRow();
                dt.Columns.Add("收款方式"); //0
                dt.Columns.Add("收款金额"); //1
                dt.Columns.Add("付款方式"); //2
                dt.Columns.Add("付款金额"); //3
                for (int i = 0; i < totalCount; i++)
                {
                    dr = dt.NewRow();
                    if (i < ShouTypeSummaryList.Count)
                    {
                        dr["收款方式"] = ShouTypeSummaryList[i].ChargeTypeName;
                        dr["收款金额"] = ShouTypeSummaryList[i].RealCost;
                    }
                    if (i < FuTypeSummaryList.Count)
                    {
                        dr["付款方式"] = FuTypeSummaryList[i].ChargeTypeName;
                        dr["付款金额"] = FuTypeSummaryList[i].RealCost;
                    }
                    dt.Rows.Add(dr);
                }
                WorkBookModel workBookModel = new WorkBookModel();
                workBookModel.dt = dt;
                workBookModel.SheetName = "收款方式汇总";
                dtlist.Add(workBookModel);
                #endregion
                #region 单据明细
                #endregion
                var dg = LoadRoomFeeHistoryList();
                var list = dg.rows as ViewRoomFeeHistory[];
                dt = new DataTable();
                dt.Columns.Add("资源位置");
                dt.Columns.Add("资源编号");
                dt.Columns.Add("收款单号");
                dt.Columns.Add("单据状态");
                dt.Columns.Add("收款人");
                dt.Columns.Add("收款日期");
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
                for (int i = 0; i < list.Length; i++)
                {
                    var item = list[i];
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
                    dr["资源位置"] = item.FullName;
                    dr["资源编号"] = item.RoomName;
                    dr["收款单号"] = item.PrintNumber;
                    dr["单据状态"] = item.ChargeStateDesc;
                    dr["收款人"] = item.ChargeMan;
                    dr["收款日期"] = WebUtil.GetStrDate(item.ChargeTime);
                    dr["收费项目"] = item.ChargeName;
                    dr["费项分类"] = item.ChargeTypeName;
                    dr["计费开始日期"] = WebUtil.GetStrDate(item.StartTime);
                    dr["计费结束日期"] = WebUtil.GetStrDate(item.EndTime);
                    dr["单价"] = item.UnitPrice > 0 ? item.UnitPrice : 0;
                    dr["面积/用量"] = item.UseCount;
                    dr["实收金额"] = item.RealCost;
                    dr["减免金额"] = item.Discount > 0 ? item.Discount : 0;
                    dr["上次读数"] = item.FinalStartPoint;
                    dr["本次读数"] = item.FinalEndPoint;
                    dr["本次用量"] = item.UseCount > 0 ? item.UseCount : 0;
                    dr["备注"] = item.Remark;
                    dt.Rows.Add(dr);
                    if (i == list.Length - 1)
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
                    if (i < list.Length - 1)
                    {
                        if (list[i].PrintNumber.Equals(list[i + 1].PrintNumber) && !string.IsNullOrEmpty(list[i].PrintNumber))
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
                var footerlist = dg.footer as ViewRoomFeeHistory[];
                if (footerlist.Length > 0)
                {
                    var footeritem = footerlist[0];
                    dr = dt.NewRow();
                    dr["资源位置"] = "合计";
                    dr["实收金额"] = footeritem.RealCost;
                    dr["减免金额"] = footeritem.Discount > 0 ? footeritem.Discount : 0;
                    dr["本次用量"] = footeritem.TotalPoint > 0 ? footeritem.TotalPoint : 0;
                    dt.Rows.Add(dr);
                }
                workBookModel = new WorkBookModel();
                workBookModel.dt = dt;
                workBookModel.SheetName = "单据明细";
                workBookModel.rangeList = rangeList;
                dtlist.Add(workBookModel);

                string FileName = FullName + DateTime.Now.ToString("yyyyMMddHHmmss") + "_导出.xls";
                string filepath = Server.MapPath("~/upload/ExcelExport/ExportStartTime/");
                base.ExportMultiFile(FileName, filepath, dtlist);
            }
            catch (Exception)
            {

            }
        }
        private void searchorderbyids(out List<ChargeMoneyTypeDetails> ShouTypeSummaryList, out List<ChargeMoneyTypeDetails> FuTypeSummaryList)
        {
            int RoomFeeOrderID = WebUtil.GetIntByStr(this.hdRoomFeeOrderID.Value, 0);
            List<int> HistoryIDList = new List<int>();
            List<int> ChargeState = new List<int>();
            ShouTypeSummaryList = new List<ChargeMoneyTypeDetails>();
            FuTypeSummaryList = new List<ChargeMoneyTypeDetails>();
            Foresight.DataAccess.Ui.DataGrid dg = ChargeMoneyTypeDetails.GetHistorySummaryGroupByTypeName(new List<int>(), new List<int>(), DateTime.MinValue, DateTime.MinValue, string.Empty, int.MinValue, int.MinValue, RoomFeeOrderID, true, HistoryIDList, UserID: WebUtil.GetUser(this.Context).UserID);
            ChargeMoneyTypeDetails[] list = dg.rows as ChargeMoneyTypeDetails[];
            ShouTypeSummaryList = list.Where(p => p.RealCost > 0).ToList();

            dg = ChargeMoneyTypeDetails.GetDepositSummaryGroupByTypeName(new List<int>(), new List<int>(), DateTime.MinValue, DateTime.MinValue, 1, string.Empty, RoomFeeOrderID, true, HistoryIDList, UserID: WebUtil.GetUser(this.Context).UserID);
            ChargeMoneyTypeDetails[] list4 = dg.rows as ChargeMoneyTypeDetails[];
            FuTypeSummaryList = list4.Where(p => p.RealCost > 0).ToList();
        }
        private Foresight.DataAccess.Ui.DataGrid LoadRoomFeeHistoryList()
        {
            try
            {
                int CompanyID = 0;
                List<int> RoomIDList = new List<int>();
                List<int> ProjectIDList = new List<int>();
                int FeeID = 0;
                int RoomFeeOrderID = WebUtil.GetIntByStr(this.hdRoomFeeOrderID.Value, 0);
                DateTime StartChargeTime = DateTime.MinValue;
                DateTime EndChargeTime = DateTime.MinValue;
                bool IncludIsCharged = false;
                bool IncludePreCharge = false;
                bool IncludeDepoistCharge = false;
                int DepoistStatus = int.MinValue;
                int PreChargeStatus = int.MinValue;
                long startRowIndex = 0;
                int pageSize = int.MaxValue;
                int[] ChargeManID = new int[] { };
                int[] ChargeSummaryID = new int[] { };
                int[] ChargeTypeID = new int[] { };
                int[] CategoryID = new int[] { };
                List<int> ChargeStatusIDList = (new int[] { 1, 3, 4, 6, 7 }).ToList();
                bool IsRoomFeeSearch = true;
                bool IsCuiShou = false;
                int ContractID = 0;
                bool ExcludeCuiShou = false;
                List<int> HistoryIDList = new List<int>();
                Foresight.DataAccess.Ui.DataGrid dg = ViewRoomFeeHistory.GetViewRoomFeeHistoryGridByRoomID(RoomIDList, ProjectIDList, FeeID, StartChargeTime, EndChargeTime, IncludIsCharged, IncludePreCharge, IncludeDepoistCharge, DepoistStatus, PreChargeStatus, CompanyID, ChargeManID, ChargeSummaryID, ChargeTypeID, CategoryID, ChargeStatusIDList, RoomFeeOrderID, IsRoomFeeSearch, IsCuiShou, ContractID, "order by [PrintNumber] desc", startRowIndex, pageSize, HistoryIDList, ExcludeCuiShou, IncludeFooter: true, UserID: WebUtil.GetUser(this.Context).UserID);
                return dg;
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("ApproveFeeOrder.aspx", "visit: LoadRoomFeeHistoryList", ex);
                return null;
            }
        }
    }
}