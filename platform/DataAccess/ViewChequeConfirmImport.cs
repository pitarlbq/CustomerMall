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
	/// This object represents the properties and methods of a ViewChequeConfirmImport.
	/// </summary>
	public partial class ViewChequeConfirmImport : EntityBaseReadOnly
	{
        public static ViewChequeConfirmImport[] GetViewChequeConfirmImportListByKeywords(string keywords, int TakeStatus, int ApproveStatus, int TransferStatus, List<int> SellerList, List<int> ProductList, List<int> DepartmentList, List<int> ProjectList)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (TakeStatus > 0)
            {
                conditions.Add("[TakeStatus]=@TakeStatus");
                parameters.Add(new SqlParameter("@TakeStatus", TakeStatus));
            }
            if (ApproveStatus > 0)
            {
                conditions.Add("[ApproveStatus]=@ApproveStatus");
                parameters.Add(new SqlParameter("@ApproveStatus", ApproveStatus));
            }
            if (TransferStatus > 0)
            {
                conditions.Add("[TransferStatus]=@TransferStatus");
                parameters.Add(new SqlParameter("@TransferStatus", TransferStatus));
            }
            if (SellerList.Count > 0)
            {
                conditions.Add("([SellerID] in (" + string.Join(",", SellerList.ToArray()) + "))");
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
            string fieldList = "select [ViewChequeConfirmImport].*,(select sum(isnull([TotalSummaryCost],0)) from [Cheque_InDetail] where [InSummaryID]=[ViewChequeConfirmImport].InSummaryID) as [ChequeTotalCost] from [ViewChequeConfirmImport] where  " + string.Join(" and ", conditions.ToArray());
            ViewChequeConfirmImport[] list = GetList<ViewChequeConfirmImport>(fieldList, parameters).ToArray();
            return list;
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
