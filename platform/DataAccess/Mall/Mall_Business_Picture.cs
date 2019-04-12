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
	/// This object represents the properties and methods of a Mall_Business_Picture.
	/// </summary>
	public partial class Mall_Business_Picture : EntityBase
	{
        public static Mall_Business_Picture[] GetMall_Business_PictureListByID(int ID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (ID == 0)
            {
                return new Mall_Business_Picture[] { };
            }
            conditions.Add("[BusinessID]=@ID");
            parameters.Add(new SqlParameter("@ID", ID));
            string cmdtext = "select * from [Mall_Business_Picture] where  " + string.Join(" and ", conditions.ToArray());
            return GetList<Mall_Business_Picture>(cmdtext, parameters).ToArray();
        }
	}
}
