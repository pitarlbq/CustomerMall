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
    /// This object represents the properties and methods of a Mall_ShipRateDetail.
    /// </summary>
    public partial class Mall_ShipRateDetail : EntityBase
    {
        public static Mall_ShipRateDetail GetDefaultMall_ShipRateDetailByRateID(int RateID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (RateID <= 0)
            {
                return null;
            }
            conditions.Add("[IsDefault]=1");
            conditions.Add("[RateID]=@RateID");
            parameters.Add(new SqlParameter("@RateID", RateID));
            return GetOne<Mall_ShipRateDetail>("select * from [Mall_ShipRateDetail] where " + string.Join(" and ", conditions.ToArray()), parameters);
        }
        public static Mall_ShipRateDetail[] GetMall_ShipRateDetailListByRateID(int RateID, int ProvinceID = 0)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (RateID <= 0)
            {
                return new Mall_ShipRateDetail[] { };
            }
            conditions.Add("[IsDefault]=0");
            conditions.Add("[RateID]=@RateID");
            parameters.Add(new SqlParameter("@RateID", RateID));
            if (ProvinceID > 0)
            {
                conditions.Add("[ID] in (select [RateDetailID] from [Mall_ShipRateDetail_Province] where [ProvinceID]=@ProvinceID)");
                parameters.Add(new SqlParameter("@ProvinceID", ProvinceID));
            }
            return GetList<Mall_ShipRateDetail>("select * from [Mall_ShipRateDetail] where " + string.Join(" and ", conditions.ToArray()) + " order by [AddTime] desc", parameters).ToArray();
        }
        public static void GetMall_ShipRateDetailByKeywords(int ProductID, List<int> CartIDList, int OrderID, out string RateTitle, out decimal RateAmount, out int RateID, out int RateType, int ProvinceID = 0, int Quantity = 0, int UserID = 0)
        {
            RateTitle = "快递 免邮";
            RateAmount = 0;
            RateID = 0;
            RateType = 0;
            if (ProductID > 0)
            {
                var data = Mall_Product.GetMall_Product(ProductID);
                CalculateRateByProduct(data, out  RateTitle, out  RateAmount, out RateID, out RateType, ProvinceID: ProvinceID, Quantity: Quantity);
                return;
            }
            if (OrderID > 0)
            {
                var orderitem_list = Mall_OrderItem.GetMall_OrderItemListByOrderID(OrderID);
                var product_list = Mall_Product.GetMall_ProductListByIDList(orderitem_list.Select(p => p.ProductID).ToList());
                foreach (var item in orderitem_list)
                {
                    var product = product_list.FirstOrDefault(p => p.ID == item.ProductID);
                    decimal my_rate_amount = 0;
                    string my_rate_title = string.Empty;
                    CalculateRateByProduct(product, out  my_rate_title, out  my_rate_amount, out RateID, out RateType, ProvinceID: ProvinceID, Quantity: item.Quantity);
                    RateAmount += my_rate_amount;
                    RateTitle += my_rate_title + " ";
                }
                return;
            }
            if (CartIDList.Count > 0)
            {
                var cartitem_list = Mall_ShoppingCart.GetMall_ShoppingCartListByIDList(CartIDList, UserID);
                var product_list = Mall_Product.GetMall_ProductListByIDList(cartitem_list.Select(p => p.ProductID).ToList());
                foreach (var item in cartitem_list)
                {
                    var product = product_list.FirstOrDefault(p => p.ID == item.ProductID);
                    decimal my_rate_amount = 0;
                    string my_rate_title = string.Empty;
                    CalculateRateByProduct(product, out  my_rate_title, out  my_rate_amount, out RateID, out RateType, ProvinceID: ProvinceID, Quantity: item.Quantity);
                    RateAmount += my_rate_amount;
                    RateTitle += my_rate_title + " ";
                }
                return;
            }
        }
        public static void GetMall_ShipRateDetailByCardIDList(int ProductID, List<int> CartIDList, int OrderID, out List<Dictionary<string, object>> list, int ProvinceID = 0, int Quantity = 0, int UserID = 0)
        {
            list = new List<Dictionary<string, object>>();
            var ship_rate_list = Mall_ShipRate.GetMall_ShipRates().ToArray();
            if (ProductID > 0)
            {
                var data = Mall_Product.GetMall_Product(ProductID);
                CalculateRateByProductOutDic(ship_rate_list, out list, ProvinceID: ProvinceID, Quantity: Quantity, BusinessID: data.BusinessID);
                return;
            }
            if (OrderID > 0)
            {
                var orderitem_list = Mall_OrderItem.GetMall_OrderItemListByOrderID(OrderID);
                if (orderitem_list.Length == 0)
                {
                    return;
                }
                var product_list = Mall_Product.GetMall_ProductListByIDList(orderitem_list.Select(p => p.ProductID).ToList());
                int TotalQuantity = orderitem_list.Sum(p => p.Quantity);
                CalculateRateByProductOutDic(ship_rate_list, out list, ProvinceID: ProvinceID, Quantity: TotalQuantity, BusinessID: orderitem_list[0].BusinessID);
                return;
            }
            if (CartIDList.Count > 0)
            {
                var cart_list = Foresight.DataAccess.Mall_ShoppingCart.GetMall_ShoppingCartListByIDList(CartIDList, UserID);
                var product_list = Foresight.DataAccess.Mall_ProductDetail.GetMall_ProductDetailListByIDList(cart_list.Select(p => p.ProductID).ToList());
                var variant_list = Foresight.DataAccess.Mall_Product_VariantDetail.GetMall_Product_VariantDetailListByIDList(cart_list.Select(p => p.VariantID).ToList());
                var business_list = Foresight.DataAccess.Mall_Business.GetMall_BusinessListByIDList(product_list.Select(p => p.BusinessID).ToList());
                decimal totalprice = 0;
                int totalsalepoint = 0;
                int TotalQuantity = 0;
                string totalpricedesc = string.Empty;
                var productlist = Mall_ShoppingCart.getshoppingcartitems(cart_list, product_list, variant_list, 0, string.Empty, out totalprice, out totalsalepoint, out TotalQuantity, out totalpricedesc);
                var my_list = new List<Dictionary<string, object>>();
                CalculateRateByProductOutDic(ship_rate_list, out my_list, ProvinceID: ProvinceID, Quantity: TotalQuantity, BusinessID: 0);
                list.AddRange(my_list);
                foreach (var business in business_list)
                {
                    totalprice = 0;
                    totalsalepoint = 0;
                    TotalQuantity = 0;
                    totalpricedesc = string.Empty;
                    productlist = Mall_ShoppingCart.getshoppingcartitems(cart_list, product_list, variant_list, business.ID, string.Empty, out totalprice, out totalsalepoint, out TotalQuantity, out totalpricedesc);
                    my_list = new List<Dictionary<string, object>>();
                    CalculateRateByProductOutDic(ship_rate_list, out my_list, ProvinceID: ProvinceID, Quantity: TotalQuantity, BusinessID: business.ID);
                    list.AddRange(my_list);
                }
            }
            return;
        }
        private static void CalculateRateByProduct(Mall_Product data, out string RateTitle, out decimal RateAmount, out int RateID, out int RateType, int ProvinceID = 0, int Quantity = 0)
        {
            RateTitle = "快递 免邮";
            RateAmount = 0;
            RateID = 0;
            RateType = 0;
            if (data == null)
            {
                return;
            }
            if (data.ShipRateID <= 0)
            {
                return;
            }
            var ship_rate = Mall_ShipRate.GetMall_ShipRate(data.ShipRateID);
            if (ship_rate == null)
            {
                return;
            }
            RateID = ship_rate.ID;
            RateType = ship_rate.RateType;
            var ship_rate_list = Mall_ShipRateDetail.GetMall_ShipRateDetailListByRateID(ship_rate.ID, ProvinceID: ProvinceID);
            if (ship_rate_list.Length > 0)
            {
                RateAmount = CalculateRateAmount(ship_rate_list[0], Quantity);
                if (RateAmount > 0)
                {
                    RateTitle = "快递";
                }
            }
            else if (ship_rate.RateType == 2)
            {
                RateTitle = ship_rate.RateTypeDesc;
            }
            else
            {
                var default_ship_rate = Mall_ShipRateDetail.GetDefaultMall_ShipRateDetailByRateID(ship_rate.ID);
                if (default_ship_rate != null)
                {
                    RateAmount = CalculateRateAmount(default_ship_rate, Quantity);
                    if (RateAmount > 0)
                    {
                        RateTitle = "快递";
                    }
                }
            }
        }
        private static void CalculateRateByProductOutDic(Mall_ShipRate[] ship_rate_list, out List<Dictionary<string, object>> ShipRateList, int ProvinceID = 0, int Quantity = 0, int BusinessID = 0)
        {
            ShipRateList = new List<Dictionary<string, object>>();
            if (ship_rate_list.Length == 0)
            {
                return;
            }
            foreach (var ship_rate in ship_rate_list)
            {
                var dic = new Dictionary<string, object>();
                dic["BusinessID"] = BusinessID;
                dic["RateID"] = ship_rate.ID;
                dic["RateType"] = ship_rate.RateType;
                string RateTitle = ship_rate.RateTile;
                decimal RateAmount = 0;
                var ship_rate_detail_list = Mall_ShipRateDetail.GetMall_ShipRateDetailListByRateID(ship_rate.ID, ProvinceID: ProvinceID);
                if (ship_rate_detail_list.Length > 0)
                {
                    RateAmount = CalculateRateAmount(ship_rate_detail_list[0], Quantity);
                }
                else
                {
                    var default_ship_rate = Mall_ShipRateDetail.GetDefaultMall_ShipRateDetailByRateID(ship_rate.ID);
                    if (default_ship_rate != null)
                    {
                        RateAmount = CalculateRateAmount(default_ship_rate, Quantity);
                    }
                }
                dic["name"] = RateTitle;
                dic["amount"] = RateAmount;
                dic["amountdesc"] = "￥" + RateAmount.ToString("0.00");
                dic["id"] = ship_rate.ID;
                dic["text"] = RateTitle;
                dic["selected"] = "";
                dic["isdefault"] = ship_rate.IsDefault;
                ShipRateList.Add(dic);
            }
        }
        private static decimal CalculateRateAmount(Mall_ShipRateDetail data, int Quantity)
        {
            decimal DefaultMoney = data.DefaultMoney > 0 ? data.DefaultMoney : 0;
            if (Quantity <= data.DefaultQuantity)
            {
                return DefaultMoney;
            }
            if (data.AdditionalQuantity <= 0)
            {
                return DefaultMoney;
            }
            int rest_quantity = Quantity - data.DefaultQuantity;
            int rest_quantity_zheng = rest_quantity / data.AdditionalQuantity;
            decimal rest_quantity_yue = (decimal)rest_quantity % data.AdditionalQuantity;
            rest_quantity_zheng = rest_quantity_yue == 0 ? rest_quantity_zheng : rest_quantity_zheng + 1;
            decimal AdditonalMoney = data.AdditionalMoney > 0 ? data.AdditionalMoney : 0;
            decimal result = DefaultMoney + (rest_quantity_zheng * AdditonalMoney);
            return Math.Round(result, 2, MidpointRounding.AwayFromZero);
        }
    }
}
