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
    /// This object represents the properties and methods of a ViewCKProductCategory.
    /// </summary>
    public partial class ViewCKProductCategory : EntityBaseReadOnly
    {
        [DatabaseColumn("TotalInventory")]
        public decimal TotalInventory { get; set; }
        public static Ui.DataGrid GetViewCKProductCategoryGridByKeywords(string Keywords, List<int> CategoryIDList, int ProductID, bool ShowTotalInventory, string orderBy, long startRowIndex, int pageSize, int CKCategoryID = 0, bool canexport = false)
        {
            long totalRows = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            string cmdwhere_in = string.Empty;
            string cmdwhere_out = string.Empty;
            if (CKCategoryID > 0)
            {
                conditions.Add("[ID] in (select [ProductID] from [CKProudctInDetail] where [InSummaryID] in (select ID from [CKProductInSumary] where [CKCategoryID]=@CKCategoryID))");
                parameters.Add(new SqlParameter("@CKCategoryID", CKCategoryID));
                cmdwhere_in += " and [InSummaryID] in (select ID from [CKProductInSumary] where [CKCategoryID]=@CKCategoryID)";
                cmdwhere_out += " and [OutSummaryID] in (select ID from [CKProductOutSumary] where [CKCategoryID]=@CKCategoryID)";
            }
            if (!string.IsNullOrEmpty(Keywords))
            {
                conditions.Add("([ProductNumber] like @Keywords or [ProductName] like @Keywords or [ProductCategoryName] like @Keywords)");
                parameters.Add(new SqlParameter("@Keywords", "%" + Keywords + "%"));
            }
            if (CategoryIDList.Count > 0)
            {
                conditions.Add("[CategoryID] in (" + string.Join(",", CategoryIDList.ToArray()) + ")");
            }
            if (ProductID > 0)
            {
                conditions.Add("[ID]=@ProductID");
                parameters.Add(new SqlParameter("@ProductID", ProductID));
            }
            string fieldList = string.Empty;
            string Statement = string.Empty;
            if (ShowTotalInventory)
            {
                fieldList = "C.*";
                Statement = @" from (select [ViewCKProductCategory].*, isnull(A.InTotalCount,0)-isnull(B.OutTotalCount,0) as TotalInventory from [ViewCKProductCategory] left join
(select ProductID,sum (isnull(InTotalCount,0)) as InTotalCount from CKProudctInDetail where 1=1 " + cmdwhere_in + @" group by ProductID)A
on A.ProductID=[ViewCKProductCategory].ID
left join
(select ProductID,sum (isnull(OutTotalCount,0)) as OutTotalCount from CKProudctOutDetail where 1=1 " + cmdwhere_out + @" group by ProductID)B
on B.ProductID=[ViewCKProductCategory].ID) C where  " + string.Join(" and ", conditions.ToArray());
            }
            else
            {
                fieldList = "[ViewCKProductCategory].*";
                Statement = @" from [ViewCKProductCategory] where  " + string.Join(" and ", conditions.ToArray());
            }

            ViewCKProductCategory[] list = new ViewCKProductCategory[] { };

            if (canexport)
            {
                list = GetList<ViewCKProductCategory>("select " + fieldList + Statement + " " + orderBy, parameters).ToArray();
                totalRows = list.Length;
            }
            else
            {
                list = GetList<ViewCKProductCategory>(fieldList, Statement, parameters, orderBy, startRowIndex, pageSize, out totalRows).ToArray();
            }
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
    }
}
