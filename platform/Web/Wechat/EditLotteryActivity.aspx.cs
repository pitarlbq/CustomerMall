using Foresight.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Web.Wechat
{
    public partial class EditLotteryActivity : BasePage
    {
        public int ID = 0;
        public string CoverImgPath = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request.QueryString["ID"], out ID);
            if (ID > 0)
            {
                var data = Foresight.DataAccess.Wechat_LotteryActivity.GetWechat_LotteryActivity(ID);
                if (data != null)
                {
                    SetInfo(data);
                    return;
                }
            }
        }
        private void SetInfo(Foresight.DataAccess.Wechat_LotteryActivity data)
        {
            this.tdActivityName.Value = data.ActivityName;
            this.tdMerchantName.Value = data.MerchantName;
            this.tdType.Value = data.Type;
            this.tdRepeat.Value = data.Repeat;
            this.tdRepeatTime.Value = data.RepeatTime > 0 ? data.RepeatTime.ToString() : "0";
            this.tdParticipantNumber.Value = data.ParticipantNumber > 0 ? data.ParticipantNumber.ToString() : "0";
            this.tdUserLimit.Value = data.UserLimit ? "1" : "0";
            this.tdNoLimitMsg.Value = data.NoLimitMsg;
            this.tdStartTime.Value = WebUtil.GetStrDate(data.StartTime, "yyyy-MM-dd HH:mm:ss");
            this.tdEndTime.Value = WebUtil.GetStrDate(data.EndTime, "yyyy-MM-dd HH:mm:ss");
            this.tdRuleDescription.Value = data.RuleDescription;
            this.tdDescription.Value = data.Description;
            CoverImgPath = !string.IsNullOrEmpty(data.CoverImg) ? WebUtil.GetContextPath() + data.CoverImg : string.Empty;
        }
    }
}