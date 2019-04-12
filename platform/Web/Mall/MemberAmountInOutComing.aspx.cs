using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Mall
{
    public partial class MemberAmountInOutComing : BasePage
    {
        public int BalanceType = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["type"] != null)
                {
                    int.TryParse(Request.QueryString["type"], out BalanceType);
                }
                if (BalanceType == 1)
                {
                    this.label_Title1.InnerHtml = "充值金额";
                    this.label_Title2.InnerHtml = "充值";
                }
                else
                {
                    this.label_Title1.InnerHtml = "扣除金额";
                    this.label_Title2.InnerHtml = "扣除";
                }
            }
        }
    }
}