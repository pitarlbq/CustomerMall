using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Linq;
using Foresight.DataAccess.Framework;
using Utility;

namespace Foresight.DataAccess
{
    /// <summary>
    /// This object represents the properties and methods of a Mall_PointRule.
    /// </summary>
    public partial class Mall_PointRule : EntityBase
    {
        public bool FinalIsActive
        {
            get
            {
                if (this.RuleStatus == 0)
                {
                    return false;
                }
                if (this.StartTime > DateTime.Now)
                {
                    return false;
                }
                if (this.EndTime < DateTime.Now && this.EndTime > DateTime.MinValue)
                {
                    return false;
                }
                return true;
            }
        }
        public string IsActiveDesc
        {
            get
            {
                return this.FinalIsActive ? "有效" : "失效";
            }
        }
        public string ActiveTimeRangeDesc
        {
            get
            {
                string desc = "";
                if (this.StartTime > DateTime.MinValue)
                {
                    desc += this.StartTime.ToString("yyyy-MM-dd");
                }
                else
                {
                    desc += "--";
                }
                desc += " 至 ";
                if (this.EndTime > DateTime.MinValue)
                {
                    desc += this.EndTime.ToString("yyyy-MM-dd");
                }
                else
                {
                    desc += "--";
                }
                return desc;
            }
        }
        public string UseForALLDesc
        {
            get
            {
                return this.IsUseForAllProduct ? "所有商品" : "限制商品";
            }
        }
        public static Ui.DataGrid GetMall_PointRuleGridByKeywords(string keywords, long startRowIndex, int pageSize)
        {
            long totalRows = 0;
            string OrderBy = " order by AddTime desc";
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (!string.IsNullOrEmpty(keywords))
            {
                conditions.Add("([RuleName] like @keywords)");
                parameters.Add(new SqlParameter("@keywords", "%" + keywords + "%"));
            }
            string fieldList = "[Mall_PointRule].*";
            string Statement = " from [Mall_PointRule] where  " + string.Join(" and ", conditions.ToArray());
            Mall_PointRule[] list = GetList<Mall_PointRule>(fieldList, Statement, parameters, OrderBy, startRowIndex, pageSize, out totalRows).ToArray();
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
        public static Mall_PointRule GetMall_PointRuleByOrderID(int OrderID)
        {
            if (OrderID <= 0)
            {
                return null;
            }
            var list = Mall_PointRule.GetMall_PointRules().Where(p => p.FinalIsActive && p.RuleType == 1).OrderByDescending(p => p.AddTime).ToArray();
            if (list.Length == 0)
            {
                return null;
            }
            var data = list.FirstOrDefault(p => p.IsUseForAllProduct);
            if (data != null)
            {
                return data;
            }
            var orderitem_list = Foresight.DataAccess.Mall_OrderItem.GetMall_OrderItemListByOrderID(OrderID);
            if (orderitem_list.Length == 0)
            {
                return null;
            }
            var orderitem_productid_list = orderitem_list.Select(p => p.ProductID).ToList();
            foreach (var item in list)
            {
                if (string.IsNullOrEmpty(item.ProductIDRange))
                {
                    continue;
                }
                List<int> ProductIDList = JsonConvert.DeserializeObject<List<int>>(item.ProductIDRange);
                if (ProductIDList.Count == 0)
                {
                    continue;
                }
                var jiaoJi = orderitem_productid_list.Intersect(ProductIDList).ToList();
                if (jiaoJi.Count == 0)
                {
                    continue;
                }
                data = item;
                break;
            }
            return data;
        }
    }
}
