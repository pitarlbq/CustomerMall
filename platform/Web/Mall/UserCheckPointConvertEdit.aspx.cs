using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Mall
{
    public partial class UserCheckPointConvertEdit : BasePage
    {
        public int ID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["ID"] != null)
            {
                int.TryParse(Request.QueryString["ID"], out ID);
            }
            if (ID > 0)
            {
                var data = Foresight.DataAccess.Mall_UserPointRule.GetMall_UserPointRule(ID);
                SetInfo(data);
            }
        }
        private void SetInfo(Foresight.DataAccess.Mall_UserPointRule data)
        {
            this.tdStartPoint.Value = data.StartPoint.ToString("0");
            this.tdEndPoint.Value = data.EndPoint.ToString("0");
            this.tdPointType.Value = data.PointType.ToString("0");
            this.tdIsActive.Value = data.IsActive ? "1" : "0";
            this.tdRemark.Value = data.Remark;
            this.tdPointValue.Value = data.PointValue.ToString();
        }
    }
}