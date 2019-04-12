using Foresight.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utility;

namespace Web.GongTan
{
    public partial class MeterProjectFeeMgr : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var list = ChargeSummary.GetChargeSummaries().ToArray();
                var items = list.Select(p =>
                {
                    var item = new { id = p.ID, name = p.Name };
                    return item;
                }).ToList();
                items.Insert(0, new { id = 0, name = "全部" });
                this.hdChargeIDList.Value = JsonConvert.SerializeObject(items);
            }
        }
    }
}