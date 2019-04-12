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
    /// This object represents the properties and methods of a Wechat_Survey.
    /// </summary>
    public partial class Wechat_Survey : EntityBase
    {
        public static Wechat_Survey[] GetWechat_SurveyListByUserID(int UserID)
        {
            if (UserID == 0)
            {
                return new Wechat_Survey[] { };
            }
            var ProjectIDList = Project.GetParentProjectIDListByAPPUserID(UserID);
            if (ProjectIDList.Count == 0)
            {
                return new Wechat_Survey[] { };
            }
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[ID] in (select [Wechat_SurveyID] from [Wechat_SurveyProject] where [ProjectID] in (" + string.Join(",", ProjectIDList.ToArray()) + "))");
            return GetList<Wechat_Survey>("select * from [Wechat_Survey] where [SurveyType]=3 and " + string.Join(" and ", conditions.ToArray()) + " order by [AddTime] desc", parameters).ToArray();
        }
        public static Wechat_Survey[] GetWechat_SurveyListByKeywords(string Keywords, int type, int SurveyType)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[SurveyType]=@SurveyType");
            parameters.Add(new SqlParameter("@SurveyType", SurveyType));
            if (type == 1)
            {
                conditions.Add("[IsWechatShow]=1");
            }
            if (type == 2 || type == 3)
            {
                conditions.Add("([IsAPPCustomerShow]=1 or [IsAPPUserShow]=1)");
            }
            if (!string.IsNullOrEmpty(Keywords))
            {
                conditions.Add("[Title] like @Keywords");
                parameters.Add(new SqlParameter("@Keywords", "%" + Keywords + "%"));
            }
            return GetList<Wechat_Survey>("select * from [Wechat_Survey] where " + string.Join(" and ", conditions.ToArray()) + " order by [AddTime] desc", parameters).ToArray();
        }
        public static Wechat_Survey[] GetWechat_SurveyListBySurveyType(int SurveyType, long startRowIndex, int pageSize, out long totalRows, bool IsWechatShow = false, bool IsAPPUserShow = false, bool IsAPPCustomerShow = false)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            string orderby = "[AddTime] desc";
            conditions.Add(" [Status]=1");
            if (SurveyType > 0)
            {
                conditions.Add("[SurveyType]=@SurveyType");
                parameters.Add(new SqlParameter("@SurveyType", SurveyType));
            }
            if (IsWechatShow)
            {
                conditions.Add("[IsWechatShow]=1");
            }
            if (IsAPPUserShow)
            {
                conditions.Add("[IsAPPUserShow]=1");
            }
            if (IsAPPCustomerShow)
            {
                conditions.Add("[IsAPPCustomerShow]=1");
            }
            string fieldList = "[Wechat_Survey].*";
            string Statement = " from [Wechat_Survey] where " + string.Join(" and ", conditions.ToArray());
            var list = GetList<Wechat_Survey>(fieldList, Statement, parameters, orderby, startRowIndex, pageSize, out totalRows).ToArray();
            return list;
        }
    }
}
