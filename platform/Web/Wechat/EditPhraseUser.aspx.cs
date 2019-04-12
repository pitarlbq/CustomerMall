using Foresight.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Wechat
{
    public partial class EditPhraseUser : BasePage
    {
        public int SurveyID = 0;
        public int QuestionID = 0;
        public int UserID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request.QueryString["SurveyID"], out SurveyID);
            int.TryParse(Request.QueryString["QuestionID"], out QuestionID);
            int.TryParse(Request.QueryString["UserID"], out UserID);
            if (QuestionID > 0)
            {
                var data = Foresight.DataAccess.Wechat_SurveyQuestion.GetWechat_SurveyQuestion(QuestionID);
                if (data != null)
                {
                    SetInfo(data);
                    return;
                }
            }
            if (UserID > 0)
            {
                if (this.SurveyID <= 0)
                {
                    Response.End();
                    return;
                }
                var user = Foresight.DataAccess.User.GetUser(UserID);
                if (UserID > 0)
                {
                    GetInfo(user);
                }
            }
        }
        private void SetInfo(Foresight.DataAccess.Wechat_SurveyQuestion data)
        {
            this.tdQuestionContent.Value = data.QuestionContent;
            this.tdSortOrder.Value = data.SortOrder.ToString();
            this.SurveyID = data.SurveyID;
            this.tdQuestionSummary.Value = data.QuestionSummary;
            this.hdContent.Value = data.QuestionDescription;
            this.tdIsDisabled.Checked = !data.IsDisabled;
        }
        private void GetInfo(Foresight.DataAccess.User user)
        {
            var data = new Foresight.DataAccess.Wechat_SurveyQuestion();
            data.SurveyID = SurveyID;
            data.QuestionContent = user.NickName;
            data.QuestionType = 1;
            data.SortOrder = 1;
            data.AddTime = DateTime.Now;
            data.AddMan = WebUtil.GetUser(this.Context).LoginName;
            data.CoverImg = user.HeadImg;
            data.QuestionDescription = user.Summary;
            data.QuestionDescription = user.Summary;
            data.IsDisabled = false;
            data.IsDeleted = false;
            data.UserID = user.UserID;
            data.Save();
            this.QuestionID = data.ID;
            this.tdQuestionContent.Value = data.QuestionContent;
            this.tdSortOrder.Value = data.SortOrder.ToString();
            this.SurveyID = data.SurveyID;
            this.tdQuestionSummary.Value = data.QuestionSummary;
            this.hdContent.Value = data.QuestionDescription;
            this.tdIsDisabled.Checked = !data.IsDisabled;
        }
    }
}