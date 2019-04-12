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
    /// This object represents the properties and methods of a Wechat_Contact.
    /// </summary>
    public partial class Wechat_Contact : EntityBase
    {
        public static Wechat_Contact GetWechat_ContactByPhoneType(string PhoneType)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (!string.IsNullOrEmpty(PhoneType))
            {
                conditions.Add("[PhoneType]=@PhoneType");
                parameters.Add(new SqlParameter("@PhoneType", PhoneType));
            }
            return GetOne<Wechat_Contact>("select top 1 * from [Wechat_Contact] where  " + string.Join(" and ", conditions.ToArray()) + " order by ID desc", parameters);
        }
        public static Wechat_Contact[] GetWechat_ContactListByMsgPhoneType(string PhoneType, List<int> ProjectIDList = null, int UserID = 0)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            List<string> conditions2 = new List<string>();
            conditions.Add("1=1");
            conditions2.Add("1=1");
            if (ProjectIDList != null && ProjectIDList.Count > 0)
            {
                List<int> EqualIDList = new List<int>();
                List<int> InIDList = new List<int>();
                Project.GetMyProjectListByProjectIDList(ProjectIDList, out EqualIDList, out InIDList);
                if (EqualIDList.Count > 0)
                {
                    List<string> cmdlist = ViewRoomFeeHistory.GetProjectIDListConditions(EqualIDList, IncludeRelation: false, RoomIDName: "[ProjectID]", UserID: UserID);
                    conditions.Add("([ID] in (select [WechatContactID] from [Wechat_ContactProject] where (" + string.Join(" or ", cmdlist.ToArray()) + ")))");
                }
            }
            if (!string.IsNullOrEmpty(PhoneType))
            {
                conditions.Add("[PhoneType]=@PhoneType");
                parameters.Add(new SqlParameter("@PhoneType", PhoneType));
                conditions2.Add("[PhoneType]=@PhoneType");
            }
            else
            {
                conditions.Add("isnull([PhoneType],'')!=@PhoneType");
                parameters.Add(new SqlParameter("@PhoneType", PhoneType));
                conditions2.Add("isnull([PhoneType],'')!=@PhoneType");
            }
            string cmdtext = "select * from [Wechat_Contact] where  " + string.Join(" and ", conditions.ToArray()) + " order by ID desc";
            var list = GetList<Wechat_Contact>(cmdtext, parameters).ToArray();
            if (list.Length > 0)
            {
                return list;
            }
            return GetList<Wechat_Contact>("select * from [Wechat_Contact] where  " + string.Join(" and ", conditions2.ToArray()) + " order by ID desc", parameters).ToArray();
        }
    }
    public partial class Wechat_ContactDetail : Wechat_Contact
    {
        [DatabaseColumn("CategoryName")]
        public string CategoryName { get; set; }
        public static Ui.DataGrid GetWechat_ContactGridByKeywords(string Keywords, string orderBy, long startRowIndex, int pageSize, List<int> EqualProjectIDList = null, string PhoneType = "")
        {
            long totalRows = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (EqualProjectIDList != null && EqualProjectIDList.Count > 0)
            {
                List<string> cmdlist = new List<string>();
                cmdlist.Add("exists (select 1 from [Wechat_ContactProject] where [WechatContactID]=Wechat_Contact.ID and [ProjectID] in (" + string.Join(",", EqualProjectIDList.ToArray()) + "))");
                cmdlist.Add("exists (select 1 from [Wechat_ContactProject] where [WechatContactID]=Wechat_Contact.ID and not exists (select 1 from Project where ID=Wechat_ContactProject.[ProjectID] and ID!=1))");
                cmdlist.Add("not exists (select 1 from [Wechat_ContactProject] where [WechatContactID]=Wechat_Contact.ID and [ProjectID]!=1)");
                conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
            }
            if (!string.IsNullOrEmpty(Keywords))
            {
                conditions.Add("([Name] like @Keywords or [PhoneNumber] like @Keywords or [Remark] like @Keywords)");
                parameters.Add(new SqlParameter("@Keywords", "%" + Keywords + "%"));
            }
            if (!string.IsNullOrEmpty(PhoneType))
            {
                conditions.Add("[PhoneType]=@PhoneType");
                parameters.Add(new SqlParameter("@PhoneType", PhoneType));
            }
            else
            {
                conditions.Add("isnull([PhoneType],'')!=@PhoneType");
                parameters.Add(new SqlParameter("@PhoneType", Utility.EnumModel.WechatContactType.hujiaowuye.ToString()));
            }
            string fieldList = "[Wechat_Contact].* ";
            string Statement = " from [Wechat_Contact] where  " + string.Join(" and ", conditions.ToArray());
            Wechat_ContactDetail[] list = GetList<Wechat_ContactDetail>(fieldList, Statement, parameters, orderBy, startRowIndex, pageSize, out totalRows).ToArray();
            var categorys = Wechat_ContactCategory.GetWechat_ContactCategories();
            foreach (var item in list)
            {
                if (item.PhoneType.Equals(Utility.EnumModel.WechatContactType.hujiaowuye.ToString()))
                {
                    item.CategoryName = "呼叫物业";
                }
                else
                {
                    var my_category = categorys.FirstOrDefault(p => p.ID == item.CategoryID);
                    item.CategoryName = my_category != null ? my_category.Name : string.Empty;
                }
            }
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
        public static Wechat_ContactDetail[] GetWechat_ContactDetailListByMsgPhoneType(string PhoneType, List<int> ProjectIDList = null, int UserID = 0)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            List<string> conditions2 = new List<string>();
            conditions.Add("1=1");
            conditions2.Add("1=1");
            if (ProjectIDList != null && ProjectIDList.Count > 0)
            {
                List<int> EqualIDList = new List<int>();
                List<int> InIDList = new List<int>();
                Project.GetMyProjectListByProjectIDList(ProjectIDList, out EqualIDList, out InIDList);
                if (EqualIDList.Count > 0)
                {
                    List<string> cmdlist = new List<string>();
                    cmdlist.Add("exists (select 1 from [Wechat_ContactProject] where [WechatContactID]=Wechat_Contact.ID and [ProjectID] in (" + string.Join(",", EqualIDList.ToArray()) + "))");
                    cmdlist.Add("exists (select 1 from [Wechat_ContactProject] where [WechatContactID]=Wechat_Contact.ID and not exists (select 1 from Project where ID=Wechat_ContactProject.[ProjectID] and ID!=1))");
                    cmdlist.Add("not exists (select 1 from [Wechat_ContactProject] where [WechatContactID]=Wechat_Contact.ID and [ProjectID]!=1)");
                    conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
                }
            }
            if (!string.IsNullOrEmpty(PhoneType))
            {
                conditions.Add("[PhoneType]=@PhoneType");
                conditions2.Add("[PhoneType]=@PhoneType");
                parameters.Add(new SqlParameter("@PhoneType", PhoneType));
            }
            else
            {
                conditions.Add("isnull([PhoneType],'')!=@PhoneType");
                conditions2.Add("isnull([PhoneType],'')!=@PhoneType");
                parameters.Add(new SqlParameter("@PhoneType", Utility.EnumModel.WechatContactType.hujiaowuye.ToString()));
            }
            string cmdtext = "select * from [Wechat_Contact] where  " + string.Join(" and ", conditions.ToArray()) + " order by ID desc";
            var list = GetList<Wechat_ContactDetail>(cmdtext, parameters).ToArray();
            if (list.Length == 0)
            {
                list = GetList<Wechat_ContactDetail>("select * from [Wechat_Contact] where  " + string.Join(" and ", conditions2.ToArray()) + " order by ID desc", parameters).ToArray();
            }
            if (list.Length > 0)
            {
                var categorys = Wechat_ContactCategory.GetWechat_ContactCategories();
                foreach (var item in list)
                {
                    if (item.PhoneType.Equals(Utility.EnumModel.WechatContactType.hujiaowuye.ToString()))
                    {
                        item.CategoryName = "呼叫物业";
                    }
                    else
                    {
                        var my_category = categorys.FirstOrDefault(p => p.ID == item.CategoryID);
                        item.CategoryName = my_category != null ? my_category.Name : string.Empty;
                    }
                }
            }
            return list;
        }
    }
}
