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
	/// This object represents the properties and methods of a Wechat_LotteryActivityRecord.
	/// </summary>
	public partial class Wechat_LotteryActivityRecord : EntityBase
	{
        public static Wechat_LotteryActivityRecord[] GetWechat_LotteryActivityRecords(int activityID, bool onlyPrize)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");

            parameters.Add(new SqlParameter("@ActivityID", activityID));
            conditions.Add("[ActivityID]=@ActivityID");

            if (onlyPrize)
            {
                conditions.Add("[PrizeID]>0");
            }

            return GetList<Wechat_LotteryActivityRecord>("select * from " + TableName + " where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
	}
}
