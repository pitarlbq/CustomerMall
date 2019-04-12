using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.APPSetup
{
    public partial class RotatingImageMgr : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var list = Foresight.DataAccess.Mall_RotatingImage.GetRotatingTypeList(IncludeALL: true);
                this.hdTypeValue.Value = Utility.JsonConvert.SerializeObject(list);
            }
        }
    }
}