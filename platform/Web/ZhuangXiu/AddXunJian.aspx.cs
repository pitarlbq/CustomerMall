using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utility;

namespace Web.ZhuangXiu
{
    public partial class AddXunJian : BasePage
    {
        public Foresight.DataAccess.ZhuangXiu zhuangxiu = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int ZhuangXiuID = 0;
                int.TryParse(Request.QueryString["ID"], out ZhuangXiuID);
                zhuangxiu = Foresight.DataAccess.ZhuangXiu.GetZhuangXiu(ZhuangXiuID);
                if (zhuangxiu != null)
                {
                    //SetInfo(zhuangxiu);
                    this.tdXunJianMan.Value = WebUtil.GetUser(this.Context).RealName;
                    this.tdXunJianTime.Value = DateTime.Now.ToString("yyyy-MM-dd");
                    var list = Foresight.DataAccess.ZhuangXiu_Rule.GetZhuangXiu_Rules();
                    var items = list.Select(p =>
                    {
                        var item = new { ID = p.ID, Name = p.RuleName };
                        return item;
                    });
                    this.hdWeiGuiProject.Value = JsonConvert.SerializeObject(items);
                }
                else
                {
                    Response.Write("ID不合法");
                    Response.End();
                }
            }
        }
    }
}