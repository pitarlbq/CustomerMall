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
    /// This object represents the properties and methods of a Wechat_Business.
    /// </summary>
    public partial class Wechat_Business : EntityBase
    {
        public static Ui.DataGrid GeWechat_BusinessGridByKeywords(string Keywords, string orderBy, long startRowIndex, int pageSize)
        {
            long totalRows = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add(" 1=1 ");
            if (!string.IsNullOrEmpty(Keywords))
            {
                conditions.Add("([BusinessName] like @Keywords or [PhoneNumber] like @Keywords)");
                parameters.Add(new SqlParameter("@Keywords", "%" + Keywords + "%"));
            }
            string fieldList = "[Wechat_Business].*";
            string Statement = " from [Wechat_Business] where  " + string.Join(" and ", conditions.ToArray());
            Wechat_Business[] list = new Wechat_Business[] { };
            list = GetList<Wechat_Business>(fieldList, Statement, parameters, orderBy, startRowIndex, pageSize, out totalRows).ToArray();
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
        public string PublishStatus
        {
            get
            {
                return this.IsPublish ? "已发布" : "未发布";
            }
        }
    }
}
