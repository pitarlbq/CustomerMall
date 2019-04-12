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
    /// This object represents the properties and methods of a Wechat_RentBuilding.
    /// </summary>
    public partial class Wechat_RentBuilding : EntityBase
    {
        public static Wechat_RentBuilding[] GeWechat_RentBuildingListByKeywords(List<int> AreaIDList, string Keywords)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (AreaIDList.Count > 0)
            {
                conditions.Add("[AreaID] in (" + string.Join(",", AreaIDList.ToArray()) + ")");
            }
            if (!string.IsNullOrEmpty(Keywords))
            {
                conditions.Add("[BuildingName] like @Keywords");
                parameters.Add(new SqlParameter("@Keywords", "%" + Keywords + "%"));
            }
            return GetList<Wechat_RentBuilding>("select * from [Wechat_RentBuilding] where " + string.Join(" and ", conditions.ToArray()) + " order by [AddTime] desc", parameters).ToArray();
        }
    }
    public partial class Wechat_RentBuildingDetail : Wechat_RentBuilding
    {
        [DatabaseColumn("AreaName")]
        public string AreaName { get; set; }
        public static Wechat_RentBuildingDetail[] GeWechat_RentBuildingDetailListByAreaIDList(List<int> IDList, List<int> AreaIDList)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (IDList.Count > 0)
            {
                conditions.Add("[ID] not in (" + string.Join(",", IDList.ToArray()) + ")");
            }
            if (AreaIDList.Count > 0)
            {
                conditions.Add("[AreaID] in (" + string.Join(",", AreaIDList.ToArray()) + ")");
            }
            return GetList<Wechat_RentBuildingDetail>("select *,(select AreaName from [Wechat_RentArea] where ID=[Wechat_RentBuilding].AreaID) as AreaName from [Wechat_RentBuilding] where " + string.Join(" and ", conditions.ToArray()) + " order by [AddTime] desc", parameters).ToArray();
        }
    }
}
