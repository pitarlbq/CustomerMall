using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;

using Foresight.DataAccess.Framework;
using System.ComponentModel;

namespace Foresight.DataAccess
{
    /// <summary>
    /// This object represents the properties and methods of a Business.
    /// </summary>
    public partial class Business : EntityBase
    {
        public static Business[] GetBusinessListByKeywords(string Keywords)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (!string.IsNullOrEmpty(Keywords))
            {
                conditions.Add("[ContactName] like @Keywords");
                parameters.Add(new SqlParameter("@Keywords", "%" + Keywords + "%"));
            }
            return GetList<Business>("select * from [Business] where " + string.Join(" and ", conditions.ToArray()) + " order by [ContactName] collate Chinese_PRC_CS_AS_KS_WS", parameters).ToArray();
        }
    }
    public enum TreeTypeDefine
    {
        [Description("商户")]
        Business,
        [Description("货品")]
        Product,
        [Description("规格")]
        SpecInfo,
        [Description("库存")]
        InventoryInfo,
        [Description("搬运工")]
        Carrier,
        [Description("搬运工分组")]
        CarrierGroup,
    }
}
