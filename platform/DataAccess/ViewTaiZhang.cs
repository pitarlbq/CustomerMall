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
    /// This object represents the properties and methods of a ViewTaiZhang.
    /// </summary>
    public partial class ViewTaiZhang : EntityBaseReadOnly
    {
        [DatabaseColumn("CalculateReducePoint")]
        public decimal CalculateReducePoint { get; set; }
        [DatabaseColumn("RelationCount")]
        public int RelationCount { get; set; }
        [DatabaseColumn("ReationID")]
        public int ReationID { get; set; }
        [DatabaseColumn("ProjectBiaoID")]
        public int ProjectBiaoID { get; set; }
        public string FinalBiaoName
        {
            get
            {
                return this.BiaoName;
            }
        }
        public string FinalBiaoCategory
        {
            get
            {
                return this.BiaoCategory;
            }
        }
        public decimal FinalStartPoint
        {
            get
            {
                if (this.ImportStartPoint >= 0)
                {
                    return this.ImportStartPoint;
                }
                return this.StartPoint;
            }
        }
        public decimal FinalEndPoint
        {
            get
            {
                if (this.ImportEndPoint >= 0)
                {
                    return this.ImportEndPoint;
                }
                return this.EndPoint;
            }
        }
        public decimal FinalTotalPoint
        {
            get
            {
                decimal totalpoint = (this.FinalEndPoint - this.FinalStartPoint) * (this.Rate > 0 ? this.Rate : 0) - this.FinalReducePoint;
                return totalpoint > 0 ? totalpoint : 0;
            }
        }
        public decimal FinalUnitPrice
        {
            get
            {
                if (this.ImportUnitPrice >= 0)
                {
                    return this.ImportUnitPrice;
                }
                if (this.UnitPrice > 0)
                {
                    return this.UnitPrice;
                }
                if (this.SummaryUnitPrice > 0)
                {
                    return this.SummaryUnitPrice;
                }
                return 0;
            }
        }
        public decimal FinalReducePoint
        {
            get
            {
                if (!this.BiaoGuiGe.Equals("总表"))
                {
                    return this.ReducePoint > 0 ? this.ReducePoint : 0;
                }
                if (this.WriteDate == DateTime.MinValue)
                {
                    return 0;
                }
                var list = ViewImportFeeDetail2.GetViewImportFeeDetail2ListByWriteDate(this.WriteDate, this.ID);
                return list.Sum(p => p.FinalTotalPoint);
            }
        }
        public decimal FinalCoefficient
        {
            get
            {
                if (this.BiaoCoefficient > 0)
                {
                    return this.BiaoCoefficient;
                }
                if (this.Coefficient > 0)
                {
                    return this.Coefficient;
                }
                return 0;
            }
        }
        public decimal FinalTotalPrice
        {
            get
            {
                decimal totalprice = (this.FinalTotalPoint * this.FinalUnitPrice * (this.FinalCoefficient > 0 ? this.FinalCoefficient : 1));
                return totalprice > 0 ? Math.Round(totalprice, 2, MidpointRounding.AwayFromZero) : 0;
            }
        }
        private static ChargePriceRange[] PriceRangeList;
        private static ChargePriceRange[] GetPriceRangeList()
        {
            if (PriceRangeList == null || PriceRangeList.Length == 0)
            {
                PriceRangeList = ChargePriceRange.GetChargePriceRangeList();
            }
            return PriceRangeList;
        }
        private static decimal GetJieTiUnitPrice(int ChargeID, decimal _CalculateUseCount)
        {
            decimal JieTieUnitPrice = 0;
            var ChargePriceRangeList = GetPriceRangeList();
            foreach (var item in ChargePriceRangeList)
            {
                if (item.SummaryID == ChargeID)
                {
                    if (_CalculateUseCount >= Convert.ToDecimal(item.MinValue) && _CalculateUseCount < Convert.ToDecimal(item.MaxValue))
                    {
                        JieTieUnitPrice = item.BasePrice;
                        break;
                    }
                }
            }
            return JieTieUnitPrice;
        }
        public static ViewTaiZhang[] GetViewTaiZhangListByWriteDate(DateTime WriteDate, int ID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[WriteDate]=@WriteDate");
            conditions.Add("[ProjectBiaoID]=@ID");
            conditions.Add("[BiaoGuiGe]!='总表'");
            parameters.Add(new SqlParameter("@WriteDate", WriteDate));
            parameters.Add(new SqlParameter("@ID", ID));
            string cmdtext = @"select * from (select [ViewTaiZhang].*,[ProjectBiao_Relation].ReationID,[ProjectBiao_Relation].ProjectBiaoID from [ProjectBiao_Relation] left join [ViewTaiZhang] on [ViewTaiZhang].ID=[ProjectBiao_Relation].ReationID)A where " + string.Join(" and ", conditions.ToArray());
            return GetList<ViewTaiZhang>(cmdtext, parameters).ToArray();
        }
        public static Ui.DataGrid GetViewTaiZhangGridByKeywords(string Keywords, List<int> RoomIDList, List<int> ProjectIDList, int BiaoID, int IsActive, int ID, int RelationStatus, string orderBy, long startRowIndex, int pageSize, int UserID = 0, bool canexport = false)
        {
            long totalRows = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("isnull(FullName,'')!=''");
            string cmdcondition = ",0 as RelationCount";
            if (ID > 0)
            {
                conditions.Add("[ID]!=@ProjectBiaoID");
                conditions.Add("[BiaoGuiGe]!='总表'");
                if (RelationStatus == 1)
                {
                    conditions.Add("[ID] in (select [ReationID] from [ProjectBiao_Relation] where [ProjectBiaoID]=@ProjectBiaoID)");
                }
                else if (RelationStatus == 0)
                {
                    conditions.Add("[ID] not in (select [ReationID] from [ProjectBiao_Relation] where [ProjectBiaoID]=@ProjectBiaoID)");
                }
                cmdcondition = ",(select count(1) from [ProjectBiao_Relation] where [ProjectBiaoID]=@ProjectBiaoID and [ReationID]=[ViewTaiZhang].ID) as RelationCount";
                parameters.Add(new SqlParameter("@ProjectBiaoID", ID));
            }
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
                conditions.Add("([FullName] like @Keywords or [Name] like @Keywords or [BiaoName] like @Keywords)");
                parameters.Add(new SqlParameter("@Keywords", "%" + Keywords + "%"));
            }
            if (BiaoID > 0)
            {
                conditions.Add("[BiaoID]=@BiaoID");
                parameters.Add(new SqlParameter("@BiaoID", BiaoID));
            }
            if (IsActive > int.MinValue)
            {
                conditions.Add("[IsActive]=@IsActive");
                parameters.Add(new SqlParameter("@IsActive", IsActive));
            }
            string fieldList = @"[ViewTaiZhang].*,
(select sum((isnull(ViewTaiZhang_2.[EndPoint],0)-isnull(ViewTaiZhang_2.StartPoint,0))*
(case when ViewTaiZhang_2.UnitPrice>0 then  
ViewTaiZhang_2.UnitPrice else ViewTaiZhang_2.SummaryUnitPrice end)-ViewTaiZhang_2.Rate) from ViewTaiZhang as ViewTaiZhang_2 where ViewTaiZhang_2.ID
in (select ReationID from ProjectBiao_Relation where ProjectBiaoID=ViewTaiZhang.ID)) as CalculateReducePoint " + cmdcondition;
            string Statement = " from [ViewTaiZhang] where  " + string.Join(" and ", conditions.ToArray());
            ViewTaiZhang[] list = new ViewTaiZhang[] { };
            if (canexport)
            {
                list = GetList<ViewTaiZhang>("select " + fieldList + Statement + " " + orderBy, parameters).ToArray();
                totalRows = list.Length;
            }
            else
            {
                list = GetList<ViewTaiZhang>(fieldList, Statement, parameters, orderBy, startRowIndex, pageSize, out totalRows).ToArray();
            }
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
        public static ViewTaiZhang[] GetViewTaiZhangListByIDs(List<int> IDList)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("isnull(FullName,'')!=''");
            if (IDList.Count > 0)
            {
                conditions.Add("[ID] in (" + string.Join(",", IDList.ToArray()) + ")");
            }
            string Statement = @"select *,
(select sum((isnull(ViewTaiZhang_2.[EndPoint],0)-isnull(ViewTaiZhang_2.StartPoint,0))*
(case when ViewTaiZhang_2.UnitPrice>0 then  
ViewTaiZhang_2.UnitPrice else ViewTaiZhang_2.SummaryUnitPrice end)-ViewTaiZhang_2.Rate) from ViewTaiZhang as ViewTaiZhang_2 where ViewTaiZhang_2.ID
in (select ReationID from ProjectBiao_Relation where ProjectBiaoID=ViewTaiZhang.ID)) as CalculateReducePoint from [ViewTaiZhang] where  " + string.Join(" and ", conditions.ToArray()) + " order by [DefaultOrder] asc";
            ViewTaiZhang[] list = GetList<ViewTaiZhang>(Statement, parameters).ToArray();
            return list;
        }
        public string IsActiveDesc
        {
            get
            {
                return this.IsActive ? "生效" : "作废";
            }
        }
        public string RelationStatusDesc
        {
            get
            {
                return this.RelationCount > 0 ? "已关联" : "未关联";
            }
        }
    }
}
