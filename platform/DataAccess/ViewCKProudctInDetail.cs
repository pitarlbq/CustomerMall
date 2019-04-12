using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Linq;
using Foresight.DataAccess.Framework;

namespace Foresight.DataAccess
{
    /// <summary>
    /// This object represents the properties and methods of a ViewCKProudctInDetail.
    /// </summary>
    public partial class ViewCKProudctInDetail : EntityBaseReadOnly
    {
        public int RestInventory
        {
            get
            {
                return ((this.InTotalCount > 0 ? this.InTotalCount : 0) - (this.TotalOutCount > 0 ? this.TotalOutCount : 0));
            }
        }
        public DateTime ApproveTime
        {
            get
            {
                if (ApproveStatus == int.MinValue)
                {
                    return DateTime.MinValue;
                }
                return this.ApproveStatus == 1 ? this.ApproveYesTime : DateTime.MinValue;
            }
        }
        public string ApproveStatusDesc
        {
            get
            {
                if (ApproveStatus == int.MinValue)
                {
                    return "未审核";
                }
                return this.ApproveStatus == 1 ? "已审核" : "未审核";
            }
        }
        public static Ui.DataGrid GetViewCKProudctInDetailGridByKeywords(string Keywords, DateTime StartTime, DateTime EndTime, string orderBy, long startRowIndex, int pageSize, int CKCategoryID, List<int> IDList = null, int ProductCategoryID = 0, bool canexport = false)
        {
            long totalRows = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (ProductCategoryID > 0)
            {
                conditions.Add("[ProductID] in (select ID from [CKProduct] where [CategoryID] in (select ID from CKProductCategory where ID=@ProductCategoryID))");
                parameters.Add(new SqlParameter("@ProductCategoryID", ProductCategoryID));
            }
            if (IDList != null && IDList.Count > 0)
            {
                conditions.Add("[ID] in (" + string.Join(",", IDList.ToArray()) + ")");
            }
            else
            {
                if (!string.IsNullOrEmpty(Keywords))
                {
                    conditions.Add("([AddUserName] like @Keywords or [OrderNumber] like @Keywords or [ContractName] like @Keywords or [WarehouseName] like @Keywords or [CategoryName] like @Keywords or [ProductName] like @Keywords or [ModelNumber] like @Keywords)");
                    parameters.Add(new SqlParameter("@Keywords", "%" + Keywords + "%"));
                }
                if (StartTime > DateTime.MinValue)
                {
                    conditions.Add("convert(nvarchar(10),[InTime],120)>=@StartTime");
                    parameters.Add(new SqlParameter("@StartTime", StartTime));
                }
                if (EndTime > DateTime.MinValue)
                {
                    conditions.Add("convert(nvarchar(10),[InTime],120)<=@EndTime");
                    parameters.Add(new SqlParameter("@EndTime", EndTime));
                }
                var CKCategoryIDList = new List<int>();
                if (CKCategoryID > 1)
                {
                    var child_categories = Foresight.DataAccess.CKCategory.GetCKCategoriesByParentID(CKCategoryID);
                    if (child_categories.Length > 0)
                    {
                        CKCategoryIDList = child_categories.Select(p => p.ID).ToList();
                    }
                    CKCategoryIDList.Add(CKCategoryID);
                }
                if (CKCategoryIDList.Count > 0)
                {
                    conditions.Add("[CKCategoryID] in (" + string.Join(",", CKCategoryIDList.ToArray()) + ")");
                }
            }
            string fieldList = "[ViewCKProudctInDetail].*";
            string Statement = " from [ViewCKProudctInDetail] where  " + string.Join(" and ", conditions.ToArray());
            ViewCKProudctInDetail[] list = new ViewCKProudctInDetail[] { };
            if (canexport)
            {
                list = GetList<ViewCKProudctInDetail>("select " + fieldList + Statement + " " + orderBy, parameters).ToArray();
            }
            else
            {
                list = GetList<ViewCKProudctInDetail>(fieldList, Statement, parameters, orderBy, startRowIndex, pageSize, out totalRows).ToArray();
            }
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
        public static Ui.DataGrid GetViewCKProudctInDetailGridBySummaryID(int SummaryID, int ServiceID, string orderBy, long startRowIndex, int pageSize, List<int> InIDList = null)
        {
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            long totalRows = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (InIDList != null && InIDList.Count > 0)
            {
                conditions.Add("[InSummaryID] in (" + string.Join(",", InIDList.ToArray()) + ")");
            }
            else if (SummaryID > 0)
            {
                conditions.Add("[InSummaryID]=@SummaryID");
                parameters.Add(new SqlParameter("@SummaryID", SummaryID));
            }
            else if (ServiceID > 0)
            {
                conditions.Add("[ServiceID]=@ServiceID");
                parameters.Add(new SqlParameter("@ServiceID", ServiceID));
            }
            else
            {
                dg.rows = new ViewCKProudctInDetail[] { };
                dg.total = 0;
                dg.page = 1;
                return dg;
            }
            string fieldList = "[ViewCKProudctInDetail].*";
            string Statement = " from [ViewCKProudctInDetail] where  " + string.Join(" and ", conditions.ToArray());
            ViewCKProudctInDetail[] list = new ViewCKProudctInDetail[] { };
            list = GetList<ViewCKProudctInDetail>(fieldList, Statement, parameters, orderBy, startRowIndex, pageSize, out totalRows).ToArray();
            dg.rows = new ViewCKProudctInDetail[] { };
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
        public static ViewCKProudctInDetail[] GetViewCKProudctInDetailListBySummaryID(int SummaryID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (SummaryID > 0)
            {
                conditions.Add("[InSummaryID]=@SummaryID");
                parameters.Add(new SqlParameter("@SummaryID", SummaryID));
            }
            string Statement = "select * from [ViewCKProudctInDetail] where  " + string.Join(" and ", conditions.ToArray());
            ViewCKProudctInDetail[] list = GetList<ViewCKProudctInDetail>(Statement, parameters).ToArray();
            return list;
        }
        public static ViewCKProudctInDetail[] GetViewCKProudctInDetailListByServiceID(int CustomerServiceID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (CustomerServiceID > 0)
            {
                conditions.Add("[ServiceID]=@CustomerServiceID");
                parameters.Add(new SqlParameter("@CustomerServiceID", CustomerServiceID));
            }
            string Statement = "select * from [ViewCKProudctInDetail] where  " + string.Join(" and ", conditions.ToArray());
            ViewCKProudctInDetail[] list = GetList<ViewCKProudctInDetail>(Statement, parameters).ToArray();
            return list;
        }
    }
}
