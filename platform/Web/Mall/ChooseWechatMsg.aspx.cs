using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Mall
{
    public partial class ChooseWechatMsg : BasePage
    {
        /// <summary>
        /// 1-微信通知 2-业主APP通知3-员工APP通知
        /// </summary>
        public int type = 1;
        /// <summary>
        /// 1-通知公告 2-活动 3-新闻
        /// </summary>
        public int msgtypeid = 1;

        public int singleselect = 0;
        public string from = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["type"]))
            {
                int.TryParse(Request.QueryString["type"], out type);
            }
            if (!string.IsNullOrEmpty(Request.QueryString["msgtypeid"]))
            {
                int.TryParse(Request.QueryString["msgtypeid"], out msgtypeid);
            }
            if (Request.QueryString["singleselect"] != null)
            {
                int.TryParse(Request.QueryString["singleselect"], out singleselect);
            }
            if (Request.QueryString["from"] != null)
            {
                from = Request.QueryString["from"];
            }
        }
    }
}