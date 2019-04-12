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
    /// This object represents the properties and methods of a ViewCustomerService.
    /// </summary>
    public partial class ViewCustomerService : EntityBaseReadOnly
    {
        public static Dictionary<int, string> ServiceAccpetManList = new Dictionary<int, string>();
        public static User[] UserList = null;
        public static User[] GetUserList()
        {
            if (UserList == null)
            {
                UserList = Foresight.DataAccess.User.GetAPPUserList();
            }
            return UserList;
        }
        public string FinalServiceAccpetMan
        {
            get
            {
                string desc = string.Empty;
                if (ServiceAccpetManList != null && ServiceAccpetManList.ContainsKey(this.ID))
                {
                    return ServiceAccpetManList[this.ID];
                }
                if (this.IsAPPShow && !string.IsNullOrEmpty(this.ServiceAccpetManID))
                {
                    string[] ServiceAccpetManIDStrList = this.ServiceAccpetManID.Replace("[", "").Replace("]", "").Split(',');
                    if (ServiceAccpetManIDStrList.Length > 0)
                    {
                        List<int> ServiceAccpetManIDList = new List<int>();
                        foreach (var item in ServiceAccpetManIDStrList)
                        {
                            if (string.IsNullOrEmpty(item))
                            {
                                continue;
                            }
                            ServiceAccpetManIDList.Add(Convert.ToInt32(item));
                        }
                        if (ServiceAccpetManIDList.Count > 0)
                        {
                            var users = GetUserList().Where(p => ServiceAccpetManIDList.Contains(p.UserID));
                            desc = string.Join(",", users.Select(p => p.RealName).ToArray());
                        }
                    }
                }
                else
                {
                    desc = this.ServiceAccpetMan;
                }
                ServiceAccpetManList[this.ID] = desc;
                return desc;
            }
        }
        public static void ResetCache()
        {
            ServiceAccpetManList = new Dictionary<int, string>();
            UserList = null;
        }
        public string FinalProjectName
        {
            get
            {
                return string.IsNullOrEmpty(this.Project_Name) ? this.ProjectName : this.Project_Name;
            }
        }
        public static Ui.DataGrid GetCustomerServiceGridByKeywords(string Keywords, List<int> RoomIDList, DateTime StartTime, DateTime EndTime, int ServiceStatus, int PayStatus, int ServiceAccpetManID, string orderBy, long startRowIndex, int pageSize, int UserID, List<int> EqualProjectIDList = null, List<int> InProjectIDList = null, int ServiceType = 0, int ServiceRange = 1, List<int> PublicProjectIDList = null, bool canexport = false)
        {
            ResetCache();
            long totalRows = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            List<string> cmdlist = new List<string>();
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
                            cmd += "  and  (isnull([ServiceNumber],'') like '%" + keywords[i] + "%' or [AddCustomerName] like '%" + keywords[i] + "%' or [AddCallPhone] like '%" + keywords[i] + "%' or [ServiceAccpetMan] like '%" + keywords[i] + "%' or [ServiceFullName] like '%" + keywords[i] + "%' or [ServiceContent] like '%" + keywords[i] + "%')";
                        }
                        else
                        {
                            cmd += "  (isnull([ServiceNumber],'') like '%" + keywords[i] + "%' or [AddCustomerName] like '%" + keywords[i] + "%' or [AddCallPhone] like '%" + keywords[i] + "%' or [ServiceAccpetMan] like '%" + keywords[i] + "%' or [ServiceFullName] like '%" + keywords[i] + "%' or [ServiceContent] like '%" + keywords[i] + "%'))";
                        }
                    }
                    else if (i == 0)
                    {
                        cmd += " and ((isnull([ServiceNumber],'') like '%" + keywords[i] + "%' or [AddCustomerName] like '%" + keywords[i] + "%' or [AddCallPhone] like '%" + keywords[i] + "%' or [ServiceAccpetMan] like '%" + keywords[i] + "%' or [ServiceFullName] like '%" + keywords[i] + "%' or [ServiceContent] like '%" + keywords[i] + "%') or";
                    }
                    else
                    {
                        cmd += "  (isnull([ServiceNumber],'') like '%" + keywords[i] + "%' or [AddCustomerName] like '%" + keywords[i] + "%' or [AddCallPhone] like '%" + keywords[i] + "%' or [ServiceAccpetMan] like '%" + keywords[i] + "%' or [ServiceFullName] like '%" + keywords[i] + "%' or [ServiceContent] like '%" + keywords[i] + "%') or ";
                    }
                }
            }
            #endregion
            if (ServiceType == 2)
            {
                conditions.Add("isnull([IsSuggestion],0)=1");
            }
            else
            {
                conditions.Add("isnull([IsSuggestion],0)=0");
                cmdlist = new List<string>();
                if (ServiceRange == 1)
                {
                    conditions.Add("isnull([PublicProjectID],0)=0");
                }
                if (ServiceRange == 2)
                {
                    conditions.Add("isnull([PublicProjectID],0)>0");
                    conditions.Add("isnull([ProjectID],0)=0");
                }
                if (InProjectIDList != null && InProjectIDList.Count > 0)
                {
                    cmdlist = ViewRoomFeeHistory.GetProjectIDListConditions(InProjectIDList, IncludeRelation: false, RoomIDName: "[ProjectID]", UserID: UserID);
                }
                if (EqualProjectIDList != null && EqualProjectIDList.Count > 0)
                {
                    cmdlist.Add("([ProjectID] in (" + string.Join(",", EqualProjectIDList.ToArray()) + "))");
                }
                if (PublicProjectIDList != null && PublicProjectIDList.Count > 0)
                {
                    cmdlist.Add("[PublicProjectID] in (" + string.Join(",", PublicProjectIDList.ToArray()) + ")");
                }
                if (cmdlist.Count > 0)
                {
                    conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
                }
                if (ServiceAccpetManID > 0)
                {
                    conditions.Add("REPLACE(REPLACE([ServiceAccpetManID],'[',','),']',',') like '%," + ServiceAccpetManID.ToString() + ",%'");
                }
                if (PayStatus == 0)
                {
                    conditions.Add("isnull([TotalFee],0)=0");
                }
                if (PayStatus == 1)
                {
                    conditions.Add("isnull([TotalFee],0)>0");
                }
                if (RoomIDList.Count > 0)
                {
                    cmdlist = new List<string>();
                    cmdlist = ViewRoomFeeHistory.GetRoomIDListConditions(RoomIDList, IncludeRelation: false, RoomIDName: "[ProjectID]");
                    conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
                }
                if (StartTime > DateTime.MinValue)
                {
                    conditions.Add("[StartTime]>=@StartTime");
                    parameters.Add(new SqlParameter("@StartTime", StartTime));
                }
                if (EndTime > DateTime.MinValue)
                {
                    conditions.Add("[StartTime]<=@EndTime");
                    parameters.Add(new SqlParameter("@EndTime", EndTime));
                }
                if (ServiceStatus > -1)
                {
                    if (ServiceStatus == 100)
                    {
                        conditions.Add("[ServiceStatus] in (3,10)");
                    }
                    else
                    {
                        conditions.Add("[ServiceStatus]=@ServiceStatus");
                    }
                    parameters.Add(new SqlParameter("@ServiceStatus", ServiceStatus));
                }
            }
            string fieldList = "[ViewCustomerService].*";
            string Statement = " from [ViewCustomerService] where  " + string.Join(" and ", conditions.ToArray()) + cmd;
            ViewCustomerService[] list = new ViewCustomerService[] { };
            if (canexport)
            {
                list = GetList<ViewCustomerService>("select " + fieldList + Statement + " " + orderBy, parameters).ToArray();
                totalRows = list.Length;
            }
            else
            {
                list = GetList<ViewCustomerService>(fieldList, Statement, parameters, orderBy, startRowIndex, pageSize, out totalRows).ToArray();
            }
            string footer_text = "select '合计' as [ServiceFullName],100 as [ServiceStatus],sum(CASE WHEN ISNUMERIC(HandelFee)=1 THEN convert(decimal(18,2),HandelFee) ELSE 0 END) as HandelFee,sum(isnull(TotalFee,0)) as TotalFee from [ViewCustomerService] where  " + string.Join(" and ", conditions.ToArray()) + cmd;
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            dg.footer = GetList<ViewCustomerService>(footer_text, parameters).ToArray();
            return dg;
        }
        public static ViewCustomerService[] GetViewCustomerServiceListByID(List<int> IDList, string orderby)
        {
            ResetCache();
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            string cmdwhere = string.Empty;
            if (IDList.Count > 0)
            {
                conditions.Add("[ID] in (" + string.Join(",", IDList.ToArray()) + ")");
            }
            ViewCustomerService[] list = new ViewCustomerService[] { };
            string cmdorderby = string.Empty;
            if (!string.IsNullOrEmpty(orderby))
            {
                if (orderby.ToLower().Trim().StartsWith("order by"))
                {
                    cmdorderby = orderby;
                }
                else
                {
                    cmdorderby = "order by " + orderby;
                }
            }
            string cmdText = "select * from [ViewCustomerService] where " + string.Join(" and ", conditions.ToArray()) + cmdorderby;
            list = GetList<ViewCustomerService>(cmdText, parameters).ToArray();
            return list;
        }
        public static ViewCustomerService[] GetViewCustomerServiceListByStatus(int status, int UserID, long startRowIndex, int pageSize, out long totalRows, bool onlybaoshi = false, List<int> ProjectIDList = null)
        {
            ResetCache();
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            string orderby = " order by [AddTime] desc";
            conditions.Add("1=1");
            if (ProjectIDList != null && ProjectIDList.Count > 0)
            {
                List<string> cmdlist = ViewRoomFeeHistory.GetProjectIDListConditions(ProjectIDList, IncludeRelation: false, RoomIDName: "[ProjectID]", UserID: UserID);
                if (UserID > -1)
                {
                    cmdlist.Add("[ProjectID]=0");
                }
                conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
            }
            if (status >= 0)
            {
                conditions.Add("[ServiceStatus]=@ServiceStatus");
                parameters.Add(new SqlParameter("@ServiceStatus", status));
                if (status == 1)
                {
                    orderby = " order by [BanJieTime] desc";
                }
            }
            if (UserID > 0)
            {
                conditions.Add("([DepartmentID] in (select DepartmentID from [UserDepartment] where [UserID]=@UserID) or DepartmentID is null or DepartmentID=0)");
                if (status != 3)
                {
                    conditions.Add("REPLACE(REPLACE([ServiceAccpetManID],'[',','),']',',') like '%," + UserID.ToString() + ",%'");
                }
                parameters.Add(new SqlParameter("@UserID", UserID));
            }
            if (onlybaoshi)
            {
                string cmdwhere = string.Empty;
                if (UserID > 0)
                {
                    cmdwhere += " and [AddUserID]=@AddUserID";
                    parameters.Add(new SqlParameter("@AddUserID", UserID));
                }
                conditions.Add("ID in (select ID from [CustomerService] where [WechatServiceID] in (select ID from [Wechat_Service] where 1=1 " + cmdwhere + "))");
            }
            string fieldList = "[ViewCustomerService].*";
            string Statement = " from [ViewCustomerService] where " + string.Join(" and ", conditions.ToArray());
            var list = GetList<ViewCustomerService>(fieldList, Statement, parameters, orderby, startRowIndex, pageSize, out totalRows).ToArray();
            if (UserID == -1)
            {
                var UserList = User.GetAPPUserList();
                var UserIDList = UserList.Select(p => p.UserID).ToList();
                list = list.Where(p =>
                {
                    if (string.IsNullOrEmpty(p.ServiceAccpetManID))
                    {
                        return true;
                    }
                    string[] ServiceAccpetManIDArray = p.ServiceAccpetManID.Replace("[", ",").Replace("]", ",").Split(',');
                    foreach (var MyUserID in UserIDList)
                    {
                        foreach (var item in ServiceAccpetManIDArray)
                        {
                            if (MyUserID.ToString().Equals(item))
                            {
                                return false;
                            }
                        }
                    }
                    return true;
                }).ToArray();
            }
            return list;
        }
        public static ViewCustomerService GetViewCustomerServiceByID(int ID)
        {
            ResetCache();
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[ID]=@ID");
            parameters.Add(new SqlParameter("@ID", ID));
            string cmdText = "select * from [ViewCustomerService] where " + string.Join(" and ", conditions.ToArray());
            return GetOne<ViewCustomerService>(cmdText, parameters);
        }
        public static ViewCustomerService[] GetAPPCustomerViewCustomerServiceListByStatus(int status, int UserID, long startRowIndex, int pageSize, out long totalRows, bool IsSuggestion = false, string OpenID = "")
        {
            ResetCache();
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            string orderby = " order by [AddTime] desc";
            conditions.Add("1=1");
            if (IsSuggestion)
            {
                conditions.Add("isnull([IsSuggestion],0)=1");
            }
            else
            {
                conditions.Add("isnull([IsSuggestion],0)=0");
            }
            if (status >= 0)
            {
                conditions.Add("[ServiceStatus]=@ServiceStatus");
                parameters.Add(new SqlParameter("@ServiceStatus", status));
                if (status == 1)
                {
                    orderby = " order by [BanJieTime] desc";
                }
            }
            if (UserID > 0)
            {
                conditions.Add("[ID] in (select ID from [CustomerService] where [AddUserID]=@UserID)");
                parameters.Add(new SqlParameter("@UserID", UserID));
            }
            if (!string.IsNullOrEmpty(OpenID))
            {
                conditions.Add("[WechatServiceID] in (select ID from [Wechat_Service] where [OpenID]=@OpenID)");
                parameters.Add(new SqlParameter("@OpenID", OpenID));
            }
            string fieldList = "[ViewCustomerService].*";
            string Statement = " from [ViewCustomerService] where " + string.Join(" and ", conditions.ToArray());
            var list = GetList<ViewCustomerService>(fieldList, Statement, parameters, orderby, startRowIndex, pageSize, out totalRows).ToArray();
            return list;
        }
        public string ServiceStatusDesc
        {
            get
            {
                if (this.ServiceStatus == int.MinValue)
                {
                    return "处理中";
                }
                switch (this.ServiceStatus)
                {
                    case 0:
                        return "处理中";
                        break;
                    case 1:
                        return "已办结";
                        break;
                    case 2:
                        return "已销单";
                        break;
                    case 10:
                        return "待接单";
                        break;
                    case 3:
                        return "待处理";
                        break;
                    case 100:
                        return "";
                        break;
                    default:
                        return "待接单";
                        break;
                }
            }
        }
        public string ServiceFromDesc
        {
            get
            {
                if (this.ServiceFullName.Equals("合计"))
                {
                    return string.Empty;
                }
                if (string.IsNullOrEmpty(this.ServiceFrom))
                {
                    if (!string.IsNullOrEmpty(this.OpenID))
                    {
                        this.ServiceFrom = Utility.EnumModel.WechatServiceFromDefine.weixin.ToString();
                    }
                    else if (this.WechatAddUserID > 0)
                    {
                        this.ServiceFrom = Utility.EnumModel.WechatServiceFromDefine.app.ToString();
                    }
                    else
                    {
                        this.ServiceFrom = Utility.EnumModel.WechatServiceFromDefine.system.ToString();
                    }
                }
                return Utility.EnumHelper.GetDescription(typeof(Utility.EnumModel.WechatServiceFromDefine), this.ServiceFrom);

            }
        }
    }
}
