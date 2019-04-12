using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.SysSeting
{
    public partial class ViewStaticPage : BasePage
    {
        public string ImagePath = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            int ID = 0;
            int.TryParse(Request.QueryString["ID"], out ID);
            if (ID > 0)
            {
                var module = Foresight.DataAccess.SysMenu.GetSysMenu(ID);
                if (module != null && !string.IsNullOrEmpty(module.ImgUrl))
                {
                    ImagePath = WebUtil.GetContextPath() + module.ImgUrl;
                }
            }
        }
    }
}