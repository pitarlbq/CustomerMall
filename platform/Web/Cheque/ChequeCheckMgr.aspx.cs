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
    public partial class ChequeCheckMgr : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private void SetDrValue(DataRow dr, string Title, object Value)
        {
            if (titleList.Length == 0)
            {
                titleList = Foresight.DataAccess.TableColumn.GetTableColumnByPageCode("chequecheckmgr", true).Where(p => !p.ColumnName.Equals("选择按钮")).ToArray();
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
                int TakeStatus = 0;
                int.TryParse(this.hdTakeStatus.Value, out TakeStatus);
                int ApproveStatus = 0;
                int.TryParse(this.hdApproveStatus.Value, out ApproveStatus);
                int TransferStatus = 0;
                int.TryParse(this.hdTransferStatus.Value, out TransferStatus);
                var list = Foresight.DataAccess.ViewChequeConfirmImport.GetViewChequeConfirmImportListByKeywords(keywords, TakeStatus, ApproveStatus, TransferStatus, SellerList, ProductList, DepartmentList, ProjectList);
                if (list.Length > 0)
                {
                    titleList = Foresight.DataAccess.TableColumn.GetTableColumnByPageCode("chequecheckmgr", true).Where(p => !p.ColumnName.Equals("选择按钮") && !p.ColumnName.Equals("金额") && !p.ColumnName.Equals("税率") && !p.ColumnName.Equals("税额") && !p.ColumnName.Equals("货物或应税劳务名称")).ToArray();
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
                        SetDrValue(dr, "项目名称", list[i].ProjectName);
                        SetDrValue(dr, "销售单位名称", list[i].SellerName);
                        SetDrValue(dr, "发票编号", list[i].ChequeNumber);
                        SetDrValue(dr, "发票代码", list[i].ChequeCode);
                        SetDrValue(dr, "开票日期", list[i].ChequeTime == DateTime.MinValue ? "" : list[i].ChequeTime.ToString("yyyy-MM-dd"));
                        SetDrValue(dr, "财务接管日期", list[i].TakeTime == DateTime.MinValue ? "" : list[i].TakeTime.ToString("yyyy-MM-dd"));
                        SetDrValue(dr, "交接人", list[i].TakeUser);
                        SetDrValue(dr, "认证状态", list[i].ApproveStatusDesc);
                        SetDrValue(dr, "认证结果", list[i].CheckApproveRemark);
                        SetDrValue(dr, "认证月度", list[i].ApproveMonth);
                        SetDrValue(dr, "认证日期", list[i].ApproveTime == DateTime.MinValue ? "" : list[i].ChequeTime.ToString("yyyy-MM-dd"));
                        SetDrValue(dr, "认证方式", list[i].ApproveMethod);
                        SetDrValue(dr, "转出时间", list[i].TransferTime == DateTime.MinValue ? "" : list[i].TransferTime.ToString("yyyy-MM-dd"));
                        SetDrValue(dr, "转出人", list[i].TransferMan);
                        SetDrValue(dr, "转出金额", list[i].TransferMoney == Decimal.MinValue ? "" : list[i].TransferMoney.ToString());
                        SetDrValue(dr, "交接状态", list[i].TakeStatusDesc);
                        SetDrValue(dr, "转出状态", list[i].TransferStatusDesc);
                        dt.Rows.Add(dr);
                    }
                    string FileName = "核销-" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";
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