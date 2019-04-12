using Foresight.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Setup
{
    public partial class EditSourceOut : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int ID = 0;
            int.TryParse(Request.QueryString["ID"], out ID);
            if (ID == 0)
            {
                Response.End();
                return;
            }
            var data = WarehouseInOut.GetWarehouseInOut(ID);
            if (data == null)
            {
                Response.End();
                return;
            }
            SetInfo(data);
        }
        private void SetInfo(WarehouseInOut data)
        {
            this.tdOrderNumber.Value = data.OrderNumber;
            this.tdInventoryInfo.Value = data.InventoryInfoID == int.MinValue ? "1" : data.InventoryInfoID.ToString();
            this.tdBusiness.Value = data.BusinessID == int.MinValue ? "1" : data.BusinessID.ToString();
            this.tdProduct.Value = data.ProductID == int.MinValue ? "1" : data.ProductID.ToString();
            this.tdCount.Value = data.Count == int.MinValue ? "" : data.Count.ToString();
            this.tdCarrier.Value = data.CarrierID == int.MinValue ? "1" : data.CarrierID.ToString();
            this.tdSpec.Value = data.SpecInfoID == int.MinValue ? "1" : data.SpecInfoID.ToString();
            if (data.SpecInfoID > 0)
            {
                var spec = SpecInfo.GetSpecInfo(data.SpecInfoID);
                this.tdColdPrice.Value = spec.ColdPrice == int.MinValue ? "0" : spec.ColdPrice.ToString();
                this.tdMovePrice.Value = spec.MovePrice == int.MinValue ? "0" : spec.MovePrice.ToString();
                this.tdMoveCost.Value = data.MoveCost.ToString();
                this.hdMovePrice.Value = spec.MovePrice == int.MinValue ? "0" : spec.MovePrice.ToString();
            }
            this.tdOutTime.Value = data.OutTime.ToString("yyyy-MM-dd");
            this.tdRemark.Value = data.Remark;
        }
    }
}