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
    /// This object represents the properties and methods of a Wechat_Msg.
    /// </summary>
    public partial class Wechat_Msg : EntityBase
    {
        public static Ui.DataGrid GeWechat_MsgGridByKeywords(string Keywords, string MsgType, string orderBy, long startRowIndex, int pageSize, int type, int msgtypeid, List<int> EqualProjectIDList = null)
        {
            long totalRows = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (EqualProjectIDList != null && EqualProjectIDList.Count > 0)
            {
                List<string> cmdlist = new List<string>();
                cmdlist.Add("exists (select 1 from [Wechat_MsgProject] where [MsgID]=Wechat_Msg.ID and [ProjectID] in (" + string.Join(",", EqualProjectIDList.ToArray()) + "))");
                cmdlist.Add("exists (select 1 from [Wechat_MsgProject] where [MsgID]=Wechat_Msg.ID and not exists (select 1 from Project where ID=Wechat_MsgProject.[ProjectID] and ID!=1))");
                cmdlist.Add("not exists (select 1 from [Wechat_MsgProject] where [MsgID]=Wechat_Msg.ID and [ProjectID]!=1)");
                conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
            }
            if (type == 1)
            {
                conditions.Add("([IsWechatSend]=1 or ([IsWechatSend] is null and [IsCustomerAPPSend] is null and [IsUserAPPSend] is null))");
            }
            if (type == 2 || type == 3)
            {
                conditions.Add("([IsCustomerAPPSend]=1 or [IsUserAPPSend]=1)");
            }
            if (msgtypeid == 1)
            {
                conditions.Add("[MsgType]=@MsgType");
                parameters.Add(new SqlParameter("@MsgType", Utility.EnumModel.WechatMsgType.tongzhi.ToString()));
            }
            if (msgtypeid == 2)
            {
                conditions.Add("[MsgType]=@MsgType");
                parameters.Add(new SqlParameter("@MsgType", Utility.EnumModel.WechatMsgType.huodong.ToString()));
            }
            if (msgtypeid == 3)
            {
                conditions.Add("[MsgType]=@MsgType");
                parameters.Add(new SqlParameter("@MsgType", Utility.EnumModel.WechatMsgType.news.ToString()));
            }
            if (!string.IsNullOrEmpty(Keywords))
            {
                conditions.Add("([MsgTitle] like @Keywords or [MsgContent] like @Keywords or [MsgSummary] like @Keywords)");
                parameters.Add(new SqlParameter("@Keywords", "%" + Keywords + "%"));
            }
            if (!string.IsNullOrEmpty(MsgType))
            {
                conditions.Add("[MsgType]=@MsgType");
                parameters.Add(new SqlParameter("@MsgType", MsgType));
            }
            string fieldList = "[Wechat_Msg].*";
            string Statement = " from [Wechat_Msg] where  " + string.Join(" and ", conditions.ToArray());
            Wechat_Msg[] list = GetList<Wechat_Msg>(fieldList, Statement, parameters, orderBy, startRowIndex, pageSize, out totalRows).ToArray();
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
        public static Wechat_Msg[] GetWechat_MsgListByMsgType(string MsgType, long startRowIndex, int pageSize, out long totalRows, bool IsWechatSend = false, bool IsUserAPPSend = false, bool IsCustomerAPPSend = false, bool IsBusinessAPPSend = false, int CategoryID = 0, List<int> ProjectIDList = null, int UserID = 0)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            string orderby = "order by [IsTopShow] desc ,isnull([SortOrder],999999) asc,[PublishTime] desc";
            conditions.Add("[IsShow]=1");
            conditions.Add("(isnull([StartTime],getdate())<=getdate() and isnull([EndTime],getdate())>=getdate())");
            if (ProjectIDList != null && ProjectIDList.Count > 0)
            {
                List<int> EqualIDList = new List<int>();
                List<int> InIDList = new List<int>();
                Project.GetMyProjectListByProjectIDList(ProjectIDList, out EqualIDList, out InIDList);
                if (EqualIDList.Count > 0)
                {
                    List<string> cmdlist = new List<string>();
                    cmdlist.Add("exists (select 1 from [Wechat_MsgProject] where [MsgID]=Wechat_Msg.ID and [ProjectID] in (" + string.Join(",", EqualIDList.ToArray()) + "))");
                    cmdlist.Add("exists (select 1 from [Wechat_MsgProject] where [MsgID]=Wechat_Msg.ID and not exists (select 1 from Project where ID=Wechat_MsgProject.[ProjectID] and ID!=1))");
                    cmdlist.Add("not exists (select 1 from [Wechat_MsgProject] where [MsgID]=Wechat_Msg.ID and [ProjectID]!=1)");

                    conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
                }
            }
            if (CategoryID > 0)
            {
                conditions.Add("[CategoryID]=@CategoryID");
                parameters.Add(new SqlParameter("@CategoryID", CategoryID));
            }
            if (!string.IsNullOrEmpty(MsgType))
            {
                conditions.Add("[MsgType]=@MsgType");
                parameters.Add(new SqlParameter("@MsgType", MsgType));
            }
            if (IsWechatSend)
            {
                conditions.Add("[IsWechatSend]=1");
            }
            if (IsUserAPPSend)
            {
                conditions.Add("[IsUserAPPSend]=1");
            }
            if (IsCustomerAPPSend)
            {
                conditions.Add("[IsCustomerAPPSend]=1");
            }
            if (IsBusinessAPPSend)
            {
                conditions.Add("[IsBusinessAPPSend]=1");
            }
            string fieldList = "[Wechat_Msg].*";
            string Statement = " from [Wechat_Msg] where " + string.Join(" and ", conditions.ToArray());
            var list = GetList<Wechat_Msg>(fieldList, Statement, parameters, orderby, startRowIndex, pageSize, out totalRows).ToArray();
            return list;
        }
        public string MsgTypeDesc
        {
            get
            {
                if (string.IsNullOrEmpty(this.MsgType))
                {
                    return string.Empty;
                }
                return Utility.EnumHelper.GetDescription(typeof(Utility.EnumModel.WechatMsgType), this.MsgType);
            }
        }
        public string IsShowDesc
        {
            get
            {
                return this.IsShow ? "显示" : "不显示";
            }
        }
        public string IsWechatSendDesc
        {
            get
            {
                return this.IsWechatSend ? "显示" : "不显示";
            }
        }
        public string IsCustomerAPPSendDesc
        {
            get
            {
                return this.IsCustomerAPPSend ? "显示" : "不显示";
            }
        }
        public string IsUserAPPSendDesc
        {
            get
            {
                return this.IsUserAPPSend ? "显示" : "不显示";
            }
        }
        /// <summary>
        /// 0-未生效 1-生效 2-已失效
        /// </summary>
        public int ValidStatus
        {
            get
            {
                int desc = 1;
                if (this.StartTime > DateTime.MinValue && this.EndTime > DateTime.MinValue)
                {
                    if (this.StartTime > DateTime.Now)
                    {
                        desc = 0;
                    }
                    else if (this.EndTime < DateTime.Now)
                    {
                        desc = 2;
                    }
                }
                else if (this.StartTime > DateTime.MinValue)
                {
                    if (this.StartTime > DateTime.Now)
                    {
                        desc = 0;
                    }
                }
                else if (this.EndTime > DateTime.MinValue)
                {
                    if (this.EndTime < DateTime.Now)
                    {
                        desc = 2;
                    }
                }
                return desc;
            }
        }
        public string IsInvalidDesc
        {
            get
            {
                if (this.ValidStatus == 0)
                {
                    return "未生效";
                }
                if (this.ValidStatus == 1)
                {
                    return "有效";
                }
                if (this.ValidStatus == 2)
                {
                    return "失效";
                }
                return "有效";
            }
        }
    }
}
