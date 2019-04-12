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
    /// This object represents the properties and methods of a Mall_OrderTradeNo.
    /// </summary>
    public partial class Mall_OrderTradeNo : EntityBase
    {
        public static void Save_Mall_OrderTradeNo(string TradeNo, List<int> OrderIDList = null)
        {
            var condtions = new List<string>();
            if (OrderIDList != null && OrderIDList.Count > 0)
            {
                condtions.Add("[OrderID] in (" + string.Join(",", OrderIDList.ToArray()) + ")");
            }
            else
            {
                condtions.Add("TradeNo=@TradeNo");
            }
            string cmdtext = "select * from [Mall_OrderTradeNo] where " + string.Join(" and ", condtions.ToArray());
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@TradeNo", TradeNo));
            var orderTradeList = GetList<Mall_OrderTradeNo>(cmdtext, parameters);
            if (OrderIDList == null)
            {
                OrderIDList = orderTradeList.Select(p => p.OrderID).ToList();
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    if (OrderIDList == null || OrderIDList.Count == 0)
                    {
                        OrderIDList = new List<int>();
                    }
                    if (OrderIDList.Count == 0)
                    {
                        var payment = Payment.GetPaymentByTradeNo(TradeNo, helper);
                        if (payment != null)
                        {
                            OrderIDList.Add(payment.OrderID);
                        }
                    }
                    foreach (var OrderID in OrderIDList)
                    {
                        var data = orderTradeList.FirstOrDefault(p => p.TradeNo.Equals(TradeNo) && p.OrderID == OrderID);
                        if (data == null)
                        {
                            data = new Mall_OrderTradeNo();
                            data.OrderID = OrderID;
                            data.TradeNo = TradeNo;
                            data.AddTime = DateTime.Now;
                            data.Save(helper);
                        }
                    }
                    cmdtext = "update [Mall_Order] set TradeNo=@TradeNo where [ID] in (" + string.Join(",", OrderIDList.ToArray()) + ")";
                    parameters = new List<SqlParameter>();
                    parameters.Add(new SqlParameter("@TradeNo", TradeNo));
                    helper.Execute(cmdtext, CommandType.Text, parameters);
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    Utility.LogHelper.WriteError("Mall_OrderTradeNo", "Save_Mall_OrderTradeNo", ex);
                }
            }
        }
    }
}
