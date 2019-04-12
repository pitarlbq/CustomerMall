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
    /// This object represents the properties and methods of a Wechat_HouseService.
    /// </summary>
    public partial class Wechat_HouseService : EntityBase
    {
        public string PublishStatus
        {
            get
            {
                return this.IsPublish ? "已发布" : "未发布";
            }
        }
        public static Wechat_HouseService[] GetWechat_HouseServiceListByAmountRuleID(int AmountRuleID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (AmountRuleID == 0)
            {
                return new Wechat_HouseService[] { };
            }
            conditions.Add("[ID] in (select [HouseServiceID] from [Mall_AmountRuleService] where [AmountRuleID]=@AmountRuleID)");
            parameters.Add(new SqlParameter("@AmountRuleID", AmountRuleID));
            string cmdtext = "select * from [Wechat_HouseService] where  " + string.Join(" and ", conditions.ToArray());
            return GetList<Wechat_HouseService>(cmdtext, parameters).ToArray();
        }
        public static Wechat_HouseService[] GetWechat_HouseServiceListByCouponID(int CouponID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("ID in (select [ServiceID] from [Mall_CouponProduct] where [CouponID]=@CouponID)");
            parameters.Add(new SqlParameter("@CouponID", CouponID));
            string Statement = @"select * from Wechat_HouseService where " + string.Join(" and ", conditions);
            return GetList<Wechat_HouseService>(Statement, parameters).ToArray();
        }
    }
    public partial class Wechat_HouseServiceDetail : Wechat_HouseService
    {
        [DatabaseColumn("CategoryName")]
        public string CategoryName { get; set; }
        public static Wechat_HouseServiceDetail[] GetWechat_HouseServiceDetailListByAreaIDList(List<int> CategoryIDList)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            List<string> sub_conditions = new List<string>();
            if (CategoryIDList.Count > 0)
            {
                conditions.Add("[CategoryID] in (" + string.Join(",", CategoryIDList.ToArray()) + ")");
            }
            return GetList<Wechat_HouseServiceDetail>("select *,(select CategoryName from [Wechat_HouseServiceCategory] where ID=Wechat_HouseService.CategoryID) as CategoryName from [Wechat_HouseService] where " + string.Join(" and ", conditions.ToArray()) + " order by [AddTime] desc", parameters).ToArray();
        }
        public static Ui.DataGrid GetWechat_HouseServiceDetailGridByKeywords(string Keywords, List<int> CategoryIDList, string orderBy, long startRowIndex, int pageSize, int type)
        {
            long totalRows = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (type == 1)
            {
                conditions.Add("[IsWechatShow]=1");
            }
            if (type == 2 || type == 3)
            {
                conditions.Add("([IsAPPCustomerShow]=1 or [IsAPPUserShow]=1)");
            }
            if (!string.IsNullOrEmpty(Keywords))
            {
                conditions.Add("([Title] like @Keywords or [ContactPhone] like @Keywords)");
                parameters.Add(new SqlParameter("@Keywords", "%" + Keywords + "%"));
            }
            if (CategoryIDList.Count > 0)
            {
                conditions.Add("[CategoryID] in (" + string.Join(",", CategoryIDList.ToArray()) + ")");
            }
            string fieldList = "A.*";
            string Statement = " from (select *,(select CategoryName from [Wechat_HouseServiceCategory] where ID=Wechat_HouseService.CategoryID) as CategoryName from [Wechat_HouseService])A where  " + string.Join(" and ", conditions.ToArray());
            Wechat_HouseServiceDetail[] list = GetList<Wechat_HouseServiceDetail>(fieldList, Statement, parameters, orderBy, startRowIndex, pageSize, out totalRows).ToArray();
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
    }
}
