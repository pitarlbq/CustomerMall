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
    /// This object represents the properties and methods of a ViewContractRoom.
    /// </summary>
    public partial class ViewContractRoom : EntityBaseReadOnly
    {
        public static ViewContractRoom[] GetViewContractRoomListByContractID(int ContractID, string guid)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (ContractID > 0)
            {
                conditions.Add("[ContractID]=@ContractID");
                parameters.Add(new SqlParameter("@ContractID", ContractID));
            }
            else if (!string.IsNullOrEmpty(guid))
            {
                conditions.Add("[GUID]=@GUID");
                parameters.Add(new SqlParameter("@GUID", guid));
            }
            ViewContractRoom[] list = GetList<ViewContractRoom>("select * from [ViewContractRoom] where  " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
            return list;
        }
        public static Ui.DataGrid GetViewContractRoomListByKeywords(int ContractID, string guid, string orderBy, long startRowIndex, int pageSize)
        {
            long totalRows = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (ContractID > 0)
            {
                conditions.Add("[ContractID]=@ContractID");
                parameters.Add(new SqlParameter("@ContractID", ContractID));
            }
            else if (!string.IsNullOrEmpty(guid))
            {
                conditions.Add("[guid]=@guid");
                parameters.Add(new SqlParameter("@guid", guid));
            }
            string fieldList = "[ViewContractRoom].*";
            string Statement = " from [ViewContractRoom] where  " + string.Join(" and ", conditions.ToArray());
            ViewContractRoom[] list = new ViewContractRoom[] { };
            list = GetList<ViewContractRoom>(fieldList, Statement, parameters, orderBy, startRowIndex, pageSize, out totalRows).ToArray();
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
    }
}
