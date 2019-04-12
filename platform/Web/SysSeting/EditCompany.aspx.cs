using Foresight.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.SysSeting
{
    public partial class EditCompany : BasePage
    {
        public string LogoPath = string.Empty;
        public string HomeLogoPath = string.Empty;
        public string LogoBodyPath = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            int CompanyID = 0;
            int.TryParse(Request.QueryString["CompanyID"], out CompanyID);
            if (CompanyID > 0)
            {
                var data = Foresight.DataAccess.Company.GetCompany(CompanyID);
                if (data != null)
                {
                    SetInfo(data);
                    return;
                }
            }
        }
        private void SetInfo(Foresight.DataAccess.Company data)
        {
            this.tdRealName.Value = data.CompanyName;
            this.tdPhoneNumber.Value = data.PhoneNumber;
            this.tdAddress.Value = data.Address;
            this.tdIsActive.Value = data.IsActive ? "1" : "0";
            this.tdIsPay.Value = data.IsPay ? "1" : "0";
            this.tdDesc.Value = data.CompanyDesc;
            this.tdChargeMan.Value = data.ChargePerson;
            this.tdDistributor.Value = data.Distributor;
            this.tdUserCount.Value = data.UserCount == int.MinValue ? "0" : data.UserCount.ToString();
            this.tdStartTime.Value = data.ServerStartTime == DateTime.MinValue ? "" : data.ServerStartTime.ToString("yyyy-MM-dd HH:mm:ss");
            this.tdEndTime.Value = data.ServerEndTime == DateTime.MinValue ? "" : data.ServerEndTime.ToString("yyyy-MM-dd HH:mm:ss");
            this.LogoPath = data.Login_LogImg;
            this.LogoBodyPath = data.Login_BodyImg;
            this.HomeLogoPath = data.Home_LogoImg;
            this.tdProjectCount.Value = data.ProjectCount >= 0 ? data.ProjectCount.ToString() : "";
            this.btnShowLogin_LogImg.Checked = !data.IsHideLogin_LogImg;
            this.btnShowLogin_BodyImg.Checked = !data.IsHideLogin_BodyImg;
            this.btnShowHome_LogoImg.Checked = !data.IsHideHome_LogoImg;
            this.tdCopyRightText.Value = data.CopyRightText;
            this.btnShowCopyRightText.Checked = !data.IsHideCopyRightText;
            this.tdAlowRemoteUpdate.Value = data.AlowRemoteUpdate ? "1" : "0";
            this.tdIsWechatOn.Value = data.IsWechatOn ? "1" : "0";
            this.tdVersionCode.Value = data.VersionCode > 0 ? data.VersionCode.ToString() : "";
            this.tdExpiringDay.Value = data.ExpiringDay > 0 ? data.ExpiringDay.ToString() : "0";
            this.btnExpiringShow.Checked = data.ExpiringShow;
            this.tdExpiringMsg.Value = data.ExpiringMsg;
            if (string.IsNullOrEmpty(data.Signature) || string.IsNullOrEmpty(data.Token))
            {
                data.Signature = Utility.Tools.GetRandomString(32, true, false, true);
                data.Token = Utility.Tools.GetByteString(4);
                data.Save();
            }
            this.tdSignature.InnerHtml = data.Signature;
            this.tdToken.InnerHtml = data.Token;
        }
    }
}