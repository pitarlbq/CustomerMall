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
    /// This object represents the properties and methods of a ViewWarehouseInOut.
    /// </summary>
    public partial class ViewWarehouseInOut : EntityBaseReadOnly
    {
        public static Ui.DataGrid GetViewWarehouseInOutByKeywords(int InOutType, int BusinessChargeStatus, int CarrierChargeStatus, int BusinessID, int CarrierGroupID, int ProductID, int SpecInfoID, int InventoryInfoID, int CarrierID, DateTime StartTime, DateTime EndTime, DateTime OutStartTime, DateTime OutEndTime, DateTime BusinessBalanceStartTime, DateTime BusinessBalanceEndTime, DateTime CarrierBalanceStartTime, DateTime CarrierBalanceEndTime, bool IncludeIsNextOrder, bool HaveInventory, int IsPrint, bool ShowCarrierFee, string orderBy, long startRowIndex, int pageSize)
        {
            long totalRows = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (ShowCarrierFee)
            {
                conditions.Add("(isnull([ColdCost],0)>0 or isnull([MoveCost],0)>0)");
            }
            if (IsPrint > int.MinValue)
            {
                if (IsPrint == 0)
                {
                    conditions.Add("isnull([PrintCount],0)=0");
                }
                else if (IsPrint == 1)
                {
                    conditions.Add("isnull([PrintCount],0)>0");
                }
            }
            if (HaveInventory)
            {
                conditions.Add("[Count]>0");
            }
            if (!IncludeIsNextOrder)
            {
                conditions.Add("([IsNextOrder] is null or [IsNextOrder]=0)");
            }
            if (CarrierBalanceStartTime > DateTime.MinValue)
            {
                conditions.Add("[CarrierBalanceTime]>=@CarrierBalanceStartTime");
                parameters.Add(new SqlParameter("@CarrierBalanceStartTime", CarrierBalanceStartTime));
            }
            if (CarrierBalanceEndTime > DateTime.MinValue)
            {
                conditions.Add("[CarrierBalanceTime]<=@CarrierBalanceEndTime");
                parameters.Add(new SqlParameter("@CarrierBalanceEndTime", CarrierBalanceEndTime));
            }
            if (BusinessBalanceStartTime > DateTime.MinValue)
            {
                conditions.Add("[BalanceTime]>=@BusinessBalanceStartTime");
                parameters.Add(new SqlParameter("@BusinessBalanceStartTime", BusinessBalanceStartTime));
            }
            if (BusinessBalanceEndTime > DateTime.MinValue)
            {
                conditions.Add("[BalanceTime]<=@BusinessBalanceEndTime");
                parameters.Add(new SqlParameter("@BusinessBalanceEndTime", BusinessBalanceEndTime));
            }
            if (OutStartTime > DateTime.MinValue)
            {
                conditions.Add("[OutTime]>=@OutStartTime");
                parameters.Add(new SqlParameter("@OutStartTime", OutStartTime));
            }
            if (OutEndTime > DateTime.MinValue)
            {
                conditions.Add("[OutTime]<=@OutEndTime");
                parameters.Add(new SqlParameter("@OutEndTime", OutEndTime));
            }
            if (StartTime > DateTime.MinValue)
            {
                conditions.Add("[StartTime]>=@StartTime");
                parameters.Add(new SqlParameter("@StartTime", StartTime));
            }
            if (EndTime > DateTime.MinValue)
            {
                conditions.Add("[StartTime]<=@EndTime");
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
            if (InOutType > 0)
            {
                conditions.Add("[InOutType]=@InOutType");
                parameters.Add(new SqlParameter("@InOutType", InOutType));
            }
            if (BusinessChargeStatus == 1)
            {
                conditions.Add("[BusinessChargeStatus]=@BusinessChargeStatus");
                parameters.Add(new SqlParameter("@BusinessChargeStatus", BusinessChargeStatus));
            }
            else if (BusinessChargeStatus == 0)
            {
                conditions.Add("([BusinessChargeStatus] is null or [BusinessChargeStatus]=0)");
            }
            if (CarrierChargeStatus == 1)
            {
                conditions.Add("[CarrierChargeStatus]=@CarrierChargeStatus");
                parameters.Add(new SqlParameter("@CarrierChargeStatus", CarrierChargeStatus));
            }
            else if (CarrierChargeStatus == 0)
            {
                conditions.Add("([CarrierChargeStatus] is null or [CarrierChargeStatus]=0)");
            }
            string fieldList = "[ViewWarehouseInOut].* ";
            string Statement = " from [ViewWarehouseInOut] where  " + string.Join(" and ", conditions.ToArray());
            ViewWarehouseInOut[] list = new ViewWarehouseInOut[] { };
            list = GetList<ViewWarehouseInOut>(fieldList, Statement, parameters, orderBy, startRowIndex, pageSize, out totalRows).ToArray();
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
        public static ViewWarehouseInOut[] GetViewWarehouseInOutSummaryByKeywords(int InOutType, int BusinessChargeStatus, int CarrierChargeStatus, int BusinessID, int CarrierGroupID, int ProductID, int SpecInfoID, int InventoryInfoID, int CarrierID, DateTime StartTime, DateTime EndTime, DateTime OutStartTime, DateTime OutEndTime, DateTime BusinessBalanceStartTime, DateTime BusinessBalanceEndTime, DateTime CarrierBalanceStartTime, DateTime CarrierBalanceEndTime, bool IncludeIsNextOrder, bool HaveInventory)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (HaveInventory)
            {
                conditions.Add("[Count]>0");
            }
            if (!IncludeIsNextOrder)
            {
                conditions.Add("([IsNextOrder] is null or [IsNextOrder]=0)");
            }
            if (CarrierBalanceStartTime > DateTime.MinValue)
            {
                conditions.Add("[CarrierBalanceTime]>=@CarrierBalanceStartTime");
                parameters.Add(new SqlParameter("@CarrierBalanceStartTime", CarrierBalanceStartTime));
            }
            if (CarrierBalanceEndTime > DateTime.MinValue)
            {
                conditions.Add("[CarrierBalanceTime]<=@CarrierBalanceEndTime");
                parameters.Add(new SqlParameter("@CarrierBalanceEndTime", CarrierBalanceEndTime));
            }
            if (BusinessBalanceStartTime > DateTime.MinValue)
            {
                conditions.Add("[BalanceTime]>=@BusinessBalanceStartTime");
                parameters.Add(new SqlParameter("@BusinessBalanceStartTime", BusinessBalanceStartTime));
            }
            if (BusinessBalanceEndTime > DateTime.MinValue)
            {
                conditions.Add("[BalanceTime]<=@BusinessBalanceEndTime");
                parameters.Add(new SqlParameter("@BusinessBalanceEndTime", BusinessBalanceEndTime));
            }
            if (OutStartTime > DateTime.MinValue)
            {
                conditions.Add("[OutTime]>=@OutStartTime");
                parameters.Add(new SqlParameter("@OutStartTime", OutStartTime));
            }
            if (OutEndTime > DateTime.MinValue)
            {
                conditions.Add("[OutTime]<=@OutEndTime");
                parameters.Add(new SqlParameter("@OutEndTime", OutEndTime));
            }
            if (StartTime > DateTime.MinValue)
            {
                conditions.Add("[StartTime]>=@StartTime");
                parameters.Add(new SqlParameter("@StartTime", StartTime));
            }
            if (EndTime > DateTime.MinValue)
            {
                conditions.Add("[StartTime]<=@EndTime");
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
            if (InOutType > 0)
            {
                conditions.Add("[InOutType]=@InOutType");
                parameters.Add(new SqlParameter("@InOutType", InOutType));
            }
            if (BusinessChargeStatus == 1)
            {
                conditions.Add("[BusinessChargeStatus]=@BusinessChargeStatus");
                parameters.Add(new SqlParameter("@BusinessChargeStatus", BusinessChargeStatus));
            }
            else if (BusinessChargeStatus == 0)
            {
                conditions.Add("([BusinessChargeStatus] is null or [BusinessChargeStatus]=0)");
            }
            if (CarrierChargeStatus == 1)
            {
                conditions.Add("[CarrierChargeStatus]=@CarrierChargeStatus");
                parameters.Add(new SqlParameter("@CarrierChargeStatus", CarrierChargeStatus));
            }
            else if (CarrierChargeStatus == 0)
            {
                conditions.Add("([CarrierChargeStatus] is null or [CarrierChargeStatus]=0)");
            }
            string cmdtext = @"select sum(TotalCount) as TotalCount,
sum([Count]) as [Count],
sum(isnull(ColdCost,0)) as ColdCost,
sum(isnull(MoveCost,0)) as MoveCost, 
sum(isnull(CarrierMoveCost,0)) as CarrierMoveCost,
sum(isnull(TotalCost,0)) as TotalCost,
sum(isnull(RealCost,0)) as RealCost,
sum(isnull(DiscountCost,0)) as DiscountCost,
sum(isnull(RemoveCost,0)) as RemoveCost,
sum(isnull(CarrierBalanceCost,0)) as CarrierBalanceCost,
sum(isnull(MovePrice,0)) as MovePrice,
sum(isnull(ColdPrice,0)) as ColdPrice,
'合计:' as OrderNumber
from ViewWarehouseInOut where " + string.Join(" and ", conditions.ToArray());
            return GetList<ViewWarehouseInOut>(cmdtext, parameters).ToArray();
        }
        public static EntityList<ViewWarehouseInOut> GetViewWarehouseInOutListByIDList(List<int> IDList)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (IDList.Count > 0)
            {
                conditions.Add("[ID] in (" + string.Join(",", IDList.ToArray()) + ")");
            }
            return GetList<ViewWarehouseInOut>("select * from [ViewWarehouseInOut] where " + string.Join(" and ", conditions.ToArray()), parameters);
        }
        public static ViewWarehouseInOut[] GetViewWarehouseInOutSummaryByIDList(List<int> IDList)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (IDList.Count > 0)
            {
                conditions.Add("[ID] in (" + string.Join(",", IDList.ToArray()) + ")");
            }
            string cmdtext = @"select sum(TotalCount) as TotalCount,
sum([Count]) as [Count],
sum(isnull(ColdCost,0)) as ColdCost,
sum(isnull(MoveCost,0)) as MoveCost, 
sum(isnull(CarrierMoveCost,0)) as CarrierMoveCost,
sum(isnull(TotalCost,0)) as TotalCost,
sum(isnull(RealCost,0)) as RealCost,
sum(isnull(DiscountCost,0)) as DiscountCost,
sum(isnull(RemoveCost,0)) as RemoveCost,
sum(isnull(CarrierBalanceCost,0)) as CarrierBalanceCost,
sum(isnull(MovePrice,0)) as MovePrice,
sum(isnull(ColdPrice,0)) as ColdPrice,
'合计:' as OrderNumber
from ViewWarehouseInOut where " + string.Join(" and ", conditions.ToArray());
            return GetList<ViewWarehouseInOut>(cmdtext, parameters).ToArray();
        }
        public string BusinessChargeStatusDesc
        {
            get
            {
                if (this.ID == int.MinValue)
                {
                    return "";
                }
                if (this.BusinessChargeStatus)
                {
                    return "结算";
                }
                return "欠费";
            }
        }
        public string CarrierChargeStatusDesc
        {
            get
            {
                if (this.ID == int.MinValue)
                {
                    return "";
                }
                if (this.CarrierChargeStatus)
                {
                    return "结算";
                }
                return "欠费";
            }
        }
        public DateTime NewEndTime
        {
            get
            {
                return this.EndTime < DateTime.Now ? DateTime.Now : this.EndTime;
            }
        }
        public int UseDays
        {
            get
            {
                TimeSpan ts = this.NewEndTime - this.StartTime;
                return Convert.ToInt32(ts.TotalDays);
            }
        }
        public string InOutTypeDesc
        {
            get
            {
                string typedesc = string.Empty;
                switch (this.InOutType)
                {
                    case 1:
                        typedesc = "入库";
                        break;
                    case 2:
                        typedesc = "出库";
                        break;
                    default:
                        break;
                }
                return typedesc;
            }
        }
    }
}
