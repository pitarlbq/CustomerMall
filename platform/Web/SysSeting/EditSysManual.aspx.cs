using Foresight.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Web.SysSeting
{
    public partial class EditSysManual : BasePage
    {
        public int CategoryID = 0;
        public int ManualID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request.QueryString["CategoryID"], out CategoryID);
            int.TryParse(Request.QueryString["ManualID"], out ManualID);
            if (ManualID > 0)
            {
                var data = Foresight.DataAccess.SysManual.GetSysManual(ManualID);
                if (data != null)
                {
                    SetInfo(data);
                    return;
                }
            }
        }
        private void SetInfo(Foresight.DataAccess.SysManual data)
        {
            this.tdTitle.Value = data.Title;
            this.tdSortBy.Value = data.SortBy > int.MinValue ? data.SortBy.ToString() : "";
            this.tdStatus.Value = data.Status > int.MinValue ? data.Status.ToString() : "1";
            this.hdContent.Value = data.Description;
            this.ManualID = data.ID;
        }
    }
}