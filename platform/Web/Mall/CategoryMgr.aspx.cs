using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Mall
{
    public partial class CategoryMgr : BasePage
    {
        public int type = 1;//1-商品分类 2-商家分类 3-社区发帖分类
        public int CanAdd = 0;
        public int CanEdit = 0;
        public int CanRemove = 0;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Request.QueryString["type"] != null)
            {
                int.TryParse(this.Request.QueryString["type"], out type);
            }
            if ((base.CheckAuthByModuleCode("1101429") && type == 1) || (base.CheckAuthByModuleCode("1101415") && type == 2) || (base.CheckAuthByModuleCode("1101366") && type == 3))
            {
                this.CanAdd = 1;
            }
            if ((base.CheckAuthByModuleCode("1101430") && type == 1) || (base.CheckAuthByModuleCode("1101416") && type == 2) || (base.CheckAuthByModuleCode("1101367") && type == 3))
            {
                this.CanEdit = 1;
            }
            if ((base.CheckAuthByModuleCode("1101431") && type == 1) || (base.CheckAuthByModuleCode("1101417") && type == 2) || (base.CheckAuthByModuleCode("1101368") && type == 3))
            {
                this.CanRemove = 1;
            }
        }
    }
}