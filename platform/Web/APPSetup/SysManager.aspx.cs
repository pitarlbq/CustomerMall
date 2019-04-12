using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utility;

namespace Web.APPSetup
{
    public partial class SysManager : BasePage
    {
        public string OpenDoorVideoFilePath = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            var syslist = Foresight.DataAccess.SysConfig.GetSysConfigs().ToArray();
            SetData(syslist);
        }
        private void SetData(Foresight.DataAccess.SysConfig[] syslist)
        {
            string Name = Foresight.DataAccess.SysConfigNameDefine.OrderCloseTime.ToString();
            this.tdOrderCloseTime.Value = SaveDefaultConfig(syslist, Name, "24");

            Name = Foresight.DataAccess.SysConfigNameDefine.OrderAuoShipped.ToString();
            this.tdOrderAuoShipped.Value = SaveDefaultConfig(syslist, Name, "72");

            Name = Foresight.DataAccess.SysConfigNameDefine.OrderAutoRate.ToString();
            this.tdOrderAutoRate.Value = SaveDefaultConfig(syslist, Name, "24");

            Name = Foresight.DataAccess.SysConfigNameDefine.OrderRefundTime.ToString();
            this.tdOrderRefundTime.Value = SaveDefaultConfig(syslist, Name, "30");

            Name = Foresight.DataAccess.SysConfigNameDefine.AllowDefineAddress.ToString();
            this.tdAllowDefineAddress.Value = SaveDefaultConfig(syslist, Name, "0");

            Name = Foresight.DataAccess.SysConfigNameDefine.JPushXianShiNotify.ToString();
            this.tdJPushXianShiNotify.Value = SaveDefaultConfig(syslist, Name, "2");

            Name = Foresight.DataAccess.SysConfigNameDefine.JPushTuanGouNotify.ToString();
            this.tdJPushTuanGouNotify.Value = SaveDefaultConfig(syslist, Name, "2");

            Name = Foresight.DataAccess.SysConfigNameDefine.MallCategoryLineCount.ToString();
            this.tdMallCategoryLineCount.Value = SaveDefaultConfig(syslist, Name, "4");

            Name = Foresight.DataAccess.SysConfigNameDefine.MallHomeYouXuanCount.ToString();
            this.tdMallHomeYouXuanCount.Value = SaveDefaultConfig(syslist, Name, "10");

            Name = Foresight.DataAccess.SysConfigNameDefine.MallHomePinTanCount.ToString();
            this.tdMallHomePinTanCount.Value = SaveDefaultConfig(syslist, Name, "5");

            Name = Foresight.DataAccess.SysConfigNameDefine.MallHomeBusinessCount.ToString();
            this.tdMallHomeBusinessCount.Value = SaveDefaultConfig(syslist, Name, "6");

            Name = Foresight.DataAccess.SysConfigNameDefine.MallHomeHotSaleCount.ToString();
            this.tdMallHomeHotSaleCount.Value = SaveDefaultConfig(syslist, Name, "10");

            Name = Foresight.DataAccess.SysConfigNameDefine.MallMallCategoryCount.ToString();
            this.tdMallMallCategoryCount.Value = SaveDefaultConfig(syslist, Name, "3");

            Name = Foresight.DataAccess.SysConfigNameDefine.MallMallBusinessCount.ToString();
            this.tdMallMallBusinessCount.Value = SaveDefaultConfig(syslist, Name, "3");

            Name = Foresight.DataAccess.SysConfigNameDefine.NoGrabTransfer.ToString();
            this.tdNoGrabTransfer.Value = SaveDefaultConfig(syslist, Name, "24");

            Name = Foresight.DataAccess.SysConfigNameDefine.OpenDoorVideoFilePath.ToString();
            OpenDoorVideoFilePath = SaveDefaultConfig(syslist, Name, "");
            if (!string.IsNullOrEmpty(OpenDoorVideoFilePath))
            {
                OpenDoorVideoFilePath = WebUtil.GetContextPath() + OpenDoorVideoFilePath;
            }
        }
        private string SaveDefaultConfig(Foresight.DataAccess.SysConfig[] syslist, string Name, string Value)
        {
            var data = syslist.FirstOrDefault(p => p.Name.Equals(Name));
            if (data == null)
            {
                data = new Foresight.DataAccess.SysConfig();
                data.Name = Name;
                data.Value = Value;
                data.AddTime = DateTime.Now;
                data.Save();
            }
            return data.Value;
        }
    }
}