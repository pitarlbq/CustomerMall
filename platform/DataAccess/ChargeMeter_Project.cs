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
    /// This object represents the properties and methods of a ChargeMeter_Project.
    /// </summary>
    public partial class ChargeMeter_Project : EntityBase
    {
        public static int GetChargeMeter_ProjectCountbyIDList(int[] IDList)
        {
            var parameters = new List<SqlParameter>();
            string cmdtext = "select count(1) from [ChargeMeter_Project] where [MeterTotalPoint]>0 and [ID] in (" + string.Join(",", IDList) + ")";
            int total = 0;
            using (SqlHelper helper = new SqlHelper())
            {
                var result = helper.ExecuteScalar(cmdtext, CommandType.Text, parameters);
                if (result != null)
                {
                    int.TryParse(result.ToString(), out total);
                }
            }
            return total;
        }
        public static void Save_ChargeMeter_Project(ChargeMeter_Project data, ChargeMeter meter, SqlHelper helper)
        {
            data.MeterName = meter.MeterName;
            data.MeterNumber = meter.MeterNumber;
            data.MeterCategoryID = meter.MeterCategoryID;
            data.MeterType = meter.MeterType;
            data.MeterSpec = meter.MeterSpec;
            data.MeterCoefficient = meter.MeterCoefficient;
            data.MeterRemark = meter.MeterRemark;
            data.MeterChargeID = meter.MeterChargeID;
            data.MeterHouseNo = meter.MeterHouseNo;
            data.MeterLocation = meter.MeterLocation;
            data.SortOrder = meter.SortOrder;
            data.WriteStatus = 0;
            data.FeeStatus = 0;
            data.Save(helper);
        }
        public static ChargeMeter_Project[] GetChargeMeterProjectListbyMeterID(int MeterID)
        {
            var parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@MeterID", MeterID));
            string cmdtext = "select * from [ChargeMeter_Project] where [MeterID]=@MeterID";
            return GetList<ChargeMeter_Project>(cmdtext, parameters).ToArray();
        }
        public string APPMeterName
        {
            get
            {
                string name = string.Empty;
                if (!string.IsNullOrEmpty(this.MeterName))
                {
                    name += this.MeterName;
                }
                if (!string.IsNullOrEmpty(name))
                {
                    name += " ";
                }
                if (!string.IsNullOrEmpty(this.MeterNumber))
                {
                    name += this.MeterNumber;
                }
                return name;
            }
        }
        public string FinalMeterName
        {
            get
            {
                if (!string.IsNullOrEmpty(this.MeterNumber))
                {
                    return this.MeterNumber;
                }
                if (!string.IsNullOrEmpty(this.MeterName))
                {
                    return this.MeterName;
                }
                return "未知仪表";
            }
        }
        /// <summary>
        /// 0-未抄 1-已抄 2-禁止抄表
        /// </summary>
        public int PointStatus
        {
            get
            {
                if (!this.IsAPPWriteEnable)
                {
                    return 2;
                }
                if (this.MeterTotalPoint > 0)
                {
                    return 1;
                }
                return 0;
            }
        }
        public string PointStatusDesc
        {
            get
            {
                if (this.PointStatus == 0)
                {
                    return "未抄";
                }
                if (this.PointStatus == 1)
                {
                    return "已抄";
                }
                return "禁止抄表";
            }
        }
        public string APPWriteStatusDesc
        {
            get
            {
                return this.IsAPPWriteEnable ? "启用" : "停用";
            }
        }
        public string WriteStatusDesc
        {
            get
            {
                if (this.FeeStatus == 1)
                {
                    return "完成抄表";
                }
                if (this.WriteStatus == 0)
                {
                    return "开始抄表";
                }
                if (this.WriteStatus == 1)
                {
                    return "完成抄表";
                }
                return string.Empty;
            }
        }
        public string FeeStatusDesc
        {
            get
            {
                return this.FeeStatus == 1 ? "已生成" : "未生成";
            }
        }
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
        public static int GetMeterCategoryID(string MeterCategoryName)
        {
            if (MeterCategoryName.Equals("水表"))
            {
                return 1;
            }
            if (MeterCategoryName.Equals("电表"))
            {
                return 2;
            }
            if (MeterCategoryName.Equals("气表"))
            {
                return 3;
            }
            return 0;
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
        public static int GetMeterTypeID(string MeterTypeName)
        {
            if (MeterTypeName.Equals("住户"))
            {
                return 1;
            }
            if (MeterTypeName.Equals("公共"))
            {
                return 2;
            }
            return 0;
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
        public static int GetMeterSpec(string MeterSpecDesc)
        {
            if (MeterSpecDesc.Equals("分表"))
            {
                return 1;
            }
            if (MeterSpecDesc.Equals("总表"))
            {
                return 2;
            }
            return 0;
        }
    }
    public partial class ChargeMeter_ProjectDetail : ChargeMeter_Project
    {
        [DatabaseColumn("ProjectName")]
        public string ProjectName { get; set; }

        [DatabaseColumn("FullName")]
        public string FullName { get; set; }
        [DatabaseColumn("DefaultOrder")]
        public string DefaultOrder { get; set; }
        [DatabaseColumn("isParent")]
        public bool isParent { get; set; }
        [DatabaseColumn("FeeEndPoint")]
        public decimal FeeEndPoint { get; set; }
        [DatabaseColumn("RoomOwnerCount")]
        public int RoomOwnerCount { get; set; }

        [DatabaseColumn("AllParentID")]
        public string AllParentID { get; set; }
        public decimal FinalFrontStartPoint
        {
            get
            {
                if (this.WriteStatus == 0)
                {
                    return this.FeeEndPoint > 0 ? this.FeeEndPoint : 0;
                }
                return this.MeterStartPoint > 0 ? this.MeterStartPoint : 0;
            }
        }
        public decimal FinalFrontEndPoint
        {
            get
            {
                this.MeterEndPoint = this.MeterEndPoint > 0 ? this.MeterEndPoint : 0;
                return this.MeterEndPoint > this.FinalFrontStartPoint ? this.MeterEndPoint : this.FinalFrontStartPoint;
            }
        }
        public decimal FinalFrontTotalPoint
        {
            get
            {
                decimal total = (this.FinalFrontEndPoint - this.FinalFrontStartPoint) * this.MeterCoefficient;
                return total > 0 ? total : 0;
            }
        }
        public decimal FinalFeeStartPoint
        {
            get
            {
                this.MeterStartPoint = this.MeterStartPoint > 0 ? this.MeterStartPoint : 0;
                return this.MeterStartPoint;
            }
        }
        public decimal FinalFeeEndPoint
        {
            get
            {
                this.MeterEndPoint = this.MeterEndPoint > 0 ? this.MeterEndPoint : 0;
                return this.MeterEndPoint;
            }
        }
        public decimal FinalFeeTotalPoint
        {
            get
            {
                decimal result = (this.FinalFeeEndPoint - this.FinalFeeStartPoint) * this.MeterCoefficient;
                result = result > 0 ? result : 0;
                result = Math.Round(result, 2, MidpointRounding.AwayFromZero);
                return result;
            }
        }
        public decimal FinalStartPoint
        {
            get
            {
                this.FeeEndPoint = this.FeeEndPoint > 0 ? this.FeeEndPoint : 0;
                this.MeterStartPoint = this.MeterStartPoint > 0 ? this.MeterStartPoint : 0;
                return this.FeeEndPoint > this.MeterStartPoint ? this.FeeEndPoint : this.MeterStartPoint;
            }
        }
        public decimal FinalEndPoint
        {
            get
            {
                this.MeterEndPoint = this.MeterEndPoint > 0 ? this.MeterEndPoint : 0;
                return this.MeterEndPoint > this.FinalFrontStartPoint ? this.MeterEndPoint : this.FinalFrontStartPoint;
            }
        }
        public decimal FinalTotalPoint
        {
            get
            {
                decimal result = (this.FinalEndPoint - this.FinalStartPoint) * this.MeterCoefficient;
                result = result > 0 ? result : 0;
                result = Math.Round(result, 2, MidpointRounding.AwayFromZero);
                return result;
            }
        }
        public string FinalName
        {
            get
            {
                return this.isParent ? this.FullName : this.FullName + "-" + this.ProjectName;
            }
        }
        public static string CommSqlText = @"select [ChargeMeter_Project].*,[Project].[Name] as ProjectName,[Project].[FullName],[Project].[isParent],[Project].[DefaultOrder],[Project].AllParentID,(select top 1 MeterEndPoint from [ChargeMeter_Project_Point] where [ChargeMeter_ProjectID]=[ChargeMeter_Project].ID order by MeterEndPoint desc) as FeeEndPoint from [ChargeMeter_Project] left join [Project] on [Project].ID=[ChargeMeter_Project].ProjectID";
        public static Ui.DataGrid GetChargeMeter_ProjectDetailGridByKeywords(string Keywords, List<int> RoomIDList, List<int> ProjectIDList, int MeterCategoryID, int MeterType, int MeterChargeID, string orderBy, long startRowIndex, int pageSize, int UserID = 0, bool canexport = false, bool IsWritePoint = false)
        {
            long totalRows = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (ProjectIDList.Count > 0)
            {
                List<string> cmdlist = ViewRoomFeeHistory.GetProjectIDListConditions(ProjectIDList, IncludeRelation: false, RoomIDName: "[ProjectID]", UserID: UserID);
                conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
            }
            if (RoomIDList.Count > 0)
            {
                List<string> cmdlist = ViewRoomFeeHistory.GetRoomIDListConditions(RoomIDList, IncludeRelation: false, RoomIDName: "[ProjectID]");
                conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
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
            string cmdcolumns = string.Empty;
            ChargeMeter_ProjectDetail[] list = new ChargeMeter_ProjectDetail[] { };
            if (canexport)
            {
                string cmdtext = "select * from (" + CommSqlText + ") as A where  " + string.Join(" and ", conditions.ToArray()) + " order by " + orderBy;
                list = GetList<ChargeMeter_ProjectDetail>(cmdtext, parameters).ToArray();
            }
            else
            {
                string fieldList = @"A.*";
                string Statement = " from (" + CommSqlText + ") as A where  " + string.Join(" and ", conditions.ToArray());
                list = GetList<ChargeMeter_ProjectDetail>(fieldList, Statement, parameters, orderBy, startRowIndex, pageSize, out totalRows).ToArray();
            }
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
        public static ChargeMeter_ProjectDetail[] GetChargeMeter_ProjectDetailListByIDList(int[] IDList, int MeterType = 1)
        {
            if (IDList.Length == 0)
            {
                return new ChargeMeter_ProjectDetail[] { };
            }
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[ID] in (" + string.Join(",", IDList) + ")");
            conditions.Add("MeterType=@MeterType");
            parameters.Add(new SqlParameter("@MeterType", MeterType));
            string cmdtext = "select * from (select [ChargeMeter_Project].*,(select count(1) from [RoomPhoneRelation] where [RoomPhoneRelation].[RoomID]=[ChargeMeter_Project].[ProjectID]) as RoomOwnerCount from [ChargeMeter_Project]) as A where  " + string.Join(" and ", conditions.ToArray());
            var list = GetList<ChargeMeter_ProjectDetail>(cmdtext, parameters).ToArray();
            return list;
        }
        public static void GetChargeMeter_ProjectDetailRoomIDList(int RoomID, out int PreRoomID, out int NextRoomID, out int CurrentRoomID, string keywords = "", List<int> ALLProjectIDList = null, int UserID = 0, int ProjectID = 0)
        {
            PreRoomID = 0;
            NextRoomID = 0;
            CurrentRoomID = 0;
            var parameters = new List<SqlParameter>();
            var conditions = new List<string>();
            conditions.Add("[IsAPPWriteEnable]=1");
            conditions.Add("[MeterType]=1");
            var list = new ChargeMeter_Project[] { };
            if (ALLProjectIDList != null && ALLProjectIDList.Count > 0)
            {
                List<string> cmdlist = ViewRoomFeeHistory.GetProjectIDListConditions(ALLProjectIDList, IncludeRelation: false, RoomIDName: "[ProjectID]", UserID: UserID);
                conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
            }
            if (!string.IsNullOrEmpty(keywords))
            {
                conditions.Add("([Project].[Name] like @keywords or [Project].[FullName] like @keywords)");
                parameters.Add(new SqlParameter("@keywords", "%" + keywords + "%"));

            }
            if (ProjectID > 0)
            {
                conditions.Add("([Project].[ID]=@ProjectID or [Project].[AllParentID] like @AllParentID)");
                parameters.Add(new SqlParameter("@ProjectID", ProjectID));
                parameters.Add(new SqlParameter("@AllParentID", "%," + ProjectID + ",%"));
            }
            list = GetList<ChargeMeter_Project>("select [ChargeMeter_Project].[ProjectID] from [ChargeMeter_Project] left join [Project] on [Project].ID=[ChargeMeter_Project].ProjectID where " + string.Join(" and ", conditions.ToArray()) + " order by [Project].DefaultOrder asc", parameters).ToArray();
            if (list.Length == 0)
            {
                return;
            }
            var ProjectIDList = list.Select(p => p.ProjectID).Distinct().ToArray();
            if (RoomID > 0)
            {
                for (int i = 0; i < ProjectIDList.Length; i++)
                {
                    if (RoomID == ProjectIDList[i])
                    {
                        CurrentRoomID = RoomID;
                        if (i > 0)
                        {
                            PreRoomID = ProjectIDList[i - 1];
                        }
                        if (i < ProjectIDList.Length - 1)
                        {
                            NextRoomID = ProjectIDList[i + 1];
                        }
                    }
                }
                return;
            }
            CurrentRoomID = ProjectIDList[0];
            if (ProjectIDList.Length > 1)
            {
                NextRoomID = ProjectIDList[1];
            }
        }
        public static ChargeMeter_ProjectDetail[] GetChargeMeter_ProjectDetailListByRoomID(int RoomID, List<int> ProjectIDList = null, int MeterType = 1, int UserID = 0, int ProjectID = 0, string keywords = "")
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[IsAPPWriteEnable]=1");
            if (RoomID > 0)
            {
                conditions.Add("[ProjectID]=@RoomID");
                parameters.Add(new SqlParameter("@RoomID", RoomID));
            }
            if (ProjectID > 0)
            {
                conditions.Add("([ProjectID]=@ProjectID or [AllParentID] like @AllParentID)");
                parameters.Add(new SqlParameter("@ProjectID", ProjectID));
                parameters.Add(new SqlParameter("@AllParentID", "%," + ProjectID + ",%"));
            }
            if (!string.IsNullOrEmpty(keywords))
            {
                conditions.Add("([ProjectName] like @keywords or [FullName] like @keywords)");
                parameters.Add(new SqlParameter("@keywords", "%" + keywords + "%"));
            }
            if (MeterType == 1)
            {
                conditions.Add("[MeterType]=1");
                if (ProjectIDList != null && ProjectIDList.Count > 0)
                {
                    List<string> cmdlist = ViewRoomFeeHistory.GetProjectIDListConditions(ProjectIDList, IncludeRelation: false, RoomIDName: "[ProjectID]", UserID: UserID);
                    conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
                }
            }
            else
            {
                conditions.Add("[MeterType]=2");
            }
            string cmdtext = "select * from (" + CommSqlText + ") as A where " + string.Join(" and ", conditions.ToArray());
            ChargeMeter_ProjectDetail[] list = GetList<ChargeMeter_ProjectDetail>(cmdtext, parameters).ToArray();
            return list;
        }
        public static ChargeMeter_ProjectDetail GetChargeMeter_ProjectDetailByID(int ID, SqlHelper helper)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("ID=@ID");
            parameters.Add(new SqlParameter("@ID", ID));
            string cmdtext = "select * from (" + CommSqlText + ") as A where  " + string.Join(" and ", conditions.ToArray());
            return GetOne<ChargeMeter_ProjectDetail>(cmdtext, parameters, helper);
        }
    }
}
