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
    /// This object represents the properties and methods of a Mall_Product_Variant.
    /// </summary>
    public partial class Mall_Product_Variant : EntityBase
    {
        public static Mall_Product_Variant GetDefaultMall_Product_VarianByProductID(int ProductID)
        {
            if (ProductID <= 0)
            {
                return null;
            }
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[IsDefault]=1");
            conditions.Add("[ProductID]=@ProductID");
            parameters.Add(new SqlParameter("@ProductID", ProductID));
            string cmdtext = "select * from [Mall_Product_Variant] where  " + string.Join(" and ", conditions.ToArray());
            return GetOne<Mall_Product_Variant>(cmdtext, parameters);
        }
        public static Mall_Product_Variant[] GetMall_Product_VariantListByIDList(List<int> IDList)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (IDList.Count == 0)
            {
                return new Mall_Product_Variant[] { };
            }
            conditions.Add("[ID] in (" + string.Join(",", IDList.ToArray()) + ")");
            string cmdtext = "select * from [Mall_Product_Variant] where  " + string.Join(" and ", conditions.ToArray());
            return GetList<Mall_Product_Variant>(cmdtext, parameters).ToArray();
        }
        public static Mall_Product_Variant[] GetMall_Product_VariantListByProductID(int ProductID, string GUID = "", bool IncludeDefault = false)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (!IncludeDefault)
            {
                conditions.Add("isnull([IsDefault],0)=0");
            }
            if (ProductID == 0 && string.IsNullOrEmpty(GUID))
            {
                return new Mall_Product_Variant[] { };
            }
            if (ProductID > 0)
            {
                conditions.Add("[ProductID]=@ProductID");
                parameters.Add(new SqlParameter("@ProductID", ProductID));
            }
            if (!string.IsNullOrEmpty(GUID))
            {
                conditions.Add("[GUID]=@GUID");
                parameters.Add(new SqlParameter("@GUID", GUID));
            }
            string cmdtext = "select * from [Mall_Product_Variant] where  " + string.Join(" and ", conditions.ToArray()) + " order by [AddTime] desc";
            return GetList<Mall_Product_Variant>(cmdtext, parameters).ToArray();
        }
        public string FinalVariantTitle
        {
            get
            {
                return string.IsNullOrEmpty(this.VariantTitle) ? "规格" : this.VariantTitle;
            }
        }
    }
    public partial class Mall_Product_VariantDetail : Mall_Product_Variant
    {
        [DatabaseColumn("SaleCount")]
        public int SaleCount { get; set; }
        [DatabaseColumn("QuantityLimit")]
        public int QuantityLimit { get; set; }
        [DatabaseColumn("DiscountPrice")]
        public decimal DiscountPrice { get; set; }
        [DatabaseColumn("DiscountQuantity")]
        public int DiscountQuantity { get; set; }
        [DatabaseColumn("DiscountSaleCount")]
        public int DiscountSaleCount { get; set; }
        [DatabaseColumn("BusinessID")]
        public int BusinessID { get; set; }
        public bool IsDiscountEnable
        {
            get
            {
                return this.DiscountPrice > 0;
            }
        }
        public int VariantInventory
        {
            get
            {
                int count = this.Inventory - this.SaleCount;
                return (count > 0 ? count : 0);
            }
        }
        public int MaxQuantity
        {
            get
            {
                int quantitylimit = this.Inventory;
                if (this.QuantityLimit > 0 && this.QuantityLimit < this.Inventory)
                {
                    quantitylimit = this.QuantityLimit;
                }
                return (quantitylimit > 0 ? quantitylimit : 0);
            }
        }
        public decimal FinalVariantPrice
        {
            get
            {
                if (this.DiscountPrice > 0)
                {
                    if (this.DiscountQuantity > this.DiscountSaleCount)
                    {
                        return this.DiscountPrice;
                    }
                }
                if (this.VariantPrice > 0)
                {
                    return this.VariantPrice;
                }
                return 0;
            }
        }
        public static string ColumnSQLText = ",(select sum([Quantity]) from [Mall_OrderItem] where [OrderID] in (select ID from [Mall_Order] where isnull([IsClosed],0)!=1) and [ProductID]=[Mall_Product_Variant].ProductID and [VariantID]=[Mall_Product_Variant].[ID]) as SaleCount,(select QuantityLimit from [Mall_Product] where [ID]=[Mall_Product_Variant].ProductID) as QuantityLimit,(select sum([Quantity]) from [Mall_OrderItem] where [IsDiscountPrice]=1 and [OrderID] in (select ID from [Mall_Order] where isnull(IsClosed,0)=0) and [ProductID]=[Mall_Product_Variant].ProductID and [VariantID]=[Mall_Product_Variant].[ID]) as DiscountSaleCount,(select BusinessID from [Mall_Product] where [ID]=[Mall_Product_Variant].ProductID) as BusinessID";
        public static Mall_Product_VariantDetail[] GetMall_Product_VariantDetailListByProductID(int ProductID, bool IncludeDefault = true)
        {
            if (ProductID <= 0)
            {
                return new Mall_Product_VariantDetail[] { };
            }
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (!IncludeDefault)
            {
                conditions.Add("isnull([IsDefault],0)!=1");
            }
            conditions.Add("[ProductID]=@ProductID");
            parameters.Add(new SqlParameter("@ProductID", ProductID));
            string cmdtext = "select * " + ColumnSQLText + " from [Mall_Product_Variant] where  " + string.Join(" and ", conditions.ToArray());
            var list = GetList<Mall_Product_VariantDetail>(cmdtext, parameters).ToArray();
            list = GetMall_ProductVariantDetailPriceList(list);
            return list;
        }
        public static Mall_Product_VariantDetail[] GetMall_Product_VariantDetailListByProductIDList(List<int> ProductIDList, bool IncludeDefault = true)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (!IncludeDefault)
            {
                conditions.Add("isnull([IsDefault],0)!=1");
            }
            if (ProductIDList.Count == 0)
            {
                return new Mall_Product_VariantDetail[] { };
            }
            conditions.Add("[ProductID] in (" + string.Join(",", ProductIDList.ToArray()) + ")");
            string cmdtext = "select * " + ColumnSQLText + " from [Mall_Product_Variant] where  " + string.Join(" and ", conditions.ToArray());
            var list = GetList<Mall_Product_VariantDetail>(cmdtext, parameters).ToArray();
            list = GetMall_ProductVariantDetailPriceList(list);
            return list;
        }
        public static Mall_Product_VariantDetail[] GetMall_Product_VariantDetailListByIDList(List<int> IDList)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (IDList.Count == 0)
            {
                return new Mall_Product_VariantDetail[] { };
            }
            conditions.Add("[ID] in (" + string.Join(",", IDList.ToArray()) + ")");
            string cmdtext = "select * " + ColumnSQLText + " from [Mall_Product_Variant] where  " + string.Join(" and ", conditions.ToArray());
            var list = GetList<Mall_Product_VariantDetail>(cmdtext, parameters).ToArray();
            list = GetMall_ProductVariantDetailPriceList(list);
            return list;
        }
        public static Mall_Product_VariantDetail GetMall_Product_VariantDetailByID(int ID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (ID == 0)
            {
                return null;
            }
            conditions.Add("[ID]=@ID");
            parameters.Add(new SqlParameter("@ID", ID));
            string cmdtext = "select * " + ColumnSQLText + " from [Mall_Product_Variant] where  " + string.Join(" and ", conditions.ToArray());
            var data = GetOne<Mall_Product_VariantDetail>(cmdtext, parameters);
            data = GetMall_ProductVariantDetailPrice(data);
            return data;
        }
        public static Mall_Product_VariantDetail[] GetMall_ProductVariantDetailPriceList(Mall_Product_VariantDetail[] list)
        {
            if (list.Length > 0)
            {
                var BusinessIDList = list.Where(p => p.BusinessID > 0).Select(p => p.BusinessID).ToList();
                var discount_product_list = Mall_BusinessDiscountRequest_Product.GetMall_BusinessDiscountRequest_ProductListByBusinessIDList(BusinessIDList);
                foreach (var item in list)
                {
                    var my_discount_product = discount_product_list.FirstOrDefault(p => p.BusinessID == item.BusinessID && p.ProductID == item.ProductID);
                    if (my_discount_product != null)
                    {
                        item.DiscountPrice = my_discount_product.Price;
                        item.DiscountQuantity = my_discount_product.Quantity;
                    }
                }
            }
            return list;
        }
        public static Mall_Product_VariantDetail GetMall_ProductVariantDetailPrice(Mall_Product_VariantDetail data)
        {
            if (data != null && data.BusinessID > 0)
            {
                var my_discount_product = Mall_BusinessDiscountRequest_Product.GetMall_BusinessDiscountRequest_ProductListByBusinessID(data.BusinessID, data.ProductID);
                if (my_discount_product != null)
                {
                    data.DiscountPrice = my_discount_product.Price;
                    data.DiscountQuantity = my_discount_product.Quantity;
                }
            }
            return data;
        }
    }
}
