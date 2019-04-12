using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;

using Foresight.DataAccess.Framework;

namespace Foresight.DataAccess
{
    /// <summary>
    /// This object represents the properties and methods of a Wechat_SurveyOptionResponse.
    /// </summary>
    public partial class Wechat_SurveyOptionResponse : EntityBase
    {
        public static Wechat_SurveyOptionResponse[] GetWechat_SurveyOptionResponseListBySurveyID(int SurveyID, string OpenID = "", int UserID = 0)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (SurveyID > 0)
            {
                conditions.Add("[SurveyQuestionOptionID] in (select ID from [Wechat_SurveyQuestionOption] where [SurveyID]=@SurveyID)");
                parameters.Add(new SqlParameter("@SurveyID", SurveyID));
            }
            if (!string.IsNullOrEmpty(OpenID))
            {
                conditions.Add("[OpenID]=@OpenID");
                parameters.Add(new SqlParameter("@OpenID", OpenID));
            }
            if (UserID > 0)
            {
                conditions.Add("[UserID]=@UserID");
                parameters.Add(new SqlParameter("@UserID", UserID));
            }
            return GetList<Wechat_SurveyOptionResponse>("select * from [Wechat_SurveyOptionResponse] where  " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
        public static int GetWechat_SurveyOptionResponseCountBySurveyID(int SurveyID)
        {
            int total = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (SurveyID > 0)
            {
                conditions.Add("[SurveyQuestionOptionID] in (select ID from [Wechat_SurveyQuestionOption] where [SurveyID]=@SurveyID)");
                parameters.Add(new SqlParameter("@SurveyID", SurveyID));
            }
            string cmdtext = "select count(1) from(select Count(1) as total from [Wechat_SurveyOptionResponse] where  " + string.Join(" and ", conditions.ToArray()) + "group by [OpenID])A";
            using (SqlHelper helper = new SqlHelper())
            {
                var Total = helper.ExecuteScalar(cmdtext, CommandType.Text, parameters);
                if (Total != null)
                {
                    int.TryParse(Total.ToString(), out total);
                }
            }
            return total;
        }
        public static Wechat_SurveyOptionResponse[] GetWechat_SurveyOptionResponseListBySurveyIDList(List<int> SurveyIDList)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (SurveyIDList.Count == 0)
            {
                return new Wechat_SurveyOptionResponse[] { };
            }
            conditions.Add("[SurveyQuestionOptionID] in (select ID from [Wechat_SurveyQuestionOption] where [SurveyID] in (" + string.Join(",", SurveyIDList.ToArray()) + "))");
            return GetList<Wechat_SurveyOptionResponse>("select * from [Wechat_SurveyOptionResponse] where  " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
        public static Wechat_SurveyOptionResponse[] GetWechat_SurveyQuestionResponseListBySurveyIDList(List<int> SurveyIDList)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (SurveyIDList.Count == 0)
            {
                return new Wechat_SurveyOptionResponse[] { };
            }
            conditions.Add("[SurveyQuestionID] in (select ID from [Wechat_SurveyQuestion] where [SurveyID] in (" + string.Join(",", SurveyIDList.ToArray()) + "))");
            return GetList<Wechat_SurveyOptionResponse>("select * from [Wechat_SurveyOptionResponse] where  " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
        public static Wechat_SurveyOptionResponse[] GetWechat_SurveyQuestionResponseListByQuestionID(int QuestionID, int UserID, string OpenID = "")
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (QuestionID == 0 || UserID == 0)
            {
                return new Wechat_SurveyOptionResponse[] { };
            }
            if (QuestionID > 0)
            {
                conditions.Add("[SurveyQuestionID]=@QuestionID");
                parameters.Add(new SqlParameter("@QuestionID", QuestionID));
            }
            if (UserID > 0)
            {
                conditions.Add("[UserID]=@UserID");
                parameters.Add(new SqlParameter("@UserID", UserID));
            }
            if (!string.IsNullOrEmpty(OpenID))
            {
                conditions.Add("[OpenID]=@OpenID");
                parameters.Add(new SqlParameter("@OpenID", OpenID));
            }
            return GetList<Wechat_SurveyOptionResponse>("select * from [Wechat_SurveyOptionResponse] where  " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
    }
}
