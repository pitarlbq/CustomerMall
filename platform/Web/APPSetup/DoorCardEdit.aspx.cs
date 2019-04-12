using Foresight.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utility;

namespace Web.APPSetup
{
    public partial class DoorCardEdit : BasePage
    {
        public int CardID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["ID"] != null)
                {
                    int.TryParse(Request.QueryString["ID"], out CardID);
                }
                if (CardID > 0)
                {
                    var data = Foresight.DataAccess.Mall_DoorCard.GetMall_DoorCard(CardID);
                    if (data != null)
                    {
                        SetInfo(data);
                    }
                }
            }
        }
        private void SetInfo(Foresight.DataAccess.Mall_DoorCard data)
        {
            this.tdProjectID.Value = data.ProjectID > 0 ? data.ProjectID.ToString() : "";
            var card_device_list = Mall_DoorCardDevice.GetMall_DoorCardDeviceListByCardID(data.ID);
            var device_list = Mall_DoorDevice.GetALLActiveMall_DoorDeviceList().Where(p => card_device_list.Select(q => q.DoorDeviceID).ToList().Contains(p.DeviceID)).ToArray();
            if (device_list.Length > 0)
            {
                this.tdDeviceList.Value = string.Join(",", device_list.Select(p => p.ID).ToArray());
                this.hdDeviceList.Value = JsonConvert.SerializeObject(device_list.Select(p => p.ID).ToArray());
            }
            var user = Foresight.DataAccess.RoomPhoneRelation.GetRoomPhoneRelation(data.RoomPhoneRelationID);
            if (user != null)
            {
                this.hdUserName.Value = user.RelationName + "\r\n" + user.RelatePhoneNumber;
                this.hdUserID.Value = user.UserID > 0 ? user.UserID.ToString("0") : "";
                this.hdRelationID.Value = user.ID.ToString();
                var project = Foresight.DataAccess.Project.GetProject(user.RoomID);
                if (project != null)
                {
                    this.hdUserName.Value += "\r\n" + project.FullName + "-" + project.Name;
                }
            }
            this.tdCardName.Value = data.CardName;
            this.tdCardSummary.Value = data.CardSummary;
            this.tdCardUID.Value = data.CardUID;
            if (data.ExpireDate == DateTime.MinValue && data.EndDays > 0)
            {
                data.ExpireDate = DateTime.Now.AddDays(data.EndDays);
            }
            this.tdExpireDate.Value = data.ExpireDate > DateTime.MinValue ? data.ExpireDate.ToString("yyyy-MM-dd") : "";
            this.tdDoorNumber.Value = data.DoorNumber;
            this.tdSortOrder.Value = data.SortOrder > int.MinValue ? data.SortOrder.ToString("0") : "";
        }
    }
}