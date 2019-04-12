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
    /// This object represents the properties and methods of a InsideCustomerAttach.
    /// </summary>
    public partial class InsideCustomerAttach : EntityBase
    {
        public static InsideCustomerAttach[] GetInsideCustomerAttachList(int InsideCustomerID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[InsideCustomerID]=@InsideCustomerID");
            parameters.Add(new SqlParameter("@InsideCustomerID", InsideCustomerID));
            return GetList<InsideCustomerAttach>("select * from [InsideCustomerAttach] where " + string.Join(" and ", conditions.ToArray()) + " order by AddTime desc", parameters).ToArray();
        }
    }
}
