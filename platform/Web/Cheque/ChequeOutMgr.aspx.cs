using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utility;

namespace Web.Cheque
{
    public partial class ChequeOutMgr : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private void SetDrValue(DataRow dr, string Title, object Value)
        {
            if (titleList.Length == 0)
            {
                titleList = Foresight.DataAccess.TableColumn.GetTableColumnByPageCode("chequeoutmgr", true).Where(p => !p.ColumnName.Equals("选择按钮")).ToArray();
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
                string Departments = this.hdDepartmentList.Value;
                List<int> DepartmentList = new List<int>();
                if (!string.IsNullOrEmpty(Departments))
                {
                    DepartmentList = JsonConvert.DeserializeObject<List<int>>(Departments);
                }
                string Products = this.hdProductList.Value;
                List<int> ProductList = new List<int>();
                if (!string.IsNullOrEmpty(Products))
                {
                    ProductList = JsonConvert.DeserializeObject<List<int>>(Products);
                }
                string Projects = this.hdProjectList.Value;
                List<int> ProjectList = new List<int>();
                if (!string.IsNullOrEmpty(Projects))
                {
                    ProjectList = JsonConvert.DeserializeObject<List<int>>(Projects);
                }
                string Sellers = this.hdSellerList.Value;
                List<int> SellerList = new List<int>();
                if (!string.IsNullOrEmpty(Sellers))
                {
                    SellerList = JsonConvert.DeserializeObject<List<int>>(Sellers);
                }
                string keywords = this.hdKeywords.Value;
                DateTime StartTime = DateTime.MinValue;
                DateTime.TryParse(this.hdStartTime.Value, out StartTime);
                DateTime EndTime = DateTime.MinValue;
                DateTime.TryParse(this.hdEndTime.Value, out EndTime);
                string ChequeCode = this.hdChequeCode.Value;

                var list = Foresight.DataAccess.ViewChequeOutSummary.GetViewChequeOutSummaryListByKeywords(keywords, SellerList, ProductList, DepartmentList, ProjectList, StartTime, EndTime, ChequeCode);
                if (list.Length > 0)
                {
                    titleList = Foresight.DataAccess.TableColumn.GetTableColumnByPageCode("chequeoutmgr", true).Where(p => !p.ColumnName.Equals("选择按钮")).ToArray();
                    DataTable dt = new DataTable();
                    foreach (var item in titleList)
                    {
                        dt.Columns.Add(item.ColumnName);
                    }
                    for (int i = 0; i < list.Length; i++)
                    {
                        DataRow dr = dt.NewRow();
                        SetDrValue(dr, "ID", list[i].ID.ToString());
                        SetDrValue(dr, "登记日期", list[i].WriteDate == DateTime.MinValue ? "" : list[i].WriteDate.ToString("yyyy-MM-dd HH:mm:ss"));
                        SetDrValue(dr, "所属直管部门", list[i].DepartmentName);
                        SetDrValue(dr, "部门档案", list[i].DepartmentFile);
                        SetDrValue(dr, "项目名称", list[i].ProjectName);
                        SetDrValue(dr, "销售单位名称", list[i].SellerName);
                        SetDrValue(dr, "销售纳税人识别号", list[i].SellerTaxNumber);
                        SetDrValue(dr, "销售地址电话", list[i].SellerAddressPhone);
                        SetDrValue(dr, "销售开户行及帐号", list[i].SellerBankAccount);
                        SetDrValue(dr, "货物或应税劳务名称", list[i].ProductName);
                        SetDrValue(dr, "规格型号", list[i].ModelNumber);
                        SetDrValue(dr, "单位", list[i].Unit);
                        SetDrValue(dr, "数量", list[i].TotalCount > 0 ? list[i].TotalCount.ToString() : "");
                        SetDrValue(dr, "单价", list[i].UnitPrice > 0 ? list[i].UnitPrice.ToString() : "");
                        SetDrValue(dr, "金额", list[i].TotalCost > 0 ? list[i].TotalCost.ToString() : "");
                        SetDrValue(dr, "税率", list[i].TaxRate);
                        SetDrValue(dr, "税额", list[i].TotalTaxCost > 0 ? list[i].TotalTaxCost.ToString() : "");
                        SetDrValue(dr, "价税合计", list[i].ChequeTotalCost > 0 ? list[i].ChequeTotalCost.ToString() : "");
                        SetDrValue(dr, "签收人员", list[i].SignOperator);
                        SetDrValue(dr, "签收日期", list[i].SignTime == DateTime.MinValue ? "" : list[i].SignTime.ToString("yyyy-MM-dd HH:mm:ss"));
                        SetDrValue(dr, "审核人员", list[i].ApproveOperator);
                        SetDrValue(dr, "审核日期", list[i].ApporveTime == DateTime.MinValue ? "" : list[i].ApporveTime.ToString("yyyy-MM-dd HH:mm:ss"));
                        SetDrValue(dr, "登记人员", list[i].WriteMan);
                        SetDrValue(dr, "销售单位分类", list[i].SellerCategoryName);
                        SetDrValue(dr, "项目分类", list[i].ProjectCategoryName);
                        SetDrValue(dr, "部门分类", list[i].DepartmentCategoryName);
                        SetDrValue(dr, "货物分类", list[i].ProductCategoryName);
                        SetDrValue(dr, "购货单位分类", list[i].BuyerCategoryName);
                        SetDrValue(dr, "发票编号", list[i].ChequeNumber);
                        SetDrValue(dr, "发票代码", list[i].ChequeCode);
                        SetDrValue(dr, "开票日期", list[i].ChequeTime == DateTime.MinValue ? "" : list[i].ChequeTime.ToString("yyyy-MM-dd"));
                        SetDrValue(dr, "购货单位名称", list[i].BuyerName);
                        SetDrValue(dr, "购货纳税人识别号", list[i].BuyerTaxNumber);
                        SetDrValue(dr, "购货地址电话", list[i].BuyerAddressPhone);
                        SetDrValue(dr, "购货开户行及帐号", list[i].BuyerBankAccount);
                        dt.Rows.Add(dr);
                    }
                    string FileName = "销项-" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";
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