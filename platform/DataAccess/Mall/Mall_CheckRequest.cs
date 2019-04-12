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
    /// This object represents the properties and methods of a Mall_CheckRequest.
    /// </summary>
    public partial class Mall_CheckRequest : EntityBase
    {
        public static Mall_CheckRequest[] GetAllActiveMall_CheckRequestList()
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("isnull([IsJieXiaoPointSent],0)=0");
            conditions.Add("[ApproveStatus]=1");
            conditions.Add("[ID] in (select [RequestID] from [Mall_CheckRequestUser])");
            conditions.Add("([ConfirmStatus]=1 or ([ConfirmStatus]=2 and [ProcessStatus]=1))");
            string cmdtext = "select * from [Mall_CheckRequest] where  " + string.Join(" and ", conditions.ToArray());
            Mall_CheckRequestDetail[] list = GetList<Mall_CheckRequestDetail>(cmdtext, parameters).ToArray();
            return list;
        }
        public static int GetMall_CheckRequestCountByStatus(int UserID, int Status)
        {
            if (UserID <= 0)
            {
                return 0;
            }
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[ApproveStatus]=1");
            conditions.Add("[ID] in (select [RequestID] from [Mall_CheckRequestUser] where [UserID]=@UserID)");
            conditions.Add("[ConfirmStatus]=@Status");
            parameters.Add(new SqlParameter("@UserID", UserID));
            parameters.Add(new SqlParameter("@Status", Status));
            int count = 0;
            using (SqlHelper helper = new SqlHelper())
            {
                string cmdtext = "select count(1) from [Mall_CheckRequest] where " + string.Join(" and ", conditions.ToArray());
                var result = helper.ExecuteScalar(cmdtext, CommandType.Text, parameters);
                if (result != null)
                {
                    count = Convert.ToInt32(result);
                }
            }
            return count;
        }
        public string ApproveStatusDesc
        {
            get
            {
                if (this.ApproveStatus == 0)
                {
                    return "待申请";
                }
                if (this.ApproveStatus == 1)
                {
                    return "审批通过";
                }
                if (this.ApproveStatus == 2)
                {
                    return "审批未通过";
                }
                if (this.ApproveStatus == 3)
                {
                    return "待审批";
                }
                return string.Empty;
            }
        }
        public string ConfirmStatusDesc
        {
            get
            {
                if (this.ConfirmStatus == 0)
                {
                    return "未申诉";
                }
                if (this.ConfirmStatus == 1)
                {
                    return "无异议";
                }
                if (this.ConfirmStatus == 2)
                {
                    return "有异议";
                }
                return string.Empty;
            }
        }
        public string ProcessStatusDesc
        {
            get
            {
                if (this.ProcessStatus <= 0)
                {
                    return "未处理";
                }
                if (this.ProcessStatus == 1)
                {
                    return "维持原考核";
                }
                if (this.ProcessStatus == 2)
                {
                    return "作废原考核";
                }
                return "未处理";
            }
        }
        public string APPProcessStatusDesc
        {
            get
            {
                if (this.ApproveStatus != 1)
                {
                    return string.Empty;
                }
                if (this.ConfirmStatus != 2)
                {
                    return string.Empty;
                }
                if (this.ProcessStatus <= 0)
                {
                    return "未处理";
                }
                if (this.ProcessStatus == 1)
                {
                    return "申诉拒绝";
                }
                if (this.ProcessStatus == 2)
                {
                    return "申诉生效";
                }
                return "未处理";
            }
        }
        public string RequestTypeDesc
        {
            get
            {
                if (this.RequestType <= 1)
                {
                    return "行为考核";
                }
                if (this.RequestType == 2)
                {
                    return "固定积分";
                }
                return "行为考核";
            }
        }
        public string IsJieXiaoPointSentDesc
        {
            get
            {
                return this.IsJieXiaoPointSent ? "已发放" : "未发放";
            }
        }
        public static int senduserjixiaopoint(List<int> IDList)
        {
            var request_list = Mall_CheckRequest.GetAllActiveMall_CheckRequestList().Where(p => IDList.Contains(p.ID)).ToArray();
            if (request_list.Length == 0)
            {
                return 0;
            }
            var rule_list = Mall_CheckRequestRuleDetail.GetMall_CheckRequestRuleDetailListByRequestIDList(IDList);
            var user_list = Mall_CheckRequestUser.GetMall_CheckRequestUserListByRequestIDList(IDList);
            int count = 0;
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    foreach (var check_request in request_list)
                    {
                        var my_user_list = user_list.Where(p => p.RequestID == check_request.ID).ToArray();
                        var my_rule_list = rule_list.Where(p => p.RequestID == check_request.ID).ToArray();
                        if (my_user_list.Length == 0 || my_rule_list.Length == 0)
                        {
                            continue;
                        }
                        foreach (var check_user in my_user_list)
                        {
                            foreach (var check_rule in my_rule_list)
                            {
                                string Title = check_rule.EarnType == 1 ? "业绩考核奖励" : check_rule.Title;
                                int PointType = check_rule.EarnType;
                                int CategoryType = check_rule.EarnType;
                                int BackPoint = check_rule.EarnType == 1 ? check_rule.PointValue : -check_rule.PointValue;
                                Mall_UserJiXiaoPoint.Insert_Mall_UserJiXiaoPoint(check_user.UserID, PointType, 0, Title, "Mall_CheckRequestID:" + check_request.ID, CategoryType, "System", 1, helper, FixedPointMonth: check_rule.FixedPointMonth, FixedPointDateTime: check_rule.FixedPointDateTime, PointValue: BackPoint, RelatedID: check_request.ID, RuleID: check_rule.ID, InfoID: check_rule.RuleID, InfoName: check_rule.CheckName, CategoryName: check_rule.CategoryName, EarnType: check_rule.EarnType, ApproveUserName: check_request.ApproveMan, ApproveTime: check_request.ApproveTime, ApproveRemark: check_request.ApproveRemark, Remark: check_request.Remark);
                                count++;
                            }
                        }
                        check_request.IsJieXiaoPointSent = true;
                        check_request.JieXiaoPointSentTime = DateTime.Now;
                        check_request.Save(helper);
                    }
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    Utility.LogHelper.WriteError("Mall_CheckRequest.cs", "senduserjixiaopoint", ex);
                    return 0;
                }
            }
            return count;
        }
    }
    public partial class Mall_CheckRequestDetail : Mall_CheckRequest
    {
        public string CheckUserInfo { get; set; }
        public string CheckCategoryName { get; set; }
        public string CheckUserPosition { get; set; }
        public string CheckRule { get; set; }
        public int UserEarnPoint { get; set; }
        public int UserReducePoint { get; set; }
        public string PointValueDesc
        {
            get
            {
                string desc = string.Empty;
                if (UserEarnPoint > 0)
                {
                    if (this.RequestType <= 1)
                    {
                        desc += "行为考评积分奖励 " + UserEarnPoint.ToString() + " ";
                    }
                    else
                    {
                        desc += "岗位固定积分奖励 " + UserEarnPoint.ToString() + " ";
                    }
                }
                if (UserReducePoint > 0)
                {
                    desc += "扣除积分 " + UserReducePoint.ToString();
                }
                return desc;
            }
        }

        public static Mall_CheckRequestDetail[] GetMall_CheckRequestDetailShiLi(Mall_CheckRequestDetail[] list, List<string> conditions, List<SqlParameter> parameters)
        {
            if (list.Length > 0)
            {
                var check_rule_list = Mall_CheckRequestRule.GetMall_CheckRequestRules().ToArray();
                var rule_list = GetList<Mall_CheckInfoDetail>("select * from [Mall_CheckInfo] where [ID] in (select [RuleID] from [Mall_CheckRequestRule] where [RequestID] in (select ID from [Mall_CheckRequest] where " + string.Join(" and ", conditions.ToArray()) + "))", parameters).ToArray();
                var check_user_list = Mall_CheckRequestUser.GetMall_CheckRequestUsers().ToArray();
                var user_list = GetList<User>("select * from [User] where [UserID] in (select [UserID] from [Mall_CheckRequestUser] where [RequestID] in (select ID from [Mall_CheckRequest] where " + string.Join(" and ", conditions.ToArray()) + "))", parameters).ToArray();
                var category_list = Mall_CheckCategory.GetMall_CheckCategories();
                foreach (var item in list)
                {
                    var my_check_user_list = check_user_list.Where(p => p.RequestID == item.ID).ToArray();
                    if (my_check_user_list.Length > 0)
                    {
                        List<int> UserIDList = my_check_user_list.Select(p => p.UserID).ToList();
                        var my_user_list = user_list.Where(p => UserIDList.Contains(p.UserID)).ToArray();
                        item.CheckUserInfo = string.Join(",", my_user_list.Select(p => p.FinalRealName));
                        item.CheckUserPosition = string.Join(",", my_user_list.Where(p => !string.IsNullOrEmpty(p.PositionName)).Select(p => p.PositionName));
                    }
                    var my_check_rule_list = check_rule_list.Where(p => p.RequestID == item.ID).ToArray();
                    if (my_check_rule_list.Length > 0)
                    {
                        List<int> RuleIDList = my_check_rule_list.Select(p => p.RuleID).ToList();
                        var my_rule_list = rule_list.Where(p => RuleIDList.Contains(p.ID)).ToArray();
                        List<int> CategoryIDList = my_rule_list.Select(p => p.CheckCategoryID).ToList();
                        var my_category_list = category_list.Where(p => CategoryIDList.Contains(p.ID)).ToList();
                        if (item.RequestType <= 1)
                        {
                            if (my_category_list.Count > 0)
                            {
                                item.CheckCategoryName = string.Join(",", my_category_list.Select(p => p.CategoryName));
                            }
                            if (my_rule_list.Length > 0)
                            {
                                item.CheckRule = string.Join(",", my_rule_list.Select(p => p.CheckName));
                            }
                        }
                        else
                        {
                            item.CheckCategoryName = my_check_rule_list[0].Title;
                            item.CheckRule = item.RequestTypeDesc;
                        }
                        item.UserEarnPoint = my_check_rule_list.Where(p => p.EarnType == 1).Sum(p => p.PointValue);
                        item.UserReducePoint = my_check_rule_list.Where(p => p.EarnType == 2).Sum(p => p.PointValue);
                    }
                }
            }
            return list;
        }
        public static Ui.DataGrid GetMall_CheckRequestDetailGridByKeywords(string Keywords, int CheckType, int approvestatus, int confirmstatus, int processstatus, string orderBy, long startRowIndex, int pageSize, int UserID, int RequestType)
        {
            long totalRows = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (RequestType > 0)
            {
                conditions.Add("(isnull([RequestType],1)=@RequestType)");
                parameters.Add(new SqlParameter("@RequestType", RequestType));
            }
            if (UserID > 0)
            {
                conditions.Add("[ID] in (select [RequestID] from [Mall_CheckRequestUser] where [UserID]=@UserID)");
                parameters.Add(new SqlParameter("@UserID", UserID));
            }
            if (CheckType > 0)
            {
                conditions.Add("[ID] in (select [RequestID] from [Mall_CheckRequestRule] where [EarnType]=@CheckType)");
                parameters.Add(new SqlParameter("@CheckType", CheckType));
            }
            if (processstatus > -1)
            {
                conditions.Add("([ProcessStatus]=@ProcessStatus)");
                parameters.Add(new SqlParameter("@ProcessStatus", processstatus));
            }
            if (approvestatus > -1)
            {
                conditions.Add("([ApproveStatus]=@ApproveStatus)");
                parameters.Add(new SqlParameter("@ApproveStatus", approvestatus));
            }
            if (confirmstatus == 2)
            {
                conditions.Add("([ConfirmStatus]=2)");
            }
            else if (confirmstatus == 1)
            {
                conditions.Add("([IsJieXiaoPointSent]=1)");
            }
            if (!string.IsNullOrEmpty(Keywords))
            {
                conditions.Add("(ID in (select [RequestID] from [Mall_CheckRequestRule] where [RuleID] in (select [ID] from [Mall_CheckInfo] where [CheckName] like @keywords or [CheckCategoryID] in (select [ID] from [Mall_CheckCategory] where [CategoryName] like @Keywords))))");
                parameters.Add(new SqlParameter("@Keywords", "%" + Keywords + "%"));
            }
            string fieldList = "[Mall_CheckRequest].* ";
            string Statement = " from [Mall_CheckRequest] where  " + string.Join(" and ", conditions.ToArray());
            Mall_CheckRequestDetail[] list = GetList<Mall_CheckRequestDetail>(fieldList, Statement, parameters, orderBy, startRowIndex, pageSize, out totalRows).ToArray();
            list = GetMall_CheckRequestDetailShiLi(list, conditions, parameters);
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.total = totalRows;
            dg.page = pageSize;
            if (list.Length == 0)
            {
                dg.rows = new int[] { };
                return dg;
            }
            var sysUserList = User.GetSysUserList();
            foreach (var item in list)
            {
                var myUser = sysUserList.FirstOrDefault(p => p.LoginName.Equals(item.ApproveMan));
                if (myUser != null)
                {
                    item.ApproveMan = myUser.FinalRealName;
                }
            }
            dg.rows = list;
            return dg;
        }
        public static Mall_CheckRequestDetail[] GetMall_CheckRequestDetailListByConfirmStatus(int confirmstatus, string orderBy, long startRowIndex, int pageSize, int UserID)
        {
            if (UserID <= 0)
            {
                return new Mall_CheckRequestDetail[] { };
            }
            long totalRows = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[ApproveStatus]=1");
            conditions.Add("[ID] in (select [RequestID] from [Mall_CheckRequestUser] where [UserID]=@UserID)");
            parameters.Add(new SqlParameter("@UserID", UserID));
            if (confirmstatus >= 0)
            {
                conditions.Add("([ConfirmStatus]=@ConfirmStatus)");
                parameters.Add(new SqlParameter("@ConfirmStatus", confirmstatus));
            }
            string fieldList = "[Mall_CheckRequest].* ";
            string Statement = " from [Mall_CheckRequest] where  " + string.Join(" and ", conditions.ToArray());
            Mall_CheckRequestDetail[] list = GetList<Mall_CheckRequestDetail>(fieldList, Statement, parameters, orderBy, startRowIndex, pageSize, out totalRows).ToArray();
            list = GetMall_CheckRequestDetailShiLi(list, conditions, parameters);
            return list;
        }
    }
}
