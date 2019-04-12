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
    /// This object represents the properties and methods of a Mall_Order.
    /// </summary>
    public partial class Mall_Order : EntityBase
    {
        public static void GetGrabOrderInfo(Mall_Order item)
        {
            item.IsAPPUserSent = true;
            item.IsCanGrab = true;
            item.GrabStatus = 1;
            item.GrabSendTime = DateTime.MinValue;
        }
        /// <summary>
        /// 订单派送列表status 1-待抢单 2-待接收 3-待发货 4-已完成
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="Status"></param>
        /// <param name="startRowIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="totalRows"></param>
        /// <returns></returns>
        public static Mall_OrderDetail[] GetAPPUserMall_OrderListByStatus(int UserID, int Status, long startRowIndex, int pageSize, out long totalRows)
        {
            totalRows = 0;
            if (UserID <= 0 || Status <= 0)
            {
                return new Mall_OrderDetail[] { };
            }
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = GetAPPUserMall_OrderListConditions(UserID, Status, parameters);
            if (conditions.Count == 0)
            {
                return new Mall_OrderDetail[] { };
            }
            string OrderBy = " order by [AddTime] desc";
            string fieldList = "A.*";
            string Statement = " from (select [Mall_Order].*,(select top 1 [ProductName] from [Mall_OrderItem] where [Mall_OrderItem].[OrderID]=[Mall_Order].ID) as ProductName,[Mall_Business].BusinessName from [Mall_Order] left join [Mall_Business] on [Mall_Business].ID=[Mall_Order].[BusinessID])A where  " + string.Join(" and ", conditions.ToArray());
            var list = GetList<Mall_OrderDetail>(fieldList, Statement, parameters, OrderBy, startRowIndex, pageSize, out totalRows).ToArray();
            return list;
        }
        /// <summary>
        /// 1-待抢单 2-待接收 3-待发货 4-已完成
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="Status"></param>
        /// <returns></returns>
        public static int GetMall_OrderCountByStatus(int UserID, int Status)
        {
            if (UserID <= 0 || Status <= 0)
            {
                return 0;
            }
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = GetAPPUserMall_OrderListConditions(UserID, Status, parameters);
            if (conditions.Count == 0)
            {
                return 0;
            }
            int count = 0;
            using (SqlHelper helper = new SqlHelper())
            {
                string cmdtext = "select count(1) from [Mall_Order] as A where " + string.Join(" and ", conditions.ToArray());
                var result = helper.ExecuteScalar(cmdtext, CommandType.Text, parameters);
                if (result != null)
                {
                    count = Convert.ToInt32(result);
                }
            }
            return count;
        }
        public static List<string> GetAPPUserMall_OrderListConditions(int UserID, int Status, List<SqlParameter> parameters)
        {
            List<string> conditions = new List<string>();
            conditions.Add("isnull([IsClosed],0)=0");
            if (Status == 1)//待抢单
            {
                var projectList = RoleProject.GetRoleProjectListByUserID(UserID);
                int[] ProjectIDList = projectList.Select(p => p.ProjectID).ToArray();
                if (ProjectIDList.Length == 0)
                {
                    return new List<string>();
                }
                var subcmdlist = new List<string>();
                foreach (var myProjectID in ProjectIDList)
                {
                    subcmdlist.Add("exists (select 1 from [Project] where [ID]=[Mall_UserProject].[ProjectID] and AllParentID like '%," + myProjectID + ",%')");
                }
                conditions.Add("exists(select 1 from [Mall_UserProject] where [UserID]=A.[UserID] and ([IsDisable]=0 or [IsDisable] is null) and (" + string.Join(" or ", subcmdlist.ToArray()) + "))");
                conditions.Add("[GrabStatus]=1");
                conditions.Add("[OrderStatus]=5");
            }
            else
            {
                parameters.Add(new SqlParameter("@UserID", UserID));
                if (Status == 2)//待接收
                {
                    conditions.Add("exists(select 1 from [Mall_OrderAPPUser] where [OrderID]=A.ID and [UserID]=@UserID and AccpetStatus=4)");
                    conditions.Add("[GrabStatus]=2");
                }
                if (Status == 3)//待发货
                {
                    conditions.Add("exists(select 1 from [Mall_OrderAPPUser] where [OrderID]=A.ID and [UserID]=@UserID and AccpetStatus=1)");
                    conditions.Add("[GrabStatus]=4");
                    conditions.Add("[OrderStatus]=5");
                }
                if (Status == 4)
                {
                    conditions.Add("exists(select 1 from [Mall_OrderAPPUser] where [OrderID]=A.ID and [UserID]=@UserID and AccpetStatus=1)");
                    conditions.Add("[OrderStatus] in (2,3)");
                }
            }
            return conditions;
        }
        /// <summary>
        /// Status 1-待付款 2-已发货 3-已完成 4-已关闭 5-待发货 6-退款申请 7-已退款 56-待发货退款申请
        /// </summary>
        /// <param name="BusinessID"></param>
        /// <param name="Status"></param>
        /// <returns></returns>
        public static int GetMall_OrderCountByBusinessID(int BusinessID, int[] StatusList)
        {
            if (BusinessID <= 0 || StatusList.Length <= 0)
            {
                return 0;
            }
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("([BusinessID]=@BusinessID or [ID] in (select [OrderID] from [Mall_OrderItem] where [BusinessID]=@BusinessID))");
            parameters.Add(new SqlParameter("@BusinessID", BusinessID));
            if (StatusList.Length == 1 && StatusList[0] == 4)
            {
                conditions.Add("[IsClosed]=1");
            }
            else if (StatusList.Length > 0)
            {
                conditions.Add("(isnull([IsClosed],0)=0)");
                conditions.Add("[OrderStatus] in (" + string.Join(",", StatusList) + ")");
            }
            int count = 0;
            using (SqlHelper helper = new SqlHelper())
            {
                string cmdtext = "select count(1) from [Mall_Order] where " + string.Join(" and ", conditions.ToArray());
                var result = helper.ExecuteScalar(cmdtext, CommandType.Text, parameters);
                if (result != null)
                {
                    count = Convert.ToInt32(result);
                }
            }
            return count;
        }
        public static int GetMall_OrderCompleteCountByBusinessID(int BusinessID, bool IsComplete)
        {
            if (BusinessID <= 0)
            {
                return 0;
            }
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("([BusinessID]=@BusinessID or [ID] in (select [OrderID] from [Mall_OrderItem] where [BusinessID]=@BusinessID))");
            parameters.Add(new SqlParameter("@BusinessID", BusinessID));
            conditions.Add("(isnull([IsClosed],0)=0)");
            conditions.Add("[OrderStatus]=3");
            if (IsComplete)
            {
                conditions.Add("[BusinessCompleteTime] is not null");
            }
            else
            {
                conditions.Add("[BusinessCompleteTime] is null");
            }
            int count = 0;
            using (SqlHelper helper = new SqlHelper())
            {
                string cmdtext = "select count(1) from [Mall_Order] where " + string.Join(" and ", conditions.ToArray());
                var result = helper.ExecuteScalar(cmdtext, CommandType.Text, parameters);
                if (result != null)
                {
                    count = Convert.ToInt32(result);
                }
            }
            return count;
        }
        public static Mall_Order[] GetMall_OrderListByBusinesUserID(int UserID, int minday, int maxday)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[ProductTypeID]!=10");
            conditions.Add("[OrderStatus]=3");
            if (UserID <= 0)
            {
                return new Mall_Order[] { };
            }
            if (minday > 0)
            {
                conditions.Add("[AddTime]<@AddTime");
                parameters.Add(new SqlParameter("@AddTime", DateTime.Today.AddDays(-minday)));
            }
            if (maxday > 0)
            {
                conditions.Add("[AddTime]>=@AddTime");
                parameters.Add(new SqlParameter("@AddTime", DateTime.Today.AddDays(-maxday)));
            }
            conditions.Add("[ID] in (select [OrderID] from [Mall_OrderItem] where [BusinessID] in (select [ID] from [Mall_Business] where [UserID]=@UserID) or [BusinessID] in (select [BusinessID] from [Mall_BusinessUser] where [UserID]=@UserID))");
            parameters.Add(new SqlParameter("@UserID", UserID));
            string cmdtext = "select [ID], [UserID],[TotalCost],[AddTime] from [Mall_Order] where  " + string.Join(" and ", conditions.ToArray());
            return GetList<Mall_Order>(cmdtext, parameters).ToArray();
        }
        public static Mall_Order[] GetMall_OrderListByTime(DateTime StartTime, DateTime EndTime, int OrderStatus = 3)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[ProductTypeID]!=10");
            if (OrderStatus > 0)
            {
                conditions.Add("[OrderStatus]=@OrderStatus");
                parameters.Add(new SqlParameter("@OrderStatus", OrderStatus));
            }
            if (StartTime > DateTime.MinValue)
            {
                conditions.Add("Convert(varchar(100),[AddTime],23)>=@StartTime");
                parameters.Add(new SqlParameter("@StartTime", StartTime));
            }
            if (EndTime > DateTime.MinValue)
            {
                conditions.Add("Convert(varchar(100),[AddTime],23)<=@EndTime");
                parameters.Add(new SqlParameter("@EndTime", EndTime));
            }
            string cmdtext = "select [ID], [UserID],[TotalCost],[AddTime],[OrderStatus] from [Mall_Order] where  " + string.Join(" and ", conditions.ToArray());
            return GetList<Mall_Order>(cmdtext, parameters).ToArray();
        }
        public static Mall_Order GetMall_OrderByTradeNo(string TradeNo, int OrderID = 0)
        {
            using (SqlHelper helper = new SqlHelper())
            {
                return GetMall_OrderByTradeNo(helper, TradeNo, OrderID: OrderID);
            }
        }
        public static Mall_Order GetMall_OrderByTradeNo(SqlHelper helper, string TradeNo, int OrderID = 0)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            if (string.IsNullOrEmpty(TradeNo) && OrderID <= 0)
            {
                return null;
            }
            conditions.Add("([ID]=@OrderID or [TradeNo]=@TradeNo)");
            parameters.Add(new SqlParameter("@OrderID", OrderID));
            parameters.Add(new SqlParameter("@TradeNo", TradeNo));
            string cmdtext = "select * from [Mall_Order] where  " + string.Join(" or ", conditions.ToArray());
            return GetOne<Mall_Order>(cmdtext, parameters, helper);
        }
        public static Mall_Order GetMall_OrderByPin_UserID(int Pin_UserID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            if (Pin_UserID == 0)
            {
                return null;
            }
            conditions.Add("[Pin_UserID]=@Pin_UserID");
            parameters.Add(new SqlParameter("@Pin_UserID", Pin_UserID));
            string cmdtext = "select * from [Mall_Order] where  " + string.Join(" and ", conditions.ToArray());
            return GetOne<Mall_Order>(cmdtext, parameters);
        }
        public static string GetLastestOrderNumber()
        {
            return DateTime.Now.ToString("yyyyMMddHHmmssfff");
        }
        public static Mall_Order[] GetMall_OrderListByStatus(int status, long startRowIndex, int pageSize, out long totalRows, int CategoryID = 0, int UserID = 0, bool isshareorder = false)
        {
            totalRows = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            if (UserID == 0)
            {
                return new Mall_Order[] { };
            }
            conditions.Add("isnull([IsDeleted],0)=0");
            if (isshareorder)
            {
                conditions.Add("[ShareUserID]=@UserID");
                conditions.Add("[OrderStatus]=3");
            }
            else
            {
                conditions.Add("[UserID]=@UserID");
            }
            parameters.Add(new SqlParameter("@UserID", UserID));
            if (status == 4)
            {
                conditions.Add("([OrderStatus] in (4,6,7) or [IsClosed]=1)");
            }
            else if (status > 0)
            {
                conditions.Add("(isnull([IsClosed],0)=0)");
                conditions.Add("[OrderStatus]=@OrderStatus");
                parameters.Add(new SqlParameter("@OrderStatus", status));
                //if (status == 2)
                //{
                //    conditions.Add("[OrderStatus] in (2,3)");
                //}
                //else
                //{
                //    conditions.Add("[OrderStatus]=@OrderStatus");
                //    parameters.Add(new SqlParameter("@OrderStatus", status));
                //}
            }
            string OrderBy = " order by [AddTime] desc";
            string fieldList = "[Mall_Order].*";
            string Statement = " from [Mall_Order] where  " + string.Join(" and ", conditions.ToArray());
            var list = GetList<Mall_Order>(fieldList, Statement, parameters, OrderBy, startRowIndex, pageSize, out totalRows).ToArray();
            return list;
        }
        public static Mall_Order[] GetBusinessMall_OrderListByStatus(int status, long startRowIndex, int pageSize, out long totalRows, int CategoryID = 0, int UserID = 0, string keywords = "")
        {
            totalRows = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("isnull([IsDeleted],0)=0");
            if (UserID == 0)
            {
                return new Mall_Order[] { };
            }
            conditions.Add("[ID] in (select [OrderID] from [Mall_OrderItem] where [BusinessID] in (select [ID] from [Mall_Business] where [UserID]=@UserID) or [BusinessID] in (select [BusinessID] from [Mall_BusinessUser] where [UserID]=@UserID))");
            parameters.Add(new SqlParameter("@UserID", UserID));
            if (status == 4)
            {
                conditions.Add("[IsClosed]=1");
            }
            else if (status == 8)
            {
                conditions.Add("(isnull([IsClosed],0)=0)");
                conditions.Add("[OrderStatus]=3");
                conditions.Add("[BusinessCompleteTime] is null");
            }
            else if (status == 3)
            {
                conditions.Add("(isnull([IsClosed],0)=0)");
                conditions.Add("[OrderStatus]=3");
                conditions.Add("[BusinessCompleteTime] is not null");
            }
            else if (status > 0)
            {
                conditions.Add("(isnull([IsClosed],0)=0)");
                conditions.Add("[OrderStatus]=@OrderStatus");
                parameters.Add(new SqlParameter("@OrderStatus", status));
            }
            if (!string.IsNullOrEmpty(keywords))
            {
                conditions.Add("([ID] in (select [OrderID] from [Mall_OrderItem] where [ProductName] like @keywords) or [OrderNumber] like @keywords or [ShipTrackNo] like @keywords)");
                parameters.Add(new SqlParameter("@keywords", "%" + keywords + "%"));
            }
            string OrderBy = " order by [AddTime] desc";
            string fieldList = "[Mall_Order].*";
            string Statement = " from [Mall_Order] where  " + string.Join(" and ", conditions.ToArray());
            var list = GetList<Mall_Order>(fieldList, Statement, parameters, OrderBy, startRowIndex, pageSize, out totalRows).ToArray();
            return list;
        }
        public static Mall_Order[] GetMall_OrderListByIDList(List<int> IDList)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            if (IDList.Count == 0)
            {
                return new Mall_Order[] { };
            }
            conditions.Add("[ID] in (" + string.Join(",", IDList.ToArray()) + ")");
            string cmdtext = "select * from [Mall_Order] where  " + string.Join(" and ", conditions.ToArray());
            return GetList<Mall_Order>(cmdtext, parameters).ToArray();
        }
        public static Mall_Order[] GetWaitingMall_OrderListByStatus(int status, int waithours)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("isnull([IsClosed],0)=0");
            if (status == 0)
            {
                return new Mall_Order[] { };
            }
            if (status == 1)
            {
                conditions.Add("[AddTime]<=@WaitTime");
            }
            else if (status == 2)
            {
                conditions.Add("[ShipTime]<=@WaitTime");
            }
            else if (status == 3)
            {
                conditions.Add("[CompleteTime]<=@WaitTime");
            }
            parameters.Add(new SqlParameter("@WaitTime", DateTime.Now.AddHours(-waithours)));
            conditions.Add("[OrderStatus]=@status");
            parameters.Add(new SqlParameter("@status", status));
            string cmdtext = "select * from [Mall_Order] where  " + string.Join(" and ", conditions.ToArray());
            var list = GetList<Mall_Order>(cmdtext, parameters).ToArray();
            return list;
        }
        public static Mall_Order[] GetMall_OrderListByKeywords(string Keywords, DateTime StartTime, DateTime EndTime, int Status, long startRowIndex, int pageSize, string ProductName, DateTime PayStartTime, DateTime PayEndTime, string BuyerNickName, string BuyerPhoneNumber, int OrderStatus, int RateStatus, string OrderNumber, string ShipCompany, int OrderType, string BusinessName, bool HideClose, int ProjectID, out long totalRows, bool canexport = false, int ShareUserID = 0, List<int> ProjectIDList = null, List<int> RoomIDList = null)
        {
            totalRows = 0;
            string OrderBy = " order by AddTime desc";
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (ProjectIDList != null && ProjectIDList.Count > 0)
            {
                var subcmdlist = new List<string>();
                foreach (var myProjectID in ProjectIDList)
                {
                    subcmdlist.Add("exists (select 1 from [Project] where [ID]=[Mall_UserProject].[ProjectID] and AllParentID like '%," + myProjectID + ",%')");
                }
                conditions.Add("exists(select 1 from [Mall_UserProject] where [UserID]=[Mall_Order].[UserID] and ([IsDisable]=0 or [IsDisable] is null) and (" + string.Join(" or ", subcmdlist.ToArray()) + "))");
                //var cmdlist = new List<string>();
                //cmdlist.Add("not exists(select 1 from [Mall_UserProject] where [UserID]=[Mall_Order].[UserID] and ([IsDisable]=0 or [IsDisable] is null))");
                //cmdlist.Add("exists(select 1 from [Mall_UserProject] where [UserID]=[Mall_Order].[UserID] and ([IsDisable]=0 or [IsDisable] is null) and not exists(select 1 from [Project] where [Project].ID=[Mall_UserProject].ProjectID))");
                //conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
            }
            if (RoomIDList != null && RoomIDList.Count > 0)
            {
                conditions.Add("exists(select 1 from [Mall_UserProject] where [UserID]=[Mall_Order].[UserID] and ([IsDisable]=0 or [IsDisable] is null) and [ProjectID] in (" + string.Join(",", RoomIDList.ToArray()) + "))");
            }
            if (ShareUserID > 0)
            {
                conditions.Add("[ShareUserID]=@ShareUserID");
                parameters.Add(new SqlParameter("@ShareUserID", ShareUserID));
            }
            if (ProjectID > 0)
            {
                conditions.Add("[AddressProjectID]=@ProjectID");
                parameters.Add(new SqlParameter("@ProjectID", ProjectID));
            }
            if (HideClose)
            {
                conditions.Add("(isnull([IsClosed],0)=0 and [OrderStatus]!=4)");
            }
            if (!string.IsNullOrEmpty(ProductName))
            {
                conditions.Add("ID in (select OrderID from [Mall_OrderItem] where [ProductName] like @ProductName)");
                parameters.Add(new SqlParameter("@ProductName", "%" + ProductName + "%"));
            }
            if (PayStartTime > DateTime.MinValue)
            {
                conditions.Add("[PayTime]>=@PayStartTime");
                parameters.Add(new SqlParameter("@PayStartTime", PayStartTime));
            }
            if (PayEndTime > DateTime.MinValue)
            {
                conditions.Add("[PayTime]<=@PayEndTime");
                parameters.Add(new SqlParameter("@PayEndTime", PayEndTime));
            }
            if (!string.IsNullOrEmpty(BuyerNickName))
            {
                conditions.Add("[UserID] in (select [UserID] from [User] where [NickName] like @BuyerNickName)");
                parameters.Add(new SqlParameter("@BuyerNickName", "%" + BuyerNickName + "%"));
            }
            if (!string.IsNullOrEmpty(BuyerPhoneNumber))
            {
                conditions.Add("[UserName] like @BuyerPhoneNumber");
                parameters.Add(new SqlParameter("@BuyerPhoneNumber", "%" + BuyerPhoneNumber + "%"));
            }
            if (RateStatus == 1)
            {
                conditions.Add("[ID] in (select OrderID from [Mall_OrderComment])");
            }
            else if (RateStatus == 2)
            {
                conditions.Add("[ID] not in (select OrderID from [Mall_OrderComment])");
            }
            if (!string.IsNullOrEmpty(OrderNumber))
            {
                conditions.Add("[OrderNumber] like @OrderNumber");
                parameters.Add(new SqlParameter("@OrderNumber", "%" + OrderNumber + "%"));
            }
            if (!string.IsNullOrEmpty(ShipCompany))
            {
                conditions.Add("[ShipCompanyName] like @ShipCompany");
                parameters.Add(new SqlParameter("@ShipCompany", "%" + ShipCompany + "%"));
            }
            if (OrderType == 11)
            {
                conditions.Add("[IsShareOrder]=1");
            }
            else if (OrderType > 0)
            {
                conditions.Add("[ProductTypeID]=@OrderType");
                parameters.Add(new SqlParameter("@OrderType", OrderType));
            }
            if (!string.IsNullOrEmpty(BusinessName))
            {
                conditions.Add("ID in (select OrderID from [Mall_OrderItem] where [BusinessName] like @BusinessName)");
                parameters.Add(new SqlParameter("@BusinessName", "%" + BusinessName + "%"));
            }
            if (StartTime > DateTime.MinValue)
            {
                conditions.Add("[AddTime]>=@StartTime");
                parameters.Add(new SqlParameter("@StartTime", StartTime));
            }
            if (EndTime > DateTime.MinValue)
            {
                conditions.Add("[AddTime]<=@EndTime");
                parameters.Add(new SqlParameter("@EndTime", EndTime));
            }
            if (OrderStatus > 0)
            {
                Status = OrderStatus;
            }
            if (Status == 4)
            {
                conditions.Add("[IsClosed]=1");
            }
            else if (Status == 0)
            {
                conditions.Add("DATEADD(MONTH,3,GETDATE())>=GETDATE()");
            }
            else if (Status == 12)
            {
                conditions.Add("DATEADD(MONTH,3,GETDATE())<GETDATE()");
            }
            else if (Status == 11)
            {
                conditions.Add("[ID] not in (select OrderID from [Mall_OrderComment])");
            }
            else
            {
                conditions.Add("isnull([IsClosed],0)=0");
                if (Status > 0)
                {
                    conditions.Add("[OrderStatus]=@Status");
                    parameters.Add(new SqlParameter("@Status", Status));
                }
            }
            if (!string.IsNullOrEmpty(Keywords))
            {
                conditions.Add("[OrderNumber] like @Keywords");
                parameters.Add(new SqlParameter("@Keywords", "%" + Keywords + "%"));
            }
            string fieldList = "[Mall_Order].*";
            string Statement = " from [Mall_Order] where " + string.Join(" and ", conditions.ToArray());
            Mall_Order[] list = new Mall_Order[] { };
            if (canexport)
            {
                list = GetList<Mall_Order>("select * " + Statement + OrderBy, parameters).ToArray();
            }
            else
            {
                list = GetList<Mall_Order>(fieldList, Statement, parameters, OrderBy, startRowIndex, pageSize, out totalRows).ToArray();
            }
            return list;
        }
        public static int GetUnReadMall_OrderNewCount()
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("isnull([IsReadNewOrder],0)=0");
            conditions.Add("[OrderStatus]=5");
            conditions.Add("isnull([IsClosed],0)=0");
            int total = 0;
            using (SqlHelper helper = new SqlHelper())
            {
                var obj = helper.ExecuteScalar("select count(1) from [Mall_Order] where " + string.Join(" and ", conditions.ToArray()), CommandType.Text, parameters);
                if (obj != null)
                {
                    total = Convert.ToInt32(obj);
                }
                if (total > 0)
                {
                    try
                    {
                        helper.BeginTransaction();
                        helper.Execute("update [Mall_Order] set IsReadNewOrder=1 where " + string.Join(" and ", conditions.ToArray()), CommandType.Text, parameters);
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
        public static int GetUnReadMall_OrderRefundCount()
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("isnull([IsReadRefundOrder],0)=0");
            conditions.Add("[OrderStatus]=6");
            conditions.Add("isnull([IsClosed],0)=0");
            int total = 0;
            using (SqlHelper helper = new SqlHelper())
            {
                var obj = helper.ExecuteScalar("select count(1) from [Mall_Order] where " + string.Join(" and ", conditions.ToArray()), CommandType.Text, parameters);
                if (obj != null)
                {
                    total = Convert.ToInt32(obj);
                }
                if (total > 0)
                {
                    try
                    {
                        helper.BeginTransaction();
                        helper.Execute("update [Mall_Order] set IsReadRefundOrder=1 where " + string.Join(" and ", conditions.ToArray()), CommandType.Text, parameters);
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
        /// <summary>
        /// 获取待接收推送订单列表
        /// </summary>
        /// <returns></returns>
        public static Mall_Order[] GetUnSendAPPMall_OrderList()
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[GrabStatus]=2");
            conditions.Add("[ID] in (select [OrderID] from [Mall_OrderAPPUser] where AccpetStatus=0 and IsAPPSend=0)");//APP未接受判断
            var list = GetList<Mall_Order>("select * from [Mall_Order] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
            return list;
        }
        /// <summary>
        /// 抢单订单无人抢转待付款订单
        /// </summary>
        /// <returns></returns>
        public static Mall_Order[] GetFailGrapAPPMall_OrderList()
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            string Name = Foresight.DataAccess.SysConfigNameDefine.NoGrabTransfer.ToString();
            var config = SysConfig.GetSysConfigByName(Name);
            int Hour = 48;
            if (config != null && !string.IsNullOrEmpty(config.Value))
            {
                int.TryParse(config.Value, out Hour);
            }
            conditions.Add("DATEADD(hour," + Hour + ", [PayTime])<@PayTime");
            parameters.Add(new SqlParameter("@PayTime", DateTime.Now));
            conditions.Add("[GrabStatus]=1");
            conditions.Add("[OrderStatus]=5");
            var list = GetList<Mall_Order>("select * from [Mall_Order] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
            foreach (var item in list)
            {
                item.IsAPPUserSent = false;
                item.IsCanGrab = false;
                item.GrabStatus = 0;
                item.Save();
            }
            return list;
        }
        /// <summary>
        /// 已付款订单转抢单订单
        /// </summary>
        /// <returns></returns>
        public static Mall_Order[] GetReadyGrapAPPMall_OrderList()
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            string Name = Foresight.DataAccess.SysConfigNameDefine.NoGrabTransfer.ToString();
            var config = SysConfig.GetSysConfigByName(Name);
            int Hour = 48;
            if (config != null && !string.IsNullOrEmpty(config.Value))
            {
                int.TryParse(config.Value, out Hour);
            }
            Hour = Hour > 0 ? Hour : 12;
            conditions.Add("DATEADD(hour," + Hour + ", [PayTime])>=@PayTime");
            parameters.Add(new SqlParameter("@PayTime", DateTime.Now));
            conditions.Add("isnull([GrabStatus],0)=0");
            conditions.Add("[OrderStatus]=5");
            var list = GetList<Mall_Order>("select * from [Mall_Order] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
            foreach (var item in list)
            {
                Mall_Order.GetGrabOrderInfo(item);
                item.Save();
            }
            return list;
        }
        /// <summary>
        /// 获取待抢单推送订单列表
        /// </summary>
        /// <returns></returns>
        public static Mall_Order[] GetUnGrapAPPMall_OrderList()
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[GrabStatus]=1");
            conditions.Add("[OrderStatus]=5");
            conditions.Add("[GrabSendTime] is null");
            string cmdtext = "select * from [Mall_Order] where " + string.Join(" and ", conditions.ToArray());
            var list = GetList<Mall_Order>(cmdtext, parameters).ToArray();
            foreach (var item in list)
            {
                item.GrabSendTime = DateTime.Now;
                item.Save();
            }
            return list;
        }
        public static Mall_Order[] GetMall_OrderListByTradeNo(string TradeNo)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            if (string.IsNullOrEmpty(TradeNo))
            {
                return new Mall_Order[] { };
            }
            conditions.Add("([TradeNo]=@TradeNo or exists(select 1 from [Mall_OrderTradeNo] where [OrderID]=Mall_Order.ID and [TradeNo]=@TradeNo))");
            parameters.Add(new SqlParameter("@TradeNo", TradeNo));
            string cmdtext = "select * from [Mall_Order] where  " + string.Join(" and ", conditions.ToArray());
            return GetList<Mall_Order>(cmdtext, parameters).ToArray();
        }
        public static void UpdateMall_OrderListByRoomFeeIDList(int[] RoomFeeIDList)
        {
            if (RoomFeeIDList.Length == 0)
            {
                return;
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    List<string> conditions = new List<string>();
                    conditions.Add("isnull([IsClosed],0)=0");
                    conditions.Add("[OrderStatus]=1");
                    conditions.Add("[ID] in (select [OrderID] from [Payment_Request] where [RoomFeeID] in (" + string.Join(",", RoomFeeIDList.ToArray()) + "))");
                    string cmdtext = "update [Mall_Order] set [OrderStatus]=4,[IsClosed]=1 where  " + string.Join(" and ", conditions.ToArray());
                    helper.BeginTransaction();
                    helper.Execute(cmdtext, CommandType.Text, parameters);
                    helper.Commit();
                }
                catch (Exception)
                {
                    helper.Rollback();
                }
            }
        }
        public static void GetShareOrderCount(int UserID, out int TotalCount, out decimal TotalCost, out int TotalPeople)
        {
            TotalCount = 0;
            TotalCost = 0;
            TotalPeople = 0;
            using (SqlHelper helper = new SqlHelper())
            {
                var conditions = new List<string>();
                conditions.Add("[ShareUserID]=@UserID");
                conditions.Add("[OrderStatus]=3");
                var parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@UserID", UserID));
                string cmdtext = "select count(1) from [Mall_Order] where" + string.Join(" and ", conditions.ToArray());
                var result = helper.ExecuteScalar(cmdtext, CommandType.Text, parameters);
                if (result != null)
                {
                    int.TryParse(result.ToString(), out TotalCount);
                }

                cmdtext = "select sum(TotalCost) from [Mall_Order] where" + string.Join(" and ", conditions.ToArray());
                result = helper.ExecuteScalar(cmdtext, CommandType.Text, parameters);
                if (result != null)
                {
                    decimal.TryParse(result.ToString(), out TotalCost);
                }

                cmdtext = "select count(1) from(select UserID from [Mall_Order] where" + string.Join(" and ", conditions.ToArray()) + " group by [UserID])A";
                result = helper.ExecuteScalar(cmdtext, CommandType.Text, parameters);
                if (result != null)
                {
                    int.TryParse(result.ToString(), out TotalPeople);
                }
            }
        }
        public decimal TotalOrderCost
        {
            get
            {
                decimal cost = (this.TotalCost > 0 ? this.TotalCost : 0) + (this.ShipRateAmount > 0 ? this.ShipRateAmount : 0) - (this.CouponAmount > 0 ? this.CouponAmount : 0);
                return (cost > 0 ? cost : 0);
            }
        }
        public int TotalOrderPointCost
        {
            get
            {
                int Total_Point = 0;
                if (this.TotalSalePoint > 0)
                {
                    Total_Point += this.TotalSalePoint;
                }
                if (this.TotalVIPSalePoint > 0)
                {
                    Total_Point += this.TotalVIPSalePoint;
                }
                return Total_Point;
            }
        }
        public string TotalCostDesc
        {
            get
            {
                if (this.TotalSalePoint > 0 && this.TotalCost > 0)
                {
                    return "￥" + this.TotalCost.ToString("0.00") + " + " + this.TotalSalePoint.ToString() + "积分";
                }
                if (this.TotalVIPSalePoint > 0 && this.TotalCost > 0)
                {
                    return "￥" + this.TotalCost.ToString("0.00") + " + " + this.TotalVIPSalePoint.ToString() + "积分";
                }
                if (this.TotalSaleStaffPoint > 0 && this.TotalCost > 0)
                {
                    return "￥" + this.TotalCost.ToString("0.00") + " + " + this.TotalSaleStaffPoint.ToString() + "积分";
                }
                if (this.TotalSalePoint > 0)
                {
                    return this.TotalSalePoint.ToString() + "积分";
                }
                if (this.TotalVIPSalePoint > 0)
                {
                    return this.TotalVIPSalePoint.ToString() + "积分";
                }
                if (this.TotalSaleStaffPoint > 0)
                {
                    return this.TotalSaleStaffPoint.ToString() + "积分";
                }
                if (this.TotalCost >= 0)
                {
                    return "￥" + this.TotalCost.ToString("0.00");
                }
                return "￥0.00";
            }
        }
        public string TotalOrderCostDesc
        {
            get
            {
                if (this.TotalSalePoint > 0 && this.TotalOrderCost > 0)
                {
                    return "￥" + this.TotalOrderCost.ToString("0.00") + " + " + this.TotalSalePoint.ToString() + "积分";
                }
                if (this.TotalVIPSalePoint > 0 && this.TotalOrderCost > 0)
                {
                    return "￥" + this.TotalOrderCost.ToString("0.00") + " + " + this.TotalVIPSalePoint.ToString() + "积分";
                }
                if (this.TotalSaleStaffPoint > 0 && this.TotalOrderCost > 0)
                {
                    return "￥" + this.TotalOrderCost.ToString("0.00") + " + " + this.TotalSaleStaffPoint.ToString() + "积分";
                }
                if (this.TotalSalePoint > 0)
                {
                    return this.TotalSalePoint.ToString() + "积分";
                }
                if (this.TotalVIPSalePoint > 0)
                {
                    return this.TotalVIPSalePoint.ToString() + "积分";
                }
                if (this.TotalSaleStaffPoint > 0)
                {
                    return this.TotalSaleStaffPoint.ToString() + "积分";
                }
                if (this.TotalOrderCost >= 0)
                {
                    return "￥" + this.TotalOrderCost.ToString("0.00");
                }
                return "￥0.00";
            }
        }
        public string OrderStatusDesc
        {
            get
            {
                if (this.IsClosed)
                {
                    return "已关闭";
                }
                string desc = string.Empty;
                switch (this.OrderStatus)
                {
                    case 1:
                        desc = "待付款";
                        break;
                    case 2:
                        desc = "已发货";
                        break;
                    case 3:
                        desc = "已完成";
                        break;
                    case 4:
                        desc = "已关闭";
                        break;
                    case 5:
                        desc = "待发货";
                        break;
                    case 6:
                        desc = "退款中";
                        break;
                    case 7:
                        desc = "已退款";
                        break;
                    default:
                        break;
                }
                return desc;
            }
        }
        public string FullAddressInfo
        {
            get
            {
                string desc = string.Empty;
                if (!string.IsNullOrEmpty(this.AddressProvince))
                {
                    desc += this.AddressProvince;
                }
                if (!string.IsNullOrEmpty(this.AddressCity))
                {
                    desc += this.AddressCity;
                }
                if (!string.IsNullOrEmpty(this.AddressDistrict))
                {
                    desc += this.AddressDistrict;
                }
                if (!string.IsNullOrEmpty(this.AddressDetailInfo))
                {
                    desc += this.AddressDetailInfo;
                }
                return desc;
            }
        }
        public string ProductTypeDesc
        {
            get
            {
                string desc = string.Empty;
                switch (this.ProductTypeID)
                {
                    case 1:
                        desc = "购买商品";
                        break;
                    case 2:
                        desc = "积分兑换";
                        break;
                    case 3:
                        desc = "拼团";
                        break;
                    case 4:
                        desc = "抢购";
                        break;
                    case 10:
                        desc = "物业缴费";
                        break;
                    default:
                        break;
                }
                return desc;
            }
        }
        public string PaymentMethodDesc
        {
            get
            {
                if (string.IsNullOrEmpty(this.PaymentMethod))
                {
                    return string.Empty;
                }
                return Utility.EnumHelper.GetDescription(typeof(Utility.EnumModel.Mall_OrderPaymentMethodDefine), this.PaymentMethod);
            }
        }
        public string FinalAddressName
        {
            get
            {
                string desc = string.Empty;
                if (!string.IsNullOrEmpty(this.AddressProvince))
                {
                    desc += this.AddressProvince;
                }
                if (!string.IsNullOrEmpty(this.AddressCity))
                {
                    desc += this.AddressCity;
                }
                if (!string.IsNullOrEmpty(this.AddressDistrict))
                {
                    desc += this.AddressDistrict;
                }
                if (!string.IsNullOrEmpty(this.AddressDetailInfo))
                {
                    desc += this.AddressDetailInfo;
                }
                return desc;
            }
        }
    }
    public partial class Mall_OrderDetail : Mall_Order
    {
        [DatabaseColumn("BusinessName")]
        public string BusinessName { get; set; }
        [DatabaseColumn("ProductName")]
        public string ProductName { get; set; }
        [DatabaseColumn("BusinessContactMan")]
        public string BusinessContactMan { get; set; }

        [DatabaseColumn("BusinessBalanceAccount")]
        public string BusinessBalanceAccount { get; set; }

        [DatabaseColumn("BalanceRuleName")]
        public string BalanceRuleName { get; set; }

        [DatabaseColumn("BalanceStatus")]
        public int BalanceStatus { get; set; }
        [DatabaseColumn("BalanceDate")]
        public DateTime BalanceDate { get; set; }
        [DatabaseColumn("RoomOwnerName")]
        public string RoomOwnerName { get; set; }
        [DatabaseColumn("LoginName")]
        public string LoginName { get; set; }
        public string BalanceStatusDesc
        {
            get
            {
                string desc = "待申请";
                switch (this.BalanceStatus)
                {
                    case 1:
                        desc = "待结算";
                        break;
                    case 2:
                        desc = "已结算";
                        break;
                    case 3:
                        desc = "审核未通过";
                        break;
                    default:
                        break;
                }
                return desc;
            }
        }
        public string FinalTitle
        {
            get
            {
                string businessName = this.BusinessName;
                if (string.IsNullOrEmpty(this.BusinessName))
                {
                    businessName = "自营";
                }
                return this.ProductName + "(" + businessName + ")";
            }
        }
        public decimal TotalRestCost { get; set; }
        public decimal TotalBasicCost { get; set; }
        public string FinalBusinessName
        {
            get
            {
                if (string.IsNullOrEmpty(this.BusinessName))
                {
                    if (this.BusinessID <= 0)
                    {
                        this.BusinessName = "福顺居自营";
                    }
                    else
                    {
                        this.BusinessName = "商户已删除";
                    }
                }
                return this.BusinessName;
            }
        }
        public static Ui.DataGrid GetMall_OrderDetailGridByKeywords(string Keywords, DateTime StartTime, DateTime EndTime, int BalanceStatus, long startRowIndex, int pageSize, int BusinessBalanceID, int BusinessType)
        {
            long totalRows = 0;
            string OrderBy = " order by CompleteTime desc,PayTime desc";
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[TotalCost]>0");
            conditions.Add("[ProductTypeID]!=10");
            conditions.Add("[OrderStatus]=3");
            //conditions.Add("[BusinessID] in (select [ID] from [Mall_Business])");
            if (BusinessBalanceID > 0)
            {
                conditions.Add("[ID] in (select [OrderID] from [Mall_BusinessBalance_Order] where [BusinessBalanceID]=@BusinessBalanceID)");
                parameters.Add(new SqlParameter("@BusinessBalanceID", BusinessBalanceID));
            }
            if (BusinessType == 1)
            {
                conditions.Add("([BusinessID]=0 or [BusinessID] is null or [BusinessID] in (select [ID] from [Mall_Business] where BusinessName like '%自营%'))");
            }
            if (BusinessType == 2)
            {
                conditions.Add("[BusinessID]>0");
            }
            if (BalanceStatus == 1)
            {
                conditions.Add("[ID] not in (select [OrderID] from [Mall_BusinessBalance_Order] where [BusinessBalanceID] in (select [ID] from [Mall_BusinessBalance] where [BalanceStatus] in (1,2)))");
            }
            else if (BalanceStatus == 2)
            {
                conditions.Add("[ID] in (select [OrderID] from [Mall_BusinessBalance_Order] where [BusinessBalanceID] in (select [ID] from [Mall_BusinessBalance] where [BalanceStatus] in (1,2)))");
            }
            if (StartTime > DateTime.MinValue)
            {
                conditions.Add("[AddTime]>=@StartTime");
                parameters.Add(new SqlParameter("@StartTime", StartTime));
            }
            if (EndTime > DateTime.MinValue)
            {
                conditions.Add("[AddTime]<=@EndTime");
                parameters.Add(new SqlParameter("@EndTime", EndTime));
            }
            if (!string.IsNullOrEmpty(Keywords))
            {
                conditions.Add("([ID] in (select [OrderID] from [Mall_OrderItem] where [ProductName] like @keywords) or [BusinessID] in (select [ID] from [Mall_Business] where [BusinessName] like @keywords))");
                parameters.Add(new SqlParameter("@keywords", "%" + Keywords + "%"));
            }
            string fieldList = "A.*";
            string Statement = " from (select [Mall_Order].*,[Mall_Business].BusinessName,[Mall_Business].ContactName as BusinessContactMan from [Mall_Order] left join [Mall_Business] on [Mall_Business].ID=[Mall_Order].BusinessID)A where  " + string.Join(" and ", conditions.ToArray());
            Mall_OrderDetail[] list = GetList<Mall_OrderDetail>("select " + fieldList + Statement + " " + OrderBy, parameters).ToArray();
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            if (list.Length == 0)
            {
                dg.rows = list;
                dg.total = totalRows;
                dg.page = pageSize;
                return dg;
            }
            var balance_list = GetList<Mall_BusinessBalance>("select * from [Mall_BusinessBalance] where [ID] in (select [BusinessBalanceID] from [Mall_BusinessBalance_Order] where [OrderID] in (select [ID] from [Mall_Order] where " + string.Join(" and ", conditions.ToArray()) + "))", parameters);
            var balance_order_list = GetList<Mall_BusinessBalance_Order>("select * from [Mall_BusinessBalance_Order] where [OrderID] in (select [ID] from [Mall_Order] where " + string.Join(" and ", conditions.ToArray()) + ")", parameters);
            var rule_list = Mall_BalanceRule.GetMall_BalanceRules().ToArray();
            var orderItemList = Mall_OrderItemDetail.GetMall_OrderItemDetailListByOrderIDList(list.Select(p => p.ID).ToList());
            foreach (var item in list)
            {
                var my_balance_order_list = balance_order_list.Where(p => p.OrderID == item.ID).ToArray();
                var my_balance_list = balance_list.Where(p => my_balance_order_list.Select(q => q.BusinessBalanceID).ToList().Contains(p.ID)).ToArray();
                var my_balance = my_balance_list.FirstOrDefault(p => p.BalanceStatus == 2);
                if (my_balance == null)
                {
                    my_balance = my_balance_list.FirstOrDefault(p => p.BalanceStatus == 1);
                }
                if (my_balance == null)
                {
                    my_balance = my_balance_list.FirstOrDefault(p => p.BalanceStatus == 2);
                }
                if (my_balance != null)
                {
                    var my_rule = rule_list.FirstOrDefault(p => p.ID == my_balance.BalanceRuleID);
                    item.BusinessBalanceAccount = my_balance.BusinessAccount;
                    if (my_rule != null)
                    {
                        item.BalanceRuleName = my_rule.Title;
                    }
                    item.BalanceStatus = my_balance.BalanceStatus;
                    if (item.BalanceStatus == 2)
                    {
                        item.BalanceDate = my_balance.ApproveTime;
                    }
                }
                var myItemList = orderItemList.Where(p => p.OrderID == item.ID).ToArray();
                item.TotalRestCost = myItemList.Sum(p => p.TotalRestCost);
                item.TotalBasicCost = myItemList.Sum(p => p.TotalBasicCost);
            }
            var footerItem = new Mall_OrderDetail();
            footerItem.TotalBasicCost = list.Sum(p => p.TotalBasicCost);
            footerItem.TotalRestCost = list.Sum(p => p.TotalRestCost);
            footerItem.TotalCost = list.Sum(p => p.TotalCost);
            var footers = new List<Mall_OrderDetail>();
            footers.Add(footerItem);
            var dataList = list.Skip((int)startRowIndex).Take(pageSize).ToArray();
            dg.rows = dataList;
            dg.total = dataList.Length;
            dg.page = pageSize;
            dg.footer = footers;
            return dg;
        }
        public static Ui.DataGrid GetMall_OrderDetailRoomOwnerGrid(int RoomID, long startRowIndex, int pageSize, DateTime StartTime, DateTime EndTime)
        {
            long totalRows = 0;
            string OrderBy = " order by CompleteTime desc,PayTime desc";
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[TotalCost]>0");
            conditions.Add("[ProductTypeID]!=10");
            conditions.Add("[OrderStatus]=3");
            if (StartTime > DateTime.MinValue)
            {
                conditions.Add("Convert(varchar(100),[AddTime],23)>=@StartTime");
                parameters.Add(new SqlParameter("@StartTime", StartTime));
            }
            if (EndTime > DateTime.MinValue)
            {
                conditions.Add("Convert(varchar(100),[AddTime],23)<=@EndTime");
                parameters.Add(new SqlParameter("@EndTime", EndTime));
            }
            if (RoomID > 0)
            {
                conditions.Add("[UserID] in (select [UserID] from [Mall_UserProject] where [ProjectID]=@ProjectID and isnull([IsDisable],0)=0)");
                parameters.Add(new SqlParameter("@ProjectID", RoomID));
            }
            string fieldList = "A.*";
            string Statement = " from (select [Mall_Order].*,(select top 1 RelationName from [RoomPhoneRelation] where [UserID]=Mall_Order.UserID) as RoomOwnerName,[User].LoginName from [Mall_Order] left join [User] on [User].UserID=[Mall_Order].UserID)A where  " + string.Join(" and ", conditions.ToArray());
            Mall_OrderDetail[] list = GetList<Mall_OrderDetail>(fieldList, Statement, parameters, OrderBy, startRowIndex, pageSize, out totalRows).ToArray();
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
    }
    public partial class Mall_OrderAnalysis : EntityBaseReadOnly
    {
        [DatabaseColumn("TotalCount")]
        public int TotalCount { get; set; }
        [DatabaseColumn("TotalCost")]
        public decimal TotalCost { get; set; }
        /// <summary>
        /// 1-待付款 2-已发货 3-已完成 4-已关闭 5-待发货 6-退款中 7-已退款
        /// </summary>
        [DatabaseColumn("OrderStatus")]
        public int OrderStatus { get; set; }

        [DatabaseColumn("UserID")]
        public int UserID { get; set; }
        [DatabaseColumn("ShareUserName")]
        public string ShareUserName { get; set; }
        [DatabaseColumn("LoginName")]
        public string LoginName { get; set; }
        [DatabaseColumn("AllParentID")]
        public string AllParentID { get; set; }
        public string ProjectName { get; set; }
        public string FinalUserName
        {
            get
            {
                if (!string.IsNullOrEmpty(this.ShareUserName))
                {
                    return this.ShareUserName;
                }
                return this.LoginName;
            }
        }
        public static Mall_OrderAnalysis[] GetMall_OrderAnalysisList(DateTime StartTime, DateTime EndTime)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("ProductTypeID!=10");
            conditions.Add("OrderStatus=3");
            if (StartTime > DateTime.MinValue)
            {
                conditions.Add("Convert(varchar(100),[AddTime],23)>=@StartTime");
                parameters.Add(new SqlParameter("@StartTime", StartTime));
            }
            if (EndTime > DateTime.MinValue)
            {
                conditions.Add("Convert(varchar(100),[AddTime],23)<=@EndTime");
                parameters.Add(new SqlParameter("@EndTime", EndTime));
            }
            string cmdtext = "select count(1) as TotalCount,sum(TotalCost) as TotalCost,[UserID] from Mall_Order where " + string.Join(" and ", conditions.ToArray()) + "  group by [UserID]";
            Mall_OrderAnalysis[] list = GetList<Mall_OrderAnalysis>(cmdtext, parameters).ToArray();
            return list;
        }
        /// <summary>
        /// BalanceStatus:1-可提现 2-结算中 3-已提现 4-交易中
        /// </summary>
        /// <param name="BusinessID"></param>
        /// <param name="totaldays"></param>
        /// <param name="BalanceStatus"></param>
        /// <returns></returns>
        public static decimal GetMall_OrderBalanceCountByBusinessID(int BusinessID, int minday, int maxday, int BalanceStatus)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("ProductTypeID!=10");
            conditions.Add("isnull(IsClosed,0)=0");
            conditions.Add("(BusinessID=@BusinessID or ID in (select [OrderID] from [Mall_OrderItem] where BusinessID=@BusinessID))");
            parameters.Add(new SqlParameter("@BusinessID", BusinessID));
            if (BalanceStatus == 1)
            {
                conditions.Add("[OrderStatus]=3");
                conditions.Add("[ID] not in (select [OrderID] from [Mall_BusinessBalance_Order] where [BusinessBalanceID] in (select [ID] from [Mall_BusinessBalance] where [BalanceStatus] in (1,2)))");
            }
            else if (BalanceStatus == 2)
            {
                conditions.Add("[OrderStatus]=3");
                conditions.Add("[ID] in (select [OrderID] from [Mall_BusinessBalance_Order] where [BusinessBalanceID] in (select [ID] from [Mall_BusinessBalance] where [BalanceStatus]=1))");
            }
            else if (BalanceStatus == 3)
            {
                conditions.Add("[OrderStatus]=3");
                conditions.Add("[ID] in (select [OrderID] from [Mall_BusinessBalance_Order] where [BusinessBalanceID] in (select [ID] from [Mall_BusinessBalance] where [BalanceStatus]=1))");
            }
            else if (BalanceStatus == 4)
            {
                conditions.Add("[OrderStatus] in (2,5)");
            }
            if (minday > 0)
            {
                conditions.Add("[AddTime]<@AddTime");
                parameters.Add(new SqlParameter("@AddTime", DateTime.Today.AddDays(-minday)));
            }
            if (maxday > 0)
            {
                conditions.Add("[AddTime]>=@AddTime");
                parameters.Add(new SqlParameter("@AddTime", DateTime.Today.AddDays(-maxday)));
            }
            string cmdtext = "select sum(TotalCost) as TotalCost from Mall_Order where " + string.Join(" and ", conditions.ToArray());
            decimal total = 0;
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    var result = helper.ExecuteScalar(cmdtext, CommandType.Text, parameters);
                    if (result != null)
                    {
                        decimal.TryParse(result.ToString(), out total);
                    }
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    //Utility.LogHelper.WriteError("Mall_Order.cs", "GetMall_OrderBalanceCountByBusinessID", ex);
                    helper.Rollback();
                }
            }
            return total;
        }
        public static Mall_OrderAnalysis[] GetMall_OrderGroupCountByBusinessID(int BusinessID)
        {
            if (BusinessID <= 0)
            {
                return new Mall_OrderAnalysis[] { };
            }
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("([BusinessID]=@BusinessID or [ID] in (select [OrderID] from [Mall_OrderItem] where [BusinessID]=@BusinessID))");
            parameters.Add(new SqlParameter("@BusinessID", BusinessID));
            conditions.Add("(isnull([IsClosed],0)=0)");
            string cmdtext = "select count(1) as TotalCount,OrderStatus from [Mall_Order] where " + string.Join(" and ", conditions.ToArray()) + " group by [OrderStatus]";
            return GetList<Mall_OrderAnalysis>(cmdtext, parameters).ToArray();
        }
        public static Ui.DataGrid GetShareMall_OrderAnalysisGrid(string Keywords, DateTime StartTime, DateTime EndTime, long startRowIndex, int pageSize, int OrderStatus)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("IsShareOrder=1");
            conditions.Add("isnull([IsClosed],0)=0");
            conditions.Add("[OrderStatus] not in (4,6,7)");
            if (OrderStatus == 1)
            {
                conditions.Add("[OrderStatus]=1");
            }
            else if (OrderStatus == 2)
            {
                conditions.Add("[OrderStatus]!=1");
            }
            if (!string.IsNullOrEmpty(Keywords))
            {
                conditions.Add("[UserID] in (select [UserID] from [User] where LoginName like @Keywords)");
                parameters.Add(new SqlParameter("@Keywords", "%" + Keywords + "%"));
            }
            if (StartTime > DateTime.MinValue)
            {
                conditions.Add("Convert(varchar(100),[AddTime],23)>=@StartTime");
                parameters.Add(new SqlParameter("@StartTime", StartTime));
            }
            if (EndTime > DateTime.MinValue)
            {
                conditions.Add("Convert(varchar(100),[AddTime],23)<=@EndTime");
                parameters.Add(new SqlParameter("@EndTime", EndTime));
            }
            long totalRows = 0;
            string fieldList = "A.*";
            string Statement = " from (select B.*,[User].LoginName,(select top 1 [RelationName] from [RoomPhoneRelation] where [UserID]=B.UserID and RelationName is not null) as ShareUserName,(select top 1 [AllParentID] from [Project] where exists(select 1 from [RoomPhoneRelation] where [UserID]=B.UserID and RelationName is not null and [RoomID]=[Project].ID)) as AllParentID from (select count(1) as TotalCount,sum(TotalCost) as TotalCost,[ShareUserID] as [UserID] from Mall_Order where " + string.Join(" and ", conditions.ToArray()) + " group by [ShareUserID])B left join [User] on [User].UserID=B.UserID)A";
            Mall_OrderAnalysis[] list = GetList<Mall_OrderAnalysis>(fieldList, Statement, parameters, "order by [UserID]", startRowIndex, pageSize, out totalRows).ToArray();
            if (list.Length > 0)
            {
                var projectList = Project.GetProjectByParentID(1);
                list = list.Select(p =>
                {
                    var myProject = projectList.FirstOrDefault(q =>
                    {
                        return !string.IsNullOrEmpty(p.AllParentID) && p.AllParentID.Contains("," + q.ID + ",");
                    });
                    p.ProjectName = myProject != null ? myProject.Name : string.Empty;
                    return p;
                }).ToArray();
            }
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
        protected override void EnsureParentProperties()
        {
            throw new NotImplementedException();
        }
    }
}
