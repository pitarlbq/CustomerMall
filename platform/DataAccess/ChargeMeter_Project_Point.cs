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
    /// This object represents the properties and methods of a ChargeMeter_Project_Point.
    /// </summary>
    public partial class ChargeMeter_Project_Point : EntityBase
    {
        public static void Save_ChargeMeter_Project_Point(ChargeMeter_Project data, SqlHelper helper)
        {
            var data_detail = ChargeMeter_ProjectDetail.GetChargeMeter_ProjectDetailByID(data.ID, helper);
            var point = new ChargeMeter_Project_Point();
            point.MeterFullName = data_detail.FinalName;
            point.ChargeMeter_ProjectID = data.ID;
            point.ProjectID = data.ProjectID;
            point.MeterID = data.MeterID;
            point.MeterName = data.MeterName;
            point.MeterNumber = data.MeterNumber;
            point.MeterCategoryID = data.MeterCategoryID;
            point.MeterType = data.MeterType;
            point.MeterSpec = data.MeterSpec;
            point.MeterCoefficient = data.MeterCoefficient;
            point.MeterRemark = data.MeterRemark;
            point.MeterChargeID = data.MeterChargeID;
            point.MeterHouseNo = data.MeterHouseNo;
            point.MeterLocation = data.MeterLocation;
            point.SortOrder = data.SortOrder;
            point.MeterStartPoint = data.MeterStartPoint;
            point.MeterEndPoint = data.MeterEndPoint;
            point.MeterTotalPoint = data.MeterTotalPoint;
            point.AddTime = data.AddTime;
            point.AddUserName = data.AddUserName;
            point.WriteStatus = data.WriteStatus;
            point.FeeStatus = data.FeeStatus;
            point.WriteDate = data.WriteDate;
            point.WriteUserName = data.WriteUserName;
            point.IsAPPWriteEnable = data.IsAPPWriteEnable;
            point.UpdateTime = DateTime.Now;
            point.UpdateUserName = User.GetCurrentUserName();
            point.Save(helper);
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
    public partial class ChargeMeter_Project_PointDetail : ChargeMeter_Project_Point
    {
        [DatabaseColumn("ProjectName")]
        public string ProjectName { get; set; }

        [DatabaseColumn("FullName")]
        public string FullName { get; set; }
        [DatabaseColumn("DefaultOrder")]
        public string DefaultOrder { get; set; }
        [DatabaseColumn("isParent")]
        public bool isParent { get; set; }
        [DatabaseColumn("ChargeName")]
        public string ChargeName { get; set; }
        public string FinalFullName
        {
            get
            {
                if (!string.IsNullOrEmpty(this.MeterFullName))
                {
                    return this.MeterFullName;
                }
                return this.isParent ? this.FullName : this.FullName + "-" + this.ProjectName;
            }
        }
        public string FinalChargeName
        {
            get
            {
                return this.ChargeName;
            }
        }
        public static string CommSqlText = ",(select [Name] from [ChargeSummary] where [ID]=[ChargeMeter_Project_Point].[MeterChargeID]) as ChargeName,(select [Name] from [Project] where ID=[ChargeMeter_Project_Point].ProjectID) as ProjectName,(select [FullName] from [Project] where ID=[ChargeMeter_Project_Point].ProjectID) as FullName,(select [isParent] from [Project] where ID=[ChargeMeter_Project_Point].ProjectID) as isParent,(select [DefaultOrder] from [Project] where ID=[ChargeMeter_Project_Point].ProjectID) as DefaultOrder";
        public static Ui.DataGrid GetChargeMeter_Project_PointDetailGridByKeywords(string Keywords, int MeterCategoryID, int MeterType, int MeterChargeID, string orderBy, long startRowIndex, int pageSize, List<int> MeterProjectIDList, int UserID = 0, bool canexport = false)
        {
            long totalRows = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            if (MeterProjectIDList.Count == 0)
            {
                return new Ui.DataGrid();
            }
            conditions.Add("[ChargeMeter_ProjectID] in (" + string.Join(",", MeterProjectIDList.ToArray()) + ")");
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
            ChargeMeter_Project_PointDetail[] list = new ChargeMeter_Project_PointDetail[] { };
            if (canexport)
            {
                string cmdtext = "select * from (select [ChargeMeter_Project_Point].* " + CommSqlText + " from [ChargeMeter_Project_Point]) as A where  " + string.Join(" and ", conditions.ToArray()) + " order by " + orderBy;
                list = GetList<ChargeMeter_Project_PointDetail>(cmdtext, parameters).ToArray();
            }
            else
            {
                string fieldList = @"A.*";
                string Statement = " from (select [ChargeMeter_Project_Point].* " + CommSqlText + " from [ChargeMeter_Project_Point]) as A where  " + string.Join(" and ", conditions.ToArray());
                list = GetList<ChargeMeter_Project_PointDetail>(fieldList, Statement, parameters, orderBy, startRowIndex, pageSize, out totalRows).ToArray();
            }
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
    }
}
