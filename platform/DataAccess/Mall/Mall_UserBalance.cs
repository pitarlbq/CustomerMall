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
    /// This object represents the properties and methods of a Mall_UserBalance.
    /// </summary>
    public partial class Mall_UserBalance : EntityBase
    {
        public static Mall_UserBalance[] GetMall_UserBalanceListByUserIDList(List<int> UserIDList)
        {
            if (UserIDList.Count == 0)
            {
                return new Mall_UserBalance[] { };
            }
            List<SqlParameter> parameters = new List<SqlParameter>();
            string cmdtext = "select * from  [Mall_UserBalance] where UserID in (" + string.Join(",", UserIDList.ToArray()) + ") and [BalanceStatus]=1";
            return GetList<Mall_UserBalance>(cmdtext, parameters).ToArray();
        }
        public static Mall_UserBalance[] GetMall_UserBalanceList(int UserID)
        {
            if (UserID <= 0)
            {
                return new Mall_UserBalance[] { };
            }
            List<SqlParameter> parameters = new List<SqlParameter>();
            string cmdtext = "select * from  [Mall_UserBalance] where UserID=@UserID and [BalanceStatus]=1 order by AddTime desc";
            parameters.Add(new SqlParameter("@UserID", UserID));
            return GetList<Mall_UserBalance>(cmdtext, parameters).ToArray();
        }
        public static decimal GetMall_UserBalanceBalance(int UserID)
        {
            if (UserID <= 0)
            {
                return 0;
            }
            decimal balance = 0;
            using (SqlHelper helper = new SqlHelper())
            {
                List<SqlParameter> parameters = new List<SqlParameter>();
                string cmdtext = @"select sum(BalanceValue) from [Mall_UserBalance] where UserID=@UserID and [BalanceStatus]=1";
                parameters.Add(new SqlParameter("@UserID", UserID));
                var balanceobj = helper.ExecuteScalar(cmdtext, CommandType.Text, parameters);
                if (balanceobj != null)
                {
                    decimal.TryParse(balanceobj.ToString(), out balance);
                }
            }
            return balance;
        }
        public static decimal GetMall_UserBalanceALLIncomingAmount(int UserID)
        {
            if (UserID <= 0)
            {
                return 0;
            }
            decimal balance = 0;
            using (SqlHelper helper = new SqlHelper())
            {
                List<SqlParameter> parameters = new List<SqlParameter>();
                string cmdtext = @"select sum(BalanceValue) from [Mall_UserBalance] where UserID=@UserID and [BalanceStatus]=1 and ([CategoryType]=2 or [CategoryType]=3)";
                parameters.Add(new SqlParameter("@UserID", UserID));
                var balanceobj = helper.ExecuteScalar(cmdtext, CommandType.Text, parameters);
                if (balanceobj != null)
                {
                    decimal.TryParse(balanceobj.ToString(), out balance);
                }
            }
            return balance;
        }
        public static Mall_UserBalance GetMall_UserBalanceByOrderID(int OrderID, int CategoryType, SqlHelper helper = null)
        {

            List<SqlParameter> parameters = new List<SqlParameter>();
            string cmdtext = "select * from  [Mall_UserBalance] where RelatedID=@OrderID and [CategoryType]=@CategoryType";
            parameters.Add(new SqlParameter("@OrderID", OrderID));
            parameters.Add(new SqlParameter("@CategoryType", CategoryType));
            if (helper == null)
            {
                return GetOne<Mall_UserBalance>(cmdtext, parameters);
            }
            return GetOne<Mall_UserBalance>(cmdtext, parameters, helper);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="BalanceType">1-充值 2-消费</param>
        /// <param name="BalanceValue"></param>
        /// <param name="Title"></param>
        /// <param name="Summary"></param>
        /// <param name="CategoryType">1-购买商品消费 2-微信充值 3-支付宝充值 4-订单退款返还 5-充值赠与 6-消费赠与 7-退款消费赠与取消 8-线下充值 9-业主结算</param>
        /// <param name="AddUserName"></param>
        /// <param name="BalanceStatus">0-未入账 1-已入账</param>
        /// <param name="TradeNo"></param>
        /// <param name="helper"></param>
        public static void Insert_Mall_UserBalance(int UserID, int BalanceType, decimal BalanceValue, string Title, string Summary, int CategoryType, string AddUserName, int BalanceStatus, string TradeNo, int RelatedID = 0, int AmountRuleID = 0, SqlHelper helper = null, string PaymentMethod = "", bool IsSent = true, DateTime? IsReadySendTime = null, bool IsManualIncoming = false, int UserLevelApproveID = 0, string Remark = "")
        {
            if (UserID <= 0)
            {
                return;
            }
            if (CategoryType == 4)
            {
                var mall_balance = Mall_UserBalance.GetMall_UserBalanceByOrderID(RelatedID, 1, helper: helper);
                if (mall_balance == null)
                {
                    return;
                }
                if (mall_balance.BalanceStatus == 0)
                {
                    if (helper == null)
                    {
                        mall_balance.Delete();
                    }
                    else
                    {
                        mall_balance.Delete(helper);
                    }
                    return;
                }
                BalanceValue = -mall_balance.BalanceValue;
            }
            if (CategoryType == 7)
            {
                var mall_balance = Mall_UserBalance.GetMall_UserBalanceByOrderID(RelatedID, 6, helper: helper);
                if (mall_balance == null)
                {
                    return;
                }
                if (mall_balance.BalanceStatus == 0)
                {
                    if (helper == null)
                    {
                        mall_balance.Delete();
                    }
                    else
                    {
                        mall_balance.Delete(helper);
                    }
                    return;
                }
                BalanceValue = -mall_balance.BalanceValue;
            }
            var data = new Mall_UserBalance();
            data.UserID = UserID;
            data.BalanceType = BalanceType;
            data.BalanceValue = BalanceValue;
            data.Title = Title;
            data.Summary = Summary;
            data.CategoryType = CategoryType;
            data.AddUserName = AddUserName;
            data.BalanceStatus = 0;
            data.AddTime = DateTime.Now;
            data.TradeNo = TradeNo;
            data.RelatedID = RelatedID;
            data.PaymentMethod = PaymentMethod;
            data.IsSent = IsSent;
            data.IsManualIncoming = IsManualIncoming;
            data.UserLevelApproveID = UserLevelApproveID;
            data.Remark = Remark;
            if (data.IsSent)
            {
                data.SentTime = DateTime.Now;
                data.BalanceStatus = 1;
            }
            if (BalanceStatus == 0)
            {
                data.BalanceStatus = BalanceStatus;
            }
            if (IsReadySendTime.HasValue)
            {
                data.IsReadySendTime = Convert.ToDateTime(IsReadySendTime);
            }
            if (helper == null)
            {
                data.Save();
                return;
            }
            data.Save(helper);
        }
        public static Mall_UserBalance GetMall_UserBalanceByTradeNo(string TradeNo)
        {
            List<SqlParameter> paramenters = new List<SqlParameter>();
            paramenters.Add(new SqlParameter("@TradeNo", TradeNo));
            return GetOne<Mall_UserBalance>("select * from [Mall_UserBalance] where TradeNo=@TradeNo", paramenters);
        }
        /// <summary>
        /// 充值处理
        /// </summary>
        /// <param name="BalanceStatus"></param>
        /// <param name="TradeNo"></param>
        /// <param name="payment"></param>
        /// <param name="AmountType"></param>
        public static void UpdateMall_UserBalanceStatus(int BalanceStatus, string TradeNo, Payment payment = null, int AmountType = 1, string PaymentMethod = "")
        {
            //充值赠与处理
            Dictionary<string, object> BackObject = new Dictionary<string, object>();
            Mall_UserBalance data = null;
            if (BalanceStatus == 1)
            {
                data = GetMall_UserBalanceByTradeNo(TradeNo);
                if (data == null)
                {
                    return;
                }
                Mall_AmountRule.GetBackAmountPoint(data.BalanceValue, out BackObject, new int[] { }, new int[] { }, AmountType: AmountType, UserID: data.UserID);
                //AmountRuleID = Utility.Tools.GetValueFromDic<int>(BackObject, "AmountRuleID");
                //BackAmount = Utility.Tools.GetValueFromDic<decimal>(BackObject, "BackAmount");
            }
            string Title = "充值赠与";
            int CategoryType = 5;
            User user = null;
            var user_level = Mall_UserLevel.GetMall_UserLevelByUserID(data.UserID, out user);
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    data.BalanceStatus = 1;
                    data.Save(helper);
                    if (user != null && user_level != null)
                    {
                        if (user.UserLevelID != user_level.ID)
                        {
                            string LevelTitle = "充值满" + user_level.StartAmount.ToString("0.00") + "升到到合伙人(" + user_level.Name + ")";
                            Mall_UserLevelApprove.Insert_Mall_UserLevelApprove(data.UserID, LevelTitle, user_level.ID, helper: helper, IncomingAmount: data.BalanceValue, IncomingType: data.PaymentMethodDesc, UserBalanceID: data.ID);
                        }
                    }
                    decimal BackAmount = Utility.Tools.GetValueFromDic<decimal>(BackObject, "BackAmount");
                    int AmountRuleID = Utility.Tools.GetValueFromDic<int>(BackObject, "AmountRuleID");
                    bool AmountIsSendNow = Utility.Tools.GetValueFromDic<bool>(BackObject, "AmountIsSendNow");
                    DateTime AmountIsReadySendTime = Utility.Tools.GetValueFromDic<DateTime>(BackObject, "AmountIsReadySendTime");
                    if (BackAmount > 0 && AmountRuleID > 0)
                    {
                        Insert_Mall_UserBalance(data.UserID, 1, BackAmount, Title, "BalaceID:" + data.ID, CategoryType, "System", 1, "", RelatedID: data.ID, AmountRuleID: AmountRuleID, helper: helper, PaymentMethod: PaymentMethod, IsSent: AmountIsSendNow, IsReadySendTime: AmountIsReadySendTime);
                    }
                    int BackPoint = Utility.Tools.GetValueFromDic<int>(BackObject, "BackPoint");
                    int PointRuleID = Utility.Tools.GetValueFromDic<int>(BackObject, "PointRuleID");
                    bool PointIsSendNow = Utility.Tools.GetValueFromDic<bool>(BackObject, "PointIsSendNow");
                    DateTime PointIsReadySendTime = Utility.Tools.GetValueFromDic<DateTime>(BackObject, "PointIsReadySendTime");
                    if (BackPoint > 0 && PointRuleID > 0)
                    {
                        Mall_UserPoint.Insert_Mall_UserPoint(data.UserID, 1, 0, Title, "BalaceID:" + data.ID, CategoryType, "System", 1, "", 0, helper, RelatedID: data.ID, PointValue: BackPoint, AmountRuleID: PointRuleID, IsSent: PointIsSendNow, IsReadySendTime: PointIsReadySendTime);
                    }
                    List<int> CouponIDList = Utility.Tools.GetValueFromDic<List<int>>(BackObject, "CouponIDList");
                    int CouponRuleID = Utility.Tools.GetValueFromDic<int>(BackObject, "CouponRuleID");
                    bool CouponIsSendNow = Utility.Tools.GetValueFromDic<bool>(BackObject, "CouponIsSendNow");
                    DateTime CouponIsReadySendTime = Utility.Tools.GetValueFromDic<DateTime>(BackObject, "CouponIsReadySendTime");
                    int SendCouponCount = Utility.Tools.GetValueFromDic<int>(BackObject, "SendCouponCount");
                    if (CouponIDList != null && CouponIDList.Count > 0 && CouponRuleID > 0)
                    {
                        foreach (var CouponID in CouponIDList)
                        {
                            for (int i = 0; i < SendCouponCount; i++)
                            {
                                Mall_CouponUser.Insert_Mall_CouponUser(data.UserID, CouponID, 1, CouponRuleID, CouponIsReadySendTime, helper: helper, IsSent: CouponIsSendNow);
                            }
                        }
                    }
                    if (payment != null)
                    {
                        payment.Save(helper);
                    }
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    Utility.LogHelper.WriteError("Mall_UserBalance.cs", "UpdateMall_UserBalanceStatus", ex);
                }
            }
        }
        /// <summary>
        /// 消费处理
        /// </summary>
        /// <param name="order"></param>
        /// <param name="payment"></param>
        public static void GetEarnThroughBuy(Mall_Order order = null, Payment payment = null)
        {
            //消费赠与处理
            if (order == null)
            {
                return;
            }
            int[] ProductIDList = Mall_OrderItem.GetProductIDListByOrderID(order.ID, IsProduct: true);
            int[] ServiceIDList = Mall_OrderItem.GetProductIDListByOrderID(order.ID, IsService: true);
            if (payment == null)
            {
                payment = Payment.GetPaymentByTradeNo(order.TradeNo);
            }
            decimal TotalCost = order.TotalCost;
            if (payment != null)
            {
                TotalCost = payment.Amount / 100;
            }
            Dictionary<string, object> BackObject = new Dictionary<string, object>();
            Mall_AmountRule.GetBackAmountPoint(TotalCost, out BackObject, ProductIDList, ServiceIDList, AmountType: 2, UserID: order.UserID);
            string Title = "消费赠与";
            int CategoryType = 6;
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    decimal BackAmount = Utility.Tools.GetValueFromDic<decimal>(BackObject, "BackAmount");
                    int AmountRuleID = Utility.Tools.GetValueFromDic<int>(BackObject, "AmountRuleID");
                    bool AmountIsSendNow = Utility.Tools.GetValueFromDic<bool>(BackObject, "AmountIsSendNow");
                    DateTime AmountIsReadySendTime = Utility.Tools.GetValueFromDic<DateTime>(BackObject, "AmountIsReadySendTime");
                    if (BackAmount > 0 && AmountRuleID > 0)
                    {
                        Insert_Mall_UserBalance(order.UserID, 1, BackAmount, Title, "BalaceID:" + order.ID, CategoryType, "System", 1, "", RelatedID: order.ID, AmountRuleID: AmountRuleID, helper: helper, PaymentMethod: order.PaymentMethod, IsSent: AmountIsSendNow, IsReadySendTime: AmountIsReadySendTime);
                    }
                    int BackPoint = Utility.Tools.GetValueFromDic<int>(BackObject, "BackPoint");
                    int PointRuleID = Utility.Tools.GetValueFromDic<int>(BackObject, "PointRuleID");
                    bool PointIsSendNow = Utility.Tools.GetValueFromDic<bool>(BackObject, "PointIsSendNow");
                    DateTime PointIsReadySendTime = Utility.Tools.GetValueFromDic<DateTime>(BackObject, "PointIsReadySendTime");
                    if (BackPoint > 0 && PointRuleID > 0)
                    {
                        Mall_UserPoint.Insert_Mall_UserPoint(order.UserID, 1, 0, Title, "BalaceID:" + order.ID, CategoryType, "System", 1, "", 0, helper, RelatedID: order.ID, PointValue: BackPoint, AmountRuleID: PointRuleID, IsSent: PointIsSendNow, IsReadySendTime: PointIsReadySendTime);
                    }
                    if (order.TotalOrderPointCost > 0)
                    {
                        Mall_UserPoint.Insert_Mall_UserPoint(order.UserID, 2, 0, "购买商品", "OrderID:" + order.ID, 1, "System", 1, order.TradeNo, order.ID, helper, RelatedID: order.ID, PointValue: -order.TotalOrderPointCost, AmountRuleID: 0);
                    }

                    List<int> CouponIDList = Utility.Tools.GetValueFromDic<List<int>>(BackObject, "CouponIDList");
                    int CouponRuleID = Utility.Tools.GetValueFromDic<int>(BackObject, "CouponRuleID");
                    bool CouponIsSendNow = Utility.Tools.GetValueFromDic<bool>(BackObject, "CouponIsSendNow");
                    DateTime CouponIsReadySendTime = Utility.Tools.GetValueFromDic<DateTime>(BackObject, "CouponIsReadySendTime");
                    int SendCouponCount = Utility.Tools.GetValueFromDic<int>(BackObject, "SendCouponCount");
                    if (CouponIDList != null && CouponIDList.Count > 0 && CouponRuleID > 0)
                    {
                        foreach (var CouponID in CouponIDList)
                        {
                            for (int i = 0; i < SendCouponCount; i++)
                            {
                                Mall_CouponUser.Insert_Mall_CouponUser(order.UserID, CouponID, 3, CouponRuleID, CouponIsReadySendTime, helper: helper, IsSent: CouponIsSendNow);
                            }
                        }
                    }
                    if (payment != null)
                    {
                        payment.Save(helper);
                    }
                    if (order != null)
                    {
                        order.Save(helper);
                    }
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    Utility.LogHelper.WriteError("Mall_UserBalance.cs", "GetEarnThroughBuy", ex);
                }
            }
        }
        public static Mall_UserBalance[] GetUnSentMall_UserBalanceList()
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            string cmdtext = "select * from  [Mall_UserBalance] where isnull(IsSent,0)=0 and [BalanceStatus]=0 and ([IsReadySendTime] is null or [IsReadySendTime]<=@Now);";
            parameters.Add(new SqlParameter("@Now", DateTime.Now));
            return GetList<Mall_UserBalance>(cmdtext, parameters).ToArray();
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
        public string BalanceTypeDesc
        {
            get
            {
                if (this.CategoryType == 10)
                {
                    return "扣除";
                }
                return this.BalanceType == 1 ? "充值" : "消费";
            }
        }
        public string CategoryTypeDesc
        {
            get
            {
                //1-购买商品消费 2-微信充值 3-支付宝充值 4-订单退款返还 5-充值赠与 6-消费赠与 7-退款消费赠与取消 8-线下充值 9-业主结算 10-线下扣除
                string desc = string.Empty;
                switch (this.CategoryType)
                {
                    case 1:
                        desc = "购买商品消费";
                        break;
                    case 2:
                        desc = "微信充值";
                        break;
                    case 3:
                        desc = "支付宝充值";
                        break;
                    case 4:
                        desc = "订单退款返还";
                        break;
                    case 5:
                        desc = "充值赠与";
                        break;
                    case 6:
                        desc = "消费赠与";
                        break;
                    case 7:
                        desc = "退款消费赠与取消";
                        break;
                    case 8:
                        desc = "线下充值";
                        break;
                    case 9:
                        desc = "业主结算";
                        break;
                    case 10:
                        desc = "线下扣除";
                        break;
                    default:
                        break;
                }
                return desc;
            }
        }
    }
    public partial class Mall_UserBalanceDetail : Mall_UserBalance
    {
        [DatabaseColumn("CustomerName")]
        public string CustomerName { get; set; }
        public string CustomerInfo { get; set; }
        public static Ui.DataGrid GetMall_UserBalanceDetailGridByKeywords(string Keywords, DateTime StartTime, DateTime EndTime, int AmountType, long startRowIndex, int pageSize, int IncomingType, int OutcomingType)
        {
            long totalRows = 0;
            string OrderBy = " order by AddTime desc";
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (AmountType > 0)
            {
                conditions.Add("[BalanceType]=@BalanceType");
                parameters.Add(new SqlParameter("@BalanceType", AmountType));
            }
            if (IncomingType > 0)
            {
                conditions.Add("[CategoryType]=@IncomingType");
                parameters.Add(new SqlParameter("@IncomingType", IncomingType));
            }
            if (OutcomingType > 0)
            {
                conditions.Add("[CategoryType]=@OutcomingType");
                parameters.Add(new SqlParameter("@OutcomingType", OutcomingType));
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
            if (!string.IsNullOrEmpty(Keywords))
            {
                conditions.Add("[UserID] in (select [UserID] from [User] where [LoginName] like @keywords)");
                parameters.Add(new SqlParameter("@keywords", "%" + Keywords + "%"));
            }
            string fieldList = "A.*";
            string Statement = " from (select [Mall_UserBalance].*,(select LoginName from [User] where [UserID]=Mall_UserBalance.UserID) as CustomerName from [Mall_UserBalance])A where  " + string.Join(" and ", conditions.ToArray());
            Mall_UserBalanceDetail[] list = GetList<Mall_UserBalanceDetail>(fieldList, Statement, parameters, OrderBy, startRowIndex, pageSize, out totalRows).ToArray();
            if (list.Length > 0)
            {
                int MinUserID = list.Min(p => p.UserID);
                int MaxUserID = list.Max(p => p.UserID);
                var userList = User.GetAPPCustomerUserList(MinUserID: MinUserID, MaxUserID: MaxUserID);
                var userProjectList = Mall_UserProject.GetMall_UserProjectListByMinMaxUserID(MinUserID, MaxUserID);
                int MinRoomID = 0;
                int MaxRoomID = 0;
                if (userProjectList.Length > 0)
                {
                    MinRoomID = userProjectList.Min(p => p.ProjectID);
                    MaxRoomID = userProjectList.Max(p => p.ProjectID);
                }
                var projectList = Project.GetProjectListByMinMaxID(MinRoomID, MaxRoomID);
                foreach (var item in list)
                {
                    var myUser = userList.FirstOrDefault(p => p.UserID == item.UserID);
                    if (myUser != null)
                    {
                        item.CustomerInfo = myUser.FinalRealName;
                        var myUserProjectList = userProjectList.Where(p => p.UserID == item.UserID).ToArray();
                        var myProjectList = projectList.Where(p => myUserProjectList.Select(q => q.ProjectID).ToList().Contains(p.ID)).ToArray();
                        if (myProjectList.Length > 0)
                        {
                            item.CustomerInfo += "【" + myProjectList[0].FullName + "-" + myProjectList[0].Name + "】";
                        }
                    }
                }
            }
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
    }
}
