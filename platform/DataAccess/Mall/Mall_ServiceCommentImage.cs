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
	/// This object represents the properties and methods of a Mall_ServiceCommentImage.
	/// </summary>
	public partial class Mall_ServiceCommentImage : EntityBase
	{
        public static Mall_ServiceCommentImage[] GetMall_ServiceCommentImageListByServiceID(int ServiceID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            if (ServiceID == 0)
            {
                return new Mall_ServiceCommentImage[] { };
            }
            conditions.Add("[ServiceID]=@ServiceID");
            parameters.Add(new SqlParameter("@ServiceID", ServiceID));
            string Statement = @"select * from Mall_ServiceCommentImage where " + string.Join(" and ", conditions) + " order by [AddTime] asc";
            return GetList<Mall_ServiceCommentImage>(Statement, parameters).ToArray();
        }
	}
}
