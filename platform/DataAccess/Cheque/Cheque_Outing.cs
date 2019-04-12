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
	/// This object represents the properties and methods of a Cheque_Outing.
	/// </summary>
	public partial class Cheque_Outing : EntityBase
	{	

	}
    public partial class Cheque_OutingDetail : Cheque_Outing
    {
        [DatabaseColumn("ProjectName")]
        public string ProjectName { get; set; }
        [DatabaseColumn("DepartmentName")]
        public string DepartmentName { get; set; }
        public static Ui.DataGrid GetCheque_OutingDetailGridByKeywords(string keywords, string orderBy, long startRowIndex, int pageSize)
        {
            long totalRows = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (!string.IsNullOrEmpty(keywords))
            {
                conditions.Add("([Operator] like @keywords or [Remark] like @keywords or [ProjectID] in (select [ID] from [Cheque_Project] where [ProjectName] like @keywords))");
                parameters.Add(new SqlParameter("@keywords", "%" + keywords + "%"));
            }
            string fieldList = "[Cheque_Outing].*,(select [ProjectName] from [Cheque_Project] where [ID]=[Cheque_Outing].[ProjectID]) as [ProjectName],(select [DepartmentName] from [Cheque_Department] where [ID]=[Cheque_Outing].[DepartmentID]) as [DepartmentName]";
            string Statement = " from [Cheque_Outing] where  " + string.Join(" and ", conditions.ToArray());
            Cheque_OutingDetail[] list = GetList<Cheque_OutingDetail>(fieldList, Statement, parameters, orderBy, startRowIndex, pageSize, out totalRows).ToArray();
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
        public static Cheque_OutingDetail[] GetCheque_OutingDetailListByKeywords(string keywords)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (!string.IsNullOrEmpty(keywords))
            {
                conditions.Add("([Operator] like @keywords or [Remark] like @keywords or [ProjectID] in (select [ID] from [Cheque_Project] where [ProjectName] like @keywords))");
                parameters.Add(new SqlParameter("@keywords", "%" + keywords + "%"));
            }
            string fieldList = "select [Cheque_Outing].*,(select [ProjectName] from [Cheque_Project] where [ID]=[Cheque_Outing].[ProjectID]) as [ProjectName],(select [DepartmentName] from [Cheque_Department] where [ID]=[Cheque_Outing].[DepartmentID]) as [DepartmentName] from [Cheque_Outing] where  " + string.Join(" and ", conditions.ToArray());
            Cheque_OutingDetail[] list = GetList<Cheque_OutingDetail>(fieldList, parameters).ToArray();
            return list;
        }
    }
}
