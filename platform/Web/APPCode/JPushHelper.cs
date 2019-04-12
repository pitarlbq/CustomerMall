using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Utility;

namespace Web.APPCode
{
    public class JPushHelper
    {
        public static bool SendJpushMsgByServiceID(int ServiceID, out string ErrorMsg, string title = "", int SendUserID = 0, string SendUserName = "")
        {
            ErrorMsg = "";
            var service = Foresight.DataAccess.CustomerService.GetCustomerService(ServiceID);
            if (service == null)
            {
                ErrorMsg = "ID不合法";
                return false;
            }
            string result = string.Empty;
            List<int> ServiceAccpetManIDList = new List<int>();
            if (!string.IsNullOrEmpty(service.ServiceAccpetManID))
            {
                ServiceAccpetManIDList = JsonConvert.DeserializeObject<List<int>>(service.ServiceAccpetManID);
            }
            string result_push = string.Empty;
            string result_ios = string.Empty;
            if (ServiceAccpetManIDList.Count > 0 && service.ServiceStatus == 10)//待接单
            {
                var users = Foresight.DataAccess.User.GetUserListByIDListByServiceProjectID(ServiceAccpetManIDList, service.ProjectID, DepartmentID: service.DepartmentID);
                if (users.Length > 0)
                {
                    Dictionary<string, object> extras = new Dictionary<string, object>();
                    var extra_model = new Utility.JpushContent(service.ServiceStatus, Type: "customerservice");
                    extras["code"] = extra_model.code;
                    extras["msg"] = extra_model.msg;
                    extras["type"] = extra_model.type;
                    extras["id"] = service.ID;
                    extras["status"] = service.ServiceStatus;
                    var users_android = users.Where(p => p.APPUserDeviceType.Equals("android")).ToArray();
                    var users_ios = users.Where(p => p.APPUserDeviceType.Equals("ios")).ToArray();
                    string[] android_cids = new string[] { };
                    string[] ios_cids = new string[] { };
                    if (users_android.Length > 0)
                    {
                        android_cids = users_android.Select(p => p.APPUserDeviceID).ToArray();
                    }
                    if (users_ios.Length > 0)
                    {
                        ios_cids = users_ios.Select(p => p.APPUserDeviceID).ToArray();
                    }
                    result_push = JPush.JpushAPI.PushMessage(title, extras, android_cids, ios_cids, extra_model.msg);
                    Foresight.DataAccess.JPushLog.Insert_JPushLog(android_cids, ios_cids, extras, result_push, 1, service.ID, true, title);
                }
                service.IsAPPSend = true;
                service.APPSendTime = DateTime.Now;
                service.APPSendResult = result_push;
                service.Save();
            }
            else if (service.ServiceStatus == 3)//待抢单
            {
                var users = Foresight.DataAccess.User.GetUserListByIDListByServiceProjectID(new List<int>(), service.ProjectID, DepartmentID: service.DepartmentID);
                if (users.Length > 0)
                {
                    Dictionary<string, object> extras = new Dictionary<string, object>();
                    var extra_model = new Utility.JpushContent(service.ServiceStatus, Type: "customerservice");
                    extras["code"] = extra_model.code;
                    extras["msg"] = extra_model.msg;
                    extras["type"] = extra_model.type;
                    extras["id"] = service.ID;
                    extras["status"] = service.ServiceStatus;
                    var users_android = users.Where(p => p.APPUserDeviceType.Equals("android")).ToArray();
                    var users_ios = users.Where(p => p.APPUserDeviceType.Equals("ios")).ToArray();
                    string[] android_cids = new string[] { };
                    string[] ios_cids = new string[] { };
                    if (users_android.Length > 0)
                    {
                        android_cids = users_android.Select(p => p.APPUserDeviceID).ToArray();
                    }
                    if (users_ios.Length > 0)
                    {
                        ios_cids = users_ios.Select(p => p.APPUserDeviceID).ToArray();
                    }
                    result_push = JPush.JpushAPI.PushMessage(title, extras, android_cids, ios_cids, extra_model.msg);
                    Foresight.DataAccess.JPushLog.Insert_JPushLog(android_cids, ios_cids, extras, result_push, 1, service.ID, true, title);
                }
            }
            service.IsAPPSend = true;
            service.SendUserID = SendUserID;
            service.SendUserName = SendUserName;
            service.APPSendTime = DateTime.Now;
            service.APPSendResult = result_push;
            service.Save();
            return true;
        }
    }
}