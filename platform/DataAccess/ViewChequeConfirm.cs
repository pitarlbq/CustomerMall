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
    /// This object represents the properties and methods of a ViewChequeConfirm.
    /// </summary>
    public partial class ViewChequeConfirm : EntityBaseReadOnly
    {
        [DatabaseColumn("ChequeTotalCost")]
        public decimal ChequeTotalCost { get; set; }
        public static Ui.DataGrid GetViewChequeConfirmGridByKeywords(string keywords, int TakeStatus, int ApproveStatus, int TransferStatus, List<int> SellerList, List<int> ProductList, List<int> DepartmentList, List<int> ProjectList, string orderBy, long startRowIndex, int pageSize)
        {
            long totalRows = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (TakeStatus > 0)
            {
                conditions.Add("isnull([TakeStatus],0)=@TakeStatus");
                parameters.Add(new SqlParameter("@TakeStatus", TakeStatus));
            }
            if (ApproveStatus > 0)
            {
                conditions.Add("isnull([ApproveStatus],0)=@ApproveStatus");
                parameters.Add(new SqlParameter("@ApproveStatus", ApproveStatus));
            }
            if (TransferStatus > 0)
            {
                conditions.Add("isnull([TransferStatus],0)=@TransferStatus");
                parameters.Add(new SqlParameter("@TransferStatus", TransferStatus));
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
            string fieldList = "[ViewChequeConfirm].*,(select sum(isnull([TotalSummaryCost],0)) from [Cheque_InDetail] where [InSummaryID]=[ViewChequeConfirm].InSummaryID) as [ChequeTotalCost]";
            string Statement = " from [ViewChequeConfirm] where  " + string.Join(" and ", conditions.ToArray());
            ViewChequeConfirm[] list = GetList<ViewChequeConfirm>(fieldList, Statement, parameters, orderBy, startRowIndex, pageSize, out totalRows).ToArray();
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
        public string ApproveStatusDesc
        {
            get
            {
                return this.ApproveStatus > 0 ? "已认证" : "未认证";
            }
        }
        public string TakeStatusDesc
        {
            get
            {
                return this.TakeStatus > 0 ? "已交接" : "未交接";
            }
        }
        public string TransferStatusDesc
        {
            get
            {
                return this.TransferStatus > 0 ? "已转出" : "未转出";
            }
        }
    }
}
