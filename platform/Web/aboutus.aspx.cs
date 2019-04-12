using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class aboutus : System.Web.UI.Page
    {
        public string HtmlContent = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var content = Foresight.DataAccess.Mall_Content.GetMall_ContentByName(Utility.EnumModel.MallContentNameDefine.aboutus.ToString());
                if (content != null)
                {
                    HtmlContent = content.Value;
                }
            }
        }
    }
}