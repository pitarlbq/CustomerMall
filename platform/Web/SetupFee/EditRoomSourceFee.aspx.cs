using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Foresight.DataAccess;

namespace Web.SetupFee
{
    public partial class EditRoomSourceFee : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["ID"]))
            {
                Response.End();
                return;
            }
            int ID = 0;
            int.TryParse(Request.QueryString["ID"], out ID);
            if (ID == 0)
            {
                Response.End();
                return;
            }
            //ViewRoomFee source = ViewRoomFee.GetViewRoomFee(ID);
            var data = RoomFeeAnalysis.GetRoomFeeAnalysisByID(ID);
            if (data == null)
            {
                return;
            }
            string op = Request.QueryString["op"];
            SetInfo(data, op);
        }
        private void SetInfo(RoomFeeAnalysis data, string op)
        {
            var roomFee = RoomFee.GetRoomFee(data.ID);
            this.tdFullName.Value = data.FullName;
            this.tdName.Value = data.RoomName;
            this.tdRemark.Value = roomFee.Remark;
            if (op.Equals("add"))
            {
                return;
            }
            this.tdUnitPrice.Value = data.CalculateUnitPrice.ToString();
            this.hdChargeName.Value = data.ChargeID > 0 ? data.ChargeID.ToString() : "";
            this.hdChargeType.Value = data.TypeID > 0 ? data.TypeID.ToString() : "";
            this.tdStartTime.Value = data.CalculateStartTime == DateTime.MinValue ? "" : data.CalculateStartTime.ToString("yyyy-MM-dd");
            this.hdEndTime.Value = data.CalculateEndTime == DateTime.MinValue ? "" : data.CalculateEndTime.ToString("yyyy-MM-dd");
            this.hdNewEndTime.Value = data.NewEndTime == DateTime.MinValue ? "" : data.NewEndTime.ToString("yyyy-MM-dd");
        }
    }
}