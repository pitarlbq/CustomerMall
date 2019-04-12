using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Wechat
{
    public partial class ViewQrCodeByURL : BasePage
    {
        public string pageurl = string.Empty;
        public string QrCodeImgPath = string.Empty;
        public string content = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["pageurl"] == null && Request.QueryString["content"] == null)
            {
                Response.End();
                return;
            }
            if (Request.QueryString["pageurl"] != null)
            {
                pageurl = Request.QueryString["pageurl"];
            }
            if (!pageurl.StartsWith("http"))
            {
                pageurl = WebUtil.GetContextPath() + pageurl;
            }
            if (Request.QueryString["content"] != null)
            {
                pageurl = Request.QueryString["content"];
            }
            var qrcode = Foresight.DataAccess.Wechat_Qrcode.GetWechat_QrcodeByPageURL(pageurl);
            if (qrcode != null)
            {
                if (qrcode.QrCodeImgPath.StartsWith("http"))
                {
                    QrCodeImgPath = qrcode.QrCodeImgPath;
                }
                else
                {
                    QrCodeImgPath = WebUtil.GetContextPath() + qrcode.QrCodeImgPath;
                }
            }
        }
    }
}