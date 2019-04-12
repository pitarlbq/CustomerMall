using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;

using Foresight.DataAccess.Framework;
using DataAccess;

namespace Foresight.DataAccess
{
    /// <summary>
    /// This object represents the properties and methods of a RoomFeeHistory.
    /// </summary>
    public partial class RoomFeeHistory : EntityBase
    {
        public static void UpdateRoomFeeHistoryID(SqlHelper helper, int RoomFeeID = 0, int HistoryRoomFeeID = 0)
        {
            string cmdtext = string.Empty;
            var parameters = new List<SqlParameter>();
            if (HistoryRoomFeeID > 0 && RoomFeeID > 0)
            {
                cmdtext = "update [RoomFeeHistory] set [ID]=@RoomFeeID where [ID]=@HistoryRoomFeeID;";
                parameters.Add(new SqlParameter("@RoomFeeID", RoomFeeID));
                parameters.Add(new SqlParameter("@HistoryRoomFeeID", HistoryRoomFeeID));
                helper.Execute(cmdtext, CommandType.Text, parameters);
            }
        }
        public static RoomFeeHistory[] GetRoomFeeHistoryByFeeIDList(List<int> FeeIDList, SqlHelper helper = null)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (FeeIDList.Count == 0)
            {
                return new RoomFeeHistory[] { };
            }
            conditions.Add("[ID] in (" + string.Join(",", FeeIDList.ToArray()) + ")");
            string commandText = "select * from [RoomFeeHistory] where " + string.Join(" and ", conditions.ToArray());
            if (helper != null)
            {
                using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
                {
                    return InitializeList<RoomFeeHistory>(reader).ToArray();
                }
            }
            return GetList<RoomFeeHistory>(commandText, parameters).ToArray();
        }
        public static RoomFeeHistory[] GetRoomFeeHistoryListByTradeNo(string TradeNo, int OrderID = 0)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            if (string.IsNullOrEmpty(TradeNo) && OrderID <= 0)
            {
                return new RoomFeeHistory[] { };
            }
            conditions.Add("[ChargeState] in (1,4)");
            List<string> sub_conditions = new List<string>();
            if (OrderID > 0)
            {
                sub_conditions.Add("[OrderID]=@OrderID");
                parameters.Add(new SqlParameter("@OrderID", OrderID));
            }
            sub_conditions.Add("[ID] in (select [RoomFeeID] from [Payment_Request] where [PaymentID] in (select [ID] from [Payment] where [TradeNo]=@TradeNo))");
            conditions.Add("(" + string.Join(" or ", sub_conditions.ToArray()) + ")");
            parameters.Add(new SqlParameter("@TradeNo", TradeNo));
            return GetList<RoomFeeHistory>("select * from [RoomFeeHistory] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
        public static int GetRoomFeeHistoryCountByTradeNo(string TradeNo, int OrderID = 0)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            if (string.IsNullOrEmpty(TradeNo) && OrderID <= 0)
            {
                return 0;
            }
            conditions.Add("[ChargeState] in (1,4)");
            List<string> sub_conditions = new List<string>();
            if (OrderID > 0)
            {
                sub_conditions.Add("[OrderID]=@OrderID");
                parameters.Add(new SqlParameter("@OrderID", OrderID));
            }
            sub_conditions.Add("[ID] in (select [RoomFeeID] from [Payment_Request] where [PaymentID] in (select [ID] from [Payment] where [TradeNo]=@TradeNo))");
            conditions.Add("(" + string.Join(" or ", sub_conditions.ToArray()) + ")");
            parameters.Add(new SqlParameter("@TradeNo", TradeNo));
            int total = 0;
            using (SqlHelper helper = new SqlHelper())
            {
                var result = helper.ExecuteScalar("select count(1) from [RoomFeeHistory] where " + string.Join(" and ", conditions.ToArray()), CommandType.Text, parameters);
                if (result != null)
                {
                    int.TryParse(result.ToString(), out total);
                }
            }
            return total;
        }
        public static RoomFeeHistory[] GetCuiShouRoomFeeHistorys(DateTime StartTime, DateTime EndTime)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("isnull([IsCuiShou],0)=1");
            if (StartTime > DateTime.MinValue)
            {
                conditions.Add("[ChargeTime]>=@StartTime");
                parameters.Add(new SqlParameter("@StartTime", StartTime));
            }
            if (EndTime > DateTime.MinValue)
            {
                conditions.Add("[ChargeTime]<=@EndTime");
                parameters.Add(new SqlParameter("@EndTime", EndTime));
            }
            return GetList<RoomFeeHistory>("select * from [RoomFeeHistory] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
        public static RoomFeeHistory GetPreRoomFeeHistory(int RoomFeeID, DateTime StartTime, SqlHelper helper, out RoomFeeHistory nextRoomFeeHistory)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            string cmdwhere1 = string.Empty;
            string cmdwhere2 = string.Empty;
            conditions.Add("[ID]=@RoomFeeID");
            conditions.Add("[IsCuiShou]=1");
            conditions.Add("[ChargeState]=5");
            if (StartTime > DateTime.MinValue)
            {
                cmdwhere1 = " and [StartTime]<@StartTime";
                cmdwhere2 = " and [StartTime]>@StartTime";
                parameters.Add(new SqlParameter("@StartTime", StartTime));
            }
            parameters.Add(new SqlParameter("@RoomFeeID", RoomFeeID));
            nextRoomFeeHistory = GetOne<RoomFeeHistory>("select top 1 * from [RoomFeeHistory] where " + string.Join(" and ", conditions.ToArray()) + cmdwhere2 + " order by [StartTime] asc", parameters, helper);
            return GetOne<RoomFeeHistory>("select top 1 * from [RoomFeeHistory] where " + string.Join(" and ", conditions.ToArray()) + cmdwhere1 + " order by [StartTime] desc", parameters, helper);
        }
        public static RoomFeeHistory[] GetRoomFeeHistoryListByRoomIDListAndChargeState(List<int> RoomIDList, List<int> ChargeState)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            if (ChargeState.Count > 0)
            {
                conditions.Add("[ChargeState] in (" + string.Join(",", ChargeState.ToArray()) + ")");
            }
            if (RoomIDList.Count > 0)
            {
                conditions.Add("[RoomID] in (" + string.Join(",", RoomIDList.ToArray()) + ")");
            }
            return GetList<RoomFeeHistory>("select * from [RoomFeeHistory] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
        public static RoomFeeHistory[] GetRoomFeeHistoryListByRoomIDList(List<int> RoomIDList, int ChargeID = 0, List<int> ChargeFeeID = null, List<int> ProjectIDList = null, int UserID = 0, int ChargeFeeType = 0, bool OnlyChargeFee = false)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            if (OnlyChargeFee)
            {
                conditions.Add("ChargeState in (1,4)");
            }
            if (ChargeFeeType > 0)
            {
                conditions.Add("[ChargeID] in (select [ID] from [ChargeSummary] where [ChargeFeeType]=@ChargeFeeType)");
                parameters.Add(new SqlParameter("@ChargeFeeType", ChargeFeeType));
            }
            if (ChargeID > 0)
            {
                conditions.Add("[ChargeID]=@ChargeID");
                parameters.Add(new SqlParameter("@ChargeID", ChargeID));
            }
            if (ChargeFeeID != null && ChargeFeeID.Count > 0)
            {
                conditions.Add("[ChargeFeeID] in (" + string.Join(",", ChargeFeeID.ToArray()) + ")");
            }
            if (RoomIDList.Count > 0)
            {
                List<string> cmdlist = ViewRoomFeeHistory.GetRoomIDListConditions(RoomIDList, RoomIDName: "[RoomID]");
                conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
            }
            if (ProjectIDList != null && ProjectIDList.Count > 0)
            {
                List<string> cmdlist = ViewRoomFeeHistory.GetProjectIDListConditions(ProjectIDList, IsContractFee: true, UserID: UserID);
                conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
            }
            return GetList<RoomFeeHistory>("select * from [RoomFeeHistory] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
        public static RoomFeeHistory[] GetRoomFeeHistoryByChargeID(int ChargeID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (ChargeID > 0)
            {
                conditions.Add("[ChargeID]=@ChargeID");
                parameters.Add(new SqlParameter("@ChargeID", ChargeID));
            }
            return GetList<RoomFeeHistory>("select * from [RoomFeeHistory] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
        public static RoomFeeHistory[] GetRoomFeeHistoryByChargeFeeID(int ChargeFeeID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (ChargeFeeID > 0)
            {
                conditions.Add("[ChargeFeeID]=@ChargeFeeID");
                parameters.Add(new SqlParameter("@ChargeFeeID", ChargeFeeID));
            }
            return GetList<RoomFeeHistory>("select * from [RoomFeeHistory] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
        public static RoomFeeHistory[] GetRoomFeeHistoryByRoomFeeID(int roomFeeID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (roomFeeID > 0)
            {
                conditions.Add("[ID]=@roomFeeID");
                parameters.Add(new SqlParameter("@roomFeeID", roomFeeID));
            }
            return GetList<RoomFeeHistory>("select * from [RoomFeeHistory] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();

        }
        public static RoomFeeHistory[] GetRoomFeeHistorysByHistoryIDs(List<int> IDList)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[HistoryID] in (" + string.Join(",", IDList.ToArray()) + ")");
            return GetList<RoomFeeHistory>("select * from [RoomFeeHistory] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
        public static RoomFeeHistory[] GetRoomFeeHistoryByID(int ID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (ID > 0)
            {
                conditions.Add("[ID]=@ID");
                parameters.Add(new SqlParameter("@ID", ID));
            }
            return GetList<RoomFeeHistory>("select * from [RoomFeeHistory] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
        public static RoomFeeHistory[] GetRoomFeeHistoryByParentID(int ParentRoomFeeID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (ParentRoomFeeID > 0)
            {
                conditions.Add("[ParentRoomFeeID]=@ParentRoomFeeID");
                parameters.Add(new SqlParameter("@ParentRoomFeeID", ParentRoomFeeID));
            }
            return GetList<RoomFeeHistory>("select * from [RoomFeeHistory] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();

        }
        public static RoomFeeHistory[] GetRoomFeeHistoryByPrintID(int PrintID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (PrintID <= 0)
            {
                return new RoomFeeHistory[] { };
            }
            conditions.Add("[PrintID]=@PrintID");
            parameters.Add(new SqlParameter("@PrintID", PrintID));
            return GetList<RoomFeeHistory>("select * from [RoomFeeHistory] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
        public static RoomFeeHistory[] GetRoomFeeHistoryListByPrintIDList(List<int> PrintIDList)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            if (PrintIDList.Count == 0)
            {
                return new RoomFeeHistory[] { };
            }
            conditions.Add("[PrintID] in (" + string.Join(",", PrintIDList.ToArray()) + ")");
            return GetList<RoomFeeHistory>("select * from [RoomFeeHistory] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
        public static int InsertRoomFeeHistoryByRoomID(int RoomFeeID, string AddMan, SqlHelper helper, string OpenID = "")
        {
            return InsertRoomFeeHistoryByRoomID(RoomFeeID, AddMan, 1, helper, OpenID);
        }
        public static int InsertRoomFeeHistoryByRoomID(int RoomFeeID, string AddMan, int ChargeState, SqlHelper helper, string OpenID = "")
        {
            OpenID = string.IsNullOrEmpty(OpenID) ? "NULL" : "'" + OpenID + "'";
            AddMan = string.IsNullOrEmpty(AddMan) ? "NULL" : "'" + AddMan + "'";
            string AddUserName = "'" + User.GetCurrentUserName() + "'";
            string commandText = @"INSERT INTO [dbo].[RoomFeeHistory]
           ([ID]
           ,[RoomID]
           ,[UseCount]
           ,[StartTime]
           ,[EndTime]
           ,[Cost]
           ,[Remark]
           ,[AddTime]
           ,[IsCharged]
           ,[ChargeFeeID]
           ,[ChargeID]
           ,[IsStart]
           ,[NewStartTime]
           ,[ImportFeeID]
           ,[UnitPrice]
           ,[RealCost]
           ,[Discount]
           ,[OutDays]
           ,[ChargeFee]
           ,[TotalRealCost]
           ,[RestCost]
           ,[TotalDiscountCost]
           ,[OnlyOnceCharge]
           ,[NewEndTime]
           ,[ContractID]
           ,[DiscountID]
           ,[CuiShouStartTime]
           ,[CuiShouEndTime]
           ,[RelatedFeeID]
           ,[ChongDiChargeID]
           ,[DefaultChargeManID]
           ,[DefaultChargeManName]
           ,[Contract_RoomChargeID]
           ,[TradeNo]
           ,[ContractDivideID]
           ,[OrderID]
           ,[IsTempFee]
           ,[IsMeterFee]
           ,[IsImportFee]
           ,[IsCycleFee]
           ,[RoomFeeCoefficient]
           ,[RoomFeeWriteDate]
           ,[RoomFeeStartPoint]
           ,[RoomFeeEndPoint]
           ,[ChargeMeterProjectFeeID]
           ,[ChargeTime]
           ,[ChargeMan]
           ,[ChargeState]
           ,[ReturnGuaranteeFee]
           ,[OpenID]
           ,[AddUserName])
           select [ID]
           ,[RoomID]
           ,[UseCount]
           ,[StartTime]
           ,[EndTime]
           ,[Cost]
           ,[Remark]
           ,getdate()
           ,[IsCharged]
           ,[ChargeFeeID]
           ,[ChargeID]
           ,[IsStart]
           ,[NewStartTime]
           ,[ImportFeeID]
           ,[UnitPrice]
           ,[RealCost]
           ,[Discount]
           ,[OutDays]
           ,[ChargeFee]
           ,[TotalRealCost]
           ,[RestCost]
           ,[TotalDiscountCost]
           ,[OnlyOnceCharge]
           ,[NewEndTime]
           ,[ContractID]
           ,[DiscountID]
           ,[CuiShouStartTime]
           ,[CuiShouEndTime]
           ,[RelatedFeeID]
           ,[ChongDiChargeID]
           ,[DefaultChargeManID]
           ,[DefaultChargeManName]
           ,[Contract_RoomChargeID]
           ,[TradeNo]
           ,[ContractDivideID]
           ,[OrderID]
           ,[IsTempFee]
           ,[IsMeterFee]
           ,[IsImportFee]
           ,[IsCycleFee]
           ,[RoomFeeCoefficient]
           ,[RoomFeeWriteDate]
           ,[RoomFeeStartPoint]
           ,[RoomFeeEndPoint]
           ,[ChargeMeterProjectFeeID]
           ,GETDATE()," + AddMan + "," + ChargeState + ",0," + OpenID + "," + AddUserName + " from [RoomFee] where ID=@ID;SELECT @@IDENTITY";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@ID", RoomFeeID));
            int ID = Convert.ToInt32(helper.ExecuteScalar(commandText, CommandType.Text, parameters));
            return ID;
        }
        public static int InsertRoomFeeHistoryByTempHistoryID(int TempHistoryID, string AddMan, int ChargeState, SqlHelper helper, string OpenID = "")
        {
            OpenID = string.IsNullOrEmpty(OpenID) ? "NULL" : "'" + OpenID + "'";
            AddMan = string.IsNullOrEmpty(AddMan) ? "NULL" : "'" + AddMan + "'";
            string AddUserName = "'" + User.GetCurrentUserName() + "'";
            string commandText = @"INSERT INTO [dbo].[RoomFeeHistory]
           ([ID]
           ,[RoomID]
           ,[UseCount]
           ,[StartTime]
           ,[EndTime]
           ,[Cost]
           ,[Remark]
           ,[AddTime]
           ,[IsCharged]
           ,[ChargeFeeID]
           ,[ChargeID]
           ,[IsStart]
           ,[NewStartTime]
           ,[ImportFeeID]
           ,[UnitPrice]
           ,[RealCost]
           ,[Discount]
           ,[OutDays]
           ,[ChargeFee]
           ,[TotalRealCost]
           ,[RestCost]
           ,[TotalDiscountCost]
           ,[OnlyOnceCharge]
           ,[NewEndTime]
           ,[ContractID]
           ,[DiscountID]
           ,[CuiShouStartTime]
           ,[CuiShouEndTime]
           ,[RelatedFeeID]
           ,[ChongDiChargeID]
           ,[DefaultChargeManID]
           ,[DefaultChargeManName]
           ,[Contract_RoomChargeID]
           ,[TradeNo]
           ,[ContractDivideID]
           ,[OrderID]
           ,[IsTempFee]
           ,[IsMeterFee]
           ,[IsImportFee]
           ,[IsCycleFee]
           ,[RoomFeeCoefficient]
           ,[ChargeTime]
           ,[ChargeMan]
           ,[ChargeState]
           ,[ReturnGuaranteeFee]
           ,[OpenID]
           ,[AddUserName])
           select [ID]
           ,[RoomID]
           ,[UseCount]
           ,[StartTime]
           ,[EndTime]
           ,[Cost]
           ,[Remark]
           ,getdate()
           ,[IsCharged]
           ,[ChargeFeeID]
           ,[ChargeID]
           ,[IsStart]
           ,[NewStartTime]
           ,[ImportFeeID]
           ,[UnitPrice]
           ,[RealCost]
           ,[Discount]
           ,[OutDays]
           ,[ChargeFee]
           ,[TotalRealCost]
           ,[RestCost]
           ,[TotalDiscountCost]
           ,[OnlyOnceCharge]
           ,[NewEndTime]
           ,[ContractID]
           ,[DiscountID]
           ,[CuiShouStartTime]
           ,[CuiShouEndTime]
           ,[RelatedFeeID]
           ,[ChongDiChargeID]
           ,[DefaultChargeManID]
           ,[DefaultChargeManName]
           ,[Contract_RoomChargeID]
           ,[TradeNo]
           ,[ContractDivideID]
           ,[OrderID]
           ,[IsTempFee]
           ,[IsMeterFee]
           ,[IsImportFee]
           ,[IsCycleFee]
           ,[RoomFeeCoefficient]
           ,GETDATE()," + AddMan + "," + ChargeState + ",0," + OpenID + "," + AddUserName + " from [TempRoomFeeHistory] where TempHistoryID=@ID;SELECT @@IDENTITY";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@ID", TempHistoryID));
            int ID = Convert.ToInt32(helper.ExecuteScalar(commandText, CommandType.Text, parameters));
            return ID;
        }
        public static decimal GetTotalRealCost(int FeeID, int RoomID, int ChargeID, SqlHelper helper)
        {
            decimal TotalRealCost = 0;
            if (FeeID == 0)
            {
                return TotalRealCost;
            }
            var parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("ChargeState in (1,4)");
            conditions.Add("[ID]=@FeeID");
            conditions.Add("[RoomID]=@RoomID");
            conditions.Add("[ChargeID]=@ChargeID");
            parameters.Add(new SqlParameter("@FeeID", FeeID));
            parameters.Add(new SqlParameter("@RoomID", RoomID));
            parameters.Add(new SqlParameter("@ChargeID", ChargeID));
            string cmdtext = @"select sum(isnull(RealCost,0)) from [RoomFeeHistory] where " + string.Join(" and ", conditions.ToArray());
            var Total = helper.ExecuteScalar(cmdtext, CommandType.Text, parameters);
            if (Total != null)
            {
                decimal.TryParse(Total.ToString(), out TotalRealCost);
            }
            return TotalRealCost;
        }
        public static RoomFeeHistory GetRoomFeeHistoryByContract_RoomChargeID(int ContractID, int Contract_RoomChargeID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[ChargeState] in (1,4)");
            conditions.Add("[ContractID]=@ContractID");
            conditions.Add("[Contract_RoomChargeID]=@Contract_RoomChargeID");
            parameters.Add(new SqlParameter("@ContractID", ContractID));
            parameters.Add(new SqlParameter("@Contract_RoomChargeID", Contract_RoomChargeID));
            return GetOne<RoomFeeHistory>("select top 1 * from [RoomFeeHistory] where " + string.Join(" and ", conditions.ToArray()), parameters);
        }
        public static RoomFeeHistory[] GetRoomFeeHistoryListByContractDivideIDList(List<int> DivideIDList)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[ChargeState] in (1,4)");
            if (DivideIDList.Count == 0)
            {
                return new RoomFeeHistory[] { };
            }
            conditions.Add("isnull(ContractDivideID,0) in (" + string.Join(",", DivideIDList.ToArray()) + ")");
            string Statement = " select * from [RoomFeeHistory] where  " + string.Join(" and ", conditions.ToArray());
            RoomFeeHistory[] list = new RoomFeeHistory[] { };
            list = GetList<RoomFeeHistory>(Statement, parameters).ToArray();
            return list;
        }
        public static RoomFeeHistory[] GetInCorrectRoomFeeHistoryList()
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            string Statement = "select * from RoomFeeHistory where ID in (Select ID from RoomFee) and ChargeState=1 order by (Select DefaultOrder from Project where ID=RoomFeeHistory.RoomID) asc";
            RoomFeeHistory[] list = new RoomFeeHistory[] { };
            list = GetList<RoomFeeHistory>(Statement, parameters).ToArray();
            return list;
        }
        public static RoomFeeHistory[] GetRoomFeeHistoryListByContractID(int ContractID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[ChargeState] in (1,4)");
            conditions.Add("[ContractID]=@ContractID");
            parameters.Add(new SqlParameter("@ContractID", ContractID));
            return GetList<RoomFeeHistory>("select * from [RoomFeeHistory] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
        public static bool CheckCuiShouRoomFeeHistoryByID(int ID, SqlHelper helper)
        {
            int count = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            conditions.Add("[ID]=@ID");
            parameters.Add(new SqlParameter("@ID", ID));
            conditions.Add("[ChargeState]=5");
            var result = helper.ExecuteScalar("select count(1) from [RoomFeeHistory] where " + string.Join(" and ", conditions.ToArray()), CommandType.Text, parameters);
            if (result != null)
            {
                int.TryParse(result.ToString(), out count);
            }
            return count > 0;
        }
        public static RoomFeeHistory[] GetCuiShouRoomFeeHistoryListByImportFeeID(int[] IDList)
        {
            if (IDList.Length == 0)
            {
                return new RoomFeeHistory[] { };
            }
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            conditions.Add("[ImportFeeID] in (" + string.Join(",", IDList) + ")");
            conditions.Add("[ChargeState]=5");
            return GetList<RoomFeeHistory>("select * from [RoomFeeHistory] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
        public static RoomFeeHistory GetRoomFeeHistoryByImportFeeID(int ImportFeeID, SqlHelper helper)
        {
            if (ImportFeeID <= 0)
            {
                return null;
            }
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("isnull([ImportFeeID],0)=@ImportFeeID");
            parameters.Add(new SqlParameter("@ImportFeeID", ImportFeeID));
            return GetOne<RoomFeeHistory>("select top 1 * from [RoomFeeHistory] where " + string.Join(" and ", conditions.ToArray()), parameters, helper);
        }
        public static RoomFeeHistory GetRoomFeeHistoryByPrintNumber(string PrintNumber)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (string.IsNullOrEmpty(PrintNumber))
            {
                return null;
            }
            conditions.Add("[PrintID] in (select ID from [PrintRoomFeeHistory] where [PrintNumber]=@PrintNumber)");
            conditions.Add("[ChargeID] not in (select ID from [ChargeSummary])");
            parameters.Add(new SqlParameter("@PrintNumber", PrintNumber));
            return GetOne<RoomFeeHistory>("select * from [RoomFeeHistory] where " + string.Join(" and ", conditions.ToArray()), parameters);
        }
        public static int GetRoomFeeHistoryListCountByChargeIDList(List<int> ChargeIDList = null, List<int> DiscountIDList = null)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            if (ChargeIDList != null && ChargeIDList.Count > 0)
            {
                conditions.Add("[ChargeID] in (" + string.Join(",", ChargeIDList.ToArray()) + ")");
            }
            if (DiscountIDList != null && DiscountIDList.Count > 0)
            {
                conditions.Add("[DiscountID] in (" + string.Join(",", DiscountIDList.ToArray()) + ")");
            }
            if (conditions.Count == 0)
            {
                return 0;
            }
            int total = 0;
            using (SqlHelper helper = new SqlHelper())
            {
                var result = helper.ExecuteScalar("select count(1) from [RoomFeeHistory] where " + string.Join(" and ", conditions.ToArray()), CommandType.Text, parameters);
                if (result != null)
                {
                    int.TryParse(result.ToString(), out total);
                }
                return total;
            }
        }
        public static int GetPrintRoomFeeHistoryListCountByChargeTypeIDList(List<int> ChargeTypeIDList)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            if (ChargeTypeIDList.Count <= 0)
            {
                return 0;
            }
            conditions.Add("[ChageType1] in (" + string.Join(",", ChargeTypeIDList.ToArray()) + ") or [ChageType2] in (" + string.Join(",", ChargeTypeIDList.ToArray()) + ")");
            int total = 0;
            using (SqlHelper helper = new SqlHelper())
            {
                var result = helper.ExecuteScalar("select count(1) from [PrintRoomFeeHistory] where " + string.Join(" and ", conditions.ToArray()), CommandType.Text, parameters);
                if (result != null)
                {
                    int.TryParse(result.ToString(), out total);
                }
                return total;
            }
        }
        public static RoomFeeHistory[] GetRoomFeeHistorysByHistoryImportFeeIDList(List<int> IDList)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[ImportFeeID] in (" + string.Join(",", IDList.ToArray()) + ")");
            return GetList<RoomFeeHistory>("select ID,[ImportFeeID],ChargeState from [RoomFeeHistory] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
    }
}
