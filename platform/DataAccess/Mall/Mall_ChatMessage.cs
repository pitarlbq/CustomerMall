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
    /// This object represents the properties and methods of a Mall_ChatMessage.
    /// </summary>
    public partial class Mall_ChatMessage : EntityBase
    {
        public static Mall_ChatMessage[] GetMall_ChatMessageListByBusinesChatID(int ChatID, bool onlyTotay = false)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (ChatID <= 0)
            {
                return new Mall_ChatMessage[] { };
            }
            if (onlyTotay)
            {
                conditions.Add("convert(char(10),[AddTime],120)=@Today");
                parameters.Add(new SqlParameter("@Today", DateTime.Now.ToString("yyyy-MM-dd")));
            }
            conditions.Add("[ChatID]=@ChatID");
            parameters.Add(new SqlParameter("@ChatID", ChatID));
            string cmdtext = "select * from [Mall_ChatMessage] where  " + string.Join(" and ", conditions.ToArray()) + " order by [AddTime] asc";
            return GetList<Mall_ChatMessage>(cmdtext, parameters).ToArray();
        }
    }
}
