
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Foresight.DataAccess;
using Utility;
using System.Web.SessionState;

namespace Web.Handler
{
    /// <summary>
    /// TempProcessHandler 的摘要说明
    /// </summary>
    public class TempProcessHandler : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string visit = context.Request.Params["visit"];
            if (string.IsNullOrEmpty(visit))
            {
                LogHelper.WriteDebug("SysSettingHandler", "visit为空");
                context.Response.Write(null);
                return;
            }
            visit = visit.ToLower();
            try
            {
                switch (visit)
                {
                    case "savechargebackguarantee":
                        SaveChargeBackGuarantee(context);
                        break;
                    default:
                        WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "Unkown Visit: " + visit);
                        break;
                }
            }
            catch (Exception ex)
            {
                Utility.LogHelper.WriteError("TempProcessHandler", "命令:" + visit, ex);
                context.Response.Write("{\"status\":false}");
            }
        }
        private void SaveChargeBackGuarantee(HttpContext context)
        {
            string values = context.Request.Params["values"];
            var chargeBackGuaranteeTemp = JsonConvert.DeserializeObject<List<ChargeBackGuaranteeTemp>>(values);
            var guid = System.Guid.NewGuid().ToString();
            foreach (var item in chargeBackGuaranteeTemp)
            {
                item.GUID = guid;
                item.Save();
            }
            context.Response.Write(guid);

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