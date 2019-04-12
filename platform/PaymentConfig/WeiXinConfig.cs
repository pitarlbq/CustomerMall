using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;
using System.Xml;
using Utility;

namespace PaymentConfig
{
    public class WeiXinConfig
    {
        static WeiXinConfig()
        {
            SetStaticValue();
        }
        public static string MobileAppID = ConfigurationManager.AppSettings["wx_MobileAppID"];

        public static string MobileAppSecret = ConfigurationManager.AppSettings["wx_MobileAppSecret"];

        public static string MobileMCHID = ConfigurationManager.AppSettings["wx_MobileMCHID"];

        public static string MobileMCHKey = ConfigurationManager.AppSettings["wx_MobileMCHKey"];

        public static string MobileSSLCERT_PATH = ConfigurationManager.AppSettings["wx_MobileSSLCERT_PATH"];

        public static string MobileSSLCERT_PASSWORD = ConfigurationManager.AppSettings["wx_MobileSSLCERT_PASSWORD"];

        public static string AppID = ConfigurationManager.AppSettings["wx_AppId"];

        public static string AppSecret = ConfigurationManager.AppSettings["wx_AppSecret"];

        public static string MCHID = ConfigurationManager.AppSettings["wx_MCHID"];

        public static string MCHKey = ConfigurationManager.AppSettings["wx_KEY"];

        public static string SSLCERT_PATH = ConfigurationManager.AppSettings["wx_SSLCERT_PATH"];

        public static string SSLCERT_PASSWORD = ConfigurationManager.AppSettings["wx_SSLCERT_PASSWORD"];

        public static string Oauth2Url = ConfigurationManager.AppSettings["DOMAIN_URL"];

        public static string WxApiUrl = ConfigurationManager.AppSettings["wx_Server_API"];

        public static string Token = ConfigurationManager.AppSettings["wx_Token"];

        public static Foresight.DataAccess.SysConfig[] config_list = null;
        public static void SetStaticValue()
        {
            if (config_list == null)
            {
                config_list = GetConfigList();
            }
            foreach (var item in config_list)
            {
                switch (item.Name)
                {
                    case "MobileAppID":
                        MobileAppID = string.IsNullOrEmpty(item.Value) ? MobileAppID : item.Value;
                        break;
                    case "MobileAppSecret":
                        MobileAppSecret = string.IsNullOrEmpty(item.Value) ? MobileAppSecret : item.Value;
                        break;
                    case "MobileMCHID":
                        MobileMCHID = string.IsNullOrEmpty(item.Value) ? MobileMCHID : item.Value;
                        break;
                    case "MobileMCHKey":
                        MobileMCHKey = string.IsNullOrEmpty(item.Value) ? MobileMCHKey : item.Value;
                        break;
                    case "MobileSSLCERT_PATH":
                        if (!string.IsNullOrEmpty(item.Value))
                        {
                            //MobileSSLCERT_PATH = System.Web.Hosting.HostingEnvironment.MapPath(item.Value);
                            SSLCERT_PATH = HttpContext.Current.Server.MapPath("~" + item.Value);
                        }
                        break;
                    case "MobileSSLCERT_PASSWORD":
                        MobileSSLCERT_PASSWORD = string.IsNullOrEmpty(item.Value) ? MobileSSLCERT_PASSWORD : item.Value;
                        break;
                    case "AppID":
                        AppID = string.IsNullOrEmpty(item.Value) ? AppID : item.Value;
                        break;
                    case "AppSecret":
                        AppSecret = string.IsNullOrEmpty(item.Value) ? AppSecret : item.Value;
                        break;
                    case "MCHID":
                        MCHID = string.IsNullOrEmpty(item.Value) ? MCHID : item.Value;
                        break;
                    case "MCHKey":
                        MCHKey = string.IsNullOrEmpty(item.Value) ? MCHKey : item.Value;
                        break;
                    case "SSLCERT_PATH":
                        if (!string.IsNullOrEmpty(item.Value))
                        {
                            //SSLCERT_PATH = System.Web.Hosting.HostingEnvironment.MapPath(item.Value);
                            SSLCERT_PATH = HttpContext.Current.Server.MapPath("~" + item.Value);
                        }
                        break;
                    case "SSLCERT_PASSWORD":
                        SSLCERT_PASSWORD = string.IsNullOrEmpty(item.Value) ? SSLCERT_PASSWORD : item.Value;
                        break;
                    case "Token":
                        Token = string.IsNullOrEmpty(item.Value) ? Token : item.Value;
                        break;
                    case "Oauth2Url":
                        Oauth2Url = string.IsNullOrEmpty(item.Value) ? Oauth2Url : item.Value;
                        break;
                    case "WxApiUrl":
                        WxApiUrl = string.IsNullOrEmpty(item.Value) ? WxApiUrl : item.Value;
                        break;
                    default:
                        break;
                }
            }
        }
        public static void ClearCache()
        {
            config_list = null;
            SetStaticValue();
            string result = HttpRequest.PostToWxServer(null, new Dictionary<string, string>() { { "action", "clearwechatconfigcache" } });
            //LogHelper.WriteInfo("ClearCache", result);
        }
        public static Foresight.DataAccess.SysConfig[] GetConfigList()
        {
            if (ConfigurationManager.ConnectionStrings["ConnString"] != null)
            {
                config_list = Foresight.DataAccess.SysConfig.GetSysConfigListByType("Wechat");
            }
            if (config_list == null)
            {
                config_list = new Foresight.DataAccess.SysConfig[] { };
            }
            return config_list;
        }
    }
}
