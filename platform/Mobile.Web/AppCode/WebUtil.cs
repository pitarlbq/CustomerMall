using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace Mobile.Web.AppCode
{
    public class WebUtil
    {
        public static void WriteJsonError(HttpContext context, ErrorCode errorcode, object err)
        {
            WriteJson(context, new JsonResponse()
            {
                Code = errorcode,
                Error = err,
            });
        }

        public static void WriteJsonResult(HttpContext context, object result)
        {
            WriteJson(context, new JsonResponse()
            {
                Code = ErrorCode.Succeed,
                Result = result
            });
        }

        public static void WriteJson(HttpContext context, object obj)
        {
            context.Response.ContentType = "application/json";
            if (obj != null)
            {
                string str = string.Empty;
                if (obj is string)
                {
                    str = (string)obj;
                }
                else
                {
                    str = new JavaScriptSerializer().Serialize(obj);
                }
                context.Response.Write(System.Text.RegularExpressions.Regex.Unescape(str));
            }
            context.Response.Flush();
        }
    }
    public class JsonResponse
    {
        public ErrorCode Code { get; set; }
        public object Error { get; set; }
        public object Result { get; set; }
    }
}