using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Linq;
using Foresight.DataAccess.Framework;

namespace Foresight.DataAccess
{
    /// <summary>
    /// This object represents the properties and methods of a Mall_UserPointRule.
    /// </summary>
    public partial class Mall_UserPointRule : EntityBase
    {
        public string IsActiveDesc
        {
            get
            {
                return this.IsActive ? "是" : "否";
            }
        }
        public string PointRange
        {
            get
            {
                return this.StartPoint.ToString("0") + " - " + this.EndPoint.ToString("0");
            }
        }
        public string PointTypeDesc
        {
            get
            {
                if (this.PointType == 1)
                {
                    return "固定积分";
                }
                return "按比例";
            }
        }
        public string ConvertValueDesc
        {
            get
            {
                return PointRange + "积分之间" + PointTypeDesc + "转换" + this.PointValueDesc;
            }
        }
        public string PointValueDesc
        {
            get
            {
                if (this.PointType == 1)
                {
                    return this.PointValue.ToString() + "积分";
                }
                return this.PointValue.ToString() + "%";
            }
        }
        public static Ui.DataGrid GetMall_UserPointRuleGridList(string keywords, long startRowIndex, int pageSize)
        {
            long totalRows = 0;
            string OrderBy = " order by StartPoint asc";
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (!string.IsNullOrEmpty(keywords))
            {
                conditions.Add("([Remark] like @keywords)");
                parameters.Add(new SqlParameter("@keywords", "%" + keywords + "%"));
            }
            string fieldList = "Mall_UserPointRule.*";
            string Statement = " from [Mall_UserPointRule] where  " + string.Join(" and ", conditions.ToArray());
            Mall_UserPointRule[] list = GetList<Mall_UserPointRule>(fieldList, Statement, parameters, OrderBy, startRowIndex, pageSize, out totalRows).ToArray();
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
        public static decimal GetCheckPointValueByPoint(decimal point, out Mall_UserPointRule data)
        {
            data = null;
            var list = Mall_UserPointRule.GetMall_UserPointRules().Where(p => p.IsActive).OrderBy(p => p.StartPoint).ToArray();
            if (list.Length == 0)
            {
                return 0;
            }
            data = list.FirstOrDefault(p => p.StartPoint <= point && p.EndPoint > point);
            if (data == null)
            {
                data = list[list.Length - 1];
            }
            if (data == null)
            {
                return 0;
            }
            if (data.PointType == 1)
            {
                return Math.Round(data.PointValue, 0, MidpointRounding.AwayFromZero);
            }
            if (data.PointType == 2)
            {
                return Math.Round((point * data.PointValue) / 100, 0, MidpointRounding.AwayFromZero);
            }
            return 0;
        }
    }
}
