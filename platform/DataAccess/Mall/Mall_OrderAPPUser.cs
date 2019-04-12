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
    /// This object represents the properties and methods of a Mall_OrderAPPUser.
    /// </summary>
    public partial class Mall_OrderAPPUser : EntityBase
    {
        public static Mall_OrderAPPUser[] GetMall_OrderAPPUserListByOrderID(int OrderID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[OrderID]=@OrderID");
            parameters.Add(new SqlParameter("@OrderID", OrderID));
            string Statement = @"select * from [Mall_OrderAPPUser] where " + string.Join(" and ", conditions);
            return GetList<Mall_OrderAPPUser>(Statement, parameters).ToArray();
        }
        public static Mall_OrderAPPUser Save_Mall_OrderAPPUser(int AccpetStatus, bool IsAPPSend = false, string APPSendResult = "", Mall_OrderAPPUser data = null, int UserID = 0, int OrderID = 0, bool IsAPPShow = false, string AddUserMan = "")
        {
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    var appUser = Mall_OrderAPPUser.Save_Mall_OrderAPPUser(AccpetStatus, helper, IsAPPSend: IsAPPSend, APPSendResult: APPSendResult, data: data, UserID: UserID, OrderID: OrderID, IsAPPShow: IsAPPShow, AddUserMan: AddUserMan);
                    helper.Commit();
                    return appUser;
                }
                catch (Exception)
                {
                    helper.Rollback();
                }
            }
            return null;
        }
        public static Mall_OrderAPPUser Save_Mall_OrderAPPUser(int AccpetStatus, SqlHelper helper, bool IsAPPSend = false, string APPSendResult = "", Mall_OrderAPPUser data = null, int UserID = 0, int OrderID = 0, bool IsAPPShow = true, string AddUserMan = "")
        {
            if (data == null)
            {
                data = new Mall_OrderAPPUser();
                data.UserID = UserID;
                data.OrderID = OrderID;
                data.AddTime = DateTime.Now;
                data.AddUserMan = AddUserMan;
            }
            data.IsAPPShow = IsAPPShow;
            data.AccpetStatus = AccpetStatus;
            data.IsAPPSend = IsAPPSend;
            data.AppSendTime = DateTime.Now;
            data.APPSendResult = APPSendResult;
            if (data.AccpetStatus == 1)
            {
                data.AccpetTime = DateTime.Now;
            }
            data.Save(helper);
            return data;
        }
    }
}
