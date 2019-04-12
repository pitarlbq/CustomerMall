using Foresight.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Setup
{
    public partial class EditCarrierGroup : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int ID = 0;
            int.TryParse(Request.QueryString["ID"], out ID);
            if (ID > 0)
            {
                var data = CarrierGroup.GetCarrierGroup(ID);
                if (data != null)
                {
                    SetInfo(data);
                }
            }
        }
        private void SetInfo(CarrierGroup data)
        {
            this.tdCarrierGroupName.Value = data.CarrierGroupName;
        }
    }
}