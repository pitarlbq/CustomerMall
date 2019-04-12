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
    public partial class ChequeStampMgr : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private void SetDrValue(DataRow dr, string Title, object Value)
        {
            if (titleList.Length == 0)
            {
                titleList = Foresight.DataAccess.TableColumn.GetTableColumnByPageCode("chequestampmgr", true).Where(p => !p.ColumnName.Equals("选择按钮")).ToArray();
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
                var list = Foresight.DataAccess.ViewChequeTax.GetViewChequeTaxListByKeywords(keywords);
                if (list.Length > 0)
                {
                    titleList = Foresight.DataAccess.TableColumn.GetTableColumnByPageCode("chequestampmgr", true).Where(p => !p.ColumnName.Equals("选择按钮")).ToArray();
                    DataTable dt = new DataTable();
                    foreach (var item in titleList)
                    {
                        dt.Columns.Add(item.ColumnName);
                    }
                    for (int i = 0; i < list.Length; i++)
                    {
                        DataRow dr = dt.NewRow();
                        SetDrValue(dr, "ID", list[i].ID.ToString());
                        SetDrValue(dr, "合同编号", list[i].ContractNumber);
                        SetDrValue(dr, "部门名称", list[i].DepartmentName);
                        SetDrValue(dr, "合同分类", list[i].ContractCategoryName);
                        SetDrValue(dr, "印花税税目税率表", list[i].TaxRateName);
                        SetDrValue(dr, "合同名称", list[i].ContractName);
                        SetDrValue(dr, "单价", (list[i].UnitPrice > 0 ? list[i].UnitPrice.ToString() : ""));
                        SetDrValue(dr, "数量", (list[i].TotalCount > 0 ? list[i].TotalCount.ToString() : ""));
                        SetDrValue(dr, "金额", (list[i].TotalCost > 0 ? list[i].TotalCost.ToString() : ""));
                        SetDrValue(dr, "税额", (list[i].TotalTaxCost > 0 ? list[i].TotalTaxCost.ToString() : ""));
                        SetDrValue(dr, "登记人", list[i].AddMan);
                        SetDrValue(dr, "登记日期", (list[i].AddTime > DateTime.MinValue ? list[i].AddTime.ToString("yyyy-MM-dd HH:mm:ss") : ""));
                        dt.Rows.Add(dr);
                    }
                    string FileName = "印花税-" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";
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