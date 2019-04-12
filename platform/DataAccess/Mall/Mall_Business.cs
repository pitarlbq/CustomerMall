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
    /// This object represents the properties and methods of a Mall_Business.
    /// </summary>
    public partial class Mall_Business : EntityBase
    {
        public static Mall_Business GetMall_BusinessByProductID(int ProductID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            conditions.Add(" [Status]=1");
            if (ProductID <= 0)
            {
                return null;
            }
            conditions.Add("[ID] in (select [BusinessID] from [Mall_Product] where [ID]=@ProductID)");
            parameters.Add(new SqlParameter("@ProductID", ProductID));
            return GetOne<Mall_Business>("select * from [Mall_Business] where " + string.Join(" and ", conditions.ToArray()), parameters);
        }
        public static Mall_Business GetMall_BusinessByDeviceID(string DeviceID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            conditions.Add(" [Status]=1");
            if (string.IsNullOrEmpty(DeviceID))
            {
                return null;
            }
            conditions.Add("[DeviceID]=@DeviceID");
            parameters.Add(new SqlParameter("@DeviceID", DeviceID));
            return GetOne<Mall_Business>("select * from [Mall_Business] where " + string.Join(" and ", conditions.ToArray()), parameters);
        }
        public static Mall_Business GetMall_BusinessByUserID(int UserID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            if (UserID == 0)
            {
                return null;
            }
            conditions.Add("[UserID]=@UserID or [ID] in (select [BusinessID] from [Mall_BusinessUser] where [UserID]=@UserID)");
            parameters.Add(new SqlParameter("@UserID", UserID));
            return GetOne<Mall_Business>("select * from [Mall_Business] where " + string.Join(" and ", conditions.ToArray()), parameters);
        }
        public static Mall_Business[] GetMall_BusinessListByIDList(List<int> IDList)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (IDList.Count == 0)
            {
                return new Mall_Business[] { };
            }
            conditions.Add("[ID] in (" + string.Join(",", IDList) + ")");
            return GetList<Mall_Business>("select * from [Mall_Business] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
        public static Mall_Business[] GetMall_BusinessListByCouponID(int CouponID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("ID in (select [BusinessID] from [Mall_CouponProduct] where [CouponID]=@CouponID)");
            parameters.Add(new SqlParameter("@CouponID", CouponID));
            string Statement = @"select * from Mall_Business where " + string.Join(" and ", conditions);
            return GetList<Mall_Business>(Statement, parameters).ToArray();
        }
        public string StatusDesc
        {
            get
            {
                string desc = string.Empty;
                switch (this.Status)
                {
                    case 10:
                        desc = "待审核";
                        break;
                    case 1:
                        desc = "审核通过";
                        break;
                    case 2:
                        desc = "审核未通过";
                        break;
                    default:
                        break;
                }
                return desc;
            }
        }
    }
    public partial class Mall_BusinessDetail : Mall_Business
    {
        [DatabaseColumn("SaleCount")]
        public int SaleCount { get; set; }
        [DatabaseColumn("RateCount")]
        public int RateCount { get; set; }
        [DatabaseColumn("RateStar")]
        public decimal RateStar { get; set; }
        public decimal Distance
        {
            get
            {
                if (Lon == 0 && Lat == 0)
                {
                    return 0;
                }
                if (string.IsNullOrEmpty(this.MapLocation))
                {
                    return 0;
                }
                double lon1 = Lon;
                double lat1 = Lat;
                string[] locationlist = this.MapLocation.Split(',');
                double lon2 = 0;
                double lat2 = 0;
                double.TryParse(locationlist[0], out lon2);
                double.TryParse(locationlist[1], out lat2);
                decimal result = Utility.BaiDuHelper.GetDistance(lon1, lat1, lon2, lat2);
                if (result > 0)
                {
                    return Math.Round(result / 1000, 2, MidpointRounding.AwayFromZero);
                }
                return 0;
            }
        }
        public string DistanceDesc
        {
            get
            {
                return Distance.ToString("0.00") + "km";
            }
        }
        public decimal RateStarAvr
        {
            get
            {
                if (this.RateStar <= 0)
                {
                    return 0;
                }
                if (this.RateCount <= 0)
                {
                    return 0;
                }
                return Math.Round(this.RateStar / this.RateCount, 2, MidpointRounding.AwayFromZero);
            }
        }
        public string RateComment
        {
            get
            {
                return RateStarAvr.ToString() + "分 | " + (this.RateCount > 0 ? this.RateCount : 0).ToString() + "评论";
            }
        }
        public static Mall_BusinessDetail[] GetMall_BusinessDetailListByKeywords(string Keywords, int sortby, long startRowIndex, int pageSize, out long totalRows, int CategoryID = 0, double lon = 0, double lat = 0, int TagID = 0, bool issuggestion = false)
        {
            ResetParams();
            Lon = lon;
            Lat = lat;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (issuggestion)
            {
                conditions.Add("[IsSuggestion]=1");
            }
            conditions.Add(" [Status]=1");
            if (TagID > 0)
            {
                conditions.Add("[ID] in (select [BusinessID] from [Mall_Product] where [ID] in (select [ProductID] from [Mall_ProductTag] where [TagID]=@TagID))");
                parameters.Add(new SqlParameter("@TagID", TagID));
            }
            if (CategoryID > 0)
            {
                conditions.Add("[ID] in (select [BusinessID] from [Mall_Business_Category] where [CategoryID]=@CategoryID)");
                parameters.Add(new SqlParameter("@CategoryID", CategoryID));
            }
            if (!string.IsNullOrEmpty(Keywords))
            {
                conditions.Add("[BusinessName] like @Keywords");
                parameters.Add(new SqlParameter("@Keywords", "%" + Keywords + "%"));
            }
            string OrderBy = " order by isnull([IsTopShow],0) desc, [AddTime] desc";
            if (sortby == 1)
            {
                OrderBy = " order by isnull([IsTopShow],0) desc, A.SaleCount desc";
            }
            else if (sortby == 2)
            {
                OrderBy = " order by isnull([IsTopShow],0) desc, [AddTime] desc";
            }
            string fieldList = "A.*";
            string Statement = " from (select *,(select sum(Quantity) from [Mall_OrderItem] where [OrderID] in (select ID from [Mall_Order] where [OrderStatus]=3) and [BusinessID]=[Mall_Business].ID) as SaleCount,(select count(1) from [Mall_OrderComment] where [BusinessID]=[Mall_Business].ID) as RateCount,(select sum(RateStar) from [Mall_OrderComment] where [BusinessID]=[Mall_Business].ID) as RateStar from [Mall_Business])A where  " + string.Join(" and ", conditions.ToArray());
            var list = GetList<Mall_BusinessDetail>(fieldList, Statement, parameters, OrderBy, startRowIndex, pageSize, out totalRows).ToArray();
            if (sortby == 3)
            {
                list = list.OrderByDescending(p =>
                {
                    return p.IsTopShow ? 1 : 0;
                }).ThenBy(p =>
                {
                    if (p.Distance == 0)
                    {
                        return decimal.MaxValue;
                    }
                    return p.Distance;
                }).ThenByDescending(p => p.AddTime).ToArray();
            }
            if (Lon != 0 && Lat != 0)
            {
                decimal distance = 0;
                var config = SysConfig.GetSysConfigByName(SysConfigNameDefine.BusinessDistance.ToString());
                if (config != null)
                {
                    decimal.TryParse(config.Value, out distance);
                }
                if (distance > 0)
                {
                    list = list.Where(p => p.Distance <= distance).ToArray();
                }
            }
            return list;
        }
        public static Ui.DataGrid GetMall_BusinessGridByKeywords(string Keywords, string orderBy, long startRowIndex, int pageSize, int Status)
        {
            ResetParams();
            long totalRows = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (Status > 0)
            {
                conditions.Add("[Status]=@Status");
                parameters.Add(new SqlParameter("@Status", Status));
            }
            if (!string.IsNullOrEmpty(Keywords))
            {
                conditions.Add("([BusinessName] like @Keywords or [BusinessAddress] like @Keywords or [ContactName] like @Keywords or [ContactPhone] like @Keywords or [LicenseNumber] like @Keywords)");
                parameters.Add(new SqlParameter("@Keywords", "%" + Keywords + "%"));
            }
            string fieldList = "[Mall_Business].*";
            string Statement = " from [Mall_Business] where  " + string.Join(" and ", conditions.ToArray());
            Mall_BusinessDetail[] list = GetList<Mall_BusinessDetail>(fieldList, Statement, parameters, orderBy, startRowIndex, pageSize, out totalRows).ToArray();
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
        public string CategoryName
        {
            get
            {
                if (CategoryName_Dic.ContainsKey(this.ID))
                {
                    return CategoryName_Dic[this.ID];
                }
                if (category_list == null)
                {
                    category_list = Foresight.DataAccess.Mall_Category.GetMall_Categories().Where(p => p.CategoryType.Equals(Utility.EnumModel.Mall_CategoryTypeDefine.businesscategory.ToString())).ToArray();
                }
                if (business_category_list == null)
                {
                    business_category_list = Foresight.DataAccess.Mall_Business_Category.GetMall_Business_Categories().ToArray();
                }
                if (category_list.Length == 0 || business_category_list.Length == 0)
                {
                    CategoryName_Dic.Add(this.ID, string.Empty);
                    return string.Empty;
                }
                List<int> category_idlist = business_category_list.Where(p => p.BusinessID == this.ID).Select(p => p.CategoryID).ToList();
                if (category_idlist.Count == 0)
                {
                    CategoryName_Dic.Add(this.ID, string.Empty);
                    return string.Empty;
                }
                var my_category_list = category_list.Where(p => category_idlist.Contains(p.ID)).ToArray();
                if (my_category_list.Length == 0)
                {
                    CategoryName_Dic.Add(this.ID, string.Empty);
                    return string.Empty;
                }
                string my_category_name = string.Join(",", my_category_list.Select(p => p.CategoryName).ToArray());
                CategoryName_Dic.Add(this.ID, my_category_name);
                return my_category_name;
            }
        }
        public static Dictionary<int, string> CategoryName_Dic = new Dictionary<int, string>();
        public static Mall_Category[] category_list = null;
        public static Mall_Business_Category[] business_category_list = null;
        public static double Lon = 0;
        public static double Lat = 0;
        public static void ResetParams()
        {
            CategoryName_Dic = new Dictionary<int, string>();
            category_list = null;
            business_category_list = null;
            Lon = 0;
            Lat = 0;
        }
    }
}
