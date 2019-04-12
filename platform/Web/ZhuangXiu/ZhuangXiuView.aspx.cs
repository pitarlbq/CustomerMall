using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.ZhuangXiu
{
    public partial class ZhuangXiuView : BasePage
    {
        public Foresight.DataAccess.ZhuangXiu zhuangxiu = null;
        public Foresight.DataAccess.ZhuangXiu_Approve approve = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int ZhuangXiuID = 0;
                int.TryParse(Request.QueryString["ID"], out ZhuangXiuID);
                zhuangxiu = Foresight.DataAccess.ZhuangXiu.GetZhuangXiu(ZhuangXiuID);
                if (zhuangxiu != null)
                {
                    SetInfo(zhuangxiu);
                    if (zhuangxiu.ApproveID > 0)
                    {
                        approve = Foresight.DataAccess.ZhuangXiu_Approve.GetZhuangXiu_Approve(zhuangxiu.ApproveID);
                    }
                }
                else
                {
                    Response.Write("ID不合法");
                    Response.End();
                }
            }
        }
        private void SetInfo(Foresight.DataAccess.ZhuangXiu data)
        {
            var project = Foresight.DataAccess.Project.GetProject(data.RoomID);
            this.tdRoomName.Value = project != null ? project.Name : "";
            this.hdApplicationMan.Value = data.ApplicationMan;
            this.tdPhoneNumber.Value = data.PhoneNumber;
            this.tdDepositPrice.Value = data.DepositPrice > decimal.MinValue ? data.DepositPrice.ToString() : "";
            this.tdZhuangXiuType.Value = data.ZhuangXiuType;
            this.tdTypeDesc.Value = data.TypeDesc;
            this.tdChargeName.Value = data.ChargeID > 0 ? data.ChargeID.ToString() : "";
            this.tdZhuangXiuTime.Value = data.ConfirmZXTime > DateTime.MinValue ? data.ConfirmZXTime.ToString("yyyy-MM-dd") : "";
            this.tdYanShouTime.Value = data.YanShouTime > DateTime.MinValue ? data.YanShouTime.ToString("yyyy-MM-dd") : "";
            this.tdYanShouMan.Value = data.YanShouMan;
            this.tdTotalWeiGuiCost.Value = "0";
            this.tdYanShouRemark.Value = data.YanShouRemark;
            var list = Foresight.DataAccess.ZhuangXiu_XunJian.GetZhuangXiu_XunJianList(data.ID);
            this.tdTotalWeiGuiCost.Value = list.Where(p => p.XunJianStatus.Equals("WeiGui")).Sum(p =>
            {
                if (p.WeiGuiCost < 0)
                {
                    return 0;
                }
                return p.WeiGuiCost;
            }).ToString();
        }
    }
}