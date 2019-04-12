
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Mall
{
    public partial class BalanceRuleEdit : BasePage
    {
        public int RuleID = 0;
        public int type = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["ID"] != null)
            {
                int.TryParse(Request.QueryString["ID"], out RuleID);
            }
            if (RuleID > 0)
            {
                var data = Foresight.DataAccess.Mall_BalanceRule.GetMall_BalanceRule(RuleID);
                if (data != null)
                {
                    SetInfo(data);
                }
            }
        }
        private void SetInfo(Foresight.DataAccess.Mall_BalanceRule data)
        {
            this.tdTitle.Value = data.Title;
            this.tdIsActive.Value = data.IsActive ? "1" : "0";
            this.tdRuleType.Value = data.RuleType > 0 ? data.RuleType.ToString() : "1";
            this.tdRemark.Value = data.Remark;
            this.tdBackBalanceType.Value = data.BackBalanceType > 0 ? data.BackBalanceType.ToString() : "1";
            this.tdBackAmount.Value = data.BackBalanceType == 1 ? data.BackPercent.ToString() : data.BackAmount.ToString();
        }
    }
}