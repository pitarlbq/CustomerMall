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
    /// This object represents the properties and methods of a ViewTempRoomFeeHistory.
    /// </summary>
    public partial class ViewTempRoomFeeHistory : EntityBaseReadOnly
    {
        public decimal FinalStartPoint
        {
            get
            {
                if (this.StartPoint > 0)
                {
                    return this.StartPoint;
                }
                if (this.RoomFeeStartPoint > 0)
                {
                    return this.RoomFeeStartPoint;
                }
                return 0;
            }
        }
        public decimal FinalEndPoint
        {
            get
            {
                if (this.EndPoint > 0)
                {
                    return this.EndPoint;
                }
                if (this.RoomFeeEndPoint > 0)
                {
                    return this.RoomFeeEndPoint;
                }
                return 0;
            }
        }
        public decimal CalculateMonthCount
        {
            get
            {
                int monthnumber = Utility.Tools.calculatemonth(this.StartTime, this.EndTime);
                decimal totaldays = Utility.Tools.calculateTotaldays(this.StartTime, this.EndTime, monthnumber, true);
                int restdays = Utility.Tools.calculateTotaldays(this.StartTime, this.EndTime, monthnumber, false);
                decimal month_count = (monthnumber + (restdays / totaldays));
                return Math.Round(month_count, 0, MidpointRounding.AwayFromZero);
            }
        }
        public static ViewTempRoomFeeHistory[] GetViewTempRoomFeeHistoryListByIDs(List<int> IDs)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();

            if (IDs.Count > 0)
            {
                conditions.Add("[TempHistoryID] in (" + string.Join(",", IDs.ToArray()) + ")");
            }
            ViewTempRoomFeeHistory[] list = new ViewTempRoomFeeHistory[] { };
            list = GetList<ViewTempRoomFeeHistory>("select * from [ViewTempRoomFeeHistory] where  " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
            return list;
        }
        public string FinalRemark
        {
            get
            {
                string desc = this.Remark;
                if (this.ProjectBiaoID > 0 && this.ImportRate > 0)
                {
                    desc += "(表名称:" + this.ImportBiaoName + ")";
                }
                return desc;
            }
        }
    }
}
