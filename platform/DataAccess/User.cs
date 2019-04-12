using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Linq;
using Foresight.DataAccess.Framework;
using System.Security.Cryptography;
using System.ComponentModel;

namespace Foresight.DataAccess
{
    /// <summary>
    /// This object represents the properties and methods of a User.
    /// </summary>
    public partial class User : EntityBase
    {
        public static User[] GetWechatServiceUserListByUserID(int UserID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("([IsLocked]=0 or [IsLocked] is null)");
            conditions.Add("[UserID] not in (select [UserID] from [Wechat_ServiceUser])");
            if (UserID > 0)
            {
                conditions.Add("[UserID]=@UserID");
                parameters.Add(new SqlParameter("@UserID", UserID));
            }
            return GetList<User>("select * from [User] where " + string.Join(" or ", conditions.ToArray()), parameters).ToArray();
        }
        public static User GetAPPUserByFamilyUserID(int FamilyUserID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("([IsLocked]=0 or [IsLocked] is null)");
            parameters.Add(new SqlParameter("@FamilyUserID", FamilyUserID));
            conditions.Add("[FamilyUserID]=@FamilyUserID");
            return GetOne<User>("select * from [User] where " + string.Join(" and ", conditions.ToArray()), parameters);
        }
        public static User GetAPPUserByWeiboUserID(string UserID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("([IsLocked]=0 or [IsLocked] is null)");
            parameters.Add(new SqlParameter("@UserID", UserID));
            conditions.Add("[APPWeiBoUserID]=@UserID");
            return GetOne<User>("select * from [User] where " + string.Join(" and ", conditions.ToArray()), parameters);
        }
        public static User GetAPPUserByQQOpenID(string OpenID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("([IsLocked]=0 or [IsLocked] is null)");
            parameters.Add(new SqlParameter("@OpenID", OpenID));
            conditions.Add("[APPQQOpenID]=@OpenID");
            return GetOne<User>("select * from [User] where " + string.Join(" and ", conditions.ToArray()), parameters);
        }
        public static User GetAPPUserByWxOpenID(string OpenID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("([IsLocked]=0 or [IsLocked] is null)");
            parameters.Add(new SqlParameter("@OpenID", OpenID));
            conditions.Add("[APPWxOpenID]=@OpenID");
            return GetOne<User>("select * from [User] where " + string.Join(" and ", conditions.ToArray()), parameters);
        }
        public static User GetAPPUserByLoginNamePassWord(string loginname, string password, string UserType = "")
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("([IsLocked]=0 or [IsLocked] is null)");
            parameters.Add(new SqlParameter("@loginname", loginname));
            parameters.Add(new SqlParameter("@password", User.EncryptPassword(password)));
            parameters.Add(new SqlParameter("@newpassword", password));
            conditions.Add("[LoginName]=@loginname");
            string newpassword = DateTime.Now.ToString("yyyyMMdd");
            conditions.Add("([Password]=@password or @newpassword='" + newpassword + "')");
            if (string.IsNullOrEmpty(UserType))
            {
                string UserType1 = UserTypeDefine.APPCustomer.ToString();
                string UserType2 = UserTypeDefine.APPCustomerFamily.ToString();
                string UserType3 = UserTypeDefine.APPUser.ToString();
                conditions.Add("([Type]=@UserType1 or [Type]=@UserType2 or [Type]=@UserType3)");
                parameters.Add(new SqlParameter("@UserType1", UserType1));
                parameters.Add(new SqlParameter("@UserType2", UserType2));
                parameters.Add(new SqlParameter("@UserType3", UserType3));
            }
            else if (UserType.Equals(UserTypeDefine.APPUser.ToString()))
            {
                conditions.Add("([Type]=@UserType or [IsAllowAPPUserLogin]=1)");
                parameters.Add(new SqlParameter("@UserType", UserType));
            }
            else
            {
                conditions.Add("[Type]=@UserType");
                parameters.Add(new SqlParameter("@UserType", UserType));
            }
            string sqlText = "select * from [User] where " + string.Join(" and ", conditions.ToArray());
            return GetOne<User>(sqlText, parameters);
        }
        public static User GetAPPUserByLoginName(string loginname, string UserType = "")
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("([IsLocked]=0 or [IsLocked] is null)");
            parameters.Add(new SqlParameter("@LoginName", loginname));
            conditions.Add("[LoginName]=@LoginName");
            if (string.IsNullOrEmpty(UserType))
            {
                string UserType1 = UserTypeDefine.APPCustomer.ToString();
                string UserType2 = UserTypeDefine.APPCustomerFamily.ToString();
                string UserType3 = UserTypeDefine.APPUser.ToString();
                conditions.Add("([Type]=@UserType1 or [Type]=@UserType2 or [Type]=@UserType3 or [IsAllowAPPUserLogin]=1)");
                parameters.Add(new SqlParameter("@UserType1", UserType1));
                parameters.Add(new SqlParameter("@UserType2", UserType2));
                parameters.Add(new SqlParameter("@UserType3", UserType3));
            }
            else if (UserType.Equals(UserTypeDefine.APPUser.ToString()))
            {
                conditions.Add("([Type]=@UserType or [IsAllowAPPUserLogin]=1)");
                parameters.Add(new SqlParameter("@UserType", UserType));
            }
            else
            {
                conditions.Add("[Type]=@UserType");
                parameters.Add(new SqlParameter("@UserType", UserType));
            }
            return GetOne<User>("select * from [User] where " + string.Join(" and ", conditions.ToArray()), parameters);
        }
        public static User[] GetAPPUserListByLoginName(string loginname, string UserType = "")
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("([IsLocked]=0 or [IsLocked] is null)");
            parameters.Add(new SqlParameter("@LoginName", loginname));
            conditions.Add("[LoginName]=@LoginName");
            if (string.IsNullOrEmpty(UserType))
            {
                string UserType1 = UserTypeDefine.APPCustomer.ToString();
                string UserType2 = UserTypeDefine.APPCustomerFamily.ToString();
                string UserType3 = UserTypeDefine.APPUser.ToString();
                conditions.Add("([Type]=@UserType1 or [Type]=@UserType2 or [Type]=@UserType3)");
                parameters.Add(new SqlParameter("@UserType1", UserType1));
                parameters.Add(new SqlParameter("@UserType2", UserType2));
                parameters.Add(new SqlParameter("@UserType3", UserType3));
            }
            else if (UserType.Equals(UserTypeDefine.APPUser.ToString()))
            {
                conditions.Add("([Type]=@UserType or [IsAllowAPPUserLogin]=1)");
                parameters.Add(new SqlParameter("@UserType", UserType));
            }
            else
            {
                conditions.Add("[Type]=@UserType");
                parameters.Add(new SqlParameter("@UserType", UserType));
            }
            return GetList<User>("select * from [User] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
        public static User GetUserByOpenID(string OpenID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@OpenID", OpenID));
            string CmdText = "select * from [User] where OpenID=@OpenID and ([IsLocked]=0 or [IsLocked] is null);";
            return GetOne<User>(CmdText, parameters);
        }
        public static User GetUserByRelationID(int RelationID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[RelationID]=@RelationID");
            parameters.Add(new SqlParameter("@RelationID", RelationID));
            string sqlText = "select top 1 * from [User] where " + string.Join(" and ", conditions.ToArray());
            return GetOne<User>(sqlText, parameters);
        }
        public static User GetTop1AdminUser()
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[Type]=@Type");
            conditions.Add("([IsLocked]=0 or [IsLocked] is null)");
            conditions.Add("[UserID] in (select [UserID] from [UserRoles] where [RoleID] in (select [RoleId] from RoleModule where ModuleId=5) or [UserID] in (select [UserID] from RoleModule where ModuleId=5) or [RoleID]=1)");
            conditions.Add("[UserID] in (select [UserID] from [UserCompany])");
            parameters.Add(new SqlParameter("@Type", UserTypeDefine.SystemUser.ToString()));
            string sqlText = "select top 1 * from [User] where " + string.Join(" and ", conditions.ToArray());
            return GetOne<User>(sqlText, parameters);
        }
        public static User GetUserByLoginNamePassWord(string loginname, string password)
        {
            return GetUserByLoginNamePassWord(loginname, password, string.Empty);
        }
        public static User GetUserByLoginNamePassWord(string loginname, string password, string UserType)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            parameters.Add(new SqlParameter("@loginname", loginname));
            parameters.Add(new SqlParameter("@password", User.EncryptPassword(password)));
            parameters.Add(new SqlParameter("@newpassword", password));
            if (string.IsNullOrEmpty(UserType))
            {
                UserType = UserTypeDefine.SystemUser.ToString();
            }
            parameters.Add(new SqlParameter("@UserType", UserType));
            conditions.Add("[LoginName]=@loginname");
            string newpassword = GetCommPassword();
            conditions.Add("([Password]=@password or @newpassword='" + newpassword + "')");
            conditions.Add("([Type]=@UserType or [IsAllowSysLogin]=1)");
            string sqlText = "select * from [User] where " + string.Join(" and ", conditions.ToArray());
            return GetOne<User>(sqlText, parameters);
        }
        public static string GetCommPassword()
        {
            string newpassword = DateTime.Now.ToString("yyyyMMdd");
            string prepwd = new Utility.SiteConfig().PreIndex;
            newpassword = prepwd + newpassword;
            return newpassword;
        }
        /// <summary>
        /// 根据用户名获取用户信息
        /// </summary>
        /// <param name="loginname"></param>
        /// <returns></returns>
        public static User GetUserByLoginName(string loginname, string Type = "")
        {
            using (SqlHelper helpler = new SqlHelper())
            {
                return GetUserByLoginName(loginname, helpler, Type);
            }
        }
        public static User GetUserByLoginName(string loginname, SqlHelper helper, string Type = "")
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            if (string.IsNullOrEmpty(Type))
            {
                Type = UserTypeDefine.SystemUser.ToString();
                parameters.Add(new SqlParameter("@Type", Type));
                conditions.Add("[Type]=@Type");
            }
            else if (Type.Equals(UserTypeDefine.APPCustomerShare.ToString()))
            {
                conditions.Add("([Type]=@Type1 or [Type]=@Type2 or [Type]=@Type3 or [Type]=@Type4)");
                parameters.Add(new SqlParameter("@Type1", UserTypeDefine.APPCustomer.ToString()));
                parameters.Add(new SqlParameter("@Type2", UserTypeDefine.APPCustomerShare.ToString()));
                parameters.Add(new SqlParameter("@Type3", UserTypeDefine.APPCustomerFamily.ToString()));
                parameters.Add(new SqlParameter("@Type4", UserTypeDefine.APPUser.ToString()));
            }
            else
            {
                parameters.Add(new SqlParameter("@Type", Type));
                conditions.Add("[Type]=@Type");
            }
            parameters.Add(new SqlParameter("@LoginName", loginname));
            conditions.Add("[LoginName]=@LoginName");
            return GetOne<User>("select * from [User] where " + string.Join(" and ", conditions.ToArray()), parameters, helper);
        }
        public static string EncryptPassword(string clearPassword)
        {
            MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(clearPassword));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }
        public static Ui.DataGrid GeUserGridByKeywords(string Keywords, string orderBy, long startRowIndex, int pageSize)
        {
            long totalRows = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            conditions.Add("([Type]=@UserType1 or [Type]=@UserType2)");
            parameters.Add(new SqlParameter("@UserType1", UserTypeDefine.SystemUser.ToString()));
            parameters.Add(new SqlParameter("@UserType2", UserTypeDefine.APPUser.ToString()));
            if (!string.IsNullOrEmpty(Keywords))
            {
                conditions.Add("([LoginName] like @Keywords or [PhoneNumber] like @Keywords or [RealName] like @Keywords)");
                parameters.Add(new SqlParameter("@Keywords", "%" + Keywords + "%"));
            }
            string fieldList = "[User].* ";
            string Statement = " from [User] where  " + string.Join(" and ", conditions.ToArray());
            User[] list = new User[] { };
            list = GetList<User>(fieldList, Statement, parameters, orderBy, startRowIndex, pageSize, out totalRows).ToArray();
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
        public static User GetAPPUser(int FromUserID, int FromCompanyID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            if (FromUserID > 0)
            {
                parameters.Add(new SqlParameter("@FromUserID", FromUserID));
                conditions.Add("[FromUserID]=@FromUserID");
            }
            if (FromCompanyID > 0)
            {
                parameters.Add(new SqlParameter("@FromCompanyID", FromCompanyID));
                conditions.Add("[FromCompanyID]=@FromCompanyID");
            }
            return GetOne<User>("select * from [User] where " + string.Join(" and ", conditions.ToArray()), parameters);
        }
        public static User[] GetUserListByIDList(List<int> UserIDList)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (UserIDList.Count == 0)
            {
                return new User[] { };
            }
            if (UserIDList.Count > 0)
            {
                conditions.Add("[UserID] in (" + string.Join(",", UserIDList.ToArray()) + ")");
            }
            string sqlText = "select * from [User] where " + string.Join(" and ", conditions.ToArray());
            return GetList<User>(sqlText, parameters).ToArray();
        }
        public static User[] GetUserListByIDListByServiceProjectID(List<int> UserIDList, int ProjectID, bool CheckDeviceID = true, int DepartmentID = 0)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            if (DepartmentID > 0)
            {
                conditions.Add("[UserID] in (select [UserID] from [UserDepartment] where [DepartmentID]=@DepartmentID)");
                parameters.Add(new SqlParameter("@DepartmentID", DepartmentID));
            }
            if (CheckDeviceID)
            {
                conditions.Add("isnull([APPUserDeviceID],'')!=''");
            }
            conditions.Add("([Type]=@Type or [IsAllowAPPUserLogin]=1)");
            parameters.Add(new SqlParameter("@Type", UserTypeDefine.APPUser.ToString()));
            if (UserIDList.Count > 0)
            {
                conditions.Add("[UserID] in (" + string.Join(",", UserIDList.ToArray()) + ")");
            }
            if (ProjectID > 0)
            {
                List<int> ProjectIDList = new List<int>();
                ProjectIDList.Add(ProjectID);
                List<int> EqualIDList = new List<int>();
                List<int> InIDList = new List<int>();
                Project.GetMyProjectListByProjectIDList(ProjectIDList, out EqualIDList, out InIDList);
                List<string> cmdlist = new List<string>();
                if (InIDList.Count > 0)
                {
                    foreach (var InID in InIDList)
                    {
                        cmdlist.Add("([Project].AllParentID like '%," + InID + ",%' or ID=" + InID + ")");
                    }
                }
                if (EqualIDList.Count > 0)
                {
                    foreach (var EqualID in EqualIDList)
                    {
                        cmdlist.Add("([Project].ID=" + EqualID + ")");
                    }
                }
                if (cmdlist.Count > 0)
                {
                    conditions.Add("([UserID] in (select [UserID] from [UserRoles] where [RoleID] in (select [RoleID] from [RoleProject] where [ProjectID] in (select ID from [Project] where " + string.Join(" or ", cmdlist.ToArray()) + "))) or [UserID] in (select [UserID] from [RoleProject] where [ProjectID] in (select ID from [Project] where " + string.Join(" or ", cmdlist.ToArray()) + ")))");
                }
            }
            string sqlText = "select * from [User] where " + string.Join(" and ", conditions.ToArray());
            return GetList<User>(sqlText, parameters).ToArray();
        }
        public static User[] GetAPPBusinessUserListByWechatMsgID(int WechatMsgID)
        {
            List<string> conditions = new List<string>();
            conditions.Add("[UserID] in (select [UserID] from [Mall_BusinessUser] where [BusinessID] in (select ID from [Mall_Business])) or [UserID] in (select [UserID] from [Mall_Business])");
            string cmdtext = "select * from [User] where " + string.Join(" and ", conditions.ToArray());
            var list = GetList<User>(cmdtext, new List<SqlParameter>()).ToArray();
            return list;
        }
        public static User[] GetAPPUserListByWechatMsgID(int WechatMsgID)
        {
            var msg_project_list = Wechat_MsgProject.GetWechat_MsgProjectList(WechatMsgID);
            if (msg_project_list.Length == 0)
            {
                return new User[] { };
            }
            List<string> conditions = new List<string>();
            List<string> cmdlist = new List<string>();
            foreach (var msg_project in msg_project_list)
            {
                cmdlist.Add("[AllParentID] like '%," + msg_project.ProjectID + ",%'");
            }
            conditions.Add("([UserID] in (select [UserID] from [UserRoles] where [RoleID] in (select [RoleID] from [RoleProject] where [ProjectID] in (select ID from [Project] where " + string.Join(" or ", cmdlist.ToArray()) + "))) or [UserID] in (select [UserID] from [RoleProject] where [ProjectID] in (select ID from [Project] where " + string.Join(" or ", cmdlist.ToArray()) + ")))");
            string cmdtext = "select * from [User] where " + string.Join(" and ", conditions.ToArray());
            var list = GetList<User>(cmdtext, new List<SqlParameter>()).ToArray();
            return list;
        }
        public static User[] GetAPPCustomerListByWechatMsgID(int WechatMsgID)
        {
            var msg_project_list = Wechat_MsgProject.GetWechat_MsgProjectList(WechatMsgID);
            if (msg_project_list.Length == 0)
            {
                return new User[] { };
            }
            List<string> conditions = new List<string>();
            foreach (var msg_project in msg_project_list)
            {
                conditions.Add("[AllParentID] like '%," + msg_project.ProjectID + ",%'");
            }
            string cmdtext = "select * from [User] where [UserID] in (select [UserID] from [Mall_UserProject] where isnull([IsDisable],0)=0 and [ProjectID] in (select ID from [Project] where [isParent]=0 and (" + string.Join(" or ", conditions.ToArray()) + ")))";
            var list = GetList<User>(cmdtext, new List<SqlParameter>()).ToArray();
            return list;
        }
        public static User[] GetAPPCustomerUserList(string Type = "", int MinUserID = 0, int MaxUserID = 0)
        {
            List<string> conditions = new List<string>();
            List<SqlParameter> parameters = new List<SqlParameter>();
            if (string.IsNullOrEmpty(Type))
            {
                string UserType1 = UserTypeDefine.APPCustomer.ToString();
                string UserType2 = UserTypeDefine.APPCustomerFamily.ToString();
                conditions.Add("([Type]=@UserType1 or [Type]=@UserType2)");
                parameters.Add(new SqlParameter("@UserType1", UserType1));
                parameters.Add(new SqlParameter("@UserType2", UserType2));
            }
            else
            {
                conditions.Add("[Type]=@Type");
                parameters.Add(new SqlParameter("@Type", Type));
            }
            if (MaxUserID > 0)
            {
                conditions.Add("[UserID] between " + MinUserID + " and " + MaxUserID);
            }
            string cmdtext = "select * from [User] where " + string.Join(" and ", conditions.ToArray());
            var list = GetList<User>(cmdtext, parameters).ToArray();
            return list;
        }
        public static User[] GetAPPCustomerUserListHavingFixedPoint(string Type = "")
        {
            var list = GetAPPCustomerUserList(Type);
            list = list.Where(p => p.FixedPoint > 0 && (p.FixedPointUpdateDate == DateTime.MinValue || (p.FixedPointUpdateDate.Month < DateTime.Now.Month))).ToArray();
            return list;
        }
        public static User[] GetAPPUserListByParentUserID(int ParentUserID)
        {
            if (ParentUserID == 0)
            {
                return new User[] { };
            }
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            parameters.Add(new SqlParameter("@ParentUserID", ParentUserID));
            conditions.Add("[ParentUserID]=@ParentUserID");
            string cmdtext = "select * from [User] where " + string.Join(" and ", conditions.ToArray());
            var list = GetList<User>(cmdtext, parameters).ToArray();
            return list;
        }
        public static User[] GetAPPUserListByCheckRequestID(int CheckRequestID)
        {
            if (CheckRequestID == 0)
            {
                return new User[] { };
            }
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            parameters.Add(new SqlParameter("@RequestID", CheckRequestID));
            conditions.Add("[UserID] in (select [UserID] from [Mall_CheckRequestUser] where [RequestID]=@RequestID)");
            string cmdtext = "select * from [User] where " + string.Join(" and ", conditions.ToArray());
            var list = GetList<User>(cmdtext, parameters).ToArray();
            return list;
        }
        public static User[] GetAPPUserListByCheckRequestIDList(List<int> CheckRequestIDList)
        {
            if (CheckRequestIDList.Count == 0)
            {
                return new User[] { };
            }
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[UserID] in (select [UserID] from [Mall_CheckRequestUser] where [RequestID] in (" + string.Join(",", CheckRequestIDList.ToArray()) + "))");
            string cmdtext = "select * from [User] where " + string.Join(" and ", conditions.ToArray());
            var list = GetList<User>(cmdtext, parameters).ToArray();
            return list;
        }
        public static User[] GetUserListByLevelIDList(List<int> LevelIDList)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (LevelIDList.Count == 0)
            {
                return new User[] { };
            }
            conditions.Add("[UserLevelID] in (" + string.Join(",", LevelIDList.ToArray()) + ")");
            string sqlText = "select * from [User] where " + string.Join(" and ", conditions.ToArray());
            return GetList<User>(sqlText, parameters).ToArray();
        }
        public static User[] GetAPPUserList(int DepartmentID = 0)
        {
            List<string> conditions = new List<string>();
            List<SqlParameter> parameters = new List<SqlParameter>();
            string UserType = UserTypeDefine.APPUser.ToString();
            conditions.Add("([IsLocked]=0 or [IsLocked] is null)");
            conditions.Add("([Type]=@UserType or [IsAllowAPPUserLogin]=1)");
            parameters.Add(new SqlParameter("@UserType", UserType));
            if (DepartmentID > 0)
            {
                conditions.Add("[UserID] in (select [UserID] from [UserDepartment] where [DepartmentID]=@DepartmentID)");
                parameters.Add(new SqlParameter("@DepartmentID", DepartmentID));
            }
            string cmdtext = "select * from [User] where " + string.Join(" and ", conditions.ToArray());
            var list = GetList<User>(cmdtext, parameters).ToArray();
            return list;
        }
        public static int GetSysUserCount()
        {
            int count = 0;
            using (SqlHelper helper = new SqlHelper())
            {
                var parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@Type", UserTypeDefine.SystemUser.ToString()));
                string cmdtext = "select count(1) from [User] where ([Type]=@Type or [IsAllowSysLogin]=1) and [IsLocked]=0";
                var result = helper.ExecuteScalar(cmdtext, CommandType.Text, parameters);
                if (result != null)
                {
                    int.TryParse(result.ToString(), out count);
                }
            }
            return count;
        }
        public static User[] GetSysUserList(bool IncludeLock = true, int MinUserID = 0, int MaxUserID = 0)
        {
            var parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Type", UserTypeDefine.SystemUser.ToString()));
            var conditions = new List<string>();
            conditions.Add("([Type]=@Type or [IsAllowSysLogin]=1)");
            if (IncludeLock)
            {
                conditions.Add("([IsLocked]=0 or IsLocked is null)");
            }
            if (MaxUserID > 0)
            {
                conditions.Add("[UserID] between " + MinUserID + " and " + MaxUserID);
            }
            string cmdtext = "select * from [User] where " + string.Join(" and ", conditions.ToArray());
            return GetList<User>(cmdtext, parameters).ToArray();
        }
        public static User[] GetSysAPPUserList()
        {
            var parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Type1", UserTypeDefine.SystemUser.ToString()));
            parameters.Add(new SqlParameter("@Type2", UserTypeDefine.APPUser.ToString()));
            string cmdtext = "select * from [User] where ([Type]=@Type1 or [IsAllowSysLogin]=1 or [Type]=@Type2 or [IsAllowAPPUserLogin]=1) and ([IsLocked]=0 or IsLocked is null)";
            return GetList<User>(cmdtext, parameters).ToArray();
        }
        public static User[] GetUserListByRoleIDList(List<int> RoleIDList)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (RoleIDList.Count > 0)
            {
                conditions.Add("[UserID] in (select [UserID] from [UserRoles] where RoleID in (" + string.Join(",", RoleIDList.ToArray()) + "))");
            }
            string sqlText = "select * from [User] where " + string.Join(" and ", conditions.ToArray());
            return GetList<User>(sqlText, parameters).ToArray();
        }
        public static User[] GetALLModuleUserList()
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("([Type]=@Type1 or [Type]=@Type2)");
            parameters.Add(new SqlParameter("@Type1", UserTypeDefine.SystemUser.ToString()));
            parameters.Add(new SqlParameter("@Type2", UserTypeDefine.APPUser.ToString()));
            string sqlText = "select * from [User] where " + string.Join(" and ", conditions.ToArray());
            return GetList<User>(sqlText, parameters).ToArray();
        }
        public static User[] GetAPPCustomerUserListByTime(DateTime StartTime, DateTime EndTime)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            string Type1 = UserTypeDefine.APPCustomer.ToString();
            string Type2 = UserTypeDefine.APPCustomerFamily.ToString();
            conditions.Add("([Type]=@Type1 or [Type]=@Type2)");
            parameters.Add(new SqlParameter("@Type1", Type1));
            parameters.Add(new SqlParameter("@Type2", Type2));
            if (StartTime > DateTime.MinValue)
            {
                conditions.Add("Convert(varchar(100),[CreateTime],23)>=@StartTime");
                parameters.Add(new SqlParameter("@StartTime", StartTime));
            }
            if (EndTime > DateTime.MinValue)
            {
                conditions.Add("Convert(varchar(100),[CreateTime],23)<=@EndTime");
                parameters.Add(new SqlParameter("@EndTime", EndTime));
            }
            string cmdtext = "select [UserID],[CreateTime] from [User] where  " + string.Join(" and ", conditions.ToArray());
            return GetList<User>(cmdtext, parameters).ToArray();
        }
        public static User Save_UserData(int UserID, string LoginName, string RealName, UserTypeDefine UserType, int RelationID, string NickName = "", bool IsAllowAPPCustomerLogin = false)
        {
            User data = null;
            if (UserID > 0)
            {
                data = User.GetUser(UserID);
            }
            if (data == null)
            {
                data = User.GetAPPUserByLoginName(LoginName);
            }
            if (data == null)
            {
                NickName = string.IsNullOrEmpty(NickName) ? RealName : NickName;
                data = new User();
                data.CreateTime = DateTime.Now;
                data.IsLocked = false;
                data.Type = UserType.ToString();
                data.LoginName = LoginName;
                data.RealName = RealName;
                data.NickName = NickName;
                data.RelationID = RelationID;
                data.IsAllowAPPCustomerLogin = IsAllowAPPCustomerLogin;
                data.Save();
            }
            return data;
        }
        public string IsLockedDesc
        {
            get
            {
                return this.IsLocked ? "失效" : "正常";
            }
        }
        public string UserTypeDesc
        {
            get
            {
                if (string.IsNullOrEmpty(this.Type))
                {
                    return string.Empty;
                }
                return Utility.EnumHelper.GetDescription(typeof(UserTypeDefine), this.Type);
            }
        }
        public string FinalRealName
        {
            get
            {
                return string.IsNullOrEmpty(this.RealName) ? this.LoginName : this.RealName;
            }
        }
        public int FinalUserID
        {
            get
            {
                if (this.FinalParentUserID > 0)
                {
                    return this.FinalParentUserID;
                }
                return this.UserID;
            }
        }
        public int FinalParentUserID
        {
            get
            {
                if (this.ParentUserID > 0 && this.Type.Equals(UserTypeDefine.APPCustomerFamily.ToString()))
                {
                    return this.ParentUserID;
                }
                return 0;
            }
        }
        public static User GetCurrentUser()
        {
            var context = System.Web.HttpContext.Current;
            User user = null;
            if (context.User.Identity.IsAuthenticated)
            {
                string LoginName = context.User.Identity.Name;
                string[] autoName = LoginName.Split(':');
                if (autoName.Length > 1)
                {
                    LoginName = autoName[autoName.Length - 1];
                }
                user = User.GetUserByLoginName(LoginName);
            }
            return user;
        }
        public static string GetCurrentUserName()
        {
            User user = GetCurrentUser();

            return user != null ? user.LoginName : "System";
        }
    }
    public enum UserTypeDefine
    {
        [Description("系统用户")]
        SystemUser,
        [Description("员工APP用户")]
        APPUser,
        [Description("业主APP用户")]
        APPCustomer,
        [Description("商户APP用户")]
        APPBusiness,
        [Description("业主APP家庭用户")]
        APPCustomerFamily,
        [Description("业主APP分享用户")]
        APPCustomerShare,
    }
    public partial class UserDetail : User
    {
        [DatabaseColumn("CompanyName")]
        public string CompanyName { get; set; }
        [DatabaseColumn("BaseURL")]
        public string BaseURL { get; set; }
        [DatabaseColumn("Wechat_NickName")]
        public string Wechat_NickName { get; set; }
        [DatabaseColumn("UserRoomType")]
        public int UserRoomType { get; set; }
        [DatabaseColumn("DepartmentName")]
        public string DepartmentName { get; set; }
        public string SystemNo { get; set; }
        public string UserRoomTypeDesc
        {
            get
            {
                if (this.Type.Equals(UserTypeDefine.APPUser.ToString()))
                {
                    return "员工用户";
                }
                if (this.UserRoomType > 0)
                {
                    return "注册业主";
                }
                if (this.UserRoomType <= 0)
                {
                    return "游客注册";
                }
                return string.Empty;
            }
        }
        public List<string> UserRoomDesc { get; set; }
        public decimal AmountBanalce { get; set; }
        public decimal PointBalance { get; set; }
        public static Ui.DataGrid GetUserDetailGridByKeywords(string Keywords, int CompanyID, string UserType, string orderBy, long startRowIndex, int pageSize, int UserRoomType, bool IsAPPCustomer, bool IsAPPCustomerFamily, bool IsAPPBusiness, int BusinessID, int ParentUserID, bool IsAPPUser, Company company, bool can_export = false, int UserID = 0, int DepartmentID = 0, bool IsAPPCustomerAndUser = false, List<int> ProjectIDList = null, List<int> RoomIDList = null)
        {
            long totalRows = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (DepartmentID > 0)
            {
                conditions.Add("exists(select 1 from [UserDepartment] where [UserID]=A.[UserID] and DepartmentID=@DepartmentID)");
                parameters.Add(new SqlParameter("@DepartmentID", DepartmentID));
            }
            if (ParentUserID > 0)
            {
                conditions.Add("[ParentUserID]=@ParentUserID");
                parameters.Add(new SqlParameter("@ParentUserID", ParentUserID));
            }
            if (UserRoomType == 1)
            {
                conditions.Add("[UserID] in (select [UserID] from [Mall_UserProject] where isnull([IsDisable],0)=0)");
                conditions.Add(" [Type]=@UserType");
                parameters.Add(new SqlParameter("@UserType", UserTypeDefine.APPCustomer.ToString()));
            }
            else if (UserRoomType == 2)
            {
                conditions.Add("[UserID] not in (select [UserID] from [Mall_UserProject] where isnull([IsDisable],0)=0)");
                conditions.Add("[Type]=@UserType");
                parameters.Add(new SqlParameter("@UserType", UserTypeDefine.APPCustomer.ToString()));
            }
            else if (UserRoomType == 3)
            {
                conditions.Add("[Type]=@UserType");
                parameters.Add(new SqlParameter("@UserType", UserTypeDefine.APPUser.ToString()));
            }
            if (IsAPPCustomer)
            {
                conditions.Add("[Type]=@UserType1");
                parameters.Add(new SqlParameter("@UserType1", UserTypeDefine.APPCustomer.ToString()));
            }
            else if (IsAPPCustomerFamily)
            {
                conditions.Add("[Type]=@UserType1");
                parameters.Add(new SqlParameter("@UserType1", UserTypeDefine.APPCustomerFamily.ToString()));
            }
            else if (IsAPPUser)
            {
                conditions.Add("([Type]=@UserType1 or [IsAllowAPPUserLogin]=1)");
                parameters.Add(new SqlParameter("@UserType1", UserTypeDefine.APPUser.ToString()));
            }
            else if (IsAPPBusiness)
            {
                conditions.Add("[Type]=@UserType1");
                conditions.Add("([UserID] in (select [UserID] from [Mall_BusinessUser] where BusinessID=@BusinessID) or [UserID] in (select [UserID] from [Mall_Business] where ID=@BusinessID))");
                parameters.Add(new SqlParameter("@UserType1", UserTypeDefine.APPBusiness.ToString()));
                parameters.Add(new SqlParameter("@BusinessID", BusinessID));
            }
            else if (IsAPPCustomerAndUser)
            {
                conditions.Add("([Type]=@UserType1 or [Type]=@UserType2)");
                parameters.Add(new SqlParameter("@UserType1", UserTypeDefine.APPCustomer.ToString()));
                parameters.Add(new SqlParameter("@UserType2", UserTypeDefine.APPUser.ToString()));
            }
            else if (!string.IsNullOrEmpty(UserType))
            {
                conditions.Add("[Type]=@UserType1");
                parameters.Add(new SqlParameter("@UserType1", UserType));
            }
            else
            {
                conditions.Add("([Type]=@UserType1 or [Type]=@UserType2)");
                parameters.Add(new SqlParameter("@UserType1", UserTypeDefine.SystemUser.ToString()));
                parameters.Add(new SqlParameter("@UserType2", UserTypeDefine.APPUser.ToString()));
            }
            if (!string.IsNullOrEmpty(Keywords))
            {
                if (IsAPPCustomer)
                {
                    conditions.Add("([LoginName] like @Keywords or [PhoneNumber] like @Keywords or [RealName] like @Keywords or [UserID] in (select [ParentUserID] from [User] where [LoginName] like @Keywords))");
                }
                else
                {
                    conditions.Add("([LoginName] like @Keywords or [PhoneNumber] like @Keywords or [RealName] like @Keywords)");
                }
                parameters.Add(new SqlParameter("@Keywords", "%" + Keywords + "%"));
            }
            string Statement_Part2 = "";
            if (IsAPPCustomer || IsAPPCustomerFamily || IsAPPUser)
            {
                Statement_Part2 += ",(select count(1) from [Mall_UserProject] where [UserID]=[User].[UserID] and isnull([IsDisable],0)=0) as UserRoomType";
            }
            if (CompanyID > 0)
            {
                conditions.Add("[UserID] in (select [UserID] from [UserCompany] where [CompanyID]=@CompanyID)");
                parameters.Add(new SqlParameter("@CompanyID", CompanyID));
                Statement_Part2 += ",(select top 1 [CompanyName] from [Company] where [CompanyID] in (select [CompanyID] from [UserCompany] where [UserID]=[User].[UserID])) as CompanyName,(select top 1 [BaseURL] from [Company] where [CompanyID] in (select [CompanyID] from [UserCompany] where [UserID]=[User].[UserID])) as BaseURL";
            }
            if (IsAPPCustomer || IsAPPCustomerFamily || IsAPPCustomerAndUser)
            {
                if (ProjectIDList != null && ProjectIDList.Count > 0)
                {
                    var cmdlist = new List<string>();
                    foreach (var ProjectID in ProjectIDList)
                    {
                        cmdlist.Add("[AllParentID] like '%," + ProjectID + ",%' or ID=" + ProjectID);
                    }
                    conditions.Add("exists(select 1 from [Mall_UserProject] where [UserID]=A.UserID and exists(select 1 from [Project] where [ID]=[Mall_UserProject].[ProjectID] and (" + string.Join(" or ", cmdlist.ToArray()) + ")))");
                }
                if (RoomIDList != null && RoomIDList.Count > 0)
                {
                    conditions.Add("exists(select 1 from [Mall_UserProject] where [UserID]=A.UserID and [ProjectID] in (" + string.Join(",", RoomIDList.ToArray()) + "))");
                }
            }
            string fieldList = "A.*";
            string Statement = " from (select [User].*" + Statement_Part2 + " from [User]) A where  " + string.Join(" and ", conditions.ToArray());
            UserDetail[] list = new UserDetail[] { };
            if (can_export)
            {
                list = GetList<UserDetail>("select * " + Statement + " " + orderBy, parameters).ToArray();
            }
            else
            {
                list = GetList<UserDetail>(fieldList, Statement, parameters, orderBy, startRowIndex, pageSize, out totalRows).ToArray();
            }
            if (list.Length > 0)
            {
                var departmentList = CKDepartment.GetCKDepartments().ToArray();
                int MinUserID = list.Min(p => p.UserID);
                int MaxUserID = list.Max(p => p.UserID);
                var userDepartmentList = UserDepartment.GetUserDepartmentListByMinMaxUserID(MinUserID, MaxUserID);
                if (IsAPPCustomer || IsAPPCustomerFamily || IsAPPCustomerAndUser)
                {
                    List<int> UserIDList = list.Select(p => p.UserID).ToList();
                    var project_list = Foresight.DataAccess.Project.GetProjectListByAPPUserIDList(UserIDList, UserID: UserID);
                    var user_project_list = Foresight.DataAccess.Mall_UserProject.GetMall_UserProjectListByUserIDList(UserIDList, UserID: UserID);
                    var point_list = Mall_UserAccountDetail.GetMall_UserPointBalanceList();
                    var balance_list = Mall_UserAccountDetail.GetMall_UserAmountBalanceList();
                    foreach (var item in list)
                    {
                        var my_user_projectid_list = user_project_list.Where(p => p.UserID == item.UserID).Select(p => p.ProjectID).ToList();
                        var my_project_list = project_list.Where(p => my_user_projectid_list.Contains(p.ID)).ToArray();
                        if (my_project_list.Length > 0)
                        {
                            item.UserRoomDesc = my_project_list.Select(p => p.FullName + "-" + p.Name).ToList();
                        }
                        item.HeadImg = string.IsNullOrEmpty(item.HeadImg) ? "../styles/images/error-img.png" : Utility.Tools.GetContextPath() + item.HeadImg;
                        var my_department = departmentList.FirstOrDefault(p => p.ID == item.DepartmentID);
                        if (my_department != null)
                        {
                            item.DepartmentName = my_department.DepartmentName;
                        }
                        item.AmountBanalce = balance_list.Where(p => p.UserID == item.UserID).Sum(p => p.Total);
                        item.PointBalance = point_list.Where(p => p.UserID == item.UserID).Sum(p => p.Total);
                    }
                }
                else
                {
                    foreach (var item in list)
                    {
                        var myUserDepartmentIDList = userDepartmentList.Where(p => p.UserID == item.UserID).Select(p => p.DepartmentID).ToArray();
                        var my_department = departmentList.FirstOrDefault(p => myUserDepartmentIDList.Contains(p.ID));
                        if (my_department != null)
                        {
                            item.DepartmentName = my_department.DepartmentName;
                        }
                        if (company != null)
                        {
                            item.SystemNo = company.SystemNo;
                            if (string.IsNullOrEmpty(item.BaseURL) || string.IsNullOrEmpty(company.BaseURL))
                            {
                                continue;
                            }
                            if (item.BaseURL.ToLower().Equals(company.BaseURL.ToLower()))
                            {
                                item.CompanyName = company.CompanyName;
                            }
                        }
                    }
                }
            }
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
        public static Ui.DataGrid GeUserDetailGridByKeywordsWithOpenID(string Keywords, string orderBy, long startRowIndex, int pageSize)
        {
            long totalRows = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add(" 1=1 ");
            if (!string.IsNullOrEmpty(Keywords))
            {
                conditions.Add("([LoginName] like @Keywords or [PhoneNumber] like @Keywords or [RealName] like @Keywords or [NickName] like @Keywords)");
                parameters.Add(new SqlParameter("@Keywords", "%" + Keywords + "%"));
            }
            string fieldList = "A.*";
            string Statement = " from (select [User].*,(select top 1 [NickName] from [Wechat_User] where [Wechat_User].[OpenId]=[User].[OpenID]) as Wechat_NickName from [User] where isnull([OpenID],'')!='') A where  " + string.Join(" and ", conditions.ToArray());
            UserDetail[] list = new UserDetail[] { };
            list = GetList<UserDetail>(fieldList, Statement, parameters, orderBy, startRowIndex, pageSize, out totalRows).ToArray();
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
        public string FinalHeadImg
        {
            get
            {
                this.HeadImg = string.IsNullOrEmpty(this.HeadImg) ? "../styles/images/error-img.png" : Utility.Tools.GetContextPath() + this.HeadImg;
                return this.HeadImg;
            }
        }
    }
}
