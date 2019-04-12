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
    /// This object represents the properties and methods of a WechatUser_Project.
    /// </summary>
    public partial class WechatUser_Project : EntityBase
    {
        public static bool CheckWechatUser_ProjectByOpenid(string OpenID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@OpenID", OpenID));
            int count = 0;
            using (SqlHelper helper = new SqlHelper())
            {
                var result = helper.ExecuteScalar("select count(1) from [WechatUser_Project] where ltrim(rtrim(OpenID))=ltrim(rtrim(@OpenID)) and exists(select 1 from [Project] where ID=WechatUser_Project.ProjectID)", CommandType.Text, parameters);
                if (result != null)
                {
                    int.TryParse(result.ToString(), out count);
                }
            }
            return count > 0;
        }
        public static WechatUser_Project[] GetWechatUser_ProjectByOpenid(string OpenID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@OpenID", OpenID));
            return GetList<WechatUser_Project>("select * from [WechatUser_Project] where ltrim(rtrim(OpenID))=ltrim(rtrim(@OpenID)) and exists(select 1 from [Project] where ID=WechatUser_Project.ProjectID)", parameters).ToArray();
        }
        public static WechatUser_Project[] GetWechatUser_ProjectListByRoomIDList(List<int> RoomIDList)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            if (RoomIDList.Count == 0)
            {
                return new WechatUser_Project[] { };
            }
            return GetList<WechatUser_Project>("select * from [WechatUser_Project] where [ProjectID] in (" + string.Join(",", RoomIDList.ToArray()) + ")", parameters).ToArray();
        }
    }
}
