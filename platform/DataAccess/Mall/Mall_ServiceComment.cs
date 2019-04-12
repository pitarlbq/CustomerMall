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
    /// This object represents the properties and methods of a Mall_ServiceComment.
    /// </summary>
    public partial class Mall_ServiceComment : EntityBase
    {

    }
    public partial class Mall_ServiceCommentDetail : Mall_ServiceComment
    {
        [DatabaseColumn("NickName")]
        public string NickName { get; set; }
        [DatabaseColumn("HeadImg")]
        public string HeadImg { get; set; }
        public static Mall_ServiceCommentDetail[] GetMall_ServiceCommentDetailListByServiceID(int ServiceID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            if (ServiceID == 0)
            {
                return new Mall_ServiceCommentDetail[] { };
            }
            conditions.Add("[ServiceID]=@ServiceID");
            parameters.Add(new SqlParameter("@ServiceID", ServiceID));
            string Statement = @"select *,(select NickName from [User] where [User].UserID=Mall_ServiceComment.UserID) as NickName,(select HeadImg from [User] where [User].UserID=Mall_ServiceComment.UserID) as HeadImg from Mall_ServiceComment where " + string.Join(" and ", conditions) + " order by [AddTime] desc";
            return GetList<Mall_ServiceCommentDetail>(Statement, parameters).ToArray();
        }
    }
}
