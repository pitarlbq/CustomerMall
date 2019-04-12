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
    /// This object represents the properties and methods of a Wechat_RentHomeType.
    /// </summary>
    public partial class Wechat_RentHomeType : EntityBase
    {
        public static Wechat_RentHomeType[] GetWechat_RentHomeTypeListByHomeID(int HomeID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (HomeID <= 0)
            {
                return new Wechat_RentHomeType[] { };
            }
            conditions.Add("[RentRoomID]=@HomeID");
            parameters.Add(new SqlParameter("@HomeID", HomeID));
            string Statement = "select * from [Wechat_RentHomeType] where  " + string.Join(" and ", conditions.ToArray());
            return GetList<Wechat_RentHomeType>(Statement, parameters).ToArray();
        }
        public static Wechat_RentHomeType[] GetWechat_RentHomeTypeListByHomeIDList(List<int> HomeIDList)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (HomeIDList.Count == 0)
            {
                return new Wechat_RentHomeType[] { };
            }
            conditions.Add("[RentRoomID] in (" + string.Join(",", HomeIDList.ToArray()) + ")");
            string Statement = "select * from [Wechat_RentHomeType] where  " + string.Join(" and ", conditions.ToArray());
            return GetList<Wechat_RentHomeType>(Statement, parameters).ToArray();
        }
    }
}
