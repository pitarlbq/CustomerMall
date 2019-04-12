using Foresight.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.SysSeting
{
    public partial class APPVersionEdit : BasePage
    {
        public string FilePath = string.Empty;
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
        }
        private void SetInfo(Foresight.DataAccess.SiteVersion data)
        {
            this.tdAPPVersionDesc.Value = data.APPVersionDesc;
            this.tdAPPVersionCode.Value = data.APPVersionCode > 0 ? data.APPVersionCode.ToString() : "";
            this.tdVersionType.Value = string.IsNullOrEmpty(data.VersionType) ? "platform" : data.VersionType;
            this.tdVersionDesc.Value = data.VersionDesc;
            FilePath = data.FilePath;
            this.tdAPPType.Value = data.APPType > 0 ? data.APPType.ToString() : "";
            if (data.VersionType.Equals("ios"))
            {
                this.tdIOS_FilePath.Value = data.FilePath;
            }
            this.tdDisableUpdate.Value = data.DisableUpdate ? "1" : "0";
            this.tdIsForceUpdate.Value = data.IsForceUpdate ? "1" : "0";
        }
    }
}