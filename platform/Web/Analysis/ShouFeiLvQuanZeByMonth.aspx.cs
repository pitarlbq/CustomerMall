using Foresight.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utility;

namespace Web.Analysis
{
    public partial class ShouFeiLvQuanZeByMonth : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var typeList = Foresight.DataAccess.ChargeMoneyType.GetChargeMoneyTypes().ToArray();
                var items = typeList.Select(p =>
                {
                    var item = new { ID = p.ChargeTypeID, Name = p.ChargeTypeName };
                    return item;
                }).ToList();
                items.Insert(0, new { ID = -1, Name = "全部" });
                DateTime StartTime = DateTime.Now.AddDays(1 - DateTime.Now.Day).AddMonths(-1);
                this.tdStartTime.Value = StartTime.ToString("yyyy-MM-dd");
                this.tdEndTime.Value = StartTime.AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd");
            }
        }
    }
}