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
    /// This object represents the properties and methods of a Mall_DoorCard.
    /// </summary>
    public partial class Mall_DoorCard : EntityBase
    {
        public static Ui.DataGrid GetMall_DoorCardGridByKeywords(string keywords, long startRowIndex, int pageSize)
        {
            long totalRows = 0;
            string OrderBy = " order by [AddTime] asc";
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (!string.IsNullOrEmpty(keywords))
            {
                conditions.Add("([CardName] like @keywords or [CardSummary] like @keywords or [CardUID] like @keywords)");
                parameters.Add(new SqlParameter("@keywords", "%" + keywords + "%"));
            }
            string fieldList = "[Mall_DoorCard].*";
            string Statement = " from [Mall_DoorCard] where  " + string.Join(" and ", conditions.ToArray());
            Mall_DoorCard[] list = GetList<Mall_DoorCard>(fieldList, Statement, parameters, OrderBy, startRowIndex, pageSize, out totalRows).ToArray();
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
        public string ExpireDateDesc
        {
            get
            {
                if (this.EndDays > 0 && this.ExpireDate == DateTime.MinValue)
                {
                    this.ExpireDate = DateTime.Now.AddDays(this.EndDays);
                }
                if (this.ExpireDate > DateTime.MinValue)
                {
                    return this.ExpireDate.ToString("yyyy-MM-dd");
                }
                return "";
            }
        }
    }
    public partial class Mall_DoorCardDetail : Mall_DoorCard
    {
        public string UserInfo { get; set; }
        public string DeviceInfo { get; set; }
        [DatabaseColumn("StartTime")]
        public DateTime StartTime { get; set; }
        [DatabaseColumn("EndTime")]
        public DateTime EndTime { get; set; }
        [DatabaseColumn("FeeStartTime")]
        public DateTime FeeStartTime { get; set; }
        public DateTime FinalFeeEndTime
        {
            get
            {
                DateTime _ActiveEndTime = DateTime.MinValue;
                var siteconfig = new Utility.SiteConfig();
                DateTime _FirstOpenDoorExpireTime = siteconfig.FirstOpenDoorExpireTime;
                if (this.FeeStartTime > DateTime.MinValue)
                {
                    _ActiveEndTime = this.FeeStartTime.AddDays(-1);
                }
                else if (this.EndTime > DateTime.MinValue)
                {
                    _ActiveEndTime = this.EndTime;
                }
                if (_ActiveEndTime < _FirstOpenDoorExpireTime)
                {
                    _ActiveEndTime = _FirstOpenDoorExpireTime;
                }
                return _ActiveEndTime;
            }
        }
        public string FeeEndDateDesc
        {
            get
            {
                return this.FinalFeeEndTime > DateTime.MinValue ? this.FinalFeeEndTime.ToString("yyyy-MM-dd") : string.Empty;
            }
        }
        public static Ui.DataGrid GetMall_DoorCardDetailGridByKeywords(string keywords, long startRowIndex, int pageSize, List<int> ProjectIDList, List<int> RoomIDList, DateTime StartTime, DateTime EndTime)
        {
            long totalRows = 0;
            string OrderBy = " order by [CardName] asc, [SortOrder] asc, [AddTime] desc";
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (StartTime > DateTime.MinValue)
            {
                conditions.Add("Convert(nvarchar(10),[AddTime],120)>=@StartTime");
                parameters.Add(new SqlParameter("@StartTime", StartTime));
            }
            if (EndTime > DateTime.MinValue)
            {
                conditions.Add("Convert(nvarchar(10),[AddTime],120)<=@EndTime");
                parameters.Add(new SqlParameter("@EndTime", EndTime));
            }
            if (!string.IsNullOrEmpty(keywords))
            {
                conditions.Add("([CardName] like @keywords or [CardSummary] like @keywords or [CardUID] like @keywords or [DoorNumber] like @keywords or ([ID] in (select [DoorCardID] from [Mall_DoorCardDevice] where [DoorDeviceID] in (select [DeviceID] from [Mall_DoorDevice] where [DeviceName] like @keywords))))");
                parameters.Add(new SqlParameter("@keywords", "%" + keywords + "%"));
            }
            List<int> EqualIDList = new List<int>();
            List<int> InIDList = new List<int>();
            if (ProjectIDList.Count > 0 && RoomIDList.Count == 0)
            {
                Project.GetMyProjectListByProjectIDList(ProjectIDList, out EqualIDList, out InIDList);
            }
            List<string> cmdlist = new List<string>();
            if (RoomIDList.Count > 0)
            {
                conditions.Add("exists(select 1 from [RoomPhoneRelation] where [ID]=[A].[RoomPhoneRelationID] and[RoomID] in (" + string.Join(",", RoomIDList.ToArray()) + "))");
            }
            if (EqualIDList.Count > 0)
            {
                cmdlist.Add("[ProjectID] in (" + string.Join(",", EqualIDList.ToArray()) + ")");
                cmdlist.Add("exists(select 1 from [RoomPhoneRelation] where [ID]=[A].[RoomPhoneRelationID] and exists(select 1 from [Project] where ID=[RoomPhoneRelation].[RoomID] and [ProjectID] in (" + string.Join(",", EqualIDList.ToArray()) + ")))");
                conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
            }
            if (InIDList.Count > 0)
            {
                cmdlist = new List<string>();
                foreach (var InID in InIDList)
                {
                    cmdlist.Add("([ProjectID] in (select ID from [Project] where AllParentID like '%," + InID.ToString() + ",%'))");
                    cmdlist.Add("exists(select 1 from [RoomPhoneRelation] where [ID]=[A].[RoomPhoneRelationID] and exists(select 1 from [Project] where ID=[RoomPhoneRelation].[RoomID] and AllParentID like '%," + InID.ToString() + ",%'))");
                }
                conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
            }
            string fieldList = "[A].*";
            string Statement = " from (select *,(select top 1 [StartTime] from [RoomFeeHistory] where [ChargeID] in (select ID from [ChargeSummary] where [ChargeFeeType]=1) and ChargeState in (1,4) and [RoomID] in (select [RoomID] from [RoomPhoneRelation] where [ID]=[Mall_DoorCard].RoomPhoneRelationID) order by ChargeTime desc) as StartTime,(select top 1 [EndTime] from [RoomFeeHistory] where [ChargeID] in (select ID from [ChargeSummary] where [ChargeFeeType]=1) and ChargeState in (1,4) and [RoomID] in (select [RoomID] from [RoomPhoneRelation] where [ID]=[Mall_DoorCard].RoomPhoneRelationID) order by ChargeTime desc) as EndTime,(select top 1 [StartTime] from [RoomFee] where [ChargeID] in (select ID from [ChargeSummary] where [ChargeFeeType]=1) and [RoomID] in (select [RoomID] from [RoomPhoneRelation] where [ID]=[Mall_DoorCard].RoomPhoneRelationID) and StartTime is not null order by StartTime asc) as FeeStartTime from [Mall_DoorCard])A where  " + string.Join(" and ", conditions.ToArray());
            Mall_DoorCardDetail[] list = GetList<Mall_DoorCardDetail>(fieldList, Statement, parameters, OrderBy, startRowIndex, pageSize, out totalRows).ToArray();
            if (list.Length > 0)
            {
                var mList = list.Where(p => p.UserID > 0).ToArray();
                int MinUserID = 0;
                int MaxUserID = 0;
                if (mList.Length > 0)
                {
                    MinUserID = mList.Min(p => p.UserID);
                    MaxUserID = mList.Max(p => p.UserID);
                }
                var userList = User.GetSysUserList(IncludeLock: false, MinUserID: MinUserID, MaxUserID: MaxUserID);
                List<int> card_idlist = list.Select(p => p.ID).ToList();
                var card_device_list = Mall_DoorCardDevice.GetMall_DoorCardDevices().Where(p => card_idlist.Contains(p.DoorCardID)).ToArray();
                var device_list = Mall_DoorDevice.GetALLActiveMall_DoorDeviceList().ToArray();
                mList = list.Where(p => p.RoomPhoneRelationID > 0).ToArray();
                int MinID = 0;
                int MaxID = 0;
                if (mList.Length > 0)
                {
                    MinID = mList.Min(p => p.RoomPhoneRelationID);
                    MaxID = mList.Max(p => p.RoomPhoneRelationID);
                }
                var relationList = RoomPhoneRelation.GetRoomPhoneRelationListByMinMaxID(MinID, MaxID);
                int MinRoomID = 0;
                int MaxRoomID = 0;
                if (relationList.Length > 0)
                {
                    MinRoomID = relationList.Min(p => p.RoomID);
                    MaxRoomID = relationList.Max(p => p.RoomID);
                }
                var projectList = Project.GetProjectListByMinMaxID(MinRoomID, MaxRoomID);
                foreach (var item in list)
                {
                    var my_card_device_list = card_device_list.Where(p => p.DoorCardID == item.ID).ToArray();
                    List<int> my_deviceidlist = my_card_device_list.Select(p => p.DoorDeviceID).ToList();
                    var my_device_list = device_list.Where(p => my_deviceidlist.Contains(p.DeviceID)).ToArray();
                    if (my_device_list.Length > 0)
                    {
                        item.DeviceInfo = string.Join(",", my_device_list.Select(p =>
                        {
                            return "【" + p.DeviceID + "," + p.DeviceName + "】";
                        }).ToArray());
                    }
                    var myRelation = relationList.FirstOrDefault(p => p.ID == item.RoomPhoneRelationID);
                    if (myRelation != null)
                    {
                        var myProject = projectList.FirstOrDefault(p => p.ID == myRelation.RoomID);
                        item.UserInfo = myRelation.RelationName;
                        if (myProject != null)
                        {
                            item.UserInfo += "【" + myProject.FullName + "-" + myProject.Name + "】";
                        }
                    }
                    var myUser = userList.FirstOrDefault(q => q.LoginName == item.AddUserName);
                    if (myUser != null)
                    {
                        item.AddUserName = myUser.FinalRealName;
                    }
                }
            }
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
    }
    public partial class Mall_DoorCardAnalysis : EntityBaseReadOnly
    {
        [DatabaseColumn("Title")]
        public string Title { get; set; }
        [DatabaseColumn("Total")]
        public int Total { get; set; }
        public static Ui.DataGrid GetMall_DoorCardAnalysisGridByKeywords(string keywords, long startRowIndex, int pageSize, List<int> ProjectIDList, List<int> RoomIDList, DateTime StartTime, DateTime EndTime)
        {
            long totalRows = 0;
            string OrderBy = " order by [Title] desc";
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (StartTime > DateTime.MinValue)
            {
                conditions.Add("Convert(nvarchar(10),[AddTime],120)>=@StartTime");
                parameters.Add(new SqlParameter("@StartTime", StartTime));
            }
            if (EndTime > DateTime.MinValue)
            {
                conditions.Add("Convert(nvarchar(10),[AddTime],120)<=@EndTime");
                parameters.Add(new SqlParameter("@EndTime", EndTime));
            }
            if (!string.IsNullOrEmpty(keywords))
            {
                conditions.Add("([CardName] like @keywords or [CardSummary] like @keywords or [CardUID] like @keywords or [DoorNumber] like @keywords or ([ID] in (select [DoorCardID] from [Mall_DoorCardDevice] where [DoorDeviceID] in (select [DeviceID] from [Mall_DoorDevice] where [DeviceName] like @keywords))))");
                parameters.Add(new SqlParameter("@keywords", "%" + keywords + "%"));
            }
            List<int> EqualIDList = new List<int>();
            List<int> InIDList = new List<int>();
            if (ProjectIDList.Count > 0 && RoomIDList.Count == 0)
            {
                Project.GetMyProjectListByProjectIDList(ProjectIDList, out EqualIDList, out InIDList);
            }
            List<string> cmdlist = new List<string>();
            if (RoomIDList.Count > 0)
            {
                conditions.Add("exists(select 1 from [RoomPhoneRelation] where [ID]=[Mall_DoorCard].[RoomPhoneRelationID] and [RoomID] in (" + string.Join(",", RoomIDList.ToArray()) + "))");
            }
            if (EqualIDList.Count > 0)
            {
                cmdlist.Add("[ProjectID] in (" + string.Join(",", EqualIDList.ToArray()) + ")");
                cmdlist.Add("exists(select 1 from [RoomPhoneRelation] where [ID]=[Mall_DoorCard].[RoomPhoneRelationID] and exists(select 1 from [Project] where ID=[RoomPhoneRelation].[RoomID] and [ProjectID] in (" + string.Join(",", EqualIDList.ToArray()) + ")))");
                conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
            }
            if (InIDList.Count > 0)
            {
                cmdlist = new List<string>();
                foreach (var InID in InIDList)
                {
                    cmdlist.Add("([ProjectID] in (select ID from [Project] where AllParentID like '%," + InID.ToString() + ",%'))");
                    cmdlist.Add("exists(select 1 from [RoomPhoneRelation] where [ID]=[Mall_DoorCard].[RoomPhoneRelationID] and exists(select 1 from [Project] where ID=[RoomPhoneRelation].[RoomID] and AllParentID like '%," + InID.ToString() + ",%'))");
                }
                conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
            }
            string fieldList = "A.*";
            string Statement = " from (select Convert(nvarchar(10),AddTime,120) as Title,count(1) as Total from Mall_DoorCard where " + string.Join(" and ", conditions.ToArray()) + " group by Convert(nvarchar(10),AddTime,120))A";
            Mall_DoorCardAnalysis[] list = GetList<Mall_DoorCardAnalysis>(fieldList, Statement, parameters, OrderBy, startRowIndex, pageSize, out totalRows).ToArray();
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
        protected override void EnsureParentProperties()
        {
        }
    }
}
