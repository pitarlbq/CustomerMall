using Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Mall
{
    public partial class RateRuleEdit : BasePage
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
                var data = Foresight.DataAccess.Mall_PointRule.GetMall_PointRule(RuleID);
                SetInfo(data);
            }
        }
        private void SetInfo(Foresight.DataAccess.Mall_PointRule data)
        {
            this.tdRuleName.Value = data.RuleName;
            this.tdRuleStatus.Value = data.RuleStatus.ToString();
            this.tdSummary.Value = data.RuleSummary;
            this.tdStartTime.Value = data.StartTime > DateTime.MinValue ? data.StartTime.ToString("yyyy-MM-dd HH:mm:ss") : "";
            this.tdEndTime.Value = data.EndTime > DateTime.MinValue ? data.EndTime.ToString("yyyy-MM-dd HH:mm:ss") : "";
            this.tdRuleType.Value = data.RuleType.ToString();
            this.tdUseForALL.Value = data.IsUseForAllProduct ? "1" : "0";
            if (!data.IsUseForAllProduct)
            {
                List<int> ProductIDList = new List<int>();
                if (!string.IsNullOrEmpty(data.ProductIDRange))
                {
                    ProductIDList = JsonConvert.DeserializeObject<List<int>>(data.ProductIDRange);
                }
                var list = Foresight.DataAccess.Mall_Product.GetMall_ProductListByIDList(ProductIDList);
                if (list.Length > 0)
                {
                    this.tdProducts.Value = string.Join(",", list.Select(p => p.ProductName).ToArray());
                    this.hdProducts.Value = JsonConvert.SerializeObject(list.Select(p => p.ID).ToArray());
                }
            }
            this.tdReturnPoint.Value = data.ReturnPoint.ToString();
        }
    }
}