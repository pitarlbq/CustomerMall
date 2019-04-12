using Foresight.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.APPSetup
{
    public partial class CheckRuleEdit : BasePage
    {
        public int CategoryID = 0;
        public int RuleID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request.QueryString["CategoryID"], out CategoryID);
            int.TryParse(Request.QueryString["RuleID"], out RuleID);
            if (RuleID > 0)
            {
                var data = Foresight.DataAccess.Mall_CheckInfo.GetMall_CheckInfo(RuleID);
                if (data != null)
                {
                    SetInfo(data);
                    return;
                }
            }
        }
        private void SetInfo(Foresight.DataAccess.Mall_CheckInfo data)
        {
            this.tdCheckName.Value = data.CheckName;
            this.tdCheckSummary.Value = data.CheckSummary;
            this.tdStartPoint.Value = data.StartPoint > 0 ? data.StartPoint.ToString() : "";
            this.tdEndPoint.Value = data.EndPoint > 0 ? data.EndPoint.ToString() : "";
            this.CategoryID = data.CheckCategoryID;
        }
    }
}