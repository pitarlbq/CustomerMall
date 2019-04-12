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
    public partial class WechatSetup_APPPay : BasePage
    {
        public string MobileCertFileLocaiton = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            var list = Foresight.DataAccess.SysConfig.GetSysConfigListByType("Wechat");
            foreach (var item in list)
            {
                switch (item.Name)
                {
                    case "MobileAppID":
                        this.tdMobileAPPID.Value = item.Value;
                        break;
                    case "MobileAppSecret":
                        this.tdMobileAppSecret.Value = item.Value;
                        break;
                    case "MobileMCHID":
                        this.tdMobileMCHID.Value = item.Value;
                        break;
                    case "MobileMCHKey":
                        this.tdMobileMCHKey.Value = item.Value;
                        break;
                    case "MobileSSLCERT_PATH":
                        if (!string.IsNullOrEmpty(item.Value))
                        {
                            this.MobileCertFileLocaiton = item.Value;
                        }
                        break;
                    case "MobileSSLCERT_PASSWORD":
                        this.tdMobileSSLCERT_PASSWORD.Value = item.Value;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}