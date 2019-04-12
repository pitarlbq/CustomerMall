using ExcelProcess;
using Foresight.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI.WebControls;

namespace Web.APPCode
{
    public class ExportHelper
    {
        public static bool DownLoadChargeFeeSummaryAnalysisData(Foresight.DataAccess.Ui.DataGrid dg, out string downloadurl, out string error)
        {
            downloadurl = string.Empty;
            error = string.Empty;
            var list = new List<Dictionary<string, object>>();
            var footers = new List<Dictionary<string, object>>();
            if (dg != null)
            {
                list = dg.rows as List<Dictionary<string, object>>;
                if (dg.footer != null)
                {
                    footers = dg.footer as List<Dictionary<string, object>>;
                }
            }
            if (list.Count == 0)
            {
                error = "没有可导出的数据";
                return false;
            }
            List<CellRangeAddressModel> rangeList = new List<CellRangeAddressModel>();
            decimal TotalCost = 0;
            decimal PayCost = 0;
            decimal UnPayCost = 0;
            DataTable dt = new DataTable();
            dt.Columns.Add("资源位置");
            dt.Columns.Add("资源编号");
            dt.Columns.Add("合同编号");
            dt.Columns.Add("合同名称");
            dt.Columns.Add("租户姓名");
            dt.Columns.Add("收费项目");
            dt.Columns.Add("计费开始日期");
            dt.Columns.Add("计费结束日期");
            dt.Columns.Add("收费日期");
            dt.Columns.Add("合同应收");
            dt.Columns.Add("已收金额");
            dt.Columns.Add("未收金额");
            dt.Columns.Add("减免方案");
            CellRangeAddressModel model1 = new CellRangeAddressModel();
            CellRangeAddressModel model2 = new CellRangeAddressModel();
            CellRangeAddressModel model3 = new CellRangeAddressModel();
            CellRangeAddressModel model4 = new CellRangeAddressModel();
            CellRangeAddressModel model5 = new CellRangeAddressModel();
            for (int i = 0; i < list.Count; i++)
            {
                if (i == 0)
                {

                    model1 = new CellRangeAddressModel();
                    model1.FirstRow = (i + 1);
                    model2 = new CellRangeAddressModel();
                    model2.FirstRow = (i + 1);
                    model3 = new CellRangeAddressModel();
                    model3.FirstRow = (i + 1);
                    model4 = new CellRangeAddressModel();
                    model4.FirstRow = (i + 1);
                    model5 = new CellRangeAddressModel();
                    model5.FirstRow = (i + 1);
                }
                DataRow dr = dt.NewRow();
                dr["资源位置"] = list[i]["FullName"];
                dr["资源编号"] = list[i]["RoomName"];
                dr["合同编号"] = list[i]["ContractNo"];
                dr["合同名称"] = list[i]["ContractName"];
                dr["租户姓名"] = list[i]["RentName"];
                dr["收费项目"] = list[i]["Name"];
                dr["计费开始日期"] = WebUtil.GetDateTimeByObj(list[i], "CalculateStartTime");
                dr["计费结束日期"] = WebUtil.GetDateTimeByObj(list[i], "CalculateEndTime");
                dr["收费日期"] = WebUtil.GetDateTimeByObj(list[i], "ReadyChargeTime");
                decimal ALLFinalTotalCost = WebUtil.GetDecimalByObj(list[i], "ALLFinalTotalCost");
                dr["合同应收"] = ALLFinalTotalCost;
                decimal TotalFinalPayCost = WebUtil.GetDecimalByObj(list[i], "TotalFinalPayCost");
                dr["已收金额"] = TotalFinalPayCost;
                decimal TotalFinalCost = WebUtil.GetDecimalByObj(list[i], "TotalFinalCost");
                dr["未收金额"] = TotalFinalCost;
                dr["减免方案"] = list[i]["ChargeDiscountName"];
                dt.Rows.Add(dr);
                TotalCost += (ALLFinalTotalCost > 0 ? ALLFinalTotalCost : 0);
                PayCost += (TotalFinalPayCost > 0 ? TotalFinalPayCost : 0);
                UnPayCost += (TotalFinalCost > 0 ? TotalFinalCost : 0);
                if (i == list.Count - 1)
                {
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
                    if (model4.IsUse)
                    {
                        rangeList.Add(model4);
                    }
                    if (model5.IsUse)
                    {
                        rangeList.Add(model5);
                    }
                }
                if (i < list.Count - 1)
                {
                    if (WebUtil.GetIntByObj(list[i], "ContractID") == WebUtil.GetIntByObj(list[i + 1], "ContractID"))
                    {
                        if (dt.Columns["资源位置"] != null)
                        {
                            model1.IsUse = true;
                            model1.LastRow = (i + 2);
                            model1.FirstCol = dt.Columns["资源位置"].Ordinal;
                            model1.LastCol = dt.Columns["资源位置"].Ordinal;
                        }
                        if (dt.Columns["资源编号"] != null)
                        {
                            model2.IsUse = true;
                            model2.LastRow = (i + 2);
                            model2.FirstCol = dt.Columns["资源编号"].Ordinal;
                            model2.LastCol = dt.Columns["资源编号"].Ordinal;
                        }
                        if (dt.Columns["合同编号"] != null)
                        {
                            model3.IsUse = true;
                            model3.LastRow = (i + 2);
                            model3.FirstCol = dt.Columns["合同编号"].Ordinal;
                            model3.LastCol = dt.Columns["合同编号"].Ordinal;
                        }
                        if (dt.Columns["合同名称"] != null)
                        {
                            model4.IsUse = true;
                            model4.LastRow = (i + 2);
                            model4.FirstCol = dt.Columns["合同名称"].Ordinal;
                            model4.LastCol = dt.Columns["合同名称"].Ordinal;
                        }
                        if (dt.Columns["租户姓名"] != null)
                        {
                            model5.IsUse = true;
                            model5.LastRow = (i + 2);
                            model5.FirstCol = dt.Columns["租户姓名"].Ordinal;
                            model5.LastCol = dt.Columns["租户姓名"].Ordinal;
                        }
                    }
                    else
                    {
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
                        if (model4.IsUse)
                        {
                            rangeList.Add(model4);
                        }
                        if (model5.IsUse)
                        {
                            rangeList.Add(model5);
                        }
                        model1 = new CellRangeAddressModel();
                        model1.FirstRow = (i + 2);
                        model2 = new CellRangeAddressModel();
                        model2.FirstRow = (i + 2);
                        model3 = new CellRangeAddressModel();
                        model3.FirstRow = (i + 2);
                        model4 = new CellRangeAddressModel();
                        model4.FirstRow = (i + 2);
                        model5 = new CellRangeAddressModel();
                        model5.FirstRow = (i + 2);
                    }
                }
            }
            DataRow totaldr = dt.NewRow();
            totaldr["合同编号"] = "合计";
            totaldr["合同应收"] = TotalCost;
            totaldr["已收金额"] = PayCost;
            totaldr["未收金额"] = UnPayCost;
            dt.Rows.Add(totaldr);
            string FileName = "合同收费_" + DateTime.Now.ToString("yyyyMMddHHmmss") + "_导入模板.xls";
            string filepath = "/upload/ExcelExport/ExportFee/";
            downloadurl = DownloadProcess(dt, FileName, filepath, rangeList: rangeList);
            return true;
        }
        public static bool DownLoadCkOutData(Foresight.DataAccess.Ui.DataGrid dg, out string downloadurl, out string error)
        {
            downloadurl = string.Empty;
            error = string.Empty;
            var list = new ViewCKProudctOutDetail[] { };
            if (dg != null)
            {
                list = dg.rows as ViewCKProudctOutDetail[];
            }
            if (list.Length == 0)
            {
                error = "没有可导出的数据";
                return false;
            }
            List<CellRangeAddressModel> rangeList = new List<CellRangeAddressModel>();
            decimal footerInTotalCount = 0;
            decimal footerInTotalPrice = 0;
            DataTable dt = new DataTable();
            dt.Columns.Add("出库单号");//0
            dt.Columns.Add("单据状态");//0
            dt.Columns.Add("领用人"); //1
            dt.Columns.Add("领用部门"); //2
            dt.Columns.Add("出库类别"); //3
            dt.Columns.Add("仓管员"); //3
            dt.Columns.Add("出库时间"); //4
            dt.Columns.Add("物品类别");//6
            dt.Columns.Add("物品名称");//6
            dt.Columns.Add("物品规格");//6
            dt.Columns.Add("出库数量"); //7
            dt.Columns.Add("出库单价"); //8
            dt.Columns.Add("出库金额"); //9
            dt.Columns.Add("备注"); //9
            CellRangeAddressModel model1 = new CellRangeAddressModel();
            CellRangeAddressModel model2 = new CellRangeAddressModel();
            CellRangeAddressModel model3 = new CellRangeAddressModel();
            CellRangeAddressModel model4 = new CellRangeAddressModel();
            CellRangeAddressModel model5 = new CellRangeAddressModel();
            CellRangeAddressModel model6 = new CellRangeAddressModel();
            CellRangeAddressModel model7 = new CellRangeAddressModel();
            for (int i = 0; i < list.Length; i++)
            {
                if (i == 0)
                {
                    model1 = new CellRangeAddressModel();
                    model1.FirstRow = (i + 1);
                    model2 = new CellRangeAddressModel();
                    model2.FirstRow = (i + 1);
                    model3 = new CellRangeAddressModel();
                    model3.FirstRow = (i + 1);
                    model4 = new CellRangeAddressModel();
                    model4.FirstRow = (i + 1);
                    model5 = new CellRangeAddressModel();
                    model5.FirstRow = (i + 1);
                    model6 = new CellRangeAddressModel();
                    model6.FirstRow = (i + 1);
                    model7 = new CellRangeAddressModel();
                    model7.FirstRow = (i + 1);
                }
                DataRow dr = dt.NewRow();
                dr["出库单号"] = list[i].OrderNumber;
                dr["单据状态"] = list[i].ApproveStatusDesc;
                dr["领用人"] = list[i].AcceptUserName;
                dr["领用部门"] = list[i].BelongTeamName;
                dr["出库类别"] = list[i].InCategoryName;
                dr["仓管员"] = list[i].AddUserName;
                dr["出库时间"] = WebUtil.GetStrDate(list[i].OutTime);
                dr["物品类别"] = list[i].ProductCategoryName;
                dr["物品名称"] = list[i].ProductName;
                dr["物品规格"] = list[i].ModelNumber;
                dr["出库数量"] = list[i].OutTotalCount;
                dr["出库单价"] = list[i].UnitPrice;
                dr["出库金额"] = list[i].OutTotalPrice;
                dr["备注"] = list[i].Remark;
                dt.Rows.Add(dr);
                footerInTotalCount += list[i].OutTotalCount;
                footerInTotalPrice += list[i].OutTotalPrice;
                if (i == list.Length - 1)
                {
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
                    if (model4.IsUse)
                    {
                        rangeList.Add(model4);
                    }
                    if (model5.IsUse)
                    {
                        rangeList.Add(model5);
                    }
                    if (model6.IsUse)
                    {
                        rangeList.Add(model6);
                    }
                    if (model7.IsUse)
                    {
                        rangeList.Add(model7);
                    }
                }
                if (i < list.Length - 1)
                {
                    if (list[i].OutSummaryID == list[i + 1].OutSummaryID)
                    {
                        if (dt.Columns["出库单号"] != null)
                        {
                            model1.IsUse = true;
                            model1.LastRow = (i + 2);
                            model1.FirstCol = dt.Columns["出库单号"].Ordinal;
                            model1.LastCol = dt.Columns["出库单号"].Ordinal;
                        }
                        if (dt.Columns["单据状态"] != null)
                        {
                            model2.IsUse = true;
                            model2.LastRow = (i + 2);
                            model2.FirstCol = dt.Columns["单据状态"].Ordinal;
                            model2.LastCol = dt.Columns["单据状态"].Ordinal;
                        }
                        if (dt.Columns["领用人"] != null)
                        {
                            model3.IsUse = true;
                            model3.LastRow = (i + 2);
                            model3.FirstCol = dt.Columns["领用人"].Ordinal;
                            model3.LastCol = dt.Columns["领用人"].Ordinal;
                        }
                        if (dt.Columns["领用部门"] != null)
                        {
                            model4.IsUse = true;
                            model4.LastRow = (i + 2);
                            model4.FirstCol = dt.Columns["领用部门"].Ordinal;
                            model4.LastCol = dt.Columns["领用部门"].Ordinal;
                        }
                        if (dt.Columns["出库类别"] != null)
                        {
                            model5.IsUse = true;
                            model5.LastRow = (i + 2);
                            model5.FirstCol = dt.Columns["出库类别"].Ordinal;
                            model5.LastCol = dt.Columns["出库类别"].Ordinal;
                        }
                        if (dt.Columns["仓管员"] != null)
                        {
                            model6.IsUse = true;
                            model6.LastRow = (i + 2);
                            model6.FirstCol = dt.Columns["仓管员"].Ordinal;
                            model6.LastCol = dt.Columns["仓管员"].Ordinal;
                        }
                        if (dt.Columns["出库时间"] != null)
                        {
                            model7.IsUse = true;
                            model7.LastRow = (i + 2);
                            model7.FirstCol = dt.Columns["出库时间"].Ordinal;
                            model7.LastCol = dt.Columns["出库时间"].Ordinal;
                        }
                    }
                    else
                    {
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
                        if (model4.IsUse)
                        {
                            rangeList.Add(model4);
                        }
                        if (model5.IsUse)
                        {
                            rangeList.Add(model5);
                        }
                        if (model6.IsUse)
                        {
                            rangeList.Add(model6);
                        }
                        if (model7.IsUse)
                        {
                            rangeList.Add(model7);
                        }
                        model1 = new CellRangeAddressModel();
                        model1.FirstRow = (i + 2);
                        model2 = new CellRangeAddressModel();
                        model2.FirstRow = (i + 2);
                        model3 = new CellRangeAddressModel();
                        model3.FirstRow = (i + 2);
                        model4 = new CellRangeAddressModel();
                        model4.FirstRow = (i + 2);
                        model5 = new CellRangeAddressModel();
                        model5.FirstRow = (i + 2);
                        model6 = new CellRangeAddressModel();
                        model6.FirstRow = (i + 2);
                        model7 = new CellRangeAddressModel();
                        model7.FirstRow = (i + 2);
                    }
                }
            }
            DataRow footerdr = dt.NewRow();
            footerdr["出库单号"] = "总合计";
            footerdr["出库数量"] = footerInTotalCount;
            footerdr["出库金额"] = footerInTotalPrice;
            dt.Rows.Add(footerdr);
            string FileName = "出库单_" + DateTime.Now.ToString("yyyyMMddHHmmss") + "_导入模板.xls";
            string filepath = "/upload/ExcelExport/ExportFee/";
            downloadurl = DownloadProcess(dt, FileName, filepath, rangeList: rangeList);
            return true;
        }
        public static bool DownLoadMaterialListData(Foresight.DataAccess.Ui.DataGrid dg, out string downloadurl, out string error)
        {
            downloadurl = string.Empty;
            error = string.Empty;
            var list = new ViewCustomerServiceInDetail[] { };
            if (dg != null)
            {
                list = dg.rows as ViewCustomerServiceInDetail[];
            }
            if (list.Length == 0)
            {
                error = "没有可导出的数据";
                return false;
            }
            List<CellRangeAddressModel> rangeList = new List<CellRangeAddressModel>();
            DataTable dt = new DataTable();
            dt.Columns.Add("服务单号");
            dt.Columns.Add("登记时间");
            dt.Columns.Add("是否有偿");
            dt.Columns.Add("是否出库");
            dt.Columns.Add("物品名称");
            dt.Columns.Add("物品规格");
            dt.Columns.Add("数量");
            dt.Columns.Add("单价");
            dt.Columns.Add("金额");
            dt.Columns.Add("维修工费");
            dt.Columns.Add("收费金额");
            dt.Columns.Add("结算状态");
            CellRangeAddressModel model1 = new CellRangeAddressModel();
            CellRangeAddressModel model2 = new CellRangeAddressModel();
            CellRangeAddressModel model3 = new CellRangeAddressModel();
            CellRangeAddressModel model4 = new CellRangeAddressModel();
            CellRangeAddressModel model5 = new CellRangeAddressModel();
            CellRangeAddressModel model6 = new CellRangeAddressModel();
            CellRangeAddressModel model7 = new CellRangeAddressModel();
            for (int i = 0; i < list.Length; i++)
            {
                if (i == 0)
                {

                    model1 = new CellRangeAddressModel();
                    model1.FirstRow = (i + 1);
                    model2 = new CellRangeAddressModel();
                    model2.FirstRow = (i + 1);
                    model3 = new CellRangeAddressModel();
                    model3.FirstRow = (i + 1);
                    model4 = new CellRangeAddressModel();
                    model4.FirstRow = (i + 1);
                    model5 = new CellRangeAddressModel();
                    model5.FirstRow = (i + 1);
                    model6 = new CellRangeAddressModel();
                    model6.FirstRow = (i + 1);
                    model7 = new CellRangeAddressModel();
                    model7.FirstRow = (i + 1);
                }
                DataRow dr = dt.NewRow();
                dr["服务单号"] = list[i].ServiceNumber;
                dr["登记时间"] = WebUtil.GetStrDate(list[i].AddTime);
                dr["是否有偿"] = list[i].PayStatusDesc;
                dr["是否出库"] = list[i].ChukuStatus;
                dr["物品名称"] = list[i].ProductName;
                dr["物品规格"] = list[i].ModelNumber;
                dr["数量"] = list[i].InTotalCount;
                dr["单价"] = list[i].UnitPrice;
                dr["金额"] = list[i].InTotalPrice;
                dr["维修工费"] = list[i].HandelFee;
                dr["收费金额"] = list[i].TotalFee;
                dr["结算状态"] = list[i].BalanceStatusDesc;
                dt.Rows.Add(dr);
                if (i == list.Length - 1)
                {
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
                    if (model4.IsUse)
                    {
                        rangeList.Add(model4);
                    }
                    if (model5.IsUse)
                    {
                        rangeList.Add(model5);
                    }
                    if (model6.IsUse)
                    {
                        rangeList.Add(model6);
                    }
                    if (model7.IsUse)
                    {
                        rangeList.Add(model7);
                    }
                }
                if (i < list.Length - 1)
                {
                    if (list[i].ServiceID == list[i + 1].ServiceID)
                    {
                        if (dt.Columns["服务单号"] != null)
                        {
                            model1.IsUse = true;
                            model1.LastRow = (i + 2);
                            model1.FirstCol = dt.Columns["服务单号"].Ordinal;
                            model1.LastCol = dt.Columns["服务单号"].Ordinal;
                        }
                        if (dt.Columns["登记时间"] != null)
                        {
                            model2.IsUse = true;
                            model2.LastRow = (i + 2);
                            model2.FirstCol = dt.Columns["登记时间"].Ordinal;
                            model2.LastCol = dt.Columns["登记时间"].Ordinal;
                        }
                        if (dt.Columns["是否有偿"] != null)
                        {
                            model3.IsUse = true;
                            model3.LastRow = (i + 2);
                            model3.FirstCol = dt.Columns["是否有偿"].Ordinal;
                            model3.LastCol = dt.Columns["是否有偿"].Ordinal;
                        }
                        if (dt.Columns["是否出库"] != null)
                        {
                            model4.IsUse = true;
                            model4.LastRow = (i + 2);
                            model4.FirstCol = dt.Columns["是否出库"].Ordinal;
                            model4.LastCol = dt.Columns["是否出库"].Ordinal;
                        }
                        if (dt.Columns["维修工费"] != null)
                        {
                            model5.IsUse = true;
                            model5.LastRow = (i + 2);
                            model5.FirstCol = dt.Columns["维修工费"].Ordinal;
                            model5.LastCol = dt.Columns["维修工费"].Ordinal;
                        }
                        if (dt.Columns["收费金额"] != null)
                        {
                            model6.IsUse = true;
                            model6.LastRow = (i + 2);
                            model6.FirstCol = dt.Columns["收费金额"].Ordinal;
                            model6.LastCol = dt.Columns["收费金额"].Ordinal;
                        }
                        if (dt.Columns["结算状态"] != null)
                        {
                            model7.IsUse = true;
                            model7.LastRow = (i + 2);
                            model7.FirstCol = dt.Columns["结算状态"].Ordinal;
                            model7.LastCol = dt.Columns["结算状态"].Ordinal;
                        }
                    }
                    else
                    {
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
                        if (model4.IsUse)
                        {
                            rangeList.Add(model4);
                        }
                        if (model5.IsUse)
                        {
                            rangeList.Add(model5);
                        }
                        if (model6.IsUse)
                        {
                            rangeList.Add(model6);
                        }
                        if (model7.IsUse)
                        {
                            rangeList.Add(model7);
                        }
                        model1 = new CellRangeAddressModel();
                        model1.FirstRow = (i + 2);
                        model2 = new CellRangeAddressModel();
                        model2.FirstRow = (i + 2);
                        model3 = new CellRangeAddressModel();
                        model3.FirstRow = (i + 2);
                        model4 = new CellRangeAddressModel();
                        model4.FirstRow = (i + 2);
                        model5 = new CellRangeAddressModel();
                        model5.FirstRow = (i + 2);
                        model6 = new CellRangeAddressModel();
                        model6.FirstRow = (i + 2);
                        model7 = new CellRangeAddressModel();
                        model7.FirstRow = (i + 2);
                    }
                }
            }
            string FileName = "物料清单_" + DateTime.Now.ToString("yyyyMMddHHmmss") + "_导入模板.xls";
            string filepath = "/upload/ExcelExport/ExportFee/";
            downloadurl = DownloadProcess(dt, FileName, filepath, rangeList: rangeList);
            return true;
        }
        public static bool DownLoadCKInData(Foresight.DataAccess.Ui.DataGrid dg, out string downloadurl, out string error)
        {
            downloadurl = string.Empty;
            error = string.Empty;
            var list = new ViewCKProudctInDetail[] { };
            if (dg != null)
            {
                list = dg.rows as ViewCKProudctInDetail[];
            }
            if (list.Length == 0)
            {
                error = "没有可导出的数据";
                return false;
            }
            List<CellRangeAddressModel> rangeList = new List<CellRangeAddressModel>();
            decimal footerInTotalCount = 0;
            decimal footerInTotalPrice = 0;
            DataTable dt = new DataTable();
            dt.Columns.Add("入库单号");//0
            dt.Columns.Add("单据状态");//0
            dt.Columns.Add("供应商简称"); //1
            dt.Columns.Add("入库类别"); //2
            dt.Columns.Add("仓管员"); //3
            dt.Columns.Add("入库时间"); //4
            dt.Columns.Add("仓库名称"); //5
            dt.Columns.Add("物品类别");//6
            dt.Columns.Add("物品名称");//6
            dt.Columns.Add("物品规格");//6
            dt.Columns.Add("入库数量"); //7
            dt.Columns.Add("入库单价"); //8
            dt.Columns.Add("入库金额"); //9
            dt.Columns.Add("备注"); //9
            CellRangeAddressModel model1 = new CellRangeAddressModel();
            CellRangeAddressModel model2 = new CellRangeAddressModel();
            CellRangeAddressModel model3 = new CellRangeAddressModel();
            CellRangeAddressModel model4 = new CellRangeAddressModel();
            CellRangeAddressModel model5 = new CellRangeAddressModel();
            CellRangeAddressModel model6 = new CellRangeAddressModel();
            for (int i = 0; i < list.Length; i++)
            {
                if (i == 0)
                {
                    model1 = new CellRangeAddressModel();
                    model1.FirstRow = (i + 1);
                    model2 = new CellRangeAddressModel();
                    model2.FirstRow = (i + 1);
                    model3 = new CellRangeAddressModel();
                    model3.FirstRow = (i + 1);
                    model4 = new CellRangeAddressModel();
                    model4.FirstRow = (i + 1);
                    model5 = new CellRangeAddressModel();
                    model5.FirstRow = (i + 1);
                    model6 = new CellRangeAddressModel();
                    model6.FirstRow = (i + 1);
                }
                DataRow dr = dt.NewRow();
                dr["入库单号"] = list[i].OrderNumber;
                dr["单据状态"] = list[i].ApproveStatusDesc;
                dr["供应商简称"] = list[i].ContractName;
                dr["入库类别"] = list[i].InCategoryName;
                dr["仓管员"] = list[i].AddUserName;
                dr["入库时间"] = WebUtil.GetStrDate(list[i].InTime);
                dr["仓库名称"] = list[i].CategoryName;
                dr["物品类别"] = list[i].ProductCategoryName;
                dr["物品名称"] = list[i].ProductName;
                dr["物品规格"] = list[i].ModelNumber;
                dr["入库数量"] = list[i].InTotalCount;
                dr["入库单价"] = list[i].UnitPrice;
                dr["入库金额"] = list[i].InTotalPrice;
                dr["备注"] = list[i].Remark;
                dt.Rows.Add(dr);
                footerInTotalCount += list[i].InTotalCount;
                footerInTotalPrice += list[i].InTotalPrice;
                if (i == list.Length - 1)
                {
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
                    if (model4.IsUse)
                    {
                        rangeList.Add(model4);
                    }
                    if (model5.IsUse)
                    {
                        rangeList.Add(model5);
                    }
                    if (model6.IsUse)
                    {
                        rangeList.Add(model6);
                    }
                }
                if (i < list.Length - 1)
                {
                    if (list[i].InSummaryID == list[i + 1].InSummaryID)
                    {
                        if (dt.Columns["入库单号"] != null)
                        {
                            model1.IsUse = true;
                            model1.LastRow = (i + 2);
                            model1.FirstCol = dt.Columns["入库单号"].Ordinal;
                            model1.LastCol = dt.Columns["入库单号"].Ordinal;
                        }
                        if (dt.Columns["单据状态"] != null)
                        {
                            model2.IsUse = true;
                            model2.LastRow = (i + 2);
                            model2.FirstCol = dt.Columns["单据状态"].Ordinal;
                            model2.LastCol = dt.Columns["单据状态"].Ordinal;
                        }
                        if (dt.Columns["供应商简称"] != null)
                        {
                            model3.IsUse = true;
                            model3.LastRow = (i + 2);
                            model3.FirstCol = dt.Columns["供应商简称"].Ordinal;
                            model3.LastCol = dt.Columns["供应商简称"].Ordinal;
                        }
                        if (dt.Columns["入库类别"] != null)
                        {
                            model4.IsUse = true;
                            model4.LastRow = (i + 2);
                            model4.FirstCol = dt.Columns["入库类别"].Ordinal;
                            model4.LastCol = dt.Columns["入库类别"].Ordinal;
                        }
                        if (dt.Columns["仓管员"] != null)
                        {
                            model5.IsUse = true;
                            model5.LastRow = (i + 2);
                            model5.FirstCol = dt.Columns["仓管员"].Ordinal;
                            model5.LastCol = dt.Columns["仓管员"].Ordinal;
                        }
                        if (dt.Columns["入库时间"] != null)
                        {
                            model6.IsUse = true;
                            model6.LastRow = (i + 2);
                            model6.FirstCol = dt.Columns["入库时间"].Ordinal;
                            model6.LastCol = dt.Columns["入库时间"].Ordinal;
                        }
                    }
                    else
                    {
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
                        if (model4.IsUse)
                        {
                            rangeList.Add(model4);
                        }
                        if (model5.IsUse)
                        {
                            rangeList.Add(model5);
                        }
                        if (model6.IsUse)
                        {
                            rangeList.Add(model6);
                        }
                        model1 = new CellRangeAddressModel();
                        model1.FirstRow = (i + 2);
                        model2 = new CellRangeAddressModel();
                        model2.FirstRow = (i + 2);
                        model3 = new CellRangeAddressModel();
                        model3.FirstRow = (i + 2);
                        model4 = new CellRangeAddressModel();
                        model4.FirstRow = (i + 2);
                        model5 = new CellRangeAddressModel();
                        model5.FirstRow = (i + 2);
                        model6 = new CellRangeAddressModel();
                        model6.FirstRow = (i + 2);
                    }
                }
                DataRow footerdr = dt.NewRow();
                footerdr["入库单号"] = "总合计";
                footerdr["入库数量"] = footerInTotalCount;
                footerdr["入库金额"] = footerInTotalPrice;
                dt.Rows.Add(footerdr);
            }
            string FileName = "入库单_" + DateTime.Now.ToString("yyyyMMddHHmmss") + "_导入模板.xls";
            string filepath = "/upload/ExcelExport/ExportFee/";
            downloadurl = DownloadProcess(dt, FileName, filepath, rangeList: rangeList);
            return true;
        }
        public static bool DownLoadPreChargeAnalysisData(Foresight.DataAccess.Ui.DataGrid dg, out string downloadurl, out string error)
        {
            downloadurl = string.Empty;
            error = string.Empty;
            ViewRoomFeeHistory[] list = new ViewRoomFeeHistory[] { };
            ViewRoomFeeHistory[] FooterRows = new ViewRoomFeeHistory[] { };
            if (dg != null)
            {
                list = dg.rows as ViewRoomFeeHistory[];
                if (dg.footer != null)
                {
                    FooterRows = dg.footer as ViewRoomFeeHistory[];
                }
            }
            if (list.Length == 0)
            {
                error = "没有可导出的数据";
                return false;
            }
            List<CellRangeAddressModel> rangeList = new List<CellRangeAddressModel>();
            DataTable dt = new DataTable();
            dt.Columns.Add("资源位置");
            dt.Columns.Add("资源编号");
            dt.Columns.Add("收款单号");
            dt.Columns.Add("收费状态");
            dt.Columns.Add("收款人");
            dt.Columns.Add("收款日期");
            dt.Columns.Add("收费项目");
            dt.Columns.Add("费项分类");
            dt.Columns.Add("计费开始日期");
            dt.Columns.Add("计费结束日期");
            dt.Columns.Add("单价");
            dt.Columns.Add("面积/用量");
            dt.Columns.Add("实收合计");
            dt.Columns.Add("实收金额");
            dt.Columns.Add("备注");
            CellRangeAddressModel model1 = new CellRangeAddressModel();
            CellRangeAddressModel model2 = new CellRangeAddressModel();
            CellRangeAddressModel model3 = new CellRangeAddressModel();
            CellRangeAddressModel model4 = new CellRangeAddressModel();
            CellRangeAddressModel model5 = new CellRangeAddressModel();
            for (int i = 0; i < list.Length; i++)
            {
                if (i == 0)
                {
                    model1 = new CellRangeAddressModel();
                    model1.FirstRow = (i + 1);
                    model2 = new CellRangeAddressModel();
                    model2.FirstRow = (i + 1);
                    model3 = new CellRangeAddressModel();
                    model3.FirstRow = (i + 1);
                    model4 = new CellRangeAddressModel();
                    model4.FirstRow = (i + 1);
                    model5 = new CellRangeAddressModel();
                    model5.FirstRow = (i + 1);
                }
                DataRow dr = dt.NewRow();
                dr["资源位置"] = list[i].FullName;
                dr["资源编号"] = list[i].RoomName;
                dr["收款单号"] = list[i].PrintNumber;
                dr["收费状态"] = list[i].ChargeStateDesc;
                dr["收款人"] = list[i].ChargeMan;
                dr["收款日期"] = WebUtil.GetStrDate(list[i].ChargeTime, "yyyy-MM-dd HH:mm:ss");
                dr["收费项目"] = list[i].ChargeName;
                dr["费项分类"] = list[i].ChargeTypeName;
                dr["计费开始日期"] = WebUtil.GetStrDate(list[i].StartTime);
                dr["计费结束日期"] = WebUtil.GetStrDate(list[i].EndTime);
                dr["单价"] = list[i].UnitPrice > 0 ? list[i].UnitPrice : 0;
                dr["面积/用量"] = list[i].UseCount > 0 ? list[i].UseCount : 0;
                decimal RealCost = 0;
                decimal PrintRealCost = 0;
                if (list[i].ChargeState == 3 || list[i].ChargeState == 6 || list[i].ChargeState == 7)
                {
                    RealCost = list[i].RealCost == decimal.MinValue ? 0 : -list[i].RealCost;
                    PrintRealCost = list[i].SumRealCost == decimal.MinValue ? 0 : -list[i].SumRealCost;
                }
                else
                {
                    RealCost = list[i].RealCost == decimal.MinValue ? 0 : list[i].RealCost;
                    PrintRealCost = list[i].SumRealCost == decimal.MinValue ? 0 : list[i].SumRealCost;
                }
                dr["实收合计"] = PrintRealCost;
                dr["实收金额"] = RealCost;
                dr["备注"] = list[i].Remark;
                dt.Rows.Add(dr);
                if (i == list.Length - 1)
                {

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
                    if (model4.IsUse)
                    {
                        rangeList.Add(model4);
                    }
                    if (model5.IsUse)
                    {
                        rangeList.Add(model5);
                    }
                }
                if (i < list.Length - 1)
                {
                    if (list[i].PrintNumber.Equals(list[i + 1].PrintNumber) && !string.IsNullOrEmpty(list[i].PrintNumber))
                    {

                        if (dt.Columns["收款单号"] != null)
                        {
                            model1.IsUse = true;
                            model1.LastRow = (i + 2);
                            model1.FirstCol = dt.Columns["收款单号"].Ordinal;
                            model1.LastCol = dt.Columns["收款单号"].Ordinal;
                        }
                        if (dt.Columns["收费状态"] != null)
                        {
                            model2.IsUse = true;
                            model2.LastRow = (i + 2);
                            model2.FirstCol = dt.Columns["收费状态"].Ordinal;
                            model2.LastCol = dt.Columns["收费状态"].Ordinal;
                        }
                        if (dt.Columns["收款人"] != null)
                        {
                            model3.IsUse = true;
                            model3.LastRow = (i + 2);
                            model3.FirstCol = dt.Columns["收款人"].Ordinal;
                            model3.LastCol = dt.Columns["收款人"].Ordinal;
                        }
                        if (dt.Columns["收款日期"] != null)
                        {
                            model4.IsUse = true;
                            model4.LastRow = (i + 2);
                            model4.FirstCol = dt.Columns["收款日期"].Ordinal;
                            model4.LastCol = dt.Columns["收款日期"].Ordinal;
                        }
                        if (dt.Columns["实收合计"] != null)
                        {
                            model5.IsUse = true;
                            model5.LastRow = (i + 2);
                            model5.FirstCol = dt.Columns["实收合计"].Ordinal;
                            model5.LastCol = dt.Columns["实收合计"].Ordinal;
                        }
                    }
                    else
                    {
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
                        if (model4.IsUse)
                        {
                            rangeList.Add(model4);
                        }
                        if (model5.IsUse)
                        {
                            rangeList.Add(model5);
                        }
                        model1 = new CellRangeAddressModel();
                        model1.FirstRow = (i + 2);
                        model2 = new CellRangeAddressModel();
                        model2.FirstRow = (i + 2);
                        model3 = new CellRangeAddressModel();
                        model3.FirstRow = (i + 2);
                        model4 = new CellRangeAddressModel();
                        model4.FirstRow = (i + 2);
                        model5 = new CellRangeAddressModel();
                        model5.FirstRow = (i + 2);
                    }
                }
            }
            if (FooterRows.Length > 0)
            {
                DataRow footer_dr = dt.NewRow();
                footer_dr["资源位置"] = "总合计";
                footer_dr["面积/用量"] = FooterRows[0].UseCount <= 0 ? 0 : FooterRows[0].UseCount;
                footer_dr["实收合计"] = FooterRows[0].SumRealCost <= 0 ? 0 : FooterRows[0].SumRealCost;
                footer_dr["实收金额"] = FooterRows[0].RealCost <= 0 ? 0 : FooterRows[0].RealCost;
                dt.Rows.Add(footer_dr);
            }
            string FileName = "预收台帐_" + DateTime.Now.ToString("yyyyMMddHHmmss") + "_导入模板.xls";
            string filepath = "/upload/ExcelExport/ExportFee/";
            downloadurl = DownloadProcess(dt, FileName, filepath, rangeList: rangeList);
            return true;
        }
        public static bool DownLoadLotteryUserTemplateData(out string downloadurl, out string error)
        {
            downloadurl = string.Empty;
            error = string.Empty;
            DataTable dt = new DataTable();
            dt.Columns.Add("客户名称");
            dt.Columns.Add("手机号码");
            DataRow dr = dt.NewRow();
            dr["客户名称"] = "张三";
            dt.Rows.Add(dr);
            string FileName = "参与人员导入模板_" + DateTime.Now.ToString("yyyyMMddHHmmss") + "_导入模板.xls";
            string filepath = "/upload/ExcelExport/ExportFee/";
            downloadurl = DownloadProcess(dt, FileName, filepath);
            return true;
        }
        public static bool DownLoadPayServiceData(Foresight.DataAccess.Ui.DataGrid dg, out string downloadurl, out string error)
        {
            downloadurl = string.Empty;
            error = string.Empty;
            var list = new ViewPayService[] { };
            var footers = new ViewPayService[] { };
            if (dg != null)
            {
                list = dg.rows as ViewPayService[];
                if (dg.footer != null)
                {
                    footers = dg.footer as ViewPayService[];
                }
            }
            if (list.Length == 0)
            {
                error = "没有可导出的数据";
                return false;
            }
            DataTable dt = new DataTable();
            dt.Columns.Add("资源位置");//0
            dt.Columns.Add("项目名称"); //1
            dt.Columns.Add("金额"); //2
            dt.Columns.Add("缴费类型"); //3
            dt.Columns.Add("记账操作"); //4
            dt.Columns.Add("支出日期"); //5
            dt.Columns.Add("操作人");//6
            dt.Columns.Add("所属房间"); //7
            dt.Columns.Add("修改时间"); //8
            dt.Columns.Add("修改人"); //9
            dt.Columns.Add("备注"); //10
            for (int i = 0; i < list.Length; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = list[i].ProjectName;
                dr[1] = list[i].PayName;
                dr[2] = list[i].PayMoney;
                dr[3] = list[i].PayType;
                dr[4] = list[i].AccountType;
                dr[5] = list[i].PayTime == DateTime.MinValue ? "" : list[i].PayTime.ToString("yyyy-MM-dd");
                dr[6] = list[i].AddMan;
                dr[7] = list[i].RoomName;
                dr[8] = list[i].ModifyTime == DateTime.MinValue ? "" : list[i].ModifyTime.ToString("yyyy-MM-dd");
                dr[9] = list[i].ModifyMan;
                dr[10] = list[i].Remark;
                dt.Rows.Add(dr);
            }
            string FileName = "支出_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";
            string filepath = "/upload/ExcelExport/ExportFee/";
            downloadurl = DownloadProcess(dt, FileName, filepath);
            return true;
        }
        public static bool DownLoadPayServiceAnalysisData(Foresight.DataAccess.Ui.DataGrid dg, out string downloadurl, out string error)
        {
            downloadurl = string.Empty;
            error = string.Empty;
            var list = new List<Dictionary<string, object>>();
            var footers = new List<Dictionary<string, object>>();
            if (dg != null)
            {
                list = dg.rows as List<Dictionary<string, object>>;
                if (dg.footer != null)
                {
                    footers = dg.footer as List<Dictionary<string, object>>;
                }
            }
            if (list.Count == 0)
            {
                error = "没有可导出的数据";
                return false;
            }
            DataTable dt = new DataTable();
            dt.Columns.Add("资源位置"); //1
            dt.Columns.Add("房间信息");
            var summary_list = Foresight.DataAccess.PaySummary.GetPaySummaries().ToArray();
            foreach (var item in summary_list)
            {
                if (!dt.Columns.Contains(item.PayName))
                {
                    dt.Columns.Add(item.PayName);
                }
            }
            dt.Columns.Add("合计");
            for (int i = 0; i < list.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr["资源位置"] = list[i]["FullName"];
                dr["房间信息"] = list[i]["RoomName"];
                foreach (var item in summary_list)
                {
                    if (list[i].ContainsKey(item.ID + "_RealCost"))
                    {
                        dr[item.PayName] = list[i][item.ID + "_RealCost"];
                    }
                }
                dr["合计"] = list[i]["heji_RealCost"];
                dt.Rows.Add(dr);
            }
            if (footers.Count > 0)
            {
                DataRow footer_dr = dt.NewRow();
                footer_dr["资源位置"] = "合计";
                footer_dr["合计"] = footers[0]["heji_RealCost"];
                foreach (var item in summary_list)
                {
                    if (footers[0].ContainsKey(item.ID + "_RealCost"))
                    {
                        footer_dr[item.PayName] = footers[0][item.ID + "_RealCost"];
                    }
                }
                dt.Rows.Add(footer_dr);
            }
            string FileName = "支出报表_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";
            string filepath = "/upload/ExcelExport/ExportFee/";
            downloadurl = DownloadProcess(dt, FileName, filepath);
            return true;
        }
        public static bool DownLoadInsideCustomerData(Foresight.DataAccess.Ui.DataGrid dg, out string downloadurl, out string error)
        {
            downloadurl = string.Empty;
            error = string.Empty;
            var list = new Foresight.DataAccess.InsideCustomer[] { };
            var footers = new Foresight.DataAccess.InsideCustomer[] { };
            if (dg != null)
            {
                list = dg.rows as Foresight.DataAccess.InsideCustomer[];
                if (dg.footer != null)
                {
                    footers = dg.footer as Foresight.DataAccess.InsideCustomer[];
                }
            }
            if (list.Length == 0)
            {
                error = "没有可导出的数据";
                return false;
            }
            var titleList = GetTableColumns("insidecustomersource");
            DataTable dt = new DataTable();
            foreach (var item in titleList)
            {
                if (!dt.Columns.Contains(item["ColumnName"].ToString()))
                {
                    dt.Columns.Add(item["ColumnName"].ToString());
                }
            }
            for (int i = 0; i < list.Length; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = list[i].ID;
                SetDrValue(titleList, dr, "客户名称", list[i].CustomerName);
                SetDrValue(titleList, dr, "行业", list[i].IndustryName);
                SetDrValue(titleList, dr, "分类", list[i].CategoryName);
                SetDrValue(titleList, dr, "意向分析", list[i].Interesting);
                SetDrValue(titleList, dr, "联系人", list[i].ContactMan);
                SetDrValue(titleList, dr, "联系方式", list[i].ContactPhone);
                SetDrValue(titleList, dr, "QQ", list[i].QQNo);
                SetDrValue(titleList, dr, "QQ群邀约", list[i].QQGroupInvitation);
                SetDrValue(titleList, dr, "微信", list[i].WechatNo);
                SetDrValue(titleList, dr, "微信群邀约", list[i].WechaGroupInvitation);
                SetDrValue(titleList, dr, "其他联系人", list[i].OtherContactMan);
                SetDrValue(titleList, dr, "客户所有者", list[i].CustomerBelonger);
                string NewFollowupDate = list[i].NewFollowupDate > DateTime.MinValue ? list[i].NewFollowupDate.ToString("yyyy-MM-dd") : "";
                SetDrValue(titleList, dr, "跟进日期", NewFollowupDate);
                SetDrValue(titleList, dr, "跟进记录", list[i].NewFollowup);
                SetDrValue(titleList, dr, "区域", list[i].Region);
                SetDrValue(titleList, dr, "省区", list[i].Province);
                SetDrValue(titleList, dr, "城市", list[i].City);
                SetDrValue(titleList, dr, "商务阶段", list[i].BusinessStage);
                decimal Cost = list[i].Cost > 0 ? list[i].Cost : 0;
                SetDrValue(titleList, dr, "报价", Cost);
                SetDrValue(titleList, dr, "成交可能性", list[i].DealProbably);
                SetDrValue(titleList, dr, "备注", list[i].Remark);
                dt.Rows.Add(dr);
            }
            string FileName = "客户资料_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";
            string filepath = "/upload/ExcelExport/ExportFee/";
            downloadurl = DownloadProcess(dt, FileName, filepath);
            return true;
        }
        public static bool DownLoadTaiZhangData(Foresight.DataAccess.Ui.DataGrid dg, out string downloadurl, out string error)
        {
            downloadurl = string.Empty;
            error = string.Empty;
            var list = new ViewTaiZhang[] { };
            var footers = new ViewTaiZhang[] { };
            if (dg != null)
            {
                list = dg.rows as ViewTaiZhang[];
                if (dg.footer != null)
                {
                    footers = dg.footer as ViewTaiZhang[];
                }
            }
            if (list.Length == 0)
            {
                error = "没有可导出的数据";
                return false;
            }
            DataTable dt = new DataTable();
            dt.Columns.Add("表台帐ID");//0
            dt.Columns.Add("项目/房间名称"); //1
            dt.Columns.Add("表名称"); //2
            dt.Columns.Add("表种类"); //3
            dt.Columns.Add("表规格"); //4
            dt.Columns.Add("缴费户号"); //4
            dt.Columns.Add("抄表日期"); //5
            dt.Columns.Add("倍率"); //5
            dt.Columns.Add("上次读数"); //5
            dt.Columns.Add("本次读数"); //5
            dt.Columns.Add("本次用量");//6
            dt.Columns.Add("扣减用量");//6
            dt.Columns.Add("系数"); //7
            dt.Columns.Add("单价"); //7
            dt.Columns.Add("备注"); //9
            dt.Columns.Add("作废状态"); //9
            for (int i = 0; i < list.Length; i++)
            {
                DataRow dr = dt.NewRow();
                dr["表台帐ID"] = list[i].ID;
                dr["项目/房间名称"] = list[i].FullName + "-" + list[i].Name;
                dr["表名称"] = list[i].FinalBiaoName;
                dr["表种类"] = list[i].FinalBiaoCategory;
                dr["缴费户号"] = list[i].ChargeRoomNo;
                dr["表规格"] = list[i].BiaoGuiGe;
                dr["倍率"] = list[i].Rate > 0 ? list[i].Rate : 0;
                dr["抄表日期"] = WebUtil.GetStrDate(list[i].ImportWriteDate);
                dr["上次读数"] = list[i].FinalStartPoint <= 0 ? 0 : list[i].FinalStartPoint;
                dr["本次读数"] = list[i].FinalEndPoint <= 0 ? 0 : list[i].FinalEndPoint;
                dr["本次用量"] = list[i].FinalTotalPoint > 0 ? list[i].FinalTotalPoint : 0;
                dr["扣减用量"] = list[i].FinalReducePoint > 0 ? list[i].FinalReducePoint : 0;
                dr["系数"] = list[i].FinalCoefficient > 0 ? list[i].FinalCoefficient : 0;
                dr["单价"] = list[i].FinalUnitPrice > 0 ? list[i].FinalUnitPrice : 0;
                dr["备注"] = list[i].Remark;
                dr["作废状态"] = list[i].IsActiveDesc;
                dt.Rows.Add(dr);
            }
            string FileName = "表台帐_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";
            string filepath = "/upload/ExcelExport/ExportFee/";
            downloadurl = DownloadProcess(dt, FileName, filepath);
            return true;
        }
        public static bool DownLoadGongTanData(Foresight.DataAccess.Ui.DataGrid dg, out string downloadurl, out string error)
        {
            downloadurl = string.Empty;
            error = string.Empty;
            var list = new ViewImportFeeDetail2[] { };
            var footers = new ViewImportFeeDetail2[] { };
            if (dg != null)
            {
                list = dg.rows as ViewImportFeeDetail2[];
                if (dg.footer != null)
                {
                    footers = dg.footer as ViewImportFeeDetail2[];
                }
            }
            if (list.Length == 0)
            {
                error = "没有可导出的数据";
                return false;
            }
            var titleList = GetTableColumns("roomfeesource");
            DataTable dt = new DataTable();
            dt.Columns.Add("账单ID");//0
            foreach (var item in titleList)
            {
                if (!dt.Columns.Contains(item["ColumnName"].ToString()))
                {
                    dt.Columns.Add(item["ColumnName"].ToString());
                }
            }
            for (int i = 0; i < list.Length; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = list[i].ID;
                SetDrValue(titleList, dr, "房源信息", list[i].FullName);
                SetDrValue(titleList, dr, "房间号", list[i].Name);
                SetDrValue(titleList, dr, "收费项目", list[i].ChargeName);
                decimal StartPoint = list[i].StartPoint;
                if (StartPoint == decimal.MinValue)
                {
                    StartPoint = list[i].LastEndPoint == decimal.MinValue ? 0 : list[i].LastEndPoint;
                }
                SetDrValue(titleList, dr, "上次读数", StartPoint);
                SetDrValue(titleList, dr, "本次读数", (list[i].EndPoint == decimal.MinValue ? 0 : list[i].EndPoint));
                SetDrValue(titleList, dr, "用量", (list[i].TotalPoint == decimal.MinValue ? 0 : list[i].TotalPoint));
                decimal UnitPrice = 0;
                if (list[i].UnitPrice > 0)
                {
                    UnitPrice = list[i].UnitPrice;
                }
                else if (list[i].SummaryUnitPrice > 0)
                {
                    UnitPrice = list[i].SummaryUnitPrice;
                }
                SetDrValue(titleList, dr, "单价", UnitPrice);
                decimal Coefficient = 0;
                if (list[i].ImportCoefficient > 0)
                {
                    Coefficient = list[i].ImportCoefficient;
                }
                else if (list[i].Coefficient > 0)
                {
                    Coefficient = list[i].Coefficient;
                }
                SetDrValue(titleList, dr, "系数", Coefficient);
                SetDrValue(titleList, dr, "金额", (list[i].TotalPrice == decimal.MinValue ? 0 : list[i].TotalPrice));
                SetDrValue(titleList, dr, "收费状态", list[i].StatusDesc);
                SetDrValue(titleList, dr, "账单日期", (list[i].WriteDate == DateTime.MinValue ? "" : list[i].WriteDate.ToString("yyyy-MM-dd")));

                DateTime StartTime = DateTime.MinValue;
                if (list[i].StartTime > DateTime.MinValue)
                {
                    StartTime = list[i].StartTime;
                }
                else if (list[i].LastEndTime > DateTime.MinValue)
                {
                    StartTime = list[i].LastEndTime.AddDays(1);
                }
                SetDrValue(titleList, dr, "计费开始日期", (StartTime == DateTime.MinValue ? "" : StartTime.ToString("yyyy-MM-dd")));
                SetDrValue(titleList, dr, "计费结束日期", (list[i].EndTime == DateTime.MinValue ? "" : list[i].EndTime.ToString("yyyy-MM-dd")));
                SetDrValue(titleList, dr, "表种类", list[i].ImportBiaoCategory);
                SetDrValue(titleList, dr, "表名称", list[i].ImportBiaoName);
                SetDrValue(titleList, dr, "缴费户号", list[i].ImportChargeRoomNo);
                SetDrValue(titleList, dr, "收款人", list[i].ChargeMan);
                SetDrValue(titleList, dr, "收款日期", (list[i].ChargeTime == DateTime.MinValue ? "" : list[i].ChargeTime.ToString("yyyy-MM-dd HH:mm:ss")));
                SetDrValue(titleList, dr, "备注", list[i].Remark);
                SetDrValue(titleList, dr, "收款单号", list[i].PrintNumber);
                SetDrValue(titleList, dr, "默认联系人", list[i].RelationName);
                SetDrValue(titleList, dr, "倍率", list[i].ImportRate > 0 ? list[i].ImportRate : 0);
                SetDrValue(titleList, dr, "扣减量", list[i].FinalReducePoint);
                SetDrValue(titleList, dr, "添加时间", (list[i].AddTime == DateTime.MinValue ? "" : list[i].AddTime.ToString("yyyy-MM-dd HH:mm:ss")));
                dt.Rows.Add(dr);
            }
            string FileName = "账单处理_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";
            string filepath = "/upload/ExcelExport/ExportFee/";
            downloadurl = DownloadProcess(dt, FileName, filepath);
            return true;
        }
        public static bool DownLoadDeviceData(Foresight.DataAccess.Ui.DataGrid dg, out string downloadurl, out string error)
        {
            downloadurl = string.Empty;
            error = string.Empty;
            var list = new ViewDevice[] { };
            var footers = new ViewDevice[] { };
            if (dg != null)
            {
                list = dg.rows as ViewDevice[];
                if (dg.footer != null)
                {
                    footers = dg.footer as ViewDevice[];
                }
            }
            if (list.Length == 0)
            {
                error = "没有可导出的数据";
                return false;
            }
            var titleList = GetTableColumns("devicemgr");
            DataTable dt = new DataTable();
            foreach (var item in titleList)
            {
                if (!dt.Columns.Contains(item["ColumnName"].ToString()))
                {
                    dt.Columns.Add(item["ColumnName"].ToString());
                }
            }
            for (int i = 0; i < list.Length; i++)
            {
                DataRow dr = dt.NewRow();
                SetDrValue(titleList, dr, "设备编码", list[i].DeviceNo);
                SetDrValue(titleList, dr, "设备类型", list[i].DeviceTypeName);
                SetDrValue(titleList, dr, "设备分组", list[i].DeviceGroupName);
                SetDrValue(titleList, dr, "设备名称", list[i].DeviceName);
                SetDrValue(titleList, dr, "规格型号", list[i].ModelNo);
                SetDrValue(titleList, dr, "所属项目", list[i].ProjectName);
                SetDrValue(titleList, dr, "存放位置", list[i].LocationPlace);
                SetDrValue(titleList, dr, "设备状态", list[i].StatusDesc);
                SetDrValue(titleList, dr, "设备等级", list[i].DeviceLevel);
                SetDrValue(titleList, dr, "维保类型", list[i].TaskTypeName);
                SetDrValue(titleList, dr, "供应商单位", list[i].Supplier);
                SetDrValue(titleList, dr, "供应商联系人", list[i].SupplierMan);
                SetDrValue(titleList, dr, "供应商联系方式", list[i].SupplierPhone);
                SetDrValue(titleList, dr, "购入日期", WebUtil.GetStrDate(list[i].PurchaseDate));
                SetDrValue(titleList, dr, "质保期", list[i].GuaranteeDate);
                SetDrValue(titleList, dr, "质保到期日期", WebUtil.GetStrDate(list[i].GuaranteeEndDate));
                SetDrValue(titleList, dr, "维保单位", list[i].RepairCompany);
                SetDrValue(titleList, dr, "维保责任人", list[i].RepairRealName);
                SetDrValue(titleList, dr, "维保联系方式", list[i].RepairUserPhone);
                SetDrValue(titleList, dr, "首次维保日期", WebUtil.GetStrDate(list[i].FirstRepairDate));
                SetDrValue(titleList, dr, "维保周期", list[i].RepairCycleDesc);
                SetDrValue(titleList, dr, "上次维保日期", WebUtil.GetStrDate(list[i].LastRepairDate));
                SetDrValue(titleList, dr, "本次维保日期", WebUtil.GetStrDate(list[i].ThisRepairDate));
                SetDrValue(titleList, dr, "巡检责任人", list[i].CheckRealName);
                SetDrValue(titleList, dr, "首次巡检日期", WebUtil.GetStrDate(list[i].FirstCheckDate));
                SetDrValue(titleList, dr, "巡检周期", list[i].CheckCycleDesc);
                SetDrValue(titleList, dr, "上次巡检日期", WebUtil.GetStrDate(list[i].LastCheckDate));
                SetDrValue(titleList, dr, "本次巡检日期", WebUtil.GetStrDate(list[i].ThisCheckDate));
                dt.Rows.Add(dr);
            }
            string FileName = "设备台帐_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";
            string filepath = "/upload/ExcelExport/ExportFee/";
            downloadurl = DownloadProcess(dt, FileName, filepath);
            return true;
        }
        public static bool DownLoadCustomerServiceData(Foresight.DataAccess.Ui.DataGrid dg, out string downloadurl, out string error)
        {
            downloadurl = string.Empty;
            error = string.Empty;
            var list = new ViewCustomerService[] { };
            var footers = new ViewCustomerService[] { };
            if (dg != null)
            {
                list = dg.rows as ViewCustomerService[];
                if (dg.footer != null)
                {
                    footers = dg.footer as ViewCustomerService[];
                }
            }
            if (list.Length == 0)
            {
                error = "没有可导出的数据";
                return false;
            }
            var titleList = GetTableColumns("customerservice");
            DataTable dt = new DataTable();
            foreach (var item in titleList)
            {
                if (!dt.Columns.Contains(item["ColumnName"].ToString()))
                {
                    dt.Columns.Add(item["ColumnName"].ToString());
                }
            }
            for (int i = 0; i < list.Length; i++)
            {
                DataRow dr = dt.NewRow();
                SetDrValue(titleList, dr, "任务来源", list[i].ServiceFromDesc);
                SetDrValue(titleList, dr, "资源位置", list[i].ServiceFullName);
                SetDrValue(titleList, dr, "反应内容", list[i].ServiceContent);
                SetDrValue(titleList, dr, "项目名称", list[i].ProjectName);
                SetDrValue(titleList, dr, "服务类别", list[i].ServiceTypeName);
                SetDrValue(titleList, dr, "登记人", list[i].AddUserName);
                SetDrValue(titleList, dr, "登记时间", list[i].StartTime > DateTime.MinValue ? list[i].StartTime.ToString("yyyy-MM-dd HH:mm") : "");
                SetDrValue(titleList, dr, "服务区域", list[i].ServiceArea);
                SetDrValue(titleList, dr, "客服单号", list[i].ServiceNumber);
                SetDrValue(titleList, dr, "反映人", list[i].AddCustomerName);
                SetDrValue(titleList, dr, "联系电话", list[i].AddCallPhone);
                SetDrValue(titleList, dr, "接单人", list[i].FinalServiceAccpetMan);
                SetDrValue(titleList, dr, "预约时间", list[i].ServiceAppointTime > DateTime.MinValue ? list[i].ServiceAppointTime.ToString("yyyy-MM-dd") : "");
                SetDrValue(titleList, dr, "处理时间", list[i].ChuliDate > DateTime.MinValue ? list[i].ChuliDate.ToString("yyyy-MM-dd") : "");
                SetDrValue(titleList, dr, "回访时间", list[i].HuiFangTime > DateTime.MinValue ? list[i].HuiFangTime.ToString("yyyy-MM-dd") : "");
                SetDrValue(titleList, dr, "办结时间", list[i].BanJieTime > DateTime.MinValue ? list[i].BanJieTime.ToString("yyyy-MM-dd") : "");
                SetDrValue(titleList, dr, "任务状态", list[i].ServiceStatusDesc);
                SetDrValue(titleList, dr, "处理情况", list[i].ChuliNote);
                SetDrValue(titleList, dr, "回访情况", list[i].HuiFangNote);
                SetDrValue(titleList, dr, "返修情况", "");
                SetDrValue(titleList, dr, "返修时间", "");
                SetDrValue(titleList, dr, "维修工费", list[i].HandelFee);
                SetDrValue(titleList, dr, "收费金额", list[i].TotalFee > 0 ? list[i].TotalFee : 0);
                dt.Rows.Add(dr);
            }
            if (footers.Length > 0)
            {
                DataRow footerdr = dt.NewRow();
                SetDrValue(titleList, footerdr, "资源位置", "合计");
                SetDrValue(titleList, footerdr, "维修工费", footers[0].HandelFee);
                SetDrValue(titleList, footerdr, "收费金额", footers[0].TotalFee);
                dt.Rows.Add(footerdr);
            }
            string FileName = "客服总台_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";
            string filepath = "/upload/ExcelExport/ExportFee/";
            downloadurl = DownloadProcess(dt, FileName, filepath);
            return true;
        }
        public static bool DownLoadContractEarnData(Foresight.DataAccess.Ui.DataGrid dg, out string downloadurl, out string error)
        {
            downloadurl = string.Empty;
            error = string.Empty;
            var list = new ViewContractDivide[] { };
            var footers = new ViewContractDivide[] { };
            if (dg != null)
            {
                list = dg.rows as ViewContractDivide[];
                if (dg.footer != null)
                {
                    footers = dg.footer as ViewContractDivide[];
                }
            }
            if (list.Length == 0)
            {
                error = "没有可导出的数据";
                return false;
            }
            var titleList = GetTableColumns("contractdividemgr");
            DataTable dt = new DataTable();
            dt.Columns.Add("账单ID");
            foreach (var item in titleList)
            {
                if (!dt.Columns.Contains(item["ColumnName"].ToString()))
                {
                    dt.Columns.Add(item["ColumnName"].ToString());
                }
            }
            for (int i = 0; i < list.Length; i++)
            {
                DataRow dr = dt.NewRow();
                dr["账单ID"] = list[i].ID;
                SetDrValue(titleList, dr, "合同号", list[i].ContractNo);
                SetDrValue(titleList, dr, "合同名称", list[i].ContractName);
                SetDrValue(titleList, dr, "租户名称", list[i].RentName);
                SetDrValue(titleList, dr, "签订日期", WebUtil.GetStrDate(list[i].SignTime));
                SetDrValue(titleList, dr, "合同开始日期", WebUtil.GetStrDate(list[i].RentStartTime));
                SetDrValue(titleList, dr, "合同结束日期", WebUtil.GetStrDate(list[i].RentEndTime));
                SetDrValue(titleList, dr, "账单状态", list[i].ChargeStatusDesc);
                SetDrValue(titleList, dr, "分成方式", list[i].DivideTypeDesc);
                SetDrValue(titleList, dr, "账单日期", WebUtil.GetStrDate(list[i].WriteDate));
                SetDrValue(titleList, dr, "账单开始日期", list[i].StartTime);
                SetDrValue(titleList, dr, "账单结束日期", list[i].EndTime);
                SetDrValue(titleList, dr, "销售额", list[i].SellCost > 0 ? list[i].SellCost : 0);
                SetDrValue(titleList, dr, "应收金额", list[i].TotalCost > 0 ? list[i].TotalCost : 0);
                SetDrValue(titleList, dr, "减免金额", list[i].DiscountCost > 0 ? list[i].DiscountCost : 0);
                SetDrValue(titleList, dr, "已收金额", list[i].RealCost > 0 ? list[i].RealCost : 0);
                SetDrValue(titleList, dr, "欠费金额", list[i].RestCost > 0 ? list[i].RestCost : 0);
                SetDrValue(titleList, dr, "备注", list[i].Remark);
                dt.Rows.Add(dr);
            }
            string FileName = "商业分成_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";
            string filepath = "/upload/ExcelExport/ExportFee/";
            downloadurl = DownloadProcess(dt, FileName, filepath);
            return true;
        }
        public static bool DownLoadContractSummaryData(Foresight.DataAccess.Ui.DataGrid dg, out string downloadurl, out string error)
        {
            downloadurl = string.Empty;
            error = string.Empty;
            var list = new ContractDetail[] { };
            var footers = new ContractDetail[] { };
            if (dg != null)
            {
                list = dg.rows as ContractDetail[];
                if (dg.footer != null)
                {
                    footers = dg.footer as ContractDetail[];
                }
            }
            if (list.Length == 0)
            {
                error = "没有可导出的数据";
                return false;
            }
            DataTable dt = new DataTable();
            dt.Columns.Add("合同编号");
            dt.Columns.Add("合同名称");
            dt.Columns.Add("租户姓名");
            dt.Columns.Add("合同期限");
            dt.Columns.Add("合同开始日期");
            dt.Columns.Add("合同结束日期");
            dt.Columns.Add("合同状态");
            dt.Columns.Add("租赁价格");
            dt.Columns.Add("合同面积");
            dt.Columns.Add("合同金额");
            dt.Columns.Add("合同应收");
            dt.Columns.Add("合同已收");
            //dt.Columns.Add("预收金额");
            dt.Columns.Add("押金金额");
            //dt.Columns.Add("违约金额");
            dt.Columns.Add("剩余天数");
            for (int i = 0; i < list.Length; i++)
            {
                DataRow dr = dt.NewRow();
                dr["合同编号"] = list[i].ContractNo;
                dr["合同名称"] = list[i].ContractName;
                dr["租户姓名"] = list[i].RentName;
                dr["合同期限"] = list[i].TimeLimit > 0 ? list[i].TimeLimit.ToString() : "";
                dr["合同开始日期"] = list[i].RentStartTime > DateTime.MinValue ? list[i].RentStartTime.ToString("yyyy-MM-dd") : "";
                dr["合同结束日期"] = list[i].RentEndTime > DateTime.MinValue ? list[i].RentEndTime.ToString("yyyy-MM-dd") : "";
                dr["合同状态"] = list[i].ContractStatusDesc;
                dr["租赁价格"] = list[i].RentPrice > 0 ? list[i].RentPrice.ToString() : "";
                dr["合同面积"] = list[i].RoomArea > 0 ? list[i].FinalTotalContractArea.ToString() : "";
                dr["合同金额"] = list[i].ContractDeposit > 0 ? list[i].ContractDeposit.ToString() : "";
                dr["合同应收"] = list[i].TotalCost > 0 ? list[i].TotalCost.ToString() : "";
                dr["合同已收"] = list[i].ChargedCost > 0 ? list[i].ChargedCost.ToString() : "";
                //dr["预收金额"] = list[i].PreCost > 0 ? list[i].PreCost.ToString() : "";
                dr["押金金额"] = list[i].DepositCost > 0 ? list[i].DepositCost.ToString() : "";
                //dr["违约金额"] = list[i].BreakCost > 0 ? list[i].BreakCost.ToString() : "";
                dr["剩余天数"] = list[i].RestDays;
                dt.Rows.Add(dr);
            }
            if (footers.Length > 0)
            {
                DataRow totaldr = dt.NewRow();
                totaldr[0] = "总合计";
                totaldr["合同编号"] = "合计";
                totaldr["合同应收"] = footers[0].TotalCost;
                totaldr["合同已收"] = footers[0].ChargedCost;
                //totaldr["预收金额"] = footerlist[0].PreCost;
                totaldr["押金金额"] = footers[0].DepositCost;
                //totaldr["违约金额"] = footerlist[0].BreakCost;
                dt.Rows.Add(totaldr);
            }
            string FileName = "合同台帐_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";
            string filepath = "/upload/ExcelExport/ExportFee/";
            downloadurl = DownloadProcess(dt, FileName, filepath);
            return true;
        }
        public static bool DownLoadCKPropertyData(Foresight.DataAccess.Ui.DataGrid dg, out string downloadurl, out string error)
        {
            downloadurl = string.Empty;
            error = string.Empty;
            var list = new CKPropertyDetails[] { };
            if (dg != null)
            {
                list = dg.rows as CKPropertyDetails[];
            }
            if (list.Length == 0)
            {
                error = "没有可导出的数据";
                return false;
            }
            var titleList = GetTableColumns("propertymgr");
            DataTable dt = new DataTable();
            foreach (var item in titleList)
            {
                if (!dt.Columns.Contains(item["ColumnName"].ToString()))
                {
                    dt.Columns.Add(item["ColumnName"].ToString());
                }
            }
            for (int i = 0; i < list.Length; i++)
            {
                DataRow dr = dt.NewRow();
                SetDrValue(titleList, dr, "资产编号", list[i].PropertyNo);
                SetDrValue(titleList, dr, "资产名称", list[i].PropertyName);
                SetDrValue(titleList, dr, "资产类别", list[i].PropertyCategoryName);
                SetDrValue(titleList, dr, "规格型号", list[i].PropertyModelNo);
                SetDrValue(titleList, dr, "单位", list[i].PropertyUnit);
                SetDrValue(titleList, dr, "数量", list[i].PropertyCount > 0 ? list[i].PropertyCount : 0);
                SetDrValue(titleList, dr, "单价", list[i].PropertyUnitPrice > 0 ? list[i].PropertyUnitPrice : 0);
                SetDrValue(titleList, dr, "购入金额", list[i].PropertyCost > 0 ? list[i].PropertyCost : 0);
                SetDrValue(titleList, dr, "购入时间", WebUtil.GetStrDate(list[i].PropertyPurchaseDate));
                SetDrValue(titleList, dr, "预计使用年限", list[i].PropertyUseYear > 0 ? list[i].PropertyUseYear : 0);
                SetDrValue(titleList, dr, "净值", list[i].PropertyRealCost > 0 ? list[i].PropertyRealCost : 0);
                SetDrValue(titleList, dr, "折旧金额", list[i].PropertyDiscountCost > 0 ? list[i].PropertyDiscountCost : 0);
                SetDrValue(titleList, dr, "变动方式", list[i].PropertyChangeType);
                SetDrValue(titleList, dr, "状态", list[i].PropertyStateDesc);
                SetDrValue(titleList, dr, "使用部门", list[i].PropertyDepartmentName);
                SetDrValue(titleList, dr, "存放地点", list[i].PropertyLocation);
                SetDrValue(titleList, dr, "使用人员", list[i].PropertyUseMan);
                SetDrValue(titleList, dr, "供应商", list[i].PropertyContractName);
                SetDrValue(titleList, dr, "联系方式", list[i].PropertyContactPhone);
                SetDrValue(titleList, dr, "备注", list[i].PropertyRemark);
                SetDrValue(titleList, dr, "操作人", list[i].UpdateMan);
                SetDrValue(titleList, dr, "操作时间", WebUtil.GetStrDate(list[i].UpdateTime));
                dt.Rows.Add(dr);
            }
            string FileName = "资产管理_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";
            string filepath = "/upload/ExcelExport/ExportFee/";
            downloadurl = DownloadProcess(dt, FileName, filepath);
            return true;
        }
        public static bool DownLoadCKProductData(Foresight.DataAccess.Ui.DataGrid dg, out string downloadurl, out string error)
        {
            downloadurl = string.Empty;
            error = string.Empty;
            var list = new ViewCKProductCategory[] { };
            if (dg != null)
            {
                list = dg.rows as ViewCKProductCategory[];
            }
            if (list.Length == 0)
            {
                error = "没有可导出的数据";
                return false;
            }
            DataTable dt = new DataTable();
            dt.Columns.Add("物品类别");
            dt.Columns.Add("物品编号");
            dt.Columns.Add("物品名称");
            dt.Columns.Add("计量单位");
            dt.Columns.Add("规格型号");
            dt.Columns.Add("默认单价");
            dt.Columns.Add("库存下限");
            dt.Columns.Add("库存上限");
            for (int i = 0; i < list.Length; i++)
            {
                DataRow dr = dt.NewRow();
                dr["物品类别"] = list[i].ProductCategoryName;
                dr["物品编号"] = list[i].ProductNumber;
                dr["物品名称"] = list[i].ProductName;
                dr["计量单位"] = list[i].Unit;
                dr["规格型号"] = list[i].ModelNumber;
                dr["默认单价"] = list[i].ProductUnitPrice > 0 ? list[i].ProductUnitPrice : 0;
                dr["库存下限"] = list[i].InventoryMin;
                dr["库存上限"] = list[i].InventoryMax;
                dt.Rows.Add(dr);
            }
            string FileName = "物品管理_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";
            string filepath = "/upload/ExcelExport/ExportFee/";
            downloadurl = DownloadProcess(dt, FileName, filepath);
            return true;
        }
        public static bool DownLoadCKMaterialLingYongData(Foresight.DataAccess.Ui.DataGrid dg, out string downloadurl, out string error)
        {
            downloadurl = string.Empty;
            error = string.Empty;
            var list = new ViewCKMaterialAnalysis[] { };
            if (dg != null)
            {
                list = dg.rows as ViewCKMaterialAnalysis[];
            }
            if (list.Length == 0)
            {
                error = "没有可导出的数据";
                return false;
            }
            DataTable dt = new DataTable();
            dt.Columns.Add("物品名称");
            dt.Columns.Add("物品类别");
            dt.Columns.Add("单位");
            dt.Columns.Add("单价");
            dt.Columns.Add("数量");
            dt.Columns.Add("金额");
            for (int i = 0; i < list.Length; i++)
            {
                DataRow dr = dt.NewRow();
                dr["物品名称"] = list[i].ProductName;
                dr["物品类别"] = list[i].CategoryName;
                dr["单位"] = list[i].Unit;
                dr["单价"] = list[i].ArvUnitPrice;
                dr["数量"] = list[i].TotalCount > 0 ? list[i].TotalCount : 0;
                dr["金额"] = list[i].TotalPrice > 0 ? list[i].TotalPrice : 0;
                dt.Rows.Add(dr);
            }
            string FileName = "物品领用_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";
            string filepath = "/upload/ExcelExport/ExportFee/";
            downloadurl = DownloadProcess(dt, FileName, filepath);
            return true;
        }
        public static bool DownLoadCKInventoryData(Foresight.DataAccess.Ui.DataGrid dg, out string downloadurl, out string error)
        {
            downloadurl = string.Empty;
            error = string.Empty;
            var list = new ViewCKProudctInventory[] { };
            if (dg != null)
            {
                list = dg.rows as ViewCKProudctInventory[];
            }
            if (list.Length == 0)
            {
                error = "没有可导出的数据";
                return false;
            }
            var titleList = GetTableColumns("ckinventorygrid");
            DataTable dt = new DataTable();
            foreach (var item in titleList)
            {
                if (!dt.Columns.Contains(item["ColumnName"].ToString()))
                {
                    dt.Columns.Add(item["ColumnName"].ToString());
                }
            }
            for (int i = 0; i < list.Length; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = list[i].ID;
                SetDrValue(titleList, dr, "物品名称", list[i].ProductName);
                SetDrValue(titleList, dr, "物品类别", list[i].CategoryName);
                SetDrValue(titleList, dr, "所在部门", list[i].DepartmentName);
                SetDrValue(titleList, dr, "规格型号", list[i].ModelNumber);
                SetDrValue(titleList, dr, "单位", list[i].Unit);
                SetDrValue(titleList, dr, "库存单价", list[i].ArvUnitPrice > 0 ? list[i].ArvUnitPrice : 0);
                SetDrValue(titleList, dr, "累计入库数量", list[i].InTotalCount > 0 ? list[i].InTotalCount : 0);
                SetDrValue(titleList, dr, "累计出库数量", list[i].OutTotalCount > 0 ? list[i].OutTotalCount : 0);
                SetDrValue(titleList, dr, "库存数量", list[i].Inventory > 0 ? list[i].Inventory : 0);
                SetDrValue(titleList, dr, "平均入库单价", list[i].ArvInUnitPrice > 0 ? list[i].ArvInUnitPrice : 0);
                SetDrValue(titleList, dr, "累计入库金额", list[i].InTotalPrice > 0 ? list[i].InTotalPrice : 0);
                SetDrValue(titleList, dr, "平均出库单价", list[i].ArvOutUnitPrice > 0 ? list[i].ArvOutUnitPrice : 0);
                SetDrValue(titleList, dr, "累计出库金额", list[i].OutTotalPrice > 0 ? list[i].OutTotalPrice : 0);
                SetDrValue(titleList, dr, "库存金额", list[i].FinalTotalCost > 0 ? list[i].FinalTotalCost : 0);
                dt.Rows.Add(dr);
            }
            string FileName = "库存_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";
            string filepath = "/upload/ExcelExport/ExportFee/";
            downloadurl = DownloadProcess(dt, FileName, filepath);
            return true;
        }
        public static bool DownLoadImportPropertyTemplateData(out string downloadurl, out string error)
        {
            downloadurl = string.Empty;
            error = string.Empty;
            DataTable dt = new DataTable();
            dt.Columns.Add("资产编号");
            dt.Columns.Add("资产名称");
            dt.Columns.Add("资产类别");
            dt.Columns.Add("规格型号");
            dt.Columns.Add("单位");
            dt.Columns.Add("数量");
            dt.Columns.Add("单价");
            dt.Columns.Add("购入金额");
            dt.Columns.Add("购入时间");
            dt.Columns.Add("预计使用年限");
            dt.Columns.Add("净值");
            dt.Columns.Add("折旧金额");
            dt.Columns.Add("变动方式");
            dt.Columns.Add("状态");
            dt.Columns.Add("使用部门");
            dt.Columns.Add("存放地点");
            dt.Columns.Add("使用人员");
            dt.Columns.Add("供应商");
            dt.Columns.Add("联系方式");
            dt.Columns.Add("备注");
            DataRow dr = dt.NewRow();
            dr["资产编号"] = "0011";
            dt.Rows.Add(dr);
            string FileName = "资产管理" + DateTime.Now.ToString("yyyyMMddHHmmss") + "_导入模板.xls";
            string filepath = "/upload/ExcelExport/ExportFee/";
            downloadurl = DownloadProcess(dt, FileName, filepath);
            return true;
        }
        public static bool DownLoadImportProductTemplateData(out string downloadurl, out string error)
        {
            downloadurl = string.Empty;
            error = string.Empty;
            DataTable dt = new DataTable();
            dt.Columns.Add("仓库名称");
            dt.Columns.Add("物品类别");
            dt.Columns.Add("物品编号");
            dt.Columns.Add("物品名称");
            dt.Columns.Add("计量单位");
            dt.Columns.Add("规格型号");
            dt.Columns.Add("默认单价");
            dt.Columns.Add("库存下限");
            dt.Columns.Add("库存上限");
            DataRow dr = dt.NewRow();
            dr["仓库名称"] = "仓库名称1";
            dt.Rows.Add(dr);
            string FileName = "物品管理" + DateTime.Now.ToString("yyyyMMddHHmmss") + "_导入模板.xls";
            string filepath = "/upload/ExcelExport/ExportFee/";
            downloadurl = DownloadProcess(dt, FileName, filepath);
            return true;
        }
        public static bool DownLoadImportCKInTemplateData(out string downloadurl, out string error)
        {
            downloadurl = string.Empty;
            error = string.Empty;
            DataTable dt = new DataTable();
            dt.Columns.Add("入库单号");
            dt.Columns.Add("所属一级仓库类别");
            dt.Columns.Add("所属二级仓库类别");
            dt.Columns.Add("仓管员");
            dt.Columns.Add("入库时间");
            dt.Columns.Add("入库类别");
            dt.Columns.Add("所在部门");
            dt.Columns.Add("供应商");
            dt.Columns.Add("供应商联系人");
            dt.Columns.Add("供应商联系电话");
            dt.Columns.Add("物品类别");
            dt.Columns.Add("物品名称");
            dt.Columns.Add("规格型号");
            dt.Columns.Add("单位");
            dt.Columns.Add("入库单价");
            dt.Columns.Add("入库数量");
            dt.Columns.Add("入库金额");
            dt.Columns.Add("备注");
            for (int i = 0; i < 2; i++)
            {
                DataRow dr = dt.NewRow();
                if (i == 0)
                {
                    dr["所属一级仓库类别"] = "成都蜀信仓库";
                    dr["所属二级仓库类别"] = "日常用品";
                    dr["仓管员"] = "管理员";
                    dr["入库时间"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
                    dr["入库类别"] = "采购入库";
                    dr["所在部门"] = "办公司";
                    dr["入库单号"] = "系统自动生成";
                    dr["供应商"] = "永友网络科技";
                    dr["供应商联系人"] = "樊磊";
                    dr["供应商联系电话"] = "13800138000";
                    dr["物品类别"] = "类别1";
                    dr["物品名称"] = "桌子";
                    dr["规格型号"] = "";
                    dr["单位"] = "个";
                    dr["入库单价"] = "100";
                    dr["入库数量"] = "6";
                    dr["入库金额"] = "系统自动计算";
                    dr["备注"] = "";
                }
                else
                {
                    dr["物品名称"] = "椅子";
                    dr["规格型号"] = "";
                    dr["单位"] = "个";
                    dr["入库单价"] = "50";
                    dr["入库数量"] = "8";
                    dr["入库金额"] = "自动计算";
                }
                dt.Rows.Add(dr);
            }
            string FileName = "入库单" + DateTime.Now.ToString("yyyyMMddHHmmss") + "_导入模板.xls";
            string filepath = "/upload/ExcelExport/ExportFee/";
            downloadurl = DownloadProcess(dt, FileName, filepath);
            return true;
        }
        public static bool DownLoadToCuiKuanListData(Foresight.DataAccess.Ui.DataGrid dg, out string downloadurl, out string error)
        {
            downloadurl = string.Empty;
            error = string.Empty;
            var list = new List<Dictionary<string, object>>();
            var footers = new List<Dictionary<string, object>>();
            if (dg != null)
            {
                list = dg.rows as List<Dictionary<string, object>>;
                if (dg.footer != null)
                {
                    footers = dg.footer as List<Dictionary<string, object>>;
                }
            }
            if (list.Count == 0)
            {
                error = "没有可导出的数据";
                return false;
            }
            DataTable dt = new DataTable();
            List<NpoiHeadCfg> head_list = new List<NpoiHeadCfg>();
            SaveNpoiHead("资源编号", "RoomName", head_list: head_list);
            dt.Columns.Add("RoomName");//0
            SaveNpoiHead("客户名称", "DefaultChargeManName", head_list: head_list);
            dt.Columns.Add("DefaultChargeManName"); //1
            SaveNpoiHead("联系方式", "RelatePhoneNumber", head_list: head_list);
            dt.Columns.Add("RelatePhoneNumber"); //2
            SaveNpoiHead("收费项目", "Name", head_list: head_list);
            dt.Columns.Add("Name"); //3
            SaveNpoiHead("单价", "CalculateUnitPrice", head_list: head_list);
            dt.Columns.Add("CalculateUnitPrice"); //4
            SaveNpoiHead("面积/用量", "CalculateUseCount", head_list: head_list);
            dt.Columns.Add("CalculateUseCount"); //5
            SaveNpoiHead("应收金额", "TotalCost", head_list: head_list);
            dt.Columns.Add("TotalCost");//6
            SaveNpoiHead("计费开始日期", "CalculateStartTime", head_list: head_list);
            dt.Columns.Add("CalculateStartTime"); //7
            SaveNpoiHead("计费结束日期", "CalculateEndTime", head_list: head_list);
            dt.Columns.Add("CalculateEndTime"); //8
            SaveNpoiHead("上次/本次读数", "LastNowPoint", head_list: head_list);
            dt.Columns.Add("LastNowPoint"); //9
            SaveNpoiHead("逾期", "OutDays", head_list: head_list);
            dt.Columns.Add("OutDays"); //10
            SaveNpoiHead("欠费分类", "CategoryNote", head_list: head_list);
            dt.Columns.Add("CategoryNote"); //11
            SaveNpoiHead("银行卡号", "BankAccountNo", head_list: head_list);
            dt.Columns.Add("BankAccountNo");
            SaveNpoiHead("住址", "HomeAddress", head_list: head_list);
            dt.Columns.Add("HomeAddress");
            SaveNpoiHead("部门", "BelongTeam", head_list: head_list);
            dt.Columns.Add("BelongTeam");
            SaveNpoiHead("功能系数", "FunctionCoefficient", head_list: head_list);
            dt.Columns.Add("FunctionCoefficient");
            DataRow dr = null;
            foreach (var item in list)
            {
                dr = dt.NewRow();
                foreach (var item2 in item)
                {
                    if (dt.Columns.Contains(item2.Key))
                    {
                        dr[item2.Key] = item2.Value;
                    }
                }
                dr["OutDays"] = calculateOutDays(item["CalculateStartTime"]);
                dr["LastNowPoint"] = item["FinalStartPoint"] + "/" + item["FinalEndPoint"];
                dt.Rows.Add(dr);
            }
            foreach (var item in footers)
            {
                dr = dt.NewRow();
                foreach (var item2 in item)
                {
                    if (dt.Columns.Contains(item2.Key))
                    {
                        dr[item2.Key] = item2.Value;
                    }
                }
                dt.Rows.Add(dr);
            }
            string FileName = "催收处理_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";
            string filepath = "/upload/ExcelExport/ExportFee/";
            downloadurl = DownloadProcess(dt, FileName, filepath, heads: head_list);
            return true;
        }
        public static bool DownLoadRoomFeeHistoryListData(Foresight.DataAccess.Ui.DataGrid dg, out string downloadurl, out string error)
        {
            error = string.Empty;
            downloadurl = string.Empty;
            ViewRoomFeeHistory[] list = new ViewRoomFeeHistory[] { };
            ViewRoomFeeHistory[] FooterRows = new ViewRoomFeeHistory[] { };
            if (dg != null)
            {
                list = dg.rows as ViewRoomFeeHistory[];
                if (dg.footer != null)
                {
                    FooterRows = dg.footer as ViewRoomFeeHistory[];
                }
            }
            if (list.Length == 0)
            {
                error = "没有可导出的数据";
                return false;
            }
            var titleList = GetTableColumns("roomfeehistory");
            DataTable dt = new DataTable();
            foreach (var item in titleList)
            {
                if (!dt.Columns.Contains(item["ColumnName"].ToString()))
                {
                    dt.Columns.Add(item["ColumnName"].ToString());
                }
            }
            List<CellRangeAddressModel> rangeList = new List<CellRangeAddressModel>();
            CellRangeAddressModel model1 = new CellRangeAddressModel();
            CellRangeAddressModel model2 = new CellRangeAddressModel();
            CellRangeAddressModel model3 = new CellRangeAddressModel();
            CellRangeAddressModel model4 = new CellRangeAddressModel();
            CellRangeAddressModel model5 = new CellRangeAddressModel();
            for (int i = 0; i < list.Length; i++)
            {
                if (i == 0)
                {
                    model1 = new CellRangeAddressModel();
                    model1.FirstRow = (i + 1);
                    model2 = new CellRangeAddressModel();
                    model2.FirstRow = (i + 1);
                    model3 = new CellRangeAddressModel();
                    model3.FirstRow = (i + 1);
                    model4 = new CellRangeAddressModel();
                    model4.FirstRow = (i + 1);
                    model5 = new CellRangeAddressModel();
                    model5.FirstRow = (i + 1);
                }
                DataRow dr = dt.NewRow();
                SetDrValue(titleList, dr, "收款单号", list[i].PrintNumber);
                SetDrValue(titleList, dr, "单据状态", list[i].ChargeStateDesc);
                SetDrValue(titleList, dr, "收款人", list[i].ChargeMan);
                SetDrValue(titleList, dr, "收款日期", WebUtil.GetStrDate(list[i].ChargeTime, "yyyy-MM-dd HH:mm:ss"));
                SetDrValue(titleList, dr, "房号", list[i].RoomName);
                SetDrValue(titleList, dr, "收费项目", list[i].ChargeName);
                SetDrValue(titleList, dr, "费项分类", list[i].ChargeTypeName);
                SetDrValue(titleList, dr, "计费开始日期", WebUtil.GetStrDate(list[i].StartTime));
                SetDrValue(titleList, dr, "计费结束日期", WebUtil.GetStrDate(list[i].EndTime));
                SetDrValue(titleList, dr, "单价", list[i].UnitPrice > 0 ? list[i].UnitPrice : 0);
                SetDrValue(titleList, dr, "面积/用量", list[i].UseCount > 0 ? list[i].UseCount : 0);
                decimal RealCost = 0;
                decimal PrintRealCost = 0;
                if (list[i].ChargeState == 3 || list[i].ChargeState == 6 || list[i].ChargeState == 7)
                {
                    RealCost = list[i].RealCost == decimal.MinValue ? 0 : -list[i].RealCost;
                    PrintRealCost = list[i].SumRealCost == decimal.MinValue ? 0 : -list[i].SumRealCost;
                }
                else
                {
                    RealCost = list[i].RealCost == decimal.MinValue ? 0 : list[i].RealCost;
                    PrintRealCost = list[i].SumRealCost == decimal.MinValue ? 0 : list[i].SumRealCost;
                }
                SetDrValue(titleList, dr, "实收金额", RealCost);
                SetDrValue(titleList, dr, "实收合计", PrintRealCost);
                SetDrValue(titleList, dr, "减免金额", list[i].Discount > 0 ? list[i].Discount : 0);
                SetDrValue(titleList, dr, "上次读数", list[i].StartPoint > 0 ? list[i].StartPoint : 0);
                SetDrValue(titleList, dr, "本次读数", list[i].EndPoint > 0 ? list[i].EndPoint : 0);
                SetDrValue(titleList, dr, "本次用量", list[i].TotalPoint > 0 ? list[i].TotalPoint : 0);
                SetDrValue(titleList, dr, "备注", list[i].Remark);
                SetDrValue(titleList, dr, "业主名称", list[i].RelationName);
                SetDrValue(titleList, dr, "联系方式", list[i].RelatePhoneNumber);
                SetDrValue(titleList, dr, "代扣对象", list[i].ChargeForMan);
                SetDrValue(titleList, dr, "一卡通号", list[i].OneCardNumber);
                SetDrValue(titleList, dr, "身份证号", list[i].RelationIDCard);
                SetDrValue(titleList, dr, "资源位置", list[i].FullName);
                SetDrValue(titleList, dr, "减免方案", list[i].DiscountName);
                dt.Rows.Add(dr);
                if (i == list.Length - 1)
                {
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
                    if (model4.IsUse)
                    {
                        rangeList.Add(model4);
                    }
                    if (model5.IsUse)
                    {
                        rangeList.Add(model5);
                    }
                }
                if (i < list.Length - 1)
                {
                    if (list[i].PrintNumber.Equals(list[i + 1].PrintNumber) && !string.IsNullOrEmpty(list[i].PrintNumber))
                    {

                        if (dt.Columns["收款单号"] != null)
                        {
                            model1.IsUse = true;
                            model1.LastRow = (i + 2);
                            model1.FirstCol = dt.Columns["收款单号"].Ordinal;
                            model1.LastCol = dt.Columns["收款单号"].Ordinal;
                        }
                        if (dt.Columns["单据状态"] != null)
                        {
                            model2.IsUse = true;
                            model2.LastRow = (i + 2);
                            model2.FirstCol = dt.Columns["单据状态"].Ordinal;
                            model2.LastCol = dt.Columns["单据状态"].Ordinal;
                        }
                        if (dt.Columns["收款人"] != null)
                        {
                            model3.IsUse = true;
                            model3.LastRow = (i + 2);
                            model3.FirstCol = dt.Columns["收款人"].Ordinal;
                            model3.LastCol = dt.Columns["收款人"].Ordinal;
                        }
                        if (dt.Columns["收款日期"] != null)
                        {
                            model4.IsUse = true;
                            model4.LastRow = (i + 2);
                            model4.FirstCol = dt.Columns["收款日期"].Ordinal;
                            model4.LastCol = dt.Columns["收款日期"].Ordinal;
                        }
                        if (dt.Columns["实收合计"] != null)
                        {
                            model5.IsUse = true;
                            model5.LastRow = (i + 2);
                            model5.FirstCol = dt.Columns["实收合计"].Ordinal;
                            model5.LastCol = dt.Columns["实收合计"].Ordinal;
                        }
                    }
                    else
                    {
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
                        if (model4.IsUse)
                        {
                            rangeList.Add(model4);
                        }
                        if (model5.IsUse)
                        {
                            rangeList.Add(model5);
                        }
                        model1 = new CellRangeAddressModel();
                        model1.FirstRow = (i + 2);
                        model2 = new CellRangeAddressModel();
                        model2.FirstRow = (i + 2);
                        model3 = new CellRangeAddressModel();
                        model3.FirstRow = (i + 2);
                        model4 = new CellRangeAddressModel();
                        model4.FirstRow = (i + 2);
                        model5 = new CellRangeAddressModel();
                        model5.FirstRow = (i + 2);
                    }
                }
            }
            if (FooterRows.Length > 0)
            {
                DataRow footer_dr = dt.NewRow();
                if (dt.Columns.Contains("面积/用量"))
                {
                    footer_dr["面积/用量"] = FooterRows[0].UseCount <= 0 ? 0 : FooterRows[0].UseCount;
                }
                if (dt.Columns.Contains("实收合计"))
                {
                    footer_dr["实收合计"] = FooterRows[0].SumRealCost <= 0 ? 0 : FooterRows[0].SumRealCost;
                }
                if (dt.Columns.Contains("实收金额"))
                {
                    footer_dr["实收金额"] = FooterRows[0].RealCost <= 0 ? 0 : FooterRows[0].RealCost;
                }
                dt.Rows.Add(footer_dr);
            }
            string FileName = "历史单据_" + DateTime.Now.ToString("yyyyMMddHHmmss") + "_导入.xls";
            string filepath = "/upload/ExcelExport/ExportFee/";
            downloadurl = DownloadProcess(dt, FileName, filepath, rangeList: rangeList);
            return true;
        }
        public static bool DownLoadToChargeAnalysisSummaryV2Data(Foresight.DataAccess.Ui.DataGrid dg, out string downloadurl, out string error)
        {
            downloadurl = string.Empty;
            error = string.Empty;
            var list = new ChargeSummaryDetails[] { };
            var footers = new List<ChargeSummaryDetails>();
            if (dg != null)
            {
                list = dg.rows as ChargeSummaryDetails[];
                if (dg.footer != null)
                {
                    footers = dg.footer as List<ChargeSummaryDetails>;
                }
            }
            if (list.Length == 0)
            {
                error = "没有可导出的数据";
                return false;
            }
            DataTable dt = new DataTable();
            dt.Columns.Add("收费项目");
            dt.Columns.Add("期初欠费");
            dt.Columns.Add("本期欠费");
            dt.Columns.Add("期末欠费");
            DataRow dr = null;
            foreach (var item in list)
            {
                dr = dt.NewRow();
                dr["收费项目"] = item.Name;
                dr["期初欠费"] = item.PreTotalCost;
                dr["本期欠费"] = item.Cost;
                dr["期末欠费"] = item.AfterTotalCost;
                dt.Rows.Add(dr);
            }
            foreach (var item in footers)
            {
                dr = dt.NewRow();
                dr["收费项目"] = item.Name;
                dr["期初欠费"] = item.PreTotalCost;
                dr["本期欠费"] = item.Cost;
                dr["期末欠费"] = item.AfterTotalCost;
                dt.Rows.Add(dr);
            }
            string FileName = "欠费汇总_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";
            string filepath = "/upload/ExcelExport/ExportFee/";
            downloadurl = DownloadProcess(dt, FileName, filepath);
            return true;
        }
        public static bool DownLoadToChargeAnalysisSummaryData(Foresight.DataAccess.Ui.DataGrid dg, out string downloadurl, out string error)
        {
            downloadurl = string.Empty;
            error = string.Empty;
            var list = new ChargeSummaryToChargeSummary[] { };
            var footers = new List<ChargeSummaryToChargeSummary>();
            if (dg != null)
            {
                list = dg.rows as ChargeSummaryToChargeSummary[];
                if (dg.footer != null)
                {
                    footers = dg.footer as List<ChargeSummaryToChargeSummary>;
                }
            }
            if (list.Length == 0)
            {
                error = "没有可导出的数据";
                return false;
            }
            DataTable dt = new DataTable();
            dt.Columns.Add("收费项目");
            dt.Columns.Add("应收金额");
            dt.Columns.Add("已收金额");
            dt.Columns.Add("应收欠费");
            DataRow dr = null;
            foreach (var item in list)
            {
                dr = dt.NewRow();
                dr["收费项目"] = item.Name;
                dr["应收金额"] = item.TotalCost;
                dr["已收金额"] = item.PayCost;
                dr["应收欠费"] = item.RestCost;
                dt.Rows.Add(dr);
            }
            foreach (var item in footers)
            {
                dr = dt.NewRow();
                dr["收费项目"] = item.Name;
                dr["应收金额"] = item.TotalCost;
                dr["已收金额"] = item.PayCost;
                dr["应收欠费"] = item.RestCost;
                dt.Rows.Add(dr);
            }
            string FileName = "欠费汇总_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";
            string filepath = "/upload/ExcelExport/ExportFee/";
            downloadurl = DownloadProcess(dt, FileName, filepath);
            return true;
        }
        public static bool DownLoadToChargeAnalysisDetailStaticsData(Foresight.DataAccess.Ui.DataGrid dg, out string downloadurl, out string error)
        {
            downloadurl = string.Empty;
            error = string.Empty;
            var list = new List<Dictionary<string, object>>();
            var footers = new List<Dictionary<string, object>>();
            if (dg != null)
            {
                list = dg.rows as List<Dictionary<string, object>>;
                if (dg.footer != null)
                {
                    footers = dg.footer as List<Dictionary<string, object>>;
                }
            }
            if (list.Count == 0)
            {
                error = "没有可导出的数据";
                return false;
            }
            DataTable dt = new DataTable();
            List<NpoiHeadCfg> head_list = new List<NpoiHeadCfg>();
            SaveNpoiHead("资源编号", "RoomName", head_list: head_list);
            dt.Columns.Add("RoomName");//0
            SaveNpoiHead("客户名称", "DefaultChargeManName", head_list: head_list);
            dt.Columns.Add("DefaultChargeManName"); //1
            SaveNpoiHead("联系方式", "RelatePhoneNumber", head_list: head_list);
            dt.Columns.Add("RelatePhoneNumber"); //2
            SaveNpoiHead("收费项目", "Name", head_list: head_list);
            dt.Columns.Add("Name"); //3
            SaveNpoiHead("单价", "CalculateUnitPrice", head_list: head_list);
            dt.Columns.Add("CalculateUnitPrice"); //4
            SaveNpoiHead("面积/用量", "CalculateUseCount", head_list: head_list);
            dt.Columns.Add("CalculateUseCount"); //5
            SaveNpoiHead("应收金额", "TotalCost", head_list: head_list);
            dt.Columns.Add("TotalCost");//6
            SaveNpoiHead("计费开始日期", "CalculateStartTime", head_list: head_list);
            dt.Columns.Add("CalculateStartTime"); //7
            SaveNpoiHead("计费结束日期", "CalculateEndTime", head_list: head_list);
            dt.Columns.Add("CalculateEndTime"); //8
            SaveNpoiHead("上次/本次读数", "LastNowPoint", head_list: head_list);
            dt.Columns.Add("LastNowPoint"); //9
            SaveNpoiHead("逾期", "OutDays", head_list: head_list);
            dt.Columns.Add("OutDays"); //10
            SaveNpoiHead("欠费分类", "CategoryNote", head_list: head_list);
            dt.Columns.Add("CategoryNote"); //11
            SaveNpoiHead("沟通备注", "RemarkNote", head_list: head_list);
            dt.Columns.Add("RemarkNote"); //12       
            DataRow dr = null;
            foreach (var item in list)
            {
                dr = dt.NewRow();
                foreach (var item2 in item)
                {
                    if (dt.Columns.Contains(item2.Key))
                    {
                        dr[item2.Key] = item2.Value;
                    }
                }
                dr["OutDays"] = calculateOutDays(item["CalculateStartTime"]);
                dr["LastNowPoint"] = item["FinalStartPoint"] + "/" + item["FinalEndPoint"];
                dt.Rows.Add(dr);
            }
            foreach (var item in footers)
            {
                dr = dt.NewRow();
                foreach (var item2 in item)
                {
                    if (dt.Columns.Contains(item2.Key))
                    {
                        dr[item2.Key] = item2.Value;
                    }
                }
                dt.Rows.Add(dr);
            }
            string FileName = "欠费_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";
            string filepath = "/upload/ExcelExport/ExportFee/";
            downloadurl = DownloadProcess(dt, FileName, filepath, heads: head_list);
            return true;
        }
        public static bool DownLoadToChargeAnalysisDetailData(Foresight.DataAccess.Ui.DataGrid dg, out string downloadurl, out string error)
        {
            downloadurl = string.Empty;
            error = string.Empty;
            var list = new List<Dictionary<string, object>>();
            var footers = new List<Dictionary<string, object>>();
            if (dg != null)
            {
                list = dg.rows as List<Dictionary<string, object>>;
                if (dg.footer != null)
                {
                    footers = dg.footer as List<Dictionary<string, object>>;
                }
            }
            if (list.Count == 0)
            {
                error = "没有可导出的数据";
                return false;
            }
            DataTable dt = new DataTable();
            List<NpoiHeadCfg> head_list = new List<NpoiHeadCfg>();
            SaveNpoiHead("资源位置", "FullName", head_list: head_list);
            dt.Columns.Add("FullName");//0
            SaveNpoiHead("资源编号", "RoomName", head_list: head_list);
            dt.Columns.Add("RoomName");//0
            SaveNpoiHead("客户名称", "DefaultChargeManName", head_list: head_list);
            dt.Columns.Add("DefaultChargeManName"); //1
            SaveNpoiHead("联系方式", "RelatePhoneNumber", head_list: head_list);
            dt.Columns.Add("RelatePhoneNumber"); //2
            SaveNpoiHead("收费项目", "Name", head_list: head_list);
            dt.Columns.Add("Name"); //3
            SaveNpoiHead("单价", "CalculateUnitPrice", head_list: head_list);
            dt.Columns.Add("CalculateUnitPrice"); //4
            SaveNpoiHead("面积/用量", "CalculateUseCount", head_list: head_list);
            dt.Columns.Add("CalculateUseCount"); //5
            SaveNpoiHead("应收金额", "TotalCost", head_list: head_list);
            dt.Columns.Add("TotalCost");//6
            SaveNpoiHead("已收金额", "TotalFinalPayCost", head_list: head_list);
            dt.Columns.Add("TotalFinalPayCost");//6
            SaveNpoiHead("应收欠费", "TotalFinalCost", head_list: head_list);
            dt.Columns.Add("TotalFinalCost");//6
            SaveNpoiHead("计费开始日期", "CalculateStartTime", head_list: head_list);
            dt.Columns.Add("CalculateStartTime"); //7
            SaveNpoiHead("计费结束日期", "CalculateEndTime", head_list: head_list);
            dt.Columns.Add("CalculateEndTime"); //8
            SaveNpoiHead("上次/本次读数", "LastNowPoint", head_list: head_list);
            dt.Columns.Add("LastNowPoint"); //9
            SaveNpoiHead("逾期", "OutDays", head_list: head_list);
            dt.Columns.Add("OutDays"); //10
            SaveNpoiHead("欠费分类", "CategoryNote", head_list: head_list);
            dt.Columns.Add("CategoryNote"); //11
            SaveNpoiHead("沟通备注", "RemarkNote", head_list: head_list);
            dt.Columns.Add("RemarkNote"); //12       
            DataRow dr = null;
            foreach (var item in list)
            {
                dr = dt.NewRow();
                foreach (var item2 in item)
                {
                    if (dt.Columns.Contains(item2.Key))
                    {
                        dr[item2.Key] = item2.Value;
                    }
                }
                dr["OutDays"] = calculateOutDays(item["CalculateStartTime"]);
                dr["LastNowPoint"] = item["FinalStartPoint"] + "/" + item["FinalEndPoint"];
                dt.Rows.Add(dr);
            }
            foreach (var item in footers)
            {
                dr = dt.NewRow();
                foreach (var item2 in item)
                {
                    if (dt.Columns.Contains(item2.Key))
                    {
                        dr[item2.Key] = item2.Value;
                    }
                }
                dt.Rows.Add(dr);
            }
            string FileName = "欠费_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";
            string filepath = "/upload/ExcelExport/ExportFee/";
            downloadurl = DownloadProcess(dt, FileName, filepath, heads: head_list);
            return true;
        }
        private static string calculateOutDays(object _StartTime)
        {
            if (_StartTime == null)
            {
                return string.Empty;
            }
            DateTime StartTime = DateTime.MinValue;
            DateTime.TryParse(_StartTime.ToString(), out StartTime);
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
        public static bool DownLoadShouRuZhiChuPayServiceData(Foresight.DataAccess.Ui.DataGrid dg, out string downloadurl, out string error)
        {
            downloadurl = string.Empty;
            error = string.Empty;
            var list = new List<Dictionary<string, object>>();
            var footers = new List<Dictionary<string, object>>();
            if (dg != null)
            {
                list = dg.rows as List<Dictionary<string, object>>;
                if (dg.footer != null)
                {
                    footers = dg.footer as List<Dictionary<string, object>>;
                }
            }
            if (list.Count == 0)
            {
                error = "没有可导出的数据";
                return false;
            }
            DataTable dt = new DataTable();
            dt.Columns.Add("收费项目");
            dt.Columns.Add("支出金额");
            DataRow dr = null;
            foreach (var item in list)
            {
                dr = dt.NewRow();
                dr["收费项目"] = item["Name"];
                dr["支出金额"] = item["TotalCost"];
                dt.Rows.Add(dr);
            }
            foreach (var item in footers)
            {
                dr = dt.NewRow();
                dr["收费项目"] = item["Name"];
                dr["支出金额"] = item["TotalCost"];
                dt.Rows.Add(dr);
            }
            string FileName = "收入支出支出汇总_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";
            string filepath = "/upload/ExcelExport/ExportFee/";
            downloadurl = DownloadProcess(dt, FileName, filepath);
            return true;
        }
        public static bool DownLoadShouRuZhiChuChargeTypeData(Foresight.DataAccess.Ui.DataGrid dg, out string downloadurl, out string error)
        {
            downloadurl = string.Empty;
            error = string.Empty;
            var list = new List<Dictionary<string, object>>();
            var footers = new List<Dictionary<string, object>>();
            if (dg != null)
            {
                list = dg.rows as List<Dictionary<string, object>>;
                if (dg.footer != null)
                {
                    footers = dg.footer as List<Dictionary<string, object>>;
                }
            }
            if (list.Count == 0)
            {
                error = "没有可导出的数据";
                return false;
            }
            DataTable dt = new DataTable();
            dt.Columns.Add("收支方式");
            dt.Columns.Add("收入");
            dt.Columns.Add("支出");
            DataRow dr = null;
            foreach (var item in list)
            {
                dr = dt.NewRow();
                dr["收支方式"] = item["Name"];
                dr["收入"] = item["ShouRuCost"];
                dr["支出"] = item["ZhiChuCost"];
                dt.Rows.Add(dr);
            }
            foreach (var item in footers)
            {
                dr = dt.NewRow();
                dr["收支方式"] = item["Name"];
                dr["收入"] = item["ShouRuCost"];
                dr["支出"] = item["ZhiChuCost"];
                dt.Rows.Add(dr);
            }
            string FileName = "收入支出收款方式汇总_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";
            string filepath = "/upload/ExcelExport/ExportFee/";
            downloadurl = DownloadProcess(dt, FileName, filepath);
            return true;
        }
        public static bool DownloadPreChargeShouRuZhiChuSummary(Foresight.DataAccess.Ui.DataGrid dg, out string downloadurl, out string error)
        {
            error = string.Empty;
            downloadurl = string.Empty;
            var list = new ChargeSummaryPreChargeAnalysis[] { };
            var footer = new ChargeSummaryPreChargeAnalysis[] { };
            if (dg != null)
            {
                list = dg.rows as ChargeSummaryPreChargeAnalysis[];
                if (dg.footer != null)
                {
                    footer = dg.footer as ChargeSummaryPreChargeAnalysis[];
                }
            }
            if (list.Length == 0)
            {
                error = "没有可导出的数据";
                return false;
            }
            DataTable dt = new DataTable();
            dt.Columns.Add("收费项目");
            dt.Columns.Add("期初余额");
            dt.Columns.Add("本期冲抵");
            dt.Columns.Add("期末余额");
            for (int i = 0; i < list.Length; i++)
            {
                DataRow dr = dt.NewRow();
                dr["收费项目"] = list[i].Name;
                dr["期初余额"] = list[i].PreTotalCost <= 0 ? 0 : list[i].PreTotalCost;
                dr["本期冲抵"] = list[i].ChargeBackCost <= 0 ? 0 : list[i].ChargeBackCost;
                dr["期末余额"] = list[i].AfterTotalCost <= 0 ? 0 : list[i].AfterTotalCost;
                dt.Rows.Add(dr);
            }
            if (footer.Length > 0)
            {
                DataRow footer_dr = dt.NewRow();
                footer_dr["收费项目"] = "总合计";
                footer_dr["期初余额"] = footer[0].PreTotalCost <= 0 ? 0 : footer[0].PreTotalCost;
                footer_dr["本期冲抵"] = footer[0].ChargeBackCost <= 0 ? 0 : footer[0].ChargeBackCost;
                footer_dr["期末余额"] = footer[0].AfterTotalCost <= 0 ? 0 : footer[0].AfterTotalCost;
                dt.Rows.Add(footer_dr);
            }
            string FileName = "收入支出冲销汇总_" + DateTime.Now.ToString("yyyyMMddHHmmss") + "_导入.xls";
            string filepath = "/upload/ExcelExport/ExportFee/";
            downloadurl = DownloadProcess(dt, FileName, filepath);
            return true;
        }
        public static bool DownLoadShouRuZhiChuSummaryAnalysisData(Foresight.DataAccess.Ui.DataGrid dg, string RoomType, out string downloadurl, out string error)
        {
            downloadurl = string.Empty;
            error = string.Empty;
            var list = new ChargeSummaryShouFeiLvAnalysis[] { };
            var footers = new List<ChargeSummaryShouFeiLvAnalysis>();
            if (dg != null)
            {
                list = dg.rows as ChargeSummaryShouFeiLvAnalysis[];
                if (dg.footer != null)
                {
                    footers = dg.footer as List<ChargeSummaryShouFeiLvAnalysis>;
                }
            }
            if (list.Length == 0)
            {
                error = "没有可导出的数据";
                return false;
            }
            DataTable dt = new DataTable();
            List<NpoiHeadCfg> head_list = new List<NpoiHeadCfg>();
            if (RoomType == "Charge")
            {
                SaveNpoiHead("收费项目", "Name", head_list: head_list);
                dt.Columns.Add("Name");

                var parent_head = SaveNpoiHead("实收金额", "实收金额");
                SaveNpoiHead("收本期", "MonthBenqiShouBenqi_ShiShou", parent_head: parent_head);
                dt.Columns.Add("MonthBenqiShouBenqi_ShiShou");
                SaveNpoiHead("收历史", "MonthBenqiShouLishi_ShiShou", parent_head: parent_head);
                dt.Columns.Add("MonthBenqiShouLishi_ShiShou");
                SaveNpoiHead("收以后", "MonthBenqiYuShou_ShiShou", parent_head: parent_head);
                dt.Columns.Add("MonthBenqiYuShou_ShiShou");
                head_list.Add(parent_head);

                SaveNpoiHead("合计", "ALLShiShouCost", head_list: head_list);
                dt.Columns.Add("ALLShiShouCost");
                DataRow dr = null;
                foreach (var item in list)
                {
                    dr = dt.NewRow();
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        string ColumnName = dt.Columns[i].ColumnName;
                        dr[ColumnName] = GetPropertyValue(item, ColumnName);
                    }
                    dt.Rows.Add(dr);
                }
                foreach (var item in footers)
                {
                    dr = dt.NewRow();
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        string ColumnName = dt.Columns[i].ColumnName;
                        dr[ColumnName] = GetPropertyValue(item, ColumnName);
                    }
                    dt.Rows.Add(dr);
                }
            }
            string FileName = "收入支出收入汇总_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";
            string filepath = "/upload/ExcelExport/ExportFee/";
            downloadurl = DownloadProcess(dt, FileName, filepath, heads: head_list);
            return true;
        }
        public static bool DownLoadShouruSummaryAnalysisData(Foresight.DataAccess.Ui.DataGrid dg, out string downloadurl, out string error)
        {
            downloadurl = string.Empty;
            error = string.Empty;
            var list = new List<Dictionary<string, object>>();
            var footers = new List<Dictionary<string, object>>();
            if (dg != null)
            {
                list = dg.rows as List<Dictionary<string, object>>;
                if (dg.footer != null)
                {
                    footers = dg.footer as List<Dictionary<string, object>>;
                }
            }
            if (list.Count == 0)
            {
                error = "没有可导出的数据";
                return false;
            }
            DataTable dt = new DataTable();
            dt.Columns.Add("收费项目");
            dt.Columns.Add("应收");
            dt.Columns.Add("实收");
            dt.Columns.Add("已收");
            dt.Columns.Add("本期收以后");
            dt.Columns.Add("本期收历史");
            dt.Columns.Add("历史欠费");
            DataRow dr = null;
            foreach (var item in list)
            {
                dr = dt.NewRow();
                dr["收费项目"] = item["ChargeName"];
                dr["应收"] = item["YingShou"];
                dr["实收"] = item["ShiShou"];
                dr["已收"] = item["YiShou"];
                dr["本期收以后"] = item["BenQiShouYiHou"];
                dr["本期收历史"] = item["BenQiShouLiShi"];
                dr["历史欠费"] = item["LiShiQianFei"];
                dt.Rows.Add(dr);
            }
            foreach (var item in footers)
            {
                dr = dt.NewRow();
                dr["收费项目"] = item["ChargeName"];
                dr["应收"] = item["YingShou"];
                dr["实收"] = item["ShiShou"];
                dr["已收"] = item["YiShou"];
                dr["本期收以后"] = item["BenQiShouYiHou"];
                dr["本期收历史"] = item["BenQiShouLiShi"];
                dr["历史欠费"] = item["LiShiQianFei"];
                dt.Rows.Add(dr);
            }
            string FileName = "收入分析_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";
            string filepath = "/upload/ExcelExport/ExportFee/";
            downloadurl = DownloadProcess(dt, FileName, filepath);
            return true;
        }
        public static bool DownLoadRealCostAnalysisSummaryData(Foresight.DataAccess.Ui.DataGrid dg, out string downloadurl, out string error)
        {
            downloadurl = string.Empty;
            error = string.Empty;
            var list = new List<Dictionary<string, object>>();
            var footers = new List<Dictionary<string, object>>();
            if (dg != null)
            {
                list = dg.rows as List<Dictionary<string, object>>;
                if (dg.footer != null)
                {
                    footers = dg.footer as List<Dictionary<string, object>>;
                }
            }
            if (list.Count == 0)
            {
                error = "没有可导出的数据";
                return false;
            }
            DataTable dt = new DataTable();
            dt.Columns.Add("收费项目");
            dt.Columns.Add("减免");
            dt.Columns.Add("实收");
            dt.Columns.Add("实收合计");
            DataRow dr = null;
            foreach (var item in list)
            {
                dr = dt.NewRow();
                dr["收费项目"] = item["ChargeName"];
                dr["减免"] = item["TotalDiscount"];
                dr["实收"] = item["ShiShou"];
                dr["实收合计"] = item["ALLPrintCost"];
                dt.Rows.Add(dr);
            }
            foreach (var item in footers)
            {
                dr = dt.NewRow();
                dr["收费项目"] = item["ChargeName"];
                dr["减免"] = item["TotalDiscount"];
                dr["实收"] = item["ShiShou"];
                dr["实收合计"] = item["ALLPrintCost"];
                dt.Rows.Add(dr);
            }
            string FileName = "实收台帐汇总_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";
            string filepath = "/upload/ExcelExport/ExportFee/";
            downloadurl = DownloadProcess(dt, FileName, filepath);
            return true;
        }
        public static bool DownLoadShouFeiLvQuanZeByMonthData(Foresight.DataAccess.Ui.DataGrid dg, string RoomType, out string downloadurl, out string error)
        {
            downloadurl = string.Empty;
            error = string.Empty;
            var list = new ChargeSummaryShouFeiLvAnalysis[] { };
            var footers = new List<ChargeSummaryShouFeiLvAnalysis>();
            if (dg != null)
            {
                list = dg.rows as ChargeSummaryShouFeiLvAnalysis[];
                if (dg.footer != null)
                {
                    footers = dg.footer as List<ChargeSummaryShouFeiLvAnalysis>;
                }
            }
            if (list.Length == 0)
            {
                error = "没有可导出的数据";
                return false;
            }
            DataTable dt = new DataTable();
            List<NpoiHeadCfg> head_list = new List<NpoiHeadCfg>();
            SaveNpoiHead("资源信息", "RoomName", head_list: head_list);
            dt.Columns.Add("RoomName");

            SaveNpoiHead("收费项目", "Name", head_list: head_list);
            dt.Columns.Add("Name");

            var parent_head = SaveNpoiHead("本期应收", "本期应收");
            SaveNpoiHead("本期收本期", "MonthBenqiShouBenqi", parent_head: parent_head);
            dt.Columns.Add("MonthBenqiShouBenqi");
            SaveNpoiHead("本期收历史", "MonthBenqiShouLishi", parent_head: parent_head);
            dt.Columns.Add("MonthBenqiShouLishi");
            SaveNpoiHead("本期收以后", "MonthBenqiYuShou", parent_head: parent_head);
            dt.Columns.Add("MonthBenqiYuShou");
            head_list.Add(parent_head);

            SaveNpoiHead("之后收本期", "MonthZhiHouShouBenqi", head_list: head_list);
            dt.Columns.Add("MonthZhiHouShouBenqi");

            SaveNpoiHead("之前收本期", "MonthLishiShouBenqi", head_list: head_list);
            dt.Columns.Add("MonthLishiShouBenqi");

            SaveNpoiHead("本期收费率", "BenQiShouFeiLv", head_list: head_list);
            dt.Columns.Add("BenQiShouFeiLv");

            SaveNpoiHead("累计收费率", "ShiShiShouFeiLv", head_list: head_list);
            dt.Columns.Add("ShiShiShouFeiLv");
            DataRow dr = null;
            if (RoomType == "Project" || RoomType == "Room")
            {
                foreach (var item in list)
                {
                    dr = dt.NewRow();
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        string ColumnName = dt.Columns[i].ColumnName;
                        dr[ColumnName] = GetPropertyValue(item, ColumnName);
                    }
                    dt.Rows.Add(dr);
                }
                foreach (var item in footers)
                {
                    dr = dt.NewRow();
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        string ColumnName = dt.Columns[i].ColumnName;
                        dr[ColumnName] = GetPropertyValue(item, ColumnName);
                    }
                    dt.Rows.Add(dr);
                }
            }
            string FileName = "收入分析表_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";
            string filepath = "/upload/ExcelExport/ExportFee/";
            downloadurl = DownloadProcess(dt, FileName, filepath, heads: head_list);
            return true;
        }
        public static bool DownloadProjectCountAnalysis(Foresight.DataAccess.Ui.DataGrid dg, out string downloadurl, out string error)
        {
            error = string.Empty;
            downloadurl = string.Empty;
            var list = new List<Dictionary<string, object>>();
            var footer = new List<Dictionary<string, object>>();
            if (dg != null)
            {
                list = dg.rows as List<Dictionary<string, object>>;
                if (dg.footer != null)
                {
                    footer = dg.footer as List<Dictionary<string, object>>;
                }
            }
            if (list.Count == 0)
            {
                error = "没有可导出的数据";
                return false;
            }
            DataTable dt = new DataTable();
            List<NpoiHeadCfg> head_list = new List<NpoiHeadCfg>();
            SaveNpoiHead("项目", "ProjectName", head_list: head_list);
            dt.Columns.Add("ProjectName");
            var parent_head = SaveNpoiHead("应收情况", "应收情况");
            SaveNpoiHead("户数", "YingShou_Count", parent_head: parent_head);
            dt.Columns.Add("YingShou_Count");
            SaveNpoiHead("金额", "YingShou_Amount", parent_head: parent_head);
            dt.Columns.Add("YingShou_Amount");
            head_list.Add(parent_head);

            parent_head = SaveNpoiHead("实收情况", "实收情况");
            SaveNpoiHead("户数", "ShiShou_Count", parent_head: parent_head);
            dt.Columns.Add("ShiShou_Count");
            SaveNpoiHead("金额", "ShiShou_Amount", parent_head: parent_head);
            dt.Columns.Add("ShiShou_Amount");
            head_list.Add(parent_head);

            parent_head = SaveNpoiHead("收费率%", "收费率%");
            SaveNpoiHead("户数", "ShouFeiLv_Count", parent_head: parent_head);
            dt.Columns.Add("ShouFeiLv_Count");
            SaveNpoiHead("金额", "ShiShou_Amount", parent_head: parent_head);
            dt.Columns.Add("ShouFeiLv_Amount");
            head_list.Add(parent_head);

            for (int i = 0; i < list.Count; i++)
            {
                DataRow dr = dt.NewRow();
                foreach (var item in list[i])
                {
                    if (dt.Columns.Contains(item.Key))
                    {
                        dr[item.Key] = list[i][item.Key];
                    }
                }
                dt.Rows.Add(dr);
            }
            if (footer.Count > 0)
            {
                DataRow footer_dr = dt.NewRow();
                foreach (var item in footer[0])
                {
                    if (dt.Columns.Contains(item.Key))
                    {
                        footer_dr[item.Key] = footer[0][item.Key];
                    }
                }
                dt.Rows.Add(footer_dr);
            }
            string FileName = "收费率表_" + DateTime.Now.ToString("yyyyMMddHHmmss") + "_导入.xls";
            string filepath = "/upload/ExcelExport/ExportFee/";
            downloadurl = DownloadProcess(dt, FileName, filepath, heads: head_list);
            return true;
        }
        public static bool DownloadPreChargeSummary(Foresight.DataAccess.Ui.DataGrid dg, out string downloadurl, out string error)
        {
            error = string.Empty;
            downloadurl = string.Empty;
            var list = new ChargeSummaryPreChargeAnalysis[] { };
            var footer = new ChargeSummaryPreChargeAnalysis[] { };
            if (dg != null)
            {
                list = dg.rows as ChargeSummaryPreChargeAnalysis[];
                if (dg.footer != null)
                {
                    footer = dg.footer as ChargeSummaryPreChargeAnalysis[];
                }
            }
            if (list.Length == 0)
            {
                error = "没有可导出的数据";
                return false;
            }
            DataTable dt = new DataTable();
            dt.Columns.Add("资源位置");
            dt.Columns.Add("房间编号");
            dt.Columns.Add("收费项目");
            dt.Columns.Add("期初余额");
            dt.Columns.Add("本期预收");
            dt.Columns.Add("本期冲抵");
            dt.Columns.Add("本期退还");
            dt.Columns.Add("期末余额");
            for (int i = 0; i < list.Length; i++)
            {
                DataRow dr = dt.NewRow();
                dr["资源位置"] = list[i].FullName;
                dr["房间编号"] = list[i].RoomName;
                dr["收费项目"] = list[i].Name;
                dr["期初余额"] = list[i].PreTotalCost <= 0 ? 0 : list[i].PreTotalCost;
                dr["本期预收"] = list[i].Cost <= 0 ? 0 : list[i].Cost;
                dr["本期冲抵"] = list[i].ChargeBackCost <= 0 ? 0 : list[i].ChargeBackCost;
                dr["本期退还"] = list[i].ChargeReturnCost <= 0 ? 0 : list[i].ChargeReturnCost;
                dr["期末余额"] = list[i].AfterTotalCost <= 0 ? 0 : list[i].AfterTotalCost;
                dt.Rows.Add(dr);
            }
            if (footer.Length > 0)
            {
                DataRow footer_dr = dt.NewRow();
                footer_dr["资源位置"] = "总合计";
                footer_dr["期初余额"] = footer[0].PreTotalCost <= 0 ? 0 : footer[0].PreTotalCost;
                footer_dr["本期预收"] = footer[0].Cost <= 0 ? 0 : footer[0].Cost;
                footer_dr["本期冲抵"] = footer[0].ChargeBackCost <= 0 ? 0 : footer[0].ChargeBackCost;
                footer_dr["本期退还"] = footer[0].ChargeReturnCost <= 0 ? 0 : footer[0].ChargeReturnCost;
                footer_dr["期末余额"] = footer[0].AfterTotalCost <= 0 ? 0 : footer[0].AfterTotalCost;
                dt.Rows.Add(footer_dr);
            }
            string FileName = "预收台帐_" + DateTime.Now.ToString("yyyyMMddHHmmss") + "_导入.xls";
            string filepath = "/upload/ExcelExport/ExportFee/";
            downloadurl = DownloadProcess(dt, FileName, filepath);
            return true;
        }
        public static bool DownloadDepositSummaryByChargename(Foresight.DataAccess.Ui.DataGrid dg, out string downloadurl, out string error)
        {
            error = string.Empty;
            downloadurl = string.Empty;
            var list = new ChargeSummaryDepositChargeAnalysis[] { };
            var footer = new ChargeSummaryDepositChargeAnalysis[] { };
            if (dg != null)
            {
                list = dg.rows as ChargeSummaryDepositChargeAnalysis[];
                if (dg.footer != null)
                {
                    footer = dg.footer as ChargeSummaryDepositChargeAnalysis[];
                }
            }
            if (list.Length == 0)
            {
                error = "没有可导出的数据";
                return false;
            }
            DataTable dt = new DataTable();
            dt.Columns.Add("资源位置");
            dt.Columns.Add("房间编号");
            dt.Columns.Add("收费项目");
            dt.Columns.Add("期初余额");
            dt.Columns.Add("本期预收");
            dt.Columns.Add("本期退还");
            dt.Columns.Add("期末余额");
            for (int i = 0; i < list.Length; i++)
            {
                DataRow dr = dt.NewRow();
                dr["资源位置"] = list[i].FullName;
                dr["房间编号"] = list[i].RoomName;
                dr["收费项目"] = list[i].Name;
                dr["期初余额"] = list[i].PreTotalCost <= 0 ? 0 : list[i].PreTotalCost;
                dr["本期预收"] = list[i].Cost <= 0 ? 0 : list[i].Cost;
                dr["本期退还"] = list[i].ChargeReturnCost <= 0 ? 0 : list[i].ChargeReturnCost;
                dr["期末余额"] = list[i].AfterTotalCost <= 0 ? 0 : list[i].AfterTotalCost;
                dt.Rows.Add(dr);
            }
            if (footer.Length > 0)
            {
                DataRow footer_dr = dt.NewRow();
                footer_dr["资源位置"] = "总合计";
                footer_dr["期初余额"] = footer[0].PreTotalCost <= 0 ? 0 : footer[0].PreTotalCost;
                footer_dr["本期预收"] = footer[0].Cost <= 0 ? 0 : footer[0].Cost;
                footer_dr["本期退还"] = footer[0].ChargeReturnCost <= 0 ? 0 : footer[0].ChargeReturnCost;
                footer_dr["期末余额"] = footer[0].AfterTotalCost <= 0 ? 0 : footer[0].AfterTotalCost;
                dt.Rows.Add(footer_dr);
            }
            string FileName = "押金台帐_" + DateTime.Now.ToString("yyyyMMddHHmmss") + "_导入.xls";
            string filepath = "/upload/ExcelExport/ExportFee/";
            downloadurl = DownloadProcess(dt, FileName, filepath);
            return true;
        }
        public static bool DownLoadDoorOpenLog(Foresight.DataAccess.Ui.DataGrid dg, out string downloadurl, out string error)
        {
            downloadurl = string.Empty;
            error = string.Empty;
            var list = dg.rows as Mall_DoorOpenLogDetail[];
            if (list.Length == 0)
            {
                error = "无相关导出数据";
                return false;
            }
            DataTable dt = new DataTable();
            dt.Columns.Add("设备标识");
            dt.Columns.Add("设备名称");
            dt.Columns.Add("开门时间");
            dt.Columns.Add("开门类型");
            for (int i = 0; i < list.Length; i++)
            {
                DataRow dr = dt.NewRow();
                dr["设备标识"] = list[i].DeviceID;
                dr["设备名称"] = list[i].DeviceName;
                dr["开门时间"] = list[i].OpenTimeDesc;
                dr["开门类型"] = list[i].OpenTypeDesc;
                dt.Rows.Add(dr);
            }
            string FileName = "开门日志_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";
            string filepath = "/upload/ExcelExport/ExportFee/";
            downloadurl = DownloadProcess(dt, FileName, filepath);
            return true;
        }
        public static bool DownLoadShouFeiLvSummaryAnalysisData(Foresight.DataAccess.Ui.DataGrid dg, out string downloadurl, out string error)
        {
            error = string.Empty;
            downloadurl = string.Empty;
            var list = dg.rows as List<Dictionary<string, object>>;
            if (dg == null)
            {
                error = "没有可导出的数据";
                return false;
            }
            error = string.Empty;
            downloadurl = string.Empty;
            list = dg.rows as List<Dictionary<string, object>>;
            var FooterRows = dg.footer as List<Dictionary<string, object>>;
            if (list.Count == 0)
            {
                error = "没有可导出的数据";
                return false;
            }
            DataTable dt = new DataTable();
            dt.Columns.Add("FullName");
            dt.Columns.Add("RoomName");
            dt.Columns.Add("RelationName");
            List<NpoiHeadCfg> head_list = new List<NpoiHeadCfg>();
            SaveNpoiHead("资源位置", "FullName", head_list: head_list);
            SaveNpoiHead("房间信息", "RoomName", head_list: head_list);
            SaveNpoiHead("客户名称", "RelationName", head_list: head_list);
            string PageCode = Utility.EnumModel.AnalysisChargeFieldPageCode.ShouFeiLvSummaryAnalysis.ToString();
            var chargesummary_list = Foresight.DataAccess.ChargeSummaryField.GetChargeSummaryFields(PageCode).Where(p => (!p.IsHide && (!p.IsHideReal || !p.IsHideRest || !p.IsHideTotal || !p.IsHideHistoryRoomFee)) || p.ChargeFieldID < 0).OrderBy(p => { return p.SortOrder < 0 ? int.MaxValue : p.SortOrder; }).ToArray();
            if (chargesummary_list.Length == 0)
            {
                error = "请先配置收费项目";
                return false;
            }
            var parent_head_1 = new NpoiHeadCfg();
            for (int i = 0; i < chargesummary_list.Length; i++)
            {
                var item = chargesummary_list[i];
                if (item.IsHideTotal && item.IsHideReal && item.IsHideRest && item.IsHideHistoryRoomFee)
                {
                    continue;
                }
                parent_head_1 = SaveNpoiHead(item.Name, item.Name);
                if (!item.IsHideTotal)
                {
                    SaveNpoiHead("应收", item.ID + "_AllCost", parent_head: parent_head_1);
                    dt.Columns.Add(item.ID + "_AllCost");
                }
                if (!item.IsHideReal)
                {
                    SaveNpoiHead("已收", item.ID + "_RealCost", parent_head: parent_head_1);
                    dt.Columns.Add(item.ID + "_RealCost");
                }
                if (!item.IsHideRest)
                {
                    SaveNpoiHead("未收", item.ID + "_RestCost", parent_head: parent_head_1);
                    dt.Columns.Add(item.ID + "_RestCost");
                }
                if (!item.IsHideHistoryRoomFee)
                {
                    SaveNpoiHead("累计欠费", item.ID + "_HistoryRestCost", parent_head: parent_head_1);
                    dt.Columns.Add(item.ID + "_HistoryRestCost");
                }
                head_list.Add(parent_head_1);
                if (i == chargesummary_list.Length - 1)
                {
                    parent_head_1 = SaveNpoiHead("合计", "合计");
                    SaveNpoiHead("应收", "heji_AllCost", parent_head: parent_head_1);
                    SaveNpoiHead("已收", "heji_RealCost", parent_head: parent_head_1);
                    SaveNpoiHead("未收", "heji_RestCost", parent_head: parent_head_1);
                    SaveNpoiHead("累计欠费", "heji_HistoryRestCost", parent_head: parent_head_1);
                    head_list.Add(parent_head_1);
                    dt.Columns.Add("heji_AllCost");
                    dt.Columns.Add("heji_RealCost");
                    dt.Columns.Add("heji_RestCost");
                    dt.Columns.Add("heji_HistoryRestCost");
                }
            }

            for (int i = 0; i < list.Count; i++)
            {
                var dr = dt.NewRow();
                foreach (var item2 in list[i])
                {
                    if (dt.Columns.Contains(item2.Key))
                    {
                        dr[item2.Key] = item2.Value;
                    }
                }
                dt.Rows.Add(dr);
            }
            foreach (var item in FooterRows)
            {
                var dr = dt.NewRow();
                foreach (var item2 in item)
                {
                    if (dt.Columns.Contains(item2.Key))
                    {
                        dr[item2.Key] = item2.Value;
                    }
                }
                dt.Rows.Add(dr);
            }
            string FileName = "收款情况表_" + DateTime.Now.ToString("yyyyMMddHHmmss") + "_导出.xls";
            string filepath = "/upload/ExcelExport/ExportFee/";
            downloadurl = DownloadProcess(dt, FileName, filepath, heads: head_list);
            return true;
        }
        public static bool DownLoadContractFeeSummaryData(Foresight.DataAccess.Ui.DataGrid dg, string OrderType, out string downloadurl, out string error)
        {
            error = string.Empty;
            downloadurl = string.Empty;
            ViewContractChargeSummary[] list = new ViewContractChargeSummary[] { };
            if (dg != null && dg.rows != null)
            {
                list = dg.rows as ViewContractChargeSummary[];
            }
            if (list.Length == 0)
            {
                error = "没有可导出的数据";
                return false;
            }
            List<CellRangeAddressModel> rangeList = new List<CellRangeAddressModel>();
            decimal TotalCost = 0;
            decimal PayCost = 0;
            decimal RestCost = 0;
            decimal DiscountCost = 0;
            DataTable dt = new DataTable();
            dt.Columns.Add("资源位置");
            dt.Columns.Add("资源编号");
            dt.Columns.Add("合同编号");
            dt.Columns.Add("合同名称");
            dt.Columns.Add("租户姓名");
            dt.Columns.Add("收费项目");
            dt.Columns.Add("计费开始日期");
            dt.Columns.Add("计费结束日期");
            dt.Columns.Add("收费日期");
            dt.Columns.Add("合同应收");
            dt.Columns.Add("已收金额");
            dt.Columns.Add("减免金额");
            dt.Columns.Add("未收金额");
            CellRangeAddressModel model1 = new CellRangeAddressModel();
            CellRangeAddressModel model2 = new CellRangeAddressModel();
            CellRangeAddressModel model3 = new CellRangeAddressModel();
            CellRangeAddressModel model4 = new CellRangeAddressModel();
            CellRangeAddressModel model5 = new CellRangeAddressModel();
            for (int i = 0; i < list.Length; i++)
            {
                if (i == 0)
                {

                    model1 = new CellRangeAddressModel();
                    model1.FirstRow = (i + 1);
                    model2 = new CellRangeAddressModel();
                    model2.FirstRow = (i + 1);
                    model3 = new CellRangeAddressModel();
                    model3.FirstRow = (i + 1);
                    model4 = new CellRangeAddressModel();
                    model4.FirstRow = (i + 1);
                    model5 = new CellRangeAddressModel();
                    model5.FirstRow = (i + 1);
                }
                DataRow dr = dt.NewRow();
                dr["资源位置"] = list[i].FullName;
                dr["资源编号"] = list[i].Name;
                dr["合同编号"] = list[i].ContractNo;
                dr["合同名称"] = list[i].ContractName;
                dr["租户姓名"] = list[i].RentName;
                dr["收费项目"] = list[i].ChargeName;
                dr["计费开始日期"] = list[i].CalculateStartTime > DateTime.MinValue ? list[i].CalculateStartTime.ToString("yyyy-MM-dd") : "";
                dr["计费结束日期"] = list[i].CalculateEndTime > DateTime.MinValue ? list[i].CalculateEndTime.ToString("yyyy-MM-dd") : "";
                dr["收费日期"] = list[i].ReadyChargeTime > DateTime.MinValue ? list[i].ReadyChargeTime.ToString("yyyy-MM-dd") : "";
                dr["合同应收"] = list[i].CalcualteTotalCost > 0 ? list[i].CalcualteTotalCost.ToString() : "";
                dr["已收金额"] = list[i].CalcualtePayCost > 0 ? list[i].CalcualtePayCost.ToString() : "";
                dr["减免金额"] = list[i].CalcualteDiscount > 0 ? list[i].CalcualteDiscount.ToString() : "";
                dr["未收金额"] = list[i].CalcualteRestCost > 0 ? list[i].CalcualteRestCost.ToString() : "";
                dt.Rows.Add(dr);
                TotalCost += (list[i].CalcualteTotalCost > 0 ? list[i].CalcualteTotalCost : 0);
                PayCost += (list[i].CalcualtePayCost > 0 ? list[i].CalcualtePayCost : 0);
                RestCost += (list[i].CalcualteRestCost > 0 ? list[i].CalcualteRestCost : 0);
                DiscountCost += (list[i].CalcualteDiscount > 0 ? list[i].CalcualteDiscount : 0);
                if (i == list.Length - 1)
                {
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
                    if (model4.IsUse)
                    {
                        rangeList.Add(model4);
                    }
                    if (model5.IsUse)
                    {
                        rangeList.Add(model5);
                    }
                }
                if (i < list.Length - 1)
                {
                    if (OrderType.Equals("Project"))
                    {
                        if (list[i].RoomID == list[i + 1].RoomID)
                        {
                            if (dt.Columns["资源位置"] != null)
                            {
                                model1.IsUse = true;
                                model1.LastRow = (i + 2);
                                model1.FirstCol = dt.Columns["资源位置"].Ordinal;
                                model1.LastCol = dt.Columns["资源位置"].Ordinal;
                            }
                        }
                        else
                        {
                            if (model1.IsUse)
                            {
                                rangeList.Add(model1);
                            }
                            model1 = new CellRangeAddressModel();
                            model1.FirstRow = (i + 2);
                        }
                    }
                    else
                    {
                        if (list[i].ContractID == list[i + 1].ContractID)
                        {
                            if (dt.Columns["资源位置"] != null)
                            {
                                model1.IsUse = true;
                                model1.LastRow = (i + 2);
                                model1.FirstCol = dt.Columns["资源位置"].Ordinal;
                                model1.LastCol = dt.Columns["资源位置"].Ordinal;
                            }
                            if (dt.Columns["资源编号"] != null)
                            {
                                model2.IsUse = true;
                                model2.LastRow = (i + 2);
                                model2.FirstCol = dt.Columns["资源编号"].Ordinal;
                                model2.LastCol = dt.Columns["资源编号"].Ordinal;
                            }
                            if (dt.Columns["合同编号"] != null)
                            {
                                model3.IsUse = true;
                                model3.LastRow = (i + 2);
                                model3.FirstCol = dt.Columns["合同编号"].Ordinal;
                                model3.LastCol = dt.Columns["合同编号"].Ordinal;
                            }
                            if (dt.Columns["合同名称"] != null)
                            {
                                model4.IsUse = true;
                                model4.LastRow = (i + 2);
                                model4.FirstCol = dt.Columns["合同名称"].Ordinal;
                                model4.LastCol = dt.Columns["合同名称"].Ordinal;
                            }
                            if (dt.Columns["租户姓名"] != null)
                            {
                                model5.IsUse = true;
                                model5.LastRow = (i + 2);
                                model5.FirstCol = dt.Columns["租户姓名"].Ordinal;
                                model5.LastCol = dt.Columns["租户姓名"].Ordinal;
                            }
                        }
                        else
                        {
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
                            if (model4.IsUse)
                            {
                                rangeList.Add(model4);
                            }
                            if (model5.IsUse)
                            {
                                rangeList.Add(model5);
                            }
                            model1 = new CellRangeAddressModel();
                            model1.FirstRow = (i + 2);
                            model2 = new CellRangeAddressModel();
                            model2.FirstRow = (i + 2);
                            model3 = new CellRangeAddressModel();
                            model3.FirstRow = (i + 2);
                            model4 = new CellRangeAddressModel();
                            model4.FirstRow = (i + 2);
                            model5 = new CellRangeAddressModel();
                            model5.FirstRow = (i + 2);
                        }
                    }
                }
            }
            DataRow totaldr = dt.NewRow();
            totaldr["合同编号"] = "合计";
            totaldr["合同应收"] = TotalCost;
            totaldr["已收金额"] = PayCost;
            totaldr["减免金额"] = DiscountCost;
            totaldr["未收金额"] = RestCost;
            dt.Rows.Add(totaldr);
            string FileName = "合同账单_" + DateTime.Now.ToString("yyyyMMddHHmmss") + "_导入.xls";
            string filepath = "/upload/ExcelExport/ExportFee/";
            downloadurl = DownloadProcess(dt, FileName, filepath, rangeList: rangeList);
            return true;
        }
        public static bool DownLoadRoomSourceData(Foresight.DataAccess.Ui.DataGrid dg, out string downloadurl, out string error)
        {
            error = string.Empty;
            downloadurl = string.Empty;
            string PageCode = "roomsource";
            string TableName = Utility.EnumModel.DefineFieldTableName.RoomBasic.ToString();
            var list = dg.rows as List<Dictionary<string, object>>;
            if (list.Count == 0)
            {
                error = "没有可导出的数据";
                return false;
            }
            var fieldlist = Foresight.DataAccess.DefineField.GetDefineFieldsByTable_Name(TableName).Where(p => p.IsShown).ToArray();
            int MinRoomID = list.Min(p => Convert.ToInt32(p["RoomID"]));
            int MaxRoomID = list.Max(p => Convert.ToInt32(p["RoomID"]));
            var contentlist = Foresight.DataAccess.RoomBasicField.GetRoomBasicFieldsByRoomIDList(MinRoomID, MaxRoomID);
            var titleList = GetTableColumns(PageCode, TableName: TableName);
            DataTable dt = new DataTable();
            dt.Columns.Add("资源ID");
            foreach (var item in titleList)
            {
                if (!dt.Columns.Contains(item["ColumnName"].ToString()))
                {
                    dt.Columns.Add(item["ColumnName"].ToString());
                }
            }
            string[] new_add_columns = new string[] { "默认联系人", "缴费人员", "缴费对象" };
            foreach (var item in new_add_columns)
            {
                if (!dt.Columns.Contains(item))
                {
                    dt.Columns.Add(item);
                }
            }
            var comHelper = new APPCode.CommHelper();
            for (int i = 0; i < list.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr["资源ID"] = list[i]["RoomID"];
                SetDrValue(titleList, dr, "资源位置", list[i]["FullName"] + "|" + list[i]["Name"]);
                SetDrValue(titleList, dr, "房间编号", list[i]["Name"]);
                SetDrValue(titleList, dr, "房间状态", list[i]["RoomStateName"]);
                decimal BuildingArea = WebUtil.GetDecimalByObj(list[i], "BuildingArea");
                SetDrValue(titleList, dr, comHelper.GetExistColumns(TableName, "BuildingArea"), BuildingArea);
                decimal ContractArea = WebUtil.GetDecimalByObj(list[i], "ContractArea");
                SetDrValue(titleList, dr, comHelper.GetExistColumns(TableName, "ContractArea"), ContractArea);
                DateTime PaymentTime = WebUtil.GetDateTimeByObj(list[i], "PaymentTime");
                SetDrValue(titleList, dr, "交房日期", WebUtil.GetStrDate(PaymentTime));
                DateTime MoveInTime = WebUtil.GetDateTimeByObj(list[i], "MoveInTime");
                SetDrValue(titleList, dr, "入住日期", WebUtil.GetStrDate(MoveInTime));
                DateTime ZxStartTime = WebUtil.GetDateTimeByObj(list[i], "ZxStartTime");
                SetDrValue(titleList, dr, "装修开始时间", WebUtil.GetStrDate(ZxStartTime));
                DateTime ZxEndTime = WebUtil.GetDateTimeByObj(list[i], "ZxEndTime");
                SetDrValue(titleList, dr, "装修验收时间", WebUtil.GetStrDate(ZxEndTime));
                SetDrValue(titleList, dr, "户型", list[i]["RoomLayout"]);
                SetDrValue(titleList, dr, "期数", list[i]["BuildingNumber"]);
                decimal BuildOutArea = WebUtil.GetDecimalByObj(list[i], "BuildOutArea");
                SetDrValue(titleList, dr, comHelper.GetExistColumns(TableName, "BuildOutArea"), BuildOutArea);
                decimal BuildInArea = WebUtil.GetDecimalByObj(list[i], "BuildInArea");
                SetDrValue(titleList, dr, comHelper.GetExistColumns(TableName, "BuildInArea"), BuildInArea);
                SetDrValue(titleList, dr, comHelper.GetExistColumns(TableName, "GonTanArea"), WebUtil.GetDecimalByObj(list[i], "GonTanArea"));
                SetDrValue(titleList, dr, comHelper.GetExistColumns(TableName, "ChanQuanArea"), WebUtil.GetDecimalByObj(list[i], "ChanQuanArea"));
                SetDrValue(titleList, dr, comHelper.GetExistColumns(TableName, "UseArea"), WebUtil.GetDecimalByObj(list[i], "UseArea"));
                SetDrValue(titleList, dr, comHelper.GetExistColumns(TableName, "PeiTaoArea"), WebUtil.GetDecimalByObj(list[i], "PeiTaoArea"));
                SetDrValue(titleList, dr, "功能系数", WebUtil.GetDecimalByObj(list[i], "FunctionCoefficient"));
                SetDrValue(titleList, dr, "分摊系数", WebUtil.GetDecimalByObj(list[i], "FenTanCoefficient"));
                SetDrValue(titleList, dr, "产权证号", list[i]["ChanQuanNo"]);
                DateTime CertificateTime = WebUtil.GetDateTimeByObj(list[i], "CertificateTime");
                SetDrValue(titleList, dr, "发证日期", WebUtil.GetStrDate(CertificateTime));
                SetDrValue(titleList, dr, "房间类型", list[i]["RoomTypeName"]);
                SetDrValue(titleList, dr, "房源属性", list[i]["RoomPropertyName"]);
                SetDrValue(titleList, dr, "自定义一", list[i]["CustomOne"]);
                SetDrValue(titleList, dr, "自定义二", list[i]["CustomTwo"]);
                SetDrValue(titleList, dr, "自定义三", list[i]["CustomThree"]);
                SetDrValue(titleList, dr, "自定义四", list[i]["CustomFour"]);
                SetDrValue(titleList, dr, "住户标签", (string.IsNullOrEmpty(list[i]["RelationTypeDesc"].ToString()) ? "业主" : list[i]["RelationTypeDesc"]));
                SetDrValue(titleList, dr, "住户类别", list[i]["RelationPropertyDesc"]);
                SetDrValue(titleList, dr, "公司名称", list[i]["CompanyName"]);
                SetDrValue(titleList, dr, "住户姓名", list[i]["RelationName"]);
                SetDrValue(titleList, dr, "联系方式", list[i]["RelatePhoneNumber"]);
                SetDrValue(titleList, dr, "是否激活", list[i]["IsLockedDesc"]);
                SetDrValue(titleList, dr, "证件类型", list[i]["IDCardTypeDesc"]);
                SetDrValue(titleList, dr, "证件号码", list[i]["RelationIDCard"]);

                DateTime Birthday = WebUtil.GetDateTimeByObj(list[i], "Birthday");
                SetDrValue(titleList, dr, "出生日期", WebUtil.GetStrDate(Birthday));
                SetDrValue(titleList, dr, "电子信箱", list[i]["EmailAddress"]);
                SetDrValue(titleList, dr, "联系地址", list[i]["HomeAddress"]);
                SetDrValue(titleList, dr, "工作单位", list[i]["OfficeAddress"]);
                SetDrValue(titleList, dr, "开户银行", list[i]["BankName"]);
                SetDrValue(titleList, dr, "开户名称", list[i]["BankAccountName"]);

                DateTime ContractStartTime = WebUtil.GetDateTimeByObj(list[i], "ContractStartTime");
                SetDrValue(titleList, dr, "合同开始日期", WebUtil.GetStrDate(ContractStartTime));
                DateTime ContractEndTime = WebUtil.GetDateTimeByObj(list[i], "ContractEndTime");
                SetDrValue(titleList, dr, "合同结束日期", WebUtil.GetStrDate(ContractEndTime));
                SetDrValue(titleList, dr, "业主自定义一", list[i]["RelateCustomOne"]);
                SetDrValue(titleList, dr, "业主自定义二", list[i]["RelateCustomTwo"]);
                SetDrValue(titleList, dr, "业主自定义三", list[i]["RelateCustomThree"]);
                SetDrValue(titleList, dr, "业主自定义四", list[i]["RelateCustomFour"]);
                SetDrValue(titleList, dr, "性格爱好", list[i]["Interesting"]);
                SetDrValue(titleList, dr, "消费倾向", list[i]["ConsumeMore"]);
                SetDrValue(titleList, dr, "所属部门", list[i]["BelongTeam"]);
                SetDrValue(titleList, dr, "一卡通号", list[i]["OneCardNumber"]);
                SetDrValue(titleList, dr, "代扣对象", list[i]["ChargeForMan"]);
                SetDrValue(titleList, dr, "默认联系人", list[i]["IsDefaultDesc"]);
                SetDrValue(titleList, dr, "缴费人员", list[i]["IsChargeFeeDesc"]);
                SetDrValue(titleList, dr, "缴费对象", list[i]["IsChargeManDesc"]);
                SetDrValue(titleList, dr, "默认排序", list[i]["DefaultOrder"]);
                SetDrValue(titleList, dr, "资源备注", list[i]["RoomBasicRemark"]);
                SetDrValue(titleList, dr, "客户备注", list[i]["RoomPhoneRelationRemark"]);
                SetDrValue(titleList, dr, comHelper.GetExistColumns(TableName, "CustomOne"), list[i]["RelateCustomOne"]);
                SetDrValue(titleList, dr, comHelper.GetExistColumns(TableName, "CustomTwo"), list[i]["RelateCustomTwo"]);
                SetDrValue(titleList, dr, comHelper.GetExistColumns(TableName, "CustomThree"), list[i]["RelateCustomThree"]);
                SetDrValue(titleList, dr, comHelper.GetExistColumns(TableName, "CustomFour"), list[i]["CustomFour"]);
                SetDrValue(titleList, dr, comHelper.GetExistColumns(TableName, "Interesting"), list[i]["Interesting"]);
                SetDrValue(titleList, dr, comHelper.GetExistColumns(TableName, "ConsumeMore"), list[i]["ConsumeMore"]);
                SetDrValue(titleList, dr, comHelper.GetExistColumns(TableName, "OneCardNumber"), list[i]["OneCardNumber"]);
                SetDrValue(titleList, dr, comHelper.GetExistColumns(TableName, "ChargeForMan"), list[i]["ChargeForMan"]);
                if (fieldlist.Length > 0)
                {
                    foreach (var item in fieldlist)
                    {
                        var contentmodel = contentlist.FirstOrDefault(q => q.FieldID == item.ID && q.RoomID == Convert.ToInt32(list[i]["RoomID"]));
                        SetDrValue(titleList, dr, item.FieldName, contentmodel == null ? "" : contentmodel.FieldContent);
                    }
                }
                dt.Rows.Add(dr);
            }
            string FileName = "资源信息_" + DateTime.Now.ToString("yyyyMMddHHmmss") + "_导出.xls";
            string filepath = "/upload/ExcelExport/ExportFee/";
            downloadurl = DownloadProcess(dt, FileName, filepath);
            return true;
        }
        public static bool DownLoadMeterProjectPointData(Foresight.DataAccess.Ui.DataGrid dg, out string downloadurl, out string error)
        {
            downloadurl = string.Empty;
            error = string.Empty;
            var list = dg.rows as ChargeMeter_Project_PointDetail[];
            if (list.Length == 0)
            {
                error = "无相关导出数据";
                return false;
            }
            DataTable dt = new DataTable();
            dt.Columns.Add("资源编号");
            dt.Columns.Add("仪表名称");
            dt.Columns.Add("仪表类型");
            dt.Columns.Add("仪表编号");
            dt.Columns.Add("上次读数");
            dt.Columns.Add("本次读数");
            dt.Columns.Add("抄表日期");
            dt.Columns.Add("抄表人");
            dt.Columns.Add("收费项目");
            dt.Columns.Add("仪表种类");
            dt.Columns.Add("仪表规格");
            dt.Columns.Add("用量");
            dt.Columns.Add("倍率");
            dt.Columns.Add("缴费户号");
            dt.Columns.Add("仪表位置");
            for (int i = 0; i < list.Length; i++)
            {
                DataRow dr = dt.NewRow();
                dr["仪表ID"] = list[i].ID;
                dr["资源编号"] = list[i].FinalFullName;
                dr["仪表名称"] = list[i].MeterName;
                dr["仪表编号"] = list[i].MeterNumber;
                dr["上次读数"] = list[i].MeterStartPoint;
                dr["本次读数"] = list[i].MeterEndPoint;
                dr["抄表日期"] = list[i].WriteDate;
                dr["抄表人"] = list[i].WriteUserName;
                dr["收费项目"] = list[i].FinalChargeName;
                dr["仪表种类"] = list[i].MeterCategoryName;
                dr["仪表类型"] = list[i].MeterTypeName;
                dr["仪表规格"] = list[i].MeterSpecDesc;
                dr["倍率"] = list[i].MeterCoefficient > 0 ? list[i].MeterCoefficient : 0;
                dr["缴费户号"] = list[i].MeterHouseNo;
                dr["仪表位置"] = list[i].MeterLocation;
                dt.Rows.Add(dr);
            }
            string FileName = "抄表记录_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";
            string filepath = "/upload/ExcelExport/ExportFee/";
            downloadurl = DownloadProcess(dt, FileName, filepath);
            return true;
        }
        public static bool DownLoadMonthFeeAnalysisData(Foresight.DataAccess.Ui.DataGrid dg, out string downloadurl, out string error)
        {
            error = string.Empty;
            downloadurl = string.Empty;
            List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
            List<Dictionary<string, object>> FooterRows = new List<Dictionary<string, object>>();
            if (dg != null)
            {
                list = dg.rows as List<Dictionary<string, object>>;
                if (dg.footer != null)
                {
                    FooterRows = dg.footer as List<Dictionary<string, object>>;
                }
            }
            if (list.Count == 0)
            {
                error = "没有可导出的数据";
                return false;
            }
            var rangeList = new List<CellRangeAddressModel>();
            CellRangeAddressModel model1 = new CellRangeAddressModel();
            CellRangeAddressModel model2 = new CellRangeAddressModel();
            CellRangeAddressModel model3 = new CellRangeAddressModel();
            List<NpoiHeadCfg> head_list = new List<NpoiHeadCfg>();
            SaveNpoiHead("资源位置", "FullName", head_list: head_list);
            SaveNpoiHead("资源编号", "RoomName", head_list: head_list);
            SaveNpoiHead("客户信息", "DefaultChargeManName", head_list: head_list);
            SaveNpoiHead("收费项目", "Name", head_list: head_list);
            DataTable dt = new DataTable();
            dt.Columns.Add("FullName");
            dt.Columns.Add("RoomName");
            dt.Columns.Add("DefaultChargeManName");
            dt.Columns.Add("Name");
            var parent_head_1 = new NpoiHeadCfg();
            var parent_head_1_1 = new NpoiHeadCfg();
            for (int i = 1; i < 13; i++)
            {
                parent_head_1 = SaveNpoiHead(i.ToString() + "月份", i.ToString() + "月份");
                SaveNpoiHead("应收", i + "_YingShou", parent_head: parent_head_1);
                SaveNpoiHead("实收", i + "_YingShou", parent_head: parent_head_1);
                SaveNpoiHead("冲抵", i + "_ChongDi", parent_head: parent_head_1);
                SaveNpoiHead("减免", i + "_JianMian", parent_head: parent_head_1);
                SaveNpoiHead("未收", i + "_WeiShou", parent_head: parent_head_1);
                head_list.Add(parent_head_1);
                dt.Columns.Add(i + "_YingShou");
                dt.Columns.Add(i + "_YiShou");
                dt.Columns.Add(i + "_ChongDi");
                dt.Columns.Add(i + "_JianMian");
                dt.Columns.Add(i + "_WeiShou");
            }
            parent_head_1 = SaveNpoiHead("合计", "合计");
            SaveNpoiHead("累计应收", "Heji_YingShou", parent_head: parent_head_1);
            SaveNpoiHead("累计实收", "Heji_YiShou", parent_head: parent_head_1);
            SaveNpoiHead("累计冲抵", "Heji_ChongDi", parent_head: parent_head_1);
            SaveNpoiHead("累计减免", "Heji_JianMian", parent_head: parent_head_1);
            SaveNpoiHead("累计未收", "Heji_WeiShou", parent_head: parent_head_1);
            head_list.Add(parent_head_1);
            dt.Columns.Add("Heji_YingShou");
            dt.Columns.Add("Heji_YiShou");
            dt.Columns.Add("Heji_ChongDi");
            dt.Columns.Add("Heji_JianMian");
            dt.Columns.Add("Heji_WeiShou");
            dt.Columns.Add("Heji_LiShiQianFei");
            for (int i = 0; i < list.Count; i++)
            {
                if (i == 0)
                {

                    model1 = new CellRangeAddressModel();
                    model1.FirstRow = (i + 2);
                    model2 = new CellRangeAddressModel();
                    model2.FirstRow = (i + 2);
                    model3 = new CellRangeAddressModel();
                    model3.FirstRow = (i + 2);
                }
                var dr = dt.NewRow();
                foreach (var item2 in list[i])
                {
                    if (dt.Columns.Contains(item2.Key))
                    {
                        dr[item2.Key] = item2.Value;
                    }
                }
                dt.Rows.Add(dr);
                if (i == list.Count - 1)
                {
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
                if (i < list.Count - 1)
                {
                    if (Convert.ToInt32(list[i]["RoomID"]) == Convert.ToInt32(list[i + 1]["RoomID"]))
                    {
                        if (dt.Columns["FullName"] != null)
                        {
                            model1.IsUse = true;
                            model1.LastRow = (i + 3);
                            model1.FirstCol = dt.Columns["FullName"].Ordinal;
                            model1.LastCol = dt.Columns["FullName"].Ordinal;
                        }
                        if (dt.Columns["RoomName"] != null)
                        {
                            model2.IsUse = true;
                            model2.LastRow = (i + 3);
                            model2.FirstCol = dt.Columns["RoomName"].Ordinal;
                            model2.LastCol = dt.Columns["RoomName"].Ordinal;
                        }
                        if (dt.Columns["DefaultChargeManName"] != null)
                        {
                            model3.IsUse = true;
                            model3.LastRow = (i + 3);
                            model3.FirstCol = dt.Columns["DefaultChargeManName"].Ordinal;
                            model3.LastCol = dt.Columns["DefaultChargeManName"].Ordinal;
                        }
                    }
                    else
                    {
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
                        model1 = new CellRangeAddressModel();
                        model1.FirstRow = (i + 3);
                        model2 = new CellRangeAddressModel();
                        model2.FirstRow = (i + 3);
                        model3 = new CellRangeAddressModel();
                        model3.FirstRow = (i + 3);
                    }
                }
            }
            foreach (var item in FooterRows)
            {
                var dr = dt.NewRow();
                foreach (var item2 in item)
                {
                    if (dt.Columns.Contains(item2.Key))
                    {
                        dr[item2.Key] = item2.Value;
                    }
                }
                dt.Rows.Add(dr);
            }
            string FileName = "月度报表_" + DateTime.Now.ToString("yyyyMMddHHmmss") + "_导出.xls";
            string filepath = "/upload/ExcelExport/ExportFee/";
            downloadurl = DownloadProcess(dt, FileName, filepath, rangeList: rangeList, heads: head_list);
            return true;
        }
        public static bool DownLoadToCuiKuanDetailsListData(Foresight.DataAccess.Ui.DataGrid dg, out string downloadurl, out string error)
        {
            error = string.Empty;
            downloadurl = string.Empty;
            ViewRoomFeeHistory[] list = new ViewRoomFeeHistory[] { };
            ViewRoomFeeHistory[] FooterRows = new ViewRoomFeeHistory[] { };
            if (dg != null)
            {
                list = dg.rows as ViewRoomFeeHistory[];
                if (dg.footer != null)
                {
                    FooterRows = dg.footer as ViewRoomFeeHistory[];
                }
            }
            if (list.Length == 0)
            {
                error = "没有可导出的数据";
                return false;
            }
            string PageCode = "cuikuanfeehistory";
            var titleList = GetTableColumns(PageCode);
            DataTable dt = new DataTable();
            foreach (var item in titleList)
            {
                if (!dt.Columns.Contains(item["ColumnName"].ToString()))
                {
                    dt.Columns.Add(item["ColumnName"].ToString());
                }
            }
            List<CellRangeAddressModel> rangeList = new List<CellRangeAddressModel>();
            CellRangeAddressModel model1 = new CellRangeAddressModel();
            CellRangeAddressModel model2 = new CellRangeAddressModel();
            CellRangeAddressModel model3 = new CellRangeAddressModel();
            CellRangeAddressModel model4 = new CellRangeAddressModel();
            CellRangeAddressModel model5 = new CellRangeAddressModel();
            for (int i = 0; i < list.Length; i++)
            {
                if (i == 0)
                {
                    model1 = new CellRangeAddressModel();
                    model1.FirstRow = (i + 1);
                    model2 = new CellRangeAddressModel();
                    model2.FirstRow = (i + 1);
                    model3 = new CellRangeAddressModel();
                    model3.FirstRow = (i + 1);
                    model4 = new CellRangeAddressModel();
                    model4.FirstRow = (i + 1);
                    model5 = new CellRangeAddressModel();
                    model5.FirstRow = (i + 1);
                }
                DataRow dr = dt.NewRow();
                SetDrValue(titleList, dr, "收款单号", list[i].PrintNumber);
                SetDrValue(titleList, dr, "单据状态", list[i].ChargeStateDesc);
                SetDrValue(titleList, dr, "收款人", list[i].ChargeMan);
                SetDrValue(titleList, dr, "收款日期", (list[i].ChargeTime == DateTime.MinValue ? "" : list[i].ChargeTime.ToString("yyyy-MM-dd")));
                SetDrValue(titleList, dr, "房号", list[i].RoomName);
                SetDrValue(titleList, dr, "收费项目", list[i].ChargeName);
                SetDrValue(titleList, dr, "费项分类", GetChargeTypeName(list[i].CategoryID));
                SetDrValue(titleList, dr, "计费开始日期", (list[i].StartTime == DateTime.MinValue ? "" : list[i].StartTime.ToString("yyyy-MM-dd")));
                SetDrValue(titleList, dr, "计费结束日期", (list[i].EndTime == DateTime.MinValue ? "" : list[i].EndTime.ToString("yyyy-MM-dd")));
                SetDrValue(titleList, dr, "单价", (list[i].UnitPrice == decimal.MinValue ? "0" : list[i].FormatUnitPrice));
                SetDrValue(titleList, dr, "面积/用量", (list[i].UseCount == decimal.MinValue ? 0 : list[i].UseCount));
                decimal RealCost = 0;
                decimal SumRealCost = 0;
                if (list[i].ChargeState == 3)
                {
                    RealCost = list[i].RealCost == decimal.MinValue ? 0 : -list[i].RealCost;
                    SumRealCost = list[i].SumRealCost == decimal.MinValue ? 0 : -list[i].SumRealCost;
                }
                else
                {
                    RealCost = list[i].RealCost == decimal.MinValue ? 0 : list[i].RealCost;
                    SumRealCost = list[i].SumRealCost == decimal.MinValue ? 0 : list[i].SumRealCost;
                }
                SetDrValue(titleList, dr, "实收金额", RealCost);
                SetDrValue(titleList, dr, "实收合计", SumRealCost);
                SetDrValue(titleList, dr, "减免金额", (list[i].Discount == decimal.MinValue ? 0 : list[i].Discount));
                SetDrValue(titleList, dr, "上次读数", list[i].FinalStartPoint);
                SetDrValue(titleList, dr, "本次读数", list[i].FinalEndPoint);
                SetDrValue(titleList, dr, "本次用量", (list[i].UseCount == decimal.MinValue ? 0 : list[i].UseCount));
                SetDrValue(titleList, dr, "备注", list[i].Remark);
                SetDrValue(titleList, dr, "业主名称", list[i].RelationName);
                SetDrValue(titleList, dr, "联系方式", list[i].RelatePhoneNumber);
                SetDrValue(titleList, dr, "代扣对象", list[i].ChargeForMan);
                SetDrValue(titleList, dr, "一卡通号", list[i].OneCardNumber);
                SetDrValue(titleList, dr, "身份证号", list[i].RelationIDCard);
                SetDrValue(titleList, dr, "身份证号", list[i].RelationIDCard);
                SetDrValue(titleList, dr, "资源位置", list[i].FullName);
                SetDrValue(titleList, dr, "银行卡号", list[i].BankAccountNo);
                SetDrValue(titleList, dr, "住址", list[i].HomeAddress);
                SetDrValue(titleList, dr, "部门", list[i].BelongTeam);
                SetDrValue(titleList, dr, "功能系数", list[i].FunctionCoefficient);
                dt.Rows.Add(dr);
                if (i == list.Length - 1)
                {
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
                    if (model4.IsUse)
                    {
                        rangeList.Add(model4);
                    }
                    if (model5.IsUse)
                    {
                        rangeList.Add(model5);
                    }
                }
                if (i < list.Length - 1)
                {
                    if (list[i].PrintNumber.Equals(list[i + 1].PrintNumber) && !string.IsNullOrEmpty(list[i].PrintNumber))
                    {

                        if (dt.Columns["收款单号"] != null)
                        {
                            model1.IsUse = true;
                            model1.LastRow = (i + 2);
                            model1.FirstCol = dt.Columns["收款单号"].Ordinal;
                            model1.LastCol = dt.Columns["收款单号"].Ordinal;
                        }
                        if (dt.Columns["单据状态"] != null)
                        {
                            model2.IsUse = true;
                            model2.LastRow = (i + 2);
                            model2.FirstCol = dt.Columns["单据状态"].Ordinal;
                            model2.LastCol = dt.Columns["单据状态"].Ordinal;
                        }
                        if (dt.Columns["收款人"] != null)
                        {
                            model3.IsUse = true;
                            model3.LastRow = (i + 2);
                            model3.FirstCol = dt.Columns["收款人"].Ordinal;
                            model3.LastCol = dt.Columns["收款人"].Ordinal;
                        }
                        if (dt.Columns["收款日期"] != null)
                        {
                            model4.IsUse = true;
                            model4.LastRow = (i + 2);
                            model4.FirstCol = dt.Columns["收款日期"].Ordinal;
                            model4.LastCol = dt.Columns["收款日期"].Ordinal;
                        }
                        if (dt.Columns["实收合计"] != null)
                        {
                            model5.IsUse = true;
                            model5.LastRow = (i + 2);
                            model5.FirstCol = dt.Columns["实收合计"].Ordinal;
                            model5.LastCol = dt.Columns["实收合计"].Ordinal;
                        }
                    }
                    else
                    {
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
                        if (model4.IsUse)
                        {
                            rangeList.Add(model4);
                        }
                        if (model5.IsUse)
                        {
                            rangeList.Add(model5);
                        }
                        model1 = new CellRangeAddressModel();
                        model1.FirstRow = (i + 2);
                        model2 = new CellRangeAddressModel();
                        model2.FirstRow = (i + 2);
                        model3 = new CellRangeAddressModel();
                        model3.FirstRow = (i + 2);
                        model4 = new CellRangeAddressModel();
                        model4.FirstRow = (i + 2);
                        model5 = new CellRangeAddressModel();
                        model5.FirstRow = (i + 2);
                    }
                }
            }
            DataRow footer_dr = dt.NewRow();
            if (dt.Columns.Contains("面积/用量"))
            {
                footer_dr["面积/用量"] = FooterRows[0].UseCount <= 0 ? 0 : FooterRows[0].UseCount;
            }
            if (dt.Columns.Contains("实收合计"))
            {
                footer_dr["实收合计"] = FooterRows[0].SumRealCost <= 0 ? 0 : FooterRows[0].SumRealCost;
            }
            if (dt.Columns.Contains("实收金额"))
            {
                footer_dr["实收金额"] = FooterRows[0].RealCost <= 0 ? 0 : FooterRows[0].RealCost;
            }
            dt.Rows.Add(footer_dr);
            string FileName = "催收单据_" + DateTime.Now.ToString("yyyyMMddHHmmss") + "_导入.xls";
            string filepath = "/upload/ExcelExport/ExportFee/";
            downloadurl = DownloadProcess(dt, FileName, filepath, rangeList: rangeList);
            return true;
        }
        public static bool DownLoadToCuiKuanDetailsDaiKouListData(Foresight.DataAccess.Ui.DataGrid dg, out string downloadurl, out string error)
        {
            error = string.Empty;
            downloadurl = string.Empty;
            ViewRoomFeeHistory[] list = new ViewRoomFeeHistory[] { };
            ViewRoomFeeHistory[] FooterRows = new ViewRoomFeeHistory[] { };
            if (dg != null)
            {
                list = dg.rows as ViewRoomFeeHistory[];
                if (dg.footer != null)
                {
                    FooterRows = dg.footer as ViewRoomFeeHistory[];
                }
            }
            if (list.Length == 0)
            {
                error = "没有可导出的数据";
                return false;
            }
            list = list.Where(p => p.ChargeState == 5).ToArray();
            var RoomIDList = list.Select(p => p.RoomID).ToList();
            var view_roombasic_list = Foresight.DataAccess.ViewRoomBasic.GetViewRoomBasicByRoomIDList(RoomIDList).Where(p => p.RoomPropertyName.Equals("代扣")).ToArray();
            if (view_roombasic_list.Length == 0)
            {
                error = "没有可导出的数据";
                return false;
            }
            DataTable dt = new DataTable();
            dt.Columns.Add("业主/租户");
            dt.Columns.Add("代扣年月");
            dt.Columns.Add("身份证号");
            dt.Columns.Add("一卡通号");
            dt.Columns.Add("代扣金额");
            decimal totalCount = 0;
            var view_roombasic_sub_list = (from t in view_roombasic_list
                                           group t by new { t.RelationName, t.RelationIDCard, t.OneCardNumber } into g
                                           select new
                                           {
                                               RelationName = g.Key.RelationName,
                                               RelationIDCard = g.Key.RelationIDCard,
                                               OneCardNumber = g.Key.OneCardNumber,
                                           }).ToArray();
            foreach (var roomitem in view_roombasic_sub_list)
            {
                var history_list = list.Where(p => p.RelationIDCard == roomitem.RelationIDCard).ToArray();
                var fina_list = history_list.GroupBy(a => a.ChargeTime.ToString("yyyy-MM")).Select(g => (new { name = g.Key, count = g.Count(), total = g.Sum(item => item.RealCost) }));
                foreach (var item in fina_list)
                {
                    DataRow dr = dt.NewRow();
                    dr["业主/租户"] = roomitem.RelationName;
                    dr["身份证号"] = roomitem.RelationIDCard;
                    dr["一卡通号"] = roomitem.OneCardNumber;
                    dr["代扣年月"] = item.name;
                    dr["代扣金额"] = item.total;
                    totalCount += item.total;
                    dt.Rows.Add(dr);
                }
            }
            DataRow totaldr = dt.NewRow();
            totaldr[0] = "总合计";
            totaldr["代扣金额"] = totalCount;
            dt.Rows.Add(totaldr);
            string FileName = "代扣单_" + DateTime.Now.ToString("yyyyMMddHHmmss") + "_导入.xls";
            string filepath = "/upload/ExcelExport/ExportFee/";
            downloadurl = DownloadProcess(dt, FileName, filepath);
            return true;
        }
        private static string GetChargeTypeName(int CategoryID)
        {
            string name = string.Empty;
            switch (CategoryID)
            {
                case 1:
                    name = "收入";
                    break;
                case 2:
                    name = "代收";
                    break;
                case 3:
                    name = "押金";
                    break;
                case 4:
                    name = "预收";
                    break;
                default:
                    break;
            }
            return name;
        }
        public static bool DownLoadChaoBiaCostAnalysisData(Foresight.DataAccess.Ui.DataGrid dg, out string downloadurl, out string error)
        {
            error = string.Empty;
            downloadurl = string.Empty;

            ViewImportFeeDetail[] list = dg.rows as ViewImportFeeDetail[];
            ViewImportFeeDetail[] footer = dg.footer as ViewImportFeeDetail[];
            if (dg != null)
            {
                list = dg.rows as ViewImportFeeDetail[];
                footer = dg.footer as ViewImportFeeDetail[];
            }
            if (list.Length == 0)
            {
                error = "没有可导出的数据";
                return false;
            }
            DataTable dt = new DataTable();
            dt.Columns.Add("资源位置"); //1
            dt.Columns.Add("资源编号"); //2
            dt.Columns.Add("收费项目"); //3
            dt.Columns.Add("上次读表"); //4
            dt.Columns.Add("本次读表"); //5
            dt.Columns.Add("用量");//6
            dt.Columns.Add("单价"); //8
            dt.Columns.Add("金额"); //9
            dt.Columns.Add("收费状态"); //10
            dt.Columns.Add("账单日期"); //10
            dt.Columns.Add("计费开始日期"); //11
            dt.Columns.Add("计费结束日期"); //12
            dt.Columns.Add("表种类"); //13
            dt.Columns.Add("表名称"); //13
            for (int i = 0; i < list.Length; i++)
            {
                DataRow dr = dt.NewRow();
                dr["资源位置"] = list[i].FullName;
                dr["资源编号"] = list[i].Name;
                dr["收费项目"] = list[i].ChargeName;
                dr["上次读表"] = list[i].StartPoint <= 0 ? 0 : list[i].StartPoint;
                dr["本次读表"] = list[i].EndPoint <= 0 ? 0 : list[i].EndPoint;
                dr["用量"] = list[i].FinalUseCount <= 0 ? 0 : list[i].FinalUseCount;
                decimal UnitPrice = 0;
                if (list[i].FinalUnitPrice > 0)
                {
                    UnitPrice = list[i].FinalUnitPrice;
                }
                else if (list[i].UnitPrice > 0)
                {
                    UnitPrice = list[i].UnitPrice;
                }
                else if (list[i].SummaryUnitPrice > 0)
                {
                    UnitPrice = list[i].SummaryUnitPrice;
                }
                dr["单价"] = UnitPrice;
                dr["金额"] = list[i].FinalRealCost <= 0 ? 0 : list[i].FinalRealCost;
                dr["收费状态"] = list[i].ChargeStatusDesc;
                dr["账单日期"] = list[i].WriteDate == DateTime.MinValue ? "" : list[i].WriteDate.ToString("yyyy-MM-dd");
                dr["计费开始日期"] = list[i].FinalStartTime == DateTime.MinValue ? "" : list[i].FinalStartTime.ToString("yyyy-MM-dd");
                dr["计费结束日期"] = list[i].FinalEndTime == DateTime.MinValue ? "" : list[i].FinalEndTime.ToString("yyyy-MM-dd");
                dr["表种类"] = list[i].ImportBiaoCategory;
                dr["表名称"] = list[i].ImportBiaoName;
                dt.Rows.Add(dr);
            }
            DataRow footer_dr = dt.NewRow();
            footer_dr["资源位置"] = "总合计";
            footer_dr["用量"] = footer[0].FinalUseCount <= 0 ? 0 : footer[0].FinalUseCount;
            footer_dr["金额"] = footer[0].FinalRealCost <= 0 ? 0 : footer[0].FinalRealCost;
            dt.Rows.Add(footer_dr);
            string FileName = "抄表台帐_" + DateTime.Now.ToString("yyyyMMddHHmmss") + "_导入.xls";
            string filepath = "/upload/ExcelExport/ExportFee/";
            downloadurl = DownloadProcess(dt, FileName, filepath);
            return true;
        }
        public static bool DownLoadMeterProjectData(Foresight.DataAccess.Ui.DataGrid dg, bool IsWritePoint, out string downloadurl, out string error)
        {
            downloadurl = string.Empty;
            error = string.Empty;
            var list = dg.rows as ChargeMeter_ProjectDetail[];
            if (list.Length == 0)
            {
                error = "无相关导出数据";
                return false;
            }
            DataTable dt = new DataTable();
            dt.Columns.Add("仪表ID");//0
            dt.Columns.Add("资源编号"); //2
            dt.Columns.Add("仪表名称"); //2
            dt.Columns.Add("仪表编号"); //3
            dt.Columns.Add("仪表种类"); //4
            dt.Columns.Add("仪表类型"); //4
            dt.Columns.Add("仪表规格"); //5
            dt.Columns.Add("倍率"); //5
            dt.Columns.Add("缴费户号"); //5
            dt.Columns.Add("仪表位置");//6
            dt.Columns.Add("备注");//6
            dt.Columns.Add("排序序号"); //7
            if (IsWritePoint)
            {
                dt.Columns.Add("抄表状态"); //7
                dt.Columns.Add("账单状态"); //7
                dt.Columns.Add("上次读数"); //7
                dt.Columns.Add("本次读数"); //7
                dt.Columns.Add("用量"); //7
            }
            for (int i = 0; i < list.Length; i++)
            {
                DataRow dr = dt.NewRow();
                dr["仪表ID"] = list[i].ID;
                dr["资源编号"] = list[i].FinalName;
                dr["仪表名称"] = list[i].MeterName;
                dr["仪表编号"] = list[i].MeterNumber;
                dr["仪表种类"] = list[i].MeterCategoryName;
                dr["仪表类型"] = list[i].MeterTypeName;
                dr["仪表规格"] = list[i].MeterSpecDesc;
                dr["倍率"] = list[i].MeterCoefficient > 0 ? list[i].MeterCoefficient : 0;
                dr["缴费户号"] = list[i].MeterHouseNo;
                dr["仪表位置"] = list[i].MeterLocation;
                dr["备注"] = list[i].MeterRemark;
                dr["排序序号"] = list[i].SortOrder > int.MinValue ? list[i].SortOrder : 0;
                if (IsWritePoint)
                {
                    dr["抄表状态"] = list[i].WriteStatusDesc;
                    dr["账单状态"] = list[i].FeeStatusDesc;
                    dr["上次读数"] = list[i].FinalFrontStartPoint;
                    dr["本次读数"] = list[i].FinalFrontEndPoint;
                    dr["用量"] = list[i].FinalFrontTotalPoint;
                }
                dt.Rows.Add(dr);
            }
            string FileName = "仪表导入_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";
            string filepath = "/upload/ExcelExport/ExportFee/";
            downloadurl = DownloadProcess(dt, FileName, filepath);
            return true;
        }
        public static bool DownLoadMallOrderData(List<Dictionary<string, object>> list, out string downloadurl, out string error)
        {
            downloadurl = string.Empty;
            error = string.Empty;
            if (list.Count == 0)
            {
                error = "无相关导出数据";
                return false;
            }
            List<CellRangeAddressModel> rangeList = new List<CellRangeAddressModel>();
            CellRangeAddressModel model1 = new CellRangeAddressModel();
            DataTable dt = new DataTable();
            dt.Columns.Add("商品");
            dt.Columns.Add("单价");
            dt.Columns.Add("数量");
            dt.Columns.Add("商品总金额");
            dt.Columns.Add("买家");
            dt.Columns.Add("交易状态");
            dt.Columns.Add("订单类型");
            dt.Columns.Add("运费");
            dt.Columns.Add("抵扣福顺券");
            dt.Columns.Add("订单总金额");
            dt.Columns.Add("订单总积分");
            dt.Columns.Add("发货");
            dt.Columns.Add("付款方式");
            dt.Columns.Add("买家备注");
            dt.Columns.Add("卖家备注");
            int count_index = 0;
            for (int i = 0; i < list.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr["商品"] = "订单编号：" + list[i]["OrderNumber"] + " 成交时间：" + list[i]["AddTime"] + " 所属商户：" + list[i]["BusinessName"];
                dt.Rows.Add(dr);
                model1 = new CellRangeAddressModel();
                model1.IsUse = true;
                model1.FirstRow = (count_index + 1);
                model1.LastRow = (count_index + 1);
                model1.FirstCol = dt.Columns["商品"].Ordinal;
                model1.LastCol = dt.Columns["卖家备注"].Ordinal;
                rangeList.Add(model1);
                count_index++;
                var item_list = list[i]["itemlist"] as List<Dictionary<string, object>>;
                for (int j = 0; j < item_list.Count; j++)
                {
                    dr = dt.NewRow();
                    string title = item_list[j]["ProductTitle"].ToString();
                    string sub_title = item_list[j]["ProductSubTitle"].ToString();
                    if (!string.IsNullOrEmpty(sub_title))
                    {
                        title += " - " + sub_title;
                    }
                    dr["商品"] = title;
                    dr["单价"] = item_list[j]["Price"];
                    dr["数量"] = item_list[j]["Quantity"];
                    dr["商品总金额"] = item_list[j]["TotalPrice"];
                    dr["买家"] = list[i]["BuyerName"].ToString() + "\n" + list[i]["BuyerPhone"].ToString() + "\n" + list[i]["FullAddressInfo"].ToString();
                    dr["交易状态"] = list[i]["OrderStatusDesc"];
                    dr["订单类型"] = list[i]["ProductTypeDesc"];
                    dr["运费"] = list[i]["ShipRateAmount"];
                    dr["抵扣福顺券"] = list[i]["CouponAmount"];
                    dr["订单总金额"] = list[i]["TotalCost"];
                    dr["订单总积分"] = list[i]["TotalPoint"];
                    dr["发货"] = list[i]["ShipCompanyName"];
                    dr["付款方式"] = list[i]["PaymentMethodDesc"];
                    dr["买家备注"] = list[i]["UserNote"];
                    dr["卖家备注"] = list[i]["SellerNote"];
                    dt.Rows.Add(dr);
                    count_index++;
                }
            }
            string FileName = "订单_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";
            string filepath = "/upload/ExcelExport/ExportFee/";
            downloadurl = DownloadProcess(dt, FileName, filepath, rangeList: rangeList);
            return true;
        }
        public static bool DownLoadShouFeiLvAnalysisData(Foresight.DataAccess.Ui.DataGrid dg, string RoomType, out string downloadurl, out string error)
        {
            downloadurl = string.Empty;
            error = string.Empty;
            var list = new ChargeSummaryShouFeiLvAnalysis[] { };
            if (dg != null)
            {
                list = dg.rows as ChargeSummaryShouFeiLvAnalysis[];
            }
            if (list.Length == 0)
            {
                error = "没有可导出的数据";
                return false;
            }
            DataTable dt = new DataTable();
            dt.Columns.Add("资源位置");
            dt.Columns.Add("房间编号");
            dt.Columns.Add("收费项目");
            dt.Columns.Add("本期应收");
            dt.Columns.Add("累计应收");
            dt.Columns.Add("本期减免");
            dt.Columns.Add("本期实收");
            dt.Columns.Add("累计减免");
            dt.Columns.Add("累计实收");
            dt.Columns.Add("本期欠费");
            dt.Columns.Add("累计欠费");
            dt.Columns.Add("本期收费率");
            dt.Columns.Add("累计收费率");
            if (RoomType == "Project")
            {
                decimal ShouFuZhiBenQiYingShou_SUM = 0;
                decimal ShouFuZhiLeiJiYingShou_SUM = 0;
                decimal ShouFuZhiBenQiShiShou_SUM = 0;
                decimal ShouFuZhiLeiJiShiShou_SUM = 0;
                decimal ShouFuZhiBenQiQianFei_SUM = 0;
                decimal ShouFuZhiLiShiQianFei_SUM = 0;
                decimal ShouFuZhiBenQiJianMian_SUM = 0;
                decimal ShouFuZhiLiShiJianMian_SUM = 0;
                DataRow dr = null;
                foreach (var item in list)
                {
                    ShouFuZhiBenQiYingShou_SUM += item.ShouFuZhiBenQiYingShou;
                    ShouFuZhiLeiJiYingShou_SUM += item.ShouFuZhiLeiJiYingShou;
                    ShouFuZhiBenQiShiShou_SUM += item.ShouFuZhiBenQiShiShou;
                    ShouFuZhiLeiJiShiShou_SUM += item.ShouFuZhiLeiJiShiShou;
                    ShouFuZhiBenQiQianFei_SUM += item.ShouFuZhiBenQiQianFei;
                    ShouFuZhiLiShiQianFei_SUM += item.ShouFuZhiLiShiQianFei;
                    ShouFuZhiBenQiJianMian_SUM += item.ShouFuZhiBenQiJianMian;
                    ShouFuZhiLiShiJianMian_SUM += item.ShouFuZhiLiShiJianMian;
                    dr = dt.NewRow();
                    dr["资源位置"] = item.FullName;
                    dr["房间编号"] = item.RoomName;
                    dr["收费项目"] = item.Name;
                    dr["本期应收"] = item.ShouFuZhiBenQiYingShou;
                    dr["累计应收"] = item.ShouFuZhiLeiJiYingShou;
                    dr["本期实收"] = item.ShouFuZhiBenQiShiShou;
                    dr["累计实收"] = item.ShouFuZhiLeiJiShiShou;
                    dr["本期欠费"] = item.ShouFuZhiBenQiQianFei;
                    dr["累计欠费"] = item.ShouFuZhiLiShiQianFei;
                    dr["本期收费率"] = item.ShouFuZhiBenQiShouFeiLv;
                    dr["累计收费率"] = item.ShouFuZhiLeiJiShouFeiLv;
                    dr["本期减免"] = item.ShouFuZhiBenQiJianMian;
                    dr["累计减免"] = item.ShouFuZhiLiShiJianMian;
                    dt.Rows.Add(dr);
                }
                dr = dt.NewRow();
                dr["资源位置"] = "合计";
                dr["房间编号"] = "";
                dr["收费项目"] = "";
                dr["本期应收"] = ShouFuZhiBenQiYingShou_SUM;
                dr["累计应收"] = ShouFuZhiLeiJiYingShou_SUM;
                dr["本期实收"] = ShouFuZhiBenQiShiShou_SUM;
                dr["累计实收"] = ShouFuZhiLeiJiShiShou_SUM;
                dr["本期欠费"] = ShouFuZhiBenQiQianFei_SUM;
                dr["累计欠费"] = ShouFuZhiLiShiQianFei_SUM;
                dr["本期收费率"] = "--";
                dr["累计收费率"] = "--";
                dr["本期减免"] = ShouFuZhiBenQiJianMian_SUM;
                dr["累计减免"] = ShouFuZhiLiShiJianMian_SUM;
                dt.Rows.Add(dr);
            }
            else if (RoomType == "Room")
            {
                decimal ShouFuZhiBenQiYingShou_SUM = 0;
                decimal ShouFuZhiLeiJiYingShou_SUM = 0;
                decimal ShouFuZhiBenQiShiShou_SUM = 0;
                decimal ShouFuZhiLeiJiShiShou_SUM = 0;
                decimal ShouFuZhiBenQiQianFei_SUM = 0;
                decimal ShouFuZhiLiShiQianFei_SUM = 0;
                decimal ShouFuZhiBenQiJianMian_SUM = 0;
                decimal ShouFuZhiLiShiJianMian_SUM = 0;
                DataRow dr = null;
                foreach (var item in list)
                {
                    ShouFuZhiBenQiYingShou_SUM += item.ShouFuZhiBenQiYingShou;
                    ShouFuZhiLeiJiYingShou_SUM += item.ShouFuZhiLeiJiYingShou;
                    ShouFuZhiBenQiShiShou_SUM += item.ShouFuZhiBenQiShiShou;
                    ShouFuZhiLeiJiShiShou_SUM += item.ShouFuZhiLeiJiShiShou;
                    ShouFuZhiBenQiQianFei_SUM += item.ShouFuZhiBenQiQianFei;
                    ShouFuZhiLiShiQianFei_SUM += item.ShouFuZhiLiShiQianFei;
                    ShouFuZhiBenQiJianMian_SUM += item.ShouFuZhiBenQiJianMian;
                    ShouFuZhiLiShiJianMian_SUM += item.ShouFuZhiLiShiJianMian;
                    dr = dt.NewRow();
                    dr["资源位置"] = item.FullName;
                    dr["房间编号"] = item.RoomName;
                    dr["收费项目"] = item.Name;
                    dr["本期应收"] = item.ShouFuZhiBenQiYingShou;
                    dr["累计应收"] = item.ShouFuZhiLeiJiYingShou;
                    dr["本期实收"] = item.ShouFuZhiBenQiShiShou;
                    dr["累计实收"] = item.ShouFuZhiLeiJiShiShou;
                    dr["本期欠费"] = item.ShouFuZhiBenQiQianFei;
                    dr["累计欠费"] = item.ShouFuZhiLiShiQianFei;
                    dr["本期收费率"] = item.ShouFuZhiBenQiShouFeiLv;
                    dr["累计收费率"] = item.ShouFuZhiLeiJiShouFeiLv;
                    dr["本期减免"] = item.ShouFuZhiBenQiJianMian;
                    dr["累计减免"] = item.ShouFuZhiLiShiJianMian;
                    dt.Rows.Add(dr);
                }
                dr = dt.NewRow();
                dr["资源位置"] = "合计";
                dr["房间编号"] = "";
                dr["收费项目"] = "";
                dr["本期应收"] = ShouFuZhiBenQiYingShou_SUM;
                dr["累计应收"] = ShouFuZhiLeiJiYingShou_SUM;
                dr["本期实收"] = ShouFuZhiBenQiShiShou_SUM;
                dr["累计实收"] = ShouFuZhiLeiJiShiShou_SUM;
                dr["本期欠费"] = ShouFuZhiBenQiQianFei_SUM;
                dr["累计欠费"] = ShouFuZhiLiShiQianFei_SUM;
                dr["本期收费率"] = "--";
                dr["累计收费率"] = "--";
                dr["本期减免"] = ShouFuZhiBenQiJianMian_SUM;
                dr["累计减免"] = ShouFuZhiLiShiJianMian_SUM;
                dt.Rows.Add(dr);
            }
            else
            {
                decimal ShouFuZhiBenQiYingShou_SUM = 0;
                decimal ShouFuZhiLeiJiYingShou_SUM = 0;
                decimal ShouFuZhiBenQiShiShou_SUM = 0;
                decimal ShouFuZhiLeiJiShiShou_SUM = 0;
                decimal ShouFuZhiBenQiQianFei_SUM = 0;
                decimal ShouFuZhiLiShiQianFei_SUM = 0;
                decimal ShouFuZhiBenQiJianMian_SUM = 0;
                decimal ShouFuZhiLiShiJianMian_SUM = 0;
                DataRow dr = null;
                foreach (var item in list)
                {
                    ShouFuZhiBenQiYingShou_SUM += item.ShouFuZhiBenQiYingShou;
                    ShouFuZhiLeiJiYingShou_SUM += item.ShouFuZhiLeiJiYingShou;
                    ShouFuZhiBenQiShiShou_SUM += item.ShouFuZhiBenQiShiShou;
                    ShouFuZhiLeiJiShiShou_SUM += item.ShouFuZhiLeiJiShiShou;
                    ShouFuZhiBenQiQianFei_SUM += item.ShouFuZhiBenQiQianFei;
                    ShouFuZhiLiShiQianFei_SUM += item.ShouFuZhiLiShiQianFei;
                    ShouFuZhiBenQiJianMian_SUM += item.ShouFuZhiBenQiJianMian;
                    ShouFuZhiLiShiJianMian_SUM += item.ShouFuZhiLiShiJianMian;
                    dr = dt.NewRow();
                    dr["资源位置"] = item.FullName;
                    dr["房间编号"] = item.RoomName;
                    dr["收费项目"] = item.Name;
                    dr["本期应收"] = item.ShouFuZhiBenQiYingShou;
                    dr["累计应收"] = item.ShouFuZhiLeiJiYingShou;
                    dr["本期实收"] = item.ShouFuZhiBenQiShiShou;
                    dr["累计实收"] = item.ShouFuZhiLeiJiShiShou;
                    dr["本期欠费"] = item.ShouFuZhiBenQiQianFei;
                    dr["累计欠费"] = item.ShouFuZhiLiShiQianFei;
                    dr["本期收费率"] = item.ShouFuZhiBenQiShouFeiLv;
                    dr["累计收费率"] = item.ShouFuZhiLeiJiShouFeiLv;
                    dr["本期减免"] = item.ShouFuZhiBenQiJianMian;
                    dr["累计减免"] = item.ShouFuZhiLiShiJianMian;
                    dt.Rows.Add(dr);
                }
                dr = dt.NewRow();
                dr["资源位置"] = "合计";
                dr["房间编号"] = "";
                dr["收费项目"] = "";
                dr["本期应收"] = ShouFuZhiBenQiYingShou_SUM;
                dr["累计应收"] = ShouFuZhiLeiJiYingShou_SUM;
                dr["本期实收"] = ShouFuZhiBenQiShiShou_SUM;
                dr["累计实收"] = ShouFuZhiLeiJiShiShou_SUM;
                dr["本期欠费"] = ShouFuZhiBenQiQianFei_SUM;
                dr["累计欠费"] = ShouFuZhiLiShiQianFei_SUM;
                dr["本期收费率"] = "--";
                dr["累计收费率"] = "--";
                dr["本期减免"] = ShouFuZhiBenQiJianMian_SUM;
                dr["累计减免"] = ShouFuZhiLiShiJianMian_SUM;
                dt.Rows.Add(dr);
            }
            string FileName = "收付制_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";
            string filepath = "/upload/ExcelExport/ExportFee/";
            downloadurl = DownloadProcess(dt, FileName, filepath);
            return true;
        }
        public static string DownloadProcess(DataTable dt, string FileName, string filepath, List<CellRangeAddressModel> rangeList = null, List<NpoiHeadCfg> heads = null)
        {

            FileName = FileName.Split('.')[0] + ".xlsx";
            string fullpath = HttpContext.Current.Server.MapPath("~" + filepath);
            if (!System.IO.Directory.Exists(fullpath))
            {
                System.IO.Directory.CreateDirectory(fullpath);
            }
            string strFileName = System.IO.Path.Combine(fullpath, FileName);

            ExcelProcess.ExcelExportHelper.ReportExcel(dt, strFileName, rangeList, heads);
            return WebUtil.GetContextPath() + filepath + FileName;
        }
        private static NpoiHeadCfg SaveNpoiHead(string FieldLable, string FieldName, List<NpoiHeadCfg> head_list = null, NpoiHeadCfg parent_head = null)
        {
            var data = new NpoiHeadCfg();
            data.FieldLable = FieldLable;
            data.FieldName = FieldName;
            data.Height = 20;
            data.IsBold = true;
            if (head_list != null)
            {
                head_list.Add(data);
            }
            if (parent_head != null)
            {
                parent_head.Childs.Add(data);
            }
            return data;
        }
        private static List<Dictionary<string, object>> GetTableColumns(string PageCode, string TableName = "")
        {
            var list = Foresight.DataAccess.TableColumn.GetTableColumnByPageCode(PageCode, true).Where(p => !p.ColumnName.Equals("选择按钮")).ToArray();
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
            var fieldlist = all_fieldlist.Where(p => string.IsNullOrEmpty(p.ColumnName) && p.IsShown);
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
        private static void SetDrValue(List<Dictionary<string, object>> titleList, DataRow dr, string Title, object Value)
        {
            for (int i = 0; i < titleList.Count; i++)
            {
                if (titleList[i]["ColumnName"].Equals(Title))
                {
                    dr[Title] = Value;
                    break;
                }
            }
        }
        public static object GetPropertyValue(object data, string Name)
        {
            var data_type = data.GetType();
            var data_property = data_type.GetProperties();
            foreach (PropertyInfo item in data_property)
            {
                if (item.PropertyType == typeof(String) || item.PropertyType == typeof(Int32) || item.PropertyType == typeof(Decimal) || item.PropertyType == typeof(Boolean) || item.PropertyType == typeof(DateTime))//属性的类型判断
                {
                    if (item.Name.Equals(Name))
                    {
                        var Value = item.GetValue(data, null);
                        if (item.PropertyType == typeof(Int32))
                        {
                            int result = 0;
                            int.TryParse(Value.ToString(), out result);
                            return result > 0 ? result : 0;
                        }
                        if (item.PropertyType == typeof(Decimal))
                        {
                            decimal result = 0;
                            decimal.TryParse(Value.ToString(), out result);
                            return result > 0 ? result : 0;
                        }
                        if (item.PropertyType == typeof(DateTime))
                        {
                            DateTime result = DateTime.MinValue;
                            DateTime.TryParse(Value.ToString(), out result);
                            return result > DateTime.MinValue ? result.ToString("yyyy-MM-dd HH:mm:ss") : string.Empty;
                        }
                        if (item.PropertyType == typeof(String))
                        {
                            return Value;
                        }
                        break;
                    }
                }
            }
            return string.Empty;
        }
    }
}