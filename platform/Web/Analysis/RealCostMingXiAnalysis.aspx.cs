using Foresight.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utility;

namespace Web.Analysis
{
    public partial class RealCostMingXiAnalysis : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            }
        }
        private DataTable loadshoufeilvsummaryanalysicbyroom()
        {
            string PageCode = Utility.EnumModel.AnalysisChargeFieldPageCode.RealCostMingXinAnalysis.ToString();
            var chargesummary_list = Foresight.DataAccess.ChargeSummaryField.GetChargeSummaryFields(PageCode).Where(p => (!p.IsHide) || p.ChargeFieldID < 0).OrderBy(p => { return p.SortOrder < 0 ? int.MaxValue : p.SortOrder; }).ToArray();
            if (chargesummary_list.Length == 0)
            {
                return null;
            }
            var SummaryIDList = chargesummary_list.Select(p => p.ID).ToArray();
            string RoomIDs = this.hdRoomIDs.Value;
            List<int> RoomIDList = new List<int>();
            if (!string.IsNullOrEmpty(RoomIDs))
            {
                RoomIDList = JsonConvert.DeserializeObject<List<int>>(RoomIDs);
            }
            string ProjectIDs = this.hdProjectIDs.Value;
            List<int> ProjectIDList = new List<int>();
            if (RoomIDList.Count == 0)
            {
                if (!string.IsNullOrEmpty(ProjectIDs))
                {
                    ProjectIDList = JsonConvert.DeserializeObject<List<int>>(ProjectIDs).Where(p => p != 1).ToList();
                }
                ProjectIDList = WebUtil.GetMyProjects(WebUtil.GetUser(this.Context).UserID, ProjectIDList).Where(p => p.ID != 1).Select(p => p.ID).ToList();
            }
            DateTime StartChargeTime = WebUtil.GetDateTimeByStr(this.tdFeeStartTime.Value);
            DateTime EndChargeTime = WebUtil.GetDateTimeByStr(this.tdFeeEndTime.Value);
            long startRowIndex = 0;
            int pageSize = int.MaxValue;
            string Keywords = string.Empty;
            var dg = Foresight.DataAccess.ViewRoomBasic.GetViewRoomBasicGrid(ProjectIDList, RoomIDList, Keywords, string.Empty, startRowIndex, pageSize);
            var room_list = dg.rows as Foresight.DataAccess.ViewRoomBasic[];
            RoomIDList = room_list.Select(p => p.RoomID).ToList();
            ProjectIDList = new List<int>();
            var feehistory_list = Foresight.DataAccess.ViewRoomFeeHistoryDetail.GetViewRoomFeeHistoryDetailList(RoomIDList, StartChargeTime, EndChargeTime, DateTime.MinValue, DateTime.MinValue, UserID: WebUtil.GetUser(this.Context).UserID);
            feehistory_list = feehistory_list.Where(p => p.ChargeState == 1).ToArray();
            Dictionary<string, object> footer = new Dictionary<string, object>();
            footer["FullName"] = "合计";
            DataTable dt = new DataTable();
            dt.Columns.Add("FullName");
            dt.Columns.Add("RoomName");
            dt.Columns.Add("RelationName");
            foreach (var summary in chargesummary_list)
            {
                dt.Columns.Add(summary.ID + "_RealCost");
            }
            dt.Columns.Add("heji_RealCost");
            DataRow dr = null;
            foreach (var room in room_list)
            {
                dr = dt.NewRow();
                dr["FullName"] = room.FullName;
                dr["RoomName"] = room.Name;
                dr["RelationName"] = room.RelationName;
                decimal heji_RealCost = 0;
                foreach (var summary in chargesummary_list)
                {
                    decimal realcost = feehistory_list.Where(p => p.RoomID == room.RoomID && p.ChargeID == summary.ID).Sum(p => p.MonthTotalCost);
                    dr[summary.ID + "_RealCost"] = (realcost > 0 ? realcost : 0);
                    heji_RealCost += realcost > 0 ? realcost : 0;
                    decimal footer_realcost = 0;
                    if (footer.ContainsKey(summary.ID + "_RealCost"))
                    {
                        footer_realcost = Convert.ToDecimal(footer[summary.ID + "_RealCost"]);
                    }
                    footer[summary.ID + "_RealCost"] = (footer_realcost + (realcost > 0 ? realcost : 0));
                }
                dr["heji_RealCost"] = heji_RealCost;
                decimal footer_heji_realcost = 0;
                if (footer.ContainsKey("heji_RealCost"))
                {
                    footer_heji_realcost = Convert.ToDecimal(footer["heji_RealCost"]);
                }
                footer["heji_RealCost"] = (footer_heji_realcost + heji_RealCost);
                dt.Rows.Add(dr);
            }
            dr = dt.NewRow();
            dr["FullName"] = "合计";
            foreach (var item in footer)
            {
                dr[item.Key] = item.Value;
            }
            dt.Rows.Add(dr);
            return dt;
        }
        protected void btnExport_Click(object sender, EventArgs e)
        {

            var dt = loadshoufeilvsummaryanalysicbyroom();
            if (dt == null)
            {
                base.RegisterClientMessage("没有可导出的数据");
                return;
            }
            int totalcount = 0;
            string PageCode = Utility.EnumModel.AnalysisChargeFieldPageCode.RealCostMingXinAnalysis.ToString();
            var chargesummary_list = Foresight.DataAccess.ChargeSummaryField.GetChargeSummaryFields(PageCode).Where(p => (!p.IsHide) || p.ChargeFieldID < 0).OrderBy(p => { return p.SortOrder < 0 ? int.MaxValue : p.SortOrder; }).ToArray();
            int firstline_count = 2;
            for (int i = 0; i < chargesummary_list.Length; i++)
            {
                var item = chargesummary_list[i];
                totalcount++;
                firstline_count++;
            }
            firstline_count = firstline_count + 1;
            TableCell[] header = new TableCell[totalcount + 4];
            for (int i = 0; i < header.Length; i++)
            {
                header[i] = new TableHeaderCell();
            }
            header[0].Text = "资源位置";
            header[1].Text = "房间信息";
            header[2].Text = "客户名称";
            for (int i = 0; i < chargesummary_list.Length; i++)
            {
                var item = chargesummary_list[i];
                header[i + 3].Text = item.Name;
            }
            header[firstline_count].Text = "合计";
            string FileName = "实收明细表" + DateTime.Now.ToString("yyyyMMddHHmmss") + "_导出.xls";
            ExcelProcess.ExportMultiHelper.DataTable2Excel(dt, header, FileName, new Dictionary<int, int>(), 0);
        }
    }
}