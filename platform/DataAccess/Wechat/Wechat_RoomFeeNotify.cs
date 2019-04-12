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
    /// This object represents the properties and methods of a Wechat_RoomFeeNotify.
    /// </summary>
    public partial class Wechat_RoomFeeNotify : EntityBase
    {
        public static Wechat_RoomFeeNotify GetWechat_RoomFeeNotifyBySendDate(string SendDate)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@SendDate", SendDate));
            return GetOne<Wechat_RoomFeeNotify>("select top 1 * from [Wechat_RoomFeeNotify] where SendDate=@SendDate", parameters);
        }
        public static Wechat_RoomFeeNotify[] GetWechat_RoomFeeNotifyByFeeIDList(int[] FeeIDList)
        {
            if (FeeIDList.Length == 0)
            {
                return new Wechat_RoomFeeNotify[] { };
            }
            List<SqlParameter> parameters = new List<SqlParameter>();
            return GetList<Wechat_RoomFeeNotify>("select * from [Wechat_RoomFeeNotify] where [FeeID] in (" + string.Join(",", FeeIDList) + ")", parameters).ToArray();
        }
    }
}
