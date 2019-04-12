using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.ZhuangXiu
{
    public partial class AddRule : BasePage
    {
        public int ID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int.TryParse(Request.QueryString["ID"], out ID);
                if (ID > 0)
                {
                    var data = Foresight.DataAccess.ZhuangXiu_Rule.GetZhuangXiu_Rule(ID);
                    if (data != null)
                    {
                        ID = data.ID;
                        this.tdRuleName.Value = data.RuleName;
                        this.tdRuleRequire.Value = data.RuleRequire;
                        this.tdRuleCategory.Value = data.RuleCategoryID > 0 ? data.RuleCategoryID.ToString() : "";
                    }
                    else
                    {
                        ID = 0;
                    }
                }
            }
        }
    }
}