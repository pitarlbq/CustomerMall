using Foresight.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.SysSeting
{
    public partial class EditVersion : BasePage
    {
        public string FilePath = string.Empty;
        public string SqlPath = string.Empty;
        public int VersionID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request.QueryString["VersionID"], out VersionID);
            if (VersionID > 0)
            {
                var data = Foresight.DataAccess.SiteVersion.GetSiteVersion(VersionID);
                if (data != null)
                {
                    SetInfo(data);
                    return;
                }
            }
            this.tdVersionCode.Value = Foresight.DataAccess.SiteVersion.GetLastestSiteVersionCode().ToString();
        }
        private void SetInfo(Foresight.DataAccess.SiteVersion data)
        {
            this.tdVersionCode.Value = data.VersionCode > 0 ? data.VersionCode.ToString() : "1";
            this.tdVersionDesc.Value = data.VersionDesc;
            FilePath = data.FilePath;
            SqlPath = data.SqlPath;
            this.tdVersionType.Value = string.IsNullOrEmpty(data.VersionType) ? "platform" : data.VersionType;
        }
    }
}