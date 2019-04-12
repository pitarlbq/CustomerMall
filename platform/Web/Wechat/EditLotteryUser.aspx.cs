using Foresight.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Wechat
{
    public partial class EditLotteryUser : BasePage
    {
        public int ID = 0;
        public int ActivityID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request.QueryString["ID"], out ID);
            int.TryParse(Request.QueryString["ActivityID"], out ActivityID);
            if (ID > 0)
            {
                var data = Foresight.DataAccess.Wechat_LotteryActivityUser.GetWechat_LotteryActivityUser(ID);
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
        private void SetInfo(Foresight.DataAccess.Wechat_LotteryActivityUser data)
        {
            this.tdCustomerName.Value = data.CustomerName;
            this.tdPhoneNumber.Value = data.PhoneNumber;
            this.ActivityID = data.ActivityID;
        }
    }
}