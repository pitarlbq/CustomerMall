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
    /// This object represents the properties and methods of a RoomFeeOrder.
    /// </summary>
    public partial class RoomFeeOrder : EntityBase
    {
        public static RoomFeeOrder GetTopRoomFeeOrder()
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            return GetOne<RoomFeeOrder>("select top 1 * from RoomFeeOrder order by OrderTime desc", parameters);
        }
        public static RoomFeeOrder[] GetRoomFeeOrderList(List<int> IDList)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (IDList.Count > 0)
            {
                conditions.Add("[ID] in (" + string.Join(",", IDList.ToArray()) + ")");
            }
            return GetList<RoomFeeOrder>("select * from RoomFeeOrder where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
        public static Ui.DataGrid GeRoomFeeOrderGridByKeywords(DateTime StartTime, DateTime EndTime, List<int> AddManList, List<int> ApproveManList, List<int> ApproveStatusList, string orderBy, long startRowIndex, int pageSize)
        {
            long totalRows = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (StartTime > DateTime.MinValue)
            {
                conditions.Add("[OrderTime]>=@StartTime");
                parameters.Add(new SqlParameter("@StartTime", StartTime));
            }
            if (EndTime > DateTime.MinValue)
            {
                conditions.Add("[OrderTime]<=@EndTime");
                parameters.Add(new SqlParameter("@EndTime", EndTime));
            }
            if (AddManList.Count > 0)
            {
                conditions.Add("[OrderUserID] in (" + string.Join(",", AddManList.ToArray()) + ")");
            }
            if (ApproveManList.Count > 0)
            {
                conditions.Add("[ApproveManUserID] in (" + string.Join(",", ApproveManList.ToArray()) + ")");
            }
            if (ApproveStatusList.Count > 0)
            {
                conditions.Add("[ApproveStatus] in (" + string.Join(",", ApproveStatusList.ToArray()) + ")");
            }
            string fieldList = "[RoomFeeOrder].* ";
            string Statement = " from [RoomFeeOrder] where  " + string.Join(" and ", conditions.ToArray());
            RoomFeeOrder[] list = new RoomFeeOrder[] { };
            list = GetList<RoomFeeOrder>(fieldList, Statement, parameters, orderBy, startRowIndex, pageSize, out totalRows).ToArray();
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
        public static RoomFeeOrder GetLastRoomFeeOrder(int OrderNumberID, SqlHelper helper)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            //conditions.Add("ChargeTime is not null");
            conditions.Add("[AddTime]>=@AddTime");
            conditions.Add("isnull([OrderNumberID],0)=@OrderNumberID");
            parameters.Add(new SqlParameter("@OrderNumberID", OrderNumberID));
            DateTime start = DateTime.Today.AddDays(1 - DateTime.Now.Day);
            parameters.Add(new SqlParameter("@AddTime", start));
            return GetOne<RoomFeeOrder>("select top 1 * from RoomFeeOrder where " + string.Join(" and ", conditions.ToArray()) + " order by AddTime desc", parameters, helper);
        }
        public static string GetLastestRoomFeeOrderNumber(string OrderTypeName, int RoomID, out int OrderNumberID)
        {
            using (SqlHelper helper = new SqlHelper())
            {
                return GetLastestRoomFeeOrderNumber(OrderTypeName, RoomID, helper, out OrderNumberID);
            }
        }
        public static string GetLastestRoomFeeOrderNumber(string OrderTypeName, int RoomID, SqlHelper helper, out int OrderNumberID)
        {
            if (string.IsNullOrEmpty(OrderTypeName))
            {
                OrderTypeName = Foresight.DataAccess.OrderTypeNameDefine.roomfeeorder.ToString();
            }
            Sys_OrderNumber sysOrderNumber = Sys_OrderNumber.GetSys_OrderNumberByRoomID(OrderTypeName, RoomID, helper);
            if (sysOrderNumber == null)
            {
                OrderNumberID = 0;
                return string.Empty;
            }
            OrderNumberID = sysOrderNumber.ID;
            RoomFeeOrder history = RoomFeeOrder.GetLastRoomFeeOrder(OrderNumberID, helper);
            string Part1 = string.Empty;
            Part1 += sysOrderNumber.OrderPrefix;
            string time_yyyy = DateTime.Now.ToString("yyyy");
            string time_mm = DateTime.Now.ToString("MM");
            string time_dd = DateTime.Now.ToString("dd");
            if (sysOrderNumber.UseYear)
            {
                Part1 += time_yyyy;
            }
            if (sysOrderNumber.UseMonth)
            {
                Part1 += time_mm;
            }
            if (sysOrderNumber.UseDay)
            {
                Part1 += time_dd;
            }
            int OrderNumberCount = sysOrderNumber.OrderNumberCount <= 0 ? 3 : sysOrderNumber.OrderNumberCount;
            int number = 1;
            if (history != null && !string.IsNullOrEmpty(history.OrderNumber))
            {
                number = PrintRoomFeeHistory.GetOrderNumberBySysOrder(history.OrderNumber, sysOrderNumber, out OrderNumberCount);
            }
            return Part1 + number.ToString("D" + OrderNumberCount);
        }
        public string ApproveStatusDesc
        {
            get
            {
                string desc = string.Empty;
                switch (this.ApproveStatus)
                {
                    case 0:
                        desc = "待审核";
                        break;
                    case 1:
                        desc = "审核通过";
                        break;
                    case 2:
                        desc = "审核未通过";
                        break;
                    case 3:
                        desc = "已作废";
                        break;
                    default:
                        break;
                }
                return desc;
            }
        }
    }
}
