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
    /// This object represents the properties and methods of a Wechat_ContactProject.
    /// </summary>
    public partial class Wechat_ContactProject : EntityBase
    {
        public static Wechat_ContactProject[] GetWechat_ContactProjectList(int ContactID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            string cmdwhere = string.Empty;
            if (ContactID > 0)
            {
                cmdwhere += " and [WechatContactID]=@ContactID";
                parameters.Add(new SqlParameter("@ContactID", ContactID));
            }
            return GetList<Wechat_ContactProject>("select * from [Wechat_ContactProject] where 1=1 " + cmdwhere, parameters).ToArray();
        }
    }
}
