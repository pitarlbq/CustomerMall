using Foresight.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.APPSetup
{
    public partial class ChatSensitiveEdit : BasePage
    {
        public int CanRemove = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (base.CheckAuthByModuleCode("1101371"))
                {
                    this.CanRemove = 1;
                }
            }
        }
    }
}