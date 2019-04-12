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
    /// This object represents the properties and methods of a SysConfig_Project.
    /// </summary>
    public partial class SysConfig_Project : EntityBase
    {
        public static SysConfig_Project[] Get_SysConfig_ProjectList(int ProjectID)
        {
            if (ProjectID <= 1)
            {
                return new SysConfig_Project[] { };
            }
            var parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@ProjectID", ProjectID));
            string cmdtext = "select * from [SysConfig_Project] where [ProjectID]=@ProjectID";
            return GetList<SysConfig_Project>(cmdtext, parameters).ToArray();
        }
        public static ViewRoomFee[] GetNotifyViewRoomFee(ViewRoomFee[] list)
        {
            var RoomIDList = list.Select(p => p.RoomID).Distinct().ToArray();
            int MinProjectID = 0;
            int MaxProjectID = 0;
            if (list.Length > 0)
            {
                MinProjectID = list.Min(p => p.RoomID);
                MaxProjectID = list.Max(p => p.RoomID);
            }
            var sysConfigList = SysConfig.GetSysConfigListByName(SysConfigNameDefine.WechatFeeNotify.ToString());
            SysConfig_ProjectDetail[] configProjectList = new SysConfig_ProjectDetail[] { };
            if (sysConfigList.Length > 0)
            {
                configProjectList = SysConfig_ProjectDetail.Get_SysConfig_ProjectListByProjectIDList(MinProjectID, MaxProjectID).Where(p => sysConfigList.Select(q => q.ID).ToArray().Contains(p.ConfigID)).ToArray();
            }
            var newList = new List<ViewRoomFee>();
            foreach (var item in list)
            {
                var myConfigProjectList = configProjectList.Where(p => item.AllParentID.Contains("," + p.ProjectID + ",") || item.RoomID == p.ProjectID).ToArray();
                var mySysConfigList = new List<SysConfig>();
                foreach (var item2 in sysConfigList)
                {
                    var mySysConfig = new SysConfig();
                    mySysConfig.ID = item2.ID;
                    mySysConfig.Name = item2.Name;
                    mySysConfig.Value = item2.Value;
                    mySysConfig.ProjectID = 0;
                    var my_config = myConfigProjectList.Where(p => p.ConfigID == item2.ID).OrderByDescending(p => p.IconID).FirstOrDefault();
                    if (my_config != null)
                    {
                        mySysConfig.Value = my_config.ConfigValue;
                        mySysConfig.ProjectID = my_config.ProjectID;
                    }
                    mySysConfigList.Add(mySysConfig);
                }
                DateTime WechatNotifyTime = DateTime.MinValue;
                bool isOwnFee = IsRoomFeeOwn(item.StartTime, item.EndTime, mySysConfigList.ToArray(), out WechatNotifyTime);
                if (isOwnFee)
                {
                    item.WechatNotifyTime = WechatNotifyTime;
                    newList.Add(item);
                }
            }
            return newList.ToArray();
        }
        public static bool IsRoomFeeOwn(DateTime StartTime, DateTime EndTime, SysConfig[] configList, out DateTime WechatNotifyTime)
        {
            WechatNotifyTime = DateTime.Today;
            var timeConfig = configList.FirstOrDefault(p => p.Name.Equals(SysConfigNameDefine.WechatFeeNotifyTime.ToString()));
            int timeValue = 0;
            if (timeConfig != null)
            {
                int.TryParse(timeConfig.Value, out timeValue);
            }
            if (timeValue <= 0 || timeValue > 4)
            {
                return false;
            }
            var dayConfig = configList.FirstOrDefault(p => p.Name.Equals(SysConfigNameDefine.WechatFeeNotify.ToString()));
            int dayValue = 0;
            if (dayConfig != null)
            {
                int.TryParse(dayConfig.Value, out dayValue);
            }
            if (StartTime > DateTime.MinValue)
            {
                if (timeValue == 1)//开始日期前
                {
                    WechatNotifyTime = StartTime.AddDays(-dayValue);
                }
                if (timeValue == 2)//开始日期后
                {
                    WechatNotifyTime = StartTime.AddDays(dayValue);
                }
            }
            if (EndTime > DateTime.MinValue)
            {
                if (timeValue == 3)//结束日期前
                {
                    WechatNotifyTime = EndTime.AddDays(-dayValue);
                }
                if (timeValue == 4)//结束日期后
                {
                    WechatNotifyTime = EndTime.AddDays(dayValue);
                }
            }
            if (WechatNotifyTime > DateTime.Today)
            {
                return false;
            }
            return true;
        }
    }
    public partial class SysConfig_ProjectDetail : SysConfig_Project
    {
        [DatabaseColumn("AllParentID")]
        public string AllParentID { get; set; }
        [DatabaseColumn("IconID")]
        public int IconID { get; set; }
        public static SysConfig_ProjectDetail[] Get_SysConfig_ProjectListByProjectIDList(int MinProjectID = 0, int MaxProjectID = 0)
        {
            if (MaxProjectID <= 0)
            {
                return new SysConfig_ProjectDetail[] { };
            }
            var parameters = new List<SqlParameter>();
            string cmdtext = "select A.AllParentID,A.IconID,[SysConfig_Project].* from (select ID,AllParentID,IconID from [Project] where ID between " + MinProjectID + " and " + MaxProjectID + " or exists (select 1 from Project as Project_1 where Project_1.ID between " + MinProjectID + " and " + MaxProjectID + " and Project_1.[AllParentID] like '%,'+Convert(nvarchar(20),[Project].ID)+',%'))A left join [SysConfig_Project] on A.ID=[SysConfig_Project].ProjectID where [SysConfig_Project].ConfigValue is not null";
            return GetList<SysConfig_ProjectDetail>(cmdtext, parameters).ToArray();
        }
        public static SysConfig_ProjectDetail GetSysConfig_ProjectDetailByAllParentID(SysConfig_ProjectDetail[] configProjectList, string AllParentID, int RoomID)
        {
            var myConfig = configProjectList.Where(p => AllParentID.Contains("," + p.ProjectID + ",") || p.ProjectID == RoomID).OrderByDescending(p => p.IconID).FirstOrDefault();
            return myConfig;
        }
    }
}
