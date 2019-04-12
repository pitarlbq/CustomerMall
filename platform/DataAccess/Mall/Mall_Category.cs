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
    /// This object represents the properties and methods of a Mall_Category.
    /// </summary>
    public partial class Mall_Category : EntityBase
    {
        public static Mall_Category[] GetMall_CategoryListByParentIDList(List<int> ParentIDList)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (ParentIDList.Count == 0)
            {
                return new Mall_Category[] { };
            }
            conditions.Add("[ParentID] in (" + string.Join(",", ParentIDList.ToArray()) + ")");
            conditions.Add("[ID] not in (" + string.Join(",", ParentIDList.ToArray()) + ")");
            string cmdtext = "select * from [Mall_Category] where  " + string.Join(" and ", conditions.ToArray());
            return GetList<Mall_Category>(cmdtext, parameters).ToArray();
        }
        public static Mall_Category[] GetMall_CategoryListByProductID(int ProductID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (ProductID == 0)
            {
                return new Mall_Category[] { };
            }
            conditions.Add("[CategoryType]=@CategoryType");
            parameters.Add(new SqlParameter("@CategoryType", Utility.EnumModel.Mall_CategoryTypeDefine.productcategory.ToString()));
            conditions.Add("[ID] in (select [CategoryID] from [Mall_Product_Category] where [ProductID]=@ProductID)");
            parameters.Add(new SqlParameter("@ProductID", ProductID));
            string cmdtext = "select * from [Mall_Category] where  " + string.Join(" and ", conditions.ToArray());
            return GetList<Mall_Category>(cmdtext, parameters).ToArray();
        }
        public static Mall_Category[] GetMall_CategoryListByBusinessID(int BusinessID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (BusinessID == 0)
            {
                return new Mall_Category[] { };
            }
            conditions.Add("[CategoryType]=@CategoryType");
            parameters.Add(new SqlParameter("@CategoryType", Utility.EnumModel.Mall_CategoryTypeDefine.businesscategory.ToString()));
            conditions.Add("[ID] in (select [CategoryID] from [Mall_Business_Category] where [BusinessID]=@BusinessID)");
            parameters.Add(new SqlParameter("@BusinessID", BusinessID));
            string cmdtext = "select * from [Mall_Category] where  " + string.Join(" and ", conditions.ToArray());
            return GetList<Mall_Category>(cmdtext, parameters).ToArray();
        }
        public static Mall_Category[] GetMall_ProductCategoryListByCouponID(int CouponID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[CategoryType]=@CategoryType");
            parameters.Add(new SqlParameter("@CategoryType", Utility.EnumModel.Mall_CategoryTypeDefine.productcategory.ToString()));
            conditions.Add("ID in (select [ProductCategoryID] from [Mall_CouponProduct] where [CouponID]=@CouponID)");
            parameters.Add(new SqlParameter("@CouponID", CouponID));
            string Statement = @"select * from Mall_Category where " + string.Join(" and ", conditions);
            return GetList<Mall_Category>(Statement, parameters).ToArray();
        }
        public string IsDisabledDesc
        {
            get
            {
                return this.IsDisabled ? "是" : "否";
            }
        }
    }
    public partial class Mall_CategoryDetail : Mall_Category
    {
        [DatabaseColumn("ProductCount")]
        public int ProductCount { get; set; }
        public static Mall_CategoryDetail[] GetMall_CategoryDetailListByKeywords(string Keywords, string orderBy, int type)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (!string.IsNullOrEmpty(Keywords))
            {
                conditions.Add("([CategoryName] like @Keywords)");
                parameters.Add(new SqlParameter("@Keywords", "%" + Keywords + "%"));
            }
            if (type == 1)
            {
                conditions.Add("[CategoryType]=@CategoryType");
                parameters.Add(new SqlParameter("@CategoryType", Utility.EnumModel.Mall_CategoryTypeDefine.productcategory.ToString()));
            }
            else if (type == 2)
            {
                conditions.Add("[CategoryType]=@CategoryType");
                parameters.Add(new SqlParameter("@CategoryType", Utility.EnumModel.Mall_CategoryTypeDefine.businesscategory.ToString()));
            }
            else if (type == 3)
            {
                conditions.Add("[CategoryType]=@CategoryType");
                parameters.Add(new SqlParameter("@CategoryType", Utility.EnumModel.Mall_CategoryTypeDefine.threadcategory.ToString()));
            }
            string Statement = "select * from (select *,(select count(1) from Mall_Product where ID in (select ProductID from Mall_Product_Category where CategoryID=Mall_Category.ID)) as ProductCount from [Mall_Category] where  " + string.Join(" and ", conditions.ToArray()) + ")A " + orderBy;
            return GetList<Mall_CategoryDetail>(Statement, parameters).ToArray();
        }
    }
}
