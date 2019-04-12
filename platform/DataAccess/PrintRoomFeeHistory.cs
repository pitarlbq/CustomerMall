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
    /// This object represents the properties and methods of a PrintRoomFeeHistory.
    /// </summary>
    public partial class PrintRoomFeeHistory : EntityBase
    {
        public static PrintRoomFeeHistory GetPrintRoomFeeHistoryByPrintNumber(string PrintNumber, int PrintID, SqlHelper helper)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[PrintNumber]=@PrintNumber");
            parameters.Add(new SqlParameter("@PrintNumber", PrintNumber));
            if (PrintID > 0)
            {
                conditions.Add("[ID]!=@PrintID");
                parameters.Add(new SqlParameter("@PrintID", PrintID));
            }
            return GetOne<PrintRoomFeeHistory>("select top 1 * from PrintRoomFeeHistory where " + string.Join(" and ", conditions.ToArray()), parameters, helper);
        }
        public static PrintRoomFeeHistory GetPrintRoomFeeHistoryByPrintNumber(string PrintNumber, SqlHelper helper)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[PrintNumber]=@PrintNumber");
            parameters.Add(new SqlParameter("@PrintNumber", PrintNumber));
            return GetOne<PrintRoomFeeHistory>("select top 1 * from PrintRoomFeeHistory where " + string.Join(" and ", conditions.ToArray()), parameters, helper);
        }
        public static PrintRoomFeeHistory[] GetPrintRoomFeeList(List<int> IDList = null, List<int> RoomFeeHistoryIDList = null)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            if (IDList != null && IDList.Count > 0)
            {
                conditions.Add("[ID] in (" + string.Join(",", IDList.ToArray()) + ")");
            }
            if (RoomFeeHistoryIDList != null && RoomFeeHistoryIDList.Count > 0)
            {
                conditions.Add("[ID] in (select [PrintID] from [RoomFeeHistory] where HistoryID in (" + string.Join(",", RoomFeeHistoryIDList.ToArray()) + "))");
            }
            if (conditions.Count == 0)
            {
                return new PrintRoomFeeHistory[] { };
            }
            return GetList<PrintRoomFeeHistory>("select * from PrintRoomFeeHistory where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
        public static PrintRoomFeeHistory GetLastPrintRoomFeeHistory(int OrderNumberID)
        {
            using (SqlHelper helper = new SqlHelper())
            {
                return GetLastPrintRoomFeeHistory(OrderNumberID, helper);
            }
        }
        public static PrintRoomFeeHistory GetLastPrintRoomFeeHistory(int OrderNumberID, SqlHelper helper)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("isnull([OrderNumberID],0)=@OrderNumberID");
            conditions.Add("[ID] in (select [PrintID] from [RoomFeeHistory])");
            parameters.Add(new SqlParameter("@OrderNumberID", OrderNumberID));
            return GetOne<PrintRoomFeeHistory>("select top 1 * from PrintRoomFeeHistory where " + string.Join(" and ", conditions.ToArray()) + " order by AddTime desc", parameters, helper);
        }
        public static string GetLastestPrintNumber(string OrderTypeName, int RoomID, out int OrderNumberID)
        {
            using (SqlHelper helper = new SqlHelper())
            {
                return GetLastestPrintNumber(OrderTypeName, RoomID, helper, out OrderNumberID);
            }
        }
        public static string GetLastestPrintNumber(int RoomID, SqlHelper helper, out int OrderNumberID)
        {
            return GetLastestPrintNumber(null, RoomID, helper, out OrderNumberID);
        }
        public static string GetLastestPrintNumber(string OrderTypeName, int RoomID, SqlHelper helper, out int OrderNumberID)
        {
            if (string.IsNullOrEmpty(OrderTypeName))
            {
                OrderTypeName = Foresight.DataAccess.OrderTypeNameDefine.chargefee.ToString();
            }
            Sys_OrderNumber sysOrderNumber = Sys_OrderNumber.GetSys_OrderNumberByRoomID(OrderTypeName, RoomID, helper);
            if (sysOrderNumber == null)
            {
                OrderNumberID = 0;
                return string.Empty;
            }
            OrderNumberID = sysOrderNumber.ID;
            PrintRoomFeeHistory history = GetLastPrintRoomFeeHistory(OrderNumberID, helper);
            string part1Str = GetLastestPrintNumberPart1(OrderTypeName, RoomID, helper, out OrderNumberID, sysOrderNumber: sysOrderNumber, history: history);
            int OrderNumberCount = 0;
            int part2Num = GetLastestPrintNumberPart2(OrderTypeName, RoomID, helper, out OrderNumberID, out OrderNumberCount, sysOrderNumber: sysOrderNumber, history: history);
            return part1Str + part2Num.ToString("D" + OrderNumberCount);
        }
        public static string GetLastestPrintNumberPart1(string OrderTypeName, int RoomID, SqlHelper helper, out int OrderNumberID, Sys_OrderNumber sysOrderNumber = null, PrintRoomFeeHistory history = null)
        {
            if (string.IsNullOrEmpty(OrderTypeName))
            {
                OrderTypeName = OrderTypeNameDefine.chargefee.ToString();
            }
            if (sysOrderNumber == null)
            {
                sysOrderNumber = Sys_OrderNumber.GetSys_OrderNumberByRoomID(OrderTypeName, RoomID, helper);
            }
            if (sysOrderNumber == null)
            {
                OrderNumberID = 0;
                return string.Empty;
            }
            OrderNumberID = sysOrderNumber.ID;
            if (history == null)
            {
                history = GetLastPrintRoomFeeHistory(OrderNumberID, helper);
            }
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
            return Part1;
        }
        public static int GetLastestPrintNumberPart2(string OrderTypeName, int RoomID, SqlHelper helper, out int OrderNumberID, out int OrderNumberCount, Sys_OrderNumber sysOrderNumber = null, PrintRoomFeeHistory history = null)
        {
            OrderNumberCount = 0;
            if (string.IsNullOrEmpty(OrderTypeName))
            {
                OrderTypeName = OrderTypeNameDefine.chargefee.ToString();
            }
            if (sysOrderNumber == null)
            {
                sysOrderNumber = Sys_OrderNumber.GetSys_OrderNumberByRoomID(OrderTypeName, RoomID, helper);
            }
            if (sysOrderNumber == null)
            {
                OrderNumberID = 0;
                return 0;
            }
            OrderNumberID = sysOrderNumber.ID;
            if (history == null)
            {
                history = GetLastPrintRoomFeeHistory(OrderNumberID, helper);
            }
            OrderNumberCount = sysOrderNumber.OrderNumberCount <= 0 ? 3 : sysOrderNumber.OrderNumberCount;
            int number = 1;
            if (history != null && !string.IsNullOrEmpty(history.PrintNumber))
            {
                number = GetOrderNumberBySysOrder(history.PrintNumber, sysOrderNumber, out OrderNumberCount);
            }
            //return number.ToString("D" + OrderNumberCount);
            return number;
        }
        public static int GetOrderNumberBySysOrder(string history_printnumber, Sys_OrderNumber sysOrderNumber, out int OrderNumberCount)
        {
            int number = 1;
            string time_yyyy = DateTime.Now.ToString("yyyy");
            string time_mm = DateTime.Now.ToString("MM");
            string time_dd = DateTime.Now.ToString("dd");
            OrderNumberCount = sysOrderNumber.OrderNumberCount <= 0 ? 3 : sysOrderNumber.OrderNumberCount;
            int use_count_dd = 0;
            int use_count_mm = 0;
            int use_count_yy = 0;
            if (sysOrderNumber.UseDay)
            {
                use_count_dd = 2;
            }
            if (sysOrderNumber.UseMonth)
            {
                use_count_mm = 2 + use_count_dd;
            }
            if (sysOrderNumber.UseYear)
            {
                use_count_yy = 4 + use_count_mm;
            }
            if (history_printnumber.Length >= OrderNumberCount + use_count_yy)
            {
                string printNumber = history_printnumber.Substring((history_printnumber.Length - OrderNumberCount), OrderNumberCount);
                int _printnumber = 0;
                int.TryParse(printNumber, out _printnumber);
                int new_number = _printnumber + 1;
                if (new_number.ToString().Length > OrderNumberCount)
                {
                    new_number = 1;
                }
                if (sysOrderNumber.IsDayReset && sysOrderNumber.UseDay)
                {
                    string printnumber_dd = history_printnumber.Substring((history_printnumber.Length - OrderNumberCount - use_count_dd), 2);
                    if (printnumber_dd == time_dd)
                    {
                        number = new_number;
                    }
                }
                else if (sysOrderNumber.IsMonthReset && sysOrderNumber.UseMonth)
                {
                    string printnumber_mm = history_printnumber.Substring((history_printnumber.Length - OrderNumberCount - use_count_mm), 2);
                    if (printnumber_mm == time_mm)
                    {
                        number = new_number;
                    }
                }
                else if (sysOrderNumber.IsYearReset && sysOrderNumber.UseYear)
                {
                    string printnumber_year = history_printnumber.Substring((history_printnumber.Length - OrderNumberCount - use_count_yy), 4);
                    if (printnumber_year == time_yyyy)
                    {
                        number = new_number;
                    }
                }
                else
                {
                    number = new_number;
                }
            }
            return number;
        }
        public static decimal GetRoomWeiShuBalance(int PrintID, int RoomID, DateTime? ChargeTime = null)
        {
            using (SqlHelper helper = new SqlHelper())
            {
                return GetRoomWeiShuBalance(PrintID, RoomID, helper, ChargeTime);
            }
        }
        public static decimal GetRoomWeiShuBalance(int PrintID, int RoomID, SqlHelper helper, DateTime? ChargeTime = null)
        {
            decimal total = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add(" 1=1 ");
            if (ChargeTime.HasValue)
            {
                DateTime _chargetime = Convert.ToDateTime(ChargeTime);
                if (_chargetime > DateTime.MinValue)
                {
                    conditions.Add("[ID] in (select [PrintID] from [RoomFeeHistory] where [ChargeTime]<@ChargeTime)");
                    parameters.Add(new SqlParameter("@ChargeTime", ChargeTime));
                }
            }
            if (PrintID > 0)
            {
                conditions.Add("[ID] in (select [PrintID] from [RoomFeeHistory] where [ChargeState] in (1,4,5) and [RoomID] in (select [RoomID] from [RoomFeeHistory] where [PrintID]=@PrintID))");
                parameters.Add(new SqlParameter("@PrintID", PrintID));
                string cmdtext = @"select sum(WeiShuMore) from [PrintRoomFeeHistory] where " + string.Join(" and ", conditions.ToArray());
                var TotalBalance = helper.ExecuteScalar(cmdtext, CommandType.Text, parameters);
                decimal totalbalance = 0;
                if (TotalBalance != null)
                {
                    decimal.TryParse(TotalBalance.ToString(), out totalbalance);
                }
                cmdtext = @"select sum(WeiShuConsume) from [PrintRoomFeeHistory] where " + string.Join(" and ", conditions.ToArray());
                var ConsumeBalance = helper.ExecuteScalar(cmdtext, CommandType.Text, parameters);
                decimal consumebalance = 0;
                if (ConsumeBalance != null)
                {
                    decimal.TryParse(ConsumeBalance.ToString(), out consumebalance);
                }
                total = totalbalance - consumebalance;
            }
            else if (RoomID > 0)
            {
                conditions.Add("[ID] in (select [PrintID] from [RoomFeeHistory] where [ChargeState] in (1,4,5) and [RoomID]=@RoomID)");
                parameters.Add(new SqlParameter("@RoomID", RoomID));
                string cmdtext = @"select sum(WeiShuMore) from [PrintRoomFeeHistory] where " + string.Join(" and ", conditions.ToArray());
                var TotalBalance = helper.ExecuteScalar(cmdtext, CommandType.Text, parameters);
                decimal totalbalance = 0;
                if (TotalBalance != null)
                {
                    decimal.TryParse(TotalBalance.ToString(), out totalbalance);
                }
                cmdtext = @"select sum(WeiShuConsume) from [PrintRoomFeeHistory] where" + string.Join(" and ", conditions.ToArray());
                var ConsumeBalance = helper.ExecuteScalar(cmdtext, CommandType.Text, parameters);
                decimal consumebalance = 0;
                if (ConsumeBalance != null)
                {
                    decimal.TryParse(ConsumeBalance.ToString(), out consumebalance);
                }
                total = totalbalance - consumebalance;
            }
            return total;
        }
        public static int GetCountByChargeState(DateTime StartTime, DateTime EndTime, string ChargeMan, List<int> ChargeStateList, List<int> ProjectIDList, int RoomFeeOrderID, bool IsRoomFeeSearch, List<int> HistoryIDList = null, bool DeleteTempHistoryIDList = true, int UserID = 0)
        {
            int total = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            //conditions.Add("1=1");
            if (HistoryIDList != null && HistoryIDList.Count > 0)
            {
                if (HistoryIDList.Count > 20)
                {
                    ViewRoomFeeHistory.CreateTempTable(HistoryIDList, DeleteTempHistoryIDList, UserID: UserID);
                    conditions.Add("EXISTS (SELECT 1 FROM [TempIDs] WHERE id in (select HistoryID from [RoomFeeHistory] where [PrintID]=[PrintRoomFeeHistory].ID) and [UserID]=" + UserID + ")");
                }
                else if (HistoryIDList.Count > 0)
                {
                    conditions.Add("[PrintRoomFeeHistory].ID in (select PrintID from [RoomFeeHistory] where HistoryID in (" + string.Join(",", HistoryIDList.ToArray()) + "))");
                }
            }
            if (RoomFeeOrderID > 0)
            {
                conditions.Add("isnull([RoomFeeOrderID],0)=@RoomFeeOrderID");
                parameters.Add(new SqlParameter("@RoomFeeOrderID", RoomFeeOrderID));
            }
            else if (IsRoomFeeSearch)
            {
                conditions.Add("isnull([RoomFeeOrderID],0)=0");
                conditions.Add("[ID] in (select [PrintID] from [RoomFeeHistory] where [ChargeID] in (select [ID] from [ChargeSummary] where isnull([IsOrderFeeOn],0)=1) or isnull(ChargeID,0)=0)");
            }
            if (StartTime > DateTime.MinValue)
            {
                conditions.Add("[ID] in (select [PrintID] from [RoomFeeHistory] where [ChargeTime]>@StartTime)");
                parameters.Add(new SqlParameter("@StartTime", StartTime));
            }
            if (EndTime > DateTime.MinValue)
            {
                conditions.Add("[ID] in (select [PrintID] from [RoomFeeHistory] where [ChargeTime]<@EndTime)");
                parameters.Add(new SqlParameter("@EndTime", EndTime));
            }
            #region 收款人查询
            string cmd = string.Empty;
            if (!string.IsNullOrEmpty(ChargeMan))
            {
                string[] keywords = ChargeMan.Trim().Split(',');
                for (int i = 0; i < keywords.Length; i++)
                {
                    if (string.IsNullOrEmpty(keywords[i].ToString()))
                    {
                        continue;
                    }
                    if (i + 1 == keywords.Length)
                    {
                        if (keywords.Length == 1)
                        {
                            cmd += "  and  ([ChargeMan] like '%" + keywords[i] + "%')";
                        }
                        else
                        {
                            cmd += "  ([ChargeMan] like '%" + keywords[i] + "%'))";
                        }
                    }
                    else if (i == 0)
                    {
                        cmd += " and (([ChargeMan] like '%" + keywords[i] + "%') or";
                    }
                    else
                    {
                        cmd += "  ([ChargeMan] like '%" + keywords[i] + "%') or ";
                    }
                }
            }
            #endregion
            //if (!string.IsNullOrEmpty(ChargeMan))
            //{
            //    conditions.Add("[ChargeMan]=@ChargeMan");
            //    parameters.Add(new SqlParameter("@ChargeMan", ChargeMan));
            //}
            if (ChargeStateList.Count > 0)
            {
                conditions.Add("[ID] in (select [PrintID] from [RoomFeeHistory] where [ChargeState] in (" + string.Join(",", ChargeStateList.ToArray()) + "))");
            }
            if (ProjectIDList.Count > 0)
            {
                List<string> cmdlist = ViewRoomFeeHistory.GetProjectIDListConditions(ProjectIDList, IncludeRelation: false, UserID: UserID);
                conditions.Add("[ID] in (select [PrintID] from [RoomFeeHistory] where (" + string.Join(" or ", cmdlist.ToArray()) + "))");
            }
            string cmdtext = "select count(1) from [PrintRoomFeeHistory] where " + string.Join(" and ", conditions.ToArray()) + cmd;
            using (SqlHelper helper = new SqlHelper())
            {
                object obj = helper.ExecuteScalar(cmdtext, CommandType.Text, parameters);
                if (obj != null)
                {
                    int.TryParse(obj.ToString(), out total);
                }
            }
            return total;
        }
        public static decimal GetSumCostByTime(DateTime StartTime, DateTime EndTime, List<int> ProjectIDList, List<int> RoomIDList, int UserID = 0)
        {
            List<int> ChargeStateList = new List<int>();
            ChargeStateList.Add(1);
            //ChargeStateList.Add(4);
            return GetSumCostByChargeState(StartTime, EndTime, string.Empty, ChargeStateList, ProjectIDList, RoomIDList, int.MinValue, false, UserID: UserID);
        }
        public static decimal GetSumCostByChargeState(DateTime StartTime, DateTime EndTime, string ChargeMan, List<int> ChargeStateList, List<int> ProjectIDList, int RoomFeeOrderID, bool IsRoomFeeSearch, List<int> HistoryIDList = null, bool DeleteTempHistoryIDList = true, int UserID = 0)
        {
            return GetSumCostByChargeState(StartTime, EndTime, ChargeMan, ChargeStateList, ProjectIDList, new List<int>(), RoomFeeOrderID, IsRoomFeeSearch, HistoryIDList, DeleteTempHistoryIDList: DeleteTempHistoryIDList, UserID: UserID);
        }
        public static decimal GetSumCostByChargeState(DateTime StartTime, DateTime EndTime, string ChargeMan, List<int> ChargeStateList, List<int> ProjectIDList, List<int> RoomIDList, int RoomFeeOrderID, bool IsRoomFeeSearch, List<int> HistoryIDList = null, bool DeleteTempHistoryIDList = true, int UserID = 0)
        {
            decimal total = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (HistoryIDList != null && HistoryIDList.Count > 0)
            {
                if (HistoryIDList.Count > 2)
                {
                    ViewRoomFeeHistory.CreateTempTable(HistoryIDList, DeleteTempHistoryIDList, UserID: UserID);
                    conditions.Add("EXISTS (SELECT 1 FROM [TempIDs] WHERE id in (select [HistoryID] from [RoomFeeHistory] where [PrintID]=[PrintRoomFeeHistory].[ID]) and [UserID]=" + UserID + ")");
                }
                else if (HistoryIDList.Count > 0)
                {
                    conditions.Add("[PrintRoomFeeHistory].ID in (select PrintID from [RoomFeeHistory] where HistoryID in (" + string.Join(",", HistoryIDList.ToArray()) + "))");
                }
            }
            if (RoomFeeOrderID > 0)
            {
                conditions.Add("isnull([RoomFeeOrderID],0)=@RoomFeeOrderID");
                parameters.Add(new SqlParameter("@RoomFeeOrderID", RoomFeeOrderID));
            }
            else if (IsRoomFeeSearch)
            {
                conditions.Add("isnull([RoomFeeOrderID],0)=0");
                conditions.Add("[ID] in (select [PrintID] from [RoomFeeHistory] where [ChargeID] in (select [ID] from [ChargeSummary] where isnull([IsOrderFeeOn],0)=1) or isnull(ChargeID,0)=0)");
            }
            if (ProjectIDList.Count > 0)
            {
                List<string> cmdlist = ViewRoomFeeHistory.GetProjectIDListConditions(ProjectIDList, IncludeRelation: false, UserID: UserID);
                conditions.Add("[ID] in (select [PrintID] from [RoomFeeHistory] where (" + string.Join(" or ", cmdlist.ToArray()) + "))");
            }
            if (RoomIDList.Count > 0)
            {
                List<string> cmdlist = ViewRoomFeeHistory.GetRoomIDListConditions(RoomIDList, IncludeRelation: false);
                conditions.Add("[ID] in (select [PrintID] from [RoomFeeHistory] where (" + string.Join(" or ", cmdlist.ToArray()) + "))");
            }
            if (StartTime > DateTime.MinValue)
            {
                conditions.Add("[ID] in (select [PrintID] from [RoomFeeHistory] where [ChargeTime]>@StartTime)");
                parameters.Add(new SqlParameter("@StartTime", StartTime));
            }
            if (EndTime > DateTime.MinValue)
            {
                conditions.Add("[ID] in (select [PrintID] from [RoomFeeHistory] where [ChargeTime]<@EndTime)");
                parameters.Add(new SqlParameter("@EndTime", EndTime));
            }
            #region 收款人查询
            string cmd = string.Empty;
            if (!string.IsNullOrEmpty(ChargeMan))
            {
                string[] keywords = ChargeMan.Trim().Split(',');
                for (int i = 0; i < keywords.Length; i++)
                {
                    if (string.IsNullOrEmpty(keywords[i].ToString()))
                    {
                        continue;
                    }
                    if (i + 1 == keywords.Length)
                    {
                        if (keywords.Length == 1)
                        {
                            cmd += "  and  ([ChargeMan] like '%" + keywords[i] + "%')";
                        }
                        else
                        {
                            cmd += "  ([ChargeMan] like '%" + keywords[i] + "%'))";
                        }
                    }
                    else if (i == 0)
                    {
                        cmd += " and (([ChargeMan] like '%" + keywords[i] + "%') or";
                    }
                    else
                    {
                        cmd += "  ([ChargeMan] like '%" + keywords[i] + "%') or ";
                    }
                }
            }
            #endregion
            //if (!string.IsNullOrEmpty(ChargeMan))
            //{
            //    conditions.Add("[ChargeMan]=@ChargeMan");
            //    parameters.Add(new SqlParameter("@ChargeMan", ChargeMan));
            //}
            if (ChargeStateList.Count > 0)
            {
                conditions.Add("[ID] in (select [PrintID] from [RoomFeeHistory] where [ChargeState] in (" + string.Join(",", ChargeStateList.ToArray()) + "))");
            }
            string cmdtext = "select sum(RealCost) from [PrintRoomFeeHistory] where " + string.Join(" and ", conditions.ToArray()) + cmd;
            using (SqlHelper helper = new SqlHelper())
            {
                object obj = helper.ExecuteScalar(cmdtext, CommandType.Text, parameters);
                if (obj != null)
                {
                    decimal.TryParse(obj.ToString(), out total);
                }
            }
            return total;
        }
        public static void UpdateRoomFeeOrderNumber(int RoomFeeOrderID, SqlHelper helper, List<int> HistoryIDList, int UserID = 0)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            conditions.Add("isnull([RoomFeeOrderID],0)=0");
            conditions.Add("[ID] in (select [PrintID] from [RoomFeeHistory] where [ChargeState] in (1,2,3,4,6,7))");
            if (HistoryIDList.Count <= 0)
            {
                throw new Exception("请选择历史单据");
            }
            if (HistoryIDList.Count > 2)
            {
                ViewRoomFeeHistory.CreateTempTable(HistoryIDList, UserID: UserID);
                conditions.Add("[ID] in (select [PrintID] from [RoomFeeHistory] where exists (select 1 from [TempIDs] where [TempIDs].id=[RoomFeeHistory].[HistoryID] and UserID=" + UserID + "))");
            }
            else if (HistoryIDList.Count > 0)
            {
                conditions.Add("[ID] in (select [PrintID] from [RoomFeeHistory] where [HistoryID] in (" + string.Join(",", HistoryIDList.ToArray()) + "))");
            }
            string cmdtext = "update [PrintRoomFeeHistory] set [RoomFeeOrderID]=@RoomFeeOrderID where " + string.Join(" and ", conditions.ToArray());
            parameters.Add(new SqlParameter("@RoomFeeOrderID", RoomFeeOrderID));
            int total = helper.Execute(cmdtext, CommandType.Text, parameters);
            if (total <= 0)
            {
                throw new Exception("请选择历史单据");
            }
        }
        public static PrintRoomFeeHistory[] GetPrintRoomFeeHistoryListByOpenID(string OpenID, int RoomID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("ID in (select [PrintID] from [RoomFeeHistory] where [ChargeState] in (1,4))");
            if (!string.IsNullOrEmpty(OpenID))
            {
                conditions.Add("[ID] in (select [PrintID] from [RoomFeeHistory] where [RoomID] in (select [ProjectID] from [WechatUser_Project] where [OpenID]=@OpenID) and ([OpenID]=@OpenID or ([OpenID] is null and Convert(nvarchar(500),[Remark]) like '%微信公众号%')))");
                parameters.Add(new SqlParameter("@OpenID", OpenID));
            }
            if (RoomID <= 0)
            {
                return new PrintRoomFeeHistory[] { };
            }
            conditions.Add("[ID] in (select [PrintID] from [RoomFeeHistory] where [RoomID] in (select [ID] from [Project] where [AllParentID] like '%," + RoomID + ",%' or ID=" + RoomID + "))");
            return GetList<PrintRoomFeeHistory>("select * from [PrintRoomFeeHistory] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
        public static PrintRoomFeeHistory[] GetPrintRoomFeeHistoryListByIDList(List<int> IDList)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (IDList.Count > 0)
            {
                conditions.Add("[ID] in (" + string.Join(",", IDList.ToArray()) + ")");
            }
            return GetList<PrintRoomFeeHistory>("select * from [PrintRoomFeeHistory] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
        public static PrintRoomFeeHistory[] GetPrintRoomFeeHistoryListByRoomProjectIDList(DateTime StartTime, DateTime EndTime, List<int> ProjectIDList, List<int> RoomIDList, int UserID = 0, List<int> ChargeStateList = null)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (ChargeStateList != null && ChargeStateList.Count > 0)
            {
                conditions.Add("[ChargeState] in (" + string.Join(",", ChargeStateList.ToArray()) + ")");
            }
            if (ProjectIDList.Count > 0)
            {
                List<string> cmdlist = ViewRoomFeeHistory.GetProjectIDListConditions(ProjectIDList, IncludeRelation: false, UserID: UserID);
                conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
            }
            if (RoomIDList.Count > 0)
            {
                List<string> cmdlist = ViewRoomFeeHistory.GetRoomIDListConditions(RoomIDList, IncludeRelation: false);
                conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
            }
            if (StartTime > DateTime.MinValue)
            {
                conditions.Add("Convert(nvarchar(10),[ChargeTime],120)>=@StartTime");
                parameters.Add(new SqlParameter("@StartTime", StartTime));
            }
            if (EndTime > DateTime.MinValue)
            {
                conditions.Add("Convert(nvarchar(10),[ChargeTime],120)<=@EndTime");
                parameters.Add(new SqlParameter("@EndTime", EndTime));
            }
            string cmdtext = "select * from [PrintRoomFeeHistory] where [ID] in (select [PrintID] from [RoomFeeHistory] where " + string.Join(" and ", conditions.ToArray()) + ")";
            return GetList<PrintRoomFeeHistory>(cmdtext, parameters).ToArray();
        }
        public static decimal GetSumWeiShuByChargeState(DateTime StartTime, DateTime EndTime, string ChargeMan, List<int> ChargeStateList, List<int> ProjectIDList, List<int> RoomIDList, int RoomFeeOrderID, bool IsRoomFeeSearch, List<int> HistoryIDList = null, bool DeleteTempHistoryIDList = true, int UserID = 0)
        {
            decimal total = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (HistoryIDList != null && HistoryIDList.Count > 0)
            {
                if (HistoryIDList.Count > 2)
                {
                    ViewRoomFeeHistory.CreateTempTable(HistoryIDList, DeleteTempHistoryIDList, UserID: UserID);
                    conditions.Add("EXISTS (SELECT 1 FROM [TempIDs] WHERE id in (select [HistoryID] from [RoomFeeHistory] where [PrintID]=[PrintRoomFeeHistory].[ID]) and [UserID]=" + UserID + ")");
                }
                else if (HistoryIDList.Count > 0)
                {
                    conditions.Add("[PrintRoomFeeHistory].ID in (select PrintID from [RoomFeeHistory] where HistoryID in (" + string.Join(",", HistoryIDList.ToArray()) + "))");
                }
            }
            if (RoomFeeOrderID > 0)
            {
                conditions.Add("isnull([RoomFeeOrderID],0)=@RoomFeeOrderID");
                parameters.Add(new SqlParameter("@RoomFeeOrderID", RoomFeeOrderID));
            }
            else if (IsRoomFeeSearch)
            {
                conditions.Add("isnull([RoomFeeOrderID],0)=0");
                conditions.Add("[ID] in (select [PrintID] from [RoomFeeHistory] where [ChargeID] in (select [ID] from [ChargeSummary] where isnull([IsOrderFeeOn],0)=1) or isnull(ChargeID,0)=0)");
            }
            if (ProjectIDList.Count > 0)
            {
                List<string> cmdlist = ViewRoomFeeHistory.GetProjectIDListConditions(ProjectIDList, IncludeRelation: false, UserID: UserID);
                conditions.Add("[ID] in (select [PrintID] from [RoomFeeHistory] where (" + string.Join(" or ", cmdlist.ToArray()) + "))");
            }
            if (RoomIDList.Count > 0)
            {
                List<string> cmdlist = ViewRoomFeeHistory.GetRoomIDListConditions(RoomIDList, IncludeRelation: false);
                conditions.Add("[ID] in (select [PrintID] from [RoomFeeHistory] where (" + string.Join(" or ", cmdlist.ToArray()) + ")");
            }
            if (StartTime > DateTime.MinValue)
            {
                conditions.Add("[ID] in (select [PrintID] from [RoomFeeHistory] where [ChargeTime]>@StartTime)");
                parameters.Add(new SqlParameter("@StartTime", StartTime));
            }
            if (EndTime > DateTime.MinValue)
            {
                conditions.Add("[ID] in (select [PrintID] from [RoomFeeHistory] where [ChargeTime]<@EndTime)");
                parameters.Add(new SqlParameter("@EndTime", EndTime));
            }
            #region 收款人查询
            string cmd = string.Empty;
            if (!string.IsNullOrEmpty(ChargeMan))
            {
                string[] keywords = ChargeMan.Trim().Split(',');
                for (int i = 0; i < keywords.Length; i++)
                {
                    if (string.IsNullOrEmpty(keywords[i].ToString()))
                    {
                        continue;
                    }
                    if (i + 1 == keywords.Length)
                    {
                        if (keywords.Length == 1)
                        {
                            cmd += "  and  ([ChargeMan] like '%" + keywords[i] + "%')";
                        }
                        else
                        {
                            cmd += "  ([ChargeMan] like '%" + keywords[i] + "%'))";
                        }
                    }
                    else if (i == 0)
                    {
                        cmd += " and (([ChargeMan] like '%" + keywords[i] + "%') or";
                    }
                    else
                    {
                        cmd += "  ([ChargeMan] like '%" + keywords[i] + "%') or ";
                    }
                }
            }
            #endregion
            //if (!string.IsNullOrEmpty(ChargeMan))
            //{
            //    conditions.Add("[ChargeMan]=@ChargeMan");
            //    parameters.Add(new SqlParameter("@ChargeMan", ChargeMan));
            //}
            if (ChargeStateList.Count > 0)
            {
                conditions.Add("[ID] in (select [PrintID] from [RoomFeeHistory] where [ChargeState] in (" + string.Join(",", ChargeStateList.ToArray()) + "))");
            }
            string cmdtext = "select sum(WeiShuMore)-sum(WeiShuConsume) from [PrintRoomFeeHistory] where " + string.Join(" and ", conditions.ToArray()) + cmd;
            using (SqlHelper helper = new SqlHelper())
            {
                object obj = helper.ExecuteScalar(cmdtext, CommandType.Text, parameters);
                if (obj != null)
                {
                    decimal.TryParse(obj.ToString(), out total);
                }
            }
            return total;
        }
    }
    public partial class PrintRoomFeeHistoryDetail : EntityBaseReadOnly
    {
        protected override void EnsureParentProperties()
        {
        }
        [DatabaseColumn("ID")]
        public int ID { get; set; }
        [DatabaseColumn("Cost")]
        public decimal Cost { get; set; }
        [DatabaseColumn("HistoryCost")]
        public decimal HistoryCost { get; set; }
        [DatabaseColumn("RealCost")]
        public decimal RealCost { get; set; }
        [DatabaseColumn("ChargeTime")]
        public DateTime ChargeTime { get; set; }
        public static PrintRoomFeeHistoryDetail[] GetPrintRoomFeeHistoryDetailList()
        {
            string cmdtext = @"select * from (select ID, Cost,(select sum(isnull(RealCost,0)) from RoomFeeHistory where PrintID=PrintRoomFeeHistory.ID) as HistoryCost,RealCost,ChargeTime from PrintRoomFeeHistory where WeiShuMore>0 or WeiShuConsume>0)A";
            return GetList<PrintRoomFeeHistoryDetail>(cmdtext, new List<SqlParameter>()).ToArray();
        }
    }
}
