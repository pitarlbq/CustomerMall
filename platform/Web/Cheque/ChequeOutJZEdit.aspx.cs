using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Cheque
{
    public partial class ChequeOutJZEdit : BasePage
    {
        public int ID = 0;
        public string guid = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            guid = System.Guid.NewGuid().ToString();
            ID = 0;
            int.TryParse(Request.QueryString["ID"], out ID);
            if (ID > 0)
            {
                var data = Foresight.DataAccess.Cheque_Outing.GetCheque_Outing(ID);
                if (data != null)
                {
                    SetInfo(data);
                    return;
                }
            }
            this.tdOperationTime.Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            this.tdOperator.Value = WebUtil.GetUser(this.Context).RealName;
        }
        private void SetInfo(Foresight.DataAccess.Cheque_Outing data)
        {
            this.tdProjectID.Value = data.ProjectID > 0 ? data.ProjectID.ToString() : "";
            this.tdStartTime.Value = data.StartTime > DateTime.MinValue ? data.StartTime.ToString("yyyy-MM-dd") : "";
            this.tdEndTime.Value = data.EndTime > DateTime.MinValue ? data.EndTime.ToString("yyyy-MM-dd") : "";
            this.tdNotifyTime.Value = data.NotifyTime > DateTime.MinValue ? data.NotifyTime.ToString("yyyy-MM-dd") : "";
            this.tdOperator.Value = data.Operator;
            this.tdOperationTime.Value = data.OperationTime > DateTime.MinValue ? data.OperationTime.ToString("yyyy-MM-dd HH:mm;ss") : "";
            this.tdIDCardStatus.Value = data.IDCardStatus;
            this.tdRemark.Value = data.Remark;
            this.tdBelongCompanyName.Value = data.BelongCompanyName;
            this.tdDepartmentID.Value = data.DepartmentID > 0 ? data.DepartmentID.ToString() : "";
            this.tdPaperNumber.Value = data.PaperNumber;
            this.tdOutingAddress.Value = data.OutingAddress;
            this.tdApproveMan.Value = data.ApproveMan;
            this.tdTaxManName.Value = data.TaxManName;
            this.tdTaxNumber.Value = data.TaxNumber;
            this.tdCompanyInChargeMan.Value = data.CompanyInChargeMan;
            this.tdIDCardType.Value = data.IDCardType;
            this.tdIDCardNumber.Value = data.IDCardNumber;
            this.tdProduceAddress.Value = data.ProduceAddress;
            this.tdCompanyRegiserType.Value = data.CompanyRegiserType;
            this.tdBusinessType.Value = data.BusinessType;
            this.tdInChargeMan.Value = data.InChargeMan;
            this.tdOperationComment.Value = data.OperationComment;
        }
    }
}