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
    /// This object represents the properties and methods of a ViewRoomPhoneRelation.
    /// </summary>
    public partial class ViewRoomPhoneRelation : EntityBaseReadOnly
    {
        [DatabaseColumn("UserLevelName")]
        public string UserLevelName { get; set; }
        public static Ui.DataGrid GetViewRoomPhoneRelationGridByKeywords(string keywords, int ProjectID, long startRowIndex, int pageSize, bool IsHuHuoRen)
        {
            long totalRows = 0;
            string OrderBy = " order by [DefaultOrder] asc";
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (IsHuHuoRen)
            {
                conditions.Add("[UserID] in (select [UserID] from [User] where [UserLevelID]>0)");
            }
            if (!string.IsNullOrEmpty(keywords))
            {
                conditions.Add("([RelatePhoneNumber] like @keywords or [RelationName] like @keywords)");
                parameters.Add(new SqlParameter("@keywords", "%" + keywords + "%"));
            }
            if (ProjectID > 0)
            {
                conditions.Add("([AllParentID] like @AllParentID or [RoomID]=@ProjectID)");
                parameters.Add(new SqlParameter("@AllParentID", "%," + ProjectID + ",%"));
                parameters.Add(new SqlParameter("@ProjectID", ProjectID));
            }
            string fieldList = "[ViewRoomPhoneRelation].*";
            string Statement = " from [ViewRoomPhoneRelation] where  " + string.Join(" and ", conditions.ToArray());
            if (IsHuHuoRen)
            {
                fieldList = "A.*";
                Statement = " from (select [ViewRoomPhoneRelation].*,(select [Name] from [Mall_UserLevel] where [ID]=(select [UserLevelID] from [User] where [UserID]=[ViewRoomPhoneRelation].[UserID])) as UserLevelName from [ViewRoomPhoneRelation])A where  " + string.Join(" and ", conditions.ToArray());
            }
            ViewRoomPhoneRelation[] list = GetList<ViewRoomPhoneRelation>(fieldList, Statement, parameters, OrderBy, startRowIndex, pageSize, out totalRows).ToArray();
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
    }
}
