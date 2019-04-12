using Foresight.DataAccess.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.ZhuangXiu
{
    public partial class ApproveZhuangXiu : BasePage
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
                        this.tdApproveDesc.Value = approve.ApproveDesc;
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
            this.tdApplicationMan.Value = data.ApplicationMan;
            this.tdDepositPrice.Value = data.DepositPrice > decimal.MinValue ? data.DepositPrice.ToString() : "";
            decimal total_realcost = 0;
            if (zhuangxiu.RoomFeeID > 0 && zhuangxiu.RoomID > 0 && zhuangxiu.ChargeID > 0)
            {
                using (SqlHelper helper = new SqlHelper())
                {
                    total_realcost = Foresight.DataAccess.RoomFeeHistory.GetTotalRealCost(zhuangxiu.RoomFeeID, zhuangxiu.RoomID, zhuangxiu.ChargeID, helper);
                }
            }
            this.tdRealDepositPrice.Value = total_realcost.ToString();
        }
    }
}