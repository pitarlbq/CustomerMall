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
    /// This object represents the properties and methods of a Mall_AmountRuleService.
    /// </summary>
    public partial class Mall_AmountRuleService : EntityBase
    {
        public static Mall_AmountRuleService[] GetMall_AmountRuleServiceListByAmountRuleID(int ID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (ID == 0)
            {
                return new Mall_AmountRuleService[] { };
            }
            conditions.Add("[AmountRuleID]=@ID");
            parameters.Add(new SqlParameter("@ID", ID));
            string cmdtext = "select * from [Mall_AmountRuleService] where  " + string.Join(" and ", conditions.ToArray());
            return GetList<Mall_AmountRuleService>(cmdtext, parameters).ToArray();
        }
    }
    public partial class Mall_AmountRuleServiceDetail : Mall_AmountRuleService
    {
        [DatabaseColumn("CouponName")]
        public string CouponName { get; set; }
        public static Mall_AmountRuleServiceDetail[] GetMall_AmountRuleServiceDetailListByAmountRuleIDList(List<int> AmountRuleIDList)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (AmountRuleIDList.Count == 0)
            {
                return new Mall_AmountRuleServiceDetail[] { };
            }
            conditions.Add("[AmountRuleID] in (" + string.Join(",", AmountRuleIDList.ToArray()) + ")");
            string cmdtext = "select *,(select [CouponName] from [Mall_Coupon] where ID=[Mall_AmountRuleService].[CouponCodeID]) as CouponName from [Mall_AmountRuleService] where  " + string.Join(" and ", conditions.ToArray());
            return GetList<Mall_AmountRuleServiceDetail>(cmdtext, parameters).ToArray();
        }
    }
}
