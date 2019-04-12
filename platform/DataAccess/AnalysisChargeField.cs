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
    /// This object represents the properties and methods of a AnalysisChargeField.
    /// </summary>
    public partial class AnalysisChargeField : EntityBase
    {
        public static AnalysisChargeField GetAnalysisChargeFieldByCode(string PageCode, int ChargeID, SqlHelper helper)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@PageCode", PageCode));
            parameters.Add(new SqlParameter("@ChargeID", ChargeID));
            return GetOne<AnalysisChargeField>("select top 1 * from [AnalysisChargeField] where PageCode=@PageCode and ChargeID=@ChargeID", parameters, helper);
        }
        public static AnalysisChargeField[] GetMonthFeeAnalysisColumns()
        {
            string PageCode = Utility.EnumModel.AnalysisChargeFieldPageCode.MonthFeeAnalysis.ToString();
            var list = AnalysisChargeField.GetAnalysisChargeFields().Where(p => p.PageCode.Equals(PageCode)).ToArray();
            List<int> IDList = new List<int>();
            for (int i = 1; i < 13; i++)
            {
                var data = list.FirstOrDefault(p => p.ChargeID == i);
                if (data == null)
                {
                    data = new AnalysisChargeField();
                    data.ChargeID = i;
                    data.SortOrder = i;
                    data.PageCode = PageCode;
                    data.IsHide = false;
                    data.IsHideTotal = false;
                    data.IsHideReal = false;
                    data.IsHideDiscount = false;
                    data._isHideRest = false;
                    data.FieldType = 2;
                    data.Save();
                }
            }
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@PageCode", PageCode));
            return GetList<AnalysisChargeField>("select * from [AnalysisChargeField] where PageCode=@PageCode", parameters).ToArray();
        }
    }
}
