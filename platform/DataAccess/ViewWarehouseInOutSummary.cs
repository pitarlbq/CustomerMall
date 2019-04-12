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
    /// This object represents the properties and methods of a ViewWarehouseInOutSummary.
    /// </summary>
    public partial class ViewWarehouseInOutSummary : EntityBaseReadOnly
    {
        public static Ui.DataGrid GetViewWarehouseInOutSummaryByKeywords(int BusinessID, int CarrierGroupID, int ProductID, int SpecInfoID, int InventoryInfoID, int CarrierID, DateTime StartTime, DateTime EndTime, DateTime OutStartTime, DateTime OutEndTime, string orderBy, long startRowIndex, int pageSize)
        {
            long totalRows = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (OutStartTime > DateTime.MinValue)
            {
                conditions.Add("([OutTime]>=@OutStartTime or [ID] in (select [RelateID] from [WarehouseInOut] where [OutTime]>=@OutStartTime and [InOutType]=2))");
                parameters.Add(new SqlParameter("@OutStartTime", OutStartTime));
            }
            if (OutEndTime > DateTime.MinValue)
            {
                conditions.Add("([OutTime]<=@OutEndTime or [ID] in (select [RelateID] from [WarehouseInOut] where [OutTime]<=@OutEndTime and [InOutType]=2))");
                parameters.Add(new SqlParameter("@OutEndTime", OutEndTime));
            }
            if (StartTime > DateTime.MinValue)
            {
                conditions.Add("([StartTime]>=@StartTime or [ID] in (select [ID] from [WarehouseInOut] where [StartTime]>=@StartTime and [InOutType]=1))");
                parameters.Add(new SqlParameter("@StartTime", StartTime));
            }
            if (EndTime > DateTime.MinValue)
            {
                conditions.Add("([StartTime]<=@EndTime or [ID] in (select [ID] from [WarehouseInOut] where [StartTime]<=@EndTime and [InOutType]=1))");
                parameters.Add(new SqlParameter("@EndTime", EndTime));
            }
            if (BusinessID > 0)
            {
                conditions.Add("[BusinessID]=@BusinessID");
                parameters.Add(new SqlParameter("@BusinessID", BusinessID));
            }
            if (CarrierGroupID > 0)
            {
                conditions.Add("[CarrierID] in (select [CarrierID] from [Carrier_Group] where GroupID=@CarrierGroupID)");
                parameters.Add(new SqlParameter("@CarrierGroupID", CarrierGroupID));
            }
            if (ProductID > 0)
            {
                conditions.Add("[ProductID]=@ProductID");
                parameters.Add(new SqlParameter("@ProductID", ProductID));
            }
            if (SpecInfoID > 0)
            {
                conditions.Add("[SpecInfoID]=@SpecInfoID");
                parameters.Add(new SqlParameter("@SpecInfoID", SpecInfoID));
            }
            if (InventoryInfoID > 0)
            {
                conditions.Add("[InventoryInfoID]=@InventoryInfoID");
                parameters.Add(new SqlParameter("@InventoryInfoID", InventoryInfoID));
            }
            if (CarrierID > 0)
            {
                conditions.Add("[CarrierID]=@CarrierID");
                parameters.Add(new SqlParameter("@CarrierID", CarrierID));
            }
            string fieldList = "[ViewWarehouseInOutSummary].* ";
            string Statement = " from [ViewWarehouseInOutSummary] where  " + string.Join(" and ", conditions.ToArray());
            ViewWarehouseInOutSummary[] list = new ViewWarehouseInOutSummary[] { };
            list = GetList<ViewWarehouseInOutSummary>(fieldList, Statement, parameters, orderBy, startRowIndex, pageSize, out totalRows).ToArray();
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
        public static ViewWarehouseInOutSummary[] GetViewWarehouseInOutSummaryFooterByKeywords(int BusinessID, int CarrierGroupID, int ProductID, int SpecInfoID, int InventoryInfoID, int CarrierID, DateTime StartTime, DateTime EndTime, DateTime OutStartTime, DateTime OutEndTime, string orderBy, long startRowIndex, int pageSize)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (OutStartTime > DateTime.MinValue)
            {
                conditions.Add("([OutTime]>=@OutStartTime or [ID] in (select [RelateID] from [WarehouseInOut] where [OutTime]>=@OutStartTime and [InOutType]=2))");
                parameters.Add(new SqlParameter("@OutStartTime", OutStartTime));
            }
            if (OutEndTime > DateTime.MinValue)
            {
                conditions.Add("([OutTime]<=@OutEndTime or [ID] in (select [RelateID] from [WarehouseInOut] where [OutTime]<=@OutEndTime and [InOutType]=2))");
                parameters.Add(new SqlParameter("@OutEndTime", OutEndTime));
            }
            if (StartTime > DateTime.MinValue)
            {
                conditions.Add("([StartTime]>=@StartTime or [ID] in (select [ID] from [WarehouseInOut] where [StartTime]>=@StartTime and [InOutType]=1))");
                parameters.Add(new SqlParameter("@StartTime", StartTime));
            }
            if (EndTime > DateTime.MinValue)
            {
                conditions.Add("([StartTime]<=@EndTime or [ID] in (select [ID] from [WarehouseInOut] where [StartTime]<=@EndTime and [InOutType]=1))");
                parameters.Add(new SqlParameter("@EndTime", EndTime));
            }
            if (BusinessID > 0)
            {
                conditions.Add("[BusinessID]=@BusinessID");
                parameters.Add(new SqlParameter("@BusinessID", BusinessID));
            }
            if (CarrierGroupID > 0)
            {
                conditions.Add("[CarrierID] in (select [CarrierID] from [Carrier_Group] where GroupID=@CarrierGroupID)");
                parameters.Add(new SqlParameter("@CarrierGroupID", CarrierGroupID));
            }
            if (ProductID > 0)
            {
                conditions.Add("[ProductID]=@ProductID");
                parameters.Add(new SqlParameter("@ProductID", ProductID));
            }
            if (SpecInfoID > 0)
            {
                conditions.Add("[SpecInfoID]=@SpecInfoID");
                parameters.Add(new SqlParameter("@SpecInfoID", SpecInfoID));
            }
            if (InventoryInfoID > 0)
            {
                conditions.Add("[InventoryInfoID]=@InventoryInfoID");
                parameters.Add(new SqlParameter("@InventoryInfoID", InventoryInfoID));
            }
            if (CarrierID > 0)
            {
                conditions.Add("[CarrierID]=@CarrierID");
                parameters.Add(new SqlParameter("@CarrierID", CarrierID));
            }
            string cmdtext = @"select sum(InTotalCount) as InTotalCount,
sum([OutTotalCount]) as [OutTotalCount],
(sum(InTotalCount)-sum([OutTotalCount])) as Inventory,
'合计:' as OrderNumber
from ViewWarehouseInOutSummary where " + string.Join(" and ", conditions.ToArray());
            return GetList<ViewWarehouseInOutSummary>(cmdtext, parameters).ToArray();
        }
    }
}
