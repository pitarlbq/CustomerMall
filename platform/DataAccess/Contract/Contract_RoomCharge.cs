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
    /// This object represents the properties and methods of a Contract_RoomCharge.
    /// </summary>
    public partial class Contract_RoomCharge : EntityBase
    {
        public static Contract_RoomCharge[] GetContract_RoomChargeList(int ContractID, string guid)
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
            return GetList<Contract_RoomCharge>("select * from [Contract_RoomCharge] where  " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
        public static Contract_RoomCharge[] GetGroupbyContract_RoomCharge(int[] RoomIDList)
        {
            if (RoomIDList.Length == 0)
            {
                return new Contract_RoomCharge[] { };
            }
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            parameters.Add(new SqlParameter("@ContractStatus", Utility.EnumModel.ContractStatus.tongguo.ToString()));
            conditions.Add("[ContractID] in (select ID from [Contract] where [ContractStatus]=@ContractStatus)");
            conditions.Add("[ContractID] in (select [ContractID] from [Contract_Room] where [RoomID] in (" + string.Join(",", RoomIDList) + "))");
            conditions.Add("([RoomID] in (" + string.Join(",", RoomIDList) + ") or [RoomID]=0)");
            return GetList<Contract_RoomCharge>("select [ContractID] from [Contract_RoomCharge] where  " + string.Join(" and ", conditions.ToArray()) + " group by [ContractID]", parameters).ToArray();
        }
        public static Contract_RoomCharge[] GetContract_RoomChargeListByIDList(List<int> IDList)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (IDList.Count > 0)
            {
                conditions.Add("[ID] in (" + string.Join(",", IDList.ToArray()) + ")");
            }
            return GetList<Contract_RoomCharge>("select * from [Contract_RoomCharge] where  " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
        public static Contract_RoomCharge[] GetContract_RoomChargeListByContractID(int ContractID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (ContractID > 0)
            {
                conditions.Add("[RoomID] in (select [RoomID] from [Contract_Room] where [ContractID]=@ContractID)");
                parameters.Add(new SqlParameter("@ContractID", ContractID));
            }
            string Statement = "select RoomID,ChargeID from [Contract_RoomCharge] where  " + string.Join(" and ", conditions.ToArray()) + " group by RoomID,ChargeID";
            return GetList<Contract_RoomCharge>(Statement, parameters).ToArray();
        }
        public static Contract_RoomCharge[] GetContract_RoomChargeListByTempGuid(string guid)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            if (string.IsNullOrEmpty(guid))
            {
                return new Contract_RoomCharge[] { };
            }
            conditions.Add("[GUID]=@guid");
            parameters.Add(new SqlParameter("@guid", guid));
            conditions.Add("[Contract_TempPriceID] in (select [Contract_TempPrice].ID from [Contract_TempPrice] where  " + string.Join(" and ", conditions.ToArray()) + ")");
            string Statement = "select * from [Contract_RoomCharge] where  " + string.Join(" and ", conditions.ToArray());
            return GetList<Contract_RoomCharge>(Statement, parameters).ToArray();
        }
    }
}
