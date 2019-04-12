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
    /// This object represents the properties and methods of a CKProductOutSumary.
    /// </summary>
    public partial class CKProductOutSumary : EntityBase
    {
        public static CKProductOutSumary GetLastCKProductOutSumary(int OrderNumberID, SqlHelper helper)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[AddTime]>=@AddTime");
            conditions.Add("isnull([OrderNumberID],0)=@OrderNumberID");
            parameters.Add(new SqlParameter("@OrderNumberID", OrderNumberID));
            DateTime start = DateTime.Today.AddDays(1 - DateTime.Now.Day);
            parameters.Add(new SqlParameter("@AddTime", start));
            return GetOne<CKProductOutSumary>("select top 1 * from CKProductOutSumary where " + string.Join(" and ", conditions.ToArray()) + " order by AddTime desc", parameters, helper);
        }
        public static string GetLastestOrderNumber(out int OrderNumberID)
        {
            using (SqlHelper helper = new SqlHelper())
            {
                return GetLastestPrintNumber(null, helper, out OrderNumberID);
            }
        }
        public static string GetLastestPrintNumber(string OrderTypeName, SqlHelper helper, out int OrderNumberID)
        {
            if (string.IsNullOrEmpty(OrderTypeName))
            {
                OrderTypeName = Foresight.DataAccess.OrderTypeNameDefine.productoutnumber.ToString();
            }
            Sys_OrderNumber sysOrderNumber = Sys_OrderNumber.GetSys_OrderNumberByRoomID(OrderTypeName, 0, helper);
            if (sysOrderNumber == null)
            {
                OrderNumberID = 0;
                return string.Empty;
            }
            OrderNumberID = sysOrderNumber.ID;
            CKProductOutSumary history = CKProductOutSumary.GetLastCKProductOutSumary(OrderNumberID, helper);
            string Part1 = string.Empty;
            Part1 += sysOrderNumber.OrderPrefix;
            if (sysOrderNumber.UseYear)
            {
                Part1 += DateTime.Now.ToString("yyyy");
            }
            if (sysOrderNumber.UseMonth)
            {
                Part1 += DateTime.Now.ToString("MM");
            }
            if (sysOrderNumber.UseDay)
            {
                Part1 += DateTime.Now.ToString("dd");
            }
            int OrderNumberCount = sysOrderNumber.OrderNumberCount <= 0 ? 3 : sysOrderNumber.OrderNumberCount;
            int number = 1;
            if (history != null && !string.IsNullOrEmpty(history.OrderNumber))
            {
                number = PrintRoomFeeHistory.GetOrderNumberBySysOrder(history.OrderNumber, sysOrderNumber, out OrderNumberCount);
            }
            return Part1 + number.ToString("D" + OrderNumberCount);
        }
    }
}
