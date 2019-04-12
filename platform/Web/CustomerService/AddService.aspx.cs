using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.CustomerService
{
    public partial class AddService : BasePage
    {
        public int ProjectID = 0;
        public string guid = string.Empty;
        public int WechatServiceID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            guid = System.Guid.NewGuid().ToString();
            this.sStartTime.InnerHtml = this.tdStartTime.Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            this.sAddUserName.InnerHtml = this.tdAddUserName.Value = WebUtil.GetUser(this.Context).RealName;
            int.TryParse(Request.QueryString["WechatID"], out WechatServiceID);
            var wechatService = Foresight.DataAccess.Wechat_Service.GetWechat_Service(WechatServiceID);
            if (wechatService != null)
            {
                ProjectID = wechatService.RoomID;
                var type = Foresight.DataAccess.ServiceType.GetServiceTypes().FirstOrDefault(p => p.ServiceTypeName.Equals(wechatService.ServiceTypeDesc));
                this.tdFullName.Value = wechatService.FullName;
                this.tdProjectName.Value = "无";
                this.tdServiceType.Value = type != null ? type.ID.ToString() : "";
                var wechat = Foresight.DataAccess.Wechat_User.GetWechat_UserByUserOpenID(wechatService.OpenID);
                this.tdAddCustomerName.Value = wechat != null ? wechat.NickName : "";
                this.tdServiceContent.Value = wechatService.ServiceContent;
                this.tdAppointTime.Value = wechatService.AddTime > DateTime.MinValue ? wechatService.AddTime.ToString("yyyy-MM-dd HH:mm") : "";
                this.tdAddCallPhone.Value = wechatService.PhoneNumber;
                this.tdAddCustomerName.Value = wechatService.ServiceMan;
                if (wechatService.AddUserID > 0)
                {
                    tdAcceptMan.Value = wechatService.AddUserID.ToString();
                    var user = Foresight.DataAccess.User.GetUser(wechatService.AddUserID);
                    this.hdAcceptMan.Value = user != null ? user.RealName : "";
                    this.tdAddUserName.Value = user != null ? user.RealName : "";
                }
                this.tdIsSendAPP.Checked = true;
            }
        }
    }
}