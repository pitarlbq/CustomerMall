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
    /// This object represents the properties and methods of a WarehouseInOut.
    /// </summary>
    public partial class WarehouseInOut : EntityBase
    {
        public static WarehouseInOut[] GetNextMonthToDO()
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("([IsToNext] is null or [IsToNext]=0)");
            conditions.Add("[Count]>0");
            conditions.Add("[InOutType]=1");
            conditions.Add("[EndTime]<@EndTime");
            parameters.Add(new SqlParameter("@EndTime", DateTime.Today));
            return GetList<WarehouseInOut>("select * from [WarehouseInOut] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
        public static WarehouseInOut[] GetWarehouseInOutListByIDs(int BusinessID, int ProductID, int SpecInfoID, int InventoryInfoID, int CarrierGroupID, int CarrierID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (BusinessID > 0)
            {
                conditions.Add("[BusinessID]=@BusinessID");
                parameters.Add(new SqlParameter("@BusinessID", BusinessID));
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
            if (CarrierGroupID > 0)
            {
                conditions.Add("[CarrierID] in (select [CarrierID] from [Carrier_Group] where [GroupID]=@CarrierID)");
                parameters.Add(new SqlParameter("@CarrierID", CarrierID));
            }
            return GetList<WarehouseInOut>("select * from [WarehouseInOut] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
        public static WarehouseInOut[] GetWarehouseInOutListByParentID(List<int> ParentIDList)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[RelateID] is not null");
            conditions.Add("[RelateID] in (" + string.Join(",", ParentIDList.ToArray()) + ")");
            return GetList<WarehouseInOut>("select * from [WarehouseInOut] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
        public static WarehouseInOut GetWarehouseInOutByOrderNumber(string OrderNumber)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[OrderNumber] like @OrderNumber");
            parameters.Add(new SqlParameter("@OrderNumber", "%" + OrderNumber + "%"));
            return GetOne<WarehouseInOut>("select top 1 * from [WarehouseInOut] where " + string.Join(" and ", conditions.ToArray())+" order by [ID] desc", parameters);
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
