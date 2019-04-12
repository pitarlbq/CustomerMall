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
    /// This object represents the properties and methods of a Mall_Product_Category.
    /// </summary>
    public partial class Mall_Product_Category : EntityBase
    {
        public static Mall_Product_Category[] GetMall_Product_CategoryListByProductID(int ProductID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (ProductID == 0)
            {
                return new Mall_Product_Category[] { };
            }
            conditions.Add("[ProductID]=@ProductID");
            parameters.Add(new SqlParameter("@ProductID", ProductID));
            string cmdtext = "select * from [Mall_Product_Category] where  " + string.Join(" and ", conditions.ToArray());
            return GetList<Mall_Product_Category>(cmdtext, parameters).ToArray();
        }
    }
}
