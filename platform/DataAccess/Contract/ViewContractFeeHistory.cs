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
    /// This object represents the properties and methods of a ViewContractFeeHistory.
    /// </summary>
    public partial class ViewContractFeeHistory : EntityBaseReadOnly
    {
        public static ViewContractFeeHistory[] GetViewContractFeeHistoryListByIDs(int RoomID, List<int> IDs, int PrintID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            if (RoomID > 0)
            {
                conditions.Add("[RoomID]=@RoomID");
                parameters.Add(new SqlParameter("@RoomID", RoomID));
            }
            if (IDs.Count > 0)
            {
                conditions.Add("[HistoryID] in (" + string.Join(",", IDs.ToArray()) + ")");
            }
            if (PrintID > 0)
            {
                conditions.Add("[PrintID]=@PrintID");
                parameters.Add(new SqlParameter("@PrintID", PrintID));
            }
            ViewContractFeeHistory[] list = new ViewContractFeeHistory[] { };
            list = GetList<ViewContractFeeHistory>("select * from [ViewContractFeeHistory] where  " + string.Join(" and ", conditions.ToArray()) + " order by [ChargeTime] desc", parameters).ToArray();
            return list;
        }
        public static Ui.DataGrid GetViewContractFeeHistoryGridByContractID(List<int> ContractIDList, bool IncludIsCharged, string orderBy, long startRowIndex, int pageSize)
        {
            long totalRows = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (ContractIDList.Count > 0)
            {
                conditions.Add("[ContractID] in (" + string.Join(",", ContractIDList.ToArray()) + ")");
            }
            if (IncludIsCharged)
            {
                conditions.Add("[ChargeState] in (1,4)");
            }
            string fieldList = "[ViewContractFeeHistory].* ";
            string Statement = " from [ViewContractFeeHistory] where  " + string.Join(" and ", conditions.ToArray());
            ViewContractFeeHistory[] list = new ViewContractFeeHistory[] { };
            list = GetList<ViewContractFeeHistory>(fieldList, Statement, parameters, orderBy, startRowIndex, pageSize, out totalRows).ToArray();
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
    }
}
