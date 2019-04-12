using Foresight.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Wechat
{
    public partial class ViewService : BasePage
    {
        public int ServiceID;
        protected void Page_Load(object sender, EventArgs e)
        {
            ServiceID = 0;
            int.TryParse(Request.QueryString["ID"], out ServiceID);
            if (ServiceID <= 0)
            {
                Response.End();
                return;
            }
            var data = Foresight.DataAccess.Wechat_Service.GetWechat_Service(ServiceID);
            if (data == null)
            {
                Response.End();
                return;
            }
            SetInfo(data);
            return;
        }
        private void SetInfo(Foresight.DataAccess.Wechat_Service data)
        {
            if (!string.IsNullOrEmpty(data.ServiceType))
            {
                this.labTitle.InnerHtml = Utility.EnumHelper.GetDescription(typeof(Utility.EnumModel.WechatServiceType), data.ServiceType);
            }
            var wechatuser = Foresight.DataAccess.Wechat_User.GetWechat_UserByUserOpenID(data.OpenID);
            this.tdOpenID.Value = wechatuser != null ? wechatuser.NickName : "";
            this.tdPhoneNumber.Value = data.PhoneNumber;
            this.tdServiceAddTime.Value = data.ServiceAddTime > DateTime.MinValue ? data.ServiceAddTime.ToString("yyyy-MM-dd HH:mm:ss") : "";
            this.tdServiceContent.Value = data.ServiceContent;
            var imglist = Foresight.DataAccess.Wechat_ServiceImg.GetWechat_ServiceImgs().Where(p => p.ServiceID == data.ID);
            this.rptImg.DataSource = imglist;
            this.rptImg.DataBind();
            if (!string.IsNullOrEmpty(data.FullName))
            {
                this.tdFullName.Value = data.FullName;
            }
            else if (data.RoomID > 0)
            {
                var room = Foresight.DataAccess.Project.GetProject(data.RoomID);
                this.tdFullName.Value = room != null ? room.FullName : "";
            }
        }
        public string getFullPath(string path)
        {
            return WebUtil.GetContextPath() + path;
        }
    }
}