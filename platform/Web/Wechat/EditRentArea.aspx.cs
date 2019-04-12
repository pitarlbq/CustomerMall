using Foresight.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Wechat
{
    public partial class EditRentArea : BasePage
    {
        public int AreaID = 0;
        public int data_id = 0;
        public string data_type = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request.QueryString["ID"], out data_id);
            int.TryParse(Request.QueryString["AreaID"], out AreaID);
            if (Request.QueryString["type"] != null)
            {
                data_type = Request.QueryString["type"];
            }
            if (data_type.Equals("area"))
            {
                this.label_title.InnerHtml = "区域名称";
                if (data_id > 0)
                {
                    var data = Foresight.DataAccess.Wechat_RentArea.GetWechat_RentArea(data_id);
                    if (data != null)
                    {
                        SetInfo(data);
                        return;
                    }
                }
            }
            else if (data_type.Equals("building"))
            {
                this.label_title.InnerHtml = "楼盘名称";
                if (data_id > 0)
                {
                    var data = Foresight.DataAccess.Wechat_RentBuilding.GetWechat_RentBuilding(data_id);
                    if (data != null)
                    {
                        SetBuildingInfo(data);
                        return;
                    }
                }
            }
            else
            {
                Response.End();
                return;
            }
        }
        private void SetInfo(Foresight.DataAccess.Wechat_RentArea data)
        {
            this.tdAreaName.Value = data.AreaName;
        }
        private void SetBuildingInfo(Foresight.DataAccess.Wechat_RentBuilding data)
        {
            this.tdAreaName.Value = data.BuildingName;
        }
    }
}