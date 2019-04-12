using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Foresight.DataAccess;
using Utility;
using Foresight.DataAccess.Framework;

namespace Web.PrintPage
{
    public partial class printchargefeeview : BasePage
    {
        public bool ShowWeiShu = true;
        protected void Page_Load(object sender, EventArgs e)
        {
            int PrintID = 0;
            int.TryParse(Request.QueryString["PrintID"], out PrintID);
            decimal pageWidth = WebUtil.GetDecimalByStr(Request.QueryString["pageWidth"]);
            if (PrintID <= 0)
            {
                Response.End();
                return;
            }
            var print = Foresight.DataAccess.PrintRoomFeeHistory.GetPrintRoomFeeHistory(PrintID);
            if (print == null)
            {
                Response.End();
                return;
            }
            var sys_order = Foresight.DataAccess.Sys_OrderNumber.GetSys_OrderNumber(print.OrderNumberID);
            if (sys_order != null && sys_order.ChargeType == 2)
            {
                Response.Redirect(WebUtil.GetContextPath() + "/PrintPage/printchargefeeview2.aspx?PrintID=" + PrintID + "&PageWidth=" + pageWidth + "&op=" + Request.QueryString["op"]);
                return;
            }
            IsCouZhengOn();
        }
        private bool IsCouZhengOn()
        {
            this.ShowWeiShu = false;
            var couzheng = Foresight.DataAccess.SysConfig.GetSysConfigByName(SysConfigNameDefine.RealCostCouZhengOn.ToString());
            if (couzheng == null)
            {
                return false;
            }
            if (couzheng.Value.Equals("0"))
            {
                return false;
            }
            this.ShowWeiShu = true;
            return true;
        }
    }
}