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
    /// This object represents the properties and methods of a ChargeMeter.
    /// </summary>
    public partial class ChargeMeter : EntityBase
    {
        public string MeterCategoryName
        {
            get
            {
                if (this.MeterCategoryID == 1)
                {
                    return "水表";
                }
                if (this.MeterCategoryID == 2)
                {
                    return "电表";
                }
                if (this.MeterCategoryID == 3)
                {
                    return "气表";
                }
                return "";
            }
        }
        public string MeterTypeName
        {
            get
            {
                if (this.MeterType == 1)
                {
                    return "住户";
                }
                if (this.MeterType == 2)
                {
                    return "公共";
                }
                return "";
            }
        }
        public string MeterSpecDesc
        {
            get
            {
                if (this.MeterSpec == 1)
                {
                    return "分表";
                }
                if (this.MeterSpec == 2)
                {
                    return "总表";
                }
                return "";
            }
        }
    }
    public partial class ChargeMeterDetail : ChargeMeter
    {
        [DatabaseColumn("ChargeName")]
        public string ChargeName { get; set; }
        public static Ui.DataGrid GetChargeMeterDetailGridByKeywords(string Keywords, List<int> RoomIDList, List<int> ProjectIDList, int MeterCategoryID, int MeterType, int MeterChargeID, string orderBy, long startRowIndex, int pageSize, int UserID = 0, bool canexport = false)
        {
            long totalRows = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (ProjectIDList.Count > 0)
            {
                List<string> cmdlist = ViewRoomFeeHistory.GetProjectIDListConditions(ProjectIDList, IncludeRelation: false, RoomIDName: "[ProjectID]", UserID: UserID);
                conditions.Add("[ID] in (select [MeterID] from [ChargeMeter_Project] where (" + string.Join(" or ", cmdlist.ToArray()) + "))");
            }
            if (RoomIDList.Count > 0)
            {
                List<string> cmdlist = ViewRoomFeeHistory.GetRoomIDListConditions(RoomIDList, IncludeRelation: false, RoomIDName: "[ProjectID]");
                conditions.Add("[ID] in (select [MeterID] from [ChargeMeter_Project] where (" + string.Join(" or ", cmdlist.ToArray()) + "))");
            }
            if (!string.IsNullOrEmpty(Keywords))
            {
                conditions.Add("([MeterName] like @Keywords or [MeterNumber] like @Keywords)");
                parameters.Add(new SqlParameter("@Keywords", "%" + Keywords + "%"));
            }
            if (MeterCategoryID > 0)
            {
                conditions.Add("[MeterCategoryID]=@MeterCategoryID");
                parameters.Add(new SqlParameter("@MeterCategoryID", MeterCategoryID));
            }
            if (MeterType > 0)
            {
                conditions.Add("[MeterType]=@MeterType");
                parameters.Add(new SqlParameter("@MeterType", MeterType));
            }
            if (MeterChargeID > 0)
            {
                conditions.Add("[MeterChargeID]=@MeterChargeID");
                parameters.Add(new SqlParameter("@MeterChargeID", MeterChargeID));
            }
            ChargeMeterDetail[] list = new ChargeMeterDetail[] { };
            if (canexport)
            {
                string cmdtext = "select * from (select [ChargeMeter].*,(select [Name] from [ChargeSummary] where [ID]=[ChargeMeter].[MeterChargeID]) as ChargeName from [ChargeMeter]) as A where  " + string.Join(" and ", conditions.ToArray()) + " order by " + orderBy;
                list = GetList<ChargeMeterDetail>(cmdtext, parameters).ToArray();
            }
            else
            {
                string fieldList = @"A.*";
                string Statement = " from (select [ChargeMeter].*,(select [Name] from [ChargeSummary] where [ID]=[ChargeMeter].[MeterChargeID]) as ChargeName from [ChargeMeter]) as A where  " + string.Join(" and ", conditions.ToArray());
                list = GetList<ChargeMeterDetail>(fieldList, Statement, parameters, orderBy, startRowIndex, pageSize, out totalRows).ToArray();
            }
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
    }
}
