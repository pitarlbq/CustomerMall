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
    /// This object represents the properties and methods of a RoomBasic.
    /// </summary>
    public partial class RoomBasic : EntityBase
    {
        public static RoomBasic GetRoomBasicByRoomID(int RoomID)
        {
            using (SqlHelper helper = new SqlHelper())
            {
                return GetRoomBasicByRoomID(RoomID, helper);
            }
        }
        public static RoomBasic GetRoomBasicByRoomID(int RoomID, SqlHelper helper)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (RoomID > 0)
            {
                conditions.Add("[RoomID]=@RoomID");
                parameters.Add(new SqlParameter("@RoomID", RoomID));
            }
            return GetOne<RoomBasic>("select top 1 * from [RoomBasic] where " + string.Join(" and ", conditions.ToArray()) + " order by [AddTime] desc", parameters, helper);
        }
        public static RoomBasic GetRoomBasicByFullName(string FullName, string RoomName)
        {
            using (SqlHelper helper = new SqlHelper())
            {
                return GetRoomBasicByFullName(FullName, RoomName, helper);
            }
        }
        public static RoomBasic GetRoomBasicByFullName(string FullName, string RoomName, SqlHelper helper)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            conditions.Add("[FullName]=@FullName");
            parameters.Add(new SqlParameter("@FullName", FullName));
            conditions.Add("[RoomName]=@RoomName");
            parameters.Add(new SqlParameter("@RoomName", RoomName));
            return GetOne<RoomBasic>("select top 1 * from [RoomBasic] where " + string.Join(" and ", conditions.ToArray()) + " order by [AddTime] desc", parameters, helper);
        }
        public string RoomStateDesc
        {
            get
            {
                //string typedesc = string.Empty;
                //switch (this.RoomState)
                //{
                //    case 1:
                //        typedesc = "单价*计费面积(月度)";
                //        break;
                //    case 2:
                //        typedesc = "定额(月度)";
                //        break;
                //    default:
                //        break;
                //}
                return this.RoomState;
            }
        }
        public static decimal GetTotalBuildingArea(int RoomID)
        {
            decimal totalbalance = 0;
            string cmdtext = @"select sum(isnull(BuildingArea,0)) from [RoomBasic] where [RoomID] in (select ID from Project where AllParentID like '%," + RoomID + ",%' or ID=" + RoomID + ")";
            using (SqlHelper helper = new SqlHelper())
            {
                var Total = helper.ExecuteScalar(cmdtext, CommandType.Text, new List<SqlParameter>());
                if (Total != null)
                {
                    decimal.TryParse(Total.ToString(), out totalbalance);
                }
            }
            return totalbalance;
        }
        public static decimal GetTotalContractAreaArea(int RoomID)
        {
            decimal totalbalance = 0;
            string cmdtext = @"select sum(isnull(ContractArea,0)) from [RoomBasic] where [RoomID] in (select ID from Project where AllParentID like '%," + RoomID + ",%' or ID=" + RoomID + ")";
            using (SqlHelper helper = new SqlHelper())
            {
                var Total = helper.ExecuteScalar(cmdtext, CommandType.Text, new List<SqlParameter>());
                if (Total != null)
                {
                    decimal.TryParse(Total.ToString(), out totalbalance);
                }
            }
            return totalbalance;
        }
        public static int GetTotalRoomCount(int RoomID)
        {
            int totalcount = 0;
            string cmdtext = @"select count(1) from Project where (AllParentID like '%," + RoomID + ",%' or ID=" + RoomID + ") and [isParent]=0";
            using (SqlHelper helper = new SqlHelper())
            {
                var Total = helper.ExecuteScalar(cmdtext, CommandType.Text, new List<SqlParameter>());
                if (Total != null)
                {
                    int.TryParse(Total.ToString(), out totalcount);
                }
            }
            return totalcount;
        }
        public static RoomBasic[] GetRoomBasicListByRoomIDList(List<int> RoomIDList)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (RoomIDList.Count > 0)
            {
                conditions.Add("[RoomID] in (" + string.Join(",", RoomIDList.ToArray()) + ")");
            }
            return GetList<RoomBasic>("select * from [RoomBasic] where " + string.Join(" and ", conditions.ToArray()) + " order by [AddTime] desc", parameters).ToArray();
        }
        public static RoomBasic[] GetRoomBasicListByContractID(int ContractID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (ContractID > 0)
            {
                conditions.Add("[RoomID] in (select [RoomID] from [Contract_Room] where [ContractID]=@ContractID)");
                parameters.Add(new SqlParameter("@ContractID", ContractID));
            }
            return GetList<RoomBasic>("select * from [RoomBasic] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
        public static RoomBasic[] GetRoomBasicListByParams(int[] RoomStateIDList = null, int[] RoomTypeIDList = null, int[] RoomPropertyIDList = null)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (RoomStateIDList != null && RoomStateIDList.Length > 0)
            {
                conditions.Add("[RoomStateID] in (" + string.Join(",", RoomStateIDList) + ")");
            }
            if (RoomTypeIDList != null && RoomTypeIDList.Length > 0)
            {
                conditions.Add("[RoomTypeID] in (" + string.Join(",", RoomTypeIDList) + ")");
            }
            if (RoomPropertyIDList != null && RoomPropertyIDList.Length > 0)
            {
                conditions.Add("[RoomPropertyID] in (" + string.Join(",", RoomPropertyIDList) + ")");
            }
            return GetList<RoomBasic>("select * from [RoomBasic] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
        public static RoomBasic[] GetRoomBasicListByMinMaxRoomID(int MinRoomID, int MaxRoomID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("RoomID between " + MinRoomID + " and " + MaxRoomID);
            return GetList<RoomBasic>("select * from [RoomBasic] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
    }
    public partial class RoomBasicStatic : EntityBaseReadOnly
    {
        [DatabaseColumn("RoomState")]
        public string RoomState { get; set; }
        [DatabaseColumn("TotalCount")]
        public int TotalCount { get; set; }
        protected override void EnsureParentProperties()
        {
        }
        public static RoomBasicStatic[] GetRoomBasicStaticCountByParams(int ProjectID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            return GetList<RoomBasicStatic>("select A.* from (select Count(1) as TotalCount,RoomState from RoomBasic where RoomID in (select ID from Project where AllParentID like '%," + ProjectID + ",%' or ID=" + ProjectID + ") and " + string.Join(" and ", conditions.ToArray()) + " group by RoomState)A", parameters).ToArray();
        }
    }
    public partial class RoomBasicDetail : EntityBaseReadOnly
    {
        [DatabaseColumn("RoomID")]
        public int RoomID { get; set; }
        [DatabaseColumn("RelationIDs")]
        public string RelationIDs { get; set; }
        protected override void EnsureParentProperties()
        {
        }
        public static RoomBasicDetail[] GetRoomBasicDetailListByRoomIDList(List<int> RoomIDList)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[RelationIDs] is not null");
            if (RoomIDList.Count > 0)
            {
                conditions.Add("[RoomID] in (" + string.Join(",", RoomIDList.ToArray()) + ")");
            }
            return GetList<RoomBasicDetail>(@"select * from (select [RoomID], (select CONVERT(NVARCHAR(50), RoomID) + ',' from RoomRelation where RoomID != RoomBasic.RoomID and (GUID in (select GUID from RoomRelation AS RoomRelation_2 where RoomRelation_2.RoomID = RoomBasic.RoomID)) FOR XML PATH('')) AS RelationIDs from RoomBasic)A where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
    }
}
