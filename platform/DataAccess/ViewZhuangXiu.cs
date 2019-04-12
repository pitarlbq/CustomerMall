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
    /// This object represents the properties and methods of a ViewZhuangXiu.
    /// </summary>
    public partial class ViewZhuangXiu : EntityBaseReadOnly
    {
        public string StatusDesc
        {
            get
            {
                if (string.IsNullOrEmpty(this.Status))
                {
                    return string.Empty;
                }
                return Utility.EnumHelper.GetDescription(typeof(Utility.EnumModel.ZhuangXiuStatus), this.Status);
            }
        }
        public static Ui.DataGrid GetViewZhuangXiuGridByKeywords(string Keywords, string Status, List<int> RoomIDList, List<int> ProjectIDList, DateTime StartTime, DateTime EndTime, string orderBy, long startRowIndex, int pageSize, int UserID = 0)
        {
            long totalRows = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
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
                            cmd += "  and  ([ApplicationMa] like '%" + keywords[i] + "%' or [RoomName] like '%" + keywords[i] + "%')";
                        }
                        else
                        {
                            cmd += "  ([ApplicationMa] like '%" + keywords[i] + "%' or [RoomName] like '%" + keywords[i] + "%'))";
                        }
                    }
                    else if (i == 0)
                    {
                        cmd += " and (([ApplicationMa] like '%" + keywords[i] + "%' or [RoomName] like '%" + keywords[i] + "%') or";
                    }
                    else
                    {
                        cmd += "  ([ApplicationMa] like '%" + keywords[i] + "%' or [RoomName] like '%" + keywords[i] + "%') or ";
                    }
                }
            }
            #endregion
            if (!string.IsNullOrEmpty(Status))
            {
                conditions.Add("[Status]=@Status");
                parameters.Add(new SqlParameter("@Status", Status));
            }
            if (ProjectIDList.Count > 0)
            {
                List<string> cmdlist = ViewRoomFeeHistory.GetProjectIDListConditions(ProjectIDList, IncludeRelation: false, UserID: UserID);
                conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
            }
            if (RoomIDList.Count > 0)
            {
                List<string> cmdlist = ViewRoomFeeHistory.GetRoomIDListConditions(RoomIDList, IncludeRelation: false);
                conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
            }
            if (StartTime > DateTime.MinValue)
            {
                if (Status.Equals(Utility.EnumModel.ZhuangXiuStatus.shenpiyes.ToString()) || Status.Equals(Utility.EnumModel.ZhuangXiuStatus.shenpino.ToString()))
                {
                    conditions.Add("[ApproveTime]>=@StartTime");
                }
                else if (Status.Equals(Utility.EnumModel.ZhuangXiuStatus.zhuangxiu.ToString()))
                {
                    conditions.Add("[ConfirmZXTime]>=@StartTime");
                }
                else if (Status.Equals(Utility.EnumModel.ZhuangXiuStatus.yanshou.ToString()))
                {
                    conditions.Add("[YanShouTime]>=@StartTime");
                }
                else
                {
                    conditions.Add("[AddTime]>=@StartTime");
                }
                parameters.Add(new SqlParameter("@StartTime", StartTime));
            }
            if (EndTime > DateTime.MinValue)
            {
                if (Status.Equals(Utility.EnumModel.ZhuangXiuStatus.shenpiyes.ToString()) || Status.Equals(Utility.EnumModel.ZhuangXiuStatus.shenpino.ToString()))
                {
                    conditions.Add("[ApproveTime]<=@EndTime");
                }
                else if (Status.Equals(Utility.EnumModel.ZhuangXiuStatus.zhuangxiu.ToString()))
                {
                    conditions.Add("[ConfirmZXTime]<=@EndTime");
                }
                else if (Status.Equals(Utility.EnumModel.ZhuangXiuStatus.yanshou.ToString()))
                {
                    conditions.Add("[YanShouTime]<=@EndTime");
                }
                else
                {
                    conditions.Add("[AddTime]<=@EndTime");
                }
                parameters.Add(new SqlParameter("@EndTime", EndTime));
            }
            string fieldList = "[ViewZhuangXiu].*";
            string Statement = " from [ViewZhuangXiu] where  " + string.Join(" and ", conditions.ToArray()) + cmd;
            ViewZhuangXiu[] list = GetList<ViewZhuangXiu>(fieldList, Statement, parameters, orderBy, startRowIndex, pageSize, out totalRows).ToArray();
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
    }
}
