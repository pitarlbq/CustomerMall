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
    /// This object represents the properties and methods of a Wechat_MsgUser.
    /// </summary>
    public partial class Wechat_MsgUser : EntityBase
    {
        public static Wechat_MsgUser GetWechat_MsgUserByOpenID(string OpenID, int MsgID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (!string.IsNullOrEmpty(OpenID))
            {
                conditions.Add("[OpenID]=@OpenID");
                parameters.Add(new SqlParameter("@OpenID", OpenID));
            }
            if (MsgID > 0)
            {
                conditions.Add("[Wechat_MsgID]=@Wechat_MsgID");
                parameters.Add(new SqlParameter("@Wechat_MsgID", MsgID));
            }
            return GetOne<Wechat_MsgUser>("select * from [Wechat_MsgUser] where " + string.Join(" and ", conditions.ToArray()), parameters);
        }
    }
}
