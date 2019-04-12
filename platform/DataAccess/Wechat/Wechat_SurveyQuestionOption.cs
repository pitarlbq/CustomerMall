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
    /// This object represents the properties and methods of a Wechat_SurveyQuestionOption.
    /// </summary>
    public partial class Wechat_SurveyQuestionOption : EntityBase
    {
        public static Wechat_SurveyQuestionOption[] GetWechat_SurveyQuestionOptionListBySurveyID(int SurveyID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (SurveyID > 0)
            {
                conditions.Add("[SurveyID]=@SurveyID");
                parameters.Add(new SqlParameter("@SurveyID", SurveyID));
            }
            return GetList<Wechat_SurveyQuestionOption>("select * from [Wechat_SurveyQuestionOption] where  " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
        public static Wechat_SurveyQuestionOption[] GetWechat_SurveyQuestionOptionListByQuestionID(int SurveyQuestionID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (SurveyQuestionID > 0)
            {
                conditions.Add("[SurveyQuestionID]=@SurveyQuestionID");
                parameters.Add(new SqlParameter("@SurveyQuestionID", SurveyQuestionID));
            }
            return GetList<Wechat_SurveyQuestionOption>("select * from [Wechat_SurveyQuestionOption] where  " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
        public static Wechat_SurveyQuestionOption[] GetWechat_SurveyQuestionOptionListBySurveyIDList(List<int> SurveyIDList)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (SurveyIDList.Count == 0)
            {
                return new Wechat_SurveyQuestionOption[] { };
            }
            conditions.Add("[SurveyID] in (" + string.Join(",", SurveyIDList.ToArray()) + ")");
            return GetList<Wechat_SurveyQuestionOption>("select * from [Wechat_SurveyQuestionOption] where  " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
    }
    public partial class Wechat_SurveyQuestionOptionDetail : Wechat_SurveyQuestionOption
    {
        [DatabaseColumn("TotalCount")]
        public int TotalCount { get; set; }
        public static Wechat_SurveyQuestionOptionDetail[] GetWechat_SurveyQuestionOptionDetailListBySurveyID(int SurveyID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (SurveyID > 0)
            {
                conditions.Add("[SurveyID]=@SurveyID");
                parameters.Add(new SqlParameter("@SurveyID", SurveyID));
            }
            return GetList<Wechat_SurveyQuestionOptionDetail>("select *,(select count(1) from [Wechat_SurveyOptionResponse] where [SurveyQuestionOptionID]=[Wechat_SurveyQuestionOption].ID) as TotalCount from [Wechat_SurveyQuestionOption] where  " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
    }
}
