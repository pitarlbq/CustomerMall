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
    /// This object represents the properties and methods of a Mall_ThreadImage.
    /// </summary>
    public partial class Mall_ThreadImage : EntityBase
    {
        public static Mall_ThreadImage[] GetMall_ThreadImageListByThreadID(int ThreadID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (ThreadID == 0)
            {
                return new Mall_ThreadImage[] { };
            }
            conditions.Add("[ThreadID]=@ThreadID");
            parameters.Add(new SqlParameter("@ThreadID", ThreadID));
            string cmdtext = "select * from [Mall_ThreadImage] where  " + string.Join(" and ", conditions.ToArray());
            return GetList<Mall_ThreadImage>(cmdtext, parameters).ToArray();
        }
    }
}
