using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Wechat
{
    public partial class MsgMgr : BasePage
    {
        /// <summary>
        /// 1-微信通知 2-业主员工APP通知 3-商户通知
        /// </summary>
        public int type = 1;
        /// <summary>
        /// 1-通知公告 2-活动(未使用) 3-新闻
        /// </summary>
        public int msgtypeid = 1;
        public int CanEdit = 0;
        public int CanAdd = 0;
        public int CanRemove = 0;
        public int CanSendAPP = 0;

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
            if (this.type == 1 || this.type == 3)
            {
                this.CanAdd = 1;
                this.CanEdit = 1;
                this.CanRemove = 1;
            }
            else
            {
                if (base.CheckAuthByModuleCode("1101332") && this.msgtypeid == 1)
                {
                    this.CanAdd = 1;
                }
                if (base.CheckAuthByModuleCode("1101335") && this.msgtypeid == 3)
                {
                    this.CanAdd = 1;
                }
                if (base.CheckAuthByModuleCode("1101333") && this.msgtypeid == 1)
                {
                    this.CanEdit = 1;
                }
                if (base.CheckAuthByModuleCode("1101336") && this.msgtypeid == 3)
                {
                    this.CanEdit = 1;
                }
                if (base.CheckAuthByModuleCode("1101334") && this.msgtypeid == 1)
                {
                    this.CanRemove = 1;
                }
                if (base.CheckAuthByModuleCode("1101338") && this.msgtypeid == 3)
                {
                    this.CanRemove = 1;
                }
            }
            if (this.type == 1)
            {
                this.CanSendAPP = 0;
            }
            else if (this.type == 3)
            {
                this.CanSendAPP = 1;
            }
            else
            {
                if (base.CheckAuthByModuleCode("1101337") && this.msgtypeid == 1)
                {
                    this.CanSendAPP = 1;
                }
                if (base.CheckAuthByModuleCode("1101339") && this.msgtypeid == 3)
                {
                    this.CanSendAPP = 1;
                }
            }
        }
    }
}