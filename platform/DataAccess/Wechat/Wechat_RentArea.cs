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
	/// This object represents the properties and methods of a Wechat_RentArea.
	/// </summary>
	public partial class Wechat_RentArea : EntityBase
	{
        public static Wechat_RentArea[] GeWechat_RentAreaListByKeywords(string Keywords)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (!string.IsNullOrEmpty(Keywords))
            {
                conditions.Add("([AreaName] like @Keywords or [ID] in (select [AreaID] from [Wechat_RentBuilding] where [BuildingName] like @Keywords))");
                parameters.Add(new SqlParameter("@Keywords", "%" + Keywords + "%"));
            }
            return GetList<Wechat_RentArea>("select * from [Wechat_RentArea] where " + string.Join(" and ", conditions.ToArray()) + " order by [AddTime] desc", parameters).ToArray();
        }
	}
}
