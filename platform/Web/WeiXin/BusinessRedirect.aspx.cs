using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utility;
using Web.APPCode;

namespace Web.WeiXin
{
    public partial class BusinessRedirect : WechatBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Response.Redirect(WeixinHelper.ResolveClientUrl("http://mp.weixin.qq.com/bizmall/mallshelf?id=&t=mall/list&biz=MzI5NDQ2MDk4Mw==&shelf_id=1&showwxpaytitle=1#wechat_redirect"), true);
        }
    }
}