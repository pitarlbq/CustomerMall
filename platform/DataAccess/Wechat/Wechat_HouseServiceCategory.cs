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
    /// This object represents the properties and methods of a Wechat_HouseServiceCategory.
    /// </summary>
    public partial class Wechat_HouseServiceCategory : EntityBase
    {
        public static Wechat_HouseServiceCategory[] GetWechat_HouseServiceCategoryListByKeywords(string Keywords, int type)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            if (type == 1)
            {
                conditions.Add("[IsWechatShow]=1");
            }
            if (type == 2 || type == 3)
            {
                conditions.Add("([IsAPPCustomerShow]=1 or [IsAPPUserShow]=1)");
            }
            if (!string.IsNullOrEmpty(Keywords))
            {
                conditions.Add("([CategoryName] like @Keywords)");
                parameters.Add(new SqlParameter("@Keywords", "%" + Keywords + "%"));
            }
            return GetList<Wechat_HouseServiceCategory>("select * from [Wechat_HouseServiceCategory] where " + string.Join(" and ", conditions.ToArray()) + " order by [AddTime] desc", parameters).ToArray();
        }
    }
}
