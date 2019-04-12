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
    /// This object represents the properties and methods of a ZhuangXiu_XunJian.
    /// </summary>
    public partial class ZhuangXiu_XunJian : EntityBase
    {
        public static ZhuangXiu_XunJian[] GetZhuangXiu_XunJianList(int ZhuangXiuID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[ZhuangXiuID]=@ZhuangXiuID");
            parameters.Add(new SqlParameter("@ZhuangXiuID", ZhuangXiuID));
            return GetList<ZhuangXiu_XunJian>("select * from [ZhuangXiu_XunJian] where " + string.Join(" and ", conditions.ToArray()) + " order by AddTime desc", parameters).ToArray();
        }
    }
}
