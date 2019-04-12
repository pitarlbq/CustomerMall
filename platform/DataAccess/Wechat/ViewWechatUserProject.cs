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
    /// This object represents the properties and methods of a ViewWechatUserProject.
    /// </summary>
    public partial class ViewWechatUserProject : EntityBaseReadOnly
    {
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
        public static Ui.DataGrid GeViewWechatUserProjectGridByKeywords(string Keywords, bool IsShowSubscribe, bool IsShowUnSubscribe, List<int> ProjectIDList, List<int> RoomIDList, string orderBy, long startRowIndex, int pageSize)
        {
            long totalRows = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[isParent]=0");
            if (IsShowSubscribe)
            {
                conditions.Add("isnull([OpenId],'')!=''");
            }
            if (IsShowUnSubscribe)
            {
                conditions.Add("isnull([OpenId],'')=''");
            }
            if (!string.IsNullOrEmpty(Keywords))
            {
                conditions.Add("([NickName] like @Keywords or [Name] like @Keywords or [FullName] like @Keywords)");
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
            string fieldList = "[ViewWechatUserProject].*";
            string Statement = " from [ViewWechatUserProject] where  " + string.Join(" and ", conditions.ToArray());
            ViewWechatUserProject[] list = GetList<ViewWechatUserProject>(fieldList, Statement, parameters, orderBy, startRowIndex, pageSize, out totalRows).ToArray();
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
    }
}
