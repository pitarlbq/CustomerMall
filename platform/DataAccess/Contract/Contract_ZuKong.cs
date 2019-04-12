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
    /// This object represents the properties and methods of a Contract_ZuKong.
    /// </summary>
    public partial class Contract_ZuKong : EntityBase
    {
        public static Contract_ZuKong[] GetContract_ZuKongListByKeywords(List<int> RoomIDList, List<int> ProjectIDList, string Keywords = "", int RoomStateID = 0, int RoomFeeState = 0, DateTime? StartTime = null, DateTime? EndTime = null, int UserID = 0)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            #region 关键字查询
            conditions.Add("[RoomName] like @Keywords");
            parameters.Add(new SqlParameter("@Keywords", "%" + Keywords + "%"));
            #endregion
            if (RoomStateID > 0)
            {
                conditions.Add("[RoomID] in (select [RoomID] from [RoomBasic] where RoomStateID=@RoomStateID)");
                parameters.Add(new SqlParameter("@RoomStateID", RoomStateID));
            }
            if (ProjectIDList.Count > 0)
            {
                List<string> cmdlist = new List<string>();
                foreach (var ProjectID in ProjectIDList)
                {
                    cmdlist.Add("([AllParentID] like '%," + ProjectID + ",%' or [ID] =" + ProjectID + ")");
                }
                conditions.Add("[RoomID] in (select [ID] from [Project] where (" + string.Join(" or ", cmdlist.ToArray()) + "))");
            }
            if (RoomIDList.Count > 0)
            {
                conditions.Add("[RoomID] in (" + string.Join(",", RoomIDList.ToArray()) + ")");
            }

            string Statement = "select * from [Contract_ZuKong] where  " + string.Join(" and ", conditions.ToArray());
            Contract_ZuKong[] list = GetList<Contract_ZuKong>(Statement, parameters).ToArray();
            DateTime NewStartTime = StartTime.HasValue ? Convert.ToDateTime(StartTime) : DateTime.MinValue;
            DateTime NewEndTime = EndTime.HasValue ? Convert.ToDateTime(EndTime) : DateTime.MinValue;
            var NewRoomIDList = list.Select(p => p.RoomID).ToList();
            if (NewRoomIDList.Count > 0)
            {
                var ViewRoomFeeList = RoomFeeAnalysis.GetRoomFeeAnalysisListByTime(NewStartTime, NewEndTime, new List<int>(), NewRoomIDList, UserID: UserID, IsContractWarning: true);
                foreach (var item in list)
                {
                    var viewroomfee = ViewRoomFeeList.Where(p => p.RoomID == item.RoomID).ToList();
                    item.RoomFee = viewroomfee.Sum(p => p.TotalFinalCost);
                }
            }
            if (RoomFeeState == 1)
            {
                list = list.Where(p => p.RoomFee > 0).ToArray();
            }
            else if (RoomFeeState == 2)
            {
                list = list.Where(p => p.RoomFee <= 0).ToArray();
            }
            return list;
        }
    }
}
