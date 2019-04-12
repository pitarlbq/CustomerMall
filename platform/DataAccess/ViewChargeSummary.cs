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
    /// This object represents the properties and methods of a ViewChargeSummary.
    /// </summary>
    public partial class ViewChargeSummary : EntityBaseReadOnly
    {
        [DatabaseColumn("SummaryType")]
        public string SummaryType { get; set; }
        public static Ui.DataGrid GetViewChargeSummaryGrid(int FeeType, int CategoryID, string SummaryType, int ContractID, string guid, string orderBy, long startRowIndex, int pageSize, string keywords)
        {
            long totalRows = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (!string.IsNullOrEmpty(keywords))
            {
                conditions.Add("[Name] like @keywords");
                parameters.Add(new SqlParameter("@keywords", "%" + keywords + "%"));
            }
            if (FeeType > 0)
            {
                conditions.Add("[FeeType]=@FeeType");
                parameters.Add(new SqlParameter("@FeeType", FeeType));
            }
            if (CategoryID > 0)
            {
                conditions.Add("[CategoryID]=@CategoryID");
                parameters.Add(new SqlParameter("@CategoryID", CategoryID));
            }
            else if (CategoryID == 0)
            {
                conditions.Add("[CategoryID] not in (select ID from Category)");
            }
            if (ContractID > 0)
            {
                conditions.Add("[ID] in (select [ChargeID] from [Contract_ChargeSummary] where [ContractID]=@ContractID)");
                parameters.Add(new SqlParameter("@ContractID", ContractID));
            }
            else if (!string.IsNullOrEmpty(guid))
            {
                conditions.Add("[ID] in (select [ChargeID] from [Contract_ChargeSummary] where [GUID]=@GUID)");
                parameters.Add(new SqlParameter("@GUID", guid));
            }
            string fieldList = "[ViewChargeSummary].*,'" + SummaryType + "' as [SummaryType] ";
            string Statement = " from [ViewChargeSummary] where  " + string.Join(" and ", conditions.ToArray());
            ViewChargeSummary[] list = new ViewChargeSummary[] { };
            list = GetList<ViewChargeSummary>(fieldList, Statement, parameters, orderBy, startRowIndex, pageSize, out totalRows).ToArray();
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
        public decimal FinalUnitPrice
        {
            get
            {
                if (this.FeeUnitPrice > decimal.MinValue)
                {
                    return this.FeeUnitPrice;
                }
                if (this.SummaryUnitPrice > decimal.MinValue)
                {
                    return this.SummaryUnitPrice;
                }
                return 0;
            }
        }
        public string FinalStartTime
        {
            get
            {
                if (this.FeeStartTime > DateTime.MinValue)
                {
                    return this.FeeStartTime.ToString("yyyy-MM-dd");
                }
                if (this.SummaryStartTime > DateTime.MinValue)
                {
                    return this.SummaryStartTime.ToString("yyyy-MM-dd");
                }
                return "--";
            }
        }
        public string FinalEndTime
        {
            get
            {
                if (this.FeeEndTime > DateTime.MinValue)
                {
                    return this.FeeEndTime.ToString("yyyy-MM-dd");
                }
                if (this.SummaryEndStartTime > DateTime.MinValue)
                {
                    return this.SummaryEndStartTime.ToString("yyyy-MM-dd");
                }
                return "--";
            }
        }
        public string ChargeTypeDesc
        {
            get
            {
                string desc = string.Empty;
                switch (this.TypeID)
                {
                    case 1:
                        desc = "单价*计费面积(月度)";
                        break;
                    case 2:
                        desc = "定额(月度)";
                        break;
                    case 3:
                        desc = "单价*计费面积*公摊系数(月度)";
                        break;
                    case 4:
                        desc = "定额(年度)";
                        break;
                    case 5:
                        desc = "单价*计费面积(按天)";
                        break;
                    case 6:
                        desc = "单价*计费面积/用量(一次性)";
                        break;
                    default:
                        break;
                }
                return desc;
            }
        }
        public int FinalEndType
        {
            get
            {
                if (this.FeeEndTypeID > int.MinValue)
                {
                    return this.FeeEndTypeID;
                }
                if (this.EndTypeID > int.MinValue)
                {
                    return this.EndTypeID;
                }
                return 0;
            }
        }
        public string EndTypeDesc
        {
            get
            {
                string desc = string.Empty;
                switch (this.FinalEndType)
                {
                    case 1:
                        desc = "按当前自然日期";
                        break;
                    case 2:
                        desc = "按计费开始日期";
                        break;
                    default:
                        break;
                }
                return desc;
            }
        }
        public string FeeTypeDesc
        {
            get
            {
                if (this.FeeType == 1)
                {
                    return "周期费用";
                }
                else if (this.FeeType == 4)
                {
                    return "临时费用";
                }
                else if (this.FeeType == 8)
                {
                    return "违约金";
                }
                return string.Empty;
            }
        }
        public int FinalChargeTypeCount
        {
            get
            {
                int FinalChargeTypeCount = -1;
                if (this.ChargeTypeCount > int.MinValue)
                {
                    FinalChargeTypeCount = this.ChargeTypeCount;
                }
                else if (this.SummaryChargeTypeCount > int.MinValue)
                {
                    FinalChargeTypeCount = this.SummaryChargeTypeCount;
                }

                return FinalChargeTypeCount > 0 ? FinalChargeTypeCount : 0;
            }
        }
        public string FinalEndNumberCountDesc
        {
            get
            {
                if (this.EndNumberCount > int.MinValue)
                {
                    switch (this.EndNumberCount)
                    {
                        case 0:
                            return "元";
                            break;
                        case 1:
                            return "角";
                            break;
                        case 2:
                            return "分";
                            break;
                        case 3:
                            return "厘";
                            break;
                        default:
                            break;
                    }
                }
                return string.Empty;
            }
        }
        public string FinalEndNumberTypeDesc
        {
            get
            {
                if (this.EndNumberType > int.MinValue)
                {
                    switch (this.EndNumberType)
                    {
                        case 1:
                            return "月";
                            break;
                        case 2:
                            return "日";
                            break;
                        default:
                            break;
                    }
                }
                return string.Empty;
            }
        }
        public string IsAllowImportDesc
        {
            get
            {
                return this.IsAllowImport ? "是" : "否";
            }
        }
        public string TimeAutoDesc
        {
            get
            {
                return this.TimeAuto ? "是" : "否";
            }
        }
        public string IsOrderFeeOnDesc
        {
            get
            {
                return this.IsOrderFeeOn ? "是" : "否";
            }
        }
        public string DisableDefaultImportFeeDesc
        {
            get
            {
                return this.DisableDefaultImportFee ? "停用" : "启用";
            }
        }
        public string FinalCalculateRule
        {
            get
            {
                string desc = string.Empty;
                if (this.EndTypeID == 3)
                {
                    return "手工指定";
                }
                if (!string.IsNullOrEmpty(this.EndTypeDesc))
                {
                    desc = this.EndTypeDesc;
                }
                if (this.FinalChargeTypeCount >= 0 && !string.IsNullOrEmpty(this.FinalEndNumberTypeDesc))
                {
                    desc += "顺延" + this.FinalChargeTypeCount + this.FinalEndNumberTypeDesc;
                }
                return desc;
            }
        }
        public static ViewChargeSummary GetViewChargeSummaryByChargeID(int ChargeID)
        {
            using (SqlHelper helper = new SqlHelper())
            {
                return GetViewChargeSummaryByChargeID(ChargeID, helper);
            }
        }
        public static ViewChargeSummary GetViewChargeSummaryByChargeID(int ChargeID, SqlHelper helper)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@ID", ChargeID));
            return GetOne<ViewChargeSummary>("select * from [ViewChargeSummary] where [ID]= @ID", parameters, helper);
        }
    }
}
