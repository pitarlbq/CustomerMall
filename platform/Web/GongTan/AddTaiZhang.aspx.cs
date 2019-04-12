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
    public partial class AddTaiZhang : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var list = Foresight.DataAccess.ChargeBiao.GetChargeBiaos();
                if (list.Count > 0)
                {
                    hdBiaoCategory.Value = JsonConvert.SerializeObject(list);
                }
            }
        }
    }
}