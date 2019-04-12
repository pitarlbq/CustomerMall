using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Device
{
    public partial class ParamSetup : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var list = Foresight.DataAccess.DeviceSetting.GetDeviceSettings();
                var repairtimesetup = list.FirstOrDefault(p => p.ModuleCode.Equals(Utility.EnumModel.DeviceSettingCode.repairtimesetup.ToString()));
                if (repairtimesetup != null)
                {
                    this.tdrepairtimecount.Value = repairtimesetup.Parameters1;
                    this.tdrepairtimetype.Value = repairtimesetup.Parameters2;
                }
                var checktimesetup = list.FirstOrDefault(p => p.ModuleCode.Equals(Utility.EnumModel.DeviceSettingCode.checktimesetup.ToString()));
                if (checktimesetup != null)
                {
                    this.tdchecktimecount.Value = checktimesetup.Parameters1;
                    this.tdchecktimetype.Value = checktimesetup.Parameters2;
                }
            }
        }
    }
}