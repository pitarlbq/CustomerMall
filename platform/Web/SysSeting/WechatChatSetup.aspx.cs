using Foresight.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.SysSeting
{
    public partial class WechatChatSetup : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var syslist = Foresight.DataAccess.SysConfig.GetSysConfigs().ToArray();
            SetInfo(syslist);
        }
        private void SetInfo(Foresight.DataAccess.SysConfig[] syslist)
        {
            var Name = SysConfigNameDefine.WechatChatStartTime.ToString();
            var data = SysConfig.SaveSysConfigByType(syslist, Name, "", CanSaveValue: false);
            this.tdWechatChatStartTime.Value = data.Value;

            Name = SysConfigNameDefine.WechatChatEndTime.ToString();
            data = SysConfig.SaveSysConfigByType(syslist, Name, "", CanSaveValue: false);
            this.tdWechatChatEndTime.Value = data.Value;

            Name = SysConfigNameDefine.WechatChatLeaveMsg.ToString();
            data = SysConfig.SaveSysConfigByType(syslist, Name, "", CanSaveValue: false);
            this.tdWechatChatLeaveMsg.Value = data.Value;

            Name = SysConfigNameDefine.WechatChatNotWorkMsg.ToString();
            data = SysConfig.SaveSysConfigByType(syslist, Name, "", CanSaveValue: false);
            this.tdWechatChatNotWorkMsg.Value = data.Value;
        }
    }
}