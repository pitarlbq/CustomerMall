using Foresight.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.APPSetup
{
    public partial class UserLevelEdit : BasePage
    {
        public int LevelID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request.QueryString["LevelID"], out LevelID);
            if (LevelID > 0)
            {
                var data = Foresight.DataAccess.Mall_UserLevel.GetMall_UserLevel(LevelID);
                if (data != null)
                {
                    SetInfo(data);
                }
            }
        }
        private void SetInfo(Foresight.DataAccess.Mall_UserLevel data)
        {
            this.tdName.Value = data.Name;
            this.tdRemark.Value = data.Remark;
            this.tdStartAmount.Value = data.StartAmount > 0 ? data.StartAmount.ToString("0.00") : "0.00";
            this.tdEndAmount.Value = data.EndAmount > 0 ? data.EndAmount.ToString("0.00") : "0.00";
        }
    }
}