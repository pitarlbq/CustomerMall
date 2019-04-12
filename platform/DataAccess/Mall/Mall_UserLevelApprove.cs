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
    /// This object represents the properties and methods of a Mall_UserLevelApprove.
    /// </summary>
    public partial class Mall_UserLevelApprove : EntityBase
    {
        public static void Insert_Mall_UserLevelApprove(int UserID, string RequestTitle, int ApproveUserLevelID, SqlHelper helper = null, decimal IncomingAmount = 0, string IncomingType = "", int UserBalanceID = 0)
        {
            var data = new Mall_UserLevelApprove();
            data.UserID = UserID;
            data.RequestTitle = RequestTitle;
            data.RequestTime = DateTime.Now;
            data.ApproveTime = DateTime.Now;
            data.ApproveStatus = 0;
            data.ApproveUserName = "System";
            data.ApproveUserLevelID = ApproveUserLevelID;
            data.AddUserName = "System";
            data.IncomingAmount = IncomingAmount;
            data.IncomingType = IncomingType;
            data.UserBalanceID = UserBalanceID;
            data.IncomingTime = DateTime.Now;
            if (helper == null)
            {
                data.Save();
                return;
            }
            data.Save(helper);
        }
    }
    public partial class Mall_UserLevelApproveDetail : Mall_UserLevelApprove
    {
        [DatabaseColumn("NickName")]
        public string NickName { get; set; }
        [DatabaseColumn("PhoneNumber")]
        public string PhoneNumber { get; set; }
        [DatabaseColumn("LevelName")]
        public string LevelName { get; set; }
        [DatabaseColumn("UserBalancePaymentMethod")]
        public string UserBalancePaymentMethod { get; set; }
        [DatabaseColumn("UserBalanceValue")]
        public decimal UserBalanceValue { get; set; }
        [DatabaseColumn("RelatePhoneNumber")]
        public string RelatePhoneNumber { get; set; }
        [DatabaseColumn("RelationName")]
        public string RelationName { get; set; }
        public string FinalyPaymentMethod
        {
            get
            {
                if (!string.IsNullOrEmpty(IncomingType))
                {
                    return IncomingType;
                }
                if (!string.IsNullOrEmpty(UserBalancePaymentMethod))
                {
                    return UserBalancePaymentMethod;
                }
                return string.Empty;
            }
        }
        public string FinalyIncomingTime
        {
            get
            {
                if (this.IncomingTime > DateTime.MinValue)
                {
                    return this.IncomingTime.ToString("yyyy-MM-dd");
                }
                return this.RequestTime.ToString("yyyy-MM-dd");
            }
        }
        public string IncomingWay
        {
            get
            {
                return this.IsManualIncoming ? "线下充值" : "线上充值";
            }
        }
        public string FinalIncomingAmount
        {
            get
            {
                if (this.IsManualIncoming)
                {
                    return this.IncomingAmount > 0 ? this.IncomingAmount.ToString("0.00") : "0.00";
                }
                return this.UserBalanceValue > 0 ? this.UserBalanceValue.ToString("0.00") : "0.00";
            }
        }
        public string ApproveStatusDesc
        {
            get
            {
                if (this.ApproveStatus == 1)
                {
                    return "审核通过";
                }
                if (this.ApproveStatus == 2)
                {
                    return "审核未通过";
                }
                if (this.ApproveStatus == 3)
                {
                    return "待申请";
                }
                return "待审核";
            }
        }
        public string FinalUserName
        {
            get
            {
                if (this.RoomPhoneRelationID > 0)
                {
                    return this.RelationName;
                }
                return this.NickName;
            }
        }
        public string FinalPhoneNumber
        {
            get
            {
                if (this.RoomPhoneRelationID > 0)
                {
                    return this.RelatePhoneNumber;
                }
                return this.PhoneNumber;
            }
        }
        public static Ui.DataGrid GetMall_UserLevelApproveDetailGridByKeywords(string keywords, int status, long startRowIndex, int pageSize)
        {
            long totalRows = 0;
            string OrderBy = " order by [RequestTime] desc";
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (status >= 0)
            {
                conditions.Add("[ApproveStatus]=@ApproveStatus");
                parameters.Add(new SqlParameter("@ApproveStatus", status));
            }
            if (!string.IsNullOrEmpty(keywords))
            {
                conditions.Add("([NickName] like @keywords or [PhoneNumber] like @keywords or [LevelName] like @keywords)");
                parameters.Add(new SqlParameter("@keywords", "%" + keywords + "%"));
            }
            string fieldList = "A.*";
            string Statement = " from (select [Mall_UserLevelApprove].*,[User].NickName,[User].PhoneNumber,[Mall_UserLevel].Name as LevelName,[Mall_UserBalance].[PaymentMethod] as UserBalancePaymentMethod,[Mall_UserBalance].[BalanceValue] as UserBalanceValue,[RoomPhoneRelation].RelatePhoneNumber,[RoomPhoneRelation].RelationName from [Mall_UserLevelApprove] left join [User] on [User].UserID=[Mall_UserLevelApprove].UserID left join [Mall_UserLevel] on [Mall_UserLevel].ID=[Mall_UserLevelApprove].[ApproveUserLevelID] left join [Mall_UserBalance] on [Mall_UserBalance].ID=[Mall_UserLevelApprove].[UserBalanceID] left join [RoomPhoneRelation] on [RoomPhoneRelation].ID=[Mall_UserLevelApprove].[RoomPhoneRelationID])A where  " + string.Join(" and ", conditions.ToArray());
            Mall_UserLevelApproveDetail[] list = GetList<Mall_UserLevelApproveDetail>(fieldList, Statement, parameters, OrderBy, startRowIndex, pageSize, out totalRows).ToArray();
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
        public static Mall_UserLevelApproveDetail GetMall_UserLevelApproveDetailByID(int ID)
        {
            if (ID <= 0)
            {
                return null;
            }
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[ID]=@ID");
            parameters.Add(new SqlParameter("@ID", ID));
            string cmdtext = "select * from (select [Mall_UserLevelApprove].*,[User].NickName,[User].PhoneNumber,[Mall_UserLevel].Name as LevelName,[Mall_UserBalance].[PaymentMethod] as UserBalancePaymentMethod,[Mall_UserBalance].[BalanceValue] as UserBalanceValue,[RoomPhoneRelation].RelatePhoneNumber,[RoomPhoneRelation].RelationName from [Mall_UserLevelApprove] left join [User] on [User].UserID=[Mall_UserLevelApprove].UserID left join [Mall_UserLevel] on [Mall_UserLevel].ID=[Mall_UserLevelApprove].[ApproveUserLevelID] left join [Mall_UserBalance] on [Mall_UserBalance].ID=[Mall_UserLevelApprove].[UserBalanceID] left join [RoomPhoneRelation] on [RoomPhoneRelation].ID=[Mall_UserLevelApprove].[RoomPhoneRelationID])A where  " + string.Join(" and ", conditions.ToArray());
            return GetOne<Mall_UserLevelApproveDetail>(cmdtext, parameters);
        }
    }
}
