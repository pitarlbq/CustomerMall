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
    /// This object represents the properties and methods of a Payment.
    /// </summary>
    public partial class Payment : EntityBase
    {
        public static Payment GetPaymentByTradeNo(string TradeNo)
        {
            using (SqlHelper helper = new SqlHelper())
            {
                return GetPaymentByTradeNo(TradeNo, helper);
            }
        }
        public static Payment GetPaymentByTradeNo(string TradeNo, SqlHelper helper)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (!string.IsNullOrEmpty(TradeNo))
            {
                conditions.Add("[TradeNo]=@TradeNo");
                parameters.Add(new SqlParameter("@TradeNo", TradeNo));
            }
            string Statement = @"select top 1 * from Payment where " + string.Join(" and ", conditions);
            return GetOne<Payment>(Statement, parameters, helper);
        }
        public static Payment Insert_Payment(decimal Amount, string PaymentType, string TradeNo, int Status, string AddUser, string Remark, string ResponseContent = "", Payment payment = null, bool CanSave = true, List<Payment_Request> request_list = null, List<RoomFee> fee_list = null, List<Mall_Order> order_list = null, int OrderID = 0, bool IsWuYe = false, bool IsRoomFee = false)
        {
            if (payment == null)
            {
                payment = new Payment();
                payment.AddTime = DateTime.Now;
                payment.PayRequestTime = DateTime.Now;
            }
            payment.Amount = Amount;
            payment.PaymentType = PaymentType;
            payment.TradeNo = TradeNo;
            payment.Status = Status;
            payment.AddUser = AddUser;
            payment.Remark = Remark;
            payment.ResponseContent = ResponseContent;
            var OrderIDList = new List<int>();
            if (new Utility.SiteConfig().IsMallOn && order_list == null)
            {
                order_list = Mall_Order.GetMall_OrderListByTradeNo(TradeNo).ToList();
            }
            if (order_list != null)
            {
                OrderIDList = order_list.Select(p => p.ID).ToList();
            }
            if (OrderID > 0 && !OrderIDList.Contains(OrderID))
            {
                OrderIDList.Add(OrderID);
            }
            if (OrderIDList.Count > 0)
            {
                payment.OrderID = OrderIDList[0];
                Mall_OrderTradeNo.Save_Mall_OrderTradeNo(payment.TradeNo, OrderIDList: OrderIDList);
            }
            if (order_list != null && order_list.Count > 0)
            {
                IsRoomFee = order_list.FirstOrDefault(p => p.ProductTypeID == 10) != null;
            }
            if (IsRoomFee)
            {
                if (request_list == null || request_list.Count == 0)
                {
                    request_list = Foresight.DataAccess.Payment_Request.GetPayment_RequestByTradeNo(TradeNo, payment.OrderID).ToList();
                }
                if ((fee_list == null || fee_list.Count == 0) && request_list.Count > 0)
                {
                    fee_list = Foresight.DataAccess.RoomFee.GetRoomFeeListByIDs(request_list.Select(p => p.RoomFeeID).ToList()).ToList();
                }
            }
            if (CanSave)
            {
                using (SqlHelper helper = new SqlHelper())
                {
                    try
                    {
                        helper.BeginTransaction();
                        payment.Save(helper);
                        if (order_list != null && order_list.Count > 0)
                        {
                            foreach (var item in order_list)
                            {
                                if (item.ProductTypeID == 10)
                                {
                                    IsRoomFee = true;
                                }
                                item.TradeNo = payment.TradeNo;
                                item.Save(helper);
                            }
                        }
                        if (request_list != null && request_list.Count > 0)
                        {
                            foreach (var item in request_list)
                            {
                                item.PaymentID = payment.ID;
                                item.OrderID = payment.OrderID;
                                item.Save(helper);
                            }
                        }
                        if (fee_list != null && fee_list.Count > 0)
                        {
                            foreach (var item in fee_list)
                            {
                                item.TradeNo = payment.TradeNo;
                                item.OrderID = payment.OrderID;
                                item.Save(helper);
                            }
                        }

                        helper.Commit();
                        return payment;
                    }
                    catch (Exception ex)
                    {
                        helper.Rollback();
                        throw ex;
                    }
                }
            }
            return payment;
        }
        public static void CompletePayment(string TradeNo = "", Payment payment = null, Mall_Order order = null)
        {
            using (SqlHelper helper = new SqlHelper())
            {
                CompletePayment(helper, TradeNo: TradeNo, payment: payment, order: order);
            }
        }
        public static void CompletePayment(SqlHelper helper, string TradeNo = "", Payment payment = null, Mall_Order order = null)
        {
            if (payment == null)
            {
                payment = Payment.GetPaymentByTradeNo(TradeNo, helper);
            }
            int OrderID = 0;
            if (payment != null)
            {
                OrderID = payment.OrderID;
                TradeNo = payment.TradeNo;
                if (payment.Status != 2)
                {
                    payment.Status = 2;
                    payment.PayCompleteTime = DateTime.Now;
                    payment.PayResult = "Success";
                    payment.Save(helper);
                }
            }
            if (!new Utility.SiteConfig().IsMallOn)
            {
                return;
            }
            if (order == null)
            {
                order = Mall_Order.GetMall_OrderByTradeNo(helper, TradeNo, OrderID: OrderID);
            }
            if (order != null)
            {
                order.PayTime = DateTime.Now;
                if (payment != null)
                {
                    if (payment.PaymentType.Equals(Utility.EnumModel.PaymentTypeDefine.app_wx.ToString()))
                    {
                        order.PaymentMethod = Utility.EnumModel.Mall_OrderPaymentMethodDefine.wxpay.ToString();
                    }
                    else if (payment.PaymentType.Equals(Utility.EnumModel.PaymentTypeDefine.app_alipay.ToString()))
                    {
                        order.PaymentMethod = Utility.EnumModel.Mall_OrderPaymentMethodDefine.alipay.ToString();
                    }
                    else if (payment.PaymentType.Equals(Utility.EnumModel.PaymentTypeDefine.app_balance_pay.ToString()))
                    {
                        order.PaymentMethod = Utility.EnumModel.Mall_OrderPaymentMethodDefine.balance.ToString();
                    }
                }
                if (order.ProductTypeID == 10)
                {
                    if (order.OrderStatus != 3)
                    {
                        order.OrderStatus = 3;
                        order.CompleteTime = DateTime.Now;
                        order.Save(helper);
                    }
                }
                else
                {
                    if (order.OrderStatus != 5)
                    {
                        order.OrderStatus = 5;
                        order.IsReadNewOrder = false;
                        order.Save(helper);
                    }
                }
            }
        }
    }
}
