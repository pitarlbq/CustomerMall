using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.ZhuangXiu
{
    public partial class ViewXunJianDetailInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int ZhuangXiuID = 0;
            int.TryParse(Request.QueryString["ID"], out ZhuangXiuID);
            var zhuangxiu = Foresight.DataAccess.ZhuangXiu.GetZhuangXiu(ZhuangXiuID);
            if (zhuangxiu != null)
            {
                var list = Foresight.DataAccess.ZhuangXiu_XunJian.GetZhuangXiu_XunJianList(zhuangxiu.ID);
                string op = Request.QueryString["op"];
                if (op.Equals("normal"))
                {
                    list = list.Where(p => p.XunJianStatus.Equals("ZhengChang")).ToArray();
                }
                else if (op.Equals("weigui"))
                {
                    list = list.Where(p => p.XunJianStatus.Equals("WeiGui")).ToArray();
                }
                else
                {
                    list = new Foresight.DataAccess.ZhuangXiu_XunJian[] { };
                }
                if (list.Length > 0)
                {
                    this.rptXunJian.Visible = true;
                    this.rptXunJian.DataSource = list;
                    this.rptXunJian.DataBind();
                    this.panContent.Visible = false;
                }
                else
                {
                    this.rptXunJian.Visible = false;
                    this.panContent.Visible = true;
                }
            }
            else
            {
                Response.Write("ID不合法");
                Response.End();
            }
        }

        protected void FileRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

        }

        protected void rptXunJian_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Repeater fileRep = (Repeater)e.Item.FindControl("FileRepeater");
                var xunjian = ((Foresight.DataAccess.ZhuangXiu_XunJian)e.Item.DataItem);
                fileRep.DataSource = Foresight.DataAccess.ZhuangXiu_File.GetZhuangXiu_FileAttachList(xunjian.ID, Utility.EnumModel.ZhuangXiuFileType.addxunjian.ToString());
                fileRep.DataBind();
            }
        }
    }
}