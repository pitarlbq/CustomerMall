using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;

using Foresight.DataAccess.Framework;

namespace Foresight.DataAccess
{
    /// <summary>
    /// This object represents the properties and methods of a ViewChequeOutSummary.
    /// </summary>
    public partial class ViewChequeOutSummary : EntityBaseReadOnly
    {
        [DatabaseColumn("ChequeTotalCost")]
        public decimal ChequeTotalCost { get; set; }
        public static Ui.DataGrid GetViewChequeOutSummaryGridByKeywords(string keywords, List<int> SellerList, List<int> ProductList, List<int> DepartmentList, List<int> ProjectList, DateTime StartTime, DateTime EndTime, string ChequeCode, string orderBy, long startRowIndex, int pageSize)
        {
            long totalRows = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (StartTime > DateTime.MinValue)
            {
                conditions.Add("CONVERT(varchar(100), [ChequeTime], 23)>=@StartTime");
                parameters.Add(new SqlParameter("@StartTime", StartTime));
            }
            if (EndTime > DateTime.MinValue)
            {
                conditions.Add("CONVERT(varchar(100), [ChequeTime], 23)<=@EndTime");
                parameters.Add(new SqlParameter("@EndTime", EndTime));
            }
            if (!string.IsNullOrEmpty(ChequeCode))
            {
                conditions.Add("[ChequeCode] like @ChequeCode");
                parameters.Add(new SqlParameter("@ChequeCode", "%" + ChequeCode + "%"));
            }
            if (SellerList.Count > 0)
            {
                conditions.Add("([SellerID] in (" + string.Join(",", SellerList.ToArray()) + "))");
            }
            if (ProductList.Count > 0)
            {
                conditions.Add("[ProductID] in (" + string.Join(",", ProductList.ToArray()) + ")");
            }
            if (DepartmentList.Count > 0)
            {
                conditions.Add("([DepartmentID] in (" + string.Join(",", DepartmentList.ToArray()) + "))");
            }
            if (ProjectList.Count > 0)
            {
                conditions.Add("([ProjectID] in (" + string.Join(",", ProjectList.ToArray()) + "))");
            }
            if (!string.IsNullOrEmpty(keywords))
            {
                conditions.Add("([DepartmentName] like @keywords or [ProjectName] like @keywords or [SellerName] like @keywords or [SellerTaxNumber] like @keywords or [SellerAddressPhone] like @keywords or [SellerBankAccount] like @keywords)");
                parameters.Add(new SqlParameter("@keywords", "%" + keywords + "%"));
            }
            string fieldList = "[ViewChequeOutSummary].*,(select sum(isnull([TotalSummaryCost],0)) from [Cheque_OutDetail] where [OutSummaryID]=[ViewChequeOutSummary].ID) as [ChequeTotalCost]";
            string Statement = " from [ViewChequeOutSummary] where  " + string.Join(" and ", conditions.ToArray());
            ViewChequeOutSummary[] list = GetList<ViewChequeOutSummary>(fieldList, Statement, parameters, orderBy, startRowIndex, pageSize, out totalRows).ToArray();
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            string footerttext = "select sum(isnull([TotalCost],0)) as TotalCost,sum(isnull([TotalTaxCost],0)) as TotalTaxCost,sum(isnull([TotalCount],0)) as TotalCount,(select sum(isnull([TotalSummaryCost],0)) from [Cheque_OutDetail] where [Cheque_OutDetail].OutSummaryID in (select ID from [ViewChequeOutSummary] where " + string.Join(" and ", conditions.ToArray()) + ")) as ChequeTotalCost from [ViewChequeOutSummary] where  " + string.Join(" and ", conditions.ToArray());
            dg.footer = GetList<ViewChequeOutSummary>(footerttext, parameters).ToArray();
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
        public static ViewChequeOutSummary[] GetViewChequeOutSummaryListByKeywords(string keywords, List<int> SellerList, List<int> ProductList, List<int> DepartmentList, List<int> ProjectList, DateTime StartTime, DateTime EndTime, string ChequeCode)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (StartTime > DateTime.MinValue)
            {
                conditions.Add("CONVERT(varchar(100), [ChequeTime], 23)>=@StartTime");
                parameters.Add(new SqlParameter("@StartTime", StartTime));
            }
            if (EndTime > DateTime.MinValue)
            {
                conditions.Add("CONVERT(varchar(100), [ChequeTime], 23)<=@EndTime");
                parameters.Add(new SqlParameter("@EndTime", EndTime));
            }
            if (!string.IsNullOrEmpty(ChequeCode))
            {
                conditions.Add("[ChequeCode] like @ChequeCode");
                parameters.Add(new SqlParameter("@ChequeCode", "%" + ChequeCode + "%"));
            }
            if (SellerList.Count > 0)
            {
                conditions.Add("([SellerID] in (" + string.Join(",", SellerList.ToArray()) + "))");
            }
            if (ProductList.Count > 0)
            {
                conditions.Add("[ID] in (select [InSummaryID] from [Cheque_InDetail] where [ProductID] in (" + string.Join(",", ProductList.ToArray()) + "))");
            }
            if (DepartmentList.Count > 0)
            {
                conditions.Add("([DepartmentID] in (" + string.Join(",", DepartmentList.ToArray()) + "))");
            }
            if (ProjectList.Count > 0)
            {
                conditions.Add("([ProjectID] in (" + string.Join(",", ProjectList.ToArray()) + "))");
            }
            if (!string.IsNullOrEmpty(keywords))
            {
                conditions.Add("([DepartmentName] like @keywords or [ProjectName] like @keywords or [SellerName] like @keywords or [SellerTaxNumber] like @keywords or [SellerAddressPhone] like @keywords or [SellerBankAccount] like @keywords)");
                parameters.Add(new SqlParameter("@keywords", "%" + keywords + "%"));
            }
            string Statement = "select *,(select sum(isnull([TotalSummaryCost],0)) from [Cheque_OutDetail] where [OutSummaryID]=[ViewChequeOutSummary].ID) as [ChequeTotalCost] from [ViewChequeOutSummary] where  " + string.Join(" and ", conditions.ToArray());
            ViewChequeOutSummary[] list = GetList<ViewChequeOutSummary>(Statement, parameters).ToArray();
            return list;
        }
    }
}
