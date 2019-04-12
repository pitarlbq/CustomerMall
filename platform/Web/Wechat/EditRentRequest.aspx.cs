using Foresight.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Wechat
{
    public partial class EditRentRequest : BasePage
    {
        public int data_id = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request.QueryString["ID"], out data_id);
            if (data_id > 0)
            {
                var data = Foresight.DataAccess.Wechat_RentRequest.GetWechat_RentRequest(data_id);
                if (data != null)
                {
                    SetInfo(data);
                    return;
                }
            }
            Response.End();
            return;
        }
        private void SetInfo(Foresight.DataAccess.Wechat_RentRequest data)
        {
            if (data.AreaID > 0)
            {
                var area = Foresight.DataAccess.Wechat_RentArea.GetWechat_RentArea(data.AreaID);
                this.tdAreaName.Value = area != null ? area.AreaName : string.Empty;
            }
            if (data.BuildingID > 0)
            {
                var building = Foresight.DataAccess.Wechat_RentBuilding.GetWechat_RentBuilding(data.BuildingID);
                this.tdAreaName.Value = building != null ? building.BuildingName : string.Empty;
            }
            this.tdContactName.Value = data.ContactName;
            this.tdContactPhone.Value = data.ContactPhone;
            this.tdRentType.Value = data.RentTypeDesc;
            this.tdBuildingProperty.Value = data.BuildingPropertyDesc;
            this.tdRemark.Value = data.Remark;
        }
    }
}