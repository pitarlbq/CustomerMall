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
    /// This object represents the properties and methods of a PayService.
    /// </summary>
    public partial class PayService : EntityBase
    {
        public static PayService[] GetPayServiceList(List<int> RoomIDList, DateTime StartTime, DateTime EndTime, int UserID = 0, List<int> EqualProjectIDList = null, List<int> InProjectIDList = null)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            List<string> cmdlist = new List<string>();
            conditions.Add("1=1");
            conditions.Add("isnull([Status],3)=3");
            if (InProjectIDList != null && InProjectIDList.Count > 0)
            {
                cmdlist = new List<string>();
                cmdlist = ViewRoomFeeHistory.GetProjectIDListConditions(InProjectIDList, IncludeRelation: false, RoomIDName: "[ProjectID]", UserID: UserID);

            }
            if (EqualProjectIDList != null && EqualProjectIDList.Count > 0)
            {
                cmdlist.Add("([ProjectID] in (" + string.Join(",", EqualProjectIDList.ToArray()) + "))");
            }
            if (cmdlist.Count > 0)
            {
                conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
            }
            if (StartTime > DateTime.MinValue)
            {
                conditions.Add("Convert(nvarchar(10),[PayTime],120)>=@StartTime");
                parameters.Add(new SqlParameter("@StartTime", StartTime));
            }
            if (EndTime > DateTime.MinValue)
            {
                conditions.Add("Convert(nvarchar(10),[PayTime],120)<=@EndTime");
                parameters.Add(new SqlParameter("@EndTime", EndTime));
            }
            if (RoomIDList.Count > 0)
            {
                cmdlist = new List<string>();
                cmdlist = ViewRoomFeeHistory.GetRoomIDListConditions(RoomIDList, IncludeRelation: false, RoomIDName: "[ProjectID]");
                conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
            }
            string Statement = @" select * from PayService where " + string.Join(" and ", conditions);
            PayService[] list = GetList<PayService>(Statement, parameters).ToArray();
            return list;
        }
        public static PayService GetPayServiceByPrintID(int PrintID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (PrintID > 0)
            {
                conditions.Add("[PrintID]=@PrintID");
                parameters.Add(new SqlParameter("@PrintID", PrintID));
            }
            string Statement = @"select top 1 * from PayService where " + string.Join(" and ", conditions);
            return GetOne<PayService>(Statement, parameters);
        }
    }
}
