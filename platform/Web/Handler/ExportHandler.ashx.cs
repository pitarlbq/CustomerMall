using Foresight.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Utility;

namespace Web.Handler
{
    /// <summary>
    /// ExportHandler 的摘要说明
    /// </summary>
    public class ExportHandler : BaseHandler, IHttpHandler
    {
        const string LogModule = "ExportHandler";
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
                    case "exportroomfeelist":
                        WrapParams(context, null);
                        exportroomfeelist(context);
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
        private void exportroomfeelist(HttpContext context)
        {
            AccpetParam["rows"] = int.MaxValue.ToString();
            int currentcount = 0;
            var dg = Web.APPCode.HandlerHelper.GetRoomFeeList(context, AccpetParam, out currentcount);
            var list = dg.rows as ViewRoomFee[];
            if (list.Length > 0)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("费项ID");
                dt.Columns.Add("资源位置");
                dt.Columns.Add("资源编号");
                dt.Columns.Add("收费对象");
                dt.Columns.Add("收费项目");
                dt.Columns.Add("计费规则");
                dt.Columns.Add("单价(月度)");
                dt.Columns.Add("计费开始日期");
                dt.Columns.Add("计费结束日期");
                dt.Columns.Add("计费停用日期");
                dt.Columns.Add("备注");
                for (int i = 0; i < list.Length; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr["费项ID"] = list[i].ID;
                    dr["资源位置"] = list[i].FullName;
                    dr["资源编号"] = list[i].RoomName;
                    dr["收费对象"] = list[i].FinalCustomerName;
                    dr["收费项目"] = list[i].Name;
                    dr["计费规则"] = list[i].ChargeTypeDesc;
                    dr["单价(月度)"] = list[i].CalculateUnitPrice > 0 ? list[i].CalculateUnitPrice : 0;
                    dr["计费开始日期"] = list[i].CalculateStartTime == DateTime.MinValue ? "" : list[i].CalculateStartTime.ToString("yyyy-MM-dd");
                    dr["计费结束日期"] = list[i].CalculateEndTime == DateTime.MinValue ? "" : list[i].CalculateEndTime.ToString("yyyy-MM-dd");
                    dr["计费停用日期"] = list[i].NewEndTime == DateTime.MinValue ? "" : list[i].NewEndTime.ToString("yyyy-MM-dd");
                    dr["备注"] = list[i].Remark;
                    dt.Rows.Add(dr);
                }
                string FileName = "费项标准" + DateTime.Now.ToString("yyyyMMddHHmmss") + "_导出.xlsx";
                string FileLocation = "/upload/ExcelExport/ExportFee/";
                string filepath = context.Server.MapPath("~" + FileLocation);
                if (!System.IO.Directory.Exists(filepath))
                {
                    System.IO.Directory.CreateDirectory(filepath);
                }
                string strFileName = System.IO.Path.Combine(filepath, FileName);
                ExcelProcess.ExcelExportHelper.ReportExcel(dt, strFileName);
                WebUtil.WriteJson(context, new { status = true, downloadurl = WebUtil.GetContextPath() + FileLocation + FileName });
            }
            else
            {
                WebUtil.WriteJson(context, new { status = false, error = "没有可以导出的数据" });
            }
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