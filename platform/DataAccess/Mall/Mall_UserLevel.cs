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
    /// This object represents the properties and methods of a Mall_UserLevel.
    /// </summary>
    public partial class Mall_UserLevel : EntityBase
    {
        public string ActiveAmountRange
        {
            get
            {
                return (this.StartAmount > 0 ? this.StartAmount.ToString("0.00") : "0.00") + " - " + (this.EndAmount > 0 ? this.EndAmount.ToString("0.00") : "0.00");
            }
        }
        public static Mall_UserLevel[] GetMall_UserLevelListByAmount(decimal StartAmount, decimal EndAmount, int ID = 0)
        {
            List<string> conditions = new List<string>();
            List<SqlParameter> parameters = new List<SqlParameter>();
            conditions.Add("(([StartAmount]<@StartAmount and [EndAmount]>@StartAmount) or ([StartAmount]<@EndAmount and [EndAmount]>=@EndAmount) or ([StartAmount]>@StartAmount and [StartAmount]<@EndAmount))");
            parameters.Add(new SqlParameter("@StartAmount", StartAmount));
            parameters.Add(new SqlParameter("@EndAmount", EndAmount));
            if (ID > 0)
            {
                conditions.Add("[ID]!=@ID");
                parameters.Add(new SqlParameter("@ID", ID));
            }
            return GetList<Mall_UserLevel>("select * from [Mall_UserLevel] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
        public static Mall_UserLevel GetMall_UserLevelByUserID(int UserID, out User user)
        {
            user = User.GetUser(UserID);
            if (user == null)
            {
                return null;
            }
            decimal amount_balance = Mall_UserBalance.GetMall_UserBalanceALLIncomingAmount(UserID);
            List<string> conditions = new List<string>();
            List<SqlParameter> parameters = new List<SqlParameter>();
            conditions.Add("[StartAmount]<=@Amount and [EndAmount]>@Amount");
            parameters.Add(new SqlParameter("@Amount", amount_balance));
            var data = GetOne<Mall_UserLevel>("select top 1 * from [Mall_UserLevel] where " + string.Join(" and ", conditions.ToArray()) + " order by [StartAmount] desc", parameters);
            return data;
        }
    }
    public partial class Mall_UserLevelDetail : Mall_UserLevel
    {
        [DatabaseColumn("UserCount")]
        public int UserCount { get; set; }
        public static Ui.DataGrid GetMall_UserLevelDetailGridByKeywords(string keywords, long startRowIndex, int pageSize)
        {
            long totalRows = 0;
            string OrderBy = " order by [StartAmount] asc";
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (!string.IsNullOrEmpty(keywords))
            {
                conditions.Add("([Name] like @keywords)");
                parameters.Add(new SqlParameter("@keywords", "%" + keywords + "%"));
            }
            string fieldList = "A.*";
            string Statement = " from (select *,(select count(1) from [User] where [UserLevelID]=[Mall_UserLevel].ID) as UserCount from [Mall_UserLevel])A where  " + string.Join(" and ", conditions.ToArray());
            Mall_UserLevelDetail[] list = GetList<Mall_UserLevelDetail>(fieldList, Statement, parameters, OrderBy, startRowIndex, pageSize, out totalRows).ToArray();
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
    }
}
