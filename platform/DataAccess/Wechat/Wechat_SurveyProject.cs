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
	/// This object represents the properties and methods of a Wechat_SurveyProject.
	/// </summary>
	public partial class Wechat_SurveyProject : EntityBase
	{
        public static Wechat_SurveyProject[] GetWechat_SurveyProjectList(int Wechat_SurveyID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            string cmdwhere = string.Empty;
            if (Wechat_SurveyID <= 0)
            {
                return new Wechat_SurveyProject[] { };
            }
            cmdwhere += " and [Wechat_SurveyID]=@Wechat_SurveyID";
            parameters.Add(new SqlParameter("@Wechat_SurveyID", Wechat_SurveyID));
            return GetList<Wechat_SurveyProject>("select * from [Wechat_SurveyProject] where 1=1 " + cmdwhere, parameters).ToArray();
        }
	}
}
