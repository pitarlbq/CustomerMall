using Foresight.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Web.Wechat
{
    public partial class EditHouseService : BasePage
    {
        public int ID = 0;
        public string IconPath = string.Empty;
        public int type = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["type"] != null)
            {
                int.TryParse(Request.QueryString["type"], out type);
            }
            int.TryParse(Request.QueryString["ID"], out ID);
            if (ID > 0)
            {
                var data = Foresight.DataAccess.Wechat_HouseService.GetWechat_HouseService(ID);
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
        }
        private void SetInfo(Foresight.DataAccess.Wechat_HouseService data)
        {
            this.tdTitle.Value = data.Title;
            this.tdContactPhone.Value = data.ContactPhone;
            this.tdCategory.Value = data.CategoryID > 0 ? data.CategoryID.ToString() : "";
            this.tdPublishStatus.Value = data.IsPublish ? "1" : "0";
            this.hdServiceIncude.Value = data.ServiceIncude;
            this.hdServiceStandard.Value = data.ServiceStandard;
            this.hdAppointNotify.Value = data.AppointNotify;
            this.IconPath = string.IsNullOrEmpty(data.IconLink) ? string.Empty : WebUtil.GetContextPath() + data.IconLink;
            this.tdSortOrder.Value = data.SortOrder > 0 ? data.SortOrder.ToString() : "";
            this.type = data.ServiceType;
            this.tdIsWechatSend.Checked = data.IsWechatShow;
            this.tdIsCustomerAPPSend.Checked = data.IsAPPCustomerShow;
            this.tdIsUserAPPSend.Checked = data.IsAPPUserShow;
            this.tdOutLinkURL.Value = data.OutLinkURL;
            this.tdUseOutLink.Value = data.UseOutLink ? "1" : "0";
        }
    }
}