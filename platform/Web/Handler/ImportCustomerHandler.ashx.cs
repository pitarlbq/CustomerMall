using ExcelProcess;
using Foresight.DataAccess;
using Foresight.DataAccess.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using Utility;

namespace Web.Handler
{
    /// <summary>
    /// ImportHandler 的摘要说明
    /// </summary>
    public class ImportCustomerHandler : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string visit = context.Request.Params["visit"];
            if (string.IsNullOrEmpty(visit))
            {
                LogHelper.WriteDebug("ImportCustomerHandler", "visit为空");
                context.Response.Write(null);
                return;
            }
            visit = visit.ToLower();
            try
            {
                switch (visit)
                {
                    case "import":
                        import(context);
                        break;
                    default:
                        WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "Unkown Visit: " + visit);
                        break;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("ImportDaiShouHandler", "visit: " + visit, ex);
                context.Response.Write("{\"status\":false}");
            }

        }
        private void import(HttpContext context)
        {
            HttpFileCollection uploadFiles = context.Request.Files;
            if (uploadFiles.Count == 0)
            {
                context.Response.Write("请选择一个文件");
                return;
            }
            if (string.IsNullOrEmpty(uploadFiles[0].FileName))
            {
                context.Response.Write("请选择一个文件");
                return;
            }
            string msg = string.Empty;
            int CompanyID = int.Parse(context.Request.Params["CompanyID"]);
            int CreatorID = int.Parse(context.Request.Params["CreatorID"]);
            string AddMan = context.Request.Params["AddMan"];
            bool ImportFailed = false;
            int TotalNumber = 0;
            titleList = Foresight.DataAccess.TableColumn.GetTableColumnByPageCode("insidecustomersource", true).Where(p => (!p.ColumnName.Equals("选择按钮") && !p.ColumnName.Equals("合同附件"))).ToArray();
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    #region 导入处理
                    for (int j = 0; j < uploadFiles.Count; j++)
                    {
                        HttpPostedFile postedFile = uploadFiles[j];
                        string filepath = HttpContext.Current.Server.MapPath("~/upload/Customer/" + DateTime.Now.ToString("yyyyMMdd"));
                        if (!System.IO.Directory.Exists(filepath))
                        {
                            System.IO.Directory.CreateDirectory(filepath);
                        }
                        string filename = DateTime.Now.ToLocalTime().ToString("yyyyMMddHHmmss") + "_" + postedFile.FileName;
                        string fullpath = Path.Combine(filepath, filename);
                        postedFile.SaveAs(fullpath);
                        DataTable table = ExcelExportHelper.NPOIReadExcel(fullpath);
                        for (int i = 0; i < table.Rows.Count; i++)
                        {
                            Foresight.DataAccess.InsideCustomer customer = null;
                            object Value = null, CustomerName = null, ContactPhone = null;
                            if (GetColumnValue("客户名称", table, i, out CustomerName))
                            {
                                if (!string.IsNullOrEmpty(CustomerName.ToString()))
                                {
                                    customer = Foresight.DataAccess.InsideCustomer.GeInsideCustomerByParams(CustomerName.ToString(), string.Empty, helper);
                                }
                            }
                            if (customer != null)
                            {
                                msg += "<p>第" + (i + 2) + "行上传失败。原因：客户已存在</p>";
                                ImportFailed = true;
                                break;
                            }
                            if (GetColumnValue("联系方式", table, i, out ContactPhone))
                            {
                                if (!string.IsNullOrEmpty(ContactPhone.ToString()))
                                {
                                    customer = Foresight.DataAccess.InsideCustomer.GeInsideCustomerByParams(string.Empty, ContactPhone.ToString(), helper);
                                }
                            }
                            if (customer != null)
                            {
                                msg += "<p>第" + (i + 2) + "行上传失败。原因：客户已存在</p>";
                                ImportFailed = true;
                                break;
                            }
                            customer = new Foresight.DataAccess.InsideCustomer();
                            if (GetColumnValue("客户名称", table, i, out Value))
                            {
                                customer.CustomerName = Value.ToString();
                            }
                            if (GetColumnValue("行业", table, i, out Value))
                            {
                                customer.IndustryName = Value.ToString();
                            }
                            if (GetColumnValue("分类", table, i, out Value))
                            {
                                customer.CategoryName = Value.ToString();
                            }
                            if (GetColumnValue("意向分析", table, i, out Value))
                            {
                                customer.Interesting = Value.ToString();
                            }
                            if (GetColumnValue("联系人", table, i, out Value))
                            {
                                customer.ContactMan = Value.ToString();
                            }
                            if (GetColumnValue("联系方式", table, i, out Value))
                            {
                                customer.ContactPhone = Value.ToString();
                            }
                            if (GetColumnValue("QQ", table, i, out Value))
                            {
                                customer.QQNo = Value.ToString();
                            }
                            if (GetColumnValue("QQ群邀约", table, i, out Value))
                            {
                                customer.QQGroupInvitation = Value.ToString();
                            }
                            if (GetColumnValue("微信", table, i, out Value))
                            {
                                customer.WechatNo = Value.ToString();
                            }
                            if (GetColumnValue("微信群邀约", table, i, out Value))
                            {
                                customer.WechaGroupInvitation = Value.ToString();
                            }
                            if (GetColumnValue("其他联系人", table, i, out Value))
                            {
                                customer.OtherContactMan = Value.ToString();
                            }
                            if (GetColumnValue("客户所有者", table, i, out Value))
                            {
                                customer.CustomerBelonger = Value.ToString();
                            }
                            if (GetColumnValue("跟进日期", table, i, out Value))
                            {
                                DateTime NewFollowupDate = DateTime.MinValue;
                                DateTime.TryParse(Value.ToString(), out NewFollowupDate);
                                customer.NewFollowupDate = NewFollowupDate;
                            }
                            if (GetColumnValue("跟进记录", table, i, out Value))
                            {
                                customer.NewFollowup = Value.ToString();
                            }
                            if (GetColumnValue("区域", table, i, out Value))
                            {
                                customer.Region = Value.ToString();
                            }
                            if (GetColumnValue("省区", table, i, out Value))
                            {
                                customer.Province = Value.ToString();
                            }
                            if (GetColumnValue("城市", table, i, out Value))
                            {
                                customer.City = Value.ToString();
                            }
                            if (GetColumnValue("商务阶段", table, i, out Value))
                            {
                                customer.BusinessStage = Value.ToString();
                            }
                            if (GetColumnValue("报价", table, i, out Value))
                            {
                                decimal Cost = decimal.MinValue;
                                decimal.TryParse(Value.ToString(), out Cost);
                                customer.Cost = Cost;
                            }
                            if (GetColumnValue("成交可能性", table, i, out Value))
                            {
                                customer.DealProbably = Value.ToString();
                            }
                            if (GetColumnValue("备注", table, i, out Value))
                            {
                                customer.Remark = Value.ToString();
                            }
                            customer.AddTime = DateTime.Now;
                            customer.AddMan = WebUtil.GetUser(context).RealName;
                            customer.Save(helper);
                            TotalNumber = i;
                        }
                    }
                    #endregion
                    if (!ImportFailed)
                    {
                        helper.Commit();
                        msg += "<p>导入完成</p>";
                    }
                    else
                    {
                        helper.Rollback();
                        msg += "<p>导入失败</p>";
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.WriteError("ImportCustomerHandler", "visit: import", ex);
                    helper.Rollback();
                    msg += "<p>第" + (TotalNumber + 2) + "行上传失败。原因：" + ex.Message + "</p>";
                }
                context.Response.Write(msg);
            }
        }
        private bool GetColumnValue(string Title, DataTable table, int index, out object Value)
        {
            Value = null;
            bool result = false;
            if (!table.Columns.Contains(Title))
            {
                return false;
            }
            for (int i = 0; i < titleList.Length; i++)
            {
                if (titleList[i].ColumnName.Equals(Title))
                {
                    DataRow dr = table.Rows[index];
                    if (dr == null)
                    {
                        return false;
                    }
                    Value = dr[Title];
                    result = true;
                    break;
                }
            }
            return result;
        }
        Foresight.DataAccess.TableColumn[] titleList = new Foresight.DataAccess.TableColumn[] { };
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}