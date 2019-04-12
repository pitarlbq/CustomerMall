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
    /// This object represents the properties and methods of a Mall_AmountRuleProduct.
    /// </summary>
    public partial class Mall_AmountRuleProduct : EntityBase
    {
        public static Mall_AmountRuleProduct[] GetMall_AmountRuleProductListByAmountRuleIDList(int[] IDList)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (IDList.Length == 0)
            {
                return new Mall_AmountRuleProduct[] { };
            }
            conditions.Add("[AmountRuleID] in (" + string.Join(",", IDList) + ")");
            string cmdtext = "select * from [Mall_AmountRuleProduct] where  " + string.Join(" and ", conditions.ToArray());
            return GetList<Mall_AmountRuleProduct>(cmdtext, parameters).ToArray();
        }
    }
}
