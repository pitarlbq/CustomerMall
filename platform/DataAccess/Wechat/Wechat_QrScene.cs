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
    /// This object represents the properties and methods of a Wechat_QrScene.
    /// </summary>
    public partial class Wechat_QrScene : EntityBase
    {
        public static Wechat_QrScene GetWechat_QrSceneByProjectID(int ProjectID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            parameters.Add(new SqlParameter("@ProjectID", ProjectID));
            conditions.Add("[ProjectID]=@ProjectID");

            return GetOne<Wechat_QrScene>("select top 1 * from [" + TableName + "] where " + string.Join(" and ", conditions.ToArray()) + " order by [ID] desc", parameters);
        }
    }
}
