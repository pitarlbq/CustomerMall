using Foresight.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utility;

namespace Web.SetupFee
{
    public partial class ViewRoomFeeList : BasePage
    {
        public string RoomIDs = string.Empty;
        public int ProjectID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            RoomIDs = Request.QueryString["RoomIDs"];
            List<int> RoomIDList = new List<int>();
            if (!string.IsNullOrEmpty(RoomIDs))
            {
                RoomIDList = JsonConvert.DeserializeObject<List<int>>(RoomIDs);
            }
            int.TryParse(Request.QueryString["ProjectID"], out ProjectID);
            if (string.IsNullOrEmpty(RoomIDs) && RoomIDList.Count == 0)
            {
                //Response.End();
                return;
            }
        }
    }
}