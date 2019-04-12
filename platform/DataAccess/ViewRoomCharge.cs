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
    /// This object represents the properties and methods of a ViewRoomCharge.
    /// </summary>
    public partial class ViewRoomCharge : EntityBaseReadOnly
    {
        public static ViewRoomCharge[] GetViewRoomChargeTreeListByRoomID(int CompanyID, int ID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[IsStart]=1");
            conditions.Add("[FeeType] in (1,5)");
            if (CompanyID != 1)
            {
                conditions.Add("([CompanyID]=@CompanyID or CompanyID is null)");
                parameters.Add(new SqlParameter("@CompanyID", CompanyID));
            }
            if (ID > 0)
            {
                conditions.Add("[RoomID]=@ID");
                parameters.Add(new SqlParameter("@ID", ID));
            }
            ViewRoomCharge[] list = GetList<ViewRoomCharge>("select max([ID]) as [ID],[RoomID],[Name],[CompanyID],[OrderBy] from [ViewRoomCharge] where " + string.Join(" and ", conditions.ToArray()) + " group by [RoomID],[Name],[CompanyID],[OrderBy] order by [OrderBy]", parameters).ToArray();
            return list;
        }
        public static ViewRoomCharge[] GetViewRoomChargeTreeList()
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[IsStart]=1");
            conditions.Add("[FeeType] in (1,5)");
            ViewRoomCharge[] list = GetList<ViewRoomCharge>("select max([ID]) as [ID],[RoomID],[Name],[CompanyID],[OrderBy] from [ViewRoomCharge] where " + string.Join(" and ", conditions.ToArray()) + " group by [RoomID],[Name],[CompanyID],[OrderBy] order by [OrderBy]", parameters).ToArray();
            return list;
        }
    }
}
