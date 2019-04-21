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
    /// This object represents the properties and methods of a Mall_Product.
    /// </summary>
    public partial class Mall_Product : EntityBase
    {
        public static Mall_Product[] GetMall_ProductListByUserID(int UserID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("BusinessID in (select [ID] from [Mall_Business] where [UserID]=@UserID) or BusinessID in (select [BusinessID] from [Mall_BusinessUser] where [UserID]=@UserID)");
            parameters.Add(new SqlParameter("@UserID", UserID));
            string Statement = @"select * from Mall_Product where " + string.Join(" and ", conditions);
            return GetList<Mall_Product>(Statement, parameters).ToArray();
        }
        public static Mall_Product[] GetMall_CouponProductListByCouponID(int CouponID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("ID in (select [ProductID] from [Mall_CouponProduct] where [CouponID]=@CouponID)");
            parameters.Add(new SqlParameter("@CouponID", CouponID));
            string Statement = @"select * from Mall_Product where " + string.Join(" and ", conditions);
            return GetList<Mall_Product>(Statement, parameters).ToArray();
        }
        public static Mall_Product[] GetMall_CouponProductListByAmountRuleID(int AmountRuleID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("ID in (select [ProductID] from [Mall_AmountRuleProduct] where [AmountRuleID]=@AmountRuleID)");
            parameters.Add(new SqlParameter("@AmountRuleID", AmountRuleID));
            string Statement = @"select * from Mall_Product where " + string.Join(" and ", conditions);
            return GetList<Mall_Product>(Statement, parameters).ToArray();
        }
        public static Mall_Product[] GetMall_ProductListByIDList(List<int> IDList)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (IDList.Count == 0)
            {
                return new Mall_Product[] { };
            }
            conditions.Add("[ID] in (" + string.Join(",", IDList.ToArray()) + ")");
            return GetList<Mall_Product>("select * from [Mall_Product] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
        public static Mall_Product[] GetMall_ProductListByOrderID(int OrderID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("ID in (select [ProductID] from [Mall_OrderItem] where [OrderID]=@OrderID)");
            parameters.Add(new SqlParameter("@OrderID", OrderID));
            string Statement = @"select * from Mall_Product where " + string.Join(" and ", conditions);
            return GetList<Mall_Product>(Statement, parameters).ToArray();
        }
        public static string GetOrderItemPriceDesc(Mall_Product product, Mall_Product_VariantDetail product_variant, int quantity, out decimal price, out int salepoint, out bool isallowproductsale, out bool isallowpointsale, out bool isallowvipsale, out bool isallowstaffsale, out string totalpricedesc, int ProductOrderType = 0)
        {
            string pricedesc = string.Empty;
            price = product.OrderItemPrice;
            salepoint = 0;
            isallowproductsale = false;
            isallowpointsale = false;
            isallowvipsale = false;
            isallowstaffsale = false;
            string desc = string.Empty;
            totalpricedesc = string.Empty;
            if (product_variant != null)
            {
                desc = product_variant.FinalVariantTitle + ": " + product_variant.VariantName;
                if (ProductOrderType == 16)
                {
                    isallowproductsale = true;
                    price = product_variant.FinalVariantPrice;
                }
                else if (ProductOrderType == 17)
                {
                    isallowpointsale = true;
                    price = product_variant.VariantPointPrice;
                    salepoint = product_variant.VariantPoint;
                }
                else if (ProductOrderType == 18)
                {
                    isallowvipsale = true;
                    price = product_variant.VariantVIPPrice;
                    salepoint = product_variant.VariantVIPPoint;
                }
                else if (ProductOrderType == 25)
                {
                    isallowstaffsale = true;
                    price = product_variant.VariantStaffPrice;
                    salepoint = product_variant.VariantStaffPoint;
                }
                else
                {
                    if (product.IsAllowProductBuy)
                    {
                        isallowproductsale = true;
                        price = product_variant.FinalVariantPrice;
                    }
                    else if (product.IsAllowPointBuy)
                    {
                        isallowpointsale = true;
                        price = product_variant.VariantPointPrice;
                        salepoint = product_variant.VariantPoint;
                    }
                    else if (product.IsAllowVIPBuy)
                    {
                        isallowvipsale = true;
                        price = product_variant.VariantVIPPrice;
                        salepoint = product_variant.VariantVIPPoint;
                    }
                    else if (product.IsAllowStaffBuy)
                    {
                        isallowstaffsale = true;
                        price = product_variant.VariantStaffPrice;
                        salepoint = product_variant.VariantStaffPoint;
                    }
                }
            }
            if (price > 0 && salepoint > 0)
            {
                pricedesc = "￥" + price.ToString("0.00") + " + " + salepoint.ToString() + "积分";
                totalpricedesc = "￥" + (price * quantity).ToString("0.00") + " + " + (salepoint * quantity).ToString() + "积分";
            }
            else if (price > 0)
            {
                pricedesc = "￥" + price.ToString("0.00");
                totalpricedesc = "￥" + (price * quantity).ToString("0.00");
            }
            else if (salepoint > 0)
            {
                pricedesc = salepoint.ToString() + "积分";
                totalpricedesc = (salepoint * quantity).ToString() + "积分";
            }
            return pricedesc;
        }
        public string IsZiYingDesc
        {
            get
            {
                return this.IsZiYing ? "是" : "否";
            }
        }
        public string StatusDesc
        {
            get
            {
                string desc = string.Empty;
                switch (this.Status)
                {
                    case 10:
                        desc = "出售中";
                        break;
                    case 2:
                        desc = "已下架";
                        break;
                    case 3:
                        desc = "待审核";
                        break;
                    case 4:
                        desc = "审核未通过";
                        break;
                    default:
                        break;
                }
                return desc;
            }
        }
        public string ProductTypeDesc
        {
            get
            {
                string desc = string.Empty;
                switch (this.ProductTypeID)
                {
                    case 1:
                        desc = "购买商品";
                        break;
                    case 2:
                        desc = "积分兑换";
                        break;
                    case 3:
                        desc = "团购";
                        break;
                    case 4:
                        desc = "秒杀";
                        break;
                    default:
                        break;
                }
                return desc;
            }
        }
        /// <summary>
        /// 1-进行中 2-未开始 3-已结束 0-无
        /// </summary>
        public int XianShiStatus
        {
            get
            {
                if (this.ProductTypeID == 4)
                {
                    if (this.XianShiStartTime > DateTime.Now)
                    {
                        return 2;
                    }
                    if (this.XianShiEndTime < DateTime.Now)
                    {
                        return 3;
                    }
                    return 1;
                }
                return 0;
            }
        }
        public string XianShiStatusDesc
        {
            get
            {
                if (this.PinStatus == 1)
                {
                    return "进行中";
                }
                if (this.PinStatus == 2)
                {
                    return "未开始";
                }
                if (this.PinStatus == 3)
                {
                    return "已结束";
                }
                return "";
            }
        }
        /// <summary>
        /// 1-进行中 2-未开始 3-已结束 0-无
        /// </summary>
        public int PinStatus
        {
            get
            {
                if (this.ProductTypeID == 3)
                {
                    if (this.PinStartTime > DateTime.Now)
                    {
                        return 2;
                    }
                    if (this.PinEndTime < DateTime.Now)
                    {
                        return 3;
                    }
                    return 1;
                }
                return 0;
            }
        }
        public string PinStatusDesc
        {
            get
            {
                if (this.PinStatus == 1)
                {
                    return "进行中";
                }
                if (this.PinStatus == 2)
                {
                    return "未开始";
                }
                if (this.PinStatus == 3)
                {
                    return "已结束";
                }
                return "";
            }
        }
        public string TimeDesc
        {
            get
            {
                if (this.ProductTypeID == 3)
                {
                    return this.PinStartTime.ToString("yyyy-MM-dd") + "至" + this.PinEndTime.ToString("yyyy-MM-dd");
                }
                if (this.ProductTypeID == 4)
                {
                    return this.XianShiStartTime.ToString("yyyy-MM-dd") + "至" + this.XianShiEndTime.ToString("yyyy-MM-dd");
                }
                return string.Empty;
            }
        }
        public decimal FinalSalePrice
        {
            get
            {
                if (this.ProductTypeID == 3)
                {
                    return this.PinSalePrice > 0 ? this.PinSalePrice : 0;
                }
                if (this.ProductTypeID == 4)
                {
                    return this.XianShiSalePrice > 0 ? this.XianShiSalePrice : 0;
                }
                return this.SalePrice > 0 ? this.SalePrice : 0;
            }
        }
        public decimal OrderItemPrice
        {
            get
            {
                if (this.ProductTypeID == 4)
                {
                    return this.XianShiSalePrice > 0 ? this.XianShiSalePrice : 0;
                }
                return this.SalePrice > 0 ? this.SalePrice : 0;
            }
        }
        public string ProductSaleDesc
        {
            get
            {
                string desc = string.Empty;
                if (this.IsAllowProductBuy)
                {
                    desc += "普通商品";
                }
                if (this.IsAllowPointBuy)
                {
                    if (!string.IsNullOrEmpty(desc))
                    {
                        desc += ",";
                    }
                    desc += "积分商品";
                }
                if (this._isAllowVIPBuy)
                {
                    if (!string.IsNullOrEmpty(desc))
                    {
                        desc += ",";
                    }
                    desc += "合伙人商品";
                }
                return desc;
            }
        }
        public int ProductOrderType
        {
            get
            {
                if (this.IsAllowProductBuy)
                {
                    return 16;
                }
                if (this.IsAllowPointBuy)
                {
                    return 17;
                }
                if (this.IsAllowVIPBuy)
                {
                    return 18;
                }
                return 16;
            }
        }
        public static int GetFinalProductOrderType(int type, int ProductOrderType)
        {
            if (type == 16 || type <= 0)
            {
                type = ProductOrderType;
            }
            return type;
        }
    }
    public partial class Mall_ProductDetail : Mall_Product
    {
        [DatabaseColumn("BusinessName")]
        public string BusinessName { get; set; }
        [DatabaseColumn("SaleCount")]
        public int SaleCount { get; set; }
        [DatabaseColumn("SaleAmount")]
        public decimal SaleAmount { get; set; }
        [DatabaseColumn("VariantID")]
        public int VariantID { get; set; }
        [DatabaseColumn("VariantName")]
        public string VariantName { get; set; }
        [DatabaseColumn("VariantPrice")]
        public decimal VariantPrice { get; set; }
        [DatabaseColumn("VariantPoint")]
        public int VariantPoint { get; set; }
        [DatabaseColumn("VariantPointPrice")]
        public decimal VariantPointPrice { get; set; }
        [DatabaseColumn("VariantVIPPrice")]
        public decimal VariantVIPPrice { get; set; }
        [DatabaseColumn("VariantVIPPoint")]
        public decimal VariantVIPPoint { get; set; }
        [DatabaseColumn("VariantStaffPrice")]
        public decimal VariantStaffPrice { get; set; }
        [DatabaseColumn("VariantStaffPoint")]
        public decimal VariantStaffPoint { get; set; }
        [DatabaseColumn("VariantInventory")]
        public int VariantInventory { get; set; }
        [DatabaseColumn("TagNames")]
        public string TagNames { get; set; }
        [DatabaseColumn("DiscountPrice")]
        public decimal DiscountPrice { get; set; }
        [DatabaseColumn("DiscountQuantity")]
        public int DiscountQuantity { get; set; }
        [DatabaseColumn("DiscountSaleCount")]
        public int DiscountSaleCount { get; set; }
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
        public string AdminNormalPriceDesc
        {
            get
            {
                string desc = "￥0.00";
                if (this.FinalVariantPrice > 0)
                {
                    desc = "￥" + this.FinalVariantPrice.ToString("0.00");
                }
                return desc;
            }
        }
        public string AdminPinTuanPriceDesc
        {
            get
            {
                string desc = "￥0.00";
                if (this.PinSalePrice > 0 && this.ProductTypeID == 3)
                {
                    desc = "￥" + this.PinSalePrice.ToString("0.00");
                }
                return desc;
            }
        }
        public string AdminXianShiPriceDesc
        {
            get
            {
                string desc = "￥0.00";
                if (this.XianShiSalePrice > 0 && this.ProductTypeID == 4)
                {
                    desc = "￥" + this.XianShiSalePrice.ToString("0.00");
                }
                return desc;
            }
        }
        public string NormalPriceDesc
        {
            get
            {
                if (this.PinStatus == 2)
                {
                    return "未开始";
                }
                if (this.PinStatus == 3)
                {
                    return "已结束";
                }
                if (this.XianShiStatus == 2)
                {
                    return "未开始";
                }
                if (this.XianShiStatus == 3)
                {
                    return "已结束";
                }
                if (this.PinStatus == 1)
                {
                    return (this.PinSalePrice > 0 ? "￥" + this.PinSalePrice.ToString("0.00") : "￥" + this.SalePrice.ToString("0.00"));
                }
                if (this.XianShiStatus == 1)
                {
                    return (this.XianShiSalePrice > 0 ? "￥" + this.XianShiSalePrice.ToString("0.00") : "￥" + this.SalePrice.ToString("0.00"));
                }
                string desc = "￥0.00";
                if (this.FinalVariantPrice > 0)
                {
                    desc = "￥" + this.FinalVariantPrice.ToString("0.00");
                }
                return desc;
            }
        }
        public string PointPriceDesc
        {
            get
            {
                string desc = "￥0.00";
                if (this.IsAllowPointBuy)
                {
                    if (this.VariantPointPrice > 0 && this.VariantPoint > 0)
                    {
                        desc = "￥" + this.VariantPointPrice.ToString("0.00") + " + " + this.VariantPoint.ToString("0") + "积分";
                    }
                    else if (this.VariantPointPrice > 0)
                    {
                        desc = "￥" + this.VariantPointPrice.ToString("0.00");
                    }
                    else if (this.VariantPoint > 0)
                    {
                        desc = this.VariantPoint.ToString("0") + "积分";
                    }
                }
                return desc;
            }
        }
        public string VIPPointPriceDesc
        {
            get
            {
                string desc = "￥0.00";
                if (this.IsAllowVIPBuy)
                {
                    if (this.VariantVIPPrice > 0 && this.VariantVIPPoint > 0)
                    {
                        desc = "￥" + this.VariantVIPPrice.ToString("0.00") + " + " + this.VariantVIPPoint.ToString("0") + "积分";
                    }
                    else if (this.VariantVIPPrice > 0)
                    {
                        desc = "￥" + this.VariantVIPPrice.ToString("0.00");
                    }
                    else if (this.VariantVIPPoint > 0)
                    {
                        desc = this.VariantVIPPoint.ToString("0") + "积分";
                    }
                }
                return desc;
            }
        }
        public string StaffPriceDesc
        {
            get
            {
                string desc = "￥0.00";
                if (this.IsAllowStaffBuy)
                {
                    if (this.VariantStaffPrice > 0 && this.VariantStaffPoint > 0)
                    {
                        desc = "￥" + this.VariantStaffPrice.ToString("0.00") + " + " + this.VariantStaffPoint.ToString("0") + "积分";
                    }
                    else if (this.VariantStaffPrice > 0)
                    {
                        desc = "￥" + this.VariantStaffPrice.ToString("0.00");
                    }
                    else if (this.VariantStaffPoint > 0)
                    {
                        desc = this.VariantStaffPoint.ToString("0") + "积分";
                    }
                }
                return desc;
            }
        }
        public string PriceDesc
        {
            get
            {
                if (this.PinStatus == 2)
                {
                    return "未开始";
                }
                if (this.PinStatus == 3)
                {
                    return "已结束";
                }
                if (this.XianShiStatus == 2)
                {
                    return "未开始";
                }
                if (this.XianShiStatus == 3)
                {
                    return "已结束";
                }
                if (this.PinStatus == 1)
                {
                    return (this.PinSalePrice > 0 ? "￥" + this.PinSalePrice.ToString("0.00") : "￥" + this.SalePrice.ToString("0.00"));
                }
                if (this.XianShiStatus == 1)
                {
                    return (this.XianShiSalePrice > 0 ? "￥" + this.XianShiSalePrice.ToString("0.00") : "￥" + this.SalePrice.ToString("0.00"));
                }
                string desc = "";
                if (this.FinalVariantPrice > 0)
                {
                    desc += "￥" + this.FinalVariantPrice.ToString("0.00");
                }
                if (this.IsAllowPointBuy && this.VariantPoint > 0)
                {
                    if (!string.IsNullOrEmpty(desc))
                    {
                        desc += " + ";
                    }
                    desc += this.VariantPoint.ToString("0") + "积分";
                }
                if (string.IsNullOrEmpty(desc))
                {
                    desc = this.SalePrice > 0 ? "￥" + this.SalePrice.ToString("0.00") : "￥0.00";
                }
                return desc;
            }
        }
        public static string ColumnSQLText = ",(select sum([Quantity]) from [Mall_OrderItem] where [OrderID] in (select ID from [Mall_Order] where isnull(IsClosed,0)=0) and [ProductID]=[Mall_Product].ID) as SaleCount,(select sum([Quantity]) from [Mall_OrderItem] where [IsDiscountPrice]=1 and [OrderID] in (select ID from [Mall_Order] where isnull(IsClosed,0)=0) and [ProductID]=[Mall_Product].ID) as DiscountSaleCount,(select sum([TotalPrice]) from [Mall_OrderItem] where [OrderID] in (select ID from [Mall_Order] where isnull(IsClosed,0)=0) and [ProductID]=[Mall_Product].ID) as SaleAmount,(select [BusinessName] from Mall_Business where ID=[Mall_Product].BusinessID) as BusinessName,(select sum([Inventory]) from [Mall_Product_Variant] where [ProductID]=[Mall_Product].ID and isnull([IsDefault],0)=0) as VariantInventory";
        public static Mall_ProductDetail[] GetBusinessMall_ProductDetailListByUID(int UserID, int sortby, long startRowIndex, int pageSize, out long totalRows, int Status, int ProductTypeID = 0)
        {
            totalRows = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            if (UserID == 0)
            {
                return new Mall_ProductDetail[] { };
            }
            if (ProductTypeID > 0)
            {
                conditions.Add("[ProductTypeID]=@ProductTypeID");
                parameters.Add(new SqlParameter("@ProductTypeID", ProductTypeID));
            }
            conditions.Add("(BusinessID in (select [ID] from [Mall_Business] where [UserID]=@UserID) or BusinessID in (select [BusinessID] from [Mall_BusinessUser] where [UserID]=@UserID))");
            parameters.Add(new SqlParameter("@UserID", UserID));
            if (Status > 0)
            {
                if (Status == 34)
                {
                    conditions.Add("[Status] in (3,4)");
                }
                else if (Status == 102)
                {
                    conditions.Add("[Status] in (10,2)");
                }
                else
                {
                    conditions.Add("[Status]=@Status");
                    parameters.Add(new SqlParameter("@Status", Status));
                }
            }
            string OrderBy = " order by [AddTime] desc";
            if (sortby == 1)
            {
                OrderBy = " order by [AddTime] desc";
            }
            else if (sortby == 2)
            {
                OrderBy = " order by A.SaleCount desc";
            }
            else if (sortby == 3)
            {
                OrderBy = " order by A.SaleAmount desc";
            }
            else if (sortby == 4)
            {
                OrderBy = " order by (A.TotalCount-A.SaleCount) desc";
            }
            else if (sortby == 5)
            {
                OrderBy = " order by [AddTime] desc";
            }
            else if (sortby == 6)
            {
                OrderBy = " order by [AddTime] asc";
            }
            string fieldList = "A.*";
            string Statement = " from (select * " + ColumnSQLText + " from [Mall_Product])A where  " + string.Join(" and ", conditions.ToArray());
            var list = GetList<Mall_ProductDetail>(fieldList, Statement, parameters, OrderBy, startRowIndex, pageSize, out totalRows).ToArray();
            return list;
        }
        /// <summary>
        ///  
        /// </summary>
        /// <param name="IsShowOnHome"></param>
        /// <param name="ProductTypeID">1-购买商品 2-积分兑换 3-拼团 4-秒杀</param>
        /// <returns></returns>
        public static Mall_ProductDetail[] GetMall_ProductDetailList(bool IsShowOnHome = false, int ProductTypeID = 0, bool IsAllowProductBuy = true)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (IsAllowProductBuy)
            {
                conditions.Add("[IsAllowProductBuy]=1");
            }
            conditions.Add("[Status]=10");
            if (ProductTypeID > 0)
            {
                conditions.Add("[ProductTypeID]=@ProductTypeID");
                parameters.Add(new SqlParameter("@ProductTypeID", ProductTypeID));
            }
            if (IsShowOnHome)
            {
                conditions.Add("[IsShowOnHome]=1");
            }
            string cmdtext = "select A.* from (select * " + ColumnSQLText + " from [Mall_Product])A where  " + string.Join(" and ", conditions.ToArray()) + " order by [AddTime] desc";
            var list = GetList<Mall_ProductDetail>(cmdtext, parameters).ToArray();
            list = GetMall_ProductDetailPriceList(list);
            return list;
        }
        public static Mall_ProductDetail[] GetMall_ProductDetailPriceList(Mall_ProductDetail[] list)
        {
            if (list.Length > 0)
            {
                var tag_list = Mall_Tag.GetMall_Tags().ToArray();
                List<int> ProductIDList = list.Select(p => p.ID).ToList();
                var variant_list = Mall_Product_VariantDetail.GetMall_Product_VariantDetailListByProductIDList(ProductIDList);
                var product_tag_list = Mall_ProductTag.GetMall_ProductTagListByProductIDList(ProductIDList);
                var BusinessIDList = list.Where(p => p.BusinessID > 0).Select(p => p.BusinessID).ToList();
                var discount_product_list = Mall_BusinessDiscountRequest_Product.GetMall_BusinessDiscountRequest_ProductListByBusinessIDList(BusinessIDList);
                foreach (var item in list)
                {
                    var my_discount_product = discount_product_list.FirstOrDefault(p => p.BusinessID == item.BusinessID && p.ProductID == item.ID);
                    if (my_discount_product != null)
                    {
                        item.DiscountPrice = my_discount_product.Price;
                        item.DiscountQuantity = my_discount_product.Quantity;
                    }
                    item.VariantPrice = (item.SalePrice > 0 ? item.SalePrice : 0);
                    item.VariantPointPrice = 0;
                    item.VariantPoint = 0;
                    item.VariantVIPPrice = 0;
                    item.VariantVIPPoint = 0;
                    item.VariantStaffPrice = 0;
                    item.VariantStaffPoint = 0;
                    item.VariantInventory = (item.TotalCount > 0 ? item.TotalCount : 0);
                    item.VariantID = 0;
                    item.VariantName = string.Empty;
                    var my_variant_list = variant_list.Where(q => q.ProductID == item.ID).OrderBy(q => q.FinalVariantPrice).ToArray();
                    if (my_variant_list.Length > 0)
                    {
                        item.VariantPrice = (my_variant_list[0].FinalVariantPrice > 0 ? my_variant_list[0].FinalVariantPrice : item.VariantPrice);
                        item.VariantPointPrice = (my_variant_list[0].VariantPointPrice > 0 ? my_variant_list[0].VariantPointPrice : item.VariantPointPrice);
                        item.VariantPoint = (my_variant_list[0].VariantPoint > 0 ? my_variant_list[0].VariantPoint : item.VariantPoint);
                        item.VariantVIPPrice = (my_variant_list[0].VariantVIPPrice > 0 ? my_variant_list[0].VariantVIPPrice : item.VariantVIPPrice);
                        item.VariantVIPPoint = (my_variant_list[0].VariantVIPPoint > 0 ? my_variant_list[0].VariantVIPPoint : item.VariantVIPPoint);
                        item.VariantStaffPrice = (my_variant_list[0].VariantStaffPrice > 0 ? my_variant_list[0].VariantStaffPrice : item.VariantStaffPrice);
                        item.VariantStaffPoint = (my_variant_list[0].VariantStaffPoint > 0 ? my_variant_list[0].VariantStaffPoint : item.VariantStaffPoint);
                        item.VariantInventory = (my_variant_list[0].Inventory > 0 ? my_variant_list[0].Inventory : item.VariantInventory);
                        item.VariantID = my_variant_list[0].ID;
                        item.VariantName = my_variant_list[0].VariantName;
                    }

                    var my_product_tag_list = product_tag_list.Where(q => q.ProductID == item.ID).ToArray();
                    var my_tag_list = tag_list.Where(q => (my_product_tag_list.Select(m => m.TagID).ToList()).Contains(q.ID)).ToArray();
                    if (my_tag_list.Length > 0)
                    {
                        item.TagNames = string.Join(",", my_tag_list.Select(q => q.TagName));
                    }
                }
            }
            return list;
        }
        public static Mall_ProductDetail GetMall_ProductDetailPrice(Mall_ProductDetail data)
        {
            if (data == null)
            {
                return null;
            }
            var my_discount_product = Mall_BusinessDiscountRequest_Product.GetMall_BusinessDiscountRequest_ProductListByBusinessID(data.BusinessID, data.ID);
            if (my_discount_product != null)
            {
                data.DiscountPrice = my_discount_product.Price;
                data.DiscountQuantity = my_discount_product.Quantity;
            }
            data.VariantPrice = (data.SalePrice > 0 ? data.SalePrice : 0);
            data.VariantPoint = 0;
            data.VariantPointPrice = 0;
            data.VariantVIPPoint = 0;
            data.VariantVIPPrice = 0;
            data.VariantStaffPrice = 0;
            data.VariantStaffPoint = 0;
            data.VariantInventory = (data.TotalCount > 0 ? data.TotalCount : 0);
            data.VariantID = 0;
            data.VariantName = string.Empty;
            var my_variant_list = Mall_Product_VariantDetail.GetMall_Product_VariantDetailListByProductID(data.ID).OrderBy(q => q.FinalVariantPrice).ToArray();
            if (my_variant_list.Length > 0)
            {
                data.VariantPrice = (my_variant_list[0].FinalVariantPrice > 0 ? my_variant_list[0].FinalVariantPrice : data.VariantPrice);
                data.VariantPoint = (my_variant_list[0].VariantPoint > 0 ? my_variant_list[0].VariantPoint : data.VariantPoint);
                data.VariantPointPrice = (my_variant_list[0].VariantPointPrice > 0 ? my_variant_list[0].VariantPointPrice : data.VariantPointPrice);
                data.VariantVIPPoint = (my_variant_list[0].VariantVIPPoint > 0 ? my_variant_list[0].VariantVIPPoint : data.VariantVIPPoint);
                data.VariantVIPPrice = (my_variant_list[0].VariantVIPPrice > 0 ? my_variant_list[0].VariantVIPPrice : data.VariantVIPPrice);
                data.VariantStaffPrice = (my_variant_list[0].VariantStaffPrice > 0 ? my_variant_list[0].VariantStaffPrice : data.VariantStaffPrice);
                data.VariantStaffPoint = (my_variant_list[0].VariantStaffPoint > 0 ? my_variant_list[0].VariantStaffPoint : data.VariantStaffPoint);
                data.VariantInventory = (my_variant_list[0].Inventory > 0 ? my_variant_list[0].Inventory : data.VariantInventory);
                data.VariantID = my_variant_list[0].ID;
                data.VariantName = my_variant_list[0].VariantName;
            }
            return data;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Keywords"></param>
        /// <param name="sortby"></param>
        /// <param name="startRowIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="totalRows"></param>
        /// <param name="CategoryID"></param>
        /// <param name="IsShowOnHome"></param>
        /// <param name="BusinessID"></param>
        /// <param name="ProductTypeID">1-购买商品 2-积分兑换 3-拼团 4-秒杀</param>
        /// <returns></returns>
        public static Mall_ProductDetail[] GetMall_ProductDetailListByKeywords(string Keywords, int sortby, long startRowIndex, int pageSize, out long totalRows, int CategoryID = 0, bool IsShowOnHome = false, int BusinessID = -1, int ProductTypeID = 0, int TagID = 0, bool isallowpointbuy = false, bool IsAllowProductBuy = false, bool IsAllowVIPBuy = false, bool IsAllowStaffBuy = false)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            conditions.Add(" [Status]=10");
            List<string> cmdlist = new List<string>();
            if (IsAllowStaffBuy)
            {
                cmdlist.Add("[IsAllowStaffBuy]=1");
            }
            if (IsAllowProductBuy)
            {
                cmdlist.Add("[IsAllowProductBuy]=1");
            }
            if (isallowpointbuy)
            {
                cmdlist.Add("[IsAllowPointBuy]=1");
            }
            if (IsAllowVIPBuy)
            {
                cmdlist.Add("[IsAllowVIPBuy]=1");
            }
            if (cmdlist.Count > 0)
            {
                conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
            }
            if (TagID > 0)
            {
                conditions.Add("[ID] in (select [ProductID] from [Mall_ProductTag] where [TagID]=@TagID)");
                parameters.Add(new SqlParameter("@TagID", TagID));
            }
            if (ProductTypeID == 34)
            {
                conditions.Add("[ProductTypeID] in (3,4)");
                parameters.Add(new SqlParameter("@ProductTypeID", ProductTypeID));
            }
            else if (ProductTypeID > 0)
            {
                conditions.Add("[ProductTypeID]=@ProductTypeID");
                parameters.Add(new SqlParameter("@ProductTypeID", ProductTypeID));
            }
            if (BusinessID == 0)
            {
                conditions.Add("[IsYouXuan]=1");
            }
            else if (BusinessID > 0)
            {
                conditions.Add("[BusinessID]=@BusinessID and [IsZiYing]=0");
                parameters.Add(new SqlParameter("@BusinessID", BusinessID));
            }
            if (IsShowOnHome)
            {
                conditions.Add("[IsShowOnHome]=1");
            }
            if (CategoryID > 0)
            {
                conditions.Add("[ID] in (select [ProductID] from [Mall_Product_Category] where [CategoryID]=@CategoryID or ([CategoryID] in (select ID from [Mall_Category] where ParentID=@CategoryID)))");
                parameters.Add(new SqlParameter("@CategoryID", CategoryID));
            }
            if (!string.IsNullOrEmpty(Keywords))
            {
                conditions.Add("[ProductName] like @Keywords");
                parameters.Add(new SqlParameter("@Keywords", "%" + Keywords + "%"));
            }
            string OrderBy = " order by [AddTime] desc";
            if (sortby == 1)
            {
                OrderBy = " order by [AddTime] desc";
            }
            else if (sortby == 2)
            {
                OrderBy = " order by A.SaleCount desc";
            }
            else if (sortby == 3)
            {
                OrderBy = " order by SalePrice desc";
            }
            else if (sortby == 4)
            {
                OrderBy = " order by SalePrice asc";
            }
            else if (sortby == 5)
            {
                OrderBy = " order by isnull([SortOrder],99999) asc";
            }
            string fieldList = "A.*";
            string Statement = " from (select * " + ColumnSQLText + " from [Mall_Product])A where  " + string.Join(" and ", conditions.ToArray());
            var list = GetList<Mall_ProductDetail>(fieldList, Statement, parameters, OrderBy, startRowIndex, pageSize, out totalRows).ToArray();
            list = GetMall_ProductDetailPriceList(list);
            return list;
        }
        public static Ui.DataGrid GetMall_ProductDetailGridByKeywords(string Keywords, long startRowIndex, int pageSize, int SortOrder, int status, int type, int IsZiYing, bool IsAllowProductBuy, bool IsAllowPointBuy, bool IsAllowVIPBuy)
        {
            ResetParams();
            long totalRows = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            List<string> cmdlist = new List<string>();
            conditions.Add("1=1");
            if (IsAllowProductBuy)
            {
                cmdlist.Add("([IsAllowProductBuy]=1)");
            }
            if (IsAllowPointBuy)
            {
                cmdlist.Add("([IsAllowPointBuy]=1)");
            }
            if (IsAllowVIPBuy)
            {
                cmdlist.Add("([IsAllowVIPBuy]=1)");
            }
            if (cmdlist.Count > 0)
            {
                conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
            }
            if (IsZiYing == 1)
            {
                conditions.Add("([IsZiYing]=1)");
            }
            else if (IsZiYing == 2)
            {
                conditions.Add("([IsZiYing]=0)");
            }
            if (type > 0)
            {
                conditions.Add("([ProductTypeID]=@type)");
                parameters.Add(new SqlParameter("@type", type));
            }
            if (status == 10 || status == 2 || status == 3 || status == 4)
            {
                conditions.Add("([Status]=@Status)");
                parameters.Add(new SqlParameter("@Status", status));
            }
            else if (status == 1)
            {
                conditions.Add("(A.TotalCount-A.SaleCount)=0");
            }
            string OrderBy = " order by AddTime desc";
            if (SortOrder == 1)
            {
                OrderBy = " order by AddTime desc";
            }
            else if (SortOrder == 2)
            {
                OrderBy = " order by (A.TotalCount-A.SaleCount) desc";
            }
            else if (SortOrder == 3)
            {
                OrderBy = " order by SaleCount desc";
            }
            else if (SortOrder == 4)
            {
                OrderBy = " order by isnull([SortOrder],99999) asc";
            }
            if (!string.IsNullOrEmpty(Keywords))
            {
                conditions.Add("([ProductName] like @Keywords or [ModelNumber] like @Keywords)");
                parameters.Add(new SqlParameter("@Keywords", "%" + Keywords + "%"));
            }
            string fieldList = "A.*";
            string Statement = " from (select * " + ColumnSQLText + " from [Mall_Product])A where  " + string.Join(" and ", conditions.ToArray());
            Mall_ProductDetail[] list = GetList<Mall_ProductDetail>(fieldList, Statement, parameters, OrderBy, startRowIndex, pageSize, out totalRows).ToArray();
            list = GetMall_ProductDetailPriceList(list);
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
        public static Mall_ProductDetail GetMall_ProductDetailByID(int ID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[ID]=@ID");
            parameters.Add(new SqlParameter("@ID", ID));
            string cmdtext = "select * " + ColumnSQLText + " from [Mall_Product] where  " + string.Join(" and ", conditions.ToArray());
            var data = GetOne<Mall_ProductDetail>(cmdtext, parameters);
            data = GetMall_ProductDetailPrice(data);
            return data;
        }
        public static Mall_ProductDetail[] GetMall_ProductDetailListByIDList(List<int> IDList)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (IDList.Count == 0)
            {
                return new Mall_ProductDetail[] { };
            }
            conditions.Add("[ID] in (" + string.Join(",", IDList.ToArray()) + ")");
            var list = GetList<Mall_ProductDetail>("select * " + ColumnSQLText + " from [Mall_Product] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
            list = GetMall_ProductDetailPriceList(list);
            return list;
        }

        public string SaleCountDesc
        {
            get
            {
                return "已售" + (this.SaleCount > 0 ? this.SaleCount : 0).ToString();
            }
        }
        public int Inventory
        {
            get
            {
                int Variant_Inventory = this.VariantInventory > 0 ? this.VariantInventory : this.TotalCount;
                int count = Variant_Inventory - this.SaleCount;
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
                return quantitylimit;
            }
        }
        public string InventoryDesc
        {
            get
            {
                return "还剩余" + this.Inventory + this.Unit;
            }
        }
        public string CategoryName
        {
            get
            {
                if (CategoryName_Dic.ContainsKey(this.ID))
                {
                    return CategoryName_Dic[this.ID];
                }
                if (category_list == null)
                {
                    category_list = Foresight.DataAccess.Mall_Category.GetMall_Categories().Where(p => p.CategoryType.Equals(Utility.EnumModel.Mall_CategoryTypeDefine.productcategory.ToString())).ToArray();
                }
                if (product_category_list == null)
                {
                    product_category_list = Foresight.DataAccess.Mall_Product_Category.GetMall_Product_Categories().ToArray();
                }
                if (category_list.Length == 0 || product_category_list.Length == 0)
                {
                    CategoryName_Dic.Add(this.ID, string.Empty);
                    return string.Empty;
                }
                List<int> category_idlist = product_category_list.Where(p => p.ProductID == this.ID).Select(p => p.CategoryID).ToList();
                if (category_idlist.Count == 0)
                {
                    CategoryName_Dic.Add(this.ID, string.Empty);
                    return string.Empty;
                }
                var my_category_list = category_list.Where(p => category_idlist.Contains(p.ID)).ToArray();
                if (my_category_list.Length == 0)
                {
                    CategoryName_Dic.Add(this.ID, string.Empty);
                    return string.Empty;
                }
                string my_category_name = string.Join(",", my_category_list.Select(p => p.CategoryName).ToArray());
                CategoryName_Dic.Add(this.ID, my_category_name);
                return my_category_name;
            }
        }
        public static Dictionary<int, string> CategoryName_Dic = new Dictionary<int, string>();
        public static Mall_Category[] category_list = null;
        public static Mall_Product_Category[] product_category_list = null;
        public static void ResetParams()
        {
            CategoryName_Dic = new Dictionary<int, string>();
            category_list = null;
            product_category_list = null;
        }
        public bool countdownenable
        {
            get
            {
                if (this.countdowndate > DateTime.MinValue)
                {
                    return true;
                }
                return false;
            }
        }
        public string countdowndesc
        {
            get
            {
                string desc = "";
                if (this.PinStatus == 1 || this.XianShiStatus == 1)
                {
                    desc = "距结束时间";
                }
                else if (this.PinStatus == 2 || this.XianShiStatus == 2)
                {
                    desc = "距开始时间";
                }
                return desc;
            }
        }
        public DateTime countdowndate
        {
            get
            {
                if (this.PinStatus == 1)
                {
                    return this.PinEndTime;
                }
                if (this.XianShiStatus == 1)
                {
                    return this.XianShiEndTime;
                }
                if (this.PinStatus == 2)
                {
                    return this.PinStartTime;
                }
                if (this.XianShiStatus == 2)
                {
                    return this.XianShiStartTime;
                }
                return DateTime.MinValue;
            }
        }
        public string countdownday
        {
            get
            {
                string desc = string.Empty;
                if (this.countdownenable)
                {
                    TimeSpan days = this.countdowndate.Subtract(DateTime.Now);
                    if (days.Days > 0)
                    {
                        desc += days.Days + "天";
                    }
                    if (days.Hours > 0 || !string.IsNullOrEmpty(desc))
                    {
                        desc += days.Hours + "小时";
                    }
                    if (days.Minutes > 0 || !string.IsNullOrEmpty(desc))
                    {
                        desc += days.Minutes + "分钟";
                    }
                    if (days.Seconds > 0 || !string.IsNullOrEmpty(desc))
                    {
                        desc += days.Seconds + "秒";
                    }
                }
                return desc;
            }
        }
    }
}
