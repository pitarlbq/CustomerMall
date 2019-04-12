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
    /// This object represents the properties and methods of a ViewRoomSourceFee.
    /// </summary>
    public partial class ViewRoomSourceFee : EntityBaseReadOnly
    {
        [DatabaseColumn("RelationName")]
        public string RelationName { get; set; }
        public static ViewRoomSourceFee GetViewRoomSourceFeeByID(int ID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[ID]=@ID");
            parameters.Add(new SqlParameter("@ID", ID));
            return GetOne<ViewRoomSourceFee>("select * from [ViewRoomSourceFee] where " + string.Join(" and ", conditions.ToArray()), parameters);
        }
        public static ViewRoomSourceFee[] GetViewRoomSourceFeeListByKeywords(string Keywords, List<int> RoomID, int ChargeID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[IsStart]=1");
            if (!string.IsNullOrEmpty(Keywords))
            {
                conditions.Add("([Name] like @Keywords or [FullName] like @Keywords or [ChargeName] like @Keywords)");
                parameters.Add(new SqlParameter("@Keywords", "%" + Keywords + "%"));
            }
            if (RoomID.Count > 0)
            {
                conditions.Add("([RoomID] in (" + string.Join(",", RoomID.ToArray()) + ") or [RoomID] in (select [RoomID] from [RoomRelation] where [GUID] in (select [GUID] from [RoomRelation] where [RoomID] in (" + string.Join(",", RoomID.ToArray()) + "))))");
            }
            if (ChargeID > 0)
            {
                conditions.Add("[ChargeID]=@ChargeID");
                parameters.Add(new SqlParameter("@ChargeID", ChargeID));
            }
            ViewRoomSourceFee[] list = new ViewRoomSourceFee[] { };
            list = GetList<ViewRoomSourceFee>("select * from [ViewRoomSourceFee] where  " + string.Join(" and ", conditions.ToArray()) + " order by [RoomID] asc", parameters).ToArray();
            return list;
        }
        public static Ui.DataGrid GetViewRoomSourceFeeGridByKeywords(string Keywords, List<int> RoomIDList, List<int> ProjectIDList, int ChargeID, bool IsRoomFee, bool IsContractFee, string RoomProperty, string orderBy, long startRowIndex, int pageSize, int UserID = 0)
        {
            long totalRows = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[IsStart]=1");
            if (!string.IsNullOrEmpty(RoomProperty))
            {
                conditions.Add("[RoomID] in (select [RoomID] from [RoomBasic] where isnull([RoomProperty],'')=@RoomProperty)");
                parameters.Add(new SqlParameter("@RoomProperty", RoomProperty));
            }
            if (IsRoomFee && !IsContractFee)
            {
                conditions.Add("isnull([ContractID],0)=0");
            }
            if (IsContractFee && !IsRoomFee)
            {
                conditions.Add("isnull([ContractID],0)>0");
            }
            conditions.Add("([RoomID] in (select [RoomID] from [RoomBasic] where isnull([IsLocked],0)=0) or not exists (select * from [RoomBasic] where isnull([IsLocked],0)=0 and [RoomID]=[ViewRoomSourceFee].[RoomID]))");
            if (!string.IsNullOrEmpty(Keywords))
            {
                conditions.Add("([Name] like @Keywords or [FullName] like @Keywords or [ChargeName] like @Keywords)");
                parameters.Add(new SqlParameter("@Keywords", "%" + Keywords + "%"));
            }
            if (ProjectIDList.Count > 0)
            {
                List<string> cmdlist = ViewRoomFeeHistory.GetProjectIDListConditions(ProjectIDList, IncludeRelation: false, UserID: UserID);
                conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
            }
            if (RoomIDList.Count > 0)
            {
                List<string> cmdlist = ViewRoomFeeHistory.GetRoomIDListConditions(RoomIDList, IncludeRelation: false);
                conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
            }
            if (ChargeID > 0)
            {
                conditions.Add("[ChargeID]=@ChargeID");
                parameters.Add(new SqlParameter("@ChargeID", ChargeID));
            }
            string fieldList = "[ViewRoomSourceFee].*,(select top 1 [RelationName] from [RoomPhoneRelation] where isnull([IsDefault],0)=1 and [RoomID]=[ViewRoomSourceFee].[RoomID]) as [RelationName]";
            string Statement = " from [ViewRoomSourceFee] where  " + string.Join(" and ", conditions.ToArray());
            ViewRoomSourceFee[] list = new ViewRoomSourceFee[] { };
            list = GetList<ViewRoomSourceFee>(fieldList, Statement, parameters, orderBy, startRowIndex, pageSize, out totalRows).ToArray();
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
        public string ChargeTypeDesc
        {
            get
            {
                string typedesc = string.Empty;
                switch (this.TypeID)
                {
                    case 1:
                        typedesc = "单价*计费面积(月度)";
                        break;
                    case 2:
                        typedesc = "定额(月度)";
                        break;
                    case 3:
                        typedesc = "单价*计费面积*公摊系数(月度)";
                        break;
                    case 4:
                        typedesc = "定额(年度)";
                        break;
                    case 5:
                        typedesc = "单价*计费面积(按天)";
                        break;
                    case 6:
                        typedesc = "单价*计费面积/用量(一次性)";
                        break;
                    default:
                        break;
                }
                return typedesc;
            }
        }
        public DateTime CalculateEndTime
        {
            get
            {
                DateTime DefaultEndTime = this.EndTime;
                //if (this.FeeType == 1)
                //{
                //    DefaultEndTime = Utility.Tools.GetRoomFeeEndTime(this.FeeType, this.SummaryChargeTypeCount, this.EndNumberType, this.EndTypeID, this.AutoToMonthEnd, this.StartTime);
                //}
                if (this.NewEndTime > DateTime.MinValue)
                {
                    return DefaultEndTime > this.NewEndTime ? this.NewEndTime : DefaultEndTime;
                }
                return DefaultEndTime;
            }
        }
    }
}
