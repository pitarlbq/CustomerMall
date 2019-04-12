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
    /// This object represents the properties and methods of a ViewCKProudctOutDetail.
    /// </summary>
    public partial class ViewCKProudctOutDetail : EntityBaseReadOnly
    {
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
        public static Ui.DataGrid GetViewCKProudctOutDetailGridByKeywords(string Keywords, DateTime StartTime, DateTime EndTime, int DepartmentID, int CKCategoryID, string orderBy, long startRowIndex, int pageSize, List<int> IDList = null, int ProductCategoryID = 0, int AcceptUserID = 0, string DepartmentName = "", bool canexport = false)
        {
            long totalRows = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (AcceptUserID > 0)
            {
                conditions.Add("[AcceptUserID]=@AcceptUserID");
                parameters.Add(new SqlParameter("@AcceptUserID", AcceptUserID));
            }
            if (ProductCategoryID > 0)
            {
                conditions.Add("[ProductID] in (select ID from [CKProduct] where [CategoryID]=@ProductCategoryID)");
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
                    conditions.Add("([AddUserName] like @Keywords or [OrderNumber] like @Keywords or [WarehouseName] like @Keywords or [CategoryName] like @Keywords or [ProductName] like @Keywords or [ModelNumber] like @Keywords)");
                    parameters.Add(new SqlParameter("@Keywords", "%" + Keywords + "%"));
                }
                if (StartTime > DateTime.MinValue)
                {
                    conditions.Add("convert(nvarchar(10),[OutTime],120)>=@StartTime");
                    parameters.Add(new SqlParameter("@StartTime", StartTime));
                }
                if (EndTime > DateTime.MinValue)
                {
                    conditions.Add("convert(nvarchar(10),[OutTime],120)<=@EndTime");
                    parameters.Add(new SqlParameter("@EndTime", EndTime));
                }
                if (DepartmentID > 0)
                {
                    if (!string.IsNullOrEmpty(DepartmentName))
                    {
                        conditions.Add("([BelongDepartmentID]=@DepartmentID or [BelongTeamName] like @DepartmentName)");
                        parameters.Add(new SqlParameter("@DepartmentID", DepartmentID));
                        parameters.Add(new SqlParameter("@DepartmentName", "%" + DepartmentName + "%"));
                    }
                    else
                    {
                        conditions.Add("[BelongDepartmentID]=@DepartmentID");
                        parameters.Add(new SqlParameter("@DepartmentID", DepartmentID));
                    }
                }
                if (CKCategoryID > 0)
                {
                    conditions.Add("[CKCategoryID]=@CKCategoryID");
                    parameters.Add(new SqlParameter("@CKCategoryID", CKCategoryID));
                }
            }
            string fieldList = "[ViewCKProudctOutDetail].*";
            string Statement = " from [ViewCKProudctOutDetail] where  " + string.Join(" and ", conditions.ToArray());
            ViewCKProudctOutDetail[] list = new ViewCKProudctOutDetail[] { };
            if (canexport)
            {
                list = GetList<ViewCKProudctOutDetail>("select " + fieldList + Statement + " " + orderBy, parameters).ToArray();
            }
            else
            {
                list = GetList<ViewCKProudctOutDetail>(fieldList, Statement, parameters, orderBy, startRowIndex, pageSize, out totalRows).ToArray();
            }
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
        public static Ui.DataGrid GetViewCKProudctOutDetailGridBySummaryID(int SummaryID, string orderBy, long startRowIndex, int pageSize)
        {
            long totalRows = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (SummaryID > 0)
            {
                conditions.Add("[OutSummaryID]=@SummaryID");
                parameters.Add(new SqlParameter("@SummaryID", SummaryID));
            }
            string fieldList = "[ViewCKProudctOutDetail].*";
            string Statement = " from [ViewCKProudctOutDetail] where  " + string.Join(" and ", conditions.ToArray());
            ViewCKProudctOutDetail[] list = new ViewCKProudctOutDetail[] { };
            list = GetList<ViewCKProudctOutDetail>(fieldList, Statement, parameters, orderBy, startRowIndex, pageSize, out totalRows).ToArray();
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
        public static ViewCKProudctOutDetail[] GetViewCKProudctOutDetailListBySummaryID(int SummaryID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (SummaryID > 0)
            {
                conditions.Add("[OutSummaryID]=@SummaryID");
                parameters.Add(new SqlParameter("@SummaryID", SummaryID));
            }
            string Statement = "select * from [ViewCKProudctOutDetail] where  " + string.Join(" and ", conditions.ToArray());
            ViewCKProudctOutDetail[] list = GetList<ViewCKProudctOutDetail>(Statement, parameters).ToArray();
            return list;
        }
    }
}
