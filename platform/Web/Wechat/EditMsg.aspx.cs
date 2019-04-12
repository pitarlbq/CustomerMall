using Foresight.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utility;

namespace Web.Wechat
{
    public partial class EditMsg : BasePage
    {
        public int ID = 0;
        /// <summary>
        /// 1-微信通知 2-业主APP通知3-员工APP通知
        /// </summary>
        public int type = 1;
        /// <summary>
        /// 1-通知公告 2-活动 3-新闻
        /// </summary>
        public int msgtypeid = 1;

        public string MsgType = string.Empty;

        public bool IsMallOn = false;
        public bool IsMallBusinessOn = false;
        public bool IsMallInHouseUserOn = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var site_config = new Utility.SiteConfig();
                IsMallOn = site_config.IsMallOn;
                IsMallBusinessOn = site_config.IsMallBusinessOn;
                IsMallInHouseUserOn = site_config.IsMallInHouseUserOn;
                if (!string.IsNullOrEmpty(Request.QueryString["type"]))
                {
                    int.TryParse(Request.QueryString["type"], out type);
                }
                if (!string.IsNullOrEmpty(Request.QueryString["msgtypeid"]))
                {
                    int.TryParse(Request.QueryString["msgtypeid"], out msgtypeid);
                }
                if (!string.IsNullOrEmpty(Request.QueryString["MsgType"]))
                {
                    MsgType = Request.QueryString["MsgType"];
                }
                var list = Foresight.DataAccess.Wechat_MsgCategory.GetWechat_MsgCategories().OrderBy(p => p.SortOrder).ToArray();
                var list_items = list.Select(p =>
                {
                    var item = new { ID = p.ID, CategoryName = p.CategoryName };
                    return item;
                });
                this.hdCategory.Value = JsonConvert.SerializeObject(list_items);
                int.TryParse(Request.QueryString["ID"], out ID);
                if (ID > 0)
                {
                    var data = Foresight.DataAccess.Wechat_Msg.GetWechat_Msg(ID);
                    if (data != null)
                    {
                        SetInfo(data);
                        return;
                    }
                }
                if (type == 1)
                {
                    this.tdIsWechatSend.Checked = true;
                }
                if (type == 2)
                {
                    this.tdIsCustomerAPPSend.Checked = true;
                }
                if (type == 3)
                {
                    this.tdIsUserAPPSend.Checked = true;
                }
                this.tdPublishTime.Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            }
        }
        private void SetInfo(Foresight.DataAccess.Wechat_Msg data)
        {
            this.tdTitle.Value = data.MsgTitle;
            this.tdSummary.Value = data.MsgSummary;
            this.tdIsShow.Value = data.IsShow ? "1" : "0";
            this.hdContent.Value = string.IsNullOrEmpty(data.HTMLContent) ? data.MsgContent : data.HTMLContent;
            this.tdPublishTime.Value = data.PublishTime > DateTime.MinValue ? data.PublishTime.ToString("yyyy-MM-dd HH:mm:ss") : "";
            this.tdStartTime.Value = data.StartTime > DateTime.MinValue ? data.StartTime.ToString("yyyy-MM-dd HH:mm:ss") : "";
            this.tdEndTime.Value = data.EndTime > DateTime.MinValue ? data.EndTime.ToString("yyyy-MM-dd HH:mm:ss") : "";
            this.tdIsTopShow.Value = data.IsTopShow ? "1" : "0";
            this.tdIsWechatSend.Checked = data.IsWechatSend;
            this.tdIsCustomerAPPSend.Checked = data.IsCustomerAPPSend;
            this.tdIsUserAPPSend.Checked = data.IsUserAPPSend;
            this.tdIsBusinessAPPSend.Checked = data.IsBusinessAPPSend;
            var list = Foresight.DataAccess.Wechat_MsgProject.GetWechat_MsgProjectList(data.ID);
            var ProjectIDList = list.Select(p => p.ProjectID).ToList();
            if (ProjectIDList.Count > 0)
            {
                this.hdProjectIDs.Value = JsonConvert.SerializeObject(ProjectIDList);
            }
            this.tdCategoryID.Value = data.CategoryID > 0 ? data.CategoryID.ToString() : string.Empty;
            this.tdSortOrder.Value = data.SortOrder > int.MinValue ? data.SortOrder.ToString() : "";
        }
    }
}