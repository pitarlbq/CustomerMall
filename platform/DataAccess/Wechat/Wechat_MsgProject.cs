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
    /// This object represents the properties and methods of a Wechat_MsgProject.
    /// </summary>
    public partial class Wechat_MsgProject : EntityBase
    {
        public static Wechat_MsgProject[] GetWechat_MsgProjectList(int MsgID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            string cmdwhere = string.Empty;
            if (MsgID > 0)
            {
                cmdwhere += " and [MsgID]=@MsgID";
                parameters.Add(new SqlParameter("@MsgID", MsgID));
            }
            return GetList<Wechat_MsgProject>("select * from [Wechat_MsgProject] where 1=1 " + cmdwhere, parameters).ToArray();
        }
    }
}
