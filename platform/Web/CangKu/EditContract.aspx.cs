using Foresight.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.CangKu
{
    public partial class EditContract : BasePage
    {
        public int ID = 0;
        public string ContractNumber = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            ID = 0;
            int.TryParse(Request.QueryString["ID"], out ID);
            if (ID > 0)
            {
                var data = Foresight.DataAccess.CKContarct.GetCKContarct(ID);
                if (data != null)
                {
                    SetInfo(data);
                    return;
                }
            }
            ContractNumber = Foresight.DataAccess.CKContarct.GetLastestContractNumber();
        }
        private void SetInfo(Foresight.DataAccess.CKContarct data)
        {
            this.tdContractName.Value = data.ContractName;
            this.tdContractFullName.Value = data.ContractFullName;
            this.tdAddress.Value = data.Address;
            this.tdContactMan.Value = data.ContactMan;
            this.tdPhoneNumber.Value = data.PhoneNumber;
            this.tdFaxNumber.Value = data.FaxNumber;
            this.tdEMailAddress.Value = data.EMailAddress;
            this.tdRemark.Value = data.Remark;
            this.ContractNumber = data.ContractNumber;
        }
    }
}