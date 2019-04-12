using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.ZhuangXiu
{
    public partial class AddYanShou : BasePage
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
                    if (zhuangxiu.Status.Equals(Utility.EnumModel.ZhuangXiuStatus.zhuangxiu.ToString()))
                    {
                        SetInfo(zhuangxiu);
                    }
                    else
                    {
                        this.tdYanShouMan.Value = WebUtil.GetUser(this.Context).RealName;
                        this.tdYanShouTime.Value = DateTime.Now.ToString("yyyy-MM-dd");
                    }
                }
                else
                {
                    Response.Write("ID不合法");
                    Response.End();
                }
            }
        }
        private void SetInfo(Foresight.DataAccess.ZhuangXiu data)
        {
            this.tdYanShouTime.Value = data.YanShouTime > DateTime.MinValue ? data.YanShouTime.ToString("yyyy-MM-dd") : "";
            this.tdYanShouMan.Value = data.YanShouMan;
            this.tdTotalWeiGuiCost.Value = "0";
            this.tdYanShouRemark.Value = data.YanShouRemark;
            var list = Foresight.DataAccess.ZhuangXiu_XunJian.GetZhuangXiu_XunJianList(data.ID);
            this.tdTotalWeiGuiCost.Value = list.Where(p => p.XunJianStatus.Equals("WeiGui")).Sum(p =>
                {
                    if (p.WeiGuiCost < 0)
                    {
                        return 0;
                    }
                    return p.WeiGuiCost;
                }).ToString();
        }
    }
}