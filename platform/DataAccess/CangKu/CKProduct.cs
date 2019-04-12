using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;

using Foresight.DataAccess.Framework;
using System.Text.RegularExpressions;

namespace Foresight.DataAccess
{
    /// <summary>
    /// This object represents the properties and methods of a CKProduct.
    /// </summary>
    public partial class CKProduct : EntityBase
    {
        public static CKProduct GetCKProductByProductNumber(string ProductNumber)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (!string.IsNullOrEmpty(ProductNumber))
            {
                conditions.Add("[ProductNumber]=@ProductNumber");
                parameters.Add(new SqlParameter("@ProductNumber", ProductNumber));
            }
            return GetOne<CKProduct>("select top 1 * from [CKProduct] where [ProductNumber]=@ProductNumber", parameters);
        }
        public static CKProduct GetCKProductByInDetailID(int InDetailID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (InDetailID > 0)
            {
                conditions.Add("[ID]=@InDetailID");
                parameters.Add(new SqlParameter("@InDetailID", InDetailID));
            }
            return GetOne<CKProduct>("select top 1 * from [CKProduct] where ID in (select ProductID from [CKProudctInDetail] where " + string.Join(" and ", conditions.ToArray()) + ")", parameters);
        }
        public static CKProduct[] GetCKProductListByKeywords(string Keywords)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (!string.IsNullOrEmpty(Keywords))
            {
                conditions.Add("[ProductName] like @Keywords");
                parameters.Add(new SqlParameter("@Keywords", "%" + Keywords + "%"));
            }
            return GetList<CKProduct>("select * from [CKProduct] where " + string.Join(" and ", conditions.ToArray()) + "order by [ProductName] collate Chinese_PRC_CS_AS_KS_WS", parameters).ToArray();
        }
        public static CKProduct GetLastCKProduct(SqlHelper helper)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            return GetOne<CKProduct>("select top 1 * from [CKProduct] order by [AddTime] desc", parameters, helper);
        }
        public static string GetLastestProductNumber()
        {
            using (SqlHelper helper = new SqlHelper())
            {
                return GetLastestProductNumber(helper);
            }
        }
        public static string GetLastestProductNumber(SqlHelper helper)
        {
            string cmdtext = "select top 1 * from CKProduct where isnull(ProductNumber,'') like 'WP_%' order by ProductNumber desc;";
            var ckproduct = GetOne<CKProduct>(cmdtext, new List<SqlParameter>(), helper);
            if (ckproduct == null)
            {
                return "WP_10000001";
            }
            string product_number = Regex.Replace(ckproduct.ProductNumber, @"[^\d]*", "");
            int product_number_int = 10000001;
            int.TryParse(product_number, out product_number_int);
            string new_product_number = (product_number_int + 1).ToString("D8");
            return "WP_" + new_product_number;
        }
    }
    public partial class CKProductDetail : CKProduct
    {
        [DatabaseColumn("TotalInventory")]
        public decimal TotalInventory { get; set; }
        public static CKProductDetail[] GetCKProductDetailList(string Keywords)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            string cmdwhere = string.Empty;
            if (!string.IsNullOrEmpty(Keywords))
            {
                cmdwhere += " and [CKProduct].[CategoryName] like '%" + Keywords + "%'";
            }
            return GetList<CKProductDetail>(@"select CKProduct.*,isnull(A.InTotalCount,0)-isnull(B.OutTotalCount,0) as TotalInventory from CKProduct
left join
(select ProductID,sum (isnull(InTotalCount,0)) as InTotalCount from CKProudctInDetail group by ProductID)A
on A.ProductID=CKProduct.ID
left join
(select ProductID,sum (isnull(OutTotalCount,0)) as OutTotalCount from CKProudctOutDetail group by ProductID)B
on B.ProductID=CKProduct.ID where 1=1" + cmdwhere, parameters).ToArray();
        }
    }
}
