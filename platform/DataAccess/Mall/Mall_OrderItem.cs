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
    /// This object represents the properties and methods of a Mall_OrderItem.
    /// </summary>
    public partial class Mall_OrderItem : EntityBase
    {
        public static Mall_OrderItem[] GetMall_OrderItemListByOrderID(int OrderID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[OrderID]=@OrderID");
            parameters.Add(new SqlParameter("@OrderID", OrderID));
            string Statement = @"select * from Mall_OrderItem where " + string.Join(" and ", conditions);
            return GetList<Mall_OrderItem>(Statement, parameters).ToArray();
        }
        public static Ui.DataGrid GetMall_OrderItemGridByKeywords(int OrderID, long startRowIndex, int pageSize)
        {
            long totalRows = 0;
            string OrderBy = " order by AddTime desc";
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (OrderID > 0)
            {
                conditions.Add("([OrderID]=@OrderID)");
                parameters.Add(new SqlParameter("@OrderID", OrderID));
            }
            string fieldList = "[Mall_OrderItem].*";
            string Statement = " from [Mall_OrderItem] where  " + string.Join(" and ", conditions.ToArray());
            Mall_OrderItem[] list = GetList<Mall_OrderItem>(fieldList, Statement, parameters, OrderBy, startRowIndex, pageSize, out totalRows).ToArray();
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
        public static Mall_OrderItem[] GetMall_OrderItemListByOrderIDList(List<int> OrderIDList)
        {
            if (OrderIDList.Count == 0)
            {
                return new Mall_OrderItem[] { };
            }
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[OrderID] in (" + string.Join(",", OrderIDList.ToArray()) + ")");
            string Statement = @"select * from Mall_OrderItem where " + string.Join(" and ", conditions);
            return GetList<Mall_OrderItem>(Statement, parameters).ToArray();
        }
        public static Mall_OrderItem[] GetAnalysisMall_OrderItemListByOrderIDList(List<int> OrderIDList)
        {
            if (OrderIDList.Count == 0)
            {
                return new Mall_OrderItem[] { };
            }
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[OrderID] in (" + string.Join(",", OrderIDList.ToArray()) + ")");
            string Statement = @"select [Quantity],[OrderID],[AddTime],[ProductID] from Mall_OrderItem where " + string.Join(" and ", conditions);
            return GetList<Mall_OrderItem>(Statement, parameters).ToArray();
        }
        public static int[] GetProductIDListByOrderID(int OrderID, bool IsProduct = false, bool IsService = false)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[OrderID]=@OrderID");
            if (IsProduct)
            {
                conditions.Add("ProductTypeID in (1,2,3,4)");
            }
            if (IsService)
            {
                conditions.Add("ProductTypeID=5");
            }
            parameters.Add(new SqlParameter("@OrderID", OrderID));
            string Statement = @"select [ProductID] from Mall_OrderItem where " + string.Join(" and ", conditions);
            var list = GetList<Mall_OrderItem>(Statement, parameters).ToArray();
            return list.Select(p => p.ProductID).ToArray();
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
                        desc = "拼团抢购";
                        break;
                    case 4:
                        desc = "限时秒杀";
                        break;
                    case 5:
                        desc = "生活服务";
                        break;
                    case 10:
                        desc = "物业收费";
                        break;
                    default:
                        break;
                }
                return desc;
            }
        }
        public string ProductTitle
        {
            get
            {
                if (this.ProductTypeID != 10)
                {
                    return this.ProductName;
                }
                return this.RoomName + "(" + this.ChargeName + ")";
            }
        }
        public string ProductSubTitle
        {
            get
            {
                if (this.ProductTypeID != 10)
                {
                    if (!string.IsNullOrEmpty(this.VariantName))
                    {
                        this.VariantTitle = string.IsNullOrEmpty(this.VariantTitle) ? "规格" : this.VariantTitle;
                        return this.VariantTitle + ": " + this.VariantName;
                    }
                    return string.Empty;
                }
                string start_time = this.StartTime > DateTime.MinValue ? this.StartTime.ToString("yyyy-MM-dd") : "--";
                string end_time = this.EndTime > DateTime.MinValue ? this.EndTime.ToString("yyyy-MM-dd") : "--";
                return start_time + " 至 " + end_time;
            }
        }
        public string PriceDesc
        {
            get
            {
                if (this.ProductBuyType == 17)
                {
                    if (this.SalePoint > 0 && this.Price > 0)
                    {
                        return "￥" + this.Price.ToString("0.00") + " + " + this.SalePoint.ToString() + "积分";
                    }
                    if (this.Price > 0)
                    {
                        return "￥" + this.Price.ToString("0.00");
                    }
                    if (this.SalePoint > 0)
                    {
                        return this.SalePoint.ToString() + "积分";
                    }
                }
                if (this.ProductBuyType == 18)
                {
                    if (this.VIPSalePoint > 0 && this.Price > 0)
                    {
                        return "￥" + this.Price.ToString("0.00") + " + " + this.VIPSalePoint.ToString() + "积分";
                    }
                    if (this.Price > 0)
                    {
                        return "￥" + this.Price.ToString("0.00");
                    }
                    if (this.VIPSalePoint > 0)
                    {
                        return this.VIPSalePoint.ToString() + "积分";
                    }
                }
                if (this.ProductBuyType == 25)
                {
                    if (this.StaffPoint > 0 && this.Price > 0)
                    {
                        return "￥" + this.Price.ToString("0.00") + " + " + this.StaffPoint.ToString() + "积分";
                    }
                    if (this.Price > 0)
                    {
                        return "￥" + this.Price.ToString("0.00");
                    }
                    if (this.StaffPoint > 0)
                    {
                        return this.StaffPoint.ToString() + "积分";
                    }
                }
                else
                {
                    if (this.Price > 0)
                    {
                        return "￥" + this.Price.ToString("0.00");
                    }
                }
                return string.Empty;
            }
        }
        public string TotalPriceDesc
        {
            get
            {
                if (this.ProductBuyType == 17)
                {
                    if (this.TotalSalePoint > 0 && this.TotalPrice > 0)
                    {
                        return "￥" + this.TotalPrice.ToString("0.00") + " + " + this.TotalSalePoint.ToString() + "积分";
                    }
                    if (this.TotalPrice > 0)
                    {
                        return "￥" + this.TotalPrice.ToString("0.00");
                    }
                    if (this.SalePoint > 0)
                    {
                        return this.TotalSalePoint.ToString() + "积分";
                    }
                }
                if (this.ProductBuyType == 18)
                {
                    if (this.VIPTotalSalePoint > 0 && this.TotalPrice > 0)
                    {
                        return "￥" + this.TotalPrice.ToString("0.00") + " + " + this.VIPTotalSalePoint.ToString() + "积分";
                    }
                    if (this.TotalPrice > 0)
                    {
                        return "￥" + this.TotalPrice.ToString("0.00");
                    }
                    if (this.VIPTotalSalePoint > 0)
                    {
                        return this.VIPTotalSalePoint.ToString() + "积分";
                    }
                }
                if (this.ProductBuyType == 25)
                {
                    if (this.TotalStaffPoint > 0 && this.TotalPrice > 0)
                    {
                        return "￥" + this.TotalPrice.ToString("0.00") + " + " + this.TotalStaffPoint.ToString() + "积分";
                    }
                    if (this.TotalPrice > 0)
                    {
                        return "￥" + this.TotalPrice.ToString("0.00");
                    }
                    if (this.TotalStaffPoint > 0)
                    {
                        return this.TotalStaffPoint.ToString() + "积分";
                    }
                }
                else
                {
                    if (this.TotalPrice > 0)
                    {
                        return "￥" + this.TotalPrice.ToString("0.00");
                    }
                }
                return string.Empty;
            }
        }
        public int ProductOrderType
        {
            get
            {
                return this.ProductBuyType > 0 ? this.ProductBuyType : 16;
            }
        }
        public int FinalSalePoint
        {
            get
            {
                int point = 0;
                if (this.SalePoint > 0)
                {
                    point += this.SalePoint;
                }
                if (this.VIPSalePoint > 0)
                {
                    point += this.VIPSalePoint;
                }
                return point;
            }
        }
    }
    public partial class Mall_OrderItemDetail : Mall_OrderItem
    {
        [DatabaseColumn("BasicPrice")]
        public decimal BasicPrice { get; set; }
        public decimal TotalBasicCost
        {
            get
            {
                this.BasicPrice = this.BasicPrice > 0 ? this.BasicPrice : 0;
                this.Quantity = this.Quantity > 0 ? this.Quantity : 0;
                return Math.Round(this.BasicPrice * this.Quantity, 2, MidpointRounding.AwayFromZero);
            }
        }
        public decimal TotalUnitCost
        {
            get
            {
                this.Price = this.Price > 0 ? this.Price : 0;
                this.Quantity = this.Quantity > 0 ? this.Quantity : 0;
                return Math.Round(this.Price * this.Quantity, 2, MidpointRounding.AwayFromZero);
            }
        }
        public decimal TotalRestCost
        {
            get
            {
                return this.TotalUnitCost - this.TotalBasicCost;
            }
        }
        public static Mall_OrderItemDetail[] GetMall_OrderItemDetailListByOrderIDList(List<int> OrderIDList)
        {
            if (OrderIDList.Count == 0)
            {
                return new Mall_OrderItemDetail[] { };
            }
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[OrderID] in (" + string.Join(",", OrderIDList.ToArray()) + ")");
            conditions.Add("[ProductTypeID]!=10");
            string Statement = @"select ID,OrderID,Quantity,Price,ProductTypeID,ProductID,VariantID from Mall_OrderItem where " + string.Join(" and ", conditions);
            var list = GetList<Mall_OrderItemDetail>(Statement, parameters).ToArray();
            if (list.Length == 0)
            {
                return new Mall_OrderItemDetail[] { };
            }
            var myList1 = list.Where(p => p.ProductTypeID != 5).ToArray();
            var myList2 = list.Where(p => p.ProductTypeID == 5).ToArray();
            var ProductIDList = myList1.Select(p => p.ProductID).ToList();
            var VariantIDList = myList1.Select(p => p.VariantID).ToList();
            var HouseServiceIDList = myList2.Select(p => p.ProductID).ToList();
            var HouseServiceTypeIDList = myList2.Select(p => p.VariantID).ToList();
            var productList = new Mall_Product[] { };
            var variantList = new Mall_Product_Variant[] { };
            var houseServiceTypeList = new Wechat_HouseServiceType[] { };
            if (ProductIDList.Count > 0)
            {
                productList = Mall_Product.GetMall_ProductListByIDList(ProductIDList);
            }
            if (VariantIDList.Count > 0)
            {
                variantList = Mall_Product_Variant.GetMall_Product_VariantListByIDList(VariantIDList);
            }
            if (HouseServiceTypeIDList.Count > 0)
            {
                houseServiceTypeList = Wechat_HouseServiceType.GetWechat_HouseServiceTypes().ToArray();
            }
            foreach (var item in list)
            {
                if (item.ProductTypeID == 5)
                {
                    var myType = houseServiceTypeList.FirstOrDefault(p => p.ID == item.VariantID);
                    if (myType != null)
                    {
                        item.BasicPrice = myType.BasicPrice > 0 ? myType.BasicPrice : 0;
                        continue;
                    }
                }
                if (item.ProductTypeID != 5)
                {
                    var myVariant = variantList.FirstOrDefault(p => p.ID == item.VariantID);
                    if (myVariant != null)
                    {
                        item.BasicPrice = myVariant.VariantBasicPrice > 0 ? myVariant.VariantBasicPrice : 0;
                        continue;
                    }
                    var myProduct = productList.FirstOrDefault(p => p.ID == item.ProductID);
                    if (myProduct != null)
                    {
                        item.BasicPrice = myProduct.BasicPrice > 0 ? myProduct.BasicPrice : 0;
                        continue;
                    }
                }
            }
            return list;
        }
    }
}
