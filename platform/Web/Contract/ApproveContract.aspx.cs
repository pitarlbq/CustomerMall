using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Contract
{
    public partial class ApproveContract : BasePage
    {
        public Foresight.DataAccess.Contract_Approve approve = null;
        public Foresight.DataAccess.Contract_Stop stop = null;
        public int ApproveID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int ContractID = 0;
                int.TryParse(Request.QueryString["ID"], out ContractID);
                approve = Foresight.DataAccess.Contract_Approve.GetContract_ApproveByContractID(ContractID);
                if (approve == null)
                {
                    this.tdApproveMan.Value = WebUtil.GetUser(this.Context).RealName;
                    this.tdApproveTime.Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                }
                else if (approve != null && approve.ApproveStatus.Equals("审核通过"))
                {
                    ApproveID = approve.ID;
                    SetInfo(approve);
                }
                stop = Foresight.DataAccess.Contract_Stop.GetContract_StopByContractID(ContractID);
            }
        }
        private void SetInfo(Foresight.DataAccess.Contract_Approve data)
        {
            this.tdJingShouTeam.Value = data.JingShouTeam;
            this.tdJingShouPerson.Value = data.JingShouPerson;
            this.tdShareRole.Value = data.ShareRole;
            this.tdApproveTime.Value = data.ApproveTime == DateTime.MinValue ? "" : data.ApproveTime.ToString("yyyy-MM-dd HH:mm:ss");
            this.tdApproveMan.Value = data.ApproveMan;
            this.tdYunYingModel.Value = data.YunYingModel;
            this.tdBusinessYeTai.Value = data.BusinessYeTai;
            this.tdBusinessRange.Value = data.BusinessRange;
            this.tdApproveDesc.Value = data.ApproveDesc;
        }
    }
}