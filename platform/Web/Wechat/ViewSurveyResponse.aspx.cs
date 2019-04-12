using Foresight.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Wechat
{
    public partial class ViewSurveyResponse : BasePage
    {
        public int SurveyID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request.QueryString["SurveyID"], out SurveyID);
            Foresight.DataAccess.Wechat_Survey data = null;
            if (SurveyID > 0)
            {
                data = Foresight.DataAccess.Wechat_Survey.GetWechat_Survey(SurveyID);
            }
            if (data == null)
            {
                Response.End();
                return;
            }
        }
    }
}