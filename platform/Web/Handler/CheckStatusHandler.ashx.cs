using Foresight.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using Utility;

namespace Web.Handler
{
    /// <summary>
    /// CheckStatusHandler 的摘要说明
    /// </summary>
    public class CheckStatusHandler : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string visit = context.Request.Params["visit"];
            if (string.IsNullOrEmpty(visit))
            {
                LogHelper.WriteDebug("CheckStatusHandler", "visit为空");
                context.Response.Write(null);
                return;
            }
            visit = visit.ToLower();
            try
            {
                switch (visit)
                {
                    case "checkdeleteproject":
                        checkdeleteproject(context);
                        break;
                    case "checkdeletechargesummary":
                        checkdeletechargesummary(context);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("CheckStatusHandler", "visit: " + visit, ex);
                context.Response.Write("{\"status\":false}");
            }
        }
        private void checkdeletechargesummary(HttpContext context)
        {
            string ChargeIDs = context.Request.Params["ChargeIDs"];
            List<int> ChargeIDList = new List<int>();
            if (!string.IsNullOrEmpty(ChargeIDs))
            {
                ChargeIDList = JsonConvert.DeserializeObject<List<int>>(ChargeIDs);
            }
            int roomfee_total = RoomFee.GetRoomFeeListCountByChargeIDList(ChargeIDList);
            if (roomfee_total > 0)
            {
                WebUtil.WriteJson(context, new { status = false, error = "有未收费的单据，操作取消" });
                return;
            }
            var history_count = RoomFeeHistory.GetRoomFeeHistoryListCountByChargeIDList(ChargeIDList: ChargeIDList);
            if (history_count > 0)
            {
                WebUtil.WriteJson(context, new { status = false, error = "有已收费的单据，操作取消" });
                return;
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void checkdeleteproject(HttpContext context)
        {
            string ProjectIDs = context.Request.Params["ProjectIds"];
            List<int> ProjectIDList = new List<int>();
            if (!string.IsNullOrEmpty(ProjectIDs))
            {
                ProjectIDList = JsonConvert.DeserializeObject<List<int>>(ProjectIDs);
            }
            string RoomIDs = context.Request.Params["RoomIDs"];
            List<int> RoomIDList = new List<int>();
            if (!string.IsNullOrEmpty(RoomIDs))
            {
                RoomIDList = JsonConvert.DeserializeObject<List<int>>(RoomIDs);
            }
            var history_list = Foresight.DataAccess.RoomFeeHistory.GetRoomFeeHistoryListByRoomIDList(RoomIDList, ProjectIDList: ProjectIDList, UserID: WebUtil.GetUser(context).UserID);
            if (history_list.Length > 0)
            {
                WebUtil.WriteJson(context, new { status = false, error = "有历史单据，请先清理" });
                return;
            }
            var fee_list = Foresight.DataAccess.RoomFee.GetRoomFeeListByRoomIDList(RoomIDList, ProjectIDList, UserID: WebUtil.GetUser(context).UserID);
            if (fee_list.Length > 0)
            {
                WebUtil.WriteJson(context, new { status = false, error = "有未收费单据，请先清理" });
                return;
            }
            var import_list = Foresight.DataAccess.ImportFee.GetImportFeeListByRoomIDList(RoomIDList, ProjectIDList, UserID: WebUtil.GetUser(context).UserID);
            if (import_list.Length > 0)
            {
                WebUtil.WriteJson(context, new { status = false, error = "有抄表单据，请先清理" });
                return;
            }
            var customer_list = Foresight.DataAccess.CustomerService.GetCustomerServiceListByRoomIDList(RoomIDList, ProjectIDList, UserID: WebUtil.GetUser(context).UserID);
            if (customer_list.Length > 0)
            {
                WebUtil.WriteJson(context, new { status = false, error = "有客户登记单，请先清理" });
                return;
            }
            var contract_room_list = Foresight.DataAccess.Contract_Room.GetContract_RoomListByRoomIDList(RoomIDList, ProjectIDList, UserID: WebUtil.GetUser(context).UserID);
            if (contract_room_list.Length > 0)
            {
                WebUtil.WriteJson(context, new { status = false, error = "有合同关联资源，请先清理" });
                return;
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}