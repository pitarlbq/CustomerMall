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
	/// This object represents the properties and methods of a Wechat_HouseServiceImg.
	/// </summary>
	public partial class Wechat_HouseServiceImg : EntityBase
	{
        public static Wechat_HouseServiceImg[] GetWechat_HouseServiceImgList(int ServiceID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[ServiceID]=@ServiceID");
            parameters.Add(new SqlParameter("@ServiceID", ServiceID));
            return GetList<Wechat_HouseServiceImg>("select * from [Wechat_HouseServiceImg] where " + string.Join(" and ", conditions.ToArray()) + " order by AddTime desc", parameters).ToArray();
        }
	}
}
