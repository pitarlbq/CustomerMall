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
    /// This object represents the properties and methods of a Project.
    /// </summary>
    public partial class Project : EntityBase
    {
        public static void GetMyProjectListByProjectIDList(List<int> ProjectIDList, out List<int> EqualIDList, out List<int> InIDList)
        {
            EqualIDList = new List<int>();
            InIDList = new List<int>();
            if (ProjectIDList.Count == 0)
            {
                return;
            }
            List<SqlParameter> parameters = new List<SqlParameter>();
            string sqlText = "select * from [Project] where [ID] in (" + string.Join(",", ProjectIDList.ToArray()) + ")";
            var list = GetList<Project>(sqlText, parameters).ToArray();
            if (list.Length > 0)
            {
                List<string> InIDStrList = string.Join("", list.Select(p => p.AllParentID).ToList()).Split(',').ToList();
                var NewEqualIDList = new List<int>();
                foreach (var item in InIDStrList)
                {
                    if (string.IsNullOrEmpty(item))
                    {
                        continue;
                    }
                    int ID = 0;
                    int.TryParse(item, out ID);
                    if (ID > 0 && !NewEqualIDList.Contains(ID))
                    {
                        NewEqualIDList.Add(ID);
                    }
                }
                InIDList = list.Where(p => p.ID != 1 && !NewEqualIDList.Contains(p.ID)).Select(p => p.ID).ToList();
                NewEqualIDList.AddRange(InIDList);
                EqualIDList = NewEqualIDList.Where(ID => ID > 1).Distinct().ToList();
            }
        }
        public static void GetMyProjectListByUserID(int UserID, out List<int> EqualIDList, out List<int> InIDList, List<int> ProjectIDList = null)
        {
            EqualIDList = new List<int>();
            InIDList = new List<int>();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@UserID", UserID));
            string cmdwhere = string.Empty;
            if (ProjectIDList != null && ProjectIDList.Count > 0)
            {
                cmdwhere += " and [ParentID] in (" + string.Join(",", ProjectIDList.ToArray()) + ")";
            }
            string sqlText = "select * from [Project] where [ID] in (select [ProjectID] from [RoleProject] where [UserID] = @UserID or [RoleID] in (select [RoleID] from [UserRoles] where [UserID] = @UserID))" + cmdwhere;
            var list = GetList<Project>(sqlText, parameters).ToArray();
            if (ProjectIDList != null && ProjectIDList.Count > 0)
            {
                sqlText = "select * from [Project] where [ID] in (" + string.Join(",", ProjectIDList.ToArray()) + ")";
                list = GetList<Project>(sqlText, parameters).ToArray();
            }
            if (list.Length > 0)
            {
                List<string> InIDStrList = string.Join("", list.Select(p => p.AllParentID).ToList()).Split(',').ToList();
                var NewEqualIDList = new List<int>();
                foreach (var item in InIDStrList)
                {
                    if (string.IsNullOrEmpty(item))
                    {
                        continue;
                    }
                    int ID = 0;
                    int.TryParse(item, out ID);
                    if (ID > 0 && !NewEqualIDList.Contains(ID))
                    {
                        NewEqualIDList.Add(ID);
                    }
                }
                InIDList = list.Where(p => p.ID != 1 && !NewEqualIDList.Contains(p.ID)).Select(p => p.ID).ToList();
                NewEqualIDList.AddRange(list.Select(p => p.ID).ToList());
                EqualIDList = NewEqualIDList;
            }
        }
        public static Project[] GetSameLevelProjectListByID(int ID, int UserID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<int> EqualIDList = new List<int>();
            List<int> InIDList = new List<int>();
            Project.GetMyProjectListByUserID(UserID, out EqualIDList, out InIDList);
            List<string> cmdlist = new List<string>();
            if (InIDList.Count > 0)
            {
                foreach (var InID in InIDList)
                {
                    cmdlist.Add("([Project].AllParentID like '%," + InID + ",%' or [ID]=" + InID + ")");
                }
            }
            if (EqualIDList.Count > 0)
            {
                foreach (var EqualID in EqualIDList)
                {
                    cmdlist.Add("([Project].ID=" + EqualID + ")");
                }
            }
            string cmdwhere = string.Empty;
            if (cmdlist.Count > 0)
            {
                cmdwhere += " and (" + string.Join(" or ", cmdlist.ToArray()) + ")";
            }
            string cmdtext = "select * from [Project] where [ParentID] in (select [ParentID] from [Project] where [ID]=@ID) " + cmdwhere + ";";
            parameters.Add(new SqlParameter("@ID", ID));
            parameters.Add(new SqlParameter("@UserID", UserID));
            return GetList<Project>(cmdtext, parameters).ToArray();
        }
        public static Project GetSaveLevelProject(int ID, int SortOrder)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@ID", ID));
            parameters.Add(new SqlParameter("@SortOrder", SortOrder));
            return GetOne<Project>("select * from [Project] where [ParentID] = (select [ParentID] from [Project] where [ID]=@ID) and [OrderBy]=@SortOrder and ID=@ID", parameters);
        }
        public static Project[] GetProjectListByOpenid(string OpenID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@OpenID", OpenID));
            return GetList<Project>("select * from [Project] where [ID] in (select [ProjectID] from [WechatUser_Project] where ltrim(rtrim(OpenID))=ltrim(rtrim(@OpenID)))", parameters).ToArray();
        }
        public static Project[] GetTopProjectListByOpenID(string OpenID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@OpenID", OpenID));
            return GetList<Project>("select * from [Project] where ParentID=1 and exists(select 1 from [Project] as Project_1 where Project_1.AllParentID like '%'+Convert(nvarchar(50),Project.ID)+'%' and Project_1.[ID] in (select [ProjectID] from [WechatUser_Project] where ltrim(rtrim(OpenID))=ltrim(rtrim(@OpenID))))", parameters).ToArray();
        }
        public static Project[] GetProjectListByPhoneNumber(string PhoneNumber)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[ID] in (select [RoomID] from RoomPhoneRelation where [RelatePhoneNumber]=@PhoneNumber)");
            parameters.Add(new SqlParameter("@PhoneNumber", PhoneNumber));
            Project[] list = GetList<Project>("SELECT * FROM [Project] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
            return list;
        }
        public static Project[] GetAllChildProjectListByID(int ID)
        {
            List<int> IDList = new List<int>();
            IDList.Add(ID);
            return GetAllChildProjectListByIDs(IDList, 0);
        }
        public static Project[] GetAllChildProjectListByIDs(List<int> ProjectIDList)
        {
            return GetAllChildProjectListByIDs(ProjectIDList, 0);
        }
        public static Project[] GetAllChildProjectListByIDs(List<int> ProjectIDList, int ParentID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (ProjectIDList != null && ProjectIDList.Count > 0)
            {
                List<string> cmdlist = new List<string>();
                foreach (var ProjectID in ProjectIDList)
                {
                    cmdlist.Add("([AllParentID] like '%," + ProjectID + ",%' or [ID] =" + ProjectID + ")");
                }
                conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
            }
            if (ParentID > 0)
            {
                conditions.Add("[ParentID]=@ParentID");
                parameters.Add(new SqlParameter("@ParentID", ParentID));
            }
            Project[] list = GetList<Project>("SELECT * FROM [Project] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
            return list;
        }
        public static Project[] GetAllChildProjectListByEqualInIDList(List<int> EqualProjectIDList, List<int> InProjectIDList, int ParentID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            List<string> cmdlist = new List<string>();
            if (EqualProjectIDList.Count > 0)
            {
                foreach (var ProjectID in EqualProjectIDList)
                {
                    cmdlist.Add("ID=" + ProjectID + "");
                }
            }
            if (InProjectIDList.Count > 0)
            {
                foreach (var ProjectID in InProjectIDList)
                {
                    cmdlist.Add("([AllParentID] like '%," + ProjectID + ",%' or [ID] =" + ProjectID + ")");
                }
            }
            if (cmdlist.Count > 0)
            {
                conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
            }
            if (ParentID > 0)
            {
                conditions.Add("[ParentID]=@ParentID");
                parameters.Add(new SqlParameter("@ParentID", ParentID));
            }
            Project[] list = GetList<Project>("SELECT * FROM [Project] where " + string.Join(" and ", conditions.ToArray()) + " order by [DefaultOrder] asc", parameters).ToArray();
            return list;
        }
        public static Project[] GetProjectListByIDs(List<int> IDList)
        {
            if (IDList.Count == 0)
            {
                return new Project[] { };
            }
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[ID] in (" + string.Join(",", IDList.ToArray()) + ")");
            Project[] list = GetList<Project>("SELECT * FROM [Project] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
            return list;
        }
        public static Project[] GetProjectList(List<int> ProjectIDList, List<int> RoomIDList)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[isParent]=0");
            if (ProjectIDList.Count > 0)
            {
                List<string> cmdlist = new List<string>();
                foreach (var ProjectID in ProjectIDList)
                {
                    cmdlist.Add("([AllParentID] like '%," + ProjectID + ",%' or [ID] =" + ProjectID + ")");
                }
                conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
            }
            if (RoomIDList.Count > 0)
            {
                conditions.Add("[ID] in (" + string.Join(",", RoomIDList.ToArray()) + ")");
            }
            Project[] list = GetList<Project>("SELECT * FROM [Project] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
            return list;
        }
        public static Project[] GetProjectByParentID(int ParentID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[ParentID]=@ParentID");
            parameters.Add(new SqlParameter("@ParentID", ParentID));
            Project[] list = GetList<Project>("SELECT * FROM [Project] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
            return list;
        }
        public static Project[] GetAPPProjectTreeListByParentID(int ParentID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[ParentID]=@ParentID");
            parameters.Add(new SqlParameter("@ParentID", ParentID));
            Project[] list = GetList<Project>("select [ID],[Name],[FullName],[isParent],[TypeDesc] FROM [Project] where " + string.Join(" and ", conditions.ToArray()) + " order by [DefaultOrder] asc", parameters).ToArray();
            return list;
        }
        public static void UpdateAllChildPrintInfo(Project project)
        {
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    string PrintNote = (string.IsNullOrEmpty(project.PrintNote) ? "NULL" : "'" + project.PrintNote + "'");
                    string CuiFeiNote = (string.IsNullOrEmpty(project.CuiFeiNote) ? "NULL" : "'" + project.CuiFeiNote + "'");
                    string PrintCancelNote = (string.IsNullOrEmpty(project.PrintCancelNote) ? "NULL" : "'" + project.PrintCancelNote + "'");
                    string PrintTitle = (string.IsNullOrEmpty(project.PrintTitle) ? "NULL" : "'" + project.PrintTitle + "'");
                    string PrintSubTitle = (string.IsNullOrEmpty(project.PrintSubTitle) ? "NULL" : "'" + project.PrintSubTitle + "'");
                    string PayPrintTitle = (string.IsNullOrEmpty(project.PayPrintTitle) ? "NULL" : "'" + project.PayPrintTitle + "'");
                    string PayPrintSubTitle = (string.IsNullOrEmpty(project.PayPrintSubTitle) ? "NULL" : "'" + project.PayPrintSubTitle + "'");
                    string CuiShouPrintTitle = (string.IsNullOrEmpty(project.CuiShouPrintTitle) ? "NULL" : "'" + project.CuiShouPrintTitle + "'");
                    string CuiShouPrintSubTitle = (string.IsNullOrEmpty(project.CuiShouPrintSubTitle) ? "NULL" : "'" + project.CuiShouPrintSubTitle + "'");
                    string PrintFont = (string.IsNullOrEmpty(project.PrintFont) ? "NULL" : "'" + project.PrintFont + "'");
                    string LogoPath = (string.IsNullOrEmpty(project.LogoPath) ? "NULL" : "'" + project.LogoPath + "'");
                    string PrintType = (string.IsNullOrEmpty(project.PrintType) ? "NULL" : "'" + project.PrintType + "'");
                    string commandText = @"update Project set [PrintNote]=" + PrintNote + ",[CuiFeiNote]=" + CuiFeiNote + ",[PrintCancelNote]=" + PrintCancelNote + ",[PrintTitle]=" + PrintTitle + ",[PrintSubTitle]=" + PrintSubTitle + ",[CuiShouPrintTitle]=" + CuiShouPrintTitle + ",[CuiShouPrintSubTitle]=" + CuiShouPrintSubTitle + ",[PrintFont]=" + PrintFont + ",[IsPrintNote]='" + project.IsPrintNote + "',[IsPrintCount]='" + project.IsPrintCount + "',[PrintWidth]='" + project.PrintWidth + "',[PrintHeight]='" + project.PrintHeight + "',[IsPrintCost]='" + project.IsPrintCost + "',[IsPrintDiscount]='" + project.IsPrintDiscount + "',[IsPrintRoomNo]='" + project.IsPrintRoomNo + "',[LogoPath]=" + LogoPath + ",[PrintType]=" + PrintType + ",[IsPrintTotalRealCost]='" + project.IsPrintTotalRealCost + "',[IsPrintRealCost]='" + project.IsPrintRealCost + "',[IsDefinePrintSize]='" + project.IsDefinePrintSize + "',[PrintTopMargin]='" + project.PrintTopMargin + "',[PrintBottomMargin]='" + project.PrintBottomMargin + "',[PrintTotalLines]='" + project.PrintTotalLines + "',[IsPrintMonthCount]='" + project.IsPrintMonthCount + "',[PayPrintTitle]=" + PayPrintTitle + ",[PayPrintSubTitle]=" + PayPrintSubTitle + ",[LogoWidth]='" + project.LogoWidth + "',[LogoHeight]='" + project.LogoHeight + "',[IsPrintUnitPrice]='" + project.IsPrintUnitPrice + "',[PrintChargeTypeCount]='" + project.PrintChargeTypeCount + "' where [AllParentID] like '%," + project.ID + ",%' or [ID]=" + project.ID;
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    helper.Execute(commandText, CommandType.Text, parameters);
                    helper.Commit();
                }
                catch (Exception)
                {
                    helper.Rollback();
                }
            }
        }
        public static void UpdateAllChildFullName(Project project, string oldFullName, string newFullName)
        {
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    string PrintNote = (string.IsNullOrEmpty(project.PrintNote) ? "NULL" : "'" + project.PrintNote + "'");
                    string CuiFeiNote = (string.IsNullOrEmpty(project.CuiFeiNote) ? "NULL" : "'" + project.CuiFeiNote + "'");
                    string PrintCancelNote = (string.IsNullOrEmpty(project.PrintCancelNote) ? "NULL" : "'" + project.PrintCancelNote + "'");
                    string PrintTitle = (string.IsNullOrEmpty(project.PrintTitle) ? "NULL" : "'" + project.PrintTitle + "'");
                    string PrintSubTitle = (string.IsNullOrEmpty(project.PrintSubTitle) ? "NULL" : "'" + project.PrintSubTitle + "'");
                    string CuiShouPrintTitle = (string.IsNullOrEmpty(project.CuiShouPrintTitle) ? "NULL" : "'" + project.CuiShouPrintTitle + "'");
                    string CuiShouPrintSubTitle = (string.IsNullOrEmpty(project.CuiShouPrintSubTitle) ? "NULL" : "'" + project.CuiShouPrintSubTitle + "'");
                    string PrintFont = (string.IsNullOrEmpty(project.PrintFont) ? "NULL" : "'" + project.PrintFont + "'");
                    string LogoPath = (string.IsNullOrEmpty(project.LogoPath) ? "NULL" : "'" + project.LogoPath + "'");
                    string PrintType = (string.IsNullOrEmpty(project.PrintType) ? "NULL" : "'" + project.PrintType + "'");
                    //REPLACE(REPLACE(REPLACE(REPLACE(OriFullName,@oldName,@newName),'第',''),'楼栋','栋'),'楼层','层')
                    string commandText = @"update Project set OriFullName=REPLACE(OriFullName,@oldName,@newName),FullName=REPLACE(OriFullName,@oldName,@newName),[PrintNote]=" + PrintNote + ",[CuiFeiNote]=" + CuiFeiNote + ",[PrintCancelNote]=" + PrintCancelNote + ",[PrintTitle]=" + PrintTitle + ",[PrintSubTitle]=" + PrintSubTitle + ",[CuiShouPrintTitle]=" + CuiShouPrintTitle + ",[CuiShouPrintSubTitle]=" + CuiShouPrintSubTitle + ",[PrintFont]=" + PrintFont + ",[IsPrintNote]='" + project.IsPrintNote + "',[IsPrintCount]='" + project.IsPrintCount + "',[PrintWidth]='" + project.PrintWidth + "',[PrintHeight]='" + project.PrintHeight + "',[IsPrintCost]='" + project.IsPrintCost + "',[IsPrintDiscount]='" + project.IsPrintDiscount + "',[IsPrintRoomNo]='" + project.IsPrintRoomNo + "',[LogoPath]=" + LogoPath + ",[PrintType]=" + PrintType + ",[IsPrintTotalRealCost]='" + project.IsPrintTotalRealCost + "',[IsPrintRealCost]='" + project.IsPrintRealCost + "',[IsDefinePrintSize]='" + project.IsDefinePrintSize + "',[PrintTopMargin]='" + project.PrintTopMargin + "',[PrintBottomMargin]='" + project.PrintBottomMargin + "',[PrintTotalLines]='" + project.PrintTotalLines + "' where [AllParentID] like '%," + project.ID + ",%' or [ID]=" + project.ID;
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    parameters.Add(new SqlParameter("@ID", project.ID));
                    parameters.Add(new SqlParameter("@oldName", oldFullName));
                    parameters.Add(new SqlParameter("@newName", newFullName));
                    helper.Execute(commandText, CommandType.Text, parameters);
                    helper.Commit();
                }
                catch (Exception)
                {
                    helper.Rollback();
                }
            }
        }
        public static void UpdateAllChildFullName(int ID, string oldName, string newName)
        {
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    string commandText = @"update Project set OriFullName=REPLACE(OriFullName,@oldName,@newName),FullName=REPLACE(OriFullName,@oldName,@newName) where [AllParentID] like '%," + ID + ",%' or [ID]=" + ID;
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    parameters.Add(new SqlParameter("@ID", ID));
                    parameters.Add(new SqlParameter("@oldName", oldName));
                    parameters.Add(new SqlParameter("@newName", newName));
                    helper.Execute(commandText, CommandType.Text, parameters);
                    helper.Commit();
                }
                catch (Exception)
                {
                    helper.Rollback();
                }
            }
        }
        public static Project[] GetChildProjects(int ID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (ID > 0)
            {
                conditions.Add("[ParentID]=@ID");
                parameters.Add(new SqlParameter("@ID", ID));
            }
            Project[] list = GetList<Project>("SELECT * FROM [Project] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
            return list;
        }
        public static Project GetFirstChildProject(int ID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (ID > 0)
            {
                conditions.Add("[ParentID]=@ID");
                parameters.Add(new SqlParameter("@ID", ID));
            }
            return GetOne<Project>("SELECT top 1 * FROM [Project] where " + string.Join(" and ", conditions.ToArray()), parameters);
        }
        public static Project GetMaxProjectByParentID(int ParentID, string TypeDesc, SqlHelper helper)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[ParentID]=@ParentID");
            parameters.Add(new SqlParameter("@ParentID", ParentID));
            if (!string.IsNullOrEmpty(TypeDesc))
            {
                conditions.Add("[TypeDesc]=@TypeDesc");
                parameters.Add(new SqlParameter("@TypeDesc", TypeDesc));
            }
            return GetOne<Project>("select top 1 * from [Project] where " + string.Join(" and ", conditions.ToArray()) + " order by [Level] desc", parameters, helper);
        }
        public static Project[] GetProjectListByParentID(int ID, int ParentID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (ParentID == 1)
            {
                conditions.Add("[ParentID] in (select [ID] from [Project] where [ParentID]=@ID)");
                parameters.Add(new SqlParameter("@ID", ID));
            }
            else
            {
                conditions.Add("[ParentID]=@ID");
                parameters.Add(new SqlParameter("@ID", ID));
            }
            Project[] list = GetList<Project>("SELECT [TypeDesc],[PName],Max([Level]) as [Level] FROM [Project] where " + string.Join(" and ", conditions.ToArray()) + " group by [TypeDesc],[PName]", parameters).ToArray();
            return list;
        }
        public static void DeleteProjectByID(int ID)
        {
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    string commandText = @";with temp
AS ( select ID from Project where ID = @ID
UNION ALL  
select  d.ID from  temp
INNER JOIN Project d ON d.ParentID = temp.ID
)
delete from Project where ID in (select ID from temp)";
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    parameters.Add(new SqlParameter("@ID", ID));
                    helper.Execute(commandText, CommandType.Text, parameters);
                    helper.Commit();
                }
                catch
                {
                    helper.Rollback();
                    throw;
                }
            }
        }
        public static Project GetProjectByName(int ParentID, string ProjectName, SqlHelper helper, out int SortBy)
        {
            SortBy = 1;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            string cmdwhere = string.Empty;
            conditions.Add("[ParentID]=@ID");
            parameters.Add(new SqlParameter("@ID", ParentID));
            cmdwhere += " and [ParentID]=@ID";
            conditions.Add("[Name]=@ProjectName");
            parameters.Add(new SqlParameter("@ProjectName", ProjectName));
            var project = GetOne<Project>("select top 1 * from [Project] where " + string.Join(" and ", conditions.ToArray()) + " order by [DefaultOrder] desc", parameters, helper);
            if (project == null)
            {
                project = GetOne<Project>("select top 1 * from [Project] where 1=1 " + cmdwhere + " order by [DefaultOrder] desc", parameters, helper);
                SortBy = project == null ? SortBy : project.OrderBy;
                return null;
            }
            return project;
        }
        public static Project[] GetAllRoomChild(List<int> IDList)
        {
            string commandText = @";with temp
AS ( select * from Project where ID in (" + string.Join(",", IDList.ToArray()) + @")
UNION ALL  
select  d.* from  temp
INNER JOIN Project d ON d.ParentID = temp.ID
)
select * from [Project] where ID in (select [ID] from temp where [isParent]=0)";
            List<SqlParameter> parameters = new List<SqlParameter>();
            return GetList<Project>(commandText, parameters).ToArray();
        }
        public static Project[] GetAllRoomChild(int ID)
        {
            List<int> IDList = new List<int>();
            IDList.Add(ID);
            return GetAllRoomChild(IDList);
        }
        public static Project GetProjectByFullName(string Name, string FullName, int CompanyID, SqlHelper helper)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[FullName]=@FullName");
            parameters.Add(new SqlParameter("@FullName", FullName));
            conditions.Add("[Name]=@Name");
            parameters.Add(new SqlParameter("@Name", Name));
            return GetOne<Project>("select top 1 * from [Project] where " + string.Join(" and ", conditions.ToArray()) + " order by [ID] desc", parameters, helper);
        }
        public static Project[] GetProjectListByUserID(int UserID, List<int> ProjectIDList)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            List<int> EqualIDList = null;
            List<int> InIDList = null;
            Project.GetMyProjectListByUserID(UserID, out EqualIDList, out InIDList, ProjectIDList: ProjectIDList);
            if (InIDList.Count > 0)
            {
                conditions.Add("ID in (" + string.Join(",", InIDList.ToArray()) + ")");
                return GetList<Project>("select * from [Project] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
            }
            else
            {
                return new Project[] { };
            }
        }
        public static Project[] GetProjectByAPPUserID(int UserID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[ParentID]=1");
            List<int> EqualIDList = new List<int>();
            List<int> InIDList = new List<int>();
            Project.GetMyProjectListByUserID(UserID, out EqualIDList, out InIDList);
            List<string> cmdlist = new List<string>();
            if (InIDList.Count > 0)
            {
                foreach (var InID in InIDList)
                {
                    cmdlist.Add("([Project].AllParentID like '%," + InID + ",%' or [ID]=" + InID + ")");
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
                conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
            }
            conditions.Add(" exists (select * from [ImportFee] where [ChargeStatus]=2 and RoomID in (select ID from [Project] p where p.isParent=0 and p.AllParentID like '%,'+ Convert(nvarchar(100),[Project].ID)+',%'))");
            Project[] list = GetList<Project>("select * from [Project] where " + string.Join(" and ", conditions.ToArray()) + " order by DefaultOrder", parameters).ToArray();
            return list;
        }
        public static Project[] GetProjectListByIconID(int IconID, int UserID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[IconID]=@IconID");
            parameters.Add(new SqlParameter("IconID", IconID));
            parameters.Add(new SqlParameter("@UserID", UserID));
            conditions.Add("[ID] in (select [ProjectID] from [RoleProject] where [UserID]=@UserID or [RoleID] in (select [RoleID] from [UserRoles] where [UserID]=@UserID))");
            Project[] list = GetList<Project>("select * from [Project] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
            return list;
        }
        public static Project[] GetProjectListByPrintID(int PrintID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            parameters.Add(new SqlParameter("PrintID", PrintID));
            conditions.Add("[ID] in (select [RoomID] from [RoomFeeHistory] where [PrintID]=@PrintID)");
            Project[] list = GetList<Project>("select * from [Project] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
            return list;
        }
        public static Project[] GetProjectListByAPPUserID(int UserID, int SelfUserID = 0)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[isParent]=0");
            string cmdwhere = " and ([UserID]=@UserID or [UserID] in (select [UserID] from [User] where [ParentUserID]=@UserID))";
            if (SelfUserID > 0)
            {
                cmdwhere = " and ([UserID]=@UserID or [UserID]=@SelfUserID)";
                parameters.Add(new SqlParameter("@SelfUserID", SelfUserID));
            }
            cmdwhere += " and isnull([IsDisable],0)=0";
            conditions.Add("[ID] in (select [ProjectID] from [Mall_UserProject] where 1=1 " + cmdwhere + ")");
            parameters.Add(new SqlParameter("@UserID", UserID));
            Project[] list = GetList<Project>("select * from [Project] where  " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
            return list;
        }
        public static List<int> GetParentProjectIDListByAPPUserID(int UserID)
        {
            var list = GetProjectListByAPPUserID(UserID);
            if (list.Length == 0)
            {
                return new List<int>();
            }
            List<int> ProjectIDList = new List<int>();
            foreach (var item in list)
            {
                if (string.IsNullOrEmpty(item.AllParentID))
                {
                    continue;
                }
                string[] AllParentIDs = item.AllParentID.Split(',');
                foreach (var AllParentID in AllParentIDs)
                {
                    if (string.IsNullOrEmpty(AllParentID))
                    {
                        continue;
                    }
                    int ParentID = 0;
                    int.TryParse(AllParentID, out ParentID);
                    if (ParentID <= 0)
                    {
                        continue;
                    }
                    if (ProjectIDList.Contains(ParentID))
                    {
                        continue;
                    }
                    ProjectIDList.Add(ParentID);
                }
            }
            return ProjectIDList;
        }
        public static Project[] GetParentProjectListByAPPUserID(int UserID)
        {
            var list = GetProjectListByAPPUserID(UserID);
            if (list.Length == 0)
            {
                return new Project[] { };
            }
            List<int> ProjectIDList = GetParentProjectIDListByAPPUserID(UserID);
            if (ProjectIDList.Count == 0)
            {
                return new Project[] { };
            }
            return GetList<Project>("select * from [Project] where ID in (" + string.Join(",", ProjectIDList.ToArray()) + ")", new List<SqlParameter>()).ToArray();
        }
        public static Project[] GetXiaoQuProjectListByAPPUserID(int UserID)
        {
            var list = GetProjectListByAPPUserID(UserID);
            if (list.Length == 0)
            {
                return new Project[] { };
            }
            string IDs = string.Join(",", list.Select(p => p.AllParentID).ToArray());
            List<string> IDStrList = IDs.Split(',').ToList();
            List<int> IDList = new List<int>();
            foreach (var IDStr in IDStrList)
            {
                if (string.IsNullOrEmpty(IDStr))
                {
                    continue;
                }
                int ID = 0;
                int.TryParse(IDStr, out ID);
                if (IDList.Contains(ID))
                {
                    continue;
                }
                IDList.Add(ID);
            }
            if (IDList.Count == 0)
            {
                return new Project[] { };
            }
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[ParentID]=1");
            conditions.Add("[ID] in (" + string.Join(",", IDList.ToArray()) + ")");
            list = GetList<Project>("select * from [Project] where  " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
            return list;
        }
        public static Project[] GetXiaoQuProjectListByAPPUserIDList(List<int> UserIDList)
        {
            var list = GetProjectListByAPPUserIDList(UserIDList);
            if (list.Length == 0)
            {
                return new Project[] { };
            }
            string IDs = string.Join(",", list.Select(p => p.AllParentID).ToArray());
            List<string> IDStrList = IDs.Split(',').ToList();
            List<int> IDList = new List<int>();
            foreach (var IDStr in IDStrList)
            {
                if (string.IsNullOrEmpty(IDStr))
                {
                    continue;
                }
                int ID = 0;
                int.TryParse(IDStr, out ID);
                if (IDList.Contains(ID))
                {
                    continue;
                }
                IDList.Add(ID);
            }
            if (IDList.Count == 0)
            {
                return new Project[] { };
            }
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[ParentID]=1");
            conditions.Add("[ID] in (" + string.Join(",", IDList.ToArray()) + ")");
            list = GetList<Project>("select * from [Project] where  " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
            return list;
        }
        public static Project[] GetProjectListByAPPUserIDList(List<int> UserIDList, int UserID = 0)
        {
            if (UserIDList.Count == 0)
            {
                return new Project[] { };
            }
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[isParent]=0");
            ViewRoomFeeHistory.CreateTempTable(UserIDList, UserID: UserID);
            string cmdwhere = " and (EXISTS (SELECT 1 FROM [TempIDs] WHERE id=[Mall_UserProject].[UserID] and UserID=" + UserID + ") or [UserID] in (select [UserID] from [User] where EXISTS (SELECT 1 FROM [TempIDs] WHERE id=[User].[ParentUserID] and UserID=" + UserID + ")))";
            cmdwhere += " and isnull([IsDisable],0)=0";
            conditions.Add("[ID] in (select [ProjectID] from [Mall_UserProject] where isnull([IsDisable],0)=0 " + cmdwhere + ")");
            Project[] list = GetList<Project>("select * from [Project] where  " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
            return list;
        }
        public static Project[] GetMyXiaoQuListByMyAPPProjectList(Project[] ProjectList, Project[] MyProjectList)
        {
            if (MyProjectList.Length == 0 || ProjectList.Length == 0)
            {
                return null;
            }
            string IDs = string.Join(",", MyProjectList.Select(p => p.AllParentID).ToArray());
            List<string> IDStrList = IDs.Split(',').ToList();
            List<int> IDList = new List<int>();
            foreach (var IDStr in IDStrList)
            {
                if (string.IsNullOrEmpty(IDStr))
                {
                    continue;
                }
                int ID = 0;
                int.TryParse(IDStr, out ID);
                if (IDList.Contains(ID))
                {
                    continue;
                }
                IDList.Add(ID);
            }
            return ProjectList.Where(p => IDList.Contains(p.ID)).ToArray();
        }
        public static Project[] GetMall_AmountRuleProjectListByAmountRuleID(int AmountRuleID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (AmountRuleID == 0)
            {
                return new Project[] { };
            }
            conditions.Add("ID in (select [ProjectID] from [Mall_AmountRuleProject] where [Mall_AmountRuleID]=@AmountRuleID)");
            parameters.Add(new SqlParameter("@AmountRuleID", AmountRuleID));
            string cmdtext = "select * from [Project] where  " + string.Join(" and ", conditions.ToArray());
            return GetList<Project>(cmdtext, parameters).ToArray();
        }
        public static Project[] GetMall_DoorDeviceProjectListByDoorDeviceIDList(List<int> DoorDeviceIDList)
        {
            if (DoorDeviceIDList.Count == 0)
            {
                return new Project[] { };
            }
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[ID] in (select [ProjectID] from [Mall_DoorDeviceProject] where [DoorDeviceID] in (" + string.Join(",", DoorDeviceIDList.ToArray()) + "))");
            Project[] list = GetList<Project>("select * from [Project] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
            return list;
        }
        public static Project[] GetXiaoQuProjectListBySystemUserID(int UserID)
        {
            var list = GetProjectListByUserID(UserID, null);
            if (list.Length == 0)
            {
                return new Project[] { };
            }
            string IDs = string.Join(",", list.Select(p => p.AllParentID).ToArray());
            List<string> IDStrList = IDs.Split(',').ToList();
            List<int> IDList = new List<int>();
            foreach (var IDStr in IDStrList)
            {
                if (string.IsNullOrEmpty(IDStr))
                {
                    continue;
                }
                int ID = 0;
                int.TryParse(IDStr, out ID);
                if (IDList.Contains(ID))
                {
                    continue;
                }
                IDList.Add(ID);
            }
            if (IDList.Count == 0)
            {
                return new Project[] { };
            }
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[ParentID]=1");
            conditions.Add("[ID] in (" + string.Join(",", IDList.ToArray()) + ")");
            list = GetList<Project>("select * from [Project] where  " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
            return list;
        }
        public static Project GetProjectByRoomPhoneRelationID(int RoomPhoneRelationID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[ID] in (select [RoomID] from [RoomPhoneRelation] where [ID]=@RoomPhoneRelationID)");
            parameters.Add(new SqlParameter("@RoomPhoneRelationID", RoomPhoneRelationID));
            return GetOne<Project>("select * from [Project] where " + string.Join(" and ", conditions.ToArray()), parameters);
        }
        public static Project GetProjectByID(int ID = 0, int ContractID = 0)
        {
            if (ID <= 0 && ContractID <= 0)
            {
                return null;
            }
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            if (ID > 0)
            {
                conditions.Add("[ID]=@ID");
                parameters.Add(new SqlParameter("@ID", ID));
            }
            if (ContractID > 0)
            {
                conditions.Add("exists(select 1 from [Contract_Room] where [RoomID]=[Project].ID and [ContractID]=@ContractID)");
                parameters.Add(new SqlParameter("@ContractID", ContractID));
            }
            return GetOne<Project>("select top 1 * from [Project] where " + string.Join(" and ", conditions.ToArray()), parameters);
        }
        public static Project[] GetProjectListByMinMaxID(int MinID, int MaxID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("isParent=0");
            conditions.Add("ID between " + MinID + " and " + MaxID);
            return GetList<Project>("select * from [Project] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
        public static void SaveProjectPrintFormatData(Project newproject, Project mainproject)
        {
            newproject.PrintTitle = mainproject.PrintTitle;
            newproject.PrintFont = mainproject.PrintFont;
            newproject.IsPrintNote = mainproject.IsPrintNote;
            newproject.IsPrintCount = mainproject.IsPrintCount;
            newproject.PrintWidth = mainproject.PrintWidth;
            newproject.PrintHeight = mainproject.PrintHeight;
            newproject.PrintSubTitle = mainproject.PrintSubTitle;
            newproject.IsPrintCost = mainproject.IsPrintCost;
            newproject.IsPrintDiscount = mainproject.IsPrintDiscount;
            newproject.LogoPath = mainproject.LogoPath;
            newproject.PrintCancelNote = mainproject.PrintCancelNote;
            newproject.CuiShouPrintTitle = mainproject.CuiShouPrintTitle;
            newproject.CuiShouPrintSubTitle = mainproject.CuiShouPrintSubTitle;
            newproject.IsPrintRoomNo = mainproject.IsPrintRoomNo;
            newproject.PrintType = mainproject.PrintType;
            newproject.IsPrintTotalRealCost = mainproject.IsPrintTotalRealCost;
            newproject.IsPrintRealCost = mainproject.IsPrintRealCost;
            newproject.IsDefinePrintSize = mainproject.IsDefinePrintSize;
            newproject.PrintTopMargin = mainproject.PrintTopMargin;
            newproject.PrintBottomMargin = mainproject.PrintBottomMargin;
            newproject.PrintTotalLines = mainproject.PrintTotalLines;
            newproject.IsPrintMonthCount = mainproject.IsPrintMonthCount;
            newproject.PayPrintTitle = mainproject.PayPrintTitle;
            newproject.PayPrintSubTitle = mainproject.PayPrintSubTitle;
            newproject.LogoWidth = mainproject.LogoWidth;
            newproject.LogoHeight = mainproject.LogoHeight;
            newproject.IsPrintUnitPrice = mainproject.IsPrintUnitPrice;
            newproject.PrintChargeTypeCount = mainproject.PrintChargeTypeCount;
        }
    }
    public class ProjectDetails : Project
    {
        [DatabaseColumn("FeeID")]
        public int FeeID { get; set; }

        [DatabaseColumn("CWID")]
        public int CWID { get; set; }

        [DatabaseColumn("CWArea")]
        public int CWArea { get; set; }

        [DatabaseColumn("DXSID")]
        public int DXSID { get; set; }

        [DatabaseColumn("DXSArea")]
        public int DXSArea { get; set; }
        [DatabaseColumn("IsLocked")]
        public bool IsLocked { get; set; }
        [DatabaseColumn("RoleID")]
        public int RoleID { get; set; }
        [DatabaseColumn("OrderNumberID")]
        public int OrderNumberID { get; set; }
        [DatabaseColumn("MsgID")]
        public int MsgID { get; set; }
        [DatabaseColumn("BuildingArea")]
        public decimal BuildingArea { get; set; }
        [DatabaseColumn("ContractArea")]
        public decimal ContractArea { get; set; }
        public static ProjectDetails[] GetRoomFeeByChildRoomID(int RoomID, int FeeID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@RoomID", RoomID));
            parameters.Add(new SqlParameter("@ChargeFeeID", FeeID));
            return GetList<ProjectDetails>(@";with temp
AS ( select * from Project where ID = @RoomID
UNION ALL  
select  d.* from  temp
INNER JOIN Project d ON d.ParentID = temp.ID
)select *,(select top 1 [ID] from [RoomFee] where RoomID=[temp].ID and [ChargeFeeID]=@ChargeFeeID and [IsStart]=1) as FeeID from [temp] where isParent=0", parameters).ToArray();
        }
        public static ProjectDetails[] GetRoomFeeByRoomIDList(List<int> RoomIDList, int FeeID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@ChargeFeeID", FeeID));
            return GetList<ProjectDetails>(@"select *,(select top 1 [ID] from [RoomFee] where RoomID=[Project].ID and [ChargeFeeID]=@ChargeFeeID and [IsStart]=1) as FeeID from [Project] where isParent=0 and ID in (" + string.Join(",", RoomIDList.ToArray()) + ")", parameters).ToArray();
        }
    }
    public class ProjectDetails2 : Project
    {
        [DatabaseColumn("PrintID")]
        public int PrintID { get; set; }
        public static ProjectDetails2[] GetProjectListByPrintIDList(List<int> PrintIDList)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("isnull(Project.[isParent],0)=0");
            if (PrintIDList.Count > 0)
            {
                conditions.Add("Project.[ID] in (select [RoomID] from [RoomFeeHistory] where [PrintID] in (" + string.Join(",", PrintIDList.ToArray()) + "))");
            }
            return GetList<ProjectDetails2>("select Project.*,A.PrintID from [Project] left join (select * from [RoomFeeHistory] where [PrintID] in (" + string.Join(",", PrintIDList.ToArray()) + ")) A on A.RoomID=Project.ID  where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
    }
    public class ProjectDetail3 : Project
    {
        [DatabaseColumn("UserID")]
        public int UserID { get; set; }
        [DatabaseColumn("NickName")]
        public string NickName { get; set; }
        [DatabaseColumn("PhoneNumber")]
        public string PhoneNumber { get; set; }
        [DatabaseColumn("LoginName")]
        public string LoginName { get; set; }
        [DatabaseColumn("ParentUserID")]
        public int ParentUserID { get; set; }
        public string EncriptID
        {
            get
            {
                return Utility.Tools.Encrypt(this.ID.ToString());
            }
        }
        public static Ui.DataGrid GetProjectDetail3GridByKeywords(string Keywords, bool IsShowSubscribe, bool IsShowUnSubscribe, List<int> ProjectIDList, List<int> RoomIDList, string orderBy, long startRowIndex, int pageSize)
        {
            long totalRows = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[isParent]=0");
            if (IsShowSubscribe)
            {
                conditions.Add("isnull([UserID],'')!=''");
            }
            if (IsShowUnSubscribe)
            {
                conditions.Add("isnull([UserID],'')=''");
            }
            if (!string.IsNullOrEmpty(Keywords))
            {
                conditions.Add("([NickName] like @Keywords or [LoginName] like @Keywords or [Name] like @Keywords or [FullName] like @Keywords or [UserID] in (select [ParentUserID] from [User] where [LoginName] like @Keywords))");
                parameters.Add(new SqlParameter("@Keywords", "%" + Keywords + "%"));
            }
            if (ProjectIDList.Count > 0)
            {
                List<string> cmdlist = new List<string>();
                foreach (var ProjectID in ProjectIDList)
                {
                    cmdlist.Add("([AllParentID] like '%," + ProjectID + ",%' or [ID] =" + ProjectID + ")");
                }
                conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
            }
            if (RoomIDList.Count > 0)
            {
                conditions.Add("[ID] in (" + string.Join(",", RoomIDList.ToArray()) + ")");
            }
            string fieldList = "[ViewAPPUserProject].*";
            string Statement = " from (select [Project].*,[User].UserID,[User].NickName,[User].PhoneNumber,[User].LoginName,[User].[ParentUserID] from [Project] left join (select * from [Mall_UserProject] where isnull([IsDisable],0)=0) as Mall_UserProject_1 on Mall_UserProject_1.[ProjectID]=[Project].ID left join [User] on [User].UserID=Mall_UserProject_1.UserID) as [ViewAPPUserProject] where  " + string.Join(" and ", conditions.ToArray());
            ProjectDetail3[] list = GetList<ProjectDetail3>(fieldList, Statement, parameters, orderBy, startRowIndex, pageSize, out totalRows).ToArray();
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
    }
    public class ProjectTree : EntityBaseReadOnly
    {
        [DatabaseColumn("ID")]
        public int ID { get; set; }
        [DatabaseColumn("ParentID")]
        public int ParentID { get; set; }
        [DatabaseColumn("Name")]
        public string Name { get; set; }
        [DatabaseColumn("FullName")]
        public string FullName { get; set; }
        [DatabaseColumn("IconID")]
        public int IconID { get; set; }

        [DatabaseColumn("IsLocked")]
        public bool IsLocked { get; set; }
        [DatabaseColumn("isParent")]
        public bool isParent { get; set; }
        [DatabaseColumn("OrgnizationID")]
        public int OrgnizationID { get; set; }
        [DatabaseColumn("RoleID")]
        public int RoleID { get; set; }
        [DatabaseColumn("OrderNumberID")]
        public int OrderNumberID { get; set; }
        [DatabaseColumn("MsgID")]
        public int MsgID { get; set; }
        [DatabaseColumn("TypeDesc")]
        public string TypeDesc { get; set; }
        [DatabaseColumn("UserID")]
        public int UserID { get; set; }


        public static string ProjectColumns = "[Project].ID,[Project].ParentID,[Project].Name,[Project].FullName,[Project].IconID,[Project].isParent,[Project].TypeDesc";
        public static ProjectTree GetProjectTree(int ID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (ID <= 0)
            {
                return null;
            }
            conditions.Add("[ID]=@ID");
            parameters.Add(new SqlParameter("@ID", ID));
            return GetOne<ProjectTree>("SELECT top 1 [Project].ID,[Project].ParentID,[Project].Name,[Project].FullName,[Project].IconID,[Project].isParent FROM [Project] where " + string.Join(" and ", conditions.ToArray()), parameters);
        }
        public static ProjectTree[] GetProjectTreeListByID(int ID, string Keywords, int UserID, int IconID = 0, bool OnlyXiaoqu = false, bool ExceptRoom = false)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (ExceptRoom)
            {
                conditions.Add("[isParent]=1");
            }
            string sortorder = string.Empty;
            if (UserID > 0)
            {
                List<int> EqualIDList = new List<int>();
                List<int> InIDList = new List<int>();
                Project.GetMyProjectListByUserID(UserID, out EqualIDList, out InIDList);
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
                string cmdwhere = string.Empty;
                if (cmdlist.Count > 0)
                {
                    conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
                }
            }
            if (OnlyXiaoqu)
            {
                conditions.Add("[ParentID]=1");
                if (!string.IsNullOrEmpty(Keywords))
                {
                    parameters.Add(new SqlParameter("@LikeKeywords", "%" + Keywords + "%"));
                    conditions.Add("([Name] like @LikeKeywords)");
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(Keywords))
                {
                    parameters.Add(new SqlParameter("@Keywords", Keywords));
                    parameters.Add(new SqlParameter("@LikeKeywords", "%" + Keywords + "%"));
                    conditions.Add("[isParent]=0");
                    conditions.Add("([Name] like @LikeKeywords or [ID] in (select [RoomID] from [RoomBasic] where [RoomType] like @LikeKeywords) or [ID] in (select [RoomID] from [RoomPhoneRelation] where [RelationName] like @LikeKeywords or [RelatePhoneNumber] like @LikeKeywords))");
                }
                else if (ID > 0)
                {
                    conditions.Add("[ParentID]=@ID");
                    parameters.Add(new SqlParameter("@ID", ID));
                }
                else
                {
                    conditions.Add("[IconID]<=2");
                }
                if (IconID > 0)
                {
                    conditions.Add("[IconID]=@IconID");
                    parameters.Add(new SqlParameter("@IconID", IconID));
                }
            }
            ProjectTree[] list = GetList<ProjectTree>("select " + ProjectColumns + ",(select top 1 [IsLocked] from [RoomBasic] where [RoomBasic].[RoomID]=[Project].[ID]) as IsLocked from [Project] where " + string.Join(" and ", conditions.ToArray()) + " order by DefaultOrder asc", parameters).ToArray();
            return list;
        }
        public static ProjectTree[] GetProjectTreeListByRoleIDAndUserID(int ID, string Keywords, int RoleID, int UserID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (!string.IsNullOrEmpty(Keywords))
            {
                parameters.Add(new SqlParameter("@Keywords", Keywords));
                parameters.Add(new SqlParameter("@LikeKeywords", "%" + Keywords + "%"));
                conditions.Add("[isParent]=0");
                conditions.Add("([Name] like @LikeKeywords or [ID] in (select [RoomID] from [RoomBasic] where [RoomType] like @LikeKeywords or [RoomOwner] like @LikeKeywords or [OwnerPhone] like @LikeKeywords or [RentName] like @LikeKeywords or [RentPhoneNumber] like @LikeKeywords))");
            }
            else if (ID > 0)
            {
                conditions.Add("[ParentID]=@ID");
                parameters.Add(new SqlParameter("@ID", ID));
            }
            else
            {
                conditions.Add("[IconID]<=2");
            }
            string cmdcolumns = string.Empty;
            if (RoleID > 0)
            {
                cmdcolumns += ",(select [RoleID] from [RoleProject] where [RoleProject].[ProjectID]=[Project].[ID] and [RoleID]=@RoleID) as RoleID";
            }
            else
            {
                cmdcolumns += ",0 as RoleID";
            }
            if (UserID > 0)
            {
                cmdcolumns += ",(select [UserID] from [RoleProject] where [RoleProject].[ProjectID]=[Project].[ID] and [UserID]=@UserID) as UserID";
            }
            else
            {
                cmdcolumns += ",0 as UserID";
            }
            parameters.Add(new SqlParameter("@RoleID", RoleID));
            parameters.Add(new SqlParameter("@UserID", UserID));
            ProjectTree[] list = GetList<ProjectTree>("select " + ProjectColumns + cmdcolumns + " from [Project] where " + string.Join(" and ", conditions.ToArray()) + " order by [DefaultOrder] asc", parameters).ToArray();
            return list;
        }
        public static ProjectTree[] GetProjectTreeListByOrderNumberID(int ID, string Keywords, int OrderNumberID, int Level, int UserID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[IconID]<=" + Level);
            if (UserID > 0)
            {
                List<int> EqualIDList = new List<int>();
                List<int> InIDList = new List<int>();
                Project.GetMyProjectListByUserID(UserID, out EqualIDList, out InIDList);
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
                string cmdwhere = string.Empty;
                if (cmdlist.Count > 0)
                {
                    conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
                }
            }
            if (!string.IsNullOrEmpty(Keywords))
            {
                parameters.Add(new SqlParameter("@Keywords", Keywords));
                parameters.Add(new SqlParameter("@LikeKeywords", "%" + Keywords + "%"));
                conditions.Add("[isParent]=0");
                conditions.Add("([Name] like @LikeKeywords or [ID] in (select [RoomID] from [RoomBasic] where [RoomType] like @LikeKeywords or [RoomOwner] like @LikeKeywords or [OwnerPhone] like @LikeKeywords or [RentName] like @LikeKeywords or [RentPhoneNumber] like @LikeKeywords))");
            }
            else if (ID > 0)
            {
                conditions.Add("[ParentID]=@ID");
                parameters.Add(new SqlParameter("@ID", ID));
            }
            parameters.Add(new SqlParameter("@OrderNumberID", OrderNumberID));
            ProjectTree[] list = GetList<ProjectTree>("select " + ProjectColumns + ",(select [OrderNumberID] from [ProjectOrderNumber] where [ProjectOrderNumber].[ProjectID]=[Project].[ID] and [OrderNumberID]=@OrderNumberID) as OrderNumberID from [Project] where " + string.Join(" and ", conditions.ToArray()) + " order by [OrderBy],[Level],[ID]", parameters).ToArray();
            return list;
        }
        public static ProjectTree[] GetProjectTreeListByMsgID(int CompanyID, int MsgID, int UserID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (UserID > 0)
            {
                List<int> EqualIDList = new List<int>();
                List<int> InIDList = new List<int>();
                Project.GetMyProjectListByUserID(UserID, out EqualIDList, out InIDList);
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
                string cmdwhere = string.Empty;
                if (cmdlist.Count > 0)
                {
                    conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
                }
            }
            conditions.Add("([ID]=1 or [ParentID]=1)");
            parameters.Add(new SqlParameter("@MsgID", MsgID));
            ProjectTree[] list = GetList<ProjectTree>("select " + ProjectColumns + ",(select [MsgID] from [Wechat_MsgProject] where [Wechat_MsgProject].[ProjectID]=[Project].[ID] and [MsgID]=@MsgID) as MsgID from [Project] where " + string.Join(" and ", conditions.ToArray()) + " order by [DefaultOrder]", parameters).ToArray();
            return list;
        }
        public static ProjectTree[] GetProjectTreeListByContactID(int CompanyID, int ContactID, int UserID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (UserID > 0)
            {
                List<int> EqualIDList = new List<int>();
                List<int> InIDList = new List<int>();
                Project.GetMyProjectListByUserID(UserID, out EqualIDList, out InIDList);
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
                string cmdwhere = string.Empty;
                if (cmdlist.Count > 0)
                {
                    conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
                }
            }
            conditions.Add("([ID]=1 or [ParentID]=1)");
            parameters.Add(new SqlParameter("@ContactID", ContactID));
            ProjectTree[] list = GetList<ProjectTree>("select " + ProjectColumns + ",(select [WechatContactID] from [Wechat_ContactProject] where [Wechat_ContactProject].[ProjectID]=[Project].[ID] and [WechatContactID]=@ContactID) as MsgID from [Project] where " + string.Join(" and ", conditions.ToArray()) + " order by [DefaultOrder]", parameters).ToArray();
            return list;
        }
        protected override void EnsureParentProperties()
        {
        }

    }
}
