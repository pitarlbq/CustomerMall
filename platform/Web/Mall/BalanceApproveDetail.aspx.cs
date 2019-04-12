using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Mall
{
    public partial class BalanceApproveDetail : BasePage
    {
        public int ID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["ID"] != null)
            {
                int.TryParse(Request.QueryString["ID"], out ID);
            }
            Foresight.DataAccess.Mall_BusinessBalance data = null;
            if (ID > 0)
            {
                data = Foresight.DataAccess.Mall_BusinessBalance.GetMall_BusinessBalance(ID);
            }
            if (data == null)
            {
                Response.End();
                return;
            }
            SetInfo(data);
        }
        private void SetInfo(Foresight.DataAccess.Mall_BusinessBalance data)
        {
            if (data.BusinessID <= 0)
            {
                this.tdBusinessName.InnerText = "福顺居自营";
            }
            else
            {
                var business = Foresight.DataAccess.Mall_Business.GetMall_Business(data.BusinessID);
                if (business != null)
                {
                    this.tdBusinessName.InnerText = business.BusinessName;
                    this.tdBusinessContactMan.InnerText = business.ContactName;
                }
            }
            this.tdBusinessAccount.InnerText = data.BusinessAccount;
            this.tdBalanceAmount.InnerText = data.BalanceAmount.ToString();
            var rule = Foresight.DataAccess.Mall_BalanceRule.GetMall_BalanceRule(data.BalanceRuleID);
            if (rule != null)
            {
                this.tdBalanceRuleName.InnerText = rule.Title;
            }
            this.BalanceStatusDesc.InnerText = data.BalanceStatusDesc;
            this.tdAddTime.InnerText = data.AddTime.ToString("yyyy-MM-dd HH:mm:ss");
            this.tdApproveTime.InnerText = data.ApproveTime > DateTime.MinValue ? data.ApproveTime.ToString("yyyy-MM-dd HH:mm:ss") : "";
            this.tdApproveMan.InnerText = data.ApproveUserMan;
            this.tdApproveStatus.InnerText = data.ApproveStatusDesc;
            this.tdApproveRemark.InnerText = data.ApproveRemark;
        }
    }
}