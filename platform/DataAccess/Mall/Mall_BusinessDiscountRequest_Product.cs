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
    /// This object represents the properties and methods of a Mall_BusinessDiscountRequest_Product.
    /// </summary>
    public partial class Mall_BusinessDiscountRequest_Product : EntityBase
    {
        public static Mall_BusinessDiscountRequest_Product[] GetMall_BusinessDiscountRequest_ProductListByBusinessDiscountRequestID(int BusinessDiscountRequestID, string GUID = "")
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            if (BusinessDiscountRequestID == 0 && string.IsNullOrEmpty(GUID))
            {
                return new Mall_BusinessDiscountRequest_ProductDetail[] { };
            }
            if (BusinessDiscountRequestID > 0)
            {
                conditions.Add("[BusinessDiscountRequestID]=@BusinessDiscountRequestID");
                parameters.Add(new SqlParameter("@BusinessDiscountRequestID", BusinessDiscountRequestID));
            }
            if (!string.IsNullOrEmpty(GUID))
            {
                conditions.Add("[Guid]=@Guid");
                parameters.Add(new SqlParameter("@Guid", GUID));
            }
            string cmdtext = "select * from [Mall_BusinessDiscountRequest_Product] where  " + string.Join(" or ", conditions.ToArray()) + " order by [ID] asc";
            var list = GetList<Mall_BusinessDiscountRequest_ProductDetail>(cmdtext, parameters).ToArray();
            return list;
        }
        public static Mall_BusinessDiscountRequest_Product[] GetMall_BusinessDiscountRequest_ProductListByIDList(List<int> IDList)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (IDList.Count == 0)
            {
                return new Mall_BusinessDiscountRequest_Product[] { };
            }
            conditions.Add("[ID] in (" + string.Join(",", IDList) + ")");
            return GetList<Mall_BusinessDiscountRequest_Product>("select * from [Mall_BusinessDiscountRequest_Product] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
        public static Mall_BusinessDiscountRequest_Product[] GetMall_BusinessDiscountRequest_ProductListByBusinessIDList(List<int> BusinessIDList)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            if (BusinessIDList.Count == 0)
            {
                return new Mall_BusinessDiscountRequest_Product[] { };
            }
            parameters.Add(new SqlParameter("@NowTime", DateTime.Now));
            conditions.Add("[BusinessDiscountRequestID] in (select ID from [Mall_BusinessDiscountRequest] where [Status]=2 and [StartTime]<=@NowTime and [EndTime]>=@NowTime)");
            conditions.Add("[BusinessID] in (" + string.Join(",", BusinessIDList) + ")");
            return GetList<Mall_BusinessDiscountRequest_Product>("select * from [Mall_BusinessDiscountRequest_Product] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
        public static Mall_BusinessDiscountRequest_Product GetMall_BusinessDiscountRequest_ProductListByBusinessID(int BusinessID, int ProductID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            if (BusinessID == 0 || ProductID == 0)
            {
                return null;
            }
            parameters.Add(new SqlParameter("@NowTime", DateTime.Now));
            conditions.Add("[BusinessDiscountRequestID] in (select ID from [Mall_BusinessDiscountRequest] where [Status]=2 and [StartTime]<=@NowTime and [EndTime]>=@NowTime)");
            conditions.Add("[BusinessID]=@BusinessID");
            conditions.Add("[ProductID]=@ProductID");
            parameters.Add(new SqlParameter("@BusinessID", BusinessID));
            parameters.Add(new SqlParameter("@ProductID", ProductID));
            return GetOne<Mall_BusinessDiscountRequest_Product>("select * from [Mall_BusinessDiscountRequest_Product] where " + string.Join(" and ", conditions.ToArray()), parameters);
        }
    }
    public partial class Mall_BusinessDiscountRequest_ProductDetail : Mall_BusinessDiscountRequest_Product
    {
        [DatabaseColumn("ProductName")]
        public string ProductName { get; set; }
        public decimal FinalPrice { get; set; }
        public int FinalInventory { get; set; }
        public static Mall_BusinessDiscountRequest_ProductDetail[] GetMall_BusinessDiscountRequest_ProductDetailListByBusinessDiscountRequestID(int BusinessDiscountRequestID, string GUID = "")
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            if (BusinessDiscountRequestID == 0 && string.IsNullOrEmpty(GUID))
            {
                return new Mall_BusinessDiscountRequest_ProductDetail[] { };
            }
            if (BusinessDiscountRequestID > 0)
            {
                conditions.Add("[BusinessDiscountRequestID]=@BusinessDiscountRequestID");
                parameters.Add(new SqlParameter("@BusinessDiscountRequestID", BusinessDiscountRequestID));
            }
            if (!string.IsNullOrEmpty(GUID))
            {
                conditions.Add("[Guid]=@Guid");
                parameters.Add(new SqlParameter("@Guid", GUID));
            }
            string cmdtext = "select * from [Mall_BusinessDiscountRequest_Product] where  " + string.Join(" or ", conditions.ToArray()) + " order by [ID] asc";
            var list = GetList<Mall_BusinessDiscountRequest_ProductDetail>(cmdtext, parameters).ToArray();
            if (list.Length == 0)
            {
                return list;
            }
            var ProductIDList = list.Select(p => p.ProductID).ToList();
            var product_list = Mall_ProductDetail.GetMall_ProductDetailListByIDList(ProductIDList);
            foreach (var item in list)
            {
                var my_product = product_list.FirstOrDefault(p => p.ID == item.ProductID);
                if (my_product != null)
                {
                    item.ProductName = my_product.ProductName;
                    item.FinalPrice = my_product.FinalSalePrice;
                    item.FinalInventory = my_product.Inventory;
                }
            }
            return list;
        }
    }
}
