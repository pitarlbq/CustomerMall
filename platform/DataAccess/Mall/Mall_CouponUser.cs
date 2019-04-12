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
    /// This object represents the properties and methods of a Mall_CouponUser.
    /// </summary>
    public partial class Mall_CouponUser : EntityBase
    {
        public string IsUsedDesc
        {
            get
            {
                return this.IsUsed ? "已使用" : "未使用";
            }
        }
        public static Mall_CouponUser[] GetMall_CouponUserListByUserIDList(List<int> UserIDList)
        {
            if (UserIDList.Count == 0)
            {
                return new Mall_CouponUser[] { };
            }
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("isnull([IsTaken],0)=1");
            conditions.Add("UserID in (" + string.Join(",", UserIDList.ToArray()) + ")");
            string cmdtext = "select * from  [Mall_CouponUser] where " + string.Join(" and ", conditions.ToArray());
            return GetList<Mall_CouponUser>(cmdtext, parameters).ToArray();
        }
        public static Mall_CouponUser[] GetMall_CouponUserListByUserID(int UserID = 0, int Type = 1)
        {
            if (UserID <= 0 && Type <= 0)
            {
                return new Mall_CouponUser[] { };
            }
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("isnull([IsTaken],0)=1");
            if (Type > 0)
            {
                conditions.Add("[UseType]=@Type");
                parameters.Add(new SqlParameter("@Type", Type));
            }
            if (UserID > 0)
            {
                conditions.Add("[UserID]=@UserID");
                parameters.Add(new SqlParameter("@UserID", UserID));
            }
            Mall_CouponUser[] list = GetList<Mall_CouponUser>("select * from [Mall_CouponUser] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
            return list;
        }
        public static int GetMall_CouponUserCount(int UserID)
        {
            if (UserID <= 0)
            {
                return 0;
            }
            int count = 0;
            using (SqlHelper helper = new SqlHelper())
            {
                List<SqlParameter> parameters = new List<SqlParameter>();
                string cmdtext = @"select count(1) from [Mall_CouponUser] where UserID=@UserID and [IsTaken]=1";
                parameters.Add(new SqlParameter("@UserID", UserID));
                var balanceobj = helper.ExecuteScalar(cmdtext, CommandType.Text, parameters);
                if (balanceobj != null)
                {
                    int.TryParse(balanceobj.ToString(), out count);
                }
            }
            return count;
        }
        public static int GetMall_CouponUserCountByUserIDStatus(int status, int UserID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            if (UserID == 0 || status < 0)
            {
                return 0;
            }
            conditions.Add("[IsSent]=1");
            conditions.Add("[UserID]=@UserID");
            parameters.Add(new SqlParameter("@UserID", UserID));
            if (status == 0)
            {
                conditions.Add("isnull([IsTaken],0)=0");
            }
            else if (status == 3)
            {
                conditions.Add("isnull([IsTaken],0)=1");
                conditions.Add("[IsUsed]=0");
                conditions.Add("([IsActive]=0 or ([EndTime]<@EndTime and [EndTime] is not null))");
                parameters.Add(new SqlParameter("@EndTime", DateTime.Now));
            }
            else
            {
                if (status == 1)
                {
                    conditions.Add("isnull([IsTaken],0)=1");
                    conditions.Add("[IsActive]=1");
                    conditions.Add("([EndTime]>=@EndTime or [EndTime] is null)");
                    conditions.Add("[IsUsed]=0");
                    parameters.Add(new SqlParameter("@EndTime", DateTime.Now));
                }
                if (status == 2)
                {
                    conditions.Add("[IsUsed]=1");
                }
            }
            int count = 0;
            using (SqlHelper helper = new SqlHelper())
            {
                string cmdtext = "select count(1) from [Mall_CouponUser] where  " + string.Join(" and ", conditions.ToArray());
                var balanceobj = helper.ExecuteScalar(cmdtext, CommandType.Text, parameters);
                if (balanceobj != null)
                {
                    int.TryParse(balanceobj.ToString(), out count);
                }
            }
            return count;
        }
        public static Mall_CouponUser[] GetMall_CouponUserListByStatus(int status, long startRowIndex, int pageSize, out long totalRows, int UserID)
        {
            totalRows = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            if (UserID == 0 || status < 0)
            {
                return new Mall_CouponUser[] { };
            }
            conditions.Add("[IsSent]=1");
            conditions.Add("[UserID]=@UserID");
            parameters.Add(new SqlParameter("@UserID", UserID));
            if (status == 0)
            {
                conditions.Add("isnull([IsTaken],0)=0");
            }
            else if (status == 3)
            {
                conditions.Add("isnull([IsTaken],0)=1");
                conditions.Add("[IsUsed]=0");
                conditions.Add("([IsActive]=0 or ([EndTime]<@EndTime and [EndTime] is not null))");
                parameters.Add(new SqlParameter("@EndTime", DateTime.Now));
            }
            else
            {
                if (status == 1)
                {
                    conditions.Add("isnull([IsTaken],0)=1");
                    conditions.Add("[IsActive]=1");
                    conditions.Add("([EndTime]>=@EndTime or [EndTime] is null)");
                    conditions.Add("[IsUsed]=0");
                    parameters.Add(new SqlParameter("@EndTime", DateTime.Now));
                }
                if (status == 2)
                {
                    conditions.Add("[IsUsed]=1");
                }
            }
            string OrderBy = " order by [AddTime] desc";
            string fieldList = "[Mall_CouponUser].*";
            string Statement = " from [Mall_CouponUser] where  " + string.Join(" and ", conditions.ToArray());
            var list = GetList<Mall_CouponUser>(fieldList, Statement, parameters, OrderBy, startRowIndex, pageSize, out totalRows).ToArray();
            return list;
        }
        public static Mall_CouponUser[] GetOrderMall_CouponUserList(int Type, int UserID, int ID = 0, int ProductID = 0, int PaymentID = 0, string CartIDs = "")
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            if (UserID <= 0)
            {
                return new Mall_CouponUser[] { };
            }
            parameters.Add(new SqlParameter("@UserID", UserID));
            conditions.Add("[UserID]=@UserID");
            conditions.Add("[IsUsed]=0");
            conditions.Add("[IsTaken]=1");
            conditions.Add("[IsActive]=1");
            conditions.Add("([EndTime]>=@EndTime or [EndTime] is null)");
            parameters.Add(new SqlParameter("@EndTime", DateTime.Now));
            //物业收费
            if (Type == 1)
            {
                conditions.Add("[CouponID] in (select [ID] from [Mall_Coupon] where [IsUseForWY]=1)");
            }
            //2-购买商品 6-拼团购买
            else if ((Type == 2 || Type == 6) && ProductID > 0)
            {
                conditions.Add("[CouponID] in (select [ID] from [Mall_Coupon] where [IsUseForProduct]=1 and ([IsUseForALLProduct]=1 or ([ID] in (select [CouponID] from [Mall_CouponProduct] where [ProductID]=@ProductID))))");
                parameters.Add(new SqlParameter("@ProductID", ProductID));
            }
            //购物车商品
            else if (Type == 3 && !string.IsNullOrEmpty(CartIDs))
            {
                List<int> CartIDList = JsonConvert.DeserializeObject<List<int>>(CartIDs);
                conditions.Add("[CouponID] in (select [ID] from [Mall_Coupon] where [IsUseForProduct]=1 and ([IsUseForALLProduct]=1 or ([ID] in (select [CouponID] from [Mall_CouponProduct] where [ProductID] in (select [ProductID] from [Mall_ShoppingCart] where ID in (" + string.Join(",", CartIDList.ToArray()) + "))))))");

            }
            //购买服务
            else if (Type == 6)
            {
                conditions.Add("[CouponID] in (select [ID] from [Mall_Coupon] where [IsUseForService]=1)");
                conditions.Add("[CouponID] in (select [ID] from [Mall_Coupon] where [IsUseForService]=1 and ([IsUseForALLService]=1 or ([ID] in (select [CouponID] from [Mall_CouponProduct] where [ServiceID]=@ServiceID))))");
                parameters.Add(new SqlParameter("@ServiceID", ID));
            }
            else
            {
                return new Mall_CouponUser[] { };
            }
            Mall_CouponUser[] list = GetList<Mall_CouponUser>("select * from [Mall_CouponUser] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
            return list;
        }
        public static List<Dictionary<string, object>> GetMySendMall_CouponUserListByUserID(int UserID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            if (UserID == 0)
            {
                return new List<Dictionary<string, object>>();
            }
            conditions.Add("[UserID]=@UserID");
            conditions.Add("isnull([IsSent],0)=1");
            conditions.Add("isnull([IsTaken],0)=0");
            parameters.Add(new SqlParameter("@UserID", UserID));
            string cmdtext = "select * from [Mall_CouponUser] where  " + string.Join(" and ", conditions.ToArray()) + " order by [AddTime] desc";
            var list = GetList<Mall_CouponUser>(cmdtext, parameters).ToArray();
            List<Mall_CouponUser> finallist = new List<Mall_CouponUser>();
            var rule_list = Mall_AmountRule.GetMall_AmountRuleListByIDList(list.Select(p => p.AmountRuleID).Distinct().ToList());
            List<int> rule_idlist = rule_list.Select(p => p.ID).ToList();
            foreach (var item in list)
            {
                if (!item.IsRead)
                {
                    finallist.Add(item);
                    continue;
                }
                var my_rule = rule_list.FirstOrDefault(p => p.ID == item.AmountRuleID);
                if (my_rule == null)
                {
                    continue;
                }
                if (my_rule.PopupUnTakeDay <= 0)
                {
                    continue;
                }
                DateTime ReadDate = new DateTime(item.ReadDate.Year, item.ReadDate.Month, item.ReadDate.Day);
                DateTime NowDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                if (ReadDate.AddDays(my_rule.PopupUnTakeDay) <= NowDate)
                {
                    finallist.Add(item);
                    continue;
                }
            }
            var coupon_list = Mall_Coupon.GetMall_CouponListByIDList(finallist.Select(p => p.CouponID).Distinct().ToList());
            List<Dictionary<string, object>> items = new List<Dictionary<string, object>>();
            int item_count = 0;
            foreach (var item in finallist)
            {
                //item.IsRead = true;
                //item.ReadDate = DateTime.Now;
                //item.Save();
                var dic = new Dictionary<string, object>();
                var my_coupon = coupon_list.FirstOrDefault(p => p.ID == item.CouponID);
                if (my_coupon == null)
                {
                    continue;
                }
                dic["ID"] = item.ID;
                dic["CouponID"] = my_coupon.ID;
                if (string.IsNullOrEmpty(my_coupon.CoverImage))
                {
                    dic["CoverImage"] = string.Empty;
                }
                else
                {
                    dic["CoverImage"] = Utility.Tools.GetContextPath() + my_coupon.CoverImage;
                }
                dic["UseTitle"] = my_coupon.UseTitle;
                dic["UseSubTitle"] = my_coupon.UseSubTitle;
                int rest_count = item_count % 3;
                dic["background_img"] = "url('../image/icons/coupon_bg_" + rest_count + ".png')";
                items.Add(dic);
                item_count++;
            }
            return items;
        }
        public static List<Dictionary<string, object>> GetExpiringMall_CouponUserListByUserID(int UserID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            if (UserID == 0)
            {
                return new List<Dictionary<string, object>>();
            }
            conditions.Add("[IsActive]=1");
            conditions.Add("[UserID]=@UserID");
            conditions.Add("isnull([IsTaken],0)=1");
            conditions.Add("isnull([IsUsed],0)=0");
            parameters.Add(new SqlParameter("@UserID", UserID));
            string cmdtext = "select * from [Mall_CouponUser] where  " + string.Join(" and ", conditions.ToArray()) + " order by [AddTime] desc";
            var list = GetList<Mall_CouponUser>(cmdtext, parameters).ToArray();
            List<Mall_CouponUser> finallist = new List<Mall_CouponUser>();
            var rule_list = Mall_AmountRule.GetMall_AmountRuleListByIDList(list.Select(p => p.AmountRuleID).Distinct().ToList());
            foreach (var item in list)
            {
                DateTime NowDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                if (item.EndTime == DateTime.MinValue || item.EndTime < NowDate)
                {
                    continue;
                }
                var my_rule = rule_list.FirstOrDefault(p => p.ID == item.AmountRuleID);
                if (my_rule == null)
                {
                    continue;
                }
                if (my_rule.PopupBeforeExpireDay <= 0)
                {
                    continue;
                }
                DateTime ExpireReadDate = DateTime.Now;
                if (item.ExpireReadDate > DateTime.MinValue)
                {
                    ExpireReadDate = new DateTime(item.ExpireReadDate.Year, item.ExpireReadDate.Month, item.ExpireReadDate.Day);
                    if (ExpireReadDate >= NowDate)
                    {
                        continue;
                    }
                }
                if (item.ExpireReadDate == DateTime.MinValue)
                {
                    item.ExpireReadDate = DateTime.Now;
                }
                ExpireReadDate = new DateTime(item.ExpireReadDate.Year, item.ExpireReadDate.Month, item.ExpireReadDate.Day);
                if (ExpireReadDate.AddDays(my_rule.PopupBeforeExpireDay) >= item.EndTime)
                {
                    finallist.Add(item);
                    continue;
                }
            }
            var coupon_list = Mall_Coupon.GetMall_CouponListByIDList(finallist.Select(p => p.CouponID).Distinct().ToList());
            List<Dictionary<string, object>> items = new List<Dictionary<string, object>>();
            int item_count = 0;
            foreach (var item in finallist)
            {
                item.ExpireReadDate = DateTime.Now;
                item.Save();
                var dic = new Dictionary<string, object>();
                var my_coupon = coupon_list.FirstOrDefault(p => p.ID == item.CouponID);
                if (my_coupon == null)
                {
                    continue;
                }
                dic["ID"] = item.ID;
                dic["CouponID"] = my_coupon.ID;
                if (string.IsNullOrEmpty(my_coupon.CoverImage))
                {
                    dic["CoverImage"] = string.Empty;
                }
                else
                {
                    dic["CoverImage"] = Utility.Tools.GetContextPath() + my_coupon.CoverImage;
                }
                dic["UseTitle"] = my_coupon.UseTitle;
                dic["UseSubTitle"] = my_coupon.UseSubTitle;
                int rest_count = item_count % 3;
                dic["background_img"] = "url('../image/icons/coupon_bg_" + rest_count + ".png')";
                items.Add(dic);
                item_count++;
            }
            return items;
        }
        public static Mall_CouponUser[] GetMall_CouponUserListByCouponType(int CouponType, int UserID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            if (CouponType == 0 || UserID == 0)
            {
                return new Mall_CouponUser[] { };
            }
            conditions.Add("[IsUsed]=0");
            conditions.Add("[IsTaken]=1");
            conditions.Add("[CouponType]=@CouponType");
            parameters.Add(new SqlParameter("@CouponType", CouponType));
            conditions.Add("[UserID]=@UserID");
            parameters.Add(new SqlParameter("@UserID", UserID));
            string cmdtext = "select * from [Mall_CouponUser] where  " + string.Join(" and ", conditions.ToArray());
            return GetList<Mall_CouponUser>(cmdtext, parameters).ToArray();
        }
        public static void Insert_Mall_CouponUser(int UserID, int CouponID, int CouponType, int CouponRuleID, DateTime IsReadySendTime, SqlHelper helper = null, bool IsSent = true)
        {
            Mall_Coupon coupon = null;
            if (helper == null)
            {
                coupon = Mall_Coupon.GetMall_Coupon(CouponID);
            }
            else
            {
                coupon = Mall_Coupon.GetMall_Coupon(CouponID, helper);
            }
            if (coupon == null)
            {
                return;
            }
            var coupon_user = new Mall_CouponUser();
            coupon_user.AddTime = DateTime.Now;
            coupon_user.AddUserMan = "System";
            coupon_user.UserID = UserID;
            coupon_user.CouponID = CouponID;
            coupon_user.IsUsed = false;
            coupon_user.UseType = 0;
            coupon_user.CouponType = CouponType;
            coupon_user.AmountRuleID = CouponRuleID;
            coupon_user.IsRead = false;
            coupon_user.IsSent = IsSent;
            coupon_user.IsReadySendTime = IsReadySendTime;
            coupon_user.IsTaken = false;
            coupon_user.StartTime = coupon.StartTime;
            coupon_user.EndTime = coupon.EndTime;
            coupon_user.IsActive = true;
            if (helper == null)
            {
                coupon_user.Save();
                return;
            }
            coupon_user.Save(helper);
        }
        public static Mall_CouponUser[] GetUnSentMall_CouponUserList()
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            string cmdtext = "select * from  [Mall_CouponUser] where isnull(IsSent,0)=0 and isnull(IsTaken,0)=0 and ([IsReadySendTime] is null or [IsReadySendTime]<=@Now);";
            parameters.Add(new SqlParameter("@Now", DateTime.Now));
            return GetList<Mall_CouponUser>(cmdtext, parameters).ToArray();
        }
        public bool FinalIsActive
        {
            get
            {
                if (!this.IsActive)
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
        
    }
    public partial class Mall_CouponUserDetail : Mall_CouponUser
    {
        [DatabaseColumn("IsUseForWY")]
        public bool IsUseForWY { get; set; }
        [DatabaseColumn("IsUseForProduct")]
        public bool IsUseForProduct { get; set; }
        [DatabaseColumn("IsUseForALLProduct")]
        public bool IsUseForALLProduct { get; set; }
        [DatabaseColumn("IsUseForALLStore")]
        public bool IsUseForALLStore { get; set; }
        [DatabaseColumn("IsUseForALLCategory")]
        public bool IsUseForALLCategory { get; set; }
        [DatabaseColumn("IsUseForService")]
        public bool IsUseForService { get; set; }
        [DatabaseColumn("IsUseForALLService")]
        public bool IsUseForALLService { get; set; }
        public static List<Dictionary<string, object>> GetOrderMall_CouponUserDicList(decimal totalprice, int BusinessID, int UserID, out List<Dictionary<string, object>> couponlist, int[] ProductIDList = null, int[] ServiceIDList = null, int PaymentID = 0)
        {
            couponlist = new List<Dictionary<string, object>>();
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            if (UserID <= 0)
            {
                return new List<Dictionary<string, object>>();
            }
            conditions.Add("[IsTaken]=1");
            parameters.Add(new SqlParameter("@UserID", UserID));
            conditions.Add("[UserID]=@UserID");
            conditions.Add("[IsUsed]=0");
            conditions.Add("[IsActive]=1");
            conditions.Add("([EndTime]>=@EndTime or [EndTime] is null)");
            parameters.Add(new SqlParameter("@EndTime", DateTime.Now));
            //物业收费
            if (PaymentID > 0)
            {
                conditions.Add("[IsUseForWY]=1");
            }
            //2-单个商品购买 6-拼团购买
            else if (ProductIDList != null && ProductIDList.Length > 0)
            {
                List<string> cmdlist = new List<string>();
                conditions.Add("[IsUseForProduct]=1");
                cmdlist.Add("[IsUseForALLProduct]=1");
                cmdlist.Add("[CouponID] in (select [CouponID] from [Mall_CouponProduct] where [ProductID] in (" + string.Join(",", ProductIDList) + "))");
                cmdlist.Add("[IsUseForALLStore]=1");
                if (BusinessID > 0)
                {
                    cmdlist.Add("[CouponID] in (select [CouponID] from [Mall_CouponProduct] where [BusinessID]=@BusinessID)");
                    parameters.Add(new SqlParameter("@BusinessID", BusinessID));
                }
                cmdlist.Add("[IsUseForALLCategory]=1");
                cmdlist.Add("[CouponID] in (select [CouponID] from [Mall_CouponProduct] where [ProductCategoryID] in (select [CategoryID] from [Mall_Product_Category] where [ProductID] in (" + string.Join(",", ProductIDList.ToArray()) + ")))");
                conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
            }
            //购买服务
            else if (ServiceIDList != null && ServiceIDList.Length > 0)
            {
                List<string> cmdlist = new List<string>();
                conditions.Add("[IsUseForService]=1");
                cmdlist.Add("[IsUseForALLService]=1");
                cmdlist.Add("[CouponID] in (select [CouponID] from [Mall_CouponProduct] where [ServiceID] in (" + string.Join(",", ServiceIDList) + "))");
                conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
            }
            else
            {
                return new List<Dictionary<string, object>>();
            }
            string cmdtext = "select * from (select [Mall_CouponUser].*,[Mall_Coupon].IsUseForWY,[Mall_Coupon].IsUseForProduct,[Mall_Coupon].IsUseForALLProduct,[Mall_Coupon].IsUseForALLStore,[Mall_Coupon].IsUseForALLCategory,[Mall_Coupon].IsUseForService,[Mall_Coupon].IsUseForALLService from [Mall_CouponUser] left join [Mall_Coupon] on [Mall_Coupon].ID=[Mall_CouponUser].CouponID)A where " + string.Join(" and ", conditions.ToArray());
            var list = GetList<Mall_CouponUserDetail>(cmdtext, parameters).ToArray();
            List<int> CouponIDList = list.Select(p => p.CouponID).Distinct().ToList();
            var all_coupons = Mall_Coupon.GetMall_CouponListByIDList(CouponIDList);
            var allcouponlist = new List<Dictionary<string, object>>();
            List<int> MyIDList = new List<int>();
            foreach (var item in list)
            {
                var my_coupon = all_coupons.FirstOrDefault(q => q.ID == item.CouponID);
                if (my_coupon == null)
                {
                    continue;
                }
                decimal price = Mall_Coupon.CalculateCouponPrice(totalprice, my_coupon);
                if (price <= 0)
                {
                    continue;
                }
                int count = 1;
                if (MyIDList.Contains(item.CouponID))
                {
                    foreach (var item2 in couponlist)
                    {
                        if (Convert.ToInt32(item2["couponid"]) == item.CouponID)
                        {
                            count = Convert.ToInt32(item2["count"]);
                            count = count + 1;
                            item2["count"] = count;
                        }
                    }
                }

                MyIDList.Add(item.CouponID);
                var dic = new Dictionary<string, object>();
                dic.Add("id", item.ID);
                dic.Add("couponid", item.CouponID);
                dic.Add("text", my_coupon.CouponName);
                dic.Add("selected", "");
                dic.Add("price", price);
                dic.Add("pricedesc", "￥-" + price.ToString("0.00"));
                dic.Add("count", 1);
                dic.Add("isused", false);
                allcouponlist.Add(dic);
                if (count > 1)
                {
                    continue;
                }
                dic = new Dictionary<string, object>();
                dic.Add("id", 0);
                dic.Add("couponid", item.CouponID);
                dic.Add("text", my_coupon.CouponName);
                dic.Add("selected", "");
                dic.Add("price", price);
                dic.Add("pricedesc", "￥-" + price.ToString("0.00"));
                dic.Add("count", count);
                couponlist.Add(dic);
            }
            return allcouponlist;
        }
    }
    public partial class Mall_CouponUserDetail2 : Mall_CouponUser
    {
        public string NickName { get; set; }
        public string PhoneNumber { get; set; }
        public string CouponName { get; set; }
        public string CouponTypeDesc { get; set; }
        public string UseForALLDesc { get; set; }
        public string UseTypeDesc { get; set; }
        public string ActiveTimeRangeDesc { get; set; }
        public static Ui.DataGrid GetMall_CouponUserDetail2GridByKeywords(string keywords, int UserID, int CouponType, int IsUsed, int IsActive, long startRowIndex, int pageSize)
        {
            long totalRows = 0;
            string OrderBy = " order by [UserID] desc,[AddTime] desc";
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (IsUsed >= 0)
            {
                conditions.Add("[IsUsed]=@IsUsed");
                parameters.Add(new SqlParameter("@IsUsed", IsUsed));
            }
            if (IsActive >= 0)
            {
                conditions.Add("([IsActive]=@IsActive and [EndTime]>=@EndTime)");
                parameters.Add(new SqlParameter("@IsActive", IsActive));
                parameters.Add(new SqlParameter("@EndTime", DateTime.Now));
            }
            if (UserID > 0)
            {
                conditions.Add("([UserID]=@UserID or [UserID] in (select [UserID] from [User] where [ParentUserID]=@UserID))");
                parameters.Add(new SqlParameter("@UserID", UserID));
            }
            if (CouponType > 0)
            {
                conditions.Add("[CouponID] in (select [ID] from [Coupon] where [CouponType]=@CouponType)");
                parameters.Add(new SqlParameter("@CouponType", CouponType));
            }
            if (!string.IsNullOrEmpty(keywords))
            {
                conditions.Add("[UserID] in (select [UserID] from [User] where [NickName] like @keywords or [PhoneNumber] like @keywords)");
                parameters.Add(new SqlParameter("@keywords", "%" + keywords + "%"));
            }
            string fieldList = "[Mall_CouponUser].*";
            string Statement = " from  [Mall_CouponUser] where  " + string.Join(" and ", conditions.ToArray());
            Mall_CouponUserDetail2[] list = GetList<Mall_CouponUserDetail2>(fieldList, Statement, parameters, OrderBy, startRowIndex, pageSize, out totalRows).ToArray();
            List<int> UserIDList = list.Select(p => p.UserID).Distinct().ToList();
            var user_list = User.GetUserListByIDList(UserIDList);
            List<int> CouponIDList = list.Select(p => p.CouponID).Distinct().ToList();
            var coupon_list = Mall_Coupon.GetMall_CouponListByIDList(CouponIDList);
            foreach (var item in list)
            {
                var my_user = user_list.FirstOrDefault(p => p.UserID == item.UserID);
                if (my_user != null)
                {
                    item.NickName = my_user.NickName;
                    item.PhoneNumber = my_user.PhoneNumber;
                }
                var my_coupon = coupon_list.FirstOrDefault(p => p.ID == item.CouponID);
                if (my_coupon != null)
                {
                    item.CouponName = my_coupon.CouponName;
                    item.CouponTypeDesc = my_coupon.CouponTypeDesc;
                    item.UseForALLDesc = my_coupon.UseForALLDesc;
                    item.UseTypeDesc = my_coupon.UseTypeDesc;
                    item.ActiveTimeRangeDesc = my_coupon.ActiveTimeRangeDesc;
                }
            }
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
    }
}
