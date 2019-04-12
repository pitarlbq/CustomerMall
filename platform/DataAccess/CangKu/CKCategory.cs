using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;

using Foresight.DataAccess.Framework;
using System.ComponentModel;

namespace Foresight.DataAccess
{
    /// <summary>
    /// This object represents the properties and methods of a CKCategory.
    /// </summary>
    public partial class CKCategory : EntityBase
    {
        public static CKCategory[] SelectChildCategorytByID(int ID)
        {
            List<int> IDList = new List<int>();
            IDList.Add(ID);
            return SelectChildCategorytByID(IDList);
        }
        public static CKCategory[] SelectChildCategorytByID(List<int> IDList)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            string commandText = @";with temp
AS ( select * from CKCategory where ID in (" + string.Join(",", IDList.ToArray()) + @")
UNION ALL  
select  d.* from  temp
INNER JOIN CKCategory d ON d.ParentID = temp.ID
)
select * from temp";
            return GetList<CKCategory>(commandText, parameters).ToArray();
        }
        public static CKCategory[] GetCKCategoryGridByKeywords(string Keywords)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            #region 关键字查询
            string cmd = string.Empty;
            if (!string.IsNullOrEmpty(Keywords))
            {
                conditions.Add("[CategoryName] like @Keywords");
                parameters.Add(new SqlParameter("@Keywords", "%" + Keywords + "%"));
            }
            #endregion
            string Statement = "select * from [CKCategory] where  " + string.Join(" and ", conditions.ToArray()) + cmd;
            CKCategory[] list = GetList<CKCategory>(Statement, parameters).ToArray();
            return list;
        }
        public static CKCategory[] GetCKCategoryListByKeywords(string Keywords, int UserID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("([ParentID]=1 or [ParentID] in (select ID from [CKCategory]))");
            if (!string.IsNullOrEmpty(Keywords))
            {
                conditions.Add("[CategoryName] like @Keywords");
                parameters.Add(new SqlParameter("@Keywords", "%" + Keywords + "%"));
            }
            if (UserID > 0)
            {
                conditions.Add("[ID] in (select [CKCategoryID] from [RoleCKCategory] where [UserID]=@UserID or [RoleID] in (select [RoleID] from [UserRoles] where [UserID]=@UserID))");
                parameters.Add(new SqlParameter("@UserID", UserID));
            }
            return GetList<CKCategory>("select * from [CKCategory] where " + string.Join(" and ", conditions.ToArray()) + " order by [CategoryName] collate Chinese_PRC_CS_AS_KS_WS", parameters).ToArray();
        }
        public string CategoryTypeDesc
        {
            get
            {
                if (string.IsNullOrEmpty(this.CategoryType))
                {
                    return string.Empty;
                }
                return Utility.EnumHelper.GetDescription(typeof(Utility.EnumModel.CKCategoryType), this.CategoryType);
            }
        }
        public static CKCategory[] GetCKCategoriesByParentID(int ParentID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (ParentID > 0)
            {
                conditions.Add("[ParentID]=@ParentID");
                parameters.Add(new SqlParameter("@ParentID", ParentID));
            }
            string Statement = "select * from [CKCategory] where  " + string.Join(" and ", conditions.ToArray());
            CKCategory[] list = GetList<CKCategory>(Statement, parameters).ToArray();
            return list;
        }
    }
    public class CKCategoryDetail : CKCategory
    {
        [DatabaseColumn("RoleID")]
        public int RoleID { get; set; }
        [DatabaseColumn("UserID")]
        public int UserID { get; set; }
        public static CKCategoryDetail[] GetProjectTreeListByID(int ID, string Keywords, int RoleID, int UserID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (!string.IsNullOrEmpty(Keywords))
            {
                parameters.Add(new SqlParameter("@Keywords", Keywords));
                parameters.Add(new SqlParameter("@LikeKeywords", "%" + Keywords + "%"));
                conditions.Add("[isParent]=0");
                conditions.Add("[CategoryName] like @LikeKeywords");
            }
            if (ID > 0)
            {
                conditions.Add("[ParentID]=@ID");
                parameters.Add(new SqlParameter("@ID", ID));
            }
            string cmdcolumns = string.Empty;
            if (RoleID > 0)
            {
                cmdcolumns += ",(select [RoleID] from [RoleCKCategory] where [RoleCKCategory].[CKCategoryID]=[CKCategory].[ID] and [RoleID]=@RoleID) as RoleID";
                parameters.Add(new SqlParameter("@RoleID", RoleID));
            }
            else
            {
                cmdcolumns += ",0 as RoleID";
            }
            if (UserID > 0)
            {
                cmdcolumns += ",(select [UserID] from [RoleCKCategory] where [RoleCKCategory].[CKCategoryID]=[CKCategory].[ID] and [UserID]=@UserID) as UserID";
                parameters.Add(new SqlParameter("@UserID", UserID));
            }
            else
            {
                cmdcolumns += ",0 as UserID";
            }
            CKCategoryDetail[] list = GetList<CKCategoryDetail>("select * " + cmdcolumns + " from [CKCategory] where " + string.Join(" and ", conditions.ToArray()) + " order by [CategoryName] collate Chinese_PRC_CS_AS_KS_WS", parameters).ToArray();
            return list;
        }
    }
}
