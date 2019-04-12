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
    public partial class printchargefeeview2 : BasePage
    {
        public bool ShowWeiShu = true;
        protected void Page_Load(object sender, EventArgs e)
        {
            int PrintID = 0;
            int.TryParse(Request.QueryString["PrintID"], out PrintID);
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
            var projectList = Foresight.DataAccess.Project.GetProjectListByPrintID(print.ID);
            bool isCouZheng = false;
            int MinProjectID = 0;
            int MaxProjectID = 0;
            if (projectList.Length > 0)
            {
                MinProjectID = projectList.Min(p => p.ID);
                MaxProjectID = projectList.Max(p => p.ID);
            }
            var sysConfig = SysConfig.GetSysConfigByName(SysConfigNameDefine.RealCostCouZhengOn.ToString());
            SysConfig_ProjectDetail[] configProjectList = new SysConfig_ProjectDetail[] { };
            if (sysConfig != null)
            {
                configProjectList = SysConfig_ProjectDetail.Get_SysConfig_ProjectListByProjectIDList(MinProjectID, MaxProjectID).Where(p => p.ConfigID == sysConfig.ID).ToArray();
            }
            foreach (var item in projectList)
            {
                if (isCouZheng)
                {
                    break;
                }
                isCouZheng = SysConfig.IsCouZhengOnByAllParentID(configProjectList, item.AllParentID, item.ID, sysConfig);
            }
            if (isCouZheng)
            {
                this.ShowWeiShu = true;
            }
        }
    }
}