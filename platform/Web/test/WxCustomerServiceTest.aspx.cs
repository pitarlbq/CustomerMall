using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.APPCode;
using WeiXin;

namespace Web.test
{
    public partial class WxCustomerServiceTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnSave1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.tdAccountName.Value))
            {
                this.tdResponse1.Text = "客服帐号不能为空";
                return;
            }
            if (string.IsNullOrEmpty(this.tdAccountNickName.Value))
            {
                this.tdResponse1.Text = "昵称不能为空";
                return;
            }
            var result = MessageHandler.CreateCustomerServiceAccount(WeixinHelper.GetAccessToken(null), this.tdAccountName.Value, this.tdAccountNickName.Value);
            this.tdResponse1.Text = result.Body;
        }
        protected void btnSave2_Click(object sender, EventArgs e)
        {
            JObject obj = new JObject();
            obj.Add("loginname", "admin");
            obj.Add("guid", Guid.NewGuid().ToString());
            obj.Add("url", WebUtil.GetContextPath());
            obj.Add("socketserver", "http://" + new Utility.SiteConfig().SocketURL);
            obj.Add("action", "login");
            obj.Add("systemtype", "platform");
            //obj.Add("url", WebUtil.GetContextPath());
            //obj.Add("socketserver", "http://" + new Utility.SiteConfig().SocketURL);
            //obj.Add("action", "notifyalert");
            //obj.Add("systemtype", "platform");
            SocketIOClient.SocketClient.EmitMsg(obj);
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.tdCustomerAccount.Value))
            {
                this.tdResponse.Text = "客服帐号不能为空";
                return;
            }
            if (string.IsNullOrEmpty(this.tdOpenID.Value))
            {
                this.tdResponse.Text = "用户OpenID不能为空";
                return;
            }
            var result = MessageHandler.CreateCustomerService(WeixinHelper.GetAccessToken(null), this.tdCustomerAccount.Value, this.tdOpenID.Value);
            this.tdResponse.Text = result.Body;
        }
    }
}