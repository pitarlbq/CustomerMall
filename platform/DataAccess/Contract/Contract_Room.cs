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
    /// This object represents the properties and methods of a Contract_Room.
    /// </summary>
    public partial class Contract_Room : EntityBase
    {
        public static Contract_Room[] GetContract_RoomListByContractID(int ContractID)
        {
            return GetContract_RoomListByContractID(ContractID, string.Empty);
        }
        public static Contract_Room[] GetContract_RoomListByContractID(int ContractID, string guid)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (ContractID > 0)
            {
                conditions.Add("[ContractID]=@ContractID");
                parameters.Add(new SqlParameter("@ContractID", ContractID));
            }
            else if (!string.IsNullOrEmpty(guid))
            {
                conditions.Add("[GUID]=@GUID");
                parameters.Add(new SqlParameter("@GUID", guid));
            }
            Contract_Room[] list = GetList<Contract_Room>("select * from [Contract_Room] where  " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
            return list;
        }
        public static Contract_Room[] GetContract_RoomList(int ContractID, string guid, int RoomID = 0, List<int> RoomIDList = null)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            if (ContractID > 0)
            {
                conditions.Add("[ContractID]=@ContractID");
                parameters.Add(new SqlParameter("@ContractID", ContractID));
            }
            else if (!string.IsNullOrEmpty(guid))
            {
                conditions.Add("[GUID]=@GUID");
                parameters.Add(new SqlParameter("@GUID", guid));
            }
            if (RoomID > 0)
            {
                conditions.Add("[RoomID]=@RoomID");
                parameters.Add(new SqlParameter("@RoomID", RoomID));
            }
            if (RoomIDList != null && RoomIDList.Count > 0)
            {
                conditions.Add("[RoomID] in (" + string.Join(",", RoomIDList.ToArray()) + ")");
            }
            if (conditions.Count == 0)
            {
                return new Contract_Room[] { };
            }
            return GetList<Contract_Room>("select * from [Contract_Room] where  " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
        public static Contract_Room[] GetContract_RoomListByIDList(List<int> IDList)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[ID] in (" + string.Join(",", IDList.ToArray()) + ")");
            return GetList<Contract_Room>("select * from [Contract_Room] where  " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
        public static Contract_Room[] GetContract_RoomListByRoomIDList(List<int> RoomIDList, List<int> ProjectIDList, int UserID = 0)
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
            return GetList<Contract_Room>("select * from [Contract_Room] where  " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
    }
    public partial class Contract_RoomDetail : EntityBaseReadOnly
    {
        [DatabaseColumn("ContractID")]
        public int ContractID { get; set; }
        [DatabaseColumn("RoomID")]
        public int RoomID { get; set; }
        [DatabaseColumn("AllParentID")]
        public string AllParentID { get; set; }
        protected override void EnsureParentProperties()
        {
        }
        public static Contract_RoomDetail[] GetContract_RoomDetailListByMinMaxContractID(int MinContractID, int MaxContractID)
        {
            return GetList<Contract_RoomDetail>("select [Contract_Room].[ContractID],[Contract_Room].[RoomID],[Project].AllParentID from [Contract_Room] left join [Project] on [Project].ID=[Contract_Room].RoomID where [ContractID] between " + MinContractID + " and " + MaxContractID, new List<SqlParameter>()).ToArray();
        }
    }
}
