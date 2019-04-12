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
	/// This object represents the properties and methods of a ContractFeeHistory.
	/// </summary>
	public partial class ContractFeeHistory : EntityBase
	{
        public static int InsertContractFeeHistoryByRoomID(int ContractFeeID, string AddMan, SqlHelper helper)
        {
            return InsertContractFeeHistoryByRoomID(ContractFeeID, AddMan, 1, helper);
        }
        public static int InsertContractFeeHistoryByRoomID(int ContractFeeID, string AddMan, int ChargeState, SqlHelper helper)
        {
            string commandText = @"INSERT INTO [dbo].[ContractFeeHistory]
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
           ,[ChargeTime]
           ,[ChargeMan]
           ,[ChargeState]
           ,ReturnGuaranteeFee)
   select *,GETDATE(),'" + AddMan + "'," + ChargeState + ",0 from [ContractFee] where ID=@ID;SELECT @@IDENTITY";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@ID", ContractFeeID));
            int ID = Convert.ToInt32(helper.ExecuteScalar(commandText, CommandType.Text, parameters));
            return ID;
        }
	}
}
