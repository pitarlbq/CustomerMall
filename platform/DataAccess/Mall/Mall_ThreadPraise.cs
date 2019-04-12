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
    /// This object represents the properties and methods of a Mall_ThreadPraise.
    /// </summary>
    public partial class Mall_ThreadPraise : EntityBase
    {
        public static Mall_ThreadPraise[] GetMall_ThreadPraiseListByThreadIDList(List<int> ThreadIDList)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (ThreadIDList.Count == 0)
            {
                return new Mall_ThreadPraise[] { };
            }
            conditions.Add("[ThreadID] in (" + string.Join(",", ThreadIDList.ToArray()) + ")");
            string cmdtext = "select * from [Mall_ThreadPraise] where  " + string.Join(" and ", conditions.ToArray());
            return GetList<Mall_ThreadPraise>(cmdtext, parameters).ToArray();
        }
        public static Mall_ThreadPraise[] GetMall_ThreadPraiseListByThreadID(int ThreadID)
        {
            if (ThreadID == 0)
            {
                return new Mall_ThreadPraise[] { };
            }
            List<int> ThreadIDList = new List<int>();
            ThreadIDList.Add(ThreadID);
            return GetMall_ThreadPraiseListByThreadIDList(ThreadIDList);
        }
        public static Mall_ThreadPraise GetMall_ThreadPraiseByThreadID(int ThreadID, int UserID)
        {
            if (ThreadID == 0 && UserID == 0)
            {
                return new Mall_ThreadPraise();
            }
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            if (ThreadID > 0)
            {
                conditions.Add("[ThreadID]=@ThreadID");
                parameters.Add(new SqlParameter("@ThreadID", ThreadID));
            }
            if (UserID > 0)
            {
                conditions.Add("[UserID]=@UserID");
                parameters.Add(new SqlParameter("@UserID", UserID));
            }
            string cmdtext = "select * from [Mall_ThreadPraise] where  " + string.Join(" and ", conditions.ToArray());
            return GetOne<Mall_ThreadPraise>(cmdtext, parameters);
        }
    }
}
