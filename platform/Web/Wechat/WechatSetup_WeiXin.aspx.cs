using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using Utility;

namespace Web.Wechat
{
    public partial class WechatSetup_WeiXin : BasePage
    {
        public string CertFileLocaiton = string.Empty;
        public int Is_Active = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.tdOauth2Url.Value = "http://demo.saasyy.com/" + WebUtil.getApplicationPath();
            this.tdWxApiUrl.Value = "http://weixin.saasyy.com/" + WebUtil.getApplicationPath();
            var list = Foresight.DataAccess.SysConfig.GetSysConfigListByType("Wechat");
            foreach (var item in list)
            {
                switch (item.Name)
                {
                    case "AppID":
                        this.tdAppID.Value = item.Value;
                        break;
                    case "AppSecret":
                        this.tdAppSecret.Value = item.Value;
                        break;
                    case "MCHID":
                        this.tdMCHID.Value = item.Value;
                        break;
                    case "MCHKey":
                        this.tdMCHKey.Value = item.Value;
                        break;
                    case "SSLCERT_PATH":
                        if (!string.IsNullOrEmpty(item.Value))
                        {
                            this.CertFileLocaiton = WebUtil.GetContextPath() + item.Value;
                        }
                        break;
                    case "SSLCERT_PASSWORD":
                        this.tdSSLCERT_PASSWORD.Value = item.Value;
                        break;
                    case "Token":
                        this.tdToken.Value = item.Value;
                        break;
                    case "Oauth2Url":
                        this.tdOauth2Url.Value = item.Value;
                        break;
                    case "WxApiUrl":
                        this.tdWxApiUrl.Value = item.Value;
                        break;
                    case "WechatEnable":
                        this.Is_Active = int.Parse(item.Value);
                        break;
                    default:
                        break;
                }
            }
        }
        protected override void ProcessAjaxRequest(HttpContext context, string action)
        {
            switch (action)
            {
                case "startwechat":
                    startwechat(context);
                    break;
                default:
                    base.ProcessAjaxRequest(context, action);
                    break;
            }
        }
        private void startwechat(HttpContext context)
        {
            try
            {
                var config = new SiteConfig();
                if (WebUtil.GetContextPath().Contains(config.SITE_URL))
                {
                    string VirName = WebUtil.GetVirName();
                    int SiteNumber = int.Parse(config.Wechat_SiteNumber);
                    string ZipPath = config.Wechat_ZipPath;
                    string SitePath = config.Wechat_SitePath;
                    Utility.Tools.UnZipFile(ZipPath, SitePath, VirName);
                    bool sitestatus = IISManager.CreateWebSite(string.Empty, VirName, SitePath + VirName + @"\weixin", false, 1, SiteNumber, "localhost");
                    string ConfigPath = SitePath + VirName + @"\weixin\Web.config";
                    Dictionary<string, object> dic = new Dictionary<string, object>();
                    string SiteURL = config.SITE_URL;
                    if (SiteURL.EndsWith("/"))
                    {
                        SiteURL = SiteURL.Substring(0, SiteURL.Length - 1);
                    }
                    if (!SiteURL.EndsWith(VirName) && !VirName.Equals("saas"))
                    {
                        SiteURL = SiteURL + "/" + VirName;
                    }
                    dic["apiurl"] = SiteURL + "/handler/api.ashx";
                    dic["SITE_URL"] = SiteURL;
                    Utility.IISManager.UpdateConfigValue(ConfigPath, dic);
                }
                var list = Foresight.DataAccess.SysConfig.GetSysConfigListByType("Wechat");
                var data = list.FirstOrDefault(p => p.Name.Equals("WechatEnable"));
                if (data == null)
                {
                    data = new Foresight.DataAccess.SysConfig();
                    data.AddTime = DateTime.Now;
                    data.ConfigType = "Wechat";
                }
                data.Name = "WechatEnable";
                data.Value = "1";
                data.Save();
                WebUtil.WriteJsonResult(context, "生成成功");
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("WechatSetup", "startwechat", ex);
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, ex);
            }
        }
    }
}