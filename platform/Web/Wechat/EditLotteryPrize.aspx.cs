using Foresight.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Wechat
{
    public partial class EditLotteryPrize : BasePage
    {
        public int ID = 0;
        public int ActivityID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request.QueryString["ID"], out ID);
            int.TryParse(Request.QueryString["ActivityID"], out ActivityID);
            if (ID > 0)
            {
                var data = Foresight.DataAccess.Wechat_LotteryActivityPrize.GetWechat_LotteryActivityPrize(ID);
                if (data != null)
                {
                    SetInfo(data);
                    return;
                }
            }
            if (ActivityID <= 0)
            {
                Response.End();
                return;
            }
        }
        private void SetInfo(Foresight.DataAccess.Wechat_LotteryActivityPrize data)
        {
            this.tdLevelName.Value = data.LevelName;
            this.tdQuota.Value = data.Quota > 0 ? data.Quota.ToString() : "0";
            this.tdPrizeName.Value = data.PrizeName;
            this.tdType.Value = data.Type;
            this.tdPrizeQuantity.Value = data.PrizeQuantity > 0 ? data.PrizeQuantity.ToString() : "0";
            this.tdPrizeUnit.Value = data.PrizeUnit;
            this.tdRepeatTime.Value = data.RepeatTime > 0 ? data.RepeatTime.ToString() : "0";
            this.ActivityID = data.ActivityID;
        }
    }
}