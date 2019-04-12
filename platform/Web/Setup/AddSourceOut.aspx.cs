using Foresight.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Setup
{
    public partial class AddSourceOut : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int ID = 0;
            int.TryParse(Request.QueryString["ID"], out ID);
            if (ID > 0)
            {
                var data = WarehouseInOut.GetWarehouseInOut(ID);
                if (data != null)
                {
                    SetInfo(data);
                }
            }
            this.tdOrderNumber.Value = GenerateNumber();
            this.tdOutTime.Value = DateTime.Now.ToString("yyyy-MM-dd");
        }
        private void SetInfo(WarehouseInOut data)
        {
            //this.tdOrderNumber.Value = data.OrderNumber;
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
                //this.tdMoveCost.Value = Math.Round((data.Count * spec.MovePrice), 2, MidpointRounding.AwayFromZero).ToString();
                this.tdMoveCost.Value = "0";
                this.hdMovePrice.Value = spec.MovePrice == int.MinValue ? "0" : spec.MovePrice.ToString();
            }
        }
        private string GenerateNumber()
        {
            string part1 = "出库单";
            string part2 = DateTime.Now.ToString("yyyyMMdd");
            Random ran = new Random();
            string part3 = "0001";
            string OrderNumber = string.Concat(part1, part2, part3);
            var warehouse = Foresight.DataAccess.WarehouseInOut.GetWarehouseInOutByOrderNumber(OrderNumber);
            if (warehouse == null)
            {
                return OrderNumber;
            }
            warehouse = Foresight.DataAccess.WarehouseInOut.GetWarehouseInOutByOrderNumber(string.Concat(part1, part2));
            if (warehouse == null)
            {
                return OrderNumber;
            }
            int number = 1;
            if (warehouse.OrderNumber.Length < 4)
            {
                return OrderNumber;
            }
            int.TryParse(warehouse.OrderNumber.Substring(warehouse.OrderNumber.Length - 4, 4), out number);
            part3 = (number + 1).ToString();
            int length = (4 - part3.Length);
            for (int i = 0; i < length; i++)
            {
                part3 = "0" + part3;
            }
            return string.Concat(part1, part2, part3);
        }
    }
}