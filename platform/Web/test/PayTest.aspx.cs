using HuiShouYin;
using HuiShouYin.Domain;

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class PayTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void tdSumit_Click(object sender, EventArgs e)
        {
            var biz_content = new ApplyPay_BizContent();
            biz_content.out_trade_no = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            biz_content.subject = "测试";
            biz_content.total_fee = this.tdPayMoney.Text;
            biz_content.client_ip = "127.0.0.1";
            biz_content.notify_url = WebUtil.GetContextPath() + "/recive/pay/notify.aspx";
            biz_content.return_url = WebUtil.GetContextPath() + "/recive/pay/notify.aspx";
            biz_content.channel_type = this.tdchannel_type.Text;
            var List = new List<Dictionary<string, object>>();
            var dic = new Dictionary<string, object>();
            dic["ID"] = 1;
            dic["EndTime"] = DateTime.Now;
            List.Add(dic);

            biz_content.pay_option = "{\\\"idlist\\\":[{\\\"ID\\\":1,\\\"EndTime\\\":\\\"2015-01-01\\\"}],\\\"openid\\\":\\\"abcd\\\"}";
            var response = MessageHandler.SendApplyPay(biz_content);
            this.tdResult.Text = response.Body;
        }

        protected void btnChangeWebConfigErrorMode_Click(object sender, EventArgs e)
        {
            var dic = new Dictionary<string, object>();
            dic["ErrorMode"] = "On";
            string configPath = System.Web.HttpContext.Current.Server.MapPath(@"../web.config");
            Utility.IISManager.UpdateConfigValue(configPath, dic);
        }
    }
}