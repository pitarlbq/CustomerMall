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
    /// This object represents the properties and methods of a ImportFee.
    /// </summary>
    public partial class ImportFee : EntityBase
    {
        public static int[] GetImportFeeRoomIDList(List<int> ProjectIDList, string keywords = "")
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            if (!string.IsNullOrEmpty(keywords))
            {
                conditions.Add("([Project].[Name] like @keywords or [Project].[FullName] like @keywords)");
                parameters.Add(new SqlParameter("@keywords", "%" + keywords + "%"));
            }
            conditions.Add("([Project].[ID] in (select [RoomID] from [RoomBasic] where isnull([IsLocked],0)=0) or not exists (select * from [RoomBasic] where isnull([IsLocked],0)=0 and [RoomID]=[ImportFee].[RoomID]))");
            if (ProjectIDList.Count > 0)
            {
                List<string> cmdlist = new List<string>();
                foreach (var ProjectID in ProjectIDList)
                {
                    cmdlist.Add("[Project].[AllParentID] like '%," + ProjectID + ",%'");
                }
                conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
            }
            conditions.Add("[ImportFee].[ChargeStatus]=2");
            string fieldList = "select [ImportFee].RoomID from [ImportFee] left join [Project] on [Project].ID=[ImportFee].RoomID where " + string.Join(" and ", conditions.ToArray()) + " order by [Project].DefaultOrder asc, [ImportFee].WriteDate desc";
            ImportFee[] list = GetList<ImportFee>(fieldList, parameters).ToArray();
            return list.Select(p => p.RoomID).Distinct().ToArray();
        }
        public string StatusDesc
        {
            get
            {
                string typedesc = string.Empty;
                switch (this.ChargeStatus)
                {
                    case 0:
                        typedesc = "未收";
                        break;
                    case 1:
                        typedesc = "已收";
                        break;
                    case 2:
                        typedesc = "草稿";
                        break;
                    default:
                        break;
                }
                return typedesc;
            }
        }
        public static ImportFee GetMaxImportFeeWriteDate()
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            return GetOne<ImportFee>("select top 1 * from [ImportFee] order by [WriteDate] desc", parameters);
        }
        public static ImportFee GetImportFeeByRoomID(int RoomID, string WriteDate, int ChargeID, SqlHelper helper)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[RoomID]=@RoomID");
            parameters.Add(new SqlParameter("@RoomID", RoomID));
            conditions.Add("[ChargeID]=@ChargeID");
            parameters.Add(new SqlParameter("@ChargeID", ChargeID));
            if (!string.IsNullOrEmpty(WriteDate))
            {
                conditions.Add("CONVERT(varchar(10), [WriteDate], 120)=@WriteDate");
                parameters.Add(new SqlParameter("@WriteDate", WriteDate));
            }
            return GetOne<ImportFee>("select top 1 * from [ImportFee] where " + string.Join(" and ", conditions.ToArray()) + " order by [WriteDate] desc", parameters, helper);
        }
        public static ImportFee[] GetImportFeeByChargeID(int ChargeID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (ChargeID > 0)
            {
                conditions.Add("[ChargeID]=@ChargeID");
                parameters.Add(new SqlParameter("@ChargeID", ChargeID));
            }
            return GetList<ImportFee>("select * from [ImportFee] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
        public static ImportFee[] GetImportFeeListByIDList(List<int> IDList)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            conditions.Add("[ID] in (" + string.Join(" , ", IDList.ToArray()) + ")");
            return GetList<ImportFee>("select * from [ImportFee] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
        public static ImportFee[] GetImportFeeByProjectBiaoIDs(List<int> ProjectBiaoIDList)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (ProjectBiaoIDList.Count > 0)
            {
                conditions.Add("[ProjectBiaoID] in (" + string.Join(",", ProjectBiaoIDList.ToArray()) + ")");
            }
            return GetList<ImportFee>("select * from [ImportFee] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
        public static ImportFee[] GetImportFeeListByRoomIDList(List<int> RoomIDList, List<int> ProjectIDList, int UserID = 0)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (RoomIDList.Count > 0)
            {
                List<string> cmdlist = ViewRoomFeeHistory.GetRoomIDListConditions(RoomIDList, RoomIDName: "[RoomID]");
                conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
            }
            if (ProjectIDList != null && ProjectIDList.Count > 0)
            {
                List<string> cmdlist = ViewRoomFeeHistory.GetProjectIDListConditions(ProjectIDList, IsContractFee: false, UserID: UserID);
                conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
            }
            return GetList<ImportFee>("select * from [ImportFee] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
        public static ImportFee GetOrCreateImportFeeByID(int ID, bool CanCreate = true)
        {
            ImportFee data = null;
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    data = GetOrCreateImportFeeByID(ID, helper, CanCreate: CanCreate);
                    helper.Commit();
                }
                catch (Exception)
                {
                    helper.Rollback();
                }
            }
            return data;
        }
        public static ImportFee GetOrCreateImportFeeByID(int ID, SqlHelper helper, bool CanCreate = true)
        {
            var data = ImportFee.GetImportFee(ID, helper);
            if (!CanCreate)
            {
                return data;
            }
            if (data != null)
            {
                return data;
            }
            #region 删除备份还原
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@ID", ID));
            var bak_data = GetOne<ImportFeeBak>("select * from [ImportFeeBak] where [ID] = @ID", parameters, helper);
            if (bak_data != null)
            {
                string cmdtext = string.Empty;
                cmdtext += "SET IDENTITY_INSERT [ImportFee] ON;";
                cmdtext += @"
                    insert into [ImportFee]
                    ([ID]
                    ,[RoomID]
                    ,[ChargeDate]
                    ,[ChargeID]
                    ,[StartPoint]
                    ,[EndPoint]
                    ,[TotalPoint]
                    ,[UnitPrice]
                    ,[TotalPrice]
                    ,[WriteDate]
                    ,[StartTime]
                    ,[EndTime]
                    ,[AddTime]
                    ,[ChargeStatus]
                    ,[ImportCoefficient]
                    ,[ImportBiaoCategory]
                    ,[ImportBiaoName]
                    ,[ChargeBiaoID]
                    ,[ProjectBiaoID]
                    ,[ImportBiaoGuiGe]
                    ,[ImportRate]
                    ,[ImportReducePoint]
                    ,[ImportChargeRoomNo])
                    select 
                    [ID]
                    ,[RoomID]
                    ,[ChargeDate]
                    ,[ChargeID]
                    ,[StartPoint]
                    ,[EndPoint]
                    ,[TotalPoint]
                    ,[UnitPrice]
                    ,[TotalPrice]
                    ,[WriteDate]
                    ,[StartTime]
                    ,[EndTime]
                    ,getdate()
                    ,[ChargeStatus]
                    ,[ImportCoefficient]
                    ,[ImportBiaoCategory]
                    ,[ImportBiaoName]
                    ,[ChargeBiaoID]
                    ,[ProjectBiaoID]
                    ,[ImportBiaoGuiGe]
                    ,[ImportRate]
                    ,[ImportReducePoint]
                    ,[ImportChargeRoomNo]
                    from [ImportFeeBak] where ID=@ID;";
                cmdtext += @"SET IDENTITY_INSERT [ImportFee] OFF;";
                int count = helper.Execute(cmdtext, CommandType.Text, parameters);
                if (count > 0)
                {
                    data = ImportFee.GetImportFee(ID, helper);
                }
            }
            #endregion
            #region 账单明细还原
            if (data == null)
            {
                var roomfee = RoomFee.GetRoomFeeByImportFeeID(ID, helper);
                if (roomfee != null)
                {
                    decimal EndPoint = roomfee.UseCount > 0 ? roomfee.UseCount : 0;
                    decimal UnitPrice = roomfee.UnitPrice > 0 ? roomfee.UnitPrice : 0;
                    decimal RealCost = roomfee.RealCost > 0 ? roomfee.RealCost : 0;
                    string WriteDate = "'" + (roomfee.RoomFeeWriteDate > DateTime.MinValue ? roomfee.RoomFeeWriteDate.ToString("yyyy-MM-dd") : DateTime.Now.ToString("yyyy-MM-dd")) + "'";
                    string StartTime = roomfee.StartTime > DateTime.MinValue ? "'" + roomfee.StartTime.ToString("yyyy-MM-dd") + "'" : "NULL";
                    string EndTime = roomfee.EndTime > DateTime.MinValue ? "'" + roomfee.EndTime.ToString("yyyy-MM-dd") + "'" : "NULL";
                    decimal ImportCoefficient = roomfee.RoomFeeCoefficient > 0 ? roomfee.RoomFeeCoefficient : 0;
                    string cmdtext = string.Empty;
                    cmdtext += "SET IDENTITY_INSERT [ImportFee] ON;";
                    cmdtext += @"insert into [ImportFee]
                    ([ID]
                    ,[RoomID]
                    ,[ChargeDate]
                    ,[ChargeID]
                    ,[StartPoint]
                    ,[EndPoint]
                    ,[TotalPoint]
                    ,[UnitPrice]
                    ,[TotalPrice]
                    ,[WriteDate]
                    ,[StartTime]
                    ,[EndTime]
                    ,[AddTime]
                    ,[ChargeStatus]
                    ,[ImportCoefficient]
                    ,[ImportBiaoCategory]
                    ,[ImportBiaoName]
                    ,[ChargeBiaoID]
                    ,[ProjectBiaoID]
                    ,[ImportBiaoGuiGe]
                    ,[ImportRate]
                    ,[ImportReducePoint]
                    ,[ImportChargeRoomNo])
                    values( 
                     " + ID + @"
                    ," + roomfee.RoomID + @"
                    ,NULL
                    ," + roomfee.ChargeID + @"
                    ,0
                    ," + EndPoint + @"
                    ," + EndPoint + @"
                    ," + UnitPrice + @"
                    ," + RealCost + @"
                    ," + WriteDate + @"
                    ," + StartTime + @"
                    ," + EndTime + @"
                    ,getdate()
                    ,0
                    ," + ImportCoefficient + @"
                    ,NULL
                    ,NULL
                    ,0
                    ,0
                    ,NULL
                    ,0
                    ,0
                    ,NULL
                    );";
                    cmdtext += @"SET IDENTITY_INSERT [ImportFee] OFF;";
                    int count = helper.Execute(cmdtext, CommandType.Text, new List<SqlParameter>());
                    if (count > 0)
                    {
                        data = ImportFee.GetImportFee(ID, helper);
                    }
                }
            }
            #endregion
            #region 历史单据还原
            if (data == null)
            {
                var roomfee = RoomFeeHistory.GetRoomFeeHistoryByImportFeeID(ID, helper);
                if (roomfee != null)
                {
                    decimal EndPoint = roomfee.UseCount > 0 ? roomfee.UseCount : 0;
                    decimal UnitPrice = roomfee.UnitPrice > 0 ? roomfee.UnitPrice : 0;
                    decimal RealCost = roomfee.RealCost > 0 ? roomfee.RealCost : 0;
                    string WriteDate = "'" + (roomfee.RoomFeeWriteDate > DateTime.MinValue ? roomfee.RoomFeeWriteDate.ToString("yyyy-MM-dd") : DateTime.Now.ToString("yyyy-MM-dd")) + "'";
                    string StartTime = roomfee.StartTime > DateTime.MinValue ? "'" + roomfee.StartTime.ToString("yyyy-MM-dd") + "'" : "NULL";
                    string EndTime = roomfee.EndTime > DateTime.MinValue ? "'" + roomfee.EndTime.ToString("yyyy-MM-dd") + "'" : "NULL";
                    decimal ImportCoefficient = roomfee.RoomFeeCoefficient > 0 ? roomfee.RoomFeeCoefficient : 0;
                    string cmdtext = string.Empty;
                    cmdtext += "SET IDENTITY_INSERT [ImportFee] ON;";
                    cmdtext += @"insert into [ImportFee]
                    ([ID]
                    ,[RoomID]
                    ,[ChargeDate]
                    ,[ChargeID]
                    ,[StartPoint]
                    ,[EndPoint]
                    ,[TotalPoint]
                    ,[UnitPrice]
                    ,[TotalPrice]
                    ,[WriteDate]
                    ,[StartTime]
                    ,[EndTime]
                    ,[AddTime]
                    ,[ChargeStatus]
                    ,[ImportCoefficient]
                    ,[ImportBiaoCategory]
                    ,[ImportBiaoName]
                    ,[ChargeBiaoID]
                    ,[ProjectBiaoID]
                    ,[ImportBiaoGuiGe]
                    ,[ImportRate]
                    ,[ImportReducePoint]
                    ,[ImportChargeRoomNo])
                    values( 
                     " + ID + @"
                    ," + roomfee.RoomID + @"
                    ,NULL
                    ," + roomfee.ChargeID + @"
                    ,0
                    ," + EndPoint + @"
                    ," + EndPoint + @"
                    ," + UnitPrice + @"
                    ," + RealCost + @"
                    ," + WriteDate + @"
                    ," + StartTime + @"
                    ," + EndTime + @"
                    ,getdate()
                    ,0
                    ," + ImportCoefficient + @"
                    ,NULL
                    ,NULL
                    ,0
                    ,0
                    ,NULL
                    ,0
                    ,0
                    ,NULL
                    );";
                    cmdtext += @"SET IDENTITY_INSERT [ImportFee] OFF;";
                    int count = helper.Execute(cmdtext, CommandType.Text, new List<SqlParameter>());
                    if (count > 0)
                    {
                        data = ImportFee.GetImportFee(ID, helper);
                    }
                }
            }
            #endregion
            return data;
        }
    }
    public class ImportFeeDetails : ImportFee
    {
        [DatabaseColumn("RoomName")]
        public string RoomName { get; set; }
        [DatabaseColumn("FullName")]
        public string FullName { get; set; }
        [DatabaseColumn("ChargeSummaryCoefficient")]
        public decimal ChargeSummaryCoefficient { get; set; }
        [DatabaseColumn("SummaryUnitPrice")]
        public decimal SummaryUnitPrice { get; set; }
        [DatabaseColumn("IsReading")]
        public bool IsReading { get; set; }
        public string FinalFullName
        {
            get
            {
                return this.FullName + "-" + this.RoomName;
            }
        }
        public static string CommSqlText = "(select [ImportFee].*,[Project].Name as RoomName,[Project].FullName,[Project].DefaultOrder,[ChargeSummary].Coefficient as ChargeSummaryCoefficient,[ChargeSummary].SummaryUnitPrice,[ChargeSummary].IsReading from [ImportFee] left join [Project] on [Project].ID=[ImportFee].RoomID left join [ChargeSummary] on [ChargeSummary].ID=[ImportFee].[ChargeID])A";
        public static ImportFeeDetails[] GetImportFeeDetailsListByRoomID(int RoomID, int ChargeID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("([RoomID] in (select [RoomID] from [RoomBasic] where isnull([IsLocked],0)=0) or not exists (select * from [RoomBasic] where isnull([IsLocked],0)=0 and [RoomID]=[A].[RoomID]))");
            conditions.Add("[RoomID]=@RoomID");
            parameters.Add(new SqlParameter("@RoomID", RoomID));
            conditions.Add("[ChargeID]=@ChargeID");
            parameters.Add(new SqlParameter("@ChargeID", ChargeID));
            conditions.Add("[ChargeStatus]=2");
            string fieldList = "select A.* from " + CommSqlText + " where " + string.Join(" and ", conditions.ToArray()) + " order by WriteDate desc,[DefaultOrder] asc";
            var list = GetList<ImportFeeDetails>(fieldList, parameters).ToArray();
            return list;
        }
        public static ImportFeeDetails[] GetImportFeeDetailsListByIDList(List<int> IDList, string orderby = "")
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            string cmdwhere = string.Empty;
            if (IDList.Count > 0)
            {
                conditions.Add("[ID] in (" + string.Join(",", IDList.ToArray()) + ")");
            }
            string cmdorderby = string.Empty;
            if (!string.IsNullOrEmpty(orderby))
            {
                if (orderby.ToLower().StartsWith("order by"))
                {
                    cmdorderby = orderby;
                }
                else
                {
                    cmdorderby = "order by " + orderby;
                }
            }
            string cmdText = "select A.* from " + CommSqlText + " where " + string.Join(" and ", conditions.ToArray()) + cmdorderby;
            var list = GetList<ImportFeeDetails>(cmdText, parameters).ToArray();
            return list;
        }
    }
}
