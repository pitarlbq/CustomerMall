using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.WeiXin
{
    public partial class MallDoorQrCode : System.Web.UI.Page
    {
        public int CodeID = 0;
        public string CodePath = string.Empty;
        public string CodeSummary = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["CodeID"] != null)
                {
                    int.TryParse(Request.QueryString["CodeID"], out CodeID);
                }
                Foresight.DataAccess.Mall_DoorRemoteQrCode data = null;
                if (CodeID > 0)
                {
                    data = Foresight.DataAccess.Mall_DoorRemoteQrCode.GetMall_DoorRemoteQrCode(CodeID);
                }
                if (data == null)
                {
                    Response.Write("<p style=\"font-size:20px;\">无效的请求</p>");
                    Response.End();
                }
                if (data.EndTime < DateTime.Now)
                {
                    Response.Write("<p style=\"font-size:20px;\">二维码已过期</p>");
                    Response.End();
                    return;
                }
                this.tdPath.Src = WebUtil.GetContextPath() + data.QrCodePath;
                this.tdSummary.InnerHtml = data.EndTime.ToString("HH点mm分") + "前有效，可以使用" + data.EffecNumber.ToString("0") + "次";
            }
        }
    }
}