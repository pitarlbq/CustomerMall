using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Linq;
using Foresight.DataAccess.Framework;

namespace Foresight.DataAccess
{
    /// <summary>
    /// This object represents the properties and methods of a Mall_UserProject.
    /// </summary>
    public partial class Mall_UserProject : EntityBase
    {
        public static Mall_UserProject[] GetMall_UserProjectListByUserID_ProjectID(int UserID, int ProjectID = 0, int SelfUserID = 0)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("isnull([IsDisable],0)=0");
            if (ProjectID > 0)
            {
                conditions.Add("[ProjectID] = @ProjectID");
                parameters.Add(new SqlParameter("@ProjectID", ProjectID));
            }
            if (SelfUserID > 0)
            {
                conditions.Add("([UserID] = @UserID or [UserID]=@SelfUserID)");
                parameters.Add(new SqlParameter("@SelfUserID", SelfUserID));
            }
            else
            {
                conditions.Add("[UserID] = @UserID");
            }
            parameters.Add(new SqlParameter("@UserID", UserID));
            string sqlText = "select * from [Mall_UserProject] where " + string.Join(" and ", conditions.ToArray());
            return GetList<Mall_UserProject>(sqlText, parameters).ToArray();
        }
        public static Mall_UserProject[] GetMall_UserProjectListByUserID(int UserID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@UserID", UserID));
            string sqlText = "select * from [Mall_UserProject] where [UserID] = @UserID and isnull([IsDisable],0)=0";
            return GetList<Mall_UserProject>(sqlText, parameters).ToArray();
        }
        public static Mall_UserProject[] GetMall_UserProjectListByUserIDList(List<int> UserIDList, int UserID = 0)
        {
            if (UserIDList.Count == 0)
            {
                return new Mall_UserProject[] { };
            }
            List<SqlParameter> parameters = new List<SqlParameter>();
            ViewRoomFeeHistory.CreateTempTable(UserIDList, UserID: UserID);
            string sqlText = "select * from [Mall_UserProject] where EXISTS (SELECT 1 FROM [TempIDs] WHERE id=[Mall_UserProject].[UserID] and UserID=" + UserID + ") and isnull([IsDisable],0)=0";
            return GetList<Mall_UserProject>(sqlText, parameters).ToArray();
        }
        public static Mall_UserProject[] GetMall_UserProjectListByProjectIDList(List<int> ProjectIDList)
        {
            if (ProjectIDList.Count == 0)
            {
                return new Mall_UserProject[] { };
            }
            List<SqlParameter> parameters = new List<SqlParameter>();
            string sqlText = "select * from [Mall_UserProject] where [ProjectID] in (" + string.Join(",", ProjectIDList.ToArray()) + ") and isnull([IsDisable],0)=0";
            return GetList<Mall_UserProject>(sqlText, parameters).ToArray();
        }
        public static List<int> GetMyUserProjectIDList(RoomPhoneRelation[] phone_list, int UserID)
        {
            if (UserID <= 0)
            {
                return new List<int>();
            }
            Mall_UserProject[] user_project_list = new Mall_UserProject[] { };
            if (phone_list.Length > 0)
            {
                user_project_list = Mall_UserProject.GetMall_UserProjectListByProjectIDList(phone_list.Select(p => p.RoomID).ToList());
            }
            return user_project_list.Where(p => p.UserID == UserID).Select(p => p.ProjectID).ToList();
        }
        public static void Insert_UserProjectList(RoomPhoneRelation[] phone_list, User user)
        {
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    Insert_UserProjectList(phone_list, user, helper);
                    helper.Commit();
                }
                catch (Exception)
                {
                    helper.Rollback();
                }
            }
        }
        public static void Insert_UserProjectList(RoomPhoneRelation[] phone_list, User user, SqlHelper helper)
        {
            var parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@UserID", user.FinalUserID));
            helper.Execute("delete from [Mall_UserProject] where [UserID]=@UserID and isnull([IsManualAdd],0)=0 and isnull([IsDisable],0)=0", CommandType.Text, parameters);
            foreach (var item in phone_list)
            {
                if (item.RelatePhoneNumber.Equals(user.LoginName))
                {
                    item.UserID = user.UserID;
                    item.Save(helper);
                }
                var my_user_project = Mall_UserProject.GetMall_UserProject(user.FinalUserID, item.RoomID, helper);
                if (my_user_project == null)
                {
                    my_user_project = new Mall_UserProject();
                }
                my_user_project.IsManualAdd = false;
                my_user_project.UserID = user.FinalUserID;
                my_user_project.ProjectID = item.RoomID;
                my_user_project.Save(helper);
            }
        }
        public static Mall_UserProject[] GetMall_UserProjectListHavingOrders()
        {
            string cmdtext = "select * from [Mall_UserProject] where [UserID] in (select [UserID] from Mall_Order where ProductTypeID!=10) and isnull([IsDisable],0)=0";
            Mall_UserProject[] list = GetList<Mall_UserProject>(cmdtext, new List<SqlParameter>()).ToArray();
            return list;
        }
        public static Mall_UserProject[] GetMall_UserProjectListByMinMaxUserID(int MinUserID = 0, int MaxUserID = 0)
        {
            List<string> conditions = new List<string>();
            List<SqlParameter> parameters = new List<SqlParameter>();
            if (MaxUserID <= 0)
            {
                return new Mall_UserProject[] { };
            }
            conditions.Add("[UserID] between " + MinUserID + " and " + MaxUserID);
            string cmdtext = "select * from [Mall_UserProject] where " + string.Join(" and ", conditions.ToArray());
            var list = GetList<Mall_UserProject>(cmdtext, parameters).ToArray();
            return list;
        }
    }
}
