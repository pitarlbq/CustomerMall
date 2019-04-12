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
    /// This object represents the properties and methods of a CustomerService.
    /// </summary>
    public partial class CustomerService : EntityBase
    {
        public static Dictionary<int, string> ServiceAccpetManList = new Dictionary<int, string>();
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
                            var users = Foresight.DataAccess.User.GetUserListByIDList(ServiceAccpetManIDList);
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
        }
        public static CustomerService GetLastCustomerService(int OrderNumberID)
        {
            ResetCache();
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            //conditions.Add("ChargeTime is not null");
            conditions.Add("[AddTime]>=@AddTime");
            conditions.Add("isnull([OrderNumberID],0)=@OrderNumberID");
            parameters.Add(new SqlParameter("@OrderNumberID", OrderNumberID));
            DateTime start = DateTime.Today.AddDays(1 - DateTime.Now.Day);
            parameters.Add(new SqlParameter("@AddTime", start));
            return GetOne<CustomerService>("select top 1 * from [CustomerService] where " + string.Join(" and ", conditions.ToArray()) + " order by AddTime desc", parameters);
        }
        public static string GetLastestCustomerServiceNumber(string OrderTypeName, int RoomID, out int OrderNumberID)
        {
            ResetCache();
            if (string.IsNullOrEmpty(OrderTypeName))
            {
                OrderTypeName = Foresight.DataAccess.OrderTypeNameDefine.customerservice.ToString();
            }
            Sys_OrderNumber sysOrderNumber = Sys_OrderNumber.GetSys_OrderNumberByRoomID(OrderTypeName, RoomID);
            if (sysOrderNumber == null)
            {
                OrderNumberID = 0;
                return string.Empty;
            }
            OrderNumberID = sysOrderNumber.ID;
            CustomerService service = CustomerService.GetLastCustomerService(OrderNumberID);
            string Part1 = string.Empty;
            Part1 += sysOrderNumber.OrderPrefix;
            string time_yyyy = DateTime.Now.ToString("yyyy");
            string time_mm = DateTime.Now.ToString("MM");
            string time_dd = DateTime.Now.ToString("dd");
            if (sysOrderNumber.UseYear)
            {
                Part1 += time_yyyy;
            }
            if (sysOrderNumber.UseMonth)
            {
                Part1 += time_mm;
            }
            if (sysOrderNumber.UseDay)
            {
                Part1 += time_dd;
            }
            int OrderNumberCount = sysOrderNumber.OrderNumberCount <= 0 ? 3 : sysOrderNumber.OrderNumberCount;
            int number = 1;
            if (service != null && !string.IsNullOrEmpty(service.ServiceNumber))
            {
                number = PrintRoomFeeHistory.GetOrderNumberBySysOrder(service.ServiceNumber, sysOrderNumber, out OrderNumberCount);
            }
            return Part1 + number.ToString("D" + OrderNumberCount);
        }

        public static int GetCustomerServiceCountByStatus(int UserID, int Status, int Type = 0)
        {
            ResetCache();
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
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
                conditions.Add("[ProjectID] in (select ID from [Project] where (" + string.Join(" or ", cmdlist.ToArray()) + "))");
            }
            conditions.Add("[ServiceStatus]=@Status");
            parameters.Add(new SqlParameter("@Status", Status));
            if (Status != 3 && Type == 0)
            {
                conditions.Add("REPLACE(REPLACE([ServiceAccpetManID],'[',','),']',',') like '%," + UserID.ToString() + ",%'");
            }
            if (Type == 0)
            {
                conditions.Add("([DepartmentID] in (select DepartmentID from [UserDepartment] where [UserID]=@UserID) or DepartmentID is null or DepartmentID=0)");
                parameters.Add(new SqlParameter("@UserID", UserID));
            }
            int count = 0;
            using (SqlHelper helper = new SqlHelper())
            {
                string cmdtext = "select count(1) from [CustomerService] where " + string.Join(" and ", conditions.ToArray());
                var result = helper.ExecuteScalar(cmdtext, CommandType.Text, parameters);
                if (result != null)
                {
                    count = Convert.ToInt32(result);
                }
            }
            return count;
        }
        public static int GetChuliGenjinCount(int UserID)
        {
            ResetCache();
            int count = 0;
            using (SqlHelper helper = new SqlHelper())
            {
                List<SqlParameter> parameters = new List<SqlParameter>();
                string cmdtext = "select count(1) from [CustomerService] where [ServiceStatus]=0 and [WechatServiceID] in (select ID from [Wechat_Service] where [AddUserID]=@UserID) and REPLACE(REPLACE([ServiceAccpetManID],'[',','),']',',') like '%," + UserID.ToString() + ",%'";
                parameters.Add(new SqlParameter("@UserID", UserID));
                var result = helper.ExecuteScalar(cmdtext, CommandType.Text, parameters);
                if (result != null)
                {
                    count = Convert.ToInt32(result);
                }
            }
            return count;
        }
        public static CustomerService[] GetCustomerServiceListByParams(int[] TaskTypeList = null)
        {
            ResetCache();
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (TaskTypeList != null && TaskTypeList.Length > 0)
            {
                conditions.Add("[TaskType] in (" + string.Join(",", TaskTypeList) + ")");
            }
            return GetList<CustomerService>("select * from [CustomerService] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
        public static CustomerService GetExistCustomerServiceByServiceNumber(int ID, string ServiceNumber)
        {
            ResetCache();
            if (string.IsNullOrEmpty(ServiceNumber))
            {
                return null;
            }
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (ID > 0)
            {
                conditions.Add("[ID]!=@ID");
                parameters.Add(new SqlParameter("@ID", ID));
            }
            if (!string.IsNullOrEmpty(ServiceNumber))
            {
                conditions.Add("[ServiceNumber]=@ServiceNumber");
                parameters.Add(new SqlParameter("@ServiceNumber", ServiceNumber));
            }
            return GetOne<CustomerService>("select top 1 * from [CustomerService] where " + string.Join(" and ", conditions.ToArray()) + " order by AddTime desc", parameters);
        }
        public static CustomerService[] GetCustomerServiceListByRoomIDList(List<int> RoomIDList, List<int> ProjectIDList, int UserID = 0, int Status = 0)
        {
            ResetCache();
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (RoomIDList.Count > 0)
            {
                List<string> cmdlist = ViewRoomFeeHistory.GetRoomIDListConditions(RoomIDList, RoomIDName: "[ProjectID]");
                conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
            }
            if (ProjectIDList != null && ProjectIDList.Count > 0)
            {
                List<string> cmdlist = ViewRoomFeeHistory.GetProjectIDListConditions(ProjectIDList, RoomIDName: "[ProjectID]", IsContractFee: false, UserID: UserID);
                conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
            }
            if (Status == 100)
            {
                conditions.Add("[ServiceStatus] in (3,10)");
            }
            return GetList<CustomerService>("select * from [CustomerService] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
        public static int GetCustomerServiceListCountByEqualProjectID(List<int> RoomIDList, int ServiceStatus, int UserID = 0, List<int> EqualProjectIDList = null, List<int> InProjectIDList = null)
        {
            int TotalCount = 0;
            GetCustomerServiceListByEqualProjectID(RoomIDList, ServiceStatus, out TotalCount, UserID: UserID, EqualProjectIDList: EqualProjectIDList, InProjectIDList: InProjectIDList, GetCount: true);
            return TotalCount;
        }
        public static CustomerService[] GetCustomerServiceListByEqualProjectID(List<int> RoomIDList, int ServiceStatus, out int TotalCount, int UserID = 0, List<int> EqualProjectIDList = null, List<int> InProjectIDList = null, bool GetCount = false)
        {
            TotalCount = 0;
            ResetCache();
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
            if (RoomIDList.Count > 0)
            {
                cmdlist = new List<string>();
                cmdlist = ViewRoomFeeHistory.GetRoomIDListConditions(RoomIDList, IncludeRelation: false, RoomIDName: "[ProjectID]");
                conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
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
            if (GetCount)
            {
                using (SqlHelper helper = new SqlHelper())
                {
                    var result = helper.ExecuteScalar("select count(1) from [CustomerService] where  " + string.Join(" and ", conditions.ToArray()), CommandType.Text, parameters);
                    if (result != null)
                    {
                        int.TryParse(result.ToString(), out TotalCount);
                    }
                }
                return new CustomerService[] { };
            }
            string cmdtext = "select * from [CustomerService] where  " + string.Join(" and ", conditions.ToArray());
            CustomerService[] list = GetList<CustomerService>(cmdtext, parameters).ToArray();
            return list;
        }
        public static int GetUnReadCustomerServiceCount()
        {
            ResetCache();
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("isnull([IsUnRead],0)=1");
            int total = 0;
            using (SqlHelper helper = new SqlHelper())
            {
                var obj = helper.ExecuteScalar("select count(1) from [CustomerService] where " + string.Join(" and ", conditions.ToArray()), CommandType.Text, parameters);
                if (obj != null)
                {
                    total = Convert.ToInt32(obj);
                }
                if (total > 0)
                {
                    try
                    {
                        helper.BeginTransaction();
                        helper.Execute("update [CustomerService] set IsUnRead=0 where " + string.Join(" and ", conditions.ToArray()), CommandType.Text, parameters);
                        helper.Commit();
                    }
                    catch (Exception)
                    {
                        helper.Rollback();
                    }
                }
            }
            return total;
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
                if (string.IsNullOrEmpty(this.ServiceFrom))
                {
                    return string.Empty;
                }
                return Utility.EnumHelper.GetDescription(typeof(Utility.EnumModel.WechatServiceFromDefine), this.ServiceFrom);
            }
        }
    }
    public partial class CustomerServiceDetail : CustomerService
    {
        [DatabaseColumn("AllParentID")]
        public string AllParentID { get; set; }
        public static List<Dictionary<string, object>> GetCustomerServiceCountGroupByProjectStatus(int UserID, int Status)
        {
            ResetCache();
            var results = new List<Dictionary<string, object>>();
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            List<int> EqualIDList = new List<int>();
            List<int> InIDList = new List<int>();
            var ProjectList = Project.GetXiaoQuProjectListBySystemUserID(UserID);
            conditions.Add("[ServiceStatus]=@Status");
            parameters.Add(new SqlParameter("@Status", Status));
            string cmdtext = "select *,(select AllParentID from [Project] where ID=[CustomerService].ProjectID) as AllParentID from [CustomerService] where " + string.Join(" and ", conditions.ToArray());
            var list = GetList<CustomerServiceDetail>(cmdtext, parameters).ToArray();
            var my_list = new CustomerServiceDetail[] { };
            var dic = new Dictionary<string, object>();
            foreach (var project in ProjectList)
            {
                my_list = list.Where(p => !string.IsNullOrEmpty(p.AllParentID) && p.AllParentID.Contains("," + project.ID.ToString() + ",")).ToArray();
                dic = new Dictionary<string, object>();
                dic["ProjectID"] = project.ID;
                dic["ProjectName"] = project.Name;
                dic["TotalCount"] = my_list.Length;
                results.Add(dic);
            }
            results = results.OrderByDescending(p => Convert.ToInt32(p["TotalCount"])).ToList();
            return results;
        }
        public static List<Dictionary<string, object>> GetCustomerServiceCountGroupByUserStatus(int UserID, int Status, int ProjectID)
        {
            ResetCache();
            var results = new List<Dictionary<string, object>>();
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            var ProjectIDList = new List<int>() { ProjectID };
            List<int> EqualIDList = new List<int>();
            List<int> InIDList = new List<int>();
            Project.GetMyProjectListByUserID(UserID, out EqualIDList, out InIDList, ProjectIDList: ProjectIDList);
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
                conditions.Add("[ProjectID] in (select ID from [Project] where (" + string.Join(" or ", cmdlist.ToArray()) + "))");
            }
            conditions.Add("[ServiceStatus]=@Status");
            parameters.Add(new SqlParameter("@Status", Status));
            string cmdtext = "select * from [CustomerService] where " + string.Join(" and ", conditions.ToArray());
            Utility.LogHelper.WriteInfo("GetCustomerServiceCountGroupByUserStatus", cmdtext);
            var list = GetList<CustomerServiceDetail>(cmdtext, parameters).ToArray();
            var UserList = User.GetAPPUserList();
            CustomerServiceDetail[] my_list = new CustomerServiceDetail[] { };
            var dic = new Dictionary<string, object>();
            var UserIDList = UserList.Select(p => p.UserID).ToList();
            foreach (var user in UserList)
            {
                //conditions.Add("REPLACE(REPLACE([ServiceAccpetManID],'[',','),']',',') like '%," + UserID.ToString() + ",%'");
                my_list = list.Where(p => !string.IsNullOrEmpty(p.ServiceAccpetManID) && p.ServiceAccpetManID.Replace("[", ",").Replace("]", ",").Contains("," + user.UserID.ToString() + ",")).ToArray();
                if (my_list.Length > 0)
                {
                    dic = new Dictionary<string, object>();
                    dic["UserID"] = user.UserID;
                    dic["UserName"] = string.IsNullOrEmpty(user.RealName) ? user.LoginName : user.RealName;
                    dic["TotalCount"] = my_list.Length;
                    results.Add(dic);
                }
            }
            my_list = list.Where(p =>
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
            if (my_list.Length > 0)
            {
                dic = new Dictionary<string, object>();
                dic["UserID"] = -1;
                dic["UserName"] = "匿名用户";
                dic["TotalCount"] = my_list.Length;
                results.Add(dic);
            }
            results = results.OrderByDescending(p => Convert.ToInt32(p["TotalCount"])).ToList();
            return results;
        }
    }
    public partial class CustomerServiceStatic : EntityBaseReadOnly
    {
        [DatabaseColumn("ID")]
        public int ID { get; set; }
        [DatabaseColumn("TotalCount")]
        public int TotalCount { get; set; }
        [DatabaseColumn("jiedandengji_count")]
        public int jiedandengji_count { get; set; }
        [DatabaseColumn("chulizhong_count")]
        public int chulizhong_count { get; set; }
        [DatabaseColumn("yiwancheng_count")]
        public int yiwancheng_count { get; set; }
        [DatabaseColumn("yihuifang_count")]
        public int yihuifang_count { get; set; }
        protected override void EnsureParentProperties()
        {
        }
        public static CustomerServiceStatic[] GetCustomerServiceStaticCountByServiceType(DateTime StartTime, DateTime EndTime, int ProjectID = 0, int UserID = 0)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
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
            if (ProjectID > 0)
            {
                conditions.Add("[ProjectID] in (select ID from Project where AllParentID like '%," + ProjectID + ",%')");
            }
            if (UserID > 0)
            {
                conditions.Add("REPLACE(REPLACE([ServiceAccpetManID],'[',','),']',',') like '%," + UserID.ToString() + ",%'");
                parameters.Add(new SqlParameter("@UserID", UserID));
            }
            return GetList<CustomerServiceStatic>("select A.*,B.yiwancheng_count,C.jiedandengji_count,D.chulizhong_count,E.yihuifang_count from (select Count(1) as TotalCount,ServiceTypeID as ID from CustomerService where " + string.Join(" and ", conditions.ToArray()) + " group by ServiceTypeID)A left join (select Count(1) as yiwancheng_count,ServiceTypeID as ID from CustomerService where [ServiceStatus]=1 and " + string.Join(" and ", conditions.ToArray()) + " group by ServiceTypeID)B on B.ID=A.ID left join (select Count(1) as jiedandengji_count,ServiceTypeID as ID from CustomerService where [ServiceStatus] in (10,3) and " + string.Join(" and ", conditions.ToArray()) + " group by ServiceTypeID)C on C.ID=A.ID left join (select Count(1) as chulizhong_count,ServiceTypeID as ID from CustomerService where [ServiceStatus] in (0) and " + string.Join(" and ", conditions.ToArray()) + " group by ServiceTypeID)D on D.ID=A.ID left join (select Count(1) as yihuifang_count,ServiceTypeID as ID from CustomerService where exists(select count(1) from [CustomerServiceHuifang] where ServiceID=[CustomerService].ID) and " + string.Join(" and ", conditions.ToArray()) + " group by ServiceTypeID)E on E.ID=A.ID", parameters).ToArray();
        }
        public static CustomerServiceStatic[] GetCustomerServiceStaticCountByTaskType(int ProjectID, DateTime StartTime, DateTime EndTime)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
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
            if (ProjectID > 0)
            {
                conditions.Add("[ProjectID] in (select ID from Project where AllParentID like '%," + ProjectID + ",%')");
            }
            return GetList<CustomerServiceStatic>("select A.*,B.yiwancheng_count,C.jiedandengji_count,D.chulizhong_count,E.yihuifang_count from (select Count(1) as TotalCount,TaskType as ID from CustomerService where " + string.Join(" and ", conditions.ToArray()) + " group by TaskType)A left join (select Count(1) as yiwancheng_count,TaskType as ID from CustomerService where [ServiceStatus]=1 and " + string.Join(" and ", conditions.ToArray()) + " group by TaskType)B on B.ID=A.ID left join (select Count(1) as jiedandengji_count,TaskType as ID from CustomerService where [ServiceStatus] in (10,3) and " + string.Join(" and ", conditions.ToArray()) + " group by TaskType)C on C.ID=A.ID left join (select Count(1) as chulizhong_count,TaskType as ID from CustomerService where [ServiceStatus] in (0) and " + string.Join(" and ", conditions.ToArray()) + " group by TaskType)D on D.ID=A.ID left join (select Count(1) as yihuifang_count,TaskType as ID from CustomerService where exists(select count(1) from [CustomerServiceHuifang] where ServiceID=[CustomerService].ID) and " + string.Join(" and ", conditions.ToArray()) + " group by TaskType)E on E.ID=A.ID", parameters).ToArray();
        }
    }
}
