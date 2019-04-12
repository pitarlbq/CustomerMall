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
    /// This object represents the properties and methods of a ViewMall_OrderItem.
    /// </summary>
    public partial class ViewMall_OrderItem : EntityBaseReadOnly
    {
        public static Ui.DataGrid GetViewMall_OrderItemGridByKeywords(string Keywords, DateTime StartTime, DateTime EndTime, int Status, long startRowIndex, int pageSize, string ProductName, DateTime PayStartTime, DateTime PayEndTime, string BuyerNickName, string BuyerPhoneNumber, int OrderStatus, int RateStatus, string OrderNumber, string ShipCompany, int OrderType, string BusinessName)
        {
            long totalRows = 0;
            string OrderBy = " order by AddTime desc,OrderAddTime desc";
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (!string.IsNullOrEmpty(ProductName))
            {
                conditions.Add("[ProductName] like @ProductName");
                parameters.Add(new SqlParameter("@ProductName", "%" + ProductName + "%"));
            }
            if (PayStartTime > DateTime.MinValue)
            {
                conditions.Add("[PayTime]>=@PayStartTime");
                parameters.Add(new SqlParameter("@PayStartTime", PayStartTime));
            }
            if (PayEndTime > DateTime.MinValue)
            {
                conditions.Add("[PayTime]<=@PayEndTime");
                parameters.Add(new SqlParameter("@PayEndTime", PayEndTime));
            }
            if (!string.IsNullOrEmpty(BuyerNickName))
            {
                conditions.Add("[UserID] in (select [UserID] from [User] where [NickName] like @BuyerNickName)");
                parameters.Add(new SqlParameter("@BuyerNickName", "%" + BuyerNickName + "%"));
            }
            if (!string.IsNullOrEmpty(BuyerPhoneNumber))
            {
                conditions.Add("[UserName] like @BuyerPhoneNumber");
                parameters.Add(new SqlParameter("@BuyerPhoneNumber", "%" + BuyerPhoneNumber + "%"));
            }
            if (RateStatus == 1)
            {
                conditions.Add("[OrderID] in (select OrderID from [Mall_OrderComment])");
            }
            else if (RateStatus == 2)
            {
                conditions.Add("[OrderID] not in (select OrderID from [Mall_OrderComment])");
            }
            if (!string.IsNullOrEmpty(OrderNumber))
            {
                conditions.Add("[OrderNumber] like @OrderNumber");
                parameters.Add(new SqlParameter("@OrderNumber", "%" + OrderNumber + "%"));
            }
            if (!string.IsNullOrEmpty(ShipCompany))
            {
                conditions.Add("[ShipCompanyName] like @ShipCompany");
                parameters.Add(new SqlParameter("@ShipCompany", "%" + ShipCompany + "%"));
            }
            if (OrderType > 0)
            {
                conditions.Add("[ProductTypeID]=@OrderType");
                parameters.Add(new SqlParameter("@OrderType", OrderType));
            }
            if (!string.IsNullOrEmpty(BusinessName))
            {
                conditions.Add("BusinessName like @BusinessName");
                parameters.Add(new SqlParameter("@BusinessName", "%" + BusinessName + "%"));
            }
            if (StartTime > DateTime.MinValue)
            {
                conditions.Add("[OrderAddTime]>=@StartTime");
                parameters.Add(new SqlParameter("@StartTime", StartTime));
            }
            if (EndTime > DateTime.MinValue)
            {
                conditions.Add("[OrderAddTime]<=@EndTime");
                parameters.Add(new SqlParameter("@EndTime", EndTime));
            }
            if (OrderStatus > 0)
            {
                Status = OrderStatus;
            }
            if (Status == 4)
            {
                conditions.Add("[IsClosed]=1");
            }
            else if (Status > 0)
            {
                conditions.Add("[OrderStatus]=@Status");
                parameters.Add(new SqlParameter("@Status", Status));
            }
            if (!string.IsNullOrEmpty(Keywords))
            {
                conditions.Add("([OrderNumber] like @Keywords or [ProductName] like @Keywords)");
                parameters.Add(new SqlParameter("@Keywords", "%" + Keywords + "%"));
            }
            string fieldList = "[ViewMall_OrderItem].*";
            string Statement = " from [ViewMall_OrderItem] where  " + string.Join(" and ", conditions.ToArray());
            ViewMall_OrderItem[] list = GetList<ViewMall_OrderItem>(fieldList, Statement, parameters, OrderBy, startRowIndex, pageSize, out totalRows).ToArray();
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
        public string OrderStatusDesc
        {
            get
            {
                if (this.IsClosed)
                {
                    return "已关闭";
                }
                string desc = string.Empty;
                switch (this.OrderStatus)
                {
                    case 1:
                        desc = "待付款";
                        break;
                    case 2:
                        desc = "已发货";
                        break;
                    case 3:
                        desc = "已完成";
                        break;
                    case 4:
                        desc = "已关闭";
                        break;
                    case 5:
                        desc = "待发货";
                        break;
                    case 6:
                        desc = "申请退款";
                        break;
                    case 7:
                        desc = "已退款";
                        break;
                    default:
                        break;
                }
                return desc;
            }
        }
        public string FullAddressInfo
        {
            get
            {
                string desc = string.Empty;
                if (!string.IsNullOrEmpty(this.AddressProvince))
                {
                    desc += this.AddressProvince;
                }
                if (!string.IsNullOrEmpty(this.AddressCity))
                {
                    desc += this.AddressCity;
                }
                if (!string.IsNullOrEmpty(this.AddressDistrict))
                {
                    desc += this.AddressDistrict;
                }
                if (!string.IsNullOrEmpty(this.AddressDetailInfo))
                {
                    desc += this.AddressDetailInfo;
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
                        desc = "拼团";
                        break;
                    case 4:
                        desc = "抢购";
                        break;
                    case 10:
                        desc = "物业缴费";
                        break;
                    default:
                        break;
                }
                return desc;
            }
        }
        public string PaymentMethodDesc
        {
            get
            {
                if (string.IsNullOrEmpty(this.PaymentMethod))
                {
                    return string.Empty;
                }
                return Utility.EnumHelper.GetDescription(typeof(Utility.EnumModel.Mall_OrderPaymentMethodDefine), this.PaymentMethod);
            }
        }
    }
}
