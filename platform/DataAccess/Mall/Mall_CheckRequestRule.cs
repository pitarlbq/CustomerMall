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
    /// This object represents the properties and methods of a Mall_CheckRequestRule.
    /// </summary>
    public partial class Mall_CheckRequestRule : EntityBase
    {
        public static Mall_CheckRequestRule[] GetMall_CheckRequestRuleListByRequestID(int RequestID)
        {
            if (RequestID <= 0)
            {
                return new Mall_CheckRequestRule[] { };
            }
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[RequestID]=@RequestID");
            parameters.Add(new SqlParameter("@RequestID", RequestID));
            string cmdtext = "select * from [Mall_CheckRequestRule] where  " + string.Join(" and ", conditions.ToArray());
            Mall_CheckRequestRule[] list = GetList<Mall_CheckRequestRule>(cmdtext, parameters).ToArray();
            return list;
        }
        public static Mall_CheckRequestRule[] GetMall_CheckRequestRuleListByRequestIDList(List<int> RequestIDList)
        {
            if (RequestIDList.Count == 0)
            {
                return new Mall_CheckRequestRule[] { };
            }
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[RequestID] in (" + string.Join(",", RequestIDList.ToArray()) + ")");
            string cmdtext = "select * from [Mall_CheckRequestRule] where  " + string.Join(" and ", conditions.ToArray());
            Mall_CheckRequestRule[] list = GetList<Mall_CheckRequestRule>(cmdtext, parameters).ToArray();
            return list;
        }
        public string CategoryTypeDesc
        {
            get
            {
                if (this.EarnType == 1)
                {
                    return "奖励";
                }
                if (this.EarnType == 2)
                {
                    return "扣除";
                }
                return string.Empty;
            }
        }
    }
    public partial class Mall_CheckRequestRuleDetail : Mall_CheckRequestRule
    {
        public int CategoryType { get; set; }
        public string CategoryName { get; set; }
        public string CheckName { get; set; }
        public int StartPoint { get; set; }
        public int EndPoint { get; set; }
        public string PointRange
        {
            get
            {
                if (this.StartPoint <= 0 && this.EndPoint <= 0)
                {
                    return string.Empty;
                }
                return this.StartPoint.ToString() + " - " + this.EndPoint.ToString();
            }
        }
        public static Mall_CheckRequestRuleDetail[] GetMall_CheckRequestRuleDetailListShiLi(Mall_CheckRequestRuleDetail[] list)
        {
            if (list.Length > 0)
            {
                var category_list = Mall_CheckCategory.GetMall_CheckCategories();
                var checkinfo_list = Mall_CheckInfo.GetMall_CheckInfos();
                foreach (var item in list)
                {
                    item.CategoryType = item.EarnType;
                    var my_checkinfo = checkinfo_list.FirstOrDefault(p => p.ID == item.RuleID);
                    if (my_checkinfo != null)
                    {
                        item.CheckName = my_checkinfo.CheckName;
                        item.StartPoint = my_checkinfo.StartPoint;
                        item.EndPoint = my_checkinfo.EndPoint;
                        var my_category = category_list.FirstOrDefault(p => p.ID == my_checkinfo.CheckCategoryID);
                        if (my_category != null)
                        {
                            item.CategoryName = my_category.CategoryName;
                        }
                    }
                    else
                    {
                        item.CheckName = "固定积分";
                        item.CategoryName = item.Title;
                        item.StartPoint = 0;
                        item.EndPoint = 0;
                    }
                }
            }
            return list;
        }

        public static Mall_CheckRequestRuleDetail[] GetMall_CheckRequestRuleDetailListByRequestID(int RequestID)
        {
            if (RequestID <= 0)
            {
                return new Mall_CheckRequestRuleDetail[] { };
            }
            var data = Mall_CheckRequest.GetMall_CheckRequest(RequestID);
            if (data == null)
            {
                return new Mall_CheckRequestRuleDetail[] { };
            }
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[RequestID]=@RequestID");
            parameters.Add(new SqlParameter("@RequestID", RequestID));
            string cmdtext = "select * from [Mall_CheckRequestRule] where  " + string.Join(" and ", conditions.ToArray());
            Mall_CheckRequestRuleDetail[] list = GetList<Mall_CheckRequestRuleDetail>(cmdtext, parameters).ToArray();
            list = GetMall_CheckRequestRuleDetailListShiLi(list);
            return list;
        }
        public static Mall_CheckRequestRuleDetail[] GetMall_CheckRequestRuleDetailListByRequestIDList(List<int> RequestIDList)
        {
            if (RequestIDList.Count == 0)
            {
                return new Mall_CheckRequestRuleDetail[] { };
            }
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[RequestID] in (" + string.Join(",", RequestIDList.ToArray()) + ")");
            string cmdtext = "select * from [Mall_CheckRequestRule] where  " + string.Join(" and ", conditions.ToArray());
            Mall_CheckRequestRuleDetail[] list = GetList<Mall_CheckRequestRuleDetail>(cmdtext, parameters).ToArray();
            list = GetMall_CheckRequestRuleDetailListShiLi(list);
            return list;
        }
    }
}
