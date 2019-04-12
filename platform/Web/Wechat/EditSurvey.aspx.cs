using Foresight.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utility;

namespace Web.Wechat
{
    public partial class EditSurvey : BasePage
    {
        public int SurveyID = 0;
        public string CoverImg = string.Empty;
        public int type = 1;
        public int SurveyType = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["type"] != null)
            {
                int.TryParse(Request.QueryString["type"], out type);
            }
            if (Request.QueryString["SurveyType"] != null)
            {
                int.TryParse(Request.QueryString["SurveyType"], out SurveyType);
            }
            this.tdLabel.InnerHtml = "描述";
            if (SurveyType == 2)
            {
                this.tdLabel.InnerHtml = "投票规则";
            }
            int.TryParse(Request.QueryString["SurveyID"], out SurveyID);
            if (SurveyID > 0)
            {
                var data = Foresight.DataAccess.Wechat_Survey.GetWechat_Survey(SurveyID);
                if (data != null)
                {
                    SetInfo(data);
                    return;
                }
            }
            if (type == 1)
            {
                this.tdIsWechatSend.Checked = true;
            }
            if (type == 2)
            {
                this.tdIsCustomerAPPSend.Checked = true;
            }
            if (type == 3)
            {
                this.tdIsUserAPPSend.Checked = true;
            }
        }
        private void SetInfo(Foresight.DataAccess.Wechat_Survey data)
        {
            this.tdTitle.Value = data.Title;
            this.tdDescription.Value = data.Description;
            this.tdStatus.Value = data.Status >= 0 ? data.Status.ToString() : "1";
            this.tdStartTime.Value = data.StartTime > DateTime.MinValue ? data.StartTime.ToString("yyyy-MM-dd HH:mm:ss") : "";
            this.tdEndTime.Value = data.EndTime > DateTime.MinValue ? data.EndTime.ToString("yyyy-MM-dd HH:mm:ss") : "";
            this.CoverImg = !string.IsNullOrEmpty(data.CoverImg) ? WebUtil.GetContextPath() + data.CoverImg : string.Empty;
            type = data.SurveyType > 0 ? data.SurveyType : 1;
            this.tdIsWechatSend.Checked = data.IsWechatShow;
            this.tdIsCustomerAPPSend.Checked = data.IsAPPCustomerShow;
            this.tdIsUserAPPSend.Checked = data.IsAPPUserShow;
            this.SurveyType = data.SurveyType;
            this.tdDayVoteLimitCount.Value = data.DayVoteLimitCount > 0 ? data.DayVoteLimitCount.ToString() : "0";
            var survery_project_list = Foresight.DataAccess.Wechat_SurveyProject.GetWechat_SurveyProjectList(data.ID);
            if (survery_project_list.Length > 0)
            {
                var project_list = Project.GetProjectListByIDs(survery_project_list.Select(p => p.ProjectID).ToList());
                if (project_list.Length > 0)
                {
                    this.tdProjects.Value = string.Join(",", project_list.Select(p => p.Name).ToArray());
                    this.hdProjectIDs.Value = JsonConvert.SerializeObject(project_list.Select(p => p.ID).ToArray());
                }
            }
            this.tdIsAllowRepeatVoteYes.Checked = data.IsAllowRepeatVote;
        }
    }
}