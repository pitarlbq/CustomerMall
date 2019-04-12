using Foresight.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.SysSeting
{
    public partial class MyCompany : BasePage
    {
        public int CompanyID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            CompanyID = WebUtil.GetCompanyID(this.Context);
            var data = Foresight.DataAccess.Company.GetCompany(CompanyID);
            if (data != null)
            {
                SetInfo(data);
                return;
            }
        }
        private void SetInfo(Foresight.DataAccess.Company data)
        {
            string erromsg = string.Empty;
            Foresight.DataAccess.Company defaultCompany = WebUtil.GetCompany(this.Context);
            if (defaultCompany != null)
            {
                this.tdRealName.Value = data.CompanyName;
                this.tdPhoneNumber.Value = data.PhoneNumber;
                this.tdAddress.Value = data.Address;
                this.tdDesc.Value = data.CompanyDesc;
                this.tdChargeMan.Value = data.ChargePerson;
                this.tdIsActive.Value = defaultCompany.IsPay ? "1" : "0";
                this.tdDistributor.Value = defaultCompany.Distributor;
                this.tdUserCount.Value = defaultCompany.UserCount == int.MinValue ? "0" : defaultCompany.UserCount.ToString();
                this.tdStartTime.Value = defaultCompany.ServerStartTime == DateTime.MinValue ? "" : defaultCompany.ServerStartTime.ToString("yyyy-MM-dd HH:mm:ss");
                this.tdEndTime.Value = defaultCompany.ServerEndTime == DateTime.MinValue ? "" : defaultCompany.ServerEndTime.ToString("yyyy-MM-dd HH:mm:ss");
                this.tdProjectCount.Value = defaultCompany.ProjectCount == int.MaxValue ? "" : defaultCompany.ProjectCount.ToString();
            }
            else
            {
                this.tdRealName.Value = data.CompanyName;
                this.tdPhoneNumber.Value = data.PhoneNumber;
                this.tdAddress.Value = data.Address;
                this.tdDesc.Value = data.CompanyDesc;
                this.tdChargeMan.Value = data.ChargePerson;
            }
        }
    }
}