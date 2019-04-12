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
	/// This object represents the properties and methods of a InsideCustomer_Followup.
	/// </summary>
	public partial class InsideCustomer_Followup : EntityBase
	{
        public static InsideCustomer_Followup[] GetInsideCustomer_FollowupList(int InsideCustomerID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (InsideCustomerID > 0)
            {
                conditions.Add("[InsideCustomerID]=@InsideCustomerID");
                parameters.Add(new SqlParameter("@InsideCustomerID", InsideCustomerID));
            }
            string fieldList = "select [InsideCustomer_Followup].* from [InsideCustomer_Followup] where " + string.Join(" and ", conditions.ToArray());
            InsideCustomer_Followup[] list = new InsideCustomer_Followup[] { };
            list = GetList<InsideCustomer_Followup>(fieldList, parameters).ToArray();
            return list;
        }
	}
}
