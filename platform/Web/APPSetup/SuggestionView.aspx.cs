using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.APPSetup
{
    public partial class SuggestionView : BasePage
    {
        public int ID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["ID"] != null)
            {
                int.TryParse(Request.QueryString["ID"], out ID);
            }
            Foresight.DataAccess.Mall_Suggestion data = null;
            if (ID > 0)
            {
                data = Foresight.DataAccess.Mall_Suggestion.GetMall_Suggestion(ID);
            }
            if (data == null)
            {
                Response.End();
                return;
            }
            SetInfo(data);
        }
        private void SetInfo(Foresight.DataAccess.Mall_Suggestion data)
        {
            this.tdContentSummary.InnerHtml = data.SummaryContent;
            this.tdAddTime.InnerHtml = data.AddTime > DateTime.MinValue ? data.AddTime.ToString("yyyy-MM-dd HH:mm:ss") : "";
            var user = Foresight.DataAccess.User.GetUser(data.UserID);
            if (user != null)
            {
                this.tdNickName.InnerHtml = user.NickName;
                this.tdPhoneNumber.InnerHtml = user.PhoneNumber;
            }
        }
    }
}