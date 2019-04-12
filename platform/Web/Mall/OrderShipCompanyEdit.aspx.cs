using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Mall
{
    public partial class OrderShipCompanyEdit : BasePage
    {
        public int CompanyID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["ID"] != null)
            {
                int.TryParse(Request.QueryString["ID"], out CompanyID);
            }
            if (CompanyID > 0)
            {
                var data = Foresight.DataAccess.Mall_ShipCompany.GetMall_ShipCompany(CompanyID);
                SetInfo(data);
            }
        }
        private void SetInfo(Foresight.DataAccess.Mall_ShipCompany data)
        {
            this.tdShipCompanyName.Value = data.ShipCompanyName;
            this.tdSortOrder.Value = data.SortOrder > 0 ? data.SortOrder.ToString() : "";
        }
    }
}