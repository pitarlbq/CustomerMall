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
    /// This object represents the properties and methods of a RoomFee.
    /// </summary>
    public partial class RoomFee : EntityBase
    {
        public static int GetRoomFeeListCountByChargeIDList(List<int> ChargeIDList)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            if (ChargeIDList.Count <= 0)
            {
                return 0;
            }
            conditions.Add("[ChargeID] in (" + string.Join(",", ChargeIDList.ToArray()) + ")");
            int total = 0;
            using (SqlHelper helper = new SqlHelper())
            {
                var result = helper.ExecuteScalar("select count(1) from [RoomFee] where " + string.Join(" and ", conditions.ToArray()), CommandType.Text, parameters);
                if (result != null)
                {
                    int.TryParse(result.ToString(), out total);
                }
                return total;
            }
        }
        public static RoomFee[] GetRoomFeeListByParams(List<int> ProjectIDList, List<int> RoomIDList, List<int> ChargeIDList, int UserID = 0)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (ChargeIDList.Count > 0)
            {
                conditions.Add("[ChargeID] in (" + string.Join(",", ChargeIDList.ToArray()) + ")");
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
            return GetList<RoomFee>("select * from [RoomFee] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
        public static bool InsertRoomFee(List<int> ProjectIDList, List<int> RoomIDList, ViewChargeSummary summary, string StartTime, string EndTime, int IsCycleFee = 0)
        {
            return InsertRoomFee(ProjectIDList, RoomIDList, StartTime, EndTime, 0, summary.SummaryUnitPrice, string.Empty, summary, string.Empty, includenopeople: true, IsCycleFee: IsCycleFee);
        }
        public static bool CheckRoomOwnerStatus(List<int> ProjectIDList, List<int> RoomIDList)
        {
            if (!new Utility.SiteConfig().CheckOwnerInStatus)
            {
                return true;
            }
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[isParent]=0");
            conditions.Add("isnull([IsLocked],0)=0");
            List<string> cmdlist = new List<string>();
            cmdlist.Add("[RoomID] in (select [RoomID] from [RoomPhoneRelation])");
            cmdlist.Add("[RoomID] in (select [RoomID] from [RoomRelation] where [GUID] in (select [GUID] from [RoomRelation] where [RoomID] in (select [RoomID] from [RoomPhoneRelation])))");
            conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
            if (ProjectIDList.Count > 0)
            {
                cmdlist = new List<string>();
                foreach (var ProjectID in ProjectIDList)
                {
                    cmdlist.Add("[AllParentID] like '%," + ProjectID + ",%'");
                }
                conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
            }
            if (RoomIDList.Count > 0)
            {
                conditions.Add("([RoomID] in (" + string.Join(",", RoomIDList.ToArray()) + "))");
            }
            int total = 0;
            using (SqlHelper helper = new SqlHelper())
            {
                var result = helper.ExecuteScalar("select count(1) from [ViewRoomBasic] where " + string.Join(" and ", conditions.ToArray()), CommandType.Text, parameters);
                if (result != null)
                {
                    int.TryParse(result.ToString(), out total);
                }
            }
            return total > 0;
        }

        public static bool InsertRoomFee(List<int> ProjectIDList, List<int> RoomIDList, string StartTime, string EndTime, int ContractID, decimal UnitPrice, string Remark, ViewChargeSummary summary, string NewEndTime, decimal TotalCost = 0, decimal UseCount = 0, int Contract_RoomChargeID = 0, bool includenopeople = true, int IsCycleFee = 0)
        {
            string sqltext = string.Empty;
            List<SqlParameter> parameters = new List<SqlParameter>();
            if (string.IsNullOrEmpty(StartTime))
            {
                StartTime = summary.SummaryStartTime == DateTime.MinValue ? "NULL" : "'" + summary.SummaryStartTime.ToString("yyyy-MM-dd") + "'";
            }
            else
            {
                StartTime = "'" + StartTime + "'";
            }
            if (string.IsNullOrEmpty(EndTime))
            {
                EndTime = "NULL";
            }
            else
            {
                EndTime = "'" + EndTime + "'";
            }
            if (string.IsNullOrEmpty(NewEndTime))
            {
                NewEndTime = "NULL";
            }
            else
            {
                NewEndTime = "'" + NewEndTime + "'";
            }
            TotalCost = TotalCost > 0 ? TotalCost : 0;
            UseCount = UseCount > 0 ? UseCount : 0;
            string AddUserName = "'" + User.GetCurrentUserName() + "'";
            if (RoomIDList.Contains(0))
            {
                sqltext += @"INSERT INTO [dbo].[RoomFee]
               ([RoomID]
               ,[UseCount]
               ,[StartTime]
               ,[EndTime]
               ,[NewEndTime]
               ,[Cost]
               ,[Remark]
               ,[AddTime]
               ,[IsCharged]
               ,[ChargeFeeID]
               ,[ChargeID]
               ,[IsStart]
               ,[UnitPrice]
               ,[ChargeFee]
               ,[ContractID]
               ,[Contract_RoomChargeID]
               ,[IsCycleFee]
               ,[AddUserName])
                values(
                0," + UseCount + "," + StartTime + "," + EndTime + "," + NewEndTime + "," + TotalCost + ",'" + Remark + @"',getdate(),0,0," + summary.ID + ",1,'" + UnitPrice + "',0," + ContractID + "," + Contract_RoomChargeID + "," + IsCycleFee + "," + AddUserName + ");";
                RoomIDList.Remove(0);
            }
            List<string> conditions = new List<string>();
            conditions.Add("[isParent]=0");
            conditions.Add("isnull([IsLocked],0)=0");
            if (!includenopeople && new Utility.SiteConfig().CheckOwnerInStatus)
            {
                List<string> cmdlist = new List<string>();
                cmdlist.Add("[ID] in (select [RoomID] from [RoomPhoneRelation])");
                cmdlist.Add("[ID] in (select [RoomID] from [RoomRelation] where [GUID] in (select [GUID] from [RoomRelation] where [RoomID] in (select [RoomID] from [RoomPhoneRelation])))");
                conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
            }
            if (ProjectIDList.Count > 0)
            {
                List<string> cmdlist = new List<string>();
                cmdlist.Add("[ID] in (" + string.Join(",", ProjectIDList.ToArray()) + ")");
                foreach (var ProjectID in ProjectIDList)
                {
                    cmdlist.Add("[AllParentID] like '%," + ProjectID + ",%'");
                }
                conditions.Add("((" + string.Join(" or ", cmdlist.ToArray()) + "))");
            }
            if (RoomIDList.Count > 0)
            {
                conditions.Add("[ID] in (" + string.Join(",", RoomIDList.ToArray()) + ")");
            }
            string cmdcolumn = ",(select [IsLocked] from [RoomBasic] where [RoomID]=[Project].ID) as IsLocked";
            if (ContractID > 0)
            {
                cmdcolumn += ",(select top 1 ID from [RoomPhoneRelation] where [RoomID]=[Project].ID and [ContractID]=@ContractID) as RelationID,(select top 1 RelationName from [RoomPhoneRelation] where [RoomID]=[Project].ID and [ContractID]=@ContractID) as RelationName";
                parameters.Add(new SqlParameter("@ContractID", ContractID));
            }
            else
            {
                cmdcolumn += ",(select top 1 ID from [RoomPhoneRelation] where [RoomID]=[Project].ID and IsDefault = 1) as RelationID,(select top 1 RelationName from [RoomPhoneRelation] where [RoomID]=[Project].ID and IsDefault = 1) as RelationName";
            }
            if (RoomIDList.Count > 0 || ProjectIDList.Count > 0)
            {
                sqltext += @"INSERT INTO [dbo].[RoomFee]
               ([RoomID]
               ,[UseCount]
               ,[StartTime]
               ,[EndTime]
               ,[NewEndTime]
               ,[Cost]
               ,[Remark]
               ,[AddTime]
               ,[IsCharged]
               ,[ChargeFeeID]
               ,[ChargeID]
               ,[IsStart]
               ,[UnitPrice]
               ,[ChargeFee]
               ,[ContractID]
               ,[Contract_RoomChargeID]
               ,[IsCycleFee]
               ,[AddUserName]
               ,[DefaultChargeManID]
               ,[DefaultChargeManName])
                select [ID]," + UseCount + "," + StartTime + "," + EndTime + "," + NewEndTime + "," + TotalCost + ",'" + Remark + @"',getdate(),0,0," + summary.ID + ",1,'" + UnitPrice + "',0," + ContractID + "," + Contract_RoomChargeID + "," + IsCycleFee + "," + AddUserName + ",A.RelationID,A.RelationName from (select [ID],[AllParentID],[isParent]" + cmdcolumn + " from [Project])A where " + string.Join(" and ", conditions.ToArray()) + ";";
            }
            if (!string.IsNullOrEmpty(sqltext))
            {
                using (SqlHelper helper = new SqlHelper())
                {
                    try
                    {
                        helper.BeginTransaction();
                        helper.Execute(sqltext, CommandType.Text, parameters);
                        helper.Commit();
                        return true;
                    }
                    catch (Exception)
                    {
                        helper.Rollback();
                        return false;
                    }
                }
            }
            return false;
        }
        public static string GetActiveImportFeeCmdText(ViewImportFeeDetail2[] list)
        {
            var roomfee_list = RoomFee.GetRoomFeeListByImportFeeIDList(list.Select(p => p.ID).ToList());
            string cmdtext = string.Empty;
            List<int> NewIDList = new List<int>();
            foreach (var importFee in list)
            {
                var roomfee = roomfee_list.FirstOrDefault(p => p.ImportFeeID == importFee.ID);
                decimal UnitPrice = importFee.FinalUnitPrice > 0 ? importFee.FinalUnitPrice : 0;
                decimal TotalPoint = importFee.RealTotalPoint > 0 ? importFee.RealTotalPoint : 0;
                if (importFee.FinalTotalPrice <= 0)
                {
                    continue;
                }
                NewIDList.Add(importFee.ID);
                string StartTime = importFee.StartTime == DateTime.MinValue ? "NULL" : "'" + importFee.StartTime.ToString("yyyy-MM-dd") + "'";
                string EndTime = importFee.EndTime == DateTime.MinValue ? "NULL" : "'" + importFee.EndTime.ToString("yyyy-MM-dd") + "'";
                decimal RoomFeeCoefficient = importFee.Coefficient > 0 ? importFee.Coefficient : 1;
                string RoomFeeWriteDate = importFee.WriteDate == DateTime.MinValue ? "NULL" : "'" + importFee.WriteDate.ToString("yyyy-MM-dd") + "'";
                decimal RoomFeeStartPoint = importFee.StartPoint > 0 ? importFee.StartPoint : 0;
                decimal RoomFeeEndPoint = importFee.EndPoint > 0 ? importFee.EndPoint : 0;
                if (roomfee == null)
                {
                    cmdtext += @"INSERT INTO [dbo].[RoomFee]
                   ([RoomID]
                   ,[UseCount]
                   ,[StartTime]
                   ,[EndTime]
                   ,[Cost]
                   ,[AddTime]
                   ,[IsCharged]
                   ,[ChargeID]
                   ,[IsStart]
                   ,[ImportFeeID]
                   ,[UnitPrice]
                   ,[ChargeFee]
                   ,[ChargeFeeID]
                   ,[IsImportFee]
                   ,[RoomFeeCoefficient]
                   ,[RoomFeeWriteDate]
                   ,[RoomFeeStartPoint]
                   ,[RoomFeeEndPoint]
                   )
                    VALUES
                   (" + importFee.RoomID + "," + TotalPoint + "," + StartTime + "," + EndTime + "," + importFee.TotalPrice + ",getdate(),0," + importFee.ChargeID + ",1," + importFee.ID + "," + UnitPrice + ",0,0,1," + RoomFeeCoefficient + "," + RoomFeeWriteDate + "," + RoomFeeStartPoint + "," + RoomFeeEndPoint + ");";
                }
                else
                {
                    cmdtext += "update RoomFee set [UseCount]=" + TotalPoint + ",[StartTime]="
                    + StartTime + ",[EndTime]=" + EndTime + ",[Cost]=" + importFee.TotalPrice + ",[UnitPrice]=" + UnitPrice + ",[RoomFeeCoefficient]=" + RoomFeeCoefficient + ",[RoomFeeWriteDate]=" + RoomFeeWriteDate + ",[IsImportFee]=1,[RoomFeeStartPoint]=" + RoomFeeStartPoint + ",[RoomFeeEndPoint]=" + RoomFeeEndPoint + " where ID=" + roomfee.ID + ";";
                }
            }
            if (NewIDList.Count > 0)
            {
                cmdtext += "update [ImportFee] set [ChargeStatus]=0 where ID in (" + string.Join(" , ", NewIDList.ToArray()) + ");";
            }
            return cmdtext;
        }
        public static RoomFee[] GetRoomFeeListByRoomIDList(int IsStart, List<int> RoomIDList, int ChargeID, int ChargeFeeType = 0)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (ChargeFeeType > 0)
            {
                conditions.Add("[ChargeID] in (select [ID] from [ChargeSummary] where [ChargeFeeType]=@ChargeFeeType)");
                parameters.Add(new SqlParameter("@ChargeFeeType", ChargeFeeType));
            }
            if (IsStart > -1)
            {
                conditions.Add("[IsStart]=@IsStart");
                parameters.Add(new SqlParameter("@IsStart", IsStart));
            }
            if (ChargeID > 0)
            {
                conditions.Add("[ChargeID]=@ChargeID");
                parameters.Add(new SqlParameter("@ChargeID", ChargeID));
            }
            if (RoomIDList.Count > 0)
            {
                conditions.Add("[RoomID] in (" + string.Join(",", RoomIDList.ToArray()) + ")");
            }
            return GetList<RoomFee>("select * from [RoomFee] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
        public static RoomFee GetRoomFeeByChargeID(int RoomID, int ChargeID)
        {
            using (SqlHelper helper = new SqlHelper())
            {
                return GetRoomFeeByChargeID(RoomID, ChargeID, helper);
            }
        }
        public static RoomFee GetRoomFeeByChargeID(int RoomID, int ChargeID, SqlHelper helper)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[IsStart]=1");
            if (RoomID > 0)
            {
                conditions.Add("[RoomID]=@RoomID");
                parameters.Add(new SqlParameter("@RoomID", RoomID));
            }
            if (ChargeID > 0)
            {
                conditions.Add("[ChargeID]=@ChargeID");
                parameters.Add(new SqlParameter("@ChargeID", ChargeID));
            }
            return GetOne<RoomFee>("select top 1 * from [RoomFee] where " + string.Join(" and ", conditions.ToArray()), parameters, helper);
        }
        public static RoomFee GetRoomFeeByIDs(int RoomID, int ChargeID, SqlHelper helper, int ImportFeeID = 0, DateTime? StartTime = null, DateTime? EndTime = null)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            if (RoomID > 0)
            {
                conditions.Add("[RoomID]=@RoomID");
                parameters.Add(new SqlParameter("@RoomID", RoomID));
            }
            if (ChargeID > 0)
            {
                conditions.Add("[ChargeID]=@ChargeID");
                parameters.Add(new SqlParameter("@ChargeID", ChargeID));
            }
            if (ImportFeeID > 0)
            {
                conditions.Add("[ImportFeeID]=@ImportFeeID");
                parameters.Add(new SqlParameter("@ImportFeeID", ImportFeeID));
            }
            if (StartTime.HasValue && EndTime.HasValue)
            {
                DateTime NewStartTime = Convert.ToDateTime(StartTime);
                DateTime NewEndTime = Convert.ToDateTime(EndTime);
                if (NewStartTime > DateTime.MinValue && NewEndTime > DateTime.MinValue)
                {
                    conditions.Add("([StartTime]=@StartTime or [StartTime]=@EndTime)");
                    parameters.Add(new SqlParameter("@StartTime", NewStartTime));
                    parameters.Add(new SqlParameter("@EndTime", NewEndTime.AddDays(1)));
                }
                else if (NewStartTime == DateTime.MinValue)
                {
                    conditions.Add("([StartTime] is null)");
                }
            }
            if (conditions.Count == 0)
            {
                return null;
            }
            return GetOne<RoomFee>("select top 1 * from [RoomFee] where " + string.Join(" and ", conditions.ToArray()), parameters, helper);
        }
        public static RoomFee[] GetRoomFeeListByRoomID(int RoomID, int ChargeID = 0)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[IsStart]=1");
            if (RoomID > 0)
            {
                conditions.Add("[RoomID]=@RoomID");
                parameters.Add(new SqlParameter("@RoomID", RoomID));
            }
            if (ChargeID > 0)
            {
                conditions.Add("[ChargeID]=@ChargeID");
                parameters.Add(new SqlParameter("@ChargeID", ChargeID));
            }
            return GetList<RoomFee>("select * from [RoomFee] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
        public static RoomFee[] GetRoomFeeListByIDs(List<int> IDs)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[IsStart]=1");
            conditions.Add("[ID] in (" + string.Join(",", IDs.ToArray()) + ")");
            return GetList<RoomFee>("select * from [RoomFee] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
        public static RoomFee GetRoomFeeByImportFeeID(int ImportFeeID, SqlHelper helper)
        {
            if (ImportFeeID <= 0)
            {
                return null;
            }
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            //conditions.Add("[IsStart]=1");
            conditions.Add("isnull([ImportFeeID],0)=@ImportFeeID");
            parameters.Add(new SqlParameter("@ImportFeeID", ImportFeeID));
            return GetOne<RoomFee>("select top 1 * from [RoomFee] where " + string.Join(" and ", conditions.ToArray()), parameters, helper);
        }
        public static RoomFee[] GetRoomFeeListByContractID(int ContractID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[IsStart]=1");
            conditions.Add("[ContractID]=@ContractID");
            parameters.Add(new SqlParameter("@ContractID", ContractID));
            return GetList<RoomFee>("select * from [RoomFee] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
        public static RoomFee[] GetRoomFeeIDListByContractIDList(int MinContractID, int MaxContractID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[IsStart]=1");
            conditions.Add("exists(select 1 from [Contract] where ID=[RoomFee].ContractID)");
            conditions.Add("[ContractID] between " + MinContractID + " and " + MaxContractID);
            return GetList<RoomFee>("select [ContractID] from [RoomFee] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
        public static RoomFee[] GetRoomFeeListByRoomIDList(List<int> RoomIDList, List<int> ProjectIDList, int UserID = 0)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[IsStart]=1");
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
            return GetList<RoomFee>("select * from [RoomFee] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
        public static RoomFee[] GetRoomFeeWeiYueList(int[] RoomFeeIDList)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            if (RoomFeeIDList.Length == 0)
            {
                return new RoomFee[] { };
            }
            conditions.Add("[RelatedFeeID] in (" + string.Join(",", RoomFeeIDList) + ")");
            return GetList<RoomFee>("select * from [RoomFee] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
        public static int GetTotalRoomFeeCount()
        {
            int total = 0;
            string cmdtext = @"select count(1) from [RoomFee]";
            using (SqlHelper helper = new SqlHelper())
            {
                var Total = helper.ExecuteScalar(cmdtext, CommandType.Text, new List<SqlParameter>());
                if (Total != null)
                {
                    int.TryParse(Total.ToString(), out total);
                }
            }
            return total;
        }
        public static RoomFee[] GetRoomFeeListByImportFeeIDList(List<int> ImportFeeIDList, int UserID = 0)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (ImportFeeIDList.Count == 0)
            {
                return new RoomFee[] { };
            }
            if (ImportFeeIDList.Count > 2)
            {
                ViewRoomFeeHistory.CreateTempTable(ImportFeeIDList, UserID: UserID);
                conditions.Add("EXISTS (SELECT 1 FROM [TempIDs] WHERE id=[RoomFee].ImportFeeID and [UserID]=" + UserID + ")");
            }
            else if (ImportFeeIDList.Count > 0)
            {
                conditions.Add("[ImportFeeID] in (" + string.Join(",", ImportFeeIDList.ToArray()) + ")");
            }
            return GetList<RoomFee>("select * from [RoomFee] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
        public static RoomFee[] GetRoomFeeListByTradeNo(string TradeNo, int OrderID = 0)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[IsStart]=1");
            List<string> sub_conditions = new List<string>();
            if (OrderID > 0)
            {
                sub_conditions.Add("[OrderID]=@OrderID");
                parameters.Add(new SqlParameter("@OrderID", OrderID));
            }
            sub_conditions.Add("[ID] in (select [RoomFeeID] from [Payment_Request] where [PaymentID] in (select [ID] from [Payment] where [TradeNo]=@TradeNo))");
            sub_conditions.Add("[TradeNo]=@TradeNo");
            conditions.Add("(" + string.Join(" or ", sub_conditions.ToArray()) + ")");
            parameters.Add(new SqlParameter("@TradeNo", TradeNo));
            return GetList<RoomFee>("select * from [RoomFee] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
        public static int GetRoomFeeCountByTradeNo(string TradeNo, int OrderID = 0)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[IsStart]=1");
            List<string> sub_conditions = new List<string>();
            if (OrderID > 0)
            {
                sub_conditions.Add("[OrderID]=@OrderID");
                parameters.Add(new SqlParameter("@OrderID", OrderID));
            }
            sub_conditions.Add("[ID] in (select [RoomFeeID] from [Payment_Request] where [PaymentID] in (select [ID] from [Payment] where [TradeNo]=@TradeNo))");
            sub_conditions.Add("[TradeNo]=@TradeNo");
            conditions.Add("(" + string.Join(" or ", sub_conditions.ToArray()) + ")");
            parameters.Add(new SqlParameter("@TradeNo", TradeNo));
            int total = 0;
            using (SqlHelper helper = new SqlHelper())
            {
                var result = helper.ExecuteScalar("select count(1) from [RoomFee] where " + string.Join(" and ", conditions.ToArray()), CommandType.Text, parameters);
                if (result != null)
                {
                    int.TryParse(result.ToString(), out total);
                }
            }
            return total;
        }
        public static RoomFee SetInfo_RoomFee(int RoomID, DateTime StartTime, DateTime EndTime, decimal Cost, decimal RealCost, decimal UnitPrice, int ChargeID, RoomFee data = null, decimal UseCount = 0, string Remark = "", bool IsCharged = false, int ChargeFeeID = 0, bool IsStart = true, decimal Discount = 0, decimal ChargeFee = 0, decimal TotalRealCost = 0, decimal TotalDiscountCost = 0, decimal RestCost = 0, int ContractID = 0, int RelatedFeeID = 0, int DefaultChargeManID = 0, string DefaultChargeManName = "", int Contract_RoomChargeID = 0, int ContractDivideID = 0, bool cansave = false, DateTime? NewEndTime = null, bool OnlyOnceCharge = false, int OutDays = 0, int DiscountID = 0, DateTime? CuiShouStartTime = null, DateTime? CuiShouEndTime = null, int ChongDiChargeID = 0, string TradeNo = "", int OrderID = 0, bool IsTempFee = false, bool IsMeterFee = false, bool IsImportFee = false, bool IsCycleFee = false, int ImportFeeID = 0, decimal RoomFeeCoefficient = 0, DateTime? RoomFeeWriteDate = null, int ChargeMeterProjectFeeID = 0, decimal RoomFeeStartPoint = 0, decimal RoomFeeEndPoint = 0, SqlHelper helper = null, int HistoryRoomFeeID = 0)
        {
            if (data == null)
            {
                data = new RoomFee();
                data.AddTime = DateTime.Now;
                data.AddUserName = User.GetCurrentUserName();
            }
            data.RoomID = RoomID;
            data.UseCount = UseCount;
            data.StartTime = StartTime;
            data.EndTime = EndTime;
            data.Cost = Cost;
            data.RealCost = RealCost;
            data.Remark = Remark;
            data.IsCharged = IsCharged;
            data.ChargeFeeID = 0;
            data.ChargeID = ChargeID;
            data.IsStart = IsStart;
            data.UnitPrice = UnitPrice;
            data.Discount = Discount;
            data.ChargeFee = ChargeFee;
            data.TotalRealCost = TotalRealCost;
            data.TotalDiscountCost = TotalDiscountCost;
            data.RestCost = RestCost;
            data.ContractID = ContractID;
            data.RelatedFeeID = RelatedFeeID;
            if (DefaultChargeManID <= 0)
            {
                RoomPhoneRelation default_relation = null;
                if (helper == null)
                {
                    default_relation = RoomPhoneRelation.GetDefaultInChargeFeeRoomPhoneRelation(data.RoomID, data.ContractID);
                }
                else
                {
                    default_relation = RoomPhoneRelation.GetDefaultInChargeFeeRoomPhoneRelation(data.RoomID, data.ContractID, helper);
                }
                if (default_relation != null)
                {
                    DefaultChargeManID = default_relation.ID;
                    DefaultChargeManName = default_relation.RelationName;
                }
            }
            data.DefaultChargeManID = DefaultChargeManID;
            data.DefaultChargeManName = DefaultChargeManName;
            data.Contract_RoomChargeID = Contract_RoomChargeID;
            data.ContractDivideID = ContractDivideID;
            if (NewEndTime != null && NewEndTime.HasValue)
            {
                data.NewEndTime = Convert.ToDateTime(NewEndTime);
            }
            data.OnlyOnceCharge = OnlyOnceCharge;
            data.OutDays = OutDays;
            data.DiscountID = DiscountID;
            if (CuiShouStartTime != null && CuiShouStartTime.HasValue)
            {
                data.CuiShouStartTime = Convert.ToDateTime(CuiShouStartTime);
            }
            if (CuiShouEndTime != null && CuiShouEndTime.HasValue)
            {
                data.CuiShouEndTime = Convert.ToDateTime(CuiShouEndTime);
            }
            data.ChongDiChargeID = ChongDiChargeID;
            data.TradeNo = TradeNo;
            data.OrderID = OrderID;
            data.IsTempFee = IsTempFee;
            data.IsMeterFee = IsMeterFee;
            data.IsImportFee = IsImportFee;
            data.IsCycleFee = IsCycleFee;
            data.ImportFeeID = ImportFeeID;
            data.RoomFeeCoefficient = RoomFeeCoefficient;
            data.ChargeMeterProjectFeeID = ChargeMeterProjectFeeID;
            data.RoomFeeStartPoint = RoomFeeStartPoint;
            data.RoomFeeEndPoint = RoomFeeEndPoint;
            if (RoomFeeWriteDate != null && RoomFeeWriteDate.HasValue)
            {
                data.RoomFeeWriteDate = Convert.ToDateTime(RoomFeeWriteDate);
            }
            if (cansave)
            {
                if (helper == null)
                {
                    using (helper = new SqlHelper())
                    {
                        try
                        {
                            helper.BeginTransaction();
                            data.Save(helper);
                            ChargeFeePriceRange.CreateChargeFeePriceRangeByImportFeeIDList(helper, RoomFeeID: data.ID, HistoryRoomFeeID: HistoryRoomFeeID);
                            helper.Commit();
                        }
                        catch (Exception)
                        {
                            helper.Rollback();
                        }
                    }
                }
                else
                {
                    data.Save(helper);
                    ChargeFeePriceRange.CreateChargeFeePriceRangeByImportFeeIDList(helper, RoomFeeID: data.ID, HistoryRoomFeeID: HistoryRoomFeeID);
                }
            }
            return data;
        }
        public static bool IsWechatChargeingFee(int[] RoomFeeIDList)
        {
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    var parameters = new List<SqlParameter>();
                    parameters.Add(new SqlParameter("@NowDate", DateTime.Now.AddSeconds(-60)));
                    string cmdtext = "select count(1) from [RoomFee] where exists(select 1 from [Payment_Request] where [RoomFeeID] in (" + string.Join(",", RoomFeeIDList) + ") and exists(select 1 from [Payment] where [Payment].ID=[Payment_Request].PaymentID and [PayRequestTime]>@NowDate))";
                    var result = helper.ExecuteScalar(cmdtext, CommandType.Text, parameters);
                    int total = 0;
                    if (result != null)
                    {
                        int.TryParse(result.ToString(), out total);
                    }
                    return total > 0;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
        public static void GetRoomFeeRoomIDList(int RoomID, out int PreRoomID, out int NextRoomID, out int CurrentRoomID, string keywords = "", List<int> ALLProjectIDList = null, int UserID = 0, int ProjectID = 0)
        {
            PreRoomID = 0;
            NextRoomID = 0;
            CurrentRoomID = 0;
            var parameters = new List<SqlParameter>();
            var conditions = new List<string>();
            conditions.Add("1=1");
            var list = new RoomFee[] { };
            if (ALLProjectIDList != null && ALLProjectIDList.Count > 0)
            {
                List<string> cmdlist = ViewRoomFeeHistory.GetProjectIDListConditions(ALLProjectIDList, IncludeRelation: false, RoomIDName: "[RoomID]", UserID: UserID);
                conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
            }
            if (!string.IsNullOrEmpty(keywords))
            {
                conditions.Add("([Project].[Name] like @keywords or [Project].[FullName] like @keywords)");
                parameters.Add(new SqlParameter("@keywords", "%" + keywords + "%"));

            }
            if (ProjectID > 0)
            {
                conditions.Add("([Project].[ID]=@ProjectID or [Project].[AllParentID] like @AllParentID)");
                parameters.Add(new SqlParameter("@ProjectID", ProjectID));
                parameters.Add(new SqlParameter("@AllParentID", "%," + ProjectID + ",%"));
            }
            list = GetList<RoomFee>("select [RoomFee].[RoomID] from [RoomFee] left join [Project] on [Project].ID=[RoomFee].RoomID where " + string.Join(" and ", conditions.ToArray()) + " order by [Project].DefaultOrder asc", parameters).ToArray();
            if (list.Length == 0)
            {
                return;
            }
            var ProjectIDList = list.Select(p => p.RoomID).Distinct().ToArray();
            if (RoomID > 0)
            {
                for (int i = 0; i < ProjectIDList.Length; i++)
                {
                    if (RoomID == ProjectIDList[i])
                    {
                        CurrentRoomID = RoomID;
                        if (i > 0)
                        {
                            PreRoomID = ProjectIDList[i - 1];
                        }
                        if (i < ProjectIDList.Length - 1)
                        {
                            NextRoomID = ProjectIDList[i + 1];
                        }
                    }
                }
                return;
            }
            CurrentRoomID = ProjectIDList[0];
            if (ProjectIDList.Length > 1)
            {
                NextRoomID = ProjectIDList[1];
            }
        }
    }
}
