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
    /// This object represents the properties and methods of a TempRoomFee.
    /// </summary>
    public partial class TempRoomFee : EntityBase
    {
        public static int InsertTempRoomFeeByRoomFeeID(int RoomFeeID, SqlHelper helper)
        {
            string commandText = string.Empty;
            //commandText += "delete from [TempRoomFee] where [ID]=@ID;";
            commandText += @"INSERT INTO [dbo].[TempRoomFee]
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
            ,[ChargeMeterProjectFeeID])
            Select [ID]
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
            from [RoomFee] where ID=@ID;SELECT @@IDENTITY";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@ID", RoomFeeID));
            int ID = Convert.ToInt32(@helper.ExecuteScalar(commandText, CommandType.Text, parameters));
            return ID;
        }
    }
}
