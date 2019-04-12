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
    /// This object represents the properties and methods of a Wechat_LotteryActivityUser.
    /// </summary>
    public partial class Wechat_LotteryActivityUser : EntityBase
    {
        public static Wechat_LotteryActivityUser GetWechat_LotteryActivityUserByPhone(string PhoneNumber, int ActivityID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (!string.IsNullOrEmpty(PhoneNumber))
            {
                conditions.Add("[PhoneNumber]=@PhoneNumber");
                parameters.Add(new SqlParameter("@PhoneNumber", PhoneNumber));
            }
            if (ActivityID > 0)
            {
                conditions.Add("[ActivityID]=@ActivityID");
                parameters.Add(new SqlParameter("@ActivityID", ActivityID));
            }
            return GetOne<Wechat_LotteryActivityUser>("select top 1 * from [Wechat_LotteryActivityUser] where  " + string.Join(" and ", conditions.ToArray()), parameters);
        }
        public static Ui.DataGrid GetWechat_LotteryActivityUserList(string keywords, int activityID, string orderBy, long startRowIndex, int pageSize)
        {
            long totalRows = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (!string.IsNullOrEmpty(keywords))
            {
                parameters.Add(new SqlParameter("@Keywords", "%" + keywords + "%"));
                conditions.Add("([PhoneNumber] like @Keywords or [CustomerName] like @Keywords)");
            }
            if (activityID > 0)
            {
                parameters.Add(new SqlParameter("@ActivityID", activityID));
                conditions.Add("[ActivityID]=@ActivityID");
            }
            var list = GetList<Wechat_LotteryActivityUser>("*", "from [Wechat_LotteryActivityUser] where " + string.Join(" and ", conditions.ToArray()), parameters, orderBy, startRowIndex, pageSize, out totalRows).ToArray();
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
        public static Wechat_LotteryActivityUser GetWechatLotteryActivityUserByOpenID(int ActivityID, string OpenID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (!string.IsNullOrEmpty(OpenID))
            {
                parameters.Add(new SqlParameter("@OpenID", OpenID));
                conditions.Add("([OpenID] = @OpenID)");
            }
            if (ActivityID > 0)
            {
                parameters.Add(new SqlParameter("@ActivityID", ActivityID));
                conditions.Add("([ActivityID] = @ActivityID)");
            }
            return GetOne<Wechat_LotteryActivityUser>("select top 1 * from [Wechat_LotteryActivityUser] where " + string.Join(" and ", conditions.ToArray()), parameters);
        }
    }
}
