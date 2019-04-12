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
    /// This object represents the properties and methods of a Mall_UserPoint.
    /// </summary>
    public partial class Mall_UserPoint : EntityBase
    {
        public static Mall_UserPoint[] GetMall_UserPointListByUserIDList(List<int> UserIDList)
        {
            if (UserIDList.Count == 0)
            {
                return new Mall_UserPoint[] { };
            }
            List<SqlParameter> parameters = new List<SqlParameter>();
            string cmdtext = "select * from  [Mall_UserPoint] where UserID in (" + string.Join(",", UserIDList.ToArray()) + ") and [PointStatus]=1";
            return GetList<Mall_UserPoint>(cmdtext, parameters).ToArray();
        }
        public static decimal GetMall_UserPointBalance(int UserID)
        {
            if (UserID <= 0)
            {
                return 0;
            }
            decimal balance = 0;
            using (SqlHelper helper = new SqlHelper())
            {
                List<SqlParameter> parameters = new List<SqlParameter>();
                string cmdtext = @"select sum(PointValue) from [Mall_UserPoint] where UserID=@UserID and [PointStatus]=1";
                parameters.Add(new SqlParameter("@UserID", UserID));
                var balanceobj = helper.ExecuteScalar(cmdtext, CommandType.Text, parameters);
                if (balanceobj != null)
                {
                    decimal.TryParse(balanceobj.ToString(), out balance);
                }
            }
            return balance;
        }
        public static Mall_UserPoint[] GetMall_UserPointList(int UserID)
        {
            if (UserID <= 0)
            {
                return new Mall_UserPoint[] { };
            }
            List<SqlParameter> parameters = new List<SqlParameter>();
            string cmdtext = "select * from  [Mall_UserPoint] where UserID=@UserID and [PointStatus]=1 order by AddTime desc";
            parameters.Add(new SqlParameter("@UserID", UserID));
            return GetList<Mall_UserPoint>(cmdtext, parameters).ToArray();
        }
        public static Mall_UserPoint GetMall_UserPointByOrderID(int OrderID, int CategoryType, SqlHelper helper = null)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            string cmdtext = "select * from  [Mall_UserPoint] where RelatedID=@OrderID and [CategoryType]=@CategoryType";
            parameters.Add(new SqlParameter("@OrderID", OrderID));
            parameters.Add(new SqlParameter("@CategoryType", CategoryType));
            if (helper == null)
                return GetOne<Mall_UserPoint>(cmdtext, parameters);
            return GetOne<Mall_UserPoint>(cmdtext, parameters, helper);
        }
        public static Mall_UserPoint Insert_Mall_UserPoint(int UserID, int PointType, decimal OrderTotalAmount, string Title, string Summary, int CategoryType, string AddUserName, int PointStatus, string TradeNo, int OrderID, int PointValue = 0, int RelatedID = 0, int AmountRuleID = 0, bool IsSent = true, DateTime? IsReadySendTime = null)
        {
            Mall_UserPoint data = null;
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    data = Insert_Mall_UserPoint(UserID, PointType, OrderTotalAmount, Title, Summary, CategoryType, AddUserName, PointStatus, TradeNo, OrderID, PointValue: PointValue, RelatedID: RelatedID, AmountRuleID: AmountRuleID, helper: helper, IsSent: IsSent, IsReadySendTime: IsReadySendTime);
                    helper.Commit();
                }
                catch (Exception)
                {
                    helper.Rollback();
                    return null;
                }
            }
            return data;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="PointType">1-充值 2-消费</param>
        /// <param name="OrderTotalAmount"></param>
        /// <param name="Title"></param>
        /// <param name="Summary"></param>
        /// <param name="CategoryType">1-积分购买消费 2-购买商品赠与 3-积分购买退货返回 4-购买商品退货扣除 5-充值赠与 6-消费赠与</param>
        /// <param name="AddUserName"></param>
        /// <param name="PointStatus">0-未入账 1-已入账</param>
        /// <param name="TradeNo"></param>
        /// <param name="OrderID"></param>
        /// <param name="PointValue"></param>
        /// <param name="RelatedID"></param>
        public static Mall_UserPoint Insert_Mall_UserPoint(int UserID, int PointType, decimal OrderTotalAmount, string Title, string Summary, int CategoryType, string AddUserName, int PointStatus, string TradeNo, int OrderID, SqlHelper helper, int PointValue = 0, int RelatedID = 0, int AmountRuleID = 0, bool IsSent = true, DateTime? IsReadySendTime = null)
        {
            if (UserID <= 0)
            {
                return null;
            }
            if (CategoryType == 3)
            {
                var mall_point = Mall_UserPoint.GetMall_UserPointByOrderID(RelatedID, 1, helper: helper);
                if (mall_point == null)
                {
                    return null;
                }
                if (mall_point.PointStatus == 0)
                {
                    mall_point.Delete(helper);
                    return null;
                }
                PointValue = -mall_point.PointValue;
            }
            if (CategoryType == 7)
            {
                var mall_point = Mall_UserPoint.GetMall_UserPointByOrderID(RelatedID, 6, helper: helper);
                if (mall_point == null)
                {
                    return null;
                }
                if (mall_point.PointStatus == 0)
                {
                    mall_point.Delete(helper);
                    return null;
                }
                PointValue = -mall_point.PointValue;
            }
            var data = new Mall_UserPoint();
            data.UserID = UserID;
            data.PointType = PointType;
            data.PointValue = PointValue;
            data.Title = Title;
            data.Summary = Summary;
            data.CategoryType = CategoryType;
            data.AddUserName = AddUserName;
            data.PointStatus = 0;
            data.AddTime = DateTime.Now;
            data.TradeNo = TradeNo;
            data.RelatedID = RelatedID;
            data.AmountRuleID = AmountRuleID;
            data.IsSent = IsSent;
            if (data.IsSent)
            {
                data.SentTime = DateTime.Now;
                data.PointStatus = 1;
            }
            if (PointStatus == 0)
            {
                data.PointStatus = PointStatus;
            }
            if (IsReadySendTime.HasValue)
            {
                data.IsReadySendTime = Convert.ToDateTime(IsReadySendTime);
            }
            data.Save(helper);
            return data;
        }
        public static Mall_UserPoint[] GetUnSentMall_UserPointList()
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            string cmdtext = "select * from  [Mall_UserPoint] where isnull(IsSent,0)=0 and [PointStatus]=0 and ([IsReadySendTime] is null or [IsReadySendTime]<=@Now);";
            parameters.Add(new SqlParameter("@Now", DateTime.Now));
            return GetList<Mall_UserPoint>(cmdtext, parameters).ToArray();
        }
        public static Ui.DataGrid GetMall_UserPointGridByKeywords(string Keywords, DateTime StartTime, DateTime EndTime, string orderBy, long startRowIndex, int pageSize)
        {
            long totalRows = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("([UserID] in (select [UserID] from [Mall_UserPoint]) or [UserID] in (select [UserID] from [Mall_UserBalance]) or [UserID] in (select [UserID] from [Mall_CouponUser]))");
            if (!string.IsNullOrEmpty(Keywords))
            {
                conditions.Add("([NickName] like @Keywords)");
                parameters.Add(new SqlParameter("@Keywords", "%" + Keywords + "%"));
            }
            string fieldList = "[User].* ";
            string Statement = " from [User] where  " + string.Join(" and ", conditions.ToArray());
            var user_list = GetList<User>(fieldList, Statement, parameters, orderBy, startRowIndex, pageSize, out totalRows).ToArray();
            var user_level_list = Mall_UserLevel.GetMall_UserLevels();
            List<int> UserIDList = user_list.Select(p => p.UserID).ToList();

            var point_list = Mall_UserAccountDetail.GetMall_UserPointBalanceList(StartTime, EndTime);
            var balance_list = Mall_UserAccountDetail.GetMall_UserAmountBalanceList(StartTime, EndTime);
            var coupon_list = Mall_CouponUser.GetMall_CouponUserListByUserIDList(UserIDList);
            if (StartTime > DateTime.MinValue)
            {
                coupon_list = coupon_list.Where(p => p.AddTime >= StartTime).ToArray();
            }
            if (EndTime > DateTime.MinValue)
            {
                coupon_list = coupon_list.Where(p => p.AddTime <= EndTime).ToArray();
            }
            var list = new List<Dictionary<string, object>>();
            foreach (var user in user_list)
            {
                var my_user_level = user_level_list.FirstOrDefault(p => p.ID == user.UserLevelID);
                var my_point_list = point_list.Where(p => p.UserID == user.UserID).ToArray();
                var my_balance_list = balance_list.Where(p => p.UserID == user.UserID).ToArray();
                var my_coupon_list = coupon_list.Where(p => p.UserID == user.UserID).ToArray();
                decimal CurrentConsumeAmount = my_balance_list.Sum(p => p.Total);
                decimal AllConsumeAmount = my_balance_list.Where(p => p.IncomeType == 1).Sum(p => p.Total);

                decimal CurrentPoint = my_point_list.Sum(p => p.Total);
                decimal AllPoint = my_point_list.Where(p => p.IncomeType == 1).Sum(p => p.Total);

                decimal CurrentFuShunQuan = coupon_list.Where(p => !p.IsUsed).ToArray().Length;
                decimal AllFuShunQuan = coupon_list.ToArray().Length;

                var dic = new Dictionary<string, object>();
                dic["NickName"] = string.IsNullOrEmpty(user.NickName) ? user.LoginName : user.NickName;
                dic["MemberLevel"] = my_user_level == null ? "普通用户" : "合伙人用户(" + my_user_level.Name + ")";
                dic["CurrentConsumeAmount"] = CurrentConsumeAmount;
                dic["AllConsumeAmount"] = AllConsumeAmount;
                dic["CurrentPoint"] = CurrentPoint;
                dic["AllPoint"] = AllPoint;
                dic["CurrentFuShunQuan"] = CurrentFuShunQuan;
                dic["AllFuShunQuan"] = AllFuShunQuan;
                list.Add(dic);
            }
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = user_list.Length;
            dg.page = pageSize;
            return dg;
        }
    }
    public partial class Mall_UserAccountDetail : EntityBaseReadOnly
    {
        [DatabaseColumn("UserID")]
        public int UserID { get; set; }
        [DatabaseColumn("IncomeType")]
        public int IncomeType { get; set; }
        [DatabaseColumn("Total")]
        public decimal Total { get; set; }
        public static Mall_UserAccountDetail[] GetMall_UserPointBalanceList(DateTime? StartTime = null, DateTime? EndTime = null)
        {
            var parameters = new List<SqlParameter>();
            var conditions = new List<string>();
            conditions.Add("[PointStatus]=1");
            if (StartTime != null && StartTime.HasValue)
            {
                DateTime startTime = Convert.ToDateTime(StartTime);
                if (startTime > DateTime.MinValue)
                {
                    conditions.Add("[AddTime]>=@startTime");
                    parameters.Add(new SqlParameter("@startTime", startTime));
                }
            }
            if (EndTime != null && EndTime.HasValue)
            {
                DateTime endTime = Convert.ToDateTime(EndTime);
                if (endTime > DateTime.MinValue)
                {
                    conditions.Add("[AddTime]<=@endTime");
                    parameters.Add(new SqlParameter("@endTime", endTime));
                }
            }
            string cmdtext = "select [UserID],[PointType] as IncomeType, sum(PointValue) as Total from [Mall_UserPoint] where " + string.Join(" and ", conditions.ToArray()) + " group by [UserID],[PointType]";
            return GetList<Mall_UserAccountDetail>(cmdtext, parameters).ToArray();
        }
        public static Mall_UserAccountDetail[] GetMall_UserAmountBalanceList(DateTime? StartTime = null, DateTime? EndTime = null)
        {
            var parameters = new List<SqlParameter>();
            var conditions = new List<string>();
            conditions.Add("[BalanceStatus]=1");
            if (StartTime != null && StartTime.HasValue)
            {
                DateTime startTime = Convert.ToDateTime(StartTime);
                if (startTime > DateTime.MinValue)
                {
                    conditions.Add("[AddTime]>=@startTime");
                    parameters.Add(new SqlParameter("@startTime", startTime));
                }
            }
            if (EndTime != null && EndTime.HasValue)
            {
                DateTime endTime = Convert.ToDateTime(EndTime);
                if (endTime > DateTime.MinValue)
                {
                    conditions.Add("[AddTime]<=@endTime");
                    parameters.Add(new SqlParameter("@endTime", endTime));
                }
            }
            string cmdtext = "select [UserID],[BalanceType] as IncomeType, sum(BalanceValue) as Total from [Mall_UserBalance] where " + string.Join(" and ", conditions.ToArray()) + " group by [UserID],[BalanceType]";
            return GetList<Mall_UserAccountDetail>(cmdtext, new List<SqlParameter>()).ToArray();
        }
        public static Mall_UserAccountDetail[] GetMall_UserJiXiaoPointList(DateTime? StartTime = null, DateTime? EndTime = null)
        {
            var parameters = new List<SqlParameter>();
            var conditions = new List<string>();
            conditions.Add("[PointStatus]=1");
            if (StartTime != null && StartTime.HasValue)
            {
                DateTime startTime = Convert.ToDateTime(StartTime);
                if (startTime > DateTime.MinValue)
                {
                    conditions.Add("[AddTime]>=@startTime");
                    parameters.Add(new SqlParameter("@startTime", startTime));
                }
            }
            if (EndTime != null && EndTime.HasValue)
            {
                DateTime endTime = Convert.ToDateTime(EndTime);
                if (endTime > DateTime.MinValue)
                {
                    conditions.Add("[AddTime]<=@endTime");
                    parameters.Add(new SqlParameter("@endTime", endTime));
                }
            }
            string cmdtext = "select [UserID],[PointType] as IncomeType, sum(PointValue) as Total from [Mall_UserJiXiaoPoint] where " + string.Join(" and ", conditions.ToArray()) + " group by [UserID],[PointType]";
            return GetList<Mall_UserAccountDetail>(cmdtext, new List<SqlParameter>()).ToArray();
        }
        protected override void EnsureParentProperties()
        {
        }
    }
}
