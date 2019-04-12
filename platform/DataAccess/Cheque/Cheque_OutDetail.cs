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
    /// This object represents the properties and methods of a Cheque_OutDetail.
    /// </summary>
    public partial class Cheque_OutDetail : EntityBase
    {
        public static Ui.DataGrid GetCheque_OutDetailGridByKeywords(int OutSummaryID, string GUID, string orderBy, long startRowIndex, int pageSize)
        {
            long totalRows = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[GUID]=@GUID");
            parameters.Add(new SqlParameter("@GUID", GUID));
            if (OutSummaryID > 0)
            {
                conditions.Add("[OutSummaryID]=@OutSummaryID");
                parameters.Add(new SqlParameter("@OutSummaryID", OutSummaryID));
            }
            string fieldList = "[Cheque_OutDetail].*";
            string Statement = " from [Cheque_OutDetail] where  " + string.Join(" or ", conditions.ToArray());
            Cheque_OutDetail[] list = GetList<Cheque_OutDetail>(fieldList, Statement, parameters, orderBy, startRowIndex, pageSize, out totalRows).ToArray();
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            string footertext = "select '合计' as [ProductName],'' as [ModelNumber],'' as [Unit], sum(isnull([TotalCost],0)) as TotalCost,sum(isnull([TotalTaxCost],0)) as TotalTaxCost from [Cheque_OutDetail] where  " + string.Join(" or ", conditions.ToArray()) + @" UNION ALL select '税价合计(大写)' as[ProductName], dbo.MoneyToCapital(sum(isnull([TotalSummaryCost],0)),0,2) as [ModelNumber],'小写' as[Unit],  sum(isnull([TotalSummaryCost],0)) as TotalCost, 0 as TotalTaxCost from [Cheque_OutDetail] where " + string.Join(" or ", conditions.ToArray());
            dg.footer = GetList<Cheque_OutDetail>(footertext, parameters).ToArray();
            dg.page = pageSize;
            return dg;
        }
        public static Cheque_OutDetail[] GetCheque_OutDetailList(int OutSummaryID, string GUID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[GUID]=@GUID");
            parameters.Add(new SqlParameter("@GUID", GUID));
            if (OutSummaryID > 0)
            {
                conditions.Add("[OutSummaryID]=@OutSummaryID");
                parameters.Add(new SqlParameter("@OutSummaryID", OutSummaryID));
            }
            string Statement = "select * from [Cheque_OutDetail] where  " + string.Join(" or ", conditions.ToArray());
            Cheque_OutDetail[] list = GetList<Cheque_OutDetail>(Statement, parameters).ToArray();
            return list;
        }
        public static Cheque_OutDetail GetCheque_OutDetail(int OutSummaryID, int ProductID)
        {
            using (SqlHelper helper = new SqlHelper())
            {
                return GetCheque_OutDetail(OutSummaryID, ProductID, helper);
            }
        }
        public static Cheque_OutDetail GetCheque_OutDetail(int OutSummaryID, int ProductID, SqlHelper helper)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (ProductID > 0)
            {
                conditions.Add("[ProductID]=@ProductID");
                parameters.Add(new SqlParameter("@ProductID", ProductID));
            }
            if (OutSummaryID > 0)
            {
                conditions.Add("[OutSummaryID]=@OutSummaryID");
                parameters.Add(new SqlParameter("@OutSummaryID", OutSummaryID));
            }
            string Statement = "select * from [Cheque_OutDetail] where  " + string.Join(" and ", conditions.ToArray());
            return GetOne<Cheque_OutDetail>(Statement, parameters, helper);
        }
    }
}
