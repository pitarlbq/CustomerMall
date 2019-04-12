using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Linq;
using Foresight.DataAccess.Framework;

namespace Foresight.DataAccess
{
    /// <summary>
    /// This object represents the properties and methods of a Wechat_SurveyQuestion.
    /// </summary>
    public partial class Wechat_SurveyQuestion : EntityBase
    {
        public static Ui.DataGrid GetWechat_SurveyQuestionGridByKeywords(string Keywords, List<int> SurveyIDList, string orderBy, long startRowIndex, int pageSize)
        {
            long totalRows = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (!string.IsNullOrEmpty(Keywords))
            {
                conditions.Add("([QuestionContent] like @Keywords)");
                parameters.Add(new SqlParameter("@Keywords", "%" + Keywords + "%"));
            }
            if (SurveyIDList.Count > 0)
            {
                conditions.Add("[SurveyID] in (" + string.Join(",", SurveyIDList.ToArray()) + ")");
            }
            string fieldList = "[Wechat_SurveyQuestion].* ";
            string Statement = " from [Wechat_SurveyQuestion] where  " + string.Join(" and ", conditions.ToArray());
            Wechat_SurveyQuestion[] list = GetList<Wechat_SurveyQuestion>(fieldList, Statement, parameters, orderBy, startRowIndex, pageSize, out totalRows).ToArray();
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
        public static Ui.DataGrid GetWechat_SurveyQuestionPhraseGridByKeywords(string Keywords, List<int> SurveyIDList, string orderBy, long startRowIndex, int pageSize)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            if (SurveyIDList.Count > 0)
            {
                conditions.Add("[SurveyID] in (" + string.Join(",", SurveyIDList.ToArray()) + ")");
            }
            conditions.Add("1=1");
            string cmdtext = "select * from [User] where  [IsAllowPhrase]=1 " + orderBy;
            var user_list = GetList<User>(cmdtext, parameters).ToArray();
            var question_list = GetList<Wechat_SurveyQuestion>("select * from [Wechat_SurveyQuestion] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
            var item_list = new List<Dictionary<string, object>>();
            foreach (var item in user_list)
            {
                var dic = new Dictionary<string, object>();
                var my_question = question_list.FirstOrDefault(p => p.UserID == item.UserID);
                if (my_question != null)
                {
                    if (my_question.IsDeleted)
                    {
                        continue;
                    }
                    if (!string.IsNullOrEmpty(Keywords) && !my_question.QuestionContent.Contains(Keywords))
                    {
                        continue;
                    }
                    dic = my_question.ToJsonObject();
                }
                else
                {
                    string QuestionContent = string.IsNullOrEmpty(item.NickName) ? item.LoginName : item.NickName;
                    if (!string.IsNullOrEmpty(Keywords) && !QuestionContent.Contains(Keywords))
                    {
                        continue;
                    }
                    dic["ID"] = 0;
                    dic["UserID"] = item.UserID;
                    dic["SurveyID"] = 0;
                    dic["QuestionContent"] = QuestionContent;
                    dic["QuestionType"] = 1;
                    dic["SortOrder"] = 1;
                    dic["AddTime"] = DateTime.Now;
                    dic["AddMan"] = "";
                    dic["CoverImg"] = item.HeadImg;
                    dic["QuestionDescription"] = item.Summary;
                    dic["IsDisabled"] = 0;
                    dic["IsDeleted"] = 0;
                }
                item_list.Add(dic);
            }
            List<int> UserIDList = user_list.Select(p => p.UserID).ToList();
            question_list = question_list.Where(p => !UserIDList.Contains(p.UserID)).ToArray();
            foreach (var item in question_list)
            {
                if (item.IsDeleted)
                {
                    continue;
                }
                var dic = new Dictionary<string, object>();
                if (!string.IsNullOrEmpty(Keywords) && !item.QuestionContent.Contains(Keywords))
                {
                    continue;
                }
                dic = item.ToJsonObject();
                item_list.Add(dic);
            }
            item_list = item_list.OrderBy(p => Convert.ToInt32(p["SortOrder"])).ToList();
            int StartRowIndex = Convert.ToInt32(startRowIndex);
            var finallist = item_list.Skip(StartRowIndex).Take(pageSize).ToList();
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = finallist;
            dg.total = item_list.Count;
            dg.page = pageSize;
            return dg;
        }
        public static Wechat_SurveyQuestion[] GetWechat_SurveyQuestionListBySurveyID(int SurveyID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (SurveyID <= 0)
            {
                return new Wechat_SurveyQuestion[] { };
            }
            conditions.Add("[SurveyID]=@SurveyID");
            parameters.Add(new SqlParameter("@SurveyID", SurveyID));
            string Statement = "select * from [Wechat_SurveyQuestion] where  " + string.Join(" and ", conditions.ToArray());
            return GetList<Wechat_SurveyQuestion>(Statement, parameters).ToArray();
        }
        public static Wechat_SurveyQuestion[] GetWechat_SurveyQuestionListBySurveyIDList(List<int> SurveyIDList)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (SurveyIDList.Count == 0)
            {
                return new Wechat_SurveyQuestion[] { };
            }
            conditions.Add("[SurveyID] in (" + string.Join(",", SurveyIDList.ToArray()) + ")");
            string Statement = "select * from [Wechat_SurveyQuestion] where  " + string.Join(" and ", conditions.ToArray());
            return GetList<Wechat_SurveyQuestion>(Statement, parameters).ToArray();
        }
        public static List<Dictionary<string, object>> GetWechat_SurveyQuestionPhraseListByUserID(int UserID, int SurveyID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            if (UserID == 0 || SurveyID <= 0)
            {
                return new List<Dictionary<string, object>>();
            }
            string cmdtext = "select * from [User] where [IsAllowPhrase]=1";
            var user_list = GetList<User>(cmdtext, parameters).ToArray();
            conditions.Add("[SurveyID]=@SurveyID");
            parameters.Add(new SqlParameter("@SurveyID", SurveyID));
            var question_list = GetList<Wechat_SurveyQuestion>("select * from [Wechat_SurveyQuestion] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
            var item_list = new List<Dictionary<string, object>>();
            foreach (var item in user_list)
            {
                var dic = new Dictionary<string, object>();
                var my_question = question_list.FirstOrDefault(p => p.UserID == item.UserID);
                if (my_question != null)
                {
                    if (my_question.IsDeleted)
                    {
                        continue;
                    }
                    dic = my_question.ToJsonObject();
                }
                else
                {
                    string QuestionContent = string.IsNullOrEmpty(item.NickName) ? item.LoginName : item.NickName;
                    dic["ID"] = 0;
                    dic["UserID"] = item.UserID;
                    dic["SurveyID"] = SurveyID;
                    dic["QuestionContent"] = QuestionContent;
                    dic["QuestionType"] = 1;
                    dic["SortOrder"] = 1;
                    dic["AddTime"] = DateTime.Now;
                    dic["AddMan"] = "";
                    dic["CoverImg"] = item.HeadImg;
                    dic["QuestionSummary"] = item.Summary;
                    dic["QuestionDescription"] = item.Summary;
                    dic["IsDisabled"] = 0;
                    dic["IsDeleted"] = 0;
                }
                item_list.Add(dic);
            }
            List<int> UserIDList = user_list.Select(p => p.UserID).ToList();
            question_list = question_list.Where(p => !UserIDList.Contains(p.UserID)).ToArray();
            foreach (var item in question_list)
            {
                if (item.IsDeleted)
                {
                    continue;
                }
                var dic = new Dictionary<string, object>();
                dic = item.ToJsonObject();
                item_list.Add(dic);
            }
            item_list = item_list.OrderBy(p => Convert.ToInt32(p["SortOrder"])).ToList();
            return item_list;
        }
        public static bool CheckWechat_SurveyQuestionVoteStatus(Wechat_Survey survey, int UserID, Wechat_SurveyOptionResponse[] response_list, string OpenID = "")
        {
            var my_response_list = new Wechat_SurveyOptionResponse[] { };
            if (UserID > 0)
            {
                my_response_list = response_list.Where(p => p.UserID == UserID).ToArray();
            }
            if (!string.IsNullOrEmpty(OpenID))
            {
                my_response_list = response_list.Where(p => p.OpenID.Equals(OpenID)).ToArray();
            }
            if (my_response_list.Length == 0)
            {
                return true;
            }
            if (!survey.IsAllowRepeatVote)
            {
                return false;
            }
            int vote_count = my_response_list.Where(p => p.AddTime.ToString("yyyy-MM-dd").Equals(DateTime.Now.ToString("yyyy-MM-dd"))).ToArray().Length;
            if (vote_count >= survey.DayVoteLimitCount)
            {
                return false;
            }
            return true;
        }
        public string QuestionTypeDesc
        {
            get
            {
                if (this.QuestionType == 1)
                {
                    return "单选";
                }
                if (this.QuestionType == 2)
                {
                    return "多选";
                }
                return string.Empty;
            }
        }
    }
}
