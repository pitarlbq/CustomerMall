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
    /// This object represents the properties and methods of a Mall_ChatSensitive.
    /// </summary>
    public partial class Mall_ChatSensitive : EntityBase
    {
        public static Mall_ChatSensitive[] GetMall_ChatSensitiveListByKeywords(string Keywords)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (string.IsNullOrEmpty(Keywords))
            {
                return new Mall_ChatSensitive[] { };
            }
            conditions.Add("CHARINDEX([Keywords],@Keywords)>0");
            parameters.Add(new SqlParameter("@Keywords", Keywords));
            string cmdtext = "select * from [Mall_ChatSensitive] where  " + string.Join(" and ", conditions.ToArray()) + " order by [AddTime] asc";
            return GetList<Mall_ChatSensitive>(cmdtext, parameters).ToArray();
        }
        public static Mall_ChatSensitive[] GetMall_ChatSensitiveListByIDList(List<int> IDList)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (IDList.Count == 0)
            {
                return new Mall_ChatSensitive[] { };
            }
            string cmdtext = "select * from [Mall_ChatSensitive] where [ID] in (" + string.Join(",", IDList.ToArray()) + ") order by [AddTime] asc";
            return GetList<Mall_ChatSensitive>(cmdtext, parameters).ToArray();
        }
    }
}
