using Foresight.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utility;

namespace Web.GongTan
{
    public partial class MeterProjectFeeCreate : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var list = ChargeSummary.GetChargeSummaries().Where(p => p.IsReading).ToArray();
                var items = list.Select(p =>
                {
                    var item = new { id = p.ID, name = p.Name };
                    return item;
                }).ToList();
                this.hdChargeIDList.Value = JsonConvert.SerializeObject(items);
            }
        }
    }
}