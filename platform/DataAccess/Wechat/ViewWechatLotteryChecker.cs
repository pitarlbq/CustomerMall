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
	/// This object represents the properties and methods of a ViewWechatLotteryChecker.
	/// </summary>
	public partial class ViewWechatLotteryChecker : EntityBaseReadOnly
	{
        public static Ui.DataGrid GetViewWechatLotteryCheckerList(string keywords, int activityID, string orderBy, long startRowIndex, int pageSize)
        {
            long totalRows = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (!string.IsNullOrEmpty(keywords))
            {
                parameters.Add(new SqlParameter("@Keywords", "%" + keywords + "%"));
                conditions.Add("([NickName] like @Keywords or [RealName] like @Keywords or [LoginName] like @Keywords)");
            }
            if (activityID > 0)
            {
                parameters.Add(new SqlParameter("@ActivityID", activityID));
                conditions.Add("[ActivityID]=@ActivityID");
            }
            var list = GetList<ViewWechatLotteryChecker>("*", "from [ViewWechatLotteryChecker] where " + string.Join(" and ", conditions.ToArray()), parameters, orderBy, startRowIndex, pageSize, out totalRows).ToArray();
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
	}
}
