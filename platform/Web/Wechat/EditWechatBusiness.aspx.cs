using Foresight.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Wechat
{
    public partial class EditWechatBusiness : BasePage
    {
        public int BusinessID = 0;
        public string BusinessImgPath = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request.QueryString["ID"], out BusinessID);
            if (BusinessID > 0)
            {
                var data = Foresight.DataAccess.Wechat_Business.GetWechat_Business(BusinessID);
                if (data != null)
                {
                    SetInfo(data);
                    return;
                }
            }
        }
        private void SetInfo(Foresight.DataAccess.Wechat_Business data)
        {
            this.tdBusinessName.Value = data.BusinessName;
            this.tdBusinessSummary.Value = data.BusinessSummary;
            this.tdIsPublish.Value = data.IsPublish ? "1" : "0";
            this.tdPhoneNumber.Value = data.PhoneNumber;
            this.BusinessImgPath = !string.IsNullOrEmpty(data.BusinessImg) ? WebUtil.GetContextPath() + data.BusinessImg : string.Empty;
        }
    }
}