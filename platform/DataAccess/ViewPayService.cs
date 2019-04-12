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
    /// This object represents the properties and methods of a ViewPayService.
    /// </summary>
    public partial class ViewPayService : EntityBaseReadOnly
    {
        public static Ui.DataGrid GetViewPayServiceGridByKeywords(int PaySummaryID, string Keywords, List<int> RoomIDList, DateTime StartTime, DateTime EndTime, string orderBy, long startRowIndex, int pageSize, int UserID = 0, List<int> EqualProjectIDList = null, List<int> InProjectIDList = null, bool canexport = false)
        {
            long totalRows = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            List<string> cmdlist = new List<string>();
            conditions.Add("1=1");
            if (InProjectIDList != null && InProjectIDList.Count > 0)
            {
                cmdlist = new List<string>();
                cmdlist = ViewRoomFeeHistory.GetProjectIDListConditions(InProjectIDList, IncludeRelation: false, RoomIDName: "[ProjectID]", UserID: UserID);

            }
            if (EqualProjectIDList != null && EqualProjectIDList.Count > 0)
            {
                cmdlist.Add("([ProjectID] in (" + string.Join(",", EqualProjectIDList.ToArray()) + "))");
            }
            if (cmdlist.Count > 0)
            {
                conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
            }
            if (PaySummaryID > 0)
            {
                conditions.Add("[PaySummaryID]=@PaySummaryID");
                parameters.Add(new SqlParameter("@PaySummaryID", PaySummaryID));
            }
            #region 关键字查询
            string cmd = string.Empty;

            if (!string.IsNullOrEmpty(Keywords))
            {
                string[] keywords = Keywords.Trim().Split(' ');
                for (int i = 0; i < keywords.Length; i++)
                {
                    if (string.IsNullOrEmpty(keywords[i].ToString()))
                    {
                        continue;
                    }
                    if (i + 1 == keywords.Length)
                    {
                        if (keywords.Length == 1)
                        {
                            cmd += "  and  ([ProjectName] like '%" + keywords[i] + "%' or [PayType] like '%" + keywords[i] + "%' or [AccountType] like '%" + keywords[i] + "%' or [RoomName] like '%" + keywords[i] + "%' or [Remark] like '%" + keywords[i] + "%')";
                        }
                        else
                        {
                            cmd += "  ([ProjectName] like '%" + keywords[i] + "%' or [PayType] like '%" + keywords[i] + "%' or [AccountType] like '%" + keywords[i] + "%' or [RoomName] like '%" + keywords[i] + "%' or [Remark] like '%" + keywords[i] + "%'))";
                        }
                    }
                    else if (i == 0)
                    {
                        cmd += " and (([ProjectName] like '%" + keywords[i] + "%' or [PayType] like '%" + keywords[i] + "%' or [AccountType] like '%" + keywords[i] + "%' or [RoomName] like '%" + keywords[i] + "%' or [Remark] like '%" + keywords[i] + "%') or";
                    }
                    else
                    {
                        cmd += "  ([ProjectName] like '%" + keywords[i] + "%' or [PayType] like '%" + keywords[i] + "%' or [AccountType] like '%" + keywords[i] + "%' or [RoomName] like '%" + keywords[i] + "%' or [Remark] like '%" + keywords[i] + "%') or ";
                    }
                }
            }
            #endregion
            if (RoomIDList.Count > 0)
            {
                cmdlist = new List<string>();
                cmdlist = ViewRoomFeeHistory.GetRoomIDListConditions(RoomIDList, IncludeRelation: false, RoomIDName: "[ProjectID]");
                conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
            }
            if (StartTime > DateTime.MinValue)
            {
                conditions.Add("[PayTime]>=@StartTime");
                parameters.Add(new SqlParameter("@StartTime", StartTime));
            }
            if (EndTime > DateTime.MinValue)
            {
                conditions.Add("[PayTime]<=@EndTime");
                parameters.Add(new SqlParameter("@EndTime", EndTime));
            }
            string fieldList = "[ViewPayService].*";
            string Statement = " from [ViewPayService] where  " + string.Join(" and ", conditions.ToArray()) + cmd;
            ViewPayService[] list = new ViewPayService[] { };
            if (canexport)
            {
                list = GetList<ViewPayService>("select " + fieldList + Statement + " " + orderBy, parameters).ToArray();
            }
            else
            {
                list = GetList<ViewPayService>(fieldList, Statement, parameters, orderBy, startRowIndex, pageSize, out totalRows).ToArray();
            }
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
        public static ViewPayService[] GetViewPayServiceList(List<int> IDList, string orderBy)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (IDList.Count > 0)
            {
                conditions.Add("[ID] in (" + string.Join(",", IDList.ToArray()) + ")");
            }
            string Statement = "select * from [ViewPayService] where  " + string.Join(" and ", conditions.ToArray());
            ViewPayService[] list = GetList<ViewPayService>(Statement, parameters).ToArray();
            return list;
        }
        //1-待申请 2-待审核 3-审核通过 4-审核未通过
        public string StatusDesc
        {
            get
            {
                string desc = string.Empty;
                switch (this.Status)
                {
                    case 1:
                        desc = "待审核";
                        break;
                    case 2:
                        desc = "待审核";
                        break;
                    case 3:
                        desc = "已审核";
                        break;
                    case 4:
                        desc = "审核未通过";
                        break;
                    default:
                        desc = "已审核";
                        break;
                }
                return desc;
            }
        }
    }
}
