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
    /// This object represents the properties and methods of a Wechat_RentHomeImg.
    /// </summary>
    public partial class Wechat_RentHomeImg : EntityBase
    {
        public static Wechat_RentHomeImg[] GetWechat_RentHomeImgList(int RentHomeID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[RentHomeID]=@RentHomeID");
            parameters.Add(new SqlParameter("@RentHomeID", RentHomeID));
            return GetList<Wechat_RentHomeImg>("select * from [Wechat_RentHomeImg] where " + string.Join(" and ", conditions.ToArray()) + " order by AddTime desc", parameters).ToArray();
        }
        public static Wechat_RentHomeImg[] GetWechat_RentHomeImgList(List<int> RentHomeIDList)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[RentHomeID] in (" + string.Join(",", RentHomeIDList.ToArray()) + ")");
            return GetList<Wechat_RentHomeImg>("select * from [Wechat_RentHomeImg] where " + string.Join(" and ", conditions.ToArray()) + " order by AddTime desc", parameters).ToArray();
        }
    }
}
