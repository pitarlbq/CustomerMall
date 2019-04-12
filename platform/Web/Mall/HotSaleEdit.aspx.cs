using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Mall
{
    public partial class HotSaleEdit : BasePage
    {
        public int SaleID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["ID"] != null)
            {
                int.TryParse(Request.QueryString["ID"], out SaleID);
            }
            if (SaleID > 0)
            {
                var data = Foresight.DataAccess.Mall_HotSale.GetMall_HotSale(SaleID);
                SetInfo(data);
            }
        }
        private void SetInfo(Foresight.DataAccess.Mall_HotSale data)
        {
            this.tdType.Value = data.Type > 0 ? data.Type.ToString() : "";
            this.tdSortOrder.Value = data.SortOrder > 0 ? data.SortOrder.ToString() : "";
            if (data.Type == 1)
            {
                this.tdProductID.Value = data.RelatedID > 0 ? data.RelatedID.ToString() : "";
            }
            else if (data.Type == 2)
            {
                this.tdBusinessID.Value = data.RelatedID > 0 ? data.RelatedID.ToString() : "";
            }
            this.tdStartTime.Value = data.StartTime > DateTime.MinValue ? data.StartTime.ToString("yyyy-MM-dd") : "";
            this.tdEndTime.Value = data.EndTime > DateTime.MinValue ? data.EndTime.ToString("yyyy-MM-dd") : "";
        }
    }
}