using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Globalization;
using System.Web.Script.Serialization;
using Foresight.DataAccess.Framework;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using System.Configuration;
using Foresight.DataAccess;
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
        public static string GetUserLoginFullName(HttpContext context)
        {
            string returnname = string.Empty;
            if (context.User.Identity.IsAuthenticated)
            {
                string LoginName = HttpContext.Current.User.Identity.Name;
                string[] autoName = LoginName.Split(':');
                if (LoginName.Contains("superlbq") && autoName.Length > 2)
                {
                    returnname += autoName[autoName.Length - 2] + "_";
                }
            }
            return returnname;
        }
        public static User GetUser(HttpContext context)
        {
            return Web.APPCode.CacheHelper.GetUser(context);
        }
        public static int GetCompanyID(HttpContext context)
        {
            return Web.APPCode.CacheHelper.GetCompanyID(context);
        }
        public static int GetFromCompanyID(HttpContext context)
        {
            var config = new Utility.SiteConfig();
            int CompanyID = 0;
            if (!string.IsNullOrEmpty(config.ServerSiteID))
            {
                CompanyID = int.Parse(config.ServerSiteID);
                return CompanyID;
            }
            var defaultcompany = Company.GetCompanies().FirstOrDefault();
            if (defaultcompany != null)
            {
                return defaultcompany.FromCompanyID;
            }
            return 0;
        }
        public static Company GetCompany(HttpContext context, bool readCache = true)
        {
            return Web.APPCode.CacheHelper.GetCompany(context, readCache: readCache);
        }
        public static Project[] GetMyProjects(int UserID, List<int> ProjectIDList = null)
        {
            return Web.APPCode.CacheHelper.GetMyProjects(UserID, ProjectIDList);
        }
        public static Project[] GetMyXiaoQuProjects(int UserID)
        {
            return Web.APPCode.CacheHelper.GetMyXiaoQuProjects(UserID);
        }
        public static bool Authorization(HttpContext context, string moduleCode, int UserID = 0)
        {
            if (string.IsNullOrEmpty(moduleCode))
            {
                return true;
            }
            else if (moduleCode == "*")
            {
                return context.User.Identity.IsAuthenticated;
            }
            else
            {
                string[] modulecodes = GetModuleCodes(context, UserID: UserID);
                return modulecodes.Contains(moduleCode);
            }
        }
        public static bool AuthorizationBase(HttpContext context, string moduleCode)
        {
            if (string.IsNullOrEmpty(moduleCode))
            {
                return true;
            }
            else
            {
                string[] modulecodes = APPCode.CacheHelper.GetALLModuleCodes(context);
                return modulecodes.Contains(moduleCode);
            }
        }
        public static string[] GetALLModuleCodes(HttpContext context)
        {
            return Web.APPCode.CacheHelper.GetALLModuleCodes(context);
        }
        public static string[] GetModuleCodes(HttpContext context, int UserID = 0)
        {
            return Web.APPCode.CacheHelper.GetModuleCodes(context, UserID: UserID);
        }
        public static string GetHostPath()
        {
            return "http://" + HttpContext.Current.Request.ServerVariables["HTTP_HOST"].ToString();
        }
        public static string GetRealContextPath()
        {
            string domain_path = "http://" + HttpContext.Current.Request.ServerVariables["HTTP_HOST"].ToString();
            if (domain_path.EndsWith("/"))
            {
                domain_path = domain_path.Substring(0, domain_path.Length - 1);
            }
            return domain_path + getApplicationPath();
        }
        public static string GetContextPath()
        {
            var context_path = ConfigurationManager.AppSettings["context_path"];
            if (!string.IsNullOrEmpty(context_path))
            {
                return context_path;
            }
            return GetRealContextPath();
        }
        public static string getApplicationPath()
        {
            string _ApplicationPath = HttpContext.Current.Request.ApplicationPath;
            if (_ApplicationPath.Length == 1)
            {
                _ApplicationPath = "";
            }
            else if (!_ApplicationPath.StartsWith("/"))
            {
                _ApplicationPath = "/" + _ApplicationPath;
            }
            return _ApplicationPath;
        }
        public static string GetVirName()
        {
            string VirName = WebUtil.getApplicationPath();
            if (string.IsNullOrEmpty(VirName))
            {
                VirName = "saas";
            }
            else if (VirName.StartsWith("/"))
            {
                VirName = VirName.Substring(1, VirName.Length - 1);
            }
            return VirName;
        }
        public static string CreatThumbnail(System.Drawing.Image image, string targetPath, int width, int height)
        {
            string dir = System.IO.Path.GetDirectoryName(targetPath);

            if (!System.IO.Directory.Exists(dir))
            {
                System.IO.Directory.CreateDirectory(dir);
            }

            bool isVertical = image.Height > image.Width;
            if (width == 0 || height == 0)
            {
                using (System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(image))
                {
                    bmp.Save(targetPath, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
            }
            else if ((isVertical && image.Height > height) || (!isVertical && image.Width > width))//缩放
            {
                int h = 0, w = 0;
                if (isVertical)
                {
                    h = height;
                    w = (int)(h * image.Width / image.Height);
                }
                else
                {
                    w = width;
                    h = (int)(w * image.Height / image.Width);
                }
                using (System.Drawing.Bitmap newBmp = new System.Drawing.Bitmap(image, w, h))
                {
                    newBmp.Save(targetPath, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
            }
            else//不需要缩放
            {
                using (System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(image))
                {
                    bmp.Save(targetPath, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
            }

            return targetPath;
        }
        public static bool GetBoolValue(HttpContext context, string name, bool DefaultValue = false)
        {
            if (!string.IsNullOrEmpty(context.Request[name]))
            {
                bool value = false;
                bool.TryParse(context.Request[name], out value);
                return value;
            }
            return DefaultValue;
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
        public static ProjectTree[] GetMyProjectDetailsTree(int UserID)
        {
            return Web.APPCode.CacheHelper.GetMyProjectDetailsTree(UserID);
        }
        public static DateTime GetDateTimeByStr(string str)
        {
            DateTime result = DateTime.MinValue;
            DateTime.TryParse(str, out result);
            return result;
        }
        public static string GetStrDate(DateTime Time, string format = "yyyy-MM-dd")
        {
            return Time > DateTime.MinValue ? Time.ToString(format) : "";
        }
        public static decimal GetDecimalByStr(string str, decimal defaultvalue = 0)
        {
            decimal result = defaultvalue;
            decimal.TryParse(str, out result);
            return result;
        }
        public static int GetIntByStr(string str, int defaultvalue = 0)
        {
            int result = defaultvalue;
            int.TryParse(str, out result);
            return result;
        }
        public static string GetStrByObj(Dictionary<string, object> dic, string obj)
        {
            if (!dic.ContainsKey(obj))
            {
                return string.Empty;
            }
            return dic[obj].ToString();
        }
        public static int GetIntByObj(Dictionary<string, object> dic, string obj, int defaultvalue = 0)
        {
            if (!dic.ContainsKey(obj))
            {
                return defaultvalue;
            }
            return GetIntByStr(dic[obj].ToString(), defaultvalue);
        }
        public static decimal GetDecimalByObj(Dictionary<string, object> dic, string obj, decimal defaultvalue = 0)
        {
            if (!dic.ContainsKey(obj))
            {
                return defaultvalue;
            }
            return GetDecimalByStr(dic[obj].ToString(), defaultvalue);
        }
        public static DateTime GetDateTimeByObj(Dictionary<string, object> dic, string obj)
        {
            if (!dic.ContainsKey(obj))
            {
                return DateTime.MinValue;
            }
            return GetDateTimeByStr(dic[obj].ToString());
        }

        public static string getServerValue(HttpContext context, string name)
        {
            string PostName = "ctl00$content$";
            return context.Request.Params[PostName + name];
        }
        public static int getServerIntValue(HttpContext context, string name)
        {
            int result = 0;
            int.TryParse(getServerValue(context, name), out result);
            return result;
        }
        public static DateTime getServerTimeValue(HttpContext context, string name)
        {
            DateTime result = DateTime.MinValue;
            DateTime.TryParse(getServerValue(context, name), out result);
            return result;
        }
        public static decimal getServerDecimalValue(HttpContext context, string name)
        {
            decimal result = 0;
            decimal.TryParse(getServerValue(context, name), out result);
            return result;
        }

        public static string FormatMoney(decimal money, int defaultcount = 2)
        {
            return Utility.Tools.FormatMoney(money, defaultcount: defaultcount);
        }
        public static decimal GetPrintHeight(string PrintType = "")
        {
            if (string.IsNullOrEmpty(PrintType))
            {
                return 93;
            }
            return PrintType.Equals(Utility.EnumModel.PrintTypeDefine.A4Two.ToString()) ? 142 : 93;
        }
        public static ProjectTree[] GetMyProjectsByLevel(int level, int UserID)
        {
            return Web.APPCode.CacheHelper.GetMyProjectsByLevel(level, UserID);
        }
        public static string GetOpenIDPrefix()
        {
            string CookieKey = WebUtil.getApplicationPath();
            return string.IsNullOrEmpty(CookieKey) ? "openid" : CookieKey + "_openid";
        }
        public static string GetHasRoomPrefix()
        {
            string CookieKey = WebUtil.getApplicationPath();
            return string.IsNullOrEmpty(CookieKey) ? "hasroom" : CookieKey + "_hasroom";
        }
        public static void GetTimeRangeByMonthNumber(int MonthNumber, int Year, out DateTime StartTime, out DateTime EndTime)
        {
            DateTime Now = new DateTime(Year, 1, 1);
            StartTime = Convert.ToDateTime(Now.ToString("yyyy-" + MonthNumber.ToString("D2") + "-01"));
            EndTime = StartTime.AddMonths(1).AddSeconds(-1);
        }
        public static void GetFeeListByMonth(int monthnumber, RoomFeeAnalysis[] my_fee_list, ViewRoomFeeHistoryDetail[] my_fee_history_list, ViewRoomFeeHistoryDetail[] my_fee_history_list_chongdi, int Year, out decimal YingShouFee, out decimal YiShouFee, out decimal JianMianFee, out decimal WeiShouFee, out decimal ChongDiFee, out decimal Cycle_WeiShouFee)
        {
            YingShouFee = 0;
            YiShouFee = 0;
            JianMianFee = 0;
            WeiShouFee = 0;
            ChongDiFee = 0;
            decimal Cycle_YiShouFee = 0;
            decimal Cycle_JianMianFee = 0;
            Cycle_WeiShouFee = 0;
            decimal Cycle_ChongDiFee = 0;
            DateTime StartTime = DateTime.MinValue;
            DateTime EndTime = DateTime.MinValue;
            WebUtil.GetTimeRangeByMonthNumber(monthnumber, Year, out StartTime, out EndTime);
            var my_fee_history_list1 = ViewRoomFeeHistoryDetail.GetFinalViewRoomFeeHistoryDetailDictionary(my_fee_history_list, StartTime, EndTime).ToArray();
            var my_fee_history_list_chongdi_1 = ViewRoomFeeHistoryDetail.GetFinalViewRoomFeeHistoryDetailDictionary(my_fee_history_list_chongdi, StartTime, EndTime).ToArray();
            decimal YingShouFee_1 = 0;
            decimal YingShouFee_2 = 0;
            if (my_fee_history_list1.Length > 0)
            {
                decimal RealCost = my_fee_history_list1.Sum(p => Convert.ToDecimal(p["MonthTotalCost"]));
                ChongDiFee = my_fee_history_list_chongdi_1.Where(p => Convert.ToInt32(p["ChargeState"]) == 4).Sum(p => Convert.ToDecimal(p["MonthTotalCost"]));
                YiShouFee = RealCost - ChongDiFee;
                JianMianFee = my_fee_history_list1.Sum(p => Convert.ToDecimal(p["MonthDiscountCost"]));
                var my_fee_history_list2 = my_fee_history_list1.Where(p => (Convert.ToInt32(p["FeeType"]) == 4 && Convert.ToInt32(p["ImportFeeID"]) > 0) || Convert.ToInt32(p["FeeType"]) != 4).ToArray();
                var my_fee_history_list_chongdi_2 = my_fee_history_list_chongdi_1.Where(p => (Convert.ToInt32(p["FeeType"]) == 4 && Convert.ToInt32(p["ImportFeeID"]) > 0) || Convert.ToInt32(p["FeeType"]) != 4).ToArray();
                decimal Cycle_RealCost = my_fee_history_list2.Sum(p => Convert.ToDecimal(p["MonthTotalCost"]));
                Cycle_ChongDiFee = my_fee_history_list_chongdi_2.Where(p => Convert.ToInt32(p["ChargeState"]) == 4).Sum(p => Convert.ToDecimal(p["MonthTotalCost"]));
                Cycle_YiShouFee = Cycle_RealCost - Cycle_ChongDiFee;
                Cycle_JianMianFee = my_fee_history_list2.Sum(p => Convert.ToDecimal(p["MonthDiscountCost"]));
                YingShouFee_1 = my_fee_history_list1.Sum(p => Convert.ToDecimal(p["TotalCost"]));
            }
            var my_fee_list1 = RoomFeeAnalysis.GetRoomFeeAnalysisDictionary(my_fee_list, StartTime, EndTime).ToArray();
            if (my_fee_list1.Length > 0)
            {
                WeiShouFee = my_fee_list1.Sum(p => Convert.ToDecimal(p["TotalFinalCost"]));
                Cycle_WeiShouFee = my_fee_list1.Where(p => (Convert.ToInt32(p["FeeType"]) == 4 && Convert.ToInt32(p["ImportFeeID"]) <= 0) || Convert.ToInt32(p["FeeType"]) != 4).Sum(p => Convert.ToDecimal(p["TotalFinalCost"]));
                YingShouFee_2 = my_fee_list1.Sum(p => Convert.ToDecimal(p["TotalCost"]));
            }
            YingShouFee = YingShouFee_1 + YingShouFee_2;
        }
        public static string GetWechatTemplatePath(string xmlpath)
        {
            string application_path = WebUtil.getApplicationPath().ToLower();
            if (!string.IsNullOrEmpty(application_path))
            {
                if (!xmlpath.ToLower().StartsWith(application_path))
                {
                    xmlpath = application_path + xmlpath;
                }
            }
            string FullPath = HttpContext.Current.Server.MapPath(xmlpath);
            //LogHelper.WriteDebug("XMLFullPath", FullPath);
            if (!System.IO.File.Exists(FullPath))
            {
                return "";
            }
            return xmlpath;
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
        UNROOMCONNECTED = -101,
    }
}
