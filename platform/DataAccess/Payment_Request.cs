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
    /// This object represents the properties and methods of a Payment_Request.
    /// </summary>
    public partial class Payment_Request : EntityBase
    {
        public static Payment_Request[] GetPayment_RequestByRoomFeeIDList(int[] RoomFeeIDList)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            if (RoomFeeIDList.Length == 0)
            {
                return new Payment_Request[] { };
            }
            conditions.Add("[RoomFeeID] in (" + string.Join(",", RoomFeeIDList) + ")");
            string Statement = @"select * from Payment_Request where " + string.Join(" and ", conditions);
            return GetList<Payment_Request>(Statement, parameters).ToArray();
        }
        public static Payment_Request[] GetPayment_RequestByPaymentID(int PaymentID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[PaymentID]=@PaymentID");
            parameters.Add(new SqlParameter("@PaymentID", PaymentID));
            string Statement = @"select * from Payment_Request where " + string.Join(" and ", conditions);
            return GetList<Payment_Request>(Statement, parameters).ToArray();
        }
        public static Payment_Request[] GetPayment_RequestByTradeNo(string TradeNo, int OrderID = 0)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            List<string> sub_conditions = new List<string>();
            if (OrderID > 0)
            {
                sub_conditions.Add("[OrderID]=@OrderID");
                sub_conditions.Add("[PaymentID] in (select ID from Payment where [TradeNo]=@TradeNo or [TradeNo] in (select TradeNo from [Mall_OrderTradeNo] where [OrderID]=@OrderID))");
                conditions.Add("(" + string.Join(" or ", sub_conditions.ToArray()) + ")");
            }
            else
            {
                conditions.Add("[PaymentID] in (select ID from Payment where [TradeNo]=@TradeNo)");
            }
            parameters.Add(new SqlParameter("@OrderID", OrderID));
            parameters.Add(new SqlParameter("@TradeNo", TradeNo));
            string Statement = @"select * from Payment_Request where " + string.Join(" and ", conditions) + " order by [AddTime] desc";
            var list = GetList<Payment_Request>(Statement, parameters).ToArray();
            var results = new List<Payment_Request>();
            foreach (var item in list)
            {
                if (results.FirstOrDefault(p => p.RoomFeeID == item.RoomFeeID) == null)
                {
                    results.Add(item);
                }
            }
            return results.ToArray();
        }
    }
}
