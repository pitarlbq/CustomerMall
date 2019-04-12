using Foresight.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.RoomResource
{
    public partial class EditRoomResource_Basic : BasePage
    {
        public string TableName = Utility.EnumModel.DefineFieldTableName.RoomBasic.ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (string.IsNullOrEmpty(Request.QueryString["RoomID"]))
                {
                    Response.End();
                    return;
                }
                int RoomID = int.Parse(Request.QueryString["RoomID"]);

                RoomBasic basic = RoomBasic.GetRoomBasicByRoomID(RoomID);
                if (basic != null)
                {
                    SetInfo(basic);
                }
                var project = Project.GetProject(RoomID);
                if (project != null)
                {
                    this.tbRoomName.Value = project.Name;
                    string[] SortOrderArray = project.DefaultOrder.Split('-');
                    int SortOrder = 0;
                    if (SortOrderArray.Length > 0)
                    {
                        int.TryParse(SortOrderArray[SortOrderArray.Length - 1], out SortOrder);
                    }
                    this.tdSortOrder.Value = SortOrder.ToString();
                }
            }
        }
        private void SetInfo(RoomBasic data)
        {
            this.tbRoomState.Value = data.RoomStateID > 0 ? data.RoomStateID.ToString() : "";
            this.tdBuildingArea.Value = data.BuildingArea == decimal.MinValue ? "" : data.BuildingArea.ToString();
            this.tdContractArea.Value = data.ContractArea == decimal.MinValue ? "" : data.ContractArea.ToString();
            this.tbPaymentTime.Value = data.PaymentTime == DateTime.MinValue ? "" : data.PaymentTime.ToString("yyyy-MM-dd");
            this.tdMoveInTime.Value = data.MoveInTime == DateTime.MinValue ? "" : data.MoveInTime.ToString("yyyy-MM-dd");
            this.tdZxStartTime.Value = data.ZxStartTime == DateTime.MinValue ? "" : data.ZxStartTime.ToString("yyyy-MM-dd");
            this.tdZxEndTime.Value = data.ZxEndTime == DateTime.MinValue ? "" : data.ZxEndTime.ToString("yyyy-MM-dd");
            this.tdRoomLayout.Value = data.RoomLayout;
            this.tbBuildingNumber.Value = data.BuildingNumber;
            this.tdBuildOutArea.Value = data.BuildOutArea == decimal.MinValue ? "" : data.BuildOutArea.ToString();
            this.tdBuildInArea.Value = data.BuildInArea == decimal.MinValue ? "" : data.BuildInArea.ToString();
            this.tdGonTanArea.Value = data.GonTanArea == decimal.MinValue ? "" : data.GonTanArea.ToString();
            this.tdChanQuanArea.Value = data.ChanQuanArea == decimal.MinValue ? "" : data.ChanQuanArea.ToString();
            this.tdUseArea.Value = data.UseArea == decimal.MinValue ? "" : data.UseArea.ToString();
            this.tdPeiTaoArea.Value = data.PeiTaoArea == decimal.MinValue ? "" : data.PeiTaoArea.ToString();
            this.tdFunctionCoefficient.Value = data.FunctionCoefficient == decimal.MinValue ? "" : data.FunctionCoefficient.ToString();
            this.tdFenTanCoefficient.Value = data.FenTanCoefficient == decimal.MinValue ? "" : data.FenTanCoefficient.ToString();
            this.tdChanQuanNo.Value = data.ChanQuanNo;
            this.tdCertificateTime.Value = data.CertificateTime == DateTime.MinValue ? "" : data.CertificateTime.ToString("yyyy-MM-dd");
            this.tbRoomProperty.Value = data.RoomPropertyID > 0 ? data.RoomPropertyID.ToString() : "";
            this.tbRoomType.Value = data.RoomTypeID > 0 ? data.RoomTypeID.ToString() : "";
            this.tdCustomOne.Value = data.CustomOne;
            this.tdCustomTwo.Value = data.CustomTwo;
            this.tdCustomThree.Value = data.CustomThree;
            this.tdCustomFour.Value = data.CustomFour;
            this.hdRemark.Value = data.Remark;
            this.tdIsLocked.Value = data.IsLocked ? "1" : "0";
        }
    }
}