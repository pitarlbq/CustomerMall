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
    /// This object represents the properties and methods of a Mall_HotSale.
    /// </summary>
    public partial class Mall_HotSale : EntityBase
    {
        public bool Is_Valid
        {
            get
            {
                if (this.StartTime == DateTime.MinValue && this.EndTime == DateTime.MinValue)
                {
                    return true;
                }
                if (this.StartTime == DateTime.MinValue)
                {
                    if (this.EndTime >= DateTime.Now)
                    {
                        return true;
                    }
                    return false;
                }
                if (this.EndTime == DateTime.MinValue)
                {
                    if (this.StartTime <= DateTime.Now)
                    {
                        return true;
                    }
                    return false;
                }
                if (this.StartTime <= DateTime.Now && this.EndTime >= DateTime.Now)
                {
                    return true;
                }
                return false;
            }
        }
        public string TypeDesc
        {
            get
            {
                if (this.Type == 1)
                {
                    return "商品";
                }
                if (this.Type == 2)
                {
                    return "商家";
                }
                return string.Empty;
            }
        }
    }
    public partial class Mall_HotSaleDetail : Mall_HotSale
    {
        public string RelatedName
        {
            get
            {
                if (this.Type == 1)
                {
                    return this.ProductName;
                }
                if (this.Type == 2)
                {
                    return this.BusinessName;
                }
                return string.Empty;
            }
        }
        [DatabaseColumn("ProductName")]
        public string ProductName { get; set; }
        [DatabaseColumn("BusinessName")]
        public string BusinessName { get; set; }
        public static Ui.DataGrid GetMall_HotSaleDetailGridByKeywords(string keywords, long startRowIndex, int pageSize)
        {
            long totalRows = 0;
            string OrderBy = " order by [SortOrder] asc, [AddTime] desc";
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (!string.IsNullOrEmpty(keywords))
            {
                conditions.Add("([ProductName] like @keywords or [BusinessName] like @keywords)");
                parameters.Add(new SqlParameter("@keywords", "%" + keywords + "%"));
            }
            string fieldList = "A.*";
            string Statement = " from (select *,(case when [Type]=1 then (select ProductName from [Mall_Product] where [ID]=[Mall_HotSale].RelatedID) else '' end) as ProductName,(case when [Type]=2 then (select BusinessName from [Mall_Business] where [ID]=[Mall_HotSale].RelatedID) else '' end) as BusinessName from [Mall_HotSale])A where  " + string.Join(" and ", conditions.ToArray());
            Mall_HotSaleDetail[] list = GetList<Mall_HotSaleDetail>(fieldList, Statement, parameters, OrderBy, startRowIndex, pageSize, out totalRows).ToArray();
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
        public static List<Dictionary<string, object>> GetMall_HotSaleList()
        {
            string context_path = Utility.Tools.GetContextPath();
            List<Dictionary<string, object>> results = new List<Dictionary<string, object>>();
            var list = Mall_HotSale.GetMall_HotSales().Where(p => p.Is_Valid).OrderBy(p => p.SortOrder).ToArray();
            if (list.Length == 0)
            {
                return results;
            }
            var list_product_ids = list.Where(p => p.Type == 1).Select(p => p.RelatedID).ToList();
            var list_business_ids = list.Where(p => p.Type == 2).Select(p => p.RelatedID).ToList();
            Mall_ProductDetail[] product_list = new Mall_ProductDetail[] { };
            Mall_Business[] business_list = new Mall_Business[] { };
            if (list_product_ids.Count > 0)
            {
                product_list = Mall_ProductDetail.GetMall_ProductDetailListByIDList(list_product_ids).Where(p => p.IsAllowProductBuy).ToArray();
            }
            if (list_business_ids.Count > 0)
            {
                business_list = Mall_Business.GetMall_BusinessListByIDList(list_business_ids);
            }
            foreach (var item in list)
            {
                Dictionary<string, object> dic = new Dictionary<string, object>();
                dic["id"] = item.ID;
                dic["type"] = item.Type;
                dic["RelatedID"] = item.RelatedID > 0 ? item.RelatedID : 0;
                if (item.Type == 1)
                {
                    var my_data = product_list.FirstOrDefault(p => p.ID == item.RelatedID);
                    if (my_data == null)
                    {
                        continue;
                    }
                    dic["imageurl"] = !string.IsNullOrEmpty(my_data.CoverImage) ? context_path + my_data.CoverImage : "";
                    dic["title"] = my_data.ProductName;
                    dic["pricevalue"] = my_data.FinalVariantPrice;
                    dic["price"] = my_data.NormalPriceDesc.ToString();
                    dic["addtime"] = my_data.AddTime.ToString("yyyy-MM-dd HH:mm:ss");
                    dic["salecount"] = my_data.SaleCount;
                }
                else if (item.Type == 2)
                {
                    var my_data = business_list.FirstOrDefault(p => p.ID == item.RelatedID);
                    if (my_data == null)
                    {
                        continue;
                    }
                    dic["imageurl"] = !string.IsNullOrEmpty(my_data.CoverImage) ? context_path + my_data.CoverImage : "";
                    dic["title"] = my_data.BusinessName;
                    dic["pricevalue"] = 0;
                    dic["price"] = "￥0.00";
                    dic["addtime"] = my_data.AddTime.ToString("yyyy-MM-dd HH:mm:ss");
                    dic["salecount"] = 0;
                }
                dic["SortOrder"] = item.SortOrder > int.MinValue ? item.SortOrder : int.MaxValue;
                results.Add(dic);
            }
            results = results.OrderBy(p => Convert.ToInt32(p["SortOrder"])).ToList();
            return results;
        }
        public static List<Dictionary<string, object>> GetMall_HotSaleListByKeywords(string keywords, int sortby, long startRowIndex, int pageSize)
        {
            List<Dictionary<string, object>> results = GetMall_HotSaleList();
            if (!string.IsNullOrEmpty(keywords))
            {
                results = results.Where(p => p["title"].ToString().Contains(keywords)).ToList();
            }
            if (sortby == 1)
            {
                results = results.OrderByDescending(p => Convert.ToDateTime(p["addtime"].ToString())).ToList();
            }
            else if (sortby == 2)
            {
                results = results.OrderByDescending(p => Convert.ToInt32(p["salecount"].ToString())).ToList();
            }
            else if (sortby == 3)
            {
                results = results.OrderByDescending(p => Convert.ToDecimal(p["pricevalue"].ToString())).ToList();
            }
            else if (sortby == 4)
            {
                results = results.OrderBy(p => Convert.ToDecimal(p["pricevalue"].ToString())).ToList();
            }
            else if (sortby == 5)
            {
                results = results.OrderBy(p => Convert.ToInt32(p["SortOrder"].ToString())).ToList();
            }
            int StartRowIndex = Convert.ToInt32(startRowIndex);
            results = results.Skip(StartRowIndex).Take(pageSize).ToList();
            return results;
        }
    }
}
