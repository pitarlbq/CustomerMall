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
    /// This object represents the properties and methods of a Contract_Template.
    /// </summary>
    public partial class Contract_Template : EntityBase
    {
        public static Ui.DataGrid GetContract_TemplateGridByKeywords(string Keywords, int Status, string orderBy, long startRowIndex, int pageSize)
        {
            long totalRows = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            #region 关键字查询
            string cmd = string.Empty;
            if (!string.IsNullOrEmpty(Keywords))
            {
                string[] keywords = Keywords.Trim().Split(' ');
                for (int i = 0; i < keywords.Length; i++)
                {
                    if (string.IsNullOrEmpty(keywords[i].ToString()))
                    {
                        continue;
                    }
                    if (i + 1 == keywords.Length)
                    {
                        if (keywords.Length == 1)
                        {
                            cmd += "  and  ([TemplateNo] like '%" + keywords[i] + "%' or [TemplateName] like '%" + keywords[i] + "%')";
                        }
                        else
                        {
                            cmd += "  ([TemplateNo] like '%" + keywords[i] + "%' or [TemplateName] like '%" + keywords[i] + "%'))";
                        }
                    }
                    else if (i == 0)
                    {
                        cmd += " and (([TemplateNo] like '%" + keywords[i] + "%' or [TemplateName] like '%" + keywords[i] + "%') or";
                    }
                    else
                    {
                        cmd += "  ([TemplateNo] like '%" + keywords[i] + "%' or [TemplateName] like '%" + keywords[i] + "%') or ";
                    }
                }
            }
            #endregion
            if (Status > 0)
            {
                conditions.Add("[TemplateStatus]=@TemplateStatus");
                parameters.Add(new SqlParameter("@TemplateStatus", Status));
            }
            string fieldList = "[Contract_Template].*";
            string Statement = " from [Contract_Template] where  " + string.Join(" and ", conditions.ToArray()) + cmd;
            Contract_Template[] list = GetList<Contract_Template>(fieldList, Statement, parameters, orderBy, startRowIndex, pageSize, out totalRows).ToArray();
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
        public string StatusDesc
        {
            get
            {
                switch (this.TemplateStatus)
                {
                    case 1:
                        return "启用";
                        break;
                    case 2:
                        return "停用";
                        break;
                    default:
                        return string.Empty;
                        break;
                }
                return string.Empty;
            }
        }
    }
}
