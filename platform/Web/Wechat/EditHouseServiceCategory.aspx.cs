using Foresight.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Web.Wechat
{
    public partial class EditHouseServiceCategory : BasePage
    {
        public int data_id = 0;
        public int type = 1;
        public string FilePath = string.Empty;
        public string FilePath_Active = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["type"] != null)
            {
                int.TryParse(Request.QueryString["type"], out type);
            }
            int.TryParse(Request.QueryString["ID"], out data_id);
            if (data_id > 0)
            {
                var data = Foresight.DataAccess.Wechat_HouseServiceCategory.GetWechat_HouseServiceCategory(data_id);
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
        private void SetInfo(Foresight.DataAccess.Wechat_HouseServiceCategory data)
        {
            this.tdCategoryName.Value = data.CategoryName;
            this.tdSortOrder.Value = data.SortOrder > 0 ? data.SortOrder.ToString() : "";
            this.type = data.ServiceType;
            this.tdIsWechatSend.Checked = data.IsWechatShow;
            this.tdIsCustomerAPPSend.Checked = data.IsAPPCustomerShow;
            this.tdIsUserAPPSend.Checked = data.IsAPPUserShow;
            if (!string.IsNullOrEmpty(data.FilePath))
            {
                this.FilePath = WebUtil.GetContextPath() + data.FilePath;
            }
            if (!string.IsNullOrEmpty(data.FilePath_Active))
            {
                this.FilePath_Active = WebUtil.GetContextPath() + data.FilePath_Active;
            }
        }
    }
}