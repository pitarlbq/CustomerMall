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
    /// This object represents the properties and methods of a ChargeMoneyType.
    /// </summary>
    public partial class ChargeMoneyType : EntityBase
    {
        public static ChargeMoneyType GetChargeMoneyTypeByChargeName(string ChargeName)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[ChargeTypeName] like @ChargeTypeName");
            parameters.Add(new SqlParameter("@ChargeTypeName", "%" + ChargeName + "%"));
            var data = GetOne<ChargeMoneyType>("select * from " + TableName + " where " + string.Join(" and ", conditions.ToArray()), parameters);
            if (data == null)
            {
                data = new ChargeMoneyType();
                data.ChargeTypeName = ChargeName;
                data.Save();
            }
            return data;
        }
    }
    public class ChargeMoneyTypeDetails : ChargeMoneyType
    {
        [DatabaseColumn("RealCost")]
        public decimal RealCost { get; set; }
        public string FormatRealCost
        {
            get
            {
                return Utility.Tools.FormatMoney(this.RealCost);
            }
        }
        [DatabaseColumn("TotalNumber")]
        public int TotalNumber { get; set; }
        [DatabaseColumn("TotalCount")]
        public decimal TotalCount { get; set; }
        [DatabaseColumn("Cost")]
        public decimal Cost { get; set; }
        public string FormatCost
        {
            get
            {
                return Utility.Tools.FormatMoney(this.Cost);
            }
        }
        public static Ui.DataGrid GetHistorySummaryGroupByRoomFeeOrderID(int RoomFeeOrderID, int UserID = 0)
        {
            return GetHistorySummaryGroupByTypeName(new List<int>(), new List<int>(), DateTime.MinValue, DateTime.MinValue, string.Empty, int.MinValue, int.MinValue, RoomFeeOrderID, true, UserID: UserID);
        }
        public static Ui.DataGrid GetHistorySummaryGroupByTypeName(List<int> RoomIDList, List<int> ProjectIDList, DateTime StartChargeTime, DateTime EndChargeTime, string ChargeMan, int ChargeSummaryID, int ChargeTypeID, int RoomFeeOrderID, int UserID = 0)
        {
            return GetHistorySummaryGroupByTypeName(RoomIDList, ProjectIDList, StartChargeTime, EndChargeTime, ChargeMan, ChargeSummaryID, ChargeTypeID, RoomFeeOrderID, false, UserID: UserID);
        }
        public static ChargeMoneyTypeDetails[] GetHistorySummaryGroupByTypeName(List<int> RoomIDList, List<int> ProjectIDList, DateTime StartChargeTime, DateTime EndChargeTime, List<int> ChargeSummaryIDList, List<int> ChargeTypeIDList, List<int> ChargeStateList, int UserID = 0)
        {
            Ui.DataGrid dg = GetHistorySummaryGroupByTypeName(RoomIDList, ProjectIDList, StartChargeTime, EndChargeTime, string.Empty, ChargeSummaryIDList, ChargeTypeIDList, ChargeStateList, 0, false, string.Empty, UserID: UserID);
            ChargeMoneyTypeDetails[] list = dg.rows as ChargeMoneyTypeDetails[];
            return list;
        }
        public static Ui.DataGrid GetHistorySummaryGroupByTypeName(List<int> RoomIDList, List<int> ProjectIDList, DateTime StartChargeTime, DateTime EndChargeTime, string ChargeMan, int ChargeSummaryID, int ChargeTypeID, int RoomFeeOrderID, bool IsRoomFeeSearch, List<int> HistoryIDList = null, bool DeleteTempHistoryIDList = true, int UserID = 0)
        {
            List<int> ChargeSummaryIDList = new List<int>();
            if (ChargeSummaryID > 0)
            {
                ChargeSummaryIDList.Add(ChargeSummaryID);
            }
            List<int> ChargeTypeIDList = new List<int>();
            if (ChargeTypeID > -1)
            {
                ChargeTypeIDList.Add(ChargeTypeID);
            }
            List<int> ChargeStateList = new List<int>();
            ChargeStateList.Add(1);
            ChargeStateList.Add(4);
            return GetHistorySummaryGroupByTypeName(RoomIDList, ProjectIDList, StartChargeTime, EndChargeTime, ChargeMan, ChargeSummaryIDList, ChargeTypeIDList, ChargeStateList, RoomFeeOrderID, IsRoomFeeSearch, string.Empty, HistoryIDList, DeleteTempHistoryIDList: DeleteTempHistoryIDList, UserID: UserID);
        }
        public static Ui.DataGrid GetHistorySummaryGroupByTypeName(List<int> RoomIDList, List<int> ProjectIDList, DateTime StartChargeTime, DateTime EndChargeTime, string ChargeMan, List<int> ChargeSummaryIDList, List<int> ChargeTypeIDList, List<int> ChargeStateList, int RoomFeeOrderID, bool IsRoomFeeSearch, string OpenID, List<int> HistoryIDList = null, bool DeleteTempHistoryIDList = true, int UserID = 0)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            List<string> conditions2 = new List<string>();
            conditions2.Add("1=1");
            List<string> conditions3 = new List<string>();
            conditions3.Add("1=1");
            if (HistoryIDList != null && HistoryIDList.Count > 0)
            {
                if (HistoryIDList.Count > 2)
                {
                    ViewRoomFeeHistory.CreateTempTable(HistoryIDList, DeleteTempHistoryIDList, UserID: UserID);
                    conditions.Add("EXISTS (SELECT 1 FROM [TempIDs] WHERE id=rfh.HistoryID and UserID=" + UserID + ")");
                    conditions2.Add("EXISTS (SELECT 1 FROM [TempIDs] WHERE id in (select HistoryID from RoomFeeHistory where PrintID=prh.ID) and UserID=" + UserID + ")");
                }
                else if (HistoryIDList.Count > 0)
                {
                    conditions.Add("rfh.HistoryID in (" + string.Join(",", HistoryIDList.ToArray()) + ")");
                    conditions2.Add("prh.ID in (select PrintID from [RoomFeeHistory] where HistoryID in (" + string.Join(",", HistoryIDList.ToArray()) + "))");
                }
            }
            if (!string.IsNullOrEmpty(OpenID))
            {
                conditions.Add("rfh.[RoomID] in (select [ProjectID] from [WechatUser_Project] where [OpenID]=@OpenID)");
                parameters.Add(new SqlParameter("@OpenID", OpenID));
            }
            if (ChargeStateList.Count > 0)
            {
                if (ChargeStateList.Contains(1) || ChargeStateList.Contains(4))
                {
                    conditions2.Add("prh.[IsCancel]=0");
                }
                conditions2.Add("prh.ID in (select PrintID from RoomFeeHistory where ChargeState in (" + string.Join(",", ChargeStateList.ToArray()) + "))");
            }
            if (RoomFeeOrderID > 0)
            {
                conditions2.Add("isnull(prh.[RoomFeeOrderID],0)=@RoomFeeOrderID");
                parameters.Add(new SqlParameter("@RoomFeeOrderID", RoomFeeOrderID));
            }
            else if (IsRoomFeeSearch)
            {
                conditions2.Add("isnull(prh.[RoomFeeOrderID],0)=0");
                conditions2.Add("prh.[ID] in (select [PrintID] from [RoomFeeHistory] where [ChargeID] in (select [ID] from [ChargeSummary] where isnull([IsOrderFeeOn],0)=1) or isnull(ChargeID,0)=0)");
                if (StartChargeTime > DateTime.MinValue)
                {
                    conditions.Add("rfh.[ChargeTime]>=@StartChargeTime");
                    parameters.Add(new SqlParameter("@StartChargeTime", StartChargeTime));
                }
                if (EndChargeTime > DateTime.MinValue)
                {
                    conditions.Add("rfh.[ChargeTime]<=@EndChargeTime");
                    parameters.Add(new SqlParameter("@EndChargeTime", EndChargeTime));
                }
            }
            else
            {
                if (StartChargeTime > DateTime.MinValue)
                {
                    conditions.Add("Convert(nvarchar(10),rfh.[ChargeTime],120)>=@StartChargeTime");
                    parameters.Add(new SqlParameter("@StartChargeTime", StartChargeTime));
                }
                if (EndChargeTime > DateTime.MinValue)
                {
                    conditions.Add("Convert(nvarchar(10),rfh.[ChargeTime],120)<=@EndChargeTime");
                    parameters.Add(new SqlParameter("@EndChargeTime", EndChargeTime));
                }
            }
            if (RoomIDList.Count > 0)
            {
                List<string> cmdlist = ViewRoomFeeHistory.GetRoomIDListConditions(RoomIDList, RoomIDName: "rfh.[RoomID]");
                conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
            }
            if (ProjectIDList.Count > 0)
            {
                List<string> cmdlist = ViewRoomFeeHistory.GetProjectIDListConditions(ProjectIDList, RoomIDName: "rfh.[RoomID]", UserID: UserID);
                conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
            }
            #region 收款人查询
            string cmd = string.Empty;
            if (!string.IsNullOrEmpty(ChargeMan))
            {
                string[] keywords = ChargeMan.Trim().Split(',');
                for (int i = 0; i < keywords.Length; i++)
                {
                    if (string.IsNullOrEmpty(keywords[i].ToString()))
                    {
                        continue;
                    }
                    if (i + 1 == keywords.Length)
                    {
                        if (keywords.Length == 1)
                        {
                            cmd += "  and  (prh.[ChargeMan] like '%" + keywords[i] + "%')";
                        }
                        else
                        {
                            cmd += "  (prh.[ChargeMan] like '%" + keywords[i] + "%'))";
                        }
                    }
                    else if (i == 0)
                    {
                        cmd += " and ((prh.[ChargeMan] like '%" + keywords[i] + "%') or";
                    }
                    else
                    {
                        cmd += "  (prh.[ChargeMan] like '%" + keywords[i] + "%') or ";
                    }
                }
            }
            #endregion
            //if (!string.IsNullOrEmpty(ChargeMan))
            //{
            //    conditions2.Add("prh.[ChargeMan] like '%" + ChargeMan + "%'");
            //}
            if (ChargeSummaryIDList.Count > 0)
            {
                conditions.Add("rfh.[ChargeID] in (" + string.Join(",", ChargeSummaryIDList.ToArray()) + ")");
            }
            if (ChargeTypeIDList.Count > 0)
            {
                conditions2.Add("(prh.[ChageType1] in (" + string.Join(",", ChargeTypeIDList.ToArray()) + ") or prh.[ChageType2] in (" + string.Join(",", ChargeTypeIDList.ToArray()) + "))");
                conditions3.Add("cmt.[ChargeTypeID] in (" + string.Join(",", ChargeTypeIDList.ToArray()) + ")");
            }
            var type_list = GetList<ChargeMoneyTypeDetails>(@"select * from ChargeMoneyType", parameters).ToList();
            var history1 = GetList<ChargeMoneyTypeDetails>(@"select sum(isnull(RealCost,0)-isnull(prh.RealMoneyCost2,0)) as RealCost,prh.ChageType1 as ChargeTypeID from PrintRoomFeeHistory prh where " + string.Join(" and ", conditions2.ToArray()) + cmd + @" and  prh.[ID] in (select [PrintID] from RoomFeeHistory rfh where " + string.Join(" and ", conditions.ToArray()) + @")
Group by prh.ChageType1", parameters).ToArray();
            var history2 = GetList<ChargeMoneyTypeDetails>(@"select sum(isnull(prh.RealMoneyCost2,0)) as RealCost,prh.ChageType2 as ChargeTypeID from PrintRoomFeeHistory prh where " + string.Join(" and ", conditions2.ToArray()) + cmd + @" and  prh.[ID] in (select [PrintID] from RoomFeeHistory rfh where " + string.Join(" and ", conditions.ToArray()) + @")
Group by prh.ChageType2", parameters).ToArray();
            decimal RealCost1 = 0;
            decimal RealCost2 = 0;
            var finalList = new List<ChargeMoneyTypeDetails>();
            foreach (var item in type_list)
            {
                RealCost1 = history1.Where(p => p.ChargeTypeID == item.ChargeTypeID).Sum(p => p.RealCost);
                RealCost2 = history2.Where(p => p.ChargeTypeID == item.ChargeTypeID).Sum(p => p.RealCost);
                if ((RealCost1 + RealCost2) > 0)
                {
                    item.RealCost = RealCost1 + RealCost2;
                    finalList.Add(item);
                }
            }
            var TypeIDList = type_list.Select(p => p.ChargeTypeID).ToList();
            RealCost1 = history1.Where(p => !TypeIDList.Contains(p.ChargeTypeID)).Sum(p => p.RealCost);
            RealCost2 = history2.Where(p => !TypeIDList.Contains(p.ChargeTypeID)).Sum(p => p.RealCost);
            if ((RealCost1 + RealCost2) > 0)
            {
                var item = new ChargeMoneyTypeDetails();
                item.ChargeTypeID = 0;
                item.ChargeTypeName = "其他";
                item.RealCost = (RealCost1 + RealCost2);
                finalList.Add(item);
            }
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = finalList.ToArray();
            dg.total = finalList.Count;
            dg.page = 1;
            return dg;
        }
        public static Ui.DataGrid GetDepositSummaryGroupByRoomFeeOrderID(int RoomFeeOrderID)
        {
            return GetDepositSummaryGroupByTypeName(new List<int>(), new List<int>(), DateTime.MinValue, DateTime.MinValue, int.MinValue, string.Empty, RoomFeeOrderID, true);
        }
        public static Ui.DataGrid GetDepositSummaryGroupByTypeName(List<int> RoomIDList, List<int> ProjectIDList, DateTime StartChargeTime, DateTime EndChargeTime, int CompanyID, string ChargeMan, int RoomFeeOrderID, bool IsRoomFeeSearch, List<int> HistoryIDList = null, bool DeleteTempHistoryIDList = true, int UserID = 0)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            string cmdNow = string.Empty;
            string cmdWhere = string.Empty;
            if (HistoryIDList != null && HistoryIDList.Count > 0)
            {
                if (HistoryIDList.Count > 2)
                {
                    ViewRoomFeeHistory.CreateTempTable(HistoryIDList, DeleteTempHistoryIDList, UserID: UserID);
                    cmdNow += " and EXISTS (SELECT 1 FROM [TempIDs] WHERE id=rfh.HistoryID and UserID=" + UserID + ")";
                }
                else if (HistoryIDList.Count > 0)
                {
                    cmdNow += " and rfh.HistoryID in (" + string.Join(",", HistoryIDList.ToArray()) + ")";
                }

            }
            if (RoomFeeOrderID > 0)
            {
                cmdNow += " and [PrintID] in (select [ID] from [PrintRoomFeeHistory] where isnull([RoomFeeOrderID],0)=@RoomFeeOrderID)";
                parameters.Add(new SqlParameter("@RoomFeeOrderID", RoomFeeOrderID));
            }
            else if (IsRoomFeeSearch)
            {
                cmdNow += " and [PrintID] in (select [ID] from [PrintRoomFeeHistory] where isnull([RoomFeeOrderID],0)=0)";
                cmdNow += " and ([ChargeID] in (select [ID] from [ChargeSummary] where isnull([IsOrderFeeOn],0)=1)  or isnull(ChargeID,0)=0)";
                if (StartChargeTime > DateTime.MinValue)
                {
                    cmdNow += " and [ChargeTime]>=@StartChargeTime";
                    parameters.Add(new SqlParameter("@StartChargeTime", StartChargeTime));
                }
                if (EndChargeTime > DateTime.MinValue)
                {
                    cmdNow += " and [ChargeTime]<=@EndChargeTime";
                    parameters.Add(new SqlParameter("@EndChargeTime", EndChargeTime));
                }
            }
            else
            {
                if (StartChargeTime > DateTime.MinValue)
                {
                    cmdNow += " and Convert(nvarchar(10),[ChargeTime],120)>=@StartChargeTime";
                    parameters.Add(new SqlParameter("@StartChargeTime", StartChargeTime));
                }
                if (EndChargeTime > DateTime.MinValue)
                {
                    cmdNow += " and Convert(nvarchar(10),[ChargeTime],120)<=@EndChargeTime";
                    parameters.Add(new SqlParameter("@EndChargeTime", EndChargeTime));
                }
            }
            #region 收款人查询
            string cmd = string.Empty;
            if (!string.IsNullOrEmpty(ChargeMan))
            {
                string[] keywords = ChargeMan.Trim().Split(',');
                for (int i = 0; i < keywords.Length; i++)
                {
                    if (string.IsNullOrEmpty(keywords[i].ToString()))
                    {
                        continue;
                    }
                    if (i + 1 == keywords.Length)
                    {
                        if (keywords.Length == 1)
                        {
                            cmd += "  and  ([ChargeMan] like '%" + keywords[i] + "%')";
                        }
                        else
                        {
                            cmd += "  ([ChargeMan] like '%" + keywords[i] + "%'))";
                        }
                    }
                    else if (i == 0)
                    {
                        cmd += " and (([ChargeMan] like '%" + keywords[i] + "%') or";
                    }
                    else
                    {
                        cmd += "  ([ChargeMan] like '%" + keywords[i] + "%') or ";
                    }
                }
            }
            cmdNow += cmd;
            #endregion
            //if (!string.IsNullOrEmpty(ChargeMan))
            //{
            //    cmdNow += " and [ChargeMan]=@ChargeMan";
            //    parameters.Add(new SqlParameter("@ChargeMan", ChargeMan));
            //}
            if (CompanyID != 1 && CompanyID > 0)
            {
                cmdWhere += " and [CompanyID]=@CompanyID";
                parameters.Add(new SqlParameter("@CompanyID", CompanyID));
            }
            if (RoomIDList.Count > 0)
            {
                List<string> cmdlist = ViewRoomFeeHistory.GetRoomIDListConditions(RoomIDList, IsContractFee: true);
                cmdNow += " and (" + string.Join(" or ", cmdlist.ToArray()) + ")";
            }
            if (ProjectIDList.Count > 0)
            {
                List<string> cmdlist = ViewRoomFeeHistory.GetProjectIDListConditions(ProjectIDList, IsContractFee: true, UserID: UserID);
                cmdNow += " and (" + string.Join(" or ", cmdlist.ToArray()) + ")";
            }
            var type_list = GetList<ChargeMoneyTypeDetails>(@"select * from ChargeMoneyType", parameters).ToList();
            var history1 = GetList<ChargeMoneyTypeDetails>(@"select sum(isnull(RealMoneyCost2,0)) as RealCost,ChageType2 as ChargeTypeID from PrintRoomFeeHistory 
            where [ID] in (select [PrintID] from RoomFeeHistory rfh where ChargeState in(3,6,7) " + cmdNow + @") 
            group by ChageType2", parameters).ToArray();
            var history2 = GetList<ChargeMoneyTypeDetails>(@"select sum(isnull(RealCost,0)-isnull(RealMoneyCost2,0)) as RealCost,ChageType1 as ChargeTypeID from PrintRoomFeeHistory 
            where [ID] in (select [PrintID] from RoomFeeHistory rfh where ChargeState in(3,6,7) " + cmdNow + @") 
            group by ChageType1", parameters).ToArray();
            decimal RealCost1 = 0;
            decimal RealCost2 = 0;
            var finalList = new List<ChargeMoneyTypeDetails>();
            foreach (var item in type_list)
            {
                RealCost1 = history1.Where(p => p.ChargeTypeID == item.ChargeTypeID).Sum(p => p.RealCost);
                RealCost2 = history2.Where(p => p.ChargeTypeID == item.ChargeTypeID).Sum(p => p.RealCost);
                if ((RealCost1 + RealCost2) > 0)
                {
                    item.RealCost = RealCost1 + RealCost2;
                    finalList.Add(item);
                }
            }
            var ChargeTypeIDList = type_list.Select(p => p.ChargeTypeID).ToList();
            RealCost1 = history1.Where(p => !ChargeTypeIDList.Contains(p.ChargeTypeID)).Sum(p => p.RealCost);
            RealCost2 = history2.Where(p => !ChargeTypeIDList.Contains(p.ChargeTypeID)).Sum(p => p.RealCost);
            if ((RealCost1 + RealCost2) > 0)
            {
                var item = new ChargeMoneyTypeDetails();
                item.ChargeTypeID = 0;
                item.ChargeTypeName = "其他";
                item.RealCost = (RealCost1 + RealCost2);
                finalList.Add(item);
            }
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = finalList.ToArray();
            dg.total = finalList.Count;
            dg.page = 1;
            return dg;
        }
    }
}
