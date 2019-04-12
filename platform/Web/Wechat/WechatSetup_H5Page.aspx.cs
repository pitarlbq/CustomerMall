using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Wechat
{
    public partial class WechatSetup_H5Page : BasePage
    {
        public string HomeBannerPath = string.Empty;
        public string ConnectRoomBannerPath = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var imageList = Foresight.DataAccess.Mall_RotatingImage.GetMall_RotatingImages().ToArray();
                var myImageData = imageList.FirstOrDefault(p => p.Type == 11);
                if (myImageData != null)
                {
                    this.HomeBannerPath = WebUtil.GetContextPath() + myImageData.ImagePath;
                }
                myImageData = imageList.FirstOrDefault(p => p.Type == 12);
                if (myImageData != null)
                {
                    this.ConnectRoomBannerPath = WebUtil.GetContextPath() + myImageData.ImagePath;
                }
                string Name = Foresight.DataAccess.SysConfigNameDefine.WechatConnnectRoomSummary.ToString();
                var sysConfig = Foresight.DataAccess.SysConfig.GetSysConfigByName(Name);
                if (sysConfig != null)
                {
                    this.tdWechatConnnectRoomSummary.Value = sysConfig.Value;
                }
            }
        }
    }
}