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
    /// This object represents the properties and methods of a Mall_UserJiXiaoPoint.
    /// </summary>
    public partial class Mall_UserJiXiaoPoint : EntityBase
    {
        public static Mall_UserJiXiaoPoint[] GetMall_UserJiXiaoPointList(int UserID)
        {
            if (UserID <= 0)
            {
                return new Mall_UserJiXiaoPoint[] { };
            }
            List<SqlParameter> parameters = new List<SqlParameter>();
            string cmdtext = "select * from  [Mall_UserJiXiaoPoint] where UserID=@UserID and [PointStatus]=1 order by AddTime desc";
            parameters.Add(new SqlParameter("@UserID", UserID));
            return GetList<Mall_UserJiXiaoPoint>(cmdtext, parameters).ToArray();
        }
        public static decimal GetMall_UserJiXiaoPointBalance(int UserID)
        {
            if (UserID <= 0)
            {
                return 0;
            }
            decimal balance = 0;
            using (SqlHelper helper = new SqlHelper())
            {
                List<SqlParameter> parameters = new List<SqlParameter>();
                string cmdtext = @"select sum(PointValue) from [Mall_UserJiXiaoPoint] where UserID=@UserID and [PointStatus]=1";
                parameters.Add(new SqlParameter("@UserID", UserID));
                var balanceobj = helper.ExecuteScalar(cmdtext, CommandType.Text, parameters);
                if (balanceobj != null)
                {
                    decimal.TryParse(balanceobj.ToString(), out balance);
                }
            }
            return balance;
        }
        public static void Insert_Mall_UserJiXiaoPoint(int UserID, int PointType, decimal OrderTotalAmount, string Title, string Summary, int CategoryType, string AddUserName, int PointStatus, string TradeNo = "", int OrderID = 0, int FixedPointMonth = 0, DateTime? FixedPointDateTime = null, int PointValue = 0, int RelatedID = 0, int AmountRuleID = 0, int RuleID = 0, int InfoID = 0, string InfoName = "", string CategoryName = "", int EarnType = 0, string ApproveUserName = "", DateTime? ApproveTime = null, string ApproveRemark = "", string Remark = "", decimal BeforePointValue = 0)
        {
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    Insert_Mall_UserJiXiaoPoint(UserID, PointType, OrderTotalAmount, Title, Summary, CategoryType, AddUserName, PointStatus, helper, TradeNo: TradeNo, OrderID: OrderID, FixedPointMonth: FixedPointMonth, FixedPointDateTime: FixedPointDateTime, PointValue: PointValue, RelatedID: RelatedID, AmountRuleID: AmountRuleID, RuleID: RuleID, InfoID: InfoID, InfoName: InfoName, CategoryName: CategoryName, EarnType: EarnType, ApproveUserName: ApproveUserName, ApproveTime: ApproveTime, ApproveRemark: ApproveRemark, Remark: Remark, BeforePointValue: BeforePointValue);
                    helper.Commit();
                }
                catch (Exception)
                {
                    helper.Rollback();
                }
            }
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
        public static void Insert_Mall_UserJiXiaoPoint(int UserID, int PointType, decimal OrderTotalAmount, string Title, string Summary, int CategoryType, string AddUserName, int PointStatus, SqlHelper helper, string TradeNo = "", int OrderID = 0, int FixedPointMonth = 0, DateTime? FixedPointDateTime = null, int PointValue = 0, int RelatedID = 0, int AmountRuleID = 0, int RuleID = 0, int InfoID = 0, string InfoName = "", string CategoryName = "", int EarnType = 0, string ApproveUserName = "", DateTime? ApproveTime = null, string ApproveRemark = "", string Remark = "", decimal BeforePointValue = 0)
        {
            if (UserID <= 0)
            {
                return;
            }
            var data = new Mall_UserJiXiaoPoint();
            data.UserID = UserID;
            data.PointType = PointType;
            data.PointValue = PointValue;
            data.Title = Title;
            data.Summary = Summary;
            data.CategoryType = CategoryType;
            data.AddUserName = AddUserName;
            data.PointStatus = PointStatus;
            data.AddTime = DateTime.Now;
            data.TradeNo = TradeNo;
            data.RelatedID = RelatedID;
            data.AmountRuleID = AmountRuleID;
            data.FixedPointMonth = FixedPointMonth > 0 ? FixedPointMonth : DateTime.Now.Month;
            if (FixedPointDateTime.HasValue)
            {
                DateTime _FixedPointDateTime = Convert.ToDateTime(FixedPointDateTime);
                data.FixedPointDateTime = _FixedPointDateTime > DateTime.MinValue ? _FixedPointDateTime : DateTime.Now;
            }
            data.InfoID = InfoID;
            data.InfoName = InfoName;
            data.CategoryName = CategoryName;
            data.EarnType = EarnType;
            data.ApproveUserName = ApproveUserName;
            if (ApproveTime.HasValue)
            {
                data.ApproveTime = Convert.ToDateTime(ApproveTime);
            }
            data.ApproveRemark = ApproveRemark;
            data.Remark = Remark;
            Mall_PointCovertRecord record = null;
            if (data.EarnType == 2)
            {
                record = new Mall_PointCovertRecord();
                record.UserID = data.UserID;
                record.PointValue = (int)BeforePointValue;
                record.CheckPointValue = data.PointValue;
                record.PointRuleID = data.RelatedID;
                record.Status = 2;
                record.AddTime = DateTime.Now;
                record.AddUserName = data.AddUserName;
            }
            Mall_PointWithDrawRecord withdrawrecord = null;
            if (data.EarnType == 3)
            {
                withdrawrecord = new Mall_PointWithDrawRecord();
                withdrawrecord.UserID = data.UserID;
                withdrawrecord.PointValue = data.PointValue;
                withdrawrecord.Status = 2;
                withdrawrecord.AddTime = DateTime.Now;
                withdrawrecord.AddUserName = data.AddUserName;
            }
            data.Save(helper);
            if (record != null)
            {
                //积分兑换扣除
                var userPoint = Mall_UserPoint.Insert_Mall_UserPoint(data.UserID, 2, 0, "积分兑换扣除", "Mall_PointCovertRecordID:" + record.ID, 8, data.AddUserName, 1, "", 0, helper, PointValue: -record.PointValue, RelatedID: record.ID);
                record.Mall_UserPointID = userPoint.ID;
                record.Mall_UserJiXiaoPointID = data.ID;
                record.Save(helper);
                data.PointStatus = 0;
                data.CategoryType = 3;
                data.RelatedID = record.ID;
            }
            if (withdrawrecord != null)
            {
                withdrawrecord.Mall_UserJiXiaoPointID = data.ID;
                withdrawrecord.Save(helper);
                data.PointStatus = 1;
                data.CategoryType = 4;
                data.RelatedID = withdrawrecord.ID;
            }
            data.Save(helper);
        }
        public string EarnTypeDesc
        {
            get
            {
                if (this.EarnType == 1)
                {
                    return "奖励";
                }
                if (this.EarnType == 2)
                {
                    return "扣除";
                }
                return string.Empty;
            }
        }
    }
    public partial class Mall_UserJiXiaoPointDetail : Mall_UserJiXiaoPoint
    {
        [DatabaseColumn("UserName")]
        public string UserName { get; set; }
        public static Ui.DataGrid GetMall_UserJiXiaoPointDetailGridByKeywords(string Keywords, DateTime StartTime, DateTime EndTime, string orderBy, long startRowIndex, int pageSize)
        {
            long totalRows = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (StartTime > DateTime.MinValue)
            {
                conditions.Add("[ApproveTime]>=@StartTime");
                parameters.Add(new SqlParameter("@StartTime", StartTime));
            }
            if (EndTime > DateTime.MinValue)
            {
                conditions.Add("[ApproveTime]<=@EndTime");
                parameters.Add(new SqlParameter("@EndTime", EndTime));
            }
            if (!string.IsNullOrEmpty(Keywords))
            {
                conditions.Add("([InfoName] like @Keywords or [CategoryName] like @Keywords)");
                parameters.Add(new SqlParameter("@Keywords", "%" + Keywords + "%"));
            }
            string fieldList = "A.* ";
            string Statement = " from (select *,(select LoginName from [User] where [UserID]=[Mall_UserJiXiaoPoint].UserID) as UserName from [Mall_UserJiXiaoPoint])A where  " + string.Join(" and ", conditions.ToArray());
            Mall_UserJiXiaoPointDetail[] list = GetList<Mall_UserJiXiaoPointDetail>(fieldList, Statement, parameters, orderBy, startRowIndex, pageSize, out totalRows).ToArray();
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
    }
}
