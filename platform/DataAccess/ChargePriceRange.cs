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
    /// This object represents the properties and methods of a ChargePriceRange.
    /// </summary>
    public partial class ChargePriceRange : EntityBase
    {
        public string BaseTypeDesc
        {
            get
            {
                if (string.IsNullOrEmpty(this.BaseType))
                {
                    return string.Empty;
                }
                return Utility.EnumHelper.GetDescription(typeof(Utility.EnumModel.PriceRangeType), this.BaseType);
            }
        }
        public static ChargePriceRange[] GetChargePriceRangeList(string orderby = "order by Convert(decimal(18,2), [MinValue]) asc")
        {
            return GetChargePriceRangeListBySummaryID(int.MinValue, orderby: orderby);
        }
        public static ChargePriceRange[] GetChargePriceRangeListBySummaryID(int SummaryID)
        {
            return GetChargePriceRangeListBySummaryID(SummaryID, string.Empty);
        }
        public static ChargePriceRange[] GetChargePriceRangeListBySummaryID(int SummaryID, string orderby = "order by Convert(decimal(18,2), [MinValue]) asc")
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            if (SummaryID > 0)
            {
                conditions.Add("[SummaryID]=@SummaryID");
                parameters.Add(new SqlParameter("@SummaryID", SummaryID));
            }
            conditions.Add("[IsActive]=1");
            ChargePriceRange[] list = GetList<ChargePriceRange>("select * from [ChargePriceRange] where " + string.Join(" and ", conditions.ToArray()) + " " + orderby, parameters).ToArray();
            return list;
        }
        public static Ui.DataGrid GetChargePriceRangeGridBySummaryID(int SummaryID, string orderBy, long startRowIndex, int pageSize)
        {
            long totalRows = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[SummaryID]=@SummaryID");
            parameters.Add(new SqlParameter("@SummaryID", SummaryID));
            string fieldList = "[ChargePriceRange].* ";
            string Statement = " from [ChargePriceRange] where  " + string.Join(" and ", conditions.ToArray());
            ChargePriceRange[] list = new ChargePriceRange[] { };
            list = GetList<ChargePriceRange>(fieldList, Statement, parameters, orderBy, startRowIndex, pageSize, out totalRows).ToArray();
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
        public string IsActiveDesc
        {
            get
            {
                string desc = this.IsActive ? "生效" : "失效";
                return desc;
            }
        }
        public string MaxValueDesc
        {
            get
            {
                string desc = string.Empty;
                decimal max = 0;
                decimal.TryParse(this.MaxValue, out max);
                desc = max == decimal.MaxValue ? "无上限" : max.ToString();
                return desc;
            }
        }
    }
}
