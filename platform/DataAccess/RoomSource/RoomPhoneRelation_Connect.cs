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
    /// This object represents the properties and methods of a RoomPhoneRelation_Connect.
    /// </summary>
    public partial class RoomPhoneRelation_Connect : EntityBase
    {
        public static RoomPhoneRelation_Connect[] GetRoomPhoneRelation_ConnectListByContractID(int ContractID)
        {
            var parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@ContractID", ContractID));
            return GetList<RoomPhoneRelation_Connect>("select * from [RoomPhoneRelation_Connect] where ContractID=@ContractID", parameters).ToArray();
        }
    }
}
