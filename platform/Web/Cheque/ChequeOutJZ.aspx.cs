using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Cheque
{
    public partial class ChequeOutJZ : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void SetDrValue(DataRow dr, string Title, object Value)
        {
            if (titleList.Length == 0)
            {
                titleList = Foresight.DataAccess.TableColumn.GetTableColumnByPageCode("chequeoutjz", true).Where(p => !p.ColumnName.Equals("选择按钮")).ToArray();
            }
            for (int i = 0; i < titleList.Length; i++)
            {
                if (titleList[i].ColumnName.Equals(Title))
                {
                    dr[Title] = Value;
                    break;
                }
            }
        }
        Foresight.DataAccess.TableColumn[] titleList = new Foresight.DataAccess.TableColumn[] { };
        protected void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                string keywords = this.hdKeywords.Value;
                var list = Foresight.DataAccess.Cheque_OutingDetail.GetCheque_OutingDetailListByKeywords(keywords);
                if (list.Length > 0)
                {
                    titleList = Foresight.DataAccess.TableColumn.GetTableColumnByPageCode("chequeoutjz", true).Where(p => !p.ColumnName.Equals("选择按钮")).ToArray();
                    DataTable dt = new DataTable();
                    foreach (var item in titleList)
                    {
                        dt.Columns.Add(item.ColumnName);
                    }
                    for (int i = 0; i < list.Length; i++)
                    {
                        DataRow dr = dt.NewRow();
                        SetDrValue(dr, "ID", list[i].ID.ToString());
                        SetDrValue(dr, "工程项目", list[i].ProjectName);
                        SetDrValue(dr, "生效日期", list[i].StartTime == DateTime.MinValue ? "" : list[i].StartTime.ToString("yyyy-MM-dd"));
                        SetDrValue(dr, "失效日期", list[i].EndTime == DateTime.MinValue ? "" : list[i].EndTime.ToString("yyyy-MM-dd"));
                        SetDrValue(dr, "提醒日期", list[i].NotifyTime == DateTime.MinValue ? "" : list[i].NotifyTime.ToString("yyyy-MM-dd"));
                        SetDrValue(dr, "经办人", list[i].Operator);
                        SetDrValue(dr, "办理日期", list[i].OperationTime == DateTime.MinValue ? "" : list[i].OperationTime.ToString("yyyy-MM-dd HH:mm:ss"));
                        SetDrValue(dr, "证件状态", list[i].IDCardStatus);
                        SetDrValue(dr, "所属分公司", list[i].BelongCompanyName);
                        SetDrValue(dr, "直管部门", list[i].DepartmentName);
                        SetDrValue(dr, "文书号", list[i].PaperNumber);
                        SetDrValue(dr, "外出经营地", list[i].OutingAddress);
                        SetDrValue(dr, "审核人", list[i].ApproveMan);
                        SetDrValue(dr, "备注", list[i].Remark);
                        dt.Rows.Add(dr);
                    }
                    string FileName = "外经证-" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";
                    string filepath = Server.MapPath("~/upload/cheque/");
                    if (!System.IO.Directory.Exists(filepath))
                    {
                        System.IO.Directory.CreateDirectory(filepath);
                    }
                    string strFileName = Path.Combine(filepath, FileName);
                    ExcelProcess.ExcelExportHelper.ReportExcel(dt, strFileName);
                    FileInfo DownloadFile = new FileInfo(strFileName);
                    if (DownloadFile.Exists)
                    {
                        string outputFileName = null;
                        System.Text.Encoding encoding;
                        string browser = HttpContext.Current.Request.UserAgent.ToUpper();
                        if (browser.Contains("MS") == true && browser.Contains("IE") == true)
                        {
                            outputFileName = HttpUtility.UrlEncode(FileName);
                            encoding = System.Text.Encoding.Default;
                        }
                        else if (browser.Contains("FIREFOX") == true)
                        {
                            outputFileName = FileName;
                            encoding = System.Text.Encoding.GetEncoding("GB2312");
                        }
                        else
                        {
                            outputFileName = HttpUtility.UrlEncode(FileName);
                            encoding = System.Text.Encoding.Default;
                        }
                        HttpContext.Current.Response.Clear();
                        HttpContext.Current.Response.Buffer = true;
                        HttpContext.Current.Response.ContentEncoding = encoding;
                        HttpContext.Current.Response.AddHeader("Content-Disposition", string.Format("attachment; filename={0}", string.IsNullOrEmpty(outputFileName) ? DateTime.Now.ToString("yyyyMMddHHmmssfff") : outputFileName));
                        Response.WriteFile(DownloadFile.FullName);
                        HttpContext.Current.Response.End();
                    }
                    else
                    {
                        base.RegisterClientMessage("服务器没有导出该数据文件");
                    }
                }
                else
                {
                    base.RegisterClientMessage("没有可导出的数据");
                }
            }
            catch (Exception ex)
            {
                //base.RegisterClientMessage("服务器内部异常" + ex.Message);
            }
        }
    }
}