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
    /// This object represents the properties and methods of a CKProductInSumary.
    /// </summary>
    public partial class CKProductInSumary : EntityBase
    {
        public static CKProductInSumary GetCKProductInSumaryByOrderNumber(string OrderNumber)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[OrderNumber]=@OrderNumber");
            parameters.Add(new SqlParameter("@OrderNumber", OrderNumber));
            return GetOne<CKProductInSumary>("select top 1 * from CKProductInSumary where " + string.Join(" and ", conditions.ToArray()) + " order by AddTime desc", parameters);
        }
        public static CKProductInSumary GetLastCKProductInSumary(int OrderNumberID, SqlHelper helper)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[AddTime]>=@AddTime");
            conditions.Add("isnull([OrderNumberID],0)=@OrderNumberID");
            parameters.Add(new SqlParameter("@OrderNumberID", OrderNumberID));
            DateTime start = DateTime.Today.AddDays(1 - DateTime.Now.Day);
            parameters.Add(new SqlParameter("@AddTime", start));
            return GetOne<CKProductInSumary>("select top 1 * from CKProductInSumary where " + string.Join(" and ", conditions.ToArray()) + " order by AddTime desc", parameters, helper);
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
                OrderTypeName = Foresight.DataAccess.OrderTypeNameDefine.productinnumber.ToString();
            }
            Sys_OrderNumber sysOrderNumber = Sys_OrderNumber.GetSys_OrderNumberByRoomID(OrderTypeName, 0, helper);
            if (sysOrderNumber == null)
            {
                OrderNumberID = 0;
                return string.Empty;
            }
            OrderNumberID = sysOrderNumber.ID;
            CKProductInSumary history = CKProductInSumary.GetLastCKProductInSumary(OrderNumberID, helper);
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
