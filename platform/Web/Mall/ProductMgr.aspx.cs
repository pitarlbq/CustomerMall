using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Mall
{
    public partial class ProductMgr : BasePage
    {
        public int status = 0;
        public int type = 1;
        public int CanAdd = 0;
        public int CanEdit = 0;
        public int CanRemove = 0;
        public int CanView = 0;
        public int CanChangeCategory = 0;
        public int CanChangePrice = 0;
        public int CanChangeTag = 0;
        public int CanApprove = 0;
        public int CanSortYouXuan = 0;
        public int CanSortPinQiang = 0;
        public int CanViewPinQiang = 0;
        public int CanOffLine = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["status"] != null)
            {
                int.TryParse(Request.QueryString["status"], out status);
            }
            if (Request.QueryString["type"] != null)
            {
                int.TryParse(Request.QueryString["type"], out type);
            }
            CanAdd = base.CheckAuthByModuleCode("1101418") ? 1 : 0;
            CanEdit = base.CheckAuthByModuleCode("1101419") ? 1 : 0;
            CanRemove = base.CheckAuthByModuleCode("1101420") ? 1 : 0;
            CanView = base.CheckAuthByModuleCode("1101421") ? 1 : 0;
            CanChangeCategory = base.CheckAuthByModuleCode("1101422") ? 1 : 0;
            CanChangePrice = base.CheckAuthByModuleCode("1101423") ? 1 : 0;
            CanChangeTag = base.CheckAuthByModuleCode("1101424") ? 1 : 0;
            CanApprove = base.CheckAuthByModuleCode("1101425") ? 1 : 0;
            CanSortYouXuan = base.CheckAuthByModuleCode("1101426") ? 1 : 0;
            CanSortPinQiang = base.CheckAuthByModuleCode("1101427") ? 1 : 0;
            CanViewPinQiang = base.CheckAuthByModuleCode("1101428") ? 1 : 0;
            CanOffLine = base.CheckAuthByModuleCode("1101469") ? 1 : 0;
        }
    }
}