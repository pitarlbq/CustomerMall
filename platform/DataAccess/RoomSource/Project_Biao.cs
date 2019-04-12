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
    /// This object represents the properties and methods of a Project_Biao.
    /// </summary>
    public partial class Project_Biao : EntityBase
    {
        public static Project_Biao[] GetProject_BiaoListByChargeID(int ChargeID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[BiaoID] in (select [ChargeBiaoID] from [ChargeSummary_Biao] where [ChargeID]=@ChargeID)");
            conditions.Add("isnull([IsActive],0)=1");
            parameters.Add(new SqlParameter("@ChargeID", ChargeID));
            Project_Biao[] list = GetList<Project_Biao>("select * from [Project_Biao] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
            return list;
        }
        public static Project_Biao[] GetProject_BiaoListByID(List<int> IDList)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            string cmdwhere = string.Empty;
            if (IDList.Count > 0)
            {
                conditions.Add("[ID] in (" + string.Join(",", IDList.ToArray()) + ")");
            }
            Project_Biao[] list = new Project_Biao[] { };
            string cmdText = "select * from [Project_Biao] where " + string.Join(" and ", conditions.ToArray());
            list = GetList<Project_Biao>(cmdText, parameters).ToArray();
            return list;
        }
        public static Project_Biao[] GetProject_BiaoListByBiaoID(List<int> RoomIDList, List<int> ProjectIDList, int ChargeID = 0, int BiaoID = 0, string BiaoCategory = "", string BiaoName = "", string BiaoGuiGe = "", int UserID = 0)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (RoomIDList.Count > 0)
            {
                List<string> cmdlist = ViewRoomFeeHistory.GetRoomIDListConditions(RoomIDList, IncludeRelation: false, RoomIDName: "[ProjectID]");
                conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
            }
            if (ProjectIDList.Count > 0)
            {
                List<string> cmdlist = ViewRoomFeeHistory.GetProjectIDListConditions(ProjectIDList, IncludeRelation: false, RoomIDName: "[ProjectID]", UserID: UserID);
                conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
            }
            Project_Biao[] list = new Project_Biao[] { };
            if (ChargeID > 0)
            {
                parameters.Add(new SqlParameter("@ChargeID", ChargeID));
                conditions.Add("[BiaoID] in (select ChargeBiaoID from ChargeSummary_Biao where ChargeID=@ChargeID)");
            }
            if (BiaoID > 0)
            {
                parameters.Add(new SqlParameter("@BiaoID", BiaoID));
                conditions.Add("[BiaoID]=@BiaoID");
            }
            if (!string.IsNullOrEmpty(BiaoCategory))
            {
                parameters.Add(new SqlParameter("@BiaoCategory", BiaoCategory));
                conditions.Add("[BiaoCategory]=@BiaoCategory");
            }
            if (!string.IsNullOrEmpty(BiaoName))
            {
                parameters.Add(new SqlParameter("@BiaoName", BiaoName));
                conditions.Add("[BiaoName]=@BiaoName");
            }
            if (!string.IsNullOrEmpty(BiaoGuiGe))
            {
                parameters.Add(new SqlParameter("@BiaoGuiGe", BiaoGuiGe));
                conditions.Add("[BiaoGuiGe]=@BiaoGuiGe");
            }
            list = GetList<Project_Biao>("select * from [Project_Biao] where  " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
            return list;
        }
    }
}
