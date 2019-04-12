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
    /// This object represents the properties and methods of a Mall_ReadPageLog.
    /// </summary>
    public partial class Mall_ReadPageLog : EntityBase
    {
        public string MyTableName
        {
            get
            {
                string desc = string.Empty;
                switch (this.PageType)
                {
                    case 1:
                        desc = "Wechat_Msg";
                        break;
                    case 2:
                        desc = "Mall_Product";
                        break;
                    default:
                        break;
                }
                return desc;
            }
        }
        public static void SaveMallReadPageLog(int type, int id, string deviceid, int userid)
        {
            if (type <= 0)
            {
                return;
            }
            var data = new Mall_ReadPageLog();
            data.DeviceID = deviceid;
            data.AddTime = DateTime.Now;
            data.PageType = type;
            data.UserID = userid;
            data.Table_Key = id;
            data.Table_Name = data.MyTableName;
            data.Save();
            if (data.PageType == 1)
            {
                string cmdtext = "select * from [Mall_ReadPageLog] where [DeviceID]=@DeviceID and [PageType]=@PageType and [Table_Key]=@Table_Key;";
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@DeviceID", data.DeviceID));
                parameters.Add(new SqlParameter("@PageType", data.PageType));
                parameters.Add(new SqlParameter("@Table_Key", data.Table_Key));
                var list = GetList<Mall_ReadPageLog>(cmdtext, parameters).ToArray();
                if (list.Length == 1)
                {
                    var wechat_msg = Wechat_Msg.GetWechat_Msg(id);
                    if (wechat_msg != null)
                    {
                        wechat_msg.APPCustomerReadCount = (wechat_msg.APPCustomerReadCount > 0 ? wechat_msg.APPCustomerReadCount : 0) + 1;
                        wechat_msg.Save();
                    }
                }
            }
        }
    }
}
