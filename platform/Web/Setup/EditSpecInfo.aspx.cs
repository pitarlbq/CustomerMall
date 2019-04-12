using Foresight.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Setup
{
    public partial class EditSpecInfo : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int ID = 0;
            int.TryParse(Request.QueryString["ID"], out ID);
            if (ID > 0)
            {
                var data = SpecInfo.GetSpecInfo(ID);
                if (data != null)
                {
                    SetInfo(data);
                }
            }
        }
        private void SetInfo(SpecInfo data)
        {
            this.tdSpecName.Value = data.SpecName;
            this.tdBalancePrice.Value = data.BalancePrice == decimal.MinValue ? "" : data.BalancePrice.ToString();
            this.tdColdPrice.Value = data.ColdPrice == decimal.MinValue ? "" : data.ColdPrice.ToString();
            this.tdMovePrice.Value = data.MovePrice == decimal.MinValue ? "" : data.MovePrice.ToString();
        }
    }
}