using Foresight.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Wechat
{
    public partial class EditRentHome : BasePage
    {
        public int HomeID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request.QueryString["HomeID"], out HomeID);
            if (HomeID > 0)
            {
                var data = Foresight.DataAccess.Wechat_RentHome.GetWechat_RentHome(HomeID);
                if (data != null)
                {
                    SetInfo(data);
                    return;
                }
            }
        }
        private void SetInfo(Foresight.DataAccess.Wechat_RentHome data)
        {
            this.tdHomeName.Value = data.HomeName;
            this.tdHomeLocation.Value = data.HomeLocation.ToString();
            this.tdRentArea.Value = data.AreaID > 0 ? data.AreaID.ToString() : "";
            this.tdSubways.Value = data.Subways;
            this.tdTraffics.Value = data.Traffics;
            this.tdSuperMarkets.Value = data.SuperMarkets;
            this.tdRoomOwners.Value = data.RoomOwners;
            this.tdPublicOwners.Value = data.PublicOwners;
            this.tdRoomDescription.Value = data.RoomDescription;
            this.tdMapLocation.Value = data.MapLocation;
            this.tdPhoneNumber.Value = data.PhoneNumber;
            this.tdRentBuilding.Value = data.BuildingID > 0 ? data.BuildingID.ToString() : "";
            this.tdHomeType.Value = data.HomeType;
        }
    }
}