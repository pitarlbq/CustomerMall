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
    /// This object represents the properties and methods of a ViewCKProudctInventory.
    /// </summary>
    public partial class ViewCKProudctInventory : EntityBaseReadOnly
    {
        [DatabaseColumn("DepartmentName")]
        public string DepartmentName { get; set; }
        public static Ui.DataGrid GetViewCKProudctInventoryGridByCategoryID(string Keywords, List<int> CategoryIDList, DateTime StartTime, DateTime EndTime, List<int> DepartmentIDList, bool IncludDepartment, string orderBy, long startRowIndex, int pageSize, int ProductCategoryID = 0, bool HideInventory = false, bool canexport = false)
        {
            long totalRows = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions1 = new List<string>();
            List<string> conditions2 = new List<string>();
            List<string> conditions3 = new List<string>();
            List<string> conditions4 = new List<string>();
            conditions1.Add(" isnull([ServiceID],0)=0 ");
            conditions2.Add(" 1=1 ");
            conditions3.Add("(isnull(InTotalCount,0)>0 or isnull(OutTotalCount,0)>0)");
            conditions4.Add(" (isnull(InTotalCount,0)>0 or isnull(OutTotalCount,0)>0) ");
            if (HideInventory)
            {
                conditions3.Add("(isnull(InTotalCount,0)-isnull(OutTotalCount,0)>0)");
                conditions4.Add("(isnull(InTotalCount,0)-isnull(OutTotalCount,0)>0)");
            }
            if (ProductCategoryID > 0)
            {
                conditions1.Add("ProductID in (select ID from [CKProduct] where CategoryID=@ProductCategoryID)");
                conditions2.Add("ProductID in (select ID from [CKProduct] where CategoryID=@ProductCategoryID)");
                conditions3.Add("CategoryID=@ProductCategoryID");
                parameters.Add(new SqlParameter("@ProductCategoryID", ProductCategoryID));
            }
            if (DepartmentIDList.Count > 0)
            {
                conditions1.Add("[InSummaryID] in (select [ID] from [CKProductInSumary] where isnull([BelongDepartmentID],0) in (" + string.Join(",", DepartmentIDList.ToArray()) + "))");
                conditions2.Add("[OutSummaryID] in (select [ID] from [CKProductOutSumary] where isnull([BelongDepartmentID],0) in (" + string.Join(",", DepartmentIDList.ToArray()) + "))");
                conditions4.Add("[ID] in (" + string.Join(",", DepartmentIDList.ToArray()) + ")");
            }
            if (StartTime > DateTime.MinValue)
            {
                conditions1.Add("[InSummaryID] in (select [ID] from [CKProductInSumary] where convert(nvarchar(10),[InTime],120)>=@StartTime)");
                conditions2.Add("[OutSummaryID] in (select [ID] from [CKProductOutSumary] where convert(nvarchar(10),[OutTime],120)>=@StartTime)");
                parameters.Add(new SqlParameter("@StartTime", StartTime.ToString("yyyy-MM-dd")));
            }
            if (EndTime > DateTime.MinValue)
            {
                conditions1.Add("[InSummaryID] in (select [ID] from [CKProductInSumary] where convert(nvarchar(10),[InTime],120)<=@EndTime)");
                conditions2.Add("[OutSummaryID] in (select [ID] from [CKProductOutSumary] where convert(nvarchar(10),[OutTime],120)<=@EndTime)");
                parameters.Add(new SqlParameter("@EndTime", EndTime.ToString("yyyy-MM-dd")));
            }
            if (CategoryIDList.Count > 0)
            {
                conditions1.Add("[InSummaryID] in (select [ID] from [CKProductInSumary] where isnull([CKCategoryID],0) in (" + string.Join(",", CategoryIDList.ToArray()) + "))");
                conditions2.Add("[OutSummaryID] in (select [ID] from [CKProductOutSumary] where isnull([CKCategoryID],0) in (" + string.Join(",", CategoryIDList.ToArray()) + "))");
                conditions3.Add("([ID] in (select ProductID from [CKProudctInDetail] where [InSummaryID] in (select [ID] from [CKProductInSumary] where isnull([CKCategoryID],0) in (" + string.Join(",", CategoryIDList.ToArray()) + "))) or  [ID] in (select ProductID from [CKProudctOutDetail] where [OutSummaryID] in (select [ID] from [CKProductOutSumary] where isnull([CKCategoryID],0) in (" + string.Join(",", CategoryIDList.ToArray()) + "))))");
            }
            if (!string.IsNullOrEmpty(Keywords))
            {
                conditions1.Add("([ProductID] in (select [ID] from [CKProduct] where ([ProductNumber] like @Keywords or [ProductName] like @Keywords or [Unit] like @Keywords or [ModelNumber] like @Keywords)) or [ProductID] in (select ID from CKProduct where CategoryID in (select ID from CKProductCategory where ProductCategoryName like @Keywords)) or [InSummaryID] in (select [ID] from [CKProductInSumary] where [CKCategoryID] in (select ID from [CKCategory] where [CategoryName] like @Keywords)))");
                conditions2.Add("([ProductID] in (select [ID] from [CKProduct] where ([ProductNumber] like @Keywords or [ProductName] like @Keywords or [Unit] like @Keywords or [ModelNumber] like @Keywords)) or [ProductID] in (select ID from CKProduct where CategoryID in (select ID from CKProductCategory where ProductCategoryName like @Keywords)) or [OutSummaryID] in (select [ID] from [CKProductOutSumary] where [CKCategoryID] in (select ID from [CKCategory] where [CategoryName] like @Keywords)))");
                conditions3.Add("([ProductNumber] like @Keywords or [ProductName] like @Keywords or [Unit] like @Keywords or [ModelNumber] like @Keywords or [CategoryName] like @Keywords)");
                parameters.Add(new SqlParameter("@Keywords", "%" + Keywords + "%"));
                conditions4.Add("[DepartmentName] like @Keywords");
            }
            string fieldList = string.Empty;
            string Statement = string.Empty;
            if (IncludDepartment)
            {
                fieldList = "C.*,0 as CategoryID,'' as ProductNumber,'' as ProductName,'' as Unit,'' as ModelNumber,''as CategoryName";
                Statement = @" from (select ID,DepartmentName,AA.InTotalCount,AA.InTotalPrice,BB.OutTotalCount,BB.OutTotalPrice from CKDepartment
left join 
(select BelongDepartmentID, SUM(InTotalCount) AS InTotalCount, SUM(InTotalPrice) AS InTotalPrice
FROM (select *,(select BelongDepartmentID from CKProductInSumary
where CKProductInSumary.ID=CKProudctInDetail.InSummaryID	 
) as BelongDepartmentID from dbo.CKProudctInDetail where " + string.Join(" and ", conditions1.ToArray()) + @")A group by A.BelongDepartmentID)AA
on  AA.BelongDepartmentID=CKDepartment.ID
left join 
(select BelongDepartmentID, SUM(OutTotalCount) AS OutTotalCount, SUM(OutTotalPrice) AS OutTotalPrice
FROM (select *,(select BelongDepartmentID from CKProductOutSumary
where CKProductOutSumary.ID=CKProudctOutDetail.OutSummaryID	 
) as BelongDepartmentID from dbo.CKProudctOutDetail where " + string.Join(" and ", conditions2.ToArray()) + @")B group by B.BelongDepartmentID)BB
on  AA.BelongDepartmentID=CKDepartment.ID
UNION ALL
select 0 as DepartmentID, '未定义' as DepartmentName,
(select SUM(InTotalCount) AS InTotalCount
FROM (select *,(select BelongDepartmentID from CKProductInSumary
where CKProductInSumary.ID=CKProudctInDetail.InSummaryID	 
) as BelongDepartmentID from dbo.CKProudctInDetail where " + string.Join(" and ", conditions1.ToArray()) + @")A where isnull(A.BelongDepartmentID,0)=0)
as InTotalCount,
(select SUM(InTotalPrice) AS InTotalCount
FROM (select *,(select BelongDepartmentID from CKProductInSumary
where CKProductInSumary.ID=CKProudctInDetail.InSummaryID	 
) as BelongDepartmentID from dbo.CKProudctInDetail where " + string.Join(" and ", conditions1.ToArray()) + @")A where isnull(A.BelongDepartmentID,0)=0)
as InTotalPrice,
(select SUM(OutTotalCount) AS OutTotalCount
FROM (select *,(select BelongDepartmentID from CKProductOutSumary
where CKProductOutSumary.ID=CKProudctOutDetail.OutSummaryID	 
) as BelongDepartmentID from dbo.CKProudctOutDetail where " + string.Join(" and ", conditions2.ToArray()) + @")A where isnull(A.BelongDepartmentID,0)=0)
as OutTotalCount,
(select SUM(OutTotalPrice) AS OutTotalPrice
FROM (select *,(select BelongDepartmentID from CKProductOutSumary
where CKProductOutSumary.ID=CKProudctOutDetail.OutSummaryID	 
) as BelongDepartmentID from dbo.CKProudctOutDetail where " + string.Join(" and ", conditions2.ToArray()) + @")A where isnull(A.BelongDepartmentID,0)=0)
as OutTotalPrice
) C  where " + string.Join(" and ", conditions4.ToArray());
            }
            else
            {
                fieldList = "C.*";
                Statement = @" from (SELECT dbo.CKProduct.ID, dbo.CKProduct.CategoryID, dbo.CKProduct.ProductNumber, dbo.CKProduct.ProductName, 
                dbo.CKProduct.Unit, dbo.CKProduct.ModelNumber, dbo.CKProductCategory.ProductCategoryName as CategoryName, A.InTotalCount, A.InTotalPrice, 
                B.OutTotalCount, B.OutTotalPrice
FROM      dbo.CKProduct LEFT OUTER JOIN
                    (SELECT   ProductID, SUM(InTotalCount) AS InTotalCount, SUM(InTotalPrice) AS InTotalPrice
                     FROM      dbo.CKProudctInDetail where " + string.Join(" and ", conditions1.ToArray()) + @" 
                     GROUP BY ProductID) AS A ON A.ProductID = dbo.CKProduct.ID LEFT OUTER JOIN
                    (SELECT   ProductID, SUM(OutTotalCount) AS OutTotalCount, SUM(OutTotalPrice) AS OutTotalPrice
                     FROM      dbo.CKProudctOutDetail where " + string.Join(" and ", conditions2.ToArray()) + @" 
                     GROUP BY ProductID) AS B ON B.ProductID = dbo.CKProduct.ID LEFT OUTER JOIN
                dbo.CKProductCategory ON dbo.CKProductCategory.ID = dbo.CKProduct.CategoryID) C  where " + string.Join(" and ", conditions3.ToArray());
            }
            ViewCKProudctInventory[] list = new ViewCKProudctInventory[] { };
            if (canexport)
            {
                list = GetList<ViewCKProudctInventory>("select " + fieldList + Statement + " " + orderBy, parameters).ToArray();
                totalRows = list.Length;
            }
            else
            {
                list = GetList<ViewCKProudctInventory>(fieldList, Statement, parameters, orderBy, startRowIndex, pageSize, out totalRows).ToArray();
            }
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
        public decimal ArvUnitPrice
        {
            get
            {
                if (this.InTotalCount <= 0 || this.InTotalPrice <= 0)
                {
                    return 0;
                }
                return Math.Round((decimal)(this.InTotalPrice / this.InTotalCount), 2, MidpointRounding.AwayFromZero);
            }
        }
        public decimal ArvInUnitPrice
        {
            get
            {
                decimal in_total_price = this.InTotalPrice > 0 ? this.InTotalPrice : 0;
                decimal in_total_count = this.InTotalCount > 0 ? this.InTotalCount : 1;
                return Math.Round(in_total_price / in_total_count, 2, MidpointRounding.AwayFromZero);
            }
        }
        public decimal ArvOutUnitPrice
        {
            get
            {
                decimal out_total_price = this.OutTotalPrice > 0 ? this.OutTotalPrice : 0;
                decimal out_total_count = this.OutTotalCount > 0 ? this.OutTotalCount : 1;
                return Math.Round(out_total_price / out_total_count, 2, MidpointRounding.AwayFromZero);
            }
        }
        public decimal FinalTotalCost
        {
            get
            {
                return Math.Round(this.ArvUnitPrice * this.Inventory, 2, MidpointRounding.AwayFromZero);
            }
        }
        public int Inventory
        {
            get
            {
                int _InTotalCount = this.InTotalCount < 0 ? 0 : this.InTotalCount;
                int _OutTotalCount = this.OutTotalCount < 0 ? 0 : this.OutTotalCount;
                int _Inventory = _InTotalCount - _OutTotalCount;
                return _Inventory < 0 ? 0 : _Inventory;
            }
        }
    }

    public partial class ViewCKMaterialAnalysis : EntityBaseReadOnly
    {
        [DatabaseColumn("ID")]
        public int ID { get; set; }
        [DatabaseColumn("ProductName")]
        public string ProductName { get; set; }
        [DatabaseColumn("CategoryName")]
        public string CategoryName { get; set; }
        [DatabaseColumn("Unit")]
        public string Unit { get; set; }
        [DatabaseColumn("TotalPrice")]
        public decimal TotalPrice { get; set; }
        [DatabaseColumn("TotalCount")]
        public decimal TotalCount { get; set; }
        public decimal ArvUnitPrice
        {
            get
            {
                if (this.TotalCount <= 0 || this.TotalPrice <= 0)
                {
                    return 0;
                }
                return Math.Round((decimal)(this.TotalPrice / this.TotalCount), 2, MidpointRounding.AwayFromZero);
            }
        }
        public static Ui.DataGrid GetViewCKMaterialAnalysisGridBy(string Keywords, List<int> CategoryIDList, DateTime StartTime, DateTime EndTime, string orderBy, long startRowIndex, int pageSize, bool canexport = false)
        {
            long totalRows = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            List<string> conditions1 = new List<string>();
            conditions.Add("1=1");
            conditions1.Add("1=1");
            if (StartTime > DateTime.MinValue)
            {
                conditions.Add("[ID] in (select [ProductID] from [CKProudctInDetail] where [ServiceID] in (select [ID] from [CustomerService] where convert(nvarchar(10),[AddTime],120)>=@StartTime))");
                conditions1.Add("[ServiceID] in (select [ID] from [CustomerService] where convert(nvarchar(10),[AddTime],120)>=@StartTime)");
                parameters.Add(new SqlParameter("@StartTime", StartTime.ToString("yyyy-MM-dd")));
            }
            if (EndTime > DateTime.MinValue)
            {
                conditions.Add("[ID] in (select [ProductID] from [CKProudctInDetail] where [ServiceID] in (select [ID] from [CustomerService] where convert(nvarchar(10),[AddTime],120)<=@EndTime))");
                conditions1.Add("[ServiceID] in (select [ID] from [CustomerService] where convert(nvarchar(10),[AddTime],120)<=@EndTime)");
                parameters.Add(new SqlParameter("@EndTime", EndTime.ToString("yyyy-MM-dd")));
            }
            if (CategoryIDList.Count > 0)
            {
                conditions.Add("[CategoryID] in (" + string.Join(",", CategoryIDList.ToArray()) + ")");
                conditions1.Add("[ProductID] in (select ID from [CKProduct] where [CategoryID] in (" + string.Join(",", CategoryIDList.ToArray()) + "))");
            }
            if (!string.IsNullOrEmpty(Keywords))
            {
                conditions.Add("([ProductNumber] like @Keywords or [ProductName] like @Keywords or [Unit] like @Keywords or [ModelNumber] like @Keywords or CategoryID in (select ID from CKCategory where [CategoryName] like @Keywords))");
                parameters.Add(new SqlParameter("@Keywords", "%" + Keywords + "%"));
            }
            string fieldList = "[A].*";
            string Statement = " from (select ID, ProductName,Unit,(select CategoryName from CKCategory where CKCategory.ID=CKProduct.CategoryID) as CategoryName,(select sum(isnull(InTotalCount,0)) from CKProudctInDetail where ProductID=CKProduct.ID and isnull(ServiceID,0)>0 and " + string.Join(" and ", conditions1.ToArray()) + ") as TotalCount,(select sum(isnull(InTotalPrice,0)) from CKProudctInDetail where ProductID=CKProduct.ID and isnull(ServiceID,0)>0 and " + string.Join(" and ", conditions1.ToArray()) + ") as TotalPrice from CKProduct where  " + string.Join(" and ", conditions.ToArray()) + ")A where (isnull(TotalCount,0)>0 or isnull(TotalPrice,0)>0)";
            ViewCKMaterialAnalysis[] list = new ViewCKMaterialAnalysis[] { };
            if (canexport)
            {
                list = GetList<ViewCKMaterialAnalysis>("select " + fieldList + Statement + " " + orderBy, parameters).ToArray();
                totalRows = list.Length;
            }
            else
            {
                list = GetList<ViewCKMaterialAnalysis>(fieldList, Statement, parameters, orderBy, startRowIndex, pageSize, out totalRows).ToArray();
            }
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
        protected override void EnsureParentProperties()
        {
        }
    }
}
