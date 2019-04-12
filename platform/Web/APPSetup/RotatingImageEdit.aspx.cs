using Foresight.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.APPSetup
{
    public partial class RotatingImageEdit : BasePage
    {
        public int ID = 0;
        public string ImagePath = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["ID"] != null)
                {
                    int.TryParse(Request.QueryString["ID"], out ID);
                }
                if (ID > 0)
                {
                    var data = Foresight.DataAccess.Mall_RotatingImage.GetMall_RotatingImage(ID);
                    if (data != null)
                    {
                        SetInfo(data);
                    }
                }
                var list = Foresight.DataAccess.Mall_RotatingImage.GetRotatingTypeList(IncludeALL: false);
                this.hdTypeValue.Value = Utility.JsonConvert.SerializeObject(list);
            }
        }
        private void SetInfo(Foresight.DataAccess.Mall_RotatingImage data)
        {
            if (!string.IsNullOrEmpty(data.ImagePath))
            {
                this.ImagePath = WebUtil.GetContextPath() + data.ImagePath;
            }
            this.tdType.Value = data.Type > 0 ? data.Type.ToString() : "";
            this.tdSortOrder.Value = data.SortOrder > 0 ? data.SortOrder.ToString() : "";
            if (data.URLLinkType == 1)
            {
                var product = Foresight.DataAccess.Mall_Product.GetMall_Product(data.URLLinkID);
                if (product != null)
                {
                    this.tdURLLinkNames.Value = product.ProductName;
                }
            }
            else if (data.URLLinkType == 2)
            {
                var business = Foresight.DataAccess.Mall_Business.GetMall_Business(data.URLLinkID);
                if (business != null)
                {
                    this.tdURLLinkNames.Value = business.BusinessName;
                }
            }
            else if (data.URLLinkType == 3 || data.URLLinkType == 4)
            {
                var msg = Foresight.DataAccess.Wechat_Msg.GetWechat_Msg(data.URLLinkID);
                if (msg != null)
                {
                    this.tdURLLinkNames.Value = msg.MsgTitle;
                }
            }
            else if (data.URLLinkType == 5)
            {
                var service = Foresight.DataAccess.Wechat_HouseService.GetWechat_HouseService(data.URLLinkID);
                if (service != null)
                {
                    this.tdURLLinkNames.Value = service.Title;
                }
            }
            this.hdProducts.Value = data.URLLinkID > 0 ? "[" + data.URLLinkID.ToString() + "]" : "[]";
            this.tdURLLinkType.Value = data.URLLinkType.ToString();
            this.tdWaitSecond.Value = data.WaitSecond > 0 ? data.WaitSecond.ToString("0") : "";
            this.tdIsActive.Value = data.IsActive ? "1" : "0";
        }
    }
}