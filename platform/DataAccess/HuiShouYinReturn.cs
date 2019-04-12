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
    /// This object represents the properties and methods of a HuiShouYinReturn.
    /// </summary>
    public partial class HuiShouYinReturn : EntityBase
    {
        public static HuiShouYinReturn GetHuiShouYinReturn(string hy_bill_no)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@hy_bill_no", hy_bill_no));
            string cmdwhere = " and hy_bill_no=@hy_bill_no";
            return GetOne<HuiShouYinReturn>("select top 1 * from [HuiShouYinReturn] where 1=1 " + cmdwhere, parameters);
        }
    }
}
