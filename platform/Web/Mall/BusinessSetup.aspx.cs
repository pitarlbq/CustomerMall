using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Mall
{
    public partial class BusinessSetup : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var syslist = Foresight.DataAccess.SysConfig.GetSysConfigs().ToArray();
            SetData(syslist);
        }
        private void SetData(Foresight.DataAccess.SysConfig[] syslist)
        {
            var data = syslist.FirstOrDefault(p => p.Name.Equals(Foresight.DataAccess.SysConfigNameDefine.BusinessDistance.ToString()));
            if (data == null)
            {
                data = new Foresight.DataAccess.SysConfig();
                data.Name = Foresight.DataAccess.SysConfigNameDefine.BusinessDistance.ToString();
                data.Value = "1";
                data.AddTime = DateTime.Now;
                data.Save();
            }
            this.tdBusinessDistance.Value = data.Value;
        }
    }
}