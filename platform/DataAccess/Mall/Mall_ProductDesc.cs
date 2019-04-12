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
    /// This object represents the properties and methods of a Mall_ProductDesc.
    /// </summary>
    public partial class Mall_ProductDesc : EntityBase
    {
        public static Mall_ProductDesc[] GetMall_ProductDescListByProductID(int ProductID, string GUID = "")
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (ProductID == 0 && string.IsNullOrEmpty(GUID))
            {
                return new Mall_ProductDesc[] { };
            }
            if (ProductID > 0)
            {
                conditions.Add("[ProductID]=@ProductID");
                parameters.Add(new SqlParameter("@ProductID", ProductID));
            }
            if (!string.IsNullOrEmpty(GUID))
            {
                conditions.Add("[GUID]=@GUID");
                parameters.Add(new SqlParameter("@GUID", GUID));
            }
            string cmdtext = "select * from [Mall_ProductDesc] where  " + string.Join(" and ", conditions.ToArray())+" order by [SortOrder] asc";
            return GetList<Mall_ProductDesc>(cmdtext, parameters).ToArray();
        }
    }
}
