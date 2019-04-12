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
    /// This object represents the properties and methods of a Mall_ShipRate.
    /// </summary>
    public partial class Mall_ShipRate : EntityBase
    {
        public static Mall_ShipRate[] GetMall_ShipRateListByIDList(List<int> IDList)
        {
            if (IDList.Count == 0)
            {
                return new Mall_ShipRate[] { };
            }
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();

            conditions.Add("[ID] in (" + string.Join(",", IDList.ToArray()) + ")");
            string cmdtext = "select * from [Mall_ShipRate] where  " + string.Join(" and ", conditions.ToArray());
            return GetList<Mall_ShipRate>(cmdtext, parameters).ToArray();
        }
        public static Mall_ShipRate GetDefaultMall_ShipRate()
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[IsDefault]=1");
            string cmdtext = "select * from [Mall_ShipRate] where  " + string.Join(" and ", conditions.ToArray());
            return GetOne<Mall_ShipRate>(cmdtext, parameters);
        }
        public string RateTypeDesc
        {
            get
            {
                if (this.RateType == 1)
                {
                    return "快递";
                }
                if (this.RateType == 2)
                {
                    return "自提";
                }
                return "";
            }
        }
        public string IsDefaultDesc
        {
            get
            {
                return this.IsDefault ? "是" : "否";
            }
        }
    }
    public partial class Mall_ShipRateAdditonal : Mall_ShipRate
    {
        [DatabaseColumn("UseProductCount")]
        public int UseProductCount { get; set; }
        public static Ui.DataGrid GetMall_ShipRateAdditonalGridByKeywords(string keywords, long startRowIndex, int pageSize)
        {
            long totalRows = 0;
            string OrderBy = " order by [AddTime] desc";
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (!string.IsNullOrEmpty(keywords))
            {
                conditions.Add("([RateTile] like @keywords)");
                parameters.Add(new SqlParameter("@keywords", "%" + keywords + "%"));
            }
            string fieldList = "A.*";
            string Statement = " from (select *,(select count(1) from [Mall_Product] where [ShipRateID]=[Mall_ShipRate].ID) as UseProductCount from [Mall_ShipRate])A where  " + string.Join(" and ", conditions.ToArray());
            Mall_ShipRateAdditonal[] list = GetList<Mall_ShipRateAdditonal>(fieldList, Statement, parameters, OrderBy, startRowIndex, pageSize, out totalRows).ToArray();
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
    }
}
