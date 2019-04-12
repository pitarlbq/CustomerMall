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
	/// This object represents the properties and methods of a Wechat_ServiceUser.
	/// </summary>
	public partial class Wechat_ServiceUser : EntityBase
	{
	}
    public partial class Wechat_ServiceUserDetail : Wechat_ServiceUser
    {
        [DatabaseColumn("LoginName")]
        public string LoginName { get; set; }

        [DatabaseColumn("RealName")]
        public string RealName { get; set; }
        public string FinalRealName
        {
            get
            {
                if (string.IsNullOrEmpty(this.RealName))
                {
                    return this.LoginName;
                }
                return this.RealName;
            }
        }
        public static Ui.DataGrid GetWechat_ServiceUserDetailGridByKeywords(string Keywords, string orderBy, long startRowIndex, int pageSize)
        {
            long totalRows = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (!string.IsNullOrEmpty(Keywords))
            {
                conditions.Add("([NickName] like @Keywords or [AccountName] like @Keywords or [Wx_Account] like @Keywords)");
                parameters.Add(new SqlParameter("@Keywords", "%" + Keywords + "%"));
            }
            string fieldList = "A.*";
            string Statement = " from (select Wechat_ServiceUser.*,[User].LoginName,[User].RealName from [Wechat_ServiceUser] left join [User] on [User].UserID=Wechat_ServiceUser.UserID)A where  " + string.Join(" and ", conditions.ToArray());
            Wechat_ServiceUserDetail[] list = GetList<Wechat_ServiceUserDetail>(fieldList, Statement, parameters, orderBy, startRowIndex, pageSize, out totalRows).ToArray();
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
    }
}
