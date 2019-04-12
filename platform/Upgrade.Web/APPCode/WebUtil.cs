using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Globalization;
using System.Web.Script.Serialization;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using System.Configuration;
using Utility;
using System.Drawing;

namespace Web
{
    public static class WebUtil
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
            context.Response.Clear();
            context.Response.AddHeader("Access-Control-Allow-Origin", "*");
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
                    //str = new JavaScriptSerializer().Serialize(obj);
                    str = JsonConvert.SerializeObject(obj);
                }
                context.Response.Write(str);
            }
            context.Response.Flush();
        }

        public static decimal GetDecimalValue(HttpContext context, string name)
        {
            decimal value = decimal.MinValue;
            decimal.TryParse(context.Request.Params[name], out value);
            return value;
        }
        public static int GetIntValue(HttpContext context, string name)
        {
            int value = int.MinValue;
            int.TryParse(context.Request.Params[name], out value);
            return value;
        }
        public static DateTime GetDateValue(HttpContext context, string name)
        {
            DateTime value = DateTime.MinValue;
            DateTime.TryParse(context.Request.Params[name], out value);
            return value;
        }
    }
    public class JsonResponse
    {
        public ErrorCode Code { get; set; }
        public object Error { get; set; }
        public object Result { get; set; }
    }

    //值格式：前3位表现错误所属业务，后2位表示具体错误类型
    public enum ErrorCode
    {
        /// <summary>
        /// 成功
        /// </summary>
        Succeed = 0,
        /// <summary>
        /// 服务器错误
        /// </summary>
        ServerError = -1,
        /// <summary>
        /// 错误的请求
        /// </summary>
        InvalideRequest = -2,
        /// <summary>
        /// 身份验证失败(用户未登录)
        /// </summary>
        AuthenticationFail = -100,
    }
}
