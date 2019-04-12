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
    /// This object represents the properties and methods of a Mall_DoorRemoteUserTime.
    /// </summary>
    public partial class Mall_DoorRemoteUserTime : EntityBase
    {
        public static Mall_DoorRemoteUserTime[] GetMall_DoorRemoteUserTimeListByRoomIDList(List<int> RoomIDList)
        {
            if (RoomIDList.Count == 0)
            {
                return new Mall_DoorRemoteUserTime[] { };
            }
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            List<string> cmdlist = ViewRoomFeeHistory.GetRoomIDListConditions(RoomIDList, RoomIDName: "[RoomID]");
            conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
            return GetList<Mall_DoorRemoteUserTime>("select * from [Mall_DoorRemoteUserTime] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
        public static Mall_DoorRemoteUserTime[] GetMall_DoorRemoteUserTimeListUserID(int UserID, int SelfUserID = 0)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            string cmdwhere = "and [RoomPhoneRelationID] in (select [ID] from [RoomPhoneRelation] where [UserID]=@UserID)";
            if (SelfUserID > 0)
            {
                cmdwhere = " and [RoomPhoneRelationID] in (select [ID] from [RoomPhoneRelation] where[UserID]=@UserID or [UserID]=@SelfUserID)";
                parameters.Add(new SqlParameter("@SelfUserID", SelfUserID));
            }
            string cmdtext = "select * from [Mall_DoorRemoteUserTime] where [Enable]=1 and [StartTime]<=@NowTime and EndTime>=@NowTime" + cmdwhere;
            parameters.Add(new SqlParameter("@UserID", UserID));
            parameters.Add(new SqlParameter("@NowTime", DateTime.Now));
            return GetList<Mall_DoorRemoteUserTime>(cmdtext, parameters).ToArray();
        }
    }
    public partial class Mall_DoorRemoteUserTimeDetail : EntityBaseReadOnly
    {
        [DatabaseColumn("RoomID")]
        public int RoomID { get; set; }
        [DatabaseColumn("FullName")]
        public string FullName { get; set; }
        [DatabaseColumn("Name")]
        public string Name { get; set; }
        [DatabaseColumn("TimeID")]
        public int TimeID { get; set; }
        [DatabaseColumn("DelayDate")]
        public DateTime DelayDate { get; set; }
        [DatabaseColumn("StartTime")]
        public DateTime StartTime { get; set; }
        [DatabaseColumn("EndTime")]
        public DateTime EndTime { get; set; }
        [DatabaseColumn("FeeStartTime")]
        public DateTime FeeStartTime { get; set; }

        [DatabaseColumn("FeeID")]
        public int FeeID { get; set; }

        [DatabaseColumn("APPRegisterCount")]
        public int APPRegisterCount { get; set; }

        [DatabaseColumn("IsDisable")]
        public bool IsDisable { get; set; }
        [DatabaseColumn("AllParentID")]
        public string AllParentID { get; set; }
        public string IsDisableDesc
        {
            get
            {
                return this.IsDisable ? "停用" : "启用";
            }
        }

        public string APPRegisterStatusDesc
        {
            get
            {
                return this.APPRegisterCount > 0 ? "已注册" : "未注册";
            }
        }
        public string LastTimeRange
        {
            get
            {
                string desc = string.Empty;
                if (this.StartTime > DateTime.MinValue)
                {
                    desc += this.StartTime.ToString("yyyy-MM-dd");
                }
                else
                {
                    desc += "--";
                }
                if (!string.IsNullOrEmpty(desc))
                {
                    desc += " 至 ";
                }
                if (this.FinalFeeEndTime > DateTime.MinValue)
                {
                    desc += this.FinalFeeEndTime.ToString("yyyy-MM-dd");
                }
                return desc;
            }
        }
        public DateTime FinalFeeEndTime
        {
            get
            {
                if (this.FeeStartTime > DateTime.MinValue)
                {
                    return this.FeeStartTime.AddDays(-1);
                }
                if (this.EndTime > DateTime.MinValue)
                {
                    return this.EndTime;
                }
                return DateTime.MinValue;
            }
        }
        public DateTime ActiveEndTime
        {
            get
            {
                DateTime _ActiveEndTime = DateTime.MinValue;
                var siteconfig = new Utility.SiteConfig();
                DateTime _FirstOpenDoorExpireTime = siteconfig.FirstOpenDoorExpireTime;
                if (this.FinalFeeEndTime == DateTime.MinValue && this.DelayDate == DateTime.MinValue)
                {
                    return _FirstOpenDoorExpireTime;
                }
                if (this.DelayDate == DateTime.MinValue)
                {
                    _ActiveEndTime = this.FinalFeeEndTime.AddDays(1);
                }
                else if (this.FinalFeeEndTime > this.DelayDate)
                {
                    _ActiveEndTime = this.FinalFeeEndTime.AddDays(1);
                }
                else
                {
                    _ActiveEndTime = this.DelayDate.AddDays(1);
                }
                if (_ActiveEndTime < _FirstOpenDoorExpireTime)
                {
                    _ActiveEndTime = _FirstOpenDoorExpireTime;
                }
                return _ActiveEndTime;
            }
        }
        public static string CommColumnCommand = @"select [Project].ID as RoomID,Project.DefaultOrder,Project.isParent,Project.AllParentID,[Project].FullName,Project.Name,Mall_DoorRemoteUserTime.DelayDate,Mall_DoorRemoteUserTime.ID as TimeID,Mall_DoorRemoteUserTime.IsDisable,(select count(1) from [Mall_UserProject] where [Mall_UserProject].ProjectID=Project.ID and isnull([Mall_UserProject].IsDisable,0)=0) as APPRegisterCount,(select top 1 [StartTime] from [RoomFeeHistory] where [ChargeID] in (select ID from [ChargeSummary] where [ChargeFeeType]=1) and ChargeState in (1,4) and [RoomID]=[Project].ID order by ChargeTime desc) as StartTime,(select top 1 [EndTime] from [RoomFeeHistory] where [ChargeID] in (select ID from [ChargeSummary] where [ChargeFeeType]=1) and ChargeState in (1,4) and [RoomID]=[Project].ID order by ChargeTime desc) as EndTime,(select top 1 [StartTime] from [RoomFee] where [ChargeID] in (select ID from [ChargeSummary] where [ChargeFeeType]=1) and [RoomID]=[Project].ID and StartTime is not null order by StartTime asc) as FeeStartTime,(select top 1 [ID] from [RoomFee] where [ChargeID] in (select ID from [ChargeSummary] where [ChargeFeeType]=1) and [RoomID]=[Project].ID and StartTime is not null order by StartTime asc) as FeeID from Project left join [Mall_DoorRemoteUserTime] on [Mall_DoorRemoteUserTime].RoomID=Project.ID";
        public static Ui.DataGrid GetMall_DoorRemoteUserTimeDetailGridByKeywords(string keywords, long startRowIndex, int pageSize, List<int> ProjectIDList, List<int> RoomIDList)
        {
            long totalRows = 0;
            string OrderBy = " order by [DefaultOrder] asc";
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("isnull([isParent],0)=0");
            if (ProjectIDList.Count > 0)
            {
                List<string> cmdlist = new List<string>();
                foreach (var ProjectID in ProjectIDList)
                {
                    cmdlist.Add("([AllParentID] like '%," + ProjectID + ",%' or [RoomID] =" + ProjectID + ")");
                }
                conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
            }
            if (RoomIDList.Count > 0)
            {
                List<string> cmdlist = ViewRoomFeeHistory.GetRoomIDListConditions(RoomIDList, IncludeRelation: false);
                conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
            }
            if (!string.IsNullOrEmpty(keywords))
            {
                conditions.Add("([Name] like @keywords or [RoomID] in (select [RoomID] from [RoomPhoneRelation] where [RelatePhoneNumber] like @keywords or [RelationName] like @keywords) or [RoomID] in (select [ProjectID] from [Mall_UserProject] where isnull([IsDisable],0)=0 and [UserID] in (select [UserID] from [User] where LoginName like @keywords)))");
                parameters.Add(new SqlParameter("@keywords", "%" + keywords + "%"));
            }
            string fieldList = "A.*";
            string Statement = " from (" + CommColumnCommand + ")A where  " + string.Join(" and ", conditions.ToArray());
            Mall_DoorRemoteUserTimeDetail[] list = GetList<Mall_DoorRemoteUserTimeDetail>(fieldList, Statement, parameters, OrderBy, startRowIndex, pageSize, out totalRows).ToArray();
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
        public static void GetMall_DoorRemoteUserTimeDetailListUserID(int UserID, out bool IsExpire, out bool IsBeforeThreeDayExpire, out List<int> ExpireProjectIDList, int SelfUserID = 0)
        {
            ExpireProjectIDList = new List<int>();
            IsExpire = false;
            IsBeforeThreeDayExpire = false;
            List<SqlParameter> parameters = new List<SqlParameter>();
            string cmdwhere = " and [RoomID] in (select [ProjectID] from [Mall_UserProject] where [UserID]=@UserID and isnull([IsDisable],0)=0)";
            if (SelfUserID > 0)
            {
                cmdwhere = " and [RoomID] in (select [ProjectID] from [Mall_UserProject] where isnull([IsDisable],0)=0 and ([UserID]=@UserID or [UserID]=@SelfUserID))";
                parameters.Add(new SqlParameter("@SelfUserID", SelfUserID));
            }
            cmdwhere += " and (isParent is null or isParent=0) and (IsDisable is null or IsDisable=0)";
            string cmdtext = "select * from (" + CommColumnCommand + ")A where 1=1 " + cmdwhere;
            parameters.Add(new SqlParameter("@UserID", UserID));
            var list = GetList<Mall_DoorRemoteUserTimeDetail>(cmdtext, parameters).ToArray();
            if (list.Length == 0)
            {
                return;
            }
            var sys_config = SysConfig.GetSysConfigByName(SysConfigNameDefine.NotifyOpenDoorBeforeFeeDay.ToString());
            int NotifyOpenDoorBeforeFeeDay = 4;
            if (sys_config != null && !string.IsNullOrEmpty(sys_config.Value))
            {
                int.TryParse(sys_config.Value, out NotifyOpenDoorBeforeFeeDay);
                NotifyOpenDoorBeforeFeeDay = (NotifyOpenDoorBeforeFeeDay > 0) ? NotifyOpenDoorBeforeFeeDay + 1 : 4;
            }
            var list1 = list.Where(p => !p.IsDisable && p.ActiveEndTime <= DateTime.Now && p.FeeID > 0).ToArray();
            IsExpire = list1.Length > 0;
            var list2 = list.Where(p => !p.IsDisable && DateTime.Now.AddDays(NotifyOpenDoorBeforeFeeDay) >= p.ActiveEndTime && DateTime.Now <= p.ActiveEndTime && p.FeeID > 0).ToArray();
            IsBeforeThreeDayExpire = list2.Length > 0;
            ExpireProjectIDList = string.Join(",", list1.Select(p => p.AllParentID).ToArray()).Split(',').Select(p =>
            {
                if (string.IsNullOrEmpty(p))
                    return -1;
                else
                    return Convert.ToInt32(p);
            }).Distinct().ToList();
        }

        protected override void EnsureParentProperties()
        {
        }
    }
}
