using Foresight.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Wechat
{
    public partial class EditSurveyQuestion : BasePage
    {
        public int SurveyID = 0;
        public int QuestionID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request.QueryString["SurveyID"], out SurveyID);
            int.TryParse(Request.QueryString["QuestionID"], out QuestionID);
            if (QuestionID > 0)
            {
                var data = Foresight.DataAccess.Wechat_SurveyQuestion.GetWechat_SurveyQuestion(QuestionID);
                if (data != null)
                {
                    SetInfo(data);
                    return;
                }
            }
        }
        private void SetInfo(Foresight.DataAccess.Wechat_SurveyQuestion data)
        {
            this.tdQuestionContent.Value = data.QuestionContent;
            this.tdQuestionType.Value = data.QuestionType.ToString();
            this.tdSortOrder.Value = data.SortOrder.ToString();
            this.SurveyID = data.SurveyID;
        }
    }
}