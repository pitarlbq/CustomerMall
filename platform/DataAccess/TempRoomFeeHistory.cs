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
    /// This object represents the properties and methods of a TempRoomFeeHistory.
    /// </summary>
    public partial class TempRoomFeeHistory : EntityBase
    {
        public static int InsertTempRoomFeeHistoryByTempFeeID(int RoomFeeID, string AddMan, SqlHelper helper)
        {
            string commandText = string.Empty;
            //commandText += "delete from [TempRoomFeeHistory] where [TempID]=@ID;";
            commandText += @"INSERT INTO [dbo].[TempRoomFeeHistory]
           ([TempID]
           ,[ID]
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
           ,[ReturnGuaranteeFee])
   select [TempID]
           ,[ID]
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
           ,GETDATE(),'" + AddMan + "',1,0 from [TempRoomFee] where TempID=@ID;SELECT @@IDENTITY";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@ID", RoomFeeID));
            int ID = Convert.ToInt32(helper.ExecuteScalar(commandText, CommandType.Text, parameters));
            return ID;
        }
        public static TempRoomFeeHistory[] GetTempRoomFeeHistoryListByIDs(List<int> IDs)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();

            if (IDs.Count > 0)
            {
                conditions.Add("[TempHistoryID] in (" + string.Join(",", IDs.ToArray()) + ")");
            }
            TempRoomFeeHistory[] list = new TempRoomFeeHistory[] { };
            list = GetList<TempRoomFeeHistory>("select * from [TempRoomFeeHistory] where  " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
            return list;
        }
        public static TempRoomFeeHistory[] GetTempRoomFeeHistorysByPrintID(int PrintID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (PrintID > 0)
            {
                conditions.Add("[PrintID]=@PrintID");
                parameters.Add(new SqlParameter("@PrintID", PrintID));
            }
            return GetList<TempRoomFeeHistory>("select * from [TempRoomFeeHistory] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();

        }
    }
}
