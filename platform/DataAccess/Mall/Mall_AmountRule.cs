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
    /// This object represents the properties and methods of a Mall_AmountRule.
    /// </summary>
    public partial class Mall_AmountRule : EntityBase
    {
        public static Mall_AmountRule[] GetMall_AmountRuleListByIDList(List<int> IDList)
        {
            if (IDList.Count == 0)
            {
                return new Mall_AmountRule[] { };
            }
            List<string> conditions = new List<string>();
            conditions.Add("[ID] in (" + string.Join(",", IDList.ToArray()) + ")");
            return GetList<Mall_AmountRule>("select * from [Mall_AmountRule] where " + string.Join(" and ", conditions.ToArray()), new List<SqlParameter>()).ToArray();
        }
        public static Mall_AmountRule[] GetMall_AmountRuleListByAmount(decimal StartAmount, decimal EndAmount, int ID = 0, int AmountType = 0, int RuleType = 0, List<int> ProjectIDList = null, bool IsUseForALLProject = false)
        {
            List<string> conditions = new List<string>();
            List<SqlParameter> parameters = new List<SqlParameter>();
            conditions.Add("[IsActive]=1");
            conditions.Add("(([StartAmount]<@StartAmount and [EndAmount]>@StartAmount) or ([StartAmount]<@EndAmount and [EndAmount]>=@EndAmount) or ([StartAmount]>@StartAmount and [StartAmount]<@EndAmount))");
            parameters.Add(new SqlParameter("@StartAmount", StartAmount));
            parameters.Add(new SqlParameter("@EndAmount", EndAmount));
            if (!IsUseForALLProject && ProjectIDList != null && ProjectIDList.Count > 0)
            {
                conditions.Add("([IsUseForALLProject]=1 or [ID] in (select [Mall_AmountRuleID] from [Mall_AmountRuleProject] where [ProjectID] in (" + string.Join(",", ProjectIDList.ToArray()) + ")))");
            }
            if (ID > 0)
            {
                conditions.Add("[ID]!=@ID");
                parameters.Add(new SqlParameter("@ID", ID));
            }
            if (AmountType > 0)
            {
                conditions.Add("[AmountType]=@AmountType");
                parameters.Add(new SqlParameter("@AmountType", AmountType));
            }
            if (RuleType > 0)
            {
                conditions.Add("[RuleType]=@RuleType");
                parameters.Add(new SqlParameter("@RuleType", RuleType));
            }
            return GetList<Mall_AmountRule>("select * from [Mall_AmountRule] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
        public static Mall_AmountRule[] GetMall_AmountRuleByAmount(decimal Amount, int AmountType = 1, int UserID = 0)
        {
            if (UserID <= 0)
            {
                return new Mall_AmountRule[] { };
            }
            List<string> conditions = new List<string>();
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<int> ProjectIDList = Project.GetParentProjectIDListByAPPUserID(UserID);
            if (ProjectIDList.Count > 0)
            {
                conditions.Add("([IsUseForALLProject]=1 or [ID] in (select [Mall_AmountRuleID] from [Mall_AmountRuleProject] where [ProjectID] in (" + string.Join(",", ProjectIDList.ToArray()) + ")))");
            }
            else
            {
                conditions.Add("[IsUseForALLProject]=1");
            }
            conditions.Add("[AmountType]=@AmountType");
            parameters.Add(new SqlParameter("@AmountType", AmountType));
            conditions.Add("[IsActive]=1");
            conditions.Add("[StartAmount]<=@Amount");
            conditions.Add("[EndAmount]>=@Amount");
            parameters.Add(new SqlParameter("@Amount", Amount));
            return GetList<Mall_AmountRule>("select * from [Mall_AmountRule] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
        public static void GetBackAmountPoint(decimal Amount, out Dictionary<string, object> BackObject, int[] ProductIDList, int[] ServiceIDList, int AmountType = 1, int UserID = 0)
        {
            BackObject = new Dictionary<string, object>();
            int AmountRuleID = 0;
            int PointRuleID = 0;
            int CouponRuleID = 0;
            if (Amount <= 0 || UserID <= 0)
            {
                return;
            }
            var list = GetMall_AmountRuleByAmount(Amount, AmountType: AmountType, UserID: UserID);
            if (list.Length == 0)
            {
                return;
            }
            int[] amountRuleIDList = list.Select(p => p.ID).ToArray();
            var amountRuleProductList = Mall_AmountRuleProduct.GetMall_AmountRuleProductListByAmountRuleIDList(amountRuleIDList);
            foreach (var data in list)
            {
                if (!data.IsUseForALLProduct)
                {
                    var myAmountRuleProductList = amountRuleProductList.Where(p => p.AmountRuleID == data.ID).ToArray();
                    var myProductIDList = myAmountRuleProductList.Select(p => p.ProductID).ToArray();
                    bool isContain = false;
                    foreach (var ProductID in ProductIDList)
                    {
                        if (myProductIDList.Contains(ProductID))
                        {
                            isContain = true;
                        }
                    }
                    var myServiceIDList = myAmountRuleProductList.Select(p => p.ServiceID).ToArray();
                    foreach (var ServiceID in ServiceIDList)
                    {
                        if (myServiceIDList.Contains(ServiceID))
                        {
                            isContain = true;
                        }
                    }
                    if (!isContain)
                    {
                        continue;
                    }
                }
                if (data.IsBackAmount && AmountRuleID <= 0)
                {
                    AmountRuleID = data.ID;
                    decimal BackAmount = 0;
                    if (data.BackAmountType == 1)
                    {
                        BackAmount = Math.Round((decimal)(Amount * data.BackAmount) / 100, 2, MidpointRounding.AwayFromZero);
                    }
                    else if (data.BackAmountType == 2)
                    {
                        BackAmount = data.BackAmount;
                    }
                    BackObject["AmountRuleID"] = data.ID;
                    BackObject["BackAmount"] = BackAmount;
                    BackObject["AmountIsSendNow"] = data.IsSendNow;
                    BackObject["AmountIsReadySendTime"] = data.IsReadySendTime;
                    if (data.IsReadySendTime <= DateTime.Now)
                    {
                        BackObject["AmountIsSendNow"] = true;
                    }
                    continue;
                }
                if (data.IsBackPoint && PointRuleID <= 0)
                {
                    PointRuleID = data.ID;
                    int BackPoint = 0;
                    if (data.BackPointType == 1)
                    {
                        BackPoint = Convert.ToInt32(Math.Round((decimal)(Amount * data.BackPoint) / 100, 0, MidpointRounding.AwayFromZero));
                    }
                    else if (data.BackPointType == 2)
                    {
                        BackPoint = Convert.ToInt32(data.BackPoint);
                    }
                    BackObject["PointRuleID"] = data.ID;
                    BackObject["BackPoint"] = BackPoint;
                    BackObject["PointIsSendNow"] = data.IsSendNow;
                    BackObject["PointIsReadySendTime"] = data.IsReadySendTime;
                    if (data.IsReadySendTime <= DateTime.Now)
                    {
                        BackObject["PointIsSendNow"] = true;
                    }
                    continue;
                }
                if (data.IsBackCoupon && CouponRuleID <= 0)
                {
                    CouponRuleID = data.ID;
                    var coupon_list = Mall_AmountRuleService.GetMall_AmountRuleServiceListByAmountRuleID(data.ID);
                    var CouponIDList = coupon_list.Select(p => p.CouponCodeID).ToList();
                    BackObject["CouponRuleID"] = data.ID;
                    BackObject["CouponIDList"] = CouponIDList;
                    BackObject["CouponIsSendNow"] = data.IsSendNow;
                    BackObject["CouponIsReadySendTime"] = data.IsReadySendTime;
                    BackObject["SendCouponCount"] = data.SendCouponCount > 0 ? data.SendCouponCount : 1;
                    if (data.IsReadySendTime <= DateTime.Now)
                    {
                        BackObject["CouponIsSendNow"] = true;
                    }
                    continue;
                }
            }
        }
        public string AmountRange
        {
            get
            {
                return this.StartAmount.ToString("0.00") + "(含) - " + this.EndAmount.ToString("0.00");
            }
        }
        public string IsUserLevelActiveDesc
        {
            get
            {
                return this.IsUserLevelActive ? "是" : "否";
            }
        }
        public string IsActiveDesc
        {
            get
            {
                return this.IsActive ? "是" : "否";
            }
        }
        public string BackAmountDesc
        {
            get
            {
                if (this.BackAmount <= 0)
                {
                    return "--";
                }
                if (this.BackAmountType == 1)
                {
                    return "按比例返还" + this.BackAmount.ToString("0.00") + "%";
                }
                if (this.BackAmountType == 2)
                {
                    return "固定金额返还" + this.BackAmount.ToString("0.00") + "元";
                }
                return "--";
            }
        }
        public string BackPointDesc
        {
            get
            {
                if (this.BackPoint <= 0)
                {
                    return "--";
                }
                if (this.BackPointType == 1)
                {
                    return "按比例返还" + this.BackPoint.ToString("0.00") + "%";
                }
                if (this.BackPointType == 2)
                {
                    return "固定积分返还" + this.BackPoint.ToString("0") + "个";
                }
                return "--";
            }
        }
        public bool IsBackAmount
        {
            get
            {
                if (!this.IsActive)
                {
                    return false;
                }
                if (this.RuleType != 2)
                {
                    return false;
                }
                if (this.BackAmount <= 0)
                {
                    return false;
                }
                if (this.BackAmountType <= 0)
                {
                    return false;
                }
                return true;
            }
        }
        public bool IsBackPoint
        {
            get
            {
                if (!this.IsActive)
                {
                    return false;
                }
                if (this.RuleType != 1)
                {
                    return false;
                }
                if (this.BackPoint <= 0)
                {
                    return false;
                }
                if (this.BackPointType <= 0)
                {
                    return false;
                }
                return true;
            }
        }
        public bool IsBackCoupon
        {
            get
            {
                if (!this.IsActive)
                {
                    return false;
                }
                if (this.RuleType != 3)
                {
                    return false;
                }
                return true;
            }
        }
        public string AmountTypeDesc
        {
            get
            {
                return this.AmountType == 1 ? "充值" : "消费";
            }
        }
        public string RuleTypeDesc
        {
            get
            {
                string desc = string.Empty;
                if (this.RuleType == 1)
                {
                    return "赠送积分";
                }
                if (this.RuleType == 2)
                {
                    return "赠送余额";
                }
                if (this.RuleType == 3)
                {
                    return "赠送福顺券";
                }
                return desc;
            }
        }
    }
    public partial class Mall_AmountRuleDetail : Mall_AmountRule
    {

        [DatabaseColumn("PartnerRankName")]
        public string PartnerRankName { get; set; }
        public string AdditionalEarnServiceDesc { get; set; }
        public static Ui.DataGrid GetMall_AmountRuleDetailGridByKeywords(string keywords, long startRowIndex, int pageSize, int RuleType, int AmountType)
        {
            long totalRows = 0;
            string OrderBy = " order by [AmountType] asc,[RuleType] asc, [StartAmount] asc";
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (AmountType > 0)
            {
                conditions.Add("[AmountType]=@AmountType");
                parameters.Add(new SqlParameter("@AmountType", AmountType));
            }
            if (RuleType > 0)
            {
                conditions.Add("[RuleType]=@RuleType");
                parameters.Add(new SqlParameter("@RuleType", RuleType));
            }
            if (!string.IsNullOrEmpty(keywords))
            {
                conditions.Add("([Title] like @keywords or [UserLevelID] in (select [ID] from [Mall_UserLevel] where [Name] like @keywords))");
                parameters.Add(new SqlParameter("@keywords", "%" + keywords + "%"));
            }
            string fieldList = "A.*";
            string Statement = " from (select *,(select Name from [Mall_UserLevel] where [ID]=[Mall_AmountRule].[UserLevelID]) as PartnerRankName from [Mall_AmountRule])A where  " + string.Join(" and ", conditions.ToArray());
            Mall_AmountRuleDetail[] list = GetList<Mall_AmountRuleDetail>(fieldList, Statement, parameters, OrderBy, startRowIndex, pageSize, out totalRows).ToArray();
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
    }
}
