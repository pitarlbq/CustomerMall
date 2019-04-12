using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using Utility;

namespace Mobile.Web.AppCode
{
    public class WechatConfig
    {
        public WechatConfig()
        {
            SetValue();
        }
        public string AppID { get; set; }

        public string AppSecret { get; set; }

        public string Token { get; set; }

        public void SetValue()
        {
            if (config_list == null)
            {
                config_list = GetConfigList();
            }
            AppID = ConfigurationManager.AppSettings["wx_AppId"];
            AppSecret = ConfigurationManager.AppSettings["wx_AppSecret"];
            Token = ConfigurationManager.AppSettings["wx_Token"];
            foreach (var item in config_list)
            {
                switch (item.Name)
                {
                    case "AppID":
                        AppID = string.IsNullOrEmpty(item.Value) ? AppID : item.Value;
                        break;
                    case "AppSecret":
                        AppSecret = string.IsNullOrEmpty(item.Value) ? AppSecret : item.Value;
                        break;
                    case "Token":
                        Token = string.IsNullOrEmpty(item.Value) ? Token : item.Value;
                        break;
                    default:
                        break;
                }
            }
        }
        public void ClearCache()
        {
            config_list = null;
        }
        public static Utility.MobileWechatModel[] GetConfigList()
        {
            for (int i = 0; i < 3; i++)
            {
                if (config_list != null)
                {
                    break;
                }
                try
                {
                    string result = MessageProcessor.Post(null, new Dictionary<string, string>() { { "visit", "getwechatconfig" } });
                    LogHelper.WriteInfo("WechatConfig", "getwechatconfig: " + result);
                    Utility.MobileWechatModelResponse response = JsonConvert.DeserializeObject<Utility.MobileWechatModelResponse>(result);
                    if (response.status)
                    {
                        config_list = response.list;
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.WriteError("WechatConfig", "getwechatconfig", ex);
                }
            }
            if (config_list == null)
            {
                config_list = new Utility.MobileWechatModel[] { };
            }
            return config_list;
        }
        public static Utility.MobileWechatModel[] config_list = null;
    }
}