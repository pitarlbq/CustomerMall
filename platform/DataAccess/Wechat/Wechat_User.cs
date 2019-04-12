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
    /// This object represents the properties and methods of a Wechat_User.
    /// </summary>
    public partial class Wechat_User : EntityBase
    {
        public static Wechat_User[] GetWechat_UserList(List<int> ProjectIDList = null, List<int> RoomIDList = null)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            string cmdwhere = string.Empty;
            List<string> cmdlist = new List<string>();
            cmdlist.Add("1=1");
            if (ProjectIDList != null && ProjectIDList.Count > 0)
            {
                foreach (var ProjectID in ProjectIDList)
                {
                    cmdlist.Add("([ProjectID] in (select ID from [Project] where [AllParentID] like '%," + ProjectID + ",%' or [ID] =" + ProjectID + "))");
                }
            }
            if (RoomIDList != null && RoomIDList.Count > 0)
            {
                cmdlist.Add("[ProjectID] in (" + string.Join(",", RoomIDList.ToArray()) + ")");
            }
            cmdwhere += " and [OpenId] in (select [OpenID] from [WechatUser_Project] where 1=1 and (" + string.Join(" or ", cmdlist.ToArray()) + "))";
            return GetList<Wechat_User>("select * from [Wechat_User] where 1=1 " + cmdwhere, parameters).ToArray();
        }
        public static Wechat_User GetWechat_UserByUserOpenID(string OpenId)
        {
            using (SqlHelper helper = new SqlHelper())
            {
                return GetWechat_UserByUserOpenid(OpenId, helper);
            }
        }
        public static Wechat_User GetWechat_UserByUserOpenid(string OpenId, SqlHelper helper)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@OpenId", OpenId));
            return GetOne<Wechat_User>("select * from [Wechat_User] where  ltrim(rtrim(OpenId))=ltrim(rtrim(@OpenId))", parameters, helper);
        }
        public static Project GetWechat_UserCurrentProject(string OpenId)
        {
            using (SqlHelper helper = new SqlHelper())
            {
                var data = GetWechat_UserByUserOpenid(OpenId, helper);
                if (data != null && data.CurrentProjectID > 0)
                {
                    var project = Project.GetProject(data.CurrentProjectID, helper);
                    return project;
                }
            }
            return null;
        }
        public static Project SaveWechat_UserCurrentProjectID(string OpenId, int ProjectID)
        {
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    var data = GetWechat_UserByUserOpenid(OpenId, helper);
                    if (data == null)
                    {
                        data = new Wechat_User();
                        data.OpenId = OpenId;
                        data.SubscribeTime = DateTime.Now;
                        data.SubScribe = 1;
                    }
                    data.CurrentProjectID = ProjectID;
                    var project = Project.GetProject(ProjectID, helper);
                    data.Save(helper);
                    helper.Commit();
                    return project;
                }
                catch (Exception)
                {
                    helper.Rollback();
                    return null;
                }
            }
        }
        public string SexDesc
        {
            get
            {
                if (this.Sex < 0)
                {
                    return string.Empty;
                }
                string desc = string.Empty;
                switch (this.Sex)
                {
                    case 2:
                        desc = "女";
                        break;
                    case 1:
                        desc = "男";
                        break;
                    default:
                        break;
                }
                return desc;
            }
        }
        public string UnSubscribeDesc
        {
            get
            {
                if (this.SubScribe < 0)
                {
                    return string.Empty;
                }
                string desc = string.Empty;
                switch (this.SubScribe)
                {
                    case 1:
                        desc = "否";
                        break;
                    case 0:
                        desc = "是";
                        break;
                    default:
                        desc = "是";
                        break;
                }
                return desc;
            }
        }
        public static List<int> GetMyWechatProjectIDList(string wx_openid, out bool HasRoom)
        {
            HasRoom = false;
            List<int> ProjectIDList = Foresight.DataAccess.WechatUser_Project.GetWechatUser_ProjectByOpenid(wx_openid).Select(p => p.ProjectID).ToList();
            if (ProjectIDList.Count > 0)
            {
                HasRoom = true;
            }
            else
            {
                var data = Foresight.DataAccess.Wechat_User.GetWechat_UserByUserOpenID(wx_openid);
                if (data != null && data.CurrentProjectID > 0)
                {
                    ProjectIDList.Add(data.CurrentProjectID);
                }
            }
            return ProjectIDList;
        }
    }
    public partial class Wechat_UserDetail : Wechat_User
    {
        [DatabaseColumn("IsChosen")]
        public int IsChosen { get; set; }
        public static Ui.DataGrid GeWechat_UserGridByKeywords(string Keywords, int Wechat_MsgID, int ChooseState, string orderBy, long startRowIndex, int pageSize)
        {
            long totalRows = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (ChooseState == 1)
            {
                conditions.Add("isnull([IsChosen],0)>0");
            }
            else if (ChooseState == 2)
            {
                conditions.Add("isnull([IsChosen],0)=0");
            }
            if (!string.IsNullOrEmpty(Keywords))
            {
                conditions.Add("([NickName] like @Keywords or [City] like @Keywords or [Province] like @Keywords)");
                parameters.Add(new SqlParameter("@Keywords", "%" + Keywords + "%"));
            }
            parameters.Add(new SqlParameter("@Wechat_MsgID", Wechat_MsgID));
            string fieldList = "A.*";
            string Statement = " from (select Wechat_User.*,(select count(1) from Wechat_MsgUser where [OpenID]=Wechat_User.OpenId and Wechat_MsgID=@Wechat_MsgID) as IsChosen from [Wechat_User])A where  " + string.Join(" and ", conditions.ToArray());
            Wechat_UserDetail[] list = GetList<Wechat_UserDetail>(fieldList, Statement, parameters, orderBy, startRowIndex, pageSize, out totalRows).ToArray();
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
        public string ChooseState
        {
            get
            {
                return this.IsChosen > 0 ? "已选择" : "未选择";
            }
        }
    }
}
