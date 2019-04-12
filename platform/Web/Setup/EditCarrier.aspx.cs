using Foresight.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Setup
{
    public partial class EditCarrier : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int ID = 0;
            int.TryParse(Request.QueryString["ID"], out ID);
            if (ID > 0)
            {
                var data = Carrier.GetCarrier(ID);
                if (data != null)
                {
                    SetInfo(data);
                }
            }
        }
        private void SetInfo(Carrier data)
        {
            this.tdCarrierName.Value = data.CarrierName;
        }
    }
}