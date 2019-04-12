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
    /// This object represents the properties and methods of a Mall_ChatTitle.
    /// </summary>
    public partial class Mall_ChatTitle : EntityBase
    {
        public static bool GrabMall_ChatTitleByAPPUserID(int ID, int UserID)
        {
            Mall_ChatTitle data = null;
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    data = Mall_ChatTitle.GetMall_ChatTitle(ID, helper);
                    if (data != null && data.ToUserID <= 0)
                    {
                        helper.BeginTransaction();
                        data.ToUserID = UserID;
                        data.Save(helper);
                        helper.Commit();
                    }
                }
                catch (Exception)
                {
                    helper.Rollback();
                }
            }
            return data.ToUserID == UserID;
        }
        public static Mall_ChatTitle GetMall_ChatTitleByAPPUserID(int UserID, int ProductID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            if (UserID <= 0)
            {
                return null;
            }
            conditions.Add("[FromUserID]=@FromUserID");
            conditions.Add("Convert(varchar(100),[AddTime],23)>=@StartTime");
            parameters.Add(new SqlParameter("@StartTime", DateTime.Today));
            parameters.Add(new SqlParameter("@FromUserID", UserID));
            conditions.Add("[ToBusinessID] in (select [BusinessID] from [Mall_Product] where [ID]=@ProductID)");
            parameters.Add(new SqlParameter("@ProductID", ProductID));
            string cmdtext = "select * from [Mall_ChatTitle] where  " + string.Join(" and ", conditions.ToArray());
            return GetOne<Mall_ChatTitle>(cmdtext, parameters);
        }
    }
    public partial class Mall_ChatTitleDetail : Mall_ChatTitle
    {
        [DatabaseColumn("LastMessage")]
        public string LastMessage { get; set; }
        [DatabaseColumn("HeadImage")]
        public string HeadImage { get; set; }
        [DatabaseColumn("NickName")]
        public string NickName { get; set; }
        [DatabaseColumn("UnreadCount")]
        public int UnreadCount { get; set; }
        public static Mall_ChatTitleDetail[] GetMall_ChatTitleDetailListByBusinesUserID(int UserID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (UserID <= 0)
            {
                return new Mall_ChatTitleDetail[] { };
            }
            conditions.Add("([ToBusinessID] in (select [ID] from [Mall_Business] where [UserID]=@UserID) or [ToBusinessID] in (select [BusinessID] from [Mall_BusinessUser] where [UserID]=@UserID))");
            conditions.Add("([ToUserID]=0 or [ToUserID]=@UserID)");
            conditions.Add("[AddTime]>=@DateToday");
            parameters.Add(new SqlParameter("@UserID", UserID));
            parameters.Add(new SqlParameter("@DateToday", DateTime.Today));
            string cmdtext = "select *,(select top 1 [ChatContent] from [Mall_ChatMessage] where [ChatID]=[Mall_ChatTitle].ID and [ChatType]=1 and [AddTime]>=@DateToday order by AddTime desc) as LastMessage,(select count(1) from [Mall_ChatMessage] where [ChatID]=[Mall_ChatTitle].ID and [ChatType]=1 and [UserReadTime] is null and [AddTime]>=@DateToday) as UnreadCount,(select top 1 [HeadImg] from [User] where [UserID]=[Mall_ChatTitle].FromUserID) as HeadImage,(select top 1 [NickName] from [User] where [UserID]=[Mall_ChatTitle].FromUserID) as NickName from [Mall_ChatTitle] where  " + string.Join(" and ", conditions.ToArray()) + " order by [AddTime] desc";
            return GetList<Mall_ChatTitleDetail>(cmdtext, parameters).ToArray();
        }
        public static int GetBusinessMsgCountByUserID(int UserID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (UserID <= 0)
            {
                return 0;
            }
            parameters.Add(new SqlParameter("@UserID", UserID));
            parameters.Add(new SqlParameter("@DateToday", DateTime.Today));
            int total = 0;
            string cmdtext = "select count(1) from [Mall_ChatMessage] where [ChatType]=1 and [UserReadTime] is null and [AddTime]>=@DateToday and  [ChatID] in (select ID from [Mall_ChatTitle] where [ToUserID]=@UserID)";
            using (SqlHelper helper = new SqlHelper())
            {
                var result = helper.ExecuteScalar(cmdtext, CommandType.Text, parameters);
                if (result != null)
                {
                    int.TryParse(result.ToString(), out total);
                }
            }
            return total;
        }
    }
}
