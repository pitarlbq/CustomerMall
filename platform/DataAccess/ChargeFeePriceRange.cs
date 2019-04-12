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
    /// This object represents the properties and methods of a ChargeFeePriceRange.
    /// </summary>
    public partial class ChargeFeePriceRange : EntityBase
    {
        public static void CreateChargeFeePriceRangeByImportFeeIDList(SqlHelper helper, List<int> ImportFeeIDList = null, List<int> RoomFeeIDList = null, int RoomFeeID = 0, int HistoryRoomFeeID = 0)
        {
            string cmdtext = string.Empty;
            var parameters = new List<SqlParameter>();
            if (HistoryRoomFeeID > 0 && RoomFeeID > 0)
            {
                RoomFeeHistory.UpdateRoomFeeHistoryID(helper, RoomFeeID: RoomFeeID, HistoryRoomFeeID: HistoryRoomFeeID);
                cmdtext = "update [ChargeFeePriceRange] set [RoomFeeID]=@RoomFeeID where [RoomFeeID]=@HistoryRoomFeeID;";
                cmdtext += "update [RoomFeeHistory] set [ID]=@RoomFeeID where [ID]=@HistoryRoomFeeID;";
                parameters.Add(new SqlParameter("@RoomFeeID", RoomFeeID));
                parameters.Add(new SqlParameter("@HistoryRoomFeeID", HistoryRoomFeeID));
                helper.Execute(cmdtext, CommandType.Text, parameters);
                return;
            }
            if (ImportFeeIDList == null && RoomFeeIDList == null && RoomFeeID == 0)
            {
                return;
            }
            List<string> conditions = new List<string>();
            conditions.Add("RoomFee.ID not in (select RoomFeeID from [ChargeFeePriceRange])");
            conditions.Add("[RoomFee].ChargeID in (select SummaryID from [ChargePriceRange])");
            if (ImportFeeIDList != null && ImportFeeIDList.Count > 0)
            {
                conditions.Add("[RoomFee].[ImportFeeID] in (" + string.Join(",", ImportFeeIDList.ToArray()) + ")");
            }
            if (RoomFeeIDList != null && RoomFeeIDList.Count > 0)
            {
                conditions.Add("[RoomFee].[ID] in (" + string.Join(",", RoomFeeIDList.ToArray()) + ")");
            }
            if (RoomFeeID > 0)
            {
                conditions.Add("[RoomFee].ID=@RoomFeeID");
                parameters.Add(new SqlParameter("@RoomFeeID", RoomFeeID));
            }
            cmdtext = @"insert into [ChargeFeePriceRange]
           ([RoomFeeID]
           ,[ChargePriceRangeID]
           ,[SummaryID]
           ,[MinValue]
           ,[MaxValue]
           ,[BasePrice]
           ,[BaseType]
           ,[IsActive]
           ,[AddTime])
            select [RoomFee].ID as RoomFeeID,
            [ChargePriceRange].ID as ChargePriceRangeID,
            [ChargePriceRange].SummaryID,
            [ChargePriceRange].MinValue,[ChargePriceRange].MaxValue,
            [ChargePriceRange].BasePrice,
            [ChargePriceRange].BaseType,
            [ChargePriceRange].IsActive,
            getdate()
            from [RoomFee]
            left join [ChargePriceRange] on SummaryID=RoomFee.ChargeID
            where " + string.Join(" and ", conditions.ToArray());
            helper.Execute(cmdtext, CommandType.Text, parameters);
        }
        public static ChargeFeePriceRange[] GetAllActiveChargeFeePriceRangeList()
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            ChargeFeePriceRange[] list = GetList<ChargeFeePriceRange>("select * from [ChargeFeePriceRange] where [RoomFeeID] in (select ID from RoomFee) and [IsActive]=1 order by Convert(decimal(18,2), [MinValue]) asc", parameters).ToArray();
            return list;
        }
        public static List<Utility.ChargeFeePriceRangeModel> GetAllActiveChargeFeePriceRangeObjectList()
        {
            var PriceFeeRangeList = ChargeFeePriceRange.GetAllActiveChargeFeePriceRangeList();
            var rangelist = PriceFeeRangeList.Select(p =>
            {
                decimal MinValue = 0;
                decimal.TryParse(p.MinValue, out MinValue);
                decimal MaxValue = 0;
                decimal.TryParse(p.MaxValue, out MaxValue);
                var data = new Utility.ChargeFeePriceRangeModel
                {
                    RoomFeeID = p.RoomFeeID,
                    SummaryID = p.SummaryID,
                    MinValue = MinValue,
                    MaxValue = MaxValue,
                    BasePrice = p.BasePrice,
                    BaseType = p.BaseType,
                    IsActive = p.IsActive
                };
                return data;
            }).ToList();
            return rangelist;
        }
    }
}
