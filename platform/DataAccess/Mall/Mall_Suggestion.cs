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
	/// This object represents the properties and methods of a Mall_Suggestion.
	/// </summary>
	public partial class Mall_Suggestion : EntityBase
	{	

	}
    public partial class Mall_SuggestionDetail : Mall_Suggestion
    {
        [DatabaseColumn("NickName")]
        public string NickName { get; set; }
        [DatabaseColumn("PhoneNumber")]
        public string PhoneNumber { get; set; }
        public static Ui.DataGrid GetMall_SuggestionDetailByKeywords(string Keywords, string orderBy, long startRowIndex, int pageSize)
        {
            long totalRows = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (!string.IsNullOrEmpty(Keywords))
            {
                conditions.Add("([NickName] like @Keywords or [SummaryContent] like @Keywords or [PhoneNumber] like @Keywords)");
                parameters.Add(new SqlParameter("@Keywords", "%" + Keywords + "%"));
            }
            string fieldList = "A.*";
            string Statement = " from (select [Mall_Suggestion].*,[User].NickName,[User].PhoneNumber from [Mall_Suggestion] left join [User] on [User].UserID=[Mall_Suggestion].UserID) as A where  " + string.Join(" and ", conditions.ToArray());
            Mall_SuggestionDetail[] list = GetList<Mall_SuggestionDetail>(fieldList, Statement, parameters, orderBy, startRowIndex, pageSize, out totalRows).ToArray();
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
    }
}
