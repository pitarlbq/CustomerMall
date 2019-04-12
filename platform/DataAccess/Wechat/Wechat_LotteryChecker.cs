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
    /// This object represents the properties and methods of a Wechat_LotteryChecker.
    /// </summary>
    public partial class Wechat_LotteryChecker : EntityBase
    {
        public static Wechat_LotteryChecker GetWechat_LotteryCheckerByActivityID(int ActivityID, int UserID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (UserID > 0)
            {
                conditions.Add("[UserID]=@UserID");
                parameters.Add(new SqlParameter("@UserID", UserID));
            }
            if (ActivityID > 0)
            {
                conditions.Add("[ActivityID]=@ActivityID");
                parameters.Add(new SqlParameter("@ActivityID", ActivityID));
            }
            return GetOne<Wechat_LotteryChecker>("select top 1 * from [Wechat_LotteryChecker] where  " + string.Join(" and ", conditions.ToArray()), parameters);
        }
    }
}
