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
    /// This object represents the properties and methods of a Mall_ShoppingCart.
    /// </summary>
    public partial class Mall_ShoppingCart : EntityBase
    {
        public static Mall_ShoppingCart[] GetMall_ShoppingCartListByBusinessUserID(int UserID, int minday, int maxday)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            conditions.Add("[UserID] not in (select [UserID] from [Mall_Order] where [OrderStatus]=3)");
            if (UserID <= 0)
            {
                return new Mall_ShoppingCart[] { };
            }
            if (maxday > 0)
            {
                conditions.Add("[AddTime]>=@AddTime");
                parameters.Add(new SqlParameter("@AddTime", DateTime.Today.AddDays(-maxday)));
            }
            if (minday > 0)
            {
                conditions.Add("[AddTime]<@AddTime");
                parameters.Add(new SqlParameter("@AddTime", DateTime.Today.AddDays(-minday)));
            }
            conditions.Add("[ProductID] in (select [ID] from [Mall_Product] where [BusinessID] in (select [ID] from [Mall_Business] where [UserID]=@UserID))");
            parameters.Add(new SqlParameter("@UserID", UserID));
            return GetList<Mall_ShoppingCart>("select [UserID],[AddTime] from [Mall_ShoppingCart] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
        public static Mall_ShoppingCart[] GetMall_ShoppingCartListByTime(DateTime StartTime, DateTime EndTime)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            conditions.Add("[UserID] not in (select [UserID] from [Mall_Order] where [OrderStatus]=3)");
            if (StartTime > DateTime.MinValue)
            {
                conditions.Add("Convert(varchar(100),[AddTime],23)>=@StartTime");
                parameters.Add(new SqlParameter("@StartTime", StartTime));
            }
            if (EndTime > DateTime.MinValue)
            {
                conditions.Add("Convert(varchar(100),[AddTime],23)<=@EndTime");
                parameters.Add(new SqlParameter("@EndTime", EndTime));
            }
            return GetList<Mall_ShoppingCart>("select [ID], [UserID],[AddTime] from [Mall_ShoppingCart] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
        public static Mall_ShoppingCart[] GetMall_ShoppingCartListByIDList(List<int> IDList, int UserID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (UserID <= 0)
            {
                return new Mall_ShoppingCart[] { };
            }
            conditions.Add("[UserID]=@UserID");
            parameters.Add(new SqlParameter("@UserID", UserID));
            conditions.Add("[ID] in (" + string.Join(",", IDList.ToArray()) + ")");
            return GetList<Mall_ShoppingCart>("select * from [Mall_ShoppingCart] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
        public static Mall_ShoppingCart[] GetMall_ShoppingCartListByUserID(int UserID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (UserID <= 0)
            {
                return new Mall_ShoppingCart[] { };
            }
            conditions.Add("[UserID]=@UserID");
            parameters.Add(new SqlParameter("@UserID", UserID));
            return GetList<Mall_ShoppingCart>("select * from [Mall_ShoppingCart] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
        public static int GetTotalCount(int UserID)
        {
            int total = 0;
            string cmdtext = @"select count(1) from [Mall_ShoppingCart] where [UserID]=@UserID and [ProductID] in (select ID from [Mall_Product] where [Status]=10)";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@UserID", UserID));
            using (SqlHelper helper = new SqlHelper())
            {
                var Total = helper.ExecuteScalar(cmdtext, CommandType.Text, parameters);
                if (Total != null)
                {
                    int.TryParse(Total.ToString(), out total);
                }
            }
            return total;
        }
        public static Mall_ShoppingCart GetMall_ShoppingCartByProductID(int ProductID, int VariantID, int UserID, int ProductOrderType)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (UserID <= 0)
            {
                return new Mall_ShoppingCart();
            }
            if (ProductOrderType > 0)
            {
                conditions.Add("[ProductOrderType]=@ProductOrderType");
                parameters.Add(new SqlParameter("@ProductOrderType", ProductOrderType));
            }
            conditions.Add("[UserID]=@UserID");
            parameters.Add(new SqlParameter("@UserID", UserID));
            if (ProductID <= 0)
            {
                return new Mall_ShoppingCart();
            }
            conditions.Add("[ProductID]=@ProductID");
            parameters.Add(new SqlParameter("@ProductID", ProductID));
            if (VariantID > 0)
            {
                conditions.Add("[VariantID]=@VariantID");
                parameters.Add(new SqlParameter("@VariantID", VariantID));
            }
            return GetOne<Mall_ShoppingCart>("select * from [Mall_ShoppingCart] where " + string.Join(" and ", conditions.ToArray()), parameters);
        }
        public static void DeleteMall_ShoppingCartListByIDList(List<int> IDList)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (IDList.Count == 0)
            {
                return;
            }
            conditions.Add("[ID] in (" + string.Join(",", IDList.ToArray()) + ")");
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    helper.Execute("delete from [Mall_ShoppingCart] where " + string.Join(" and ", conditions.ToArray()), CommandType.Text, new List<SqlParameter>());
                    helper.Commit();
                }
                catch (Exception)
                {
                    helper.Rollback();
                }
            }
        }
        public static List<Dictionary<string, object>> getshoppingcartitems(Mall_ShoppingCart[] list, Mall_ProductDetail[] products, Mall_Product_VariantDetail[] product_variants, int BusinessID, string context_path, out decimal totalprice, out int totalsalepoint, out int TotalQuantity, out string totalpricedesc)
        {
            totalprice = 0;
            TotalQuantity = 0;
            totalpricedesc = string.Empty;
            totalsalepoint = 0;
            List<Dictionary<string, object>> productlist = new List<Dictionary<string, object>>();
            Mall_ProductDetail[] my_products = new Mall_ProductDetail[] { };
            if (BusinessID > 0)
            {
                my_products = products.Where(p => p.BusinessID == BusinessID).ToArray();
            }
            else
            {
                my_products = products.Where(p => p.IsZiYing).ToArray();
            }
            var my_cartlist = list.Where(p => my_products.Select(q => q.ID).ToList().Contains(p.ProductID)).ToArray();
            foreach (var item in my_cartlist)
            {
                var my_product = products.FirstOrDefault(p => p.ID == item.ProductID);
                if (my_product == null)
                {
                    continue;
                }
                var my_variant = product_variants.FirstOrDefault(p => p.ID == item.VariantID);
                decimal price = 0;
                int salepoint = 0;
                bool isallowproductsale = false;
                bool isallowpointsale = false;
                bool isallowvipsale = false;
                bool isallowstaffsale = false;
                int type = Mall_Product.GetFinalProductOrderType(item.ProductOrderType, my_product.ProductOrderType);
                string pricedesc = Mall_Product.GetOrderItemPriceDesc(my_product, my_variant, item.Quantity, out price, out salepoint, out isallowproductsale, out isallowpointsale, out isallowvipsale, out isallowstaffsale, out totalpricedesc, ProductOrderType: type);
                string desc = string.Empty;

                if (!string.IsNullOrEmpty(item.VariantTitle) && !string.IsNullOrEmpty(item.VariantName))
                {
                    desc = item.VariantTitle + ": " + item.VariantName;
                }
                Dictionary<string, object> dic = new Dictionary<string, object>();
                dic["id"] = item.ID;
                dic["productid"] = item.ProductID;
                dic["variantid"] = item.VariantID;
                dic["imageurl"] = !string.IsNullOrEmpty(my_product.CoverImage) ? context_path + my_product.CoverImage : "../image/error-img.png";
                dic["title"] = my_product.ProductName;
                dic["desc"] = desc;
                dic["pricedesc"] = pricedesc;
                dic["price"] = price;
                dic["salepoint"] = salepoint;
                dic["quantity"] = item.Quantity;
                dic["checked"] = false;
                dic["maxquantity"] = my_product.MaxQuantity;
                dic["quantitylimit"] = my_product.QuantityLimit > 0 ? my_product.QuantityLimit : 0;
                dic["producttypeid"] = my_product.ProductTypeID;
                dic["ProductOrderType"] = item.ProductOrderType > 0 ? item.ProductOrderType : 16;
                totalprice += price * item.Quantity;
                totalsalepoint += salepoint * item.Quantity;
                TotalQuantity += item.Quantity;
                productlist.Add(dic);
            }
            if (totalsalepoint > 0 && totalprice > 0)
            {
                totalpricedesc = "￥" + totalprice.ToString("0.00") + " + " + totalsalepoint.ToString() + "积分";
            }
            else if (totalprice > 0)
            {
                totalpricedesc = "￥" + totalprice.ToString("0.00");
            }
            else if (totalsalepoint > 0)
            {
                totalpricedesc = totalsalepoint.ToString() + "积分";
            }
            return productlist;
        }
    }
}
